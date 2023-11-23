Imports System.IO
Imports System.Threading

Public Class frmMT198
    Private mnOpIndice As Integer  ' Maneja los Indices del Combo de Operaciones
    Private mnNumOps As Long     ' Almacena el numero de operaciones por caso
    Private mnReenvio As Byte     ' Bandera para permiso de reenvio
    Private mnImpresion As Byte     ' Bandera para permiso impresion
    Private mnContinua As Byte     ' Bandera para continuar con los eventos despues de mostrar el reporte de envio
    Private mnRepSwift As Long     ' Variable para almacenar en numero de reporte swift actual
    Private mnCambioFecha As Byte     ' Bandera para no tener problemas con el cambio de fecha y el refresh
    Private mnInicia As Byte     ' Bandera para inicio de busquedascboOperacion
    Private objExcel As Object   'Objeto excel
    'Dim objExcel            As Excel.Application
    Private existeArchivo As Boolean
    Private nomOpEnLista As String
    Private arrnomOpEnLista() As String
    Private strFile As String
    Private strnameFile As String

    Private objDatasource As New Datasource
    Private dtRespConsulta As DataTable
    Private objLibreria As New Libreria
    Private objArchivoExcel As StreamWriter
    Private bEncabezados As Boolean = True
    Private sRutaArchivo As String
    Private Sub frmMT198_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Se cambia cursor a reloj de espera - ALB
        'Screen.MousePointer = vbHourglass
        'Cambio de imagen de la forma
        'CargarColores Me, cambio
        lblTotalOperaciones.BackColor = Color.Black
        lblTotalOperaciones.ForeColor = Color.White
        'Centerform Me
        gs_Sql = "Select descripcion_agencia, agencia from " & "CATALOGOS" & "..AGENCIA WITH (NOLOCK) where agencia " & "= 1" & " order by agencia"
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'Do While dbError() = 0
        '    cboAgencias.AddItem dbGetValue(0)
        'cboAgencias.ItemData(cboAgencias.NewIndex) = dbGetValue(1)
        '    dbGetRecord
        'Loop
        cboAgencias.ValueMember = "agencia"
        cboAgencias.DisplayMember = "descripcion_agencia"
        cboAgencias.DataSource = dtRespConsulta
        cboAgencias.SelectedIndex = 0
        'dbEndQuery
        mnInicia = 0
        If cboAgencias.Items.Count > 0 Then
            'cboAgencias.ListIndex = 0
            cmdPorEnviar.Visible = OperacionesPorEnviarAgencia(cboAgencias.SelectedValue) 'cboAgencias.ItemData(0))
            'cboOperacion.DataSource.Clear
            gs_Sql = "Select descripcion_operacion_definida, trs.tipo_reporte_swift"
            gs_Sql = gs_Sql & " from OPERACION_DEFINIDA od WITH (NOLOCK), TIPO_REPORTE_SWIFT trs WITH (NOLOCK)"
            gs_Sql = gs_Sql & " Where trs.operacion_definida_global = od.operacion_definida_global"
            gs_Sql = gs_Sql & " and od.agencia = trs.agencia"
            gs_Sql = gs_Sql & " and od.agencia = " & cboAgencias.SelectedValue 'cboAgencias.ItemData(0)
            gs_Sql = gs_Sql & " and trs.tipo_reporte_swift not in (17,18)"
            gs_Sql = gs_Sql & " order by trs.tipo_reporte_swift"
            'dbExecQuery gs_Sql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            'Do While dbError() = 0
            '    cboOperacion.AddItem dbGetValue(0)
            '    cboOperacion.ItemData(cboOperacion.NewIndex) = Val(dbGetValue(1))
            '    dbGetRecord
            'Loop
            cboOperacion.ValueMember = "tipo_reporte_swift"
            cboOperacion.DisplayMember = "descripcion_operacion_definida"
            cboOperacion.DataSource = dtRespConsulta
            cboOperacion.SelectedIndex = 0
            'dbEndQuery
        End If
        If cboOperacion.Items.Count > 0 Then
            'cboOperacion.ListIndex = 0
            cboOperacion.SelectedIndex = 0
        End If
        'txtFecha = InvierteFecha(gs_FechaHoy)
        If Thread.CurrentThread.CurrentCulture.Name = "en-US" Then
            dtpFecha.CustomFormat = "MM-dd-yyyy"
            lblFormatoFecha.Text = "mm-dd-yyyy"
        ElseIf Thread.CurrentThread.CurrentCulture.Name = "es-MX" Then
            dtpFecha.CustomFormat = "dd-MM-yyyy"
            lblFormatoFecha.Text = "dd-mm-aaaa"
        End If
        mnReenvio = 0
        mnImpresion = 0
        ' Verifica si el usuario tiene permiso para envio de reportes swift
        If True Then 'If objLibreria.Permiso("PENVIOMT198") Then
            optOpciones0.Enabled = True
            optOpciones0.Checked = True
            chkUltimoRep.Enabled = True
        Else
            optOpciones0.Enabled = False
            optOpciones1.Checked = True
            chkUltimoRep.Enabled = False
            'Si no tiene el permiso, se regresa a default - ALB
            'Screen.MousePointer = vbDefault
        End If
        Me.Show()
        Me.Refresh()
        mnInicia = 1
    End Sub
    '---------------------------------------------------------------------------------------------
    'Evalua si hay operaciones que falten por enviar en el 198 se usa en las formas mt198 y mt202
    '---------------------------------------------------------------------------------------------
    Function OperacionesPorEnviarAgencia(nagencia As Integer, Optional bbva As String = "") As Boolean
        'Se excluyen de esta funcion las operaciones con operacion_definida_global 81 y 91
        gs_Sql = "select count(OP.operacion) "
        'If Not IsMissing(bbva) Then
        If Not (bbva IsNot Nothing) Then
            gs_Sql = gs_Sql & " from OPERACION OP left outer join FUNCIONARIOS..FUNCIONARIO F WITH (NOLOCK) on OP.funcionario = F.funcionario, PRODUCTO_CONTRATADO PC WITH (NOLOCK), "
        Else
            gs_Sql = gs_Sql & " from OPERACION OP, PRODUCTO_CONTRATADO PC WITH (NOLOCK) "
        End If
        gs_Sql = gs_Sql & " where operacion_definida in "
        'los angeles
        If nagencia = 1 Then
            gs_Sql = gs_Sql & " (8583,8083,8587,8087,8089,8597,8097,8585,8085,8584,8094,8086,"
            '24 Horas  17-08-1998
            gs_Sql = gs_Sql & " 8096,8088,8588,8589,8590,8591,8592,"
            'Operaciones de Depositos y Retiros de TDD
            gs_Sql = gs_Sql & " 8552, 8553, 8052, 8053, 8054, 8056, 8057)"
            'NY
        ElseIf nagencia = 2 Then
            gs_Sql = gs_Sql & " (2583,2083,2587,2087,2089,2597,2097,2585,2085,2584,2094,2086,"
            '24 Horas  17-08-1998
            gs_Sql = gs_Sql & "  2096,2088,2588,2589,2590,2591,2592)"
            'Cayman
        ElseIf nagencia = 3 Then
            gs_Sql = gs_Sql & " (3583,3083,3587,3087,3089,3597,3097,3585,3085,3584,3094,3086,"
            '24 Horas  17-08-1998
            gs_Sql = gs_Sql & "  3096,3081,3091,3088,3588,3589,3590,3591,3592)"
            'Londres (todavía no se encuetran definidas en producción las operaciones_definidas)
        Else
            gs_Sql = gs_Sql & " (0)"
        End If
        gs_Sql = gs_Sql & " and status_operacion in (2,3,4,5) "

        'If Not IsMissing(bbva) Then
        If Not (bbva IsNot Nothing) Then
            If bbva = 1 Then  ' es bbva
                gs_Sql = gs_Sql & " and F.bbvab = 1 "   'Sólo operaciones realizadas con funcionarios que operan en suc no migradas
            Else
                gs_Sql = gs_Sql & " and OP.funcionario = F.funcionario "
                gs_Sql = gs_Sql & " and F.bbvab = 0 "   ' sólo operaciones realizadas con funcionarios que operan en suc no migradas
            End If
        End If
        gs_Sql = gs_Sql & " and fecha_operacion = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
        gs_Sql = gs_Sql & " and OP.producto_contratado = PC.producto_contratado "
        gs_Sql = gs_Sql & " and OP.operacion  not in ( "
        gs_Sql = gs_Sql & " select operacion "
        gs_Sql = gs_Sql & " from REPORTE_SWIFT RS WITH (NOLOCK), OPERACION_SWIFT OS WITH (NOLOCK), STATUS_REPORTE_SWIFT SR WITH (NOLOCK)"
        gs_Sql = gs_Sql & " where RS.no_rep_swift = OS.no_rep_swift "
        gs_Sql = gs_Sql & " and SR.status_reporte = RS.status_reporte "
        gs_Sql = gs_Sql & " and RS.agencia = " & nagencia
        gs_Sql = gs_Sql & " and fecha_reporte='" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "' ) "
        'gs_sql = gs_sql & " and PC.producto_contratado not in ("
        'gs_sql = gs_sql & " select producto_contratado"
        'gs_sql = gs_sql & " from  OPERACION o , OPERACION_DEFINIDA od"
        'gs_sql = gs_sql & " where od.operacion_definida = o.operacion_definida"
        'gs_sql = gs_sql & " and od.operacion_definida_global = 100"
        'gs_sql = gs_sql & " and status_operacion not in (2,3,4,5))"
        'dbExecQuery(gs_Sql)
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta Is Nothing Or dtRespConsulta.Rows.Count = 0 Then 'If dbError() <> 0 Then
            MsgBox("Ha ocurrido un error al guardar la operación.", vbCritical, "Error")
            OperacionesPorEnviarAgencia = False
        ElseIf dtRespConsulta.Rows(0).Item(0) > 0 Then 'ElseIf dbGetValue(0) > 0 Then
            OperacionesPorEnviarAgencia = True
        Else
            OperacionesPorEnviarAgencia = False
        End If
        'dbEndQuery
    End Function
    Private Sub cmdPorEnviar_Click(sender As Object, e As EventArgs) Handles cmdPorEnviar.Click
        'Modificación: BAGO-EDS-07/MZO/06. Sustitución de la constante "CATALOGOS" por la variable "DBCATALOGOS"

        On Error GoTo errPorEnviar
        Dim nOperaciones As Long
        Dim sExtra As String '* 12
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        'Limpiamos variables para correccion del nombre en pestañas del excel
        Erase arrnomOpEnLista
        nomOpEnLista = ""

        'Screen.MousePointer = vbHourglass
        If cmdPorEnviar.Text = "&Normal" Then
            ActualizaLista
            'Screen.MousePointer = vbDefault
            Exit Sub
        Else
            sExtra = ""
            'dgvOperacion1.DataSource = Nothing 'lstOperacion.Clear
            lstOperacion.Items.Clear()
            nOperaciones = 0
            lblTemas.Text = "No. Op:       Cuenta:      Agencia:      Definición:"
            optOpciones1.Visible = False
            optOpciones2.Visible = False
            chkUltimoRep.Visible = False
            dtpFecha.Enabled = False
            cboOperacion.Enabled = False
            'cboOperacion.ForeColor = QBColor(15)
            cmdPorEnviar.Text = "&Normal"
            'Si es agencia Houston calcula comisiones
            If cboAgencias.SelectedValue = 1 Then 'If cboAgencias.ItemData(cboAgencias.ListIndex) = 1 Then
                'Limpia tabla de temporal para comisiones
                'dbExecQuery("Delete TICKET..TMP_OPS_COMISIONES")
                'dbEndQuery
                gs_Sql = "Delete TICKET..TMP_OPS_COMISIONES"
                'gs_Sql = "" 'RACB quitar
                objDatasource.insertar(gs_Sql)
                'Calula comisiones
                gs_Sql = "INSERT INTO TICKET..TMP_OPS_COMISIONES"
                gs_Sql = gs_Sql & " Select producto_contratado, referencia, SUM(monto_operacion), 0 AS operacion"
                gs_Sql = gs_Sql & " FROM " & "TICKET" & "..OPERACION OP, " & "TICKET" & "..RETIRO_PME RPME,"
                gs_Sql = gs_Sql & " " & "TICKET" & "..OPERACION_DEFINIDA OD, " & "CATALOGOS" & "..AGENCIA AG"
                gs_Sql = gs_Sql & " WHERE OP.fecha_operacion = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
                gs_Sql = gs_Sql & " AND OP.operacion = RPME.operacion"
                gs_Sql = gs_Sql & " AND OP.operacion_definida = OD.operacion_definida"
                gs_Sql = gs_Sql & " AND OD.operacion_definida_global = 58"
                gs_Sql = gs_Sql & " AND OD.agencia = AG.agencia"
                gs_Sql = gs_Sql & " AND AG.agencia in (1, 3)"
                gs_Sql = gs_Sql & " GROUP BY producto_contratado, referencia"
                'dbExecQuery gs_Sql
                'dbEndQuery
                'gs_Sql = "" 'RACB quitar
                objDatasource.insertar(gs_Sql)
                'Actualiza operacion en tabla temporal de comisiones
                gs_Sql = "UPDATE TICKET..TMP_OPS_COMISIONES set operacion = OP.operacion"
                gs_Sql = gs_Sql & " FROM " & "TICKET" & "..OPERACION OP, " & "TICKET" & "..RETIRO_PME RPME, "
                gs_Sql = gs_Sql & " " & "TICKET" & "..OPERACION_DEFINIDA OD, " & "CATALOGOS" & "..AGENCIA AG"
                gs_Sql = gs_Sql & " WHERE OP.fecha_operacion = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
                gs_Sql = gs_Sql & " AND OP.operacion = RPME.operacion"
                gs_Sql = gs_Sql & " AND TMP_OPS_COMISIONES.producto_contratado = OP.producto_contratado"
                gs_Sql = gs_Sql & " AND TMP_OPS_COMISIONES.folio_extranjero = RPME.referencia"
                gs_Sql = gs_Sql & " AND OP.operacion_definida = OD.operacion_definida"
                gs_Sql = gs_Sql & " AND OD.operacion_definida_global = 58"
                gs_Sql = gs_Sql & " AND RPME.tipo_documento in (211, 215, 219, 223, 227, 231, 236)"
                gs_Sql = gs_Sql & " AND OD.agencia = AG.agencia"
                gs_Sql = gs_Sql & " AND AG.agencia in (1, 3)"
                'dbExecQuery gs_Sql
                'dbEndQuery
                'gs_Sql = "" 'RACB quitar
                objDatasource.insertar(gs_Sql)
            End If
            Select Case cboAgencias.SelectedValue 'cboAgencias.ItemData(cboAgencias.ListIndex)
                Case 1 'Houston
                    gs_Sql = "Select "
                    gs_Sql = gs_Sql & " OP.operacion, cuenta_cliente, descripcion_agencia, OD.descripcion_operacion_definida, "
                    gs_Sql = gs_Sql & " AG.agencia, tipo_reporte_swift, RS.desc_tipo_reporte_swift, status_operacion"
                    gs_Sql = gs_Sql & " From"
                    gs_Sql = gs_Sql & " OPERACION OP, PRODUCTO_CONTRATADO PC, OPERACION_DEFINIDA OD, " & "CATALOGOS" & "..AGENCIA AG, "
                    gs_Sql = gs_Sql & " TIPO_REPORTE_SWIFT RS"
                    gs_Sql = gs_Sql & " Where"
                    gs_Sql = gs_Sql & " OP.operacion_definida in "
                    gs_Sql = gs_Sql & "(8583,8065,8083,8587,8087,8597,8097,8585,8085,8089,8584,8094,8086,8096,8088,8588,8589,8590,8591,8592," &
                                  " 8552, 8553, 8052, 8053, 8054, 8056, 8057, 8059, 8559,8060)"
                    gs_Sql = gs_Sql & " and status_operacion in (2,3,4,5) and"
                    gs_Sql = gs_Sql & " fecha_operacion = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "' and OP.producto_contratado = PC.producto_contratado and"
                    gs_Sql = gs_Sql & " RS.operacion_definida_global = OD.operacion_definida_global and "
                    gs_Sql = gs_Sql & " PC.agencia = OD.agencia and "
                    gs_Sql = gs_Sql & " PC.agencia = RS.agencia and "
                    gs_Sql = gs_Sql & " AG.agencia = PC.agencia and OD.operacion_definida = OP.operacion_definida and OP.operacion not in"
                    gs_Sql = gs_Sql & " (Select operacion From REPORTE_SWIFT RS WITH (NOLOCK), OPERACION_SWIFT OS WITH (NOLOCK), STATUS_REPORTE_SWIFT SR WITH (NOLOCK) Where"
                    gs_Sql = gs_Sql & " RS.no_rep_swift = OS.no_rep_swift and SR.status_reporte = RS.status_reporte and fecha_reporte='" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "')"
                    gs_Sql = gs_Sql & " and  PC.producto_contratado not in "
                    gs_Sql = gs_Sql & " (select producto_contratado from  OPERACION o WITH (NOLOCK), OPERACION_DEFINIDA od WITH (NOLOCK)"
                    gs_Sql = gs_Sql & " where od.operacion_definida = o.operacion_definida and od.operacion_definida_global = 100"
                    gs_Sql = gs_Sql & " and status_operacion not in (2,3,4,5))  "
                    gs_Sql = gs_Sql & " UNION "
                    gs_Sql = gs_Sql & " Select "
                    gs_Sql = gs_Sql & " OP.operacion, cuenta_cliente, descripcion_agencia, OD.descripcion_operacion_definida, "
                    gs_Sql = gs_Sql & " AG.agencia, tipo_reporte_swift, RS.desc_tipo_reporte_swift, status_operacion"
                    gs_Sql = gs_Sql & " From"
                    gs_Sql = gs_Sql & " OPERACION OP, PRODUCTO_CONTRATADO PC, OPERACION_DEFINIDA OD, " & "CATALOGOS" & "..AGENCIA AG, "
                    gs_Sql = gs_Sql & " TIPO_REPORTE_SWIFT RS, TMP_OPS_COMISIONES TMOP"
                    gs_Sql = gs_Sql & " Where"
                    gs_Sql = gs_Sql & " OP.operacion_definida = 8058"
                    gs_Sql = gs_Sql & " and OP.operacion = TMOP.operacion"
                    gs_Sql = gs_Sql & " and status_operacion in (2,3,4,5)"
                    gs_Sql = gs_Sql & " and fecha_operacion = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "' and OP.producto_contratado = PC.producto_contratado and"
                    gs_Sql = gs_Sql & " RS.operacion_definida_global = OD.operacion_definida_global and "
                    gs_Sql = gs_Sql & " PC.agencia = OD.agencia and "
                    gs_Sql = gs_Sql & " PC.agencia = RS.agencia and "
                    gs_Sql = gs_Sql & " AG.agencia = PC.agencia and OD.operacion_definida = OP.operacion_definida and OP.operacion not in"
                    gs_Sql = gs_Sql & " (Select operacion From REPORTE_SWIFT RS WITH (NOLOCK), OPERACION_SWIFT OS WITH (NOLOCK), STATUS_REPORTE_SWIFT SR WITH (NOLOCK) Where"
                    gs_Sql = gs_Sql & " RS.no_rep_swift = OS.no_rep_swift and SR.status_reporte = RS.status_reporte and fecha_reporte='" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "')"
                    gs_Sql = gs_Sql & " and  PC.producto_contratado not in "
                    gs_Sql = gs_Sql & " (select producto_contratado from  OPERACION o WITH (NOLOCK), OPERACION_DEFINIDA od WITH (NOLOCK)"
                    gs_Sql = gs_Sql & " where od.operacion_definida = o.operacion_definida and od.operacion_definida_global = 100"
                    gs_Sql = gs_Sql & " and status_operacion not in (2,3,4,5))  "
                    'gs_Sql = gs_Sql & " Order By descripcion_agencia, OP.operacion"

                Case 3 'Cayman
                    gs_Sql = "Select "
                    gs_Sql = gs_Sql & " OP.operacion, cuenta_cliente, descripcion_agencia, OD.descripcion_operacion_definida, "
                    gs_Sql = gs_Sql & " AG.agencia, tipo_reporte_swift"
                    gs_Sql = gs_Sql & " From"
                    gs_Sql = gs_Sql & " OPERACION OP, PRODUCTO_CONTRATADO PC, OPERACION_DEFINIDA OD, " & "CATALOGOS" & "..AGENCIA AG, "
                    gs_Sql = gs_Sql & " TIPO_REPORTE_SWIFT RS"
                    gs_Sql = gs_Sql & " Where"
                    gs_Sql = gs_Sql & " OP.operacion_definida in "
                    gs_Sql = gs_Sql & "(3583,3065,3083,3587,3087,3597,3097,3089,3585,3085,3584,3094,3086,3096,3081,3091,3088,3588,3589,3590,3591,3592) "
                    gs_Sql = gs_Sql & " and status_operacion in (2,3,4,5) and"
                    gs_Sql = gs_Sql & " fecha_operacion = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "' and OP.producto_contratado = PC.producto_contratado and"
                    gs_Sql = gs_Sql & " RS.operacion_definida_global = OD.operacion_definida_global and "
                    gs_Sql = gs_Sql & " PC.agencia = OD.agencia and "
                    gs_Sql = gs_Sql & " PC.agencia = RS.agencia and "
                    gs_Sql = gs_Sql & " AG.agencia = PC.agencia and OD.operacion_definida = OP.operacion_definida and OP.operacion not in"
                    gs_Sql = gs_Sql & " (Select operacion From REPORTE_SWIFT RS WITH (NOLOCK), OPERACION_SWIFT OS WITH (NOLOCK), STATUS_REPORTE_SWIFT SR WITH (NOLOCK) Where"
                    gs_Sql = gs_Sql & " RS.no_rep_swift = OS.no_rep_swift and SR.status_reporte = RS.status_reporte and fecha_reporte='" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "')"
                    gs_Sql = gs_Sql & " and  PC.producto_contratado not in "
                    gs_Sql = gs_Sql & " (select producto_contratado from  OPERACION o WITH (NOLOCK), OPERACION_DEFINIDA od WITH (NOLOCK)"
                    gs_Sql = gs_Sql & " where od.operacion_definida = o.operacion_definida and od.operacion_definida_global = 100"
                    gs_Sql = gs_Sql & " and status_operacion not in (2,3,4,5))  "
                    'gs_Sql = gs_Sql & " Order By descripcion_agencia, OP.operacion"
            End Select
            'dbExecQuery gs_Sql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql & " Order By descripcion_agencia, OP.operacion")
            For Each row As DataRow In dtRespConsulta.Rows 'Do While Not IsdbError
                sExtra = row(2)
                lstOperacion.Items.Add("  " & row(0) & "     " & row(1) & "     " & sExtra & "  " & row(3) & "                                                   " & row(4) & "  " & row(5))
                nomOpEnLista = nomOpEnLista & row(3) & ", "
                nOperaciones = nOperaciones + 1
                'dbGetRecord
            Next 'Loop
            'dbEndQuery
            If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
                For Each row As DataRow In dtRespConsulta.Rows
                    nomOpEnLista = nomOpEnLista & dtRespConsulta.Rows(0).Item(3) & ", "
                Next
                nOperaciones = dtRespConsulta.Rows.Count
                Dim gs_Sql2 = "Select T1.operacion Operacion, T1.cuenta_cliente Cuenta,T1.descripcion_agencia Agencia, T1.descripcion_operacion_definida Definición From ("
                gs_Sql2 = gs_Sql2 & gs_Sql & ") T1 inner join STATUS_OPERACION SO on T1.status_operacion = SO.status_operacion Order By T1.descripcion_agencia, T1.operacion"
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql2)
                'dgvOperacion1.DataSource = dtRespConsulta
            End If
            If StrComp(nomOpEnLista, "", vbTextCompare) <> 0 Then
                nomOpEnLista = Mid(nomOpEnLista, 1, Len(nomOpEnLista) - 2)
                arrnomOpEnLista = Split(nomOpEnLista, ",")
                lblTotalOperaciones.Text = "Numero de operaciones por enviar:       " & nOperaciones
            End If
        End If
        mnContinua = 0
        Me.Refresh()
        'Screen.MousePointer = vbDefault
        Exit Sub
