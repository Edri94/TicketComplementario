Public Class ConsultaRetDepTDD

    Const cDeposito = 1
    Const cRetiro = 2

    Dim mn_renglon As Byte
    Private ms_Tabla As String
    Private ms_TipoOp As String
    Private ms_NombreServicio As String


    Private mi_TipoOp As Integer
    Private numOperacion As Integer
    Private numCuenta As Integer


    Public Sub ConsultaRetDepTDD(numOperacion As Integer, mi_TipoOp As Integer, numCuenta As Integer)
        Me.numOperacion = numOperacion
        Me.mi_TipoOp = mi_TipoOp
        Me.numCuenta = numCuenta
    End Sub



    Private Sub ConsultaRetDepTDD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.mi_TipoOp <> 1 And Me.mi_TipoOp <> 2 Then
            MessageBox.Show("Error al cargar tipo de operacion")
            Me.Close()
        Else
            If Me.mi_TipoOp = cDeposito Then
                ms_Tabla = "DEPOSITO_CED"
                ms_TipoOp = "Deposito"
            Else
                ms_Tabla = "RETIRO_CED"
                ms_TipoOp = "Retiro"
            End If
        End If

        Me.Text = $"Consulta de {Me.ms_TipoOp}"
        GroupBox1.Text = $"Detalle del {Me.ms_TipoOp}"
        LlenaCampos()
    End Sub

    Private Sub LlenaCampos()
        Dim ln_ProdCont As Long
        Dim ls_TipoSuc As String
        Dim Ln_Docto As Integer
        Dim Ln_Moneda As Integer
        Dim ln_Detalle As Integer
        Dim ls_Func As String
        Dim lsCodigoMP As String

        txtNumOperacion.Text = Me.numOperacion
        txtNumCuenta.Text = numCuenta

        Using ticket_cntx As New TICKETEntities
            Using catalogo_cntx As New CATALOGOSEntities
                Using funcionario_cntx As New FUNCIONARIOSEntities
                    Dim operacion As OPERACION = (From o In ticket_cntx.OPERACION
                                                  Join pc In ticket_cntx.PRODUCTO_CONTRATADO On pc.producto_contratado1 Equals o.producto_contratado
                                                  Join od In ticket_cntx.OPERACION_DEFINIDA On od.operacion_definida1 Equals o.operacion_definida
                                                  Where o.operacion1 = Me.numOperacion
                                                  Select o).FirstOrDefault()

                    If operacion IsNot Nothing Then
                        txtFechaOperacion.Text = operacion.fecha_operacion
                        txtMonto.Text = operacion.monto_operacion
                        txtUsuarioCapt.Text = catalogo_cntx.USUARIO.Where(Function(w) w.usuario1 = operacion.usuario_captura).FirstOrDefault().nombre_usuario
                        txtFuncionario.Text = funcionario_cntx.FUNCIONARIO.Where(Function(w) w.funcionario1 = operacion.funcionario).FirstOrDefault().nombre_funcionario
                        txtFechaCaptura.Text = operacion.fecha_captura
                        pnlCancelada.Visible = If(operacion.status_operacion = 250, True, False)
                        txtOperacionDefinida.Text = $"{operacion.OPERACION_DEFINIDA1.code_kapiti_cliente} {operacion.OPERACION_DEFINIDA1.descripcion_kapiti}"
                        txtMontoTipoCambio.Text = operacion.monto_operacion
                    End If

                    ObtenerStatusOpSw(operacion)

                    'Busca el BPIGO del funcionario que capturo la operacion
                    Dim funcionario As FUNCIONARIO = (From f In funcionario_cntx.FUNCIONARIO
                                                      Where f.funcionario1 = operacion.funcionario
                                                      Select f).FirstOrDefault()

                    txtNumFuncionario.Text = funcionario.numero_funcionario

                    'Verifica los datos del saldo del cliente
                    Dim concepto As CONCEPTO = (From c In ticket_cntx.CONCEPTO
                                                Join cd In ticket_cntx.CONCEPTO_DEFINIDO On c.concepto_definido Equals cd.concepto_definido1
                                                Where c.producto_contratado = operacion.producto_contratado And cd.concepto_definido_global = 5
                                                Select c).FirstOrDefault()

                    txtSaldo.Text = concepto.valor_concepto

                    'Verifica el dato de Operacion PIU
                    Dim operacion_piu As OPERACION_PIU = (From op In ticket_cntx.OPERACION_PIU
                                                          Where op.operacion = operacion.operacion1
                                                          Select op).FirstOrDefault()

                    If operacion_piu IsNot Nothing Then
                        txtTicketPIU.Text = $"REF={txtNumOperacion.Text} SLIP={operacion_piu.operacion_piu1}"
                    Else
                        Dim operacion_piu_batch As OPERACION_PIU_BATCH = (From opb In ticket_cntx.OPERACION_PIU_BATCH
                                                                          Where opb.operacion = operacion.operacion1
                                                                          Select opb).FirstOrDefault()

                        If operacion_piu_batch IsNot Nothing Then
                            txtTicketPIU.Text = $"REF={txtNumOperacion.Text} SLIP={operacion_piu_batch.operacion_piu_tk}"
                        Else
                            txtTicketPIU.Text = $"REF={txtNumOperacion.Text}"
                        End If
                    End If

                    'Verifica los datos de Retiro TDD
                    If Me.mi_TipoOp = cDeposito Then
                        Dim deposito As DEPOSITO_CED = (From dc In ticket_cntx.DEPOSITO_CED
                                                        Where dc.operacion = operacion.operacion1
                                                        Select dc).FirstOrDefault()

                        txtObservaciones.Text = deposito.referencia
                        txtTraduccionReferencia.Text = deposito.referencia
                        txtMontoTipoCambio.Text = $"{txtMontoTipoCambio.Text} {deposito.tipo_cambio}"

                        lsCodigoMP = deposito.codigo_leyenda


                    Else
                        Dim retiro As RETIRO_CED = (From rc In ticket_cntx.RETIRO_CED
                                                    Where rc.operacion = operacion.operacion1
                                                    Select rc).FirstOrDefault()

                        txtObservaciones.Text = retiro.referencia
                        txtTraduccionReferencia.Text = retiro.referencia
                        txtMontoTipoCambio.Text = $"{txtMontoTipoCambio.Text} {retiro.tipo_cambio}"

                        lsCodigoMP = retiro.codigo_leyenda

                    End If

                    'Verifica los datos de Leyendas TDD
                    Dim codigo_operacion_ced As CODIGO_OPERACION_CED = (From coe In ticket_cntx.CODIGO_OPERACION_CED
                                                                        Where coe.codigo_leyenda = lsCodigoMP
                                                                        Select coe).FirstOrDefault()

                    txtTraduccionReferencia.Text = $"{codigo_operacion_ced.traduccion} {txtTraduccionReferencia.Text}"

                End Using
            End Using
        End Using


    End Sub

    Private Sub ObtenerStatusOpSw(operacion As OPERACION)
        Dim status_operacion = "", status_bitacora = ""
        Select Case operacion.status_operacion
            Case 0
                status_operacion = "Sin Validar"
            Case 1
                status_operacion = "Sin Validar"
            Case 2
                status_operacion = "Validado"
            Case 3
                status_operacion = "Validado"
            Case 4
                status_operacion = "Validado EQ"
            Case 5
                status_operacion = "Rechazado EQ"
            Case 6
                status_operacion = "Complementado"
            Case 12
                status_operacion = "Rechazado"
            Case 16
                status_operacion = "Rechazado"
            Case 220
                status_operacion = "Sin Validar"
            Case 250
                status_operacion = "Cancelado"
        End Select

        Dim operacion_swift As OPERACION_SWIFT
        Dim bitacora As BITACORA_ENVIO_SWIFT = New BITACORA_ENVIO_SWIFT()

        Using contexto As New TICKETEntities
            operacion_swift = contexto.OPERACION_SWIFT.Where(Function(w) w.operacion = numOperacion).FirstOrDefault()
            If operacion_swift IsNot Nothing Then
                bitacora = contexto.BITACORA_ENVIO_SWIFT.Where(Function(w) w.no_rep_swift = operacion_swift.no_rep_swift).FirstOrDefault()
            End If

            Select Case bitacora.status_envio
                Case 3
                    status_bitacora = "Enviado SW"
                Case 4
                    status_bitacora = "Validado SW"
                Case 5
                    status_bitacora = "Rechazado SW"
                Case Else
                    status_bitacora = "Pendiente SW"
            End Select

            lblStatusOp.Text = status_operacion
            lblStatusSw.Text = status_bitacora
        End Using
    End Sub

    Private Sub cmdCierra_Click(sender As Object, e As EventArgs) Handles cmdCierra.Click
        Me.Close()
    End Sub
End Class