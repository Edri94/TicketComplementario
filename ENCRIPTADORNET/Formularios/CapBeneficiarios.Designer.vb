<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CapBeneficiarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CapBeneficiarios))
        Me.btCerrar = New System.Windows.Forms.Button()
        Me.gpoAut = New System.Windows.Forms.GroupBox()
        Me.btGuardar = New System.Windows.Forms.Button()
        Me.gvBeneficiarios = New System.Windows.Forms.DataGridView()
        Me.Beneficiario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.APELLIDOPAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.APELLIDOMAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btEliminar = New System.Windows.Forms.Button()
        Me.gpoApoNvo = New System.Windows.Forms.GroupBox()
        Me.btAgregar = New System.Windows.Forms.Button()
        Me.txApellidoMat = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txApellidoPat = New System.Windows.Forms.TextBox()
        Me.lbNombre = New System.Windows.Forms.Label()
        Me.gpoAut.SuspendLayout()
        CType(Me.gvBeneficiarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpoApoNvo.SuspendLayout()
        Me.SuspendLayout()
        '
        'btCerrar
        '
        Me.btCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCerrar.Location = New System.Drawing.Point(760, 370)
        Me.btCerrar.Name = "btCerrar"
        Me.btCerrar.Size = New System.Drawing.Size(100, 35)
        Me.btCerrar.TabIndex = 8
        Me.btCerrar.Text = "Cerrar"
        Me.btCerrar.UseVisualStyleBackColor = True
        '
        'gpoAut
        '
        Me.gpoAut.Controls.Add(Me.btGuardar)
        Me.gpoAut.Controls.Add(Me.gvBeneficiarios)
        Me.gpoAut.Controls.Add(Me.btEliminar)
        Me.gpoAut.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpoAut.Location = New System.Drawing.Point(8, 138)
        Me.gpoAut.Name = "gpoAut"
        Me.gpoAut.Size = New System.Drawing.Size(862, 226)
        Me.gpoAut.TabIndex = 39
        Me.gpoAut.TabStop = False
        Me.gpoAut.Text = "Beneficiarios asignados a esta cuenta"
        '
        'btGuardar
        '
        Me.btGuardar.Enabled = False
        Me.btGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGuardar.Location = New System.Drawing.Point(752, 45)
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(100, 35)
        Me.btGuardar.TabIndex = 6
        Me.btGuardar.Text = "Actualizar"
        Me.btGuardar.UseVisualStyleBackColor = True
        '
        'gvBeneficiarios
        '
        Me.gvBeneficiarios.AllowUserToAddRows = False
        Me.gvBeneficiarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvBeneficiarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Beneficiario, Me.Nombre, Me.APELLIDOPAT, Me.APELLIDOMAT})
        Me.gvBeneficiarios.Location = New System.Drawing.Point(8, 22)
        Me.gvBeneficiarios.Margin = New System.Windows.Forms.Padding(2)
        Me.gvBeneficiarios.Name = "gvBeneficiarios"
        Me.gvBeneficiarios.RowTemplate.Height = 24
        Me.gvBeneficiarios.Size = New System.Drawing.Size(729, 194)
        Me.gvBeneficiarios.TabIndex = 5
        '
        'Beneficiario
        '
        Me.Beneficiario.DataPropertyName = "BENEFICIARIO"
        Me.Beneficiario.HeaderText = "Beneficiario"
        Me.Beneficiario.Name = "Beneficiario"
        Me.Beneficiario.Visible = False
        '
        'Nombre
        '
        Me.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Nombre.DataPropertyName = "NOMBRE"
        Me.Nombre.FillWeight = 240.0!
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Width = 240
        '
        'APELLIDOPAT
        '
        Me.APELLIDOPAT.DataPropertyName = "APELLIDOPAT"
        Me.APELLIDOPAT.FillWeight = 240.0!
        Me.APELLIDOPAT.HeaderText = "Apellido Paterno"
        Me.APELLIDOPAT.Name = "APELLIDOPAT"
        Me.APELLIDOPAT.Width = 240
        '
        'APELLIDOMAT
        '
        Me.APELLIDOMAT.DataPropertyName = "APELLIDOMAT"
        Me.APELLIDOMAT.FillWeight = 240.0!
        Me.APELLIDOMAT.HeaderText = "Apellido Materno"
        Me.APELLIDOMAT.Name = "APELLIDOMAT"
        Me.APELLIDOMAT.Width = 240
        '
        'btEliminar
        '
        Me.btEliminar.Enabled = False
        Me.btEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btEliminar.Location = New System.Drawing.Point(752, 164)
        Me.btEliminar.Name = "btEliminar"
        Me.btEliminar.Size = New System.Drawing.Size(100, 35)
        Me.btEliminar.TabIndex = 7
        Me.btEliminar.Text = "Eliminar"
        Me.btEliminar.UseVisualStyleBackColor = True
        '
        'gpoApoNvo
        '
        Me.gpoApoNvo.Controls.Add(Me.btAgregar)
        Me.gpoApoNvo.Controls.Add(Me.txApellidoMat)
        Me.gpoApoNvo.Controls.Add(Me.Label2)
        Me.gpoApoNvo.Controls.Add(Me.txNombre)
        Me.gpoApoNvo.Controls.Add(Me.Label1)
        Me.gpoApoNvo.Controls.Add(Me.txApellidoPat)
        Me.gpoApoNvo.Controls.Add(Me.lbNombre)
        Me.gpoApoNvo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpoApoNvo.Location = New System.Drawing.Point(7, 11)
        Me.gpoApoNvo.Name = "gpoApoNvo"
        Me.gpoApoNvo.Size = New System.Drawing.Size(863, 123)
        Me.gpoApoNvo.TabIndex = 38
        Me.gpoApoNvo.TabStop = False
        Me.gpoApoNvo.Text = "Nuevo Beneficiario"
        '
        'btAgregar
        '
        Me.btAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAgregar.Location = New System.Drawing.Point(749, 76)
        Me.btAgregar.Name = "btAgregar"
        Me.btAgregar.Size = New System.Drawing.Size(100, 35)
        Me.btAgregar.TabIndex = 4
        Me.btAgregar.Text = "Agregar"
        Me.btAgregar.UseVisualStyleBackColor = True
        '
        'txApellidoMat
        '
        Me.txApellidoMat.Location = New System.Drawing.Point(170, 82)
        Me.txApellidoMat.MaxLength = 30
        Me.txApellidoMat.Name = "txApellidoMat"
        Me.txApellidoMat.Size = New System.Drawing.Size(296, 21)
        Me.txApellidoMat.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(82, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 16)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Ap Materno"
        '
        'txNombre
        '
        Me.txNombre.Location = New System.Drawing.Point(170, 24)
        Me.txNombre.MaxLength = 30
        Me.txNombre.Name = "txNombre"
        Me.txNombre.Size = New System.Drawing.Size(296, 21)
        Me.txNombre.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(85, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 16)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Ap Paterno"
        '
        'txApellidoPat
        '
        Me.txApellidoPat.Location = New System.Drawing.Point(170, 53)
        Me.txApellidoPat.MaxLength = 30
        Me.txApellidoPat.Name = "txApellidoPat"
        Me.txApellidoPat.Size = New System.Drawing.Size(296, 21)
        Me.txApellidoPat.TabIndex = 2
        '
        'lbNombre
        '
        Me.lbNombre.AutoSize = True
        Me.lbNombre.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNombre.Location = New System.Drawing.Point(109, 27)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(57, 16)
        Me.lbNombre.TabIndex = 26
        Me.lbNombre.Text = "Nombre"
        '
        'CapBeneficiarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(879, 415)
        Me.Controls.Add(Me.btCerrar)
        Me.Controls.Add(Me.gpoAut)
        Me.Controls.Add(Me.gpoApoNvo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CapBeneficiarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de Beneficiarios"
        Me.gpoAut.ResumeLayout(False)
        CType(Me.gvBeneficiarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpoApoNvo.ResumeLayout(False)
        Me.gpoApoNvo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btCerrar As Button
    Friend WithEvents gpoAut As GroupBox
    Friend WithEvents gvBeneficiarios As DataGridView
    Friend WithEvents btEliminar As Button
    Friend WithEvents gpoApoNvo As GroupBox
    Friend WithEvents btAgregar As Button
    Friend WithEvents txApellidoMat As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txNombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txApellidoPat As TextBox
    Friend WithEvents lbNombre As Label
    Friend WithEvents btGuardar As Button
    Friend WithEvents Beneficiario As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents APELLIDOPAT As DataGridViewTextBoxColumn
    Friend WithEvents APELLIDOMAT As DataGridViewTextBoxColumn
End Class
