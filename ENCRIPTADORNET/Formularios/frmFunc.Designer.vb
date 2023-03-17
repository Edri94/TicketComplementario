<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFunc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFunc))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbFuncs = New System.Windows.Forms.ComboBox()
        Me.txtFuncCte = New System.Windows.Forms.TextBox()
        Me.pnlDatos = New System.Windows.Forms.GroupBox()
        Me.txtUniOrg = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblStatusFunc = New System.Windows.Forms.Label()
        Me.lstSistemas = New System.Windows.Forms.ListBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmdUnidad = New System.Windows.Forms.Button()
        Me.txtUniGes = New System.Windows.Forms.TextBox()
        Me.txtTicketId = New System.Windows.Forms.TextBox()
        Me.cmbSucursal1 = New System.Windows.Forms.ComboBox()
        Me.cmbSucursal = New System.Windows.Forms.ComboBox()
        Me.lblPorGestor = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.chkEstrategico = New System.Windows.Forms.CheckBox()
        Me.chkBBVA = New System.Windows.Forms.CheckBox()
        Me.txtGestorTF = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtNumReg = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCP = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbUbicacion = New System.Windows.Forms.ComboBox()
        Me.lblUnidadOrgB = New System.Windows.Forms.TextBox()
        Me.lblUnidadOrgA = New System.Windows.Forms.TextBox()
        Me.txtNumF = New System.Windows.Forms.TextBox()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.txtColonia = New System.Windows.Forms.TextBox()
        Me.txtCalle = New System.Windows.Forms.TextBox()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.txtApellidoM = New System.Windows.Forms.TextBox()
        Me.txtApellidoP = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdBorrar = New System.Windows.Forms.Button()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdNuevo = New System.Windows.Forms.Button()
        Me.pbProceso = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbFuncs)
        Me.GroupBox1.Controls.Add(Me.txtFuncCte)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1124, 65)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(351, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 22)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nombre:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 22)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nómina s/dig.v:"
        '
        'cmbFuncs
        '
        Me.cmbFuncs.FormattingEnabled = True
        Me.cmbFuncs.Location = New System.Drawing.Point(435, 21)
        Me.cmbFuncs.Name = "cmbFuncs"
        Me.cmbFuncs.Size = New System.Drawing.Size(674, 28)
        Me.cmbFuncs.TabIndex = 1
        '
        'txtFuncCte
        '
        Me.txtFuncCte.Location = New System.Drawing.Point(145, 21)
        Me.txtFuncCte.Name = "txtFuncCte"
        Me.txtFuncCte.Size = New System.Drawing.Size(191, 26)
        Me.txtFuncCte.TabIndex = 0
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.txtUniOrg)
        Me.pnlDatos.Controls.Add(Me.Label21)
        Me.pnlDatos.Controls.Add(Me.lblStatusFunc)
        Me.pnlDatos.Controls.Add(Me.lstSistemas)
        Me.pnlDatos.Controls.Add(Me.Label22)
        Me.pnlDatos.Controls.Add(Me.cmdUnidad)
        Me.pnlDatos.Controls.Add(Me.txtUniGes)
        Me.pnlDatos.Controls.Add(Me.txtTicketId)
        Me.pnlDatos.Controls.Add(Me.cmbSucursal1)
        Me.pnlDatos.Controls.Add(Me.cmbSucursal)
        Me.pnlDatos.Controls.Add(Me.lblPorGestor)
        Me.pnlDatos.Controls.Add(Me.Label20)
        Me.pnlDatos.Controls.Add(Me.Label19)
        Me.pnlDatos.Controls.Add(Me.Label18)
        Me.pnlDatos.Controls.Add(Me.Label17)
        Me.pnlDatos.Controls.Add(Me.chkEstrategico)
        Me.pnlDatos.Controls.Add(Me.chkBBVA)
        Me.pnlDatos.Controls.Add(Me.txtGestorTF)
        Me.pnlDatos.Controls.Add(Me.Label16)
        Me.pnlDatos.Controls.Add(Me.txtNumReg)
        Me.pnlDatos.Controls.Add(Me.Label15)
        Me.pnlDatos.Controls.Add(Me.txtCP)
        Me.pnlDatos.Controls.Add(Me.Label14)
        Me.pnlDatos.Controls.Add(Me.cmbUbicacion)
        Me.pnlDatos.Controls.Add(Me.lblUnidadOrgB)
        Me.pnlDatos.Controls.Add(Me.lblUnidadOrgA)
        Me.pnlDatos.Controls.Add(Me.txtNumF)
        Me.pnlDatos.Controls.Add(Me.txtEstado)
        Me.pnlDatos.Controls.Add(Me.txtColonia)
        Me.pnlDatos.Controls.Add(Me.txtCalle)
        Me.pnlDatos.Controls.Add(Me.txtFax)
        Me.pnlDatos.Controls.Add(Me.txtTelefono)
        Me.pnlDatos.Controls.Add(Me.txtApellidoM)
        Me.pnlDatos.Controls.Add(Me.txtApellidoP)
        Me.pnlDatos.Controls.Add(Me.txtNombre)
        Me.pnlDatos.Controls.Add(Me.Label13)
        Me.pnlDatos.Controls.Add(Me.Label12)
        Me.pnlDatos.Controls.Add(Me.Label11)
        Me.pnlDatos.Controls.Add(Me.Label10)
        Me.pnlDatos.Controls.Add(Me.Label9)
        Me.pnlDatos.Controls.Add(Me.Label8)
        Me.pnlDatos.Controls.Add(Me.Label7)
        Me.pnlDatos.Controls.Add(Me.Label6)
        Me.pnlDatos.Controls.Add(Me.Label5)
        Me.pnlDatos.Controls.Add(Me.Label4)
        Me.pnlDatos.Controls.Add(Me.Label3)
        Me.pnlDatos.Location = New System.Drawing.Point(12, 83)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(1124, 551)
        Me.pnlDatos.TabIndex = 1
        Me.pnlDatos.TabStop = False
        '
        'txtUniOrg
        '
        Me.txtUniOrg.Location = New System.Drawing.Point(1013, 278)
        Me.txtUniOrg.Name = "txtUniOrg"
        Me.txtUniOrg.Size = New System.Drawing.Size(96, 26)
        Me.txtUniOrg.TabIndex = 48
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(821, 279)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(196, 22)
        Me.Label21.TabIndex = 47
        Me.Label21.Text = "Unidad Organizacional:"
        '
        'lblStatusFunc
        '
        Me.lblStatusFunc.AutoSize = True
        Me.lblStatusFunc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusFunc.Location = New System.Drawing.Point(732, 475)
        Me.lblStatusFunc.Name = "lblStatusFunc"
        Me.lblStatusFunc.Size = New System.Drawing.Size(156, 22)
        Me.lblStatusFunc.TabIndex = 46
        Me.lblStatusFunc.Text = "Gestor ANULADO"
        '
        'lstSistemas
        '
        Me.lstSistemas.FormattingEnabled = True
        Me.lstSistemas.ItemHeight = 20
        Me.lstSistemas.Location = New System.Drawing.Point(161, 436)
        Me.lstSistemas.Name = "lstSistemas"
        Me.lstSistemas.Size = New System.Drawing.Size(448, 104)
        Me.lstSistemas.TabIndex = 45
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(157, 411)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(428, 22)
        Me.Label22.TabIndex = 44
        Me.Label22.Text = "Sistemas en donde se encuentra asignado el Gestor"
        '
        'cmdUnidad
        '
        Me.cmdUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUnidad.Location = New System.Drawing.Point(819, 273)
        Me.cmdUnidad.Name = "cmdUnidad"
        Me.cmdUnidad.Size = New System.Drawing.Size(290, 34)
        Me.cmdUnidad.TabIndex = 43
        Me.cmdUnidad.Text = "&Asignar Unidad Organizacional"
        Me.cmdUnidad.UseVisualStyleBackColor = True
        Me.cmdUnidad.Visible = False
        '
        'txtUniGes
        '
        Me.txtUniGes.Location = New System.Drawing.Point(945, 85)
        Me.txtUniGes.Name = "txtUniGes"
        Me.txtUniGes.Size = New System.Drawing.Size(164, 26)
        Me.txtUniGes.TabIndex = 42
        '
        'txtTicketId
        '
        Me.txtTicketId.Location = New System.Drawing.Point(705, 84)
        Me.txtTicketId.Name = "txtTicketId"
        Me.txtTicketId.Size = New System.Drawing.Size(96, 26)
        Me.txtTicketId.TabIndex = 41
        '
        'cmbSucursal1
        '
        Me.cmbSucursal1.FormattingEnabled = True
        Me.cmbSucursal1.Location = New System.Drawing.Point(627, 240)
        Me.cmbSucursal1.Name = "cmbSucursal1"
        Me.cmbSucursal1.Size = New System.Drawing.Size(482, 28)
        Me.cmbSucursal1.TabIndex = 40
        '
        'cmbSucursal
        '
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Location = New System.Drawing.Point(626, 178)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(483, 28)
        Me.cmbSucursal.TabIndex = 39
        '
        'lblPorGestor
        '
        Me.lblPorGestor.AutoSize = True
        Me.lblPorGestor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorGestor.Location = New System.Drawing.Point(623, 212)
        Me.lblPorGestor.Name = "lblPorGestor"
        Me.lblPorGestor.Size = New System.Drawing.Size(177, 22)
        Me.lblPorGestor.TabIndex = 38
        Me.lblPorGestor.Text = "Por Terminal Gestor:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(623, 152)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(118, 22)
        Me.Label20.TabIndex = 37
        Me.Label20.Text = "Por Sucursal:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(623, 119)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(325, 22)
        Me.Label19.TabIndex = 36
        Me.Label19.Text = "Centro Responsable de Contabilización"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(807, 85)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(141, 22)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Unidad Gestora:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(623, 85)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(83, 22)
        Me.Label17.TabIndex = 34
        Me.Label17.Text = "Ticket Id:"
        '
        'chkEstrategico
        '
        Me.chkEstrategico.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkEstrategico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEstrategico.Location = New System.Drawing.Point(870, 22)
        Me.chkEstrategico.Name = "chkEstrategico"
        Me.chkEstrategico.Size = New System.Drawing.Size(239, 57)
        Me.chkEstrategico.TabIndex = 33
        Me.chkEstrategico.Text = "Gestor Estratégico"
        Me.chkEstrategico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkEstrategico.UseVisualStyleBackColor = True
        '
        'chkBBVA
        '
        Me.chkBBVA.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkBBVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBBVA.Location = New System.Drawing.Point(627, 21)
        Me.chkBBVA.Name = "chkBBVA"
        Me.chkBBVA.Size = New System.Drawing.Size(216, 57)
        Me.chkBBVA.TabIndex = 32
        Me.chkBBVA.Text = "Gestor de BBVA"
        Me.chkBBVA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkBBVA.UseVisualStyleBackColor = True
        '
        'txtGestorTF
        '
        Me.txtGestorTF.Location = New System.Drawing.Point(727, 278)
        Me.txtGestorTF.Name = "txtGestorTF"
        Me.txtGestorTF.Size = New System.Drawing.Size(89, 26)
        Me.txtGestorTF.TabIndex = 31
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(623, 279)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(107, 22)
        Me.Label16.TabIndex = 30
        Me.Label16.Text = "Usuario PU:"
        '
        'txtNumReg
        '
        Me.txtNumReg.Location = New System.Drawing.Point(461, 278)
        Me.txtNumReg.Name = "txtNumReg"
        Me.txtNumReg.Size = New System.Drawing.Size(148, 26)
        Me.txtNumReg.TabIndex = 29
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(302, 282)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(153, 22)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Nómina completa:"
        '
        'txtCP
        '
        Me.txtCP.Location = New System.Drawing.Point(461, 116)
        Me.txtCP.Name = "txtCP"
        Me.txtCP.Size = New System.Drawing.Size(148, 26)
        Me.txtCP.TabIndex = 27
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(405, 120)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 22)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "C.P.:"
        '
        'cmbUbicacion
        '
        Me.cmbUbicacion.FormattingEnabled = True
        Me.cmbUbicacion.Location = New System.Drawing.Point(161, 242)
        Me.cmbUbicacion.Name = "cmbUbicacion"
        Me.cmbUbicacion.Size = New System.Drawing.Size(230, 28)
        Me.cmbUbicacion.TabIndex = 4
        '
        'lblUnidadOrgB
        '
        Me.lblUnidadOrgB.Enabled = False
        Me.lblUnidadOrgB.Location = New System.Drawing.Point(161, 363)
        Me.lblUnidadOrgB.Name = "lblUnidadOrgB"
        Me.lblUnidadOrgB.Size = New System.Drawing.Size(948, 26)
        Me.lblUnidadOrgB.TabIndex = 25
        '
        'lblUnidadOrgA
        '
        Me.lblUnidadOrgA.Enabled = False
        Me.lblUnidadOrgA.Location = New System.Drawing.Point(161, 319)
        Me.lblUnidadOrgA.Name = "lblUnidadOrgA"
        Me.lblUnidadOrgA.Size = New System.Drawing.Size(948, 26)
        Me.lblUnidadOrgA.TabIndex = 24
        '
        'txtNumF
        '
        Me.txtNumF.Location = New System.Drawing.Point(161, 278)
        Me.txtNumF.Name = "txtNumF"
        Me.txtNumF.Size = New System.Drawing.Size(135, 26)
        Me.txtNumF.TabIndex = 23
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(409, 242)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(200, 26)
        Me.txtEstado.TabIndex = 22
        '
        'txtColonia
        '
        Me.txtColonia.Location = New System.Drawing.Point(161, 212)
        Me.txtColonia.Name = "txtColonia"
        Me.txtColonia.Size = New System.Drawing.Size(448, 26)
        Me.txtColonia.TabIndex = 21
        '
        'txtCalle
        '
        Me.txtCalle.Location = New System.Drawing.Point(161, 180)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(448, 26)
        Me.txtCalle.TabIndex = 20
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(161, 148)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(188, 26)
        Me.txtFax.TabIndex = 19
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(161, 116)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(188, 26)
        Me.txtTelefono.TabIndex = 18
        '
        'txtApellidoM
        '
        Me.txtApellidoM.Location = New System.Drawing.Point(161, 84)
        Me.txtApellidoM.Name = "txtApellidoM"
        Me.txtApellidoM.Size = New System.Drawing.Size(448, 26)
        Me.txtApellidoM.TabIndex = 17
        '
        'txtApellidoP
        '
        Me.txtApellidoP.Location = New System.Drawing.Point(161, 52)
        Me.txtApellidoP.Name = "txtApellidoP"
        Me.txtApellidoP.Size = New System.Drawing.Size(448, 26)
        Me.txtApellidoP.TabIndex = 16
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(161, 21)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(448, 26)
        Me.txtNombre.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 56)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(147, 22)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Apellido Paterno:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(149, 22)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Apellido Materno:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 120)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 22)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Teléfono 1:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 152)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 22)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Teléfono 2:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 184)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 22)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Calle:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 216)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 22)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Colonia:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 248)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 22)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Ubicación:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 282)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(133, 22)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Nómina s/dig.v:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 320)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 22)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Unidad Org.:"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 354)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 47)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Unidad Org. Anterior:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 22)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nombre(s):"
        '
        'cmdBorrar
        '
        Me.cmdBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBorrar.Location = New System.Drawing.Point(678, 653)
        Me.cmdBorrar.Name = "cmdBorrar"
        Me.cmdBorrar.Size = New System.Drawing.Size(123, 47)
        Me.cmdBorrar.TabIndex = 2
        Me.cmdBorrar.Text = "&Anular"
        Me.cmdBorrar.UseVisualStyleBackColor = True
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardar.Location = New System.Drawing.Point(826, 653)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(123, 47)
        Me.cmdGuardar.TabIndex = 3
        Me.cmdGuardar.Text = "&Guardar"
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalir.Location = New System.Drawing.Point(979, 653)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(123, 47)
        Me.cmdSalir.TabIndex = 4
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNuevo.Location = New System.Drawing.Point(473, 653)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(182, 47)
        Me.cmdNuevo.TabIndex = 5
        Me.cmdNuevo.Text = "&Nueva busqueda"
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'pbProceso
        '
        Me.pbProceso.Location = New System.Drawing.Point(22, 653)
        Me.pbProceso.Name = "pbProceso"
        Me.pbProceso.Size = New System.Drawing.Size(419, 47)
        Me.pbProceso.TabIndex = 49
        '
        'frmFunc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1148, 724)
        Me.Controls.Add(Me.pbProceso)
        Me.Controls.Add(Me.cmdNuevo)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.cmdBorrar)
        Me.Controls.Add(Me.pnlDatos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFunc"
        Me.Text = "Gestores"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbFuncs As ComboBox
    Friend WithEvents txtFuncCte As TextBox
    Friend WithEvents pnlDatos As GroupBox
    Friend WithEvents lblStatusFunc As Label
    Friend WithEvents lstSistemas As ListBox
    Friend WithEvents Label22 As Label
    Friend WithEvents cmdUnidad As Button
    Friend WithEvents txtUniGes As TextBox
    Friend WithEvents txtTicketId As TextBox
    Friend WithEvents cmbSucursal1 As ComboBox
    Friend WithEvents cmbSucursal As ComboBox
    Friend WithEvents lblPorGestor As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents chkEstrategico As CheckBox
    Friend WithEvents chkBBVA As CheckBox
    Friend WithEvents txtGestorTF As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtNumReg As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtCP As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbUbicacion As ComboBox
    Friend WithEvents lblUnidadOrgB As TextBox
    Friend WithEvents lblUnidadOrgA As TextBox
    Friend WithEvents txtNumF As TextBox
    Friend WithEvents txtEstado As TextBox
    Friend WithEvents txtColonia As TextBox
    Friend WithEvents txtCalle As TextBox
    Friend WithEvents txtFax As TextBox
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents txtApellidoM As TextBox
    Friend WithEvents txtApellidoP As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmdBorrar As Button
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents cmdSalir As Button
    Friend WithEvents txtUniOrg As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents cmdNuevo As Button
    Friend WithEvents pbProceso As ProgressBar
End Class
