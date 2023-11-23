Public Class frmReasignaFunc
    Private mnFuncant As Integer
    Private bControcombo As Boolean = True
    Private objDatasource As New Datasource
    Private objLibreria As New Libreria
    Private dtRespConsulta As DataTable
    Private sFuncionarioActual As String '----- RACB 11-07-2023 convivencia APX
    Private Sub txtCuenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCuenta.KeyPress
        'KeyAscii = Filtra(KeyAscii, 1)
        If AscW(e.KeyChar) = CInt(Keys.Enter) Then 'If KeyAscii = vbKeyReturn Then
            cmbCuentas.Focus()
        Else
            If cmbCuentas.Items.Count > 0 Then
                cmbCuentas.DataSource = Nothing
                txtFunc.Text = ""
                fraFunc.Enabled = False
                'cmbFuncs.Clear
                cmbFuncs.DataSource = Nothing
                LimpiaDatos()
            End If
        End If
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
    End Sub
    Private Sub txtCuenta_LostFocus(sender As Object, e As EventArgs) Handles txtCuenta.LostFocus
        If Trim(txtCuenta.Text) = "" Then
            Exit Sub
        End If
        If cmbCuentas.Items.Count > 0 Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        'Screen.MousePointer = vbHourglass
        'BAGO-EDS-10/MZO/06. Uso de IsNull en concatenación de cadenas
        gs_Sql = "Select AG.prefijo_agencia, "
        gs_Sql = gs_Sql & "rtrim(CT.nombre_cliente)+' '+rtrim(IsNull(CT.apellido_paterno, Space(0)))+' '+rtrim(IsNull(CT.apellido_materno, Space(0))), "
        gs_Sql = gs_Sql & "AG.descripcion_agencia, "
        gs_Sql = gs_Sql & "PC.producto_contratado "
        gs_Sql = gs_Sql & ", AG.prefijo_agencia+'-'+CT.cuenta_cliente+' '+rtrim(CT.nombre_cliente)+' '+rtrim(IsNull(CT.apellido_paterno, Space(0)))+' '+rtrim(IsNull(CT.apellido_materno, Space(0)))+' ('+AG.descripcion_agencia+')' as Mostrar " '----- RACB 14/11/2022
        gs_Sql = gs_Sql & "From "
        gs_Sql = gs_Sql & "CATALOGOS" & "..AGENCIA AG, "
        gs_Sql = gs_Sql & "CATALOGOS" & "..CLIENTE CT, "
        gs_Sql = gs_Sql & "PRODUCTO_CONTRATADO PC "
        gs_Sql = gs_Sql & "Where"
        gs_Sql = gs_Sql & " PC.cuenta_cliente = CT.cuenta_cliente"
        gs_Sql = gs_Sql & " and PC.agencia = CT.agencia"
        gs_Sql = gs_Sql & " and AG.agencia = PC.agencia"
        gs_Sql = gs_Sql & " and PC.producto in (2009,3009,8009)"
        gs_Sql = gs_Sql & " and PC.status_producto not in (2039,3039,8039)"
        gs_Sql = gs_Sql & " and CT.cuenta_cliente = '" & txtCuenta.Text & "'"
        'dbExecQuery gs_Sql                        'Busca los clientes existentes con este numero de cuenta
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'Do While Not IsdbError                      'Llena el combo de cuentas con la información encontrada
        'cmbCuentas.AddItem Trim(dbGetValue(0)) & "-" & txtCuenta.Text & "  " & Trim(dbGetValue(1)) & "   (" & LowCaseName(dbGetValue(2)) & ")"
        'cmbCuentas.ItemData(cmbCuentas.NewIndex) = Val(dbGetValue(3))
        'dbGetRecord
        'Loop
        cmbCuentas.ValueMember = "producto_contratado"
        cmbCuentas.DisplayMember = "Mostrar"
        cmbCuentas.DataSource = dtRespConsulta
        'dbEndQuery
        'Screen.MousePointer = vbDefault
        If cmbCuentas.Items.Count = 0 Then          'En caso de no haber cuentas existentes
            MsgBox("No se encontraron clientes con este número de cuenta.", vbInformation, "Cuenta Invalida")
            txtCuenta.Text = ""
            txtCuenta.Focus()
        ElseIf cmbCuentas.Items.Count = 1 Then      'En caso de haber encontrado una sola cuenta
            cmbCuentas.SelectedIndex = 0                'Selecciona la cuenta encontrada
        Else
            'SendMessage cmbCuentas.hWnd, 335, 1, 0  'Despliega el combo de cuentas
            cmbCuentas.SelectedIndex = -1
        End If
    End Sub
    Private Sub txtFunc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFunc.KeyPress
        'KeyAscii = Filtra(KeyAscii, 1)
        If AscW(e.KeyChar) = CInt(Keys.Enter) Then 'If KeyAscii = vbKeyReturn Then
            cmbFuncs.Focus()
        Else
            If cmbFuncs.Items.Count > 0 Then
                'cmbFuncs.Clear
                cmbFuncs.DataSource = Nothing
                LimpiaDatos()
            End If
        End If
    End Sub
    Private Sub txtFunc_LostFocus(sender As Object, e As EventArgs) Handles txtFunc.LostFocus
        If ActiveControl.Name = "cmdSalir" Then
            Exit Sub
        End If
        If Trim$(txtFunc.Text) <> "" Then                    'Se proporciona algun numero de BPIGO
            'Screen.MousePointer = vbHourglass
            'cmbFuncs.Clear
            cmbFuncs.DataSource = Nothing
            gs_Sql = "Exec FUNCIONARIOS..sp_busca_func_dolares '" & Trim(txtFunc.Text) & "', ' '"
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            'dbExecQuery gs_Sql                              'Busca los funcionarios que correspondan al BPIGO
            'dbGetRecord
            'Do While dbError() = 0
            'cmbFuncs.AddItem LowCaseName(dbGetValue(1))
            'cmbFuncs.ItemData(cmbFuncs.NewIndex) = dbGetValue(0)
            'dbGetRecord
            'Loop
            cmbFuncs.ValueMember = "funcionario"
            cmbFuncs.DisplayMember = "nombre"
            cmbFuncs.DataSource = dtRespConsulta
            'dbEndQuery
            'Screen.MousePointer = vbDefault
            If cmbFuncs.Items.Count = 1 Then                'Solo se encontrol un funcionario, lo selecciona
                cmbFuncs.SelectedIndex = 0
            ElseIf cmbFuncs.Items.Count > 1 Then            'Se encontro mas de un funcionario, despliega el combo
                'gs_Sql = SendMessage(cmbFuncs.hWnd, 335, 1, 0)
                cmbFuncs.SelectedIndex = -1
            Else
                MsgBox("No existen Gestores con este número de BPIGO.", vbInformation, "Gestor")
                txtFunc.Text = ""
                txtFunc.Focus()
            End If
        End If
    End Sub
    Private Sub cmbCuentas_Click(sender As Object, e As EventArgs) Handles cmbCuentas.SelectedIndexChanged
        txtFunc.Text = ""
        fraFunc.Enabled = False
        cmbFuncs.DataSource = Nothing
        LimpiaDatos()
        If cmbCuentas.Items.Count = 0 Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        pgbProgreso.Visible = True
        pgbProgreso.Maximum = 10
        pgbProgreso.Value = 2
        If cmbCuentas.SelectedIndex > -1 Then
            'Screen.MousePointer = vbHourglass
            'BAGO-EDS-10/MZO/06. Uso de IsNull en concatenación de cadenas
            gs_Sql = "Select rtrim(FU.nombre_funcionario)+' '+rtrim(IsNull(FU.apellido_paterno, Space(0)))+' '+rtrim(IsNull(FU.apellido_materno, Space(0))) as nombre, "
            gs_Sql = gs_Sql & "FU.funcionario, PC.cuenta_cliente "
            gs_Sql = gs_Sql & "From FUNCIONARIOS..FUNCIONARIO FU, "
            gs_Sql = gs_Sql & "CATALOGOS..CLIENTE CT, PRODUCTO_CONTRATADO PC Where"
            gs_Sql = gs_Sql & " PC.producto_contratado = " & cmbCuentas.SelectedValue 'cmbCuentas.ItemData(cmbCuentas.ListIndex)
            gs_Sql = gs_Sql & " And CT.cuenta_cliente = PC.cuenta_cliente"
            gs_Sql = gs_Sql & " And CT.agencia = PC.agencia"
            gs_Sql = gs_Sql & " And FU.funcionario = CT.funcionario"
            'dbExecQuery gs_Sql                  'Busca el funcionario asignado a la cuenta seleccionada
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            pgbProgreso.Value = 4
            If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If Not IsdbError Then
                bControcombo = False
                'cmbFuncs.AddItem LowCaseName(dbGetValue(0))
                'cmbFuncs.ItemData(cmbFuncs.NewIndex) = Val(dbGetValue(1))
                cmbFuncs.ValueMember = "funcionario"
                cmbFuncs.DisplayMember = "nombre"
                cmbFuncs.DataSource = dtRespConsulta
                mnFuncant = Val(dtRespConsulta.Rows(0).Item(1))
                txtCuenta.Tag = Val(dtRespConsulta.Rows(0).Item(1))
                txtCuenta.Text = Trim$(dtRespConsulta.Rows(0).Item(2))
                pgbProgreso.Value = 6
                sFuncionarioActual = cmbFuncs.SelectedValue.ToString '----- RACB 11-07-2023 convivencia APX
            End If
            'dbEndQuery
            'Screen.MousePointer = vbDefault
            If cmbFuncs.Items.Count = 0 Then      'En caso de no haber encontrado un funcionario
                MsgBox("La cuenta no tiene asignado ningún Gestor.", vbCritical, "Cuenta Invalida")
            Else                                'En caso de haber econtrado al funcionario de la cuenta
                fraFunc.Enabled = True
                cmbFuncs.SelectedIndex = 0            'Se selecciona
            End If
        End If
        bControcombo = True
        pgbProgreso.Value = 10
        pgbProgreso.Visible = False
        pgbProgreso.Value = 0
    End Sub
    Private Sub cmbCuentas_DropDown(sender As Object, e As EventArgs) Handles cmbCuentas.DropDown
        If cmbCuentas.Items.Count > 0 Then
            Exit Sub
        End If
        'Screen.MousePointer = vbHourglass
        'BAGO-EDS-10/MZO/06. Uso de IsNull en concatenación de cadenas
        gs_Sql = "Select AG.prefijo_agencia, "
        gs_Sql = gs_Sql & "rtrim(CT.nombre_cliente)+' '+rtrim(IsNull(CT.apellido_paterno, Space(0)))+' '+rtrim(IsNull(CT.apellido_materno, Space(0))), "
        gs_Sql = gs_Sql & "AG.descripcion_agencia, PC.producto_contratado, "
        gs_Sql = gs_Sql & "PC.cuenta_cliente "
        gs_Sql = gs_Sql & ", AG.prefijo_agencia+'-'+CT.cuenta_cliente+' '+rtrim(CT.nombre_cliente)+' '+rtrim(IsNull(CT.apellido_paterno, Space(0)))+' '+rtrim(IsNull(CT.apellido_materno, Space(0)))+' ('+AG.descripcion_agencia+')' as Mostrar " '----- RACB 14/11/2022
        gs_Sql = gs_Sql & "From "
        gs_Sql = gs_Sql & "CATALOGOS..AGENCIA AG, "
        gs_Sql = gs_Sql & "CATALOGOS..CLIENTE CT, PRODUCTO_CONTRATADO PC "
        gs_Sql = gs_Sql & "Where PC.cuenta_cliente = CT.cuenta_cliente "
        gs_Sql = gs_Sql & "And PC.agencia = CT.agencia "
        gs_Sql = gs_Sql & "And AG.agencia = PC.agencia "
        gs_Sql = gs_Sql & "And PC.producto In ( 2009, 3009, 8009 ) "
        gs_Sql = gs_Sql & "And PC.status_producto Not In ( 2039, 3039, 8039 ) "
        If Trim(cmbCuentas.Text) <> "" Then
            gs_Sql = gs_Sql & "And UPPER(rtrim(CT.nombre_cliente)+' '+rtrim(IsNull(CT.apellido_paterno, Space(0)))+' '+rtrim(IsNull(CT.apellido_materno, Space(0)))) LIKE '%" & UCase(cmbCuentas.Text) & "%' "
        End If
        gs_Sql = gs_Sql & "Order By rtrim(CT.nombre_cliente)+' '+rtrim(IsNull(CT.apellido_paterno, Space(0)))+' '+rtrim(IsNull(CT.apellido_materno, Space(0)))"
        'dbExecQuery gs_Sql                        'Busca los clientes existentes con este numero de cuenta
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'Do While dbError() = 0                      'Llena el combo de cuentas con la información encontrada
        'cmbCuentas.AddItem Trim$(dbGetValue(0)) & "-" & dbGetValue(4) & "  " & Trim$(dbGetValue(1)) & "   (" & LowCaseName(dbGetValue(2)) & ")"
        'cmbCuentas.ItemData(cmbCuentas.NewIndex) = Val(dbGetValue(3))
        'dbGetRecord
        cmbCuentas.ValueMember = "producto_contratado"
        cmbCuentas.DisplayMember = "Mostrar"
        cmbCuentas.DataSource = dtRespConsulta
        'Loop
        'dbEndQuery
        'Screen.MousePointer = vbDefault
        If cmbCuentas.Items.Count = 0 Then          'En caso de no haber cuentas existentes
            If Trim$(cmbCuentas.Text) <> "" Then
                MsgBox("No se encontraron clientes que conicidan con la descripción.", vbInformation, "Cliente No Existente")
                cmbCuentas.Text = ""
            Else
                MsgBox("No es posible leer información de clientes de la base de datos.", vbCritical, "SQL Server Error")
            End If
            cmbCuentas.Focus()
        ElseIf cmbCuentas.Items.Count = 1 Then      'En caso de haber encontrado una sola cuenta
            cmbCuentas.SelectedIndex = 0                'Selecciona la cuenta encontrada
        End If

    End Sub
    Private Sub cmbCuentas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbCuentas.KeyPress
        If AscW(e.KeyChar) = CInt(Keys.Enter) Then 'If KeyAscii = vbKeyReturn Then
            txtCuenta.Focus()
        Else
            If cmbCuentas.Items.Count > 0 Then
                cmbCuentas.DataSource = Nothing
                txtCuenta.Text = ""
                txtCuenta.Tag = 0
                txtFunc.Text = ""
                fraFunc.Enabled = False
                cmbFuncs.DataSource = Nothing
                LimpiaDatos()
            End If
        End If
    End Sub
    Private Sub cmbCuentas_LostFocus(sender As Object, e As EventArgs) Handles cmbCuentas.LostFocus
        If cmbCuentas.Items.Count > 0 Then
            Exit Sub
        End If
        If Trim(cmbCuentas.Text) = "" Then
            Exit Sub
        End If
        'Screen.MousePointer = vbHourglass
        'BAGO-EDS-10/MZO/06. Uso de IsNull en concatenación de cadenas
        gs_Sql = "Select AG.prefijo_agencia, "
        gs_Sql = gs_Sql & "rtrim(CT.nombre_cliente)+' '+rtrim(IsNull(CT.apellido_paterno, Space(0)))+' '+rtrim(IsNull(CT.apellido_materno, Space(0))), "
        gs_Sql = gs_Sql & "AG.descripcion_agencia, PC.producto_contratado, "
        gs_Sql = gs_Sql & "PC.cuenta_cliente "
        gs_Sql = gs_Sql & ", AG.prefijo_agencia+'-'+CT.cuenta_cliente+' '+rtrim(CT.nombre_cliente)+' '+rtrim(IsNull(CT.apellido_paterno, Space(0)))+' '+rtrim(IsNull(CT.apellido_materno, Space(0)))+' ('+AG.descripcion_agencia+')' as Mostrar " '----- RACB 14/11/2022
        gs_Sql = gs_Sql & "From "
        gs_Sql = gs_Sql & "CATALOGOS..AGENCIA AG, "
        gs_Sql = gs_Sql & "CATALOGOS..CLIENTE CT, PRODUCTO_CONTRATADO PC "
        'BAGO-EDS-07/MZO/06. El campo "CT.cuenta_cliente" estaba unido al "And" siguiente. Se adicionó un espacio.
        gs_Sql = gs_Sql & "Where PC.cuenta_cliente = CT.cuenta_cliente "
        gs_Sql = gs_Sql & "And PC.agencia = CT.agencia "
        gs_Sql = gs_Sql & "And AG.agencia = PC.agencia "
        gs_Sql = gs_Sql & "And PC.producto In ( 2009, 3009, 8009 ) "
        gs_Sql = gs_Sql & "And PC.status_producto Not In ( 2039, 3039, 8039 ) "
        gs_Sql = gs_Sql & "And UPPER(rtrim(IsNull(CT.nombre_cliente, Space(0)))+' '+rtrim(IsNull(CT.apellido_paterno, Space(0)))+' '+rtrim(IsNull(CT.apellido_materno, Space(0)))) LIKE '%" & UCase(cmbCuentas.Text) & "%' "
        gs_Sql = gs_Sql & "Order By rtrim(IsNull(CT.nombre_cliente, Space(0)))+' '+rtrim(IsNull(CT.apellido_paterno, Space(0)))+' '+rtrim(IsNull(CT.apellido_materno, Space(0)))"
        'dbExecQuery gs_Sql                        'Busca los clientes existentes con este numero de cuenta
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'Do While dbError() = 0                      'Llena el combo de cuentas con la información encontrada
        'cmbCuentas.AddItem Trim$(dbGetValue(0)) & "-" & dbGetValue(4) & "  " & Trim$(dbGetValue(1)) & "   (" & LowCaseName(dbGetValue(2)) & ")"
        'cmbCuentas.ItemData(cmbCuentas.NewIndex) = Val(dbGetValue(3))
        'dbGetRecord
        'Loop
        cmbCuentas.ValueMember = "producto_contratado"
        cmbCuentas.DisplayMember = "Mostrar"
        cmbCuentas.DataSource = dtRespConsulta
        'dbEndQuery
        'Screen.MousePointer = vbDefault
        If cmbCuentas.Items.Count = 0 Then          'En caso de no haber cuentas existentes
            MsgBox("No se encontraron clientes que conicidan con la descripción.", vbInformation, "Cliente No Existente")
            cmbCuentas.Text = ""
            cmbCuentas.Focus()
        ElseIf cmbCuentas.Items.Count = 1 Then      'En caso de haber encontrado una sola cuenta
            cmbCuentas.SelectedIndex = 0                'Selecciona la cuenta encontrada
        Else
            'SendMessage cmbCuentas.hWnd, 335, 1, 0  'Despliega el combo de cuentas
            cmbCuentas.SelectedIndex = -1
        End If
    End Sub
    Private Sub cmbFuncs_Click(sender As Object, e As EventArgs) Handles cmbFuncs.SelectedIndexChanged
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        If bControcombo Then
            pgbProgreso.Visible = True
            pgbProgreso.Maximum = 10
            Dim lsPadre As String
            txtFunc.Text = ""
            LimpiaDatos()
            If cmbFuncs.Items.Count = 0 Then
                Exit Sub
            End If
            pgbProgreso.Value = 1
            If cmbFuncs.SelectedIndex > -1 Then
                'gs_Sql = "Select numero_funcionario, "
                'gs_Sql = gs_Sql & "telefono_funcionario, "
                'gs_Sql = gs_Sql & "cp_funcionario, "
                'gs_Sql = gs_Sql & "fax_funcionario, "
                'gs_Sql = gs_Sql & "calle_funcionario, "
                'gs_Sql = gs_Sql & "colonia_funcionario, "
                'gs_Sql = gs_Sql & "UB.descripcion_ubicacion, "
                'gs_Sql = gs_Sql & "UP.descripcion_ubicacion, "
                'gs_Sql = gs_Sql & "FU.estrategico "
                'gs_Sql = gs_Sql & "From "
                'gs_Sql = gs_Sql & "FUNCIONARIOS..FUNCIONARIO FU, "
                'gs_Sql = gs_Sql & "FUNCIONARIOS..UBICACION UB, "
                'gs_Sql = gs_Sql & "FUNCIONARIOS..UBICACION UP "
                'gs_Sql = gs_Sql & "Where"
                'gs_Sql = gs_Sql & " funcionario = " & cmbFuncs.SelectedValue 'cmbFuncs.ItemData(cmbFuncs.ListIndex)
                'gs_Sql = gs_Sql & " and UB.ubicacion = FU.ubicacion"
                'gs_Sql = gs_Sql & " and UP.ubicacion =* UB.ubicacion_padre"
                'dbExecQuery gs_Sql                      'Busca los datos del Funcionario
                'dbGetRecord


                gs_Sql = "Select numero_funcionario, telefono_funcionario, cp_funcionario, fax_funcionario, calle_funcionario, colonia_funcionario, UB.descripcion_ubicacion, UP.descripcion_ubicacion, FU.estrategico 
                        From FUNCIONARIOS..FUNCIONARIO FU inner join FUNCIONARIOS..UBICACION UB on UB.ubicacion = FU.ubicacion
								                          right outer join FUNCIONARIOS..UBICACION UP on UP.ubicacion = UB.ubicacion_padre
                        Where funcionario = " & cmbFuncs.SelectedValue

                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                pgbProgreso.Value = 2
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If Not IsdbError Then
                    If Val(cmbFuncs.SelectedValue) <> Val(txtCuenta.Tag) Then 'If Val(cmbFuncs.ItemData(cmbFuncs.ListIndex)) <> Val(txtCuenta.Tag) Then
                        cmdAsignar.Enabled = True
                    Else
                        cmdAsignar.Enabled = False
                    End If
                    '      'GACC
                    '      lblUniGes.Caption = obtenUniOrg(Val(cmbFuncs.ItemData(cmbFuncs.ListIndex)))
                    txtFunc.Text = dtRespConsulta.Rows(0).Item(0)
                    lblTel.Text = dtRespConsulta.Rows(0).Item(1)
                    lblCP.Text = dtRespConsulta.Rows(0).Item(2)
                    lblFax.Text = dtRespConsulta.Rows(0).Item(3)
                    lblCalle.Text = dtRespConsulta.Rows(0).Item(4)
                    lblCol.Text = dtRespConsulta.Rows(0).Item(5)
                    lblUbicacion.Text = objLibreria.LowCaseName(dtRespConsulta.Rows(0).Item(6)) & ", " & objLibreria.LowCaseName(dtRespConsulta.Rows(0).Item(7))
                    If Val(dtRespConsulta.Rows(0).Item(8)) = 1 Then
                        fraFunc.Text = "Gestor Estrategico"
                    End If
                    pgbProgreso.Value = 3
                    'dbEndQuery
                    gs_Sql = "Select UO.unidad_organizacional_padre, "
                    gs_Sql = gs_Sql & "UO.unidad_org_bancomer, "
                    gs_Sql = gs_Sql & "UO.descripcion_unidad_organizacio "
                    gs_Sql = gs_Sql & "From "
                    gs_Sql = gs_Sql & "FUNCIONARIOS..UNIDAD_ORGANIZACIONAL UO, "
                    gs_Sql = gs_Sql & "FUNCIONARIOS..FUNCIONARIO FU "
                    gs_Sql = gs_Sql & "Where"
                    gs_Sql = gs_Sql & " FU.unidad_organizacional = UO.unidad_organizacional"
                    gs_Sql = gs_Sql & " and FU.funcionario = " & cmbFuncs.SelectedValue 'cmbFuncs.ItemData(cmbFuncs.ListIndex)
                    'dbExecQuery gs_Sql                    'Busca la ruta del Funcionario
                    'dbGetRecord
                    dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                    pgbProgreso.Value = 4
                    If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If Not IsdbError Then
                        lsPadre = Trim(dtRespConsulta.Rows(0).Item(0))
                        lblUO.Text = " \(" & Trim(dtRespConsulta.Rows(0).Item(1)) & ") " & objLibreria.LowCaseName(dtRespConsulta.Rows(0).Item(2))
                    End If
                    'dbEndQuery
                    pgbProgreso.Value = 5
                    Do While Val(lsPadre) > 0
                        gs_Sql = "Select unidad_organizacional_padre, "
                        gs_Sql = gs_Sql & "unidad_org_bancomer,"
                        gs_Sql = gs_Sql & "descripcion_unidad_organizacio "
                        gs_Sql = gs_Sql & "From "
                        gs_Sql = gs_Sql & "FUNCIONARIOS..UNIDAD_ORGANIZACIONAL "
                        gs_Sql = gs_Sql & "Where unidad_organizacional = " & lsPadre
                        'dbExecQuery gs_Sql
                        'dbGetRecord
                        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If Not IsdbError Then
                            lsPadre = Trim(dtRespConsulta.Rows(0).Item(0))
                            lblUO.Text = " \(" & Trim(dtRespConsulta.Rows(0).Item(1)) & ") " & objLibreria.LowCaseName(dtRespConsulta.Rows(0).Item(2)) & lblUO.Text
                        End If
                        'dbEndQuery
                    Loop
                    pgbProgreso.Value = 7
                Else
                    MsgBox("No es posible consultar la información del Gestor.", vbCritical, "SQL Server Error")
                End If
                'dbEndQuery
            End If
        End If
        pgbProgreso.Value = 10
        pgbProgreso.Visible = False
        pgbProgreso.Value = 0
    End Sub
    Private Sub cmbFuncs_DropDown(sender As Object, e As EventArgs) Handles cmbFuncs.DropDown
        If Trim(txtFunc.Text) = "" Then                        'No hay numero de BPIGO
            If cmbFuncs.Items.Count = 0 Then                  'No hay datos en el combo
                'Screen.MousePointer = vbHourglass
                gs_Sql = "exec FUNCIONARIOS..sp_busca_func_dolares 'N','%" & UCase(Trim(cmbFuncs.Text)) & "%'"
                'dbExecQuery gs_Sql                            'Busca funcionarios que correspondan con el texto del combo
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                'Do While Not IsdbError
                'cmbFuncs.AddItem LowCaseName(dbGetValue(1))
                'cmbFuncs.ItemData(cmbFuncs.NewIndex) = dbGetValue(0)
                'dbGetRecord
                'Loop
                cmbFuncs.ValueMember = "funcionario"
                cmbFuncs.DisplayMember = "nombre"
                cmbFuncs.DataSource = dtRespConsulta
                'dbEndQuery
                'Screen.MousePointer = vbDefault
                If cmbFuncs.Items.Count = 0 Then                 'No se encontraron funcionario que correspondan con el texto
                    If Trim(cmbFuncs.Text) <> "" Then
                        MsgBox("No se encontraron Gestores bajo esta descripción.", vbInformation, "Gestor")
                        cmbFuncs.Text = ""
                    Else
                        MsgBox("No es posible leer información de Gestores de la base de datos.", vbCritical, "SQL Server Error")
                    End If
                    cmbFuncs.Focus()
                ElseIf cmbFuncs.Items.Count = 1 Then            'En caso de haber encontrado una sola cuenta
                    cmbFuncs.SelectedIndex = 0                      'Selecciona la cuenta encontrada
                End If
            End If
        End If
    End Sub
    Private Sub cmbFuncs_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbFuncs.KeyPress
        If AscW(e.KeyChar) = CInt(Keys.Enter) Then 'If KeyAscii = vbKeyReturn Then
            txtFunc.Focus()
        Else
            If cmbFuncs.Items.Count > 0 Then
                txtFunc.Text = ""
                cmbFuncs.DataSource = Nothing
                LimpiaDatos()
            End If
            'KeyAscii = Asc(UCase(Chr(KeyAscii)))      'Convierte el texto a mayusculas
            'cmbFuncs.Text = cmbFuncs.Text.ToUpper
        End If
    End Sub
    Private Sub cmbFuncs_LostFocus(sender As Object, e As EventArgs) Handles cmbFuncs.LostFocus
        Try
            If cmbFuncs.Items.Count > 0 Then
                Exit Sub
            End If
            If Trim(cmbFuncs.Text) = "" Then
                Exit Sub
            Else
                'gs_Sql = SendMessage(cmbFuncs.hWnd, 335, 1, 0)    'Ejecuta el drop down para buscar funcionarios
                cmbFuncs.SelectedIndex = -1
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LimpiaDatos()
        fraFunc.Text = "Gestor"
        lblTel.Text = ""
        lblCP.Text = ""
        lblFax.Text = ""
        lblCalle.Text = ""
        lblCol.Text = ""
        lblUbicacion.Text = ""
        lblUO.Text = ""
        cmdAsignar.Enabled = False
    End Sub
    Private Sub cmdAsignar_Click(sender As Object, e As EventArgs) Handles cmdAsignar.Click
        Dim lsPrefijo As String
        Dim lsSufijo As String
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        pgbProgreso.Visible = True
        pgbProgreso.Maximum = 10
        If Val(txtCuenta.Text) = 0 Then     'No hay cuenta
            MsgBox("No ha seleccionado una cuenta a la cual asignar el Gestor.", vbInformation, "Cuenta Faltante")
            txtCuenta.Focus()
            Exit Sub
        End If
        pgbProgreso.Value = 1
        If Val(txtFunc.Text) = 0 Then       'No hay funcionario
            MsgBox("Debe seleccionar un Gestor para poder asignarlo a la cuenta.", vbInformation, "Dato Faltante")
            txtFunc.Focus()
            Exit Sub
        End If
        pgbProgreso.Value = 4
        gs_Sql = "Select AG.prefijo_agencia, "
        gs_Sql = gs_Sql & "TC.sufijo_kapiti "
        gs_Sql = gs_Sql & "From "
        gs_Sql = gs_Sql & "CATALOGOS..AGENCIA AG, "
        gs_Sql = gs_Sql & "PRODUCTO_CONTRATADO PC, "
        gs_Sql = gs_Sql & "TIPO_CUENTA_EJE TC, "
        gs_Sql = gs_Sql & "CUENTA_EJE CE "
        gs_Sql = gs_Sql & "Where"
        gs_Sql = gs_Sql & " PC.producto_contratado = " & cmbCuentas.SelectedValue 'cmbCuentas.ItemData(cmbCuentas.ListIndex)
        gs_Sql = gs_Sql & " and CE.producto_contratado = PC.producto_contratado"
        gs_Sql = gs_Sql & " and TC.tipo_cuenta_eje = CE.tipo_cuenta_eje"
        gs_Sql = gs_Sql & " and AG.agencia = PC.agencia"
        'dbExecQuery gs_Sql                  'Busca el prefijo y sufijo de la cuenta
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        pgbProgreso.Value = 6
        If dtRespConsulta Is Nothing And dtRespConsulta.Rows.Count = 0 Then 'If dbError Then
            'dbEndQuery
            MsgBox("No es posible obtener información de la cuenta.", vbCritical, "SQL Server Error")
            Exit Sub
        Else
            lsPrefijo = Trim(dtRespConsulta.Rows(0).Item(0))
            lsSufijo = Trim(dtRespConsulta.Rows(0).Item(1))
        End If
        'dbEndQuery
