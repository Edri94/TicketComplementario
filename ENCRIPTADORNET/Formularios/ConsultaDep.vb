Public Class ConsultaDep

    Private numOperacion, numCuenta As Integer

    Public Sub ConsultaDep(numOperacion As Integer, numCuenta As Integer)
        Me.numOperacion = numOperacion
        Me.numCuenta = numCuenta
    End Sub


    Private Sub ConsultaDep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenaCampos()
    End Sub

    Private Sub LlenaCampos()
        Dim operacion As OPERACION
        Using ticket_cntx As New TICKETEntities
            Using funcionario_cntx As New FUNCIONARIOSEntities
                Using catalogos_cntx As New CATALOGOSEntities
                    'Obtenemos la fecha de operación, el monto y el número de operación definida
                    operacion = (
                        From o In ticket_cntx.OPERACION
                        Join pc In ticket_cntx.PRODUCTO_CONTRATADO On pc.producto_contratado1 Equals o.producto_contratado
                        Where o.operacion1 = numOperacion
                        Select o
                ).FirstOrDefault()

                    txtNumOperacion.Text = numOperacion
                    txtFechaOperacion.Text = operacion.fecha_operacion
                    txtMonto.Text = operacion.monto_operacion
                    txtNumCuenta.Text = numCuenta
                    txtUsuarioCapt.Text = catalogos_cntx.USUARIO.Where(Function(w) w.usuario1 = operacion.usuario_captura).FirstOrDefault().nombre_usuario
                    txtFuncionario.Text = operacion.contacto
                    txtFechaCaptura.Text = operacion.fecha_captura
                    pnlCancelada.Visible = If(operacion.status_operacion = 250, True, False)
                    lblGrabadora.Text = If(operacion.grabadora IsNot Nothing, operacion.grabadora.Value, "")

                    'Establece la información para status Equation y/o Swift
                    ObtenerStatusOpSw(operacion)


                    If operacion.funcionario.HasValue Then
                        If operacion.funcionario.Value > 0 Then
                            'Busca el BPIGO del funcionario que capturo la operacion
                            Dim funcionario = funcionario_cntx.FUNCIONARIO.Where(Function(w) w.funcionario1 = operacion.funcionario.Value).FirstOrDefault()
                        End If
                    End If

                    'Verifica datos de la sucursal
                    Dim deposito_pme = ticket_cntx.DEPOSITO_PME.Where(Function(w) w.operacion = operacion.operacion1).FirstOrDefault()

                    If deposito_pme IsNot Nothing Then
                        txtNumCR.Text = deposito_pme.centro_regional
                        txtCR.Text = deposito_pme.nombre_centro_regional
                        txtNumPlaza.Text = deposito_pme.plaza
                        txtPlaza.Text = deposito_pme.nombre_plaza
                        txtNumSucursal.Text = deposito_pme.sucursal
                        txtSucursal.Text = deposito_pme.nombre_sucursal
                        txtCed.Text = deposito_pme.referencia
                        txtCausa.Text = deposito_pme.causa
                    End If

                    'Verifica datos del Tipo de Documento,  datos del folio de la linea de servicio y del tipo de moneda
                    'Dim documento As TIPO_DOCUMENTO = contexto1.TIPO_DOCUMENTO.Join(contexto1.DEPOSITO.Where(Function(w) w.operacion = operacion.operacion1), Function(td) td.tipo_documento1, Function(d) d.tipo_documento, Function(td, d) td).FirstOrDefault()
                    Dim documento As DetalleDocumento = (From td In ticket_cntx.TIPO_DOCUMENTO
                                                         Join d In ticket_cntx.DEPOSITO On td.tipo_documento1 Equals d.tipo_documento
                                                         Join tm In ticket_cntx.TIPO_MONEDA On d.tipo_moneda Equals tm.tipo_moneda1
                                                         Where d.operacion = operacion.operacion1
                                                         Select New DetalleDocumento With {.descDoc = td.descripcion_documento, .descMoneda = tm.descripcion_moneda, .folioLineaServicio = d.folio_linea_servicio, .otroDoc = d.otro_documento}).FirstOrDefault()


                    If documento IsNot Nothing Then
                        txtDocumento.Text = documento.descDoc
                        txtFolio.Text = documento.folioLineaServicio
                        txtMoneda.Text = documento.descMoneda
                    Else
                        txtDocumento.Text = "Sin Documento"
                        txtFolio.Text = "Sin Folio"
                        txtMoneda.Text = "Sin Moneda"
                    End If


                    Dim instrumentos As List(Of DETALLE_INSTRUMENTO) = ticket_cntx.DETALLE_INSTRUMENTO.Where(Function(w) w.operacion = operacion.operacion1).ToList()

                    If instrumentos.Count() > 0 Then
                        Dim detalle_instrumentos = (From di In ticket_cntx.DETALLE_INSTRUMENTO
                                                    Join tm In ticket_cntx.TIPO_MONEDA On di.tipo_moneda Equals tm.tipo_moneda1
                                                    Where di.operacion = operacion.operacion1
                                                    Select di).ToList()

                        If detalle_instrumentos IsNot Nothing Then
                            Dim dt As DataTable
                            dt = New DataTable("DetalleInstrumento")

                            Dim col1 As DataColumn = New DataColumn("No. de Docto")
                            col1.DataType = System.Type.GetType("System.String")

                            Dim col2 As DataColumn = New DataColumn("Monto del Docto")
                            col2.DataType = System.Type.GetType("System.Decimal")

                            Dim col3 As DataColumn = New DataColumn("Descripcion del Docto")
                            col3.DataType = System.Type.GetType("System.String")

                            Dim col4 As DataColumn = New DataColumn("Moneda")
                            col4.DataType = System.Type.GetType("System.String")

                            dt.Columns.Add(col1)
                            dt.Columns.Add(col2)
                            dt.Columns.Add(col3)
                            dt.Columns.Add(col4)

                            For Each detalle As DETALLE_INSTRUMENTO In detalle_instrumentos
                                Dim row As DataRow
                                row = dt.NewRow()

                                row.Item("No. de Docto") = detalle.num_documento
                                row.Item("Monto del Docto") = detalle.monto_documento
                                row.Item("Descripcion del Docto") = detalle.descripcion_documento
                                row.Item("Moneda") = detalle.TIPO_MONEDA1.descripcion_moneda
                                dt.Rows.Add(row)
                            Next

                            DataGridView1.DataSource = dt
                            DataGridView1.Refresh()
                        End If
                    End If

                    'Obtenemos el número del destino
                    'Dim deposito As DEPOSITO = contexto1.DEPOSITO.Join(contexto1.TIPO_MONEDA, Function(d) d.tipo_moneda, Function(tm) tm.tipo_moneda1, Function(d, tm) d).FirstOrDefault()
                    Dim deposito As DetalleDocumento = (From d In ticket_cntx.DEPOSITO
                                                        Join tm In ticket_cntx.TIPO_MONEDA On d.tipo_moneda Equals tm.tipo_moneda1
                                                        Where d.operacion = operacion.operacion1
                                                        Select New DetalleDocumento With {.descMoneda = tm.descripcion_moneda, .folioLineaServicio = d.folio_linea_servicio}).FirstOrDefault()

                    If deposito IsNot Nothing Then
                        txtMoneda.Text = documento.descMoneda
                        txtFolio.Text = documento.folioLineaServicio
                    Else
                        txtMoneda.Text = ""
                        txtFolio.Text = ""
                    End If

                    'Si tiene Detalle de Autorizacion habilita el botón cmdAutorizacion
                    Dim detalle_autorizaicon As DETALLE_AUTORIZACION = (From da In ticket_cntx.DETALLE_AUTORIZACION
                                                                        Join ea In ticket_cntx.ESTADO_AUTORIZACION On da.estado_autorizacion Equals ea.estado_autorizacion1
                                                                        Where da.operacion = operacion.operacion1
                                                                        Select da).FirstOrDefault()

                    If detalle_autorizaicon Is Nothing Then
                        cmdAutorizacion.Enabled = False
                    Else
                        If detalle_autorizaicon.numero_autorizacion <> "" Then
                            cmdAutorizacion.Enabled = True
                        Else
                            cmdAutorizacion.Enabled = False
                        End If
                    End If
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

    Private Sub cmdCierra_Click(sender As Object, e As EventArgs) Handles cmdCierra.Click, cmdAutorizacion.Click
        Me.Close()
    End Sub
End Class