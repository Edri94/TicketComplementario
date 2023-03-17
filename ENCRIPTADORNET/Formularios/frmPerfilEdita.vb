Public Class frmPerfilEdita
    Private mb_CambioComentario As Boolean
    Private ms_Cambios As String
    Public gb_CambioAutorizacion As Boolean

    Private objDataSourse As New Datasource
    Private NumAplicacion As String
    Private objModPErmisos As modPermisos = New modPermisos()
    Private objLibreria As Libreria = New Libreria()
    Private objDatasource As Datasource = New Datasource()
    Private iRepetir As Integer
    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir de editar perfil") <> vbYes Then Exit Sub
        Me.Close()
    End Sub
    Private Sub frmPerfilEdita_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer
        'CargarColores frmPerfilEdita, cambio
        ms_Cambios = ""
        'Me.Width = 11010
        'Me.Height = 4815
        'Centerform Me
        'Llena los controles con la información de la base
        NumAplicacion = "(9)"
        LlenaListViewPermisos()
        'LlenaListViewAutorizaciones()
        'NumAplicacion = "(2)"
        'LlenaListViewPermisos()
        'LlenaListViewAutorizaciones()
        'NumAplicacion = "(1,2)"
        LlenaComboPerfiles()
        cmdActualizar.Enabled = False
        If gn_TotalAutorizaciones = 0 Then
            'picAutorizaciones.Visible = False
        End If
        'Guarda una imagen del status de los comentarios
        'For i = 0 To UBound(ga_Autorizaciones)
        '    ms_Cambios = ms_Cambios & CStr(ga_Autorizaciones(i).Comentario) & ","
        'Next
        'ms_Cambios = ms_Cambios.Substring(0, ms_Cambios.Length - 1)
    End Sub
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--
    'Llena la lista de permisos con los encontrados en la base de datos
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--
    Public Sub LlenaListViewPermisos()
        Dim ln_Indice As Long
        If gn_TotalPermisos = 0 Then
            'LstChkPermisos.Items(gn_TotalPermisos).Visible = False
            LstChkPermisos.Enabled = False
            Exit Sub
        End If
        'LstChkPermisos.Items(1).Caption = ga_Permisos(0).Descripcion
        If ga_Permisos(ln_Indice).Descripcion IsNot Nothing And ga_Permisos(ln_Indice).IDAplicacion = (NumAplicacion.Replace("(", "")).Replace(")", "") Then
            LstChkPermisos.Items.Add(ga_Permisos(0).Descripcion)
        End If
        For ln_Indice = 1 To gn_TotalPermisos - 1
            If ga_Permisos(ln_Indice).Descripcion IsNot Nothing And ga_Permisos(ln_Indice).IDAplicacion = (NumAplicacion.Replace("(", "")).Replace(")", "") Then
                'LstChkPermisos(ln_Indice)
                'LstChkPermisos.Items(ln_Indice).Top = LstChkPermisos.Items(ln_Indice - 1).Top + 250
                'LstChkPermisos.Items(ln_Indice).Left = 30
                'LstChkPermisos.Items(ln_Indice).Caption = ga_Permisos(ln_Indice).Descripcion
                'LstChkPermisos.Items(ln_Indice).Visible = True
                LstChkPermisos.Items.Add(ga_Permisos(ln_Indice).Descripcion)
                If Trim(ga_Permisos(ln_Indice).Descripcion) = "Disponible" Then
                    LstChkPermisos.Items(ln_Indice).Enabled = False
                End If
            End If

        Next
        'If gn_TotalPermisos > 9 Then
        '    vsbBarra.Max = gn_TotalPermisos - 9
        '    vsbBarra.Visible = True
        'End If
    End Sub
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=---
    ' Llena la lista de autorizaciones con los encontrados en la base de datos
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=---
    Public Sub LlenaListViewAutorizaciones()
        Dim i As Integer
        If gn_TotalAutorizaciones = 0 Then
            'LstChkAutorizaciones.Items(gn_TotalAutorizaciones).Visible = False
            LstChkAutorizaciones.Enabled = False
            'chkComentario(gn_TotalAutorizaciones).Visible = False
        Else
            'LstChkAutorizaciones.Items(0).Caption = ga_Autorizaciones(0).Descripcion
            If ga_Autorizaciones(0).Descripcion IsNot Nothing And ga_Autorizaciones(0).IDAplicacion = (NumAplicacion.Replace("(", "")).Replace(")", "") Then
                LstChkAutorizaciones.Items.Add(ga_Autorizaciones(0).Descripcion)
                LstChkComentario.Items.Add("")
            End If
            'chkComentario(0).Value = ga_Autorizaciones(0).Comentario
            For i = 1 To gn_TotalAutorizaciones - 1
                If ga_Autorizaciones(i).Descripcion IsNot Nothing And ga_Autorizaciones(i).IDAplicacion = (NumAplicacion.Replace("(", "")).Replace(")", "") Then
                    'Load chkAutorizaciones(i)
                    'LstChkAutorizaciones.Items(i).Move(30, LstChkAutorizaciones.Items(i - 1).Top + 250)
                    'LstChkAutorizaciones.Items(i).Caption = ga_Autorizaciones(i).Descripcion
                    'LstChkAutorizaciones.Items(i).Visible = True
                    'Load chkComentario(i)
                    'chkComentario(i).Move 3750, chkComentario(i - 1).Top + 250
                    'chkComentario(i).Value = ga_Autorizaciones(i).Comentario
                    'chkComentario(i).Visible = True
                    LstChkAutorizaciones.Items.Add(ga_Autorizaciones(i).Descripcion)
                    LstChkComentario.Items.Add("")
                    'LstChkComentario.SetItemChecked(i, ga_Autorizaciones(i).Comentario)
                    If Trim(ga_Autorizaciones(i).Descripcion) = "Disponible" Then
                        LstChkAutorizaciones.Items(i).Enabled = False
                        LstChkComentario.Items(i).Enabled = False
                    End If
                End If
            Next
            'If gn_TotalAutorizaciones > 9 Then
            '    vsbBarra2.Max = gn_TotalAutorizaciones - 9
            '    vsbBarra2.Visible = True
            'End If
        End If
    End Sub
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=---
    'Llena el combo de perfiles dependiendo de la aplicacion que se trate.
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=---
    Public Sub LlenaComboPerfiles()
        Dim ln_Indice As Integer
        Dim dtRespuesta As DataTable
        'cmbPerfiles.Clear
        ReDim objModPErmisos.ga_Perfiles(1, 0)
        objModPErmisos.ga_Perfiles(0, 0) = 0 : objModPErmisos.ga_Perfiles(1, 0) = 0
        gs_Sql = "SELECT 0 perfil, 'Seleccione un Perfil' nombre_perfil, '' masc_permisos, '' masc_autorizaciones,0 aplicacion  union "
        gs_Sql = gs_Sql & "SELECT perfil, nombre_perfil, masc_permisos, masc_autorizaciones,aplicacion FROM CATALOGOS..PERFIL_HEXA "
        gs_Sql = gs_Sql & " WHERE aplicacion in " & NumAplicacion & " ORDER BY aplicacion,perfil"
        'dbExecQuery gs_Sql
        'dbGetRecord
        'If dbError <> 0 Then
        dtRespuesta = objDataSourse.RealizaConsulta(gs_Sql)
        If dtRespuesta Is Nothing Then
            MsgBox("No se encontraron perfiles para esta aplicación.", vbInformation, "Aviso")
        Else
            'Do While dbError = 0
            '    'cmbPerfiles.AddItem Trim(dbGetValue(1))
            '    'cmbPerfiles.ItemData(cmbPerfiles.NewIndex) = Val(dbGetValue(0))
            '    ReDim Preserve ga_Perfiles(1, Val(dbGetValue(0)))
            '    ' Guarda el numero total de permisos por perfil
            '    ga_Perfiles(0, Val(dbGetValue(0))) = Trim(dbGetValue(2))
            '    ' Guarda el numero total de autorizaciones por perfil
            '    ga_Perfiles(1, Val(dbGetValue(0))) = Trim(dbGetValue(3))
            '    'dbGetRecord
            'Loop
            cmbPerfiles.Visible = True
            cmbPerfiles.DisplayMember = "nombre_perfil"
            cmbPerfiles.ValueMember = "perfil"
            cmbPerfiles.DataSource = dtRespuesta
            For Each row As DataRow In dtRespuesta.Rows
                'cmbPerfiles.Items.Insert(row.Item("perfil"), row.Item("nombre_perfil"))
                ReDim objModPErmisos.ga_Perfiles(1, Val(row(0)))
                ' Guarda el numero total de permisos por perfil
                objModPErmisos.ga_Perfiles(0, Val(row(0))) = Trim(row(2))
                ' Guarda el numero total de autorizaciones por perfil
                objModPErmisos.ga_Perfiles(1, Val(row(0))) = Trim(row(3))
            Next
        End If
        'dbEndQuery
        If cmbPerfiles.Items.Count = 0 Then
            cmbPerfiles.Text = "Sin Perfiles"
            'Else
            'cmbPerfiles = "Seleccione un Perfil"
        End If
    End Sub
    Private Sub cmbPerfiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPerfiles.SelectedIndexChanged
        'Dim i As Integer
        Dim arComentarios() As String = ms_Cambios.Split(",")
        'LimpiaChecks Me
        mb_CambioComentario = False
        'Marca el status de comentarios
        'For i = 0 To arComentarios.Length - 1
        '    LstChkComentario.Items(i).Value = Val(Mid(ms_Cambios, i + 1, 1))
        'Next i
        If cmbPerfiles.Items.Count = 0 Then
            Exit Sub
        End If
        If cmbPerfiles.SelectedIndex = -1 Then
            cmdActualizar.Enabled = False
            Exit Sub
        End If
        objLibreria.CargaPermisos("9")
        'objLibreria.CargaAutorizaciones()
        MarcaPermisos(True)
        MarcaAutorizaciones(True)
        cmdEliminar.Enabled = True
        If NumAplicacion = cmbPerfiles.SelectedValue Then 'cmbPerfiles.ItemData(cmbPerfiles.ListIndex) Then
            BloqueaChecks()
            cmdEliminar.Enabled = False
        End If
        cmdActualizar.Enabled = True
        mb_CambioComentario = False
        gb_CambioAutorizacion = False
        'If vsbBarra.Visible Then vsbBarra = 0
        'If vsbBarra2.Visible Then vsbBarra2 = 0
    End Sub
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    'Marca en las pantallas de seguimiento aquellos permisos que tenga cada usuario
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Sub MarcaPermisos(Editable As Boolean)
        Dim ln_Accesos As String
        Dim ln_Indice As Integer
        For i = 0 To LstChkPermisos.Items.Count - 1
            LstChkPermisos.SetItemChecked(i, False)
        Next
        If gn_TotalPermisos > 0 Then
            ln_Accesos = cmbPerfiles.SelectedItem.Row.ItemArray(2)
            'ln_Accesos = gc_Perfiles(Forma.cmbPerfiles.ItemData(Forma.cmbPerfiles.ListIndex)).Accesos
            If objModPErmisos.ZeroTrim(ln_Accesos) <> "" Then
                For ln_Indice = 0 To gn_TotalPermisos - 1
                    'LstChkPermisos.Items(ln_Indice).Enabled = True
                    If objModPErmisos.PermisosPorUsuario(ga_Permisos(ln_Indice).Nombre, ln_Accesos, ga_Permisos(ln_Indice).IDAplicacion) Then
                        LstChkPermisos.SetItemChecked(ln_Indice, True)
                    End If
                Next
                If Not Editable Then
                    For ln_Indice = 0 To gn_TotalPermisos - 1
                        If LstChkPermisos.Items(ln_Indice) = 1 Then LstChkPermisos.Items(ln_Indice).Enabled = False
                    Next ln_Indice
                End If
            End If
        End If
    End Sub
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    ' Marca en las pantallas de seguimiento aquellas autorizaciones que tenga cada usuario
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Sub MarcaAutorizaciones(Editable As Boolean)
        Dim ls_Accesos As String
        Dim i As Integer
        For i = 0 To LstChkAutorizaciones.Items.Count - 1
            LstChkAutorizaciones.SetItemChecked(i, False)
        Next
        For i = 0 To LstChkComentario.Items.Count - 1
            LstChkComentario.SetItemChecked(i, False)
        Next
        If gn_TotalAutorizaciones > 0 Then
            'ls_Accesos = gc_Perfiles(Forma.cmbPerfiles.ItemData(Forma.cmbPerfiles.ListIndex)).Autorizaciones
            ls_Accesos = cmbPerfiles.SelectedItem.Row.ItemArray(3)
            Dim ver = objModPErmisos.ZeroTrim(ls_Accesos)
            If objModPErmisos.ZeroTrim(ls_Accesos) <> "" Then
                For i = 0 To gn_TotalAutorizaciones - 1
                    'If Trim(LstChkAutorizaciones.Items(i).Caption) <> "Disponible" Then
                    '    LstChkAutorizaciones.Items(i).Enabled = True
                    'End If
                    LstChkComentario.SetItemChecked(i, ga_Autorizaciones(i).Comentario)
                    If objModPErmisos.AutorizacionesPorUsuario(ga_Autorizaciones(i).Nombre, ls_Accesos, ga_Autorizaciones(i).IDAplicacion) Then
                        LstChkAutorizaciones.SetItemChecked(i, True)
                    End If
                    'chkComentario(i).Value = ga_Autorizaciones(i).Comentario
                Next
                If Not Editable Then
                    'For i = 0 To gn_TotalAutorizaciones - 1
                    '    If LstChkAutorizaciones.Items(i) = 1 Then
                    '        LstChkAutorizaciones.Items(i).Enabled = False
                    '    End If
                    '    If LstChkComentario.Items(i) = 1 Then
                    '        LstChkComentario.Items(i).Enabled = False
                    '    End If
                    'Next i
                End If
            Else
                For i = 0 To LstChkComentario.Items.Count - 1 'For i = 0 To gn_TotalAutorizaciones - 1
                    LstChkComentario.SetItemChecked(i, ga_Autorizaciones(i).Comentario)
                Next
            End If
        End If
        ls_Accesos = cmbPerfiles.SelectedItem.Row.ItemArray(3)
        'ls_sql = "SELECT PU.perfil, PU.masc_permisos, PU.masc_autorizaciones " &
        '             "FROM CATALOGOS.dbo.PERMISOS_X_USUARIO_HEXA PU, CATALOGOS.dbo.PERFIL_HEXA PF " &
        '             "WHERE PU.usuario=" & cmbUsuarios.SelectedValue & 'cmbUsuarios.ItemData(cmbUsuarios.ListIndex) &
        '             " AND PF.perfil=PU.perfil " &
        '             " AND PF.aplicacion in " & NumAplicacion
        ''dbExecQuery ls_sql
        ''dbGetRecord
        'dtRespuesta = objDataSourse.RealizaConsulta(ls_sql)
        ''If Not IsdbError Then
        'If dtRespuesta IsNot Nothing And dtRespuesta.Rows.Count > 0 Then
        '    mn_PerfilAsignado = Val(dtRespuesta.Rows(j).Item(0))
        '    ms_PermisosIndep = dtRespuesta.Rows(j).Item(1)
        '    ms_AutorizaIndep = dtRespuesta.Rows(j).Item(2)
        'Else
        '    mn_PerfilAsignado = Val(NumAplicacion)
        'End If
    End Sub
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--
    'Inhabilita los checkboxes de permisos y autorizaciones
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--
    Public Sub BloqueaChecks()
        'Dim ln_Indice As Long
        'If gn_TotalPermisos > 0 Then
        '    For ln_Indice = 0 To gn_TotalPermisos - 1
        '        Forma.chkPermisos(ln_Indice).Enabled = False
        '    Next ln_Indice
        'End If
        'If gn_TotalAutorizaciones > 0 Then
        '    For ln_Indice = 0 To gn_TotalAutorizaciones - 1
        '        Forma.chkAutorizaciones(ln_Indice).Enabled = False
        '    Next ln_Indice
        'End If
        LstChkPermisos.Enabled = False
        LstChkAutorizaciones.Enabled = False
        LstChkComentario.Enabled = False
    End Sub
    Private Sub cmdActualizar_Click(sender As Object, e As EventArgs) Handles cmdActualizar.Click
        Dim ls_PermisosAnt As String
        Dim ls_AutorizaAnt As String
        Dim ls_FechaAnt As String
        Dim NumRegistros As Integer
        GuardaStatusAutorizaciones()
        If cmbPerfiles.SelectedIndex > -1 And cmbPerfiles.Items.Count > 0 Then
            If gb_CambioAutorizacion Then
                gb_CambioAutorizacion = False
