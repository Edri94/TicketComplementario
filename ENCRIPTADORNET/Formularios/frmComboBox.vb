Public Class frmComboBox
    Private objDatasource As New Datasource
    Private bCambio As Boolean = False
    Private Sub frmComboBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbEstatus.DisplayMember = "DESCRIPCION"
        cmbEstatus.ValueMember = "STATUS_OPERACION"
        cmbEstatus.DataSource = objDatasource.RealizaConsulta("Select SO.STATUS_OPERACION, Case SO.STATUS_OPERACION 
	                                                                WHEN '0' THEN '0 - VALIDACIÓN A FUTURO'
	                                                                WHEN '1' THEN '1 - PENDIENTE DE VALIDAR'
	                                                                WHEN '2' THEN '2 - VALIDADO'
	                                                                WHEN '3' THEN '3 - PENDIENTE DE RECIBIR'
	                                                                WHEN '4' THEN '4 - VALIDADO EQ'
	                                                                WHEN '250' THEN '250 - CANCELADO'
	                                                                ELSE CONVERT(VARCHAR(3),SO.STATUS_OPERACION) + ' - ' + UPPER(SO.DESCRIPCION_STATUS)
	                                                                END DESCRIPCION
                                                                from TICKET..STATUS_OPERACION SO")
        cmbEstatus.SelectedText = GsEstatusMantenimientoOperacion
        bCambio = True
    End Sub

    Private Sub cmbEstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstatus.SelectedIndexChanged
        If bCambio Then
            GsEstatusMantenimientoOperacion = cmbEstatus.Text
            Me.Close()
        End If
    End Sub
End Class