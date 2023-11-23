Imports System.Threading
Public Class frmRetirosOrdenPagoMT103
    Private gAgencia As Integer = 1
    Private GnProductoContratado As Long
    Private la_TitulosProducto(4) As String
    Private objDatasource As New Datasource
    Private Const mn_OpDefinidaGlob = 81
    Private mn_Monto As Decimal
    Private mn_Comision As Long
    Private mn_TipoComision As Byte
    Private mn_OpDefinida As Integer
    Private Aplicacion As String = "TicketComplementario"
    Private nRespuesta As Long
    Private sIdBanca As String
    Private NumAplicacion As Integer = 1
    Private objModPErmisos As modPermisos = New modPermisos()
    Private la_Buffer As New List(Of PermisoRemoto)
    Private estatus As Long = 6
    Private status As Integer
    Private iFormularioOrigen As Integer = 0
    Private iTicketGenerado As Integer = 0
    Private iUsuarioCaptura As Integer = 0
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(MenuOpcion As Integer)
        Me.New()
        iFormularioOrigen = MenuOpcion
    End Sub
    Private Sub frmRetirosOrdenPagoMT103_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Thread.CurrentThread.CurrentCulture.Name = "en-US" Then
            dtpApertura.CustomFormat = "MM-dd-yyyy"
            dtpFechaCaptura.CustomFormat = "MM-dd-yyyy"
            dtpFechaOperacion.CustomFormat = "MM-dd-yyyy"
        ElseIf Thread.CurrentThread.CurrentCulture.Name = "es-MX" Then
            dtpApertura.CustomFormat = "dd-MM-yyyy"
            dtpFechaCaptura.CustomFormat = "dd-MM-yyyy"
            dtpFechaOperacion.CustomFormat = "dd-MM-yyyy"
        End If
        BuscarOperacionesPendientes()
        Me.Size = New Size(1170, 560)
        If iFormularioOrigen = 1 Then
            BloquearCampos()
            'cmdGuardar.Text = "Guardar ticket"
            'Me.Size = New Size(880, 560)
        ElseIf iFormularioOrigen = 2 Then
            Me.Text = "Validar retiros por orden de pago MT103"
            GroupBox1.Enabled = False
            GroupBox2.Enabled = False
            GroupBox3.Enabled = False
            GroupBox4.Enabled = False
            Referencia.Enabled = False
            cmdActualizar.Text = "Corregir"
            cmdGuardar.Text = "Validar ticket"
            'Me.Size = New Size(1170, 560)
        End If
        'txtOperacion.Enabled = True
        txtFunc.Enabled = True
        'txtMonto.Text = Me.Width
        'txtOperacion.Text = Me.Height
    End Sub
    Private Sub TxtABABI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtABABI.KeyPress
        If iFormularioOrigen = 1 Then
            If TxtABABI.Text <> "" Then
                TxtABABC.Enabled = False
                TxtCableCBC.Enabled = False
            Else
                TxtABABC.Enabled = True
                TxtCableCBC.Enabled = True
            End If
        End If
    End Sub
    Private Sub TxtABABC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtABABC.KeyPress
        If iFormularioOrigen = 1 Then
            If TxtABABC.Text <> "" Then
                TxtABABI.Enabled = False
                TxtCableCBI.Enabled = False
            Else
                TxtABABI.Enabled = True
                TxtCableCBI.Enabled = True
            End If
        End If
    End Sub
    Private Sub txtCuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuenta.KeyPress
        Try
            LimpiarCampos()
            If AscW(e.KeyChar) = CInt(Keys.Enter) Then
                If Trim(txtCuenta.Text) <> "" Then
                    ConsultarInformacion()
                    DesbloquearCampos()
                Else
                    MsgBox("Se requiere la cuenta para iniciar la búsqueda")
                End If
            End If
        Catch ex As Exception
            MsgBox("No se tiene información de la cuenta")
        End Try
    End Sub
    Private Sub txtOperacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOperacion.KeyPress
        Try
            If AscW(e.KeyChar) = CInt(Keys.Enter) Then
                If Trim(txtOperacion.Text) <> "" Then
                    BuscarTicketyLlenar(1)
                    ConsultarInformacion()
                    BuscarTicketyLlenar(2)
                    DesbloquearCampos()
                Else
                    MsgBox("Se requiere la cuenta para iniciar la búsqueda")
                End If
            End If
        Catch ex As Exception
            MsgBox("No se tiene información de la cuenta")
        End Try
    End Sub
    Private Sub TxtABABI_LostFocus(sender As Object, e As EventArgs) Handles TxtABABI.LostFocus
        Try
            If iFormularioOrigen = 1 Then
                encuentraClave(Trim(TxtABABI.Text), gAgencia, "bc")
            End If
        Catch ex As Exception
            'MsgBox("No se tiene información de la cuenta")
        End Try
    End Sub
    Private Sub TxtABABC_LostFocus(sender As Object, e As EventArgs) Handles TxtABABC.LostFocus
        Try
            If iFormularioOrigen = 1 Then
                encuentraClave(Trim(TxtABABC.Text), gAgencia, "bc")
            End If
        Catch ex As Exception
            'MsgBox("No se tiene información de la cuenta")
        End Try
    End Sub
    Private Sub TxtFunc_LostFocus(sender As Object, e As EventArgs) Handles txtFunc.LostFocus
        Try
            Dim dtRespConsulta As DataTable
            If iFormularioOrigen = 1 Then
                cmbFuncionario.DataSource = Nothing
                gs_Sql = "Select funcionario, rtrim(nombre_funcionario) + ' ' + rtrim(apellido_paterno) + ' ' + rtrim(apellido_materno) nombre From FUNCIONARIOS..FUNCIONARIO Where numero_funcionario = " & txtFunc.Text
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                cmbFuncionario.ValueMember = "funcionario"
                cmbFuncionario.DisplayMember = "nombre"
                cmbFuncionario.DataSource = dtRespConsulta
                cmbFuncionario.SelectedIndex = 0
            Else
                txtFunc.Text = ""
                cmbFuncionario.DataSource = Nothing
                cmbFuncionario.Text = ""
            End If
        Catch ex As Exception
            'MsgBox("No se tiene información de la cuenta")
        End Try
    End Sub
    '-------------------------------------------------------------------
    'Calcula el saldo disponible para una cuenta eje
    '-------------------------------------------------------------------
    Function ObtenSaldo() As Decimal
        Dim dtRespConsulta As DataTable
        Dim nSaldo As Decimal

        'ProcessMessage "Calculando Saldo..."
        nSaldo = 0

        ' SALDO QUE BAJA DE EQUATION AL INICIO DE DIA
        gs_Sql = "select valor_concepto from CONCEPTO C, CONCEPTO_DEFINIDO CD"
        gs_Sql = gs_Sql & " where producto_contratado= " & GnProductoContratado
        gs_Sql = gs_Sql & " and CD.concepto_definido= C.concepto_definido"
        gs_Sql = gs_Sql & " and CD.concepto_definido_global =5"
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta.Rows(0).Item(0).ToString() <> "" Then
            nSaldo = Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        'Depositos fecha valor hoy ya validados y no cancelados
        'incluyendo depositos por vencimiento
        'cpb 7-junio-2004 Anexo de Operaciones de Tarjeta de Debito (552, 553)
        'cpb 13-octubre-2004 Anexo de Operaciones para la Operatoria por Sucursales (559)
        gs_Sql = "select sum(monto_operacion) from OPERACION OP, OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & " where OP.producto_contratado= " & GnProductoContratado
        gs_Sql = gs_Sql & " and OP.fecha_operacion = '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion in (2,3,4,5)"
        gs_Sql = gs_Sql & " and OP.operacion_definida= OD.operacion_definida"
        gs_Sql = gs_Sql & " and operacion_definida_global"
        gs_Sql = gs_Sql & " in (560, 580, 583, 584, 585, 587, 597,588, 589, 590, 591, 592, 680,"
        gs_Sql = gs_Sql & " 552, 553, 559)"
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbExecQuery gs_Sql
        'dbGetRecord
        If dtRespConsulta.Rows(0).Item(0).ToString() <> "" Then
            nSaldo = nSaldo + Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        'Todos los retiros (menos orden de pago, td, over's) fecha valor hoy que no esten cancelados
        'cpb 7-junio-2004 Anexo de Operaciones de Tarjeta de Debito
        'cpb 13-octubre-2004 Anexo de Operaciones para la Operatoria por Sucursales (58, 59)
        gs_Sql = "select sum(monto_operacion) from OPERACION OP, OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & " where OP.producto_contratado= " & GnProductoContratado
        gs_Sql = gs_Sql & " and OP.fecha_operacion >= '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion <> 250"
        gs_Sql = gs_Sql & " and OP.operacion_definida= OD.operacion_definida"
        gs_Sql = gs_Sql & " and operacion_definida_global in (60, 65, 83,84, 85, 86, 87, 91, 94, 96, 97, 88, 89,"
        'gs_sql = gs_sql & " 52, 53, 54, 55, 56, 57)"  'se quito retenciones (55)
        gs_Sql = gs_Sql & " 52, 53, 54, 56, 57, 58, 59)"
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbExecQuery gs_Sql
        'dbGetRecord
        If dtRespConsulta.Rows(0).Item(0).ToString() <> "" Then
            nSaldo = nSaldo - Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        'Algun retiro que no se haya validado a tiempo por lo tanto sería fecha valor anterior y estaría en status 0 o 1, los unicos retiros que se validan son los de
        'la cuenta mercury en agencias y las compras de TD cuando son renovaciones
        'cpb 7-junio-2004 Anexo de Operaciones de Tarjeta de Debito
        'cpb 13-octubre-2004 Anexo de Operaciones para la Operatoria por Sucursales (58, 59)
        gs_Sql = "select sum(monto_operacion) from OPERACION OP, OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & " where OP.producto_contratado= " & GnProductoContratado
        gs_Sql = gs_Sql & " and OP.fecha_operacion < '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion in (0,1,220)"
        gs_Sql = gs_Sql & " and OP.operacion_definida= OD.operacion_definida"
        gs_Sql = gs_Sql & " and operacion_definida_global"
        gs_Sql = gs_Sql & " in (80, 83, 85, 86, 87, 91, 94, 96, 97, 88, 89, 180,"
        'gs_sql = gs_sql & " 52, 53, 54, 55, 56, 57)" 'se quito retenciones (55)
        gs_Sql = gs_Sql & " 52, 53, 54, 56, 57, 58, 59)"
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbExecQuery gs_Sql
        'dbGetRecord
        If dtRespConsulta.Rows(0).Item(0).ToString() <> "" Then
            nSaldo = nSaldo - Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        'Todos los retiros por orden de pago fecha valor o mañana, que no esten cancelados y no sean parcialmente/sujetos a recepción
        gs_Sql = "select sum(monto_operacion) from OPERACION OP, OPERACION_DEFINIDA OD, RETIRO_ORDEN_PAGO RO"
        gs_Sql = gs_Sql & " where OP.producto_contratado= " & GnProductoContratado
        gs_Sql = gs_Sql & " and OP.fecha_operacion >= '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion <> 250"
        gs_Sql = gs_Sql & " and OP.operacion= RO.operacion"
        gs_Sql = gs_Sql & " and OP.operacion_definida= OD.operacion_definida"
        gs_Sql = gs_Sql & " and operacion_definida_global = 81"
        gs_Sql = gs_Sql & " and RO.sujeto_a_recepcion = 0"
        gs_Sql = gs_Sql & " and RO.parcialmente_sujeto = 0"
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbExecQuery gs_Sql
        'dbGetRecord
        If dtRespConsulta.Rows(0).Item(0).ToString() <> "" Then
            nSaldo = nSaldo - Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        'Todos los retiros por orden de pago fecha anterior y que no fue validado, que no esten cancelados y no sean parcialmente/sujetos a recepción
        gs_Sql = "select sum(monto_operacion) from OPERACION OP, OPERACION_DEFINIDA OD, RETIRO_ORDEN_PAGO RO"
        gs_Sql = gs_Sql & " where OP.producto_contratado= " & GnProductoContratado
        gs_Sql = gs_Sql & " and OP.fecha_operacion < '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion in (0,1)"
        gs_Sql = gs_Sql & " and OP.operacion= RO.operacion"
        gs_Sql = gs_Sql & " and OP.operacion_definida= OD.operacion_definida"
        gs_Sql = gs_Sql & " and operacion_definida_global = 81"
        gs_Sql = gs_Sql & " and RO.sujeto_a_recepcion = 0"
        gs_Sql = gs_Sql & " and RO.parcialmente_sujeto = 0"
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbExecQuery gs_Sql
        'dbGetRecord
        If dtRespConsulta.Rows(0).Item(0).ToString() <> "" Then
            nSaldo = nSaldo - Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        'Retiros por compra de TD que no son de renovacion, de fechas valor hoy o futuras y no sujetos a recepcion
        gs_Sql = "select sum(monto_operacion) from OPERACION OP, COMPRA_CD CC, OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & " where OP.producto_contratado= " & GnProductoContratado
        gs_Sql = gs_Sql & " and OP.fecha_operacion >= '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion <> 250"
        gs_Sql = gs_Sql & " and status_operacion >= 0"
        gs_Sql = gs_Sql & " and OP.operacion_definida= OD.operacion_definida"
        gs_Sql = gs_Sql & " and operacion_definida_global = 80"
        gs_Sql = gs_Sql & " and CC.renovacion = 2"
        gs_Sql = gs_Sql & " and CC.origen not in (1,7) " '  no SUJETO A RECEPCION DE FONDOS
        gs_Sql = gs_Sql & " and OP.operacion = CC.operacion "
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbExecQuery gs_Sql
        'dbGetRecord
        If dtRespConsulta.Rows(0).Item(0).ToString() <> "" Then
            nSaldo = nSaldo - Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        'TRAE LOS TD QUE SON DE RENOVACION Y FECHA DE OPERACION HOY, son solo las operaciones origen que son
        'de renovación por lo tanto tienen producto_contratado a renovar igual a nulo
        'gs_Sql = "select sum(monto_operacion) from OPERACION OP, COMPRA_CD CC, OPERACION_DEFINIDA OD, "
        gs_Sql = "select sum(monto_operacion) from OPERACION OP, COMPRA_CD CC, OPERACION_DEFINIDA OD "
        'gs_Sql = sSql & "  CERTIFICADO_DEPOSITO CD, PRODUCTO_CONTRATADO PC"
        gs_Sql = gs_Sql & " where OP.producto_contratado= " & GnProductoContratado
        gs_Sql = gs_Sql & " and OP.fecha_operacion = '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion <> 250"
        gs_Sql = gs_Sql & " and status_operacion >= 0"
        gs_Sql = gs_Sql & " and OP.operacion_definida= OD.operacion_definida"
        gs_Sql = gs_Sql & " and operacion_definida_global = 80"
        gs_Sql = gs_Sql & " and CC.renovacion <> 2"
        gs_Sql = gs_Sql & " and OP.operacion = CC.operacion "
        gs_Sql = gs_Sql & " and CC.origen not in (1,7) " ' SUJETO A RECEPCION DE FONDOS
        'gs_Sql = sSql & " and CD.operacion = OP.operacion"
        'gs_Sql = sSql & " and CD.producto_contratado  = PC.producto_contratado"
        'gs_Sql = sSql & " and CD.producto_contratado_a_renovar = null"
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbExecQuery gs_Sql
        'dbGetRecord
        If dtRespConsulta.Rows(0).Item(0).ToString() <> "" Then
            nSaldo = nSaldo - Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        'TRAE LOS TD QUE SON DE RENOVACION Y FECHA DE OPERACION futura solo se revisa el estatus 2 para diferenciarlas de las de futuros
        'que son renovacion de una compra, son solo las operaciones origen que son
        'de renovación por lo tanto tienen producto_contratado a renovar igual a nulo
        'gs_Sql = "select sum(monto_operacion) from OPERACION OP, COMPRA_CD CC, OPERACION_DEFINIDA OD, "
        gs_Sql = "select sum(monto_operacion) from OPERACION OP, COMPRA_CD CC, OPERACION_DEFINIDA OD "
        'gs_Sql = gs_Sql & "  CERTIFICADO_DEPOSITO CD, PRODUCTO_CONTRATADO PC"
        gs_Sql = gs_Sql & " where OP.producto_contratado= " & GnProductoContratado
        gs_Sql = gs_Sql & " and OP.fecha_operacion > '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion <> 250"
        gs_Sql = gs_Sql & " and status_operacion >= 2"
        gs_Sql = gs_Sql & " and OP.operacion_definida= OD.operacion_definida"
        gs_Sql = gs_Sql & " and operacion_definida_global = 80"
        gs_Sql = gs_Sql & " and CC.renovacion <> 2"
        gs_Sql = gs_Sql & " and OP.operacion = CC.operacion "
        gs_Sql = gs_Sql & " and CC.origen not in (1,7) " ' SUJETO A RECEPCION DE FONDOS
        'gs_Sql = gs_Sql & " and CD.operacion = OP.operacion"
        'gs_Sql = gs_Sql & " and CD.producto_contratado  = PC.producto_contratado"
        'gs_Sql = gs_Sql & " and CD.producto_contratado_a_renovar = null"
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbExecQuery gs_Sql
        'dbGetRecord
        If dtRespConsulta.Rows(0).Item(0).ToString() <> "" Then
            nSaldo = nSaldo - Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        'TD overnight
        gs_Sql = "  select  sum(monto_operacion)"
        gs_Sql = gs_Sql & " from OPERACION OP, COMPRA_TD_OVERNIGHT C, OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & "  where OP.producto_contratado = " & GnProductoContratado
        gs_Sql = gs_Sql & "  and OP.fecha_operacion = '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion <> 250"
        gs_Sql = gs_Sql & " and OP.operacion_definida = OD.operacion_definida"
        gs_Sql = gs_Sql & " and OD.operacion_definida_global = 180"
        gs_Sql = gs_Sql & " and OP.operacion = C.operacion"
        gs_Sql = gs_Sql & " and C.origen not in (1,7) " ' SUJETO A RECEPCION DE FONDOS
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbExecQuery gs_Sql
        'dbGetRecord
        If dtRespConsulta.Rows(0).Item(0).ToString() <> "" Then
            nSaldo = nSaldo - Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        'TD's Overnight validados a futuros
        gs_Sql = "select sum(monto_operacion) from OPERACION OP, COMPRA_TD_OVERNIGHT C, "
        gs_Sql = gs_Sql & "OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & " where OP.producto_contratado = " & GnProductoContratado
        gs_Sql = gs_Sql & " and OP.fecha_operacion > '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion <> 250"
        gs_Sql = gs_Sql & " and status_operacion >= 2"
        gs_Sql = gs_Sql & " and OP.operacion_definida = OD.operacion_definida"
        gs_Sql = gs_Sql & " and OD.operacion_definida_global = 180"
        gs_Sql = gs_Sql & " and OP.operacion = C.operacion"
        gs_Sql = gs_Sql & " and C.origen not in (1,7)" 'Sujeto a Recepción de Fondos
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbExecQuery gs_Sql
        'dbGetRecord
        If dtRespConsulta.Rows(0).Item(0).ToString() <> "" Then
            nSaldo = nSaldo - Math.Round((dtRespConsulta.Rows(0).Item(0)), 4)
        End If
        'dbEndQuery

        'Operaciónes con tarjeta de débito que se reporten por concepto de Floating
        gs_Sql = "Select Sum(FL.monto) From Transferencia.FLOATING FL, TARJETA_DEBITO TD,"
        gs_Sql = gs_Sql & " PRODUCTO_CONTRATADO PC, PRODUCTO_CONTRATADO PCT where"
        gs_Sql = gs_Sql & " PC.producto_contratado =" & GnProductoContratado
        gs_Sql = gs_Sql & " and PC.cuenta_cliente = PCT.cuenta_cliente"
        gs_Sql = gs_Sql & " and PCT.producto=8017 and PCT.status_producto <>250"
        gs_Sql = gs_Sql & " and PCT.producto_contratado = TD.producto_contratado"
        gs_Sql = gs_Sql & " and FL.numero_tarjeta = TD.tarjeta"
        'dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql) '------- Duda
        ''dbExecQuery gs_Sql
        ''dbGetRecord
        'If dtRespConsulta.Rows(0).Item(0).ToString() <> "" Then'------- Duda
        '    nSaldo = nSaldo - Val(dtRespConsulta.Rows(0).Item(0))'------- Duda
        'End If'------- Duda
        'dbEndQuery

        'Operaciónes que se bajan directamente de kapiti retiro
        gs_Sql = "select sum(monto_operacion) from OPERACION OP, OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & " where OP.producto_contratado= " & GnProductoContratado
        gs_Sql = gs_Sql & " and OP.fecha_operacion = '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion <> 250"
        gs_Sql = gs_Sql & " and OP.operacion_definida= OD.operacion_definida"
        gs_Sql = gs_Sql & " and operacion_definida_global =  95"
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbExecQuery gs_Sql
        'dbGetRecord
        If dtRespConsulta.Rows(0).Item(0).ToString() <> "" Then
            nSaldo = nSaldo - Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        'Operaciónes que se bajan directamente de kapiti depósito
        gs_Sql = "select sum(monto_operacion) from OPERACION OP, OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & " where OP.producto_contratado= " & GnProductoContratado
        gs_Sql = gs_Sql & " and OP.fecha_operacion = '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion <> 250"
        gs_Sql = gs_Sql & " and OP.operacion_definida= OD.operacion_definida"
        gs_Sql = gs_Sql & " and operacion_definida_global =  595"
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbExecQuery gs_Sql
        'dbGetRecord
        If dtRespConsulta.Rows(0).Item(0).ToString() <> "" Then
            nSaldo = nSaldo + Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        'Suma de Hold's
        gs_Sql = "Select sum(valor_concepto) from CONCEPTO CH, CONCEPTO_DEFINIDO CDH, PRODUCTO_CONTRATADO PCH, "
        gs_Sql = gs_Sql & "STATUS_PRODUCTO SPH, PRODUCTO PCTA, PRODUCTO_CONTRATADO PCCTA "
        gs_Sql = gs_Sql & "where PCH.producto_contratado = CH.producto_contratado and PCH.producto = CDH.producto and "
        gs_Sql = gs_Sql & "PCH.agencia = CDH.agencia and CDH.concepto_definido= CH.concepto_definido and "
        gs_Sql = gs_Sql & "CDH.concepto_definido_global in(10, 20) "  'Monto del Hold
        gs_Sql = gs_Sql & "and SPH.status_producto = PCH.status_producto and SPH.producto = PCH.producto and "
        gs_Sql = gs_Sql & "SPH.agencia = PCH.agencia and SPH.status_producto_global in(2, 7) " 'Holds Activos LockBox y TDD
        gs_Sql = gs_Sql & "and PCCTA.agencia = PCH.agencia and PCCTA.cuenta_cliente = PCH.cuenta_cliente and "
        gs_Sql = gs_Sql & "PCTA.producto = PCCTA.producto and PCTA.agencia = PCCTA.agencia and "
        gs_Sql = gs_Sql & "PCTA.producto_global = 9 "       'Cuenta Eje
        gs_Sql = gs_Sql & "and PCCTA.producto_contratado= " & GnProductoContratado
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbExecQuery gs_Sql
        'dbGetRecord
        If dtRespConsulta.Rows(0).Item(0).ToString() <> "" Then
            'Resta el monto del Hold al saldo
            nSaldo = nSaldo - Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        ObtenSaldo = nSaldo
        'ProcessMessage "OFF"
    End Function
    '---------------------------------------------------------------------------
    'Calcula el saldo disponible para una cuenta eje de Depósitos comprometidos
    '---------------------------------------------------------------------------
    Function ObtenSaldoDepCom() As Decimal
        Dim dtRespConsulta As DataTable
        Dim nSaldoDep As Decimal

        If iFormularioOrigen = 1 Then
            MsgBox("Calculando Saldo de Depósitos comprometidos...")
        End If
        nSaldoDep = 0
        'depositos fecha valor hoy NO validados
        'cpb 7-junio-2004 Anexo de Operaciones de Tarjeta de Debito (552, 553)
        'cpb 13-octubre-2004 Anexo de Operaciones para la Operatoria por Sucursales (559)
        gs_Sql = "select "
        gs_Sql = gs_Sql & " sum(monto_operacion) "
        gs_Sql = gs_Sql & " from "
        gs_Sql = gs_Sql & " OPERACION OP, "
        gs_Sql = gs_Sql & " OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & " where "
        gs_Sql = gs_Sql & " OP.producto_contratado= " & GnProductoContratado
        gs_Sql = gs_Sql & " and OP.fecha_operacion = '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion in (1,220)"
        gs_Sql = gs_Sql & " and OP.operacion_definida= OD.operacion_definida"
        gs_Sql = gs_Sql & " and OD.operacion_definida_global in (583,589,590,591,"
        gs_Sql = gs_Sql & " 552, 553, 559)"
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbExecQuery gs_Sql
        'dbGetRecord
        If dtRespConsulta.Rows(0).Item(0).ToString() <> "" Then
            nSaldoDep = Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery
        ObtenSaldoDepCom = nSaldoDep
        'ProcessMessage "OFF"
        If iFormularioOrigen = 1 Then
            MsgBox("Calculo terminado...")
        End If
    End Function

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        If iFormularioOrigen = 1 Then
            If txtOperacion.Text = "" Then
                GuardarTicket()
                iUsuarioCaptura = userId
            Else
                MsgBox("Ya tienes un ticket asignado : " & txtOperacion.Text)
            End If
        ElseIf iFormularioOrigen = 2 Then
            If MsgBox("¿Desea validar la operación " & txtOperacion.Text & "?", vbYesNo + vbQuestion) = vbNo Then
                Exit Sub
            End If
            If txtOperacion.Text <> "" Then
                If iUsuarioCaptura <> userId Then
                    iTicketGenerado = txtOperacion.Text
                    objDatasource.insertar(GuardarDatosVista())
                    ValidarOperacion()
                    LimpiarCampos()
                    txtOperacion.Text = ""
                    txtCuenta.Text = ""
                Else
                    MsgBox("No se puede validar una operación capturada por el mismo usuario")
                End If
            Else
                MsgBox("Requieres indicar un ticket")
            End If
        End If
        BuscarOperacionesPendientes()
        'Llama a la Pantalla de Compra de Time Deposit
        'If lb_StatusOpera.CapturaTD = True Then
        '    If MsgBox("¿Desea concertar la compra de un Time Deposit en este momento?", vbQuestion + vbYesNo, "Compra de Time Deposit") = vbYes Then
        '        Unload Me
        '        frmConCliente.cmdCD_Click
        '    End If
        'End If
        'cmdValidar.Enabled = True
        'TxtABABC.Enabled = True
        'TxtCableCBC.Enabled = True
    End Sub
    Private Function DatosCorrectos() As Boolean
        Dim dtRespConsulta As DataTable
        DatosCorrectos = False

        If CDate(gs_HoraSistema) > ValorParametroHora(mn_OpDefinidaGlob, "CAPTURA", 2) Then
            If dtpFechaOperacion.Value = dtpFechaCaptura.Value Then 'If CDate(txtFechaOperacion.text) = CDate(FechaY2K(txtFechaCaptura)) Then
                'If MsgBox("La hora limite para retiros ya paso. ¿Desea realizar la operación con fecha valor hoy?", vbYesNo + vbQuestion, "Fecha de Operacion") = vbYes Then
                '    If PideAutorizacion("AHORAOPERA", Trim(txtCuenta.Text), mn_OpDefinidaGlob, CCur(txtMonto.Text)) = False Then
                '        cmdCancelar.Caption = "&Salir"
                '        cmdGuardar.Visible = False
                '        If cmdCancelar.Enabled And cmdCancelar.Visible Then
                '            cmdCancelar.SetFocus
                '        End If
                '        Exit Function
                '    End If
                'Else
                '    MsgBox("La hora limite para retiros ya paso, sólo se puede realizar la operación con password.", vbInformation, "Hora Invalida...")
                '    cmdCancelar.Caption = "&Salir"
                '    cmdGuardar.Visible = False
                '    If cmdCancelar.Enabled And cmdCancelar.Visible Then
                '        cmdCancelar.SetFocus
                '    End If
                '    Exit Function
                'End If
                MsgBox("La hora limite para retiros ya paso.")
            End If
        End If

        'Validando fecha
        If Trim(dtpFechaOperacion.Value).ToString() = "" Then
            MsgBox("Es necesaria la Fecha de operacion.", vbInformation, "Dato Faltante")
            'txtFechaOperacion.text = ""
            If dtpFechaOperacion.Enabled And dtpFechaOperacion.Visible Then
                dtpFechaOperacion.Focus()
            End If
            Exit Function
        End If

        'Si no se capturó el monto
        If Trim(txtFunc.Text) = "" Or cmbFuncionario.Text = "" Then
            MsgBox("Es necesario que especifique el funcionario.", vbInformation, "Dato Faltante")
            If txtFunc.Enabled And txtFunc.Visible Then
                txtFunc.Focus()
            End If
            Exit Function
        End If

        'Si no se capturó el monto
        If Trim(txtMonto.Text) = "" Or Not IsNumeric(txtMonto.Text) Then
            MsgBox("Es necesario que especifique el 'Monto'.", vbInformation, "Dato Faltante")
            If txtMonto.Enabled And txtMonto.Visible Then
                txtMonto.Focus()
            End If
            Exit Function
        End If

        'Si el monto es cero
        If Decimal.Parse(txtMonto.Text) = 0 Then
            MsgBox("El 'Monto' debe ser mayor a cero.", vbInformation, "Dato Erroneo")
            If txtMonto.Enabled And txtMonto.Visible Then
                txtMonto.Focus()
            End If
            Exit Function
        End If

        mn_Monto = Decimal.Parse(txtMonto.Text)
        mn_Comision = 0
        'Se obtiene el monto de la comisión de la fecha mas reciente de acuerdo al tipo de comisión
        gs_Sql = "Select monto From TICKET..COMISIONES "
        gs_Sql = gs_Sql & "Where "
        gs_Sql = gs_Sql & "agencia = " & gAgencia & " and "
        gs_Sql = gs_Sql & "fecha_valida = ("
        gs_Sql = gs_Sql & "Select max(fecha_valida) "
        gs_Sql = gs_Sql & "From TICKET..COMISIONES "
        gs_Sql = gs_Sql & "Where "
        gs_Sql = gs_Sql & "agencia = " & gAgencia & " and "
        'si el banco esta dentro de E.U.
        If 1 = 1 Then 'If chkBcoEU.Value = 1 Then '--------------- Duda
            gs_Sql = gs_Sql & "tipo_comision = 1) and "
            gs_Sql = gs_Sql & "tipo_comision = 1"
            mn_TipoComision = 1
            'si el banco esta fuera de E.U.
        Else
            gs_Sql = gs_Sql & "tipo_comision = 2) and "
            gs_Sql = gs_Sql & "tipo_comision = 2"
            mn_TipoComision = 2
        End If
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta Is Nothing Then 'If dbError <> 0 Then
            'dbEndQuery
            MsgBox("No se puede consultar la base de datos. Se recomienda capturar de nuevo.", vbCritical, "SQL Server Error")
            Exit Function
        Else
            mn_Comision = dtRespConsulta.Rows(0).Item(0)
        End If
        'dbEndQuery
        If (Trim(TxtABABI.Text) = "") And (Trim(TxtABABC.Text) = "") And (Trim(TxtCableCBI.Text) = "") And (Trim(TxtCableCBC.Text) = "") Then
            MsgBox("Es necesario indicar datos del Banco Concertador/Intermediario.", vbInformation, "Datos Faltantes")
            If TxtABABI.Enabled And TxtABABI.Visible Then
                TxtABABI.Focus()
            End If
            Exit Function
        End If
        '------------------- RACB
        If TxtABABC.Text <> "" Then
            If txtRCuentaBC.Text = "" Then
                MsgBox("Es necesario indicar una cuenta.", vbInformation, "Datos Faltantes")
                TxtABABI.Focus()
                Exit Function
            End If
        End If
        If (Trim(txtRCuentaBoAP.Text) = "") Or (Trim(txtDatosAd1.Text) = "") Then
            MsgBox("Es necesario indicar la infomacion completa del beneficiario.", vbInformation, "Datos Faltantes")
            txtRCuentaBoAP.Focus()
            Exit Function
        ElseIf (Trim(txtDatosAd2.Text) = "") And (Trim(txtDatosAd3.Text) = "") And (Trim(txtDatosAd4.Text) = "") Then
            MsgBox("Es necesario indicar la infomacion completa del beneficiario.", vbInformation, "Datos Faltantes")
            txtDatosAd1.Focus()
            Exit Function
        End If
        If (Trim(txtRef1.Text) = "") And (Trim(txtRef2.Text) = "") And (Trim(txtRef3.Text) = "") And (Trim(txtRef4.Text) = "") Then
            MsgBox("Es necesario indicar informacion en referencia.", vbInformation, "Datos Faltantes")
            txtRef1.Focus()
            Exit Function
        End If
        '------------------- RACB
        If Trim(txtFunc.Text) = "" Then
            MsgBox("Es necesario que indique el concertador.", vbInformation, "Dato Faltante")
            If txtFunc.Enabled And txtFunc.Visible Then
                txtFunc.Focus()
            End If
            Exit Function
        End If
        If Trim(DirectCast(cmbFuncionario.SelectedItem, System.Data.DataRowView).Row.ItemArray(1)) = "" Then
            MsgBox("Es necesario que indique el concertador.", vbInformation, "Dato Faltante")
            If cmbFuncionario.Enabled And cmbFuncionario.Visible Then
                cmbFuncionario.Focus()
            End If
            Exit Function
        End If
        'If Trim(TxtContacto.text) = "" Then
        '    MsgBox("Es necesario que indique el contacto.", vbInformation, "Dato Faltante")
        '    If TxtContacto.Enabled And TxtContacto.Visible Then
        '        TxtContacto.Focus
        '    End If
        '    Exit Function
        'End If
        'If cmbFunc.ListIndex = -1 Then
        '    MsgBox("Es necesario que indique el concertador.", vbInformation, "Dato Faltante")
        '    If cmbFunc.Enabled And cmbFunc.Visible Then
        '        cmbFunc.SetFocus
        '    End If
        '    Exit Function
        'End If
        'Si no es sujeto o parcialmente sujeto a recepción de fondos
        'If (chkSujetoRF.Value = 0) And (chkParcialSRF.Value = 0) Then
        If (Decimal.Parse(txtSaldo.Text) < Decimal.Parse(mn_Monto + mn_Comision)) And chkExentarCom.Checked = False Then
            MsgBox("No se puede realizar el retiro, el saldo es insuficiente. ", vbInformation, Aplicacion)
            If txtMonto.Enabled And txtMonto.Visible Then
                txtMonto.Focus()
            End If
            Exit Function
        ElseIf Decimal.Parse(txtSaldo.Text) < Decimal.Parse(mn_Monto) And chkExentarCom.Checked = True Then
            MsgBox("No se puede realizar el retiro, el saldo es insuficiente. ", vbInformation, Aplicacion)
            If txtMonto.Enabled And txtMonto.Visible Then
                txtMonto.Focus()
            End If
            Exit Function
        End If
        'No exento de comisión
        If chkExentarCom.Checked = False Then
            nRespuesta = MsgBox("La operación generará un retiro por el monto de " & Format(mn_Monto, "###,###,##0.00") & " y un retiro por comisión de " & mn_Comision & ".", vbOKCancel + vbInformation, Aplicacion)
            If nRespuesta <> vbOK Then
                Exit Function
            End If
            'Si esta excento de comisión
        Else
            nRespuesta = MsgBox("La operación generará un retiro por el monto de " & Format(mn_Monto, "###,###,##0.00") & ".", vbOKCancel + vbInformation, Aplicacion)
            If nRespuesta <> vbOK Then
                Exit Function
            End If
        End If
        'Si esta sujeto o parcialmente sujeto a recepción de fondos
        'Else
        '    If chkSujetoRF.Value = 1 Then
        '        nRespuesta = MsgBox("La operación generará un retiro por el monto de " & Format(mn_Monto, "###,###,##0.00") & " sujeta a recepción de fondos.", vbOKCancel + vbInformation, Aplicacion)
        '    Else
        '        nRespuesta = MsgBox("La operación generará un retiro por el monto de " & Format(mn_Monto, "###,###,##0.00") & Chr(13) & "         parcialmente sujeta a recepción de fondos.", vbOKCancel + vbInformation, Aplicacion)
        '    End If
        '    If nRespuesta <> vbOK Then Exit Function
        'End If

        If dtpFechaOperacion.Value > CDate(FechaOpera(dtpFechaCaptura.Value, 1)) Then 'If CDate(txtFechaOperacion.text) > CDate(FechaOpera(txtFechaCaptura, 1)) Then
            MsgBox("La fecha de operación no puede ser mayor que " & dtpFechaCaptura.Value, vbInformation, Aplicacion)
            If dtpFechaOperacion.Enabled And dtpFechaOperacion.Visible Then
                dtpFechaOperacion.Focus()
            End If
            Exit Function
        End If
        DatosCorrectos = True
    End Function
    Public Function ValorParametroHora(ByVal OpDefinida As String, Descripcion As String, hora As Byte) As Date
        Dim dtRespConsulta As DataTable
        gs_Sql = "Select"
        gs_Sql = gs_Sql & " convert(char(5),hora_inicio,8),"
        gs_Sql = gs_Sql & " convert(char(5),hora_fin,8), "
        gs_Sql = gs_Sql & " convert(char(5),hora_password,8)"
        gs_Sql = gs_Sql & " from PARAMETROS_HORARIOS"
        gs_Sql = gs_Sql & " where descripcion = '" & Trim(Descripcion) & "'"
        gs_Sql = gs_Sql & " and operacion_definida_global = " & OpDefinida
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta IsNot Nothing Then 'If dbError = 0 Then
            If hora = 1 Then
                'Hora de Inicio de Operaciones
                ValorParametroHora = CDate(dtRespConsulta.Rows(0).Item(0))
            ElseIf hora = 2 Then
                'Hora Limite de Operacion Sin Password
                ValorParametroHora = CDate(dtRespConsulta.Rows(0).Item(1))
            Else
                'Hora Limite de Operacion Con Password
                ValorParametroHora = CDate(dtRespConsulta.Rows(0).Item(2))
            End If
        Else
            MsgBox("Error  al  Obtener  Dato  Parametrizado." & Chr(13) & "Notifique al Departamento de Sistemas!" & Chr(13) & "Descripción de Parametro: " & Trim(Descripcion), vbCritical, "Error")
            'If hora = 1 Then
            'ValorParametroHora = "08:00"
            'ElseIf hora = 2 Then
            'ValorParametroHora = "14:30"
            'Else
            'ValorParametroHora = "16:30"
            'End If
            ValorParametroHora = "00:00"
        End If
        'dbEndQuery
    End Function
    Private Function TipoCuenta() As Byte
        Dim dtRespConsulta As DataTable
        TipoCuenta = 0
        gs_Sql = "Select tipo_cuenta_eje From"
        gs_Sql = gs_Sql & " PRODUCTO_CONTRATADO PC,"
        gs_Sql = gs_Sql & " CUENTA_EJE CE"
        gs_Sql = gs_Sql & " Where PC.producto_contratado = " & GnProductoContratado
        gs_Sql = gs_Sql & " and PC.producto_contratado = CE.producto_contratado"
        gs_Sql = gs_Sql & " and PC.agencia = " & gAgencia
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbExecQuery gs_Sql
        'dbGetRecord
        If dtRespConsulta IsNot Nothing Then
            TipoCuenta = Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery
    End Function
    '------------------------------------------------------------------------------------------
    ' MESA DE AGENCIAS
    '------------------------------------------------------------------------------------------
    'Objetivo : Determinar si continua la operación de retiro,
    '           Pide autorizaciones en el caso de que sea necesario
    '           Esta función se llama al dar guardar y después de que paso por datos correctos
    '------------------------------------------------------------------------------------------
    ' UTILIZA :
    ' 1. Variable global gnproductocontratado:
    '                                           donde debe estar el producto contratado de la cuenta
    '                                           eje sobre la que se buscan vencimientos
    ' 3. Recibe operaciondefinida global que debe ser entera
    ' 4. Saldo que debe ser el saldo disponible sin la operación que se esta evaluando tipo Currency
    ' 5. Tipo definido por usuario Opera000LA: Continua as boolean, CapturaTD as boolean
    ' 6. Cuenta que la recibe de 6 digitos
    ' 7. Variable global gagencia : debe ser global porque la usa la autorización
    Public Function OperaRet(ByVal OpDef_Global As Integer, ByVal Saldo As Decimal, ByVal Monto_Ret As Decimal, ByVal Cuenta As String) As Opera000LA
        ' Monto minimo de Time deposit
        Dim lc_MinTD As Decimal
        'Si la cuenta tiene o no vencimientos fecha valor hoy
        Dim lb_Venc As Boolean
        Dim lc_Saldo2 As Decimal
        Dim li_TotalRethoy As Integer
        Dim dtRespConsulta As DataTable
        '1. Datos previos
        OperaRet.Continua = False
        OperaRet.CapturaTD = False
        ' Evalua si la cuenta tiene o no vencimientos fecha valor hoy
        If TieneVencimientos() = True Then
            lb_Venc = True
        Else
            lb_Venc = False
        End If
        'Trae monto minimo de TD
        ValidaBanca(txtCuenta.Text)
        lc_MinTD = ValorParametroOp(4, 1, 80, sIdBanca)
        ' Cuenta
        Cuenta = Trim(Cuenta)
        'Valida si la cuenta tiene renovación para aceptar la operacion de retiro
        If lb_Venc = True Then
            ' Trae numero de retiros de hoy sin tomar en cuenta comisiones ordenes de pago , ni renovaciones, ni td
            li_TotalRethoy = 0
            gs_Sql = " select count(*) "
            gs_Sql = gs_Sql & " from OPERACION o, OPERACION_DEFINIDA od "
            gs_Sql = gs_Sql & " where operacion_definida_global in (83,85,97,87,86,81,94,88)"
            gs_Sql = gs_Sql & " and o.operacion_definida = od.operacion_definida"
            gs_Sql = gs_Sql & " and status_operacion <> 250"
            gs_Sql = gs_Sql & " and fecha_operacion ='" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
            gs_Sql = gs_Sql & " and producto_contratado = " & GnProductoContratado
            'dbExecQuery gs_Sql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            If dtRespConsulta.Rows(0).Item(0) <> "" Then
                li_TotalRethoy = Val(dtRespConsulta.Rows(0).Item(0))
            End If
            'dbEndQuery
            '2.
            If Saldo >= Monto_Ret Then
                'Ve condicion de monto contra retiros
                lc_Saldo2 = ObtenSaldo000LA()
                'Tiene saldo
                If lc_Saldo2 > Monto_Ret Then
                    If Val(ValorParametro("TOTRETIROS000")) >= li_TotalRethoy Then
                        If (Saldo - Monto_Ret) < lc_MinTD Then
                            MsgBox("Debe retirar el saldo restante.", vbInformation, "Aviso")
                            'If PideAutorizacion("ASALDOMIN", Cuenta, OpDef_Global, Monto_Ret) = False Then
                            If Not PideAutorizacion("ASALDOMIN", Cuenta, OpDef_Global, Monto_Ret) Then
                                MsgBox("No puede continuar con la operación " & Chr(13) & " la autorización fue rechazada.", vbInformation, "Aviso")
                            Else
                                OperaRet.Continua = True
                            End If
                            Exit Function
                        Else ' el saldo alcanza para concertación
                            'nRespuesta = MsgBox(" Va a concertar el TD en este momento? ", vbYesNo + vbInformation, "Aviso")
                            'If nRespuesta = vbNo Then
                            If MsgBox(" Va a concertar el TD en este momento? ", vbYesNo + vbInformation, "Aviso") = vbNo Then
                                'pide autorización
                                'If PideAutorizacion("ANOCONCERTATD", Cuenta, OpDef_Global, Monto_Ret) = False Then
                                If Not PideAutorizacion("ANOCONCERTATD", Cuenta, OpDef_Global, Monto_Ret) Then
                                    MsgBox("No puede continuar con la operación " & Chr(13) & " la autorización fue rechazada.", vbInformation, "Aviso")
                                Else
                                    OperaRet.Continua = True
                                End If
                                Exit Function
                            Else ' si concerta td
                                OperaRet.Continua = True
                                OperaRet.CapturaTD = True
                                Exit Function
                            End If  ' va aconcertar td
                        End If
                    Else 'ya se paso del limite de retiros de hoy
                        'AUTORIZACION MÁXIMO DE RETIROS
                        MsgBox("Ha excedido el máximo de retiros por día necesita autorización.", vbInformation, "Aviso")
                        'If PideAutorizacion("AMAXRETIROS", Cuenta, OpDef_Global, Monto_Ret) = False Then
                        If Not PideAutorizacion("AMAXRETIROS", Cuenta, OpDef_Global, Monto_Ret) Then
                            MsgBox("No puede continuar con la operación " & Chr(13) & " la autorización fue rechazada.", vbInformation, "Aviso")
                        Else
                            OperaRet.Continua = True
                        End If
                        Exit Function
                    End If
                    'Esta retirando el total
                ElseIf lc_Saldo2 = Monto_Ret Then
                    OperaRet.Continua = True
                    Exit Function
                Else
                    MsgBox("Debe cancelar la renovación.", vbInformation, "Aviso")
                    Exit Function
                End If
            Else
                MsgBox("No tiene saldo suficiente.", vbInformation, "Aviso")
                Exit Function
            End If
        Else
            MsgBox("No puede continuar la Operacion, la Cuenta no tiene Vencimientos", vbInformation, "Aviso")
            Exit Function
        End If
    End Function
    '------------------------------------------------------------------------------------------
    'Objetivo : Determinar si una cuenta tiene vencimientos de time deposit fecha valor hoy
    '------------------------------------------------------------------------------------------
    ' usa Variable global gnproductocontratado:
    ' donde debe estar el producto contratado de la cuenta eje sobre la que se buscan vencimientos
    Public Function TieneVencimientos() As Boolean
        Dim dtRespConsulta As DataTable
        TieneVencimientos = False
        gs_Sql = " select count(*) "
        gs_Sql = gs_Sql & " From  OPERACION o,  OPERACION_DEFINIDA od Where"
        gs_Sql = gs_Sql & " o.producto_contratado = " & GnProductoContratado
        gs_Sql = gs_Sql & " and o.operacion_definida = od.operacion_definida"
        gs_Sql = gs_Sql & " and od.operacion_definida_global = 580"
        gs_Sql = gs_Sql & " and o.fecha_operacion = '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and o.status_operacion <> 250"
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta.Rows(0).Item(0) <> "" Then
            If Val(dtRespConsulta.Rows(0).Item(0)) <> 0 Then
                TieneVencimientos = True
            End If
        End If
        'dbEndQuery
    End Function
    '---------------------------------------------------------------------------------------
    'Devuelve el monto_minimo de la tabla PARAMETROS_OPERACION segun el TipoCuenta y Agencia
    '---------------------------------------------------------------------------------------
    Public Function ValorParametroOp(ByVal TipoCuenta As Integer, ByVal Agencia As Byte, ByVal OpDef As Integer, ByVal Banca As String) As Decimal
        Dim dtRespConsulta As DataTable
        '***SE AGREGA A LA CONSULTA ID DE BANCA / SANDRA LUZ GARCIA MONTOYA 13/08/2007
        gs_Sql = "Select monto_minimo from PARAMETROS_OPERACION"
        gs_Sql = gs_Sql & " where tipo_cuenta_eje = " & Trim(TipoCuenta)
        gs_Sql = gs_Sql & " and agencia = " & Agencia
        gs_Sql = gs_Sql & " and operacion_definida_global = " & OpDef
        gs_Sql = gs_Sql & " and unidad_banca = " & Banca
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta IsNot Nothing Then
            ValorParametroOp = Trim(dtRespConsulta.Rows(0).Item(0))
        Else
            ValorParametroOp = 0
        End If
        'dbEndQuery
    End Function
    Public Sub ValidaBanca(idBcaCuenta As String)
        '***SE AGREGA CONSULTA CUENTA_BCA_CR PARA OBTENER ID DE BANCA / SANDRA LUZ GARCIA MONTOYA 13/08/2007
        Dim dtRespConsulta As DataTable
        gs_Sql = "Select id_division from "
        gs_Sql = gs_Sql & "CUENTA_BCA_CR "
        gs_Sql = gs_Sql & "where cuenta = '" & idBcaCuenta & "' "
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        sIdBanca = dtRespConsulta.Rows(0).Item(0)
        'dbEndQuery
    End Sub
    '-------------------------------------------------------------------
    'Calcula el saldo de una cuenta 00 de LA para hacer retiros
    ' y no usar la cuenta como puente ( sólo se retira sobre vencimientos)
    ' SALDO =
    '  +  depositos por vencimientos de hoy
    '  -  retiros de hoy ( a excepción de TD)
    '  -  renovaciones de hoy sin cancelar
    '-------------------------------------------------------------------
    Function ObtenSaldo000LA() As Decimal
        Dim dtRespConsulta As DataTable
        Dim nSaldo As Decimal
        'ProcessMessage "Calculando Saldo de Vencimientos Cuenta 000 de Houston..."
        nSaldo = 0
        'Depositos de hoy por vencimientos
        gs_Sql = "select sum(monto_operacion) from OPERACION OP, OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & " where OP.producto_contratado= " & GnProductoContratado
        gs_Sql = gs_Sql & " and OP.fecha_operacion = '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion <> 250"
        gs_Sql = gs_Sql & " and status_operacion >= 2"
        gs_Sql = gs_Sql & " and OP.operacion_definida= OD.operacion_definida"
        gs_Sql = gs_Sql & " and operacion_definida_global in (580,680)"
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta.Rows(0).Item(0) <> "" Then
            nSaldo = nSaldo + Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        'Todos los retiros (menos orden de pago) fecha valor hoy que no esten cancelados
        'Se agregan op def 58 y 59 de comisiones y devoluciones
        gs_Sql = "select sum(monto_operacion) from OPERACION OP, OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & " where OP.producto_contratado= " & GnProductoContratado
        gs_Sql = gs_Sql & " and OP.fecha_operacion = '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion <> 250"
        gs_Sql = gs_Sql & " and OP.operacion_definida= OD.operacion_definida"
        gs_Sql = gs_Sql & " and operacion_definida_global in (60,65,83,85,86,87,91,94,96,97,88, 89, 58, 59)"          '24 Horas  13-08-1998
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta.Rows(0).Item(0) <> "" Then
            nSaldo = nSaldo - Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        'Todos los retiros por orden de pago fecha valor o mañana, que no esten cancelados y no sean sujetos a recepción
        gs_Sql = "select sum(monto_operacion) from OPERACION OP, OPERACION_DEFINIDA OD, RETIRO_ORDEN_PAGO RO"
        gs_Sql = gs_Sql & " where OP.producto_contratado= " & GnProductoContratado
        gs_Sql = gs_Sql & " and OP.fecha_operacion >= '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion <> 250"
        gs_Sql = gs_Sql & " and OP.operacion= RO.operacion"
        gs_Sql = gs_Sql & " and OP.operacion_definida= OD.operacion_definida"
        gs_Sql = gs_Sql & " and operacion_definida_global = 81"
        gs_Sql = gs_Sql & " and RO.sujeto_a_recepcion = 0"
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta.Rows(0).Item(0) <> "" Then
            nSaldo = nSaldo - Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        'Todos los retiros por orden de pago fecha valor o mañana, que no esten cancelados y no sean sujetos a recepción
        gs_Sql = "select sum(monto_operacion) from OPERACION OP, OPERACION_DEFINIDA OD, RETIRO_ORDEN_PAGO RO"
        gs_Sql = gs_Sql & " where OP.producto_contratado= " & GnProductoContratado
        gs_Sql = gs_Sql & " and OP.fecha_operacion < '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion in (0,1)"
        gs_Sql = gs_Sql & " and OP.operacion= RO.operacion"
        gs_Sql = gs_Sql & " and OP.operacion_definida= OD.operacion_definida"
        gs_Sql = gs_Sql & " and operacion_definida_global = 81"
        gs_Sql = gs_Sql & " and RO.sujeto_a_recepcion = 0"
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta.Rows(0).Item(0) <> "" Then
            nSaldo = nSaldo - Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        'Algun retiro que no se haya validado a tiempo por lo tanto sería fecha valor anterior y estaría en status 0 o 1, los unicos retiros que se validan son los de
        'la cuenta mercury en agencias y las compras de TD cuando son renovaciones
        gs_Sql = "select sum(monto_operacion) from OPERACION OP, OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & " where OP.producto_contratado= " & GnProductoContratado
        gs_Sql = gs_Sql & " and OP.fecha_operacion < '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion in (0,1)"
        gs_Sql = gs_Sql & " and OP.operacion_definida= OD.operacion_definida"
        gs_Sql = gs_Sql & " and operacion_definida_global"
        gs_Sql = gs_Sql & " in (83,85,86,87,91,94,96,97,88, 89)"                                                              '24 Horas  13-08-1998
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta.Rows(0).Item(0) <> "" Then
            nSaldo = nSaldo - Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        ' TRAE LOS TD QUE SON DE RENOVACION Y FECHA DE OPERACION HOY,
        gs_Sql = "select sum(monto_operacion) from OPERACION OP, COMPRA_CD CC, OPERACION_DEFINIDA OD "
        gs_Sql = gs_Sql & " where OP.producto_contratado= " & GnProductoContratado
        gs_Sql = gs_Sql & " and OP.fecha_operacion = '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion in (0,1)"
        gs_Sql = gs_Sql & " and OP.operacion_definida= OD.operacion_definida"
        gs_Sql = gs_Sql & " and operacion_definida_global in (80)"
        gs_Sql = gs_Sql & " and OP.operacion = CC.operacion "
        gs_Sql = gs_Sql & " and CC.origen = 3" ' renovación
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta.Rows(0).Item(0) <> "" Then
            nSaldo = nSaldo - Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        'Operaciones que se bajan directamente de kapiti retiro
        gs_Sql = "select sum(monto_operacion) from OPERACION OP, OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & " where OP.producto_contratado= " & GnProductoContratado
        gs_Sql = gs_Sql & " and OP.fecha_operacion = '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"
        gs_Sql = gs_Sql & " and status_operacion <> 250"
        gs_Sql = gs_Sql & " and OP.operacion_definida= OD.operacion_definida"
        gs_Sql = gs_Sql & " and operacion_definida_global =  95"
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta.Rows(0).Item(0) <> "" Then
            nSaldo = nSaldo - Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery
        ObtenSaldo000LA = nSaldo
        'ProcessMessage "OFF"
    End Function
    '------------------------------------------------------------------
    'Devuelve el valor de un parametro de la tabla PARAMETRIZACION
    '------------------------------------------------------------------
    Public Function ValorParametro(Parametro As String) As String
        Dim dtRespConsulta As DataTable
        gs_Sql = "Select valor from PARAMETRIZACION"
        gs_Sql = gs_Sql & " where codigo = '" & Trim(Parametro) & "'"
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta IsNot Nothing Then
            ValorParametro = Trim(dtRespConsulta.Rows(0).Item(0))
        ElseIf Val(dtRespConsulta.Rows(0).Item(0)) = 0 And (Parametro = "CTE_PU_PFIS" Or Parametro = "CTE_PU_PFMOR") Then
            ValorParametro = 0
        Else
            MsgBox("Error al Obtener Dato Parametrizado." & Chr(13) & "Notifique al Departamento de Sistemas!" & Chr(13) & "Código de Parametro: " & Trim(Parametro), vbCritical, "Error")
            ValorParametro = ""
        End If
        'dbEndQuery
    End Function
    '-------------------------------------------------------
    'Consulta de la base de datos el monto millonario
    'Originalmente se encontraba en moddeclaraciones-Mesa y modMiscelaneas - Back
    'Agregada e identada por CEB 20-02-2002
    '-------------------------------------------------------
    Function Monto_Millonario() As Decimal
        Dim dtRespConsulta As DataTable
        Monto_Millonario = 0
        'dbExecQuery("SELECT monto_millonario FROM PARAMETROS")
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta("SELECT monto_millonario FROM PARAMETROS")
        If dtRespConsulta IsNot Nothing Then
            Monto_Millonario = Val(dtRespConsulta.Rows(0).Item(0))
        Else
            MsgBox("No esta registrado el monto millonario, consulte al departamento de sistemas.", vbInformation, "Aviso")
        End If
        'dbEndQuery
    End Function
    '-------------------------------------------------------
    'Funcion general que regresa la Operacion Definida (Integer),
    'Recibe la Operacion Definida Global y la Agencia.
    'Originalmente se encontraba en moddeclaraciones-Mesa
    'Agregada e identada por CEB 20-02-2002
    '-------------------------------------------------------
    Public Function OperacionDefinida(ByVal ODGlobal As Integer, ByVal Agencia As Integer) As Integer
        'La enum agencias fue eliminada se tomara la agencia como tipo integer
        'ya que el unico lugar donde se manda llamar se le pasa la variable gAgencia
        'de tipo integer
        'Public Function OperacionDefinida(ByVal ODGlobal As Integer, _
        '                                  ByVal Agencia As Agencias) As Integer
        On Error GoTo errOperacionDefinida
        Dim ls_qry As String
        Dim dtRespConsulta As DataTable
        OperacionDefinida = 0
        'dbEndQuery
        ls_qry = "SELECT operacion_definida FROM OPERACION_DEFINIDA " &
        "WHERE operacion_definida_global = " & CStr(ODGlobal) &
        " AND agencia = " & CStr(Agencia)
        'dbExecQuery ls_qry
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(ls_qry)
        If dtRespConsulta IsNot Nothing Then
            OperacionDefinida = Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery
        Exit Function
