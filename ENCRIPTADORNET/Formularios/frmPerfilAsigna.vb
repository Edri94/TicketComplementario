Public Class frmPerfilAsigna
    Private objDataSourse As New Datasource
    Private NumAplicacion As String
    Private objModPErmisos As modPermisos = New modPermisos()
    Private objLibreria As Libreria = New Libreria()
    Private objDatasource As Datasource = New Datasource()

    Private mn_PerfilAsignado As Integer
    Private ms_PermisosIndep As String
    Private ms_AutorizaIndep As String
    Private Nom_perfil As String
    Private iControl As Integer
    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir de asignar permisos") <> vbYes Then Exit Sub
        Me.Close()
    End Sub
    Private Sub frmPerfilAsigna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CargarColores frmPerfilAsigna, cambio
        'Me.Width = 8595
        'Me.Height = 5895
        'Centerform Me
        NumAplicacion = "(9)"
        lblArea.Text = ""
        'NumAplicacion = "(1)"
        LlenaListViewPermisos()
        'LlenaListViewAutorizaciones()
        'NumAplicacion = "(2)"
        'LlenaListViewPermisos()
        'LlenaListViewAutorizaciones()
        'NumAplicacion = "(1,2)"
        LlenaComboPerfiles()
        'chkMesa.Checked = True
        LlenaListViewUsuarios()
        If gn_TotalAutorizaciones = 0 Then
            LstChkAutorizaciones.Visible = False
        End If
        LstChkPermisos.SelectionMode = 0
    End Sub
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    ' Llena la lista de Usuarios disponibles por Base de Datos
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Sub LlenaListViewUsuarios()
        Dim ls_sql As String
        Dim dtRespuesta As DataTable
        'Forma.cmbUsuarios.Clear
        ls_sql = "select 0 usuario,'-- Seleccione un Usuario --' login union select usuario, login from " & "CATALOGOS.dbo.USUARIO"
        ls_sql = ls_sql & " where password not in ('ANULADO','BLOQUEAR') "
        ls_sql = ls_sql & " order by login"
        'dbExecQuery(ls_sql)
        'dbGetRecord
        'Do While Not IsdbError
        '    cmbUsuarios.AddItem UCase(Trim(dbGetValue(1)))
        '    cmbUsuarios.ItemData(cmbUsuarios.NewIndex) = Val(dbGetValue(0))
        '    dbGetRecord
        'Loop
        'dbEndQuery
        dtRespuesta = objDataSourse.RealizaConsulta(ls_sql)
        cmbUsuarios.Visible = True
        cmbUsuarios.DisplayMember = "login"
        cmbUsuarios.ValueMember = "usuario"
        cmbUsuarios.DataSource = dtRespuesta

        If cmbUsuarios.Items.Count = 0 Then
            'cmbUsuarios.Text = "No se encontraron usuarios."
            cmbUsuarios.Items.Insert(0, "No se encontraron usuarios.")
            cmbUsuarios.Enabled = False
            'Else
            '    cmbUsuarios = "Seleccione un Usuario"
        End If
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
                    If Trim(ga_Autorizaciones(i).Descripcion) = "Disponible" Then
                        LstChkAutorizaciones.Items(i).Enabled = False
                        'chkComentario(i).Enabled = False
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
        'gs_Sql = "Select T1.* from (SELECT 0 perfil, 'Seleccione un Perfil' nombre_perfil, '' masc_permisos, '' masc_autorizaciones,1 aplicacion union SELECT perfil, nombre_perfil, masc_permisos, masc_autorizaciones,aplicacion FROM CATALOGOS..PERFIL_HEXA WHERE aplicacion in (1))T1 union Select  T2.* from (SELECT 0 perfil, '-------------' nombre_perfil, '' masc_permisos, '' masc_autorizaciones,2 aplicacion union SELECT perfil, nombre_perfil, masc_permisos, masc_autorizaciones,aplicacion FROM CATALOGOS..PERFIL_HEXA WHERE aplicacion in (2))T2 ORDER BY aplicacion,perfil"
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
    '-----------------------------------------------------
    'Busca las propiedades del usuario seleccionado
    '-----------------------------------------------------
    Private Sub cmbUsuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUsuarios.SelectedIndexChanged
        Dim ls_sql As String
        Dim ln_IndicePerfil As Integer
        Dim i As Integer
        Dim dtRespuesta As DataTable
        lblArea.Text = ""
        For i = 0 To LstChkPermisos.Items.Count - 1
            LstChkPermisos.SetItemChecked(i, False)
        Next
        For i = 0 To LstChkAutorizaciones.Items.Count - 1
            LstChkAutorizaciones.SetItemChecked(i, False)
        Next
        'If cmbUsuarios.ListIndex > -1 Then

        If cmbUsuarios.SelectedIndex > -1 Then
            'Call LimpiaChecks(Me)
            ls_sql = "SELECT US.nombre_usuario, AU.descripcion " &
                     "FROM CATALOGOS.dbo.USUARIO US " &
                     "RIGHT OUTER JOIN CATALOGOS.dbo.AREA_USUARIO AU " &
                     "ON AU.area_usuario = US.area_usuario " &
                     "WHERE US.usuario = " & cmbUsuarios.SelectedValue 'cmbUsuarios.ItemData(cmbUsuarios.ListIndex)
            'dbExecQuery ls_sql
            'dbGetRecord
            dtRespuesta = objDataSourse.RealizaConsulta(ls_sql)
            'If Not IsdbError Then
            If dtRespuesta IsNot Nothing And dtRespuesta.Rows.Count > 0 Then
                cmbNombre.Text = objLibreria.LowCaseName(dtRespuesta.Rows(0).Item(0))
                If Trim(dtRespuesta.Rows(0).Item(1)) <> "" Then
                    lblArea.Text = "Usuario de " & Trim(dtRespuesta.Rows(0).Item(1))
                End If
            End If
            'dbEndQuery
            ' Busca el perfil asignado al usuario
            ls_sql = "SELECT PU.perfil, PU.masc_permisos, PU.masc_autorizaciones " &
                     "FROM CATALOGOS.dbo.PERMISOS_X_USUARIO_HEXA PU, CATALOGOS.dbo.PERFIL_HEXA PF " &
                     "WHERE PU.usuario=" & cmbUsuarios.SelectedValue & 'cmbUsuarios.ItemData(cmbUsuarios.ListIndex) &
                     " AND PF.perfil=PU.perfil " &
                     " AND PF.aplicacion in " & NumAplicacion
            'dbExecQuery ls_sql
            'dbGetRecord
            dtRespuesta = objDataSourse.RealizaConsulta(ls_sql)
            'If Not IsdbError Then
            If dtRespuesta IsNot Nothing And dtRespuesta.Rows.Count > 0 Then
                mn_PerfilAsignado = Val(dtRespuesta.Rows(0).Item(0))
                ms_PermisosIndep = dtRespuesta.Rows(0).Item(1)
                ms_AutorizaIndep = dtRespuesta.Rows(0).Item(2)
            Else
                mn_PerfilAsignado = Val(0)
                cmbPerfiles.SelectedValue = mn_PerfilAsignado
                Exit Sub
            End If
            cmbPerfiles.SelectedValue = mn_PerfilAsignado
            'dbEndQuery
            ln_IndicePerfil = 0
            For i = 0 To cmbPerfiles.Items.Count - 1
                If cmbPerfiles.SelectedValue = mn_PerfilAsignado Then
                    ln_IndicePerfil = i
                    Exit For
                End If
            Next

            If cmbPerfiles.Items.Count > 0 Then
                cmdActualizar.Enabled = True

                'If cmbPerfiles.ListIndex = ln_IndicePerfil Then
                If cmbPerfiles.SelectedIndex <> ln_IndicePerfil Then
                    cmbPerfiles_Click()
                Else
                    cmbPerfiles.SelectedIndex = ln_IndicePerfil
                End If
            End If

            'Busca permisos y autorizaciones independientes asignadas al usuario
            If gn_TotalPermisos > 0 Then
                If objModPErmisos.ZeroTrim(ms_PermisosIndep) <> "" Then
                    For i = 0 To gn_TotalPermisos - 1
                        'If LstChkPermisos.Items(i).Enabled Then
                        If objModPErmisos.PermisosPorUsuario(ga_Permisos(i).Nombre, ms_PermisosIndep, ga_Permisos(i).IDAplicacion) Then
                            LstChkPermisos.SetItemChecked(i, True)
                        End If
                        'End If
                    Next
                End If
            End If
            If gn_TotalAutorizaciones > 0 And objModPErmisos.ZeroTrim(ms_AutorizaIndep) <> "" Then
                For i = 0 To gn_TotalAutorizaciones - 1
                    'If LstChkAutorizaciones.Items(i).Enabled Then
                    If objModPErmisos.AutorizacionesPorUsuario(ga_Autorizaciones(i).Nombre, ms_AutorizaIndep, ga_Autorizaciones(i).IDAplicacion) Then
                        LstChkAutorizaciones.SetItemChecked(i, True)
                    End If
                    'End If
                Next
            End If
        End If

        'If vsbBarra.Visible Then vsbBarra = 0
        'If vsbBarra2.Visible Then vsbBarra2 = 0
        'cmdActualizar.Enabled = False
        If NumAplicacion = 0 And cmbPerfiles.SelectedIndex = 0 Then
            LstChkPermisos.Enabled = False
            LstChkAutorizaciones.Enabled = False
        Else
            LstChkPermisos.Enabled = True
            LstChkAutorizaciones.Enabled = True
        End If
        'cmbPerfiles.SelectedValue = mn_PerfilAsignado

    End Sub
    Private Sub cmbPerfiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPerfiles.SelectedIndexChanged
        cmbPerfiles_Click()
    End Sub
    Private Sub cmbPerfiles_Click()
        'LimpiaChecks Me
        If cmbPerfiles.Items.Count = 0 Then Exit Sub
        If cmbPerfiles.SelectedIndex = -1 Then Exit Sub
        MarcaPermisos(False)
        MarcaAutorizaciones(False)
        If NumAplicacion = cmbPerfiles.SelectedValue Then 'cmbPerfiles.ItemData(cmbPerfiles.ListIndex) Then
            BloqueaChecks()
        End If
        'If vsbBarra.Visible Then vsbBarra = 0
        'If vsbBarra2.Visible Then vsbBarra2 = 0
        If cmbUsuarios.SelectedIndex > -1 Then cmdActualizar.Enabled = True
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
                'If Not Editable Then
                '    For ln_Indice = 0 To gn_TotalPermisos - 1
                '        If LstChkPermisos.Items(ln_Indice) = 1 Then
                '            'LstChkPermisos.Items(ln_Indice).Enabled = False
                '        End If
                '    Next ln_Indice
                'End If
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
        'For i = 0 To LstChkComentario.Items.Count - 1
        '    LstChkComentario.SetItemChecked(i, False)
        'Next
        If gn_TotalAutorizaciones > 0 Then
            'ls_Accesos = gc_Perfiles(Forma.cmbPerfiles.ItemData(Forma.cmbPerfiles.ListIndex)).Autorizaciones
            ls_Accesos = cmbPerfiles.SelectedItem.Row.ItemArray(3)
            If objModPErmisos.ZeroTrim(ls_Accesos) <> "" Then
                For i = 0 To gn_TotalAutorizaciones - 1
                    'If Trim(LstChkAutorizaciones.Items(i).Caption) <> "Disponible" Then
                    '    LstChkAutorizaciones.Items(i).Enabled = True
                    'End If
                    'LstChkComentario.SetItemChecked(i, ga_Autorizaciones(i).Comentario)
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
                For i = 0 To gn_TotalAutorizaciones - 1
                    'LstChkComentario.SetItemChecked(i, ga_Autorizaciones(i).Comentario)
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
    End Sub

    Private Sub cmdActualizar_Click(sender As Object, e As EventArgs) Handles cmdActualizar.Click
        If NumAplicacion <> "" Then
            '------------------------------------------------------- RACB 22/03/2023
            Dim objGlobal As New Cursors
            If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
                Exit Sub
            End If
            '------------------------------------------------------- RACB 22/03/2023
            If cmbPerfiles.SelectedValue > 0 Then
                Dim ls_sql As String
                Dim ls_TotalPermisos As String
                Dim ls_TotalAutoriza As String
                Dim ln_PerfilActualiza As Integer
                Dim ln_UsuarioActualiza As Integer
                Dim dtRespuesta As DataTable
                Dim NumRegistros As Integer
                'If cmbUsuarios.ListIndex > -1 Then
                If cmbUsuarios.SelectedIndex > -1 Then
                    'If cmbPerfiles.ListIndex > -1 Then
                    If cmbPerfiles.SelectedIndex > -1 Then
                        ln_PerfilActualiza = cmbPerfiles.SelectedValue 'cmbPerfiles.ItemData(cmbPerfiles.ListIndex)  ' Si se le asigno un perfil de la lista.
                    Else
                        ln_PerfilActualiza = NumAplicacion                                     ' Si no se le asigna el perfil por defecto.
                    End If
                    ln_UsuarioActualiza = cmbUsuarios.SelectedValue 'cmbUsuarios.ItemData(cmbUsuarios.ListIndex)
                    ls_TotalPermisos = "0000000000000000000000000000000000000000000000000000000000000" 'TotalAccesos()
                    ls_TotalAutoriza = TotalAutorizaciones()
                    ' Actualiza
                    ls_sql = "SELECT PU.usuario " &
                             "FROM CATALOGOS.dbo.PERMISOS_X_USUARIO_HEXA AS PU" &
                             " JOIN CATALOGOS.dbo.PERFIL_HEXA AS PF" &
                             " ON (PU.perfil=PF.perfil) " &
                             "WHERE PU.usuario=" & ln_UsuarioActualiza &
                             " AND PF.aplicacion in " & NumAplicacion
                    'dbExecQuery ls_sql
                    'dbGetRecord
                    dtRespuesta = objDataSourse.RealizaConsulta(ls_sql)
                    ' Si el usuario ya existe para esta aplicacion, entonces hace un update.
                    'If Not IsdbError Then
                    If dtRespuesta IsNot Nothing And dtRespuesta.Rows.Count > 0 Then
                        ls_sql = "UPDATE CATALOGOS.dbo.PERMISOS_X_USUARIO_HEXA"
                        ls_sql = ls_sql & " SET masc_permisos='" & ls_TotalPermisos
                        ls_sql = ls_sql & "', masc_autorizaciones='" & ls_TotalAutoriza
                        ls_sql = ls_sql & "', perfil=" & ln_PerfilActualiza
                        ls_sql = ls_sql & " WHERE usuario=" & ln_UsuarioActualiza
                        ls_sql = ls_sql & " AND perfil=" & mn_PerfilAsignado
                        ls_sql = ls_sql & " AND masc_permisos='" & ms_PermisosIndep
                        ls_sql = ls_sql & "' AND masc_autorizaciones='" & ms_AutorizaIndep & "'"
                    Else
                        'Si el usuario no existe para esta aplicacion entonces lo da de alta.
                        ls_sql = "INSERT INTO CATALOGOS.dbo.PERMISOS_X_USUARIO_HEXA (perfil, usuario, masc_permisos, masc_autorizaciones) " &
                                 "VALUES " & " (" & ln_PerfilActualiza & ", " & ln_UsuarioActualiza & ",'" & ls_TotalPermisos & "', '" & ls_TotalAutoriza & "')"
                    End If
                    'dbEndQuery
                    Do
                        'dbExecQuery ls_sql
                        NumRegistros = objDatasource.insertar(ls_sql)
                        If NumRegistros <= 0 Then
                            'dbEndQuery
                            If MsgBox("Ocurrio un error al Registrar la Actualización. La Operación fue Cancelada." & vbCr _
                               & "                            ¿Desea Reintentar la Operación?", vbRetryCancel + vbCritical, "Aviso") <> vbRetry Then
                                Exit Do
                            End If
                        Else
                            'Registra la modificación en la bitacora
                            If NumAplicacion = "(1,2)" Then
                                For ContApp = 1 To 2
                                    ls_sql = "INSERT INTO CATALOGOS.dbo.BITACORA_PERMISOS_HEXA "
                                    ls_sql = ls_sql & "(usuario, fecha_modificacion, masc_permisos, "
                                    ls_sql = ls_sql & "masc_autorizaciones, usuario_valida, aplicacion, nombre_pc) "
                                    ls_sql = ls_sql & "VALUES (" & ln_UsuarioActualiza & ", getdate(), '"
                                    ls_sql = ls_sql & ls_TotalPermisos & "', '" & ls_TotalAutoriza & "', " & usuario & ", " & ContApp
                                    ls_sql = ls_sql & ", '" & gnGetComputerName() & "')"
                                    Do
                                        'dbEndQuery
                                        'dbExecQuery ls_sql
                                        NumRegistros = objDatasource.insertar(ls_sql)
                                        'If Not IsdbError Then
                                        If NumRegistros > 0 Then
                                            MsgBox("¡La actualización se registro con exito!", vbInformation + vbOKOnly, "Aviso")
                                            Exit Do
                                        Else
                                            If MsgBox("Ocurrio un error al registrar la actualización en bitácora." & vbCrLf &
                                              "¿Desea Reintentar la Operación?", vbRetryCancel + vbCritical, "Error") <> vbRetry Then
                                                Exit Do
                                            End If
                                        End If
                                    Loop
                                Next
                            Else
                                ls_sql = "INSERT INTO CATALOGOS.dbo.BITACORA_PERMISOS_HEXA "
                                ls_sql = ls_sql & "(usuario, fecha_modificacion, masc_permisos, "
                                ls_sql = ls_sql & "masc_autorizaciones, usuario_valida, aplicacion, nombre_pc) "
                                ls_sql = ls_sql & "VALUES (" & ln_UsuarioActualiza & ", getdate(), '"
                                ls_sql = ls_sql & ls_TotalPermisos & "', '" & ls_TotalAutoriza & "', " & usuario & ", " & NumAplicacion
                                ls_sql = ls_sql & ", '" & gnGetComputerName() & "')"
                                Do
                                    'dbEndQuery
                                    'dbExecQuery ls_sql
                                    NumRegistros = objDatasource.insertar(ls_sql)
                                    'If Not IsdbError Then
                                    If NumRegistros > 0 Then
                                        MsgBox("¡La actualización se registro con exito!", vbInformation + vbOKOnly, "Aviso")
                                        Exit Do
                                    Else
                                        If MsgBox("Ocurrio un error al registrar la actualización en bitácora." & vbCrLf &
                                          "¿Desea Reintentar la Operación?", vbRetryCancel + vbCritical, "Error") <> vbRetry Then
                                            Exit Do
                                        End If
                                    End If
                                Loop
                            End If
                            'dbEndQuery

                            'Registra la modificación en la bitacora
                            If NumAplicacion = "(1,2)" Then
                                For ContApp = 1 To 2
                                    gs_Sql = "INSERT INTO CATALOGOS.dbo.BITACORA_PERFIL_PSW "
                                    gs_Sql = gs_Sql & "(usuario, fecha_modificacion, "
                                    gs_Sql = gs_Sql & "usuario_valida, aplicacion, nombre_pc, perfil) "
                                    gs_Sql = gs_Sql & "VALUES (" & ln_UsuarioActualiza & ", getdate(), "
                                    gs_Sql = gs_Sql & usuario & ", " & ContApp
                                    gs_Sql = gs_Sql & ", '" & gnGetComputerName() & "', " & mn_PerfilAsignado & ")"
                                    'dbExecQuery gs_Sql
                                    NumRegistros = objDatasource.insertar(gs_Sql)
                                    'If dbError Then
                                    If NumRegistros <= 0 Then
                                        MsgBox("Ocurrio un error al registrar la actualización en bitácora.", vbInformation, "Información")
                                    End If
                                Next
                            Else
                                gs_Sql = "INSERT INTO CATALOGOS.dbo.BITACORA_PERFIL_PSW "
                                gs_Sql = gs_Sql & "(usuario, fecha_modificacion, "
                                gs_Sql = gs_Sql & "usuario_valida, aplicacion, nombre_pc, perfil) "
                                gs_Sql = gs_Sql & "VALUES (" & ln_UsuarioActualiza & ", getdate(), "
                                gs_Sql = gs_Sql & usuario & ", " & NumAplicacion
                                gs_Sql = gs_Sql & ", '" & gnGetComputerName() & "', " & mn_PerfilAsignado & ")"
                                'dbExecQuery gs_Sql
                                NumRegistros = objDatasource.insertar(gs_Sql)
                                'If dbError Then
                                If NumRegistros <= 0 Then
                                    MsgBox("Ocurrio un error al registrar la actualización en bitácora.", vbInformation, "Información")
                                End If
                            End If
                            'dbEndQuery
                            'MERD 02-12-2008 CAMBIO SOLICITADO POR AUDITORIA ACCIONES DE LOS USUARIOS CON PERFIL DE ADMINSITRADOR
                            gs_Sql = "select distinct ph.nombre_perfil  "
                            gs_Sql = gs_Sql & "from catalogos..PERMISOS_X_USUARIO_HEXA PUH join catalogos..PERFIL_HEXA PH"
                            gs_Sql = gs_Sql & " on PUH.perfil=PH.perfil  where ph.aplicacion in " & NumAplicacion & " and ph.perfil=" & Trim(ln_PerfilActualiza)
                            'dbExecQuery gs_Sql
                            'dbGetRecord
                            dtRespuesta = objDataSourse.RealizaConsulta(gs_Sql)
                            'dbEndQuery
                            'If dbError Then
                            If dtRespuesta Is Nothing Then
                                'dbEndQuery
                                'ShowDefaultCursor
                                MsgBox("No es posible actualizar la base de datos.", vbInformation + vbOKOnly, "Aviso")
                                'If MsgBox("No es posible actualizar la base de datos. ¿Desea Reintentar?", vbYesNo + vbCritical, "SQL Server Error") = vbYes Then
                                '    dbRollback
                                'Else
                                '    dbRollback
                                'End If
                            Else
                                Nom_perfil = Trim(dtRespuesta.Rows(0).Item(0))
                            End If

                            gs_Sql = "Insert into CATALOGOS..BITACORA_USUARIO "
                            gs_Sql = gs_Sql & "(FECHA_MOVIMIENTO,ESTATUS,Comentario,Usuario,usuario_valida,Aplicacion,Permisos)"
                            gs_Sql = gs_Sql & " values (getdate(),2,'PERMISOS PARA USUARIO','" & Trim(UCase(ln_UsuarioActualiza)) & "', "
                            gs_Sql = gs_Sql & "'" & Trim(usuario) & "',9, '"
                            gs_Sql = gs_Sql & Trim(Nom_perfil) & "')"
                            'dbExecQuery gs_Sql
                            NumRegistros = objDatasource.insertar(gs_Sql)
                            'If dbError Then
                            If NumRegistros <= 0 Then
                                'dbEndQuery
                                'ShowDefaultCursor
                                MsgBox("No es posible actualizar la base de datos.", vbInformation + vbOKOnly, "Aviso")
                                'If MsgBox("No es posible actualizar la base de datos. ¿Desea Reintentar?", vbYesNo + vbCritical, "SQL Server Error") = vbYes Then
                                '    dbRollback
                                'Else
                                '    dbRollback
                                'End If
                            End If
                            'cmbUsuarios_Click
                            ' Salir del ciclo
                            Exit Do
                        End If
                    Loop
                Else
                    MsgBox("¡No se ha seleccionado ningun usuario!", vbInformation + vbOKOnly, "Aviso")
                End If

                'cmdActualizar.Enabled = False
                cmbUsuarios.Focus()
            Else
                MsgBox("Seleccione un perfil valido", vbInformation + vbOKOnly, "Aviso")
            End If
        Else
            MsgBox("Seleccione una aplicacion valida", vbInformation + vbOKOnly, "Aviso")
        End If
    End Sub
    Public Function TotalAccesos() As String
        Dim i As Integer
        Dim s As String
        Dim ver = ga_Permisos
        TotalAccesos = ""
        If gn_TotalPermisos > 0 Then
            s = StrDup(gn_MaxPermiso, "0")
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
    Private Sub Cambio()
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
            'txtNombre.Focus()
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
                If cmbNombre.Items.Count > 0 Then
                    cmbNombre.DataSource.Clear()
                End If
            End If
        End If
    End Sub
    Private Sub cmbNombre_LostFocus(sender As Object, e As EventArgs) Handles cmbNombre.LostFocus
        Dim dtRespConsulta As DataTable
        'If cmbNombre.Items.Count = 0 Then
        If Trim(cmbNombre.Text) <> "" Then
            'If cmbUsuarios.SelectedIndex = -1 Then
            'ShowWaitCursor
            Dim gsSql = "Select nombre_usuario, login, "
            gsSql = gsSql & "origen_usuario, area_usuario, "
            gsSql = gsSql & "convert(char(10),fecha_cambio_password,105), "
            gsSql = gsSql & "password, usuario from "
            gsSql = gsSql & "CATALOGOS..USUARIO where "
            gsSql = gsSql & "nombre_usuario like '%" & Trim(cmbNombre.Text) & "%' and password not in ('ANULADO','BLOQUEAR')"
            'gsSql = gsSql & "and password <> 'ANULADO' "
            dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
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
                cmbUsuarios.SelectedIndex = -1
                cmbUsuarios.SelectedIndex = 0
                'ElseIf cmbNombre.Items.Count > 0 Then
                '    cmbNombre.SelectedIndex = -1
                'Else
                '    gsSql = SendMessage(cmbNombre.hWnd, 335, 1, 0)
                '    cmbNombre.Focus()
                'End If
            End If
        End If
        'End If
    End Sub
End Class