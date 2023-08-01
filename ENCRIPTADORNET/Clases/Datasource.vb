Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports System.Data.OleDb


Public Class Datasource

    Private sqlstring As String
    Private SQLTranConnection As SqlConnection 'RACB 20/01/2021
    Private SQLTranCommand As SqlCommand 'RACB 20/01/2021
    Private SQLTranTransaction As SqlTransaction 'RACB 20/01/2021

    '' Funciones desarrolladas por Beatriz Adriana Palacios Sanchez.
#Region "Funciones Conexiones a BASE de DATOS"
    Sub set_sqlstring()
        'sqlstring = "data source=" & server & ";initial catalog =" & db & ";User ID=" & user & ";Password=" & pwd & ";"
        Dim l As New Libreria

        If iReportes = 1 Then
            l.CredencialesConexion()
            sqlstring = "data source=" & l.SERVER & ";initial catalog =" & l.DBFUN & ";User ID=" & l.USER & ";Password=" & l.PWD & ";"
        Else
            l.CredencialesConexionRep()
            sqlstring = "data source=" & l.SERVER & ";initial catalog =" & l.DB & ";User ID=" & l.USER & ";Password=" & l.PWD & ";"
        End If
        sqlstring = sqlstring.Replace("initial catalog ", "database ") '------- RACB 29-06-2023 para nueva base 19
        sqlstring = sqlstring.Replace("data source ", "server ") '------- RACB 29-06-2023 para nueva base 19
    End Sub

    Function valida_coneccion_sql() As Boolean
        Dim ok As Boolean = False

        set_sqlstring()

        Dim coneccion As New SqlConnection()
        coneccion.ConnectionString = sqlstring
        Try
            coneccion.Open()
            If coneccion.State = ConnectionState.Open Then
                coneccion.Close()
                ok = True
            Else
                coneccion.Close()
            End If
        Catch ex As Exception
            MsgBox("Error al validar la conexion (" & ex.Message & ")")
            coneccion.Close()
        End Try

        Return ok
    End Function

    Function insertar(ByVal querry As String) As Integer
        Dim conec As SqlConnection = get_coneccion_sql()

        Dim i As Integer = 0

        If valida_coneccion_sql() Then
            Try
                conec.Open()
                Using commando = New SqlCommand(UCase(querry), conec)
                    commando.CommandTimeout = 2480

                    i = Math.Abs(commando.ExecuteNonQuery())
                    '  commando.Connection.CreateCommand.ExecuteNonQuery()
                    ' commando.Dispose()
                End Using
                If i = 0 Then
                    Return 0
                Else
                    Return i
                End If
            Catch ex As Exception
                'conec.Dispose() 'RACB 20/01/2021
                'conec.Close() 'RACB 20/01/2021
                MsgBox("Error en el query a actualizar o insertar: " + querry + "Descripcion del error: " + ex.Message)
                i = -1
            Finally 'RACB 20/01/2021
                conec.Dispose() 'RACB 20/01/2021
                conec.Close() 'RACB 20/01/2021
            End Try
        Else
            MsgBox("CONEXION INVALIDA A LA BASE DE DATOS")
        End If

        Return i

    End Function
    Function Consulta(ByVal query As String, ByVal sFuncion As String) As DataTable
        Dim connexio As SqlConnection = get_coneccion_sql()
        Dim adapter As New SqlDataAdapter
        Dim commando As SqlCommand
        Dim dt As New DataSet()

        If valida_coneccion_sql() Then
            'MsgBox("Conexion valida a base de datos")
            Try
                connexio.Open()
                commando = New SqlCommand(query, connexio)
                commando.CommandTimeout = 120
                adapter.SelectCommand = commando
                adapter.Fill(dt, "Consulta")
                adapter.Dispose()
                commando.Dispose()

                connexio.Dispose()
                connexio.Close()
                commando = Nothing
                connexio = Nothing

                Return dt.Tables(0)

            Catch exc As Exception
                Return Nothing
                MsgBox("Error bd: " & exc.Message & "  ERROR EN FUNCION " & sFuncion & " - QUERY: " & query)
                connexio.Dispose()
                connexio.Close()
                connexio = Nothing
            End Try
        Else
            Return Nothing
            MsgBox("CONEXION INVALIDA A LA BASE DE DATOS")
        End If

    End Function
    Function SP(ByVal query As String, ByVal sFuncion As String) As DataTable
        Dim connexio As SqlConnection = get_coneccion_sql()
        Dim adapter As SqlDataAdapter
        Dim dt As New DataSet()

        If valida_coneccion_sql() Then
            Try
                connexio.Open()

                adapter = New SqlDataAdapter(query, connexio)
                adapter.Fill(dt, "SP")
                adapter.Dispose()

                connexio.Dispose()
                connexio.Close()
                connexio = Nothing

                Return dt.Tables(0)

            Catch exc As Exception
                MsgBox("Error bd: " & exc.Message & "   ERROR EN SP " & sFuncion)
                connexio.Dispose()
                connexio.Close()
                connexio = Nothing
            End Try
        Else
            MsgBox("CONEXION INVALIDA A LA BASE DE DATOS")
        End If

        Return Nothing


    End Function

    Function regresa_count(ByVal query As String, ByVal funcion As String) As String
        set_sqlstring()
        Dim coneccion As New SqlConnection()
        coneccion.ConnectionString = sqlstring
        'Dim col As String = ""
        Dim col As String = "0" '---- RACB 03/03/2021
        Try
            coneccion.Open()
            If coneccion.State = ConnectionState.Open Then
                Using command As SqlCommand = New SqlCommand(query, coneccion)
                    col = Convert.ToInt32(command.ExecuteScalar())
                End Using
                coneccion.Close()
            End If

        Catch ex As Exception
            MsgBox("Error en funcion " & funcion & ": " & ex.Message)
            Err.Clear()
            coneccion.Close()
        End Try
        Return col
    End Function

    Function get_coneccion_sql() As SqlConnection

        set_sqlstring()
        Dim coneccion As New SqlConnection()
        coneccion.ConnectionString = sqlstring
        Try
            coneccion.Open()
            If coneccion.State = ConnectionState.Open Then
                ' coneccion.Dispose()
                coneccion.Close()
                Return coneccion
                Exit Function
            Else
                coneccion.Dispose()
                coneccion.Close()
                Return Nothing
                Exit Function
            End If
        Catch ex As Exception
            coneccion.Dispose()
            coneccion.Close()
            Return Nothing
            Exit Function
        End Try
        coneccion.Dispose()
        coneccion.Close()
        Return coneccion
        Exit Function
    End Function

