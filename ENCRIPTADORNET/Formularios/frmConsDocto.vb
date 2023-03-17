Public Class frmConsDocto

    'Dim gs_sql As String
    Dim mn_Tipo As Byte
    Dim mb_FED As Boolean
    Dim l As New Libreria

    'Variable utilizada para los permisos de Alchemy
    Public bolEntraAlchemy As Boolean
    'Ruta de la base de ALchemy
    Public rutaAlchemy As String
    '---------------------------------Termina Alchemy

    Private Sub frmConsDocto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cursor = System.Windows.Forms.Cursors.WaitCursor
        If bolEntraAlchemy Then Alchemy.Enabled = True
        'Call CargarColores(Me, cambio)
        'Call Centerform(Me)
        l.cambiarLabels(lblDoc)
        l.cambiarLabels(lblFechaRec)
        l.cambiarLabels(lblCta)
        l.cambiarLabels(lblFechaCap)
        l.cambiarLabels(lblAgencia)
        l.cambiarLabels(lblFechaOp)
        l.cambiarLabels(lblNombreCte)
        l.cambiarLabels(lblPersonaOp)
        l.cambiarLabels(lblNumPlaza)
        l.cambiarLabels(lblPlaza)
        l.cambiarLabels(lblNumSuc)
        l.cambiarLabels(lblSuc)
        l.cambiarLabels(lblTipoDoc)
        l.cambiarLabels(lblTipoInst)
        l.cambiarLabels(lblTipoFte)
        l.cambiarLabels(lblDivisa)
        l.cambiarLabels(lblUsuario)
        l.cambiarLabels(lblStatusGOS)
        l.cambiarLabels(lblStatusConc)
        l.cambiarLabels(lblMonto)
        l.cambiarLabels(lblTicket)
        l.cambiarLabels(lblRef)
        l.cambiarLabels(lblDetalle)
        l.cambiarLabels(lblComision)
        l.cambiarLabels(lblTktMercury)
        l.cambiarLabels(lblCtaMercury)
        l.cambiarLabels(lblVerificado)
        l.cambiarLabels(lblFechaConc)
        l.cambiarLabels(lblTktConc)
        l.cambiarLabels(lblFechaDig)
        l.cambiarLabels(lbldisco)
        'lblTitulo.FontBold = True
        'lblOriginal.FontBold = True
        'Me.Top = 25
        'Me.Show()
    End Sub

    Public Function Muestra(ByVal Documento As String, ByVal FED As Boolean, ByVal Tipo As Byte)

        Cursor = System.Windows.Forms.Cursors.WaitCursor
        'Me.ShowDialog()
        'MsgBox("El documento al entrar a MUESTRA " + Documento, MessageBoxButtons.OK)
        lblDoc.Text = Documento
        Dim ln_TipoDoc As Byte
        Dim lb_Concilia, lb_regresa As Boolean
        Dim ls_DocDigital As String
        Dim ls_fuente As Integer
        Dim ls_TIPODOCUMENTO As Integer
        Dim row As DataRow
        Dim value As Object
        Dim dst As New Datasource
        Dim dtt As DataTable
        Dim dstsop As New Datasource
        Dim dttsop As DataTable
        Dim dttConcilia As DataTable
        Dim dttDisco As DataTable

        lb_regresa = True
        Cursor = System.Windows.Forms.Cursors.WaitCursor  '    ShowWaitCursor
        mb_FED = FED
        If mb_FED = False Then
            lblTStatus0.Visible = True
            lblTStatus1.Visible = True
            lblStatusGOS.Visible = True
            lblStatusConc.Visible = True
        End If
        mn_Tipo = Tipo
        lblDoc.Text = Documento
        lb_Concilia = False
        '    dbEndQuery
        gs_Sql = "Select tipo_operacion,DC.tipo_documento,DC.fuente  from "
        gs_Sql = gs_Sql & "GOS.dbo.DOCUMENTO DC, "
        gs_Sql = gs_Sql & "GOS.dbo.TIPO_DOCUMENTO TD "
        gs_Sql = gs_Sql & "where "
        gs_Sql = gs_Sql & "DC.tipo_documento = TD.tipo_documento and "
        gs_Sql = gs_Sql & "DC.documento = " & Documento
        '    dbExecQuery gs_Sql                              'Busca el tipo de operacion
        '    dbGetRecord

        'MsgBox("gs_sql en frmConsDocto" + gs_sql, MsgBoxStyle.Information, "Consulta")

        dtt = New DataTable
        dtt = dst.RealizaConsulta(gs_Sql)
        If dtt.Rows.Count > 0 Then
            'MsgBox("Tipo de Operación " + dtt.Rows.Count.ToString().PadRight(15), MsgBoxStyle.Information, "Consulta")
            'else
            'MsgBox("No hay tipo de operación.", MsgBoxStyle.Information, "Consulta")
            'End If

            row = dtt.Rows(0) 'dtt.Rows.Count - 1)
            value = row.Item("tipo_operacion")
            ln_TipoDoc = CStr(value)                 'Val(dbGetValue(0))
            value = row.Item("tipo_documento")
            ls_fuente = CStr(value)                   'Val(dbGetValue(2))
            value = row.Item("fuente")
            ls_TIPODOCUMENTO = CStr(value)            'Val(dbGetValue(1))

            'MsgBox("ln_TipoDoc " + ln_TipoDoc.ToString(), MsgBoxStyle.Information, "Consulta")
            'MsgBox("ls_fuente " + ls_fuente.ToString(), MsgBoxStyle.Information, "Consulta")
            'MsgBox("ls_TIPODOCUMENTO " + ls_TIPODOCUMENTO.ToString(), MsgBoxStyle.Information, "Consulta")

            'Me.ShowDialog()
            'Cursor = System.Windows.Forms.Cursors.Default


            'ls_fuente =                   'Val(dbGetValue(2))
            'ls_TIPODOCUMENTO =            'Val(dbGetValue(1))

            '    ln_TipoDoc = Val(dbGetValue(0))
            '    ls_fuente = Val(dbGetValue(2))
            '    ls_TIPODOCUMENTO = Val(dbGetValue(1))

            '    dbEndQuery
            Select Case ln_TipoDoc
                Case 0                                        'Es una operacion de Deposito
                    ln_TipoDoc = 0
                    lblTitulo.Text = "Consulta de Documento - Deposito"
                    lblDepRet0.Visible = True
                    lblDepRet1.Visible = True
                    lblDepRet2.Visible = True
                    lblCuenta.Text = "Numero de Cuenta:"
                    lblAg.Text = "Agencia:"
                    lblCtaPlaza.Text = "Plaza:"
                    lblAgSuc.Text = "Sucursal:"
                    lblAgSuc.Visible = True
                    lblNumSuc.Visible = True
                    lblPlaza.Visible = True
                    'lblNumPlaza.Width = 325 '1380
                    lblSuc.Visible = True
                    lblTipoInst.Visible = True
                    lblDivisa.Visible = True
                    lblRef.Visible = True
                    lblDetalle.Visible = True
                    lblTitDetalle.Text = "Linea de Servicio:"
                    lblComision.Visible = True
                    lblTitComision.Visible = True
                    LabelVerif.Visible = True
                    lblVerificado.Visible = True
                Case 1                                        'Es una operacion de Retiro
                    ln_TipoDoc = 1
                    lblTitulo.Text = "Consulta de Documento - Retiro"
                    lblDepRet0.Visible = True
                    lblDepRet1.Visible = True
                    lblDepRet2.Visible = True
                    lblCuenta.Text = "Numero de Cuenta:"
                    lblAg.Text = "Agencia:"
                    lblAgSuc.Visible = True
                    lblNumSuc.Visible = True
                    lblCtaPlaza.Text = "Plaza:"
                    lblAgSuc.Text = "Sucursal:"
                    lblPlaza.Visible = True
                    'lblNumPlaza.Width = 1380
                    lblSuc.Visible = True
                    lblTipoInst.Visible = True
                    lblDivisa.Visible = True
                    lblRef.Visible = True
                    lblDetalle.Visible = True
                    lblTitDetalle.Text = "N° de Cheque:"
                    lblComision.Visible = False
                    lblTitComision.Visible = False
                    LabelVerif.Visible = True
                    lblVerificado.Visible = True
                Case 2                                        'Es una operacion de Traspaso
                    ln_TipoDoc = 2
                    lblTitulo.Text = "Consulta de Documento - Traspaso"
                    lblDepRet0.Visible = False
                    lblDepRet1.Visible = False
                    lblDepRet2.Visible = False
                    lblCuenta.Text = "Cuenta Cargo:"
                    lblAg.Text = "Agencia Cargo:"
                    lblAgSuc.Visible = True
                    lblAgSuc.Text = "Agencia Destino:"
                    lblNumSuc.Visible = True
                    lblCtaPlaza.Text = "Cuenta Destino:"
                    lblAg.Visible = False
                    lblNombreCte.Visible = False
                    Label6.Visible = False
                    lblPersonaOp.Visible = False
                    lblPlaza.Visible = False
                    'lblNumPlaza.Width = 1380
                    lblSuc.Visible = False
                    lblTipoInst.Visible = False
                    lblDivisa.Visible = False
                    lblRef.Visible = False
                    lblDetalle.Visible = False
                    lblTitDetalle.Text = ""
                    lblComision.Visible = False
                    lblTitComision.Visible = False
                    LabelVerif.Visible = False
                    lblVerificado.Visible = False
                Case Else                                     'Es una operacion de Transferencia
                    ln_TipoDoc = 3
                    lblTitulo.Text = "Consulta de Documento - Transferencia"
                    lblDepRet0.Visible = False
                    lblDepRet1.Visible = False
                    lblDepRet2.Visible = False
                    lblCuenta.Text = "Cuenta Cargo:"
                    lblAg.Text = "Agencia Cargo:"
                    lblCtaPlaza.Text = "Cuenta Destino:"
                    lblAgSuc.Visible = False
                    lblNumSuc.Visible = False
                    lblAg.Visible = False
                    lblNombreCte.Visible = False
                    Label6.Visible = False
                    lblPersonaOp.Visible = False
                    lblPlaza.Visible = False
                    'lblNumPlaza.Width = 4670
                    lblSuc.Visible = False
                    lblTipoInst.Visible = False
                    lblDivisa.Visible = False
                    lblRef.Visible = False
                    lblDetalle.Visible = False
                    lblTitDetalle.Text = ""
                    lblComision.Visible = False
                    lblTitComision.Visible = False
                    LabelVerif.Visible = False
                    lblVerificado.Visible = False
            End Select
            gs_Sql = "Select "
            gs_Sql = gs_Sql & "AG.prefijo_agencia+'-'+"                       '0
            gs_Sql = gs_Sql & "cuenta_cliente+'-'+"
            gs_Sql = gs_Sql & "sufijo as age_ctacte_sufijo, "
            gs_Sql = gs_Sql & "AG.descripcion_agencia as descripcion_agencia, "                      '1
            gs_Sql = gs_Sql & "convert(char(10),fecha_recepcion,105) as fecha_recepcion, "       '2
            gs_Sql = gs_Sql & "convert(char(10),fecha_captura,105) as fecha_captura, "         '3
            gs_Sql = gs_Sql & "convert(char(10),fecha_operacion,105) as fecha_operacion, "       '4
            gs_Sql = gs_Sql & "monto, "                                       '5
            gs_Sql = gs_Sql & "ticket, "                                      '6
            gs_Sql = gs_Sql & "referencia, "                                  '7
            gs_Sql = gs_Sql & "ticket_mercury, "                              '8
            gs_Sql = gs_Sql & "cuenta_mercury+'-'+"
            gs_Sql = gs_Sql & "sufijo_mercury, "                              '9
            gs_Sql = gs_Sql & "verificado, "                                  '10
            gs_Sql = gs_Sql & "descripcion_documento, "                       '11
            gs_Sql = gs_Sql & "descripcion_fuente, "                          '12
            gs_Sql = gs_Sql & "descripcion_status_concilia, "                 '13
            gs_Sql = gs_Sql & "descripcion_status_gos, "                      '14
            gs_Sql = gs_Sql & "nombre_usuario, "                              '15
            gs_Sql = gs_Sql & "operacion_concilia, "                          '16
            gs_Sql = gs_Sql & "convert(char(10),fecha_concilia,105) as fec_conci, "        '17
            gs_Sql = gs_Sql & "convert(char(10),fecha_digitalizacion,105) as fec_digi, "  '18
            gs_Sql = gs_Sql & "digitalizacion, "                              '19
            If ln_TipoDoc < 2 Then                          'Si es deposito o retiro
                gs_Sql = gs_Sql & "PZ.plaza, "                                  '20
                gs_Sql = gs_Sql & "PZ.nombre_plaza, "                           '21
                gs_Sql = gs_Sql & "SU.sucursal, "                               '22
                gs_Sql = gs_Sql & "SU.nombre_sucursal, "                        '23
                gs_Sql = gs_Sql & "DV.descripcion_divisa, "                     '24
                gs_Sql = gs_Sql & "TI.descripcion_instrumento, "                '25
                gs_Sql = gs_Sql & "PO.original, "                               '26
                If ln_TipoDoc = 0 Then                        'Si se trata de un deposito
                    gs_Sql = gs_Sql & "PO.linea_servicio, "                       '27
                    gs_Sql = gs_Sql & "PO.total_comision_iva, "                   '28
                Else                                          'Si se trata de un retiro
                    gs_Sql = gs_Sql & "PO.cheque, "                               '27
                    gs_Sql = gs_Sql & "PO.numero_cheque, "                        '28
                End If
                gs_Sql = gs_Sql & "nombre_cliente, "                            '20
                gs_Sql = gs_Sql & "persona_opera, "                             '30
                gs_Sql = gs_Sql & "numero_soportes "                            '31
            ElseIf ln_TipoDoc = 2 Then                      'Si se trata de un traspaso
                gs_Sql = gs_Sql & "AD.prefijo_agencia+'-'+"                     '20
                gs_Sql = gs_Sql & "PO.cuenta_destino+'-'+"
                gs_Sql = gs_Sql & "PO.sufijo_destino as prefctadestino, '',"    '21
                gs_Sql = gs_Sql & "AD.descripcion_agencia "                     '22
            Else                                            'Si se trata de una transferencia
                gs_Sql = gs_Sql & "PO.cuenta_abono "                            '20
            End If
            gs_Sql = gs_Sql & "From "
            If ln_TipoDoc = 0 Then                          'Si se trata de un deposito
                gs_Sql = gs_Sql & "GOS.dbo.DEPOSITO_CED PO, "
            ElseIf ln_TipoDoc = 1 Then                      'Si se trata de un retiro
                gs_Sql = gs_Sql & "GOS.dbo.RETIRO_CED PO, "
            ElseIf ln_TipoDoc = 2 Then                      'Si se trata de un traspaso
                gs_Sql = gs_Sql & "GOS.dbo.TRASPASO PO, "
            Else                                            'Si se trata de una transferencia
                gs_Sql = gs_Sql & "GOS.dbo.TRANSFERENCIA PO, "
            End If
            If ln_TipoDoc < 2 Then                          'Si es deposito o retiro
                gs_Sql = gs_Sql & "GOS.dbo.PLAZAS PZ, "
                gs_Sql = gs_Sql & "GOS.dbo.SUCURSAL SU, "
                gs_Sql = gs_Sql & "GOS.dbo.DIVISAS DV, "
                gs_Sql = gs_Sql & "GOS.dbo.TIPO_INSTRUMENTO TI, "
            End If
            gs_Sql = gs_Sql & "GOS.dbo.FUENTES FU, "
            gs_Sql = gs_Sql & "GOS.dbo.USUARIO US, "                       'gstUsuarios
            gs_Sql = gs_Sql & "GOS.dbo.DOCUMENTO DC, "
            gs_Sql = gs_Sql & "GOS.dbo.STATUS_GOS SG, "
            gs_Sql = gs_Sql & "GOS.dbo.TIPO_DOCUMENTO TD, "
            gs_Sql = gs_Sql & "GOS.dbo.STATUS_CONCILIA SC, "
            If ln_TipoDoc = 2 Then                          'Si es un traspaso
                gs_Sql = gs_Sql & "CATALOGOS.dbo.AGENCIA AD,"
            End If
            gs_Sql = gs_Sql & "CATALOGOS.dbo.AGENCIA AG "
            gs_Sql = gs_Sql & "Where "
            gs_Sql = gs_Sql & "FU.fuente = DC.fuente and "
            gs_Sql = gs_Sql & "SG.status_gos = DC.status_gos and "
            gs_Sql = gs_Sql & "SC.status_concilia = DC.status_concilia and "
            gs_Sql = gs_Sql & "US.usuario = DC.usuario and "
            gs_Sql = gs_Sql & "AG.agencia = DC.agencia and "
            'gs_sql = gs_sql & "DC.agencia " & gs_PermisoAgencias & " and "
            gs_Sql = gs_Sql & "TD.tipo_documento = DC.tipo_documento and "
            If ln_TipoDoc < 2 Then                          'Si es deposito o retiro
                gs_Sql = gs_Sql & "PZ.plaza = PO.plaza and "
                gs_Sql = gs_Sql & "SU.sucursal = PO.sucursal and "
                gs_Sql = gs_Sql & "DV.divisa = PO.divisa and "
                gs_Sql = gs_Sql & "TI.tipo_instrumento = PO.tipo_instrumento and "
            End If
            If ln_TipoDoc = 2 Then                          'Si es un traspaso
                gs_Sql = gs_Sql & "AD.agencia = PO.agencia_destino and "
            End If
            If ln_TipoDoc = 3 Then                           'Si es Transferencia
                gs_Sql = gs_Sql & "PO.documento =* DC.documento and "
            Else                                            'Si es un Dep, Ret o Traspaso
                gs_Sql = gs_Sql & "PO.documento = DC.documento and "
            End If
            gs_Sql = gs_Sql & "DC.documento = " & Documento
            'dbExecQuery gs_sql                              'Busca datos particulares del documento
            'dbGetRecord
            dtt = New DataTable
            dtt = dst.RealizaConsulta(gs_Sql)
            If dtt.Rows.Count > 0 Then
                'If dbError = 0 Then
                row = dtt.Rows(0)
                'value = row.Item("agecliesufijo")
                'lblCta.Text = CStr(value)                'Val(dbGetValue(0))
                lblCta.Text = row.Item("age_ctacte_sufijo").ToString
                lblAgencia.Text = row.Item("descripcion_agencia").ToString
                lblFechaRec.Text = row.Item("fecha_recepcion").ToString 'FechaDisplay(dbGetValue(2))
                lblFechaCap.Text = row.Item("fecha_captura").ToString 'FechaDisplay(dbGetValue(3))
                lblFechaOp.Text = row.Item("fecha_operacion").ToString  'FechaDisplay(dbGetValue(4))
                lblMonto.Text = "$" + String.Format("{0:0.00}", Convert.ToDecimal(row.Item("monto").ToString)) 'row.Item("monto").ToString  'Format(dbGetValue(5), "#,###,###,##0.00")
                lblTicket.Text = row.Item("ticket").ToString  'Format(Trim(dbGetValue(6)), FORMAT_TICKET)
                lblRef.Text = row.Item("referencia").ToString  'Trim(dbGetValue(7))
                lblTktMercury.Text = row.Item("ticket_mercury").ToString  'Trim(dbGetValue(8))
                If Trim(lblTktMercury.Text) <> "" Then
                    lblTitMercury0.Visible = True
                    lblTitMercury1.Visible = True
                    lblTktMercury.Visible = True
                    lblCtaMercury.Visible = True
                    lblCtaMercury.Text = row.Item("sufijo_mercury").ToString 'Trim(dbGetValue(9))
                End If
                If ln_TipoDoc < 2 Then                        'Solo Depósitos o Retiros
                    If Val(row.Item("verificado").ToString) = 1 Then             'Si Verificado = 1
                        lblVerificado.Text = "Ok"
                    Else
                        lblVerificado.Text = "Sin Verificar"
                    End If
                End If
                lblTipoDoc.Text = row.Item("descripcion_documento").ToString 'LowCaseName(dbGetValue(11))
                lblTipoFte.Text = row.Item("descripcion_fuente").ToString 'LowCaseName(dbGetValue(12))
                lblStatusConc.Text = row.Item("descripcion_status_concilia").ToString 'LowCaseName(dbGetValue(13))
                lblStatusGOS.Text = row.Item("descripcion_status_gos").ToString 'LowCaseName(dbGetValue(14))
                lblUsuario.Text = row.Item("nombre_usuario").ToString 'LowCaseName(dbGetValue(15))
                lblTktConc.Text = row.Item("operacion_concilia").ToString 'Trim(dbGetValue(16))
                If Trim(lblTktConc.Text) = "" Then lblTktConc.Text = "00000000"
                lblFechaConc.Text = row.Item("fec_conci").ToString 'FechaDisplay(dbGetValue(17))
                If Trim(lblFechaConc.Text) = "" Then lblFechaConc.Text = "00/00/0000"
                lblFechaDig.Text = row.Item("fec_digi").ToString 'FechaDisplay(dbGetValue(18))
                If Trim(lblFechaDig.Text) = "" Then lblFechaDig.Text = "00/00/0000"
                ls_DocDigital = row.Item("digitalizacion").ToString 'Trim(dbGetValue(19))
                If ln_TipoDoc < 2 Then                          'Si es deposito o retiro
                    lblNumPlaza.Text = Trim(row.Item("plaza").ToString) 'Trim(dbGetValue(20))
                    lblPlaza.Text = Trim(row.Item("nombre_plaza").ToString) 'LowCaseName(dbGetValue(21))
                    lblNumSuc.Text = row.Item("sucursal").ToString 'Trim(dbGetValue(22))
                    lblSuc.Text = row.Item("nombre_sucursal").ToString 'LowCaseName(dbGetValue(23))
                    lblDivisa.Text = row.Item("descripcion_divisa").ToString 'LowCaseName(dbGetValue(24))
                    lblTipoInst.Text = row.Item("descripcion_instrumento").ToString 'LowCaseName(dbGetValue(25))
                ElseIf ln_TipoDoc = 2 Then                      'Si se trata de un traspaso
                    lblNumPlaza.Text = Trim(row.Item("prefctadestino").ToString) 'Trim(dbGetValue(20))
                    lblPlaza.Text = " " 'row.Item("nombre_plaza").ToString 'LowCaseName(dbGetValue(21))
                    lblNumSuc.Text = row.Item("descripcion_agencia").ToString 'Trim(dbGetValue(22))
                Else                                            'Si se trata de una transferencia
                    lblNumPlaza.Text = Trim(row.Item("cuenta_abono").ToString) 'Trim(dbGetValue(20))
                End If
                If ln_TipoDoc < 2 Then
                    If Val(row.Item("original").ToString) = 1 Then             'Si se recibio documento original dbGetValue(26)
                        lblOriginal.Visible = True
                    Else
                        lblOriginal.Visible = False
                    End If
                End If

                If ln_TipoDoc = 0 Then                      'Si se trata de un deposito
                    lblDetalle.Text = row.Item("linea_servicio").ToString 'Trim(dbGetValue(27))  {$0:0.00} {0:#.00}
                    lblComision.Text = "$" + String.Format("{0:0.00}", Convert.ToDecimal(row.Item("total_comision_iva").ToString)) 'row.Item("total_comision_iva") 'Format(dbGetValue(28), "#,###,###,##0.00")
                ElseIf ln_TipoDoc = 1 Then                  'Si se trata de un retiro
                    If Val(row.Item("cheque").ToString) = 0 Then           'No se utilizo cheque dbGetValue(27)
                        lblDetalle.Text = "Sin Cheque"
                    Else                                      'Se utilizo cheque
                        lblDetalle.Text = Trim(row.Item("numero_cheque").ToString) 'dbGetValue(28)
                    End If
                End If

                If ln_TipoDoc < 2 Then                          'Si es deposito o retiro
                    lblNombreCte.Text = Trim(row.Item("nombre_cliente").ToString) 'dbGetValue(29)
                    lblPersonaOp.Text = Trim(row.Item("persona_opera").ToString)  'Trim(dbGetValue(30))
                    If Val(Trim(row.Item("numero_soportes").ToString)) > 0 Then   'El documento debe tener soportes dbGetValue(31)
                        '    '    dbEndQuery
                        gs_Sql = "Select "
                        gs_Sql = gs_Sql & "numero_soporte as 'Numero_Soporte' , "
                        gs_Sql = gs_Sql & "detalle_soporte as 'Detalle_Soporte', "
                        gs_Sql = gs_Sql & "descripcion_soporte as 'Descripcion', "
                        gs_Sql = gs_Sql & "descripcion_divisa as 'Divisa', "
                        gs_Sql = gs_Sql & "importe as 'Importe', "
                        gs_Sql = gs_Sql & "convert(char(10),fecha_soporte,105) as 'Fecha Soporte', "
                        gs_Sql = gs_Sql & "soporte as 'Soporte' "
                        gs_Sql = gs_Sql & "From "
                        gs_Sql = gs_Sql & "GOS.dbo.DIVISAS DV, "
                        gs_Sql = gs_Sql & "GOS.dbo.SOPORTE SO, "
                        gs_Sql = gs_Sql & "GOS.dbo.TIPO_SOPORTE TS "
                        gs_Sql = gs_Sql & "Where "
                        gs_Sql = gs_Sql & "DV.divisa =* SO.divisa and "
                        gs_Sql = gs_Sql & "TS.tipo_soporte = SO.tipo_soporte and "
                        gs_Sql = gs_Sql & "documento = " & Documento

                        dttsop = New DataTable
                        dttsop = dstsop.RealizaConsulta(gs_Sql)
                        If dttsop Is Nothing Then
                            gpoBoxSoportes.Visible = False
                            'dgvSoportes.Visible = False
                        Else
                            If dttsop.Rows.Count > 0 Then
                                dgvSoportes.DataSource = dttsop
                                Me.dgvSoportes.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
                                For i = 0 To 6 Step 1
                                    dgvSoportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                                Next
                                dgvSoportes.Columns("Importe").DefaultCellStyle.Format = "C2"
                                dgvSoportes.Columns("Importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                                '    'LlenaLstView lstSoportes, "NS&DS&DS&DD&IM&FS&Soporte", gs_sql, False, 1, "+4", "", "+5"

                                '    '    If lstSoportes.ListItems.Count > 0 Then   'Se encontraron soportes para el documento
                                '    '        lstSoportes.Visible = True
                                '    '        If lstSoportes.ListItems.Count > 7 Then 'Arregla el ancho de las columnas en base al numero de registros
                                '    '            lstSoportes.ColumnHeaders(4).Width = 1600
                                '    '        Else
                                '    '            lstSoportes.ColumnHeaders(4).Width = 1800
                                '    '        End If
                                '    '    Else
                                '    '        lstSoportes.Visible = False
                                '    '    End If
                            Else
                                gpoBoxSoportes.Visible = False
                                'dgvSoportes.Visible = False
                            End If
                            'dbEndQuery
                            'Se busca la clasificación de los tipos de soportes
                            If dgvSoportes.Rows.Count > 0 Then '  lstSoportes.ListItems.Count > 0 Then
                                Call ObtieneClasifTipoSoporte(Documento, ln_TipoDoc, ls_fuente, ls_TIPODOCUMENTO)
                            End If
                            gs_Sql = "Select operacion_concilia "
                            gs_Sql = gs_Sql & "From "
                            gs_Sql = gs_Sql & "GOS.dbo.DOCUMENTO "
                            gs_Sql = gs_Sql & "Where "
                            gs_Sql = gs_Sql & "status_concilia = 5 and "
                            gs_Sql = gs_Sql & "documento = " & Documento

                            dttConcilia = New DataTable
                            dttConcilia = dst.RealizaConsulta(gs_Sql)
                            If dtt.Rows.Count > 0 Then
                                'If dbError = 0 Then
                                row = dtt.Rows(0)
                                'value = row.Item("agecliesufijo")
                                'lblCta.Text = CStr(value)                'Val(dbGetValue(0))
                                lblCta.Text = row.Item("age_ctacte_sufijo").ToString

                                'dbExecQuery gs_sql                          'Busca el ticket con el que concilia
                                'dbGetRecord
                                'If dbError = 0 Then
                                '    lblStatusConc = lblStatusConc & "  (Ticket N° " & Format(Trim(dbGetValue(0)), FORMAT_TICKET) & ")"
                                '    lb_Concilia = True
                                'End If
                                '    dbEndQuery
                                'Else
                                'MsgBox "No es posible consultar la base de datos.", vbCritical, "SQL Server Error"
                                'dbEndQuery
                            End If
                        End If
                    End If

                    'dbEndQuery
                    'ShowDefaultCursor
                    If FED = True Then                            'Es consulta para el FED
                        If lb_Concilia = False Then                 'El documento no esta conciliado
                            MsgBox("El documento no ha sido conciliado.", vbInformation, "Conciliación")
                        End If
                    End If
                    'Alchemy no es requerido por usuarios AICED, acuerdo 9 de sep 2020
                    If Val(ls_DocDigital) > 0 Then                'Si existe digitalizacion
                        cmdDigital.Enabled = True
                        If bolEntraAlchemy Then Alchemy.Enabled = True
                    Else
                        cmdDigital.Enabled = False
                        Alchemy.Enabled = False
                    End If
                    If cmdDigital.Enabled And Val(ls_DocDigital) > 1 Then
                        '    'If Alchemy.Enabled And Val(ls_DocDigital) > 1 Then
                        gs_Sql = "Select d.nombre "
                        gs_Sql = gs_Sql & " From "
                        gs_Sql = gs_Sql & " TDOCUMENTO t, TDISCO d"
                        gs_Sql = gs_Sql & " Where "
                        gs_Sql = gs_Sql & " t.disco = d.disco and "
                        gs_Sql = gs_Sql & " documento = " & ls_DocDigital
                        'Busca el documento con el que concilia
                        'dbExecQuery gs_Sql
                        'dbGetRecord
                        '    If dbError = 0 Then
                        '        lbldisco.Visible = True
                        '        lbldisco.Caption = Trim(dbGetValue(0))
                        '    End If
                        '    dbEndQuery
                        'End If
                        'dbEndQuery
                        Cursor = System.Windows.Forms.Cursors.Default
                        'Me.Show()
                        'Me.ShowDialog()
                    End If
                End If
            End If
        Else
            MsgBox("No hay información para el documento " + Documento + ".", MsgBoxStyle.Information, "Consulta de documentos")
            lb_regresa = False
            Me.Dispose()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
        Return lb_regresa
    End Function

    Private Sub cmdCierra_Click()
        'Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdConsultar_Click(sender As Object, e As EventArgs) Handles cmdConsultar.Click

        If mb_FED = True Then
            Dim frmConsulta As New frmConsulta
            frmConsulta.Fuente(mn_Tipo, "FED")
            'frmConsulta.mnTipo = mn_Tipo
            'frmConsulta.ShowDialog()
        Else
            frmConsulta.Fuente(mn_Tipo, False)
        End If
        Me.Close()
    End Sub
    Private Sub cmdImprimir_Click()

        '      Dim ln_Formulas As Byte

        '      ShowWaitCursor
        '      For ln_Formulas = 0 To 20               'Elimina formulas (de reportes anteriores)
        '          MDIGOS.rptSeguimiento.Formulas(ln_Formulas) = ""
        '      Next ln_Formulas
        '      gs_sql = "exec sp_g_soportes_x_docto " & gn_ProcessID & ", " & lblDoc
        '      dbExecQuery gs_sql                      'Genera la tabla para datos de soportes
        '      dbEndQuery
        '      MDIGOS.rptSeguimiento.ReportFileName = RUTAREPS & "\GOS_ConsDoc.rpt"
        '      MDIGOS.rptSeguimiento.SelectionFormula = "{DOCUMENTO.documento} = " & lblDoc
        '      MDIGOS.rptSeguimiento.Formulas(0) = "Fecha = '" & gs_FechaHoy & "'"
        '      MDIGOS.rptSeguimiento.Formulas(1) = "Hora = '" & HoraSistema & "'"
        '      MDIGOS.rptSeguimiento.Formulas(2) = "Plaza = '" & lblNumPlaza & "  " & lblPlaza & "'"
        '      MDIGOS.rptSeguimiento.Formulas(3) = "Sucursal = '" & lblNumSuc & "  " & lblSuc & "'"
        '      MDIGOS.rptSeguimiento.Formulas(4) = "Instrum = '" & lblTipoInst & "'"
        '      MDIGOS.rptSeguimiento.Formulas(5) = "Divisa = '" & lblDivisa & "'"
        '      MDIGOS.rptSeguimiento.Formulas(6) = "TitDetalle = '" & lblTitDetalle & "'"
        '      MDIGOS.rptSeguimiento.Formulas(7) = "Detalle = '" & lblDetalle & "'"
        '      If lblComision.Visible = True Then      'Si hay dato de comision
        '          MDIGOS.rptSeguimiento.Formulas(8) = "Comision = '" & lblComision & "'"
        '      Else
        '          MDIGOS.rptSeguimiento.Formulas(8) = "Comision = ''"
        '      End If
        '      If lblVerificado = "Sin Verificar" Then 'El documento no esta verificado
        '          MDIGOS.rptSeguimiento.Formulas(9) = "Verificado = ''"
        '      Else
        '          MDIGOS.rptSeguimiento.Formulas(9) = "Verificado = 'Verificado'"
        '      End If
        '      If lblOriginal.Visible = True Then      'Si se recibio documento original
        '          MDIGOS.rptSeguimiento.Formulas(10) = "Original = 'Original'"
        '      Else
        '          MDIGOS.rptSeguimiento.Formulas(10) = "Original = ''"
        '      End If
        '      MaximizaReporte MDIGOS.rptSeguimiento
        'For ln_Formulas = 0 To 20               'Elimina formulas para reportes posteriores
        '          MDIGOS.rptSeguimiento.Formulas(ln_Formulas) = ""
        '      Next ln_Formulas
        '      ShowDefaultCursor
    End Sub

    '----------------------------------------------------------------------------
    'Llena una lista de Tipo ListView con el Query Determinado
    '----------------------------------------------------------------------------

    '    Public Sub LlenaLstView(ObjetoLista As ListView, Titulos As String, Query As String, AutoWidth As Boolean, Optional LowCase, Optional MoneyColumns, Optional FormatStrings, Optional DateColumns, Optional Status)

    '        Dim lc_Columna As ColumnHeader
    '        Dim li_LstDato As ListItem
    '        Dim ls_Titulos As String
    '        Dim ln_Titulos As Byte
    '        Dim ln_Next As Integer
    '        Dim ln_Counter As Long
    '        Dim ln_Separador As Integer
    '        Dim lb_LowCase As Boolean
    '        Dim lb_Limite As Boolean
    '        Dim ls_MoneyCol As String
    '        Dim ls_Datos As String
    '        Dim ls_Formato As String
    '        Dim ls_Formats As String
    '        Dim ls_Dates As String

    '        ln_Counter = 0
    '        lb_Limite = False
    '        lb_LowCase = False
    '        If Not IsMissing(LowCase) Then
    '            If Val(LowCase) <> 0 Then lb_LowCase = True     'Convierte texto a LowCaseText
    '        End If
    '        If Not IsMissing(MoneyColumns) Then
    '            ls_MoneyCol = CStr(MoneyColumns)
    '        Else
    '            ls_MoneyCol = ""
    '        End If
    '        If Not IsMissing(FormatStrings) Then
    '            ls_Formats = CStr(FormatStrings)
    '        Else
    '            ls_Formats = ""
    '        End If
    '        If Not IsMissing(DateColumns) Then
    '            ls_Dates = CStr(DateColumns)
    '        Else
    '            ls_Dates = ""
    '        End If
    '        If Not IsMissing(Status) Then
    '            If TypeOf Status Is Label Then
    '                Status.Tag = 0
    '                If TRADUCE = True Then
    '                    Status.Caption = "Searching for data..."
    '                Else
    '                    Status.Caption = "Buscando información..."
    '                End If
    '                Status.Refresh
    '                lb_Limite = True
    '            End If
    '        End If
    '        On Error GoTo ErrorDeclaration
    '        ObjetoLista.Arrange = 2
    '        ObjetoLista.HideColumnHeaders = False
    '        ObjetoLista.View = 3
    '        ln_Titulos = 1
    '        For ln_Separador = 1 To Len(Titulos)              'Cuenta el numero de titulos
    '            If Mid(Titulos, ln_Separador, 1) = "&" Then ln_Titulos = ln_Titulos + 1
    '        Next ln_Separador
    '        ObjetoLista.ListItems.Clear                       'Borra el contenido de la lista
    '        If ObjetoLista.ColumnHeaders.Count > 0 Then       'Verifica si la lista ya tiene columnas
    '            If AutoWidth = True Then                        'Si se requiere autowidth borra las columnas existentes
    '                For ln_Separador = ObjetoLista.ColumnHeaders.Count To 1 Step -1
    '                    ObjetoLista.ColumnHeaders.Remove ln_Separador
    '      Next ln_Separador
    '            End If
    '        Else                                              'Si no hay columnas las crea
    '            ls_Titulos = Trim(Titulos)
    '            If ln_Titulos > 1 Then
    '                ls_Titulos = ""
    '                For ln_Separador = 1 To Len(Titulos)
    '                    If Mid(Titulos, ln_Separador, 1) = "&" Then
    '          Set lc_Columna = ObjetoLista.ColumnHeaders.Add(, , ls_Titulos, (ObjetoLista.Width - 950) / ln_Titulos)
    '          ls_Titulos = ""
    '                    Else
    '                        ls_Titulos = ls_Titulos & Mid(Titulos, ln_Separador, 1)
    '                    End If
    '                Next ln_Separador
    '      Set lc_Columna = ObjetoLista.ColumnHeaders.Add(, , ls_Titulos, (ObjetoLista.Width - 1000) / ln_Titulos)
    '    Else
    '      Set lc_Columna = ObjetoLista.ColumnHeaders.Add(, , ls_Titulos, ObjetoLista.Width - 400)
    '    End If
    '        End If
    '        dbExecQuery Query                                 'Ejecuta el Query y llena la lista
    '        dbGetRecord
    '        If dbError = 0 Then
    '            Do While dbError = 0
    '                ln_Counter = ln_Counter + 1
    '                If lb_Limite = True Then                      'Si se requiere validar el numero de registros resultantes
    '                    If ln_Counter Mod 100 = 0 Then
    '                        If TRADUCE = True Then
    '                            Status.Caption = CStr(ln_Counter) & " Records found..."
    '                        Else
    '                            Status.Caption = CStr(ln_Counter) & " registros encontrados..."
    '                        End If
    '                        Status.Refresh
    '                    End If
    '                End If
    '                If ln_Counter > 2500 Then GoTo Continuo       'Si hay mas de 2500 registros en la lista, no la llena mas
    '                ls_Datos = Trim(dbGetValue(0))
    '                If lb_LowCase Then                            'Si se deben formatear los textos a Mayus/Minus
    '                    ls_Datos = LowCaseName(ls_Datos)
    '                End If
    '                If ls_MoneyCol <> "" Then                     'Si hay columnas con formato de moneda
    '                    If InStr(ls_MoneyCol, "+0") > 0 Then
    '                        ls_Datos = Format(ls_Datos, "###,###,###,##0.00")
    '                    End If
    '                End If
    '                If ls_Formats <> "" Then                      'Si hay columnas con formatos especiales
    '                    If InStr(ls_Formats, "+0-") > 0 Then
    '                        ls_Formato = Mid(ls_Formats, InStr(ls_Formats, "+0") + 3)
    '                        ln_Next = InStr(ls_Formato, "+")
    '                        If ln_Next > 0 Then
    '                            ls_Formato = Left(ls_Formato, InStr(ls_Formato, "+") - 1)
    '                        End If
    '                        ls_Datos = Format(ls_Datos, ls_Formato)
    '                    End If
    '                End If
    '                If ls_Dates <> "" Then                        'Si hay columna con formato de fecha
    '                    If InStr(ls_Dates, "+0") > 0 Then
    '                        ls_Datos = FechaDisplay(ls_Datos)
    '                    End If
    '                End If
    '      Set li_LstDato = ObjetoLista.ListItems.Add(, , ls_Datos)
    '      If ln_Titulos > 1 Then                        'Si hay mas de una columna en la lista
    '                    For ln_Separador = 1 To ln_Titulos - 1
    '                        ls_Datos = Trim(dbGetValue(ln_Separador))
    '                        If lb_LowCase Then                        'Si se deben formatear los textos a Mayus/Minus
    '                            ls_Datos = LowCaseName(ls_Datos)
    '                        End If
    '                        If ls_MoneyCol <> "" Then                 'Si hay columnas con formato de moneda
    '                            If InStr(ls_MoneyCol, "+" & CStr(ln_Separador)) > 0 Then
    '                                ls_Datos = Format(ls_Datos, "###,###,###,##0.00")
    '                            End If
    '                        End If
    '                        If ls_Formats <> "" Then                  'Si hay columnas con formatos especiales
    '                            If InStr(ls_Formats, "+" & CStr(ln_Separador) & "-") > 0 Then
    '                                ls_Formato = Mid(ls_Formats, InStr(ls_Formats, "+" & CStr(ln_Separador)) + 3)
    '                                ln_Next = InStr(ls_Formato, "+")
    '                                If ln_Next > 0 Then
    '                                    ls_Formato = Left(ls_Formato, InStr(ls_Formato, "+") - 1)
    '                                End If
    '                                ls_Datos = Format(ls_Datos, ls_Formato)
    '                            End If
    '                        End If
    '                        If ls_Dates <> "" Then                    'Si hay columna con formato de fecha
    '                            If InStr(ls_Dates, "+" & CStr(ln_Separador)) > 0 Then
    '                                ls_Datos = FechaDisplay(ls_Datos)
    '                            End If
    '                        End If
    '                        li_LstDato.SubItems(ln_Separador) = ls_Datos
    '                    Next ln_Separador
    '                End If
    'Continuo:
    '                dbGetRecord
    '                If ln_Counter >= 250000 Then GoTo FinQuery     'Si se han contado mas de 25000 registros termina el query
    '            Loop
    '        End If
    'FinQuery:
    '        dbEndQuery
    '        If lb_Limite = True Then
    '            If ln_Counter = 0 Then
    '                If TRADUCE = True Then
    '                    Status.Caption = "Record not found."
    '                Else
    '                    Status.Caption = "No se encontraron registros."
    '                End If
    '            ElseIf ln_Counter = 1 Then
    '                If TRADUCE = True Then
    '                    Status.Caption = "Record found."
    '                Else
    '                    Status.Caption = "Se encontró un registro."
    '                End If
    '            Else
    '                Status.Tag = ln_Counter
    '                If TRADUCE = True Then
    '                    Status.Caption = " " & CStr(ln_Counter) & " Records found."
    '                Else
    '                    Status.Caption = "Se encontraron " & CStr(ln_Counter) & " registros."
    '                End If
    '            End If
    '            Status.Refresh
    '        End If
    '        Exit Sub

    'ErrorDeclaration:
    '        dbEndQuery
    '        If lb_Limite = True Then
    '            If TRADUCE = True Then
    '                Status.Caption = "Unexpected Database Access Error."
    '            Else
    '                Status.Caption = "Ocurrio un error al consultar la base de datos."
    '            End If
    '            Status.Refresh
    '        End If
    '        If Err.Number = 380 Then
    '            If TRADUCE = True Then
    '                MsgBox "Unexpected Database Access Error.", vbCritical, "Error"
    '    Else
    '                MsgBox "No coincide el numero de columnas con los resultados del Query.", vbCritical, "Error"
    '    End If
    '        Else
    '            If TRADUCE = True Then
    '                MsgBox "Unexpected Error: " & Err.Description, vbCritical, "Error"
    '    Else
    '                MsgBox "Error de Ejecución: " & Err.Description, vbCritical, "Error"
    '    End If
    '        End If
    '    End Sub




    Private Sub cmdCierra_Click(sender As Object, e As EventArgs) Handles cmdCierra.Click
        Close()
    End Sub

    Private Sub cmdDigital_Click(sender As Object, e As EventArgs) Handles cmdDigital.Click

        l.MuestraDigitalizacion(Trim(lblDoc.Text), 1, 0)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Function ObtieneClasifTipoSoporte(ByVal numdocumento As String, n_OP As Byte, Fuente As Integer, n_TipoDoc As Byte)
        'C:Otiene los dtos necesarios para

        Dim lsSQL As String
        Dim ln_instrumento As Long
        Dim lsClasifTipoSoporte, ln_TipoInstr As String
        Dim ln_Contador As Integer
        Dim row As DataRow
        Dim value As Object

        Dim dsc, dscd As New Datasource
        Dim dtc, dtcd As DataTable

        On Error GoTo Error_cblmc_ObtieneUsuario

        'sólo en caso de que sea un deposito o un retiro
        If n_OP = 0 Or n_OP = 1 Then
            If n_OP = 0 Then                          'El documento es deposito
                gs_Sql = "Select "
                gs_Sql = gs_Sql & "tipo_instrumento "
                gs_Sql = gs_Sql & "From "
                gs_Sql = gs_Sql & "GOS.dbo.DEPOSITO_CED DC "
                gs_Sql = gs_Sql & "where "
                gs_Sql = gs_Sql & "documento = " & numdocumento
            Else                                                    'El documento es un retiro
                gs_Sql = "Select "
                gs_Sql = gs_Sql & "tipo_instrumento "
                gs_Sql = gs_Sql & "From "
                gs_Sql = gs_Sql & "GOS.dbo.RETIRO_CED RC "
                gs_Sql = gs_Sql & "where "
                gs_Sql = gs_Sql & "documento = " & numdocumento

            End If
            'dbExecQuery gs_Sql
            'dbGetRecord
            dtc = New DataTable
            dtc = dsc.RealizaConsulta(gs_Sql)
            If Not dtc Is Nothing Then
                If dtc.Rows.Count > 0 Then
                    'MsgBox("Tipo de Instrumento " + dtc.Rows.Count.ToString().PadRight(15), MsgBoxStyle.Information, "Consulta")
                    row = dtc.Rows(0) 'dtt.Rows.Count - 1)
                    value = row.Item("tipo_instrumento")
                    ln_instrumento = CStr(value)                 'Val(dbGetValue(0))
                End If
            Else
                'MsgBox("No hay tipo de instrumento", MsgBoxStyle.Information, "Consulta")
                Exit Function
            End If
            'Si hay respuesta
            'If dbError = 0 Then
            '    If Trim(dbGetValue(0)) <> "" Then
            '        ln_instrumento = Val(dbGetValue(0))
            '    End If
            'End If
            'dbEndQuery
            For ln_Contador = 0 To dgvSoportes.Rows.Count - 1 'lstSoportes.ListItems.Count
                gs_Sql = "Select "
                gs_Sql = gs_Sql & "TS.tipo_soporte, SV.opcional, SV.soporte_agrupado "
                gs_Sql = gs_Sql & "from "                                                                     '6                  ,7               ,8
                gs_Sql = gs_Sql & "GOS.dbo.SOPORTE SO  JOIN "
                gs_Sql = gs_Sql & "GOS.dbo.TIPO_SOPORTE TS "
                gs_Sql = gs_Sql & "ON "
                gs_Sql = gs_Sql & "TS.tipo_soporte = SO.tipo_soporte and "
                gs_Sql = gs_Sql & "soporte = " & Convert.ToString(dgvSoportes.Rows(ln_Contador).Cells(6).Value)
                'CStr(dgvSoportes.Rows(ln_Contador).Cells.Item("soporte"))     'lstSoportes.ListItems(ln_Contador).SubItems(6)
                'Se agrega la condición para encontrar la información de soportes válidos
                gs_Sql = gs_Sql & " LEFT JOIN GOS.dbo.SOPORTES_VALIDOS SV "
                gs_Sql = gs_Sql & " ON "
                gs_Sql = gs_Sql & " SV.fuente =  " & Fuente
                gs_Sql = gs_Sql & " and SV.tipo_documento = " & n_TipoDoc
                gs_Sql = gs_Sql & " and SV.tipo_instrumento = " & ln_instrumento
                gs_Sql = gs_Sql & " AND SO.tipo_soporte = SV.tipo_soporte "
                'MsgBox("SQL de Soportes " + gs_Sql, MsgBoxStyle.Information, "Consulta")
                dtcd = New DataTable
                dtcd = dsc.RealizaConsulta(gs_Sql)
                If Not dtcd Is Nothing Then
                    If dtcd.Rows.Count > 0 Then
                        'MsgBox("Detalle soportes " + dtcd.Rows.Count.ToString().PadRight(15), MsgBoxStyle.Information, "Consulta")
                        'row = dtcd.Rows(0) 'dtt.Rows.Count - 1)
                        'value = row.Item("tipo_instrumento")
                        'ln_instrumento = CStr(value)                 'Val(dbGetValue(0))
                    End If
                Else
                    'MsgBox("No hay tipo de instrumento", MsgBoxStyle.Information, "Consulta")
                    Exit Function
                End If
                '      dbExecQuery gs_Sql
                'dbGetRecord
                'Si hay respuesta
                'If dbError = 0 Then
                '16-jul-2002 LMC. Se obtiene la cadena a agregar a la descripción del soporte
                row = dtcd.Rows(0)
                'value = row.Item("agecliesufijo")
                'lblCta.Text = CStr(value)                'Val(dbGetValue(0))
                'lblCta.Text = dtcd.Rows(0).Item("tipo_soporte").ToString
                If IsNumeric(dtcd.Rows(0).Item("tipo_soporte").ToString) And IsNumeric(dtcd.Rows(0).Item("opcional").ToString) And IsNumeric(dtcd.Rows(0).Item("soporte_agrupado").ToString) Then
                    '                tipo_soporte,                         opcional,                         soporte_agrupado "
                    If Val(dtcd.Rows(0).Item("opcional").ToString) = 1 Then
                        lsClasifTipoSoporte = "OPCIONAL"
                    Else
                        If dtcd.Rows(0).Item("tipo_soporte").ToString <> dtcd.Rows(0).Item("soporte_agrupado").ToString Then
                            lsClasifTipoSoporte = "EQUIVALENTE"
                        Else
                            lsClasifTipoSoporte = "OBLIGATORIO"
                        End If
                    End If
                Else
                    lsClasifTipoSoporte = ""
                End If
                'dgvSoportes.Rows(ln_Contador).Item("descripcion").ToString = dgvSoportes.Rows(ln_Contador).Item("descripcion").ToString & " " & lsClasifTipoSoporte
                dgvSoportes.Rows(ln_Contador).Cells(2).Value = dgvSoportes.Rows(ln_Contador).Cells(2).Value & " " & lsClasifTipoSoporte
                ' lstSoportes.ListItems(ln_Contador).SubItems(2) = lstSoportes.ListItems(ln_Contador).SubItems(2) & " " & lsClasifTipoSoporte
                'End If
            Next
        End If
Error_cblmc_ObtieneUsuario:
        If Err.Number <> 0 Then
            MsgBox("Error: " & Err.Description, vbCritical, "Error")
        End If
    End Function

End Class