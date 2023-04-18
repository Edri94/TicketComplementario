Imports System.Threading

Public Class frmMantUsr
    Private gsSql As String
    Private objDataSource As New Datasource
    Private dtRespConsulta As DataTable
    Private iRegistrosAfectados As Integer
    Private iUsuarioSelec As Integer
    Private iControl As Integer
    Private Sub frmMantUsr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Centerform Me
        'Cambio de colores
        'CargarColores Me, cambio

        'ShowWaitCursor
        Call LlenaListaUsuarios()
        gsSql = "Select origen_usuario, descripcion_origen"
        gsSql = gsSql & " from CATALOGOS..ORIGEN_USUARIO"
        'dbExecQuery gsSql
        'dbGetRecord
        'Do While dbError = 0
        '    cmbOrigen.AddItem LowCaseName(dbGetValue(1))
        '    cmbOrigen.ItemData(cmbOrigen.NewIndex) = Val(dbGetValue(0))
        '    dbGetRecord
        'Loop
        'dbEndQuery
        dtRespConsulta = objDataSource.RealizaConsulta(gsSql)
        cmbOrigen.ValueMember = "origen_usuario"
        cmbOrigen.DisplayMember = "descripcion_origen"
        cmbOrigen.DataSource = dtRespConsulta
        If cmbOrigen.Items.Count > 0 Then cmbOrigen.SelectedIndex = -1
        gsSql = "Select area_usuario, descripcion"
        gsSql = gsSql & " from CATALOGOS..AREA_USUARIO"
        'dbExecQuery gsSql
        'dbGetRecord
        'Do While dbError = 0
        '    cmbArea.AddItem Trim(dbGetValue(1))
        '    cmbArea.ItemData(cmbArea.NewIndex) = Val(dbGetValue(0))
        '    dbGetRecord
        'Loop
        'dbEndQuery
        dtRespConsulta = objDataSource.RealizaConsulta(gsSql)
        cmbArea.ValueMember = "area_usuario"
        cmbArea.DisplayMember = "descripcion"
        cmbArea.DataSource = dtRespConsulta
        If cmbArea.Items.Count > 0 Then cmbArea.SelectedIndex = -1
        'ShowDefaultCursor
        'Me.Show()
        If Thread.CurrentThread.CurrentCulture.Name = "en-US" Then
            dtpFecha.CustomFormat = "MM-dd-yyyy"
        ElseIf Thread.CurrentThread.CurrentCulture.Name = "es-MX" Then
            dtpFecha.CustomFormat = "dd-MM-yyyy"
        End If
    End Sub
    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir de mantenimiento de usuarios") <> vbYes Then Exit Sub
        Me.Close()
    End Sub
    Private Sub cmbUsuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUsuarios.SelectedIndexChanged
        Dim lnIndex As Byte
        Dim dtRespConsulta1 As DataTable
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        If cmbUsuarios.DataSource IsNot Nothing Then
            cmdAceptar.Enabled = False
            cmdElimina.Enabled = False
            txtNombre.Text = ""
            txtLogin.Text = ""
            'txtFecha = ""
            cmbOrigen.SelectedIndex = -1
            cmbArea.SelectedIndex = -1
            fraDatos.Enabled = False
            dtRespConsulta1 = Nothing
            If cmbUsuarios.SelectedIndex > 0 Then
                'ShowWaitCursor
                fraDatos.Enabled = True
                cmdAceptar.Enabled = True
                cmdElimina.Enabled = True
                gsSql = "Select nombre_usuario, login, "
                gsSql = gsSql & "origen_usuario, area_usuario, "
                gsSql = gsSql & "convert(char(10),fecha_cambio_password,105), "
                gsSql = gsSql & "password, usuario "
                gsSql = gsSql & "from CATALOGOS..USUARIO "
                gsSql = gsSql & "where usuario = " & cmbUsuarios.SelectedValue 'cmbUsuarios.ItemData(cmbUsuarios.ListIndex)
                'dbExecQuery gsSql
                'dbGetRecord
                'ShowDefaultCursor
                dtRespConsulta1 = objDataSource.RealizaConsulta(gsSql)
                'If dbError = 0 Then
                If dtRespConsulta1 IsNot Nothing And dtRespConsulta1.Rows.Count > 0 Then
                    'cmbNombre.Clear
                    'cmbNombre.AddItem LowCaseName(dbGetValue(0))
                    'cmbNombre.ItemData(cmbNombre.NewIndex) = Val(dbGetValue(6))
                    cmbNombre.ValueMember = "usuario"
                    cmbNombre.DisplayMember = "nombre_usuario"
                    cmbNombre.DataSource = dtRespConsulta1
                    cmbNombre.SelectedIndex = 0
                    txtNombre.Text = Trim(dtRespConsulta1.Rows(0).Item(0))
                    txtLogin.Text = Trim(dtRespConsulta1.Rows(0).Item(1))
                    If cmbOrigen.Items.Count > 0 Then
                        'For lnIndex = 0 To cmbOrigen.Items.Count - 1
                        '    If cmbOrigen.ItemData(lnIndex) = Val(dbGetValue(2)) Then
                        '        Exit For
                        '    End If
                        'Next lnIndex
                        cmbOrigen.SelectedValue = dtRespConsulta1.Rows(0).Item(2)
                    End If
                    'If lnIndex < cmbOrigen.ListCount Then
                    '    cmbOrigen.SelectedIndex = lnIndex
                    'End If
                    If cmbArea.Items.Count > 0 Then
                        'For lnIndex = 0 To cmbArea.ListCount - 1
                        '    If cmbArea.ItemData(lnIndex) = Val(dbGetValue(3)) Then
                        '        Exit For
                        '    End If
                        'Next lnIndex
                        cmbArea.SelectedValue = dtRespConsulta1.Rows(0).Item(3)
                    End If
                    'If lnIndex < cmbArea.ListCount Then
                    '    cmbArea.ListIndex = lnIndex
                    'End If
                    dtpFecha.Value = Trim(dtRespConsulta1.Rows(0).Item(4))
                    '            If Trim(dbGetValue(5)) = "BLOQUEAR" Then
                    '                cmdReactivar.Enabled = True
                    '                lblBloqueado.Visible = True
                    '            Else
                    '                cmdReactivar.Enabled = False
                    '                lblBloqueado.Visible = False
                    '            End If

                    If Trim(dtRespConsulta1.Rows(0).Item(5)) = "BLOQUEAR" Then
                        cmdReactivar.Enabled = True
                        lblBloqueado.Visible = True
                        lblBloqueado.Text = "Usuario Bloqueado"
                    ElseIf Trim(dtRespConsulta1.Rows(0).Item(5)) = "ANULADO" Then
                        cmdReactivar.Enabled = True
                        lblBloqueado.Visible = True
                        lblBloqueado.Text = "Usuario Anulado"
                    Else
                        cmdReactivar.Enabled = False
                        lblBloqueado.Visible = False
                    End If

                Else
                    MsgBox("No es posible consultar la base de datos.", vbCritical, "SQL Server Error")
                End If
                'dbEndQuery
            End If
        End If
    End Sub
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    ' Llena la lista de Usuarios disponibles por Base de Datos
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Sub LlenaListaUsuarios()
        Dim ls_sql As String
        Dim dtListaUsuario As DataTable
        If cmbUsuarios.DataSource IsNot Nothing Then
            cmbUsuarios.DataSource.Clear()
        End If
        ls_sql = "select 0 As usuario,'-- Todos los usuarios --' As login union "
        ls_sql = ls_sql & "select usuario, login from " & "CATALOGOS" & ".dbo." & "USUARIO"
        'Requerimiento 27 permitir reactivación de Anulados y Bloqueados.
        If StrComp(Me.Name, "frmMantUsr", vbTextCompare) <> 0 Then
            ls_sql = ls_sql & " where password Not In ('ANULADO','BLOQUEAR') "
        End If
        ls_sql = ls_sql & " order by login"
        dtListaUsuario = objDataSource.RealizaConsulta(ls_sql)
        cmbUsuarios.Visible = True
        cmbUsuarios.DisplayMember = "login"
        cmbUsuarios.ValueMember = "usuario"
        cmbUsuarios.DataSource = dtListaUsuario
    End Sub
    Private Sub cmdElimina_Click(sender As Object, e As EventArgs) Handles cmdElimina.Click
        Dim iRegistrosAfectados As Integer
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        If MsgBox("¿Esta seguro de eliminar al Usuario " & Trim(txtNombre.Text) & "?", vbYesNo + vbQuestion, "Usuarios...") = vbYes Then
Elimina:
            'ShowWaitCursor
            gsSql = "Update CATALOGOS..USUARIO  "
            gsSql = gsSql & "set password = 'ANULADO' "
            gsSql = gsSql & "where usuario = " & cmbUsuarios.SelectedValue 'cmbUsuarios.ItemData(cmbUsuarios.ListIndex)
            'dbExecQuery gsSql
            iRegistrosAfectados = objDataSource.insertar(gsSql)
            'If dbError <> 0 Then
            If iRegistrosAfectados <= 0 Then
                'dbEndQuery
                'ShowDefaultCursor
                If MsgBox("No es posible actualizar la base de datos. ¿Desea reintentar?", vbYesNo + vbCritical, "SQL Server Error") = vbYes Then GoTo Elimina
            Else
                'ShowDefaultCursor
                MsgBox("El Usuario " & Trim(txtNombre.Text) & " ha sido Eliminado.", vbInformation, "Usuarios...")
            End If
            'dbEndQuery
        Else
            Exit Sub
        End If
        cmdAceptar.Enabled = False
        cmdElimina.Enabled = False
        txtNombre.Text = ""
        txtLogin.Text = ""
        'txtFecha.Text = ""
        cmbNombre.DataSource = Nothing
        cmbOrigen.SelectedIndex = -1
        cmbArea.SelectedIndex = -1
        Call LlenaListaUsuarios()
        'cmbUsuarios.SetFocus
    End Sub
    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        If DatosCompletos() = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
