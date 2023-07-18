<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuApp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenuApp))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbGos = New System.Windows.Forms.RadioButton()
        Me.rbBack = New System.Windows.Forms.RadioButton()
        Me.rbMesa = New System.Windows.Forms.RadioButton()
        Me.rbTicket = New System.Windows.Forms.RadioButton()
        Me.cmdGenerar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbGos)
        Me.GroupBox1.Controls.Add(Me.rbBack)
        Me.GroupBox1.Controls.Add(Me.rbMesa)
        Me.GroupBox1.Controls.Add(Me.rbTicket)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(21, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(454, 128)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selecciona la aplicación a obtener el reporte"
        '
        'rbGos
        '
        Me.rbGos.AutoSize = True
        Me.rbGos.Location = New System.Drawing.Point(289, 84)
        Me.rbGos.Name = "rbGos"
        Me.rbGos.Size = New System.Drawing.Size(75, 26)
        Me.rbGos.TabIndex = 3
        Me.rbGos.TabStop = True
        Me.rbGos.Text = "GOS"
        Me.rbGos.UseVisualStyleBackColor = True
        Me.rbGos.Visible = False
        '
        'rbBack
        '
        Me.rbBack.AutoSize = True
        Me.rbBack.Location = New System.Drawing.Point(289, 37)
        Me.rbBack.Name = "rbBack"
        Me.rbBack.Size = New System.Drawing.Size(75, 26)
        Me.rbBack.TabIndex = 2
        Me.rbBack.TabStop = True
        Me.rbBack.Text = "Back"
        Me.rbBack.UseVisualStyleBackColor = True
        '
        'rbMesa
        '
        Me.rbMesa.AutoSize = True
        Me.rbMesa.Location = New System.Drawing.Point(38, 82)
        Me.rbMesa.Name = "rbMesa"
        Me.rbMesa.Size = New System.Drawing.Size(78, 26)
        Me.rbMesa.TabIndex = 1
        Me.rbMesa.TabStop = True
        Me.rbMesa.Text = "Mesa"
        Me.rbMesa.UseVisualStyleBackColor = True
        '
        'rbTicket
        '
        Me.rbTicket.AutoSize = True
        Me.rbTicket.Location = New System.Drawing.Point(38, 37)
        Me.rbTicket.Name = "rbTicket"
        Me.rbTicket.Size = New System.Drawing.Size(214, 26)
        Me.rbTicket.TabIndex = 0
        Me.rbTicket.TabStop = True
        Me.rbTicket.Text = "TicketComplementario"
        Me.rbTicket.UseVisualStyleBackColor = True
        '
        'cmdGenerar
        '
        Me.cmdGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerar.Location = New System.Drawing.Point(492, 94)
        Me.cmdGenerar.Name = "cmdGenerar"
        Me.cmdGenerar.Size = New System.Drawing.Size(99, 46)
        Me.cmdGenerar.TabIndex = 1
        Me.cmdGenerar.Text = "&Generar"
        Me.cmdGenerar.UseVisualStyleBackColor = True
        '
        'frmMenuApp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(606, 162)
        Me.Controls.Add(Me.cmdGenerar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMenuApp"
        Me.Text = "Selecciona aplicativo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbGos As RadioButton
    Friend WithEvents rbBack As RadioButton
    Friend WithEvents rbMesa As RadioButton
    Friend WithEvents rbTicket As RadioButton
    Friend WithEvents cmdGenerar As Button
End Class
