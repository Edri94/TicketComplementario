Imports CrystalDecisions.CrystalReports.Engine.DataDefinition
Imports CrystalDecisions.CrystalReports.Engine.ParameterFieldDefinition
Imports System.Net


Public Class RepAperturas
    Public sSelectionFormula, RutaDestino As String
    Public iTipo As Integer
    Dim lsAmbiente As String = ""
    Dim lsReporte As String = ""
    Dim lsRutaFolder As String = ""
    Dim objLibreria As New Libreria
    Private Sub RepAperturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        'Dim rptAperturaCuenta As New Aperturas_Back()
        Dim reporte As New ReportDocument

        Dim l As New Libreria

        Dim sFechaIni As String
        Dim sFechaFin As String
        Dim List As New List(Of String)
        Dim lsAmbiente As String = ""
        Dim lsReporte As String = ""

        Try
            sFechaIni = fe_Inicio
            sFechaFin = fe_Fin
            Me.Text = ls_TituloReporte

            'determina el ambiente, si es preubas DES, si es Producción PROD
            If l.ENTORNO = "TEST" Then
                lsAmbiente = "Test"
            Else
                lsAmbiente = ""
            End If

            If opcionReporte = 1 Then
                'Aperturas del Dia 
                'lsReporte = "d:\Aperturas_Back" & lsAmbiente & ".rpt"
                lsReporte = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\" & "Aperturas_Back" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                'realiza la conexion del objeto "reporte" con la BD 
                l.logonBDreporte(reporte, 1)
                'actualiza objeto "reporte"
                reporte.Refresh()

                'pasamos el parametros de la Agencia
                reporte.SetParameterValue("pAgencia", "Houston")

                'pasamos valores de los campos de formula
                reporte.DataDefinition.FormulaFields.Item("FechaInicio").Text = "'" & sFechaIni & "'"
                reporte.DataDefinition.FormulaFields.Item("FechaFin").Text = "'" & sFechaFin & "'"

                'asignamos la formula al reporte, se anexa sobre lo que ya tiene configurado en el reporte
                reporte.RecordSelectionFormula = (ls_PorImprimir + " and {PRODUCTO_CONTRATADO.agencia}= 1 ")

            ElseIf opcionReporte = 2 Then
                'Validadas en el Dia con Detalle
                'lsReporte = "d:\Aper_detalle" & lsAmbiente & ".rpt"
                lsReporte = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\" & "Aper_detalle" & lsAmbiente & ".rpt"
                reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                l.logonBDreporte(reporte, 1)
                reporte.Refresh()

                'Se arma el query que se anexara sobre el query que ya contiene el reporte
                ls_PorImprimir = "{OPERACION.fecha_operacion}= Date(" & sFechaIni.Substring(0, 4).Trim & "," & sFechaIni.Substring(5, 2).Trim & "," & sFechaIni.Substring(8, 2).Trim & ")"
                ls_PorImprimir &= " and {OPERACION.status_operacion} in [2,3,4,5] "
                ls_PorImprimir &= " and {OPERACION.operacion_definida}=8100 "
                ls_PorImprimir &= " and {PRODUCTO_CONTRATADO.agencia}=1 "

                reporte.RecordSelectionFormula = ("(" & ls_PorImprimir & ")")

            ElseIf opcionReporte = 3 Then
                'lsReporte = "d:\Aper_por_Fecha" & lsAmbiente & ".rpt"
                lsReporte = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\" & "Aper_por_Fecha" & lsAmbiente & ".rpt"
                reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                l.logonBDreporte(reporte, 1)
                reporte.Refresh()

                reporte.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & Now().ToString("yyyy-MM-dd") & "'"
                reporte.DataDefinition.FormulaFields.Item("Rango").Text = "'Del " & sFechaIni & " al " & sFechaFin & "'"

                ls_PorImprimir = "{PRODUCTO_CONTRATADO.fecha_contratacion}>= Date(" & sFechaIni.Substring(0, 4).Trim & "," & sFechaIni.Substring(5, 2).Trim & "," & sFechaIni.Substring(8, 2).Trim & ")"
                ls_PorImprimir &= " and {PRODUCTO_CONTRATADO.fecha_contratacion}<= Date(" & sFechaFin.Substring(0, 4).Trim & "," & sFechaFin.Substring(5, 2).Trim & "," & sFechaFin.Substring(8, 2).Trim & ")"
                ls_PorImprimir &= " and {PRODUCTO_CONTRATADO.producto}=8009 and {CLIENTE.agencia}=1 "

                reporte.RecordSelectionFormula = ("(" & ls_PorImprimir & ")")

            ElseIf opcionReporte = 4 Then
                'lsReporte = "d:\aper_ticket" & lsAmbiente & ".rpt"
                lsReporte = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\" & "aper_ticket" & lsAmbiente & ".rpt"
                reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                l.logonBDreporte(reporte, 2)
                reporte.Refresh()

                reporte.SetParameterValue("pAgencia", "Houston")
                reporte.DataDefinition.FormulaFields.Item("FechaHoy").Text = "'" & Now().ToString("yyyy-MM-dd") & "'"

                reporte.RecordSelectionFormula = ("(" & ls_PorImprimir & ")")

            End If

            'Mostramos el reporte
            CrystalRV_Aperturas.ReportSource = reporte


        Catch ex As Exception
            MsgBox("Ha ocurrido un error: " & ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub btn_Salir_Click(sender As Object, e As EventArgs) Handles btn_Salir.Click
        Me.CrystalRV_Aperturas.ReportSource = Nothing
        Me.Close()
    End Sub
End Class