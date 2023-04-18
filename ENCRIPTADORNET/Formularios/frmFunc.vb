Public Class frmFunc
    Private gsSql As String
    Private objDatasource As New Datasource
    Private dtRespConsulta As New DataTable
    Private lLibreria As New Libreria
    Public mnModo As Byte
    Private mnFunc As Double
    Private mnUnidadAnt As Integer
    Private mnUnidadAct As Integer
    Private mo_PrevWindow As Form
    Private mnKeyState As Integer
    Private mnEstrategico As Byte
    Private mbHabilita As Boolean
    Private bSuc As Boolean
    Private strPapelera As String
    Public Ms_UnidadOrgAnulada As String
    Private msNumeroFuncionario As String
    Private msUnidadOrgBancomer As String
    Private mnUnidadOrganizacional As Integer
    Private gnUnidadOrg As Integer    'Numero de unidad organizacional en trabajo
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hWnd As Long, ByVal wMsg As Long, ByVal wParam As Long, lParam As Long) As Long

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir de Gestores") <> vbYes Then
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub
    Private Sub frmFunc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'lblStatusFunc.FontBold = True
        lblStatusFunc.Font = New Font(lblStatusFunc.Font, FontStyle.Bold)
        'Aparencia de colores
        'CargarColores Me, cambio
        'cambiarLabels lblStatusFunc
        'cambiarLabels lblUnidadOrgB
        'cambiarLabels lblUnidadOrgA
        lblUnidadOrgA.Refresh()
        lblUnidadOrgB.Refresh()
        'lblUnidadOrgA.Locked = True 'MERD Softtek para visualizar toda la ruta
        'lblUnidadOrgB.Locked = True
        'lblUnidadOrgA.Enabled = True 'MERD Softtek para visualizar toda la ruta
        'lblUnidadOrgB.Enabled = True

        '    Centerform Me
        'ShowWaitCursor
        mbHabilita = True
        gsSql = "Select ubicacion, descripcion_ubicacion from FUNCIONARIOS..UBICACION WITH (NOLOCK) "
        gsSql = gsSql & "where descripcion_ubicacion like 'DESCONO%' and tipo_ubicacion=4"
        'dbExecQuery gsSql
        'dbGetRecord
        'dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
        'If dbError = 0 Then
        'cmbUbicacion.AddItem Trim(dbGetValue(1))
        'cmbUbicacion.ItemData(cmbUbicacion.NewIndex) = Val(dbGetValue(0))
        'End If
        'dbEndQuery
        gsSql = "Select ubicacion, descripcion_ubicacion from FUNCIONARIOS..UBICACION WITH (NOLOCK) "
        gsSql = gsSql & "where tipo_ubicacion=4 "
        gsSql = gsSql & "order by descripcion_ubicacion"
        'dbExecQuery gsSql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
        cmbUbicacion.ValueMember = "ubicacion"
        cmbUbicacion.DisplayMember = "descripcion_ubicacion"
        cmbUbicacion.DataSource = dtRespConsulta
        cmbUbicacion.SelectedIndex = 0
        'Do While dbError = 0
        'cmbUbicacion.AddItem Trim(dbGetValue(1))
        'cmbUbicacion.ItemData(cmbUbicacion.NewIndex) = Val(dbGetValue(0))
        'dbGetRecord
        'Loop
        'dbEndQuery
        'If cmbUbicacion.ListCount > 0 Then
        '    mnUnidadAct = 0
        '    cmbUbicacion.ListIndex = 0
        'End If
        If cmbUbicacion.Items.Count > 0 Then
            mnUnidadAct = 0
            cmbUbicacion.SelectedIndex = 0
        End If
        Call llena_sucursales_M
        Call llena_sucursales_M1
        Select Case mnModo
            Case 1
                Me.Text = "Consulta Gestores"
                chkEstrategico.Visible = False
                chkBBVA.Visible = False
            Case 2
                Me.Text = "Mantenimiento Gestores"
                chkEstrategico.Visible = True
                'pnlEstrategico.Visible = False
                chkBBVA.Visible = True
                'pnlBBVA.Visible = False
                Select Case cmdBorrar.Text
                    Case "&Anular"
                        'Tiene permiso para cancelar al Gestor
                        If True Then 'If lLibreria.Permiso("PFUNCCANCEL") Then
                            cmdBorrar.Text = "&Anular"
                            cmdBorrar.Enabled = True
                            cmdBorrar.Visible = True
                        End If
                    Case "&Reactivar"
                        'Tiene permiso para reactivar al Gestor
                        If True Then 'If lLibreria.Permiso("PFUNCREACTIVA") = True Then
                            cmdBorrar.Text = "&Reactivar"
                            cmdBorrar.Enabled = True
                            cmdBorrar.Visible = True
                        End If
                End Select
                If True Then 'If lLibreria.Permiso("PFUNCALTAEST") Then
                    chkEstrategico.Enabled = True
                    chkBBVA.Enabled = True
                Else
                    chkEstrategico.Enabled = False
                    chkBBVA.Enabled = False
                End If
        End Select
        cmdGuardar.Enabled = False
        'ShowDefaultCursor
    End Sub
    Private Sub llena_sucursales_M()

        'ShowWaitCursor
        'cpb 7marzo2006 SQL2000 cambio de la variable BD_CATALOGOS_SUCURSALES por BD_CATALOGOS leída de inicio de la apliación
        'llena combo sucursales
        gsSql = "Select cr_opera,bbvab,nombre_sucursal,sucursal "
        gsSql = gsSql & "From "
        gsSql = gsSql & "CATALOGOS" & "..SUCURSAL WITH (NOLOCK) where "
        If IsNumeric(Trim(cmbSucursal.Text)) Or IsNumeric(Microsoft.VisualBasic.Left(Trim(cmbSucursal.Text), 7)) Then
            cmbSucursal.Text = Microsoft.VisualBasic.Left(Trim(cmbSucursal.Text), 7)
            gsSql = gsSql & "sucursal like '" & Trim(cmbSucursal.Text) & "%' and "
        ElseIf Trim(cmbSucursal.Text) <> "" Then
            gsSql = gsSql & "nombre_sucursal like '%" & Trim(cmbSucursal.Text) & "%' and "
        End If
            gsSql = gsSql & "estrategica =1 and bbvab=" & If(chkBBVA.Checked, 1, 0) & " "
            gsSql = gsSql & "order by sucursal "
        'dbExecQuery gsSql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
        If cmbSucursal.DataSource IsNot Nothing Then
            cmbSucursal.DataSource.Clear()
        End If
        dtRespConsulta.Columns.Add("DatoMostrado")
        For Each row As DataRow In dtRespConsulta.Rows
            row("DatoMostrado") = row("sucursal") + " " + row("nombre_sucursal")
        Next
        'Do While dbError = 0
        'cmbSucursal.AddItem Trim(dbGetValue(3)) & "  " & Trim(dbGetValue(2))
        'cmbSucursal.ItemData(cmbSucursal.NewIndex) = Val(dbGetValue(0))
        'dbGetRecord
        'Loop
        'For Each row As DataRow In dtRespConsulta.Rows
        '    cmbSucursal.Items.Insert(row.Item("cr_opera"), row.Item("sucursal") & "  " & row.Item("nombre_sucursal"))
        'Next
        cmbSucursal.ValueMember = "cr_opera"
        cmbSucursal.DisplayMember = "DatoMostrado" '& "  " & "nombre_sucursal"
        cmbSucursal.DataSource = dtRespConsulta
        'cmbSucursal.SelectedIndex = 0


        'dbEndQuery
        If mbHabilita Then cmdGuardar.Enabled = True
        'ShowDefaultCursor
    End Sub

    Private Sub llena_sucursales_M1()
        'ShowWaitCursor
        'cpb 7marzo2006 SQL2000 cambio de la variable BD_CATALOGOS_SUCURSALES por BD_CATALOGOS leída de inicio de la apliación
        'llena combo sucursales
        gsSql = "Select cr_opera,bbvab,nombre_sucursal,sucursal "
        gsSql = gsSql & "From "
        gsSql = gsSql & "CATALOGOS" & "..SUCURSAL WITH (NOLOCK) where "
        If IsNumeric(Trim(cmbSucursal1.Text)) Or IsNumeric(Microsoft.VisualBasic.Left(Trim(cmbSucursal1.Text), 7)) Then
            cmbSucursal1.Text = Microsoft.VisualBasic.Left(Trim(cmbSucursal1.Text), 7)
            gsSql = gsSql & "sucursal like '" & Trim(cmbSucursal1.Text) & "%' and "
        ElseIf Trim(cmbSucursal1.Text) <> "" Then
            gsSql = gsSql & "nombre_sucursal like '%" & Trim(cmbSucursal1.Text) & "%' and "
        End If
        gsSql = gsSql & "estrategica =1 and bbvab=" & If(chkBBVA.Checked, 1, 0) & " "
        gsSql = gsSql & "order by sucursal "
        'dbExecQuery gsSql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
        If cmbSucursal1.DataSource IsNot Nothing Then
            cmbSucursal1.DataSource.Clear
        End If
        dtRespConsulta.Columns.Add("DatoMostrado")
        For Each row As DataRow In dtRespConsulta.Rows
            row("DatoMostrado") = row("sucursal") + " " + row("nombre_sucursal")
        Next
        'Do While dbError = 0
        '    cmbSucursal1.AddItem Trim(dbGetValue(3)) & "  " & Trim(dbGetValue(2))
        'cmbSucursal1.ItemData(cmbSucursal1.NewIndex) = Val(dbGetValue(0))
        '    dbGetRecord
        'Loop
        'For Each row As DataRow In dtRespConsulta.Rows
        '    cmbSucursal1.Items.Insert(row.Item("cr_opera"), row.Item("sucursal") & "  " & row.Item("nombre_sucursal"))
        'Next
        cmbSucursal1.ValueMember = "cr_opera"
        cmbSucursal1.DisplayMember = "DatoMostrado"
        cmbSucursal1.DataSource = dtRespConsulta
        'cmbSucursal1.SelectedIndex = 0
        'dbEndQuery
        If mbHabilita Then cmdGuardar.Enabled = True
        'ShowDefaultCursor
    End Sub
    Private Sub txtFuncCte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFuncCte.KeyPress
        'KeyAscii = Filtra(KeyAscii, 1)
        If AscW(e.KeyChar) = CInt(Keys.Enter) Then 'If KeyAscii = 13 Then
            If cmbFuncs.Enabled = True Then cmbFuncs.Focus()
        Else
            Call LimpiaCampos()
            If cmbFuncs.Items.Count > 0 Then
                If cmbFuncs.DataSource Is Nothing Then
                    cmbFuncs.Items.Clear()
                Else
                    cmbFuncs.DataSource = Nothing
                End If
            End If
        End If
    End Sub
    Private Sub txtFuncCte_LostFocus(sender As Object, e As EventArgs) Handles txtFuncCte.LostFocus
        If cmbFuncs.Items.Count > 0 And Trim(txtFuncCte.Text) <> "" Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        pbProceso.Visible = True
        pbProceso.Maximum = 3
        pbProceso.Value = 0
        If Trim(txtFuncCte.Text) <> "" Then
            If Len(txtFuncCte.Text.Length) < 8 Then
                txtFuncCte.Text = txtFuncCte.Text.PadLeft(8, "0")
            End If
            'cpb 9marzo2006 SQL2000 manejo de la concatenación de campos nulos
            gsSql = "Select "
            gsSql = gsSql & " funcionario, "
            gsSql = gsSql & " rtrim(nombre_funcionario)+' '+rtrim(isnull(apellido_paterno, space(0)))+' '+"
            gsSql = gsSql & " rtrim(isnull(apellido_materno, space(0))) AS Nombre"
            gsSql = gsSql & " From "
            gsSql = gsSql & " FUNCIONARIOS..FUNCIONARIO WITH (NOLOCK) "
            gsSql = gsSql & " Where "
            gsSql = gsSql & " convert(int,numero_funcionario) = " & Trim(txtFuncCte.Text)
            If mnModo = 3 Then
                gsSql = gsSql & " and unidad_organizacional = " & gnUnidadOrg
            End If
            gsSql = gsSql & " Order by "
            gsSql = gsSql & " rtrim(nombre_funcionario)+' '+rtrim(isnull(apellido_paterno, space(0)))+' '+"
            gsSql = gsSql & " rtrim(isnull(apellido_materno, space(0)))"
            Call LimpiaCampos()

            If cmbFuncs.DataSource Is Nothing Then
                cmbFuncs.Items.Clear()
            Else
                cmbFuncs.DataSource = Nothing
            End If
            pbProceso.Value = 1

            'dbExecQuery gsSql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
            'Do While dbError = 0
            '    cmbFuncs.AddItem LowCaseName(dbGetValue(1))
            'cmbFuncs.ItemData(cmbFuncs.NewIndex) = Val(dbGetValue(0))
            '    dbGetRecord
            'Loop
            If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
                cmbFuncs.ValueMember = "funcionario"
                cmbFuncs.DisplayMember = "Nombre"
                cmbFuncs.DataSource = dtRespConsulta
                cmbFuncs.SelectedIndex = 0
            Else

            End If
            'dbEndQuery
            If True Then 'If lLibreria.Permiso("PFUNCALTAEST") Then
                chkEstrategico.Enabled = True
                chkBBVA.Enabled = True
            Else
                chkEstrategico.Enabled = False
                chkBBVA.Enabled = False
            End If
            pbProceso.Value = 2
            If mnModo <> 2 Then
                cmdBorrar.Visible = False
            End If
            If cmbFuncs.Items.Count = 1 Then
                cmbFuncs.SelectedIndex = 0
            ElseIf cmbFuncs.Items.Count > 1 Then
                SendMessage(cmbFuncs.SelectedValue, 335, 1, 0)
            Else
                cmdGuardar.Enabled = False
                chkEstrategico.Enabled = False
                chkBBVA.Enabled = False
                MsgBox("El No. de Gestor no existe.", vbInformation, "Aviso")
                txtFuncCte.Text = ""
                txtFuncCte.Focus()
            End If
            'Oliva Farias García OFG 15/nov/2016 - Registro de Modificaciones de funcionarios en Bitacora de Gestores
            LimpiarTag()
        End If
        pbProceso.Value = 3
        pbProceso.Visible = False
        pbProceso.Value = 0
    End Sub
    Private Sub LimpiaCampos()
        cmdBorrar.Enabled = False
        If mnModo <> 3 Then gnUnidadOrg = 0
        mnUnidadAnt = 0
        mnEstrategico = 2
        txtNombre.Text = ""
        txtApellidoP.Text = ""
        txtApellidoM.Text = ""
        txtTelefono.Text = ""
        txtFax.Text = ""
        txtCP.Text = ""
        txtCalle.Text = ""
        txtColonia.Text = ""
        If cmbUbicacion.Items.Count > 0 Then
            mnUnidadAct = 0
            cmbUbicacion.SelectedIndex = 0
        End If
        txtEstado.Text = ""
        txtNumF.Text = ""
        txtNumReg.Text = ""
        '******* OLIVIA FARIAS GARCIA OFG 2016-07-21
        'PARA QUE LIMPIE EL CAMPO CUANDO SE HAGAN CONSULTAS Y MANTENIMIENTOS YA QUE NO EXISTIA
        txtGestorTF.Text = ""
        lblUnidadOrgA.Text = "" 'MERD Softtek para visualizar toda la ruta
        lblUnidadOrgB.Text = ""
        'lblUnidadOrgA.Enabled = True 'MERD Softtek para visualizar toda la ruta
        'lblUnidadOrgB.Enabled = True
        'lblUnidadOrgA.Locked = True 'MERD Softtek para visualizar toda la ruta
        'lblUnidadOrgB.Locked = True
        lstSistemas.Items.Clear()
        pnlDatos.Enabled = False
        If cmbSucursal.DataSource IsNot Nothing Then
            cmbSucursal.DataSource = Nothing
        End If
        If cmbSucursal1.DataSource IsNot Nothing Then
            cmbSucursal1.DataSource = Nothing
        End If
    End Sub
    'INICIO: Oliva Farias García OFG 15/nov/2016 - Registro de Modificaciones de funcionarios en Bitacora de Gestores
    Private Sub LimpiarTag()
        txtNombre.Tag = ""
        txtApellidoP.Tag = ""
        txtApellidoM.Tag = ""
        txtTelefono.Tag = ""
        txtFax.Tag = ""
        txtCalle.Tag = ""
        txtColonia.Tag = ""
        txtCP.Tag = ""
        cmbUbicacion.Tag = ""
        txtEstado.Tag = ""
        txtNumF.Tag = ""
        txtNumReg.Tag = ""
        txtGestorTF.Tag = ""
        cmbSucursal.Tag = ""
        cmbSucursal1.Tag = ""
        chkEstrategico.Tag = ""
        chkBBVA.Tag = ""
        'FIN: Oliva Farias García OFG 15/nov/2016 - Registro de Modificaciones de funcionarios en Bitacora de Gestores
    End Sub
    Private Sub cmbFuncs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFuncs.SelectedIndexChanged
        If cmbFuncs.DataSource IsNot Nothing Then
            pbProceso.Visible = True
            pbProceso.Maximum = 10
            pbProceso.Value = 0
            Dim sgsSql1 As String
            On Error GoTo errComboFuncs
            '*****************************
            Dim lsElemento As String
            Dim lnIndice As Integer
            Dim lnPadre As Integer
            Dim lnTpUniOrg As Integer
            Dim blTpUniOrg As Boolean
            Dim blTpUniOrg2 As Boolean
            Dim foundRows As DataRow()
            '------------------------------------------------------- RACB 22/03/2023
            Dim objGlobal As New Cursors
            If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
                Exit Sub
            End If
            '------------------------------------------------------- RACB 22/03/2023
            blTpUniOrg = False
            blTpUniOrg2 = True
            Label5.Visible = True
            lblUnidadOrgA.Visible = True 'MERD Visualizar ruta completa
            lblUnidadOrgB.Visible = True
            'Label16.Visible = True
            'Label16.Text = "Unidad Org. Anterior:"
            '*****************************
            pbProceso.Value = 1
            mnEstrategico = 2
            'StatusMessage ""
            If cmbFuncs.Items.Count < 0 Then Exit Sub
            'ShowWaitCursor

            'No tiene el numero de Gestor
            '*********************************
            If Trim(txtFuncCte.Text) = "" Then
                gsSql = "Select numero_funcionario from FUNCIONARIOS..FUNCIONARIO WITH (NOLOCK) where "
                gsSql = gsSql & "funcionario = " & cmbFuncs.SelectedValue.ToString 'cmbFuncs.ItemData(cmbFuncs.ListIndex)
                'dbExecQuery gsSql
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
                If dtRespConsulta Is Nothing And dtRespConsulta.Rows.Count <= 0 Then 'If dbError <> 0 Then
                    'dbEndQuery
                    'ShowDefaultCursor
                    MsgBox("No es posible obtener el numero del Gestor.", vbCritical, "Error")
                    Exit Sub
                End If
                txtFuncCte.Text = dtRespConsulta.Rows(0).Item(0)
                'dbEndQuery
            End If
            '*********************************
            If mnModo <> 2 Then
                cmdBorrar.Visible = False
            End If
            If (cmbFuncs.Text <> "") Or (Trim(txtFuncCte.Text) <> "") Then
                mnFunc = cmbFuncs.SelectedValue.ToString 'cmbFuncs.ItemData(cmbFuncs.ListIndex)
                gsSql = "Select rtrim(nombre_funcionario), "
                gsSql = gsSql & "rtrim(apellido_paterno), "
                gsSql = gsSql & "rtrim(apellido_materno), "
                gsSql = gsSql & "numero_funcionario, "
                gsSql = gsSql & "numero_registro, "
                gsSql = gsSql & "telefono_funcionario, "
                gsSql = gsSql & "fax_funcionario, "
                gsSql = gsSql & "rtrim(calle_funcionario), "
                gsSql = gsSql & "rtrim(colonia_funcionario), "
                gsSql = gsSql & "ubicacion, "
                gsSql = gsSql & "rtrim(cp_funcionario), "
                gsSql = gsSql & "estrategico, "
                gsSql = gsSql & "activo, "
                gsSql = gsSql & "on_mni, "
                gsSql = gsSql & "on_bsi, "
                gsSql = gsSql & "on_harris, "
                gsSql = gsSql & "bbvab, "
                gsSql = gsSql & "RIGHT('0000000'+LTRIM(CONVERT(VARCHAR(7), funcionario)), 7) as Ticket_id,unidad_organizacional,cr_opera,cr_opera_term "
                gsSql = gsSql & "from FUNCIONARIOS..FUNCIONARIO WITH (NOLOCK) "
                gsSql = gsSql & "where funcionario = " & mnFunc
                'Obtiene los datos del funcionario
                'dbExecQuery gsSql
                'dbGetRecord
                Dim dtRespConsulta2 = objDatasource.RealizaConsulta(gsSql)
                If dtRespConsulta2 IsNot Nothing And dtRespConsulta2.Rows.Count > 0 Then 'If dbError = 0 Then
                    Call LimpiaCampos()
                    txtNombre.Text = lLibreria.LowCaseName(dtRespConsulta2.Rows(0).Item(0))
                    txtApellidoP.Text = lLibreria.LowCaseName(dtRespConsulta2.Rows(0).Item(1))
                    txtApellidoM.Text = lLibreria.LowCaseName(dtRespConsulta2.Rows(0).Item(2))
                    txtNumF.Text = dtRespConsulta2.Rows(0).Item(3)
                    txtFuncCte.Text = dtRespConsulta2.Rows(0).Item(3).PadLeft(8, "0")
                    txtNumReg.Text = dtRespConsulta2.Rows(0).Item(4)
                    txtTelefono.Text = dtRespConsulta2.Rows(0).Item(5)
                    txtFax.Text = dtRespConsulta2.Rows(0).Item(6)
                    txtCP.Text = dtRespConsulta2.Rows(0).Item(10)
                    txtCalle.Text = dtRespConsulta2.Rows(0).Item(7)
                    txtColonia.Text = dtRespConsulta2.Rows(0).Item(8)
                    chkEstrategico.Checked = Val(dtRespConsulta2.Rows(0).Item(11))
                    mnEstrategico = Val(dtRespConsulta2.Rows(0).Item(11))
                    txtTicketId.Text = dtRespConsulta2.Rows(0).Item(17)
                    txtUniOrg.Text = dtRespConsulta2.Rows(0).Item(18)
                    chkBBVA.Checked = Val(dtRespConsulta2.Rows(0).Item(16))
                    If cmbSucursal.DataSource Is Nothing And cmbSucursal1.DataSource Is Nothing Then
                        llena_sucursales_M()
                        llena_sucursales_M1()
                    End If
                    If dtRespConsulta2.Rows(0).Item(19).ToString <> "" Then
                        foundRows = cmbSucursal.DataSource.Select("cr_opera = " & dtRespConsulta2.Rows(0).Item(19))
                        If foundRows.Length > 0 Then
                            cmbSucursal.SelectedValue = (DirectCast(foundRows, System.Data.DataRow())(0)).ItemArray(0)
                        End If
                    Else
                        cmbSucursal.SelectedValue = -1
                    End If
                    pbProceso.Value = 2
                    If dtRespConsulta2.Rows(0).Item(20).ToString <> "" Then
                        foundRows = cmbSucursal1.DataSource.Select("cr_opera = " & dtRespConsulta2.Rows(0).Item(20))
                        If foundRows.Length > 0 Then
                            cmbSucursal1.SelectedValue = (DirectCast(foundRows, System.Data.DataRow())(0)).ItemArray(0)
                        End If
                    Else
                        cmbSucursal1.SelectedValue = -1
                    End If
                    Select Case mnModo
                        Case 1
                            If Val(dtRespConsulta2.Rows(0).Item(11)) = 1 Then
                                'pnlEstrategico.Visible = True
                                chkEstrategico.Visible = True

                            Else
                                'pnlEstrategico.Visible = False
                                chkEstrategico.Visible = False
                            End If
                            If Val(dtRespConsulta2.Rows(0).Item(16)) = True Then
                                'pnlBBVA.Visible = True
                                chkBBVA.Visible = True
                            Else
                                'pnlBBVA.Visible = False
                                chkBBVA.Visible = False
                            End If
                        Case 2
                            If True Then 'If lLibreria.Permiso("PFUNCALTAEST") Then
                                chkEstrategico.Enabled = True
                            Else
                                chkEstrategico.Enabled = False
                            End If
                            If True Then 'If lLibreria.Permiso("PFUNCALTAEST") Then
                                chkBBVA.Enabled = True
                            Else
                                chkBBVA.Enabled = False
                            End If
                    End Select

                    pbProceso.Value = 3

                    '    ' 02-05-2012
                    '    'GACC
                    '    txtUniGes.text = obtenUniOrg(mnFunc)
                    '     '      txtUniGes.text = ""

                    'El funcionario esta activo
                    If Val(dtRespConsulta2.Rows(0).Item(12)) = 1 Then
                        lblStatusFunc.Visible = False
                        Call HabilitaCampos()
                        'El modo es diferente a consulta
                        If mnModo <> 1 Then
                            'Tiene permiso para cancelar al funcionario
                            If True Then 'If lLibreria.Permiso("PFUNCCANCEL") Then
                                cmdBorrar.Text = "&Anular"
                                cmdBorrar.Enabled = True
                                cmdBorrar.Visible = True
                            End If
                        End If
                        'El funcionario esta inactivo
                    Else
                        '*********Renombramos la etiqueta
                        'Label16.Text = "Unidad Org Anterior.:"
                        lblStatusFunc.Visible = True
                        Call DeshabilitaCampos()
                        'El modo es diferente a consulta
                        If mnModo <> 1 Then
                            'Tiene permiso para reactivar al funcionario
                            If True Then 'If lLibreria.Permiso("PFUNCREACTIVA") = True Then
                                cmdBorrar.Text = "&Reactivar"
                                cmdBorrar.Enabled = True
                                cmdBorrar.Visible = True
                            End If
                        End If
                    End If
                    pbProceso.Value = 4
                    'If(Val(dtRespConsulta.Rows(0).Item(13), 1, 0)
                    Dim valor1 = If(dtRespConsulta2.Rows(0).Item(13), 1, 0)
                    Dim valor2 = If(dtRespConsulta2.Rows(0).Item(15), 1, 0)
                    If valor1 = 1 Then lstSistemas.Items.Add("Mesa de Negocios Internacionales")
                    'If Val(dbGetValue(14)) = 1 Then lstSistemas.AddItem "Ticket Houston BSI"
                    If valor2 = 1 Then lstSistemas.Items.Add("Ticket Harris")
                    If Trim(dtRespConsulta2.Rows(0).Item(9)) <> "" Then
                        sgsSql1 = "Select EDO.descripcion_ubicacion From "
                        sgsSql1 = sgsSql1 & "FUNCIONARIOS..UBICACION CIU, "
                        sgsSql1 = sgsSql1 & "FUNCIONARIOS..UBICACION EDO "
                        sgsSql1 = sgsSql1 & " where CIU.ubicacion= " & Val(dtRespConsulta2.Rows(0).Item(9))
                        sgsSql1 = sgsSql1 & " and CIU.ubicacion_padre=EDO.ubicacion"

                        cmbUbicacion.SelectedValue = dtRespConsulta2.Rows(0).Item(9).ToString
                        mnUnidadAct = cmbUbicacion.SelectedIndex
                        'For lnIndice = 0 To (cmbUbicacion.Items.Count - 1)
                        '    cmbUbicacion.SelectedIndex = lnIndice
                        '    If cmbUbicacion.SelectedValue.ToString = Val(dtRespConsulta2.Rows(0).Item(9).ToString) Then
                        '        mnUnidadAct = lnIndice
                        '        'chkBBVA.Checked = Val(dtRespConsulta2.Rows(0).Item(1))
                        '        'dbEndQuery
                        '        'cmbUbicacion.ListIndex = lnIndice
                        '        Exit For
                        '    End If
                        'Next lnIndice
                        'dbEndQuery
                        'dbExecQuery gsSql
                        'dbGetRecord
                        dtRespConsulta = objDatasource.RealizaConsulta(sgsSql1)
                        If dtRespConsulta IsNot Nothing Then 'If dbError = 0 Then
                            If dtRespConsulta.Rows.Count > 0 Then
                                txtEstado.Text = dtRespConsulta.Rows(0).Item(0)
                            End If
                        Else
                            txtEstado.Text = ""
                        End If
                        'dbEndQuery
                    Else
                        mnUnidadAct = 0
                        cmbUbicacion.SelectedIndex = 0
                    End If
                Else
                    'dbEndQuery
                    'ShowDefaultCursor
                    MsgBox("No es posible obtener información del Gestor.", vbCritical, "Error")
                    Exit Sub
                End If
                pbProceso.Value = 5
                '************************************************************************************
                Dim activo As Boolean

                activo = False

                'CPB 18-Julio-2006
                'Actualiza la tabla Funcionario.UNIDAD_ORGAIZACIONAL_RESUMEN para todos los funcionarios
                'ActualizaUnidadOrg

                gsSql = "Select unidad_organizacional, unidad_organizacional_anterior, "
                gsSql = gsSql & "activo from FUNCIONARIOS..FUNCIONARIO WITH (NOLOCK) where funcionario = " & mnFunc
                'dbExecQuery gsSql
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                    If dtRespConsulta.Rows(0).Item(0) = 0 Then
                        lblUnidadOrgA.Visible = True
                        'Label5.Visible = False
                    End If
                    If dtRespConsulta.Rows(0).Item(1).ToString = "" Then
                        'lblUnidadOrgB.Visible = False
                        'Label16.Visible = False
                    Else
                        If InStr(1, Trim(dtRespConsulta.Rows(0).Item(1)), "Gestores Anulados(11)", vbTextCompare) <> 0 Then
                            lblUnidadOrgB.Text = lLibreria.LowCaseName(Trim(dtRespConsulta.Rows(0).Item(1)))
                        Else
                            lblUnidadOrgB.Text = lLibreria.LowCaseName("Root(0)\Bancomer(1)\" & dtRespConsulta.Rows(0).Item(1))
                        End If
                    End If
                    If dtRespConsulta.Rows(0).Item(2) = 1 Then activo = True
                End If
                'dbEndQuery
                pbProceso.Value = 6
                'Obtiene el path de unidades organizacionales
                'cpb 6mzo2006 SQL2000 quitar espacion en la ruta del funcionario
                gsSql = "Select ltrim(rtrim(pla.descripcion_unidad_organizacio))+'('+ltrim(rtrim(pla.unidad_org_bancomer))+')', "
                gsSql = gsSql & "pla.unidad_organizacional_padre, pla.unidad_organizacional "
                gsSql = gsSql & ", fun.unidad_organizacional_anterior From "
                gsSql = gsSql & "FUNCIONARIOS..FUNCIONARIO fun WITH (NOLOCK) , "
                gsSql = gsSql & "FUNCIONARIOS..UNIDAD_ORGANIZACIONAL pla WITH (NOLOCK) "
                gsSql = gsSql & "where funcionario = " & mnFunc
                gsSql = gsSql & " and fun.unidad_organizacional = pla.unidad_organizacional"
                'dbExecQuery gsSql
                'dbGetRecord
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                    lnPadre = dtRespConsulta.Rows(0).Item(1)

                    gnUnidadOrg = dtRespConsulta.Rows(0).Item(2)
                    mnUnidadAnt = gnUnidadOrg

                    lblUnidadOrgA.Text = lLibreria.LowCaseName(dtRespConsulta.Rows(0).Item(0))
                Else
                    lnPadre = -1
                    gnUnidadOrg = txtUniOrg.Text
                    lblUnidadOrgA.Text = ""
                    'StatusMessage "Error"
                    MsgBox("Error al obtener la ruta de unidad organizacional.", vbCritical, "Error")
                    'StatusMessage ""
                End If
                'dbEndQuery
                pbProceso.Value = 7
                Do While lnPadre <> -1
                    'cpb 6mzo2006 SQL2000 quitar espacion en la ruta del funcionario
                    gsSql = "Select ltrim(rtrim(descripcion_unidad_organizacio))+'('+ltrim(rtrim(unidad_org_bancomer))+')', "
                    'gsSql = gsSql & " unidad_organizacional_padre From "
                    gsSql = gsSql & " unidad_organizacional_padre, tipo_unidad_organizacional From "
                    gsSql = gsSql & "FUNCIONARIOS..UNIDAD_ORGANIZACIONAL WITH (NOLOCK) "
                    gsSql = gsSql & " where unidad_organizacional = " & lnPadre
                    If blTpUniOrg Then
                        If blTpUniOrg2 Then
                            gsSql = gsSql & " and  tipo_unidad_organizacional = " & lnTpUniOrg - 1
                            blTpUniOrg2 = False
                        End If
                    End If
                    blTpUniOrg = True
                    'dbExecQuery gsSql
                    'dbGetRecord
                    dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
                    If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                        lblUnidadOrgA.Text = lLibreria.LowCaseName(dtRespConsulta.Rows(0).Item(0)) & " \" & lblUnidadOrgA.Text

                        lnPadre = dtRespConsulta.Rows(0).Item(1)
                        lnTpUniOrg = dtRespConsulta.Rows(0).Item(2)
                    Else
                        lnPadre = -1
                    End If
                    'dbEndQuery
                Loop

                If mnModo = 2 Or mnModo = 3 Then
                    pnlDatos.Enabled = True
                    txtNombre.Focus()
                Else
                    txtFuncCte.Focus()
                End If
                '*******************************************
                If mnModo = 1 Then
                    If lblUnidadOrgA.Visible = True And lblUnidadOrgB.Visible = True Then
                        If InStr(1, Trim$(lblUnidadOrgA.Text), "Banca Comercial(021)") <> 0 Then
                            cmbSucursal1.Visible = False
                            lblPorGestor.Visible = False
                        Else
                            cmbSucursal1.Visible = True
                            lblPorGestor.Visible = True
                        End If
                    ElseIf lblUnidadOrgA.Visible = True Then
                        If InStr(1, Trim$(lblUnidadOrgA.Text), "Banca Comercial(021)") <> 0 Then
                            cmbSucursal1.Visible = False
                            lblPorGestor.Visible = False
                        Else
                            cmbSucursal1.Visible = True
                            lblPorGestor.Visible = True
                        End If
                    ElseIf lblUnidadOrgB.Visible = True Then
                        If InStr(1, Trim$(lblUnidadOrgB.Text), "Banca Comercial(021)") <> 0 Then
                            cmbSucursal1.Visible = False
                            lblPorGestor.Visible = False
                        Else
                            cmbSucursal1.Visible = True
                            lblPorGestor.Visible = True
                        End If
                    End If
                End If
                '*******************************************
            Else
                txtFuncCte.Text = ""
            End If

            pbProceso.Value = 8
            ' ITS,EAG,ODT1,05/10/2011---------------------------------
            gsSql = "SELECT  registrotf FROM FUNCIONARIOS..FUNCIONARIOTF WITH (NOLOCK) WHERE funcionario = " &
                     cmbFuncs.SelectedValue.ToString 'cmbFuncs.ItemData(cmbFuncs.ListIndex)

            'dbExecQuery gsSql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
            If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                txtGestorTF.Text = dtRespConsulta.Rows(0).Item(0)
            End If

            Call funcionario_BBVB()
            Call funcionario_BBVB1()

            'Oliva Farias García OFG 15/nov/2016 - Registro de Modificaciones de funcionarios en Bitacora de Gestores
            LimpiarTag()
            'FIN: Oliva Farias García OFG 15/nov/2016 - Registro de Modificaciones de funcionarios en Bitacora de Gestores
            pbProceso.Value = 9

            '    If mnModo = 2 Then
            '        If lblUnidadOrg.Visible = True And lblUnidadOrg2.Visible = True Then
            '            If InStr(1, Trim$(lblUnidadOrg.Caption), "Banca Comercial(021)") <> 0 Then
            '                cmbSucursal.ListIndex = -1
            '                cmbSucursal1.ListIndex = -1
            '            End If
            '        ElseIf lblUnidadOrg.Visible = True Then
            '            If InStr(1, Trim$(lblUnidadOrg.Caption), "Banca Comercial(021)") <> 0 Then
            '                cmbSucursal.ListIndex = -1
            '                cmbSucursal1.ListIndex = -1
            '            End If
            '        End If
            '    End If
            cmdGuardar.Enabled = False
            If mnModo = 2 Then
                cmdGuardar.Enabled = True
                cmdBorrar.Visible = True
            End If
            'ShowDefaultCursor
            pbProceso.Value = 10
            If ValidaCuentasAsinadas() Then
                'cmbSucursal.Enabled = True
                'cmbSucursal1.Enabled = True
                'txtUniOrg.Enabled = True
            Else
                MsgBox("El gestor tiene cuentas asignadas.", vbInformation, "Cuentas asignadas")
                'cmbSucursal.Enabled = False
                'cmbSucursal1.Enabled = False
                'txtUniOrg.Enabled = False
            End If
            pbProceso.Visible = False
            pbProceso.Value = 0
            Exit Sub
errComboFuncs:
            Resume
            MsgBox(Err.Number & " " & Err.Description, vbCritical, "Error")
        End If
        pbProceso.Value = 10
        pbProceso.Visible = False
        pbProceso.Value = 0
    End Sub
    Private Sub cmbFuncs_DropDown(sender As Object, e As EventArgs) Handles cmbFuncs.DropDown
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        If cmbFuncs.Items.Count = 0 Then
            If Trim(cmbFuncs.Text) = "" Then
                Exit Sub
            End If
            'ShowWaitCursor
            'cpb 9marzo2006 SQL2000 manejo de la concatenación de campos nulos
            gsSql = "Select funcionario, "
            gsSql = gsSql & "rtrim(nombre_funcionario)+' '+rtrim(isnull(apellido_paterno, space(0)))+' '+rtrim(isnull(apellido_materno, space(0))) Nombre "
            gsSql = gsSql & "From FUNCIONARIOS..FUNCIONARIO WITH (NOLOCK) "
            gsSql = gsSql & "Where "
            gsSql = gsSql & "rtrim(nombre_funcionario)+' '+rtrim(isnull(apellido_paterno, space(0)))+' '+rtrim(isnull(apellido_materno, space(0))) like '%" & Trim(cmbFuncs.Text) & "%' "
            gsSql = gsSql & "order by rtrim(nombre_funcionario)+' '+rtrim(isnull(apellido_paterno, space(0)))+' '+rtrim(isnull(apellido_materno, space(0)))"
            Call LimpiaCampos()
            txtFuncCte.Text = ""
            'cmbFuncs.Clear
            'dbExecQuery gsSql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
            'Do While dbError = 0
            'cmbFuncs.AddItem LowCaseName(dbGetValue(1))
            'cmbFuncs.ItemData(cmbFuncs.NewIndex) = Val(dbGetValue(0))
            'dbGetRecord
            'Loop
            If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
                cmbFuncs.ValueMember = "funcionario"
                cmbFuncs.DisplayMember = "Nombre"
                cmbFuncs.DataSource = dtRespConsulta
                cmbFuncs.SelectedIndex = 0
            End If
            'dbEndQuery
            'StatusMessage "Seleccione un Gestor de la lista..."
            'ShowDefaultCursor
        End If
    End Sub

    Private Sub DeshabilitaCampos()
        Dim loObjeto As Control
        mbHabilita = False
        'ShowWaitCursor
        cmbUbicacion.Enabled = False
        cmdUnidad.Enabled = False
        cmdGuardar.Enabled = False
        For Each loObjeto In Controls
            If TypeOf loObjeto Is TextBox Then
                loObjeto.Enabled = True
            End If
        Next
        txtFuncCte.Enabled = False
        chkEstrategico.Enabled = False
        chkBBVA.Enabled = False
        'ShowDefaultCursor
    End Sub
    Private Sub HabilitaCampos()
        Dim loObjeto As Control
        mbHabilita = True
        'ShowWaitCursor
        cmbUbicacion.Enabled = True
        cmdUnidad.Enabled = True
        cmdGuardar.Enabled = True
        For Each loObjeto In Controls
            If TypeOf loObjeto Is TextBox Then
                loObjeto.Enabled = False
            End If
        Next
        txtFuncCte.Enabled = False
        chkEstrategico.Enabled = True
        chkBBVA.Enabled = True
        'ShowDefaultCursor
    End Sub
    Private Sub funcionario_BBVB()

        Dim itemSucursal As Integer
        Dim X As Long
        'llena_sucursales_M
        If mnModo = 2 Then
            itemSucursal = -1
            If cmbSucursal.DataSource Is Nothing Then
                Call llena_sucursales_M()
            End If
            'cpb 7marzo2006 SQL2000 cambio de la variable BD_CATALOGOS_SUCURSALES por BD_CATALOGOS leída de inicio de la apliación
            gsSql = "Select S.cr_opera,S.bbvab,S.nombre_sucursal,S.sucursal "
                gsSql = gsSql & "From FUNCIONARIOS..FUNCIONARIO F WITH (NOLOCK), " & "CATALOGOS" & "..SUCURSAL S WITH (NOLOCK) "
                gsSql = gsSql & "where  F.cr_opera=S.cr_opera and "
                gsSql = gsSql & "F.funcionario = " & cmbFuncs.SelectedValue.ToString 'cmbFuncs.ItemData(cmbFuncs.ListIndex)
                'dbExecQuery gsSql
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                    itemSucursal = Val(dtRespConsulta.Rows(0).Item(0))
                End If
                'dbEndQuery
                If itemSucursal > -1 Then
                    For X = 0 To cmbSucursal.Items.Count - 1
                        'cmbSucursal.SelectedIndex = X
                        If itemSucursal = cmbSucursal.SelectedValue() Then
                            'cmbSucursal.ListIndex = X
                            Exit Sub
                        End If
                    Next X
                End If
            Else
                'cpb 7marzo2006 SQL2000 cambio de la variable BD_CATALOGOS_SUCURSALES por BD_CATALOGOS leída de inicio de la apliación
                gsSql = "Select S.cr_opera,S.bbvab,S.nombre_sucursal,S.sucursal "
            gsSql = gsSql & "From FUNCIONARIOS..FUNCIONARIO F WITH (NOLOCK) , " & "CATALOGOS" & "..SUCURSAL S WITH (NOLOCK) "
            gsSql = gsSql & "where  F.cr_opera=S.cr_opera and "
            gsSql = gsSql & "F.funcionario = " & cmbFuncs.SelectedValue.ToString 'cmbFuncs.ItemData(cmbFuncs.ListIndex)
            'dbExecQuery gsSql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
            'If dbError = 0 Then
            '    cmbSucursal.Clear
            '    cmbSucursal.AddItem Trim(dbGetValue(3)) & "  " & Trim(dbGetValue(2))
            'cmbSucursal.ItemData(cmbSucursal.NewIndex) = Val(dbGetValue(0))
            '    cmbSucursal.ListIndex = 0
            'End If
            If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                itemSucursal = Val(dtRespConsulta.Rows(0).Item(0))
            End If
            If itemSucursal > -1 Then
                For X = 0 To cmbSucursal.Items.Count - 1
                    'cmbSucursal.SelectedIndex = X
                    If itemSucursal = cmbSucursal.SelectedValue() Then
                        'cmbSucursal.ListIndex = X
                        Exit Sub
                    End If
                Next X
            End If
        End If
    End Sub

    Private Sub funcionario_BBVB1()
        Dim itemSucursal As Integer
        Dim X As Long
        'llena_sucursales_M
        If mnModo = 2 Then
            itemSucursal = -1
            If cmbSucursal1.DataSource Is Nothing Then
                Call llena_sucursales_M1()
            End If
            'cpb 7marzo2006 SQL2000 cambio de la variable BD_CATALOGOS_SUCURSALES por BD_CATALOGOS leída de inicio de la apliación
            gsSql = "Select S.cr_opera,S.bbvab,S.nombre_sucursal,S.sucursal "
            gsSql = gsSql & "From FUNCIONARIOS..FUNCIONARIO F WITH (NOLOCK) , " & "CATALOGOS" & "..SUCURSAL S WITH (NOLOCK) "
            gsSql = gsSql & "where  F.cr_opera_term=S.cr_opera and "
            gsSql = gsSql & "F.funcionario = " & cmbFuncs.SelectedValue.ToString 'cmbFuncs.ItemData(cmbFuncs.ListIndex)
            'dbExecQuery gsSql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
            If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                itemSucursal = Val(dtRespConsulta.Rows(0).Item(0))
            End If
            'dbEndQuery
            If itemSucursal > -1 Then
                For X = 0 To cmbSucursal1.Items.Count() - 1
                    'cmbSucursal1.SelectedIndex = X
                    If itemSucursal = cmbSucursal1.SelectedValue() Then
                        'cmbSucursal1.ListIndex = X
                        Exit Sub
                    End If
                Next X
            End If
        Else
            'cpb 7marzo2006 SQL2000 cambio de la variable BD_CATALOGOS_SUCURSALES por BD_CATALOGOS leída de inicio de la apliación
            gsSql = "Select S.cr_opera,S.bbvab,S.nombre_sucursal,S.sucursal "
            gsSql = gsSql & "From FUNCIONARIOS..FUNCIONARIO F WITH (NOLOCK) , " & "CATALOGOS" & "..SUCURSAL S WITH (NOLOCK) "
            gsSql = gsSql & "where  F.cr_opera_term=S.cr_opera and "
            gsSql = gsSql & "F.funcionario = " & cmbFuncs.SelectedValue.ToString 'cmbFuncs.ItemData(cmbFuncs.ListIndex)
            'dbExecQuery gsSql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
            'If dbError = 0 Then
            '    cmbSucursal1.Clear
            '    cmbSucursal1.AddItem Trim(dbGetValue(3)) & "  " & Trim(dbGetValue(2))
            'cmbSucursal1.ItemData(cmbSucursal1.NewIndex) = Val(dbGetValue(0))
            '    cmbSucursal1.ListIndex = 0
            'End If
            'dbEndQuery
            If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                itemSucursal = Val(dtRespConsulta.Rows(0).Item(0))
            End If
            If itemSucursal > -1 Then
                For X = 0 To cmbSucursal1.Items.Count - 1
                    'cmbSucursal1.SelectedIndex = X
                    If itemSucursal = cmbSucursal1.SelectedValue() Then
                        'cmbSucursal.ListIndex = X
                        Exit Sub
                    End If
                Next X
            End If
        End If
    End Sub
    Private Sub cmdUnidad_Click(sender As Object, e As EventArgs) Handles cmdUnidad.Click
        If lstSistemas.Items.Count > 0 Then
            'StatusMessage "Confirme operación de cambio..."
            If MsgBox("El Gestor tiene cuentas asignadas. ¿Desea cambiarlo de unidad organizacional?", vbYesNo + vbQuestion, "Mensaje") = vbYes Then
                'frmUnidadOrg.TipoConsulta(4, cmbFuncs.Text)
                cmbSucursal.SelectedIndex = -1
                cmbSucursal1.SelectedIndex = -1
            Else
                'StatusMessage ""
                Exit Sub
            End If
            'StatusMessage ""
        Else
            mo_PrevWindow = Nothing
            'frmUnidadOrg.TipoConsulta(4, cmbFuncs.Text)
            cmbSucursal.SelectedIndex = -1
            cmbSucursal1.SelectedIndex = -1
        End If
    End Sub
    Private Sub chkBBVA_CheckedChanged(sender As Object, e As EventArgs) Handles chkBBVA.CheckedChanged
        If mnEstrategico <> 2 Then
            If mbHabilita = True Then cmdGuardar.Enabled = True
            If txtApellidoP.Enabled = True Then txtApellidoP.Focus()
        End If
        Call llena_sucursales_M()
        Call llena_sucursales_M1()
    End Sub
    Private Sub chkEstrategico_CheckedChanged(sender As Object, e As EventArgs) Handles chkEstrategico.CheckedChanged
        If mnEstrategico <> 2 Then
            If mbHabilita = True Then cmdGuardar.Enabled = True
            If txtApellidoP.Enabled = True Then txtApellidoP.Focus()
        End If
    End Sub
    Private Sub cmdBorrar_Click(sender As Object, e As EventArgs) Handles cmdBorrar.Click
        Dim lsAccion As String
        Dim lsSQL As String
        Dim tmpUnidadOrg As Long
        Dim unidadAnulada As String
        Dim frmActive As Object
        Dim UOAnulada As Long
        Dim lnActivo As Integer
        Dim lnUnidadOrganizacional As Integer
        Dim lsNumeroFuncionario As String
        Dim lsUnidadOrgBancomer As String
        Dim lsFechaAlta As Date
        Dim lnIdTransaccion As Integer
        'WSS001 Begins
        Dim numFuncionarioPU As String

        Dim dtRespuesta As DataTable
        'WSS001 Ends
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        If txtFuncCte.Text <> "" And cmbFuncs.DataSource IsNot Nothing Then
            unidadAnulada = ""
            'Se va a reactivar o anular sin cuentas
            If (lstSistemas.Items.Count = 0) Or (cmdBorrar.Text = "&Reactivar") Then
                'StatusMessage "Confirme operación..."
                If MsgBox("¿Está seguro de querer " & LCase(Mid(cmdBorrar.Text, 2)) & " al Gestor?", vbYesNo + vbQuestion, "Mensaje") = vbNo Then
                    'StatusMessage ""
                    Exit Sub
                End If
                'StatusMessage ""
                'Se quiere anular al Gestor
                'dbBeginTran
                objDatasource.IniciaTransaccion()
                If cmdBorrar.Text = "&Anular" Then
                    gsSql = "Select count(*) from "
                    gsSql = gsSql & "FUNCIONARIOS..TARJETA_ID where "
                    gsSql = gsSql & "funcionario = " & mnFunc
                    gsSql = gsSql & "  and  status_tarjeta_id in (2,39)"
                    'dbExecQuery gsSql
                    'dbGetRecord
                    dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
                    If Val(dtRespConsulta.Rows(0).Item(0)) > 0 Then
                        'dbEndQuery
                        'StatusMessage "Operación Invalida..."
                        MsgBox("No es posible anular al Gestor porque tiene una tarjeta de identificación asignada.Debe cancelar la tarjeta.", vbInformation, "Gestor con Tarjeta")
                        'dbRollback
                        objDatasource.RollbackTransaccion()
                        Exit Sub
                    End If
                    'dbEndQuery

                    'strUnidadOrg = strchr(AjustaUnidadOrganiza)

                    'Olivia Farías 13/09/2011
                    'EL CAMBIO SE REALIZO DEBIDO A QUE CAUSABA PROBLEMAS AL GENERAL ARCHIVOS PARA DATAMART YA QUE LA UNIDAD ORGANIZACION ESTA DEFINIDA EN 4 POSICIONES

                    'COMENTADO PARA QUE NO HAGA NADA CON LA UO ANTERIOR Y PONGA 3737 CUANDO ANULA
                    '            If Len(AjustaUnidadOrganiza) > 75 Then
                    '                MsgBox "La unidad organizacional sobrepasa los 75 caracteres, porfavor ajustela", vbInformation
                    '                frmAjusteUnidadOrg.Show vbModal, MDIFuncs
                    '                If Ms_UnidadOrgAnulada = "" Then
                    '                    dbRollback
                    '                    Exit Sub
                    '                End If
                    '            Else
                    '                Ms_UnidadOrgAnulada = Trim(UCase(AjustaUnidadOrganiza))
                    '            End If
                    '            '**** Inserto la unidad organizacional actual en texto a una rama en anulados
                    '            gsSql = "select unidad_organizacional from UNIDAD_ORGANIZACIONAL where rtrim(descripcion_unidad_organizacio) = '" & Ms_UnidadOrgAnulada & "'"
                    '            dbExecQuery gsSql
                    '            dbGetRecord
                    '            If dbError = 0 Then
                    '                UOAnulada = dbGetValue(0)
                    '                dbEndQuery
                    '            Else ' inserto una descripcion nueva
                    '                dbEndQuery
                    '                gbTreeCharged = False
                    '***Oliva Farias García OFG 13/09/2011
                    gsSql = "Select unidad_organizacional From FUNCIONARIOS..UNIDAD_ORGANIZACIONAL WITH (NOLOCK) Where unidad_organizacional = 9999"
                    'dbExecQuery gsSql
                    'dbGetRecord
                    dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
                    If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                        UOAnulada = dtRespConsulta.Rows(0).Item(0)
                    End If
                    'dbEndQuery
                    '                gsSql = "Select max(unidad_organizacional)+1 From UNIDAD_ORGANIZACIONAL"
                    '                dbExecQuery gsSql
                    '                dbGetRecord
                    '                If dbError = 0 Then UOAnulada = dbGetValue(0)
                    '                dbEndQuery
                    '                gsSql = "insert into UNIDAD_ORGANIZACIONAL " & _
                    '                        "select unidad_organizacional = " & UOAnulada & ", unidad_org_bancomer,tipo_unidad_organizacional, " & _
                    '                        "descripcion_unidad_organizacio= '" & Ms_UnidadOrgAnulada & "',unidad_organizacional_padre = 3737,estrategica " & _
                    '                        "from UNIDAD_ORGANIZACIONAL where unidad_organizacional = " & mnUnidadAnt
                    '                dbExecQuery gsSql
                    '                If dbError <> 0 Then
                    '                    MsgBox "No fue posible actualizar la Unidad Organizacional de la base de datos.", vbCritical, "Error"
                    '                    dbRollback
                    '                    Exit Sub
                    '                End If
                    'End If
                    gsSql = "exec FUNCIONARIOS..spu_unidad_org_ant " & UOAnulada & ", " & mnFunc
                    objDatasource.EjecutaComandoTransaccion(gsSql)
                    'dbExecQuery gsSql
                    gsSql = "update FUNCIONARIOS..FUNCIONARIO set unidad_organizacional_anterior = '" & lblUnidadOrgA.Text & "'"
                    objDatasource.EjecutaComandoTransaccion(gsSql)
                    'INICIO: Oliva Farias García OFG 09/nov/2016 - Registro de Anular o Baja en Bitacora de Gestores
                    gsSql = "EXEC FUNCIONARIOS..sp_mantenimiento_func "
                    gsSql = gsSql & mnFunc & "," & 2 & "," & usuario
                    'dbExecQuery gsSql
                    If objDatasource.EjecutaComandoTransaccion(gsSql) = False Then 'If dbError <> 0 Then
                        MsgBox("No fue posible registrar la información en bitacora.", vbCritical, "Gestores")
                    End If
                    'dbEndQuery
                    'FIN: Oliva Farias García OFG 09/nov/2016 - Registro de Bitacora de Gestores

                    If 0 <> 0 Then 'If dbError <> 0 Then
                        MsgBox("No fue posible actualizar la Unidad Organizacional de la base de datos.", vbCritical, "Error")
                        'dbRollback
                        objDatasource.RollbackTransaccion()
                        Exit Sub
                    End If
                End If

                If cmdBorrar.Text = "&Reactivar" Then
                    unidadAnulada = Trim(lblUnidadOrgA.Text)
                    gsSql = "Select count(*) from FUNCIONARIOS..FUNCIONARIO WITH (NOLOCK) where unidad_organizacional = " & gnUnidadOrg
                    'dbExecQuery gsSql
                    'dbGetRecord
                    If objDatasource.EjecutaComandoTransaccion(gsSql) = True Then 'If dbError = 0 Then
                        If iValorTransaccion = 1 Then 'If dbGetValue(0) = 1 Then
                            lsSQL = "delete FUNCIONARIOS..UNIDAD_ORGANIZACIONAL where unidad_organizacional = " & gnUnidadOrg
                        End If
                    End If
                    'dbEndQuery
                    'MsgBox("Especifique la unidad organizacional donde estará ubicado el gestor", vbInformation)
                    tmpUnidadOrg = gnUnidadOrg
                    'cmdUnidad.DoClick
                    cmdUnidad_Click(sender, e)
                    Me.Tag = ""
                    'Me.Enabled = False
                    'frmUnidadOrg.SetFocus
                    '    Set frmActive = MDIFuncs.ActiveForm
                    '    Do While Not frmActive Is Nothing
                    '    If frmActive.Name <> "frmUnidadOrg" Then Exit Do
                    '    DoEvents
                    '        Set frmActive = MDIFuncs.ActiveForm
                    '    Loop
                    'Me.Enabled = True
                    'Me.SetFocus

                    If Val(Me.Tag) = 1 Then ' ++++ Cancelo el usuario y hacemos un rollback de cualquier cambio
                        gnUnidadOrg = tmpUnidadOrg ' ++ Regreso la unidad organizacional que tenia
                        'dbRollback
                        objDatasource.RollbackTransaccion()
                        Exit Sub
                    Else
                        lnActivo = 1
                        gsSql = "Update FUNCIONARIOS..FUNCIONARIO "
                        gsSql = gsSql & "set activo = " & lnActivo
                        gsSql = gsSql & ", unidad_organizacional = " & gnUnidadOrg & ", unidad_organizacional_anterior = '" & unidadAnulada & "'"
                        gsSql = gsSql & ", fecha_ult_modif = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
                    End If
                Else
                    lnActivo = 0
                    gsSql = "Update FUNCIONARIOS..FUNCIONARIO "
                    gsSql = gsSql & "set activo = " & lnActivo
                    gsSql = gsSql & ", fecha_baja = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
                    'olivia farias agregar cambie a cr 3737 cuando se anula
                End If
                gsSql = gsSql & " where funcionario = " & mnFunc
                'dbExecQuery gsSql

                If objDatasource.EjecutaComandoTransaccion(gsSql) = True Then 'If dbError = 0 Then
                    'dbEndQuery
                    'Libera cambios en la Base de Datos
                    'dbCommit
                    'ActualizaUnidadOrg mnFunc
                    If lsSQL <> "" Then
                        'dbExecQuery lsSQL
                        objDatasource.EjecutaComandoTransaccion(gsSql)
                        'dbEndQuery
                    End If
                    'INICIO: Oliva Farias García OFG 09/nov/2016 - Registro de Reactivación en Bitacora de Gestores
                    If lnActivo = 1 Then
                        gsSql = "EXEC FUNCIONARIOS..sp_mantenimiento_func "
                        gsSql = gsSql & mnFunc & "," & 14 & "," & usuario
                        'dbExecQuery gsSql
                        If objDatasource.EjecutaComandoTransaccion(gsSql) = False Then 'If dbError <> 0 Then
                            MsgBox("No fue posible registrar la información en bitacora.", vbCritical, "Gestores")
                        End If
                        'dbEndQuery
                    End If
                    'FIN: Oliva Farias García OFG 09/nov/2016 - Registro de Bitacora de Gestores

                    'ActualizaUnidadOrg mnFunc
                    MsgBox("El Gestor fue " & IIf(cmdBorrar.Text = "&Reactivar", "reactivado", "anulado") & ".", vbInformation, "Aviso")
                    objDatasource.CommitTransaccion()
                    objDatasource.IniciaTransaccion()
                    'El Gestor fue reactivado
                    If cmdBorrar.Text = "&Reactivar" Then
                        lblStatusFunc.Visible = False
                        Call HabilitaCampos()
                        'Tiene permiso para cancelar
                        If True Then 'If lLibreria.Permiso("PFUNCCANCEL") = True Then
                            cmdBorrar.Text = "&Anular"
                            'No tiene permiso para anular
                        Else
                            cmdBorrar.Visible = False
                        End If
                        'El Gestor fue anulado
                    Else
                        lblStatusFunc.Visible = True
                        Call DeshabilitaCampos()
                        'Tiene permiso para reactivar
                        If True Then 'If lLibreria.Permiso("PFUNCREACTIVA") = True Then
                            cmdBorrar.Text = "&Reactivar"
                            'No tiene permiso para reactivar
                        Else
                            cmdBorrar.Visible = False
                        End If
                    End If
                    '*******
                    Call cmbFuncs_Click()
                    '*******
                Else
                    'dbEndQuery
                    'dbRollback
                    objDatasource.RollbackTransaccion()
                    MsgBox("No fue posible actualizar la base de datos.", vbCritical, "Error")
                    Exit Sub
                End If
            Else
                MsgBox("El Gestor tiene cuentas asignadas. Reasigne las cuentas e intente de nuevo.", vbInformation, "Mensaje")
                Exit Sub
            End If

            'Extrae datos del funcionario
            gsSql = "SELECT "
            gsSql = gsSql & "isnull(unidad_organizacional, 0) as unidad_organizacional, numero_funcionario, isnull(rtrim(convert(char(10), fecha_alta, 105)), '01-01-2000') as fecha_alta "
            gsSql = gsSql & "FROM "
            gsSql = gsSql & "FUNCIONARIOS..FUNCIONARIO WITH (NOLOCK) "
            gsSql = gsSql & "WHERE"
            gsSql = gsSql & " funcionario = " & mnFunc
            'dbExecQuery gsSql
            'dbGetRecord

            dtRespuesta = objDatasource.RealizaConsulta(gsSql)
            If dtRespuesta IsNot Nothing And dtRespuesta.Rows.Count > 0 Then 'If dbError = 0 Then
                lnUnidadOrganizacional = dtRespuesta.Rows(0).Item(0)
                lsNumeroFuncionario = dtRespuesta.Rows(0).Item(1)
                lsFechaAlta = dtRespuesta.Rows(0).Item(2)
            End If
            'dbEndQuery

            gsSql = "SELECT "
            gsSql = gsSql & "unidad_org_bancomer "
            gsSql = gsSql & "FROM "
            gsSql = gsSql & "FUNCIONARIOS..UNIDAD_ORGANIZACIONAL WITH (NOLOCK) "
            gsSql = gsSql & "WHERE"
            gsSql = gsSql & " unidad_organizacional = " & lnUnidadOrganizacional

            'dbExecQuery gsSql
            'dbGetRecord
            objDatasource.EjecutaComandoTransaccion(gsSql)
            lsUnidadOrgBancomer = iValorTransaccion
            'dbEndQuery

            'WSS001 Begins
            If Trim(txtGestorTF.Text) <> "" Then
                numFuncionarioPU = Trim(txtGestorTF.Text)
            Else
                numFuncionarioPU = "M" & Trim(txtNumF.Text)
            End If
            'WSS001 Ends

            'Si es reactivación pero con cr_opera o es baja registra datos para PU
            If (lnActivo = 1 And Trim(lsUnidadOrgBancomer) <> "") Or lnActivo = 0 Then
                lnIdTransaccion = 0

                'Extrae el Id de la Transacción
                gsSql = "select isnull(max(id_transaccion), 0) as id_transaccion "
                gsSql = gsSql & "from " & "Ticket" & "..TMP_FUNCIONARIOS_PU WITH (NOLOCK) "
                'dbExecQuery gsSql
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                    lnIdTransaccion = dtRespConsulta.Rows(0).Item(0)
                Else
                    'ShowDefaultCursor
                    MsgBox("No fue posible registrar la información para PU.", vbCritical, "Gestores")
                    'dbRollback
                    objDatasource.RollbackTransaccion()
                    Exit Sub
                End If
                'dbEndQuery




                'Inserta en la Bitacora para envios a HOST

                'Subproducto 0000000002
                lnIdTransaccion = lnIdTransaccion + 1

                gsSql = "Insert into " & "Ticket" & "..TMP_FUNCIONARIOS_PU ("
                gsSql = gsSql & "id_funcionario, "
                gsSql = gsSql & "centro_regional, "
                gsSql = gsSql & "numero_funcionario, "
                gsSql = gsSql & "producto, "
                gsSql = gsSql & "subproducto, "
                gsSql = gsSql & "fecha_alta, "
                gsSql = gsSql & "fecha_baja, "
                gsSql = gsSql & "fecha_ultimo_mant, "
                gsSql = gsSql & "tipo_peticion, "
                gsSql = gsSql & "id_transaccion, "
                gsSql = gsSql & "tipo, "
                gsSql = gsSql & "status_envio) "
                gsSql = gsSql & "VALUES ("
                gsSql = gsSql & mnFunc & ", "                               'id_funcionario
                gsSql = gsSql & "'" & lsUnidadOrgBancomer & "', "           'sucursal/plaza
                'WSS001 Begins
                'gsSql = gsSql & "'M" & Trim(lsNumeroFuncionario) & "', "    'numero_funcionario
                gsSql = gsSql & "'" & Trim(numFuncionarioPU) & "', "    'numero_funcionario
                'WSS001 Ends
                gsSql = gsSql & "'10', "                                    'producto
                gsSql = gsSql & "'0000000002', "                            'subproducto
                If lnActivo = 0 Then
                    gsSql = gsSql & "'" & Format(CDate(lsFechaAlta), "yyyy-MM-dd") & "'," 'fecha_alta
                    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_baja
                    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_ultimo_mant
                    gsSql = gsSql & "'B', "                                 'tipo_peticion - baja
                    gsSql = gsSql & lnIdTransaccion & ", "
                    gsSql = gsSql & "'B', "
                Else
                    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'," 'fecha_alta
                    gsSql = gsSql & "'12-31-2080', "                        'fecha_baja
                    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_ultimo_mant
                    gsSql = gsSql & "'A', "                                 'tipo_peticion - alta
                    gsSql = gsSql & lnIdTransaccion & ", "
                    gsSql = gsSql & "'A', "
                End If
                gsSql = gsSql & "0) "                                       'status_envio

                'Ejecuta la inserción a la bitacora
                'dbExecQuery gsSql

                If objDatasource.EjecutaComandoTransaccion(gsSql) = False Then 'If dbError <> 0 Then
                    'dbRollback
                    objDatasource.RollbackTransaccion()
                    MsgBox("No fue posible registrar la información para PU.", vbCritical, "Error")
                    Exit Sub
                End If
                'dbEndQuery

                'Subproducto 0000000000
                lnIdTransaccion = lnIdTransaccion + 1

                gsSql = "Insert into " & "Ticket" & "..TMP_FUNCIONARIOS_PU ("
                gsSql = gsSql & "id_funcionario, "
                gsSql = gsSql & "centro_regional, "
                gsSql = gsSql & "numero_funcionario, "
                gsSql = gsSql & "producto, "
                gsSql = gsSql & "subproducto, "
                gsSql = gsSql & "fecha_alta, "
                gsSql = gsSql & "fecha_baja, "
                gsSql = gsSql & "fecha_ultimo_mant, "
                gsSql = gsSql & "tipo_peticion, "
                gsSql = gsSql & "id_transaccion, "
                gsSql = gsSql & "tipo, "
                gsSql = gsSql & "status_envio) "
                gsSql = gsSql & "VALUES ("
                gsSql = gsSql & mnFunc & ", "                               'id_funcionario
                gsSql = gsSql & "'" & lsUnidadOrgBancomer & "', "           'sucursal/plaza
                'WSS001 Begins
                'gsSql = gsSql & "'M" & Trim(lsNumeroFuncionario) & "', "    'numero_funcionario
                gsSql = gsSql & "'" & Trim(numFuncionarioPU) & "', "    'numero_funcionario
                'WSS001 Ends
                gsSql = gsSql & "'10', "                                    'producto
                gsSql = gsSql & "'0000000000', "                            'subproducto
                If lnActivo = 0 Then
                    gsSql = gsSql & "'" & Format(CDate(lsFechaAlta), "yyyy-MM-dd") & "'," 'fecha_alta
                    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_baja
                    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_ultimo_mant
                    gsSql = gsSql & "'B', "                                 'tipo_peticion - baja
                    gsSql = gsSql & lnIdTransaccion & ", "
                    gsSql = gsSql & "'B', "
                Else
                    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_alta
                    gsSql = gsSql & "'12-31-2080', "                        'fecha_baja
                    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_ultimo_mant
                    gsSql = gsSql & "'A', "                                 'tipo_peticion - alta
                    gsSql = gsSql & lnIdTransaccion & ", "
                    gsSql = gsSql & "'A', "
                End If
                gsSql = gsSql & "0) "                                       'status_envio

                'Ejecuta la inserción a la bitacora
                'dbExecQuery gsSql

                If objDatasource.EjecutaComandoTransaccion(gsSql) = False Then 'If dbError <> 0 Then
                    'dbRollback
                    objDatasource.RollbackTransaccion()
                    MsgBox("No fue posible registrar la información para PU.", vbCritical, "Error")
                    Exit Sub
                End If
                'dbEndQuery

                'Subproducto 0000000687
                lnIdTransaccion = lnIdTransaccion + 1

                gsSql = "Insert into " & "Ticket" & "..TMP_FUNCIONARIOS_PU ("
                gsSql = gsSql & "id_funcionario, "
                gsSql = gsSql & "centro_regional, "
                gsSql = gsSql & "numero_funcionario, "
                gsSql = gsSql & "producto, "
                gsSql = gsSql & "subproducto, "
                gsSql = gsSql & "fecha_alta, "
                gsSql = gsSql & "fecha_baja, "
                gsSql = gsSql & "fecha_ultimo_mant, "
                gsSql = gsSql & "tipo_peticion, "
                gsSql = gsSql & "id_transaccion, "
                gsSql = gsSql & "tipo, "
                gsSql = gsSql & "status_envio) "
                gsSql = gsSql & "VALUES ("
                gsSql = gsSql & mnFunc & ", "                               'id_funcionario
                gsSql = gsSql & "'" & lsUnidadOrgBancomer & "', "           'sucursal/plaza
                'WSS001 Begins
                'gsSql = gsSql & "'M" & Trim(lsNumeroFuncionario) & "', "    'numero_funcionario
                gsSql = gsSql & "'" & Trim(numFuncionarioPU) & "', "    'numero_funcionario
                'WSS001 Ends
                gsSql = gsSql & "'10', "                                    'producto
                gsSql = gsSql & "'0000000687', "                            'subproducto
                If lnActivo = 0 Then
                    gsSql = gsSql & "'" & Format(CDate(lsFechaAlta), "yyyy-MM-dd") & "'," 'fecha_alta
                    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_baja
                    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_ultimo_mant
                    gsSql = gsSql & "'B', "                                 'tipo_peticion - baja
                    gsSql = gsSql & lnIdTransaccion & ", "
                    gsSql = gsSql & "'B', "
                Else
                    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'," 'fecha_alta
                    gsSql = gsSql & "'12-31-2080', "                        'fecha_baja
                    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_ultimo_mant
                    gsSql = gsSql & "'A', "                                 'tipo_peticion - alta
                    gsSql = gsSql & lnIdTransaccion & ", "
                    gsSql = gsSql & "'A', "
                End If
                gsSql = gsSql & "0) "                                       'status_envio

                'Ejecuta la inserción a la bitacora
                'dbExecQuery gsSql

                If objDatasource.EjecutaComandoTransaccion(gsSql) = False Then 'If dbError <> 0 Then
                    'dbRollback
                    objDatasource.RollbackTransaccion()
                    MsgBox("No fue posible registrar la información para PU.", vbCritical, "Error")
                    Exit Sub
                End If
                'dbEndQuery


                'Subproducto 0000000100
                lnIdTransaccion = lnIdTransaccion + 1

                gsSql = "Insert into " & "Ticket" & "..TMP_FUNCIONARIOS_PU ("
                gsSql = gsSql & "id_funcionario, "
                gsSql = gsSql & "centro_regional, "
                gsSql = gsSql & "numero_funcionario, "
                gsSql = gsSql & "producto, "
                gsSql = gsSql & "subproducto, "
                gsSql = gsSql & "fecha_alta, "
                gsSql = gsSql & "fecha_baja, "
                gsSql = gsSql & "fecha_ultimo_mant, "
                gsSql = gsSql & "tipo_peticion, "
                gsSql = gsSql & "id_transaccion, "
                gsSql = gsSql & "tipo, "
                gsSql = gsSql & "status_envio) "
                gsSql = gsSql & "VALUES ("
                gsSql = gsSql & mnFunc & ", "                               'id_funcionario
                gsSql = gsSql & "'" & lsUnidadOrgBancomer & "', "           'sucursal/plaza
                'WSS001 Begins
                'gsSql = gsSql & "'M" & Trim(lsNumeroFuncionario) & "', "    'numero_funcionario
                gsSql = gsSql & "'" & Trim(numFuncionarioPU) & "', "    'numero_funcionario
                'WSS001 Ends
                gsSql = gsSql & "'10', "                                    'producto
                gsSql = gsSql & "'0000000100', "                            'subproducto
                If lnActivo = 0 Then
                    gsSql = gsSql & "'" & Format(CDate(lsFechaAlta), "yyyy-MM-dd") & "'," 'fecha_alta
                    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_baja
                    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_ultimo_mant
                    gsSql = gsSql & "'B', "                                 'tipo_peticion - baja
                    gsSql = gsSql & lnIdTransaccion & ", "
                    gsSql = gsSql & "'B', "
                Else
                    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'," 'fecha_alta
                    gsSql = gsSql & "'12-31-2080', "                        'fecha_baja
                    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_ultimo_mant
                    gsSql = gsSql & "'A', "                                 'tipo_peticion - alta
                    gsSql = gsSql & lnIdTransaccion & ", "
                    gsSql = gsSql & "'A', "
                End If
                gsSql = gsSql & "0) "                                       'status_envio
                'dbExecQuery gsSql
                objDatasource.EjecutaComandoTransaccion(gsSql)

                'INICIO: Oliva Farias García OFG 09/nov/2016 - Registro de Alta o Baja de CR por Reactivacion o Anulacion en Bitacora de Gestores
                If lnActivo = 0 Then
                    gsSql = "EXEC FUNCIONARIOS..sp_mantenimiento_func "
                    gsSql = gsSql & mnFunc & "," & 15 & "," & usuario
                    'dbExecQuery gsSql
                    If objDatasource.EjecutaComandoTransaccion(gsSql) = False Then 'If dbError <> 0 Then
                        MsgBox("No fue posible registrar la información en bitacora.", vbCritical, "Gestores")
                    End If
                    'dbEndQuery
                Else
                    gsSql = "EXEC FUNCIONARIOS..sp_mantenimiento_func "
                    gsSql = gsSql & mnFunc & "," & 16 & "," & usuario
                    'dbExecQuery gsSql
                    If objDatasource.EjecutaComandoTransaccion(gsSql) = False Then 'If dbError <> 0 Then
                        MsgBox("No fue posible registrar la información en bitacora.", vbCritical, "Gestores")
                    End If
                    'dbEndQuery
                End If
                'FIN: Oliva Farias García OFG 09/nov/2016 - Registro de Bitacora de Gestores

                If 0 <> 0 Then 'If dbError <> 0 Then
                    'dbRollback
                    objDatasource.RollbackTransaccion()
                    MsgBox("No fue posible registrar la información para PU.", vbCritical, "Error")
                    Exit Sub
                End If
                'dbEndQuery
            End If

            'dbCommit
            objDatasource.CommitTransaccion()
        End If

        'Actualiza la tabla Funcionario.UNIDAD_ORGAIZACIONAL_RESUMEN
        'ActualizaUnidadOrg mnFunc
    End Sub
    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Dim lbFuncAltaPU As Boolean
        Dim lbFuncBajaPU As Boolean
        Dim lnUnidadOrganizacional As Integer
        Dim lsNumeroFuncionario As String
        Dim lsUnidadOrgBancomer As String
        Dim lsFechaAlta As String
        Dim lnIdTransaccion As Integer
        Dim lnIdTransaccion_002 As Integer
        Dim lnIdTransaccion_100 As Integer
        Dim lnIdTransaccion_000 As Integer
        Dim lnIdTransaccion_687 As Integer
        'wss001 begins
        Dim numFuncionarioPU As String
        'wss001 ends
        'OFG 15/11/2016 INICIO BITACORA MANTENIMIENTO GESTOR
        Dim strValidaEjecucion As String
        Dim strOpciones() As String, i As Integer
        Dim lngOperacion As Long
        'OFG 15/11/2016 FIN BITACORA MANTENIMIENTO GESTOR

        ' OLIVIA FARIAS GARCIA OFG 2016-07-21
        'MODIFICACION PARA QUE ACTUALICE O INSERTE EL REGISTRO TF DEL FUNCIONARIO
        Dim countfunc As Integer
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        'Inicializa a que no se tiene que mandar a la tabla TMP_FUNCIONARIOS_PU
        lbFuncAltaPU = False
        lbFuncBajaPU = False

        'Falta escribir el nombre del Gestor
        If cmbSucursal.SelectedValue <> cmbSucursal1.SelectedValue Then
            MsgBox("Las opciones ''Sucursal'' y ''Terminal Gestor'' no son correctas", vbInformation, "Gestores")
            Exit Sub
        End If


        If Trim(txtNombre.Text) = "" Then
            MsgBox("Falta Indicar el Nombre del Gestor", vbInformation, "Gestores")
            txtNombre.Focus()
            Exit Sub
        End If
        'Falta escribir el apellido paterno
        If Trim(txtApellidoP.Text) = "" Then
            MsgBox("Falta Indicar el Apellido Paterno del Gestor", vbInformation, "Gestores")
            txtApellidoP.Focus()
            Exit Sub
        End If
        'Falta escribir el apellido materno
        If Trim(txtApellidoM.Text) = "" Then
            MsgBox("Falta Indicar el Apellido Materno del Gestor", vbInformation, "Gestores")
            txtApellidoM.Focus()
            Exit Sub
        End If
        'Falta escribir el Teléfono del Gestor
        If Trim(txtTelefono.Text) = "" Then
            MsgBox("Falta Indicar el Teléfono del Gestor", vbInformation, "Gestores")
            txtTelefono.Focus()
            Exit Sub
        End If
        'Falta escribir el Código Postal
        If Trim(txtCP.Text) = "" Then
            MsgBox("Falta Indicar el Código Postal", vbInformation, "Gestores")
            txtCP.Focus()
            Exit Sub
        End If
        'Falta escribir la Calle
        If Trim(txtCalle.Text) = "" Then
            MsgBox("Falta Indicar la Calle", vbInformation, "Gestores")
            txtCalle.Focus()
            Exit Sub
        End If
        'Falta seleccionar la Ubicación
        If cmbUbicacion.SelectedIndex = -1 Then
            MsgBox("Es necesario indicar la ubicación del Gestor.", vbInformation, "Aviso")
            cmbUbicacion.Focus()
            Exit Sub
        End If
        'Falta escribir el número de Gestor
        If Trim(txtNumF.Text) = "" Then
            MsgBox("Falta indicar el número de Gestor.", vbInformation, "Aviso")
            txtNumF.Focus()
            Exit Sub
        End If
        'tiene espacios intermedios
        If InStr(Trim(txtNumF.Text), " ") <> 0 Then
            MsgBox("Es incorrecto el Numero de Gestor", vbCritical, "Gestores")
            txtNumF.Focus()
            Exit Sub
        End If
        'Falta escribir el numero registro
        If Trim(txtNumReg.Text) = "" Then
            MsgBox("Falta Indicar el Numero de Registro", vbInformation, "Gestores")
            txtNumReg.Focus()
            Exit Sub
        End If
        'Falta asignar sucursal a func
        If cmbSucursal.SelectedIndex = -1 Then
            If vbNo = MsgBox("No ha asignado Sucursal al Gestor" & Chr(13) & "¿Desea continuar?", vbYesNo, "Gestores") Then
                cmbSucursal.Focus()
                Exit Sub
            End If
        End If
        'Falta asignar por gestor a func
        If cmbSucursal1.Visible = True Then
            If cmbSucursal1.SelectedIndex = -1 Then
                If vbNo = MsgBox("No ha asignado Terminal Gestor al Gestor" & Chr(13) & "¿Desea continuar?", vbYesNo, "Gestores") Then
                    cmbSucursal1.Focus()
                    Exit Sub
                End If
            End If
        End If
        If (txtFuncCte.Text) <> Trim(txtNumF.Text) Then
            gsSql = "select count(*) from FUNCIONARIOS..FUNCIONARIO WITH (NOLOCK) where numero_funcionario='" & Trim(txtNumF.Text) & "'"
            'verifica que numero_funcionario no este dado de alta
            'dbExecQuerygsSql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
            If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                If CDbl(dtRespConsulta.Rows(0).Item(0)) > 0 Then
                    If vbNo = MsgBox("¿Desea actualizar los datos del Gestor Número: " & Trim(txtNumF.Text) & " ?", vbYesNo, "Gestores") Then Exit Sub
                End If
            End If
            'dbEndQuery
        End If

        If gnUnidadOrg <> mnUnidadAnt Then
            'StatusMessage "Confirme operación de cambio de plaza..."
            If MsgBox("¿Está seguro de cambiar al Gestor de plaza?", vbYesNo + vbQuestion, "Mensaje") = vbNo Then
                'StatusMessage ""
                Exit Sub
            End If
            'StatusMessage ""
        End If

        If chkEstrategico.Checked = True Then
            gsSql = "Select estrategica "
            gsSql = gsSql & "From "
            gsSql = gsSql & "FUNCIONARIOS..UNIDAD_ORGANIZACIONAL WITH (NOLOCK) "
            gsSql = gsSql & "Where unidad_organizacional = " & gnUnidadOrg
            'Verifica que la unidad sea estrategica
            'dbExecQuery gsSql
            'dbGetRecord
            'Se encontro la unidad organizacional
            dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
            If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                'La unidad no es estrategica
                If Val(dtRespConsulta.Rows(0).Item(0)) = 0 Then
                    'dbEndQuery
                    'StatusMessage "Confirme operación de cambio..."
                    If MsgBox("La unidad organizacional asignada no es estrategica. ¿Desea Guardar los Cambios?",
                vbQuestion + vbYesNo, "Guardar Datos") = vbNo Then
                        'StatusMessage ""
                        Exit Sub
                    End If
                    'StatusMessage ""
                End If
                'No se encontro la unidad organizacional
            Else
                'dbEndQuery
                'StatusMessage "Confirme operación de cambio..."
                If MsgBox("No se esta asignando una unidad organizacioal. ¿Desea Guardar los Cambios?",
            vbQuestion + vbYesNo, "Guardar Datos") = vbNo Then
                    'StatusMessage ""
                    Exit Sub
                End If
                'StatusMessage ""
            End If
            'dbEndQuery
        End If

        'Busca la unidad_organizacional y el numero_funcionario antes de actualizarlo
        gsSql = "SELECT "
        gsSql = gsSql & "isnull(unidad_organizacional, 0) as unidad_organizacional, numero_funcionario "
        gsSql = gsSql & "FROM "
        gsSql = gsSql & "FUNCIONARIOS..FUNCIONARIO WITH (NOLOCK) "
        gsSql = gsSql & "WHERE"
        gsSql = gsSql & " funcionario = " & mnFunc
        'dbExecQuery gsSql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
            mnUnidadOrganizacional = dtRespConsulta.Rows(0).Item(0)
            msNumeroFuncionario = dtRespConsulta.Rows(0).Item(1)
        End If
        'dbEndQuery

        'WSS001 Begins
        '    gsSql = "UPDATE FUNCIONARIOTF SET registrotf = '" & txtGestorTF & "' WHERE numero_funcionario = '" & msNumeroFuncionario & "'"
        '    dbExecQuery gsSql
        '
        '    dbEndQuery
        'WSS001 Ends

        'Extrae la sucursal o la plaza
        gsSql = "SELECT "
        gsSql = gsSql & "unidad_org_bancomer "
        gsSql = gsSql & "FROM "
        gsSql = gsSql & "FUNCIONARIOS..UNIDAD_ORGANIZACIONAL WITH (NOLOCK) "
        gsSql = gsSql & "WHERE"
        gsSql = gsSql & " unidad_organizacional = " & mnUnidadOrganizacional
        'dbExecQuery gsSql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
            msUnidadOrgBancomer = dtRespConsulta.Rows(0).Item(0)
        End If
        'dbEndQuery

        gsSql = "Update FUNCIONARIOS..FUNCIONARIO set "
        gsSql = gsSql & "nombre_funcionario = '" & UCase(Trim(txtNombre.Text)) & "', "
        gsSql = gsSql & "apellido_paterno = '" & UCase(Trim(txtApellidoP.Text)) & "', "
        gsSql = gsSql & "apellido_materno = '" & UCase(Trim(txtApellidoM.Text)) & "', "
        gsSql = gsSql & "numero_funcionario = '" & Trim(txtNumF.Text) & "', "
        gsSql = gsSql & "numero_registro = '" & Trim(txtNumReg.Text) & "', "
        gsSql = gsSql & "telefono_funcionario = '" & Trim(txtTelefono.Text) & "', "
        gsSql = gsSql & "fax_funcionario = '" & Trim(txtFax.Text) & "', "
        gsSql = gsSql & "calle_funcionario = '" & Trim(txtCalle.Text) & "', "
        gsSql = gsSql & "colonia_funcionario = '" & Trim(txtColonia.Text) & "', "
        gsSql = gsSql & "cp_funcionario = '" & Trim(txtCP.Text) & "', "
        gsSql = gsSql & "ubicacion = " & cmbUbicacion.SelectedValue.ToString & ", " 'cmbUbicacion.ItemData(cmbUbicacion.ListIndex) & ", "
        gsSql = gsSql & "estrategico = " & Convert.ToInt32(chkEstrategico.Checked) & ", "
        gsSql = gsSql & "bbvab = " & Convert.ToInt32(chkBBVA.Checked) & ", "
        gsSql = gsSql & "unidad_organizacional = " & txtUniOrg.Text & ", "
        'fecha ultima modificacion
        gsSql = gsSql & "fecha_ult_modif = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "', "
        If cmbSucursal.SelectedIndex <> -1 Then
            gsSql = gsSql & "cr_opera = " & cmbSucursal.SelectedValue.ToString & ", " 'cmbSucursal.ItemData(cmbSucursal.ListIndex) & ", "
        Else
            gsSql = gsSql & "cr_opera = null, "
        End If
        If cmbSucursal1.Visible = True Then
            If cmbSucursal1.SelectedIndex <> -1 Then
                gsSql = gsSql & "cr_opera_term = " & cmbSucursal1.SelectedValue.ToString & " " 'cmbSucursal1.ItemData(cmbSucursal1.ListIndex) & " "
            Else
                gsSql = gsSql & "cr_opera_term = null"
            End If
        Else
            If cmbSucursal.Items.Count <> -1 Then
                gsSql = gsSql & "cr_opera_term = " & cmbSucursal.SelectedValue.ToString 'cmbSucursal.ItemData(cmbSucursal.ListIndex)
            Else
                gsSql = gsSql & "cr_opera_term = null"
            End If
        End If
        gsSql = gsSql & " where funcionario = " & mnFunc
        'dbExecQuery gsSql

        If objDatasource.insertar(gsSql) > 0 Then 'If dbError = 0 Then
            '******* Guardo el cambio de unidad organizacional
            If gnUnidadOrg <> mnUnidadAnt Then
                'dbEndQuery
                gsSql = "exec spu_unidad_org_ant " & gnUnidadOrg & ", " & mnFunc
                'dbExecQuery gsSql
                'Valida el resultado de la ejecución del SP
                dtRespConsulta = objDatasource.EjecutaSP(gsSql)
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError <> 0 Then
                    MsgBox("No fue posible modificar los datos del Gestor.", vbCritical, "Error")
                    GoTo FinError
                Else
                    MsgBox("Los datos del Gestor han sido guardados.", vbInformation, "Aviso")
                End If
                'dbEndQuery
            Else
                MsgBox("Los datos del Gestor han sido guardados.", vbInformation, "Aviso")
                'dbEndQuery
            End If
        Else
            MsgBox("No fue posible modificar los datos del Gestor.", vbCritical, "Error")
            GoTo FinError
        End If
        '*******
        'dbEndQuery

        'OLIVIA FARIAS GARCIA OFG 2016-07-21
        'MODIFICACION PARA QUE ACTUALICE O INSERTE EL REGISTRO TF DEL FUNCIONARIO

        If Trim(txtGestorTF.Text) <> "" Then
            numFuncionarioPU = Trim(txtGestorTF.Text)
        Else
            numFuncionarioPU = "M" & txtNumF.Text
        End If

        countfunc = 0
        'Valida si ya existe el registro TF en la tabla de funcionariotf
        gsSql = "select count(*) from funcionarios..FUNCIONARIOTF WITH (NOLOCK) "
        gsSql = gsSql & "WHERE funcionario = " & mnFunc
        'dbExecQuery gsSql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then '
            countfunc = dtRespConsulta.Rows(0).Item(0)
        End If
        If countfunc > 0 Then
            'Actualiza el registro en caso de existir
            gsSql = "UPDATE FUNCIONARIOS..FUNCIONARIOTF SET registrotf = '" & numFuncionarioPU & "', "
            gsSql = gsSql & "Numero_funcionario = '" & txtNumF.Text & "', "
            gsSql = gsSql & "funcionario = " & mnFunc
            gsSql = gsSql & " WHERE funcionario = " & mnFunc
            'dbExecQuery gsSql
            'dbEndQuery
            objDatasource.insertar(gsSql)
        Else
            'inserta el registro completo en caso de no existir
            gsSql = "INSERT INTO funcionarios..FUNCIONARIOTF "
            gsSql = gsSql & "(funcionario,registrotf, numero_funcionario) "
            gsSql = gsSql & "VALUES(" & mnFunc & ",'" & numFuncionarioPU & "',"
            gsSql = gsSql & "'" & txtNumF.Text & "')"
            'dbExecQuery gsSql
            'dbEndQuery
            objDatasource.insertar(gsSql)
        End If
        'dbEndQuery
        'OLIVIA FARIAS GARCIA OFG 2016-07-21
        'PARA QUE ACTUALICE O INSERTE EL REGISTRO TF DEL FUNCIONARIO
        'OFG END

        'INICIO: Oliva Farias García OFG 15/nov/2016 - Registro de Modificaciones de funcionarios en Bitacora de Gestores
        strValidaEjecucion = ValidarEjecucion

        'Mantenimiento TABLA
        If Mid(strValidaEjecucion, 1, 1) = "1" Then
            strOpciones = Split(Mid(strValidaEjecucion, 2), ",")
            For i = 0 To UBound(strOpciones)
                If strOpciones(i) <> 0 Then
                    gsSql = "EXEC FUNCIONARIOS..sp_mantenimiento_func " & mnFunc & "," & strOpciones(i) & "," & usuario
                    'dbExecQuery gsSql
                    dtRespConsulta = objDatasource.EjecutaSP(gsSql)
                    If dtRespConsulta Is Nothing Or dtRespConsulta.Rows.Count <= 0 Then 'If dbError <> 0 Then
                        MsgBox("No fue posible registrar la información en bitacora.", vbCritical, "Gestores")
                    End If
                    'dbEndQuery
                End If
            Next
        End If

        'Se regresa linea comentada al inicio del bloque
        Call cmbFuncs_Click() '***
        'FIN: Oliva Farias García OFG 15/nov/2016 - Registro de Modificaciones de funcionarios en Bitacora de Gestores

        DirectCast(cmbFuncs.SelectedItem, System.Data.DataRowView).Row.ItemArray(0) = lLibreria.LowCaseName(txtNombre.Text) & " " & lLibreria.LowCaseName(txtApellidoP.Text) & " " & lLibreria.LowCaseName(txtApellidoM.Text)
        'Call ActualizaUnidadOrg(mnFunc)

        'Busca la unidad_organizacional y numero_funcionario actualizado
        gsSql = "SELECT "
        gsSql = gsSql & "isnull(unidad_organizacional, 0) as unidad_organizacional, numero_funcionario, isnull(rtrim(convert(char(10), fecha_alta, 105)), '01-01-2000') as fecha_alta "
        gsSql = gsSql & "FROM "
        gsSql = gsSql & "FUNCIONARIOS..FUNCIONARIO WITH (NOLOCK) "
        gsSql = gsSql & "WHERE"
        gsSql = gsSql & " funcionario = " & mnFunc
        'dbExecQuery gsSql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
            lnUnidadOrganizacional = dtRespConsulta.Rows(0).Item(0)
            lsNumeroFuncionario = dtRespConsulta.Rows(0).Item(1)
            lsFechaAlta = dtRespConsulta.Rows(0).Item(2)
        End If
        'dbEndQuery

        'Extrae la sucursal o la plaza
        gsSql = "SELECT "
        gsSql = gsSql & "unidad_org_bancomer "
        gsSql = gsSql & "FROM "
        gsSql = gsSql & "FUNCIONARIOS..UNIDAD_ORGANIZACIONAL WITH (NOLOCK) "
        gsSql = gsSql & "WHERE"
        gsSql = gsSql & " unidad_organizacional = " & lnUnidadOrganizacional
        'dbExecQuery gsSql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
            lsUnidadOrgBancomer = dtRespConsulta.Rows(0).Item(0)
        End If
        'dbEndQuery

        'Si tenía plaza o sucursal
        If msUnidadOrgBancomer <> Nothing Or msUnidadOrgBancomer <> "" Then
            'Tiene plaza o sucursal
            If (lsUnidadOrgBancomer <> Nothing Or lsUnidadOrgBancomer <> "") Then
                'Valida si cambio de plaza o sucursal
                If (msUnidadOrgBancomer <> lsUnidadOrgBancomer) Then
                    lbFuncBajaPU = True
                    lbFuncAltaPU = True
                End If
            End If
        Else
            'No tenía plaza o sucursal y le asignó
            If lsUnidadOrgBancomer <> Nothing Or lsUnidadOrgBancomer <> "" Then lbFuncAltaPU = True
        End If

        'Prende bandera si el numero de funcionario fue modificado
        If msNumeroFuncionario <> lsNumeroFuncionario Then
            lbFuncBajaPU = True
            lbFuncAltaPU = True
            'WSS001 Begins
            'WSS001 Ends
        End If

        lnIdTransaccion_100 = 0
        lnIdTransaccion_000 = 0
        lnIdTransaccion_002 = 0
        lnIdTransaccion_687 = 0

        'cpb 2mzo2006 SQL2000 Cambio de DESARROLLO por la variable BD_TICKET para la tabla TMP_FUNCIONARIOS_PU
        'Valida si tiene que mandar datos a la tabla TMP_FUNCIONARIOS_PU con base a las banderas
        If lbFuncAltaPU Or lbFuncBajaPU Then
            '----------------------------------
            lnIdTransaccion = 0
            'Extrae el Id de la Transacción
            gsSql = "select isnull(max(id_transaccion), 0) as id_transaccion "
            gsSql = gsSql & "from " & "TICKET" & "..TMP_FUNCIONARIOS_PU"
            'dbExecQuery gsSql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
            If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                lnIdTransaccion = dtRespConsulta.Rows(0).Item(0)
            Else
                'ShowDefaultCursor
                MsgBox("No fue posible registrar la información para PU.", vbCritical, "Gestores")
                GoTo FinError
            End If
            'dbEndQuery

            If lbFuncAltaPU Then
                'Inserta registro con datos despues de la actualización para la ALTA

                'Subproducto 0000000002
                lnIdTransaccion = lnIdTransaccion + 1

                gsSql = "Insert into " & "TICKET" & "..TMP_FUNCIONARIOS_PU ("
                gsSql = gsSql & "id_funcionario, "
                gsSql = gsSql & "centro_regional, "
                gsSql = gsSql & "numero_funcionario, "
                gsSql = gsSql & "producto, "
                gsSql = gsSql & "subproducto, "
                gsSql = gsSql & "fecha_alta, "
                gsSql = gsSql & "fecha_baja, "
                gsSql = gsSql & "fecha_ultimo_mant, "
                gsSql = gsSql & "tipo_peticion, "
                gsSql = gsSql & "status_envio, "
                gsSql = gsSql & "id_transaccion, "
                gsSql = gsSql & "tipo) "
                gsSql = gsSql & "VALUES ("
                gsSql = gsSql & mnFunc & ", "                            'id_funcionario
                gsSql = gsSql & "'" & lsUnidadOrgBancomer & "', "        'sucursal/plaza

                'WSS001 Begins
                'gsSql = gsSql & "'M" & lsNumeroFuncionario & "', "       'numero_funcionario
                gsSql = gsSql & "'" & numFuncionarioPU & "', "       'numero_funcionario
                'WSS001 Ends

                gsSql = gsSql & "'10', "                                 'producto
                gsSql = gsSql & "'0000000002', "                         'subproducto
                'cpb 8marzo2006 SQL2000 reasigna lsFechaAlta, si es 01-01-2000 pone la fecha del día
                'If lsFechaAlta <> "01-01-2000" Then
                '    gsSql = gsSql & "'" & Format(CDate(lsFechaAlta), "yyyy-MM-dd") & "',"  'fecha_alta
                'Else
                '    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_hoy
                'End If
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_alta
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"                          'fecha_baja
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"   'fecha_ultimo_mant
                gsSql = gsSql & "'A', "                                  'tipo_peticion
                gsSql = gsSql & "0, "                                    'status_envio
                gsSql = gsSql & lnIdTransaccion & ", "
                gsSql = gsSql & "'M') "

                'Ejecuta la inserción a la bitacora
                'dbExecQuery gsSql
                If objDatasource.insertar(gsSql) <= 0 Then 'If dbError <> 0 Then
                    MsgBox("No fue posible insertar información para actualización en Gestores PU.", vbCritical, "Error")
                    GoTo FinError
                End If

                'dbEndQuery

                lnIdTransaccion_002 = lnIdTransaccion

                'Subproducto 0000000000
                lnIdTransaccion = lnIdTransaccion + 1

                gsSql = "Insert into " & "TICKET" & "..TMP_FUNCIONARIOS_PU ("
                gsSql = gsSql & "id_funcionario, "
                gsSql = gsSql & "centro_regional, "
                gsSql = gsSql & "numero_funcionario, "
                gsSql = gsSql & "producto, "
                gsSql = gsSql & "subproducto, "
                gsSql = gsSql & "fecha_alta, "
                gsSql = gsSql & "fecha_baja, "
                gsSql = gsSql & "fecha_ultimo_mant, "
                gsSql = gsSql & "tipo_peticion, "
                gsSql = gsSql & "status_envio, "
                gsSql = gsSql & "id_transaccion, "
                gsSql = gsSql & "tipo) "
                gsSql = gsSql & "VALUES ("
                gsSql = gsSql & mnFunc & ", "                            'id_funcionario
                gsSql = gsSql & "'" & lsUnidadOrgBancomer & "', "        'sucursal/plaza
                'WSS001 Begins
                'gsSql = gsSql & "'M" & lsNumeroFuncionario & "', "       'numero_funcionario
                gsSql = gsSql & "'" & numFuncionarioPU & "', "       'numero_funcionario
                'WSS001 Ends
                gsSql = gsSql & "'10', "                                 'producto
                gsSql = gsSql & "'0000000000', "                         'subproducto
                'cpb 8marzo2006 SQL2000 reasigna lsFechaAlta, si es 01-01-2000 pone la fecha del día
                'If lsFechaAlta <> "01-01-2000" Then
                '    gsSql = gsSql & "'" & Format(CDate(lsFechaAlta), "yyyy-MM-dd") & "',"  'fecha_alta
                'Else
                '    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_hoy
                'End If
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_alta
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"                          'fecha_baja
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"   'fecha_ultimo_mant
                gsSql = gsSql & "'A', "                                  'tipo_peticion
                gsSql = gsSql & "0, "                                    'status_envio
                gsSql = gsSql & lnIdTransaccion & ", "
                gsSql = gsSql & "'M') "

                'Ejecuta la inserción a la bitacora
                'dbExecQuery gsSql

                If objDatasource.insertar(gsSql) <= 0 Then 'If dbError <> 0 Then
                    MsgBox("No fue posible insertar información para actualización en Gestores PU.", vbCritical, "Error")
                    GoTo FinError
                End If

                'dbEndQuery

                lnIdTransaccion_000 = lnIdTransaccion

                'Subproducto 0000000687
                lnIdTransaccion = lnIdTransaccion + 1

                gsSql = "Insert into " & "TICKET" & "..TMP_FUNCIONARIOS_PU ("
                gsSql = gsSql & "id_funcionario, "
                gsSql = gsSql & "centro_regional, "
                gsSql = gsSql & "numero_funcionario, "
                gsSql = gsSql & "producto, "
                gsSql = gsSql & "subproducto, "
                gsSql = gsSql & "fecha_alta, "
                gsSql = gsSql & "fecha_baja, "
                gsSql = gsSql & "fecha_ultimo_mant, "
                gsSql = gsSql & "tipo_peticion, "
                gsSql = gsSql & "status_envio, "
                gsSql = gsSql & "id_transaccion, "
                gsSql = gsSql & "tipo) "
                gsSql = gsSql & "VALUES ("
                gsSql = gsSql & mnFunc & ", "                            'id_funcionario
                gsSql = gsSql & "'" & lsUnidadOrgBancomer & "', "        'sucursal/plaza
                'WSS001 Begins
                'gsSql = gsSql & "'M" & lsNumeroFuncionario & "', "       'numero_funcionario
                gsSql = gsSql & "'" & numFuncionarioPU & "', "       'numero_funcionario
                'WSS001 Ends
                gsSql = gsSql & "'10', "                                 'producto
                gsSql = gsSql & "'0000000687', "                         'subproducto
                'cpb 8marzo2006 SQL2000 reasigna lsFechaAlta, si es 01-01-2000 pone la fecha del día
                'If lsFechaAlta <> "01-01-2000" Then
                '    gsSql = gsSql & "'" & Format(CDate(lsFechaAlta), "yyyy-MM-dd") & "',"  'fecha_alta
                'Else
                '    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_hoy
                'End If
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_alta
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"                          'fecha_baja
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"   'fecha_ultimo_mant
                gsSql = gsSql & "'A', "                                  'tipo_peticion
                gsSql = gsSql & "0, "                                    'status_envio
                gsSql = gsSql & lnIdTransaccion & ", "
                gsSql = gsSql & "'M') "

                'Ejecuta la inserción a la bitacora
                'dbExecQuery gsSql

                If objDatasource.insertar(gsSql) <= 0 Then 'If dbError <> 0 Then
                    MsgBox("No fue posible insertar información para actualización en Gestores PU.", vbCritical, "Error")
                    GoTo FinError
                End If

                'dbEndQuery

                lnIdTransaccion_687 = lnIdTransaccion

                'Subproducto 0000000100
                lnIdTransaccion = lnIdTransaccion + 1

                gsSql = "Insert into " & "TICKET" & "..TMP_FUNCIONARIOS_PU ("
                gsSql = gsSql & "id_funcionario, "
                gsSql = gsSql & "centro_regional, "
                gsSql = gsSql & "numero_funcionario, "
                gsSql = gsSql & "producto, "
                gsSql = gsSql & "subproducto, "
                gsSql = gsSql & "fecha_alta, "
                gsSql = gsSql & "fecha_baja, "
                gsSql = gsSql & "fecha_ultimo_mant, "
                gsSql = gsSql & "tipo_peticion, "
                gsSql = gsSql & "status_envio, "
                gsSql = gsSql & "id_transaccion, "
                gsSql = gsSql & "tipo) "
                gsSql = gsSql & "VALUES ("
                gsSql = gsSql & mnFunc & ", "                            'id_funcionario
                gsSql = gsSql & "'" & lsUnidadOrgBancomer & "', "        'sucursal/plaza

                'WSS001 Begins
                'gsSql = gsSql & "'M" & lsNumeroFuncionario & "', "       'numero_funcionario
                gsSql = gsSql & "'" & numFuncionarioPU & "', "       'numero_funcionario
                'WSS001 Ends

                gsSql = gsSql & "'10', "                                 'producto
                gsSql = gsSql & "'0000000100', "                         'subproducto
                'cpb 8marzo2006 SQL2000 reasigna lsFechaAlta, si es 01-01-2000 pone la fecha del día
                'If lsFechaAlta <> "01-01-2000" Then
                '    gsSql = gsSql & "'" & Format(CDate(lsFechaAlta), "yyyy-MM-dd") & "',"  'fecha_alta
                'Else
                '    gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_hoy
                'End If
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_alta
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"                          'fecha_baja
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"   'fecha_ultimo_mant
                gsSql = gsSql & "'A', "                                  'tipo_peticion
                gsSql = gsSql & "0, "                                    'status_envio
                gsSql = gsSql & lnIdTransaccion & ", "
                gsSql = gsSql & "'M') "

                'Ejecuta la inserción a la bitacora
                'dbExecQuery gsSql

                If objDatasource.insertar(gsSql) <= 0 Then 'If dbError <> 0 Then
                    MsgBox("No fue posible insertar información para actualización en Gestores PU.", vbCritical, "Error")
                    GoTo FinError
                End If

                'dbEndQuery

                lnIdTransaccion_100 = lnIdTransaccion
            End If

            If lbFuncBajaPU Then
                'Inserta registro con datos antes de la actualización para la BAJA

                'Subproducto 0000000002
                If lnIdTransaccion_002 = 0 Then lnIdTransaccion_002 = lnIdTransaccion + 1

                gsSql = "Insert into " & "TICKET" & "..TMP_FUNCIONARIOS_PU ("
                gsSql = gsSql & "id_funcionario, "
                gsSql = gsSql & "centro_regional, "
                gsSql = gsSql & "numero_funcionario, "
                gsSql = gsSql & "producto, "
                gsSql = gsSql & "subproducto, "
                gsSql = gsSql & "fecha_alta, "
                gsSql = gsSql & "fecha_baja, "
                gsSql = gsSql & "fecha_ultimo_mant, "
                gsSql = gsSql & "tipo_peticion, "
                gsSql = gsSql & "status_envio, "
                gsSql = gsSql & "id_transaccion, "
                gsSql = gsSql & "tipo) "
                gsSql = gsSql & "VALUES ("
                gsSql = gsSql & mnFunc & ", "                           'id_funcionario
                gsSql = gsSql & "'" & msUnidadOrgBancomer & "', "       'sucursal/plaza

                'WSS001 Begins
                'gsSql = gsSql & "'M" & msNumeroFuncionario & "', "       'numero_funcionario
                gsSql = gsSql & "'" & numFuncionarioPU & "', "       'numero_funcionario
                'WSS001 Ends

                gsSql = gsSql & "'10', "                                'producto
                gsSql = gsSql & "'0000000002', "                        'subproducto
                gsSql = gsSql & "'" & Format(CDate(lsFechaAlta), "yyyy-MM-dd") & "'," 'fecha_alta
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_baja
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_ultimo_mant
                gsSql = gsSql & "'B', "                                 'tipo_peticion
                gsSql = gsSql & "0, "                                   'status_envio
                gsSql = gsSql & lnIdTransaccion_002 & ", "
                gsSql = gsSql & "'M') "

                'Ejecuta la inserción a la bitacora
                'dbExecQuery gsSql

                If objDatasource.insertar(gsSql) <= 0 Then 'If dbError <> 0 Then
                    MsgBox("No fue posible insertar información para actualización en Gestores PU.", vbCritical, "Error")
                    GoTo FinError
                End If

                'dbEndQuery

                'Subproducto 0000000000
                If lnIdTransaccion_000 = 0 Then lnIdTransaccion_000 = lnIdTransaccion + 1

                gsSql = "Insert into " & "TICKET" & "..TMP_FUNCIONARIOS_PU ("
                gsSql = gsSql & "id_funcionario, "
                gsSql = gsSql & "centro_regional, "
                gsSql = gsSql & "numero_funcionario, "
                gsSql = gsSql & "producto, "
                gsSql = gsSql & "subproducto, "
                gsSql = gsSql & "fecha_alta, "
                gsSql = gsSql & "fecha_baja, "
                gsSql = gsSql & "fecha_ultimo_mant, "
                gsSql = gsSql & "tipo_peticion, "
                gsSql = gsSql & "status_envio, "
                gsSql = gsSql & "id_transaccion, "
                gsSql = gsSql & "tipo) "
                gsSql = gsSql & "VALUES ("
                gsSql = gsSql & mnFunc & ", "                           'id_funcionario
                gsSql = gsSql & "'" & msUnidadOrgBancomer & "', "       'sucursal/plaza
                'WSS001 Begins
                'gsSql = gsSql & "'M" & msNumeroFuncionario & "', "       'numero_funcionario
                gsSql = gsSql & "'" & numFuncionarioPU & "', "       'numero_funcionario
                'WSS001 Ends
                gsSql = gsSql & "'10', "                                'producto
                gsSql = gsSql & "'0000000000', "                        'subproducto
                gsSql = gsSql & "'" & Format(CDate(lsFechaAlta), "yyyy-MM-dd") & "'," 'fecha_alta
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_baja
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_ultimo_mant
                gsSql = gsSql & "'B', "                                 'tipo_peticion
                gsSql = gsSql & "0, "                                   'status_envio
                gsSql = gsSql & lnIdTransaccion_000 & ", "
                gsSql = gsSql & "'M') "

                'Ejecuta la inserción a la bitacora
                'dbExecQuery gsSql

                If objDatasource.insertar(gsSql) <= 0 Then 'If dbError <> 0 Then
                    MsgBox("No fue posible insertar información para actualización en Gestores PU.", vbCritical, "Error")
                    GoTo FinError
                End If

                'dbEndQuery

                'Subproducto 0000000687
                If lnIdTransaccion_687 = 0 Then lnIdTransaccion_687 = lnIdTransaccion + 1

                gsSql = "Insert into " & "TICKET" & "..TMP_FUNCIONARIOS_PU ("
                gsSql = gsSql & "id_funcionario, "
                gsSql = gsSql & "centro_regional, "
                gsSql = gsSql & "numero_funcionario, "
                gsSql = gsSql & "producto, "
                gsSql = gsSql & "subproducto, "
                gsSql = gsSql & "fecha_alta, "
                gsSql = gsSql & "fecha_baja, "
                gsSql = gsSql & "fecha_ultimo_mant, "
                gsSql = gsSql & "tipo_peticion, "
                gsSql = gsSql & "status_envio, "
                gsSql = gsSql & "id_transaccion, "
                gsSql = gsSql & "tipo) "
                gsSql = gsSql & "VALUES ("
                gsSql = gsSql & mnFunc & ", "                           'id_funcionario
                gsSql = gsSql & "'" & msUnidadOrgBancomer & "', "       'sucursal/plaza
                'WSS001 Begins
                'gsSql = gsSql & "'M" & msNumeroFuncionario & "', "       'numero_funcionario
                gsSql = gsSql & "'" & numFuncionarioPU & "', "       'numero_funcionario
                'WSS001 Ends
                gsSql = gsSql & "'10', "                                'producto
                gsSql = gsSql & "'0000000687', "                        'subproducto
                gsSql = gsSql & "'" & Format(CDate(lsFechaAlta), "yyyy-MM-dd") & "'," 'fecha_alta
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_baja
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_ultimo_mant
                gsSql = gsSql & "'B', "                                 'tipo_peticion
                gsSql = gsSql & "0, "                                   'status_envio
                gsSql = gsSql & lnIdTransaccion_687 & ", "
                gsSql = gsSql & "'M') "

                'Ejecuta la inserción a la bitacora
                'dbExecQuery gsSql

                If objDatasource.insertar(gsSql) <= 0 Then 'If dbError <> 0 Then
                    MsgBox("No fue posible insertar información para actualización en Gestores PU.", vbCritical, "Error")
                    GoTo FinError
                End If

                'dbEndQuery

                'Subproducto 0000000100
                If lnIdTransaccion_100 = 0 Then lnIdTransaccion_100 = lnIdTransaccion + 1

                gsSql = "Insert into " & "TICKET" & "..TMP_FUNCIONARIOS_PU ("
                gsSql = gsSql & "id_funcionario, "
                gsSql = gsSql & "centro_regional, "
                gsSql = gsSql & "numero_funcionario, "
                gsSql = gsSql & "producto, "
                gsSql = gsSql & "subproducto, "
                gsSql = gsSql & "fecha_alta, "
                gsSql = gsSql & "fecha_baja, "
                gsSql = gsSql & "fecha_ultimo_mant, "
                gsSql = gsSql & "tipo_peticion, "
                gsSql = gsSql & "status_envio, "
                gsSql = gsSql & "id_transaccion, "
                gsSql = gsSql & "tipo) "
                gsSql = gsSql & "VALUES ("
                gsSql = gsSql & mnFunc & ", "                           'id_funcionario
                gsSql = gsSql & "'" & msUnidadOrgBancomer & "', "       'sucursal/plaza
                'WSS001 Begins
                'gsSql = gsSql & "'M" & msNumeroFuncionario & "', "       'numero_funcionario
                gsSql = gsSql & "'" & numFuncionarioPU & "', "       'numero_funcionario
                'WSS001 Ends
                gsSql = gsSql & "'10', "                                'producto
                gsSql = gsSql & "'0000000100', "                        'subproducto
                gsSql = gsSql & "'" & Format(CDate(lsFechaAlta), "yyyy-MM-dd") & "'," 'fecha_alta
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_baja
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_ultimo_mant
                gsSql = gsSql & "'B', "                                 'tipo_peticion
                gsSql = gsSql & "0, "                                   'status_envio
                gsSql = gsSql & lnIdTransaccion_100 & ", "
                gsSql = gsSql & "'M') "

                'Ejecuta la inserción a la bitacora
                'dbExecQuery gsSql

                If objDatasource.insertar(gsSql) <= 0 Then 'If dbError <> 0 Then
                    MsgBox("No fue posible insertar información para actualización en Gestores PU.", vbCritical, "Error")
                    GoTo FinError
                End If
                'dbEndQuery

                'INICIO: Oliva Farias García OFG 15/nov/2016 - Registro de Modificaciones de funcionarios en Bitacora de Gestores
                gsSql = "EXEC FUNCIONARIOS..sp_mantenimiento_func "
                gsSql = gsSql & mnFunc & "," & 11 & "," & usuario
                'dbExecQuery gsSql
                dtRespConsulta = objDatasource.EjecutaSP(gsSql)
                If False Then 'If dtRespConsulta Is Nothing Then 'If dbError <> 0 Then
                    MsgBox("No fue posible registrar la información en bitacora.", vbCritical, "Gestores")
                End If
                'dbEndQuery
                'FIN: Oliva Farias García OFG 15/nov/2016 - Registro de Modificaciones de funcionarios en Bitacora de Gestores
            End If
        End If

        cmdGuardar.Enabled = False

        'CPB 18-Julio-2006
        'Actualiza la tabla Funcionario.UNIDAD_ORGAIZACIONAL_RESUMEN para todos los funcionarios
        'ActualizaUnidadOrg

        Exit Sub

FinError:
        'dbEndQuery
        Exit Sub
    End Sub
    'INICIO: Oliva Farias García OFG 15/nov/2016 - Registro de Modificaciones de funcionarios en Bitacora de Gestores
    Private Function ValidarEjecucion() As String
        Dim strMensaje As String
        Dim intMantenimientoN As Integer
        Dim intMantenimientoAP As Integer
        Dim intMantenimientoT As Integer
        Dim intMantenimientoD As Integer
        Dim intMantenimientoNS As Integer
        Dim intMantenimientoNC As Integer
        Dim intMantenimientoPU As Integer
        Dim intMantenimientoCRC As Integer
        Dim intMantenimientoE As Integer
        Dim intMantenimientoB As Integer

        strMensaje = ""

        'Nombre del Funcionario
        If txtNombre.Tag <> "" Then
            strMensaje = "Nombre de Gestor" & vbCrLf & "--------------------------------------" & vbCrLf
            intMantenimientoN = 3
        End If

        'Apellidos del Funcionario
        If txtApellidoP.Tag <> "" Or
        txtApellidoM.Tag <> "" Then
            strMensaje = "Apellidos de Gestor" & vbCrLf & "--------------------------------------" & vbCrLf
            intMantenimientoAP = 4
        End If

        'Telefonos del Funcionario
        If txtTelefono.Tag <> "" Or
        txtFax.Tag <> "" Then
            strMensaje = "Telefonos del Gestor" & vbCrLf & "--------------------------------------" & vbCrLf
            intMantenimientoT = 5
        End If

        'Direccion del Funcionario
        If txtCalle.Tag <> "" Or
        txtColonia.Tag <> "" Or
        txtEstado.Tag <> "" Or
        txtCP.Tag <> "" Or
        cmbUbicacion.Tag <> "" Then
            If strMensaje <> "" Then strMensaje = strMensaje & vbCrLf & "Datos de Dirección" & vbCrLf & "--------------------------------------" & vbCrLf
            If strMensaje = "" Then strMensaje = "Datos de Dirección" & vbCrLf & "--------------------------------------" & vbCrLf

            intMantenimientoD = 6

            If txtCalle.Tag <> "" Then
                strMensaje = strMensaje & "Direccion: Calle" & vbCrLf
            End If
            If txtColonia.Tag <> "" Then
                strMensaje = strMensaje & "Direccion: Colonia" & vbCrLf
            End If
            If txtEstado.Tag <> "" Then
                strMensaje = strMensaje & "Direccion: Estado" & vbCrLf
            End If
            If txtCP.Tag <> "" Then
                strMensaje = strMensaje & "Dirección: C.P." & vbCrLf
            End If
            If cmbUbicacion.Tag <> "" Then
                strMensaje = strMensaje & "Dirección: Ubicación" & vbCrLf
            End If
        End If

        'Nomina sin digito verificador del Funcionario (numero_funcionario)
        If txtNumF.Tag <> "" Then
            strMensaje = "Nomina s/dig. verif." & vbCrLf & "--------------------------------------" & vbCrLf
            intMantenimientoNS = 7
        End If

        'Nomina completa del Funcionario (numero_registro)
        If txtNumReg.Tag <> "" Then
            strMensaje = "Nomina completa de Gestor" & vbCrLf & "--------------------------------------" & vbCrLf
            intMantenimientoNC = 8
        End If

        'Usuario PU del Funcionario (registroTF)
        If txtGestorTF.Tag <> "" Then
            strMensaje = "Usuario PU " & vbCrLf & "--------------------------------------" & vbCrLf
            intMantenimientoPU = 9
        End If

        'Centro Responsable de Contabilizacion del Funcionario (cr_opera
        If cmbSucursal.Tag <> "" Or
       cmbSucursal1.Tag <> "" Then
            If strMensaje <> "" Then strMensaje = strMensaje & vbCrLf & "Por sucursal" & vbCrLf & "--------------------------------------" & vbCrLf
            If strMensaje = "" Then strMensaje = "Por terminal" & vbCrLf & "--------------------------------------" & vbCrLf

            intMantenimientoCRC = 10
        End If

        'Status Estrategico del Funcionario
        If chkEstrategico.Tag <> "" Then
            strMensaje = "Status Estrategico de Gestor" & vbCrLf & "--------------------------------------" & vbCrLf
            intMantenimientoE = 12
        End If

        'Status BBVA del Funcionario
        If chkBBVA.Tag <> "" Then
            strMensaje = "Status BBVA de Gestor" & vbCrLf & "--------------------------------------" & vbCrLf
            intMantenimientoB = 13
        End If


        'Validar que se hayan hecho los mantenimientos
        If intMantenimientoN = 0 And
        intMantenimientoAP = 0 And
        intMantenimientoT = 0 And
        intMantenimientoD = 0 And
        intMantenimientoNS = 0 And
        intMantenimientoNC = 0 And
        intMantenimientoPU = 0 And
        intMantenimientoCRC = 0 And
        intMantenimientoE = 0 And
        intMantenimientoB = 0 Then

            'No se afecto ninguna de los campos para manteniento
            ValidarEjecucion = "0"
        Else
            'Si hubo mantenimientos
            ValidarEjecucion = "1" &
                                intMantenimientoN & "," &
                                intMantenimientoAP & "," &
                                intMantenimientoT & "," &
                                intMantenimientoD & "," &
                                intMantenimientoNS & "," &
                                intMantenimientoNC & "," &
                                intMantenimientoPU & "," &
                                intMantenimientoCRC & "," &
                                intMantenimientoE & "," &
                                intMantenimientoB
        End If
        'FIN: Oliva Farias García OFG 15/nov/2016 - Registro de Modificaciones de funcionarios en Bitacora de Gestores
    End Function
    Private Sub cmbFuncs_Click()

        On Error GoTo errComboFuncs
        '*****************************
        Dim lsElemento As String
        Dim lnIndice As Integer
        Dim lnPadre As Integer
        Dim lnTpUniOrg As Integer
        Dim blTpUniOrg As Boolean
        Dim blTpUniOrg2 As Boolean

        Dim foundRows As DataRow()
        blTpUniOrg = False
        blTpUniOrg2 = True

        Label5.Visible = True
        lblUnidadOrgA.Visible = True 'MERD Visualizar ruta completa
        lblUnidadOrgB.Visible = True
        'Label16.Visible = True
        'Label16.Text = "Unidad Org. Anterior:"
        '*****************************

        mnEstrategico = 2
        'StatusMessage ""
        If cmbFuncs.Items.Count < 0 Then Exit Sub
        'ShowWaitCursor

        'No tiene el numero de Gestor
        '*********************************
        If Trim(txtFuncCte.Text) = "" Then
            gsSql = "Select numero_funcionario from FUNCIONARIOS..FUNCIONARIO WITH (NOLOCK) where "
            gsSql = gsSql & "funcionario = " & cmbFuncs.SelectedValue.ToString 'cmbFuncs.ItemData(cmbFuncs.ListIndex)
            'dbExecQuery gsSql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
            If dtRespConsulta Is Nothing Or dtRespConsulta.Rows.Count <= 0 Then 'If dbError <> 0 Then
                'dbEndQuery
                'ShowDefaultCursor
                MsgBox("No es posible obtener el numero del Gestor.", vbCritical, "Error")
                Exit Sub
            End If
            txtFuncCte.Text = dtRespConsulta.Rows(0).Item(0)
            'dbEndQuery
        End If
        '*********************************

        cmdBorrar.Visible = False

        If (cmbFuncs.Text <> "") Or (Trim(txtFuncCte.Text) <> "") Then
            mnFunc = cmbFuncs.SelectedValue.ToString 'cmbFuncs.ItemData(cmbFuncs.ListIndex)
            gsSql = "Select rtrim(nombre_funcionario), "
            gsSql = gsSql & "rtrim(apellido_paterno), "
            gsSql = gsSql & "rtrim(apellido_materno), "
            gsSql = gsSql & "numero_funcionario, "
            gsSql = gsSql & "numero_registro, "
            gsSql = gsSql & "telefono_funcionario, "
            gsSql = gsSql & "fax_funcionario, "
            gsSql = gsSql & "rtrim(calle_funcionario), "
            gsSql = gsSql & "rtrim(colonia_funcionario), "
            gsSql = gsSql & "ubicacion, "
            gsSql = gsSql & "rtrim(cp_funcionario), "
            gsSql = gsSql & "estrategico, "
            gsSql = gsSql & "activo, "
            gsSql = gsSql & "on_mni, "
            gsSql = gsSql & "on_bsi, "
            gsSql = gsSql & "on_harris, "
            gsSql = gsSql & "bbvab, "
            gsSql = gsSql & "RIGHT('0000000'+LTRIM(CONVERT(VARCHAR(7), funcionario)), 7) as Ticket_id,unidad_organizacional,cr_opera,cr_opera_term "
            gsSql = gsSql & "from FUNCIONARIOS..FUNCIONARIO WITH (NOLOCK) "
            gsSql = gsSql & "where funcionario = " & mnFunc
            'Obtiene los datos del funcionario
            'dbExecQuery gsSql
            'dbGetRecord

            Dim dtRespConsulta2 = objDatasource.RealizaConsulta(gsSql)
            If dtRespConsulta2 IsNot Nothing And dtRespConsulta2.Rows.Count > 0 Then 'If dbError = 0 Then
                Call LimpiaCampos()
                txtNombre.Text = lLibreria.LowCaseName(dtRespConsulta2.Rows(0).Item(0))
                txtApellidoP.Text = lLibreria.LowCaseName(dtRespConsulta2.Rows(0).Item(1))
                txtApellidoM.Text = lLibreria.LowCaseName(dtRespConsulta2.Rows(0).Item(2))
                txtNumF.Text = dtRespConsulta2.Rows(0).Item(3)
                txtFuncCte.Text = dtRespConsulta2.Rows(0).Item(3).PadLeft(8, "0")
                txtNumReg.Text = dtRespConsulta2.Rows(0).Item(4)
                txtTelefono.Text = dtRespConsulta2.Rows(0).Item(5)
                txtFax.Text = dtRespConsulta2.Rows(0).Item(6)
                txtCP.Text = dtRespConsulta2.Rows(0).Item(10)
                txtCalle.Text = dtRespConsulta2.Rows(0).Item(7)
                txtColonia.Text = dtRespConsulta2.Rows(0).Item(8)
                chkEstrategico.Checked = Val(dtRespConsulta2.Rows(0).Item(11))
                mnEstrategico = Val(dtRespConsulta2.Rows(0).Item(11))
                txtTicketId.Text = dtRespConsulta2.Rows(0).Item(17)
                txtUniOrg.Text = dtRespConsulta2.Rows(0).Item(18)
                chkBBVA.Checked = Val(dtRespConsulta2.Rows(0).Item(16))
                If cmbSucursal.DataSource Is Nothing And cmbSucursal1.DataSource Is Nothing Then
                    llena_sucursales_M()
                    llena_sucursales_M1()
                End If
                If dtRespConsulta2.Rows(0).Item(19).ToString <> "" Then
                    foundRows = cmbSucursal.DataSource.Select("cr_opera = " & dtRespConsulta2.Rows(0).Item(19))
                    If foundRows.Length > 0 Then
                        cmbSucursal.SelectedValue = (DirectCast(foundRows, System.Data.DataRow())(0)).ItemArray(0)
                    End If
                Else
                    cmbSucursal.SelectedValue = -1
                End If
                If dtRespConsulta2.Rows(0).Item(20).ToString <> "" Then
                    foundRows = cmbSucursal1.DataSource.Select("cr_opera = " & dtRespConsulta2.Rows(0).Item(20))
                    If foundRows.Length > 0 Then
                        cmbSucursal1.SelectedValue = (DirectCast(foundRows, System.Data.DataRow())(0)).ItemArray(0)
                    End If
                Else
                    cmbSucursal1.SelectedValue = -1
                End If
                Select Case mnModo
                    Case 1
                        If Val(dtRespConsulta2.Rows(0).Item(11)) = 1 Then
                            chkEstrategico.Visible = True
                        Else
                            chkEstrategico.Visible = False
                        End If
                        If Val(dtRespConsulta2.Rows(0).Item(16)) = True Then
                            chkBBVA.Visible = True
                        Else
                            chkBBVA.Visible = False
                        End If
                    Case 2
                        If True Then 'If lLibreria.Permiso("PFUNCALTAEST") Then
                            chkEstrategico.Enabled = True
                        Else
                            chkEstrategico.Enabled = False
                        End If
                        If True Then 'If lLibreria.Permiso("PFUNCALTAEST") Then
                            chkBBVA.Enabled = True
                        Else
                            chkBBVA.Enabled = False
                        End If
                End Select



                '    ' 02-05-2012
                '    'GACC
                '    txtUniGes.text = obtenUniOrg(mnFunc)
                '     '      txtUniGes.text = ""

                'El funcionario esta activo
                If Val(dtRespConsulta2.Rows(0).Item(12)) = 1 Then
                    lblStatusFunc.Visible = False
                    Call HabilitaCampos()
                    'El modo es diferente a consulta
                    If mnModo <> 1 Then
                        'Tiene permiso para cancelar al funcionario
                        If True Then 'If lLibreria.Permiso("PFUNCCANCEL") Then
                            cmdBorrar.Text = "&Anular"
                            cmdBorrar.Enabled = True
                            cmdBorrar.Visible = True
                        End If
                    End If
                    'El funcionario esta inactivo
                Else
                    '*********Renombramos la etiqueta
                    'Label16.Text = "Unidad Org Anterior.:"
                    lblStatusFunc.Visible = True
                    Call DeshabilitaCampos()
                    'El modo es diferente a consulta
                    If mnModo <> 1 Then
                        'Tiene permiso para reactivar al funcionario
                        If True Then 'If lLibreria.Permiso("PFUNCREACTIVA") = True Then
                            cmdBorrar.Text = "&Reactivar"
                            cmdBorrar.Enabled = True
                            cmdBorrar.Visible = True
                        End If
                    End If
                End If
                Dim valor1 = If(dtRespConsulta2.Rows(0).Item(13), 1, 0)
                Dim valor2 = If(dtRespConsulta2.Rows(0).Item(15), 1, 0)
                If valor1 = 1 Then lstSistemas.Items.Add("Mesa de Negocios Internacionales")
                'If Val(dbGetValue(14)) = 1 Then lstSistemas.AddItem "Ticket Houston BSI"
                If valor2 = 1 Then lstSistemas.Items.Add("Ticket Harris")
                If Trim(dtRespConsulta2.Rows(0).Item(9)) <> "" Then
                    gsSql = "Select EDO.descripcion_ubicacion From "
                    gsSql = gsSql & "FUNCIONARIOS..UBICACION CIU, "
                    gsSql = gsSql & "FUNCIONARIOS..UBICACION EDO "
                    gsSql = gsSql & " where CIU.ubicacion= " & Val(dtRespConsulta2.Rows(0).Item(9))
                    gsSql = gsSql & " and CIU.ubicacion_padre=EDO.ubicacion"

                    cmbUbicacion.SelectedValue = dtRespConsulta2.Rows(0).Item(9).ToString
                    mnUnidadAct = cmbUbicacion.SelectedIndex

                    'For lnIndice = 0 To (cmbUbicacion.Items.Count - 1)
                    '    cmbUbicacion.SelectedIndex = lnIndice
                    '    If cmbUbicacion.SelectedValue = Val(dtRespConsulta2.Rows(0).Item(9)) Then
                    '        mnUnidadAct = lnIndice
                    '        chkBBVA.Checked = Val(dtRespConsulta2.Rows(0).Item(16))
                    '        'dbEndQuery
                    '        cmbUbicacion.SelectedIndex = lnIndice
                    '        Exit For
                    '    End If
                    'Next lnIndice
                    'dbEndQuery
                    'dbExecQuery gsSql
                    'dbGetRecord
                    dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
                    If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                        txtEstado.Text = dtRespConsulta.Rows(0).Item(0)
                    Else
                        txtEstado.Text = ""
                    End If
                    'dbEndQuery
                Else
                    mnUnidadAct = 0
                    cmbUbicacion.SelectedIndex = 0
                End If
            Else
                'dbEndQuery
                'ShowDefaultCursor
                MsgBox("No es posible obtener información del Gestor.", vbCritical, "Error")
                Exit Sub
            End If

            '************************************************************************************
            Dim activo As Boolean

            activo = False

            'CPB 18-Julio-2006
            'Actualiza la tabla Funcionario.UNIDAD_ORGAIZACIONAL_RESUMEN para todos los funcionarios
            'ActualizaUnidadOrg

            gsSql = "Select unidad_organizacional, unidad_organizacional_anterior, "
            gsSql = gsSql & "activo from FUNCIONARIOS..FUNCIONARIO WITH (NOLOCK) where funcionario = " & mnFunc
            'dbExecQuery gsSql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
            If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                If dtRespConsulta.Rows(0).Item(0) = 0 Then
                    'lblUnidadOrgA.Visible = False
                    'Label5.Visible = False
                End If
                If dtRespConsulta.Rows(0).Item(1).ToString = "" Then
                    'lblUnidadOrgB.Visible = False
                    'Label16.Visible = False
                Else
                    If InStr(1, Trim(dtRespConsulta.Rows(0).Item(1)), "Gestores Anulados(11)", vbTextCompare) <> 0 Then
                        lblUnidadOrgB.Text = lLibreria.LowCaseName(Trim(dtRespConsulta.Rows(0).Item(1)))
                    Else
                        lblUnidadOrgB.Text = lLibreria.LowCaseName("Root(0)\Bancomer(1)\" & dtRespConsulta.Rows(0).Item(1))
                    End If
                End If
                If dtRespConsulta.Rows(0).Item(2) = 1 Then activo = True
            End If
            'dbEndQuery

            'Obtiene el path de unidades organizacionales
            'cpb 6mzo2006 SQL2000 quitar espacion en la ruta del funcionario
            gsSql = "Select ltrim(rtrim(pla.descripcion_unidad_organizacio))+'('+ltrim(rtrim(pla.unidad_org_bancomer))+')', "
            gsSql = gsSql & "pla.unidad_organizacional_padre, pla.unidad_organizacional "
            gsSql = gsSql & ", fun.unidad_organizacional_anterior From "
            gsSql = gsSql & "FUNCIONARIOS..FUNCIONARIO fun WITH (NOLOCK), "
            gsSql = gsSql & "FUNCIONARIOS..UNIDAD_ORGANIZACIONAL pla WITH (NOLOCK) "
            gsSql = gsSql & "where funcionario = " & mnFunc
            gsSql = gsSql & " and fun.unidad_organizacional = pla.unidad_organizacional"
            'dbExecQuery gsSql
            'dbGetRecord
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
            If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                lnPadre = dtRespConsulta.Rows(0).Item(1)

                gnUnidadOrg = dtRespConsulta.Rows(0).Item(2)
                mnUnidadAnt = gnUnidadOrg

                lblUnidadOrgA.Text = lLibreria.LowCaseName(dtRespConsulta.Rows(0).Item(0))
            Else
                lnPadre = -1
                gnUnidadOrg = txtUniOrg.Text
                lblUnidadOrgA.Text = ""
                'StatusMessage "Error"
                MsgBox("Error al obtener la ruta de unidad organizacional.", vbCritical, "Error")
                'StatusMessage ""
            End If
            'dbEndQuery

            Do While lnPadre <> -1
                'cpb 6mzo2006 SQL2000 quitar espacion en la ruta del funcionario
                gsSql = "Select ltrim(rtrim(descripcion_unidad_organizacio))+'('+ltrim(rtrim(unidad_org_bancomer))+')', "
                'gsSql = gsSql & " unidad_organizacional_padre From "
                gsSql = gsSql & " unidad_organizacional_padre, tipo_unidad_organizacional From "
                gsSql = gsSql & "FUNCIONARIOS..UNIDAD_ORGANIZACIONAL WITH (NOLOCK) "
                gsSql = gsSql & " where unidad_organizacional = " & lnPadre
                If blTpUniOrg Then
                    If blTpUniOrg2 Then
                        gsSql = gsSql & " and  tipo_unidad_organizacional = " & lnTpUniOrg - 1
                        blTpUniOrg2 = False
                    End If
                End If
                blTpUniOrg = True
                'dbExecQuery gsSql
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                    lblUnidadOrgA.Text = lLibreria.LowCaseName(dtRespConsulta.Rows(0).Item(0)) & " \" & lblUnidadOrgA.Text

                    lnPadre = dtRespConsulta.Rows(0).Item(1)
                    lnTpUniOrg = dtRespConsulta.Rows(0).Item(2)
                Else
                    lnPadre = -1
                End If
                'dbEndQuery
            Loop

            If mnModo = 2 Or mnModo = 3 Then
                pnlDatos.Enabled = True
                txtNombre.Focus()
            Else
                txtFuncCte.Focus()
            End If
            '*******************************************
            If mnModo = 1 Then
                If lblUnidadOrgA.Visible = True And lblUnidadOrgB.Visible = True Then
                    If InStr(1, Trim$(lblUnidadOrgA.Text), "Banca Comercial(021)") <> 0 Then
                        cmbSucursal1.Visible = False
                        lblPorGestor.Visible = False
                    Else
                        cmbSucursal1.Visible = True
                        lblPorGestor.Visible = True
                    End If
                ElseIf lblUnidadOrgA.Visible = True Then
                    If InStr(1, Trim$(lblUnidadOrgA.Text), "Banca Comercial(021)") <> 0 Then
                        cmbSucursal1.Visible = False
                        lblPorGestor.Visible = False
                    Else
                        cmbSucursal1.Visible = True
                        lblPorGestor.Visible = True
                    End If
                ElseIf lblUnidadOrgB.Visible = True Then
                    If InStr(1, Trim$(lblUnidadOrgB.Text), "Banca Comercial(021)") <> 0 Then
                        cmbSucursal1.Visible = False
                        lblPorGestor.Visible = False
                    Else
                        cmbSucursal1.Visible = True
                        lblPorGestor.Visible = True
                    End If
                End If
            End If
            '*******************************************
        Else
            txtFuncCte.Text = ""
        End If


        ' ITS,EAG,ODT1,05/10/2011---------------------------------
        gsSql = "SELECT  registrotf FROM FUNCIONARIOS..FUNCIONARIOTF WITH (NOLOCK) WHERE funcionario = " & cmbFuncs.SelectedValue.ToString
        'cmbFuncs.ItemData(cmbFuncs.ListIndex)

        'dbExecQuery gsSql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
            txtGestorTF.Text = dtRespConsulta.Rows(0).Item(0)
        End If


        Call funcionario_BBVB()
        Call funcionario_BBVB1()

        'Oliva Farias García OFG 15/nov/2016 - Registro de Modificaciones de funcionarios en Bitacora de Gestores
        LimpiarTag()
        'FIN: Oliva Farias García OFG 15/nov/2016 - Registro de Modificaciones de funcionarios en Bitacora de Gestores


        '    If mnModo = 2 Then
        '        If lblUnidadOrg.Visible = True And lblUnidadOrg2.Visible = True Then
        '            If InStr(1, Trim$(lblUnidadOrg.Caption), "Banca Comercial(021)") <> 0 Then
        '                cmbSucursal.ListIndex = -1
        '                cmbSucursal1.ListIndex = -1
        '            End If
        '        ElseIf lblUnidadOrg.Visible = True Then
        '            If InStr(1, Trim$(lblUnidadOrg.Caption), "Banca Comercial(021)") <> 0 Then
        '                cmbSucursal.ListIndex = -1
        '                cmbSucursal1.ListIndex = -1
        '            End If
        '        End If
        '    End If
        cmdGuardar.Enabled = False
        If mnModo = 2 Then
            cmdGuardar.Enabled = True
            cmdBorrar.Visible = True
        End If
        If ValidaCuentasAsinadas() Then
            cmbSucursal.Enabled = True
            cmbSucursal1.Enabled = True
            txtUniOrg.Enabled = True
        Else
            MsgBox("El gestor tiene cuentas asignadas.", vbInformation, "Cuentas asignadas")
            cmbSucursal.Enabled = False
            cmbSucursal1.Enabled = False
            txtUniOrg.Enabled = False
        End If
        'ShowDefaultCursor
        Exit Sub
errComboFuncs:
        Resume
        MsgBox(Err.Number & " " & Err.Description, vbCritical, "Error")
    End Sub

    Private Sub cmbUbicacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUbicacion.SelectedIndexChanged
        If cmbUbicacion.DataSource IsNot Nothing Then
            gsSql = "Select EDO.descripcion_ubicacion from "
            gsSql = gsSql & "FUNCIONARIOS..UBICACION CIU, "
            gsSql = gsSql & "FUNCIONARIOS..UBICACION EDO"
            gsSql = gsSql & " where CIU.ubicacion= " & cmbUbicacion.SelectedValue 'cmbUbicacion.ItemData(cmbUbicacion.ListIndex)
            gsSql = gsSql & " and CIU.ubicacion_padre=EDO.ubicacion"
            'dbExecQuery gsSql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
            If dtRespConsulta IsNot Nothing Then 'If dbError = 0 Then
                If dtRespConsulta.Rows.Count > 0 Then
                    txtEstado.Text = dtRespConsulta.Rows(0).Item(0)
                End If
            End If
                'dbEndQuery
            End If
        'If mnUnidadAct <> cmbUbicacion.ListIndex Then
        '    If mbHabilita = True Then cmdGuardar.Enabled = True
        '    'Oliva Farias García OFG 15/nov/2016 - Registro de Modificaciones de funcionarios en Bitacora de Gestores
        '    cmbUbicacion.Tag = "1"
        'End If
    End Sub

    Private Sub cmbSucursal_DropDown(sender As Object, e As EventArgs) Handles cmbSucursal.DropDown
        Dim iValorAnterior = 0
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        iValorAnterior = cmbSucursal.SelectedValue
        Dim sSql = "Select cr_opera,bbvab,nombre_sucursal,sucursal From CATALOGOS..SUCURSAL WITH (NOLOCK) where estrategica =1 and bbvab=1 order by sucursal "
            dtRespConsulta = objDatasource.RealizaConsulta(sSql)
            dtRespConsulta.Columns.Add("DatoMostrado")
            For Each row As DataRow In dtRespConsulta.Rows
                row("DatoMostrado") = row("sucursal") + " " + row("nombre_sucursal")
            Next
            cmbSucursal.DataSource = Nothing
            cmbSucursal.ValueMember = "cr_opera"
            cmbSucursal.DisplayMember = "DatoMostrado"
            cmbSucursal.DataSource = dtRespConsulta
            cmbSucursal.SelectedValue = iValorAnterior
    End Sub
    Private Sub cmbSucursal1_DropDown(sender As Object, e As EventArgs) Handles cmbSucursal1.DropDown
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        Dim iValorAnterior = 0
        iValorAnterior = cmbSucursal1.SelectedValue
        llena_sucursales_M1()
        Dim sSql = "Select cr_opera,bbvab,nombre_sucursal,sucursal From CATALOGOS..SUCURSAL WITH (NOLOCK) where estrategica =1 and bbvab=1 order by sucursal "
        dtRespConsulta = objDatasource.RealizaConsulta(sSql)
        dtRespConsulta.Columns.Add("DatoMostrado")
        For Each row As DataRow In dtRespConsulta.Rows
            row("DatoMostrado") = row("sucursal") + " " + row("nombre_sucursal")
        Next
        cmbSucursal1.DataSource = Nothing
        cmbSucursal1.ValueMember = "cr_opera"
        cmbSucursal1.DisplayMember = "DatoMostrado"
        cmbSucursal1.DataSource = dtRespConsulta
        cmbSucursal1.SelectedValue = iValorAnterior
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        LimpiaCampos()
        txtFuncCte.Text = ""
        txtFuncCte.Enabled = True
        cmbFuncs.Text = ""
        cmbFuncs.DataSource = Nothing
    End Sub
    Private Sub txtUniOrg_LostFocus(sender As Object, e As EventArgs) Handles txtUniOrg.LostFocus
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        cmbSucursal_DropDown(sender, e)
        cmbSucursal1_DropDown(sender, e)
        cmbSucursal.SelectedValue = -1
        cmbSucursal1.SelectedValue = -1
        Dim foundRows = cmbSucursal.DataSource.Select("sucursal =" & txtUniOrg.Text)
        If foundRows.Length > 0 Then
            cmbSucursal.SelectedValue = (DirectCast(foundRows, System.Data.DataRow())(0)).ItemArray(0)
            cmbSucursal1.SelectedValue = (DirectCast(foundRows, System.Data.DataRow())(0)).ItemArray(0)
        Else
            MsgBox("No se encontro el CR.", vbCritical, "Error")
        End If
    End Sub
    Private Sub cmbSucursal_LostFocus(sender As Object, e As EventArgs) Handles cmbSucursal.LostFocus
        Dim sCadenaBuscar As String = cmbSucursal.Text
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        For i As Integer = 0 To cmbSucursal.Items.Count - 1
            cmbSucursal.SelectedIndex = i
            If DirectCast(cmbSucursal.SelectedItem, System.Data.DataRowView).Row.ItemArray(4).ToString.Contains(sCadenaBuscar) Then
                Exit For
            End If
        Next
    End Sub
    Private Sub cmbSucursal1_LostFocus(sender As Object, e As EventArgs) Handles cmbSucursal1.LostFocus
        Dim sCadenaBuscar As String = cmbSucursal1.Text
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        For i As Integer = 0 To cmbSucursal1.Items.Count - 1
            cmbSucursal1.SelectedIndex = i
            If DirectCast(cmbSucursal1.SelectedItem, System.Data.DataRowView).Row.ItemArray(4).ToString.Contains(sCadenaBuscar) Then
                Exit For
            End If
        Next
    End Sub
    Private Function ValidaCuentasAsinadas() As Boolean

        gsSql = "Select rtrim(FU.nombre_funcionario)+' '+rtrim(IsNull(FU.apellido_paterno, Space(0)))+' '+rtrim(IsNull(FU.apellido_materno, Space(0))) as nombre, FU.funcionario, PC.cuenta_cliente "
        gsSql = gsSql & "From FUNCIONARIOS..FUNCIONARIO FU WITH (NOLOCK), CATALOGOS..CLIENTE CT WITH (NOLOCK), TICKET..PRODUCTO_CONTRATADO PC WITH (NOLOCK) "
        gsSql = gsSql & "where FU.numero_funcionario = '" & txtNumF.Text & "' "
        gsSql = gsSql & "And CT.cuenta_cliente = PC.cuenta_cliente "
        gsSql = gsSql & "And CT.agencia = PC.agencia "
        gsSql = gsSql & "And FU.funcionario = CT.funcionario"
        dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count = 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    'Private Sub txtUniOrg_Click(sender As Object, e As EventArgs) Handles txtUniOrg.Click
    '    If ValidaCuentasAsinadas() = False Then
    '        MsgBox("El gestor tiene cuentas asignadas.", vbCritical, "Error")
    '        cmbSucursal.Enabled = False
    '        cmbSucursal1.Enabled = False
    '        txtUniOrg.Enabled = False
    '        cmbFuncs.Focus()
    '    End If
    'End Sub
End Class