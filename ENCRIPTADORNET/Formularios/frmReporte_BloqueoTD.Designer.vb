<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporte_BloqueoTD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporte_BloqueoTD))
        Me.Frame3 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFechaFin = New System.Windows.Forms.TextBox()
        Me.txtFechaIni = New System.Windows.Forms.TextBox()
        Me.fraUsuario = New System.Windows.Forms.GroupBox()
        Me.optTodos = New System.Windows.Forms.CheckBox()
        Me.cmbNombre = New System.Windows.Forms.ComboBox()
        Me.optFecha = New System.Windows.Forms.CheckBox()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.pbStatus = New System.Windows.Forms.ProgressBar()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Frame3.SuspendLayout()
        Me.fraUsuario.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame3
        '
        Me.Frame3.Controls.Add(Me.optFecha)
        Me.Frame3.Controls.Add(Me.Label4)
        Me.Frame3.Controls.Add(Me.Label3)
        Me.Frame3.Controls.Add(Me.Label2)
        Me.Frame3.Controls.Add(Me.Label1)
        Me.Frame3.Controls.Add(Me.txtFechaFin)
        Me.Frame3.Controls.Add(Me.txtFechaIni)
        Me.Frame3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.Location = New System.Drawing.Point(13, 137)
        Me.Frame3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Frame3.Size = New System.Drawing.Size(751, 139)
        Me.Frame3.TabIndex = 3
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Fecha de Bloqueo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(309, 88)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 24)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "(yyyy-mm-dd)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(309, 46)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 24)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "(yyyy-mm-dd)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(92, 91)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Final"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(88, 46)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Inicial"
        '
        'txtFechaFin
        '
        Me.txtFechaFin.Location = New System.Drawing.Point(153, 88)
        Me.txtFechaFin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.Size = New System.Drawing.Size(148, 29)
        Me.txtFechaFin.TabIndex = 1
        '
        'txtFechaIni
        '
        Me.txtFechaIni.Location = New System.Drawing.Point(153, 43)
        Me.txtFechaIni.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFechaIni.Name = "txtFechaIni"
        Me.txtFechaIni.Size = New System.Drawing.Size(148, 29)
        Me.txtFechaIni.TabIndex = 0
        '
        'fraUsuario
        '
        Me.fraUsuario.Controls.Add(Me.optTodos)
        Me.fraUsuario.Controls.Add(Me.cmbNombre)
        Me.fraUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraUsuario.Location = New System.Drawing.Point(13, 18)
        Me.fraUsuario.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraUsuario.Name = "fraUsuario"
        Me.fraUsuario.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraUsuario.Size = New System.Drawing.Size(751, 95)
        Me.fraUsuario.TabIndex = 2
        Me.fraUsuario.TabStop = False
        Me.fraUsuario.Text = "Usuario"
        '
        'optTodos
        '
        Me.optTodos.Appearance = System.Windows.Forms.Appearance.Button
        Me.optTodos.BackColor = System.Drawing.Color.Gainsboro
        Me.optTodos.Location = New System.Drawing.Point(589, 20)
        Me.optTodos.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optTodos.Name = "optTodos"
        Me.optTodos.Size = New System.Drawing.Size(150, 54)
        Me.optTodos.TabIndex = 2
        Me.optTodos.Text = "Todos"
        Me.optTodos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optTodos.UseVisualStyleBackColor = False
        '
        'cmbNombre
        '
        Me.cmbNombre.FormattingEnabled = True
        Me.cmbNombre.Location = New System.Drawing.Point(9, 32)
        Me.cmbNombre.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbNombre.Name = "cmbNombre"
        Me.cmbNombre.Size = New System.Drawing.Size(572, 32)
        Me.cmbNombre.TabIndex = 0
        '
        'optFecha
        '
        Me.optFecha.Appearance = System.Windows.Forms.Appearance.Button
        Me.optFecha.BackColor = System.Drawing.Color.Gainsboro
        Me.optFecha.Location = New System.Drawing.Point(481, 43)
        Me.optFecha.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optFecha.Name = "optFecha"
        Me.optFecha.Size = New System.Drawing.Size(171, 69)
        Me.optFecha.TabIndex = 6
        Me.optFecha.Text = "Cualquier Fecha"
        Me.optFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optFecha.UseVisualStyleBackColor = False
        '
        'cmdImprimir
        '
        Me.cmdImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdImprimir.Location = New System.Drawing.Point(518, 376)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(120, 51)
        Me.cmdImprimir.TabIndex = 4
        Me.cmdImprimir.Text = "Imprimir"
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(644, 376)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(120, 51)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Salir"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'pbStatus
        '
        Me.pbStatus.Location = New System.Drawing.Point(13, 319)
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(751, 37)
        Me.pbStatus.TabIndex = 6
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(13, 294)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(25, 22)
        Me.lblStatus.TabIndex = 7
        Me.lblStatus.Text = "   "
        '
        'frmReporte_BloqueoTD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(784, 450)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.pbStatus)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.fraUsuario)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReporte_BloqueoTD"
        Me.Text = "Reporte de bloqueos por usuario"
        Me.Frame3.ResumeLayout(False)
        Me.Frame3.PerformLayout()
        Me.fraUsuario.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Frame3 As GroupBox
    Friend WithEvents optFecha As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFechaFin As TextBox
    Friend WithEvents txtFechaIni As TextBox
    Friend WithEvents fraUsuario As GroupBox
    Friend WithEvents optTodos As CheckBox
    Friend WithEvents cmbNombre As ComboBox
    Friend WithEvents cmdImprimir As Button
    Friend WithEvents cmdCancel As Button
    Friend WithEvents pbStatus As ProgressBar
    Friend WithEvents lblStatus As Label
End Class
