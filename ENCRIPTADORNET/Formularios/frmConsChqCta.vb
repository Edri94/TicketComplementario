Public Class frmConsChqCta

    Public bindingSource1 As BindingSource

    Dim l As New Libreria

    Private Sub cmdBuscar_Click(sender As Object, e As EventArgs) Handles cmdBuscar.Click

        Dim d As New Datasource
        Dim dt As New DataTable
        Dim iCol As Integer = 0

        If Not DatosCompletos() Then Exit Sub

        Cursor = System.Windows.Forms.Cursors.WaitCursor 'Screen.MousePointer = vbHourglass
        lblStatus.Text = "Buscando solicitudes..."
        gs_Sql = "Select "
        gs_Sql = gs_Sql & "convert(char(10),CH.fecha_solicitud,105), "
        gs_Sql = gs_Sql & "CH.num_func_envio, "
        gs_Sql = gs_Sql & "CH.cr_envio, "
        gs_Sql = gs_Sql & "substring(CH.sucursal_envio,1,3), "
        gs_Sql = gs_Sql & "substring(CH.sucursal_envio,4,4), "
        gs_Sql = gs_Sql & "CH.cta_eje_envio, "
        gs_Sql = gs_Sql & "CH.num_func_solicita, "
        gs_Sql = gs_Sql & "CH.cr_solicita, "                      '"SS.centro_regional, "
        gs_Sql = gs_Sql & "substring(CH.sucursal_solicita,1,3), "
        gs_Sql = gs_Sql & "substring(CH.sucursal_solicita,4,4), "
        gs_Sql = gs_Sql & "CH.total_cheques, "
        gs_Sql = gs_Sql & "case CH.tipo_chequera when 1 then 'Especial' else 'Normal' end, "
        gs_Sql = gs_Sql & "CH.chequera, "
        gs_Sql = gs_Sql & "CH.ultimo_cheque, "
        gs_Sql = gs_Sql & "CH.orden, "
        gs_Sql = gs_Sql & "ST.descripcion_status "
        gs_Sql = gs_Sql & "From "
        gs_Sql = gs_Sql & "CATALOGOS.dbo.CLIENTE CL, "
        gs_Sql = gs_Sql & "CATALOGOS.dbo.AGENCIA AG, "
        gs_Sql = gs_Sql & "CATALOGOS.dbo.SUCURSAL SS, "
        gs_Sql = gs_Sql & "CHEQUERAS CH, "
        gs_Sql = gs_Sql & "CUENTA_EJE CE, "
        gs_Sql = gs_Sql & "STATUS_CHEQUERA ST, "
        gs_Sql = gs_Sql & "TIPO_CUENTA_EJE TC, "
        gs_Sql = gs_Sql & "PRODUCTO_CONTRATADO PC "
        gs_Sql = gs_Sql & "Where "
        gs_Sql = gs_Sql & "CL.agencia = PC.agencia and "
        gs_Sql = gs_Sql & "CL.cuenta_cliente = PC.cuenta_cliente and "
        gs_Sql = gs_Sql & "CE.producto_contratado = PC.producto_contratado and "
        gs_Sql = gs_Sql & "PC.producto_contratado = CH.producto_contratado and "
        gs_Sql = gs_Sql & "ST.status_chequera = CH.status_chequera and "
        gs_Sql = gs_Sql & "SS.sucursal =* CH.sucursal_solicita and "
        gs_Sql = gs_Sql & "TC.tipo_cuenta_eje = CE.tipo_cuenta_eje and "
        gs_Sql = gs_Sql & "AG.agencia = PC.agencia and "
        gs_Sql = gs_Sql & "PC.agencia = " & cmbAgencias.SelectedValue.ToString
        If chkStatus.Checked = True Then
            gs_Sql = gs_Sql & " and CH.status_chequera = " & cmbStatus.SelectedValue.ToString 'ItemData(cmbStatus.ListIndex)
        End If
        'End If
        If chkCuentas.Checked = True Then
            gs_Sql = gs_Sql & " and PC.cuenta_cliente >= '" & Trim(txtCuentaIni.Text) & "'"
            gs_Sql = gs_Sql & " and PC.cuenta_cliente <= '" & Trim(txtCuentaFin.Text) & "'"
        End If
        If chkFechas.Checked = True Then
            gs_Sql = gs_Sql & " and CH.fecha_solicitud > '" & l.InvierteFecha(txtFechaIni.Text) & "'"
            gs_Sql = gs_Sql & " and CH.fecha_solicitud < '" & l.InvierteFecha(DateAdd("d", 1, txtFechaFin.Text)) & "'"
        End If
        gs_Sql = gs_Sql & " Order by CH.fecha_solicitud"
        dt = d.RealizaConsulta(gs_Sql)
        If dt.Rows.Count > 0 Then

            dgvDatos.DataSource = dt
            'If lstDatos.ListItems.Count > 0 Then
            'cmdImprimir.Enabled = True
            lblStatus.Text = CStr(dt.Rows.Count) & " solicitudes en la lista..."

            Me.dgvDatos.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
            dgvDatos.AutoSizeRowsMode =
                                    DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            dgvDatos.Columns(0).HeaderText = "Fecha de solicitud"
            dgvDatos.Columns(1).HeaderText = "Número de envío" 'CH.num_func_envio, "
            dgvDatos.Columns(2).HeaderText = "CR de Envío" 'CH.cr_envio, "
            dgvDatos.Columns(3).HeaderText = "Plaza de Envío" 'substring(CH.sucursal_envio,1,3), "
            dgvDatos.Columns(4).HeaderText = "Sucursal de Envío" 'substring(CH.sucursal_envio,4,4), "
            dgvDatos.Columns(5).HeaderText = "Cuenta Eje de Envío" 'CH.cta_eje_envio, "
            dgvDatos.Columns(6).HeaderText = "Número de Solicitud" 'CH.num_func_solicita, "
            dgvDatos.Columns(7).HeaderText = "CR Solicitante" 'CH.cr_solicita, "                      
            dgvDatos.Columns(8).HeaderText = "Plaza Solicitante" 'substring(CH.sucursal_solicita,1,3), "
            dgvDatos.Columns(9).HeaderText = "Sucursal Solicitante" 'substring(CH.sucursal_solicita,4,4), "
            dgvDatos.Columns(10).HeaderText = "Total de cheques" 'CH.total_cheques, "
            dgvDatos.Columns(11).HeaderText = "Tipo de chequera" 'case CH.tipo_chequera when 1 then 'Especial' else 'Normal' end, "
            dgvDatos.Columns(12).HeaderText = "Chequera" 'CH.chequera, "
            dgvDatos.Columns(13).HeaderText = "Último cheque" 'CH.ultimo_cheque, "
            dgvDatos.Columns(14).HeaderText = "Orden" 'CH.orden, "
            dgvDatos.Columns(15).HeaderText = "Status" 'ST.descripcion_status "

            dgvDatos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            For i = 0 To 15 Step 1
                dgvDatos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

        Else
            dgvDatos.DataSource = dt
            lblStatus.Text = "Sin solicitudes en la lista..."
            'cmdImprimir.Enabled = True
        End If
        Cursor = System.Windows.Forms.Cursors.Default
        cmdImprimir.Enabled = True '------------------ RACB 24-05-2021

    End Sub

    Private Sub frmConsChqCta_Load(sender As Object, e As EventArgs) Handles Me.Load
        monthCalendar.SelectionRange = New SelectionRange(DateTime.Today, DateTime.Today)
    End Sub

    '-------------------------------------------------
    'Verifica que los datos opcionales esten completos
    '-------------------------------------------------

    Private Function DatosCompletos() As Boolean

        DatosCompletos = False
        If cmbAgencias.SelectedIndex = -1 Then '    lstAgencias.ListIndex = -1 Then
            MsgBox("Es necesario seleccionar la agencia de origen de las cuentas.", vbInformation, "Datos Faltantes")
            cmbAgencias.Select()  'SelectedIndex  
            Exit Function
        End If
        If chkStatus.Checked = True Then
            If cmbStatus.SelectedIndex = -1 Then
                MsgBox("Es necesario seleccionar el status por buscar.", vbInformation, "Datos Faltantes")
                cmbStatus.Select()
                Exit Function
            End If
        End If
        If chkCuentas.Checked = True Then
            If Trim(txtCuentaIni.Text) = "" Then
                MsgBox("Es necesario indicar el numero de cuenta inicial del rango.", vbInformation, "Datos Faltantes")
                txtCuentaIni.Select()
                Exit Function
            End If
            If Trim(txtCuentaFin.Text) = "" Then
                MsgBox("Es necesario indicar el numero de cuenta final del rango.", vbInformation, "Datos Faltantes")
                txtCuentaFin.Select()
                Exit Function
            End If
            If Val(txtCuentaFin.Text) < Val(txtCuentaIni.Text) Then
                MsgBox("La cuenta inicial debe ser menor o igual que la cuenta final.", vbInformation, "Datos Incorrectos")
                txtCuentaIni.Select()
                Exit Function
            End If
        End If
        If chkFechas.Checked = True Then

            If Trim(txtFechaIni.Text) = "/  /" Then
                MsgBox("Es necesario indicar la fecha inicial del rango.", vbInformation, "Datos Faltantes")
                txtFechaIni.Select()
                Exit Function
            End If
            If Trim(txtFechaFin.Text) = "/  /" Then
                MsgBox("Es necesario indicar la fecha final del rango.", vbInformation, "Datos Faltantes")
                txtFechaFin.Select()
                Exit Function
            End If
            If CDate(txtFechaFin.Text) < CDate(txtFechaIni.Text) Then
                MsgBox("La fecha inicial debe ser menor o igual que la fecha final.", vbInformation, "Datos Incorrectos")
                txtFechaIni.Select()
                Exit Function
            End If
        End If
        DatosCompletos = True
    End Function

    Private Sub btnSelecFechas_Click(sender As Object, e As EventArgs)
        Dim fechaInicio, fechaFin As DateTime
        fechaInicio = monthCalendar.SelectionStart
        fechaFin = monthCalendar.SelectionEnd

        txtFechaIni.Text = fechaInicio.ToString()
        txtFechaFin.Text = fechaFin.ToString()


    End Sub

    Private Sub monthCalendar_Click(sender As Object, e As EventArgs) Handles monthCalendar.Click

    End Sub

    Private Sub monthCalendar_DateChanged(sender As Object, e As DateRangeEventArgs) Handles monthCalendar.DateChanged
        txtFechaIni.Text = e.Start.ToShortDateString()
        txtFechaFin.Text = e.End.ToShortDateString()
    End Sub



    Public Sub Tipo(Reporte As Byte)
        Cursor = System.Windows.Forms.Cursors.WaitCursor 'Screen.MousePointer = vbHourglass
        Me.Width = 690
        Me.Height = 490
        Me.CenterToParent()
        Me.Refresh()
        Me.Show()

        Dim ln_Rows As Integer
        Dim d As New Datasource
        Dim dt As DataTable
        Dim ds As New Datasource
        Dim dts As DataTable

        gs_Sql = "Select distinct descripcion_agencia, AG.agencia "
        gs_Sql = gs_Sql & "From vw_cuentas_chequera CC, "
        gs_Sql = gs_Sql & "CATALOGOS.dbo.AGENCIA AG "
        gs_Sql = gs_Sql & "Where CC.agencia = AG.agencia "
        If gb_FijarAgencia Then gs_Sql = gs_Sql & " And AG.agencia = 1" 'Fijar Agencia Houston
        'MARB - IDS Comercial, 11 Mar 03
        'Permiso de agencias
        'gs_Sql = gs_Sql & " and AG.agencia " & GsPermisoAgencia ---------------- verificar
        gs_Sql = gs_Sql & "order by descripcion_agencia"


        dt = New DataTable
        dt = d.RealizaConsulta(gs_Sql)

        'Me.grdDoc.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)

        If dt.Rows.Count > 0 Then

            cmbAgencias.DataSource = dt
            cmbAgencias.DisplayMember = Trim("descripcion_agencia")
            cmbAgencias.ValueMember = "agencia"

            Select Case Reporte
                Case 1
                    Me.Text = "Consulta de Solicitud de Chequeras por Número de Cuenta"
                    gpoCuenta.Visible = True 'chkCuentas.Visible = True
                    gpoFechas.Visible = False
                    chkStatus.Visible = False
                    cmbStatus.Visible = False

                Case 2
                    Me.Text = "Consulta de Solicitud de Chequeras por Status de Chequera"
                    gs_Sql = "Select descripcion_status, status_chequera "
                    gs_Sql = gs_Sql & "From "
                    gs_Sql = gs_Sql & "STATUS_CHEQUERA "
                    gs_Sql = gs_Sql & "Order by descripcion_status"

                    dts = New DataTable
                    dts = ds.RealizaConsulta(gs_Sql)

                    If dts.Rows.Count > 0 Then
                        cmbStatus.DataSource = dts
                        cmbStatus.DisplayMember = Trim("descripcion_status")
                        cmbStatus.ValueMember = "status_chequera"
                        chkStatus.Visible = True
                        cmbStatus.Visible = True
                    End If

                Case 3
                    Me.Text = "Consulta de Solicitud de Chequeras por Fecha"
                    gpoFechas.Visible = True
                    gpoCuenta.Visible = False
                    chkStatus.Visible = False
                    cmbStatus.Visible = False


            End Select
        End If
        Cursor = System.Windows.Forms.Cursors.Default 'Screen.MousePointer = vbDefault
    End Sub

    Private Sub cmbAgencias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAgencias.SelectedIndexChanged

    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    Private Sub chkFechas_Click(sender As Object, e As EventArgs) Handles chkFechas.Click
        If Not chkFechas.Checked Then
            txtFechaIni.Text = ""
            txtFechaFin.Text = ""
        End If
    End Sub

    Private Sub chkCuentas_Click(sender As Object, e As EventArgs) Handles chkCuentas.Click
        If Not chkCuentas.Checked Then
            txtCuentaIni.Text = ""
            txtCuentaFin.Text = ""
        End If
    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        '--------------------------------- RACB 28-05-2021
        Dim ls_Formula As String = ""
        Dim ls_FechaIni As String
        Dim ls_FechaFin As String

        Dim rptDoc As New ReportDocument
        Dim lsAmbiente As String = ""
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""
        Dim objLibreria As New Libreria

        If chkStatus.Checked = True Then
            ls_Formula = "{CHEQUERAS.status_chequera} = " & cmbStatus.SelectedIndex 'cmbStatus.ItemData(cmbStatus.ListIndex)
            ls_Formula = ls_Formula & " and {PRODUCTO_CONTRATADO.agencia} = " & cmbAgencias.SelectedValue 'lstAgencias.ItemData(lstAgencias.ListIndex)
        Else
            If chkCuentas.Checked = True Then
                If Trim(ls_Formula) <> "" Then ls_Formula = ls_Formula & " and "
                ls_Formula = ls_Formula & " {PRODUCTO_CONTRATADO.cuenta_cliente} >= '" & Trim(txtCuentaIni.Text) & "'"
                ls_Formula = ls_Formula & " and {PRODUCTO_CONTRATADO.cuenta_cliente} <= '" & Trim(txtCuentaFin.Text) & "'"
                ls_Formula = ls_Formula & " and {PRODUCTO_CONTRATADO.agencia} = " & cmbAgencias.SelectedValue 'lstAgencias.ItemData(lstAgencias.ListIndex)
            Else
                If chkFechas.Checked = True Then
                    ls_FechaIni = DateAdd("d", -1, txtFechaIni)
                    ls_FechaFin = DateAdd("d", 1, txtFechaFin)
                    If Trim(ls_Formula) <> "" Then ls_Formula = ls_Formula & " and "
                    ls_Formula = ls_Formula & " {CHEQUERAS.fecha_solicitud} > Date(" & Microsoft.VisualBasic.Right(ls_FechaIni, 4) & ","
                    ls_Formula = ls_Formula & Mid(ls_FechaIni, 4, 2) & ","
                    ls_Formula = ls_Formula & Microsoft.VisualBasic.Left(ls_FechaIni, 2) & ")"
                    ls_Formula = ls_Formula & " and {CHEQUERAS.fecha_solicitud} < Date(" & Microsoft.VisualBasic.Right(ls_FechaFin, 4) & ","
                    ls_Formula = ls_Formula & Mid(ls_FechaFin, 4, 2) & ","
                    ls_Formula = ls_Formula & Microsoft.VisualBasic.Left(ls_FechaFin, 2) & ")"
                    ls_Formula = ls_Formula & " and {PRODUCTO_CONTRATADO.agencia} = " & cmbAgencias.SelectedValue 'lstAgencias.ItemData(lstAgencias.ListIndex)
                Else
                    ls_Formula = "{PRODUCTO_CONTRATADO.agencia} = " & cmbAgencias.SelectedValue 'lstAgencias.ItemData(lstAgencias.ListIndex)
                End If
            End If
        End If

        '
        'Modificación en formula por campo bbva de tipo bit  20090406  Sandra Garcia
        '
        ls_Formula = ls_Formula & " And not {CHEQUERAS.bbvab}"            'Primero obtenemos Bancomer

        'MDIValida.Report.ReportFileName = GPATH & "\CHQ_PorCuenta.Rpt"
        lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
        lsReporte = lsRutaFolder & "CHQ_PORCUENTA" & lsAmbiente & ".RPT"
        rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
        objLibreria.logonBDreporte(rptDoc, 1)
        'MDIValida.Report.Formulas(0) = "Fecha = '" & InvierteFecha(gs_FechaHoy) & "'"
        'MDIValida.Report.Formulas(1) = "Hora = '" & HoraSistema & "'"
        'MDIValida.Report.Formulas(2) = "Origen = 'BANCOMER'"
        rptDoc.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & Now().ToString("dd-MM-yyyy") & "'"
        rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Now().ToString("hh:mm") & "'"
        rptDoc.DataDefinition.FormulaFields.Item("Origen").Text = "'BANCOMER'"
        'MDIValida.Report.SelectionFormula = ls_Formula
        rptDoc.RecordSelectionFormula = ls_Formula

        'Screen.MousePointer = vbHourglass

        'MuestraVentanaReporte MDIValida.Report
        opcionReporte = 16
        RepOperativa.reporteOFAC = rptDoc
        RepOperativa.ShowDialog()

        '
        'Obtenemos BBVA
        '

        '
        'Modificación en formula por campo bbva de tipo bit  20090406  Sandra Garcia
        '

        ls_Formula = Microsoft.VisualBasic.Left$(ls_Formula, Len(ls_Formula) - 21) & "{CHEQUERAS.bbvab}"

        'MDIValida.Report.ReportFileName = GPATH & "\CHQ_PorCuenta.Rpt"
        lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
        lsReporte = lsRutaFolder & "CHQ_PORCUENTA" & lsAmbiente & ".RPT"
        rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
        objLibreria.logonBDreporte(rptDoc, 1)
        'MDIValida.Report.Formulas(0) = "Fecha='" & InvierteFecha(gs_FechaHoy) & "'"
        'MDIValida.Report.Formulas(1) = "Hora='" & HoraSistema & "'"
        'MDIValida.Report.Formulas(2) = "Origen = 'BBVA'"
        rptDoc.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & Now().ToString("dd-MM-yyyy") & "'"
        rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Now().ToString("hh:mm") & "'"
        rptDoc.DataDefinition.FormulaFields.Item("Origen").Text = "'BBVA'"
        'MDIValida.Report.SelectionFormula = ls_Formula
        rptDoc.RecordSelectionFormula = ls_Formula

        'Screen.MousePointer = vbHourglass

        'MuestraVentanaReporte MDIValida.Report
        opcionReporte = 16
        RepOperativa.reporteOFAC = rptDoc
        RepOperativa.ShowDialog()

        'Screen.MousePointer = vbDefault
        '--------------------------------- RACB 28-05-2021
    End Sub
End Class