errOperacionDefinida:
        MsgBox(Err.Number & " " & Err.Description, vbCritical, "Error")
        OperacionDefinida = 0
    End Function
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    'Hace las modificaciones a la tabla de EVENTO_AUTORIZACION como sea necesario
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    Public Sub RegistraAutorizacion(Operacion As String, Optional Comentario As Object = "", Optional ValorPrevio As Object = "")
        Dim dtRespConsulta As DataTable
        Dim ln_Indice As Integer
        Dim ln_Operaciones As Integer
        Dim Ls_Comentario As String

        If NumAplicacion = 2 Then
            'Operacion = Trim(Operacion)
            If Trim(gs_ComentarioAutorizacion) = "" Then
                If Comentario IsNot Nothing Then 'If IsMissing(Comentario) = False Then
                    gs_ComentarioAutorizacion = Comentario
                Else
                    gs_ComentarioAutorizacion = gs_Comentario
                End If
            End If
            '---------------- RACB
            dtRespConsulta = objDatasource.RealizaConsulta("SELECT convert(char(5),getdate(),14)")
            gs_HoraSistema = dtRespConsulta.Rows(0).Item(0).ToString()
            '---------------- RACB
            'No hay autorización previa
            If gb_OperacionConPassword = False Then GoTo Fin
            'No se confirmo el numero de usuario que valida
            If gn_UsuarioAutoriza = 0 Then GoTo Fin
            'No se confirmo el numero de autorización que valida
            If gn_NumeroAutorizacion = 0 Then GoTo Fin
            'No se indica la operación por validar
            If Operacion = "" Then GoTo Fin
            gs_Sql = "Insert into " & "CATALOGOS" & ".dbo.EVENTO_AUTORIZACION"
            gs_Sql = gs_Sql & " (usuario_opera, usuario_password, fecha_password,"
            gs_Sql = gs_Sql & " operacion, autorizacion, comentario, comentario_respuesta, aplicacion) values ("
            gs_Sql = gs_Sql & userId & ", " & gn_UsuarioAutoriza & ", '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " " & gs_HoraSistema & "', " & Operacion
            gs_Sql = gs_Sql & ", " & gn_NumeroAutorizacion
            gs_Sql = gs_Sql & ", '" & gs_ComentarioAutorizacion & "', '" & gs_Respuesta & "', " & NumAplicacion & ")"
            'dbExecQuery(gs_Sql)
            If objDatasource.insertar(gs_Sql) = 0 Then
                MsgBox("Error: No se actualizó EVENTO_AUTORIZACION.", vbCritical + vbOKOnly, "Autorización")
            End If
            'dbEndQuery