Guarda:
        'ShowWaitCursor
        iUsuarioSelec = cmbUsuarios.SelectedValue
        gsSql = "Update CATALOGOS..USUARIO set "
        gsSql = gsSql & "login = '" & Trim(txtLogin.Text) & "', "
        gsSql = gsSql & "nombre_usuario = '" & Trim(txtNombre.Text) & "', "
        gsSql = gsSql & "origen_usuario = " & cmbOrigen.SelectedValue & ", " 'cmbOrigen.ItemData(cmbOrigen.ListIndex) & ", "
        gsSql = gsSql & "fecha_cambio_password = '" & dtpFecha.Value.Year & "-" & dtpFecha.Value.Month & "-" & dtpFecha.Value.Day & " " & DateTime.Now.ToString("hh:mm:ss") & "', "
        gsSql = gsSql & "area_usuario = " & cmbArea.SelectedValue & " " 'cmbArea.ItemData(cmbArea.ListIndex) & " "
        gsSql = gsSql & "where usuario = " & cmbUsuarios.SelectedValue 'cmbUsuarios.ItemData(cmbUsuarios.ListIndex)
        'dbExecQuery gsSql
        iRegistrosAfectados = objDataSource.insertar(gsSql)
        'If dbError <> 0 Then
        If iRegistrosAfectados <= 0 Then
            'dbEndQuery
            'ShowDefaultCursor
            If MsgBox("No es posible actualizar la base de datos. ¿Desea reintentar?", vbYesNo + vbCritical, "SQL Server Error") = vbYes Then GoTo Guarda
        Else
            MsgBox("Los datos del usuario han sido actualizados.", vbInformation, "Actualización...")
        End If
        'dbEndQuery
        'cmbUsuarios.SelectedText = txtLogin.Text
        cmbUsuarios.DataSource.Clear()
        LlenaListaUsuarios()
        cmbUsuarios.SelectedValue = iUsuarioSelec
        'ShowDefaultCursor
    End Sub
    Private Function DatosCompletos() As Boolean

        DatosCompletos = False
        If Trim(txtNombre.Text) = "" Then
            MsgBox("Es necesario especificar el Nombre del Usuario.", vbInformation, "Datos Faltantes...")
            'txtNombre.SetFocus
            Exit Function
        End If
        If Trim(txtLogin.Text) = "" Then
            MsgBox("Es necesario especificar el Login del Usuario.", vbInformation, "Datos Faltantes...")
            'txtLogin.SetFocus
            Exit Function
        End If
        'If Trim(txtFecha) = "" Then
        '    MsgBox("Es necesario especificar la fecha de cambio de password.", vbInformation, "Datos Faltantes...")
        'txtFecha.SetFocus
        '    Exit Function
        'End If
        'If Not EsFechaY2K(txtFecha) Then
        '    MsgBox("La fecha de cambio de password es incorrecta. Utilice formato dd-mm-yyyy.", vbInformation, "Fecha Invalida...")
        'txtFecha.SetFocus
        '    Exit Function
        'End If
        If cmbOrigen.SelectedIndex < 0 Then
            MsgBox("Seleccione el Origen del Usuario.", vbInformation, "Datos Faltantes...")
            'cmbOrigen.SetFocus
            Exit Function
        End If
        If cmbArea.SelectedIndex < 0 Then
            MsgBox("Seleccione el Area del Usuario.", vbInformation, "Datos Faltantes...")
            'cmbArea.SetFocus
            Exit Function
        End If
        'ShowWaitCursor
        gsSql = "Select count(*) from CATALOGOS..USUARIO"
        gsSql = gsSql & " where nombre_usuario = " & "'" & Trim(txtNombre.Text) & "'"
        gsSql = gsSql & " and password <> 'ANULADO'"
        gsSql = gsSql & " and usuario <> " & cmbUsuarios.SelectedValue 'cmbUsuarios.ItemData(cmbUsuarios.ListIndex)
        'dbExecQuery gsSql
        'dbGetRecord
        dtRespConsulta = objDataSource.RealizaConsulta(gsSql)
        If Val(dtRespConsulta.Rows(0).Item(0)) > 0 Then
            'dbEndQuery
            'ShowDefaultCursor
            MsgBox("Ya existe un usuario con el mismo nombre.", vbCritical, "Usuario...")
            'txtNombre.SetFocus
            Exit Function
        End If
        'dbEndQuery
        gsSql = "Select count(*) from CATALOGOS..USUARIO"
        gsSql = gsSql & " where login = " & "'" & Trim(txtLogin.Text) & "'"
        gsSql = gsSql & " and usuario <> " & cmbUsuarios.SelectedValue 'cmbUsuarios.ItemData(cmbUsuarios.ListIndex)
        'dbExecQuery gsSql
        'dbGetRecord
        'ShowDefaultCursor
        dtRespConsulta = objDataSource.RealizaConsulta(gsSql)
        If Val(dtRespConsulta.Rows(0).Item(0)) > 0 Then
            'dbEndQuery
            MsgBox("Ya existe un usuario con el mismo login.", vbCritical, "Usuario...")
            'txtLogin.SetFocus
            Exit Function
        End If
        'dbEndQuery
        DatosCompletos = True
    End Function
    Private Sub cmdReactivar_Click(sender As Object, e As EventArgs) Handles cmdReactivar.Click
        'On Error GoTo ErrReactivar
        Try
            '------------------------------------------------------- RACB 22/03/2023
            Dim objGlobal As New Cursors
            If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
                Exit Sub
            End If
            '------------------------------------------------------- RACB 22/03/2023
