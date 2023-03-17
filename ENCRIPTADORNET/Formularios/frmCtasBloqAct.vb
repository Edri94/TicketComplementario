Public Class frmCtasBloqAct
    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    Private Sub frmCtasBloqAct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFechaIni.Text = Date.Now.Date.ToString("yyyy-MM-dd")
        txtFechaIni.Enabled = False
        cmdImprimir.Enabled = False
    End Sub

    Private Sub cmdBuscar_Click(sender As Object, e As EventArgs) Handles cmdBuscar.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.dgvCtasBloqAct.DataSource = ""
        iHayRegistros = 0
        iHayRegistros = RealizaConsultaOperaciones()
        If iHayRegistros > 0 Then
            llenaGridCtasBloq()
            cmdImprimir.Enabled = True
        Else
            cmdImprimir.Enabled = False
            MsgBox("No hay registros de Cuentas Bloqueadas o Activas.", MsgBoxStyle.Exclamation, "Consulta Cuentas Activas o Bloqueadas")
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Function RealizaConsultaOperaciones() As Integer
        Dim d As New Datasource
        Dim dt As DataTable
        Dim sSQL As String
        Dim iRegistros As Integer
        sSQL = "select count(*) FROM FUNCIONARIOS.dbo.CTAS_ACTIVAS_BLOQUEADAS"

        dt = d.RealizaConsulta(sSQL)
        iRegistros = dt.Rows(0).Item(0)
        RealizaConsultaOperaciones = iRegistros
    End Function

    Function llenaGridCtasBloq() As Boolean
        Dim d As New Datasource
        Dim sSQL As String
        sSQL = " Select CTAS_ACTIVAS_BLOQUEADAS.NOMBRE_CLIENTE, CTAS_ACTIVAS_BLOQUEADAS.CUENTA_CED, "
        sSQL &= "CTAS_ACTIVAS_BLOQUEADAS.ALTA_CED, CTAS_ACTIVAS_BLOQUEADAS.GESTOR_CED, "
        sSQL &= "CTAS_ACTIVAS_BLOQUEADAS.CR, CTAS_ACTIVAS_BLOQUEADAS.SUCURSAL, "
        sSQL &= "CTAS_ACTIVAS_BLOQUEADAS.CUENTA_MXP, CTAS_ACTIVAS_BLOQUEADAS.ALTA_MXP, "
        sSQL &= "CTAS_ACTIVAS_BLOQUEADAS.GESTOR_MXP, CTAS_ACTIVAS_BLOQUEADAS.CLIENTE_PU, "
		sSQL &= "CTAS_ACTIVAS_BLOQUEADAS.STATUS "
        sSQL &= "FROM FUNCIONARIOS.dbo.CTAS_ACTIVAS_BLOQUEADAS CTAS_ACTIVAS_BLOQUEADAS "
        sSQL &= "ORDER BY CR, SUCURSAL, GESTOR_CED, GESTOR_MXP "

        dgvCtasBloqAct.DataSource = d.RealizaConsulta(sSQL)
        llenaGridCtasBloq = True
    End Function

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        If iHayRegistros > 0 Then
            opcionReporte = 10    'reporte de cuentas bloqueadas y activas
            RepOperativa.ShowDialog()
        End If
    End Sub
End Class