Fin:
            'Reinicializa las variables para operaciones posteriores
            gn_UsuarioAutoriza = 0
            gn_NumeroAutorizacion = 0
            gs_ComentarioAutorizacion = ""
            'Reinicializa la variable para operaciones posteriores
            gb_OperacionConPassword = False

        ElseIf NumAplicacion = 1 Then
            Ls_Comentario = ""
            Operacion = Trim(Operacion)
            If Comentario IsNot Nothing Then 'If IsMissing(Comentario) = False Then
                Ls_Comentario = Comentario
            End If
            'No hay autorización previa
            'If gb_OperacionConPassword = False Then
            '    GoTo Fin2
            'End If
            'No se confirmo el numero de usuario que valida
            'If gn_UsuarioAutoriza = 0 Then
            '    GoTo Fin2
            'End If
            'No se indica la operación por validar
            'If Operacion = "" Then
            '    GoTo Fin2
            'End If
            'If UBound(ga_PermisosRemotos) > 0 Then
            '    ln_Operaciones = UBound(ga_PermisosRemotos) - 1
            'Else
            '    ln_Operaciones = 0
            'End If

            For ln_Indice = 0 To ln_Operaciones
                gs_Sql = "Insert into " & "CATALOGOS" & "..EVENTO_AUTORIZACION"
                gs_Sql = gs_Sql & " (usuario_opera, usuario_password, fecha_password,"
                gs_Sql = gs_Sql & " operacion, autorizacion, comentario, comentario_respuesta, tasa, sobretasa, aplicacion) values ("
                gs_Sql = gs_Sql & userId
                If gn_Tipo_Tasa = 2 Then
                    gs_Sql = gs_Sql & ", " & gn_MesaRegional
                Else
                    gs_Sql = gs_Sql & ", " & la_Buffer(ln_Indice).UsuarioAutoriza
                End If
                gs_Sql = gs_Sql & ", getdate(), " & Operacion
                gs_Sql = gs_Sql & ", " & la_Buffer(ln_Indice).Autorizacion
                gs_Sql = gs_Sql & ", '" & Ls_Comentario & " " & la_Buffer(ln_Indice).Comentario
                gs_Sql = gs_Sql & "', '" & la_Buffer(ln_Indice).Respuesta
                gs_Sql = gs_Sql & "', "
                If la_Buffer(ln_Indice).SobreTasa = 0 Then
                    gs_Sql = gs_Sql & "null, null, " & NumAplicacion & ")"
                Else
                    gs_Sql = gs_Sql & la_Buffer(ln_Indice).tasa & ", " & la_Buffer(ln_Indice).SobreTasa & ", " & NumAplicacion & ")"
                End If
                'dbExecQuery gs_Sql
                If objDatasource.insertar(gs_Sql) = 0 Then
                    MsgBox("Error: No se actualizó EVENTO_AUTORIZACION.", vbCritical, "Error")
                End If
                'dbEndQuery
            Next ln_Indice

