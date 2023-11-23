Public Class frmCancelaTicket
    Private mnOpDefinida As Long
    Private mbCancelaTicket As Boolean
    Private msOperDefGlobal As String
    Private objDatasource As New Datasource
    Private bError As Boolean
    Private Sub frmCancelaTicket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CargarColores Me, cambio
        'cambiarLabels lblMonto
        'cambiarLabels lblCtaCte
        'cambiarLabels LblFechaCaptura
        'cambiarLabels LblFechaOperacion
        'lblDescripcion.FontBold = True
        'Centerform Me
        GsPermisoAgencia = 1
        msOperDefGlobal = "(60,65,80,81,83,85,86,87,88,89,91,96,94,95,97,560,580,583,584,585,588,589,590,591,592,595)"
    End Sub
    Private Sub txtTicket_LostFocus(sender As Object, e As EventArgs) Handles txtTicket.LostFocus
        Dim lnStatusOperacion As Long
        Dim dtRespConsulta As DataTable
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        cmdCancelar.Enabled = False
        txtComentario.Enabled = False
        If Trim(txtTicket.Text) = "" Then Exit Sub
        If Not IsNumeric(Trim(txtTicket.Text)) Then
            MsgBox("El número de Ticket debe ser numérico.", vbInformation, "Aviso")
            txtTicket.Text = ""
            txtTicket.Focus()
            Exit Sub
        End If
        gs_Sql = "Select "
        gs_Sql = gs_Sql & " status_operacion, "                        '0
        gs_Sql = gs_Sql & " descripcion_operacion_definida, "          '1
        gs_Sql = gs_Sql & " operacion_definida_global, "               '2
        gs_Sql = gs_Sql & " prefijo_agencia+'-'+cuenta_cliente, "      '3
        gs_Sql = gs_Sql & " monto_operacion, "                         '4
        gs_Sql = gs_Sql & " convert(char(10),fecha_operacion,105), "   '5
        gs_Sql = gs_Sql & " convert(char(10),fecha_captura,105) "      '6
        gs_Sql = gs_Sql & " From "
        gs_Sql = gs_Sql & " TICKET..OPERACION OP, "
        gs_Sql = gs_Sql & " TICKET..OPERACION_DEFINIDA OD, "
        gs_Sql = gs_Sql & " TICKET..PRODUCTO_CONTRATADO PC,"
        gs_Sql = gs_Sql & " CATALOGOS" & ".dbo.AGENCIA AG "
        gs_Sql = gs_Sql & " Where "
        gs_Sql = gs_Sql & " status_operacion in (2,3,4,5,250) "
        gs_Sql = gs_Sql & " and PC.producto_contratado = OP.producto_contratado "
        gs_Sql = gs_Sql & " and OD.operacion_definida = OP.operacion_definida "
        gs_Sql = gs_Sql & " and AG.agencia = PC.agencia "
        gs_Sql = gs_Sql & " and AG.agencia = OD.agencia "
        gs_Sql = gs_Sql & " and OD.operacion_definida_global in " & msOperDefGlobal
        gs_Sql = gs_Sql & " and OP.operacion = " & Trim(txtTicket.Text)
        gs_Sql = gs_Sql & " and PC.agencia = " & GsPermisoAgencia    'Permiso Agencias
        'dbExecQuery gs_Sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'If Not IsdbError Then    
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'Si ocurrio algun error o no encontro ninguna operación...
            lnStatusOperacion = Val(dtRespConsulta.Rows(0).Item(0))
            lblDescripcion.Text = Trim(dtRespConsulta.Rows(0).Item(1))
            mnOpDefinida = Val(dtRespConsulta.Rows(0).Item(2))                         'Obtiene el numero de operacion definida
            lblCtaCte.Text = Trim(dtRespConsulta.Rows(0).Item(3))
            lblMonto.Text = "$" & Format(dtRespConsulta.Rows(0).Item(4), "#0.00") '"$" & Format(Trim(dtRespConsulta.Rows(0).Item(4)), "#,###,###,###,##0.00")
            LblFechaCaptura.Text = Trim(dtRespConsulta.Rows(0).Item(6))
            LblFechaOperacion.Text = Trim(dtRespConsulta.Rows(0).Item(5))
        Else                                                        'Si se encontro el número de operación indicado...
            'dbEndQuery
            MsgBox("No se encontro ninguna operación con el No. de Ticket " & Trim(txtTicket.Text) & ", " & Chr(13) & "o el status de la operación no es válido para cancelar.", vbInformation, "Cancelación")
            Exit Sub
        End If
        'dbEndQuery
        'Si se trata de Time Deposit, no se puede cancelar
        If mnOpDefinida = 80 Then
            MsgBox("No es posible cancelar la operación " & Trim(txtTicket.Text) & " porque es un Time Deposit.", vbInformation, "Cancelación")
            txtTicket.Focus()
            Limpiar()
            Exit Sub
        End If
        Select Case lnStatusOperacion
            Case 3              'Si la operación ha sido enviada a eq. por la interfaz
                MsgBox("La operación " & Trim(txtTicket.Text) & " ya fue enviada a Kapiti.", vbInformation, "Aviso")
            Case 4              'Si la operación se encuentra val en tkt y en eq.
                MsgBox("La operación " & Trim(txtTicket.Text) & " ya fue enviada y recibida en Kapiti.", vbInformation, "Aviso")
            Case 5              'Si la operación se encuentra val en tkt y no val en eq.
                MsgBox("La operación " & Trim(txtTicket.Text) & " ya fue enviada y rechazada en Kapiti.", vbInformation, "Aviso")
            Case 250            'Si la operación se encuentra cancelada
                MsgBox("La operación " & Trim(txtTicket.Text) & " ya esta cancelada.", vbInformation, "Aviso")
                Limpiar()
                txtTicket.Focus()
                Exit Sub
        End Select
        cmdCancelar.Enabled = True
        txtComentario.Enabled = True
        txtComentario.Focus()
    End Sub

    Private Sub cmdLimpia_Click(sender As Object, e As EventArgs) Handles cmdLimpia.Click
        Limpiar()
    End Sub
    Private Sub Limpiar()
        txtTicket.Text = ""
        lblDescripcion.Text = ""
        lblCtaCte.Text = ""
        lblMonto.Text = ""
        LblFechaCaptura.Text = ""
        LblFechaOperacion.Text = ""
        If txtComentario.Enabled Then
            txtComentario.Text = ""
        End If
        txtComentario.Enabled = False
        cmdCancelar.Enabled = False
    End Sub
    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Dim lnOperacionDep As Long
        Dim Cadena, Caracter, Pos
        Dim dtRespConsulta As DataTable
        'Se valida que no existan "saltos de linea" en la cadena a guardar PHILGMS1 20080729
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        Caracter = Chr(13)
        Cadena = txtComentario.Text
        Pos = InStr(1, Cadena, Caracter, 1)
        If Pos > 0 Then
            txtComentario.Text = Mid(Cadena, 1, Pos - 1)
        Else
            txtComentario.Text = Cadena
        End If

        If Trim(txtComentario.Text) = "" Then
            MsgBox("Es necesario el comentario de la Cancelación del Ticket.", vbInformation, "Aviso")
            txtComentario.Text = ""
            txtComentario.Focus()
            Exit Sub
        End If
        If MsgBox("¿Esta seguro de cancelar la operación " & Trim(txtTicket.Text) & "?", vbQuestion + vbYesNo, "Cancelación") = vbYes Then
            'Si es Traspaso, se busca la operación de depósito para cancelarla también
            If (mnOpDefinida = 87) Or (mnOpDefinida = 97) Then
                gs_Sql = "Select "
                gs_Sql = gs_Sql & " operacion_deposito "
                gs_Sql = gs_Sql & " From "
                gs_Sql = gs_Sql & " TRASPASO "
                gs_Sql = gs_Sql & " Where "
                gs_Sql = gs_Sql & " operacion = " & Trim(txtTicket.Text)
                'dbExecQuery gs_Sql
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                'If Not IsdbError Then
                If dtRespConsulta Is Nothing Or dtRespConsulta.Rows.Count = 0 Then
                    lnOperacionDep = Val(dtRespConsulta.Rows(0).Item(0))
                Else
                    'dbEndQuery
                    MsgBox("Ocurrio un error al buscar la operación de depósito por traspaso.", vbCritical, "Aviso")
                    txtTicket.Focus()
                    Limpiar()
                    Exit Sub
                End If
                'dbEndQuery
            End If

            'Inicia Transacción
            'dbBeginTran
            objDatasource.IniciaTransaccion()
            CancelaTicket(Trim(txtTicket.Text))
            If ((mnOpDefinida = 87) Or (mnOpDefinida = 97)) And (mbCancelaTicket = True) Then
                CancelaTicket(lnOperacionDep)
            End If
            If Not mbCancelaTicket Then
                'dbRollback
                objDatasource.RollbackTransaccion()
                MsgBox("Ocurrio un error al intentar Cancelar la operación.", vbCritical, "Aviso")
                txtTicket.Focus()
                Limpiar()
                Exit Sub
            End If
            'dbCommit
            objDatasource.CommitTransaccion()
            If (mnOpDefinida = 87) Or (mnOpDefinida = 97) Then
                MsgBox("Las operaciones " & Trim(txtTicket.Text) & " '" & lblDescripcion.Text & "' " & Chr(13) & " y " & lnOperacionDep & " '" & dtRespConsulta.Rows(0).Item(0) & "' han sido canceladas.", vbInformation, "Cancelación")
            Else
                MsgBox("La operación " & Trim(txtTicket.Text) & ": '" & lblDescripcion.Text & "' ha sido cancelada.", vbInformation, "Aviso")
            End If
            cmdCancelar.Enabled = False
            txtTicket.Focus()
            Limpiar()
        End If
    End Sub
    Private Sub CancelaTicket(nOperacion As Long)
        mbCancelaTicket = False
        'Se modifica el status de la operación a "Cancelada"
        gs_Sql = "Update OPERACION "
        gs_Sql = gs_Sql & "Set status_operacion = 250 "
        gs_Sql = gs_Sql & "Where operacion = " & nOperacion
        'dbExecQuery gs_Sql
        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then ' 'If dbError Then
            'dbEndQuery
            Exit Sub
        End If
        'dbEndQuery
        'Se inserta el evento de Cancelación
        Dim dtRespConsulta = objDatasource.RealizaConsulta("SELECT convert(char(5),getdate(),14)")
        Dim drRegistro = dtRespConsulta.Rows(0)
        gs_HoraSistema = drRegistro.Item(0).ToString
        gs_Sql = "Insert into EVENTO_OPERACION "
        gs_Sql = gs_Sql & "(operacion, fecha_evento, "
        gs_Sql = gs_Sql & " status_operacion, comentario_evento, usuario) "
        gs_Sql = gs_Sql & " values "
        gs_Sql = gs_Sql & " ( " & nOperacion & ", '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & " " & gs_HoraSistema & "', "
        gs_Sql = gs_Sql & " 250, '"
        If StrComp(Trim(txtComentario.Text), "", vbTextCompare) <> 0 Then
            gs_Sql = gs_Sql & Trim(txtComentario.Text) & "', " & userId & ")"
        Else
            gs_Sql = gs_Sql & nOperacion & "', " & userId & ")"
        End If
        'dbExecQuery gs_Sql
        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then ''If dbError Then
            'dbEndQuery
            Exit Sub
        End If
        'dbEndQuery
        mbCancelaTicket = True
    End Sub
    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir de Cancelación de Operaciones Validadas") <> vbYes Then
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub
End Class