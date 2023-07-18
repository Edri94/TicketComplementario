<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManttoParHor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManttoParHor))
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cboTOperacion = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdHorarios = New System.Windows.Forms.DataGridView()
        CType(Me.grdHorarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtHora
        '
        Me.txtHora.Location = New System.Drawing.Point(14, 435)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(116, 26)
        Me.txtHora.TabIndex = 0
        '
        'cmdGuardar
        '
        Me.cmdGuardar.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmdGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardar.Location = New System.Drawing.Point(360, 361)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(117, 35)
        Me.cmdGuardar.TabIndex = 1
        Me.cmdGuardar.Text = "Guardar"
        Me.cmdGuardar.UseVisualStyleBackColor = False
        '
        'cmdSalir
        '
        Me.cmdSalir.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmdSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalir.Location = New System.Drawing.Point(520, 361)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(117, 35)
        Me.cmdSalir.TabIndex = 2
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = False
        '
        'cboTOperacion
        '
        Me.cboTOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTOperacion.FormattingEnabled = True
        Me.cboTOperacion.Items.AddRange(New Object() {"Elegir una opcion"})
        Me.cboTOperacion.Location = New System.Drawing.Point(14, 46)
        Me.cboTOperacion.Name = "cboTOperacion"
        Me.cboTOperacion.Size = New System.Drawing.Size(214, 28)
        Me.cboTOperacion.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 22)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Tipo de Operación"
        '
        'grdHorarios
        '
        Me.grdHorarios.AllowUserToAddRows = False
        Me.grdHorarios.AllowUserToDeleteRows = False
        Me.grdHorarios.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.grdHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdHorarios.Location = New System.Drawing.Point(14, 83)
        Me.grdHorarios.Name = "grdHorarios"
        Me.grdHorarios.RowHeadersWidth = 62
        Me.grdHorarios.Size = New System.Drawing.Size(623, 264)
        Me.grdHorarios.TabIndex = 5
        '
        'frmManttoParHor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(651, 426)
        Me.Controls.Add(Me.grdHorarios)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboTOperacion)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.txtHora)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmManttoParHor"
        Me.Text = "Mantenimiento de Horarios de Operación Cash"
        CType(Me.grdHorarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtHora As TextBox
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents cmdSalir As Button
    Friend WithEvents cboTOperacion As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents grdHorarios As DataGridView
End Class
