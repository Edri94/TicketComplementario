﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentasSaldosSobregiros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCuentasSaldosSobregiros))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.txtFechaIni = New System.Windows.Forms.TextBox()
        Me.cmdConsultar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvSaldosSobregiros = New System.Windows.Forms.DataGridView()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvSaldosSobregiros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox1.Controls.Add(Me.cmdImprimir)
        Me.GroupBox1.Controls.Add(Me.txtFechaIni)
        Me.GroupBox1.Controls.Add(Me.cmdConsultar)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 3)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(1164, 135)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'cmdImprimir
        '
        Me.cmdImprimir.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cmdImprimir.Location = New System.Drawing.Point(975, 46)
        Me.cmdImprimir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(150, 54)
        Me.cmdImprimir.TabIndex = 3
        Me.cmdImprimir.Text = "Imprimir"
        Me.cmdImprimir.UseVisualStyleBackColor = False
        '
        'txtFechaIni
        '
        Me.txtFechaIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaIni.Location = New System.Drawing.Point(462, 58)
        Me.txtFechaIni.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFechaIni.Name = "txtFechaIni"
        Me.txtFechaIni.Size = New System.Drawing.Size(148, 29)
        Me.txtFechaIni.TabIndex = 6
        Me.txtFechaIni.Text = "0000-00-00"
        Me.txtFechaIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdConsultar
        '
        Me.cmdConsultar.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cmdConsultar.Location = New System.Drawing.Point(777, 46)
        Me.cmdConsultar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdConsultar.Name = "cmdConsultar"
        Me.cmdConsultar.Size = New System.Drawing.Size(150, 54)
        Me.cmdConsultar.TabIndex = 5
        Me.cmdConsultar.Text = "Consultar"
        Me.cmdConsultar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(393, 66)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha:"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(60, 46)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 57)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Agencia HOUSTON"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvSaldosSobregiros
        '
        Me.dgvSaldosSobregiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSaldosSobregiros.Location = New System.Drawing.Point(18, 151)
        Me.dgvSaldosSobregiros.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvSaldosSobregiros.Name = "dgvSaldosSobregiros"
        Me.dgvSaldosSobregiros.RowHeadersWidth = 62
        Me.dgvSaldosSobregiros.Size = New System.Drawing.Size(1164, 372)
        Me.dgvSaldosSobregiros.TabIndex = 3
        '
        'cmdSalir
        '
        Me.cmdSalir.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cmdSalir.Location = New System.Drawing.Point(1002, 540)
        Me.cmdSalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(150, 54)
        Me.cmdSalir.TabIndex = 4
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = False
        '
        'frmCuentasSaldosSobregiros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1200, 609)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.dgvSaldosSobregiros)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmCuentasSaldosSobregiros"
        Me.Text = "Reporte de Consulta de Cuentas Sobregiradas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvSaldosSobregiros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmdImprimir As Button
    Friend WithEvents txtFechaIni As TextBox
    Friend WithEvents cmdConsultar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvSaldosSobregiros As DataGridView
    Friend WithEvents cmdSalir As Button
End Class
