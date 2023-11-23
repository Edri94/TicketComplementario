<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaSaldosMov
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
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.lblOrigenCta = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFechaApertura = New System.Windows.Forms.Label()
        Me.lblECancelacion = New System.Windows.Forms.Label()
        Me.lblFechaCancelacion = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCuentaHouston = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNumFuncionario = New System.Windows.Forms.Label()
        Me.lblFuncionario = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.lblFax = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblUGestora = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTipoCuenta = New System.Windows.Forms.Label()
        Me.lblBanca = New System.Windows.Forms.Label()
        Me.btnCuentaManc = New System.Windows.Forms.Button()
        Me.btnSaldoDisp = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gridProductos = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblValorConcepto = New System.Windows.Forms.Label()
        Me.lblDescripcionConcepto = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.gridOperaciones = New System.Windows.Forms.DataGridView()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbAgencia = New System.Windows.Forms.ComboBox()
        Me.lblCotitular = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.loading = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.gridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.gridOperaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.loading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(202, 20)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(129, 26)
        Me.txtCuenta.TabIndex = 1
        '
        'lblOrigenCta
        '
        Me.lblOrigenCta.Location = New System.Drawing.Point(654, 24)
        Me.lblOrigenCta.Name = "lblOrigenCta"
        Me.lblOrigenCta.Size = New System.Drawing.Size(572, 24)
        Me.lblOrigenCta.TabIndex = 2
        Me.lblOrigenCta.Text = "Origen de la Apertura"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(654, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 22)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha Apertura:"
        '
        'lblFechaApertura
        '
        Me.lblFechaApertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFechaApertura.Location = New System.Drawing.Point(786, 63)
        Me.lblFechaApertura.Name = "lblFechaApertura"
        Me.lblFechaApertura.Size = New System.Drawing.Size(122, 27)
        Me.lblFechaApertura.TabIndex = 3
        '
        'lblECancelacion
        '
        Me.lblECancelacion.Location = New System.Drawing.Point(933, 65)
        Me.lblECancelacion.Name = "lblECancelacion"
        Me.lblECancelacion.Size = New System.Drawing.Size(150, 24)
        Me.lblECancelacion.TabIndex = 2
        Me.lblECancelacion.Text = "Fecha Cancelacion:"
        '
        'lblFechaCancelacion
        '
        Me.lblFechaCancelacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFechaCancelacion.Location = New System.Drawing.Point(1089, 62)
        Me.lblFechaCancelacion.Name = "lblFechaCancelacion"
        Me.lblFechaCancelacion.Size = New System.Drawing.Size(129, 28)
        Me.lblFechaCancelacion.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(654, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(170, 25)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Cuenta Houston:"
        '
        'lblCuentaHouston
        '
        Me.lblCuentaHouston.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCuentaHouston.Location = New System.Drawing.Point(786, 101)
        Me.lblCuentaHouston.Name = "lblCuentaHouston"
        Me.lblCuentaHouston.Size = New System.Drawing.Size(200, 28)
        Me.lblCuentaHouston.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Gestor:"
        '
        'lblNumFuncionario
        '
        Me.lblNumFuncionario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumFuncionario.Location = New System.Drawing.Point(110, 142)
        Me.lblNumFuncionario.Name = "lblNumFuncionario"
        Me.lblNumFuncionario.Size = New System.Drawing.Size(115, 21)
        Me.lblNumFuncionario.TabIndex = 5
        '
        'lblFuncionario
        '
        Me.lblFuncionario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFuncionario.Location = New System.Drawing.Point(231, 143)
        Me.lblFuncionario.Name = "lblFuncionario"
        Me.lblFuncionario.Size = New System.Drawing.Size(409, 20)
        Me.lblFuncionario.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(654, 173)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Telefono:"
        '
        'lblTelefono
        '
        Me.lblTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTelefono.Location = New System.Drawing.Point(742, 177)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(180, 21)
        Me.lblTelefono.TabIndex = 5
        '
        'lblFax
        '
        Me.lblFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFax.Location = New System.Drawing.Point(1022, 177)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(204, 20)
        Me.lblFax.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(962, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 20)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Fax:"
        '
        'lblUGestora
        '
        Me.lblUGestora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUGestora.Location = New System.Drawing.Point(786, 132)
        Me.lblUGestora.Name = "lblUGestora"
        Me.lblUGestora.Size = New System.Drawing.Size(200, 28)
        Me.lblUGestora.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(654, 140)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 20)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "U Gestora:"
        '
        'lblTipoCuenta
        '
        Me.lblTipoCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTipoCuenta.Location = New System.Drawing.Point(23, 236)
        Me.lblTipoCuenta.Name = "lblTipoCuenta"
        Me.lblTipoCuenta.Size = New System.Drawing.Size(288, 26)
        Me.lblTipoCuenta.TabIndex = 7
        '
        'lblBanca
        '
        Me.lblBanca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBanca.Location = New System.Drawing.Point(349, 236)
        Me.lblBanca.Name = "lblBanca"
        Me.lblBanca.Size = New System.Drawing.Size(288, 26)
        Me.lblBanca.TabIndex = 7
        '
        'btnCuentaManc
        '
        Me.btnCuentaManc.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnCuentaManc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCuentaManc.Location = New System.Drawing.Point(859, 232)
        Me.btnCuentaManc.Name = "btnCuentaManc"
        Me.btnCuentaManc.Size = New System.Drawing.Size(207, 35)
        Me.btnCuentaManc.TabIndex = 4
        Me.btnCuentaManc.Text = "Cuenta Mancomunada"
        Me.btnCuentaManc.UseVisualStyleBackColor = False
        '
        'btnSaldoDisp
        '
        Me.btnSaldoDisp.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnSaldoDisp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaldoDisp.Location = New System.Drawing.Point(1086, 232)
        Me.btnSaldoDisp.Name = "btnSaldoDisp"
        Me.btnSaldoDisp.Size = New System.Drawing.Size(137, 35)
        Me.btnSaldoDisp.TabIndex = 5
        Me.btnSaldoDisp.Text = "Saldo Disponible"
        Me.btnSaldoDisp.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(162, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Busqueda por cuenta"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Controls.Add(Me.gridProductos)
        Me.Panel1.Location = New System.Drawing.Point(23, 308)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(585, 200)
        Me.Panel1.TabIndex = 11
        '
        'gridProductos
        '
        Me.gridProductos.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.gridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridProductos.Location = New System.Drawing.Point(3, 3)
        Me.gridProductos.Name = "gridProductos"
        Me.gridProductos.ReadOnly = True
        Me.gridProductos.RowHeadersWidth = 62
        Me.gridProductos.RowTemplate.Height = 28
        Me.gridProductos.Size = New System.Drawing.Size(579, 194)
        Me.gridProductos.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel2.Controls.Add(Me.lblSaldo)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.lblValorConcepto)
        Me.Panel2.Controls.Add(Me.lblDescripcionConcepto)
        Me.Panel2.Location = New System.Drawing.Point(641, 308)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(585, 200)
        Me.Panel2.TabIndex = 11
        '
        'lblSaldo
        '
        Me.lblSaldo.Location = New System.Drawing.Point(400, 146)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(157, 37)
        Me.lblSaldo.TabIndex = 0
        Me.lblSaldo.Text = "Saldo Sin Cargar"
        Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(23, 154)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(279, 37)
        Me.Label13.TabIndex = 0
        '
        'lblValorConcepto
        '
        Me.lblValorConcepto.Location = New System.Drawing.Point(23, 83)
        Me.lblValorConcepto.Name = "lblValorConcepto"
        Me.lblValorConcepto.Size = New System.Drawing.Size(534, 43)
        Me.lblValorConcepto.TabIndex = 0
        '
        'lblDescripcionConcepto
        '
        Me.lblDescripcionConcepto.Location = New System.Drawing.Point(23, 19)
        Me.lblDescripcionConcepto.Name = "lblDescripcionConcepto"
        Me.lblDescripcionConcepto.Size = New System.Drawing.Size(534, 49)
        Me.lblDescripcionConcepto.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(23, 276)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(585, 32)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Productos"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(641, 273)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(585, 32)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Conceptos"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel3.Controls.Add(Me.gridOperaciones)
        Me.Panel3.Location = New System.Drawing.Point(23, 520)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1203, 209)
        Me.Panel3.TabIndex = 13
        '
        'gridOperaciones
        '
        Me.gridOperaciones.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.gridOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridOperaciones.Location = New System.Drawing.Point(3, 2)
        Me.gridOperaciones.Name = "gridOperaciones"
        Me.gridOperaciones.ReadOnly = True
        Me.gridOperaciones.RowHeadersWidth = 62
        Me.gridOperaciones.RowTemplate.Height = 28
        Me.gridOperaciones.Size = New System.Drawing.Size(1197, 203)
        Me.gridOperaciones.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(347, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 20)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "Agencia"
        '
        'cmbAgencia
        '
        Me.cmbAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAgencia.FormattingEnabled = True
        Me.cmbAgencia.Location = New System.Drawing.Point(425, 20)
        Me.cmbAgencia.Name = "cmbAgencia"
        Me.cmbAgencia.Size = New System.Drawing.Size(146, 28)
        Me.cmbAgencia.TabIndex = 2
        '
        'lblCotitular
        '
        Me.lblCotitular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCotitular.Location = New System.Drawing.Point(107, 98)
        Me.lblCotitular.Name = "lblCotitular"
        Me.lblCotitular.Size = New System.Drawing.Size(530, 25)
        Me.lblCotitular.TabIndex = 5
        Me.lblCotitular.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(19, 69)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 20)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Cliente:"
        '
        'lblRuta
        '
        Me.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRuta.Location = New System.Drawing.Point(26, 172)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(614, 46)
        Me.lblRuta.TabIndex = 15
        '
        'lblCliente
        '
        Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCliente.Location = New System.Drawing.Point(107, 63)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(530, 25)
        Me.lblCliente.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 20)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Cotitular:"
        Me.Label2.Visible = False
        '
        'BackgroundWorker1
        '
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalir.Location = New System.Drawing.Point(1104, 735)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(119, 42)
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnBuscar
        '
        Me.btnBuscar.FlatAppearance.BorderSize = 0
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Image = Global.Ticket.My.Resources.Resources.lupa
        Me.btnBuscar.Location = New System.Drawing.Point(585, 13)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(41, 38)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'loading
        '
        Me.loading.Image = Global.Ticket.My.Resources.Resources.loading
        Me.loading.Location = New System.Drawing.Point(585, 15)
        Me.loading.Name = "loading"
        Me.loading.Size = New System.Drawing.Size(41, 36)
        Me.loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.loading.TabIndex = 19
        Me.loading.TabStop = False
        Me.loading.Visible = False
        '
        'frmConsultaSaldosMov
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1237, 785)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.loading)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblCliente)
        Me.Controls.Add(Me.lblRuta)
        Me.Controls.Add(Me.cmbAgencia)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnSaldoDisp)
        Me.Controls.Add(Me.btnCuentaManc)
        Me.Controls.Add(Me.lblBanca)
        Me.Controls.Add(Me.lblTipoCuenta)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblUGestora)
        Me.Controls.Add(Me.lblFax)
        Me.Controls.Add(Me.lblCotitular)
        Me.Controls.Add(Me.lblFuncionario)
        Me.Controls.Add(Me.lblTelefono)
        Me.Controls.Add(Me.lblNumFuncionario)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblCuentaHouston)
        Me.Controls.Add(Me.lblFechaCancelacion)
        Me.Controls.Add(Me.lblFechaApertura)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblECancelacion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblOrigenCta)
        Me.Controls.Add(Me.txtCuenta)
        Me.Name = "frmConsultaSaldosMov"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Saldos y Movimientos"
        Me.Panel1.ResumeLayout(False)
        CType(Me.gridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.gridOperaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.loading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCuenta As TextBox
    Friend WithEvents lblOrigenCta As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblFechaApertura As Label
    Friend WithEvents lblECancelacion As Label
    Friend WithEvents lblFechaCancelacion As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblCuentaHouston As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblNumFuncionario As Label
    Friend WithEvents lblFuncionario As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblTelefono As Label
    Friend WithEvents lblFax As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblUGestora As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblTipoCuenta As Label
    Friend WithEvents lblBanca As Label
    Friend WithEvents btnCuentaManc As Button
    Friend WithEvents btnSaldoDisp As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents gridProductos As DataGridView
    Friend WithEvents lblSaldo As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblValorConcepto As Label
    Friend WithEvents lblDescripcionConcepto As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents gridOperaciones As DataGridView
    Friend WithEvents Label15 As Label
    Friend WithEvents cmbAgencia As ComboBox
    Friend WithEvents lblCotitular As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents lblRuta As Label
    Friend WithEvents lblCliente As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnSalir As Button
    Friend WithEvents loading As PictureBox
    Friend WithEvents btnBuscar As Button
End Class
