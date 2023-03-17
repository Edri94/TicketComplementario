Imports System.ComponentModel

Public Class frmManttoParHor


    Public DatosEditados As Boolean = False
    Dim Mn_PrevCol As Long, Mn_PrevRow As Long ' Variables para almacenar la columna y renglon respectivamente previos al actual
    Dim Mb_CambioHr As Boolean
    Public bindingSource1 As BindingSource
    Public MsTabla As String


    Private Sub dtpFechaFin_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        GuardaDatos()
    End Sub

    Private Sub GuardaDatos()
        Dim Ln_x As Long
        Dim ResActualiza As Integer
        Dim ValorSeleccionado As String = cboTOperacion.SelectedValue.ToString

        On Error GoTo ManejoErrores

        Dim d As New Datasource

        If ValidaHr() Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            For Ln_x = 0 To grdHorarios.Rows.Count - 1

                ResActualiza = d.ActualizaHorariosOpeCash(MsTabla, Convert.ToString(grdHorarios.Rows.Item(Ln_x).Cells(1).Value), Convert.ToString(grdHorarios.Rows.Item(Ln_x).Cells(2).Value), Convert.ToString(grdHorarios.Rows.Item(Ln_x).Cells(3).Value), Convert.ToString(grdHorarios.Rows.Item(Ln_x).Cells(4).Value))
                If ResActualiza <= 0 Then
                    MsgBox("No ha sido posible actualizar los horarios", MsgBoxStyle.Exclamation, "Aviso")
                    Return
                End If

            Next Ln_x

            DatosEditados = False
            MsgBox("Los horarios han sido actualizados.", MsgBoxStyle.Information, "Aviso")

            Me.Cursor = System.Windows.Forms.Cursors.Default


        End If

        Exit Sub
ManejoErrores:
        MsgBox("Ha ocurrido un error en GuardaDatos" & Err.Number & ": " & Err.Description, MsgBoxStyle.Critical, "Guarda Datos")

    End Sub

    Private Sub frmManttoParHor_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub

    Private Function ValidaHr() As Boolean

        On Error GoTo ManejoErrores

        Dim Ls_NomCampo, Ls_Operativa As String
        Dim Ln_NewRow As Long, Ln_NewCol As Long
        Dim hrini, hrfin, hrpass As String

        For Ln_x = 0 To grdHorarios.Rows.Count - 1

            hrini = Convert.ToString(grdHorarios.Rows.Item(Ln_x).Cells(1).Value)
            hrfin = Convert.ToString(grdHorarios.Rows.Item(Ln_x).Cells(2).Value)
            hrpass = Convert.ToString(grdHorarios.Rows.Item(Ln_x).Cells(3).Value)
            Ls_Operativa = Convert.ToString(grdHorarios.Rows.Item(Ln_x).Cells(0).Value)

            'Validaremos las horas proporcionadas sean validas
            If Not IsDate(hrini) Or Not IsDate(hrfin) Or Not IsDate(hrpass) Then
                MsgBox("Debe introducir horarios válidos, para " + Ls_Operativa + " corrija. ")
            End If

            'Valida la hora de inicio no sea mayor a la hora fin
            If CDate(hrfin) < CDate(hrini) And CDate(hrini) <> CDate("00:00") And CDate(hrfin) <> CDate("00:00") And CDate(hrpass) <> CDate("00:00") Then '------RACB 12/03/2021
                'MsgBox("La hora inicial es " + CDate(hrini).ToString + " la hora final es " + CDate(hrfin).ToString)
                'Set the current cell to the cell in column 1, Row Ln_x.
                grdHorarios.CurrentCell = grdHorarios.Item(1, Ln_x)
                MsgBox("La Hora de Inicio debe ser menor o igual a la Hora de Fin", vbInformation, "Hora Incorrecta") '------RACB 12/03/2021
                Return False
                Exit Function
            End If

            'Valida la hora password no sea mayor a la hora fin
            If CDate(hrpass) < CDate(hrfin) And CDate(hrini) <> CDate("00:00") And CDate(hrfin) <> CDate("00:00") And CDate(hrpass) <> CDate("00:00") Then '------RACB 12/03/2021
                'MsgBox("La hora inicial es " + CDate(hrini).ToString + " la hora final es " + CDate(hrfin).ToString)
                grdHorarios.CurrentCell = grdHorarios.Item(3, Ln_x)
                MsgBox("La Hora de Fin debe ser menor o igual a la Hora de Password", vbInformation, "Hora Incorrecta") '------RACB 12/03/2021
                Return False
                Exit Function
            End If

        Next Ln_x

        ValidaHr = True
        Exit Function
