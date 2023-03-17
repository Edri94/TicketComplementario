'*************    Módulo de Chequeras    **************'
'****       Fecha de Creación: 17/07/2020           ***'
'**** Creado por: SGGG-Susan Gabriela Gómez González***' 

Public Class frmCaptura


    Dim mbMenu As Boolean
    Dim mbSearching As Boolean
    Dim mbSoportes As Boolean
    Dim mbDocTieneActa As Boolean
    Dim msLastDate As String
    Dim mnDivisa As Byte
    Dim mnAgencia As Byte
    Dim mnAgTrasp As Byte
    Dim mnNewNode As Integer
    Dim moNodo As Object
    Dim moLastNode As Object
    Dim mnButton As Byte
    Dim mnTipoOp As Byte
    Dim msNumID As String
    Dim msTicket As String
    Dim msDocIni As String
    Dim ms_Desarrollo As String
    Dim ms_Catalogos As String
    Dim mn_TipoFuente As Byte
    Dim mn_Bbvab As Byte
    Dim mb_TicketNODisp As Integer  'Valores  1 o 0, 0  Ticket sin acta por ticket no disponible 0  'Este valor se cambia cuando se captura la acta para documentos que no tengan ticket válido
    Dim Mb_optDepGC As Boolean
    Dim Mb_optRetGC As Boolean

    Dim bNuevoRegistro As Boolean
    Dim bNuevoDocto As Boolean
    Dim bConcilSoporte As Boolean
    Dim iNoSoportes As Integer
    Dim iSoporte As Integer
    Dim iTotSoportes As Integer
    Dim sCliente As String
    Dim mn_Fuente As Byte
    Public usuario_gos As Integer


    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
        Dim lsTipoNodo As String
        If mnNewNode <> 0 Then
            If iNoSoportes = 0 Then
                lsTipoNodo = "Nuevo Documento?"
            Else
                lsTipoNodo = "Nuevo Soporte?"
            End If
            If MsgBox("¿Desea cancelar la captura del " & lsTipoNodo & ". Se cerrara la ventana de Captura ",
                      vbQuestion + vbYesNo + vbDefaultButton2, "Cancelación") = vbNo Then
                Exit Sub
            Else
                Me.Close()
            End If
        Else
            Me.Close()
        End If

    End Sub

    Private Sub frmCaptura_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim d As New Datasource
        Dim dtDatosTpFuente As DataTable
        Dim dtDatosTpDivisa As DataTable

        Me.CenterToScreen()

        LimpiaCampos()
        iSoporte = 1
        mbMenu = False
        mbSearching = False
        mnDivisa = 0
        mnAgencia = 0
        mnAgTrasp = 0
        mnNewNode = 0
        msDocIni = ""
        msLastDate = Date.Now.ToString("dd/MM/yyyy")
        mbSoportes = False
        'txNumDoc.ForeColor = lngWhite
        gvOperaciones.AutoGenerateColumns = False

        'Inicializa los txbox de ticket
        txTicket0.MaxLength = 7
        txTicket0.Text = ""
        txTicket.MaxLength = 7
        txTicket.Text = ""
        txTicketMER.MaxLength = 7
        txTicketMER.Text = ""
        txTicket2.MaxLength = 7
        txTicket2.Text = ""
        txTicketMER2.MaxLength = 7
        txTicketMER2.Text = ""

        'moLastNode.EnsureVisible
        tabOperaciones.TabIndex = 1

        'Llena combo de tipos de soporte
        dllSoporte.Items.Add("Obligatorios")
        'dllSoporte.Items.Add("Opcionales")
        'dllSoporte.Items.Add("Equivalentes")
        'dllSoporte.Items.Add("Todos")
        dllSoporte.SelectedIndex = 0

        'Inicializa la fecha de captura
        dtpFechaCaptura.Text = Date.Now.Date.ToString("dd-MM-yyyy")

        'Llena combo de Tipo Fuente
        dtDatosTpFuente = d.LlenaTipoFuente("")
        dllTipoFuente.Visible = True
        dllTipoFuente.DataSource = dtDatosTpFuente
        dllTipoFuente.DisplayMember = "descripcion_tipo_fuente"
        dllTipoFuente.ValueMember = "tipo_fuente"
        dllTipoFuente.SelectedIndex = -1

        If dllTipoFuente.Items.Count = 0 Then
            MsgBox("No es posible consultar los tipo de fuente.", vbCritical, "SQL Server Error")
        End If

        'Llena combos de tipo de divisa
        dtDatosTpDivisa = d.LlenaTipoDivisa("")
        dllDivisas.Visible = True
        dllDivisas.DataSource = dtDatosTpDivisa
        dllDivisas.DisplayMember = "descripcion_divisa"
        dllDivisas.ValueMember = "divisa"
        dllDivisas.SelectedIndex = -1
        dllDepDivisas.Visible = True
        dllDepDivisas.DataSource = dtDatosTpDivisa
        dllDepDivisas.DisplayMember = "descripcion_divisa"
        dllDepDivisas.ValueMember = "divisa"
        dllDepDivisas.SelectedIndex = -1
        dllRetDivisas.Visible = True
        dllRetDivisas.DataSource = dtDatosTpDivisa
        dllRetDivisas.DisplayMember = "descripcion_divisa"
        dllRetDivisas.ValueMember = "divisa"
        dllRetDivisas.SelectedIndex = -1
        'gvOperaciones.Enabled = False
        'If Permiso("PCAPTESPECIAL") Then
        '    dtpFechaCaptura.Locked = False                         
        'Deshabilita el cambio de fecha
        'End If
        ''Se supone que no existe ticket dentro de la tabla de T_OPERACION
        mb_TicketNODisp = 0
        bNuevoDocto = False
        mn_Fuente = 0

        tbRetiros.Parent = Nothing ' Ocultar Tabpage
        tbDepositos.Parent = tabOperaciones ' Mostrar Tabpage
        tabOperaciones.Appearance = Appearance.Normal
        tbDepositos.Text = ""


        'obtiene ID de usuario en BD de GOS, debe ser equivalente al usuario de TICKET
        usuario_gos = d.ObtieneUsuarioGOS
        If usuario_gos = 0 Then
            MsgBox("No tiene permisos para acceder a la captura de AICED", MsgBoxStyle.Information)
            Me.Close()
        End If

    End Sub
    Private Sub optLA()
        If mnTipoOp = 0 Then
            grbDepMercury.Visible = False
            grbDepMercury.Enabled = False
            grbDepAgencias.Enabled = True
            txCuentaMER.Text = ""
            txSufijoMER.Text = ""
            txTicketMER.Text = ""
        Else
            grbRetMercury.Visible = False
            grbRetMercury.Enabled = False
            grbRetAgencias.Enabled = True
            txCuentaMER2.Text = ""
            txSufijoMER2.Text = ""
            txTicketMER2.Text = ""
        End If
        LlenaCombosCte()
        If txCuenta.Text = "400329" Or txCuenta2.Text = "400329" Then
            If mnTipoOp = 0 Then
                grbDepMercury.Visible = True
                grbDepMercury.Enabled = True
            Else
                grbRetMercury.Visible = True
                grbRetMercury.Enabled = True
            End If
        Else
            If mnTipoOp = 0 Then
                grbDepMercury.Visible = False
                grbDepMercury.Enabled = False
            Else
                grbRetMercury.Visible = False
                grbRetMercury.Enabled = False
            End If
        End If
    End Sub

    Private Sub dllTipoFuente_DropDown(sender As Object, e As EventArgs) Handles dllTipoFuente.DropDown
        gvOperaciones.Enabled = True
        If dtpFechaCaptura.Text = Date.Now.ToString("dd/MM/yyyy") Then
            If dllTipoFuente.SelectedIndex <> -1 Then
                btAgregar.Text = "Agregar Docto."
                btAgregar.Enabled = True
                mnNewNode = 0
            End If
        End If
    End Sub

    Private Sub dllTipoFuente_DropDownClosed(sender As Object, e As EventArgs) Handles dllTipoFuente.DropDownClosed
        Dim d As New Datasource
        Dim dtDatoBbvab As DataTable

        If dllTipoFuente.SelectedIndex <> -1 Or dllTipoFuente.Text <> "" Then
            LimpiaCampos()
            mnNewNode = 0
            btAgregar.Enabled = True
            mn_TipoFuente = dllTipoFuente.SelectedValue
            dtDatoBbvab = d.DatoTipoFuente(mn_TipoFuente)
            mn_Bbvab = dtDatoBbvab.Rows(0).Item(0)

            txDepPlaza.Enabled = True
            dllDepPlaza.Enabled = True
            txRetPlaza.Enabled = True
            dllRetPlaza.Enabled = True
            If cbDocto.Checked = 1 Then
                dllTipoFuente.Enabled = False
            Else
                dllTipoFuente.Enabled = True
            End If
            gvOperaciones.DataSource = Nothing
            dtpFechaCaptura.Text = Date.Now.Date.ToString("dd-MM-yyyy")
            If tabOperaciones.TabIndex = 0 Then
                dtpFechaRecepcion.Text = Date.Now.Date.ToString("dd-MM-yyyy")
                dtpFechaOp.Text = Date.Now.Date.ToString("dd-MM-yyyy")
            Else
                dtpFechaRecepcion2.Text = Date.Now.Date.ToString("dd-MM-yyyy")
                dtpFechaOp2.Text = Date.Now.Date.ToString("dd-MM-yyyy")
            End If
            LlenaDataGrid()
            grbSoporte.Enabled = False
        End If
    End Sub

    Sub LimpiaCampos()
        Dim lo_Control As Control
        'Si es limpieza general de campos

        If mnNewNode = 0 Then
            For Each lo_Control In Controls
                LimpiaCamposGrp(Me.grbDatosDoc)
                LimpiaCamposGrp(Me.grbDepAgencias)
                LimpiaCamposGrp(Me.grbDepMercury)
                LimpiaCamposGrp(Me.grbRetAgencias)
                LimpiaCamposGrp(Me.grbRetMercury)
                LimpiaCampostab(Me.tabOperaciones)
                LimpiaCamposGrp(Me.grbSoporte)
            Next

            dllTipoSoporte.Text = ""

            grbSoporte.Visible = False
            lbNumSoportes.Text = "Documento Sin Soportes..."
            lbNumSoportes.Refresh()
            cbOriginal1.Checked = 0
            cbOriginal2.Checked = 0
            cbCheque.Checked = 0
            cbFirmaCliente.Checked = 0
            btImprimir.Enabled = False
            btGuarda.Enabled = False
            btElimina.Enabled = False
            mnDivisa = 0
            mnAgencia = 1
            grbDepMercury.Enabled = False
            grbDepMercury.Visible = False
            grbRetMercury.Enabled = False
            grbRetMercury.Visible = False
            dtpFechaOp.Text = Date.Now.ToString("dd/MM/yyyy")
            dtpFechaRecepcion.Text = Date.Now.ToString("dd/MM/yyyy")
            dtpFechaOp2.Text = Date.Now.ToString("dd/MM/yyyy")
            dtpFechaRecepcion2.Text = Date.Now.ToString("dd/MM/yyyy")
            Cursor = System.Windows.Forms.Cursors.Default
            txTicket0.Text = ""
            txTicket0.Enabled = False
            dllTipoDocto.SelectedIndex = -1
            txNumDoc.Text = ""
        Else
            For Each lo_Control In Controls
                LimpiaCamposGrp(Me.grbSoporte)
            Next
        End If
    End Sub
    Sub LimpiaCamposGrp(ByVal sNomcontrol As GroupBox)
        Dim lo_Control As Control
        'Recorremos todos los controles del formulario que enviamos  
        For Each lo_Control In sNomcontrol.Controls
            'Filtramos solo aquellos de tipo TextBox 
            If TypeOf lo_Control Is TextBox Then
                lo_Control.Text = "" ' eliminar el texto  
            End If
        Next
    End Sub
    Sub LimpiaCampostab(ByVal sNomcontrol As TabControl)
        Dim lo_Control As Control
        'Recorremos todos los controles del formulario que enviamos  

        For Each tab As TabPage In sNomcontrol.TabPages
            For Each lo_Control In tab.Controls
                If TypeOf lo_Control Is TextBox Then
                    lo_Control.Text = ""
                End If
                If TypeOf lo_Control Is ComboBox Then
                    lo_Control.Text = ""
                End If
            Next
        Next
    End Sub
    Private Sub DatosTipoDocto()
        Dim d As New Datasource
        Dim dtDatostpInst As DataTable

        'Habilita el area de captura
        tabOperaciones.Appearance = Appearance.Button
        tabOperaciones.Enabled = True
        'Despliega el tab correspondiente al tipo de operacion
        If mnTipoOp = 0 Then
            tbDepositos.Text = "Depositos"
            tbRetiros.Parent = Nothing ' Ocultar Tabpage
            tbDepositos.Parent = tabOperaciones ' Mostrar Tabpage
            dtpFechaRecepcion.Text = Date.Now.ToString("dd/MM/yyyy")
            tabOperaciones.SelectedIndex = 0
            'DEPOSITOS
            grbDepAgencias.Enabled = True
            grbDepMercury.Enabled = False
        Else
            tbRetiros.Parent = tabOperaciones ' Ocultar Tabpage
            tbDepositos.Parent = Nothing ' Mostrar Tabpage
            dtpFechaRecepcion2.Text = Date.Now.ToString("dd/MM/yyyy")
            tabOperaciones.SelectedIndex = 1
            'RETIROS
            grbRetAgencias.Enabled = True
            grbRetMercury.Enabled = False
        End If
        btGuarda.Enabled = True

        'Llena el combo de instrumento por tipo de operación
        dtDatostpInst = d.DatosTipoInstrumento(dllTipoDocto.SelectedValue, mn_Fuente, "")
        Select Case mnTipoOp
            Case 0
                dllDepTipoInstrumento.Visible = True
                dllDepTipoInstrumento.DataSource = dtDatostpInst
                dllDepTipoInstrumento.DisplayMember = "descripcion_instrumento"
                dllDepTipoInstrumento.ValueMember = "tipo_instrumento"
                dllDepTipoInstrumento.SelectedIndex = -1
                rbUS.Checked = True
                mnDivisa = 2
                cbOriginal1.Focus()
                txTicket.Focus()
            Case 1
                cbCheque.Checked = False
                cbFirmaCliente.Checked = False
                txRetNumCheque.Enabled = False
                dllRetTipoInstrumento.Visible = True
                dllRetTipoInstrumento.DataSource = dtDatostpInst
                dllRetTipoInstrumento.DisplayMember = "descripcion_instrumento"
                dllRetTipoInstrumento.ValueMember = "tipo_instrumento"
                dllRetTipoInstrumento.SelectedIndex = -1
                rbRetUS.Checked = True
                mnDivisa = 2
                cbOriginal2.Focus()
                txTicket2.Focus()
        End Select
        'End If
        'Llena combo de clientes
        optLA()
    End Sub

    Private Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        CancelaNuevoReg()
    End Sub

    Private Sub btGuarda_Click(sender As Object, e As EventArgs) Handles btGuarda.Click

        Dim d As New Datasource
        Dim lnTab As Byte
        Dim sTicket As String
        Dim sFechaOp As String
        Dim sInsertaSoporte As String
        Dim sInsertDocto As String

        Dim lsDoc As String
        Dim lsSoporte As String
        Dim lnTipoInstrumento As Integer
        Const iticketNodisp As Integer = 0

        Try
            'Verifica si el Horario de Operación es aún válido.
            If VerificarHrValida(1) = True Then
                lnTab = mnTipoOp
                'Si es un nuevo registro 
                If bNuevoRegistro = 0 Then
                    If bNuevoDocto = True Then
                        'Si es un nuevo Documento
