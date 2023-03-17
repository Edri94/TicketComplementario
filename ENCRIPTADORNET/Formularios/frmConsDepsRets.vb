Public Class frmConsDepsRets

    Dim mn_Contador As Byte
    Dim mb_Traduce As Boolean
    Dim mb_FED As Boolean 'No se utiliza la variable gn_FED por que el tipo de consulta se pasa por parametro
    Dim mn_Tipo As Byte

    Dim l As New Libreria

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub frmConsDepsRets_Load(sender As Object, e As EventArgs) Handles Me.Load

        'If bolEntraAlchemy Then Alchemy.Enabled = True
        'Centerform Me
        'Me.StartPosition = FormStartPosition.CenterScreen
        Me.CenterToParent()
        'CargarColores Me, cambio

        l.cambiarLabels(lblNumOperacion)
        l.cambiarLabels(lblMonto)
        l.cambiarLabels(lblFechaCaptura)
        l.cambiarLabels(lblDestino)
        l.cambiarLabels(lblConcilia)
        l.cambiarLabels(lblDocvsSop)
        l.cambiarLabels(lblNumCuenta)
        l.cambiarLabels(lblFechaOperacion)
        l.cambiarLabels(lblGrabadora)
        l.cambiarLabels(lblLinea)
        l.cambiarLabels(lbldisco)
        l.cambiarLabels(lblNumCR)
        l.cambiarLabels(lblCR)
        l.cambiarLabels(lblNumPlaza)
        l.cambiarLabels(lblPlaza)
        l.cambiarLabels(lblNumSucursal)
        l.cambiarLabels(lblSucursal)
        l.cambiarLabels(lblDocumento)
        l.cambiarLabels(lblCed)
        l.cambiarLabels(lblOtroDocto)
        l.cambiarLabels(lblNumFuncionario)
        l.cambiarLabels(lblMoneda)
        l.cambiarLabels(lblFuncionario)
        l.cambiarLabels(lblUsuarioCapt)
        l.cambiarLabels(lblNumDocto0)
        l.cambiarLabels(lblMontoDocto0)
        l.cambiarLabels(lblDescDocto0)
        l.cambiarLabels(lblMonedaDocto0)
        l.cambiarLabels(lblNumDocto1)
        l.cambiarLabels(lblMontoDocto1)
        l.cambiarLabels(lblDescDocto1)
        l.cambiarLabels(lblMonedaDocto1)
        l.cambiarLabels(lblNumDocto2)
        l.cambiarLabels(lblMontoDocto2)
        l.cambiarLabels(lblDescDocto2)
        l.cambiarLabels(lblMonedaDocto2)
        l.cambiarLabels(lblNumDocto3)
        l.cambiarLabels(lblMontoDocto3)
        l.cambiarLabels(lblDescDocto3)
        l.cambiarLabels(lblMonedaDocto3)
        l.cambiarLabels(lblNumDocto4)
        l.cambiarLabels(lblMontoDocto4)
        l.cambiarLabels(lblDescDocto4)
        l.cambiarLabels(lblMonedaDocto4)
        l.cambiarLabels(lblNumDocto4)
        l.cambiarLabels(lblMontoDocto4)
        l.cambiarLabels(lblDescDocto4)
        l.cambiarLabels(lblMonedaDocto4)
    End Sub

    Public Sub Muestra(ByVal Operacion As String, ByVal FED As Boolean, ByVal Tipo As Byte)

        Dim ln_Destino As Long
        'Dim ln_Contador As Byte ALB- Se cambia por mn_Contador
        Dim ln_TipoOper As Byte
        Dim ln_digitalizacion As Long

        Dim dst As New Datasource
        Dim dtt As DataTable

        Dim row As DataRow

        Dim li_operacion As Integer

        '    ShowWaitCursor
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        mb_FED = FED
        mn_Tipo = Tipo
        If mb_FED = True Then
            mb_Traduce = True
        Else
            mb_Traduce = False
        End If

        'Implementaremos una función para consultar el origen del usuario para determinar 
        'si se debe traducir o no

        l.verificarTraduccion()
        mb_Traduce = TRADUCE

        '    dbEndQuery
        '    'cpb 9marzo2006 SQL2000 concatenamiento de campos nulos
        gs_Sql = "Select "                  'Obtiene información del Depósito o Retiro
        gs_Sql = gs_Sql & "monto_operacion, "
        gs_Sql = gs_Sql & "convert(char(10),fecha_operacion,105) as fecha_operacion, "
        gs_Sql = gs_Sql & "convert(char(10),fecha_captura,105) as fecha_captura, "
        gs_Sql = gs_Sql & "linea, "
        gs_Sql = gs_Sql & "grabadora, "
        gs_Sql = gs_Sql & "numero_funcionario, "
        gs_Sql = gs_Sql & "rtrim(nombre_funcionario)+' '+rtrim(isnull(apellido_paterno, space(0)))+' '+rtrim(isnull(apellido_materno, space(0))) as nombreFuncionario, "
        gs_Sql = gs_Sql & "prefijo_agencia + '-' + cuenta_cliente as NumCuenta, "
        gs_Sql = gs_Sql & "nombre_usuario, "
        gs_Sql = gs_Sql & "status_operacion, "
        gs_Sql = gs_Sql & "operacion_definida_global, contacto "
        gs_Sql = gs_Sql & "from "
        gs_Sql = gs_Sql & "GOS.dbo.T_OPERACION OP, "
        gs_Sql = gs_Sql & "CATALOGOS.dbo.USUARIO US, "
        gs_Sql = gs_Sql & "TICKET.dbo.PRODUCTO_CONTRATADO PC, "
        gs_Sql = gs_Sql & "TICKET.dbo.OPERACION_DEFINIDA OD, "
        gs_Sql = gs_Sql & "CATALOGOS.dbo.AGENCIA AG, "
        gs_Sql = gs_Sql & "FUNCIONARIOS.dbo.FUNCIONARIO FU "
        gs_Sql = gs_Sql & "where "
        gs_Sql = gs_Sql & "OD.operacion_definida = OP.operacion_definida and "
        gs_Sql = gs_Sql & "PC.producto_contratado = OP.producto_contratado and "
        gs_Sql = gs_Sql & "OP.usuario_captura = US.usuario and "
        gs_Sql = gs_Sql & "AG.agencia = PC.agencia and "
        gs_Sql = gs_Sql & "AG.agencia = OD.agencia and "
        gs_Sql = gs_Sql & "OP.funcionario *= FU.funcionario and "
        gs_Sql = gs_Sql & "OP.operacion = " & Operacion
        '& " and "
        'gs_Sql = gs_Sql & "AG.agencia " & gs_PermisoAgencias          'Permiso Agencias
        '    dbExecQuery gs_Sql                            'Busca los datos de la operación
        '    dbGetRecord
        '    If dbError = 0 Then
        dtt = New DataTable
        dtt = dst.RealizaConsulta(gs_Sql)
        If dtt.Rows.Count > 0 Then
            row = dtt.Rows(0)
            li_operacion = row.Item("operacion_definida_global")
            If mb_Traduce = True Then                      'Si es consulta para el FED despliega Titulos en Ingles
                Select Case li_operacion 'Val(dbGetValue(10))
                    Case 83, 88                             'Operaciones de Retiro
                        ln_TipoOper = 1
                        lblTitulo.Text = "Withdrawals Review"
                        Me.Text = "Withdrawals Review"
                        lblDestCausa.Text = "Description:"
                        lblTitDocto.Text = "Withdrawal Type:"
                        lblFolioCheque.Text = "Cheque N°:"
                    Case 89                                 'Operacion de Retiro por Area Interna
                        ln_TipoOper = 1
                        lblTitulo.Text = "Internal Area Withdrawals Review"
                        Me.Text = "Internal Area Withdrawals Review"
                        lblDestCausa.Text = "Description:"
                        lblTitDocto.Text = "Withdrawal Type:"
                        lblFolioCheque.Text = "Cheque N°:"
                    Case 583, 588                           'Operacion de Deposito por Sucursal
                        ln_TipoOper = 0
                        lblTitulo.Text = "Deposits Review"
                        Me.Text = "Deposits Review"
                        lblDestCausa.Text = "Pay To:"
                        lblTitDocto.Text = "Deposit Type:"
                        lblFolioCheque.Text = "Reference:"
                    Case 589, 592                           'Operacion de Deposito por Area Interna
                        ln_TipoOper = 0
                        lblTitulo.Text = "Internal Area Deposits Review"
                        Me.Text = "Internal Area Deposits Review"
                        lblDestCausa.Text = "Pay To:"
                        lblTitDocto.Text = "Deposit Type:"
                        lblFolioCheque.Text = "Reference:"
                    Case 590                                'Operacion de Deposito por Sucursal 24 Hrs
                        ln_TipoOper = 0
                        lblTitulo.Text = "24 Hours Deposits Review"
                        Me.Text = "24 Hours Deposits Review"
                        lblDestCausa.Text = "Pay To:"
                        lblTitDocto.Text = "Deposit Type:"
                        lblFolioCheque.Text = "Reference:"
                    Case 591                                'Operacion de Deposito por Sucursal 24 Hrs
                        ln_TipoOper = 0
                        lblTitulo.Text = "Internal Area 24 Hours Deposits Review"
                        Me.Text = "Internal Area 24 Hours Deposits Review"
                        lblDestCausa.Text = "Pay To:"
                        lblTitDocto.Text = "Deposit Type:"
                        lblFolioCheque.Text = "Reference:"
                End Select
                lblTitMonto.Text = "Amount:"
                lblFecha.Text = "Transaction Date:"
                lblCuenta.Text = "Account Number:"
                lblFechaOp.Text = "Value Date:"
                lblRec.Text = "Recorder N°:"
                lblLineaTel.Text = "Phone Line N°:"
                lblStatusTicket.Text = "Ticket Status:"
                lblTCR.Text = "Regional Center:"
                lblTPlaza.Text = "Plaza:"
                lblTSuc.Text = "Branch:"
                lblOtroDoc.Text = "Other Document:"
                lblBPIGO.Text = "Account Executive:"
                lblFunc.Text = "Finantial Consultant:"
                lblUsr.Text = "Input User:"
                lblFicha.Text = "Slip N°:"
                lblTMoneda.Text = "Currency:"
                lblnum_docto.Text = "Doc. N°"
                lblmonto_docto.Text = "Doc. Ammount"
                lbldesc_docto.Text = "Document Description"
                lblTipoMoneda.Text = "Currency"
                cmdDigital.Text = "&Image"
                cmdConsultar.Text = "&Search"
                cmdImprimir.Text = "&Print"
                cmdCierra.Text = "&Exit"
            Else
                Select Case li_operacion
                    Case 83                                 'Operacion de Retiro por Sucursal en Firme
                        ln_TipoOper = 1
                        lblTitulo.Text = "Consulta de Retiro por Sucursal en Firme"
                        Me.Text = "Consulta de Retiro por Sucursal"
                        lblTitMonto.Text = "Monto del Retiro:"
                        lblDestCausa.Text = "Causa:"
                        lblTitDocto.Text = "Tipo de Retiro:"
                        lblFolioCheque.Text = "N° de Cheque:"
                    Case 88                                 'Operacion de Retiro por Devolución de Cheque
                        ln_TipoOper = 1
                        lblTitulo.Text = "Consulta de Retiro por Devolución de Cheque"
                        Me.Text = "Consulta de Retiro por Devolución de Cheque"
                        lblTitMonto.Text = "Monto del Retiro:"
                        lblDestCausa.Text = "Causa:"
                        lblTitDocto.Text = "Tipo de Retiro:"
                        lblFolioCheque.Text = "N° de Cheque:"
                    Case 89                                 'Operacion de Retiro por Area Interna
                        ln_TipoOper = 1
                        lblTitulo.Text = "Consulta de Retiro por Area Interna"
                        Me.Text = "Consulta de Retiro por Area Interna"
                        lblTitMonto.Text = "Monto del Retiro:"
                        lblDestCausa.Text = "Causa:"
                        lblTitDocto.Text = "Tipo de Retiro:"
                        lblFolioCheque.Text = "N° de Cheque:"
                    Case 583                                'Operacion de Deposito por Sucursal en Firme
                        ln_TipoOper = 0
                        lblTitulo.Text = "Consulta de Depósito por Sucursal en Firme"
                        Me.Text = "Consulta de Depósito por Sucursal"
                        lblTitMonto.Text = "Monto del Depósito:"
                        lblDestCausa.Text = "Destino:"
                        lblTitDocto.Text = "Tipo de Depósito:"
                        lblFolioCheque.Text = "N° de Folio:"
                    Case 588                                'Operacion de Deposito por Sucursal S.B.F
                        ln_TipoOper = 0
                        lblTitulo.Text = "Consulta de Depósito por Sucursal S.B.F"
                        Me.Text = "Consulta de Depósito por Sucursal S.B.F"
                        lblTitMonto.Text = "Monto del Depósito:"
                        lblDestCausa.Text = "Destino:"
                        lblTitDocto.Text = "Tipo de Depósito:"
                        lblFolioCheque.Text = "N° de Folio:"
                    Case 589                                'Operacion de Deposito por Area Interna
                        ln_TipoOper = 0
                        lblTitulo.Text = "Consulta de Depósito por Area Interna"
                        Me.Text = "Consulta de Depósito por Area Interna"
                        lblTitMonto.Text = "Monto del Depósito:"
                        lblDestCausa.Text = "Destino:"
                        lblTitDocto.Text = "Tipo de Depósito:"
                        lblFolioCheque.Text = "N° de Folio:"
                    Case 590                                'Operacion de Deposito por Sucursal 24 Hrs
                        ln_TipoOper = 0
                        lblTitulo.Text = "Consulta de Depósito por Sucursal 24 Horas"
                        Me.Text = "Consulta de Depósito por Sucursal 24 Horas"
                        lblTitMonto.Text = "Monto del Depósito:"
                        lblDestCausa.Text = "Destino:"
                        lblTitDocto.Text = "Tipo de Depósito:"
                        lblFolioCheque.Text = "N° de Folio:"
                    Case 591                                'Operacion de Deposito por Sucursal 24 Hrs
                        ln_TipoOper = 0
                        lblTitulo.Text = "Consulta de Depósito por Area Interna 24 Horas"
                        Me.Text = "Consulta de Depósito por Area Interna 24 Horas"
                        lblTitMonto.Text = "Monto del Depósito:"
                        lblDestCausa.Text = "Destino:"
                        lblTitDocto.Text = "Tipo de Depósito:"
                        lblFolioCheque.Text = "N° de Folio:"
                    Case 592                                'Operacion de Deposito por Area Interna S.B.F
                        ln_TipoOper = 0
                        lblTitulo.Text = "Consulta de Depósito por Area Interna S.B.F"
                        Me.Text = "Consulta de Depósito por Area Interna S.B.F"
                        lblTitMonto.Text = "Monto del Depósito:"
                        lblDestCausa.Text = "Destino:"
                        lblTitDocto.Text = "Tipo de Depósito:"
                        lblFolioCheque.Text = "N° de Folio:"
                End Select
            End If
            If mb_FED = False Then                       'Si es consulta para el FED no muestra status
                lblTStatus0.Visible = True
                lblTStatus1.Visible = True
                lblConcilia.Visible = True
                lblDocvsSop.Visible = True
            End If
            lblNumOperacion.Text = Operacion
            lblMonto.Text = "$" + String.Format("{0:0.00}", Convert.ToDecimal(row.Item("monto_operacion").ToString))
            lblFechaOperacion.Text = row.Item("fecha_operacion").ToString
            lblFechaCaptura.Text = row.Item("fecha_captura").ToString
            lblLinea.Text = row.Item("linea").ToString
            lblGrabadora.Text = row.Item("grabadora").ToString
            lblNumFuncionario.Text = row.Item("numero_funcionario").ToString
            lblFuncionario.Text = row.Item("nombreFuncionario").ToString 'pasar a minúsculas
            If lblFuncionario.Text = "" Then
                lblFuncionario.Text = row.Item("contacto").ToString
            End If
            lblNumCuenta.Text = row.Item("NumCuenta").ToString
            lblUsuarioCapt.Text = row.Item("nombre_usuario").ToString
            If Val(row.Item("status_operacion").ToString) = 250 Then            'El status de la operacion es de cancelada
                If mb_Traduce = True Then                    'Si es consulta para el FED despliega Titulos en Ingles
                    pnlCancelada.Text = "Canceled Operation"
                Else
                    pnlCancelada.Text = "Operación Cancelada"
                End If
                pnlCancelada.Visible = True
                lblStatusTicket.Visible = True
                'tmrBlink.Enabled = True
            Else
                pnlCancelada.Visible = False
                lblStatusTicket.Visible = False
                'tmrBlink.Enabled = False
            End If
        End If

        lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        '    Else
        '        dbEndQuery
        '        ShowDefaultCursor
        '        If mb_Traduce = True Then                      'Si es consulta para el FED despliega Titulos en Ingles
        '            MsgBox "Unexpected Database Access Error.", vbCritical, "SQL Server Error"
        'Else
        '            MsgBox "No es posible consultar la base de datos.", vbCritical, "SQL Server Error"
        'End If
        '        Exit Sub
        '    End If
        '    dbEndQuery
        Dim dsCR As New Datasource
        Dim dtCR As DataTable
        dtCR = New DataTable
        gs_Sql = "select "
        gs_Sql = gs_Sql & "centro_regional, "
        gs_Sql = gs_Sql & "nombre_centro_regional, "
        gs_Sql = gs_Sql & "plaza, "
        gs_Sql = gs_Sql & "nombre_plaza, "
        gs_Sql = gs_Sql & "sucursal, "
        gs_Sql = gs_Sql & "nombre_sucursal, "
        gs_Sql = gs_Sql & "referencia "
        If ln_TipoOper = 0 Then                       'la operacion es un deposito
            gs_Sql = gs_Sql & "from "
            gs_Sql = gs_Sql & "GOS.dbo.t_deposito_pme "
        Else                                          'la operacion es un retiro
            gs_Sql = gs_Sql & "from "
            gs_Sql = gs_Sql & "GOS.dbo.t_retiro_pme "
        End If
        gs_Sql = gs_Sql & "where "
        gs_Sql = gs_Sql & "operacion = " & Operacion
        '    dbExecQuery gs_Sql                            'Busca los datos del centro de costos
        '    dbGetRecord
        '    If dbError = 0 Then
        dtCR = dsCR.RealizaConsulta(gs_Sql)
        If dtCR.Rows.Count > 0 Then
            row = dtCR.Rows(0)
            lblNumCR.Text = Trim(row.Item("centro_regional").ToString)
            lblCR.Text = Trim(row.Item("nombre_centro_regional").ToString) 'Poner minúsculas
            lblNumPlaza.Text = Trim(row.Item("plaza").ToString)
            lblPlaza.Text = Trim(row.Item("nombre_plaza").ToString) 'Poner minúsculas
            lblNumSucursal.Text = Trim(row.Item("sucursal").ToString)
            lblSucursal.Text = Trim(row.Item("nombre_sucursal").ToString) 'Poner minúsculas
            lblCed.Text = Trim(row.Item("referencia").ToString)
        End If
        '    dbEndQuery
        Dim dsConc As New Datasource
        Dim dtConc As DataTable
        dtConc = New DataTable
        gs_Sql = "Select descripcion_status_concilia "
        gs_Sql = gs_Sql & "From "
        gs_Sql = gs_Sql & "GOS.dbo.OPERACION_TICKET OT, "
        gs_Sql = gs_Sql & "GOS.dbo.STATUS_CONCILIA SC "
        gs_Sql = gs_Sql & "Where "
        gs_Sql = gs_Sql & "SC.status_concilia = OT.status_concilia and "
        gs_Sql = gs_Sql & "OT.operacion = " & Operacion
        '    dbExecQuery gs_Sql                            'Busca el status de conciliacion del Ticket
        '    dbGetRecord
        '    If dbError = 0 Then
        dtConc = dsConc.RealizaConsulta(gs_Sql)
        If dtConc.Rows.Count > 0 Then
            row = dtConc.Rows(0)
            lblConcilia.Text = Trim(row.Item("descripcion_status_concilia").ToString)
            '        dbEndQuery
        End If
        Dim dsDoc As New Datasource
        Dim dtDoc As DataTable
        dtDoc = New DataTable
        gs_Sql = "Select documento, "
        gs_Sql = gs_Sql & "digitalizacion "
        gs_Sql = gs_Sql & "From "
        gs_Sql = gs_Sql & "GOS.dbo.DOCUMENTO "
        gs_Sql = gs_Sql & "Where "
        gs_Sql = gs_Sql & "operacion_concilia = " & Operacion
        '        dbExecQuery gs_Sql                          'Busca el documento con el que concilia
        '        dbGetRecord
        '        If dbError = 0 Then
        dtDoc = dsDoc.RealizaConsulta(gs_Sql)
        If dtDoc.Rows.Count > 0 Then
            row = dtDoc.Rows(0)
            lblConcilia.Text = lblConcilia.Text & "  (Documento N° " & Trim(row.Item("documento").ToString) & ")"
            If Val(row.Item("digitalizacion").ToString) > 0 Then
                cmdDigital.Enabled = True
                'If bolEntraAlchemy Then Alchemy.Enabled = True  'Ver que onda, nos indicaron quitarlo
                cmdDigital.Tag = Val(row.Item("documento").ToString)
                ln_digitalizacion = Val(row.Item("digitalizacion").ToString)
            Else
                cmdDigital.Enabled = False
                Alchemy.Enabled = False
                cmdDigital.Tag = 0
            End If
        End If
        '        dbEndQuery
        If cmdDigital.Enabled = True And ln_digitalizacion > 1 Then
            If Alchemy.Enabled = True And ln_digitalizacion > 1 Then
                'Regresar al boton de alchemy cuando este se implemente
                Dim dsDisco As New Datasource
                Dim dtDisco As DataTable
                dtDisco = New DataTable
                gs_Sql = "Select d.nombre as nombre "
                gs_Sql = gs_Sql & " From "
                gs_Sql = gs_Sql & " GOS.dbo.TDOCUMENTO t, GOS.dbo.TDISCO d"
                gs_Sql = gs_Sql & " Where "
                gs_Sql = gs_Sql & " t.disco = d.disco and documento = " & ln_digitalizacion
                'dbExecQuery gs_Sql                          'Busca el documento con el que concilia
                'dbGetRecord
                'If dbError = 0 Then
                dtDisco = dsDisco.RealizaConsulta(gs_Sql)
                If dtDisco.Rows.Count > 0 Then
                    row = dtDisco.Rows(0)
                    lbldisco.Visible = True
                    lbldisco.Text = Trim(row.Item("nombre").ToString)
                End If
                'dbEndQuery
            End If
        Else
            lblConcilia.Text = "No disponible"
        End If
        '    dbEndQuery
        Dim dsStatus As New Datasource
        Dim dtStatus As DataTable
        dtStatus = New DataTable
        gs_Sql = "Select descripcion_status_gos "
        gs_Sql = gs_Sql & "From "
        gs_Sql = gs_Sql & "GOS.dbo.DOCUMENTO doc, "
        gs_Sql = gs_Sql & "GOS.dbo.STATUS_GOS sg "
        gs_Sql = gs_Sql & "Where "
        gs_Sql = gs_Sql & "sg.status_gos = doc.status_gos and "
        gs_Sql = gs_Sql & "doc.ticket = " & Operacion
        '    dbExecQuery gs_Sql                            'Busca el status de conciliacion del Ticket
        '    dbGetRecord
        '    If dbError = 0 Then
        dtStatus = dsStatus.RealizaConsulta(gs_Sql)
        If dtStatus.Rows.Count > 0 Then
            row = dtStatus.Rows(0)
            lblDocvsSop.Text = Trim(row.Item("descripcion_status_gos").ToString)
        Else
            lblDocvsSop.Text = "No disponible"
        End If
        '    dbEndQuery
        Dim dsDescDoc As New Datasource
        Dim dtDescDoc As DataTable
        dtDescDoc = New DataTable
        gs_Sql = "Select "
        gs_Sql = gs_Sql & "TD.descripcion_documento, "
        gs_Sql = gs_Sql & "DR.otro_documento "
        gs_Sql = gs_Sql & "from "
        gs_Sql = gs_Sql & "TICKET.dbo.TIPO_DOCUMENTO TD, "
        If ln_TipoOper = 0 Then                       'La operacion es un deposito
            gs_Sql = gs_Sql & "GOS.dbo.T_DEPOSITO DR "
        Else                                          'La operacion es un retiro
            gs_Sql = gs_Sql & "GOS.dbo.T_RETIRO_PME DR "
        End If
        gs_Sql = gs_Sql & "where "
        gs_Sql = gs_Sql & "TD.tipo_documento = DR.tipo_documento and "
        gs_Sql = gs_Sql & "DR.operacion = " & Operacion
        '    dbExecQuery gs_Sql                            'Busca datos del Tipo de Documento
        '    dbGetRecord
        dtDescDoc = dsDescDoc.RealizaConsulta(gs_Sql)
        If dtDescDoc.Rows.Count > 0 Then
            row = dtDescDoc.Rows(0)
            '    If dbError = 0 Then
            If Trim(row.Item("descripcion_documento").ToString) <> "" Then
                lblDocumento.Text = Trim(row.Item("descripcion_documento").ToString)
            Else
                If mb_Traduce = True Then                    'Si es consulta para el FED despliega Titulos en Ingles
                    lblDocumento.Text = ""
                Else
                    lblDocumento.Text = "Sin Documento "
                End If
            End If
            lblOtroDocto.Text = Trim(row.Item("otro_documento").ToString)
        End If
        '    dbEndQuery
        Dim dsMoneda As New Datasource
        Dim dtMoneda As DataTable
        dtMoneda = New DataTable
        gs_Sql = "Select "
        gs_Sql = gs_Sql & "TM.descripcion_moneda, "
        If ln_TipoOper = 0 Then                       'La operacion es un deposito
            gs_Sql = gs_Sql & "DR.folio_linea_servicio as col1, "
            gs_Sql = gs_Sql & "DR.destino as col2, "
            gs_Sql = gs_Sql & "DR.otro_documento as col3 "
            gs_Sql = gs_Sql & "From "
            gs_Sql = gs_Sql & "GOS.dbo.T_DEPOSITO DR, "
        Else                                          'La operacion es un retiro
            gs_Sql = gs_Sql & "DR.numero_cheque as col1, "
            gs_Sql = gs_Sql & "DR.causa as col2 "
            gs_Sql = gs_Sql & "From "
            gs_Sql = gs_Sql & "GOS.dbo.T_RETIRO_PME DR, "
        End If
        gs_Sql = gs_Sql & "TICKET.dbo.TIPO_DOCUMENTO TD, "
        gs_Sql = gs_Sql & "TICKET.dbo.TIPO_MONEDA TM "
        gs_Sql = gs_Sql & "Where "
        gs_Sql = gs_Sql & "TD.tipo_documento = DR.tipo_documento and "
        gs_Sql = gs_Sql & "TM.tipo_moneda =* DR.tipo_moneda and "
        gs_Sql = gs_Sql & "DR.operacion = " & Operacion
        '    dbExecQuery gs_Sql                            'Busca mas datos particulares de la operacion
        '    dbGetRecord
        '    If dbGetValue(0) <> "" Then
        dtMoneda = dsMoneda.RealizaConsulta(gs_Sql)
        If dtMoneda.Rows.Count > 0 Then
            row = dtMoneda.Rows(0)
            If Trim(row.Item("descripcion_moneda").ToString) <> "" Then
                lblMoneda.Text = Trim(row.Item("descripcion_moneda").ToString) 'colocar minúsculas
            Else
                If mb_Traduce = True Then
                    lblMoneda.Text = "No Currency"
                Else
                    lblMoneda.Text = "Sin Moneda"
                End If
            End If

            lblNumExtra.Text = Trim(row.Item("col1").ToString)
            If ln_TipoOper = 0 Then                       'La operacion es un deposito
                If mb_Traduce = True Then
                    Select Case Val(Trim(row.Item("col2").ToString))
                        Case 0
                            lblDestino.Text = ""
                        Case 1
                            lblDestino.Text = "Client Account"
                        Case 2
                            lblDestino.Text = "BOT Securities"
                        Case 3
                            lblDestino.Text = "Credit"
                        Case 4
                            lblDestino.Text = Trim(row.Item("col3").ToString)
                    End Select
                Else
                    Select Case Val(Trim(row.Item("col2").ToString))
                        Case 0
                            lblDestino.Text = "Sin Destino"
                        Case 1
                            lblDestino.Text = "Depositar en Cuenta del Cliente"
                        Case 2
                            lblDestino.Text = "BOT Securities"
                        Case 3
                            lblDestino.Text = "Pago de Crédito"
                        Case 4
                            lblDestino.Text = Trim(row.Item("col3").ToString)
                    End Select
                End If
            Else
                lblDestino.Text = Val(Trim(row.Item("col2").ToString))
            End If
        End If

        '    dbEndQuery
        Dim dsDetInst As New Datasource
        Dim dtDetInst As DataTable
        dtDetInst = New DataTable
        Dim ls_monto As String
        gs_Sql = "Select "
        gs_Sql = gs_Sql & "sum(monto_documento) as summonto "
        gs_Sql = gs_Sql & "from "
        gs_Sql = gs_Sql & "TICKET.dbo.DETALLE_INSTRUMENTO "
        gs_Sql = gs_Sql & "where operacion = " & Operacion
        '    dbExecQuery gs_Sql                            'Verifica si el depósito tiene detalle de instrumentos
        '    dbGetRecord
        dtDetInst = dsDetInst.RealizaConsulta(gs_Sql)
        If dtDetInst.Rows.Count > 0 Then
            row = dtDetInst.Rows(0)
            ls_monto = row.Item("summonto").ToString
            If ls_monto <> "" Then


                lblTotalMontos.Text = "$" + String.Format("{0:0.00}", Convert.ToDecimal(ls_monto)) 'Format(Val(dbGetValue(0)), "#,###,###,##0.00")
                '    dbEndQuery
                If Convert.ToDecimal(ls_monto) > 0 Then              'Si el deposito tiene detalle de instrumentos
                    cmdConsultar.Top = cmdConsultar.Top + 130 '2600  'Ajusta la posición de los botones de comandos
                    cmdImprimir.Top = cmdImprimir.Top + 130 '2600
                    'cmdCierra.Top = cmdCierra.Top + 130 '2600

                    'fraDetalle.Visible = True                   'Muestra el frame de detalles
                    'Me.Height = 8100                           'Hace mas grande la pantalla
                    'Centerform Me
                    'Me.Top = 45
                    Me.Refresh()
                    mn_Contador = 0
                    Dim dsDetInst2 As New Datasource
                    Dim dtDetInst2 As DataTable
                    Dim totalMonto As Decimal
                    dtDetInst2 = New DataTable
                    gs_Sql = "Select DI.num_documento, "
                    gs_Sql = gs_Sql & "DI.monto_documento, "
                    gs_Sql = gs_Sql & "TM.descripcion_moneda, "
                    gs_Sql = gs_Sql & "DI.descripcion_documento "
                    gs_Sql = gs_Sql & "from "
                    gs_Sql = gs_Sql & "TICKET.dbo.DETALLE_INSTRUMENTO DI, "
                    gs_Sql = gs_Sql & "TICKET.dbo.TIPO_MONEDA TM "
                    gs_Sql = gs_Sql & "where "
                    gs_Sql = gs_Sql & "operacion = " & Operacion & " and "
                    gs_Sql = gs_Sql & "DI.tipo_moneda = TM.tipo_moneda"
                    'dbExecQuery gs_Sql                          'Busca los datos del detalle
                    'dbGetRecord
                    dtDetInst2 = dsDetInst2.RealizaConsulta(gs_Sql)
                    If Not IsNothing(dtDetInst2) Then
                        If dtDetInst2.Rows.Count > 0 Then
                            dgvDocumentos.DataSource = dtDetInst2
                            'lblNumTkts.Text = dtt.Rows.Count.ToString() '.PadRight(20 - lblNumTkts.Text.Length, " ")
                            'lblNumTkts.Width = AnchoEtiquetaNums
                            'MsgBox("Tickets " + dtt.Rows.Count.ToString().PadRight(15), MsgBoxStyle.Information, "Consulta")
                            dgvDocumentos.Columns(0).HeaderText = "Núm. de Docto."
                            dgvDocumentos.Columns(1).HeaderText = "Monto de Docto."
                            dgvDocumentos.Columns(2).HeaderText = "Descripción del Docto."
                            dgvDocumentos.Columns(3).HeaderText = "Moneda"
                            dgvDocumentos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            dgvDocumentos.Columns(1).DefaultCellStyle.Format = "c"
                            dgvDocumentos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            dgvDocumentos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            dgvDocumentos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                            For i = 0 To dtDetInst2.Rows.Count - 1 Step 1
                                totalMonto = totalMonto + dtDetInst2.Rows(i).Item("monto_documento")
                                'Convert.ToDecimal(dtDetInst2.Rows(i).Item("monto_documento").ToString)
                            Next
                            lblTotalMonto.Text = "$" + String.Format("{0:0.00}", Convert.ToDecimal(totalMonto))
                        Else
                            dgvDocumentos.DataSource = Nothing
                            dgvDocumentos.Visible = False
                            lblTotalMonto.Visible = False
                            lblTotal.Visible = False
                        End If
                    Else
                        dgvDocumentos.DataSource = Nothing
                        lblTotalMonto.Visible = False
                        lblTotal.Visible = False

                    End If

                    'Do While i < dtDetInst.Rows.Count 'dbError = 0
                    '    lblNumDocto(mn_Contador) = Trim(dbGetValue(0))
                    '    lblMontoDocto(mn_Contador) = Format(dbGetValue(1), "#,###,###,##0.00")
                    '    lblDescDocto(mn_Contador) = Trim(dbGetValue(3))
                    '    lblMonedaDocto(mn_Contador) = Trim(dbGetValue(2))
                    '    dbGetRecord
                    '    mn_Contador = mn_Contador + 1
                    '    i++
                    'Loop
                    'dbEndQuery
                Else
                    'fraDetalle.Visible = False
                End If
                '    dbEndQuery-------------------------
            End If
        End If
        '    ShowDefaultCursor
        '    If mb_FED = True Then
        '        cmdDigital.Enabled = True
        '        If bolEntraAlchemy Then Alchemy.Enabled = True
        '    End If
        Cursor = System.Windows.Forms.Cursors.Default
        Me.Visible = True
        Me.Refresh()
    End Sub

    Private Sub cmdCierra_Click(sender As Object, e As EventArgs) Handles cmdCierra.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class