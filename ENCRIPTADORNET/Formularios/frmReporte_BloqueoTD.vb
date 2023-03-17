Public Class frmReporte_BloqueoTD

    Dim msFechaIni As String
    Dim msFechaFin As String
    Dim mnUsuario As Integer
    Dim mnTipoRep As Byte

    Private objLibreria As New Libreria
    Private objDatasource As New Datasource
    Private Sub frmReporte_BloqueoTD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Call CargarColores(Me, cambio)
        'Call Centerform(Me)

        'lblStatus.ForeColor = &HFFFF&
        'lblStatus.Appearance = 1
        'lblStatus.BackColor = vbYellow
        'lblStatus.FontBold = True
        'ShowWaitCursor

        If True Then 'If objLibreria.Permiso("PREPOPETODOS") Then
            fraUsuario.Enabled = True
            'optTodos.Value = False
            optTodos.Checked = False
            optTodos.Visible = True
            gs_Sql = "Select usuario, "
            gs_Sql = gs_Sql & "nombre_usuario "
            gs_Sql = gs_Sql & "From "
            'gs_Sql = gs_Sql & dbcatalogos & ".." & gsUSUARIO & " "
            gs_Sql = gs_Sql & "CATALOGOS..USUARIO "
            gs_Sql = gs_Sql & "Where password <> 'ANULADO' "
            gs_Sql = gs_Sql & "order by nombre_usuario"
            LlenaLista(cmbNombre, gs_Sql)
            cmbNombre.SelectedIndex = -1
        Else
            fraUsuario.Enabled = False
            'optTodos.Value = False
            optTodos.Checked = False
            optTodos.Visible = False
            gs_Sql = "Select usuario, "
            gs_Sql = gs_Sql & "nombre_usuario "
            gs_Sql = gs_Sql & "From "
            'gs_Sql = gs_Sql & dbcatalogos & ".." & gsUSUARIO & " "
            gs_Sql = gs_Sql & "CATALOGOS..USUARIO "
            'gs_Sql = gs_Sql & "Where usuario = " & gn_Usuario
            gs_Sql = gs_Sql & "Where usuario = " & usuario
            gs_Sql = gs_Sql & " and password <> 'ANULADO'"
            LlenaLista(cmbNombre, gs_Sql)
            If cmbNombre.Items.Count > 0 Then cmbNombre.SelectedIndex = -1
            optTodos.Checked = True
        End If

        'ShowDefaultCursor
        'txtFechaIni.Text = InvierteFecha(gs_FechaHoy)
        'txtFechaFin.Text = InvierteFecha(gs_FechaHoy)
        txtFechaIni.Text = CDate(gs_FechaHoy).ToString("yyyy-MM-dd")
        txtFechaFin.Text = CDate(gs_FechaHoy).ToString("yyyy-MM-dd")

        'optTodos.Value = 1
        'optFecha.Value = 1

        pbStatus.Maximum = 5
        pbStatus.Value = 0
    End Sub

    '-----------------------------------------------------------
    'Llena un ListBox o un ComboBox con el resultado de un Query
    '-----------------------------------------------------------
    Public Sub LlenaLista(Objeto As Control, Query As String)
        Dim d As New Datasource
        Dim dtListaUsuario As DataTable
        Dim sSql As String

        'Llena combo Tipo de Cliente
        dtListaUsuario = d.RealizaConsulta(Query)

        cmbNombre.Visible = True
        cmbNombre.DisplayMember = "nombre_usuario"
        cmbNombre.ValueMember = "usuario"
        cmbNombre.DataSource = dtListaUsuario
    End Sub

    Private Sub optTodos_CheckedChanged(sender As Object, e As EventArgs) Handles optTodos.CheckedChanged
        If optTodos.Checked = True Then
            cmbNombre.SelectedIndex = -1
            cmbNombre.Enabled = False
        Else
            cmbNombre.Enabled = True
        End If
    End Sub

    Private Sub optFecha_CheckedChanged(sender As Object, e As EventArgs) Handles optFecha.CheckedChanged
        If optFecha.Checked = True Then
            txtFechaIni.Enabled = False
            txtFechaFin.Enabled = False
        Else
            txtFechaIni.Enabled = True
            txtFechaFin.Enabled = True
        End If
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir de Bloqueos TD's") <> vbYes Then Exit Sub
        Me.Close()
    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        pbStatus.Value = 0
        Dim dtRespConsulta As DataTable
        Dim iRegistrosAfectados As Integer
        Dim rptDoc As New ReportDocument
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""
        Dim lsAmbiente As String = ""

        On Error GoTo errImprimir

        Dim lngTotRegs As Long

        If Not DatosCorrectos() Then Exit Sub

        'ShowWaitCursor

        lblStatus.Text = "Generando tabla de datos..."
        lblStatus.Refresh()

        'msFechaIni = InvierteFecha(txtFechaIni.Text)
        'msFechaFin = InvierteFecha(txtFechaFin.Text)
        msFechaIni = CDate(txtFechaIni.Text).ToString("yyyy-MM-dd")
        msFechaFin = CDate(txtFechaFin.Text).ToString("yyyy-MM-dd")

        pbStatus.Value = 1

        'dbExecQuery "Delete TMP_TDS_BLOQUEADOS "
        'dbEndQuery
        objDatasource.insertar("Delete TMP_TDS_BLOQUEADOS ")

        gs_Sql = "Insert Into TMP_TDS_BLOQUEADOS "
        gs_Sql = gs_Sql & "select C.operacion, "
        gs_Sql = gs_Sql & "       C.fecha_operacion fecha_inicio, "
        gs_Sql = gs_Sql & "       B.fecha_vencimiento, "
        gs_Sql = gs_Sql & "       B.cuenta_cliente, "
        'gs_Sql = gs_Sql & "       ltrim(rtrim(D.nombre_cliente)) + ' ' + ltrim(rtrim(D.apellido_paterno)) + ' ' + ltrim(rtrim(D.apellido_materno)) nombre_cliente, "
        gs_Sql = gs_Sql & "       COALESCE(ltrim(rtrim(D.nombre_cliente)), '') + ' ' + COALESCE(ltrim(rtrim(D.apellido_paterno)), '') + ' ' + COALESCE(ltrim(rtrim(D.apellido_materno)), ''), " '---- RACB 01/07/2021
        gs_Sql = gs_Sql & "       B.producto_contratado, "
        gs_Sql = gs_Sql & "       C.monto_operacion, "
        gs_Sql = gs_Sql & "       A.fecha_evento fecha_bloqueo, "
        gs_Sql = gs_Sql & "       A.comentario_evento motivo_bloqueo, "
        gs_Sql = gs_Sql & "       C.status_operacion, "
        gs_Sql = gs_Sql & "       B.status_producto, "
        gs_Sql = gs_Sql & "       A.status_producto status_bloqueo, "
        gs_Sql = gs_Sql & "       A.usuario, "
        gs_Sql = gs_Sql & "       E.nombre_usuario, "
        gs_Sql = gs_Sql & "       usuario_evalua = CASE ISNULL(F.usuario_evalua,0)  "
        gs_Sql = gs_Sql & "                        WHEN 0 THEN A.usuario "
        gs_Sql = gs_Sql & "                        ELSE F.usuario_evalua "
        gs_Sql = gs_Sql & "                        END, "
        gs_Sql = gs_Sql & "       nombre_usuario_evalua = CASE ISNULL(G.nombre_usuario,'') "
        gs_Sql = gs_Sql & "                        WHEN '' THEN E.nombre_usuario "
        gs_Sql = gs_Sql & "                        ELSE G.nombre_usuario "
        gs_Sql = gs_Sql & "                        END "
        gs_Sql = gs_Sql & "  From TICKET..EVENTO_PRODUCTO A, "
        gs_Sql = gs_Sql & "       TICKET..PRODUCTO_CONTRATADO B, "
        gs_Sql = gs_Sql & "       TICKET..OPERACION C, "
        gs_Sql = gs_Sql & "       CATALOGOS..CLIENTE D, "
        gs_Sql = gs_Sql & "       CATALOGOS..USUARIO E, "
        gs_Sql = gs_Sql & "       CATALOGOS..PERMISOS_REMOTOS F, "
        gs_Sql = gs_Sql & "       CATALOGOS..USUARIO G "
        gs_Sql = gs_Sql & " Where A.status_producto = 8003 "

        If optFecha.Checked = False Then
            gs_Sql = gs_Sql & " and A.fecha_evento >= '" & msFechaIni & " 12:00AM' "
            gs_Sql = gs_Sql & " and A.fecha_evento <= '" & msFechaFin & " 11:59PM' "
        End If

        If cmbNombre.SelectedIndex > -1 Then
            gs_Sql = gs_Sql & " and A.usuario = " & mnUsuario & " "
        End If

        gs_Sql = gs_Sql & "   and B.producto_contratado = A.producto_contratado "
        gs_Sql = gs_Sql & "   and B.status_producto = 8043 "
        gs_Sql = gs_Sql & "   and C.operacion = convert(int,B.clave_producto_contratado) "
        gs_Sql = gs_Sql & "   and C.status_operacion <> 250 "
        gs_Sql = gs_Sql & "   and D.cuenta_cliente = B.cuenta_cliente "
        gs_Sql = gs_Sql & "   and E.usuario = A.usuario "
        gs_Sql = gs_Sql & "   and F.cuenta_cliente = D.cuenta_cliente "
        gs_Sql = gs_Sql & "   and F.operacion_definida = C.operacion_definida "
        gs_Sql = gs_Sql & "   and F.usuario = A.usuario "
        gs_Sql = gs_Sql & "   and G.usuario = F.usuario_evalua " '----> RACB 21/12/2021
        gs_Sql = gs_Sql & " order by B.fecha_vencimiento "

        'dbExecQuery gs_Sql
        iRegistrosAfectados = objDatasource.insertar(gs_Sql)

        pbStatus.Value = 2

        'If dbError <> 0 Then
        If iRegistrosAfectados < 0 Then
            'ShowDefaultCursor
            MsgBox("No es posible generar el reporte. Error al actualizar la tabla Temporal.", vbCritical, "SQL Server Error")
            'dbEndQuery
            Exit Sub
        End If
        'dbEndQuery

        'dbExecQuery("Select Count(*) From TMP_TDS_BLOQUEADOS ")
        'dbGetRecord
        'lngTotRegs = Val(dbGetValue(0))
        dtRespConsulta = objDatasource.RealizaConsulta("Select Count(*) From TMP_TDS_BLOQUEADOS ")
        lngTotRegs = Val(dtRespConsulta.Rows(0).Item(0))
        'dbEndQuery

        pbStatus.Value = 3

        If lngTotRegs > 0 Then
            'rptOperaciones.ReportFileName = GPATH & "\TDsBloqueados.rpt"
            'rptOperaciones.WindowTitle = "Reporte de Time Deposits Bloqueados."
            'LimpiaFormulas rptOperaciones
            'rptOperaciones.Formulas(0) = "Hora = '" & HoraSistema & "'"
            'rptOperaciones.Formulas(1) = "Fecha = '" & InvierteFecha(gs_FechaHoy) & "'"
            lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
            lsReporte = lsRutaFolder & "TDsBloqueados" & lsAmbiente & ".rpt"
            rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
            objLibreria.logonBDreporte(rptDoc, 1)
            rptDoc.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & gs_FechaHoy & "'"
            rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & gs_HoraSistema & "'"
            If optFecha.Checked = False Then
                'rptOperaciones.Formulas(2) = "Rango_Fecha = 'Del " & msFechaIni & " al " & msFechaFin & "'"
                rptDoc.DataDefinition.FormulaFields.Item("Rango_Fecha").Text = "'Del " & msFechaIni & " al " & msFechaFin & "'"
            Else
                'rptOperaciones.Formulas(2) = "Rango_Fecha = ''"
                rptDoc.DataDefinition.FormulaFields.Item("Rango_Fecha").Text = "''"
            End If

            pbStatus.Value = 4

            'MaximizaReporte rptOperaciones
            opcionReporte = 16
            RepOperativa.reporteOFAC = rptDoc
            RepOperativa.ShowDialog()
        Else
            MsgBox("No existen bloqueos con estos parametros.", vbInformation, "Bloqueos TD's")
        End If

        lblStatus.Text = "Listo..."
        'lblStatus.Width = 5415
        lblStatus.Refresh()
        'ShowDefaultCursor

        pbStatus.Value = 5

        Exit Sub