#Region "Consulta de cuenta"

    Function validaUser(ByVal slogin As String) As String

        Dim s As String

        s = "SELECT COUNT(usuario) NUM FROM catalogos.dbo.USUARIO WHERE login = '" & slogin & "'"

        Return regresa_count(s, "validaUser")

    End Function
    Function validaUserB(ByVal slogin As String) As String

        Dim s As String

        s = "SELECT COUNT(usuario) NUM FROM catalogos.dbo.USUARIO where password = 'BLOQUEAR' AND login = '" & slogin & "'"

        Return regresa_count(s, "validaUserB")

    End Function
    Function validaUserA(ByVal slogin As String) As String

        Dim s As String

        s = "SELECT COUNT(usuario) NUM FROM catalogos.dbo.USUARIO where password = 'ANULADO' AND login = '" & slogin & "'"

        Return regresa_count(s, "validaUserA")

    End Function
    Function validaPass(ByVal slogin As String, ByVal spass As String) As String
        Dim s As String
        Dim l As New Libreria

        'spass = l.Encrypt(spass)
        spass = l.Encryption(1, spass)
        l = Nothing
        s = "SELECT COUNT(usuario) NUM FROM catalogos.dbo.USUARIO where login = '" & slogin & "' and password = '" & spass & "'"
        Return regresa_count(s, "validaPass")
    End Function
    Function login(ByVal slogin As String, ByVal spass As String) As DataTable
        Dim s As String
        Dim l As New Libreria

        'spass = l.Encrypt(spass)
        'spass = l.Encryption(2, "YU^xa_Q]_`j`e")
        'l = Nothing
        s = "SELECT usuario, origen_usuario, convert(char(10),fecha_cambio_password,105), convert(char(10),fecha_ultimo_acceso,105), password, nombre_usuario FROM catalogos.dbo.USUARIO where password <> 'BLOQUEAR' and password <> 'ANULADO' AND login = '" & slogin & "'"  ' and password = '" & spass & "'"
        's = "SELECT usuario FROM catalogos.dbo.USUARIO where password <> 'BLOQUEAR' and password <> 'ANULADO' AND login = '" & slogin & "'"  ' and password = '" & spass & "'"
        Return Consulta(s, "LOGIN")
    End Function

    Function InsertaRegistroGestor(ByVal sUsuario As String) As Integer

        Dim Query As String
        Dim Registro As Integer

        Query = " INSERT INTO CATALOGOS..BITACORA_IDENTIFICACION (tarjeta, fecha_registro,  funcionario, usuario, tipo_log, detalle) values (0, getdate(), 0, " & sUsuario & ", 3, 'Registro Funcionario MNI')"

        Registro = insertar(Query)

        Return Registro

    End Function

    Function ObtenAgencia(ByVal sCuenta As String) As DataTable
        Dim s As String

        s = " Select ag.prefijo_agencia + '-' + cte.cuenta_cliente + ' ' + rtrim(rtrim(nombre_cliente)+ ' ' + rtrim(isnull(apellido_paterno,''))+
                ' '+rtrim(isnull(apellido_materno,'')))+' ('+ag.descripcion_agencia+')' as NombreAgencia, ag.agencia
                from   CATALOGOS..CLIENTE cte, 
                       CATALOGOS..AGENCIA ag, 
                       TICKET..PRODUCTO_CONTRATADO PC, 
                       TICKET..PRODUCTO P
                where cte.agencia = ag.agencia            
                and cte.cuenta_cliente = " & sCuenta & "
                and PC.cuenta_cliente= cte.cuenta_cliente 
                and PC.agencia= cte.agencia 
                and PC.producto= P.producto 
                and P.producto_global = 9                
                and PC.agencia= ag.agencia 
                and PC.agencia = 1"

        Return Consulta(s, "ObtenAgencia")

    End Function

    Function ObtenDatosGestor(ByVal sCuenta As String) As DataTable
        Dim s As String

        s = ("Select telefono_funcionario, fax_funcionario, numero_funcionario, 
                rtrim(ltrim(nombre_funcionario)) + ' ' + rtrim(ltrim(fu.apellido_paterno)) + ' ' + rtrim(ltrim(fu.apellido_materno)), 
                cuenta_houston, isnull(rtrim(ltrim(co.nombre_cot))+ ' '+rtrim(ltrim(co.paterno_cot))+ ' '+ rtrim(ltrim(materno_cot)),'') Cotitular, 
                fu.funcionario 
                from CATALOGOS..CLIENTE cte 
                INNER JOIN FUNCIONARIOS..FUNCIONARIO fu  ON cte.funcionario = fu.funcionario 
                LEFT JOIN CATALOGOS..COTITULAR co ON cte.cuenta_cliente = co.cuenta_cliente and cte.agencia = co.agencia  
                where cte.cuenta_cliente = " & sCuenta & "
                and cte.agencia = 1")

        Return Consulta(s, "ObtenDatosGestor")

    End Function

    Function ObtenPadreRutaGestor(ByVal sCuenta As String) As DataTable
        Dim s As String

        s = ("Select 
                uo.tipo_unidad_organizacional, 
                uo.unidad_organizacional_padre, 
                rtrim(uo.unidad_org_bancomer)+' '+rtrim(uo.descripcion_unidad_organizacio) 
                From 
                FUNCIONARIOS..UNIDAD_ORGANIZACIONAL uo, 
                FUNCIONARIOS..FUNCIONARIO fu, 
                CATALOGOS..CLIENTE cl 
                Where fu.unidad_organizacional = uo.unidad_organizacional
                    and fu.funcionario = cl.funcionario  
                    and cl.cuenta_cliente = " & sCuenta & "
                    and cl.agencia = 1")

        Return Consulta(s, "ObtenPadreRutaGestor")

    End Function
    Function ObtenRutaGestor(ByVal sPadre As String) As DataTable
        Dim s As String

        s = (" Select 
            unidad_organizacional_padre, 
            descripcion_unidad_organizacio, 
            rtrim(unidad_org_bancomer)+' '+rtrim(descripcion_unidad_organizacio), 
            unidad_organizacional, 
            tipo_unidad_organizacional 
            From 
            FUNCIONARIOS..UNIDAD_ORGANIZACIONAL 
            Where unidad_organizacional = " & sPadre & "")

        Return Consulta(s, "ObtenRutaGestor")

    End Function

    Function ObtenProductoContratado(ByVal sCuenta As String) As DataTable
        Dim s As String

        s = (" Select 
             pc.producto_contratado, 
             sp.status_producto_global, pr.producto 
             From
             TICKET..PRODUCTO_CONTRATADO pc, 
             TICKET..STATUS_PRODUCTO sp, TICKET..PRODUCTO pr 
             Where 
             pc.cuenta_cliente = '" & sCuenta & "'
             and pc.agencia =  1
             and pc.status_producto = sp.status_producto 
             and pc.producto = pr.producto 
             and pr.producto_global = 9 
             order by pc.producto")

        Return Consulta(s, "ObtenProductoContratado")

    End Function

    Function ObtieneStatusCuenta(ByVal sCuenta As String) As DataTable
        Dim s As String

        s = " Select pc.status_producto, PC.producto_contratado, S.descripcion_status, "
        s &= "PC.clave_producto_contratado, P.descripcion_producto, tce.sufijo_kapiti "
        s &= "from TICKET..PRODUCTO_CONTRATADO PC, TICKET..PRODUCTO P, "
        s &= "TICKET..STATUS_PRODUCTO S, CATALOGOS..CLIENTE CL, CUENTA_EJE ce, TIPO_CUENTA_EJE tce "
        s &= "where PC.cuenta_cliente = '" & sCuenta & "' "
        s &= "and PC.agencia=1 "
        s &= "AND PC.cuenta_cliente = CL.cuenta_cliente "
        s &= "and PC.producto = P.producto  "
        s &= "and S.status_producto = PC.status_producto "
        s &= "and PC.producto = 8009 "
        s &= "and ce.producto_contratado = pc.producto_contratado "
        s &= "and ce.tipo_cuenta_eje = tce.tipo_cuenta_eje "

        Return Consulta(s, "ObtieneStatusCuenta")
    End Function

    Function EsCuentaRestringida(ByVal sProdContratado As Integer) As DataTable
        Dim s As String

        s = " Select descripcion_bloqueo_observacio "
        s &= "from TICKET..BLOQUEO_CUENTAS_DINAMICO BC, BLOQUEO_OBSERVACION BO,  "
        s &= "STATUS_BLOQUEO SB  "
        s &= "where producto_contratado = " & sProdContratado
        s &= "and BO.status_bloqueo = 0 "
        s &= "and BC.bloqueo_observacion = BO.bloqueo_observacion "
        s &= "and BO.status_bloqueo = SB.status_bloqueo "

        Return Consulta(s, "EsCuentaRestringida")
    End Function

    Function LlenaAlertasCuenta(ByVal sProdContratado As Integer) As DataTable
        Dim s As String
        s = " Select bc.bloqueo_observacion, bo.descripcion_bloqueo_observacio "
        s &= "from TICKET..BLOQUEO_CUENTAS_DINAMICO BC, BLOQUEO_OBSERVACION BO "
        s &= "where producto_contratado = " & sProdContratado
        s &= " and BC.bloqueo_observacion = BO.bloqueo_observacion "
        s &= "and status_bloqueo = 3  "

        Return Consulta(s, "LlenaAlertasCuenta")
    End Function

    Function LlenaBloqueosCuenta(ByVal sProdContratado As Integer) As DataTable
        Dim s As String
        s = " Select bc.bloqueo_observacion, bo.descripcion_bloqueo_observacio "
        s &= "from TICKET..BLOQUEO_CUENTAS_DINAMICO BC, BLOQUEO_OBSERVACION BO "
        s &= "where producto_contratado = " & sProdContratado
        s &= "and BC.bloqueo_observacion = BO.bloqueo_observacion "
        s &= "and BO.status_bloqueo = 1  "

        Return Consulta(s, "LlenaBloqueosCuenta")
    End Function

    Function EliminaAlertas(ByVal sProdContratado As Integer, ByVal iStatusBloqueo As Integer) As Integer
        Dim s As String
        Dim Registro As Integer

        s = " Delete TICKET..BLOQUEO_CUENTAS_DINAMICO "
        s &= "FROM TICKET..BLOQUEO_CUENTAS_DINAMICO BC, BLOQUEO_OBSERVACION BO "
        s &= "where producto_contratado = " & sProdContratado
        s &= " and BC.bloqueo_observacion = BO.bloqueo_observacion "
        s &= "and BO.status_bloqueo = " & iStatusBloqueo

        Registro = insertar(s)
        Return Registro
    End Function

    Function InsertaAlertas(ByVal sProdContratado As Integer, ByVal AlertaObservacion As String, ByVal fechaHOY As String, ByVal usuario As String, ByVal Hora As String) As Integer
        Dim s As String
        Dim Registro As Integer

        s = " Insert into TICKET..BLOQUEO_CUENTAS_DINAMICO "
        s &= " (producto_contratado, bloqueo_observacion, fecha_bloqueo_proceso, "
        s &= " consultor_bloquea, fecha_restriccion, tipo_bloqueo ) "
        s &= " values (" & sProdContratado & "," & AlertaObservacion & ","
        s &= " '" & fechaHOY & "','" & usuario & "','" & fechaHOY & " " & Hora & "',3 )"

        Registro = insertar(s)

        Return Registro

    End Function

    Function InsertaBloqueos(ByVal sProdContratado As Integer, ByVal idBloqueo As Integer, ByVal fechaHOY As String, ByVal usuario As String, ByVal Hora As String) As Integer
        Dim s As String
        Dim Registro As Integer

        s = " Insert into TICKET..BLOQUEO_CUENTAS_DINAMICO "
        s &= " (producto_contratado, bloqueo_observacion, fecha_bloqueo_proceso, "
        s &= " consultor_bloquea, fecha_restriccion, tipo_bloqueo ) "
        s &= " values (" & sProdContratado & "," & idBloqueo & ","
        s &= " '" & fechaHOY & "','" & usuario & "','" & fechaHOY & " " & Hora & "',1 )"
        Registro = insertar(s)
        Return Registro
    End Function

    Function ObtieneBloqueoObservacionID(ByVal BloqueoObservacion As String) As DataTable
        Dim s As String
        s = " Select bloqueo_observacion "
        s &= "from TICKET..BLOQUEO_OBSERVACION "
        s &= "where descripcion_bloqueo_observacio = '" & BloqueoObservacion & "' "

        Return Consulta(s, "ObtieneBloqueoObsercionID")
    End Function


    Function InsertaBloqueosHistorico(ByVal sProdContratado As Integer, ByVal fechaHOY As String, ByVal Hora As String) As Integer
        Dim s As String
        Dim Registro As Integer

        s = " Insert into TICKET..BLOQUEO_CUENTAS_HISTORICO "
        s &= " (producto_contratado, bloqueo_observacion,fecha_bloqueo_proceso,"
        s &= " consultor_bloquea, fecha_reactivacion)  "
        s &= "select bc.producto_contratado, bc.bloqueo_observacion, bc.fecha_bloqueo_proceso, "
        s &= " bc.consultor_bloquea, '" & fechaHOY & " " & Hora & "'"
        s &= " from BLOQUEO_CUENTAS_DINAMICO bc, BLOQUEO_OBSERVACION bo "
        s &= " where producto_contratado = " & sProdContratado
        s &= " and bc.bloqueo_observacion = bo.bloqueo_observacion "
        s &= " and bo.status_bloqueo = 1"

        Registro = insertar(s)
        Return Registro
    End Function

    Function UpdateCuenta(ByVal sProdContratado As Integer, ByVal iStatusCuenta As Integer) As Integer
        Dim s As String
        Dim Registro As Integer

        s = " Update TICKET..PRODUCTO_CONTRATADO "
        s &= "SET status_producto=SP.status_producto "
        s &= "from STATUS_PRODUCTO SP, PRODUCTO_CONTRATADO PC "
        s &= "where PC.producto_contratado = " & sProdContratado
        s &= " and PC.agencia = 1 "
        s &= " and SP.status_producto_global = " & iStatusCuenta
        s &= " and SP.producto = PC.producto"
        s &= " and PC.producto = 8009"
        Registro = insertar(s)
        Return Registro
    End Function

    Function BuscaDetalleBloqueo(ByVal sProdContratado As Integer, ByVal iStatus As Integer) As DataTable
        Dim s As String
        s = " Select explicacion, status_bloqueo "
        s &= "from TICKET..DETALLE_STATUS "
        s &= "where producto_contratado = " & sProdContratado
        If iStatus <> 0 Then
            s &= " and status_bloqueo = " & iStatus
        End If

        Return Consulta(s, "BuscaDetalleBloqueo")
    End Function

    Function EliminaBloqueoDetalle(ByVal sProdContratado As Integer, ByVal iStatus As Integer) As Integer
        Dim Query As String
        Dim Registro As Integer

        Query = " DELETE from TICKET..DETALLE_STATUS "
        Query &= " Where (producto_contratado = " & sProdContratado & " And status_bloqueo = " & iStatus & " ) "
        Query &= " or (producto_contratado = " & sProdContratado & " And status_bloqueo is null ) "
        Registro = insertar(Query)
        Return Registro

    End Function

    Function ObtenTipoCuenta(ByVal sProductoCont As String) As DataTable
        Dim s As String

        s = (" Select 
             descripcion_tipo, T.tipo_cuenta_eje from TICKET..CUENTA_EJE C, TICKET..TIPO_CUENTA_EJE T
             where producto_contratado = " & sProductoCont & "            
             and C.tipo_cuenta_eje= T.tipo_cuenta_eje")

        Return Consulta(s, "ObtenTipoCuenta")

    End Function

    Function ObtenProducto(ByVal sCuenta As String) As DataTable
        Dim s As String

        s = (" Select PC.producto_contratado, S.descripcion_status,
            PC.clave_producto_contratado, P.descripcion_producto
            from TICKET..PRODUCTO_CONTRATADO PC, TICKET..PRODUCTO P,
            TICKET..STATUS_PRODUCTO S
            where PC.cuenta_cliente = '" & sCuenta & "'
            and PC.agencia=1
            and PC.producto = P.producto 
            and S.status_producto = PC.status_producto        
            and PC.producto <> 3028
            order by PC.producto_contratado")

        Return Consulta(s, "ObtenProducto")

    End Function

    Function ObtenConcepto(ByVal sProductoCont As String) As DataTable
        Dim s As String

        s = (" Select descripcion_concepto_definido,valor_concepto
        from TICKET..CONCEPTO C,TICKET..CONCEPTO_DEFINIDO CD
		where producto_contratado = " & sProductoCont & "
		and C.concepto_definido = CD.concepto_definido")

        Return Consulta(s, "ObtenConcepto")

    End Function

    Function ObtenOperaciones(ByVal sCuenta As String) As DataTable
        Dim s As String

        s = (" Select O.operacion, status_nombre = CASE WHEN O.status_operacion=0 THEN 'SIN VALIDAR'
        WHEN O.status_operacion= 1  THEN 'SIN VALIDAR'
        WHEN O.status_operacion= 2 THEN 'VALIDADO'
        WHEN O.status_operacion= 3 THEN 'VALIDADO'
        WHEN O.status_operacion= 4 THEN 'VALIDADO EQ'
        WHEN O.status_operacion= 5 THEN 'RECHQZADO EQ'
        WHEN O.status_operacion= 220 THEN 'SIN VALIDAR'
        WHEN O.status_operacion= 250 THEN 'CANCELADO'
        WHEN O.status_operacion= 6 THEN 'COMPLEMENTADO'
        WHEN O.status_operacion= 12 THEN 'RECHAZADO'
        WHEN O.status_operacion= 16 THEN 'RECHAZADO' END,
        OD.descripcion_operacion_definida, O.fecha_captura, O.fecha_operacion, O.monto_operacion    
        from TICKET..OPERACION O, TICKET..OPERACION_DEFINIDA OD  Where producto_contratado = ( 
        select  producto_contratado From  TICKET..PRODUCTO_CONTRATADO Where producto = (
        select producto From TICKET..OPERACION_DEFINIDA Where operacion_definida_global = 100 
        and  agencia =  1 ) 
        and cuenta_cliente='" & sCuenta & "' )
        and O.operacion_definida=OD.operacion_definida and OD.operacion_definida_global=100")

        Return Consulta(s, "ObtenOperaciones")

    End Function

    Function ObtenStatusOperacion(ByVal sProductoCont As String) As Integer
        Dim s As String
        Dim status As Integer
        Dim dtStatus As DataTable

        s = (" Select status_operacion
        from TICKET..OPERACION O, TICKET..OPERACION_DEFINIDA OD
        where producto_contratado = " & sProductoCont & "
        And O.operacion_definida = OD.operacion_definida 
        And OD.operacion_definida_global = 100")

        dtStatus = Consulta(s, "ObtenStatusOperacion")

        status = Convert.ToInt16(dtStatus.Rows(0).Item(0))

        Return status

    End Function
    Function ObtenTipoOperacion(ByVal sOperacion As Integer) As DataTable
        Dim s As String

        s = (" Select Case AG.prefijo_agencia +'-'+PC.cuenta_cliente, 
        OD.operacion_definida_global, 
        OP.linea, 
        OP.operacion_definida 
        FROM 
        TICKET..PRODUCTO_CONTRATADO PC,
        TICKET..OPERACION OP, 
        TICKET..OPERACION_DEFINIDA OD,
        CATALOGOS..AGENCIA AG 
        WHERE 
        OP.operacion = " & sOperacion & "
         And OP.producto_contratado = PC.producto_contratado
         And OP.operacion_definida = OD.operacion_definida
         And AG.agencia = PC.agencia
         And PC.agencia  = 1")

        Return Consulta(s, "ObtenTipoOperacion")

    End Function

    ' Carga de datos de Cliente
    Function LoadCuenta(ByVal sCuenta As String) As DataTable
        Dim s As String
        s = " Select  PC.producto_contratado, PC.cuenta_cliente, CL.fecha_alta, convert(char(10),CL.fecha_alta,108), "
        s &= " OP.status_operacion, OP.operacion, CL.fecha_alta, PC.fecha_vencimiento "
        s &= " From TICKET..OPERACION OP, TICKET..PRODUCTO_CONTRATADO PC, CATALOGOS..CLIENTE CL "
        s &= " Where PC.producto_contratado = OP.producto_contratado And PC.producto = 8009 "
        s &= " And OP.operacion_definida = 8100 And PC.cuenta_cliente =  '" & sCuenta & "'"
        s &= " And PC.cuenta_cliente = CL.cuenta_cliente And pc.agencia = cl.agencia "
        s &= " and PC.agencia = 1 "
        Return Consulta(s, "LoadCuenta")

    End Function

#End Region

#Region "Apertura de cuenta"

    Function ActualizaConsecutivos(ByVal sCampo As String, ByVal sValor As String) As Integer

        Dim Query As String
        Dim Registro As Integer

        Query = "UPDATE TICKET..CONSECUTIVOS SET " & sCampo & " = " & sValor

        Registro = insertar(Query)

        Return Registro

    End Function
    Function InsertaCliente(ByVal sCuenta_cliente As String, ByVal sNombre As String, ByVal sFuncionario As String, ByVal sTipoCliente As String, ByVal sCuentaeje As String, ByVal sMnemonico As String, ByVal sShortName As String, ByVal sFechaCtaEje As String, ByVal sApellidoPat As String, ByVal sApellidoMat As String, ByVal iTipoPersona As String) As Integer

        Dim Query As String
        Dim Registro As Integer

        'MsgBox("sCuenta_cliente:" & sCuenta_cliente)

        Query = "Insert into 
          CATALOGOS..CLIENTE (cuenta_cliente, nombre_cliente, fecha_alta, funcionario, 
          tipo_cliente, 
          apellido_paterno, apellido_materno, persona_moral, cuenta_modificada, cuenta_eje_pesos, 
          mnemonico, documentacion, agencia, tiene_chequera, cuenta_houston, funcionario_pesos, fecha_cuenta_pesos, func_pesos, shortname  ) 
               values ('" & sCuenta_cliente & "','" & sNombre & "',  getdate(), '" & sFuncionario & "',"

        If sTipoCliente = "0" Then
            Query = Query & "8,"      'persona fisica
        Else
            Query = Query & "'" & sTipoCliente & "',"
        End If

        Query = Query & "'" & sApellidoPat & "', '" & sApellidoMat & "'," & iTipoPersona & ", 1, '" & sCuentaeje & "', 
          '" & sMnemonico & "',     0,     1 ,       1 ,      null,     0,  '" & sFechaCtaEje & "',  '', '" & sShortName & "')"

        Registro = insertar(Query)

        Return Registro

    End Function

    Function InsertaClienteFideicomiso(ByVal sCuenta_cliente As String) As Integer

        Dim Query As String
        Dim Registro As Integer

        Query = "Insert into 
          CATALOGOS..CLIENTE_FIDEICOMISO (
          agencia,
          cuenta_cliente, 
          fecha_alta, 
          fecha_baja, 
          estatus,
          tipo_operacion
          ) values (
          1,
          '" & sCuenta_cliente & "',   
          getdate(),    
          null,   
          1,    
          'A')"

        Registro = insertar(Query)

        Return Registro

    End Function

    Function InsertaProductoContratado(ByVal sCuenta_cliente As String) As DataTable

        Dim Query As String

        Query = "Insert into 
          TICKET..PRODUCTO_CONTRATADO (
          producto,
          cuenta_cliente, 
          clave_producto_contratado, 
          fecha_contratacion, 
          fecha_vencimiento,
          status_producto,
          agencia
          ) values (
          (select producto from TICKET..status_producto where agencia = 1 and rtrim(descripcion_status) = 'Activa'),
          '" & sCuenta_cliente & "',   
          '',    
          getdate(),
          null,   
          (select status_producto from TICKET..status_producto where agencia = 1 and rtrim(descripcion_status) = 'Activa'),    
          1)

          SELECT @@IDENTITY"

        Return Consulta(Query, "InsertaProductoContratado")

    End Function

    Function InsertaCuentaEje(ByVal iProductoContratado As Integer, ByVal sTipoCuentaEje As Integer) As Integer

        Dim Query As String
        Dim Registro As Integer

        Query = "Insert into 
          TICKET..CUENTA_EJE (
          producto_contratado,
          tipo_cuenta_eje
          ) values (
          " & iProductoContratado & ",
          " & sTipoCuentaEje & ")"

        Registro = insertar(Query)

        Return Registro

    End Function
    Function InsertaOperacion(ByVal iProductoContratado As Integer, ByVal iOperacionDefinida As Integer, ByVal sLinea As String, ByVal sGrabadora As String, ByVal sFuncionario As String, ByVal sContacto As String) As DataTable

        Dim Query As String

        Query = "Insert into TICKET..OPERACION (
          producto_contratado, 
          operacion_definida, 
          fecha_captura, 
          status_operacion, 
          fecha_operacion, 
          monto_operacion, 
          usuario_captura, 
          usuario_valida, 
          linea, 
          funcionario, 
          contacto, 
          grabadora
          ) values (
          " & iProductoContratado & ",   
          " & iOperacionDefinida & ",    
          getdate(),          
          1,                            
          CAST(getdate() AS VARCHAR(12)),
          0,                            
          629,               
          null,                         
          " & sLinea & ",       
          " & sFuncionario & ",              
          '" & sContacto & "',          
          " & sGrabadora & " )

          SELECT @@IDENTITY"

        Return Consulta(Query, "InsertaOperacion")

    End Function
    Function InsertaConcepto(ByVal sProductoContratado As String, ByVal sConcepto As String) As Integer

        Dim Query As String

        Query = "   Insert into TICKET..CONCEPTO (
          producto_contratado, concepto_definido, 
          valor_concepto
          ) values (" & sProductoContratado & "," & sConcepto & ",0)"

        Return insertar(Query)

    End Function
    Function ObtenerOperacionDefinida() As DataTable
        Dim s As String
        s = ("  Select operacion_definida 
              From TICKET..OPERACION_DEFINIDA
              Where
               producto = (Select producto From TICKET..status_producto Where agencia = 1 And RTrim(descripcion_status) = 'Activa')
               And operacion_definida_global = 100")

        Return Consulta(s, "ObtenerOperacionDefinida")

    End Function

    Function ObtenerConcepto() As DataTable
        Dim s As String
        s = ("  Select concepto_definido 
              From TICKET..CONCEPTO_DEFINIDO 
              Where
               producto =  (select producto from TICKET..status_producto where agencia = 1 and rtrim(descripcion_status) = 'Activa')
               and rtrim(descripcion_concepto_definido) = 'Saldo en Cuenta Eje'")

        Return Consulta(s, "ObtenerConcepto")

    End Function

    Function Preposiciones() As DataTable
        Dim s As String
        s = ("  Select pre_texto From CATALOGOS..PREPOSICION Where pre_status <> 9")

        Return Consulta(s, "Preposiciones")

    End Function
    Function TipoSociedad() As DataTable
        Dim s As String
        s = ("  Select tipo_sociedad From CATALOGOS..TIPO_SOCIEDAD")

        Return Consulta(s, "TipoSociedad")

    End Function
    Function Unico(ByVal sField As String, ByVal sTexto As String) As DataTable
        Dim s As String
        s = ("  Select Count ( * ) From CATALOGOS..CLIENTE Where " & sField & " = '" & sTexto & "'")

        Return Consulta(s, "Unico")

    End Function

    Function ObtenerConsecutivoCte(ByVal sCampoConsecutivo As String) As DataTable
        Dim s As String

        s = ("  Select " & sCampoConsecutivo & "
              From
              TICKET..CONSECUTIVOS")

        Return Consulta(s, "ObtenerConsecutivoCte")

    End Function

    Function DatosUnidadOrg(ByVal iFuncionario As Integer) As DataTable
        Dim s As String

        s = ("  Select A.nombre_funcionario,
                A.apellido_paterno,
                A.apellido_materno,
                B.unidad_org_bancomer
                From FUNCIONARIOS..FUNCIONARIO A, FUNCIONARIOS..UNIDAD_ORGANIZACIONAL B
                Where A.unidad_organizacional = B.unidad_organizacional
                And FUNCIONARIO = " & iFuncionario)

        Return Consulta(s, "DatosUnidadOrg")

    End Function

    Function DatosApertura(ByVal sProductoCont As String) As DataTable
        Dim s As String

        s = ("  Select numero_funcionario,              --'0
          CT.apellido_paterno,                          --'1
          CT.apellido_materno,                          --'2
          nombre_cliente,                               --'3
          persona_moral,                                --'4
          tipo_cliente,                                 --'5
          cuenta_eje_pesos,                             --'6
          convert(char(10),fecha_cuenta_pesos,105),     --'7
          nombre_cliente,                               --'8
          PC.cuenta_cliente,                            --'9
          rtrim(nombre_funcionario)+' '+rtrim(FU.apellido_paterno)+' '+rtrim(FU.apellido_materno), 
          CT.funcionario                                --'11          
          From 
          TICKET..PRODUCTO_CONTRATADO PC,
          CATALOGOS..CLIENTE CT, 
          FUNCIONARIOS..FUNCIONARIO FU 
          Where
           PC.cuenta_cliente = CT.cuenta_cliente
           And PC.agencia = CT.agencia
           And PC.producto_contratado =  " & sProductoCont & "
           And FU.funcionario = CT.funcionario")

        Return Consulta(s, "DatosApertura")

    End Function

    Function DatosAgencia(ByVal sCuenta As String) As DataTable
        Dim s As String

        s = ("  Select AG.prefijo_agencia+'-'+CT.cuenta_cliente+' '
          +rtrim(rtrim(nombre_cliente)+' '+rtrim(apellido_paterno)+' '
          +rtrim(apellido_materno))+' ('
          +AG.descripcion_agencia+')', 
          PC.producto_contratado 
          From 
          CATALOGOS..CLIENTE CT, 
          CATALOGOS..AGENCIA AG, 
          TICKET..PRODUCTO_CONTRATADO PC 
          Where
           PC.producto in (2009,3009,8009)
           and PC.cuenta_cliente = CT.cuenta_cliente
           and PC.agencia = CT.agencia
           and CT.agencia = AG.agencia           
           and PC.cuenta_cliente = '" & sCuenta & "'
           and AG.agencia = 1 ")

        Return Consulta(s, "DatosAgencia")

    End Function

    Function ExisteCuenta(ByVal sCuenta As String) As String
        Dim s As String

        s = ("Select COUNT(cuenta_cliente) 
              From 
              CATALOGOS..CLIENTE 
              where
              cuenta_cliente = '" & sCuenta & "'
              and agencia = 1 ")

        Return regresa_count(s, "ExisteCuenta")

    End Function

    'Function ConsultaCampo(ByVal sQuery As String) As String
    '    Dim s As String

    '    s = ("Select COUNT(cuenta_cliente) 
    '          From 
    '          CATALOGOS..CLIENTE 
    '          where
    '          cuenta_cliente = '" & sCuenta & "'
    '          and agencia = 1 ")

    '    Return regresa_count(s, "ExisteCuenta")

    'End Function

    Function DatosTipoCliente() As DataTable
        Dim s As String

        s = (" SELECT 0 As tipo_cliente, '' As descripcion_tipo_cliente
            UNION
            SELECT tipo_cliente, descripcion_tipo_cliente FROM CATALOGOS..TIPO_CLIENTE ")

        Return Consulta(s, "DatosTipoCliente")

    End Function
    Function DatosGestores(ByVal sNombre As String) As DataTable
        Dim s As String

        s = (" sp_busca_func_dolares 'N', '%" & sNombre & "%' ")

        Return SP(s, "DatosGestores")

    End Function
    Function FechaSistema() As String
        Dim DtHoy As DataTable

        Dim s As String

        s = (" SELECT CONVERT(CHAR(10),fecha_sistema,105) FROM TICKET..PARAMETROS ")

        DtHoy = Consulta(s, "FechaSistema")

        Return DtHoy.Rows(0).Item(0)

    End Function

    Function FechaHabilDiaAnterior(ByVal ls_Query As String) As String
        Dim DtHoy As DataTable
        Dim s As String
        s = ls_Query
        DtHoy = Consulta(s, "FechaHabilDiaAnterior")
        Return DtHoy.Rows(0).Item(0)
    End Function


    Function ValorParametro(ByVal sParametro As String) As DataTable
        Dim s As String

        s = (" SELECT valor FROM TICKET..PARAMETRIZACION WHERE codigo = '" & sParametro & "'")

        Return Consulta(s, "ValorParametro")

    End Function
    Function ValorParametroAP(ByVal sParametro As String) As DataTable
        Dim s As String

        s = (" SELECT valor FROM TICKET..PARAMETRIZACION WHERE codigo = '" & sParametro & "'")

        Return Consulta(s, "ValorParametroAP")

    End Function

    Function ValidaBanca(ByVal sParametro As String)
        Dim s As String

        s = (" SELECT id_division FROM TICKET..CUENTA_BCA_CR WHERE cuenta = '" & sParametro & "'")

        Return Consulta(s, "ValidaBanca")
    End Function

    Function SPGestor(ByVal sID As String, ByVal sNombre As String) As DataTable
        Dim s As String

        s = (" FUNCIONARIOS.dbo.sp_busca_func_dolares '" & sID & "','" & sNombre & "' ")

        Return Consulta(s, "SPGestor")

    End Function

    Function ObtenerRutaDelGestor(ByVal sFun As String) As DataTable
        Dim s As String

        s = ("  select 
                 rtrim(banca),              
                 rtrim(division),           
                 rtrim(cr),                 
                 rtrim(plaza),              
                 rtrim(sucursal)            
                 From 
                FUNCIONARIOS.[Funcionario].[UNIDAD_ORGANIZACIONAL_RESUMEN]
                 Where 
                 funcionario = " & sFun)

        Return Consulta(s, "ObtenerRutaDelGestor")

    End Function



#End Region

#Region "Complemento de Apertura"
    ' Carga de datos de operaciones por validar (status = 1)
    Function OperacionesPorComplementar() As DataTable
        Dim s As String
        s = ("  select PC.cuenta_cliente as [CUENTA], OP.OPERACION AS [TICKET], TCE.descripcion_tipo AS [CUENTAEJE]
              FROM TICKET..OPERACION OP
              INNER JOIN TICKET..PRODUCTO_CONTRATADO PC ON OP.producto_contratado = PC.producto_contratado
              INNER JOIN CATALOGOS..CLIENTE C ON PC.cuenta_cliente = C.cuenta_cliente
              INNER JOIN TICKET..CUENTA_EJE CE ON CE.producto_contratado = PC.producto_contratado
              INNER JOIN TICKET..TIPO_CUENTA_EJE TCE ON CE.tipo_cuenta_eje =TCE.tipo_cuenta_eje
              where status_operacion in (1,7) --and year(fecha_operacion) =2019
              and operacion_definida = 8100
              and TCE.tipo_cuenta_eje in (1,2,3,4)
              and PC.producto = 8009
              order by TCE.descripcion_tipo, PC.cuenta_cliente")

        Return Consulta(s, "OperacionesPorComplementar")

    End Function
    ' Carga de datos de la operacion
    Function LoadCuentaParte1(ByVal iTicket As Integer) As DataTable
        Dim s As String
        s = ("     Select 
                   OP.linea,                               
                   OP.grabadora,                           
                   PC.producto_contratado,                 
                   PC.cuenta_cliente,                      
                   OP.fecha_captura,                       
                   convert(char(10),OP.fecha_captura,108)  
                   From 
                   TICKET..OPERACION OP, 
                   TICKET..PRODUCTO_CONTRATADO PC 
                   Where PC.producto_contratado = OP.producto_contratado                   
                   and OP.operacion =  " & iTicket & "")

        Return Consulta(s, "LoadCuentaParte1")

    End Function
    ' Carga de datos de Cliente
    Function LoadCuentaParte2(ByVal sCuenta As String) As DataTable
        Dim s As String
        s = ("  Select rtrim(nombre_cliente),  ISNULL(calle,'') as calle, ISNULL(cp_cliente,'') as cp_cliente,                           
                  ISNULL(telefono_cliente,'') as telefono_cliente, ISNULL(fax_cliente,'') as fax_cliente,                          
                  convert(char(10),fecha_alta,105), ISNULL(del_o_municipio,'') as del_o_municipio,                            
                  ISNULL(func_pesos,'') as func_pesos, ISNULL(apellido_paterno,'') as apellido_paterno,                     
                  ISNULL(apellido_materno,'') as apellido_materno, ISNULL(colonia_cliente,'') as colonia_cliente,                      
                  ISNULL(cuenta_mancomunada,'') as cuenta_mancomunada, ISNULL(no_ext,'') as no_ext,                               
                  ISNULL(no_int,'') as no_int, ISNULL(componente,'') as componente, ISNULL(rfc,'') as rfc,                                  
                  ISNULL(direccion_cliente,'') as direccion_cliente, persona_moral,
                  cuenta_eje_pesos as cuentaPesos, fecha_cuenta_pesos as fechacuentaPesos, ubicacion as ubicacion 
                  From 
                  CATALOGOS..CLIENTE 
                  Where
                   cuenta_cliente = '" & sCuenta & "'
                   and agencia = 1")

        Return Consulta(s, "LoadCuentaParte2")

    End Function
    ' Carga de datos de Direccion Envio
    Function LoadCuentaParte3(ByVal sCuenta As String) As DataTable
        Dim s As String
        s = ("  Select ISNULL(calle_envio,'') as calle_envio,        
                ISNULL(cp_cliente,'') as cp_cliente,                           
                ISNULL(colonia_cliente,'') as colonia_cliente,                      
                ISNULL(ubicacion,'') as ubicacion,                            
                ISNULL(no_ext_envio,'') as no_ext_envio,                         
                ISNULL(no_int_envio,'') as no_int_envio,                         
                ISNULL(componente_envio,'') as componente_envio,                    
                ISNULL(direccion_cliente,'') as direccion_cliente, 
                ISNULL(del_o_municipio_envio,'') as del_o_municipio_envio    
                From
                CATALOGOS..DIRECCION_ENVIO 
                Where
                cuenta_cliente = '" & sCuenta & "'
                and agencia = 1")

        Return Consulta(s, "LoadCuentaParte3")

    End Function

    Function LoadTipoCuenta(ByVal sProdCont As String) As DataTable
        Dim s As String
        s = " select producto_contratado, ce.tipo_cuenta_eje, descripcion_tipo, sufijo_kapiti "
        s &= " from cuenta_eje ce, TIPO_CUENTA_EJE tce where producto_contratado = " & sProdCont
        s &= " and ce.tipo_cuenta_eje = tce.tipo_cuenta_eje "

        Return Consulta(s, "LoadTipoCuenta")

    End Function

    Function DatosUbicacion() As DataTable
        Dim s As String
        s = ("  Select 0 AS ubicacion, '' AS descripcion
	            UNION
	            SELECT * FROM
	            (Select U.ubicacion, 
                rtrim(U.descripcion_ubicacion)+', '+rtrim(U2.descripcion_ubicacion)  as descripcion
                From 
                FUNCIONARIOS..UBICACION U, 
                FUNCIONARIOS..UBICACION U2 
                Where
                U.tipo_ubicacion = 4 
                and U.ubicacion_padre = U2.ubicacion
                ) A
	            order by descripcion")

        Return Consulta(s, "DatosUbicacion")

    End Function

    Function ExisteDireccion(ByVal sCuenta As String) As DataTable
        Dim s As String
        s = ("  Select Count ( * ) From CATALOGOS..DIRECCION_ENVIO 
                Where
                cuenta_cliente = '" & sCuenta & "'
                and agencia = 1 ")

        Return Consulta(s, "ExisteDireccion")

    End Function
    Function ActualizaDatosComp(datos As ECliente) As Integer

        Dim Query As String
        Dim Registro As Integer

        Query = "Update CATALOGOS.dbo.CLIENTE Set 
               calle = '" & datos.Calle & "', 
               no_ext = '" & datos.NoExt & "',   
               no_int = '" & datos.NoInt & "', 
               componente = '" & datos.Componente & "', 
               colonia_cliente = '" & datos.ColoniaCte & "', 
               del_o_municipio = '" & datos.Del_o_mun & "', 
               cp_cliente = '" & datos.CPCte & "', 
               telefono_cliente = '" & datos.TelefonoCte & "', 
               fax_cliente = '" & datos.FaxCte & "', 
               rfc = '" & datos.RFC & "', 
               ubicacion =  '" & datos.Ubicacion & "', 
               func_pesos = '" & datos.FunPesos & "', 
               cuenta_mancomunada =  0 , 
               cuenta_modificada = 1 
               where
               cuenta_cliente = '" & datos.Cuenta & "'
               and agencia =  1"

        Registro = insertar(Query)

        Return Registro

    End Function

    Function InsertaDireccionEnvio(datos As EDireccionEnv) As Integer

        Dim Query As String
        Dim Registro As Integer

        Query = "   Insert into CATALOGOS..DIRECCION_ENVIO 
                   (agencia, cuenta_cliente, 
                   cp_cliente, colonia_cliente, 
                   ubicacion, calle_envio, 
                   no_ext_envio, no_int_envio, 
                   componente_envio, del_o_municipio_envio) 
                   values 
                   (1, 
                   '" & datos.Cuenta & "', 
                   '" & UCase(datos.CPCte) & "', 
                   '" & UCase(datos.ColoniaCte) & "', 
                   " & datos.Ubicacion & " ,
	               '" & UCase(datos.Calle) & "', 
                   '" & UCase(datos.NoExt) & "',
                   '" & UCase(datos.NoInt) & "',
                   '" & UCase(datos.Componente) & "',       
                   '" & datos.Del_o_mun & "')"

        Registro = insertar(Query)

        Return Registro

    End Function

    Function ActualizaDireccionEnvio(datos As EDireccionEnv) As Integer

        Dim Query As String
        Dim Registro As Integer

        Query = "    Update CATALOGOS.dbo.DIRECCION_ENVIO set
                    calle_envio = '" & UCase(datos.Calle) & "',
                    no_ext_envio = '" & UCase(datos.NoExt) & "',       
                    no_int_envio = '" & UCase(datos.NoInt) & "',      
                    componente_envio = '" & UCase(datos.Componente) & "',       
                    colonia_cliente = '" & UCase(datos.ColoniaCte) & "',
                    del_o_municipio_envio = '" & datos.Del_o_mun & "', 
                    cp_cliente = '" & UCase(datos.CPCte) & "',
                    ubicacion = " & datos.Ubicacion & "
                    Where
                    cuenta_cliente = '" & datos.Cuenta & "'
                    and agencia = 1"

        Registro = insertar(Query)

        Return Registro

    End Function

    Function ActualizaOperacion(ByVal iTicket As Integer, ByVal sUsuario As String) As Integer
        Dim Query As String
        Dim Registro As Integer

        Query = " Update TICKET..OPERACION set 
                  usuario_valida = " & sUsuario & ", 
                  status_operacion = 6 
                  where operacion = " & iTicket

        Registro = insertar(Query)

        Return Registro

    End Function

    Function InsertaEventoOperacion(ByVal iTicket As Integer, ByVal sUsuario As String) As Integer
        Dim Query As String
        Dim Registro As Integer

        Query = "Insert into TICKET..EVENTO_OPERACION 
                  (operacion, fecha_evento, status_operacion, 
                   comentario_evento, usuario) 
                   values 
                   (" & iTicket & ", getdate(),6, 'Complemento Contingencia Apertura'," & sUsuario & ")"

        Registro = insertar(Query)

        Return Registro

    End Function

#End Region

#Region "Captura de Autorizados"
    Function ObtieneAutorizados(ByVal sCuenta As String) As DataTable
        Dim s As String
        s = "  Select autorizado AS AUTORIZADO, ltrim(IsNull(nombre_aut,'')) NOMBRE, ltrim(IsNull(paterno_aut,'')) APELLIDOPAT, ltrim(IsNull(materno_aut,'')) APELLIDOMAT   "
        s &= " From CATALOGOS..AUTORIZADO "
        s &= " Where cuenta_cliente = '" & sCuenta & "' and agencia = 1"

        Return Consulta(s, "ObtieneAutorizados")

    End Function

    Function ExisteAutorizado(datos As EAutorizado) As String

        Dim s As String
        Dim lsNombre As String = datos.Nombre & " " & datos.Paterno & " " & datos.Materno

        s = "Select COUNT(autorizado) EXISTE
              From 
              CATALOGOS..AUTORIZADO 
              Where
               nombre_aut = '" & datos.Nombre & "'   
               and paterno_aut = '" & datos.Paterno & "'   
               and materno_aut = '" & datos.Materno & "'
               and cuenta_cliente ='" & datos.Cuenta & "'
               and agencia = 1
               or nombre_aut = '" & lsNombre.Trim() & "'
               Or ltrim(nombre_aut + IsNull(paterno_aut,'') + IsNull(materno_aut,''))= '" & datos.Nombre & datos.Paterno & datos.Materno & "'"

        Return regresa_count(s, "ExisteAutorizado")

    End Function
    Function InsertaAutorizado(datos As EAutorizado, ByVal sUsuario As String) As Integer

        Dim Query As String
        Dim Registro As Integer

        'Query = "Insert into CATALOGOS..AUTORIZADO 
        '        (cuenta_cliente,agencia,nombre_aut,paterno_aut,materno_aut, fecha_alta, usuario)
        '        VALUES 
        '            ('" & datos.Cuenta & "', 
        '             1, 
        '           '" & UCase(datos.Nombre) & "', 
        '           '" & UCase(datos.Paterno) & "', 
        '           '" & UCase(datos.Materno) & "',GETDATE()," & sUsuario & ")"

        '-------------------------- RACB 28/06/2022
        Query = "Insert into CATALOGOS..AUTORIZADO 
                (cuenta_cliente,agencia,nombre_aut,paterno_aut,materno_aut, fecha_alta)
                VALUES 
                    ('" & datos.Cuenta & "', 
                     1, 
                   '" & UCase(datos.Nombre) & "', 
                   '" & UCase(datos.Paterno) & "', 
                   '" & UCase(datos.Materno) & "',GETDATE()" & ")"
        '-------------------------- RACB 28/06/2022

        Registro = insertar(Query)

        Return Registro

    End Function

    Function ActualizaAutorizado(datos As EAutorizado, ByVal sUsuario As String) As Integer

        Dim Query As String
        Dim Registro As Integer

        'Query = "UPDATE CATALOGOS..AUTORIZADO 
        '        SET nombre_aut = '" & UCase(datos.Nombre) & "',
        '            paterno_aut = '" & UCase(datos.Paterno) & "',
        '            materno_aut = '" & UCase(datos.Materno) & "', 
        '            fecha_mantenimiento = GETDATE(),
        '            usuario = " & sUsuario & "
        '        WHERE                
        '            cuenta_cliente = '" & datos.Cuenta & "'
        '            AND agencia  =  1
        '            AND autorizado = " & datos.Autorizado
        '-------------------------- RACB 28/06/2022
        Query = "UPDATE CATALOGOS..AUTORIZADO 
                SET nombre_aut = '" & UCase(datos.Nombre) & "',
                    paterno_aut = '" & UCase(datos.Paterno) & "',
                    materno_aut = '" & UCase(datos.Materno) & "', 
                    fecha_mantenimiento = GETDATE() " & "
                WHERE                
                    cuenta_cliente = '" & datos.Cuenta & "'
                    AND agencia  =  1
                    AND autorizado = " & datos.Autorizado
        '-------------------------- RACB 28/06/2022
        Registro = insertar(Query)

        Return Registro

    End Function

    Function EliminaAutorizado(autorizado As Integer) As Integer

        Dim Query As String
        Dim Registro As Integer

        Query = " DELETE CATALOGOS..AUTORIZADO Where autorizado = " & autorizado

        Registro = insertar(Query)

        Return Registro

    End Function


#End Region

#Region "Captura de Apoderados"
    Function ObtieneApoderados(ByVal sCuenta As String) As DataTable
        Dim s As String
        s = ("  Select apoderado AS APODERADO,               
                ltrim(IsNull(nombre_apo,'')) NOMBRE,
                ltrim(IsNull(paterno_apo,'')) APELLIDOPAT,
                ltrim(IsNull(materno_apo,'')) APELLIDOMAT    
               From 
               CATALOGOS..APODERADO 
               Where
               cuenta_cliente = '" & sCuenta & "'
               and agencia = 1")

        Return Consulta(s, "ObtieneApoderados")

    End Function

    Function ExisteApoderado(datos As EApoderado) As String

        Dim s As String
        Dim lsNombre As String = datos.Nombre & " " & datos.Paterno & " " & datos.Materno

        s = "Select COUNT(apoderado) EXISTE
              From 
              CATALOGOS..APODERADO 
              Where
               nombre_apo = '" & datos.Nombre & "'   
               and paterno_apo = '" & datos.Paterno & "'   
               and materno_apo = '" & datos.Materno & "'
               and cuenta_cliente ='" & datos.Cuenta & "'
               and agencia = 1
               or nombre_apo = '" & lsNombre.Trim() & "'
               Or ltrim(nombre_apo + IsNull(paterno_apo,'') + IsNull(materno_apo,''))= '" & datos.Nombre & datos.Paterno & datos.Materno & "'"

        Return regresa_count(s, "ExisteApoderado")

    End Function

    Function InsertaApoderado(datos As EApoderado, ByVal sUsuario As String) As Integer

        Dim Query As String
        Dim Registro As Integer

        'Query = "Insert into CATALOGOS..APODERADO 
        '        (cuenta_cliente,agencia,nombre_apo,paterno_apo,materno_apo, fecha_alta, usuario)
        '        VALUES 
        '            ('" & datos.Cuenta & "', 
        '             1, 
        '           '" & UCase(datos.Nombre) & "', 
        '           '" & UCase(datos.Paterno) & "', 
        '           '" & UCase(datos.Materno) & "',GETDATE()," & sUsuario & ")"
        '-------------------------- RACB 23/02/2022
        Query = "Insert into CATALOGOS..APODERADO 
                (cuenta_cliente,agencia,nombre_apo,paterno_apo,materno_apo, fecha_alta)
                VALUES 
                    ('" & datos.Cuenta & "', 
                     1, 
                   '" & UCase(datos.Nombre) & "', 
                   '" & UCase(datos.Paterno) & "', 
                   '" & UCase(datos.Materno) & "',GETDATE() )"
        '-------------------------- RACB 23/02/2022
        Registro = insertar(Query)

        Return Registro

    End Function
    Function ActualizaApoderado(datos As EApoderado, ByVal sUsuario As String) As Integer

        Dim Query As String
        Dim Registro As Integer

        'Query = "UPDATE CATALOGOS..APODERADO 
        '        SET nombre_apo = '" & UCase(datos.Nombre) & "',
        '            paterno_apo = '" & UCase(datos.Paterno) & "',
        '            materno_apo = '" & UCase(datos.Materno) & "', 
        '            fecha_mantenimiento = GETDATE(),
        '            usuario = " & sUsuario & "
        '        WHERE                
        '            cuenta_cliente = '" & datos.Cuenta & "'
        '            AND agencia  =  1
        '            AND apoderado = " & datos.Apoderado
        '-------------------------- RACB 23/02/2022
        Query = "UPDATE CATALOGOS..APODERADO 
                SET nombre_apo = '" & UCase(datos.Nombre) & "',
                    paterno_apo = '" & UCase(datos.Paterno) & "',
                    materno_apo = '" & UCase(datos.Materno) & "', 
                    fecha_mantenimiento = GETDATE() " & "
                WHERE                
                    cuenta_cliente = '" & datos.Cuenta & "'
                    AND agencia  =  1
                    AND apoderado = " & datos.Apoderado
        '-------------------------- RACB 23/02/2022
        Registro = insertar(Query)

        Return Registro

    End Function

    Function EliminaApoderado(apoderado As Integer) As Integer

        Dim Query As String
        Dim Registro As Integer

        Query = " DELETE CATALOGOS..APODERADO Where apoderado = " & apoderado

        Registro = insertar(Query)

        Return Registro

    End Function

#End Region

#Region "Captura de Beneficiarios"
    Function ObtieneBeneficiarios(ByVal sCuenta As String) As DataTable

        Dim s As String
        s = ("  Select beneficiario AS BENEFICIARIO,               
                ltrim(IsNull(nombre_benef,'')) NOMBRE,
                ltrim(IsNull(paterno_benef,'')) APELLIDOPAT,
                ltrim(IsNull(materno_benef,'')) APELLIDOMAT                 
               From 
               CATALOGOS..BENEFICIARIO 
               Where
               cuenta_cliente = '" & sCuenta & "'
               and agencia = 1")

        Return Consulta(s, "ObtieneBeneficiarios")

    End Function

    Function ExisteBeneficiario(datos As EBeneficiario) As String

        Dim s As String
        Dim lsNombre As String = datos.Nombre & " " & datos.Paterno & " " & datos.Materno


        s = "Select COUNT(beneficiario) EXISTE
              From 
              CATALOGOS..BENEFICIARIO 
              Where
               nombre_benef = '" & datos.Nombre & "'   
               and paterno_benef = '" & datos.Paterno & "'   
               and materno_benef = '" & datos.Materno & "'
               and cuenta_cliente ='" & datos.Cuenta & "'
               and agencia = 1
               or nombre_benef = '" & lsNombre.Trim() & "'
               Or ltrim(nombre_benef + IsNull(paterno_benef,'') + IsNull(materno_benef,''))= '" & datos.Nombre & datos.Paterno & datos.Materno & "'"

        Return regresa_count(s, "ExisteBeneficiario")

    End Function
    Function InsertaBeneficiario(datos As EBeneficiario, ByVal sUsuario As String) As Integer

        Dim Query As String
        Dim Registro As Integer

        'Query = "Insert into CATALOGOS..BENEFICIARIO 
        '        (cuenta_cliente,agencia,nombre_benef,paterno_benef,materno_benef, fecha_alta, usuario) 
        '        VALUES 
        '            ('" & datos.Cuenta & "', 
        '             1, 
        '           '" & UCase(datos.Nombre) & "', 
        '           '" & UCase(datos.Paterno) & "', 
        '           '" & UCase(datos.Materno) & "',GETDATE()," & sUsuario & ")"
        '-------------------------- RACB 23/02/2022
        Query = "Insert into CATALOGOS..BENEFICIARIO 
                (cuenta_cliente,agencia,nombre_benef,paterno_benef,materno_benef, fecha_alta) 
                VALUES 
                    ('" & datos.Cuenta & "', 
                     1, 
                   '" & UCase(datos.Nombre) & "', 
                   '" & UCase(datos.Paterno) & "', 
                   '" & UCase(datos.Materno) & "',GETDATE())"
        '-------------------------- RACB 23/02/2022

        Registro = insertar(Query)

        Return Registro

    End Function
    Function ActualizaBeneficiario(datos As EBeneficiario, ByVal sUsuario As String) As Integer

        Dim Query As String
        Dim Registro As Integer

        'Query = "UPDATE CATALOGOS..BENEFICIARIO 
        '        SET nombre_benef = '" & UCase(datos.Nombre) & "',
        '            paterno_benef = '" & UCase(datos.Paterno) & "',
        '            materno_benef = '" & UCase(datos.Materno) & "', 
        '            fecha_mantenimiento = GETDATE(),
        '            usuario = " & sUsuario & "
        '        WHERE                
        '            cuenta_cliente = '" & datos.Cuenta & "'
        '            AND agencia  =  1
        '            AND beneficiario = " & datos.Beneficiario
        '-------------------------- RACB 28/06/2022
        Query = "UPDATE CATALOGOS..BENEFICIARIO 
                SET nombre_benef = '" & UCase(datos.Nombre) & "',
                    paterno_benef = '" & UCase(datos.Paterno) & "',
                    materno_benef = '" & UCase(datos.Materno) & "', 
                    fecha_mantenimiento = GETDATE() " & "
                WHERE                
                    cuenta_cliente = '" & datos.Cuenta & "'
                    AND agencia  =  1
                    AND beneficiario = " & datos.Beneficiario
        '-------------------------- RACB 28/06/2022
        Registro = insertar(Query)

        Return Registro

    End Function
    Function EliminaBeneficiario(beneficiario As Integer) As Integer

        Dim Query As String
        Dim Registro As Integer

        Query = " DELETE CATALOGOS..BENEFICIARIO Where beneficiario = " & beneficiario

        Registro = insertar(Query)

        Return Registro

    End Function
#End Region

#Region "Captura de Cotitulares"
    Function ObtieneCotitulares(ByVal sCuenta As String) As DataTable
        Dim s As String
        s = ("  Select cotitular AS COTITULAR,               
                ltrim(IsNull(nombre_cot,'')) NOMBRE,
                ltrim(IsNull(paterno_cot,'')) APELLIDOPAT,
                ltrim(IsNull(materno_cot,'')) APELLIDOMAT 
               From 
               CATALOGOS..COTITULAR 
               Where
               cuenta_cliente = '" & sCuenta & "'
               and agencia = 1")

        Return Consulta(s, "ObtieneCotitulares")

    End Function
    Function ExisteCotitular(datos As ECotitular) As String

        Dim s As String
        Dim lsNombre As String = datos.Nombre & " " & datos.Paterno & " " & datos.Materno

        s = "Select COUNT(cotitular) EXISTE
              From 
              CATALOGOS..COTITULAR 
              Where
               nombre_cot = '" & datos.Nombre & "'   
               and paterno_cot = '" & datos.Paterno & "'   
               and materno_cot = '" & datos.Materno & "'
               and cuenta_cliente ='" & datos.Cuenta & "'
               and agencia = 1
               or nombre_cot = '" & lsNombre.Trim() & "'
               Or ltrim(nombre_cot + IsNull(paterno_cot,'') + IsNull(materno_cot,''))= '" & datos.Nombre & datos.Paterno & datos.Materno & "'"

        Return regresa_count(s, "ExisteCotitular")

    End Function

    Function InsertaCotitular(datos As ECotitular, ByVal sUsuario As String) As Integer

        Dim Query As String
        Dim Registro As Integer

        'Query = "Insert into CATALOGOS..COTITULAR 
        '        (cuenta_cliente,agencia,nombre_cot,paterno_cot,materno_cot, fecha_alta, usuario)
        '        VALUES 
        '            ('" & datos.Cuenta & "', 
        '             1, 
        '           '" & UCase(datos.Nombre) & "', 
        '           '" & UCase(datos.Paterno) & "', 
        '           '" & UCase(datos.Materno) & "',GETDATE()," & sUsuario & ")"
        '-------------------------- RACB 28/06/2022
        Query = "Insert into CATALOGOS..COTITULAR 
                (cuenta_cliente,agencia,nombre_cot,paterno_cot,materno_cot, fecha_alta)
                VALUES 
                    ('" & datos.Cuenta & "', 
                     1, 
                   '" & UCase(datos.Nombre) & "', 
                   '" & UCase(datos.Paterno) & "', 
                   '" & UCase(datos.Materno) & "',GETDATE()" & ")"
        '-------------------------- RACB 28/06/2022

        Registro = insertar(Query)

        Return Registro

    End Function
    Function ActualizaCotitular(datos As ECotitular, ByVal sUsuario As String) As Integer

        Dim Query As String
        Dim Registro As Integer

        'Query = "UPDATE CATALOGOS..COTITULAR 
        '        SET nombre_cot = '" & UCase(datos.Nombre) & "',
        '            paterno_cot = '" & UCase(datos.Paterno) & "',
        '            materno_cot = '" & UCase(datos.Materno) & "', 
        '            fecha_mantenimiento = GETDATE(),
        '            usuario = " & sUsuario & "
        '        WHERE                
        '            cuenta_cliente = '" & datos.Cuenta & "'
        '            AND agencia  =  1
        '            AND cotitular = " & datos.Cotitular
        '-------------------------- RACB 28/06/2022
        Query = "UPDATE CATALOGOS..COTITULAR 
                SET nombre_cot = '" & UCase(datos.Nombre) & "',
                    paterno_cot = '" & UCase(datos.Paterno) & "',
                    materno_cot = '" & UCase(datos.Materno) & "', 
                    fecha_mantenimiento = GETDATE() " & "
                WHERE                
                    cuenta_cliente = '" & datos.Cuenta & "'
                    AND agencia  =  1
                    AND cotitular = " & datos.Cotitular
        Registro = insertar(Query)
        '-------------------------- RACB 28/06/2022
        Return Registro

    End Function
    Function EliminaCotitular(cotitular As Integer) As Integer

        Dim Query As String
        Dim Registro As Integer

        Query = " DELETE CATALOGOS..COTITULAR Where cotitular = " & cotitular

        Registro = insertar(Query)

        Return Registro

    End Function
#End Region

#Region "ValidaApertura"
    ' Carga de datos de operaciones preparados para validar (status = 6)
    Function OperacionesPorValidar() As DataTable
        Dim s As String
        s = ("    Select PC.cuenta_cliente AS [CUENTA], 
                    OP.operacion AS [TICKET],         
                    TCE.descripcion_tipo AS [CUENTAEJE] 
                    From 
                    TICKET..PRODUCTO_CONTRATADO PC, 
                    TICKET..OPERACION OP, 
                    TICKET..CUENTA_EJE C, 
                    CATALOGOS..USUARIO U, 
		            TICKET..TIPO_CUENTA_EJE TCE
                    Where C.tipo_cuenta_eje =TCE.tipo_cuenta_eje
		             and PC.producto_contratado = OP.producto_contratado
                     and PC.producto_contratado = C.producto_contratado
                     and OP.operacion_definida = 8100        
                     and OP.status_operacion = 6
                     and fecha_operacion <= GETDATE()		 
                     and C.tipo_cuenta_eje in (1,2,3,4)        
                     and OP.usuario_captura <> 91 
                     and OP.usuario_captura = U.usuario
                     order by TCE.descripcion_tipo, PC.cuenta_cliente")
        's = ("    Select PC.cuenta_cliente AS [CUENTA], 
        '            OP.operacion AS [TICKET],         
        '            TCE.descripcion_tipo AS [CUENTAEJE] 
        '            From 
        '            TICKET..PRODUCTO_CONTRATADO PC, 
        '            TICKET..OPERACION OP, 
        '            TICKET..CUENTA_EJE C, 
        '            CATALOGOS..USUARIO U, 
        '      TICKET..TIPO_CUENTA_EJE TCE
        '            Where C.tipo_cuenta_eje =TCE.tipo_cuenta_eje
        '       and PC.producto_contratado = OP.producto_contratado
        '             and PC.producto_contratado = C.producto_contratado
        '             and OP.operacion_definida = 8100        
        '             and OP.status_operacion = 6
        '             and fecha_operacion < GETDATE()		 
        '             and C.tipo_cuenta_eje in (1,2,3,4)        
        '             and OP.usuario_captura <> 91 
        '             and OP.usuario_captura = U.usuario
        '            and U.login <> 'TF'
        '             order by TCE.descripcion_tipo, PC.cuenta_cliente")
        Return Consulta(s, "OperacionesPorValidar")

    End Function

    Function ExisteDepositosAnteriores(ByVal sProductoContratado As String) As DataTable
        Dim s As String
        s = ("  Select Count ( * ) 
                From TICKET..OPERACION OP, 
                TICKET..OPERACION_DEFINIDA OD 
                Where 
                OP.operacion_definida = OD.operacion_definida And 
                OP.producto_contratado =  " & sProductoContratado & "  And 
                OD.operacion_definida_global In 
                ( 580, 583, 584, 585, 587, 597, 589, 591, 592 ) And 
                OP.status_operacion <> 250 And 
                OP.fecha_operacion < GETDATE() ")

        Return Consulta(s, "ExisteDepositosAnteriores")

    End Function
    Function ValidaOperacion(ByVal iTicket As Integer, ByVal sUsuario As String) As Integer
        Dim Query As String
        Dim Registro As Integer

        Query = " Update TICKET..OPERACION set 
                  usuario_valida = " & sUsuario & ", 
                  status_operacion = 2 
                  where operacion = " & iTicket

        Registro = insertar(Query)

        Return Registro

    End Function

    Function InsertaEventoOperacionVal(ByVal iTicket As Integer, ByVal sUsuario As String) As Integer
        Dim Query As String
        Dim Registro As Integer

        Query = "Insert into TICKET..EVENTO_OPERACION 
                  (operacion, fecha_evento, status_operacion, 
                   comentario_evento, usuario) 
                   values 
                   (" & iTicket & ", getdate(),2, 'Validación de Apertura'," & sUsuario & ")"

        Registro = insertar(Query)

        Return Registro

    End Function

    Function InsertaBitacoraSwift(ByVal iTicket As Integer) As Integer
        Dim Query As String
        Dim Registro As Integer

        Query = " insert into BITACORA_REPORTE_SWIFT_MT198 "
        Query &= " (operacion, agencia, fecha_envio, status_reporte, status_envio, tipo_operacion) "
        Query &= " values ( " & iTicket & ", 1 , CONVERT(smalldatetime, GETDATE(),130), 2, 0, 'CT')"

        Registro = insertar(Query)
        Return Registro

    End Function

#End Region



#End Region


#Region "Reporte Cuentas Nuevas"
    ' Carga de datos de Cliente
    Function LoadCuentasApertura(ByVal sFechaInicio As String, ByVal sFechaFin As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = " Select distinct"
        lsGsSql = lsGsSql & " O.operacion AS [operacion], PC.cuenta_cliente AS [cuenta_cliente],"
        lsGsSql = lsGsSql & " O.monto_operacion AS [monto_operacion], case RO.impreso when 1 then 'Impreso' else '' end as [impreso],"
        lsGsSql = lsGsSql & " PC.producto_contratado AS [producto_contratado],"
        lsGsSql = lsGsSql & " CASE"
        lsGsSql = lsGsSql & " WHEN status_operacion = 0 THEN 'Sin Validar'"
        lsGsSql = lsGsSql & " WHEN status_operacion = 1 THEN 'Sin Validar'"
        lsGsSql = lsGsSql & " WHEN status_operacion = 2 THEN 'Validada'"
        lsGsSql = lsGsSql & " WHEN status_operacion = 3 THEN 'Validada'"
        lsGsSql = lsGsSql & " WHEN status_operacion = 4 THEN 'Validada EQ'"
        lsGsSql = lsGsSql & " WHEN status_operacion = 5 THEN 'Rechazada EQ'"
        lsGsSql = lsGsSql & " WHEN status_operacion = 220 THEN 'Sin Validar'"
        lsGsSql = lsGsSql & " WHEN status_operacion = 250 THEN 'Cancelada'"
        lsGsSql = lsGsSql & " WHEN status_operacion = 6 THEN 'Complementada'"
        lsGsSql = lsGsSql & " WHEN status_operacion = 12 THEN 'Rechazada'"
        lsGsSql = lsGsSql & " WHEN status_operacion = 16 THEN 'Rechazada'"
        lsGsSql = lsGsSql & " End AS [desc_status_op],"
        lsGsSql = lsGsSql & " SP.descripcion_status AS [desc_status_cta]"
        lsGsSql = lsGsSql & " from "
        lsGsSql = lsGsSql & " TICKET..PRODUCTO_CONTRATADO PC,"
        lsGsSql = lsGsSql & " CATALOGOS..AGENCIA AG,"
        lsGsSql = lsGsSql & " TICKET..CUENTA_EJE CE,"
        lsGsSql = lsGsSql & " TICKET..TIPO_CUENTA_EJE TCE, "
        lsGsSql = lsGsSql & " TICKET..OPERACION_DEFINIDA OD,"
        lsGsSql = lsGsSql & " TICKET..STATUS_PRODUCTO SP,"
        lsGsSql = lsGsSql & " TICKET..OPERACION O With (INDEX = IDX_FECHA_OPERA)"
        lsGsSql = lsGsSql & " LEFT OUTER JOIN  TICKET..REPORTE_OPERACION RO"
        lsGsSql = lsGsSql & " ON O.operacion = RO.operacion "
        lsGsSql = lsGsSql & " where operacion_definida_global =100 "
        lsGsSql = lsGsSql & " and O.fecha_operacion between '" & sFechaInicio & "' and '" & sFechaFin & "'"
        lsGsSql = lsGsSql & " and O.status_operacion <> 250"
        lsGsSql = lsGsSql & " and O.producto_contratado = PC.producto_contratado"
        lsGsSql = lsGsSql & " and PC.producto_contratado = CE.producto_contratado"
        lsGsSql = lsGsSql & " and CE.tipo_cuenta_eje = TCE.tipo_cuenta_eje"
        lsGsSql = lsGsSql & " and PC.agencia = AG.agencia"
        lsGsSql = lsGsSql & " and PC.agencia = SP.agencia"
        lsGsSql = lsGsSql & " and PC.status_producto = SP.status_producto"
        lsGsSql = lsGsSql & " and OD.operacion_definida = O.operacion_definida"
        lsGsSql = lsGsSql & " and PC.agencia = 1 "
        lsGsSql = lsGsSql & " order by O.operacion"


        'MsgBox(sFechaInicio)
        'MsgBox(sFechaFin)
        'MsgBox("el query es: " & lsGsSql)

        Return Consulta(lsGsSql, "LoadCuentasApertura")

    End Function

    Function LoadCuentasAperturaxFecha(ByVal sFechaInicio As String, ByVal sFechaFin As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = " SELECT CLIENTE.cuenta_cliente, CLIENTE.apellido_paterno, CLIENTE.apellido_materno, CLIENTE.nombre_cliente, "
        lsGsSql = lsGsSql & " PRODUCTO_CONTRATADO.fecha_contratacion, AGENCIA.descripcion_agencia, UNIDAD_ORGANIZACIONAL_RESUMEN.cr, "
        lsGsSql = lsGsSql & " CLIENTE.funcionario, STATUS_PRODUCTO.descripcion_status, CLIENTE.cuenta_eje_pesos "

        lsGsSql = lsGsSql & " FROM   CATALOGOS.dbo.CLIENTE CLIENTE "
        lsGsSql = lsGsSql & " INNER JOIN TICKET.dbo.PRODUCTO_CONTRATADO PRODUCTO_CONTRATADO ON CLIENTE.cuenta_cliente=PRODUCTO_CONTRATADO.cuenta_cliente "
        lsGsSql = lsGsSql & " INNER JOIN FUNCIONARIOS.Funcionario.UNIDAD_ORGANIZACIONAL_RESUMEN UNIDAD_ORGANIZACIONAL_RESUMEN ON CLIENTE.funcionario=UNIDAD_ORGANIZACIONAL_RESUMEN.funcionario "
        lsGsSql = lsGsSql & " INNER JOIN CATALOGOS.dbo.AGENCIA AGENCIA ON CLIENTE.agencia=AGENCIA.agencia "
        lsGsSql = lsGsSql & " INNER JOIN TICKET.dbo.STATUS_PRODUCTO STATUS_PRODUCTO ON PRODUCTO_CONTRATADO.status_producto=STATUS_PRODUCTO.status_producto "

        lsGsSql = lsGsSql & " where PRODUCTO_CONTRATADO.producto = 8009 "
        lsGsSql = lsGsSql & " and PRODUCTO_CONTRATADO.fecha_contratacion between '" & sFechaInicio & " 00:00:00' and '" & sFechaFin & " 23:59:50'"
        lsGsSql = lsGsSql & " and CLIENTE.agencia = 1 "

        Return Consulta(lsGsSql, "LoadCuentasAperturaxFecha")

    End Function

    Function LoadCuentasAperturaValidadas(ByVal sFechaInicio As String, ByVal sFechaFin As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "  SELECT OPERACION.operacion, CLIENTE.apellido_paterno, CLIENTE.apellido_materno, "
        lsGsSql = lsGsSql & " CLIENTE.nombre_cliente, CLIENTE.deposito_inicial, CLIENTE.cuenta_cliente, AGENCIA.descripcion_agencia, OPERACION.fecha_operacion "
        lsGsSql = lsGsSql & " FROM   TICKET.dbo.OPERACION OPERACION "
        lsGsSql = lsGsSql & "INNER Join TICKET.dbo.PRODUCTO_CONTRATADO PRODUCTO_CONTRATADO ON OPERACION.producto_contratado=PRODUCTO_CONTRATADO.producto_contratado "
        lsGsSql = lsGsSql & "INNER JOIN CATALOGOS.dbo.CLIENTE CLIENTE ON (PRODUCTO_CONTRATADO.cuenta_cliente=CLIENTE.cuenta_cliente) AND (PRODUCTO_CONTRATADO.agencia=CLIENTE.agencia) "
        lsGsSql = lsGsSql & "INNER JOIN CATALOGOS.dbo.AGENCIA AGENCIA ON PRODUCTO_CONTRATADO.agencia=AGENCIA.agencia    "
        lsGsSql = lsGsSql & " WHERE  OPERACION.operacion_definida = OPERACION.operacion_definida "
        lsGsSql = lsGsSql & " And OPERACION.fecha_operacion = '" & sFechaInicio & "' "
        lsGsSql = lsGsSql & " And OPERACION.status_operacion In (2,3,4,5) "
        lsGsSql = lsGsSql & " And OPERACION.operacion_definida=8100 "
        lsGsSql = lsGsSql & " And PRODUCTO_CONTRATADO.agencia=1 "
        lsGsSql = lsGsSql & "  ORDER BY OPERACION.operacion"



        'MsgBox(sFechaInicio)
        'MsgBox(sFechaFin)
        'MsgBox("el query es: " & lsGsSql)

        Return Consulta(lsGsSql, "LoadCuentasAperturaValidadas")

    End Function

    Function LoadCuentasAperConsolidadoxTicket(ByVal sFechaInicio As String, ByVal sFechaFin As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = " Select distinct"
        lsGsSql = lsGsSql & " O.operacion AS [operacion],"
        lsGsSql = lsGsSql & " PC.cuenta_cliente AS [cuenta_cliente],"
        lsGsSql = lsGsSql & " O.monto_operacion AS [monto_operacion],"
        lsGsSql = lsGsSql & " case RO.impreso when 1 then 'Impreso' else '' end as [impreso]"
        lsGsSql = lsGsSql & " from "
        lsGsSql = lsGsSql & " TICKET..PRODUCTO_CONTRATADO PC,"
        lsGsSql = lsGsSql & " TICKET..OPERACION_DEFINIDA OD,"
        lsGsSql = lsGsSql & " TICKET..OPERACION O "
        lsGsSql = lsGsSql & " LEFT OUTER JOIN TICKET..REPORTE_OPERACION RO"
        lsGsSql = lsGsSql & " ON O.operacion = RO.operacion"
        lsGsSql = lsGsSql & " where operacion_definida_global =100 "
        lsGsSql = lsGsSql & " and O.fecha_operacion = '" & sFechaInicio & "' "
        lsGsSql = lsGsSql & " and O.status_operacion in (2,3,4,5) "
        lsGsSql = lsGsSql & " and O.status_operacion <> 250 "
        lsGsSql = lsGsSql & " and O.producto_contratado = PC.producto_contratado"
        lsGsSql = lsGsSql & " and OD.operacion_definida = O.operacion_definida"
        lsGsSql = lsGsSql & " and PC.agencia = 1 "
        lsGsSql = lsGsSql & " order by O.operacion"


        'MsgBox(sFechaInicio)
        'MsgBox(sFechaFin)
        'MsgBox("el query es: " & lsGsSql)

        Return Consulta(lsGsSql, "LoadCuentasAperConsolidadoxTicket")

    End Function

    Function LoadCatalogoAlertas() As DataTable
        Dim lsGsSql As String

        lsGsSql = "  SELECT descripcion_bloqueo_observacio "
        lsGsSql &= " FROM   TICKET.dbo.BLOQUEO_OBSERVACION "
        lsGsSql &= " WHERE  status_bloqueo = 3 "

        Return Consulta(lsGsSql, "LoadCatalogoAlertas")

    End Function

    Function LoadCatalogoBloqueos() As DataTable
        Dim lsGsSql As String

        lsGsSql = "  SELECT descripcion_bloqueo_observacio "
        lsGsSql &= " FROM   TICKET.dbo.BLOQUEO_OBSERVACION "
        lsGsSql &= " WHERE  status_bloqueo = 1 "

        Return Consulta(lsGsSql, "LoadCatalogoBloqueos")

    End Function

#End Region



#Region "Reportes GONET Beatriz A Palacios"

    Function ObtieneOperacionesMT103(ByVal sFecha As String) As DataTable

        Dim s As String
        s = ("  Select OP.operacion, case RS.status_envio when 1 then 'Si' else 'No' end as enviado
                From TICKET..REPORTE_SWIFT_MT103 RS, TICKET..OPERACION_DEFINIDA OD,
                TICKET..OPERACION OP 
                Where RS.operacion = OP.operacion and
                OP.operacion_definida = OD.operacion_definida and
                OD.agencia in (1 ) and
                OP.status_operacion <> 250 and
                OP.fecha_operacion = '" & sFecha & "'")

        Return Consulta(s, "ObtieneOperacionesMT103")

    End Function

#End Region

#Region "Reportes Operativa MNI"
    Function ObtieneCuentas000(ByVal sCadenaSQL As String) As DataTable

        Return Consulta(sCadenaSQL, "ObtieneCuentas000")

    End Function

    Function EjecutaSP(ByVal sStoreProcedure As String) As DataTable

        'Return SP(sStoreProcedure, "EjecutaSP")
        Return Consulta(sStoreProcedure, "EjecutaSP")

    End Function


    Function LoadSaldos000(ByVal lsGsSql As String) As DataTable

        Return Consulta(lsGsSql, "LoadSaldos000")

    End Function


    Function HayRegistros(ByVal lsGsSql As String) As String

        Return regresa_count(lsGsSql, "HayRegistros")

    End Function

    Function RealizaConsulta(ByVal lsGsSql As String) As DataTable

        Return Consulta(lsGsSql, "RealizaConsulta")

    End Function


    Function LoadOperacionesApliCont(ByVal sFechaInicio As String, ByVal sFechaFin As String) As DataTable
        Dim lsGsSql As String
        lsGsSql = "Select vwte.operacion_definida_global, vwte.operacion, vwte.cuenta_cliente, vwte.descripcion_operacion_definida, "
        lsGsSql &= " vwte.fecha_captura, vwte.fecha_contabilidad, vwte.monto_operacion, vwte.fecha_operacion, "
        lsGsSql &= " vwte.Origen, vwte.descripcion_status, vwte.mt202, vwte.nombre_centro_origen, vwte.captura "
        lsGsSql &= " From TICKET.dbo.vw_tareas_entradas vwte "
        lsGsSql &= " Where vwte.fecha_contabilidad = '" & sFechaInicio & "' "
        lsGsSql &= " And vwte.agencia = 1 "
        lsGsSql &= " UNION "
        lsGsSql &= " Select vwte.operacion_definida_global, vwte.operacion, vwte.cuenta_cliente, vwte.descripcion_operacion_definida, "
        lsGsSql &= " vwte.fecha_captura, vwte.fecha_contabilidad, vwte.monto_operacion, vwte.fecha_operacion, "
        lsGsSql &= " vwte.Origen, vwte.descripcion_status, vwte.mt202, vwte.nombre_centro_origen, vwte.captura "
        lsGsSql &= " From TICKET.dbo.vw_tareas_entradas vwte "
        lsGsSql &= " Where vwte.fecha_contabilidad = '" & sFechaFin & "' "
        lsGsSql &= " And vwte.agencia = 1 "
        lsGsSql &= " Order By vwte.fecha_contabilidad, vwte.Origen "
        'MsgBox(sFechaInicio)
        'MsgBox(sFechaFin)
        'MsgBox("el query es: " & lsGsSql)
        Return Consulta(lsGsSql, "LoadOperacionesApliCont")
    End Function

#End Region
#Region "Permisos Seguridad"
    Function obtiene_permisos_autorizaciones(ByVal iUsuario As Integer, ByVal iAplic As Integer) As DataTable
        Dim lsGsSql As String
        lsGsSql = "SELECT PF.masc_permisos, PU.masc_permisos, "
        lsGsSql &= " PF.masc_autorizaciones, PU.masc_autorizaciones FROM "
        lsGsSql &= " CATALOGOS.dbo.PERMISOS_X_USUARIO_HEXA PU, "
        lsGsSql &= " CATALOGOS.dbo.PERFIL_HEXA PF"
        lsGsSql &= " WHERE PU.usuario = " & iUsuario
        lsGsSql &= " And PU.perfil = PF.perfil And PF.aplicacion = " & iAplic

        Return Consulta(lsGsSql, "obtiene_permisos_autorizaciones")
    End Function

    Function LogOn() As Boolean
        On Error GoTo errLogOn
        If TypeName(funcionalidades.ActiveForm) = "Nothing" Then

            Dim lo_LoginDialog As New Login
            Dim lb_loggedin As Boolean

            'Inicializamos el arreglo de autorizaciones remotas
            '-ReDim ga_PermisosRemotos(0)
            LogOn = False
            'Set lo_LoginDialog = New Login
            lo_LoginDialog.ShowDialog()

            lb_loggedin = lo_LoginDialog.bLogin
            'Set lo_LoginDialog = Nothing
            'Revisa si el usuario ya se dio de alta en la aplicacion
            If lb_loggedin Then
                'revisa el usuario en la BD
                'gs_sql = "SELECT equipo, convert(char(10),fecha_login,105) FROM "
                'gs_sql = gs_sql & DBCATALOGOS & "..USUARIO_X_APLICACION WHERE"
                'gs_sql = gs_sql & " usuario = " & gn_Usuario
                'gs_sql = gs_sql & " AND aplicacion = " & NumAplicacion
                'dbExecQuery(gs_sql)
                'dbGetRecord
                'Si el usuario fue encontrado y no es la misma PC, lo notifica
                'If Not IsdbError Then
                'If UCase(Trim(dbGetValue(0))) <> UCase(gnGetComputerName) Then
                '    lb_loggedin = False
                '    gn_Usuario = 0
                '    MsgBox "Ya existe una sesión para este usuario en el " & vbCrLf & "equipo " & Trim(dbGetValue(0)) &
                '           " iniciada en la fecha " & Trim(dbGetValue(1)) & ".", vbCritical, "Acceso no permitido..."
                'Else
                '    gs_sql = "UPDATE " & DBCATALOGOS & "..USUARIO_X_APLICACION "
                '    gs_sql = gs_sql & "SET fecha_login = getdate() "
                '    gs_sql = gs_sql & "WHERE usuario=" & gn_Usuario & " AND "
                '    gs_sql = gs_sql & "aplicacion=" & NumAplicacion
                '    dbExecQuery(gs_sql)
                '    dbEndQuery
                'End If
                'Si el usuario no fue encontrado lo registra
                'Else
                'dbEndQuery
                'gs_sql = "INSERT INTO " & DBCATALOGOS & "..USUARIO_X_APLICACION "
                'gs_sql = gs_sql & "(usuario, aplicacion, fecha_login, equipo) VALUES ("
                'gs_sql = gs_sql & gn_Usuario & ", "
                'gs_sql = gs_sql & NumAplicacion & ", "
                'gs_sql = gs_sql & "getdate(), "
                'gs_sql = gs_sql & "'" & Trim(gnGetComputerName) & "')"
                'dbExecQuery(gs_sql)
                ''Si fallo el registro notifica al usuario
                'If dbError Then
                '    lb_loggedin = False
                '    gn_Usuario = 0
                '    MsgBox "No es posible registrar el ingreso a la aplicación.", vbCritical, "Acceso no permitido..."
                'End If
                'End If
                'dbEndQuery
            End If
            LogOn = lb_loggedin
        End If
        Exit Function
errLogOn:
        MsgBox("Error: " & Err.Number & " " & Err.Description, MsgBoxStyle.Critical, "Error al entrar al Sistema.")

    End Function
#End Region

#Region "MantenimientoHorarios"
    Function ActualizaHorariosOpeCash(MsTabla As String, hrini As String, hrfin As String, hrpass As String, param As String) As Integer

        Dim Query As String
        Dim Registro As Integer

        Query = "    Update " & MsTabla & " set " &
                    "hora_inicio=convert(datetime,'" & hrini & "'), " &
                     "hora_fin=convert(datetime,'" & hrfin & "'), " &
                     "hora_password=convert(datetime,'" & hrpass & "') " &
                     "where parametro = " & param
        Registro = insertar(Query)

        Return Registro

    End Function
#End Region

#Region "QUERYS DEL MODULO CHEQUERAS"

    'Funciones desarrolladas por Susan Gabriela Gómez González - SGGG 22-06-2020

    'Obtiene el tipo de chequera para ser llenado el combo de chequeras en Solicitud Normal
    Function LoadTipoChequera() As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select Distinct descripcion, tipo_chequera "
        lsGsSql &= "From TICKET..TIPO_CHEQUERA (nolock) Where tipo_chequera > 1"

        Return Consulta(lsGsSql, "LoadTipoChequera")

    End Function

    'Inserta la sucursal si no se encuentra dada de alta
    Function InsertaSucursal_CHQ(ByVal sNumSucCta As String, ByVal sSucCta As String) As Integer

        Dim lsGsSql As String

        lsGsSql = "INSERT INTO CATALOGOS..SUCURSAL_CHQ "
        lsGsSql &= "(suc_sucursal, suc_nombre, suc_bbvab) values ('"
        lsGsSql &= sNumSucCta.PadLeft(7, "0") & "', '" & UCase(sSucCta) & "',1)"

        Return insertar(lsGsSql)

    End Function

    'Obtiene las sucursales para poder llenar el combo 
    Function LoadSucursal(ByVal nomSucursal As String, ByVal numSucursal As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select suc_sucursal, suc_nombre From  CATALOGOS..SUCURSAL_CHQ (nolock) "

        'Si existe texto en el combo, busca por nombre
        If Trim$(nomSucursal) <> "" Then
            lsGsSql &= "Where UPPER(suc_nombre) Like '%" & UCase$(Trim$(nomSucursal)) & "%'"

            'Si existe número de sucursal, busca por número
        ElseIf Trim$(numSucursal) <> "" Then
            lsGsSql &= "Where suc_sucursal = '" & Trim$(numSucursal).PadLeft(7, "0") & "' "
        End If

        lsGsSql &= " Order By suc_nombre"

        Return Consulta(lsGsSql, "LoadSucursal")

    End Function

    'Obtiene datos del cliente
    Function ObtieneDatoscliente(ByVal sNumCta As String) As DataTable

        Dim lsGsSql As String

        lsGsSql = "Select PC.producto_contratado, "
        lsGsSql &= "rtrim(STUFF (LOWER(CL.nombre_cliente), 1, 1, UPPER(left(CL.nombre_cliente, 1))))+' '+ "
        lsGsSql &= "rtrim(IsNull(STUFF (LOWER(CL.apellido_paterno), 1, 1, UPPER(left(CL.apellido_paterno, 1))), Space(0)))+' '+ "
        lsGsSql &= "rtrim(IsNull(STUFF (LOWER(CL.apellido_materno), 1, 1, UPPER(left(CL.apellido_materno, 1))), Space(0))) "
        lsGsSql &= "+' ('+ AG.descripcion_agencia + ')' AS nombrecliente, "
        lsGsSql &= "AG.descripcion_agencia   "
        lsGsSql &= "From CATALOGOS..CLIENTE CL (nolock) , CATALOGOS..AGENCIA AG (nolock) , "
        lsGsSql &= "TICKET..PRODUCTO_CONTRATADO PC (nolock), "
        lsGsSql &= "TICKET..CUENTA_EJE CE, "
        lsGsSql &= "vw_cuentas_chequera CC "
        lsGsSql &= "Where "
        lsGsSql &= "AG.agencia = PC.agencia And "
        lsGsSql &= "CC.agencia = PC.agencia And "
        lsGsSql &= "CL.agencia = PC.agencia And "
        If Trim$(sNumCta) <> "" Then
            lsGsSql &= "CL.cuenta_cliente = '" & Trim$(sNumCta) & "' And "
        End If
        lsGsSql &= "PC.cuenta_cliente = CL.cuenta_cliente And "
        lsGsSql &= "PC.producto In ( 8009, 2009, 3009 ) And "
        lsGsSql &= "PC.status_producto In ( 8001, 2001, 3001 ) And "
        lsGsSql &= "CE.producto_contratado = PC.producto_contratado And "
        lsGsSql &= "CC.tipo_cuenta_eje = CE.tipo_cuenta_eje "
        lsGsSql &= "Order by rtrim(CL.nombre_cliente)+' '+rtrim(IsNull(CL.apellido_paterno, Space(0)))+' '+rtrim(IsNull(CL.apellido_materno, Space(0)))"

        Return Consulta(lsGsSql, "ObtieneDatoscliente")

    End Function

    'Obtiene el numero de cuenta
    Function ObtieneNumCuenta(ByVal Ln_ProdCont As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "SELECT cuenta_cliente FROM TICKET..PRODUCTO_CONTRATADO (nolock)"
        lsGsSql &= " Where producto_contratado = " & Ln_ProdCont

        Return Consulta(lsGsSql, "ObtieneNumCuenta")

    End Function

    'Obtiene el ultimo numero de cheque de la cuenta indicada
    Function ObtieneCheque(ByVal Ln_ProdCont As Long) As DataTable
        Dim lsGsSql As String

        lsGsSql = "select isnull(ultimo_cheque,0), ISNULL(ultima_longfolio,0) "
        lsGsSql &= "from CHEQUERAS (nolock) where chequera = ("
        lsGsSql &= " Select ISNULL(max(chequera),0) "
        lsGsSql &= " From TICKET..CHEQUERAS(nolock) "
        lsGsSql &= " Where producto_contratado = " & Ln_ProdCont & " And "
        lsGsSql &= " status_chequera In ( 1, 2, 3 ))"

        Return Consulta(lsGsSql, "ObtieneCheque")

    End Function

    'Actualiza el Cliente para indicarle que tiene chequera
    Function ActualizaCliente(ByVal sProdCont As String)
        Dim lsGsSql As String
        Dim Registro As Integer

        lsGsSql = "Update CATALOGOS..CLIENTE "
        lsGsSql &= "Set tiene_chequera = 1 From "
        lsGsSql &= "CATALOGOS..CLIENTE CL, "
        lsGsSql &= "TICKET..PRODUCTO_CONTRATADO PC "
        lsGsSql &= "Where "
        lsGsSql &= "PC.cuenta_cliente = CL.cuenta_cliente and "
        lsGsSql &= "PC.agencia = CL.agencia and "
        lsGsSql &= "PC.producto_contratado = " & sProdCont

        Registro = insertar(lsGsSql)
        Return Registro

    End Function

    'Inserta el evento en chequera
    Function InsertaEvenCheq(ByVal sComentario As String, ByVal sRegistro As String, ByVal iStaus As Integer)
        Dim lsGsSql As String
        Dim Registro As Integer

        lsGsSql = "Insert Into TICKET..EVENTO_CHEQUERA ( chequera, descripcion, "
        lsGsSql &= "fecha_evento, usuario_evento, status_chequera ) "
        lsGsSql &= "Values ( "
        lsGsSql &= sRegistro & ", "
        lsGsSql &= "'" & Trim$(sComentario) & "', "
        lsGsSql &= "getdate(), "
        lsGsSql &= usuario & ", "
        lsGsSql &= iStaus & " )"

        Registro = insertar(lsGsSql)
        Return Registro

    End Function

    'Valida si ya existe una chequera para la cuenta
    Function ExisteCHQ(ByVal sProductoCont As String) As DataTable
        Dim lsGsSql As String

        'Busca datos de una solicitud de chequera previa
        lsGsSql = "Select ISNULL(Max ( chequera ),0) From TICKET..CHEQUERAS (nolock) Where "
        lsGsSql &= "producto_contratado = " & sProductoCont

        Return Consulta(lsGsSql, "ExisteCHQ")

    End Function

    'obtiene los datos de la chequera anterior
    Function DatosCHQAnterior(ByVal sChqAnterior As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select num_func_envio, cr_envio, desc_cr_envio, "
        lsGsSql &= "plaza_envio, desc_plaza_envio, sucursal_envio, "
        lsGsSql &= "desc_suc_envio, cta_eje_envio = right(rtrim(cta_eje_envio), 10), "
        lsGsSql &= "sucursal_solicita, funcionario_solicita, num_func_solicita, "
        lsGsSql &= "cr_solicita "
        lsGsSql &= " From TICKET..CHEQUERAS (nolock) "
        lsGsSql &= "Where chequera = " & sChqAnterior

        Return Consulta(lsGsSql, "DatosCHQAnterior")
    End Function

    'Obtiene los datos de la cuenta Eje 
    Function DatosCuentaEje(ByVal sProducto As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select cuenta_eje_pesos = ISNULL(right(rtrim(CL.cuenta_eje_pesos), 10),0) From TICKET..PRODUCTO_CONTRATADO PC, "
        lsGsSql &= "CATALOGOS..CLIENTE CL (nolock) Where "
        lsGsSql &= "CL.cuenta_cliente = PC.cuenta_cliente And "
        lsGsSql &= "CL.agencia = PC.agencia And "
        lsGsSql &= "PC.producto_contratado = " & sProducto

        Return Consulta(lsGsSql, "DatosCuentaEje")

    End Function

    'Obtiene los datos del centro regional
    Function DatosCR(ByVal sNumCR As String) As DataTable
        Dim lsGsSql As String
        lsGsSql = "Select CR.nombre_centro_regional From "
        lsGsSql &= "CATALOGOS..CENTRO_REGIONAL CR (nolock) Where "
        lsGsSql &= "CR.centro_regional = " & sNumCR
        lsGsSql &= " Order By CR.nombre_centro_regional"

        Return Consulta(lsGsSql, "DatosCR")
    End Function

    'Inserta chequera
    Function InsertaChequera(ByVal bTpSol As Integer, ByVal sProdCont As String,
                             ByVal sNumSucursal As String,
                             ByVal sNombreFunc As String, ByVal sNumFunc As String,
                             ByVal sFuncPesos As String, ByVal sNumCRCta As String,
                             ByVal sCRCta As String, ByVal sNumSucCta As String,
                             ByVal sSucCta As String, sCtaEje As String,
                             ByVal sNumCheques As String, ByVal lnUltimoChq As Integer,
                             ByVal LnLongCHQ As String, lnStatus As String,
                             ByVal sNumCR As String, ByVal Erroneo As Boolean,
                             ByVal sComentario As String) As DataTable
        Dim lsGsSql As String
        Dim lsGsSql2 As String
        Dim sLastPart As String
        sLastPart = ""
        Dim d As New Datasource
        Dim dRegistro As DataTable
        Dim conec As SqlConnection = get_coneccion_sql()
        Dim command As SqlCommand = conec.CreateCommand
        Dim Transac As SqlTransaction
        Dim iRegistro As Integer
        Dim iFolioIni As Integer
        Dim iFolioFin As Integer

        If Trim$(sSucCta).Length >= 40 Then
            sSucCta = sSucCta.Substring(0, 39)
        End If

        If valida_coneccion_sql() Then
            conec.Open()
            Transac = conec.BeginTransaction()
            command.Connection = conec
            command.Transaction = Transac

            Try
                lsGsSql = "Insert Into TICKET..CHEQUERAS ( orden, fecha_solicitud, "
                lsGsSql &= "producto_contratado, "

                'Si es Chequera Normal
                If bTpSol = 1 Then
                    lsGsSql &= "sucursal_solicita, funcionario_solicita, num_func_solicita, "
                End If

                lsGsSql &= "num_func_envio, cr_envio, "
                lsGsSql &= "desc_cr_envio, plaza_envio, "
                lsGsSql &= "desc_plaza_envio, sucursal_envio, "
                lsGsSql &= "desc_suc_envio, cta_eje_envio, "
                lsGsSql &= "tipo_chequera, total_cheques, "
                lsGsSql &= "ultimo_cheque, status_chequera, "
                lsGsSql &= "usuario_solicita, bbvab, cr_solicita, plaza_solicita, ultima_longfolio ) "
                lsGsSql &= "Values ( 0, GETDATE(), "
                lsGsSql &= sProdCont & ", "

                'Si es Chequera Normal
                If bTpSol = 1 Then
                    lsGsSql &= "'" & sNumSucursal.PadLeft(7, "0") & "', "
                    lsGsSql &= "'" & Trim$(sNombreFunc) & "', "
                    lsGsSql &= "'" & Trim$(sNumFunc) & "', "
                End If

                lsGsSql &= "'" & Trim$(sFuncPesos) & "', "
                lsGsSql &= "'" & Trim$(sNumCRCta) & "', "
                lsGsSql &= "'" & Trim$(sCRCta) & "', "
                lsGsSql &= "' ', ' ', "
                lsGsSql &= "'" & sNumSucCta.PadLeft(7, "0") & "', "
                lsGsSql &= "'" & Trim$(sSucCta) & "', "
                lsGsSql &= "'" & Trim$(sCtaEje) & "', "

                'si es Chequera Normal
                If bTpSol = 1 Then
                    'Si es chequera de 500 cheques
                    If Val(sNumCheques) = 500 Then

                        lsGsSql &= "5, "
                        lsGsSql &= "100, "
                        For ln_Orden = 1 To 5
                            lsGsSql2 = ""
                            lsGsSql2 = lsGsSql
                            lnUltimoChq = lnUltimoChq + 100
                            sLastPart = Right(CStr(lnUltimoChq), LnLongCHQ) & ", "
                            lsGsSql2 &= sLastPart & lnStatus & ", " & usuario & ", 1, '" &
                                    Trim$(sNumCR) & "', '  ', " & LnLongCHQ & ")"

                            lsGsSql2 &= "     
                                    Select @@Identity"
                            dRegistro = d.Consulta(lsGsSql2, "InsertaChequera")
                            iRegistro = dRegistro.Rows(0).Item(0)

                        Next ln_Orden
                        'Inserta evento Chequera
                        d.InsertaEvenCheq(sComentario, iRegistro, lnStatus)
                        'Es solicitud Errónea
                        If Erroneo = True Then
                            iFolioIni = lnUltimoChq - 499
                            iFolioFin = lnUltimoChq - 499

                        Else
                            'Es solicitud normal
                            iFolioIni = lnUltimoChq - 499
                            iFolioFin = lnUltimoChq
                        End If
                        Return dRegistro
                        Exit Function
                    Else
                        If sNumCheques = 25 Then
                            lsGsSql &= "2, "
                        ElseIf sNumCheques = 50 Then
                            lsGsSql &= "3, "
                        ElseIf sNumCheques = 100 Then
                            lsGsSql &= "4, "
                        End If
                    End If
                Else
                    lsGsSql &= "1, "
                End If

                lsGsSql &= Val(sNumCheques) & ", "
                lsGsSql &= Right(CStr(lnUltimoChq + Val(sNumCheques)), LnLongCHQ) & ", "
                lsGsSql &= lnStatus & ", " & usuario & ", 1, '" &
                    Trim$(sNumCR) & "', '  ', " & LnLongCHQ & " )"
                lsGsSql &= "     
                Select @@Identity"
                dRegistro = d.Consulta(lsGsSql, "InsertaChequera")
                iRegistro = dRegistro.Rows(0).Item(0)
                'Inserta evento Chequera
                d.InsertaEvenCheq(sComentario, iRegistro, lnStatus)
                Transac.Commit()
                Return dRegistro
            Catch ex As Exception
                'Console.WriteLine("Error en Commit " & ex.GetType() & " " & ex.Message)
                Try
                    Transac.Rollback()
                Catch ex2 As Exception
                    'Msgbox("Error en Rollback " & ex2.GetType() & " " & ex2.Message)
                End Try
            End Try
        End If
    End Function

#Region "CONSULTA APERTURA CHEQUERA PENDIENTE"
    'Obtiene los tickets de apertira de chequeras pendientes, para llenar el grid
    Function ObtieneSolicitudPend(ByVal sFechaIni As String, ByVal sFechaFin As String) As DataTable

        Dim lsGsSql As String

        lsGsSql = "Select OP.operacion, PC.cuenta_cliente, "
        lsGsSql &= "Convert ( Char ( 10 ), OP.fecha_operacion, 105 ) fecha "
        lsGsSql &= "From CATALOGOS..CLIENTE CL (NOLOCK), "
        lsGsSql &= "TICKET..PRODUCTO_CONTRATADO PC (NOLOCK), TICKET..CUENTA_EJE CE (NOLOCK), "
        lsGsSql &= "TICKET..OPERACION OP (NOLOCK), vw_cuentas_chequera CC "
        lsGsSql &= "Where OP.fecha_operacion > '" & DateAdd("d", -1, sFechaIni).ToString("MM-dd-yyyy") & "' "
        lsGsSql &= "  And OP.fecha_operacion < '" & DateAdd("d", 1, sFechaFin).ToString("MM-dd-yyyy") & "' "
        lsGsSql &= "  And PC.cuenta_cliente = CL.cuenta_cliente "
        lsGsSql &= "  And PC.producto In ( 8009, 3009 ) "
        lsGsSql &= "  And OP.producto_contratado = PC.producto_contratado "
        lsGsSql &= "  And OP.operacion_definida In ( 8100, 3100 ) "
        lsGsSql &= "  And PC.status_producto In ( 8001, 3001 ) "
        lsGsSql &= "  And CE.producto_contratado = PC.producto_contratado "
        lsGsSql &= "  And CC.tipo_cuenta_eje = CE.tipo_cuenta_eje "
        lsGsSql &= "  And OP.status_operacion In ( 2, 3, 4 ) "
        lsGsSql &= "  And CC.agencia = PC.agencia "
        lsGsSql &= "  And CL.agencia = PC.agencia "
        lsGsSql &= "  And PC.agencia = 1 "
        lsGsSql &= "  And CL.tiene_chequera = 1 "
        lsGsSql &= "  And PC.producto_contratado Not In ( "
        lsGsSql &= "Select Distinct producto_contratado From CHEQUERAS "
        lsGsSql &= "Where status_chequera <> 5 ) "
        lsGsSql &= "Order By OP.fecha_operacion, PC.cuenta_cliente"

        Return Consulta(lsGsSql, "ObtieneSolicitudPend")
    End Function

    'Obtiene los datos de la cuenta de apertura seleccionada, mediante el ticket
    Function DatosConsCHQApert(ByVal sticket As String) As DataTable

        Dim lsGsSql As String
        lsGsSql = "Select AG.prefijo_agencia, "
        lsGsSql &= "CL.cuenta_cliente, "
        lsGsSql &= "rtrim(CL.tratamiento)+' '+rtrim(CL.nombre_cliente)+' '+rtrim(IsNull(CL.apellido_paterno, Space(0)))+' '+rtrim(IsNull(CL.apellido_materno, Space(0))), "
        lsGsSql &= "TC.sufijo_kapiti, "
        lsGsSql &= "ISNULL( CL.funcionario_pesos,'') funcionario_pesos, "
        lsGsSql &= "CL.funcionario, "
        lsGsSql &= "CL.cuenta_eje_pesos "
        lsGsSql &= "From CATALOGOS..CLIENTE CL, CATALOGOS..AGENCIA AG, "
        lsGsSql &= "TICKET..PRODUCTO_CONTRATADO PC, TICKET..TIPO_CUENTA_EJE TC, "
        lsGsSql &= "TICKET..CUENTA_EJE CE, TICKET..OPERACION OP "
        lsGsSql &= "Where OP.operacion = " & sticket & " and "
        lsGsSql &= "CE.producto_contratado = PC.producto_contratado and "
        lsGsSql &= "TC.tipo_cuenta_eje = CE.tipo_cuenta_eje and "
        lsGsSql &= "CL.cuenta_cliente = PC.cuenta_cliente and "
        lsGsSql &= "CL.agencia = PC.agencia and "
        lsGsSql &= "AG.agencia = PC.agencia and "
        lsGsSql &= "PC.producto_contratado = OP.producto_contratado "

        Return Consulta(lsGsSql, "DatosConsCHQApert")

    End Function

    'Obtiene datos de los Gestores (Funcionarios) asociados a la Chequera
    Function DatosGestoresCHQ(ByVal sFuncionario As String) As DataTable
        Dim lsGsSql As String
        lsGsSql = "Select "
        lsGsSql &= "UR.cr, "
        lsGsSql &= "UR.plaza, "
        lsGsSql &= "UR.sucursal, "
        lsGsSql &= "FU.numero_funcionario, "
        lsGsSql &= "rtrim(FU.nombre_funcionario)+' '+rtrim(IsNull(FU.apellido_paterno, Space(0)))+' '+rtrim(IsNull(apellido_materno, Space(0))) "
        lsGsSql &= "From FUNCIONARIOS.Funcionario.UNIDAD_ORGANIZACIONAL_RESUMEN UR, "
        lsGsSql &= "FUNCIONARIOS..FUNCIONARIO FU "
        lsGsSql &= "Where"
        lsGsSql &= " UR.funcionario = FU.funcionario"
        lsGsSql &= " and FU.funcionario = " & sFuncionario

        Return Consulta(lsGsSql, "DatosGestoresCHQ")
    End Function
#End Region

#Region "BUSCAR CHEQUERA POR CUENTA o FECHA"

    Function ObtDatosCHQCtaFecha(ByVal iTipoCons As Integer, ByVal sCuentaIni As String,
                 ByVal sCuentaFin As String, ByVal sFechaIni As String,
                 ByVal sFechaFin As String) As DataTable
        Dim lsGsSql As String
        Dim d As New Datasource

        lsGsSql = "Select "
        lsGsSql &= "convert(char(10),CH.fecha_solicitud,105) fecha, "
        lsGsSql &= "CH.num_func_envio, "
        lsGsSql &= "CH.cr_envio, "
        lsGsSql &= "substring(CH.sucursal_envio,1,3) plaza_envio, "
        lsGsSql &= "substring(CH.sucursal_envio,4,4) sucursal_envio, "
        lsGsSql &= "CH.cta_eje_envio, "
        lsGsSql &= "CH.num_func_solicita, "
        lsGsSql &= "CH.cr_solicita, "
        lsGsSql &= "substring(CH.sucursal_solicita,1,3) plaza_sol, "
        lsGsSql &= "substring(CH.sucursal_solicita,4,4) sucursal_sol, "
        lsGsSql &= "CH.total_cheques, "
        lsGsSql &= "case CH.tipo_chequera when 1 then 'Especial' else 'Normal' end  tipo_chequera, "
        lsGsSql &= "CH.chequera, "
        lsGsSql &= "CH.ultimo_cheque, "
        lsGsSql &= "CH.orden, "
        lsGsSql &= "ST.descripcion_status "
        lsGsSql &= "From "
        lsGsSql &= "CATALOGOS..CLIENTE CL, "
        lsGsSql &= "CATALOGOS..AGENCIA AG, "
        lsGsSql &= "TICKET..CUENTA_EJE CE, "
        lsGsSql &= "TICKET..STATUS_CHEQUERA ST, "
        lsGsSql &= "TICKET..TIPO_CUENTA_EJE TC, "
        lsGsSql &= "TICKET..PRODUCTO_CONTRATADO PC, "
        lsGsSql &= "CATALOGOS..SUCURSAL SS "
        lsGsSql &= "RIGHT OUTER JOIN TICKET..CHEQUERAS CH "
        lsGsSql &= "ON SS.sucursal = CH.sucursal_solicita "
        lsGsSql &= "Where "
        lsGsSql &= "CL.agencia = PC.agencia and "
        lsGsSql &= "CL.cuenta_cliente = PC.cuenta_cliente and "
        lsGsSql &= "CE.producto_contratado = PC.producto_contratado and "
        lsGsSql &= "PC.producto_contratado = CH.producto_contratado and "
        lsGsSql &= "ST.status_chequera = CH.status_chequera and "
        lsGsSql &= "TC.tipo_cuenta_eje = CE.tipo_cuenta_eje And "
        lsGsSql &= "AG.agencia = PC.agencia and "
        lsGsSql &= "PC.agencia = 1"
        If iTipoCons = 1 Then
            lsGsSql &= " and PC.cuenta_cliente >= '" & Trim(sCuentaIni) & "'"
            lsGsSql &= " and PC.cuenta_cliente <= '" & Trim(sCuentaFin) & "'"
        End If
        If iTipoCons = 2 Then
            lsGsSql &= " and CH.fecha_solicitud > '" & DateAdd("d", 0, sFechaIni).ToString("MM-dd-yyyy") & "' "
            lsGsSql &= " and CH.fecha_solicitud < '" & DateAdd("d", 1, sFechaFin).ToString("MM-dd-yyyy") & "' "
        End If
        lsGsSql &= " Order by CH.fecha_solicitud"

        Return Consulta(lsGsSql, "ObtDatosCHQCtaFecha")
    End Function
#End Region
#Region "CANCELAR CHEQUERAS"
    'Busca chequeras a cancelar ya sea por rango de fecha, cuenta o ambas
    Function ObtieneChequera(ByVal sCuenta1 As String, ByVal sCuenta2 As String,
                             ByVal sFechaini As String, ByVal sFechaFin As String) As DataTable
        Dim lsGsSql As String
        lsGsSql = "Select CH.chequera, Convert ( char(10), CH.fecha_solicitud, 105 ) fecha, "
        lsGsSql &= "PC.cuenta_cliente, CH.total_cheques "
        lsGsSql &= "From TICKET..CHEQUERAS CH, TICKET..PRODUCTO_CONTRATADO PC "
        lsGsSql &= "Where PC.producto_contratado = CH.producto_contratado "
        lsGsSql &= "And CH.status_chequera In ( 1, 2 ) "
        If sCuenta1 <> "" Then
            lsGsSql &= "And PC.cuenta_cliente >= '" & sCuenta1 & "' "
            lsGsSql &= "And PC.cuenta_cliente <= '" & sCuenta2 & "' "
        End If

        If sFechaini <> "" Then
            lsGsSql &= "And CH.fecha_solicitud >= '" & DateAdd("d", 0, sFechaini).ToString("MM-dd-yyyy") & " 00:01AM' "
            lsGsSql &= "And CH.fecha_solicitud <= '" & DateAdd("d", 0, sFechaFin).ToString("MM-dd-yyyy") & " 11:59PM' "
        End If

        lsGsSql &= "And PC.agencia = 1 "
        lsGsSql &= "Order By CH.fecha_solicitud, PC.cuenta_cliente"


        Return Consulta(lsGsSql, "ObtieneChequera")
    End Function

    Function DatosConsCancelCHQ(ByVal iChequera As Integer)
        Dim lsGsSql As String
        lsGsSql = "Select AG.prefijo_agencia, CT.cuenta_cliente, "
        lsGsSql &= "convert(char(10),CH.fecha_solicitud,105), "
        lsGsSql &= "rtrim(CT.tratamiento) + ' ' + rtrim(CT.nombre_cliente) + ' ' + rtrim(IsNull(CT.apellido_paterno, Space(0))) + ' ' + rtrim(IsNull(CT.apellido_materno, Space(0))), "
        lsGsSql &= "CH.num_func_envio, CH.cta_eje_envio, "
        lsGsSql &= "CH.num_func_solicita, CH.funcionario_solicita, "
        lsGsSql &= "CH.sucursal_solicita, CH.total_cheques, "
        lsGsSql &= "CH.ultimo_cheque, CH.chequera, "
        lsGsSql &= "CH.status_chequera, CH.tipo_chequera, "
        lsGsSql &= "CH.cr_envio, CH.desc_cr_envio, "
        lsGsSql &= "CH.plaza_envio, CH.desc_plaza_envio, "
        lsGsSql &= "CH.sucursal_envio, CH.desc_suc_envio, "
        lsGsSql &= "ISNULL(CH.cr_solicita,''), ISNULL(CH.plaza_solicita,'') "
        lsGsSql &= "From "
        lsGsSql &= "CATALOGOS..AGENCIA AG, "
        lsGsSql &= "CATALOGOS..CLIENTE CT, "
        lsGsSql &= "TICKET..PRODUCTO_CONTRATADO PC, "
        lsGsSql &= "TICKET..CHEQUERAS CH "
        lsGsSql &= "Where "
        lsGsSql &= "PC.producto_contratado = CH.producto_contratado and "
        lsGsSql &= "CT.cuenta_cliente = PC.cuenta_cliente and "
        lsGsSql &= "CT.agencia = PC.agencia and "
        lsGsSql &= "AG.agencia = PC.agencia and "
        lsGsSql &= "CH.chequera = " & iChequera

        Return Consulta(lsGsSql, "DatosConsCancelCHQ")
    End Function

    Function CancelaChequera(ByVal sNumCheques As String, ByVal iChequera As Integer,
                             ByVal laChequeras() As String) As String
        Dim lsGsSql As String
        Dim d As New Datasource
        Dim sRegistro As String
        Dim conec As SqlConnection = get_coneccion_sql()
        Dim command As SqlCommand = conec.CreateCommand
        Dim Transac As SqlTransaction
        Dim iRegistro As Integer

        If valida_coneccion_sql() Then
            conec.Open()
            Transac = conec.BeginTransaction()
            command.Connection = conec
            command.Transaction = Transac

            Try

                'Si es chequera de 500 cheques
                If Val(sNumCheques) = 500 Then
                    For lnContador = 0 To 4
                        lsGsSql = "Update CHEQUERAS Set status_chequera = 250 "
                        lsGsSql &= "Where chequera = " & laChequeras(lnContador)

                        iRegistro = insertar(lsGsSql)
                        'Inserta evento Chequera
                        d.InsertaEvenCheq("Cancelación de Solicitud de Chequera", laChequeras(lnContador), "250")
                    Next lnContador
                Else
                    lsGsSql = "Update TICKET..CHEQUERAS Set status_chequera = 250 "
                    lsGsSql &= "Where chequera = " & iChequera

                    iRegistro = insertar(lsGsSql)
                    'Inserta evento Chequera
                    d.InsertaEvenCheq("Cancelación de Solicitud de Chequera", iChequera, "250")
                End If
                sRegistro = "OK"
                Transac.Commit()
                Return sRegistro
            Catch ex As Exception
                sRegistro = "NOK"
                Transac.Rollback()
                Return sRegistro
            End Try
        End If
    End Function

    Function CancelaChequera500(ByVal iRegistro As String) As String()
        Dim lsGsSql As String
        Dim d As New Datasource
        Dim dDatosChequera As DataTable
        Dim dChequeras As DataTable
        Dim sRegistro As String
        Dim iChequera As Integer
        Dim saChequeras() As String

        lsGsSql = "Select  fecha_solicitud, producto_contratado, "
        lsGsSql &= "sucursal_solicita, funcionario_solicita, "
        lsGsSql &= "num_func_solicita, status_chequera, "
        lsGsSql &= "usuario_solicita From TICKET..CHEQUERAS "
        lsGsSql &= "Where chequera = " & iRegistro & " And "
        lsGsSql &= "tipo_chequera = 5 And "
        lsGsSql &= "total_cheques = 100"


        iChequera = 0
        ReDim saChequeras(1)
        dDatosChequera = d.Consulta(lsGsSql, "CancelaChequera500")
        If dDatosChequera.Rows().Count() = 0 Then
            MsgBox("No es posible actualizar la base de datos.", vbCritical, "SQL Server Error")
            sRegistro = "NOK"
            Return saChequeras
            Exit Function
        Else
            lsGsSql = "Select chequera From CHEQUERAS "
            lsGsSql &= "Where fecha_solicitud >= '" & CDate(dDatosChequera.Rows(0).Item(0)).ToString("yyyy-MM-dd") & "' And "
            lsGsSql &= "fecha_solicitud < '" & DateAdd("d", 1, dDatosChequera.Rows(0).Item(0)).ToString("yyyy-MM-dd") & "' and "
            lsGsSql &= "producto_contratado = " & Trim(dDatosChequera.Rows(0).Item(1)) & " And "
            lsGsSql &= "sucursal_solicita = '" & Trim(dDatosChequera.Rows(0).Item(2)) & "' And "
            lsGsSql &= "funcionario_solicita ='" & Trim(dDatosChequera.Rows(0).Item(3)) & "' And "
            lsGsSql &= "num_func_solicita = '" & Trim(dDatosChequera.Rows(0).Item(4)) & "' And "
            lsGsSql &= "status_chequera = " & Trim(dDatosChequera.Rows(0).Item(5)) & " And "
            lsGsSql &= "usuario_solicita = " & Trim(dDatosChequera.Rows(0).Item(6)) & " And "
            lsGsSql &= "tipo_chequera = 5 And "
            lsGsSql &= "total_cheques = 100"

            dChequeras = d.Consulta(lsGsSql, "CancelaChequera500")

            If dChequeras.Rows().Count() = 0 Then
                MsgBox("No es posible actualizar la base de datos.", vbCritical, "SQL Server Error")
                sRegistro = "NOK"
                Return saChequeras
                Exit Function
            Else
                iChequera = 0
                ReDim saChequeras(1)

                For Each dr As DataRow In dChequeras.Rows
                    ReDim Preserve saChequeras(iChequera)
                    saChequeras(iChequera) = Trim(dChequeras.Rows(iChequera).Item(0))
                    iChequera = iChequera + 1
                Next
                If iChequera = 1 Then
                    sRegistro = "NOK"
                    MsgBox("No es posible actualizar la base de datos.", vbCritical, "SQL Server Error")
                    Return saChequeras
                    Exit Function
                Else
                    sRegistro = d.CancelaChequera(500, 0, saChequeras)
                    Return saChequeras

                End If
            End If
        End If
    End Function

#End Region
#End Region



#Region "AICED - CAPTURA"

    Function ObtieneUsuarioGOS() As Integer
        Dim lsGsSql As String
        Dim dtUsuario As DataTable
        Dim dtUsuarioGOS As DataTable
        Dim iUsuario As Integer

        lsGsSql = "Select login from CATALOGOS..USUARIO "
        lsGsSql &= "where usuario = " & usuario
        dtUsuario = Consulta(lsGsSql, "LlenaTipoFuente")

        lsGsSql = "Select usuario From GOS..USUARIO "
        lsGsSql &= "Where login = '" & Trim(dtUsuario.Rows(0).Item(0)) & "'"
        dtUsuarioGOS = Consulta(lsGsSql, "LlenaTipoFuente")

        If dtUsuarioGOS.Rows().Count = 0 Then
            iUsuario = 0
        Else
            iUsuario = dtUsuarioGOS.Rows(0).Item(0)
        End If

        Return iUsuario
    End Function
    Function LlenaTipoFuente(ByVal sTpFuente As String) As DataTable
        Dim lsGsSql As String
        lsGsSql = "Select "
        lsGsSql &= "tipo_fuente, "
        lsGsSql &= "descripcion_tipo_fuente "
        lsGsSql &= "From "
        lsGsSql &= "GOS..TIPO_FUENTE "

        If sTpFuente = "" Then
            lsGsSql &= "Where bbvab = 1"
        Else
            lsGsSql &= "Where tipo_fuente = " & sTpFuente
        End If
        lsGsSql &= "order by tipo_fuente"

        Return Consulta(lsGsSql, "LlenaTipoFuente")
    End Function
    Function LlenaTipoDivisa(ByVal sDivisa As String) As DataTable
        Dim lsGsSql As String
        lsGsSql = "Select "
        lsGsSql &= "divisa, "
        lsGsSql &= "descripcion_divisa "
        lsGsSql &= "From "
        lsGsSql &= "GOS..DIVISAS "
        If sDivisa <> "" Then
            lsGsSql &= "WHERE divisa = " & sDivisa
        End If
        lsGsSql &= " order by divisa"

        Return Consulta(lsGsSql, "LlenaTipoDivisa")
    End Function
    Function DatoTipoFuente(ByVal bTipoFuente As Byte) As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select bbvab From GOS..TIPO_FUENTE where tipo_fuente = " & bTipoFuente

        Return Consulta(lsGsSql, "DatoTipoFuente")
    End Function

    Function DatosFuente(ByVal bTipoFuente As Byte, ByVal sSucursal As String) As DataTable
        Dim lsGsSql As String
        Dim dtDatosFuente As DataTable
        Dim dtFuene As DataTable

        lsGsSql = "Select distinct "
        lsGsSql &= "FU.fuente, "
        lsGsSql &= "descripcion_fuente "
        lsGsSql &= "From "
        lsGsSql &= "GOS..TIPO_DOCUMENTO TD, "
        lsGsSql &= "GOS..DOCUMENTOS_VALIDOS DV "
        lsGsSql &= "GOS..FUENTES FU "
        lsGsSql &= "INNER Join GOS..SUCURSAL S "
        lsGsSql &= "On FU.fuente = S.fuente "
        lsGsSql &= "Where "
        lsGsSql &= "DV.fuente = FU.fuente and "
        lsGsSql &= "DV.tipo_documento = TD.tipo_documento and "
        lsGsSql &= "TD.tipo_operacion in (0,1) and "
        lsGsSql &= "tipo_fuente = " & bTipoFuente
        lsGsSql &= " and activa_mantenimiento = 1"
        lsGsSql &= " and S.sucursal = '" & sSucursal & "' "
        lsGsSql &= " Order By "
        lsGsSql &= "descripcion_fuente"
        dtFuene = Consulta(lsGsSql, "DatosFuente")

        If dtFuene Is Nothing Then
            lsGsSql = "Select distinct "
            lsGsSql &= "FU.fuente, "
            lsGsSql &= "descripcion_fuente "
            lsGsSql &= "From "
            lsGsSql &= "GOS..FUENTES FU, "
            lsGsSql &= "GOS..TIPO_DOCUMENTO TD, "
            lsGsSql &= "GOS..DOCUMENTOS_VALIDOS DV "
            lsGsSql &= "Where "
            lsGsSql &= "DV.fuente = FU.fuente and "
            lsGsSql &= "DV.tipo_documento = TD.tipo_documento and "
            lsGsSql &= "TD.tipo_operacion in (0,1) and "
            lsGsSql &= "tipo_fuente = " & bTipoFuente
            lsGsSql &= " and activa_mantenimiento = 1"
            lsGsSql &= " and FU.fuente = case when tipo_fuente = 3 then  39 ELSE 66 END "
            lsGsSql &= " Order By "
            lsGsSql &= "descripcion_fuente"
            dtFuene = Consulta(lsGsSql, "DatosFuente")
        End If
        dtDatosFuente = dtFuene
        Return dtDatosFuente
    End Function

    Function DatostpOperacion(ByVal stpDoc As String) As DataTable
        Dim lsGsSql As String
        lsGsSql = "Select "
        lsGsSql &= "tipo_operacion "
        lsGsSql &= "From "
        lsGsSql &= "GOS..TIPO_DOCUMENTO "
        lsGsSql &= "Where "
        lsGsSql &= "tipo_documento = " & stpDoc

        Return Consulta(lsGsSql, "DatostpOperacion")
    End Function

    Function DatosTipoInstrumento(ByVal sTpDocto As String, ByVal stpFuente As String,
                                  ByVal sTpInstr As String) As DataTable
        Dim lsGsSql As String
        lsGsSql = "Select "
        lsGsSql &= "TI.tipo_instrumento, "
        lsGsSql &= "descripcion_instrumento "
        lsGsSql &= "From "
        lsGsSql &= "GOS..TIPO_INSTRUMENTO TI, "
        lsGsSql &= "GOS..INSTRUMENTOS_VALIDOS IV "
        lsGsSql &= "Where "
        lsGsSql &= "IV.tipo_instrumento = TI.tipo_instrumento and "
        If sTpInstr = "" Then
            lsGsSql &= "IV.tipo_documento = " & sTpDocto & " and "
            lsGsSql &= "IV.fuente = " & stpFuente & " and "
        Else
            lsGsSql &= "TI.tipo_instrumento = " & sTpInstr & " and "
        End If

        lsGsSql &= "activo_captura = 1 "
        lsGsSql &= "order by "
        lsGsSql &= "TI.tipo_instrumento"


        Return Consulta(lsGsSql, "DatosTipoInstrumento")
    End Function
    Function TipoAcceso(ByVal sTipoAcceso As String) As DataTable
        Dim lsGsSql As String
        lsGsSql = "SELECT T.descripcion, "
        lsGsSql &= "convert(char(5), hora_inicio, 108) as hora_ini, "
        lsGsSql &= "convert(char(5), hora_fin, 108) as hora_fin, "
        lsGsSql &= "convert(char(5), GETDATE(), 108) as hora_act "
        lsGsSql &= "FROM  GOS..TIPO_ACCESO T (NOLOCK) "
        lsGsSql &= "WHERE T.id_tipo_acceso = " & sTipoAcceso

        Return Consulta(lsGsSql, "TipoAcceso")
    End Function

    Function tipoSoporte(ByVal iSoporte As Integer, ByVal bSopVal As Boolean,
                         ByVal sFuente As String, ByVal sTipoDocto As String,
                         ByVal sTipoInstrumento As String) As DataTable
        Dim lsGsSql As String
        lsGsSql = "Select distinct "
        lsGsSql &= "SV.tipo_soporte, "
        lsGsSql &= "TS.descripcion_soporte "
        lsGsSql &= "From "
        lsGsSql &= "GOS..SOPORTES_VALIDOS SV, "
        lsGsSql &= "GOS..TIPO_SOPORTE TS "
        lsGsSql &= "Where "
        lsGsSql &= "TS.activo_captura = 1 and "
        lsGsSql &= "TS.tipo_soporte = SV.tipo_soporte"

        If iSoporte <> 3 Then
            'No se requieren todos los soportes
            lsGsSql &= " and SV.fuente = " & sFuente & " and "
            lsGsSql &= "SV.tipo_documento  = " & sTipoDocto & " and "

            If bSopVal = True Then           'Se buscan soportes validos
                lsGsSql &= "SV.tipo_instrumento = " & sTipoInstrumento & " and "
            End If

            If iSoporte = 0 Then      'Se buscan soportes obligatorios
                lsGsSql &= "SV.tipo_soporte = SV.soporte_agrupado and "
                lsGsSql &= "SV.opcional = 0"
            ElseIf iSoporte = 2 Then  'Se buscan soportes equivalentes
                lsGsSql &= "SV.tipo_soporte <> SV.soporte_agrupado and "
                lsGsSql &= "SV.opcional = 0"
            ElseIf iSoporte = 1 Then  'Se buscan soportes opcionales
                lsGsSql &= "SV.opcional = 1"
            End If
        End If
        lsGsSql &= " Order by descripcion_soporte"

        Return Consulta(lsGsSql, "tipoSoporte")
    End Function

    Function BuscaDocumentos(ByVal sDocIni As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "select"
        lsGsSql &= " distinct"
        lsGsSql &= " DOC.documento,"
        lsGsSql &= " convert(char(10),DOC.fecha_captura,105) fecha_captura,"
        lsGsSql &= " FU.fuente,"
        lsGsSql &= " FU.tipo_fuente"
        lsGsSql &= " From"
        lsGsSql &= " GOS..DOCUMENTO DOC,"
        lsGsSql &= " GOS..FUENTES FU,"
        lsGsSql &= " GOS..TIPO_DOCUMENTO TD,"
        lsGsSql &= " GOS..DOCUMENTOS_VALIDOS DV"
        lsGsSql &= " Where"
        lsGsSql &= " DV.fuente = FU.fuente and"
        lsGsSql &= " DV.tipo_documento = TD.tipo_documento and"
        lsGsSql &= " TD.tipo_operacion in (0,1) and"
        lsGsSql &= " DOC.fuente = DV.fuente and"
        lsGsSql &= " DOC.documento = " & sDocIni & " and"
        lsGsSql &= " DOC.agencia = 1 "

        Return Consulta(lsGsSql, "")

    End Function
    Function BuscaTpDocto(ByVal sNumDoc As String) As DataTable
        Dim lsGsSql As String
        lsGsSql = "Select tipo_documento from "
        lsGsSql &= " GOS..DOCUMENTO "
        lsGsSql &= " where documento = " & sNumDoc

        Return Consulta(lsGsSql, "BuscaTraspGOS")

    End Function
    Function RevisaDatosTicket(ByVal NumTab As Integer, txTicketMER As String,
                               ByVal txReferencia As String, ByVal txCuentaMER As String)
        Dim lsGsSql As String

        'lsGsSql = " " & DEFAULT_SRVRMERCURY & "." & DBTICKET & ".NuevoMIS.sp_a_busca_ticket "
        lsGsSql &= NumTab & ", "                     'Tipo de Operacion (0 Dep, 1 Ret)
        lsGsSql &= txTicketMER & ", "       'Ticket de Mercury
        lsGsSql &= txReferencia & ", '"     'Ficha CED
        lsGsSql &= txCuentaMER & "'"        'Cuenta Mercury

        Return Consulta(lsGsSql, "RevisaDatosTicket")

    End Function

    Function LlenaGridDocto(ByVal sDocIni As String, ByVal sFechaCaptura As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "select documento, cuenta_cliente, ticket, tipo_operacion, 
                   status_gos, fecha_captura , fecha_operacion,  soporte , descripcion_soporte
                   from ("
        lsGsSql &= "Select "
        lsGsSql &= "documento, "
        lsGsSql &= "cuenta_cliente, "
        lsGsSql &= "ticket, "
        lsGsSql &= "tipo_operacion, "
        lsGsSql &= "status_gos, "
        lsGsSql &= "Convert ( Char ( 10 ), fecha_captura, 105 ) fecha_captura, fecha_operacion, "
        lsGsSql &= "NULL soporte, NULL descripcion_soporte "
        lsGsSql &= "From "
        lsGsSql &= "GOS..DOCUMENTO DC, "
        lsGsSql &= "GOS..TIPO_DOCUMENTO TD "
        lsGsSql &= "Where "
        If sDocIni <> "" Then
            lsGsSql &= "DC.documento = " & sDocIni & " and "
        End If
        lsGsSql &= "TD.tipo_documento = DC.tipo_documento and "
        lsGsSql &= "TD.tipo_operacion in (0,1) and "
        lsGsSql &= "fecha_captura >= '" & DateAdd("d", 0, sFechaCaptura).ToString("MM-dd-yyyy") & " 00:01AM'  and "
        lsGsSql &= "fecha_captura < '" & DateAdd("d", 1, sFechaCaptura).ToString("MM-dd-yyyy") & " 00:01AM'   "
        'lsGsSql &= "fuente = " & sFuente
        'If Permiso("PCAPTESPECIAL") = False Then
        '    lsGsSql &= " and usuario = " & gn_Usuario
        'End If

        'Datos Soporte
        lsGsSql &= " UNION "
        lsGsSql &= "Select  DC.documento,  cuenta_cliente, null ticket, null tipo_operacion, null status_gos, "
        lsGsSql &= "null fecha_captura, null fecha_operacion, "
        lsGsSql &= "soporte,  descripcion_soporte From GOS..TIPO_DOCUMENTO TD ,GOS..DOCUMENTO DC "
        lsGsSql &= "inner join  "
        lsGsSql &= "( Select documento, soporte, descripcion_soporte "
        lsGsSql &= " From GOS..SOPORTE SO, GOS..TIPO_SOPORTE TS "
        lsGsSql &= "Where TS.tipo_soporte = SO.tipo_soporte  "
        If sDocIni <> "" Then
            lsGsSql &= "and documento = " & sDocIni
        End If
        lsGsSql &= ") TPS  "
        lsGsSql &= "on TPS.documento = DC.documento "
        lsGsSql &= "Where "
        If sDocIni <> "" Then
            lsGsSql &= "DC.documento = " & sDocIni & " and "
        End If
        lsGsSql &= "TD.tipo_documento = DC.tipo_documento and "
        lsGsSql &= "TD.tipo_operacion in (0,1) and "
        lsGsSql &= "fecha_captura >= '" & DateAdd("d", 0, sFechaCaptura).ToString("MM-dd-yyyy") & " 00:01AM'  and "
        lsGsSql &= "fecha_captura < '" & DateAdd("d", 1, sFechaCaptura).ToString("MM-dd-yyyy") & " 00:01AM'  "
        'lsGsSql &= "fuente = " & sFuente
        lsGsSql &= ") DOCTOSOPORTE "

        'Valida la fecha de captura
        If CDate(sFechaCaptura) = Date.Now Then
            lsGsSql &= " Order by descripcion_soporte ,documento"
        Else
            lsGsSql &= " Order by cuenta_cliente,documento,descripcion_soporte, fecha_operacion"
        End If

        Return Consulta(lsGsSql, "LlenaGridDocto")

    End Function

    Function LlenaTipoDocto(ByVal sFuente As String, ByVal sTpDocto As String, ByVal bTpOper As Byte) As DataTable
        Dim lsGsSql As String
        lsGsSql = "Select "
        lsGsSql &= "TD.tipo_documento, "
        lsGsSql &= "TD.descripcion_documento "
        lsGsSql &= "From "
        lsGsSql &= "GOS..TIPO_DOCUMENTO TD, "
        lsGsSql &= "GOS..DOCUMENTOS_VALIDOS DV "
        lsGsSql &= "Where "
        lsGsSql &= "TD.tipo_operacion in (0,1) and "
        If sTpDocto = "" Then
            lsGsSql &= "DV.tipo_documento = TD.tipo_documento and "
            lsGsSql &= "DV.fuente = " & sFuente
            lsGsSql &= " and TD.tipo_operacion = " & bTpOper
        Else
            lsGsSql &= "DV.tipo_documento = " & sTpDocto
            lsGsSql &= " and DV.tipo_documento = TD.tipo_documento and "
            lsGsSql &= "DV.fuente = " & sFuente
        End If
        lsGsSql &= " Order by DV.tipo_documento"

        Return Consulta(lsGsSql, "LlenaTipoDocto")

    End Function

    Function BuscaDatosDocto(ByVal sNumDoc As String)
        Dim lsGsSql As String

        lsGsSql = "Select cuenta_cliente, sufijo, agencia, "           '0 1 2
        lsGsSql &= "convert(char(10),fecha_recepcion,105), "           '3
        lsGsSql &= "convert(char(10),fecha_operacion,105), "           '4
        lsGsSql &= "numero_soportes, monto, "                          '5 6
        lsGsSql &= "ticket, referencia, "                              '7 8
        lsGsSql &= "convert(char(5),fecha_captura,8), "                '9
        lsGsSql &= "firma_cliente, "                                   '10
        lsGsSql &= "nombre_cliente, "                                  '11
        lsGsSql &= "persona_opera, "                                   '12
        lsGsSql &= "ISNULL(ticket_mercury,0), "                        '13
        lsGsSql &= "ISNULL(cuenta_mercury,0), "                        '14
        lsGsSql &= "ISNULL(sufijo_mercury,0), "                         '15
        lsGsSql &= "fuente "                                            '16
        lsGsSql &= "from GOS..DOCUMENTO "
        lsGsSql &= "where documento = " & sNumDoc

        Return Consulta(lsGsSql, "BuscaDatosDocto")

    End Function

    Function BuscaDatosDeposito(ByVal sNumDoc As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select "
        lsGsSql &= "divisa, "
        lsGsSql &= "original, "
        lsGsSql &= "total_comision_iva, "
        lsGsSql &= "nombre_plaza, "
        lsGsSql &= "nombre_sucursal, "
        lsGsSql &= "DC.plaza, "
        lsGsSql &= "right(DC.sucursal,4), "
        lsGsSql &= "linea_servicio, "
        lsGsSql &= "tipo_instrumento "
        lsGsSql &= "From "
        lsGsSql &= "GOS..DEPOSITO_CED DC, "
        lsGsSql &= "GOS..PLAZAS PZ, "
        lsGsSql &= "GOS..SUCURSAL SU  "
        lsGsSql &= "where "
        lsGsSql &= "documento = " & sNumDoc & " and "
        lsGsSql &= "PZ.plaza = DC.plaza and "
        lsGsSql &= "SU.sucursal = DC.sucursal"


        Return Consulta(lsGsSql, "BuscaDatosDeposito")
    End Function
    Function BuscaDatosRetiro(ByVal sNumDoc As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select "
        lsGsSql &= "numero_cheque, "
        lsGsSql &= "divisa, "
        lsGsSql &= "tipo_instrumento, "
        lsGsSql &= "original, "
        lsGsSql &= "nombre_plaza, "
        lsGsSql &= "nombre_sucursal, "
        lsGsSql &= "RC.plaza, "
        lsGsSql &= "right(RC.sucursal,4) "
        lsGsSql &= "From "
        lsGsSql &= "GOS..RETIRO_CED RC, "
        lsGsSql &= "GOS..PLAZAS PZ, "
        lsGsSql &= "GOS..SUCURSAL SU "
        lsGsSql &= "where "
        lsGsSql &= "documento = " & sNumDoc & " and "
        lsGsSql &= "PZ.plaza = RC.plaza and "
        lsGsSql &= "SU.sucursal = RC.sucursal"


        Return Consulta(lsGsSql, "BuscaDatosRetiro")
    End Function

    Function BuscaDatosSoporte(ByVal sSoporte As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select numero_soporte, detalle_soporte, descripcion_soporte, "
        lsGsSql &= "ISNULL(divisa,0), importe, convert(char(10),fecha_soporte,105), TS.tipo_soporte "
        lsGsSql &= "from "
        lsGsSql &= "GOS..SOPORTE SO, "
        lsGsSql &= "GOS..TIPO_SOPORTE TS "
        lsGsSql &= "where "
        lsGsSql &= "TS.tipo_soporte = SO.tipo_soporte and "
        lsGsSql &= "soporte = " & sSoporte

        Return Consulta(lsGsSql, "BuscaDatosSoporte")

    End Function
    Function BuscaTicketDocto(ByVal sTicket As String, ByVal sFechaOp As String) As DataTable
        Dim lsGsSql As String
        lsGsSql = "Select "
        lsGsSql &= "documento "
        lsGsSql &= "From "
        lsGsSql &= "GOS..DOCUMENTO "
        lsGsSql &= "Where fecha_operacion = '" & CDate(sFechaOp).ToString("MM-dd-yyyy") & "' "
        lsGsSql &= "and ticket = "
        lsGsSql &= Val(sTicket)

        Return Consulta(lsGsSql, "")
    End Function

    Function TicketDisponible(ByVal sTicket As String) As DataTable
        Dim lsGsSql As String
        lsGsSql = "Select "
        lsGsSql &= "operacion "
        lsGsSql &= "From "
        lsGsSql &= "GOS..T_OPERACION "
        lsGsSql &= "Where operacion = "
        lsGsSql &= sTicket

        Return Consulta(lsGsSql, "TicketDisponible")
    End Function

    Function InsertaDocumento(ByVal sTicketMer As String, ByVal sCuentaMer As String,
                              ByVal sSufijoMer As String, ByVal sCuenta As String,
                              ByVal sSufijo As String, ByVal sFechaRecepcion As String,
                              ByVal sFechaCaptura As String, ByVal sFechaOp As String,
                              ByVal sSoportes As String, ByVal sTipoDocto As String,
                              ByVal sFuente As String, ByVal sMonto As String,
                              ByVal sTicket As String, ByVal sReferencia As String,
                              ByVal bFirmaCliente As Boolean, ByVal lnTab As Byte,
                              ByVal sCliente As String, ByVal sPersona As String,
                              ByVal iTipoInstrumento As Integer, ByVal sPlaza As String,
                              ByVal sSucursal As String, ByVal iDivisa As Integer,
                              ByVal sFolioServicio As String, ByVal sOriginal As String,
                              ByVal sComiCHQ As String, ByVal sTpDivisa As Integer,
                              ByVal mnBbvab As Integer, ByRef sNumDoc As String,
                              ByVal sNumCheque As String, ByVal usuario_gos As Integer) As String

        Dim lsGsSql As String
        Dim d As New Datasource
        Dim dRegistro As DataTable
        Dim sRegistro As String
        Dim conec As SqlConnection = get_coneccion_sql()
        Dim command As SqlCommand = conec.CreateCommand
        Dim Transac As SqlTransaction
        Dim sDoc As String
        Const n_ticket_Nodisp As Integer = 0
        Dim iRegistro As Integer


        If valida_coneccion_sql() Then
            conec.Open()
            Transac = conec.BeginTransaction()
            command.Connection = conec
            command.Transaction = Transac
            Try
                lsGsSql = "Insert into GOS..DOCUMENTO (cuenta_cliente, sufijo, agencia, fecha_recepcion, "
                lsGsSql &= "fecha_captura, fecha_operacion, numero_soportes, "
                lsGsSql &= "tipo_documento, fuente, monto, ticket, referencia, "
                lsGsSql &= "status_concilia, status_gos, usuario, firma_cliente, verificado, "
                If Val(sTicketMer) <> 0 Or
                   Val(sCuentaMer) <> 0 Or
                   Val(sSufijoMer) <> 0 Then
                    lsGsSql &= "ticket_mercury, cuenta_mercury, sufijo_mercury, "
                End If
                lsGsSql &= "nombre_cliente, persona_opera,ticket_nodisp"
                lsGsSql &= ") values ("
                lsGsSql &= "'" & Trim(sCuenta) & "', "                      'cuenta_cliente
                lsGsSql &= "'" & Trim(sSufijo) & "', "                      'sufijo
                lsGsSql &= "1, "                                            'agencia
                lsGsSql &= "'" & Convert.ToDateTime(sFechaRecepcion).ToString("MM-dd-yyyy") & "', "                    'fecha_recepcion
                lsGsSql &= "'" & Convert.ToDateTime(sFechaCaptura).ToString("MM-dd-yyyy") & " " & Format(Now(), "HH:mm") & "', "  'fecha_captura
                lsGsSql &= "'" & Convert.ToDateTime(sFechaOp).ToString("MM-dd-yyyy") & "', "                           'fecha_operacion
                lsGsSql &= Val(sSoportes) & ", "                            'numero_soportes
                lsGsSql &= sTipoDocto & ", "                                'tipo_documento
                lsGsSql &= sFuente & ", "                                   'fuente
                lsGsSql &= sMonto & ", "                                    'monto
                lsGsSql &= sTicket & ", "                                   'ticket (agencias)
                lsGsSql &= sReferencia & ", "                               'referencia
                lsGsSql &= "1, "                                            'status_concilia
                lsGsSql &= "6, "                                            'status_gos (sin conciliacion)
                lsGsSql &= usuario_gos & ", "                                   'usuario
                If lnTab = 1 Then
                    'El documento es retiro
                    If bFirmaCliente = True Then
                        'Tiene firma del cliente
                        lsGsSql &= "1, "                                     'firma_cliente
                    Else
                        lsGsSql &= "0, "                                     'firma_cliente
                    End If
                Else
                    lsGsSql &= "0, "                                         'firma_cliente
                End If
                lsGsSql &= "0, "                                             'verificado

                If Val(sTicketMer) <> 0 Or
                   Val(sCuentaMer) <> 0 Or
                   Val(sSufijoMer) <> 0 Then
                    lsGsSql &= Val(sTicketMer) & ", '"
                    lsGsSql &= Val(sCuentaMer) & "', '"
                    lsGsSql &= Val(sSufijoMer) & "', "
                End If
                If lnTab = 0 Then
                    'El documento es deposito
                    lsGsSql &= "'" & sCliente & "', "
                    lsGsSql &= "'" & sPersona & "',"
                Else
                    'El documento es retiro
                    lsGsSql &= "'" & sCliente & "', "
                    lsGsSql &= "'" & sPersona & "',"
                End If
                lsGsSql &= n_ticket_Nodisp
                lsGsSql &= ")"
                lsGsSql &= " 
                Select @@Identity"
                'Inserta en DOCUMENTO                
                dRegistro = d.Consulta(lsGsSql, "InsertaDocumento")
                If dRegistro Is Nothing Then
                    sRegistro = "NOK"
                    Return sRegistro
                    Exit Function
                End If
                sDoc = CStr(Val(dRegistro.Rows(0).Item(0)))
                sNumDoc = sDoc
                Select Case lnTab
                    Case 0
                        'Deposito
                        lsGsSql = "Insert into GOS..DEPOSITO_CED (documento, "
                        lsGsSql &= "plaza, sucursal, divisa, linea_servicio, "
                        lsGsSql &= "tipo_instrumento, total_comision_iva, original) values ("
                        lsGsSql &= sDoc & ", "
                        lsGsSql &= "'" & sPlaza & "', "
                        If mnBbvab = 0 Then
                            lsGsSql &= "'" & sPlaza & sSucursal & "', "
                        Else
                            lsGsSql &= "'" & sSucursal & "', "
                        End If
                        If sTpDivisa = 1 Then
                            lsGsSql &= "1, "
                        ElseIf sTpDivisa = 2 Then
                            lsGsSql &= "2, "
                        Else
                            lsGsSql &= iDivisa & ", "
                        End If
                        lsGsSql &= Val(sFolioServicio) & ", "
                        lsGsSql &= iTipoInstrumento & ", "
                        lsGsSql &= sComiCHQ & ", "
                        lsGsSql &= Val(sOriginal) & ")"
                    Case 1
                        'Retiro
                        lsGsSql = "Insert into GOS..RETIRO_CED (documento, "
                        lsGsSql &= "plaza, sucursal, cheque, numero_cheque, divisa, "
                        lsGsSql &= "tipo_instrumento, original) values ("
                        lsGsSql &= sDoc & ", "
                        lsGsSql &= "'" & sPlaza & "', "
                        If mnBbvab = 0 Then
                            lsGsSql &= "'" & sPlaza & sSucursal & "', "
                        Else
                            lsGsSql &= "'" & sSucursal & "', "
                        End If
                        If sNumCheque <> "" Then
                            lsGsSql &= "1, "
                        Else
                            lsGsSql &= "0, "
                        End If
                        lsGsSql &= "'" & sNumCheque & "', "
                        If sTpDivisa = 1 Then
                            lsGsSql &= "1, "
                        ElseIf sTpDivisa = 2 Then
                            lsGsSql &= "2, "
                        Else
                            lsGsSql &= iDivisa & ", "
                        End If
                        lsGsSql &= iTipoInstrumento & ","
                        lsGsSql &= Val(sOriginal) & ")"
                End Select
                iRegistro = insertar(lsGsSql)
                If iRegistro = 0 Then
                    lsGsSql = "DELETE GOS..DOCUMENTO WHERE documento = " & sDoc
                    iRegistro = insertar(lsGsSql)
                    sRegistro = "NOK"
                    Return sRegistro
                    Exit Function
                End If
                Transac.Commit()
                sRegistro = "OK"
                Return sRegistro
            Catch ex As Exception
                sRegistro = "NOK"
                Transac.Rollback()
                Return sRegistro
            End Try
        End If
        Return sRegistro
    End Function
    Function InsertaSoporte(ByVal sNumDoc As String, ByVal sNumDocSoporte As String,
                            ByVal sDetalle As String, ByVal sTipoSoporte As String,
                            ByVal sDivisa As String, ByVal sImporteSoporte As String,
                            ByVal sFechaSoporte As String) As String

        Dim lsGsSql As String
        Dim d As New Datasource
        Dim dRegistro As DataTable
        Dim sRegistro As String
        Try

            lsGsSql = "Insert into GOS..SOPORTE (documento, numero_soporte, detalle_soporte, "
            lsGsSql &= "tipo_soporte, divisa, importe, fecha_soporte) values ("
            lsGsSql &= sNumDoc & ", "                                           'documento
            If sNumDocSoporte <> "" Then
                lsGsSql &= "'" & sNumDocSoporte & "',"                          'numero de soporte (documento)
            Else
                lsGsSql &= "null, "                                             'sin numero de documento
            End If
            lsGsSql &= "'" & sDetalle & "', "                                   'detalle_soporte
            lsGsSql &= sTipoSoporte & ", "                                      'tipo_soporte
            If sDivisa <> "" Then
                lsGsSql &= sDivisa & ", "                                       'divisa
            Else
                lsGsSql &= "null, "                                             'sin divisa
            End If
            If Trim(sImporteSoporte) <> "" Then
                lsGsSql &= sImporteSoporte & ", "                               'importe
            Else
                lsGsSql &= "0, "                                                'sin importe
            End If
            If Trim(sFechaSoporte) <> "" Then
                lsGsSql &= "'" & Convert.ToDateTime(sFechaSoporte).ToString("MM-dd-yyyy") & "')"           'fecha_soporte
            Else
                lsGsSql &= "null)"                                              'sin fecha_soporte
            End If

            lsGsSql &= "
                   Select @@Identity "

            dRegistro = d.Consulta(lsGsSql, "")
            If dRegistro Is Nothing Then
                sRegistro = "NOK"
                Return sRegistro
                Exit Function
            End If
            sRegistro = "OK"
            Return sRegistro
        Catch ex As Exception
            sRegistro = "NOK"
            Return sRegistro
        End Try
    End Function

    Function BuscaDatosTicket(ByRef lnTab As Byte, ByVal sticket As String) As DataTable
        Dim lsGsSql As String
        Dim dtDatosTicket As DataTable

        '0 DEPOSITO
        lsGsSql = "SELECT distinct(C.cuenta_cliente), T.sufijo_kapiti, "
        lsGsSql &= "O.fecha_operacion, O.monto_operacion, "
        lsGsSql &= "C.nombre_cliente, C.apellido_paterno, C.apellido_materno, "
        lsGsSql &= "D.nombre_sucursal , D.sucursal , O.status_operacion "
        lsGsSql &= "FROM TICKET..OPERACION O, "
        lsGsSql &= "TICKET..DEPOSITO_PME D, "
        lsGsSql &= "TICKET..PRODUCTO_CONTRATADO P, "
        lsGsSql &= "CATALOGOS..CLIENTE C, "
        lsGsSql &= "TICKET..CUENTA_EJE CE, "
        lsGsSql &= "TICKET..TIPO_CUENTA_EJE T "
        lsGsSql &= " WHERE O.operacion = " & sticket
        lsGsSql &= " AND D.operacion = O.operacion AND "
        lsGsSql &= "P.producto_contratado = O.producto_contratado AND "
        lsGsSql &= "P.cuenta_cliente = C.cuenta_cliente AND "
        lsGsSql &= "P.producto_contratado = CE.producto_contratado AND "
        lsGsSql &= "CE.tipo_cuenta_eje = T.tipo_cuenta_eje "

        dtDatosTicket = Consulta(lsGsSql, "BuscaDatosTicket")
        lnTab = 0

        If dtDatosTicket.Rows.Count = 0 Then
            '1 RETIRO
            lsGsSql = "SELECT distinct(C.cuenta_cliente), T.sufijo_kapiti, "
            lsGsSql &= "O.fecha_operacion, O.monto_operacion, "
            lsGsSql &= "C.nombre_cliente, C.apellido_paterno, C.apellido_materno, "
            lsGsSql &= "D.nombre_sucursal , D.sucursal , O.status_operacion "
            lsGsSql &= "FROM TICKET..OPERACION O, "
            lsGsSql &= "TICKET..RETIRO_PME D, "
            lsGsSql &= "TICKET..PRODUCTO_CONTRATADO P, "
            lsGsSql &= "CATALOGOS..CLIENTE C, "
            lsGsSql &= "TICKET..CUENTA_EJE CE, "
            lsGsSql &= "TICKET..TIPO_CUENTA_EJE T "
            lsGsSql &= " WHERE O.operacion = " & sticket
            lsGsSql &= " AND D.operacion = O.operacion AND "
            lsGsSql &= "P.producto_contratado = O.producto_contratado AND "
            lsGsSql &= "P.cuenta_cliente = C.cuenta_cliente AND "
            lsGsSql &= "P.producto_contratado = CE.producto_contratado AND "
            lsGsSql &= "CE.tipo_cuenta_eje = T.tipo_cuenta_eje "
            dtDatosTicket = Consulta(lsGsSql, "BuscaDatosTicket")
            lnTab = 1
        End If

        Return dtDatosTicket
    End Function

    Function ListaClientes(ByVal sCuenta As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select "
        lsGsSql &= "rtrim(ltrim(nombre_cliente))+' '+"
        lsGsSql &= "rtrim(ltrim(apellido_paterno))+' '+"
        lsGsSql &= "rtrim(ltrim(apellido_materno)) as nombrecliente "
        lsGsSql &= "From "
        lsGsSql &= "CATALOGOS..CLIENTE "
        lsGsSql &= "Where "
        lsGsSql &= "cuenta_cliente = '" & sCuenta & "' and "
        lsGsSql &= "agencia = 1 "

        lsGsSql &= " Union "
        lsGsSql &= "Select "
        lsGsSql &= "rtrim(ltrim(nombre_aut)) + ' ' +"
        lsGsSql &= "rtrim(ltrim(paterno_aut)) + ' '   +"
        lsGsSql &= "rtrim(ltrim(materno_aut)) + ' '   + '(Autorizado)'  as nombrecliente "
        lsGsSql &= "From "
        lsGsSql &= "CATALOGOS..AUTORIZADO "
        lsGsSql &= "Where "
        lsGsSql &= "cuenta_cliente = '" & sCuenta & "' and "
        lsGsSql &= "agencia = 1"

        'Se agrega la consulta de cotitulares
        lsGsSql &= " Union "
        lsGsSql &= "Select "
        lsGsSql &= "rtrim(ltrim(nombre_cot)) + ' '   +"
        lsGsSql &= "rtrim(ltrim(paterno_cot)) + ' '   +"
        lsGsSql &= "rtrim(ltrim(materno_cot)) + ' '   + '(Cotitular)'  as nombrecliente "
        lsGsSql &= "From "
        lsGsSql &= "CATALOGOS..COTITULAR "
        lsGsSql &= "Where "
        lsGsSql &= "cuenta_cliente = '" & sCuenta & "' and "
        lsGsSql &= "agencia = 1"

        Return Consulta(lsGsSql, "ListaClientes")

    End Function

    Function EliminaDocto(ByVal sNumID As String, ByVal sTipo As String) As String
        Dim lsGsSql As String
        Dim d As New Datasource
        Dim dRegistro As DataTable
        Dim sRegistro As String
        Dim conec As SqlConnection = get_coneccion_sql()
        Dim command As SqlCommand = conec.CreateCommand
        Dim Transac As SqlTransaction
        Dim dDelete As DataTable
        Dim iIndex As Integer
        Dim lsMantDoc As String
        lsMantDoc = ""
        If valida_coneccion_sql() Then
            conec.Open()
            Transac = conec.BeginTransaction()
            command.Connection = conec
            command.Transaction = Transac
            Try
                If sTipo = "D" Then
                    'Se puede desconciliar el documento
                    lsGsSql = " BEGIN TRY
                                BEGIN TRANSACTION;   
                                Delete GOS..SOPORTE where documento = " & sNumID
                    lsGsSql &= "
                                Delete GOS..DEPOSITO_CED where documento = " & sNumID
                    lsGsSql &= "
                                Delete GOS..RETIRO_CED where documento = " & sNumID
                    lsGsSql &= "
                                Delete GOS..TRANSFERENCIA where documento = " & sNumID
                    lsGsSql &= "
                                Delete GOS..TRASPASO where documento = " & sNumID
                    lsGsSql &= "
                                SELECT 1
                                COMMIT TRANSACTION;
                                END TRY
                                BEGIN CATCH
                                SELECT 0
                                ROLLBACK TRANSACTION
                                END CATCH;"

                    dDelete = Consulta(lsGsSql, "")
                    If dDelete.Rows(0).Item(0) = 0 Then
                        sRegistro = "NOK"
                        Return sRegistro
                        Exit Function
                    End If

                    lsGsSql = "Select mantenimiento "
                    lsGsSql &= " from GOS..MANT_DOCUMENTO "
                    lsGsSql &= " where documento = " & sNumID
                    'Busca mantenimientos para el documento
                    dRegistro = d.Consulta(lsGsSql, "EliminaDocto")

                    For iIndex = 0 To dRegistro.Rows.Count - 1
                        'El documento tiene mantenimientos
                        If Trim(lsMantDoc) <> "" Then
                            lsMantDoc = lsMantDoc & ", "
                        End If
                        lsMantDoc = lsMantDoc & dRegistro.Rows(iIndex).Item(0)
                    Next iIndex

                    If lsMantDoc <> "" Then
                        'Elimina los mantenimientos del documento
                        lsMantDoc = "(" & lsMantDoc & ")"
                        lsGsSql = " BEGIN TRY
                                    BEGIN TRANSACTION;
                                    Delete GOS..MANT_RETIRO where mantenimiento in " & lsMantDoc
                        lsGsSql &= "
                                    Delete GOS..MANT_DEPOSITO where mantenimiento in " & lsMantDoc
                        lsGsSql &= "
                                    Delete GOS..MANT_SOPORTE where documento = " & sNumID
                        'Elimina Mant. Soportes del documento
                        lsGsSql &= "
                                    delete GOS..MANT_DOCUMENTO where mantenimiento in " & lsMantDoc
                        lsGsSql &= "
                                SELECT 1
                                COMMIT TRANSACTION;
                                END TRY
                                BEGIN CATCH
                                SELECT 0
                                ROLLBACK TRANSACTION
                                END CATCH;"

                        dDelete = Consulta(lsGsSql, "")
                        If dDelete.Rows(0).Item(0) = 0 Then
                            sRegistro = "NOK"
                            Return sRegistro
                            Exit Function
                        End If
                    End If
                    'Elimina el documento
                    lsGsSql = "Delete GOS..DOCUMENTO where documento = " & sNumID
                    If insertar(lsGsSql) = 0 Then
                        sRegistro = "NOK"
                        Return sRegistro
                        Exit Function
                    End If
                Else
                    'Borra el soporte
                    lsGsSql = "Delete GOS..SOPORTE where soporte = " & sNumID

                    If insertar(lsGsSql) = 0 Then
                        sRegistro = "NOK"
                        Return sRegistro
                        Exit Function
                    End If
                End If
                sRegistro = "OK"
                Return sRegistro
            Catch ex As Exception
                sRegistro = "NOK"
                Transac.Rollback()
                Return sRegistro
            End Try
        End If
    End Function
    Function EliminaSoporte()

    End Function

    Function BuscaActa(ByVal sNumID As String, ByVal ActCancel As Byte) As DataTable
        Dim lsGsSql As String
        lsGsSql = "Select "
        lsGsSql &= "documento, acta "
        lsGsSql &= "From "
        lsGsSql &= "GOS..ACTA_ADM "
        lsGsSql &= "Where "
        If ActCancel = 0 Then
            'Acta Adm activa
            lsGsSql &= "cancelada = 0 and "
        Else
            'Acta Adm cancelada
            lsGsSql &= "cancelada = 1 and "
        End If
        lsGsSql &= "documento = " & sNumID

        Return Consulta(lsGsSql, "BuscaActa")
    End Function

    Function DesconciliaDocto(ByVal sActa As String, ByVal sNumID As String,
                              ByVal sTicket As String)
        Dim lsGsSql As String
        Dim d As New Datasource
        Dim dtDoctoConcil As DataTable
        Dim sRegistro As String
        Dim conec As SqlConnection = get_coneccion_sql()
        Dim command As SqlCommand = conec.CreateCommand
        Dim Transac As SqlTransaction
        Dim iRegistro As Integer

        If valida_coneccion_sql() Then
            conec.Open()
            Transac = conec.BeginTransaction()
            command.Connection = conec
            command.Transaction = Transac
            Try
                lsGsSql = "Delete GOS..ORIGEN_ERROR_ACTA_ADM where acta in " & sActa
                lsGsSql &= "
                                "
                lsGsSql &= "Delete GOS..TIPO_ERROR_ACTA_ADM where acta in " & sActa
                lsGsSql &= "
                                "
                lsGsSql &= "Delete GOS..ACTA_ADM where acta in " & sActa
                iRegistro = insertar(lsGsSql)
                If iRegistro = 0 Then
                    sRegistro = "NOK"
                    Return sRegistro
                    Exit Function
                End If
                lsGsSql = "exec GOS..sp_g_desconciliacion " & sNumID & ", 0"
                Consulta(lsGsSql, "DesconciliaDocto SP")
                lsGsSql = "Select "
                lsGsSql &= "documento, status_concilia "
                lsGsSql &= "From "
                lsGsSql &= "DOCUMENTO DC "
                lsGsSql &= "Where "
                lsGsSql &= "DC.documento = " & sNumID
                dtDoctoConcil = d.Consulta(lsGsSql, "DesconciliaDocto")
                If Val(dtDoctoConcil.Rows(0).Item(1)) = 4 Then
                    lsGsSql = " Delete DIFERENCIAS where documento = " & sNumID
                    lsGsSql &= " and operacion = " & sTicket
                    iRegistro = insertar(lsGsSql)
                    If iRegistro = 0 Then
                        sRegistro = "OK"
                        Return sRegistro
                        Exit Function
                    End If
                End If
                sRegistro = "OK"
                Return sRegistro
            Catch ex As Exception
                sRegistro = "NOK"
                Transac.Rollback()
                Return sRegistro
            End Try
        End If
        Return sRegistro
    End Function

    Function Concilia(ByVal sConcilDocto As String) As String
        Dim lsGsSql As String
        Dim sRegistro As String
        Dim iRegistro As String
        Try
            'DESCOMENTAR EN CASO DE REQUERIR NUEVAMENTE LA CONCILIACIÓN DE ACUERDO AL 
            'NUMERODE DE SOPORTES POR EL TIPO DE INSTRUMENTO SELECCIONADO
            'lsGsSql = "exec GOS..sp_g_concilia_soportes "
            'lsGsSql &= sConcilDocto
            'Consulta(lsGsSql, "Concilia SP")

            lsGsSql = "UPDATE GOS..DOCUMENTO "
            lsGsSql &= "SET status_gos = 5 "
            lsGsSql &= " WHERE  documento = " & sConcilDocto
            iRegistro = insertar(lsGsSql)

            If iRegistro <> 0 Then
                sRegistro = "OK"
            Else
                sRegistro = "NOK"
            End If

        Catch ex As Exception
            sRegistro = "NOK"
            Return sRegistro
        End Try
        Return sRegistro
    End Function

    Function EstatusConcilia(ByVal sDocto As String) As DataTable
        Dim lsGsSql As String
        lsGsSql = "Select status_gos "
        lsGsSql &= "From GOS..DOCUMENTO "
        lsGsSql &= "Where documento = " & sDocto

        Return Consulta(lsGsSql, "EstatusConcilia")
    End Function

    Function ListaSucursal(ByVal sNomSuc As String, ByVal bBbvab As Byte,
                           ByVal sPlaza As String, ByVal sRetSucursal As String,
                           ByVal bTpConsul As Byte) As DataTable
        Dim lsGsSql As String

        If bTpConsul = 0 Then
            lsGsSql = "Select right(sucursal,4) sucursal, nombre_sucursal "
            lsGsSql &= " From GOS..SUCURSAL "
            lsGsSql &= " Where nombre_sucursal like '%" & UCase(sNomSuc) & "%'"
            If bBbvab = 0 Then
                lsGsSql &= " and plaza = '" & sPlaza & "' "
            End If
            lsGsSql &= " And bbvab = " & bBbvab
            lsGsSql &= " Order by nombre_sucursal "

        ElseIf bTpConsul = 1 Then
            lsGsSql = "Select s.sucursal, s.nombre_sucursal "
            lsGsSql &= " From GOS..PLAZAS p, GOS..SUCURSAL s"
            If bBbvab = 0 Then
                lsGsSql &= " Where s.sucursal = '" & sPlaza & sRetSucursal & "'"
                lsGsSql &= " And s.plaza = '" & sPlaza & "' "
            Else
                lsGsSql &= " Where s.sucursal = '" & sRetSucursal & "'"
            End If
            lsGsSql &= " And p.plaza = s.plaza"
            lsGsSql &= " And bbvab = " & bBbvab
        Else
            lsGsSql = "Select count(*) from GOS..SUCURSAL Where plaza = '" & sPlaza & "'"
        End If

        Return Consulta(lsGsSql, "ListaSucursal")
    End Function

    Function ListaPlaza(ByVal sSucursal As String, ByVal bBbvab As Byte,
                        ByVal sPlaza As String) As DataTable
        Dim lsGsSql As String

        If sPlaza = "" Then
            lsGsSql = "Select p.plaza, p.nombre_plaza "
            lsGsSql &= " From GOS..PLAZAS p, GOS..SUCURSAL s"
            lsGsSql &= " Where s.sucursal = '" & sSucursal & "'"
            lsGsSql &= " And p.plaza = s.plaza"
            lsGsSql &= " And bbvab = " & bBbvab
        Else
            lsGsSql = "Select plaza, nombre_plaza "      'Llena el combo de Plaza
            lsGsSql &= " From PLAZAS "
            lsGsSql &= " Where nombre_plaza like '%" & sPlaza & "%'"
            lsGsSql &= " Order by nombre_plaza"
        End If

        Return Consulta(lsGsSql, "ListaPlaza")
    End Function

    Function NumSoportes(ByVal sfuente As String, sTpDocto As String,
                         ByVal sTpIsntrum As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select COUNT(*) "
        lsGsSql &= " From GOS..SOPORTES_VALIDOS sv, GOS..TIPO_SOPORTE ts "
        lsGsSql &= " Where sv.fuente = " & sfuente
        lsGsSql &= " And sv.tipo_documento = " & sTpDocto
        lsGsSql &= " And sv.tipo_instrumento = " & sTpIsntrum
        lsGsSql &= " And sv.soporte_agrupado = sv.tipo_soporte"
        lsGsSql &= " And opcional <> 1"
        lsGsSql &= " And ts.tipo_soporte = sv.tipo_soporte"
        lsGsSql &= " And ts.activo_captura =1"

        Return Consulta(lsGsSql, "NumSoportes")
    End Function

#Region "TRASPASOS"
    Function BuscaTraspGOS(ByVal sOperacion As String, ByVal sFechaOperacion As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select documento "
        lsGsSql &= " From "
        lsGsSql &= " DOCUMENTO "
        lsGsSql &= " Where "
        lsGsSql &= " fecha_operacion= '" & Convert.ToDateTime(sFechaOperacion).ToString("MM-dd-yyyy") & "' and"
        lsGsSql &= " ticket= " & sOperacion

        Return Consulta(lsGsSql, "BuscaTraspGOS")

    End Function
    Function BuscaDatosTraspasos(ByVal sOperacion As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select "
        lsGsSql &= "OP.monto_operacion, "
        lsGsSql &= "AG.prefijo_agencia, "
        lsGsSql &= "PC.cuenta_cliente, "
        lsGsSql &= "convert(char(10),OP.fecha_captura,105), "
        lsGsSql &= "convert(char(10),OP.fecha_operacion,105), "
        lsGsSql &= "TR.causa, "
        lsGsSql &= "OP.status_operacion, "
        lsGsSql &= "TCE.sufijo_kapiti, "
        lsGsSql &= "PC.agencia, "                'Datos de la cuenta origen
        lsGsSql &= "AGD.prefijo_agencia, "
        lsGsSql &= "PCD.cuenta_cliente, "
        lsGsSql &= "TCED.sufijo_kapiti, "
        lsGsSql &= "PCD.agencia ag_destino "     'Datos de la cuenta destino
        lsGsSql &= "From "
        lsGsSql &= "GOS..T_OPERACION OP, "
        lsGsSql &= "GOS..OPERACION_TICKET OT, "
        lsGsSql &= "GOS..T_TRASPASO TR, "
        lsGsSql &= "TICKET..PRODUCTO_CONTRATADO PC, "
        lsGsSql &= "CATALOGOS..AGENCIA AG, "
        lsGsSql &= "TICKET..CUENTA_EJE CE, "
        lsGsSql &= "CATALOGOS..TIPO_CUENTA_EJE TCE, "
        lsGsSql &= "TICKET..PRODUCTO_CONTRATADO PCD, "
        lsGsSql &= "CATALOGOS..AGENCIA AGD, "
        lsGsSql &= "TICKET..CUENTA_EJE CED, "
        lsGsSql &= "CATALOGOS..TIPO_CUENTA_EJE TCED "
        lsGsSql &= "Where "
        lsGsSql &= "OP.operacion = TR.operacion and "
        lsGsSql &= "OP.operacion = OT.operacion and "    'Se asegura que exista en ambas
        lsGsSql &= "OP.producto_contratado = PC.producto_contratado and "
        lsGsSql &= "PC.producto in (8009,3009,2009) and "
        lsGsSql &= "CE.producto_contratado = PC.producto_contratado and "
        lsGsSql &= "CE.tipo_cuenta_eje = TCE.tipo_cuenta_eje and "
        lsGsSql &= "PC.agencia = AG.agencia and "
        lsGsSql &= "PCD.producto in (8009,3009,2009) and "
        lsGsSql &= "OP.usuario_captura <> 285 and "      'Usuario Captura CASH en Ticket
        lsGsSql &= "CED.producto_contratado = PCD.producto_contratado and "
        lsGsSql &= "PCD.cuenta_cliente = TR.cuenta_destino and "
        lsGsSql &= "CED.tipo_cuenta_eje = TCED.tipo_cuenta_eje and "
        lsGsSql &= "PCD.agencia = AGD.agencia and "
        lsGsSql &= "PCD.agencia = agencia_destino and "  'Join con la agencia destino
        lsGsSql &= "OP.operacion = " & sOperacion '& " and "
        ' lsGsSql &= "AG.agencia = 1 "

        Return Consulta(lsGsSql, "BuscaDatosTraspasos")

    End Function

    Function InsertaDoctoTraspaso(ByVal sCtaOrigen As String, ByVal sSufijoOrigen As String,
                             ByVal sFechaCaptura As String, ByVal sFechaOperacion As String,
                             ByVal sMonto As String, ByVal sTicket As String,
                             ByVal sCtaDestino As String, ByVal sSufijoDestino As String,
                             ByRef sDocto As String, ByVal usuariogos As Integer) As String
        Dim lsGsSql As String
        Dim d As New Datasource
        Dim dRegistro As DataTable
        Dim conec As SqlConnection = get_coneccion_sql()
        Dim command As SqlCommand = conec.CreateCommand
        Dim Transac As SqlTransaction
        Dim sRegistro As String

        sDocto = ""
        sRegistro = ""
        If valida_coneccion_sql() Then
            conec.Open()
            Transac = conec.BeginTransaction()
            command.Connection = conec
            command.Transaction = Transac

            Try
                lsGsSql = "Insert into GOS..DOCUMENTO "
                lsGsSql &= "(cuenta_cliente, "
                lsGsSql &= "sufijo,agencia, "
                lsGsSql &= "fecha_recepcion, "
                lsGsSql &= "fecha_captura, "
                lsGsSql &= "fecha_operacion, "
                lsGsSql &= "numero_soportes, "
                lsGsSql &= "tipo_documento, "
                lsGsSql &= "fuente, "
                lsGsSql &= "monto, "
                lsGsSql &= "ticket, "
                lsGsSql &= "referencia, "
                lsGsSql &= "status_concilia, "
                lsGsSql &= "status_gos, "
                lsGsSql &= "usuario, "
                lsGsSql &= "operacion_concilia, "
                lsGsSql &= "fecha_concilia"
                lsGsSql &= ") values ("
                lsGsSql &= "'" & sCtaOrigen & "', "
                lsGsSql &= "'" & sSufijoOrigen & "', "
                lsGsSql &= "1, "
                lsGsSql &= "getdate () , "
                lsGsSql &= "'" & Convert.ToDateTime(sFechaCaptura).ToString("MM-dd-yyyy") & " " & Format(Now(), "HH:mm") & "', "
                lsGsSql &= "'" & Convert.ToDateTime(sFechaOperacion).ToString("MM-dd-yyyy") & "', "
                lsGsSql &= "0, 4, 20, "
                lsGsSql &= "CONVERT(VARCHAR, CAST('" & sMonto & "' As MONEY)) , "
                lsGsSql &= sTicket & ", "
                lsGsSql &= "0, 5, 5, "
                lsGsSql &= usuariogos & ", "
                lsGsSql &= sTicket & ", "
                lsGsSql &= "getdate()) "
                lsGsSql &= "     
                Select @@Identity" 'Recupera el no. de documento

                dRegistro = d.Consulta(lsGsSql, "InsertaDoctoTraspaso")

                If dRegistro.Rows.Count > 0 Then
                    sDocto = dRegistro.Rows(0).Item(0)
                Else
                    sRegistro = "NOK"
                    Transac.Rollback()
                    Return sRegistro
                    Exit Function
                End If

                lsGsSql = "Insert into TRASPASO ("
                lsGsSql &= "documento, cuenta_destino, sufijo_destino, agencia_destino"
                lsGsSql &= ") values ("
                lsGsSql &= sDocto & ", "
                lsGsSql &= "'" & sCtaDestino & "', "
                lsGsSql &= "'" & sSufijoDestino & "', "
                lsGsSql &= " 1)"

                ' Concilia la operación en ticket
                lsGsSql = "UPDATE OPERACION_TICKET "
                lsGsSql &= " SET status_concilia = 5 "
                lsGsSql &= " Where "
                lsGsSql &= " operacion = " & sTicket

                Transac.Commit()
                sRegistro = "OK"
                Return sRegistro
            Catch ex As Exception
                Try
                    sRegistro = "NOK"
                    Transac.Rollback()
                    Return sRegistro
                Catch ex2 As Exception
                    sRegistro = "NOK"
                    Return sRegistro
                End Try
            End Try
        End If
        Return sRegistro
    End Function

#End Region
#End Region

#Region "Control de Transacciones"
    '//----------------------------- RACB 20/01/2021
    Sub IniciaTransaccion()
        Try
            SQLTranConnection = New SqlConnection
            SQLTranCommand = New SqlCommand
            SQLTranConnection = get_coneccion_sql()
            SQLTranCommand = SQLTranConnection.CreateCommand
            If valida_coneccion_sql() Then
                SQLTranConnection.Open()
                SQLTranTransaction = SQLTranConnection.BeginTransaction()
                SQLTranCommand.Connection = SQLTranConnection
                SQLTranCommand.Transaction = SQLTranTransaction
            End If
        Catch ex As Exception
            SQLTranTransaction.Rollback()
            SQLTranTransaction.Dispose()
            SQLTranCommand.Dispose()
            SQLTranConnection.Dispose()
            SQLTranConnection.Close()
        End Try
    End Sub
    Function EjecutaComandoTransaccion(InstruccionSQL As String) As Boolean
        Try
            SQLTranCommand.CommandText = InstruccionSQL
            SQLTranCommand.CommandTimeout = 120
            If InstruccionSQL.Contains("Select") Then
                If InstruccionSQL.ToUpper.Contains("INSERT") = False Then
                    SQLTranCommand.CommandType = CommandType.Text
                    dTablaTransaccion = Consulta(InstruccionSQL, "EjecutaComandoTransaccion")
                    iValorTransaccion = dTablaTransaccion.Rows(0).Item(0) 'CType(SQLTranCommand.ExecuteScalar(), Integer)
                    Return True
                End If
            End If
                SQLTranCommand.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Sub CommitTransaccion()
        SQLTranTransaction.Commit()
        SQLTranTransaction.Dispose()
        SQLTranCommand.Dispose()
        SQLTranConnection.Dispose()
        SQLTranConnection.Close()
    End Sub
    Sub RollbackTransaccion()
        SQLTranTransaction.Rollback()
        SQLTranTransaction.Dispose()
        SQLTranCommand.Dispose()
        SQLTranConnection.Dispose()
        SQLTranConnection.Close()
    End Sub
    '//----------------------------- RACB 20/01/2021
#End Region

#Region "Mantenimiento Cuentas"

    Function EncuentraMannto(ByVal lnAgenProdContra As Long) As DataTable
        Dim lsGsSql As String
        lsGsSql = "SELECT count(*)"
        lsGsSql &= "FROM MANTENIMIENTO_CUENTA MC, TIPO_MANTENIMIENTO_CUENTA TMC "
        lsGsSql &= "Where MC.status_mantenimiento < 4 "
        lsGsSql &= "AND MC.Producto_contratado = " & lnAgenProdContra
        lsGsSql &= "AND MC.tipo_mantenimiento = TMC.tipo_mantenimiento "
        lsGsSql &= "AND MC.tipo_mantenimiento in (2,3) "

        Return Consulta(lsGsSql, "DatosGestoresCHQ")
    End Function

    Function DatosAgencia(ByVal iIndicador As Integer, sDato As String) As DataTable
        Dim lsGsSql As String
        lsGsSql = "SELECT "
        lsGsSql &= "ag.prefijo_agencia+'-'+"
        lsGsSql &= "cte.cuenta_cliente+' '"
        lsGsSql &= "+rtrim(nombre_cliente)+' '+"
        lsGsSql &= "rtrim(IsNull(apellido_paterno, Space(0)))+' '+"
        lsGsSql &= "rtrim(IsNull(apellido_materno, Space(0)))"
        lsGsSql &= "+' ('+ag.descripcion_agencia+')', "
        lsGsSql &= "ag.agencia "
        lsGsSql &= "from CATALOGOS..CLIENTE cte, "
        lsGsSql &= "CATALOGOS..AGENCIA ag "
        lsGsSql &= "where"
        lsGsSql &= " cte.agencia = ag.agencia"
        lsGsSql &= " and ag.agencia in (1,2,3) "
        If iIndicador = 1 Then         'Nombre
            lsGsSql &= " and UPPER(rtrim(nombre_cliente)+' '+"
            lsGsSql &= "rtrim(IsNull(apellido_paterno, Space(0)))+' '+"
            lsGsSql &= "rtrim(IsNull(apellido_materno, Space(0)))) "
            lsGsSql &= " like '%" & UCase(sDato) & "%'"
        ElseIf iIndicador = 2 Then     'Cuenta
            lsGsSql &= " and cuenta_cliente = '" & Trim(sDato) & "'"
        End If

        Return Consulta(lsGsSql, "DatosAgencia")
    End Function

    Function DatosCuenta(ByVal iAgencia As Integer, ByVal lsCuenta As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select nombre_cliente, "                                     '0
        lsGsSql &= "apellido_paterno, "                                         '1
        lsGsSql &= "apellido_materno, "                                         '2
        lsGsSql &= "telefono_cliente, "                                         '3
        lsGsSql &= "rfc, "                                                      '4  
        lsGsSql &= "fax_cliente, "                                              '5
        lsGsSql &= "func_pesos, "                                               '6
        lsGsSql &= "funcionario, "                                              '7
        lsGsSql &= "isnull(cuenta_mancomunada,0) as cuenta_mancomunada, "       '8
        lsGsSql &= "cuenta_eje_pesos, "                                         '9
        lsGsSql &= "isnull(fecha_cuenta_pesos,'') as fecha_cuenta_pesos, "      '10
        lsGsSql &= "isnull(persona_moral,0) as persona_moral, "                 '11
        lsGsSql &= "descripcion_tipo_cliente, "                                 '12
        lsGsSql &= "isnull(cuenta_houston,'') as cuenta_houston, "              '13
        lsGsSql &= "isnull(fecha_banklink,'') as fecha_banklink, "              '14
        lsGsSql &= "isnull(tiene_chequera,0) as tiene_chequera, "               '15
        lsGsSql &= "calle, "                                                    '16
        lsGsSql &= "no_ext, "                                                   '17
        lsGsSql &= "no_int, "                                                   '18
        lsGsSql &= "isnull(componente,'') as componente, "                      '19
        lsGsSql &= "colonia_cliente, "                                          '20
        lsGsSql &= "CL.ubicacion, "                                             '21
        lsGsSql &= "cp_cliente, "                                               '22
        'Pord Con de la cta 
        lsGsSql &= "PC.producto_contratado, "                                   '23
        lsGsSql &= "descripcion_tipo, "                                         '24
        lsGsSql &= "PC.status_producto, "                                       '25
        lsGsSql &= "isnull(fecha_vencimiento,'') as fecha_vencimiento, "        '26
        lsGsSql &= "CL.tipo_cliente, "                                          '27
        'Status de la Cuenta
        lsGsSql &= "SP.descripcion_status, "                                    '28
        'Status Global de Cta
        lsGsSql &= "SP.status_producto_global, "                                '29
        'formato dd-mm-aaaa
        lsGsSql &= "convert(char(10),fecha_cuenta_pesos,101) as fecha_cuenta_pesos, " '30
        '<<eliminar campo>> lvm
        lsGsSql &= "direccion_cliente "                                         '31
        'lsGsSql &= "CL.del_o_municipio "                                        '32
        lsGsSql &= "From "
        lsGsSql &= "PRODUCTO_CONTRATADO PC, "
        lsGsSql &= "PRODUCTO PR, "
        lsGsSql &= "STATUS_PRODUCTO SP, "
        lsGsSql &= "CUENTA_EJE CE, "
        lsGsSql &= "TIPO_CUENTA_EJE TCE, "
        lsGsSql &= "CATALOGOS..CLIENTE CL "
        lsGsSql &= "LEFT OUTER JOIN  CATALOGOS..TIPO_CLIENTE TC "
        lsGsSql &= "ON CL.tipo_cliente = TC.tipo_cliente "
        lsGsSql &= "Where "
        lsGsSql &= "PC.cuenta_cliente = CL.cuenta_cliente "
        lsGsSql &= "and PC.agencia = CL.agencia "
        lsGsSql &= "and PC.producto = PR.producto "
        lsGsSql &= "and PC.agencia = PR.agencia "
        lsGsSql &= "and PC.status_producto = SP.status_producto "
        'CUENTA EJE
        lsGsSql &= "and PR.producto_global = 9 "
        lsGsSql &= "and PC.producto_contratado = CE.producto_contratado "
        lsGsSql &= "and CE.tipo_cuenta_eje = TCE.tipo_cuenta_eje "
        lsGsSql &= "and CL.cuenta_cliente = '" & lsCuenta & "' "
        lsGsSql &= "and CL.agencia = " & iAgencia & " "

        Return Consulta(lsGsSql, "DatosCuenta")
    End Function

    Function StatusCuenta(ByVal lnProdContra As Long) As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select status_operacion "                             '0
        lsGsSql &= "From OPERACION "
        lsGsSql &= "Where producto_contratado = " & lnProdContra
        lsGsSql &= " and operacion_definida = 8100 "

        Return Consulta(lsGsSql, "StatusCuenta")
    End Function

    Function ObtieneUbicacion(ByVal lnUbicacion As Integer, ByVal lsCuenta As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select "
        lsGsSql &= " rtrim(U.descripcion_ubicacion)+', '+rtrim(U2.descripcion_ubicacion)"
        lsGsSql &= " From "
        lsGsSql &= "FUNCIONARIOS..UBICACION U, "
        lsGsSql &= "FUNCIONARIOS..UBICACION U2, "
        lsGsSql &= "CATALOGOS..CLIENTE C "
        lsGsSql &= " Where "
        lsGsSql &= " U.tipo_ubicacion = 4 "
        lsGsSql &= " and U.ubicacion_padre = U2.ubicacion "
        lsGsSql &= " and U.ubicacion = C.ubicacion "
        lsGsSql &= " and C.ubicacion is not null "
        'lsGsSql &= " and C.del_o_municipio is not null "
        lsGsSql &= " and C.ubicacion = " & lnUbicacion
        lsGsSql &= " and C.cuenta_cliente = '" & lsCuenta & "' "

        Return Consulta(lsGsSql, "ObtieneUbicacíon")
    End Function

    Function ObtieneUbicacionEnvio(ByVal lnUbicacion As Integer) As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select "
        lsGsSql &= "rtrim(U.descripcion_ubicacion)+', '+rtrim(U2.descripcion_ubicacion) "
        lsGsSql &= "From "
        'lsGsSql &= "FUNCIONARIOS..UBICACION U, "
        'lsGsSql &= "FUNCIONARIOS..UBICACION U2 "
        lsGsSql &= "CATALOGOS..UBICACION U, "
        lsGsSql &= "CATALOGOS..UBICACION U2 "
        lsGsSql &= "Where"
        lsGsSql &= " U.tipo_ubicacion = 4 "
        lsGsSql &= " and U.ubicacion_padre = U2.ubicacion"
        lsGsSql &= " and U.ubicacion is not null "
        lsGsSql &= " and U.ubicacion = " & lnUbicacion

        Return Consulta(lsGsSql, "ObtieneUbicacionEnvio")
    End Function

    Function ObtieneDelMun(ByVal lsCuenta As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "select"
        lsGsSql &= " del_o_municipio from catalogos..cliente"
        lsGsSql &= " where cuenta_cliente = '" & lsCuenta & "' "

        Return Consulta(lsGsSql, "ObtieneDelMun")
    End Function

    Function ObtieneDirEnvio(ByVal lsCuenta As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "select "
        lsGsSql &= "calle_envio, "                                      '0
        lsGsSql &= "no_ext_envio, "                                     '1
        lsGsSql &= "no_int_envio, "                                     '2
        lsGsSql &= "isnull(componente_envio,'') as componente_envio, "  '3
        lsGsSql &= "colonia_cliente, "                                  '4
        lsGsSql &= "ubicacion, "                                        '5
        lsGsSql &= "cp_cliente, "                                       '6
        lsGsSql &= "direccion_cliente, "                                '7
        lsGsSql &= "del_o_municipio_envio "                             '8
        lsGsSql &= "From "
        lsGsSql &= "CATALOGOS..DIRECCION_ENVIO "
        lsGsSql &= "Where"
        lsGsSql &= " cuenta_cliente = '" & lsCuenta & "'"
        lsGsSql &= " and agencia = 1 "

        Return Consulta(lsGsSql, "ObtieneDirEnvio")
    End Function

    Function ObtieneFunc(ByVal lnFuncionario As Integer) As DataTable
        Dim lsGsSql As String

        lsGsSql = "select "
        lsGsSql &= "rtrim(nombre_funcionario)+' '+"
        lsGsSql &= "rtrim(IsNull(apellido_paterno, Space(0)))+' '+"
        lsGsSql &= "rtrim(IsNull(apellido_materno, Space(0))), "
        lsGsSql &= "numero_funcionario "
        lsGsSql &= "from "
        lsGsSql &= "FUNCIONARIOS..FUNCIONARIO "
        lsGsSql &= "where funcionario = " & lnFuncionario

        Return Consulta(lsGsSql, "ObtieneFunc")
    End Function

    Function ObtieneRutaFunc(ByVal lsCuenta As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select UO.unidad_organizacional_padre, "
        lsGsSql &= "rtrim(IsNull(UO.descripcion_unidad_organizacio, Space(0)))+'('+IsNull(UO.unidad_org_bancomer, Space(0))+')' "
        lsGsSql &= "From "
        lsGsSql &= "FUNCIONARIOS..UNIDAD_ORGANIZACIONAL UO, "
        lsGsSql &= "FUNCIONARIOS..FUNCIONARIO FU, "
        lsGsSql &= "CATALOGOS..CLIENTE CL "
        lsGsSql &= "Where"
        lsGsSql &= " FU.unidad_organizacional = UO.unidad_organizacional"
        lsGsSql &= " and FU.funcionario = CL.funcionario"
        lsGsSql &= " and CL.cuenta_cliente = '" & lsCuenta & "'"
        lsGsSql &= " and CL.agencia = 1"

        Return Consulta(lsGsSql, "ObtieneRutaFunc")
    End Function

    Function ObtieneUnidadPadre(ByVal lnUnidadPadre As Integer) As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select unidad_organizacional_padre, "
        lsGsSql &= "rtrim(IsNull(descripcion_unidad_organizacio, Space(0)))+'('+"
        lsGsSql &= "IsNull(unidad_org_bancomer, Space(0))+')' "
        lsGsSql &= "from "
        lsGsSql &= "FUNCIONARIOS..UNIDAD_ORGANIZACIONAL "
        lsGsSql &= "where unidad_organizacional = " & lnUnidadPadre

        Return Consulta(lsGsSql, "ObtieneUnidadPadre")
    End Function

    Function ObtieneDatosAdic(ByVal lnProductoContratado As Long) As DataTable
        Dim lsGsSql As String

        lsGsSql = "select "
        lsGsSql &= "rtrim(nombre_usuario), "                 '0
        'Fecha Captura Tkt
        lsGsSql &= "isnull(fecha_captura,'') as fecha_captura, "                         '1
        'Hora Captura Tkt
        lsGsSql &= "convert(char(10),fecha_captura,108), "   '2
        'Fecha Aper. Equation
        lsGsSql &= "isnull(fecha_operacion,'') as fecha_operacion, "                       '3
        lsGsSql &= "linea, "                                 '4
        lsGsSql &= "grabadora "                              '5
        lsGsSql &= "from "
        lsGsSql &= "OPERACION_DEFINIDA od, "
        lsGsSql &= "OPERACION o "
        lsGsSql &= "LEFT OUTER JOIN CATALOGOS..USUARIO u "
        lsGsSql &= " On o.usuario_captura = u.usuario "
        lsGsSql &= "where "
        lsGsSql &= "o.operacion_definida = od.operacion_definida "
        'APERTURA DE CTA
        lsGsSql &= "and operacion_definida_global = 100 "
        lsGsSql &= "and o.producto_contratado = " & lnProductoContratado

        Return Consulta(lsGsSql, "ObtieneDatosAdic")
    End Function


    Function ExisteParticipes(ByVal lsCuenta As String, ByVal iTipoParticipacion As Integer) As DataTable
        Dim lsGsSql As String

        lsGsSql = "select "
        lsGsSql &= "count(*) "
        lsGsSql &= "from "
        If iTipoParticipacion = 1 Then
            lsGsSql &= "CATALOGOS..COTITULAR "
        ElseIf iTipoParticipacion = 2 Then
            lsGsSql &= "CATALOGOS..BENEFICIARIO "
        ElseIf iTipoParticipacion = 3 Then
            lsGsSql &= "CATALOGOS..AUTORIZADO "
        ElseIf iTipoParticipacion = 4 Then
            lsGsSql &= "CATALOGOS..APODERADO "
        End If
        lsGsSql &= "where "
        lsGsSql &= "cuenta_cliente = '" & lsCuenta & "' "
        lsGsSql &= "and agencia = 1"


        Return Consulta(lsGsSql, "ExisteParticipes")
    End Function

    Function EsFideicomiso(ByVal lsCuenta As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "select DISTINCT "
        lsGsSql &= " fideicomiso=count(cf.cuenta_cliente)"
        lsGsSql &= " From catalogos..cliente_fideicomiso cf "
        lsGsSql &= " join ticket..Producto_contratado pc on cf.cuenta_cliente=pc.cuenta_cliente "
        lsGsSql &= " join ticket..Operacion op on pc.producto_contratado=op.producto_contratado join ticket..operacion_definida od on op.operacion_definida=od.operacion_definida "
        lsGsSql &= " Where "
        lsGsSql &= " cf.estatus=0  "
        lsGsSql &= " AND (cf.tipo_operacion ='M') "
        lsGsSql &= " and Cf.cuenta_cliente = '" & lsCuenta & "' "
        lsGsSql &= " and Cf.agencia = 1 "

        Return Consulta(lsGsSql, "EsFideicomiso")
    End Function

    Function EsFideicomiso2(ByVal lsCuenta As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "select DISTINCT "
        lsGsSql &= " fideicomiso=count(cf.cuenta_cliente)"
        lsGsSql &= " From "
        lsGsSql &= "catalogos..cliente_fideicomiso cf with(nolock) "
        lsGsSql &= "join ticket..Producto_contratado pc with(nolock) on cf.cuenta_cliente=pc.cuenta_cliente "
        lsGsSql &= "join ticket..Operacion op with(nolock) on pc.producto_contratado=op.producto_contratado join ticket..operacion_definida od on op.operacion_definida=od.operacion_definida "
        lsGsSql &= " Where "
        lsGsSql &= " cf.estatus=1  "
        lsGsSql &= " AND (cf.tipo_operacion ='A' or cf.tipo_operacion ='M') "
        lsGsSql &= "and Cf.cuenta_cliente = '" & lsCuenta & "' "
        lsGsSql &= "and Cf.agencia = 1 "

        Return Consulta(lsGsSql, "EsFideicomiso2")
    End Function

    Function LlenaTipoCliente() As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select descripcion_tipo_cliente, "
        lsGsSql &= " tipo_cliente "
        lsGsSql &= " From "
        lsGsSql &= "CATALOGOS..TIPO_CLIENTE "

        Return Consulta(lsGsSql, "LlenaTipoCliente")
    End Function

    Function ObtieneStatusProdCont(ByVal lnProdCon As Long) As DataTable
        Dim lsGsSql As String

        lsGsSql = "SELECT status_operacion "
        lsGsSql &= " FROM OPERACION "
        lsGsSql &= " WHERE producto_contratado=" & lnProdCon
        lsGsSql &= " AND operacion_definida=8100 "

        Return Consulta(lsGsSql, "ObtieneStatusProdCont")
    End Function

    Function ObtieneShortName_Mnemonico(ByVal lsCuenta As String) As DataTable
        Dim lsGsSql As String

        lsGsSql = "Select shortname, mnemonico  "
        lsGsSql &= "from CATALOGOS.dbo.CLIENTE "
        lsGsSql &= " where cuenta_cliente = '" & Trim(lsCuenta) & "'"
        lsGsSql &= " and agencia = 1"

        Return Consulta(lsGsSql, "ObtieneShortName_Mnemonico")
    End Function

    'Select count(*) from " & DBCATALOGOS & ".dbo.DIAS_FERIADOS where fecha = '" & InvierteFecha(ls_Cadena) & "'"
    Function VerificaDiasFeriados(ByVal lsCadena As String) As DataTable
        Dim lsGsSql As String
        Dim lsf_cuenta As String
        'Dim d As Datasource
        lsf_cuenta = InvierteFecha_yyymmdd(lsCadena)
        lsGsSql = "Select count(*) from CATALOGOS.dbo.DIAS_FERIADOS where fecha = '" & lsf_cuenta & "'"


        Return Consulta(lsGsSql, "VerificaDiasFeriados")
    End Function

    Function ConsultaUbicacion(ByVal lnUbicacion As Integer) As DataTable
        Dim gs_Sql As String

        gs_Sql = " select EDO.descripcion_ubicacion "
        gs_Sql &= " from FUNCIONARIOS.dbo.UBICACION CIU, "
        gs_Sql &= " FUNCIONARIOS.dbo.UBICACION EDO "
        gs_Sql &= " where "
        gs_Sql &= " CIU.ubicacion= " & lnUbicacion & " "
        gs_Sql &= " and CIU.ubicacion_padre=EDO.ubicacion "

        Return Consulta(gs_Sql, "ConsultaUbicacion")
    End Function

    '--------------------------------------------------------------------------------------
    'Invierte la entre los formatos dd-mm-yy y mm-dd-yy si el parametro es una fecha valida
    '--------------------------------------------------------------------------------------
    Public Function InvierteFecha(ByVal Fecha As String) As String

        Dim ls_Cadena As String

        InvierteFecha = Trim(Fecha)
        ls_Cadena = Trim(Fecha)
        'Si no es una fecha valida, termina
        If Not IsDate(Fecha) Then Exit Function
        'Si le falta un caracter al dia
        If Mid(ls_Cadena, 2, 1) = "-" Or Mid(ls_Cadena, 2, 1) = "/" Then
            ls_Cadena = "0" & ls_Cadena
        End If
        'Si le falta un caracter al mes
        If Mid(ls_Cadena, 5, 1) = "-" Or Mid(ls_Cadena, 5, 1) = "/" Then
            ls_Cadena = Left(ls_Cadena, 3) & "0" & Mid(ls_Cadena, 4, 4)
        End If
        InvierteFecha = Mid(ls_Cadena, 4, 3) & Left(ls_Cadena, 3) & DatePart("yyyy", InvierteFecha)
    End Function

    'Fecha llega como dd/MM/yyyy
    'Se pasa a yyyy-MM-dd, para las consultas en SQL.
    Public Function InvierteFecha_yyymmdd(ByVal Fecha As String) As String
        Dim ls_dia As String
        Dim ls_mes As String
        Dim ls_anio As String
        Dim ls_Cadena As String

        InvierteFecha_yyymmdd = Trim(Fecha)
        ls_Cadena = Trim(Fecha)
        'Si no es una fecha valida, termina
        If Not IsDate(Fecha) Then Exit Function
        'Si le falta un caracter al dia
        If Mid(ls_Cadena, 2, 1) = "-" Or Mid(ls_Cadena, 2, 1) = "/" Then
            ls_Cadena = "0" & ls_Cadena
        End If
        'Si le falta un caracter al mes
        If Mid(ls_Cadena, 5, 1) = "-" Or Mid(ls_Cadena, 5, 1) = "/" Then
            ls_Cadena = Left(ls_Cadena, 3) & "0" & Mid(ls_Cadena, 4, 4)
        End If
        ls_dia = Mid(ls_Cadena, 1, 2)
        ls_mes = Mid(ls_Cadena, 4, 2)
        ls_anio = DatePart("yyyy", InvierteFecha_yyymmdd)

        InvierteFecha_yyymmdd = ls_anio & "-" & ls_mes & "-" & ls_dia
        'InvierteFecha_yyymmdd = Mid(ls_Cadena, 4, 3) & Left(ls_Cadena, 3) & DatePart("yyyy", InvierteFecha_yyymmdd)
    End Function


#End Region

#Region "ACTUALIZA_MANTENIMIENTO_CUENTAS"
    'inicia "ACTUALIZA MANTENIMIENTO CUENTAS"


    Function UpdCliente(ByVal sQuery As String) As Integer

        Dim Query As String
        Dim Registro As Integer

        Query = sQuery
        Registro = insertar(Query)

        Return Registro

    End Function

    Function InsQuery(ByVal sQuery As String) As Integer

        Dim Query As String
        Dim Registro As Integer

        Query = sQuery
        Registro = insertar(Query)

        Return Registro

    End Function

    Function ConsultaQuery(ByVal sQuery As String) As Integer
        Dim lsGsSql As String
        Dim dtDatatable As DataTable
        Dim Registro As Integer

        lsGsSql = sQuery

        dtDatatable = Consulta(lsGsSql, "ConsultaQuery")

        If dtDatatable.Rows.Count > 0 Then
            Registro = dtDatatable.Rows(0).Item(0)
        Else
            Registro = 0
        End If
        Return Registro
    End Function

    Function InsertaEventoProducto(ByVal lnProdCon As Long, ByVal lsFecha As String, ByVal lsHora As String, ByVal lnStatusCta As Integer, ByVal lnUsuario As Integer) As Integer
        Dim gs_Sql As String
        Dim Registro As Integer

        gs_Sql = "Insert into "
        gs_Sql &= " EVENTO_PRODUCTO "
        gs_Sql &= " (producto_contratado, fecha_evento, status_producto, "
        gs_Sql &= " comentario_evento, usuario) "
        gs_Sql &= " values "
        gs_Sql &= " ( " & lnProdCon & ", '" & lsFecha & " " & lsHora & "', "
        gs_Sql &= lnStatusCta & ", 'Mantenimiento a Cuenta', " & lnUsuario & ") "

        Registro = insertar(gs_Sql)

        Return Registro

    End Function


    Function ValorParametroStr(ByVal sParametro As String) As String
        Dim s As String
        Dim dtDatatable As DataTable
        Dim ValorParam As String

        s = " SELECT valor FROM TICKET..PARAMETRIZACION WHERE codigo = '" & sParametro & "'"

        dtDatatable = Consulta(s, "ValorParametroStr")
        If dtDatatable.Rows.Count > 0 Then
            ValorParam = dtDatatable.Rows(0).Item(0)
        Else
            ValorParam = 0
        End If
        Return ValorParam
    End Function

#End Region
    'finaliza "ACTUALIZA MANTENIMIENTO CUENTAS"

End Class

