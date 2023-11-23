Imports System.Data.SqlClient

Public Class ConsultaTraspasos
    Public numOperacion, numCuenta As Integer

    Public Sub ConsultaTraspasos(numOperacion As Integer, numCuenta As Integer)
        Me.numOperacion = numOperacion
        Me.numCuenta = numCuenta
    End Sub

    Private Sub ConsultaTraspasos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenaCampos()
    End Sub

    Private Sub cmdCierra_Click(sender As Object, e As EventArgs) Handles cmdCierra.Click
        Me.Close()
    End Sub

    Private Sub LlenaCampos()
        txtNumOperacion.Text = numOperacion

        Using ticket_cntx As New TICKETEntities
            Using catalogo_cntx As New CATALOGOSEntities
                Using funcionario_cntx As New FUNCIONARIOSEntities
                    Dim traspaso As DetalleTraspaso =
                        (From t In ticket_cntx.TRASPASO
                         Join o In ticket_cntx.OPERACION On t.operacion Equals o.operacion1
                         Join pc In ticket_cntx.PRODUCTO_CONTRATADO On pc.producto_contratado1 Equals o.producto_contratado
                         Where o.operacion1 = numOperacion
                         Select New DetalleTraspaso With {
                                                   .cuentaCliente = pc.cuenta_cliente,
                                                   .operacion = o.operacion1,
                                                   .fechaCaptura = o.fecha_captura,
                                                   .montoOperacion = o.monto_operacion,
                                                   .linea = o.linea,
                                                   .fechaOperacion = o.fecha_operacion,
                                                   .causa = t.causa,
                                                   .cuentaDestino = t.cuenta_destino,
                                                   .contacto = "",
                                                   .usuarioCaptura = o.usuario_captura,
                                                   .numFuncionario = o.funcionario,
                                                   .statusOp = o.status_operacion
                                                }).FirstOrDefault()

                    traspaso.usuario = catalogo_cntx.USUARIO.Where(Function(w) w.usuario1 = traspaso.usuarioCaptura).FirstOrDefault()
                    traspaso.funcionario = funcionario_cntx.FUNCIONARIO.Where(Function(w) w.funcionario1 = traspaso.numFuncionario).FirstOrDefault()

                    txtNumCuenta.Text = traspaso.cuentaCliente
                    txtNumOperacion.Text = traspaso.operacion
                    txtFechaCaptura.Text = traspaso.fechaCaptura
                    txtMonto.Text = traspaso.montoOperacion
                    txtLinea.Text = traspaso.linea
                    txtFechaOperacion.Text = traspaso.fechaOperacion
                    txtCausa.Text = traspaso.causa
                    txtDestino.Text = traspaso.cuentaDestino
                    txtUsuarioCapt.Text = traspaso.usuario.nombre_usuario
                    txtNumFuncionario.Text = traspaso.funcionario.numero_funcionario
                    txtFuncionario.Text = traspaso.funcionario.nombre_funcionario

                    If traspaso.statusOp = 250 Then
                        Dim query As String = "
                            select 
	                            convert(char(25),fecha_evento,105),        
	                            U.nombre_usuario,                        
	                            e.comentario_evento                      
	                            from 
	                            TICKET.dbo.EVENTO_OPERACION e, 
	                            TICKET.dbo.OPERACION o, 
	                            CATALOGOS.dbo.USUARIO u 
                            Where 
	                            o.operacion = @operacion
	                            and e.status_operacion = 250 
	                            and o.operacion = e.operacion 
	                            and e.usuario = U.usuario"

                        Dim evento As EVENTO_OPERACION = ticket_cntx.Database.SqlQuery(Of EVENTO_OPERACION)(query, New SqlParameter("@operacion", numOperacion)).FirstOrDefault()
                        lblfechacancela.Text = evento.fechaEvento
                        lblusuariocancela.Text = evento.usuario.nombre_usuario
                        lblMotivoCan.Text = evento.comentarioEvento
                    End If

                    'Si tiene Detalle de Autorizacion habilita el botón cmdAutorizacion
                    Dim autorizacion As DETALLE_AUTORIZACION = (From da In ticket_cntx.DETALLE_AUTORIZACION
                                                                Join ea In ticket_cntx.ESTADO_AUTORIZACION On da.estado_autorizacion Equals ea.estado_autorizacion1
                                                                Where da.operacion = numOperacion
                                                                Select da).FirstOrDefault()

                    If autorizacion Is Nothing Then
                        cmdAutorizacion.Enabled = False
                    Else
                        If autorizacion.numero_autorizacion <> "" Then
                            cmdAutorizacion.Enabled = True
                        Else
                            cmdAutorizacion.Enabled = False
                        End If
                    End If

                End Using
            End Using
        End Using

    End Sub

    Private Class DetalleTraspaso
        Private _prefijoAgencia As String
        Public Property prefijoAgencia() As String
            Get
                Return _prefijoAgencia
            End Get
            Set(ByVal value As String)
                _prefijoAgencia = value
            End Set
        End Property

        Private _cuentaCliente As String
        Public Property cuentaCliente() As String
            Get
                Return _cuentaCliente
            End Get
            Set(ByVal value As String)
                _cuentaCliente = value
            End Set
        End Property

        Private _operacion As Integer
        Public Property operacion() As Integer
            Get
                Return _operacion
            End Get
            Set(ByVal value As Integer)
                _operacion = value
            End Set
        End Property

        Private _fechaCaptura As DateTime
        Public Property fechaCaptura() As DateTime
            Get
                Return _fechaCaptura
            End Get
            Set(ByVal value As DateTime)
                _fechaCaptura = value
            End Set
        End Property

        Private _montoOperacion As Decimal
        Public Property montoOperacion() As Decimal
            Get
                Return _montoOperacion
            End Get
            Set(ByVal value As Decimal)
                _montoOperacion = value
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

        Private _fechaOperacion As DateTime
        Public Property fechaOperacion() As DateTime
            Get
                Return _fechaOperacion
            End Get
            Set(ByVal value As DateTime)
                _fechaOperacion = value
            End Set
        End Property

        Private _causa As String
        Public Property causa() As String
            Get
                Return _causa
            End Get
            Set(ByVal value As String)
                _causa = value
            End Set
        End Property

        Private _cuentaDestino As String
        Public Property cuentaDestino() As String
            Get
                Return _cuentaDestino
            End Get
            Set(ByVal value As String)
                _cuentaDestino = value
            End Set
        End Property

        Private _usuario As USUARIO
        Public Property usuario() As USUARIO
            Get
                Return _usuario
            End Get
            Set(ByVal value As USUARIO)
                _usuario = value
            End Set
        End Property

        Private _funcionario As FUNCIONARIO
        Public Property funcionario() As FUNCIONARIO
            Get
                Return _funcionario
            End Get
            Set(ByVal value As FUNCIONARIO)
                _funcionario = value
            End Set
        End Property

        Private _numFuncionario As Integer
        Public Property numFuncionario() As Integer
            Get
                Return _numFuncionario
            End Get
            Set(ByVal value As Integer)
                _numFuncionario = value
            End Set
        End Property

        Private _contacto As String
        Public Property contacto() As String
            Get
                Return _contacto
            End Get
            Set(ByVal value As String)
                _contacto = value
            End Set
        End Property

        Private _statusOp As Integer
        Public Property statusOp() As Integer
            Get
                Return _statusOp
            End Get
            Set(ByVal value As Integer)
                _statusOp = value
            End Set
        End Property

        Private _grabadora As Integer
        Public Property grabadora() As Integer
            Get
                Return _grabadora
            End Get
            Set(ByVal value As Integer)
                _grabadora = value
            End Set
        End Property

        Private _usuarioCaptura As Integer
        Public Property usuarioCaptura() As Integer
            Get
                Return _usuarioCaptura
            End Get
            Set(ByVal value As Integer)
                _usuarioCaptura = value
            End Set
        End Property
    End Class
End Class