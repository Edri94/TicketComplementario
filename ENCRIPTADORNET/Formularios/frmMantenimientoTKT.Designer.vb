<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantenimientoTKT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMantenimientoTKT))
        Me.txtTicket = New System.Windows.Forms.TextBox()
        Me.cmdBuscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFecha1 = New System.Windows.Forms.DateTimePicker()
        Me.fraOperaciones0 = New System.Windows.Forms.GroupBox()
        Me.msfgOperaciones0 = New System.Windows.Forms.DataGridView()
        Me.fraOperaciones1 = New System.Windows.Forms.GroupBox()
        Me.msfgOperaciones1 = New System.Windows.Forms.DataGridView()
        Me.fraOperaciones2 = New System.Windows.Forms.GroupBox()
        Me.msfgOperaciones2 = New System.Windows.Forms.DataGridView()
        Me.cmdAplicar = New System.Windows.Forms.Button()
        Me.cmdLimpiar = New System.Windows.Forms.Button()
        Me.cmdCierra = New System.Windows.Forms.Button()
        Me.fraOperaciones0.SuspendLayout()
        CType(Me.msfgOperaciones0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraOperaciones1.SuspendLayout()
        CType(Me.msfgOperaciones1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraOperaciones2.SuspendLayout()
        CType(Me.msfgOperaciones2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTicket
        '
        Me.txtTicket.Location = New System.Drawing.Point(12, 18)
        Me.txtTicket.Name = "txtTicket"
        Me.txtTicket.Size = New System.Drawing.Size(1265, 26)
        Me.txtTicket.TabIndex = 0
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Location = New System.Drawing.Point(1295, 12)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(95, 38)
        Me.cmdBuscar.TabIndex = 1
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(971, 22)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Notas: 1) Si es mas de un ticket favor de separarlos con coma "",""          2)Solo" &
    " se aceptan operaciones que no sean TD's"
        '
        'dtpFecha1
        '
        Me.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha1.Location = New System.Drawing.Point(1107, 50)
        Me.dtpFecha1.Name = "dtpFecha1"
        Me.dtpFecha1.Size = New System.Drawing.Size(145, 26)
        Me.dtpFecha1.TabIndex = 3
        Me.dtpFecha1.Visible = False
        '
        'fraOperaciones0
        '
        Me.fraOperaciones0.Controls.Add(Me.msfgOperaciones0)
        Me.fraOperaciones0.Location = New System.Drawing.Point(12, 91)
        Me.fraOperaciones0.Name = "fraOperaciones0"
        Me.fraOperaciones0.Size = New System.Drawing.Size(1378, 212)
        Me.fraOperaciones0.TabIndex = 4
        Me.fraOperaciones0.TabStop = False
        Me.fraOperaciones0.Text = "ACTUALES"
        '
        'msfgOperaciones0
        '
        Me.msfgOperaciones0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.msfgOperaciones0.Location = New System.Drawing.Point(17, 25)
        Me.msfgOperaciones0.Name = "msfgOperaciones0"
        Me.msfgOperaciones0.RowHeadersWidth = 62
        Me.msfgOperaciones0.RowTemplate.Height = 28
        Me.msfgOperaciones0.Size = New System.Drawing.Size(1338, 168)
        Me.msfgOperaciones0.TabIndex = 0
        '
        'fraOperaciones1
        '
        Me.fraOperaciones1.Controls.Add(Me.msfgOperaciones1)
        Me.fraOperaciones1.Location = New System.Drawing.Point(12, 309)
        Me.fraOperaciones1.Name = "fraOperaciones1"
        Me.fraOperaciones1.Size = New System.Drawing.Size(1378, 241)
        Me.fraOperaciones1.TabIndex = 5
        Me.fraOperaciones1.TabStop = False
        Me.fraOperaciones1.Text = "VISTA PRELIMINAR"
        '
        'msfgOperaciones1
        '
        Me.msfgOperaciones1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.msfgOperaciones1.Location = New System.Drawing.Point(17, 25)
        Me.msfgOperaciones1.Name = "msfgOperaciones1"
        Me.msfgOperaciones1.RowHeadersWidth = 62
        Me.msfgOperaciones1.RowTemplate.Height = 28
        Me.msfgOperaciones1.Size = New System.Drawing.Size(1338, 196)
        Me.msfgOperaciones1.TabIndex = 1
        '
        'fraOperaciones2
        '
        Me.fraOperaciones2.Controls.Add(Me.msfgOperaciones2)
        Me.fraOperaciones2.Location = New System.Drawing.Point(12, 556)
        Me.fraOperaciones2.Name = "fraOperaciones2"
        Me.fraOperaciones2.Size = New System.Drawing.Size(1378, 216)
        Me.fraOperaciones2.TabIndex = 5
        Me.fraOperaciones2.TabStop = False
        Me.fraOperaciones2.Text = "MODIFICADO"
        '
        'msfgOperaciones2
        '
        Me.msfgOperaciones2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.msfgOperaciones2.Location = New System.Drawing.Point(17, 34)
        Me.msfgOperaciones2.Name = "msfgOperaciones2"
        Me.msfgOperaciones2.RowHeadersWidth = 62
        Me.msfgOperaciones2.RowTemplate.Height = 28
        Me.msfgOperaciones2.Size = New System.Drawing.Size(1338, 167)
        Me.msfgOperaciones2.TabIndex = 2
        '
        'cmdAplicar
        '
        Me.cmdAplicar.Location = New System.Drawing.Point(1031, 778)
        Me.cmdAplicar.Name = "cmdAplicar"
        Me.cmdAplicar.Size = New System.Drawing.Size(94, 38)
        Me.cmdAplicar.TabIndex = 6
        Me.cmdAplicar.Text = "Aplicar"
        Me.cmdAplicar.UseVisualStyleBackColor = True
        '
        'cmdLimpiar
        '
        Me.cmdLimpiar.Location = New System.Drawing.Point(1152, 778)
        Me.cmdLimpiar.Name = "cmdLimpiar"
        Me.cmdLimpiar.Size = New System.Drawing.Size(94, 38)
        Me.cmdLimpiar.TabIndex = 7
        Me.cmdLimpiar.Text = "Limpiar"
        Me.cmdLimpiar.UseVisualStyleBackColor = True
        '
        'cmdCierra
        '
        Me.cmdCierra.Location = New System.Drawing.Point(1273, 778)
        Me.cmdCierra.Name = "cmdCierra"
        Me.cmdCierra.Size = New System.Drawing.Size(94, 38)
        Me.cmdCierra.TabIndex = 8
        Me.cmdCierra.Text = "Cerrar"
        Me.cmdCierra.UseVisualStyleBackColor = True
        '
        'frmMantenimientoTKT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1413, 828)
        Me.Controls.Add(Me.cmdCierra)
        Me.Controls.Add(Me.cmdLimpiar)
        Me.Controls.Add(Me.cmdAplicar)
        Me.Controls.Add(Me.fraOperaciones2)
        Me.Controls.Add(Me.fraOperaciones1)
        Me.Controls.Add(Me.fraOperaciones0)
        Me.Controls.Add(Me.dtpFecha1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdBuscar)
        Me.Controls.Add(Me.txtTicket)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMantenimientoTKT"
        Me.Text = "frmMantenimientoTKT"
        Me.fraOperaciones0.ResumeLayout(False)
        CType(Me.msfgOperaciones0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraOperaciones1.ResumeLayout(False)
        CType(Me.msfgOperaciones1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraOperaciones2.ResumeLayout(False)
        CType(Me.msfgOperaciones2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtTicket As TextBox
    Friend WithEvents cmdBuscar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFecha1 As DateTimePicker
    Friend WithEvents fraOperaciones0 As GroupBox
    Friend WithEvents msfgOperaciones0 As DataGridView
    Friend WithEvents fraOperaciones1 As GroupBox
    Friend WithEvents fraOperaciones2 As GroupBox
    Friend WithEvents cmdAplicar As Button
    Friend WithEvents cmdLimpiar As Button
    Friend WithEvents cmdCierra As Button
    Friend WithEvents msfgOperaciones1 As DataGridView
    Friend WithEvents msfgOperaciones2 As DataGridView
End Class
