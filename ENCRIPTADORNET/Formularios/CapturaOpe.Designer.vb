<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CapturaOpe
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btGestor = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txCuenta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txNombreAg = New System.Windows.Forms.TextBox()
        Me.txCotitular = New System.Windows.Forms.TextBox()
        Me.txAgencia = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PnDatosCap = New System.Windows.Forms.Panel()
        Me.lbFaxGestor = New System.Windows.Forms.Label()
        Me.lbTelefonoGestor = New System.Windows.Forms.Label()
        Me.lbNombreGestor = New System.Windows.Forms.Label()
        Me.lbCveGestor = New System.Windows.Forms.Label()
        Me.lbRuta = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txBanca = New System.Windows.Forms.TextBox()
        Me.txTipoCueta = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PnGestor = New System.Windows.Forms.Panel()
        Me.lbConcepto = New System.Windows.Forms.Label()
        Me.lbValor = New System.Windows.Forms.Label()
        Me.gvProducto = New System.Windows.Forms.DataGridView()
        Me.gvOperaciones = New System.Windows.Forms.DataGridView()
        Me.btDepositos = New System.Windows.Forms.Button()
        Me.PnDatosCap.SuspendLayout()
        Me.PnGestor.SuspendLayout()
        CType(Me.gvProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvOperaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btGestor
        '
        Me.btGestor.Location = New System.Drawing.Point(6, 5)
        Me.btGestor.Name = "btGestor"
        Me.btGestor.Size = New System.Drawing.Size(113, 23)
        Me.btGestor.TabIndex = 0
        Me.btGestor.Text = "Registrar Gestor"
        Me.btGestor.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Buscar por cuenta"
        '
        'txCuenta
        '
        Me.txCuenta.Location = New System.Drawing.Point(104, 12)
        Me.txCuenta.Name = "txCuenta"
        Me.txCuenta.Size = New System.Drawing.Size(91, 20)
        Me.txCuenta.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Buscar por cotitular"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Buscar por nombre"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(219, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Agencia"
        '
        'txNombreAg
        '
        Me.txNombreAg.Location = New System.Drawing.Point(104, 41)
        Me.txNombreAg.Name = "txNombreAg"
        Me.txNombreAg.Size = New System.Drawing.Size(418, 20)
        Me.txNombreAg.TabIndex = 6
        '
        'txCotitular
        '
        Me.txCotitular.Location = New System.Drawing.Point(104, 67)
        Me.txCotitular.Name = "txCotitular"
        Me.txCotitular.Size = New System.Drawing.Size(418, 20)
        Me.txCotitular.TabIndex = 7
        '
        'txAgencia
        '
        Me.txAgencia.Location = New System.Drawing.Point(271, 11)
        Me.txAgencia.Name = "txAgencia"
        Me.txAgencia.Size = New System.Drawing.Size(397, 20)
        Me.txAgencia.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(537, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Fecha Apertura"
        '
        'PnDatosCap
        '
        Me.PnDatosCap.Controls.Add(Me.btDepositos)
        Me.PnDatosCap.Controls.Add(Me.gvOperaciones)
        Me.PnDatosCap.Controls.Add(Me.gvProducto)
        Me.PnDatosCap.Controls.Add(Me.lbValor)
        Me.PnDatosCap.Controls.Add(Me.lbConcepto)
        Me.PnDatosCap.Controls.Add(Me.lbFaxGestor)
        Me.PnDatosCap.Controls.Add(Me.lbTelefonoGestor)
        Me.PnDatosCap.Controls.Add(Me.lbNombreGestor)
        Me.PnDatosCap.Controls.Add(Me.lbCveGestor)
        Me.PnDatosCap.Controls.Add(Me.lbRuta)
        Me.PnDatosCap.Controls.Add(Me.Button2)
        Me.PnDatosCap.Controls.Add(Me.Button1)
        Me.PnDatosCap.Controls.Add(Me.txBanca)
        Me.PnDatosCap.Controls.Add(Me.txTipoCueta)
        Me.PnDatosCap.Controls.Add(Me.Label8)
        Me.PnDatosCap.Controls.Add(Me.Label7)
        Me.PnDatosCap.Controls.Add(Me.Label6)
        Me.PnDatosCap.Controls.Add(Me.txNombreAg)
        Me.PnDatosCap.Controls.Add(Me.Label5)
        Me.PnDatosCap.Controls.Add(Me.Label1)
        Me.PnDatosCap.Controls.Add(Me.txAgencia)
        Me.PnDatosCap.Controls.Add(Me.txCuenta)
        Me.PnDatosCap.Controls.Add(Me.txCotitular)
        Me.PnDatosCap.Controls.Add(Me.Label2)
        Me.PnDatosCap.Controls.Add(Me.Label3)
        Me.PnDatosCap.Controls.Add(Me.Label4)
        Me.PnDatosCap.Location = New System.Drawing.Point(9, 12)
        Me.PnDatosCap.Name = "PnDatosCap"
        Me.PnDatosCap.Size = New System.Drawing.Size(835, 506)
        Me.PnDatosCap.TabIndex = 10
        '
        'lbFaxGestor
        '
        Me.lbFaxGestor.AutoSize = True
        Me.lbFaxGestor.Location = New System.Drawing.Point(716, 97)
        Me.lbFaxGestor.Name = "lbFaxGestor"
        Me.lbFaxGestor.Size = New System.Drawing.Size(0, 13)
        Me.lbFaxGestor.TabIndex = 21
        '
        'lbTelefonoGestor
        '
        Me.lbTelefonoGestor.AutoSize = True
        Me.lbTelefonoGestor.Location = New System.Drawing.Point(593, 97)
        Me.lbTelefonoGestor.Name = "lbTelefonoGestor"
        Me.lbTelefonoGestor.Size = New System.Drawing.Size(0, 13)
        Me.lbTelefonoGestor.TabIndex = 20
        '
        'lbNombreGestor
        '
        Me.lbNombreGestor.AutoSize = True
        Me.lbNombreGestor.Location = New System.Drawing.Point(157, 97)
        Me.lbNombreGestor.MinimumSize = New System.Drawing.Size(360, 0)
        Me.lbNombreGestor.Name = "lbNombreGestor"
        Me.lbNombreGestor.Size = New System.Drawing.Size(360, 13)
        Me.lbNombreGestor.TabIndex = 19
        Me.lbNombreGestor.Text = "NombreGestor"
        '
        'lbCveGestor
        '
        Me.lbCveGestor.AutoSize = True
        Me.lbCveGestor.Location = New System.Drawing.Point(101, 97)
        Me.lbCveGestor.MinimumSize = New System.Drawing.Size(50, 0)
        Me.lbCveGestor.Name = "lbCveGestor"
        Me.lbCveGestor.Size = New System.Drawing.Size(57, 13)
        Me.lbCveGestor.TabIndex = 18
        Me.lbCveGestor.Text = "CveGestor"
        '
        'lbRuta
        '
        Me.lbRuta.Location = New System.Drawing.Point(7, 125)
        Me.lbRuta.Name = "lbRuta"
        Me.lbRuta.Size = New System.Drawing.Size(800, 41)
        Me.lbRuta.TabIndex = 17
        Me.lbRuta.Text = "Ruta Organizacional"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(688, 175)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(127, 23)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Saldo Disponible"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(540, 175)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 23)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txBanca
        '
        Me.txBanca.Enabled = False
        Me.txBanca.Location = New System.Drawing.Point(222, 179)
        Me.txBanca.Name = "txBanca"
        Me.txBanca.Size = New System.Drawing.Size(300, 20)
        Me.txBanca.TabIndex = 14
        '
        'txTipoCueta
        '
        Me.txTipoCueta.Location = New System.Drawing.Point(7, 179)
        Me.txTipoCueta.Name = "txTipoCueta"
        Me.txTipoCueta.Size = New System.Drawing.Size(188, 20)
        Me.txTipoCueta.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(685, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Fax"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(537, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Telefono"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Gestor"
        '
        'PnGestor
        '
        Me.PnGestor.Controls.Add(Me.btGestor)
        Me.PnGestor.Location = New System.Drawing.Point(9, 7)
        Me.PnGestor.Name = "PnGestor"
        Me.PnGestor.Size = New System.Drawing.Size(124, 34)
        Me.PnGestor.TabIndex = 11
        '
        'lbConcepto
        '
        Me.lbConcepto.Location = New System.Drawing.Point(540, 213)
        Me.lbConcepto.Name = "lbConcepto"
        Me.lbConcepto.Size = New System.Drawing.Size(275, 20)
        Me.lbConcepto.TabIndex = 22
        Me.lbConcepto.Text = "Concepto"
        Me.lbConcepto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbValor
        '
        Me.lbValor.Location = New System.Drawing.Point(540, 249)
        Me.lbValor.Name = "lbValor"
        Me.lbValor.Size = New System.Drawing.Size(275, 17)
        Me.lbValor.TabIndex = 23
        Me.lbValor.Text = "valor"
        Me.lbValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gvProducto
        '
        Me.gvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvProducto.Location = New System.Drawing.Point(6, 222)
        Me.gvProducto.Name = "gvProducto"
        Me.gvProducto.Size = New System.Drawing.Size(516, 108)
        Me.gvProducto.TabIndex = 24
        '
        'gvOperaciones
        '
        Me.gvOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvOperaciones.Location = New System.Drawing.Point(6, 354)
        Me.gvOperaciones.Name = "gvOperaciones"
        Me.gvOperaciones.Size = New System.Drawing.Size(809, 108)
        Me.gvOperaciones.TabIndex = 25
        '
        'btDepositos
        '
        Me.btDepositos.Location = New System.Drawing.Point(7, 469)
        Me.btDepositos.Name = "btDepositos"
        Me.btDepositos.Size = New System.Drawing.Size(75, 23)
        Me.btDepositos.TabIndex = 26
        Me.btDepositos.Text = "Depositos"
        Me.btDepositos.UseVisualStyleBackColor = True
        '
        'CapturaOpe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 530)
        Me.Controls.Add(Me.PnGestor)
        Me.Controls.Add(Me.PnDatosCap)
        Me.Name = "CapturaOpe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de operaciones"
        Me.PnDatosCap.ResumeLayout(False)
        Me.PnDatosCap.PerformLayout()
        Me.PnGestor.ResumeLayout(False)
        CType(Me.gvProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvOperaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btGestor As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txCuenta As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txNombreAg As TextBox
    Friend WithEvents txCotitular As TextBox
    Friend WithEvents txAgencia As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents PnDatosCap As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents txBanca As TextBox
    Friend WithEvents txTipoCueta As TextBox
    Friend WithEvents lbNombreGestor As Label
    Friend WithEvents lbCveGestor As Label
    Friend WithEvents lbRuta As Label
    Friend WithEvents PnGestor As Panel
    Friend WithEvents lbTelefonoGestor As Label
    Friend WithEvents lbFaxGestor As Label
    Friend WithEvents lbValor As Label
    Friend WithEvents lbConcepto As Label
    Friend WithEvents gvProducto As DataGridView
    Friend WithEvents btDepositos As Button
    Friend WithEvents gvOperaciones As DataGridView
End Class
