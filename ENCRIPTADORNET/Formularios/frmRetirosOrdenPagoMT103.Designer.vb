<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRetirosOrdenPagoMT103
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRetirosOrdenPagoMT103))
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.chkExentarCom = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtCableCBI = New System.Windows.Forms.TextBox()
        Me.TxtABABI = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtRDatos4BC = New System.Windows.Forms.TextBox()
        Me.txtRDatos3BC = New System.Windows.Forms.TextBox()
        Me.txtRDatos2BC = New System.Windows.Forms.TextBox()
        Me.txtRDatos1BC = New System.Windows.Forms.TextBox()
        Me.txtRCuentaBC = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtCableCBC = New System.Windows.Forms.TextBox()
        Me.TxtABABC = New System.Windows.Forms.TextBox()
        Me.Referencia = New System.Windows.Forms.GroupBox()
        Me.txtRef4 = New System.Windows.Forms.TextBox()
        Me.txtRef2 = New System.Windows.Forms.TextBox()
        Me.txtRef3 = New System.Windows.Forms.TextBox()
        Me.txtRef1 = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtDatosAd4 = New System.Windows.Forms.TextBox()
        Me.txtDatosAd3 = New System.Windows.Forms.TextBox()
        Me.txtDatosAd2 = New System.Windows.Forms.TextBox()
        Me.txtDatosAd1 = New System.Windows.Forms.TextBox()
        Me.txtRCuentaBoAP = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmbFuncionario = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFunc = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSaldoTot = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSaldoDep = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.dtpApertura = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmbAgencia = New System.Windows.Forms.ComboBox()
        Me.txtSaldo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFechaOperacion = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaCaptura = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOperacion = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdActualizar = New System.Windows.Forms.Button()
        Me.dgvTicketsPendientes = New System.Windows.Forms.DataGridView()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Referencia.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvTicketsPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardar.Location = New System.Drawing.Point(438, 753)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(137, 40)
        Me.cmdGuardar.TabIndex = 25
        Me.cmdGuardar.Text = "Generar ticket"
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'chkExentarCom
        '
        Me.chkExentarCom.AutoSize = True
        Me.chkExentarCom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkExentarCom.Location = New System.Drawing.Point(364, 319)
        Me.chkExentarCom.Name = "chkExentarCom"
        Me.chkExentarCom.Size = New System.Drawing.Size(173, 26)
        Me.chkExentarCom.TabIndex = 27
        Me.chkExentarCom.Text = "Exentar comisión"
        Me.chkExentarCom.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.TxtCableCBI)
        Me.GroupBox1.Controls.Add(Me.TxtABABI)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(865, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(415, 191)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Banco Intermediario"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 111)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(169, 22)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "Clave Intermediario:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(14, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 22)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "ABA:"
        '
        'TxtCableCBI
        '
        Me.TxtCableCBI.Location = New System.Drawing.Point(18, 136)
        Me.TxtCableCBI.MaxLength = 30
        Me.TxtCableCBI.Name = "TxtCableCBI"
        Me.TxtCableCBI.Size = New System.Drawing.Size(379, 28)
        Me.TxtCableCBI.TabIndex = 1
        '
        'TxtABABI
        '
        Me.TxtABABI.Location = New System.Drawing.Point(18, 65)
        Me.TxtABABI.MaxLength = 9
        Me.TxtABABI.Name = "TxtABABI"
        Me.TxtABABI.Size = New System.Drawing.Size(188, 28)
        Me.TxtABABI.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.txtRDatos4BC)
        Me.GroupBox2.Controls.Add(Me.txtRDatos3BC)
        Me.GroupBox2.Controls.Add(Me.txtRDatos2BC)
        Me.GroupBox2.Controls.Add(Me.txtRDatos1BC)
        Me.GroupBox2.Controls.Add(Me.txtRCuentaBC)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.TxtCableCBC)
        Me.GroupBox2.Controls.Add(Me.TxtABABC)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(865, 222)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(415, 525)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Banco Pagador"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 278)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(145, 22)
        Me.Label21.TabIndex = 9
        Me.Label21.Text = "Datos del banco:"
        '
        'txtRDatos4BC
        '
        Me.txtRDatos4BC.Location = New System.Drawing.Point(18, 475)
        Me.txtRDatos4BC.MaxLength = 30
        Me.txtRDatos4BC.Name = "txtRDatos4BC"
        Me.txtRDatos4BC.Size = New System.Drawing.Size(379, 28)
        Me.txtRDatos4BC.TabIndex = 12
        '
        'txtRDatos3BC
        '
        Me.txtRDatos3BC.Location = New System.Drawing.Point(18, 425)
        Me.txtRDatos3BC.MaxLength = 30
        Me.txtRDatos3BC.Name = "txtRDatos3BC"
        Me.txtRDatos3BC.Size = New System.Drawing.Size(379, 28)
        Me.txtRDatos3BC.TabIndex = 11
        '
        'txtRDatos2BC
        '
        Me.txtRDatos2BC.Location = New System.Drawing.Point(18, 371)
        Me.txtRDatos2BC.MaxLength = 30
        Me.txtRDatos2BC.Name = "txtRDatos2BC"
        Me.txtRDatos2BC.Size = New System.Drawing.Size(379, 28)
        Me.txtRDatos2BC.TabIndex = 10
        '
        'txtRDatos1BC
        '
        Me.txtRDatos1BC.Location = New System.Drawing.Point(18, 308)
        Me.txtRDatos1BC.MaxLength = 30
        Me.txtRDatos1BC.Name = "txtRDatos1BC"
        Me.txtRDatos1BC.Size = New System.Drawing.Size(379, 28)
        Me.txtRDatos1BC.TabIndex = 9
        '
        'txtRCuentaBC
        '
        Me.txtRCuentaBC.Location = New System.Drawing.Point(92, 214)
        Me.txtRCuentaBC.MaxLength = 30
        Me.txtRCuentaBC.Name = "txtRCuentaBC"
        Me.txtRCuentaBC.Size = New System.Drawing.Size(206, 28)
        Me.txtRCuentaBC.TabIndex = 8
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(9, 218)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 22)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "Cuenta:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 111)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(173, 22)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Clave Corresponsal:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 40)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 22)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "ABA:"
        '
        'TxtCableCBC
        '
        Me.TxtCableCBC.Location = New System.Drawing.Point(13, 136)
        Me.TxtCableCBC.MaxLength = 30
        Me.TxtCableCBC.Name = "TxtCableCBC"
        Me.TxtCableCBC.Size = New System.Drawing.Size(384, 28)
        Me.TxtCableCBC.TabIndex = 1
        '
        'TxtABABC
        '
        Me.TxtABABC.Location = New System.Drawing.Point(13, 65)
        Me.TxtABABC.MaxLength = 9
        Me.TxtABABC.Name = "TxtABABC"
        Me.TxtABABC.Size = New System.Drawing.Size(206, 28)
        Me.TxtABABC.TabIndex = 0
        '
        'Referencia
        '
        Me.Referencia.Controls.Add(Me.txtRef4)
        Me.Referencia.Controls.Add(Me.txtRef2)
        Me.Referencia.Controls.Add(Me.txtRef3)
        Me.Referencia.Controls.Add(Me.txtRef1)
        Me.Referencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Referencia.Location = New System.Drawing.Point(438, 423)
        Me.Referencia.Name = "Referencia"
        Me.Referencia.Size = New System.Drawing.Size(414, 324)
        Me.Referencia.TabIndex = 31
        Me.Referencia.TabStop = False
        Me.Referencia.Text = "Referencia"
        '
        'txtRef4
        '
        Me.txtRef4.Location = New System.Drawing.Point(6, 253)
        Me.txtRef4.MaxLength = 30
        Me.txtRef4.Name = "txtRef4"
        Me.txtRef4.Size = New System.Drawing.Size(386, 28)
        Me.txtRef4.TabIndex = 3
        '
        'txtRef2
        '
        Me.txtRef2.Location = New System.Drawing.Point(6, 117)
        Me.txtRef2.MaxLength = 30
        Me.txtRef2.Name = "txtRef2"
        Me.txtRef2.Size = New System.Drawing.Size(386, 28)
        Me.txtRef2.TabIndex = 1
        '
        'txtRef3
        '
        Me.txtRef3.Location = New System.Drawing.Point(6, 186)
        Me.txtRef3.MaxLength = 30
        Me.txtRef3.Name = "txtRef3"
        Me.txtRef3.Size = New System.Drawing.Size(386, 28)
        Me.txtRef3.TabIndex = 2
        '
        'txtRef1
        '
        Me.txtRef1.Location = New System.Drawing.Point(6, 47)
        Me.txtRef1.MaxLength = 30
        Me.txtRef1.Name = "txtRef1"
        Me.txtRef1.Size = New System.Drawing.Size(386, 28)
        Me.txtRef1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.txtDatosAd4)
        Me.GroupBox3.Controls.Add(Me.txtDatosAd3)
        Me.GroupBox3.Controls.Add(Me.txtDatosAd2)
        Me.GroupBox3.Controls.Add(Me.txtDatosAd1)
        Me.GroupBox3.Controls.Add(Me.txtRCuentaBoAP)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(16, 423)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(403, 324)
        Me.GroupBox3.TabIndex = 32
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = " Beneficiario o abono posterior"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(14, 149)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(159, 22)
        Me.Label20.TabIndex = 7
        Me.Label20.Text = "Datos Adicionales:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(14, 77)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(78, 22)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Nombre:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(23, 33)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(73, 22)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Cuenta:"
        '
        'txtDatosAd4
        '
        Me.txtDatosAd4.Location = New System.Drawing.Point(15, 274)
        Me.txtDatosAd4.MaxLength = 30
        Me.txtDatosAd4.Name = "txtDatosAd4"
        Me.txtDatosAd4.Size = New System.Drawing.Size(368, 28)
        Me.txtDatosAd4.TabIndex = 4
        '
        'txtDatosAd3
        '
        Me.txtDatosAd3.Location = New System.Drawing.Point(15, 232)
        Me.txtDatosAd3.MaxLength = 30
        Me.txtDatosAd3.Name = "txtDatosAd3"
        Me.txtDatosAd3.Size = New System.Drawing.Size(368, 28)
        Me.txtDatosAd3.TabIndex = 3
        '
        'txtDatosAd2
        '
        Me.txtDatosAd2.Location = New System.Drawing.Point(15, 186)
        Me.txtDatosAd2.MaxLength = 30
        Me.txtDatosAd2.Name = "txtDatosAd2"
        Me.txtDatosAd2.Size = New System.Drawing.Size(368, 28)
        Me.txtDatosAd2.TabIndex = 2
        '
        'txtDatosAd1
        '
        Me.txtDatosAd1.Location = New System.Drawing.Point(18, 102)
        Me.txtDatosAd1.MaxLength = 30
        Me.txtDatosAd1.Name = "txtDatosAd1"
        Me.txtDatosAd1.Size = New System.Drawing.Size(368, 28)
        Me.txtDatosAd1.TabIndex = 1
        '
        'txtRCuentaBoAP
        '
        Me.txtRCuentaBoAP.Location = New System.Drawing.Point(102, 33)
        Me.txtRCuentaBoAP.MaxLength = 30
        Me.txtRCuentaBoAP.Name = "txtRCuentaBoAP"
        Me.txtRCuentaBoAP.Size = New System.Drawing.Size(204, 28)
        Me.txtRCuentaBoAP.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmbFuncionario)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.txtFunc)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.txtSaldoTot)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txtSaldoDep)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.txtMonto)
        Me.GroupBox4.Controls.Add(Me.dtpApertura)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.CmbAgencia)
        Me.GroupBox4.Controls.Add(Me.txtSaldo)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.dtpFechaOperacion)
        Me.GroupBox4.Controls.Add(Me.dtpFechaCaptura)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.txtCuenta)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.chkExentarCom)
        Me.GroupBox4.Location = New System.Drawing.Point(16, 14)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(836, 390)
        Me.GroupBox4.TabIndex = 33
        Me.GroupBox4.TabStop = False
        '
        'cmbFuncionario
        '
        Me.cmbFuncionario.FormattingEnabled = True
        Me.cmbFuncionario.Location = New System.Drawing.Point(524, 254)
        Me.cmbFuncionario.Name = "cmbFuncionario"
        Me.cmbFuncionario.Size = New System.Drawing.Size(307, 28)
        Me.cmbFuncionario.TabIndex = 51
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(360, 257)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(158, 22)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "Nombre de gestor:"
        '
        'txtFunc
        '
        Me.txtFunc.Enabled = False
        Me.txtFunc.Location = New System.Drawing.Point(174, 256)
        Me.txtFunc.MaxLength = 30
        Me.txtFunc.Name = "txtFunc"
        Me.txtFunc.Size = New System.Drawing.Size(142, 26)
        Me.txtFunc.TabIndex = 47
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 257)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(158, 22)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "Numero de gestor:"
        '
        'txtSaldoTot
        '
        Me.txtSaldoTot.Enabled = False
        Me.txtSaldoTot.Location = New System.Drawing.Point(551, 188)
        Me.txtSaldoTot.Name = "txtSaldoTot"
        Me.txtSaldoTot.Size = New System.Drawing.Size(153, 26)
        Me.txtSaldoTot.TabIndex = 45
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(360, 189)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 22)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "Saldo total:"
        '
        'txtSaldoDep
        '
        Me.txtSaldoDep.Enabled = False
        Me.txtSaldoDep.Location = New System.Drawing.Point(551, 132)
        Me.txtSaldoDep.Name = "txtSaldoDep"
        Me.txtSaldoDep.Size = New System.Drawing.Size(153, 26)
        Me.txtSaldoDep.TabIndex = 43
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(360, 136)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(185, 22)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "Saldo Dep sin validar:"
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(174, 318)
        Me.txtMonto.MaxLength = 30
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(102, 26)
        Me.txtMonto.TabIndex = 41
        '
        'dtpApertura
        '
        Me.dtpApertura.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpApertura.CustomFormat = "dd-MM-yyyy"
        Me.dtpApertura.Enabled = False
        Me.dtpApertura.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpApertura.Location = New System.Drawing.Point(179, 76)
        Me.dtpApertura.Name = "dtpApertura"
        Me.dtpApertura.Size = New System.Drawing.Size(142, 26)
        Me.dtpApertura.TabIndex = 40
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 22)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Fecha apertura:"
        '
        'CmbAgencia
        '
        Me.CmbAgencia.FormattingEnabled = True
        Me.CmbAgencia.Location = New System.Drawing.Point(437, 18)
        Me.CmbAgencia.Name = "CmbAgencia"
        Me.CmbAgencia.Size = New System.Drawing.Size(394, 28)
        Me.CmbAgencia.TabIndex = 38
        '
        'txtSaldo
        '
        Me.txtSaldo.Enabled = False
        Me.txtSaldo.Location = New System.Drawing.Point(551, 76)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Size = New System.Drawing.Size(153, 26)
        Me.txtSaldo.TabIndex = 37
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(360, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(174, 22)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Saldo en cuenta eje:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 319)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 22)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Monto US$:"
        '
        'dtpFechaOperacion
        '
        Me.dtpFechaOperacion.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaOperacion.CustomFormat = "dd-MM-yyyy"
        Me.dtpFechaOperacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaOperacion.Location = New System.Drawing.Point(179, 188)
        Me.dtpFechaOperacion.Name = "dtpFechaOperacion"
        Me.dtpFechaOperacion.Size = New System.Drawing.Size(142, 26)
        Me.dtpFechaOperacion.TabIndex = 34
        '
        'dtpFechaCaptura
        '
        Me.dtpFechaCaptura.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaCaptura.CustomFormat = "dd-MM-yyyy"
        Me.dtpFechaCaptura.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaCaptura.Location = New System.Drawing.Point(179, 133)
        Me.dtpFechaCaptura.Name = "dtpFechaCaptura"
        Me.dtpFechaCaptura.Size = New System.Drawing.Size(142, 26)
        Me.dtpFechaCaptura.TabIndex = 33
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 22)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Fecha valor:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 22)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Fecha captura:"
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(179, 18)
        Me.txtCuenta.MaxLength = 30
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(142, 26)
        Me.txtCuenta.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(360, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 22)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Cliente:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 22)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Numero de cuenta:"
        '
        'txtOperacion
        '
        Me.txtOperacion.Enabled = False
        Me.txtOperacion.Location = New System.Drawing.Point(97, 761)
        Me.txtOperacion.Name = "txtOperacion"
        Me.txtOperacion.Size = New System.Drawing.Size(102, 26)
        Me.txtOperacion.TabIndex = 50
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(27, 762)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 22)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = "Ticket:"
        '
        'cmdSalir
        '
        Me.cmdSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalir.Location = New System.Drawing.Point(1143, 753)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(137, 40)
        Me.cmdSalir.TabIndex = 51
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdActualizar
        '
        Me.cmdActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdActualizar.Location = New System.Drawing.Point(581, 753)
        Me.cmdActualizar.Name = "cmdActualizar"
        Me.cmdActualizar.Size = New System.Drawing.Size(128, 40)
        Me.cmdActualizar.TabIndex = 52
        Me.cmdActualizar.Text = "Actualizar"
        Me.cmdActualizar.UseVisualStyleBackColor = True
        '
        'dgvTicketsPendientes
        '
        Me.dgvTicketsPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTicketsPendientes.Location = New System.Drawing.Point(1299, 22)
        Me.dgvTicketsPendientes.Name = "dgvTicketsPendientes"
        Me.dgvTicketsPendientes.RowHeadersWidth = 62
        Me.dgvTicketsPendientes.RowTemplate.Height = 28
        Me.dgvTicketsPendientes.Size = New System.Drawing.Size(415, 725)
        Me.dgvTicketsPendientes.TabIndex = 53
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(715, 753)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(137, 40)
        Me.cmdCancelar.TabIndex = 54
        Me.cmdCancelar.Text = "Cancelar ticket"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmRetirosOrdenPagoMT103
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1735, 803)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.dgvTicketsPendientes)
        Me.Controls.Add(Me.cmdActualizar)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.txtOperacion)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Referencia)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRetirosOrdenPagoMT103"
        Me.Text = "Captura de retiros por orden de pago MT103"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Referencia.ResumeLayout(False)
        Me.Referencia.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgvTicketsPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents chkExentarCom As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TxtCableCBI As TextBox
    Friend WithEvents TxtABABI As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents TxtCableCBC As TextBox
    Friend WithEvents TxtABABC As TextBox
    Friend WithEvents Referencia As GroupBox
    Friend WithEvents txtRef4 As TextBox
    Friend WithEvents txtRef2 As TextBox
    Friend WithEvents txtRef3 As TextBox
    Friend WithEvents txtRef1 As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtDatosAd4 As TextBox
    Friend WithEvents txtDatosAd3 As TextBox
    Friend WithEvents txtDatosAd2 As TextBox
    Friend WithEvents txtDatosAd1 As TextBox
    Friend WithEvents txtRCuentaBoAP As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtRDatos4BC As TextBox
    Friend WithEvents txtRDatos3BC As TextBox
    Friend WithEvents txtRDatos2BC As TextBox
    Friend WithEvents txtRDatos1BC As TextBox
    Friend WithEvents txtRCuentaBC As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents cmbFuncionario As ComboBox
    Friend WithEvents txtOperacion As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtFunc As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtSaldoTot As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtSaldoDep As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents dtpApertura As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents CmbAgencia As ComboBox
    Friend WithEvents txtSaldo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpFechaOperacion As DateTimePicker
    Friend WithEvents dtpFechaCaptura As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCuenta As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents cmdSalir As Button
    Friend WithEvents cmdActualizar As Button
    Friend WithEvents dgvTicketsPendientes As DataGridView
    Friend WithEvents cmdCancelar As Button
End Class
