<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUnidadOrg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUnidadOrg))
        Me.fraDatos = New System.Windows.Forms.GroupBox()
        Me.pbCarga = New System.Windows.Forms.ProgressBar()
        Me.cmdNivelAtras = New System.Windows.Forms.Button()
        Me.dgvFuncionarios = New System.Windows.Forms.DataGridView()
        Me.cmbNombre = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdLista = New System.Windows.Forms.Button()
        Me.cmbTipoUnidad = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumFuncs = New System.Windows.Forms.TextBox()
        Me.txtNumUnidad = New System.Windows.Forms.TextBox()
        Me.txtPadres = New System.Windows.Forms.TextBox()
        Me.pnlEdicion = New System.Windows.Forms.GroupBox()
        Me.chkAreaInterna = New System.Windows.Forms.CheckBox()
        Me.chkEstrategica = New System.Windows.Forms.CheckBox()
        Me.cmdBorrar = New System.Windows.Forms.Button()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.cmdBusca = New System.Windows.Forms.Button()
        Me.cmdReporte3 = New System.Windows.Forms.Button()
        Me.cmdReporte = New System.Windows.Forms.Button()
        Me.cmdArbol = New System.Windows.Forms.Button()
        Me.cmdReporte2 = New System.Windows.Forms.Button()
        Me.cmdCierra = New System.Windows.Forms.Button()
        Me.chkAnuladoss = New System.Windows.Forms.CheckBox()
        Me.fraDatos.SuspendLayout()
        CType(Me.dgvFuncionarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEdicion.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraDatos
        '
        Me.fraDatos.Controls.Add(Me.pbCarga)
        Me.fraDatos.Controls.Add(Me.cmdNivelAtras)
        Me.fraDatos.Controls.Add(Me.dgvFuncionarios)
        Me.fraDatos.Controls.Add(Me.cmbNombre)
        Me.fraDatos.Controls.Add(Me.Label6)
        Me.fraDatos.Controls.Add(Me.cmdLista)
        Me.fraDatos.Controls.Add(Me.cmbTipoUnidad)
        Me.fraDatos.Controls.Add(Me.Label4)
        Me.fraDatos.Controls.Add(Me.Label3)
        Me.fraDatos.Controls.Add(Me.Label2)
        Me.fraDatos.Controls.Add(Me.Label1)
        Me.fraDatos.Controls.Add(Me.txtNumFuncs)
        Me.fraDatos.Controls.Add(Me.txtNumUnidad)
        Me.fraDatos.Controls.Add(Me.txtPadres)
        Me.fraDatos.Controls.Add(Me.pnlEdicion)
        Me.fraDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraDatos.Location = New System.Drawing.Point(12, 12)
        Me.fraDatos.Name = "fraDatos"
        Me.fraDatos.Size = New System.Drawing.Size(885, 551)
        Me.fraDatos.TabIndex = 1
        Me.fraDatos.TabStop = False
        Me.fraDatos.Text = "Datos de la Unidad Organizacional"
        '
        'pbCarga
        '
        Me.pbCarga.Location = New System.Drawing.Point(28, 79)
        Me.pbCarga.Name = "pbCarga"
        Me.pbCarga.Size = New System.Drawing.Size(832, 31)
        Me.pbCarga.TabIndex = 24
        Me.pbCarga.Visible = False
        '
        'cmdNivelAtras
        '
        Me.cmdNivelAtras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNivelAtras.Location = New System.Drawing.Point(108, 68)
        Me.cmdNivelAtras.Name = "cmdNivelAtras"
        Me.cmdNivelAtras.Size = New System.Drawing.Size(363, 31)
        Me.cmdNivelAtras.TabIndex = 14
        Me.cmdNivelAtras.Text = "&Nivel Anterior"
        Me.cmdNivelAtras.UseVisualStyleBackColor = True
        '
        'dgvFuncionarios
        '
        Me.dgvFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFuncionarios.Location = New System.Drawing.Point(28, 342)
        Me.dgvFuncionarios.Name = "dgvFuncionarios"
        Me.dgvFuncionarios.RowHeadersWidth = 62
        Me.dgvFuncionarios.RowTemplate.Height = 28
        Me.dgvFuncionarios.Size = New System.Drawing.Size(832, 193)
        Me.dgvFuncionarios.TabIndex = 13
        '
        'cmbNombre
        '
        Me.cmbNombre.FormattingEnabled = True
        Me.cmbNombre.Location = New System.Drawing.Point(108, 32)
        Me.cmbNombre.Name = "cmbNombre"
        Me.cmbNombre.Size = New System.Drawing.Size(363, 30)
        Me.cmbNombre.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(477, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(239, 22)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Unidad Organizacional (CR):"
        '
        'cmdLista
        '
        Me.cmdLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLista.Location = New System.Drawing.Point(489, 217)
        Me.cmdLista.Name = "cmdLista"
        Me.cmdLista.Size = New System.Drawing.Size(371, 31)
        Me.cmdLista.TabIndex = 10
        Me.cmdLista.Text = "&Ver Lista"
        Me.cmdLista.UseVisualStyleBackColor = True
        '
        'cmbTipoUnidad
        '
        Me.cmbTipoUnidad.Enabled = False
        Me.cmbTipoUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoUnidad.FormattingEnabled = True
        Me.cmbTipoUnidad.Location = New System.Drawing.Point(292, 166)
        Me.cmbTipoUnidad.Name = "cmbTipoUnidad"
        Me.cmbTipoUnidad.Size = New System.Drawing.Size(568, 28)
        Me.cmbTipoUnidad.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 220)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(176, 22)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Gestores Asociados:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(262, 22)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Tipo de Unidad Organizacional:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 22)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nombre:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 22)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Ruta:"
        '
        'txtNumFuncs
        '
        Me.txtNumFuncs.Enabled = False
        Me.txtNumFuncs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumFuncs.Location = New System.Drawing.Point(206, 217)
        Me.txtNumFuncs.Name = "txtNumFuncs"
        Me.txtNumFuncs.Size = New System.Drawing.Size(265, 26)
        Me.txtNumFuncs.TabIndex = 3
        '
        'txtNumUnidad
        '
        Me.txtNumUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumUnidad.Location = New System.Drawing.Point(722, 34)
        Me.txtNumUnidad.Name = "txtNumUnidad"
        Me.txtNumUnidad.Size = New System.Drawing.Size(138, 26)
        Me.txtNumUnidad.TabIndex = 4
        '
        'txtPadres
        '
        Me.txtPadres.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPadres.Location = New System.Drawing.Point(83, 116)
        Me.txtPadres.Name = "txtPadres"
        Me.txtPadres.Size = New System.Drawing.Size(777, 26)
        Me.txtPadres.TabIndex = 1
        '
        'pnlEdicion
        '
        Me.pnlEdicion.Controls.Add(Me.chkAreaInterna)
        Me.pnlEdicion.Controls.Add(Me.chkEstrategica)
        Me.pnlEdicion.Controls.Add(Me.cmdBorrar)
        Me.pnlEdicion.Controls.Add(Me.cmdAgregar)
        Me.pnlEdicion.Location = New System.Drawing.Point(28, 251)
        Me.pnlEdicion.Name = "pnlEdicion"
        Me.pnlEdicion.Size = New System.Drawing.Size(832, 76)
        Me.pnlEdicion.TabIndex = 0
        Me.pnlEdicion.TabStop = False
        '
        'chkAreaInterna
        '
        Me.chkAreaInterna.AutoSize = True
        Me.chkAreaInterna.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAreaInterna.Location = New System.Drawing.Point(141, 32)
        Me.chkAreaInterna.Name = "chkAreaInterna"
        Me.chkAreaInterna.Size = New System.Drawing.Size(122, 24)
        Me.chkAreaInterna.TabIndex = 23
        Me.chkAreaInterna.Text = "Área interna"
        Me.chkAreaInterna.UseVisualStyleBackColor = True
        '
        'chkEstrategica
        '
        Me.chkEstrategica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEstrategica.Location = New System.Drawing.Point(6, 27)
        Me.chkEstrategica.Name = "chkEstrategica"
        Me.chkEstrategica.Size = New System.Drawing.Size(129, 34)
        Me.chkEstrategica.TabIndex = 22
        Me.chkEstrategica.Text = "Estratégica"
        Me.chkEstrategica.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkEstrategica.UseVisualStyleBackColor = True
        '
        'cmdBorrar
        '
        Me.cmdBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBorrar.Location = New System.Drawing.Point(570, 26)
        Me.cmdBorrar.Name = "cmdBorrar"
        Me.cmdBorrar.Size = New System.Drawing.Size(245, 34)
        Me.cmdBorrar.TabIndex = 13
        Me.cmdBorrar.Text = "&Borrar"
        Me.cmdBorrar.UseVisualStyleBackColor = True
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAgregar.Location = New System.Drawing.Point(293, 26)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(245, 34)
        Me.cmdAgregar.TabIndex = 12
        Me.cmdAgregar.Text = "&Agregar"
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'cmdBusca
        '
        Me.cmdBusca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBusca.Location = New System.Drawing.Point(40, 579)
        Me.cmdBusca.Name = "cmdBusca"
        Me.cmdBusca.Size = New System.Drawing.Size(195, 34)
        Me.cmdBusca.TabIndex = 15
        Me.cmdBusca.Text = "&Regresar a Primer Nivel"
        Me.cmdBusca.UseVisualStyleBackColor = True
        '
        'cmdReporte3
        '
        Me.cmdReporte3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReporte3.Location = New System.Drawing.Point(366, 579)
        Me.cmdReporte3.Name = "cmdReporte3"
        Me.cmdReporte3.Size = New System.Drawing.Size(180, 34)
        Me.cmdReporte3.TabIndex = 16
        Me.cmdReporte3.Text = "&Unidades Gestores"
        Me.cmdReporte3.UseVisualStyleBackColor = True
        '
        'cmdReporte
        '
        Me.cmdReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReporte.Location = New System.Drawing.Point(694, 579)
        Me.cmdReporte.Name = "cmdReporte"
        Me.cmdReporte.Size = New System.Drawing.Size(180, 34)
        Me.cmdReporte.TabIndex = 17
        Me.cmdReporte.Text = "&Reporte con  Cuentas"
        Me.cmdReporte.UseVisualStyleBackColor = True
        '
        'cmdArbol
        '
        Me.cmdArbol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdArbol.Location = New System.Drawing.Point(40, 635)
        Me.cmdArbol.Name = "cmdArbol"
        Me.cmdArbol.Size = New System.Drawing.Size(195, 34)
        Me.cmdArbol.TabIndex = 19
        Me.cmdArbol.Text = "Ac&tualizar"
        Me.cmdArbol.UseVisualStyleBackColor = True
        Me.cmdArbol.Visible = False
        '
        'cmdReporte2
        '
        Me.cmdReporte2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReporte2.Location = New System.Drawing.Point(366, 635)
        Me.cmdReporte2.Name = "cmdReporte2"
        Me.cmdReporte2.Size = New System.Drawing.Size(180, 34)
        Me.cmdReporte2.TabIndex = 20
        Me.cmdReporte2.Text = "Re&porte"
        Me.cmdReporte2.UseVisualStyleBackColor = True
        Me.cmdReporte2.Visible = False
        '
        'cmdCierra
        '
        Me.cmdCierra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCierra.Location = New System.Drawing.Point(694, 635)
        Me.cmdCierra.Name = "cmdCierra"
        Me.cmdCierra.Size = New System.Drawing.Size(180, 34)
        Me.cmdCierra.TabIndex = 21
        Me.cmdCierra.Text = "&Salir"
        Me.cmdCierra.UseVisualStyleBackColor = True
        '
        'chkAnuladoss
        '
        Me.chkAnuladoss.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkAnuladoss.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAnuladoss.Location = New System.Drawing.Point(333, 569)
        Me.chkAnuladoss.Name = "chkAnuladoss"
        Me.chkAnuladoss.Size = New System.Drawing.Size(244, 34)
        Me.chkAnuladoss.TabIndex = 23
        Me.chkAnuladoss.Text = "Incluir Gestores Inactivos"
        Me.chkAnuladoss.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkAnuladoss.UseVisualStyleBackColor = True
        Me.chkAnuladoss.Visible = False
        '
        'frmUnidadOrg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(917, 720)
        Me.Controls.Add(Me.chkAnuladoss)
        Me.Controls.Add(Me.cmdCierra)
        Me.Controls.Add(Me.cmdReporte2)
        Me.Controls.Add(Me.cmdArbol)
        Me.Controls.Add(Me.cmdReporte)
        Me.Controls.Add(Me.cmdReporte3)
        Me.Controls.Add(Me.cmdBusca)
        Me.Controls.Add(Me.fraDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUnidadOrg"
        Me.Text = "Consulta de Unidades Organizacionales"
        Me.fraDatos.ResumeLayout(False)
        Me.fraDatos.PerformLayout()
        CType(Me.dgvFuncionarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEdicion.ResumeLayout(False)
        Me.pnlEdicion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraDatos As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNumUnidad As TextBox
    Friend WithEvents txtPadres As TextBox
    Friend WithEvents cmbTipoUnidad As ComboBox
    Friend WithEvents cmdLista As Button
    Friend WithEvents cmdBorrar As Button
    Friend WithEvents cmdAgregar As Button
    Private WithEvents pnlEdicion As GroupBox
    Friend WithEvents cmdBusca As Button
    Friend WithEvents cmdReporte3 As Button
    Friend WithEvents cmdReporte As Button
    Friend WithEvents cmdArbol As Button
    Friend WithEvents cmdReporte2 As Button
    Friend WithEvents cmdCierra As Button
    Friend WithEvents chkEstrategica As CheckBox
    Friend WithEvents txtNumFuncs As TextBox
    Friend WithEvents chkAnuladoss As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbNombre As ComboBox
    Friend WithEvents dgvFuncionarios As DataGridView
    Friend WithEvents cmdNivelAtras As Button
    Friend WithEvents pbCarga As ProgressBar
    Friend WithEvents chkAreaInterna As CheckBox
End Class
