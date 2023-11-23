<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConsultaDep
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pnlCancelada = New System.Windows.Forms.Button()
        Me.lblStatusSw = New System.Windows.Forms.TextBox()
        Me.lblStatusOp = New System.Windows.Forms.TextBox()
        Me.txtFechaCaptura = New System.Windows.Forms.TextBox()
        Me.lblGrabadora = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.txtFechaOperacion = New System.Windows.Forms.TextBox()
        Me.txtNumCuenta = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNumOperacion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtUsuarioCapt = New System.Windows.Forms.TextBox()
        Me.txtCed = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCausa = New System.Windows.Forms.TextBox()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.txtPlaza = New System.Windows.Forms.TextBox()
        Me.txtCR = New System.Windows.Forms.TextBox()
        Me.txtNumCR = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFuncionario = New System.Windows.Forms.TextBox()
        Me.txtNumFuncionario = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtNumSucursal = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblUniGes = New System.Windows.Forms.TextBox()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.txtMoneda = New System.Windows.Forms.TextBox()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtNumPlaza = New System.Windows.Forms.TextBox()
        Me.cmdCierra = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmdAutorizacion = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pnlCancelada)
        Me.GroupBox1.Controls.Add(Me.lblStatusSw)
        Me.GroupBox1.Controls.Add(Me.lblStatusOp)
        Me.GroupBox1.Controls.Add(Me.txtFechaCaptura)
        Me.GroupBox1.Controls.Add(Me.lblGrabadora)
        Me.GroupBox1.Controls.Add(Me.TextBox8)
        Me.GroupBox1.Controls.Add(Me.txtFechaOperacion)
        Me.GroupBox1.Controls.Add(Me.txtNumCuenta)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtMonto)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtNumOperacion)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1253, 181)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle del Deposito"
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
        Me.lblStatusSw.ReadOnly = True
        Me.lblStatusSw.Size = New System.Drawing.Size(204, 26)
        Me.lblStatusSw.TabIndex = 1
        '
        'lblStatusOp
        '
        Me.lblStatusOp.Location = New System.Drawing.Point(677, 97)
        Me.lblStatusOp.Name = "lblStatusOp"
        Me.lblStatusOp.ReadOnly = True
        Me.lblStatusOp.Size = New System.Drawing.Size(204, 26)
        Me.lblStatusOp.TabIndex = 1
        '
        'txtFechaCaptura
        '
        Me.txtFechaCaptura.Location = New System.Drawing.Point(171, 106)
        Me.txtFechaCaptura.Name = "txtFechaCaptura"
        Me.txtFechaCaptura.ReadOnly = True
        Me.txtFechaCaptura.Size = New System.Drawing.Size(204, 26)
        Me.txtFechaCaptura.TabIndex = 1
        '
        'lblGrabadora
        '
        Me.lblGrabadora.Location = New System.Drawing.Point(1149, 60)
        Me.lblGrabadora.Name = "lblGrabadora"
        Me.lblGrabadora.ReadOnly = True
        Me.lblGrabadora.Size = New System.Drawing.Size(79, 26)
        Me.lblGrabadora.TabIndex = 1
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(1149, 24)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(79, 26)
        Me.TextBox8.TabIndex = 1
        '
        'txtFechaOperacion
        '
        Me.txtFechaOperacion.Location = New System.Drawing.Point(677, 61)
        Me.txtFechaOperacion.Name = "txtFechaOperacion"
        Me.txtFechaOperacion.ReadOnly = True
        Me.txtFechaOperacion.Size = New System.Drawing.Size(204, 26)
        Me.txtFechaOperacion.TabIndex = 1
        '
        'txtNumCuenta
        '
        Me.txtNumCuenta.Location = New System.Drawing.Point(677, 25)
        Me.txtNumCuenta.Name = "txtNumCuenta"
        Me.txtNumCuenta.ReadOnly = True
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
        Me.txtMonto.ReadOnly = True
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
        'txtNumOperacion
        '
        Me.txtNumOperacion.Location = New System.Drawing.Point(171, 34)
        Me.txtNumOperacion.Name = "txtNumOperacion"
        Me.txtNumOperacion.ReadOnly = True
        Me.txtNumOperacion.Size = New System.Drawing.Size(204, 26)
        Me.txtNumOperacion.TabIndex = 1
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
        Me.Label3.Size = New System.Drawing.Size(137, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Fecha de registro:"
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
        Me.Label2.Size = New System.Drawing.Size(148, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Monto del deposito:"
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
        Me.GroupBox2.Controls.Add(Me.txtUsuarioCapt)
        Me.GroupBox2.Controls.Add(Me.txtCed)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtCausa)
        Me.GroupBox2.Controls.Add(Me.txtSucursal)
        Me.GroupBox2.Controls.Add(Me.txtPlaza)
        Me.GroupBox2.Controls.Add(Me.txtCR)
        Me.GroupBox2.Controls.Add(Me.txtNumCR)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtFuncionario)
        Me.GroupBox2.Controls.Add(Me.txtNumFuncionario)
        Me.GroupBox2.Controls.Add(Me.txtDescripcion)
        Me.GroupBox2.Controls.Add(Me.txtNumSucursal)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.lblUniGes)
        Me.GroupBox2.Controls.Add(Me.txtFolio)
        Me.GroupBox2.Controls.Add(Me.txtMoneda)
        Me.GroupBox2.Controls.Add(Me.txtDocumento)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtNumPlaza)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 199)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1253, 340)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Solo para Negocios Internacionales"
        '
        'txtUsuarioCapt
        '
        Me.txtUsuarioCapt.Location = New System.Drawing.Point(190, 296)
        Me.txtUsuarioCapt.Name = "txtUsuarioCapt"
        Me.txtUsuarioCapt.ReadOnly = True
        Me.txtUsuarioCapt.Size = New System.Drawing.Size(726, 26)
        Me.txtUsuarioCapt.TabIndex = 1
        '
        'txtCed
        '
        Me.txtCed.Location = New System.Drawing.Point(190, 148)
        Me.txtCed.Name = "txtCed"
        Me.txtCed.ReadOnly = True
        Me.txtCed.Size = New System.Drawing.Size(204, 26)
        Me.txtCed.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(16, 300)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(156, 20)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Usuario que registro:"
        '
        'txtCausa
        '
        Me.txtCausa.Location = New System.Drawing.Point(468, 148)
        Me.txtCausa.Name = "txtCausa"
        Me.txtCausa.ReadOnly = True
        Me.txtCausa.Size = New System.Drawing.Size(769, 26)
        Me.txtCausa.TabIndex = 1
        '
        'txtSucursal
        '
        Me.txtSucursal.Location = New System.Drawing.Point(407, 111)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.ReadOnly = True
        Me.txtSucursal.Size = New System.Drawing.Size(830, 26)
        Me.txtSucursal.TabIndex = 1
        '
        'txtPlaza
        '
        Me.txtPlaza.Location = New System.Drawing.Point(407, 74)
        Me.txtPlaza.Name = "txtPlaza"
        Me.txtPlaza.ReadOnly = True
        Me.txtPlaza.Size = New System.Drawing.Size(830, 26)
        Me.txtPlaza.TabIndex = 1
        '
        'txtCR
        '
        Me.txtCR.Location = New System.Drawing.Point(407, 37)
        Me.txtCR.Name = "txtCR"
        Me.txtCR.ReadOnly = True
        Me.txtCR.Size = New System.Drawing.Size(830, 26)
        Me.txtCR.TabIndex = 1
        '
        'txtNumCR
        '
        Me.txtNumCR.Location = New System.Drawing.Point(190, 37)
        Me.txtNumCR.Name = "txtNumCR"
        Me.txtNumCR.ReadOnly = True
        Me.txtNumCR.Size = New System.Drawing.Size(204, 26)
        Me.txtNumCR.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(16, 151)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(167, 20)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Numero de Ficha Ced:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(165, 20)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Centro Regional (CR):"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 188)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(130, 20)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Tipo Documento:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 77)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 20)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Plaza:"
        '
        'txtFuncionario
        '
        Me.txtFuncionario.Location = New System.Drawing.Point(317, 260)
        Me.txtFuncionario.Name = "txtFuncionario"
        Me.txtFuncionario.ReadOnly = True
        Me.txtFuncionario.Size = New System.Drawing.Size(599, 26)
        Me.txtFuncionario.TabIndex = 1
        '
        'txtNumFuncionario
        '
        Me.txtNumFuncionario.Location = New System.Drawing.Point(190, 259)
        Me.txtNumFuncionario.Name = "txtNumFuncionario"
        Me.txtNumFuncionario.ReadOnly = True
        Me.txtNumFuncionario.Size = New System.Drawing.Size(109, 26)
        Me.txtNumFuncionario.TabIndex = 1
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(190, 222)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(379, 26)
        Me.txtDescripcion.TabIndex = 1
        '
        'txtNumSucursal
        '
        Me.txtNumSucursal.Location = New System.Drawing.Point(190, 111)
        Me.txtNumSucursal.Name = "txtNumSucursal"
        Me.txtNumSucursal.ReadOnly = True
        Me.txtNumSucursal.Size = New System.Drawing.Size(204, 26)
        Me.txtNumSucursal.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 260)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 20)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Gestor:"
        '
        'lblUniGes
        '
        Me.lblUniGes.Location = New System.Drawing.Point(1074, 297)
        Me.lblUniGes.Name = "lblUniGes"
        Me.lblUniGes.ReadOnly = True
        Me.lblUniGes.Size = New System.Drawing.Size(163, 26)
        Me.lblUniGes.TabIndex = 1
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(804, 224)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.ReadOnly = True
        Me.txtFolio.Size = New System.Drawing.Size(112, 26)
        Me.txtFolio.TabIndex = 1
        '
        'txtMoneda
        '
        Me.txtMoneda.Location = New System.Drawing.Point(804, 188)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.ReadOnly = True
        Me.txtMoneda.Size = New System.Drawing.Size(433, 26)
        Me.txtMoneda.TabIndex = 1
        '
        'txtDocumento
        '
        Me.txtDocumento.Location = New System.Drawing.Point(190, 185)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.ReadOnly = True
        Me.txtDocumento.Size = New System.Drawing.Size(379, 26)
        Me.txtDocumento.TabIndex = 1
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(1080, 271)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(91, 20)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "U. Gestora:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(727, 230)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 20)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Folio:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(727, 191)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(71, 20)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Moneda:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(403, 151)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 20)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Causa:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 114)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 20)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Sucursal:"
        '
        'txtNumPlaza
        '
        Me.txtNumPlaza.Location = New System.Drawing.Point(190, 74)
        Me.txtNumPlaza.Name = "txtNumPlaza"
        Me.txtNumPlaza.ReadOnly = True
        Me.txtNumPlaza.Size = New System.Drawing.Size(204, 26)
        Me.txtNumPlaza.TabIndex = 1
        '
        'cmdCierra
        '
        Me.cmdCierra.Location = New System.Drawing.Point(1080, 785)
        Me.cmdCierra.Name = "cmdCierra"
        Me.cmdCierra.Size = New System.Drawing.Size(169, 36)
        Me.cmdCierra.TabIndex = 1
        Me.cmdCierra.Text = "Salir"
        Me.cmdCierra.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DataGridView1)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 545)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1049, 276)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalle del Instrumento:"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 57)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(1037, 188)
        Me.DataGridView1.TabIndex = 4
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(154, 248)
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
        'cmdAutorizacion
        '
        Me.cmdAutorizacion.Location = New System.Drawing.Point(1080, 743)
        Me.cmdAutorizacion.Name = "cmdAutorizacion"
        Me.cmdAutorizacion.Size = New System.Drawing.Size(169, 36)
        Me.cmdAutorizacion.TabIndex = 1
        Me.cmdAutorizacion.Text = "Detalle Autorizacion"
        Me.cmdAutorizacion.UseVisualStyleBackColor = True
        '
        'ConsultaDep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1277, 938)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdAutorizacion)
        Me.Controls.Add(Me.cmdCierra)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ConsultaDep"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Depositos en Firme"
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
    Friend WithEvents lblStatusSw As TextBox
    Friend WithEvents lblStatusOp As TextBox
    Friend WithEvents txtFechaCaptura As TextBox
    Friend WithEvents lblGrabadora As TextBox
    Friend WithEvents TextBox8 As TextBox
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
    Friend WithEvents pnlCancelada As Button
    Friend WithEvents txtUsuarioCapt As TextBox
    Friend WithEvents txtCed As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtCausa As TextBox
    Friend WithEvents txtSucursal As TextBox
    Friend WithEvents txtPlaza As TextBox
    Friend WithEvents txtCR As TextBox
    Friend WithEvents txtNumCR As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtNumFuncionario As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents txtNumSucursal As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtDocumento As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtNumPlaza As TextBox
    Friend WithEvents txtFuncionario As TextBox
    Friend WithEvents lblUniGes As TextBox
    Friend WithEvents txtFolio As TextBox
    Friend WithEvents txtMoneda As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents cmdCierra As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents cmdAutorizacion As Button
End Class
