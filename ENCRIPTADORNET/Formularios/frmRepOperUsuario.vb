Public Class frmRepOperUsuario

    Dim sUsuario As String
    Private Sub dgvOperxUsuario_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOperxUsuario.CellContentClick

    End Sub

    Private Sub frmRepOperUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        cargaListaUsuario()
        txtFechaIni.Text = Date.Now.Date.ToString("yyyy-MM-dd")
        txtFechaFin.Text = Date.Now.Date.ToString("yyyy-MM-dd")
        'optTodos.Enabled = True
        'optTodos.Checked = False
        chkTodos.Enabled = True
        chkTodos.Checked = False
        sUsuario = ""
    End Sub

    'Private Sub cmdTodos_Click(sender As Object, e As EventArgs)
    '    If cmdTodos.Enabled = True Then
    '        cmbListaUsuarios.SelectedItem = -1
    '        cmbListaUsuarios.SelectedIndex = -1
    '    End If
    'End Sub

#Region "Subrutinas"
    Private Sub cmdConsultar_Click(sender As Object, e As EventArgs) Handles cmdConsultar.Click
        If ValidaDatos() Then
            '------------------------------------------------------- RACB 22/03/2023
            Dim objGlobal As New Cursors
            If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
                Exit Sub
            End If
            '------------------------------------------------------- RACB 22/03/2023
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            Me.dgvOperxUsuario.DataSource = ""
            iHayRegistros = 0
            If DatosCorrectos() Then
                'inicializa grid
                'dgvOperxUsuario.DataSource = ""
                'Me.Refresh()
                'ejecuta sp para crear informe
                If EjecutaConsulta() Then
                    'busca si hubo registros
                    iHayRegistros = RealizaConsultaOperaciones()
                    If iHayRegistros > 0 Then
                        llenaGridOperaciones()
                    Else
                        MsgBox("No hay operaciones para el Usuario seleccionado.", MsgBoxStyle.Exclamation, "Consulta de Operaciones por Usuario")
                    End If
                End If
                Cursor = System.Windows.Forms.Cursors.Default
            Else
                Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If
        End If
    End Sub
    Function ValidaDatos() As Boolean
        ValidaDatos = False
        If Trim(txtFechaIni.Text) = "" Then
            MsgBox("Es necesario indicar una fecha de captura inicial.", MsgBoxStyle.Information, "Fecha Faltante")
            txtFechaIni.Select()
            Exit Function
        End If
        If Trim(txtFechaFin.Text) = "" Then
            MsgBox("Es necesario indicar una fecha de captura final.", MsgBoxStyle.Information, "Fecha Faltante")
            txtFechaFin.Select()
            Exit Function
        End If
        If chkTodos.Checked = False Then
            If cmbListaUsuarios.SelectedIndex < 0 Then
                MsgBox("Debe elegir un Usuario valido o elegir la opción Todos.", MsgBoxStyle.Information, "Fecha Invalida")
                cmbListaUsuarios.Select()
            End If
        End If
        ValidaDatos = True
    End Function

    'Private Sub optTodos_CheckedChanged(sender As Object, e As EventArgs)
    '    If optTodos.Checked = True Then
    '        cmbListaUsuarios.Enabled = False
    '        cmdConsultar.Enabled = True
    '    Else
    '        cmbListaUsuarios.Enabled = True
    '        cmdConsultar.Enabled = False
    '    End If
    'End Sub


