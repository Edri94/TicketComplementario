Imports System.Threading

Public Class Login

    Public bLogin As Boolean
    Private Sub btAceptar_Click(sender As Object, e As EventArgs) Handles btAceptar.Click
        'En el este boton se realiza la funcionalidad de validar el login para entrar a la pantalla principal de Ticket Electronico Contingencia **********

        Dim d As New Datasource
        Dim l As New Libreria

        Dim dtlogin As New DataTable
        Dim dtPermAutor As New DataTable
        Dim validaLogin As Integer
        Dim sPermiso0 As String
        Dim sPermiso1 As String
        Dim sPermiso2 As String
        Dim sPermiso3 As String

        bLogin = False

        If My.Computer.Network.IsAvailable = False Then
            MsgBox("EL EQUIPO NO TIENE CONEXION DE RED")
            Exit Sub
        Else

            If Not DatosCorrectos() Then
                Exit Sub
            End If

            dtlogin = d.login(txLogin.Text.Trim(), txPass.Text.Trim()) 'Funcion que realiza la validacion de login en dase de datos

            validaLogin = dtlogin.Rows.Count
            nameUser = txLogin.Text.Trim()

            If validaLogin > 0 Then

                usuario = dtlogin.Rows(0).Item(0)

                'carga permisos del usuario en la aplicación (9 - TicketComplementario)
                dtPermAutor = d.obtiene_permisos_autorizaciones(usuario, 9)
                If dtPermAutor IsNot Nothing And dtPermAutor.Rows.Count > 0 Then
                    sPermiso0 = dtPermAutor.Rows(0).Item(0)
                    sPermiso1 = dtPermAutor.Rows(0).Item(1)
                    sPermiso2 = dtPermAutor.Rows(0).Item(2)
                    sPermiso3 = dtPermAutor.Rows(0).Item(3)
                End If
                gs_Permisos1 = l.CombinaValores(sPermiso0, sPermiso1)

                ''carga permisos del usuario en la aplicación (1 - MESA)
                'dtPermAutor = d.obtiene_permisos_autorizaciones(usuario, 1)
                'If dtPermAutor IsNot Nothing And dtPermAutor.Rows.Count > 0 Then
                '    sPermiso0 = dtPermAutor.Rows(0).Item(0)
                '    sPermiso1 = dtPermAutor.Rows(0).Item(1)
                '    sPermiso2 = dtPermAutor.Rows(0).Item(2)
                '    sPermiso3 = dtPermAutor.Rows(0).Item(3)
                'End If

                ''If gs_Permisos1 IsNot Nothing And gs_Permisos1 <> "" Then
                'gs_Permisos1 = l.CombinaValores(sPermiso0, sPermiso1)
                ''End If
                ''If gn_Autorizaciones1 IsNot Nothing And gn_Autorizaciones1 <> "" Then
                'gn_Autorizaciones1 = l.CombinaValores(sPermiso2, sPermiso3)
                ''End If

                ''carga permisos del usuario en la aplicación (2 - BACK)
                'dtPermAutor = d.obtiene_permisos_autorizaciones(usuario, 2)
                'If dtPermAutor IsNot Nothing And dtPermAutor.Rows.Count > 0 Then
                '    sPermiso0 = dtPermAutor.Rows(0).Item(0)
                '    sPermiso1 = dtPermAutor.Rows(0).Item(1)
                '    sPermiso2 = dtPermAutor.Rows(0).Item(2)
                '    sPermiso3 = dtPermAutor.Rows(0).Item(3)
                'End If
                ''If gs_Permisos2 IsNot Nothing And gs_Permisos2 <> "" Then
                'gs_Permisos2 = l.CombinaValores(sPermiso0, sPermiso1)
                ''End If
                ''If gn_Autorizaciones2 IsNot Nothing And gn_Autorizaciones2 <> "" Then
                'gn_Autorizaciones2 = l.CombinaValores(sPermiso2, sPermiso3)
                ''End If

                bLogin = True

                Me.Enabled = False '------RACB 27/09/2021
                ValidaTiempoContrasena(dtlogin) '------RACB 27/09/2021
                Me.Enabled = True '------RACB 27/09/2021
                gs_Sql = "UPDATE " & "Catalogos" & ".." & "USUARIO" '------RACB 21/04/2022
                gs_Sql = gs_Sql & " SET login_erroneo = " & 0 '------RACB 21/04/2022
                gs_Sql = gs_Sql & " WHERE usuario = " & usuario '------21/04/2022
                d.insertar(gs_Sql) '------21/04/2022

                If Relogin = False Then
                    Dim fTicket As New funcionalidades
                    fTicket.Show()
                Else
                    Relogin = False
                End If

                Me.Hide()
            Else
                gn_Autorizaciones1 = ""
                gs_Permisos1 = ""
                gn_Autorizaciones2 = ""
                gs_Permisos2 = ""
                MsgBox("EL USUARIO NO ES VALIDO, VERIFIQUE SI ESTA BLOQUEADO O ANULADO O SI EXISTE")
            End If

            If Not Err.Number = 0 Then
                MsgBox("ERROR AL FIRMARSE AL SISTEMA", Err.Description)
                Err.Clear()
            End If
        End If

    End Sub
    Private Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        Me.Close()
    End Sub

    Function DatosCorrectos() As Boolean
        Dim d As New Datasource
        Dim ExisteUser As String
        Dim UserBloqueado As String
        Dim UserAnulado As String
        Dim ExistePass As String

        If txLogin.Text = String.Empty Then
            MsgBox("Es necesario ingresar usuario", vbInformation, "Validación")
            txLogin.Focus()
            Return False
        End If

        If txPass.Text = String.Empty Then
            MsgBox("Es necesario ingresar el password", vbInformation, "Validación")
            txPass.Focus()
            Return False
        End If

        ExisteUser = d.validaUser(txLogin.Text.Trim())
        UserBloqueado = d.validaUserB(txLogin.Text.Trim())
        UserAnulado = d.validaUserA(txLogin.Text.Trim())
        ExistePass = d.validaPass(txLogin.Text.Trim(), txPass.Text.Trim())
        'ExistePass = 1

        If ExisteUser = "0" Then
            MsgBox("El usuario no existe o esta mal escrito, favor de verificar", vbInformation, "Validación")
            txLogin.Focus()
            Return False
        End If

        If UserBloqueado > "0" Then
            MsgBox("El usuario esta bloqueado", vbInformation, "Validación")
            txLogin.Focus()
            Return False
        End If

        If UserAnulado > "0" Then
            MsgBox("El usuario esta anulado", vbInformation, "Validación")
            txLogin.Focus()
            Return False
        End If

        If ExistePass = "0" Then
            MsgBox("El password no es correcto, favor de verificar", vbInformation, "Validación")
            txLogin.Focus()
            ErrorPassword() '---- RACB 21/04/2022
            Return False
        End If


        Return True

    End Function
    Private Sub ValidaTiempoContrasena(dtDatosLogin As DataTable)
        Dim objDataSource As New Datasource
        Dim dtRespConsulta As DataTable
        Dim drRegistro As DataRow
        Dim culture As String = ""
        Dim ign_Usuario As Integer
        Dim NumRegistros As Integer
        Dim ign_Origen As Integer
        Dim lsFechaPassword As String
        Dim lsFechaUltimoAcceso As String
        Dim iParamCambioPass As Integer
        Dim VistaMantPasswd As New MantPasswd

        dtRespConsulta = objDataSource.RealizaConsulta("select convert(Char(10), fecha_sistema, 101) from PARAMETROS")
        drRegistro = dtRespConsulta.Rows(0)
        gs_FechaHoy = drRegistro.Item(0).ToString
        iParamCambioPass = Val(objDataSource.ValorParametro("CAMBIO_PASSW").Rows(0).Item(0))

        If Thread.CurrentThread.CurrentCulture.Name = "en-US" Then
            lsFechaPassword = dtDatosLogin.Rows(0).Item(2).ToString.Substring(3, 2) & "-" & dtDatosLogin.Rows(0).Item(2).ToString.Substring(0, 2) & "-" & dtDatosLogin.Rows(0).Item(2).ToString.Substring(6, 4)
            lsFechaUltimoAcceso = dtDatosLogin.Rows(0).Item(3).ToString.Substring(3, 2) & "-" & dtDatosLogin.Rows(0).Item(3).ToString.Substring(0, 2) & "-" & dtDatosLogin.Rows(0).Item(3).ToString.Substring(6, 4)
        ElseIf Thread.CurrentThread.CurrentCulture.Name = "es-MX" Then
            lsFechaPassword = dtDatosLogin.Rows(0).Item(2)
            lsFechaUltimoAcceso = dtDatosLogin.Rows(0).Item(3)
            gs_FechaHoy = gs_FechaHoy.ToString.Substring(3, 2) & "-" & gs_FechaHoy.Substring(0, 2) & "-" & gs_FechaHoy.Substring(6, 4)
        End If

        ign_Usuario = dtDatosLogin.Rows(0).Item(0)
        ign_Origen = dtDatosLogin.Rows(0).Item(1)
        iPass_gn_Usuario = ign_Usuario
        sPass_Usuario = txLogin.Text
        sPass_Contraseña = txPass.Text

        'Verifica la ultima vez que se cambio el password
        If Trim(lsFechaPassword) <> "" Then
            If CDate(DateAdd("d", iParamCambioPass, lsFechaPassword)) <= CDate(gs_FechaHoy) Then
                MsgBox("Por seguridad es necesario que cambie su password.", vbInformation, "Cambio de Password...")
                'Me.Hide()
                MantPasswd.StartPosition = FormStartPosition.CenterScreen
                MantPasswd.ShowDialog()
                Exit Sub
            End If
            'Si no tiene una fecha valida entonces fija la fecha de hoy
        Else
            gs_Sql = "Update " & "Catalogos.dbo.USUARIO"
            gs_Sql = gs_Sql & " set fecha_cambio_password = getdate() "
            gs_Sql = gs_Sql & " where usuario = " & ign_Usuario
            'dbExecQuery gs_Sql
            '        dbEndQuery
            NumRegistros = objDataSource.insertar(gs_Sql)
        End If

        'Verfica si el password en BANCO001 pide que se cambie.
        If StrComp(Trim(txPass.Text), "Banco001", vbTextCompare) = 0 Then
            MsgBox("Por seguridad es necesario que cambie su password.", vbInformation, "Cambio de Password...")
            'Unload Me
            MantPasswd.StartPosition = FormStartPosition.CenterScreen
            MantPasswd.ShowDialog()
            Exit Sub
        End If
        'Si NO es la primera vez que ingresa al sistema actualiza la fecha de ultimo acceso
        If lsFechaUltimoAcceso <> "" Then
            gs_Sql = "UPDATE " & "Catalogos.dbo.USUARIO " &
                "SET fecha_ultimo_acceso=getdate(), " &
                "login_erroneo=0 " &
                "WHERE usuario=" & ign_Usuario
            'Actualiza la ultima vez que acceso el sistema
            'dbExecQuery gs_Sql
            '    dbEndQuery
            NumRegistros = objDataSource.insertar(gs_Sql)
            'En otro caso pide que cambie su password
        Else
            MsgBox("Por seguridad es necesario que cambie su password.", vbInformation, "Cambio de Password...")
            'Unload Me
            MantPasswd.StartPosition = FormStartPosition.CenterScreen
            MantPasswd.ShowDialog()
            Exit Sub
        End If
    End Sub
    Private Sub ErrorPassword()
        Dim objDataSource As New Datasource
        Dim dtRespConsulta As DataTable
        Dim lnErrorLog As String
        Dim gn_Usuario As String
        gs_Sql = "SELECT usuario, login_erroneo FROM " & "Catalogos" & ".." & "USUARIO"
        gs_Sql = gs_Sql & " WHERE login = '" & Trim(txLogin.Text) & "' "
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDataSource.RealizaConsulta(gs_Sql)
        'Numero de errores en login_erroneo
        lnErrorLog = Val(dtRespConsulta.Rows(0).Item(1).ToString)
            gn_Usuario = Val(dtRespConsulta.Rows(0).Item(0).ToString)
            lnErrorLog = lnErrorLog + 1
            'dbEndQuery
            gs_Sql = "UPDATE " & "Catalogos" & ".." & "USUARIO"
            gs_Sql = gs_Sql & " SET login_erroneo = " & lnErrorLog
            gs_Sql = gs_Sql & " WHERE usuario = " & gn_Usuario
            'dbExecQuery gs_Sql
            'dbEndQuery
            objDataSource.insertar(gs_Sql)
            dtRespConsulta = objDataSource.ValorParametro("LOG_ERR")
        If Val(dtRespConsulta.Rows(0).Item(0)) <= lnErrorLog Then
            gs_Sql = "Update " & "Catalogos" & ".." & "USUARIO"
            gs_Sql = gs_Sql & " set password = 'BLOQUEAR'"
            'DGI 28122006
            'Nueva linea para que se pase el paasword anterior a una nueva columna
            'En caso de Bloquear el usuario
            gs_Sql = gs_Sql & ", ultimo_pwd = (Select password from " & "Catalogos" & ".." & "USUARIO" & " where usuario = " & gn_Usuario & ")"
            gs_Sql = gs_Sql & " where usuario = " & gn_Usuario
            'dbExecQuery gs_Sql
            'dbEndQuery
            objDataSource.insertar(gs_Sql)
            MsgBox("El Login que ingresó ha sido bloqueado por causas de seguridad. Contacte al Administrador del Sistema. " & "" & ".", vbInformation, "Acceso")
            'Registra la modificación en la bitacora
            gs_Sql = "INSERT INTO " & "Catalogos" & ".dbo.BITACORA_PERFIL_PSW "
            gs_Sql = gs_Sql & "(usuario, fecha_modificacion, "
            gs_Sql = gs_Sql & "usuario_valida, aplicacion, nombre_pc, password) "
            gs_Sql = gs_Sql & "VALUES (" & gn_Usuario & ", getdate(), "
            gs_Sql = gs_Sql & gn_Usuario & ", " & 9 'NumAplicacion
            gs_Sql = gs_Sql & ", '" & gnGetComputerName() & "', 'BLOQUEAR')"
            'dbExecQuery gs_Sql
            'dbEndQuery
            objDataSource.insertar(gs_Sql)
            gn_Usuario = 0
            'Unload Me
            'Else
            '    MsgBox("El password que tecleo es incorrecto.", vbInformation, "Acceso")
            '    gn_Usuario = 0
            '    txPass.Text = ""
            '    txPass.Focus()
            '    Exit Sub
        End If
    End Sub
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
End Class