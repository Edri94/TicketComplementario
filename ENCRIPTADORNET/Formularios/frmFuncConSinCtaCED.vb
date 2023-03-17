Public Class frmFuncConSinCtaCED
    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    Private Sub frmFuncConSinCtaCED_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFechaIni.Text = Date.Now.Date.ToString("yyyy-MM-dd")
        txtFechaIni.Enabled = False
        cmdImprimir.Enabled = False
    End Sub

    Private Sub cmdBuscar_Click(sender As Object, e As EventArgs) Handles cmdBuscar.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.dgvFuncCtasConSin.DataSource = ""
        iHayRegistros = 0

        iHayRegistros = RealizaConsultaOper()
        If iHayRegistros > 0 Then
            LlenaGridCtasConSin()
            cmdImprimir.Enabled = True
        Else
            cmdImprimir.Enabled = False
            MsgBox("No hay registros de Funcionarios Con y Sin Cuentas CED.", MsgBoxStyle.Exclamation, "Consulta Funcionarios Con y Sin Cuentas CED")
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Function RealizaConsultaOper() As Integer
        Dim d As New Datasource
        Dim dt As DataTable
        Dim sSQL As String
        Dim iRegistros As Integer

        sSQL = "select count(*) FROM FUNCIONARIOS.dbo.FUNC_CTAS_CED"

        dt = d.RealizaConsulta(sSQL)
        iRegistros = dt.Rows(0).Item(0)
        RealizaConsultaOper = iRegistros
    End Function

    Function LlenaGridCtasConSin() As Boolean
        Dim d As New Datasource
        Dim sSQL As String
        LlenaGridCtasConSin = False

        sSQL = " SELECT  FUNC_CTAS_CED.ID_FUNC, FUNC_CTAS_CED.CR, FUNC_CTAS_CED.NOMBRE_CR, FUNC_CTAS_CED.STATUS_CR, "
        sSQL &= " FUNC_CTAS_CED.NUMERO_FUNCIONARIO, FUNC_CTAS_CED.NUMERO_REGISTRO, FUNC_CTAS_CED.STATUS_GESTOR, "
        sSQL &= " FUNC_CTAS_CED.TIF, FUNC_CTAS_CED.STATUS_TIF, FUNC_CTAS_CED.USUARIO_PU, FUNC_CTAS_CED.NOMBRE_GESTOR, "
        sSQL &= " FUNC_CTAS_CED.AP_PGESTOR, FUNC_CTAS_CED.AP_MGESTOR, FUNC_CTAS_CED.CR_OPERA, FUNC_CTAS_CED.NOMBRE_CRPERA, "
        sSQL &= " FUNC_CTAS_CED.CR_TERM, FUNC_CTAS_CED.NOMBRE_CRTERM, FUNC_CTAS_CED.CED_LARGA, FUNC_CTAS_CED.CED, "
        sSQL &= " FUNC_CTAS_CED.CLIENTE, FUNC_CTAS_CED.STATUS "
        sSQL &= " FROM   FUNCIONARIOS.dbo.FUNC_CTAS_CED FUNC_CTAS_CED "
        sSQL &= " ORDER BY CR, NOMBRE_CR, AP_PGESTOR, AP_MGESTOR, NOMBRE_GESTOR "

        Me.dgvFuncCtasConSin.DataSource = d.RealizaConsulta(sSQL)
        LlenaGridCtasConSin = True
    End Function

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        If iHayRegistros > 0 Then
            opcionReporte = 11    'reporte de funcionarios con y sin cuentas ced
            RepOperativa.ShowDialog()
        End If
    End Sub
End Class