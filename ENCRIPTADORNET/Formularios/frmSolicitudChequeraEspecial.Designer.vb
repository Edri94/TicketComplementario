<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSolicitudChequeraEspecial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSolicitudChequeraEspecial))
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
        Me.btSolError = New System.Windows.Forms.Button()
        Me.btCancelar = New System.Windows.Forms.Button()
        Me.grbResultados = New System.Windows.Forms.GroupBox()
        Me.lblFolioFin = New System.Windows.Forms.TextBox()
        Me.lblFolioIni = New System.Windows.Forms.TextBox()
        Me.lblRegistro = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.grbEspeciales = New System.Windows.Forms.GroupBox()
        Me.grbReporte = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btImprimir = New System.Windows.Forms.Button()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.txMotivoError = New System.Windows.Forms.TextBox()
        Me.lbMotivoError = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txNumCheques = New System.Windows.Forms.TextBox()
        Me.btAceptar = New System.Windows.Forms.Button()
        Me.btLimpiar = New System.Windows.Forms.Button()
        Me.btCerrar = New System.Windows.Forms.Button()
        Me.grbDatosCliente.SuspendLayout()
        Me.grbDatosCuenta.SuspendLayout()
        Me.grbResultados.SuspendLayout()
        Me.grbEspeciales.SuspendLayout()
        Me.grbReporte.SuspendLayout()
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
        Me.txFechaSolicitud.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txFechaSolicitud.Location = New System.Drawing.Point(713, 19)
        Me.txFechaSolicitud.Name = "txFechaSolicitud"
        Me.txFechaSolicitud.Size = New System.Drawing.Size(79, 21)
        Me.txFechaSolicitud.TabIndex = 4
        '
        'dllNomCta
        '
        Me.dllNomCta.FormattingEnabled = True
        Me.dllNomCta.Location = New System.Drawing.Point(121, 43)
        Me.dllNomCta.Name = "dllNomCta"
        Me.dllNomCta.Size = New System.Drawing.Size(390, 21)
        Me.dllNomCta.TabIndex = 2
        '
        'txNumCta
        '
        Me.txNumCta.Location = New System.Drawing.Point(121, 16)
        Me.txNumCta.Name = "txNumCta"
        Me.txNumCta.Size = New System.Drawing.Size(80, 21)
        Me.txNumCta.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(598, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha de Solicitud"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre del Cliente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 20)
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
        Me.grbDatosCuenta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Cuenta Eje Pesos"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(59, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Sucursal"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(80, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "DAR"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Gestor Eje Pesos"
        '
        'btSolError
        '
        Me.btSolError.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSolError.Location = New System.Drawing.Point(397, 125)
        Me.btSolError.Name = "btSolError"
        Me.btSolError.Size = New System.Drawing.Size(119, 27)
        Me.btSolError.TabIndex = 14
        Me.btSolError.Text = "Solicitud Errónea"
        Me.btSolError.UseVisualStyleBackColor = True
        '
        'btCancelar
        '
        Me.btCancelar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCancelar.Location = New System.Drawing.Point(254, 125)
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
        Me.grbResultados.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbResultados.Location = New System.Drawing.Point(549, 111)
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
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(10, 84)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(161, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Folio Final (Último Cheque)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(96, 57)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Folio Inicial"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(41, 31)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(127, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Número de Registros"
        '
        'grbEspeciales
        '
        Me.grbEspeciales.BackColor = System.Drawing.Color.Transparent
        Me.grbEspeciales.Controls.Add(Me.grbReporte)
        Me.grbEspeciales.Controls.Add(Me.txMotivoError)
        Me.grbEspeciales.Controls.Add(Me.lbMotivoError)
        Me.grbEspeciales.Controls.Add(Me.Label17)
        Me.grbEspeciales.Controls.Add(Me.txNumCheques)
        Me.grbEspeciales.Controls.Add(Me.btSolError)
        Me.grbEspeciales.Controls.Add(Me.btCancelar)
        Me.grbEspeciales.Location = New System.Drawing.Point(8, 272)
        Me.grbEspeciales.Name = "grbEspeciales"
        Me.grbEspeciales.Size = New System.Drawing.Size(533, 198)
        Me.grbEspeciales.TabIndex = 3
        Me.grbEspeciales.TabStop = False
        '
        'grbReporte
        '
        Me.grbReporte.BackColor = System.Drawing.Color.Transparent
        Me.grbReporte.Controls.Add(Me.Label16)
        Me.grbReporte.Controls.Add(Me.Label15)
        Me.grbReporte.Controls.Add(Me.btImprimir)
        Me.grbReporte.Controls.Add(Me.dtpFechaFin)
        Me.grbReporte.Controls.Add(Me.dtpFechaIni)
        Me.grbReporte.Location = New System.Drawing.Point(254, 6)
        Me.grbReporte.Name = "grbReporte"
        Me.grbReporte.Size = New System.Drawing.Size(262, 113)
        Me.grbReporte.TabIndex = 7
        Me.grbReporte.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(80, 47)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(38, 13)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "hasta"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(105, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Envios con Fecha"
        '
        'btImprimir
        '
        Me.btImprimir.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btImprimir.Location = New System.Drawing.Point(80, 71)
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Size = New System.Drawing.Size(119, 27)
        Me.btImprimir.TabIndex = 0
        Me.btImprimir.Text = "&Imprimir"
        Me.btImprimir.UseVisualStyleBackColor = True
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(139, 45)
        Me.dtpFechaFin.MaxDate = New Date(2030, 12, 31, 0, 0, 0, 0)
        Me.dtpFechaFin.MinDate = New Date(2015, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(114, 21)
        Me.dtpFechaFin.TabIndex = 4
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIni.Location = New System.Drawing.Point(139, 19)
        Me.dtpFechaIni.MaxDate = New Date(2030, 12, 31, 0, 0, 0, 0)
        Me.dtpFechaIni.MinDate = New Date(2015, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(114, 21)
        Me.dtpFechaIni.TabIndex = 3
        '
        'txMotivoError
        '
        Me.txMotivoError.Location = New System.Drawing.Point(121, 167)
        Me.txMotivoError.Name = "txMotivoError"
        Me.txMotivoError.Size = New System.Drawing.Size(392, 21)
        Me.txMotivoError.TabIndex = 10
        Me.txMotivoError.Visible = False
        '
        'lbMotivoError
        '
        Me.lbMotivoError.Enabled = False
        Me.lbMotivoError.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMotivoError.Location = New System.Drawing.Point(16, 167)
        Me.lbMotivoError.Name = "lbMotivoError"
        Me.lbMotivoError.Size = New System.Drawing.Size(96, 21)
        Me.lbMotivoError.TabIndex = 4
        Me.lbMotivoError.Text = "Motivo de Error:"
        Me.lbMotivoError.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(23, 24)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(93, 13)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "N° de Cheques"
        '
        'txNumCheques
        '
        Me.txNumCheques.Location = New System.Drawing.Point(122, 24)
        Me.txNumCheques.Name = "txNumCheques"
        Me.txNumCheques.Size = New System.Drawing.Size(79, 21)
        Me.txNumCheques.TabIndex = 15
        '
        'btAceptar
        '
        Me.btAceptar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAceptar.Location = New System.Drawing.Point(624, 314)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(119, 27)
        Me.btAceptar.TabIndex = 4
        Me.btAceptar.Text = "&Aceptar"
        Me.btAceptar.UseVisualStyleBackColor = True
        '
        'btLimpiar
        '
        Me.btLimpiar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btLimpiar.Location = New System.Drawing.Point(624, 355)
        Me.btLimpiar.Name = "btLimpiar"
        Me.btLimpiar.Size = New System.Drawing.Size(119, 27)
        Me.btLimpiar.TabIndex = 5
        Me.btLimpiar.Text = "&Limpiar"
        Me.btLimpiar.UseVisualStyleBackColor = True
        '
        'btCerrar
        '
        Me.btCerrar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCerrar.Location = New System.Drawing.Point(624, 398)
        Me.btCerrar.Name = "btCerrar"
        Me.btCerrar.Size = New System.Drawing.Size(119, 27)
        Me.btCerrar.TabIndex = 6
        Me.btCerrar.Text = "&Cerrar"
        Me.btCerrar.UseVisualStyleBackColor = True
        '
        'frmSolicitudChequeraEspecial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(825, 475)
        Me.Controls.Add(Me.btCerrar)
        Me.Controls.Add(Me.btLimpiar)
        Me.Controls.Add(Me.btAceptar)
        Me.Controls.Add(Me.grbResultados)
        Me.Controls.Add(Me.grbDatosCuenta)
        Me.Controls.Add(Me.grbDatosCliente)
        Me.Controls.Add(Me.grbEspeciales)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSolicitudChequeraEspecial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud de Chequeras"
        Me.grbDatosCliente.ResumeLayout(False)
        Me.grbDatosCliente.PerformLayout()
        Me.grbDatosCuenta.ResumeLayout(False)
        Me.grbDatosCuenta.PerformLayout()
        Me.grbResultados.ResumeLayout(False)
        Me.grbResultados.PerformLayout()
        Me.grbEspeciales.ResumeLayout(False)
        Me.grbEspeciales.PerformLayout()
        Me.grbReporte.ResumeLayout(False)
        Me.grbReporte.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grbDatosCliente As GroupBox
    Friend WithEvents grbDatosCuenta As GroupBox
    Friend WithEvents grbResultados As GroupBox
    Friend WithEvents grbEspeciales As GroupBox
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
    Friend WithEvents txNumCRCta As TextBox
    Friend WithEvents dllSucCta As ComboBox
    Friend WithEvents lblFolioFin As TextBox
    Friend WithEvents lblFolioIni As TextBox
    Friend WithEvents lblRegistro As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btSolError As Button
    Friend WithEvents btCancelar As Button
    Friend WithEvents grbReporte As GroupBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents btImprimir As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents dllNomCta As ComboBox
    Friend WithEvents txNumCheques As TextBox
    Friend WithEvents dtpFechaIni As DateTimePicker
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents txFechaSolicitud As TextBox
    Friend WithEvents txMotivoError As TextBox
    Friend WithEvents lbMotivoError As TextBox
End Class