actualiza:
            'ShowWaitCursor
            gsSql = "Update CATALOGOS..USUARIO set "
            'BANCO001
            gsSql = gsSql & "password = 'STjeoM@@^Ss\Ua^Ss\Ve', "
            'Sin error de login
            gsSql = gsSql & "login_erroneo = 0 "
            gsSql = gsSql & "where usuario = " & cmbUsuarios.SelectedValue 'cmbUsuarios'cmbUsuarios.ItemData(cmbUsuarios.ListIndex)
            'dbExecQuery gsSql
            iRegistrosAfectados = objDataSource.insertar(gsSql)
            'If dbError <> 0 Then
            If iRegistrosAfectados <= 0 Then
                'dbEndQuery
                'ShowDefaultCursor
                If MsgBox("No es posible actualizar la base de datos. ¿Desea reintentar?", vbYesNo + vbCritical, "SQL Server Error") = vbYes Then
                    GoTo actualiza
                End If
            Else
                MsgBox("El usuario ha sido reactivado con el password 'BANCO001'.", vbInformation, "Actualización...")
                lblBloqueado.Visible = False
                cmdReactivar.Enabled = False
            End If
            'dbEndQuery
            'ShowDefaultCursor
            'If cmdAceptar.Enabled Then
            '    cmdAceptar.SetFocus
            'End If
            cmbUsuarios.DataSource.Clear()
            LlenaListaUsuarios()
            cmbNombre.DataSource.Clear()
            Exit Sub
            'ErrReactivar:
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Private Sub Cambio() 'Handles cmbNombre.SelectedIndexChanged
        Dim lnIndex As Integer = 0
        Dim drvElementos As DataRowView
        'On Error Resume Next
        If 1 > -1 Then
            For lnIndex = 0 To cmbUsuarios.Items.Count - 1
                drvElementos = cmbUsuarios.Items(lnIndex)
                If DirectCast(drvElementos, System.Data.DataRowView).Row.ItemArray(0) = iControl Then
                    Exit For
                End If
            Next lnIndex
            cmbUsuarios.SelectedIndex = lnIndex
            txtNombre.Focus()
        End If
    End Sub
    Private Sub cmbNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbNombre.KeyPress
        'If KeyAscii = 13 Then
        If AscW(e.KeyChar) = CInt(Keys.Enter) Then
            cmdCerrar.Focus()
        Else
            'KeyAscii = Asc(UCase(Chr(KeyAscii)))
            If (cmbNombre.Items.Count > 0) Or ((cmbUsuarios.Text <> "Seleccione un Usuario") And (cmbUsuarios.Text <> "Buscando...")) Then
                cmbUsuarios.Text = "Buscando..."
                cmdAceptar.Enabled = False
                cmdElimina.Enabled = False
                txtNombre.Text = ""
                txtLogin.Text = ""
                'txtFecha = ""
                If cmbNombre.Items.Count > 0 Then
                    cmbNombre.DataSource.Clear()
                End If
                cmbOrigen.SelectedIndex = -1
                cmbArea.SelectedIndex = -1
                fraDatos.Enabled = False
            End If
        End If
    End Sub
    Private Sub cmbNombre_LostFocus(sender As Object, e As EventArgs) Handles cmbNombre.LostFocus
        'If cmbNombre.Items.Count = 0 Then
        If Trim(cmbNombre.Text) <> "" Then
            'If cmbUsuarios.SelectedIndex = -1 Then
            'ShowWaitCursor
            gsSql = "Select nombre_usuario, login, "
            gsSql = gsSql & "origen_usuario, area_usuario, "
            gsSql = gsSql & "convert(char(10),fecha_cambio_password,105), "
            gsSql = gsSql & "password, usuario from "
            gsSql = gsSql & "CATALOGOS..USUARIO where "
            gsSql = gsSql & "nombre_usuario like '%" & Trim(cmbNombre.Text) & "%' "
            'gsSql = gsSql & "and password <> 'ANULADO' "
            dtRespConsulta = objDataSource.RealizaConsulta(gsSql)
            'cmbNombre.ValueMember = "usuario"
            'cmbNombre.DisplayMember = "nombre_usuario"
            If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
                iControl = dtRespConsulta.Rows(0).Item(6)
                Cambio()
            End If
            'cmbNombre.DataSource = dtRespConsulta
            'iControl = 0
            '    dbExecQuery gsSql
            'dbGetRecord
            'Do While dbError = 0
            '    cmbNombre.AddItem LowCaseName(dbGetValue(0))
            'cmbNombre.ItemData(cmbNombre.NewIndex) = Val(dbGetValue(1))
            '    dbGetRecord
            'Loop
            'dbEndQuery
            'ShowDefaultCursor
            If dtRespConsulta.Rows.Count = 0 Then
                MsgBox("No se encontraron usuarios cuyo nombre concuerde con la descripción.", vbInformation, "Usuarios...")
                cmbNombre.Text = ""
                cmbNombre.Focus()
                'ElseIf cmbNombre.Items.Count > 0 Then
                '    cmbNombre.SelectedIndex = -1
                'Else
                '    gsSql = SendMessage(cmbNombre.hWnd, 335, 1, 0)
                '    cmbNombre.Focus()
            End If
            'End If
        End If
        'End If
    End Sub
    Private Sub cmdDesbloquear_Click(sender As Object, e As EventArgs) Handles cmdDesbloquear.Click
        'If cmbUsuarios.SelectedValue > 0 Then
        '    gsSql = " Update catalogos..usuario "
        '    gsSql = gsSql & "set password = (select ultimo_pwd from catalogos..usuario where usuario = " & cmbUsuarios.SelectedValue & "), login_erroneo = 0"
        '    gsSql = gsSql & "where usuario = " & cmbUsuarios.SelectedValue
        '    If objDataSource.insertar(gsSql) > 0 Then
        '        MsgBox("El usuario ha sido desbloqueado con el mismo password.", vbInformation, "Actualización...")
        '        lblBloqueado.Visible = False
        '        cmdReactivar.Enabled = False
        '        cmdDesbloquear.Enabled = False
        '        cmbUsuarios.DataSource.Clear()
        '        LlenaListaUsuarios()
        '        cmbNombre.DataSource.Clear()
        '    End If
        'End If
        If cmbUsuarios.SelectedValue > 0 Then
            '------------------------------------------------------- RACB 22/03/2023
            Dim objGlobal As New Cursors
            If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
                Exit Sub
            End If
            '------------------------------------------------------- RACB 22/03/2023