GuardaDocumento:
                        If lnTab = 0 Then
                            sTicket = txTicket.Text
                            sFechaOp = dtpFechaOp.Value
                        Else
                            sTicket = txTicket2.Text
                            sFechaOp = dtpFechaOp2.Value
                        End If
                        If RevisaDatosDocto(lnTab) = False Then
                            Exit Sub
                        End If
                        'Cambio de validación del ticket para que tome el indice por fecha_operacion
                        If ValidaTicket(lnTab, sTicket, sFechaOp) = False Then
                            Exit Sub
                        End If
                        'inserta el nuevo Documento 
                        If lnTab = 0 Then
                            sInsertDocto = d.InsertaDocumento(txTicketMER.Text, txCuentaMER.Text, txSufijoMER.Text, txCuenta.Text, txSufijo.Text,
                                                dtpFechaRecepcion.Value, dtpFechaCaptura.Value, dtpFechaOp.Value, 1,
                                                dllTipoDocto.SelectedValue, mn_Fuente, txMonto.Text, txTicket.Text,
                                                txReferencia.Text, cbFirmaCliente.Checked, lnTab, sCliente,
                                                sCliente, dllDepTipoInstrumento.SelectedValue, txDepPlaza.Text,
                                                txDepSucursal.Text, mnDivisa, txDepFolioServicio.Text, cbOriginal1.Checked,
                                                txDepComision.Text, dllDepDivisas.SelectedValue, mn_Bbvab, txNumDoc.Text, "", usuario_gos)
                        Else

                            sInsertDocto = d.InsertaDocumento(txTicketMER2.Text, txCuentaMER2.Text, txSufijoMER2.Text, txCuenta2.Text, txSufijo2.Text,
                                                dtpFechaRecepcion2.Value, dtpFechaCaptura.Value, dtpFechaOp2.Value, 1,
                                                dllTipoDocto.SelectedValue, mn_Fuente, txMonto2.Text, sTicket,
                                                txReferencia2.Text, cbFirmaCliente.Checked, lnTab, sCliente,
                                                sCliente, dllRetTipoInstrumento.SelectedValue, txRetPlaza.Text,
                                                txRetSucursal.Text, mnDivisa, "", cbOriginal2.Checked,
                                                "", dllRetDivisas.SelectedValue, mn_Bbvab, txNumDoc.Text, txRetNumCheque.Text, usuario_gos)
                        End If

                        If sInsertDocto = "OK" Then
                            If gvOperaciones.Rows.Count = 0 Then
                                gvOperaciones.DataSource = d.LlenaGridDocto(txNumDoc.Text, dtpFechaCaptura.Text)
                            Else
                                gvOperaciones.DataSource = d.LlenaGridDocto("", dtpFechaCaptura.Text)
                            End If
                            gvOperaciones.AllowUserToAddRows = False
                            Concilia(txNumDoc.Text)
                            AgregarRegistro()
                            'If mnTipoOp = 0 Then
                            '   iNoSoportes = txSoportes.Text
                            'Else
                            iNoSoportes = 0
                            'End If

                            'Pinta de color azul la fila para indicar al usuario el nuevo documento  
                            SelectFilaDocto(txNumDoc.Text)

                            'Si el acta tiene un ticket no disponible
                            If mb_TicketNODisp = 0 Then
                                MsgBox("Deberá dar de alta acta administrativa con el número de documento : <<" & lsDoc & ">> ")
                            End If
                            'Se inicializa la variable para la captura de un nuevo documento
                            mb_TicketNODisp = 0
                        Else
                            If MsgBox("Ha ocurrido un error al guardar los datos del documento. ¿Desea Reintentar?", vbQuestion + vbRetryCancel, "SQL Server Error") = vbRetry Then
                                GoTo GuardaDocumento
                            Else
                                CancelaNuevoReg()
                            End If
                        End If
                    Else
                        'El nodo es un nuevo soporte
