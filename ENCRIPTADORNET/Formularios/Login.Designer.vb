<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txPass = New System.Windows.Forms.TextBox()
        Me.txLogin = New System.Windows.Forms.TextBox()
        Me.lbPass = New System.Windows.Forms.Label()
        Me.lbLogin = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btCancelar = New System.Windows.Forms.Button()
        Me.btAceptar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txPass)
        Me.GroupBox1.Controls.Add(Me.txLogin)
        Me.GroupBox1.Controls.Add(Me.lbPass)
        Me.GroupBox1.Controls.Add(Me.lbLogin)
        Me.GroupBox1.Location = New System.Drawing.Point(8, -2)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(432, 172)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txPass
        '
        Me.txPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txPass.Location = New System.Drawing.Point(212, 102)
        Me.txPass.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txPass.MaxLength = 14
        Me.txPass.Name = "txPass"
        Me.txPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txPass.Size = New System.Drawing.Size(181, 29)
        Me.txPass.TabIndex = 3
        Me.txPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txLogin
        '
        Me.txLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txLogin.Location = New System.Drawing.Point(212, 37)
        Me.txLogin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txLogin.Name = "txLogin"
        Me.txLogin.Size = New System.Drawing.Size(181, 29)
        Me.txLogin.TabIndex = 2
        Me.txLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbPass
        '
        Me.lbPass.AutoSize = True
        Me.lbPass.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPass.ForeColor = System.Drawing.Color.Navy
        Me.lbPass.Location = New System.Drawing.Point(36, 102)
        Me.lbPass.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbPass.Name = "lbPass"
        Me.lbPass.Size = New System.Drawing.Size(144, 29)
        Me.lbPass.TabIndex = 1
        Me.lbPass.Text = "Password"
        '
        'lbLogin
        '
        Me.lbLogin.AutoSize = True
        Me.lbLogin.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLogin.ForeColor = System.Drawing.Color.Navy
        Me.lbLogin.Location = New System.Drawing.Point(86, 40)
        Me.lbLogin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbLogin.Name = "lbLogin"
        Me.lbLogin.Size = New System.Drawing.Size(86, 29)
        Me.lbLogin.TabIndex = 0
        Me.lbLogin.Text = "Login"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btCancelar)
        Me.GroupBox2.Controls.Add(Me.btAceptar)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 168)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(432, 85)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'btCancelar
        '
        Me.btCancelar.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.btCancelar.FlatAppearance.BorderSize = 2
        Me.btCancelar.Location = New System.Drawing.Point(225, 22)
        Me.btCancelar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(182, 51)
        Me.btCancelar.TabIndex = 1
        Me.btCancelar.Text = "Cancelar"
        Me.btCancelar.UseVisualStyleBackColor = False
        '
        'btAceptar
        '
        Me.btAceptar.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btAceptar.Location = New System.Drawing.Point(22, 22)
        Me.btAceptar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(182, 51)
        Me.btAceptar.TabIndex = 0
        Me.btAceptar.Text = "Aceptar"
        Me.btAceptar.UseVisualStyleBackColor = False
        '
        'Login
        '
        Me.AcceptButton = Me.btAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(447, 257)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ticket Electronico Modulo Complementario"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btCancelar As Button
    Friend WithEvents btAceptar As Button
    Friend WithEvents txPass As TextBox
    Friend WithEvents txLogin As TextBox
    Friend WithEvents lbPass As Label
    Friend WithEvents lbLogin As Label
End Class
