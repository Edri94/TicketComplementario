<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AperturaCuenta
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AperturaCuenta))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optCta100 = New System.Windows.Forms.RadioButton()
        Me.optCta000 = New System.Windows.Forms.RadioButton()
        Me.optCta687 = New System.Windows.Forms.RadioButton()
        Me.CkFideicomiso = New System.Windows.Forms.CheckBox()
        Me.grBusquedaDatosCta = New System.Windows.Forms.GroupBox()
        Me.txApellidoMat = New System.Windows.Forms.TextBox()
        Me.lbApM = New System.Windows.Forms.Label()
        Me.txApellidoPat = New System.Windows.Forms.TextBox()
        Me.lbApP = New System.Windows.Forms.Label()
        Me.DTPicker = New System.Windows.Forms.DateTimePicker()
        Me.lbTipoCliente = New System.Windows.Forms.Label()
        Me.CkConfirme = New System.Windows.Forms.CheckBox()
        Me.txNombre = New System.Windows.Forms.TextBox()
        Me.lbFechaAperturaCtaEje = New System.Windows.Forms.Label()
        Me.lbNombre = New System.Windows.Forms.Label()
        Me.txCuentaEjePesos = New System.Windows.Forms.TextBox()
        Me.ddlTipoCliente = New System.Windows.Forms.ComboBox()
        Me.lbCuentaEje = New System.Windows.Forms.Label()
        Me.grMuestraNuevaCuenta = New System.Windows.Forms.GroupBox()
        Me.btCancelar = New System.Windows.Forms.Button()
        Me.btGuardar = New System.Windows.Forms.Button()
        Me.txTicket = New System.Windows.Forms.TextBox()
        Me.lbTicket = New System.Windows.Forms.Label()
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CkPersonaFisica = New System.Windows.Forms.RadioButton()
        Me.CkPersonaMoral = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txRutaUnOrg = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ddlConcertador = New System.Windows.Forms.ComboBox()
        Me.txUniOrg = New System.Windows.Forms.TextBox()
        Me.lbCentro = New System.Windows.Forms.Label()
        Me.TXConcertador = New System.Windows.Forms.TextBox()
        Me.lbNombreConcentrador = New System.Windows.Forms.Label()
        Me.lbConcertador = New System.Windows.Forms.Label()
        Me.ddlGestores = New System.Windows.Forms.ComboBox()
        Me.lbNombreGestor = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXGestor = New System.Windows.Forms.TextBox()
        Me.lbAgencia = New System.Windows.Forms.Label()
        Me.txAgencia = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.grBusquedaDatosCta.SuspendLayout()
        Me.grMuestraNuevaCuenta.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox1.Controls.Add(Me.optCta100)
        Me.GroupBox1.Controls.Add(Me.optCta000)
        Me.GroupBox1.Controls.Add(Me.optCta687)
        Me.GroupBox1.Controls.Add(Me.CkFideicomiso)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(4, 240)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(921, 52)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de Cuenta"
        '
        'optCta100
        '
        Me.optCta100.AutoSize = True
        Me.optCta100.Location = New System.Drawing.Point(151, 20)
        Me.optCta100.Name = "optCta100"
        Me.optCta100.Size = New System.Drawing.Size(151, 17)
        Me.optCta100.TabIndex = 10
        Me.optCta100.Text = "Cheques sin intereses"
        Me.optCta100.UseVisualStyleBackColor = True
        '
        'optCta000
        '
        Me.optCta000.AutoSize = True
        Me.optCta000.Location = New System.Drawing.Point(521, 20)
        Me.optCta000.Name = "optCta000"
        Me.optCta000.Size = New System.Drawing.Size(79, 17)
        Me.optCta000.TabIndex = 12
        Me.optCta000.Text = "Inversion"
        Me.optCta000.UseVisualStyleBackColor = True
        Me.optCta000.Visible = False
        '
        'optCta687
        '
        Me.optCta687.AutoSize = True
        Me.optCta687.Location = New System.Drawing.Point(338, 20)
        Me.optCta687.Name = "optCta687"
        Me.optCta687.Size = New System.Drawing.Size(98, 17)
        Me.optCta687.TabIndex = 11
        Me.optCta687.Text = "Now Account"
        Me.optCta687.UseVisualStyleBackColor = True
        Me.optCta687.Visible = False
        '
        'CkFideicomiso
        '
        Me.CkFideicomiso.AutoSize = True
        Me.CkFideicomiso.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CkFideicomiso.Location = New System.Drawing.Point(621, 21)
        Me.CkFideicomiso.Name = "CkFideicomiso"
        Me.CkFideicomiso.Size = New System.Drawing.Size(92, 17)
        Me.CkFideicomiso.TabIndex = 13
        Me.CkFideicomiso.Text = "Fideicomiso"
        Me.CkFideicomiso.UseVisualStyleBackColor = True
        '
        'grBusquedaDatosCta
        '
        Me.grBusquedaDatosCta.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.grBusquedaDatosCta.Controls.Add(Me.txApellidoMat)
        Me.grBusquedaDatosCta.Controls.Add(Me.lbApM)
        Me.grBusquedaDatosCta.Controls.Add(Me.txApellidoPat)
        Me.grBusquedaDatosCta.Controls.Add(Me.lbApP)
        Me.grBusquedaDatosCta.Controls.Add(Me.DTPicker)
        Me.grBusquedaDatosCta.Controls.Add(Me.lbTipoCliente)
        Me.grBusquedaDatosCta.Controls.Add(Me.CkConfirme)
        Me.grBusquedaDatosCta.Controls.Add(Me.txNombre)
        Me.grBusquedaDatosCta.Controls.Add(Me.lbFechaAperturaCtaEje)
        Me.grBusquedaDatosCta.Controls.Add(Me.lbNombre)
        Me.grBusquedaDatosCta.Controls.Add(Me.txCuentaEjePesos)
        Me.grBusquedaDatosCta.Controls.Add(Me.ddlTipoCliente)
        Me.grBusquedaDatosCta.Controls.Add(Me.lbCuentaEje)
        Me.grBusquedaDatosCta.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grBusquedaDatosCta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grBusquedaDatosCta.Location = New System.Drawing.Point(3, 298)
        Me.grBusquedaDatosCta.Name = "grBusquedaDatosCta"
        Me.grBusquedaDatosCta.Size = New System.Drawing.Size(922, 186)
        Me.grBusquedaDatosCta.TabIndex = 4
        Me.grBusquedaDatosCta.TabStop = False
        Me.grBusquedaDatosCta.Text = "Busqueda"
        '
        'txApellidoMat
        '
        Me.txApellidoMat.BackColor = System.Drawing.SystemColors.Window
        Me.txApellidoMat.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txApellidoMat.Location = New System.Drawing.Point(145, 140)
        Me.txApellidoMat.MaxLength = 20
        Me.txApellidoMat.Name = "txApellidoMat"
        Me.txApellidoMat.Size = New System.Drawing.Size(186, 21)
        Me.txApellidoMat.TabIndex = 19
        Me.txApellidoMat.Visible = False
        '
        'lbApM
        '
        Me.lbApM.AutoSize = True
        Me.lbApM.Location = New System.Drawing.Point(70, 145)
        Me.lbApM.Name = "lbApM"
        Me.lbApM.Size = New System.Drawing.Size(72, 13)
        Me.lbApM.TabIndex = 25
        Me.lbApM.Text = "Ap Materno"
        Me.lbApM.Visible = False
        '
        'txApellidoPat
        '
        Me.txApellidoPat.BackColor = System.Drawing.SystemColors.Window
        Me.txApellidoPat.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txApellidoPat.Location = New System.Drawing.Point(145, 114)
        Me.txApellidoPat.MaxLength = 20
        Me.txApellidoPat.Name = "txApellidoPat"
        Me.txApellidoPat.Size = New System.Drawing.Size(186, 21)
        Me.txApellidoPat.TabIndex = 18
        Me.txApellidoPat.Visible = False
        '
        'lbApP
        '
        Me.lbApP.AutoSize = True
        Me.lbApP.Location = New System.Drawing.Point(72, 119)
        Me.lbApP.Name = "lbApP"
        Me.lbApP.Size = New System.Drawing.Size(70, 13)
        Me.lbApP.TabIndex = 23
        Me.lbApP.Text = "Ap Paterno"
        Me.lbApP.Visible = False
        '
        'DTPicker
        '
        Me.DTPicker.CustomFormat = "ddd dd MMM yyyy"
        Me.DTPicker.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPicker.Location = New System.Drawing.Point(784, 26)
        Me.DTPicker.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.DTPicker.Name = "DTPicker"
        Me.DTPicker.Size = New System.Drawing.Size(120, 21)
        Me.DTPicker.TabIndex = 15
        '
        'lbTipoCliente
        '
        Me.lbTipoCliente.AutoSize = True
        Me.lbTipoCliente.Location = New System.Drawing.Point(49, 56)
        Me.lbTipoCliente.Name = "lbTipoCliente"
        Me.lbTipoCliente.Size = New System.Drawing.Size(93, 13)
        Me.lbTipoCliente.TabIndex = 0
        Me.lbTipoCliente.Text = "Tipo de Cliente"
        '
        'CkConfirme
        '
        Me.CkConfirme.Enabled = False
        Me.CkConfirme.Location = New System.Drawing.Point(525, 81)
        Me.CkConfirme.Name = "CkConfirme"
        Me.CkConfirme.Size = New System.Drawing.Size(395, 34)
        Me.CkConfirme.TabIndex = 20
        Me.CkConfirme.Text = "Le confirme al proveedor que la cuenta no genera intereses y no acepta tarjeta de" &
    " credito"
        Me.CkConfirme.UseVisualStyleBackColor = True
        '
        'txNombre
        '
        Me.txNombre.BackColor = System.Drawing.SystemColors.Window
        Me.txNombre.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txNombre.Location = New System.Drawing.Point(145, 88)
        Me.txNombre.MaxLength = 40
        Me.txNombre.Name = "txNombre"
        Me.txNombre.Size = New System.Drawing.Size(297, 21)
        Me.txNombre.TabIndex = 17
        '
        'lbFechaAperturaCtaEje
        '
        Me.lbFechaAperturaCtaEje.AutoSize = True
        Me.lbFechaAperturaCtaEje.Location = New System.Drawing.Point(533, 32)
        Me.lbFechaAperturaCtaEje.Name = "lbFechaAperturaCtaEje"
        Me.lbFechaAperturaCtaEje.Size = New System.Drawing.Size(248, 13)
        Me.lbFechaAperturaCtaEje.TabIndex = 0
        Me.lbFechaAperturaCtaEje.Text = "Fecha de apertura de cuenta eje en pesos"
        '
        'lbNombre
        '
        Me.lbNombre.AutoSize = True
        Me.lbNombre.Location = New System.Drawing.Point(90, 93)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(52, 13)
        Me.lbNombre.TabIndex = 0
        Me.lbNombre.Text = "Nombre"
        '
        'txCuentaEjePesos
        '
        Me.txCuentaEjePesos.BackColor = System.Drawing.SystemColors.Window
        Me.txCuentaEjePesos.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCuentaEjePesos.Location = New System.Drawing.Point(145, 26)
        Me.txCuentaEjePesos.MaxLength = 10
        Me.txCuentaEjePesos.Name = "txCuentaEjePesos"
        Me.txCuentaEjePesos.Size = New System.Drawing.Size(113, 21)
        Me.txCuentaEjePesos.TabIndex = 14
        '
        'ddlTipoCliente
        '
        Me.ddlTipoCliente.BackColor = System.Drawing.SystemColors.Window
        Me.ddlTipoCliente.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ddlTipoCliente.FormattingEnabled = True
        Me.ddlTipoCliente.Location = New System.Drawing.Point(145, 51)
        Me.ddlTipoCliente.Name = "ddlTipoCliente"
        Me.ddlTipoCliente.Size = New System.Drawing.Size(186, 21)
        Me.ddlTipoCliente.TabIndex = 16
        '
        'lbCuentaEje
        '
        Me.lbCuentaEje.AutoSize = True
        Me.lbCuentaEje.Location = New System.Drawing.Point(35, 31)
        Me.lbCuentaEje.Name = "lbCuentaEje"
        Me.lbCuentaEje.Size = New System.Drawing.Size(107, 13)
        Me.lbCuentaEje.TabIndex = 0
        Me.lbCuentaEje.Text = "Cuenta eje pesos"
        '
        'grMuestraNuevaCuenta
        '
        Me.grMuestraNuevaCuenta.BackColor = System.Drawing.SystemColors.Control
        Me.grMuestraNuevaCuenta.Controls.Add(Me.btCancelar)
        Me.grMuestraNuevaCuenta.Controls.Add(Me.btGuardar)
        Me.grMuestraNuevaCuenta.Controls.Add(Me.txTicket)
        Me.grMuestraNuevaCuenta.Controls.Add(Me.lbTicket)
        Me.grMuestraNuevaCuenta.Controls.Add(Me.txtCuenta)
        Me.grMuestraNuevaCuenta.Controls.Add(Me.Label3)
        Me.grMuestraNuevaCuenta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grMuestraNuevaCuenta.Location = New System.Drawing.Point(3, 483)
        Me.grMuestraNuevaCuenta.Name = "grMuestraNuevaCuenta"
        Me.grMuestraNuevaCuenta.Size = New System.Drawing.Size(921, 67)
        Me.grMuestraNuevaCuenta.TabIndex = 5
        Me.grMuestraNuevaCuenta.TabStop = False
        '
        'btCancelar
        '
        Me.btCancelar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btCancelar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCancelar.Location = New System.Drawing.Point(789, 16)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(120, 42)
        Me.btCancelar.TabIndex = 22
        Me.btCancelar.Text = "Cancelar"
        Me.btCancelar.UseVisualStyleBackColor = False
        '
        'btGuardar
        '
        Me.btGuardar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btGuardar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGuardar.Location = New System.Drawing.Point(622, 16)
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(120, 42)
        Me.btGuardar.TabIndex = 21
        Me.btGuardar.Text = "Guardar"
        Me.btGuardar.UseVisualStyleBackColor = False
        '
        'txTicket
        '
        Me.txTicket.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txTicket.Enabled = False
        Me.txTicket.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txTicket.Location = New System.Drawing.Point(337, 25)
        Me.txTicket.Name = "txTicket"
        Me.txTicket.Size = New System.Drawing.Size(75, 23)
        Me.txTicket.TabIndex = 0
        '
        'lbTicket
        '
        Me.lbTicket.AutoSize = True
        Me.lbTicket.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTicket.Location = New System.Drawing.Point(289, 29)
        Me.lbTicket.Name = "lbTicket"
        Me.lbTicket.Size = New System.Drawing.Size(47, 13)
        Me.lbTicket.TabIndex = 0
        Me.lbTicket.Text = "Ticket"
        Me.lbTicket.Visible = False
        '
        'txtCuenta
        '
        Me.txtCuenta.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCuenta.Enabled = False
        Me.txtCuenta.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta.Location = New System.Drawing.Point(144, 25)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(75, 23)
        Me.txtCuenta.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Numero de cuenta"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox2.Controls.Add(Me.CkPersonaFisica)
        Me.GroupBox2.Controls.Add(Me.CkPersonaMoral)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(4, 182)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(921, 52)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de persona"
        '
        'CkPersonaFisica
        '
        Me.CkPersonaFisica.AutoSize = True
        Me.CkPersonaFisica.Location = New System.Drawing.Point(337, 21)
        Me.CkPersonaFisica.Name = "CkPersonaFisica"
        Me.CkPersonaFisica.Size = New System.Drawing.Size(104, 17)
        Me.CkPersonaFisica.TabIndex = 9
        Me.CkPersonaFisica.Text = "Persona fisica"
        Me.CkPersonaFisica.UseVisualStyleBackColor = True
        '
        'CkPersonaMoral
        '
        Me.CkPersonaMoral.AutoSize = True
        Me.CkPersonaMoral.Checked = True
        Me.CkPersonaMoral.Location = New System.Drawing.Point(150, 21)
        Me.CkPersonaMoral.Name = "CkPersonaMoral"
        Me.CkPersonaMoral.Size = New System.Drawing.Size(108, 17)
        Me.CkPersonaMoral.TabIndex = 8
        Me.CkPersonaMoral.TabStop = True
        Me.CkPersonaMoral.Text = "Persona moral"
        Me.CkPersonaMoral.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.txRutaUnOrg)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.ddlConcertador)
        Me.Panel1.Controls.Add(Me.txUniOrg)
        Me.Panel1.Controls.Add(Me.lbCentro)
        Me.Panel1.Controls.Add(Me.TXConcertador)
        Me.Panel1.Controls.Add(Me.lbNombreConcentrador)
        Me.Panel1.Controls.Add(Me.lbConcertador)
        Me.Panel1.Controls.Add(Me.ddlGestores)
        Me.Panel1.Controls.Add(Me.lbNombreGestor)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TXGestor)
        Me.Panel1.Controls.Add(Me.lbAgencia)
        Me.Panel1.Controls.Add(Me.txAgencia)
        Me.Panel1.Location = New System.Drawing.Point(4, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(922, 171)
        Me.Panel1.TabIndex = 6
        '
        'txRutaUnOrg
        '
        Me.txRutaUnOrg.BackColor = System.Drawing.SystemColors.Window
        Me.txRutaUnOrg.Enabled = False
        Me.txRutaUnOrg.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txRutaUnOrg.Location = New System.Drawing.Point(143, 64)
        Me.txRutaUnOrg.Multiline = True
        Me.txRutaUnOrg.Name = "txRutaUnOrg"
        Me.txRutaUnOrg.Size = New System.Drawing.Size(761, 42)
        Me.txRutaUnOrg.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(58, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Ruta del Gestor"
        '
        'ddlConcertador
        '
        Me.ddlConcertador.BackColor = System.Drawing.SystemColors.Window
        Me.ddlConcertador.Enabled = False
        Me.ddlConcertador.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ddlConcertador.FormattingEnabled = True
        Me.ddlConcertador.Location = New System.Drawing.Point(522, 112)
        Me.ddlConcertador.Name = "ddlConcertador"
        Me.ddlConcertador.Size = New System.Drawing.Size(383, 21)
        Me.ddlConcertador.TabIndex = 14
        '
        'txUniOrg
        '
        Me.txUniOrg.BackColor = System.Drawing.SystemColors.Window
        Me.txUniOrg.Enabled = False
        Me.txUniOrg.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txUniOrg.Location = New System.Drawing.Point(143, 139)
        Me.txUniOrg.Name = "txUniOrg"
        Me.txUniOrg.Size = New System.Drawing.Size(113, 21)
        Me.txUniOrg.TabIndex = 15
        '
        'lbCentro
        '
        Me.lbCentro.AutoSize = True
        Me.lbCentro.Location = New System.Drawing.Point(41, 145)
        Me.lbCentro.Name = "lbCentro"
        Me.lbCentro.Size = New System.Drawing.Size(98, 13)
        Me.lbCentro.TabIndex = 8
        Me.lbCentro.Text = "Centro responsable"
        '
        'TXConcertador
        '
        Me.TXConcertador.BackColor = System.Drawing.SystemColors.Window
        Me.TXConcertador.Enabled = False
        Me.TXConcertador.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXConcertador.Location = New System.Drawing.Point(143, 113)
        Me.TXConcertador.Name = "TXConcertador"
        Me.TXConcertador.Size = New System.Drawing.Size(113, 21)
        Me.TXConcertador.TabIndex = 12
        '
        'lbNombreConcentrador
        '
        Me.lbNombreConcentrador.AutoSize = True
        Me.lbNombreConcentrador.Location = New System.Drawing.Point(474, 118)
        Me.lbNombreConcentrador.Name = "lbNombreConcentrador"
        Me.lbNombreConcentrador.Size = New System.Drawing.Size(44, 13)
        Me.lbNombreConcentrador.TabIndex = 9
        Me.lbNombreConcentrador.Text = "Nombre"
        '
        'lbConcertador
        '
        Me.lbConcertador.AutoSize = True
        Me.lbConcertador.Location = New System.Drawing.Point(74, 118)
        Me.lbConcertador.Name = "lbConcertador"
        Me.lbConcertador.Size = New System.Drawing.Size(65, 13)
        Me.lbConcertador.TabIndex = 10
        Me.lbConcertador.Text = "Concertador"
        '
        'ddlGestores
        '
        Me.ddlGestores.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ddlGestores.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ddlGestores.FormattingEnabled = True
        Me.ddlGestores.Location = New System.Drawing.Point(521, 37)
        Me.ddlGestores.Name = "ddlGestores"
        Me.ddlGestores.Size = New System.Drawing.Size(383, 21)
        Me.ddlGestores.TabIndex = 7
        '
        'lbNombreGestor
        '
        Me.lbNombreGestor.AutoSize = True
        Me.lbNombreGestor.Location = New System.Drawing.Point(473, 43)
        Me.lbNombreGestor.Name = "lbNombreGestor"
        Me.lbNombreGestor.Size = New System.Drawing.Size(44, 13)
        Me.lbNombreGestor.TabIndex = 6
        Me.lbNombreGestor.Text = "Nombre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Gestor de cta en dlls"
        '
        'TXGestor
        '
        Me.TXGestor.BackColor = System.Drawing.SystemColors.Window
        Me.TXGestor.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXGestor.Location = New System.Drawing.Point(143, 37)
        Me.TXGestor.Name = "TXGestor"
        Me.TXGestor.Size = New System.Drawing.Size(113, 21)
        Me.TXGestor.TabIndex = 4
        '
        'lbAgencia
        '
        Me.lbAgencia.AutoSize = True
        Me.lbAgencia.Location = New System.Drawing.Point(93, 13)
        Me.lbAgencia.Name = "lbAgencia"
        Me.lbAgencia.Size = New System.Drawing.Size(46, 13)
        Me.lbAgencia.TabIndex = 3
        Me.lbAgencia.Text = "Agencia"
        '
        'txAgencia
        '
        Me.txAgencia.BackColor = System.Drawing.SystemColors.Window
        Me.txAgencia.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txAgencia.Location = New System.Drawing.Point(143, 10)
        Me.txAgencia.Name = "txAgencia"
        Me.txAgencia.Size = New System.Drawing.Size(113, 21)
        Me.txAgencia.TabIndex = 2
        '
        'AperturaCuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(928, 552)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grMuestraNuevaCuenta)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grBusquedaDatosCta)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AperturaCuenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Apertura de Cuenta CED"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grBusquedaDatosCta.ResumeLayout(False)
        Me.grBusquedaDatosCta.PerformLayout()
        Me.grMuestraNuevaCuenta.ResumeLayout(False)
        Me.grMuestraNuevaCuenta.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grBusquedaDatosCta As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txCuentaEjePesos As TextBox
    Friend WithEvents ddlTipoCliente As ComboBox
    Friend WithEvents lbCuentaEje As Label
    Friend WithEvents lbFechaAperturaCtaEje As Label
    Friend WithEvents lbNombre As Label
    Friend WithEvents txNombre As TextBox
    Friend WithEvents CkFideicomiso As CheckBox
    Friend WithEvents CkConfirme As CheckBox
    Friend WithEvents grMuestraNuevaCuenta As GroupBox
    Friend WithEvents btCancelar As Button
    Friend WithEvents btGuardar As Button
    Friend WithEvents txTicket As TextBox
    Friend WithEvents lbTicket As Label
    Friend WithEvents txtCuenta As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lbTipoCliente As Label
    Friend WithEvents DTPicker As DateTimePicker
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CkPersonaFisica As RadioButton
    Friend WithEvents CkPersonaMoral As RadioButton
    Friend WithEvents optCta100 As RadioButton
    Friend WithEvents optCta000 As RadioButton
    Friend WithEvents optCta687 As RadioButton
    Friend WithEvents txApellidoPat As TextBox
    Friend WithEvents lbApP As Label
    Friend WithEvents txApellidoMat As TextBox
    Friend WithEvents lbApM As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TXGestor As TextBox
    Friend WithEvents lbAgencia As Label
    Friend WithEvents txAgencia As TextBox
    Friend WithEvents txRutaUnOrg As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ddlConcertador As ComboBox
    Friend WithEvents txUniOrg As TextBox
    Friend WithEvents lbCentro As Label
    Friend WithEvents TXConcertador As TextBox
    Friend WithEvents lbNombreConcentrador As Label
    Friend WithEvents lbConcertador As Label
    Friend WithEvents ddlGestores As ComboBox
    Friend WithEvents lbNombreGestor As Label
End Class