errImprimir:
        'ShowDefaultCursor
        MsgBox(Err.Number & " " & Err.Description, vbCritical, "Error de Reporte")
        lblStatus.Text = "Listo..."
        'pbStatus.Width = 5415
        lblStatus.Refresh()
        pbStatus.Value = 5
    End Sub
    '**************************************************
    ' Funciones y procedimientos
    '**************************************************

    Private Function DatosCorrectos() As Boolean

        DatosCorrectos = False
        If cmbNombre.SelectedIndex = -1 And optTodos.Checked = False Then
            If optTodos.Visible = True Then
                MsgBox("Debe elegir un Usuario valido o elegir la opción Todos.", vbInformation, "Usuario")
                Exit Function
            Else
                MsgBox("Es necesario indicar el nombre de usuario.", vbInformation, "Usuario")
                Exit Function
            End If
            cmbNombre.Focus()
        End If

        If Trim(txtFechaIni.Text) = "" Then
            MsgBox("En necesario indicar la fecha inicial del periodo.", vbInformation, "Dato Faltante...")
            txtFechaIni.Focus()
            Exit Function
        End If

        If Trim(txtFechaFin.Text) = "" Then
            MsgBox("En necesario indicar la fecha final del periodo.", vbInformation, "Dato Faltante...")
            txtFechaFin.Focus()
            Exit Function
        End If

        If CDate(txtFechaIni.Text) > CDate(txtFechaFin.Text) Then
            MsgBox("La fecha final del periodo debe ser mayor o igual a la fecha inicial.", vbInformation, "Dato Faltante...")
            txtFechaFin.Focus()
            Exit Function
        End If

        DatosCorrectos = True
    End Function

    Private Sub cmbNombre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNombre.SelectedIndexChanged
        If cmbNombre.SelectedIndex > -1 Then
            mnUsuario = cmbNombre.SelectedValue 'cmbNombre.ItemData(cmbNombre.ListIndex)
        End If
    End Sub
End Class