ActualizaPerfil:
                gs_Sql = "UPDATE CATALOGOS..PERFIL_HEXA SET masc_permisos = '" & TotalAccesos()
                gs_Sql = gs_Sql & "', masc_autorizaciones = '" & TotalAutorizaciones()
                gs_Sql = gs_Sql & "', fecha_modificacion = getdate() WHERE"
                gs_Sql = gs_Sql & " aplicacion in " & NumAplicacion & " AND nombre_perfil = '" & Trim(cmbPerfiles.Text) & "'"
                'dbExecQuery gs_Sql
                NumRegistros = objDatasource.insertar(gs_Sql)
                'If dbError <> 0 Then
                If NumRegistros <= 0 Then
                    'dbEndQuery
                    If MsgBox("Ocurrio un error al intentar actualizar el perfil." & Chr(13) &
                    " ¿Desea reintentar la operación? ", vbRetryCancel + vbCritical, "Aviso") = vbRetry Then
                        GoTo ActualizaPerfil
                    End If
                    Exit Sub
                End If
                'dbEndQuery
                objModPErmisos.ga_Perfiles(0, Val(cmbPerfiles.SelectedValue)) = TotalAccesos()
                objModPErmisos.ga_Perfiles(1, Val(cmbPerfiles.SelectedValue)) = TotalAutorizaciones()
                MsgBox("La actualización se registro con exito!", vbInformation, "Aviso")
                LlenaComboPerfiles()
                cmdActualizar.Enabled = False
            End If
        Else
            MsgBox("Seleccione un Perfil", vbInformation, "Aviso")
        End If
        cmbPerfiles.Focus()
    End Sub
    '---------------------------------------------------------------------------------------------------------------------------------
    'Registra en la base de datos es estado de la condición de 'Requiere Comentario' de cada autorizacion
    '---------------------------------------------------------------------------------------------------------------------------------
    Private Sub GuardaStatusAutorizaciones()
        Dim i As Integer
        Dim lb_Actualiza As Boolean
        Dim ls_Cambios As String
        Dim NumRegistros As Integer

        If Not mb_CambioComentario Then
            Exit Sub
        End If
        If gn_TotalAutorizaciones = 0 Then
            Exit Sub
        End If
        'Crea una imagen del status de los comentarios actual
        For i = 0 To UBound(ga_Autorizaciones)
            ls_Cambios = ls_Cambios & CStr(LstChkComentario.GetItemChecked(i).ToString() & ",")
        Next
        ls_Cambios = ls_Cambios.Substring(0, ls_Cambios.Length - 1)
        'Compara el status de comentarios inicial con el actual
        If ls_Cambios = ms_Cambios Then
            Exit Sub
        End If
        lb_Actualiza = True
        mb_CambioComentario = False
        If MsgBox(" El cambio en la opción 'Requiere Comentario' aplica para todos los perfiles." & vbCrLf &
            "¿Desea actualizar el Requerimiento de Comentario para las Autorizaciones?", vbQuestion + vbYesNo, "Modificación Global") = vbYes Then
            For i = 0 To gn_TotalAutorizaciones - 1
                gs_Sql = "Update CATALOGOS.dbo.AUTORIZACIONES_HEXA set requiere_comentario = " & Convert.ToInt32(LstChkComentario.GetItemChecked(i))
                gs_Sql = gs_Sql & " where rtrim(ltrim(descripcion)) = '" & Trim(ga_Autorizaciones(i).Descripcion) & "'"
                'dbExecQuery gs_Sql
                NumRegistros = objDatasource.insertar(gs_Sql)
                'If dbError Then
                If NumRegistros <= 0 Then
                    lb_Actualiza = False
                End If
                'dbEndQuery
            Next
            If lb_Actualiza = False Then
                MsgBox("Hubo errores en la actualización de los valores de la base de datos.", vbInformation, "Aviso")
            End If
            'CargaPermisos()
            ms_Cambios = ""
            'Regenera la imagen del status de comentarios
            For i = 0 To UBound(ga_Autorizaciones)
                ms_Cambios = ms_Cambios & CStr(ga_Autorizaciones(i).Comentario) & ","
            Next
            ms_Cambios = ms_Cambios.Substring(0, ms_Cambios.Length - 1)
            'No se requiere el cambio en comentarios
        Else
            'Marca el status de comentarios
            For i = 0 To Len(ms_Cambios) - 1
                'LstChkComentario.Items(i).Value = Val(Mid(ms_Cambios, i + 1, 1))
            Next i
        End If

        cmdEliminar.Enabled = False
        cmdActualizar.Enabled = False
    End Sub
    Public Function TotalAccesos() As String
        Dim i As Integer
        Dim s As String
        Dim ver = ga_Permisos
        TotalAccesos = ""
        If gn_TotalPermisos > 0 Then
            s = StrDup(gn_MaxPermiso, "0")
            'For i = 0 To gn_TotalPermisos - 1
            For i = 0 To gn_TotalPermisos - 1
                'If LstChkPermisos.Items(i) = 1 And LstChkPermisos.Items(i).Enabled Then
                If i <= LstChkPermisos.Items.Count - 1 Then
                    If LstChkPermisos.GetItemChecked(i) = True Then
                        Mid(s, ga_Permisos(i).Valor, 1) = "1"
                        'Debug.Print s
                    End If
                End If
            Next
            TotalAccesos = objLibreria.Bin2Hex(s)
        End If
    End Function
    Public Function TotalAutorizaciones() As String
        'Dim i As Integer
        'Dim s As String
        'TotalAutorizaciones = ""
        'If gn_TotalAutorizaciones > 0 Then
        '    s = StrDup(gn_MaxAutorizacion, "0")
        '    For i = 0 To gn_TotalAutorizaciones - 1
        '        'If LstChkAutorizaciones.Items(i) = 1 And LstChkAutorizaciones.Items(i).Enabled Then
        '        If LstChkAutorizaciones.GetItemChecked(i) = True Then
        '            Mid(s, ga_Autorizaciones(i).Valor, 1) = "1"
        '        End If
        '    Next
        '    TotalAutorizaciones = objLibreria.Bin2Hex(s)
        'End If
    End Function
    'Fecha 25-feb-04
    'Modificó Cristina Peral Báez (cpb 25-feb-04)
    'Modificación:
    '  Validación del perfil en usuarios Activos, en caso de haber no permitir la eliminación
    '  Eliminación de usuarios Anulados y Bloqueados con el perfil a eliminar, una vez pasada la validación anterior
    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        Dim i As Integer
        Dim ln_Indice As Integer
        Dim dtRespuesta As DataTable
        Dim NumRegistros As Integer
        'Busca si el perfil esta asignado a algun usuario
        gs_Sql = "SELECT count(PU.usuario) FROM CATALOGOS..PERMISOS_X_USUARIO_HEXA PU, "
        gs_Sql = gs_Sql & "CATALOGOS..PERFIL_HEXA PF, CATALOGOS..USUARIO US "
        'gs_Sql = gs_Sql & " WHERE PF.aplicacion = " & (NumAplicacion.Replace("(", "")).Replace(")", "")
        gs_Sql = gs_Sql & " WHERE PF.perfil = PU.perfil AND PF.nombre_perfil = '" & Trim(cmbPerfiles.Text) & "'" '---gs_Sql = gs_Sql & " AND PF.perfil = PU.perfil AND PF.nombre_perfil = '" & Trim(cmbPerfiles.Text) & "'"
        gs_Sql = gs_Sql & " AND PU.usuario = US.usuario AND PF.aplicacion = 9 AND US.password not in ('ANULADO', 'BLOQUEAR')" 'cpb 25-feb-04
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespuesta = objDataSourse.RealizaConsulta(gs_Sql)
        'If dbError = 0 Then
        If dtRespuesta IsNot Nothing And dtRespuesta.Rows.Count Then
            If Val(dtRespuesta.Rows(0).Item(0)) > 0 Then
                MsgBox("El perfil aún esta asignado a " & dtRespuesta.Rows(0).Item(0) & " usuario(s). Operación cancelada.", vbInformation, "Aviso")
                'dbEndQuery
                cmdEliminar.Enabled = False
                Exit Sub
            End If
        Else
            'dbEndQuery
            MsgBox("Ocurrio un error al leer la base de datos. Operación cancelada.", vbCritical, "Aviso")
            Exit Sub
        End If
        'dbEndQuery
        If MsgBox("¿Desea eliminar el Perfil " & Trim(cmbPerfiles.Text) & "? ", vbYesNo + vbQuestion, "Aviso") = vbYes Then
