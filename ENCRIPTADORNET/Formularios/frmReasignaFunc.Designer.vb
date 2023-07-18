<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReasignaFunc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReasignaFunc))
        Me.SSPanel1 = New System.Windows.Forms.GroupBox()
        Me.cmbCuentas = New System.Windows.Forms.ComboBox()
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fraFunc = New System.Windows.Forms.GroupBox()
        Me.lblUniGes = New System.Windows.Forms.Label()
        Me.lblCP = New System.Windows.Forms.Label()
        Me.lblUO = New System.Windows.Forms.Label()
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.lblCol = New System.Windows.Forms.Label()
        Me.lblCalle = New System.Windows.Forms.Label()
        Me.lblFax = New System.Windows.Forms.Label()
        Me.lblTel = New System.Windows.Forms.Label()
        Me.cmbFuncs = New System.Windows.Forms.ComboBox()
        Me.txtFunc = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdAsignar = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.pgbProgreso = New System.Windows.Forms.ProgressBar()
        Me.SSPanel1.SuspendLayout()
        Me.fraFunc.SuspendLayout()
        Me.SuspendLayout()
        '
        'SSPanel1
        '
        Me.SSPanel1.Controls.Add(Me.cmbCuentas)
        Me.SSPanel1.Controls.Add(Me.txtCuenta)
        Me.SSPanel1.Controls.Add(Me.Label1)
        Me.SSPanel1.Location = New System.Drawing.Point(12, 12)
        Me.SSPanel1.Name = "SSPanel1"
        Me.SSPanel1.Size = New System.Drawing.Size(776, 75)
        Me.SSPanel1.TabIndex = 0
        Me.SSPanel1.TabStop = False
        Me.SSPanel1.Text = "Cliente"
        '
        'cmbCuentas
        '
        Me.cmbCuentas.FormattingEnabled = True
        Me.cmbCuentas.Location = New System.Drawing.Point(217, 26)
        Me.cmbCuentas.Name = "cmbCuentas"
        Me.cmbCuentas.Size = New System.Drawing.Size(539, 28)
        Me.cmbCuentas.TabIndex = 2
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(101, 27)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(110, 26)
        Me.txtCuenta.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cuenta:"
        '
        'fraFunc
        '
        Me.fraFunc.Controls.Add(Me.lblUniGes)
        Me.fraFunc.Controls.Add(Me.lblCP)
        Me.fraFunc.Controls.Add(Me.lblUO)
        Me.fraFunc.Controls.Add(Me.lblUbicacion)
        Me.fraFunc.Controls.Add(Me.lblCol)
        Me.fraFunc.Controls.Add(Me.lblCalle)
        Me.fraFunc.Controls.Add(Me.lblFax)
        Me.fraFunc.Controls.Add(Me.lblTel)
        Me.fraFunc.Controls.Add(Me.cmbFuncs)
        Me.fraFunc.Controls.Add(Me.txtFunc)
        Me.fraFunc.Controls.Add(Me.Label10)
        Me.fraFunc.Controls.Add(Me.Label9)
        Me.fraFunc.Controls.Add(Me.Label8)
        Me.fraFunc.Controls.Add(Me.Label7)
        Me.fraFunc.Controls.Add(Me.Label6)
        Me.fraFunc.Controls.Add(Me.Label5)
        Me.fraFunc.Controls.Add(Me.Label4)
        Me.fraFunc.Controls.Add(Me.Label3)
        Me.fraFunc.Controls.Add(Me.Label2)
        Me.fraFunc.Location = New System.Drawing.Point(12, 93)
        Me.fraFunc.Name = "fraFunc"
        Me.fraFunc.Size = New System.Drawing.Size(776, 357)
        Me.fraFunc.TabIndex = 1
        Me.fraFunc.TabStop = False
        Me.fraFunc.Text = "Gestor"
        '
        'lblUniGes
        '
        Me.lblUniGes.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblUniGes.Location = New System.Drawing.Point(582, 266)
        Me.lblUniGes.Name = "lblUniGes"
        Me.lblUniGes.Size = New System.Drawing.Size(174, 26)
        Me.lblUniGes.TabIndex = 26
        Me.lblUniGes.Visible = False
        '
        'lblCP
        '
        Me.lblCP.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblCP.Location = New System.Drawing.Point(381, 76)
        Me.lblCP.Name = "lblCP"
        Me.lblCP.Size = New System.Drawing.Size(98, 26)
        Me.lblCP.TabIndex = 25
        '
        'lblUO
        '
        Me.lblUO.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblUO.Location = New System.Drawing.Point(121, 266)
        Me.lblUO.Name = "lblUO"
        Me.lblUO.Size = New System.Drawing.Size(358, 78)
        Me.lblUO.TabIndex = 24
        '
        'lblUbicacion
        '
        Me.lblUbicacion.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblUbicacion.Location = New System.Drawing.Point(121, 230)
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.Size = New System.Drawing.Size(358, 26)
        Me.lblUbicacion.TabIndex = 23
        '
        'lblCol
        '
        Me.lblCol.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblCol.Location = New System.Drawing.Point(121, 192)
        Me.lblCol.Name = "lblCol"
        Me.lblCol.Size = New System.Drawing.Size(358, 26)
        Me.lblCol.TabIndex = 22
        '
        'lblCalle
        '
        Me.lblCalle.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblCalle.Location = New System.Drawing.Point(121, 153)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(358, 26)
        Me.lblCalle.TabIndex = 21
        '
        'lblFax
        '
        Me.lblFax.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblFax.Location = New System.Drawing.Point(121, 115)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(176, 26)
        Me.lblFax.TabIndex = 20
        '
        'lblTel
        '
        Me.lblTel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTel.Location = New System.Drawing.Point(121, 76)
        Me.lblTel.Name = "lblTel"
        Me.lblTel.Size = New System.Drawing.Size(176, 26)
        Me.lblTel.TabIndex = 19
        '
        'cmbFuncs
        '
        Me.cmbFuncs.FormattingEnabled = True
        Me.cmbFuncs.Location = New System.Drawing.Point(252, 33)
        Me.cmbFuncs.Name = "cmbFuncs"
        Me.cmbFuncs.Size = New System.Drawing.Size(504, 28)
        Me.cmbFuncs.TabIndex = 3
        '
        'txtFunc
        '
        Me.txtFunc.Location = New System.Drawing.Point(119, 35)
        Me.txtFunc.Name = "txtFunc"
        Me.txtFunc.Size = New System.Drawing.Size(127, 26)
        Me.txtFunc.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(485, 266)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 20)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "U. Gestora:"
        Me.Label10.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(333, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 20)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "C.P.:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 266)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 20)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Unidad Org.:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 230)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 20)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Ubicación:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 20)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Colonia:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 153)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 20)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Calle:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 20)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Fax:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Teléfono:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "BPIGO:"
        '
        'cmdAsignar
        '
        Me.cmdAsignar.Enabled = False
        Me.cmdAsignar.Location = New System.Drawing.Point(565, 467)
        Me.cmdAsignar.Name = "cmdAsignar"
        Me.cmdAsignar.Size = New System.Drawing.Size(102, 36)
        Me.cmdAsignar.TabIndex = 2
        Me.cmdAsignar.Text = "&Asignar"
        Me.cmdAsignar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(686, 467)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(102, 36)
        Me.cmdSalir.TabIndex = 3
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'pgbProgreso
        '
        Me.pgbProgreso.Location = New System.Drawing.Point(12, 467)
        Me.pgbProgreso.Name = "pgbProgreso"
        Me.pgbProgreso.Size = New System.Drawing.Size(534, 36)
        Me.pgbProgreso.TabIndex = 4
        Me.pgbProgreso.Visible = False
        '
        'frmReasignaFunc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(800, 515)
        Me.Controls.Add(Me.pgbProgreso)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdAsignar)
        Me.Controls.Add(Me.fraFunc)
        Me.Controls.Add(Me.SSPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReasignaFunc"
        Me.Text = "Reasignación de Gestores"
        Me.SSPanel1.ResumeLayout(False)
        Me.SSPanel1.PerformLayout()
        Me.fraFunc.ResumeLayout(False)
        Me.fraFunc.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SSPanel1 As GroupBox
    Friend WithEvents cmbCuentas As ComboBox
    Friend WithEvents txtCuenta As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents fraFunc As GroupBox
    Friend WithEvents lblUO As Label
    Friend WithEvents lblUbicacion As Label
    Friend WithEvents lblCol As Label
    Friend WithEvents lblCalle As Label
    Friend WithEvents lblFax As Label
    Friend WithEvents lblTel As Label
    Friend WithEvents cmbFuncs As ComboBox
    Friend WithEvents txtFunc As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmdAsignar As Button
    Friend WithEvents cmdSalir As Button
    Friend WithEvents lblUniGes As Label
    Friend WithEvents lblCP As Label
    Friend WithEvents pgbProgreso As ProgressBar
End Class
