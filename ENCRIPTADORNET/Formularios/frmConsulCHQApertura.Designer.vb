<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsulCHQApertura
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsulCHQApertura))
        Me.grbCtaPesos = New System.Windows.Forms.GroupBox()
        Me.txNumCtaEje = New System.Windows.Forms.TextBox()
        Me.txSucursal = New System.Windows.Forms.TextBox()
        Me.txNumSucursal = New System.Windows.Forms.TextBox()
        Me.txPlaza = New System.Windows.Forms.TextBox()
        Me.txNumPlaza = New System.Windows.Forms.TextBox()
        Me.txCR = New System.Windows.Forms.TextBox()
        Me.txNumCR = New System.Windows.Forms.TextBox()
        Me.txNomGestor = New System.Windows.Forms.TextBox()
        Me.txNumGestorP = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.grbCtaDlls = New System.Windows.Forms.GroupBox()
        Me.txSufijo = New System.Windows.Forms.TextBox()
        Me.txtCtaDlls = New System.Windows.Forms.TextBox()
        Me.txPrefAgencia = New System.Windows.Forms.TextBox()
        Me.txSucursalDlls = New System.Windows.Forms.TextBox()
        Me.txNumSucDlls = New System.Windows.Forms.TextBox()
        Me.txPlazaDlls = New System.Windows.Forms.TextBox()
        Me.txNumPlazaDlls = New System.Windows.Forms.TextBox()
        Me.txCRDlls = New System.Windows.Forms.TextBox()
        Me.txNumCRDlls = New System.Windows.Forms.TextBox()
        Me.txNomGestorDlls = New System.Windows.Forms.TextBox()
        Me.txNumGestorDlls = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.grbSolicitud = New System.Windows.Forms.GroupBox()
        Me.rdCHQEspecial = New System.Windows.Forms.RadioButton()
        Me.rdCHQNormal = New System.Windows.Forms.RadioButton()
        Me.btSolicitar = New System.Windows.Forms.Button()
        Me.grbDatosCuenta = New System.Windows.Forms.GroupBox()
        Me.btBuscar = New System.Windows.Forms.Button()
        Me.txFecha = New System.Windows.Forms.TextBox()
        Me.txNombre = New System.Windows.Forms.TextBox()
        Me.txCuenta = New System.Windows.Forms.TextBox()
        Me.txPrefijo = New System.Windows.Forms.TextBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btLimpiar = New System.Windows.Forms.Button()
        Me.btCerrar = New System.Windows.Forms.Button()
        Me.gvOperaciones = New System.Windows.Forms.DataGridView()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ticket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grbCtaPesos.SuspendLayout()
        Me.grbCtaDlls.SuspendLayout()
        Me.grbSolicitud.SuspendLayout()
        Me.grbDatosCuenta.SuspendLayout()
        CType(Me.gvOperaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbCtaPesos
        '
        Me.grbCtaPesos.Controls.Add(Me.txNumCtaEje)
        Me.grbCtaPesos.Controls.Add(Me.txSucursal)
        Me.grbCtaPesos.Controls.Add(Me.txNumSucursal)
        Me.grbCtaPesos.Controls.Add(Me.txPlaza)
        Me.grbCtaPesos.Controls.Add(Me.txNumPlaza)
        Me.grbCtaPesos.Controls.Add(Me.txCR)
        Me.grbCtaPesos.Controls.Add(Me.txNumCR)
        Me.grbCtaPesos.Controls.Add(Me.txNomGestor)
        Me.grbCtaPesos.Controls.Add(Me.txNumGestorP)
        Me.grbCtaPesos.Controls.Add(Me.Label11)
        Me.grbCtaPesos.Controls.Add(Me.Label10)
        Me.grbCtaPesos.Controls.Add(Me.Label9)
        Me.grbCtaPesos.Controls.Add(Me.Label8)
        Me.grbCtaPesos.Controls.Add(Me.Label7)
        Me.grbCtaPesos.Location = New System.Drawing.Point(369, 116)
        Me.grbCtaPesos.Name = "grbCtaPesos"
        Me.grbCtaPesos.Size = New System.Drawing.Size(554, 159)
        Me.grbCtaPesos.TabIndex = 0
        Me.grbCtaPesos.TabStop = False
        Me.grbCtaPesos.Text = "Gestor de Cuentas Pesos"
        '
        'txNumCtaEje
        '
        Me.txNumCtaEje.Enabled = False
        Me.txNumCtaEje.Location = New System.Drawing.Point(121, 129)
        Me.txNumCtaEje.Name = "txNumCtaEje"
        Me.txNumCtaEje.Size = New System.Drawing.Size(93, 28)
        Me.txNumCtaEje.TabIndex = 14
        '
        'txSucursal
        '
        Me.txSucursal.Enabled = False
        Me.txSucursal.Location = New System.Drawing.Point(192, 103)
        Me.txSucursal.Name = "txSucursal"
        Me.txSucursal.Size = New System.Drawing.Size(348, 28)
        Me.txSucursal.TabIndex = 13
        '
        'txNumSucursal
        '
        Me.txNumSucursal.Enabled = False
        Me.txNumSucursal.Location = New System.Drawing.Point(121, 103)
        Me.txNumSucursal.Name = "txNumSucursal"
        Me.txNumSucursal.Size = New System.Drawing.Size(65, 28)
        Me.txNumSucursal.TabIndex = 12
        '
        'txPlaza
        '
        Me.txPlaza.Enabled = False
        Me.txPlaza.Location = New System.Drawing.Point(192, 77)
        Me.txPlaza.Name = "txPlaza"
        Me.txPlaza.Size = New System.Drawing.Size(348, 28)
        Me.txPlaza.TabIndex = 11
        '
        'txNumPlaza
        '
        Me.txNumPlaza.Enabled = False
        Me.txNumPlaza.Location = New System.Drawing.Point(121, 77)
        Me.txNumPlaza.Name = "txNumPlaza"
        Me.txNumPlaza.Size = New System.Drawing.Size(65, 28)
        Me.txNumPlaza.TabIndex = 10
        '
        'txCR
        '
        Me.txCR.Enabled = False
        Me.txCR.Location = New System.Drawing.Point(192, 50)
        Me.txCR.Name = "txCR"
        Me.txCR.Size = New System.Drawing.Size(348, 28)
        Me.txCR.TabIndex = 9
        '
        'txNumCR
        '
        Me.txNumCR.Enabled = False
        Me.txNumCR.Location = New System.Drawing.Point(121, 50)
        Me.txNumCR.Name = "txNumCR"
        Me.txNumCR.Size = New System.Drawing.Size(65, 28)
        Me.txNumCR.TabIndex = 8
        '
        'txNomGestor
        '
        Me.txNomGestor.Enabled = False
        Me.txNomGestor.Location = New System.Drawing.Point(192, 24)
        Me.txNomGestor.Name = "txNomGestor"
        Me.txNomGestor.Size = New System.Drawing.Size(348, 28)
        Me.txNomGestor.TabIndex = 7
        '
        'txNumGestorP
        '
        Me.txNumGestorP.Enabled = False
        Me.txNumGestorP.Location = New System.Drawing.Point(121, 24)
        Me.txNumGestorP.Name = "txNumGestorP"
        Me.txNumGestorP.Size = New System.Drawing.Size(65, 28)
        Me.txNumGestorP.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 132)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(157, 20)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Cuenta Eje Pesos"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(63, 106)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 20)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Sucursal"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(81, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 20)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Plaza"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(146, 20)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Centro Regional"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(73, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 20)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Gestor"
        '
        'grbCtaDlls
        '
        Me.grbCtaDlls.Controls.Add(Me.txSufijo)
        Me.grbCtaDlls.Controls.Add(Me.txtCtaDlls)
        Me.grbCtaDlls.Controls.Add(Me.txPrefAgencia)
        Me.grbCtaDlls.Controls.Add(Me.txSucursalDlls)
        Me.grbCtaDlls.Controls.Add(Me.txNumSucDlls)
        Me.grbCtaDlls.Controls.Add(Me.txPlazaDlls)
        Me.grbCtaDlls.Controls.Add(Me.txNumPlazaDlls)
        Me.grbCtaDlls.Controls.Add(Me.txCRDlls)
        Me.grbCtaDlls.Controls.Add(Me.txNumCRDlls)
        Me.grbCtaDlls.Controls.Add(Me.txNomGestorDlls)
        Me.grbCtaDlls.Controls.Add(Me.txNumGestorDlls)
        Me.grbCtaDlls.Controls.Add(Me.Label17)
        Me.grbCtaDlls.Controls.Add(Me.Label16)
        Me.grbCtaDlls.Controls.Add(Me.Label15)
        Me.grbCtaDlls.Controls.Add(Me.Label14)
        Me.grbCtaDlls.Controls.Add(Me.Label13)
        Me.grbCtaDlls.Location = New System.Drawing.Point(369, 283)
        Me.grbCtaDlls.Name = "grbCtaDlls"
        Me.grbCtaDlls.Size = New System.Drawing.Size(554, 166)
        Me.grbCtaDlls.TabIndex = 1
        Me.grbCtaDlls.TabStop = False
        Me.grbCtaDlls.Text = "Gestor de Cuentas Dólares"
        '
        'txSufijo
        '
        Me.txSufijo.Enabled = False
        Me.txSufijo.Location = New System.Drawing.Point(263, 132)
        Me.txSufijo.Name = "txSufijo"
        Me.txSufijo.Size = New System.Drawing.Size(65, 28)
        Me.txSufijo.TabIndex = 16
        '
        'txtCtaDlls
        '
        Me.txtCtaDlls.Enabled = False
        Me.txtCtaDlls.Location = New System.Drawing.Point(193, 132)
        Me.txtCtaDlls.Name = "txtCtaDlls"
        Me.txtCtaDlls.Size = New System.Drawing.Size(65, 28)
        Me.txtCtaDlls.TabIndex = 15
        '
        'txPrefAgencia
        '
        Me.txPrefAgencia.Enabled = False
        Me.txPrefAgencia.Location = New System.Drawing.Point(122, 132)
        Me.txPrefAgencia.Name = "txPrefAgencia"
        Me.txPrefAgencia.Size = New System.Drawing.Size(65, 28)
        Me.txPrefAgencia.TabIndex = 14
        '
        'txSucursalDlls
        '
        Me.txSucursalDlls.Enabled = False
        Me.txSucursalDlls.Location = New System.Drawing.Point(192, 106)
        Me.txSucursalDlls.Name = "txSucursalDlls"
        Me.txSucursalDlls.Size = New System.Drawing.Size(348, 28)
        Me.txSucursalDlls.TabIndex = 13
        '
        'txNumSucDlls
        '
        Me.txNumSucDlls.Enabled = False
        Me.txNumSucDlls.Location = New System.Drawing.Point(121, 106)
        Me.txNumSucDlls.Name = "txNumSucDlls"
        Me.txNumSucDlls.Size = New System.Drawing.Size(65, 28)
        Me.txNumSucDlls.TabIndex = 12
        '
        'txPlazaDlls
        '
        Me.txPlazaDlls.Enabled = False
        Me.txPlazaDlls.Location = New System.Drawing.Point(192, 80)
        Me.txPlazaDlls.Name = "txPlazaDlls"
        Me.txPlazaDlls.Size = New System.Drawing.Size(348, 28)
        Me.txPlazaDlls.TabIndex = 11
        '
        'txNumPlazaDlls
        '
        Me.txNumPlazaDlls.Enabled = False
        Me.txNumPlazaDlls.Location = New System.Drawing.Point(121, 80)
        Me.txNumPlazaDlls.Name = "txNumPlazaDlls"
        Me.txNumPlazaDlls.Size = New System.Drawing.Size(65, 28)
        Me.txNumPlazaDlls.TabIndex = 10
        '
        'txCRDlls
        '
        Me.txCRDlls.Enabled = False
        Me.txCRDlls.Location = New System.Drawing.Point(192, 54)
        Me.txCRDlls.Name = "txCRDlls"
        Me.txCRDlls.Size = New System.Drawing.Size(348, 28)
        Me.txCRDlls.TabIndex = 9
        '
        'txNumCRDlls
        '
        Me.txNumCRDlls.Enabled = False
        Me.txNumCRDlls.Location = New System.Drawing.Point(121, 54)
        Me.txNumCRDlls.Name = "txNumCRDlls"
        Me.txNumCRDlls.Size = New System.Drawing.Size(65, 28)
        Me.txNumCRDlls.TabIndex = 8
        '
        'txNomGestorDlls
        '
        Me.txNomGestorDlls.Enabled = False
        Me.txNomGestorDlls.Location = New System.Drawing.Point(192, 28)
        Me.txNomGestorDlls.Name = "txNomGestorDlls"
        Me.txNomGestorDlls.Size = New System.Drawing.Size(348, 28)
        Me.txNomGestorDlls.TabIndex = 7
        '
        'txNumGestorDlls
        '
        Me.txNumGestorDlls.Enabled = False
        Me.txNumGestorDlls.Location = New System.Drawing.Point(121, 28)
        Me.txNumGestorDlls.Name = "txNumGestorDlls"
        Me.txNumGestorDlls.Size = New System.Drawing.Size(65, 28)
        Me.txNumGestorDlls.TabIndex = 6
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label17.Location = New System.Drawing.Point(23, 136)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(141, 20)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Cuenta Eje Dlls"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(62, 109)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 20)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Sucursal"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(83, 83)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 20)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Plaza"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(19, 57)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(146, 20)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Centro Regional"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(75, 31)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 20)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Gestor"
        '
        'grbSolicitud
        '
        Me.grbSolicitud.Controls.Add(Me.rdCHQEspecial)
        Me.grbSolicitud.Controls.Add(Me.rdCHQNormal)
        Me.grbSolicitud.Controls.Add(Me.btSolicitar)
        Me.grbSolicitud.Location = New System.Drawing.Point(12, 283)
        Me.grbSolicitud.Name = "grbSolicitud"
        Me.grbSolicitud.Size = New System.Drawing.Size(347, 96)
        Me.grbSolicitud.TabIndex = 2
        Me.grbSolicitud.TabStop = False
        Me.grbSolicitud.Text = "Solicitud de Chequeras"
        '
        'rdCHQEspecial
        '
        Me.rdCHQEspecial.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdCHQEspecial.AutoSize = True
        Me.rdCHQEspecial.BackColor = System.Drawing.SystemColors.ControlLight
        Me.rdCHQEspecial.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.rdCHQEspecial.FlatAppearance.BorderSize = 2
        Me.rdCHQEspecial.FlatAppearance.CheckedBackColor = System.Drawing.Color.CornflowerBlue
        Me.rdCHQEspecial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdCHQEspecial.Location = New System.Drawing.Point(34, 57)
        Me.rdCHQEspecial.Name = "rdCHQEspecial"
        Me.rdCHQEspecial.Size = New System.Drawing.Size(181, 34)
        Me.rdCHQEspecial.TabIndex = 4
        Me.rdCHQEspecial.Text = "Chequera Especial"
        Me.rdCHQEspecial.UseVisualStyleBackColor = False
        '
        'rdCHQNormal
        '
        Me.rdCHQNormal.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdCHQNormal.AutoSize = True
        Me.rdCHQNormal.BackColor = System.Drawing.SystemColors.ControlLight
        Me.rdCHQNormal.Checked = True
        Me.rdCHQNormal.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdCHQNormal.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.rdCHQNormal.FlatAppearance.BorderSize = 2
        Me.rdCHQNormal.FlatAppearance.CheckedBackColor = System.Drawing.Color.CornflowerBlue
        Me.rdCHQNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdCHQNormal.Location = New System.Drawing.Point(34, 26)
        Me.rdCHQNormal.Name = "rdCHQNormal"
        Me.rdCHQNormal.Size = New System.Drawing.Size(179, 34)
        Me.rdCHQNormal.TabIndex = 3
        Me.rdCHQNormal.TabStop = True
        Me.rdCHQNormal.Text = "Chequera Normal "
        Me.rdCHQNormal.UseVisualStyleBackColor = False
        '
        'btSolicitar
        '
        Me.btSolicitar.Location = New System.Drawing.Point(214, 40)
        Me.btSolicitar.Name = "btSolicitar"
        Me.btSolicitar.Size = New System.Drawing.Size(100, 35)
        Me.btSolicitar.TabIndex = 2
        Me.btSolicitar.Text = "&Solicitar"
        Me.btSolicitar.UseVisualStyleBackColor = True
        '
        'grbDatosCuenta
        '
        Me.grbDatosCuenta.Controls.Add(Me.btBuscar)
        Me.grbDatosCuenta.Controls.Add(Me.txFecha)
        Me.grbDatosCuenta.Controls.Add(Me.txNombre)
        Me.grbDatosCuenta.Controls.Add(Me.txCuenta)
        Me.grbDatosCuenta.Controls.Add(Me.txPrefijo)
        Me.grbDatosCuenta.Controls.Add(Me.dtpFechaFin)
        Me.grbDatosCuenta.Controls.Add(Me.dtpFechaIni)
        Me.grbDatosCuenta.Controls.Add(Me.Label6)
        Me.grbDatosCuenta.Controls.Add(Me.Label2)
        Me.grbDatosCuenta.Controls.Add(Me.Label5)
        Me.grbDatosCuenta.Controls.Add(Me.Label4)
        Me.grbDatosCuenta.Controls.Add(Me.Label3)
        Me.grbDatosCuenta.Controls.Add(Me.Label1)
        Me.grbDatosCuenta.Location = New System.Drawing.Point(12, 12)
        Me.grbDatosCuenta.Name = "grbDatosCuenta"
        Me.grbDatosCuenta.Size = New System.Drawing.Size(911, 98)
        Me.grbDatosCuenta.TabIndex = 3
        Me.grbDatosCuenta.TabStop = False
        '
        'btBuscar
        '
        Me.btBuscar.Location = New System.Drawing.Point(214, 35)
        Me.btBuscar.Name = "btBuscar"
        Me.btBuscar.Size = New System.Drawing.Size(100, 35)
        Me.btBuscar.TabIndex = 12
        Me.btBuscar.Text = "&Buscar"
        Me.btBuscar.UseVisualStyleBackColor = True
        '
        'txFecha
        '
        Me.txFecha.Enabled = False
        Me.txFecha.Location = New System.Drawing.Point(822, 28)
        Me.txFecha.Name = "txFecha"
        Me.txFecha.Size = New System.Drawing.Size(75, 28)
        Me.txFecha.TabIndex = 11
        '
        'txNombre
        '
        Me.txNombre.Enabled = False
        Me.txNombre.Location = New System.Drawing.Point(479, 53)
        Me.txNombre.Name = "txNombre"
        Me.txNombre.Size = New System.Drawing.Size(421, 28)
        Me.txNombre.TabIndex = 10
        '
        'txCuenta
        '
        Me.txCuenta.Enabled = False
        Me.txCuenta.Location = New System.Drawing.Point(549, 26)
        Me.txCuenta.Name = "txCuenta"
        Me.txCuenta.Size = New System.Drawing.Size(65, 28)
        Me.txCuenta.TabIndex = 9
        '
        'txPrefijo
        '
        Me.txPrefijo.Enabled = False
        Me.txPrefijo.Location = New System.Drawing.Point(479, 26)
        Me.txPrefijo.Name = "txPrefijo"
        Me.txPrefijo.Size = New System.Drawing.Size(65, 28)
        Me.txPrefijo.TabIndex = 8
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(87, 53)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(108, 28)
        Me.dtpFechaFin.TabIndex = 7
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIni.Location = New System.Drawing.Point(87, 28)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(108, 28)
        Me.dtpFechaIni.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(780, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 20)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Agencia Houston"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(362, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(175, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Nombre del Cliente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(362, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(171, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Número de Cuenta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha Fin"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Inicio"
        '
        'btLimpiar
        '
        Me.btLimpiar.Location = New System.Drawing.Point(44, 16)
        Me.btLimpiar.Name = "btLimpiar"
        Me.btLimpiar.Size = New System.Drawing.Size(100, 35)
        Me.btLimpiar.TabIndex = 4
        Me.btLimpiar.Text = "&Limpiar"
        Me.btLimpiar.UseVisualStyleBackColor = True
        '
        'btCerrar
        '
        Me.btCerrar.Location = New System.Drawing.Point(213, 16)
        Me.btCerrar.Name = "btCerrar"
        Me.btCerrar.Size = New System.Drawing.Size(100, 35)
        Me.btCerrar.TabIndex = 5
        Me.btCerrar.Text = "&Cerrar"
        Me.btCerrar.UseVisualStyleBackColor = True
        '
        'gvOperaciones
        '
        Me.gvOperaciones.AllowUserToAddRows = False
        Me.gvOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvOperaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.Cuenta, Me.ticket})
        Me.gvOperaciones.Location = New System.Drawing.Point(12, 116)
        Me.gvOperaciones.Name = "gvOperaciones"
        Me.gvOperaciones.ReadOnly = True
        Me.gvOperaciones.RowHeadersWidth = 62
        Me.gvOperaciones.Size = New System.Drawing.Size(347, 159)
        Me.gvOperaciones.TabIndex = 6
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.MinimumWidth = 8
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 150
        '
        'Cuenta
        '
        Me.Cuenta.DataPropertyName = "cuenta_cliente"
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.MinimumWidth = 8
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.ReadOnly = True
        Me.Cuenta.Width = 150
        '
        'ticket
        '
        Me.ticket.DataPropertyName = "operacion"
        Me.ticket.HeaderText = "Ticket"
        Me.ticket.MinimumWidth = 8
        Me.ticket.Name = "ticket"
        Me.ticket.ReadOnly = True
        Me.ticket.Width = 150
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btCerrar)
        Me.GroupBox1.Controls.Add(Me.btLimpiar)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 385)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(345, 61)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'frmConsulCHQApertura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(934, 455)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gvOperaciones)
        Me.Controls.Add(Me.grbDatosCuenta)
        Me.Controls.Add(Me.grbSolicitud)
        Me.Controls.Add(Me.grbCtaDlls)
        Me.Controls.Add(Me.grbCtaPesos)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsulCHQApertura"
        Me.Text = "Consulta de Solicitud de Chequeras Pendientes por Apertura"
        Me.grbCtaPesos.ResumeLayout(False)
        Me.grbCtaPesos.PerformLayout()
        Me.grbCtaDlls.ResumeLayout(False)
        Me.grbCtaDlls.PerformLayout()
        Me.grbSolicitud.ResumeLayout(False)
        Me.grbSolicitud.PerformLayout()
        Me.grbDatosCuenta.ResumeLayout(False)
        Me.grbDatosCuenta.PerformLayout()
        CType(Me.gvOperaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grbCtaPesos As GroupBox
    Friend WithEvents grbCtaDlls As GroupBox
    Friend WithEvents grbSolicitud As GroupBox
    Friend WithEvents grbDatosCuenta As GroupBox
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents dtpFechaIni As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btLimpiar As Button
    Friend WithEvents btCerrar As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txFecha As TextBox
    Friend WithEvents txNombre As TextBox
    Friend WithEvents txCuenta As TextBox
    Friend WithEvents txPrefijo As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents btSolicitar As Button
    Friend WithEvents txNumCtaEje As TextBox
    Friend WithEvents txSucursal As TextBox
    Friend WithEvents txNumSucursal As TextBox
    Friend WithEvents txPlaza As TextBox
    Friend WithEvents txNumPlaza As TextBox
    Friend WithEvents txCR As TextBox
    Friend WithEvents txNumCR As TextBox
    Friend WithEvents txNomGestor As TextBox
    Friend WithEvents txNumGestorP As TextBox
    Friend WithEvents txtCtaDlls As TextBox
    Friend WithEvents txPrefAgencia As TextBox
    Friend WithEvents txSucursalDlls As TextBox
    Friend WithEvents txNumSucDlls As TextBox
    Friend WithEvents txPlazaDlls As TextBox
    Friend WithEvents txNumPlazaDlls As TextBox
    Friend WithEvents txCRDlls As TextBox
    Friend WithEvents txNumCRDlls As TextBox
    Friend WithEvents txNomGestorDlls As TextBox
    Friend WithEvents txNumGestorDlls As TextBox
    Friend WithEvents txSufijo As TextBox
    Friend WithEvents gvOperaciones As DataGridView
    Friend WithEvents btBuscar As Button
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents Cuenta As DataGridViewTextBoxColumn
    Friend WithEvents ticket As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdCHQEspecial As RadioButton
    Friend WithEvents rdCHQNormal As RadioButton
End Class
