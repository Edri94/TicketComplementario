Public Class frmRepOperRelev
    Dim iRegistrosD As Integer = 0
    Dim iRegistrosR As Integer = 0

    Private Sub frmRepOperRelev_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        txtFechaIni.Text = Now().ToString("yyyy-MM-dd")
        txtFechaFin.Text = Now().ToString("yyyy-MM-dd")
        txtMontoIni.Text = "7500.00"
        txtMontoFin.Text = "100000.00"
        cmdBuscar.Enabled = True
    End Sub

    Private Sub cmdBuscar_Click(sender As Object, e As EventArgs) Handles cmdBuscar.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        'limpiamos el control del grid
        dgvDepositosRetiros.DataSource = ""

        If ValidaDatos() Then
            If Not LlenaGridDepositosRetiros() Then
                cmdImprimir.Enabled = False
            Else
                'activa boton de imprimir
                cmdImprimir.Enabled = True
            End If
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        Dim iMontoIni As Integer = 0
        Dim iMontoFin As Integer = 0

        fe_Inicio = Trim(txtFechaIni.Text)
        fe_Fin = Trim(txtFechaFin.Text)
        iMontoIni = Trim(txtMontoIni.Text)
        iMontoFin = Trim(txtMontoFin.Text)

        Cursor = System.Windows.Forms.Cursors.WaitCursor

        'arma el query que se pasara al reporte
        ls_PorImprimir = ""
        ls_PorImprimir = " {OPERACION.fecha_captura} > datetime (" & fe_Inicio.Substring(0, 4).Trim & "," & fe_Inicio.Substring(5, 2).Trim & "," & fe_Inicio.Substring(8, 2).Trim & ",00,01,00)" '------- RACB 22-12-2022 //Se cambia al tipo datatime y se agregan los limites de horas
        ls_PorImprimir &= " and {OPERACION.fecha_captura} < datetime (" & fe_Fin.Substring(0, 4).Trim & "," & fe_Fin.Substring(5, 2).Trim & "," & fe_Fin.Substring(8, 2).Trim & ",23,58,00)" '------- RACB 22-12-2022 //Se cambia al tipo datatime y se agregan los limites de horas
        ls_PorImprimir &= " and {OPERACION.monto_operacion} >= " & iMontoIni & ""
        ls_PorImprimir &= " and {OPERACION.monto_operacion} <= " & iMontoFin & ""
        'ls_PorImprimir &= " and {PRODUCTO_CONTRATADO.producto} in [8009, 2009, 3009]"
        ls_PorImprimir &= " and {TIPO_DOCUMENTO.tipo_documento} in [5, 9, 19, 22, 30, 43, 44, 1, 2,15, 16, 27, 28, 42, 68, 26, 39, 63, 121, 116, 124]"
        ls_PorImprimir &= " and {OPERACION.status_operacion} <> 250 "
        ls_PorImprimir &= " and {AGENCIA.agencia}=1 "

        'imprime retiros
        If iRegistrosR >= 0 Then
            opcionReporte = 2    'reporte de Operaciones relevantes Retiros
            RepOperativa.ShowDialog()
        End If

        'imprime depositos
        If iRegistrosD >= 0 Then
            opcionReporte = 3    'reporte de Operaciones relevantes Retiros
            RepOperativa.ShowDialog()
        End If

        Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub


