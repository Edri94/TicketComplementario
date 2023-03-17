<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CapCotitulares
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CapCotitulares))
        Me.btCerrar = New System.Windows.Forms.Button()
        Me.gpoCot = New System.Windows.Forms.GroupBox()
        Me.btGuardar = New System.Windows.Forms.Button()
        Me.gvCotitulares = New System.Windows.Forms.DataGridView()
        Me.Cotitular = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.APELLIDOPAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.APELLIDOMAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btEliminar = New System.Windows.Forms.Button()
        Me.gpoCotNvo = New System.Windows.Forms.GroupBox()
        Me.btAgregar = New System.Windows.Forms.Button()
        Me.txApellidoMat = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txApellidoPat = New System.Windows.Forms.TextBox()
        Me.lbNombre = New System.Windows.Forms.Label()
        Me.gpoCot.SuspendLayout()
        CType(Me.gvCotitulares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpoCotNvo.SuspendLayout()
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
        'gpoCot
        '
        Me.gpoCot.Controls.Add(Me.btGuardar)
        Me.gpoCot.Controls.Add(Me.gvCotitulares)
        Me.gpoCot.Controls.Add(Me.btEliminar)
        Me.gpoCot.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpoCot.Location = New System.Drawing.Point(8, 138)
        Me.gpoCot.Name = "gpoCot"
        Me.gpoCot.Size = New System.Drawing.Size(862, 226)
        Me.gpoCot.TabIndex = 42
        Me.gpoCot.TabStop = False
        Me.gpoCot.Text = "Cotitulares asignados a esta cuenta"
        '
        'btGuardar
        '
        Me.btGuardar.Enabled = False
        Me.btGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGuardar.Location = New System.Drawing.Point(752, 45)
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(100, 35)
        Me.btGuardar.TabIndex = 6
        Me.btGuardar.Text = "Guardar"
        Me.btGuardar.UseVisualStyleBackColor = True
        '
        'gvCotitulares
        '
        Me.gvCotitulares.AllowUserToAddRows = False
        Me.gvCotitulares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCotitulares.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cotitular, Me.Nombre, Me.APELLIDOPAT, Me.APELLIDOMAT})
        Me.gvCotitulares.Location = New System.Drawing.Point(8, 22)
        Me.gvCotitulares.Margin = New System.Windows.Forms.Padding(2)
        Me.gvCotitulares.Name = "gvCotitulares"
        Me.gvCotitulares.RowTemplate.Height = 24
        Me.gvCotitulares.Size = New System.Drawing.Size(729, 194)
        Me.gvCotitulares.TabIndex = 5
        '
        'Cotitular
        '
        Me.Cotitular.DataPropertyName = "COTITULAR"
        Me.Cotitular.HeaderText = "Cotitular"
        Me.Cotitular.Name = "Cotitular"
        Me.Cotitular.Visible = False
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
        'gpoCotNvo
        '
        Me.gpoCotNvo.Controls.Add(Me.btAgregar)
        Me.gpoCotNvo.Controls.Add(Me.txApellidoMat)
        Me.gpoCotNvo.Controls.Add(Me.Label2)
        Me.gpoCotNvo.Controls.Add(Me.txNombre)
        Me.gpoCotNvo.Controls.Add(Me.Label1)
        Me.gpoCotNvo.Controls.Add(Me.txApellidoPat)
        Me.gpoCotNvo.Controls.Add(Me.lbNombre)
        Me.gpoCotNvo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpoCotNvo.Location = New System.Drawing.Point(7, 11)
        Me.gpoCotNvo.Name = "gpoCotNvo"
        Me.gpoCotNvo.Size = New System.Drawing.Size(863, 123)
        Me.gpoCotNvo.TabIndex = 41
        Me.gpoCotNvo.TabStop = False
        Me.gpoCotNvo.Text = "Nuevo Cotitular"
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
        Me.Label2.Location = New System.Drawing.Point(83, 85)
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
        Me.Label1.Location = New System.Drawing.Point(86, 56)
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
        Me.lbNombre.Location = New System.Drawing.Point(110, 26)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(57, 16)
        Me.lbNombre.TabIndex = 26
        Me.lbNombre.Text = "Nombre"
        '
        'CapCotitulares
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(879, 415)
        Me.Controls.Add(Me.btCerrar)
        Me.Controls.Add(Me.gpoCot)
        Me.Controls.Add(Me.gpoCotNvo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CapCotitulares"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de Cotitulares"
        Me.gpoCot.ResumeLayout(False)
        CType(Me.gvCotitulares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpoCotNvo.ResumeLayout(False)
        Me.gpoCotNvo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btCerrar As Button
    Friend WithEvents gpoCot As GroupBox
    Friend WithEvents gvCotitulares As DataGridView
    Friend WithEvents btEliminar As Button
    Friend WithEvents gpoCotNvo As GroupBox
    Friend WithEvents btAgregar As Button
    Friend WithEvents txApellidoMat As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txNombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txApellidoPat As TextBox
    Friend WithEvents lbNombre As Label
    Friend WithEvents btGuardar As Button
    Friend WithEvents Cotitular As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents APELLIDOPAT As DataGridViewTextBoxColumn
    Friend WithEvents APELLIDOMAT As DataGridViewTextBoxColumn
End Class
