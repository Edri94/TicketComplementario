Public Class DataSourceModCancelaCtas
    'Funciones 
#Region "Cancelacion y Reactivacion de cuentas"

#Region "Cuenta"
    'Datos de la cuenta 
    Function ObtenDatosCuenta(ByVal sCuenta As String) As DataTable
        Dim d As New Datasource
        Dim s As String
        s = "  Select prefijo_agencia, sufijo_kapiti 
                From CATALOGOS..AGENCIA AG, 
                TICKET..PRODUCTO_CONTRATADO PC, 
                TICKET..CUENTA_EJE CE, 
                TICKET..TIPO_CUENTA_EJE TC 
                Where PC.cuenta_cliente = '" & sCuenta & "'
                 and PC.agencia =  1
                 and AG.agencia = PC.agencia
                 and PC.producto in (8009)
                 and CE.producto_contratado = PC.producto_contratado
                 and TC.tipo_cuenta_eje = CE.tipo_cuenta_eje"
        Return d.Consulta(s, "ObtenStatusCuenta")
    End Function


    Function ExisteHistorico(ByVal sCuenta As String) As String
        Dim d As New Datasource
        Dim s As String
        s = "   Select count(*) From CATALOGOS..HIST_CAN_REAC_CTA 
                Where cuenta_cliente_hist = '" & sCuenta & "'
                and agencia_hist = 1"
        Return d.regresa_count(s, "ExisteHistorico")
    End Function

    'Inserta Historico
    Function InsertaHistorico(ByVal sCuenta As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer

        Query = " INSERT INTO CATALOGOS..HIST_CAN_REAC_CTA
            (cuenta_cliente_hist,agencia_hist)
            VALUES('" & sCuenta & "',1)"
        Registro = d.insertar(Query)
        Return Registro
    End Function

#End Region


    'Funcion llena campos
#Region "Funcion llena campos"
    Function buscaCuenta(ByVal sCuenta As String) As DataTable
        Dim d As New Datasource
        Dim s As String
        s = "  Select PC.producto_contratado, SP.status_producto_global, TC.sufijo_kapiti 
                From TICKET..PRODUCTO_CONTRATADO PC, TICKET..STATUS_PRODUCTO SP, 
                TICKET..PRODUCTO PR, TICKET..CUENTA_EJE CE, 
                TICKET..TIPO_CUENTA_EJE TC 
                Where
                 PC.cuenta_cliente = '" & sCuenta & "'
                 and PC.agencia =  1
                 and PC.status_producto = SP.status_producto
                 and PC.producto = PR.producto
                 and PR.producto_global = 9
                 and PC.producto_contratado = CE.producto_contratado
                 and CE.tipo_cuenta_eje = TC.tipo_cuenta_eje"
        Return d.Consulta(s, "ObtenStatusCuenta")
    End Function
    Function MotivoCta(ByVal sProductoContratado As String) As DataTable
        Dim d As New Datasource
        Dim s As String
        s = "  Select explicacion From TICKET..DETALLE_STATUS
                where producto_contratado = " & sProductoContratado & ""
        Return d.Consulta(s, "MotivoCta")
    End Function
    Function MotivoCtaBloqueada(ByVal sProductoContratado As String) As DataTable
        Dim d As New Datasource
        Dim s As String
        s = "  Select explicacion From TICKET..DETALLE_STATUS
                where producto_contratado = " & sProductoContratado & ""
        Return d.Consulta(s, "MotivoCtaBloqueada")
    End Function

    Function MotivoCtaCancelada(ByVal sProductoContratado As String) As DataTable
        Dim d As New Datasource
        Dim s As String
        s = "  Select top 1 CONVERT(VARCHAR,fecha,103) + ' ' + motivo 
                From TICKET..CANCELA_REACTIVA_CUENTAS
                where producto_contratado =  " & sProductoContratado & " order by fecha desc"
        Return d.Consulta(s, "MotivoCtaCancelada")
    End Function

    Function EsFideicomiso(ByVal sCuenta As String) As String
        Dim d As New Datasource
        Dim s As String
        s = "   select count(DISTINCT cf.cuenta_cliente) as fideicomiso
                From catalogos..cliente_fideicomiso cf with(nolock) 
                join ticket..Producto_contratado pc with(nolock) on cf.cuenta_cliente=pc.cuenta_cliente 
                join ticket..Operacion op with(nolock) on pc.producto_contratado=op.producto_contratado 
			    join ticket..operacion_definida od with(nolock) on op.operacion_definida=od.operacion_definida 
                Where (cf.tipo_operacion ='A' or cf.tipo_operacion ='M') 
                and Cf.cuenta_cliente = '" & sCuenta & "'
                and Cf.agencia =  1"
        Return d.regresa_count(s, "EsFideicomiso")
    End Function

#End Region

    'Funcion del radiobutton de cuenta cancelada
    Function buscaSaldoCta(ByVal sProductoContratado As String) As DataTable
        'La cuenta tiene saldo (acreedor o deudor)
        Dim d As New Datasource
        Dim s As String
        s = "  Select valor_concepto From TICKET..CONCEPTO 
                where producto_contratado = " & sProductoContratado & ""
        Return d.Consulta(s, "buscaSaldoCta")
    End Function

    'Busca productos activos sobre la cuenta
    Function buscaProductosActivos(ByVal sCuenta As String) As DataTable
        Dim d As New Datasource

        Dim s As String

        s = "  Select count (*) 
                From TICKET..PRODUCTO_CONTRATADO PC, TICKET..STATUS_PRODUCTO SP 
                Where
                 PC.cuenta_cliente = '" & sCuenta & "'
                 and PC.agencia = 1
                 and PC.fecha_vencimiento > getdate()
                 and PC.status_producto = SP.status_producto
                 and SP.status_producto_global not in (24,39,41)"
        'MsgBox("query:" & s)
        Return d.Consulta(s, "buscaProductosActivos")
    End Function

    'Accion Guardar
#Region "Guardar"

    Function UltimoStatusCuenta(ByVal sProductoContratado As String) As DataTable
        Dim d As New Datasource
        Dim s As String
        s = "  Select status_anterior From TICKET..CANCELA_REACTIVA_CUENTAS 
                Where producto_contratado =  " & sProductoContratado & " order by fecha desc"
        Return d.Consulta(s, "UltimoStatusCuenta")
    End Function

    Function ActualizaStatusCta(ByVal sStatus As String, ByVal sCuenta As String, ByVal sProductoContratado As String, ByVal sStatusAnterior As String, ByVal optOpcion As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Dim sStatBD As String

        If optOpcion = "Activa" Then sStatBD = "8001"
        If optOpcion = "Cancelada" Then sStatBD = "8039"

        Query = "update TICKET..PRODUCTO_CONTRATADO set    
        status_producto = " & sStatBD & ", 
        fecha_vencimiento = (case 
                            when PC.status_producto in (8001,1) then getdate() 
                            when PC.status_producto in (8039,39) then NULL
                            end)
		From 
		TICKET..PRODUCTO_CONTRATADO PC, 
		TICKET..STATUS_PRODUCTO SP, 
		TICKET..CUENTA_EJE CE
		where
		 PC.cuenta_cliente = '" & sCuenta & "'
		 and PC.producto_contratado =  " & sProductoContratado & "
		 and PC.agencia =  1
		 and PC.producto_contratado = CE.producto_contratado "
        If sStatus = "39" Or sStatus = "8039" Then
            Query = Query & "and SP.status_producto_global = 39"
        ElseIf sStatus = "1" Or sStatus = "8001" Then
            Query = Query & "and SP.status_producto_global = " & sStatusAnterior
        End If
        Query = Query & "  and SP.producto = PC.producto"
        Query = Query & "  and SP.producto = 8009"
        'MsgBox("Query: " & Query)
        Registro = d.insertar(Query)
        Return Registro
    End Function


    Function InsertaDatosReactivaCanc(ByVal sProductoContratado As String, ByVal sStatusOrigen As String, ByVal usuario As String, ByVal sCausa As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = "Insert into TICKET..CANCELA_REACTIVA_CUENTAS 
                 (producto_contratado, status_anterior, usuario, motivo) 
	            values (" & sProductoContratado & "," & sStatusOrigen & " ,'" & usuario & "', '" & sCausa & "')"
        'MsgBox(Query)
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function BloqueoFideicomiso(ByVal sCuenta As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer

        Query = "UPDATE CATALOGOS..CLIENTE_FIDEICOMISO 
                 SET fecha_baja = getdate() , ESTATUS=4  
                 WHERE cuenta_cliente= '" & sCuenta & "'
                 AND agencia =  1"
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function CancelacionCTA(ByVal sCuenta As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = "UPDATE  catalogos..CLIENTE 
                 SET fecha_baja = getdate()
                 where cuenta_cliente ='" & sCuenta & "' 
                 And agencia = 1"

        Registro = d.insertar(Query)
        Return Registro

    End Function

    Function BRNFunCTA(ByVal sCuenta As String) As DataTable
        Dim d As New Datasource

        Dim s As String

        s = "Select rtrim(nombre_funcionario)+' '+rtrim(f.apellido_paterno)+' '+rtrim(f.apellido_materno),
        rtrim(isnull(banca,''))+'\'+rtrim(isnull(division,''))+'\'+rtrim(isnull(cr,''))+'\'+rtrim(isnull(plaza,''))+'\'+rtrim(isnull(sucursal,''))
        From
        Funcionarios.Funcionario.UNIDAD_ORGANIZACIONAL_RESUMEN u,
        Funcionarios..FUNCIONARIO f,
        catalogos ..CLIENTE c
        Where
        c.funcionario = u.funcionario and
        c.funcionario = u.funcionario and
        f.funcionario = u.funcionario and
        c.cuenta_cliente = '" & sCuenta & "'
        and c.agencia = 1"
        'MsgBox("query: " & s)
        Return d.Consulta(s, "BRNFunCTA")
    End Function

    Function CancelacionFideicomiso(ByVal sCuenta As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = "UPDATE catalogos..CLIENTE_FIDEICOMISO 
                     SET fecha_baja = getdate() , ESTATUS=5 
                     WHERE cuenta_cliente =  '" & sCuenta & "'
                     AND agencia = 1"
        Registro = d.insertar(Query)
        Return Registro
    End Function
    'DGI 29-05-2008 PARA LA CANCELACION Y REACTIVACION DE CUENTAS
    '*********************************************************************
    Function CanReCTA1(ByVal sCuenta As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = "UPDATE catalogos..HIST_CAN_REAC_CTA
        SET colonia_cliente_env_hist = (SELECT colonia_cliente FROM catalogos..DIRECCION_ENVIO
        where cuenta_cliente = '" & sCuenta & "'
         and agencia = 1)
        where cuenta_cliente_hist = '" & sCuenta & "'
         and agencia_hist = 1"
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function CanReCTA2(ByVal sCuenta As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = "UPDATE catalogos..HIST_CAN_REAC_CTA
		SET direccion_cliente_env_hist = (SELECT direccion_cliente FROM catalogos..DIRECCION_ENVIO
        where cuenta_cliente = '" & sCuenta & "'
        and agencia = 1 )
        where cuenta_cliente_hist = '" & sCuenta & "'
        and agencia_hist = 1"
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function CanReCTA3(ByVal sCuenta As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = "UPDATE catalogos..HIST_CAN_REAC_CTA
        SET cp_cliente_env_hist = (SELECT cp_cliente FROM catalogos..DIRECCION_ENVIO
                                where cuenta_cliente = '" & sCuenta & "'
                                and agencia = 1)
        where cuenta_cliente_hist = '" & sCuenta & "'
       and agencia_hist = 1"
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function BuscaCTA(ByVal sCuenta As String) As DataTable
        Dim d As New Datasource
        Dim s As String
        s = "Select count(*) From catalogos..DIRECCION_ENVIO 
        where cuenta_cliente = '" & sCuenta & "'
        and agencia = 1"
        Return d.Consulta(s, "BuscaCTA")
    End Function

    Function ExisteDirec(ByVal sCuenta As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = "Update catalogos..DIRECCION_ENVIO set 
               colonia_cliente = 'lsNombreFunc',
               direccion_cliente = 'lsRutaFunc',
               cp_cliente = 'Cta Cancel'
               where
               cuenta_cliente = '" & sCuenta & "'
               and agencia = 1"
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function UpdDirecEnv(ByVal sCuenta As String, ByVal lsRutaFunc As String, ByVal lsNombreFunc As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = "Update catalogos..DIRECCION_ENVIO set 
               colonia_cliente = '" & lsNombreFunc & "',
               direccion_cliente = '" & lsRutaFunc & "',
               cp_cliente = 'Cta Cancel'
               where
               cuenta_cliente = '" & sCuenta & "'
               and agencia = 1"
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function ActualizaDirec(ByVal sCuenta As String, ByVal lsRutaFunc As String, ByVal lsNombreFunc As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = " Insert into catalogos..DIRECCION_ENVIO 
			      ( agencia, cuenta_cliente, direccion_cliente, cp_cliente, colonia_cliente, ubicacion ) 
                  values ( 1,'" & sCuenta & "', '" & lsRutaFunc & "', 'Cta Cancel','" & lsNombreFunc & "' ,0)"
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function InsDirecEnv(ByVal sCuenta As String, ByVal lsRutaFunc As String, ByVal lsNombreFunc As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        If Len(lsRutaFunc) > 180 Then
            lsRutaFunc = lsRutaFunc.Substring(1, 180)
        End If
        Query = "Insert into catalogos..DIRECCION_ENVIO 
			( agencia, cuenta_cliente, direccion_cliente, cp_cliente, colonia_cliente, ubicacion ) 
            values ( 1,'" & sCuenta & "', '" & lsRutaFunc & "', 'Cta Cancel','" & lsNombreFunc & "' ,0 )"
        Registro = d.insertar(Query)
        Return Registro
    End Function


    'Buscamos los funcionarios para actualizarlos
    Function BuscaFun(ByVal sCuenta As String) As DataTable
        Dim d As New Datasource
        Dim s As String
        s = "Select funcionario From catalogos..CLIENTE 
        Where cuenta_cliente = '" & sCuenta & "'
        and agencia = 1"
        Return d.Consulta(s, "BuscaFun")
    End Function

    'DGI 29-05-2008 PARA LA CANCELACION Y REACTIVACION DE CUENTAS
    '*********************************************************************parte2
    Function Asignafun(ByVal sCuenta As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = "UPDATE catalogos ..HIST_CAN_REAC_CTA
        set funcionario_hist = (SELECT funcionario FROM catalogos..CLIENTE
        where cuenta_cliente = '" & sCuenta & "'
        and agencia = 1 )
        where cuenta_cliente_hist = '" & sCuenta & "'
        and agencia_hist = 1"
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function AsignafunCancela(ByVal sCuenta As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = " Update catalogos..CLIENTE set 
        funcionario =  4252 
          From catalogos..CLIENTE c 
        Where
        c.cuenta_cliente = '" & sCuenta & "'
        and c.agencia = 1"
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function Stored(ByVal liNumeroFunc As Integer) As DataTable
        Dim d As New Datasource
        'Dudas********************************
        Dim s As String
        s = "  Exec FUNCIONARIOS..sp_fun_act_on " & liNumeroFunc & ", 1"
        Return d.Consulta(s, "Stored")
    End Function

    Function StatusOP(ByVal msProdCont As Integer) As DataTable
        Dim d As New Datasource
        Dim s As String
        s = " Select status_operacion 
                FROM ticket..OPERACION
                WHERE producto_contratado =" & msProdCont & "
                And operacion_definida = 8100  "
        'MsgBox(s)
        Return d.Consulta(s, "StatusOP")
    End Function
    'VALIDAR IDENTITY
    Function Identity(ByVal msProdCont As Integer) As DataTable
        Dim d As New Datasource
        Dim s As String
        s = " select @@Identity "
        Return d.Consulta(s, "Identity")
    End Function
    'DGI (EDS) Nuevo Reactivación de cuenta
    Function ReactivaCTA(ByVal sCuenta As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = " UPDATE catalogos..CLIENTE
                 SET fecha_alta = getdate(),
                 fecha_baja = NULL
                 WHERE cuenta_cliente='" & sCuenta & "'
                 AND agencia = 1"
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function SreactivaCTA(ByVal sCuenta As Integer, ByVal lsPrefijo As Integer, ByVal lsSufijo As Integer) As DataTable
        Dim d As New Datasource
        Dim s As String
        s = " SELECT OP.operacion, OP.status_operacion 
        FROM PRODUCTO_CONTRATADO PC, OPERACION OP, OPERACION_DEFINIDA OD, PRODUCTO P, 
        CATALOGOS..AGENCIA AG, CUENTA_EJE CE, TIPO_CUENTA_EJE TCE 
        WHERE PC.cuenta_cliente = '" & sCuenta & "' 
        AND PC.producto_contratado = OP.producto_contratado 
        AND P.producto_global = 9 
        AND PC.agencia = P.agencia 
        AND OP.operacion_definida = OD.operacion_definida 
        AND P.agencia = OD.agencia
        AND OD.operacion_definida_global = 100 
        AND PC.agencia = AG.agencia 
        AND AG.prefijo_agencia = '" & lsPrefijo & "' 
		AND PC.producto_contratado = CE.producto_contratado 
		AND CE.tipo_cuenta_eje = TCE.tipo_cuenta_eje
        AND TCE.sufijo_kapiti = '" & lsSufijo & "' "
        Return d.Consulta(s, "SreactivaCTA")
    End Function

    Function sConsOper_Status(ByVal sCuenta As String, ByVal lsPrefijo As Integer, ByVal lsSufijo As Integer) As DataTable
        Dim d As New Datasource
        Dim s As String
        s = " SELECT OP.operacion, OP.status_operacion 
        FROM ticket..PRODUCTO_CONTRATADO PC, ticket..OPERACION OP, ticket..OPERACION_DEFINIDA OD, 
        ticket..PRODUCTO P, CATALOGOS..AGENCIA AG, ticket..CUENTA_EJE CE, ticket..TIPO_CUENTA_EJE TCE 
        WHERE PC.cuenta_cliente = '" & sCuenta & "' 
        AND PC.producto_contratado = OP.producto_contratado 
        AND P.producto_global = 9 
        AND PC.agencia = P.agencia 
        AND OP.operacion_definida = OD.operacion_definida 
        AND P.agencia = OD.agencia
        AND OD.operacion_definida_global = 100 
        AND PC.agencia = AG.agencia 
        AND AG.prefijo_agencia = '" & lsPrefijo & "' 
		AND PC.producto_contratado = CE.producto_contratado 
		AND CE.tipo_cuenta_eje = TCE.tipo_cuenta_eje
        AND TCE.sufijo_kapiti = '" & lsSufijo & "' "
        'MsgBox(s)
        Return d.Consulta(s, "SreactivaCTA")
    End Function

    Function StatusAper(ByVal lnOperacionAper As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = " UPDATE OPERACION SET status_operacion = 6 
		WHERE operacion =  " & lnOperacionAper
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function complementa(ByVal lnOperacionAper As String, ByVal gn_Usuario As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = "   INSERT INTO EVENTO_OPERACION 
		(operacion, fecha_evento, status_operacion, comentario_evento, usuario, tipo_evento) 
        VALUES (" & lnOperacionAper & ", GETDATE(), 6, 'Apertura Complementada por Reactivación de Cuenta', " & gn_Usuario & ", 1)"
        Registro = d.insertar(Query)
        Return Registro
    End Function

    'MERD Activacion de la cuenta
    Function MERDactCTA(ByVal sCuenta As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = " UPDATE catalogos..CLIENTE_FIDEICOMISO 
                     SET fecha_baja = NULL , ESTATUS=1
                     WHERE cuenta_cliente='" & sCuenta & "' 
                     AND agencia =  1 "
        Registro = d.insertar(Query)
        Return Registro
    End Function
    'DGI 29-05-2008 PARA LA CANCELACION Y REACTIVACION DE CUENTAS
    Function CTAhouston(ByVal sCuenta As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = " UPDATE catalogos..CLIENTE
        SET cuenta_houston = (SELECT cuenta_houston_hist FROM catalogos..HIST_CAN_REAC_CTA
        where cuenta_cliente_hist = '" & sCuenta & "'
		and agencia_hist = 1)
        where cuenta_cliente = '" & sCuenta & "'
        and agencia = 1 "
        Registro = d.insertar(Query)
        Return Registro
    End Function
    Function DIRECCION_ENVIO(ByVal sCuenta As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = " UPDATE catalogos..DIRECCION_ENVIO
        SET colonia_cliente = (SELECT colonia_cliente_env_hist FROM catalogos..HIST_CAN_REAC_CTA
                                where cuenta_cliente_hist = '" & sCuenta & "'
                                and agencia_hist = 1)
        where cuenta_cliente = '" & sCuenta & "'
        and agencia = 1 "
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function DIRECCION_ENVIO2(ByVal sCuenta As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = " UPDATE catalogos..DIRECCION_ENVIO
                  SET direccion_cliente = (SELECT direccion_cliente_env_hist FROM catalogos..HIST_CAN_REAC_CTA
                                           where cuenta_cliente_hist = '" & sCuenta & "'
                                           and agencia_hist = 1)
                  where cuenta_cliente = '" & sCuenta & "'
                  and agencia = 1 "
        Registro = d.insertar(Query)
        Return Registro
    End Function
    Function DIRECCION_ENVIO3(ByVal sCuenta As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = " UPDATE catalogos..DIRECCION_ENVIO
        SET cp_cliente = (SELECT cp_cliente_env_hist FROM catalogos..HIST_CAN_REAC_CTA
        where cuenta_cliente_hist = '" & sCuenta & "'
        and agencia_hist = 1)
        where cuenta_cliente = '" & sCuenta & "'
        and agencia = 1"
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function FuncionarioAsig(ByVal sCuenta As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = " UPDATE catalogos..DIRECCION_ENVIO
        SET cp_cliente = (SELECT cp_cliente_env_hist FROM catalogos..HIST_CAN_REAC_CTA
        where cuenta_cliente_hist = '" & sCuenta & "'
        and agencia_hist = 1)
        where cuenta_cliente = '" & sCuenta & "'
        and agencia = 1"
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function UpdFuncCuenta(ByVal sCuenta As String) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = " UPDATE catalogos..CLIENTE
        SET funcionario = (SELECT funcionario FROM catalogos..HIST_CAN_REAC_CTA
        where cuenta_cliente_hist = '" & sCuenta & "'
        and agencia_hist = 1)
        where cuenta_cliente = '" & sCuenta & "'
        and agencia = 1"
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function InsEventoOperacion(ByVal OperacionAper As Integer, ByVal gn_Usuario As String) As Integer
        '*************************************************************************
        'cambiar el contenido del insert que sera llamado desde cancelacionctas.vb
        '*************************************************************************
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = "   Insert into TICKET..EVENTO_OPERACION 
			        (operacion, fecha_evento, status_operacion, comentario_evento, usuario, tipo_evento) 
            VALUES(" & OperacionAper & ", GETDATE(), 6, 'Apertura Complementada por Reactivación de Cuenta', " & gn_Usuario & ", 1)"
        'MsgBox(Query)
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function InsEventoProducto(ByVal sProductoContratado As String, ByVal gn_Usuario As String, ByVal lsComentario As String, ByVal iStatus As Integer) As Integer
        '*************************************************************************
        'cambiar el contenido del insert que sera llamado desde cancelacionctas.vb
        '*************************************************************************
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = "Insert into TICKET..EVENTO_PRODUCTO "
        Query &= " (producto_contratado, fecha_evento, status_producto, comentario_evento, usuario) "
        Query &= " values (" & sProductoContratado & ", getdate()," & iStatus & ",'" & lsComentario & "','" & gn_Usuario & "')"
        'Query &= " values (" & sProductoContratado & ", getdate(), 8039,'" & lsComentario & "','" & gn_Usuario & "')"
        'MsgBox(Query)
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function InsMantenimientoCuenta(ByVal sProductoContratado As String, ByVal gn_Usuario As String) As Integer
        '*************************************************************************
        'cambiar el contenido del insert que sera llamado desde cancelacionctas.vb
        '*************************************************************************
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = "   Insert into TICKET..MANTENIMIENTO_CUENTA 
			(producto_contratado, tipo_mantenimiento, fecha_mantenimiento, fecha_operacion,
            status_mantenimiento, usuario)
            values (" & sProductoContratado & ", 4, getdate(), getdate(), 4, '" & gn_Usuario & "')"
        'MsgBox(Query)
        Registro = d.insertar(Query)
        Return Registro
    End Function


#End Region

#Region "Bloqueo Desbloqueo Cuentas - Cancelacion Cuentas"

    Function BuscaTicket(ByVal sTicket As String) As DataTable
        Dim d As New Datasource
        Dim s As String
        s = "Select status_operacion, "                        '0
        s &= "descripcion_operacion_definida, "        '1
        s &= "cuenta_cliente, "                        '2
        s &= "monto_operacion, "                       '3
        s &= "convert(char(10),fecha_operacion,105), " '4
        s &= "convert(char(10),fecha_captura,105), "   '5
        s &= "pc.agencia, "                            '6
        s &= "od.operacion_definida_global, "          '7
        s &= "a.descripcion_agencia "                  '8
        s &= "From "
        s &= "OPERACION op, "
        s &= "PRODUCTO_CONTRATADO pc, "
        s &= "OPERACION_DEFINIDA od, "
        s &= "CATALOGOS..AGENCIA a "
        s &= "Where op.operacion = " & sTicket
        s &= "  and op.status_operacion >=2 "
        s &= "  and pc.producto_contratado = op.producto_contratado "
        s &= "  and pc.agencia = 1 "
        s &= "  and od.operacion_definida = op.operacion_definida "
        s &= "  and od.operacion_definida_global = 80 "
        s &= "  and a.agencia = pc.agencia "

        Return d.Consulta(s, "ObtieneTicket")

    End Function

    Function BuscaTicketCan(ByVal sTicket As String) As DataTable
        Dim d As New Datasource
        Dim s As String
        s = "Select status_operacion, "                        '0
        s &= "descripcion_operacion_definida, "        '1
        s &= "cuenta_cliente, "                        '2
        s &= "monto_operacion, "                       '3
        s &= "convert(char(10),fecha_operacion,105), " '4
        s &= "convert(char(10),fecha_captura,105), "   '5
        s &= "pc.agencia, "                            '6
        s &= "od.operacion_definida_global, "          '7
        s &= "a.descripcion_agencia "                  '8
        s &= "From "
        s &= "OPERACION op, "
        s &= "PRODUCTO_CONTRATADO pc, "
        s &= "OPERACION_DEFINIDA od, "
        s &= "CATALOGOS..AGENCIA a "
        s &= "Where op.operacion = " & sTicket
        s &= "  and op.status_operacion >=2 "
        s &= "  and pc.producto_contratado = op.producto_contratado "
        s &= "  and pc.agencia = 1 "
        s &= "  and od.operacion_definida = op.operacion_definida "
        s &= "  and od.operacion_definida_global in ( 80, 180 ) "
        s &= "  and a.agencia = pc.agencia "

        Return d.Consulta(s, "BuscaTicketCan")

    End Function


    Function BuscaTD(ByVal sTicket As String) As DataTable
        Dim d As New Datasource
        Dim s As String
        s = "Select convert(char(10),pc.fecha_vencimiento,105), "
        s &= "tasa, "
        s &= "plazo, "
        s &= "ocd.descripcion, "
        s &= "producto_contratado,"
        s &= "status_producto "
        s &= "From "
        s &= "COMPRA_CD ctd, "
        s &= "PRODUCTO_CONTRATADO pc, "
        s &= "CATALOGOS..ORIGEN_CD ocd "
        s &= "where"
        s &= " ctd.origen=ocd.origen"
        s &= " and ctd.operacion = " & Trim(sTicket)
        s &= " and convert(int,clave_producto_contratado) = ctd.operacion "

        Return d.Consulta(s, "ObtieneTDTicket")

    End Function

    Function BuscaOperTD(ByVal lnProductoContratado As Long) As DataTable
        Dim d As New Datasource
        Dim s As String
        s = "SELECT operacion "
        s &= "FROM COMPRA_CD "
        s &= "WHERE producto_contratado_a_renovar = " & lnProductoContratado

        Return d.Consulta(s, "ObtieneTicketTD")

    End Function

    Function BuscaOperCompraTD(ByVal lnOperación As Long) As DataTable
        Dim d As New Datasource
        Dim s As String
        s = "SELECT ISNULL(operacion_venc,0) FROM COMPRA_CD WHERE operacion = " & lnOperación

        Return d.Consulta(s, "BuscaOperCompraTD")

    End Function

    Function ActOper(ByVal lngOperacionRenovacion As String, ByVal lnStatus As Integer) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = "UPDATE OPERACION SET  status_operacion = " & lnStatus & " WHERE operacion = " & lngOperacionRenovacion
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function ActProdCont(ByVal lnProductoContratado As String, ByVal lnStatusProd As Integer) As Integer
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = "UPDATE PRODUCTO_CONTRATADO SET  status_producto = " & lnStatusProd & "  WHERE producto_contratado = " & lnProductoContratado
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function InsEventoProd(ByVal lnProdContratado As Integer, ByVal lnstatus As Integer, ByVal lsComentario As String, ByVal gn_Usuario As String) As Integer
        '*************************************************************************
        'cambiar el contenido del insert que sera llamado desde cancelacionctas.vb
        '*************************************************************************
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = "   Insert into TICKET..EVENTO_PRODUCTO 
			        (producto_contratado, fecha_evento, status_producto, comentario_evento, usuario) 
            VALUES(" & lnProdContratado & ", GETDATE(), " & lnstatus & ", '" & lsComentario & "', " & gn_Usuario & " )"
        'MsgBox(Query)
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function InsEventoOper(ByVal lnOperacion As Integer, ByVal lnstatus As Integer, ByVal lsComentario As String, ByVal gn_Usuario As String) As Integer
        '*************************************************************************
        'cambiar el contenido del insert que sera llamado desde cancelacionctas.vb
        '*************************************************************************
        Dim d As New Datasource
        Dim Query As String
        Dim Registro As Integer
        Query = "Insert into TICKET..EVENTO_OPERACION "
        Query &= " (operacion, fecha_evento, status_operacion, comentario_evento, usuario) "
        Query &= " VALUES(" & lnOperacion & ", GETDATE(), " & lnstatus & ", '" & lsComentario & "', " & gn_Usuario & " )"
        'MsgBox(Query)
        Registro = d.insertar(Query)
        Return Registro
    End Function

    Function StatusProducto(ByVal lnProdEstatusGlobal As Integer) As DataTable
        Dim d As New Datasource
        Dim s As String
        s = " Select status_producto FROM ticket..STATUS_PRODUCTO "
        s &= " WHERE status_producto_global =" & lnProdEstatusGlobal
        s &= "  And agencia = 1"
        'MsgBox(s)
        Return d.Consulta(s, "StatusProducto")
    End Function


#End Region

#End Region
End Class
