<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CancelacionCtas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CancelacionCtas))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dllAgencia = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txSufijo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txCuenta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optCancelada = New System.Windows.Forms.RadioButton()
        Me.optBloqueada = New System.Windows.Forms.RadioButton()
        Me.optActiva = New System.Windows.Forms.RadioButton()
        Me.gTituloCausa = New System.Windows.Forms.GroupBox()
        Me.txCausa = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btSalir = New System.Windows.Forms.Button()
        Me.btActualizar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gTituloCausa.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dllAgencia)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txSufijo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txCuenta)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 5)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(1060, 109)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'dllAgencia
        '
        Me.dllAgencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dllAgencia.FormattingEnabled = True
        Me.dllAgencia.Location = New System.Drawing.Point(246, 55)
        Me.dllAgencia.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dllAgencia.Name = "dllAgencia"
        Me.dllAgencia.Size = New System.Drawing.Size(793, 32)
        Me.dllAgencia.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(244, 26)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 24)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Agencia"
        '
        'txSufijo
        '
        Me.txSufijo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txSufijo.Location = New System.Drawing.Point(153, 55)
        Me.txSufijo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txSufijo.MaxLength = 3
        Me.txSufijo.Name = "txSufijo"
        Me.txSufijo.Size = New System.Drawing.Size(70, 29)
        Me.txSufijo.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(150, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Sufijo"
        '
        'txCuenta
        '
        Me.txCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCuenta.Location = New System.Drawing.Point(20, 55)
        Me.txCuenta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txCuenta.MaxLength = 6
        Me.txCuenta.Name = "txCuenta"
        Me.txCuenta.Size = New System.Drawing.Size(108, 29)
        Me.txCuenta.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cuenta"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optCancelada)
        Me.GroupBox2.Controls.Add(Me.optBloqueada)
        Me.GroupBox2.Controls.Add(Me.optActiva)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 117)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(1060, 98)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'optCancelada
        '
        Me.optCancelada.Appearance = System.Windows.Forms.Appearance.Button
        Me.optCancelada.Enabled = False
        Me.optCancelada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optCancelada.Location = New System.Drawing.Point(771, 25)
        Me.optCancelada.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optCancelada.Name = "optCancelada"
        Me.optCancelada.Size = New System.Drawing.Size(225, 54)
        Me.optCancelada.TabIndex = 6
        Me.optCancelada.TabStop = True
        Me.optCancelada.Text = "Cuenta Cancelada"
        Me.optCancelada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optCancelada.UseVisualStyleBackColor = True
        '
        'optBloqueada
        '
        Me.optBloqueada.Appearance = System.Windows.Forms.Appearance.Button
        Me.optBloqueada.Enabled = False
        Me.optBloqueada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optBloqueada.Location = New System.Drawing.Point(424, 25)
        Me.optBloqueada.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optBloqueada.Name = "optBloqueada"
        Me.optBloqueada.Size = New System.Drawing.Size(225, 54)
        Me.optBloqueada.TabIndex = 5
        Me.optBloqueada.TabStop = True
        Me.optBloqueada.Text = "Cuenta Bloqueada"
        Me.optBloqueada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optBloqueada.UseVisualStyleBackColor = True
        '
        'optActiva
        '
        Me.optActiva.Appearance = System.Windows.Forms.Appearance.Button
        Me.optActiva.Enabled = False
        Me.optActiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optActiva.Location = New System.Drawing.Point(68, 25)
        Me.optActiva.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optActiva.Name = "optActiva"
        Me.optActiva.Size = New System.Drawing.Size(225, 54)
        Me.optActiva.TabIndex = 4
        Me.optActiva.TabStop = True
        Me.optActiva.Text = "Cuenta Activa"
        Me.optActiva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optActiva.UseVisualStyleBackColor = True
        '
        'gTituloCausa
        '
        Me.gTituloCausa.Controls.Add(Me.txCausa)
        Me.gTituloCausa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gTituloCausa.Location = New System.Drawing.Point(18, 217)
        Me.gTituloCausa.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gTituloCausa.Name = "gTituloCausa"
        Me.gTituloCausa.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gTituloCausa.Size = New System.Drawing.Size(1060, 169)
        Me.gTituloCausa.TabIndex = 2
        Me.gTituloCausa.TabStop = False
        Me.gTituloCausa.Text = "Causa"
        '
        'txCausa
        '
        Me.txCausa.Enabled = False
        Me.txCausa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCausa.Location = New System.Drawing.Point(16, 32)
        Me.txCausa.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txCausa.MaxLength = 100
        Me.txCausa.Multiline = True
        Me.txCausa.Name = "txCausa"
        Me.txCausa.Size = New System.Drawing.Size(1020, 119)
        Me.txCausa.TabIndex = 7
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btSalir)
        Me.GroupBox4.Controls.Add(Me.btActualizar)
        Me.GroupBox4.Location = New System.Drawing.Point(20, 389)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox4.Size = New System.Drawing.Size(1059, 85)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        '
        'btSalir
        '
        Me.btSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSalir.Location = New System.Drawing.Point(888, 20)
        Me.btSalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btSalir.Name = "btSalir"
        Me.btSalir.Size = New System.Drawing.Size(150, 54)
        Me.btSalir.TabIndex = 9
        Me.btSalir.Text = "Salir"
        Me.btSalir.UseVisualStyleBackColor = True
        '
        'btActualizar
        '
        Me.btActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btActualizar.Location = New System.Drawing.Point(714, 20)
        Me.btActualizar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btActualizar.Name = "btActualizar"
        Me.btActualizar.Size = New System.Drawing.Size(150, 54)
        Me.btActualizar.TabIndex = 8
        Me.btActualizar.Text = "Actualizar"
        Me.btActualizar.UseVisualStyleBackColor = True
        '
        'CancelacionCtas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1092, 491)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.gTituloCausa)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "CancelacionCtas"
        Me.Text = "Cancelación / Reactivación de Cuentas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.gTituloCausa.ResumeLayout(False)
        Me.gTituloCausa.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txSufijo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txCuenta As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dllAgencia As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents optCancelada As RadioButton
    Friend WithEvents optActiva As RadioButton
    Friend WithEvents gTituloCausa As GroupBox
    Friend WithEvents txCausa As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btSalir As Button
    Friend WithEvents btActualizar As Button
    Friend WithEvents optBloqueada As RadioButton
End Class
