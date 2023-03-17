<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMT202BBVA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMT202BBVA))
        Me.SSPanel2 = New System.Windows.Forms.GroupBox()
        Me.chkEnvioDef = New System.Windows.Forms.CheckBox()
        Me.cmdHistorico = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboAgencias = New System.Windows.Forms.ComboBox()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.pbProceso = New System.Windows.Forms.ProgressBar()
        Me.SSPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SSPanel2
        '
        Me.SSPanel2.Controls.Add(Me.chkEnvioDef)
        Me.SSPanel2.Controls.Add(Me.cmdHistorico)
        Me.SSPanel2.Controls.Add(Me.Label1)
        Me.SSPanel2.Controls.Add(Me.ComboAgencias)
        Me.SSPanel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSPanel2.Location = New System.Drawing.Point(12, 12)
        Me.SSPanel2.Name = "SSPanel2"
        Me.SSPanel2.Size = New System.Drawing.Size(378, 163)
        Me.SSPanel2.TabIndex = 0
        Me.SSPanel2.TabStop = False
        '
        'chkEnvioDef
        '
        Me.chkEnvioDef.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkEnvioDef.Location = New System.Drawing.Point(74, 92)
        Me.chkEnvioDef.Name = "chkEnvioDef"
        Me.chkEnvioDef.Size = New System.Drawing.Size(153, 49)
        Me.chkEnvioDef.TabIndex = 4
        Me.chkEnvioDef.Text = "Envío Definitivo"
        Me.chkEnvioDef.UseVisualStyleBackColor = True
        '
        'cmdHistorico
        '
        Me.cmdHistorico.Location = New System.Drawing.Point(233, 92)
        Me.cmdHistorico.Name = "cmdHistorico"
        Me.cmdHistorico.Size = New System.Drawing.Size(117, 49)
        Me.cmdHistorico.TabIndex = 3
        Me.cmdHistorico.Text = "&Histórico"
        Me.cmdHistorico.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 22)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Agencia:"
        '
        'ComboAgencias
        '
        Me.ComboAgencias.FormattingEnabled = True
        Me.ComboAgencias.Location = New System.Drawing.Point(93, 30)
        Me.ComboAgencias.Name = "ComboAgencias"
        Me.ComboAgencias.Size = New System.Drawing.Size(259, 30)
        Me.ComboAgencias.TabIndex = 0
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAceptar.Location = New System.Drawing.Point(176, 195)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(104, 35)
        Me.cmdAceptar.TabIndex = 1
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(286, 195)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(104, 35)
        Me.cmdCancelar.TabIndex = 2
        Me.cmdCancelar.Text = "&Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'pbProceso
        '
        Me.pbProceso.Location = New System.Drawing.Point(12, 195)
        Me.pbProceso.Name = "pbProceso"
        Me.pbProceso.Size = New System.Drawing.Size(261, 35)
        Me.pbProceso.TabIndex = 3
        Me.pbProceso.Visible = False
        '
        'frmMT202BBVA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(407, 242)
        Me.Controls.Add(Me.pbProceso)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.SSPanel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMT202BBVA"
        Me.Text = "Reporte MT202 BBVA"
        Me.SSPanel2.ResumeLayout(False)
        Me.SSPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SSPanel2 As GroupBox
    Friend WithEvents cmdHistorico As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboAgencias As ComboBox
    Friend WithEvents cmdAceptar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents chkEnvioDef As CheckBox
    Friend WithEvents pbProceso As ProgressBar
End Class
