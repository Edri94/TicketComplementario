Public Class frmTDDPosteoRechazos
    Dim iRegsTDDRechazos As Integer = 0

    Private Sub frmTDDPosteoRechazos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        txtFechaIni.Text = ""
        txtFechaFin.Text = ""
        txtFechaIni.Text = Now().ToString("yyyy-MM-dd")
        txtFechaFin.Text = Now().ToString("yyyy-MM-dd")
        cmdImprimir.Enabled = False
    End Sub

    Private Sub cmdBuscar_Click(sender As Object, e As EventArgs) Handles cmdBuscar.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        If ValidaDatos() Then
            'inicializa grid
            dgvTDDRechazos.DataSource = ""
            If Not LlenaGridTDDRechazos() Then
                cmdImprimir.Enabled = False
            Else
                'activa boton de imprimir
                cmdImprimir.Enabled = True
            End If
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click

        'arma el query que se pasara al reporte
        ls_PorImprimir = ""
        ls_PorImprimir &= " {vw_retenciones_posteos.opcion} = 2 "
        ls_PorImprimir &= " And {vw_retenciones_posteos.fecha_captura} >= Date (" & txtFechaIni.Text.Substring(0, 4).Trim & "," & txtFechaIni.Text.Substring(5, 2).Trim & "," & txtFechaIni.Text.Substring(8, 2).Trim & ") "
        ls_PorImprimir &= " And {vw_retenciones_posteos.fecha_captura} <= Date (" & txtFechaFin.Text.Substring(0, 4).Trim & "," & txtFechaFin.Text.Substring(5, 2).Trim & "," & txtFechaFin.Text.Substring(8, 2).Trim & ") "
        'Date (" & fe_Inicio.Substring(0, 4).Trim & "," & fe_Inicio.Substring(5, 2).Trim & "," & fe_Inicio.Substring(8, 2).Trim & ")"
        'imprime retiros
        If iRegsTDDRechazos > 0 Then
            opcionReporte = 4    'reporte de TDD Posteos Rechazados
            RepOperativa.ShowDialog()
        End If

    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub



#Region "Funciones"
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
        If Len(Trim(txtFechaIni.Text)) <> 10 Then
            MsgBox("Es necesario indicar una fecha de captura inicial Correcta.", MsgBoxStyle.Information, "Fecha Incorrecta")
            txtFechaIni.Select()
            Exit Function
        End If
        If Len(Trim(txtFechaFin.Text)) <> 10 Then
            MsgBox("Es necesario indicar una fecha de captura final Correcta.", MsgBoxStyle.Information, "Fecha Incorrecta")
            txtFechaFin.Select()
            Exit Function
        End If
        ValidaDatos = True

    End Function

    Function LlenaGridTDDRechazos() As Boolean
        Dim gs_sql As String
        Dim d As New Datasource
        Dim dctas = New Datasource
        Dim dtTablaRespuesta As New DataTable


        LlenaGridTDDRechazos = False

        If buscaTTDRechazados() Then
            'arma el query para presentar en el grid
            gs_sql = "Select vw_rp.prefijo_agencia, vw_rp.cuenta_cliente, vw_rp.fecha_captura, "
            gs_sql &= " vw_rp.fecha_operacion, vw_rp.numero_retencion, vw_rp.operacion_piu, "
            gs_sql &= " vw_rp.importe_operacion, vw_rp.observaciones, vw_rp.status_proceso, "
            gs_sql &= " vw_rp.operacion, vw_rp.opcion, vw_rp.consecutivo, vw_rp.fecha_grupo "
            gs_sql &= " From TICKET.dbo.vw_retenciones_posteos vw_rp "
            gs_sql &= " Where vw_rp.opcion = 2 "
            gs_sql &= " And vw_rp.fecha_captura between '" & txtFechaIni.Text & " 00:00' "
            gs_sql &= " And '" & txtFechaFin.Text & " 23:59' "

            'dgvTDDRechazos.DataSource = dctas.RealizaConsulta(gs_sql) '------ RACB 12/03/2021
            dtTablaRespuesta = dctas.RealizaConsulta(gs_sql) '------ RACB 12/03/2021
            dgvTDDRechazos.DataSource = Nothing '------ RACB 12/03/2021
            dgvTDDRechazos.Refresh() '------ RACB 12/03/2021
            dgvTDDRechazos.DataSource = dtTablaRespuesta '------ RACB 12/03/2021
            dgvTDDRechazos.Columns("importe_operacion").DefaultCellStyle.Format = "N2" '-----RACB 04/03/2021
            dgvTDDRechazos.Refresh() '------ RACB 12/03/2021
        Else
                LlenaGridTDDRechazos = False
        End If

        LlenaGridTDDRechazos = True
    End Function

    Function buscaTTDRechazados() As Boolean
        Dim gs_sql As String
        Dim d As New Datasource
        Dim dctas = New Datasource
        iRegsTDDRechazos = 0

        buscaTTDRechazados = False

        'busca depositos
        'gs_sql = "Select vw_rp.prefijo_agencia, vw_rp.cuenta_cliente, vw_rp.fecha_captura, "
        'gs_sql &= " vw_rp.fecha_operacion, vw_rp.numero_retencion, vw_rp.operacion_piu, "
        'gs_sql &= " vw_rp.importe_operacion, vw_rp.observaciones, vw_rp.status_proceso, "
        'gs_sql &= " vw_rp.operacion, vw_rp.opcion, vw_rp.consecutivo, vw_rp.fecha_grupo "
        gs_sql = "Select count(*) "
        gs_sql &= " From TICKET.dbo.vw_retenciones_posteos vw_rp "
        gs_sql &= " Where vw_rp.opcion = 2 "
        gs_sql &= " And vw_rp.fecha_captura between '" & txtFechaIni.Text & "' "
        gs_sql &= " And '" & txtFechaFin.Text & "' "

        iRegsTDDRechazos = d.HayRegistros(gs_sql)

        If iRegsTDDRechazos > 0 Then
            buscaTTDRechazados = True
        Else
            MsgBox("No existen operaciones de TDD Posteos con Rechazo", MsgBoxStyle.Information, "Sin Operaciones TDD Posteos Rechazos")
        End If

    End Function


#End Region



End Class