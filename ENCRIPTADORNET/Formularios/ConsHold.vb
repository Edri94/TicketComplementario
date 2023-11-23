Public Class ConsHold
    Public Property prod As Short
    Public Property MiTipoHold As Integer
    Public Property MnStatusProd As Integer

    Const ci_HoldTDD As Integer = 14
    Const ci_Hold As Integer = 12



    Private Sub ConsHold_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim producto_contratado As PRODUCTO_CONTRATADO = New PRODUCTO_CONTRATADO
        Dim evento As EVENTO_PRODUCTO = New EVENTO_PRODUCTO
        Dim usuario As USUARIO = New USUARIO
        Dim idUsuario As Short

        txtFechaContratacion.Enabled = False
        txtFechaEq.Enabled = False
        txtFechaVenc.Enabled = False

        'Obtiene todos los datos de Hold
        Using contexto1 As New TICKETEntities
            producto_contratado = (From pc In contexto1.PRODUCTO_CONTRATADO
                                   Join h In contexto1.HOLD On pc.producto_contratado1 Equals h.producto_contratado
                                   Join c In contexto1.CONCEPTO On pc.producto_contratado1 Equals c.producto_contratado
                                   Join sp In contexto1.STATUS_PRODUCTO On pc.status_producto Equals sp.status_producto1
                                   Where pc.producto_contratado1 <> prod
                                   Select pc).FirstOrDefault() 'prueba

            If producto_contratado IsNot Nothing Then
                txtNumCuenta.Text = producto_contratado.cuenta_cliente
                txtFechaContratacion.Value = producto_contratado.fecha_contratacion
                txtFechaVenc.Value = If(producto_contratado.fecha_vencimiento.HasValue, producto_contratado.fecha_vencimiento.Value, txtFechaVenc.MinDate)
                txtFechaEq.Value = producto_contratado.HOLD.FirstOrDefault().fecha_equation
                txtMontoHold.Text = producto_contratado.CONCEPTO.FirstOrDefault().valor_concepto
                lblCancela.Text = producto_contratado.STATUS_PRODUCTO1.descripcion_status
                txtDesc1.Text = producto_contratado.HOLD.FirstOrDefault().descripcion1
                txtDesc2.Text = producto_contratado.HOLD.FirstOrDefault().descripcion2
                txtDesc3.Text = producto_contratado.HOLD.FirstOrDefault().descripcion3
                txtDesc4.Text = producto_contratado.HOLD.FirstOrDefault().descripcion4
                txtUsuarioEq.Text = producto_contratado.HOLD.FirstOrDefault().usuario_equation
                MnStatusProd = producto_contratado.STATUS_PRODUCTO1.status_producto_global
            End If

            If MnStatusProd = 42 Then
                evento = (From ep In contexto1.EVENTO_PRODUCTO
                          Join pc In contexto1.PRODUCTO_CONTRATADO On ep.producto_contratado Equals pc.producto_contratado1
                          Join sp In contexto1.STATUS_PRODUCTO On pc.status_producto Equals sp.status_producto1
                          Where sp.status_producto_global = 42 And pc.producto_contratado1 = prod
                          Select ep).FirstOrDefault()
                idUsuario = evento.usuario


                Using contexto2 As New CATALOGOSEntities
                    usuario = (From u In contexto2.USUARIO
                               Where u.usuario1 = idUsuario
                               Select u).FirstOrDefault()

                    lblFechaCancela.Text = evento.fecha_evento
                    lblUsuarioCancela.Text = usuario.nombre_usuario
                    lblMotivoCancela.Text = evento.comentario_evento

                End Using


            End If
        End Using


        If MiTipoHold = ci_HoldTDD Then
            ModoHoldTDD()
            CargaHoldRetiro()
        End If

    End Sub

    Private Sub CargaHoldRetiro()
        'Retencion de fondos
        Using contexto As New TICKETEntities
            Dim hold_retiro As HOLD_RETIRO = (From hr In contexto.HOLD_RETIRO
                                              Where hr.producto_contratado = prod
                                              Select hr).FirstOrDefault()

            If hold_retiro IsNot Nothing Then
                txtProdContratado.Text = prod
                txtHold.Text = hold_retiro.hold
                txtOpRetiro.Text = hold_retiro.operacion_retiro
                txtOpHold.Text = hold_retiro.operacion_hold

                Select Case hold_retiro.tipo
                    Case "A"
                        txtRetencionFondos.Text = "Activo"
                    Case "V"
                        txtRetencionFondos.Text = "Aplicada"
                    Case "C"
                        txtRetencionFondos.Text = "Cancelada"
                End Select
            Else
                MessageBox.Show("Problemas al recuperar la informacion de HOLD_RETIRO")
            End If
        End Using

    End Sub

    Private Sub ModoHoldTDD()
        lblProducto.Visible = True
        lblHold.Visible = True
        lblOpRetiro.Visible = True
        lblOpHold.Visible = True

        txtProdContratado.Visible = True
        txtHold.Visible = True
        txtOpRetiro.Visible = True
        txtOpHold.Visible = True
        txtRetencionFondos.Visible = True


    End Sub
End Class