Public Class VerAutorizados
    Private Sub VerAutorizados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        cargaGridView()
    End Sub

    Sub cargaGridView()
        Dim d As New Datasource
        Dim dtAut As DataTable

        dtAut = d.ObtieneAutorizados(CuentaCompApertura)

        If dtAut.Rows.Count > 0 Then
            gvAutorizados.DataSource = dtAut
        End If
    End Sub

    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
        Me.Hide()
    End Sub
End Class