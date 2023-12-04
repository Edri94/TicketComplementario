Public Class ConsultaRetAreaInterna
    Private num_operacion As Integer
    Private cuenta As String
    Private linea As Integer


    Private Sub ConsultaRetAreaInterna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenaCampos()
        Localizar()
    End Sub

    Private Sub Localizar()
        Me.Height = (txtNumOperacion.Location.Y + cmdCierra.Location.Y + 50)
    End Sub

    Private Sub LlenaCampos()
        Dim ln_ProdCont As Long
        Dim ls_TipoSuc As String
        Dim Ln_Docto As Integer
        Dim Ln_Moneda As Integer
        Dim ln_Detalle As Integer
        Dim ls_Func As String

        Dim operacion As OPERACION
        Dim funcionario As FUNCIONARIO
        Dim concepto As CONCEPTO
        Dim retiro As RETIRO_PME
        Dim doc As TIPO_DOCUMENTO
        Dim opera_suc As OPERA_SUCURSAL
        Dim moneda As TIPO_MONEDA
        Dim unidad_org As UNIDAD_ORGANIZACIONAL
        Dim detalle_instrumentos As List(Of DETALLE_INSTRUMENTO)
        Dim detalle_aut As DETALLE_AUTORIZACION

        txtNumOperacion.Text = num_operacion
        txtLinea.Text = linea

        Using ticket_cntx As New TICKETEntities
            Using funcionario_cntx As New FUNCIONARIOSEntities
                Using catalogos_cntx As New CATALOGOSEntities
                    operacion = (From op In ticket_cntx.OPERACION
                                 Join pc In ticket_cntx.PRODUCTO_CONTRATADO On op.producto_contratado Equals pc.producto_contratado1
                                 Where op.operacion1 = num_operacion
                                 Select op).FirstOrDefault()

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

                    'Obtener Status de Operación y Status Swift
                    ObtenerStatusOpSw(operacion)

                    'Verifica los datos del saldo del cliente
                    concepto = (From c In ticket_cntx.CONCEPTO
                                Join cd In ticket_cntx.CONCEPTO_DEFINIDO On c.concepto_definido Equals cd.concepto_definido1
                                Select c).FirstOrDefault()

                    txtSaldo.Text = concepto.valor_concepto

                    txtNumCuenta.Text = cuenta

                    'Verifica los datos de la Sucursal
                    retiro = (From r In ticket_cntx.RETIRO_PME
                              Where r.operacion = operacion.operacion1
                              Select r).FirstOrDefault()

                    txtCausaPME.Text = retiro.causa
                    txtNumCRPME.Text = retiro.centro_regional
                    lblNumPlaza.Text = retiro.plaza
                    lblNumSuc.Text = retiro.sucursal
                    txtCRPME.Text = retiro.nombre_centro_regional
                    txtPlazaPME.Text = retiro.nombre_plaza
                    txtSucursalPME.Text = retiro.nombre_sucursal
                    lblReferencia.Text = retiro.referencia

                    If retiro.numero_cheque.HasValue Then
                        txtNoCheque.Text = retiro.numero_cheque.Value
                    Else
                        txtNoCheque.Text = "Sin Número de Cheque"
                    End If

                    txtDescripcion.Text = retiro.otro_documento

                    If retiro.referencia_ced.HasValue Then
                        lblReferenciaCED.Text = retiro.referencia_ced
                    End If



                    'Verifica los datos del Documento
                    If retiro.tipo_documento.HasValue Then
                        doc = (From td In ticket_cntx.TIPO_DOCUMENTO
                               Where td.tipo_documento1 = retiro.tipo_documento
                               Select td).FirstOrDefault()

                        If doc IsNot Nothing Then
                            txtTipoDocumento.Text = doc.descripcion_documento
                        Else
                            txtTipoDocumento.Text = "Sin Documento"
                        End If
                    End If

                    'Verifica datos de títulos de referencias
                    opera_suc = (From os In catalogos_cntx.OPERA_SUCURSAL
                                 Where os.sucursal = retiro.sucursal
                                 Select os).FirstOrDefault()

                    lblTReferencia.Text = opera_suc.tit_referencia
                    lblReferenciaCED.Text = opera_suc.tit_referencia_ced

                    'Verifica los datos de la moneda
                    If retiro.tipo_moneda.HasValue Then
                        moneda = (From tm In ticket_cntx.TIPO_MONEDA
                                  Where tm.tipo_moneda1 = retiro.tipo_moneda
                                  Select tm).FirstOrDefault()

                        If moneda IsNot Nothing Then
                            txtTipoMoneda.Text = moneda.descripcion_moneda
                        Else
                            txtTipoMoneda.Text = "Sin Moneda"
                        End If
                    End If

                    'Verifica los datos de la Unidad Organizacional Resumen
                    unidad_org = (From uo In funcionario_cntx.UNIDAD_ORGANIZACIONAL
                                  Where uo.unidad_organizacional1 = retiro.cr_patrimonial
                                  Select uo).FirstOrDefault()

                    If unidad_org IsNot Nothing Then
                        txtPlazaPME.Text = unidad_org.descripcion_unidad_organizacio
                    End If


                    'Verifica si el depósito tiene detalle de instrumento
                    detalle_instrumentos = (From di In ticket_cntx.DETALLE_INSTRUMENTO
                                            Where di.operacion = operacion.operacion1
                                            Select di).ToList()

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
            operacion_swift = contexto.OPERACION_SWIFT.Where(Function(w) w.operacion = operacion.operacion1).FirstOrDefault()
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

    Public Sub ConsultaRetAreaInterna(num_operacion As Integer, cuenta As String, linea As Integer)
        Me.num_operacion = num_operacion
        Me.cuenta = cuenta
        Me.linea = linea
    End Sub

    Private Sub cmdCierra_Click(sender As Object, e As EventArgs) Handles cmdCierra.Click
        Me.Close()
    End Sub
End Class