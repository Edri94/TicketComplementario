Imports System.Threading

Public Class frmRepAgencias
    Dim mn_Agencia As Byte
    Dim ms_Agencia As String
    Dim ms_FechaFuturo As String
    Dim mn_TipoRep As Byte
    Const OperDepRet = 0
    Dim objLibreria As New Libreria
    Dim objDatasource As New Datasource
    Private chkOperacionTag As String = ""
    Dim rptRepAgencias As New ReportDocument
    Dim lsAmbiente As String = ""
    Dim lsReporte As String = ""
    Dim lsRutaFolder As String = ""

    '**********************************************************
    'Autor:
    'Fec. Creación:
    'Autor ult. modif.: Ma. del Carmen Martínez León
    'Fec. ult. modif. : Feb, 2004
    'Procedimiento que cambia el aspecto de la forma, así como
    ' asigna el título correspondiente
    '**********************************************************
    Public Sub ReporteAgencias(ByVal Tipo As Byte)

        mn_TipoRep = Tipo

        Select Case mn_TipoRep
            Case 2 : Dimension(1, "Reporte de Operaciones Pendientes de Recibir")
            Case 3 : Dimension(1, "Reporte de Operaciones Pendientes de Enviar")
            Case 4 : Dimension(1, "Reporte de Operaciones Rechazadas")
            Case 5 : Dimension(0, "Reporte de Depósitos")
            Case 6 : Dimension(0, "Reporte de Retiros")
            Case 7 : Dimension(2, "Reporte de Operaciones Canceladas")
            Case 8 : Dimension(0, "Reporte de Detalle de Depósitos")
            Case 9 : Dimension(2, "Reporte de Operaciones No Validadas")
            Case 10 : Dimension(1, "Reporte de Operaciones Integradas en Saldos")
            Case 11 : Dimension(0, "Reporte de Movimientos de Retiro")
            Case 12 : Dimension(0, "Reporte de Movimientos de Depósito")
            Case 13 : Dimension(0, "Reporte de Error de Movimientos")
            Case 18 : Dimension(0, "Reporte de Ctas. No Aperturadas")
            Case 20 : Dimension(0, "Reporte de Detalle de Retiros")
        End Select

    End Sub
    '**********************************************************
    'Autor:
    'Fec. Creación:
    'Autor ult. modif.: Ma. del Carmen Martínez León
    'Fec. ult. modif. : Feb, 2004
    'Procedimiento que cambia el tamaño de la forma
    '**********************************************************
    Private Sub Dimension(Tipo As Byte, Ls_Titulo As String)

        'If Tipo = 0 Then 'Normal
        'SSPanel1.Height = 615
        'Me.Height = 3045
        'cmdAceptar.Top = 2190
        'cmdSalir.Top = 2190
        'ElseIf Tipo = 1 Then 'Opciones
        'SSPanel1.Height = 2655
        'Me.Height = 5145
        'cmdAceptar.Top = 4320
        'cmdSalir.Top = 4320
        'ElseIf Tipo = 2 Then
        'SSPanel1.Height = 1855
        'Me.Height = 4305
        'cmdAceptar.Top = 3480
        'cmdSalir.Top = 3480
        'End If
        If Tipo = 0 Then
            Me.Size = New Size(318, 230)
            SSPanel1.Size = New Size(278, 90)
            cmdAceptar.Location = New Point(15, 140)
            cmdSalir.Location = New Point(155, 140)
            chkOperacion1.Visible = False
            chkOperacion2.Visible = False
            chkOperacion3.Visible = False
            chkOperacion4.Visible = False
            fraRep.Visible = False
        End If

        'frmRepAgencias.Caption = Ls_Titulo
        Me.Text = Ls_Titulo
        'rptRepAgencias.WindowTitle = frmRepAgencias.Caption
        Me.Show()

    End Sub

    Private Sub frmRepAgencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtRespConsulta As DataTable
        '     Screen.MousePointer = vbHourglass
        '     CargarColores Me, cambio
        'Centerform Me
        If Thread.CurrentThread.CurrentCulture.Name = "en-US" Then
            dtpFecha.CustomFormat = "MM-dd-yyyy"
        ElseIf Thread.CurrentThread.CurrentCulture.Name = "es-MX" Then
            dtpFecha.CustomFormat = "dd-MM-yyyy"
        End If
        gs_Sql = "SELECT agencia, descripcion_agencia "
        gs_Sql = gs_Sql & " FROM " & "CATALOGOS.dbo.AGENCIA "
        gs_Sql = gs_Sql & " WHERE agencia = " & "1"
        gs_Sql = gs_Sql & " ORDER BY agencia"
        'dbExecQuery(gs_Sql)
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'Do While Not IsdbError
        '    lstAgencia.AddItem(dbGetValue(1))
        '    lstAgencia.ItemData(lstAgencia.NewIndex) = dbGetValue(0)
        '    dbGetRecord
        'Loop
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
            For Each row As DataRow In dtRespConsulta.Rows
                lstAgencia.Items.Add(row.Item(1))
            Next
        End If

        ''MCML. Por default coloca que deben imprimirse reportes de Equation
        'chkTipoRep(0).Value = -1
        chkTipoRep1.Checked = True
        'dbEndQuery
        'txtFecha = FechaOpera(InvierteFecha(gs_FechaHoy))
        ms_FechaFuturo = DateAdd("d", 1, dtpFecha.Value)
        'Screen.MousePointer = vbDefault
    End Sub
    Private Sub ConfOpcion(Index As Integer)
        'If chkOperacion(Index).Value = vbUnchecked Then
        '    chkOperacion(Index).tag = ""
        'ElseIf chkOperacion(Index).Value = vbChecked Then
        Select Case Index
            Case 0 'Depositos y Retiros [IDS-IFC Se incluyeron las operaciones (deposito y retiro) definidas para TDD]
                'chkOperacion(Index).tag = "89, 65, 88, 83, 54, 56, 57, 87, 52, 53, 589, 591, 592, 590, 583, 588, 553, 552, 587, 597"
                chkOperacionTag = "89, 65, 88, 83, 54, 56, 57, 87, 52, 53, 589, 591, 592, 590, 583, 588, 553, 552, 587, 597"
            Case 1 'Retiro por compra de TDs
                'chkOperacion(Index).tag = "80, 180" 'ALB Agrega operaciones TD's OVN
                chkOperacionTag = "80, 180" 'ALB Agrega operaciones TD's OVN
            Case 2 'Retiro por Orden de Pago
                'chkOperacion(Index).tag = "81"
                chkOperacionTag = "81"
            Case 3 'Retiro por Orden de Pago otras Divisas
                'chkOperacion(Index).tag = "86"
                chkOperacionTag = "86"
        End Select
        'End If
        HabilitarImprimir()
    End Sub
    '*************************************************************
    'Autor:             Ma. del Carmen Martínez León
    'Fec. Creación:     Ene, 2004
    'Autor ult. modif.: Ma. del Carmen Martínez León
    'Fec. ult. modif. : Feb, 2004
    'Procedimiento que habilita o deshabilita el botón de Imprimir
    '*************************************************************
    Private Sub HabilitarImprimir()

        Dim Lb_ChkOper As Boolean, Lb_LstAgencia As Boolean, Lb_ChkRep As Boolean
        Dim Li_Cont As Integer

        '' MCML. Sólo se habilitará o deshabilitará el botón Imprimir si son Operaciones:
        '' Pend. a Recibir (2) / Pend. a Enviar (3) / Rechazadas (4) /
        '' Canceladas (7) / No Validadas (9) / Int. en Saldos (10)
        '' y estan activadas todas las opciones requeridas para realizar la consulta
        If (mn_TipoRep = 2 Or mn_TipoRep = 3 Or mn_TipoRep = 4 Or mn_TipoRep = 7 Or mn_TipoRep = 9 Or mn_TipoRep = 10) Then

            ''MCML. Verifica si seleccionó alguna Operación
            Lb_ChkOper = False
            For Li_Cont = 0 To 3
                'If chkOperacion(Li_Cont).Value = 1 Then Lb_ChkOper = True
                If chkOperacion1.Checked = True Or chkOperacion2.Checked = True Or chkOperacion3.Checked = True Or chkOperacion4.Checked = True Then Lb_ChkOper = True
            Next Li_Cont

            ''MCML. Verifica si seleccionó alguna Agencia
            Lb_LstAgencia = False
            'For Li_Cont = 0 To lstAgencia.ListCount - 1
            '    If lstAgencia.Selected(Li_Cont) = True Then Lb_LstAgencia = True
            'Next Li_Cont
            If lstAgencia.SelectedIndex > -1 Then
                Lb_LstAgencia = True
            End If

            ''MCML. Verifica si seleccionó algún Tipo de Reporte
            Lb_ChkRep = False
            For Li_Cont = 0 To 1
                'If chkTipoRep(Li_Cont).Value = -1 Then Lb_ChkRep = True
                If chkTipoRep1.Checked = True Or chkTipoRep2.Checked = True Then Lb_ChkRep = True
            Next Li_Cont

            If Lb_ChkOper = True And Lb_LstAgencia = True And Lb_ChkRep = True Then
                cmdAceptar.Enabled = True
            Else
                cmdAceptar.Enabled = False
            End If
        End If

    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir del reporte") <> vbYes Then
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        On Error GoTo ErrHdlr
        mn_Agencia = lstAgencia.SelectedIndex + 1
        'Screen.MousePointer = vbHourglass
        Select Case mn_TipoRep
            'Case 2 : RepOpPendRec()      ''MCLM. Operaciones Pendientes a Recibir Equation
                'RepOpPendRecSwift ''MCLM. Operaciones Pendientes a Recibir SWIFT
            Case 3  'RepOpPendEnv      ''MCLM. Operaciones Pendientes a Enviar Equation
                'RepOpPendEnvSwift ''MCLM. Operaciones Pendientes a Enviar SWIFT
            Case 4  'RepOpRech         ''MCLM. Operaciones Rechazadas Equation
                'RepOpRechSwift    ''MCLM. Operaciones Rechazadas SWIFT
            Case 5  'RepOpDeposito
            Case 6  'RepOpRetiro
            Case 7  'RepOpCanceladas   ''MCLM. Operaciones Canceladas
            Case 8 : RepDetDep()
            Case 9  'RepOpNoVal        ''MCLM. Operaciones No Validadas
            Case 10 : RepOpIntSaldos()    ''MCLM. Operaciones Integradas en Saldos Equation
                RepOpIntSaldosSwift() ''MCLM. Operaciones Integradas en Saldos SWIFT
            Case 11  'RepMovRet
            Case 12  'RepMovDep
            Case 13  'RepMovErr
            Case 18  'RepCtasNoAp
            Case 20 : RepDetRet()
        End Select

        Select Case mn_TipoRep
            Case 5 To 9, 11 To 20
                'MuestraVentanaReporte(rptRepAgencias)
                cmdSalir.Enabled = True
        End Select

        'Screen.MousePointer = vbDefault
        Exit Sub

