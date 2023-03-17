Public Class frmRepOperNOValidadas
    Dim tag0 As String
    Dim tag1 As String
    Dim tag2 As String
    Dim tag3 As String
    Dim iRegistros As Integer

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    Private Sub frmRepOperNOValidadas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        'carga valores inicales
        txtFecha.Text = Date.Now().Date.ToString("yyyy-MM-dd")
        'activa chk de reporte equation
        chkTipoRep0.Checked = False
        cmdConsultar.Enabled = False
        cmdImprimir.Enabled = False
    End Sub

    Private Sub chkOperacion0_CheckedChanged(sender As Object, e As EventArgs) Handles chkOperacion0.CheckedChanged
        If chkOperacion0.Checked = True Then
            tag0 = "89, 65, 88, 83, 54, 56, 57, 87, 52, 53, 589, 591, 592, 590, 583, 588, 553, 552, 587, 597"
        Else
            tag0 = ""
        End If
        chkTipoRep0_CheckedChanged(sender, e)
    End Sub

    Private Sub chkOperacion1_CheckedChanged(sender As Object, e As EventArgs) Handles chkOperacion1.CheckedChanged
        If chkOperacion1.Checked = True Then
            tag1 = "80, 180"
        Else
            tag1 = ""
        End If
        chkTipoRep0_CheckedChanged(sender, e)
    End Sub

    Private Sub chkOperacion2_CheckedChanged(sender As Object, e As EventArgs) Handles chkOperacion2.CheckedChanged
        If chkOperacion2.Checked = True Then
            tag2 = "81"
        Else
            tag2 = ""
        End If
        chkTipoRep0_CheckedChanged(sender, e)
    End Sub

    Private Sub chkOperacion3_CheckedChanged(sender As Object, e As EventArgs) Handles chkOperacion3.CheckedChanged
        If chkOperacion3.Checked = True Then
            tag3 = "86"
        Else
            tag3 = ""
        End If
        chkTipoRep0_CheckedChanged(sender, e)
    End Sub

    Private Sub chkTipoRep0_CheckedChanged(sender As Object, e As EventArgs) Handles chkTipoRep0.CheckedChanged
        If chkTipoRep0.Checked = True Then
            If HabilitaConsulta() Then
                cmdConsultar.Enabled = True
            Else
                If chkTipoRep1.Checked = False Then
                    cmdConsultar.Enabled = False
                End If
            End If
        Else
            If chkTipoRep1.Checked = False Then
                cmdConsultar.Enabled = False
            End If
        End If
    End Sub

    Private Sub chkTipoRep1_CheckedChanged(sender As Object, e As EventArgs) Handles chkTipoRep1.CheckedChanged
        If chkTipoRep1.Checked = True Then
            If HabilitaConsulta() Then
                cmdConsultar.Enabled = True
            Else
                If chkTipoRep0.Checked = False Then
                    cmdConsultar.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub cmdConsultar_Click(sender As Object, e As EventArgs) Handles cmdConsultar.Click
        Dim lsOperDefinidas As String
        Dim Ls_Sel As String
        Dim Ls_Selcount As String
        Dim Ls_Selselect As String
        Dim Ls_Selorder As String

        Cursor = System.Windows.Forms.Cursors.WaitCursor

        'realiza la extracción de la información
        'arma concatenado de operaciones definidas
        'lsOperDefinidas = tag0 + "," + tag1 + "," + tag2 + "," + tag3
        If tag0.ToString.Trim <> "" Then
            lsOperDefinidas = tag0
        End If
        If tag1.ToString.Trim <> "" Then
            If lsOperDefinidas.ToString.Trim = "" Then
                lsOperDefinidas = tag1
            Else
                lsOperDefinidas &= "," + tag1
            End If
        End If
        If tag2.ToString.Trim <> "" Then
            If lsOperDefinidas.ToString.Trim = "" Then
                lsOperDefinidas = tag2
            Else
                lsOperDefinidas &= "," + tag2
            End If
        End If
        If tag3.ToString.Trim <> "" Then
            If lsOperDefinidas.ToString.Trim = "" Then
                lsOperDefinidas = tag3
            Else
                lsOperDefinidas &= "," + tag3
            End If
        End If

        ls_PorImprimir = ""

        If lsOperDefinidas.ToString.Trim = "" Then
            Cursor = System.Windows.Forms.Cursors.Default
            MsgBox("Debe de eligir al menos un tipo de operación para imprimir", MsgBoxStyle.Information, "Seleccione un Tipo de operación")
            Exit Sub
        End If
        'arma el select
        Ls_Selcount = "SELECT  count(*) "

        Ls_Selselect = "SELECT   OPERACION.operacion, "
        Ls_Selselect &= "  OPERACION.monto_operacion, "
        Ls_Selselect &= "  PRODUCTO_CONTRATADO.cuenta_cliente, "
        Ls_Selselect &= "  OPERACION_DEFINIDA.descripcion_operacion_definida, "
        Ls_Selselect &= "  STATUS_OPERACION.descripcion_status, "
        Ls_Selselect &= "  AGENCIA.descripcion_agencia "

        Ls_Sel = " FROM  TICKET.dbo.OPERACION OPERACION "
        Ls_Sel &= "  INNER JOIN TICKET.dbo.OPERACION_DEFINIDA OPERACION_DEFINIDA "
        Ls_Sel &= "  ON OPERACION.operacion_definida = OPERACION_DEFINIDA.operacion_definida "
        Ls_Sel &= "  INNER JOIN TICKET.dbo.STATUS_OPERACION STATUS_OPERACION "
        Ls_Sel &= "  ON OPERACION.status_operacion = STATUS_OPERACION.status_operacion "
        Ls_Sel &= "  INNER JOIN TICKET.dbo.PRODUCTO_CONTRATADO PRODUCTO_CONTRATADO "
        Ls_Sel &= "  ON OPERACION.producto_contratado = PRODUCTO_CONTRATADO.producto_contratado "
        Ls_Sel &= "  INNER JOIN CATALOGOS.dbo.AGENCIA AGENCIA "
        Ls_Sel &= "  ON PRODUCTO_CONTRATADO.agencia = AGENCIA.agencia"

        ls_PorImprimir = Ls_Selselect
        ls_PorImprimir &= Ls_Sel

        Ls_Sel &= " WHERE OPERACION.status_operacion IN (0,1,220) AND "
        Ls_Sel &= "      OPERACION_DEFINIDA.operacion_definida_global IN (" & lsOperDefinidas & ") AND "
        Ls_Sel &= "      PRODUCTO_CONTRATADO.agencia = 1 AND "
        Ls_Sel &= "     OPERACION.fecha_operacion = ('" & txtFecha.Text & "')  "
        Ls_Selorder = " ORDER BY OPERACION.operacion ASC "

        'ls_PorImprimir = Ls_Selselect
        'ls_PorImprimir &= Ls_Sel
        'ls_PorImprimir &= Ls_Selorder

        ls_PorImprimir = " {OPERACION.status_operacion} IN [0,1,220] "
        ls_PorImprimir &= " AND {OPERACION_DEFINIDA.operacion_definida_global} In [" & lsOperDefinidas & "] "
        ls_PorImprimir &= " AND {PRODUCTO_CONTRATADO.agencia} = 1 "
        'ls_PorImprimir &= " AND {AGENCIA.agencia} = 1 )"
        ls_PorImprimir &= " AND {OPERACION.fecha_operacion} = DateTime(" & txtFecha.Text.Substring(0, 4) & "," & txtFecha.Text.Substring(5, 2) & "," & txtFecha.Text.Substring(8, 2) & ") "
        'ls_PorImprimir &= " and OPERACION.fecha_operacion = (2020,05,26) "
        'ls_PorImprimir &= " and {OPERACION.fecha_operacion} = DateTime(2020, 06, 19) "

        'inicializa el grid
        dgvOperacionesNOValidadas.DataSource = ""

        'rEALIZA LA CONSULTA
        If LlenaGridOperacionesNOValidadas(Ls_Sel, Ls_Selcount, Ls_Selselect, Ls_Selorder) Then
            cmdImprimir.Enabled = True
            dgvOperacionesNOValidadas.Columns("monto_operacion").DefaultCellStyle.Format = "N2" '-----RACB 04/03/2021
        End If
        Cursor = System.Windows.Forms.Cursors.Default
        cmdImprimir.Enabled = True

    End Sub


    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click

        'realiza la extracción de la información
        opcionReporte = 6    'reporte de Operaciones NO validadas
        'ls_PorImprimir = "WHERE  OPERACION.fecha_operacion = '" & (Jan 8, 2001) & "'"
        fe_Inicio = txtFecha.Text

        'ls_PorImprimir = "Select AGENCIA.descripcion_agencia,  OPERACION.operacion, STATUS_OPERACION.descripcion_status , "
        'ls_PorImprimir &= " OPERACION.monto_operacion, OPERACION_DEFINIDA.descripcion_operacion_definida, PRODUCTO_CONTRATADO.cuenta_cliente "
        'ls_PorImprimir &= " FROM(((Ticket.dbo.OPERACION   OPERACION  "
        'ls_PorImprimir &= " INNER Join  TICKET. dbo.PRODUCTO_CONTRATADO  PRODUCTO_CONTRATADO  ON  OPERACION.producto_contratado = PRODUCTO_CONTRATADO.producto_contratado ) "
        'ls_PorImprimir &= " INNER Join  TICKET. dbo.OPERACION_DEFINIDA  OPERACION_DEFINIDA  On ( OPERACION.operacion_definida = OPERACION_DEFINIDA.operacion_definida ) "
        'ls_PorImprimir &= " And (PRODUCTO_CONTRATADO.agencia = OPERACION_DEFINIDA.agencia)) "
        'ls_PorImprimir &= " INNER Join  TICKET.dbo.STATUS_OPERACION  STATUS_OPERACION  On  OPERACION.status_operacion = STATUS_OPERACION.status_operacion ) "
        'ls_PorImprimir &= " INNER Join  CATALOGOS.dbo.AGENCIA  AGENCIA  On  PRODUCTO_CONTRATADO.agencia = AGENCIA.agencia           "
        'ls_PorImprimir = " OPERACION.fecha_operacion = Date(" & txtFecha.Text.Substring(0, 4).Trim & "," & txtFecha.Text.Substring(5, 2).Trim & "," & txtFecha.Text.Substring(8, 2).Trim & ")"

        'ls_PorImprimir = " OPERACION.fecha_operacion = '" & txtFecha.Text & "'"

        'ls_PorImprimir = "{OPERACION.fecha_operacion}= Date(" & txtFecha.Text.Substring(0, 4).Trim & "," & txtFecha.Text.Substring(5, 2).Trim & "," & txtFecha.Text.Substring(8, 2).Trim & ")"
        RepOperativa.ShowDialog()

    End Sub

    Private Sub chkOperacion0_Click(sender As Object, e As EventArgs) Handles chkOperacion0.Click
        'If chkOperacion0.Checked = True Then
        '    tag0 = "89, 65, 88, 83, 54, 56, 57, 87, 52, 53, 589, 591, 592, 590, 583, 588, 553, 552, 587, 597"
        'Else
        '    tag0 = ""
        'End If
    End Sub

    Private Sub chkOperacion1_Click(sender As Object, e As EventArgs) Handles chkOperacion1.Click
        'If chkOperacion1.Checked = True Then
        '    tag1 = "80, 180"
        'Else
        '    tag1 = ""
        'End If
    End Sub

    Private Sub chkOperacion2_Click(sender As Object, e As EventArgs) Handles chkOperacion2.Click
        'If chkOperacion2.Checked = True Then
        '    tag2 = "81"
        'Else
        '    tag2 = ""
        'End If
    End Sub

    Private Sub chkOperacion3_Click(sender As Object, e As EventArgs) Handles chkOperacion3.Click
        'If chkOperacion3.Checked = True Then
        '    tag3 = "86"
        'Else
        '    tag3 = ""
        'End If
    End Sub

    Private Sub chkTipoRep0_Click(sender As Object, e As EventArgs) Handles chkTipoRep0.Click
        'If chkTipoRep0.Checked = True Then
        '    If HabilitaConsulta() Then
        '        cmdConsultar.Enabled = True
        '    Else
        '        If chkTipoRep1.Checked = False Then
        '            cmdConsultar.Enabled = False
        '        End If
        '    End If
        'End If
    End Sub


