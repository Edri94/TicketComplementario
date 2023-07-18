<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRepAperturas
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdBuscar = New System.Windows.Forms.Button()
        Me.gvCuentasAperturadas = New System.Windows.Forms.DataGridView()
        Me.Operacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontoOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductoContratado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstatusOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstatusCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rb_PorRango = New System.Windows.Forms.RadioButton()
        Me.rb_ConsolidXTicket = New System.Windows.Forms.RadioButton()
        Me.rb_ValidadasdelDia = New System.Windows.Forms.RadioButton()
        Me.rb_DelDia = New System.Windows.Forms.RadioButton()
        CType(Me.gvCuentasAperturadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(271, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fecha Inicio:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(495, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha Fin:"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmdImprimir.Location = New System.Drawing.Point(451, 21)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(100, 35)
        Me.cmdImprimir.TabIndex = 5
        Me.cmdImprimir.Text = "Imprimir"
        Me.cmdImprimir.UseVisualStyleBackColor = False
        '
        'cmdSalir
        '
        Me.cmdSalir.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmdSalir.Location = New System.Drawing.Point(590, 21)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(100, 35)
        Me.cmdSalir.TabIndex = 6
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = False
        '
        'cmdBuscar
        '
        Me.cmdBuscar.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmdBuscar.Location = New System.Drawing.Point(820, 24)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(100, 35)
        Me.cmdBuscar.TabIndex = 7
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.UseVisualStyleBackColor = False
        '
        'gvCuentasAperturadas
        '
        Me.gvCuentasAperturadas.AllowUserToDeleteRows = False
        Me.gvCuentasAperturadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCuentasAperturadas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Operacion, Me.Cuenta, Me.MontoOperacion, Me.ProductoContratado, Me.EstatusOperacion, Me.EstatusCuenta})
        Me.gvCuentasAperturadas.Location = New System.Drawing.Point(230, 74)
        Me.gvCuentasAperturadas.Name = "gvCuentasAperturadas"
        Me.gvCuentasAperturadas.ReadOnly = True
        Me.gvCuentasAperturadas.Size = New System.Drawing.Size(708, 264)
        Me.gvCuentasAperturadas.TabIndex = 8
        '
        'Operacion
        '
        Me.Operacion.DataPropertyName = "operacion"
        Me.Operacion.HeaderText = "Operacion"
        Me.Operacion.Name = "Operacion"
        Me.Operacion.ReadOnly = True
        '
        'Cuenta
        '
        Me.Cuenta.DataPropertyName = "cuenta_cliente"
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.ReadOnly = True
        '
        'MontoOperacion
        '
        Me.MontoOperacion.DataPropertyName = "monto_operacion"
        Me.MontoOperacion.HeaderText = "Monto"
        Me.MontoOperacion.Name = "MontoOperacion"
        Me.MontoOperacion.ReadOnly = True
        '
        'ProductoContratado
        '
        Me.ProductoContratado.DataPropertyName = "producto_contratado"
        Me.ProductoContratado.HeaderText = "Producto Contratado"
        Me.ProductoContratado.Name = "ProductoContratado"
        Me.ProductoContratado.ReadOnly = True
        '
        'EstatusOperacion
        '
        Me.EstatusOperacion.DataPropertyName = "desc_status_op"
        Me.EstatusOperacion.HeaderText = "Estatus Operacion"
        Me.EstatusOperacion.Name = "EstatusOperacion"
        Me.EstatusOperacion.ReadOnly = True
        '
        'EstatusCuenta
        '
        Me.EstatusCuenta.DataPropertyName = "desc_status_cta"
        Me.EstatusCuenta.HeaderText = "Estatus Cuenta"
        Me.EstatusCuenta.Name = "EstatusCuenta"
        Me.EstatusCuenta.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox1.Controls.Add(Me.gvCuentasAperturadas)
        Me.GroupBox1.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.cmdBuscar)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(952, 425)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones de Filtrado"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdSalir)
        Me.GroupBox2.Controls.Add(Me.cmdImprimir)
        Me.GroupBox2.Location = New System.Drawing.Point(230, 344)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(708, 65)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFin.Location = New System.Drawing.Point(567, 27)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(104, 22)
        Me.dtpFechaFin.TabIndex = 10
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaInicio.Location = New System.Drawing.Point(356, 27)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(108, 22)
        Me.dtpFechaInicio.TabIndex = 9
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox3.Controls.Add(Me.rb_PorRango)
        Me.GroupBox3.Controls.Add(Me.rb_ConsolidXTicket)
        Me.GroupBox3.Controls.Add(Me.rb_ValidadasdelDia)
        Me.GroupBox3.Controls.Add(Me.rb_DelDia)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 30)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(209, 379)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Reporte:"
        '
        'rb_PorRango
        '
        Me.rb_PorRango.AutoSize = True
        Me.rb_PorRango.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_PorRango.Location = New System.Drawing.Point(20, 160)
        Me.rb_PorRango.Name = "rb_PorRango"
        Me.rb_PorRango.Size = New System.Drawing.Size(158, 20)
        Me.rb_PorRango.TabIndex = 3
        Me.rb_PorRango.TabStop = True
        Me.rb_PorRango.Text = "Por Rango de Fechas"
        Me.rb_PorRango.UseVisualStyleBackColor = True
        '
        'rb_ConsolidXTicket
        '
        Me.rb_ConsolidXTicket.AutoSize = True
        Me.rb_ConsolidXTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_ConsolidXTicket.Location = New System.Drawing.Point(20, 222)
        Me.rb_ConsolidXTicket.Name = "rb_ConsolidXTicket"
        Me.rb_ConsolidXTicket.Size = New System.Drawing.Size(166, 20)
        Me.rb_ConsolidXTicket.TabIndex = 2
        Me.rb_ConsolidXTicket.Text = "Consolidado por Ticket"
        Me.rb_ConsolidXTicket.UseVisualStyleBackColor = True
        '
        'rb_ValidadasdelDia
        '
        Me.rb_ValidadasdelDia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_ValidadasdelDia.Location = New System.Drawing.Point(20, 90)
        Me.rb_ValidadasdelDia.Name = "rb_ValidadasdelDia"
        Me.rb_ValidadasdelDia.Size = New System.Drawing.Size(166, 40)
        Me.rb_ValidadasdelDia.TabIndex = 1
        Me.rb_ValidadasdelDia.Text = "Validadas en el Día con Detalle"
        Me.rb_ValidadasdelDia.UseVisualStyleBackColor = True
        '
        'rb_DelDia
        '
        Me.rb_DelDia.AutoSize = True
        Me.rb_DelDia.Checked = True
        Me.rb_DelDia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_DelDia.Location = New System.Drawing.Point(20, 37)
        Me.rb_DelDia.Name = "rb_DelDia"
        Me.rb_DelDia.Size = New System.Drawing.Size(71, 20)
        Me.rb_DelDia.TabIndex = 0
        Me.rb_DelDia.TabStop = True
        Me.rb_DelDia.Text = "Del Día"
        Me.rb_DelDia.UseVisualStyleBackColor = True
        '
        'frmRepAperturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(970, 432)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmRepAperturas"
        Me.Text = "Reportes Apertura de Cuentas CED"
        CType(Me.gvCuentasAperturadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmdImprimir As Button
    Friend WithEvents cmdSalir As Button
    Friend WithEvents cmdBuscar As Button
    Friend WithEvents gvCuentasAperturadas As DataGridView
    Friend WithEvents Operacion As DataGridViewTextBoxColumn
    Friend WithEvents Cuenta As DataGridViewTextBoxColumn
    Friend WithEvents MontoOperacion As DataGridViewTextBoxColumn
    Friend WithEvents ProductoContratado As DataGridViewTextBoxColumn
    Friend WithEvents EstatusOperacion As DataGridViewTextBoxColumn
    Friend WithEvents EstatusCuenta As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rb_ConsolidXTicket As RadioButton
    Friend WithEvents rb_ValidadasdelDia As RadioButton
    Friend WithEvents rb_DelDia As RadioButton
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents rb_PorRango As RadioButton
End Class
