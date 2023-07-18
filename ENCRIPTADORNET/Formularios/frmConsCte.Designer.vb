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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsCte))
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
        Me.GroupBox2.Location = New System.Drawing.Point(18, 18)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(1146, 168)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cliente"
        '
        'lblNombre1
        '
        Me.lblNombre1.Enabled = False
        Me.lblNombre1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre1.Location = New System.Drawing.Point(312, 97)
        Me.lblNombre1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lblNombre1.Name = "lblNombre1"
        Me.lblNombre1.Size = New System.Drawing.Size(463, 28)
        Me.lblNombre1.TabIndex = 6
        '
        'cmbCliente
        '
        Me.cmbCliente.Enabled = False
        Me.cmbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(312, 48)
        Me.cmbCliente.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(462, 30)
        Me.cmbCliente.TabIndex = 11
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(201, 48)
        Me.txtCuenta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCuenta.Mask = "999999"
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(74, 29)
        Me.txtCuenta.TabIndex = 10
        Me.txtCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCuenta.ValidatingType = GetType(Integer)
        '
        'lblNumDocs
        '
        Me.lblNumDocs.BackColor = System.Drawing.SystemColors.Control
        Me.lblNumDocs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumDocs.Location = New System.Drawing.Point(950, 49)
        Me.lblNumDocs.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNumDocs.Name = "lblNumDocs"
        Me.lblNumDocs.Size = New System.Drawing.Size(105, 28)
        Me.lblNumDocs.TabIndex = 8
        Me.lblNumDocs.Text = "                    "
        Me.lblNumDocs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNumTkts
        '
        Me.lblNumTkts.BackColor = System.Drawing.SystemColors.Control
        Me.lblNumTkts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumTkts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumTkts.Location = New System.Drawing.Point(950, 97)
        Me.lblNumTkts.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNumTkts.Name = "lblNumTkts"
        Me.lblNumTkts.Size = New System.Drawing.Size(105, 28)
        Me.lblNumTkts.TabIndex = 7
        Me.lblNumTkts.Text = "                    "
        Me.lblNumTkts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(794, 98)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(149, 22)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "No. de Registros:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(792, 49)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 22)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "No. Documentos:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(123, 98)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 22)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Nombre del Cliente:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(123, 54)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 22)
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
        Me.GroupBox1.Location = New System.Drawing.Point(18, 195)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(1146, 374)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Documento"
        '
        'txtDocTkt1
        '
        Me.txtDocTkt1.Location = New System.Drawing.Point(664, 322)
        Me.txtDocTkt1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDocTkt1.Mask = "9999999999"
        Me.txtDocTkt1.Name = "txtDocTkt1"
        Me.txtDocTkt1.Size = New System.Drawing.Size(116, 29)
        Me.txtDocTkt1.TabIndex = 28
        Me.txtDocTkt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDocTkt1.ValidatingType = GetType(Integer)
        Me.txtDocTkt1.Visible = False
        '
        'txtDocTkt0
        '
        Me.txtDocTkt0.Location = New System.Drawing.Point(543, 322)
        Me.txtDocTkt0.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDocTkt0.Mask = "9999999999"
        Me.txtDocTkt0.Name = "txtDocTkt0"
        Me.txtDocTkt0.Size = New System.Drawing.Size(116, 29)
        Me.txtDocTkt0.TabIndex = 27
        Me.txtDocTkt0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDocTkt0.ValidatingType = GetType(Integer)
        Me.txtDocTkt0.Visible = False
        '
        'txtDocFecha1
        '
        Me.txtDocFecha1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocFecha1.Location = New System.Drawing.Point(328, 323)
        Me.txtDocFecha1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDocFecha1.Mask = "00/00/0000"
        Me.txtDocFecha1.Name = "txtDocFecha1"
        Me.txtDocFecha1.Size = New System.Drawing.Size(112, 28)
        Me.txtDocFecha1.TabIndex = 26
        Me.txtDocFecha1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDocFecha1.ValidatingType = GetType(Date)
        Me.txtDocFecha1.Visible = False
        '
        'txtDocFecha0
        '
        Me.txtDocFecha0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocFecha0.Location = New System.Drawing.Point(206, 323)
        Me.txtDocFecha0.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDocFecha0.Mask = "00/00/0000"
        Me.txtDocFecha0.Name = "txtDocFecha0"
        Me.txtDocFecha0.Size = New System.Drawing.Size(112, 28)
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
        Me.cmbDocStatus.Location = New System.Drawing.Point(964, 320)
        Me.cmbDocStatus.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbDocStatus.Name = "cmbDocStatus"
        Me.cmbDocStatus.Size = New System.Drawing.Size(163, 28)
        Me.cmbDocStatus.TabIndex = 16
        Me.cmbDocStatus.Visible = False
        '
        'chkDocStatus
        '
        Me.chkDocStatus.AutoSize = True
        Me.chkDocStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDocStatus.Location = New System.Drawing.Point(789, 323)
        Me.chkDocStatus.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkDocStatus.Name = "chkDocStatus"
        Me.chkDocStatus.Size = New System.Drawing.Size(178, 26)
        Me.chkDocStatus.TabIndex = 15
        Me.chkDocStatus.Text = "Status Doc vs Tkt"
        Me.chkDocStatus.UseVisualStyleBackColor = True
        '
        'chkDocTicket
        '
        Me.chkDocTicket.AutoSize = True
        Me.chkDocTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDocTicket.Location = New System.Drawing.Point(456, 323)
        Me.chkDocTicket.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkDocTicket.Name = "chkDocTicket"
        Me.chkDocTicket.Size = New System.Drawing.Size(85, 26)
        Me.chkDocTicket.TabIndex = 12
        Me.chkDocTicket.Text = "Ticket"
        Me.chkDocTicket.UseVisualStyleBackColor = True
        '
        'chkDocFecha
        '
        Me.chkDocFecha.AutoSize = True
        Me.chkDocFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDocFecha.Location = New System.Drawing.Point(27, 323)
        Me.chkDocFecha.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkDocFecha.Name = "chkDocFecha"
        Me.chkDocFecha.Size = New System.Drawing.Size(174, 26)
        Me.chkDocFecha.TabIndex = 2
        Me.chkDocFecha.Text = "Fecha Operación"
        Me.chkDocFecha.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(960, 689)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(163, 30)
        Me.ComboBox1.TabIndex = 24
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(784, 692)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(178, 26)
        Me.CheckBox1.TabIndex = 23
        Me.CheckBox1.Text = "Status Doc vs Tkt"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(642, 689)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 28)
        Me.TextBox1.TabIndex = 22
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(531, 689)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(98, 28)
        Me.TextBox2.TabIndex = 21
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(448, 692)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(85, 26)
        Me.CheckBox2.TabIndex = 20
        Me.CheckBox2.Text = "Ticket"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(312, 689)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 28)
        Me.TextBox3.TabIndex = 19
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(201, 689)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(98, 28)
        Me.TextBox4.TabIndex = 18
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox3.Location = New System.Drawing.Point(22, 692)
        Me.CheckBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(174, 26)
        Me.CheckBox3.TabIndex = 17
        Me.CheckBox3.Text = "Fecha Operación"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'cmbDiferencia
        '
        Me.cmbDiferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDiferencia.FormattingEnabled = True
        Me.cmbDiferencia.Location = New System.Drawing.Point(1008, 32)
        Me.cmbDiferencia.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbDiferencia.Name = "cmbDiferencia"
        Me.cmbDiferencia.Size = New System.Drawing.Size(120, 30)
        Me.cmbDiferencia.TabIndex = 1
        Me.cmbDiferencia.Visible = False
        '
        'grdDoc
        '
        Me.grdDoc.AllowUserToAddRows = False
        Me.grdDoc.AllowUserToDeleteRows = False
        Me.grdDoc.AllowUserToOrderColumns = True
        Me.grdDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDoc.Location = New System.Drawing.Point(27, 32)
        Me.grdDoc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grdDoc.Name = "grdDoc"
        Me.grdDoc.ReadOnly = True
        Me.grdDoc.RowHeadersWidth = 62
        Me.grdDoc.Size = New System.Drawing.Size(1102, 282)
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
        Me.GroupBox3.Location = New System.Drawing.Point(18, 595)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Size = New System.Drawing.Size(1146, 360)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ticket"
        '
        'txtTktTkt1
        '
        Me.txtTktTkt1.Location = New System.Drawing.Point(664, 302)
        Me.txtTktTkt1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTktTkt1.Mask = "9999999999"
        Me.txtTktTkt1.Name = "txtTktTkt1"
        Me.txtTktTkt1.Size = New System.Drawing.Size(116, 29)
        Me.txtTktTkt1.TabIndex = 29
        Me.txtTktTkt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTktTkt1.ValidatingType = GetType(Integer)
        Me.txtTktTkt1.Visible = False
        '
        'txtTktTkt0
        '
        Me.txtTktTkt0.Location = New System.Drawing.Point(543, 302)
        Me.txtTktTkt0.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTktTkt0.Mask = "9999999999"
        Me.txtTktTkt0.Name = "txtTktTkt0"
        Me.txtTktTkt0.Size = New System.Drawing.Size(116, 29)
        Me.txtTktTkt0.TabIndex = 29
        Me.txtTktTkt0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTktTkt0.ValidatingType = GetType(Integer)
        Me.txtTktTkt0.Visible = False
        '
        'txtTktFecha1
        '
        Me.txtTktFecha1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTktFecha1.Location = New System.Drawing.Point(328, 306)
        Me.txtTktFecha1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTktFecha1.Mask = "00/00/0000"
        Me.txtTktFecha1.Name = "txtTktFecha1"
        Me.txtTktFecha1.Size = New System.Drawing.Size(112, 28)
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
        Me.cmbTktStatus.Location = New System.Drawing.Point(964, 303)
        Me.cmbTktStatus.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbTktStatus.Name = "cmbTktStatus"
        Me.cmbTktStatus.Size = New System.Drawing.Size(163, 28)
        Me.cmbTktStatus.TabIndex = 32
        Me.cmbTktStatus.Visible = False
        '
        'txtTktFecha0
        '
        Me.txtTktFecha0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTktFecha0.Location = New System.Drawing.Point(206, 306)
        Me.txtTktFecha0.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTktFecha0.Mask = "00/00/0000"
        Me.txtTktFecha0.Name = "txtTktFecha0"
        Me.txtTktFecha0.Size = New System.Drawing.Size(112, 28)
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
        Me.grdTkt.Location = New System.Drawing.Point(27, 32)
        Me.grdTkt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grdTkt.Name = "grdTkt"
        Me.grdTkt.ReadOnly = True
        Me.grdTkt.RowHeadersWidth = 62
        Me.grdTkt.Size = New System.Drawing.Size(1102, 265)
        Me.grdTkt.TabIndex = 0
        '
        'chkTktStatus
        '
        Me.chkTktStatus.AutoSize = True
        Me.chkTktStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTktStatus.Location = New System.Drawing.Point(789, 306)
        Me.chkTktStatus.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkTktStatus.Name = "chkTktStatus"
        Me.chkTktStatus.Size = New System.Drawing.Size(178, 26)
        Me.chkTktStatus.TabIndex = 31
        Me.chkTktStatus.Text = "Status Doc vs Tkt"
        Me.chkTktStatus.UseVisualStyleBackColor = True
        '
        'chkTktFecha
        '
        Me.chkTktFecha.AutoSize = True
        Me.chkTktFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTktFecha.Location = New System.Drawing.Point(27, 306)
        Me.chkTktFecha.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkTktFecha.Name = "chkTktFecha"
        Me.chkTktFecha.Size = New System.Drawing.Size(174, 26)
        Me.chkTktFecha.TabIndex = 25
        Me.chkTktFecha.Text = "Fecha Operación"
        Me.chkTktFecha.UseVisualStyleBackColor = True
        '
        'chkTktTicket
        '
        Me.chkTktTicket.AutoSize = True
        Me.chkTktTicket.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.chkTktTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTktTicket.Location = New System.Drawing.Point(453, 306)
        Me.chkTktTicket.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkTktTicket.Name = "chkTktTicket"
        Me.chkTktTicket.Size = New System.Drawing.Size(85, 26)
        Me.chkTktTicket.TabIndex = 28
        Me.chkTktTicket.Text = "Ticket"
        Me.chkTktTicket.UseVisualStyleBackColor = False
        '
        'cmdActualiza
        '
        Me.cmdActualiza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdActualiza.Location = New System.Drawing.Point(872, 965)
        Me.cmdActualiza.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdActualiza.Name = "cmdActualiza"
        Me.cmdActualiza.Size = New System.Drawing.Size(112, 52)
        Me.cmdActualiza.TabIndex = 4
        Me.cmdActualiza.Text = "Actualizar"
        Me.cmdActualiza.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalir.Location = New System.Drawing.Point(1026, 965)
        Me.cmdSalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(112, 52)
        Me.cmdSalir.TabIndex = 5
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'frmConsCte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1200, 1035)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdActualiza)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
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
