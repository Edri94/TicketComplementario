Public Class VerApoderados
    Private Sub VerApoderados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        cargaGridView()
    End Sub
    Sub cargaGridView()
        Dim d As New Datasource
        Dim dtApo As DataTable

        dtApo = d.ObtieneApoderados(CuentaCompApertura)

        If dtApo.Rows.Count > 0 Then
            gvApoderados.DataSource = dtApo
        End If
    End Sub

    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
        Me.Hide()
    End Sub
End Class