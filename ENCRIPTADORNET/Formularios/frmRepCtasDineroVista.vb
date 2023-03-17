Public Class frmRepCtasDineroVista
    Private Sub frmRepCtasDineroVista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        'asigna fecha a controles de fecha
        txtCuentaIni.Text = ""
        txtCuentaFin.Text = ""
        txtCuentaIni.Enabled = False
        txtCuentaFin.Enabled = False

        'iReportes = 1
        optTodas.Checked = True
        iRango = 0
        cmdImprimir.Enabled = True

    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    Private Sub cmdBuscar_Click(sender As Object, e As EventArgs) Handles cmdBuscar.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        If validaDatos() Then
            cmdImprimir.Enabled = True 'False ---------------- RACB 24-05-2021
            'inicializa grid
            dgvCuentas000.DataSource = ""

            'busca información
            If optRango.Checked Then
                'revisa cuentas 000
                If Not RevisaCuenta() Then
                    Cursor = System.Windows.Forms.Cursors.Default
                    MsgBox("No existen Cuentas 000.", MsgBoxStyle.Information, "Saldos 000")
                    Exit Sub
                End If
            End If

            'Genera la Tabla SALDO_CTA_000 con el saldo de cada cuenta
            If Not CalculaMontos000() Then
                Cursor = System.Windows.Forms.Cursors.Default
                MsgBox("No se generaron Saldos de Cuentas 000.", MsgBoxStyle.Information, "Saldos 000")
                Exit Sub
            End If

            'Llena grid con los registros con Saldos generados
            If Not Llenagrid000() Then
                Cursor = System.Windows.Forms.Cursors.Default
                MsgBox("No se generaron Saldos de Cuentas 000.", MsgBoxStyle.Information, "Saldos 000")
                Exit Sub
            End If

            cmdImprimir.Enabled = True
            iHayRegistros = 1
            sCuentaIni = txtCuentaIni.Text
            sCuentaFin = txtCuentaFin.Text

        End If
        Cursor = System.Windows.Forms.Cursors.Default
        cmdImprimir.Enabled = True '---------------- RACB 24-05-2021
    End Sub


#Region "Funciones"
    Function validaDatos() As Boolean
        validaDatos = True
    End Function

    Function RevisaCuenta() As Boolean
        Dim li_ExistenCtas As Integer
        Dim gs_sql As String
        Dim d As New Datasource
        Dim dtCuentas As DataTable


        RevisaCuenta = False

        If txtCuentaIni.Text = "" Or txtCuentaIni.Text = "" Then
            MsgBox("Debe de ingresar una cuenta de inicio y fin", MsgBoxStyle.Information, "Reporte Cuentas 000")
            Exit Function
        End If

        gs_sql = "select count(*) "
        gs_sql &= " from PRODUCTO_CONTRATADO pc, CUENTA_EJE ce"
        gs_sql &= " where pc.producto_contratado = ce.producto_contratado"
        gs_sql &= " and pc.agencia = 1"
        'Cuentas 000 (Inversión)
        gs_sql &= " and ce.tipo_cuenta_eje = 4"
        If txtCuentaIni.Text = txtCuentaFin.Text Then   'Una sola Cuenta
            gs_sql &= " and pc.cuenta_cliente = '" & Trim(txtCuentaIni.Text) & "'"
        Else   'Varias Cuentas
            gs_sql &= " and pc.cuenta_cliente > '" & Trim(txtCuentaIni.Text) & "'"
            gs_sql &= " and pc.cuenta_cliente <= '" & Trim(txtCuentaFin.Text) & "'"
        End If

        dtCuentas = d.ObtieneCuentas000(gs_sql)
        If dtCuentas.Rows.Count > 0 Then
            li_ExistenCtas = dtCuentas.Rows(0).Item(0)
        Else
            li_ExistenCtas = 0
            iHayRegistros = 0
        End If

        If li_ExistenCtas = 0 Then Exit Function

        RevisaCuenta = True

    End Function

    Function CalculaMontos000() As Boolean
        Dim gs_sql As String
        Dim d As New Datasource
        Dim dtCuentas As DataTable
        Dim lsHora As String

        CalculaMontos000 = False

        gs_sql = "exec sp_a_obten_montos_cta_000 1"

        dtCuentas = d.EjecutaSP(gs_sql)

        'buscamos si hubo registros en tabal de saldos
        'SALDO_CTA_000

        gs_sql = "Select distinct convert(char(5),fecha_saldo,114) from SALDO_CTA_000"
        dtCuentas = d.ObtieneCuentas000(gs_sql)


        If dtCuentas.Rows.Count > 0 Then
            lsHora = dtCuentas.Rows(0).Item(0).ToString
            lsHora000 = lsHora
        Else
            lsHora = "0"
        End If

        If lsHora = "0" Then Exit Function

        CalculaMontos000 = True

    End Function

    Function Llenagrid000() As Boolean
        Dim gs_sql As String
        Dim d As New Datasource
        Dim dctas = New Datasource
        Dim dtResouesta As New DataTable '---RACB 24/03/2021
        Llenagrid000 = False

        'buscamos si hubo registros en tabal de saldos SALDO_CTA_000
        gs_sql = "Select * from SALDO_CTA_000 where saldo_total <> 0 order by 2"
        dtResouesta = dctas.LoadSaldos000(gs_sql) '---RACB 24/03/2021
        If dtResouesta.Rows.Count > 0 Then '---RACB 24/03/2021
            dgvCuentas000.DataSource = dtResouesta '---RACB 24/03/2021
            dgvCuentas000.Refresh() '---RACB 24/03/2021
            Llenagrid000 = True
        End If '---RACB 24/03/2021
    End Function

    Private Sub optRango_CheckedChanged(sender As Object, e As EventArgs) Handles optRango.CheckedChanged
        txtCuentaIni.Enabled = True
        txtCuentaFin.Enabled = True
        iRango = 1
    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        'realiza la impresión del reporte
        'Saldos a la vista cuentas 000
        opcionReporte = 1
        RepOperativa.ShowDialog()


    End Sub

    Private Sub optTodas_CheckedChanged(sender As Object, e As EventArgs) Handles optTodas.CheckedChanged
        txtCuentaIni.Enabled = False
        txtCuentaFin.Enabled = False
        iRango = 0
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    'EjecutaSP

#End Region
End Class