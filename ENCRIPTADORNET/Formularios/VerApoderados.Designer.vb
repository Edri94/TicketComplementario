<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VerApoderados
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VerApoderados))
        Me.gpoAut = New System.Windows.Forms.GroupBox()
        Me.gvApoderados = New System.Windows.Forms.DataGridView()
        Me.btCerrar = New System.Windows.Forms.Button()
        Me.Apoderado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.APELLIDOPAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.APELLIDOMAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gpoAut.SuspendLayout()
        CType(Me.gvApoderados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpoAut
        '
        Me.gpoAut.Controls.Add(Me.gvApoderados)
        Me.gpoAut.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpoAut.Location = New System.Drawing.Point(4, 12)
        Me.gpoAut.Name = "gpoAut"
        Me.gpoAut.Size = New System.Drawing.Size(714, 196)
        Me.gpoAut.TabIndex = 37
        Me.gpoAut.TabStop = False
        Me.gpoAut.Text = "Apoderados asignados a esta cuenta"
        '
        'gvApoderados
        '
        Me.gvApoderados.AllowUserToAddRows = False
        Me.gvApoderados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvApoderados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Apoderado, Me.Nombre, Me.APELLIDOPAT, Me.APELLIDOMAT})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvApoderados.DefaultCellStyle = DataGridViewCellStyle1
        Me.gvApoderados.Location = New System.Drawing.Point(5, 20)
        Me.gvApoderados.Margin = New System.Windows.Forms.Padding(2)
        Me.gvApoderados.Name = "gvApoderados"
        Me.gvApoderados.ReadOnly = True
        Me.gvApoderados.RowTemplate.Height = 24
        Me.gvApoderados.Size = New System.Drawing.Size(704, 171)
        Me.gvApoderados.TabIndex = 34
        '
        'btCerrar
        '
        Me.btCerrar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCerrar.Location = New System.Drawing.Point(613, 214)
        Me.btCerrar.Name = "btCerrar"
        Me.btCerrar.Size = New System.Drawing.Size(100, 35)
        Me.btCerrar.TabIndex = 38
        Me.btCerrar.Text = "Cerrar"
        Me.btCerrar.UseVisualStyleBackColor = True
        '
        'Apoderado
        '
        Me.Apoderado.DataPropertyName = "APODERADO"
        Me.Apoderado.FillWeight = 80.0!
        Me.Apoderado.HeaderText = "Apoderado"
        Me.Apoderado.Name = "Apoderado"
        Me.Apoderado.ReadOnly = True
        Me.Apoderado.Visible = False
        Me.Apoderado.Width = 80
        '
        'Nombre
        '
        Me.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Nombre.DataPropertyName = "NOMBRE"
        Me.Nombre.FillWeight = 220.0!
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 220
        '
        'APELLIDOPAT
        '
        Me.APELLIDOPAT.DataPropertyName = "APELLIDOPAT"
        Me.APELLIDOPAT.FillWeight = 220.0!
        Me.APELLIDOPAT.HeaderText = "Apellido Paterno"
        Me.APELLIDOPAT.Name = "APELLIDOPAT"
        Me.APELLIDOPAT.ReadOnly = True
        Me.APELLIDOPAT.Width = 220
        '
        'APELLIDOMAT
        '
        Me.APELLIDOMAT.DataPropertyName = "APELLIDOMAT"
        Me.APELLIDOMAT.FillWeight = 220.0!
        Me.APELLIDOMAT.HeaderText = "Apellido Materno"
        Me.APELLIDOMAT.Name = "APELLIDOMAT"
        Me.APELLIDOMAT.ReadOnly = True
        Me.APELLIDOMAT.Width = 220
        '
        'VerApoderados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(723, 256)
        Me.ControlBox = False
        Me.Controls.Add(Me.btCerrar)
        Me.Controls.Add(Me.gpoAut)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "VerApoderados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Apoderados"
        Me.gpoAut.ResumeLayout(False)
        CType(Me.gvApoderados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gpoAut As GroupBox
    Friend WithEvents gvApoderados As DataGridView
    Friend WithEvents btCerrar As Button
    Friend WithEvents Apoderado As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents APELLIDOPAT As DataGridViewTextBoxColumn
    Friend WithEvents APELLIDOMAT As DataGridViewTextBoxColumn
End Class
