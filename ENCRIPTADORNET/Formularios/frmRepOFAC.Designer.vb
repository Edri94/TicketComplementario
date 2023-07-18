<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepOFAC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepOFAC))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lstAgencia = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optTodas = New System.Windows.Forms.CheckBox()
        Me.optFecha = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btExaminar = New System.Windows.Forms.Button()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.pnlFecha = New System.Windows.Forms.GroupBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.fbdExploradorCarpetas = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.pnlFecha.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstAgencia)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox2.Size = New System.Drawing.Size(257, 147)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Agencia"
        '
        'lstAgencia
        '
        Me.lstAgencia.FormattingEnabled = True
        Me.lstAgencia.ItemHeight = 21
        Me.lstAgencia.Location = New System.Drawing.Point(8, 27)
        Me.lstAgencia.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.lstAgencia.Name = "lstAgencia"
        Me.lstAgencia.Size = New System.Drawing.Size(241, 109)
        Me.lstAgencia.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optTodas)
        Me.GroupBox1.Controls.Add(Me.optFecha)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(293, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(317, 137)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de Reporte"
        '
        'optTodas
        '
        Me.optTodas.Appearance = System.Windows.Forms.Appearance.Button
        Me.optTodas.Location = New System.Drawing.Point(9, 76)
        Me.optTodas.Name = "optTodas"
        Me.optTodas.Size = New System.Drawing.Size(294, 32)
        Me.optTodas.TabIndex = 11
        Me.optTodas.Text = "Todas"
        Me.optTodas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optTodas.UseVisualStyleBackColor = True
        '
        'optFecha
        '
        Me.optFecha.Appearance = System.Windows.Forms.Appearance.Button
        Me.optFecha.Location = New System.Drawing.Point(9, 38)
        Me.optFecha.Name = "optFecha"
        Me.optFecha.Size = New System.Drawing.Size(294, 32)
        Me.optFecha.TabIndex = 10
        Me.optFecha.Text = "Por fecha de alta de cuenta"
        Me.optFecha.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox3.Controls.Add(Me.btExaminar)
        Me.GroupBox3.Controls.Add(Me.txtRuta)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(13, 168)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Size = New System.Drawing.Size(597, 82)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ruta del archivo"
        '
        'btExaminar
        '
        Me.btExaminar.Location = New System.Drawing.Point(471, 24)
        Me.btExaminar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btExaminar.Name = "btExaminar"
        Me.btExaminar.Size = New System.Drawing.Size(112, 40)
        Me.btExaminar.TabIndex = 1
        Me.btExaminar.Text = "Examinar…"
        Me.btExaminar.UseVisualStyleBackColor = True
        '
        'txtRuta
        '
        Me.txtRuta.Location = New System.Drawing.Point(9, 30)
        Me.txtRuta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.Size = New System.Drawing.Size(452, 28)
        Me.txtRuta.TabIndex = 0
        '
        'pnlFecha
        '
        Me.pnlFecha.Controls.Add(Me.dtpFechaFin)
        Me.pnlFecha.Controls.Add(Me.dtpFechaIni)
        Me.pnlFecha.Controls.Add(Me.Label2)
        Me.pnlFecha.Controls.Add(Me.Label1)
        Me.pnlFecha.Enabled = False
        Me.pnlFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlFecha.Location = New System.Drawing.Point(13, 261)
        Me.pnlFecha.Name = "pnlFecha"
        Me.pnlFecha.Size = New System.Drawing.Size(597, 111)
        Me.pnlFecha.TabIndex = 7
        Me.pnlFecha.TabStop = False
        Me.pnlFecha.Text = "Rango de fechas"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = "dd-MM-yyyy"
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFin.Location = New System.Drawing.Point(269, 69)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(167, 28)
        Me.dtpFechaFin.TabIndex = 3
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.CustomFormat = "dd-MM-yyyy"
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaIni.Location = New System.Drawing.Point(269, 27)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(167, 28)
        Me.dtpFechaIni.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(145, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fecha fin:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(145, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha inicio:"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdImprimir.Location = New System.Drawing.Point(384, 386)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(111, 45)
        Me.cmdImprimir.TabIndex = 8
        Me.cmdImprimir.Text = "&Imprimir"
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalir.Location = New System.Drawing.Point(510, 386)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(100, 45)
        Me.cmdSalir.TabIndex = 9
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'frmRepOFAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(622, 450)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.pnlFecha)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRepOFAC"
        Me.Text = "Reporte OFAC"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.pnlFecha.ResumeLayout(False)
        Me.pnlFecha.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lstAgencia As ListBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btExaminar As Button
    Friend WithEvents txtRuta As TextBox
    Friend WithEvents pnlFecha As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFechaIni As DateTimePicker
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents cmdImprimir As Button
    Friend WithEvents cmdSalir As Button
    Friend WithEvents fbdExploradorCarpetas As FolderBrowserDialog
    Friend WithEvents optTodas As CheckBox
    Friend WithEvents optFecha As CheckBox
End Class