#Region "Funciones"
    Function ValidaDatos() As Boolean
        Dim montoi As Integer
        Dim montof As Integer

        ValidaDatos = False

        If Trim(txtFechaIni.Text) = "" Or txtFechaIni.Text.Trim.Length > 10 Or txtFechaIni.Text.Trim.Length < 10 Then
            MsgBox("Es necesario indicar una fecha de captura inicial.", MsgBoxStyle.Information, "Fecha Faltante")
            txtFechaIni.Select()
            Exit Function
        End If
        If txtFechaIni.Text.Trim.Length > 10 Or txtFechaIni.Text.Trim.Length < 10 Then
            MsgBox("La fecha Inicial NO es una fecha Valida", MsgBoxStyle.Information, "Fecha Faltante")
            txtFechaIni.Select()
            Exit Function
        End If

        If Trim(txtFechaFin.Text) = "" Then
            MsgBox("Es necesario indicar una fecha de captura final.", MsgBoxStyle.Information, "Fecha Faltante")
            txtFechaFin.Select()
            Exit Function
        End If
        If txtFechaFin.Text.Trim.Length > 10 Or txtFechaFin.Text.Trim.Length < 10 Then
            MsgBox("La fecha Final NO es una fecha Valida", MsgBoxStyle.Information, "Fecha Faltante")
            txtFechaFin.Select()
            Exit Function
        End If


        If Convert.ToDateTime(txtFechaIni.Text) > Convert.ToDateTime(txtFechaFin.Text) Then
            MsgBox("La fecha final del periodo debe ser mayor o igual a la fecha inicial.", MsgBoxStyle.Information, "Fecha Invalida")
            txtFechaFin.Select()
            Exit Function
        End If

        If Trim(txtMontoIni.Text) = "" Then
            MsgBox("El monto inicial del periodo debe ser mayor o igual a cero..", MsgBoxStyle.Information, "Monto Invalido")
            txtMontoIni.Select()
            Exit Function
        End If
        If Trim(txtMontoFin.Text) = "" Then
            MsgBox("El monto final del periodo debe ser mayor o igual a cero..", MsgBoxStyle.Information, "Monto Invalido")
            txtMontoFin.Select()
            Exit Function
        End If

        montoi = txtMontoIni.Text
        montof = txtMontoFin.Text

        If (montoi > montof) Then
            MsgBox("El monto final debe ser mayor o igual al monto inicial.", MsgBoxStyle.Information, "Monto Invalido")
            txtMontoFin.Select()
            Exit Function
        End If

        ValidaDatos = True

    End Function

    Function LlenaGridDepositosRetiros() As Boolean
        Dim gs_sql As String
        Dim d As New Datasource
        Dim dctas = New Datasource

        LlenaGridDepositosRetiros = False

        If buscaDepositosRetiros() Then

            'arma el query para presentar en el grid
            'buscamos si hubo registros en tabal de saldos SALDO_CTA_000
            gs_sql = " SELECT  'DEPOSITO' AS TIPO_OPER, CL.nombre_cliente, CL.apellido_paterno, CL.apellido_materno, AG.prefijo_agencia, PC.cuenta_cliente, TCE.sufijo_kapiti, "
            gs_sql &= " OP.fecha_captura, OP.fecha_operacion, TM.descripcion_moneda, DPME.nombre_plaza, DPME.plaza, DPME.nombre_sucursal, "
            gs_sql &= " DPME.sucursal, DPME.referencia, OP.monto_operacion, OP.operacion, AG.descripcion_agencia, SP.descripcion_status, "
            gs_sql &= " OD.descripcion_operacion_definida, TD.descripcion_documento, OP.operacion_definida "
            gs_sql &= " FROM   ((((((((((CATALOGOS.dbo.AGENCIA AG "
            gs_sql &= " INNER JOIN CATALOGOS.dbo.CLIENTE CL ON AG.agencia=CL.agencia) "
            gs_sql &= " INNER JOIN TICKET.dbo.PRODUCTO_CONTRATADO PC ON CL.cuenta_cliente=PC.cuenta_cliente) "
            gs_sql &= " INNER JOIN TICKET.dbo.OPERACION OP ON PC.producto_contratado=OP.producto_contratado) "
            gs_sql &= " INNER JOIN TICKET.dbo.STATUS_PRODUCTO SP ON PC.status_producto=SP.status_producto) "
            gs_sql &= " INNER JOIN TICKET.dbo.DEPOSITO_PME DPME ON OP.operacion=DPME.operacion) "
            gs_sql &= " INNER JOIN TICKET.dbo.OPERACION_DEFINIDA OD ON OP.operacion_definida=OD.operacion_definida) "
            gs_sql &= " INNER JOIN TICKET.dbo.CUENTA_EJE CE ON OP.producto_contratado=CE.producto_contratado) "
            gs_sql &= " INNER JOIN TICKET.dbo.DEPOSITO DE ON DPME.operacion=DE.operacion) "
            gs_sql &= " INNER JOIN TICKET.dbo.TIPO_DOCUMENTO TD ON DE.tipo_documento=TD.tipo_documento) "
            gs_sql &= " Left OUTER JOIN TICKET.dbo.TIPO_MONEDA TM ON DE.tipo_moneda=TM.tipo_moneda) "
            gs_sql &= " INNER JOIN TICKET.dbo.TIPO_CUENTA_EJE TCE ON CE.tipo_cuenta_eje=TCE.tipo_cuenta_eje "
            gs_sql &= " where OP.fecha_captura > '" & Trim(txtFechaIni.Text) & " 00:01' "
            gs_sql &= " And OP.fecha_captura < '" & Trim(txtFechaFin.Text) & " 23:59' "
            gs_sql &= " And OP.monto_operacion >= " & Trim(txtMontoIni.Text)
            gs_sql &= " And OP.monto_operacion <= " & Trim(txtMontoFin.Text)
            gs_sql &= " And OP.status_operacion <> 250 "
            gs_sql &= " And AG.agencia=1 "
            gs_sql &= " And TD.tipo_documento in (5, 9, 19, 22, 30, 43, 44, 1, 2,15, 16, 27, 28, 42, 68, 26, 39, 63, 121, 116, 124) "
            gs_sql &= " union "
            gs_sql &= " Select 'RETIRO' AS TIPO_OPER, CL.nombre_cliente, CL.apellido_paterno, CL.apellido_materno, AG.prefijo_agencia, PC.cuenta_cliente, TCE.sufijo_kapiti, "
            gs_sql &= " OP.fecha_operacion, OP.fecha_captura, TM.descripcion_moneda, RPME.nombre_plaza, RPME.plaza, RPME.nombre_sucursal, "
            gs_sql &= " RPME.sucursal, RPME.referencia, OP.monto_operacion, OP.operacion, AG.descripcion_agencia, SP.descripcion_status, "
            gs_sql &= " OD.descripcion_operacion_definida, TD.descripcion_documento, OP.operacion_definida "
            gs_sql &= " FROM   (((((((((CATALOGOS.dbo.AGENCIA AG "
            gs_sql &= " INNER JOIN CATALOGOS.dbo.CLIENTE CL ON AG.agencia=CL.agencia) "
            gs_sql &= " INNER JOIN TICKET.dbo.PRODUCTO_CONTRATADO PC ON CL.cuenta_cliente=PC.cuenta_cliente) "
            gs_sql &= " INNER JOIN TICKET.dbo.OPERACION OP ON PC.producto_contratado=OP.producto_contratado) "
            gs_sql &= " INNER JOIN TICKET.dbo.STATUS_PRODUCTO SP ON PC.status_producto=SP.status_producto) "
            gs_sql &= " INNER JOIN TICKET.dbo.OPERACION_DEFINIDA OD ON OP.operacion_definida=OD.operacion_definida) "
            gs_sql &= " INNER JOIN TICKET.dbo.RETIRO_PME RPME ON OP.operacion=RPME.operacion) "
            gs_sql &= " INNER JOIN TICKET.dbo.CUENTA_EJE CE ON OP.producto_contratado=CE.producto_contratado) "
            gs_sql &= " INNER JOIN TICKET.dbo.TIPO_CUENTA_EJE TCE ON CE.tipo_cuenta_eje=TCE.tipo_cuenta_eje) "
            gs_sql &= " Left OUTER JOIN TICKET.dbo.TIPO_MONEDA TM ON RPME.tipo_moneda=TM.tipo_moneda) "
            gs_sql &= " INNER JOIN TICKET.dbo.TIPO_DOCUMENTO TD ON RPME.tipo_documento=TD.tipo_documento"
            gs_sql &= " where OP.fecha_captura > '" & Trim(txtFechaIni.Text) & " 00:01' "
            gs_sql &= " And OP.fecha_captura < '" & Trim(txtFechaFin.Text) & " 23:59' "
            gs_sql &= " And OP.monto_operacion >= " & Trim(txtMontoIni.Text)
            gs_sql &= " And OP.monto_operacion <= " & Trim(txtMontoFin.Text)
            gs_sql &= " And OP.status_operacion <> 250 "
            gs_sql &= " And AG.agencia=1 "
            gs_sql &= " And TD.tipo_documento in (5, 9, 19, 22, 30, 43, 44, 1, 2,15, 16, 27, 28, 42, 68, 26, 39, 63, 121, 116, 124) "
            gs_sql &= " ORDER BY AG.prefijo_agencia, SP.descripcion_status, OD.descripcion_operacion_definida, TD.descripcion_documento "

            dgvDepositosRetiros.DataSource = dctas.RealizaConsulta(gs_sql)
            dgvDepositosRetiros.Columns("monto_operacion").DefaultCellStyle.Format = "N2" 'RACB 13/04/2021
        Else
            LlenaGridDepositosRetiros = False
        End If

        LlenaGridDepositosRetiros = True
    End Function

    Function buscaDepositosRetiros() As Boolean
        Dim gs_sql As String
        Dim d As New Datasource
        Dim dctas = New Datasource
        iRegistrosD = 0
        iRegistrosR = 0

        buscaDepositosRetiros = False

        'busca depositos
        gs_sql = "Select COUNT(*) FROM((((((((((CATALOGOS.dbo.AGENCIA AG "
        gs_sql &= " INNER Join CATALOGOS.dbo.CLIENTE CL On AG.agencia=CL.agencia) "
        gs_sql &= " INNER Join TICKET.dbo.PRODUCTO_CONTRATADO PC On CL.cuenta_cliente=PC.cuenta_cliente) "
        gs_sql &= " INNER Join TICKET.dbo.OPERACION OP On PC.producto_contratado=OP.producto_contratado) "
        gs_sql &= " INNER Join TICKET.dbo.STATUS_PRODUCTO SP On PC.status_producto=SP.status_producto) "
        gs_sql &= " INNER Join TICKET.dbo.DEPOSITO_PME DPME On OP.operacion=DPME.operacion) "
        gs_sql &= " INNER Join TICKET.dbo.OPERACION_DEFINIDA OD On OP.operacion_definida=OD.operacion_definida) "
        gs_sql &= " INNER Join TICKET.dbo.CUENTA_EJE CE On OP.producto_contratado=CE.producto_contratado) "
        gs_sql &= " INNER Join TICKET.dbo.DEPOSITO DE On DPME.operacion=DE.operacion) "
        gs_sql &= " INNER Join TICKET.dbo.TIPO_DOCUMENTO TD On DE.tipo_documento=TD.tipo_documento) "
        gs_sql &= " Left OUTER JOIN TICKET.dbo.TIPO_MONEDA TM On DE.tipo_moneda=TM.tipo_moneda) "
        gs_sql &= " INNER Join TICKET.dbo.TIPO_CUENTA_EJE TCE On CE.tipo_cuenta_eje=TCE.tipo_cuenta_eje "
        gs_sql &= " where OP.fecha_captura > '" & txtFechaIni.Text & " 00:01' "
        gs_sql &= " And OP.fecha_captura < '" & txtFechaFin.Text & " 23:59' "
        gs_sql &= " And OP.monto_operacion >= " & txtMontoIni.Text
        gs_sql &= " And OP.monto_operacion <= " & txtMontoFin.Text
        gs_sql &= " And OP.status_operacion <> 250 "
        gs_sql &= " And AG.agencia = 1 "
        gs_sql &= " And TD.tipo_documento In (5, 9, 19, 22, 30, 43, 44, 1, 2,15, 16, 27, 28, 42, 68, 26, 39, 63, 121, 116, 124) "

        iRegistrosD = d.HayRegistros(gs_sql)

        'busca retiros
        gs_sql = "Select COUNT(*) FROM(((((((((CATALOGOS.dbo.AGENCIA AG "
        gs_sql &= " INNER Join CATALOGOS.dbo.CLIENTE CL ON AG.agencia=CL.agencia) "
        gs_sql &= " INNER Join TICKET.dbo.PRODUCTO_CONTRATADO PC ON CL.cuenta_cliente=PC.cuenta_cliente) "
        gs_sql &= " INNER Join TICKET.dbo.OPERACION OP ON PC.producto_contratado=OP.producto_contratado) "
        gs_sql &= " INNER Join TICKET.dbo.STATUS_PRODUCTO SP ON PC.status_producto=SP.status_producto) "
        gs_sql &= " INNER Join TICKET.dbo.OPERACION_DEFINIDA OD ON OP.operacion_definida=OD.operacion_definida) "
        gs_sql &= " INNER Join TICKET.dbo.RETIRO_PME RPME ON OP.operacion=RPME.operacion) "
        gs_sql &= " INNER Join TICKET.dbo.CUENTA_EJE CE ON OP.producto_contratado=CE.producto_contratado) "
        gs_sql &= " INNER Join TICKET.dbo.TIPO_CUENTA_EJE TCE ON CE.tipo_cuenta_eje=TCE.tipo_cuenta_eje) "
        gs_sql &= " Left OUTER JOIN TICKET.dbo.TIPO_MONEDA TM ON RPME.tipo_moneda=TM.tipo_moneda) "
        gs_sql &= " INNER Join TICKET.dbo.TIPO_DOCUMENTO TD ON RPME.tipo_documento=TD.tipo_documento "
        gs_sql &= " where OP.fecha_captura > '" & txtFechaIni.Text & " 00:01' "
        gs_sql &= " And OP.fecha_captura < '" & txtFechaFin.Text & " 23:59' "
        gs_sql &= " And OP.monto_operacion >= " & txtMontoIni.Text
        gs_sql &= " And OP.monto_operacion <= " & txtMontoFin.Text
        gs_sql &= " And OP.status_operacion <> 250 "
        gs_sql &= " And AG.agencia=1 "
        gs_sql &= " And TD.tipo_documento in (5, 9, 19, 22, 30, 43, 44, 1, 2,15, 16, 27, 28, 42, 68, 26, 39, 63, 121, 116, 124) "


        iRegistrosR = d.HayRegistros(gs_sql)

        'suma depositos y retiros.
        If (iRegistrosD + iRegistrosR) > 0 Then
            buscaDepositosRetiros = True
        Else
            MsgBox("No existen operaciones con los parametros indicados", MsgBoxStyle.Information, "Sin Operaciones Relevantes")
        End If


    End Function
#End Region

End Class