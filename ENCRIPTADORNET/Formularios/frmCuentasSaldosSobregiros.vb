Public Class frmCuentasSaldosSobregiros
    Dim strFechaHoy As String
    Dim strFechaInicio As String
    Dim strFechaFin As String
    Dim SFechaIniPar As String
    Dim SFechaFinPar As String


    Private Sub frmCuentasSaldosSobregiros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        'recupera fechas para reporte, a un día habil anterior a la fecha actual.
        strFechaHoy = Date.Now().Date.ToString("yyyy-MM-dd")
        strFechaInicio = strFechaHoy
        strFechaFin = strFechaHoy

        txtFechaIni.Text = strFechaInicio
        'txtFechaFin.Text = strFechaFin



    End Sub

    Private Sub cmdConsultar_Click(sender As Object, e As EventArgs) Handles cmdConsultar.Click
        Dim gs_sqlcount As String
        Dim gs_sqlselect As String
        Dim gs_sql As String
        Dim gs_sqlOK As String
        Dim d As New Datasource
        Dim iHayRegistros As Integer

        Cursor = System.Windows.Forms.Cursors.WaitCursor

        'revisa si hay operaciones de la fecha que se ingreso

        gs_sqlcount = "SELECT COUNT(*) FROM "
        gs_sqlselect = "SELECT * FROM "
        gs_sql = "	( "
        gs_sql &= "		SELECT CL.CUENTA_CLIENTE,  "
        gs_sql &= "		RTRIM(F.NOMBRE_FUNCIONARIO)+ ' ' + RTRIM(F.APELLIDO_PATERNO) + ' ' +  RTRIM(F.APELLIDO_MATERNO) AS GESTOR,  "
        gs_sql &= "		RTRIM(CL.nombre_cliente)+ ' ' + ISNULL(RTRIM(cl.apellido_paterno),'') + ' ' +  ISNULL(RTRIM(cl.apellido_materno),'') AS CLIENTE, "
        gs_sql &= "		CONVERT(DECIMAL(16,2),C.VALOR_CONCEPTO) SALDO, "
        gs_sql &= "			((((((((((((C.VALOR_CONCEPTO +  "
        gs_sql &= "							(SELECT  ISNULL(SUM(monto_operacion),0) FROM OPERACION OP WITH(NOLOCK), OPERACION_DEFINIDA OD WITH(NOLOCK) "
        gs_sql &= "								WHERE OP.producto_contratado = C.PRODUCTO_CONTRATADO "
        gs_sql &= "								AND OP.fecha_operacion = '" & strFechaHoy & "' "
        gs_sql &= "								AND status_operacion IN (2,3,4,5)  "
        gs_sql &= "								AND OP.operacion_definida = OD.operacion_definida  "
        gs_sql &= "								AND operacion_definida_global IN (560, 580, 583, 584, 585, 587, 597,588, "
        gs_sql &= "								589, 590, 591, 592, 680,552, 553, 559)) - "
        gs_sql &= "((SELECT ISNULL(SUM(monto_operacion),0) FROM OPERACION OP With(NOLOCK), OPERACION_DEFINIDA OD With(NOLOCK) "
        gs_sql &= "								WHERE OP.producto_contratado= C.PRODUCTO_CONTRATADO  "
        gs_sql &= "								And OP.fecha_operacion >= '" & strFechaHoy & "' "
        gs_sql &= "								AND status_operacion <> 250  "
        gs_sql &= "								AND OP.operacion_definida = OD.operacion_definida  "
        gs_sql &= "								AND operacion_definida_global IN (60, 65, 83,84, 85, 86, 87, 91, 94, 96, 97, "
        gs_sql &= "								 88, 89, 52, 53, 54, 56, 57, 58, 59)) )-  "
        gs_sql &= "							(SELECT ISNULL(SUM(monto_operacion),0) FROM OPERACION OP WITH(NOLOCK), OPERACION_DEFINIDA OD WITH(NOLOCK) "
        gs_sql &= "								WHERE OP.producto_contratado= C.PRODUCTO_CONTRATADO  "
        gs_sql &= "								AND OP.fecha_operacion < '" & strFechaHoy & "' "
        gs_sql &= "								AND status_operacion IN (0,1,220)  "
        gs_sql &= "								AND OP.operacion_definida = OD.operacion_definida  "
        gs_sql &= "								AND operacion_definida_global IN (80, 83, 85, 86, 87, 91, 94, 96, 97, 88, 89, "
        gs_sql &= "								 180, 52, 53, 54, 56, 57, 58, 59))) -  "
        gs_sql &= "							(SELECT ISNULL(SUM(monto_operacion),0) FROM OPERACION OP WITH(NOLOCK), OPERACION_DEFINIDA OD WITH(NOLOCK), RETIRO_ORDEN_PAGO RO WITH(NOLOCK) "
        gs_sql &= "								WHERE OP.producto_contratado= C.PRODUCTO_CONTRATADO "
        gs_sql &= "								AND OP.fecha_operacion >= '" & strFechaHoy & "' "
        gs_sql &= "								AND status_operacion <> 250  "
        gs_sql &= "								AND OP.operacion = RO.operacion  "
        gs_sql &= "								AND OP.operacion_definida = OD.operacion_definida  "
        gs_sql &= "								AND operacion_definida_global = 81  "
        gs_sql &= "								AND RO.sujeto_a_recepcion = 0  "
        gs_sql &= "								AND RO.parcialmente_sujeto = 0))- "
        gs_sql &= "							(SELECT ISNULL(SUM(monto_operacion),0) FROM OPERACION OP WITH(NOLOCK), OPERACION_DEFINIDA OD WITH(NOLOCK), RETIRO_ORDEN_PAGO RO WITH(NOLOCK) "
        gs_sql &= "								WHERE OP.producto_contratado = C.PRODUCTO_CONTRATADO  "
        gs_sql &= "								AND OP.fecha_operacion < '" & strFechaHoy & "' "
        gs_sql &= "								AND status_operacion in (0,1)  "
        gs_sql &= "								AND OP.operacion= RO.operacion  "
        gs_sql &= "								AND OP.operacion_definida = OD.operacion_definida "
        gs_sql &= "								AND operacion_definida_global = 81  "
        gs_sql &= "								AND RO.sujeto_a_recepcion = 0 AND RO.parcialmente_sujeto = 0)) - "
        gs_sql &= "							(SELECT ISNULL(SUM(monto_operacion),0) FROM OPERACION OP WITH(NOLOCK), COMPRA_CD CC WITH(NOLOCK), OPERACION_DEFINIDA OD WITH(NOLOCK) "
        gs_sql &= "								WHERE OP.producto_contratado = C.PRODUCTO_CONTRATADO  "
        gs_sql &= "								AND OP.fecha_operacion >= '" & strFechaHoy & "'  "
        gs_sql &= "								AND status_operacion <> 250  "
        gs_sql &= "								AND status_operacion >= 0  "
        gs_sql &= "								AND OP.operacion_definida = OD.operacion_definida  "
        gs_sql &= "								AND operacion_definida_global = 80  "
        gs_sql &= "								AND CC.renovacion = 2  "
        gs_sql &= "								AND CC.origen NOT IN (1,7) "
        gs_sql &= "								AND OP.operacion = CC.operacion)) - "
        gs_sql &= "							(SELECT ISNULL(SUM(monto_operacion),0) FROM OPERACION OP WITH(NOLOCK), COMPRA_CD CC WITH(NOLOCK), OPERACION_DEFINIDA OD  WITH(NOLOCK) "
        gs_sql &= "								WHERE OP.producto_contratado = C.PRODUCTO_CONTRATADO "
        gs_sql &= "								AND OP.fecha_operacion = '" & strFechaHoy & "'  "
        gs_sql &= "								AND status_operacion <> 250  "
        gs_sql &= "								AND status_operacion >= 0  "
        gs_sql &= "								AND OP.operacion_definida = OD.operacion_definida  "
        gs_sql &= "								AND operacion_definida_global = 80  "
        gs_sql &= "								AND CC.renovacion <> 2  "
        gs_sql &= "								AND OP.operacion = CC.operacion   "
        gs_sql &= "								AND CC.origen NOT IN (1,7))) - "
        gs_sql &= "							(SELECT ISNULL(SUM(monto_operacion),0) FROM OPERACION OP WITH(NOLOCK), COMPRA_CD CC WITH(NOLOCK), OPERACION_DEFINIDA OD  WITH(NOLOCK) "
        gs_sql &= "								WHERE OP.producto_contratado = C.PRODUCTO_CONTRATADO "
        gs_sql &= "								AND OP.fecha_operacion > '" & strFechaHoy & "'  "
        gs_sql &= "								AND status_operacion <> 250  "
        gs_sql &= "								AND status_operacion >= 2  "
        gs_sql &= "								AND OP.operacion_definida = OD.operacion_definida  "
        gs_sql &= "								AND operacion_definida_global = 80  "
        gs_sql &= "								AND CC.renovacion <> 2  "
        gs_sql &= "								AND OP.operacion = CC.operacion   "
        gs_sql &= "								AND CC.origen NOT IN (1,7)))- "
        gs_sql &= "							(SELECT ISNULL(SUM(monto_operacion),0) FROM OPERACION OP WITH(NOLOCK), COMPRA_TD_OVERNIGHT CTO WITH(NOLOCK), OPERACION_DEFINIDA OD  WITH(NOLOCK) "
        gs_sql &= "								WHERE OP.producto_contratado = C.PRODUCTO_CONTRATADO  "
        gs_sql &= "								AND OP.fecha_operacion = '" & strFechaHoy & "'  "
        gs_sql &= "								AND status_operacion <> 250  "
        gs_sql &= "								AND OP.operacion_definida = OD.operacion_definida  "
        gs_sql &= "								AND OD.operacion_definida_global = 180  "
        gs_sql &= "								AND OP.operacion = CTO.operacion  "
        gs_sql &= "								AND CTO.origen NOT IN(1,7))) - "
        gs_sql &= "							(SELECT ISNULL(SUM(monto_operacion),0) FROM OPERACION OP WITH(NOLOCK), COMPRA_TD_OVERNIGHT CTO WITH(NOLOCK), OPERACION_DEFINIDA OD WITH(NOLOCK) "
        gs_sql &= "								WHERE OP.producto_contratado = C.PRODUCTO_CONTRATADO "
        gs_sql &= "								AND OP.fecha_operacion > '" & strFechaHoy & "'  "
        gs_sql &= "								AND status_operacion <> 250  "
        gs_sql &= "								AND status_operacion >= 2  "
        gs_sql &= "								AND OP.operacion_definida = OD.operacion_definida  "
        gs_sql &= "								AND OD.operacion_definida_global = 180  "
        gs_sql &= "								AND OP.operacion = CTO.operacion  "
        gs_sql &= "								AND CTO.origen not in (1,7))) - "
        gs_sql &= "							(SELECT ISNULL(SUM(monto_operacion),0) FROM OPERACION OP WITH(NOLOCK), OPERACION_DEFINIDA OD WITH(NOLOCK) "
        gs_sql &= "								WHERE OP.producto_contratado = C.PRODUCTO_CONTRATADO  "
        gs_sql &= "								AND OP.fecha_operacion = '" & strFechaHoy & "'  "
        gs_sql &= "								AND status_operacion <> 250  "
        gs_sql &= "								AND OP.operacion_definida= OD.operacion_definida  "
        gs_sql &= "								AND operacion_definida_global =  95))) + "
        gs_sql &= "							(SELECT ISNULL(SUM(monto_operacion),0) FROM OPERACION OP WITH(NOLOCK), OPERACION_DEFINIDA OD WITH(NOLOCK) "
        gs_sql &= "								WHERE OP.producto_contratado = C.PRODUCTO_CONTRATADO "
        gs_sql &= "								AND OP.fecha_operacion = '" & strFechaHoy & "'  "
        gs_sql &= "								AND status_operacion <> 250  "
        gs_sql &= "								AND OP.operacion_definida= OD.operacion_definida  "
        gs_sql &= "								AND operacion_definida_global =  595)) - "
        gs_sql &= "							((SELECT ISNULL(SUM(valor_concepto),0)  "
        gs_sql &= "                           FROM CONCEPTO CH WITH(NOLOCK), CONCEPTO_DEFINIDO CDH WITH(NOLOCK), PRODUCTO_CONTRATADO PCH WITH(NOLOCK),  "
        gs_sql &= " 						       STATUS_PRODUCTO SPH WITH(NOLOCK), PRODUCTO PCTA WITH(NOLOCK), PRODUCTO_CONTRATADO PCCTA WITH(NOLOCK) "
        gs_sql &= "								WHERE PCH.producto_contratado = CH.producto_contratado  "
        gs_sql &= "								AND PCH.producto = CDH.producto  "
        gs_sql &= "								AND PCH.agencia = CDH.agencia  "
        gs_sql &= "								AND CDH.concepto_definido = CH.concepto_definido  "
        gs_sql &= "								AND CDH.concepto_definido_global in(10, 20)  "
        gs_sql &= "								AND SPH.status_producto = PCH.status_producto  "
        gs_sql &= "								AND SPH.producto = PCH.producto  "
        gs_sql &= "								AND SPH.agencia = PCH.agencia  "
        gs_sql &= "								AND SPH.status_producto_global IN(2, 7)  "
        gs_sql &= "								AND PCCTA.agencia = PCH.agencia  "
        gs_sql &= "								AND PCCTA.cuenta_cliente = PCH.cuenta_cliente  "
        gs_sql &= "								AND PCTA.producto = PCCTA.producto  "
        gs_sql &= "								AND PCTA.agencia = PCCTA.agencia  "
        gs_sql &= "								AND PCTA.producto_global = 9  "
        gs_sql &= "								AND PCCTA.producto_contratado = C.PRODUCTO_CONTRATADO)) + "
        gs_sql &= "							(SELECT ISNULL(SUM (monto_operacion),0) FROM OPERACION OP WITH(NOLOCK), OPERACION_DEFINIDA OD WITH(NOLOCK) "
        gs_sql &= "								WHERE OP.producto_contratado =  C.PRODUCTO_CONTRATADO "
        gs_sql &= "								AND OP.fecha_operacion = '" & strFechaHoy & "'  "
        gs_sql &= "								AND status_operacion in (1,220) "
        gs_sql &= "								AND OP.operacion_definida= OD.operacion_definida "
        gs_sql &= "								AND OD.operacion_definida_global in (583,589,590,591, "
        gs_sql &= "								552, 553, 559))  "
        gs_sql &= "							) AS SALDO_DISPONIBLE "
        gs_sql &= "		, CONVERT(DECIMAL(16,2),(dbo.fn_saldos_disponibles(1,C.PRODUCTO_CONTRATADO,'" & strFechaHoy & "')))AS DEPOSITOS "
        gs_sql &= "		, CONVERT(DECIMAL(16,2),(dbo.fn_saldos_disponibles(2,C.PRODUCTO_CONTRATADO,'" & strFechaHoy & "')))AS RETIROS "
        gs_sql &= "		, CONVERT(DECIMAL(16,2),(dbo.fn_saldos_disponibles(3,C.PRODUCTO_CONTRATADO,'" & strFechaHoy & "')))AS RENOVACIONES "
        gs_sql &= "		, CONVERT(DECIMAL(16,2),(dbo.fn_saldos_disponibles(4,C.PRODUCTO_CONTRATADO,'" & strFechaHoy & "')))AS RETENCIONES "
        gs_sql &= "		, PC.producto_contratado  "
        gs_sql &= "		FROM CONCEPTO C WITH(NOLOCK) "
        gs_sql &= "		INNER JOIN CONCEPTO_DEFINIDO CD WITH(NOLOCK) "
        gs_sql &= "		ON CD.concepto_definido= C.concepto_definido  "
        gs_sql &= "		INNER JOIN PRODUCTO_CONTRATADO PC WITH(NOLOCK) "
        gs_sql &= "		ON C.producto_contratado = PC.producto_contratado "
        gs_sql &= "		INNER JOIN STATUS_PRODUCTO SP WITH(NOLOCK) "
        gs_sql &= "		ON PC.status_producto = SP.status_producto "
        gs_sql &= "		INNER JOIN CATALOGOS..CLIENTE CL WITH(NOLOCK) "
        gs_sql &= "		ON PC.cuenta_cliente = CL.cuenta_cliente "
        gs_sql &= "		INNER JOIN FUNCIONARIOS..FUNCIONARIO F WITH(NOLOCK) "
        gs_sql &= "		ON CL.funcionario = F.funcionario "
        gs_sql &= "		WHERE C.concepto_definido  =  8005 "
        gs_sql &= "		AND CD.concepto_definido_global =5 "
        gs_sql &= "		AND CD.producto = 8009 "
        gs_sql &= "		AND CD.agencia = 1 "
        gs_sql &= "		AND SP.status_producto = 8001 "
        gs_sql &= "		AND CL.agencia = 1 "
        gs_sql &= "		)TABLA_TEMPORAL "
        gs_sql &= "		where SALDO_DISPONIBLE < 0.000 "
        'gs_sql &= "		ORDER BY 3,4, cuenta_cliente	 " '-------------------------- RACB 20-05-2021


        gs_sqlOK = gs_sqlcount & gs_sql


        iHayRegistros = d.HayRegistros(gs_sqlOK)
        If iHayRegistros > 0 Then
            gs_sqlOK = gs_sqlselect & gs_sql
            dgvSaldosSobregiros.DataSource = d.RealizaConsulta(gs_sqlOK)
            cmdImprimir.Enabled = True

        End If

    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        Dim SFechaIniPar As String
        Dim SFechaFinPar As String

        fe_Inicio = txtFechaIni.Text
        'realiza la extracción de la información - Fecha Inicio
        opcionReporte = 13    'reporte de Cuentas con Saldo Sobregiro
        'ls_PorImprimir = "'
        RepOperativa.ShowDialog()

    End Sub
End Class