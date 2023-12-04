Imports System.Data.SqlClient

Public Class frmConsultaSaldosMov

    Dim agencias As List(Of AGENCIA)
    Dim productos As List(Of PRODUCTO_CONTRATADO)
    Dim la_TitulosProducto As List(Of String)
    Dim la_TitulosConcepto As List(Of String)
    Dim la_TitulosOperaciones As List(Of String)
    Dim cliente As CLIENTE
    Dim funcionario As FUNCIONARIO
    Dim unidad_organizacional As UNIDAD_ORGANIZACIONAL
    Dim lista_operaciones1, lista_operaciones2 As List(Of GridOperacion)


    Dim cuenta As String
    Dim producto_contratado As Integer

    Dim numero_uo As Integer
    Dim siManc As Integer
    Dim gnTipoCuenta As Integer
    Dim gAgencia As Integer

    Dim click_cmbAgencias As Boolean = False
    Dim bTDDAdicional As Boolean = False
    Dim bTDDNueva As Boolean = False
    Private bActivafrmCliente As Boolean = False

    Dim bdFuncionarios As FUNCIONARIOSEntities = New FUNCIONARIOSEntities()
    Dim bdTicket As TICKETEntities = New TICKETEntities()
    Dim bdCatalogos As CATALOGOSEntities = New CATALOGOSEntities()


    Dim ls_Causa As String
    Dim cta_H As String
    Dim ls_Causa2 As String
    Dim ls_Mensaje As String = ""
    Dim ls_Mensaje2 As String
    Dim lb_Sobregiro As Boolean
    Dim lb_Bloqueado As Boolean
    Dim lb_Alerta As Boolean
    Dim lb_Cancelada As Boolean
    Dim lb_Tipo3 As Boolean
    Dim lb_TipoServ As Boolean
    Dim ln_Plaza As Integer
    Dim lb_TipoFic As Boolean
    Dim ln_Padre As Long
    Dim ln_CtaEje As Integer
    Dim ls_CtaCliente As String
    Dim lb_Suc As Boolean
    Dim ls_FechaInicioDep As String
    Dim sEtiqueta As String
    Dim sEtiquetaV As Integer
    Dim GnProdContCd As Integer
    Dim tablaTemporal As String


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs)

    End Sub

    ''' <summary>
    ''' Busca el movimiento de apertura
    ''' </summary>
    ''' <param name="cuenta"></param>
    ''' <param name="operacion_glbl"></param>
    Private Sub buscaApertura(cuenta As String, operacion_glbl As Integer)

        Dim query As String = $"
            select 
	           fecha_operacion
            from 
	            OPERACION O inner join OPERACION_DEFINIDA od on o.operacion_definida = od.operacion_definida 
            Where 
	            producto_contratado in ( 
		            select  
			            producto_contratado 
		            From  
			            PRODUCTO_CONTRATADO 
		            Where 
			            producto = (
				            select 
					            producto 
				            From 
					            OPERACION_DEFINIDA 
				            Where 
					            operacion_definida_global = @operacion_global
 					            and  
 					            agencia = 1
				            ) 
			            and cuenta_cliente = @cuenta
		            )
		            and OD.operacion_definida_global=100
	    "

        Using contexto As New TICKETEntities
            Dim fecha_apertura As DateTime = contexto.Database.SqlQuery(Of DateTime)(query, New SqlParameter("@cuenta", cuenta), New SqlParameter("@operacion_global", operacion_glbl)).FirstOrDefault()
            lblFechaApertura.Text = fecha_apertura.ToString("dd-MM-yyyy")

        End Using
    End Sub

    ''' <summary>
    ''' Busca el movimiento de cancelación.
    ''' </summary>
    ''' <param name="ctaCliente"></param>
    ''' <param name="sp"></param>
    ''' <param name="p"></param>
    Private Sub buscaCancelacion(ctaCliente As String, sp As Short, p As Short)
        Dim producto As PRODUCTO_CONTRATADO = bdTicket.PRODUCTO_CONTRATADO.Where(Function(w) w.status_producto = sp And w.producto = p And w.cuenta_cliente = ctaCliente).FirstOrDefault()
        If producto IsNot Nothing Then
            lblFechaCancelacion.Visible = True
            lblECancelacion.Visible = True
            lblFechaCancelacion.Text = producto.fecha_vencimiento
        Else
            lblFechaCancelacion.Visible = False
            lblECancelacion.Visible = False
            lblFechaCancelacion.Text = String.Empty
        End If
    End Sub

    ''' <summary>
    ''' Carga en un arreglo el movimiento de apertura. 
    ''' </summary>
    Private Sub cargaApertura()
        Dim strQuery As String = "
        Select 
            top 10
	        operacion, 
	        status_nombre = CASE 
		        WHEN status_operacion = 0 THEN 'SIN VALIDAR' 
		        WHEN status_operacion = 1 THEN 'SIN VALIDAR' 
		        WHEN status_operacion = 2 THEN 'VALIDADO' 
		        WHEN status_operacion = 3 THEN 'VALIDADO' 
		        WHEN status_operacion = 4 THEN 'VALIDADO EQ' 
		        WHEN status_operacion = 5 THEN 'RECHAZADO EQ' 
		        WHEN status_operacion = 220 THEN 'SIN VALIDAR' 
		        WHEN status_operacion = 250 THEN 'CANCELADO' 
		        WHEN status_operacion = 6 THEN 'COMPLEMENTADO' 
		        WHEN status_operacion = 12 THEN 'RECHAZADO' 
		        WHEN status_operacion = 16 THEN 'RECHAZADO' 
	        END,
	        descripcion_operacion_definida,
	        fecha_captura,
	        fecha_operacion,
	        monto_operacion
        from 
	        TICKET.dbo.OPERACION O 
            INNER JOIN TICKET.dbo.OPERACION_DEFINIDA OD on O.operacion_definida = OD.operacion_definida 
	        where 
                producto_contratado = ( 
		            select  producto_contratado 
		            From  PRODUCTO_CONTRATADO 
		            Where producto = (
			            select producto 
			            From OPERACION_DEFINIDA 
			            Where 
                            operacion_definida_global = 100 
				            and  agencia = 1
			            ) 
			            and cuenta_cliente= @cuenta_cliente 
		            )
		            and OD.operacion_definida_global=100"


        Using contexto As New TICKETEntities
            lista_operaciones2 = contexto.Database.SqlQuery(Of GridOperacion)(strQuery, New SqlParameter("@cuenta_cliente", cuenta)).ToList()
        End Using
    End Sub

    ''' <summary>
    ''' Limpia campos llenados 
    ''' </summary>
    Private Sub LimpiaCampos()
        txtCuenta.Text = String.Empty
        cmbAgencia.DataSource = Nothing
        cmbAgencia.Refresh()
        lblCliente.Text = String.Empty
        lblCotitular.Text = String.Empty
        lblNumFuncionario.Text = String.Empty
        lblFuncionario.Text = String.Empty
        lblRuta.Text = String.Empty
        lblTipoCuenta.Text = String.Empty
        lblBanca.Text = String.Empty
        lblFechaApertura.Text = String.Empty
        lblFechaCancelacion.Text = String.Empty
        lblCuentaHouston.Text = String.Empty
        lblUGestora.Text = String.Empty
        lblTelefono.Text = String.Empty
        lblFax.Text = String.Empty
        gridProductos.DataSource = Nothing
        gridProductos.Refresh()
        gridOperaciones.DataSource = Nothing
        gridOperaciones.Refresh()
        lblDescripcionConcepto.Text = String.Empty
        lblValorConcepto.Text = String.Empty
        lblSaldo.Text = String.Empty

        productos = Nothing
        la_TitulosProducto = Nothing
        la_TitulosConcepto = Nothing
        la_TitulosOperaciones = Nothing
        cliente = Nothing
        funcionario = Nothing
        unidad_organizacional = Nothing
        lista_operaciones1 = Nothing
        lista_operaciones2 = Nothing

        btnBuscar.Enabled = True
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="producto"></param>
    Private Sub MotivoCtaCancelada(producto As PRODUCTO_CONTRATADO)
        'Busca el registro mas reciente de cancelación para la cuenta
        Dim maximo As Integer = MaxCancelaReactivaCuentaByProduc(producto.producto_contratado1)

        If maximo > 0 Then
            'Busca el motivo para la cancelación de la cuenta
            Dim motivo As CANCELA_REACTIVA_CUENTAS = CancelaReactivaCuentaByProduc(producto.producto_contratado1)
            If motivo IsNot Nothing Then
                'Si el motivo no es vacio
                If motivo.motivo <> "" Then
                    MessageBox.Show("La cuenta está ¡Cancelada! debido a " + motivo.motivo, "Cuenta Cancelada")
                Else
                    MessageBox.Show("La cuenta está ¡Cancelada! y no tiene motivo de Cancelación. ", "Cuenta Cancelada")
                End If
            End If
        Else
            MessageBox.Show("La cuenta está ¡Cancelada! y no tiene motivo de Cancelación. ", "Cuenta Cancelada")
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub LlenaCampos()
        Try
            'Todos los menus en true si esta bloque ada o es día feriado se deshabilitan
            btnSaldoDisp.Enabled = True

            lb_TipoFic = False
            lb_TipoServ = False
            lb_Tipo3 = False
            lb_Bloqueado = True
            lb_Alerta = True
            lb_Cancelada = False
            ln_Plaza = 0
            ls_Causa = ""


            cliente = ClienteByCuenta()
            funcionario = FuncionarioByFunc(cliente)
            'cotitular = CotitularByCliente()

            LlenarDatosFuncionario()
            LlenarDatosClientes()
            'LlenarDatosCotitular()

            unidad_organizacional = UnidadesOrganizacionesByUnidad(numero_uo)

            'Se va llenando el path de unidad organizacional del funcionario
            If unidad_organizacional IsNot Nothing Then
                If unidad_organizacional.tipo_unidad_organizacional = 3 Then
                    lb_Tipo3 = True
                End If
                ln_Padre = unidad_organizacional.unidad_organizacional_padre
                lblRuta.Text = $"\ {unidad_organizacional.unidad_org_bancomer.Trim()} {unidad_organizacional.descripcion_unidad_organizacio.Trim()}"
            End If

            If ln_Padre > 0 Then

                Do While ln_Padre > 0
                    Dim unidad_organizacional As UNIDAD_ORGANIZACIONAL
                    unidad_organizacional = UnidadesOrganizacionesByUnidad(ln_Padre)

                    ln_Padre = unidad_organizacional.unidad_organizacional_padre
                    ' ******SE BUSCA EL NIVEL CORRESPONDIENTE A LA BANCA ******
                    sEtiqueta = unidad_organizacional.descripcion_unidad_organizacio
                    If unidad_organizacional.tipo_unidad_organizacional = 2 And InStr(sEtiqueta, "BANCA") > 0 Then
                        lblBanca.Text = unidad_organizacional.descripcion_unidad_organizacio
                        sEtiquetaV = unidad_organizacional.descripcion_unidad_organizacio.Contains("BANCA")
                    ElseIf unidad_organizacional.tipo_unidad_organizacional = 1 And InStr(sEtiqueta, "BANCA") > 0 And sEtiquetaV = 0 Then
                        lblBanca.Text = unidad_organizacional.descripcion_unidad_organizacio
                    End If

                    lblRuta.Text += $" \ {unidad_organizacional.unidad_org_bancomer.Trim()} {unidad_organizacional.descripcion_unidad_organizacio.Trim()}"

                    'unidad organizacional banca de servicios
                    If unidad_organizacional.unidad_organizacional1 = 5 Then
                        lb_TipoServ = True
                        'unidad organizacional banca de servicios ficomer
                    ElseIf unidad_organizacional.unidad_organizacional1 = 1410 Then
                        lb_TipoServ = True
                    End If
                Loop
            Else
                Dim sMsg As String
                sMsg = "El funcionario no está asignado a ningun tipo de BANCA. Pedir BANCA, DIVISION, CENTRO REGIONAL y SUCURSAL
                 del funcionario para asignarlo correctamente. Si es necesario, pedir también el nombre del FUNCIONARIO de la cuenta.
                Esta información pasarla al área de Sistemas para hacer los cambios correspondientes."
                MessageBox.Show(sMsg)
            End If


            If lb_Tipo3 And lb_TipoServ Then
                Dim sMsg As String
                sMsg = "El funcionario no está asignado a una SUCURSAL. Pedir BANCA, DIVISION, CENTRO REGIONAL, PLAZA y SUCURSAL
                 del funcionario para asignarlo correctamente. Si es necesario, pedir también el nombre del FUNCIONARIO de la cuenta.
                Esta información pasarla al área de Sistemas para hacer los cambios correspondientes."
                MessageBox.Show(sMsg)
            End If
            If lb_Tipo3 And lb_TipoFic Then
                Dim sMsg As String
                sMsg = "El funcionario está asignado a BANCA DE SERVICIOS FICOMER. Pedir BANCA, DIVISION, CENTRO REGIONAL, PLAZA y SUCURSAL
                del FUNCIONARIO para asignarlo correctamente. Si es necesario, pedir también el nombre del FUNCIONARIO de la cuenta.
                Esta información pasarla al área de Sistemas para hacer los cambios correspondientes."
                MessageBox.Show(sMsg)
            End If

            Dim pc As PRODUCTO_CONTRATADO = ProductoContratadoByCuentaAndGlobal(cuenta, 9)

            If productos IsNot Nothing Then
                If pc.status_producto = 4 Or pc.producto_contratado1 = 0 Then
                ElseIf pc.status_producto = 39 Then
                    lb_Bloqueado = False
                    lb_Alerta = False
                    lb_Cancelada = True
                Else
                    lb_Bloqueado = False
                End If
            Else
                'MessageBox.Show("Este cliente no tiene cuenta eje.")
                lb_Bloqueado = False
            End If

            If lb_Cancelada Then
                MotivoCtaCancelada(pc)
            End If

            Dim operacion As OPERACION = OperacionByProduc(pc)

            'Obtiene el numero de usuario que apertutó la cuenta
            If operacion IsNot Nothing Then
                If operacion.usuario_captura = 91 Then
                    lb_Suc = True
                End If
            End If

            Dim apertura_sucursal As APERTURA_SUCURSAL_MANUAL = AperturaSucursalManualByProduct(pc)

            'Revisa si la apertura fue manual
            If apertura_sucursal IsNot Nothing Then
                lb_Suc = True
            End If

            'Se revisa el estado de Alerta del producto en bloqueo de cuentas
            Dim bcd As List(Of BLOQUEO_CUENTAS_DINAMICO) = BloqueoCuentaDinamicoByProduc(pc, 3)

            If bcd.Count > 0 Then
                ls_Mensaje2 = bcd.FirstOrDefault().BLOQUEO_OBSERVACION1.descripcion_bloqueo_observacio
            Else
                lb_Alerta = False
            End If

            'Se revisa el estado de Bloqueo y que tipo de bloqueo pertenece
            bcd = BloqueoCuentaDinamicoByProduc(pc, 1)

            If bcd.Count() > 0 Then
                Dim i As Integer = 0
                Do While i <= bcd.Count()
                    ls_Mensaje += Chr(13) + bcd(i).BLOQUEO_OBSERVACION1.descripcion_bloqueo_observacio
                Loop
            End If

            Dim cuenta_eje As CUENTA_EJE = CuentaEjeByProduct(pc)

            'Trae la descripción del tipo de cuenta eje que tiene el cliente
            If cuenta_eje IsNot Nothing Then
                lblTipoCuenta.Text = cuenta_eje.TIPO_CUENTA_EJE1.descripcion_tipo
                'GnTipoCuenta = Val(dbGetValue(1))
            End If


            If (lb_Bloqueado Or lb_Alerta) And lb_Suc = False Then
                Dim detalle As List(Of STATUS_BLOQUEO_GROUP) = DetalleStatusByProduct(pc)

                If detalle IsNot Nothing Then
                    Dim index As Integer
                    Do While index <= detalle.Count()
                        If detalle(index).status_bloqueo = 1 Then
                            ls_Causa += $"La cuenta eje está bloqueada por: {Chr(13)} {ls_Mensaje.Trim()}"
                            ls_Causa += $"{Chr(13)} {ls_Mensaje.Trim()} Observación del Bloqueo: {Chr(13)}"
                            ls_Causa += $"{detalle(index).explicacion} {Chr(13)}"
                        ElseIf detalle(index).status_bloqueo = 3 Then
                            ls_Causa += $"La cuenta permanece en estado de Alerta por: {Chr(13)} {ls_Mensaje2.Trim()}"
                            ls_Causa += $"{Chr(13)} Observación de Alerta: {Chr(13)}"
                            ls_Causa += $"{detalle(index).explicacion} {Chr(13)}"
                        End If
                    Loop
                End If

                If ls_Causa.Trim().Length() = 0 And ls_Mensaje.Trim().Length() = 38 Then
                    ls_Causa += "La cuenta eje está bloqueada por: " + ls_Mensaje
                End If

                MessageBox.Show(ls_Causa, "Cuenta Eje")

                'Revisa el saldo de la cuenta para verificar sobregiros
                Dim concepto As CONCEPTO = ConceptoByProduct(cuenta)

                'Si el saldo de la cuenta es mayor o igual a cero
                If concepto IsNot Nothing Then
                    lb_Sobregiro = False
                Else
                    lb_Sobregiro = True
                End If

                'Si no hay sobregiro ...
                If lb_Sobregiro = False Then
                    'Verifica si la cuenta tiene tarjeta de debito
                    Dim pc2 As PRODUCTO_CONTRATADO = ProductoContratadoByProductAndCuenta(cuenta, 8017)

                    'Si existe tarjeta con status nueva, normal o sin movimiento
                    If pc2 IsNot Nothing Then
                        If pc2.status_producto = 29 Or pc2.status_producto = 30 Or pc2.status_producto = 31 Then
                            bTDDAdicional = True
                            bTDDNueva = False
                        Else
                            bTDDAdicional = False
                            bTDDNueva = False
                        End If
                    Else
                        bTDDNueva = True
                        bTDDAdicional = False
                    End If
                End If

                'Tambien al buscar por nombre debe presentar información de productos.
                'Call cmdBuscar_Click

                If cliente.cuenta_mancomunada = 1 Then
                    siManc = 1
                Else
                    siManc = 0
                End If

                If lb_Bloqueado Then
                    If lb_Suc Then
                        'cmdCD_Overnight.Enabled = False
                        'cmdCD.Enabled = False
                    Else
                        If Not PideAutprizacion("ACTABLOQUEADA", cliente, gn_OpDefinida) Then
                            If lb_Bloqueado Then
                                'cmdCD_Overnight.Enabled = False
                                'cmdCD.Enabled = False
                                'cmdDeposito.Enabled = False
                                'cmdRetiro.Enabled = False
                                'cmdTraspaso.Enabled = False
                            End If
                        End If
                        RegistraAutorizacion("0", "Opera Sobre Cuenta Bloqueada")
                    End If
                End If

                Dim operaciones As List(Of OPERACION) = OperacionesByProduc(pc, 100)

                If operaciones.Count() > 0 Then
                    'Revisa si la cuenta se aperturo en Mercury
                    lblOrigenCta.Text = "CUENTA APERTURADA POR MAC."
                    If lb_Suc Then lblOrigenCta.Text = "CUENTA APERTURADA POR SUCURSAL"
                Else
                    lblOrigenCta.Text = "CUENTA APERTURADA POR PME."
                End If
            End If

            'Si el tipo de cuenta es 000 de LA la operación es diferente
            If gnTipoCuenta = 4 And gAgencia = 1 Then
                If TieneVencimeintos(pc) = False Then
                    'mnuRetOrdenPagoMT103.Enabled = False
                    'mnuRetSucursal.Enabled = False
                    'mnuRetOrdenDivisas.Enabled = False
                    'mnuRetAreasInternas.Enabled = False
                End If
            End If

            If Not verificaDiaFeriado() Then
                'cmdCD_Overnight.Enabled = False
                'cmdDeposito.Enabled = False
                'cmdRetiro.Enabled = False
                'cmdTraspaso.Enabled = False
                'cmdCD.Enabled = False
            End If

            If cta_H IsNot Nothing Then
                MessageBox.Show("Esta cuenta tiene BANKLINK", "Aviso")
            End If

            buscaApertura(cuenta, 100)
            buscaCancelacion(cuenta, 8039, 8009)
            indicaSaldoCargado(1)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub LlenaComboAgencias()

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub ActualizaGridProductoConcOper()
        Dim strQuery As String = "
        Select 
	        operacion AS [num_operacion], 
	        status_nombre = CASE 
		        WHEN status_operacion = 0 THEN 'SIN VALIDAR' 
		        WHEN status_operacion = 1 THEN 'SIN VALIDAR' 
		        WHEN status_operacion = 2 THEN 'VALIDADO' 
		        WHEN status_operacion = 3 THEN 'VALIDADO' 
		        WHEN status_operacion = 4 THEN 'VALIDADO EQ' 
		        WHEN status_operacion = 5 THEN 'RECHAZADO EQ' 
		        WHEN status_operacion = 220 THEN 'SIN VALIDAR' 
		        WHEN status_operacion = 250 THEN 'CANCELADO' 
		        WHEN status_operacion = 6 THEN 'COMPLEMENTADO' 
		        WHEN status_operacion = 12 THEN 'RECHAZADO' 
		        WHEN status_operacion = 16 THEN 'RECHAZADO' 
	        END,
	        descripcion_operacion_definida,
	        fecha_captura,
	        fecha_operacion,
	        monto_operacion
        from 
	        TICKET.dbo.OPERACION O 
            INNER JOIN TICKET.dbo.OPERACION_DEFINIDA OD on O.operacion_definida = OD.operacion_definida         
	        where 
                producto_contratado = @pProductoCont"


        Using contexto As New TICKETEntities
            lista_operaciones1 = contexto.Database.SqlQuery(Of GridOperacion)(strQuery, New SqlParameter("@pProductoCont", producto_contratado)).ToList()
        End Using

        cargaApertura()

        CargaGridOperaciones()

    End Sub

    Private Sub CargaGridOperaciones()
        Try
            Dim dt As DataTable
            dt = New DataTable("Operaciones")

            Dim col1 As DataColumn = New DataColumn("No. Operacion")
            col1.DataType = System.Type.GetType("System.Int32")

            Dim col2 As DataColumn = New DataColumn("Status Nombre")
            col2.DataType = System.Type.GetType("System.String")

            Dim col3 As DataColumn = New DataColumn("Descripcion Operacion Definida")
            col3.DataType = System.Type.GetType("System.String")

            Dim col4 As DataColumn = New DataColumn("Fecha Captura")
            col4.DataType = System.Type.GetType("System.DateTime")

            Dim col5 As DataColumn = New DataColumn("Fecha Operacion")
            col5.DataType = System.Type.GetType("System.DateTime")

            Dim col6 As DataColumn = New DataColumn("Monto Operacion")
            col6.DataType = System.Type.GetType("System.Decimal")

            dt.Columns.Add(col1)
            dt.Columns.Add(col2)
            dt.Columns.Add(col3)
            dt.Columns.Add(col4)
            dt.Columns.Add(col5)
            dt.Columns.Add(col6)

            For index = 0 To (lista_operaciones1.Count - 1)
                Dim row As DataRow
                row = dt.NewRow()

                row.Item("No. Operacion") = lista_operaciones1(index).num_operacion
                row.Item("Status Nombre") = lista_operaciones1(index).status_nombre
                row.Item("Descripcion Operacion Definida") = lista_operaciones1(index).descripcion_operacion_definida
                row.Item("Fecha Captura") = lista_operaciones1(index).fecha_captura
                row.Item("Fecha Operacion") = lista_operaciones1(index).fecha_operacion
                row.Item("Monto Operacion") = lista_operaciones1(index).monto_operacion

                dt.Rows.Add(row)
            Next


            gridOperaciones.DataSource = dt
            gridOperaciones.Refresh()

        Catch ex As Exception
            MessageBox.Show("Error al Consultar el Cliente")
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSaldoDisp_Click(sender As Object, e As EventArgs) Handles btnSaldoDisp.Click
        Dim ln_Saldo As Decimal
        Dim ln_SaldoDepSinVal As Decimal
        Dim ln_SaldoTot
        Dim direccion As Direccion

        Dim strSql As String = $"
        Select 
            CASE WHEN CL.calle is null THEN ''                        
                 WHEN CL.calle = '' THEN ''  
                 ELSE 'Calle: ' + ltrim(rtrim(CL.calle)) + ' '  
            END AS [calle],  
            CASE WHEN CL.no_ext is null THEN ''                       
                 WHEN CL.no_ext = '' THEN ''  
                 ELSE 'No. Ext. ' + ltrim(rtrim(CL.no_ext)) + ' '  
            END AS [noexterior],  
            CASE WHEN CL.no_int is null THEN ''                       
                 WHEN CL.no_int = '' THEN ''  
                 ELSE 'No. Int. ' + ltrim(rtrim(CL.no_int)) + ' '  
            END AS [nointerior], 
            CASE WHEN CL.componente is null THEN ''                   
                 WHEN CL.componente = '' THEN ''  
                 ELSE 'Componente: ' + ltrim(rtrim(CL.componente)) + ' '  
            END AS [componente],  
            CASE WHEN CL.colonia_cliente is null THEN ''              
                 WHEN CL.colonia_cliente = '' THEN ''  
                 ELSE 'Colonia: ' + ltrim(rtrim(CL.colonia_cliente)) + ' '  
            END[colonia],  
            ltrim(rtrim(CL.direccion_cliente)) AS [direccion],                       
           UB.descripcion_ubicacion AS [ubicacion1],                                  
           U2.descripcion_ubicacion AS [ubicacion2]                                 
           From  
           CATALOGOS.dbo.CLIENTE CL
           inner join  FUNCIONARIOS.dbo.UBICACION UB on UB.ubicacion = CL.ubicacion 
           RIGHT OUTER JOIN FUNCIONARIOS.dbo.UBICACION U2  ON U2.ubicacion = UB.ubicacion_padre 
           Where   
	        CL.cuenta_cliente = @cuenta 
            and
   	        CL.agencia = @agencia;
        "

        Using contexto As New CATALOGOSEntities
            direccion = contexto.Database.SqlQuery(Of Direccion)(strSql, New SqlParameter("@cuenta", cuenta), New SqlParameter("@agencia", 1)).FirstOrDefault()
        End Using


        ln_Saldo = ObtenSaldo(productos.FirstOrDefault())
        ln_SaldoDepSinVal = ObtenSaldoDepCom(productos.FirstOrDefault())
        ln_SaldoTot = ln_Saldo + ln_SaldoDepSinVal

        If direccion Is Nothing Then
            MessageBox.Show($"
            Saldo actual de la Cuenta:      {Decimal.Parse(ln_Saldo).ToString("C")} 
            Saldo de Dep Sin Validar:       {Decimal.Parse(ln_SaldoDepSinVal).ToString("C")}
            ----------------------------------------------------------                                  
            Saldo Total:                              {Decimal.Parse(ln_SaldoTot).ToString("C")}

            Sin direccion")
        Else
            MessageBox.Show($"
            Saldo actual de la Cuenta:     {Decimal.Parse(ln_Saldo).ToString("C")} 
            Saldo de Dep Sin Validar:      {Decimal.Parse(ln_SaldoDepSinVal).ToString("C")}
            ----------------------------------------------------------
            Saldo Total:                             {Decimal.Parse(ln_SaldoTot).ToString("C")}

            Dirección del Cliente:         
            {direccion.direccion}")
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmConsultaSaldosMov_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = Me.Height + 25
        'Me.Width = 1260


        agencias = AgenciasByAll()

        lblSaldo.Text = ""
        lblSaldo.ForeColor = Color.Black
        lblSaldo.Visible = False

        lblOrigenCta.Text = ""

        'Enciende bandera de que está activa frmCliente, se utiliza para consulta de TD y TDO
        bActivafrmCliente = True
        btnSaldoDisp.Enabled = False

        ''Si no tiene Permiso para Agencia: CAYMAN el botón no debe mostrarse
        'If Not Permiso("PAGENCIACAYMAN") Then
        '    cmdCD_Overnight.Visible = False
        'End If

        'cmdCD_Overnight.Enabled = False
        'cmdDeposito.Enabled = False
        'cmdRetiro.Enabled = False
        'cmdTraspaso.Enabled = False
        'btnBuscar.Enabled = False

        'Se llena el arreglo con los titulos para la tabla de productos
        la_TitulosProducto = New List(Of String)

        la_TitulosProducto.Add("     ")
        la_TitulosProducto.Add(" St. Producto")
        la_TitulosProducto.Add(" Clave")
        la_TitulosProducto.Add(" Descripción")

        'Se llena el arreglo con los titulos para la tabla de conceptos
        la_TitulosConcepto = New List(Of String)

        la_TitulosConcepto.Add(" Descripción")
        la_TitulosConcepto.Add(" Valor")

        'Se llena el arreglo con los titulos para la tabla de operaciones
        la_TitulosOperaciones = New List(Of String)

        la_TitulosOperaciones.Add(" Ticket")
        la_TitulosOperaciones.Add(" St. Operación")
        la_TitulosOperaciones.Add(" Operación")
        la_TitulosOperaciones.Add(" Fecha Captura ")
        la_TitulosOperaciones.Add(" Fecha Operación")
        la_TitulosOperaciones.Add(" Monto")

        'Se llenan los titulos de las tablas

    End Sub



    Private Sub mdiSEECargaGridP(control As Control, query As String, tiulos() As String)

    End Sub

    Private Sub mdiSEECargaGrid2(control As Control, query As String, tiulos() As String)

    End Sub
    Private Sub mdiSEECargaGrid(control As Control, query As String, tiulos() As String)

    End Sub

    Private Sub mdiSEECargaTitulosGrid(control As Control, tiulos() As String)

    End Sub

    Private Sub gridProductos_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridProductos.CellContentDoubleClick
        Dim producto_contratado As String = gridProductos.Rows(e.RowIndex).Cells(1).Value.ToString()
        Dim producto_global As PRODUCTO_CONTRATADO
        'Dim producto_global As PRODUCTO_CONTRATADO = ProductoContratadoByProduct(Int32.Parse(producto_contratado))
        Dim clave As Integer = Int32.Parse(producto_contratado)
        Using contexto As New TICKETEntities
            producto_global = (
                    From pc In contexto.PRODUCTO_CONTRATADO
                    Join p In contexto.PRODUCTO On pc.producto Equals p.producto1
                    Where pc.clave_producto_contratado = clave
                    Select pc
            ).FirstOrDefault()

            Dim frmConsProd As ConsProd = New ConsProd
            Dim frmConsHold As ConsHold = New ConsHold


            Select Case producto_global.PRODUCTO1.producto_global
            'Time Deposit's
                Case 11
                    GnProdContCd = Integer.Parse(producto_global.clave_producto_contratado.Trim())
                    frmConsProd.prod = Integer.Parse(producto_global.clave_producto_contratado.Trim())
                    frmConsProd.Show()
            'Hold's
                Case 12
                    GnProdContCd = producto_global.clave_producto_contratado
                    frmConsHold.prod = producto_global.clave_producto_contratado
                    frmConsHold.MiTipoHold = 12
                    frmConsHold.Show()
            'Hold's TDD
                Case 14
                    GnProdContCd = producto_global.clave_producto_contratado
            End Select

        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        btnBuscar.Visible = False
        If Not BackgroundWorker1.IsBusy() Then
            BackgroundWorker1.RunWorkerAsync()
        Else
            MessageBox.Show("Programa ocupado")
        End If
    End Sub

    Private Function verificaDiaFeriado() As Boolean
        verificaDiaFeriado = False

        Dim fecha As DIAS_FERIADOS = DiaFeriadoByFecha(DateTime.Now)

        If fecha IsNot Nothing Then
            'mnuRetSucursal.Enabled = False
            'mnuRetAreasInternas.Enabled = False
            'mnuRetOrdenDivisas.Enabled = False
            'mnuRetDirecto.Enabled = False
            'mnuRetAclaracion.Enabled = False
            'cmdTraspaso.Enabled = False
            'cmdCD.Enabled = False
            'cmdCD_Overnight.Enabled = False
            'cmdRetiro.Enabled = False
            'mnuDepDirecto.Enabled = False
            'mnuDepDirecto.Visible = False
        End If

        verificaDiaFeriado = True
    End Function

    ''' <summary>
    ''' Indica que tipo de saldos estan cargados en el sistema.
    ''' </summary>
    ''' <param name="agencia"></param>
    Private Sub indicaSaldoCargado(agencia As Integer)
        Dim posicion As Integer
        If agencia = 1 Then
            posicion = 2
        End If

        lblSaldo.Visible = True
        lblSaldo.ForeColor = Color.Black

        Dim status As String = GetParametro(posicion)

        If status <> String.Empty Then
            If status = "1" Then
                lblSaldo.Text = "Saldo Equation OK"
                lblSaldo.ForeColor = Color.Green
            ElseIf status = "9" Then
                lblSaldo.Text = "Saldo Contingencia"
                lblSaldo.ForeColor = Color.Blue
            ElseIf status = "0" Then
                lblSaldo.Text = "Saldo Sin Cargar"
                lblSaldo.ForeColor = Color.Red
            End If
        Else
            lblSaldo.Text = "Saldo Sin Cargar"
            lblSaldo.ForeColor = Color.Red
        End If

    End Sub

    Private Sub CargaGridProductos()
        Try
            bdTicket.Configuration.LazyLoadingEnabled = True

            producto_contratado = ProductoContratadoByProductoAndCuenta(8009, cuenta, 1).producto_contratado1
            ProductoContratadoByCuenta(cuenta)




            Dim dt As DataTable
            dt = New DataTable("Productos")

            Dim col1 As DataColumn = New DataColumn("St. Producto")
            col1.DataType = System.Type.GetType("System.String")

            Dim col2 As DataColumn = New DataColumn("Clave")
            col2.DataType = System.Type.GetType("System.String")

            Dim col3 As DataColumn = New DataColumn("Descripcion")
            col3.DataType = System.Type.GetType("System.String")

            dt.Columns.Add(col1)
            dt.Columns.Add(col2)
            dt.Columns.Add(col3)

            For index = 0 To (productos.Count - 1)
                Dim row As DataRow
                row = dt.NewRow()

                row.Item("St. Producto") = productos(index).STATUS_PRODUCTO1.descripcion_status.TrimEnd()
                row.Item("Clave") = productos(index).clave_producto_contratado.TrimEnd()
                row.Item("Descripcion") = productos(index).PRODUCTO1.descripcion_producto.TrimEnd()

                dt.Rows.Add(row)
            Next


            gridProductos.DataSource = dt
            gridProductos.Refresh()

        Catch ex As Exception
            MessageBox.Show("Error al Consultar el Cliente")
        End Try
    End Sub

    Private Function ProductoContratadoByProductoAndCuenta(prod_cont As Integer, cuenta As String, p_agencia As Integer) As PRODUCTO_CONTRATADO
        ProductoContratadoByProductoAndCuenta = Nothing
        ProductoContratadoByProductoAndCuenta = (
                    From pc In bdTicket.PRODUCTO_CONTRATADO
                    Where
                        pc.cuenta_cliente = cuenta And pc.agencia = p_agencia And pc.producto = prod_cont
                    Select pc).FirstOrDefault()
    End Function

    Private Sub ProductoContratadoByCuenta(cuenta As String)
        productos = Nothing
        productos = (
                    From pc In bdTicket.PRODUCTO_CONTRATADO
                    Join p In bdTicket.PRODUCTO On pc.producto Equals p.producto1
                    Join sp In bdTicket.STATUS_PRODUCTO On pc.status_producto Equals sp.status_producto1
                    Where
                        pc.cuenta_cliente = cuenta And pc.agencia = 1 And pc.producto <> 3028
                    Select pc).ToList()
    End Sub

    Private Function ProductoContratadoByCuentaAndGlobal(cuenta As String, producto_glob As Integer) As PRODUCTO_CONTRATADO
        ProductoContratadoByCuentaAndGlobal = (
                    From pc In bdTicket.PRODUCTO_CONTRATADO
                    Join p In bdTicket.PRODUCTO On pc.producto Equals p.producto1
                    Join sp In bdTicket.STATUS_PRODUCTO On pc.status_producto Equals sp.status_producto1
                    Where
                        pc.cuenta_cliente = cuenta And pc.agencia = 1 And p.producto_global = producto_glob
                    Select pc).FirstOrDefault()
    End Function

    Private Sub cmbAgencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAgencia.SelectedIndexChanged

    End Sub

    Private Function ExisteCuenta(cuenta As Integer) As Boolean
        Dim cliente As CLIENTE = ClienteByCuenta()

        If cliente IsNot Nothing Then
            ExisteCuenta = True
        Else
            ExisteCuenta = False
        End If
    End Function

    Private Sub CargaConceptos()
        lblDescripcionConcepto.Text = productos.FirstOrDefault().CONCEPTO.Where(Function(w) w.concepto_definido = 8005).FirstOrDefault().CONCEPTO_DEFINIDO1.descripcion_concepto_definido
        lblValorConcepto.Text = productos.FirstOrDefault().CONCEPTO.Where(Function(w) w.concepto_definido = 8005).FirstOrDefault().valor_concepto.ToString("C")

    End Sub





    Private Function GetParametro(posicion As Integer) As String
        GetParametro = String.Empty

        Dim query As String = $"SELECT 
	        SUBSTRING( CONVERT(varchar(4),  error_saldos), @posicion , 1) AS status
        From 
          PARAMETROS"

        Using contexto As New TICKETEntities
            GetParametro = contexto.Database.SqlQuery(Of String)(query, New SqlParameter("@cuenta", cuenta), New SqlParameter("@posicion", posicion)).FirstOrDefault()
        End Using


    End Function









    Private Function DiaFeriadoByFecha(fecha As DateTime) As DIAS_FERIADOS
        DiaFeriadoByFecha = (
            From df In bdCatalogos.DIAS_FERIADOS
            Where df.fecha = fecha
            Select df
        ).FirstOrDefault()
    End Function

    ''' <summary>
    ''' Determinar si una cuenta tiene vencimientos de time deposit fecha valor hoy
    ''' </summary>
    ''' <returns></returns>
    Private Function TieneVencimeintos(pc As PRODUCTO_CONTRATADO) As Boolean
        TieneVencimeintos = False

        If OperacionesByProduc(pc, 580, 250, DateTime.Now).Count() <> 0 Then
            TieneVencimeintos = True
        End If


    End Function

    Private Function OperacionesByProduc(pc As PRODUCTO_CONTRATADO, product_global As Integer) As List(Of OPERACION)
        OperacionesByProduc = (
            From o In bdTicket.OPERACION
            Join od In bdTicket.OPERACION_DEFINIDA On o.operacion_definida Equals od.operacion_definida1
            Where o.producto_contratado = pc.producto_contratado1 And od.operacion_definida_global = product_global
            Select o
        ).ToList()
    End Function

    Private Function OperacionesByProduc(pc As PRODUCTO_CONTRATADO, product_global As Integer, status_operaciona As Integer, fecha As DateTime) As List(Of OPERACION)
        OperacionesByProduc = (
            From o In bdTicket.OPERACION
            Join od In bdTicket.OPERACION_DEFINIDA On o.operacion_definida Equals od.operacion_definida1
            Where o.producto_contratado = pc.producto_contratado1 And od.operacion_definida_global = product_global And o.fecha_operacion = fecha And o.status_operacion <> status_operaciona
            Select o
        ).ToList()
    End Function

    Private Sub RegistraAutorizacion(v1 As String, v2 As String)
        Throw New NotImplementedException()
    End Sub

    Private Function PideAutprizacion(v As String, cliente As CLIENTE, gn_OpDefinida As Integer) As Boolean
        Throw New NotImplementedException()
    End Function

    Private Function ProductoContratadoByProductAndCuenta(cuenta As String, product As Integer) As PRODUCTO_CONTRATADO
        ProductoContratadoByProductAndCuenta = (From pc In bdTicket.PRODUCTO_CONTRATADO
                                                Where pc.producto = product And pc.cuenta_cliente = cuenta And (pc.status_producto = 34 Or pc.status_producto = 36 Or pc.status_producto = 38)
                                                Select pc).FirstOrDefault()
    End Function

    Private Function ConceptoByProduct(cuenta As String) As CONCEPTO
        ConceptoByProduct = (From c In bdTicket.CONCEPTO
                             Join pc In bdTicket.PRODUCTO_CONTRATADO On c.producto_contratado Equals pc.producto_contratado1
                             Where pc.cuenta_cliente = cuenta And (pc.producto = 8009 Or pc.producto = 8010) And (pc.status_producto = 1 Or pc.status_producto = 2)
                             Select c).FirstOrDefault()
    End Function

    Private Function DetalleStatusByProduct(pc As PRODUCTO_CONTRATADO) As List(Of STATUS_BLOQUEO_GROUP)
        DetalleStatusByProduct = (From ds In bdTicket.DETALLE_STATUS
                                  Where ds.producto_contratado = pc.producto_contratado1
                                  Group By dsGroup = New With {Key ds.status_bloqueo, Key ds.explicacion} Into Cuenta = Count(ds.status_bloqueo)
                                  Order By dsGroup.status_bloqueo Ascending
                                  Select New STATUS_BLOQUEO_GROUP With {.status_bloqueo = dsGroup.status_bloqueo, .explicacion = dsGroup.explicacion, .status_grupo = Cuenta}).ToList()
    End Function

    Private Function CuentaEjeByProduct(pc As PRODUCTO_CONTRATADO) As CUENTA_EJE
        CuentaEjeByProduct = (From ce In bdTicket.CUENTA_EJE
                              Join tce In bdTicket.TIPO_CUENTA_EJE On ce.tipo_cuenta_eje Equals tce.tipo_cuenta_eje1
                              Where ce.producto_contratado = pc.producto_contratado1
                              Select ce
                                          ).FirstOrDefault()

    End Function

    Private Function BloqueoCuentaDinamicoByProduc(pc As PRODUCTO_CONTRATADO, st As Integer) As List(Of BLOQUEO_CUENTAS_DINAMICO)
        BloqueoCuentaDinamicoByProduc = (From bcd In bdTicket.BLOQUEO_CUENTAS_DINAMICO
                                         Join bo In bdTicket.BLOQUEO_OBSERVACION On bcd.bloqueo_observacion Equals bo.bloqueo_observacion1
                                         Where bcd.producto_contratado = pc.producto_contratado1 And bo.status_bloqueo = st
                                         Select bcd).ToList()
    End Function

    Private Function AperturaSucursalManualByProduct(pc As PRODUCTO_CONTRATADO) As APERTURA_SUCURSAL_MANUAL
        AperturaSucursalManualByProduct = bdTicket.APERTURA_SUCURSAL_MANUAL.Where(Function(w) w.producto_contratado = pc.producto_contratado1).FirstOrDefault()
    End Function

    Private Function OperacionByProduc(pc As PRODUCTO_CONTRATADO) As OPERACION
        OperacionByProduc = (
            From o In bdTicket.OPERACION
            Join od In bdTicket.OPERACION_DEFINIDA On o.operacion_definida Equals od.operacion_definida1
            Where o.producto_contratado = pc.producto_contratado1 And od.operacion_definida_global = 100
            Select o
        ).FirstOrDefault()
    End Function



    Private Function CancelaReactivaCuentaByProduc(consecutivo As Integer) As CANCELA_REACTIVA_CUENTAS
        Return bdTicket.CANCELA_REACTIVA_CUENTAS.Where(Function(w) w.consecutivo = consecutivo).FirstOrDefault()
    End Function

    Private Function MaxCancelaReactivaCuentaByProduc(product As Integer) As Integer
        Return bdTicket.CANCELA_REACTIVA_CUENTAS.Where(Function(w) w.producto_contratado = product).Select(Function(s) s.consecutivo).DefaultIfEmpty().Max()
    End Function

    Private Function UnidadesOrganizacionesByUnidad(num_uinidad As Long) As UNIDAD_ORGANIZACIONAL
        UnidadesOrganizacionesByUnidad = (
                From uo In bdFuncionarios.UNIDAD_ORGANIZACIONAL
                Where uo.unidad_organizacional1 = num_uinidad
                Select uo).FirstOrDefault()
    End Function

    Private Function ClienteByCuenta() As CLIENTE
        ClienteByCuenta = (
                From c In bdCatalogos.CLIENTE
                Where c.cuenta_cliente = cuenta And c.agencia = 1
                Select c
            ).FirstOrDefault()
    End Function





    Private Sub LlenarDatosClientes()

        If cliente.persona_moral = 1 Then
            lblCliente.Text = $"{cliente.nombre_cliente.Trim()}"
        Else
            lblCliente.Text = $"{cliente.nombre_cliente.Trim()} {cliente.apellido_paterno.Trim()} {cliente.apellido_materno.Trim()}"
        End If


        If cliente.cuenta_houston <> "" Then
            lblCuentaHouston.Text = cliente.cuenta_houston
            lblCuentaHouston.Visible = True
            cta_H = cliente.cuenta_houston
        Else
            lblCuentaHouston.Visible = False
        End If
    End Sub



    Private Sub LlenarDatosFuncionario()
        lblFax.Text = funcionario.fax_funcionario
        lblTelefono.Text = funcionario.telefono_funcionario
        lblNumFuncionario.Text = funcionario.numero_funcionario
        lblFuncionario.Text = GetNombreFuncionario()
    End Sub

    Private Function GetNombreFuncionario() As String
        Return $"{funcionario.nombre_funcionario.Trim()} {funcionario.apellido_paterno.Trim()} {funcionario.apellido_materno.Trim()}"
    End Function

    Private Function FuncionarioByFunc(cliente As CLIENTE) As FUNCIONARIO
        Dim num_func As Integer = cliente.funcionario

        FuncionarioByFunc = (
                From f In bdFuncionarios.FUNCIONARIO
                Where f.funcionario1 = num_func
                Select f
            ).FirstOrDefault()

        numero_uo = FuncionarioByFunc.unidad_organizacional
    End Function
    Private Function AgenciasByAll() As List(Of AGENCIA)
        Try
            AgenciasByAll = bdCatalogos.AGENCIA.ToList()

        Catch ex As Exception
            MessageBox.Show("Error al Consultar Agencias")
            AgenciasByAll = New List(Of AGENCIA)

        End Try

    End Function

    Private Sub txtCuenta_Leave(sender As Object, e As EventArgs) Handles txtCuenta.Leave
        LlenarCmbAgencias()
    End Sub

    Private Sub LlenarCmbAgencias()
        agencias = agencias.Where(Function(a) a.agencia1 = 1).ToList()
        cmbAgencia.DataSource = agencias
        cmbAgencia.ValueMember = "agencia1"
        cmbAgencia.DisplayMember = "descripcion_agencia"
        cmbAgencia.Refresh()
    End Sub

    Private Sub cmbAgencia_Click(sender As Object, e As EventArgs) Handles cmbAgencia.Click
        click_cmbAgencias = True
    End Sub



    ''' <summary>
    ''' Calcula el saldo disponible para una cuenta eje de Depósitos comprometidos
    ''' </summary>
    ''' <param name="producto"></param>
    ''' <returns></returns>
    Private Function ObtenSaldoDepCom(producto As PRODUCTO_CONTRATADO) As Decimal
        Using contexto As New TICKETEntities
            Dim operaciones_global, status, origenes, conceptos, productos_globales As Integer()
            Dim nSaldo As Decimal = 0
            Dim list_operaciones As List(Of OPERACION)

            status = New Integer() {1, 220}
            operaciones_global = New Integer() {583, 589, 590, 591, 552, 553, 559}

            list_operaciones = (
                    From o In contexto.OPERACION
                    Join od In contexto.OPERACION_DEFINIDA On o.operacion_definida Equals od.operacion_definida1
                    Where o.producto_contratado = producto.producto_contratado1 And (status.Contains(o.status_operacion)) And (operaciones_global.Contains(od.operacion_definida_global)) And o.fecha_operacion = DateTime.Now
                    Select o
            ).ToList()

            If (list_operaciones.Count() > 0) Then
                nSaldo = list_operaciones.Sum(Function(s) s.monto_operacion)
            Else
                nSaldo = 0
            End If

            ObtenSaldoDepCom = nSaldo
        End Using
    End Function

    ''' <summary>
    ''' Calcula el saldo disponible para una cuenta eje
    ''' </summary>
    ''' <param name="producto"></param>
    ''' <returns></returns>
    Private Function ObtenSaldo(producto As PRODUCTO_CONTRATADO) As Decimal
        Using contexto As New TICKETEntities

            Dim nSaldo As Decimal = 0
            Dim operaciones_global, status, origenes, conceptos, productos_globales As Integer()
            Dim list_operaciones As List(Of OPERACION)
            Dim list_conceptos As List(Of CONCEPTO)

            ObtenSaldo = 0
            'SALDO QUE BAJA DE EQUATION AL INICIO DE DIA
            Dim concepto As CONCEPTO = ConceptoByProductoAndGlobal(producto.producto_contratado1, 5)

            If concepto IsNot Nothing Then
                nSaldo = concepto.valor_concepto
            Else
                nSaldo = 0
            End If

            'Depositos fecha valor hoy ya validados y no cancelados
            'incluyendo depositos por vencimiento
            status = New Integer() {2, 3, 4, 5}
            operaciones_global = New Integer() {560, 580, 583, 584, 585, 587, 597, 588, 589, 590, 591, 592, 680, 552, 553, 559}


            list_operaciones = (
                    From o In contexto.OPERACION
                    Join od In contexto.OPERACION_DEFINIDA On o.operacion_definida Equals od.operacion_definida1
                    Where o.producto_contratado = producto.producto_contratado1 And (status.Contains(o.status_operacion)) And (operaciones_global.Contains(od.operacion_definida_global)) And o.fecha_operacion = DateTime.Now
                    Select o
            ).ToList()

            If (list_operaciones.Count() > 0) Then
                nSaldo += list_operaciones.Sum(Function(s) s.monto_operacion)
            End If

            'Todos los retiros (menos orden de pago, td, over's) fecha valor hoy que no esten cancelados
            operaciones_global = New Integer() {60, 65, 83, 84, 85, 86, 87, 91, 94, 96, 97, 88, 89, 52, 53, 54, 56, 57, 58, 59}

            list_operaciones = (
                    From o In contexto.OPERACION
                    Join od In contexto.OPERACION_DEFINIDA On o.operacion_definida Equals od.operacion_definida1
                    Where o.producto_contratado = producto.producto_contratado1 And (o.status_operacion <> 250) And (operaciones_global.Contains(od.operacion_definida_global)) And o.fecha_operacion >= DateTime.Now
                    Select o
            ).ToList()

            If (list_operaciones.Count() > 0) Then
                nSaldo -= list_operaciones.Sum(Function(s) s.monto_operacion)
            End If

            'Algun retiro que no se haya validado a tiempo por lo tanto sería fecha valor anterior y estaría en status 0 o 1, los unicos retiros que se validan son los de
            'la cuenta mercury en agencias y las compras de TD cuando son renovaciones
            status = New Integer() {0, 1, 220}
            operaciones_global = New Integer() {80, 83, 85, 86, 87, 91, 94, 96, 97, 88, 89, 180, 52, 53, 54, 56, 57, 58, 59}

            list_operaciones = (
                   From o In contexto.OPERACION
                   Join od In contexto.OPERACION_DEFINIDA On o.operacion_definida Equals od.operacion_definida1
                   Where o.producto_contratado = producto.producto_contratado1 And (status.Contains(o.status_operacion)) And (operaciones_global.Contains(od.operacion_definida_global)) And o.fecha_operacion < DateTime.Now
                   Select o
            ).ToList()

            If (list_operaciones.Count() > 0) Then
                nSaldo -= list_operaciones.Sum(Function(s) s.monto_operacion)
            End If

            'Todos los retiros por orden de pago fecha valor o mañana, que no esten cancelados y no sean parcialmente/sujetos a recepción
            list_operaciones = (
                      From o In contexto.OPERACION
                      Join od In contexto.OPERACION_DEFINIDA On o.operacion_definida Equals od.operacion_definida1
                      Join rop In contexto.RETIRO_ORDEN_PAGO On o.operacion1 Equals rop.operacion
                      Where o.producto_contratado = producto.producto_contratado1 And o.status_operacion <> 250 And o.fecha_operacion >= DateTime.Now And od.operacion_definida_global = 81 And rop.sujeto_a_recepcion = 0 And rop.parcialmente_sujeto = 0
                      Select o
              ).ToList()

            If (list_operaciones.Count() > 0) Then
                nSaldo -= list_operaciones.Sum(Function(s) s.monto_operacion)
            End If


            'Todos los retiros por orden de pago fecha anterior y que no fue validado, que no esten cancelados y no sean parcialmente/sujetos a recepción
            status = New Integer() {0, 1}

            list_operaciones = (
                     From o In contexto.OPERACION
                     Join od In contexto.OPERACION_DEFINIDA On o.operacion_definida Equals od.operacion_definida1
                     Join rop In contexto.RETIRO_ORDEN_PAGO On o.operacion1 Equals rop.operacion
                     Where o.producto_contratado = producto.producto_contratado1 And (status.Contains(o.status_operacion)) And o.fecha_operacion < DateTime.Now And od.operacion_definida_global = 81 And rop.sujeto_a_recepcion = 0 And rop.parcialmente_sujeto = 0
                     Select o
             ).ToList()

            If (list_operaciones.Count() > 0) Then
                nSaldo -= list_operaciones.Sum(Function(s) s.monto_operacion)
            End If



            'Retiros por compra de TD que no son de renovacion, de fechas valor hoy o futuras y no sujetos a recepcion
            origenes = New Integer() {1, 7}
            list_operaciones = (
                   From o In contexto.OPERACION
                   Join od In contexto.OPERACION_DEFINIDA On o.operacion_definida Equals od.operacion_definida1
                   Join cc In contexto.COMPRA_CD On o.operacion1 Equals cc.operacion
                   Where o.producto_contratado = producto.producto_contratado1 And o.status_operacion <> 250 And o.status_operacion >= 0 And o.fecha_operacion >= DateTime.Now And od.operacion_definida_global = 80 And cc.renovacion = 2 And Not (origenes.Contains(cc.origen))
                   Select o
            ).ToList()

            If (list_operaciones.Count() > 0) Then
                nSaldo -= list_operaciones.Sum(Function(s) s.monto_operacion)
            End If


            'TRAE LOS TD QUE SON DE RENOVACION Y FECHA DE OPERACION HOY, son solo las operaciones origen que son
            'de renovación por lo tanto tienen producto_contratado a renovar igual a nulo
            list_operaciones = (
                   From o In contexto.OPERACION
                   Join od In contexto.OPERACION_DEFINIDA On o.operacion_definida Equals od.operacion_definida1
                   Join cc In contexto.COMPRA_CD On o.operacion1 Equals cc.operacion
                   Where o.producto_contratado = producto.producto_contratado1 And o.status_operacion <> 250 And o.status_operacion >= 0 And o.fecha_operacion = DateTime.Now And od.operacion_definida_global = 80 And cc.renovacion <> 2 And Not (origenes.Contains(cc.origen))
                   Select o
            ).ToList()

            If (list_operaciones.Count() > 0) Then
                nSaldo -= list_operaciones.Sum(Function(s) s.monto_operacion)
            End If


            'TRAE LOS TD QUE SON DE RENOVACION Y FECHA DE OPERACION futura solo se revisa el estatus 2 para diferenciarlas de las de futuros
            'que son renovacion de una compra, son solo las operaciones origen que son
            'de renovación por lo tanto tienen producto_contratado a renovar igual a nulo
            list_operaciones = (
                   From o In contexto.OPERACION
                   Join od In contexto.OPERACION_DEFINIDA On o.operacion_definida Equals od.operacion_definida1
                   Join cc In contexto.COMPRA_CD On o.operacion1 Equals cc.operacion
                   Where o.producto_contratado = producto.producto_contratado1 And o.status_operacion <> 250 And o.status_operacion >= 2 And o.fecha_operacion > DateTime.Now And od.operacion_definida_global = 80 And cc.renovacion <> 2 And Not (origenes.Contains(cc.origen))
                   Select o
            ).ToList()

            If (list_operaciones.Count() > 0) Then
                nSaldo -= list_operaciones.Sum(Function(s) s.monto_operacion)
            End If


            'TD overnight
            list_operaciones = (
                      From o In contexto.OPERACION
                      Join od In contexto.OPERACION_DEFINIDA On o.operacion_definida Equals od.operacion_definida1
                      Join cto In contexto.COMPRA_TD_OVERNIGHT On o.operacion1 Equals cto.operacion
                      Where o.producto_contratado = producto.producto_contratado1 And o.status_operacion <> 250 And o.fecha_operacion = DateTime.Now And od.operacion_definida_global = 180 And Not (origenes.Contains(cto.origen))
                      Select o
               ).ToList()

            If (list_operaciones.Count() > 0) Then
                nSaldo -= list_operaciones.Sum(Function(s) s.monto_operacion)
            End If

            'TD's Overnight validados a futuros
            list_operaciones = (
                From o In contexto.OPERACION
                Join od In contexto.OPERACION_DEFINIDA On o.operacion_definida Equals od.operacion_definida1
                Join cto In contexto.COMPRA_TD_OVERNIGHT On o.operacion1 Equals cto.operacion
                Where o.producto_contratado = producto.producto_contratado1 And o.status_operacion <> 250 And o.status_operacion >= 2 And o.fecha_operacion > DateTime.Now And od.operacion_definida_global = 180 And Not (origenes.Contains(cto.origen))
                Select o
             ).ToList()

            If (list_operaciones.Count() > 0) Then
                nSaldo -= list_operaciones.Sum(Function(s) s.monto_operacion)
            End If


            ''Operaciónes con tarjeta de débito que se reporten por concepto de Floating
            'Select Case Sum(FL.monto) From Transferencia.FLOATING FL, TARJETA_DEBITO TD,
            'PRODUCTO_CONTRATADO PC, PRODUCTO_CONTRATADO PCT where
            'PC.producto_contratado = @producto_contratado
            'And PC.cuenta_cliente = PCT.cuenta_cliente
            'And PCT.producto=8017 And PCT.status_producto <>250
            'And PCT.producto_contratado = TD.producto_contratado
            'And FL.numero_tarjeta = TD.tarjeta0

            'Operaciónes que se bajan directamente de kapiti retiro
            list_operaciones = (
                    From o In contexto.OPERACION
                    Join od In contexto.OPERACION_DEFINIDA On o.operacion_definida Equals od.operacion_definida1
                    Where o.producto_contratado = producto.producto_contratado1 And o.status_operacion <> 250 And o.fecha_operacion = DateTime.Now And od.operacion_definida_global = 95
                    Select o
            ).ToList()

            If (list_operaciones.Count() > 0) Then
                nSaldo -= list_operaciones.Sum(Function(s) s.monto_operacion)

            End If

            'Operaciónes que se bajan directamente de kapiti depósito
            list_operaciones = (
                    From o In contexto.OPERACION
                    Join od In contexto.OPERACION_DEFINIDA On o.operacion_definida Equals od.operacion_definida1
                    Where o.producto_contratado = producto.producto_contratado1 And o.status_operacion <> 250 And o.fecha_operacion = DateTime.Now And od.operacion_definida_global = 595
                    Select o
            ).ToList()

            If (list_operaciones.Count() > 0) Then
                nSaldo += list_operaciones.Sum(Function(s) s.monto_operacion)
            End If

            'Suma de Hold's
            conceptos = New Integer() {10, 20}
            productos_globales = New Integer() {2, 7}
            list_conceptos = (
                      From ch In contexto.CONCEPTO
                      Join pch In contexto.PRODUCTO_CONTRATADO On ch.producto_contratado Equals pch.producto_contratado1
                      Join cdh In contexto.CONCEPTO_DEFINIDO On pch.producto Equals cdh.producto
                      Join sph In contexto.STATUS_PRODUCTO On sph.status_producto1 Equals pch.status_producto
                      Join pcta In contexto.PRODUCTO On pcta.agencia Equals pch.agencia
                      Join pccta In contexto.PRODUCTO_CONTRATADO On pccta.cuenta_cliente Equals pch.cuenta_cliente
                      Where pch.agencia = cdh.agencia And cdh.concepto_definido1 = ch.concepto_definido And conceptos.Contains(cdh.concepto_definido_global) And sph.producto = pch.producto And sph.agencia = pch.agencia And productos_globales.Contains(sph.status_producto1) And pcta.producto1 = pccta.producto And pcta.agencia = pccta.agencia And pcta.producto_global = 9 And pccta.producto_contratado1 = producto.producto_contratado1
                      Select ch
              ).ToList()

            If (list_conceptos.Count() > 0) Then
                nSaldo -= list_conceptos.Sum(Function(s) s.valor_concepto)
            End If

            ObtenSaldo = nSaldo
        End Using


    End Function

    Private Function OperacionByStatusFechaAndGlobal(fecha As Date, status As Integer, operacion_global() As Integer, producto_contratado As Integer) As Decimal
        Using contexto As New TICKETEntities
            OperacionByStatusFechaAndGlobal = (
                    From o In contexto.OPERACION
                    Join od In contexto.OPERACION_DEFINIDA On o.operacion_definida Equals od.operacion_definida1
                    Where o.producto_contratado = producto_contratado And (o.status_operacion <> status) And (operacion_global.Contains(od.operacion_definida_global)) And o.fecha_operacion >= fecha
                    Select o
            ).Sum(Function(s) s.monto_operacion)
        End Using
    End Function

    Private Function OperacionByStatusFechaAndGlobal(fecha As Date, status() As Integer, operacion_global() As Integer, producto_contratado As Integer) As Decimal
        Using contexto As New TICKETEntities
            OperacionByStatusFechaAndGlobal = (
                    From o In contexto.OPERACION
                    Join od In contexto.OPERACION_DEFINIDA On o.operacion_definida Equals od.operacion_definida1
                    Where o.producto_contratado = producto_contratado And (status.Contains(o.status_operacion)) And (operacion_global.Contains(od.operacion_definida_global)) And o.fecha_operacion = fecha
                    Select o
            ).Sum(Function(s) s.monto_operacion)
        End Using
    End Function

    Private Function ConceptoByProductoAndGlobal(producto_contratado As Integer, concepto_global As Integer) As CONCEPTO
        Using contexto As New TICKETEntities
            ConceptoByProductoAndGlobal = (
                    From c In contexto.CONCEPTO
                    Join cd In contexto.CONCEPTO_DEFINIDO On c.concepto_definido Equals cd.concepto_definido1
                    Where c.producto_contratado = producto_contratado And cd.concepto_definido_global = concepto_global
                    Select c
            ).FirstOrDefault()
        End Using
    End Function

    Public Class Direccion
        Private _calle As String
        Private _noexterior As String
        Private _nointerior As String
        Private _componente As String
        Private _colonia As String
        Private _direccion As String
        Private _ubicacion1 As String
        Private _ubicacion2 As String
        Public Property ubicacion2() As String
            Get
                Return _ubicacion2
            End Get
            Set(ByVal value As String)
                _ubicacion2 = value
            End Set
        End Property

        Public Property ubicacion1() As String
            Get
                Return _ubicacion1
            End Get
            Set(ByVal value As String)
                _ubicacion1 = value
            End Set
        End Property

        Public Property direccion() As String
            Get
                Return _direccion
            End Get
            Set(ByVal value As String)
                _direccion = value
            End Set
        End Property

        Public Property colonia() As String
            Get
                Return _colonia
            End Get
            Set(ByVal value As String)
                _colonia = value
            End Set
        End Property

        Public Property componente() As String
            Get
                Return _componente
            End Get
            Set(ByVal value As String)
                _componente = value
            End Set
        End Property



        Public Property nointerior() As String
            Get
                Return _nointerior
            End Get
            Set(ByVal value As String)
                _nointerior = value
            End Set
        End Property

        Public Property noexterior() As String
            Get
                Return _noexterior
            End Get
            Set(ByVal value As String)
                _noexterior = value
            End Set
        End Property

        Public Property calle() As String
            Get
                Return _calle
            End Get
            Set(ByVal value As String)
                _calle = value
            End Set
        End Property
    End Class



    Private Function ProductoContratadoByProduct(prod As Integer) As PRODUCTO_CONTRATADO
        Using contexto As New TICKETEntities
            Dim producto As PRODUCTO_CONTRATADO = (
                    From pc In contexto.PRODUCTO_CONTRATADO
                    Join p In contexto.PRODUCTO On pc.producto Equals p.producto1
                    Where pc.clave_producto_contratado = prod
                    Select pc
            ).FirstOrDefault()

            ProductoContratadoByProduct = producto
        End Using
    End Function

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Cargando(True)

        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(Function()
                                            If click_cmbAgencias = True Then
                                                If ((CType(cmbAgencia.SelectedItem, AGENCIA).agencia1)) = 1 Then
                                                    cuenta = txtCuenta.Text
                                                    If (cuenta <> "") Then

                                                        If ExisteCuenta(Integer.Parse(cuenta)) Then
                                                            LlenaCampos()
                                                            buscaApertura(cuenta, 100)
                                                            CargaGridProductos()
                                                            CargaConceptos()
                                                            ActualizaGridProductoConcOper()
                                                        Else
                                                            MessageBox.Show("Not existe la cuenta")
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End Function))
        End If


    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtCuenta_DoubleClick(sender As Object, e As EventArgs) Handles txtCuenta.DoubleClick
        LimpiaCampos()
    End Sub

    Private Sub Cargando(ByVal cargando As Boolean)
        If loading.InvokeRequired Then
            loading.Invoke(New MethodInvoker(Function()
                                                 loading.Visible = cargando
                                                 loading.BackColor = Color.FromArgb(153, 180, 209)
                                                 loading.Refresh()
                                             End Function))

        Else
            loading.Visible = cargando
            loading.BackColor = Color.FromArgb(153, 180, 209)
            loading.Refresh()
        End If


        If btnBuscar.InvokeRequired Then
            btnBuscar.Invoke(New MethodInvoker(Function()
                                                   btnBuscar.Visible = Not cargando
                                                   btnBuscar.Refresh()
                                               End Function))
        Else
            btnBuscar.Visible = Not cargando
            btnBuscar.Refresh()
        End If
    End Sub

    Private Sub txtCuenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCuenta.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCuenta_MouseHover(sender As Object, e As EventArgs) Handles txtCuenta.MouseHover
        Dim tt As ToolTip = New ToolTip()
        tt.SetToolTip(txtCuenta, "Haz doble click para limpiar todos los campos.")
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Cargando(False)
        btnBuscar.Enabled = False
    End Sub

    ''' <summary>
    ''' Busca el tipo de operacion en base a un numero de operacion
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub gridOperaciones_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridOperaciones.CellContentDoubleClick
        Dim num_operacion As Integer = 0
        If (Integer.TryParse(gridOperaciones.Rows(e.RowIndex).Cells(0).Value.ToString(), num_operacion)) Then
            If num_operacion > 0 Then
                ConsultarOperacion(num_operacion)
            End If
        End If
    End Sub

    Private Sub ConsultarOperacion(num_operacion As Integer)
        Dim nTipoOperacion As Integer
        Dim nTipoRetiro As Integer
        Dim nMovimientos As Integer

        'num_operacion = 2024602 '[PRUEBA]

        Dim producto_operacion As DetalleOperacion
        Using contexto As New TICKETEntities
            producto_operacion = (
                    From pc In contexto.PRODUCTO_CONTRATADO
                    Join o In contexto.OPERACION On o.producto_contratado Equals pc.producto_contratado1
                    Join od In contexto.OPERACION_DEFINIDA On od.operacion_definida1 Equals o.operacion_definida
                    Where o.operacion1 = num_operacion And pc.agencia = 1
                    Select New DetalleOperacion With {.linea = o.linea, .operacionDefGlbl = od.operacion_definida_global, .operacion_definida = o.operacion_definida}
            ).FirstOrDefault()



            If producto_operacion IsNot Nothing Then
                Dim od_glbl = producto_operacion.operacionDefGlbl
                If od_glbl > 0 Then
                    Select Case od_glbl
                        Case 100    'Apertura de cuenta
                            nTipoOperacion = 1
                        Case 101    'Apertura de cuenta
                            nTipoOperacion = 29
                        Case 583    'Depósito PME
                            nTipoOperacion = 2
                        Case 589, 559    'Depósito Area Interna, Se agrego la Oper Def Global 559 para "Depositos Devolucion"
                            nTipoOperacion = 27
                        Case 591    'Depósito Area Interna 24 Hrs
                            nTipoOperacion = 27
                        Case 592    'Depósito Area Interna SBF
                            nTipoOperacion = 27
                        Case 590    'Depósito 24 Horas
                            nTipoOperacion = 26
                        Case 65
                            nTipoOperacion = 33
                        Case 83     'Retiro por PME
                            nTipoOperacion = 3  'Retiro
                            nTipoRetiro = 3
                        Case 84     'Retiro recaudacion IDE
                            nTipoOperacion = 3  'Retiro
                            nTipoRetiro = 3
                        Case 89, 59 'Retiro Area Interna, Se agrego la Oper Def Global 59 para "Retiro Devolucion"
                            nTipoOperacion = 28 'Retiro
                            nTipoRetiro = 3
                        Case 87     'Traspaso
                            nTipoOperacion = 4
                        Case 97     'Traspaso
                            nTipoOperacion = 4
                        Case 80     'Retiro por Compra de CD
                            nTipoOperacion = 5
                        Case 580    'Deposito por vencimiento de CD
                            nTipoOperacion = 6
                        Case 587    'Deposito por Traspaso
                            nTipoOperacion = 7
                        Case 597    'Deposito por Transferencia
                            nTipoOperacion = 7
                        Case 602    'Modificación de Time Deposit Harris
                            nTipoOperacion = 9
                        Case 91     'Retiro por Comisión Orden de Pago
                            nTipoOperacion = 10
                        Case 86     'Retiro por Orden de Pago de Otras Divisas
                            nTipoOperacion = 11
                        Case 96     'Comision de Orden de Pago de Otras Divisas
                            nTipoOperacion = 12
                        Case 94     'Consulta de Retiro Especial
                            nTipoOperacion = 13
                        Case 90     'Consulta de Inversión en Time Deposit Harris
                            nTipoOperacion = 14
                        Case 600    'Consulta Depositos de Intereses Devengados Harris
                            nTipoOperacion = 15
                        Case 601    'Consulta Retiros de Intereses Harris
                            nTipoOperacion = 16
                        Case 584    'Consulta de Deposito Especiales
                            nTipoOperacion = 17
                        Case 180    'Consulta de Inversión en TD Overnight
                            nTipoOperacion = 18
                        Case 595    'Consulta de DEPOSITOS DIRECTOS EQUATION LA
                            nTipoOperacion = 19
                        Case 95     'Consulta de RETIROS DIRECTOS EQUATION LA
                            nTipoOperacion = 20
                        Case 603    'Consulta de Retiros de capital Harris
                            nTipoOperacion = 21
                        Case 88     'Consulta de Retiros por cheque devuelto
                            nTipoOperacion = 22
                            nTipoRetiro = 4
                        Case 588    'Consulta de Depositos Salvo Buen Cobro
                            nTipoOperacion = 24
                        Case 81     'Retiro por Orden de Pago
                            nTipoOperacion = 25
                        Case 590    'Depósito 24 Horas
                            nTipoOperacion = 26
                        Case 680    'Consulta de Deposito por Vencimiento de TD Overniht
                            nTipoOperacion = 30
                        Case 560
                            nTipoOperacion = 31
                        Case 60
                            nTipoOperacion = 32
                        Case 52, 53, 54, 56, 57, 58   'Consulta de Retiro TDD, Se agrego la Oper Def Global 58 para "Depositos Devolucion"
                            nTipoOperacion = 34
                        Case 552, 553             'Consulta de Deposito TDD
                            nTipoOperacion = 35
                        Case 55                   'Consulta de Retencion de Fondos
                            nTipoOperacion = 36
                        Case Else
                            MessageBox.Show("Ticket inválido.", "Dato Incorrecto")
                    End Select
                Else
                    Dim od = producto_operacion.operacion_definida

                    Select Case od
                        Case 100              'Apertura de cuenta
                            nTipoOperacion = 8
                        Case 1010             'KRET CHEQUE EMITIDO
                            nTipoOperacion = 8
                        Case 1025             'KRET INICIO DE TERM DEPOSITS
                            nTipoOperacion = 8
                        Case 1035             'KRET TRANSFERENCIAS
                            nTipoOperacion = 8
                        Case 1036             'KRET COMISIÓN POR TRANSFERENCIA
                            nTipoOperacion = 8
                        Case 1070             'KRET TRANSFERENCIA ENTRE BANCOS
                            nTipoOperacion = 8
                        Case 1080             'KRET TRASPASO ENTRE AGENCIAS DEBITOS GRA
                            nTipoOperacion = 8
                        Case 1191             'KRET RETIROS CUENTA DE CLIENTES
                            nTipoOperacion = 8
                        Case 1250             'KRET VENCIMIENTO TERM DEPOSIT VS CUENTA
                            nTipoOperacion = 8
                        Case 1260             'KRET GASTOS
                            nTipoOperacion = 8
                        Case 1271             'KRET COMISION POR TRANSFERENCIA
                            nTipoOperacion = 8
                        Case 1326             'KRET CARGOS SALDO PROM. DEBAJO DEL PROM.
                            nTipoOperacion = 8
                        Case 1515             'KDEP INGRESOS
                            nTipoOperacion = 8
                        Case 1525             'KDEP DEPOSITO CUENTAS DE CLIENTE
                            nTipoOperacion = 8
                        Case 1530             'KDEP ABONO PARA FONDEO CONTRA BANCOS
                            nTipoOperacion = 8
                        Case 1535             'KDEP ABONO POR TRANSFERENCIA/FED.RESERV.
                            nTipoOperacion = 8
                        Case 1580             'KDEP COMISION GANADA POR TRASPASO(BANCOS
                            nTipoOperacion = 8
                        Case 1581             'KDEP CONFORMIDAD
                            nTipoOperacion = 8
                        Case 1590             'KDEP ABONO TEMPORAL
                            nTipoOperacion = 8
                        Case 1595             'KDEP CANCELACIÓN DE TERM DEPOSIT
                            nTipoOperacion = 8
                        Case 1750             'KDEP VENCIMIENTO DE TERM DEPOSIT
                            nTipoOperacion = 8
                        Case 1775             'KDEP ABONO AL CLIENTE POR CHQ. DEVUELTO
                            nTipoOperacion = 8
                        Case 1921             'KDEP INTERESES PAGADOS A CTA. DEL CLIENT
                            nTipoOperacion = 8
                        Case 8595             'DEPOSITO DIRECTO EQUATION LA
                            nTipoOperacion = 8
                        Case 8095             'RETIRO DIRECTO EQUATION LA
                            nTipoOperacion = 8
                        Case 8060             'RETIRO RECAUDACION IMPUESTO IDE -BG
                            nTipoOperacion = 8
                    End Select

                End If

                Dim linea = producto_operacion.linea

                Select Case nTipoOperacion
                    Case 1
                        ConsultaApertura.ShowDialog()
                    Case 2
                        ConsultaDep.ConsultaDep(num_operacion, cuenta)
                        ConsultaDep.ShowDialog()
                    Case 3
                        Consultaret.Consultaret(num_operacion, cuenta, linea)
                        Consultaret.ShowDialog()
                    Case 4
                        ConsultaTraspasos.ConsultaTraspasos(num_operacion, cuenta)
                        ConsultaTraspasos.ShowDialog()
                    Case 5
                        MessageBox.Show("Formulario en construccion")
                        ConsultaCD.Show()
                    Case 6
                        MessageBox.Show("Formulario en construccion")
                        ConsultaDepCD.Show()
                    Case 7
                        MessageBox.Show("Formulario en construccion")
                        ConsultaDepTrasp.Show()
                    Case 8
                        MessageBox.Show("Formulario en construccion")
                        ConsultaKapiti.Show()
                    Case 10
                        MessageBox.Show("Formulario en construccion")
                        ConsultaRetCom.Show()
                    Case 11
                        MessageBox.Show("Formulario en construccion")
                        RetOrdPagDiv.Show()
                    Case 12
                        MessageBox.Show("Formulario en construccion")
                        ComOrdPag.Show()
                    Case 13
                        MessageBox.Show("Formulario en construccion")
                        ConRetEsp.Show()
                    Case 17
                        MessageBox.Show("Formulario en construccion")
                        ConsDepEsp.Show()
                    Case 18
                        MessageBox.Show("Formulario en construccion")
                        ConsultaTDOvernight.Show()
                    Case 19     'Consulta de DEPOSITOS DIRECTOS EQUATION LA
                        MessageBox.Show("Formulario en construccion")
                        nMovimientos = 1
                        ConsRetDepDIRECTOS.Show()
                    Case 20     'Consulta de RETIROS DIRECTOS EQUATION LA
                        MessageBox.Show("Formulario en construccion")
                        nMovimientos = 0
                        ConsRetDepDIRECTOS.ShowDialog()
                    Case 22     'Consulta de Retiros por devolucion de cheques
                        MessageBox.Show("Formulario en construccion")
                        consultaretpdcheq.ShowDialog()
                    Case 24     'Consulta de Debitos Salvo Buen Cobro
                        MessageBox.Show("Formulario en construccion")
                        ConsultaDepSBF.Show()
                    Case 25     'Consulta de Retiros por Orden de Pago
                        'If MsgBox("Desea Consultar el Retiro para MT100 (Presione Si) o para MT103 (Presione No).", vbYesNo, "Selección") = vbYes Then
                        '    ConsultaRetOrdPago.Show
                        'Else
                        MessageBox.Show("Formulario en construccion")
                        ConsultaRetOrdPagoMT103.Show()
                'End If
                    Case 26
                        MessageBox.Show("Formulario en construccion")
                        ConsultaDep24Horas.Show()
                    Case 27
                        ConsultaDepAreaInterna.ConsultaDepAreaInterna(num_operacion, cuenta)
                        ConsultaDepAreaInterna.ShowDialog()
                    Case 28
                        ConsultaRetAreaInterna.ConsultaRetAreaInterna(num_operacion, cuenta, linea)
                        ConsultaRetAreaInterna.Show()
                    Case 29
                        MessageBox.Show("Formulario en construccion")
                        ConsultaApTraspasada.Show()
                    Case 30
                        MessageBox.Show("Formulario en construccion")
                        ConsVenTDOvernight.Show()
                    Case 31
                        MessageBox.Show("Formulario en construccion")
                        ConsultaDepDirecto.Show()
                    Case 32
                        MessageBox.Show("Formulario en construccion")
                        ConsultaRetDirecto.Show()
                    Case 33
                        MessageBox.Show("Formulario en construccion")
                        frmConsRetAclaracion.Show()
                    Case 34
                        ConsultaRetDepTDD.ConsultaRetDepTDD(num_operacion, 2, cuenta)
                        ConsultaRetDepTDD.ShowDialog()
                    Case 35
                        ConsultaRetDepTDD.ConsultaRetDepTDD(num_operacion, 1, cuenta)
                        ConsultaRetDepTDD.ShowDialog()
                    Case 36
                        MessageBox.Show("Formulario en construccion")
                        ConsultaReten.Show()

                End Select

            Else
                MessageBox.Show("No se encuentra el Número de Ticket.")
            End If

        End Using
    End Sub

    Private Function ProductoContratadoByOperacion(num_operacion As Integer) As PRODUCTO_CONTRATADO
        Using contexto As New TICKETEntities
            ProductoContratadoByOperacion = (
                    From pc In contexto.PRODUCTO_CONTRATADO
                    Join o In contexto.OPERACION On o.producto_contratado Equals pc.producto_contratado1
                    Join od In contexto.OPERACION_DEFINIDA On od.operacion_definida1 Equals o.operacion_definida
                    Where o.operacion1 = num_operacion And pc.agencia = 1
                    Select pc
            ).FirstOrDefault()
        End Using
    End Function

    Private Sub gridOperaciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridOperaciones.CellContentClick

    End Sub

    Public Class DetalleOperacion
        Private _operacionDefinida As Short
        Public Property operacion_definida() As Short
            Get
                Return _operacionDefinida
            End Get
            Set(ByVal value As Short)
                _operacionDefinida = value
            End Set
        End Property

        Private _operacionDefinidaGlobal As Short
        Public Property operacionDefGlbl() As Short
            Get
                Return _operacionDefinidaGlobal
            End Get
            Set(ByVal value As Short)
                _operacionDefinidaGlobal = value
            End Set
        End Property

        Private _linea As Integer
        Public Property linea() As Integer
            Get
                Return _linea
            End Get
            Set(ByVal value As Integer)
                _linea = value
            End Set
        End Property
    End Class

End Class