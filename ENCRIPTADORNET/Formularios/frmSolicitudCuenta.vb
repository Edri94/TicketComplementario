Imports System.IO
Imports System.Threading
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports Microsoft.Office.Interop

Public Class frmSolicitudCuenta

    Dim l As New Libreria

    Dim iRegistros As Integer = 0

    Dim mnUsuario As Integer
    Dim msFechaIni As String
    Dim msFechaFin As String


    Private consu As Object
    Private sqlstring As String
    Private strnameFile As String
    Private strFile As String
    Private objDataSouce As Datasource
    Private sRutaTemporal, sNomArchivo As String
    Private objLibreria As New Libreria

    Private Sub frmSolicitudCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()
        cargaListaBanca()
        cargaListaAsesor()
        cargaListaStatus()
        cboAsesores.Text = ""
        CboBanca.Text = ""
        CboStatus.Text = ""
        TxtFecha.Enabled = False
        TxtFecha1.Enabled = False
        Me.Size = New Size(875, 555)
    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir de Consulta de Solicitudes") <> vbYes Then
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub
    Private Sub chkFechas_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechas.CheckedChanged
        If chkFechas.Checked = False Then
            TxtFecha.Text = DateTime.Now
            TxtFecha1.Text = DateTime.Now
            TxtFecha.Enabled = False
            TxtFecha1.Enabled = False
        Else
            TxtFecha.Enabled = True
            TxtFecha1.Enabled = True
        End If
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Me.Panel1.Visible = True
        Dim fechaGenerado As String = DateTime.Now.ToString("yyyy-MM-dd").Substring(0, 10)
        Dim excel = "\GOMAC"
        Dim StrPath As String = ""
        Dim MisDocumentos As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        StrPath = MisDocumentos & excel
        Dim columnas As Integer = Me.dgvFiltro.Columns.Count
        Dim filas As Integer = Me.dgvFiltro.Rows.Count
        Dim total As Integer = columnas * filas
        If filas > 0 Then
            Me.ProgressBar1.Value = 20
            If filas > 1000 Then
                MessageBox.Show("Detectamos mas de 1000 registros, este proceso puede demorar unos segundos...")
            End If
            Dim exApp As New Microsoft.Office.Interop.Excel.Application
            Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
            Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

            Try
                Me.ProgressBar1.Value = 30
                lblStatus.Text = "Cargando..."
                exLibro = exApp.Workbooks.Add() 'Crea el libro de excel
                exHoja = exLibro.Worksheets.Add()
                Me.ProgressBar1.Value = 50
                For i As Integer = 1 To columnas
                    exHoja.Cells.Item(1, i) = dgvFiltro.Columns(i - 1).Name.ToString
                Next
                Me.ProgressBar1.Value = 70
                For Fila As Integer = 0 To filas - 1
                    For Col As Integer = 0 To columnas - 1
                        exHoja.Cells.Item(Fila + 2, Col + 1) = dgvFiltro.Rows(Fila).Cells(Col).Value
                        If Fila = 70 Then
                            Console.WriteLine()
                        End If
                    Next
                Next
                Me.ProgressBar1.Value = 80
                exHoja.Rows.Item(1).Font.Bold = 1
                exHoja.Rows.Item(1).Font.Color = RGB(255, 255, 255)
                exHoja.Rows.Item(1).Interior.Color = RGB(48, 84, 150)
                exHoja.Rows.Item(filas + 1).Interior.Color = RGB(255, 255, 153)
                exHoja.Rows.Item(1).HorizontalAlignment = 3
                exHoja.Columns.AutoFit()
                exHoja.Columns.HorizontalAlignment = 2
                Me.ProgressBar1.Value = 100
                MsgBox("El reporte se ha creado correctamente", MsgBoxStyle.OkOnly, "Creado correctamente")
                exApp.Application.Visible = True
                exHoja = Nothing
                exLibro = Nothing
                exApp = Nothing
                lblStatus.Text = "Listo..."
                Me.Panel1.Visible = False
                Me.ProgressBar1.Value = 10
                lblStatus.Refresh()

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear el reporte")
                Me.Panel1.Visible = False
                Me.ProgressBar1.Value = 10
            End Try
        Else

            MessageBox.Show("No se puede generar un archivo excel sin registros, revice los filtros")
            lblStatus.Text = "Listo..."

            Me.Panel1.Visible = False
            Me.ProgressBar1.Value = 10
        End If



    End Sub

    Private Function ValidaRuta(ruta As String) As Boolean

        Try
            If Not Directory.Exists(ruta) Then
                Directory.CreateDirectory(ruta)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub cmdBuscar_Click(sender As Object, e As EventArgs) Handles cmdBuscar.Click

        Cursor = System.Windows.Forms.Cursors.WaitCursor
        lblStatus.Text = "Buscando solicitudes..."
        Me.CargarDatos()
        Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub CargarDatos()

        Dim d As New Datasource
        Dim dt As DataTable
        Dim Asesor As String = sp(cboAsesores.Text, "-", 0)
        Dim Cuenta As String = Me.TxtCCuenta.Text
        Dim Nombre As String = Me.txtNombreCliente.Text
        Dim ApellidoP As String = Me.TxtApPat.Text
        Dim ApellidoM As String = Me.TxtCApellidoMat.Text
        Dim Banca As String = CboBanca.Text
        Dim Status As String = sp(CboStatus.Text, "-", 0)
        Dim FechaInicio As String = FechaSQL(IIf(TxtFecha.Enabled, TxtFecha.Text, ""), 0)
        Dim FechaFin As String = FechaSQL(IIf(TxtFecha.Enabled, TxtFecha1.Text, ""), 1)
        Try

            dt = d.EjecutaSP("[SP_GM_Obtener_ReporteGOMAC] 
            '" + Asesor + "','" + Cuenta + "','" + Nombre + "','" + ApellidoP + "','" + ApellidoM + "','" + Banca + "','" + Status + "','" + FechaInicio + "','" + FechaFin + "'")

            If dt.Rows.Count > 0 Then

                dgvFiltro.DataSource = dt
                dgvFiltro.Columns(dt.Columns.Count - 1).Width = 1550
                lblStatus.Text = CStr(dt.Rows.Count) & " solicitudes en la lista..."
                Cursor = System.Windows.Forms.Cursors.Default
                cmdAceptar.Enabled = True
            Else
                MessageBox.Show("No se encontraron registros")
                lblStatus.Text = "Sin datos"
                dgvFiltro.DataSource = Nothing
                dgvFiltro.Refresh()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            lblStatus.Text = "Listo..."
        Finally
            d = Nothing
            GC.Collect()
        End Try

    End Sub

    Private Function FechaSQL(text As String, tipo As Integer) As String
        Dim cadenaFecha As String = ""
        'tipo 0 = fecha inicio, tipo = 1 fecha fin
        'Entrada de fecha 01-12-2022  dd/mm/yyyy
        Dim separador As String
        Dim le As Integer
        If tipo = 0 Then
            If text <> "" Then
                separador = IIf(text.Contains("-"), "-", "/")
                le = Len(sp(text, separador, 2))
                If (le = 4) Then
                    cadenaFecha = sp(text, separador, 2) + "-" + sp(text, separador, 1) + "-" + sp(text, separador, 0)
                Else
                    cadenaFecha = sp(text, separador, 0) + "-" + sp(text, separador, 1) + "-" + sp(text, separador, 2)
                End If

            Else
                cadenaFecha = "1900-01-01"
            End If
        Else
            If text <> "" Then
                separador = IIf(text.Contains("-"), "-", "/")
                le = Len(sp(text, separador, 2))
                If (le = 4) Then
                    cadenaFecha = sp(text, separador, 2) + "-" + sp(text, separador, 1) + "-" + sp(text, separador, 0)
                Else
                    cadenaFecha = sp(text, separador, 0) + "-" + sp(text, separador, 1) + "-" + sp(text, separador, 2)
                End If

            Else
                cadenaFecha = "3000-01-01"
            End If
        End If

        'Salida de fecha 2022-12-01  yyy/mm/dd
        Return cadenaFecha
    End Function

    Private Sub LimpiarPantalla()
        chkFechas.Checked = False
        TxtFecha.Text = DateTime.Now
        TxtFecha1.Text = DateTime.Now
        TxtFecha.Enabled = False
        TxtFecha1.Enabled = False
        cboAsesores.Text = ""
        CboBanca.Text = ""
        CboStatus.Text = ""
        txtNombreCliente.Text = ""
        TxtApPat.Text = ""
        TxtCApellidoMat.Text = ""
        TxtCCuenta.Text = ""
        dgvFiltro.DataSource = Nothing
        dgvFiltro.Refresh()
    End Sub

#Region "Funciones"
    Public Function sp(cadena As String, simbolo As String, item As Integer)
        Dim separar() As String
        separar = Split(cadena, simbolo)
        Return separar(item)
    End Function
    Private Function DatosCompletos() As Boolean

        DatosCompletos = False


        If Trim(cboAsesores.Text) = "" And Trim(TxtCCuenta.Text) = "" And Trim(CboBanca.Text) = "." And chkFechas.Checked = 0 Then
            ''If CboBanca.Text = "Selecciona una opción" Then
            MsgBox("Es necesario seleccionar la banca, un asesor o la fecha.", vbCritical, "Error de Consulta")
            CboBanca.Select()
            cboAsesores.Select()
            CboStatus.Select()
            Exit Function
        End If

        If chkFechas.Checked = True Then
            If CDate(TxtFecha.Text) > CDate(TxtFecha1.Text) Then
                MsgBox("La fecha inicial del periodo debe ser menor o igual a la fecha final.", vbInformation, "Fecha Invalida")
                TxtFecha.Text = DateTime.Now
                TxtFecha1.Text = DateTime.Now
                Exit Function
            End If
        End If

        DatosCompletos = True

    End Function

    Function cargaListaAsesor() As Boolean
        Dim d As New Datasource
        Dim dtListaAsesor As DataTable
        Dim sSql As String

        cboAsesores.Items.Clear()

        cargaListaAsesor = False

        sSql = "select rtrim(Id_ConsultorMac) + '-' + rtrim(NOM_CONSULTORMAC) + ' ' + rtrim(AP_CONSULTORMAC) + ' ' + rtrim(AM_CONSULTORMAC) asesor"
        sSql &= " from bmtktp01..CONSULTORES"

        dtListaAsesor = d.RealizaConsulta(sSql)

        cboAsesores.Visible = True
        cboAsesores.DisplayMember = "asesor"
        cboAsesores.ValueMember = "Id_ConsultorMac"
        cboAsesores.DataSource = dtListaAsesor

        'cargaListaAsesor = True
    End Function

    Function cargaListaBanca() As Boolean
        Dim d As New Datasource
        Dim dtListaBanca As DataTable

        Dim sSql As String


        cargaListaBanca = False

        sSql = "Select * "
        sSql &= " from bmtktp01..ver_banca "
        sSql &= "order by 1"
        ''CboBanca.Items.Insert(0, "Selecciona una opción")

        dtListaBanca = d.RealizaConsulta(sSql)

        CboBanca.Visible = True
        CboBanca.DisplayMember = "Banca"
        CboBanca.DataSource = dtListaBanca

        cargaListaBanca = True
    End Function

    Private Sub btnLimpiarFiltro_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltro.Click
        Me.LimpiarPantalla()
    End Sub

    Private Sub TxtCCuenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCCuenta.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Function cargaListaStatus() As Boolean
        Dim d As New Datasource
        Dim dtListaStatus As DataTable
        Dim sSql As String

        cargaListaStatus = False

        sSql = "Select rtrim(Id_Status) + '-' + rtrim(Descripcion_Status) as 'Descripcion_Status', Id_Status from bmtktp01..TIPO_STATUS"


        'Llena combo Tipo de Cliente
        dtListaStatus = d.RealizaConsulta(sSql)

        CboStatus.Visible = True
        CboStatus.DisplayMember = "Descripcion_Status"
        CboStatus.ValueMember = "Id_Status"
        CboStatus.DataSource = dtListaStatus


        cargaListaStatus = True
    End Function


#End Region

End Class