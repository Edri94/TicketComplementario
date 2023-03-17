Public Class frmReenvioTicket
    Dim nOperacion As Long
    Dim X As Long
    Private la_TitulosCampos(4) As String
    Dim objDataSource As New Datasource
    Dim objLibreria As New Libreria

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir de Reenvío de Tickets") <> vbYes Then
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub

    Private Sub frmReenvioTicket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim FechaHoy As Date
        ' Centra la forma y carga los colores seleccionados por el usuario
        'Call Centerform(Me)
        'Call CargarColores(Me, cambio)

        FechaHoy = Date.Now

        ' Llena el grid con las operaciones rechazadas del día...
        la_TitulosCampos(0) = "Operacion"
        la_TitulosCampos(1) = "Fecha Captura"
        la_TitulosCampos(2) = "Fecha Proceso"
        la_TitulosCampos(3) = "Monto Operación"

        sfrmOperRechaz.Text = "Operaciones rechazadas del día " + (CStr(FechaHoy)) + " (dd-mm-yyyy)"    'Formatea_Fecha(CStr(FechaHoy))

        llenaGridOperRechazadas()

        ' Restablece el aspecto del cursor
        'ShowDefaultCursor
    End Sub
    Private Function llenaGridOperRechazadas()
        Dim strSqlquery As String
        Dim FechaHoy As Date = Date.Now
        Dim dtRespConsulta As DataTable
        'CONVERT(CHAR(10),CD.fecha_vencimiento,105),
        strSqlquery = "SELECT" & vbCrLf
        strSqlquery = strSqlquery + "   OP.operacion" & vbCrLf
        strSqlquery = strSqlquery + "   ,CONVERT(CHAR(10),OP.fecha_captura,105)" & vbCrLf
        strSqlquery = strSqlquery + "   ,CONVERT(CHAR(10),OP.fecha_operacion,105)" & vbCrLf
        strSqlquery = strSqlquery + "   ,CONVERT(real, OP.monto_operacion)" & vbCrLf
        strSqlquery = strSqlquery + "-- ,PD.operacion_definida_global" & vbCrLf
        strSqlquery = strSqlquery + "FROM" & vbCrLf
        strSqlquery = strSqlquery + "   OPERACION OP," & vbCrLf
        strSqlquery = strSqlquery + "   OPERACION_DEFINIDA PD," & vbCrLf
        strSqlquery = strSqlquery + "   BITACORA_ENVIO_KAPITI BEK" & vbCrLf
        strSqlquery = strSqlquery + "WHERE" & vbCrLf
        strSqlquery = strSqlquery + "       OP.status_operacion = 5" & vbCrLf
        strSqlquery = strSqlquery + "AND    PD.operacion_definida = OP.operacion_definida" & vbCrLf
        strSqlquery = strSqlquery + "AND    BEK.operacion = OP.operacion" & vbCrLf
        'strSqlquery = strSqlquery + "AND    OP.fecha_operacion >= '" + InvierteFecha(CStr(DateTime.Now)) + "'" & vbCrLf
        strSqlquery = strSqlquery + "AND    OP.fecha_operacion >= '" + (FechaHoy.Year & "-" & FechaHoy.Month & "-" & FechaHoy.Day) + "'" & vbCrLf
        'strSqlquery = strSqlquery + "AND    OP.fecha_operacion < DATEADD(dd, 1, CONVERT(smalldatetime, '" + InvierteFecha(CStr(DateTime.Now)) + "'))" & vbCrLf
        strSqlquery = strSqlquery + "AND    OP.fecha_operacion < DATEADD(dd, 1, CONVERT(smalldatetime, '" + (FechaHoy.Year & "-" & FechaHoy.Month & "-" & FechaHoy.Day) + "'))" & vbCrLf
        '    strSqlquery = strSqlquery + "AND    OP.fecha_operacion >= '20040910'" & vbCrLf
        '    strSqlquery = strSqlquery + "AND    OP.fecha_operacion < DATEADD(dd, 1, CONVERT(smalldatetime, '20040910'))" & vbCrLf
        strSqlquery = strSqlquery + "AND    PD.operacion_definida_global IN (80, 180,           -- Retiro por compra de TD" & vbCrLf
        strSqlquery = strSqlquery + "       589, 591, 592, 590, 583, 588, 553, 552, 587, 597, 559,  -- Depositos" & vbCrLf
        strSqlquery = strSqlquery + "       89, 65, 88, 83, 54, 56, 57, 87, 52, 53, 58, 59)     -- Retiros" & vbCrLf
        strSqlquery = strSqlquery + "ORDER BY fecha_operacion, PD.operacion_definida_global"
        'Call CargaGrid(gridOperRechazadas, strSqlquery, la_TitulosCampos)
        dtRespConsulta = objDataSource.RealizaConsulta(strSqlquery)
        gridOperRechazadas.DataSource = dtRespConsulta
        gridOperRechazadas.Columns(3).DefaultCellStyle.Format = "N2"
        For i = 0 To 3
            gridOperRechazadas.Columns(i).HeaderText = la_TitulosCampos(i).ToString
        Next
    End Function

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Call LimpiarCampos
    End Sub
    Private Sub LimpiarCampos()
        ' Limpia todos los campos y recarga el grid de operaciones rechazadas
        txtNumTicket.Text = ""
        txtFechaCapt.Text = ""
        txtFechaProc.Text = ""
        txtMonto.Text = ""
        txtNota.Text = ""
        ssFrmRenvio.Text = ""

        ' Restablece los botones
        StatusBotones(False)

        ' Recarga el Grid
        'llenaGridOperRechazadas()
    End Sub
    Private Sub StatusBotones(verBoton As Boolean)
        cmdReenviar.Enabled = verBoton
        cmdCancelar.Enabled = verBoton
        ssFrmRenvio.Enabled = verBoton
        txtNota.Enabled = verBoton
    End Sub

    Private Sub cmdReenviar_Click(sender As Object, e As EventArgs) Handles cmdReenviar.Click
        ' Verifica q exista información en para ingresar en comentario_evento
        If StrComp(txtNota.Text, "", vbTextCompare) = 0 Then
            MsgBox("Requiere escribir el motivo del reenvío de esta operacion", vbInformation)
            Exit Sub
        End If

        BtnVisible(False)
        pgbCarga.Maximum = 6
        pgbCarga.Value = 0
        pgbCarga.Value = 1
        Call ProcessMessage("Ejecutando reenvío de la operación " + CStr(nOperacion))
        pgbCarga.Value = 2
        If ReenviarOperacion() Then
            pgbCarga.Value = 3
            ProcessMessage("Reenvío de la operación " + CStr(nOperacion) + " completado...")
            LimpiarCampos()
        Else
            ProcessMessage("Error ejecutar el reenvío de la operación " + CStr(nOperacion))
        End If
        pgbCarga.Value = 0
        BtnVisible(True)
        X = 0
        llenaGridOperRechazadas()
        'tmrMensaje.Enabled = True
    End Sub
    Private Function ReenviarOperacion() As Boolean
        Dim sql_reenvioOP As String
        Dim oRespuestaSP As Object

        sql_reenvioOP = "EXEC sp_reenvio_operaciones " + CStr(nOperacion) + ", '" + txtNota.Text + "', " + CStr(usuario)
        ReenviarOperacion = False
        pgbCarga.Value = 4
        ' Solicita cursor en modo de espera
        'ShowWaitCursor

