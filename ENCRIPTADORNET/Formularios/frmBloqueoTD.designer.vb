<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBloqueoTD
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
        Me.cmdBloquear = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdLimpiar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.lblComentario = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.lblConcepto = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCuenta = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTicket = New System.Windows.Forms.Label()
        Me.txtPlazo = New System.Windows.Forms.TextBox()
        Me.txtTasa = New System.Windows.Forms.TextBox()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.txtFecVencimiento = New System.Windows.Forms.TextBox()
        Me.txtFecOperacion = New System.Windows.Forms.TextBox()
        Me.txtFecCaptura = New System.Windows.Forms.TextBox()
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.txtAgencia = New System.Windows.Forms.TextBox()
        Me.txtTicket = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdBloquear)
        Me.GroupBox1.Controls.Add(Me.cmdSalir)
        Me.GroupBox1.Controls.Add(Me.cmdLimpiar)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 556)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(933, 95)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'cmdBloquear
        '
        Me.cmdBloquear.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cmdBloquear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBloquear.Location = New System.Drawing.Point(579, 25)
        Me.cmdBloquear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdBloquear.Name = "cmdBloquear"
        Me.cmdBloquear.Size = New System.Drawing.Size(150, 54)
        Me.cmdBloquear.TabIndex = 7
        Me.cmdBloquear.Text = "Bloquear"
        Me.cmdBloquear.UseVisualStyleBackColor = False
        '
        'cmdSalir
        '
        Me.cmdSalir.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cmdSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalir.Location = New System.Drawing.Point(758, 25)
        Me.cmdSalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(150, 54)
        Me.cmdSalir.TabIndex = 6
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = False
        '
        'cmdLimpiar
        '
        Me.cmdLimpiar.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cmdLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLimpiar.Location = New System.Drawing.Point(302, 25)
        Me.cmdLimpiar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdLimpiar.Name = "cmdLimpiar"
        Me.cmdLimpiar.Size = New System.Drawing.Size(150, 54)
        Me.cmdLimpiar.TabIndex = 5
        Me.cmdLimpiar.Text = "Limpiar"
        Me.cmdLimpiar.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblMensaje)
        Me.GroupBox2.Controls.Add(Me.txtComentario)
        Me.GroupBox2.Controls.Add(Me.lblComentario)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lblMonto)
        Me.GroupBox2.Controls.Add(Me.lblConcepto)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lblCuenta)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblTicket)
        Me.GroupBox2.Controls.Add(Me.txtPlazo)
        Me.GroupBox2.Controls.Add(Me.txtTasa)
        Me.GroupBox2.Controls.Add(Me.txtMonto)
        Me.GroupBox2.Controls.Add(Me.txtDescripcion)
        Me.GroupBox2.Controls.Add(Me.txtOrigen)
        Me.GroupBox2.Controls.Add(Me.txtFecVencimiento)
        Me.GroupBox2.Controls.Add(Me.txtFecOperacion)
        Me.GroupBox2.Controls.Add(Me.txtFecCaptura)
        Me.GroupBox2.Controls.Add(Me.txtCuenta)
        Me.GroupBox2.Controls.Add(Me.txtAgencia)
        Me.GroupBox2.Controls.Add(Me.txtTicket)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(13, 5)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(933, 550)
        Me.GroupBox2.TabIndex = 49
        Me.GroupBox2.TabStop = False
        '
        'lblMensaje
        '
        Me.lblMensaje.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.Location = New System.Drawing.Point(461, 39)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(447, 47)
        Me.lblMensaje.TabIndex = 24
        Me.lblMensaje.Text = "Estatus de la Operación."
        Me.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtComentario
        '
        Me.txtComentario.Location = New System.Drawing.Point(23, 404)
        Me.txtComentario.MaxLength = 100
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(885, 138)
        Me.txtComentario.TabIndex = 23
        '
        'lblComentario
        '
        Me.lblComentario.AutoSize = True
        Me.lblComentario.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComentario.Location = New System.Drawing.Point(19, 379)
        Me.lblComentario.Name = "lblComentario"
        Me.lblComentario.Size = New System.Drawing.Size(189, 22)
        Me.lblComentario.TabIndex = 22
        Me.lblComentario.Text = "Motivo del Bloqueo:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(505, 320)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 22)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Plazo:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(505, 270)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 22)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Tasa:"
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.Location = New System.Drawing.Point(505, 222)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(73, 22)
        Me.lblMonto.TabIndex = 19
        Me.lblMonto.Text = "Monto:"
        '
        'lblConcepto
        '
        Me.lblConcepto.AutoSize = True
        Me.lblConcepto.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConcepto.Location = New System.Drawing.Point(505, 175)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(102, 22)
        Me.lblConcepto.TabIndex = 18
        Me.lblConcepto.Text = "Concepto:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(505, 130)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 22)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Origen:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(73, 320)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(181, 22)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Fecha Vencimento:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(73, 270)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 22)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Fecha Operación:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(73, 222)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 22)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Fecha Captura:"
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuenta.Location = New System.Drawing.Point(73, 171)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(82, 22)
        Me.lblCuenta.TabIndex = 13
        Me.lblCuenta.Text = "Cuenta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(73, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 22)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Agencia:"
        '
        'lblTicket
        '
        Me.lblTicket.AutoSize = True
        Me.lblTicket.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTicket.Location = New System.Drawing.Point(73, 51)
        Me.lblTicket.Name = "lblTicket"
        Me.lblTicket.Size = New System.Drawing.Size(72, 22)
        Me.lblTicket.TabIndex = 11
        Me.lblTicket.Text = "Ticket:"
        '
        'txtPlazo
        '
        Me.txtPlazo.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtPlazo.Location = New System.Drawing.Point(625, 314)
        Me.txtPlazo.MaxLength = 25
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.Size = New System.Drawing.Size(167, 28)
        Me.txtPlazo.TabIndex = 10
        '
        'txtTasa
        '
        Me.txtTasa.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtTasa.Location = New System.Drawing.Point(625, 264)
        Me.txtTasa.MaxLength = 15
        Me.txtTasa.Name = "txtTasa"
        Me.txtTasa.Size = New System.Drawing.Size(167, 28)
        Me.txtTasa.TabIndex = 9
        '
        'txtMonto
        '
        Me.txtMonto.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtMonto.Location = New System.Drawing.Point(625, 216)
        Me.txtMonto.MaxLength = 25
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(167, 28)
        Me.txtMonto.TabIndex = 8
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtDescripcion.Location = New System.Drawing.Point(625, 169)
        Me.txtDescripcion.MaxLength = 60
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(272, 28)
        Me.txtDescripcion.TabIndex = 7
        '
        'txtOrigen
        '
        Me.txtOrigen.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtOrigen.Location = New System.Drawing.Point(625, 124)
        Me.txtOrigen.MaxLength = 50
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Size = New System.Drawing.Size(272, 28)
        Me.txtOrigen.TabIndex = 6
        '
        'txtFecVencimiento
        '
        Me.txtFecVencimiento.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtFecVencimiento.Location = New System.Drawing.Point(265, 314)
        Me.txtFecVencimiento.MaxLength = 15
        Me.txtFecVencimiento.Name = "txtFecVencimiento"
        Me.txtFecVencimiento.Size = New System.Drawing.Size(167, 28)
        Me.txtFecVencimiento.TabIndex = 5
        '
        'txtFecOperacion
        '
        Me.txtFecOperacion.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtFecOperacion.Location = New System.Drawing.Point(265, 264)
        Me.txtFecOperacion.MaxLength = 15
        Me.txtFecOperacion.Name = "txtFecOperacion"
        Me.txtFecOperacion.Size = New System.Drawing.Size(167, 28)
        Me.txtFecOperacion.TabIndex = 4
        '
        'txtFecCaptura
        '
        Me.txtFecCaptura.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtFecCaptura.Location = New System.Drawing.Point(265, 216)
        Me.txtFecCaptura.MaxLength = 15
        Me.txtFecCaptura.Name = "txtFecCaptura"
        Me.txtFecCaptura.Size = New System.Drawing.Size(167, 28)
        Me.txtFecCaptura.TabIndex = 3
        '
        'txtCuenta
        '
        Me.txtCuenta.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtCuenta.Location = New System.Drawing.Point(265, 169)
        Me.txtCuenta.MaxLength = 10
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(167, 28)
        Me.txtCuenta.TabIndex = 2
        '
        'txtAgencia
        '
        Me.txtAgencia.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtAgencia.Location = New System.Drawing.Point(265, 124)
        Me.txtAgencia.MaxLength = 15
        Me.txtAgencia.Name = "txtAgencia"
        Me.txtAgencia.Size = New System.Drawing.Size(167, 28)
        Me.txtAgencia.TabIndex = 1
        '
        'txtTicket
        '
        Me.txtTicket.Location = New System.Drawing.Point(265, 43)
        Me.txtTicket.MaxLength = 7
        Me.txtTicket.Name = "txtTicket"
        Me.txtTicket.Size = New System.Drawing.Size(167, 28)
        Me.txtTicket.TabIndex = 0
        '
        'frmBloqueoTD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(960, 658)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmBloqueoTD"
        Me.Text = "Bloqueo / Desbloqueo de Time Deposits"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmdSalir As Button
    Friend WithEvents cmdLimpiar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmdBloquear As Button
    Friend WithEvents txtComentario As TextBox
    Friend WithEvents lblComentario As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblMonto As Label
    Friend WithEvents lblConcepto As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblCuenta As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTicket As Label
    Friend WithEvents txtPlazo As TextBox
    Friend WithEvents txtTasa As TextBox
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents txtOrigen As TextBox
    Friend WithEvents txtFecVencimiento As TextBox
    Friend WithEvents txtFecOperacion As TextBox
    Friend WithEvents txtFecCaptura As TextBox
    Friend WithEvents txtCuenta As TextBox
    Friend WithEvents txtAgencia As TextBox
    Friend WithEvents txtTicket As TextBox
    Friend WithEvents lblMensaje As Label
End Class
