<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManntoCuentas
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.cmdBuscar = New System.Windows.Forms.Button()
        Me.dgvManntoCuentas = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkTipo = New System.Windows.Forms.CheckBox()
        Me.chkCuenta = New System.Windows.Forms.CheckBox()
        Me.chkRango = New System.Windows.Forms.CheckBox()
        Me.chkFecha = New System.Windows.Forms.CheckBox()
        Me.cmbTipoMannto = New System.Windows.Forms.ComboBox()
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblRango = New System.Windows.Forms.Label()
        Me.txtFechaFin = New System.Windows.Forms.TextBox()
        Me.txtFechaIni = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvManntoCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSalir)
        Me.GroupBox1.Controls.Add(Me.cmdImprimir)
        Me.GroupBox1.Controls.Add(Me.cmdBuscar)
        Me.GroupBox1.Controls.Add(Me.dgvManntoCuentas)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(4, 11)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(1245, 694)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selección de Información por:"
        '
        'cmdSalir
        '
        Me.cmdSalir.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cmdSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalir.Location = New System.Drawing.Point(1084, 629)
        Me.cmdSalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(150, 54)
        Me.cmdSalir.TabIndex = 6
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = False
        '
        'cmdImprimir
        '
        Me.cmdImprimir.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cmdImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdImprimir.Location = New System.Drawing.Point(1084, 205)
        Me.cmdImprimir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(150, 54)
        Me.cmdImprimir.TabIndex = 5
        Me.cmdImprimir.Text = "Imprimir"
        Me.cmdImprimir.UseVisualStyleBackColor = False
        '
        'cmdBuscar
        '
        Me.cmdBuscar.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cmdBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBuscar.Location = New System.Drawing.Point(886, 205)
        Me.cmdBuscar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(150, 54)
        Me.cmdBuscar.TabIndex = 4
        Me.cmdBuscar.Text = "Consultar"
        Me.cmdBuscar.UseVisualStyleBackColor = False
        '
        'dgvManntoCuentas
        '
        Me.dgvManntoCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvManntoCuentas.Location = New System.Drawing.Point(9, 282)
        Me.dgvManntoCuentas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvManntoCuentas.Name = "dgvManntoCuentas"
        Me.dgvManntoCuentas.RowHeadersWidth = 62
        Me.dgvManntoCuentas.Size = New System.Drawing.Size(1226, 338)
        Me.dgvManntoCuentas.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(969, 66)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 75)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Agencia HOUSTON"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkTipo)
        Me.GroupBox2.Controls.Add(Me.chkCuenta)
        Me.GroupBox2.Controls.Add(Me.chkRango)
        Me.GroupBox2.Controls.Add(Me.chkFecha)
        Me.GroupBox2.Controls.Add(Me.cmbTipoMannto)
        Me.GroupBox2.Controls.Add(Me.txtCuenta)
        Me.GroupBox2.Controls.Add(Me.txtFecha)
        Me.GroupBox2.Controls.Add(Me.lblFecha)
        Me.GroupBox2.Controls.Add(Me.lblRango)
        Me.GroupBox2.Controls.Add(Me.txtFechaFin)
        Me.GroupBox2.Controls.Add(Me.txtFechaIni)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(14, 23)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(814, 249)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'chkTipo
        '
        Me.chkTipo.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkTipo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.chkTipo.Location = New System.Drawing.Point(26, 191)
        Me.chkTipo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkTipo.Name = "chkTipo"
        Me.chkTipo.Size = New System.Drawing.Size(270, 43)
        Me.chkTipo.TabIndex = 21
        Me.chkTipo.Text = "Tipo de Mantenimiento"
        Me.chkTipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkTipo.UseVisualStyleBackColor = False
        '
        'chkCuenta
        '
        Me.chkCuenta.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkCuenta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.chkCuenta.Location = New System.Drawing.Point(26, 138)
        Me.chkCuenta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkCuenta.Name = "chkCuenta"
        Me.chkCuenta.Size = New System.Drawing.Size(270, 43)
        Me.chkCuenta.TabIndex = 20
        Me.chkCuenta.Text = "Cuenta Cliente"
        Me.chkCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkCuenta.UseVisualStyleBackColor = False
        '
        'chkRango
        '
        Me.chkRango.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkRango.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.chkRango.Location = New System.Drawing.Point(26, 85)
        Me.chkRango.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkRango.Name = "chkRango"
        Me.chkRango.Size = New System.Drawing.Size(270, 43)
        Me.chkRango.TabIndex = 19
        Me.chkRango.Text = "Rango"
        Me.chkRango.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkRango.UseVisualStyleBackColor = False
        '
        'chkFecha
        '
        Me.chkFecha.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkFecha.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.chkFecha.Location = New System.Drawing.Point(26, 29)
        Me.chkFecha.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkFecha.Name = "chkFecha"
        Me.chkFecha.Size = New System.Drawing.Size(270, 43)
        Me.chkFecha.TabIndex = 18
        Me.chkFecha.Text = "Fecha"
        Me.chkFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkFecha.UseVisualStyleBackColor = False
        '
        'cmbTipoMannto
        '
        Me.cmbTipoMannto.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoMannto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoMannto.FormattingEnabled = True
        Me.cmbTipoMannto.Location = New System.Drawing.Point(320, 195)
        Me.cmbTipoMannto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbTipoMannto.Name = "cmbTipoMannto"
        Me.cmbTipoMannto.Size = New System.Drawing.Size(474, 28)
        Me.cmbTipoMannto.TabIndex = 17
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(320, 143)
        Me.txtCuenta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCuenta.MaxLength = 6
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(138, 29)
        Me.txtCuenta.TabIndex = 5
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(320, 34)
        Me.txtFecha.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFecha.MaxLength = 10
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(138, 29)
        Me.txtFecha.TabIndex = 4
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(656, 42)
        Me.lblFecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(128, 24)
        Me.lblFecha.TabIndex = 3
        Me.lblFecha.Text = "(dd-mm-aaaa)"
        '
        'lblRango
        '
        Me.lblRango.AutoSize = True
        Me.lblRango.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRango.Location = New System.Drawing.Point(656, 94)
        Me.lblRango.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRango.Name = "lblRango"
        Me.lblRango.Size = New System.Drawing.Size(128, 24)
        Me.lblRango.TabIndex = 2
        Me.lblRango.Text = "(dd-mm-aaaa)"
        '
        'txtFechaFin
        '
        Me.txtFechaFin.Location = New System.Drawing.Point(483, 89)
        Me.txtFechaFin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFechaFin.MaxLength = 10
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.Size = New System.Drawing.Size(145, 29)
        Me.txtFechaFin.TabIndex = 1
        '
        'txtFechaIni
        '
        Me.txtFechaIni.Location = New System.Drawing.Point(320, 89)
        Me.txtFechaIni.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFechaIni.MaxLength = 10
        Me.txtFechaIni.Name = "txtFechaIni"
        Me.txtFechaIni.Size = New System.Drawing.Size(138, 29)
        Me.txtFechaIni.TabIndex = 0
        '
        'frmManntoCuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1257, 711)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmManntoCuentas"
        Me.Text = "Reporte de Mantenimiento de Cuentas CED"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvManntoCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmdSalir As Button
    Friend WithEvents cmdImprimir As Button
    Friend WithEvents cmdBuscar As Button
    Friend WithEvents dgvManntoCuentas As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblFecha As Label
    Friend WithEvents lblRango As Label
    Friend WithEvents txtFechaFin As TextBox
    Friend WithEvents txtFechaIni As TextBox
    Friend WithEvents txtCuenta As TextBox
    Friend WithEvents txtFecha As TextBox
    Friend WithEvents cmbTipoMannto As ComboBox
    Friend WithEvents chkTipo As CheckBox
    Friend WithEvents chkCuenta As CheckBox
    Friend WithEvents chkRango As CheckBox
    Friend WithEvents chkFecha As CheckBox
End Class
