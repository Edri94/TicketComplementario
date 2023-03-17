<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompApertura
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CompApertura))
        Me.lbAgencia = New System.Windows.Forms.Label()
        Me.txAgencia = New System.Windows.Forms.TextBox()
        Me.grBusquedaGestor = New System.Windows.Forms.GroupBox()
        Me.gvOperaciones = New System.Windows.Forms.DataGridView()
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TICKET = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CuentaEje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txRutaUnOrg = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txNombreFunDll = New System.Windows.Forms.TextBox()
        Me.txFunDll = New System.Windows.Forms.TextBox()
        Me.lbGDlls = New System.Windows.Forms.Label()
        Me.txRFC = New System.Windows.Forms.TextBox()
        Me.lbRFC = New System.Windows.Forms.Label()
        Me.txgrabadora = New System.Windows.Forms.TextBox()
        Me.txlinea = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txFunPesos = New System.Windows.Forms.TextBox()
        Me.txFax = New System.Windows.Forms.TextBox()
        Me.txTelefonoCte = New System.Windows.Forms.TextBox()
        Me.lbGestorPesos = New System.Windows.Forms.Label()
        Me.lbFax = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txhoraApertura = New System.Windows.Forms.TextBox()
        Me.txfechaApertura = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbFechaAperturaCtaEje = New System.Windows.Forms.Label()
        Me.txApellidoMat = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txApellidoPat = New System.Windows.Forms.TextBox()
        Me.txCuenta = New System.Windows.Forms.TextBox()
        Me.txTicket = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbNombre = New System.Windows.Forms.Label()
        Me.lbTicket = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dllCiudad = New System.Windows.Forms.ComboBox()
        Me.txColonia = New System.Windows.Forms.TextBox()
        Me.txComponente = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txCP = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txNumInt = New System.Windows.Forms.TextBox()
        Me.txNumExt = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txCalle = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btCerrar = New System.Windows.Forms.Button()
        Me.btAceptar = New System.Windows.Forms.Button()
        Me.lbTpPersona = New System.Windows.Forms.Label()
        Me.lbPersona = New System.Windows.Forms.Label()
        Me.btCotitulares = New System.Windows.Forms.Button()
        Me.btBeneficiario = New System.Windows.Forms.Button()
        Me.btAutorizados = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CkReplicarDir = New System.Windows.Forms.CheckBox()
        Me.dllCiudadEnv = New System.Windows.Forms.ComboBox()
        Me.txColoniaEnv = New System.Windows.Forms.TextBox()
        Me.txComponenteEnv = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txCPEnv = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txNumIntEnv = New System.Windows.Forms.TextBox()
        Me.txNumExtEnv = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txCalleEnvio = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.colCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTicket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipoCuentaEje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.grBusquedaGestor.SuspendLayout()
        CType(Me.gvOperaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbAgencia
        '
        Me.lbAgencia.AutoSize = True
        Me.lbAgencia.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAgencia.Location = New System.Drawing.Point(128, 20)
        Me.lbAgencia.Name = "lbAgencia"
        Me.lbAgencia.Size = New System.Drawing.Size(59, 13)
        Me.lbAgencia.TabIndex = 0
        Me.lbAgencia.Text = "Agencia"
        '
        'txAgencia
        '
        Me.txAgencia.Enabled = False
        Me.txAgencia.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txAgencia.Location = New System.Drawing.Point(193, 18)
        Me.txAgencia.Name = "txAgencia"
        Me.txAgencia.Size = New System.Drawing.Size(128, 23)
        Me.txAgencia.TabIndex = 0
        '
        'grBusquedaGestor
        '
        Me.grBusquedaGestor.Controls.Add(Me.gvOperaciones)
        Me.grBusquedaGestor.Controls.Add(Me.txAgencia)
        Me.grBusquedaGestor.Controls.Add(Me.lbAgencia)
        Me.grBusquedaGestor.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grBusquedaGestor.Location = New System.Drawing.Point(18, 12)
        Me.grBusquedaGestor.Name = "grBusquedaGestor"
        Me.grBusquedaGestor.Size = New System.Drawing.Size(515, 243)
        Me.grBusquedaGestor.TabIndex = 1
        Me.grBusquedaGestor.TabStop = False
        '
        'gvOperaciones
        '
        Me.gvOperaciones.AllowUserToAddRows = False
        Me.gvOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvOperaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cuenta, Me.TICKET, Me.CuentaEje})
        Me.gvOperaciones.Location = New System.Drawing.Point(5, 47)
        Me.gvOperaciones.Margin = New System.Windows.Forms.Padding(2)
        Me.gvOperaciones.Name = "gvOperaciones"
        Me.gvOperaciones.ReadOnly = True
        Me.gvOperaciones.RowTemplate.Height = 24
        Me.gvOperaciones.Size = New System.Drawing.Size(505, 188)
        Me.gvOperaciones.TabIndex = 0
        '
        'Cuenta
        '
        Me.Cuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cuenta.DataPropertyName = "CUENTA"
        Me.Cuenta.FillWeight = 90.0!
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.ReadOnly = True
        Me.Cuenta.Width = 90
        '
        'TICKET
        '
        Me.TICKET.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.TICKET.DataPropertyName = "TICKET"
        Me.TICKET.FillWeight = 90.0!
        Me.TICKET.HeaderText = "Ticket"
        Me.TICKET.Name = "TICKET"
        Me.TICKET.ReadOnly = True
        Me.TICKET.Width = 90
        '
        'CuentaEje
        '
        Me.CuentaEje.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CuentaEje.DataPropertyName = "CUENTAEJE"
        Me.CuentaEje.FillWeight = 190.0!
        Me.CuentaEje.HeaderText = "Tipo Cuenta Eje"
        Me.CuentaEje.Name = "CuentaEje"
        Me.CuentaEje.ReadOnly = True
        Me.CuentaEje.Width = 190
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txRutaUnOrg)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txNombreFunDll)
        Me.GroupBox1.Controls.Add(Me.txFunDll)
        Me.GroupBox1.Controls.Add(Me.lbGDlls)
        Me.GroupBox1.Controls.Add(Me.txRFC)
        Me.GroupBox1.Controls.Add(Me.lbRFC)
        Me.GroupBox1.Controls.Add(Me.txgrabadora)
        Me.GroupBox1.Controls.Add(Me.txlinea)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.txFunPesos)
        Me.GroupBox1.Controls.Add(Me.txFax)
        Me.GroupBox1.Controls.Add(Me.txTelefonoCte)
        Me.GroupBox1.Controls.Add(Me.lbGestorPesos)
        Me.GroupBox1.Controls.Add(Me.lbFax)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txhoraApertura)
        Me.GroupBox1.Controls.Add(Me.txfechaApertura)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lbFechaAperturaCtaEje)
        Me.GroupBox1.Controls.Add(Me.txApellidoMat)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txNombre)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txApellidoPat)
        Me.GroupBox1.Controls.Add(Me.txCuenta)
        Me.GroupBox1.Controls.Add(Me.txTicket)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lbNombre)
        Me.GroupBox1.Controls.Add(Me.lbTicket)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(18, 262)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(516, 404)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle de la cuenta"
        '
        'txRutaUnOrg
        '
        Me.txRutaUnOrg.Enabled = False
        Me.txRutaUnOrg.Location = New System.Drawing.Point(100, 349)
        Me.txRutaUnOrg.Multiline = True
        Me.txRutaUnOrg.Name = "txRutaUnOrg"
        Me.txRutaUnOrg.Size = New System.Drawing.Size(394, 45)
        Me.txRutaUnOrg.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(2, 366)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Ruta del Gestor"
        '
        'txNombreFunDll
        '
        Me.txNombreFunDll.Enabled = False
        Me.txNombreFunDll.Location = New System.Drawing.Point(161, 309)
        Me.txNombreFunDll.Name = "txNombreFunDll"
        Me.txNombreFunDll.Size = New System.Drawing.Size(333, 21)
        Me.txNombreFunDll.TabIndex = 51
        '
        'txFunDll
        '
        Me.txFunDll.Enabled = False
        Me.txFunDll.Location = New System.Drawing.Point(99, 309)
        Me.txFunDll.Name = "txFunDll"
        Me.txFunDll.Size = New System.Drawing.Size(56, 21)
        Me.txFunDll.TabIndex = 50
        '
        'lbGDlls
        '
        Me.lbGDlls.AutoSize = True
        Me.lbGDlls.Location = New System.Drawing.Point(28, 316)
        Me.lbGDlls.Name = "lbGDlls"
        Me.lbGDlls.Size = New System.Drawing.Size(70, 13)
        Me.lbGDlls.TabIndex = 49
        Me.lbGDlls.Text = "Gestor Dlls"
        Me.lbGDlls.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txRFC
        '
        Me.txRFC.Location = New System.Drawing.Point(100, 244)
        Me.txRFC.MaxLength = 15
        Me.txRFC.Name = "txRFC"
        Me.txRFC.Size = New System.Drawing.Size(221, 21)
        Me.txRFC.TabIndex = 3
        '
        'lbRFC
        '
        Me.lbRFC.AutoSize = True
        Me.lbRFC.Location = New System.Drawing.Point(68, 251)
        Me.lbRFC.Name = "lbRFC"
        Me.lbRFC.Size = New System.Drawing.Size(30, 13)
        Me.lbRFC.TabIndex = 40
        Me.lbRFC.Text = "RFC"
        '
        'txgrabadora
        '
        Me.txgrabadora.Enabled = False
        Me.txgrabadora.Location = New System.Drawing.Point(453, 215)
        Me.txgrabadora.Name = "txgrabadora"
        Me.txgrabadora.Size = New System.Drawing.Size(41, 21)
        Me.txgrabadora.TabIndex = 0
        Me.txgrabadora.Visible = False
        '
        'txlinea
        '
        Me.txlinea.Enabled = False
        Me.txlinea.Location = New System.Drawing.Point(453, 186)
        Me.txlinea.Name = "txlinea"
        Me.txlinea.Size = New System.Drawing.Size(42, 21)
        Me.txlinea.TabIndex = 0
        Me.txlinea.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(384, 218)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(68, 13)
        Me.Label23.TabIndex = 37
        Me.Label23.Text = "Grabadora"
        Me.Label23.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(413, 189)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(37, 13)
        Me.Label22.TabIndex = 36
        Me.Label22.Text = "Linea"
        Me.Label22.Visible = False
        '
        'txFunPesos
        '
        Me.txFunPesos.Location = New System.Drawing.Point(100, 279)
        Me.txFunPesos.Name = "txFunPesos"
        Me.txFunPesos.Size = New System.Drawing.Size(394, 21)
        Me.txFunPesos.TabIndex = 4
        '
        'txFax
        '
        Me.txFax.Location = New System.Drawing.Point(100, 215)
        Me.txFax.MaxLength = 20
        Me.txFax.Name = "txFax"
        Me.txFax.Size = New System.Drawing.Size(221, 21)
        Me.txFax.TabIndex = 2
        '
        'txTelefonoCte
        '
        Me.txTelefonoCte.Location = New System.Drawing.Point(100, 186)
        Me.txTelefonoCte.MaxLength = 20
        Me.txTelefonoCte.Name = "txTelefonoCte"
        Me.txTelefonoCte.Size = New System.Drawing.Size(221, 21)
        Me.txTelefonoCte.TabIndex = 1
        '
        'lbGestorPesos
        '
        Me.lbGestorPesos.AutoSize = True
        Me.lbGestorPesos.Location = New System.Drawing.Point(16, 286)
        Me.lbGestorPesos.Name = "lbGestorPesos"
        Me.lbGestorPesos.Size = New System.Drawing.Size(82, 13)
        Me.lbGestorPesos.TabIndex = 32
        Me.lbGestorPesos.Text = "Gestor Pesos"
        '
        'lbFax
        '
        Me.lbFax.AutoSize = True
        Me.lbFax.Location = New System.Drawing.Point(72, 222)
        Me.lbFax.Name = "lbFax"
        Me.lbFax.Size = New System.Drawing.Size(26, 13)
        Me.lbFax.TabIndex = 31
        Me.lbFax.Text = "Fax"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(43, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Telefono"
        '
        'txhoraApertura
        '
        Me.txhoraApertura.Enabled = False
        Me.txhoraApertura.Location = New System.Drawing.Point(387, 50)
        Me.txhoraApertura.Name = "txhoraApertura"
        Me.txhoraApertura.Size = New System.Drawing.Size(107, 21)
        Me.txhoraApertura.TabIndex = 0
        '
        'txfechaApertura
        '
        Me.txfechaApertura.Enabled = False
        Me.txfechaApertura.Location = New System.Drawing.Point(387, 22)
        Me.txfechaApertura.Name = "txfechaApertura"
        Me.txfechaApertura.Size = New System.Drawing.Size(107, 21)
        Me.txfechaApertura.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(276, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Hora de apertura"
        '
        'lbFechaAperturaCtaEje
        '
        Me.lbFechaAperturaCtaEje.AutoSize = True
        Me.lbFechaAperturaCtaEje.Location = New System.Drawing.Point(270, 30)
        Me.lbFechaAperturaCtaEje.Name = "lbFechaAperturaCtaEje"
        Me.lbFechaAperturaCtaEje.Size = New System.Drawing.Size(111, 13)
        Me.lbFechaAperturaCtaEje.TabIndex = 26
        Me.lbFechaAperturaCtaEje.Text = "Fecha de apertura"
        '
        'txApellidoMat
        '
        Me.txApellidoMat.Enabled = False
        Me.txApellidoMat.Location = New System.Drawing.Point(100, 147)
        Me.txApellidoMat.Name = "txApellidoMat"
        Me.txApellidoMat.Size = New System.Drawing.Size(396, 21)
        Me.txApellidoMat.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Ap Materno"
        '
        'txNombre
        '
        Me.txNombre.Enabled = False
        Me.txNombre.Location = New System.Drawing.Point(100, 89)
        Me.txNombre.MaxLength = 30
        Me.txNombre.Name = "txNombre"
        Me.txNombre.Size = New System.Drawing.Size(396, 21)
        Me.txNombre.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Ap Paterno"
        '
        'txApellidoPat
        '
        Me.txApellidoPat.Enabled = False
        Me.txApellidoPat.Location = New System.Drawing.Point(100, 118)
        Me.txApellidoPat.Name = "txApellidoPat"
        Me.txApellidoPat.Size = New System.Drawing.Size(396, 21)
        Me.txApellidoPat.TabIndex = 0
        '
        'txCuenta
        '
        Me.txCuenta.Enabled = False
        Me.txCuenta.Location = New System.Drawing.Point(100, 50)
        Me.txCuenta.Name = "txCuenta"
        Me.txCuenta.Size = New System.Drawing.Size(130, 21)
        Me.txCuenta.TabIndex = 0
        '
        'txTicket
        '
        Me.txTicket.Enabled = False
        Me.txTicket.Location = New System.Drawing.Point(100, 22)
        Me.txTicket.Name = "txTicket"
        Me.txTicket.Size = New System.Drawing.Size(130, 21)
        Me.txTicket.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(50, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Cuenta"
        '
        'lbNombre
        '
        Me.lbNombre.AutoSize = True
        Me.lbNombre.Location = New System.Drawing.Point(46, 97)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(52, 13)
        Me.lbNombre.TabIndex = 18
        Me.lbNombre.Text = "Nombre"
        '
        'lbTicket
        '
        Me.lbTicket.AutoSize = True
        Me.lbTicket.Location = New System.Drawing.Point(57, 30)
        Me.lbTicket.Name = "lbTicket"
        Me.lbTicket.Size = New System.Drawing.Size(41, 13)
        Me.lbTicket.TabIndex = 17
        Me.lbTicket.Text = "Ticket"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dllCiudad)
        Me.GroupBox2.Controls.Add(Me.txColonia)
        Me.GroupBox2.Controls.Add(Me.txComponente)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txCP)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txNumInt)
        Me.GroupBox2.Controls.Add(Me.txNumExt)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txCalle)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(552, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(559, 191)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Direccion"
        '
        'dllCiudad
        '
        Me.dllCiudad.FormattingEnabled = True
        Me.dllCiudad.Location = New System.Drawing.Point(92, 147)
        Me.dllCiudad.Name = "dllCiudad"
        Me.dllCiudad.Size = New System.Drawing.Size(446, 21)
        Me.dllCiudad.TabIndex = 11
        '
        'txColonia
        '
        Me.txColonia.Location = New System.Drawing.Point(92, 116)
        Me.txColonia.MaxLength = 30
        Me.txColonia.Name = "txColonia"
        Me.txColonia.Size = New System.Drawing.Size(446, 21)
        Me.txColonia.TabIndex = 10
        '
        'txComponente
        '
        Me.txComponente.Location = New System.Drawing.Point(92, 84)
        Me.txComponente.MaxLength = 25
        Me.txComponente.Name = "txComponente"
        Me.txComponente.Size = New System.Drawing.Size(446, 21)
        Me.txComponente.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 152)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 13)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "Ciudad/Edo"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 90)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 13)
        Me.Label13.TabIndex = 41
        Me.Label13.Text = "Componente"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(39, 122)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Colonia"
        '
        'txCP
        '
        Me.txCP.Location = New System.Drawing.Point(460, 51)
        Me.txCP.MaxLength = 10
        Me.txCP.Name = "txCP"
        Me.txCP.Size = New System.Drawing.Size(76, 21)
        Me.txCP.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(375, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 13)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Codigo Postal"
        '
        'txNumInt
        '
        Me.txNumInt.Location = New System.Drawing.Point(283, 52)
        Me.txNumInt.MaxLength = 12
        Me.txNumInt.Name = "txNumInt"
        Me.txNumInt.Size = New System.Drawing.Size(83, 21)
        Me.txNumInt.TabIndex = 7
        '
        'txNumExt
        '
        Me.txNumExt.Location = New System.Drawing.Point(92, 52)
        Me.txNumExt.MaxLength = 12
        Me.txNumExt.Name = "txNumExt"
        Me.txNumExt.Size = New System.Drawing.Size(83, 21)
        Me.txNumExt.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(184, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(99, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Numero Interior"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Num Exterior"
        '
        'txCalle
        '
        Me.txCalle.Location = New System.Drawing.Point(92, 22)
        Me.txCalle.MaxLength = 35
        Me.txCalle.Name = "txCalle"
        Me.txCalle.Size = New System.Drawing.Size(446, 21)
        Me.txCalle.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(53, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Calle"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btCerrar)
        Me.GroupBox3.Controls.Add(Me.btAceptar)
        Me.GroupBox3.Location = New System.Drawing.Point(552, 588)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(559, 77)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        '
        'btCerrar
        '
        Me.btCerrar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCerrar.Location = New System.Drawing.Point(439, 23)
        Me.btCerrar.Margin = New System.Windows.Forms.Padding(2)
        Me.btCerrar.Name = "btCerrar"
        Me.btCerrar.Size = New System.Drawing.Size(100, 35)
        Me.btCerrar.TabIndex = 24
        Me.btCerrar.Text = "Cerrar"
        Me.btCerrar.UseVisualStyleBackColor = True
        '
        'btAceptar
        '
        Me.btAceptar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAceptar.Location = New System.Drawing.Point(322, 23)
        Me.btAceptar.Margin = New System.Windows.Forms.Padding(2)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(100, 35)
        Me.btAceptar.TabIndex = 23
        Me.btAceptar.Text = "Aceptar"
        Me.btAceptar.UseVisualStyleBackColor = True
        '
        'lbTpPersona
        '
        Me.lbTpPersona.AutoSize = True
        Me.lbTpPersona.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTpPersona.ForeColor = System.Drawing.Color.Blue
        Me.lbTpPersona.Location = New System.Drawing.Point(131, 21)
        Me.lbTpPersona.Name = "lbTpPersona"
        Me.lbTpPersona.Size = New System.Drawing.Size(15, 14)
        Me.lbTpPersona.TabIndex = 42
        Me.lbTpPersona.Text = ".."
        '
        'lbPersona
        '
        Me.lbPersona.AutoSize = True
        Me.lbPersona.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPersona.Location = New System.Drawing.Point(11, 22)
        Me.lbPersona.Name = "lbPersona"
        Me.lbPersona.Size = New System.Drawing.Size(122, 14)
        Me.lbPersona.TabIndex = 41
        Me.lbPersona.Text = "Tipo de Persona: "
        '
        'btCotitulares
        '
        Me.btCotitulares.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCotitulares.Location = New System.Drawing.Point(439, 89)
        Me.btCotitulares.Margin = New System.Windows.Forms.Padding(2)
        Me.btCotitulares.Name = "btCotitulares"
        Me.btCotitulares.Size = New System.Drawing.Size(100, 35)
        Me.btCotitulares.TabIndex = 22
        Me.btCotitulares.Text = "Cotitulares"
        Me.btCotitulares.UseVisualStyleBackColor = True
        '
        'btBeneficiario
        '
        Me.btBeneficiario.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btBeneficiario.Location = New System.Drawing.Point(322, 89)
        Me.btBeneficiario.Margin = New System.Windows.Forms.Padding(2)
        Me.btBeneficiario.Name = "btBeneficiario"
        Me.btBeneficiario.Size = New System.Drawing.Size(100, 35)
        Me.btBeneficiario.TabIndex = 21
        Me.btBeneficiario.Text = "Beneficiarios"
        Me.btBeneficiario.UseVisualStyleBackColor = True
        '
        'btAutorizados
        '
        Me.btAutorizados.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAutorizados.Location = New System.Drawing.Point(201, 88)
        Me.btAutorizados.Margin = New System.Windows.Forms.Padding(2)
        Me.btAutorizados.Name = "btAutorizados"
        Me.btAutorizados.Size = New System.Drawing.Size(100, 35)
        Me.btAutorizados.TabIndex = 20
        Me.btAutorizados.Text = "Autorizados"
        Me.btAutorizados.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CkReplicarDir)
        Me.GroupBox4.Controls.Add(Me.dllCiudadEnv)
        Me.GroupBox4.Controls.Add(Me.txColoniaEnv)
        Me.GroupBox4.Controls.Add(Me.txComponenteEnv)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.txCPEnv)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.txNumIntEnv)
        Me.GroupBox4.Controls.Add(Me.txNumExtEnv)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.txCalleEnvio)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(552, 209)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(559, 228)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Direccion Envio"
        '
        'CkReplicarDir
        '
        Me.CkReplicarDir.AutoSize = True
        Me.CkReplicarDir.Location = New System.Drawing.Point(415, 17)
        Me.CkReplicarDir.Name = "CkReplicarDir"
        Me.CkReplicarDir.Size = New System.Drawing.Size(129, 17)
        Me.CkReplicarDir.TabIndex = 12
        Me.CkReplicarDir.Text = "Replicar Direccion"
        Me.CkReplicarDir.UseVisualStyleBackColor = True
        '
        'dllCiudadEnv
        '
        Me.dllCiudadEnv.FormattingEnabled = True
        Me.dllCiudadEnv.Location = New System.Drawing.Point(92, 184)
        Me.dllCiudadEnv.Name = "dllCiudadEnv"
        Me.dllCiudadEnv.Size = New System.Drawing.Size(447, 21)
        Me.dllCiudadEnv.TabIndex = 19
        '
        'txColoniaEnv
        '
        Me.txColoniaEnv.Location = New System.Drawing.Point(92, 152)
        Me.txColoniaEnv.MaxLength = 30
        Me.txColoniaEnv.Name = "txColoniaEnv"
        Me.txColoniaEnv.Size = New System.Drawing.Size(447, 21)
        Me.txColoniaEnv.TabIndex = 18
        '
        'txComponenteEnv
        '
        Me.txComponenteEnv.Location = New System.Drawing.Point(92, 120)
        Me.txComponenteEnv.MaxLength = 25
        Me.txComponenteEnv.Name = "txComponenteEnv"
        Me.txComponenteEnv.Size = New System.Drawing.Size(447, 21)
        Me.txComponenteEnv.TabIndex = 17
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(16, 190)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 13)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "Ciudad/Edo"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 127)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 13)
        Me.Label16.TabIndex = 41
        Me.Label16.Text = "Componente"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(39, 159)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(50, 13)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "Colonia"
        '
        'txCPEnv
        '
        Me.txCPEnv.Location = New System.Drawing.Point(462, 87)
        Me.txCPEnv.MaxLength = 10
        Me.txCPEnv.Name = "txCPEnv"
        Me.txCPEnv.Size = New System.Drawing.Size(76, 21)
        Me.txCPEnv.TabIndex = 16
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(375, 94)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 13)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "Codigo Postal"
        '
        'txNumIntEnv
        '
        Me.txNumIntEnv.Location = New System.Drawing.Point(290, 87)
        Me.txNumIntEnv.MaxLength = 12
        Me.txNumIntEnv.Name = "txNumIntEnv"
        Me.txNumIntEnv.Size = New System.Drawing.Size(76, 21)
        Me.txNumIntEnv.TabIndex = 15
        '
        'txNumExtEnv
        '
        Me.txNumExtEnv.Location = New System.Drawing.Point(92, 87)
        Me.txNumExtEnv.MaxLength = 12
        Me.txNumExtEnv.Name = "txNumExtEnv"
        Me.txNumExtEnv.Size = New System.Drawing.Size(76, 21)
        Me.txNumExtEnv.TabIndex = 14
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(188, 93)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(99, 13)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Numero Interior"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(7, 93)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(82, 13)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "Num Exterior"
        '
        'txCalleEnvio
        '
        Me.txCalleEnvio.Location = New System.Drawing.Point(92, 56)
        Me.txCalleEnvio.MaxLength = 35
        Me.txCalleEnvio.Name = "txCalleEnvio"
        Me.txCalleEnvio.Size = New System.Drawing.Size(447, 21)
        Me.txCalleEnvio.TabIndex = 13
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(53, 62)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(36, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Calle"
        '
        'colCuenta
        '
        Me.colCuenta.DataPropertyName = "Cuenta"
        Me.colCuenta.HeaderText = "Cuenta"
        Me.colCuenta.Name = "colCuenta"
        Me.colCuenta.Width = 82
        '
        'colTicket
        '
        Me.colTicket.HeaderText = "Ticket"
        Me.colTicket.Name = "colTicket"
        Me.colTicket.Width = 75
        '
        'colTipoCuentaEje
        '
        Me.colTipoCuentaEje.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.colTipoCuentaEje.FillWeight = 400.0!
        Me.colTipoCuentaEje.HeaderText = "Cuenta Eje"
        Me.colTipoCuentaEje.Name = "colTipoCuentaEje"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lbTpPersona)
        Me.GroupBox5.Controls.Add(Me.btBeneficiario)
        Me.GroupBox5.Controls.Add(Me.lbPersona)
        Me.GroupBox5.Controls.Add(Me.btAutorizados)
        Me.GroupBox5.Controls.Add(Me.btCotitulares)
        Me.GroupBox5.Location = New System.Drawing.Point(552, 443)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(559, 139)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        '
        'CompApertura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1123, 678)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grBusquedaGestor)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "CompApertura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Complemento de apertura de cuenta"
        Me.grBusquedaGestor.ResumeLayout(False)
        Me.grBusquedaGestor.PerformLayout()
        CType(Me.gvOperaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lbAgencia As Label
    Friend WithEvents txAgencia As TextBox
    Friend WithEvents grBusquedaGestor As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lbTicket As Label
    Friend WithEvents lbNombre As Label
    Friend WithEvents txApellidoPat As TextBox
    Friend WithEvents txCuenta As TextBox
    Friend WithEvents txTicket As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txNombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txApellidoMat As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txhoraApertura As TextBox
    Friend WithEvents txfechaApertura As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lbFechaAperturaCtaEje As Label
    Friend WithEvents lbGestorPesos As Label
    Friend WithEvents lbFax As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txFunPesos As TextBox
    Friend WithEvents txFax As TextBox
    Friend WithEvents txTelefonoCte As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txCalle As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txCP As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txNumInt As TextBox
    Friend WithEvents txNumExt As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btAutorizados As Button
    Friend WithEvents txColonia As TextBox
    Friend WithEvents txComponente As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents dllCiudad As ComboBox
    Friend WithEvents btCerrar As Button
    Friend WithEvents btAceptar As Button
    Friend WithEvents btCotitulares As Button
    Friend WithEvents btBeneficiario As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dllCiudadEnv As ComboBox
    Friend WithEvents txColoniaEnv As TextBox
    Friend WithEvents txComponenteEnv As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txCPEnv As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txNumIntEnv As TextBox
    Friend WithEvents txNumExtEnv As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txCalleEnvio As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents colCuenta As DataGridViewTextBoxColumn
    Friend WithEvents colTicket As DataGridViewTextBoxColumn
    Friend WithEvents colTipoCuentaEje As DataGridViewTextBoxColumn
    Friend WithEvents gvOperaciones As DataGridView
    Friend WithEvents txRFC As TextBox
    Friend WithEvents lbRFC As Label
    Friend WithEvents Cuenta As DataGridViewTextBoxColumn
    Friend WithEvents TICKET As DataGridViewTextBoxColumn
    Friend WithEvents CuentaEje As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txgrabadora As TextBox
    Friend WithEvents txlinea As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents CkReplicarDir As CheckBox
    Friend WithEvents lbTpPersona As Label
    Friend WithEvents lbPersona As Label
    Friend WithEvents txNombreFunDll As TextBox
    Friend WithEvents txFunDll As TextBox
    Friend WithEvents lbGDlls As Label
    Friend WithEvents txRutaUnOrg As TextBox
    Friend WithEvents Label6 As Label
End Class