ManejoErrores:
        MsgBox("Ha ocurrido un error en ValidaHr" & Err.Number & ": " & Err.Description, MsgBoxStyle.Critical, "Valida Horarios")
        ValidaHr = False
    End Function


    Private Sub LlenaDatos(TipoOperacion As String)

        On Error GoTo ManejoErrores

        If DatosEditados Then

            If MsgBox("Editaste algunos horarios y perderás los cambios ¿deseas continuar?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                GoTo TraeHorarios
            Else
                Return
            End If
        Else
            GoTo TraeHorarios
        End If

TraeHorarios:

        Dim Ln_CadValida As Integer
        bindingSource1 = New BindingSource()
        Dim gs_sql As String
        Dim d As New Datasource
        Dim dt As DataTable

        DatosEditados = False

        If InStr(TipoOperacion, ".") = 0 Then

            gs_sql = "select descripcion_operacion=(select distinct op.descripcion_operacion_definida " &
                      "from OPERACION_DEFINIDA op (nolock) where op.operacion_definida_global=hr.operacion_definida_global " &
                     "and agencia in (1,3)), HRInicio=convert(varchar(5), hr.hora_inicio, 108) , HRFin=convert(varchar(5), hr.hora_fin, 108), HRPwd=convert(varchar(5), hr.hora_password, 108), hr.parametro " &
                     "from " & MsTabla & " hr (nolock) where rtrim(ltrim(descripcion))='" & TipoOperacion & "' order by 1"

            dt = New DataTable
            dt = d.RealizaConsulta(gs_sql)

            If dt.Rows.Count > 0 Then
                grdHorarios.DataSource = dt
                'grdHorarios.Columns("descripcion_operacion").ReadOnly = True
                grdHorarios.Columns("parametro").Visible = False
                grdHorarios.AllowUserToResizeColumns = False
                grdHorarios.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                grdHorarios.Columns("descripcion_operacion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                grdHorarios.Columns("HRInicio").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                grdHorarios.Columns("HRFin").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                grdHorarios.Columns("HRPwd").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                grdHorarios.Columns("descripcion_operacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                grdHorarios.Columns("HRInicio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                grdHorarios.Columns("HRFin").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                grdHorarios.Columns("HRPwd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                grdHorarios.Columns("descripcion_operacion").ReadOnly = True
                DatosEditados = False

            Else
                MsgBox("No hay horarios para el Tipo de Operación seleccionado.", MsgBoxStyle.Information, "Consulta")
            End If
        End If
        Exit Sub
ManejoErrores:
        MsgBox("Ha ocurrido un error en LlenaDatos" & Err.Number & ": " & Err.Description, MsgBoxStyle.Critical, "Llena Datos")

    End Sub

    Private Sub cboTOperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTOperacion.SelectedIndexChanged

        Dim IndiceSeleccionado As Integer = cboTOperacion.SelectedIndex

        If IndiceSeleccionado = -1 Then Return
        Dim ValorSeleccionado As String = cboTOperacion.SelectedValue.ToString

        If cboTOperacion.FindStringExact(ValorSeleccionado) <> -1 Then
            LlenaDatos(ValorSeleccionado)
        End If



    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click

        If MsgBox("¿Deseas salir?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then '------RACB 12/03/2021
            Me.Close() '------RACB 12/03/2021
        End If '------RACB 12/03/2021

        'If DatosEditados Then

        '    If MsgBox("Editaste algunos horarios y perderás los cambios ¿deseas salir?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
        '        Me.Close()
        '    Else
        '        Return
        '    End If
        'Else
        '    Me.Close()
        'End If

    End Sub

    Private Sub frmManttoParHor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim d As New Datasource
        Dim dt As New DataTable

        DatosEditados = False

        gs_sql = "select distinct ltrim(rtrim(descripcion)) as descripcion from " + MsTabla + " (nolock)"

        dt = d.RealizaConsulta(gs_sql)

        If dt.Rows.Count > 0 Then

            cboTOperacion.DataSource = dt
            cboTOperacion.DisplayMember = "descripcion"
            cboTOperacion.ValueMember = "descripcion"

        Else
            MsgBox("No hay información a desplegar combo", MessageBoxButtons.OK)
        End If

        cboTOperacion.SelectedIndex = -1

    End Sub

    Private Sub cboTOperacion_DataSourceChanged(sender As Object, e As EventArgs) Handles cboTOperacion.DataSourceChanged

    End Sub



    Private Sub grdHorarios_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles grdHorarios.CellValidating

        Dim headerText As String
        Dim hrini, hrfin, hrpwd As String

        'If (DatosEditados = True) Then
        headerText = grdHorarios.Columns(e.ColumnIndex).HeaderText

            'Si acaba de editar la columna HRInicio, hora inicial veremos sea una hora válida
            If (headerText.Equals("HRInicio")) Then
                DatosEditados = True
                hrini = Convert.ToString(e.FormattedValue.ToString())
                If Not IsDate(hrini) Then
                    grdHorarios.Rows(e.RowIndex).ErrorText = "Introduzca un horario inicial válido."
                e.Cancel = True
                DatosEditados = False
                Return
                Else
                    grdHorarios.Rows(e.RowIndex).ErrorText = String.Empty
                    e.Cancel = False
                End If
                'Verificamos la hora de inicio sea menor a la hora fin
                hrfin = Convert.ToString(grdHorarios.Rows(e.RowIndex).Cells(2).Value)
            If CDate(hrfin) < CDate(hrini) And CDate(hrfin) <> CDate("00:00") Then '------RACB 12/03/2021
                grdHorarios.Rows(e.RowIndex).ErrorText = "La Hora de Inicio debe ser menor o igual a la Hora de Fin." '------RACB 12/03/2021
                e.Cancel = True
                DatosEditados = False
                Return
            Else
                grdHorarios.Rows(e.RowIndex).ErrorText = String.Empty
                    e.Cancel = False
                End If
            End If


            'Si acaba de editar la columna HRFin, hora final veremos sea una hora válida
            If (headerText.Equals("HRFin")) Then
                DatosEditados = True
                hrfin = Convert.ToString(e.FormattedValue.ToString())
                If Not IsDate(hrfin) Then
                    grdHorarios.Rows(e.RowIndex).ErrorText = "Introduzca un horario final válido."
                e.Cancel = True
                DatosEditados = False
                Return
                Else
                    grdHorarios.Rows(e.RowIndex).ErrorText = String.Empty
                    e.Cancel = False
                End If
                'Verificamos la hora fin sea mayor a la hora de inicio
                hrini = Convert.ToString(grdHorarios.Rows(e.RowIndex).Cells(1).Value)
            If CDate(hrfin) < CDate(hrini) Then '------RACB 12/03/2021
                grdHorarios.Rows(e.RowIndex).ErrorText = "La Hora de Fin debe ser mayor o igual a la Hora de Inicio." '------RACB 12/03/2021
                e.Cancel = True
                DatosEditados = False
                Return
            Else
                grdHorarios.Rows(e.RowIndex).ErrorText = String.Empty
                    e.Cancel = False
                End If
                hrpwd = Convert.ToString(grdHorarios.Rows(e.RowIndex).Cells(3).Value)
            'MsgBox("Hora ini " + hrini + " hora fin " + hrfin + " hrpwd " + hrpwd)
            If CDate(hrpwd) < CDate(hrfin) And CDate(hrpwd) <> CDate("00:00") Then '------RACB 12/03/2021
                grdHorarios.Rows(e.RowIndex).ErrorText = "La Hora de Fin debe ser menor o igual  la Hora de Password." '------RACB 12/03/2021
                e.Cancel = True
                DatosEditados = False
                Return
            Else
                grdHorarios.Rows(e.RowIndex).ErrorText = String.Empty
                    e.Cancel = False
                End If

            End If


            'Si acaba de editar la columna HRPwd, hora pwd veremos sea una hora válida
            If (headerText.Equals("HRPwd")) Then
                DatosEditados = True
                hrpwd = Convert.ToString(e.FormattedValue.ToString())
                If Not IsDate(hrpwd) Then
                    grdHorarios.Rows(e.RowIndex).ErrorText = "Introduzca un horario password válido."
                e.Cancel = True
                DatosEditados = False
                Return
                Else
                    grdHorarios.Rows(e.RowIndex).ErrorText = String.Empty
                    e.Cancel = False
                End If
                'Verificamos la hora pass sea mayor a la hora fin
                hrfin = Convert.ToString(grdHorarios.Rows(e.RowIndex).Cells(2).Value)
            If CDate(hrpwd) < CDate(hrfin) Then '------RACB 12/03/2021
                grdHorarios.Rows(e.RowIndex).ErrorText = "La Hora de Password debe ser mayor o igual a la Hora Fin." '------RACB 12/03/2021
                e.Cancel = True
                DatosEditados = False
                Return
            Else
                grdHorarios.Rows(e.RowIndex).ErrorText = String.Empty
                    e.Cancel = False
                End If
            End If
        'End If
    End Sub

    Private Sub grdHorarios_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles grdHorarios.CellEndEdit
        DatosEditados = True
    End Sub

    'Private Sub grdHorarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdHorarios.CellClick
    '    If DatosEditados Then
    '        ValidaHr()

    '    End If
    'End Sub


End Class