ErrHdlr:
        'Screen.MousePointer = vbDefault
        If Err.Number <> 0 Then
            If Err.Number = vbObjectError + 101 Then
                MsgBox(Err.Description, vbExclamation, "Back Agencias")
                'chkOperacion(0).SetFocus
            Else
                MsgBox("Error [" & Err.Number & "] " & Err.Description, vbExclamation, "Back Agencias")
            End If
        End If
    End Sub
    '**********************************************************
    'Autor:
    'Fec. Creación:
    'Autor ult. modif.: Ma. del Carmen Martínez León
    'Fec. ult. modif. : Feb, 2004
    'Reporte de Operaciones Pendiente de Recibir
    'Modificación: BAGO-EDS-07/MZO/06. Cambio de la constante "DESARROLLO" por la variable "DBDESARROLLO" y de la constante
    '              "CATALOGOS" por la variable "DBCATALOGOS"
    '**********************************************************
    'Private Sub RepOpPendRec()
    '    Dim Ls_Operaciones As String, Ls_Sel As String
    '    ''Si está activado el Tipo de Reporte Equation, realiza la consulta
    '    'If chkTipoRep(0).Value = -1 And chkTipoRep(0).Enabled = True Then
    '    If chkTipoRep1.Checked = True Then
    '        ''Determina las Operaciones Definidas Globales a consultar
    '        Ls_Operaciones = OperacionesDefinidas

    '        If Ls_Operaciones = "" Then
    '            Err.Raise(vbObjectError + 101, "RepOpPendRec", "Debe de seleccionar una opción como mínimo para imprimir")
    '        Else
    '            Ls_Sel =
    '        " SELECT   OPERACION.operacion, OPERACION.monto_operacion, " & vbCrLf &
    '        "     AGENCIA.descripcion_agencia, " & vbCrLf &
    '        "     CLIENTE.cuenta_cliente, " & vbCrLf &
    '        "     CLIENTE.nombre_cliente, " & vbCrLf &
    '        "     CLIENTE.apellido_paterno, " & vbCrLf &
    '        "     CLIENTE.apellido_materno " & vbCrLf &
    '        "FROM " & "TICKET.dbo.OPERACION OPERACION " & vbCrLf &
    '        "     INNER JOIN " & "TICKET.dbo.OPERACION_DEFINIDA OPERACION_DEFINIDA " & vbCrLf &
    '        "     ON OPERACION.operacion_definida = OPERACION_DEFINIDA.operacion_definida " & vbCrLf &
    '        "     INNER JOIN " & "TICKET.dbo.PRODUCTO_CONTRATADO PRODUCTO_CONTRATADO " & vbCrLf &
    '        "     ON OPERACION.producto_contratado = PRODUCTO_CONTRATADO.producto_contratado " & vbCrLf &
    '        "     INNER JOIN " & "CATALOGOS.dbo.AGENCIA AGENCIA " & vbCrLf &
    '        "     ON PRODUCTO_CONTRATADO.agencia = AGENCIA.agencia " & vbCrLf &
    '        "     INNER JOIN " & "TICKET.dbo.CUENTA_EJE CUENTA_EJE " & vbCrLf &
    '        "     ON PRODUCTO_CONTRATADO.producto_contratado = CUENTA_EJE.producto_contratado " & vbCrLf &
    '        "     INNER JOIN " & "CATALOGOS.dbo.CLIENTE CLIENTE " & vbCrLf &
    '        "     ON PRODUCTO_CONTRATADO.cuenta_cliente = CLIENTE.cuenta_cliente AND " & vbCrLf &
    '        "     PRODUCTO_CONTRATADO.agencia = CLIENTE.agencia " & vbCrLf &
    '        "     INNER JOIN " & "TICKET.dbo.TIPO_CUENTA_EJE TIPO_CUENTA_EJE " & vbCrLf &
    '        "     ON CUENTA_EJE.tipo_cuenta_eje = TIPO_CUENTA_EJE.tipo_cuenta_eje " & vbCrLf
    '            Ls_Sel = Ls_Sel &
    '        "WHERE OPERACION_DEFINIDA.operacion_definida_global IN (" &
    '                 Ls_Operaciones & ") AND " & vbCrLf &
    '        "     OPERACION.status_operacion = 3 AND " & vbCrLf &
    '        "     PRODUCTO_CONTRATADO.agencia = " & mn_Agencia & " AND " & vbCrLf &
    '        "     OPERACION.fecha_operacion = ('" & CrearFecha() & "')  " & vbCrLf &
    '        "ORDER BY OPERACION.operacion"
    '            With rptRepAgencias
    '                '.ReportFileName = GPATH & "\ope_penR_Agen.rpt"
    '                rptRepAgencias = New ope_penR_Agen
    '                rptRepAgencias.SQLQuery = Ls_Sel
    '                rptRepAgencias.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & objLibreria.InvierteFecha(gs_FechaHoy) & "'"
    '                rptRepAgencias.DataDefinition.FormulaFields.Item("Hora").Text = "'" & gs_HoraSistema & "'"
    '                rptRepAgencias.DataDefinition.FormulaFields.Item("FechaOp").Text = "'Fecha de Operación: " & Trim(dtpFecha.Text) & "'"
    '            End With
    '            'MuestraVentanaReporte rptRepAgencias
    '            opcionReporte = 16    'reporte de Mantenimientos
    '            RepOperativa.reporteOFAC = rptRepAgencias
    '            RepOperativa.ShowDialog()
    '        End If
    '    End If
    'End Sub
    Private Function OperacionesDefinidas() As String
        Dim Ls_OperaDef As String
        Dim Ln_x As Byte
        'For Ln_x = 0 To 3
        'If Trim(chkOperacion(Ln_x).tag) <> "" Then
        If chkOperacion1.Tag <> "" Then
            If Trim(Ls_OperaDef) <> "" Then Ls_OperaDef = Ls_OperaDef & ","
            'Ls_OperaDef = Ls_OperaDef & Trim(chkOperacion(Ln_x).tag)
            Ls_OperaDef = Ls_OperaDef & Trim(chkOperacion1.Tag)
        End If

        If chkOperacion2.Tag <> "" Then
            If Trim(Ls_OperaDef) <> "" Then Ls_OperaDef = Ls_OperaDef & ","
            Ls_OperaDef = Ls_OperaDef & Trim(chkOperacion2.Tag)
        End If
        If chkOperacion3.Tag <> "" Then
            If Trim(Ls_OperaDef) <> "" Then Ls_OperaDef = Ls_OperaDef & ","
            Ls_OperaDef = Ls_OperaDef & Trim(chkOperacion3.Tag)
        End If
        If chkOperacion4.Tag <> "" Then
            If Trim(Ls_OperaDef) <> "" Then Ls_OperaDef = Ls_OperaDef & ","
            Ls_OperaDef = Ls_OperaDef & Trim(chkOperacion4.Tag)
        End If
        'Next Ln_x
        OperacionesDefinidas = Ls_OperaDef
    End Function
    '**********************************************************
    'Autor:             Ma. del Carmen Martínez León
    'Fec. Creación:     Ene, 2004
    'Autor ult. modif.: Ma. del Carmen Martínez León
    'Fec. ult. modif. : Feb, 2004
    'Devuelve con formato "mmm dd, yyyy" la información
    ' contenida en txtFecha
    '**********************************************************
    Private Function CrearFecha() As String

        Dim ls_Fecha As String

        Select Case Month(dtpFecha.Value)
            Case 1 : ls_Fecha = "Jan"
            Case 2 : ls_Fecha = "Feb"
            Case 3 : ls_Fecha = "Mar"
            Case 4 : ls_Fecha = "Apr"
            Case 5 : ls_Fecha = "May"
            Case 6 : ls_Fecha = "Jun"
            Case 7 : ls_Fecha = "Jul"
            Case 8 : ls_Fecha = "Aug"
            Case 9 : ls_Fecha = "Sep"
            Case 10 : ls_Fecha = "Oct"
            Case 11 : ls_Fecha = "Nov"
            Case 12 : ls_Fecha = "Dec"
        End Select

        ls_Fecha = ls_Fecha & " " & Microsoft.VisualBasic.Day(dtpFecha.Value)
        ls_Fecha = ls_Fecha & ", " & Year(dtpFecha.Value)

        CrearFecha = ls_Fecha
    End Function
    '**************************************************************
    'Autor:
    'Fec. Creación:
    'Autor ult. modif.: Ma. del Carmen Martínez León
    'Fec. ult. modif. : Feb, 2004
    'Genera el Reporte de Operaciones Integradas en Saldos Equation
    'Modificación: BAGO-EDS-07/MZO/06. Cambio de la constante "DESARROLLO" por la variable "DBDESARROLLO" y de la constante
    '              "CATALOGOS" por la variable "DBCATALOGOS"
    '**************************************************************
    Private Sub RepOpIntSaldos()

        Dim Ls_Operaciones As String, Ls_Sel As String

        ''Si está activado el Tipo de Reporte Equation, realiza la consulta
        'If chkTipoRep(0).Value = -1 And chkTipoRep(0).Enabled = True Then
        If chkTipoRep1.Checked = True Then
            ''Determina las Operaciones Definidas Globales a consultar
            Ls_Operaciones = OperacionesDefinidas()

            If Ls_Operaciones = "" Then
                Err.Raise(vbObjectError + 101, "RepOpIntSaldos", "Debe de seleccionar una opción como mínimo para imprimir")
            Else
                Ls_Sel = "SELECT   OPERACION.operacion, " & vbCrLf &
            "  OPERACION.monto_operacion, " & vbCrLf &
            "  OPERACION_DEFINIDA.descripcion_operacion_definida, " & vbCrLf &
            "  AGENCIA.descripcion_agencia, " & vbCrLf &
            "  CLIENTE.cuenta_cliente, " & vbCrLf &
            "  CLIENTE.nombre_cliente, " & vbCrLf &
            "  CLIENTE.apellido_paterno, " & vbCrLf &
            "  CLIENTE.apellido_materno "

                Ls_Sel = Ls_Sel & vbCrLf &
                "FROM  " & "TICKET.dbo.OPERACION OPERACION " & vbCrLf &
                "  INNER JOIN " & "TICKET.dbo.OPERACION_DEFINIDA OPERACION_DEFINIDA " & vbCrLf &
                "  ON OPERACION.operacion_definida = OPERACION_DEFINIDA.operacion_definida " & vbCrLf &
                "  INNER JOIN " & "TICKET.dbo.PRODUCTO_CONTRATADO PRODUCTO_CONTRATADO " & vbCrLf &
                "  ON OPERACION.producto_contratado = PRODUCTO_CONTRATADO.producto_contratado " & vbCrLf &
                "  INNER JOIN " & "CATALOGOS.dbo.AGENCIA AGENCIA " & vbCrLf &
                "  ON PRODUCTO_CONTRATADO.agencia = AGENCIA.agencia " & vbCrLf &
                "  INNER JOIN " & "TICKET.dbo.CUENTA_EJE CUENTA_EJE " & vbCrLf &
                "  ON PRODUCTO_CONTRATADO.producto_contratado = CUENTA_EJE.producto_contratado " & vbCrLf &
                "  INNER JOIN " & "CATALOGOS.dbo.CLIENTE CLIENTE " & vbCrLf &
                "  ON PRODUCTO_CONTRATADO.cuenta_cliente = CLIENTE.cuenta_cliente AND " & vbCrLf &
                "     PRODUCTO_CONTRATADO.agencia = CLIENTE.agencia " & vbCrLf &
                "  INNER JOIN " & "TICKET.dbo.TIPO_CUENTA_EJE TIPO_CUENTA_EJE " & vbCrLf &
                "  ON CUENTA_EJE.tipo_cuenta_eje = TIPO_CUENTA_EJE.tipo_cuenta_eje "

                Ls_Sel = Ls_Sel & vbCrLf &
                      "WHERE OPERACION.status_operacion = 4 AND " & vbCrLf &
                "      OPERACION_DEFINIDA.operacion_definida_global IN (" & Ls_Operaciones & ") AND " & vbCrLf &
                "      PRODUCTO_CONTRATADO.agencia = " & mn_Agencia & " AND " & vbCrLf &
                "     OPERACION.fecha_operacion = ('" & CrearFecha() & "') " & vbCrLf &
                " ORDER BY OPERACION.operacion ASC "

                ls_PorImprimir = ""
                ls_PorImprimir = "{OPERACION.status_operacion} = 4"
                ls_PorImprimir &= " and  {OPERACION_DEFINIDA.operacion_definida_global} in [" & Ls_Operaciones & "]"
                ls_PorImprimir &= " and  {PRODUCTO_CONTRATADO.agencia} = " & mn_Agencia
                ls_PorImprimir &= " and  {OPERACION.fecha_operacion} = date( " & dtpFecha.Value.Year & ", " & dtpFecha.Value.Month & ", " & dtpFecha.Value.Day & " )"

                With rptRepAgencias
                    '.ReportFileName = GPATH & "\ope_integradas.rpt"
                    'rptRepAgencias = New ope_integradas
                    lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
                    lsReporte = lsRutaFolder & "ope_integradas" & lsAmbiente & ".rpt"
                    rptRepAgencias.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                    'SQLQuery = Ls_Sel
                    rptRepAgencias.RecordSelectionFormula = (ls_PorImprimir)
                    rptRepAgencias.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & objLibreria.InvierteFecha(gs_FechaHoy) & "'"
                    rptRepAgencias.DataDefinition.FormulaFields.Item("Hora").Text = "'" & gs_HoraSistema & "'"
                    rptRepAgencias.DataDefinition.FormulaFields.Item("FechaOp").Text = "'Fecha de Operación: " & Trim(dtpFecha.Text) & "'"
                End With
                'MuestraVentanaReporte rptRepAgencias
                opcionReporte = 16    'reporte de Mantenimientos
                RepOperativa.reporteOFAC = rptRepAgencias
                RepOperativa.ShowDialog()
            End If
        End If
    End Sub
    '**************************************************************
    'Autor:             Ma. del Carmen Martínez León
    'Fec. Creación:     Ene, 2004
    'Autor ult. modif.: Ma. del Carmen Martínez León
    'Fec. ult. modif. : Feb, 2004
    'Genera el Reporte de Operaciones Integradas en Saldos Swift
    'Modificación: BAGO-EDS-07/MZO/06. Cambio de la constante "DESARROLLO" por la variable "DBDESARROLLO" y de la constante
    '              "CATALOGOS" por la variable "DBCATALOGOS"
    '**************************************************************
    Private Sub RepOpIntSaldosSwift()

        Dim Ls_Sel As String, Ls_Consulta As String, Ls_OperDefOP As String

        ''Si está activado el Tipo de Reporte Swift, realiza la consulta
        'If chkTipoRep(1).Value = -1 And chkTipoRep(1).Enabled = True Then
        If chkTipoRep2.Checked = True Then
            Ls_Sel = "SELECT   OPERACION.operacion, " & vbCrLf &
             "  OPERACION.monto_operacion, " & vbCrLf &
             "  OPERACION_DEFINIDA.descripcion_operacion_definida, " & vbCrLf &
             "  AGENCIA.descripcion_agencia, " & vbCrLf &
             "  CLIENTE.cuenta_cliente, " & vbCrLf &
             "  CLIENTE.nombre_cliente, " & vbCrLf &
             "  CLIENTE.apellido_paterno, " & vbCrLf &
             "  CLIENTE.apellido_materno "

            Ls_Sel = Ls_Sel & vbCrLf &
             "FROM  " & "TICKET.dbo.OPERACION OPERACION " & vbCrLf &
             "  INNER JOIN " & "TICKET.dbo.OPERACION_DEFINIDA OPERACION_DEFINIDA " & vbCrLf &
             "  ON OPERACION.operacion_definida = OPERACION_DEFINIDA.operacion_definida " & vbCrLf &
             "  INNER JOIN " & "TICKET.dbo.PRODUCTO_CONTRATADO PRODUCTO_CONTRATADO " & vbCrLf &
             "  ON OPERACION.producto_contratado = PRODUCTO_CONTRATADO.producto_contratado " & vbCrLf &
             "  INNER JOIN " & "CATALOGOS.dbo.AGENCIA AGENCIA " & vbCrLf &
             "  ON PRODUCTO_CONTRATADO.agencia = AGENCIA.agencia " & vbCrLf &
             "  INNER JOIN " & "TICKET.dbo.CUENTA_EJE CUENTA_EJE " & vbCrLf &
             "  ON PRODUCTO_CONTRATADO.producto_contratado = CUENTA_EJE.producto_contratado " & vbCrLf &
             "  INNER JOIN " & "CATALOGOS.dbo.CLIENTE CLIENTE " & vbCrLf &
             "  ON PRODUCTO_CONTRATADO.cuenta_cliente = CLIENTE.cuenta_cliente AND " & vbCrLf &
             "     PRODUCTO_CONTRATADO.agencia = CLIENTE.agencia " & vbCrLf &
             "  INNER JOIN " & "TICKET.dbo.TIPO_CUENTA_EJE TIPO_CUENTA_EJE " & vbCrLf &
             "  ON CUENTA_EJE.tipo_cuenta_eje = TIPO_CUENTA_EJE.tipo_cuenta_eje "

            'If chkOperacion(0).Value = 1 Or chkOperacion(2).Value = 1 Then
            If chkOperacion1.Checked = True Or chkOperacion3.Checked = True Then
                Ls_Consulta = Ls_Sel & vbCrLf &
                "  INNER JOIN " & "TICKET.dbo.OPERACION_SWIFT OPERACION_SWIFT " & vbCrLf &
                "  ON OPERACION.operacion = OPERACION_SWIFT.operacion " & vbCrLf &
                "  INNER JOIN " & "TICKET.dbo.BITACORA_ENVIO_SWIFT BITACORA_ENVIO_SWIFT " & vbCrLf &
                "  ON OPERACION_SWIFT.no_rep_swift = BITACORA_ENVIO_SWIFT.no_rep_swift "

                Ls_OperDefOP = ""

                ObtenerOperDefinida(0, Ls_OperDefOP)
                ObtenerOperDefinida(2, Ls_OperDefOP)
                Ls_OperDefOP = OperacionesDefinidas()

                Ls_Consulta = Ls_Consulta & vbCrLf &
                "WHERE PRODUCTO_CONTRATADO.agencia = " & mn_Agencia & " AND " & vbCrLf &
                "      BITACORA_ENVIO_SWIFT.status_envio = 4 AND " &
                "      OPERACION.fecha_operacion = ('" & CrearFecha() & "') AND " & vbCrLf &
                "      OPERACION_DEFINIDA.operacion_definida_global IN (" &
                      Ls_OperDefOP & ") "

                ls_PorImprimir = "{PRODUCTO_CONTRATADO.agencia} = " & mn_Agencia
                ls_PorImprimir &= " and  {BITACORA_ENVIO_SWIFT.status_envio} = 4"
                ls_PorImprimir &= " and  {OPERACION.fecha_operacion} = date(" & dtpFecha.Value.Year & "," & dtpFecha.Value.Month & "," & dtpFecha.Value.Day & ")"
                ls_PorImprimir &= " and  {OPERACION_DEFINIDA.operacion_definida_global} in [" & Ls_OperDefOP & "]"
            End If
            'If chkOperacion(1).Value = 1 Then
            If chkOperacion2.Checked = True Then
                If Len(Ls_Consulta) > 0 Then Ls_Consulta = Ls_Consulta & vbCrLf & "UNION"
                Ls_Consulta = Ls_Consulta & vbCrLf & Ls_Sel & vbCrLf &
                "  INNER JOIN " & "TICKET.dbo.BITACORA_REPORTE_SWIFT_MT198 BITACORA_REPORTE_SWIFT_MT198" & vbCrLf &
                "  ON OPERACION.operacion = BITACORA_REPORTE_SWIFT_MT198.operacion"

                Ls_OperDefOP = ""
                ObtenerOperDefinida(1, Ls_OperDefOP)
                Ls_OperDefOP = OperacionesDefinidas()

                Ls_Consulta = Ls_Consulta & vbCrLf &
                "WHERE PRODUCTO_CONTRATADO.agencia = " & mn_Agencia & " AND " & vbCrLf &
                "      BITACORA_REPORTE_SWIFT_MT198.status_reporte = 4 AND " & vbCrLf &
                "      BITACORA_REPORTE_SWIFT_MT198.status_envio = 1 AND " & vbCrLf &
                "      OPERACION.fecha_operacion = ('" & CrearFecha() & "') AND " & vbCrLf &
                "      OPERACION_DEFINIDA.operacion_definida_global IN (" &
                      Ls_OperDefOP & ") "

                ls_PorImprimir = "{PRODUCTO_CONTRATADO.agencia} = " & mn_Agencia
                'ls_PorImprimir &= " and  {BITACORA_REPORTE_SWIFT_MT198.status_reporte} = 4"
                'ls_PorImprimir &= " and  {BITACORA_REPORTE_SWIFT_MT198.status_envio} = 1"
                ls_PorImprimir &= " and  {OPERACION.fecha_operacion} = date ( " & dtpFecha.Value.Year & ", " & dtpFecha.Value.Month & ", " & dtpFecha.Value.Day & " )"
                ls_PorImprimir &= " and  {OPERACION_DEFINIDA.operacion_definida_global} in [" & Ls_OperDefOP & "]"
            End If

            Ls_Consulta = Ls_Consulta & vbCrLf & " ORDER BY OPERACION.operacion "

            If Ls_OperDefOP <> "" Then
                With rptRepAgencias
                    '.ReportFileName = GPATH & "\ope_integradasSwift.rpt"
                    'rptRepAgencias = New ope_integradasSwift
                    lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
                    lsReporte = lsRutaFolder & "ope_integradasSwift" & lsAmbiente & ".rpt"
                    rptRepAgencias.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                    '.SQLQuery = Ls_Sel
                    rptRepAgencias.RecordSelectionFormula = (ls_PorImprimir)
                    rptRepAgencias.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & objLibreria.InvierteFecha(gs_FechaHoy) & "'"
                    rptRepAgencias.DataDefinition.FormulaFields.Item("Hora").Text = "'" & gs_HoraSistema & "'"
                    rptRepAgencias.DataDefinition.FormulaFields.Item("FechaOp").Text = "'Fecha de Operación: " & Trim(dtpFecha.Text) & "'"
                End With
                'MuestraVentanaReporte rptRepAgencias
                opcionReporte = 16    'reporte de Mantenimientos
                RepOperativa.reporteOFAC = rptRepAgencias
                RepOperativa.ShowDialog()
            End If
        End If
    End Sub
    '*************************************************************
    'Autor:             Ma. del Carmen Martínez León
    'Fec. Creación:     Ene, 2004
    'Autor ult. modif.: Ma. del Carmen Martínez León
    'Fec. ult. modif. : Feb, 2004
    'Devuelve las operaciones definidas del CheckBox seleccionado
    '*************************************************************
    Private Sub ObtenerOperDefinida(Li_Cont As Integer, Ls_Oper As String)

        Dim Ls_OperaDef As String

        Ls_OperaDef = ""

        Select Case Li_Cont
            Case 0 : chkOperacionTag = chkOperacion1.Tag
            Case 1 : chkOperacionTag = chkOperacion2.Tag
            Case 2 : chkOperacionTag = chkOperacion3.Tag
            Case 3 : chkOperacionTag = chkOperacion4.Tag
        End Select

        'If Trim(chkOperacion(Li_Cont).tag) <> "" Then
        If Trim(chkOperacionTag) <> "" Then
            Ls_OperaDef = Trim(chkOperacionTag)
            Ls_Oper = Trim(Ls_Oper) & IIf(Len(Ls_Oper) > 0, ",", "") &
                Trim(Ls_OperaDef)
        End If

    End Sub

    Private Sub chkOperacion1_CheckedChanged(sender As Object, e As EventArgs) Handles chkOperacion1.CheckedChanged
        ConfOpcion(0)
        If chkOperacion1.Checked = True Then
            chkOperacion1.Tag = chkOperacionTag
        Else
            chkOperacion1.Tag = ""
        End If

    End Sub

    Private Sub chkOperacion2_CheckedChanged(sender As Object, e As EventArgs) Handles chkOperacion2.CheckedChanged
        ConfOpcion(1)
        If chkOperacion2.Checked = True Then
            chkOperacion2.Tag = chkOperacionTag
        Else
            chkOperacion2.Tag = ""
        End If
    End Sub

    Private Sub chkOperacion3_CheckedChanged(sender As Object, e As EventArgs) Handles chkOperacion3.CheckedChanged
        ConfOpcion(2)
        If chkOperacion3.Checked = True Then
            chkOperacion3.Tag = chkOperacionTag
        Else
            chkOperacion3.Tag = ""
        End If
    End Sub

    Private Sub chkOperacion4_CheckedChanged(sender As Object, e As EventArgs) Handles chkOperacion4.CheckedChanged
        ConfOpcion(3)
        If chkOperacion4.Checked = True Then
            chkOperacion4.Tag = chkOperacionTag
        Else
            chkOperacion4.Tag = ""
        End If
    End Sub
    Private Sub RepDetDep()

        'No incluyo Area Interna por ser reporte de Depositos por Sucursal
        With rptRepAgencias
            '.ReportFileName = GPATH & "\det_depo_RAgen.rpt"
            lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
            lsReporte = lsRutaFolder & "det_depo_RAgen" & lsAmbiente & ".rpt"
            rptRepAgencias.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
            '.Formulas(0) = "FechaHoy = '" & InvierteFecha(gs_FechaHoy) & "'"
            rptRepAgencias.DataDefinition.FormulaFields.Item("FechaHoy").Text = "'" & Trim(gs_FechaHoy) & "'"
            rptRepAgencias.RecordSelectionFormula = "({OPERACION.fecha_operacion}>=Date("
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & dtpFecha.Value.Year
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & "," & Format(dtpFecha.Value.Month, "00")
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & "," & Format(dtpFecha.Value.Day, "00") & ") "
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & "and {OPERACION.fecha_operacion}<Date("
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & CDate(ms_FechaFuturo).Year
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & "," & Format(CDate(ms_FechaFuturo).Month, "00")
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & "," & Format(CDate(ms_FechaFuturo).Day, "00") & ") "
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & " and {PRODUCTO_CONTRATADO.agencia} = " & mn_Agencia
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & " and {OPERACION_DEFINIDA.operacion_definida_global} in [583 ,588,589,590,591,592   ]"
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & " and {OPERACION.status_operacion} <> 250 )"
            '.ParameterFields(0) = "pTitulo;" & "DETALLE DE DEPÓSITOS SUCURSALES HOY" & ";TRUE"
            rptRepAgencias.SetParameterValue("pTitulo", "DETALLE DE DEPÓSITOS SUCURSALES HOY")
            '.ParameterFields(1) = "pAgencia;" & lstAgencia.Text & ";TRUE"
            rptRepAgencias.SetParameterValue("pAgencia", lstAgencia.Text)
            opcionReporte = 16    'reporte de Mantenimientos
            RepOperativa.reporteOFAC = rptRepAgencias
            RepOperativa.ShowDialog()
        End With
    End Sub
    Private Sub RepDetRet()

        With rptRepAgencias
            '.ReportFileName = GPATH & "\det_ret_RAgen.rpt"
            lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
            lsReporte = lsRutaFolder & "det_ret_RAgen" & lsAmbiente & ".rpt"
            rptRepAgencias.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
            '.Formulas(0) = "FechaHoy = '" & InvierteFecha(gs_FechaHoy) & "'"
            rptRepAgencias.DataDefinition.FormulaFields.Item("FechaHoy").Text = "'" & Trim(gs_FechaHoy) & "'"
            rptRepAgencias.RecordSelectionFormula = "({OPERACION.fecha_operacion}>=Date("
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & dtpFecha.Value.Year
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & "," & Format(dtpFecha.Value.Month, "00")
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & "," & Format(dtpFecha.Value.Day, "00") & ") "
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & "and {OPERACION.fecha_operacion}<Date("
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & CDate(ms_FechaFuturo).Year
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & "," & Format(CDate(ms_FechaFuturo).Month, "00")
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & "," & Format(CDate(ms_FechaFuturo).Day, "00") & ") "
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & " and {PRODUCTO_CONTRATADO.agencia} = " & mn_Agencia
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & " and {OPERACION_DEFINIDA.operacion_definida_global} in [65,83,88,89] "   '24 Horas
            rptRepAgencias.RecordSelectionFormula = rptRepAgencias.RecordSelectionFormula & " and {OPERACION.status_operacion} <> 250 )"
            '.ParameterFields(0) = "pTitulo;" & "DETALLE DE RETIROS SUCURSALES HOY" & ";TRUE"
            rptRepAgencias.SetParameterValue("pTitulo", "DETALLE DE RETIROS SUCURSALES HOY")
            '.ParameterFields(1) = "pAgencia;" & lstAgencia.Text & ";TRUE"
            rptRepAgencias.SetParameterValue("pAgencia", lstAgencia.Text)
            opcionReporte = 16    'reporte de Mantenimientos
            RepOperativa.reporteOFAC = rptRepAgencias
            RepOperativa.ShowDialog()
        End With

    End Sub
End Class