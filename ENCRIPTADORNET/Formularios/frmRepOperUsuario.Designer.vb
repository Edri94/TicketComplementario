<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepOperUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepOperUsuario))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkTodos = New System.Windows.Forms.CheckBox()
        Me.cmbListaUsuarios = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.cmdConsultar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFechaFin = New System.Windows.Forms.TextBox()
        Me.txtFechaIni = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgvOperxUsuario = New System.Windows.Forms.DataGridView()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvOperxUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkTodos)
        Me.GroupBox1.Controls.Add(Me.cmbListaUsuarios)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(18, 18)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(626, 171)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Usuario"
        '
        'chkTodos
        '
        Me.chkTodos.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkTodos.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.chkTodos.Location = New System.Drawing.Point(447, 32)
        Me.chkTodos.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(150, 54)
        Me.chkTodos.TabIndex = 2
        Me.chkTodos.Text = "Todos"
        Me.chkTodos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkTodos.UseVisualStyleBackColor = False
        '
        'cmbListaUsuarios
        '
        Me.cmbListaUsuarios.FormattingEnabled = True
        Me.cmbListaUsuarios.Location = New System.Drawing.Point(22, 108)
        Me.cmbListaUsuarios.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbListaUsuarios.Name = "cmbListaUsuarios"
        Me.cmbListaUsuarios.Size = New System.Drawing.Size(572, 32)
        Me.cmbListaUsuarios.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdImprimir)
        Me.GroupBox2.Controls.Add(Me.cmdConsultar)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtFechaFin)
        Me.GroupBox2.Controls.Add(Me.txtFechaIni)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(662, 18)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(824, 171)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fecha de Consulta"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cmdImprimir.Location = New System.Drawing.Point(640, 60)
        Me.cmdImprimir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(150, 54)
        Me.cmdImprimir.TabIndex = 7
        Me.cmdImprimir.Text = "Imprimir"
        Me.cmdImprimir.UseVisualStyleBackColor = False
        '
        'cmdConsultar
        '
        Me.cmdConsultar.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cmdConsultar.Location = New System.Drawing.Point(459, 60)
        Me.cmdConsultar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdConsultar.Name = "cmdConsultar"
        Me.cmdConsultar.Size = New System.Drawing.Size(150, 54)
        Me.cmdConsultar.TabIndex = 6
        Me.cmdConsultar.Text = "Consultar"
        Me.cmdConsultar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(218, 108)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 24)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "(yyyy-mm-dd)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 108)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 24)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "(yyyy-mm-dd)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 48)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Final"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 48)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Inicial"
        '
        'txtFechaFin
        '
        Me.txtFechaFin.Location = New System.Drawing.Point(212, 72)
        Me.txtFechaFin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.Size = New System.Drawing.Size(148, 29)
        Me.txtFechaFin.TabIndex = 1
        '
        'txtFechaIni
        '
        Me.txtFechaIni.Location = New System.Drawing.Point(27, 72)
        Me.txtFechaIni.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFechaIni.Name = "txtFechaIni"
        Me.txtFechaIni.Size = New System.Drawing.Size(148, 29)
        Me.txtFechaIni.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvOperxUsuario)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(18, 198)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Size = New System.Drawing.Size(1467, 572)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Resultados"
        '
        'dgvOperxUsuario
        '
        Me.dgvOperxUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOperxUsuario.Location = New System.Drawing.Point(73, 31)
        Me.dgvOperxUsuario.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvOperxUsuario.Name = "dgvOperxUsuario"
        Me.dgvOperxUsuario.RowHeadersWidth = 62
        Me.dgvOperxUsuario.Size = New System.Drawing.Size(1442, 531)
        Me.dgvOperxUsuario.TabIndex = 0
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(1302, 794)
        Me.cmdSalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(150, 54)
        Me.cmdSalir.TabIndex = 3
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'frmRepOperUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1503, 866)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmRepOperUsuario"
        Me.Text = "Reporte Operaciones por Usuario"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvOperxUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbListaUsuarios As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFechaFin As TextBox
    Friend WithEvents txtFechaIni As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cmdImprimir As Button
    Friend WithEvents cmdConsultar As Button
    Friend WithEvents cmdSalir As Button
    Friend WithEvents dgvOperxUsuario As DataGridView
    Friend WithEvents chkTodos As CheckBox
End Class