Fin2:
            Call CancelaAutorizacion()

        End If
    End Sub
    '******************************************************************************************************************
    'Funcion que pide autorizaciones
    'Modificada por CEB 13-02-2002, para que funcione para las dos aplicaciones.
    '******************************************************************************************************************
    Public Function PideAutorizacion(Constante As String, Optional NoCuenta As String = "", Optional OpDefG As Integer = 0, Optional Monto As Integer = 0, Optional tasa As Integer = 0, Optional SobreTasa As Integer = 0, Optional Plazo As Integer = 0) As Boolean
        'Public Function PideAutorizacion(Constante As String, NoCuenta As String, ByVal OpDefG As Integer, Optional Monto, Optional tasa, Optional SobreTasa, Optional Plazo) As Boolean
        Dim dtRespConsulta As DataTable
        Dim ln_Indice As Integer
        Dim ln_Registra As Integer
        Dim ln_IndiceArreglo As Integer
        Dim ln_Autorizacion As Integer
        Dim ln_PlazoTasa As Integer

        gn_Monto = 0
        gn_Tasa = 0
        gn_Plazo = 0
        gn_SobreTasa = 0
        gs_Respuesta = ""
        gs_Comentario = ""
        ln_Autorizacion = 0
        gn_IDAutorizacion = 0
        'Constante con el nombre de la Autorizacion
        gs_Autorizacion = Constante
        'Cuenta Cliente a la que afecta la Operacion
        gs_Cuenta_Cliente = NoCuenta

        'Calcula la operacion definida de la base
        If gAgencia <> 0 Then
            gn_Operacion_Definida = OperacionDefinida(OpDefG, gAgencia)
            'Si no hay un numero de agencia valido.
        Else
            PideAutorizacion = False
            Exit Function
        End If

        'Monto de la Operacion
        If Monto.ToString IsNot Nothing Then
            gn_Monto = Decimal.Parse(Monto)
        End If
        'Tasa Normal de la Operación
        If tasa.ToString IsNot Nothing Then
            gn_Tasa = Decimal.Parse(tasa)
        End If
        'Sobretasa de la Operación
        If SobreTasa.ToString IsNot Nothing Then
            gn_SobreTasa = Decimal.Parse(SobreTasa)
        End If
        'Plazo de Sobretasa de la Operación
        If Plazo.ToString IsNot Nothing Then
            gn_Plazo = Decimal.Parse(Plazo)
        End If

        'Si no hay Autorizaciones en el sistema
        If gn_TotalAutorizaciones = 0 Then
            MsgBox("Error: Descripción de Autorización Inexistente." & vbCrLf &
            DEFAULT_SRVR & " : " & "CATALOGOS" & " : " & gs_Autorizacion & vbCrLf & vbCr &
            " Notifique al Departamento de Sistemas.     ", vbCritical, "Error")
            PideAutorizacion = False
            Exit Function
            'Busca la autorizacion descrita en el arreglo.
        Else
            For ln_IndiceArreglo = 0 To gn_TotalAutorizaciones - 1
                If Trim(ga_Autorizaciones(ln_IndiceArreglo).Nombre) = Constante Then
                    ln_Autorizacion = ln_IndiceArreglo + 1
                    gn_IDAutorizacion = ga_Autorizaciones(ln_IndiceArreglo).Valor
                    'Para registrar la autorizacion
                    gn_NumeroAutorizacion = ga_Autorizaciones(ln_IndiceArreglo).Valor
                    'Si la encuentra salimos del for
                    Exit For
                End If
            Next ln_IndiceArreglo
        End If

        'Si el nombre de la autorizacion no existe
        If ln_Autorizacion = 0 Then
            MsgBox("Error: Descripción de Autorización Inexistente." & vbCrLf &
        DEFAULT_SRVR & " : " & "CATALOGOS" & " : " & Constante & vbCrLf & vbCr &
        " Notifique al Departamento de Sistemas.     ", vbCritical, "Error")
            PideAutorizacion = False
            Exit Function
        End If
        ln_Autorizacion = ln_Autorizacion - 1
        'Verifica la hora maxima para operar con password
        'Si hay datos en el campo de hora_limite
        If Trim(ga_Autorizaciones(ln_Autorizacion).Hora) <> "" Then
            'No aplica si la hora limite ya se cumplio
            If CDate(Trim(ga_Autorizaciones(ln_Autorizacion).Hora)) < CDate(gs_HoraSistema) Then
                MsgBox("Ya paso la hora para efectuar este tipo de operación.", vbInformation, "Aviso")
                PideAutorizacion = False
                Exit Function
            End If
        End If

        'Selecciona que aplicacion esta solicitando la autorizacion
        Select Case NumAplicacion
        'Si la aplicacion es MESA Agencias
            Case 1
                'Si el usuario tiene asignada la autorizacion que se pide y no se trata de sobretaasa
                ' O se tiene que registrar la peticion para Mesas Regionales de Precios.
                If ((Constante <> "ASOBRETASA" Or gn_Tipo_Tasa = 5) And Autorizacion(Constante) = True) Or (Constante = "ASOBRETASA" And gn_Autno_Regsi = 1) Then
                    gs_Sql = "Insert into " & "CATALOGOS" & "..PERMISOS_REMOTOS"
                    gs_Sql = gs_Sql & " (cuenta_cliente, operacion_definida, monto, usuario, fecha,"
                    gs_Sql = gs_Sql & " datos_referencia, comentario_respuesta, status_autorizacion, autorizacion, aplicacion)"
                    gs_Sql = gs_Sql & " values ('" & gs_Cuenta_Cliente & "'," & gn_Operacion_Definida
                    gs_Sql = gs_Sql & ", " & gn_Monto & ", " & userId & ", getdate()"
                    gs_Sql = gs_Sql & ", '" & ga_Autorizaciones(ln_Autorizacion).Descripcion
                    If gn_Plazo <> 0 Then
                        gs_Sql = gs_Sql & " con Plazo a " & gn_Plazo & " dias"
                    End If
                    gs_Sql = gs_Sql & " ', '" & gs_Autorizacion & Space(20 - Len(gs_Autorizacion))
                    gs_Sql = gs_Sql & Space(15 - Len(Str(gn_Tasa))) & Str(gn_Tasa)
                    gs_Sql = gs_Sql & Space(15 - Len(Str(gn_SobreTasa))) & Str(gn_SobreTasa)
                    gs_Sql = gs_Sql & "', 1," & ga_Autorizaciones(ln_Autorizacion).Valor & "," & NumAplicacion & " )"
                    'dbExecQuery gs_Sql
                    'dbEndQuery
                    objDatasource.insertar(gs_Sql)
                    'dbExecQuery("Select @@IDENTITY")
                    dtRespConsulta = objDatasource.RealizaConsulta("Select @@IDENTITY")
                    'dbGetRecord
                    If dtRespConsulta IsNot Nothing Then 'If Not IsdbError Then
                        gn_Peticion = Val(dtRespConsulta.Rows(0).Item(0))
                    Else
                        gn_Peticion = 0
                    End If
                    'dbEndQuery
                    gb_Autorizacion = True
                    gb_OperacionConPassword = True
                    gn_UsuarioAutoriza = userId
                    gs_Comentario = ""
                    gs_Respuesta = ""
                    'Solicita la autorizacion remota
                Else
                    'frmAutorizacionRemota.Show 1
                End If
        'Si la aplicacion es BACK Agencias
            Case 2
                '    If Autorizacion(Constante) Then
                '        gs_Sql = "Insert into " & "CATALOGOS" & "..PERMISOS_REMOTOS"
                '        gs_Sql = gs_Sql & " (cuenta_cliente, operacion_definida, monto, usuario, fecha,"
                '        gs_Sql = gs_Sql & " datos_referencia, comentario_respuesta, status_autorizacion, autorizacion, aplicacion)"
                '        gs_Sql = gs_Sql & " values ('" & gs_Cuenta_Cliente & "'," & gn_Operacion_Definida
                '        gs_Sql = gs_Sql & ", " & gn_Monto & ", " & gn_Usuario & ", getdate()"
                '        gs_Sql = gs_Sql & ", '" & ga_Autorizaciones(ln_Autorizacion).Descripcion
                '        If gn_Plazo <> 0 Then
                '            gs_Sql = gs_Sql & " con Plazo a " & gn_Plazo & " dias"
                '        End If
                '        gs_Sql = gs_Sql & " ', '" & gs_Autorizacion & Space(20 - Len(gs_Autorizacion))
                '        gs_Sql = gs_Sql & Space(15 - Len(Str(gn_Tasa))) & Str(gn_Tasa)
                '        gs_Sql = gs_Sql & Space(15 - Len(Str(gn_SobreTasa))) & Str(gn_SobreTasa)
                '        gs_Sql = gs_Sql & "', 1," & ga_Autorizaciones(ln_Autorizacion).Valor & "," & NumAplicacion & " )"
                '        dbExecQuery gs_Sql
                '        dbEndQuery
                '        dbExecQuery("Select @@IDENTITY")
                '        dbGetRecord
                '        If Not IsdbError Then
                '            gn_Peticion = Val(dbGetValue(0))
                '        Else
                '            gn_Peticion = 0
                '        End If
                '        dbEndQuery
                '        gb_Autorizacion = True
                '        gb_OperacionConPassword = True
                '        gn_UsuarioAutoriza = gn_Usuario
                '        gs_Comentario = ""
                '        gs_Respuesta = ""
                '        'Si no solicita la autorizacion remota
                '    Else
                '        frmAutorizacionRemota.Show 1
                'End If
        End Select

        PideAutorizacion = gb_Autorizacion

        'Si se autoriza la operación
        'If gb_Autorizacion Then
        'Si no hay autorizaciones registradas para esta operación
        If la_Buffer.Count = 0 Then 'If UBound(ga_PermisosRemotos) = 0 Then
            ga_PermisosRemotos.peticion = gn_Peticion
            ga_PermisosRemotos.Autorizacion = gn_IDAutorizacion
            ga_PermisosRemotos.UsuarioAutoriza = gn_UsuarioAutoriza
            ga_PermisosRemotos.Comentario = gs_Comentario
            ga_PermisosRemotos.Respuesta = gs_Respuesta
            ga_PermisosRemotos.tasa = gn_Tasa
            ga_PermisosRemotos.SobreTasa = gn_SobreTasa
            la_Buffer.Add(ga_PermisosRemotos)
            'ReDim Preserve ga_PermisosRemotos(1)
            'Si ya existe autorizaciones registradas para la operación
        Else
            ln_Registra = -1
            For ln_Indice = 0 To la_Buffer.Count - 1
                If la_Buffer(ln_Indice).Autorizacion = gn_IDAutorizacion Then
                    ln_Registra = ln_Indice
                End If
            Next ln_Indice
            'Si el tipo de autorizacion ya se habia dado actualiza el numero de peticion
            If ln_Registra > -1 Then
                la_Buffer(ln_Registra).peticion = gn_Peticion
                la_Buffer(ln_Registra).UsuarioAutoriza = gn_UsuarioAutoriza
                la_Buffer(ln_Registra).Comentario = gs_Comentario
                la_Buffer(ln_Registra).Respuesta = gs_Respuesta
                la_Buffer(ln_Registra).tasa = gn_Tasa
                la_Buffer(ln_Registra).SobreTasa = gn_SobreTasa
                'Si la autorizacion es nueva para la operacion se registra en el arreglo
            Else
                la_Buffer(la_Buffer.Count).peticion = gn_Peticion
                la_Buffer(la_Buffer.Count).Autorizacion = gn_IDAutorizacion
                la_Buffer(la_Buffer.Count).UsuarioAutoriza = gn_UsuarioAutoriza
                la_Buffer(la_Buffer.Count).Comentario = gs_Comentario
                la_Buffer(la_Buffer.Count).Respuesta = gs_Respuesta
                la_Buffer(la_Buffer.Count).tasa = gn_Tasa
                la_Buffer(la_Buffer.Count).SobreTasa = gn_SobreTasa
                'ReDim Preserve ga_PermisosRemotos(UBound(ga_PermisosRemotos) + 1)
            End If
        End If
        'End If
    End Function
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    'Devuelve el valor booleano correspondiente a una autorizacion del usuario que firmo
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function Autorizacion(ByVal strNombreAut As String) As Boolean
        Autorizacion = objModPErmisos.AutorizacionesPorUsuario(strNombreAut, gn_Autorizaciones)
    End Function
    '-----------------------------------------------------------------------
    'Reinicializa las variables de Autorizacion para operaciones posteriores
    '-----------------------------------------------------------------------
    Public Sub CancelaAutorizacion()
        gs_Respuesta = ""
        gs_Comentario = ""
        gs_Autorizacion = ""
        gn_Plazo = 0
        gn_IDAutorizacion = 0
        gn_UsuarioAutoriza = 0
        gb_OperacionConPassword = False
        'ReDim ga_PermisosRemotos(0)
    End Sub

    Private Sub ValidarOperacion()
        NumAplicacion = 2

        If Trim(txtOperacion.Text) <> "" Then 'If Trim(LblRTicket.Caption) <> "" Then
            'Si es horario con password
            If CDate(gs_HoraSistema) > ValorParametroHora(81, "VALIDACION", 2) Then
                'Si no tiene la autorizacion del horario
                If Not Autorizacion("AHORAOPERA") Then
                    If MsgBox("La hora normal de validaciónes ya paso, la operación requiere Autorización Remota", vbInformation, "Validación...") = vbOK Then
                        Exit Sub
                    Else
                        If Not PideAutorizacion("AHORAOPERA", Trim(txtCuenta.Text), 81, Trim(txtMonto.Text)) Then 'Trim(LblRMontRet.Caption)) Then
                            'If PideAutorizacion("AHORAOPERA") = False Then
                            MsgBox("No es posible validar la operación sin password.", vbInformation, "Validación...")
                            Exit Sub
                        Else
                            Call RegistraAutorizacion(Trim(txtOperacion.Text)) 'Call RegistraAutorizacion(Trim(LblRTicket.Caption))
                            If estatus = 16 Then
                                'Si no tiene la autorizacion de verificación OFAC
                                If Not Autorizacion("AVALOFAC") Then
                                    If MsgBox("Validación OFAC, La operación requiere Autorización Remota. ¿Desea Continuar?", vbYesNo + vbQuestion, "Validación...") = vbNo Then
                                        Exit Sub
                                    Else
                                        If Not PideAutorizacion("AVALOFAC", Trim(txtCuenta.Text), 81, Trim(txtMonto.Text)) Then 'Trim(LblRMontRet.Caption)) Then
                                            MsgBox("No es posible validar la operación sin Autorización.", vbInformation, "Validación...")
                                            Exit Sub
                                        Else
                                            Call Validar(Trim(txtOperacion.Text)) 'Call Validar(Trim(LblRTicket.Caption))
                                            Call RegistraAutorizacion(Trim(txtOperacion.Text)) 'Call RegistraAutorizacion(Trim(LblRTicket.Caption))
                                        End If
                                    End If
                                Else
                                    Call Validar(Trim(txtOperacion.Text)) 'Call Validar(Trim(LblRTicket.Caption))
                                End If
                            Else
                                Call Validar(Trim(txtOperacion.Text)) 'Call Validar(Trim(LblRTicket.Caption))
                            End If
                        End If
                    End If
                Else
                    If estatus = 16 Then
                        'Si no tiene la autorizacion de verificación OFAC
                        If Not Autorizacion("AVALOFAC") Then
                            If MsgBox("Validación OFAC, La operación requiere Autorización Remota. ¿Desea Continuar?", vbYesNo + vbQuestion, "Validación...") = vbNo Then
                                Exit Sub
                            Else
                                If Not PideAutorizacion("AVALOFAC", Trim(txtCuenta.Text), 81, Trim(txtMonto.Text)) Then 'Trim(LblRMontRet.Caption)) Then
                                    MsgBox("No es posible validar la operación sin Autorización.", vbInformation, "Validación...")
                                    Exit Sub
                                Else
                                    Call Validar(Trim(txtOperacion.Text)) 'Call Validar(Trim(LblRTicket.Caption))
                                    Call RegistraAutorizacion(Trim(txtOperacion.Text)) 'Call RegistraAutorizacion(Trim(LblRTicket.Caption))
                                End If
                            End If
                        Else
                            Call Validar(Trim(txtOperacion.Text)) 'Call Validar(Trim(LblRTicket.Caption))
                        End If
                    Else
                        Call Validar(Trim(txtOperacion.Text)) 'Call Validar(Trim(LblRTicket.Caption))
                    End If
                End If
            Else
                If estatus = 16 Then
                    'Si no tiene la autorizacion de verificación OFAC
                    If Not Autorizacion("AVALOFAC") Then
                        If MsgBox("Validación OFAC, La operación requiere Autorización Remota. ¿Desea Continuar?", vbYesNo + vbQuestion, "Validación...") = vbNo Then
                            Exit Sub
                        Else
                            If Not PideAutorizacion("AVALOFAC", Trim(txtCuenta.Text), 81, Trim(txtMonto.Text)) Then 'Trim(LblRMontRet.Caption)) Then
                                MsgBox("No es posible validar la operación sin Autorización.", vbInformation, "Validación...")
                                Exit Sub
                            Else
                                Call Validar(Trim(txtOperacion.Text)) 'Call Validar(Trim(LblRTicket.Caption))
                                Call RegistraAutorizacion(Trim(txtOperacion.Text)) 'Call RegistraAutorizacion(Trim(LblRTicket.Caption))
                            End If
                        End If
                    Else
                        Call Validar(Trim(txtOperacion.Text)) 'Call Validar(Trim(LblRTicket.Caption))
                    End If
                Else
                    Call Validar(Trim(txtOperacion.Text)) 'Call Validar(Trim(LblRTicket.Caption))
                End If
            End If
        End If
    End Sub
    '------------------------------------------------------------------
    'Valida la operación poniéndola en status 2
    '------------------------------------------------------------------
    Private Sub Validar(ByRef Operacion As String)
        Dim l As New Libreria
        Dim lsSufijoKapiti As String
        Dim lsFechaKapiti As String
        Dim lsMontoKapiti As String
        Dim lsMontoComision As String
        Dim lsOpComision As String
        Dim lsCampo20 As String '* 3
        Dim lsPrefijo As String
        Dim lsSQLMT As String
        Dim lnSujeto As Byte
        Dim lnBancoEU As Byte
        Dim lnExento As Byte
        Dim lnParcial As Byte
        Dim lnFondosMEX As Byte
        Dim strEventoOperacion As String
        'MARB
        Dim Ls_BancoDest As String
        Dim dtRespConsulta As DataTable

        'Obtiene el estatus de la operacion
        gs_Sql = "select status_operacion from OPERACION WHERE operacion=" & Operacion
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        status = dtRespConsulta.Rows(0).Item(0)
        'dbEndQuery

        'Verifica el tipo de EVENTO OPERACION que se va a realizar
        If estatus = 16 Then
            'frmCausas.Show vbModal
            strEventoOperacion = gs_Sql
            gs_Respuesta = strEventoOperacion
        Else
            strEventoOperacion = "Validación Retiro Orden Pago"
            gs_Respuesta = "Validación Retiro Orden Pago"
        End If

        If status = 0 Or status = 1 Or status = 6 Or status = 16 Then '----- duda
            lsOpComision = ""
            lsMontoComision = "0.00"
            'Busca indicadores de la operación
            gs_Sql = "Select sujeto_a_recepcion, "
            gs_Sql = gs_Sql & "banco_en_EU, "
            gs_Sql = gs_Sql & "excento_comision, "
            gs_Sql = gs_Sql & "parcialmente_sujeto, "
            gs_Sql = gs_Sql & "fondos_bancomer_mex "
            gs_Sql = gs_Sql & "From RETIRO_ORDEN_PAGO "
            gs_Sql = gs_Sql & "Where operacion = " & Operacion
            'dbExecQuery gs_Sql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            If dtRespConsulta IsNot Nothing Then
                lnSujeto = Val(Convert.ToInt32(dtRespConsulta.Rows(0).Item(0)))
                lnBancoEU = Val(Convert.ToInt32(dtRespConsulta.Rows(0).Item(1)))
                lnExento = Val(Convert.ToInt32(dtRespConsulta.Rows(0).Item(2)))
                lnParcial = Val(Convert.ToInt32(dtRespConsulta.Rows(0).Item(3)))
                lnFondosMEX = Val(Convert.ToInt32(dtRespConsulta.Rows(0).Item(4)))
            Else
                'dbEndQuery
                MsgBox("Ocurrio un error al buscar datos de la operación.", vbCritical, "Error")
                Exit Sub
            End If
            'dbEndQuery

            gs_Sql = "Select AG.prefijo_agencia, TC.sufijo_kapiti "
            gs_Sql = gs_Sql & "From OPERACION OP, PRODUCTO_CONTRATADO PC, "
            gs_Sql = gs_Sql & "CUENTA_EJE CE, "
            gs_Sql = gs_Sql & "TIPO_CUENTA_EJE TC, "
            gs_Sql = gs_Sql & "CATALOGOS" & "..AGENCIA AG "
            gs_Sql = gs_Sql & "Where OP.operacion = " & Operacion & " "
            gs_Sql = gs_Sql & "  and PC.producto_contratado = OP.producto_contratado "
            gs_Sql = gs_Sql & "  and CE.producto_contratado = PC.producto_contratado "
            gs_Sql = gs_Sql & "  and TC.tipo_cuenta_eje = CE.tipo_cuenta_eje "
            gs_Sql = gs_Sql & "  and AG.agencia = PC.agencia "
            'Busca el prefijo y sufijo de la cuenta de operación
            'dbExecQuery gs_Sql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            'Encontro el prefijo y sufijo
            If dtRespConsulta IsNot Nothing Then 'If dbError = 0 Then
                lsPrefijo = Trim(dtRespConsulta.Rows(0).Item(0))
                lsSufijoKapiti = Trim(dtRespConsulta.Rows(0).Item(1))
                'No econtro el prefijo y sufijo
            Else
                'dbEndQuery
                MsgBox("Ocurrio un error al buscar el tipo de cuenta de la operación.", vbCritical, "Error")
                Exit Sub
            End If
            'dbEndQuery

            'Se debio generar comisión
            If (lnExento + lnSujeto + lnParcial) = 0 Then
                'Busca datos de la comision que se genero
                gs_Sql = "Select CA.operacion, OP.monto_operacion "
                gs_Sql = gs_Sql & "From "
                gs_Sql = gs_Sql & "OPERACION OP, "
                gs_Sql = gs_Sql & "COMISION_APLICADA CA "
                gs_Sql = gs_Sql & "Where "
                gs_Sql = gs_Sql & "OP.operacion = CA.operacion and "
                gs_Sql = gs_Sql & "CA.operacion_origen = " & Operacion
                'dbExecQuery gs_Sql
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                'Se encontraron los datos de la comisión
                If dtRespConsulta IsNot Nothing Then
                    'Guarda el Ticket de la Comisión en una variable
                    lsOpComision = Trim(dtRespConsulta.Rows(0).Item(0))
                    'Guarda el Monto de la Comisión en una variable
                    lsMontoComision = Format(dtRespConsulta.Rows(0).Item(1)) ', "###,##0.00")
                Else
                    'dbEndQuery
                    MsgBox("Ocurrio un error al buscar datos de la comisión.", vbCritical, "Error")
                    Exit Sub
                End If
                'No se generó comisión pero es SRF o PSRF
            ElseIf lnExento = 0 Then
                gs_Sql = "Select monto "
                gs_Sql = gs_Sql & "From COMISIONES "
                gs_Sql = gs_Sql & "Where "
                gs_Sql = gs_Sql & "agencia = " & gAgencia & " and "
                gs_Sql = gs_Sql & "fecha_valida = ("
                gs_Sql = gs_Sql & "Select max(fecha_valida) "
                gs_Sql = gs_Sql & "From COMISIONES "
                gs_Sql = gs_Sql & "Where "
                gs_Sql = gs_Sql & "agencia = " & gAgencia & " and "
                'El banco esta dentro de E.U.
                If lnBancoEU = 1 Then
                    gs_Sql = gs_Sql & "tipo_comision = 1) and "
                    gs_Sql = gs_Sql & "tipo_comision = 1"
                    'El banco esta fuera de E.U.
                Else
                    gs_Sql = gs_Sql & "tipo_comision = 2) and "
                    gs_Sql = gs_Sql & "tipo_comision = 2"
                End If
                'Busca el monto de la comisión
                'dbExecQuery gs_Sql
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                'No se encontró el monto de la comisión
                If dtRespConsulta Is Nothing Then
                    'dbEndQuery
                    MsgBox("Ocurrió un error al buscar el monto de la comisión.", vbCritical, "Error")
                    Exit Sub
                    'Encontro el monto de la comisión
                Else
                    'Guarda el Monto de la Comisión en una variable
                    lsMontoComision = Format(dtRespConsulta.Rows(0).Item(0), "###,##0.00")
                End If
            End If
            'dbEndQuery

            gs_Sql = "Select "
            gs_Sql = gs_Sql & "usuario = case when UT.usuario_tran is null then UD.usuario_tran else UT.usuario_tran end "
            gs_Sql = gs_Sql & "From "
            gs_Sql = gs_Sql & "OPERACION OP left outer join CATALOGOS..USUARIO_TRANSACCION UT on OP.usuario_captura = UT.usuario, "
            gs_Sql = gs_Sql & "CATALOGOS" & "..USUARIO_TRANSACCION UD "
            gs_Sql = gs_Sql & "Where OP.operacion = " & Operacion & " "
            gs_Sql = gs_Sql & "  and UD.usuario = 0 "
            'dbExecQuery gs_Sql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql) 'Duda no sale nada ¿quien inserta?
            'Ocurrio un error al buscar el usuario de captura
            If dtRespConsulta Is Nothing Then
                'dbEndQuery
                MsgBox("Ocurrió un error al buscar el usuario de captura.", vbCritical, "Error")
                Exit Sub
            Else
                If dtRespConsulta.Rows.Count > 0 Then
                    lsCampo20 = Trim(dtRespConsulta.Rows(0).Item(0))
                Else
                    lsCampo20 = Trim("")
                End If
            End If
            'dbEndQuery
            'Se asegura que la longitud del Campo20 sea de 3 posiciones
            lsCampo20 = Microsoft.VisualBasic.Left(lsCampo20 & "   ", 3)
            'Se debe generar query para reporte MT100
            If Val(lnFondosMEX) = 0 Then
                lsFechaKapiti = CDate(gs_FechaHoy).Year.ToString.Substring(2, 2) & CDate(gs_FechaHoy).Month.ToString().PadLeft(2, "0") & CDate(gs_FechaHoy).Day.ToString().PadLeft(2, "0") 'Microsoft.VisualBasic.Right(gs_FechaHoy, 2) & Mid(gs_FechaHoy, 4, 2) & Microsoft.VisualBasic.Left(gs_FechaHoy, 2)
                lsMontoKapiti = Decimal.Parse(txtMonto.Text).ToString("F2") 'CCur(LblRMontRet)
                lsMontoKapiti = lsMontoKapiti.PadLeft(15, "0") 'Format(lsMontoKapiti, "###########0.00")
                lsMontoKapiti = Microsoft.VisualBasic.Left(lsMontoKapiti, (InStr(lsMontoKapiti, ".") - 1)) & "," & Microsoft.VisualBasic.Right(lsMontoKapiti, 2)

                lsSQLMT = "Insert into REPORTE_SWIFT_MT103 "
                lsSQLMT = lsSQLMT & "(operacion, basic_header, app_header, campo_20, campo_32_date, "
                lsSQLMT = lsSQLMT & "campo_32_ammount, campo_50, campo_53, campo_56_aba, campo_56_cve, "
                lsSQLMT = lsSQLMT & "campo_57_1, campo_57_2, campo_57_3, campo_57_4, campo_57_5, campo_59_1, "
                lsSQLMT = lsSQLMT & "campo_59_2, campo_59_3, campo_59_4, campo_59_5, campo_70_1, campo_70_2, "
                lsSQLMT = lsSQLMT & "campo_70_3, campo_70_4, campo_70_5, campo_71, campo_72_1, campo_72_2, "
                lsSQLMT = lsSQLMT & "campo_72_3, campo_72_4, status_envio, fecha_reporte, campo_23,msg_xml) values ("
                'operacion
                lsSQLMT = lsSQLMT & Operacion
                'basic_header
                lsSQLMT = lsSQLMT & ", 'BCMRMXMMAOPE'"
                'La Agencia es Cayman
                If gAgencia = 3 Then
                    'No requiere complemento posterior
                    If 0 = 0 Then 'If chkComplemento.Value = 0 Then
                        'app_header
                        lsSQLMT = lsSQLMT & ", 'CHASUS33'"
                    Else
                        'app_header
                        lsSQLMT = lsSQLMT & ", 'CHASIS99'"
                    End If
                    'La Agencia es LA o NY
                Else
                    'No requiere complemento posterior
                    If 0 = 0 Then 'If chkComplemento.Value = 0 Then
                        'app_header
                        Ls_BancoDest = ValorParametro("DATOSR1")
                        If InStr(1, Ls_BancoDest, ",") Then
                            Ls_BancoDest = Microsoft.VisualBasic.Left(Ls_BancoDest, InStr(1, Ls_BancoDest, ",") - 1)
                        End If
                        'lsSQLMT = lsSQLMT & ", 'BCMRUS6L'"
                        lsSQLMT = lsSQLMT & ", '" & Ls_BancoDest & "'"
                    Else
                        'app_header
                        lsSQLMT = lsSQLMT & ", 'BCRMUS6L'"
                    End If
                End If
                lsSQLMT = lsSQLMT & ", '" & lsCampo20 & lsFechaKapiti
                lsSQLMT = lsSQLMT & Operacion & "'" 'lsSQLMT = lsSQLMT & Format(Operacion, "0000000") & "'"  'campo_20
                lsSQLMT = lsSQLMT & ", '" & lsFechaKapiti & "'"         'campo_32_date
                lsSQLMT = lsSQLMT & ", '" & lsMontoKapiti & "'"         'campo_32_ammount
                'campo_50
                If Len(Trim(lsMontoKapiti) & Trim(TrimAS400(Microsoft.VisualBasic.Left(CmbAgencia.SelectedItem.ToString().Substring(11, (CmbAgencia.SelectedItem.ToString().Length() - 20)), 35)))) = 19 Then 'LblRClienteOrd, 35)))) = 19 Then
                    lsSQLMT = lsSQLMT & ", '" & TrimAS400(Microsoft.VisualBasic.Left(CmbAgencia.SelectedItem.ToString().Substring(11, (CmbAgencia.SelectedItem.ToString().Length() - 20)), 35)) & ".'"
                Else
                    lsSQLMT = lsSQLMT & ", '" & TrimAS400(Microsoft.VisualBasic.Left(CmbAgencia.SelectedItem.ToString().Substring(11, (CmbAgencia.SelectedItem.ToString().Length() - 20)), 35)) & "'"
                End If
                'La Agencia es Cayman
                'campo_53
                If gAgencia = 3 Then
                    lsSQLMT = lsSQLMT & ", 'BCMRMXMM'"
                    'La Agencia es LA o NY
                Else
                    lsSQLMT = lsSQLMT & ", '" & lsPrefijo & Trim(txtCuenta.Text) & lsSufijoKapiti & "'"
                End If
                'La Agencia es Cayman
                'campo_56_aba
                If gAgencia = 3 Then
                    If TrimAS400(TxtABABI.Text) <> "" Then
                        lsSQLMT = lsSQLMT & ", '//FW" & TrimAS400(TxtABABI.Text) & "'"
                    Else
                        lsSQLMT = lsSQLMT & ", ''"
                    End If
                    'campo_56_cve
                    'lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRdatos1BI.Text) & TrimAS400(txtRdatos2BI.Text)
                    'lsSQLMT = lsSQLMT & TrimAS400(txtRdatos3BI.Text) & " " & TrimAS400(txtRdatos4BI.Text) & "'"
                    lsSQLMT = lsSQLMT & ", '" & TrimAS400("") & TrimAS400("")
                    lsSQLMT = lsSQLMT & TrimAS400("") & " " & TrimAS400("") & "'"
                    lsSQLMT = lsSQLMT & ", '" & TrimAS400("") & TrimAS400("")
                    lsSQLMT = lsSQLMT & TrimAS400("") & " " & TrimAS400("") & "'"
                    'La Agencia es LA o NY
                Else
                    'Es parcialmente/sujeto a recepcion
                    If (lnSujeto = 1) Or (lnParcial = 1) Then
                        'Hay datos de intermediario
                        If (Trim(TxtCableCBI.Text & TxtABABI.Text)) <> "" Then
                            'campo_56_aba
                            lsSQLMT = lsSQLMT & ", ''"
                            If lnSujeto = 1 Then
                                'campo_56_cve
                                lsSQLMT = lsSQLMT & ", 'SUJETO A RECEPCION DE FONDOS'"
                            Else
                                'campo_56_cve
                                lsSQLMT = lsSQLMT & ", 'PARCIAL SUJETO RECEPCION DE FONDOS'"
                            End If
                        Else
                            'campo_56_aba
                            lsSQLMT = lsSQLMT & ", ''"
                            'campo_56_cve
                            lsSQLMT = lsSQLMT & ", ''"
                        End If
                        'No es sujeta a recepcion
                    Else
                        'Existe intermediario
                        If (Trim(TxtCableCBI.Text & TxtABABI.Text)) <> "" Then
                            'campo_56_aba
                            lsSQLMT = lsSQLMT & ", '//FW" & TrimAS400(TxtABABI.Text) & "'"
                            'campo_56_cve
                            lsSQLMT = lsSQLMT & ", '" & TrimAS400(TxtCableCBI.Text) & "'"
                            'No existe intermediario
                        Else
                            'campo_56_aba
                            lsSQLMT = lsSQLMT & ", ''"
                            'campo_56_cve
                            lsSQLMT = lsSQLMT & ", ''"
                        End If
                    End If
                End If

                'La Agencia es Cayman
                If gAgencia = 3 Then
                    'Es parcialmente/sujeto a recepcion de fondos
                    If (lnSujeto = 1) Or (lnParcial = 1) Then
                        If lnSujeto = 1 Then
                            'campo_57_1
                            lsSQLMT = lsSQLMT & ", 'SUJETA A RECEPCION DE FONDOS'"
                        Else
                            'campo_57_1
                            lsSQLMT = lsSQLMT & ", 'PARCIAL SUJETO RECEPCION DE FONDOS'"
                        End If
                        'campo_57_2
                        lsSQLMT = lsSQLMT & ", ''"
                        'campo_57_3
                        lsSQLMT = lsSQLMT & ", ''"
                        'campo_57_4
                        lsSQLMT = lsSQLMT & ", ''"
                        'campo_57_5
                        lsSQLMT = lsSQLMT & ", ''"
                        'Hay ABA de banco intermediario
                    ElseIf Trim(TxtABABI.Text) <> "" Then
                        ''campo_57_1
                        lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRCuentaBC.Text) & "'"
                        'campo_57_2
                        lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos1BC.Text) & "'"
                        'campo_57_3
                        lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos2BC.Text) & "'"
                        'campo_57_4
                        lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos3BC.Text) & "'"
                        'campo_57_5
                        lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos4BC.Text) & "'"
                        'Hay cuenta de corresponsal
                    ElseIf Trim(txtRCuentaBC.Text) <> "" Then
                        ''campo_57_1
                        lsSQLMT = lsSQLMT & ", '//FW" & TrimAS400(txtRCuentaBC.Text) & "'"
                        ''campo_57_2
                        lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos1BC.Text) & "'"
                        'campo_57_3
                        lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos2BC.Text) & "'"
                        'campo_57_4
                        lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos3BC.Text) & "'"
                        'campo_57_5
                        lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos4BC.Text) & "'"
                        'Hay ABA de corresponsal
                    ElseIf Trim(TxtABABC.Text) <> "" Then
                        ''campo_57_1f
                        lsSQLMT = lsSQLMT & ", '//FW" & TrimAS400(TxtABABC.Text) & "'"
                        'campo_57_2
                        lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos1BC.Text) & "'"
                        'campo_57_3
                        lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos2BC.Text) & "'"
                        'campo_57_4
                        lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos3BC.Text) & "'"
                        'campo_57_5
                        lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos4BC.Text) & "'"
                        'campo_57_1
                        lsSQLMT = lsSQLMT & ", '//FW" & TrimAS400(TxtABABC.Text) & "'"
                        'No hay corresponsal y no es sujeta a recepcion
                    Else
                        'campo_57_1
                        lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos1BC.Text) & "'"
                        'campo_57_2
                        lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos2BC.Text) & "'"
                        'campo_57_3
                        lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos3BC.Text) & "'"
                        'campo_57_4
                        lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos4BC.Text) & "'"
                        'campo_57_5
                        lsSQLMT = lsSQLMT & ", ''"
                    End If
                    'La Agencia es LA o NY
                Else
                    'Es parcialmente/sujeto a recepcion
                    If (lnSujeto = 1) Or (lnParcial = 1) Then
                        'Hay banco corresponsal
                        If Trim(TxtABABC.Text & TxtCableCBC.Text) <> "" Then
                            If lnSujeto = 1 Then
                                'campo_57_1
                                lsSQLMT = lsSQLMT & ", 'SUJETA A RECEPCION DE FONDOS'"
                            Else
                                'campo_57_1
                                lsSQLMT = lsSQLMT & ", 'PARCIAL SUJETO RECEPCION DE FONDOS'"
                            End If
                            'campo_57_2
                            lsSQLMT = lsSQLMT & ", ''"
                            'campo_57_3
                            lsSQLMT = lsSQLMT & ", ''"
                            'campo_57_4
                            lsSQLMT = lsSQLMT & ", ''"
                            'campo_57_5
                            lsSQLMT = lsSQLMT & ", ''"
                            'Existe la cuenta del corresponsal
                        ElseIf Trim(txtRCuentaBC.Text) <> "" Then
                            ''campo_57_1
                            lsSQLMT = lsSQLMT & ", '/" & TrimAS400(txtRCuentaBC.Text) & "'"
                            'campo_57_2
                            lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos1BC.Text) & "'"
                            'campo_57_3
                            lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos2BC.Text) & "'"
                            'campo_57_4
                            lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos3BC.Text) & "'"
                            'campo_57_5
                            lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos4BC.Text) & "'"
                            'No hay banco corresponsal ni cuenta
                        Else
                            'campo_57_1
                            lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos1BC.Text) & "'"
                            'campo_57_2
                            lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos2BC.Text) & "'"
                            'campo_57_3
                            lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos3BC.Text) & "'"
                            'campo_57_4
                            lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos4BC.Text) & "'"
                            'campo_57_5
                            lsSQLMT = lsSQLMT & ", ''"
                        End If
                        'No es sujeto a recepcion
                    Else
                        'Hay banco corresponsal
                        If Trim(TxtABABC.Text & TxtCableCBC.Text) <> "" Then
                            'campo_57_1
                            lsSQLMT = lsSQLMT & ", '//FW" & TrimAS400(TxtABABC.Text) & "'"
                            'campo_57_2
                            lsSQLMT = lsSQLMT & ", '" & TrimAS400(TxtCableCBC.Text) & "'"
                            'campo_57_3
                            lsSQLMT = lsSQLMT & ", ''"
                            'campo_57_4
                            lsSQLMT = lsSQLMT & ", ''"
                            'campo_57_5
                            lsSQLMT = lsSQLMT & ", ''"
                            'Existe la cuenta del corresponsal
                        ElseIf Trim(txtRCuentaBC.Text) <> "" Then
                            'campo_57_1
                            lsSQLMT = lsSQLMT & ", '/" & TrimAS400(txtRCuentaBC.Text) & "'"
                            'campo_57_2
                            lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos1BC.Text) & "'"
                            'campo_57_3
                            lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos2BC.Text) & "'"
                            'campo_57_4
                            lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos3BC.Text) & "'"
                            'campo_57_5
                            lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos4BC.Text) & "'"
                            'No existe banco corresponsal ni cuenta
                        Else
                            'campo_57_1
                            lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos1BC.Text) & "'"
                            'campo_57_2
                            lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos2BC.Text) & "'"
                            'campo_57_3
                            lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos3BC.Text) & "'"
                            'campo_57_4
                            lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRDatos4BC.Text) & "'"
                            'campo_57_5
                            lsSQLMT = lsSQLMT & ", ''"
                        End If
                    End If
                End If
                ''campo_59_1
                'lsSQLMT = lsSQLMT & ", '/" & TrimAS400(LblRCuentaBoAP) & "'"
                ''campo_59_2
                'lsSQLMT = lsSQLMT & ", '" & TrimAS400(LblDatosAd1) & "'"
                ''campo_59_3
                'lsSQLMT = lsSQLMT & ", '" & TrimAS400(LblDatosAd2) & "'"
                ''campo_59_4
                'lsSQLMT = lsSQLMT & ", '" & TrimAS400(LblDatosAd3) & "'"
                ''campo_59_5
                'lsSQLMT = lsSQLMT & ", '" & TrimAS400(LblDatosAd4) & "'"
                'campo_59_1
                lsSQLMT = lsSQLMT & ", '/" & TrimAS400(txtRCuentaBoAP.Text) & "'"
                'campo_59_2
                lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtDatosAd1.Text) & "'"
                'campo_59_3
                lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtDatosAd2.Text) & "'"
                'campo_59_4
                lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtDatosAd3.Text) & "'"
                'campo_59_5
                lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtDatosAd4.Text) & "'"
                'campo_70_1
                lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRef1.Text) & "'"
                'campo_70_2
                lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRef2.Text) & "'"
                'campo_70_3
                lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRef3.Text) & "'"
                'campo_70_4
                lsSQLMT = lsSQLMT & ", '" & TrimAS400(txtRef4.Text) & "'"
                'campo_70_5
                lsSQLMT = lsSQLMT & ", ''"
                'campo_71
                lsSQLMT = lsSQLMT & ", 'OUR'"
                'campo_72_1
                lsSQLMT = lsSQLMT & ", '" & lsPrefijo & "'"
                'La Agencia es Cayman
                If gAgencia = 3 Then
                    'campo_72_2
                    lsSQLMT = lsSQLMT & ", ''"
                    'campo_72_3
                    lsSQLMT = lsSQLMT & ", ''"
                    'campo_72_4
                    lsSQLMT = lsSQLMT & ", '"
                    'La Agencia es LA o NY
                Else
                    'campo_72_2
                    lsSQLMT = lsSQLMT & ", '/REC/"
                    'No esta exento de comision
                    If lnExento = 0 Then
                        'campo_72_3
                        lsSQLMT = lsSQLMT & "', 'USD " & Decimal.Parse(lsMontoComision).ToString("N2") & " COMMISSION"
                        'MARB
                        lsSQLMT = lsSQLMT & " " & ValorParametro("LEYENDA" & gAgencia) '" L.A."
                        'Esta exento de comision
                    Else
                        'campo_72_3
                        lsSQLMT = lsSQLMT & "', 'PLEASE DONT CHARGE COMMISSION"
                    End If
                    'Es parcialmente/sujeto a recepcion
                    If (lnSujeto = 1) Or (lnParcial = 1) Then
                        'Hay banco intermediario
                        If Trim(TxtCableCBI.Text & TxtABABI.Text) <> "" Then
                            'campo_72_4
                            lsSQLMT = lsSQLMT & "', '" & TrimAS400(TxtABABI.Text) & " " &
                        TrimAS400(TxtCableCBI.Text)
                            'Hay banco corresponsal
                        ElseIf Trim(TxtCableCBC.Text & TxtABABC.Text) <> "" Then
                            'campo_72_4
                            lsSQLMT = lsSQLMT & "', '" & TrimAS400(TxtABABC.Text) & " " &
                        TrimAS400(TxtCableCBC.Text)
                        Else
                            'campo_72_4
                            lsSQLMT = lsSQLMT & "', '"
                        End If
                        'No es sujeto a recepcion
                    Else
                        'campo_72_4
                        lsSQLMT = lsSQLMT & "', '"
                    End If
                End If
                'status_envio
                lsSQLMT = lsSQLMT & "', 0" '--------- RACB 16/03/2022
                'fecha_reporte, campo_23
                '---------------- RACB
                dtRespConsulta = objDatasource.RealizaConsulta("SELECT convert(char(5),getdate(),14)")
                gs_HoraSistema = dtRespConsulta.Rows(0).Item(0).ToString()
                '---------------- RACB
                lsSQLMT = lsSQLMT & ", '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " " & gs_HoraSistema & "', 'CRED' "
            End If


            'Nueva comlumna para identificar envios de MT o XML
            lsSQLMT = lsSQLMT & ",0)"

            If Decimal.Parse(txtMonto.Text) > 500000 Then 'If ln_monto_operacion > 500000 Then
                If Not l.Permiso("PVALOP501") Then
                    MsgBox("No tiene permisos para validar operaciones mayores a 500 mil Dlls.", vbCritical, "Error")
                    Exit Sub
                End If
            ElseIf Decimal.Parse(txtMonto.Text) > 100000 Then 'ElseIf ln_monto_operacion > 100000 Then
                If Not l.Permiso("PVALOP101") Then
                    MsgBox("No tiene permisos para validar operaciones mayores a 100 mil Dlls.", vbCritical, "Error")
                    Exit Sub
                End If
            End If

            'Inicia Transacción
            'dbBeginTran
            objDatasource.IniciaTransaccion()
            If status = 0 Or status = 1 Or status = 6 Or status = 16 Then 'Duda
                'Valida la Operacion de Retiro (Status = 2)
                gs_Sql = "update OPERACION"
                gs_Sql = gs_Sql & " set status_operacion = 2,"
                gs_Sql = gs_Sql & " usuario_valida = " & userId
                gs_Sql = gs_Sql & " Where operacion = " & Operacion
                'dbExecQuery gs_Sql
                If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
                    'dbRollback
                    objDatasource.RollbackTransaccion()
                    MsgBox("Ocurrió un error al intentar validar la operación.", vbCritical, "Error")
                    Exit Sub
                End If
                'Hay operación de comisión
                If (lnExento + lnSujeto + lnParcial) = 0 Then
                    'dbEndQuery
                    gs_Sql = "Update OPERACION"
                    gs_Sql = gs_Sql & " set status_operacion = 2,"
                    gs_Sql = gs_Sql & " usuario_valida = " & userId
                    gs_Sql = gs_Sql & " Where operacion = " & lsOpComision
                    'Valida la comision generada
                    'dbExecQuery gs_Sql
                    'No se pudo validar la comisión
                    If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
                        'dbRollback
                        objDatasource.RollbackTransaccion()
                        MsgBox("Ocurrió un error al intentar validar la comisión.", vbCritical, "Error")
                        Exit Sub
                    End If
                End If
                'Los fondos no son para Bancomer México
                If Val(lnFondosMEX) = 0 Then
                    'dbEndQuery
                    'Ejecuta el query para generación de MT100
                    'dbExecQuery lsSQLMT
                    If objDatasource.EjecutaComandoTransaccion(lsSQLMT) = False Then
                        'dbRollback
                        objDatasource.RollbackTransaccion()
                        MsgBox("No se pudo generar el reporte swift. La operación no se puede validar.", vbCritical, "Error")
                        Exit Sub
                    End If
                End If
                'dbEndQuery

                'Arma el query para EVENTO_OPERACION el registro de bitacora
                gs_Sql = "Insert into EVENTO_OPERACION ("
                gs_Sql = gs_Sql & "operacion, fecha_evento, status_operacion, "
                gs_Sql = gs_Sql & "comentario_evento, usuario"
                gs_Sql = gs_Sql & ") values ("
                gs_Sql = gs_Sql & Operacion & ",'" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " " & gs_HoraSistema & "', 2, "
                gs_Sql = gs_Sql & "'" & strEventoOperacion & "', " & userId & ")"
                'Inserta registro en EVENTO_OPERACION
                'dbExecQuery gs_Sql
                If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
                    'dbRollback
                    objDatasource.RollbackTransaccion()
                    MsgBox("Ocurrio un error al registrar el Evento de la Operación.", vbCritical, "Error")
                    cmdActualizar.Enabled = False
                    Exit Sub
                End If
                'dbEndQuery

                'Termina la transacción
                'dbCommit
                objDatasource.CommitTransaccion()
                MsgBox("La operación de retiro ha sido validada.", vbInformation, Aplicacion)
                cmdGuardar.Enabled = False
                cmdActualizar.Enabled = False
                dgvTicketsPendientes.DataSource = ""
                'dgvTicketsPendientes.Columns.Clear()
                'dgvTicketsPendientes.Rows.Clear()
                BuscarOperacionesPendientes()
                'Tvarbol.Nodes(Tvarbol.SelectedItem.Index).Image = ObtenImagen(2)
                'Call Muestra(False)
            Else
                gs_Sql = "select descripcion_status from STATUS_OPERACION where status_operacion =" & status
                'dbExecQuery gs_Sql
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                MsgBox("No se puede validar la operación por encontrarse en status: " & status)
                'dbEndQuery
            End If
        Else
            gs_Sql = "select descripcion_status from STATUS_OPERACION where status_operacion = " & status
            'dbExecQuery gs_Sql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            MsgBox("No se puede validar  la operación por encontrarse en status: " & status)
            'dbEndQuery
        End If
    End Sub
    Private Sub GuardarTicket()
        NumAplicacion = 1
        Dim ln_OpDefComision As Integer
        Dim ln_Operacion As Long
        Dim ln_Operacion2 As Long
        Dim ln_Status As Long
        Dim lb_StatusOpera As New Opera000LA
        Dim Ls_Referencia As String
        Dim ln_Saldo As Decimal
        Dim ln_Monto As Decimal
        Dim dtRespConsulta As DataTable
        lb_StatusOpera.CapturaTD = False
        lb_StatusOpera.Continua = False
        If DatosCorrectos() = False Then
            Exit Sub
        End If
        'Si el tipo de cuenta es 000 de LA
        If TipoCuenta() = 4 And gAgencia = 1 Then
            lb_StatusOpera = OperaRet(81, Decimal.Parse(txtSaldo.Text), Decimal.Parse(txtMonto.Text + mn_Comision), Trim(txtCuenta.Text))
            'No puede continuar la operación
            If lb_StatusOpera.Continua = False Then
                MsgBox("No es posible concertar el retiro.", vbInformation, "Aviso")
                Exit Sub
            End If
        End If

        'Si el monto excede del monto normal de operacion
        If Decimal.Parse(txtMonto.Text) >= Monto_Millonario() Then
            If MsgBox("Necesita autorización para operar con montos millonarios." & Chr(13) & "              ¿Desea continuar con la operación?", vbOKCancel + vbInformation, "Autorización Necesaria") = vbOK Then
                If PideAutorizacion("AMONTOMILLONAR", Trim(txtCuenta.Text), mn_OpDefinidaGlob, Decimal.Parse(txtMonto.Text, 4)) = False Then
                    txtMonto.Text = "0.00"
                    If txtMonto.Enabled And txtMonto.Visible Then
                        txtMonto.Focus()
                    End If
                    Exit Sub
                End If
            Else
                txtMonto.Text = "0.00"
                If txtMonto.Enabled And txtMonto.Visible Then
                    txtMonto.Focus()
                End If
                Exit Sub
            End If
        End If

        mn_OpDefinida = OperacionDefinida(mn_OpDefinidaGlob, gAgencia)
        If mn_OpDefinida = 0 Then
            MsgBox("Ocurrio un error la guardar la operación. Se recomienda capturar de nuevo.", vbCritical, "SQL Server Error")
            Exit Sub
        End If

        'If CDate(txtFechaOperacion.text) > CDate(InvierteFecha(gs_FechaHoy)) Then
        If dtpFechaOperacion.Value > CDate(gs_FechaHoy & " " & gs_HoraSistema) Then
            'La operacion es fecha valor futura
            ln_Status = 0
        Else
            'La operacion es fecha valor hoy
            ln_Status = 1
        End If

