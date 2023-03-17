<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCancelaTicket
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancelaTicket))
        Me.txtTicket = New System.Windows.Forms.TextBox()
        Me.txtComentario = New System.Windows.Forms.RichTextBox()
        Me.cmdLimpia = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.lblCtaCte = New System.Windows.Forms.Label()
        Me.LblFechaCaptura = New System.Windows.Forms.Label()
        Me.LblFechaOperacion = New System.Windows.Forms.Label()
        Me.lblTicket = New System.Windows.Forms.Label()
        Me.lblNomMonto = New System.Windows.Forms.Label()
        Me.lblCuenta = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblComentario = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtTicket
        '
        Me.txtTicket.Location = New System.Drawing.Point(82, 21)
        Me.txtTicket.Name = "txtTicket"
        Me.txtTicket.Size = New System.Drawing.Size(186, 26)
        Me.txtTicket.TabIndex = 0
        '
        'txtComentario
        '
        Me.txtComentario.Enabled = False
        Me.txtComentario.Location = New System.Drawing.Point(113, 168)
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(626, 115)
        Me.txtComentario.TabIndex = 5
        Me.txtComentario.Text = ""
        '
        'cmdLimpia
        '
        Me.cmdLimpia.Location = New System.Drawing.Point(348, 302)
        Me.cmdLimpia.Name = "cmdLimpia"
        Me.cmdLimpia.Size = New System.Drawing.Size(116, 38)
        Me.cmdLimpia.TabIndex = 6
        Me.cmdLimpia.Text = "&Limpiar"
        Me.cmdLimpia.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(485, 302)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(116, 38)
        Me.cmdCancelar.TabIndex = 7
        Me.cmdCancelar.Text = "&Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(623, 302)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(116, 38)
        Me.cmdSalir.TabIndex = 8
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'lblMonto
        '
        Me.lblMonto.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblMonto.Location = New System.Drawing.Point(83, 69)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(185, 26)
        Me.lblMonto.TabIndex = 9
        '
        'lblCtaCte
        '
        Me.lblCtaCte.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblCtaCte.Location = New System.Drawing.Point(83, 115)
        Me.lblCtaCte.Name = "lblCtaCte"
        Me.lblCtaCte.Size = New System.Drawing.Size(185, 26)
        Me.lblCtaCte.TabIndex = 10
        '
        'LblFechaCaptura
        '
        Me.LblFechaCaptura.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LblFechaCaptura.Location = New System.Drawing.Point(477, 69)
        Me.LblFechaCaptura.Name = "LblFechaCaptura"
        Me.LblFechaCaptura.Size = New System.Drawing.Size(147, 26)
        Me.LblFechaCaptura.TabIndex = 11
        '
        'LblFechaOperacion
        '
        Me.LblFechaOperacion.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LblFechaOperacion.Location = New System.Drawing.Point(477, 115)
        Me.LblFechaOperacion.Name = "LblFechaOperacion"
        Me.LblFechaOperacion.Size = New System.Drawing.Size(147, 26)
        Me.LblFechaOperacion.TabIndex = 12
        '
        'lblTicket
        '
        Me.lblTicket.AutoSize = True
        Me.lblTicket.Location = New System.Drawing.Point(12, 27)
        Me.lblTicket.Name = "lblTicket"
        Me.lblTicket.Size = New System.Drawing.Size(55, 20)
        Me.lblTicket.TabIndex = 13
        Me.lblTicket.Text = "Ticket:"
        '
        'lblNomMonto
        '
        Me.lblNomMonto.AutoSize = True
        Me.lblNomMonto.Location = New System.Drawing.Point(12, 75)
        Me.lblNomMonto.Name = "lblNomMonto"
        Me.lblNomMonto.Size = New System.Drawing.Size(58, 20)
        Me.lblNomMonto.TabIndex = 14
        Me.lblNomMonto.Text = "Monto:"
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Location = New System.Drawing.Point(12, 121)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(65, 20)
        Me.lblCuenta.TabIndex = 15
        Me.lblCuenta.Text = "Cuenta:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(352, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 20)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Fecha Captura:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(336, 121)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 20)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Fecha Operación:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(630, 75)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 20)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "(dd-mm-aaaa)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(630, 121)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 20)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "(dd-mm-aaaa)"
        '
        'lblComentario
        '
        Me.lblComentario.AutoSize = True
        Me.lblComentario.Location = New System.Drawing.Point(12, 212)
        Me.lblComentario.Name = "lblComentario"
        Me.lblComentario.Size = New System.Drawing.Size(95, 20)
        Me.lblComentario.TabIndex = 20
        Me.lblComentario.Text = "Comentario:"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblDescripcion.Location = New System.Drawing.Point(274, 21)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(465, 26)
        Me.lblDescripcion.TabIndex = 21
        '
        'frmCancelaTicket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(757, 357)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.lblComentario)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblCuenta)
        Me.Controls.Add(Me.lblNomMonto)
        Me.Controls.Add(Me.lblTicket)
        Me.Controls.Add(Me.LblFechaOperacion)
        Me.Controls.Add(Me.LblFechaCaptura)
        Me.Controls.Add(Me.lblCtaCte)
        Me.Controls.Add(Me.lblMonto)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdLimpia)
        Me.Controls.Add(Me.txtComentario)
        Me.Controls.Add(Me.txtTicket)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCancelaTicket"
        Me.Text = "Cancelación de Operaciones Validadas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtTicket As TextBox
    Friend WithEvents txtComentario As RichTextBox
    Friend WithEvents cmdLimpia As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents cmdSalir As Button
    Friend WithEvents lblMonto As Label
    Friend WithEvents lblCtaCte As Label
    Friend WithEvents LblFechaCaptura As Label
    Friend WithEvents LblFechaOperacion As Label
    Friend WithEvents lblTicket As Label
    Friend WithEvents lblNomMonto As Label
    Friend WithEvents lblCuenta As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblComentario As Label
    Friend WithEvents lblDescripcion As Label
End Class
