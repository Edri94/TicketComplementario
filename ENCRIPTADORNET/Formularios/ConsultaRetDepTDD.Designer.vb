<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaRetDepTDD
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
        Me.pnlCancelada = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFuncionario = New System.Windows.Forms.TextBox()
        Me.txtNumFuncionario = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtUsuarioCapt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblStatusSw = New System.Windows.Forms.TextBox()
        Me.txtSaldo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblStatusOp = New System.Windows.Forms.TextBox()
        Me.txtFechaCaptura = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFechaOperacion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.txtNumCuenta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNumOperacion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtMontoTipoCambio = New System.Windows.Forms.TextBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.txtTraduccionReferencia = New System.Windows.Forms.TextBox()
        Me.txtTicketPIU = New System.Windows.Forms.TextBox()
        Me.txtOperacionDefinida = New System.Windows.Forms.TextBox()
        Me.cmdCierra = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pnlCancelada)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtFuncionario)
        Me.GroupBox1.Controls.Add(Me.txtNumFuncionario)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtUsuarioCapt)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblStatusSw)
        Me.GroupBox1.Controls.Add(Me.txtSaldo)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblStatusOp)
        Me.GroupBox1.Controls.Add(Me.txtFechaCaptura)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtFechaOperacion)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtMonto)
        Me.GroupBox1.Controls.Add(Me.txtNumCuenta)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtNumOperacion)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1074, 280)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle del Retiro"
        '
        'pnlCancelada
        '
        Me.pnlCancelada.Location = New System.Drawing.Point(837, 209)
        Me.pnlCancelada.Name = "pnlCancelada"
        Me.pnlCancelada.Size = New System.Drawing.Size(223, 39)
        Me.pnlCancelada.TabIndex = 3
        Me.pnlCancelada.Text = "Operacion Cancelada"
        Me.pnlCancelada.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(951, 76)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 20)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "(dd-mm-aaaa)"
        '
        'txtFuncionario
        '
        Me.txtFuncionario.Location = New System.Drawing.Point(304, 192)
        Me.txtFuncionario.Name = "txtFuncionario"
        Me.txtFuncionario.Size = New System.Drawing.Size(432, 26)
        Me.txtFuncionario.TabIndex = 1
        '
        'txtNumFuncionario
        '
        Me.txtNumFuncionario.Location = New System.Drawing.Point(182, 192)
        Me.txtNumFuncionario.Name = "txtNumFuncionario"
        Me.txtNumFuncionario.Size = New System.Drawing.Size(116, 26)
        Me.txtNumFuncionario.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 198)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Gestor:"
        '
        'txtUsuarioCapt
        '
        Me.txtUsuarioCapt.Location = New System.Drawing.Point(182, 160)
        Me.txtUsuarioCapt.Name = "txtUsuarioCapt"
        Me.txtUsuarioCapt.Size = New System.Drawing.Size(554, 26)
        Me.txtUsuarioCapt.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(156, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Usuario que registro:"
        '
        'lblStatusSw
        '
        Me.lblStatusSw.Location = New System.Drawing.Point(735, 128)
        Me.lblStatusSw.Name = "lblStatusSw"
        Me.lblStatusSw.Size = New System.Drawing.Size(210, 26)
        Me.lblStatusSw.TabIndex = 1
        '
        'txtSaldo
        '
        Me.txtSaldo.Location = New System.Drawing.Point(182, 128)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Size = New System.Drawing.Size(210, 26)
        Me.txtSaldo.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(572, 131)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(99, 20)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Status Swift:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Saldo en Cuenta:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatusOp
        '
        Me.lblStatusOp.Location = New System.Drawing.Point(735, 96)
        Me.lblStatusOp.Name = "lblStatusOp"
        Me.lblStatusOp.Size = New System.Drawing.Size(210, 26)
        Me.lblStatusOp.TabIndex = 1
        '
        'txtFechaCaptura
        '
        Me.txtFechaCaptura.Location = New System.Drawing.Point(182, 96)
        Me.txtFechaCaptura.Name = "txtFechaCaptura"
        Me.txtFechaCaptura.Size = New System.Drawing.Size(210, 26)
        Me.txtFechaCaptura.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(572, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 20)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Status Equation:"
        '
        'txtFechaOperacion
        '
        Me.txtFechaOperacion.Location = New System.Drawing.Point(735, 64)
        Me.txtFechaOperacion.Name = "txtFechaOperacion"
        Me.txtFechaOperacion.Size = New System.Drawing.Size(210, 26)
        Me.txtFechaOperacion.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Fecha de registro:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(572, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(157, 20)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Fecha de Operacion:"
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(182, 64)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(210, 26)
        Me.txtMonto.TabIndex = 1
        '
        'txtNumCuenta
        '
        Me.txtNumCuenta.Location = New System.Drawing.Point(735, 32)
        Me.txtNumCuenta.Name = "txtNumCuenta"
        Me.txtNumCuenta.Size = New System.Drawing.Size(210, 26)
        Me.txtNumCuenta.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Monto del Retiro:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(572, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 20)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Numero de Cuenta:"
        '
        'txtNumOperacion
        '
        Me.txtNumOperacion.Location = New System.Drawing.Point(182, 32)
        Me.txtNumOperacion.Name = "txtNumOperacion"
        Me.txtNumOperacion.Size = New System.Drawing.Size(210, 26)
        Me.txtNumOperacion.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ticket:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtMontoTipoCambio)
        Me.GroupBox2.Controls.Add(Me.txtObservaciones)
        Me.GroupBox2.Controls.Add(Me.txtTraduccionReferencia)
        Me.GroupBox2.Controls.Add(Me.txtTicketPIU)
        Me.GroupBox2.Controls.Add(Me.txtOperacionDefinida)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 298)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1074, 218)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Referencia"
        '
        'txtMontoTipoCambio
        '
        Me.txtMontoTipoCambio.Location = New System.Drawing.Point(114, 167)
        Me.txtMontoTipoCambio.Name = "txtMontoTipoCambio"
        Me.txtMontoTipoCambio.Size = New System.Drawing.Size(831, 26)
        Me.txtMontoTipoCambio.TabIndex = 2
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(114, 135)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(831, 26)
        Me.txtObservaciones.TabIndex = 2
        '
        'txtTraduccionReferencia
        '
        Me.txtTraduccionReferencia.Location = New System.Drawing.Point(114, 103)
        Me.txtTraduccionReferencia.Name = "txtTraduccionReferencia"
        Me.txtTraduccionReferencia.Size = New System.Drawing.Size(831, 26)
        Me.txtTraduccionReferencia.TabIndex = 2
        '
        'txtTicketPIU
        '
        Me.txtTicketPIU.Location = New System.Drawing.Point(114, 71)
        Me.txtTicketPIU.Name = "txtTicketPIU"
        Me.txtTicketPIU.Size = New System.Drawing.Size(831, 26)
        Me.txtTicketPIU.TabIndex = 2
        '
        'txtOperacionDefinida
        '
        Me.txtOperacionDefinida.Location = New System.Drawing.Point(114, 39)
        Me.txtOperacionDefinida.Name = "txtOperacionDefinida"
        Me.txtOperacionDefinida.Size = New System.Drawing.Size(831, 26)
        Me.txtOperacionDefinida.TabIndex = 2
        '
        'cmdCierra
        '
        Me.cmdCierra.Location = New System.Drawing.Point(939, 523)
        Me.cmdCierra.Name = "cmdCierra"
        Me.cmdCierra.Size = New System.Drawing.Size(135, 45)
        Me.cmdCierra.TabIndex = 2
        Me.cmdCierra.Text = "Cerrar"
        Me.cmdCierra.UseVisualStyleBackColor = True
        '
        'ConsultaRetDepTDD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1098, 580)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdCierra)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ConsultaRetDepTDD"
        Me.Text = "Consulta de Retiros"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents pnlCancelada As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents txtFuncionario As TextBox
    Friend WithEvents txtNumFuncionario As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtUsuarioCapt As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lblStatusSw As TextBox
    Friend WithEvents txtSaldo As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblStatusOp As TextBox
    Friend WithEvents txtFechaCaptura As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtFechaOperacion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents txtNumCuenta As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtNumOperacion As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtMontoTipoCambio As TextBox
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents txtTraduccionReferencia As TextBox
    Friend WithEvents txtTicketPIU As TextBox
    Friend WithEvents txtOperacionDefinida As TextBox
    Friend WithEvents cmdCierra As Button
End Class
