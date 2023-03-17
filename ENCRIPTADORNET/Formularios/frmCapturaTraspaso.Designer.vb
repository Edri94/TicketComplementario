<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCapturaTraspaso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapturaTraspaso))
        Me.grbDatos = New System.Windows.Forms.GroupBox()
        Me.dtpFechaOperacion = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaCaptura = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txCuentaAnexa = New System.Windows.Forms.TextBox()
        Me.txCausa = New System.Windows.Forms.TextBox()
        Me.txMonto = New System.Windows.Forms.TextBox()
        Me.txCuenta = New System.Windows.Forms.TextBox()
        Me.txTicket = New System.Windows.Forms.TextBox()
        Me.grbDocto = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txDocto = New System.Windows.Forms.TextBox()
        Me.gbBotones = New System.Windows.Forms.GroupBox()
        Me.btCerrar = New System.Windows.Forms.Button()
        Me.btAgregar = New System.Windows.Forms.Button()
        Me.grbDatos.SuspendLayout()
        Me.grbDocto.SuspendLayout()
        Me.gbBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbDatos
        '
        Me.grbDatos.Controls.Add(Me.dtpFechaOperacion)
        Me.grbDatos.Controls.Add(Me.dtpFechaCaptura)
        Me.grbDatos.Controls.Add(Me.Label7)
        Me.grbDatos.Controls.Add(Me.Label6)
        Me.grbDatos.Controls.Add(Me.Label5)
        Me.grbDatos.Controls.Add(Me.Label4)
        Me.grbDatos.Controls.Add(Me.Label3)
        Me.grbDatos.Controls.Add(Me.Label2)
        Me.grbDatos.Controls.Add(Me.Label1)
        Me.grbDatos.Controls.Add(Me.txCuentaAnexa)
        Me.grbDatos.Controls.Add(Me.txCausa)
        Me.grbDatos.Controls.Add(Me.txMonto)
        Me.grbDatos.Controls.Add(Me.txCuenta)
        Me.grbDatos.Controls.Add(Me.txTicket)
        Me.grbDatos.Location = New System.Drawing.Point(9, 3)
        Me.grbDatos.Name = "grbDatos"
        Me.grbDatos.Size = New System.Drawing.Size(525, 197)
        Me.grbDatos.TabIndex = 0
        Me.grbDatos.TabStop = False
        '
        'dtpFechaOperacion
        '
        Me.dtpFechaOperacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaOperacion.Location = New System.Drawing.Point(133, 112)
        Me.dtpFechaOperacion.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.dtpFechaOperacion.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaOperacion.Name = "dtpFechaOperacion"
        Me.dtpFechaOperacion.Size = New System.Drawing.Size(91, 21)
        Me.dtpFechaOperacion.TabIndex = 15
        '
        'dtpFechaCaptura
        '
        Me.dtpFechaCaptura.Enabled = False
        Me.dtpFechaCaptura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaCaptura.Location = New System.Drawing.Point(133, 84)
        Me.dtpFechaCaptura.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.dtpFechaCaptura.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaCaptura.Name = "dtpFechaCaptura"
        Me.dtpFechaCaptura.Size = New System.Drawing.Size(91, 21)
        Me.dtpFechaCaptura.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(298, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Número de Cuenta"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Cuenta Destino"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(83, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Causa"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Fecha de Operación"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Fecha Captura"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(85, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Monto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(85, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Ticket"
        '
        'txCuentaAnexa
        '
        Me.txCuentaAnexa.Enabled = False
        Me.txCuentaAnexa.Location = New System.Drawing.Point(132, 165)
        Me.txCuentaAnexa.Name = "txCuentaAnexa"
        Me.txCuentaAnexa.Size = New System.Drawing.Size(91, 21)
        Me.txCuentaAnexa.TabIndex = 6
        '
        'txCausa
        '
        Me.txCausa.Enabled = False
        Me.txCausa.Location = New System.Drawing.Point(132, 137)
        Me.txCausa.Name = "txCausa"
        Me.txCausa.Size = New System.Drawing.Size(375, 21)
        Me.txCausa.TabIndex = 5
        '
        'txMonto
        '
        Me.txMonto.Enabled = False
        Me.txMonto.Location = New System.Drawing.Point(132, 53)
        Me.txMonto.Name = "txMonto"
        Me.txMonto.Size = New System.Drawing.Size(91, 21)
        Me.txMonto.TabIndex = 2
        '
        'txCuenta
        '
        Me.txCuenta.Enabled = False
        Me.txCuenta.Location = New System.Drawing.Point(416, 25)
        Me.txCuenta.Name = "txCuenta"
        Me.txCuenta.Size = New System.Drawing.Size(91, 21)
        Me.txCuenta.TabIndex = 1
        '
        'txTicket
        '
        Me.txTicket.Location = New System.Drawing.Point(132, 25)
        Me.txTicket.Name = "txTicket"
        Me.txTicket.Size = New System.Drawing.Size(91, 21)
        Me.txTicket.TabIndex = 0
        '
        'grbDocto
        '
        Me.grbDocto.Controls.Add(Me.Label8)
        Me.grbDocto.Controls.Add(Me.txDocto)
        Me.grbDocto.Location = New System.Drawing.Point(9, 203)
        Me.grbDocto.Name = "grbDocto"
        Me.grbDocto.Size = New System.Drawing.Size(250, 63)
        Me.grbDocto.TabIndex = 1
        Me.grbDocto.TabStop = False
        Me.grbDocto.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(31, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "No. Documento"
        '
        'txDocto
        '
        Me.txDocto.Enabled = False
        Me.txDocto.Location = New System.Drawing.Point(132, 25)
        Me.txDocto.Name = "txDocto"
        Me.txDocto.Size = New System.Drawing.Size(91, 21)
        Me.txDocto.TabIndex = 0
        '
        'gbBotones
        '
        Me.gbBotones.Controls.Add(Me.btCerrar)
        Me.gbBotones.Controls.Add(Me.btAgregar)
        Me.gbBotones.Location = New System.Drawing.Point(282, 203)
        Me.gbBotones.Name = "gbBotones"
        Me.gbBotones.Size = New System.Drawing.Size(250, 63)
        Me.gbBotones.TabIndex = 2
        Me.gbBotones.TabStop = False
        '
        'btCerrar
        '
        Me.btCerrar.Location = New System.Drawing.Point(131, 16)
        Me.btCerrar.Name = "btCerrar"
        Me.btCerrar.Size = New System.Drawing.Size(100, 35)
        Me.btCerrar.TabIndex = 16
        Me.btCerrar.Text = "&Cerrar"
        Me.btCerrar.UseVisualStyleBackColor = True
        '
        'btAgregar
        '
        Me.btAgregar.Enabled = False
        Me.btAgregar.Location = New System.Drawing.Point(21, 16)
        Me.btAgregar.Name = "btAgregar"
        Me.btAgregar.Size = New System.Drawing.Size(100, 35)
        Me.btAgregar.TabIndex = 0
        Me.btAgregar.Text = "&Agregar"
        Me.btAgregar.UseVisualStyleBackColor = True
        '
        'frmCapturaTraspaso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(542, 273)
        Me.Controls.Add(Me.gbBotones)
        Me.Controls.Add(Me.grbDocto)
        Me.Controls.Add(Me.grbDatos)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCapturaTraspaso"
        Me.Text = "Captura de Traspasos"
        Me.grbDatos.ResumeLayout(False)
        Me.grbDatos.PerformLayout()
        Me.grbDocto.ResumeLayout(False)
        Me.grbDocto.PerformLayout()
        Me.gbBotones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grbDatos As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txCuentaAnexa As TextBox
    Friend WithEvents txCausa As TextBox
    Friend WithEvents txMonto As TextBox
    Friend WithEvents txCuenta As TextBox
    Friend WithEvents txTicket As TextBox
    Friend WithEvents grbDocto As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txDocto As TextBox
    Friend WithEvents gbBotones As GroupBox
    Friend WithEvents btCerrar As Button
    Friend WithEvents btAgregar As Button
    Friend WithEvents dtpFechaOperacion As DateTimePicker
    Friend WithEvents dtpFechaCaptura As DateTimePicker
End Class
