Imports CrystalDecisions.CrystalReports.Engine.DataDefinition
Imports CrystalDecisions.CrystalReports.Engine.ParameterFieldDefinition
Imports CrystalDecisions.Shared
Imports System.Net


Public Class RepOperativa
    Public sSelectionFormula, RutaDestino As String
    Public iTipo As Integer
    Public reporteOFAC As New ReportDocument

    Private Sub RepOperativa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim rptAperturaCuenta As New Aperturas_Back()
        Dim reporte As New ReportDocument
        Dim l As New Libreria
        Dim List As New List(Of String)
        Dim lsAmbiente As String = ""
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""

        'Verificar la ruta
        'MsgBox("My.Application.Info.DirectoryPath: " & My.Application.Info.DirectoryPath) '---- RACB 03/03/2021
        lsRutaFolder = My.Application.Info.DirectoryPath & "\" & l.sFolderRPT & "\"
        'lsRutaFolder = "D:\Gaby\Respaldo\CGAH\2020\Ticket\ModuloComplementarioTKT\ENCRIPTADORNET\Reportes" & "\"
        '& l.sFolderRPT & "\"
        'MsgBox("directorio: " & lsReporte2 & "\" & l.sFolderRPT)
        'MsgBox("directorio lsRutaFolder: " & lsRutaFolder) '---- RACB 03/03/2021
        'MsgBox("directorio sFolderRPT: " & l.sFolderRPT) '---- RACB 03/03/2021

        'lsReporte2 = CurDir()
        'MsgBox("directorio: " & lsReporte2)
        Me.Size = New Size(1220, 670) '---- RACB 24/04/2021

        Me.CenterToScreen()

        Try

            'determina el ambiente, si es preubas DES, si es Producción PROD
            If l.ENTORNO = "TEST" Then
                lsAmbiente = "Test"
            Else
                lsAmbiente = ""
            End If

            'Pone en puntero en espera
            Cursor = System.Windows.Forms.Cursors.WaitCursor


            'reporte Saldos dienero a la vista cuentas 000
            If opcionReporte = 1 Then
                lsReporte = lsRutaFolder & "CtasDVTOT" & lsAmbiente & ".rpt" '---- RACB 03/03/2021
                '--asigna el reporte a el objeto "reporte"
                reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault) '---- RACB 03/03/2021
                'reporte = New CtasDVTOT
                '--realiza la conexion del objeto "reporte" con la BD 
                l.logonBDreporte(reporte, 1)
                '--actualiza objeto "reporte"
                reporte.Refresh()
                '--pasamos valores de los campos de formula
                reporte.DataDefinition.FormulaFields.Item("HoraSistema").Text = "'" & Now().ToString("hh:mm") & "'"
                reporte.DataDefinition.FormulaFields.Item("HoraSaldo").Text = "'" & lsHora000 & "'"
                reporte.DataDefinition.FormulaFields.Item("FechaHoy").Text = "'" & Now().ToString("yyyy-mm-dd") & "'"

                ls_PorImprimir = " {vw_dinero_vista.agencia} = 1 "
                If iRango = 1 Then
                    ls_PorImprimir = ls_PorImprimir & " and {vw_dinero_vista.cuenta_cliente} >= '" & Trim(sCuentaIni) & "'"
                    ls_PorImprimir = ls_PorImprimir & " and {vw_dinero_vista.cuenta_cliente} <= '" & Trim(sCuentaFin) & "'"
                End If
                'asignamos la formula al reporte, se anexa sobre lo que ya tiene configurado en el reporte
                reporte.RecordSelectionFormula = (ls_PorImprimir)
            End If

            'reporte Operaciones Relevantes Retiros
            If opcionReporte = 2 Then
                'Aperturas del Dia 
                lsReporte = lsRutaFolder & "REL_RETIROS" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                'reporte = New REL_RETIROS
                'realiza la conexion del objeto "reporte" con la BD 
                l.logonBDreporte(reporte, 1)
                'actualiza objeto "reporte"
                reporte.Refresh()
                'pasamos valores de los campos de formula
                reporte.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & Now().ToString("yyyy-mm-dd") & "'"
                reporte.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Now().ToString("hh:mm") & "'"
                reporte.DataDefinition.FormulaFields.Item("Periodo").Text = "'Del " & fe_Inicio & " al " & fe_Fin & "'"

                'asignamos la formula al reporte, se anexa sobre lo que ya tiene configurado en el reporte
                reporte.RecordSelectionFormula = (ls_PorImprimir)
            End If

            'reporte Operaciones Relevantes Retiros
            If opcionReporte = 3 Then
                'Aperturas del Dia 
                lsReporte = lsRutaFolder & "REL_DEPOSITOS" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                'realiza la conexion del objeto "reporte" con la BD 
                'reporte = New REL_Depositos
                l.logonBDreporte(reporte, 1)
                'actualiza objeto "reporte"
                reporte.Refresh()

                'pasamos valores de los campos de formula
                reporte.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & Now().ToString("yyyy-mm-dd") & "'"
                reporte.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Now().ToString("hh:mm") & "'"
                reporte.DataDefinition.FormulaFields.Item("Periodo").Text = "'Del " & fe_Inicio & " al " & fe_Fin & "'"

                'asignamos la formula al reporte, se anexa sobre lo que ya tiene configurado en el reporte
                reporte.RecordSelectionFormula = (ls_PorImprimir)
            End If

            'reporte de TDD Posteos Rechazados
            If opcionReporte = 4 Then
                'Aperturas del Dia 
                lsReporte = lsRutaFolder & "tddCompras" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                'realiza la conexion del objeto "reporte" con la BD 
                'reporte = New tddCompras
                l.logonBDreporte(reporte, 1)
                'actualiza objeto "reporte"
                reporte.Refresh()
                'pasamos valores de los campos de formula
                reporte.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & Now().ToString("yyyy-MM-dd") & "'"
                reporte.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Now().ToString("hh:mm") & "'"
                reporte.DataDefinition.FormulaFields.Item("Titulo").Text = "'Posteos Rechazados'"

                'asignamos la formula al reporte, se anexa sobre lo que ya tiene configurado en el reporte
                reporte.RecordSelectionFormula = (ls_PorImprimir)
            End If

            'reporte de operaciones por usuario
            If opcionReporte = 5 Then
                'Reportes de operaciones por usuario 
                'rptOperacionesXUsuario2020
                'lsReporte = lsRutaFolder & "rptOperaXUsuario" & lsAmbiente & ".rpt"
                lsReporte = lsRutaFolder & "rptOperacionesXUsuario2020" & lsAmbiente & ".rpt"
                'reporte = New rptOperacionesXUsuario2020
                'asigna el reporte a el objeto "reporte"
                reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                'realiza la conexion del objeto "reporte" con la BD 
                l.logonBDreporte(reporte, 1)
                'actualiza objeto "reporte"
                reporte.Refresh()
                reporte.DataDefinition.FormulaFields.Item("FechaIni").Text = "'" & fe_Inicio & "'"
                reporte.DataDefinition.FormulaFields.Item("FechaFin").Text = "'" & fe_Fin & "'"
                reporte.RecordSelectionFormula = (ls_PorImprimir) '-----------RACB 22/03/2021
            End If

            'reporte de operaciones NO Validadas
            If opcionReporte = 6 Then
                'Reportes de operaciones NO Validadas
                'lsReporte = "d:\ope_recibNV" & lsAmbiente & ".rpt"
                lsReporte = lsRutaFolder & "op_recibNoValidadas" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                'reporte = New op_recibNoValidadas
                'realiza la conexion del objeto "reporte" con la BD 
                l.logonBDreporte(reporte, 1)
                'actualiza objeto "reporte"
                reporte.Refresh()
                reporte.DataDefinition.FormulaFields.Item("FechaHoy").Text = "'" & Now().ToString("yyyy-MM-dd") & "'"
                reporte.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Now().ToString("hh:mm") & "'"
                reporte.DataDefinition.FormulaFields.Item("FechaOp").Text = "'" & fe_Inicio.ToString & "'"
                'reporte.DataDefinition.SQLExpressionFields = ls_PorImprimir
                reporte.RecordSelectionFormula = (ls_PorImprimir)
            End If

            'reporte de operaciones Aplicación contable Fecha Inicio
            If opcionReporte = 7 Then
                lsReporte = lsRutaFolder & "aplic_contable" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                'realiza la conexion del objeto "reporte" con la BD 
                'reporte = New aplic_contable
                l.logonBDreporte(reporte, 1)
                'actualiza objeto "reporte"
                reporte.Refresh()
                reporte.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & Now().ToString("yyyy-MM-dd") & "'"
                reporte.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Now().ToString("hh:mm") & "'"
                reporte.DataDefinition.FormulaFields.Item("Agencia").Text = "'HOUSTON'"
                ls_PorImprimir = " {vw_tareas_entradas.fecha_contabilidad} = date(" & fe_Inicio.Substring(0, 4) & "," & fe_Inicio.Substring(5, 2) & "," & fe_Inicio.Substring(8, 2) & ")"
                ls_PorImprimir &= " AND {vw_tareas_entradas.agencia} = 1"
                reporte.RecordSelectionFormula = (ls_PorImprimir)
            End If

            'reporte de operaciones Aplicación contable Fecha Fin
            If opcionReporte = 8 Then
                lsReporte = lsRutaFolder & "aplic_contable" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                'reporte = New aplic_contable
                'realiza la conexion del objeto "reporte" con la BD 
                l.logonBDreporte(reporte, 1)
                'actualiza objeto "reporte"
                reporte.Refresh()
                reporte.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & Now().ToString("yyyy-MM-dd") & "'"
                reporte.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Now().ToString("hh:mm") & "'"
                reporte.DataDefinition.FormulaFields.Item("Agencia").Text = "'HOUSTON'"
                ls_PorImprimir = " {vw_tareas_entradas.fecha_contabilidad} = date(" & fe_Fin.Substring(0, 4) & "," & fe_Fin.Substring(5, 2) & "," & fe_Fin.Substring(8, 2) & ")"
                ls_PorImprimir &= " and  {vw_tareas_entradas.agencia} = 1"
                reporte.RecordSelectionFormula = (ls_PorImprimir)
            End If

            'reporte de operaciones Aplicación contable Fecha Fin
            If opcionReporte = 9 Then
                lsReporte = lsRutaFolder & "rptOrdenesDePago" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                'reporte = New rptOrdenesDePago
                'realiza la conexion del objeto "reporte" con la BD 
                l.logonBDreporte(reporte, 1)
                'actualiza objeto "reporte"
                reporte.Refresh()
                reporte.DataDefinition.FormulaFields.Item("FechaHoy").Text = "'" & Now().ToString("yyyy-MM-dd") & "'"
                reporte.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Now().ToString("hh:mm") & "'"
                reporte.SetParameterValue("pFechaIni", fe_Inicio)
                reporte.SetParameterValue("pFechaFin", fe_Fin)
            End If

            'reporte de cuentas bloqueadas y activas
            If opcionReporte = 10 Then
                lsReporte = lsRutaFolder & "rptCuentasCedAB" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                'reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                reporte.Load(lsReporte)
                'reporte = New rptCuentasCedAB
                'realiza la conexion del objeto "reporte" con la BD 
                'l.logonBDreporte(reporte, 1)
                'actualiza objeto "reporte"
                reporte.Refresh()
            End If

            'reporte de funcionarios con y sin cuenta CED
            If opcionReporte = 11 Then
                lsReporte = lsRutaFolder & "rptGestoresActCED2020" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                'reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                reporte.Load(lsReporte)
                'reporte = New rptGestoresActCED2020
                'realiza la conexion del objeto "reporte" con la BD 
                'l.logonBDreporte(reporte, 1)
                'actualiza objeto "reporte"
                reporte.Refresh()
            End If

            If opcionReporte = 12 Then
                lsReporte = lsRutaFolder & "rptMantCuentaPU" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                'reporte = New rptMantCuentaPU
                'realiza la conexion del objeto "reporte" con la BD 
                l.logonBDreporte(reporte, 1)
                'actualiza objeto "reporte"
                reporte.Refresh()
                reporte.RecordSelectionFormula = (ls_PorImprimir)
            End If

            If opcionReporte = 13 Then
                lsReporte = lsRutaFolder & "RepSaldosxCuenta2020" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                'reporte = New RepSaldosxCuenta2020
                'realiza la conexion del objeto "reporte" con la BD 
                l.logonBDreporte(reporte, 1)
                'actualiza objeto "reporte"
                reporte.Refresh()
                'reporte.SetParameterValue("FECHAHOY", fe_Inicio)
                reporte.SetParameterValue("@FECHAHOY", fe_Inicio)
                'reporte.RecordSelectionFormula = (ls_PorImprimir)
            End If

            If opcionReporte = 14 Then
                lsReporte = lsRutaFolder & "gos_DoctosDep" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                'reporte = New gos_DoctosDep
                'realiza la conexion del objeto "reporte" con la BD 
                l.logonBDreporte(reporte, 1)
                'actualiza objeto "reporte"
                reporte.Refresh()
                reporte.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & Now().ToString("yyyy-MM-dd") & "'"
                reporte.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Now().ToString("hh:mm") & "'"
                reporte.DataDefinition.FormulaFields.Item("HoraCap").Text = "'" & msHoraCap & "'"
                reporte.RecordSelectionFormula = (ls_PorImprimir)
            End If

            If opcionReporte = 15 Then
                lsReporte = lsRutaFolder & "gos_DoctosRet" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                'reporte = New gos_DoctosRet
                'realiza la conexion del objeto "reporte" con la BD 
                l.logonBDreporte(reporte, 1)
                'actualiza objeto "reporte"
                reporte.Refresh()
                reporte.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & Now().ToString("yyyy-MM-dd") & "'"
                reporte.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Now().ToString("hh:mm") & "'"
                reporte.DataDefinition.FormulaFields.Item("HoraCap").Text = "'" & msHoraCap & "'"
                reporte.RecordSelectionFormula = (ls_PorImprimir)
            End If

            '--------------------------------------- RACB 19/04/2021
            If opcionReporte = 16 Or opcionReporte = 17 Then
                reporte = reporteOFAC
            End If
            If opcionReporte <> 2 And opcionReporte <> 3 And opcionReporte <> 17 Then
                Dim cn As ConnectionInfo = New ConnectionInfo()
                cn.ServerName = l.Decrypt(l.SERVER)
                cn.DatabaseName = l.Decrypt("z1Rh9boc5VE=")
                cn.UserID = l.Decrypt("qeOBHX/EztY=")
                cn.Password = l.Decrypt("qeOBHX/EztY=")
                cn.Type = ConnectionInfoType.SQL
                SetDBLogonForReport(cn, reporte)
            ElseIf opcionReporte = 17 Then
                Dim cn As ConnectionInfo = New ConnectionInfo()
                cn.ServerName = l.Decrypt(l.SERVER)
                cn.DatabaseName = l.Decrypt("F/zR1+RmJaBlM9ASBnA7fA==")
                cn.UserID = l.Decrypt("qeOBHX/EztY=")
                cn.Password = l.Decrypt("qeOBHX/EztY=")
                cn.Type = ConnectionInfoType.SQL
                SetDBLogonForReport(cn, reporte)
            End If
            '--------------------------------------- RACB 19/04/2021

            '*************************
            '*************************
            '  Mostramos el reporte
            '*************************
            '*************************
            'reporte.Refresh()
            crvRepOper.ReportSource = reporte
            '*************************
            '*************************

            'restablecemos el puntero
            Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            MsgBox("Ha ocurrido un error: " & ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    '--------------------------------------- RACB 19/04/2021    
    Private Sub SetDBLogonForReport(varConnectionInfo As ConnectionInfo, rptDocument As ReportDocument)
        Dim myTables As Tables = rptDocument.Database.Tables
        For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
            myTableLogonInfo.ConnectionInfo = varConnectionInfo
            myTable.ApplyLogOnInfo(myTableLogonInfo)
        Next
    End Sub
    '--------------------------------------- RACB 19/04/2021
End Class