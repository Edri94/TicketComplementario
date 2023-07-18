<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsChqCta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsChqCta))
        Me.cmdBuscar = New System.Windows.Forms.Button()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.chkCuentas = New System.Windows.Forms.CheckBox()
        Me.chkFechas = New System.Windows.Forms.CheckBox()
        Me.monthCalendar = New System.Windows.Forms.MonthCalendar()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.chkStatus = New System.Windows.Forms.CheckBox()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbAgencias = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gpoFechas = New System.Windows.Forms.GroupBox()
        Me.txtFechaFin = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaIni = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gpoCuenta = New System.Windows.Forms.GroupBox()
        Me.txtCuentaFin = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCuentaIni = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpoFechas.SuspendLayout()
        Me.gpoCuenta.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBuscar.Location = New System.Drawing.Point(808, 49)
        Me.cmdBuscar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(112, 46)
        Me.cmdBuscar.TabIndex = 1
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'cmdImprimir
        '
        Me.cmdImprimir.Enabled = False
        Me.cmdImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdImprimir.Location = New System.Drawing.Point(808, 114)
        Me.cmdImprimir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(112, 46)
        Me.cmdImprimir.TabIndex = 2
        Me.cmdImprimir.Text = "Imprimir"
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'chkCuentas
        '
        Me.chkCuentas.AutoSize = True
        Me.chkCuentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCuentas.Location = New System.Drawing.Point(30, 34)
        Me.chkCuentas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkCuentas.Name = "chkCuentas"
        Me.chkCuentas.Size = New System.Drawing.Size(103, 26)
        Me.chkCuentas.TabIndex = 4
        Me.chkCuentas.Text = "Cuentas"
        Me.chkCuentas.UseVisualStyleBackColor = True
        '
        'chkFechas
        '
        Me.chkFechas.AutoSize = True
        Me.chkFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFechas.Location = New System.Drawing.Point(22, 46)
        Me.chkFechas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkFechas.Name = "chkFechas"
        Me.chkFechas.Size = New System.Drawing.Size(95, 26)
        Me.chkFechas.TabIndex = 5
        Me.chkFechas.Text = "Fechas"
        Me.chkFechas.UseVisualStyleBackColor = True
        '
        'monthCalendar
        '
        Me.monthCalendar.Location = New System.Drawing.Point(1137, 203)
        Me.monthCalendar.Margin = New System.Windows.Forms.Padding(14)
        Me.monthCalendar.MaxSelectionCount = 365
        Me.monthCalendar.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.monthCalendar.Name = "monthCalendar"
        Me.monthCalendar.TabIndex = 12
        Me.monthCalendar.Visible = False
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.AllowUserToDeleteRows = False
        Me.dgvDatos.AllowUserToOrderColumns = True
        Me.dgvDatos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatos.Location = New System.Drawing.Point(32, 249)
        Me.dgvDatos.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.ReadOnly = True
        Me.dgvDatos.RowHeadersWidth = 62
        Me.dgvDatos.Size = New System.Drawing.Size(939, 374)
        Me.dgvDatos.TabIndex = 15
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkStatus.Location = New System.Drawing.Point(368, 168)
        Me.chkStatus.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(87, 26)
        Me.chkStatus.TabIndex = 16
        Me.chkStatus.Text = "Status"
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'cmbStatus
        '
        Me.cmbStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(477, 165)
        Me.cmbStatus.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(180, 30)
        Me.cmbStatus.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(363, 46)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 22)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "hasta"
        '
        'cmbAgencias
        '
        Me.cmbAgencias.Enabled = False
        Me.cmbAgencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAgencias.FormattingEnabled = True
        Me.cmbAgencias.Location = New System.Drawing.Point(142, 165)
        Me.cmbAgencias.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbAgencias.Name = "cmbAgencias"
        Me.cmbAgencias.Size = New System.Drawing.Size(181, 30)
        Me.cmbAgencias.TabIndex = 20
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(27, 649)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(1055, 22)
        Me.lblStatus.TabIndex = 21
        Me.lblStatus.Text = resources.GetString("lblStatus.Text")
        '
        'cmdSalir
        '
        Me.cmdSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalir.Location = New System.Drawing.Point(808, 178)
        Me.cmdSalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(112, 46)
        Me.cmdSalir.TabIndex = 22
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(39, 171)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 22)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Agencia:"
        '
        'gpoFechas
        '
        Me.gpoFechas.Controls.Add(Me.txtFechaFin)
        Me.gpoFechas.Controls.Add(Me.txtFechaIni)
        Me.gpoFechas.Controls.Add(Me.Label4)
        Me.gpoFechas.Controls.Add(Me.Label2)
        Me.gpoFechas.Controls.Add(Me.chkFechas)
        Me.gpoFechas.Location = New System.Drawing.Point(54, 35)
        Me.gpoFechas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gpoFechas.Name = "gpoFechas"
        Me.gpoFechas.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gpoFechas.Size = New System.Drawing.Size(614, 98)
        Me.gpoFechas.TabIndex = 24
        Me.gpoFechas.TabStop = False
        Me.gpoFechas.Text = "Rango de fechas de solicitud"
        '
        'txtFechaFin
        '
        Me.txtFechaFin.Location = New System.Drawing.Point(440, 42)
        Me.txtFechaFin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFechaFin.Mask = "00/00/0000"
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.Size = New System.Drawing.Size(102, 26)
        Me.txtFechaFin.TabIndex = 27
        Me.txtFechaFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFechaFin.ValidatingType = GetType(Date)
        '
        'txtFechaIni
        '
        Me.txtFechaIni.Location = New System.Drawing.Point(224, 42)
        Me.txtFechaIni.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFechaIni.Mask = "00/00/0000"
        Me.txtFechaIni.Name = "txtFechaIni"
        Me.txtFechaIni.Size = New System.Drawing.Size(102, 26)
        Me.txtFechaIni.TabIndex = 26
        Me.txtFechaIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFechaIni.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(150, 46)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 22)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Desde"
        '
        'gpoCuenta
        '
        Me.gpoCuenta.Controls.Add(Me.txtCuentaFin)
        Me.gpoCuenta.Controls.Add(Me.Label5)
        Me.gpoCuenta.Controls.Add(Me.txtCuentaIni)
        Me.gpoCuenta.Controls.Add(Me.Label1)
        Me.gpoCuenta.Controls.Add(Me.chkCuentas)
        Me.gpoCuenta.Location = New System.Drawing.Point(57, 35)
        Me.gpoCuenta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gpoCuenta.Name = "gpoCuenta"
        Me.gpoCuenta.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gpoCuenta.Size = New System.Drawing.Size(610, 82)
        Me.gpoCuenta.TabIndex = 25
        Me.gpoCuenta.TabStop = False
        Me.gpoCuenta.Text = "Rango de cuentas"
        '
        'txtCuentaFin
        '
        Me.txtCuentaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuentaFin.Location = New System.Drawing.Point(468, 34)
        Me.txtCuentaFin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCuentaFin.Mask = "999999"
        Me.txtCuentaFin.Name = "txtCuentaFin"
        Me.txtCuentaFin.Size = New System.Drawing.Size(103, 28)
        Me.txtCuentaFin.TabIndex = 27
        Me.txtCuentaFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCuentaFin.ValidatingType = GetType(Integer)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(378, 37)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 22)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "hasta"
        '
        'txtCuentaIni
        '
        Me.txtCuentaIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuentaIni.Location = New System.Drawing.Point(236, 34)
        Me.txtCuentaIni.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCuentaIni.Mask = "999999"
        Me.txtCuentaIni.Name = "txtCuentaIni"
        Me.txtCuentaIni.Size = New System.Drawing.Size(103, 28)
        Me.txtCuentaIni.TabIndex = 26
        Me.txtCuentaIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCuentaIni.ValidatingType = GetType(Integer)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(146, 37)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 22)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Desde"
        '
        'frmConsChqCta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1006, 686)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.cmbAgencias)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.gpoFechas)
        Me.Controls.Add(Me.chkStatus)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.monthCalendar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.cmdBuscar)
        Me.Controls.Add(Me.gpoCuenta)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmConsChqCta"
        Me.Text = "Reporte"
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpoFechas.ResumeLayout(False)
        Me.gpoFechas.PerformLayout()
        Me.gpoCuenta.ResumeLayout(False)
        Me.gpoCuenta.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdBuscar As Button
    Friend WithEvents cmdImprimir As Button
    Friend WithEvents chkCuentas As CheckBox
    Friend WithEvents chkFechas As CheckBox
    Friend WithEvents monthCalendar As MonthCalendar
    Friend WithEvents dgvDatos As DataGridView
    Friend WithEvents chkStatus As CheckBox
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbAgencias As ComboBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents cmdSalir As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents gpoFechas As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents gpoCuenta As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFechaIni As MaskedTextBox
    Friend WithEvents txtFechaFin As MaskedTextBox
    Friend WithEvents txtCuentaIni As MaskedTextBox
    Friend WithEvents txtCuentaFin As MaskedTextBox
End Class
