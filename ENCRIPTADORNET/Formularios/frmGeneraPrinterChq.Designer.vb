<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGeneraPrinterChq
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGeneraPrinterChq))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grbSolicitudes = New System.Windows.Forms.GroupBox()
        Me.txtPorEnviar = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.grbFechas = New System.Windows.Forms.GroupBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.chkReimpresion = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btExaminar = New System.Windows.Forms.Button()
        Me.txtRutaHD = New System.Windows.Forms.TextBox()
        Me.lblSolicitudes = New System.Windows.Forms.Label()
        Me.pbrSolicitudes = New System.Windows.Forms.ProgressBar()
        Me.fbdExplorarCarpetas = New System.Windows.Forms.FolderBrowserDialog()
        Me.btPrint = New System.Windows.Forms.Button()
        Me.btGenerar = New System.Windows.Forms.Button()
        Me.btSalir = New System.Windows.Forms.Button()
        Me.grbSolicitudes.SuspendLayout()
        Me.grbFechas.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 37)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(188, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha de Generación:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 77)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(222, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "N° Solicitudes Pendientes:"
        '
        'grbSolicitudes
        '
        Me.grbSolicitudes.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.grbSolicitudes.Controls.Add(Me.txtPorEnviar)
        Me.grbSolicitudes.Controls.Add(Me.txtFecha)
        Me.grbSolicitudes.Controls.Add(Me.Label1)
        Me.grbSolicitudes.Controls.Add(Me.Label2)
        Me.grbSolicitudes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbSolicitudes.Location = New System.Drawing.Point(18, 18)
        Me.grbSolicitudes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grbSolicitudes.Name = "grbSolicitudes"
        Me.grbSolicitudes.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grbSolicitudes.Size = New System.Drawing.Size(530, 126)
        Me.grbSolicitudes.TabIndex = 4
        Me.grbSolicitudes.TabStop = False
        Me.grbSolicitudes.Text = "Solicitudes"
        '
        'txtPorEnviar
        '
        Me.txtPorEnviar.Enabled = False
        Me.txtPorEnviar.Location = New System.Drawing.Point(246, 74)
        Me.txtPorEnviar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPorEnviar.Name = "txtPorEnviar"
        Me.txtPorEnviar.Size = New System.Drawing.Size(270, 28)
        Me.txtPorEnviar.TabIndex = 9
        '
        'txtFecha
        '
        Me.txtFecha.Enabled = False
        Me.txtFecha.Location = New System.Drawing.Point(246, 32)
        Me.txtFecha.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(270, 28)
        Me.txtFecha.TabIndex = 8
        '
        'grbFechas
        '
        Me.grbFechas.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.grbFechas.Controls.Add(Me.dtpFechaFin)
        Me.grbFechas.Controls.Add(Me.dtpFechaIni)
        Me.grbFechas.Controls.Add(Me.chkReimpresion)
        Me.grbFechas.Controls.Add(Me.Label3)
        Me.grbFechas.Controls.Add(Me.Label5)
        Me.grbFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbFechas.Location = New System.Drawing.Point(18, 169)
        Me.grbFechas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grbFechas.Name = "grbFechas"
        Me.grbFechas.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grbFechas.Size = New System.Drawing.Size(530, 126)
        Me.grbFechas.TabIndex = 5
        Me.grbFechas.TabStop = False
        Me.grbFechas.Text = "Reimpresión"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = "dd-MM-yyyy"
        Me.dtpFechaFin.Enabled = False
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFin.Location = New System.Drawing.Point(372, 58)
        Me.dtpFechaFin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(151, 28)
        Me.dtpFechaFin.TabIndex = 11
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.CustomFormat = "dd-MM-yyyy"
        Me.dtpFechaIni.Enabled = False
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaIni.Location = New System.Drawing.Point(158, 58)
        Me.dtpFechaIni.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(163, 28)
        Me.dtpFechaIni.TabIndex = 9
        '
        'chkReimpresion
        '
        Me.chkReimpresion.AutoSize = True
        Me.chkReimpresion.Location = New System.Drawing.Point(14, 29)
        Me.chkReimpresion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkReimpresion.Name = "chkReimpresion"
        Me.chkReimpresion.Size = New System.Drawing.Size(136, 26)
        Me.chkReimpresion.TabIndex = 6
        Me.chkReimpresion.Text = "Reimpresión"
        Me.chkReimpresion.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 65)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(147, 22)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Envios con fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(319, 66)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 22)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "hasta"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox2.Controls.Add(Me.btExaminar)
        Me.GroupBox2.Controls.Add(Me.txtRutaHD)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(18, 320)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(530, 126)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ruta de Generación en Disco"
        '
        'btExaminar
        '
        Me.btExaminar.Location = New System.Drawing.Point(408, 45)
        Me.btExaminar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btExaminar.Name = "btExaminar"
        Me.btExaminar.Size = New System.Drawing.Size(112, 40)
        Me.btExaminar.TabIndex = 1
        Me.btExaminar.Text = "Examinar…"
        Me.btExaminar.UseVisualStyleBackColor = True
        '
        'txtRutaHD
        '
        Me.txtRutaHD.Location = New System.Drawing.Point(9, 49)
        Me.txtRutaHD.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtRutaHD.Name = "txtRutaHD"
        Me.txtRutaHD.Size = New System.Drawing.Size(388, 28)
        Me.txtRutaHD.TabIndex = 0
        '
        'lblSolicitudes
        '
        Me.lblSolicitudes.AutoSize = True
        Me.lblSolicitudes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSolicitudes.Location = New System.Drawing.Point(27, 555)
        Me.lblSolicitudes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSolicitudes.Name = "lblSolicitudes"
        Me.lblSolicitudes.Size = New System.Drawing.Size(251, 22)
        Me.lblSolicitudes.TabIndex = 6
        Me.lblSolicitudes.Text = "Registrando 0 solicitudes de 0"
        '
        'pbrSolicitudes
        '
        Me.pbrSolicitudes.Location = New System.Drawing.Point(18, 586)
        Me.pbrSolicitudes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pbrSolicitudes.Name = "pbrSolicitudes"
        Me.pbrSolicitudes.Size = New System.Drawing.Size(530, 35)
        Me.pbrSolicitudes.TabIndex = 7
        '
        'fbdExplorarCarpetas
        '
        Me.fbdExplorarCarpetas.ShowNewFolderButton = False
        '
        'btPrint
        '
        Me.btPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btPrint.Location = New System.Drawing.Point(63, 477)
        Me.btPrint.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btPrint.Name = "btPrint"
        Me.btPrint.Size = New System.Drawing.Size(112, 46)
        Me.btPrint.TabIndex = 8
        Me.btPrint.Text = "&Imprimir"
        Me.btPrint.UseVisualStyleBackColor = True
        Me.btPrint.Visible = False
        '
        'btGenerar
        '
        Me.btGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGenerar.Location = New System.Drawing.Point(206, 477)
        Me.btGenerar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btGenerar.Name = "btGenerar"
        Me.btGenerar.Size = New System.Drawing.Size(112, 46)
        Me.btGenerar.TabIndex = 9
        Me.btGenerar.Text = "&Generar"
        Me.btGenerar.UseVisualStyleBackColor = True
        '
        'btSalir
        '
        Me.btSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSalir.Location = New System.Drawing.Point(344, 477)
        Me.btSalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btSalir.Name = "btSalir"
        Me.btSalir.Size = New System.Drawing.Size(112, 46)
        Me.btSalir.TabIndex = 10
        Me.btSalir.Text = "&Salir"
        Me.btSalir.UseVisualStyleBackColor = True
        '
        'frmGeneraPrinterChq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(568, 640)
        Me.Controls.Add(Me.btSalir)
        Me.Controls.Add(Me.btGenerar)
        Me.Controls.Add(Me.btPrint)
        Me.Controls.Add(Me.pbrSolicitudes)
        Me.Controls.Add(Me.lblSolicitudes)
        Me.Controls.Add(Me.grbFechas)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grbSolicitudes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmGeneraPrinterChq"
        Me.Text = "Generación de Archivo de Chequeras"
        Me.grbSolicitudes.ResumeLayout(False)
        Me.grbSolicitudes.PerformLayout()
        Me.grbFechas.ResumeLayout(False)
        Me.grbFechas.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents grbSolicitudes As GroupBox
    Friend WithEvents grbFechas As GroupBox
    Friend WithEvents chkReimpresion As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtPorEnviar As TextBox
    Friend WithEvents txtFecha As TextBox
    Friend WithEvents txtRutaHD As TextBox
    Friend WithEvents lblSolicitudes As Label
    Friend WithEvents pbrSolicitudes As ProgressBar
    Friend WithEvents btExaminar As Button
    Friend WithEvents fbdExplorarCarpetas As FolderBrowserDialog
    Friend WithEvents btPrint As Button
    Friend WithEvents btGenerar As Button
    Friend WithEvents btSalir As Button
    Friend WithEvents dtpFechaIni As DateTimePicker
    Friend WithEvents dtpFechaFin As DateTimePicker
End Class