IniciaTrans:
        'dbBeginTran
        objDatasource.IniciaTransaccion()
        '---------------- RACB
        dtRespConsulta = objDatasource.RealizaConsulta("SELECT convert(char(5),getdate(),14)")
        gs_HoraSistema = dtRespConsulta.Rows(0).Item(0).ToString()
        '---------------- RACB
        gs_Sql = "Insert into OPERACION (producto_contratado, operacion_definida, fecha_captura,"
        gs_Sql = gs_Sql & " status_operacion, fecha_operacion, monto_operacion, usuario_captura,"
        gs_Sql = gs_Sql & " usuario_valida, linea, funcionario, contacto)"
        gs_Sql = gs_Sql & " values (" & GnProductoContratado & ", "
        gs_Sql = gs_Sql & mn_OpDefinida & ", '"
        gs_Sql = gs_Sql & dtpFechaCaptura.Value.ToString("yyyy-MM-dd") & " " & gs_HoraSistema 'InvierteFecha(txtFechaCaptura) & " " & HoraSistema
        gs_Sql = gs_Sql & "', " & ln_Status & ", '"
        gs_Sql = gs_Sql & dtpFechaOperacion.Value.ToString("yyyy-MM-dd") & "', " 'InvierteFecha(txtFechaOperacion.text) & "', "
        gs_Sql = gs_Sql & mn_Monto & ", "
        gs_Sql = gs_Sql & userId & ", null, "
        gs_Sql = gs_Sql & gn_Linea & ", "
        gs_Sql = gs_Sql & cmbFuncionario.SelectedValue & ", " 'cmbFunc.ItemData(cmbFunc.ListIndex) & ", "
        gs_Sql = gs_Sql & "'" & UCase(Trim(DirectCast(cmbFuncionario.SelectedItem, System.Data.DataRowView).Row.ItemArray(1))) & "')" '"'" & UCase(Trim(cmbFunc)) & "')"
        'Registra en la tabla de OPERACION
        'dbExecQuery gs_Sql
        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
            'dbRollback
            objDatasource.RollbackTransaccion()
            If MsgBox("Ocurrido un error al guardar la operación. Se recomienda capturar de nuevo.", vbRetryCancel + vbCritical, "SQL Server Error") = vbRetry Then
                GoTo IniciaTrans
            Else
                Exit Sub
            End If
        End If
        'dbEndQuery
        'dbExecQuery("Select @@IDENTITY")
        If objDatasource.EjecutaComandoTransaccion("Select @@IDENTITY") = False Then
            'dbRollback
            objDatasource.RollbackTransaccion()
            If MsgBox("Ocurrido un error al guardar la operación. Se recomienda capturar de nuevo.", vbRetryCancel + vbCritical, "SQL Server Error") = vbRetry Then
                GoTo IniciaTrans
            Else
                Exit Sub
            End If
        End If
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta("Select @@IDENTITY")
        ln_Operacion = Val(iValorTransaccion)
        'dbEndQuery

        gs_Sql = "Insert into RETIRO_ORDEN_PAGO (operacion, sujeto_a_recepcion, banco_en_EU,"
        gs_Sql = gs_Sql & " fondos_bancomer_mex, excento_comision, aba_intermediario, cve_intermediario,"
        gs_Sql = gs_Sql & " aba_corresponsal, cve_corresponsal, parcialmente_sujeto,contacto)"
        gs_Sql = gs_Sql & " values (" & ln_Operacion & ", "
        'Si esta sujeto a recepción de fondos
        If 0 = 1 Then 'If chkSujetoRF.Value = 1 Then
            gs_Sql = gs_Sql & "1, "
        Else
            gs_Sql = gs_Sql & "0, "
        End If
        'Si el banco dentro de EU.
        If 0 = 1 Then 'If chkBcoEU.Value = 1 Then
            gs_Sql = gs_Sql & "1, "
        Else
            gs_Sql = gs_Sql & "0, "
        End If
        'Si son fondos para bancomer Mexico.
        If 0 = 1 Then 'If chkBancomerMex.Value = 1 Then
            gs_Sql = gs_Sql & "1, "
        Else
            gs_Sql = gs_Sql & "0, "
        End If
        'Si checo exentar comisión.
        If chkExentarCom.Checked = True Then 'If chkExentarCom.Value = 1 Then
            gs_Sql = gs_Sql & "1, "
        Else
            gs_Sql = gs_Sql & "0, "
        End If
        'Si escribio ABA del intermediario
        If Trim(TxtABABI.Text) <> "" Then
            gs_Sql = gs_Sql & "'" & Trim(TxtABABI.Text) & "', "
        Else
            gs_Sql = gs_Sql & "null, "
        End If
        'Si escribio clave del intermediario
        If Trim(TxtCableCBI.Text) <> "" Then
            gs_Sql = gs_Sql & "'" & Trim(TxtCableCBI.Text) & "', "
        Else
            gs_Sql = gs_Sql & "null, "
        End If
        'Si escribio ABA del corresponsal
        If Trim(TxtABABC.Text) <> "" Then
            gs_Sql = gs_Sql & "'" & Trim(TxtABABC.Text) & "', "
        Else
            gs_Sql = gs_Sql & "null, "
        End If
        'Si escribio clave del corresponsal
        If Trim(TxtCableCBC.Text) <> "" Then
            gs_Sql = gs_Sql & "'" & Trim(TxtCableCBC.Text) & "', "
        Else
            gs_Sql = gs_Sql & "null, "
        End If
        'Si esta parcialmente sujeto a recepción de fondos
        If 0 = 1 Then 'If chkParcialSRF.Value = 1 Then
            gs_Sql = gs_Sql & "1,"
        Else
            gs_Sql = gs_Sql & "0,"
        End If
        gs_Sql = gs_Sql & "'" & Trim(DirectCast(cmbFuncionario.SelectedItem, System.Data.DataRowView).Row.ItemArray(1)) & "')" 'gs_sql = gs_sql & "'" & Trim(TxtContacto.text) & "')"
        'Registra en la tabla de RETIRO ORDEN DE PAGO
        'dbExecQuery gs_Sql
        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
            'dbRollback
            objDatasource.RollbackTransaccion()
            If MsgBox("Ocurrido un error al guardar la operación. Se recomienda capturar de nuevo.", vbRetryCancel + vbCritical, "SQL Server Error") = vbRetry Then
                GoTo IniciaTrans
                Exit Sub
            Else
                Exit Sub
            End If
        End If
        iTicketGenerado = ln_Operacion
        If objDatasource.EjecutaComandoTransaccion(GuardarDatosVista()) = False Then '------ Se agragan los datos faltantes RACB 17-03-2022
            'dbRollback
            objDatasource.RollbackTransaccion()
            If MsgBox("Ocurrido un error al guardar la operación. Se recomienda capturar de nuevo.", vbRetryCancel + vbCritical, "SQL Server Error") = vbRetry Then
                GoTo IniciaTrans
            Else
                Exit Sub
            End If
        End If
        'dbEndQuery

        'Inserto un registro en EVENTO_OPERACION
        gs_Sql = "Insert into EVENTO_OPERACION "
        gs_Sql = gs_Sql & " (operacion, fecha_evento, status_operacion,"
        gs_Sql = gs_Sql & " comentario_evento, usuario) "
        gs_Sql = gs_Sql & " values ("
        gs_Sql = gs_Sql & ln_Operacion & ",'" & dtpFechaCaptura.Value.ToString("yyyy-MM-dd") & " " & gs_HoraSistema 'InvierteFecha(txtFechaCaptura) & " " & HoraSistema
        gs_Sql = gs_Sql & "'," & ln_Status & ",'Captura Retiro Orden de Pago'," & userId & ")" 'gn_Usuario & ")"
        'dbExecQuery gs_Sql
        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
            'dbRollback
            objDatasource.RollbackTransaccion()
            If MsgBox("Ha ocurrido un error al guardar la operación.  Se recomienda Cancelar la operación y capturar de nuevo", vbRetryCancel + vbCritical, "Aviso") = vbRetry Then
                GoTo IniciaTrans
            Else
                'ShowDefaultCursor
                Exit Sub
            End If
        End If
        'dbEndQuery

        'Si no es sujeto o parcialmente sujeto a recepción de fondos
        'If (chkSujetoRF.Value = 0) And (chkParcialSRF.Value = 0) Then
        'Si no esta excento de la comision
        If chkExentarCom.Checked = False Then 'If chkExentarCom.Value = 0 Then
            'Obtiene la operacion definida de la comisión por agencia
            ln_OpDefComision = OperacionDefinida(91, gAgencia)
            If ln_OpDefComision = 0 Then
                'dbRollback
                objDatasource.RollbackTransaccion()
                If MsgBox("Ocurrido un error al guardar la operación. Se recomienda capturar de nuevo.", vbRetryCancel + vbCritical, "SQL Server Error") = vbRetry Then
                    GoTo IniciaTrans
                Else
                    Exit Sub
                End If
            End If

            gs_Sql = "Insert into OPERACION (producto_contratado, operacion_definida,"
            gs_Sql = gs_Sql & " fecha_captura, status_operacion, fecha_operacion,"
            gs_Sql = gs_Sql & " monto_operacion, usuario_captura, usuario_valida, linea,"
            gs_Sql = gs_Sql & " funcionario, contacto)"
            gs_Sql = gs_Sql & " values (" & GnProductoContratado & ", " & ln_OpDefComision & ", '"
            gs_Sql = gs_Sql & dtpFechaCaptura.Value.ToString("yyyy-MM-dd") & " " & gs_HoraSistema & "', " & ln_Status & ", '"
            gs_Sql = gs_Sql & dtpFechaOperacion.Value.ToString("yyyy-MM-dd") & "', "
            gs_Sql = gs_Sql & mn_Comision & ", " & userId & ",  null,"
            gs_Sql = gs_Sql & gn_Linea & ", "
            gs_Sql = gs_Sql & cmbFuncionario.SelectedValue & ", "
            gs_Sql = gs_Sql & "'" & UCase(Trim(DirectCast(cmbFuncionario.SelectedItem, System.Data.DataRowView).Row.ItemArray(1))) & "')"
            'Inserta la operacion de la comision
            'dbExecQuery gs_Sql
            If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
                'dbRollback
                objDatasource.RollbackTransaccion()
                If MsgBox("Ocurrido un error al guardar la operación. Se recomienda capturar de nuevo.", vbRetryCancel + vbCritical, "SQL Server Error") = vbRetry Then
                    GoTo IniciaTrans
                Else
                    Exit Sub
                End If
            End If
            'dbEndQuery
            'dbExecQuery("Select @@IDENTITY")
            'dbGetRecord
            If objDatasource.EjecutaComandoTransaccion("Select @@IDENTITY") = False Then
                'dbRollback
                objDatasource.RollbackTransaccion()
                If MsgBox("Ocurrido un error al guardar la operación. Se recomienda capturar de nuevo.", vbRetryCancel + vbCritical, "SQL Server Error") = vbRetry Then
                    GoTo IniciaTrans
                Else
                    Exit Sub
                End If
            End If
            ln_Operacion2 = Val(iValorTransaccion)
            'dbEndQuery

            gs_Sql = "Insert into COMISION_APLICADA (operacion, operacion_origen, tipo_comision)"
            gs_Sql = gs_Sql & " values (" & ln_Operacion2 & ", " & ln_Operacion & ", " & mn_TipoComision & ")"
            'Registra en COMISION_APLICADA por la comision
            'dbExecQuery gs_Sql
            If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
                'dbRollback
                objDatasource.RollbackTransaccion()
                If MsgBox("Ocurrido un error al guardar la operación. Se recomienda capturar de nuevo.", vbRetryCancel + vbCritical, "SQL Server Error") = vbRetry Then
                    GoTo IniciaTrans
                Else
                    Exit Sub
                End If
            End If
            'dbEndQuery
            Ls_Referencia = ln_Operacion2 & " TRANSFER COMMISSION USD"
            gs_Sql = "Insert into REFERENCIAS (operacion, referencia)"
            gs_Sql = gs_Sql & " values (" & ln_Operacion2 & ",'" & Mid(Ls_Referencia, 1, 30) & " ')"
            'Inserta un registro en REFERENCIAS para COMISION
            'dbExecQuery gs_Sql
            If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
                'dbRollback
                objDatasource.RollbackTransaccion()
                If MsgBox("Ocurrido un error al guardar la operación. Se recomienda capturar de nuevo.", vbRetryCancel + vbCritical, "SQL Server Error") = vbRetry Then
                    GoTo IniciaTrans
                Else
                    Exit Sub
                End If
            End If
            'dbEndQuery
        End If
        'End If

        'Revisa nuevamente el saldo por si ya se concertó otra operación
        ln_Saldo = mn_Monto + 0 'ln_Saldo = mn_Monto + ObtenSaldo()
        ln_Monto = mn_Monto
        If chkExentarCom.Checked = False Then
            ln_Saldo = ln_Saldo + mn_Comision
            ln_Monto = ln_Monto + mn_Comision
        End If

        txtSaldo.Text = Format(ln_Saldo, "#,###,##0.00")
        'Obtiene Saldo con Dep Sin Validar
        txtSaldoDep.Text = Format(0, "#,###,##0.00") 'txtSaldoDep.Text = Format(ObtenSaldoDepCom(), "#,###,##0.00")
        txtSaldoTot.Text = Format((Decimal.Parse(txtSaldo.Text) + Decimal.Parse(txtSaldoDep.Text)), "#,###,##0.00")
        If ln_Saldo < ln_Monto Then
            'dbRollback
            objDatasource.RollbackTransaccion()
            MsgBox("No se puede realizar la Orden de Pago porque el monto es mayor al saldo disponible." & Chr(13) & "                               La operación ha sido Cancelada.", vbCritical, "Monto Invalido...")
            Exit Sub
        End If
        'dbCommit
        objDatasource.CommitTransaccion()

        '----------------------- RACB  Duda
        ga_PermisosRemotos = New PermisoRemoto
        PideAutorizacion("ASUJETO", Trim(txtCuenta.Text), mn_OpDefinidaGlob, Decimal.Parse(txtMonto.Text))
        '----------------------- RACB 

        '*** Habilita indicador para refresh en Grid Operaciones frmCliente  STL - TINDE-May/2001
        'bCapturoOperaciones = True
        'txtNumFunc.Locked = True
        'TxtCableCBI.Locked = True
        'TxtCableCBC.Locked = True
        'TxtABABI.Locked = True
        'TxtABABC.Locked = True
        'txtMonto.Locked = True
        'txtFechaOperacion.Locked = True
        'chkSujetoRF.Enabled = False
        'chkParcialSRF.Enabled = False
        'chkExentarCom.Enabled = False
        'chkBancomerMex.Enabled = False
        'chkBcoEU.Enabled = False
        txtOperacion.Text = Format(ln_Operacion, "0000000")
        'Verifica si la operacion se hizo con password
        RegistraAutorizacion(Str(ln_Operacion))
        MsgBox("La operación de retiro ha sido guardada.", vbInformation, Aplicacion)
        MsgBox("El Ticket es: " & Format(ln_Operacion, "0000000"), vbInformation, Aplicacion)
        cmdGuardar.Enabled = False
        'cmdCancelar.Caption = "&Salir"
        'cmdGuardar.Caption = "&Nueva"
    End Sub
    Private Sub ConsultarInformacion()
        Dim dtRespConsulta As DataTable
        Dim iContador As Integer = 0
        Dim ls_CtaCliente As String
        '----------------------- Datos Cliente/Cuenta
        gs_Sql = "Select ag.prefijo_agencia+'-'+cte.cuenta_cliente+' '+"
        gs_Sql = gs_Sql & " rtrim(rtrim(nombre_cliente)+' '+rtrim(apellido_paterno)+"
        gs_Sql = gs_Sql & "' '+rtrim(apellido_materno))+' ('+"
        gs_Sql = gs_Sql & " ag.descripcion_agencia+')', ag.agencia"
        gs_Sql = gs_Sql & " from " & "CATALOGOS" & "..CLIENTE cte,"
        gs_Sql = gs_Sql & " " & "CATALOGOS" & "..AGENCIA ag"
        gs_Sql = gs_Sql & " where cte.agencia = ag.agencia"
        gs_Sql = gs_Sql & " and cuenta_cliente = '" & txtCuenta.Text & "'"
        gs_Sql = gs_Sql & " and ag.agencia =" & gAgencia
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        CmbAgencia.Items.Insert(0, "Selecciona una opción")
        For Each row As DataRow In dtRespConsulta.Rows
            iContador = iContador + 1
            CmbAgencia.Items.Insert(iContador, row.Item(0))
        Next
        iContador = 0
        CmbAgencia.SelectedIndex = 1
        '----------------------- Busca apertura
        gs_Sql = "select fecha_operacion from OPERACION O, OPERACION_DEFINIDA OD Where producto_contratado = ( "
        gs_Sql = gs_Sql & "select  producto_contratado From  PRODUCTO_CONTRATADO Where producto = ("
        gs_Sql = gs_Sql & "select producto From OPERACION_DEFINIDA Where operacion_definida_global = 100"
        gs_Sql = gs_Sql & " and  agencia = " & 1 & ") "
        gs_Sql = gs_Sql & "and cuenta_cliente='" & txtCuenta.Text & "' )"
        gs_Sql = gs_Sql & "and O.operacion_definida=OD.operacion_definida and OD.operacion_definida_global=100"
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta.Rows(0).Item(0) IsNot Nothing And dtRespConsulta.Rows(0).Item(0).ToString() <> "" Then
            dtpApertura.Visible = True
            dtpApertura.Value = CDate(dtRespConsulta.Rows(0).Item(0))
        Else
            dtpApertura.Visible = False
        End If
        '----------------------- Datos Funcionario/Gestor
        If CmbAgencia.SelectedIndex > -1 Then
            ls_CtaCliente = Trim(Mid(CmbAgencia.Text, 6, 6))
        Else
            ls_CtaCliente = ""
        End If
        txtFunc.Text = ""
        txtCuenta.Focus()
        gs_Sql = "select numero_funcionario from Funcionarios..Funcionario where funcionario in (select CD_FUNCIONARIO from TMP_USUARIOAPXTKT where CD_USER = " & userId & ")"
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'gs_Sql = "Select "
        'gs_Sql = gs_Sql & " telefono_funcionario, "
        'gs_Sql = gs_Sql & " fax_funcionario, numero_funcionario, "
        'gs_Sql = gs_Sql & " rtrim(ltrim(nombre_funcionario))+ ' '+"
        'gs_Sql = gs_Sql & " rtrim(ltrim(fu.apellido_paterno))+ ' '+"
        'gs_Sql = gs_Sql & " rtrim(ltrim(fu.apellido_materno)), "
        'gs_Sql = gs_Sql & " cuenta_houston, rtrim(ltrim(co.nombre_cot))+ ' '+rtrim(ltrim(co.paterno_cot))+ ' '+ rtrim(ltrim(materno_cot)), "
        'gs_Sql = gs_Sql & " fu.funcionario "
        'gs_Sql = gs_Sql & " From "
        'gs_Sql = gs_Sql & " CATALOGOS" & "..CLIENTE cl, "
        'gs_Sql = gs_Sql & " FUNCIONARIOS" & "..FUNCIONARIO fu, "
        'gs_Sql = gs_Sql & " CATALOGOS" & "..COTITULAR co "
        'gs_Sql = gs_Sql & " Where "
        'gs_Sql = gs_Sql & " cl.funcionario = fu.funcionario "
        'gs_Sql = gs_Sql & " and cl.cuenta_cliente *= co.cuenta_cliente "
        'gs_Sql = gs_Sql & " and cl.agencia *= co.agencia "
        'gs_Sql = gs_Sql & " and cl.cuenta_cliente = '" & ls_CtaCliente & "' "
        'gs_Sql = gs_Sql & " and cl.agencia = " & gAgencia
        'dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
            txtFunc.Text = Trim(dtRespConsulta.Rows(0).Item(0))
            gs_Sql = "exec " & "FUNCIONARIOS..sp_busca_concertador_operacion '" & UCase(Trim(txtFunc.Text)) & "',' '"
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            cmbFuncionario.ValueMember = "funcionario"
            cmbFuncionario.DisplayMember = "nombre"
            cmbFuncionario.DataSource = dtRespConsulta
            cmbFuncionario.SelectedIndex = 0
        End If
        '----------------------- Busca producto contratado
        gs_Sql = "Select "
        gs_Sql = gs_Sql & " pc.producto_contratado, "
        gs_Sql = gs_Sql & " sp.status_producto_global, pr.producto "
        gs_Sql = gs_Sql & " From"
        gs_Sql = gs_Sql & " PRODUCTO_CONTRATADO pc, "
        gs_Sql = gs_Sql & " STATUS_PRODUCTO sp, PRODUCTO pr "
        gs_Sql = gs_Sql & " Where "
        gs_Sql = gs_Sql & " pc.cuenta_cliente = '" & ls_CtaCliente & "' "
        gs_Sql = gs_Sql & " and pc.agencia = " & gAgencia
        gs_Sql = gs_Sql & " and pc.status_producto = sp.status_producto "
        gs_Sql = gs_Sql & " and pc.producto = pr.producto "
        gs_Sql = gs_Sql & " and pr.producto_global = 9 "
        gs_Sql = gs_Sql & " order by pc.producto "
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        GnProductoContratado = CLng(dtRespConsulta.Rows(0).Item(0))
        '----------------------- Busca saldos
        txtSaldo.Text = Format$(ObtenSaldo(), "###,###,##0.00")
        'Obtiene Saldo con Dep Sin Validar
        txtSaldoDep.Text = Format$(ObtenSaldoDepCom(), "#,###,##0.00")
        'txtSaldoTot = Format((CCur(lblSaldo) + CCur(lblSaldoDep)), "#,###,##0.00")
        txtSaldoTot.Text = Format((Math.Round(Decimal.Parse(txtSaldo.Text), 4) + Math.Round(Decimal.Parse(txtSaldoDep.Text), 4)), "#,###,##0.00")
        'resultado = Decimal.Parse(valor).ToString("#,###,##0.00")
    End Sub
    Private Function encuentraClave(ByVal numeroAba As String, ByVal Agencia As Integer, ByVal campoABA As String) As Boolean
        Dim dtRespConsulta As DataTable
        'On Error GoTo errEncuentra
        'encuentraClave = False

        gs_Sql = "SELECT nombre_telegrafico, nombre_largo, ciudad, elegible_transfer_status FROM "
        gs_Sql = gs_Sql & "CLAVE_CABLEGRAFICA WHERE numero_aba = '" & numeroAba & "'"
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If TxtABABI.Text <> "" Then
            TxtCableCBI.Text = dtRespConsulta.Rows(0).Item(1)
            TxtABABC.Enabled = False
            TxtCableCBC.Enabled = False
        ElseIf TxtABABC.Text <> "" Then
            TxtCableCBC.Text = dtRespConsulta.Rows(0).Item(1)
            TxtABABI.Enabled = False
            TxtCableCBI.Enabled = False
        End If
        encuentraClave = True
        '        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
        '            If StrComp(Trim(dtRespConsulta.Rows(0).Item(3)), "Y", vbTextCompare) = 0 Then
        '                If StrComp(Trim(campoABA), "bc", vbTextCompare) = 0 Then
        '                    If Agencia = 3 Then
        '                        TxtCableCBC.Text = Trim(dtRespConsulta.Rows(0).Item(1)) & " " & Trim(dtRespConsulta.Rows(0).Item(2))
        '                    Else
        '                        TxtCableCBC.Text = Trim(dtRespConsulta.Rows(0).Item(0))
        '                    End If
        '                ElseIf StrComp(Trim(campoABA), "bi", vbTextCompare) = 0 Then
        '                    If Agencia = 3 Then
        '                        TxtCableCBI.Text = Trim(dtRespConsulta.Rows(0).Item(1)) & " " & Trim(dtRespConsulta.Rows(0).Item(2))
        '                    Else
        '                        TxtCableCBI.Text = Trim(dtRespConsulta.Rows(0).Item(0))
        '                    End If
        '                End If
        '            Else
        '                MsgBox("El número de ABA " & numeroAba & " pertenece a un banco no elegible.", vbInformation, "Información")
        '                If StrComp(Trim(campoABA), "bc", vbTextCompare) = 0 Then
        '                    TxtABABC.Text = ""
        '                    TxtCableCBC.Text = ""
        '                    If TxtABABC.Enabled And TxtABABC.Visible Then
        '                        TxtABABC.Focus()
        '                    End If
        '                ElseIf StrComp(Trim(campoABA), "bi", vbTextCompare) = 0 Then
        '                    TxtABABI.Text = ""
        '                    TxtCableCBI.Text = ""
        '                    If TxtABABI.Enabled And TxtABABI.Visible Then
        '                        TxtABABI.Focus()
        '                    End If
        '                End If
        '            End If
        '            'dbEndQuery
        '        Else
        '            MsgBox("No hay Clave Cablegráfica para el número de ABA " & numeroAba & ".", vbInformation, "Información")
        '            If StrComp(Trim(campoABA), "bc", vbTextCompare) = 0 Then
        '                TxtABABC.Text = ""
        '                TxtCableCBC.Text = ""
        '                If TxtABABC.Enabled And TxtABABC.Visible Then
        '                    TxtABABC.Focus()
        '                End If
        '            ElseIf StrComp(Trim(campoABA), "bi", vbTextCompare) = 0 Then
        '                TxtABABI.Text = ""
        '                TxtCableCBI.Text = ""
        '                If TxtABABI.Enabled And TxtABABI.Visible Then
        '                    TxtABABI.Focus()
        '                End If
        '            End If
        '        End If
        '        encuentraClave = True
        '        Exit Function
        'errEncuentra:
        '        MsgBox("Error al encontrar la Clave Cablegráfica.", vbCritical, "Error")
        '        encuentraClave = False
        '        TxtABABC.Text = ""
        '        TxtABABI.Text = ""
        '        TxtCableCBC.Text = ""
        '        TxtCableCBI.Text = ""
        '        If TxtABABC.Enabled And TxtABABC.Visible Then
        '            TxtABABC.Focus()
        '        End If
    End Function
    Private Function GuardarDatosVista() As String
        gs_Sql = "Update RETIRO_ORDEN_PAGO "
        gs_Sql = gs_Sql & "Set aba_intermediario = '" & TxtABABI.Text & "',"
        gs_Sql = gs_Sql & "cve_intermediario = '" & TxtCableCBI.Text & "',"
        gs_Sql = gs_Sql & "aba_corresponsal = '" & TxtABABC.Text & "',"
        gs_Sql = gs_Sql & "cve_corresponsal = '" & TxtCableCBC.Text & "',"
        gs_Sql = gs_Sql & "cta_corresponsal = '" & txtRCuentaBC.Text & "',"
        gs_Sql = gs_Sql & "dato1_corresponsal = '" & txtRDatos1BC.Text & "',"
        gs_Sql = gs_Sql & "dato2_corresponsal = '" & txtRDatos2BC.Text & "',"
        gs_Sql = gs_Sql & "dato3_corresponsal = '" & txtRDatos3BC.Text & "',"
        gs_Sql = gs_Sql & "dato4_corresponsal = '" & txtRDatos4BC.Text & "',"
        gs_Sql = gs_Sql & "cta_beneficiario = '" & txtRCuentaBoAP.Text & "',"
        gs_Sql = gs_Sql & "dato1_beneficiario = '" & txtDatosAd1.Text & "',"
        gs_Sql = gs_Sql & "dato2_beneficiario = '" & txtDatosAd2.Text & "',"
        gs_Sql = gs_Sql & "dato3_beneficiario = '" & txtDatosAd3.Text & "',"
        gs_Sql = gs_Sql & "dato4_beneficiario = '" & txtDatosAd4.Text & "',"
        gs_Sql = gs_Sql & "referencia1 = '" & txtRef1.Text & "',"
        gs_Sql = gs_Sql & "referencia2 = '" & txtRef2.Text & "',"
        gs_Sql = gs_Sql & "referencia3 = '" & txtRef3.Text & "',"
        gs_Sql = gs_Sql & "referencia4 = '" & txtRef4.Text & "',"
        gs_Sql = gs_Sql & "contacto = '" & UCase(Trim(DirectCast(cmbFuncionario.SelectedItem, System.Data.DataRowView).Row.ItemArray(1))) & "' "
        gs_Sql = gs_Sql & " where operacion = " & iTicketGenerado
        'dbExecQuery gs_Sql
        Return gs_Sql
    End Function
    Sub BuscarTicketyLlenar(Opcion As Integer)
        Dim dtRespConsulta As DataTable
        Dim iFunicionario As Integer
        If Opcion = 1 Then
            gs_Sql = "Select convert(char(10), OP.fecha_operacion,105), "
            gs_Sql = gs_Sql & "OP.monto_operacion, "
            gs_Sql = gs_Sql & "PC.producto_contratado, "
            gs_Sql = gs_Sql & "PC.cuenta_cliente "
            gs_Sql = gs_Sql & "From "
            gs_Sql = gs_Sql & "OPERACION OP, "
            gs_Sql = gs_Sql & "PRODUCTO_CONTRATADO PC "
            gs_Sql = gs_Sql & "Where"
            gs_Sql = gs_Sql & " OP.status_operacion in (0,1,12)"
            gs_Sql = gs_Sql & " and OP.operacion = " & txtOperacion.Text
            gs_Sql = gs_Sql & " and PC.producto_contratado = OP.producto_contratado"
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
                txtCuenta.Text = dtRespConsulta.Rows(0).Item(3)
            Else
                MsgBox("No se encontro el ticket", vbInformation, "Dato incorrecto")
            End If
        ElseIf Opcion = 2 Then
            gs_Sql = "SELECT fecha_captura,fecha_operacion,funcionario,monto_operacion,usuario_captura FROM OPERACION WHERE operacion = '" & txtOperacion.Text & "'"
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
                dtpFechaCaptura.Value = CDate(dtRespConsulta.Rows(0).Item(0))
                dtpFechaOperacion.Value = CDate(dtRespConsulta.Rows(0).Item(1))
                iFunicionario = dtRespConsulta.Rows(0).Item(2)
                txtMonto.Text = Format(dtRespConsulta.Rows(0).Item(3), "###,###,##0.00")
                iUsuarioCaptura = dtRespConsulta.Rows(0).Item(4)
            End If
            gs_Sql = "SELECT * FROM RETIRO_ORDEN_PAGO WHERE operacion = " & txtOperacion.Text
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
                chkExentarCom.Checked = Convert.ToBoolean(dtRespConsulta.Rows(0).Item(4).ToString())
                TxtABABI.Text = dtRespConsulta.Rows(0).Item(5)
                TxtCableCBI.Text = dtRespConsulta.Rows(0).Item(6)
                TxtABABC.Text = dtRespConsulta.Rows(0).Item(11)
                TxtCableCBC.Text = dtRespConsulta.Rows(0).Item(12)
                txtRCuentaBC.Text = dtRespConsulta.Rows(0).Item(13)
                txtRDatos1BC.Text = dtRespConsulta.Rows(0).Item(14)
                txtRDatos2BC.Text = dtRespConsulta.Rows(0).Item(15)
                txtRDatos3BC.Text = dtRespConsulta.Rows(0).Item(16)
                txtRDatos4BC.Text = dtRespConsulta.Rows(0).Item(17)
                txtRCuentaBoAP.Text = dtRespConsulta.Rows(0).Item(18)
                txtDatosAd1.Text = dtRespConsulta.Rows(0).Item(19)
                txtDatosAd2.Text = dtRespConsulta.Rows(0).Item(20)
                txtDatosAd3.Text = dtRespConsulta.Rows(0).Item(21)
                txtDatosAd4.Text = dtRespConsulta.Rows(0).Item(22)
                txtRef1.Text = dtRespConsulta.Rows(0).Item(23)
                txtRef2.Text = dtRespConsulta.Rows(0).Item(24)
                txtRef3.Text = dtRespConsulta.Rows(0).Item(25)
                txtRef4.Text = dtRespConsulta.Rows(0).Item(26)
                gs_Sql = "Select numero_funcionario From FUNCIONARIOS..funcionario Where funcionario = " & iFunicionario
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                txtFunc.Text = dtRespConsulta.Rows(0).Item(0)
                gs_Sql = "Select funcionario, rtrim(nombre_funcionario) + ' ' + rtrim(apellido_paterno) + ' ' + rtrim(apellido_materno) nombre From FUNCIONARIOS..FUNCIONARIO Where numero_funcionario = " & txtFunc.Text
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                cmbFuncionario.ValueMember = "funcionario"
                cmbFuncionario.DisplayMember = "nombre"
                cmbFuncionario.DataSource = dtRespConsulta
                cmbFuncionario.SelectedIndex = 0
                cmdGuardar.Enabled = True
                'GroupBox4.Enabled = False
                If iFormularioOrigen = 1 Then
                    cmdGuardar.Enabled = False
                Else
                    cmdGuardar.Enabled = True
                End If
            Else
                MsgBox("No se encontro el ticket", vbInformation, "Dato incorrecto")
            End If
        End If
    End Sub
    '------------------------------------------------------------------------------------------
    'Suma o Resta Dias Naturales a la fecha dada y verifica si dicha fecha no es dia feriado.
    ' Recibe dd-mm-aaaa y regresa dd-mm-aaaa
    '------------------------------------------------------------------------------------------
    Public Function FechaOpera(ByVal Fecha As String, Optional NumDias As Integer = 0) As String
        Dim dtRespConsulta As DataTable
        Dim ls_Cadena As String
        Dim ln_Direccion As Integer
        Dim ln_NumDias As Integer
        Dim ls_Query As String
        Dim g As New Cursors

        ls_Cadena = Trim(Fecha)
        FechaOpera = Trim(Fecha)
        'Si no es una fecha valida, termina
        If Not IsDate(Fecha) Then Exit Function
        'Si le falta un caracter al dia
        If Mid(ls_Cadena, 2, 1) = "-" Or Mid(ls_Cadena, 2, 1) = "/" Then
            ls_Cadena = "0" & ls_Cadena
        End If
        'Si le falta un caracter al mes
        If Mid(ls_Cadena, 5, 1) = "-" Or Mid(ls_Cadena, 5, 1) = "/" Then
            ls_Cadena = Microsoft.VisualBasic.Left(ls_Cadena, 3) & "0" & Mid(ls_Cadena, 4, 6)
        End If
        'Verifica si se deben hacer una operacion con la fecha
        If NumDias > 0 Then 'If Not IsMissing(NumDias) Then
            ln_NumDias = Val(NumDias)
        Else
            ln_NumDias = 0
        End If
        ls_Cadena = DateAdd("d", ln_NumDias, ls_Cadena)

