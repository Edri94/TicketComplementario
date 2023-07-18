Public Class MantPasswd
    Public ign_Usuario As Integer
    Public sUsuario As String
    Public sPass As String
    Private objDataSourse As New Datasource
    Private objLibreria As New Libreria
    Private Sub MantPasswd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ign_Usuario = iPass_gn_Usuario
        sUsuario = sPass_Usuario
        sPass = sPass_Contraseña
        txtLogin.Text = sUsuario
        txtPasswd.Text = sPass
    End Sub
    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Dim ls_Password As String
        Dim NumAplicacion As String
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        ls_Password = Trim(txtNvoPasswd.Text)
        NumAplicacion = "9"
        'dbBeginTran
        If txtNvoPasswd.Text = txtConfPasswd.Text Then
            If sPass <> txtNvoPasswd.Text Then
                objDataSourse.IniciaTransaccion()
                gs_Sql = "Update " & "Catalogos..USUARIO set "
                gs_Sql = gs_Sql & "fecha_cambio_password = getdate(), "
                gs_Sql = gs_Sql & "fecha_ultimo_acceso = getdate(), "
                gs_Sql = gs_Sql & "password = '" & objLibreria.Encryption(1, ls_Password) & "' "
                gs_Sql = gs_Sql & "where usuario = " & ign_Usuario
                'dbExecQuery gs_Sql
                'If Not IsdbError Then
                If objDataSourse.EjecutaComandoTransaccion(gs_Sql) Then
                    'dbEndQuery
                    gs_Sql = "INSERT INTO TICKET..TKT_HISTORICO_PWD (TKTUSR,TKTPSW,TKTFEP,TKTNET) " &
                        "VALUES ('" & txtLogin.Text & "','" & objLibreria.Encryption(1, ls_Password) & "',getdate(),'" & Environment.MachineName & "')"
                    '"VALUES ('" & txtLogin.text & "','" & Encryption(1, ls_Password) & "',convert(varchar(10),getdate(),110),'" & Environment.MachineName & "')"
                    'dbExecQuery gs_Sql
                    'If Not IsdbError Then
                    '    dbEndQuery
                    If objDataSourse.EjecutaComandoTransaccion(gs_Sql) Then
                        'Registra la modificación en la bitacora
                        gs_Sql = "INSERT INTO " & "Catalogos.dbo.BITACORA_PERFIL_PSW "
                        gs_Sql = gs_Sql & "(usuario, fecha_modificacion, "
                        gs_Sql = gs_Sql & "usuario_valida, aplicacion, nombre_pc, password) "
                        gs_Sql = gs_Sql & "VALUES (" & ign_Usuario & ", getdate(), "
                        gs_Sql = gs_Sql & ign_Usuario & ", " & NumAplicacion
                        gs_Sql = gs_Sql & ", '" & Environment.MachineName & "', '" & objLibreria.Encryption(1, ls_Password) & "')"
                        '    dbExecQuery gs_Sql
                        'If Not IsdbError Then
                        '        dbEndQuery
                        If objDataSourse.EjecutaComandoTransaccion(gs_Sql) Then
                            MsgBox("El Password se Modificó con Éxito", vbInformation, "Aviso")
                            'dbCommit
                            objDataSourse.CommitTransaccion()
                            Me.Close()
                        Else
                            'dbEndQuery
                            MsgBox("La operación no se pudo registrar en la bitácora", vbInformation, "Información")
                            'dbCommit
                            objDataSourse.RollbackTransaccion()
                        End If
                    Else
                        'dbEndQuery
                        MsgBox("No es posible actualizar la base de datos.", vbCritical, "SQL Server Error")
                        'dbRollback
                        objDataSourse.RollbackTransaccion()
                    End If
                    'Unload Me
                Else
                    'dbEndQuery
                    MsgBox("No es posible actualizar la base de datos.", vbCritical, "SQL Server Error")
                    'dbRollback
                    objDataSourse.RollbackTransaccion()
                End If
            Else
                MsgBox("No se puede repetir la contraseña anterior.", vbInformation, "Información")
            End If
        Else
            MsgBox("La nueva contraseña no coincide.", vbInformation, "Información")
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "No se guardarán los cambios") <> vbYes Then Exit Sub
        Me.Close()
    End Sub
End Class