<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsulta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsulta))
        Me.cmdCierra = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTicket = New System.Windows.Forms.MaskedTextBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCierra
        '
        Me.cmdCierra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCierra.Location = New System.Drawing.Point(498, 175)
        Me.cmdCierra.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdCierra.Name = "cmdCierra"
        Me.cmdCierra.Size = New System.Drawing.Size(153, 51)
        Me.cmdCierra.TabIndex = 0
        Me.cmdCierra.Text = "Cerrar"
        Me.cmdCierra.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAceptar.Location = New System.Drawing.Point(288, 175)
        Me.cmdAceptar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(153, 51)
        Me.cmdAceptar.TabIndex = 1
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTicket)
        Me.GroupBox1.Controls.Add(Me.lblTitulo)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 18)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(666, 148)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'txtTicket
        '
        Me.txtTicket.Location = New System.Drawing.Point(459, 54)
        Me.txtTicket.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTicket.Mask = "9999999999"
        Me.txtTicket.Name = "txtTicket"
        Me.txtTicket.Size = New System.Drawing.Size(108, 26)
        Me.txtTicket.TabIndex = 2
        Me.txtTicket.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTicket.ValidatingType = GetType(Integer)
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Location = New System.Drawing.Point(32, 54)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(329, 20)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Escriba el número del ... que desea consultar:"
        '
        'frmConsulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(723, 245)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cmdCierra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmConsulta"
        Me.Text = "Consultas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdCierra As Button
    Friend WithEvents cmdAceptar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents txtTicket As MaskedTextBox
End Class
