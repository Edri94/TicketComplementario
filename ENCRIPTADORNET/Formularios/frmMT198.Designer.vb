<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMT198
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMT198))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFormatoFecha = New System.Windows.Forms.Label()
        Me.cboAgencias = New System.Windows.Forms.ComboBox()
        Me.cboOperacion = New System.Windows.Forms.ComboBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optOpciones2 = New System.Windows.Forms.RadioButton()
        Me.optOpciones1 = New System.Windows.Forms.RadioButton()
        Me.optOpciones0 = New System.Windows.Forms.RadioButton()
        Me.chkImprimeReporte = New System.Windows.Forms.CheckBox()
        Me.chkUltimoRep = New System.Windows.Forms.CheckBox()
        Me.lblTotalOperaciones = New System.Windows.Forms.Label()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdPorEnviar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.lblTemas = New System.Windows.Forms.Label()
        Me.lstOperacion = New System.Windows.Forms.ListBox()
        Me.pbMT198 = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Agencia:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Operacion:"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 22)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha:"
        '
        'lblFormatoFecha
        '
        Me.lblFormatoFecha.AutoSize = True
        Me.lblFormatoFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormatoFecha.Location = New System.Drawing.Point(280, 57)
        Me.lblFormatoFecha.Name = "lblFormatoFecha"
        Me.lblFormatoFecha.Size = New System.Drawing.Size(122, 22)
        Me.lblFormatoFecha.TabIndex = 3
        Me.lblFormatoFecha.Text = "(dd-mm-aaaa)"
        '
        'cboAgencias
        '
        Me.cboAgencias.FormattingEnabled = True
        Me.cboAgencias.Location = New System.Drawing.Point(91, 8)
        Me.cboAgencias.Name = "cboAgencias"
        Me.cboAgencias.Size = New System.Drawing.Size(225, 28)
        Me.cboAgencias.TabIndex = 8
        '
        'cboOperacion
        '
        Me.cboOperacion.FormattingEnabled = True
        Me.cboOperacion.Location = New System.Drawing.Point(116, 52)
        Me.cboOperacion.Name = "cboOperacion"
        Me.cboOperacion.Size = New System.Drawing.Size(225, 28)
        Me.cboOperacion.TabIndex = 9
        Me.cboOperacion.Visible = False
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "dd-MM-yyyy"
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(91, 54)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(183, 26)
        Me.dtpFecha.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optOpciones2)
        Me.GroupBox1.Controls.Add(Me.optOpciones1)
        Me.GroupBox1.Controls.Add(Me.optOpciones0)
        Me.GroupBox1.Controls.Add(Me.chkImprimeReporte)
        Me.GroupBox1.Controls.Add(Me.chkUltimoRep)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 386)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(518, 73)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'optOpciones2
        '
        Me.optOpciones2.AutoSize = True
        Me.optOpciones2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optOpciones2.Location = New System.Drawing.Point(609, 25)
        Me.optOpciones2.Name = "optOpciones2"
        Me.optOpciones2.Size = New System.Drawing.Size(107, 26)
        Me.optOpciones2.TabIndex = 7
        Me.optOpciones2.TabStop = True
        Me.optOpciones2.Text = "&Reenviar"
        Me.optOpciones2.UseVisualStyleBackColor = True
        Me.optOpciones2.Visible = False
        '
        'optOpciones1
        '
        Me.optOpciones1.AutoSize = True
        Me.optOpciones1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optOpciones1.Location = New System.Drawing.Point(365, 25)
        Me.optOpciones1.Name = "optOpciones1"
        Me.optOpciones1.Size = New System.Drawing.Size(97, 26)
        Me.optOpciones1.TabIndex = 6
        Me.optOpciones1.TabStop = True
        Me.optOpciones1.Text = "&Imprimir"
        Me.optOpciones1.UseVisualStyleBackColor = True
        Me.optOpciones1.Visible = False
        '
        'optOpciones0
        '
        Me.optOpciones0.AutoSize = True
        Me.optOpciones0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optOpciones0.Location = New System.Drawing.Point(32, 25)
        Me.optOpciones0.Name = "optOpciones0"
        Me.optOpciones0.Size = New System.Drawing.Size(167, 26)
        Me.optOpciones0.TabIndex = 5
        Me.optOpciones0.TabStop = True
        Me.optOpciones0.Text = "Imprimir y &Enviar"
        Me.optOpciones0.UseVisualStyleBackColor = True
        '
        'chkImprimeReporte
        '
        Me.chkImprimeReporte.AutoSize = True
        Me.chkImprimeReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkImprimeReporte.Location = New System.Drawing.Point(328, 87)
        Me.chkImprimeReporte.Name = "chkImprimeReporte"
        Me.chkImprimeReporte.Size = New System.Drawing.Size(173, 26)
        Me.chkImprimeReporte.TabIndex = 4
        Me.chkImprimeReporte.Text = "Generar Rep Imp"
        Me.chkImprimeReporte.UseVisualStyleBackColor = True
        Me.chkImprimeReporte.Visible = False
        '
        'chkUltimoRep
        '
        Me.chkUltimoRep.AutoSize = True
        Me.chkUltimoRep.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUltimoRep.Location = New System.Drawing.Point(32, 87)
        Me.chkUltimoRep.Name = "chkUltimoRep"
        Me.chkUltimoRep.Size = New System.Drawing.Size(155, 26)
        Me.chkUltimoRep.TabIndex = 3
        Me.chkUltimoRep.Text = "Último Reporte"
        Me.chkUltimoRep.UseVisualStyleBackColor = True
        Me.chkUltimoRep.Visible = False
        '
        'lblTotalOperaciones
        '
        Me.lblTotalOperaciones.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTotalOperaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalOperaciones.ForeColor = System.Drawing.SystemColors.Window
        Me.lblTotalOperaciones.Location = New System.Drawing.Point(15, 479)
        Me.lblTotalOperaciones.Name = "lblTotalOperaciones"
        Me.lblTotalOperaciones.Size = New System.Drawing.Size(522, 26)
        Me.lblTotalOperaciones.TabIndex = 13
        Me.lblTotalOperaciones.Text = "Número de operaciones por enviar: "
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(12, 520)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(149, 44)
        Me.cmdAceptar.TabIndex = 14
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdPorEnviar
        '
        Me.cmdPorEnviar.Location = New System.Drawing.Point(199, 520)
        Me.cmdPorEnviar.Name = "cmdPorEnviar"
        Me.cmdPorEnviar.Size = New System.Drawing.Size(149, 44)
        Me.cmdPorEnviar.TabIndex = 15
        Me.cmdPorEnviar.Text = "&Por Enviar"
        Me.cmdPorEnviar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(388, 520)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(149, 44)
        Me.cmdCancelar.TabIndex = 16
        Me.cmdCancelar.Text = "&Cerrar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'lblTemas
        '
        Me.lblTemas.AutoSize = True
        Me.lblTemas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTemas.Location = New System.Drawing.Point(15, 98)
        Me.lblTemas.Name = "lblTemas"
        Me.lblTemas.Size = New System.Drawing.Size(466, 22)
        Me.lblTemas.TabIndex = 18
        Me.lblTemas.Text = "Operación:             Cuenta:            Reporte:           Status:"
        '
        'lstOperacion
        '
        Me.lstOperacion.FormattingEnabled = True
        Me.lstOperacion.ItemHeight = 20
        Me.lstOperacion.Location = New System.Drawing.Point(19, 137)
        Me.lstOperacion.Name = "lstOperacion"
        Me.lstOperacion.Size = New System.Drawing.Size(518, 244)
        Me.lstOperacion.TabIndex = 19
        '
        'pbMT198
        '
        Me.pbMT198.Location = New System.Drawing.Point(16, 479)
        Me.pbMT198.Name = "pbMT198"
        Me.pbMT198.Size = New System.Drawing.Size(521, 26)
        Me.pbMT198.TabIndex = 20
        Me.pbMT198.Visible = False
        '
        'frmMT198
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(556, 577)
        Me.Controls.Add(Me.pbMT198)
        Me.Controls.Add(Me.lstOperacion)
        Me.Controls.Add(Me.lblTemas)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdPorEnviar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.lblTotalOperaciones)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.cboOperacion)
        Me.Controls.Add(Me.cboAgencias)
        Me.Controls.Add(Me.lblFormatoFecha)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMT198"
        Me.Text = "Reporte MT198"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblFormatoFecha As Label
    Friend WithEvents cboAgencias As ComboBox
    Friend WithEvents cboOperacion As ComboBox
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chkImprimeReporte As CheckBox
    Friend WithEvents chkUltimoRep As CheckBox
    Friend WithEvents lblTotalOperaciones As Label
    Friend WithEvents cmdAceptar As Button
    Friend WithEvents cmdPorEnviar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents optOpciones2 As RadioButton
    Friend WithEvents optOpciones1 As RadioButton
    Friend WithEvents optOpciones0 As RadioButton
    Friend WithEvents lblTemas As Label
    Friend WithEvents lstOperacion As ListBox
    Friend WithEvents pbMT198 As ProgressBar
End Class
