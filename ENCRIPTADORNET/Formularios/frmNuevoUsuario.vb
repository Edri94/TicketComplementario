Public Class frmNuevoUsuario
    Dim objDatasource As New Datasource
    Dim dtRespConsulta As DataTable
    Dim iUsuario As Integer
    Dim UsuarioElim As Integer
    Dim NumAplicacion As Integer
    Private Sub frmNuevoUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Nhouston = False
        'Call Centerform(Me)
        'Call CargarColores(Me, cambio)

        'ShowWaitCursor
        NumAplicacion = 1 '------ RACB 01/04/2022
        txtPassword.Text = "BANCO001"
        txtConfirm.Text = "BANCO001"
        gs_Sql = "Select origen_usuario, descripcion_origen"
        gs_Sql = gs_Sql & " from " & "CATALOGOS..ORIGEN_USUARIO"
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
            cmbOrigen.ValueMember = "origen_usuario"
            cmbOrigen.DisplayMember = "descripcion_origen"
            cmbOrigen.DataSource = dtRespConsulta
            cmbOrigen.SelectedIndex = 0
        End If
        'Do While Not IsdbError
        'cmbOrigen.AddItem LowCaseName(dbGetValue(1))
        'cmbOrigen.ItemData(cmbOrigen.NewIndex) = Val(dbGetValue(0))
        'dbGetRecord
        'Loop
        'dbEndQuery
        'If cmbOrigen.ListCount = 1 Then cmbOrigen.ListIndex = 0
        gs_Sql = "Select area_usuario, descripcion"
        gs_Sql = gs_Sql & " from " & "CATALOGOS..AREA_USUARIO"
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
            cmbArea.ValueMember = "area_usuario"
            cmbArea.DisplayMember = "descripcion"
            cmbArea.DataSource = dtRespConsulta
            cmbArea.SelectedIndex = 0
        End If
        'Do While Not IsdbError
        'cmbArea.AddItem Trim(dbGetValue(1))
        'cmbArea.ItemData(cmbArea.NewIndex) = Val(dbGetValue(0))
        'dbGetRecord
        'Loop
        'dbEndQuery
        'If cmbArea.ListCount = 1 Then cmbArea.ListIndex = 0
        'ShowDefaultCursor
        'Me.Show()
    End Sub
    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Dim ls_Usuario As String
        Dim ls_Password As String
        Dim l As New Libreria
        If cmdGuardar.Text = "&Guardar" Then
            '------------------------------------------------------- RACB 22/03/2023
            Dim objGlobal As New Cursors
            If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
                Exit Sub
            End If
            '------------------------------------------------------- RACB 22/03/2023
            If DatosCompletos() = False Then Exit Sub