actualiza:
            'ShowWaitCursor
            Dim strPassword As String
            gs_Sql = "SELECT ultimo_pwd FROM catalogos..usuario where usuario = " & cmbUsuarios.SelectedValue 'cmbUsuarios.ItemData(cmbUsuarios.ListIndex)
            'dbExecQuery gs_Sql
            dtRespConsulta = objDataSource.RealizaConsulta(gs_Sql)
            If dtRespConsulta Is Nothing Or dtRespConsulta.Rows.Count = 0 Then 'If dbError Then
                'dbEndQuery
                'ShowDefaultCursor
                If MsgBox("No es posible obtener el password anterior. ¿Desea reintentar?", vbYesNo + vbCritical, "SQL Server Error") = vbYes Then GoTo actualiza
            Else
                'dbGetRecord
                strPassword = Trim(dtRespConsulta.Rows(0).Item(0).ToString()) 'Trim(dbGetValue(0))
                'dbEndQuery
            End If
            gs_Sql = "Update " & "catalogos..usuario"
            gs_Sql = gs_Sql & " set password = '" & strPassword & "', "
            gs_Sql = gs_Sql & "login_erroneo = 0 "
            'Para que pida cambio de password
            gs_Sql = gs_Sql & "where usuario = " & cmbUsuarios.SelectedValue
            'dbExecQuery gs_Sql
            If objDataSource.insertar(gs_Sql) = 0 Then 'If dbError Then
                'dbEndQuery
                'ShowDefaultCursor
                If MsgBox("No es posible actualizar la base de datos. ¿Desea reintentar?", vbYesNo + vbCritical, "SQL Server Error") = vbYes Then GoTo actualiza
            Else
                'dbEndQuery
                'Registra la modificación en la bitacora
                gs_Sql = "INSERT INTO " & "CATALOGOS..BITACORA_PERFIL_PSW "
                gs_Sql = gs_Sql & "(usuario, fecha_modificacion, "
                gs_Sql = gs_Sql & "usuario_valida, aplicacion, nombre_pc, password) "
                gs_Sql = gs_Sql & "VALUES (" & cmbUsuarios.SelectedValue & ", getdate(), "
                gs_Sql = gs_Sql & usuario & ", " & "9"
                gs_Sql = gs_Sql & ", '" & Environment.MachineName & "', '" & strPassword & "')" 'gs_Sql = gs_Sql & ", '" & gnGetComputerName & "', '" & strPassword & "')"
                'dbExecQuery gs_Sql
                If objDataSource.insertar(gs_Sql) > 0 Then 'If Not IsdbError Then
                    'dbEndQuery
                    MsgBox("El usuario ha sido desbloqueado. Intente con el password anterior.", vbInformation, "Actualización...")
                Else
                    'dbEndQuery
                    MsgBox("El usuario ha sido desbloqueado. Intente con el password anterior, pero no se puedo registrar la operacione en la Bitacora.", vbInformation, "Actualización...")
                End If
                lblBloqueado.Visible = False
            End If
            'MERD 02-12-2008 CAMBIO SOLICITADO POR AUDITORIA ACCIONES DE LOS USUARIOS CON PERFIL DE ADMINSITRADOR
            gs_Sql = "SELECT USUARIO FROM CATALOGOS..USUARIO with(nolock) WHERE LOGIN= "
            gs_Sql = gs_Sql & " '" & Trim(UCase(txtLogin.Text)) & "' "
            'dbExecQuery gs_Sql
            'dbGetRecord
            dtRespConsulta = objDataSource.RealizaConsulta(gs_Sql)
            usuario = Val(dtRespConsulta.Rows(0).Item(0))
            If dtRespConsulta Is Nothing Or dtRespConsulta.Rows.Count = 0 Then 'If dbError Then
                'dbEndQuery
                'ShowDefaultCursor
                If MsgBox("No es posible realizar la consulta del usuario ¿Deseas Continuar?", vbYesNo + vbCritical, "SQL Server Error") = vbYes Then
                    'dbRollback
                Else
                    'dbRollback
                End If
            End If
            gs_Sql = "Insert into CATALOGOS..BITACORA_USUARIO "
            gs_Sql = gs_Sql & "(FECHA_MOVIMIENTO,ESTATUS,Comentario,Usuario,usuario_valida,Aplicacion)"
            gs_Sql = gs_Sql & " values (getdate(),4,'DESBLOQUEO DE USUARIO','" & Trim(UCase(usuario)) & "', "
            gs_Sql = gs_Sql & "'" & Trim(usuario) & "',9) "
            'dbExecQuery gs_Sql
            If objDataSource.insertar(gs_Sql) = 0 Then 'If dbError Then
                'dbEndQuery
                'ShowDefaultCursor
                If MsgBox("No es posible actualizar la base de datos. ¿Desea Reintentar?", vbYesNo + vbCritical, "SQL Server Error") = vbYes Then
                    'dbRollback
                Else
                    'dbRollback
                End If
            End If
            'ShowDefaultCursor
            cmbUsuarios.Focus()
            cmdDesbloquear.Enabled = False
            cmdReactivar.Enabled = False
        End If

    End Sub
End Class