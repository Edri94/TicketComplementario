Public Class frmMantenimientoTKT
    Public mnEntro As Byte
    Private objDatasource As New Datasource
    Private dtTablaPrevia As New DataTable
    Private strgFechaUltAccion As String
    Private Sub frmMantenimientoTKT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataTable()
    End Sub
    Private Sub cmdBuscar_Click(sender As Object, e As EventArgs) Handles cmdBuscar.Click
        If Microsoft.VisualBasic.Right(txtTicket.Text, 1) = "," Then txtTicket.Text = Mid(txtTicket.Text, 1, Len(txtTicket.Text) - 1)
        LlenarGrid()
        ActualizaUltimoMovimiento()
    End Sub
    Private Sub LlenarGrid()
        Dim intContador As Integer, strTickets() As String, intTotTicket As Integer, intCuentaVueltas As Integer, bolNoEncontroTicket As Boolean
        Dim dtRespConsulta As DataTable
        bolNoEncontroTicket = False
        intContador = 1
        strTickets = Split(txtTicket.Text, ",")
        intTotTicket = UBound(strTickets)
        intCuentaVueltas = 0
        'InicializaGrid()
        'While intCuentaVueltas <= intTotTicket
        gs_Sql = ""
        gs_Sql = "SELECT OP.OPERACION, AG.PREFIJO_AGENCIA + '-' + PC.CUENTA_CLIENTE + '-' + TCE.SUFIJO_KAPITI," &
                    "ISNULL(RTRIM(LTRIM(UPPER(CL.NOMBRE_CLIENTE))),'') + ' ' + ISNULL(RTRIM(LTRIM(UPPER(APELLIDO_PATERNO))),'') + ' ' + ISNULL(RTRIM(LTRIM(UPPER(APELLIDO_MATERNO))),'')," &
                    "OP.MONTO_OPERACION, " &
                    "CONVERT(VARCHAR(10),OP.FECHA_OPERACION,105)," &
                    "Case op.STATUS_OPERACION " &
                        "WHEN '0' THEN '0 - VALIDACIÓN A FUTURO'" &
                        "WHEN '1' THEN '1 - PENDIENTE DE VALIDAR'" &
                        "WHEN '2' THEN '2 - VALIDADO'" &
                        "WHEN '3' THEN '3 - PENDIENTE DE RECIBIR'" &
                        "WHEN '4' THEN '4 - VALIDADO EQ'" &
                        "WHEN '250' THEN '250 - CANCELADO'" &
                        "ELSE CONVERT(VARCHAR(3),OP.STATUS_OPERACION) + ' - ' + UPPER(SO.DESCRIPCION_STATUS)" &
                        "END, " &
                    "OD.DESCRIPCION_OPERACION_DEFINIDA, " &
                    "ISNULL(RTRIM(LTRIM(UPPER(CL.NOMBRE_CLIENTE))),'') + '-' + ISNULL(RTRIM(LTRIM(UPPER(APELLIDO_PATERNO))),'') + '-' + ISNULL(RTRIM(LTRIM(UPPER(APELLIDO_MATERNO))),'') AS NOMBRE_ANT " &
                    "FROM TICKET..PRODUCTO_CONTRATADO PC, TICKET..OPERACION OP, CATALOGOS..AGENCIA AG, CUENTA_EJE CE, TIPO_CUENTA_EJE TCE," &
                         "CATALOGOS..CLIENTE CL, TICKET..STATUS_OPERACION SO, OPERACION_DEFINIDA OD "
        If False Then 'If Permiso("PMANTTKTOPER") And Not Permiso("PMANTTKTAPER") Then
            gs_Sql = gs_Sql & "WHERE convert(varchar(7),OP.OPERACION) IN (" & txtTicket.Text & ") " &
                        "AND OP.PRODUCTO_CONTRATADO = PC.PRODUCTO_CONTRATADO " &
                        "AND PC.AGENCIA = AG.AGENCIA " &
                        "AND PC.AGENCIA = 1 " &
                        "AND PC.PRODUCTO_CONTRATADO = CE.PRODUCTO_CONTRATADO AND CE.TIPO_CUENTA_EJE = TCE.TIPO_CUENTA_EJE " &
                        "AND CL.CUENTA_CLIENTE = PC.CUENTA_CLIENTE " &
                        "AND CL.AGENCIA = 1 " &
                        "AND OP.STATUS_OPERACION = SO.STATUS_OPERACION " &
                        "AND OP.OPERACION_DEFINIDA = OD.OPERACION_DEFINIDA " &
                        "AND OP.OPERACION_DEFINIDA NOT IN (8080,8055, 8100) "
        ElseIf False Then 'ElseIf Permiso("PMANTTKTAPER") And Not Permiso("PMANTTKTOPER") Then
            gs_Sql = gs_Sql & "WHERE convert(varchar(7),OP.OPERACION) IN (" & txtTicket.Text & ") " &
                            "AND OP.OPERACION_DEFINIDA = 8100 " &
                            "AND OP.STATUS_OPERACION = 4 " &
                            "AND OP.PRODUCTO_CONTRATADO = PC.PRODUCTO_CONTRATADO " &
                            "AND PC.STATUS_PRODUCTO = 8001 " &
                            "AND PC.AGENCIA = 1 " &
                            "AND PC.AGENCIA = AG.AGENCIA " &
                            "AND PC.PRODUCTO_CONTRATADO = CE.PRODUCTO_CONTRATADO AND CE.TIPO_CUENTA_EJE = TCE.TIPO_CUENTA_EJE " &
                            "AND CL.CUENTA_CLIENTE = PC.CUENTA_CLIENTE " &
                            "AND CL.PERSONA_MORAL = 0 " &
                            "AND (CL.APELLIDO_MATERNO IS NULL OR CL.APELLIDO_MATERNO = '') " &
                            "AND OP.STATUS_OPERACION = SO.STATUS_OPERACION " &
                            "AND OP.OPERACION_DEFINIDA = OD.OPERACION_DEFINIDA "
        ElseIf True Then 'ElseIf Permiso("PMANTTKTAPER") And Permiso("PMANTTKTOPER") Then
            gs_Sql = "SELECT OP.OPERACION TICKET, AG.PREFIJO_AGENCIA + '-' + PC.CUENTA_CLIENTE + '-' + TCE.SUFIJO_KAPITI CUENTA," &
                            "ISNULL(RTRIM(LTRIM(UPPER(CL.NOMBRE_CLIENTE))),'') + ' ' + ISNULL(RTRIM(LTRIM(UPPER(APELLIDO_PATERNO))),'') + ' ' + ISNULL(RTRIM(LTRIM(UPPER(APELLIDO_MATERNO))),'') CLIENTE, " &
                            "OP.MONTO_OPERACION MONTO, " &
                            "CONVERT(VARCHAR(10),OP.FECHA_OPERACION,105) FECHA," &
                            "Case op.STATUS_OPERACION " &
                                "WHEN '0' THEN '0 - VALIDACIÓN A FUTURO'" &
                                "WHEN '1' THEN '1 - PENDIENTE DE VALIDAR'" &
                                "WHEN '2' THEN '2 - VALIDADO'" &
                                "WHEN '3' THEN '3 - PENDIENTE DE RECIBIR'" &
                                "WHEN '4' THEN '4 - VALIDADO EQ'" &
                                "WHEN '250' THEN '250 - CANCELADO'" &
                                "ELSE CONVERT(VARCHAR(3),OP.STATUS_OPERACION) + ' - ' + UPPER(SO.DESCRIPCION_STATUS)" &
                                "END STATUS, " &
                            "OD.DESCRIPCION_OPERACION_DEFINIDA OPERACION, " &
                            "ISNULL(RTRIM(LTRIM(UPPER(CL.NOMBRE_CLIENTE))),'') + '-' + ISNULL(RTRIM(LTRIM(UPPER(APELLIDO_PATERNO))),'') + '-' + ISNULL(RTRIM(LTRIM(UPPER(APELLIDO_MATERNO))),'') AS NOMBRE_ANT " &
                            "FROM TICKET..PRODUCTO_CONTRATADO PC, TICKET..OPERACION OP, CATALOGOS..AGENCIA AG, CUENTA_EJE CE, TIPO_CUENTA_EJE TCE," &
                                 "CATALOGOS..CLIENTE CL, TICKET..STATUS_OPERACION SO, OPERACION_DEFINIDA OD "
            gs_Sql = gs_Sql & "WHERE convert(varchar(7),OP.OPERACION) IN (" & txtTicket.Text & ") " &
                        "AND OP.PRODUCTO_CONTRATADO = PC.PRODUCTO_CONTRATADO " &
                        "AND PC.AGENCIA = AG.AGENCIA " &
                        "AND PC.AGENCIA = 1 " &
                        "AND PC.PRODUCTO_CONTRATADO = CE.PRODUCTO_CONTRATADO AND CE.TIPO_CUENTA_EJE = TCE.TIPO_CUENTA_EJE " &
                        "AND CL.CUENTA_CLIENTE = PC.CUENTA_CLIENTE " &
                        "AND OP.STATUS_OPERACION = SO.STATUS_OPERACION " &
                        "AND OP.OPERACION_DEFINIDA = OD.OPERACION_DEFINIDA " &
                        "AND OP.OPERACION_DEFINIDA NOT IN (8080,8055, 8100) "
            gs_Sql = gs_Sql & "UNION ALL "
            gs_Sql = gs_Sql & "SELECT OP.OPERACION, AG.PREFIJO_AGENCIA + '-' + PC.CUENTA_CLIENTE + '-' + TCE.SUFIJO_KAPITI," &
                        "ISNULL(RTRIM(LTRIM(UPPER(CL.NOMBRE_CLIENTE))),'') + ' ' + ISNULL(RTRIM(LTRIM(UPPER(APELLIDO_PATERNO))),'') + ' ' + ISNULL(RTRIM(LTRIM(UPPER(APELLIDO_MATERNO))),'')," &
                        "OP.MONTO_OPERACION, " &
                        "CONVERT(VARCHAR(10),OP.FECHA_OPERACION,105)," &
                        "Case op.STATUS_OPERACION " &
                            "WHEN '0' THEN '0 - VALIDACIÓN A FUTURO'" &
                            "WHEN '1' THEN '1 - PENDIENTE DE VALIDAR'" &
                            "WHEN '2' THEN '2 - VALIDADO'" &
                            "WHEN '3' THEN '3 - PENDIENTE DE RECIBIR'" &
                            "WHEN '4' THEN '4 - VALIDADO EQ'" &
                            "WHEN '250' THEN '250 - CANCELADO'" &
                            "ELSE CONVERT(VARCHAR(3),OP.STATUS_OPERACION) + ' - ' + UPPER(SO.DESCRIPCION_STATUS)" &
                            "END, " &
                        "OD.DESCRIPCION_OPERACION_DEFINIDA, " &
                        "ISNULL(RTRIM(LTRIM(UPPER(CL.NOMBRE_CLIENTE))),'') + '-' + ISNULL(RTRIM(LTRIM(UPPER(APELLIDO_PATERNO))),'') + '-' + ISNULL(RTRIM(LTRIM(UPPER(APELLIDO_MATERNO))),'') AS NOMBRE_ANT " &
                        "FROM TICKET..PRODUCTO_CONTRATADO PC, TICKET..OPERACION OP, CATALOGOS..AGENCIA AG, CUENTA_EJE CE, TIPO_CUENTA_EJE TCE," &
                             "CATALOGOS..CLIENTE CL, TICKET..STATUS_OPERACION SO, OPERACION_DEFINIDA OD "
            gs_Sql = gs_Sql & "WHERE convert(varchar(7),OP.OPERACION) IN (" & txtTicket.Text & ") " &
                        "AND OP.OPERACION_DEFINIDA = 8100 " &
                        "AND OP.STATUS_OPERACION = 4 " &
                        "AND OP.PRODUCTO_CONTRATADO = PC.PRODUCTO_CONTRATADO " &
                        "AND PC.STATUS_PRODUCTO = 8001 " &
                        "AND PC.AGENCIA = 1 " &
                        "AND PC.AGENCIA = AG.AGENCIA " &
                        "AND PC.PRODUCTO_CONTRATADO = CE.PRODUCTO_CONTRATADO AND CE.TIPO_CUENTA_EJE = TCE.TIPO_CUENTA_EJE " &
                        "AND CL.CUENTA_CLIENTE = PC.CUENTA_CLIENTE " &
                        "AND CL.PERSONA_MORAL = 0 " &
                        "AND (CL.APELLIDO_MATERNO IS NULL OR CL.APELLIDO_MATERNO = '') " &
                        "AND OP.STATUS_OPERACION = SO.STATUS_OPERACION " &
                        "AND OP.OPERACION_DEFINIDA = OD.OPERACION_DEFINIDA "
        End If
        gs_Sql = gs_Sql & "ORDER BY OP.OPERACION"
        'Ejecutar el SP de consulta para los ticket
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        cmdAplicar.Enabled = False
        cmdLimpiar.Enabled = False
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
            msfgOperaciones0.DataSource = Nothing
            If msfgOperaciones0.Columns.Count > 0 Then
                msfgOperaciones0.Columns.RemoveAt(0)
            End If
            msfgOperaciones0.DataSource = dtRespConsulta
        End If
        '        If dbError() And bolNoEncontroTicket = False Then bolNoEncontroTicket = True
        '        Do While Not dbError()
        '            txtTicket.Enabled = False
        '            cmdBuscar.Enabled = False
        '            cmdLimpiar.Enabled = True
        '            If intContador = 1 Then
        '                msfgOperaciones0.TextMatrix(intContador, 0) = dbGetValue(0)
        '            Else
        '                msfgOperaciones(0).AddItem dbGetValue(0)
        '        End If
        '            msfgOperaciones(0).TextMatrix(intContador, 1) = Trim(dbGetValue(1))
        '            msfgOperaciones(0).TextMatrix(intContador, 2) = Trim(dbGetValue(2))
        '            msfgOperaciones(0).TextMatrix(intContador, 3) = UCase(Trim(dbGetValue(3)))
        '            msfgOperaciones(0).TextMatrix(intContador, 4) = UCase(Trim(dbGetValue(4)))
        '            msfgOperaciones(0).TextMatrix(intContador, 5) = UCase(Trim(dbGetValue(5)))
        '            msfgOperaciones(0).TextMatrix(intContador, 6) = UCase(Trim(dbGetValue(6)))
        '            ReDim Preserve arrNombreAct(intContador)
        '            ReDim Preserve arrNombreAnt(intContador)
        '            arrNombreAnt(intContador) = UCase(Trim(dbGetValue(7)))
        '            arrNombreAct(intContador) = UCase(Trim(dbGetValue(7)))
        '            dbGetRecord
        '            intContador = intContador + 1
        '            msfgOperaciones(0).Refresh
        '        Loop
        '        dbEndQuery
        '        intCuentaVueltas = intCuentaVueltas + 1
        '        cmdLimpiar.Enabled = True
        '        msfgOperaciones(0).Enabled = True
        'End While 'Wend
        If bolNoEncontroTicket Then
            If False Then 'If Permiso("PMANTTKTOPER") Then
                MsgBox("Aviso: 1 o varios de los tickets no se pueden mostrar por: " & vbCrLf & vbCrLf &
                        "1.-El ticket no existe" & vbCrLf &
                        "2.-La cuenta no pertenece a la agencia Houston" & vbCrLf &
                        "3.-Son operaciones no permitidas en esta pantalla" & vbCrLf & vbCrLf &
                        "Favor de verificar", vbInformation + vbOKOnly, "Busqueda de ticket")
            ElseIf True Then 'ElseIf Permiso("PMANTTKTAPER") Then
                MsgBox("Aviso: 1 o varios de los tickets no se pueden mostrar por: " & vbCrLf & vbCrLf &
                        "1.-La operación no ha sido validada en Equation " & vbCrLf &
                        "2.-El ticket no corresponde a una apertura" & vbCrLf &
                        "3.-La cuenta no esta activa" & vbCrLf &
                        "4.-La cuenta no pertenece a la agencia Houston" & vbCrLf &
                        "5.-Es una persona moral" & vbCrLf &
                        "6.-No necesite mantenimiento de apellido materno" & vbCrLf & vbCrLf &
                        "7.-El ticket no existe" & vbCrLf &
                        "8.-Son operaciones no permitidas en esta pantalla" & vbCrLf & vbCrLf &
                        "Favor de verificar", vbInformation + vbOKOnly, "Busqueda de ticket")
            End If
        End If
        Dim asListaEstatus() As String = {" 1 - PENDIENTE DE VALIDAR ", " 2 - VALIDADO ", " 3 - PENDIENTE DE RECIBIR ", " 4 - VALIDADO EQ ", " 250 - CANCELADO "}
        'Dim dgvcbcNuevaColumna As New DataGridViewComboBoxColumn()
        'dgvcbcNuevaColumna.DataSource = asListaEstatus
        'dgvcbcNuevaColumna.Width = 150
        'dgvcbcNuevaColumna.HeaderText = "NUEVO_ESTATUS"
        'dgvcbcNuevaColumna.DisplayIndex = 6
        'Dim ver = dgvcbcNuevaColumna.ValueMember
        'msfgOperaciones0.Columns.Add(dgvcbcNuevaColumna)
        'ShowDefaultCursor
    End Sub
    Public Sub ActualizaUltimoMovimiento()
        'DGI 03-07-2007
        'dbExecQuery "SELECT CONVERT(VARCHAR(50),GETDATE(),120)"
        'dbGetRecord
        'strgFechaUltAccion = Format(dbGetValue(0), "dd-mm-yyyy hh:mm:ss")
        'dbEndQuery
        Dim dtRespConsulta As DataTable
        dtRespConsulta = objDatasource.RealizaConsulta("SELECT CONVERT(VARCHAR(50),GETDATE(),120)")
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count <= 0 Then
            strgFechaUltAccion = Format(dtRespConsulta.Rows(0).Item(0), "dd-mm-yyyy hh:mm:ss")
        End If
    End Sub
    Private Sub msfgOperaciones0_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles msfgOperaciones0.CellContentClick
        Dim bAgregaRegistro As Boolean = True
        If msfgOperaciones0.CurrentCell.ColumnIndex = 5 Then
            GsEstatusMantenimientoOperacion = msfgOperaciones0.CurrentCell.Value.ToString
            Dim ComboBoxSelect As New frmComboBox
            ComboBoxSelect.StartPosition = FormStartPosition.CenterScreen
            ComboBoxSelect.ShowDialog()
            If GsEstatusMantenimientoOperacion <> msfgOperaciones0.CurrentCell.Value.ToString Then
                'msfgOperaciones0.CurrentCell.Value = GsEstatusMantenimientoOperacion
                For Each registro As DataRow In dtTablaPrevia.Rows
                    If registro("TICKET").ToString() = msfgOperaciones0.CurrentRow.Cells("TICKET").Value.ToString() Then
                        bAgregaRegistro = False
                        registro("STATUS") = GsEstatusMantenimientoOperacion
                        msfgOperaciones1.Refresh()
                        Exit For
                    End If
                Next
                If bAgregaRegistro Then
                    CrearDataRow(msfgOperaciones0.CurrentRow)
                    msfgOperaciones1.DataSource = Nothing
                    msfgOperaciones1.DataSource = dtTablaPrevia
                End If
            End If
        End If
    End Sub
    Private Sub CrearDataTable()
        dtTablaPrevia.Columns.Add("TICKET")
        dtTablaPrevia.Columns.Add("CUENTA")
        dtTablaPrevia.Columns.Add("CLIENTE")
        dtTablaPrevia.Columns.Add("MONTO")
        dtTablaPrevia.Columns.Add("FECHA")
        dtTablaPrevia.Columns.Add("STATUS")
        dtTablaPrevia.Columns.Add("OPERACION")
    End Sub
    Private Sub CrearDataRow(drRegistroOriginal As DataGridViewRow)
        Dim drRegistro As DataRow = dtTablaPrevia.NewRow()
        drRegistro("TICKET") = drRegistroOriginal.Cells("TICKET").Value.ToString()
        drRegistro("CUENTA") = drRegistroOriginal.Cells("CUENTA").Value.ToString()
        drRegistro("CLIENTE") = drRegistroOriginal.Cells("CLIENTE").Value.ToString()
        drRegistro("MONTO") = drRegistroOriginal.Cells("MONTO").Value.ToString()
        drRegistro("FECHA") = drRegistroOriginal.Cells("FECHA").Value.ToString()
        drRegistro("STATUS") = GsEstatusMantenimientoOperacion
        drRegistro("OPERACION") = drRegistroOriginal.Cells("OPERACION").Value.ToString()
        dtTablaPrevia.Rows.Add(drRegistro)
    End Sub
End Class