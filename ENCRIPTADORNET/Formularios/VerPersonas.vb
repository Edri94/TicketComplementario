Public Class VerPersonas
    Public dtTablaUnida As New DataTable
    Private Sub btSalir_Click(sender As Object, e As EventArgs) Handles btSalir.Click
        Me.Close()
    End Sub

    Private Sub VerPersonas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        If dtTablaUnida.Rows.Count > 0 Then
            gvPersonas.DataSource = dtTablaUnida
            gvPersonas.Columns(0).HeaderText = "Nombre"
            gvPersonas.Columns(1).HeaderText = "Apellido Paterno"
            gvPersonas.Columns(2).HeaderText = "Apellido Materno"
        End If
    End Sub
End Class