Imports System.Globalization
Imports System.Threading

Public Class frmBloqueoTD

    Dim gAgencia As Integer
    Dim mnOpDefinida As Integer
    Dim GnProductoContratado As Long
    Dim GnStatusProducto As Long
    Public selec As Boolean

    'Private 

    Private Sub frmBloqueoTD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMensaje.Text = ""
        txtTicket.Tag = 0

        Me.CenterToScreen()

        lblMensaje.Font = New Font(lblMensaje.Font, FontStyle.Bold)
        lblMensaje.ForeColor = Color.Blue
        cmdBloquear.Enabled = False
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub cmdLimpiar_Click(sender As Object, e As EventArgs) Handles cmdLimpiar.Click
        LimpiaControles()
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
        cmdBloquear.Enabled = False
        cmdBloquear.Text = "&Bloquear"
        'txtTicket.Focus()
    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    Private Sub txtTicket_TextChanged(sender As Object, e As EventArgs) Handles txtTicket.TextChanged
        Exit Sub
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

            dtBuscaTicket = d.BuscaTicket(txtTicket.Text)
            If dtBuscaTicket.Rows.Count <= 0 Then

                Cursor = System.Windows.Forms.Cursors.Default
                MsgBox("La operación con numero de Ticket " & Trim(txtTicket.Text) & " no es valida para este tipo de bloqueo.", vbInformation, "Bloqueo / Desbloqueo TD's")
                txtTicket.Tag = 0
                txtTicket.Text = ""
                txtTicket.Focus()
                Exit Sub

            Else

                cmdBloquear.Enabled = True
                Select Case Val(dtBuscaTicket.Rows(0).Item(0).ToString().Trim())    'En base al status de operacion
                    Case 2 : lsMensaje = "fue validada"
                    Case 3 : lsMensaje = "ya fue enviada a Equation."
                    Case 4 : lsMensaje = "ya fue enviada y recibida en Equation."
                    Case 5 : lsMensaje = "fue rechazada en Equation."
                    Case 250
                        lsMensaje = "ya estaba cancelada."
                        Cursor = System.Windows.Forms.Cursors.Default
                        MsgBox("La operacion esta cancelada por lo que no se puede bloquear/desbloquear.", vbInformation, "Bloqueo / Desbloqueo TD's")
                        cmdBloquear.Enabled = False
                        txtTicket.Tag = 0
                        txtTicket.Text = ""
                        txtTicket.Focus()
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

                '------------------------------------------------------------- RACB 19-05-2021
                If Thread.CurrentThread.CurrentCulture.Name = "en-US" Then
                    txtFecCaptura.Text = Date.ParseExact(Trim(dtBuscaTicket.Rows(0).Item(5).ToString().Trim()), "dd-MM-yyyy", Nothing).ToString("MM-dd-yyyy").ToString()
                    txtFecOperacion.Text = Date.ParseExact(Trim(dtBuscaTicket.Rows(0).Item(4).ToString().Trim()), "dd-MM-yyyy", Nothing).ToString("MM-dd-yyyy").ToString()
                ElseIf Thread.CurrentThread.CurrentCulture.Name = "es-MX" Then
                    txtFecCaptura.Text = Trim(dtBuscaTicket.Rows(0).Item(5).ToString().Trim())
                    txtFecOperacion.Text = Trim(dtBuscaTicket.Rows(0).Item(4).ToString().Trim())
                End If
                'txtFecCaptura.Text = Trim(dtBuscaTicket.Rows(0).Item(5).ToString().Trim())
                'txtFecOperacion.Text = Trim(dtBuscaTicket.Rows(0).Item(4).ToString().Trim())
                '------------------------------------------------------------- RACB 19-05-2021

                txtAgencia.Text = dtBuscaTicket.Rows(0).Item(8).ToString().Trim()
                gAgencia = Val(dtBuscaTicket.Rows(0).Item(6).ToString().Trim())
                mnOpDefinida = dtBuscaTicket.Rows(0).Item(7).ToString().Trim()
                lsFechaO = dtBuscaTicket.Rows(0).Item(4).ToString().Trim()

                If mnOpDefinida = 80 Then       'Es un Time Deposit
                    dtBuscaTicket = Nothing
                    dtBuscaTicket = d.BuscaTD(txtTicket.Text)

                    If dtBuscaTicket.Rows.Count > 0 Then
                        '------------------------------------------------------------- RACB 19-05-2021
                        If Thread.CurrentThread.CurrentCulture.Name = "en-US" Then
                            txtFecVencimiento.Text = DateTime.ParseExact(Trim(dtBuscaTicket.Rows(0).Item(0).ToString().Trim()), "dd-MM-yyyy", Nothing).ToString("MM-dd-yyyy")
                        ElseIf Thread.CurrentThread.CurrentCulture.Name = "es-MX" Then
                            txtFecVencimiento.Text = dtBuscaTicket.Rows(0).Item(0).ToString().Trim()
                        End If
                        'txtFecVencimiento.Text = dtBuscaTicket.Rows(0).Item(0).ToString().Trim()
                        '------------------------------------------------------------- RACB 19-05-2021

                        txtTasa.Text = dtBuscaTicket.Rows(0).Item(1).ToString().Trim()

                        If mnOpDefinida = 80 Then         'Si es TD
                            txtPlazo.Text = dtBuscaTicket.Rows(0).Item(2).ToString().Trim()
                            txtOrigen.Text = dtBuscaTicket.Rows(0).Item(3).ToString().Trim()
                            'Asigna Producto Contratado y Estatus del TD, asociado al ticket capturado.
                            GnProductoContratado = CLng(dtBuscaTicket.Rows(0).Item(4).ToString().Trim())
                            GnStatusProducto = dtBuscaTicket.Rows(0).Item(5).ToString().Trim()
                        End If

                        Select Case GnStatusProducto
                            Case 8043 'Ya esta bloqueado
                                cmdBloquear.Text = "&Desbloquear"
                                cmdBloquear.Enabled = True
                                lblComentario.Text = "Motivo del desbloqueo:"
                            Case 8003 'Activo, puede bloquerse
                                cmdBloquear.Text = "&Bloquear"
                                cmdBloquear.Enabled = True
                                lblComentario.Text = "Motivo del bloqueo:"
                            Case Else
                                cmdBloquear.Text = "&Bloquear"
                                cmdBloquear.Enabled = False
                                lblComentario.Text = "Motivo del bloqueo:"
                                Cursor = System.Windows.Forms.Cursors.Default
                                MsgBox("No es posible bloquear / desbloquear Time Deposit" & vbCrLf &
                                       "Tal vez la operación ya se encuentra vencida o cancelada.", vbInformation, "Bloqueo / Desbloqueo TD's")
                                Exit Sub
                        End Select

                    Else
                        Cursor = System.Windows.Forms.Cursors.Default
                        MsgBox("No es posible encontrar información sobre el TD.", vbCritical, "SQL Server Error")
                        cmdBloquear.Enabled = False
                        dtBuscaTicket = Nothing
                        Exit Sub
                    End If

                End If

            End If

        End If

        Cursor = System.Windows.Forms.Cursors.Default
        txtComentario.Focus()

    End Sub

    Private Sub txtTicket_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTicket.KeyPress
        Dim g As New Cursors
        'e = g.Filtra(e, 1)

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            'If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True
            cmdSalir.Focus()
        ElseIf txtTicket.Tag <> 0 Then
            LimpiaControles()
        End If


    End Sub

    Private Sub txtTicket_GotFocus(sender As Object, e As EventArgs) Handles txtTicket.GotFocus
        Dim g As New Cursors
        'g.MarcaTexto(txtTicket)
    End Sub

    Private Sub cmdBloquear_Click(sender As Object, e As EventArgs) Handles cmdBloquear.Click
        Dim strTit As String
        Dim datFechaVenc As Date
        Dim datFechaHoy As Date
        Dim lngOperVenc As Long
        Dim lngOperReno As Long
        Dim d As New DataSourceModCancelaCtas
        Dim dtBuscaTicket As DataTable
        Dim regActualiza As Integer
        Dim insEventoProd As Integer

        strTit = ""
        If GnStatusProducto = 8003 Then 'Activo, puede bloquerse
            strTit = "Bloquear"
        ElseIf GnStatusProducto = 8043 Then 'Ya esta bloqueado, puede desbloquearse
            strTit = "Desbloquear"
        End If

        If txtComentario.Text.Trim = "" Then     'No hay comentario de bloqueo / desbloqueo
            MsgBox("Es necesario indicar el motivo para " & strTit, vbInformation, "Bloqueo / Desbloqueo TD's")
            txtComentario.Focus()
            Exit Sub
        End If

        If MsgBox("¿Desea " & strTit & " la operación " & txtTicket.Text.Trim & "?", vbQuestion + vbYesNo, "Bloqueo / Desbloqueo TD's") = vbNo Then Exit Sub

        'Cambiar a verdadero la validación cuando pase a producción
        Dim l As New Libreria
        If l.Permiso("PBLOQUEATD") Then
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            'Busca la operacion futura (operacion de reovación) asociada con el Producto contratado.
            dtBuscaTicket = Nothing
            dtBuscaTicket = d.BuscaOperTD(GnProductoContratado)

            If dtBuscaTicket.Rows.Count > 0 Then
                'Asigna Operacion de Renovación futura
                lngOperReno = dtBuscaTicket.Rows(0).Item(0)

                If GnStatusProducto = 8003 Then 'Activo, puede bloquerse

                    'bloquea Operacion de Renovación Futura
                    regActualiza = 0
                    regActualiza = d.ActOper(lngOperReno, 250)
                    If regActualiza <= 0 Then
                        MsgBox("No es posible " & strTit & " la operación en la base de datos.", vbCritical, "SQL Server Error")
                        Exit Sub
                    End If
                    'Bloquea ProductoContratado del TD asociado al Ticket que se busco en pantalla
                    regActualiza = 0
                    regActualiza = d.ActProdCont(GnProductoContratado, 8043)
                    If regActualiza <= 0 Then
                        MsgBox("No es posible " & strTit & " la operación en la base de datos.", vbCritical, "SQL Server Error")
                        Exit Sub
                    End If

                ElseIf GnStatusProducto = 8043 Then 'Ya esta bloqueado, puede desbloquearse

                    datFechaVenc = CDate(txtFecVencimiento.Text)
                    datFechaHoy = CDate(gs_FechaHoy)

                    If datFechaVenc > datFechaHoy Then
                        'Desbloquea Operacion de Renovación Futura
                        regActualiza = 0
                        regActualiza = d.ActOper(lngOperReno, 0)
                        If regActualiza <= 0 Then
                            MsgBox("No es posible " & strTit & " la operación en la base de datos.", vbCritical, "SQL Server Error")
                            Exit Sub
                        End If
                        'Desbloquea y Activa el  ProductoContratado del TD asociado al Ticket que se busco en pantalla
                        regActualiza = 0
                        regActualiza = d.ActProdCont(GnProductoContratado, 8003)
                        If regActualiza <= 0 Then
                            MsgBox("No es posible " & strTit & " la operación en la base de datos.", vbCritical, "SQL Server Error")
                            Exit Sub
                        End If
                    ElseIf datFechaVenc = datFechaHoy Then
                        'Desbloquea Operacion de Renovación Futura
                        regActualiza = 0
                        regActualiza = d.ActOper(lngOperReno, 1)
                        If regActualiza <= 0 Then
                            MsgBox("No es posible " & strTit & " la operación en la base de datos.", vbCritical, "SQL Server Error")
                            Exit Sub
                        End If
                        regActualiza = 0
                        'Vence el ProductoContratado del TD asociado al Ticket que se busco en pantalla
                        regActualiza = d.ActProdCont(GnProductoContratado, 8025)
                        If regActualiza <= 0 Then
                            MsgBox("No es posible " & strTit & " la operación en la base de datos.", vbCritical, "SQL Server Error")
                            Exit Sub
                        End If

                        dtBuscaTicket = Nothing
                        dtBuscaTicket = d.BuscaOperCompraTD(GnProductoContratado)
                        lngOperVenc = dtBuscaTicket.Rows(0).Item(0)

                        If lngOperVenc > 0 Then
                            'Desbloquea Operacion de Renovación y la pone como integrada en Saldos
                            regActualiza = 0
                            regActualiza = d.ActOper(lngOperVenc, 4)
                            If regActualiza <= 0 Then
                                MsgBox("No es posible " & strTit & " la operación en la base de datos.", vbCritical, "SQL Server Error")
                                Exit Sub
                            End If
                        Else
                            Cursor = System.Windows.Forms.Cursors.Default
                            MsgBox("No se puede " & strTit & " TD, porque no existe depósito por vencimiento.", vbCritical, "SQL Server Error")
                            Exit Sub
                        End If

                    ElseIf datFechaVenc < datFechaHoy Then
                        'Vence el ProductoContratado del TD asociado al Ticket que se busco en pantalla
                        regActualiza = 0
                        regActualiza = d.ActProdCont(GnProductoContratado, 8025)
                        If regActualiza <= 0 Then
                            MsgBox("No es posible " & strTit & " la operación en la base de datos.", vbCritical, "SQL Server Error")
                            Exit Sub
                        End If

                        MsgBox("El time deposit ha vencido." & vbCrLf &
                               "El producto contratado ha sido cambiado de bloqueado a vencido." & vbCrLf &
                               "Deposito por vencimiento no existe o no puede haber quedado cancelado.", vbInformation, "Bloqueo / Desbloqueo TD's")

                    End If

                End If

                'inserta en evento producto
                insEventoProd = 0
                insEventoProd = d.InsEventoProd(GnProductoContratado, GnStatusProducto, UCase(txtComentario.Text.Trim), usuario)
                If regActualiza <= 0 Then
                    MsgBox("No es posible " & strTit & " la operación en la base de datos.", vbCritical, "SQL Server Error")
                    Exit Sub
                End If

                If GnStatusProducto = 8003 Then 'Activo, puede bloquerse
                    strTit = "Bloqueado"
                ElseIf GnStatusProducto = 8043 Then 'Ya esta bloqueado, puede desbloquearse
                    strTit = "Desbloqueado"
                End If

                MsgBox("El ticket " & txtTicket.Text & " fue " & strTit & " exitosamente.", vbInformation, "Bloqueo / Desbloqueo TD's")
                LimpiaControles()
                Cursor = System.Windows.Forms.Cursors.Default

            Else
                MsgBox("No se encuentra la operación a renovar", vbExclamation, "Bloqueo / Desbloqueo TD's")
            End If

        Else
            MsgBox("No puede continuar para " & strTit, vbInformation, "Aviso")
            Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub

            'If Not PideAutorizacion("ABLOQUEATD", Trim(txtCtaCte.text), 80, txtMonto, txtTasa, , txtPlazo) Then
            '    MsgBox("No puede continuar para " & strTit, vbInformation, "Aviso")
            '    Cursor = System.Windows.Forms.Cursors.Default
            '    Exit Sub
            'End If

        End If

        'inserta en evento producto
        'insEventoProd = 0
        'insEventoProd = d.InsEventoProd(GnProductoContratado, GnStatusProducto, UCase(txtComentario.Text.Trim), usuario)
        'If regActualiza <= 0 Then
        '    MsgBox("No es posible " & strTit & " la operación en la base de datos.", vbCritical, "SQL Server Error")
        '    Exit Sub
        'End If

        'If GnStatusProducto = 8003 Then 'Activo, puede bloquerse
        '    strTit = "Bloqueado"
        'ElseIf GnStatusProducto = 8043 Then 'Ya esta bloqueado, puede desbloquearse
        '    strTit = "Desbloqueado"
        'End If

        'MsgBox("El ticket " & txtTicket.Text & " fue " & strTit & " exitosamente.", vbInformation, "Bloqueo / Desbloqueo TD's")
        'LimpiaControles()
        Cursor = System.Windows.Forms.Cursors.Default
        'Exit Sub

    End Sub

    Private Sub cmdBloquear_MouseEnter(sender As Object, e As EventArgs) Handles cmdBloquear.MouseEnter
        cmdBloquear_GotFocus(sender, e)
    End Sub

    Private Sub cmdBloquear_GotFocus(sender As Object, e As EventArgs) Handles cmdBloquear.GotFocus
        selec = True
    End Sub

    Private Sub cmdBloquear_LostFocus(sender As Object, e As EventArgs) Handles cmdBloquear.LostFocus
        selec = False
    End Sub

    Private Sub cmdSalir_GotFocus(sender As Object, e As EventArgs) Handles cmdSalir.GotFocus
        selec = True
    End Sub

    Private Sub cmdSalir_LostFocus(sender As Object, e As EventArgs) Handles cmdSalir.LostFocus
        selec = False
    End Sub

    Private Sub cmdSalir_MouseEnter(sender As Object, e As EventArgs) Handles cmdSalir.MouseEnter
        'cmdSalir_GotFocus(sender, e)
    End Sub
End Class