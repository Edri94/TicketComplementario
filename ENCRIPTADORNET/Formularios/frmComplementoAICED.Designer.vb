<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComplementoAICED
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComplementoAICED))
        Me.cmbTipoFuente = New System.Windows.Forms.ComboBox()
        Me.cmbFuente = New System.Windows.Forms.ComboBox()
        Me.cmbPlaza = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdContinuar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPlaza = New System.Windows.Forms.TextBox()
        Me.cmbCentroRegional = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cmbTipoFuente
        '
        Me.cmbTipoFuente.FormattingEnabled = True
        Me.cmbTipoFuente.Location = New System.Drawing.Point(150, 56)
        Me.cmbTipoFuente.Name = "cmbTipoFuente"
        Me.cmbTipoFuente.Size = New System.Drawing.Size(314, 28)
        Me.cmbTipoFuente.TabIndex = 0
        '
        'cmbFuente
        '
        Me.cmbFuente.FormattingEnabled = True
        Me.cmbFuente.Location = New System.Drawing.Point(150, 100)
        Me.cmbFuente.Name = "cmbFuente"
        Me.cmbFuente.Size = New System.Drawing.Size(314, 28)
        Me.cmbFuente.TabIndex = 1
        '
        'cmbPlaza
        '
        Me.cmbPlaza.FormattingEnabled = True
        Me.cmbPlaza.Location = New System.Drawing.Point(150, 149)
        Me.cmbPlaza.Name = "cmbPlaza"
        Me.cmbPlaza.Size = New System.Drawing.Size(314, 28)
        Me.cmbPlaza.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tipo Fuente:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fuente:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 157)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Plaza:"
        '
        'cmdContinuar
        '
        Me.cmdContinuar.Location = New System.Drawing.Point(352, 199)
        Me.cmdContinuar.Name = "cmdContinuar"
        Me.cmdContinuar.Size = New System.Drawing.Size(103, 47)
        Me.cmdContinuar.TabIndex = 6
        Me.cmdContinuar.Text = "&Continuar"
        Me.cmdContinuar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Centro regional:"
        '
        'txtPlaza
        '
        Me.txtPlaza.Location = New System.Drawing.Point(150, 12)
        Me.txtPlaza.MaxLength = 3
        Me.txtPlaza.Name = "txtPlaza"
        Me.txtPlaza.Size = New System.Drawing.Size(63, 26)
        Me.txtPlaza.TabIndex = 8
        Me.txtPlaza.Text = "000"
        '
        'cmbCentroRegional
        '
        Me.cmbCentroRegional.FormattingEnabled = True
        Me.cmbCentroRegional.Location = New System.Drawing.Point(219, 12)
        Me.cmbCentroRegional.Name = "cmbCentroRegional"
        Me.cmbCentroRegional.Size = New System.Drawing.Size(245, 28)
        Me.cmbCentroRegional.TabIndex = 9
        '
        'frmComplementoAICED
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(485, 255)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbCentroRegional)
        Me.Controls.Add(Me.txtPlaza)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdContinuar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbPlaza)
        Me.Controls.Add(Me.cmbFuente)
        Me.Controls.Add(Me.cmbTipoFuente)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmComplementoAICED"
        Me.Text = "Complementos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbTipoFuente As ComboBox
    Friend WithEvents cmbFuente As ComboBox
    Friend WithEvents cmbPlaza As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmdContinuar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPlaza As TextBox
    Friend WithEvents cmbCentroRegional As ComboBox
End Class
