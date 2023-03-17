Public Class frmComplementoAICED
    Dim objDatasource As New Datasource
    Dim dtRespConsulta As DataTable
    Dim gsSql As String
    Private Sub cmbCentroRegional_DropDown(sender As Object, e As EventArgs) Handles cmbCentroRegional.DropDown
        gsSql = "SELECT centro_regional,nombre_centro_regional FROM CATALOGOS..CENTRO_REGIONAL order by nombre_centro_regional"
        dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
        cmbCentroRegional.ValueMember = "centro_regional"
        cmbCentroRegional.DisplayMember = "nombre_centro_regional"
        cmbCentroRegional.DataSource = dtRespConsulta
        cmbCentroRegional.SelectedIndex = -1
    End Sub
    Private Sub cmbTipoFuente_DropDown(sender As Object, e As EventArgs) Handles cmbTipoFuente.DropDown
        gsSql = "Select tipo_fuente, descripcion_tipo_fuente "
        gsSql = gsSql & " from GOS..TIPO_FUENTE where bbvab = 1"
        dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
        cmbTipoFuente.ValueMember = "tipo_fuente"
        cmbTipoFuente.DisplayMember = "descripcion_tipo_fuente"
        cmbTipoFuente.DataSource = dtRespConsulta
        cmbTipoFuente.SelectedIndex = -1
    End Sub
    Private Sub cmbFuente_DropDown(sender As Object, e As EventArgs) Handles cmbFuente.DropDown
        gsSql = "Select fuente,descripcion_fuente "
        gsSql = gsSql & "From GOS..FUENTES "
        gsSql = gsSql & "Where "
        gsSql = gsSql & "upper(descripcion_fuente) like '%" & Trim(cmbFuente.Text) & "%' and tipo_fuente= " & cmbTipoFuente.SelectedValue
        gsSql = gsSql & " order by descripcion_fuente"
        dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
        cmbFuente.ValueMember = "fuente"
        cmbFuente.DisplayMember = "descripcion_fuente"
        cmbFuente.DataSource = dtRespConsulta
        cmbFuente.SelectedIndex = -1
    End Sub
    Private Sub cmbPlaza_DropDown(sender As Object, e As EventArgs) Handles cmbPlaza.DropDown
        gsSql = "SELECT plaza,  nombre_plaza"
        gsSql = gsSql & " FROM GOS..PLAZAS "
        gsSql = gsSql & "where upper(nombre_plaza) LIKE '%" + Trim(UCase(cmbPlaza.Text)) + "%' "
        gsSql = gsSql & "order by nombre_plaza"
        dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
        cmbPlaza.ValueMember = "plaza"
        cmbPlaza.DisplayMember = "nombre_plaza"
        cmbPlaza.DataSource = dtRespConsulta
        cmbPlaza.SelectedIndex = -1
    End Sub
    Private Sub cmdContinuar_Click(sender As Object, e As EventArgs) Handles cmdContinuar.Click
        If cmbTipoFuente.SelectedIndex < 0 Or cmbFuente.SelectedIndex < 0 Or cmbPlaza.SelectedIndex < 0 Then
            MsgBox("Se requiere seleccionar una opción en cada lista", vbCritical, "Falta Información")
        Else
            GsTipoFuente = cmbTipoFuente.SelectedValue
            GsFuente = cmbFuente.SelectedValue
            GsPlaza = cmbPlaza.SelectedValue
            GsCentroRegional = cmbCentroRegional.SelectedValue
            GsPlazaBack = txtPlaza.Text
            Me.Close()
        End If
    End Sub
End Class