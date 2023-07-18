<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPerfilEdita
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPerfilEdita))
        Me.Frame3 = New System.Windows.Forms.GroupBox()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdActualizar = New System.Windows.Forms.Button()
        Me.LstChkComentario = New System.Windows.Forms.CheckedListBox()
        Me.LstChkAutorizaciones = New System.Windows.Forms.CheckedListBox()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.LstChkPermisos = New System.Windows.Forms.CheckedListBox()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNombrePerfil = New System.Windows.Forms.Label()
        Me.txtNombrePerfil = New System.Windows.Forms.TextBox()
        Me.cmbPerfiles = New System.Windows.Forms.ComboBox()
        Me.Frame3.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame3
        '
        Me.Frame3.Controls.Add(Me.Label3)
        Me.Frame3.Controls.Add(Me.Label1)
        Me.Frame3.Controls.Add(Me.LstChkComentario)
        Me.Frame3.Controls.Add(Me.LstChkAutorizaciones)
        Me.Frame3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.Location = New System.Drawing.Point(12, 419)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.Size = New System.Drawing.Size(724, 234)
        Me.Frame3.TabIndex = 10
        Me.Frame3.TabStop = False
        Me.Frame3.Visible = False
        '
        'cmdEliminar
        '
        Me.cmdEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminar.Location = New System.Drawing.Point(332, 373)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(113, 40)
        Me.cmdEliminar.TabIndex = 15
        Me.cmdEliminar.Text = "Eliminar"
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(229, 22)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Autorizaciones por Perfil"
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAgregar.Location = New System.Drawing.Point(204, 373)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(113, 39)
        Me.cmdAgregar.TabIndex = 14
        Me.cmdAgregar.Text = "Nuevo"
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(370, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 22)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Requiere comentario"
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.Location = New System.Drawing.Point(615, 373)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(96, 40)
        Me.cmdCerrar.TabIndex = 13
        Me.cmdCerrar.Text = "&Salir"
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdActualizar
        '
        Me.cmdActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdActualizar.Location = New System.Drawing.Point(467, 373)
        Me.cmdActualizar.Name = "cmdActualizar"
        Me.cmdActualizar.Size = New System.Drawing.Size(113, 40)
        Me.cmdActualizar.TabIndex = 12
        Me.cmdActualizar.Text = "&Actualizar"
        Me.cmdActualizar.UseVisualStyleBackColor = True
        '
        'LstChkComentario
        '
        Me.LstChkComentario.CheckOnClick = True
        Me.LstChkComentario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstChkComentario.FormattingEnabled = True
        Me.LstChkComentario.Location = New System.Drawing.Point(499, 42)
        Me.LstChkComentario.Name = "LstChkComentario"
        Me.LstChkComentario.Size = New System.Drawing.Size(200, 179)
        Me.LstChkComentario.TabIndex = 1
        '
        'LstChkAutorizaciones
        '
        Me.LstChkAutorizaciones.CheckOnClick = True
        Me.LstChkAutorizaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstChkAutorizaciones.FormattingEnabled = True
        Me.LstChkAutorizaciones.Location = New System.Drawing.Point(15, 42)
        Me.LstChkAutorizaciones.Name = "LstChkAutorizaciones"
        Me.LstChkAutorizaciones.Size = New System.Drawing.Size(484, 179)
        Me.LstChkAutorizaciones.TabIndex = 0
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.LstChkPermisos)
        Me.Frame1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.Location = New System.Drawing.Point(12, 124)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(718, 237)
        Me.Frame1.TabIndex = 9
        Me.Frame1.TabStop = False
        Me.Frame1.Text = " Permisos por Perfil."
        '
        'LstChkPermisos
        '
        Me.LstChkPermisos.CheckOnClick = True
        Me.LstChkPermisos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstChkPermisos.FormattingEnabled = True
        Me.LstChkPermisos.Location = New System.Drawing.Point(14, 45)
        Me.LstChkPermisos.Name = "LstChkPermisos"
        Me.LstChkPermisos.Size = New System.Drawing.Size(685, 179)
        Me.LstChkPermisos.TabIndex = 0
        '
        'Frame2
        '
        Me.Frame2.Controls.Add(Me.Label2)
        Me.Frame2.Controls.Add(Me.lblNombrePerfil)
        Me.Frame2.Controls.Add(Me.txtNombrePerfil)
        Me.Frame2.Controls.Add(Me.cmbPerfiles)
        Me.Frame2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.Location = New System.Drawing.Point(12, 6)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Size = New System.Drawing.Size(718, 95)
        Me.Frame2.TabIndex = 8
        Me.Frame2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 22)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Perfil"
        '
        'lblNombrePerfil
        '
        Me.lblNombrePerfil.AutoSize = True
        Me.lblNombrePerfil.Location = New System.Drawing.Point(361, 25)
        Me.lblNombrePerfil.Name = "lblNombrePerfil"
        Me.lblNombrePerfil.Size = New System.Drawing.Size(228, 22)
        Me.lblNombrePerfil.TabIndex = 14
        Me.lblNombrePerfil.Text = "Nombre del Nuevo Perfil"
        '
        'txtNombrePerfil
        '
        Me.txtNombrePerfil.Location = New System.Drawing.Point(365, 50)
        Me.txtNombrePerfil.Name = "txtNombrePerfil"
        Me.txtNombrePerfil.Size = New System.Drawing.Size(334, 28)
        Me.txtNombrePerfil.TabIndex = 6
        '
        'cmbPerfiles
        '
        Me.cmbPerfiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPerfiles.FormattingEnabled = True
        Me.cmbPerfiles.Location = New System.Drawing.Point(6, 45)
        Me.cmbPerfiles.Name = "cmbPerfiles"
        Me.cmbPerfiles.Size = New System.Drawing.Size(334, 30)
        Me.cmbPerfiles.TabIndex = 0
        '
        'frmPerfilEdita
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(748, 678)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdActualizar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPerfilEdita"
        Me.Text = "Edición de Perfiles"
        Me.Frame3.ResumeLayout(False)
        Me.Frame3.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Frame3 As GroupBox
    Friend WithEvents LstChkAutorizaciones As CheckedListBox
    Friend WithEvents Frame1 As GroupBox
    Friend WithEvents LstChkPermisos As CheckedListBox
    Friend WithEvents Frame2 As GroupBox
    Friend WithEvents cmbPerfiles As ComboBox
    Friend WithEvents LstChkComentario As CheckedListBox
    Friend WithEvents lblNombrePerfil As Label
    Friend WithEvents txtNombrePerfil As TextBox
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdActualizar As Button
    Friend WithEvents cmdAgregar As Button
    Friend WithEvents cmdEliminar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
End Class
