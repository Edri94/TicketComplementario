Public Class frmUnidadOrg
    Private mnTipoConsulta As Byte
    Private ms_CurrName As String
    Private ms_CurrNum As String
    Private mb_Changes As Boolean
    Private mb_NodeEdit As Boolean
    Private mnFuncMove As Long
    Private mnUOrgMove As Long
    Private mnNumUnOrg As Long
    Private ls_NomUnidad As String
    Private gbTreeCharged As Boolean
    Private gaArbolUnOrg() As UnidadOrg
    Private gsSql As String
    Private dtRespConsulta As DataTable
    Private dtRespFuncConsulta As DataTable
    Private dtRespConsultaTipo As DataTable
    Private objDatasource As New Datasource
    Private dtHijos As DataTable
    Private l As New Libreria
    Private SQL_Query As String
    Private iFormularioOrigen As Integer = 0
    Private iCRAnterior As String
    Private iCRAnteriorNav As String
    Private iControlCargando As Integer = 0
    Public Sub New(MenuOpcion As Integer)
        InitializeComponent()
        iFormularioOrigen = MenuOpcion
    End Sub
    '---------------------------------------------------
    'Limpia todos los campos del arbol
    '---------------------------------------------------
    Private Sub LimpiaCampos()
        'lblTipo = ""
        'lblTipo.Refresh
        txtNumFuncs.Text = ""
        'lblNumFuncs.Refresh
        cmbNombre.DataSource = Nothing
        txtNumUnidad.Text = ""
        txtNumUnidad.Refresh()
        txtPadres.Text = ""
        txtPadres.Refresh()
        dgvFuncionarios.DataSource = Nothing
        chkEstrategica.Checked = 0
        cmdLista.Enabled = False
        cmbTipoUnidad.SelectedIndex = 0
    End Sub
    Private Sub BuscaListaUnidadOrganizacional(iOpcion As Integer)
        SQL_Query = "WITH UNIDAD_ORGANIZACIONAL_RUTA AS 
                    (
                             SELECT A.unidad_organizacional, A.unidad_organizacional_padre, A.descripcion_unidad_organizacio,RTRIM (LTRIM (Cast(A.unidad_organizacional AS VARCHAR(999)))) ruta,tipo_unidad_organizacional,estrategica, unidad_org_bancomer
                             FROM   FUNCIONARIOS..UNIDAD_ORGANIZACIONAL A
                             WHERE  A.unidad_organizacional_padre = -1 
                             UNION ALL
                             SELECT B.unidad_organizacional, B.unidad_organizacional_padre, B.descripcion_unidad_organizacio,RTRIM (LTRIM (Cast(C.ruta + '\' + Cast(B.unidad_organizacional AS VARCHAR(999)) AS VARCHAR(999)))) ruta,B.tipo_unidad_organizacional,B.estrategica, B.unidad_org_bancomer
                             FROM   FUNCIONARIOS..UNIDAD_ORGANIZACIONAL B
                                    INNER JOIN UNIDAD_ORGANIZACIONAL_RUTA C ON B.unidad_organizacional_padre = C.unidad_organizacional
                             WHERE  B.unidad_organizacional_padre IS NOT NULL
                    )
                    SELECT UOR.unidad_organizacional,UOR.descripcion_unidad_organizacio, UOR.ruta,TU.tipo_unidad_organizacional,CASE UOR.estrategica When 1 Then 'true' When 0 Then 'false' END estrategica, UOR.unidad_organizacional_padre
                    FROM UNIDAD_ORGANIZACIONAL_RUTA UOR,
                    FUNCIONARIOS..TIPO_UNIDAD_ORGANIZACIONAL TU
                    WHERE UOR.tipo_unidad_organizacional = TU.tipo_unidad_organizacional 
                    AND UOR.unidad_organizacional>0
                    AND UOR.UNIDAD_ORGANIZACIONAL_PADRE <> 3737 "
        If iOpcion = 1 Then
            SQL_Query = SQL_Query & "AND UOR.unidad_organizacional = " & txtNumUnidad.Text & " "
        ElseIf iOpcion = 2 Then
            SQL_Query = SQL_Query & "AND UOR.descripcion_unidad_organizacio like '%" & cmbNombre.Text & "%' "
        End If
        SQL_Query = SQL_Query & "ORDER BY UOR.unidad_organizacional;"
        dtRespConsulta = objDatasource.RealizaConsulta(SQL_Query)
        cmbNombre.DisplayMember = "descripcion_unidad_organizacio"
        cmbNombre.ValueMember = "unidad_organizacional"
        cmbNombre.DataSource = dtRespConsulta
        SQL_Query = "SELECT * FROM FUNCIONARIOS..TIPO_UNIDAD_ORGANIZACIONAL"
        If cmbTipoUnidad.DataSource Is Nothing Then
            dtRespConsultaTipo = objDatasource.RealizaConsulta(SQL_Query)
            cmbTipoUnidad.ValueMember = "tipo_unidad_organizacional"
            cmbTipoUnidad.DisplayMember = "descripcion_unidad_organizacio"
            cmbTipoUnidad.DataSource = dtRespConsultaTipo
        End If
        If dtRespConsulta.Rows.Count = 0 Then
            MsgBox("No se encontró información.", vbInformation, "Unidad Organizacional")
            cmdBusca_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cbNombre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNombre.SelectedIndexChanged
        If iControlCargando = 0 Then
            txtPadres.Text = ""
            txtNumUnidad.Text = ""
            txtNumFuncs.Text = ""
            cmbTipoUnidad.SelectedIndex = -1
            chkEstrategica.Checked = False
            chkAreaInterna.Checked = False
            If cmbNombre.DataSource IsNot Nothing And cmbNombre.Items.Count > 0 And cmbNombre.SelectedIndex >= 0 Then
                txtNumUnidad.Text = cmbNombre.SelectedValue.ToString()
                SQL_Query = "Select numero_funcionario [NUM.], rtrim(nombre_funcionario)+' '+rtrim(isnull(apellido_paterno, space(0)))+' '+rtrim(isnull(apellido_materno, space(0))) NOMBRE, telefono_funcionario TEL, fax_funcionario FAX, funcionario FUNCIONARIO,CASE activo When 1 Then 'SI' When 0 Then 'NO' END ACTIVO
                    From FUNCIONARIOS..FUNCIONARIO 
                    where unidad_organizacional = " & txtNumUnidad.Text & " order by numero_funcionario"
                dtRespFuncConsulta = objDatasource.RealizaConsulta(SQL_Query)
                BuscarNombresPadres()
                dgvFuncionarios.DataSource = Nothing
            End If
            If txtNumUnidad.Text <> "" Then
                txtNumUnidad.Text = txtNumUnidad.Text.ToString().PadLeft(4, "0")
                txtNumUnidad.Refresh()
            End If
        End If
        iCRAnterior = txtNumUnidad.Text
    End Sub
    Private Sub BuscarNombresPadres()
        Dim dtRespuesta As DataTable
        Dim adrRegistro2 As DataRow()
        Dim adrRegistro As DataRow() = dtRespConsulta.Select("unidad_organizacional = " & txtNumUnidad.Text)
        Dim sPadres As String = ""
        Dim asPadres As Array
        dtRespuesta = objDatasource.RealizaConsulta("SELECT unidad_organizacional,descripcion_unidad_organizacio + '(' + LTRIM(RTRIM(unidad_org_bancomer)) + ')' From FUNCIONARIOS..UNIDAD_ORGANIZACIONAL ")
        If adrRegistro.Length > 0 Then
            For Each row As DataRow In adrRegistro
                asPadres = row.Item(2).Split(New String() {"\"}, StringSplitOptions.RemoveEmptyEntries)
                cmbTipoUnidad.SelectedValue = row.Item(3)
                txtNumFuncs.Text = dtRespFuncConsulta.Rows.Count()
                If dtRespFuncConsulta.Rows.Count() > 0 Then
                    cmdLista.Enabled = True
                Else
                    cmdLista.Enabled = False
                End If
                chkEstrategica.Checked = row.Item(4)
                For Each IPadre As String In asPadres
                    adrRegistro2 = dtRespuesta.Select("unidad_organizacional = " & IPadre)
                    For Each row2 As DataRow In adrRegistro2
                        sPadres = sPadres & row2.Item(1).ToString & "\"
                    Next
                Next
                Dim iUltimoNodoPadre = asPadres.Length() - 2
                ValidarHijos(asPadres(iUltimoNodoPadre).ToString)
            Next
            txtPadres.Text = sPadres.Substring(0, sPadres.Length - 1)
        End If
        dtRespuesta = objDatasource.RealizaConsulta("select area_interna from CATALOGOS..SUCURSAL where sucursal = '" & Trim$(txtNumUnidad.Text.PadLeft(7, "0")) & "'")
        If dtRespuesta IsNot Nothing And dtRespuesta.Rows.Count > 0 Then
            chkAreaInterna.Checked = dtRespuesta.Rows(0).Item(0)
        End If
    End Sub
    Private Sub cmdBusca_Click(sender As Object, e As EventArgs) Handles cmdBusca.Click
        LimpiaCampos()
        txtNumUnidad.Text = "0002"
        Buscar()
    End Sub
    Private Sub cmdLista_Click(sender As Object, e As EventArgs) Handles cmdLista.Click
        dgvFuncionarios.DataSource = dtRespFuncConsulta
        dgvFuncionarios.Columns("FUNCIONARIO").Visible = False
    End Sub
    Private Sub frmUnidadOrg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'cmdReporte.Enabled = False
        'cmdReporte2.Enabled = False
        'cmdReporte3.Enabled = False
        If iFormularioOrigen = 1 Then
            cmdArbol.Visible = False
            pnlEdicion.Enabled = False
        ElseIf iFormularioOrigen = 2 Then
            Me.Text = "Mantenimiento de Unidades Organizacionales"
            cmdArbol.Visible = True
            pnlEdicion.Enabled = True
            cmdReporte.Visible = False
            cmdReporte3.Visible = False
        End If
        SQL_Query = "SELECT * FROM FUNCIONARIOS..TIPO_UNIDAD_ORGANIZACIONAL"
        If cmbTipoUnidad.DataSource Is Nothing Then
            dtRespConsultaTipo = objDatasource.RealizaConsulta(SQL_Query)
            cmbTipoUnidad.ValueMember = "tipo_unidad_organizacional"
            cmbTipoUnidad.DisplayMember = "descripcion_unidad_organizacio"
            cmbTipoUnidad.DataSource = dtRespConsultaTipo
        End If
        txtNumUnidad.Text = 2
        BuscaListaUnidadOrganizacional(1)
    End Sub
    Private Sub cmdReporte_Click(sender As Object, e As EventArgs) Handles cmdReporte.Click
        Dim lsTipo As String = ""
        Dim lsFormula As String = ""
        Dim Var_Banca As String
        Dim aux As String

        Dim rptDoc As New ReportDocument
        Dim lsAmbiente As String = ""
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        mnFuncMove = 0
        mnUOrgMove = 0
        If Trim(cmbNombre.Text) = "" Or cmbNombre.SelectedIndex = -1 Then
            MsgBox("Seleccione una unidad organizacional.", vbInformation, "Mensaje")
            Exit Sub
        Else
            'CPB 18-Julio-2006
            'Actualiza la tabla Funcionario.UNIDAD_ORGAIZACIONAL_RESUMEN para todos los funcionarios
            'ActualizaUnidadOrg

            'MDIFuncs.rptFuncs.ReportFileName = REPSPATH & "\Cons_Func_Agen.rpt"
            'MDIFuncs.rptFuncs.Formulas(0) = "Fecha_Hoy='" & gsFechaHoy & "'"
            'MDIFuncs.rptFuncs.Formulas(1) = "Hora = '" & HoraSistema & "'"
            lsRutaFolder = My.Application.Info.DirectoryPath & "\" & l.sFolderRPT & "\"
            lsReporte = lsRutaFolder & "Cons_Func_Agen" & lsAmbiente & ".rpt"
            rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
            l.logonBDreporte(rptDoc, 1)
            rptDoc.DataDefinition.FormulaFields.Item("Fecha_Hoy").Text = "'" & Now().ToString("dd-MM-yyyy") & "'"
            rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Now().ToString("hh:mm") & "'"

            'If InStr(UCase(lblTipo), "ESTRATEGICA") <> 0 Then
            '    lsTipo = Trim(Left(lblTipo, InStr(UCase(lblTipo), "ESTRATEGICA") - 1))
            'Else
            '    lsTipo = lblTipo
            'End If
            If chkEstrategica.Checked <> False Then
                lsTipo = UCase(UCase(Trim(DirectCast(cmbTipoUnidad.SelectedItem, System.Data.DataRowView).Row.ItemArray(1))))
            Else
                lsTipo = lsTipo
            End If

            'Modificación para resolver el Requerimiento No.2
            'Se extrajo el nombre de la banca para realizar el match en la formula del reporte
            'Modificación realizada por JEMG 31/01/2001
            'Quita la palabra ROOT(0) \
            If Len(Trim(txtPadres.Text)) > 0 Then
                aux = Microsoft.VisualBasic.Right(txtPadres.Text, Len(txtPadres.Text) - InStr(txtPadres.Text, "\"))
                'Quita la palabra Bancomer(1) \
                If Len(Trim(aux)) > 0 Then
                    aux = Microsoft.VisualBasic.Right(aux, Len(aux) - InStr(aux, "\"))
                    aux = Trim(aux) & "\"
                    'Toma la Banca
                    If Len(Trim(aux)) > 0 Then
                        Var_Banca = Microsoft.VisualBasic.Left(aux, InStr(aux, "\") - 1)
                    End If
                End If
            End If

            Select Case UCase(Trim(lsTipo))
                Case "BANCA"
                    lsFormula = "{vw_a_func_con_ctas_tkt.banca}='" & UCase(UCase(Trim(DirectCast(cmbNombre.SelectedItem, System.Data.DataRowView).Row.ItemArray(1)))) & "(" & Trim(txtNumUnidad.Text) & ")'"
                Case "DIVISION"
                    lsFormula = "{vw_a_func_con_ctas_tkt.banca}='" & UCase(Var_Banca) & "'"
                    lsFormula = lsFormula & " And {vw_a_func_con_ctas_tkt.division}='" & UCase(UCase(UCase(Trim(DirectCast(cmbNombre.SelectedItem, System.Data.DataRowView).Row.ItemArray(1))))) & "(" & Trim(txtNumUnidad.Text) & ")'"
                Case "CENTRO REGIONAL"
                    lsFormula = "{vw_a_func_con_ctas_tkt.banca}='" & UCase(Var_Banca) & "'"
                    lsFormula = lsFormula & " And {vw_a_func_con_ctas_tkt.cr}='" & UCase(UCase(UCase(Trim(DirectCast(cmbNombre.SelectedItem, System.Data.DataRowView).Row.ItemArray(1))))) & "(" & Trim(txtNumUnidad.Text) & ")'"
                Case "PLAZA"
                    lsFormula = "{vw_a_func_con_ctas_tkt.banca}='" & UCase(Var_Banca) & "'"
                    lsFormula = lsFormula & " And {vw_a_func_con_ctas_tkt.plaza}='" & UCase(UCase(UCase(Trim(DirectCast(cmbNombre.SelectedItem, System.Data.DataRowView).Row.ItemArray(1))))) & "(" & Trim(txtNumUnidad.Text) & ")'"
                Case "SUCURSAL"
                    lsFormula = "{vw_a_func_con_ctas_tkt.banca}='" & UCase(Var_Banca) & "'"
                    lsFormula = lsFormula & " And {vw_a_func_con_ctas_tkt.sucursal}='" & UCase(UCase(UCase(Trim(DirectCast(cmbNombre.SelectedItem, System.Data.DataRowView).Row.ItemArray(1))))) & "(" & Trim(txtNumUnidad.Text) & ")'"
            End Select

            'Solo se debem mostrar funcionarios activos
            'If chkAnulados.Value = 0 Then
            If UCase(Trim(lsTipo)) = "BANCOMER" Then
                lsFormula = lsFormula & " {vw_a_func_con_ctas_tkt.activo} = 1"
            Else
                If lsFormula <> "" Then
                    lsFormula = lsFormula & " and {vw_a_func_con_ctas_tkt.activo} = 1"
                Else
                    lsFormula = lsFormula & " {vw_a_func_con_ctas_tkt.activo} = 1"
                End If
            End If
            'End If
            'ShowWaitCursor
            'MDIFuncs.rptFuncs.SelectionFormula = lsFormula
            rptDoc.RecordSelectionFormula = lsFormula
            'MaximizaReporte MDIFuncs.rptFuncs
            opcionReporte = 17
            RepOperativa.reporteOFAC = rptDoc
            RepOperativa.ShowDialog()
            'ShowDefaultCursor
        End If
    End Sub

    Private Sub cmdReporte2_Click(sender As Object, e As EventArgs) Handles cmdReporte2.Click
        Dim lsTipo As String
        Dim Var_Banca As String
        Dim aux As String

        Dim rptDoc As New ReportDocument
        Dim lsAmbiente As String = ""
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        If cmbNombre.Text = "" Then
            MsgBox("Seleccione una unidad organizacional.", vbInformation, "Unidad Organizacional")
            Exit Sub
        Else
            'CPB 18-Julio-2006
            'Actualiza la tabla Funcionario.UNIDAD_ORGAIZACIONAL_RESUMEN para todos los funcionarios
            'ActualizaUnidadOrg

            'If InStr(UCase(lblTipo), "ESTRATEGICA") <> 0 Then
            '    lsTipo = Trim(Microsoft.VisualBasic.Left(lblTipo, InStr(UCase(lblTipo), "ESTRATEGICA") - 1))
            'Else
            '    lsTipo = lblTipo
            'End If
            If chkEstrategica.Checked <> False Then
                lsTipo = UCase(UCase(Trim(DirectCast(cmbTipoUnidad.SelectedItem, System.Data.DataRowView).Row.ItemArray(1))))
            Else
                lsTipo = lsTipo
            End If

            'RepConOrg.ReportFileName = REPSPATH & "\CONS_FUNC_2_Agen.rpt"
            'RepConOrg.Formulas(0) = "Fecha_hoy ='" & gsFechaHoy & "'"
            'RepConOrg.Formulas(1) = "Hora = '" & HoraSistema & "'"
            lsRutaFolder = My.Application.Info.DirectoryPath & "\" & l.sFolderRPT & "\"
            lsReporte = lsRutaFolder & "CONS_FUNC_2_Agen" & lsAmbiente & ".rpt"
            rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
            l.logonBDreporte(rptDoc, 1)
            rptDoc.DataDefinition.FormulaFields.Item("Fecha_hoy").Text = "'" & Now().ToString("dd-MM-yyyy") & "'"
            rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Now().ToString("hh:mm") & "'"
            'Modificación para resolver la solicitud no.2
            'Se extrajo el nombre de la banca para realizar el match en la formula del reporte
            'Modificación realizada por JEMG 31/01/2001
            'Quita la palabra ROOT(0) \
            If Len(Trim(txtPadres.Text)) > 0 Then
                aux = Microsoft.VisualBasic.Right(txtPadres.Text, Len(txtPadres.Text) - InStr(txtPadres.Text, "\"))
                'Quita la palabra Bancomer(1) \
                If Len(Trim(aux)) > 0 Then
                    aux = Microsoft.VisualBasic.Right(aux, Len(aux) - InStr(aux, "\"))
                    aux = Trim(aux) & "\"
                    'Toma la Banca
                    If Len(Trim(aux)) > 0 Then
                        Var_Banca = Microsoft.VisualBasic.Left(aux, InStr(aux, "\") - 1)
                    End If
                End If
            End If
            Select Case UCase(Trim(lsTipo))
                Case "BANCA"
                    rptDoc.RecordSelectionFormula = "UpperCase({UNIDAD_ORGANIZACIONAL_RESUMEN.banca})='" & UCase(UCase(UCase(Trim(DirectCast(cmbNombre.SelectedItem, System.Data.DataRowView).Row.ItemArray(1))))) & "(" & Trim(txtNumUnidad.Text) & ")'"
                Case "DIVISION"
                    rptDoc.RecordSelectionFormula = "UpperCase({UNIDAD_ORGANIZACIONAL_RESUMEN.banca})='" & UCase(Var_Banca) & "'"
                    rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & "And UpperCase({UNIDAD_ORGANIZACIONAL_RESUMEN.division})='" & UCase(UCase(UCase(Trim(DirectCast(cmbNombre.SelectedItem, System.Data.DataRowView).Row.ItemArray(1))))) & "(" & Trim(txtNumUnidad.Text) & ")'"
                Case "CENTRO REGIONAL"
                    rptDoc.RecordSelectionFormula = "UpperCase({UNIDAD_ORGANIZACIONAL_RESUMEN.banca})='" & UCase(Var_Banca) & "'"
                    rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & "And UpperCase({UNIDAD_ORGANIZACIONAL_RESUMEN.cr})='" & UCase(UCase(UCase(Trim(DirectCast(cmbNombre.SelectedItem, System.Data.DataRowView).Row.ItemArray(1))))) & "(" & Trim(txtNumUnidad.Text) & ")'"
                Case "PLAZA"
                    rptDoc.RecordSelectionFormula = "UpperCase({UNIDAD_ORGANIZACIONAL_RESUMEN.banca})='" & UCase(Var_Banca) & "'"
                    rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & "And UpperCase({UNIDAD_ORGANIZACIONAL_RESUMEN.plaza})='" & UCase(UCase(UCase(Trim(DirectCast(cmbNombre.SelectedItem, System.Data.DataRowView).Row.ItemArray(1))))) & "(" & Trim(txtNumUnidad.Text) & ")'"
                Case "SUCURSAL"
                    rptDoc.RecordSelectionFormula = "UpperCase({UNIDAD_ORGANIZACIONAL_RESUMEN.banca})='" & UCase(Var_Banca) & "'"
                    rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & "And UpperCase({UNIDAD_ORGANIZACIONAL_RESUMEN.sucursal})='" & UCase(UCase(UCase(Trim(DirectCast(cmbNombre.SelectedItem, System.Data.DataRowView).Row.ItemArray(1))))) & "(" & Trim(txtNumUnidad.Text) & ")'"
            End Select

            If UCase(Trim(lsTipo)) = "BANCOMER" Then
                rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & " {FUNCIONARIO.activo} = 1"
            Else
                If rptDoc.RecordSelectionFormula <> "" Then
                    rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & " AND "
                End If
                rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & " {FUNCIONARIO.activo} = 1"
            End If
            'MaximizaReporte RepConOrg
            opcionReporte = 17
            RepOperativa.reporteOFAC = rptDoc
            RepOperativa.ShowDialog()
        End If
    End Sub
    Private Sub cmdReporte3_Click(sender As Object, e As EventArgs) Handles cmdReporte3.Click
        Dim lsTipo As String = ""
        Dim Var_Banca As String = ""
        Dim aux As String = ""
        On Error GoTo errImprime

        Dim rptDoc As New ReportDocument
        Dim lsAmbiente As String = ""
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        If DirectCast(cmbNombre.DataSource, System.Data.DataTable).Rows.Count Then
            If UCase(UCase(UCase(Trim(DirectCast(cmbNombre.SelectedItem, System.Data.DataRowView).Row.ItemArray(1))))) = "" Then
                MsgBox("Seleccione una unidad organizacional.", vbInformation, "Unidad Organizacional")
                Exit Sub
            Else
                'CPB 18-Julio-2006
                'Actualiza la tabla Funcionario.UNIDAD_ORGAIZACIONAL_RESUMEN para todos los funcionarios
                'ActualizaUnidadOrg
                'If InStr(UCase(lblTipo), "ESTRATEGICA") <> 0 Then
                '    lsTipo = Trim(Microsoft.VisualBasic.Left(lblTipo, InStr(UCase(lblTipo), "ESTRATEGICA") - 1))
                'Else
                '    lsTipo = lblTipo
                'End If
                If chkEstrategica.Checked <> False Then
                    lsTipo = UCase(UCase(Trim(DirectCast(cmbTipoUnidad.SelectedItem, System.Data.DataRowView).Row.ItemArray(1))))
                Else
                    lsTipo = lsTipo
                End If
                'RepConOrg.ReportFileName = REPSPATH & "\CONS_FUNC_2_Agen.rpt"
                'RepConOrg.Formulas(0) = "Fecha_hoy ='" & gsFechaHoy & "'"
                'RepConOrg.Formulas(1) = "Hora = '" & HoraSistema & "'"
                lsRutaFolder = My.Application.Info.DirectoryPath & "\" & l.sFolderRPT & "\"
                lsReporte = lsRutaFolder & "CONS_FUNC_2_Agen" & lsAmbiente & ".rpt"
                rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                l.logonBDreporte(rptDoc, 1)
                rptDoc.DataDefinition.FormulaFields.Item("Fecha_hoy").Text = "'" & Now().ToString("dd-MM-yyyy") & "'"
                rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Now().ToString("hh:mm") & "'"
                '********
                ' Se quito la forma anterior ya que al ser anulados se toma todo el nombre del nodo como
                ' lo que le corresponda ya sea (division, centro reg., plaza ó sucursal
                ' Miguel Angel Ramírez Belmont
                'aux = txtPadres.Text
                'Token(aux, "\")
                'Var_Banca = UCase(Trim(Token(aux, "\")))
                'aux = UCase(Mid(aux, 1, 45))
                'Quita la palabra ROOT(0) \
                If Len(Trim(txtPadres.Text)) > 0 Then
                    aux = Microsoft.VisualBasic.Right(txtPadres.Text, Len(txtPadres.Text) - InStr(txtPadres.Text, "\"))
                    'Quita la palabra Bancomer(1) \
                    If Len(Trim(aux)) > 0 Then
                        aux = Microsoft.VisualBasic.Right(aux, Len(aux) - InStr(aux, "\"))
                        aux = Trim(aux) & "\"
                        'Toma la Banca
                        If Len(Trim(aux)) > 0 Then
                            Var_Banca = Microsoft.VisualBasic.Left(aux, InStr(aux, "\") - 1)
                        End If
                    End If
                End If
                aux = UCase(UCase(Trim(DirectCast(cmbNombre.SelectedItem, System.Data.DataRowView).Row.ItemArray(1)))) & "(" & Trim(txtNumUnidad.Text) & ")"


                'RepConOrg.SelectionFormula = "UpperCase({UNIDAD_ORGANIZACIONAL_RESUMEN.banca})='" & Var_Banca & "' "
                rptDoc.RecordSelectionFormula = "UpperCase({UNIDAD_ORGANIZACIONAL_RESUMEN.banca})='" & Var_Banca & "' "
                Select Case UCase(Trim(lsTipo))
                    Case "DIVISION"
                        rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & "And UpperCase({UNIDAD_ORGANIZACIONAL_RESUMEN.division})='" & aux & "'"
                    Case "CENTRO REGIONAL"
                        rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & "And UpperCase({UNIDAD_ORGANIZACIONAL_RESUMEN.cr})='" & aux & "'"
                    Case "PLAZA"
                        rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & "And UpperCase({UNIDAD_ORGANIZACIONAL_RESUMEN.plaza})='" & aux & "'"
                    Case "SUCURSAL"
                        rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & "And UpperCase({UNIDAD_ORGANIZACIONAL_RESUMEN.sucursal})='" & aux & "'"
                End Select
                If UCase(lsTipo) = "BANCOMER" Then
                    rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & " {FUNCIONARIO.activo} in [1]"
                Else
                    If rptDoc.RecordSelectionFormula <> "" Then
                        rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & " AND {FUNCIONARIO.activo} = 1"
                    Else
                        rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & " {FUNCIONARIO.activo} = 1"
                    End If
                End If
                'MaximizaReporte RepConOrg
                opcionReporte = 17
                RepOperativa.reporteOFAC = rptDoc
                RepOperativa.ShowDialog()
            End If
            Exit Sub
errImprime:
            If Err.Number = 20507 Then
                MsgBox("Verifique la ruta de su reporte", vbExclamation, "Información")
            Else
                MsgBox(Err.Number & " " & Err.Description, vbCritical, "Error")
            End If
        End If
    End Sub
    Private Function Token(tmp As String, search As String) As String
        Dim X As Long
        X = InStr(1, tmp, search)
        If X Then
            Token = Mid$(tmp, 1, X - 1)
            tmp = Mid$(tmp, X + 1)
        Else
            Token = tmp
            tmp = ""
        End If
    End Function
    Private Sub cmdCierra_Click(sender As Object, e As EventArgs) Handles cmdCierra.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir de consulta de unidades") <> vbYes Then
            Exit Sub
        End If
        Me.Close()
    End Sub
    Private Sub cmdAgregar_Click(sender As Object, e As EventArgs) Handles cmdAgregar.Click
        If cmbNombre.SelectedIndex >= 0 And cmbTipoUnidad.SelectedValue = 3 Then
            '------------------------------------------------------- RACB 22/03/2023
            Dim objGlobal As New Cursors
            If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
                Exit Sub
            End If
            '------------------------------------------------------- RACB 22/03/2023
            Dim lsNumUnidad As String
            Dim lsBancomer As String
            Dim lsNombre As String
            Dim lsTipo As String
            Dim lsTipoUnidad As String
            Dim lnTipo As Integer
            Dim loNodo As TreeNode 'Node
            Dim g As New Cursors

            mnFuncMove = 0
            mnUOrgMove = 0
            '***************
            If GestorAnulado(txtPadres.Text) Then 'If GestorAnulado(tvArbol.SelectedItem) Then  'StrComp("FANU", Right(tvArbol.SelectedItem.Key, 4), vbTextCompare) = 0 Then
                MsgBox("Esta parte del árbol es informativa, no se pueden agregar hijos", vbInformation, "Información")
                Exit Sub
            Else
                '**************
                If MsgBox("¿Esta seguro de querer agregar una unidad organizacional?", vbQuestion + vbYesNo, "Añadir Unidad Organizacional") = vbNo Then
                    'No desea proseguir con la operacion
                    Exit Sub
                End If
                If MsgBox("¿Esta seguro de agregar un hijo a " & UCase(UCase(UCase(Trim(DirectCast(cmbNombre.SelectedItem, System.Data.DataRowView).Row.ItemArray(1))))) & "?",'tvArbol.SelectedItem.text & "?",
                vbYesNo + vbQuestion, "Mensaje") = vbNo Then
                    Exit Sub
                End If
                lsNombre = InputBox("¿Cual es el nombre de la nueva unidad?", "Nombre de la Unidad")
                'Se revisa que el nombre no contenga caracteres invalidos
                lsNombre = UCase(Trim(g.ChecaTexto(lsNombre)))
                If Trim(lsNombre) = "" Then
                    MsgBox("No es posible agregar una unidad sin nombre.", vbInformation, "Aviso")
                    Exit Sub
                End If
                If InStr(UCase(Trim(cmbTipoUnidad.Text)), "PLAZA") Then
                    lsBancomer = InputBox("¿Numero de centro responsable?", "Numero de Unidad Bancomer")
                    lsBancomer = lsBancomer.ToString().PadLeft(4, "0")
                Else
                    lsBancomer = InputBox("¿Numero de unidad organizacional Bancomer?", "Numero de Unidad Bancomer")
                    lsBancomer = lsBancomer.ToString().PadLeft(4, "0")
                End If
                If Trim(lsBancomer) = "" Then
                    MsgBox("No es posible agregar una unidad sin número.", vbInformation, "Aviso")
                    Exit Sub
                End If
                'Se recorta el numero de UOB a 10 caracteres
                lsBancomer = Microsoft.VisualBasic.Left(Trim(lsBancomer), 10)
                If Not IsNumeric(lsBancomer) Then
                    MsgBox("El campo unidad organizacional Bancomer debe ser numérico.", vbInformation, "Aviso")
                    Exit Sub
                End If
                'lsTipoUnidad = InputBox("¿Cual es el tipo de unidad?" & vbCrLf & "0) ROOT" & vbCrLf & "1) BANCA" & vbCrLf & "2) DIVISION" & vbCrLf & "3) CENTRO REGIONAL" & vbCrLf & "4) PLAZA" & vbCrLf & "5) SUCURSAL" & vbCrLf & "6) LIBRE" & vbCrLf & "7) BANCOMER" & vbCrLf & "8) BAM", "Nombre de la Unidad")
                'lsTipoUnidad = UCase(Trim(g.ChecaTexto(lsTipoUnidad)))
                'If Trim(lsTipoUnidad) = "" Then
                '    MsgBox("No es posible agregar una unidad sin tipo.", vbInformation, "Aviso")
                '    Exit Sub
                'End If
                lsTipoUnidad = 4
                'gsSql = "Select max(unidad_organizacional)+1 From " 
                'gsSql = gsSql & "UNIDAD_ORGANIZACIONAL "
                gsSql = "Select COUNT(unidad_organizacional) From FUNCIONARIOS..UNIDAD_ORGANIZACIONAL where unidad_org_bancomer = " + lsBancomer
                'Selecciona el siguiente numero de unidad organizacional disponible
                'dbExecQuery gsSql
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                    If dtRespConsulta.Rows(0).Item(0) = 0 Then
                        'Se asigna el numero de unidad a una variable
                        lsNumUnidad = Trim(lsBancomer)
                    Else
                        MsgBox("El CR indicado ya se encuentra registrado.", vbCritical, "Error")
                        Exit Sub
                    End If
                Else
                    'dbEndQuery
                    MsgBox("No fue posible agregar la unidad al catalogo.", vbCritical, "Error")
                    Exit Sub
                End If
                'dbEndQuery
                'La rama del arbol seleccionada tiene hijos
                If dtHijos.Rows.Count > 0 Then 'If tvArbol.SelectedItem.Children > 0 Then
                    'lsTipo = tvArbol.SelectedItem.Child.Image
                    'Se busca el tipo de unidad por generar
                    'If InStr(lsTipo, "EST") > 0 Then
                    '    lsTipo = Microsoft.VisualBasic.Left(lsTipo, (Len(lsTipo) - 3))
                    'End If
                    'Se hace una comparacion de tipos de unidad
                    'For lnTipo = 0 To cmbTipoUnidad.Items.Count 'cmbTipoUnidad.ListCount
                    '    If lnTipo = cmbTipoUnidad.Items.Count Then 'cmbTipoUnidad.ListCount Then
                    '        If cmbTipoUnidad.ListIndex = cmbTipoUnidad.ListCount - 1 Then 'If cmbTipoUnidad.ListIndex = cmbTipoUnidad.ListCount - 1 Then
                    '            lnTipo = cmbTipoUnidad.ItemData(cmbTipoUnidad.ListIndex)
                    '        Else
                    '            lnTipo = cmbTipoUnidad.ItemData(cmbTipoUnidad.ListIndex) + 1
                    '        End If
                    '    End If
                    '    If UCase(cmbTipoUnidad.List(lnTipo)) = lsTipo Then
                    '        Exit For
                    '    End If
                    'Next lnTipo
                    lnTipo = lsTipoUnidad
                    'La rama seleccionada no tiene hijos
                Else
                    'La unidad seleccionada es del ultimo nivel
                    'If cmbTipoUnidad.ListIndex = cmbTipoUnidad.ListCount - 1 Then
                    '    lnTipo = cmbTipoUnidad.ItemData(cmbTipoUnidad.ListIndex)
                    '    lsTipo = UCase(Trim(cmbTipoUnidad.List(cmbTipoUnidad.ListIndex)))
                    '    'La unidad seleccionada no es del ultimo nivel
                    'Else
                    '    lnTipo = cmbTipoUnidad.ItemData(cmbTipoUnidad.ListIndex) + 1
                    '    lsTipo = UCase(Trim(cmbTipoUnidad.List(cmbTipoUnidad.ListIndex + 1)))
                    'End If
                    lnTipo = lsTipoUnidad
                End If
                gsSql = "Insert into FUNCIONARIOS..UNIDAD_ORGANIZACIONAL ("
                gsSql = gsSql & "unidad_organizacional, "
                gsSql = gsSql & "unidad_org_bancomer, "
                gsSql = gsSql & "tipo_unidad_organizacional, "
                gsSql = gsSql & "descripcion_unidad_organizacio, "
                gsSql = gsSql & "unidad_organizacional_padre, "
                gsSql = gsSql & "estrategica"
                gsSql = gsSql & ") values ("
                gsSql = gsSql & lsNumUnidad & ", '"
                gsSql = gsSql & lsBancomer & "', "
                gsSql = gsSql & CStr(lnTipo) & ", '"
                gsSql = gsSql & lsNombre & "', "
                gsSql = gsSql & txtNumUnidad.Text & ", " 'Microsoft.VisualBasic.Right(tvArbol.SelectedItem.Key, (Len(tvArbol.SelectedItem.Key) - 1)) & ", "
                gsSql = gsSql & "0)"
                'Se intenta registrar la nueva unidad
                'dbExecQuery gsSql
                'No hubo error...
                If objDatasource.insertar(gsSql) > 0 Then 'If dbError = 0 Then
                    'dbEndQuery
                    lsNombre = lsNombre & "(" & lsBancomer & ")"
                    MsgBox("Se dio de alta la unidad organizacional " & lsNombre & ".", vbInformation, "Aviso")
                    'Set loNodo = tvArbol.Nodes.Add(tvArbol.SelectedItem.Key, tvwChild, "K" & lsNumUnidad, lsNombre, lsTipo)
                    'ReDim Preserve gaArbolUnOrg(UBound(gaArbolUnOrg) + 1)
                    ''Se agrega un registro al arreglo
                    'With gaArbolUnOrg(UBound(gaArbolUnOrg))
                    '    .Relacion = tvArbol.SelectedItem.Key
                    '    .TreeChild = tvwChild
                    '    .Llave = "K" & lsNumUnidad
                    '    .Texto = lsNombre
                    '    .Imagen = lsTipo
                    'End With
                    AltaComplementos(lsNombre, lsBancomer) '--RACB 22-02-2023
                    'INICIO: Registro de Alta en Bitacora de Unidad Organizacional creado por Oliva Farias García OFG 25/nov/2016
                    gsSql = "EXEC FUNCIONARIOS..sp_mantenimiento_unidad_org "
                    gsSql = gsSql & lsBancomer & "," & 1 & "," & userId 'gsSql = gsSql & gnUnidadOrg & "," & 1 & "," & gnUsuario
                    'dbExecQuery gsSql
                    If objDatasource.insertar(gsSql) <= 0 Then 'If dbError <> 0 Then
                        MsgBox("No fue posible registrar la información en bitacora.", vbCritical, "Unidad organizacional")
                    End If
                    'dbEndQuery
                    'FIN: Registro de Bitacora de Unidad Organizacional creado por Oliva Farias García OFG 25/nov/2016

                    'Si hubo error...
                Else
                    MsgBox("No fue posible agregar la unidad al catalogo.", vbCritical, "Error")
                End If
                'dbEndQuery
            End If
        Else
            MsgBox("No se puede agregar una sucursal en el tipo de unidad organizacional actual.", vbCritical, "Error")
        End If
    End Sub
    Private Function GestorAnulado(Nodo As String) As Boolean 'Node) As Boolean
        If InStr(1, UCase(Nodo), "GESTORES ANULADOS", vbBinaryCompare) <> 0 Then
            GestorAnulado = True
        Else
            GestorAnulado = False
        End If
    End Function
    Private Sub ValidarHijos(CRValidar As String)
        SQL_Query = "Select * From FUNCIONARIOS..UNIDAD_ORGANIZACIONAL where unidad_organizacional_padre = " + CRValidar
        dtHijos = objDatasource.RealizaConsulta(SQL_Query)
    End Sub
    Private Sub cmdBorrar_Click(sender As Object, e As EventArgs) Handles cmdBorrar.Click
        Dim lnIndice As Long

        mnFuncMove = 0
        mnUOrgMove = 0
        '***************
        If GestorAnulado(cmbNombre.Text) Then  ' StrComp("FANU", Right(tvArbol.SelectedItem.Key, 4), vbTextCompare) = 0 Then
            MsgBox("Esta parte del árbol es informativa, no se pueden eliminar elementos", vbInformation, "Información")
            Exit Sub
        Else
            '**************
            If MsgBox("¿Esta seguro de borrar la unidad organizacional " &
            cmbNombre.Text & "?", vbYesNo + vbQuestion, "Borrar Unidad Organizacional") = vbYes Then
                gsSql = "Delete FUNCIONARIOS..UNIDAD_ORGANIZACIONAL"
                gsSql = gsSql & " where unidad_organizacional=" & txtNumUnidad.Text & ";"
                gsSql = gsSql & "declare @numero int = " & txtNumUnidad.Text & "; 
                                 delete CATALOGOS..SUCURSAL where sucursal = @numero; 
                                 delete CATALOGOS..SUCURSAL_CHQ where suc_sucursal = @numero; 
                                 delete CATALOGOS..SUCURSAL_CHQ where suc_sucursal = @numero; 
                                 delete GOS..SUCURSAL where sucursal = CONVERT(VARCHAR,@numero);
                                 delete FUNCIONARIOS..LIGAS_CR where unidad_organizacional = @numero"
                'dbExecQuery gsSql
                If objDatasource.insertar(gsSql) > 0 Then 'If dbError = 0 Then
                    'StatusMessage("Eliminando Registro...")
                    'ShowProgress("Eliminando Registro...", UBound(gaArbolUnOrg))
                    'For lnIndice = 0 To UBound(gaArbolUnOrg)
                    'pbrProgress.Value = lnIndice
                    'If gaArbolUnOrg(lnIndice).Llave = tvArbol.SelectedItem.Key Then
                    '    gaArbolUnOrg(lnIndice).Llave = ""
                    '    pbrProgress.Value = UBound(gaArbolUnOrg)
                    '    Exit For
                    'End If
                    'Next lnIndice
                    'pnlStatus.Visible = False
                    If InStr(UCase(Trim(cmbTipoUnidad.Text)), "REGIONAL") <> 0 Then
                        borra_liga_cr
                    End If
                    'StatusMessage("")
                    MsgBox("La unidad " & cmbNombre.Text & " ha sido borrada.", vbInformation, "Aviso")
                    'tvArbol.Nodes.Remove(tvArbol.SelectedItem.Key)
                    mb_Changes = False
                    'INICIO: Registro de Borrar en Bitacora de Unidad Organizacional creado por Oliva Farias García OFG 25/nov/2016
                    gsSql = "EXEC FUNCIONARIOS..sp_mantenimiento_unidad_org "
                    gsSql = gsSql & txtNumUnidad.Text & "," & 2 & "," & userId
                    'dbExecQuery gsSql
                    If objDatasource.insertar(gsSql) <= 0 Then 'If dbError <> 0 Then
                        MsgBox("No fue posible registrar la información en bitacora.", vbCritical, "Unidad organizacional")
                    End If
                    'dbEndQuery
                    'FIN: Registro de Bitacora de Unidad Organizacional creado por Oliva Farias García OFG 25/nov/2016

                Else
                    MsgBox("No fue posible eliminar a la unidad del catalogo.", vbCritical, "Error")
                End If
                'dbEndQuery
            End If
        End If
    End Sub
    Private Sub borra_liga_cr()
        gsSql = "delete FUNCIONARIOS..LIGAS_CR "
        gsSql = gsSql & "where unidad_organizacional=" & Trim(txtNumUnidad.Tag)
        'dbExecQuery gsSql
        If objDatasource.insertar(gsSql) > 0 Then 'If dbError <> 0 Then
            MsgBox("Ocurrio un error al intentar borrar la Liga del Centro Regional.", vbCritical, "Centro Regional")
        End If
        'dbEndQuery
    End Sub
    Private Sub cmdArbol_Click(sender As Object, e As EventArgs) Handles cmdArbol.Click
        If cmbTipoUnidad.SelectedValue = 4 Then
            '------------------------------------------------------- RACB 22/03/2023
            Dim objGlobal As New Cursors
            If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
                Exit Sub
            End If
            '------------------------------------------------------- RACB 22/03/2023
            If MsgBox("¿Desea actualizar la información de la unidad organizacional?", vbYesNo + vbQuestion, "Salir de consulta de unidades") = vbYes Then
                gsSql = "UPDATE FUNCIONARIOS..UNIDAD_ORGANIZACIONAL "
                'gsSql = gsSql & "SET unidad_organizacional = " & txtNumUnidad.Text & ","
                gsSql = gsSql & "SET unidad_org_bancomer = " & txtNumUnidad.Text & ","
                gsSql = gsSql & "tipo_unidad_organizacional = " & cmbTipoUnidad.SelectedValue & ","
                gsSql = gsSql & "descripcion_unidad_organizacio = '" & cmbNombre.Text & "',"
                gsSql = gsSql & "estrategica = " & Convert.ToInt32(chkEstrategica.Checked) & " "
                gsSql = gsSql & "WHERE unidad_organizacional = '" & iCRAnterior & "'"
                If objDatasource.insertar(gsSql) > 0 Then
                    gsSql = " UPDATE CATALOGOS..SUCURSAL "
                    'gsSql = gsSql & "SET sucursal = '" & txtNumUnidad.Text.PadLeft(7, "0") & "', "
                    gsSql = gsSql & "SET nombre_sucursal = '" & cmbNombre.Text & "', "
                    gsSql = gsSql & "estrategica = " & Convert.ToInt32(chkEstrategica.Checked) & ", "
                    gsSql = gsSql & "area_interna = " & Convert.ToInt32(chkAreaInterna.Checked) & " "
                    gsSql = gsSql & "where sucursal = '" & iCRAnterior.PadLeft(7, "0") & "'; "
                    gsSql = gsSql & "UPDATE CATALOGOS..SUCURSAL_CHQ "
                    'gsSql = gsSql & "SET suc_sucursal = '" & txtNumUnidad.Text.PadLeft(7, "0") & "', "
                    gsSql = gsSql & "SET suc_nombre = '" & cmbNombre.Text & "' "
                    gsSql = gsSql & "where suc_sucursal = '" & iCRAnterior.PadLeft(7, "0") & "'; "
                    gsSql = gsSql & "UPDATE GOS..SUCURSAL "
                    'gsSql = gsSql & "SET sucursal = '" & txtNumUnidad.Text & "', "
                    gsSql = gsSql & "SET nombre_sucursal = '" & cmbNombre.Text & "', "
                    gsSql = gsSql & "estrategica = " & Convert.ToInt32(chkEstrategica.Checked) & " "
                    gsSql = gsSql & "where sucursal = '" & iCRAnterior & "'; "
                    'gsSql = gsSql & "UPDATE FUNCIONARIOS..LIGAS_CR "
                    'gsSql = gsSql & "SET unidad_organizacional = " & txtNumUnidad.Text & " "
                    'gsSql = gsSql & "WHERE unidad_organizacional = " & iCRAnterior & "; "
                    If objDatasource.insertar(gsSql) > 0 Then
                        MsgBox("La unidad organizacional y sus complementos se actualizaron correctamente.", vbInformation, "Unidad organizacional")
                    End If
                End If
                gsSql = "EXEC FUNCIONARIOS..sp_mantenimiento_unidad_org "
                gsSql = gsSql & txtNumUnidad.Text & "," & 6 & "," & userId
                If objDatasource.insertar(gsSql) <= 0 Then 'If dbError <> 0 Then
                    MsgBox("No fue posible registrar la información en bitacora.", vbCritical, "Unidad organizacional")
                End If
            End If
        End If
        Buscar()
    End Sub
    Private Sub cmbNombre_DropDown(sender As Object, e As EventArgs) Handles cmbNombre.DropDown
        If cmbNombre.SelectedIndex >= 0 And cmbTipoUnidad.SelectedValue <> 4 Then
            iControlCargando = 1
            SQL_Query = "WITH UNIDAD_ORGANIZACIONAL_RUTA AS 
                    (
                             SELECT A.unidad_organizacional, A.unidad_organizacional_padre, A.descripcion_unidad_organizacio,Cast(A.unidad_organizacional AS VARCHAR) ruta,tipo_unidad_organizacional,estrategica, unidad_org_bancomer
                             FROM   FUNCIONARIOS..UNIDAD_ORGANIZACIONAL A
                             WHERE  A.unidad_organizacional_padre = -1 
                             UNION ALL
                             SELECT B.unidad_organizacional, B.unidad_organizacional_padre, B.descripcion_unidad_organizacio,
                                    Cast(C.ruta + '\' + Cast(B.unidad_organizacional AS VARCHAR) AS VARCHAR),B.tipo_unidad_organizacional,B.estrategica, B.unidad_org_bancomer
                             FROM   FUNCIONARIOS..UNIDAD_ORGANIZACIONAL B
                                    INNER JOIN UNIDAD_ORGANIZACIONAL_RUTA C ON B.unidad_organizacional_padre = C.unidad_organizacional
                             WHERE  B.unidad_organizacional_padre IS NOT NULL
                    )
                    SELECT UOR.unidad_organizacional,UOR.descripcion_unidad_organizacio, UOR.ruta,TU.tipo_unidad_organizacional,CASE UOR.estrategica When 1 Then 'true' When 0 Then 'false' END estrategica,UOR.unidad_organizacional_padre
                    FROM UNIDAD_ORGANIZACIONAL_RUTA UOR,
                    FUNCIONARIOS..TIPO_UNIDAD_ORGANIZACIONAL TU
                    WHERE UOR.tipo_unidad_organizacional = TU.tipo_unidad_organizacional 
                    AND UOR.unidad_organizacional>0
                    AND UOR.UNIDAD_ORGANIZACIONAL_PADRE <> 3737 "
            SQL_Query = SQL_Query & "AND UOR.unidad_organizacional_padre = " & txtNumUnidad.Text & " "
            SQL_Query = SQL_Query & "ORDER BY UOR.unidad_organizacional;"
            dtRespConsulta = objDatasource.RealizaConsulta(SQL_Query)
            cmbNombre.DisplayMember = "descripcion_unidad_organizacio"
            cmbNombre.ValueMember = "unidad_organizacional"
            cmbNombre.DataSource = dtRespConsulta
            SQL_Query = "SELECT * FROM FUNCIONARIOS..TIPO_UNIDAD_ORGANIZACIONAL"
            If cmbTipoUnidad.DataSource Is Nothing Then
                dtRespConsultaTipo = objDatasource.RealizaConsulta(SQL_Query)
                cmbTipoUnidad.ValueMember = "tipo_unidad_organizacional"
                cmbTipoUnidad.DisplayMember = "descripcion_unidad_organizacio"
                cmbTipoUnidad.DataSource = dtRespConsultaTipo
            End If
            If dtRespConsulta.Rows.Count = 0 Then
                MsgBox("No se encontró información.", vbInformation, "Unidad Organizacional")
            End If
            cmbNombre.SelectedIndex = -1
            iControlCargando = 0
        End If
        iCRAnterior = txtNumUnidad.Text
    End Sub
    Private Sub cmdNivelAtras_Click(sender As Object, e As EventArgs) Handles cmdNivelAtras.Click
        If txtNumUnidad.Text > 2 Then
            '------------------------------------------------------- RACB 22/03/2023
            Dim objGlobal As New Cursors
            If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
                Exit Sub
            End If
            '------------------------------------------------------- RACB 22/03/2023
            Dim CRPadre = cmbNombre.DataSource.Rows(0).Item(5)
            txtNumUnidad.Text = CRPadre
            Buscar()
        End If
    End Sub
    Private Sub txtNumUnidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumUnidad.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            '------------------------------------------------------- RACB 22/03/2023
            Dim objGlobal As New Cursors
            If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
                Exit Sub
            End If
            '------------------------------------------------------- RACB 22/03/2023
            Buscar()
        End If
    End Sub
    Private Sub Buscar()
        pbCarga.Visible = True
        pbCarga.Maximum = 5
        pbCarga.Refresh()
        pbCarga.Value = 1
        pbCarga.Refresh()
        If cmbNombre.Text = "" And txtNumUnidad.Text = "" Then
            MsgBox("Se requiere ingresar Nombre o CR para iniciar la busqueda", vbInformation, "Falta Información")
            Exit Sub
        End If
        pbCarga.Value = 2
        If txtNumUnidad.Text <> "" Then
            BuscaListaUnidadOrganizacional(1)
        ElseIf cmbNombre.Text <> "" Then
            BuscaListaUnidadOrganizacional(2)
        End If
        pbCarga.Value = 3
        cmdReporte.Enabled = True
        cmdReporte2.Enabled = True
        cmdReporte3.Enabled = True
        If txtNumUnidad.Text <> "" Then
            txtNumUnidad.Text = txtNumUnidad.Text.ToString().PadLeft(4, "0")
            txtNumUnidad.Refresh()
        End If
        iCRAnterior = txtNumUnidad.Text
        pbCarga.Value = 5
        System.Threading.Thread.Sleep(3000)
        pbCarga.Visible = False
        pbCarga.Value = 0
    End Sub
    Private Sub AltaComplementos(lsNombre As String, lsBancomer As String)
        Dim dtRespuesta As DataTable
        Dim sSQLComplementos As String
        Dim popopComplementoAICED As New frmComplementoAICED
        popopComplementoAICED.StartPosition = FormStartPosition.CenterScreen
        popopComplementoAICED.ShowDialog()
        lsNombre = lsNombre.Substring(0, (lsNombre.IndexOf("(")))
        '================== Alta de complementos Back
        'Buscamos la sucursal para evitar duplicados
        sSQLComplementos = "Select Count ( * ) From " & "CATALOGOS..SUCURSAL "
        sSQLComplementos = sSQLComplementos & "Where sucursal = '" & Trim$(lsNombre) & "'"
        dtRespuesta = objDatasource.RealizaConsulta(sSQLComplementos)
        If dtRespuesta IsNot Nothing And dtRespuesta.Rows(0).Item(0) = 0 Then
            sSQLComplementos = "Insert Into " & "CATALOGOS..SUCURSAL ( bbvab, sucursal, "
            sSQLComplementos = sSQLComplementos & "nombre_sucursal, plaza, centro_regional, "
            sSQLComplementos = sSQLComplementos & "estrategica, area_interna, cuenta_virtual ) Values ( "
            sSQLComplementos = sSQLComplementos & "1, "
            sSQLComplementos = sSQLComplementos & "'" & Trim$(lsBancomer.ToString().PadLeft(7, "0")) & "', "
            sSQLComplementos = sSQLComplementos & "'" & Trim$(lsNombre) & "', "
            sSQLComplementos = sSQLComplementos & "'" & Trim$(GsPlazaBack) & "', "
            sSQLComplementos = sSQLComplementos & "'" & Trim$(GsCentroRegional) & "', "
            sSQLComplementos = sSQLComplementos & "0, "
            sSQLComplementos = sSQLComplementos & "0, "
            sSQLComplementos = sSQLComplementos & "0)"
            If objDatasource.insertar(sSQLComplementos) > 0 Then
                ' ================= Alta de complementos Chequera
                'Buscamos la sucursal para evitar duplicados
                sSQLComplementos = "Select Count(suc_sucursal) from CATALOGOS..SUCURSAL_CHQ Where suc_sucursal = '" & Trim$(lsBancomer.ToString().PadLeft(7, "0")) & "'"
                dtRespuesta = objDatasource.RealizaConsulta(sSQLComplementos)
                If dtRespuesta IsNot Nothing And dtRespuesta.Rows(0).Item(0) = 0 Then
                    sSQLComplementos = "Insert Into " & "CATALOGOS..SUCURSAL_CHQ "
                    sSQLComplementos = sSQLComplementos & "( suc_sucursal, suc_nombre, suc_bbvab ) Values ( "
                    sSQLComplementos = sSQLComplementos & "'" & Trim$(lsBancomer.ToString().PadLeft(7, "0")) & "', "
                    sSQLComplementos = sSQLComplementos & "'" & Trim$(lsNombre) & "', 1 )"
                    If objDatasource.insertar(sSQLComplementos) > 0 Then
                        ' ================= Alta de complementos AICED
                        sSQLComplementos = "Insert Into GOS..SUCURSAL (sucursal, nombre_sucursal, plaza, fuente, estrategica, bbvab) Values "
                        sSQLComplementos = sSQLComplementos & "('" & Format(Trim$(lsBancomer.ToString().PadLeft(4, "0"))) & "', '" & Trim$(lsNombre) & "', '" & Format(GsPlaza.ToString().PadLeft(3, "0")) & "', " & GsFuente & ",0, 1); "
                        sSQLComplementos = sSQLComplementos & "INSERT INTO FUNCIONARIOS..LIGAS_CR VALUES ('" & lsBancomer & "','','" & GsCentroRegional & "');"
                        If objDatasource.insertar(sSQLComplementos) > 0 Then
                            MsgBox("Complementos generados correctamente", vbInformation, "Complementos")
                        Else
                            MsgBox("Se genero un problema al registrar el complemento AICED", vbCritical, "Complementos")
                        End If
                    Else
                        MsgBox("Se genero un problema al registrar el complemento Chequera", vbCritical, "Complementos")
                    End If
                ElseIf dtRespuesta.Rows(0).Item(0) > 0 Then
                    MsgBox("Se detectó una duplicidad en el complemento Chequera", vbCritical, "Complementos")
                End If
            Else
                MsgBox("Se genero un problema al registrar el complemento Back", vbCritical, "Complementos")
            End If
        ElseIf dtRespuesta.Rows(0).Item(0) > 0 Then
            MsgBox("Se detectó una duplicidad en el complemento Back", vbCritical, "Complementos")
        End If
    End Sub
End Class