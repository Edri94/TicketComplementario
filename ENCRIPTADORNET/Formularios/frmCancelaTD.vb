Public Class frmCancelaTD

    Dim gAgencia As Integer
    Dim mnOpDefinida As Integer
    Dim GnProductoContratado As Long
    Dim GnStatusProducto As Long
    Public selec As Boolean

    Private Sub frmCancelaTD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMensaje.Text = ""
        txtTicket.Tag = 0

        Me.CenterToScreen()

        lblMensaje.Font = New Font(lblMensaje.Font, FontStyle.Bold)
        lblMensaje.ForeColor = Color.Blue
    End Sub

    Private Sub txtTicket_TextChanged(sender As Object, e As EventArgs) Handles txtTicket.TextChanged
        Exit Sub
    End Sub

    Private Sub txtTicket_GotFocus(sender As Object, e As EventArgs) Handles txtTicket.GotFocus
        Dim g As New Cursors
        'g.MarcaTexto(txtTicket)
    End Sub

    Private Sub txtTicket_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTicket.KeyPress
        Dim g As New Cursors

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            'If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True
            cmdSalir.Focus()
        ElseIf txtTicket.Tag <> 0 Then
            LimpiaControles()
        End If
    End Sub

    Private Sub LimpiaControles()
        txtAgencia.Text = ""
        txtCuenta.Text = ""
        txtTicket.Text = ""
        txtOrigen.Text = ""
        txtComentario.Text = ""
        txtMonto.Text = ""
        txtTasa.Text = ""
        txtPlazo.Text = ""
        txtDescripcion.Text = ""
        txtFecOperacion.Text = ""
        txtFecCaptura.Text = ""
        txtFecVencimiento.Text = ""
        txtComentario.Text = ""
        txtTicket.Tag = 0
        lblMensaje.Text = ""
        lblMensaje.Visible = False
        cmdCancelar.Enabled = False
        cmdCancelar.Text = "&Cancelar"
        'txtTicket.Focus()
    End Sub

    Private Sub txtTicket_LostFocus(sender As Object, e As EventArgs) Handles txtTicket.LostFocus
        Dim lsFechaO As String
        Dim lsMensaje As String
        Dim lsMonto As String
        Dim lnMonto As Long
        Dim d As New DataSourceModCancelaCtas
        Dim dtBuscaTicket As DataTable

        If Val(txtTicket.Text) = 0 Then Exit Sub
        If Len(txtTicket.Text) < 7 Then Exit Sub
        lsMensaje = ""
        lsMonto = "0.00"

        Cursor = System.Windows.Forms.Cursors.WaitCursor

        If txtTicket.Tag = 0 Then             'Este ticket no se habia buscado anteriormente

            txtTicket.Tag = Val(txtTicket.Text)

            dtBuscaTicket = d.BuscaTicketCan(txtTicket.Text)

            If dtBuscaTicket.Rows.Count <= 0 Then
                Cursor = System.Windows.Forms.Cursors.Default
                MsgBox("La operación con numero de Ticket " & Trim(txtTicket.Text) & " no es valida para este tipo de cancelación.", vbInformation, "Bloqueo / Desbloqueo TD's")
                txtTicket.Tag = 0
                txtTicket.Text = ""
                txtTicket.Focus()
                Exit Sub
            Else
                cmdCancelar.Enabled = True
                Select Case Val(dtBuscaTicket.Rows(0).Item(0).ToString().Trim())    'En base al status de operacion
                    Case 2 : lsMensaje = "fue validada"
                    Case 3 : lsMensaje = "ya fue enviada a Equation."
                    Case 4 : lsMensaje = "ya fue enviada y recibida en Equation."
                    Case 5 : lsMensaje = "fue rechazada en Equation."
                    Case 250
                        lsMensaje = "ya estaba cancelada."
                        Cursor = System.Windows.Forms.Cursors.Default
                        MsgBox("La operacion esta cancelada.", vbInformation, "Cancelación")
                        cmdCancelar.Enabled = False
                        txtTicket.Tag = 0
                        txtTicket.Text = ""
                        txtTicket.Focus()
                        Cursor = System.Windows.Forms.Cursors.Default
                        Exit Sub
                End Select

                lblMensaje.Visible = True
                lblMensaje.Text = "La operación " & lsMensaje
                lblComentario.Visible = True
                txtDescripcion.Text = dtBuscaTicket.Rows(0).Item(1).ToString().Trim()
                lblCuenta.Visible = True
                txtCuenta.Text = dtBuscaTicket.Rows(0).Item(2).ToString().Trim()
                lblMonto.Visible = True
                lsMonto = dtBuscaTicket.Rows(0).Item(3).ToString().Trim()
                lnMonto = dtBuscaTicket.Rows(0).Item(3)

                txtMonto.Text = Format(lnMonto, "###,###,###,##0.00")
                txtFecCaptura.Text = Trim(dtBuscaTicket.Rows(0).Item(5).ToString().Trim())
                txtFecOperacion.Text = Trim(dtBuscaTicket.Rows(0).Item(4).ToString().Trim())
                txtAgencia.Text = dtBuscaTicket.Rows(0).Item(8).ToString().Trim()
                gAgencia = Val(dtBuscaTicket.Rows(0).Item(6).ToString().Trim())
                mnOpDefinida = dtBuscaTicket.Rows(0).Item(7).ToString().Trim()
                lsFechaO = dtBuscaTicket.Rows(0).Item(4).ToString().Trim()

                If mnOpDefinida = 80 Then       'Es un Time Deposit
                    dtBuscaTicket = Nothing
                    dtBuscaTicket = d.BuscaTD(txtTicket.Text)

                    If dtBuscaTicket.Rows.Count > 0 Then
                        txtFecVencimiento.Text = dtBuscaTicket.Rows(0).Item(0).ToString().Trim()
                        txtTasa.Text = dtBuscaTicket.Rows(0).Item(1).ToString().Trim()
                        'If mnOpDefinida = 80 Then         'Si es TD
                        txtPlazo.Text = dtBuscaTicket.Rows(0).Item(2).ToString().Trim()
                        txtOrigen.Text = dtBuscaTicket.Rows(0).Item(3).ToString().Trim()
                        'Asigna Producto Contratado y Estatus del TD, asociado al ticket capturado.
                        GnProductoContratado = CLng(dtBuscaTicket.Rows(0).Item(4).ToString().Trim())
                        'End If
                    Else
                        Cursor = System.Windows.Forms.Cursors.Default
                        MsgBox("No es posible encontrar información sobre el TD.", vbCritical, "SQL Server Error")
                        cmdCancelar.Enabled = False
                        dtBuscaTicket = Nothing
                        Exit Sub
                    End If

                End If

            End If

        End If
        txtComentario.Focus()
        Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Dim lsStatusGlobal As String
        Dim lsStatus As String
        Dim d As New DataSourceModCancelaCtas
        Dim dtBuscaTicket As DataTable
        Dim regActualiza As Integer
        Dim InsEventoOper As Integer

        If txtComentario.Text.Trim = "" Then     'No hay comentario de bloqueo / desbloqueo
            MsgBox("Es necesario indicar el motivo de la cancelación. ", vbInformation, "Cancelación.")
            txtComentario.Focus()
            Exit Sub
        End If

        If MsgBox("¿Desea cancelar la operación " & txtTicket.Text.Trim & "?", vbQuestion + vbYesNo, "Cancelación") = vbNo Then Exit Sub

        Cursor = System.Windows.Forms.Cursors.WaitCursor

        regActualiza = 0
        regActualiza = d.ActOper(CInt(txtTicket.Text), 250)

        If regActualiza <= 0 Then
            MsgBox("No es posible cancelar la operación en la base de datos.", vbCritical, "SQL Server Error")
            Exit Sub
        End If

        lsStatusGlobal = "0"
        Select Case mnOpDefinida
            Case 80 : lsStatusGlobal = "24"
            Case 180 : lsStatusGlobal = "41"
        End Select

        'StatusProducto
        dtBuscaTicket = Nothing
        dtBuscaTicket = d.BuscaOperTD(CInt(lsStatusGlobal))

        If regActualiza <= 0 Then
            MsgBox("No es posible obtener el estatus del producto de la operación en la base de datos.", vbCritical, "SQL Server Error")
            Exit Sub
        End If

        lsStatus = dtBuscaTicket.Rows(0).Item(0)

        'Actualiza producto ActProdCont
        regActualiza = 0
        regActualiza = d.ActProdCont(GnProductoContratado, CInt(lsStatus))

        If regActualiza <= 0 Then
            MsgBox("No es posible actualizar el estatus del producto en la base de datos.", vbCritical, "SQL Server Error")
            Exit Sub
        End If

        'inserta en operacion evento, la cancelación del td
        InsEventoOper = 0
        InsEventoOper = d.InsEventoOper(CLng(txtTicket.Text), "250", UCase(txtComentario.Text.Trim), usuario)
        If InsEventoOper <= 0 Then
            MsgBox("No es posible insertar el evento de la operación en la base de datos.", vbCritical, "SQL Server Error")
            'Exit Sub
        End If

        Cursor = System.Windows.Forms.Cursors.Default

        MsgBox("El ticket " & txtTicket.Text & " fue cancelado exitosamente.", vbInformation, "Cancelación")

        LimpiaControles()

    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    Private Sub cmdSalir_LostFocus(sender As Object, e As EventArgs) Handles cmdSalir.LostFocus

    End Sub

    Private Sub cmdCancelar_GotFocus(sender As Object, e As EventArgs) Handles cmdCancelar.GotFocus
        selec = True
    End Sub

    Private Sub cmdCancelar_LostFocus(sender As Object, e As EventArgs) Handles cmdCancelar.LostFocus
        selec = False
    End Sub

    Private Sub cmdCancelar_MouseEnter(sender As Object, e As EventArgs) Handles cmdCancelar.MouseEnter
        cmdCancelar_GotFocus(sender, e)
    End Sub

    Private Sub cmdLimpiar_Click(sender As Object, e As EventArgs) Handles cmdLimpiar.Click
        LimpiaControles()
    End Sub

End Class