IniciaTrans:
            'dbBeginTran
            'ShowWaitCursor
            objDatasource.IniciaTransaccion()
            ls_Password = Trim(txtPassword.Text)
            gs_Sql = "Insert into " & "CATALOGOS..USUARIO "
            gs_Sql = gs_Sql & "(login, password, kapiti, nombre_usuario, origen_usuario, fecha_cambio_password, area_usuario)"
            gs_Sql = gs_Sql & " values ('" & Trim(UCase(txtLogin.Text)) & "', "
            gs_Sql = gs_Sql & "'" & l.Encryption(1, ls_Password) & "', "
            If Trim(txtKapiti.Text) = "" Then
                gs_Sql = gs_Sql & " null, '"
            Else
                gs_Sql = gs_Sql & "'" & Trim(txtKapiti.Text) & "', '"
            End If
            gs_Sql = gs_Sql & Trim(txtNombre.Text) & "', "
            gs_Sql = gs_Sql & cmbOrigen.SelectedValue 'cmbOrigen.ItemData(cmbOrigen.ListIndex)
            gs_Sql = gs_Sql & ", getdate(), "
            gs_Sql = gs_Sql & cmbArea.SelectedValue & ")" 'cmbArea.ItemData(cmbArea.ListIndex) & ")"
            'dbExecQuery gs_Sql
            'DGI 04-07-2007 CAMBIO PARA EL HISTORICO DE PASSWORD
            If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then 'If dbError Then
                'dbEndQuery
                'ShowDefaultCursor
                If MsgBox("No es posible actualizar la base de datos. ¿Desea Reintentar?", vbYesNo + vbCritical, "SQL Server Error") = vbYes Then
                    'dbRollback
                    objDatasource.RollbackTransaccion()
                    GoTo IniciaTrans
                Else
                    'dbRollback
                    objDatasource.RollbackTransaccion()
                End If
            Else
                'MERD 02-12-2008 CAMBIO SOLICITADO POR AUDITORIA ACCIONES DE LOS USUARIOS CON PERFIL DE ADMINSITRADOR
                gs_Sql = "Select USUARIO FROM CATALOGOS..USUARIO with(nolock) WHERE LOGIN= "
                gs_Sql = gs_Sql & " '" & Trim(UCase(txtLogin.Text)) & "' "
                'dbExecQuery gs_Sql
                'dbGetRecord
                'iUsuario = Val(dtRespConsulta.Rows(0).Item(0))
                If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then 'If dbError Then
                    'dbEndQuery
                    'ShowDefaultCursor
                    If MsgBox("No es posible realizar la consulta del usuario ¿Deseas Continuar?", vbYesNo + vbCritical, "SQL Server Error") = vbYes Then
                        'dbRollback
                        objDatasource.RollbackTransaccion()
                        GoTo IniciaTrans
                    Else
                        'dbRollback
                        objDatasource.RollbackTransaccion()
                    End If
                Else
                    iUsuario = Val(iValorTransaccion)
                End If

                gs_Sql = "Insert into CATALOGOS..BITACORA_USUARIO "
                gs_Sql = gs_Sql & "(FECHA_MOVIMIENTO,ESTATUS,Comentario,Usuario,usuario_valida,Aplicacion)"
                gs_Sql = gs_Sql & " values (getdate(),1,'ALTA DE USUARIO','" & Trim(UCase(usuario)) & "', "
                gs_Sql = gs_Sql & "'" & Trim(usuario) & "',1) "
                'dbExecQuery gs_Sql
                If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then 'If dbError Then
                    'dbEndQuery
                    'ShowDefaultCursor
                    If MsgBox("No es posible actualizar la base de datos. ¿Desea Reintentar?", vbYesNo + vbCritical, "SQL Server Error") = vbYes Then
                        'dbRollback
                        objDatasource.RollbackTransaccion()
                        GoTo IniciaTrans
                    Else
                        'dbRollback
                        objDatasource.RollbackTransaccion()
                    End If
                End If

                'INSERCIÓN A LA TABLA DE TKT_HISTORICO_PWD
                gs_Sql = "Insert into TKT_HISTORICO_PWD "
                gs_Sql = gs_Sql & "(TKTUSR, TKTPSW, TKTFEP, TKTNET)"
                gs_Sql = gs_Sql & " values ('" & Trim(UCase(txtLogin.Text)) & "', "
                gs_Sql = gs_Sql & "'" & l.Encryption(1, ls_Password) & "', "
                gs_Sql = gs_Sql & "getdate(), '"
                gs_Sql = gs_Sql & gnGetComputerName() & "')"
                'dbExecQuery gs_Sql
                If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then 'If dbError Then
                    'dbEndQuery
                    'ShowDefaultCursor
                    If MsgBox("No es posible actualizar la base de datos. ¿Desea Reintentar?", vbYesNo + vbCritical, "SQL Server Error") = vbYes Then
                        'dbRollback
                        objDatasource.RollbackTransaccion()
                        GoTo IniciaTrans
                    Else
                        'dbRollback
                        objDatasource.RollbackTransaccion()
                    End If
                Else
                    'dbEndQuery
                    'dbCommit
                    objDatasource.CommitTransaccion()
                    'ShowDefaultCursor
                    MsgBox("El usuario ha sido dado de alta.", vbInformation, "Usuario...")
                    cmdGuardar.Text = "&Nuevo"
                    'txtNombre.Locked = True
                    'txtLogin.Locked = True
                    'txtPassword.Locked = True
                    'txtConfirm.Locked = True
                    'txtKapiti.Locked = True
                    cmbOrigen.Enabled = False
                    cmbArea.Enabled = False
                End If
            End If
        Else
            cmdGuardar.Text = "&Guardar"
            txtNombre.Text = ""
            'txtNombre.Locked = False
            txtLogin.Text = ""
            'txtLogin.Locked = False
            txtPassword.Text = ""
            'txtPassword.Locked = False
            txtConfirm.Text = ""
            'txtConfirm.Locked = False
            txtKapiti.Text = ""
            'txtKapiti.Locked = False
            cmbOrigen.Enabled = True
            cmbOrigen.SelectedIndex = -1
            cmbArea.Enabled = True
            cmbArea.SelectedIndex = -1
            txtNombre.Focus()
        End If
    End Sub
    Private Function DatosCompletos() As Boolean
        DatosCompletos = False
        If Trim(txtNombre.Text) = "" Then
            MsgBox("Es necesario especificar el Nombre del Usuario.", vbInformation, "Datos Faltantes...")
            txtNombre.Focus()
            Exit Function
        End If
        If Trim(txtLogin.Text) = "" Then
            MsgBox("Es necesario especificar el Login del Usuario.", vbInformation, "Datos Faltantes...")
            txtLogin.Focus()
            Exit Function
        End If
        If Trim(txtPassword.Text) = "" Then
            MsgBox("Es necesario especificar el Password del Usuario.", vbInformation, "Datos Faltantes...")
            txtPassword.Focus()
            Exit Function
        End If
        If Len(Trim(txtPassword.Text)) < 7 Then
            MsgBox("El Password debe tener al menos 7 caracteres.", vbInformation, "Aviso")
            txtPassword.Focus()
            Exit Function
        End If
        If Trim(txtPassword.Text) <> Trim(txtConfirm.Text) Then
            MsgBox("El password y su confirmación no coinciden. Escriba el mismo dato en los dos campos.", vbInformation, "Confirmación...")
            txtConfirm.Text = ""
            txtPassword.Text = ""
            txtPassword.Focus()
            Exit Function
        End If
        If cmbOrigen.SelectedIndex < 0 Then
            MsgBox("Seleccione el Origen del Usuario.", vbInformation, "Datos Faltantes...")
            cmbOrigen.Focus()
            Exit Function
        End If
        If cmbArea.SelectedIndex < 0 Then
            MsgBox("Seleccione el Area del Usuario.", vbInformation, "Datos Faltantes...")
            cmbArea.Focus()
            Exit Function
        End If
        'ShowWaitCursor
        gs_Sql = "Select count(*) from " & "CATALOGOS..USUARIO "
        gs_Sql = gs_Sql & " where nombre_usuario = " & "'" & Trim(txtNombre.Text) & "'"
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
            If Val(dtRespConsulta.Rows(0).Item(0)) > 0 Then
                'dbEndQuery
                'ShowDefaultCursor
                MsgBox("Ya existe un usuario con el mismo nombre.", vbCritical, "Usuario...")
                txtNombre.Focus()
                Exit Function
            End If
        End If
        'dbEndQuery
        gs_Sql = "Select count(*) from CATALOGOS..USUARIO "
        gs_Sql = gs_Sql & " where login = " & "'" & Trim(txtLogin.Text) & "'"
        'dbExecQuery gs_Sql
        'dbGetRecord
        'ShowDefaultCursor
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
            If Val(dtRespConsulta.Rows(0).Item(0)) > 0 Then
                'dbEndQuery
                MsgBox("Ya existe un usuario con el mismo login.", vbCritical, "Usuario...")
                If MsgBox("Existe un registro con el mismo Login, ¿Desea reactivar el usuario?", vbYesNo + vbCritical) = vbNo Then
                    txtLogin.Focus()
                    Exit Function
                Else
                    'ShowWaitCursor
                    gs_Sql = "Select usuario from CATALOGOS..USUARIO "
                    gs_Sql = gs_Sql & " where login = " & "'" & Trim(txtLogin.Text) & "' and PASSWORD ='ANULADO'"
                    'dbExecQuery gs_Sql
                    'dbGetRecord
                    dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                    UsuarioElim = Val(dtRespConsulta.Rows(0).Item(0))
                    'ShowDefaultCursor
                    'dbEndQuery
                    gs_Sql = "Update " & "CATALOGOS..usuario  set "
                    'BANCO001
                    gs_Sql = gs_Sql & "password = 'STjeoM@@^Ss\Ua^Ss\Ve', "
                    'Sin error de login
                    gs_Sql = gs_Sql & "login_erroneo = 0 "
                    'Para que pida cambio de password
                    gs_Sql = gs_Sql & ", fecha_cambio_password  = '01-01-1900' "
                    gs_Sql = gs_Sql & "where usuario = " & UsuarioElim
                    'dbExecQuery gs_Sql
                    If objDatasource.insertar(gs_Sql) <= 0 Then 'If dbError Then
                        'dbEndQuery
                        'ShowDefaultCursor
                        If MsgBox("No es posible actualizar la base de datos. ¿Desea reintentar?", vbYesNo + vbCritical, "SQL Server Error") = vbYes Then txtLogin.Focus()
                        Exit Function
                    Else
                        'dbEndQuery
                        'Registra la modificación en la bitacora
                        gs_Sql = "INSERT INTO " & "CATALOGOS.dbo.BITACORA_PERFIL_PSW "
                        gs_Sql = gs_Sql & "(usuario, fecha_modificacion, "
                        gs_Sql = gs_Sql & "usuario_valida, aplicacion, nombre_pc, password) "
                        gs_Sql = gs_Sql & "VALUES (" & iUsuario & ", getdate(), "
                        gs_Sql = gs_Sql & usuario & ", " & NumAplicacion
                        gs_Sql = gs_Sql & ", '" & gnGetComputerName() & "', 'STjeoM@@^Ss\Ua^Ss\Ve')"
                        'dbExecQuery gs_Sql
                        If objDatasource.insertar(gs_Sql) <= 0 Then 'If Not IsdbError Then
                            'dbEndQuery
                            MsgBox("El usuario ha sido reactivado con el password 'BANCO001'.", vbInformation, "Actualización...")
                        Else
                            'dbEndQuery
                            MsgBox("El usuario ha sido reactivado con el password 'BANCO001', pero no se puedo registrar la operacione en la Bitacora.", vbInformation, "Actualización...")
                        End If
                        'MERD 02-12-2008 CAMBIO SOLICITADO POR AUDITORIA ACCIONES DE LOS USUARIOS CON PERFIL DE ADMINSITRADOR
                        gs_Sql = "Insert into CATALOGOS..BITACORA_USUARIO "
                        gs_Sql = gs_Sql & "(FECHA_MOVIMIENTO,ESTATUS,Comentario,Usuario,usuario_valida,Aplicacion)"
                        gs_Sql = gs_Sql & " values (getdate(),7,'ACT. DE USUARIO ELIMINADO','" & Trim(UCase(UsuarioElim)) & "', "
                        gs_Sql = gs_Sql & "'" & Trim(usuario) & "',1) "
                        'dbExecQuery gs_Sql
                        If objDatasource.insertar(gs_Sql) <= 0 Then 'If dbError Then
                            'dbEndQuery
                            'ShowDefaultCursor
                            'If MsgBox("No es posible actualizar la base de datos. ¿Desea Reintentar?", vbYesNo + vbCritical, "SQL Server Error") = vbYes Then
                            '    dbRollback
                            'Else
                            '    dbRollback
                            'End If
                            MsgBox("No es posible actualizar la BITACORA", vbInformation, "SQL Server Error")
                        End If
                        txtLogin.Enabled = False
                        txtNombre.Enabled = False
                        txtKapiti.Enabled = False
                        txtPassword.Enabled = False
                        txtConfirm.Enabled = False
                        cmbOrigen.Enabled = False
                        cmbArea.Enabled = False
                        cmdGuardar.Enabled = False
                        Exit Function
                    End If
                End If
            End If
        End If
        'dbEndQuery
        DatosCompletos = True
    End Function
    '-------------------------------------------------
    'Obtiene la identificacion de la PC bajo la Red
    'Originalmente se encontraba en moddeclaraciones-Mesa y modMiscelaneas - Back
    'Agregada e identada por CEB 20-02-2002
    '-------------------------------------------------
    Public Function gnGetComputerName() As String
        'Dim LsBuffer As String '* 255
        'Dim LnNumChars As Long
        'Dim LnCode As Long

        'LnNumChars = 255
        'LnCode = GetComputerName(LsBuffer, LnNumChars)
        'If LnCode > 0 Then gnGetComputerName = Microsoft.VisualBasic.Left(LsBuffer, LnNumChars)
        Return Environment.MachineName
    End Function
    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir de nuevo usuario") <> vbYes Then
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub
End Class