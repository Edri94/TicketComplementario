Public Class Consultaret

    Private numOperacion, numCuenta, nLinea As Integer

    Public Sub Consultaret(numOperacion As Integer, numCuenta As Integer, nLinea As Integer)
        Me.numOperacion = numOperacion
        Me.numCuenta = numCuenta
    End Sub

    Private Sub Consultaret_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenaCampos()
    End Sub

    Private Sub LlenaCampos()
        txtNumOperacion.Text = numOperacion
        txtLinea.Text = nLinea

        'Verifica los datos de la Operación
        Using ticket_cntx As New TICKETEntities
            Using funcionario_cntx As New FUNCIONARIOSEntities
                Dim operacion = (From o In ticket_cntx.OPERACION
                                 Join pc In ticket_cntx.PRODUCTO_CONTRATADO On o.producto_contratado Equals pc.producto_contratado1
                                 Where o.operacion1 = numOperacion
                                 Select o).FirstOrDefault()


                If operacion IsNot Nothing Then
                    txtFechaOperacion.Text = operacion.fecha_operacion
                    txtMonto.Text = operacion.monto_operacion
                    txtUsuarioCapt.Text = operacion.usuario_captura
                    txtFuncionario.Text = operacion.funcionario
                    txtFechaCaptura.Text = operacion.fecha_captura
                    pnlCancelada.Visible = If(operacion.status_operacion = 250, True, False)
                End If

                ObtenerStatusOpSw(operacion)

                'Busca el BPIGO del funcionario que capturo la operacion

                Dim funcionario = (From f In funcionario_cntx.FUNCIONARIO Where f.funcionario1 = operacion.funcionario Select f).FirstOrDefault()

                If funcionario IsNot Nothing Then
                    txtNumFuncionario.Text = funcionario.numero_funcionario
                End If


                'Verifica los datos del saldo del cliente
                Dim concepto = (From c In ticket_cntx.CONCEPTO
                                Join cd In ticket_cntx.CONCEPTO_DEFINIDO On c.concepto_definido Equals cd.concepto_definido1
                                Where c.producto_contratado = operacion.producto_contratado And cd.concepto_definido_global = 5
                                Select c).FirstOrDefault()

                If concepto IsNot Nothing Then
                    txtSaldo.Text = concepto.valor_concepto
                Else
                    txtSaldo.Text = "0.00"
                End If

                'Verifica los datos de la Sucursal
                Dim retiro_pme = (From rp In ticket_cntx.RETIRO_PME
                                  Where rp.operacion = operacion.operacion1
                                  Select rp).FirstOrDefault()

                If retiro_pme IsNot Nothing Then
                    txtCausaPME.Text = retiro_pme.causa
                    txtNumCRPME.Text = retiro_pme.centro_regional
                    lblNumPlaza.Text = retiro_pme.plaza
                    lblNumSuc.Text = retiro_pme.sucursal
                    txtCRPME.Text = retiro_pme.nombre_centro_regional
                    txtPlazaPME.Text = retiro_pme.nombre_plaza
                    txtSucursalPME.Text = retiro_pme.nombre_sucursal
                    txtCedRet.Text = retiro_pme.cr_patrimonial
                    txtNoCheque.Text = retiro_pme.numero_cheque
                    txtDescripcion.Text = retiro_pme.otro_documento

                    'Verifica los datos del Documento
                    Dim tipo_doc = (From td In ticket_cntx.TIPO_DOCUMENTO
                                    Where td.tipo_documento1 = retiro_pme.tipo_documento
                                    Select td).FirstOrDefault()

                    If tipo_doc IsNot Nothing Then
                        txtTipoDocumento.Text = tipo_doc.descripcion_documento
                    Else
                        txtTipoDocumento.Text = "Sin Documento"
                    End If

                    'Verifica los datos de la moneda
                    Dim tipo_moneda = (From tm In ticket_cntx.TIPO_MONEDA
                                       Where tm.tipo_moneda1 = retiro_pme.tipo_moneda
                                       Select tm).FirstOrDefault()

                    If tipo_moneda IsNot Nothing Then
                        txtTipoMoneda.Text = tipo_moneda.descripcion_moneda
                    Else
                        txtTipoMoneda.Text = "Sin Moneda"
                    End If

                    'Verifica los datos de la Unidad Organizacional Resumen
                    Dim unidad_org = (From uo In funcionario_cntx.UNIDAD_ORGANIZACIONAL
                                      Where uo.unidad_organizacional1 = retiro_pme.cr_patrimonial
                                      Select uo).FirstOrDefault()
                End If

                'Verifica si el depósito tiene detalle de instrumento
                Dim instrumentos As List(Of DETALLE_INSTRUMENTO) = ticket_cntx.DETALLE_INSTRUMENTO.Where(Function(w) w.operacion = operacion.operacion1).ToList()

                If instrumentos.Count() > 0 Then
                    Dim detalle_instrumento = (From di In ticket_cntx.DETALLE_INSTRUMENTO
                                               Join tm In ticket_cntx.TIPO_MONEDA On di.tipo_moneda Equals tm.tipo_moneda1
                                               Where di.operacion = operacion.operacion1
                                               Select di).ToList()

                    If detalle_instrumento IsNot Nothing Then
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

                        For Each detalle As DETALLE_INSTRUMENTO In detalle_instrumento
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

                    'Si tiene Detalle de Autorizacion habilita el botón cmdAutorizacion
                    Dim detalle_autorizaicon = (From da In ticket_cntx.DETALLE_AUTORIZACION
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
                End If
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
End Class