errPorEnviar:
        MsgBox(Err.Number & " - " & Err.Description, vbCritical, "Error.")
        'Screen.MousePointer = vbDefault
    End Sub
    '------------------------------------------------------------------------
    'Actualiza la lista de operaciones segun el caso de operacion y agencia
    '------------------------------------------------------------------------
    Private Sub ActualizaLista()
        Dim ln_Condicion As Long
        Dim ln_Segundo As Long
        Dim ln_Siguiente As Long
        Dim ln_Indice As Long
        Dim la_Buffer() As String
        Dim ls_Data1 As String
        Dim ls_Data2 As String
        Dim ls_Espacio As String
        'Screen.MousePointer = vbHourglass
        cmdPorEnviar.Text = "&Por Enviar"
        dtpFecha.Enabled = True
        cboAgencias.Enabled = True
        cboOperacion.Enabled = True
        'cboAgencias.ForeColor = QBColor(0)
        'cboOperacion.ForeColor = QBColor(0)
        'optOpciones1.Visible = True
        'optOpciones1.Visible = True
        'optOpciones2.Visible = True
        'chkUltimoRep.Visible = True
        'dgvOperacion1.DataSource = Nothing
        lstOperacion.Items.Clear()
        mnNumOps = 0
        If cboOperacion.SelectedIndex = -1 Then 'If cboOperacion.ListIndex = -1 Then
            'Screen.MousePointer = vbDefault
            Exit Sub
        End If
        mnOpIndice = cboOperacion.SelectedValue
        gs_Sql = "Select T1.operacion AS [No. Op.], T1.cuenta_cliente AS Cuenta, T2.no_reporte_dia AS Reporte, T2.descripcion_status_reporte AS Estatus From ("
        gs_Sql = gs_Sql & "Select OP.operacion, cuenta_cliente, od.agencia "
        gs_Sql = gs_Sql & " From OPERACION OP, PRODUCTO_CONTRATADO PC,"
        gs_Sql = gs_Sql & " OPERACION_DEFINIDA od, TIPO_REPORTE_SWIFT trs" '", CATALOGOS..Agencia AG"
        gs_Sql = gs_Sql & " Where OP.operacion_definida = od.operacion_definida"
        gs_Sql = gs_Sql & " and od.operacion_definida_global = trs.operacion_definida_global"
        gs_Sql = gs_Sql & " and od.agencia = trs.agencia"
        'gs_Sql = gs_Sql & " and od.agencia = AG.agencia"
        gs_Sql = gs_Sql & " and od.agencia = " & cboAgencias.SelectedValue 'cboAgencias.ItemData(cboAgencias.ListIndex)
        gs_Sql = gs_Sql & " and trs.tipo_reporte_swift = " & Val(mnOpIndice)
        gs_Sql = gs_Sql & " and status_operacion in (2,3,4,5) and fecha_operacion = '" & Format(dtpFecha.Value.Date, "yyyy-MM-dd") & "'" 'dtpFecha.Value.Date.Year & "-" & dtpFecha.Value.Date.Month & "-" & dtpFecha.Value.Date.Day 'InvierteFecha(dtpFecha) & "'"
        gs_Sql = gs_Sql & " and OP.producto_contratado = PC.producto_contratado "
        gs_Sql = gs_Sql & " and trs.tipo_reporte_swift not in (17,18)"
        gs_Sql = gs_Sql & " and PC.producto_contratado not in "
        gs_Sql = gs_Sql & " (Select producto_contratado from  OPERACION o , OPERACION_DEFINIDA od"
        gs_Sql = gs_Sql & " where od.operacion_definida = o.operacion_definida and od.operacion_definida_global = 100"
        gs_Sql = gs_Sql & " and status_operacion not in (2,3,4,5))) T1 inner join ("
        gs_Sql = gs_Sql & "Select operacion, no_reporte_dia, descripcion_status_reporte, RS.status_reporte"
        gs_Sql = gs_Sql & " From REPORTE_SWIFT RS, OPERACION_SWIFT OS, STATUS_REPORTE_SWIFT SR"
        gs_Sql = gs_Sql & " Where RS.no_rep_swift = OS.no_rep_swift and SR.status_reporte = RS.status_reporte and"
        gs_Sql = gs_Sql & " RS.tipo_reporte_swift not in (17,18) and "
        gs_Sql = gs_Sql & " fecha_reporte = '" & Format(dtpFecha.Value.Date, "yyyy-MM-dd") & "') T2 on T1.operacion = T2.operacion "
        gs_Sql = gs_Sql & " Order By T1.operacion"
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dgvOperacion1.DataSource = dtRespConsulta
        lblTemas.Text = "Operacion:             Cuenta:            Reporte:           Status:"
        '        cmdPorEnviar.Text = "&Por Enviar"
        '        dtpFecha.Enabled = True
        '        cboAgencias.Enabled = True
        '        cboOperacion.Enabled = True
        '        'cboAgencias.ForeColor = QBColor(0)
        '        'cboOperacion.ForeColor = QBColor(0)
        '        optOpciones1.Visible = True
        '        optOpciones1.Visible = True
        '        optOpciones2.Visible = True
        '        chkUltimoRep.Visible = True
        '        dgvOperacion.DataSource = Nothing
        '        mnNumOps = 0
        '        If cboOperacion.SelectedIndex = -1 Then 'If cboOperacion.ListIndex = -1 Then
        '            'Screen.MousePointer = vbDefault
        '            Exit Sub
        '        End If
        '        mnOpIndice = cboOperacion.SelectedValue 'cboOperacion.ItemData(cboOperacion.ListIndex)
        '        gs_Sql = "Select OP.operacion, cuenta_cliente"
        '        gs_Sql = gs_Sql & " From OPERACION OP, PRODUCTO_CONTRATADO PC,"
        '        gs_Sql = gs_Sql & " OPERACION_DEFINIDA od, TIPO_REPORTE_SWIFT trs"
        '        gs_Sql = gs_Sql & " Where OP.operacion_definida = od.operacion_definida"
        '        gs_Sql = gs_Sql & " and od.operacion_definida_global = trs.operacion_definida_global"
        '        gs_Sql = gs_Sql & " and od.agencia = trs.agencia"
        '        gs_Sql = gs_Sql & " and od.agencia = " & cboAgencias.SelectedValue 'cboAgencias.ItemData(cboAgencias.ListIndex)
        '        gs_Sql = gs_Sql & " and trs.tipo_reporte_swift = " & Val(mnOpIndice)
        '        gs_Sql = gs_Sql & " and status_operacion in (2,3,4,5) and fecha_operacion = '" & Format(dtpFecha.Value.Date, "yyyy-MM-dd") & "'" 'dtpFecha.Value.Date.Year & "-" & dtpFecha.Value.Date.Month & "-" & dtpFecha.Value.Date.Day 'InvierteFecha(dtpFecha) & "'"
        '        gs_Sql = gs_Sql & " and OP.producto_contratado = PC.producto_contratado "
        '        gs_Sql = gs_Sql & " and trs.tipo_reporte_swift not in (17,18)"
        '        gs_Sql = gs_Sql & " and PC.producto_contratado not in "
        '        gs_Sql = gs_Sql & " (Select producto_contratado from  OPERACION o , OPERACION_DEFINIDA od"
        '        gs_Sql = gs_Sql & " where od.operacion_definida = o.operacion_definida and od.operacion_definida_global = 100"
        '        gs_Sql = gs_Sql & " and status_operacion not in (2,3,4,5))"
        '        gs_Sql = gs_Sql & " Order By OP.operacion "
        '        ' Busqueda de operaciones efectuadas a la fecha
        '        'dbExecQuery gs_Sql
        '        'dbGetRecord
        '        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        '        ln_Condicion = 0
        '        'Do While dbError() = 0
        '        '    ln_Condicion = ln_Condicion + 1
        '        '    dbGetRecord
        '        'Loop
        '        'dbEndQuery
        '        ReDim la_Buffer(ln_Condicion * 2)
        '        ' Llena el arreglo con los datos
        '        'dbExecQuery gs_Sql
        '        For ln_Indice = 0 To (ln_Condicion - 1) * 2 Step 2
        '            'dbGetRecord
        '            la_Buffer(ln_Indice) = Format(dtRespConsulta.Rows(ln_Indice).Item(0), "0000000") 'Format(dbGetValue(0), "0000000")
        '            la_Buffer(ln_Indice + 1) = dtRespConsulta.Rows(ln_Indice).Item(1) 'dbGetValue(1)
        '        Next ln_Indice
        '        'dbEndQuery
        '        gs_Sql = "Select operacion,"
        '        gs_Sql = gs_Sql & " no_reporte_dia, descripcion_status_reporte, RS.status_reporte"
        '        gs_Sql = gs_Sql & " From REPORTE_SWIFT RS, OPERACION_SWIFT OS, STATUS_REPORTE_SWIFT SR"
        '        gs_Sql = gs_Sql & " Where RS.no_rep_swift = OS.no_rep_swift and SR.status_reporte = RS.status_reporte and"
        '        gs_Sql = gs_Sql & " RS.tipo_reporte_swift not in (17,18) and "
        '        gs_Sql = gs_Sql & " fecha_reporte = '" & Format(dtpFecha.Value.Date, "yyyy-MM-dd") & "'"
        '        gs_Sql = gs_Sql & " Order By operacion"
        '        ' Busca las operaciones en swift
        '        'dbExecQuery gs_Sql
        '        'dbGetRecord
        '        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        '        ln_Segundo = 0
        '        ' Cuenta los resultados obtenidos
        '        'Do While dbError() = 0
        '        '    ln_Segundo = ln_Segundo + 1
        '        '    dbGetRecord
        '        'Loop
        '        ln_Segundo = dtRespConsulta.Rows.Count + 1
        '        dgvOperacion.DataSource = dtRespConsulta
        '        'dbEndQuery
        '        'dbExecQuery gs_Sql
        '        'dbGetRecord
        '        ln_Indice = 0
        '        ln_Siguiente = 0
        '        Do While ln_Indice < (ln_Condicion * 2)
        '            ls_Data1 = la_Buffer(ln_Indice)
        '            ls_Data2 = dtRespConsulta.Rows(ln_Indice).Item(0)
        '            ' Compara con los datos obtenidos
        'Compara_Datos:
        '            If Val(ls_Data1) = Val(ls_Data2) Then
        '                ls_Espacio = "    "
        '                If Len(la_Buffer(ln_Indice)) = 5 Then ls_Espacio = "  "
        '                'lstOperacion.AddItem ls_Espacio & la_Buffer(ln_Indice) & "              " & la_Buffer(ln_Indice + 1) & "                    " & dbGetValue(1) & "                " & dbGetValue(2) & "                                   " & dbGetValue(3)
        '                dgvOperacion.Rows.Add(dtRespConsulta.Rows(ln_Indice))
        '                ln_Indice = ln_Indice + 2
        '                'dbGetRecord
        '                ln_Siguiente = ln_Siguiente + 1
        '            Else
        '                If Val(ls_Data1) > Val(ls_Data2) Then
        '                    'dbGetRecord
        '                    ln_Siguiente = ln_Siguiente + 1
        '                    ls_Data2 = dtRespConsulta.Rows(ln_Indice).Item(0)
        '                    If ln_Siguiente > ln_Segundo Then
        '                        GoTo TerminaLlenado
        '                    Else
        '                        GoTo Compara_Datos
        '                    End If
        '                End If
        '                If Val(ls_Data1) < Val(ls_Data2) Then
        'TerminaLlenado:
        '                    'lstOperacion.AddItem "    " & la_Buffer(ln_Indice) & "              " & la_Buffer(ln_Indice + 1)
        '                    dgvOperacion.Rows.Add(dtRespConsulta.Rows(ln_Indice))
        '                    ln_Indice = ln_Indice + 2
        '                    mnNumOps = mnNumOps + 1
        '                End If
        '            End If
        '        Loop
        '        'dbEndQuery
        If True Then 'If objLibreria.Permiso("PENVIOMT198") Then
            If dtpFecha.Value.Date = gs_FechaHoy Then 'If InvierteFecha(dtpFecha) = gs_FechaHoy Then
                If CDate(gs_HoraSistema) < CDate("12:00PM") Then
                    optOpciones2.Enabled = False
                Else
                    optOpciones2.Enabled = True
                End If
            End If
        End If
        If Trim(cboAgencias.SelectedValue) = 3 Then
            optOpciones2.Enabled = False
        End If
        lblTotalOperaciones.Text = "Numero de operaciones por enviar:     " & mnNumOps
        'ReDim la_Buffer(dgvOperacion1.Rows.Count)
        ' Ordena la lista (verifica condicion de reenvio)
        'ln_Indice = 0
        'ln_Segundo = 0
        'ln_Condicion = mnNumOps
        'Do While ln_Indice < (dgvOperacion.Rows.Count)
        '    ls_Data1 = Trim(Mid(Trim(dgvOperacion.Rows(ln_Indice)), 40, 10))
        '    If (mnReenvio = 0 And mnImpresion = 0) Then
        '        If ls_Data1 = "" Then
        '            la_Buffer(ln_Segundo) = lstOperacion.List(ln_Indice)
        '            ln_Segundo = ln_Segundo + 1
        '            ln_Indice = ln_Indice + 1
        '        Else
        '            la_Buffer(ln_Condicion) = lstOperacion.List(ln_Indice)
        '            ln_Condicion = ln_Condicion + 1
        '            ln_Indice = ln_Indice + 1
        '        End If
        '    End If
        '    If mnReenvio = 1 Then
        '        If Len(Trim(lstOperacion.List(ln_Indice))) > 50 Then
        '            ls_Data2 = Right(Trim(lstOperacion.List(ln_Indice)), 1)
        '            ' Busca todas las operaciones con status en 4 o 5
        '            If ls_Data2 = 4 Or ls_Data2 = 5 Then
        '                la_Buffer(ln_Segundo) = lstOperacion.List(ln_Indice)
        '                ln_Segundo = ln_Segundo + 1
        '                ln_Indice = ln_Indice + 1
        '            Else
        '                ln_Indice = ln_Indice + 1
        '            End If
        '        Else
        '            ln_Indice = ln_Indice + 1
        '        End If
        '    End If
        '    If mnImpresion = 1 Then
        '        If Len(Trim(lstOperacion.List(ln_Indice))) > 50 Then
        '            ls_Data2 = Right(Trim(lstOperacion.List(ln_Indice)), 1)
        '            If ls_Data2 = 2 Or ls_Data2 = 3 Or ls_Data2 = 4 Or ls_Data2 = 5 Then
        '                la_Buffer(ln_Segundo) = lstOperacion.List(ln_Indice)
        '                ln_Segundo = ln_Segundo + 1
        '                ln_Indice = ln_Indice + 1
        '            Else
        '                ln_Indice = ln_Indice + 1
        '            End If
        '        Else
        '            ln_Indice = ln_Indice + 1
        '        End If
        '    End If
        'Loop
        If (mnReenvio = 0 And mnImpresion = 0) Then
            'ln_Condicion = dgvOperacion1.Rows.Count - 1
        Else
            ln_Condicion = ln_Segundo - 1
        End If
        'dgvOperacion.DataSource = Nothing
        For ln_Indice = 0 To ln_Condicion
            'lstOperacion.AddItem la_Buffer(ln_Indice)
        Next ln_Indice
        'lstOperacion.Refresh
        'Screen.MousePointer = vbDefault
    End Sub
    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        cmdAceptar.Enabled = False
        pbMT198.Visible = True
        pbMT198.Maximum = 10
        Dim nRepDia As Long
        Dim nMaxOp As Long
        Dim sOperacion As String
        Dim nOperaciones As Long
        Dim nOperacionesInserta As Long
        Dim nVarTipo As Byte
        Dim ln_Indice As Long
        Dim Arreglo() As Long
        Dim nNumRepSwift As Long
        Dim tipoOperacion As String

        Dim rptDoc As New ReportDocument
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""
        Dim LsFormula As String = ""
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        pbMT198.Value = 1
        bEncabezados = True
        'Se disparan lo eventos de busqueda de operaciones
        'para evitar que se dupliquen el envio de operaciones
        If cmdPorEnviar.Text = "&Por Enviar" Then
            If mnInicia <> 0 Then
                ActualizaLista()
            End If
        Else
            cmdPorEnviar.Text = "&Por Enviar"
            lstOperacion.Items.Clear()
            Call cmdPorEnviar_Click(sender, e)
            cmdPorEnviar.Text = "&Normal"
        End If

        gs_Sql = "select max(tipo_reporte_swift) from TIPO_REPORTE_SWIFT WITH (NOLOCK)"
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If Not dbError() Then
            nNumRepSwift = Val(dtRespConsulta.Rows(0).ItemArray(0))
        Else
            'dbEndQuery
            MsgBox("Error comuniquese con el Departamento de Sistemas!", vbInformation, "Aviso")
            Exit Sub
        End If
        'dbEndQuery
        If lstOperacion.Items.Count = 0 Then
            MsgBox("No hay operaciones por procesar!", vbInformation, "Aviso")
            pbMT198.Value = 10
            pbMT198.Visible = False
            pbMT198.Value = 0
            Exit Sub
        End If
        pbMT198.Value = 2
        'Screen.MousePointer = vbHourglass
        mnContinua = 0
        If cmdPorEnviar.Text = "&Por Enviar" Then
            gs_Sql = "SELECT MAX(no_reporte_dia) + 1"
            gs_Sql = gs_Sql & " FROM REPORTE_SWIFT WITH (NOLOCK) WHERE"
            gs_Sql = gs_Sql & " fecha_reporte='" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "' AND"
            gs_Sql = gs_Sql & " agencia=" & cboAgencias.SelectedValue & " AND" 'cboAgencias.ItemData(cboAgencias.ListIndex) & " AND"
            gs_Sql = gs_Sql & " tipo_reporte_swift = " & cboOperacion.SelectedValue 'cboOperacion.ItemData(cboOperacion.ListIndex)
            'dbExecQuery gs_Sql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbGetValue(0) = "" Then
                nRepDia = Val(dtRespConsulta.Rows(0).ItemArray(0))
            Else
                nRepDia = 1
            End If
            'dbEndQuery
            ' Impresion y envio
            If optOpciones0.Checked Then
                If mnNumOps = 0 Then
                    MsgBox("No hay operaciones por imprimir y enviar!", vbInformation, "Aviso")
                    'Screen.MousePointer = vbDefault
                    Exit Sub
                End If
                'Genero la instancia de Excel
                If generaInstancia(cboAgencias.SelectedValue) Then
                    'dbBeginTran
                    objDatasource.IniciaTransaccion()
                    gs_Sql = "INSERT INTO TICKET..REPORTE_SWIFT"
                    gs_Sql = gs_Sql & " (fecha_reporte, agencia, no_reporte_dia, tipo_reporte_swift, no_registros, status_reporte, reenvio, ultimo_reporte, usuario)"
                    gs_Sql = gs_Sql & " VALUES ('"
                    gs_Sql = gs_Sql & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "', "
                    gs_Sql = gs_Sql & cboAgencias.SelectedValue & ", "
                    gs_Sql = gs_Sql & nRepDia & ", "
                    gs_Sql = gs_Sql & cboOperacion.SelectedValue & ", "
                    gs_Sql = gs_Sql & mnNumOps & ", "
                    'Cayman
                    If Trim(cboAgencias.SelectedValue) = 3 Then
                        gs_Sql = gs_Sql & "4, 1, "
                        'Cualquier otra agencia
                    Else
                        gs_Sql = gs_Sql & "1, 0, "
                    End If
                    gs_Sql = gs_Sql & chkUltimoRep.Checked & ","
                    gs_Sql = gs_Sql & userId & ")"
                    'dbExecQuery gs_Sql
                    If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then 'If dbError Then
                        'dbRollback
                        objDatasource.RollbackTransaccion()
                        MsgBox("Ocurrio un error al intentar modificar la base de datos," & Chr(13) & " verifique que la conexión a la red no tenga problemas.", 16, "Aviso")
                        'dbEndQuery
                        'Screen.MousePointer = vbDefault
                        Exit Sub
                    End If
                    'dbEndQuery
                    'dbExecQuery("SELECT MAX(no_rep_swift) FROM REPORTE_SWIFT")
                    'dbGetRecord
                    objDatasource.EjecutaComandoTransaccion("Select MAX(no_rep_swift) FROM REPORTE_SWIFT WITH (NOLOCK)")
                    If iValorTransaccion = 0 Then 'If dbGetValue(0) = "" Then
                        mnRepSwift = 1
                    Else
                        mnRepSwift = Val(iValorTransaccion)
                    End If
                    'dbEndQuery
                    nMaxOp = 0
                    If mnNumOps > 40 Then
                        mnNumOps = 40
                        MsgBox("El bloque contenía más de 40 operaciones, solamente" & Chr(13) & " se enviarán en este swift 40 operaciones, vuelva a enviar el resto .", 16, "Aviso")
                    End If
                    If poneEncabezados(cboOperacion.Text) Then
                        For nMaxOp = 0 To mnNumOps - 1
                            sOperacion = Trim(Microsoft.VisualBasic.Left(Trim(lstOperacion.Items(nMaxOp)), 7))
                            If insertaOpExcel(sOperacion) Then
                                gs_Sql = "INSERT INTO TICKET..OPERACION_SWIFT"
                                gs_Sql = gs_Sql & " (no_rep_swift, operacion) VALUES ("
                                gs_Sql = gs_Sql & mnRepSwift & ", " & sOperacion & ")"
                                'dbExecQuery gs_Sql
                                If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then 'If dbError Then
                                    'dbRollback
                                    objDatasource.RollbackTransaccion()
                                    MsgBox("Ocurrio un error al intentar modificar la base de datos," & Chr(13) & " verifique que la conexión a la red no tenga problemas.", 16, "Aviso")
                                    'dbEndQuery
                                    'Screen.MousePointer = vbDefault
                                    Exit Sub
                                End If
                                'dbEndQuery
                            End If
                        Next nMaxOp
                    End If
                    'dbCommit
                    objDatasource.CommitTransaccion()
                    pbMT198.Value = 3
                    'Call terminaExcel
                    'Call muestraExcel
                    If chkImprimeReporte.Checked Then
                        'CrystalRep.WindowParentHandle = MDIValida.hwnd
                        'CrystalRep.WindowState = crptMinimized
                        'CrystalRep.Formulas(0) = "Operacion = '" & cboOperacion.List(cboOperacion.ListIndex) & "'"
                        'CrystalRep.Formulas(1) = "Agencia = '" & cboAgencias.List(cboAgencias.ListIndex) & "'"
                        'CrystalRep.Formulas(2) = "Fecha = '" & Trim(txtFecha) & "'"
                        'CrystalRep.Formulas(3) = "Hora = '" & Format(Time, "hh:mm") & "'"
                        'CrystalRep.SelectionFormula = "{REPORTE_SWIFT.no_rep_swift} = " & mnRepSwift & " and "
                        'CrystalRep.SelectionFormula = CrystalRep.SelectionFormula & "{REPORTE_SWIFT.tipo_reporte_swift}= " & cboOperacion.SelectedValue 'cboOperacion.ItemData(cboOperacion.ListIndex)
                        'CrystalRep.ReportFileName = GPATH & "\MT198 enviar_2.RPT"
                        'MuestraVentanaReporte CrystalRep
                        lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
                        lsReporte = lsRutaFolder & "MT198 enviar_2.RPT" '& lsAmbiente & ".rpt"
                        rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                        objLibreria.logonBDreporte(rptDoc, 1)
                        rptDoc.DataDefinition.FormulaFields.Item("Operacion").Text = "'" & DirectCast(cboOperacion.SelectedItem, System.Data.DataRowView).Row.ItemArray(0) & " '" 'cboOperacion.List(cboOperacion.ListIndex) & "'"
                        rptDoc.DataDefinition.FormulaFields.Item("Agencia").Text = "'" & DirectCast(cboAgencias.SelectedItem, System.Data.DataRowView).Row.ItemArray(0) & " '" 'cboAgencias.List(cboAgencias.ListIndex) & "'"
                        rptDoc.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & Trim(Format(dtpFecha.Value.Date, "yyyy-MM-dd")) & "'"
                        rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Format(Now.TimeOfDay.ToString.Substring(0, 5)) & "'"
                        LsFormula = "{REPORTE_SWIFT.no_rep_swift} = " & mnRepSwift & " and "
                        LsFormula = LsFormula & "{REPORTE_SWIFT.tipo_reporte_swift}= " & cboOperacion.SelectedValue 'cboOperacion.ItemData(cboOperacion.ListIndex)
                        rptDoc.RecordSelectionFormula = LsFormula
                        opcionReporte = 16
                        RepOperativa.reporteOFAC = rptDoc
                        RepOperativa.ShowDialog()
                    End If
                    mnContinua = 1
                    'Instancia de excel
                End If
                'Termina Imprimir y Enviar
                ' Impresion
            ElseIf optOpciones1.Checked Then
                If lstOperacion.Items.Count = 0 Then
                    'Screen.MousePointer = vbDefault
                    MsgBox("No hay operaciones por imprimir!", vbInformation, "Aviso")
                    Exit Sub
                End If
                'CrystalRep.WindowParentHandle = MDIValida.hwnd
                'CrystalRep.WindowState = crptMinimized
                'CrystalRep.Formulas(0) = "Operacion = '" & cboOperacion.List(cboOperacion.ListIndex) & "'"
                'CrystalRep.Formulas(1) = "Agencia = '" & cboAgencias.List(cboAgencias.ListIndex) & "'"
                'CrystalRep.Formulas(2) = "Fecha = '" & Trim(txtFecha) & "'"
                'CrystalRep.Formulas(3) = "Hora = '" & Format(Time, "hh:mm") & "'"
                'CrystalRep.SelectionFormula = "{REPORTE_SWIFT.status_reporte} in [2,3,4,5] and "
                'CrystalRep.SelectionFormula = CrystalRep.SelectionFormula & "{REPORTE_SWIFT.fecha_reporte}=Date (" & Format(txtFecha, "yyyy,mm,dd") & ") and "
                'CrystalRep.SelectionFormula = CrystalRep.SelectionFormula & "{REPORTE_SWIFT.agencia}= " & cboAgencias.SelectedValue & " and "
                'CrystalRep.SelectionFormula = CrystalRep.SelectionFormula & "{REPORTE_SWIFT.tipo_reporte_swift}= " & cboOperacion.SelectedValue 'cboOperacion.ItemData(cboOperacion.ListIndex)
                'CrystalRep.ReportFileName = GPATH & "\MT198 imprimir_2.RPT"
                'MuestraVentanaReporte CrystalRep
                lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
                lsReporte = lsRutaFolder & "MT198 imprimir_2.RPT" '& lsAmbiente & ".rpt"
                rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                objLibreria.logonBDreporte(rptDoc, 1)
                rptDoc.DataDefinition.FormulaFields.Item("Operacion").Text = "'" & DirectCast(cboOperacion.SelectedItem, System.Data.DataRowView).Row.ItemArray(0) & "'"
                rptDoc.DataDefinition.FormulaFields.Item("Agencia").Text = "'" & DirectCast(cboAgencias.SelectedItem, System.Data.DataRowView).Row.ItemArray(0) & "'"
                rptDoc.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & Trim(Format(dtpFecha.Value.Date, "yyyy-MM-dd")) & "'"
                rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Format(Now.TimeOfDay.ToString.Substring(0, 5)) & "'"
                LsFormula = "{REPORTE_SWIFT.status_reporte} in [2,3,4,5] and "
                LsFormula = LsFormula & "{REPORTE_SWIFT.fecha_reporte}=Date (" & dtpFecha.Value.Date.Year & ", " & dtpFecha.Value.Date.Month & ", " & dtpFecha.Value.Date.Day & ") and "
                LsFormula = LsFormula & "{REPORTE_SWIFT.agencia}= " & cboAgencias.SelectedValue & " and " 'cboAgencias.ItemData(cboAgencias.ListIndex) & " and "
                LsFormula = LsFormula & "{REPORTE_SWIFT.tipo_reporte_swift}= " & cboOperacion.SelectedValue 'cboOperacion.ItemData(cboOperacion.ListIndex)
                rptDoc.RecordSelectionFormula = LsFormula
                opcionReporte = 16
                RepOperativa.reporteOFAC = rptDoc
                RepOperativa.ShowDialog()
                'Termina Imprimir
                ' Reenvio
                pbMT198.Value = 4
            ElseIf optOpciones2.Checked Then
                If lstOperacion.Items.Count = 0 Then
                    'Screen.MousePointer = vbDefault
                    MsgBox("No hay operaciones por reenviar!", vbInformation, "Aviso")
                    Exit Sub
                End If
                'dbBeginTran
                objDatasource.IniciaTransaccion()
                pbMT198.Value = 5
                For nMaxOp = 0 To lstOperacion.Items.Count - 1
                    sOperacion = Trim(Microsoft.VisualBasic.Left(Trim(lstOperacion.Items(nMaxOp)), 10))
                    gs_Sql = "UPDATE TICKET..REPORTE_SWIFT SET status_reporte=2, reenvio=1"
                    gs_Sql = gs_Sql & " WHERE reenvio=0 and no_rep_swift in (select no_rep_swift"
                    gs_Sql = gs_Sql & " FROM OPERACION_SWIFT WITH (NOLOCK) WHERE operacion= " & sOperacion & ") and"
                    gs_Sql = gs_Sql & " status_reporte in (4,5) and fecha_reporte='" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
                    'dbExecQuery gs_Sql
                    If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then 'If dbError Then
                        MsgBox("Ocurrio un error al intentar modificar la base de datos," & Chr(13) & " verifique que la conexión a la red no tenga problemas.", 16, "Aviso")
                        'dbRollback
                        objDatasource.RollbackTransaccion()
                        'dbEndQuery
                        'Screen.MousePointer = vbDefault
                        Exit Sub
                    End If
                    'dbEndQuery
                Next nMaxOp
                'dbCommit
                objDatasource.CommitTransaccion()
                'CrystalRep.WindowParentHandle = MDIValida.hwnd
                'CrystalRep.WindowState = crptMinimized
                'CrystalRep.Formulas(0) = "Operacion = '" & cboOperacion.List(cboOperacion.ListIndex) & "'"
                'CrystalRep.Formulas(1) = "Agencia = '" & cboAgencias.List(cboAgencias.ListIndex) & "'"
                'CrystalRep.Formulas(2) = "Fecha = '" & Trim(txtFecha) & "'"
                'CrystalRep.Formulas(3) = "Hora = '" & Format(Time, "hh:mm") & "'"
                'CrystalRep.SelectionFormula = "{REPORTE_SWIFT.status_reporte} = 2 and {REPORTE_SWIFT.reenvio} = 1 and "
                'CrystalRep.SelectionFormula = CrystalRep.SelectionFormula & "{REPORTE_SWIFT.agencia}=" & cboAgencias.SelectedValue & " and "
                'CrystalRep.SelectionFormula = CrystalRep.SelectionFormula & "{REPORTE_SWIFT.fecha_reporte}=Date (" & Format(InvierteFecha(gs_FechaHoy), "yyyy,mm,dd") & ") and "
                'CrystalRep.SelectionFormula = CrystalRep.SelectionFormula & "{REPORTE_SWIFT.tipo_reporte_swift}= " & cboOperacion.SelectedValue 'cboOperacion.ItemData(cboOperacion.ListIndex)
                'CrystalRep.ReportFileName = GPATH & "\MT198 reenvio_2.RPT"
                'MuestraVentanaReporte CrystalRep
                lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
                lsReporte = lsRutaFolder & "MT198 reenvio_2.RPT" '& lsAmbiente & ".rpt"
                rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                objLibreria.logonBDreporte(rptDoc, 1)
                rptDoc.DataDefinition.FormulaFields.Item("Operacion").Text = "'" & DirectCast(cboOperacion.SelectedItem, System.Data.DataRowView).Row.ItemArray(0) & "'"
                rptDoc.DataDefinition.FormulaFields.Item("Agencia").Text = "'" & DirectCast(cboAgencias.SelectedItem, System.Data.DataRowView).Row.ItemArray(0) & "'"
                rptDoc.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & Trim(Format(dtpFecha.Value.Date, "yyyy-MM-dd")) & "'"
                rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Format(Now.TimeOfDay.ToString.Substring(0, 5)) & "'"
                LsFormula = "{REPORTE_SWIFT.status_reporte} = 2 and {REPORTE_SWIFT.reenvio} = 1 and "
                LsFormula = LsFormula & "{REPORTE_SWIFT.agencia}=" & cboAgencias.SelectedValue & " and " 'cboAgencias.ItemData(cboAgencias.ListIndex) & " and "
                LsFormula = LsFormula & "{REPORTE_SWIFT.fecha_reporte}=Date (" & dtpFecha.Value.Date.Year & ", " & dtpFecha.Value.Date.Month & ", " & dtpFecha.Value.Date.Day & ") and "
                LsFormula = LsFormula & "{REPORTE_SWIFT.tipo_reporte_swift}= " & cboOperacion.SelectedValue 'cboOperacion.ItemData(cboOperacion.ListIndex)
                rptDoc.RecordSelectionFormula = LsFormula
                opcionReporte = 16
                RepOperativa.reporteOFAC = rptDoc
                RepOperativa.ShowDialog()
                'Termina Reenviar
            End If
            ' Si cmdPorEnviar = "Normal" entonces imprime todas las operaciones por enviar
        Else
            gs_Sql = MsgBox("¿Desea enviar todo el bloque de operaciones?", vbOKCancel + vbQuestion, "Aviso")
            If gs_Sql = 2 Then
                'Screen.MousePointer = vbDefault
                Exit Sub
            End If
            pbMT198.Value = 6
            nMaxOp = Val(Microsoft.VisualBasic.Right(lblTotalOperaciones.Text, 3))
            If generaInstancia(cboAgencias.SelectedValue) Then
                Do While nMaxOp <> 0
                    ' Los posibles tipos de operaciones
                    For nVarTipo = 1 To nNumRepSwift
                        ReDim Arreglo(nMaxOp)
                        gs_Sql = "SELECT MAX(no_reporte_dia) + 1"
                        gs_Sql = gs_Sql & " FROM REPORTE_SWIFT WITH (NOLOCK) WHERE"
                        gs_Sql = gs_Sql & " fecha_reporte='" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "' AND"
                        gs_Sql = gs_Sql & " agencia = " & cboAgencias.SelectedValue & " and"
                        gs_Sql = gs_Sql & " tipo_reporte_swift = " & nVarTipo
                        'dbExecQuery gs_Sql
                        'dbGetRecord
                        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                        If dtRespConsulta.Rows(0).Item(0).ToString() = "" Then 'If dbGetValue(0) = "" Then
                            nRepDia = 1
                        Else
                            nRepDia = Val(dtRespConsulta.Rows(0).Item(0))
                        End If
                        'dbEndQuery
                        ' Busca las operaciones que cumplan las condiciones de la combinacion correspondiente
                        nOperaciones = 0
                        For ln_Indice = 0 To lstOperacion.Items.Count - 1
                            If Val(Microsoft.VisualBasic.Right(lstOperacion.Items(ln_Indice), 2)) = nVarTipo Then
                                Arreglo(nOperaciones) = ln_Indice
                                tipoOperacion = ""
                                tipoOperacion = Trim(arrnomOpEnLista(ln_Indice))
                                nOperaciones = nOperaciones + 1
                            End If
                        Next ln_Indice
                        If nOperaciones > 40 Then
                            nOperacionesInserta = 40
                            MsgBox("El bloque contenía más de 40 operaciones, solamente" & Chr(13) & " se enviarán en este swift 40 operaciones, vuelva a enviar el resto .", 16, "Aviso")
                        Else
                            nOperacionesInserta = nOperaciones
                        End If
                        If nOperacionesInserta > 0 Then
                            'dbBeginTran
                            objDatasource.IniciaTransaccion()
                            pbMT198.Value = 7
                            gs_Sql = "INSERT INTO TICKET..REPORTE_SWIFT"
                            gs_Sql = gs_Sql & " (fecha_reporte, agencia, no_reporte_dia, tipo_reporte_swift,"
                            gs_Sql = gs_Sql & " no_registros, status_reporte, reenvio, ultimo_reporte, usuario)"
                            gs_Sql = gs_Sql & " VALUES ('"
                            gs_Sql = gs_Sql & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "', "
                            gs_Sql = gs_Sql & cboAgencias.SelectedValue & ", "
                            gs_Sql = gs_Sql & nRepDia & ", "
                            gs_Sql = gs_Sql & nVarTipo & ", "
                            gs_Sql = gs_Sql & nOperacionesInserta & ", "
                            If cboAgencias.SelectedValue = 3 Then 'Cayman
                                gs_Sql = gs_Sql & "4, 1, "
                            Else
                                gs_Sql = gs_Sql & "2, 0, "
                            End If
                            gs_Sql = gs_Sql & Convert.ToInt32(chkUltimoRep.Checked) & ","
                            gs_Sql = gs_Sql & userId & ")"
                            ' Actualiza la tabla de Reporte Swift
                            'dbExecQuery gs_Sql
                            If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then 'If dbError Then
                                'dbRollback
                                objDatasource.RollbackTransaccion()
                                MsgBox("Ocurrio un error al intentar modificar la base de datos," & Chr(13) & " verifique que la conexión a la red no tenga problemas.", 16, "Aviso")
                                'dbEndQuery
                                'Screen.MousePointer = vbDefault
                                Exit Sub
                            End If
                            'dbEndQuery
                            objDatasource.EjecutaComandoTransaccion("Select MAX(no_rep_swift) FROM REPORTE_SWIFT WITH (NOLOCK)") 'dbExecQuery("SELECT MAX(no_rep_swift) FROM REPORTE_SWIFT")
                            '' Selecciona el ultimo numero del reporte swift
                            'dbGetRecord
                            If iValorTransaccion = 0 Then 'If dbGetValue(0) = "" Then
                                mnRepSwift = 1
                            Else
                                mnRepSwift = Val(iValorTransaccion)
                            End If
                            'dbEndQuery
                            pbMT198.Value = 8
                            If poneEncabezados(tipoOperacion) Then
                                For ln_Indice = 0 To nOperacionesInserta - 1

                                    sOperacion = Trim(Microsoft.VisualBasic.Left(Trim(lstOperacion.Items(Arreglo(ln_Indice))), 7))
                                    If insertaOpExcel(sOperacion) Then
                                        gs_Sql = "INSERT INTO TICKET..OPERACION_SWIFT"
                                        gs_Sql = gs_Sql & " (no_rep_swift, operacion) VALUES ("
                                        gs_Sql = gs_Sql & mnRepSwift & ", " & sOperacion & ")"
                                        ' Inserta cada operacion que concuerde con la descripcion en la operacion_swift
                                        'dbExecQuery gs_Sql
                                        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then 'If dbError Then
                                            'dbRollback
                                            objDatasource.RollbackTransaccion()
                                            MsgBox("Ocurrio un error al intentar modificar la base de datos," & Chr(13) & " verifique que la conexión a la red no tenga problemas.", 16, "Aviso")
                                            'dbEndQuery
                                            'Screen.MousePointer = vbDefault
                                            Exit Sub
                                        End If
                                        'dbEndQuery
                                    End If
                                Next ln_Indice
                            End If
                            'dbCommit
                            objDatasource.CommitTransaccion()
                            pbMT198.Value = 9
                            If chkImprimeReporte.Checked Then
                                'CrystalRep.WindowParentHandle = MDIValida.hwnd
                                'CrystalRep.WindowState = crptMinimized
                                'sOperacion = Trim(Right(lstOperacion.List(Arreglo(0)), Len(Trim(lstOperacion.List(Arreglo(0)))) - 35))
                                'sOperacion = Trim(Left(sOperacion, 40))
                                'CrystalRep.Formulas(0) = "Operacion = '" & sOperacion & "'"
                                'CrystalRep.Formulas(1) = "Agencia = '" & Trim(Left(Right(lstOperacion.List(Arreglo(0)), Len(lstOperacion.List(Arreglo(0))) - 22), 13)) & "'"
                                'CrystalRep.Formulas(2) = "Fecha = '" & Trim(txtFecha) & "'"
                                'CrystalRep.Formulas(3) = "Hora = '" & Format(Time, "hh:mm") & "'"
                                'CrystalRep.SelectionFormula = "{REPORTE_SWIFT.no_rep_swift} = " & mnRepSwift & " and "
                                'CrystalRep.SelectionFormula = CrystalRep.SelectionFormula & "{REPORTE_SWIFT.tipo_reporte_swift}= " & Right(lstOperacion.List(Arreglo(0)), 2)
                                'CrystalRep.ReportFileName = GPATH & "\MT198 enviar_2.RPT"
                                'MuestraVentanaReporte CrystalRep
                                lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
                                lsReporte = lsRutaFolder & "MT198 enviar_2.RPT" '& lsAmbiente & ".rpt"
                                rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                                objLibreria.logonBDreporte(rptDoc, 1)
                                'sOperacion = Trim(Microsoft.VisualBasic.Right(lstOperacion.List(Arreglo(0)), Len(Trim(lstOperacion.List(Arreglo(0)))) - 35))
                                'sOperacion = Trim(Microsoft.VisualBasic.Right(dgvOperacion1.Rows(Arreglo(0)).Cells(0).Value, dgvOperacion1.Rows(Arreglo(0)).Cells(0).Value.ToString.Length - 35))
                                sOperacion = Trim(Microsoft.VisualBasic.Left(sOperacion, 40))
                                rptDoc.DataDefinition.FormulaFields.Item("Operacion").Text = "'" & sOperacion & "'"
                                rptDoc.DataDefinition.FormulaFields.Item("Agencia").Text = "'" & 1 & "'" 'Trim(Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(lstOperacion.List(Arreglo(0)), Len(lstOperacion.List(Arreglo(0))) - 22), 13)) & "'"
                                rptDoc.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & Trim(Format(dtpFecha.Value.Date, "yyyy-MM-dd")) & "'"
                                rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Format(gs_HoraSistema, "hh:mm") & "'"
                                LsFormula = "{REPORTE_SWIFT.no_rep_swift} = " & mnRepSwift & " and "
                                'LsFormula = LsFormula & "{REPORTE_SWIFT.tipo_reporte_swift}= " & Microsoft.VisualBasic.Right(dgvOperacion1.Rows(Arreglo(0)).Cells(0).Value, 2)
                            End If
                        End If
                        nMaxOp = nMaxOp - nOperaciones
                    Next nVarTipo
                Loop
            End If
            'Call terminaExcel
            'Call muestraExcel
            'Screen.MousePointer = vbDefault
            objArchivoExcel.Close()
            pbMT198.Value = 10
            MsgBox("Las operaciones se enviaron con exito", vbInformation, "Aviso")
        End If
        ActualizaLista()
        pbMT198.Visible = False
        pbMT198.Value = 0
        'Screen.MousePointer = vbDefault
        cmdAceptar.Enabled = True
        My.Computer.FileSystem.DeleteFile(sRutaArchivo)
    End Sub

    '-------------------------------------------------------------------------------
    'Se genera la instancia de Excel si no existe si ya existe toma el existente
    '-------------------------------------------------------------------------------
    'FileCopy(Path.GetTempPath() & sFile, lsPathChequera & sFile)
    'File.WriteAllBytes(Path.GetTempPath() & sFile, My.Resources.PRINTER)
    Private Function generaInstancia(ByVal Agencia As Long) As Boolean
        'On Error GoTo errExcel
        '        generaInstancia = False
        '        Dim nomAgencia As String = ""
        '        If Agencia = 1 Then
        '            nomAgencia = "HO"
        '        ElseIf Agencia = 3 Then
        '            nomAgencia = "GC"
        '        End If
        '        'Nombre del archivo
        '        strnameFile = "B" & nomAgencia & Format(Now, "yyyyMMddHHmmss")
        '        strFile = String.Format(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\" + strnameFile & ".csv")
        '        objArchivoExcel = New StreamWriter(strFile)
        '        generaInstancia = True
        On Error GoTo errExcel
        generaInstancia = False
        Dim intFile As Integer
        Dim nomAgencia As String
        Dim GetTempDir As String
        If Agencia = 1 Then
            nomAgencia = "HO"
        ElseIf Agencia = 3 Then
            nomAgencia = "GC"
        End If

        'Create Object
        'objExcel = CreateObject("Excel.Application") 'Set objExcel = CreateObject("Excel.Application")
        'objExcel.DisplayAlerts = False
        'GetTempDir = Path.GetTempPath()
        'ChDir(GetTempDir)
        intFile = 1

        'Nombre del archivo
        strnameFile = "B" & nomAgencia & Format(Now, "yyyyMMddHHmmss")
        'strFile = GetTempDir & strnameFile & ".xls"    ' porque no genera bien la ruta por el cambio de chequeras. 14/oct/2005 "\" & Esto ya no es necesario porque ya lo envia la funcion GetTempDir (03-11-2005)

        ''Verificamos si existe el archivo
        'If Dir$(strFile) = "" Then 'If Dir(strFile, vbArchive) = "" Then
        '    existeArchivo = False
        '    'Si no existe se crea
        '    OpenstrFile For Output As #intFile
        '        Else
        '    existeArchivo = True
        strFile = String.Format(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\" + strnameFile & ".csv")
        sRutaArchivo = strFile
        objArchivoExcel = New StreamWriter(strFile)
        'End If

        'Close #intFile

        'Open Excel File
        'objExcel.Workbooks.Open FileName:=strFile

        'Para mostrar la ventana excel
        'objExcel.Application.Visible = True

        generaInstancia = True
        Exit Function
errExcel:
        MsgBox(Err.Number & " " & Err.Description, vbCritical, "Error")
        'Destroy Object
        'Set objExcel = Nothing
        generaInstancia = False
    End Function
    '-------------------------------------------------------------------------------
    'Funcion prepara archivo de excel para dejar listo los encabezados
    'para imprimir las operacion
    '-------------------------------------------------------------------------------
    Private Function poneEncabezados(ByVal nombreOp As String) As Boolean
        On Error GoTo errEncabezados
        'Ingresamos los encabezados para el archivo
        If (bEncabezados) Then
            'objArchivoExcel.WriteLine("NO. DE OPERACIONES ,REPORTE MT198 ,FECHA OPERACION ,AGENCIA ,OPERACION ,REFERENCIA ,CUENTA CLIENTE ,MONTO OPERACION ")
            objArchivoExcel.WriteLine("FECHA OPERACION ,AGENCIA ,OPERACION ,REFERENCIA ,CUENTA CLIENTE ,MONTO OPERACION ")
            bEncabezados = False
        End If
        poneEncabezados = True
        Exit Function
errEncabezados:
        MsgBox(Err.Number & " " & Err.Description, vbCritical, "Error Encabezados")
        poneEncabezados = False
        bEncabezados = True
        ' Recorrer las filas del dataGridView
        '        On Error GoTo errEncabezados
        '        Dim X As Long
        '        Dim Y As Long
        '        poneEncabezados = False
        '        'La longitud para una pestaña no debe sobrepasar 31 caracteres
        '        If Len(nombreOp) > 31 Then nombreOp = Mid(nombreOp, 1, 30)
        '        Y = 0
        '        'Si el archivo ya esta creado agrega lo necesario
        '        If StrComp(strnameFile, objExcel.Worksheets.Item(1).Name, vbTextCompare) <> 0 Then
        '            'Verificamos si ya existe la hoja de ese tipo de operaciones
        '            For X = 1 To objExcel.Worksheets.Count
        '                If StrComp(objExcel.Worksheets.Item(X).Name, nombreOp, vbTextCompare) = 0 Then
        '                    Y = X
        '                    Exit For
        '                End If
        '            Next X
        '            'Si ya existe checa si tiene los encabezados
        '            If Y > 0 Then
        '                objExcel.Worksheets.Item(Y).Select
        '                'Si son necesarias Headers
        '                objExcel.Range("B1").Select
        '                If StrComp(objExcel.ActiveCell.FormulaR1C1, "No. de Operaciones", vbTextCompare) <> 0 Then
        '                    objExcel.ActiveCell.FormulaR1C1 = "No. de Operaciones"
        '                End If
        '                objExcel.Range("C2").Select
        '                If StrComp(objExcel.ActiveCell.FormulaR1C1, "REPORTE MT198", vbTextCompare) <> 0 Then
        '                    objExcel.ActiveCell.FormulaR1C1 = "REPORTE MT198"
        '                End If
        '                objExcel.Range("A3").Select
        '                If StrComp(objExcel.ActiveCell.FormulaR1C1, "FECHA OPERACIÓN", vbTextCompare) <> 0 Then
        '                    objExcel.ActiveCell.FormulaR1C1 = "FECHA OPERACIÓN"
        '                End If
        '                objExcel.Range("B3").Select
        '                If StrComp(objExcel.ActiveCell.FormulaR1C1, "AGENCIA", vbTextCompare) <> 0 Then
        '                    objExcel.ActiveCell.FormulaR1C1 = "AGENCIA"
        '                End If
        '                objExcel.Range("C3").Select
        '                If StrComp(objExcel.ActiveCell.FormulaR1C1, "OPERACIÓN", vbTextCompare) <> 0 Then
        '                    objExcel.ActiveCell.FormulaR1C1 = "OPERACIÓN"
        '                End If
        '                objExcel.Range("D3").Select
        '                If StrComp(objExcel.ActiveCell.FormulaR1C1, "REFERENCIA", vbTextCompare) <> 0 Then
        '                    objExcel.ActiveCell.FormulaR1C1 = "REFERENCIA"
        '                End If
        '                objExcel.Range("E3").Select
        '                If StrComp(objExcel.ActiveCell.FormulaR1C1, "CUENTA CLIENTE", vbTextCompare) <> 0 Then
        '                    objExcel.ActiveCell.FormulaR1C1 = "CUENTA CLIENTE"
        '                End If
        '                objExcel.Range("F3").Select
        '                If StrComp(objExcel.ActiveCell.FormulaR1C1, "MONTO OPERACIÓN", vbTextCompare) <> 0 Then
        '                    objExcel.ActiveCell.FormulaR1C1 = "MONTO OPERACIÓN"
        '                End If
        '                'Si la hoja no existe crea una con ese nombre y pone el encabezado
        '            Else
        '                objExcel.Worksheets.Add
        '                objExcel.ActiveWorkbook.ActiveSheet.Name = nombreOp
        '                'Headers
        '                objExcel.Range("A1").Select
        '                objExcel.ActiveCell.FormulaR1C1 = "0"
        '                objExcel.Range("B1").Select
        '                objExcel.ActiveCell.FormulaR1C1 = "No. de Operaciones"
        '                objExcel.Range("C2").Select
        '                objExcel.ActiveCell.FormulaR1C1 = "REPORTE MT198"
        '                objExcel.Range("A3").Select
        '                objExcel.ActiveCell.FormulaR1C1 = "FECHA OPERACIÓN"
        '                objExcel.Range("B3").Select
        '                objExcel.ActiveCell.FormulaR1C1 = "AGENCIA"
        '                objExcel.Range("C3").Select
        '                objExcel.ActiveCell.FormulaR1C1 = "OPERACIÓN"
        '                objExcel.Range("D3").Select
        '                objExcel.ActiveCell.FormulaR1C1 = "REFERENCIA"
        '                objExcel.Range("E3").Select
        '                objExcel.ActiveCell.FormulaR1C1 = "CUENTA CLIENTE"
        '                objExcel.Range("F3").Select
        '                objExcel.ActiveCell.FormulaR1C1 = "MONTO OPERACIÓN"
        '            End If
        '            'Si el archivo No esta creado pone encabezados
        '        Else  'If Not existeArchivo Then
        '            'Ponemos el nombre a la hoja de Excel correspondiente al tipo de operacion
        '            objExcel.ActiveWorkbook.ActiveSheet.Name = nombreOp
        '            'Headers
        '            objExcel.Range("A1").Select
        '            objExcel.ActiveCell.FormulaR1C1 = "0"
        '            objExcel.Range("B1").Select
        '            objExcel.ActiveCell.FormulaR1C1 = "No. de Operaciones"
        '            objExcel.Range("C2").Select
        '            objExcel.ActiveCell.FormulaR1C1 = "REPORTE MT198"
        '            objExcel.Range("A3").Select
        '            objExcel.ActiveCell.FormulaR1C1 = "FECHA OPERACIÓN"
        '            objExcel.Range("B3").Select
        '            objExcel.ActiveCell.FormulaR1C1 = "AGENCIA"
        '            objExcel.Range("C3").Select
        '            objExcel.ActiveCell.FormulaR1C1 = "OPERACIÓN"
        '            objExcel.Range("D3").Select
        '            objExcel.ActiveCell.FormulaR1C1 = "REFERENCIA"
        '            objExcel.Range("E3").Select
        '            objExcel.ActiveCell.FormulaR1C1 = "CUENTA CLIENTE"
        '            objExcel.Range("F3").Select
        '            objExcel.ActiveCell.FormulaR1C1 = "MONTO OPERACIÓN"
        '        End If
        '        poneEncabezados = True
        '        Exit Function
        'errEncabezados:
        '        MsgBox(Err.Number & " " & Err.Description, vbCritical, "Error Encabezados")
        '        poneEncabezados = False
    End Function
    '----------------------------------------------------------------
    'Agrega la operacion correspondiente al Excel
    '----------------------------------------------------------------
    Private Function insertaOpExcel(ByVal noTicket As String) As Boolean
        'Modificación: BAGO-EDS-07/MZO/06. Cambio en los "Select Case" para adecuar el Null por Is Null
        On Error GoTo errponRenglon
        Dim noRenglon As Long
        Dim numOpDef As Integer
        insertaOpExcel = False
        Dim linea As String = String.Empty
        numOpDef = opDefXTicket(noTicket)
        'Encontramos los datos a imprimir en el excel segun tipo de operacion definida para
        'buscar en sus tablas correspondientes
        If numOpDef <> 8058 Then
            If numOpDef = 8552 Or numOpDef = 8553 Then
                gs_Sql = "Select OP.fecha_operacion, AG.descripcion_agencia, OP.operacion, REF.observaciones, "
                gs_Sql = gs_Sql & "AG.prefijo_agencia + ' ' + PC.cuenta_cliente + ' ' + TCE.sufijo_kapiti, "
                gs_Sql = gs_Sql & "OP.monto_operacion "
                gs_Sql = gs_Sql & "FROM " & "TICKET" & ".dbo.OPERACION OP, " & "CATALOGOS" & ".dbo.AGENCIA AG, "
                gs_Sql = gs_Sql & "TICKET" & ".dbo.DEPOSITO_CED REF, " & "TICKET" & ".dbo.PRODUCTO_CONTRATADO PC, "
            ElseIf numOpDef = 8052 Or numOpDef = 8053 Or numOpDef = 8054 Or numOpDef = 8056 Or numOpDef = 8057 Then
                gs_Sql = "Select OP.fecha_operacion, AG.descripcion_agencia, OP.operacion, REF.observaciones, "
                gs_Sql = gs_Sql & "AG.prefijo_agencia + ' ' + PC.cuenta_cliente + ' ' + TCE.sufijo_kapiti, "
                gs_Sql = gs_Sql & "OP.monto_operacion "
                gs_Sql = gs_Sql & "FROM " & "TICKET" & ".dbo.OPERACION OP, " & "CATALOGOS" & ".dbo.AGENCIA AG, "
                gs_Sql = gs_Sql & "TICKET" & ".dbo.RETIRO_CED REF, " & "TICKET" & ".dbo.PRODUCTO_CONTRATADO PC, "
            ElseIf numOpDef <> 0 Then
                gs_Sql = "Select OP.fecha_operacion, AG.descripcion_agencia, OP.operacion, REF.referencia, "
                gs_Sql = gs_Sql & "AG.prefijo_agencia + ' ' + PC.cuenta_cliente + ' ' + TCE.sufijo_kapiti, "
                gs_Sql = gs_Sql & "OP.monto_operacion "
                gs_Sql = gs_Sql & "FROM " & "TICKET" & ".dbo.OPERACION OP, " & "CATALOGOS" & ".dbo.AGENCIA AG, "
                gs_Sql = gs_Sql & "TICKET" & ".dbo.REFERENCIAS REF, " & "TICKET" & ".dbo.PRODUCTO_CONTRATADO PC, "
            End If
            gs_Sql = gs_Sql & "TICKET" & ".dbo.CUENTA_EJE CE, " & "TICKET" & ".dbo.TIPO_CUENTA_EJE TCE "
            gs_Sql = gs_Sql & "WHERE CE.tipo_cuenta_eje = TCE.tipo_cuenta_eje "
            gs_Sql = gs_Sql & "AND PC.producto_contratado = CE.producto_contratado "
            gs_Sql = gs_Sql & "AND OP.producto_contratado = PC.producto_contratado "
            gs_Sql = gs_Sql & "AND OP.operacion = REF.operacion "
            gs_Sql = gs_Sql & "AND PC.agencia = AG.agencia "
            gs_Sql = gs_Sql & "AND OP.operacion = " & CLng(noTicket)
        ElseIf numOpDef = 8058 Then
            gs_Sql = "Select OP.fecha_operacion, AG.descripcion_agencia, OP.operacion, REF.referencia, "
            gs_Sql = gs_Sql & "AG.prefijo_agencia + ' ' + PC.cuenta_cliente + ' ' + TCE.sufijo_kapiti, "
            gs_Sql = gs_Sql & "TMOP.monto_operacion "
            gs_Sql = gs_Sql & "FROM " & "TICKET" & ".dbo.OPERACION OP, " & "TICKET" & ".dbo.TMP_OPS_COMISIONES TMOP, " & "CATALOGOS" & ".dbo.AGENCIA AG, "
            gs_Sql = gs_Sql & "TICKET" & ".dbo.REFERENCIAS REF, " & "TICKET" & ".dbo.PRODUCTO_CONTRATADO PC, "
            gs_Sql = gs_Sql & "TICKET" & ".dbo.CUENTA_EJE CE, " & "TICKET" & ".dbo.TIPO_CUENTA_EJE TCE "
            gs_Sql = gs_Sql & "WHERE CE.tipo_cuenta_eje = TCE.tipo_cuenta_eje "
            gs_Sql = gs_Sql & "AND PC.producto_contratado = CE.producto_contratado "
            gs_Sql = gs_Sql & "AND OP.producto_contratado = PC.producto_contratado "
            gs_Sql = gs_Sql & "AND OP.operacion = TMOP.operacion "
            gs_Sql = gs_Sql & "AND TMOP.producto_contratado = PC.producto_contratado "
            gs_Sql = gs_Sql & "AND TMOP.operacion = REF.operacion "
            gs_Sql = gs_Sql & "AND PC.agencia = AG.agencia "
            gs_Sql = gs_Sql & "AND TMOP.operacion = " & CLng(noTicket)
        End If
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If Not dbError() Then
            For Each row As DataRow In dtRespConsulta.Rows
                ' vaciar la línea
                linea = String.Empty
                ' Recorrer la cantidad de columnas que contiene el dataGridView
                For col As Integer = 0 To row.ItemArray.Count - 1
                    ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
                    linea = linea & row.ItemArray(col).ToString & ","
                Next
                ' Escribir una línea con el método WriteLine
                With objArchivoExcel
                    ' eliminar el último caracter “;” de la cadena
                    linea = linea.Remove(linea.Length - 1).ToString
                    ' escribir la fila
                    .WriteLine(linea.ToString)
                End With
            Next
            'objExcel.Range("A1").Select
            'noRenglon = CLng(objExcel.ActiveCell.FormulaR1C1)
            'objExcel.Range("A" & noRenglon + 4).Select
            'objExcel.ActiveCell.FormulaR1C1 = Format(dbGetValue(0), "dd-mm-yyyy")
            'objExcel.Range("B" & noRenglon + 4).Select
            'objExcel.ActiveCell.FormulaR1C1 = dbGetValue(1)
            'objExcel.Range("C" & noRenglon + 4).Select
            'objExcel.ActiveCell.FormulaR1C1 = dbGetValue(2)
            'objExcel.Range("D" & noRenglon + 4).Select
            'objExcel.ActiveCell.FormulaR1C1 = dbGetValue(3)
            'objExcel.Range("E" & noRenglon + 4).Select
            'objExcel.ActiveCell.FormulaR1C1 = dbGetValue(4)
            'objExcel.Range("F" & noRenglon + 4).Select
            'objExcel.ActiveCell.FormulaR1C1 = Format(dbGetValue(5), "$#,###.00")
            'objExcel.Range("A1").Select
            'objExcel.ActiveCell.FormulaR1C1 = CStr(noRenglon + 1)
        End If
        'dbEndQuery
        insertaOpExcel = True
        Exit Function
errponRenglon:
        MsgBox(Err.Number & " " & Err.Description, vbCritical, "Error Agrega Operación")
        insertaOpExcel = False
    End Function
    '----------------------------------------------------------------------------------
    'La funcion regresa el tipo de Operacion definida segun el numero de Ticket que se pasa
    '----------------------------------------------------------------------------------
    Private Function opDefXTicket(ByVal ticket As Double) As Integer
        On Error GoTo erropDefXTicket
        Dim ls_qry As String
        opDefXTicket = 0
        'dbEndQuery
        ls_qry = "Select operacion_definida FROM OPERACION "
        ls_qry = ls_qry & "WHERE operacion = " & ticket
        'dbExecQuery ls_qry
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(ls_qry)
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
            opDefXTicket = Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery
        Exit Function
erropDefXTicket:
        MsgBox(Err.Number & " " & Err.Description, vbCritical, "Error")
        opDefXTicket = 0
    End Function
    Private Sub cboOperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOperacion.SelectedIndexChanged
        If mnInicia <> 0 Then
            ActualizaLista()
        End If
    End Sub
    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir de MT198") <> vbYes Then Exit Sub
        Me.Close()
    End Sub
End Class