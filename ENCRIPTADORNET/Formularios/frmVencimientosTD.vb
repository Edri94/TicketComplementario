Imports System.Threading

Public Class frmVencimientosTD
    Private objLibreria As New Libreria
    Private objDatasource As New Datasource
    Private Sub frmVencimientosTD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtRespConsulta As DataTable
        '      Centerform Me
        'CargarColores Me, cambio
        'Me.Show()
        gs_Sql = "Select agencia, descripcion_agencia from " & "CATALOGOS.dbo.AGENCIA "
        gs_Sql = gs_Sql & " where agencia = 1 " '& GsPermisoAgencia
        gs_Sql = gs_Sql & " order by agencia"
        '    dbExecQuery(gs_Sql)
        '    dbGetRecord
        '    Do While Not IsdbError
        '        lstAgencia.AddItem Trim(dbGetValue(1))
        'lstAgencia.ItemData(lstAgencia.NewIndex) = Val(dbGetValue(0))
        '        dbGetRecord
        '    Loop
        '    dbEndQuery
        '    txtfecha = InvierteFecha(gs_FechaHoy)
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        lstAgencia.Items.Insert(0, "Selecciona una opción")
        For Each row As DataRow In dtRespConsulta.Rows
            lstAgencia.Items.Insert(row.Item("agencia"), row.Item("descripcion_agencia"))
        Next
        lstAgencia.SelectedIndex = 0
        If Thread.CurrentThread.CurrentCulture.Name = "en-US" Then
            dtpFecha.CustomFormat = "MM-dd-yyyy"
        ElseIf Thread.CurrentThread.CurrentCulture.Name = "es-MX" Then
            dtpFecha.CustomFormat = "dd-MM-yyyy"
        End If
    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir del apartado Vencimiento de TDs por día") <> vbYes Then
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        Dim ls_Fecha As String
        Dim rptDoc As New ReportDocument
        Dim lsAmbiente As String = ""
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""
        If lstAgencia.SelectedIndex < 1 Then
            MsgBox("Falta indicar la agencia.", vbInformation, "Agencia")
            lstAgencia.Focus()
            Exit Sub
        End If
        'Screen.MousePointer = vbHourglass
        ls_Fecha = DateAdd("d", 1, dtpFecha.Value).ToString
        '      ReportVencDia.ReportFileName = GPATH & "\TDsVencimientos.rpt"
        'rptDoc = New tdsvencimientos
        lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
        lsReporte = lsRutaFolder & "tdsvencimientos" & lsAmbiente & ".rpt"
        rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
        rptDoc.RecordSelectionFormula = "{vw_vencimientos_td_dia.fecha_vencimiento} >= Date ("
        rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & Format(Year(dtpFecha.Value), "0000")
        rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & "," & Format(Month(dtpFecha.Value), "00")
        rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & "," & Format(Microsoft.VisualBasic.Day(dtpFecha.Value), "00") & ") "
        rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & "and {vw_vencimientos_td_dia.fecha_vencimiento} < Date ("
        rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & Format(Year(ls_Fecha), "0000")
        rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & "," & Format(Month(ls_Fecha), "00")
        rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & "," & Format(Microsoft.VisualBasic.Day(ls_Fecha), "00") & ") "
        rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & "and {vw_vencimientos_td_dia.agencia} = " & lstAgencia.SelectedIndex
        'ReportVencDia.Formulas(0) = "VencDIA = '" & txtfecha & "'"
        'ReportVencDia.Formulas(1) = "HORA = '" & Format(Time, "hh:mm") & "'"
        'ReportVencDia.Formulas(2) = "FechaHoy = '" & InvierteFecha(gs_FechaHoy) & "'"

        rptDoc.DataDefinition.FormulaFields.Item("VencDIA").Text = "'" & Trim(dtpFecha.Text) & "'"
        rptDoc.DataDefinition.FormulaFields.Item("HORA").Text = "'" & gs_HoraSistema & "'"
        rptDoc.DataDefinition.FormulaFields.Item("FechaHoy").Text = "'" & Trim(dtpFecha.Text) & "'"
        opcionReporte = 16
        RepOperativa.reporteOFAC = rptDoc
        RepOperativa.ShowDialog()
        '      MuestraVentanaReporte ReportVencDia
        '      Screen.MousePointer = vbDefault
    End Sub
End Class