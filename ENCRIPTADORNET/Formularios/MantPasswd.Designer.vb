<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MantPasswd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MantPasswd))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.txtPasswd = New System.Windows.Forms.TextBox()
        Me.txtNvoPasswd = New System.Windows.Forms.TextBox()
        Me.txtConfPasswd = New System.Windows.Forms.TextBox()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(166, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Contraseña actual: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(166, 22)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nueva contraseña: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 157)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(186, 22)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Confirma contraseña: "
        '
        'txtLogin
        '
        Me.txtLogin.Location = New System.Drawing.Point(93, 22)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(347, 26)
        Me.txtLogin.TabIndex = 4
        '
        'txtPasswd
        '
        Me.txtPasswd.Location = New System.Drawing.Point(177, 56)
        Me.txtPasswd.MaxLength = 14
        Me.txtPasswd.Name = "txtPasswd"
        Me.txtPasswd.Size = New System.Drawing.Size(263, 26)
        Me.txtPasswd.TabIndex = 5
        Me.txtPasswd.UseSystemPasswordChar = True
        '
        'txtNvoPasswd
        '
        Me.txtNvoPasswd.Location = New System.Drawing.Point(177, 120)
        Me.txtNvoPasswd.MaxLength = 14
        Me.txtNvoPasswd.Name = "txtNvoPasswd"
        Me.txtNvoPasswd.Size = New System.Drawing.Size(263, 26)
        Me.txtNvoPasswd.TabIndex = 6
        Me.txtNvoPasswd.UseSystemPasswordChar = True
        '
        'txtConfPasswd
        '
        Me.txtConfPasswd.Location = New System.Drawing.Point(197, 153)
        Me.txtConfPasswd.MaxLength = 14
        Me.txtConfPasswd.Name = "txtConfPasswd"
        Me.txtConfPasswd.Size = New System.Drawing.Size(243, 26)
        Me.txtConfPasswd.TabIndex = 7
        Me.txtConfPasswd.UseSystemPasswordChar = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAceptar.Location = New System.Drawing.Point(471, 105)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(103, 41)
        Me.cmdAceptar.TabIndex = 8
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(471, 152)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(103, 41)
        Me.cmdCancelar.TabIndex = 9
        Me.cmdCancelar.Text = "&Salir"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'MantPasswd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(590, 203)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.txtConfPasswd)
        Me.Controls.Add(Me.txtNvoPasswd)
        Me.Controls.Add(Me.txtPasswd)
        Me.Controls.Add(Me.txtLogin)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MantPasswd"
        Me.Text = "Cambio de Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtLogin As TextBox
    Friend WithEvents txtPasswd As TextBox
    Friend WithEvents txtNvoPasswd As TextBox
    Friend WithEvents txtConfPasswd As TextBox
    Friend WithEvents cmdAceptar As Button
    Friend WithEvents cmdCancelar As Button
End Class
