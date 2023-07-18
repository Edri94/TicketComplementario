<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantUsr
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMantUsr))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbNombre = New System.Windows.Forms.ComboBox()
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox()
        Me.lblBloqueado = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fraDatos = New System.Windows.Forms.GroupBox()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.cmbArea = New System.Windows.Forms.ComboBox()
        Me.cmbOrigen = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdElimina = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdReactivar = New System.Windows.Forms.Button()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdDesbloquear = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.fraDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbNombre)
        Me.GroupBox1.Controls.Add(Me.cmbUsuarios)
        Me.GroupBox1.Controls.Add(Me.lblBloqueado)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 124)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Usuario"
        '
        'cmbNombre
        '
        Me.cmbNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNombre.FormattingEnabled = True
        Me.cmbNombre.Location = New System.Drawing.Point(295, 55)
        Me.cmbNombre.Name = "cmbNombre"
        Me.cmbNombre.Size = New System.Drawing.Size(459, 28)
        Me.cmbNombre.TabIndex = 4
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(6, 55)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(283, 28)
        Me.cmbUsuarios.TabIndex = 3
        '
        'lblBloqueado
        '
        Me.lblBloqueado.AutoSize = True
        Me.lblBloqueado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBloqueado.Location = New System.Drawing.Point(609, 32)
        Me.lblBloqueado.Name = "lblBloqueado"
        Me.lblBloqueado.Size = New System.Drawing.Size(145, 20)
        Me.lblBloqueado.TabIndex = 2
        Me.lblBloqueado.Text = "Usuario Bloqueado"
        Me.lblBloqueado.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(291, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Login"
        '
        'fraDatos
        '
        Me.fraDatos.Controls.Add(Me.txtLogin)
        Me.fraDatos.Controls.Add(Me.txtNombre)
        Me.fraDatos.Controls.Add(Me.dtpFecha)
        Me.fraDatos.Controls.Add(Me.cmbArea)
        Me.fraDatos.Controls.Add(Me.cmbOrigen)
        Me.fraDatos.Controls.Add(Me.Label8)
        Me.fraDatos.Controls.Add(Me.Label7)
        Me.fraDatos.Controls.Add(Me.Label6)
        Me.fraDatos.Controls.Add(Me.Label5)
        Me.fraDatos.Controls.Add(Me.Label4)
        Me.fraDatos.Enabled = False
        Me.fraDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraDatos.Location = New System.Drawing.Point(12, 142)
        Me.fraDatos.Name = "fraDatos"
        Me.fraDatos.Size = New System.Drawing.Size(570, 296)
        Me.fraDatos.TabIndex = 1
        Me.fraDatos.TabStop = False
        Me.fraDatos.Text = "Datos del Usuario"
        '
        'txtLogin
        '
        Me.txtLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogin.Location = New System.Drawing.Point(10, 150)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(229, 26)
        Me.txtLogin.TabIndex = 9
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(10, 63)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(539, 26)
        Me.txtNombre.TabIndex = 8
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "dd-MM-yyyy"
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(34, 246)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(160, 26)
        Me.dtpFecha.TabIndex = 7
        '
        'cmbArea
        '
        Me.cmbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Location = New System.Drawing.Point(337, 220)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(212, 28)
        Me.cmbArea.TabIndex = 6
        '
        'cmbOrigen
        '
        Me.cmbOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOrigen.FormattingEnabled = True
        Me.cmbOrigen.Location = New System.Drawing.Point(337, 127)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New System.Drawing.Size(212, 28)
        Me.cmbOrigen.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(267, 220)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 20)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Area: "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(267, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 20)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Origen: "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 223)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(233, 20)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Fecha de cambio de password: "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 20)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Login: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Nombre usuario: "
        '
        'cmdElimina
        '
        Me.cmdElimina.Location = New System.Drawing.Point(606, 142)
        Me.cmdElimina.Name = "cmdElimina"
        Me.cmdElimina.Size = New System.Drawing.Size(176, 39)
        Me.cmdElimina.TabIndex = 2
        Me.cmdElimina.Text = "&Eliminar"
        Me.cmdElimina.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(606, 199)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(176, 39)
        Me.cmdAceptar.TabIndex = 3
        Me.cmdAceptar.Text = "&Actualizar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdReactivar
        '
        Me.cmdReactivar.Location = New System.Drawing.Point(606, 258)
        Me.cmdReactivar.Name = "cmdReactivar"
        Me.cmdReactivar.Size = New System.Drawing.Size(176, 39)
        Me.cmdReactivar.TabIndex = 4
        Me.cmdReactivar.Text = "&Reactivar"
        Me.cmdReactivar.UseVisualStyleBackColor = True
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Location = New System.Drawing.Point(606, 375)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(176, 39)
        Me.cmdCerrar.TabIndex = 5
        Me.cmdCerrar.Text = "&Salir"
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdDesbloquear
        '
        Me.cmdDesbloquear.Location = New System.Drawing.Point(606, 318)
        Me.cmdDesbloquear.Name = "cmdDesbloquear"
        Me.cmdDesbloquear.Size = New System.Drawing.Size(176, 39)
        Me.cmdDesbloquear.TabIndex = 7
        Me.cmdDesbloquear.Text = "&Desbloquear"
        Me.cmdDesbloquear.UseVisualStyleBackColor = True
        '
        'frmMantUsr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.cmdDesbloquear)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdReactivar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cmdElimina)
        Me.Controls.Add(Me.fraDatos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMantUsr"
        Me.Text = "Mantenimiento de Usuarios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.fraDatos.ResumeLayout(False)
        Me.fraDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblBloqueado As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents fraDatos As GroupBox
    Friend WithEvents cmbNombre As ComboBox
    Friend WithEvents cmbUsuarios As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents cmbArea As ComboBox
    Friend WithEvents cmbOrigen As ComboBox
    Friend WithEvents txtLogin As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents cmdElimina As Button
    Friend WithEvents cmdAceptar As Button
    Friend WithEvents cmdReactivar As Button
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdDesbloquear As Button
End Class
