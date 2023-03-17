'*************    Módulo de Chequeras    **************'
'****       Fecha de Creación: /07/2020           ***'
'**** Creado por: SGGG-Susan Gabriela Gómez González***' 
Public Class frmCancelarCHQ

    Dim FTicket As String
    Dim FProductoContratado As Integer
    Public FCuentaCliente As String


    Private BindingSource1 As BindingSource = New BindingSource
    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
        iCtaCliente = ""
        Me.Close()
    End Sub

    Private Sub frmCancelarCHQ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.CenterToScreen()
            txCuenta.Text = " "
            LimpiaCampos()
            txFecha.Text = Date.Now.Date.ToString("dd-MM-yyyy")
            dtpFechaIni.Text = DateTime.Now
            dtpFechaFin.Text = DateTime.Now

            lbMotivo.Visible = False
            txMotivo.Visible = False
            btCancelar.Enabled = False
            txMotivo.CharacterCasing = CharacterCasing.Upper
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en la funcion frmConsulCHQApertura_Load, Error:" & ex.Message, vbInformation, "Carga formulario ValidaApertura")
            Exit Sub
        End Try

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
    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        Dim d As New Datasource

        lbMotivo.Visible = False
        txMotivo.Visible = False
        btCancelar.Enabled = False
        LimpiaCampos()
        If cbCuenta.Checked Then
            If txCuentaIni.Text = "" Then
                MsgBox("Es necesario indicar el número de cuenta inicial.", vbInformation, "Dato Faltante")
                txCuentaIni.Focus()
                Exit Sub
            End If
            If txCuentaFin.Text = "" Then
                MsgBox("Es necesario indicar el número de cuenta final.", vbInformation, "Dato Faltante")
                txCuentaFin.Focus()
                Exit Sub
            End If
            If Val(txCuentaIni.Text) > Val(txCuentaFin.Text) Then
                MsgBox("La cuenta de inicio debe ser menor o igual a la cuenta final.", vbInformation, "Dato Faltante")
                txCuentaIni.Focus()
                Exit Sub
            End If

        End If

        If cbFecha.Checked Then
            If CDate(dtpFechaIni.Text) > CDate(dtpFechaFin.Text) Then
                MsgBox("La fecha inicial del periodo debe ser menor o igual a la fecha final.", vbInformation, "Fecha Invalida")
                dtpFechaIni.Text = DateTime.Now
                dtpFechaFin.Text = DateTime.Now
                Exit Sub
            End If
        End If

        If cbCuenta.Checked = True And cbFecha.Checked = False Then
            BindingSource1.DataSource = d.ObtieneChequera(txCuentaIni.Text, txCuentaFin.Text, "", "")
        ElseIf cbFecha.Checked = True And cbCuenta.Checked = False Then
            BindingSource1.DataSource = d.ObtieneChequera("", "", dtpFechaIni.Text, dtpFechaFin.Text)
        ElseIf cbCuenta.Checked And cbFecha.Checked Then
            BindingSource1.DataSource = d.ObtieneChequera(txCuentaIni.Text, txCuentaFin.Text, dtpFechaIni.Text, dtpFechaFin.Text)
        End If

        ' propiedades para el DataGridview  
        '''''''''''''''''''''''''''''''''''''''  
        With gvOperaciones
            ' enlazar los controles  
            .DataSource = BindingSource1.DataSource
        End With

    End Sub

    Private Sub gvOperaciones_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles gvOperaciones.CellMouseClick
        Try
            Dim d = New Datasource
            Dim dtDatosCliente As DataTable
            Dim dtDatosSucursal As DataTable
            Dim dtDatosCR As DataTable

            Dim sSucSolicita As String
            txMotivo.Text = ""

            If Not String.IsNullOrEmpty(gvOperaciones.CurrentRow.Cells("Cuenta").Value.ToString()) Then

                SelectFilaDocto(gvOperaciones.CurrentRow.Cells("Chequera").Value)

                'Llena Campos
                dtDatosCliente = d.DatosConsCancelCHQ(gvOperaciones.CurrentRow.Cells("Chequera").Value.ToString())

                iCtaCliente = gvOperaciones.CurrentRow.Cells("cuenta").Value

                If dtDatosCliente.Rows.Count >= 0 Then
                    txPrefijo.Text = Trim(dtDatosCliente.Rows(0).Item(0))
                    txCuenta.Text = Trim(dtDatosCliente.Rows(0).Item(1))
                    txFecha.Text = Trim(dtDatosCliente.Rows(0).Item(2))
                    txNombre.Text = dtDatosCliente.Rows(0).Item(3).ToString.ToUpper
                    txNumGestor.Text = Trim(dtDatosCliente.Rows(0).Item(4))
                    txNumGestorSol.Text = Trim(dtDatosCliente.Rows(0).Item(6))
                    txNomGestorSol.Text = Trim(dtDatosCliente.Rows(0).Item(7))
                    sSucSolicita = Trim(dtDatosCliente.Rows(0).Item(8))
                    txNumSucSol.Text = Mid(sSucSolicita, 4)
                    txNumCheques.Text = Trim(dtDatosCliente.Rows(0).Item(9))
                    txUltimoCHQ.Text = Trim(dtDatosCliente.Rows(0).Item(10))
                    txFolioFin.Text = Trim(dtDatosCliente.Rows(0).Item(10))
                    txFolioIni.Text = CStr(Val(txFolioFin.Text) - Val(txNumCheques.Text) + 1)
                    txRegistro.Text = Trim(dtDatosCliente.Rows(0).Item(11))

                    If Len(Trim(dtDatosCliente.Rows(0).Item(5))) = 12 Or Len(Trim(dtDatosCliente.Rows(0).Item(5))) = 10 Then
                        txNumCtaEje.Text = Trim(dtDatosCliente.Rows(0).Item(5))
                    Else
                        MsgBox("La cuenta no tiene cuenta eje pesos.", vbInformation, "Cuenta Invalida")
                    End If
                    If Val(dtDatosCliente.Rows(0).Item(12)) <> 250 Then
                        btCancelar.Enabled = True
                        lbMotivo.Visible = True
                        txMotivo.Visible = True
                    Else
                        MsgBox("Esta Chequera se encuetra Cancelada.", vbInformation, "Información")
                        btCancelar.Enabled = False
                        lbMotivo.Visible = False
                        txMotivo.Visible = False
                        ColorColumnaCancelada()
                    End If
                    If Val(dtDatosCliente.Rows(0).Item(13)) = 5 Then
                        'Si es solicitud de 500 cheques
                        lblTipo.Visible = True
                    Else
                        'Si es otro tipo de solicitud
                        lblTipo.Visible = False
                    End If

                    txNumCR.Text = Trim(dtDatosCliente.Rows(0).Item(14))
                    txCR.Text = Trim(dtDatosCliente.Rows(0).Item(15))
                    txNumSucursal.Text = Trim(dtDatosCliente.Rows(0).Item(18))
                    txSucursal.Text = Trim(dtDatosCliente.Rows(0).Item(19))
                    txNumCRSol.Text = dtDatosCliente.Rows(0).Item(20)


                    'Obtenemos nombre de la sucursal solicitante
                    If Trim(sSucSolicita) <> "" Then
                        dtDatosSucursal = d.LoadSucursal("", sSucSolicita)
                        txSucursalSol.Text = dtDatosSucursal.Rows(0).Item(1)
                    End If

                    'Obtenemos nombre del Centro Regional 
                    If txNumCRSol.Text().Trim <> "" Then
                        If txNumCRSol.Text.Trim <> txNumCR.Text Then
                            dtDatosCR = d.DatosCR(txNumCRSol.Text())
                            If dtDatosCR.Rows().Count > 0 Then
                                txCRSol.Text = dtDatosCR.Rows(0).Item(0)
                            Else
                                txCRSol.Text = ""
                            End If
                        Else
                            txCRSol.Text = txCR.Text
                        End If
                    End If
                End If
                    lbMotivo.Visible = True
                txMotivo.Visible = True
                btCancelar.Enabled = True
            End If
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento gvOperaciones_CellMouseClick, Error:" & ex.Message, vbInformation, "Seleccionar una operacion")
            Exit Sub
        End Try

    End Sub

    Private Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        Try
            Dim d As New Datasource
            Dim sRegistro As String
            Dim saRegistro() As String

            ReDim saRegistro(1)

            If Trim(txMotivo.Text) = "" Then
                MsgBox("Es necesario indicar el motivo de la cancelación.", vbInformation, "Dato Faltante")
                txMotivo.Focus()
                Exit Sub
            End If

            'Si es chequera de 500 cheques
            If lblTipo.Visible Then
                If MsgBox("Esta solicitud involucra 5 solicitudes de 100 cheques." & Chr(13) &
                        "¿Desea cancelar las solicitudes involucradas?", vbQuestion + vbYesNo,
                        "Solicitud de 500 Cheques") = vbNo Then
                    'sRegistro = d.CancelaChequera(1, txRegistro.Text, saRegistro)
                    'If sRegistro = "OK" Then
                    '    ColorColumnaCancelada()
                    '    MsgBox("La Chequera se fue Cancelada.", vbInformation, "Información")
                    'End If
                    Exit Sub
                Else
                    saRegistro = d.CancelaChequera500(txRegistro.Text)
                    For lnContador = 0 To saRegistro.Length - 1
                        Dim ret As Integer = Buscar(
                                    "chequera",
                                    saRegistro(lnContador),
                                    BindingSource1)
                        ' si no se encontró ....  
                        If ret = -1 Then
                            ' mostrar un mensaje  
                            MsgBox("No se encontró la fila", MsgBoxStyle.Critical)
                        Else
                            With gvOperaciones
                                ' volver a enlazar  
                                .DataSource = BindingSource1
                                ' Pasarle el índice para  
                                .Item(0, ret).Style.BackColor = Color.LightCoral
                                .Item(1, ret).Style.BackColor = Color.LightCoral
                                .Item(2, ret).Style.BackColor = Color.LightCoral
                                .Item(3, ret).Style.BackColor = Color.LightCoral
                            End With
                        End If
                    Next lnContador
                    ColorColumnaCancelada()
                    MsgBox("La Chequera fue Cancelada.", vbInformation, "Información")
                End If
            Else
                If MsgBox("¿Desea cancelar la chequera con el No " & txRegistro.Text & ", de la cuenta " & txCuenta.Text & "?", vbQuestion + vbYesNo,
                            "Solicitud de 500 Cheques") = vbNo Then
                    Exit Sub
                Else
                    sRegistro = d.CancelaChequera(1, txRegistro.Text, saRegistro)
                    If sRegistro = "OK" Then
                        ColorColumnaCancelada()
                        MsgBox("La Chequera fue Cancelada.", vbInformation, "Información")
                        gvOperaciones.CurrentRow.Selected = False
                    End If
                End If

            End If

            btCancelar.Enabled = False
            lbMotivo.Visible = False
            txMotivo.Visible = False
        Catch ex As Exception
            MsgBox("No es posible Cancelar la chequera." & ex.Message, vbInformation, "Cancela Chequera")
            Exit Sub
        End Try
    End Sub

    Private Sub txCuentaIni_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txCuentaIni.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
        txCuentaIni.MaxLength = 6
    End Sub

    Private Sub txCuentaFin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txCuentaFin.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
        txCuentaFin.MaxLength = 6
    End Sub

    Private Sub txCuentaIni_Leave(sender As Object, e As EventArgs) Handles txCuentaIni.Leave
        txCuentaFin.Text = txCuentaIni.Text
        txCuentaFin.Focus()
    End Sub

    Sub ColorColumnaCancelada()
        With gvOperaciones
            .Item(0, gvOperaciones.CurrentRow.Index).Style.BackColor = Color.LightCoral
            .Item(1, gvOperaciones.CurrentRow.Index).Style.BackColor = Color.LightCoral
            .Item(2, gvOperaciones.CurrentRow.Index).Style.BackColor = Color.LightCoral
            .Item(3, gvOperaciones.CurrentRow.Index).Style.BackColor = Color.LightCoral
        End With

    End Sub
    Function Buscar(ByVal Columna As String, ByVal texto As String,
                    ByVal BindingSource As BindingSource) As Integer

        Try
            ' si está vacio salir y no retornar nada  
            If BindingSource1.DataSource Is Nothing Then
                Return -1
            End If

            ' Ejecutar el método Find pasándole los datos  
            Dim fila As Integer = BindingSource.Find(Columna.Trim, texto)

            ' Mover el cursor a la fila obtenida  
            BindingSource.Position = fila

            ' retornar el valor  
            Return fila

            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
        ' no retornar nada  
        Return -1

    End Function

    Private Sub cbCuenta_CheckedChanged(sender As Object, e As EventArgs) Handles cbCuenta.CheckedChanged

        If cbCuenta.Checked = False Then
            txCuentaIni.Text = ""
            txCuentaFin.Text = ""
            txCuentaIni.Enabled = False
            txCuentaFin.Enabled = False
        Else
            txCuentaIni.Enabled = True
            txCuentaFin.Enabled = True
        End If
    End Sub

    Private Sub cbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles cbFecha.CheckedChanged
        If cbFecha.Checked = False Then
            dtpFechaIni.Text = DateTime.Now
            dtpFechaFin.Text = DateTime.Now
            dtpFechaIni.Enabled = False
            dtpFechaFin.Enabled = False
        Else
            dtpFechaIni.Enabled = True
            dtpFechaFin.Enabled = True
        End If
    End Sub
    Sub SelectFilaDocto(ByVal iNumDocto As Integer)
        For i As Integer = 0 To gvOperaciones.Rows.Count - 1
            'Si el valor de la primera celda ubicada, por ejemplo, en la fila 1 es igual a 3
            If gvOperaciones.Rows(i).Cells("Chequera").Value = iNumDocto Then
                'Mueve el cursor a dicha fila
                gvOperaciones.CurrentCell = gvOperaciones.Item(0, i)
                'Pinta de color azul la fila para indicar al usuario el nuevo documento  
                gvOperaciones.Rows(i).Selected = True
                Exit For
            End If
        Next
    End Sub
End Class