Imports System.IO
Imports System.Threading

Public Class frmRepOFAC
    Dim mn_opcion As Integer
    Dim mn_Agencia As Integer
    Dim ms_Agencia As String
    Dim num_error As Integer
    Dim objLibreria As New Libreria
    Dim objDatasource As New Datasource
    Dim reporteOFAC As New ReportDocument
    Dim lsAmbiente As String = ""
    Dim lsReporte As String = ""
    Dim lsRutaFolder As String = ""
    Public Sub Reporte(Opcion As Integer)

        mn_opcion = Opcion

        Select Case Opcion
            Case 0, 7
                Me.Text = Me.Text & "  Personas Físicas: Titulares"
            Case 1, 8
                Me.Text = Me.Text & "  Personas Físicas: Beneficiarios"
            Case 2, 9
                Me.Text = Me.Text & "  Personas Físicas: Cotitulares"
            Case 3, 10
                Me.Text = Me.Text & "  Personas Físicas: Autorizados"
            Case 4, 11
                Me.Text = Me.Text & "  Personas Morales: Titulares"
            Case 5, 12
                Me.Text = Me.Text & "  Personas Morales: Apoderados"
            Case 6, 13
                Me.Text = Me.Text & "  Personas Morales: Autorizados"
        End Select
        Me.Show()
    End Sub

    Private Sub frmRepOFAC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtRespConsulta As DataTable
        '    ShowWaitCursor
        '    Centerform Me
        'CargarColores Me, cambio
        Me.Show()
        Me.Refresh()
        If Thread.CurrentThread.CurrentCulture.Name = "en-US" Then
            dtpFechaIni.CustomFormat = "MM-dd-yyyy"
            dtpFechaFin.CustomFormat = "MM-dd-yyyy"
        ElseIf Thread.CurrentThread.CurrentCulture.Name = "es-MX" Then
            dtpFechaIni.CustomFormat = "dd-MM-yyyy"
            dtpFechaFin.CustomFormat = "dd-MM-yyyy"
        End If
        dtpFechaIni.Text = Date.Now.ToString("yyyy-MM-dd")
        dtpFechaFin.Text = Date.Now.ToString("yyyy-MM-dd")
        gs_Sql = " select agencia, descripcion_agencia from " & "CATALOGOS.dbo.AGENCIA "
        gs_Sql = gs_Sql & " where agencia = " & 1
        gs_Sql = gs_Sql & " order by agencia"
        'dbExecQuery(gs_Sql)
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'Do While dbError = 0
        '    lstAgencia.AddItem(dbGetValue(1))
        '    lstAgencia.ItemData(lstAgencia.NewIndex) = dbGetValue(0)
        '    dbGetRecord
        'Loop
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
            For Each row As DataRow In dtRespConsulta.Rows
                lstAgencia.Items.Add(row.Item(1))
            Next
        End If
        lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
        'dbEndQuery
        'ShowDefaultCursor
    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir del Modulo OFAC") <> vbYes Then Exit Sub
        Me.Close()
    End Sub

    Private Sub btExaminar_Click(sender As Object, e As EventArgs) Handles btExaminar.Click
        fbdExploradorCarpetas.Description() = "Seleccione la carpeta en la que se desea guardar el archivo."
        If (fbdExploradorCarpetas.ShowDialog() = DialogResult.OK) Then
            txtRuta.Text = fbdExploradorCarpetas.SelectedPath
        End If
    End Sub

    Private Sub optFecha_CheckedChanged(sender As Object, e As EventArgs) Handles optFecha.CheckedChanged
        If optFecha.Checked = True Then
            pnlFecha.Enabled = True
            optTodas.Checked = False
        End If
    End Sub

    Private Sub optTodas_CheckedChanged(sender As Object, e As EventArgs) Handles optTodas.CheckedChanged
        If optTodas.Checked = True Then
            pnlFecha.Enabled = False
            optFecha.Checked = False
        End If
    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        'Modificación: BAGO-EDS-07/MZO/06. Cambio de la constante "DESARROLLO" por la variable "DBDESARROLLO" y de la constante
        '              "CATALOGOS" por la variable "DBCATALOGOS"
        '              BAGO-EDS-13/MZO/06. Uso de IsNull en concatenación de cadenas

        Dim lsArchivo As String
        Dim LsFormula As String
        Dim lsProducto As String
        Dim lsStatusProducto1 As String
        Dim lsstatusProducto2 As String
        Dim lsListaCuentas As String
        Dim lsCuentas As String
        Dim lsSelectionFormula As String
        Dim lsSelForFileTxt As String
        Dim dtRespConsulta As DataTable
        Dim ruta As String = ""
        Dim escritor As StreamWriter
        'variables para crear el archivo
        Dim fs As VariantType
        Dim a As VariantType
        Dim sFechaIni As String
        Dim sFechaFin As String

        'No se ha seleccionado la agencia
        'If lstAgencia.ListIndex = -1 Then
        If txtRuta.Text = "" Then
            MsgBox("Debe seleccionar una ruta para guardar el archivo.", vbInformation, "Dato Faltante")
            Exit Sub
        End If
        If lstAgencia.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar una Agencia para el reporte.", vbInformation, "Dato Faltante")
            Exit Sub
        End If
        'Se eligio rango de fechas
        If optFecha.Checked = True Then
            If CDate(dtpFechaIni.Text) > CDate(dtpFechaFin.Text) Then
                MsgBox("La fecha final debe ser mayor o igual a la fecha inicial.", vbInformation, "Fecha Invalida")
                dtpFechaFin.Focus()
                Exit Sub
            End If
        End If
        'formato a la ruta del reporte
        If Microsoft.VisualBasic.Right(Trim(txtRuta.Text), 1) = "\" Then txtRuta.Text = Microsoft.VisualBasic.Left(Trim(txtRuta.Text), (Len(Trim(txtRuta.Text)) - 1))
        'El directorio especificado no existe
        If Dir(Trim(txtRuta.Text), vbDirectory) = "" Then
            MsgBox("El directorio no existe, por favor indique una ruta valida.", vbInformation, "Ruta Invalida")
            txtRuta.Focus()
            Exit Sub
        End If

        'reporteOFAC.Reset

        'Se busca el producto y el status dependiendo de la agencia
        Select Case mn_opcion
            Case 0, 1, 2, 3, 4, 5, 6
                'para cuentas activas
                gs_Sql = "select status_producto from " & "TICKET.dbo." & "STATUS_PRODUCTO WHERE status_producto_global =1 AND agencia=" & mn_Agencia
                'dbExecQuery gs_Sql
                'dbGetRecord
                'lsStatusProducto1 = dbGetValue(0)
                'dbEndQuery
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
                    lsStatusProducto1 = dtRespConsulta.Rows(0).Item(0).ToString()
                End If
                'para cuentas bloqueadas
                gs_Sql = "select status_producto from " & "TICKET.dbo." & "STATUS_PRODUCTO WHERE status_producto_global =4 AND agencia=" & mn_Agencia
                '    dbExecQuery gs_Sql
                'dbGetRecord
                '    lsstatusProducto2 = dbGetValue(0)
                '    dbEndQuery
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
                    lsstatusProducto2 = dtRespConsulta.Rows(0).Item(0).ToString()
                End If
        'Para cuentas canceladas
            Case 7, 8, 9, 10, 11, 12, 13
                gs_Sql = "select status_producto from " & "TICKET.dbo." & "STATUS_PRODUCTO WHERE status_producto_global=39 and agencia=" & mn_Agencia
                '    dbExecQuery gs_Sql
                'dbGetRecord
                '    lsStatusProducto1 = dbGetValue(0)
                '    dbEndQuery
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
                    lsStatusProducto1 = dtRespConsulta.Rows(0).Item(0).ToString()
                End If
        End Select

        'Para todos los tipos de cuenta dependiendo de la agencia
        gs_Sql = "select producto from " & "TICKET.dbo." & "PRODUCTO  WHERE producto_global=9 and agencia=" & mn_Agencia
        '    dbExecQuery gs_Sql
        'dbGetRecord
        '    lsProducto = dbGetValue(0)
        '    dbEndQuery
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        lsProducto = dtRespConsulta.Rows(0).Item(0).ToString()

        'Limpiamos las variables
        lsSelectionFormula = ""
        lsSelForFileTxt = ""

        fe_Inicio = dtpFechaIni.Value.ToString("yyyy-MM-dd")
        fe_Fin = dtpFechaFin.Value.ToString("yyyy-MM-dd")
        sFechaIni = fe_Inicio
        sFechaFin = fe_Fin

        'Se genera el selection formula dependiendo del tipo de reporte
        Select Case mn_opcion
        'Personas Fisicas Titular
            Case 0
                'reporteOFAC = New reptitA
                lsReporte = lsRutaFolder & "reptitA" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporteOFAC.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                objLibreria.logonBDreporte(reporteOFAC, 1)
                If optFecha.Checked Then
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "," & lsstatusProducto2 & "]"
                    'lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}>= Date(" & Format(Year(dtpFechaIni.Value), "0000") & "," & Format(Month(dtpFechaIni.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}>=Date(" & sFechaIni.Substring(0, 4).Trim & "," & sFechaIni.Substring(5, 2).Trim & "," & sFechaIni.Substring(8, 2).Trim & ")"
                    'lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}<= Date(" & Format(Year(dtpFechaIni.Value), "0000") & "," & Format(Month(dtpFechaFin.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}<=Date(" & sFechaFin.Substring(0, 4).Trim & "," & sFechaFin.Substring(5, 2).Trim & "," & sFechaFin.Substring(8, 2).Trim & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral}=0"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & "," & lsstatusProducto2 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta >= '" & sFechaIni.Substring(0, 4).Trim & "-" & sFechaIni.Substring(5, 2).Trim & "-" & sFechaIni.Substring(8, 2).Trim & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta <= '" & sFechaFin.Substring(0, 4).Trim & "-" & sFechaFin.Substring(5, 2).Trim & "-" & sFechaFin.Substring(8, 2).Trim & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 0"

                    If dtpFechaIni.Text <> dtpFechaFin.Text Then
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & " al " & dtpFechaFin & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text & " al " & dtpFechaFin.Text)
                    Else
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text)
                    End If
                Else
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "," & lsstatusProducto2 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral}=0"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & "," & lsstatusProducto2 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 0"

                    'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte de  Todas las Cuentas" & ";TRUE"
                    reporteOFAC.SetParameterValue("pFecha", "Reporte de  Todas las Cuentas")
                End If
                'reporteOFAC.ParameterFields(1) = "pAgencia;" & ms_Agencia & ";TRUE"
                reporteOFAC.SetParameterValue("pAgencia", ms_Agencia)
        'Personas Fisicas Titular
            Case 7
                'reporteOFAC = New reptitA
                lsReporte = lsRutaFolder & "reptitA" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporteOFAC.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                objLibreria.logonBDreporte(reporteOFAC, 1)
                If optFecha.Checked Then
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}>= Date(" & Format(Year(dtpFechaIni.Value), "0000") & "," & Format(Month(dtpFechaIni.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}<= Date(" & Format(Year(dtpFechaFin.Value), "0000") & "," & Format(Month(dtpFechaFin.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral} = 0"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta >= '" & Format(Month(dtpFechaIni.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & "-" & Format(Year(dtpFechaIni.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta <= '" & Format(Month(dtpFechaFin.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & "-" & Format(Year(dtpFechaFin.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 0"
                    If dtpFechaIni.Text <> dtpFechaFin.Text Then
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & " al " & dtpFechaFin & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text & " al " & dtpFechaFin.Text)
                    Else
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text)
                    End If
                Else
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral} = 0"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 0"

                    'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte de  Todas las Cuentas" & ";TRUE"
                    reporteOFAC.SetParameterValue("pFecha", "Reporte de  Todas las Cuentas")
                End If
                'reporteOFAC.ParameterFields(1) = "pAgencia;" & ms_Agencia & ";TRUE"
                reporteOFAC.SetParameterValue("pAgencia", ms_Agencia)
        'Personas Fisicas Beneficiarios
            Case 1
                'reporteOFAC = New repBenefA
                lsReporte = lsRutaFolder & "repBenefA" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporteOFAC.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                objLibreria.logonBDreporte(reporteOFAC, 1)
                If optFecha.Checked Then
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "," & lsstatusProducto2 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}>= Date(" & Format(Year(dtpFechaIni.Value), "0000") & "," & Format(Month(dtpFechaIni.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}<= date(" & Format(Year(dtpFechaFin.Value), "0000") & "," & Format(Month(dtpFechaFin.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral}=0"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & "," & lsstatusProducto2 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta >= '" & Format(Month(dtpFechaIni.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & "-" & Format(Year(dtpFechaIni.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta <= '" & Format(Month(dtpFechaFin.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & "-" & Format(Year(dtpFechaFin.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 0"

                    If dtpFechaIni.Text <> dtpFechaFin.Text Then
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & " al " & dtpFechaFin & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text & " al " & dtpFechaFin.Text)
                    Else
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text)
                    End If
                Else
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "," & lsstatusProducto2 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral}=0"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & "," & lsstatusProducto2 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 0"

                    'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte de  Todas las Cuentas" & ";TRUE"
                    reporteOFAC.SetParameterValue("pFecha", "Reporte de  Todas las Cuentas")
                End If
                'reporteOFAC.ParameterFields(1) = "pAgencia;" & ms_Agencia & ";TRUE"
                reporteOFAC.SetParameterValue("pAgencia", ms_Agencia)
                'reporteOFAC.ParameterFields(2) = "pTitulo;" & "BENEFICIARIOS" & ";TRUE"
                reporteOFAC.SetParameterValue("pTitulo", "BENEFICIARIOS")
        'Personas Fisicas Beneficiarios
            Case 8
                'reporteOFAC = New repBenefA
                lsReporte = lsRutaFolder & "repBenefA" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporteOFAC.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                objLibreria.logonBDreporte(reporteOFAC, 1)
                If optFecha.Checked Then
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}>= Date(" & Format(Year(dtpFechaIni.Value), "0000") & "," & Format(Month(dtpFechaIni.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}<= date(" & Format(Year(dtpFechaFin.Value), "0000") & "," & Format(Month(dtpFechaFin.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral}=0"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta >= '" & Format(Month(dtpFechaIni.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & "-" & Format(Year(dtpFechaIni.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta <= '" & Format(Month(dtpFechaFin.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & "-" & Format(Year(dtpFechaFin.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 0"

                    If dtpFechaIni.Text <> dtpFechaFin.Text Then
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & " al " & dtpFechaFin & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text & " al " & dtpFechaFin.Text)
                    Else
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text)
                    End If
                Else
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral}=0"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 0"

                    'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte de  Todas las Cuentas" & ";TRUE"
                    reporteOFAC.SetParameterValue("pFecha", "Reporte de  Todas las Cuentas")
                End If
                'reporteOFAC.ParameterFields(1) = "pAgencia;" & ms_Agencia & ";TRUE"
                reporteOFAC.SetParameterValue("pAgencia", ms_Agencia)
                'reporteOFAC.ParameterFields(2) = "pTitulo;" & "BENEFICIARIOS" & ";TRUE"
                reporteOFAC.SetParameterValue("pTitulo", "BENEFICIARIOS")
        'Personas Fisicas Cotitulares
            Case 2
                'reporteOFAC = New repcotA
                lsReporte = lsRutaFolder & "repcotA" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporteOFAC.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                objLibreria.logonBDreporte(reporteOFAC, 1)
                If optFecha.Checked Then
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "," & lsstatusProducto2 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}>= Date(" & Format(Year(dtpFechaIni.Value), "0000") & "," & Format(Month(dtpFechaIni.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}<= date(" & Format(Year(dtpFechaFin.Value), "0000") & "," & Format(Month(dtpFechaFin.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral}=0"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & "," & lsstatusProducto2 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta >= '" & Format(Month(dtpFechaIni.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & "-" & Format(Year(dtpFechaIni.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta <= '" & Format(Month(dtpFechaFin.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & "-" & Format(Year(dtpFechaFin.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 0"

                    If dtpFechaIni.Text <> dtpFechaFin.Text Then
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & " al " & dtpFechaFin & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text & " al " & dtpFechaFin.Text)
                    Else
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text)
                    End If
                    'reporteOFAC.ParameterFields(1) = "pAgencia;" & ms_Agencia & ";TRUE"
                    reporteOFAC.SetParameterValue("pAgencia", ms_Agencia)
                Else
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "," & lsstatusProducto2 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral}=0"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & "," & lsstatusProducto2 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 0"

                    'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte de  Todas las Cuentas" & ";TRUE"
                    reporteOFAC.SetParameterValue("pFecha", "Reporte de  Todas las Cuentas")
                End If
        'Personas Fisicas Cotitulares
            Case 9
                'reporteOFAC = New repcotA
                lsReporte = lsRutaFolder & "repcotA" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporteOFAC.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                objLibreria.logonBDreporte(reporteOFAC, 1)
                If optFecha.Checked Then
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}>= Date(" & Format(Year(dtpFechaIni.Value), "0000") & "," & Format(Month(dtpFechaIni.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}<= date(" & Format(Year(dtpFechaFin.Value), "0000") & "," & Format(Month(dtpFechaFin.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral}=0"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta >= '" & Format(Month(dtpFechaIni.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & "-" & Format(Year(dtpFechaIni.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta <= '" & Format(Month(dtpFechaFin.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & "-" & Format(Year(dtpFechaFin.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 0"

                    If dtpFechaIni.Text <> dtpFechaFin.Text Then
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & " al " & dtpFechaFin & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text & " al " & dtpFechaFin.Text)
                    Else
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text)
                    End If
                Else
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral}=0"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 0"

                    'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte de  Todas las Cuentas" & ";TRUE"
                    reporteOFAC.SetParameterValue("pFecha", "Reporte de  Todas las Cuentas")
                End If
                'reporteOFAC.ParameterFields(1) = "pAgencia;" & ms_Agencia & ";TRUE"
                reporteOFAC.SetParameterValue("pAgencia", ms_Agencia)
        'Personas Fisicas Autorizados
            Case 3
                'reporteOFAC = New repAutA
                lsReporte = lsRutaFolder & "repAutA" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporteOFAC.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                objLibreria.logonBDreporte(reporteOFAC, 1)
                If optFecha.Checked Then
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "," & lsstatusProducto2 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {vw_autorizados.fecha_alta}>= Date(" & Format(Year(dtpFechaIni.Value), "0000") & "," & Format(Month(dtpFechaIni.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {vw_autorizados.fecha_alta}<= date(" & Format(Year(dtpFechaFin.Value), "0000") & "," & Format(Month(dtpFechaFin.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {vw_autorizados.persona_moral}=0 and {vw_autorizados.agencia}= " & mn_Agencia

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & "," & lsstatusProducto2 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and " & "CATALOGOS..vw_autorizados.fecha_alta >= '" & Format(Month(dtpFechaIni.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & "-" & Format(Year(dtpFechaIni.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and " & "CATALOGOS..vw_autorizados.fecha_alta <= '" & Format(Month(dtpFechaFin.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & "-" & Format(Year(dtpFechaFin.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and " & "CATALOGOS..vw_autorizados.persona_moral = 0 and " & "CATALOGOS..vw_autorizados.agencia = " & mn_Agencia

                    If dtpFechaIni.Text <> dtpFechaFin.Text Then
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & " al " & dtpFechaFin & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text & " al " & dtpFechaFin.Text)
                    Else
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text)
                    End If
                Else
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto} = " & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "," & lsstatusProducto2 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {vw_autorizados.persona_moral} = 0 and {vw_autorizados.agencia}= " & mn_Agencia

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & "," & lsstatusProducto2 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and " & "CATALOGOS..vw_autorizados.persona_moral = 0 and " & "CATALOGOS..vw_autorizados.agencia = " & mn_Agencia

                    'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte de  Todas las Cuentas" & ";TRUE"
                    reporteOFAC.SetParameterValue("pFecha", "Reporte de  Todas las Cuentas")
                End If
                'reporteOFAC.ParameterFields(1) = "pAgencia;" & ms_Agencia & ";TRUE"
                reporteOFAC.SetParameterValue("pAgencia", ms_Agencia)
        'Personas Fisicas Autorizados
            Case 10
                'reporteOFAC = New repAutA
                lsReporte = lsRutaFolder & "repAutA" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporteOFAC.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                objLibreria.logonBDreporte(reporteOFAC, 1)
                If optFecha.Checked Then
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {vw_autorizados.fecha_alta}>= Date(" & Format(Year(dtpFechaIni.Value), "0000") & "," & Format(Month(dtpFechaIni.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {vw_autorizados.fecha_alta}<= date(" & Format(Year(dtpFechaFin.Value), "0000") & "," & Format(Month(dtpFechaFin.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {vw_autorizados.persona_moral}=0"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and " & "CATALOGOS..vw_autorizados.fecha_alta >= '" & Format(Month(dtpFechaIni.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & "-" & Format(Year(dtpFechaIni.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and " & "CATALOGOS..vw_autorizados.fecha_alta <= '" & Format(Month(dtpFechaFin.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & "-" & Format(Year(dtpFechaFin.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and " & "CATALOGOS..vw_autorizados.persona_moral = 0"

                    If dtpFechaIni.Text <> dtpFechaFin.Text Then
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & " al " & dtpFechaFin & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text & " al " & dtpFechaFin.Text)
                    Else
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text)
                    End If
                Else
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {vw_autorizados.persona_moral}=0"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and " & "CATALOGOS..vw_autorizados.persona_moral = 0"

                    'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte de  Todas las Cuentas" & ";TRUE"
                    reporteOFAC.SetParameterValue("pFecha", "Reporte de  Todas las Cuentas")
                End If
                'reporteOFAC.ParameterFields(1) = "pAgencia;" & ms_Agencia & ";TRUE"
                reporteOFAC.SetParameterValue("pAgencia", ms_Agencia)
        'Personas Morales Titulares
            Case 4
                'reporteOFAC = New reptitA
                lsReporte = lsRutaFolder & "reptitA" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporteOFAC.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                objLibreria.logonBDreporte(reporteOFAC, 1)
                If optFecha.Checked Then
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "," & lsstatusProducto2 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}>= Date(" & Format(Year(dtpFechaIni.Value), "0000") & "," & Format(Month(dtpFechaIni.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}<= date(" & Format(Year(dtpFechaFin.Value), "0000") & "," & Format(Month(dtpFechaFin.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral}=1"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & "," & lsstatusProducto2 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta >= '" & Format(Month(dtpFechaIni.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & "-" & Format(Year(dtpFechaIni.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta <= '" & Format(Month(dtpFechaFin.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & "-" & Format(Year(dtpFechaFin.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 1"

                    If dtpFechaIni.Text <> dtpFechaFin.Text Then
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & " al " & dtpFechaFin & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text & " al " & dtpFechaFin.Text)
                    Else
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text)
                    End If
                Else
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "," & lsstatusProducto2 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral}=1"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & "," & lsstatusProducto2 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 1"

                    'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte de  Todas las Cuentas" & ";TRUE"
                    reporteOFAC.SetParameterValue("pFecha", "Reporte de  Todas las Cuentas")
                End If
                'reporteOFAC.ParameterFields(1) = "pAgencia;" & ms_Agencia & ";TRUE"
                reporteOFAC.SetParameterValue("pAgencia", ms_Agencia)
        'Personas Morales Titulares
            Case 11
                'reporteOFAC = New reptitA
                lsReporte = lsRutaFolder & "reptitA" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporteOFAC.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                objLibreria.logonBDreporte(reporteOFAC, 1)
                If optFecha.Checked Then
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}>= Date(" & Format(Year(dtpFechaIni.Value), "0000") & "," & Format(Month(dtpFechaIni.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}<= date(" & Format(Year(dtpFechaFin.Value), "0000") & "," & Format(Month(dtpFechaFin.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral}=1"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta >= '" & Format(Month(dtpFechaIni.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & "-" & Format(Year(dtpFechaIni.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta <= '" & Format(Month(dtpFechaFin.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & "-" & Format(Year(dtpFechaFin.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 1"

                    If dtpFechaIni.Text <> dtpFechaFin.Text Then
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & " al " & dtpFechaFin & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text & " al " & dtpFechaFin.Text)
                    Else
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text)
                    End If
                Else
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral}=1"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 1"

                    'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte de  Todas las Cuentas" & ";TRUE"
                    reporteOFAC.SetParameterValue("pFecha", "Reporte de  Todas las Cuentas")
                End If
                'reporteOFAC.ParameterFields(1) = "pAgencia;" & ms_Agencia & ";TRUE"
                reporteOFAC.SetParameterValue("pAgencia", ms_Agencia)
        'Personas Morales Apoderados
            Case 5
                'reporteOFAC = New repApoA
                lsReporte = lsRutaFolder & "repApoA" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporteOFAC.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                objLibreria.logonBDreporte(reporteOFAC, 1)
                If optFecha.Checked Then
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "," & lsstatusProducto2 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}>= Date(" & Format(Year(dtpFechaIni.Value), "0000") & "," & Format(Month(dtpFechaIni.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}<= date(" & Format(Year(dtpFechaFin.Value), "0000") & "," & Format(Month(dtpFechaFin.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral}=1"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & "," & lsstatusProducto2 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta >= '" & Format(Month(dtpFechaIni.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & "-" & Format(Year(dtpFechaIni.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta <= '" & Format(Month(dtpFechaFin.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & "-" & Format(Year(dtpFechaFin.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 1"

                    If dtpFechaIni.Text <> dtpFechaFin.Text Then
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & " al " & dtpFechaFin & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text & " al " & dtpFechaFin.Text)
                    Else
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text)
                    End If
                Else
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "," & lsstatusProducto2 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral}=1"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & "," & lsstatusProducto2 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 1"

                    'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte de  Todas las Cuentas" & ";TRUE"
                    reporteOFAC.SetParameterValue("pFecha", "Reporte de  Todas las Cuentas")
                End If
                'reporteOFAC.ParameterFields(1) = "pAgencia;" & ms_Agencia & ";TRUE"
                reporteOFAC.SetParameterValue("pAgencia", ms_Agencia)
                'reporteOFAC.ParameterFields(2) = "pTitulo;" & "APODERADOS" & ";TRUE"
                reporteOFAC.SetParameterValue("pTitulo", "APODERADOS")
        'Personas Morales Apoderados
            Case 12
                'reporteOFAC = New repApoA
                lsReporte = lsRutaFolder & "repAutA" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporteOFAC.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                objLibreria.logonBDreporte(reporteOFAC, 1)
                If optFecha.Checked Then
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}>= Date(" & Format(Year(dtpFechaIni.Value), "0000") & "," & Format(Month(dtpFechaIni.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.fecha_alta}<= date(" & Format(Year(dtpFechaFin.Value), "0000") & "," & Format(Month(dtpFechaFin.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral}=1"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta >= '" & Format(Month(dtpFechaIni.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & "-" & Format(Year(dtpFechaIni.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.fecha_alta <= '" & Format(Month(dtpFechaFin.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & "-" & Format(Year(dtpFechaFin.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 1"

                    If dtpFechaIni.Text <> dtpFechaFin.Text Then
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & " al " & dtpFechaFin & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text & " al " & dtpFechaFin.Text)
                    Else
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text)
                    End If
                Else
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {CLIENTE.persona_moral}=1"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and C.persona_moral = 1"

                    'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte de  Todas las Cuentas" & ";TRUE"
                    reporteOFAC.SetParameterValue("pFecha", "Reporte de  Todas las Cuentas")
                End If
                'reporteOFAC.ParameterFields(1) = "pAgencia;" & ms_Agencia & ";TRUE"
                reporteOFAC.SetParameterValue("pAgencia", ms_Agencia)
                'reporteOFAC.ParameterFields(2) = "pTitulo;" & "APODERADOS" & ";TRUE"
                reporteOFAC.SetParameterValue("pTitulo", "APODERADOS")
        'Personas Morales Autorizados
            Case 6
                'reporteOFAC = New repAutA
                lsReporte = lsRutaFolder & "repAutA" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporteOFAC.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                objLibreria.logonBDreporte(reporteOFAC, 1)
                If optFecha.Checked Then
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "," & lsstatusProducto2 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {vw_autorizados.fecha_alta}>= Date(" & Format(Year(dtpFechaIni.Value), "0000") & "," & Format(Month(dtpFechaIni.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {vw_autorizados.fecha_alta}<= date(" & Format(Year(dtpFechaFin.Value), "0000") & "," & Format(Month(dtpFechaFin.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {vw_autorizados.persona_moral}=1"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & "," & lsstatusProducto2 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and " & "CATALOGOS..vw_autorizados.fecha_alta >= '" & Format(Month(dtpFechaIni.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & "-" & Format(Year(dtpFechaIni.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and " & "CATALOGOS..vw_autorizados.fecha_alta <= '" & Format(Month(dtpFechaFin.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & "-" & Format(Year(dtpFechaFin.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and " & "CATALOGOS..vw_autorizados.persona_moral = 1"

                    If dtpFechaIni.Text <> dtpFechaFin.Text Then
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & " al " & dtpFechaFin & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text & " al " & dtpFechaFin.Text)
                    Else
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text)
                    End If
                Else
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "," & lsstatusProducto2 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {vw_autorizados.persona_moral}=1"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & "," & lsstatusProducto2 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and " & "CATALOGOS..vw_autorizados.persona_moral = 1"

                    'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte de  Todas las Cuentas" & ";TRUE"
                    reporteOFAC.SetParameterValue("pFecha", "Reporte de  Todas las Cuentas")
                End If
                'reporteOFAC.ParameterFields(1) = "pAgencia;" & ms_Agencia & ";TRUE"
                reporteOFAC.SetParameterValue("pAgencia", ms_Agencia)
        'Personas Morales Autorizados
            Case 13
                'reporteOFAC = New repAutA
                lsReporte = lsRutaFolder & "repAutA" & lsAmbiente & ".rpt"
                'asigna el reporte a el objeto "reporte"
                reporteOFAC.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                objLibreria.logonBDreporte(reporteOFAC, 1)
                If optFecha.Checked Then
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {vw_autorizados.fecha_alta}>= Date(" & Format(Year(dtpFechaIni.Value), "0000") & "," & Format(Month(dtpFechaIni.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {vw_autorizados.fecha_alta}<= date(" & Format(Year(dtpFechaFin.Value), "0000") & "," & Format(Month(dtpFechaFin.Value), "00") & "," & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & ")"
                    lsSelectionFormula = lsSelectionFormula & " and {vw_autorizados.persona_moral}=1"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and " & "CATALOGOS..vw_autorizados.fecha_alta >= '" & Format(Month(dtpFechaIni.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaIni.Value), "00") & "-" & Format(Year(dtpFechaIni.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and " & "CATALOGOS..vw_autorizados.fecha_alta <= '" & Format(Month(dtpFechaFin.Value), "00") & "-" & Format(Microsoft.VisualBasic.Day(dtpFechaFin.Value), "00") & "-" & Format(Year(dtpFechaFin.Value), "0000") & "'"
                    lsSelForFileTxt = lsSelForFileTxt & " and " & "CATALOGOS..vw_autorizados.persona_moral = 1"

                    If dtpFechaIni.Text <> dtpFechaFin.Text Then
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & " al " & dtpFechaFin & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text & " al " & dtpFechaFin.Text)
                    Else
                        'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte del " & dtpFechaIni & ";TRUE"
                        reporteOFAC.SetParameterValue("pFecha", "Reporte del " & dtpFechaIni.Text)
                    End If
                Else
                    lsSelectionFormula = "{PRODUCTO_CONTRATADO.producto}=" & lsProducto & " and {PRODUCTO_CONTRATADO.status_producto} in [" & lsStatusProducto1 & "]"
                    lsSelectionFormula = lsSelectionFormula & " and {vw_autorizados.persona_moral}=1"

                    lsSelForFileTxt = "PD.producto = " & lsProducto & " and PD.status_producto in (" & lsStatusProducto1 & ")"
                    lsSelForFileTxt = lsSelForFileTxt & " and " & "CATALOGOS..vw_autorizados.persona_moral = 1"

                    'reporteOFAC.ParameterFields(0) = "pFecha;" & "Reporte de  Todas las Cuentas" & ";TRUE"
                    reporteOFAC.SetParameterValue("pFecha", "Reporte de  Todas las Cuentas")
                End If
                'reporteOFAC.ParameterFields(1) = "pAgencia;" & ms_Agencia & ";TRUE"
                reporteOFAC.SetParameterValue("pAgencia", ms_Agencia)
        End Select

        'Limpiamos la formula del reporte
        'Call LimpiaFormulas(reporteOFAC)

        'Elige el nombre del archivo en base a la opcion
        Select Case mn_opcion
        'Se genera el reporte en disco
            Case 0, 7
                'Ruta Final del archivo
                If mn_opcion = 0 Then
                    lsArchivo = txtRuta.Text & "\CActPFisTitulares.txt"
                ElseIf mn_opcion = 7 Then
                    lsArchivo = txtRuta.Text & "\CCanPFisTitulares.txt"
                End If

                'Si el archivo exite pregunta si desea sobreescribir.
                If Dir(lsArchivo, vbArchive) <> "" Then
                    If MsgBox("El Archivo " & lsArchivo & " ya Existe. ¿Desea Sobreescribirlo? ", vbYesNo + vbQuestion + vbDefaultButton2, "Reporte OFAC") = vbNo Then
                        Exit Sub
                    Else
                        On Error Resume Next
                        Kill(lsArchivo)
                        'If Err() <> 0 Then
                        '    Err.Clear()
                        '    MsgBox(Err.Description, vbCritical, "Error de Archivo")
                        '    Exit Sub
                        'End If
                    End If
                End If

                'Armamos la sentencia, con los resultados se generara el archivo
                gs_Sql = "SELECT PD.producto, PD.status_producto, C.cuenta_cliente, "
                gs_Sql = gs_Sql & "rtrim(C.nombre_cliente) + ' ' + rtrim(IsNull(C.apellido_paterno, Space(0))) + ' ' + rtrim(IsNull(C.apellido_materno, Space(0))) as Nombre "
                gs_Sql = gs_Sql & "From " & "TICKET..PRODUCTO_CONTRATADO PD INNER JOIN " & "CATALOGOS..CLIENTE C ON "
                gs_Sql = gs_Sql & "PD.cuenta_cliente = C.cuenta_cliente AND PD.agencia = C.agencia WHERE "
                gs_Sql = gs_Sql & lsSelForFileTxt
                gs_Sql = gs_Sql & " ORDER BY C.cuenta_cliente"

                'dbExecQuery(gs_Sql)
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                'If dbError = 0 Then
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
                    'Creamos el archivo
                    'Set fs = CreateObject("Scripting.FileSystemObject")
                    'Set a = fs.CreateTextFile(lsArchivo, True)
                    'Do While dbError = 0
                    '    'Insertamos en el archivo
                    '    a.writeline(dbGetValue(2) & "        " & dbGetValue(3))
                    '    dbGetRecord
                    'Loop
                    ''Cerramos el archivo
                    'a.Close
                    ruta = lsArchivo
                    escritor = File.AppendText(ruta)
                    For Each row As DataRow In dtRespConsulta.Rows
                        escritor.Write(row.Item(2) & "        " & row.Item(3) & vbCrLf)
                    Next
                    escritor.Flush()
                    escritor.Close()
                    'Aviso de operacion exitosa
                    MsgBox("Se generó el archivo " & lsArchivo, vbInformation, "Mensaje")
                    'dbEndQuery

                    'Realiza el reporte de Crystal
                    'reporteOFAC.ReportFileName = GPATH & "\reptitA.rpt"
                    'reporteOFAC.Destination = crptToWindow
                    'reporteOFAC.SelectionFormula = lsSelectionFormula
                    'Call MaximizaReporte(reporteOFAC)
                    opcionReporte = 16    'reporte de Mantenimientos
                    reporteOFAC.RecordSelectionFormula = lsSelectionFormula
                    RepOperativa.reporteOFAC = reporteOFAC
                    RepOperativa.ShowDialog()
                Else
                    MsgBox("No hay información concordante para generar el archivo " & lsArchivo, vbInformation, "Mensaje")
                    'dbEndQuery
                End If
            Case 1, 8
                'Ruta Final del archivo
                If mn_opcion = 1 Then
                    lsArchivo = txtRuta.Text & "\CActPFisBeneficiario.txt"
                ElseIf mn_opcion = 8 Then
                    lsArchivo = txtRuta.Text & "\CCanPFisBeneficiario.txt"
                End If

                'Si el archivo exite pregunta si desea sobreescribir.
                If Dir(lsArchivo, vbArchive) <> "" Then
                    If MsgBox("El Archivo " & lsArchivo & " ya Existe. ¿Desea Sobreescribirlo? ", vbYesNo + vbQuestion + vbDefaultButton2, "Reporte OFAC") = vbNo Then
                        Exit Sub
                    Else
                        On Error Resume Next
                        Kill(lsArchivo)
                        'If Err() <> 0 Then
                        '    Err.Clear()
                        '    MsgBox(Err.Description, vbCritical, "Error de Archivo")
                        '    Exit Sub
                        'End If
                    End If
                End If

                'Armamos la sentencia, con los resultados se generara el archivo
                gs_Sql = "SELECT  B.cuenta_cliente, "
                gs_Sql = gs_Sql & "rtrim(IsNull(B.nombre_benef, Space(0))) + ' ' + rtrim(IsNull(B.paterno_benef, Space(0))) + ' ' + rtrim(IsNull(B.materno_benef, Space(0))) as Nombre, "
                gs_Sql = gs_Sql & "C.cuenta_cliente, PD.cuenta_cliente "
                gs_Sql = gs_Sql & "From " & "CATALOGOS..BENEFICIARIO B INNER JOIN " & "CATALOGOS..CLIENTE C ON "
                gs_Sql = gs_Sql & "B.cuenta_cliente = C.cuenta_cliente AND "
                gs_Sql = gs_Sql & "B.agencia = C.agencia "
                gs_Sql = gs_Sql & "INNER JOIN " & "TICKET..PRODUCTO_CONTRATADO PD ON "
                gs_Sql = gs_Sql & "C.cuenta_cliente = PD.cuenta_cliente AND "
                gs_Sql = gs_Sql & "C.agencia = PD.agencia WHERE "
                gs_Sql = gs_Sql & lsSelForFileTxt
                gs_Sql = gs_Sql & " ORDER BY B.cuenta_cliente"

                'dbExecQuery(gs_Sql)
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                'If dbError = 0 Then
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
                    'Creamos el archivo
                    'Set fs = CreateObject("Scripting.FileSystemObject")
                    'Set a = fs.CreateTextFile(lsArchivo, True)
                    'Do While dbError = 0
                    '    'Insertamos en el archivo
                    '    a.writeline(dbGetValue(0) & "        " & dbGetValue(1))
                    '    dbGetRecord
                    'Loop
                    ''Cerramos el archivo
                    'a.Close
                    ruta = lsArchivo
                    escritor = File.AppendText(ruta)
                    For Each row As DataRow In dtRespConsulta.Rows
                        escritor.Write(row.Item(0) & "        " & row.Item(1) & vbCrLf)
                    Next
                    escritor.Flush()
                    escritor.Close()
                    'Aviso de operacion exitosa
                    MsgBox("Se generó el archivo " & lsArchivo, vbInformation, "Mensaje")
                    'dbEndQuery

                    'Realiza el reporte de Crystal
                    'reporteOFAC.ReportFileName = GPATH & "\repbenefA.rpt"
                    'reporteOFAC.Destination = crptToWindow
                    'reporteOFAC.SelectionFormula = lsSelectionFormula
                    'Call MaximizaReporte(reporteOFAC)
                    opcionReporte = 16    'reporte de Mantenimientos
                    reporteOFAC.RecordSelectionFormula = lsSelectionFormula
                    RepOperativa.reporteOFAC = reporteOFAC
                    RepOperativa.ShowDialog()
                Else
                    MsgBox("No hay información concordante para generar el archivo " & lsArchivo, vbInformation, "Mensaje")
                    'dbEndQuery
                End If
            Case 2, 9
                'Ruta Final del archivo
                If mn_opcion = 2 Then
                    lsArchivo = txtRuta.Text & "\CActPFisCotitulares.txt"
                ElseIf mn_opcion = 9 Then
                    lsArchivo = txtRuta.Text & "\CCanPFisCotitulares.txt"
                End If

                'Si el archivo exite pregunta si desea sobreescribir.
                If Dir(lsArchivo, vbArchive) <> "" Then
                    If MsgBox("El Archivo " & lsArchivo & " ya Existe. ¿Desea Sobreescribirlo? ", vbYesNo + vbQuestion + vbDefaultButton2, "Reporte OFAC") = vbNo Then
                        Exit Sub
                    Else
                        On Error Resume Next
                        Kill(lsArchivo)
                        'If Err() <> 0 Then
                        '    Err.Clear()
                        '    MsgBox(Err.Description, vbCritical, "Error de Archivo")
                        '    Exit Sub
                        'End If
                    End If
                End If

                'Armamos la sentencia, con los resultados se generara el archivo
                gs_Sql = "SELECT  CO.cuenta_cliente, "
                gs_Sql = gs_Sql & "rtrim(IsNull(CO.nombre_cot, Space(0))) + ' ' + rtrim(IsNull(CO.paterno_cot, Space(0))) + ' ' + rtrim(IsNull(CO.materno_cot, Space(0))) as Nombre, "
                gs_Sql = gs_Sql & "A.agencia, PD.producto_contratado "
                gs_Sql = gs_Sql & "FROM " & "CATALOGOS..COTITULAR CO INNER JOIN " & "CATALOGOS..CLIENTE C ON "
                gs_Sql = gs_Sql & "CO.cuenta_cliente = C.cuenta_cliente AND "
                gs_Sql = gs_Sql & "CO.agencia = C.agencia "
                gs_Sql = gs_Sql & "INNER JOIN " & "TICKET..PRODUCTO_CONTRATADO PD ON "
                gs_Sql = gs_Sql & "C.cuenta_cliente = PD.cuenta_cliente AND "
                gs_Sql = gs_Sql & "C.agencia = PD.agencia "
                gs_Sql = gs_Sql & "INNER JOIN " & "CATALOGOS..AGENCIA A ON "
                gs_Sql = gs_Sql & "C.agencia = A.agencia WHERE "
                gs_Sql = gs_Sql & lsSelForFileTxt
                gs_Sql = gs_Sql & " ORDER BY CO.cuenta_cliente"

                'dbExecQuery(gs_Sql)
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                'If dbError = 0 Then
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
                    'Creamos el archivo
                    'Set fs = CreateObject("Scripting.FileSystemObject")
                    'Set a = fs.CreateTextFile(lsArchivo, True)
                    'Do While dbError = 0
                    '    'Insertamos en el archivo
                    '    a.writeline(dbGetValue(0) & "        " & dbGetValue(1))
                    '    dbGetRecord
                    'Loop
                    ''Cerramos el archivo
                    'a.Close
                    ruta = lsArchivo
                    escritor = File.AppendText(ruta)
                    For Each row As DataRow In dtRespConsulta.Rows
                        escritor.Write(row.Item(0) & "        " & row.Item(1) & vbCrLf)
                    Next
                    escritor.Flush()
                    escritor.Close()
                    'Aviso de operacion exitosa
                    MsgBox("Se generó el archivo " & lsArchivo, vbInformation, "Mensaje")
                    'dbEndQuery

                    'Realiza el reporte de Crystal
                    'reporteOFAC.ReportFileName = GPATH & "\repcotA.rpt"
                    'reporteOFAC.Destination = crptToWindow
                    'reporteOFAC.SelectionFormula = lsSelectionFormula
                    'Call MaximizaReporte(reporteOFAC)
                    opcionReporte = 16    'reporte de Mantenimientos
                    reporteOFAC.RecordSelectionFormula = lsSelectionFormula
                    RepOperativa.reporteOFAC = reporteOFAC
                    RepOperativa.ShowDialog()
                Else
                    MsgBox("No hay información concordante para generar el archivo " & lsArchivo, vbInformation, "Mensaje")
                    'dbEndQuery
                End If
            Case 3, 10
                'Ruta Final del archivo
                If mn_opcion = 3 Then
                    lsArchivo = txtRuta.Text & "\CActPFisAutorizados.txt"
                ElseIf mn_opcion = 10 Then
                    lsArchivo = txtRuta.Text & "\CCanPFisAutorizados.txt"
                End If

                'Si el archivo exite pregunta si desea sobreescribir.
                If Dir(lsArchivo, vbArchive) <> "" Then
                    If MsgBox("El Archivo " & lsArchivo & " ya Existe. ¿Desea Sobreescribirlo? ", vbYesNo + vbQuestion + vbDefaultButton2, "Reporte OFAC") = vbNo Then
                        Exit Sub
                    Else
                        On Error Resume Next
                        Kill(lsArchivo)
                        'If Err() <> 0 Then
                        '    Err.Clear()
                        '    MsgBox(Err.Description, vbCritical, "Error de Archivo")
                        '    Exit Sub
                        'End If
                    End If
                End If

                'Armamos la sentencia, con los resultados se generara el archivo
                gs_Sql = "SELECT  rtrim(IsNull(" & "CATALOGOS..vw_autorizados.nombre_cliente, Space(0))) + ' ' + rtrim(IsNull(" & "CATALOGOS..vw_autorizados.apellido_paterno, Space(0))) + ' ' + rtrim(IsNull(" & "CATALOGOS..vw_autorizados.apellido_materno, Space(0))) as Nombre, "
                gs_Sql = gs_Sql & "rtrim(IsNull(" & "CATALOGOS..vw_autorizados.nombre_aut, Space(0))) + ' ' + rtrim(IsNull(" & "CATALOGOS..vw_autorizados.paterno_aut, Space(0))) + ' ' + rtrim(IsNull(" & "CATALOGOS..vw_autorizados.materno_aut, Space(0))) as Nombre, "
                gs_Sql = gs_Sql & "CATALOGOS..vw_autorizados.cuenta_cliente, PD.producto, PD.status_producto "
                gs_Sql = gs_Sql & "FROM    " & "CATALOGOS..vw_autorizados INNER JOIN "
                gs_Sql = gs_Sql & "TICKET..PRODUCTO_CONTRATADO PD ON "
                gs_Sql = gs_Sql & "CATALOGOS..vw_autorizados.cuenta_cliente = PD.cuenta_cliente AND "
                gs_Sql = gs_Sql & "CATALOGOS..vw_autorizados.agencia = PD.agencia WHERE "
                gs_Sql = gs_Sql & lsSelForFileTxt
                gs_Sql = gs_Sql & " ORDER BY " & "CATALOGOS..vw_autorizados.cuenta_cliente"

                'dbExecQuery(gs_Sql)
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                'If dbError = 0 Then
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
                    'Creamos el archivo
                    'Set fs = CreateObject("Scripting.FileSystemObject")
                    'Set a = fs.CreateTextFile(lsArchivo, True)
                    'Do While dbError = 0
                    '    'Insertamos en el archivo
                    '    a.writeline(dbGetValue(2) & "        " & dbGetValue(1))
                    '    dbGetRecord
                    'Loop
                    ''Cerramos el archivo
                    'a.Close
                    ruta = lsArchivo
                    escritor = File.AppendText(ruta)
                    For Each row As DataRow In dtRespConsulta.Rows
                        escritor.Write(row.Item(2) & "        " & row.Item(1) & vbCrLf)
                    Next
                    escritor.Flush()
                    escritor.Close()
                    'Aviso de operacion exitosa
                    MsgBox("Se generó el archivo " & lsArchivo, vbInformation, "Mensaje")
                    'dbEndQuery

                    'Realiza el reporte de Crystal
                    'reporteOFAC.ReportFileName = GPATH & "\repautA.rpt"
                    'reporteOFAC.Destination = crptToWindow
                    'reporteOFAC.SelectionFormula = lsSelectionFormula
                    'Call MaximizaReporte(reporteOFAC)
                    opcionReporte = 16    'reporte de Mantenimientos
                    reporteOFAC.RecordSelectionFormula = lsSelectionFormula
                    RepOperativa.reporteOFAC = reporteOFAC
                    RepOperativa.ShowDialog()
                Else
                    MsgBox("No hay información concordante para generar el archivo " & lsArchivo, vbInformation, "Mensaje")
                    'dbEndQuery
                End If
            Case 4, 11
                'Ruta Final del archivo
                If mn_opcion = 4 Then
                    lsArchivo = txtRuta.Text & "\CActPMorTitular.txt"
                ElseIf mn_opcion = 11 Then
                    lsArchivo = txtRuta.Text & "\CCanPMorTitular.txt"
                End If

                'Si el archivo exite pregunta si desea sobreescribir.
                If Dir(lsArchivo, vbArchive) <> "" Then
                    If MsgBox("El Archivo " & lsArchivo & " ya Existe. ¿Desea Sobreescribirlo? ", vbYesNo + vbQuestion + vbDefaultButton2, "Reporte OFAC") = vbNo Then
                        Exit Sub
                    Else
                        On Error Resume Next
                        Kill(lsArchivo)
                        'If Err() <> 0 Then
                        '    Err.Clear()
                        '    MsgBox(Err.Description, vbCritical, "Error de Archivo")
                        '    Exit Sub
                        'End If
                    End If
                End If

                'Armamos la sentencia, con los resultados se generara el archivo
                gs_Sql = "SELECT PD.producto, PD.status_producto, C.cuenta_cliente, "
                gs_Sql = gs_Sql & "rtrim(C.nombre_cliente) + ' ' + rtrim(IsNull(C.apellido_paterno, Space(0))) + ' ' + rtrim(IsNull(C.apellido_materno, Space(0))) as Nombre "
                gs_Sql = gs_Sql & "From " & "TICKET..PRODUCTO_CONTRATADO PD INNER JOIN " & "CATALOGOS..CLIENTE C ON "
                gs_Sql = gs_Sql & "PD.cuenta_cliente = C.cuenta_cliente AND PD.agencia = C.agencia WHERE "
                gs_Sql = gs_Sql & lsSelForFileTxt
                gs_Sql = gs_Sql & " ORDER BY C.cuenta_cliente"

                'dbExecQuery(gs_Sql)
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                'If dbError = 0 Then
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
                    'Creamos el archivo
                    'Set fs = CreateObject("Scripting.FileSystemObject")
                    'Set a = fs.CreateTextFile(lsArchivo, True)
                    'Do While dbError = 0
                    '    'Insertamos en el archivo
                    '    a.writeline(dbGetValue(2) & "        " & dbGetValue(3))
                    '    dbGetRecord
                    'Loop
                    ''Cerramos el archivo
                    'a.Close
                    ruta = lsArchivo
                    escritor = File.AppendText(ruta)
                    For Each row As DataRow In dtRespConsulta.Rows
                        escritor.Write(row.Item(2) & "        " & row.Item(3) & vbCrLf)
                    Next
                    escritor.Flush()
                    escritor.Close()
                    'Aviso de operacion exitosa
                    MsgBox("Se generó el archivo " & lsArchivo, vbInformation, "Mensaje")
                    'dbEndQuery

                    'Realiza el reporte de Crystal
                    'reporteOFAC.ReportFileName = GPATH & "\reptitA.rpt"
                    'reporteOFAC.Destination = crptToWindow
                    'reporteOFAC.SelectionFormula = lsSelectionFormula
                    'Call MaximizaReporte(reporteOFAC)
                    opcionReporte = 16    'reporte de Mantenimientos
                    reporteOFAC.RecordSelectionFormula = lsSelectionFormula
                    RepOperativa.reporteOFAC = reporteOFAC
                    RepOperativa.ShowDialog()
                Else
                    MsgBox("No hay información concordante para generar el archivo " & lsArchivo, vbInformation, "Mensaje")
                    'dbEndQuery
                End If
            Case 5, 12
                'Ruta Final del archivo
                If mn_opcion = 5 Then
                    lsArchivo = txtRuta.Text & "\CActPMorApoderado.txt"
                ElseIf mn_opcion = 12 Then
                    lsArchivo = txtRuta.Text & "\CCanPMorApoderado.txt"
                End If

                'Si el archivo exite pregunta si desea sobreescribir.
                If Dir(lsArchivo, vbArchive) <> "" Then
                    If MsgBox("El Archivo " & lsArchivo & " ya Existe. ¿Desea Sobreescribirlo? ", vbYesNo + vbQuestion + vbDefaultButton2, "Reporte OFAC") = vbNo Then
                        Exit Sub
                    Else
                        On Error Resume Next
                        Kill(lsArchivo)
                        'If Err() <> 0 Then
                        '    Err.Clear()
                        '    MsgBox(Err.Description, vbCritical, "Error de Archivo")
                        '    Exit Sub
                        'End If
                    End If
                End If

                'Armamos la sentencia, con los resultados se generara el archivo
                gs_Sql = "SELECT  APO.cuenta_cliente, "
                gs_Sql = gs_Sql & "rtrim(APO.nombre_apo) + ' ' + rtrim(isNull(APO.paterno_apo, Space(0))) + ' ' + rtrim(IsNull(APO.materno_apo, Space(0))) as Nombre, "
                gs_Sql = gs_Sql & "C.cuenta_cliente, PD.producto_contratado "
                gs_Sql = gs_Sql & "FROM    " & "CATALOGOS..APODERADO APO INNER JOIN " & "CATALOGOS..CLIENTE C ON "
                gs_Sql = gs_Sql & "APO.cuenta_cliente = C.cuenta_cliente AND "
                gs_Sql = gs_Sql & "APO.agencia = C.agencia "
                gs_Sql = gs_Sql & "INNER JOIN " & "TICKET..PRODUCTO_CONTRATADO PD ON "
                gs_Sql = gs_Sql & "C.cuenta_cliente = PD.cuenta_cliente AND PD.agencia = C.agencia WHERE "
                gs_Sql = gs_Sql & lsSelForFileTxt
                gs_Sql = gs_Sql & " ORDER BY APO.cuenta_cliente"

                'dbExecQuery(gs_Sql)
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                'If dbError = 0 Then
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
                    'Creamos el archivo
                    'Set fs = CreateObject("Scripting.FileSystemObject")
                    'Set a = fs.CreateTextFile(lsArchivo, True)
                    'Do While dbError = 0
                    '    'Insertamos en el archivo
                    '    a.writeline(dbGetValue(0) & "        " & dbGetValue(1))
                    '    dbGetRecord
                    'Loop
                    ''Cerramos el archivo
                    'a.Close
                    ruta = lsArchivo
                    escritor = File.AppendText(ruta)
                    For Each row As DataRow In dtRespConsulta.Rows
                        escritor.Write(row.Item(0) & "        " & row.Item(1) & vbCrLf)
                    Next
                    escritor.Flush()
                    escritor.Close()
                    'Aviso de operacion exitosa
                    MsgBox("Se generó el archivo " & lsArchivo, vbInformation, "Mensaje")
                    'dbEndQuery

                    'Realiza el reporte de Crystal
                    'reporteOFAC.ReportFileName = GPATH & "\repApoA.rpt"
                    'reporteOFAC.Destination = crptToWindow
                    'reporteOFAC.SelectionFormula = lsSelectionFormula
                    'Call MaximizaReporte(reporteOFAC)
                    opcionReporte = 16    'reporte de Mantenimientos
                    reporteOFAC.RecordSelectionFormula = lsSelectionFormula
                    RepOperativa.reporteOFAC = reporteOFAC
                    RepOperativa.ShowDialog()
                Else
                    MsgBox("No hay información concordante para generar el archivo " & lsArchivo, vbInformation, "Mensaje")
                    'dbEndQuery
                End If
            Case 6, 13
                'Ruta Final del archivo
                If mn_opcion = 6 Then
                    lsArchivo = txtRuta.Text & "\CActPMorAutorizado.txt"
                ElseIf mn_opcion = 13 Then
                    lsArchivo = txtRuta.Text & "\CCanPMorAutorizado.txt"
                End If

                'Si el archivo exite pregunta si desea sobreescribir.
                If Dir(lsArchivo, vbArchive) <> "" Then
                    If MsgBox("El Archivo " & lsArchivo & " ya Existe. ¿Desea Sobreescribirlo? ", vbYesNo + vbQuestion + vbDefaultButton2, "Reporte OFAC") = vbNo Then
                        Exit Sub
                    Else
                        On Error Resume Next
                        Kill(lsArchivo)
                        'If Err() <> 0 Then
                        '    Err.Clear()
                        '    MsgBox(Err.Description, vbCritical, "Error de Archivo")
                        '    Exit Sub
                        'End If
                    End If
                End If

                'Armamos la sentencia, con los resultados se generara el archivo
                gs_Sql = "SELECT  rtrim(IsNull(" & "CATALOGOS..vw_autorizados.nombre_cliente, Space(0))) + ' ' + rtrim(IsNull(" & "CATALOGOS..vw_autorizados.apellido_paterno, Space(0))) + ' ' + rtrim(IsNull(" & "CATALOGOS..vw_autorizados.apellido_materno, Space(0))) as Nombre, "
                gs_Sql = gs_Sql & "rtrim(IsNull(" & "CATALOGOS..vw_autorizados.nombre_aut, Space(0))) + ' ' + rtrim(IsNull(" & "CATALOGOS..vw_autorizados.paterno_aut, Space(0))) + ' ' + rtrim(IsNull(" & "CATALOGOS..vw_autorizados.materno_aut, Space(0))) as Nombre, "
                gs_Sql = gs_Sql & "CATALOGOS..vw_autorizados.cuenta_cliente, PD.producto, PD.status_producto "
                gs_Sql = gs_Sql & "FROM    " & "CATALOGOS..vw_autorizados INNER JOIN "
                gs_Sql = gs_Sql & "TICKET..PRODUCTO_CONTRATADO PD ON "
                gs_Sql = gs_Sql & "CATALOGOS..vw_autorizados.cuenta_cliente = PD.cuenta_cliente AND "
                gs_Sql = gs_Sql & "CATALOGOS..vw_autorizados.agencia = PD.agencia WHERE "
                gs_Sql = gs_Sql & lsSelForFileTxt
                gs_Sql = gs_Sql & " ORDER BY " & "CATALOGOS..vw_autorizados.cuenta_cliente"

                'dbExecQuery(gs_Sql)
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                'If dbError = 0 Then
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
                    'Creamos el archivo
                    'Set fs = CreateObject("Scripting.FileSystemObject")
                    'Set a = fs.CreateTextFile(lsArchivo, True)
                    'Do While dbError = 0
                    '    'Insertamos en el archivo
                    '    a.writeline(dbGetValue(2) & "        " & dbGetValue(3))
                    '    dbGetRecord
                    'Loop
                    ''Cerramos el archivo
                    'a.Close
                    ruta = lsArchivo
                    escritor = File.AppendText(ruta)
                    For Each row As DataRow In dtRespConsulta.Rows
                        escritor.Write(row.Item(2) & "        " & row.Item(3) & vbCrLf)
                    Next
                    escritor.Flush()
                    escritor.Close()
                    'Aviso de operacion exitosa
                    MsgBox("Se generó el archivo " & lsArchivo, vbInformation, "Mensaje")
                    'dbEndQuery

                    'Realiza el reporte de Crystal
                    'reporteOFAC.ReportFileName = GPATH & "\repautA.rpt"
                    'reporteOFAC.Destination = crptToWindow
                    'reporteOFAC.SelectionFormula = lsSelectionFormula
                    'Call MaximizaReporte(reporteOFAC)
                    opcionReporte = 16    'reporte de Mantenimientos
                    reporteOFAC.RecordSelectionFormula = lsSelectionFormula
                    RepOperativa.reporteOFAC = reporteOFAC
                    RepOperativa.ShowDialog()
                Else
                    MsgBox("No hay información concordante para generar el archivo " & lsArchivo, vbInformation, "Mensaje")
                    'dbEndQuery
                End If
        End Select
    End Sub

    Private Sub lstAgencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAgencia.SelectedIndexChanged
        'If lstAgencia.ListIndex > -1 Then
        If lstAgencia.SelectedIndex > -1 Then
            'ms_Agencia = lstAgencia.List(lstAgencia.ListIndex)
            ms_Agencia = lstAgencia.SelectedItem.ToString()
            'mn_Agencia = lstAgencia.ItemData(lstAgencia.ListIndex)
            mn_Agencia = lstAgencia.SelectedIndex + 1
            cmdImprimir.Focus()
        End If
    End Sub
    '-------------------------------------------------------
    'Limpia las formulas remanentes en un Reporte de Crystal
    'Originalmente se encontraba en moddeclaraciones-Mesa y modMiscelaneas - Back
    'Agregada e identada por CEB 20-02-2002
    '-------------------------------------------------------
    Public Sub LimpiaFormulas(Reporte As Object)

        Dim ln_Formula As Integer

        Reporte.SortFields(0) = ""
        Reporte.SortFields(1) = ""
        Reporte.SortFields(2) = ""
        Reporte.SelectionFormula = ""
        For ln_Formula = 0 To 50
            Reporte.Formulas(ln_Formula) = ""
        Next ln_Formula
    End Sub
End Class