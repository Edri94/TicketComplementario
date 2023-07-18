Public Class VerBeneficiarios

    Private Sub VerBeneficiarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        cargaGridView()
    End Sub

    Sub cargaGridView()
        Dim d As New Datasource
        Dim dtBen As DataTable

        dtBen = d.ObtieneBeneficiarios(CuentaCompApertura)

        If dtBen.Rows.Count > 0 Then
            gvBeneficiarios.DataSource = dtBen
        End If
    End Sub

    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
        Me.Hide()
    End Sub

    Private Sub gvBeneficiarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvBeneficiarios.CellContentClick

    End Sub
End Class