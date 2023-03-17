<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSolicitudChequeraNormal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSolicitudChequeraNormal))
        Me.grbDatosCliente = New System.Windows.Forms.GroupBox()
        Me.txFechaSolicitud = New System.Windows.Forms.TextBox()
        Me.dllNomCta = New System.Windows.Forms.ComboBox()
        Me.txNumCta = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grbDatosCuenta = New System.Windows.Forms.GroupBox()
        Me.dllSucCta = New System.Windows.Forms.ComboBox()
        Me.txCRCta = New System.Windows.Forms.TextBox()
        Me.txCtaEjePesos = New System.Windows.Forms.TextBox()
        Me.txNumSucCta = New System.Windows.Forms.TextBox()
        Me.txNumCRCta = New System.Windows.Forms.TextBox()
        Me.txGestorPesos = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grbNoEspeciales = New System.Windows.Forms.GroupBox()
        Me.txMotivoError = New System.Windows.Forms.TextBox()
        Me.lbMotivoError = New System.Windows.Forms.TextBox()
        Me.dllNumCheques = New System.Windows.Forms.ComboBox()
        Me.dllSucursal = New System.Windows.Forms.ComboBox()
        Me.txCR = New System.Windows.Forms.TextBox()
        Me.txNomGestor = New System.Windows.Forms.TextBox()
        Me.txNumSucursal = New System.Windows.Forms.TextBox()
        Me.txNumCR = New System.Windows.Forms.TextBox()
        Me.btSolError = New System.Windows.Forms.Button()
        Me.txNumGestor = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btCancelar = New System.Windows.Forms.Button()
        Me.grbResultados = New System.Windows.Forms.GroupBox()
        Me.lblFolioFin = New System.Windows.Forms.TextBox()
        Me.lblFolioIni = New System.Windows.Forms.TextBox()
        Me.lblRegistro = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btAceptar = New System.Windows.Forms.Button()
        Me.btLimpiar = New System.Windows.Forms.Button()
        Me.btCerrar = New System.Windows.Forms.Button()
        Me.grbDatosCliente.SuspendLayout()
        Me.grbDatosCuenta.SuspendLayout()
        Me.grbNoEspeciales.SuspendLayout()
        Me.grbResultados.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbDatosCliente
        '
        Me.grbDatosCliente.Controls.Add(Me.txFechaSolicitud)
        Me.grbDatosCliente.Controls.Add(Me.dllNomCta)
        Me.grbDatosCliente.Controls.Add(Me.txNumCta)
        Me.grbDatosCliente.Controls.Add(Me.Label3)
        Me.grbDatosCliente.Controls.Add(Me.Label2)
        Me.grbDatosCliente.Controls.Add(Me.Label1)
        Me.grbDatosCliente.Location = New System.Drawing.Point(9, 17)
        Me.grbDatosCliente.Name = "grbDatosCliente"
        Me.grbDatosCliente.Size = New System.Drawing.Size(805, 75)
        Me.grbDatosCliente.TabIndex = 0
        Me.grbDatosCliente.TabStop = False
        '
        'txFechaSolicitud
        '
        Me.txFechaSolicitud.Enabled = False
        Me.txFechaSolicitud.Location = New System.Drawing.Point(712, 17)
        Me.txFechaSolicitud.Name = "txFechaSolicitud"
        Me.txFechaSolicitud.Size = New System.Drawing.Size(79, 21)
        Me.txFechaSolicitud.TabIndex = 4
        '
        'dllNomCta
        '
        Me.dllNomCta.FormattingEnabled = True
        Me.dllNomCta.Location = New System.Drawing.Point(121, 44)
        Me.dllNomCta.Name = "dllNomCta"
        Me.dllNomCta.Size = New System.Drawing.Size(390, 21)
        Me.dllNomCta.TabIndex = 2
        '
        'txNumCta
        '
        Me.txNumCta.Location = New System.Drawing.Point(121, 17)
        Me.txNumCta.Name = "txNumCta"
        Me.txNumCta.Size = New System.Drawing.Size(80, 21)
        Me.txNumCta.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(596, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha de Solicitud"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre del Cliente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Número de Cuenta"
        '
        'grbDatosCuenta
        '
        Me.grbDatosCuenta.Controls.Add(Me.dllSucCta)
        Me.grbDatosCuenta.Controls.Add(Me.txCRCta)
        Me.grbDatosCuenta.Controls.Add(Me.txCtaEjePesos)
        Me.grbDatosCuenta.Controls.Add(Me.txNumSucCta)
        Me.grbDatosCuenta.Controls.Add(Me.txNumCRCta)
        Me.grbDatosCuenta.Controls.Add(Me.txGestorPesos)
        Me.grbDatosCuenta.Controls.Add(Me.Label7)
        Me.grbDatosCuenta.Controls.Add(Me.Label6)
        Me.grbDatosCuenta.Controls.Add(Me.Label5)
        Me.grbDatosCuenta.Controls.Add(Me.Label4)
        Me.grbDatosCuenta.Location = New System.Drawing.Point(8, 111)
        Me.grbDatosCuenta.Name = "grbDatosCuenta"
        Me.grbDatosCuenta.Size = New System.Drawing.Size(533, 155)
        Me.grbDatosCuenta.TabIndex = 1
        Me.grbDatosCuenta.TabStop = False
        Me.grbDatosCuenta.Text = "Datos de la Cuenta (Envío)"
        '
        'dllSucCta
        '
        Me.dllSucCta.FormattingEnabled = True
        Me.dllSucCta.Location = New System.Drawing.Point(210, 81)
        Me.dllSucCta.Name = "dllSucCta"
        Me.dllSucCta.Size = New System.Drawing.Size(306, 21)
        Me.dllSucCta.TabIndex = 7
        '
        'txCRCta
        '
        Me.txCRCta.Location = New System.Drawing.Point(210, 54)
        Me.txCRCta.Name = "txCRCta"
        Me.txCRCta.Size = New System.Drawing.Size(306, 21)
        Me.txCRCta.TabIndex = 5
        '
        'txCtaEjePesos
        '
        Me.txCtaEjePesos.Location = New System.Drawing.Point(122, 109)
        Me.txCtaEjePesos.Name = "txCtaEjePesos"
        Me.txCtaEjePesos.Size = New System.Drawing.Size(79, 21)
        Me.txCtaEjePesos.TabIndex = 8
        '
        'txNumSucCta
        '
        Me.txNumSucCta.Location = New System.Drawing.Point(122, 81)
        Me.txNumSucCta.Name = "txNumSucCta"
        Me.txNumSucCta.Size = New System.Drawing.Size(79, 21)
        Me.txNumSucCta.TabIndex = 6
        '
        'txNumCRCta
        '
        Me.txNumCRCta.Location = New System.Drawing.Point(122, 54)
        Me.txNumCRCta.Name = "txNumCRCta"
        Me.txNumCRCta.Size = New System.Drawing.Size(79, 21)
        Me.txNumCRCta.TabIndex = 4
        '
        'txGestorPesos
        '
        Me.txGestorPesos.Location = New System.Drawing.Point(122, 28)
        Me.txGestorPesos.Name = "txGestorPesos"
        Me.txGestorPesos.Size = New System.Drawing.Size(79, 21)
        Me.txGestorPesos.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Cuenta Eje Pesos"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(59, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Sucursal"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(80, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "DAR"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Gestor Eje Pesos"
        '
        'grbNoEspeciales
        '
        Me.grbNoEspeciales.Controls.Add(Me.txMotivoError)
        Me.grbNoEspeciales.Controls.Add(Me.lbMotivoError)
        Me.grbNoEspeciales.Controls.Add(Me.dllNumCheques)
        Me.grbNoEspeciales.Controls.Add(Me.dllSucursal)
        Me.grbNoEspeciales.Controls.Add(Me.txCR)
        Me.grbNoEspeciales.Controls.Add(Me.txNomGestor)
        Me.grbNoEspeciales.Controls.Add(Me.txNumSucursal)
        Me.grbNoEspeciales.Controls.Add(Me.txNumCR)
        Me.grbNoEspeciales.Controls.Add(Me.btSolError)
        Me.grbNoEspeciales.Controls.Add(Me.txNumGestor)
        Me.grbNoEspeciales.Controls.Add(Me.Label11)
        Me.grbNoEspeciales.Controls.Add(Me.Label10)
        Me.grbNoEspeciales.Controls.Add(Me.Label9)
        Me.grbNoEspeciales.Controls.Add(Me.Label8)
        Me.grbNoEspeciales.Controls.Add(Me.btCancelar)
        Me.grbNoEspeciales.Location = New System.Drawing.Point(7, 272)
        Me.grbNoEspeciales.Name = "grbNoEspeciales"
        Me.grbNoEspeciales.Size = New System.Drawing.Size(534, 172)
        Me.grbNoEspeciales.TabIndex = 13
        Me.grbNoEspeciales.TabStop = False
        Me.grbNoEspeciales.Text = "Datos del Solicitante"
        '
        'txMotivoError
        '
        Me.txMotivoError.Location = New System.Drawing.Point(123, 141)
        Me.txMotivoError.Name = "txMotivoError"
        Me.txMotivoError.Size = New System.Drawing.Size(392, 21)
        Me.txMotivoError.TabIndex = 10
        Me.txMotivoError.Visible = False
        '
        'lbMotivoError
        '
        Me.lbMotivoError.Enabled = False
        Me.lbMotivoError.Location = New System.Drawing.Point(13, 141)
        Me.lbMotivoError.Name = "lbMotivoError"
        Me.lbMotivoError.Size = New System.Drawing.Size(100, 21)
        Me.lbMotivoError.TabIndex = 4
        Me.lbMotivoError.Text = "Motivo de Error:"
        Me.lbMotivoError.Visible = False
        '
        'dllNumCheques
        '
        Me.dllNumCheques.FormattingEnabled = True
        Me.dllNumCheques.Location = New System.Drawing.Point(122, 104)
        Me.dllNumCheques.Name = "dllNumCheques"
        Me.dllNumCheques.Size = New System.Drawing.Size(79, 21)
        Me.dllNumCheques.TabIndex = 15
        '
        'dllSucursal
        '
        Me.dllSucursal.FormattingEnabled = True
        Me.dllSucursal.Location = New System.Drawing.Point(211, 76)
        Me.dllSucursal.Name = "dllSucursal"
        Me.dllSucursal.Size = New System.Drawing.Size(306, 21)
        Me.dllSucursal.TabIndex = 14
        '
        'txCR
        '
        Me.txCR.Location = New System.Drawing.Point(210, 51)
        Me.txCR.Name = "txCR"
        Me.txCR.Size = New System.Drawing.Size(306, 21)
        Me.txCR.TabIndex = 12
        '
        'txNomGestor
        '
        Me.txNomGestor.Location = New System.Drawing.Point(210, 25)
        Me.txNomGestor.Name = "txNomGestor"
        Me.txNomGestor.Size = New System.Drawing.Size(306, 21)
        Me.txNomGestor.TabIndex = 10
        '
        'txNumSucursal
        '
        Me.txNumSucursal.Location = New System.Drawing.Point(122, 77)
        Me.txNumSucursal.Name = "txNumSucursal"
        Me.txNumSucursal.Size = New System.Drawing.Size(79, 21)
        Me.txNumSucursal.TabIndex = 13
        '
        'txNumCR
        '
        Me.txNumCR.Location = New System.Drawing.Point(122, 51)
        Me.txNumCR.Name = "txNumCR"
        Me.txNumCR.Size = New System.Drawing.Size(79, 21)
        Me.txNumCR.TabIndex = 11
        '
        'btSolError
        '
        Me.btSolError.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSolError.Location = New System.Drawing.Point(379, 104)
        Me.btSolError.Name = "btSolError"
        Me.btSolError.Size = New System.Drawing.Size(119, 27)
        Me.btSolError.TabIndex = 14
        Me.btSolError.Text = "Solicitud Errónea"
        Me.btSolError.UseVisualStyleBackColor = True
        '
        'txNumGestor
        '
        Me.txNumGestor.Location = New System.Drawing.Point(122, 24)
        Me.txNumGestor.Name = "txNumGestor"
        Me.txNumGestor.Size = New System.Drawing.Size(79, 21)
        Me.txNumGestor.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(23, 108)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "N° de Cheques"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(59, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Sucursal"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(80, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "DAR"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(71, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Gestor"
        '
        'btCancelar
        '
        Me.btCancelar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCancelar.Location = New System.Drawing.Point(253, 104)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(119, 27)
        Me.btCancelar.TabIndex = 13
        Me.btCancelar.Text = " Cancelar Error"
        Me.btCancelar.UseVisualStyleBackColor = True
        Me.btCancelar.Visible = False
        '
        'grbResultados
        '
        Me.grbResultados.Controls.Add(Me.lblFolioFin)
        Me.grbResultados.Controls.Add(Me.lblFolioIni)
        Me.grbResultados.Controls.Add(Me.lblRegistro)
        Me.grbResultados.Controls.Add(Me.Label14)
        Me.grbResultados.Controls.Add(Me.Label13)
        Me.grbResultados.Controls.Add(Me.Label12)
        Me.grbResultados.Location = New System.Drawing.Point(548, 111)
        Me.grbResultados.Name = "grbResultados"
        Me.grbResultados.Size = New System.Drawing.Size(266, 155)
        Me.grbResultados.TabIndex = 2
        Me.grbResultados.TabStop = False
        Me.grbResultados.Text = "Resultados de la Solicitud"
        '
        'lblFolioFin
        '
        Me.lblFolioFin.Enabled = False
        Me.lblFolioFin.Location = New System.Drawing.Point(173, 84)
        Me.lblFolioFin.Name = "lblFolioFin"
        Me.lblFolioFin.Size = New System.Drawing.Size(79, 21)
        Me.lblFolioFin.TabIndex = 5
        '
        'lblFolioIni
        '
        Me.lblFolioIni.Enabled = False
        Me.lblFolioIni.Location = New System.Drawing.Point(173, 54)
        Me.lblFolioIni.Name = "lblFolioIni"
        Me.lblFolioIni.Size = New System.Drawing.Size(79, 21)
        Me.lblFolioIni.TabIndex = 4
        '
        'lblRegistro
        '
        Me.lblRegistro.Enabled = False
        Me.lblRegistro.Location = New System.Drawing.Point(173, 24)
        Me.lblRegistro.Name = "lblRegistro"
        Me.lblRegistro.Size = New System.Drawing.Size(79, 21)
        Me.lblRegistro.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 84)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(161, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Folio Final (Último Cheque)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(99, 57)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Folio Inicial"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(43, 31)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(127, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Número de Registros"
        '
        'btAceptar
        '
        Me.btAceptar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAceptar.Location = New System.Drawing.Point(617, 301)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(119, 27)
        Me.btAceptar.TabIndex = 4
        Me.btAceptar.Text = "&Aceptar"
        Me.btAceptar.UseVisualStyleBackColor = True
        '
        'btLimpiar
        '
        Me.btLimpiar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btLimpiar.Location = New System.Drawing.Point(617, 344)
        Me.btLimpiar.Name = "btLimpiar"
        Me.btLimpiar.Size = New System.Drawing.Size(119, 27)
        Me.btLimpiar.TabIndex = 5
        Me.btLimpiar.Text = "&Limpiar"
        Me.btLimpiar.UseVisualStyleBackColor = True
        '
        'btCerrar
        '
        Me.btCerrar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCerrar.Location = New System.Drawing.Point(617, 384)
        Me.btCerrar.Name = "btCerrar"
        Me.btCerrar.Size = New System.Drawing.Size(119, 27)
        Me.btCerrar.TabIndex = 6
        Me.btCerrar.Text = "&Cerrar"
        Me.btCerrar.UseVisualStyleBackColor = True
        '
        'frmSolicitudChequeraNormal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(822, 454)
        Me.Controls.Add(Me.grbNoEspeciales)
        Me.Controls.Add(Me.btCerrar)
        Me.Controls.Add(Me.btLimpiar)
        Me.Controls.Add(Me.btAceptar)
        Me.Controls.Add(Me.grbResultados)
        Me.Controls.Add(Me.grbDatosCuenta)
        Me.Controls.Add(Me.grbDatosCliente)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSolicitudChequeraNormal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud de Chequeras"
        Me.grbDatosCliente.ResumeLayout(False)
        Me.grbDatosCliente.PerformLayout()
        Me.grbDatosCuenta.ResumeLayout(False)
        Me.grbDatosCuenta.PerformLayout()
        Me.grbNoEspeciales.ResumeLayout(False)
        Me.grbNoEspeciales.PerformLayout()
        Me.grbResultados.ResumeLayout(False)
        Me.grbResultados.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grbDatosCliente As GroupBox
    Friend WithEvents grbDatosCuenta As GroupBox
    Friend WithEvents grbResultados As GroupBox
    Friend WithEvents btAceptar As Button
    Friend WithEvents btLimpiar As Button
    Friend WithEvents btCerrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txNumCta As TextBox
    Friend WithEvents txGestorPesos As TextBox
    Friend WithEvents txCRCta As TextBox
    Friend WithEvents txCtaEjePesos As TextBox
    Friend WithEvents txNumSucCta As TextBox
    Friend WithEvents dllSucCta As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents dllSucursal As ComboBox
    Friend WithEvents txMotivoError As TextBox
    Friend WithEvents txCR As TextBox
    Friend WithEvents txNomGestor As TextBox
    Friend WithEvents txNumSucursal As TextBox
    Friend WithEvents txNumCR As TextBox
    Friend WithEvents txNumGestor As TextBox
    Friend WithEvents lbMotivoError As TextBox
    Friend WithEvents dllNumCheques As ComboBox
    Friend WithEvents lblFolioFin As TextBox
    Friend WithEvents lblFolioIni As TextBox
    Friend WithEvents lblRegistro As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btSolError As Button
    Friend WithEvents btCancelar As Button
    Friend WithEvents grbNoEspeciales As GroupBox
    Friend WithEvents dllNomCta As ComboBox
    Friend WithEvents txFechaSolicitud As TextBox
    Friend WithEvents txNumCRCta As TextBox
End Class
