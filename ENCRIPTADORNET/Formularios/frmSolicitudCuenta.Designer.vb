<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSolicitudCuenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSolicitudCuenta))
        Me.CboStatus = New System.Windows.Forms.ComboBox()
        Me.TxtCCuenta = New System.Windows.Forms.TextBox()
        Me.txtNombreCliente = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CboBanca = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboConsultor = New System.Windows.Forms.ComboBox()
        Me.consultor = New System.Windows.Forms.Label()
        Me.TxtCApellidoMat = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtApPat = New System.Windows.Forms.TextBox()
        Me.fechas = New System.Windows.Forms.GroupBox()
        Me.chkFechas = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtFecha1 = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cboAsesores = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmdBuscar = New System.Windows.Forms.Button()
        Me.dgvFiltro = New System.Windows.Forms.DataGridView()
        Me.btnLimpiarFiltro = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.fechas.SuspendLayout()
        Me.Frame2.SuspendLayout()
        CType(Me.dgvFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CboStatus
        '
        Me.CboStatus.FormattingEnabled = True
        Me.CboStatus.Location = New System.Drawing.Point(111, 187)
        Me.CboStatus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CboStatus.Name = "CboStatus"
        Me.CboStatus.Size = New System.Drawing.Size(352, 24)
        Me.CboStatus.TabIndex = 55
        '
        'TxtCCuenta
        '
        Me.TxtCCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCCuenta.Location = New System.Drawing.Point(111, 149)
        Me.TxtCCuenta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtCCuenta.Name = "TxtCCuenta"
        Me.TxtCCuenta.Size = New System.Drawing.Size(352, 22)
        Me.TxtCCuenta.TabIndex = 54
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreCliente.Location = New System.Drawing.Point(111, 110)
        Me.txtNombreCliente.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.Size = New System.Drawing.Size(352, 22)
        Me.txtNombreCliente.TabIndex = 53
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 187)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 18)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Status"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 18)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "Cuenta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 18)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "Nombre(s)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 18)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Cliente"
        '
        'CboBanca
        '
        Me.CboBanca.FormattingEnabled = True
        Me.CboBanca.Location = New System.Drawing.Point(111, 56)
        Me.CboBanca.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CboBanca.Name = "CboBanca"
        Me.CboBanca.Size = New System.Drawing.Size(352, 24)
        Me.CboBanca.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 18)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Banca"
        '
        'cboConsultor
        '
        Me.cboConsultor.FormattingEnabled = True
        Me.cboConsultor.Location = New System.Drawing.Point(201, 60)
        Me.cboConsultor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboConsultor.Name = "cboConsultor"
        Me.cboConsultor.Size = New System.Drawing.Size(0, 24)
        Me.cboConsultor.TabIndex = 46
        '
        'consultor
        '
        Me.consultor.AutoSize = True
        Me.consultor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.consultor.Location = New System.Drawing.Point(22, 22)
        Me.consultor.Name = "consultor"
        Me.consultor.Size = New System.Drawing.Size(55, 18)
        Me.consultor.TabIndex = 45
        Me.consultor.Text = "Asesor"
        '
        'TxtCApellidoMat
        '
        Me.TxtCApellidoMat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCApellidoMat.Location = New System.Drawing.Point(876, 110)
        Me.TxtCApellidoMat.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtCApellidoMat.Name = "TxtCApellidoMat"
        Me.TxtCApellidoMat.Size = New System.Drawing.Size(220, 22)
        Me.TxtCApellidoMat.TabIndex = 61
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(804, 114)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 18)
        Me.Label10.TabIndex = 60
        Me.Label10.Text = "Materno"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(805, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 18)
        Me.Label11.TabIndex = 59
        Me.Label11.Text = "Apellido" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TxtApPat
        '
        Me.TxtApPat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtApPat.Location = New System.Drawing.Point(566, 110)
        Me.TxtApPat.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtApPat.Name = "TxtApPat"
        Me.TxtApPat.Size = New System.Drawing.Size(220, 22)
        Me.TxtApPat.TabIndex = 58
        '
        'fechas
        '
        Me.fechas.Controls.Add(Me.chkFechas)
        Me.fechas.Controls.Add(Me.Label13)
        Me.fechas.Controls.Add(Me.TxtFecha)
        Me.fechas.Controls.Add(Me.Label14)
        Me.fechas.Controls.Add(Me.TxtFecha1)
        Me.fechas.Location = New System.Drawing.Point(620, 149)
        Me.fechas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.fechas.Name = "fechas"
        Me.fechas.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.fechas.Size = New System.Drawing.Size(498, 98)
        Me.fechas.TabIndex = 57
        Me.fechas.TabStop = False
        Me.fechas.Text = "Rango de Fechas"
        '
        'chkFechas
        '
        Me.chkFechas.AutoSize = True
        Me.chkFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFechas.Location = New System.Drawing.Point(128, 0)
        Me.chkFechas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkFechas.Name = "chkFechas"
        Me.chkFechas.Size = New System.Drawing.Size(18, 17)
        Me.chkFechas.TabIndex = 27
        Me.chkFechas.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 57)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(108, 20)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Fecha Inicial:"
        '
        'TxtFecha
        '
        Me.TxtFecha.CustomFormat = "dd-MM-yyyy"
        Me.TxtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtFecha.Location = New System.Drawing.Point(125, 54)
        Me.TxtFecha.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtFecha.Name = "TxtFecha"
        Me.TxtFecha.Size = New System.Drawing.Size(135, 24)
        Me.TxtFecha.TabIndex = 26
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(268, 57)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 20)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Fecha Final:"
        '
        'TxtFecha1
        '
        Me.TxtFecha1.CustomFormat = "dd-MM-yyyy"
        Me.TxtFecha1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtFecha1.Location = New System.Drawing.Point(371, 57)
        Me.TxtFecha1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtFecha1.Name = "TxtFecha1"
        Me.TxtFecha1.Size = New System.Drawing.Size(135, 24)
        Me.TxtFecha1.TabIndex = 28
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(499, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 18)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Paterno"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(499, 94)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 18)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "Apellido" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Frame2
        '
        Me.Frame2.Controls.Add(Me.cmdAceptar)
        Me.Frame2.Controls.Add(Me.cmdSalir)
        Me.Frame2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.Location = New System.Drawing.Point(268, 538)
        Me.Frame2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Frame2.Size = New System.Drawing.Size(612, 85)
        Me.Frame2.TabIndex = 65
        Me.Frame2.TabStop = False
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAceptar.Location = New System.Drawing.Point(118, 22)
        Me.cmdAceptar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(185, 50)
        Me.cmdAceptar.TabIndex = 7
        Me.cmdAceptar.Text = "&Generar Reporte"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalir.Location = New System.Drawing.Point(361, 22)
        Me.cmdSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(185, 50)
        Me.cmdSalir.TabIndex = 8
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cboAsesores
        '
        Me.cboAsesores.FormattingEnabled = True
        Me.cboAsesores.Location = New System.Drawing.Point(111, 16)
        Me.cboAsesores.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboAsesores.Name = "cboAsesores"
        Me.cboAsesores.Size = New System.Drawing.Size(352, 24)
        Me.cboAsesores.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 345)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 17)
        Me.Label1.TabIndex = 68
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(22, 540)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(20, 18)
        Me.lblStatus.TabIndex = 70
        Me.lblStatus.Text = "   "
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Location = New System.Drawing.Point(991, 251)
        Me.cmdBuscar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(112, 36)
        Me.cmdBuscar.TabIndex = 71
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'dgvFiltro
        '
        Me.dgvFiltro.BackgroundColor = System.Drawing.Color.White
        Me.dgvFiltro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFiltro.Location = New System.Drawing.Point(21, 308)
        Me.dgvFiltro.Name = "dgvFiltro"
        Me.dgvFiltro.RowHeadersWidth = 51
        Me.dgvFiltro.RowTemplate.Height = 24
        Me.dgvFiltro.Size = New System.Drawing.Size(1104, 225)
        Me.dgvFiltro.TabIndex = 73
        '
        'btnLimpiarFiltro
        '
        Me.btnLimpiarFiltro.Location = New System.Drawing.Point(862, 251)
        Me.btnLimpiarFiltro.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnLimpiarFiltro.Name = "btnLimpiarFiltro"
        Me.btnLimpiarFiltro.Size = New System.Drawing.Size(112, 36)
        Me.btnLimpiarFiltro.TabIndex = 74
        Me.btnLimpiarFiltro.Text = "Limpiar filtro"
        Me.btnLimpiarFiltro.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(122, 15)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(220, 23)
        Me.ProgressBar1.TabIndex = 75
        Me.ProgressBar1.Value = 10
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Location = New System.Drawing.Point(407, 250)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(359, 54)
        Me.Panel1.TabIndex = 76
        Me.Panel1.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(5, 20)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 18)
        Me.Label7.TabIndex = 77
        Me.Label7.Text = "   Cargando"
        '
        'frmSolicitudCuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1152, 627)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnLimpiarFiltro)
        Me.Controls.Add(Me.dgvFiltro)
        Me.Controls.Add(Me.cmdBuscar)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboAsesores)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtCApellidoMat)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtApPat)
        Me.Controls.Add(Me.fechas)
        Me.Controls.Add(Me.CboStatus)
        Me.Controls.Add(Me.TxtCCuenta)
        Me.Controls.Add(Me.txtNombreCliente)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CboBanca)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboConsultor)
        Me.Controls.Add(Me.consultor)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmSolicitudCuenta"
        Me.Text = "Reporte Go-MAC"
        Me.fechas.ResumeLayout(False)
        Me.fechas.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        CType(Me.dgvFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CboStatus As ComboBox
    Friend WithEvents TxtCCuenta As TextBox
    Friend WithEvents txtNombreCliente As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents CboBanca As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cboConsultor As ComboBox
    Friend WithEvents consultor As Label
    Friend WithEvents TxtCApellidoMat As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TxtApPat As TextBox
    Friend WithEvents fechas As GroupBox
    Friend WithEvents chkFechas As CheckBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TxtFecha As DateTimePicker
    Friend WithEvents Label14 As Label
    Friend WithEvents TxtFecha1 As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Frame2 As GroupBox
    Friend WithEvents cmdAceptar As Button
    Friend WithEvents cmdSalir As Button
    Friend WithEvents cboAsesores As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents cmdBuscar As Button
    Friend WithEvents dgvFiltro As DataGridView
    Friend WithEvents btnLimpiarFiltro As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
End Class