VerificaFecha:
        'Determina el tipo de fechas por verificar
        If gAgencia = 4 Then
            ls_Query = "Select count(*) from " & "CATALOGOS" & "..DIAS_FERIADOS_LONDRES "
            ls_Query = ls_Query & "where fecha = '" & Format(CDate(ls_Cadena), "yyyy-MM-dd") & "'" 'InvierteFecha(ls_Cadena) & "'"
            ls_Query = ls_Query & "and fecha not in (Select fecha_opera_feriado from PARAMETROS)"
        Else
            ls_Query = "Select count(*) from " & "CATALOGOS" & "..DIAS_FERIADOS "
            ls_Query = ls_Query & "where fecha = '" & Format(CDate(ls_Cadena), "yyyy-MM-dd") & "'"
            ls_Query = ls_Query & " and fecha not in (Select fecha_opera_feriado from PARAMETROS)"
        End If
        'dbExecQuery(ls_Query)
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(ls_Query)
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
            'Si la fecha calculada es un dia feriado
            If Val(dtRespConsulta.Rows(0).Item(0)) <> 0 Then
                'dbEndQuery
                If ln_NumDias < 0 Then
                    ls_Cadena = DateAdd("d", -1, ls_Cadena)
                Else
                    ls_Cadena = DateAdd("d", 1, ls_Cadena)
                End If
                GoTo VerificaFecha
            End If
        Else
            'dbEndQuery
            MsgBox("No se puede leer la tabla de Dias Feriados en " & DEFAULT_SRVR & ".", vbCritical, "Error")
            Exit Function
        End If
        'dbEndQuery
        FechaOpera = Microsoft.VisualBasic.Left(Format(CDate(ls_Cadena), "dd/MM/yy"), 6) & DatePart("yyyy", ls_Cadena)
        Dim ver = ""
        'Nuevo DGI 23112006
        'FechaOpera = ValidaFormato(FechaOpera)
        'FechaOpera = Replace(FechaOpera, "/", "-")
    End Function

    '---------------------------------------------------------------
    'Elimina caracteres invalidos para AS400
    '---------------------------------------------------------------
    Private Function TrimAS400(Nombre As String) As String
        Dim lnindice As Byte
        Dim lsCaracter As String
        Dim lsnombre As String

        lsnombre = ""
        Nombre = UCase(Trim(Nombre))
        For lnindice = 1 To Len(Nombre)
            lsCaracter = Mid(Nombre, lnindice, 1)
            If (Asc(lsCaracter) < 65 Or Asc(lsCaracter) > 90) And
            (Asc(lsCaracter) < 97 Or Asc(lsCaracter) > 122) And
            (Asc(lsCaracter) < 48 Or Asc(lsCaracter) > 57) And
            (Asc(lsCaracter) < 44 Or Asc(lsCaracter) > 46) And
            (Asc(lsCaracter) <> 32) Then
                lsCaracter = ""
            End If
            lsnombre = lsnombre & lsCaracter
        Next lnindice
        TrimAS400 = Trim(lsnombre)
    End Function
    Private Sub BuscarOperacionesPendientes()
        Dim dtRespConsulta As DataTable
        'Busca Ordenes de Pago menores o iguales a hoy
        gs_Sql = "Select T1.cuenta_cliente CUENTA,T1.operacion OPERACION,SO.descripcion_interfaz_ced ESTATUS, T1.status_operacion ID_ESTATUS from ( Select PC.cuenta_cliente, OP.operacion, OP.status_operacion "
        gs_Sql = gs_Sql & "From OPERACION OP, PRODUCTO_CONTRATADO PC "
        gs_Sql = gs_Sql & "Where OP.fecha_operacion >= '" & Format((DateAdd("d", -2, CDate(gs_FechaHoy))), "yyyy/MM/dd") & "' "
        gs_Sql = gs_Sql & "and OP.status_operacion in (0,1,12) "
        'gs_Sql = gs_Sql & "  and OP.usuario_captura <> " & gn_Usuario
        gs_Sql = gs_Sql & "and OP.operacion_definida = (SELECT operacion_definida FROM OPERACION_DEFINIDA WHERE operacion_definida_global = 81 AND agencia = 1) "
        gs_Sql = gs_Sql & "and PC.producto_contratado = OP.producto_contratado) T1 inner join STATUS_OPERACION SO on T1.status_operacion = SO.status_operacion "
        gs_Sql = gs_Sql & "order by T1.operacion "
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dgvTicketsPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvTicketsPendientes.DataSource = dtRespConsulta
        For Each dgvRegistro As DataGridViewRow In dgvTicketsPendientes.Rows
            If dgvRegistro.Cells("ID_ESTATUS").Value = 12 Then
                dgvRegistro.DefaultCellStyle.BackColor = Color.LightCoral
            End If
        Next
        dgvTicketsPendientes.Columns("ID_ESTATUS").Visible = False
        dgvTicketsPendientes.AllowUserToAddRows = False
    End Sub
    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Dim lsOpOrigen As Integer
        Dim lsMotivo As String
        Dim dtRespConsulta As DataTable
        If iUsuarioCaptura <> userId Then
            '------------------------------------------------------- RACB 22/03/2023
            Dim objGlobal As New Cursors
            If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
                Exit Sub
            End If
            '------------------------------------------------------- RACB 22/03/2023
            If txtOperacion.Text <> "" Then
                iTicketGenerado = txtOperacion.Text
                lsOpOrigen = 0
                If MsgBox("¿Desea Cancelar la Operación " & iTicketGenerado & "?", vbYesNo + vbQuestion) = vbNo Then
                    Exit Sub
                End If
                lsMotivo = InputBox("¿Cuál fue el motivo de la cancelación del ticket " & iTicketGenerado & "?", "Motivo de la Cancelación")
                If Trim(lsMotivo) <> "" Then
                    lsMotivo = Microsoft.VisualBasic.Left(lsMotivo, 50)
                Else
                    Exit Sub
                End If
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor 'ShowWaitCursor

                'Revisa si la operacion genero comision
                gs_Sql = "Select count(*) "
                gs_Sql = gs_Sql & "From "
                gs_Sql = gs_Sql & "COMISION_APLICADA "
                gs_Sql = gs_Sql & "Where operacion_origen = " & iTicketGenerado 'LblRTicket.Caption
                'dbExecQuery gs_Sql
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                If dtRespConsulta Is Nothing Then
                    'dbEndQuery
                    Me.Cursor = System.Windows.Forms.Cursors.Default 'ShowDefaultCursor
                    MsgBox("No es posible obtener información de la base de datos.", vbCritical, "SQL Server Error")
                    Exit Sub
                End If

                'La operacion genero comision
                If Val(dtRespConsulta.Rows(0).Item(0)) > 0 Then
                    gs_Sql = "Select operacion "
                    gs_Sql = gs_Sql & "From "
                    gs_Sql = gs_Sql & "COMISION_APLICADA "
                    gs_Sql = gs_Sql & "Where operacion_origen = " & iTicketGenerado 'LblRTicket.Caption
                    'Busca la operacion de comisión
                    'dbExecQuery gs_Sql
                    'dbGetRecord
                    dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                    If dtRespConsulta Is Nothing Then
                        'dbEndQuery
                        Me.Cursor = System.Windows.Forms.Cursors.Default 'ShowDefaultCursor
                        MsgBox("No es posible obtener información de la base de datos.", vbCritical, "SQL Server Error")
                        Exit Sub
                    Else
                        lsOpOrigen = CInt(Trim(dtRespConsulta.Rows(0).Item(0)))
                        'dbEndQuery
                    End If
                End If

                objDatasource.IniciaTransaccion() 'dbBeginTran
                'Cancela la operacion
                gs_Sql = "Update OPERACION set"
                gs_Sql = gs_Sql & " status_operacion = 250,"
                gs_Sql = gs_Sql & " usuario_valida = " & userId
                gs_Sql = gs_Sql & " Where operacion = " & iTicketGenerado
                gs_Sql = gs_Sql & " and operacion_definida = (SELECT operacion_definida FROM OPERACION_DEFINIDA WHERE operacion_definida_global = 81 AND agencia = 1)"
                'dbExecQuery gs_Sql
                If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
                    'dbRollback
                    objDatasource.RollbackTransaccion()
                    Me.Cursor = System.Windows.Forms.Cursors.Default 'ShowDefaultCursor
                    MsgBox("No es posible cancelar la operacion.", vbCritical, "SQL Server Error")
                    Exit Sub
                End If
                'dbEndQuery

                'Existe operacion de comision
                If lsOpOrigen > 0 Then
                    gs_Sql = "Update OPERACION set"
                    gs_Sql = gs_Sql & " status_operacion = 250"
                    gs_Sql = gs_Sql & " Where operacion = " & lsOpOrigen
                    'Cancela la operacion de comision
                    'dbExecQuery gs_Sql
                    If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
                        'dbRollback
                        objDatasource.RollbackTransaccion()
                        Me.Cursor = System.Windows.Forms.Cursors.Default 'ShowDefaultCursor
                        MsgBox("No es posible cancelar la operacion.", vbCritical, "SQL Server Error")
                        Exit Sub
                    End If
                    'dbEndQuery
                    '---------------- RACB
                    dtRespConsulta = objDatasource.RealizaConsulta("SELECT convert(char(5),getdate(),14)")
                    gs_HoraSistema = dtRespConsulta.Rows(0).Item(0).ToString()
                    '---------------- RACB
                    gs_Sql = "Insert into EVENTO_OPERACION ("
                    gs_Sql = gs_Sql & "operacion, fecha_evento, "
                    gs_Sql = gs_Sql & "status_operacion, comentario_evento, usuario"
                    gs_Sql = gs_Sql & ") values ("
                    gs_Sql = gs_Sql & lsOpOrigen & ", '" & Format(CDate(gs_FechaHoy), "yyyy/MM/dd") & " " & gs_HoraSistema & "', "
                    gs_Sql = gs_Sql & "250, '" & lsMotivo & "', " & userId & ")"
                    'dbExecQuery gs_Sql
                    If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
                        'dbRollback
                        objDatasource.RollbackTransaccion()
                        Me.Cursor = System.Windows.Forms.Cursors.Default 'ShowDefaultCursor
                        MsgBox("No es posible cancelar la operacion.", vbCritical, "SQL Server Error")
                        Exit Sub
                    End If
                    'dbEndQuery
                End If

                gs_Sql = "Insert into EVENTO_OPERACION ("
                gs_Sql = gs_Sql & "operacion, fecha_evento, "
                gs_Sql = gs_Sql & "status_operacion, comentario_evento, usuario"
                gs_Sql = gs_Sql & ") values ("
                gs_Sql = gs_Sql & iTicketGenerado & ", "
                gs_Sql = gs_Sql & "'" & Format(CDate(gs_FechaHoy), "yyyy/MM/dd") & " " & gs_HoraSistema & "', "
                gs_Sql = gs_Sql & "250, "
                gs_Sql = gs_Sql & "'" & lsMotivo & "', "
                gs_Sql = gs_Sql & userId & ")"
                'Registra el evento de cancelación
                'dbExecQuery gs_Sql
                If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
                    'dbRollback
                    objDatasource.RollbackTransaccion()
                    Me.Cursor = System.Windows.Forms.Cursors.Default 'ShowDefaultCursor
                    MsgBox("No es posible cancelar la operacion.", vbCritical, "SQL Server Error")
                    Exit Sub
                End If
                'dbEndQuery

                'dbCommit
                objDatasource.CommitTransaccion()
                BuscarOperacionesPendientes()
                Call LimpiarCampos()
                cmdCancelar.Enabled = False
                MsgBox("La operación " & iTicketGenerado & " ha sido cancelada.", vbInformation, "Cancelación de Orden de Pago")
                txtCuenta.Text = ""
                Me.Cursor = System.Windows.Forms.Cursors.Default 'ShowDefaultCursor
                'Tvarbol.Nodes(Tvarbol.SelectedItem.Index).Image = ObtenImagen(250)
                'Muestra False
            Else
                MsgBox("Se requiere indicar un ticket", vbInformation, "Error")
            End If
        Else
            MsgBox("No se puede cancelar una operación capturada por el mismo usuario")
        End If
    End Sub
    '--------------------------------------------------------------------------
    'Corrige la operación activa poniéndolo en status 12
    '--------------------------------------------------------------------------
    Private Sub Corregir(ByRef Operacion As String, ByRef OpDefinida As String, iEstatus As Integer)
        Dim dtRespConsulta As DataTable
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor 'ShowWaitCursor
        dtRespConsulta = objDatasource.RealizaConsulta("SELECT operacion_definida FROM OPERACION_DEFINIDA WHERE operacion_definida_global = 81 AND agencia = 1")
        OpDefinida = dtRespConsulta.Rows(0).Item(0)
        objDatasource.IniciaTransaccion() 'dbBeginTran
        'Actualiza la tabla de operación con status 12 (Corregir)
        'Actualiza la tabla de operación con status 1 (corregido)
        gs_Sql = "Update OPERACION set"
        gs_Sql = gs_Sql & " status_operacion = " & iEstatus & ","
        gs_Sql = gs_Sql & " usuario_valida = " & userId
        gs_Sql = gs_Sql & " Where operacion = " & Operacion
        gs_Sql = gs_Sql & " and operacion_definida = " & OpDefinida
        'dbExecQuery gs_Sql
        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
            objDatasource.RollbackTransaccion() 'dbRollback
            Me.Cursor = System.Windows.Forms.Cursors.Default 'ShowDefaultCursor
            MsgBox("No es posible actualizar el status de la operación.", vbCritical, "SQL Server Error")
            Exit Sub
        End If
        'dbEndQuery
        '---------------- RACB
        dtRespConsulta = objDatasource.RealizaConsulta("SELECT convert(char(5),getdate(),14)")
        gs_HoraSistema = dtRespConsulta.Rows(0).Item(0).ToString()
        '---------------- RACB
        'Registro el evento de corrección
        gs_Sql = "Insert into EVENTO_OPERACION ("
        gs_Sql = gs_Sql & "operacion, fecha_evento, status_operacion, "
        gs_Sql = gs_Sql & "comentario_evento, usuario"
        gs_Sql = gs_Sql & ") values ("
        gs_Sql = gs_Sql & Operacion & ", "
        gs_Sql = gs_Sql & "'" & Format(CDate(gs_FechaHoy), "yyyy/MM/dd") & " " & gs_HoraSistema & "', "
        gs_Sql = gs_Sql & iEstatus & ", " '"12, "
        gs_Sql = gs_Sql & "'Corrección Retiro Orden Pago', "
        gs_Sql = gs_Sql & userId & ")"
        'dbExecQuery gs_Sql
        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
            objDatasource.RollbackTransaccion() 'dbRollback
            Me.Cursor = System.Windows.Forms.Cursors.Default 'ShowDefaultCursor
            MsgBox("No es posible actualizar el status de la operación.", vbCritical, "SQL Server Error")
            Exit Sub
        End If
        'dbEndQuery

        objDatasource.CommitTransaccion() 'dbCommit
        'Tvarbol.Nodes(Tvarbol.SelectedItem.Index).Image = ObtenImagen(12)
        'Call Muestra(False)
        Call LimpiarCampos()
        BuscarOperacionesPendientes()
        Me.Cursor = System.Windows.Forms.Cursors.Default 'ShowDefaultCursor
    End Sub
    Private Sub dgvTicketsPendientes_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvTicketsPendientes.CellMouseDoubleClick
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim selectedRow = dgvTicketsPendientes.Rows(e.RowIndex)
            Dim kEnterGenerico As New KeyPressEventArgs(Convert.ToChar(13))
            If dgvTicketsPendientes.Rows.Count > 0 Then
                txtOperacion.Text = selectedRow.Cells(1).Value
                txtOperacion_KeyPress(sender, kEnterGenerico)
                cmdGuardar.Enabled = True
                cmdActualizar.Enabled = True
                GroupBox4.Enabled = False
            End If
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir de operaciones de retiro") <> vbYes Then Exit Sub
        Me.Close()
    End Sub
    Private Sub cmdActualizar_Click(sender As Object, e As EventArgs) Handles cmdActualizar.Click
        If txtOperacion.Text <> "" Then
            '------------------------------------------------------- RACB 22/03/2023
            Dim objGlobal As New Cursors
            If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
                Exit Sub
            End If
            '------------------------------------------------------- RACB 22/03/2023
            If iFormularioOrigen = 1 Then
                iTicketGenerado = txtOperacion.Text
                If objDatasource.insertar(GuardarDatosVista()) > 0 Then
                    Corregir(txtOperacion.Text, "", 1)
                    BuscarOperacionesPendientes()
                    txtOperacion.Text = ""
                    txtCuenta.Text = ""
                    MsgBox("Se actualizo la informacion correctamente", vbInformation, "Error")
                Else
                    MsgBox("No se guardo la nueva informacion", vbInformation, "Error")
                End If
            ElseIf iFormularioOrigen = 2 Then
                If MsgBox("¿Desea corregir la operación " & txtOperacion.Text & "?", vbYesNo + vbQuestion) = vbNo Then
                    Exit Sub
                End If
                Corregir(txtOperacion.Text, "", 12)
                BuscarOperacionesPendientes()
                txtOperacion.Text = ""
                txtCuenta.Text = ""
                cmdActualizar.Enabled = False
            End If
        Else
            MsgBox("Se requiere indicar un ticket", vbInformation, "Error")
        End If
    End Sub

    Private Sub LimpiarCampos()
        txtMonto.Text = ""
        txtOperacion.Text = ""
        txtSaldo.Text = ""
        txtSaldoDep.Text = ""
        txtSaldoTot.Text = ""
        txtFunc.Text = ""
        TxtABABI.Text = ""
        TxtCableCBI.Text = ""
        TxtABABC.Text = ""
        TxtCableCBC.Text = ""
        txtRef1.Text = ""
        txtRef2.Text = ""
        txtRef3.Text = ""
        txtRef4.Text = ""
        dtpApertura.Value = Date.Today
        dtpFechaCaptura.Value = Date.Today
        dtpFechaOperacion.Value = Date.Today
        cmbFuncionario.DataSource = Nothing
        CmbAgencia.Items.Clear()
        CmbAgencia.Text = ""
        txtRCuentaBC.Text = ""
        txtRDatos1BC.Text = ""
        txtRDatos2BC.Text = ""
        txtRDatos3BC.Text = ""
        txtRDatos4BC.Text = ""
        txtRCuentaBoAP.Text = ""
        txtDatosAd1.Text = ""
        txtDatosAd2.Text = ""
        txtDatosAd3.Text = ""
        txtDatosAd4.Text = ""
        BloquearCampos()
    End Sub
    Private Sub BloquearCampos()
        TxtABABI.Enabled = False
        TxtCableCBI.Enabled = False
        TxtABABC.Enabled = False
        TxtCableCBC.Enabled = False
        txtRef1.Enabled = False
        txtRef2.Enabled = False
        txtRef3.Enabled = False
        txtRef4.Enabled = False
        CmbAgencia.Enabled = False
        txtRCuentaBC.Enabled = False
        txtRDatos1BC.Enabled = False
        txtRDatos2BC.Enabled = False
        txtRDatos3BC.Enabled = False
        txtRDatos4BC.Enabled = False
        txtRCuentaBoAP.Enabled = False
        txtDatosAd1.Enabled = False
        txtDatosAd2.Enabled = False
        txtDatosAd3.Enabled = False
        txtDatosAd4.Enabled = False
    End Sub
    Private Sub DesbloquearCampos()
        TxtABABI.Enabled = True
        TxtCableCBI.Enabled = True
        TxtABABC.Enabled = True
        TxtCableCBC.Enabled = True
        txtRef1.Enabled = True
        txtRef2.Enabled = True
        txtRef3.Enabled = True
        txtRef4.Enabled = True
        CmbAgencia.Enabled = True
        txtRCuentaBC.Enabled = True
        txtRDatos1BC.Enabled = True
        txtRDatos2BC.Enabled = True
        txtRDatos3BC.Enabled = True
        txtRDatos4BC.Enabled = True
        txtRCuentaBoAP.Enabled = True
        txtDatosAd1.Enabled = True
        txtDatosAd2.Enabled = True
        txtDatosAd3.Enabled = True
        txtDatosAd4.Enabled = True
    End Sub
End Class