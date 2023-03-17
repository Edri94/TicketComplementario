Imports System.Threading

Public Class frmRepTDOvernight
    Private objLibreria As New Libreria
    Private objDatasource As New Datasource
    Private Sub frmRepTDOvernight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Width = 7275
        'Me.Height = 5985
        'Call Centerform(Me)
        'Call CargarColores(Me, cambio)
        'lblOps.BackColor = vbBlue
        'lblOps.ForeColor = vbYellow
        'lblOps.FontBold = True
        'txtFecha = InvierteFecha(gs_FechaHoy)
        Dim dtRespConsulta As DataTable
        Dim dsLista As New DataSet
        gs_Sql = "Select descripcion_agencia, agencia from CATALOGOS..AGENCIA (nolock) Where agencia = 1 order by agencia"
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        cboAgencias.Items.Insert(0, "Selecciona una opción")
        For Each row As DataRow In dtRespConsulta.Rows
            cboAgencias.Items.Insert(row.Item("agencia"), row.Item("descripcion_agencia"))
        Next
        cboAgencias.SelectedIndex = 0
        If Thread.CurrentThread.CurrentCulture.Name = "en-US" Then
            dtpFecha.CustomFormat = "MM-dd-yyyy"
        ElseIf Thread.CurrentThread.CurrentCulture.Name = "es-MX" Then
            dtpFecha.CustomFormat = "dd-MM-yyyy"
        End If
        cmdAceptar.Enabled = False
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Dim ln_Items As Integer
        Dim ln_NumOps As Integer
        Dim ls_Rango As String
        Dim rptDoc As New ReportDocument
        Dim lsAmbiente As String = ""
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""

        ls_Rango = ""
        ln_NumOps = 0
        'For ln_Items = 1 To lstDatos.ListItems.Count
        '    If lstDatos.ListItems(ln_Items).Selected Then
        '        ln_NumOps = ln_NumOps + 1
        '    End If
        'Next ln_Items
        ln_NumOps = lstDatos.SelectedRows.Count
        If ln_NumOps = 0 Then
            If MsgBox("No hay operaciones seleccionadas ¿Desea imprimir todas las de la lista?", vbQuestion + vbYesNo, "Operaciones") = vbNo Then
                Exit Sub
            Else
                'For ln_Items = 1 To lstDatos.ListItems.Count
                '    lstDatos.ListItems(ln_Items).Selected = True
                'Next ln_Items
                For i = 0 To lstDatos.Rows.Count
                    lstDatos.Rows(i).Selected = True
                Next
            End If
        End If
        'Screen.MousePointer = vbHourglass
        lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
        If GsRepTDOver = "Normal" Then
            'OperacRepor.ReportFileName = GPATH & "\Compra_TD_Overnight.rpt"
            'rptDoc = New Compra_TD_Overnight
            lsReporte = lsRutaFolder & "Compra_TD_Overnight" & lsAmbiente & ".rpt"
            rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
            objLibreria.logonBDreporte(rptDoc, 1)
        Else
            'OperacRepor.ReportFileName = GPATH & "\Compra_TD_Overnight_lista.rpt"
            'rptDoc = New Compra_td_Overnight_lista
            lsReporte = lsRutaFolder & "Compra_td_Overnight_lista" & lsAmbiente & ".rpt"
            rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
            objLibreria.logonBDreporte(rptDoc, 1)
        End If
        'OperacRepor.Formulas(0) = "FechaHoy = '" & gs_FechaHoy & "'"
        'OperacRepor.Formulas(1) = "FechaOp = 'Fecha Operación: " & Trim(txtFecha) & "'"
        'OperacRepor.Formulas(2) = "Hora=' " & HoraSistema & "'"
        rptDoc.DataDefinition.FormulaFields.Item("FechaHoy").Text = "'" & gs_FechaHoy & "'"
        rptDoc.DataDefinition.FormulaFields.Item("FechaOp").Text = "'Fecha Operación: " & Trim(dtpFecha.Text) & "'"
        rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Format(gs_HoraSistema, "hh:mm") & "'"
        ln_NumOps = 0
        'For ln_Items = 1 To lstDatos.ListItems.Count
        For Each dgvrRegistroSeleccionado As DataGridViewRow In lstDatos.SelectedRows
            'If lstDatos.ListItems(ln_Items).Selected Then
            If ls_Rango = "" Then
                'ls_Rango = Trim(lstDatos.ListItems(ln_Items).text)
                ls_Rango = Trim(dgvrRegistroSeleccionado.Cells(0).Value)
            Else
                If Microsoft.VisualBasic.Right(Trim(ls_Rango), 1) = "]" Then
                    'ls_Rango = ls_Rango & " or {OPERACION.operacion} in [" & Trim(lstDatos.ListItems(ln_Items).text)
                    ls_Rango = ls_Rango & " or {OPERACION.operacion} in [" & Trim(dgvrRegistroSeleccionado.Cells(0).Value)
                Else
                    'ls_Rango = ls_Rango & ", " & Trim(lstDatos.ListItems(ln_Items).text)
                    ls_Rango = ls_Rango & ", " & Trim(dgvrRegistroSeleccionado.Cells(0).Value)
                End If
            End If
            ln_NumOps = ln_NumOps + 1
            If ln_NumOps Mod 20 = 0 Then
                ls_Rango = ls_Rango & "]"
            End If
            'End If
        Next 'ln_Items
        If ls_Rango <> "" Then
            lblOps.Text = "Imprimiendo..."
            lblOps.Refresh()

            If Microsoft.VisualBasic.Right(Trim(ls_Rango), 1) = "]" Then
                ls_Rango = "[" & ls_Rango
            Else
                ls_Rango = "[" & ls_Rango & "]"
            End If
            ls_Rango = "({OPERACION.operacion} in " & ls_Rango & ")"
            'OperacRepor.SelectionFormula = ls_Rango
            rptDoc.RecordSelectionFormula = ls_Rango
            'MuestraVentanaReporte(OperacRepor)
            opcionReporte = 16
            RepOperativa.reporteOFAC = rptDoc
            RepOperativa.ShowDialog()
        End If
        lblOps.Text = CStr(lstDatos.Rows.Count) & " operacion(es) en la lista"
        'Screen.MousePointer = vbDefault

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir del apartado Compra de TDs") <> vbYes Then
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub

    Private Sub cmdBuscar_Click(sender As Object, e As EventArgs) Handles cmdBuscar.Click
        Dim dtRespConsulta As DataTable
        If Trim(dtpFecha.Text) = "" Then
            MsgBox("Es necesario indicar la fecha del operación.", vbInformation, "Fecha Faltante")
            dtpFecha.Focus()
            Exit Sub
        End If
        'Screen.MousePointer = vbHourglass
        'lstDatos.ListItems.Clear
        lblOps.Text = "0 operacion(es) en la lista"
        cmdAceptar.Enabled = True
        gs_Sql = "Select "
        gs_Sql = gs_Sql & "OP.operacion As Operación, "
        gs_Sql = gs_Sql & "PC.cuenta_cliente As Cuenta, "
        gs_Sql = gs_Sql & "OP.monto_operacion As Monto, "
        gs_Sql = gs_Sql & "convert(char(10),OP.fecha_captura,105) As Fecha "
        gs_Sql = gs_Sql & "From "
        gs_Sql = gs_Sql & "TICKET..OPERACION OP, "
        gs_Sql = gs_Sql & "TICKET..PRODUCTO_CONTRATADO PC, "
        gs_Sql = gs_Sql & "TICKET..COMPRA_TD_OVERNIGHT TD "
        gs_Sql = gs_Sql & "Where "
        gs_Sql = gs_Sql & "OP.operacion_definida = 3180 and "
        gs_Sql = gs_Sql & "OP.operacion = TD.operacion and "
        gs_Sql = gs_Sql & "OP.fecha_operacion = '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' and "
        gs_Sql = gs_Sql & "OP.status_operacion <> 250 and "
        gs_Sql = gs_Sql & "OP.status_operacion >= 2 and "
        gs_Sql = gs_Sql & "OP.producto_contratado = PC.producto_contratado "
        gs_Sql = gs_Sql & "Order By OP.operacion"
        'LlenaLista(lstDatos, "Operación&Cuenta&Monto&Fecha de Captura", gs_Sql, True, False, False, 0, 0, "+2", "+0-0000000")
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
            'lstDatos.Rows.Clear()
            lstDatos.Columns.Clear()
            lstDatos.DataSource = Nothing
            lstDatos.Refresh()
            lstDatos.DataSource = dtRespConsulta
            lstDatos.Columns(2).DefaultCellStyle.Format = "N2"
            lblOps.Text = CStr(dtRespConsulta.Rows.Count) & " operacion(es) en la lista"
            lstDatos.Refresh()
        Else
            cmdAceptar.Enabled = False
            lstDatos.DataSource = Nothing
            MsgBox("No se encontraron operaciones para las fechas dadas.", vbInformation, "Operaciones")
            dtpFecha.Focus()
        End If

        'If lstDatos.ListItems.Count > 16 Then
        '    lstDatos.ColumnHeaders(4).Width = 1591      'Si hay mas de 16 columnas
        'Else
        '    lstDatos.ColumnHeaders(4).Width = 1786      'Si hay 16 columnas o menos
        'End If
        'If lstDatos.ListItems.Count = 0 Then
        'cmdAceptar.Enabled = False
        'MsgBox("No se encontraron operaciones para las fechas dadas.", vbInformation, "Operaciones")
        'dtpFecha.Focus()
        'End If
        'Screen.MousePointer = vbDefault
    End Sub
End Class