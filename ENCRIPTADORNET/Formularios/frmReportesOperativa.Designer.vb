<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepOperativa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RepOperativa))
        Me.crvRepOper = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'crvRepOper
        '
        Me.crvRepOper.ActiveViewIndex = -1
        Me.crvRepOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvRepOper.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvRepOper.Location = New System.Drawing.Point(18, 18)
        Me.crvRepOper.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.crvRepOper.Name = "crvRepOper"
        Me.crvRepOper.Size = New System.Drawing.Size(1758, 862)
        Me.crvRepOper.TabIndex = 0
        Me.crvRepOper.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(1594, 891)
        Me.cmdSalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(183, 55)
        Me.cmdSalir.TabIndex = 1
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'RepOperativa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1796, 965)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.crvRepOper)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "RepOperativa"
        Me.Text = "Reportes Operativa"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents crvRepOper As CrystalReportViewer
    Friend WithEvents cmdSalir As Button
End Class
