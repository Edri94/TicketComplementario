<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCargaDiasFeriados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargaDiasFeriados))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbAño = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbAmbos = New System.Windows.Forms.RadioButton()
        Me.rbEUA = New System.Windows.Forms.RadioButton()
        Me.rbMexico = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.loading = New System.Windows.Forms.PictureBox()
        Me.dtGrdVwFeriados = New System.Windows.Forms.DataGridView()
        Me.dtpMesFestivo = New System.Windows.Forms.MonthCalendar()
        Me.bgwCargaFines = New System.ComponentModel.BackgroundWorker()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.loading, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtGrdVwFeriados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbAño)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbMes)
        Me.GroupBox1.Controls.Add(Me.label1)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(941, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selecciones el Mes y Año a visualizar"
        '
        'cmbAño
        '
        Me.cmbAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAño.FormattingEnabled = True
        Me.cmbAño.Location = New System.Drawing.Point(578, 44)
        Me.cmbAño.Name = "cmbAño"
        Me.cmbAño.Size = New System.Drawing.Size(336, 28)
        Me.cmbAño.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(530, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Año:"
        '
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Location = New System.Drawing.Point(143, 44)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(336, 28)
        Me.cmbMes.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(94, 47)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(43, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Mes:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbAmbos)
        Me.GroupBox2.Controls.Add(Me.rbEUA)
        Me.GroupBox2.Controls.Add(Me.rbMexico)
        Me.GroupBox2.Location = New System.Drawing.Point(32, 164)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(941, 95)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Seleccione el pais"
        '
        'rbAmbos
        '
        Me.rbAmbos.AutoSize = True
        Me.rbAmbos.Location = New System.Drawing.Point(747, 39)
        Me.rbAmbos.Name = "rbAmbos"
        Me.rbAmbos.Size = New System.Drawing.Size(84, 24)
        Me.rbAmbos.TabIndex = 0
        Me.rbAmbos.TabStop = True
        Me.rbAmbos.Text = "Ambos"
        Me.rbAmbos.UseVisualStyleBackColor = True
        '
        'rbEUA
        '
        Me.rbEUA.AutoSize = True
        Me.rbEUA.Location = New System.Drawing.Point(536, 39)
        Me.rbEUA.Name = "rbEUA"
        Me.rbEUA.Size = New System.Drawing.Size(147, 24)
        Me.rbEUA.TabIndex = 0
        Me.rbEUA.TabStop = True
        Me.rbEUA.Text = "Estados Unidos"
        Me.rbEUA.UseVisualStyleBackColor = True
        '
        'rbMexico
        '
        Me.rbMexico.AutoSize = True
        Me.rbMexico.Location = New System.Drawing.Point(389, 39)
        Me.rbMexico.Name = "rbMexico"
        Me.rbMexico.Size = New System.Drawing.Size(83, 24)
        Me.rbMexico.TabIndex = 0
        Me.rbMexico.TabStop = True
        Me.rbMexico.Text = "Mexico"
        Me.rbMexico.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.loading)
        Me.GroupBox3.Controls.Add(Me.dtGrdVwFeriados)
        Me.GroupBox3.Controls.Add(Me.dtpMesFestivo)
        Me.GroupBox3.Location = New System.Drawing.Point(32, 290)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(941, 322)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Seleccionar el Dia"
        '
        'loading
        '
        Me.loading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.loading.Image = CType(resources.GetObject("loading.Image"), System.Drawing.Image)
        Me.loading.Location = New System.Drawing.Point(617, 91)
        Me.loading.Name = "loading"
        Me.loading.Size = New System.Drawing.Size(180, 159)
        Me.loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.loading.TabIndex = 2
        Me.loading.TabStop = False
        Me.loading.Visible = False
        '
        'dtGrdVwFeriados
        '
        Me.dtGrdVwFeriados.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        Me.dtGrdVwFeriados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtGrdVwFeriados.Location = New System.Drawing.Point(512, 43)
        Me.dtGrdVwFeriados.Name = "dtGrdVwFeriados"
        Me.dtGrdVwFeriados.RowHeadersWidth = 62
        Me.dtGrdVwFeriados.RowTemplate.Height = 28
        Me.dtGrdVwFeriados.Size = New System.Drawing.Size(391, 253)
        Me.dtGrdVwFeriados.TabIndex = 1
        '
        'dtpMesFestivo
        '
        Me.dtpMesFestivo.Location = New System.Drawing.Point(42, 43)
        Me.dtpMesFestivo.Name = "dtpMesFestivo"
        Me.dtpMesFestivo.TabIndex = 0
        '
        'bgwCargaFines
        '
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(813, 648)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(133, 45)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(649, 648)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(133, 45)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(485, 648)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(133, 45)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.Text = "Guadar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmCargaDiasFeriados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1006, 705)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmCargaDiasFeriados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga de Dias Feriados"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.loading, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtGrdVwFeriados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbAño As ComboBox
    Friend WithEvents cmbMes As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbAmbos As RadioButton
    Friend WithEvents rbEUA As RadioButton
    Friend WithEvents rbMexico As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dtpMesFestivo As MonthCalendar
    Friend WithEvents bgwCargaFines As System.ComponentModel.BackgroundWorker
    Friend WithEvents dtGrdVwFeriados As DataGridView
    Friend WithEvents loading As PictureBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Private WithEvents label1 As Label
    Friend WithEvents Label2 As Label
End Class
