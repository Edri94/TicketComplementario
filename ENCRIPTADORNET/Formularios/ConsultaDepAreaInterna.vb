Public Class ConsultaDepAreaInterna

    Private numOperacion As Integer
    Private cuenta As Integer
    Private operacion As OPERACION
    Dim funcionario As FUNCIONARIO
    'Dim deposito_pme As DEPOSITO_PME
    Dim tipo_doc As DetalleDocumento
    Dim opera_sucursal As OPERA_SUCURSAL
    Dim detalle_instrumentos As List(Of DETALLE_INSTRUMENTO)
    Dim detalle_aut As DETALLE_AUTORIZACION


    Public Sub ConsultaDepAreaInterna(numOperacion As Integer, cuenta As Integer)
        Me.numOperacion = numOperacion
        Me.cuenta = cuenta
    End Sub


    Private Sub ConsultaDepAreaInterna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenaCampos()
    End Sub


    Private Sub LlenaCampos()
        Dim ln_DetIns As Integer
        Dim ls_Func As String
        Dim Ln_TipoDoc As Integer


        txtNumOperacion.Text = numOperacion
        txtNumCuenta.Text = cuenta

        Using ticket_cntx As New TICKETEntities
            Using funcionario_cntx As New FUNCIONARIOSEntities
                Using catalogos_cntx As New CATALOGOSEntities

                    operacion = ticket_cntx.OPERACION.Where(Function(w) w.operacion1 = numOperacion).FirstOrDefault()

                    ObtenerOperDefinida()

                    'Obtenemos la fecha de operación, el monto y el número de operación definida
                    txtFechaOperacion.Text = operacion.fecha_operacion
                    txtMonto.Text = operacion.monto_operacion
                    txtUsuarioCapt.Text = catalogos_cntx.USUARIO.Where(Function(w) w.usuario1 = operacion.usuario_captura).FirstOrDefault().nombre_usuario

                    txtFuncionario.Text = operacion.contacto
                    txtFechaCaptura.Text = operacion.fecha_captura

                    If operacion.status_operacion = 250 Then
                        pnlCancelada.Visible = True
                    Else
                        pnlCancelada.Visible = False
                    End If

                    lblGrabadora.Text = operacion.grabadora

                    If operacion.funcionario.HasValue Then
                        funcionario = funcionario_cntx.FUNCIONARIO.Where(Function(w) w.funcionario1 = operacion.funcionario).FirstOrDefault()

                        txtNumFuncionario.Text = funcionario.numero_funcionario
                    End If

                    'Verifica datos de la sucursal
                    txtNumCR.Text = operacion.DEPOSITO_PME.plaza
                    txtCR.Text = operacion.DEPOSITO_PME.nombre_plaza
                    txtNumPlaza.Text = operacion.DEPOSITO_PME.nombre_plaza
                    txtPlaza.Text = operacion.DEPOSITO_PME.nombre_plaza
                    txtNumSucursal.Text = operacion.DEPOSITO_PME.sucursal
                    txtSucursal.Text = operacion.DEPOSITO_PME.nombre_plaza
                    lblReferencia.Text = operacion.DEPOSITO_PME.nombre_plaza
                    txtCausa.Text = operacion.DEPOSITO_PME.causa

                    'Verifica datos del Tipo de Documento
                    'tipo_doc = (From td In ticket_cntx.TIPO_DOCUMENTO
                    '            Join d In ticket_cntx.DEPOSITO On td.tipo_documento1 Equals d.tipo_documento
                    '            Where d.operacion = operacion.operacion1
                    '            Select td).FirstOrDefault()

                    txtDocumento.Text = operacion.DEPOSITO.TIPO_DOCUMENTO1.descripcion_documento
                    txtDescripcion.Text = operacion.DEPOSITO.otro_documento
                    lblReferenciaCED.Text = If(operacion.DEPOSITO.referencia_ced.HasValue, operacion.DEPOSITO.referencia_ced.Value, "")

                    'Verifica datos de títulos de referencias
                    opera_sucursal = catalogos_cntx.OPERA_SUCURSAL.Where(Function(w) w.sucursal = operacion.DEPOSITO_PME.sucursal).FirstOrDefault()
                    lblTReferencia.Text = opera_sucursal.tit_referencia
                    lblReferenciaCED.Text = opera_sucursal.tit_referencia_ced


                    'Verifica datos del folio de la linea de servicio y del tipo de moneda
                    tipo_doc = (From td In ticket_cntx.TIPO_DOCUMENTO
                                Join d In ticket_cntx.DEPOSITO On td.tipo_documento1 Equals d.tipo_documento
                                Join tm In ticket_cntx.TIPO_MONEDA On d.tipo_moneda Equals tm.tipo_moneda1
                                Where d.operacion = operacion.operacion1
                                Select New DetalleDocumento With {.folioLineaServicio = d.folio_linea_servicio, .descMoneda = tm.descripcion_moneda, .deposito = d, .moneda = tm}).FirstOrDefault()

                    If tipo_doc IsNot Nothing Then
                        txtFolio.Text = tipo_doc.folioLineaServicio
                        txtFolio.Text = tipo_doc.descMoneda
                    End If



                    'Verifica si el depósito tiene detalle de instrumento
                    detalle_instrumentos = ticket_cntx.DETALLE_INSTRUMENTO.Where(Function(w) w.operacion = operacion.operacion1).ToList()

                    If detalle_instrumentos.Count() > 0 Then
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

                    'Obtenemos el número del destino
                    If tipo_doc IsNot Nothing Then
                        If tipo_doc.moneda.descripcion_moneda = "" Then
                            txtMoneda.Text = "Sin Moneda"
                        Else
                            txtMoneda.Text = tipo_doc.moneda.descripcion_moneda
                        End If

                        If tipo_doc.deposito.folio_linea_servicio.HasValue Then
                            txtFolio.Text = "Sin Folio"
                        Else
                            txtFolio.Text = tipo_doc.deposito.folio_linea_servicio
                        End If
                    Else
                        txtMoneda.Text = "Sin Moneda"
                         txtFolio.Text = "Sin Folio"
                    End If



                    'Si tiene Detalle de Autorizacion habilita el botón cmdAutorizacion
                    detalle_aut = (From da In ticket_cntx.DETALLE_AUTORIZACION
                                   Join ea In ticket_cntx.ESTADO_AUTORIZACION On da.estado_autorizacion Equals ea.estado_autorizacion1
                                   Where da.operacion = operacion.operacion1
                                   Select da).FirstOrDefault()

                    If detalle_aut IsNot Nothing Then
                        cmdAutorizacion.Enabled = True
                    Else
                        cmdAutorizacion.Enabled = False
                    End If

                End Using
            End Using
        End Using


    End Sub

    Private Sub ObtenerOperDefinida()
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