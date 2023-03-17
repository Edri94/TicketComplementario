<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Desencripta = New System.Windows.Forms.Button()
        Me.Encripta = New System.Windows.Forms.Button()
        Me.txtTexto = New System.Windows.Forms.TextBox()
        Me.EtiquetaRes = New System.Windows.Forms.Label()
        Me.lbResultado = New System.Windows.Forms.Label()
        Me.txtResutado = New System.Windows.Forms.TextBox()
        Me.btConexionbd = New System.Windows.Forms.Button()
        Me.lbError = New System.Windows.Forms.Label()
        Me.gvDatos = New System.Windows.Forms.DataGridView()
        CType(Me.gvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Desencripta
        '
        Me.Desencripta.Location = New System.Drawing.Point(26, 60)
        Me.Desencripta.Name = "Desencripta"
        Me.Desencripta.Size = New System.Drawing.Size(233, 32)
        Me.Desencripta.TabIndex = 2
        Me.Desencripta.Text = "Desencriptador"
        Me.Desencripta.UseVisualStyleBackColor = True
        '
        'Encripta
        '
        Me.Encripta.Location = New System.Drawing.Point(26, 110)
        Me.Encripta.Name = "Encripta"
        Me.Encripta.Size = New System.Drawing.Size(232, 32)
        Me.Encripta.TabIndex = 3
        Me.Encripta.Text = "Encriptador"
        Me.Encripta.UseVisualStyleBackColor = True
        '
        'txtTexto
        '
        Me.txtTexto.Location = New System.Drawing.Point(26, 24)
        Me.txtTexto.Name = "txtTexto"
        Me.txtTexto.Size = New System.Drawing.Size(232, 20)
        Me.txtTexto.TabIndex = 1
        '
        'EtiquetaRes
        '
        Me.EtiquetaRes.AutoSize = True
        Me.EtiquetaRes.Location = New System.Drawing.Point(24, 176)
        Me.EtiquetaRes.Name = "EtiquetaRes"
        Me.EtiquetaRes.Size = New System.Drawing.Size(58, 13)
        Me.EtiquetaRes.TabIndex = 3
        Me.EtiquetaRes.Text = "Resultado:"
        '
        'lbResultado
        '
        Me.lbResultado.AutoSize = True
        Me.lbResultado.Location = New System.Drawing.Point(27, 214)
        Me.lbResultado.Name = "lbResultado"
        Me.lbResultado.Size = New System.Drawing.Size(0, 13)
        Me.lbResultado.TabIndex = 4
        '
        'txtResutado
        '
        Me.txtResutado.Location = New System.Drawing.Point(27, 200)
        Me.txtResutado.Name = "txtResutado"
        Me.txtResutado.Size = New System.Drawing.Size(231, 20)
        Me.txtResutado.TabIndex = 4
        '
        'btConexionbd
        '
        Me.btConexionbd.Location = New System.Drawing.Point(327, 24)
        Me.btConexionbd.Name = "btConexionbd"
        Me.btConexionbd.Size = New System.Drawing.Size(233, 25)
        Me.btConexionbd.TabIndex = 5
        Me.btConexionbd.Text = "Conexion BD"
        Me.btConexionbd.UseVisualStyleBackColor = True
        '
        'lbError
        '
        Me.lbError.AutoSize = True
        Me.lbError.Location = New System.Drawing.Point(335, 70)
        Me.lbError.Name = "lbError"
        Me.lbError.Size = New System.Drawing.Size(0, 13)
        Me.lbError.TabIndex = 7
        '
        'gvDatos
        '
        Me.gvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvDatos.Location = New System.Drawing.Point(327, 148)
        Me.gvDatos.Name = "gvDatos"
        Me.gvDatos.Size = New System.Drawing.Size(422, 269)
        Me.gvDatos.TabIndex = 6
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 447)
        Me.Controls.Add(Me.gvDatos)
        Me.Controls.Add(Me.lbError)
        Me.Controls.Add(Me.btConexionbd)
        Me.Controls.Add(Me.txtResutado)
        Me.Controls.Add(Me.lbResultado)
        Me.Controls.Add(Me.EtiquetaRes)
        Me.Controls.Add(Me.txtTexto)
        Me.Controls.Add(Me.Encripta)
        Me.Controls.Add(Me.Desencripta)
        Me.Name = "Form1"
        Me.Text = "Encritador NET"
        CType(Me.gvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Desencripta As Button
    Friend WithEvents Encripta As Button
    Friend WithEvents txtTexto As TextBox
    Friend WithEvents EtiquetaRes As Label
    Friend WithEvents lbResultado As Label
    Friend WithEvents txtResutado As TextBox
    Friend WithEvents btConexionbd As Button
    Friend WithEvents lbError As Label
    Friend WithEvents gvDatos As DataGridView
End Class
