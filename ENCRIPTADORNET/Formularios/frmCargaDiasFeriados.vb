Imports System.Data.SqlClient

Public Class frmCargaDiasFeriados

    Dim meses As List(Of Fecha)
    Dim años As List(Of Fecha)
    Dim dias_oficiales As List(Of Fecha)
    Dim dias_feriados As List(Of DIAS_FERIADOS)
    Dim dias_feriados_excel As List(Of DIAS_FERIADOS)
    Dim dias_festivos As List(Of Holiday)


    Dim fecha_selected As DateTime

    Dim pais_seleted As Byte

    Dim click_cmbAño = False
    Dim click_cmbMes = False
    Dim click_dtpFecha = False

    Dim cmbYearSelect, cmbMesSelect As Integer

    Dim api As HolidayApi = New HolidayApi()

    Dim dias_fijos() As Fecha

    Private Sub frmCargaDiasFeriados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        meses = New List(Of Fecha)
        años = New List(Of Fecha)
        dias_feriados = New List(Of DIAS_FERIADOS)

        LlenarMeses()
        LlenarAños()

        dias_feriados_excel = CargaExcelFeriados()

    End Sub

    Private Function CargaExcelFeriados() As List(Of DIAS_FERIADOS)
        Dim app As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        Dim libro As Microsoft.Office.Interop.Excel.Workbook
        Dim hoja As Microsoft.Office.Interop.Excel.Worksheet
        Dim dia, tipo_dia As Microsoft.Office.Interop.Excel.Range
        Dim path As String = BuscarCarpetaRecursos(System.Windows.Forms.Application.StartupPath())

        Dim dia_feriado As DIAS_FERIADOS

        CargaExcelFeriados = New List(Of DIAS_FERIADOS)

        If path <> String.Empty Then
            libro = app.Workbooks.Open(path)
            hoja = libro.Worksheets("Feriados")

            For fila = 1 To 13
                If fila > 1 And fila <= 13 Then
                    If CType(hoja.Cells(fila, 1), Microsoft.Office.Interop.Excel.Range).Value Is Nothing Then
                        Exit For
                    End If
                    dia = CType(hoja.Cells(fila, 1), Microsoft.Office.Interop.Excel.Range)
                    tipo_dia = CType(hoja.Cells(fila, 2), Microsoft.Office.Interop.Excel.Range)

                    Dim fecha_add As DateTime = DateTime.Parse(dia.Value())
                    Dim tipo_add As Integer = Int32.Parse(tipo_dia.Value())

                    dia_feriado = New DIAS_FERIADOS With {.fecha = fecha_add, .tipo_dia_feriado = tipo_add}

                    CargaExcelFeriados.Add(dia_feriado)
                End If
            Next
        End If
    End Function

    Private Function BuscarCarpetaRecursos(path As String) As String

        Dim directorios As Integer = My.Computer.FileSystem.GetDirectories(path).Count()

        For Each foundFolder As String In My.Computer.FileSystem.GetDirectories(path)

            Dim carpeta As String = foundFolder
            If carpeta.Contains("Resources") Then
                For Each foundFile As String In My.Computer.FileSystem.GetFiles(carpeta)
                    Dim archivo As String = foundFile
                    If archivo.Contains("Feriados") Then
                        Return archivo
                    End If
                Next
            End If
        Next
        Return String.Empty
    End Function

    Private Sub LlenarAños()
        Dim primer_fecha As DateTime = New DateTime(DateTime.Now.Year, 1, 1)

        For i = 1 To 100
            años.Add(New Fecha With {.Nombre = primer_fecha.ToString("yyyy"), .Numero = primer_fecha.Year})
            primer_fecha = primer_fecha.AddYears(1)
        Next

        cmbAño.DataSource = años
        cmbAño.ValueMember = "Numero"
        cmbAño.DisplayMember = "Nombre"
    End Sub

    Private Sub LlenarMeses()
        Dim primer_fecha As DateTime = New DateTime(DateTime.Now.Year, 1, 1)

        For i = 1 To 12
            meses.Add(New Fecha With {.Nombre = primer_fecha.ToString("MMMM"), .Numero = primer_fecha.Month})
            primer_fecha = primer_fecha.AddMonths(1)
        Next

        cmbMes.DataSource = meses
        cmbMes.ValueMember = "Numero"
        cmbMes.DisplayMember = "Nombre"
    End Sub

    Private Sub cmbMes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMes.SelectedIndexChanged
        Try
            CargarDiasMes()
            SeleccionarCalendario()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error en Combo Box", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub SeleccionarCalendario()
        Try

            If cmbAño.SelectedValue IsNot Nothing AndAlso cmbMes.SelectedValue IsNot Nothing Then
                Dim año As Integer = (CType(cmbAño.SelectedItem, Fecha)).Numero
                Dim mes As Integer = (CType(cmbMes.SelectedItem, Fecha)).Numero
                SeleccionarFecha(New DateTime(año, mes, 1))
                dias_feriados = ConsultaFeriadosPorMes(New DateTime(año, mes, 1))
                Dim dt As DataTable = LlenarListFeriados(dias_feriados)
                dtGrdVwFeriados.DataSource = dt
                dtGrdVwFeriados.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                dtGrdVwFeriados.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                dtGrdVwFeriados.Refresh()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error en Calendario", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Function LlenarListFeriados(ByVal dias_feriados As List(Of DIAS_FERIADOS)) As DataTable
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Fecha")
        dt.Columns.Add("Tipo")

        For Each dia As DIAS_FERIADOS In dias_feriados
            Dim dr As DataRow = dt.NewRow()
            dr("Fecha") = dia.fecha.ToString("dd-MM-yyyy")

            If dia.tipo_dia_feriado = 1 Then
                dr("Tipo") = "Mexico"
            ElseIf dia.tipo_dia_feriado = 2 Then
                dr("Tipo") = "Estados Unidos"
            ElseIf dia.tipo_dia_feriado = 3 Then
                dr("Tipo") = "Ambos"
            End If

            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Private Function ConsultaFeriadosPorMes(ByVal fecha As DateTime) As List(Of DIAS_FERIADOS)
        Using context As CATALOGOSEntities = New CATALOGOSEntities()
            Dim fecha1 As DateTime = New DateTime(fecha.Year, fecha.Month, fecha.Day)
            Dim fecha2 As DateTime = New DateTime(fecha.Year, fecha.Month, UltimoDiaMes(fecha))
            Dim resultado As List(Of DIAS_FERIADOS) = context.DIAS_FERIADOS.Where(Function(w) w.fecha >= fecha1 AndAlso w.fecha <= fecha2).OrderBy(Function(o) o.fecha).ToList()
            Return resultado
        End Using
    End Function

    Private Sub SeleccionarFecha(fecha As Date)
        dtpMesFestivo.SelectionStart = fecha
        dtpMesFestivo.SelectionEnd = fecha
    End Sub

    Private Sub CargarDiasMes()
        If click_cmbMes Then

            If cmbMes.SelectedValue IsNot Nothing Then
                Dim fecha_inicio As DateTime = New DateTime(CInt(cmbAño.SelectedValue), CInt(cmbMes.SelectedValue), 1)
                Dim fecha_fin As DateTime = New DateTime(CInt(cmbAño.SelectedValue), CInt(cmbMes.SelectedValue), UltimoDiaMes(fecha_inicio))

                Using context As CATALOGOSEntities = New CATALOGOSEntities()
                    Dim lista_dias As List(Of DIAS_FERIADOS) = context.DIAS_FERIADOS.Where(Function(w) w.fecha >= fecha_inicio AndAlso w.fecha <= fecha_fin).ToList()

                    If lista_dias.Count() = 0 Then
                        Dim dialogResult As DialogResult = MessageBox.Show("No hay dias cargados para este Mes, ¿Desea cargar todos los fines de semana de este mes?", "Sin Dias Feriados", MessageBoxButtons.YesNo)

                        If dialogResult = DialogResult.Yes Then
                            CargarFinesFecha(fecha_inicio.Year, fecha_inicio.Month)
                        End If
                    End If
                End Using
            End If

            LimitarDatePicker(True)
        End If
    End Sub

    Private Sub LimitarDatePicker(ByVal combos As Boolean)
        Dim fecha_inicio, fecha_fin As DateTime

        If combos Then
            fecha_inicio = New DateTime(CInt(cmbAño.SelectedValue), CInt(cmbMes.SelectedValue), 1)
            fecha_fin = New DateTime(CInt(cmbAño.SelectedValue), CInt(cmbMes.SelectedValue), UltimoDiaMes(fecha_inicio))
        Else
            fecha_inicio = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
            fecha_fin = New DateTime(DateTime.Now.Year, DateTime.Now.Month, UltimoDiaMes(fecha_inicio))
        End If

        If fecha_inicio > dtpMesFestivo.MaxDate Then
            dtpMesFestivo.MaxDate = fecha_fin
            dtpMesFestivo.MinDate = fecha_inicio
        Else
            dtpMesFestivo.MinDate = fecha_inicio
            dtpMesFestivo.MaxDate = fecha_fin
        End If
    End Sub

    Private Sub CargarFinesFecha(ByVal year As Integer, ByVal Optional mes As Integer = 0)
        Me.cmbYearSelect = year
        Me.cmbMesSelect = mes

        If Not bgwCargaFines.IsBusy Then
            bgwCargaFines.RunWorkerAsync()
        Else
            MessageBox.Show("Ya hay una tarea ejecutandose. Favor de Esperar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function UltimoDiaMes(fecha_inicio As Date) As Integer
        Dim dia As Integer = 0
        Dim fecha_sum As DateTime = fecha_inicio

        Do
            fecha_sum = fecha_sum.AddDays(1)
            dia += 1
        Loop While fecha_sum.Month = fecha_inicio.Month

        Return dia
    End Function

    Private Sub cmbAño_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAño.SelectedIndexChanged
        Try
            CargarDiasAño()
            SeleccionarCalendario()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error en Combo Box", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub CargarDiasAño()
        If click_cmbAño Then

            If cmbAño.SelectedValue IsNot Nothing Then
                Dim fecha_inicio As DateTime = New DateTime(CInt(cmbAño.SelectedValue), 1, 1)
                Dim fecha_fin As DateTime = New DateTime(CInt(cmbAño.SelectedValue), 12, 31)

                Using context As CATALOGOSEntities = New CATALOGOSEntities()
                    Dim lista_dias As List(Of DIAS_FERIADOS) = context.DIAS_FERIADOS.Where(Function(w) w.fecha >= fecha_inicio AndAlso w.fecha <= fecha_fin).ToList()

                    If lista_dias.Count() = 0 Then
                        Dim dialogResult As DialogResult = MessageBox.Show("No hay dias cargados para este año, ¿Desea cargar todos los fines de semana y festivos oficiales de este año?", "Sin Dias Feriados", MessageBoxButtons.YesNo)

                        If dialogResult = DialogResult.Yes Then
                            CargarFinesFecha(fecha_inicio.Year)
                        End If
                    End If
                End Using
            End If

            LimitarDatePicker(True)
        End If
    End Sub

    Private Sub CargarDiasFestivos(dias_festivos As List(Of Holiday), fines_semana As List(Of DIAS_FERIADOS))
        Dim cnn As SqlConnection
        Dim transaction As SqlTransaction
        Dim cmd As SqlCommand

        Using context As CATALOGOSEntities = New CATALOGOSEntities()
            cnn = CType(context.Database.Connection, SqlConnection)
            cnn.Open()
            cmd = cnn.CreateCommand()
            transaction = cnn.BeginTransaction()
            cmd.Connection = cnn
            cmd.Transaction = transaction

            Try
                Dim afectados As Integer = 0

                Dim dias_año As List(Of DIAS_FERIADOS) = ConsultaFeriadosPorAnio(Me.cmbYearSelect)

                For Each dia As Holiday In dias_festivos

                    Dim valida_dia As Boolean = ValidaDiaFeriado(dia, dias_año)

                    If valida_dia Then
                        cmd.Parameters.Clear()
                        cmd.CommandText = "INSERT INTO DIAS_FERIADOS(fecha, tipo_dia_feriado) VALUES(@param1, @param2)"
                        cmd.Parameters.AddWithValue("@param1", dia.fecha)
                        cmd.Parameters.AddWithValue("@param2", 1)
                        afectados += cmd.ExecuteNonQuery()
                    End If
                Next

                transaction.Commit()
                MessageBox.Show($"Se cargaron {afectados} dias", "Carga Dias Festivos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                transaction.Rollback()
                MessageBox.Show(ex.Message, "Error al Cargar Dias Festivos", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Finally
                cnn.Close()
            End Try
        End Using
    End Sub

    Private Function ValidaDiaFeriado(dia As Holiday, dias_año As List(Of DIAS_FERIADOS)) As Boolean
        Dim fecha1 As DateTime = New DateTime(dia.fecha.Year, dia.fecha.Month, dia.fecha.Day) + New TimeSpan(0, 0, 0)
        Dim fecha2 As DateTime = New DateTime(dia.fecha.Year, dia.fecha.Month, dia.fecha.Day) + New TimeSpan(23, 59, 59)
        Dim fecha As DIAS_FERIADOS = dias_año.Where(Function(w) w.fecha >= fecha1 And w.fecha <= fecha2).FirstOrDefault()

        If fecha IsNot Nothing Then
            ValidaDiaFeriado = False
        Else
            ValidaDiaFeriado = True
        End If
    End Function

    Private Function ConsultaFeriadosPorAnio(año As Integer) As List(Of DIAS_FERIADOS)
        Using context As CATALOGOSEntities = New CATALOGOSEntities()
            Dim fecha_inicio As DateTime = New DateTime(año, 1, 1)
            Dim fecha_fin As DateTime = New DateTime(año, 12, 31)

            ConsultaFeriadosPorAnio = (From df In context.DIAS_FERIADOS
                                       Where df.fecha >= fecha_inicio And df.fecha <= fecha_fin
                                       Select df).ToList()
        End Using

    End Function

    Private Sub dtGrdVwFeriados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtGrdVwFeriados.CellDoubleClick
        Try
            btnGuardar.Enabled = True
            fecha_selected = DateTime.Parse(dtGrdVwFeriados.Rows(e.RowIndex).Cells(0).Value.ToString())
            Dim dia_nombre As String = fecha_selected.ToString("dddd")

            If dia_nombre <> "sábado" AndAlso dia_nombre <> "domingo" Then
                btnCancelar.Text = "Eliminar"
                btnGuardar.Text = "Actualizar"
                SeleccionarFecha(fecha_selected)
                Dim pais As String = dtGrdVwFeriados.Rows(e.RowIndex).Cells(1).Value.ToString()
                pais_seleted = 0

                Select Case pais
                    Case "Mexico"
                        pais_seleted = 1
                        rbMexico.Checked = True
                    Case "Estados Unidos"
                        pais_seleted = 2
                        rbEUA.Checked = True
                    Case "Ambos"
                        pais_seleted = 3
                        rbAmbos.Checked = True
                End Select

                Dim existe As Boolean = ConsultarFecha(New DIAS_FERIADOS With {
                    .tipo_dia_feriado = pais_seleted,
                    .fecha = fecha_selected
                })
            Else
                MessageBox.Show("No se puede editar o eliminar un fin de semana", "Fines de Semana", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnCancelar.Text = "Cancelar"
                btnGuardar.Text = "Guardar"
                btnGuardar.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al Seleccionar", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Function ConsultarFecha(ByVal dia As DIAS_FERIADOS) As Boolean
        Using context As CATALOGOSEntities = New CATALOGOSEntities()
            Dim resultado As DIAS_FERIADOS = context.DIAS_FERIADOS.Where(Function(w) w.fecha = dia.fecha).FirstOrDefault()

            If resultado Is Nothing Then
                Return False
            Else
                Return True
            End If
        End Using
    End Function

    Private Sub dtpMesFestivo_Enter(sender As Object, e As EventArgs) Handles dtpMesFestivo.Enter
        btnGuardar.Enabled = True
    End Sub

    Private Sub dtpMesFestivo_Leave(sender As Object, e As EventArgs) Handles dtpMesFestivo.Leave
        If btnGuardar.Focused Then
            btnGuardar.PerformClick()
        Else
            btnGuardar.Enabled = False
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim cnn As SqlConnection

        Try

            If btnGuardar.Text = "Guardar" Then
                Dim dia As DIAS_FERIADOS = New DIAS_FERIADOS()
                dia.tipo_dia_feriado = ObtenerPais()
                dia.fecha = dtpMesFestivo.SelectionStart

                If ConsultarFecha(dia) Then
                    MessageBox.Show("Esta fecha ya esta dada de alta", "Fecha Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else

                    Using context As CATALOGOSEntities = New CATALOGOSEntities()
                        cnn = CType(context.Database.Connection, SqlConnection)
                        cnn.Open()
                        Dim cmd As SqlCommand = cnn.CreateCommand()
                        cmd.CommandText = "INSERT INTO DIAS_FERIADOS(fecha, tipo_dia_feriado) VALUES(@param1, @param2)"
                        cmd.Parameters.AddWithValue("@param1", dia.fecha)
                        cmd.Parameters.AddWithValue("@param2", dia.tipo_dia_feriado)
                        Dim afectados As Integer = cmd.ExecuteNonQuery()
                        cnn.Close()

                        If afectados > 0 Then
                            SeleccionarCalendario()
                        End If
                    End Using
                End If
            ElseIf btnGuardar.Text = "Actualizar" Then

                Using context As CATALOGOSEntities = New CATALOGOSEntities()
                    Dim dia As DIAS_FERIADOS = context.DIAS_FERIADOS.Where(Function(w) w.fecha = fecha_selected AndAlso w.tipo_dia_feriado = pais_seleted).FirstOrDefault()
                    dia.tipo_dia_feriado = ObtenerPais()
                    cnn = CType(context.Database.Connection, SqlConnection)
                    cnn.Open()
                    Dim cmd As SqlCommand = cnn.CreateCommand()
                    cmd.CommandText = "UPDATE DIAS_FERIADOS SET tipo_dia_feriado=@param1 WHERE fecha=@param2"
                    cmd.Parameters.AddWithValue("@param1", dia.tipo_dia_feriado)
                    cmd.Parameters.AddWithValue("@param2", dia.fecha)
                    Dim afectados As Integer = cmd.ExecuteNonQuery()
                    cnn.Close()

                    If afectados > 0 Then
                        SeleccionarCalendario()
                    End If
                End Using
            End If

            btnCancelar.Text = "Cancelar"
            btnGuardar.Text = "Guardar"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        Finally
            btnGuardar.Enabled = False
        End Try
    End Sub

    Private Function ObtenerPais() As Byte
        Dim respuesta As Byte = 0

        If rbMexico.Checked Then
            respuesta = 1
        ElseIf rbEUA.Checked Then
            respuesta = 2
        ElseIf rbAmbos.Checked Then
            respuesta = 3
        End If

        Return respuesta
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If btnCancelar.Text = "Cancelar" Then
        ElseIf btnCancelar.Text = "Eliminar" Then
            Dim dialogResult As DialogResult = MessageBox.Show("Esta seguro de borrar el dia feriado?", "Borrando Dia Feriado", MessageBoxButtons.YesNo)

            If dialogResult = DialogResult.Yes Then

                Using context As CATALOGOSEntities = New CATALOGOSEntities()
                    Dim dia As DIAS_FERIADOS = context.DIAS_FERIADOS.Where(Function(w) w.fecha = fecha_selected AndAlso w.tipo_dia_feriado = pais_seleted).FirstOrDefault()
                    Dim cnn As SqlConnection = CType(context.Database.Connection, SqlConnection)
                    cnn.Open()
                    Dim cmd As SqlCommand = cnn.CreateCommand()
                    cmd.CommandText = "DELETE FROM DIAS_FERIADOS WHERE fecha=@param1 AND tipo_dia_feriado=@param2"
                    cmd.Parameters.AddWithValue("@param1", dia.fecha)
                    cmd.Parameters.AddWithValue("@param2", dia.tipo_dia_feriado)
                    Dim afectados As Integer = cmd.ExecuteNonQuery()

                    If afectados > 0 Then
                        SeleccionarCalendario()
                    End If
                End Using
            ElseIf dialogResult = DialogResult.No Then
                Return
            End If
        End If

        btnCancelar.Text = "Cancelar"
        btnGuardar.Text = "Guardar"
        btnGuardar.Enabled = False

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cmbMes_Click(sender As Object, e As EventArgs) Handles cmbMes.Click
        click_cmbMes = True
    End Sub

    Private Sub cmbAño_Click(sender As Object, e As EventArgs) Handles cmbAño.Click
        click_cmbAño = True
    End Sub

    Private Sub bgwCargaFines_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwCargaFines.DoWork
        Cargando(True)
        Dim cnn As SqlConnection
        Dim transaction As SqlTransaction
        Dim cmd As SqlCommand

        Using context As CATALOGOSEntities = New CATALOGOSEntities()
            cnn = CType(context.Database.Connection, SqlConnection)
            cnn.Open()
            cmd = cnn.CreateCommand()
            transaction = cnn.BeginTransaction()
            cmd.Connection = cnn
            cmd.Transaction = transaction

            Try
                Dim fecha_contador As DateTime
                Dim afectados As Integer = 0

                If Me.cmbMesSelect <= 0 Then
                    fecha_contador = New DateTime(Me.cmbYearSelect, 1, 1)
                    Do
                        Dim nombre_dia As String = fecha_contador.ToString("dddd")

                        If nombre_dia = "sábado" OrElse nombre_dia = "domingo" Then
                            afectados += InsertarDiaFeriado(cnn, cmd, fecha_contador, 3)
                        End If

                        fecha_contador = fecha_contador.AddDays(1)
                    Loop While fecha_contador.Year = Me.cmbYearSelect
                Else
                    fecha_contador = New DateTime(Me.cmbYearSelect, Me.cmbMesSelect, 1)
                    Do
                        Dim nombre_dia As String = fecha_contador.ToString("dddd")

                        If nombre_dia = "sábado" OrElse nombre_dia = "domingo" Then
                            afectados += InsertarDiaFeriado(cnn, cmd, fecha_contador, 3)
                        End If

                        fecha_contador = fecha_contador.AddDays(1)
                    Loop While fecha_contador.Month = Me.cmbMesSelect
                End If

                transaction.Commit()

                cmd = cnn.CreateCommand()
                transaction = cnn.BeginTransaction()
                cmd.Connection = cnn
                cmd.Transaction = transaction

                Dim feriados As List(Of DIAS_FERIADOS) = ConsultaFeriadosPorAnio(cmbYearSelect)
                Dim valida_cargado As Boolean = False
                Dim fecha_iterada As DIAS_FERIADOS


                For Each feriado As DIAS_FERIADOS In dias_feriados_excel
                    Dim fecha_insert As Date = New DateTime(cmbYearSelect, feriado.fecha.Month, feriado.fecha.Day)
                    fecha_iterada = feriados.Where(Function(w) w.fecha = fecha_insert).FirstOrDefault()

                    If fecha_iterada Is Nothing Then
                        afectados += InsertarDiaFeriado(cnn, cmd, fecha_insert, feriado.tipo_dia_feriado)
                    End If
                Next

                transaction.Commit()

                MessageBox.Show($"Se cargaron {afectados} dias", "Carga Fines de semana", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                transaction.Rollback()
                MessageBox.Show(ex.Message, "Error al Cargar Fines de Semana", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Finally
                cnn.Close()
            End Try
        End Using
    End Sub

    Private Function InsertarDiaFeriado(cnn As SqlConnection, cmd As SqlCommand, fecha_contador As Date, tipo As Integer) As Integer
        cmd.Parameters.Clear()
        cmd.CommandText = "INSERT INTO DIAS_FERIADOS(fecha, tipo_dia_feriado) VALUES(@param1, @param2)"
        cmd.Parameters.AddWithValue("@param1", fecha_contador)
        cmd.Parameters.AddWithValue("@param2", tipo)
        InsertarDiaFeriado = cmd.ExecuteNonQuery()
    End Function



    Private Sub Cargando(ByVal cargando As Boolean)
        If loading.InvokeRequired Then
            loading.Invoke(New MethodInvoker(Function()
                                                 loading.Visible = cargando
                                                 loading.BackColor = Color.FromArgb(153, 180, 209)
                                                 loading.Refresh()
                                             End Function))
            dtGrdVwFeriados.Invoke(New MethodInvoker(Function()
                                                         dtGrdVwFeriados.Visible = Not cargando
                                                         dtGrdVwFeriados.Refresh()
                                                     End Function))
        Else
            loading.Visible = cargando
            loading.BackColor = Color.FromArgb(153, 180, 209)
            loading.Refresh()
            dtGrdVwFeriados.Visible = Not cargando
            dtGrdVwFeriados.Refresh()
        End If
    End Sub

    Private Sub bgwCargaFines_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwCargaFines.RunWorkerCompleted
        Cargando(False)
        SeleccionarCalendario()
    End Sub

    Private Sub bgwCargaFestivos_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)

    End Sub

    Public Class Fecha
        Private _Numero As Int32
        Public Property Numero() As Int32
            Get
                Return _Numero
            End Get
            Set(ByVal value As Int32)
                _Numero = value
            End Set
        End Property

        Private _Nombre As String
        Public Property Nombre() As String
            Get
                Return _Nombre
            End Get
            Set(ByVal value As String)
                _Nombre = value
            End Set
        End Property

        Private _mes As Integer
        Public Property Mes() As Integer
            Get
                Return _mes
            End Get
            Set(ByVal value As Integer)
                _mes = value
            End Set
        End Property

        Private _pais As Integer
        Public Property Pais() As Integer
            Get
                Return _pais
            End Get
            Set(ByVal value As Integer)
                _pais = value
            End Set
        End Property

        Private _diaMex As Integer
        Public Property diaMex() As Integer
            Get
                Return _diaMex
            End Get
            Set(ByVal value As Integer)
                _diaMex = value
            End Set
        End Property

        Private _diaUsa As Integer
        Public Property diaUsa() As Integer
            Get
                Return _diaUsa
            End Get
            Set(ByVal value As Integer)
                _diaUsa = value
            End Set
        End Property
    End Class


End Class