
Public Class frmCapturaTraspaso

    Dim ms_CtaOrigen As String
    Dim ms_CtaDestino As String
    Dim ms_SufijoOrigen As String
    Dim ms_SufijoDestino As Integer
    Dim ms_AgOrigen As String
    Dim ms_AgDestino As Integer
    Dim mb_Salir As Boolean

    Dim frmCaptura As New frmCaptura
    Dim Libreria As New Libreria
    Public usuariogos As Integer
    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmCapturaTraspaso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Establece la máxima longitud de captura del Ticket
        txTicket.MaxLength = 7
        txTicket.Text = ""
        dtpFechaOperacion.Text = Date.Now.Date.ToString("dd-MM-yyyy")

        Me.CenterToScreen()




    End Sub

    Private Sub btAgregar_Click(sender As Object, e As EventArgs) Handles btAgregar.Click
        Try
            Dim d As New Datasource
            Dim sRegistro As String
            If frmCaptura.VerificarHrValida(3) = True Then
                If btAgregar.Text = "&Nueva" Then
                    btAgregar.Text = "&Agregar"
                    btAgregar.Enabled = False
                    grbDocto.Visible = False
                    LimpiaCampos()
                    txTicket.Text = ""
                    txTicket.Focus()
                    Exit Sub
                End If
                If Not BuscaTicket(Trim(txTicket.Text), True) Then
                    LimpiaCampos()
                    Exit Sub
                End If
