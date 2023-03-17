<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepAperturas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CrystalRV_Aperturas = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.btn_Salir = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CrystalRV_Aperturas
        '
        Me.CrystalRV_Aperturas.ActiveViewIndex = -1
        Me.CrystalRV_Aperturas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalRV_Aperturas.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalRV_Aperturas.Location = New System.Drawing.Point(12, 12)
        Me.CrystalRV_Aperturas.Name = "CrystalRV_Aperturas"
        Me.CrystalRV_Aperturas.Size = New System.Drawing.Size(1199, 577)
        Me.CrystalRV_Aperturas.TabIndex = 0
        Me.CrystalRV_Aperturas.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'btn_Salir
        '
        Me.btn_Salir.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btn_Salir.Location = New System.Drawing.Point(1103, 604)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(108, 37)
        Me.btn_Salir.TabIndex = 1
        Me.btn_Salir.Text = "Salir"
        Me.btn_Salir.UseVisualStyleBackColor = False
        '
        'RepAperturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1220, 653)
        Me.Controls.Add(Me.btn_Salir)
        Me.Controls.Add(Me.CrystalRV_Aperturas)
        Me.Name = "RepAperturas"
        Me.Text = "Reporte Aperturas de Cuentas"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CrystalRV_Aperturas As CrystalReportViewer
    Friend WithEvents btn_Salir As Button
End Class
