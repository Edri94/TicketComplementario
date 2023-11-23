<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Consultaret
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFuncionario = New System.Windows.Forms.TextBox()
        Me.pnlCancelada = New System.Windows.Forms.Button()
        Me.lblStatusSw = New System.Windows.Forms.TextBox()
        Me.lblStatusOp = New System.Windows.Forms.TextBox()
        Me.txtNumFuncionario = New System.Windows.Forms.TextBox()
        Me.txtUsuarioCapt = New System.Windows.Forms.TextBox()
        Me.txtSaldo = New System.Windows.Forms.TextBox()
        Me.txtFechaCaptura = New System.Windows.Forms.TextBox()
        Me.lblGrabadora = New System.Windows.Forms.TextBox()
        Me.txtLinea = New System.Windows.Forms.TextBox()
        Me.txtFechaOperacion = New System.Windows.Forms.TextBox()
        Me.txtNumCuenta = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtNumOperacion = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblUniGes = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtSucursalPME = New System.Windows.Forms.TextBox()
        Me.txtPlazaPME = New System.Windows.Forms.TextBox()
        Me.txtCRPME = New System.Windows.Forms.TextBox()
        Me.txtNumCRPME = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtNoCheque = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtTipoMoneda = New System.Windows.Forms.TextBox()
        Me.txtCedRet = New System.Windows.Forms.TextBox()
        Me.txtTipoDocumento = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblNumSuc = New System.Windows.Forms.TextBox()
        Me.txtCausaPME = New System.Windows.Forms.TextBox()
        Me.lblNumPlaza = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmdCierra = New System.Windows.Forms.Button()
        Me.cmdAutorizacion = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFuncionario)
        Me.GroupBox1.Controls.Add(Me.pnlCancelada)
        Me.GroupBox1.Controls.Add(Me.lblStatusSw)
        Me.GroupBox1.Controls.Add(Me.lblStatusOp)
        Me.GroupBox1.Controls.Add(Me.txtNumFuncionario)
        Me.GroupBox1.Controls.Add(Me.txtUsuarioCapt)
        Me.GroupBox1.Controls.Add(Me.txtSaldo)
        Me.GroupBox1.Controls.Add(Me.txtFechaCaptura)
        Me.GroupBox1.Controls.Add(Me.lblGrabadora)
        Me.GroupBox1.Controls.Add(Me.txtLinea)
        Me.GroupBox1.Controls.Add(Me.txtFechaOperacion)
        Me.GroupBox1.Controls.Add(Me.txtNumCuenta)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtMonto)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtNumOperacion)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1253, 274)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle del Retiro"
        '
        'txtFuncionario
        '
        Me.txtFuncionario.Location = New System.Drawing.Point(300, 220)
        Me.txtFuncionario.Name = "txtFuncionario"
        Me.txtFuncionario.Size = New System.Drawing.Size(371, 26)
        Me.txtFuncionario.TabIndex = 3
        '
        'pnlCancelada
        '
        Me.pnlCancelada.Location = New System.Drawing.Point(1046, 119)
        Me.pnlCancelada.Name = "pnlCancelada"
        Me.pnlCancelada.Size = New System.Drawing.Size(182, 40)
        Me.pnlCancelada.TabIndex = 2
        Me.pnlCancelada.Text = "Operacion Cancelada"
        Me.pnlCancelada.UseVisualStyleBackColor = True
        '
        'lblStatusSw
        '
        Me.lblStatusSw.Location = New System.Drawing.Point(677, 133)
        Me.lblStatusSw.Name = "lblStatusSw"
        Me.lblStatusSw.Size = New System.Drawing.Size(204, 26)
        Me.lblStatusSw.TabIndex = 1
        '
        'lblStatusOp
        '
        Me.lblStatusOp.Location = New System.Drawing.Point(677, 97)
        Me.lblStatusOp.Name = "lblStatusOp"
        Me.lblStatusOp.Size = New System.Drawing.Size(204, 26)
        Me.lblStatusOp.TabIndex = 1
        '
        'txtNumFuncionario
        '
        Me.txtNumFuncionario.Location = New System.Drawing.Point(171, 220)
        Me.txtNumFuncionario.Name = "txtNumFuncionario"
        Me.txtNumFuncionario.Size = New System.Drawing.Size(123, 26)
        Me.txtNumFuncionario.TabIndex = 1
        '
        'txtUsuarioCapt
        '
        Me.txtUsuarioCapt.Location = New System.Drawing.Point(171, 182)
        Me.txtUsuarioCapt.Name = "txtUsuarioCapt"
        Me.txtUsuarioCapt.Size = New System.Drawing.Size(500, 26)
        Me.txtUsuarioCapt.TabIndex = 1
        '
        'txtSaldo
        '
        Me.txtSaldo.Location = New System.Drawing.Point(171, 144)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Size = New System.Drawing.Size(204, 26)
        Me.txtSaldo.TabIndex = 1
        '
        'txtFechaCaptura
        '
        Me.txtFechaCaptura.Location = New System.Drawing.Point(171, 106)
        Me.txtFechaCaptura.Name = "txtFechaCaptura"
        Me.txtFechaCaptura.Size = New System.Drawing.Size(204, 26)
        Me.txtFechaCaptura.TabIndex = 1
        '
        'lblGrabadora
        '
        Me.lblGrabadora.Location = New System.Drawing.Point(1149, 60)
        Me.lblGrabadora.Name = "lblGrabadora"
        Me.lblGrabadora.Size = New System.Drawing.Size(79, 26)
        Me.lblGrabadora.TabIndex = 1
        '
        'txtLinea
        '
        Me.txtLinea.Location = New System.Drawing.Point(1149, 24)
        Me.txtLinea.Name = "txtLinea"
        Me.txtLinea.Size = New System.Drawing.Size(79, 26)
        Me.txtLinea.TabIndex = 1
        '
        'txtFechaOperacion
        '
        Me.txtFechaOperacion.Location = New System.Drawing.Point(677, 61)
        Me.txtFechaOperacion.Name = "txtFechaOperacion"
        Me.txtFechaOperacion.Size = New System.Drawing.Size(204, 26)
        Me.txtFechaOperacion.TabIndex = 1
        '
        'txtNumCuenta
        '
        Me.txtNumCuenta.Location = New System.Drawing.Point(677, 25)
        Me.txtNumCuenta.Name = "txtNumCuenta"
        Me.txtNumCuenta.Size = New System.Drawing.Size(204, 26)
        Me.txtNumCuenta.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(514, 130)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 20)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Status Swift:"
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(171, 70)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(204, 26)
        Me.txtMonto.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(514, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Status Equation:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(1052, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 20)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Grabadora:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 223)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 20)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Gestor:"
        '
        'txtNumOperacion
        '
        Me.txtNumOperacion.Location = New System.Drawing.Point(171, 34)
        Me.txtNumOperacion.Name = "txtNumOperacion"
        Me.txtNumOperacion.Size = New System.Drawing.Size(204, 26)
        Me.txtNumOperacion.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 185)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(157, 20)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Usuario que capturo:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(514, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(157, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fecha de Operacion:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 147)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(132, 20)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Saldo en Cuenta:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(1052, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 20)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Linea:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Fecha de captura:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(514, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Numero de Cuenta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Monto del retiro:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ticket:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblUniGes)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.txtDescripcion)
        Me.GroupBox2.Controls.Add(Me.txtSucursalPME)
        Me.GroupBox2.Controls.Add(Me.txtPlazaPME)
        Me.GroupBox2.Controls.Add(Me.txtCRPME)
        Me.GroupBox2.Controls.Add(Me.txtNumCRPME)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtNoCheque)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtTipoMoneda)
        Me.GroupBox2.Controls.Add(Me.txtCedRet)
        Me.GroupBox2.Controls.Add(Me.txtTipoDocumento)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.lblNumSuc)
        Me.GroupBox2.Controls.Add(Me.txtCausaPME)
        Me.GroupBox2.Controls.Add(Me.lblNumPlaza)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 310)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1253, 306)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'lblUniGes
        '
        Me.lblUniGes.Location = New System.Drawing.Point(1148, 246)
        Me.lblUniGes.Name = "lblUniGes"
        Me.lblUniGes.Size = New System.Drawing.Size(89, 26)
        Me.lblUniGes.TabIndex = 3
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(1050, 249)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(91, 20)
        Me.Label26.TabIndex = 2
        Me.Label26.Text = "U. Gestora:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(661, 210)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(576, 26)
        Me.txtDescripcion.TabIndex = 1
        '
        'txtSucursalPME
        '
        Me.txtSucursalPME.Location = New System.Drawing.Point(285, 132)
        Me.txtSucursalPME.Name = "txtSucursalPME"
        Me.txtSucursalPME.Size = New System.Drawing.Size(386, 26)
        Me.txtSucursalPME.TabIndex = 1
        '
        'txtPlazaPME
        '
        Me.txtPlazaPME.Location = New System.Drawing.Point(285, 94)
        Me.txtPlazaPME.Name = "txtPlazaPME"
        Me.txtPlazaPME.Size = New System.Drawing.Size(386, 26)
        Me.txtPlazaPME.TabIndex = 1
        '
        'txtCRPME
        '
        Me.txtCRPME.Location = New System.Drawing.Point(286, 58)
        Me.txtCRPME.Name = "txtCRPME"
        Me.txtCRPME.Size = New System.Drawing.Size(385, 26)
        Me.txtCRPME.TabIndex = 1
        '
        'txtNumCRPME
        '
        Me.txtNumCRPME.Location = New System.Drawing.Point(190, 58)
        Me.txtNumCRPME.Name = "txtNumCRPME"
        Me.txtNumCRPME.Size = New System.Drawing.Size(89, 26)
        Me.txtNumCRPME.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(35, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 20)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Causa:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(35, 61)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 20)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "C.R.:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(35, 97)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 20)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Plaza:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(35, 252)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(127, 20)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Tipo de Moneda:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(35, 213)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(152, 20)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Tipo de Documento:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(35, 135)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(75, 20)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Sucursal:"
        '
        'txtNoCheque
        '
        Me.txtNoCheque.Location = New System.Drawing.Point(582, 173)
        Me.txtNoCheque.Name = "txtNoCheque"
        Me.txtNoCheque.Size = New System.Drawing.Size(89, 26)
        Me.txtNoCheque.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(457, 176)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(119, 20)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "No. de Cheque:"
        '
        'txtTipoMoneda
        '
        Me.txtTipoMoneda.Location = New System.Drawing.Point(190, 249)
        Me.txtTipoMoneda.Name = "txtTipoMoneda"
        Me.txtTipoMoneda.Size = New System.Drawing.Size(452, 26)
        Me.txtTipoMoneda.TabIndex = 1
        '
        'txtCedRet
        '
        Me.txtCedRet.Location = New System.Drawing.Point(190, 170)
        Me.txtCedRet.Name = "txtCedRet"
        Me.txtCedRet.Size = New System.Drawing.Size(89, 26)
        Me.txtCedRet.TabIndex = 1
        '
        'txtTipoDocumento
        '
        Me.txtTipoDocumento.Location = New System.Drawing.Point(190, 210)
        Me.txtTipoDocumento.Name = "txtTipoDocumento"
        Me.txtTipoDocumento.Size = New System.Drawing.Size(452, 26)
        Me.txtTipoDocumento.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(35, 173)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(148, 20)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Num. de Ficha Ced:"
        '
        'lblNumSuc
        '
        Me.lblNumSuc.Location = New System.Drawing.Point(190, 132)
        Me.lblNumSuc.Name = "lblNumSuc"
        Me.lblNumSuc.Size = New System.Drawing.Size(89, 26)
        Me.lblNumSuc.TabIndex = 1
        '
        'txtCausaPME
        '
        Me.txtCausaPME.Location = New System.Drawing.Point(190, 22)
        Me.txtCausaPME.Name = "txtCausaPME"
        Me.txtCausaPME.Size = New System.Drawing.Size(481, 26)
        Me.txtCausaPME.TabIndex = 1
        '
        'lblNumPlaza
        '
        Me.lblNumPlaza.Location = New System.Drawing.Point(190, 94)
        Me.lblNumPlaza.Name = "lblNumPlaza"
        Me.lblNumPlaza.Size = New System.Drawing.Size(89, 26)
        Me.lblNumPlaza.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DataGridView1)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 622)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1049, 357)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalle del Instrumento:"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 56)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(1037, 266)
        Me.DataGridView1.TabIndex = 4
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(148, 328)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(83, 20)
        Me.Label25.TabIndex = 3
        Me.Label25.Text = "Total: 0.00"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(368, 22)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(168, 20)
        Me.Label23.TabIndex = 2
        Me.Label23.Text = "Descripcion del Docto."
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(826, 22)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(67, 20)
        Me.Label24.TabIndex = 2
        Me.Label24.Text = "Moneda"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(186, 22)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(130, 20)
        Me.Label22.TabIndex = 2
        Me.Label22.Text = "Monto del Docto."
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(16, 22)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(119, 20)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "Num. de Docto."
        '
        'cmdCierra
        '
        Me.cmdCierra.Location = New System.Drawing.Point(1080, 904)
        Me.cmdCierra.Name = "cmdCierra"
        Me.cmdCierra.Size = New System.Drawing.Size(169, 36)
        Me.cmdCierra.TabIndex = 4
        Me.cmdCierra.Text = "Salir"
        Me.cmdCierra.UseVisualStyleBackColor = True
        '
        'cmdAutorizacion
        '
        Me.cmdAutorizacion.Location = New System.Drawing.Point(1080, 852)
        Me.cmdAutorizacion.Name = "cmdAutorizacion"
        Me.cmdAutorizacion.Size = New System.Drawing.Size(169, 36)
        Me.cmdAutorizacion.TabIndex = 5
        Me.cmdAutorizacion.Text = "Detalle Autorizacion"
        Me.cmdAutorizacion.UseVisualStyleBackColor = True
        '
        'Consultaret
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1267, 997)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdAutorizacion)
        Me.Controls.Add(Me.cmdCierra)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Consultaret"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Retiros"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents pnlCancelada As Button
    Friend WithEvents lblStatusSw As TextBox
    Friend WithEvents lblStatusOp As TextBox
    Friend WithEvents txtFechaCaptura As TextBox
    Friend WithEvents lblGrabadora As TextBox
    Friend WithEvents txtLinea As TextBox
    Friend WithEvents txtFechaOperacion As TextBox
    Friend WithEvents txtNumCuenta As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNumOperacion As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents txtFuncionario As TextBox
    Friend WithEvents txtNumFuncionario As TextBox
    Friend WithEvents txtUsuarioCapt As TextBox
    Friend WithEvents txtSaldo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtCRPME As TextBox
    Friend WithEvents txtNumCRPME As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtCedRet As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents lblNumSuc As TextBox
    Friend WithEvents txtCausaPME As TextBox
    Friend WithEvents lblNumPlaza As TextBox
    Friend WithEvents txtSucursalPME As TextBox
    Friend WithEvents txtPlazaPME As TextBox
    Friend WithEvents txtNoCheque As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txtTipoMoneda As TextBox
    Friend WithEvents txtTipoDocumento As TextBox
    Friend WithEvents lblUniGes As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents cmdCierra As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents cmdAutorizacion As Button
End Class
