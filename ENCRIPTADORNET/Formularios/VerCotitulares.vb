Public Class VerCotitulares
    Private Sub VerCotitulares_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        cargaGridView()
    End Sub
    Sub cargaGridView()
        Dim d As New Datasource
        Dim dtCot As DataTable

        dtCot = d.ObtieneCotitulares(CuentaCompApertura)

        If dtCot.Rows.Count > 0 Then
            gvCotitulares.DataSource = dtCot
        End If
    End Sub

    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
        Me.Hide()
    End Sub
End Class