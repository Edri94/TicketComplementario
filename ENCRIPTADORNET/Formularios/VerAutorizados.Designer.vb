<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VerAutorizados
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VerAutorizados))
        Me.gpoAut = New System.Windows.Forms.GroupBox()
        Me.gvAutorizados = New System.Windows.Forms.DataGridView()
        Me.btCerrar = New System.Windows.Forms.Button()
        Me.Autorizado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.APELLIDOPAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.APELLIDOMAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gpoAut.SuspendLayout()
        CType(Me.gvAutorizados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpoAut
        '
        Me.gpoAut.Controls.Add(Me.gvAutorizados)
        Me.gpoAut.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpoAut.Location = New System.Drawing.Point(4, 12)
        Me.gpoAut.Name = "gpoAut"
        Me.gpoAut.Size = New System.Drawing.Size(714, 196)
        Me.gpoAut.TabIndex = 38
        Me.gpoAut.TabStop = False
        Me.gpoAut.Text = "Autorizados asignados a esta cuenta"
        '
        'gvAutorizados
        '
        Me.gvAutorizados.AllowUserToAddRows = False
        Me.gvAutorizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvAutorizados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Autorizado, Me.Nombre, Me.APELLIDOPAT, Me.APELLIDOMAT})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvAutorizados.DefaultCellStyle = DataGridViewCellStyle1
        Me.gvAutorizados.Location = New System.Drawing.Point(5, 20)
        Me.gvAutorizados.Margin = New System.Windows.Forms.Padding(2)
        Me.gvAutorizados.Name = "gvAutorizados"
        Me.gvAutorizados.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvAutorizados.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gvAutorizados.RowTemplate.Height = 24
        Me.gvAutorizados.Size = New System.Drawing.Size(704, 171)
        Me.gvAutorizados.TabIndex = 34
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
        'Autorizado
        '
        Me.Autorizado.DataPropertyName = "AUTORIZADO"
        Me.Autorizado.FillWeight = 40.0!
        Me.Autorizado.HeaderText = "Apoderado"
        Me.Autorizado.Name = "Autorizado"
        Me.Autorizado.ReadOnly = True
        Me.Autorizado.Visible = False
        Me.Autorizado.Width = 80
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
        'VerAutorizados
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
        Me.Name = "VerAutorizados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Autorizados"
        Me.gpoAut.ResumeLayout(False)
        CType(Me.gvAutorizados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gpoAut As GroupBox
    Friend WithEvents btCerrar As Button
    Friend WithEvents gvAutorizados As DataGridView
    Friend WithEvents Autorizado As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents APELLIDOPAT As DataGridViewTextBoxColumn
    Friend WithEvents APELLIDOMAT As DataGridViewTextBoxColumn
End Class
