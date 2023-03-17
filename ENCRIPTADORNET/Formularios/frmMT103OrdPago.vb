Public Class frmMT103OrdPago
    Private Sub frmMT103OrdPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        txtFechaIni.Text = Date.Now().Date.ToString("yyyy-MM-dd")
        txtFechaFin.Text = Date.Now().Date.ToString("yyyy-MM-dd")
        txtFechaIni.Enabled = False
        txtFechaFin.Enabled = False

        RbTodas.Checked = True
        RbEnv.Enabled = False
        RbNoEnv.Enabled = False

        cmdImprimir.Enabled = False

        Me.txtPendxConfirmar.Text = "0"
        Me.txtPendientesxAplicar.Text = "0"
        Me.txtEnvEqPendxConfirmar.Text = "0"
        Me.txtAplicYEnv_EQ.Text = "0"
        Me.txtPendDetenidosSwift.Text = "0"
        Me.txtOperCanceladas.Text = "0"

    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    Private Sub cmdConsultar_Click(sender As Object, e As EventArgs) Handles cmdConsultar.Click
        Dim gs_sql As String
        Dim d As New Datasource
        Dim dtaOrdPago As New DataTable
        Dim iHayRegistros As Integer

        limpiarPantalla()

        Cursor = System.Windows.Forms.Cursors.WaitCursor
        'Inicializa valor de operaciones contables
        'mnOpContables = 0
        'revisa si hay operaciones de la fecha que se ingreso

        d.EjecutaSP("exec sp_Ordenes_de_Pago '" & txtFechaIni.Text & "','" & txtFechaFin.Text & "','" & nameUser & "','TODAS'")

        gs_sql = "SELECT top 1 RESUMEN_PENDIENTE_SIN_CONFIRMAR, RESUMEN_TOTAL_PENDIENTE_SIN_CONFIRMAR, "
        gs_sql &= " RESUMEN_PENDIENTE_APLICAR, RESUMEN_TOTAL_PENDIENTE_APLICAR, "
        gs_sql &= " RESUMEN_ENVIADA, RESUMEN_TOTAL_ENVIADA, "
        gs_sql &= " RESUMEN_APLICADO, RESUMEN_TOTAL_APLICADO, "
        gs_sql &= " RESUMEN_SWIFT, RESUMEN_TOTAL_SWIFT, "
        gs_sql &= " RESUMEN_CANCELADAS, RESUMEN_TOTAL_CANCELADAS "
        gs_sql &= " From TICKET.dbo.REPORTE_ORDENES_PAGO_MT103 "

        dtaOrdPago = d.Consulta(gs_sql, "ConsultaOrdPago")

        Me.txtPendxConfirmar.Text = dtaOrdPago.Rows(0).Item(1)
        Me.txtPendientesxAplicar.Text = dtaOrdPago.Rows(0).Item(3)
        Me.txtEnvEqPendxConfirmar.Text = dtaOrdPago.Rows(0).Item(5)
        Me.txtAplicYEnv_EQ.Text = dtaOrdPago.Rows(0).Item(7)
        Me.txtPendDetenidosSwift.Text = dtaOrdPago.Rows(0).Item(9)
        Me.txtOperCanceladas.Text = dtaOrdPago.Rows(0).Item(11)

        iHayRegistros = dtaOrdPago.Rows(0).Item(1) + dtaOrdPago.Rows(0).Item(3) + dtaOrdPago.Rows(0).Item(5) + dtaOrdPago.Rows(0).Item(7) + dtaOrdPago.Rows(0).Item(9) + dtaOrdPago.Rows(0).Item(11)

        If iHayRegistros > 0 Then
            cmdImprimir.Enabled = True
        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub limpiarPantalla()
        Me.txtPendxConfirmar.Text = "0"
        Me.txtPendientesxAplicar.Text = "0"
        Me.txtEnvEqPendxConfirmar.Text = "0"
        Me.txtAplicYEnv_EQ.Text = "0"
        Me.txtPendDetenidosSwift.Text = "0"
        Me.txtOperCanceladas.Text = "0"

    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        fe_Inicio = txtFechaIni.Text
        fe_Fin = txtFechaFin.Text
        'realiza la extracción de la información - Fecha Inicio
        opcionReporte = 9    'reporte de Operaciones Aplicación Contable Fecha Inicio
        'ls_PorImprimir = "'
        RepOperativa.ShowDialog()

    End Sub
End Class