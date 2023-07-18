<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMT103OrdPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMT103OrdPago))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RbTodas = New System.Windows.Forms.RadioButton()
        Me.RbNoEnv = New System.Windows.Forms.RadioButton()
        Me.RbEnv = New System.Windows.Forms.RadioButton()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.cmdConsultar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFechaFin = New System.Windows.Forms.TextBox()
        Me.txtFechaIni = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblOperCanceladas = New System.Windows.Forms.Label()
        Me.lblPendDetenidosSwift = New System.Windows.Forms.Label()
        Me.lblAplicYEnv_EQ = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtOperCanceladas = New System.Windows.Forms.TextBox()
        Me.txtPendDetenidosSwift = New System.Windows.Forms.TextBox()
        Me.txtAplicYEnv_EQ = New System.Windows.Forms.TextBox()
        Me.txtEnvEqPendxConfirmar = New System.Windows.Forms.TextBox()
        Me.txtPendientesxAplicar = New System.Windows.Forms.TextBox()
        Me.txtPendxConfirmar = New System.Windows.Forms.TextBox()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.cmdImprimir)
        Me.GroupBox1.Controls.Add(Me.cmdConsultar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtFechaFin)
        Me.GroupBox1.Controls.Add(Me.txtFechaIni)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 6)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(1164, 148)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parametros de Consulta"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RbTodas)
        Me.GroupBox3.Controls.Add(Me.RbNoEnv)
        Me.GroupBox3.Controls.Add(Me.RbEnv)
        Me.GroupBox3.Location = New System.Drawing.Point(-84, 29)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Size = New System.Drawing.Size(164, 174)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ordenes de Pago:"
        Me.GroupBox3.Visible = False
        '
        'RbTodas
        '
        Me.RbTodas.AutoSize = True
        Me.RbTodas.Location = New System.Drawing.Point(26, 118)
        Me.RbTodas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RbTodas.Name = "RbTodas"
        Me.RbTodas.Size = New System.Drawing.Size(78, 24)
        Me.RbTodas.TabIndex = 5
        Me.RbTodas.TabStop = True
        Me.RbTodas.Text = "Todas"
        Me.RbTodas.UseVisualStyleBackColor = True
        Me.RbTodas.Visible = False
        '
        'RbNoEnv
        '
        Me.RbNoEnv.AutoSize = True
        Me.RbNoEnv.Location = New System.Drawing.Point(27, 83)
        Me.RbNoEnv.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RbNoEnv.Name = "RbNoEnv"
        Me.RbNoEnv.Size = New System.Drawing.Size(121, 24)
        Me.RbNoEnv.TabIndex = 4
        Me.RbNoEnv.TabStop = True
        Me.RbNoEnv.Text = "No enviadas"
        Me.RbNoEnv.UseVisualStyleBackColor = True
        Me.RbNoEnv.Visible = False
        '
        'RbEnv
        '
        Me.RbEnv.AutoSize = True
        Me.RbEnv.Location = New System.Drawing.Point(26, 34)
        Me.RbEnv.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RbEnv.Name = "RbEnv"
        Me.RbEnv.Size = New System.Drawing.Size(99, 24)
        Me.RbEnv.TabIndex = 3
        Me.RbEnv.TabStop = True
        Me.RbEnv.Text = "Enviadas"
        Me.RbEnv.UseVisualStyleBackColor = True
        Me.RbEnv.Visible = False
        '
        'cmdImprimir
        '
        Me.cmdImprimir.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cmdImprimir.Location = New System.Drawing.Point(976, 63)
        Me.cmdImprimir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(150, 54)
        Me.cmdImprimir.TabIndex = 12
        Me.cmdImprimir.Text = "Imprimir"
        Me.cmdImprimir.UseVisualStyleBackColor = False
        '
        'cmdConsultar
        '
        Me.cmdConsultar.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cmdConsultar.Location = New System.Drawing.Point(783, 63)
        Me.cmdConsultar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdConsultar.Name = "cmdConsultar"
        Me.cmdConsultar.Size = New System.Drawing.Size(150, 54)
        Me.cmdConsultar.TabIndex = 13
        Me.cmdConsultar.Text = "Consultar"
        Me.cmdConsultar.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(531, 51)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Fecha Fin:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(332, 51)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Fecha Inicio:"
        '
        'txtFechaFin
        '
        Me.txtFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFin.Location = New System.Drawing.Point(532, 77)
        Me.txtFechaFin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.Size = New System.Drawing.Size(148, 29)
        Me.txtFechaFin.TabIndex = 9
        Me.txtFechaFin.Text = "0000-00-00"
        Me.txtFechaFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFechaIni
        '
        Me.txtFechaIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaIni.Location = New System.Drawing.Point(332, 77)
        Me.txtFechaIni.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFechaIni.Name = "txtFechaIni"
        Me.txtFechaIni.Size = New System.Drawing.Size(148, 29)
        Me.txtFechaIni.TabIndex = 8
        Me.txtFechaIni.Text = "0000-00-00"
        Me.txtFechaIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(88, 54)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 57)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Agencia HOUSTON"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblOperCanceladas)
        Me.GroupBox2.Controls.Add(Me.lblPendDetenidosSwift)
        Me.GroupBox2.Controls.Add(Me.lblAplicYEnv_EQ)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtOperCanceladas)
        Me.GroupBox2.Controls.Add(Me.txtPendDetenidosSwift)
        Me.GroupBox2.Controls.Add(Me.txtAplicYEnv_EQ)
        Me.GroupBox2.Controls.Add(Me.txtEnvEqPendxConfirmar)
        Me.GroupBox2.Controls.Add(Me.txtPendientesxAplicar)
        Me.GroupBox2.Controls.Add(Me.txtPendxConfirmar)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 169)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(1164, 208)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Resumen Resultado de Consulta"
        '
        'lblOperCanceladas
        '
        Me.lblOperCanceladas.AutoSize = True
        Me.lblOperCanceladas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperCanceladas.Location = New System.Drawing.Point(664, 162)
        Me.lblOperCanceladas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOperCanceladas.Name = "lblOperCanceladas"
        Me.lblOperCanceladas.Size = New System.Drawing.Size(223, 24)
        Me.lblOperCanceladas.TabIndex = 20
        Me.lblOperCanceladas.Text = "Operaciones Canceladas"
        '
        'lblPendDetenidosSwift
        '
        Me.lblPendDetenidosSwift.AutoSize = True
        Me.lblPendDetenidosSwift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendDetenidosSwift.Location = New System.Drawing.Point(664, 102)
        Me.lblPendDetenidosSwift.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPendDetenidosSwift.Name = "lblPendDetenidosSwift"
        Me.lblPendDetenidosSwift.Size = New System.Drawing.Size(265, 24)
        Me.lblPendDetenidosSwift.TabIndex = 19
        Me.lblPendDetenidosSwift.Text = "Pendientes Detenidos en Swift"
        '
        'lblAplicYEnv_EQ
        '
        Me.lblAplicYEnv_EQ.AutoSize = True
        Me.lblAplicYEnv_EQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAplicYEnv_EQ.Location = New System.Drawing.Point(664, 45)
        Me.lblAplicYEnv_EQ.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAplicYEnv_EQ.Name = "lblAplicYEnv_EQ"
        Me.lblAplicYEnv_EQ.Size = New System.Drawing.Size(285, 24)
        Me.lblAplicYEnv_EQ.TabIndex = 18
        Me.lblAplicYEnv_EQ.Text = "Aplicados y Enviados a Equation"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(63, 160)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(336, 24)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Enviadas Equation Pend por Confirmar"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(63, 100)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(201, 24)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Pendientes por Aplicar"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(63, 43)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(224, 24)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Pendientes por Confirmar"
        '
        'txtOperCanceladas
        '
        Me.txtOperCanceladas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOperCanceladas.Location = New System.Drawing.Point(976, 155)
        Me.txtOperCanceladas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtOperCanceladas.Name = "txtOperCanceladas"
        Me.txtOperCanceladas.Size = New System.Drawing.Size(148, 29)
        Me.txtOperCanceladas.TabIndex = 14
        Me.txtOperCanceladas.Text = "0"
        Me.txtOperCanceladas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPendDetenidosSwift
        '
        Me.txtPendDetenidosSwift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPendDetenidosSwift.Location = New System.Drawing.Point(976, 95)
        Me.txtPendDetenidosSwift.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPendDetenidosSwift.Name = "txtPendDetenidosSwift"
        Me.txtPendDetenidosSwift.Size = New System.Drawing.Size(148, 29)
        Me.txtPendDetenidosSwift.TabIndex = 13
        Me.txtPendDetenidosSwift.Text = "0"
        Me.txtPendDetenidosSwift.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAplicYEnv_EQ
        '
        Me.txtAplicYEnv_EQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAplicYEnv_EQ.Location = New System.Drawing.Point(976, 38)
        Me.txtAplicYEnv_EQ.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtAplicYEnv_EQ.Name = "txtAplicYEnv_EQ"
        Me.txtAplicYEnv_EQ.Size = New System.Drawing.Size(148, 29)
        Me.txtAplicYEnv_EQ.TabIndex = 12
        Me.txtAplicYEnv_EQ.Text = "0"
        Me.txtAplicYEnv_EQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEnvEqPendxConfirmar
        '
        Me.txtEnvEqPendxConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEnvEqPendxConfirmar.Location = New System.Drawing.Point(426, 155)
        Me.txtEnvEqPendxConfirmar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtEnvEqPendxConfirmar.Name = "txtEnvEqPendxConfirmar"
        Me.txtEnvEqPendxConfirmar.Size = New System.Drawing.Size(148, 29)
        Me.txtEnvEqPendxConfirmar.TabIndex = 11
        Me.txtEnvEqPendxConfirmar.Text = "0"
        Me.txtEnvEqPendxConfirmar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPendientesxAplicar
        '
        Me.txtPendientesxAplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPendientesxAplicar.Location = New System.Drawing.Point(426, 95)
        Me.txtPendientesxAplicar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPendientesxAplicar.Name = "txtPendientesxAplicar"
        Me.txtPendientesxAplicar.Size = New System.Drawing.Size(148, 29)
        Me.txtPendientesxAplicar.TabIndex = 10
        Me.txtPendientesxAplicar.Text = "0"
        Me.txtPendientesxAplicar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPendxConfirmar
        '
        Me.txtPendxConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPendxConfirmar.Location = New System.Drawing.Point(426, 38)
        Me.txtPendxConfirmar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPendxConfirmar.Name = "txtPendxConfirmar"
        Me.txtPendxConfirmar.Size = New System.Drawing.Size(148, 29)
        Me.txtPendxConfirmar.TabIndex = 9
        Me.txtPendxConfirmar.Text = "0"
        Me.txtPendxConfirmar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdSalir
        '
        Me.cmdSalir.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cmdSalir.Location = New System.Drawing.Point(994, 400)
        Me.cmdSalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(150, 54)
        Me.cmdSalir.TabIndex = 3
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = False
        '
        'frmMT103OrdPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1200, 478)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmMT103OrdPago"
        Me.Text = "Ordenes de Pago"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFechaFin As TextBox
    Friend WithEvents txtFechaIni As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmdImprimir As Button
    Friend WithEvents cmdConsultar As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RbTodas As RadioButton
    Friend WithEvents RbNoEnv As RadioButton
    Friend WithEvents RbEnv As RadioButton
    Friend WithEvents txtOperCanceladas As TextBox
    Friend WithEvents txtPendDetenidosSwift As TextBox
    Friend WithEvents txtAplicYEnv_EQ As TextBox
    Friend WithEvents txtEnvEqPendxConfirmar As TextBox
    Friend WithEvents txtPendientesxAplicar As TextBox
    Friend WithEvents txtPendxConfirmar As TextBox
    Friend WithEvents cmdSalir As Button
    Friend WithEvents lblOperCanceladas As Label
    Friend WithEvents lblPendDetenidosSwift As Label
    Friend WithEvents lblAplicYEnv_EQ As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
End Class
