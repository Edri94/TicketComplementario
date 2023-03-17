<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Bloqueo_DesbloqueoCtas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Bloqueo_DesbloqueoCtas))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSufijo = New System.Windows.Forms.TextBox()
        Me.lbCtaRestringida = New System.Windows.Forms.Label()
        Me.cmbAgencia = New System.Windows.Forms.ComboBox()
        Me.lbAgencia = New System.Windows.Forms.Label()
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.lbCuenta = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optRBloqueada = New System.Windows.Forms.RadioButton()
        Me.optRActiva = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkAlerta = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ChkLstBloqueos = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCausaBloqueo = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ChkLstAlertas = New System.Windows.Forms.CheckedListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCausaAlerta = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.LblCtaFideicomiso = New System.Windows.Forms.Label()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtSufijo)
        Me.GroupBox1.Controls.Add(Me.lbCtaRestringida)
        Me.GroupBox1.Controls.Add(Me.cmbAgencia)
        Me.GroupBox1.Controls.Add(Me.lbAgencia)
        Me.GroupBox1.Controls.Add(Me.txtCuenta)
        Me.GroupBox1.Controls.Add(Me.lbCuenta)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 14)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(1401, 111)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(304, 43)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 25)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Sufijo:"
        '
        'txtSufijo
        '
        Me.txtSufijo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSufijo.Location = New System.Drawing.Point(390, 37)
        Me.txtSufijo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSufijo.Name = "txtSufijo"
        Me.txtSufijo.Size = New System.Drawing.Size(73, 30)
        Me.txtSufijo.TabIndex = 5
        '
        'lbCtaRestringida
        '
        Me.lbCtaRestringida.AutoSize = True
        Me.lbCtaRestringida.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCtaRestringida.Location = New System.Drawing.Point(1164, 77)
        Me.lbCtaRestringida.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCtaRestringida.Name = "lbCtaRestringida"
        Me.lbCtaRestringida.Size = New System.Drawing.Size(190, 20)
        Me.lbCtaRestringida.TabIndex = 4
        Me.lbCtaRestringida.Text = "Cuenta Restringida"
        '
        'cmbAgencia
        '
        Me.cmbAgencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAgencia.FormattingEnabled = True
        Me.cmbAgencia.Location = New System.Drawing.Point(603, 37)
        Me.cmbAgencia.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbAgencia.Name = "cmbAgencia"
        Me.cmbAgencia.Size = New System.Drawing.Size(756, 33)
        Me.cmbAgencia.TabIndex = 3
        '
        'lbAgencia
        '
        Me.lbAgencia.AutoSize = True
        Me.lbAgencia.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAgencia.Location = New System.Drawing.Point(498, 43)
        Me.lbAgencia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbAgencia.Name = "lbAgencia"
        Me.lbAgencia.Size = New System.Drawing.Size(116, 25)
        Me.lbAgencia.TabIndex = 2
        Me.lbAgencia.Text = "Agencia: "
        '
        'txtCuenta
        '
        Me.txtCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta.Location = New System.Drawing.Point(118, 37)
        Me.txtCuenta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(146, 30)
        Me.txtCuenta.TabIndex = 1
        '
        'lbCuenta
        '
        Me.lbCuenta.AutoSize = True
        Me.lbCuenta.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCuenta.Location = New System.Drawing.Point(26, 43)
        Me.lbCuenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCuenta.Name = "lbCuenta"
        Me.lbCuenta.Size = New System.Drawing.Size(104, 25)
        Me.lbCuenta.TabIndex = 0
        Me.lbCuenta.Text = "Cuenta: "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optRBloqueada)
        Me.GroupBox2.Controls.Add(Me.optRActiva)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Controls.Add(Me.chkAlerta)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 134)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(1400, 66)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'optRBloqueada
        '
        Me.optRBloqueada.AutoSize = True
        Me.optRBloqueada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optRBloqueada.Location = New System.Drawing.Point(387, 20)
        Me.optRBloqueada.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optRBloqueada.Name = "optRBloqueada"
        Me.optRBloqueada.Size = New System.Drawing.Size(216, 29)
        Me.optRBloqueada.TabIndex = 5
        Me.optRBloqueada.TabStop = True
        Me.optRBloqueada.Text = "Cuenta Bloqueada"
        Me.optRBloqueada.UseVisualStyleBackColor = True
        '
        'optRActiva
        '
        Me.optRActiva.AutoSize = True
        Me.optRActiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optRActiva.Location = New System.Drawing.Point(74, 20)
        Me.optRActiva.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optRActiva.Name = "optRActiva"
        Me.optRActiva.Size = New System.Drawing.Size(173, 29)
        Me.optRActiva.TabIndex = 4
        Me.optRActiva.TabStop = True
        Me.optRActiva.Text = "Cuenta Activa"
        Me.optRActiva.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel1.Location = New System.Drawing.Point(692, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(15, 549)
        Me.Panel1.TabIndex = 3
        '
        'chkAlerta
        '
        Me.chkAlerta.AutoSize = True
        Me.chkAlerta.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAlerta.Location = New System.Drawing.Point(966, 22)
        Me.chkAlerta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkAlerta.Name = "chkAlerta"
        Me.chkAlerta.Size = New System.Drawing.Size(224, 29)
        Me.chkAlerta.TabIndex = 2
        Me.chkAlerta.Text = "Cuenta en Alerta"
        Me.chkAlerta.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChkLstBloqueos)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtCausaBloqueo)
        Me.GroupBox3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(16, 209)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Size = New System.Drawing.Size(690, 466)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Bloqueo de cuentas"
        '
        'ChkLstBloqueos
        '
        Me.ChkLstBloqueos.FormattingEnabled = True
        Me.ChkLstBloqueos.Location = New System.Drawing.Point(24, 34)
        Me.ChkLstBloqueos.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ChkLstBloqueos.Name = "ChkLstBloqueos"
        Me.ChkLstBloqueos.Size = New System.Drawing.Size(643, 212)
        Me.ChkLstBloqueos.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 266)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(212, 25)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Causa del bloqueo: "
        '
        'txtCausaBloqueo
        '
        Me.txtCausaBloqueo.Location = New System.Drawing.Point(24, 291)
        Me.txtCausaBloqueo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCausaBloqueo.Multiline = True
        Me.txtCausaBloqueo.Name = "txtCausaBloqueo"
        Me.txtCausaBloqueo.Size = New System.Drawing.Size(643, 159)
        Me.txtCausaBloqueo.TabIndex = 1
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ChkLstAlertas)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.txtCausaAlerta)
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(728, 209)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox4.Size = New System.Drawing.Size(690, 466)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Cuenta en Alerta"
        '
        'ChkLstAlertas
        '
        Me.ChkLstAlertas.FormattingEnabled = True
        Me.ChkLstAlertas.Location = New System.Drawing.Point(20, 34)
        Me.ChkLstAlertas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ChkLstAlertas.Name = "ChkLstAlertas"
        Me.ChkLstAlertas.Size = New System.Drawing.Size(654, 212)
        Me.ChkLstAlertas.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 266)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(204, 25)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Causa de la alerta:"
        '
        'txtCausaAlerta
        '
        Me.txtCausaAlerta.Location = New System.Drawing.Point(20, 291)
        Me.txtCausaAlerta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCausaAlerta.Multiline = True
        Me.txtCausaAlerta.Name = "txtCausaAlerta"
        Me.txtCausaAlerta.Size = New System.Drawing.Size(654, 159)
        Me.txtCausaAlerta.TabIndex = 2
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.LblCtaFideicomiso)
        Me.GroupBox5.Controls.Add(Me.cmdSalir)
        Me.GroupBox5.Controls.Add(Me.cmdGuardar)
        Me.GroupBox5.Location = New System.Drawing.Point(16, 682)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox5.Size = New System.Drawing.Size(1401, 91)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        '
        'LblCtaFideicomiso
        '
        Me.LblCtaFideicomiso.AutoSize = True
        Me.LblCtaFideicomiso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCtaFideicomiso.ForeColor = System.Drawing.Color.Blue
        Me.LblCtaFideicomiso.Location = New System.Drawing.Point(28, 37)
        Me.LblCtaFideicomiso.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCtaFideicomiso.Name = "LblCtaFideicomiso"
        Me.LblCtaFideicomiso.Size = New System.Drawing.Size(292, 25)
        Me.LblCtaFideicomiso.TabIndex = 2
        Me.LblCtaFideicomiso.Text = "La Cuenta es un Fideicomiso"
        '
        'cmdSalir
        '
        Me.cmdSalir.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalir.Location = New System.Drawing.Point(1232, 22)
        Me.cmdSalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(150, 54)
        Me.cmdSalir.TabIndex = 1
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardar.Location = New System.Drawing.Point(1032, 22)
        Me.cmdGuardar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(150, 54)
        Me.cmdGuardar.TabIndex = 0
        Me.cmdGuardar.Text = "Guardar"
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'Bloqueo_DesbloqueoCtas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1434, 782)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Bloqueo_DesbloqueoCtas"
        Me.Text = "Bloqueo/Desbloqueo y Alertamiento de Cuentas CED"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lbAgencia As Label
    Friend WithEvents txtCuenta As TextBox
    Friend WithEvents lbCuenta As Label
    Friend WithEvents cmbAgencia As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkAlerta As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCausaBloqueo As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCausaAlerta As TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents cmdSalir As Button
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents lbCtaRestringida As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSufijo As TextBox
    Friend WithEvents ChkLstAlertas As CheckedListBox
    Friend WithEvents ChkLstBloqueos As CheckedListBox
    Friend WithEvents LblCtaFideicomiso As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents optRBloqueada As RadioButton
    Friend WithEvents optRActiva As RadioButton
End Class
