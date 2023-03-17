<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsCte
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblNombre1 = New System.Windows.Forms.TextBox()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.txtCuenta = New System.Windows.Forms.MaskedTextBox()
        Me.lblNumDocs = New System.Windows.Forms.Label()
        Me.lblNumTkts = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDocTkt1 = New System.Windows.Forms.MaskedTextBox()
        Me.txtDocTkt0 = New System.Windows.Forms.MaskedTextBox()
        Me.txtDocFecha1 = New System.Windows.Forms.MaskedTextBox()
        Me.txtDocFecha0 = New System.Windows.Forms.MaskedTextBox()
        Me.cmbDocStatus = New System.Windows.Forms.ComboBox()
        Me.chkDocStatus = New System.Windows.Forms.CheckBox()
        Me.chkDocTicket = New System.Windows.Forms.CheckBox()
        Me.chkDocFecha = New System.Windows.Forms.CheckBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.cmbDiferencia = New System.Windows.Forms.ComboBox()
        Me.grdDoc = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtTktTkt1 = New System.Windows.Forms.MaskedTextBox()
        Me.txtTktTkt0 = New System.Windows.Forms.MaskedTextBox()
        Me.txtTktFecha1 = New System.Windows.Forms.MaskedTextBox()
        Me.cmbTktStatus = New System.Windows.Forms.ComboBox()
        Me.txtTktFecha0 = New System.Windows.Forms.MaskedTextBox()
        Me.grdTkt = New System.Windows.Forms.DataGridView()
        Me.chkTktStatus = New System.Windows.Forms.CheckBox()
        Me.chkTktFecha = New System.Windows.Forms.CheckBox()
        Me.chkTktTicket = New System.Windows.Forms.CheckBox()
        Me.cmdActualiza = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdTkt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblNombre1)
        Me.GroupBox2.Controls.Add(Me.cmbCliente)
        Me.GroupBox2.Controls.Add(Me.txtCuenta)
        Me.GroupBox2.Controls.Add(Me.lblNumDocs)
        Me.GroupBox2.Controls.Add(Me.lblNumTkts)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(764, 109)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cliente"
        '
        'lblNombre1
        '
        Me.lblNombre1.Enabled = False
        Me.lblNombre1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre1.Location = New System.Drawing.Point(208, 63)
        Me.lblNombre1.Name = "lblNombre1"
        Me.lblNombre1.Size = New System.Drawing.Size(310, 21)
        Me.lblNombre1.TabIndex = 6
        '
        'cmbCliente
        '
        Me.cmbCliente.Enabled = False
        Me.cmbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(208, 31)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(309, 23)
        Me.cmbCliente.TabIndex = 11
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(134, 31)
        Me.txtCuenta.Mask = "999999"
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(51, 22)
        Me.txtCuenta.TabIndex = 10
        Me.txtCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCuenta.ValidatingType = GetType(Integer)
        '
        'lblNumDocs
        '
        Me.lblNumDocs.BackColor = System.Drawing.SystemColors.Control
        Me.lblNumDocs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumDocs.Location = New System.Drawing.Point(633, 32)
        Me.lblNumDocs.Name = "lblNumDocs"
        Me.lblNumDocs.Size = New System.Drawing.Size(70, 18)
        Me.lblNumDocs.TabIndex = 8
        Me.lblNumDocs.Text = "                    "
        Me.lblNumDocs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNumTkts
        '
        Me.lblNumTkts.BackColor = System.Drawing.SystemColors.Control
        Me.lblNumTkts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumTkts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumTkts.Location = New System.Drawing.Point(633, 63)
        Me.lblNumTkts.Name = "lblNumTkts"
        Me.lblNumTkts.Size = New System.Drawing.Size(70, 18)
        Me.lblNumTkts.TabIndex = 7
        Me.lblNumTkts.Text = "                    "
        Me.lblNumTkts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(529, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "No. de Registros:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(528, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "No. Documentos:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(82, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Nombre del Cliente:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(82, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cuenta:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDocTkt1)
        Me.GroupBox1.Controls.Add(Me.txtDocTkt0)
        Me.GroupBox1.Controls.Add(Me.txtDocFecha1)
        Me.GroupBox1.Controls.Add(Me.txtDocFecha0)
        Me.GroupBox1.Controls.Add(Me.cmbDocStatus)
        Me.GroupBox1.Controls.Add(Me.chkDocStatus)
        Me.GroupBox1.Controls.Add(Me.chkDocTicket)
        Me.GroupBox1.Controls.Add(Me.chkDocFecha)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.CheckBox3)
        Me.GroupBox1.Controls.Add(Me.cmbDiferencia)
        Me.GroupBox1.Controls.Add(Me.grdDoc)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(12, 127)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(764, 243)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Documento"
        '
        'txtDocTkt1
        '
        Me.txtDocTkt1.Location = New System.Drawing.Point(443, 209)
        Me.txtDocTkt1.Mask = "9999999999"
        Me.txtDocTkt1.Name = "txtDocTkt1"
        Me.txtDocTkt1.Size = New System.Drawing.Size(79, 22)
        Me.txtDocTkt1.TabIndex = 28
        Me.txtDocTkt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDocTkt1.ValidatingType = GetType(Integer)
        Me.txtDocTkt1.Visible = False
        '
        'txtDocTkt0
        '
        Me.txtDocTkt0.Location = New System.Drawing.Point(362, 209)
        Me.txtDocTkt0.Mask = "9999999999"
        Me.txtDocTkt0.Name = "txtDocTkt0"
        Me.txtDocTkt0.Size = New System.Drawing.Size(79, 22)
        Me.txtDocTkt0.TabIndex = 27
        Me.txtDocTkt0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDocTkt0.ValidatingType = GetType(Integer)
        Me.txtDocTkt0.Visible = False
        '
        'txtDocFecha1
        '
        Me.txtDocFecha1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocFecha1.Location = New System.Drawing.Point(219, 210)
        Me.txtDocFecha1.Mask = "00/00/0000"
        Me.txtDocFecha1.Name = "txtDocFecha1"
        Me.txtDocFecha1.Size = New System.Drawing.Size(76, 21)
        Me.txtDocFecha1.TabIndex = 26
        Me.txtDocFecha1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDocFecha1.ValidatingType = GetType(Date)
        Me.txtDocFecha1.Visible = False
        '
        'txtDocFecha0
        '
        Me.txtDocFecha0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocFecha0.Location = New System.Drawing.Point(137, 210)
        Me.txtDocFecha0.Mask = "00/00/0000"
        Me.txtDocFecha0.Name = "txtDocFecha0"
        Me.txtDocFecha0.Size = New System.Drawing.Size(76, 21)
        Me.txtDocFecha0.TabIndex = 25
        Me.txtDocFecha0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDocFecha0.ValidatingType = GetType(Date)
        Me.txtDocFecha0.Visible = False
        '
        'cmbDocStatus
        '
        Me.cmbDocStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDocStatus.FormattingEnabled = True
        Me.cmbDocStatus.Location = New System.Drawing.Point(643, 208)
        Me.cmbDocStatus.Name = "cmbDocStatus"
        Me.cmbDocStatus.Size = New System.Drawing.Size(110, 21)
        Me.cmbDocStatus.TabIndex = 16
        Me.cmbDocStatus.Visible = False
        '
        'chkDocStatus
        '
        Me.chkDocStatus.AutoSize = True
        Me.chkDocStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDocStatus.Location = New System.Drawing.Point(526, 210)
        Me.chkDocStatus.Name = "chkDocStatus"
        Me.chkDocStatus.Size = New System.Drawing.Size(118, 19)
        Me.chkDocStatus.TabIndex = 15
        Me.chkDocStatus.Text = "Status Doc vs Tkt"
        Me.chkDocStatus.UseVisualStyleBackColor = True
        '
        'chkDocTicket
        '
        Me.chkDocTicket.AutoSize = True
        Me.chkDocTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDocTicket.Location = New System.Drawing.Point(304, 210)
        Me.chkDocTicket.Name = "chkDocTicket"
        Me.chkDocTicket.Size = New System.Drawing.Size(58, 19)
        Me.chkDocTicket.TabIndex = 12
        Me.chkDocTicket.Text = "Ticket"
        Me.chkDocTicket.UseVisualStyleBackColor = True
        '
        'chkDocFecha
        '
        Me.chkDocFecha.AutoSize = True
        Me.chkDocFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDocFecha.Location = New System.Drawing.Point(18, 210)
        Me.chkDocFecha.Name = "chkDocFecha"
        Me.chkDocFecha.Size = New System.Drawing.Size(120, 19)
        Me.chkDocFecha.TabIndex = 2
        Me.chkDocFecha.Text = "Fecha Operación"
        Me.chkDocFecha.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(640, 448)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(110, 23)
        Me.ComboBox1.TabIndex = 24
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(523, 450)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(118, 19)
        Me.CheckBox1.TabIndex = 23
        Me.CheckBox1.Text = "Status Doc vs Tkt"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(428, 448)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(68, 21)
        Me.TextBox1.TabIndex = 22
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(354, 448)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(67, 21)
        Me.TextBox2.TabIndex = 21
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(299, 450)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(58, 19)
        Me.CheckBox2.TabIndex = 20
        Me.CheckBox2.Text = "Ticket"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(208, 448)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(68, 21)
        Me.TextBox3.TabIndex = 19
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(134, 448)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(67, 21)
        Me.TextBox4.TabIndex = 18
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox3.Location = New System.Drawing.Point(15, 450)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(120, 19)
        Me.CheckBox3.TabIndex = 17
        Me.CheckBox3.Text = "Fecha Operación"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'cmbDiferencia
        '
        Me.cmbDiferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDiferencia.FormattingEnabled = True
        Me.cmbDiferencia.Location = New System.Drawing.Point(672, 21)
        Me.cmbDiferencia.Name = "cmbDiferencia"
        Me.cmbDiferencia.Size = New System.Drawing.Size(81, 23)
        Me.cmbDiferencia.TabIndex = 1
        Me.cmbDiferencia.Visible = False
        '
        'grdDoc
        '
        Me.grdDoc.AllowUserToAddRows = False
        Me.grdDoc.AllowUserToDeleteRows = False
        Me.grdDoc.AllowUserToOrderColumns = True
        Me.grdDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDoc.Location = New System.Drawing.Point(18, 21)
        Me.grdDoc.Name = "grdDoc"
        Me.grdDoc.ReadOnly = True
        Me.grdDoc.Size = New System.Drawing.Size(735, 183)
        Me.grdDoc.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtTktTkt1)
        Me.GroupBox3.Controls.Add(Me.txtTktTkt0)
        Me.GroupBox3.Controls.Add(Me.txtTktFecha1)
        Me.GroupBox3.Controls.Add(Me.cmbTktStatus)
        Me.GroupBox3.Controls.Add(Me.txtTktFecha0)
        Me.GroupBox3.Controls.Add(Me.grdTkt)
        Me.GroupBox3.Controls.Add(Me.chkTktStatus)
        Me.GroupBox3.Controls.Add(Me.chkTktFecha)
        Me.GroupBox3.Controls.Add(Me.chkTktTicket)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 387)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(764, 234)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ticket"
        '
        'txtTktTkt1
        '
        Me.txtTktTkt1.Location = New System.Drawing.Point(443, 196)
        Me.txtTktTkt1.Mask = "9999999999"
        Me.txtTktTkt1.Name = "txtTktTkt1"
        Me.txtTktTkt1.Size = New System.Drawing.Size(79, 22)
        Me.txtTktTkt1.TabIndex = 29
        Me.txtTktTkt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTktTkt1.ValidatingType = GetType(Integer)
        Me.txtTktTkt1.Visible = False
        '
        'txtTktTkt0
        '
        Me.txtTktTkt0.Location = New System.Drawing.Point(362, 196)
        Me.txtTktTkt0.Mask = "9999999999"
        Me.txtTktTkt0.Name = "txtTktTkt0"
        Me.txtTktTkt0.Size = New System.Drawing.Size(79, 22)
        Me.txtTktTkt0.TabIndex = 29
        Me.txtTktTkt0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTktTkt0.ValidatingType = GetType(Integer)
        Me.txtTktTkt0.Visible = False
        '
        'txtTktFecha1
        '
        Me.txtTktFecha1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTktFecha1.Location = New System.Drawing.Point(219, 199)
        Me.txtTktFecha1.Mask = "00/00/0000"
        Me.txtTktFecha1.Name = "txtTktFecha1"
        Me.txtTktFecha1.Size = New System.Drawing.Size(76, 21)
        Me.txtTktFecha1.TabIndex = 28
        Me.txtTktFecha1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTktFecha1.ValidatingType = GetType(Date)
        Me.txtTktFecha1.Visible = False
        '
        'cmbTktStatus
        '
        Me.cmbTktStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTktStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTktStatus.FormattingEnabled = True
        Me.cmbTktStatus.Location = New System.Drawing.Point(643, 197)
        Me.cmbTktStatus.Name = "cmbTktStatus"
        Me.cmbTktStatus.Size = New System.Drawing.Size(110, 21)
        Me.cmbTktStatus.TabIndex = 32
        Me.cmbTktStatus.Visible = False
        '
        'txtTktFecha0
        '
        Me.txtTktFecha0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTktFecha0.Location = New System.Drawing.Point(137, 199)
        Me.txtTktFecha0.Mask = "00/00/0000"
        Me.txtTktFecha0.Name = "txtTktFecha0"
        Me.txtTktFecha0.Size = New System.Drawing.Size(76, 21)
        Me.txtTktFecha0.TabIndex = 27
        Me.txtTktFecha0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTktFecha0.ValidatingType = GetType(Date)
        Me.txtTktFecha0.Visible = False
        '
        'grdTkt
        '
        Me.grdTkt.AllowUserToAddRows = False
        Me.grdTkt.AllowUserToDeleteRows = False
        Me.grdTkt.AllowUserToOrderColumns = True
        Me.grdTkt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTkt.Location = New System.Drawing.Point(18, 21)
        Me.grdTkt.Name = "grdTkt"
        Me.grdTkt.ReadOnly = True
        Me.grdTkt.Size = New System.Drawing.Size(735, 172)
        Me.grdTkt.TabIndex = 0
        '
        'chkTktStatus
        '
        Me.chkTktStatus.AutoSize = True
        Me.chkTktStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTktStatus.Location = New System.Drawing.Point(526, 199)
        Me.chkTktStatus.Name = "chkTktStatus"
        Me.chkTktStatus.Size = New System.Drawing.Size(118, 19)
        Me.chkTktStatus.TabIndex = 31
        Me.chkTktStatus.Text = "Status Doc vs Tkt"
        Me.chkTktStatus.UseVisualStyleBackColor = True
        '
        'chkTktFecha
        '
        Me.chkTktFecha.AutoSize = True
        Me.chkTktFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTktFecha.Location = New System.Drawing.Point(18, 199)
        Me.chkTktFecha.Name = "chkTktFecha"
        Me.chkTktFecha.Size = New System.Drawing.Size(120, 19)
        Me.chkTktFecha.TabIndex = 25
        Me.chkTktFecha.Text = "Fecha Operación"
        Me.chkTktFecha.UseVisualStyleBackColor = True
        '
        'chkTktTicket
        '
        Me.chkTktTicket.AutoSize = True
        Me.chkTktTicket.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.chkTktTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTktTicket.Location = New System.Drawing.Point(302, 199)
        Me.chkTktTicket.Name = "chkTktTicket"
        Me.chkTktTicket.Size = New System.Drawing.Size(58, 19)
        Me.chkTktTicket.TabIndex = 28
        Me.chkTktTicket.Text = "Ticket"
        Me.chkTktTicket.UseVisualStyleBackColor = False
        '
        'cmdActualiza
        '
        Me.cmdActualiza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdActualiza.Location = New System.Drawing.Point(581, 627)
        Me.cmdActualiza.Name = "cmdActualiza"
        Me.cmdActualiza.Size = New System.Drawing.Size(75, 34)
        Me.cmdActualiza.TabIndex = 4
        Me.cmdActualiza.Text = "Actualizar"
        Me.cmdActualiza.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalir.Location = New System.Drawing.Point(684, 627)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(75, 34)
        Me.cmdSalir.TabIndex = 5
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'frmConsCte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(800, 673)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdActualiza)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmConsCte"
        Me.Text = "Consulta por Cliente"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.grdTkt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblNumDocs As Label
    Friend WithEvents lblNumTkts As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents grdDoc As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents grdTkt As DataGridView
    Friend WithEvents cmbDiferencia As ComboBox
    Friend WithEvents cmbDocStatus As ComboBox
    Friend WithEvents chkDocStatus As CheckBox
    Friend WithEvents chkDocTicket As CheckBox
    Friend WithEvents chkDocFecha As CheckBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents cmbTktStatus As ComboBox
    Friend WithEvents chkTktStatus As CheckBox
    Friend WithEvents chkTktFecha As CheckBox
    Friend WithEvents chkTktTicket As CheckBox
    Friend WithEvents cmdActualiza As Button
    Friend WithEvents cmdSalir As Button
    Friend WithEvents txtCuenta As MaskedTextBox
    Friend WithEvents txtDocFecha1 As MaskedTextBox
    Friend WithEvents txtDocFecha0 As MaskedTextBox
    Friend WithEvents txtTktFecha1 As MaskedTextBox
    Friend WithEvents txtTktFecha0 As MaskedTextBox
    Friend WithEvents txtDocTkt0 As MaskedTextBox
    Friend WithEvents txtDocTkt1 As MaskedTextBox
    Friend WithEvents txtTktTkt1 As MaskedTextBox
    Friend WithEvents txtTktTkt0 As MaskedTextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents lblNombre1 As TextBox
    Friend WithEvents cmbCliente As ComboBox
End Class
