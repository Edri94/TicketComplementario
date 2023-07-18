<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCancelarCHQ
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancelarCHQ))
        Me.grbCtaPesos = New System.Windows.Forms.GroupBox()
        Me.txNumCtaEje = New System.Windows.Forms.TextBox()
        Me.txSucursal = New System.Windows.Forms.TextBox()
        Me.txNumSucursal = New System.Windows.Forms.TextBox()
        Me.txCR = New System.Windows.Forms.TextBox()
        Me.txNumCR = New System.Windows.Forms.TextBox()
        Me.txNumGestor = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.grbCtaDlls = New System.Windows.Forms.GroupBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txUltimoCHQ = New System.Windows.Forms.TextBox()
        Me.txFolioFin = New System.Windows.Forms.TextBox()
        Me.txFolioIni = New System.Windows.Forms.TextBox()
        Me.txRegistro = New System.Windows.Forms.TextBox()
        Me.txNumCheques = New System.Windows.Forms.TextBox()
        Me.txSucursalSol = New System.Windows.Forms.TextBox()
        Me.txNumSucSol = New System.Windows.Forms.TextBox()
        Me.txCRSol = New System.Windows.Forms.TextBox()
        Me.txNumCRSol = New System.Windows.Forms.TextBox()
        Me.txNomGestorSol = New System.Windows.Forms.TextBox()
        Me.txNumGestorSol = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.grbDatosCuenta = New System.Windows.Forms.GroupBox()
        Me.txFecha = New System.Windows.Forms.TextBox()
        Me.txNombre = New System.Windows.Forms.TextBox()
        Me.txCuenta = New System.Windows.Forms.TextBox()
        Me.txPrefijo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btBuscar = New System.Windows.Forms.Button()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.btCerrar = New System.Windows.Forms.Button()
        Me.gvOperaciones = New System.Windows.Forms.DataGridView()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Chequera = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cheques = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbFecha = New System.Windows.Forms.CheckBox()
        Me.cbCuenta = New System.Windows.Forms.CheckBox()
        Me.txCuentaFin = New System.Windows.Forms.TextBox()
        Me.txCuentaIni = New System.Windows.Forms.TextBox()
        Me.btCancelar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txMotivo = New System.Windows.Forms.TextBox()
        Me.lbMotivo = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.grbCtaPesos.SuspendLayout()
        Me.grbCtaDlls.SuspendLayout()
        Me.grbDatosCuenta.SuspendLayout()
        CType(Me.gvOperaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbCtaPesos
        '
        Me.grbCtaPesos.Controls.Add(Me.txNumCtaEje)
        Me.grbCtaPesos.Controls.Add(Me.txSucursal)
        Me.grbCtaPesos.Controls.Add(Me.txNumSucursal)
        Me.grbCtaPesos.Controls.Add(Me.txCR)
        Me.grbCtaPesos.Controls.Add(Me.txNumCR)
        Me.grbCtaPesos.Controls.Add(Me.txNumGestor)
        Me.grbCtaPesos.Controls.Add(Me.Label11)
        Me.grbCtaPesos.Controls.Add(Me.Label10)
        Me.grbCtaPesos.Controls.Add(Me.Label8)
        Me.grbCtaPesos.Controls.Add(Me.Label7)
        Me.grbCtaPesos.Location = New System.Drawing.Point(369, 116)
        Me.grbCtaPesos.Name = "grbCtaPesos"
        Me.grbCtaPesos.Size = New System.Drawing.Size(554, 137)
        Me.grbCtaPesos.TabIndex = 0
        Me.grbCtaPesos.TabStop = False
        Me.grbCtaPesos.Text = "Gestor Apertura (envio)"
        '
        'txNumCtaEje
        '
        Me.txNumCtaEje.Enabled = False
        Me.txNumCtaEje.Location = New System.Drawing.Point(121, 103)
        Me.txNumCtaEje.Name = "txNumCtaEje"
        Me.txNumCtaEje.Size = New System.Drawing.Size(93, 21)
        Me.txNumCtaEje.TabIndex = 14
        '
        'txSucursal
        '
        Me.txSucursal.Enabled = False
        Me.txSucursal.Location = New System.Drawing.Point(192, 77)
        Me.txSucursal.Name = "txSucursal"
        Me.txSucursal.Size = New System.Drawing.Size(348, 21)
        Me.txSucursal.TabIndex = 13
        '
        'txNumSucursal
        '
        Me.txNumSucursal.Enabled = False
        Me.txNumSucursal.Location = New System.Drawing.Point(121, 77)
        Me.txNumSucursal.Name = "txNumSucursal"
        Me.txNumSucursal.Size = New System.Drawing.Size(65, 21)
        Me.txNumSucursal.TabIndex = 12
        '
        'txCR
        '
        Me.txCR.Enabled = False
        Me.txCR.Location = New System.Drawing.Point(192, 50)
        Me.txCR.Name = "txCR"
        Me.txCR.Size = New System.Drawing.Size(348, 21)
        Me.txCR.TabIndex = 9
        '
        'txNumCR
        '
        Me.txNumCR.Enabled = False
        Me.txNumCR.Location = New System.Drawing.Point(121, 50)
        Me.txNumCR.Name = "txNumCR"
        Me.txNumCR.Size = New System.Drawing.Size(65, 21)
        Me.txNumCR.TabIndex = 8
        '
        'txNumGestor
        '
        Me.txNumGestor.Enabled = False
        Me.txNumGestor.Location = New System.Drawing.Point(121, 24)
        Me.txNumGestor.Name = "txNumGestor"
        Me.txNumGestor.Size = New System.Drawing.Size(65, 21)
        Me.txNumGestor.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 106)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Cuenta Eje Pesos"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(63, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Sucursal"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Centro Regional"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(73, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Gestor"
        '
        'grbCtaDlls
        '
        Me.grbCtaDlls.Controls.Add(Me.lblTipo)
        Me.grbCtaDlls.Controls.Add(Me.Label19)
        Me.grbCtaDlls.Controls.Add(Me.Label18)
        Me.grbCtaDlls.Controls.Add(Me.Label17)
        Me.grbCtaDlls.Controls.Add(Me.Label15)
        Me.grbCtaDlls.Controls.Add(Me.Label9)
        Me.grbCtaDlls.Controls.Add(Me.txUltimoCHQ)
        Me.grbCtaDlls.Controls.Add(Me.txFolioFin)
        Me.grbCtaDlls.Controls.Add(Me.txFolioIni)
        Me.grbCtaDlls.Controls.Add(Me.txRegistro)
        Me.grbCtaDlls.Controls.Add(Me.txNumCheques)
        Me.grbCtaDlls.Controls.Add(Me.txSucursalSol)
        Me.grbCtaDlls.Controls.Add(Me.txNumSucSol)
        Me.grbCtaDlls.Controls.Add(Me.txCRSol)
        Me.grbCtaDlls.Controls.Add(Me.txNumCRSol)
        Me.grbCtaDlls.Controls.Add(Me.txNomGestorSol)
        Me.grbCtaDlls.Controls.Add(Me.txNumGestorSol)
        Me.grbCtaDlls.Controls.Add(Me.Label16)
        Me.grbCtaDlls.Controls.Add(Me.Label14)
        Me.grbCtaDlls.Controls.Add(Me.Label13)
        Me.grbCtaDlls.Location = New System.Drawing.Point(369, 259)
        Me.grbCtaDlls.Name = "grbCtaDlls"
        Me.grbCtaDlls.Size = New System.Drawing.Size(554, 183)
        Me.grbCtaDlls.TabIndex = 1
        Me.grbCtaDlls.TabStop = False
        Me.grbCtaDlls.Text = "Datos de Solicitud"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(364, 17)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(176, 13)
        Me.lblTipo.TabIndex = 28
        Me.lblTipo.Text = "Chequera de 500 Cheques"
        Me.lblTipo.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(346, 151)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(127, 13)
        Me.Label19.TabIndex = 27
        Me.Label19.Text = "N° Último de Cheque"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(192, 151)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(14, 13)
        Me.Label18.TabIndex = 26
        Me.Label18.Text = "a"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(384, 126)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 13)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "N° de Registro"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(85, 151)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 13)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Folio"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 123)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "N° de Chequera"
        '
        'txUltimoCHQ
        '
        Me.txUltimoCHQ.Enabled = False
        Me.txUltimoCHQ.Location = New System.Drawing.Point(475, 151)
        Me.txUltimoCHQ.Name = "txUltimoCHQ"
        Me.txUltimoCHQ.Size = New System.Drawing.Size(65, 21)
        Me.txUltimoCHQ.TabIndex = 22
        '
        'txFolioFin
        '
        Me.txFolioFin.Enabled = False
        Me.txFolioFin.Location = New System.Drawing.Point(213, 152)
        Me.txFolioFin.Name = "txFolioFin"
        Me.txFolioFin.Size = New System.Drawing.Size(65, 21)
        Me.txFolioFin.TabIndex = 21
        '
        'txFolioIni
        '
        Me.txFolioIni.Enabled = False
        Me.txFolioIni.Location = New System.Drawing.Point(121, 152)
        Me.txFolioIni.Name = "txFolioIni"
        Me.txFolioIni.Size = New System.Drawing.Size(65, 21)
        Me.txFolioIni.TabIndex = 20
        '
        'txRegistro
        '
        Me.txRegistro.Enabled = False
        Me.txRegistro.Location = New System.Drawing.Point(475, 123)
        Me.txRegistro.Name = "txRegistro"
        Me.txRegistro.Size = New System.Drawing.Size(65, 21)
        Me.txRegistro.TabIndex = 19
        '
        'txNumCheques
        '
        Me.txNumCheques.Enabled = False
        Me.txNumCheques.Location = New System.Drawing.Point(121, 123)
        Me.txNumCheques.Name = "txNumCheques"
        Me.txNumCheques.Size = New System.Drawing.Size(65, 21)
        Me.txNumCheques.TabIndex = 18
        '
        'txSucursalSol
        '
        Me.txSucursalSol.Enabled = False
        Me.txSucursalSol.Location = New System.Drawing.Point(193, 94)
        Me.txSucursalSol.Name = "txSucursalSol"
        Me.txSucursalSol.Size = New System.Drawing.Size(348, 21)
        Me.txSucursalSol.TabIndex = 13
        '
        'txNumSucSol
        '
        Me.txNumSucSol.Enabled = False
        Me.txNumSucSol.Location = New System.Drawing.Point(121, 94)
        Me.txNumSucSol.Name = "txNumSucSol"
        Me.txNumSucSol.Size = New System.Drawing.Size(65, 21)
        Me.txNumSucSol.TabIndex = 12
        '
        'txCRSol
        '
        Me.txCRSol.Enabled = False
        Me.txCRSol.Location = New System.Drawing.Point(192, 65)
        Me.txCRSol.Name = "txCRSol"
        Me.txCRSol.Size = New System.Drawing.Size(348, 21)
        Me.txCRSol.TabIndex = 9
        '
        'txNumCRSol
        '
        Me.txNumCRSol.Enabled = False
        Me.txNumCRSol.Location = New System.Drawing.Point(121, 65)
        Me.txNumCRSol.Name = "txNumCRSol"
        Me.txNumCRSol.Size = New System.Drawing.Size(65, 21)
        Me.txNumCRSol.TabIndex = 8
        '
        'txNomGestorSol
        '
        Me.txNomGestorSol.Enabled = False
        Me.txNomGestorSol.Location = New System.Drawing.Point(192, 36)
        Me.txNomGestorSol.Name = "txNomGestorSol"
        Me.txNomGestorSol.Size = New System.Drawing.Size(348, 21)
        Me.txNomGestorSol.TabIndex = 7
        '
        'txNumGestorSol
        '
        Me.txNumGestorSol.Enabled = False
        Me.txNumGestorSol.Location = New System.Drawing.Point(121, 36)
        Me.txNumGestorSol.Name = "txNumGestorSol"
        Me.txNumGestorSol.Size = New System.Drawing.Size(65, 21)
        Me.txNumGestorSol.TabIndex = 6
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(62, 95)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 13)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Sucursal"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(19, 67)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Centro Regional"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(75, 39)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Gestor"
        '
        'grbDatosCuenta
        '
        Me.grbDatosCuenta.Controls.Add(Me.txFecha)
        Me.grbDatosCuenta.Controls.Add(Me.txNombre)
        Me.grbDatosCuenta.Controls.Add(Me.txCuenta)
        Me.grbDatosCuenta.Controls.Add(Me.txPrefijo)
        Me.grbDatosCuenta.Controls.Add(Me.Label6)
        Me.grbDatosCuenta.Controls.Add(Me.Label5)
        Me.grbDatosCuenta.Controls.Add(Me.Label4)
        Me.grbDatosCuenta.Location = New System.Drawing.Point(369, 12)
        Me.grbDatosCuenta.Name = "grbDatosCuenta"
        Me.grbDatosCuenta.Size = New System.Drawing.Size(553, 98)
        Me.grbDatosCuenta.TabIndex = 3
        Me.grbDatosCuenta.TabStop = False
        Me.grbDatosCuenta.Text = "Datos de la Cuenta"
        '
        'txFecha
        '
        Me.txFecha.Enabled = False
        Me.txFecha.Location = New System.Drawing.Point(449, 29)
        Me.txFecha.Name = "txFecha"
        Me.txFecha.Size = New System.Drawing.Size(96, 21)
        Me.txFecha.TabIndex = 11
        '
        'txNombre
        '
        Me.txNombre.Enabled = False
        Me.txNombre.Location = New System.Drawing.Point(124, 54)
        Me.txNombre.Name = "txNombre"
        Me.txNombre.Size = New System.Drawing.Size(421, 21)
        Me.txNombre.TabIndex = 10
        '
        'txCuenta
        '
        Me.txCuenta.Enabled = False
        Me.txCuenta.Location = New System.Drawing.Point(194, 29)
        Me.txCuenta.Name = "txCuenta"
        Me.txCuenta.Size = New System.Drawing.Size(65, 21)
        Me.txCuenta.TabIndex = 9
        '
        'txPrefijo
        '
        Me.txPrefijo.Enabled = False
        Me.txPrefijo.Location = New System.Drawing.Point(123, 29)
        Me.txPrefijo.Name = "txPrefijo"
        Me.txPrefijo.Size = New System.Drawing.Size(65, 21)
        Me.txPrefijo.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(403, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Nombre del Cliente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Número de Cuenta"
        '
        'btBuscar
        '
        Me.btBuscar.Location = New System.Drawing.Point(230, 104)
        Me.btBuscar.Name = "btBuscar"
        Me.btBuscar.Size = New System.Drawing.Size(100, 35)
        Me.btBuscar.TabIndex = 12
        Me.btBuscar.Text = "&Buscar"
        Me.btBuscar.UseVisualStyleBackColor = True
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(239, 66)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(91, 21)
        Me.dtpFechaFin.TabIndex = 7
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIni.Location = New System.Drawing.Point(126, 66)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(87, 21)
        Me.dtpFechaIni.TabIndex = 6
        '
        'btCerrar
        '
        Me.btCerrar.Location = New System.Drawing.Point(227, 20)
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
        Me.gvOperaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.Cuenta, Me.Chequera, Me.Cheques})
        Me.gvOperaciones.Location = New System.Drawing.Point(11, 189)
        Me.gvOperaciones.Name = "gvOperaciones"
        Me.gvOperaciones.ReadOnly = True
        Me.gvOperaciones.Size = New System.Drawing.Size(347, 253)
        Me.gvOperaciones.TabIndex = 6
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'Cuenta
        '
        Me.Cuenta.DataPropertyName = "cuenta_cliente"
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.ReadOnly = True
        '
        'Chequera
        '
        Me.Chequera.DataPropertyName = "chequera"
        Me.Chequera.HeaderText = "Chequera"
        Me.Chequera.Name = "Chequera"
        Me.Chequera.ReadOnly = True
        '
        'Cheques
        '
        Me.Cheques.DataPropertyName = "total_cheques"
        Me.Cheques.HeaderText = "Total Cheques"
        Me.Cheques.Name = "Cheques"
        Me.Cheques.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbFecha)
        Me.GroupBox1.Controls.Add(Me.btBuscar)
        Me.GroupBox1.Controls.Add(Me.cbCuenta)
        Me.GroupBox1.Controls.Add(Me.txCuentaFin)
        Me.GroupBox1.Controls.Add(Me.txCuentaIni)
        Me.GroupBox1.Controls.Add(Me.dtpFechaIni)
        Me.GroupBox1.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(345, 161)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(219, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "a"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(219, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "a"
        '
        'cbFecha
        '
        Me.cbFecha.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbFecha.AutoSize = True
        Me.cbFecha.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cbFecha.Checked = True
        Me.cbFecha.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbFecha.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cbFecha.FlatAppearance.BorderSize = 2
        Me.cbFecha.FlatAppearance.CheckedBackColor = System.Drawing.Color.CornflowerBlue
        Me.cbFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbFecha.Location = New System.Drawing.Point(10, 67)
        Me.cbFecha.Name = "cbFecha"
        Me.cbFecha.Size = New System.Drawing.Size(102, 23)
        Me.cbFecha.TabIndex = 16
        Me.cbFecha.Text = "     Fecha        "
        Me.cbFecha.UseVisualStyleBackColor = False
        '
        'cbCuenta
        '
        Me.cbCuenta.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbCuenta.AutoSize = True
        Me.cbCuenta.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cbCuenta.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cbCuenta.FlatAppearance.BorderSize = 2
        Me.cbCuenta.FlatAppearance.CheckedBackColor = System.Drawing.Color.CornflowerBlue
        Me.cbCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbCuenta.Location = New System.Drawing.Point(10, 29)
        Me.cbCuenta.Name = "cbCuenta"
        Me.cbCuenta.Size = New System.Drawing.Size(102, 23)
        Me.cbCuenta.TabIndex = 15
        Me.cbCuenta.Text = "     Cuenta      "
        Me.cbCuenta.UseVisualStyleBackColor = False
        '
        'txCuentaFin
        '
        Me.txCuentaFin.Enabled = False
        Me.txCuentaFin.Location = New System.Drawing.Point(239, 30)
        Me.txCuentaFin.Name = "txCuentaFin"
        Me.txCuentaFin.Size = New System.Drawing.Size(91, 21)
        Me.txCuentaFin.TabIndex = 14
        '
        'txCuentaIni
        '
        Me.txCuentaIni.Enabled = False
        Me.txCuentaIni.Location = New System.Drawing.Point(126, 29)
        Me.txCuentaIni.Name = "txCuentaIni"
        Me.txCuentaIni.Size = New System.Drawing.Size(87, 21)
        Me.txCuentaIni.TabIndex = 13
        '
        'btCancelar
        '
        Me.btCancelar.Location = New System.Drawing.Point(19, 19)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(100, 35)
        Me.btCancelar.TabIndex = 8
        Me.btCancelar.Text = "&Cancelar"
        Me.btCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txMotivo)
        Me.GroupBox2.Controls.Add(Me.lbMotivo)
        Me.GroupBox2.Location = New System.Drawing.Point(369, 448)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(554, 67)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        '
        'txMotivo
        '
        Me.txMotivo.Location = New System.Drawing.Point(121, 27)
        Me.txMotivo.Name = "txMotivo"
        Me.txMotivo.Size = New System.Drawing.Size(420, 21)
        Me.txMotivo.TabIndex = 1
        '
        'lbMotivo
        '
        Me.lbMotivo.AutoSize = True
        Me.lbMotivo.Location = New System.Drawing.Point(1, 30)
        Me.lbMotivo.Name = "lbMotivo"
        Me.lbMotivo.Size = New System.Drawing.Size(117, 13)
        Me.lbMotivo.TabIndex = 0
        Me.lbMotivo.Text = "Motivo Cancelación"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btCancelar)
        Me.GroupBox3.Controls.Add(Me.btCerrar)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 448)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(341, 67)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        '
        'frmCancelarCHQ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(934, 527)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gvOperaciones)
        Me.Controls.Add(Me.grbDatosCuenta)
        Me.Controls.Add(Me.grbCtaDlls)
        Me.Controls.Add(Me.grbCtaPesos)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCancelarCHQ"
        Me.Text = "Cancelacion de Solicitud de Chequeras"
        Me.grbCtaPesos.ResumeLayout(False)
        Me.grbCtaPesos.PerformLayout()
        Me.grbCtaDlls.ResumeLayout(False)
        Me.grbCtaDlls.PerformLayout()
        Me.grbDatosCuenta.ResumeLayout(False)
        Me.grbDatosCuenta.PerformLayout()
        CType(Me.gvOperaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grbCtaPesos As GroupBox
    Friend WithEvents grbCtaDlls As GroupBox
    Friend WithEvents grbDatosCuenta As GroupBox
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents dtpFechaIni As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btCerrar As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txFecha As TextBox
    Friend WithEvents txNombre As TextBox
    Friend WithEvents txCuenta As TextBox
    Friend WithEvents txPrefijo As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txNumCtaEje As TextBox
    Friend WithEvents txSucursal As TextBox
    Friend WithEvents txNumSucursal As TextBox
    Friend WithEvents txCR As TextBox
    Friend WithEvents txNumCR As TextBox
    Friend WithEvents txNumGestor As TextBox
    Friend WithEvents txSucursalSol As TextBox
    Friend WithEvents txNumSucSol As TextBox
    Friend WithEvents txCRSol As TextBox
    Friend WithEvents txNumCRSol As TextBox
    Friend WithEvents txNomGestorSol As TextBox
    Friend WithEvents txNumGestorSol As TextBox
    Friend WithEvents gvOperaciones As DataGridView
    Friend WithEvents btBuscar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btCancelar As Button
    Friend WithEvents txUltimoCHQ As TextBox
    Friend WithEvents txFolioFin As TextBox
    Friend WithEvents txFolioIni As TextBox
    Friend WithEvents txRegistro As TextBox
    Friend WithEvents txNumCheques As TextBox
    Friend WithEvents txCuentaFin As TextBox
    Friend WithEvents txCuentaIni As TextBox
    Friend WithEvents cbFecha As CheckBox
    Friend WithEvents cbCuenta As CheckBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txMotivo As TextBox
    Friend WithEvents lbMotivo As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents Cuenta As DataGridViewTextBoxColumn
    Friend WithEvents Chequera As DataGridViewTextBoxColumn
    Friend WithEvents Cheques As DataGridViewTextBoxColumn
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTipo As Label
End Class