EliminaPerfil:
            'cpb 25-feb-04 Inicio
            'gs_Sql = "Delete CATALOGOS..PERMISOS_X_USUARIO_HEXA "
            'gs_Sql = gs_Sql & " from CATALOGOS..PERFIL_HEXA P"
            'gs_Sql = gs_Sql & " Where CATALOGOS..PERMISOS_X_USUARIO_HEXA.perfil = P.perfil"
            'gs_Sql = gs_Sql & " and P.perfil = " & cmbPerfiles.SelectedValue
            'dbExecQuery gs_Sql
            gs_Sql = "Delete CATALOGOS..PERMISOS_X_USUARIO_HEXA Where perfil = " & cmbPerfiles.SelectedValue
            NumRegistros = objDataSourse.insertar(gs_Sql)
            gs_Sql = "Delete CATALOGOS..PERFIL_HEXA Where perfil = " & cmbPerfiles.SelectedValue
            NumRegistros = objDataSourse.insertar(gs_Sql)
            'If dbError <> 0 Then
            If NumRegistros <= 0 Then
                'dbEndQuery
                If MsgBox("Ocurrió un error al intentar eliminar el perfil.                " & Chr(13) & "        ¿Desea reintentar la operación?", vbRetryCancel + vbCritical, "Aviso") = vbRetry Then
                    GoTo EliminaPerfil
                Else
                    Exit Sub
                End If
            End If
            'cpb 25-feb-04 Fin

            'gs_Sql = "DELETE CATALOGOS..PERFIL_HEXA WHERE nombre_perfil = '" & Trim(cmbPerfiles.Text) & "' AND"
            'gs_Sql = gs_Sql & " aplicacion = " & (NumAplicacion.Replace("(", "")).Replace(")", "") & " AND perfil = " & cmbPerfiles.SelectedValue
            ''dbExecQuery gs_Sql
            'NumRegistros = objDatasource.insertar(gs_Sql)
            ''If dbError <> 0 Then
            'If NumRegistros <= 0 Then
            '    'dbEndQuery
            '    If MsgBox("Ocurrio un error al intentar eliminar el perfil. " & Chr(13) &
            '          "¿Desea reintentar la operación?", vbRetryCancel + vbCritical, "Aviso") = vbRetry Then
            '        GoTo EliminaPerfil
            '    End If
            'Else
            'dbEndQuery
            MsgBox("¡La eliminación se registro con exito!", vbInformation, "Aviso")
            LlenaComboPerfiles()
            'LimpiaChecks()
            mb_CambioComentario = False
            'Marca el status de comentarios
            For i = 0 To Len(ms_Cambios) - 1
                'LstChkComentario.Items(i).Value = Val(Mid(ms_Cambios, i + 1, 1))
            Next i
            cmdEliminar.Enabled = False
            cmdActualizar.Enabled = False
        End If
        'End If
    End Sub
    '-------------------------------------------------------
    'Pemite guardar un nuevo perfil en la base de datos.
    '-------------------------------------------------------
    Private Sub cmdAgregar_Click(sender As Object, e As EventArgs) Handles cmdAgregar.Click
        Dim i As Integer
        Dim dtRespuesta As DataTable
        Dim NumRegistros As Integer
        If cmdAgregar.Text = "&Nuevo" Then
            cmdActualizar.Enabled = False
            cmdEliminar.Enabled = False
            'cmdAgregar.Caption = "&Guardar"
            'cmdCerrar.Caption = "&Cancelar"
            cmbPerfiles.Enabled = False
            lblNombrePerfil.Visible = True
            txtNombrePerfil.Visible = True
            txtNombrePerfil.Text = ""
            txtNombrePerfil.Focus()
        Else
            If Trim(txtNombrePerfil.Text) = "" Then
                MsgBox("No se ha especificado el nombre del nuevo perfil.", vbInformation, "Aviso")
                txtNombrePerfil.Text = ""
                txtNombrePerfil.Focus()
                Exit Sub
            End If
            'Verifica que el nombre del nuevo perfil no exista ya en la base de datos.
            gs_Sql = "SELECT perfil FROM "
            gs_Sql = gs_Sql & "CATALOGOS..PERFIL_HEXA "
            gs_Sql = gs_Sql & "WHERE nombre_perfil = '" & UCase(Trim(txtNombrePerfil.Text)) & "' AND aplicacion in (" & NumAplicacion & ")"
            'dbExecQuery gs_Sql
            'dbGetRecord
            dtRespuesta = objDataSourse.RealizaConsulta(gs_Sql)
            'If dbError = 0 Then
            If dtRespuesta IsNot Nothing And dtRespuesta.Rows.Count > 0 Then
                'dbEndQuery
                MsgBox("El nombre de perfil especificado ya existe.", vbInformation, "Aviso")
                'txtNombrePerfil.SelStart = 0
                'txtNombrePerfil.SeLength = Len(txtNombrePerfil)
                txtNombrePerfil.Focus()
                Exit Sub
            End If
            'dbEndQuery
