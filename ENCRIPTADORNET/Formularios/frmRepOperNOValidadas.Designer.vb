<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepOperNOValidadas
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkTipoRep1 = New System.Windows.Forms.CheckBox()
        Me.chkTipoRep0 = New System.Windows.Forms.CheckBox()
        Me.chkOperacion3 = New System.Windows.Forms.CheckBox()
        Me.chkOperacion2 = New System.Windows.Forms.CheckBox()
        Me.chkOperacion1 = New System.Windows.Forms.CheckBox()
        Me.chkOperacion0 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdConsultar = New System.Windows.Forms.Button()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgvOperacionesNOValidadas = New System.Windows.Forms.DataGridView()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvOperacionesNOValidadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.chkOperacion3)
        Me.GroupBox1.Controls.Add(Me.chkOperacion2)
        Me.GroupBox1.Controls.Add(Me.chkOperacion1)
        Me.GroupBox1.Controls.Add(Me.chkOperacion0)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtFecha)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(658, 126)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkTipoRep1)
        Me.GroupBox2.Controls.Add(Me.chkTipoRep0)
        Me.GroupBox2.Location = New System.Drawing.Point(326, 65)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(310, 47)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'chkTipoRep1
        '
        Me.chkTipoRep1.AutoSize = True
        Me.chkTipoRep1.Location = New System.Drawing.Point(175, 19)
        Me.chkTipoRep1.Name = "chkTipoRep1"
        Me.chkTipoRep1.Size = New System.Drawing.Size(90, 17)
        Me.chkTipoRep1.TabIndex = 1
        Me.chkTipoRep1.Text = "Reporte Swift"
        Me.chkTipoRep1.UseVisualStyleBackColor = True
        '
        'chkTipoRep0
        '
        Me.chkTipoRep0.AutoSize = True
        Me.chkTipoRep0.Location = New System.Drawing.Point(33, 19)
        Me.chkTipoRep0.Name = "chkTipoRep0"
        Me.chkTipoRep0.Size = New System.Drawing.Size(109, 17)
        Me.chkTipoRep0.TabIndex = 0
        Me.chkTipoRep0.Text = "Reporte Equation"
        Me.chkTipoRep0.UseVisualStyleBackColor = True
        '
        'chkOperacion3
        '
        Me.chkOperacion3.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkOperacion3.Location = New System.Drawing.Point(168, 78)
        Me.chkOperacion3.Name = "chkOperacion3"
        Me.chkOperacion3.Size = New System.Drawing.Size(100, 35)
        Me.chkOperacion3.TabIndex = 6
        Me.chkOperacion3.Text = "Orden de Pago Otras Divisas"
        Me.chkOperacion3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkOperacion3.UseVisualStyleBackColor = True
        '
        'chkOperacion2
        '
        Me.chkOperacion2.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkOperacion2.Location = New System.Drawing.Point(32, 78)
        Me.chkOperacion2.Name = "chkOperacion2"
        Me.chkOperacion2.Size = New System.Drawing.Size(100, 35)
        Me.chkOperacion2.TabIndex = 5
        Me.chkOperacion2.Text = "Retiro por Orden de Pago"
        Me.chkOperacion2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkOperacion2.UseVisualStyleBackColor = True
        '
        'chkOperacion1
        '
        Me.chkOperacion1.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkOperacion1.Location = New System.Drawing.Point(168, 29)
        Me.chkOperacion1.Name = "chkOperacion1"
        Me.chkOperacion1.Size = New System.Drawing.Size(100, 35)
        Me.chkOperacion1.TabIndex = 4
        Me.chkOperacion1.Text = "Retiro por Compra de TD"
        Me.chkOperacion1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkOperacion1.UseVisualStyleBackColor = True
        '
        'chkOperacion0
        '
        Me.chkOperacion0.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkOperacion0.Location = New System.Drawing.Point(32, 29)
        Me.chkOperacion0.Name = "chkOperacion0"
        Me.chkOperacion0.Size = New System.Drawing.Size(100, 35)
        Me.chkOperacion0.TabIndex = 3
        Me.chkOperacion0.Text = "Depositos y Retiros"
        Me.chkOperacion0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkOperacion0.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(459, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha:"
        '
        'txtFecha
        '
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = New System.Drawing.Point(514, 27)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(112, 22)
        Me.txtFecha.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(331, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 48)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Agencia HOUSTON"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdConsultar
        '
        Me.cmdConsultar.Location = New System.Drawing.Point(680, 21)
        Me.cmdConsultar.Name = "cmdConsultar"
        Me.cmdConsultar.Size = New System.Drawing.Size(100, 35)
        Me.cmdConsultar.TabIndex = 1
        Me.cmdConsultar.Text = "Consultar"
        Me.cmdConsultar.UseVisualStyleBackColor = True
        '
        'cmdImprimir
        '
        Me.cmdImprimir.Location = New System.Drawing.Point(680, 87)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(100, 35)
        Me.cmdImprimir.TabIndex = 2
        Me.cmdImprimir.Text = "Imprimir"
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvOperacionesNOValidadas)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 131)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(780, 250)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'dgvOperacionesNOValidadas
        '
        Me.dgvOperacionesNOValidadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOperacionesNOValidadas.Location = New System.Drawing.Point(5, 12)
        Me.dgvOperacionesNOValidadas.Name = "dgvOperacionesNOValidadas"
        Me.dgvOperacionesNOValidadas.Size = New System.Drawing.Size(769, 231)
        Me.dgvOperacionesNOValidadas.TabIndex = 0
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(686, 387)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(100, 35)
        Me.cmdSalir.TabIndex = 4
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'frmRepOperNOValidadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(793, 429)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.cmdConsultar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmRepOperNOValidadas"
        Me.Text = "Reporte Operaciones NO Validadas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvOperacionesNOValidadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkTipoRep1 As CheckBox
    Friend WithEvents chkTipoRep0 As CheckBox
    Friend WithEvents chkOperacion3 As CheckBox
    Friend WithEvents chkOperacion2 As CheckBox
    Friend WithEvents chkOperacion1 As CheckBox
    Friend WithEvents chkOperacion0 As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFecha As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdConsultar As Button
    Friend WithEvents cmdImprimir As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cmdSalir As Button
    Friend WithEvents dgvOperacionesNOValidadas As DataGridView
End Class
