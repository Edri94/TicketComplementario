<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepCtasDineroVista
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCuentaFin = New System.Windows.Forms.TextBox()
        Me.txtCuentaIni = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.optRango = New System.Windows.Forms.RadioButton()
        Me.optTodas = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvCuentas000 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvCuentas000, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSalir)
        Me.GroupBox1.Controls.Add(Me.cmdImprimir)
        Me.GroupBox1.Controls.Add(Me.cmdBuscar)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.dgvCuentas000)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(922, 515)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cmdSalir
        '
        Me.cmdSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalir.Location = New System.Drawing.Point(815, 468)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(100, 35)
        Me.cmdSalir.TabIndex = 9
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdImprimir
        '
        Me.cmdImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdImprimir.Location = New System.Drawing.Point(816, 66)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(100, 35)
        Me.cmdImprimir.TabIndex = 8
        Me.cmdImprimir.Text = "Imprimir"
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBuscar.Location = New System.Drawing.Point(619, 65)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(100, 35)
        Me.cmdBuscar.TabIndex = 7
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCuentaFin)
        Me.GroupBox2.Controls.Add(Me.txtCuentaIni)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.optRango)
        Me.GroupBox2.Controls.Add(Me.optTodas)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(529, 115)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'txtCuentaFin
        '
        Me.txtCuentaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuentaFin.Location = New System.Drawing.Point(379, 76)
        Me.txtCuentaFin.Name = "txtCuentaFin"
        Me.txtCuentaFin.Size = New System.Drawing.Size(100, 23)
        Me.txtCuentaFin.TabIndex = 11
        '
        'txtCuentaIni
        '
        Me.txtCuentaIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuentaIni.Location = New System.Drawing.Point(214, 76)
        Me.txtCuentaIni.Name = "txtCuentaIni"
        Me.txtCuentaIni.Size = New System.Drawing.Size(100, 23)
        Me.txtCuentaIni.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(274, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Agencia HOUSTON"
        '
        'optRango
        '
        Me.optRango.Appearance = System.Windows.Forms.Appearance.Button
        Me.optRango.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optRango.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optRango.Location = New System.Drawing.Point(44, 68)
        Me.optRango.Name = "optRango"
        Me.optRango.Size = New System.Drawing.Size(100, 35)
        Me.optRango.TabIndex = 8
        Me.optRango.TabStop = True
        Me.optRango.Text = "Por Rango"
        Me.optRango.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optRango.UseVisualStyleBackColor = True
        '
        'optTodas
        '
        Me.optTodas.Appearance = System.Windows.Forms.Appearance.Button
        Me.optTodas.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optTodas.Checked = True
        Me.optTodas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optTodas.Location = New System.Drawing.Point(44, 19)
        Me.optTodas.Name = "optTodas"
        Me.optTodas.Size = New System.Drawing.Size(100, 35)
        Me.optTodas.TabIndex = 7
        Me.optTodas.TabStop = True
        Me.optTodas.Text = "Todas"
        Me.optTodas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optTodas.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(220, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Cuenta Inicio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(391, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Cuenta Fin"
        '
        'dgvCuentas000
        '
        Me.dgvCuentas000.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCuentas000.Location = New System.Drawing.Point(6, 144)
        Me.dgvCuentas000.Name = "dgvCuentas000"
        Me.dgvCuentas000.Size = New System.Drawing.Size(910, 308)
        Me.dgvCuentas000.TabIndex = 0
        '
        'frmRepCtasDineroVista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(946, 533)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmRepCtasDineroVista"
        Me.Text = "Reporte Cuentas de Inversión 000 con Dinero a la Vista"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvCuentas000, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgvCuentas000 As DataGridView
    Friend WithEvents cmdImprimir As Button
    Friend WithEvents cmdBuscar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents optRango As RadioButton
    Friend WithEvents optTodas As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmdSalir As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCuentaFin As TextBox
    Friend WithEvents txtCuentaIni As TextBox
End Class
