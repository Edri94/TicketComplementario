<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepCtasBloqueadas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RepCtasBloqueadas))
        Me.SSPanel1 = New System.Windows.Forms.GroupBox()
        Me.lstAgencia = New System.Windows.Forms.ListBox()
        Me.frmOrden = New System.Windows.Forms.GroupBox()
        Me.rbOrden1 = New System.Windows.Forms.RadioButton()
        Me.rbOrden0 = New System.Windows.Forms.RadioButton()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.rbOpcReporte1 = New System.Windows.Forms.RadioButton()
        Me.rbOpcReporte0 = New System.Windows.Forms.RadioButton()
        Me.txtCuenta1 = New System.Windows.Forms.TextBox()
        Me.txtCuenta0 = New System.Windows.Forms.TextBox()
        Me.dtpFecha1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpFecha0 = New System.Windows.Forms.DateTimePicker()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.chkTipoBloqueo3 = New System.Windows.Forms.CheckBox()
        Me.chkTipoBloqueo4 = New System.Windows.Forms.CheckBox()
        Me.chkTipoBloqueo1 = New System.Windows.Forms.CheckBox()
        Me.chkTipoBloqueo2 = New System.Windows.Forms.CheckBox()
        Me.chkTipoBloqueo0 = New System.Windows.Forms.CheckBox()
        Me.dgvBloqueo = New System.Windows.Forms.DataGridView()
        Me.cmdBuscar = New System.Windows.Forms.Button()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.SSPanel1.SuspendLayout()
        Me.frmOrden.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        CType(Me.dgvBloqueo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SSPanel1
        '
        Me.SSPanel1.Controls.Add(Me.lstAgencia)
        Me.SSPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSPanel1.Location = New System.Drawing.Point(12, 12)
        Me.SSPanel1.Name = "SSPanel1"
        Me.SSPanel1.Size = New System.Drawing.Size(166, 92)
        Me.SSPanel1.TabIndex = 0
        Me.SSPanel1.TabStop = False
        Me.SSPanel1.Text = "Agencia"
        '
        'lstAgencia
        '
        Me.lstAgencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAgencia.FormattingEnabled = True
        Me.lstAgencia.ItemHeight = 20
        Me.lstAgencia.Location = New System.Drawing.Point(19, 34)
        Me.lstAgencia.Name = "lstAgencia"
        Me.lstAgencia.Size = New System.Drawing.Size(125, 44)
        Me.lstAgencia.TabIndex = 1
        '
        'frmOrden
        '
        Me.frmOrden.Controls.Add(Me.rbOrden1)
        Me.frmOrden.Controls.Add(Me.rbOrden0)
        Me.frmOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmOrden.Location = New System.Drawing.Point(198, 12)
        Me.frmOrden.Name = "frmOrden"
        Me.frmOrden.Size = New System.Drawing.Size(296, 92)
        Me.frmOrden.TabIndex = 1
        Me.frmOrden.TabStop = False
        Me.frmOrden.Text = "Ordenado por"
        '
        'rbOrden1
        '
        Me.rbOrden1.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbOrden1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbOrden1.Location = New System.Drawing.Point(151, 27)
        Me.rbOrden1.Name = "rbOrden1"
        Me.rbOrden1.Size = New System.Drawing.Size(129, 52)
        Me.rbOrden1.TabIndex = 8
        Me.rbOrden1.TabStop = True
        Me.rbOrden1.Text = "Cuenta"
        Me.rbOrden1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbOrden1.UseVisualStyleBackColor = True
        '
        'rbOrden0
        '
        Me.rbOrden0.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbOrden0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbOrden0.Location = New System.Drawing.Point(6, 28)
        Me.rbOrden0.Name = "rbOrden0"
        Me.rbOrden0.Size = New System.Drawing.Size(129, 51)
        Me.rbOrden0.TabIndex = 7
        Me.rbOrden0.TabStop = True
        Me.rbOrden0.Text = "Fecha"
        Me.rbOrden0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbOrden0.UseVisualStyleBackColor = True
        '
        'Frame2
        '
        Me.Frame2.Controls.Add(Me.rbOpcReporte1)
        Me.Frame2.Controls.Add(Me.rbOpcReporte0)
        Me.Frame2.Controls.Add(Me.txtCuenta1)
        Me.Frame2.Controls.Add(Me.txtCuenta0)
        Me.Frame2.Controls.Add(Me.dtpFecha1)
        Me.Frame2.Controls.Add(Me.dtpFecha0)
        Me.Frame2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.Location = New System.Drawing.Point(12, 119)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Size = New System.Drawing.Size(482, 193)
        Me.Frame2.TabIndex = 2
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "  Opción de Reporte"
        '
        'rbOpcReporte1
        '
        Me.rbOpcReporte1.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbOpcReporte1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbOpcReporte1.Location = New System.Drawing.Point(52, 121)
        Me.rbOpcReporte1.Name = "rbOpcReporte1"
        Me.rbOpcReporte1.Size = New System.Drawing.Size(129, 47)
        Me.rbOpcReporte1.TabIndex = 7
        Me.rbOpcReporte1.TabStop = True
        Me.rbOpcReporte1.Text = "Por Cuenta:"
        Me.rbOpcReporte1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbOpcReporte1.UseVisualStyleBackColor = True
        '
        'rbOpcReporte0
        '
        Me.rbOpcReporte0.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbOpcReporte0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbOpcReporte0.Location = New System.Drawing.Point(52, 46)
        Me.rbOpcReporte0.Name = "rbOpcReporte0"
        Me.rbOpcReporte0.Size = New System.Drawing.Size(129, 45)
        Me.rbOpcReporte0.TabIndex = 6
        Me.rbOpcReporte0.TabStop = True
        Me.rbOpcReporte0.Text = "Por Fecha:"
        Me.rbOpcReporte0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbOpcReporte0.UseVisualStyleBackColor = True
        '
        'txtCuenta1
        '
        Me.txtCuenta1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta1.Location = New System.Drawing.Point(322, 131)
        Me.txtCuenta1.Name = "txtCuenta1"
        Me.txtCuenta1.Size = New System.Drawing.Size(119, 26)
        Me.txtCuenta1.TabIndex = 5
        '
        'txtCuenta0
        '
        Me.txtCuenta0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta0.Location = New System.Drawing.Point(188, 131)
        Me.txtCuenta0.Name = "txtCuenta0"
        Me.txtCuenta0.Size = New System.Drawing.Size(119, 26)
        Me.txtCuenta0.TabIndex = 4
        '
        'dtpFecha1
        '
        Me.dtpFecha1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha1.Location = New System.Drawing.Point(318, 58)
        Me.dtpFecha1.Name = "dtpFecha1"
        Me.dtpFecha1.Size = New System.Drawing.Size(119, 26)
        Me.dtpFecha1.TabIndex = 2
        '
        'dtpFecha0
        '
        Me.dtpFecha0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha0.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha0.Location = New System.Drawing.Point(187, 58)
        Me.dtpFecha0.Name = "dtpFecha0"
        Me.dtpFecha0.Size = New System.Drawing.Size(119, 26)
        Me.dtpFecha0.TabIndex = 1
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.chkTipoBloqueo3)
        Me.Frame1.Controls.Add(Me.chkTipoBloqueo4)
        Me.Frame1.Controls.Add(Me.chkTipoBloqueo1)
        Me.Frame1.Controls.Add(Me.chkTipoBloqueo2)
        Me.Frame1.Controls.Add(Me.chkTipoBloqueo0)
        Me.Frame1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.Location = New System.Drawing.Point(511, 12)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(367, 300)
        Me.Frame1.TabIndex = 3
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Selección del Tipo de Bloqueo"
        '
        'chkTipoBloqueo3
        '
        Me.chkTipoBloqueo3.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkTipoBloqueo3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTipoBloqueo3.Location = New System.Drawing.Point(203, 138)
        Me.chkTipoBloqueo3.Name = "chkTipoBloqueo3"
        Me.chkTipoBloqueo3.Size = New System.Drawing.Size(144, 60)
        Me.chkTipoBloqueo3.TabIndex = 5
        Me.chkTipoBloqueo3.Text = "Por Desvios P.M.E."
        Me.chkTipoBloqueo3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkTipoBloqueo3.UseVisualStyleBackColor = True
        '
        'chkTipoBloqueo4
        '
        Me.chkTipoBloqueo4.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkTipoBloqueo4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTipoBloqueo4.Location = New System.Drawing.Point(136, 211)
        Me.chkTipoBloqueo4.Name = "chkTipoBloqueo4"
        Me.chkTipoBloqueo4.Size = New System.Drawing.Size(129, 60)
        Me.chkTipoBloqueo4.TabIndex = 4
        Me.chkTipoBloqueo4.Text = "Otros"
        Me.chkTipoBloqueo4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkTipoBloqueo4.UseVisualStyleBackColor = True
        '
        'chkTipoBloqueo1
        '
        Me.chkTipoBloqueo1.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkTipoBloqueo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTipoBloqueo1.Location = New System.Drawing.Point(203, 49)
        Me.chkTipoBloqueo1.Name = "chkTipoBloqueo1"
        Me.chkTipoBloqueo1.Size = New System.Drawing.Size(144, 61)
        Me.chkTipoBloqueo1.TabIndex = 3
        Me.chkTipoBloqueo1.Text = "Por Crédito Asociado"
        Me.chkTipoBloqueo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkTipoBloqueo1.UseVisualStyleBackColor = True
        '
        'chkTipoBloqueo2
        '
        Me.chkTipoBloqueo2.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkTipoBloqueo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTipoBloqueo2.Location = New System.Drawing.Point(22, 138)
        Me.chkTipoBloqueo2.Name = "chkTipoBloqueo2"
        Me.chkTipoBloqueo2.Size = New System.Drawing.Size(165, 60)
        Me.chkTipoBloqueo2.TabIndex = 2
        Me.chkTipoBloqueo2.Text = "Por TDD Asociada"
        Me.chkTipoBloqueo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkTipoBloqueo2.UseVisualStyleBackColor = True
        '
        'chkTipoBloqueo0
        '
        Me.chkTipoBloqueo0.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkTipoBloqueo0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTipoBloqueo0.Location = New System.Drawing.Point(22, 50)
        Me.chkTipoBloqueo0.Name = "chkTipoBloqueo0"
        Me.chkTipoBloqueo0.Size = New System.Drawing.Size(165, 60)
        Me.chkTipoBloqueo0.TabIndex = 1
        Me.chkTipoBloqueo0.Text = "Por Documentación NO Entregada"
        Me.chkTipoBloqueo0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkTipoBloqueo0.UseVisualStyleBackColor = True
        '
        'dgvBloqueo
        '
        Me.dgvBloqueo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBloqueo.Location = New System.Drawing.Point(12, 329)
        Me.dgvBloqueo.Name = "dgvBloqueo"
        Me.dgvBloqueo.RowHeadersWidth = 62
        Me.dgvBloqueo.RowTemplate.Height = 28
        Me.dgvBloqueo.Size = New System.Drawing.Size(866, 286)
        Me.dgvBloqueo.TabIndex = 4
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Location = New System.Drawing.Point(499, 636)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(110, 41)
        Me.cmdBuscar.TabIndex = 5
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'cmdImprimir
        '
        Me.cmdImprimir.Location = New System.Drawing.Point(636, 636)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(110, 41)
        Me.cmdImprimir.TabIndex = 6
        Me.cmdImprimir.Text = "Imprimir"
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(769, 636)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(109, 41)
        Me.cmdSalir.TabIndex = 7
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'RepCtasBloqueadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(891, 692)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.cmdBuscar)
        Me.Controls.Add(Me.dgvBloqueo)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.frmOrden)
        Me.Controls.Add(Me.SSPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "RepCtasBloqueadas"
        Me.Text = "RepCtasBloqueadas"
        Me.SSPanel1.ResumeLayout(False)
        Me.frmOrden.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        CType(Me.dgvBloqueo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SSPanel1 As GroupBox
    Friend WithEvents lstAgencia As ListBox
    Friend WithEvents frmOrden As GroupBox
    Friend WithEvents Frame2 As GroupBox
    Friend WithEvents txtCuenta1 As TextBox
    Friend WithEvents txtCuenta0 As TextBox
    Friend WithEvents dtpFecha1 As DateTimePicker
    Friend WithEvents dtpFecha0 As DateTimePicker
    Friend WithEvents Frame1 As GroupBox
    Friend WithEvents chkTipoBloqueo3 As CheckBox
    Friend WithEvents chkTipoBloqueo4 As CheckBox
    Friend WithEvents chkTipoBloqueo1 As CheckBox
    Friend WithEvents chkTipoBloqueo2 As CheckBox
    Friend WithEvents chkTipoBloqueo0 As CheckBox
    Friend WithEvents dgvBloqueo As DataGridView
    Friend WithEvents cmdBuscar As Button
    Friend WithEvents cmdImprimir As Button
    Friend WithEvents cmdSalir As Button
    Friend WithEvents rbOpcReporte1 As RadioButton
    Friend WithEvents rbOpcReporte0 As RadioButton
    Friend WithEvents rbOrden1 As RadioButton
    Friend WithEvents rbOrden0 As RadioButton
End Class
