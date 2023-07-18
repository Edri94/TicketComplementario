<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPerfilAsigna
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPerfilAsigna))
        Me.FrameX = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbNombre = New System.Windows.Forms.ComboBox()
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.cmbPerfiles = New System.Windows.Forms.ComboBox()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.LstChkPermisos = New System.Windows.Forms.CheckedListBox()
        Me.Frame3 = New System.Windows.Forms.GroupBox()
        Me.LstChkAutorizaciones = New System.Windows.Forms.CheckedListBox()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdActualizar = New System.Windows.Forms.Button()
        Me.lblArea = New System.Windows.Forms.Label()
        Me.FrameX.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Frame3.SuspendLayout()
        Me.SuspendLayout()
        '
        'FrameX
        '
        Me.FrameX.Controls.Add(Me.Label3)
        Me.FrameX.Controls.Add(Me.Label2)
        Me.FrameX.Controls.Add(Me.cmbNombre)
        Me.FrameX.Controls.Add(Me.cmbUsuarios)
        Me.FrameX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FrameX.Location = New System.Drawing.Point(12, 12)
        Me.FrameX.Name = "FrameX"
        Me.FrameX.Size = New System.Drawing.Size(715, 100)
        Me.FrameX.TabIndex = 0
        Me.FrameX.TabStop = False
        Me.FrameX.Text = "Usuarios"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(372, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 22)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 22)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Login"
        '
        'cmbNombre
        '
        Me.cmbNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNombre.FormattingEnabled = True
        Me.cmbNombre.Location = New System.Drawing.Point(372, 55)
        Me.cmbNombre.Name = "cmbNombre"
        Me.cmbNombre.Size = New System.Drawing.Size(325, 30)
        Me.cmbNombre.TabIndex = 1
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(6, 55)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(333, 30)
        Me.cmbUsuarios.TabIndex = 0
        '
        'Frame2
        '
        Me.Frame2.Controls.Add(Me.cmbPerfiles)
        Me.Frame2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.Location = New System.Drawing.Point(12, 118)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Size = New System.Drawing.Size(305, 82)
        Me.Frame2.TabIndex = 1
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Perfil"
        '
        'cmbPerfiles
        '
        Me.cmbPerfiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPerfiles.FormattingEnabled = True
        Me.cmbPerfiles.Location = New System.Drawing.Point(6, 34)
        Me.cmbPerfiles.Name = "cmbPerfiles"
        Me.cmbPerfiles.Size = New System.Drawing.Size(278, 30)
        Me.cmbPerfiles.TabIndex = 0
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.LstChkPermisos)
        Me.Frame1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.Location = New System.Drawing.Point(12, 206)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(715, 186)
        Me.Frame1.TabIndex = 2
        Me.Frame1.TabStop = False
        Me.Frame1.Text = " Permisos Individuales."
        '
        'LstChkPermisos
        '
        Me.LstChkPermisos.CheckOnClick = True
        Me.LstChkPermisos.Enabled = False
        Me.LstChkPermisos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstChkPermisos.FormattingEnabled = True
        Me.LstChkPermisos.Location = New System.Drawing.Point(13, 35)
        Me.LstChkPermisos.Name = "LstChkPermisos"
        Me.LstChkPermisos.Size = New System.Drawing.Size(684, 129)
        Me.LstChkPermisos.TabIndex = 0
        '
        'Frame3
        '
        Me.Frame3.Controls.Add(Me.LstChkAutorizaciones)
        Me.Frame3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.Location = New System.Drawing.Point(12, 444)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.Size = New System.Drawing.Size(715, 178)
        Me.Frame3.TabIndex = 3
        Me.Frame3.TabStop = False
        Me.Frame3.Text = " Autorizaciones Individuales"
        Me.Frame3.Visible = False
        '
        'LstChkAutorizaciones
        '
        Me.LstChkAutorizaciones.CheckOnClick = True
        Me.LstChkAutorizaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstChkAutorizaciones.FormattingEnabled = True
        Me.LstChkAutorizaciones.Location = New System.Drawing.Point(18, 32)
        Me.LstChkAutorizaciones.Name = "LstChkAutorizaciones"
        Me.LstChkAutorizaciones.Size = New System.Drawing.Size(679, 129)
        Me.LstChkAutorizaciones.TabIndex = 0
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.Location = New System.Drawing.Point(613, 398)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(96, 40)
        Me.cmdCerrar.TabIndex = 5
        Me.cmdCerrar.Text = "&Salir"
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdActualizar
        '
        Me.cmdActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdActualizar.Location = New System.Drawing.Point(437, 398)
        Me.cmdActualizar.Name = "cmdActualizar"
        Me.cmdActualizar.Size = New System.Drawing.Size(113, 40)
        Me.cmdActualizar.TabIndex = 4
        Me.cmdActualizar.Text = "&Actualizar"
        Me.cmdActualizar.UseVisualStyleBackColor = True
        '
        'lblArea
        '
        Me.lblArea.AutoSize = True
        Me.lblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArea.Location = New System.Drawing.Point(332, 152)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(131, 22)
        Me.lblArea.TabIndex = 6
        Me.lblArea.Text = "Usuario de ..."
        '
        'frmPerfilAsigna
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(743, 443)
        Me.Controls.Add(Me.lblArea)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.cmdActualizar)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.FrameX)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPerfilAsigna"
        Me.Text = "Asignación de Perfiles / Permisos"
        Me.FrameX.ResumeLayout(False)
        Me.FrameX.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Frame3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FrameX As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbNombre As ComboBox
    Friend WithEvents cmbUsuarios As ComboBox
    Friend WithEvents Frame2 As GroupBox
    Friend WithEvents cmbPerfiles As ComboBox
    Friend WithEvents Frame1 As GroupBox
    Friend WithEvents Frame3 As GroupBox
    Friend WithEvents cmdActualizar As Button
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents lblArea As Label
    Friend WithEvents LstChkPermisos As CheckedListBox
    Friend WithEvents LstChkAutorizaciones As CheckedListBox
End Class
