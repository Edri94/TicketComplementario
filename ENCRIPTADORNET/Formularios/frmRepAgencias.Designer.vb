<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepAgencias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepAgencias))
        Me.SSPanel2 = New System.Windows.Forms.GroupBox()
        Me.lstAgencia = New System.Windows.Forms.ListBox()
        Me.SSPanel1 = New System.Windows.Forms.GroupBox()
        Me.fraRep = New System.Windows.Forms.GroupBox()
        Me.chkTipoRep2 = New System.Windows.Forms.CheckBox()
        Me.chkTipoRep1 = New System.Windows.Forms.CheckBox()
        Me.chkOperacion4 = New System.Windows.Forms.CheckBox()
        Me.chkOperacion3 = New System.Windows.Forms.CheckBox()
        Me.chkOperacion2 = New System.Windows.Forms.CheckBox()
        Me.chkOperacion1 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.SSPanel2.SuspendLayout()
        Me.SSPanel1.SuspendLayout()
        Me.fraRep.SuspendLayout()
        Me.SuspendLayout()
        '
        'SSPanel2
        '
        Me.SSPanel2.Controls.Add(Me.lstAgencia)
        Me.SSPanel2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSPanel2.Location = New System.Drawing.Point(13, 12)
        Me.SSPanel2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SSPanel2.Name = "SSPanel2"
        Me.SSPanel2.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SSPanel2.Size = New System.Drawing.Size(416, 110)
        Me.SSPanel2.TabIndex = 5
        Me.SSPanel2.TabStop = False
        Me.SSPanel2.Text = "Agencia"
        '
        'lstAgencia
        '
        Me.lstAgencia.FormattingEnabled = True
        Me.lstAgencia.ItemHeight = 21
        Me.lstAgencia.Location = New System.Drawing.Point(21, 27)
        Me.lstAgencia.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.lstAgencia.Name = "lstAgencia"
        Me.lstAgencia.Size = New System.Drawing.Size(378, 67)
        Me.lstAgencia.TabIndex = 0
        '
        'SSPanel1
        '
        Me.SSPanel1.Controls.Add(Me.fraRep)
        Me.SSPanel1.Controls.Add(Me.chkOperacion4)
        Me.SSPanel1.Controls.Add(Me.chkOperacion3)
        Me.SSPanel1.Controls.Add(Me.chkOperacion2)
        Me.SSPanel1.Controls.Add(Me.chkOperacion1)
        Me.SSPanel1.Controls.Add(Me.Label1)
        Me.SSPanel1.Controls.Add(Me.dtpFecha)
        Me.SSPanel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSPanel1.Location = New System.Drawing.Point(13, 139)
        Me.SSPanel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SSPanel1.Name = "SSPanel1"
        Me.SSPanel1.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SSPanel1.Size = New System.Drawing.Size(416, 414)
        Me.SSPanel1.TabIndex = 6
        Me.SSPanel1.TabStop = False
        '
        'fraRep
        '
        Me.fraRep.Controls.Add(Me.chkTipoRep2)
        Me.fraRep.Controls.Add(Me.chkTipoRep1)
        Me.fraRep.Location = New System.Drawing.Point(21, 327)
        Me.fraRep.Name = "fraRep"
        Me.fraRep.Size = New System.Drawing.Size(378, 68)
        Me.fraRep.TabIndex = 8
        Me.fraRep.TabStop = False
        '
        'chkTipoRep2
        '
        Me.chkTipoRep2.AutoSize = True
        Me.chkTipoRep2.Location = New System.Drawing.Point(194, 27)
        Me.chkTipoRep2.Name = "chkTipoRep2"
        Me.chkTipoRep2.Size = New System.Drawing.Size(167, 25)
        Me.chkTipoRep2.TabIndex = 8
        Me.chkTipoRep2.Text = "Reporte SWIFT"
        Me.chkTipoRep2.UseVisualStyleBackColor = True
        '
        'chkTipoRep1
        '
        Me.chkTipoRep1.AutoSize = True
        Me.chkTipoRep1.Location = New System.Drawing.Point(9, 27)
        Me.chkTipoRep1.Name = "chkTipoRep1"
        Me.chkTipoRep1.Size = New System.Drawing.Size(188, 25)
        Me.chkTipoRep1.TabIndex = 7
        Me.chkTipoRep1.Text = "Reporte Equation"
        Me.chkTipoRep1.UseVisualStyleBackColor = True
        '
        'chkOperacion4
        '
        Me.chkOperacion4.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkOperacion4.Location = New System.Drawing.Point(21, 262)
        Me.chkOperacion4.Name = "chkOperacion4"
        Me.chkOperacion4.Size = New System.Drawing.Size(361, 53)
        Me.chkOperacion4.TabIndex = 6
        Me.chkOperacion4.Text = "Retiro por Orden de Pago otras Divisas"
        Me.chkOperacion4.UseVisualStyleBackColor = True
        '
        'chkOperacion3
        '
        Me.chkOperacion3.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkOperacion3.Location = New System.Drawing.Point(21, 203)
        Me.chkOperacion3.Name = "chkOperacion3"
        Me.chkOperacion3.Size = New System.Drawing.Size(253, 42)
        Me.chkOperacion3.TabIndex = 5
        Me.chkOperacion3.Text = "Retiro por Orden de Pago"
        Me.chkOperacion3.UseVisualStyleBackColor = True
        '
        'chkOperacion2
        '
        Me.chkOperacion2.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkOperacion2.Location = New System.Drawing.Point(21, 140)
        Me.chkOperacion2.Name = "chkOperacion2"
        Me.chkOperacion2.Size = New System.Drawing.Size(238, 49)
        Me.chkOperacion2.TabIndex = 4
        Me.chkOperacion2.Text = "Retiro por Compra de TD"
        Me.chkOperacion2.UseVisualStyleBackColor = True
        '
        'chkOperacion1
        '
        Me.chkOperacion1.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkOperacion1.Location = New System.Drawing.Point(21, 75)
        Me.chkOperacion1.Name = "chkOperacion1"
        Me.chkOperacion1.Size = New System.Drawing.Size(197, 49)
        Me.chkOperacion1.TabIndex = 3
        Me.chkOperacion1.Text = "Depositos y Retiros"
        Me.chkOperacion1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha"
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "dd-MM-yyyy"
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(95, 28)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(147, 28)
        Me.dtpFecha.TabIndex = 0
        '
        'cmdSalir
        '
        Me.cmdSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalir.Location = New System.Drawing.Point(240, 574)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(189, 45)
        Me.cmdSalir.TabIndex = 9
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAceptar.Location = New System.Drawing.Point(12, 574)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(204, 45)
        Me.cmdAceptar.TabIndex = 8
        Me.cmdAceptar.Text = "&Imprimir"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'frmRepAgencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(452, 643)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.SSPanel1)
        Me.Controls.Add(Me.SSPanel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRepAgencias"
        Me.Text = "Reportes"
        Me.SSPanel2.ResumeLayout(False)
        Me.SSPanel1.ResumeLayout(False)
        Me.SSPanel1.PerformLayout()
        Me.fraRep.ResumeLayout(False)
        Me.fraRep.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SSPanel2 As GroupBox
    Friend WithEvents lstAgencia As ListBox
    Friend WithEvents SSPanel1 As GroupBox
    Friend WithEvents fraRep As GroupBox
    Friend WithEvents chkTipoRep2 As CheckBox
    Friend WithEvents chkTipoRep1 As CheckBox
    Friend WithEvents chkOperacion4 As CheckBox
    Friend WithEvents chkOperacion3 As CheckBox
    Friend WithEvents chkOperacion2 As CheckBox
    Friend WithEvents chkOperacion1 As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents cmdSalir As Button
    Friend WithEvents cmdAceptar As Button
End Class
