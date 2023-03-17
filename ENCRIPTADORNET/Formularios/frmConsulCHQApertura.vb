'*************    Módulo de Chequeras    **************'
'****       Fecha de Creación: 06/07/2020           ***'
'**** Creado por: SGGG-Susan Gabriela Gómez González***' 
Public Class frmConsulCHQApertura

    Dim FTicket As String
    Dim FProductoContratado As Integer
    Public FCuentaCliente As String
    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
        iCtaCliente = ""
        Me.Close()
    End Sub

    Private Sub frmConsulCHQApertura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.CenterToScreen()
            txCuenta.Text = " "
            LimpiaCampos()
            txFecha.Text = Date.Now.Date.ToString("dd-MM-yyyy")
            dtpFechaIni.Text = DateTime.Now
            dtpFechaFin.Text = DateTime.Now
            gvOperaciones.Enabled = False

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en la funcion frmConsulCHQApertura_Load, Error:" & ex.Message, vbInformation, "Carga formulario ValidaApertura")
            Exit Sub
        End Try

    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        txCuenta.Text = ""
        txNombre.Text = ""
        txPrefijo.Text = ""
        LimpiaCampos()
        txFecha.Text = Date.Now.Date.ToString("dd-MM-yyyy")
    End Sub
    Sub LimpiaCampos()
        Dim lo_Control As Control
        'Si es limpieza general de campos
        For Each lo_Control In Controls
            LimpiaCamposGrp(Me.grbCtaPesos)
            LimpiaCamposGrp(Me.grbCtaDlls)
            LimpiaCamposGrp(Me.grbDatosCuenta)
        Next
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Sub LimpiaCamposGrp(ByVal sNomcontrol As GroupBox)
        Dim lo_Control As Control
        'Recorremos todos los controles del formulario que enviamos  
        For Each lo_Control In sNomcontrol.Controls
            'Filtramos solo aquellos de tipo TextBox 
            If TypeOf lo_Control Is TextBox Then
                lo_Control.Text = "" ' eliminar el texto  
            End If
        Next
    End Sub

    Private Sub btSolicitar_Click(sender As Object, e As EventArgs) Handles btSolicitar.Click

        If rdCHQNormal.Checked = True Then
            Dim frmSolicitudChequera As New frmSolicitudChequeraNormal
            frmSolicitudChequeraNormal.ShowDialog()
            frmSolicitudChequeraNormal.txNumCta.Focus()
        Else
            Dim frmSolicitudChequera As New frmSolicitudChequeraNormal
            frmSolicitudChequeraEspecial.ShowDialog()
            frmSolicitudChequeraEspecial.txNumCta.Focus()
        End If

    End Sub
    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        Dim d As New Datasource

        If CDate(dtpFechaIni.Text) > CDate(dtpFechaFin.Text) Then
            MsgBox("La fecha inicial del periodo debe ser menor o igual a la fecha final.", vbInformation, "Fecha Invalida")
            dtpFechaIni.Text = DateTime.Now
            dtpFechaFin.Text = DateTime.Now
            Exit Sub
        End If
        gvOperaciones.DataSource = d.ObtieneSolicitudPend(dtpFechaIni.Text, dtpFechaFin.Text)

        If gvOperaciones.Rows.Count() <> 0 Then
            gvOperaciones.Enabled = True
        Else
            gvOperaciones.Enabled = False
            MsgBox("No se encuentran datos en el periodo seleccionado.", vbInformation)
        End If

    End Sub

    Private Sub gvOperaciones_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles gvOperaciones.CellMouseClick
        Try
            Dim d = New Datasource
            Dim dtDatosCliente As DataTable
            Dim dtDatosGestor As DataTable
            Dim sFuncionario As String
            Dim sFuncDlls As String

            LimpiaCampos()
            If Not String.IsNullOrEmpty(gvOperaciones.CurrentRow.Cells("Cuenta").Value.ToString()) Then
                'Llena Campos
                dtDatosCliente = d.DatosConsCHQApert(gvOperaciones.CurrentRow.Cells("ticket").Value.ToString())

                iCtaCliente = gvOperaciones.CurrentRow.Cells("cuenta").Value
                FTicket = Convert.ToUInt32(gvOperaciones.CurrentRow.Cells("ticket").Value)
                txCuenta.Text = iCtaCliente
                txCuenta.Enabled = False
                'txTicket.Enabled = False
                ' LimpiaCampos

                If dtDatosCliente.Rows.Count >= 0 Then                                                      'Si existen datos
                    txPrefijo.Text = dtDatosCliente.Rows(0).Item(0)
                    txPrefAgencia.Text = dtDatosCliente.Rows(0).Item(0)
                    txCuenta.Text = dtDatosCliente.Rows(0).Item(1)
                    txtCtaDlls.Text = dtDatosCliente.Rows(0).Item(1)
                    txNombre.Text = dtDatosCliente.Rows(0).Item(2).ToString.ToUpper
                    txSufijo.Text = dtDatosCliente.Rows(0).Item(3)
                    sFuncionario = dtDatosCliente.Rows(0).Item(4)
                    sFuncDlls = Trim(dtDatosCliente.Rows(0).Item(5))

                    'Tiene cuenta eje pesos
                    If Len(Trim(dtDatosCliente.Rows(0).Item(6))) = 12 Then
                        txNumCtaEje.Text = Trim(dtDatosCliente.Rows(0).Item(6))
                        'Busca datos del funcionario pesos
                        dtDatosGestor = d.DatosGestoresCHQ(sFuncionario)
                        'Se encontraron datos del funcionario pesos
                        If dtDatosGestor.Rows.Count <> 0 Then
                            txCR.Text = dtDatosGestor.Rows(0).Item(0).ToString.ToUpper
                            If InStr(txCR.Text, "(") > 0 Then txNumCR.Text = CStr(Val(Mid(txCR.Text, InStr(txCR.Text, "(") + 1))).PadLeft(2, "0")
                            txPlaza.Text = dtDatosGestor.Rows(0).Item(1).ToString.ToUpper
                            If InStr(txPlaza.Text, "(") > 0 Then txNumPlaza.Text = CStr(Val(Mid(txPlaza.Text, InStr(txPlaza.Text, "(") + 1))).PadLeft(3, "0")
                            txSucursal.Text = dtDatosGestor.Rows(0).Item(2).ToString.ToUpper
                            If InStr(txSucursal.Text, "(") > 0 Then
                                txNumSucursal.Text = CStr(Val(Mid(txSucursal.Text, InStr(txSucursal.Text, "(") + 1)))
                                If Len(txNumSucursal.Text) > 4 Then
                                    txNumSucursal.Text = txNumSucursal.Text.Substring(Len(txNumSucursal.Text) - 4).PadLeft(4, "0")
                                Else
                                    txNumSucursal.Text = txNumSucursal.Text.PadLeft(4, "0")
                                End If
                            End If
                            txNumGestorP.Text = Trim(dtDatosGestor.Rows(0).Item(3))
                            txNomGestor.Text = dtDatosGestor.Rows(0).Item(4).ToString.ToUpper
                        End If

                        'Busca datos del funcionario dolares
                        dtDatosGestor = d.DatosGestoresCHQ(sFuncDlls)
                        'Se encontraron datos del funcionario dolares
                        If dtDatosGestor.Rows.Count <> 0 Then
                            txCRDlls.Text = dtDatosGestor.Rows(0).Item(0).ToString.ToUpper
                            If InStr(txCRDlls.Text, "(") > 0 Then txNumCRDlls.Text = CStr(Val(Mid(txCRDlls.Text, InStr(txCRDlls.Text, "(") + 1))).PadLeft(2, "0")
                            txPlazaDlls.Text = dtDatosGestor.Rows(0).Item(1).ToString.ToUpper
                            If InStr(txPlazaDlls.Text, "(") > 0 Then txNumPlazaDlls.Text = CStr(Val(Mid(txPlazaDlls.Text, InStr(txPlazaDlls.Text, "(") + 1))).PadLeft(3, "0")
                            txSucursalDlls.Text = dtDatosGestor.Rows(0).Item(2).ToString.ToUpper
                            If InStr(txSucursalDlls.Text, "(") > 0 Then
                                txNumSucDlls.Text = CStr(Val(Mid(txSucursalDlls.Text, InStr(txSucursalDlls.Text, "(") + 1)))
                                If Len(txNumSucDlls.Text) > 4 Then
                                    txNumSucDlls.Text = txNumSucDlls.Text.Substring(Len(txNumSucDlls.Text) - 4).PadLeft(4, "0")
                                Else
                                    txNumSucDlls.Text = txNumSucDlls.Text.PadLeft(4, "0")
                                End If
                            End If
                            txNumGestorDlls.Text = Trim(dtDatosGestor.Rows(0).Item(3))
                            txNomGestorDlls.Text = dtDatosGestor.Rows(0).Item(4).ToString.ToUpper
                        End If
                        btSolicitar.Enabled = True
                    Else
                        'No tiene cuenta eje pesos
                        MsgBox("La cuenta no tiene cuenta eje pesos.", vbInformation, "Cuenta Invalida")
                        btSolicitar.Enabled = False
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento gvOperaciones_CellMouseClick, Error:" & ex.Message, vbInformation, "Seleccionar una operacion")
            Exit Sub
        End Try

    End Sub

    Private Sub txCuenta_TextChanged(sender As Object, e As EventArgs) Handles txCuenta.TextChanged
        If Trim(txCuenta.Text) = "" Then
            btSolicitar.Enabled = False
        Else
            btSolicitar.Enabled = True
        End If
    End Sub



#Region "FUNCIONES"


#End Region

End Class