#End Region
#Region "Funciones"

    Function EjecutaConsulta() As Boolean
        Dim d As New Datasource
        Dim dt As DataTable
        Dim sSQL As String

        Dim pUsuario As String

        If chkTodos.Checked = True Then
            'pUsuario = "TODOS"
            pUsuario = "99999"
        Else
            pUsuario = sUsuario
        End If

        sSQL = "EXEC SP_OPERACIONES_X_USUARIO "
        sSQL &= " '" & txtFechaIni.Text & "', '" & txtFechaFin.Text & "', " & pUsuario

        dt = d.EjecutaSP(sSQL)

        EjecutaConsulta = True
    End Function

    Function RealizaConsultaOperaciones() As Integer
        Dim d As New Datasource
        Dim dt As DataTable
        Dim sSQL As String
        Dim iRegistros As Integer

        sSQL = "select count(*) from ticket..TMP_OPERACIONES_X_USUARIO"
        dt = d.RealizaConsulta(sSQL)

        iRegistros = dt.Rows(0).Item(0)

        RealizaConsultaOperaciones = iRegistros
    End Function

    Function llenaGridOperaciones() As Boolean
        Dim d As New Datasource
        Dim sSQL As String
        sSQL = "select * from ticket..TMP_OPERACIONES_X_USUARIO"
        sSQL = sSQL & " TMP_OxU Where TMP_OxU.fecha_captura >= '" & txtFechaIni.Text & " 00:00:00' " & "and TMP_OxU.fecha_captura <= '" & txtFechaFin.Text & " 23:59:59'" '-----RACB 04/03/2021
        dgvOperxUsuario.DataSource = d.RealizaConsulta(sSQL)
        If dgvOperxUsuario.Rows.Count > 0 Then '-----RACB 04/03/2021
            dgvOperxUsuario.Columns("monto_operacion").DefaultCellStyle.Format = "N2" '-----RACB 04/03/2021
        End If '-----RACB 04/03/2021
        llenaGridOperaciones = True

    End Function

    Function cargaListaUsuario() As Boolean
        Dim d As New Datasource
        Dim dtListaUsuario As DataTable
        Dim sSql As String

        cargaListaUsuario = False

        sSql = "Select usuario, nombre_usuario "
        sSql &= " from CATALOGOS..USUARIO "
        'sSql &= " where usuario = " & VARIABLES.usuario
        sSql &= " where password <> 'ANULADO' "
        sSql &= " and fecha_ultimo_acceso >= '2015-12-31 00:00'"
        sSql &= " order by usuario "

        'Llena combo Tipo de Cliente
        dtListaUsuario = d.RealizaConsulta(sSql)

        cmbListaUsuarios.Visible = True
        cmbListaUsuarios.DisplayMember = "nombre_usuario"
        cmbListaUsuarios.ValueMember = "usuario"
        cmbListaUsuarios.DataSource = dtListaUsuario

        cargaListaUsuario = True
    End Function

    Function DatosCorrectos() As Boolean
        DatosCorrectos = False

        If chkTodos.Checked = False Then
            If cmbListaUsuarios.SelectedIndex = -1 Then
                MsgBox("Debe elegir un Usuario valido o elegir la opción Todos.", vbInformation, "Usuario")
                cmbListaUsuarios.Select()
                Exit Function
            Else
                sUsuario = cmbListaUsuarios.SelectedValue
                'sUsuario = cmbListaUsuarios.SelectedItem(cmbListaUsuarios.SelectedValue)
                'sUsuario = cmbListaUsuarios.ValueMember(cmbListaUsuarios.SelectedValue)
            End If
        End If


        'If cmbListaUsuarios.SelectedIndex = -1 And chkTodos.Checked = False Then
        '    If chkTodos.Checked = False Then
        '        MsgBox("Debe elegir un Usuario valido o elegir la opción Todos.", vbInformation, "Usuario")
        '        Exit Function
        '    Else
        '        MsgBox("Es necesario indicar el nombre de usuario.", vbInformation, "Usuario")
        '        Exit Function
        '    End If
        '    cmbListaUsuarios.Select()
        'End If

        If Trim(txtFechaIni.Text) = "" Then
            MsgBox("En necesario indicar la fecha inicial del periodo.", vbInformation, "Dato Faltante...")
            txtFechaIni.Select()
            Exit Function
        End If
        If Trim(txtFechaFin.Text) = "" Then
            MsgBox("En necesario indicar la fecha final del periodo.", vbInformation, "Dato Faltante...")
            txtFechaFin.Select()
            Exit Function
        End If
        If CDate(txtFechaIni.Text) > CDate(txtFechaFin.Text) Then
            MsgBox("La fecha final del periodo debe ser mayor o igual a la fecha inicial.", vbInformation, "Dato Faltante...")
            txtFechaFin.Select()
            Exit Function
        End If

        DatosCorrectos = True
    End Function

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        If iHayRegistros > 0 Then
            '------------------------------------------------------- RACB 22/03/2023
            Dim objGlobal As New Cursors
            If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
                Exit Sub
            End If
            '------------------------------------------------------- RACB 22/03/2023
            fe_Inicio = txtFechaIni.Text
            fe_Fin = txtFechaFin.Text

            opcionReporte = 5    'reporte de operaciones por usuario
            ls_PorImprimir = " {TMP_OPERACIONES_X_USUARIO.fecha_captura} >= date(" & fe_Inicio.Substring(0, 4) & "," & fe_Inicio.Substring(5, 2) & "," & fe_Inicio.Substring(8, 2) & ")" '---RACB 22/03/2021 fecha_operacion
            ls_PorImprimir &= " and {TMP_OPERACIONES_X_USUARIO.fecha_captura} <= date(" & fe_Fin.Substring(0, 4) & "," & fe_Fin.Substring(5, 2) & "," & fe_Fin.Substring(8, 2) & ")" '---RACB 22/03/2021 fecha_operacion
            RepOperativa.ShowDialog()
        End If
    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        If chkTodos.Checked = True Then
            cmbListaUsuarios.Enabled = False
            cmdConsultar.Enabled = True
        Else
            cmbListaUsuarios.Enabled = True
            cmdConsultar.Enabled = True
        End If
    End Sub

    Private Sub cmbListaUsuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaUsuarios.SelectedIndexChanged

    End Sub




#End Region
End Class