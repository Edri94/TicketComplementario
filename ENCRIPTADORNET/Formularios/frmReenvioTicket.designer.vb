<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReenvioTicket
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReenvioTicket))
        Me.ssFrmRenvio = New System.Windows.Forms.GroupBox()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.txtFechaCapt = New System.Windows.Forms.TextBox()
        Me.txtFechaProc = New System.Windows.Forms.TextBox()
        Me.txtNumTicket = New System.Windows.Forms.TextBox()
        Me.txtNota = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdReenviar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.sfrmOperRechaz = New System.Windows.Forms.GroupBox()
        Me.gridOperRechazadas = New System.Windows.Forms.DataGridView()
        Me.lbGenArch = New System.Windows.Forms.Label()
        Me.pgbCarga = New System.Windows.Forms.ProgressBar()
        Me.ssFrmRenvio.SuspendLayout()
        Me.sfrmOperRechaz.SuspendLayout()
        CType(Me.gridOperRechazadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ssFrmRenvio
        '
        Me.ssFrmRenvio.Controls.Add(Me.txtMonto)
        Me.ssFrmRenvio.Controls.Add(Me.txtFechaCapt)
        Me.ssFrmRenvio.Controls.Add(Me.txtFechaProc)
        Me.ssFrmRenvio.Controls.Add(Me.txtNumTicket)
        Me.ssFrmRenvio.Controls.Add(Me.txtNota)
        Me.ssFrmRenvio.Controls.Add(Me.Label5)
        Me.ssFrmRenvio.Controls.Add(Me.Label4)
        Me.ssFrmRenvio.Controls.Add(Me.Label3)
        Me.ssFrmRenvio.Controls.Add(Me.Label2)
        Me.ssFrmRenvio.Controls.Add(Me.Label1)
        Me.ssFrmRenvio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ssFrmRenvio.Location = New System.Drawing.Point(12, 239)
        Me.ssFrmRenvio.Name = "ssFrmRenvio"
        Me.ssFrmRenvio.Size = New System.Drawing.Size(776, 295)
        Me.ssFrmRenvio.TabIndex = 1
        Me.ssFrmRenvio.TabStop = False
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(526, 88)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(235, 28)
        Me.txtMonto.TabIndex = 13
        '
        'txtFechaCapt
        '
        Me.txtFechaCapt.Location = New System.Drawing.Point(526, 44)
        Me.txtFechaCapt.Name = "txtFechaCapt"
        Me.txtFechaCapt.Size = New System.Drawing.Size(235, 28)
        Me.txtFechaCapt.TabIndex = 12
        '
        'txtFechaProc
        '
        Me.txtFechaProc.Location = New System.Drawing.Point(150, 88)
        Me.txtFechaProc.Name = "txtFechaProc"
        Me.txtFechaProc.Size = New System.Drawing.Size(232, 28)
        Me.txtFechaProc.TabIndex = 11
        '
        'txtNumTicket
        '
        Me.txtNumTicket.Location = New System.Drawing.Point(150, 47)
        Me.txtNumTicket.Name = "txtNumTicket"
        Me.txtNumTicket.Size = New System.Drawing.Size(232, 28)
        Me.txtNumTicket.TabIndex = 10
        '
        'txtNota
        '
        Me.txtNota.Location = New System.Drawing.Point(10, 152)
        Me.txtNota.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNota.Multiline = True
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(759, 131)
        Me.txtNota.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 22)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Nota del reenvío"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(388, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 22)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Monto : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(388, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 22)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Fecha Captura : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 22)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha Proceso : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Num. de Ticket : "
        '
        'cmdReenviar
        '
        Me.cmdReenviar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReenviar.Location = New System.Drawing.Point(489, 547)
        Me.cmdReenviar.Name = "cmdReenviar"
        Me.cmdReenviar.Size = New System.Drawing.Size(93, 45)
        Me.cmdReenviar.TabIndex = 2
        Me.cmdReenviar.Text = "&Reenviar"
        Me.cmdReenviar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(596, 547)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(92, 45)
        Me.cmdCancelar.TabIndex = 3
        Me.cmdCancelar.Text = "&Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalir.Location = New System.Drawing.Point(699, 547)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(89, 45)
        Me.cmdSalir.TabIndex = 4
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'sfrmOperRechaz
        '
        Me.sfrmOperRechaz.Controls.Add(Me.gridOperRechazadas)
        Me.sfrmOperRechaz.Location = New System.Drawing.Point(12, 12)
        Me.sfrmOperRechaz.Name = "sfrmOperRechaz"
        Me.sfrmOperRechaz.Size = New System.Drawing.Size(776, 221)
        Me.sfrmOperRechaz.TabIndex = 6
        Me.sfrmOperRechaz.TabStop = False
        '
        'gridOperRechazadas
        '
        Me.gridOperRechazadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridOperRechazadas.Location = New System.Drawing.Point(16, 30)
        Me.gridOperRechazadas.Name = "gridOperRechazadas"
        Me.gridOperRechazadas.RowHeadersWidth = 62
        Me.gridOperRechazadas.RowTemplate.Height = 28
        Me.gridOperRechazadas.Size = New System.Drawing.Size(745, 177)
        Me.gridOperRechazadas.TabIndex = 2
        '
        'lbGenArch
        '
        Me.lbGenArch.AutoSize = True
        Me.lbGenArch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbGenArch.Location = New System.Drawing.Point(17, 559)
        Me.lbGenArch.Name = "lbGenArch"
        Me.lbGenArch.Size = New System.Drawing.Size(31, 22)
        Me.lbGenArch.TabIndex = 12
        Me.lbGenArch.Text = " -  "
        Me.lbGenArch.Visible = False
        '
        'pgbCarga
        '
        Me.pgbCarga.Location = New System.Drawing.Point(439, 554)
        Me.pgbCarga.Name = "pgbCarga"
        Me.pgbCarga.Size = New System.Drawing.Size(327, 38)
        Me.pgbCarga.TabIndex = 11
        Me.pgbCarga.Visible = False
        '
        'frmReenvioTicket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.Controls.Add(Me.lbGenArch)
        Me.Controls.Add(Me.pgbCarga)
        Me.Controls.Add(Me.sfrmOperRechaz)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdReenviar)
        Me.Controls.Add(Me.ssFrmRenvio)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReenvioTicket"
        Me.Text = "Reenvío de Operaciones"
        Me.ssFrmRenvio.ResumeLayout(False)
        Me.ssFrmRenvio.PerformLayout()
        Me.sfrmOperRechaz.ResumeLayout(False)
        CType(Me.gridOperRechazadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ssFrmRenvio As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents txtFechaCapt As TextBox
    Friend WithEvents txtFechaProc As TextBox
    Friend WithEvents txtNumTicket As TextBox
    Friend WithEvents txtNota As TextBox
    Friend WithEvents cmdReenviar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents cmdSalir As Button
    Friend WithEvents sfrmOperRechaz As GroupBox
    Friend WithEvents gridOperRechazadas As DataGridView
    Friend WithEvents lbGenArch As Label
    Friend WithEvents pgbCarga As ProgressBar
End Class
