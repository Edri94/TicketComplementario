<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReimpRepMT198
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReimpRepMT198))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAgencias = New System.Windows.Forms.ComboBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.grdOperaciones = New System.Windows.Forms.DataGridView()
        Me.lblTotalOperaciones = New System.Windows.Forms.Label()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.pbGenArch = New System.Windows.Forms.ProgressBar()
        Me.lbGenArch = New System.Windows.Forms.Label()
        CType(Me.grdOperaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Agencia:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fecha:"
        '
        'cboAgencias
        '
        Me.cboAgencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAgencias.FormattingEnabled = True
        Me.cboAgencias.Location = New System.Drawing.Point(109, 14)
        Me.cboAgencias.Name = "cboAgencias"
        Me.cboAgencias.Size = New System.Drawing.Size(223, 30)
        Me.cboAgencias.TabIndex = 2
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "dd-MM-yyyy"
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(109, 62)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(151, 28)
        Me.dtpFecha.TabIndex = 3
        '
        'grdOperaciones
        '
        Me.grdOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdOperaciones.Location = New System.Drawing.Point(12, 96)
        Me.grdOperaciones.Name = "grdOperaciones"
        Me.grdOperaciones.RowHeadersWidth = 62
        Me.grdOperaciones.RowTemplate.Height = 28
        Me.grdOperaciones.Size = New System.Drawing.Size(1068, 305)
        Me.grdOperaciones.TabIndex = 4
        '
        'lblTotalOperaciones
        '
        Me.lblTotalOperaciones.AutoSize = True
        Me.lblTotalOperaciones.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTotalOperaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalOperaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalOperaciones.ForeColor = System.Drawing.SystemColors.Window
        Me.lblTotalOperaciones.Location = New System.Drawing.Point(8, 418)
        Me.lblTotalOperaciones.Name = "lblTotalOperaciones"
        Me.lblTotalOperaciones.Size = New System.Drawing.Size(317, 24)
        Me.lblTotalOperaciones.TabIndex = 5
        Me.lblTotalOperaciones.Text = "Número de operaciones encontradas: "
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAceptar.Location = New System.Drawing.Point(690, 407)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(136, 35)
        Me.cmdAceptar.TabIndex = 6
        Me.cmdAceptar.Text = "&Generar Excel"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdImprimir
        '
        Me.cmdImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdImprimir.Location = New System.Drawing.Point(867, 407)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(97, 35)
        Me.cmdImprimir.TabIndex = 7
        Me.cmdImprimir.Text = "&Imprimir"
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(1005, 407)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 35)
        Me.cmdCancelar.TabIndex = 8
        Me.cmdCancelar.Text = "&Salir"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'pbGenArch
        '
        Me.pbGenArch.Location = New System.Drawing.Point(218, 407)
        Me.pbGenArch.Name = "pbGenArch"
        Me.pbGenArch.Size = New System.Drawing.Size(430, 35)
        Me.pbGenArch.TabIndex = 9
        Me.pbGenArch.Visible = False
        '
        'lbGenArch
        '
        Me.lbGenArch.AutoSize = True
        Me.lbGenArch.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbGenArch.Location = New System.Drawing.Point(8, 414)
        Me.lbGenArch.Name = "lbGenArch"
        Me.lbGenArch.Size = New System.Drawing.Size(204, 21)
        Me.lbGenArch.TabIndex = 10
        Me.lbGenArch.Text = "Generando Archivos..."
        Me.lbGenArch.Visible = False
        '
        'frmReimpRepMT198
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1092, 452)
        Me.Controls.Add(Me.lbGenArch)
        Me.Controls.Add(Me.pbGenArch)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.lblTotalOperaciones)
        Me.Controls.Add(Me.grdOperaciones)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.cboAgencias)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReimpRepMT198"
        Me.Text = "Reimpresión MT198"
        CType(Me.grdOperaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboAgencias As ComboBox
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents grdOperaciones As DataGridView
    Friend WithEvents lblTotalOperaciones As Label
    Friend WithEvents cmdAceptar As Button
    Friend WithEvents cmdImprimir As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents pbGenArch As ProgressBar
    Friend WithEvents lbGenArch As Label
End Class
