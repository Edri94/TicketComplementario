<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CapAutorizados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CapAutorizados))
        Me.gpoAutNvo = New System.Windows.Forms.GroupBox()
        Me.btAgregar = New System.Windows.Forms.Button()
        Me.txApellidoMat = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txApellidoPat = New System.Windows.Forms.TextBox()
        Me.lbNombre = New System.Windows.Forms.Label()
        Me.btGuardar = New System.Windows.Forms.Button()
        Me.gpoAut = New System.Windows.Forms.GroupBox()
        Me.gvAutorizados = New System.Windows.Forms.DataGridView()
        Me.Autorizado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApellidoPat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApellidoMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btEliminar = New System.Windows.Forms.Button()
        Me.btCerrar = New System.Windows.Forms.Button()
        Me.gpoAutNvo.SuspendLayout()
        Me.gpoAut.SuspendLayout()
        CType(Me.gvAutorizados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpoAutNvo
        '
        Me.gpoAutNvo.Controls.Add(Me.btAgregar)
        Me.gpoAutNvo.Controls.Add(Me.txApellidoMat)
        Me.gpoAutNvo.Controls.Add(Me.Label2)
        Me.gpoAutNvo.Controls.Add(Me.txNombre)
        Me.gpoAutNvo.Controls.Add(Me.Label1)
        Me.gpoAutNvo.Controls.Add(Me.txApellidoPat)
        Me.gpoAutNvo.Controls.Add(Me.lbNombre)
        Me.gpoAutNvo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpoAutNvo.Location = New System.Drawing.Point(7, 11)
        Me.gpoAutNvo.Name = "gpoAutNvo"
        Me.gpoAutNvo.Size = New System.Drawing.Size(863, 123)
        Me.gpoAutNvo.TabIndex = 0
        Me.gpoAutNvo.TabStop = False
        Me.gpoAutNvo.Text = "Nuevo Autorizado"
        '
        'btAgregar
        '
        Me.btAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAgregar.Location = New System.Drawing.Point(753, 69)
        Me.btAgregar.Name = "btAgregar"
        Me.btAgregar.Size = New System.Drawing.Size(100, 35)
        Me.btAgregar.TabIndex = 4
        Me.btAgregar.Text = "Agregar"
        Me.btAgregar.UseVisualStyleBackColor = True
        '
        'txApellidoMat
        '
        Me.txApellidoMat.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txApellidoMat.Location = New System.Drawing.Point(170, 82)
        Me.txApellidoMat.MaxLength = 30
        Me.txApellidoMat.Name = "txApellidoMat"
        Me.txApellidoMat.Size = New System.Drawing.Size(296, 23)
        Me.txApellidoMat.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(82, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 16)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Ap Materno"
        '
        'txNombre
        '
        Me.txNombre.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txNombre.Location = New System.Drawing.Point(170, 24)
        Me.txNombre.MaxLength = 30
        Me.txNombre.Name = "txNombre"
        Me.txNombre.Size = New System.Drawing.Size(296, 23)
        Me.txNombre.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(85, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 16)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Ap Paterno"
        '
        'txApellidoPat
        '
        Me.txApellidoPat.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txApellidoPat.Location = New System.Drawing.Point(170, 53)
        Me.txApellidoPat.MaxLength = 30
        Me.txApellidoPat.Name = "txApellidoPat"
        Me.txApellidoPat.Size = New System.Drawing.Size(296, 23)
        Me.txApellidoPat.TabIndex = 2
        '
        'lbNombre
        '
        Me.lbNombre.AutoSize = True
        Me.lbNombre.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNombre.Location = New System.Drawing.Point(109, 28)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(57, 16)
        Me.lbNombre.TabIndex = 26
        Me.lbNombre.Text = "Nombre"
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
        'gpoAut
        '
        Me.gpoAut.Controls.Add(Me.btGuardar)
        Me.gpoAut.Controls.Add(Me.gvAutorizados)
        Me.gpoAut.Controls.Add(Me.btEliminar)
        Me.gpoAut.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpoAut.Location = New System.Drawing.Point(8, 138)
        Me.gpoAut.Name = "gpoAut"
        Me.gpoAut.Size = New System.Drawing.Size(862, 226)
        Me.gpoAut.TabIndex = 1
        Me.gpoAut.TabStop = False
        Me.gpoAut.Text = "Autorizados asignados a esta cuenta"
        '
        'gvAutorizados
        '
        Me.gvAutorizados.AllowUserToAddRows = False
        Me.gvAutorizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvAutorizados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Autorizado, Me.Nombre, Me.ApellidoPat, Me.ApellidoMat})
        Me.gvAutorizados.Location = New System.Drawing.Point(8, 22)
        Me.gvAutorizados.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.gvAutorizados.Name = "gvAutorizados"
        Me.gvAutorizados.ReadOnly = True
        Me.gvAutorizados.RowTemplate.Height = 24
        Me.gvAutorizados.Size = New System.Drawing.Size(729, 194)
        Me.gvAutorizados.TabIndex = 5
        '
        'Autorizado
        '
        Me.Autorizado.DataPropertyName = "AUTORIZADO"
        Me.Autorizado.HeaderText = "Autorizado"
        Me.Autorizado.Name = "Autorizado"
        Me.Autorizado.ReadOnly = True
        Me.Autorizado.Visible = False
        '
        'Nombre
        '
        Me.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Nombre.DataPropertyName = "NOMBRE"
        Me.Nombre.FillWeight = 240.0!
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 240
        '
        'ApellidoPat
        '
        Me.ApellidoPat.DataPropertyName = "APELLIDOPAT"
        Me.ApellidoPat.FillWeight = 240.0!
        Me.ApellidoPat.HeaderText = "Apellido Paterno"
        Me.ApellidoPat.Name = "ApellidoPat"
        Me.ApellidoPat.ReadOnly = True
        Me.ApellidoPat.Width = 240
        '
        'ApellidoMat
        '
        Me.ApellidoMat.DataPropertyName = "APELLIDOMAT"
        Me.ApellidoMat.FillWeight = 240.0!
        Me.ApellidoMat.HeaderText = "Apellido Materno"
        Me.ApellidoMat.Name = "ApellidoMat"
        Me.ApellidoMat.ReadOnly = True
        Me.ApellidoMat.Width = 240
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
        'CapAutorizados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(879, 415)
        Me.Controls.Add(Me.btCerrar)
        Me.Controls.Add(Me.gpoAut)
        Me.Controls.Add(Me.gpoAutNvo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CapAutorizados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de  Autorizados"
        Me.gpoAutNvo.ResumeLayout(False)
        Me.gpoAutNvo.PerformLayout()
        Me.gpoAut.ResumeLayout(False)
        CType(Me.gvAutorizados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gpoAutNvo As GroupBox
    Friend WithEvents btAgregar As Button
    Friend WithEvents txApellidoMat As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txNombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txApellidoPat As TextBox
    Friend WithEvents lbNombre As Label
    Friend WithEvents gpoAut As GroupBox
    Friend WithEvents btEliminar As Button
    Friend WithEvents btCerrar As Button
    Friend WithEvents gvAutorizados As DataGridView
    Friend WithEvents btGuardar As Button
    Friend WithEvents Autorizado As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents ApellidoPat As DataGridViewTextBoxColumn
    Friend WithEvents ApellidoMat As DataGridViewTextBoxColumn
End Class