RegistraPerfil:
            gs_Sql = "INSERT INTO CATALOGOS..PERFIL_HEXA (aplicacion, masc_permisos, masc_autorizaciones, nombre_perfil, fecha_modificacion) VALUES "
            gs_Sql = gs_Sql & "(" & 9 & ", '" & TotalAccesos() & "', '" & TotalAutorizaciones() & "', '" & UCase(Trim(txtNombrePerfil.Text)) & "', getdate())" '---gs_Sql = gs_Sql & "(" & (NumAplicacion.Replace("(", "")).Replace(")", "") & ", '" & TotalAccesos() & "', '" & TotalAutorizaciones() & "', '" & UCase(Trim(txtNombrePerfil.Text)) & "', getdate())"
            'dbExecQuery gs_Sql
            NumRegistros = objDatasource.insertar(gs_Sql)
            'If dbError <> 0 Then
            If NumRegistros <= 0 Then
                'dbEndQuery
                If MsgBox("Ocurrio un error al intentar dar de alta el perfil." & Chr(13) &
                "    ¿Desea reintentar la operación?", vbRetryCancel + vbCritical, "Aviso") = vbRetry Then
                    GoTo RegistraPerfil
                End If
            Else
                GuardaStatusAutorizaciones()
                MsgBox("El perfil se registro con exito!", vbInformation, "Aviso")
                cmdAgregar.Enabled = False
                'Recupera los datos de la Base de datos
                LlenaComboPerfiles()
                'LimpiaChecks Me
                mb_CambioComentario = False
                'Marca el status de comentarios
                For i = 0 To Len(ms_Cambios) - 1
                    'LstChkComentario.Items(i).Value = Val(Mid(ms_Cambios, i + 1, 1))
                Next i
                'Deja los controles listos
                cmdEliminar.Enabled = False
                cmdActualizar.Enabled = False
                'cmdAgregar.Caption = "&Nuevo"
                'cmdCerrar.Caption = "&Cerrar"
                cmbPerfiles.Enabled = True
                lblNombrePerfil.Visible = False
                txtNombrePerfil.Visible = False
            End If
        End If
    End Sub
    Private Sub LstChkPermisos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstChkPermisos.SelectedIndexChanged
        gb_CambioAutorizacion = True
    End Sub

    Private Sub LstChkAutorizaciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstChkAutorizaciones.SelectedIndexChanged
        gb_CambioAutorizacion = True
    End Sub

    Private Sub LstChkComentario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstChkComentario.SelectedIndexChanged
        gb_CambioAutorizacion = True
        mb_CambioComentario = True
    End Sub
End Class