IniciaReenvioOP:

        ' Ejecuta los Querys Necesarios para completar el proceso de reenvio de operaciones
        'dbExecQuery sql_reenvioOP
        oRespuestaSP = objDataSource.EjecutaSP(sql_reenvioOP)
        pgbCarga.Value = 5
        'If dbError Then
        '    GoTo ErrorReenvio
        'End If

        'dbEndQuery

        'ShowDefaultCursor
        ReenviarOperacion = True
        pgbCarga.Value = 6
        MsgBox("Proceso terminado de forma correcta", vbInformation)
        Exit Function

ErrorReenvio:
        'ShowDefaultCursor
        If MsgBox("Ha ocurrido un error al reenviar la operación.  Se recomienda Cancelar y capturar de nuevo", vbRetryCancel + vbCritical, "Transaction Error") = vbRetry Then
            GoTo IniciaReenvioOP
        Else
            ReenviarOperacion = False
        End If
    End Function
    Private Sub gridOperRechazadas_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles gridOperRechazadas.RowEnter
        ' En cada click sobre el grid se borra la información de los campos de reenvío
        If gridOperRechazadas.SelectedRows.Count > 0 Then
                LimpiarCampos()
                ''gridOperRechazadas.Col = 0
                nOperacion = gridOperRechazadas.SelectedRows.Item(0).Cells(0).Value
            ' Ejecuta la carga de la operacion en la seccion correspondiente
            LLenaDatosOPeracion()
        End If
    End Sub
    Private Function LLenaDatosOPeracion()
        Dim sql_query As String
        Dim FechaHoy As Date = Date.Now
        Dim dtRespConsulta As DataTable
        ' Solicita cambiar cursor
        'ShowWaitCursor

        On Error GoTo ErrorLlenado

        sql_query = "SELECT" & vbCrLf
        sql_query = sql_query + "   OP.operacion" & vbCrLf
        sql_query = sql_query + "   ,CONVERT(CHAR(10),OP.fecha_captura,105)" & vbCrLf
        sql_query = sql_query + "   ,CONVERT(CHAR(10),OP.fecha_operacion,105)" & vbCrLf
        sql_query = sql_query + "   ,OP.monto_operacion" & vbCrLf
        sql_query = sql_query + "   ,PD.descripcion_operacion_definida" & vbCrLf
        sql_query = sql_query + "FROM" & vbCrLf
        sql_query = sql_query + "   OPERACION OP," & vbCrLf
        sql_query = sql_query + "   OPERACION_DEFINIDA PD," & vbCrLf
        sql_query = sql_query + "   BITACORA_ENVIO_KAPITI BEK" & vbCrLf
        sql_query = sql_query + "WHERE" & vbCrLf
        sql_query = sql_query + "       OP.operacion = " + CStr(nOperacion) & vbCrLf
        sql_query = sql_query + "AND    OP.status_operacion = 5" & vbCrLf
        sql_query = sql_query + "AND    PD.operacion_definida = OP.operacion_definida" & vbCrLf
        sql_query = sql_query + "AND    BEK.operacion = OP.operacion" & vbCrLf
        sql_query = sql_query + "AND    OP.fecha_operacion >= '" + (FechaHoy.Year & "-" & FechaHoy.Month & "-" & FechaHoy.Day) + "'" & vbCrLf
        sql_query = sql_query + "AND    OP.fecha_operacion < DATEADD(dd, 1, CONVERT(smalldatetime, '" + (FechaHoy.Year & "-" & FechaHoy.Month & "-" & FechaHoy.Day) + "'))" & vbCrLf
        '    sql_query = sql_query + "AND    OP.fecha_operacion >= '20040910'" & vbCrLf
        '    sql_query = sql_query + "AND    OP.fecha_operacion < DATEADD(dd, 1, CONVERT(smalldatetime, '20040910'))" & vbCrLf
        sql_query = sql_query + "AND    PD.operacion_definida_global IN (80, 180,           -- Retiro por compra de TD" & vbCrLf
        sql_query = sql_query + "       589, 591, 592, 590, 583, 588, 553, 552, 587, 597, 559,  -- Depositos" & vbCrLf
        sql_query = sql_query + "       89, 65, 88, 83, 54, 56, 57, 87, 52, 53, 58, 59)     -- Retiros" & vbCrLf
        sql_query = sql_query + "ORDER BY fecha_operacion, PD.operacion_definida_global"

        'dbExecQuery sql_query
        'dbGetRecord
        dtRespConsulta = objDataSource.RealizaConsulta(sql_query)

        If dtRespConsulta Is Nothing Then
            GoTo ErrorLlenado
        End If

        ' Despliega contenido y descripcion de la operación
        ' operacion   fecha_captura               fecha_operacion             monto_operacion      descripcion_operacion_definida

        If Trim(dtRespConsulta.Rows(0).Item(0)) = "" Then
            GoTo ErrorLlenado
        End If

        'txtNumTicket.Text = CStr(dbGetValue(0))
        txtNumTicket.Text = CStr(dtRespConsulta.Rows(0).Item(0))
        'txtFechaCapt.Text = InvierteFecha(dbGetValue(1))
        txtFechaCapt.Text = objLibreria.InvierteFecha(dtRespConsulta.Rows(0).Item(1))
        'txtFechaProc.Text = InvierteFecha(dbGetValue(2))
        txtFechaProc.Text = objLibreria.InvierteFecha(dtRespConsulta.Rows(0).Item(2))

        If Trim(dtRespConsulta.Rows(0).Item(3)) = "" Then
            txtMonto.Text = "0.00"
        Else
            txtMonto.Text = Format(dtRespConsulta.Rows(0).Item(3), "###,###,###,##0.00")
        End If

        ssFrmRenvio.Text = "Tipo de Operacion Rechazada : " + CStr(dtRespConsulta.Rows(0).Item(4))
        'dbEndQuery

        ' Restablece apariencia del cursor
        'ShowDefaultCursor

        Call StatusBotones(True)

        Exit Function

ErrorLlenado:
        'dbEndQuery
        MsgBox("No es posible recuperar el ticket en este momento intente más tarde", vbCritical)
        'ShowDefaultCursor
    End Function
    Public Sub ProcessMessage(MENSAJE As String)
        lbGenArch.Text = Trim(MENSAJE)
        lbGenArch.Refresh()
    End Sub
    Private Sub BtnVisible(bEsattus As Boolean)
        If bEsattus = True Then
            cmdReenviar.Visible = bEsattus
            cmdCancelar.Visible = bEsattus
            cmdSalir.Visible = bEsattus
            lbGenArch.Visible = False
            pgbCarga.Visible = False
        Else
            cmdReenviar.Visible = bEsattus
            cmdCancelar.Visible = bEsattus
            cmdSalir.Visible = bEsattus
            lbGenArch.Visible = True
            pgbCarga.Visible = True
        End If
    End Sub
End Class