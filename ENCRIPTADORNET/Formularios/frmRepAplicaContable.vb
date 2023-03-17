Public Class frmRepAplicaContable
    Dim strFechaHoy As String
    Dim strFechaInicio As String
    Dim strFechaFin As String
    Dim strFechaHabil As String
    Dim mnOpContables As Integer
    Dim SFechaIniPar As String
    Dim SFechaFinPar As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()

    End Sub

    Private Sub frmRepAplicaContable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim d As New Datasource
        Dim ls_Query As String

        Dim lnDiaInhabil As Integer

        Me.CenterToScreen()

        'recupera fechas para reporte, a un día habil anterior a la fecha actual.
        strFechaHoy = Date.Now().Date.ToString("yyyy-MM-dd")
        strFechaFin = strFechaHoy

        'obtien fecha habil anterior a hoy
        ls_Query = "Select convert(char(10), dateadd(dd, -1, '" & strFechaHoy & "'), 110)"
        strFechaHabil = d.FechaHabilDiaAnterior(ls_Query)

        lnDiaInhabil = 1

        Do While lnDiaInhabil > 0
            ls_Query = "Select count(1)"
            ls_Query &= " from CATALOGOS.dbo.DIAS_FERIADOS"
            ls_Query &= " where fecha = '" & strFechaHabil & "'"
            ls_Query &= " and tipo_dia_feriado = 3"

            lnDiaInhabil = d.regresa_count(ls_Query, "EsHabil")

            If lnDiaInhabil > 0 Then
                ls_Query = "Select convert(char(10), dateadd(dd, -1, '" & strFechaHabil & "'), 110)"
                strFechaHabil = d.FechaHabilDiaAnterior(ls_Query)
            End If

        Loop

        strFechaInicio = strFechaHabil   '.ToString("yyyy-MM-dd")
        txtFechaIni.Text = strFechaHabil
        txtFechaIni.Text = txtFechaIni.Text.Substring(6, 4) + "-" + txtFechaIni.Text.Substring(0, 2) + "-" + txtFechaIni.Text.Substring(3, 2)
        txtFechaFin.Text = Date.Now().Date.ToString("yyyy-MM-dd")

        'dtpFechaInicio.Value = CDate(strFechaHabil)
        'dtpFechaFin.Value = CDate(strFechaHabil)
        'dtpFechaInicio.Value = Date.Now().Date.ToString("yyyy-MM-dd")
        'dtpFechaFin.Value = Date.Now().Date.ToString("yyyy-MM-dd")

        'apaga boton de imprimir
        cmdImprimir.Enabled = False

    End Sub

    Private Sub cmdConsultar_Click(sender As Object, e As EventArgs) Handles cmdConsultar.Click
        Dim gs_sql As String
        Dim d As New Datasource
        Dim iHayRegistros As Integer


        SFechaIniPar = txtFechaIni.Text.Substring(5, 2) + "-" + txtFechaIni.Text.Substring(8, 2) + "-" + txtFechaIni.Text.Substring(0, 4)
        SFechaFinPar = txtFechaFin.Text.Substring(5, 2) + "-" + txtFechaFin.Text.Substring(8, 2) + "-" + txtFechaFin.Text.Substring(0, 4)

        '*******************************************************************
        '*******************************************************************
        '****     TODAS LAS FECHAS DEBEN PASAR CON FORMATO MM-DD-YYYY
        '*******************************************************************
        '*******************************************************************

        Cursor = System.Windows.Forms.Cursors.WaitCursor
        'Inicializa valor de operaciones contables
        mnOpContables = 0
        'revisa si hay operaciones de la fecha que se ingreso

        gs_sql = "SELECT ISNULL(COUNT(1), 0) FROM TICKET.dbo.TAREAS_ENTRADAS_PIU T , CATALOGOS..AGENCIA AG,"
        gs_sql &= " OPERACION OP"
        gs_sql &= " WHERE convert(char(10), OP.fecha_captura, 110) >= '" & SFechaIniPar & "'"
        gs_sql &= " AND convert(char(10), OP.fecha_captura, 110) < '" & SFechaIniPar & "'"
        gs_sql &= " AND convert(char(10), T.fecha_contabilidad, 110) = '" & SFechaIniPar & "'"
        gs_sql &= " AND OP.operacion = T.operacion"
        gs_sql &= " AND contable = 1"
        gs_sql &= " AND AG.agencia = 1 "
        gs_sql &= " AND SUBSTRING(T.cuenta, 1, 4) = AG.prefijo_agencia"

        iHayRegistros = d.HayRegistros(gs_sql)

        If iHayRegistros > 0 Then
            mnOpContables = iHayRegistros
        End If

        gs_sql = "SELECT ISNULL(COUNT(1), 0) FROM TAREAS_ENTRADAS_PIU T, CATALOGOS..AGENCIA AG,"
        gs_sql &= " OPERACION OP"
        gs_sql &= " WHERE convert(char(10), OP.fecha_captura, 110) >= '" & SFechaIniPar & "'"
        gs_sql &= " AND convert(char(10), OP.fecha_captura, 110) < '" & SFechaFinPar & "'"
        gs_sql &= " AND convert(char(10), T.fecha_contabilidad, 110) = '" & SFechaIniPar & "'"
        gs_sql &= " AND OP.operacion = T.operacion"
        gs_sql &= " AND contable = 1"
        gs_sql &= " AND AG.agencia = 1 "
        gs_sql &= " AND SUBSTRING(T.cuenta, 1, 4) = AG.prefijo_agencia"

        iHayRegistros = d.HayRegistros(gs_sql)

        If iHayRegistros > 0 Then
            mnOpContables += iHayRegistros
        End If

        gs_sql = "SELECT ISNULL(COUNT(1), 0) FROM TAREAS_ENTRADAS_CED T , CATALOGOS..AGENCIA AG,"
        gs_sql &= " OPERACION OP"
        gs_sql &= " WHERE convert(char(10), OP.fecha_captura, 110) >= '" & SFechaIniPar & "'"
        gs_sql &= " AND convert(char(10), OP.fecha_captura, 110) < '" & SFechaFinPar & "'"
        gs_sql &= " AND convert(char(10), T.fecha_contabilidad, 110) = '" & SFechaIniPar & "'"
        gs_sql &= " AND OP.operacion = T.operacion"
        gs_sql &= " AND contable = 1"
        gs_sql &= " AND AG.agencia = 1 "
        gs_sql &= " AND SUBSTRING(T.cuenta, 1, 4) = AG.prefijo_agencia"

        iHayRegistros = d.HayRegistros(gs_sql)

        If iHayRegistros > 0 Then
            mnOpContables += iHayRegistros
        End If

        gs_sql = "SELECT ISNULL(COUNT(1), 0) FROM TAREAS_ENTRADAS_CED T, CATALOGOS..AGENCIA AG,"
        gs_sql &= " OPERACION OP"
        gs_sql &= " WHERE convert(char(10), OP.fecha_captura, 110) >= '" & SFechaFinPar & "'"
        gs_sql &= " AND convert(char(10), OP.fecha_captura, 110) < '" & SFechaFinPar & "'"
        gs_sql &= " AND convert(char(10), T.fecha_contabilidad, 110) = '" & SFechaFinPar & "'"
        gs_sql &= " AND OP.operacion = T.operacion"
        gs_sql &= " AND contable = 1"
        gs_sql &= " AND AG.agencia = 1 "
        gs_sql &= " AND SUBSTRING(T.cuenta, 1, 4) = AG.prefijo_agencia"

        If iHayRegistros > 0 Then
            mnOpContables += iHayRegistros
        End If

        If mnOpContables = 0 Then
            Cursor = System.Windows.Forms.Cursors.Default
            MsgBox("No existen operaciones para el filtro seleccionado", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If

        gs_sql = "Select Case vwte.operacion_definida_global, vwte.operacion, vwte.cuenta_cliente, vwte.descripcion_operacion_definida, "
        gs_sql &= " vwte.fecha_captura, vwte.fecha_contabilidad, vwte.monto_operacion, vwte.fecha_operacion, "
        gs_sql &= " vwte.Origen, vwte.descripcion_status, vwte.mt202, vwte.nombre_centro_origen, vwte.captura "
        gs_sql &= " From TICKET.dbo.vw_tareas_entradas vwte "
        gs_sql &= " Where vwte.fecha_contabilidad = '2020-01-06'  "
        gs_sql &= " And vwte.agencia = 1 "
        gs_sql &= " Order By vwte.Origen "

        'obtiene cuentas dentro de las fecha seleccionada, y llena el Grid de la forma
        'dgvOperaciones.DataSource = d.LoadOperacionesApliCont(strFechaInicio, strFechaFin)

        dgvOperaciones.DataSource = d.LoadOperacionesApliCont(SFechaIniPar, SFechaFinPar)
        dgvOperaciones.Columns("monto_operacion").DefaultCellStyle.Format = "N2" '-----RACB 22/03/2021

        cmdImprimir.Enabled = True
        Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        Dim SFechaIniPar As String
        Dim SFechaFinPar As String

        'fe_Inicio = SFechaIniPar
        'fe_Inicio = strFechaInicio
        fe_Inicio = txtFechaIni.Text
        'realiza la extracción de la información - Fecha Inicio
        opcionReporte = 7    'reporte de Operaciones Aplicación Contable Fecha Inicio
        'ls_PorImprimir = "'
        RepOperativa.ShowDialog()


        'fe_Fin = SFechaFinPar
        'fe_Fin = strFechaFin
        fe_Fin = txtFechaFin.Text
        'realiza la extracción de la información - Fecha Fin
        opcionReporte = 8    'reporte de Operaciones Aplicación Contable Fecha Inicio
        'ls_PorImprimir = "'
        RepOperativa.ShowDialog()

    End Sub
End Class