Reasigna:
        'Screen.MousePointer = vbHourglass
        'dbBeginTran
        objDatasource.IniciaTransaccion()
        gs_Sql = "Update "
        gs_Sql = gs_Sql & "CATALOGOS..CLIENTE set "
        gs_Sql = gs_Sql & "funcionario = " & cmbFuncs.SelectedValue 'cmbFuncs.ItemData(cmbFuncs.ListIndex)
        gs_Sql = gs_Sql & " From "
        gs_Sql = gs_Sql & "CATALOGOS..CLIENTE CL, "
        gs_Sql = gs_Sql & "PRODUCTO_CONTRATADO PC "
        gs_Sql = gs_Sql & "Where"
        gs_Sql = gs_Sql & " PC.producto_contratado = " & cmbCuentas.SelectedValue 'cmbCuentas.ItemData(cmbCuentas.ListIndex)
        gs_Sql = gs_Sql & " and CL.agencia = PC.agencia"
        gs_Sql = gs_Sql & " and CL.cuenta_cliente = PC.cuenta_cliente"
        'dbExecQuery gs_Sql                  'Actualiza el funcionario en la cuenta
        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then 'If dbError Then
            'dbEndQuery
            'Screen.MousePointer = vbDefault
            If MsgBox("Ocurrio un error al intentar asignar al Gestor. ¿Desea reintentar?", vbCritical + vbRetryCancel, "SQL Server Error") = vbRetry Then
                GoTo Reasigna
            Else
                objDatasource.RollbackTransaccion()
                Exit Sub
            End If
        End If
        pgbProgreso.Value = 8
        '-------- RACB 11-07-2023 convivencia APX
        gs_Sql = "INSERT INTO REASIGNAFUNCAPX VALUES (" & cmbCuentas.SelectedValue & "," & sFuncionarioActual & "," & cmbFuncs.SelectedValue & "," & userId & ",GETDATE())"
        objDatasource.EjecutaComandoTransaccion(gs_Sql) '-------- RACB 11-07-2023 convivencia APX
        'dbEndQuery
        If cmbFuncs.SelectedValue <> mnFuncant Then 'If cmbFuncs.ItemData(cmbFuncs.ListIndex) <> mnFuncant Then
            '*** Actualiza liga on_mni de DB Funcionarios Nuevo
            gs_Sql = "Exec FUNCIONARIOS..sp_fun_act_on " & cmbFuncs.SelectedValue & ", 1" 'cmbFuncs.ItemData(cmbFuncs.ListIndex) & ", 1"
            'dbExecQuery gs_Sql
            If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then 'If dbError Then
                'dbRollback
                objDatasource.RollbackTransaccion()
                If MsgBox("An error has ocurred in transaction processing. It is recomended to cancel and to Capture again", vbRetryCancel + vbCritical, "SQL Server Error") = vbRetry Then
                    GoTo Reasigna
                Else
                    Exit Sub
                End If
            End If
            pgbProgreso.Value = 9
            'dbEndQuery
            '*** Actualiza liga on_bsi de DB Funcionarios Anterior
            gs_Sql = "Exec FUNCIONARIOS..sp_fun_act_on " & mnFuncant & ", 1"
            'dbExecQuery gs_Sql
            If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then 'If dbError Then
                'dbRollback
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                If MsgBox("An error has ocurred in transaction processing. It is recomended to cancel and to Capture again", vbRetryCancel + vbCritical, "SQL Server Error") = vbRetry Then
                    GoTo Reasigna
                Else
                    Exit Sub
                End If
            End If
        End If
        'dbEndQuery
        'dbCommit
        objDatasource.CommitTransaccion()
        'gs_Sql = "exec " & DEFAULT_SRVRKYC & ".dbo.sp_a_kyc_reasignacion "
        'gs_Sql = gs_Sql & "'" & lsPrefijo & "', "
        'gs_Sql = gs_Sql & "'" & Trim(txtCuenta.Text) & "', "
        'gs_Sql = gs_Sql & "'" & lsSufijo & "', "
        'gs_Sql = gs_Sql & cmbFuncs.SelectedValue 'cmbFuncs.ItemData(cmbFuncs.ListIndex)
        ''dbExecQuery gs_Sql                  'Envia los datos de reasignación a KYC
        'dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError Then
        '    MsgBox("No es posible actualizar la información en KYC. Notifique al departamento de sistemas.", vbInformation, "Reasignación KYC")
        'End If
        'dbEndQuery
        'Screen.MousePointer = vbDefault
        txtCuenta.Tag = cmbFuncs.SelectedValue 'cmbFuncs.ItemData(cmbFuncs.ListIndex)
        cmdAsignar.Enabled = False
        pgbProgreso.Value = 10
        MsgBox("La asignacion termino de forma correcta.", vbInformation, "Asignacion correcta")
        pgbProgreso.Visible = False
        pgbProgreso.Value = 0
    End Sub
    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir de Reasignación de Gestores") <> vbYes Then Exit Sub
        Me.Close()
    End Sub
End Class