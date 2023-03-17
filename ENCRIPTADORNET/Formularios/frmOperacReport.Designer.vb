<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOperacReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOperacReport))
        Me.lstAgencia = New System.Windows.Forms.ListBox()
        Me.SSPSBF = New System.Windows.Forms.GroupBox()
        Me.rbtPC = New System.Windows.Forms.RadioButton()
        Me.rbtFOH = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.dgvOperac = New System.Windows.Forms.DataGridView()
        Me.pgbCarga = New System.Windows.Forms.ProgressBar()
        Me.lbGenArch = New System.Windows.Forms.Label()
        Me.SSPSBF.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvOperac, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstAgencia
        '
        Me.lstAgencia.FormattingEnabled = True
        Me.lstAgencia.ItemHeight = 21
        Me.lstAgencia.Location = New System.Drawing.Point(8, 27)
        Me.lstAgencia.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.lstAgencia.Name = "lstAgencia"
        Me.lstAgencia.Size = New System.Drawing.Size(241, 67)
        Me.lstAgencia.TabIndex = 0
        '
        'SSPSBF
        '
        Me.SSPSBF.Controls.Add(Me.rbtPC)
        Me.SSPSBF.Controls.Add(Me.rbtFOH)
        Me.SSPSBF.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSPSBF.Location = New System.Drawing.Point(280, 13)
        Me.SSPSBF.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SSPSBF.Name = "SSPSBF"
        Me.SSPSBF.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SSPSBF.Size = New System.Drawing.Size(260, 110)
        Me.SSPSBF.TabIndex = 2
        Me.SSPSBF.TabStop = False
        Me.SSPSBF.Text = "Seleccione la opción deseada"
        Me.SSPSBF.Visible = False
        '
        'rbtPC
        '
        Me.rbtPC.AutoSize = True
        Me.rbtPC.Location = New System.Drawing.Point(14, 68)
        Me.rbtPC.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rbtPC.Name = "rbtPC"
        Me.rbtPC.Size = New System.Drawing.Size(257, 25)
        Me.rbtPC.TabIndex = 1
        Me.rbtPC.TabStop = True
        Me.rbtPC.Text = "Pendientes por confirmar"
        Me.rbtPC.UseVisualStyleBackColor = True
        '
        'rbtFOH
        '
        Me.rbtFOH.AutoSize = True
        Me.rbtFOH.Location = New System.Drawing.Point(14, 34)
        Me.rbtFOH.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rbtFOH.Name = "rbtFOH"
        Me.rbtFOH.Size = New System.Drawing.Size(245, 25)
        Me.rbtFOH.TabIndex = 0
        Me.rbtFOH.TabStop = True
        Me.rbtFOH.Text = "Fecha operación de hoy"
        Me.rbtFOH.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstAgencia)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(15, 13)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox2.Size = New System.Drawing.Size(257, 110)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Agencia"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(87, 136)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(453, 21)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Seleccione la(s) operacion(es) que desea imprimir."
        '
        'cmdImprimir
        '
        Me.cmdImprimir.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdImprimir.Location = New System.Drawing.Point(328, 413)
        Me.cmdImprimir.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(92, 38)
        Me.cmdImprimir.TabIndex = 6
        Me.cmdImprimir.Text = "&Imprimir"
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(447, 411)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(92, 40)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "&Salir"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'dgvOperac
        '
        Me.dgvOperac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOperac.Location = New System.Drawing.Point(12, 160)
        Me.dgvOperac.Name = "dgvOperac"
        Me.dgvOperac.RowHeadersWidth = 62
        Me.dgvOperac.RowTemplate.Height = 28
        Me.dgvOperac.Size = New System.Drawing.Size(527, 245)
        Me.dgvOperac.TabIndex = 8
        '
        'pgbCarga
        '
        Me.pgbCarga.Location = New System.Drawing.Point(212, 422)
        Me.pgbCarga.Name = "pgbCarga"
        Me.pgbCarga.Size = New System.Drawing.Size(327, 38)
        Me.pgbCarga.TabIndex = 9
        Me.pgbCarga.Visible = False
        '
        'lbGenArch
        '
        Me.lbGenArch.AutoSize = True
        Me.lbGenArch.Location = New System.Drawing.Point(14, 430)
        Me.lbGenArch.Name = "lbGenArch"
        Me.lbGenArch.Size = New System.Drawing.Size(192, 21)
        Me.lbGenArch.TabIndex = 10
        Me.lbGenArch.Text = "Generando archivo..."
        Me.lbGenArch.Visible = False
        '
        'frmOperacReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(556, 467)
        Me.Controls.Add(Me.lbGenArch)
        Me.Controls.Add(Me.pgbCarga)
        Me.Controls.Add(Me.dgvOperac)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.SSPSBF)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "frmOperacReport"
        Me.Text = "Operaciones del Día"
        Me.SSPSBF.ResumeLayout(False)
        Me.SSPSBF.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvOperac, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstAgencia As ListBox
    Friend WithEvents SSPSBF As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbtPC As RadioButton
    Friend WithEvents rbtFOH As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdImprimir As Button
    Friend WithEvents cmdCancel As Button
    Friend WithEvents dgvOperac As DataGridView
    Friend WithEvents pgbCarga As ProgressBar
    Friend WithEvents lbGenArch As Label
End Class