Guardar:
                sRegistro = d.InsertaDoctoTraspaso(ms_CtaOrigen, ms_SufijoOrigen, dtpFechaCaptura.Value, dtpFechaOperacion.Value,
                                                    txMonto.Text, txTicket.Text, ms_CtaDestino, ms_SufijoDestino, txDocto.Text, usuariogos)
                If sRegistro = "OK" Then
                    MsgBox("Se insertó traspaso correctamente.", vbInformation, "Traspaso")
                    grbDocto.Visible = True
                    btAgregar.Text = "&Nueva"
                Else
                    If MsgBox("Ha ocurrido un error al guardar los datos del documento. ¿Desea Reintentar?", vbQuestion + vbRetryCancel, "SQL Server Error") = vbRetry Then
                        GoTo Guardar
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("No es posible capturar el traspaso ." & ex.Message, vbInformation, "Captura Traspasos")
            Exit Sub
        End Try
    End Sub

    Private Function BuscaTicket(ByVal Operacion As String, ls_validadocto As Boolean) As Boolean

        Dim d As New Datasource
        Dim dtDatoTraspGos As DataTable
        Dim dtDatosTraspasos As DataTable
        BuscaTicket = True

        'Busca el traspaso en GOS
        dtDatoTraspGos = d.BuscaTraspGOS(Operacion, dtpFechaOperacion.Text)
        'Si existe en GOS
        If dtDatoTraspGos IsNot Nothing Then
            MsgBox("Ya existe en GOS el Documento " & dtDatoTraspGos.Rows(0).Item(0) & " de Traspaso con éste número de Ticket.", vbInformation, "Traspaso")
            txTicket.Text = ""
            dtpFechaOperacion.Text = ""
            txTicket.Focus()
            BuscaTicket = False
            Exit Function
        End If

        'Si no existe en GOS
        dtDatosTraspasos = d.BuscaDatosTraspasos(Operacion)
        If dtDatosTraspasos.Rows().Count > 0 Then
            txMonto.Text = Format(dtDatosTraspasos.Rows(0).Item(0), "#,###,###,##0.00")
            txCuenta.Text = Trim(dtDatosTraspasos.Rows(0).Item(1)) + "-" + Trim(dtDatosTraspasos.Rows(0).Item(2))
            dtpFechaCaptura.Text = DateTime.Now
            dtpFechaOperacion.Text = dtDatosTraspasos.Rows(0).Item(4)
            txCausa.Text = Libreria.LowCaseName(dtDatosTraspasos.Rows(0).Item(5))
            txCuentaAnexa.Text = Trim(dtDatosTraspasos.Rows(0).Item(9)) + "-" + Trim(dtDatosTraspasos.Rows(0).Item(10))
            ms_SufijoOrigen = Trim(dtDatosTraspasos.Rows(0).Item(7))
            ms_AgOrigen = Trim(dtDatosTraspasos.Rows(0).Item(8))
            ms_CtaOrigen = Trim(dtDatosTraspasos.Rows(0).Item(2))
            ms_CtaDestino = Trim(dtDatosTraspasos.Rows(0).Item(10))
            ms_SufijoDestino = Trim(dtDatosTraspasos.Rows(0).Item(11))
            ms_AgDestino = Trim(dtDatosTraspasos.Rows(0).Item(12))
            If Val(dtDatosTraspasos.Rows(0).Item(6)) = 250 Then
                'Si la operación está cancelada
                MsgBox("La operación de Traspaso esta cancelada en Ticket, no es posible guardarla en GOS.", vbInformation, "Status de Operación")
                btAgregar.Enabled = False
                ' LimpiaCampos
                txTicket.Text = ""
                dtpFechaOperacion.Text = ""
                txTicket.Focus()
                BuscaTicket = False
                Exit Function
            Else
                btAgregar.Enabled = True
            End If
        End If

        If Trim(txCuenta.Text) = "" Then
            'Si no se encontró traspaso alguno con dicho ticket
            MsgBox("No se encontró ningún Traspaso con este número de Ticket.", vbInformation, "Traspaso")
            txTicket.Text = ""
            txTicket.Focus()
            BuscaTicket = False
        End If

    End Function


    Private Sub txTicket_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txTicket.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
        If txCuenta.Text <> "" And txTicket.TextLength = 7 Then
            LimpiaCampos()
            txTicket.Text = ""
            dtpFechaOperacion.Text = Date.Now.Date.ToString("dd-MM-yyyy")
            grbDocto.Visible = False
        End If
    End Sub
    Private Sub dtpFechaOperacion_Leave(sender As Object, e As EventArgs) Handles dtpFechaOperacion.Leave
        Dim ls_fechaoperacion As String
        ls_fechaoperacion = dtpFechaOperacion.Text
    End Sub
    Private Sub dtpFechaOperacion_CloseUp(sender As Object, e As EventArgs) Handles dtpFechaOperacion.CloseUp
        Dim ls_fechaoperacion As String
        ls_fechaoperacion = dtpFechaOperacion.Text
        If txCuenta.Text = "" Then
            If txTicket.Text = "" Then
                MsgBox("No se ha capturado el Número de Ticket, no puede realizarse la búsqueda de la Información", vbInformation, Me.Text)
                txTicket.Focus()
            Else
                LimpiaCampos()
                BuscaTicket(txTicket.Text, False)
            End If
        End If
    End Sub

    Sub LimpiaCampos()
        btAgregar.Enabled = False
        'Si es limpieza general de campos
        LimpiaCamposGrp(Me.grbDatos)
        LimpiaCamposGrp(Me.grbDocto)
    End Sub
    Sub LimpiaCamposGrp(ByVal sNomcontrol As GroupBox)
        Dim lo_Control As Control
        'Recorremos todos los controles del formulario que enviamos  
        For Each lo_Control In sNomcontrol.Controls
            'Filtramos solo aquellos de tipo TextBox 
            If TypeOf lo_Control Is TextBox Then
                If lo_Control.Name <> "txTicket" Then
                    lo_Control.Text = "" ' eliminar el texto  
                End If
            End If
        Next
    End Sub

    Private Sub txTicket_Leave(sender As Object, e As EventArgs) Handles txTicket.Leave

        If txTicket.Text <> "" Then
            If IsNumeric(Trim(txTicket.Text)) Then
                Format(txTicket.Text, "0000000")
            Else
                MsgBox("El número de Ticket debe ser numérico.", vbInformation, "Mensaje")
                txTicket.Text = ""
                txTicket.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btCerrar_MouseEnter(sender As Object, e As EventArgs) Handles btCerrar.MouseEnter
        mb_Salir = True
    End Sub


End Class