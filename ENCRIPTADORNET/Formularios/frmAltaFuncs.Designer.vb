<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAltaFuncs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAltaFuncs))
        Me.btExaminar = New System.Windows.Forms.Button()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btRegistro = New System.Windows.Forms.Button()
        Me.btCerrar = New System.Windows.Forms.Button()
        Me.pbRegistro = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'btExaminar
        '
        Me.btExaminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btExaminar.Location = New System.Drawing.Point(419, 42)
        Me.btExaminar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btExaminar.Name = "btExaminar"
        Me.btExaminar.Size = New System.Drawing.Size(120, 40)
        Me.btExaminar.TabIndex = 3
        Me.btExaminar.Text = "Examinar…"
        Me.btExaminar.UseVisualStyleBackColor = True
        '
        'txtRuta
        '
        Me.txtRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRuta.Location = New System.Drawing.Point(20, 49)
        Me.txtRuta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.Size = New System.Drawing.Size(388, 28)
        Me.txtRuta.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(490, 22)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Selecciona el archivo que contiene la información a registrar"
        '
        'btRegistro
        '
        Me.btRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btRegistro.Location = New System.Drawing.Point(49, 104)
        Me.btRegistro.Name = "btRegistro"
        Me.btRegistro.Size = New System.Drawing.Size(150, 38)
        Me.btRegistro.TabIndex = 5
        Me.btRegistro.Text = "Iniciar registro"
        Me.btRegistro.UseVisualStyleBackColor = True
        '
        'btCerrar
        '
        Me.btCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCerrar.Location = New System.Drawing.Point(296, 104)
        Me.btCerrar.Name = "btCerrar"
        Me.btCerrar.Size = New System.Drawing.Size(112, 40)
        Me.btCerrar.TabIndex = 6
        Me.btCerrar.Text = "Cerrar"
        Me.btCerrar.UseVisualStyleBackColor = True
        '
        'pbRegistro
        '
        Me.pbRegistro.Location = New System.Drawing.Point(20, 162)
        Me.pbRegistro.Name = "pbRegistro"
        Me.pbRegistro.Size = New System.Drawing.Size(519, 31)
        Me.pbRegistro.TabIndex = 7
        Me.pbRegistro.Visible = False
        '
        'frmAltaFuncs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(565, 202)
        Me.Controls.Add(Me.pbRegistro)
        Me.Controls.Add(Me.btCerrar)
        Me.Controls.Add(Me.btRegistro)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btExaminar)
        Me.Controls.Add(Me.txtRuta)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAltaFuncs"
        Me.Text = "Alta de Gestores"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btExaminar As Button
    Friend WithEvents txtRuta As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btRegistro As Button
    Friend WithEvents btCerrar As Button
    Friend WithEvents pbRegistro As ProgressBar
End Class