GuardaSoporte:
                        If RevisaDatosSoporte() = False Then
                            Exit Sub
                        End If
                        sInsertaSoporte = d.InsertaSoporte(txNumDoc.Text, txNumDocSoporte.Text, txDetalle.Text, dllTipoSoporte.SelectedValue,
                                            dllDivisas.SelectedValue, Decimal.Parse(txImporteSoporte.Text), dtpFechaSoporte.Value)
                        If sInsertaSoporte = "NOK" Then
                            If MsgBox("A ocurrido un error al guardar los datos del soporte. ¿Desea Reintentar?", vbQuestion + vbRetryCancel, "SQL Server Error") = vbRetry Then
                                GoTo GuardaSoporte
                            Else
                                CancelaNuevoReg()
                                Exit Sub
                            End If
                        Else
                            'If mnTipoOp = 0 Then
                            '    'Deposito CED
                            '    lnTipoInstrumento = dllDepTipoInstrumento.SelectedValue
                            '    lsSoporte = txSoportes.Text
                            'Else
                            '    'Retiro CED
                            '    lnTipoInstrumento = dllRetTipoInstrumento.SelectedValue
                            '    lsSoporte = txSoportes2.Text
                            'End If
                            lsSoporte = 1
                            Concilia(txNumDoc.Text)
                        End If

                        'iNoSoportes = iNoSoportes - 1
                        iNoSoportes = iNoSoportes + 1
                        If iNoSoportes <> 0 Then
                            AgregarRegistro()
                            If gvOperaciones.Rows.Count = 0 Then
                                gvOperaciones.DataSource = d.LlenaGridDocto(txNumDoc.Text, dtpFechaCaptura.Text)
                            Else
                                gvOperaciones.DataSource = d.LlenaGridDocto("", dtpFechaCaptura.Text)
                            End If
                            'Pinta de color azul la fila para indicar al usuario el nuevo documento  
                            SelectFilaDocto(txNumDoc.Text)
                            Exit Sub
                        End If
                        If gvOperaciones.Rows.Count = 0 Then
                            gvOperaciones.DataSource = d.LlenaGridDocto(txNumDoc.Text, dtpFechaCaptura.Text)
                        Else
                            gvOperaciones.DataSource = d.LlenaGridDocto("", dtpFechaCaptura.Text)
                        End If
                        'Pinta de color azul la fila para indicar al usuario el nuevo documento  
                        SelectFilaDocto(txNumDoc.Text)
                        btGuarda.Enabled = False
                        dllTipoDocto.Enabled = False
                        btCancelar.Enabled = False
                        grbSoporte.Enabled = False
                        tabOperaciones.Enabled = False
                        mnNewNode = 0
                    End If

                    dllTipoDocto.Enabled = False
                    btCancelar.Enabled = False
                    tabOperaciones.Enabled = False
                End If
                grbDatosDoc.Enabled = True
                dtpFechaCaptura.Enabled = False
                btElimina.Enabled = True
                btImprimir.Enabled = True
            End If
            Exit Sub
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento btGuarda_Click, Error:" & ex.Message, vbInformation, "Seleccionar una operacion")
            Exit Sub
        End Try
    End Sub

    Sub SelectFilaDocto(ByVal iNumDocto As Integer)
        For i As Integer = 0 To gvOperaciones.Rows.Count - 1
            'Si el valor de la primera celda ubicada, por ejemplo, en la fila 1 es igual a 3
            If gvOperaciones.Rows(i).Cells("documento").Value = iNumDocto Then
                'Mueve el cursor a dicha fila
                gvOperaciones.CurrentCell = gvOperaciones.Item(0, i)
                'Pinta de color azul la fila para indicar al usuario el nuevo documento  
                gvOperaciones.Rows(i).Selected = True
                Exit For
            End If
        Next
    End Sub

    Private Function ValidaTicket(ByVal lnTabTicket As Byte, ByVal sticket As String,
                                  ByVal sFechaOp As String) As Boolean
        Dim d As New Datasource
        Dim dtTicketDocto As DataTable
        Dim dtTicketDisponible As DataTable

        ValidaTicket = True
        mb_TicketNODisp = 0
        If Trim(sticket) <> "" Then
            If IsNumeric(Trim(sticket)) Then
                sticket = sticket.ToString.PadRight(7, "0")
                'Se busca el numero dlnTabTickete ticket
                dtTicketDocto = d.BuscaTicketDocto(sticket, sFechaOp)
                If dtTicketDocto.Rows.Count <> 0 Then
                    If MsgBox("El número de documento <<" & Val(dtTicketDocto.Rows(0).Item(0)) & ">> tiene este número de ticket. ¿Desea continuar?", vbQuestion + vbYesNo, "Validación de Número de Ticket") = vbNo Then
                        ValidaTicket = False
                    Else
                        MsgBox("Recuerde que este número de ticket ya fue utilizado.", vbInformation, "Validación de Número de Ticket")
                    End If
                End If
                ' Validación de ticket disponible (es disponible cuando se encuentra en la tabla de T_OPERACION)
                If Trim(sticket) <> "" Then
                    dtTicketDisponible = d.TicketDisponible(sticket)
                    If dtTicketDisponible.Rows.Count > 0 Then
                        mb_TicketNODisp = 1
                    Else
                        If MsgBox("El número de ticket: <<" & Trim(sticket) & ">> no existe. " & "Tendrá que capturar una acta administrativa por Ticket No Disponible." & Chr(13) & "¿Desea continuar?", vbQuestion + vbYesNo, "Validación de Número de Ticket") = vbNo Then
                            ValidaTicket = False
                        End If
                        mb_TicketNODisp = 0
                    End If
                End If
            Else
                If MsgBox("El número de Ticket debe ser numérico. ¿Desea continuar?", vbQuestion + vbYesNo, "Formato Incorrecto") = vbNo Then
                    ValidaTicket = False
                End If
            End If
            Exit Function
        Else
            MsgBox("No ha capturado el Número de Ticket", vbInformation, Me.Text)
        End If
    End Function

    Public Function VerificarHrValida(ByVal sTipoAcceso As Integer) As Boolean
        Dim d As New Datasource
        Dim dtTpAcceso As DataTable

        Dim Lda_HrIni As Object
        Dim Lda_HrFin As Object
        Dim Lda_HrAct As Object
        Dim blValido As Boolean

        Lda_HrAct = ""
        Lda_HrIni = ""
        Lda_HrFin = ""
        blValido = True
        dtTpAcceso = d.TipoAcceso(sTipoAcceso)
        If dtTpAcceso.Rows.Count > 0 Then
            Lda_HrIni = dtTpAcceso.Rows(0).Item(1)
            Lda_HrFin = dtTpAcceso.Rows(0).Item(2)
            Lda_HrAct = dtTpAcceso.Rows(0).Item(3)
        End If

        If Lda_HrAct < Lda_HrIni Or Lda_HrAct > Lda_HrFin Then
            MsgBox("La hora actual  (" & Lda_HrAct &
                  ")  no se encuentra en el rango " & vbCrLf &
                  Space(4) & "del Horario de Operación [" & Lda_HrIni & " - " & Lda_HrFin & "]")
            blValido = False
        End If

        VerificarHrValida = blValido
    End Function
    '------------------------------------------------------
    'Hace la conciliacion del documento contra sus soportes
    '------------------------------------------------------
    Private Sub Concilia(ByVal sDocto As String)

        Dim d As New Datasource
        Dim dtConcilia As String
        Dim dtDatoEstatus As DataTable

        'Concilia el documento
        dtConcilia = d.Concilia(sDocto)
        If dtConcilia = "NOK" Then
            MsgBox("Ocurrio un error al ejecutar el proceso de conciliación con Soportes.", vbCritical, "Captura")
        End If

        'Busca el status de conciliación resultante
        dtDatoEstatus = d.EstatusConcilia(sDocto)
        If Val(dtDatoEstatus.Rows(0).Item(0)) = 5 Then
            'Si el documento esta conciliado
            bConcilSoporte = 1
        Else
            bConcilSoporte = 0
        End If

        'gvOperaciones.DataSource = d.LlenaGridDocto()

    End Sub

    '---------------------------------------------------------------------
    'Revisa que no haya datos faltantes o erroneos para guardar el soporte
    '---------------------------------------------------------------------
    Private Function RevisaDatosSoporte() As Boolean

        Dim sFechaRecepcion As String

        RevisaDatosSoporte = False
        If dllSoporte.SelectedIndex = -1 Then
            MsgBox("Es necesario indicar la clasificacion de los soportes.", vbInformation, "Dato Faltante")
            dllSoporte.Focus()
        End If

        If dllTipoSoporte.SelectedIndex = -1 Then
            MsgBox("Es necesario indicar el tipo de soporte.", vbInformation, "Dato Faltante")
            If dllTipoSoporte.Enabled = True Then dllTipoSoporte.Focus()
        End If

        If Trim(txImporteSoporte.Text) = "" Then
            MsgBox("Es necesario indicar el importe del soporte.", vbInformation, "Dato Faltante")
            txImporteSoporte.Focus()
            Exit Function
        End If

        'Se valida la fecha del soporte
        If tabOperaciones.SelectedIndex = 0 Then
            sFechaRecepcion = dtpFechaRecepcion.Value
        Else
            sFechaRecepcion = dtpFechaRecepcion2.Value
        End If

        'La fecha de recepción debe ser mayor igual que la fecha de soporte
        If Not CDate(sFechaRecepcion) >= CDate(dtpFechaSoporte.Value.ToString("dd/MM/yyyy")) Then
            MsgBox("La fecha del soporte debe ser menor o igual a la fecha de recepción.", vbInformation)
            dtpFechaSoporte.Focus()
        Else
            RevisaDatosSoporte = True
        End If

    End Function
    Private Sub cbDocto_Click(sender As Object, e As EventArgs) Handles cbDocto.Click

        Dim d As New Datasource
        Dim dtDatosTpFuente As DataTable

        LimpiaCampos()
        txNumDoc.Text = ""

        gvOperaciones.DataSource = Nothing
        If cbDocto.Checked = True Then
            btAgregar.Enabled = False
            txDocIni.Enabled = True
            txDocIni.Focus()
            dllTipoFuente.Enabled = False
            dtpFechaCaptura.Enabled = False

            dtpFechaCaptura.Text = ""
            dllTipoFuente.SelectedIndex = -1
        Else
            txDocIni.Text = ""
            txDocIni.Enabled = False
            dllTipoFuente.Enabled = True
            dtpFechaCaptura.Enabled = True
            'Inicializa Fecha Captura con Fecha Hoy
            dtpFechaCaptura.Text = Date.Now.Date.ToString("dd-MM-yyyy")
            dllTipoFuente.Focus()
            'Llena el Combo Tipo Fuente
            dtDatosTpFuente = d.LlenaTipoFuente("")
            dllTipoFuente.Visible = True
            dllTipoFuente.DataSource = dtDatosTpFuente
            dllTipoFuente.DisplayMember = "descripcion_tipo_fuente"
            dllTipoFuente.ValueMember = "tipo_fuente"
            dllTipoFuente.SelectedIndex = -1

        End If
    End Sub
    Private Sub txDepFolioServicio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txDepFolioServicio.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txNumDocSoporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txNumDocSoporte.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txDocIni_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txDocIni.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
        txDocIni.MaxLength = 6
        If dllTipoFuente.SelectedIndex <> -1 Then
            LimpiaCampos()
            dtpFechaCaptura.Text = Date.Now.Date.ToString("dd-MM-yyyy")
            gvOperaciones.DataSource = Nothing
            dllTipoFuente.SelectedIndex = -1
        End If
    End Sub
    Private Sub txRetNumCheque_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txRetNumCheque.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txReferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txReferencia.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txReferencia2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txReferencia2.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txCuenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txCuenta.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txCuenta2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txCuenta2.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txSufijo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txSufijo.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txSufijo2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txSufijo2.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txTicket0_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txTicket0.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
        txTicket0.MaxLength = 7
        If dllTipoDocto.SelectedIndex > -1 Then
            mnNewNode = 0
            LimpiaCampos()
            mnNewNode = 1
            txTicket0.Enabled = True
        End If
    End Sub

    Private Sub txDepPlaza_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txDepPlaza.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txRetPlaza_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txRetPlaza.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txDepSucursal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txDepSucursal.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txRetSucursal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txRetSucursal.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txSoportes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txSoportes.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txDocIni_Leave(sender As Object, e As EventArgs) Handles txDocIni.Leave
        If Trim(txDocIni.Text) <> "" Then
            If cbDocto.Checked = True Then
                If BuscarDatosDocumento() = False Then Exit Sub
                LlenaDataGrid()
                gvOperaciones.Enabled = True
                btAgregar.Enabled = True
            Else
                txDocIni.Text = ""
                txDocIni.Focus()
                Exit Sub
            End If
        Else
            If cbDocto.Checked = True Then
                LimpiaCampos()
                Exit Sub
            End If
            Exit Sub
        End If
    End Sub

    Sub LlenaDataGrid()
        Dim d As New Datasource

        If dllTipoFuente.SelectedIndex = -1 Then Exit Sub
        If cbDocto.Checked = True Then
            gvOperaciones.DataSource = d.LlenaGridDocto(txDocIni.Text, dtpFechaCaptura.Text)
        Else
            gvOperaciones.DataSource = d.LlenaGridDocto("", dtpFechaCaptura.Text)
        End If
    End Sub

    Private Sub dllTipoSoporte_DropDown(sender As Object, e As EventArgs) Handles dllTipoSoporte.DropDown
        Dim d As New Datasource
        Dim dtDatosSoporte As DataTable
        Dim sTipoInstrumento As String

        If mnTipoOp = 0 Then
            sTipoInstrumento = dllDepTipoInstrumento.SelectedValue
        Else
            sTipoInstrumento = dllRetTipoInstrumento.SelectedValue
        End If

        dtDatosSoporte = d.tipoSoporte(dllSoporte.SelectedIndex, cbSopVal.Checked, mn_Fuente,
                                           dllTipoDocto.SelectedValue, sTipoInstrumento)


        If dtDatosSoporte.Rows.Count = 0 Then
            'InfoBox "No existe soportes de este tipo para este instrumento."
            dllTipoSoporte.Enabled = False
            dllSoporte.Focus()
        Else
            dllTipoSoporte.DataSource = dtDatosSoporte
            dllTipoSoporte.DisplayMember = "descripcion_soporte"
            dllTipoSoporte.ValueMember = "tipo_soporte"
        End If

    End Sub

    Private Sub dllSoporte_Leave(sender As Object, e As EventArgs) Handles dllSoporte.Leave
        Dim d As New Datasource
        Dim dtDatosSoporte As DataTable
        Dim sTipoInstrumento As String
        Dim iNSoporte As Integer
        'Calsificación del tipo de soporte obligatorio, opcional, equivalente
        Dim sClasifTipoSoporte As String
        sClasifTipoSoporte = ""

        If mnTipoOp = 0 Then
            sTipoInstrumento = dllDepTipoInstrumento.SelectedValue
        Else
            sTipoInstrumento = dllRetTipoInstrumento.SelectedValue
        End If
        iNSoporte = Val(dllSoporte.SelectedValue)

        If dllSoporte.SelectedIndex > -1 Then
            dllTipoSoporte.Enabled = True
            'No se requieren todos los soportes
            If dllSoporte.SelectedIndex <> 3 Then
                If cbSopVal.Checked = True Then
                    'Se busca la cadena a agregar en caso
                    Select Case dllSoporte.SelectedIndex
                        Case Is = 0                     'Soportes obligatorios
                            sClasifTipoSoporte = "OBLIGATORIO"
                        Case Is = 2                     'Soporte equivalente
                            sClasifTipoSoporte = "EQUIVALENTE"
                        Case Is = 1                     'Soporte opcional
                            sClasifTipoSoporte = "OPCIONAL"
                        Case Else
                            sClasifTipoSoporte = ""
                    End Select
                End If
            End If

            'Se agrega la cadena de obligatorio, opcional, equivalente

            dtDatosSoporte = d.tipoSoporte(dllSoporte.SelectedIndex, cbSopVal.Checked, mn_Fuente,
                                           dllTipoDocto.SelectedValue, sTipoInstrumento)


            If dtDatosSoporte.Rows.Count = 0 Then
                'InfoBox "No existe soportes de este tipo para este instrumento."
                dllTipoSoporte.Enabled = False
                dllSoporte.Focus()
            Else
                dllTipoSoporte.DataSource = dtDatosSoporte
                dllTipoSoporte.DisplayMember = "descripcion_soporte"
                dllTipoSoporte.ValueMember = "tipo_soporte"
            End If
            'No se selecciono algun elemento de la lista
        Else
            dllTipoSoporte.DataSource = Nothing
            dllTipoSoporte.DisplayMember = Nothing
            dllTipoSoporte.ValueMember = Nothing
            dllTipoSoporte.Enabled = False
        End If

    End Sub
    Function BuscarDatosDocumento() As Boolean
        Dim d As New Datasource
        Dim dtDatosTpFuente As DataTable
        Dim dtDatosFuente As DataTable
        Dim dtDatosDocto As DataTable
        Dim sFuente As String
        Dim iTipoFuente As Integer

        'LimpiaDatos
        BuscarDatosDocumento = False

        'Busca fuentes de documentos validos
        dtDatosDocto = d.BuscaDocumentos(txDocIni.Text)

        If dtDatosDocto.Rows().Count() > 0 Then
            dtpFechaCaptura.Text = dtDatosDocto.Rows(0).Item(1)
            sFuente = Trim(dtDatosDocto.Rows(0).Item(2))
            iTipoFuente = Trim(dtDatosDocto.Rows(0).Item(3))
        Else
            'No se encontraron fuentes
            MsgBox("El Documento  " & txDocIni.Text & "  no se ha encontrado.", vbInformation, "Captura de Documento")
            txDocIni.Text = ""
            txDocIni.Focus()
            Exit Function
        End If

        'Llena el combo de Tipos de Fuente (Tipo información)
        dtDatosTpFuente = d.LlenaTipoFuente(iTipoFuente)
        dllTipoFuente.Visible = True
        dllTipoFuente.DataSource = dtDatosTpFuente
        dllTipoFuente.DisplayMember = "descripcion_tipo_fuente"
        dllTipoFuente.ValueMember = "tipo_fuente"
        dllTipoFuente.SelectedIndex = 0

        BuscarDatosDocumento = True
    End Function

    '-----------------------------------------------------------------------
    'Revisa que no haya datos faltantes o erroneos para guardar el documento
    '-----------------------------------------------------------------------
    Private Function RevisaDatosDocto(NumTab As Byte) As Boolean
        Dim d As New Datasource
        Dim dtDatosTicket As DataTable

        RevisaDatosDocto = False
        If Trim(dtpFechaCaptura.Text) = "" Then
            MsgBox("Es necesario indicar la fecha de captura.", vbInformation, "Dato Faltante")
            dtpFechaCaptura.Focus()
            Exit Function
        End If
        If Trim(txDepComision.Text) = "" Then
            txDepComision.Text = "0.00"
        End If

        If mnTipoOp = 0 Then
            If Trim(txReferencia.Text) = "" Then
                'No se ha escrito el Numero de Ficha CED
                MsgBox("Es necesario indicar el número de Folio.", vbInformation, "Dato Faltante")
                txReferencia.Focus()
                Exit Function
            End If
        Else
            If Trim(txReferencia2.Text) = "" Then
                'No se ha escrito el Numero de Ficha CED
                MsgBox("Es necesario indicar el número de Folio.", vbInformation, "Dato Faltante")
                txReferencia2.Focus()
                Exit Function
            End If
        End If

        'Revisión de condiciones de fechas
        Select Case NumTab
            Case 0
                'Revisa Datos para Depósito
                If (Val(txTicketMER.Text) <> 0 And Trim(txTicket.Text) = "") Then
                    'Busca el ticket correspondiente en Agencias
                    dtDatosTicket = d.RevisaDatosTicket(NumTab, txTicketMER.Text, txReferencia.Text, txCuentaMER.Text)

                    If dtDatosTicket.Rows().Count > 0 Then
                        'Se encuentra el Ticket
                        txTicket.Text = Val(dtDatosTicket.Rows(0).Item(0))
                    Else
                        'No se encuentra el Ticket
                        txTicket.Text = 0
                        'No existe Ticket de Agencias
                        MsgBox("No se encuentra el Ticket de Agencias correspondiente al de Mercury.", vbInformation, "Ticket Inválido")
                        If txTicket.Enabled = True Then
                            txTicket.Focus()  'solo si se encuentra habilitado en campo
                        End If
                        Exit Function
                    End If
                End If
                If Trim(txCuentaMER.Text) <> "" Then
                    'Cta. no debe ser nula
                    If Len(txCuentaMER.Text) < 6 Then
                        'Cta. debe ser de 6 dígitos
                        MsgBox("El número de Cuenta debe ser de 6 dígitos.", vbInformation, "Error en el Formato")
                        txCuentaMER.Focus()
                        Exit Function
                    End If
                End If
                If Val(txTicketMER.Text) <> 0 Then
                    'El Ticket de no debe ser nulo
                    If Len(txTicketMER.Text) < 6 Then
                        'El Ticket debe ser de 6 dígitos
                        MsgBox("El Ticket debe ser de 6 dígitos.", vbInformation, "Error en el Formato")
                        txTicketMER.Focus()
                        Exit Function
                    End If
                End If
                If Trim(txTicket.Text) = "" Then
                    MsgBox("Es necesario indicar el número de ticket.", vbInformation, "Cuenta Faltante")
                    txTicket.Focus()
                    Exit Function
                End If
                If Val(txTicket.Text) <> 0 Then        'El Ticket de no debe ser nulo
                    If Len(txTicket.Text) < 6 Then      'El Ticket debe ser de 6 dígitos
                        MsgBox("El Ticket debe ser de 6 dígitos.", vbInformation, "Error en el Formato")
                        txTicket.Focus()
                        Exit Function
                    End If
                End If
                If Trim(txCuenta.Text) = "" Then
                    'Cta. no debe ser nula
                    MsgBox("Es necesario indicar el número de cuenta.", vbInformation, "Cuenta Faltante")
                    txCuenta.Focus()
                    Exit Function
                ElseIf Len(txCuenta.Text) < 6 Then
                    'Cta. debe ser de 6 digitos
                    MsgBox("El número de cuenta debe ser de 6 digitos.", vbInformation, "Error en Formato")
                    txCuenta.Focus()
                    Exit Function
                End If
                If Trim(dtpFechaOp.Text) = "" Then
                    'Fecha de Operación no debe ser nula
                    MsgBox("Es necesario indicar la fecha de operación.", vbInformation, "Fecha Faltante")
                    dtpFechaOp.Focus()
                    Exit Function
                End If
                If mnDivisa = 0 Then
                    'Se debe indicar el tipo de divisa
                    'Documento de Deposito
                    If dllDepDivisas.SelectedIndex = -1 Then
                        MsgBox("Es necesario indicar el tipo de divisa.", vbInformation, "Dato Faltante")
                        'optOD = True
                        dllDepDivisas.Focus()
                        Exit Function
                    End If
                End If
                If Trim(txReferencia.Text) = "" Then         'La referencia no debe ser nula
                    MsgBox("Es necesario indicar el número de folio.", vbInformation, "Dato Faltante")
                    txReferencia.Focus()
                    Exit Function
                End If
                If Val(txMonto.Text) <= 0 Then               'El valor del Monto no debe ser nulo
                    MsgBox("Es necesario indicar un monto positivo.", vbInformation, "Monto Faltante")
                    txMonto.Focus()
                    Exit Function
                End If

                If Trim(dllDepCte.Text) = "" Then
                    MsgBox("Es necesario indicar el Nombre del Cliente.", vbInformation, "Dato Faltante")
                    dllDepCte.Focus()
                    Exit Function
                End If
                If Trim(dllDepPersona.Text) = "" Then
                    MsgBox("Es necesario indicar el Nombre de la Persona que operó el documento.", vbInformation, "Dato Faltante")
                    dllDepPersona.Focus()
                    Exit Function
                End If
                If Trim(txDepSucursal.Text) = "" Then            'El valor de la Sucursal no debe ser nulo
                    MsgBox("Es necesario indicar la Sucursal de la cuenta.", vbInformation, "Dato Faltante")
                    txDepSucursal.Focus()
                    Exit Function
                End If
                If Trim(txDepPlaza.Text) = "" Then               'El valor de la Plaza no debe ser nulo
                    MsgBox("Es necesario indicar la Plaza de la cuenta.", vbInformation, "Dato Faltante")
                    txDepPlaza.Focus()
                    Exit Function
                End If
                If dllDepTipoInstrumento.SelectedIndex = -1 Then
                    MsgBox("Es necesario indicar el tipo de instrumento del documento.", vbInformation, "Dato Faltante")
                    dllDepTipoInstrumento.Focus()
                    Exit Function
                End If
                'If Trim(txSoportes.Text) = "" Then
                '    MsgBox("Es necesario indicar el número de soportes.", vbInformation, "Dato Faltante")
                '    txSoportes.Focus()
                '    Exit Function
                'End If
                'Validación de fecha de recepcion
                If Not (CDate(dtpFechaRecepcion.Text) >= CDate(dtpFechaOp.Text)) Then
                    MsgBox("La fecha de recepción debe ser mayor a la fecha de operación.", vbInformation)
                    dtpFechaRecepcion.Focus()
                    Exit Function
                Else
                    RevisaDatosDocto = True
                End If
            Case 1
                'Revisa Datos para Retiro
                If (Val(txTicketMER2.Text) <> 0 And Trim(txTicket2.Text) = "") Then

                    'Busca el ticket correspondiente en Agencias
                    dtDatosTicket = d.RevisaDatosTicket(NumTab, txTicketMER2.Text, txReferencia2.Text, txCuentaMER2.Text)


                    If dtDatosTicket.Rows().Count > 0 Then
                        'Se encuentra el Ticket
                        txTicket.Text = Val(dtDatosTicket.Rows(0).Item(0))
                    Else
                        'No se encuentra el Ticket
                        txTicket2.Text = 0
                        'No existe Ticket de Agencias
                        MsgBox("No se encuentra el Ticket de Agencias correspondiente al de Mercury.", vbInformation, "Ticket Inválido")
                        If txTicket2.Enabled = True Then
                            txTicket2.Focus()  'solo si se encuentra habilitado en campo
                        End If
                        Exit Function
                    End If
                End If
                If Trim(txCuentaMER2.Text) <> "" Then
                    'Cta. no debe ser nula
                    If Len(txCuentaMER2.Text) < 6 Then
                        'Cta. debe ser de 6 dígitos
                        MsgBox("El número de Cuenta debe ser de 6 dígitos.", vbInformation, "Error en el Formato")
                        txCuentaMER2.Focus()
                        Exit Function
                    End If
                End If
                If Val(txTicketMER2.Text) <> 0 Then
                    'El Ticket de no debe ser nulo
                    If Len(txTicketMER2.Text) < 6 Then
                        'El Ticket debe ser de 6 dígitos
                        MsgBox("El Ticket debe ser de 6 dígitos.", vbInformation, "Error en el Formato")
                        txTicketMER2.Focus()
                        Exit Function
                    End If
                End If

                If Trim(txTicket2.Text) = "" Then
                    MsgBox("Es necesario indicar el número de ticket.", vbInformation, "Cuenta Faltante")
                    txTicket2.Focus()
                    Exit Function
                End If
                If Val(txTicket2.Text) <> 0 Then
                    'El Ticket de no debe ser nulo
                    If Len(txTicket2.Text) < 6 Then
                        'El Ticket debe ser de 6 dígitos
                        MsgBox("El Ticket debe ser de 6 dígitos.", vbInformation, "Error en el Formato")
                        txTicket2.Focus()
                        Exit Function
                    End If
                End If
                If Trim(txCuenta2.Text) = "" Then             'Cta. no debe ser nula
                    MsgBox("Es necesario indicar el número de cuenta.", vbInformation, "Cuenta Faltante")
                    txCuenta2.Focus()
                    Exit Function
                ElseIf Len(txCuenta2.Text) < 6 Then           'Cta. debe ser de 6 digitos
                    MsgBox("El número de cuenta debe ser de 6 digitos.", vbInformation, "Error en Formato")
                    txCuenta2.Focus()
                    Exit Function
                End If
                If Trim(dtpFechaOp2.Text) = "" Then            'Fecha de Operación no debe ser nula
                    MsgBox("Es necesario indicar la fecha de operación.", vbInformation, "Fecha Faltante")
                    dtpFechaOp2.Focus()
                    Exit Function
                End If
                If mnDivisa = 0 Then                                  'Se debe indicar el tipo de divisa
                    'Documento de Retiro
                    'Se debe indicar el tipo de divisa
                    If dllRetDivisas.SelectedIndex = -1 Then
                        MsgBox("Es necesario indicar el tipo de divisa.", vbInformation, "Dato Faltante")
                        'optRetOD.Value = True
                        dllRetDivisas.Focus()
                        Exit Function
                    End If
                End If
                If Trim(txReferencia2.Text) = "" Then         'La referencia no debe ser nula
                    MsgBox("Es necesario indicar el número de folio.", vbInformation, "Dato Faltante")
                    txReferencia2.Focus()
                    Exit Function
                End If
                If Val(txMonto2.Text) <= 0 Then               'El valor del Monto no debe ser nulo
                    MsgBox("Es necesario indicar un monto positivo.", vbInformation, "Monto Faltante")
                    txMonto2.Focus()
                    Exit Function
                End If

                If Trim(dllRetCte.Text) = "" Then
                    MsgBox("Es necesario indicar el Nombre del Cliente.", vbInformation, "Dato Faltante")
                    dllRetCte.Focus()
                    Exit Function
                End If
                If Trim(dllRetPersona.Text) = "" Then
                    MsgBox("Es necesario indicar el Nombre de la Persona que operó el documento.", vbInformation, "Dato Faltante")
                    dllRetPersona.Focus()
                    Exit Function
                End If
                If Trim(txRetSucursal.Text) = "" Then
                    MsgBox("Es necesario indicar la Sucursal de la cuenta.", vbInformation, "Dato Faltante")
                    txRetSucursal.Focus()
                    Exit Function
                End If
                If Trim(txRetPlaza.Text) = "" Then
                    MsgBox("Es necesario indicar la plaza de la cuenta.", vbInformation, "Dato Faltante")
                    txRetPlaza.Focus()
                    Exit Function
                End If
                If dllRetTipoInstrumento.SelectedIndex = -1 Then
                    MsgBox("Es necesario indicar el tipo de instrumento del documento.", vbInformation, "Dato Faltante")
                    dllRetTipoInstrumento.Focus()
                    Exit Function
                End If
                If cbCheque.Checked = True And Trim(txRetNumCheque.Text) = "" Then
                    MsgBox("Es necesario indicar el número de cheque.", vbInformation, "Dato Faltante")
                    txRetNumCheque.Focus()
                    Exit Function
                End If

                'If Trim(txSoportes2.Text) = "" Then
                '    MsgBox("Es necesario indicar el número de soportes.", vbInformation, "Dato Faltante")
                '    txSoportes2.Focus()
                '    Exit Function
                'End If
                'Validación de fecha de recepcion
                If Not (CDate(dtpFechaRecepcion2.Text) >= CDate(dtpFechaOp2.Text)) Then
                    MsgBox("La fecha de recepción debe ser mayor a la fecha de operación.", vbInformation)
                    dtpFechaRecepcion.Focus()
                    Exit Function
                Else
                    RevisaDatosDocto = True
                End If
        End Select
    End Function
    Private Sub btAgregarSoporte_Click(sender As Object, e As EventArgs) Handles btAgregarSoporte.Click
        btAgregarSoporte.Enabled = False
        mnNewNode = 1
        LimpiaCampos()
        AgregarRegistro()
    End Sub
    Private Sub btAgregar_Click(sender As Object, e As EventArgs) Handles btAgregar.Click

        If dllTipoFuente.SelectedIndex <> -1 Then
            LimpiaCampos()
            AgregarRegistro()
        Else
            MsgBox("No ha seleccionao un Tipo de Fuente ", vbInformation)
        End If
    End Sub
    Sub AgregarRegistro()

        btElimina.Enabled = False
        btImprimir.Enabled = False
        btCancelar.Enabled = True
        dtpFechaCaptura.Enabled = True

        pbBuscar.Enabled = True
        txTicket0.Enabled = True
        If gvOperaciones.Rows.Count <> 0 Then
            If dtpFechaCaptura.Text <> Date.Now.ToString("dd/MM/yyyy") Then
                msNumID = ""
            Else
                If txNumDoc.Text = "" Then
                    msNumID = Convert.ToString(gvOperaciones.CurrentRow.Cells("documento").Value)
                Else
                    msNumID = txNumDoc.Text
                End If
            End If
        End If

        If msNumID = "" Then
            'Si se esta agregando un documento
            grbSoporte.Visible = False
            txNumDoc.Text = ""
            'Limpia grid en caso de quE exita una consulta con fecha diferente al dia de hoy
            If dtpFechaCaptura.Text <> Date.Now.ToString("dd/MM/yyyy") Then
                dtpFechaCaptura.Text = Date.Now
                gvOperaciones.DataSource = Nothing
                gvOperaciones.AllowUserToAddRows = True
                txDocIni.Text = ""
            Else
                gvOperaciones.AllowUserToAddRows = True
            End If
            bNuevoDocto = True
        Else
            If mnNewNode = 1 Then
                'Si se esta agregando un nuevo soporte
                grbSoporte.Text = "SOPORTE No " & iSoporte
                iSoporte = iSoporte + 1
                cbSopVal.Checked = 1
                tabOperaciones.Enabled = False
                dllTipoSoporte.SelectedIndex = -1
                dllDivisas.SelectedValue = 2
                If mnTipoOp = 0 Then
                    dtpFechaSoporte.Text = dtpFechaOp.Value
                Else
                    dtpFechaSoporte.Text = dtpFechaOp2.Value
                End If
                grbSoporte.Visible = True
                grbSoporte.Enabled = True
                btGuarda.Enabled = True
                btCancelar.Enabled = True
                gvOperaciones.AllowUserToAddRows = True
                txTicket0.Enabled = False
                pbBuscar.Enabled = False
                LimpiaCampos()
                If iNoSoportes = 0 Then
                    LimpiaCampos()
                    msNumID = ""
                    bNuevoDocto = False
                End If
            Else
                gvOperaciones.AllowUserToAddRows = True
                iSoporte = 1
                bNuevoDocto = True
            End If
        End If

        btAgregar.Enabled = False
        grbDatosDoc.Enabled = False
        txTicket0.Focus()
        mnNewNode = 1
    End Sub



    Private Sub dtpFechaCaptura_CloseUp(sender As Object, e As EventArgs) Handles dtpFechaCaptura.CloseUp

        If msLastDate <> dtpFechaCaptura.Value.ToString("dd/MM/yyyy") Then
            msLastDate = dtpFechaCaptura.Value.ToString("dd/MM/yyyy")
            LimpiaCampos()
            cbDocto.Checked = 0
            LlenaDataGrid()
        Else
            btAgregar.Enabled = True
        End If
    End Sub

    Private Sub cbTraspasos_Click_1(sender As Object, e As EventArgs) Handles cbTraspasos.Click
        If cbTraspasos.Checked = True Then
            pbBuscar.Enabled = False
            btCancelar.Enabled = False
            gvOperaciones.DataSource = Nothing
            btTraspasos.Enabled = True
            dllTipoFuente.SelectedIndex = -1
            mnNewNode = 0
            gvOperaciones.AllowUserToAddRows = False
            tabOperaciones.Enabled = False
            btAgregar.Enabled = False
            LimpiaCampos()
        Else
            dllTipoFuente.SelectedIndex = -1
            grbDatosDoc.Enabled = True
            btTraspasos.Enabled = False
            dllTipoFuente.Enabled = True
            dllTipoFuente.Focus()
            LimpiaCampos()
        End If
    End Sub

    Private Sub btTraspasos_Click(sender As Object, e As EventArgs) Handles btTraspasos.Click
        Dim frmCapturaTraspaso As New frmCapturaTraspaso
        frmCapturaTraspaso.usuariogos = usuario_gos
        frmCapturaTraspaso.ShowDialog()
    End Sub
    Private Sub gvOperaciones_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles gvOperaciones.CellMouseClick
        Dim sSoporte As String
        Dim sDocto As String
        Try
            iTotSoportes = 0
            LimpiaCampos()
            If gvOperaciones.DisplayedRowCount(True) > 1 Then
                If Not String.IsNullOrEmpty(gvOperaciones.CurrentRow.Cells("documento").Value.ToString()) Then
                    If mnNewNode <> 0 Then
                        'Esta pendiente un nuevo documento
                        CancelaNuevoReg()
                        Exit Sub
                    End If
                    'Obtiene el valor del soporte, para verificar si se esta seleccionando uno
                    sSoporte = Convert.ToString(gvOperaciones.CurrentRow.Cells(3).Value)
                    If sSoporte = "" Then
                        'Pinta de color azul la fila para indicar al usuario el nuevo documento  
                        SelectFilaDocto(gvOperaciones.CurrentRow.Cells("documento").Value)
                        lbNumSoportes.Visible = True
                        LlenaDatosDocumento(gvOperaciones.CurrentRow.Cells("documento").Value)
                        btElimina.Enabled = False
                        grbSoporte.Visible = False
                        sDocto = ""
                        For i As Integer = gvOperaciones.CurrentRow.Index To gvOperaciones.Rows.Count - 1
                            If (sDocto = "") Or (sDocto = Convert.ToString(gvOperaciones.Rows(i).Cells("documento").Value)) Then
                                sDocto = Convert.ToString(gvOperaciones.Rows(i).Cells("documento").Value)
                                If Convert.ToString(gvOperaciones.Rows(i).Cells(3).Value) <> "" Then
                                    iTotSoportes = iTotSoportes + 1
                                End If
                            Else
                                Exit For
                            End If
                        Next

                        If iTotSoportes <> 0 Then
                            lbNumSoportes.Text = "Documento con " & iTotSoportes & " Soportes..."
                            iTotSoportes = 0
                            btAgregarSoporte.Enabled = True
                        Else
                            lbNumSoportes.Text = "Documento Sin Soportes..."
                            btElimina.Visible = True
                            btElimina.Text = "Elimina Docto"
                            btElimina.Enabled = True
                            btAgregarSoporte.Enabled = True
                        End If
                    Else
                        'Se selecciona un soporte
                        lbNumSoportes.Visible = False
                        LlenaDatosDocumento(gvOperaciones.CurrentRow.Cells("documento").Value)
                        LlenaDatosSoporte(gvOperaciones.CurrentRow.Cells(3).Value)
                        'Pinta de color azul la fila para indicar al usuario el nuevo documento  
                        SelectFilaDocto(gvOperaciones.CurrentRow.Cells(3).Value)

                        grbSoporte.Enabled = False
                        btElimina.Visible = True
                        btElimina.Text = "Elimina Soporte"
                        btElimina.Enabled = True

                    End If
                Else
                    If mnNewNode <> 0 Then
                        'Esta pendiente un nuevo documento
                        CancelaNuevoReg()
                        Exit Sub
                    End If
                    btAgregar.Text = "Agrega &Docto."
                    btAgregar.Enabled = True
                End If
            Else
                If mnNewNode <> 0 Then
                    'Esta pendiente un nuevo documento
                    CancelaNuevoReg()
                    Exit Sub
                End If
                btAgregar.Text = "Agrega &Docto."
                btAgregar.Enabled = True
            End If

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento gvOperaciones_CellMouseClick, Error:" & ex.Message, vbInformation, "Seleccionar una operacion")
            Exit Sub
        End Try

    End Sub
    Sub CancelaNuevoReg()
        Dim lsTipoNodo As String
        If mnNewNode <> 0 Then
            If iNoSoportes = 0 Then
                lsTipoNodo = "Nuevo Documento?"
            Else
                lsTipoNodo = "Nuevo Soporte?"
            End If
            If MsgBox("¿Desea cancelar la captura del " & lsTipoNodo,
                      vbQuestion + vbYesNo + vbDefaultButton2, "Cancelación") = vbNo Then
                Exit Sub
            Else
                btAgregarSoporte.Enabled = False
                btAgregar.Enabled = True
                dtpFechaCaptura.Enabled = False
                gvOperaciones.AllowUserToAddRows = False
                tabOperaciones.Enabled = False
                grbDatosDoc.Enabled = True
                mnNewNode = 0
                iSoporte = 1
                iNoSoportes = 0
                btCancelar.Enabled = False
                msNumID = ""
                bNuevoDocto = False
                LimpiaCampos()
            End If
        End If
    End Sub

    '---------------------------------------------------------------
    'Llena el area de datos de documento para del documento indicado
    '---------------------------------------------------------------
    Private Sub LlenaDatosDocumento(ByVal Documento As Integer)

        Dim d = New Datasource
        Dim dtDatoDocto As DataTable
        Dim dtDatosTpDocto As DataTable
        Dim dtDatosDocumento As DataTable
        Dim dtDatosDeposito As DataTable
        Dim dtDatosRetiro As DataTable
        Dim dtDatostpInst As DataTable
        Dim dtDatostpOp As DataTable
        Dim dtDatosTpDivisa As DataTable
        Dim dtDatosFuente As DataTable
        Dim lsNumDoc As String
        Dim lnIndice As Byte
        Dim lsLineaS As String
        Dim sNoSucrusal As String
        Dim bFirma As Byte

        sNoSucrusal = ""
        'Llena Campos
        LimpiaCampos()
        btGuarda.Enabled = False
        btImprimir.Enabled = False
        grbSoporte.Enabled = False

        If lnIndice = 0 Then
            grbDepMercury.Visible = True
            grbDepMercury.Enabled = True
        Else
            grbRetMercury.Visible = True
            grbRetMercury.Enabled = True
        End If

        lsNumDoc = Documento
        txNumDoc.Text = lsNumDoc
        'Busca el tipo de documento
        dtDatoDocto = d.BuscaTpDocto(lsNumDoc)
        If dtDatoDocto.Rows().Count = 0 Then
            'No se encuentra el tipo de documento
            MsgBox("No es posible consultar los datos del documento.", vbCritical, "SLQ Server Error")
            Exit Sub
        Else
            'Se encontro el tipo de documento
            dllTipoDocto.Enabled = True

            dtDatosDocumento = d.BuscaDatosDocto(lsNumDoc)
            If dtDatosDocumento.Rows().Count() > 0 Then
                'Prende bandera de busqueda
                mbSearching = True

                'dtDatosFuente = d.DatosFuente(mn_TipoFuente, sNoSucrusal)
                mn_Fuente = dtDatosDocumento.Rows(0).Item(16)

                'Selecciona en el combo el tipo de documento correspondiente
                dtDatosTpDocto = d.LlenaTipoDocto(mn_Fuente, dtDatoDocto.Rows(0).Item(0), mnTipoOp)
                'Llena Combo dll Tipo Documento
                If dtDatosTpDocto Is Nothing Or dtDatosTpDocto.Rows.Count = 0 Then
                    'Si ocurrio algun error con el tipo de documento
                    MsgBox("No es posible identificar el tipo de documento.", vbCritical, "SQL Server Error")
                    Exit Sub
                Else
                    dllTipoDocto.DataSource = dtDatosTpDocto
                    dllTipoDocto.DisplayMember = "descripcion_documento"
                    dllTipoDocto.ValueMember = "tipo_documento"
                    btGuarda.Enabled = False
                    dllTipoDocto.Enabled = False

                    'Revisa el tipo de operacion del Tipo de Documento Seleccionado
                    dtDatostpOp = d.DatostpOperacion(dllTipoDocto.SelectedValue)
                    mnTipoOp = dtDatostpOp.Rows(0).Item(0)
                    tabOperaciones.SelectedIndex = mnTipoOp
                End If


                If mnTipoOp = 0 Then
                    tbRetiros.Parent = Nothing ' Ocultar Tabpage
                    tbDepositos.Parent = tabOperaciones ' Mostrar Tabpage
                    txCuenta.Text = Trim(dtDatosDocumento.Rows(0).Item(0))
                    txSufijo.Text = Trim(dtDatosDocumento.Rows(0).Item(1))
                    dtpFechaRecepcion.Text = dtDatosDocumento.Rows(0).Item(3)
                    dtpFechaOp.Text = dtDatosDocumento.Rows(0).Item(4)
                    txSoportes.Text = Trim(dtDatosDocumento.Rows(0).Item(5))
                    txMonto.Text = Format(dtDatosDocumento.Rows(0).Item(6), "###,###,###,##0.00")
                    txTicket.Text = Trim(dtDatosDocumento.Rows(0).Item(7))
                    msTicket = Trim(dtDatosDocumento.Rows(0).Item(7))
                Else
                    tbDepositos.Parent = Nothing ' Ocultar Tabpage
                    tbRetiros.Parent = tabOperaciones ' Mostrar Tabpage
                    txCuenta2.Text = Trim(dtDatosDocumento.Rows(0).Item(0))
                    txSufijo2.Text = Trim(dtDatosDocumento.Rows(0).Item(1))
                    dtpFechaRecepcion2.Text = dtDatosDocumento.Rows(0).Item(3)
                    dtpFechaOp2.Text = dtDatosDocumento.Rows(0).Item(4)
                    txSoportes2.Text = Trim(dtDatosDocumento.Rows(0).Item(5))
                    txMonto2.Text = Format(dtDatosDocumento.Rows(0).Item(6), "###,###,###,##0.00")
                    txTicket2.Text = Trim(dtDatosDocumento.Rows(0).Item(7))
                    msTicket = Trim(dtDatosDocumento.Rows(0).Item(7))
                End If


                If Val(dtDatosDocumento.Rows(0).Item(13)) <> 0 Or Val(dtDatosDocumento.Rows(0).Item(14)) <> 0 Or Val(dtDatosDocumento.Rows(0).Item(15)) <> 0 Then
                    If lnIndice = 0 Then
                        grbDepMercury.Visible = True
                        grbDepMercury.Enabled = True
                        If Val(dtDatosDocumento.Rows(0).Item(13)) <> 0 Then txCuentaMER.Text = Val(dtDatosDocumento.Rows(0).Item(13))
                        If Val(dtDatosDocumento.Rows(0).Item(14)) <> 0 Then txSufijoMER.Text = Val(dtDatosDocumento.Rows(0).Item(14))
                        If Val(dtDatosDocumento.Rows(0).Item(15)) <> 0 Then txTicketMER.Text = Val(dtDatosDocumento.Rows(0).Item(15))
                        If tabOperaciones.SelectedIndex < 2 Then txReferencia.Text = Trim(dtDatosDocumento.Rows(0).Item(8))

                    Else
                        grbRetMercury.Visible = True
                        grbRetMercury.Enabled = True
                        If Val(dtDatosDocumento.Rows(0).Item(13)) <> 0 Then txCuentaMER2.Text = Val(dtDatosDocumento.Rows(0).Item(13))
                        If Val(dtDatosDocumento.Rows(0).Item(14)) <> 0 Then txSufijoMER2.Text = Val(dtDatosDocumento.Rows(0).Item(14))
                        If Val(dtDatosDocumento.Rows(0).Item(15)) <> 0 Then txTicketMER2.Text = Val(dtDatosDocumento.Rows(0).Item(15))
                        If tabOperaciones.SelectedIndex < 2 Then txReferencia2.Text = Trim(dtDatosDocumento.Rows(0).Item(8))

                    End If
                End If

                'Apaga bandera de busqueda
                mbSearching = False

                msHoraCap = dtDatosDocumento.Rows(0).Item(9)

                bFirma = Val(dtDatosDocumento.Rows(0).Item(10))
                If bFirma = 0 Then
                    cbFirmaCliente.Checked = False
                Else
                    cbFirmaCliente.Checked = True
                End If
                If mnTipoOp = 0 Then
                        'El Documento es deposito
                        dllDepCte.Text = dtDatosDocumento.Rows(0).Item(11)
                        dllDepPersona.Text = Trim(dtDatosDocumento.Rows(0).Item(12))
                        'Busca datos de deposito
                        dtDatosDeposito = d.BuscaDatosDeposito(lsNumDoc)
                        If dtDatosDeposito.Rows.Count > 0 Then
                            Select Case Val(dtDatosDeposito.Rows(0).Item(0))
                                Case 1
                                    rbMN.Checked = True
                                Case 2
                                    rbUS.Checked = True
                                Case Else
                                    mbSearching = True
                                    'Prende bandera de busqueda
                                    rbOD.Checked = True
                                    dtDatosTpDivisa = d.LlenaTipoDivisa(dtDatosDeposito.Rows(0).Item(0))
                                    dllDepDivisas.Visible = True
                                    dllDepDivisas.DataSource = dtDatosTpDivisa
                                    dllDepDivisas.DisplayMember = "descripcion_divisa"
                                    dllDepDivisas.ValueMember = "divisa"
                                    'Apaga bandera de busqueda
                                    mbSearching = False
                            End Select
                            cbOriginal1.Checked = Val(dtDatosDeposito.Rows(0).Item(1))
                        txDepComision.Text = Format(dtDatosDeposito.Rows(0).Item(2), "###,###,###,##0.00")
                        If mn_Bbvab = 0 Then
                                dllDepPlaza.Text = Trim(dtDatosDeposito.Rows(0).Item(3))
                                txDepPlaza.Text = Trim(dtDatosDeposito.Rows(0).Item(5))
                                dllDepSucursal.Text = Trim(dtDatosDeposito.Rows(0).Item(4))
                                sNoSucrusal = Trim(dtDatosDeposito.Rows(0).Item(6))
                                txDepSucursal.Text = sNoSucrusal
                            Else
                                dllDepSucursal.Text = Trim(dtDatosDeposito.Rows(0).Item(4))
                                sNoSucrusal = Trim(dtDatosDeposito.Rows(0).Item(6))
                                txDepSucursal.Text = sNoSucrusal
                                txDepPlaza.Text = Trim(dtDatosDeposito.Rows(0).Item(5))
                                dllDepPlaza.Text = Trim(dtDatosDeposito.Rows(0).Item(3))
                            End If
                            lsLineaS = Trim(dtDatosDeposito.Rows(0).Item(7))
                            dtDatostpInst = d.DatosTipoInstrumento("", "", dtDatosDeposito.Rows(0).Item(8))
                            dllDepTipoInstrumento.Visible = True
                            dllDepTipoInstrumento.DataSource = dtDatostpInst
                            dllDepTipoInstrumento.DisplayMember = "descripcion_instrumento"
                            dllDepTipoInstrumento.ValueMember = "tipo_instrumento"
                            txDepFolioServicio.Text = lsLineaS
                        Else
                            'No se encontraron datos en deposito
                            MsgBox("No es posible consultar algunos datos del documento.", vbCritical, "SQL Server Error")
                        End If

                    ElseIf mnTipoOp <> 0 Then
                        'El documento es retiro
                        dllRetCte.Text = Trim(dtDatosDocumento.Rows(0).Item(11))
                        dllRetPersona.Text = Trim(dtDatosDocumento.Rows(0).Item(12))
                        'Busca datos en retiro
                        dtDatosRetiro = d.BuscaDatosRetiro(lsNumDoc)
                        If dtDatosRetiro.Rows.Count > 0 Then
                            If Trim(dtDatosRetiro.Rows(0).Item(0)) <> "" Then
                                cbCheque.Checked = True
                                txRetNumCheque.Text = Trim(dtDatosRetiro.Rows(0).Item(0))
                            Else
                                cbCheque.Checked = False
                                txRetNumCheque.Text = ""
                            End If
                            Select Case Val(dtDatosRetiro.Rows(0).Item(1))
                                Case 1
                                    rbRetMN.Checked = True
                                Case 2
                                    rbRetUS.Checked = True
                                Case Else
                                    mbSearching = True
                                    'Prende bandera de busqueda
                                    rbRetOD.Checked = True
                                    dtDatosTpDivisa = d.LlenaTipoDivisa(dtDatosRetiro.Rows(0).Item(1))
                                    dllRetDivisas.Visible = True
                                    dllRetDivisas.DataSource = dtDatosTpDivisa
                                    dllRetDivisas.DisplayMember = "descripcion_divisa"
                                    dllRetDivisas.ValueMember = "divisa"
                                    'Apaga bandera de busqueda
                                    mbSearching = False
                            End Select
                            'Llena el combo de instrumento por tipo de operación
                            dtDatostpInst = d.DatosTipoInstrumento("", "", dtDatosRetiro.Rows(0).Item(2))
                            dllRetTipoInstrumento.Visible = True
                            dllRetTipoInstrumento.DataSource = dtDatostpInst
                            dllRetTipoInstrumento.DisplayMember = "descripcion_instrumento"
                            dllRetTipoInstrumento.ValueMember = "tipo_instrumento"
                            dllRetTipoInstrumento.SelectedIndex = 0
                        Else
                            'No se encontraron datos en retiro
                            MsgBox("No es posible consultar algunos datos del documento.", vbCritical, "SQL Server Error")
                        End If

                        cbOriginal2.Checked = Val(dtDatosRetiro.Rows(0).Item(3))
                        If mn_Bbvab = 0 Then
                            dllRetPlaza.Text = Trim(dtDatosRetiro.Rows(0).Item(4))
                            txRetPlaza.Text = Trim(dtDatosRetiro.Rows(0).Item(6))
                            dllRetSucursal.Text = Trim(dtDatosRetiro.Rows(0).Item(5))
                            sNoSucrusal = Trim(dtDatosRetiro.Rows(0).Item(7))
                            txRetSucursal.Text = sNoSucrusal
                        Else
                            dllRetSucursal.Text = Trim(dtDatosRetiro.Rows(0).Item(5))
                            sNoSucrusal = Trim(dtDatosRetiro.Rows(0).Item(7))
                            txRetSucursal.Text = sNoSucrusal
                            txRetPlaza.Text = Trim(dtDatosRetiro.Rows(0).Item(6))
                            dllRetPlaza.Text = Trim(dtDatosRetiro.Rows(0).Item(4))
                        End If

                    End If

                Else
                    'No se encontraron datos del documento
                    MsgBox("No es posible consultar los datos del documento.", vbCritical, "SQL Server Error")
            End If

        End If
        btImprimir.Enabled = True

    End Sub

    Sub ColorColumnaCancelada()
        With gvOperaciones
            .CurrentCell.Style.BackColor = Color.LightCoral
            '.Item(0, gvOperaciones.CurrentRow.Index).Style.BackColor = Color.LightCoral
            '.Item(1, gvOperaciones.CurrentRow.Index).Style.BackColor = Color.LightCoral
            '.Item(2, gvOperaciones.CurrentRow.Index).Style.BackColor = Color.LightCoral
            '.Item(3, gvOperaciones.CurrentRow.Index).Style.BackColor = Color.LightCoral
        End With

    End Sub

    '----------------------------------------------------
    'Llena el area de datos de soporte
    '----------------------------------------------------
    Private Sub LlenaDatosSoporte(ByVal Soporte As Integer)
        Dim d As New Datasource
        Dim dtDatosSoporte As DataTable
        Dim lsSoporte As String
        Dim lnIndice As Byte
        Dim dtDatosTpDivisa As DataTable

        dllTipoDocto.Enabled = False
        tabOperaciones.Enabled = False
        lsSoporte = Soporte
        dtDatosSoporte = d.BuscaDatosSoporte(lsSoporte)

        If dtDatosSoporte.Rows().Count() > 0 Then
            txNumDocSoporte.Text = Trim(dtDatosSoporte.Rows(0).Item(0))
            txDetalle.Text = Trim(dtDatosSoporte.Rows(0).Item(1))
            dllTipoSoporte.Text = Trim(dtDatosSoporte.Rows(0).Item(2))
            'dllTipoSoporte.ValueMember = Val(dtDatosSoporte.Rows(0).Item(6))

            dtDatosTpDivisa = d.LlenaTipoDivisa(dtDatosSoporte.Rows(0).Item(3))
            dllDivisas.Visible = True
            dllDivisas.DataSource = dtDatosTpDivisa
            dllDivisas.DisplayMember = "descripcion_divisa"
            dllDivisas.ValueMember = "divisa"

            txImporteSoporte.Text = Format(dtDatosSoporte.Rows(0).Item(4), "###,###,###,##0.00")
            dtpFechaSoporte.Text = dtDatosSoporte.Rows(0).Item(5)
        Else
            MsgBox("No es posible consultar los datos del soporte.", vbCritical, "SQL Server Error")
        End If
        grbSoporte.Enabled = True
        grbSoporte.Visible = True

    End Sub

    Private Sub pbBuscarD_Click(sender As Object, e As EventArgs) Handles pbBuscar.Click
        BuscarDatos()
    End Sub

    Private Sub BuscarDatos()

        Dim d As New Datasource
        Dim dtDatosTicket As DataTable
        Dim dtDatosPlaza As DataTable
        Dim dtDatosTpDocto As DataTable
        Dim dtDatosFuente As DataTable
        Dim lsCliente As String
        Dim lsNoSucursal As String
        Dim lsSucursal As String
        Dim lsNoPlaza As String
        Dim lsPlaza As String
        Dim lsMonto As String
        Dim lsSufijo As String
        ' Dim strFechas() As Variant
        Dim sTicket As String
        Dim lsFecha As String

        sTicket = txTicket0.Text
        'Validamos que el ticket sea númerico
        If IsNumeric(sTicket) Then
            dtDatosTicket = d.BuscaDatosTicket(mnTipoOp, sTicket)
            If dtDatosTicket.Rows.Count > 0 Then
                lsNoSucursal = CStr(dtDatosTicket.Rows(0).Item(8).Substring(dtDatosTicket.Rows(0).Item(8).Length - 4))

                dtDatosFuente = d.DatosFuente(mn_TipoFuente, lsNoSucursal)
                mn_Fuente = dtDatosFuente.Rows(0).Item(0)

                dtDatosTpDocto = d.LlenaTipoDocto(mn_Fuente, "", mnTipoOp)
                'Llena Combo dll Tipo Documento
                dllTipoDocto.Visible = True
                dllTipoDocto.DataSource = dtDatosTpDocto
                dllTipoDocto.DisplayMember = "descripcion_documento"
                dllTipoDocto.ValueMember = "tipo_documento"

                If CStr(Val(dtDatosTicket.Rows(0).Item(9))) <> 250 Then
                    DatosTipoDocto()
                    'validar que el ticket no este cancelado
                    If mnTipoOp = 0 Then
                        txCuenta.Text = CStr(Val(dtDatosTicket.Rows(0).Item(0))).PadLeft(6, "0")
                    Else
                        txCuenta2.Text = CStr(Val(dtDatosTicket.Rows(0).Item(0))).PadLeft(6, "0")
                    End If
                    lsSufijo = CStr(dtDatosTicket.Rows(0).Item(1))
                    lsFecha = dtDatosTicket.Rows(0).Item(2)

                    'Fechas.Value = lsFecha
                    'lsFecha = String(2 - Len(CStr(Fechas.Day)), "0") & Fechas.Day & "-" & String(2 - Len(CStr(Fechas.Month)), "0") & Fechas.Month & "-" & Fechas.Year
                    lsMonto = Format(dtDatosTicket.Rows(0).Item(3), "##.00")
                    lsCliente = CStr(dtDatosTicket.Rows(0).Item(4).ToString()) & " " &
                                CStr(dtDatosTicket.Rows(0).Item(5).ToString()) & " " &
                                CStr(dtDatosTicket.Rows(0).Item(6).ToString())
                    lsSucursal = CStr(dtDatosTicket.Rows(0).Item(7))
                    dtDatosPlaza = d.ListaPlaza(lsNoSucursal, 1, "")
                    If dtDatosPlaza.Rows.Count = 0 Then
                        lsNoPlaza = ""
                        lsPlaza = ""
                    Else
                        lsNoPlaza = CStr(dtDatosPlaza.Rows(0).Item(0))
                        lsPlaza = CStr(dtDatosPlaza.Rows(0).Item(1))
                    End If

                    'Se llenan el combo antes de depositar los datos para que se tomen los
                    'valores necesarios para guardarlos.
                    LlenaCombosCte()

                    If mnTipoOp = 0 Then
                        'DEPOSITO
                        txTicket.Text = sTicket
                        dllDepCte.Text = lsCliente
                        dllDepPersona.Text = lsCliente
                        dllDepSucursal.Text = lsSucursal
                        txDepSucursal.Text = lsNoSucursal
                        txDepPlaza.Text = lsNoPlaza
                        dllDepPlaza.Text = lsPlaza
                        txDepComision.Text = lsMonto
                        dtpFechaOp.Text = CStr(lsFecha)
                        txMonto.Text = lsMonto
                        txSufijo.Text = lsSufijo
                        txReferencia.Focus()
                    Else
                        'RETIRO
                        txTicket2.Text = sTicket
                        dllRetCte.Text = lsCliente
                        dllRetPersona.Text = lsCliente
                        dllRetSucursal.Text = lsSucursal
                        txRetSucursal.Text = lsNoSucursal
                        txRetPlaza.Text = lsNoPlaza
                        dllRetPlaza.Text = lsPlaza
                        dtpFechaOp2.Text = CStr(lsFecha)
                        txMonto2.Text = lsMonto
                        txSufijo2.Text = lsSufijo
                        txReferencia2.Focus()

                    End If
                Else
                    MsgBox("No es posible capturar un documento con este No. de Ticket." & vbCrLf & "No. de Ticket cancelado", vbCritical + vbInformation, "Busqueda de datos")
                    LimpiaCampos()
                    txTicket0.Text = ""
                    dllTipoDocto.Text = ""
                    If mnTipoOp = 0 Then
                        txTicket.Text = ""
                        txTicket.Focus()
                        dtpFechaRecepcion.Text = DateTime.Now
                        dllDepCte.SelectedIndex = -1
                        dllDepPersona.SelectedIndex = -1
                    Else
                        txTicket2.Text = ""
                        txTicket2.Focus()
                        dtpFechaRecepcion2.Text = DateTime.Now
                        dllRetPersona.SelectedIndex = -1
                        dllRetCte.SelectedIndex = -1
                    End If
                End If
            Else
                MsgBox("No se encontró información para el Ticket", vbCritical + vbInformation, "Busqueda de datos") 'MsgBox("Ocurrio un error al hacer la consulta a la base de datos", vbCritical + vbInformation, "Busqueda de datos")
                LimpiaCampos()
                If mnTipoOp = 0 Then
                    txTicket.Text = ""
                    txTicket.Focus()
                    dtpFechaRecepcion.Text = DateTime.Now
                    dllDepCte.SelectedIndex = -1
                    dllDepPersona.SelectedIndex = -1
                Else
                    txTicket2.Text = ""
                    txTicket2.Focus()
                    dtpFechaRecepcion2.Text = DateTime.Now
                    dllRetPersona.SelectedIndex = -1
                    dllRetCte.SelectedIndex = -1
                End If
            End If
        Else
            MsgBox("Es necesario digitar el No. de ticket. ", vbInformation + vbCritical, "Busqueda de datos")
            If mnTipoOp = 0 Then
                txTicket.Focus()
            Else
                txTicket2.Focus()
            End If
        End If
    End Sub

    Private Sub LlenaCombosCte()

        Dim d As New Datasource
        Dim dtListaClientes As DataTable
        Dim sCuenta As String
        Dim sCuentaMercury As String
        Dim Index As Integer

        If mnTipoOp = 0 Then
            'Es documento de Deposito
            dllDepCte.DataSource = Nothing
            dllDepCte.DisplayMember = Nothing
            dllDepCte.ValueMember = Nothing
            dllDepPersona.DataSource = Nothing
            dllDepPersona.DisplayMember = Nothing
            dllDepPersona.ValueMember = Nothing
        Else
            'Es documento de Retiro
            dllRetCte.DataSource = Nothing
            dllRetCte.DisplayMember = Nothing
            dllRetCte.ValueMember = Nothing
            dllRetPersona.DataSource = Nothing
            dllRetPersona.DisplayMember = Nothing
            dllRetPersona.ValueMember = Nothing
        End If
        If mbSearching = True Then Exit Sub   'Se estan buscando datos de un documento existente
        If mnTipoOp = 0 Then
            'Es documento de Deposito
            Index = 0
            sCuenta = Trim(txCuenta.Text)
            If dllDepCte.SelectedIndex > 0 Then
                'El combo tiene datos
                If dllDepCte.SelectedText = Val(sCuenta) + mnAgencia Then
                    'Son los datos de la cuenta actual
                    Exit Sub
                Else
                    'No son datos de la cuenta actual
                    dllDepCte.DataSource = Nothing
                    dllDepCte.DisplayMember = Nothing
                    dllDepCte.ValueMember = Nothing
                    dllDepPersona.DataSource = Nothing
                    dllDepPersona.DisplayMember = Nothing
                    dllDepPersona.ValueMember = Nothing
                End If
            End If
        Else
            'Es documento de Retiro
            Index = 1
            sCuenta = Trim(txCuenta2.Text)
            If dllRetCte.SelectedIndex > 0 Then
                'El combo tiene datos
                If dllRetCte.SelectedText = Val(sCuenta) + mnAgencia Then
                    'Son los datos de la cuenta actual
                    Exit Sub
                Else
                    'No son datos de la cuenta actual
                    dllRetCte.DataSource = Nothing
                    dllRetCte.DisplayMember = Nothing
                    dllRetCte.ValueMember = Nothing
                    dllRetPersona.DataSource = Nothing
                    dllRetPersona.DisplayMember = Nothing
                    dllRetPersona.ValueMember = Nothing
                End If
            End If
        End If

        'Si la cuenta es vacía,  termina
        If sCuenta = "" Then Exit Sub
        '---------------------- LISTA DE CLIENTES --------------------------
        dtListaClientes = d.ListaClientes(sCuenta)
        If dtListaClientes.Rows.Count <> 0 Then
            sCliente = Trim(dtListaClientes.Rows(0).Item(0).ToString())
            If mnTipoOp = 0 Then
                'Es documento de Deposito
                dllDepCte.Text = sCliente
                '---------------------- LISTA DE PERSONA OPERA --------------------------
                dllDepPersona.Text = sCliente
            Else
                'Es documento de Retiro
                dllRetCte.Text = sCliente
                '---------------------- LISTA DE PERSONA OPERA --------------------------
                dllRetPersona.Text = sCliente
            End If


            '  If Trim(txCuentaMER(Index).Text) <> "" Then    
            'Agencia - Cayman para la cta de Mercury'
            '      gs_Sql = " " & DEFAULT_SRVRMERCURY & "." & DBCATALOGOS & ".dbo.sp_a_obten_nombre_cli_cot "
            '      gs_Sql = gs_Sql & " '" & txtCuentaMER(Index).text & "'"
            '      dbExecQuery gs_Sql                    'Busca el titular y Autorizado de la Cuenta y Agencia
            '      dbGetRecord
            '      Do While dbError = 0
            '          If tabOperaciones.Tab = 0 Then      'Es documento de Deposito
            '              cmbDepPersona.AddItem dbGetValue(0)
            'Else                                'Es documento de Retiro
            '              cmbRetPersona.AddItem dbGetValue(0)
            'End If
            '          dbGetRecord
            '      Loop
            '      dbEndQuery
            '      ShowDefaultCursor
            '  End If
        End If
    End Sub
    '--------------------------------------------------------------
    'Elimina el Nodo Seleccionado: Documento o Soporte
    '--------------------------------------------------------------
    Private Sub btElimina_Click(sender As Object, e As EventArgs) Handles btElimina.Click

        Dim d As New Datasource
        Dim sDatosElimina As String
        Dim dtBuscaActa As DataTable
        Dim lsTipo As String
        Dim lsMantDoc As String
        Dim sSoporte As String
        lsTipo = ""
        lsMantDoc = ""
        sSoporte = Convert.ToString(gvOperaciones.CurrentRow.Cells(3).Value)
        msNumID = Convert.ToString(gvOperaciones.CurrentRow.Cells("documento").Value)
        If sSoporte = "" Then
            lsTipo = "DOCUMENTO"
        Else
            lsTipo = "SOPORTE"
        End If

        If MsgBox("¿Desea eliminar el " & lsTipo & "?", vbQuestion + vbYesNo, "Eliminar") = vbYes Then
            Select Case lsTipo
                Case "DOCUMENTO"
                    '----- Si se trata de un Documento -----
                    If Desconciliable() = False Then
                        'No se puede desconciliar el documento
                        If mbDocTieneActa = False Then
                            'Tiene Acta Activa Asociada
                            MsgBox("Ocurrio un error al intentar borrar el " & lsTipo.ToUpper & ".", vbCritical, "SQL Server Error")
                        End If
                        Exit Sub
                    Else
                        sDatosElimina = d.EliminaDocto(msNumID, "D")
                        If sDatosElimina = "NOK" Then
                            MsgBox("Ocurrio un error al intentar borrar el " & UCase(lsTipo) & ".", vbCritical, "SQL Server Error")
                        Else
                            btAgregarSoporte.Enabled = False
                            gvOperaciones.DataSource = d.LlenaGridDocto("", dtpFechaCaptura.Text)
                        End If
                    End If

                Case "SOPORTE"

                    dtBuscaActa = d.BuscaActa(msNumID, 0)
                    If dtBuscaActa.Rows.Count <> 0 Then
                        'El soporte pertenece a un documento con acta
                        If MsgBox("El soporte pertenece a un Documento con el Acta  " & dtBuscaActa.Rows(0).Item(1) & ". ¿Desea eliminar el soporte?", vbQuestion + vbYesNo, "Eliminar") = vbYes Then
                            sDatosElimina = d.EliminaDocto(msNumID, "S")
                            If sDatosElimina = "NOK" Then
                                MsgBox("Ocurrio un error al intentar borrar el " & UCase(lsTipo) & ".", vbCritical, "SQL Server Error")
                            End If
                        End If
                    Else
                        sDatosElimina = d.EliminaDocto(sSoporte, "S")
                        If sDatosElimina = "NOK" Then
                            MsgBox("Ocurrio un error al intentar borrar el " & UCase(lsTipo) & ".", vbCritical, "SQL Server Error")
                        Else
                            gvOperaciones.DataSource = d.LlenaGridDocto("", dtpFechaCaptura.Text)
                        End If

                    End If
            End Select
            LimpiaCampos()
        End If
    End Sub
    Private Function Desconciliable() As Boolean
        Try
            Dim d As New Datasource
            Dim dtBuscaActa As DataTable
            Dim lsActa As String
            Dim iIndex As Integer

            mbDocTieneActa = False
            Desconciliable = False
            dtBuscaActa = d.BuscaActa(msNumID, 0)
            If dtBuscaActa.Rows.Count <> 0 Then
                MsgBox("El documento tiene asociada el Acta No. " & Val(dtBuscaActa.Rows(0).Item(1)) & ",  para eliminarlo es necesario cancelar el Acta.", vbInformation, "Mensaje ")
                mbDocTieneActa = True
                Exit Function
            Else
                lsActa = ""
                'Busca todas las Actas Adm canceladas ligadas al Documento
                dtBuscaActa = d.BuscaActa(msNumID, 1)
                For iIndex = 0 To dtBuscaActa.Rows.Count - 1
                    If Trim(lsActa) <> "" Then
                        lsActa = lsActa & ", "
                    End If
                    lsActa = lsActa & dtBuscaActa.Rows(iIndex).Item(1)
                Next iIndex
                If lsActa <> "" Then
                    lsActa = "(" & lsActa & ")"
                    dtBuscaActa = d.DesconciliaDocto(lsActa, msNumID, msTicket)
                End If
            End If
            Desconciliable = True

            mbDocTieneActa = True
            Exit Function

        Catch ex As Exception
            MsgBox("Ocurrio un error al intentar eliminar el documento.", vbCritical, "Mensaje Error")
            Exit Function
        End Try
    End Function

    Private Sub gvOperaciones_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gvOperaciones.CellFormatting
        With gvOperaciones
            For i As Integer = 0 To .Rows.Count - 1
                If Convert.ToString(.Rows(i).Cells("soporte").Value) <> "" Then
                    .Rows(i).Cells(1).Style.ForeColor = Color.White
                    For X As Integer = 0 To 4
                        .Rows(i).Cells(X).Style.BackColor = Color.White
                    Next
                Else
                    For X As Integer = 0 To 4
                        .Rows(i).Cells(X).Style.BackColor = Color.LightGray
                    Next
                End If
            Next
        End With
    End Sub

    Private Sub dllRetSucursal_DropDown(sender As Object, e As EventArgs) Handles dllRetSucursal.DropDown
        Dim d As New Datasource
        Dim dtDatosSucursal As DataTable

        If (Trim(txRetPlaza.Text) <> "" And dllRetSucursal.Items.Count = 0 And mn_Bbvab = 0) _
                        Or (dllRetSucursal.Items.Count = 0 And mn_Bbvab = 1) Then
            txRetSucursal.Text = ""
            dtDatosSucursal = d.ListaSucursal(dllRetSucursal.Text, mn_Bbvab, txRetPlaza.Text, txRetSucursal.Text, 0)
            dllRetSucursal.DataSource = dtDatosSucursal
            dllRetSucursal.DisplayMember = "nombre_sucursal"
            dllRetSucursal.ValueMember = "sucursal"
        End If
    End Sub

    Private Sub dllRetSucursal_Leave(sender As Object, e As EventArgs) Handles dllRetSucursal.Leave
        Dim d As New Datasource
        Dim dtDatosSucursal As DataTable

        If (Trim(txRetPlaza.Text) <> "" And Trim(txRetSucursal.Text) = "" And mn_Bbvab = 0) _
             Or (Trim(txRetSucursal.Text) = "" And mn_Bbvab = 1) Then
            dtDatosSucursal = d.ListaSucursal(dllRetSucursal.Text, mn_Bbvab, txRetPlaza.Text, txRetSucursal.Text, 0)
            If dtDatosSucursal Is Nothing Then
                MsgBox("No se encontraton sucursales con el nombre indicado.", vbInformation, "Sucursal Invalida")
                dllRetSucursal.Focus()
                dllRetSucursal.Text = ""
                Exit Sub
            Else
                dllRetSucursal.DataSource = dtDatosSucursal
                dllRetSucursal.DisplayMember = "nombre_sucursal"
                dllRetSucursal.ValueMember = "sucursal"
            End If
        End If

        If Trim(txRetPlaza.Text) <> "" And Trim(txRetSucursal.Text) <> "" Then
            dtDatosSucursal = d.ListaSucursal("", mn_Bbvab, txRetPlaza.Text, txRetSucursal.Text, 1)
            If dtDatosSucursal.Rows.Count = 0 Then
                If UCase(Trim(dtDatosSucursal.Rows(0).Item(1))) <> UCase(dllRetSucursal.Text) Then
                    MsgBox("La Sucursal no esta asociada a la plaza seleccionada", vbInformation, "Sucursal Invalida")
                    txRetSucursal.Text = ""
                    dllRetSucursal.SelectedIndex = -1
                    txRetSucursal.Focus()
                    Exit Sub
                End If
            Else
                MsgBox("La Sucursal no esta asociada a la plaza seleccionada", vbInformation, "Sucursal Invalida")
                txRetSucursal.Text = ""
                dllRetSucursal.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub dllRetSucursal_DropDownClosed(sender As Object, e As EventArgs) Handles dllRetSucursal.DropDownClosed
        Dim d As New Datasource
        Dim dtDatosPlaza As DataTable
        If dllRetSucursal.SelectedIndex <> -1 And dllRetSucursal.Items.Count <> 0 Then
            txRetSucursal.Text = dllRetSucursal.SelectedValue.ToString.PadRight(4, "0")
            If mn_Bbvab = 1 Then
                dtDatosPlaza = d.ListaPlaza(txRetSucursal.Text, mn_Bbvab, "")
                If dtDatosPlaza Is Nothing Then
                    MsgBox("La Sucursal no esta asociada a ninguna plaza", vbInformation, "Sucursal Invalida")
                    txRetPlaza.Text = ""
                    dllRetPlaza.Text = ""
                    txRetSucursal.Text = ""
                    dllRetSucursal.Text = ""
                    dllRetSucursal.SelectedIndex = -1
                Else
                    txRetPlaza.Text = dtDatosPlaza.Rows(0).Item(0)
                    dllRetPlaza.Text = dtDatosPlaza.Rows(0).Item(1)
                End If
            End If
        End If
    End Sub

    Private Sub dllDepSucursal_DropDown(sender As Object, e As EventArgs) Handles dllDepSucursal.DropDown
        Dim d As New Datasource
        Dim dtDatosSucursal As DataTable

        If (Trim(txDepPlaza.Text) <> "" And dllDepSucursal.Items.Count = 0 And mn_Bbvab = 0) _
                        Or (dllDepSucursal.Items.Count = 0 And mn_Bbvab = 1) Then
            txDepSucursal.Text = ""
            dtDatosSucursal = d.ListaSucursal(dllDepSucursal.Text, mn_Bbvab, txDepPlaza.Text, txDepSucursal.Text, 0)
            dllDepSucursal.DataSource = dtDatosSucursal
            dllDepSucursal.DisplayMember = "nombre_sucursal"
            dllDepSucursal.ValueMember = "sucursal"

        End If
    End Sub

    Private Sub dllDepSucursal_DropDownClosed(sender As Object, e As EventArgs) Handles dllDepSucursal.DropDownClosed
        Dim d As New Datasource
        Dim dtDatosPlaza As DataTable
        If dllDepSucursal.SelectedIndex <> -1 And dllDepSucursal.Items.Count <> 0 Then
            txDepSucursal.Text = dllDepSucursal.SelectedValue.ToString.PadRight(4, "0")
            If mn_Bbvab = 1 Then
                dtDatosPlaza = d.ListaPlaza(txDepSucursal.Text, mn_Bbvab, "")
                If dtDatosPlaza Is Nothing Then
                    MsgBox("La Sucursal no esta asociada a ninguna plaza", vbInformation, "Sucursal Invalida")
                    txDepPlaza.Text = ""
                    dllDepPlaza.Text = ""
                    txDepSucursal.Text = ""
                    dllDepSucursal.Text = ""
                    dllDepSucursal.SelectedIndex = -1
                Else
                    txDepPlaza.Text = dtDatosPlaza.Rows(0).Item(0)
                    dllDepPlaza.Text = dtDatosPlaza.Rows(0).Item(1)
                End If
            End If
        End If
    End Sub

    Private Sub dllDepSucursal_Leave(sender As Object, e As EventArgs) Handles dllDepSucursal.Leave
        Dim d As New Datasource
        Dim dtDatosSucursal As DataTable

        If (Trim(txDepPlaza.Text) <> "" And Trim(txDepSucursal.Text) = "" And mn_Bbvab = 0) _
             Or (Trim(txDepSucursal.Text) = "" And mn_Bbvab = 1) Then
            dtDatosSucursal = d.ListaSucursal(dllDepSucursal.Text, mn_Bbvab, txDepPlaza.Text, txDepSucursal.Text, 0)
            If dtDatosSucursal Is Nothing Then
                MsgBox("No se encontraton sucursales con el nombre indicado.", vbInformation, "Sucursal Invalida")
                dllDepSucursal.Focus()
                dllDepSucursal.Text = ""
                Exit Sub
            Else
                dllDepSucursal.DataSource = dtDatosSucursal
                dllDepSucursal.DisplayMember = "nombre_sucursal"
                dllDepSucursal.ValueMember = "sucursal"
            End If
        End If

        If Trim(txDepPlaza.Text) <> "" And Trim(txDepSucursal.Text) <> "" Then
            dtDatosSucursal = d.ListaSucursal("", mn_Bbvab, txDepPlaza.Text, txDepSucursal.Text, 1)
            If dtDatosSucursal.Rows.Count = 0 Then
                If UCase(Trim(dtDatosSucursal.Rows(0).Item(1))) <> UCase(dllDepSucursal.Text) Then
                    MsgBox("La Sucursal no esta asociada a la plaza seleccionada", vbInformation, "Sucursal Invalida")
                    txDepSucursal.Text = ""
                    dllDepSucursal.SelectedIndex = -1
                    txDepSucursal.Focus()
                    Exit Sub
                End If
            Else
                MsgBox("La Sucursal no esta asociada a la plaza seleccionada", vbInformation, "Sucursal Invalida")
                txDepSucursal.Text = ""
                dllDepSucursal.SelectedIndex = -1
            End If
        End If
    End Sub
    Private Sub dllRetPlaza_DropDown(sender As Object, e As EventArgs) Handles dllRetPlaza.DropDown
        Dim d As New Datasource
        Dim dtDatosPlaza As DataTable
        If dllRetPlaza.Items.Count = 0 Then
            txRetPlaza.Text = ""
            dtDatosPlaza = d.ListaPlaza("", 0, dllRetPlaza.Text)
            dllRetPlaza.DataSource = dtDatosPlaza
            dllRetPlaza.DisplayMember = "nombre_plaza"
            dllRetPlaza.ValueMember = "plaza"
        End If
    End Sub
    Private Sub dllDepPlaza_DropDown(sender As Object, e As EventArgs) Handles dllDepPlaza.DropDown
        Dim d As New Datasource
        Dim dtDatosPlaza As DataTable
        If dllDepPlaza.Items.Count = 0 Then
            txDepPlaza.Text = ""
            dtDatosPlaza = d.ListaPlaza("", 0, dllDepPlaza.Text)
            dllDepPlaza.DataSource = dtDatosPlaza
            dllDepPlaza.DisplayMember = "nombre_plaza"
            dllDepPlaza.ValueMember = "plaza"
        End If
    End Sub
    Private Sub dllRetPlaza_DropDownClosed(sender As Object, e As EventArgs) Handles dllRetPlaza.DropDownClosed
        Dim D As New Datasource
        Dim dtDatosSucursal As DataTable

        If dllRetPlaza.SelectedIndex <> -1 And dllRetPlaza.Items.Count > 0 Then
            txRetPlaza.Text = dllRetPlaza.SelectedValue.ToString.PadRight(3, "0")
            dtDatosSucursal = D.ListaSucursal("", 0, txRetPlaza.Text, "", 3)
            If dtDatosSucursal.Rows(0).Item(0) = 0 Then
                MsgBox("La plaza seleccionada no tiene sucursales asociadas", vbInformation, "Plaza Invalida")
                txRetPlaza.Text = ""
                dllRetPlaza.Text = ""
                dllRetPlaza.SelectedIndex = -1
                txRetPlaza.Focus()
            End If
        End If
    End Sub
    Private Sub dllDepPlaza_DropDownClosed(sender As Object, e As EventArgs) Handles dllDepPlaza.DropDownClosed
        Dim D As New Datasource
        Dim dtDatosSucursal As DataTable

        If dllDepPlaza.SelectedIndex <> -1 And dllDepPlaza.Items.Count > 0 Then
            txDepPlaza.Text = dllDepPlaza.SelectedValue.ToString.PadRight(3, "0")
            dtDatosSucursal = D.ListaSucursal("", 0, txDepPlaza.Text, "", 3)
            If dtDatosSucursal.Rows(0).Item(0) = 0 Then
                MsgBox("La plaza seleccionada no tiene sucursales asociadas", vbInformation, "Plaza Invalida")
                txDepPlaza.Text = ""
                dllDepPlaza.Text = ""
                dllDepPlaza.SelectedIndex = -1
                txDepPlaza.Focus()
            End If
        End If
    End Sub
    Private Sub dllRetPlaza_Leave(sender As Object, e As EventArgs) Handles dllRetPlaza.Leave
        Dim d As New Datasource
        Dim dtDatosSucursal As DataTable
        Dim dtDatosPlaza As DataTable
        If mn_Bbvab = 0 Then
            If Trim(txRetPlaza.Text) = "" Then
                'Llena el combo de Plaza
                dtDatosPlaza = d.ListaPlaza("", 0, txRetPlaza.Text)
                If dtDatosPlaza Is Nothing Then
                    MsgBox("No existen plazas con el nombre indicado.", vbInformation, "Plaza Invalida")
                    dllRetPlaza.Focus()
                    Exit Sub
                Else
                    dllRetPlaza.DataSource = dtDatosPlaza
                    dllRetPlaza.DisplayMember = "nombre_plaza"
                    dllRetPlaza.ValueMember = "plaza"
                    dllRetPlaza.SelectedIndex = 0
                End If
            End If
            If Trim(txRetPlaza.Text) <> "" And Trim(txRetSucursal.Text) <> "" Then
                dtDatosSucursal = d.ListaSucursal("", mn_Bbvab, txRetPlaza.Text, txRetSucursal.Text, 1)
                If dtDatosSucursal.Rows.Count = 0 Then
                    If UCase(Trim(dtDatosSucursal.Rows(0).Item(1))) <> UCase(dllRetSucursal.Text) Then
                        MsgBox("La Sucursal no esta asociada a la plaza seleccionada", vbInformation, "Sucursal Invalida")
                        txRetSucursal.Text = ""
                        dllRetSucursal.Text = ""
                        dllRetSucursal.DataSource = Nothing
                        dllRetSucursal.DisplayMember = Nothing
                        dllRetSucursal.ValueMember = Nothing
                        txRetSucursal.Focus()
                        Exit Sub
                    End If
                Else
                    MsgBox("La Sucursal no esta asociada a la plaza seleccionada", vbInformation, "Sucursal Invalida")
                    txRetSucursal.Text = ""
                    dllRetSucursal.Text = ""
                    dllRetSucursal.DataSource = Nothing
                    dllRetSucursal.DisplayMember = Nothing
                    dllRetSucursal.ValueMember = Nothing
                End If
            End If
        End If
    End Sub
    Private Sub dllDepPlaza_Leave(sender As Object, e As EventArgs) Handles dllDepPlaza.Leave
        Dim d As New Datasource
        Dim dtDatosSucursal As DataTable
        Dim dtDatosPlaza As DataTable
        If mn_Bbvab = 0 Then
            If Trim(txDepPlaza.Text) = "" Then
                'Llena el combo de Plaza
                dtDatosPlaza = d.ListaPlaza("", 0, txDepPlaza.Text)
                If dtDatosPlaza Is Nothing Then
                    MsgBox("No existen plazas con el nombre indicado.", vbInformation, "Plaza Invalida")
                    dllDepPlaza.Focus()
                    Exit Sub
                Else
                    dllDepPlaza.DataSource = dtDatosPlaza
                    dllDepPlaza.DisplayMember = "nombre_plaza"
                    dllDepPlaza.ValueMember = "plaza"
                    dllDepPlaza.SelectedIndex = 0
                End If
            End If
            If Trim(txDepPlaza.Text) <> "" And Trim(txDepSucursal.Text) <> "" Then
                dtDatosSucursal = d.ListaSucursal("", mn_Bbvab, txDepPlaza.Text, txDepSucursal.Text, 1)
                If dtDatosSucursal.Rows.Count = 0 Then
                    If UCase(Trim(dtDatosSucursal.Rows(0).Item(1))) <> UCase(dllDepSucursal.Text) Then
                        MsgBox("La Sucursal no esta asociada a la plaza seleccionada", vbInformation, "Sucursal Invalida")
                        txDepSucursal.Text = ""
                        dllDepSucursal.Text = ""
                        dllDepSucursal.DataSource = Nothing
                        dllDepSucursal.DisplayMember = Nothing
                        dllDepSucursal.ValueMember = Nothing
                        txDepSucursal.Focus()
                        Exit Sub
                    End If
                Else
                    MsgBox("La Sucursal no esta asociada a la plaza seleccionada", vbInformation, "Sucursal Invalida")
                    txDepSucursal.Text = ""
                    dllDepSucursal.Text = ""
                    dllDepSucursal.DataSource = Nothing
                    dllDepSucursal.DisplayMember = Nothing
                    dllDepSucursal.ValueMember = Nothing
                End If
            End If
        End If
    End Sub

    Private Sub txCuenta_Leave(sender As Object, e As EventArgs) Handles txCuenta.Leave
        If txCuenta.Text <> "" Then
            If txCuenta.Enabled Then
                If Len(txCuenta.Text) < 6 Then
                    MsgBox("El número de Cuenta de la Agencia debe ser de 6 dígitos.", vbInformation, "Error en el Formato")
                    txCuenta.Focus()
                    Exit Sub
                End If
                grbDepMercury.Visible = False
                grbDepMercury.Enabled = False
                LlenaCombosCte()
            End If
        End If
    End Sub

    Private Sub txCuenta2_Leave(sender As Object, e As EventArgs) Handles txCuenta2.Leave
        If txCuenta2.Text <> "" Then
            If txCuenta2.Enabled Then
                If Len(txCuenta2.Text) < 6 Then
                    MsgBox("El número de Cuenta de la Agencia debe ser de 6 dígitos.", vbInformation, "Error en el Formato")
                    txCuenta2.Focus()
                    Exit Sub
                End If
                grbRetMercury.Visible = False
                grbRetMercury.Enabled = False
                LlenaCombosCte()
            End If
        End If
    End Sub

    Private Sub dllRetDivisas_DropDownClosed(sender As Object, e As EventArgs) Handles dllRetDivisas.DropDownClosed
        If dllRetDivisas.SelectedIndex = -1 Then
            mnDivisa = 0
        Else
            mnDivisa = dllRetDivisas.SelectedValue
        End If
    End Sub

    Private Sub dllDepDivisas_DropDownClosed(sender As Object, e As EventArgs) Handles dllDepDivisas.DropDownClosed
        If dllDepDivisas.SelectedIndex = -1 Then
            mnDivisa = 0
        Else
            mnDivisa = dllDepDivisas.SelectedValue
        End If
    End Sub

    Private Sub rbMN_CheckedChanged(sender As Object, e As EventArgs) Handles rbMN.CheckedChanged
        If rbMN.Checked = True Then
            mnDivisa = 1
            dllDepDivisas.SelectedIndex = -1
            dllDepDivisas.Enabled = False
        Else
            mnDivisa = 0
            dllDepDivisas.Enabled = True
        End If
    End Sub

    Private Sub rbRetMN_CheckedChanged(sender As Object, e As EventArgs) Handles rbRetMN.CheckedChanged
        If rbRetMN.Checked = True Then
            mnDivisa = 1
            dllRetDivisas.SelectedIndex = -1
            dllRetDivisas.Enabled = False
        Else
            mnDivisa = 0
            dllRetDivisas.Enabled = True
        End If
    End Sub

    Private Sub rbRetOD_CheckedChanged(sender As Object, e As EventArgs) Handles rbRetOD.CheckedChanged
        If rbRetOD.Checked = True Then
            mnDivisa = 0
            dllRetDivisas.Enabled = True
        Else
            dllRetDivisas.Enabled = False
        End If
    End Sub
    Private Sub rbDOD_CheckedChanged(sender As Object, e As EventArgs) Handles rbOD.CheckedChanged
        If rbOD.Checked = True Then
            mnDivisa = 0
            dllDepDivisas.Enabled = True
        Else
            dllDepDivisas.Enabled = False
        End If
    End Sub
    Private Sub rbRetUS_CheckedChanged(sender As Object, e As EventArgs) Handles rbRetUS.CheckedChanged
        If rbRetUS.Checked = True Then
            mnDivisa = 2
            dllRetDivisas.SelectedIndex = -1
            dllRetDivisas.Enabled = False
        Else
            mnDivisa = 0
            dllRetDivisas.Enabled = True
        End If
    End Sub

    Private Sub rbUS_CheckedChanged(sender As Object, e As EventArgs) Handles rbUS.CheckedChanged
        If rbUS.Checked = True Then
            mnDivisa = 2
            dllDepDivisas.SelectedIndex = -1
            dllDepDivisas.Enabled = False
        Else
            mnDivisa = 0
            dllDepDivisas.Enabled = True
        End If
    End Sub

    Private Sub dllDepTipoInstrumento_DropDownClosed(sender As Object, e As EventArgs) Handles dllDepTipoInstrumento.DropDownClosed
        Dim d As New Datasource
        Dim dtDatoNumSoportes As DataTable
        'Llena Num de soportes
        dtDatoNumSoportes = d.NumSoportes(mn_Fuente, dllTipoDocto.SelectedValue, dllDepTipoInstrumento.SelectedValue)
        'txSoportes.Text = dtDatoNumSoportes.Rows(0).Item(0)
    End Sub
    Private Sub dllRetTipoInstrumento_DropDownClosed(sender As Object, e As EventArgs) Handles dllRetTipoInstrumento.DropDownClosed
        Dim d As New Datasource
        Dim dtDatoNumSoportes As DataTable
        'Llena Num de soportes
        dtDatoNumSoportes = d.NumSoportes(mn_Fuente, dllTipoDocto.SelectedValue, dllRetTipoInstrumento.SelectedValue)
        'txSoportes2.Text = dtDatoNumSoportes.Rows(0).Item(0)
    End Sub

    Private Sub txImporteSoporte_Leave(sender As Object, e As EventArgs) Handles txImporteSoporte.Leave
        txImporteSoporte.Text = Format(Val(txImporteSoporte.Text), "###,###,###,##0.00")
    End Sub

    Private Sub txImporteSoporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txImporteSoporte.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) _
            And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub txRetNumCheque_Leave(sender As Object, e As EventArgs) Handles txRetNumCheque.Leave
        If txRetNumCheque.Text <> "" Then
            If Not IsNumeric(txRetNumCheque.Text) Then
                MsgBox("El número de Cheque debe ser numérico.", vbInformation, "Formato Incorrecto")
                txRetNumCheque.Text = ""
                txRetNumCheque.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cbCheque_Click(sender As Object, e As EventArgs) Handles cbCheque.Click
        If cbCheque.Checked = True Then
            txRetNumCheque.Enabled = True
            txRetNumCheque.Focus()
        Else
            txRetNumCheque.Text = ""
            txRetNumCheque.Enabled = False
            If btGuarda.Enabled Then btGuarda.Focus()
        End If
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click

        Try
            'arma el query que se pasara al reporte
            ls_PorImprimir = ""
            ls_PorImprimir &= "{DOCUMENTO.documento} = " & txNumDoc.Text

            'Selecciona el nombre del reporte segun el tipo de documento
            If mnTipoOp = 0 Then
                'Depositos
                opcionReporte = 14
            Else
                'Retiros
                opcionReporte = 15
            End If
            RepOperativa.ShowDialog()
        Catch ex As Exception
            MsgBox("Ha ocurrido un error: " & ex.Message)
            Exit Sub
        End Try


    End Sub


End Class