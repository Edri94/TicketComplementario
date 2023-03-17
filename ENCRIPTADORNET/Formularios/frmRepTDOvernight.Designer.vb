<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepTDOvernight
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepTDOvernight))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdBuscar = New System.Windows.Forms.Button()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.cboAgencias = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstDatos = New System.Windows.Forms.DataGridView()
        Me.lblOps = New System.Windows.Forms.Label()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.lstDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdBuscar)
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Controls.Add(Me.cboAgencias)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(550, 123)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Operaciones"
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Location = New System.Drawing.Point(420, 70)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(104, 36)
        Me.cmdBuscar.TabIndex = 4
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "dd-mm-yyyy"
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(203, 76)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(200, 28)
        Me.dtpFecha.TabIndex = 3
        '
        'cboAgencias
        '
        Me.cboAgencias.FormattingEnabled = True
        Me.cboAgencias.Location = New System.Drawing.Point(106, 36)
        Me.cboAgencias.Name = "cboAgencias"
        Me.cboAgencias.Size = New System.Drawing.Size(200, 30)
        Me.cboAgencias.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(178, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fecha de Operación:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Agencia:"
        '
        'lstDatos
        '
        Me.lstDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.lstDatos.Location = New System.Drawing.Point(12, 136)
        Me.lstDatos.Name = "lstDatos"
        Me.lstDatos.RowHeadersWidth = 62
        Me.lstDatos.RowTemplate.Height = 28
        Me.lstDatos.Size = New System.Drawing.Size(550, 236)
        Me.lstDatos.TabIndex = 1
        '
        'lblOps
        '
        Me.lblOps.AutoSize = True
        Me.lblOps.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblOps.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblOps.Location = New System.Drawing.Point(31, 386)
        Me.lblOps.Name = "lblOps"
        Me.lblOps.Size = New System.Drawing.Size(189, 20)
        Me.lblOps.TabIndex = 5
        Me.lblOps.Text = "0 operacion(es) en la lista"
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(322, 378)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(104, 36)
        Me.cmdAceptar.TabIndex = 5
        Me.cmdAceptar.Text = "&Imprimir"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(432, 378)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(104, 36)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "&Salir"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmRepTDOvernight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(585, 424)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.lblOps)
        Me.Controls.Add(Me.lstDatos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRepTDOvernight"
        Me.Text = "Reporte de Operaciones de TD Overnight"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.lstDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmdBuscar As Button
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents cboAgencias As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lstDatos As DataGridView
    Friend WithEvents lblOps As Label
    Friend WithEvents cmdAceptar As Button
    Friend WithEvents cmdCancel As Button
End Class
