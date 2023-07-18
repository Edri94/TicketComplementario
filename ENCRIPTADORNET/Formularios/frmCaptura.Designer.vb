<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCaptura
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCaptura))
        Me.grbDatosDoc = New System.Windows.Forms.GroupBox()
        Me.dtpFechaCaptura = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txDocIni = New System.Windows.Forms.TextBox()
        Me.cbDocto = New System.Windows.Forms.CheckBox()
        Me.dllTipoFuente = New System.Windows.Forms.ComboBox()
        Me.gvOperaciones = New System.Windows.Forms.DataGridView()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ticket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.soporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion_soporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.documento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grbBotones2 = New System.Windows.Forms.GroupBox()
        Me.btCerrar = New System.Windows.Forms.Button()
        Me.btCancelar = New System.Windows.Forms.Button()
        Me.btGuarda = New System.Windows.Forms.Button()
        Me.btImprimir = New System.Windows.Forms.Button()
        Me.btElimina = New System.Windows.Forms.Button()
        Me.btAgregar = New System.Windows.Forms.Button()
        Me.grbSoporte = New System.Windows.Forms.GroupBox()
        Me.dllDivisas = New System.Windows.Forms.ComboBox()
        Me.txNumDocSoporte = New System.Windows.Forms.TextBox()
        Me.txDetalle = New System.Windows.Forms.TextBox()
        Me.txImporteSoporte = New System.Windows.Forms.TextBox()
        Me.dtpFechaSoporte = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Importe = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dllTipoSoporte = New System.Windows.Forms.ComboBox()
        Me.dllSoporte = New System.Windows.Forms.ComboBox()
        Me.cbSopVal = New System.Windows.Forms.CheckBox()
        Me.lbNumSoportes = New System.Windows.Forms.Label()
        Me.grbDatos = New System.Windows.Forms.GroupBox()
        Me.pbBuscar = New System.Windows.Forms.PictureBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txTicket0 = New System.Windows.Forms.TextBox()
        Me.txNumDoc = New System.Windows.Forms.TextBox()
        Me.dllTipoDocto = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tabOperaciones = New System.Windows.Forms.TabControl()
        Me.tbDepositos = New System.Windows.Forms.TabPage()
        Me.txSoportes = New System.Windows.Forms.TextBox()
        Me.txDepSucursal = New System.Windows.Forms.TextBox()
        Me.txDepFolioServicio = New System.Windows.Forms.TextBox()
        Me.txDepComision = New System.Windows.Forms.TextBox()
        Me.txDepPlaza = New System.Windows.Forms.TextBox()
        Me.txMonto = New System.Windows.Forms.TextBox()
        Me.txReferencia = New System.Windows.Forms.TextBox()
        Me.cbOriginal1 = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dllDepTipoInstrumento = New System.Windows.Forms.ComboBox()
        Me.dllDepSucursal = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.grbDepAgencias = New System.Windows.Forms.GroupBox()
        Me.txTicket = New System.Windows.Forms.TextBox()
        Me.txSufijo = New System.Windows.Forms.TextBox()
        Me.txCuenta = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.dllDepPlaza = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.grbDepMercury = New System.Windows.Forms.GroupBox()
        Me.txTicketMER = New System.Windows.Forms.TextBox()
        Me.txSufijoMER = New System.Windows.Forms.TextBox()
        Me.txCuentaMER = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.dllDepPersona = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.dllDepCte = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dtpFechaOp = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dtpFechaRecepcion = New System.Windows.Forms.DateTimePicker()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.grbDivisa = New System.Windows.Forms.GroupBox()
        Me.dllDepDivisas = New System.Windows.Forms.ComboBox()
        Me.rbOD = New System.Windows.Forms.RadioButton()
        Me.rbUS = New System.Windows.Forms.RadioButton()
        Me.rbMN = New System.Windows.Forms.RadioButton()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.tbRetiros = New System.Windows.Forms.TabPage()
        Me.txRetSucursal = New System.Windows.Forms.TextBox()
        Me.txSoportes2 = New System.Windows.Forms.TextBox()
        Me.txRetPlaza = New System.Windows.Forms.TextBox()
        Me.txMonto2 = New System.Windows.Forms.TextBox()
        Me.txReferencia2 = New System.Windows.Forms.TextBox()
        Me.txRetNumCheque = New System.Windows.Forms.TextBox()
        Me.cbOriginal2 = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dllRetTipoInstrumento = New System.Windows.Forms.ComboBox()
        Me.dllRetSucursal = New System.Windows.Forms.ComboBox()
        Me.grbRetAgencias = New System.Windows.Forms.GroupBox()
        Me.txTicket2 = New System.Windows.Forms.TextBox()
        Me.txSufijo2 = New System.Windows.Forms.TextBox()
        Me.txCuenta2 = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.dllRetPlaza = New System.Windows.Forms.ComboBox()
        Me.grbRetMercury = New System.Windows.Forms.GroupBox()
        Me.txTicketMER2 = New System.Windows.Forms.TextBox()
        Me.txSufijoMER2 = New System.Windows.Forms.TextBox()
        Me.txCuentaMER2 = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.dllRetPersona = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.dllRetCte = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.dtpFechaOp2 = New System.Windows.Forms.DateTimePicker()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.dtpFechaRecepcion2 = New System.Windows.Forms.DateTimePicker()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.dllRetDivisas = New System.Windows.Forms.ComboBox()
        Me.rbRetOD = New System.Windows.Forms.RadioButton()
        Me.rbRetUS = New System.Windows.Forms.RadioButton()
        Me.rbRetMN = New System.Windows.Forms.RadioButton()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.cbCheque = New System.Windows.Forms.CheckBox()
        Me.cbFirmaCliente = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grbNumSoportes = New System.Windows.Forms.GroupBox()
        Me.grbBotones = New System.Windows.Forms.GroupBox()
        Me.btAgregarSoporte = New System.Windows.Forms.Button()
        Me.grbTraspasos = New System.Windows.Forms.GroupBox()
        Me.cbTraspasos = New System.Windows.Forms.CheckBox()
        Me.btTraspasos = New System.Windows.Forms.Button()
        Me.grbDatosDoc.SuspendLayout()
        CType(Me.gvOperaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbBotones2.SuspendLayout()
        Me.grbSoporte.SuspendLayout()
        Me.grbDatos.SuspendLayout()
        CType(Me.pbBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabOperaciones.SuspendLayout()
        Me.tbDepositos.SuspendLayout()
        Me.grbDepAgencias.SuspendLayout()
        Me.grbDepMercury.SuspendLayout()
        Me.grbDivisa.SuspendLayout()
        Me.tbRetiros.SuspendLayout()
        Me.grbRetAgencias.SuspendLayout()
        Me.grbRetMercury.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.grbNumSoportes.SuspendLayout()
        Me.grbBotones.SuspendLayout()
        Me.grbTraspasos.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbDatosDoc
        '
        Me.grbDatosDoc.Controls.Add(Me.dtpFechaCaptura)
        Me.grbDatosDoc.Controls.Add(Me.Label11)
        Me.grbDatosDoc.Controls.Add(Me.Label8)
        Me.grbDatosDoc.Controls.Add(Me.txDocIni)
        Me.grbDatosDoc.Controls.Add(Me.cbDocto)
        Me.grbDatosDoc.Controls.Add(Me.dllTipoFuente)
        Me.grbDatosDoc.Location = New System.Drawing.Point(7, 0)
        Me.grbDatosDoc.Name = "grbDatosDoc"
        Me.grbDatosDoc.Size = New System.Drawing.Size(344, 111)
        Me.grbDatosDoc.TabIndex = 0
        Me.grbDatosDoc.TabStop = False
        '
        'dtpFechaCaptura
        '
        Me.dtpFechaCaptura.Enabled = False
        Me.dtpFechaCaptura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaCaptura.Location = New System.Drawing.Point(122, 43)
        Me.dtpFechaCaptura.Name = "dtpFechaCaptura"
        Me.dtpFechaCaptura.Size = New System.Drawing.Size(103, 28)
        Me.dtpFechaCaptura.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(160, 20)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Fecha de Captura"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(47, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 20)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Tipo Fuente"
        '
        'txDocIni
        '
        Me.txDocIni.Enabled = False
        Me.txDocIni.Location = New System.Drawing.Point(124, 71)
        Me.txDocIni.Name = "txDocIni"
        Me.txDocIni.Size = New System.Drawing.Size(99, 28)
        Me.txDocIni.TabIndex = 5
        '
        'cbDocto
        '
        Me.cbDocto.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbDocto.AutoSize = True
        Me.cbDocto.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cbDocto.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cbDocto.FlatAppearance.BorderSize = 2
        Me.cbDocto.FlatAppearance.CheckedBackColor = System.Drawing.Color.CornflowerBlue
        Me.cbDocto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbDocto.Location = New System.Drawing.Point(12, 70)
        Me.cbDocto.Name = "cbDocto"
        Me.cbDocto.Size = New System.Drawing.Size(153, 30)
        Me.cbDocto.TabIndex = 2
        Me.cbDocto.TabStop = False
        Me.cbDocto.Text = "   Documento   "
        Me.cbDocto.UseVisualStyleBackColor = False
        '
        'dllTipoFuente
        '
        Me.dllTipoFuente.FormattingEnabled = True
        Me.dllTipoFuente.Location = New System.Drawing.Point(122, 16)
        Me.dllTipoFuente.Name = "dllTipoFuente"
        Me.dllTipoFuente.Size = New System.Drawing.Size(178, 28)
        Me.dllTipoFuente.TabIndex = 0
        '
        'gvOperaciones
        '
        Me.gvOperaciones.AllowUserToAddRows = False
        Me.gvOperaciones.AllowUserToDeleteRows = False
        Me.gvOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvOperaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fecha, Me.cuenta, Me.ticket, Me.soporte, Me.descripcion_soporte, Me.documento})
        Me.gvOperaciones.Location = New System.Drawing.Point(7, 115)
        Me.gvOperaciones.MultiSelect = False
        Me.gvOperaciones.Name = "gvOperaciones"
        Me.gvOperaciones.ReadOnly = True
        Me.gvOperaciones.RowHeadersWidth = 62
        Me.gvOperaciones.Size = New System.Drawing.Size(344, 375)
        Me.gvOperaciones.TabIndex = 1
        '
        'fecha
        '
        Me.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.fecha.DataPropertyName = "fecha_captura"
        Me.fecha.HeaderText = "fecha"
        Me.fecha.MaxInputLength = 10
        Me.fecha.MinimumWidth = 8
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        Me.fecha.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.fecha.Width = 91
        '
        'cuenta
        '
        Me.cuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.cuenta.DataPropertyName = "cuenta_cliente"
        Me.cuenta.HeaderText = "cuenta"
        Me.cuenta.MinimumWidth = 8
        Me.cuenta.Name = "cuenta"
        Me.cuenta.ReadOnly = True
        Me.cuenta.Width = 103
        '
        'ticket
        '
        Me.ticket.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ticket.DataPropertyName = "ticket"
        Me.ticket.HeaderText = "ticket"
        Me.ticket.MinimumWidth = 8
        Me.ticket.Name = "ticket"
        Me.ticket.ReadOnly = True
        Me.ticket.Width = 93
        '
        'soporte
        '
        Me.soporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.soporte.DataPropertyName = "soporte"
        Me.soporte.HeaderText = "soporte"
        Me.soporte.MinimumWidth = 8
        Me.soporte.Name = "soporte"
        Me.soporte.ReadOnly = True
        Me.soporte.Visible = False
        Me.soporte.Width = 150
        '
        'descripcion_soporte
        '
        Me.descripcion_soporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.descripcion_soporte.DataPropertyName = "descripcion_soporte"
        Me.descripcion_soporte.HeaderText = "descripcion_soporte"
        Me.descripcion_soporte.MinimumWidth = 8
        Me.descripcion_soporte.Name = "descripcion_soporte"
        Me.descripcion_soporte.ReadOnly = True
        Me.descripcion_soporte.Width = 217
        '
        'documento
        '
        Me.documento.DataPropertyName = "documento"
        Me.documento.HeaderText = "documento"
        Me.documento.MinimumWidth = 8
        Me.documento.Name = "documento"
        Me.documento.ReadOnly = True
        Me.documento.Visible = False
        Me.documento.Width = 150
        '
        'grbBotones2
        '
        Me.grbBotones2.Controls.Add(Me.btCerrar)
        Me.grbBotones2.Controls.Add(Me.btCancelar)
        Me.grbBotones2.Controls.Add(Me.btGuarda)
        Me.grbBotones2.Controls.Add(Me.btImprimir)
        Me.grbBotones2.Location = New System.Drawing.Point(959, 0)
        Me.grbBotones2.Name = "grbBotones2"
        Me.grbBotones2.Size = New System.Drawing.Size(115, 490)
        Me.grbBotones2.TabIndex = 2
        Me.grbBotones2.TabStop = False
        '
        'btCerrar
        '
        Me.btCerrar.Location = New System.Drawing.Point(6, 385)
        Me.btCerrar.Name = "btCerrar"
        Me.btCerrar.Size = New System.Drawing.Size(100, 71)
        Me.btCerrar.TabIndex = 6
        Me.btCerrar.Text = "&Cerrar"
        Me.btCerrar.UseVisualStyleBackColor = True
        '
        'btCancelar
        '
        Me.btCancelar.Enabled = False
        Me.btCancelar.Location = New System.Drawing.Point(6, 272)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(100, 71)
        Me.btCancelar.TabIndex = 5
        Me.btCancelar.Text = "&Cancelar"
        Me.btCancelar.UseVisualStyleBackColor = True
        '
        'btGuarda
        '
        Me.btGuarda.Enabled = False
        Me.btGuarda.Location = New System.Drawing.Point(6, 158)
        Me.btGuarda.Name = "btGuarda"
        Me.btGuarda.Size = New System.Drawing.Size(100, 71)
        Me.btGuarda.TabIndex = 4
        Me.btGuarda.Text = "&Guardar"
        Me.btGuarda.UseVisualStyleBackColor = True
        '
        'btImprimir
        '
        Me.btImprimir.Enabled = False
        Me.btImprimir.Location = New System.Drawing.Point(6, 42)
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Size = New System.Drawing.Size(100, 70)
        Me.btImprimir.TabIndex = 3
        Me.btImprimir.Text = "&Imprimir"
        Me.btImprimir.UseVisualStyleBackColor = True
        '
        'btElimina
        '
        Me.btElimina.Enabled = False
        Me.btElimina.Location = New System.Drawing.Point(235, 26)
        Me.btElimina.Name = "btElimina"
        Me.btElimina.Size = New System.Drawing.Size(100, 35)
        Me.btElimina.TabIndex = 2
        Me.btElimina.Text = "&Eliminar Nodo"
        Me.btElimina.UseVisualStyleBackColor = True
        Me.btElimina.Visible = False
        '
        'btAgregar
        '
        Me.btAgregar.Enabled = False
        Me.btAgregar.Location = New System.Drawing.Point(13, 26)
        Me.btAgregar.Name = "btAgregar"
        Me.btAgregar.Size = New System.Drawing.Size(100, 35)
        Me.btAgregar.TabIndex = 1
        Me.btAgregar.Text = "&Agregar Docto."
        Me.btAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btAgregar.UseVisualStyleBackColor = True
        '
        'grbSoporte
        '
        Me.grbSoporte.Controls.Add(Me.dllDivisas)
        Me.grbSoporte.Controls.Add(Me.txNumDocSoporte)
        Me.grbSoporte.Controls.Add(Me.txDetalle)
        Me.grbSoporte.Controls.Add(Me.txImporteSoporte)
        Me.grbSoporte.Controls.Add(Me.dtpFechaSoporte)
        Me.grbSoporte.Controls.Add(Me.Label7)
        Me.grbSoporte.Controls.Add(Me.Label6)
        Me.grbSoporte.Controls.Add(Me.Label5)
        Me.grbSoporte.Controls.Add(Me.Label3)
        Me.grbSoporte.Controls.Add(Me.Importe)
        Me.grbSoporte.Controls.Add(Me.Label1)
        Me.grbSoporte.Controls.Add(Me.dllTipoSoporte)
        Me.grbSoporte.Controls.Add(Me.dllSoporte)
        Me.grbSoporte.Controls.Add(Me.cbSopVal)
        Me.grbSoporte.Location = New System.Drawing.Point(0, 0)
        Me.grbSoporte.Name = "grbSoporte"
        Me.grbSoporte.Size = New System.Drawing.Size(717, 134)
        Me.grbSoporte.TabIndex = 0
        Me.grbSoporte.TabStop = False
        Me.grbSoporte.Text = "Soporte"
        Me.grbSoporte.Visible = False
        '
        'dllDivisas
        '
        Me.dllDivisas.FormattingEnabled = True
        Me.dllDivisas.Location = New System.Drawing.Point(428, 104)
        Me.dllDivisas.Name = "dllDivisas"
        Me.dllDivisas.Size = New System.Drawing.Size(280, 28)
        Me.dllDivisas.TabIndex = 14
        '
        'txNumDocSoporte
        '
        Me.txNumDocSoporte.Location = New System.Drawing.Point(146, 104)
        Me.txNumDocSoporte.MaxLength = 12
        Me.txNumDocSoporte.Name = "txNumDocSoporte"
        Me.txNumDocSoporte.Size = New System.Drawing.Size(116, 28)
        Me.txNumDocSoporte.TabIndex = 13
        '
        'txDetalle
        '
        Me.txDetalle.Location = New System.Drawing.Point(146, 74)
        Me.txDetalle.Name = "txDetalle"
        Me.txDetalle.Size = New System.Drawing.Size(562, 28)
        Me.txDetalle.TabIndex = 12
        '
        'txImporteSoporte
        '
        Me.txImporteSoporte.Location = New System.Drawing.Point(146, 47)
        Me.txImporteSoporte.MaxLength = 16
        Me.txImporteSoporte.Name = "txImporteSoporte"
        Me.txImporteSoporte.Size = New System.Drawing.Size(116, 28)
        Me.txImporteSoporte.TabIndex = 11
        '
        'dtpFechaSoporte
        '
        Me.dtpFechaSoporte.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaSoporte.Location = New System.Drawing.Point(428, 47)
        Me.dtpFechaSoporte.Name = "dtpFechaSoporte"
        Me.dtpFechaSoporte.Size = New System.Drawing.Size(280, 28)
        Me.dtpFechaSoporte.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(383, 109)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 20)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Divisa"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(57, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = " N° de Docto."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(66, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 20)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Descripción"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(336, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Fecha Soporte"
        '
        'Importe
        '
        Me.Importe.AutoSize = True
        Me.Importe.Location = New System.Drawing.Point(85, 50)
        Me.Importe.Name = "Importe"
        Me.Importe.Size = New System.Drawing.Size(79, 20)
        Me.Importe.TabIndex = 4
        Me.Importe.Text = "Importe"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(265, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tipo"
        '
        'dllTipoSoporte
        '
        Me.dllTipoSoporte.FormattingEnabled = True
        Me.dllTipoSoporte.Location = New System.Drawing.Point(297, 20)
        Me.dllTipoSoporte.Name = "dllTipoSoporte"
        Me.dllTipoSoporte.Size = New System.Drawing.Size(411, 28)
        Me.dllTipoSoporte.TabIndex = 2
        '
        'dllSoporte
        '
        Me.dllSoporte.Enabled = False
        Me.dllSoporte.FormattingEnabled = True
        Me.dllSoporte.Location = New System.Drawing.Point(146, 20)
        Me.dllSoporte.Name = "dllSoporte"
        Me.dllSoporte.Size = New System.Drawing.Size(116, 28)
        Me.dllSoporte.TabIndex = 1
        '
        'cbSopVal
        '
        Me.cbSopVal.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbSopVal.AutoSize = True
        Me.cbSopVal.Location = New System.Drawing.Point(29, 18)
        Me.cbSopVal.Name = "cbSopVal"
        Me.cbSopVal.Size = New System.Drawing.Size(162, 30)
        Me.cbSopVal.TabIndex = 0
        Me.cbSopVal.Text = "   Sop. Válidos   "
        Me.cbSopVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cbSopVal.UseVisualStyleBackColor = True
        '
        'lbNumSoportes
        '
        Me.lbNumSoportes.AutoSize = True
        Me.lbNumSoportes.Location = New System.Drawing.Point(229, 69)
        Me.lbNumSoportes.Name = "lbNumSoportes"
        Me.lbNumSoportes.Size = New System.Drawing.Size(220, 20)
        Me.lbNumSoportes.TabIndex = 15
        Me.lbNumSoportes.Text = "Documentos sin Soporte"
        '
        'grbDatos
        '
        Me.grbDatos.Controls.Add(Me.pbBuscar)
        Me.grbDatos.Controls.Add(Me.Label46)
        Me.grbDatos.Controls.Add(Me.txTicket0)
        Me.grbDatos.Controls.Add(Me.txNumDoc)
        Me.grbDatos.Controls.Add(Me.dllTipoDocto)
        Me.grbDatos.Controls.Add(Me.Label4)
        Me.grbDatos.Controls.Add(Me.Label2)
        Me.grbDatos.Controls.Add(Me.tabOperaciones)
        Me.grbDatos.Controls.Add(Me.Label9)
        Me.grbDatos.Location = New System.Drawing.Point(357, 0)
        Me.grbDatos.Name = "grbDatos"
        Me.grbDatos.Size = New System.Drawing.Size(586, 490)
        Me.grbDatos.TabIndex = 3
        Me.grbDatos.TabStop = False
        '
        'pbBuscar
        '
        Me.pbBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbBuscar.Enabled = False
        Me.pbBuscar.Image = CType(resources.GetObject("pbBuscar.Image"), System.Drawing.Image)
        Me.pbBuscar.Location = New System.Drawing.Point(152, 9)
        Me.pbBuscar.Name = "pbBuscar"
        Me.pbBuscar.Size = New System.Drawing.Size(33, 30)
        Me.pbBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbBuscar.TabIndex = 46
        Me.pbBuscar.TabStop = False
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(11, 16)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(95, 20)
        Me.Label46.TabIndex = 17
        Me.Label46.Text = "No. Ticket"
        '
        'txTicket0
        '
        Me.txTicket0.Enabled = False
        Me.txTicket0.Location = New System.Drawing.Point(76, 13)
        Me.txTicket0.MaxLength = 7
        Me.txTicket0.Name = "txTicket0"
        Me.txTicket0.Size = New System.Drawing.Size(70, 28)
        Me.txTicket0.TabIndex = 16
        '
        'txNumDoc
        '
        Me.txNumDoc.BackColor = System.Drawing.Color.White
        Me.txNumDoc.Enabled = False
        Me.txNumDoc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txNumDoc.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txNumDoc.Location = New System.Drawing.Point(452, 13)
        Me.txNumDoc.Name = "txNumDoc"
        Me.txNumDoc.Size = New System.Drawing.Size(96, 29)
        Me.txNumDoc.TabIndex = 4
        Me.txNumDoc.Text = "              "
        Me.txNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dllTipoDocto
        '
        Me.dllTipoDocto.Enabled = False
        Me.dllTipoDocto.FormattingEnabled = True
        Me.dllTipoDocto.Location = New System.Drawing.Point(225, 13)
        Me.dllTipoDocto.Name = "dllTipoDocto"
        Me.dllTipoDocto.Size = New System.Drawing.Size(140, 28)
        Me.dllTipoDocto.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(375, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 20)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "N° Docto."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(191, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tipo"
        '
        'tabOperaciones
        '
        Me.tabOperaciones.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.tabOperaciones.Controls.Add(Me.tbDepositos)
        Me.tabOperaciones.Controls.Add(Me.tbRetiros)
        Me.tabOperaciones.Enabled = False
        Me.tabOperaciones.Location = New System.Drawing.Point(36, 40)
        Me.tabOperaciones.Name = "tabOperaciones"
        Me.tabOperaciones.SelectedIndex = 0
        Me.tabOperaciones.Size = New System.Drawing.Size(524, 440)
        Me.tabOperaciones.TabIndex = 15
        '
        'tbDepositos
        '
        Me.tbDepositos.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.tbDepositos.Controls.Add(Me.txSoportes)
        Me.tbDepositos.Controls.Add(Me.txDepSucursal)
        Me.tbDepositos.Controls.Add(Me.txDepFolioServicio)
        Me.tbDepositos.Controls.Add(Me.txDepComision)
        Me.tbDepositos.Controls.Add(Me.txDepPlaza)
        Me.tbDepositos.Controls.Add(Me.txMonto)
        Me.tbDepositos.Controls.Add(Me.txReferencia)
        Me.tbDepositos.Controls.Add(Me.cbOriginal1)
        Me.tbDepositos.Controls.Add(Me.Label13)
        Me.tbDepositos.Controls.Add(Me.dllDepTipoInstrumento)
        Me.tbDepositos.Controls.Add(Me.dllDepSucursal)
        Me.tbDepositos.Controls.Add(Me.Label30)
        Me.tbDepositos.Controls.Add(Me.grbDepAgencias)
        Me.tbDepositos.Controls.Add(Me.Label29)
        Me.tbDepositos.Controls.Add(Me.dllDepPlaza)
        Me.tbDepositos.Controls.Add(Me.Label28)
        Me.tbDepositos.Controls.Add(Me.grbDepMercury)
        Me.tbDepositos.Controls.Add(Me.Label27)
        Me.tbDepositos.Controls.Add(Me.dllDepPersona)
        Me.tbDepositos.Controls.Add(Me.Label26)
        Me.tbDepositos.Controls.Add(Me.dllDepCte)
        Me.tbDepositos.Controls.Add(Me.Label18)
        Me.tbDepositos.Controls.Add(Me.Label19)
        Me.tbDepositos.Controls.Add(Me.dtpFechaOp)
        Me.tbDepositos.Controls.Add(Me.Label20)
        Me.tbDepositos.Controls.Add(Me.dtpFechaRecepcion)
        Me.tbDepositos.Controls.Add(Me.Label21)
        Me.tbDepositos.Controls.Add(Me.grbDivisa)
        Me.tbDepositos.Controls.Add(Me.Label22)
        Me.tbDepositos.Controls.Add(Me.Label25)
        Me.tbDepositos.Controls.Add(Me.Label23)
        Me.tbDepositos.Controls.Add(Me.Label24)
        Me.tbDepositos.Location = New System.Drawing.Point(4, 32)
        Me.tbDepositos.Name = "tbDepositos"
        Me.tbDepositos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbDepositos.Size = New System.Drawing.Size(516, 404)
        Me.tbDepositos.TabIndex = 1
        Me.tbDepositos.Text = "Depositos"
        '
        'txSoportes
        '
        Me.txSoportes.Enabled = False
        Me.txSoportes.Location = New System.Drawing.Point(457, 359)
        Me.txSoportes.MaxLength = 3
        Me.txSoportes.Name = "txSoportes"
        Me.txSoportes.Size = New System.Drawing.Size(46, 28)
        Me.txSoportes.TabIndex = 14
        Me.txSoportes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txSoportes.Visible = False
        '
        'txDepSucursal
        '
        Me.txDepSucursal.Location = New System.Drawing.Point(133, 259)
        Me.txDepSucursal.Name = "txDepSucursal"
        Me.txDepSucursal.Size = New System.Drawing.Size(69, 28)
        Me.txDepSucursal.TabIndex = 45
        '
        'txDepFolioServicio
        '
        Me.txDepFolioServicio.Location = New System.Drawing.Point(399, 386)
        Me.txDepFolioServicio.MaxLength = 7
        Me.txDepFolioServicio.Name = "txDepFolioServicio"
        Me.txDepFolioServicio.Size = New System.Drawing.Size(104, 28)
        Me.txDepFolioServicio.TabIndex = 13
        '
        'txDepComision
        '
        Me.txDepComision.Location = New System.Drawing.Point(133, 386)
        Me.txDepComision.Name = "txDepComision"
        Me.txDepComision.Size = New System.Drawing.Size(100, 28)
        Me.txDepComision.TabIndex = 12
        '
        'txDepPlaza
        '
        Me.txDepPlaza.Location = New System.Drawing.Point(133, 232)
        Me.txDepPlaza.MaxLength = 3
        Me.txDepPlaza.Name = "txDepPlaza"
        Me.txDepPlaza.Size = New System.Drawing.Size(69, 28)
        Me.txDepPlaza.TabIndex = 44
        '
        'txMonto
        '
        Me.txMonto.Location = New System.Drawing.Point(133, 359)
        Me.txMonto.Name = "txMonto"
        Me.txMonto.Size = New System.Drawing.Size(100, 28)
        Me.txMonto.TabIndex = 11
        '
        'txReferencia
        '
        Me.txReferencia.Location = New System.Drawing.Point(433, 152)
        Me.txReferencia.MaxLength = 8
        Me.txReferencia.Name = "txReferencia"
        Me.txReferencia.Size = New System.Drawing.Size(70, 28)
        Me.txReferencia.TabIndex = 39
        '
        'cbOriginal1
        '
        Me.cbOriginal1.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbOriginal1.AutoSize = True
        Me.cbOriginal1.Location = New System.Drawing.Point(6, 9)
        Me.cbOriginal1.Name = "cbOriginal1"
        Me.cbOriginal1.Size = New System.Drawing.Size(190, 30)
        Me.cbOriginal1.TabIndex = 27
        Me.cbOriginal1.Text = "Documento Original"
        Me.cbOriginal1.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(285, 14)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(152, 20)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Fecha Recepción"
        '
        'dllDepTipoInstrumento
        '
        Me.dllDepTipoInstrumento.FormattingEnabled = True
        Me.dllDepTipoInstrumento.Location = New System.Drawing.Point(133, 332)
        Me.dllDepTipoInstrumento.Name = "dllDepTipoInstrumento"
        Me.dllDepTipoInstrumento.Size = New System.Drawing.Size(230, 28)
        Me.dllDepTipoInstrumento.TabIndex = 10
        '
        'dllDepSucursal
        '
        Me.dllDepSucursal.FormattingEnabled = True
        Me.dllDepSucursal.Location = New System.Drawing.Point(271, 259)
        Me.dllDepSucursal.Name = "dllDepSucursal"
        Me.dllDepSucursal.Size = New System.Drawing.Size(232, 28)
        Me.dllDepSucursal.TabIndex = 43
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(360, 364)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(140, 20)
        Me.Label30.TabIndex = 9
        Me.Label30.Text = "N° de Soportes"
        Me.Label30.Visible = False
        '
        'grbDepAgencias
        '
        Me.grbDepAgencias.Controls.Add(Me.txTicket)
        Me.grbDepAgencias.Controls.Add(Me.txSufijo)
        Me.grbDepAgencias.Controls.Add(Me.txCuenta)
        Me.grbDepAgencias.Controls.Add(Me.Label15)
        Me.grbDepAgencias.Controls.Add(Me.Label14)
        Me.grbDepAgencias.Location = New System.Drawing.Point(6, 44)
        Me.grbDepAgencias.Name = "grbDepAgencias"
        Me.grbDepAgencias.Size = New System.Drawing.Size(504, 46)
        Me.grbDepAgencias.TabIndex = 24
        Me.grbDepAgencias.TabStop = False
        Me.grbDepAgencias.Text = "Agencia en el Extranjero"
        '
        'txTicket
        '
        Me.txTicket.Enabled = False
        Me.txTicket.ForeColor = System.Drawing.SystemColors.Info
        Me.txTicket.Location = New System.Drawing.Point(424, 17)
        Me.txTicket.MaxLength = 7
        Me.txTicket.Name = "txTicket"
        Me.txTicket.Size = New System.Drawing.Size(70, 28)
        Me.txTicket.TabIndex = 4
        '
        'txSufijo
        '
        Me.txSufijo.Enabled = False
        Me.txSufijo.Location = New System.Drawing.Point(200, 17)
        Me.txSufijo.MaxLength = 3
        Me.txSufijo.Name = "txSufijo"
        Me.txSufijo.Size = New System.Drawing.Size(42, 28)
        Me.txSufijo.TabIndex = 3
        '
        'txCuenta
        '
        Me.txCuenta.Enabled = False
        Me.txCuenta.Location = New System.Drawing.Point(126, 17)
        Me.txCuenta.MaxLength = 6
        Me.txCuenta.Name = "txCuenta"
        Me.txCuenta.Size = New System.Drawing.Size(70, 28)
        Me.txCuenta.TabIndex = 2
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(294, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(192, 20)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "N° de Rep. de la MNI"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(76, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 20)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Cuenta"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(268, 381)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(182, 40)
        Me.Label29.TabIndex = 8
        Me.Label29.Text = "Folio del Sistema " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de Línea de Servicio"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dllDepPlaza
        '
        Me.dllDepPlaza.FormattingEnabled = True
        Me.dllDepPlaza.Location = New System.Drawing.Point(271, 232)
        Me.dllDepPlaza.Name = "dllDepPlaza"
        Me.dllDepPlaza.Size = New System.Drawing.Size(232, 28)
        Me.dllDepPlaza.TabIndex = 42
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(7, 392)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(183, 20)
        Me.Label28.TabIndex = 7
        Me.Label28.Text = "Tot. Comisión + IVA"
        '
        'grbDepMercury
        '
        Me.grbDepMercury.Controls.Add(Me.txTicketMER)
        Me.grbDepMercury.Controls.Add(Me.txSufijoMER)
        Me.grbDepMercury.Controls.Add(Me.txCuentaMER)
        Me.grbDepMercury.Controls.Add(Me.Label17)
        Me.grbDepMercury.Controls.Add(Me.Label16)
        Me.grbDepMercury.Location = New System.Drawing.Point(6, 96)
        Me.grbDepMercury.Name = "grbDepMercury"
        Me.grbDepMercury.Size = New System.Drawing.Size(504, 46)
        Me.grbDepMercury.TabIndex = 25
        Me.grbDepMercury.TabStop = False
        Me.grbDepMercury.Text = "Cuenta Mercury"
        Me.grbDepMercury.Visible = False
        '
        'txTicketMER
        '
        Me.txTicketMER.Location = New System.Drawing.Point(424, 17)
        Me.txTicketMER.MaxLength = 6
        Me.txTicketMER.Name = "txTicketMER"
        Me.txTicketMER.Size = New System.Drawing.Size(70, 28)
        Me.txTicketMER.TabIndex = 4
        '
        'txSufijoMER
        '
        Me.txSufijoMER.Location = New System.Drawing.Point(200, 17)
        Me.txSufijoMER.MaxLength = 3
        Me.txSufijoMER.Name = "txSufijoMER"
        Me.txSufijoMER.Size = New System.Drawing.Size(42, 28)
        Me.txSufijoMER.TabIndex = 3
        '
        'txCuentaMER
        '
        Me.txCuentaMER.Location = New System.Drawing.Point(126, 17)
        Me.txCuentaMER.MaxLength = 6
        Me.txCuentaMER.Name = "txCuentaMER"
        Me.txCuentaMER.Size = New System.Drawing.Size(70, 28)
        Me.txCuentaMER.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(294, 21)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(192, 20)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "N° de Rep. de la MNI"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(76, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 20)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Cuenta"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(11, 365)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(176, 20)
        Me.Label27.TabIndex = 6
        Me.Label27.Text = "Importe en Dólares"
        '
        'dllDepPersona
        '
        Me.dllDepPersona.FormattingEnabled = True
        Me.dllDepPersona.Location = New System.Drawing.Point(134, 205)
        Me.dllDepPersona.Name = "dllDepPersona"
        Me.dllDepPersona.Size = New System.Drawing.Size(369, 28)
        Me.dllDepPersona.TabIndex = 41
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(25, 336)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(159, 20)
        Me.Label26.TabIndex = 5
        Me.Label26.Text = "Tipo Instrumento"
        '
        'dllDepCte
        '
        Me.dllDepCte.FormattingEnabled = True
        Me.dllDepCte.Location = New System.Drawing.Point(133, 179)
        Me.dllDepCte.Name = "dllDepCte"
        Me.dllDepCte.Size = New System.Drawing.Size(369, 28)
        Me.dllDepCte.TabIndex = 40
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(28, 155)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(151, 20)
        Me.Label18.TabIndex = 28
        Me.Label18.Text = "Fecha Operación"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(13, 182)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(175, 20)
        Me.Label19.TabIndex = 29
        Me.Label19.Text = "Nombre del Cliente"
        '
        'dtpFechaOp
        '
        Me.dtpFechaOp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaOp.Location = New System.Drawing.Point(133, 149)
        Me.dtpFechaOp.Name = "dtpFechaOp"
        Me.dtpFechaOp.Size = New System.Drawing.Size(103, 28)
        Me.dtpFechaOp.TabIndex = 38
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 204)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(182, 40)
        Me.Label20.TabIndex = 30
        Me.Label20.Text = "Persona que realiza " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "la transacción"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dtpFechaRecepcion
        '
        Me.dtpFechaRecepcion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaRecepcion.Location = New System.Drawing.Point(389, 11)
        Me.dtpFechaRecepcion.Name = "dtpFechaRecepcion"
        Me.dtpFechaRecepcion.Size = New System.Drawing.Size(114, 28)
        Me.dtpFechaRecepcion.TabIndex = 37
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(70, 238)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(88, 20)
        Me.Label21.TabIndex = 31
        Me.Label21.Text = "No. Plaza"
        '
        'grbDivisa
        '
        Me.grbDivisa.Controls.Add(Me.dllDepDivisas)
        Me.grbDivisa.Controls.Add(Me.rbOD)
        Me.grbDivisa.Controls.Add(Me.rbUS)
        Me.grbDivisa.Controls.Add(Me.rbMN)
        Me.grbDivisa.Location = New System.Drawing.Point(6, 280)
        Me.grbDivisa.Name = "grbDivisa"
        Me.grbDivisa.Size = New System.Drawing.Size(504, 46)
        Me.grbDivisa.TabIndex = 36
        Me.grbDivisa.TabStop = False
        Me.grbDivisa.Text = "Divisa"
        '
        'dllDepDivisas
        '
        Me.dllDepDivisas.FormattingEnabled = True
        Me.dllDepDivisas.Location = New System.Drawing.Point(362, 16)
        Me.dllDepDivisas.Name = "dllDepDivisas"
        Me.dllDepDivisas.Size = New System.Drawing.Size(135, 28)
        Me.dllDepDivisas.TabIndex = 3
        '
        'rbOD
        '
        Me.rbOD.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbOD.AutoSize = True
        Me.rbOD.Location = New System.Drawing.Point(251, 16)
        Me.rbOD.Name = "rbOD"
        Me.rbOD.Size = New System.Drawing.Size(152, 30)
        Me.rbOD.TabIndex = 2
        Me.rbOD.TabStop = True
        Me.rbOD.Text = "    Otras Div.    "
        Me.rbOD.UseVisualStyleBackColor = True
        '
        'rbUS
        '
        Me.rbUS.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbUS.AutoSize = True
        Me.rbUS.Location = New System.Drawing.Point(134, 16)
        Me.rbUS.Name = "rbUS"
        Me.rbUS.Size = New System.Drawing.Size(161, 30)
        Me.rbUS.TabIndex = 1
        Me.rbUS.TabStop = True
        Me.rbUS.Text = "   Dólares U.S.   "
        Me.rbUS.UseVisualStyleBackColor = True
        '
        'rbMN
        '
        Me.rbMN.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbMN.AutoSize = True
        Me.rbMN.Location = New System.Drawing.Point(16, 16)
        Me.rbMN.Name = "rbMN"
        Me.rbMN.Size = New System.Drawing.Size(164, 30)
        Me.rbMN.TabIndex = 0
        Me.rbMN.TabStop = True
        Me.rbMN.Text = "Moneda Nacional"
        Me.rbMN.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(51, 264)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(118, 20)
        Me.Label22.TabIndex = 32
        Me.Label22.Text = "No. Sucursal"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(212, 264)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(83, 20)
        Me.Label25.TabIndex = 35
        Me.Label25.Text = "Sucursal"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(321, 155)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(150, 20)
        Me.Label23.TabIndex = 33
        Me.Label23.Text = "Número de Folio"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(231, 238)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(53, 20)
        Me.Label24.TabIndex = 34
        Me.Label24.Text = "Plaza"
        '
        'tbRetiros
        '
        Me.tbRetiros.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.tbRetiros.Controls.Add(Me.txRetSucursal)
        Me.tbRetiros.Controls.Add(Me.txSoportes2)
        Me.tbRetiros.Controls.Add(Me.txRetPlaza)
        Me.tbRetiros.Controls.Add(Me.txMonto2)
        Me.tbRetiros.Controls.Add(Me.txReferencia2)
        Me.tbRetiros.Controls.Add(Me.txRetNumCheque)
        Me.tbRetiros.Controls.Add(Me.cbOriginal2)
        Me.tbRetiros.Controls.Add(Me.Label12)
        Me.tbRetiros.Controls.Add(Me.dllRetTipoInstrumento)
        Me.tbRetiros.Controls.Add(Me.dllRetSucursal)
        Me.tbRetiros.Controls.Add(Me.grbRetAgencias)
        Me.tbRetiros.Controls.Add(Me.Label33)
        Me.tbRetiros.Controls.Add(Me.dllRetPlaza)
        Me.tbRetiros.Controls.Add(Me.grbRetMercury)
        Me.tbRetiros.Controls.Add(Me.Label36)
        Me.tbRetiros.Controls.Add(Me.dllRetPersona)
        Me.tbRetiros.Controls.Add(Me.Label37)
        Me.tbRetiros.Controls.Add(Me.dllRetCte)
        Me.tbRetiros.Controls.Add(Me.Label38)
        Me.tbRetiros.Controls.Add(Me.Label39)
        Me.tbRetiros.Controls.Add(Me.dtpFechaOp2)
        Me.tbRetiros.Controls.Add(Me.Label40)
        Me.tbRetiros.Controls.Add(Me.dtpFechaRecepcion2)
        Me.tbRetiros.Controls.Add(Me.Label41)
        Me.tbRetiros.Controls.Add(Me.GroupBox7)
        Me.tbRetiros.Controls.Add(Me.Label42)
        Me.tbRetiros.Controls.Add(Me.Label43)
        Me.tbRetiros.Controls.Add(Me.Label44)
        Me.tbRetiros.Controls.Add(Me.Label45)
        Me.tbRetiros.Controls.Add(Me.cbCheque)
        Me.tbRetiros.Controls.Add(Me.cbFirmaCliente)
        Me.tbRetiros.Location = New System.Drawing.Point(4, 32)
        Me.tbRetiros.Name = "tbRetiros"
        Me.tbRetiros.Padding = New System.Windows.Forms.Padding(3)
        Me.tbRetiros.Size = New System.Drawing.Size(516, 404)
        Me.tbRetiros.TabIndex = 0
        Me.tbRetiros.Text = "Retiros"
        '
        'txRetSucursal
        '
        Me.txRetSucursal.Location = New System.Drawing.Point(133, 259)
        Me.txRetSucursal.MaxLength = 4
        Me.txRetSucursal.Name = "txRetSucursal"
        Me.txRetSucursal.Size = New System.Drawing.Size(69, 28)
        Me.txRetSucursal.TabIndex = 107
        '
        'txSoportes2
        '
        Me.txSoportes2.Enabled = False
        Me.txSoportes2.Location = New System.Drawing.Point(457, 359)
        Me.txSoportes2.MaxLength = 3
        Me.txSoportes2.Name = "txSoportes2"
        Me.txSoportes2.Size = New System.Drawing.Size(46, 28)
        Me.txSoportes2.TabIndex = 85
        Me.txSoportes2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txSoportes2.Visible = False
        '
        'txRetPlaza
        '
        Me.txRetPlaza.Location = New System.Drawing.Point(133, 232)
        Me.txRetPlaza.MaxLength = 3
        Me.txRetPlaza.Name = "txRetPlaza"
        Me.txRetPlaza.Size = New System.Drawing.Size(69, 28)
        Me.txRetPlaza.TabIndex = 106
        '
        'txMonto2
        '
        Me.txMonto2.Location = New System.Drawing.Point(134, 359)
        Me.txMonto2.Name = "txMonto2"
        Me.txMonto2.Size = New System.Drawing.Size(100, 28)
        Me.txMonto2.TabIndex = 84
        '
        'txReferencia2
        '
        Me.txReferencia2.Location = New System.Drawing.Point(433, 152)
        Me.txReferencia2.MaxLength = 8
        Me.txReferencia2.Name = "txReferencia2"
        Me.txReferencia2.Size = New System.Drawing.Size(70, 28)
        Me.txReferencia2.TabIndex = 101
        '
        'txRetNumCheque
        '
        Me.txRetNumCheque.Location = New System.Drawing.Point(363, 387)
        Me.txRetNumCheque.Name = "txRetNumCheque"
        Me.txRetNumCheque.Size = New System.Drawing.Size(140, 28)
        Me.txRetNumCheque.TabIndex = 79
        '
        'cbOriginal2
        '
        Me.cbOriginal2.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbOriginal2.AutoSize = True
        Me.cbOriginal2.Location = New System.Drawing.Point(6, 9)
        Me.cbOriginal2.Name = "cbOriginal2"
        Me.cbOriginal2.Size = New System.Drawing.Size(190, 30)
        Me.cbOriginal2.TabIndex = 89
        Me.cbOriginal2.Text = "Documento Original"
        Me.cbOriginal2.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(285, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(152, 20)
        Me.Label12.TabIndex = 86
        Me.Label12.Text = "Fecha Recepción"
        '
        'dllRetTipoInstrumento
        '
        Me.dllRetTipoInstrumento.FormattingEnabled = True
        Me.dllRetTipoInstrumento.Location = New System.Drawing.Point(134, 332)
        Me.dllRetTipoInstrumento.Name = "dllRetTipoInstrumento"
        Me.dllRetTipoInstrumento.Size = New System.Drawing.Size(230, 28)
        Me.dllRetTipoInstrumento.TabIndex = 83
        '
        'dllRetSucursal
        '
        Me.dllRetSucursal.FormattingEnabled = True
        Me.dllRetSucursal.Location = New System.Drawing.Point(271, 259)
        Me.dllRetSucursal.Name = "dllRetSucursal"
        Me.dllRetSucursal.Size = New System.Drawing.Size(232, 28)
        Me.dllRetSucursal.TabIndex = 105
        '
        'grbRetAgencias
        '
        Me.grbRetAgencias.Controls.Add(Me.txTicket2)
        Me.grbRetAgencias.Controls.Add(Me.txSufijo2)
        Me.grbRetAgencias.Controls.Add(Me.txCuenta2)
        Me.grbRetAgencias.Controls.Add(Me.Label31)
        Me.grbRetAgencias.Controls.Add(Me.Label32)
        Me.grbRetAgencias.Location = New System.Drawing.Point(6, 44)
        Me.grbRetAgencias.Name = "grbRetAgencias"
        Me.grbRetAgencias.Size = New System.Drawing.Size(504, 46)
        Me.grbRetAgencias.TabIndex = 87
        Me.grbRetAgencias.TabStop = False
        Me.grbRetAgencias.Text = "Agencia en el Extranjero"
        '
        'txTicket2
        '
        Me.txTicket2.Enabled = False
        Me.txTicket2.Location = New System.Drawing.Point(424, 17)
        Me.txTicket2.MaxLength = 7
        Me.txTicket2.Name = "txTicket2"
        Me.txTicket2.Size = New System.Drawing.Size(70, 28)
        Me.txTicket2.TabIndex = 4
        '
        'txSufijo2
        '
        Me.txSufijo2.Location = New System.Drawing.Point(200, 17)
        Me.txSufijo2.MaxLength = 3
        Me.txSufijo2.Name = "txSufijo2"
        Me.txSufijo2.Size = New System.Drawing.Size(42, 28)
        Me.txSufijo2.TabIndex = 3
        '
        'txCuenta2
        '
        Me.txCuenta2.Location = New System.Drawing.Point(126, 17)
        Me.txCuenta2.MaxLength = 6
        Me.txCuenta2.Name = "txCuenta2"
        Me.txCuenta2.Size = New System.Drawing.Size(70, 28)
        Me.txCuenta2.TabIndex = 2
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(294, 22)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(192, 20)
        Me.Label31.TabIndex = 1
        Me.Label31.Text = "N° de Rep. de la MNI"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(76, 21)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(70, 20)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "Cuenta"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(360, 364)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(140, 20)
        Me.Label33.TabIndex = 82
        Me.Label33.Text = "N° de Soportes"
        Me.Label33.Visible = False
        '
        'dllRetPlaza
        '
        Me.dllRetPlaza.FormattingEnabled = True
        Me.dllRetPlaza.Location = New System.Drawing.Point(271, 232)
        Me.dllRetPlaza.Name = "dllRetPlaza"
        Me.dllRetPlaza.Size = New System.Drawing.Size(232, 28)
        Me.dllRetPlaza.TabIndex = 104
        '
        'grbRetMercury
        '
        Me.grbRetMercury.Controls.Add(Me.txTicketMER2)
        Me.grbRetMercury.Controls.Add(Me.txSufijoMER2)
        Me.grbRetMercury.Controls.Add(Me.txCuentaMER2)
        Me.grbRetMercury.Controls.Add(Me.Label34)
        Me.grbRetMercury.Controls.Add(Me.Label35)
        Me.grbRetMercury.Location = New System.Drawing.Point(6, 96)
        Me.grbRetMercury.Name = "grbRetMercury"
        Me.grbRetMercury.Size = New System.Drawing.Size(504, 46)
        Me.grbRetMercury.TabIndex = 88
        Me.grbRetMercury.TabStop = False
        Me.grbRetMercury.Text = "Cuenta Mercury"
        Me.grbRetMercury.Visible = False
        '
        'txTicketMER2
        '
        Me.txTicketMER2.Location = New System.Drawing.Point(424, 17)
        Me.txTicketMER2.MaxLength = 6
        Me.txTicketMER2.Name = "txTicketMER2"
        Me.txTicketMER2.Size = New System.Drawing.Size(70, 28)
        Me.txTicketMER2.TabIndex = 4
        '
        'txSufijoMER2
        '
        Me.txSufijoMER2.Location = New System.Drawing.Point(200, 17)
        Me.txSufijoMER2.MaxLength = 3
        Me.txSufijoMER2.Name = "txSufijoMER2"
        Me.txSufijoMER2.Size = New System.Drawing.Size(42, 28)
        Me.txSufijoMER2.TabIndex = 3
        '
        'txCuentaMER2
        '
        Me.txCuentaMER2.Location = New System.Drawing.Point(126, 17)
        Me.txCuentaMER2.MaxLength = 6
        Me.txCuentaMER2.Name = "txCuentaMER2"
        Me.txCuentaMER2.Size = New System.Drawing.Size(70, 28)
        Me.txCuentaMER2.TabIndex = 2
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(294, 21)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(192, 20)
        Me.Label34.TabIndex = 1
        Me.Label34.Text = "N° de Rep. de la MNI"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(76, 21)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(70, 20)
        Me.Label35.TabIndex = 0
        Me.Label35.Text = "Cuenta"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(14, 365)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(176, 20)
        Me.Label36.TabIndex = 81
        Me.Label36.Text = "Importe en Dólares"
        '
        'dllRetPersona
        '
        Me.dllRetPersona.FormattingEnabled = True
        Me.dllRetPersona.Location = New System.Drawing.Point(133, 205)
        Me.dllRetPersona.Name = "dllRetPersona"
        Me.dllRetPersona.Size = New System.Drawing.Size(370, 28)
        Me.dllRetPersona.TabIndex = 103
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(27, 336)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(159, 20)
        Me.Label37.TabIndex = 80
        Me.Label37.Text = "Tipo Instrumento"
        '
        'dllRetCte
        '
        Me.dllRetCte.FormattingEnabled = True
        Me.dllRetCte.Location = New System.Drawing.Point(133, 179)
        Me.dllRetCte.Name = "dllRetCte"
        Me.dllRetCte.Size = New System.Drawing.Size(370, 28)
        Me.dllRetCte.TabIndex = 102
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(28, 155)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(151, 20)
        Me.Label38.TabIndex = 90
        Me.Label38.Text = "Fecha Operación"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(13, 182)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(175, 20)
        Me.Label39.TabIndex = 91
        Me.Label39.Text = "Nombre del Cliente"
        '
        'dtpFechaOp2
        '
        Me.dtpFechaOp2.Enabled = False
        Me.dtpFechaOp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaOp2.Location = New System.Drawing.Point(133, 149)
        Me.dtpFechaOp2.Name = "dtpFechaOp2"
        Me.dtpFechaOp2.Size = New System.Drawing.Size(103, 28)
        Me.dtpFechaOp2.TabIndex = 100
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(6, 204)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(182, 40)
        Me.Label40.TabIndex = 92
        Me.Label40.Text = "Persona que realiza " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "la transacción"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dtpFechaRecepcion2
        '
        Me.dtpFechaRecepcion2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaRecepcion2.Location = New System.Drawing.Point(389, 11)
        Me.dtpFechaRecepcion2.Name = "dtpFechaRecepcion2"
        Me.dtpFechaRecepcion2.Size = New System.Drawing.Size(114, 28)
        Me.dtpFechaRecepcion2.TabIndex = 99
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(70, 238)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(88, 20)
        Me.Label41.TabIndex = 93
        Me.Label41.Text = "No. Plaza"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.dllRetDivisas)
        Me.GroupBox7.Controls.Add(Me.rbRetOD)
        Me.GroupBox7.Controls.Add(Me.rbRetUS)
        Me.GroupBox7.Controls.Add(Me.rbRetMN)
        Me.GroupBox7.Location = New System.Drawing.Point(6, 280)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(504, 46)
        Me.GroupBox7.TabIndex = 98
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Divisa"
        '
        'dllRetDivisas
        '
        Me.dllRetDivisas.FormattingEnabled = True
        Me.dllRetDivisas.Location = New System.Drawing.Point(362, 16)
        Me.dllRetDivisas.Name = "dllRetDivisas"
        Me.dllRetDivisas.Size = New System.Drawing.Size(135, 28)
        Me.dllRetDivisas.TabIndex = 3
        '
        'rbRetOD
        '
        Me.rbRetOD.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbRetOD.AutoSize = True
        Me.rbRetOD.Location = New System.Drawing.Point(251, 16)
        Me.rbRetOD.Name = "rbRetOD"
        Me.rbRetOD.Size = New System.Drawing.Size(152, 30)
        Me.rbRetOD.TabIndex = 2
        Me.rbRetOD.TabStop = True
        Me.rbRetOD.Text = "    Otras Div.    "
        Me.rbRetOD.UseVisualStyleBackColor = True
        '
        'rbRetUS
        '
        Me.rbRetUS.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbRetUS.AutoSize = True
        Me.rbRetUS.Location = New System.Drawing.Point(134, 16)
        Me.rbRetUS.Name = "rbRetUS"
        Me.rbRetUS.Size = New System.Drawing.Size(161, 30)
        Me.rbRetUS.TabIndex = 1
        Me.rbRetUS.TabStop = True
        Me.rbRetUS.Text = "   Dólares U.S.   "
        Me.rbRetUS.UseVisualStyleBackColor = True
        '
        'rbRetMN
        '
        Me.rbRetMN.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbRetMN.AutoSize = True
        Me.rbRetMN.Location = New System.Drawing.Point(16, 16)
        Me.rbRetMN.Name = "rbRetMN"
        Me.rbRetMN.Size = New System.Drawing.Size(164, 30)
        Me.rbRetMN.TabIndex = 0
        Me.rbRetMN.TabStop = True
        Me.rbRetMN.Text = "Moneda Nacional"
        Me.rbRetMN.UseVisualStyleBackColor = True
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(52, 264)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(118, 20)
        Me.Label42.TabIndex = 94
        Me.Label42.Text = "No. Sucursal"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(212, 264)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(83, 20)
        Me.Label43.TabIndex = 97
        Me.Label43.Text = "Sucursal"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(321, 155)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(150, 20)
        Me.Label44.TabIndex = 95
        Me.Label44.Text = "Número de Folio"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(231, 238)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(53, 20)
        Me.Label45.TabIndex = 96
        Me.Label45.Text = "Plaza"
        '
        'cbCheque
        '
        Me.cbCheque.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbCheque.AutoSize = True
        Me.cbCheque.Location = New System.Drawing.Point(254, 386)
        Me.cbCheque.Name = "cbCheque"
        Me.cbCheque.Size = New System.Drawing.Size(144, 30)
        Me.cbCheque.TabIndex = 77
        Me.cbCheque.Text = "     Cheque     "
        Me.cbCheque.UseVisualStyleBackColor = True
        '
        'cbFirmaCliente
        '
        Me.cbFirmaCliente.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbFirmaCliente.AutoSize = True
        Me.cbFirmaCliente.Location = New System.Drawing.Point(66, 386)
        Me.cbFirmaCliente.Name = "cbFirmaCliente"
        Me.cbFirmaCliente.Size = New System.Drawing.Size(217, 30)
        Me.cbFirmaCliente.TabIndex = 76
        Me.cbFirmaCliente.Text = "Ficha Firma del Cliente"
        Me.cbFirmaCliente.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label9.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(442, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(189, 44)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "             "
        '
        'grbNumSoportes
        '
        Me.grbNumSoportes.Controls.Add(Me.grbSoporte)
        Me.grbNumSoportes.Controls.Add(Me.lbNumSoportes)
        Me.grbNumSoportes.Location = New System.Drawing.Point(357, 497)
        Me.grbNumSoportes.Name = "grbNumSoportes"
        Me.grbNumSoportes.Size = New System.Drawing.Size(717, 133)
        Me.grbNumSoportes.TabIndex = 4
        Me.grbNumSoportes.TabStop = False
        Me.grbNumSoportes.Text = "Soporte"
        '
        'grbBotones
        '
        Me.grbBotones.Controls.Add(Me.btAgregarSoporte)
        Me.grbBotones.Controls.Add(Me.btAgregar)
        Me.grbBotones.Controls.Add(Me.btElimina)
        Me.grbBotones.Location = New System.Drawing.Point(10, 494)
        Me.grbBotones.Name = "grbBotones"
        Me.grbBotones.Size = New System.Drawing.Size(341, 77)
        Me.grbBotones.TabIndex = 5
        Me.grbBotones.TabStop = False
        '
        'btAgregarSoporte
        '
        Me.btAgregarSoporte.Enabled = False
        Me.btAgregarSoporte.Location = New System.Drawing.Point(125, 27)
        Me.btAgregarSoporte.Name = "btAgregarSoporte"
        Me.btAgregarSoporte.Size = New System.Drawing.Size(100, 35)
        Me.btAgregarSoporte.TabIndex = 3
        Me.btAgregarSoporte.Text = "&Agregar Soporte"
        Me.btAgregarSoporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btAgregarSoporte.UseVisualStyleBackColor = True
        '
        'grbTraspasos
        '
        Me.grbTraspasos.Controls.Add(Me.cbTraspasos)
        Me.grbTraspasos.Controls.Add(Me.btTraspasos)
        Me.grbTraspasos.Location = New System.Drawing.Point(12, 568)
        Me.grbTraspasos.Name = "grbTraspasos"
        Me.grbTraspasos.Size = New System.Drawing.Size(339, 59)
        Me.grbTraspasos.TabIndex = 6
        Me.grbTraspasos.TabStop = False
        '
        'cbTraspasos
        '
        Me.cbTraspasos.AutoSize = True
        Me.cbTraspasos.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cbTraspasos.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cbTraspasos.FlatAppearance.BorderSize = 2
        Me.cbTraspasos.FlatAppearance.CheckedBackColor = System.Drawing.Color.CornflowerBlue
        Me.cbTraspasos.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbTraspasos.Location = New System.Drawing.Point(6, 16)
        Me.cbTraspasos.Name = "cbTraspasos"
        Me.cbTraspasos.Size = New System.Drawing.Size(195, 25)
        Me.cbTraspasos.TabIndex = 3
        Me.cbTraspasos.Text = "Captura Traspaso"
        Me.cbTraspasos.UseVisualStyleBackColor = False
        '
        'btTraspasos
        '
        Me.btTraspasos.Enabled = False
        Me.btTraspasos.Location = New System.Drawing.Point(233, 18)
        Me.btTraspasos.Name = "btTraspasos"
        Me.btTraspasos.Size = New System.Drawing.Size(100, 35)
        Me.btTraspasos.TabIndex = 0
        Me.btTraspasos.Text = "Traspasos"
        Me.btTraspasos.UseVisualStyleBackColor = True
        '
        'frmCaptura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1095, 641)
        Me.Controls.Add(Me.grbTraspasos)
        Me.Controls.Add(Me.grbBotones)
        Me.Controls.Add(Me.grbDatos)
        Me.Controls.Add(Me.grbBotones2)
        Me.Controls.Add(Me.gvOperaciones)
        Me.Controls.Add(Me.grbDatosDoc)
        Me.Controls.Add(Me.grbNumSoportes)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCaptura"
        Me.Text = "Captura y Recepción de Documentos"
        Me.grbDatosDoc.ResumeLayout(False)
        Me.grbDatosDoc.PerformLayout()
        CType(Me.gvOperaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbBotones2.ResumeLayout(False)
        Me.grbSoporte.ResumeLayout(False)
        Me.grbSoporte.PerformLayout()
        Me.grbDatos.ResumeLayout(False)
        Me.grbDatos.PerformLayout()
        CType(Me.pbBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabOperaciones.ResumeLayout(False)
        Me.tbDepositos.ResumeLayout(False)
        Me.tbDepositos.PerformLayout()
        Me.grbDepAgencias.ResumeLayout(False)
        Me.grbDepAgencias.PerformLayout()
        Me.grbDepMercury.ResumeLayout(False)
        Me.grbDepMercury.PerformLayout()
        Me.grbDivisa.ResumeLayout(False)
        Me.grbDivisa.PerformLayout()
        Me.tbRetiros.ResumeLayout(False)
        Me.tbRetiros.PerformLayout()
        Me.grbRetAgencias.ResumeLayout(False)
        Me.grbRetAgencias.PerformLayout()
        Me.grbRetMercury.ResumeLayout(False)
        Me.grbRetMercury.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.grbNumSoportes.ResumeLayout(False)
        Me.grbNumSoportes.PerformLayout()
        Me.grbBotones.ResumeLayout(False)
        Me.grbTraspasos.ResumeLayout(False)
        Me.grbTraspasos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grbDatosDoc As GroupBox
    Friend WithEvents gvOperaciones As DataGridView
    Friend WithEvents grbBotones2 As GroupBox
    Friend WithEvents btCerrar As Button
    Friend WithEvents btCancelar As Button
    Friend WithEvents btGuarda As Button
    Friend WithEvents btImprimir As Button
    Friend WithEvents btElimina As Button
    Friend WithEvents btAgregar As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txDocIni As TextBox
    Friend WithEvents cbDocto As CheckBox
    Friend WithEvents dllTipoFuente As ComboBox
    Friend WithEvents grbSoporte As GroupBox
    Friend WithEvents dllDivisas As ComboBox
    Friend WithEvents txNumDocSoporte As TextBox
    Friend WithEvents txDetalle As TextBox
    Friend WithEvents txImporteSoporte As TextBox
    Friend WithEvents dtpFechaSoporte As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Importe As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dllTipoSoporte As ComboBox
    Friend WithEvents dllSoporte As ComboBox
    Friend WithEvents cbSopVal As CheckBox
    Friend WithEvents grbDatos As GroupBox
    Friend WithEvents txNumDoc As TextBox
    Friend WithEvents dllTipoDocto As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lbNumSoportes As Label
    Friend WithEvents grbNumSoportes As GroupBox
    Friend WithEvents grbBotones As GroupBox
    Friend WithEvents grbTraspasos As GroupBox
    Friend WithEvents btTraspasos As Button
    Friend WithEvents dtpFechaCaptura As DateTimePicker
    Friend WithEvents cbTraspasos As CheckBox
    Friend WithEvents fecha As DataGridViewTextBoxColumn
    Friend WithEvents cuenta As DataGridViewTextBoxColumn
    Friend WithEvents ticket As DataGridViewTextBoxColumn
    Friend WithEvents soporte As DataGridViewTextBoxColumn
    Friend WithEvents descripcion_soporte As DataGridViewTextBoxColumn
    Friend WithEvents documento As DataGridViewTextBoxColumn
    Friend WithEvents Label46 As Label
    Friend WithEvents txTicket0 As TextBox
    Friend WithEvents tabOperaciones As TabControl
    Friend WithEvents tbDepositos As TabPage
    Friend WithEvents txSoportes As TextBox
    Friend WithEvents txDepSucursal As TextBox
    Friend WithEvents txDepFolioServicio As TextBox
    Friend WithEvents txDepComision As TextBox
    Friend WithEvents txDepPlaza As TextBox
    Friend WithEvents txMonto As TextBox
    Friend WithEvents txReferencia As TextBox
    Friend WithEvents cbOriginal1 As CheckBox
    Friend WithEvents Label13 As Label
    Friend WithEvents dllDepTipoInstrumento As ComboBox
    Friend WithEvents dllDepSucursal As ComboBox
    Friend WithEvents Label30 As Label
    Friend WithEvents grbDepAgencias As GroupBox
    Friend WithEvents pbBuscar As PictureBox
    Friend WithEvents txTicket As TextBox
    Friend WithEvents txSufijo As TextBox
    Friend WithEvents txCuenta As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents dllDepPlaza As ComboBox
    Friend WithEvents Label28 As Label
    Friend WithEvents grbDepMercury As GroupBox
    Friend WithEvents txTicketMER As TextBox
    Friend WithEvents txSufijoMER As TextBox
    Friend WithEvents txCuentaMER As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents dllDepPersona As ComboBox
    Friend WithEvents Label26 As Label
    Friend WithEvents dllDepCte As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents dtpFechaOp As DateTimePicker
    Friend WithEvents Label20 As Label
    Friend WithEvents dtpFechaRecepcion As DateTimePicker
    Friend WithEvents Label21 As Label
    Friend WithEvents grbDivisa As GroupBox
    Friend WithEvents dllDepDivisas As ComboBox
    Friend WithEvents rbOD As RadioButton
    Friend WithEvents rbUS As RadioButton
    Friend WithEvents rbMN As RadioButton
    Friend WithEvents Label22 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents tbRetiros As TabPage
    Friend WithEvents txRetSucursal As TextBox
    Friend WithEvents txSoportes2 As TextBox
    Friend WithEvents txRetPlaza As TextBox
    Friend WithEvents txMonto2 As TextBox
    Friend WithEvents txReferencia2 As TextBox
    Friend WithEvents txRetNumCheque As TextBox
    Friend WithEvents cbOriginal2 As CheckBox
    Friend WithEvents Label12 As Label
    Friend WithEvents dllRetTipoInstrumento As ComboBox
    Friend WithEvents dllRetSucursal As ComboBox
    Friend WithEvents grbRetAgencias As GroupBox
    Friend WithEvents txTicket2 As TextBox
    Friend WithEvents txSufijo2 As TextBox
    Friend WithEvents txCuenta2 As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents dllRetPlaza As ComboBox
    Friend WithEvents grbRetMercury As GroupBox
    Friend WithEvents txTicketMER2 As TextBox
    Friend WithEvents txSufijoMER2 As TextBox
    Friend WithEvents txCuentaMER2 As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents dllRetPersona As ComboBox
    Friend WithEvents Label37 As Label
    Friend WithEvents dllRetCte As ComboBox
    Friend WithEvents Label38 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents dtpFechaOp2 As DateTimePicker
    Friend WithEvents Label40 As Label
    Friend WithEvents dtpFechaRecepcion2 As DateTimePicker
    Friend WithEvents Label41 As Label
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents dllRetDivisas As ComboBox
    Friend WithEvents rbRetOD As RadioButton
    Friend WithEvents rbRetUS As RadioButton
    Friend WithEvents rbRetMN As RadioButton
    Friend WithEvents Label42 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents cbCheque As CheckBox
    Friend WithEvents cbFirmaCliente As CheckBox
    Friend WithEvents btAgregarSoporte As Button
    Friend WithEvents Label9 As Label
End Class