#Region "Funciones"
    Function HabilitaConsulta() As Boolean
        HabilitaConsulta = False

        'Revisa que se haya seleccionado un tipo re operacion
        If (chkOperacion0.Checked = False) And (chkOperacion1.Checked = False) And (chkOperacion2.Checked = False) And (chkOperacion3.Checked = False) Then
            MsgBox("Debe de eligir al menos un tipo de operación", MsgBoxStyle.Information, "Seleccione un Tipo de operación")
            Exit Function
        End If

        HabilitaConsulta = True
    End Function

    'Private Function CrearFecha() As String
    '    Dim ls_Fecha As String
    '    Select Case Month(txtFecha.Text)
    '        Case 1 : ls_Fecha = "Jan"
    '        Case 2 : ls_Fecha = "Feb"
    '        Case 3 : ls_Fecha = "Mar"
    '        Case 4 : ls_Fecha = "Apr"
    '        Case 5 : ls_Fecha = "May"
    '        Case 6 : ls_Fecha = "Jun"
    '        Case 7 : ls_Fecha = "Jul"
    '        Case 8 : ls_Fecha = "Aug"
    '        Case 9 : ls_Fecha = "Sep"
    '        Case 10 : ls_Fecha = "Oct"
    '        Case 11 : ls_Fecha = "Nov"
    '        Case 12 : ls_Fecha = "Dec"
    '    End Select
    '    ls_Fecha = ls_Fecha & " " & Day(txtFecha.Text)
    '    ls_Fecha = ls_Fecha & ", " & Year(txtFecha.Text)
    '    CrearFecha = ls_Fecha
    'End Function

    Function LlenaGridOperacionesNOValidadas(gs_sql As String, gs_sqlcount As String, gs_sqlselect As String, gs_sqlorder As String) As Boolean
        Dim d As New Datasource
        Dim dctas = New Datasource
        Dim gs_sql_completo As String

        LlenaGridOperacionesNOValidadas = False


        If buscaOperacionesNOValidadas(gs_sqlcount, gs_sql) Then
            'arma el query para presentar en el grid
            'buscamos si hubo registros en tabal de saldos SALDO_CTA_000
            gs_sql_completo = gs_sqlselect & " " & gs_sql & " " & gs_sqlorder
            dgvOperacionesNOValidadas.DataSource = dctas.RealizaConsulta(gs_sql_completo)

        Else
            LlenaGridOperacionesNOValidadas = False
            Exit Function
        End If
        cmdImprimir.Enabled = True
        LlenaGridOperacionesNOValidadas = True
    End Function


    Function buscaOperacionesNOValidadas(gs_sqlcount As String, gs_sql As String) As Boolean
        Dim d As New Datasource
        Dim dctas = New DataTable
        Dim gs_sql_completo As String

        iRegistros = 0

        buscaOperacionesNOValidadas = False

        gs_sql_completo = gs_sqlcount & " " & gs_sql

        'iRegistros = d.HayRegistros(gs_sql_completo)
        dctas = d.RealizaConsulta(gs_sql_completo)
        iRegistros = dctas.Rows(0).Item(0)

        If iRegistros > 0 Then
            buscaOperacionesNOValidadas = True
        Else
            MsgBox("No existen operaciones", MsgBoxStyle.Information, "Sin Operaciones NO Validadas")
            Exit Function
        End If


    End Function



#End Region

End Class