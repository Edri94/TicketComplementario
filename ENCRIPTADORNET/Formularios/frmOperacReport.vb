Imports System.IO

Public Class frmOperacReport
    Private mnAgencia As Integer
    Private mnTipoRep As Byte

    Private objDatasource As New Datasource
    Private objLibreria As New Libreria
    Private Sub frmOperacReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtRespConsulta As New DataTable()
        'Screen.MousePointer = vbHourglass
        'Label1.ForeColor = &HC0&
        'Me.Width = 7365
        'Me.Height = 5895
        'Call Centerform(Me)
        'Call CargarColores(Me, cambio)
        'Me.Show()
        MaximizeBox = False
        MinimizeBox = False
        'ControlBox = False
        FormBorderStyle = FormBorderStyle.FixedSingle
        'Me.Size = New Size(500, 600)
        gs_Sql = "Select agencia, descripcion_agencia"
        gs_Sql = gs_Sql & " from " & "CATALOGOS" & ".dbo.AGENCIA"
        gs_Sql = gs_Sql & " where agencia = 1 " ' & GsPermisoAgencia
        gs_Sql = gs_Sql & " order by agencia"
        'dbExecQuery gs_Sql
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbGetRecord
        If dtRespConsulta.Rows.Count > 0 Then
            'Do While Not IsdbError
            For Each row As DataRow In dtRespConsulta.Rows
                lstAgencia.Items.Add(row.Item(1))
                'lstAgencia.AddItem(dbGetValue(1))
                'lstAgencia.ItemData(lstAgencia.NewIndex) = dbGetValue(0)
                'dbGetRecord
            Next
            'Loop
        End If
        gs_Sql = ""
        'Reporte(5)
        If Not Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Desktop & "\S_B_F") Then
            Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Desktop & "\S_B_F")
        End If
        'dbEndQuery
        'Screen.MousePointer = vbDefault
    End Sub

    Private Sub rbtFOH_CheckedChanged(sender As Object, e As EventArgs) Handles rbtFOH.CheckedChanged
        If lstAgencia.SelectedIndex <> -1 Then
            lstAgencia_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub rbtPC_CheckedChanged(sender As Object, e As EventArgs) Handles rbtPC.CheckedChanged
        If lstAgencia.SelectedIndex <> -1 Then
            lstAgencia_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub lstAgencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAgencia.SelectedIndexChanged
        If lstAgencia.SelectedIndex > -1 Then
            'mnAgencia = lstAgencia.ItemData(lstAgencia.ListIndex)
            mnAgencia = lstAgencia.SelectedIndex + 1
            'Screen.MousePointer = vbHourglass
            cmdImprimir.Enabled = True
            dgvOperac.DataSource = Nothing
            Select Case mnTipoRep
                Case 2 : ListaRetiros()
                Case 3 : ListaDep(583)          'Depositos por sucursal en Firme
                Case 4 : ListaRetDevCheque()
                Case 5 : ListaDep(588)          'Depositos por sucursal SBF
                Case 6 : ListaCDs()
                Case 7 : ListaCDsLista()
                Case 8 : ListaAperturas()
                Case 9 : ListaAperturasVal()
                Case 10 : ListaAperturasDia()
                Case 11 : ListaTraspasos()
                Case 12 : ListaDepAreaInt(589)   'Depositos Area Interna en Firme
                Case 13 : ListaRetAreaInt()
                Case 14 : ListaTraspasos()
                Case 15 : ListaDepAreaInt(591)   'Depositos Area Interna 24H
                Case 16 : ListaDepAreaInt(592)   'Depositos Area Interna SBF
                Case 17 : ListaDep(590)          'Depositos por sucursal 24H
            End Select
            If mnTipoRep = 10 Then
                'lstOperac.ColumnHeaders.Clear
                dgvOperac.DataSource = Nothing
                LlenaLista("Ticket&Cuenta&Monto&Status de Impresión", gs_Sql, True, False, False, 0, 0, "+2", "+0-0000000")
                'ElseIf optSBF(0).Value Then
            ElseIf rbtFOH.Checked = True Then
                LlenaLista("Ticket&Cuenta&Monto&Status", gs_Sql, True, False, False, 0, 0, "+2", "+0-0000000")
            Else 'LGA MAYO 24, 2007 Se cambio la etiqueta de Fecha Captura por Fecha Vencimiento
                LlenaLista("Ticket&Cuenta&Monto&Status&Fecha Vencimiento&Fecha Operacion", gs_Sql, True, False, False, 0, 0, "+2", "+0-0000000")
            End If
            'Screen.MousePointer = vbDefault
            'If lstOperac.ListItems.Count = 0 Then
            If dgvOperac.Rows.Count = 0 Then
                cmdImprimir.Enabled = False
                MsgBox("No hay operaciones para el día de hoy.", vbInformation, "Aviso")
            End If
        End If
    End Sub

    Private Sub ListaRetiros()
        'Obtiene las operaciones con fecha_operacion = "HOY" ya validadas
        gs_Sql = "Select distinct"
        gs_Sql = gs_Sql & " O.operacion,"
        gs_Sql = gs_Sql & " PC.cuenta_cliente,"
        gs_Sql = gs_Sql & " O.monto_operacion,"
        gs_Sql = gs_Sql & " case RO.impreso when 1 then 'Impreso' else '' end"
        gs_Sql = gs_Sql & " from TICKET..RETIRO_PME ROP,"
        gs_Sql = gs_Sql & " TICKET..OPERACION O left outer join TICKET..REPORTE_OPERACION RO on O.operacion = RO.operacion,"
        gs_Sql = gs_Sql & " TICKET..PRODUCTO_CONTRATADO PC,"
        gs_Sql = gs_Sql & " TICKET..OPERACION_DEFINIDA OD,"
        gs_Sql = gs_Sql & " TICKET..TIPO_DOCUMENTO TD"
        gs_Sql = gs_Sql & " where OD.operacion_definida_global IN (83, 59, 58)"
        gs_Sql = gs_Sql & " and O.status_operacion <> 250"
        gs_Sql = gs_Sql & " and O.status_operacion >= 2"
        gs_Sql = gs_Sql & " and O.operacion = ROP.operacion"
        gs_Sql = gs_Sql & " and ROP.tipo_documento = TD.tipo_documento"
        gs_Sql = gs_Sql & " and O.fecha_operacion > '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 00:00:00'"
        gs_Sql = gs_Sql & " and O.fecha_operacion < '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 23:59:59'"
        gs_Sql = gs_Sql & " and O.producto_contratado = PC.producto_contratado"
        gs_Sql = gs_Sql & " and O.operacion_definida=OD.operacion_definida"
        gs_Sql = gs_Sql & " and OD.agencia = " & mnAgencia
        gs_Sql = gs_Sql & " order by O.operacion"
    End Sub
    Private Sub ListaRetDevCheque()
        'Obtiene las operaciones con fecha_operacion = "HOY" ya validadas
        gs_Sql = "Select distinct"
        gs_Sql = gs_Sql & " O.operacion,"
        gs_Sql = gs_Sql & " PC.cuenta_cliente,"
        gs_Sql = gs_Sql & " O.monto_operacion,"
        gs_Sql = gs_Sql & " case RO.impreso when 1 then 'Impreso' else '' end"
        gs_Sql = gs_Sql & " from TICKET..RETIRO_PME ROP,"
        gs_Sql = gs_Sql & " TICKET..OPERACION O left outer join TICKET..REPORTE_OPERACION RO on O.operacion = RO.operacion,"
        gs_Sql = gs_Sql & " TICKET..PRODUCTO_CONTRATADO PC,"
        gs_Sql = gs_Sql & " TICKET..OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & " where OD.operacion_definida_global = 88"
        gs_Sql = gs_Sql & " and O.status_operacion <> 250"
        gs_Sql = gs_Sql & " and O.status_operacion >= 2"
        gs_Sql = gs_Sql & " and O.operacion = ROP.operacion"
        gs_Sql = gs_Sql & " and O.fecha_operacion > '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 00:00:00'"
        gs_Sql = gs_Sql & " and O.fecha_operacion < '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 23:59:59'"
        gs_Sql = gs_Sql & " and O.producto_contratado = PC.producto_contratado"
        gs_Sql = gs_Sql & " and O.operacion_definida=OD.operacion_definida"
        gs_Sql = gs_Sql & " and OD.agencia = " & mnAgencia
        gs_Sql = gs_Sql & " order by O.operacion"
    End Sub

    Private Sub ListaDep(ByVal OpDefGlobal As String)
        Select Case OpDefGlobal
            Case 583
                'Obtiene las operaciones con fecha_cierre <= "HOY" ya Validadas
                gs_Sql = "Select distinct"
                gs_Sql = gs_Sql & " O.operacion,"
                gs_Sql = gs_Sql & " PC.cuenta_cliente,"
                gs_Sql = gs_Sql & " O.monto_operacion,"
                gs_Sql = gs_Sql & " case RO.impreso when 1 then 'Impreso' else '' end"
                gs_Sql = gs_Sql & " from TICKET..DEPOSITO_PME ROP,"
                gs_Sql = gs_Sql & " TICKET..OPERACION O left outer join TICKET..REPORTE_OPERACION RO on O.operacion = RO.operacion,"
                gs_Sql = gs_Sql & " TICKET..PRODUCTO_CONTRATADO PC,"
                gs_Sql = gs_Sql & " TICKET..OPERACION_DEFINIDA OD,"
                gs_Sql = gs_Sql & " TICKET..DEPOSITO D,"
                gs_Sql = gs_Sql & " TICKET..TIPO_DOCUMENTO TD"
                gs_Sql = gs_Sql & " where OD.operacion_definida_global IN (" & OpDefGlobal & ", 559)"
                gs_Sql = gs_Sql & " and O.status_operacion <> 250 and O.status_operacion >= 2"
                gs_Sql = gs_Sql & " and O.operacion = ROP.operacion"
                gs_Sql = gs_Sql & " and O.operacion = D.operacion"
                gs_Sql = gs_Sql & " and D.operacion = ROP.operacion"
                gs_Sql = gs_Sql & " and D.tipo_documento = TD.tipo_documento"
                gs_Sql = gs_Sql & " and ROP.fecha_cierre > '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 00:00:00'"
                gs_Sql = gs_Sql & " and ROP.fecha_cierre < '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 23:59:59'"
                gs_Sql = gs_Sql & " and O.producto_contratado = PC.producto_contratado"
                gs_Sql = gs_Sql & " and O.operacion_definida= OD.operacion_definida"
                gs_Sql = gs_Sql & " and OD.agencia = " & mnAgencia

            Case 588
                'If optSBF(0).Value Then
                If rbtFOH.Checked = True Then
                    'Obtiene las operaciones con fecha_cierre <= "HOY" ya Validadas
                    gs_Sql = "Select distinct"
                    gs_Sql = gs_Sql & " O.operacion, PC.cuenta_cliente,O.monto_operacion,"
                    gs_Sql = gs_Sql & " case RO.impreso when 1 then 'Impreso' else '' end"
                    gs_Sql = gs_Sql & " from TICKET..DEPOSITO_PME ROP, "
                    gs_Sql = gs_Sql & " TICKET..PRODUCTO_CONTRATADO PC,TICKET..OPERACION_DEFINIDA OD,"
                    gs_Sql = gs_Sql & " TICKET..DEPOSITO D,"
                    gs_Sql = gs_Sql & " TICKET..TIPO_DOCUMENTO TD,"
                    gs_Sql = gs_Sql & " TICKET..OPERACION O"
                    gs_Sql = gs_Sql & " LEFT OUTER JOIN TICKET..REPORTE_OPERACION RO"
                    gs_Sql = gs_Sql & " ON  O.operacion = RO.operacion"
                    gs_Sql = gs_Sql & " where OD.operacion_definida_global = " & OpDefGlobal
                    gs_Sql = gs_Sql & " and O.status_operacion <> 250 and O.status_operacion >= 2"
                    gs_Sql = gs_Sql & " and O.operacion = ROP.operacion"
                    gs_Sql = gs_Sql & " and O.operacion = D.operacion"
                    gs_Sql = gs_Sql & " and D.operacion = ROP.operacion"
                    gs_Sql = gs_Sql & " and D.tipo_documento = TD.tipo_documento"
                    gs_Sql = gs_Sql & " and ROP.fecha_cierre > '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 00:00:00'"
                    gs_Sql = gs_Sql & " and ROP.fecha_cierre < '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 23:59:59'"
                    gs_Sql = gs_Sql & " and O.producto_contratado = PC.producto_contratado"
                    gs_Sql = gs_Sql & " and O.operacion_definida= OD.operacion_definida"
                    gs_Sql = gs_Sql & " and OD.agencia = " & mnAgencia
                Else
                    'LGA MAYO 24, 2007  Se anexan 6 dias habilies a la Fecha Captura
                    'que es lo que tarda en hacerse el deposito (Operaciones "N" Dias)
                    gs_Sql = "SELECT  DISTINCT "
                    gs_Sql = gs_Sql & "O.operacion, PC.cuenta_cliente, O.monto_operacion,"
                    gs_Sql = gs_Sql & "CASE RO.impreso WHEN 1 THEN 'Impreso' ELSE ''END,"
                    gs_Sql = gs_Sql & "'Fecha_Vencimiento' =CASE "
                    gs_Sql = gs_Sql & "WHEN DATEPART(weekday,DATEADD(d,6,fecha_captura))= 7 THEN DATEADD(d,8,fecha_captura)"
                    gs_Sql = gs_Sql & "WHEN DATEPART(weekday,DATEADD(d,6,fecha_captura))= 1 THEN DATEADD(d,7,fecha_captura)"
                    gs_Sql = gs_Sql & "ELSE DATEADD(d,8,fecha_captura)  END, fecha_operacion "
                    gs_Sql = gs_Sql & "from TICKET..DEPOSITO_PME ROP, TICKET..OPERACION O left outer join TICKET..REPORTE_OPERACION RO on O.operacion = RO.operacion,"
                    gs_Sql = gs_Sql & "TICKET..PRODUCTO_CONTRATADO PC, TICKET..OPERACION_DEFINIDA OD, "
                    gs_Sql = gs_Sql & "TICKET..DEPOSITO D, TICKET..TIPO_DOCUMENTO TD "
                    gs_Sql = gs_Sql & "Where O.operacion = ROP.operacion "
                    gs_Sql = gs_Sql & "AND O.operacion = D.operacion "
                    gs_Sql = gs_Sql & "AND OD.operacion_definida_global = " & OpDefGlobal
                    gs_Sql = gs_Sql & " AND O.status_operacion = 0 "
                    gs_Sql = gs_Sql & "AND D.operacion = ROP.operacion "
                    gs_Sql = gs_Sql & "AND D.tipo_documento = TD.tipo_documento "
                    gs_Sql = gs_Sql & "AND O.producto_contratado = PC.producto_contratado "
                    gs_Sql = gs_Sql & "AND O.operacion_definida= OD.operacion_definida "
                    gs_Sql = gs_Sql & "AND OD.agencia = 1"
                End If
            Case 590
                'Obtiene las operaciones con fecha_cierre <= "HOY" ya Validadas
                gs_Sql = "Select distinct"
                gs_Sql = gs_Sql & " O.operacion,"
                gs_Sql = gs_Sql & " PC.cuenta_cliente,"
                gs_Sql = gs_Sql & " O.monto_operacion,"
                gs_Sql = gs_Sql & " case RO.impreso when 1 then 'Impreso' else '' end"
                gs_Sql = gs_Sql & " from TICKET..DEPOSITO_PME ROP,"
                gs_Sql = gs_Sql & " TICKET..PRODUCTO_CONTRATADO PC,"
                gs_Sql = gs_Sql & " TICKET..OPERACION_DEFINIDA OD,"
                gs_Sql = gs_Sql & " TICKET..DEPOSITO D,"
                gs_Sql = gs_Sql & " TICKET..TIPO_DOCUMENTO TD,"
                gs_Sql = gs_Sql & " TICKET..OPERACION O"
                gs_Sql = gs_Sql & " LEFT OUTER JOIN TICKET..REPORTE_OPERACION RO"
                gs_Sql = gs_Sql & " ON  O.operacion = RO.operacion"
                gs_Sql = gs_Sql & " where OD.operacion_definida_global = " & OpDefGlobal
                gs_Sql = gs_Sql & " and O.status_operacion <> 250 and O.status_operacion >= 2"
                gs_Sql = gs_Sql & " and O.operacion = ROP.operacion"
                gs_Sql = gs_Sql & " and O.operacion = D.operacion"
                gs_Sql = gs_Sql & " and D.operacion = ROP.operacion"
                gs_Sql = gs_Sql & " and D.tipo_documento = TD.tipo_documento"
                gs_Sql = gs_Sql & " and ROP.fecha_cierre > '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 00:00:00'"
                gs_Sql = gs_Sql & " and ROP.fecha_cierre < '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 23:59:59'"
                gs_Sql = gs_Sql & " and O.producto_contratado = PC.producto_contratado"
                gs_Sql = gs_Sql & " and O.operacion_definida= OD.operacion_definida"
                gs_Sql = gs_Sql & " and OD.agencia = " & mnAgencia
        End Select
    End Sub

    Private Sub ListaTraspasos()
        gs_Sql = "Select distinct"
        gs_Sql = gs_Sql & " O.operacion,"
        gs_Sql = gs_Sql & " P.cuenta_cliente,"
        gs_Sql = gs_Sql & " O.monto_operacion,"
        gs_Sql = gs_Sql & " case RO.impreso when 1 then 'Impreso' else '' end"
        gs_Sql = gs_Sql & " From TICKET..TRASPASO T,"
        gs_Sql = gs_Sql & " TICKET..OPERACION O left outer join TICKET..REPORTE_OPERACION RO on O.operacion = RO.operacion,"
        gs_Sql = gs_Sql & " TICKET..PRODUCTO_CONTRATADO P,"
        gs_Sql = gs_Sql & " TICKET..OPERACION_DEFINIDA OD, "
        gs_Sql = gs_Sql & " CATALOGOS" & ".dbo.AGENCIA A,"
        gs_Sql = gs_Sql & " TICKET..CUENTA_EJE CE,"
        gs_Sql = gs_Sql & " TICKET..TIPO_CUENTA_EJE TCE"
        gs_Sql = gs_Sql & " Where O.operacion = T.operacion and"
        gs_Sql = gs_Sql & " P.producto_contratado = O.producto_contratado and"
        gs_Sql = gs_Sql & " O.operacion_definida = OD.operacion_definida and"
        gs_Sql = gs_Sql & " A.agencia = " & mnAgencia
        If mnTipoRep = 11 Then
            gs_Sql = gs_Sql & " and OD.operacion_definida_global = 87"
        Else
            gs_Sql = gs_Sql & " and OD.operacion_definida_global = 97"
        End If
        gs_Sql = gs_Sql & " and P.producto_contratado = O.producto_contratado"
        gs_Sql = gs_Sql & " and P.agencia = A.agencia"
        gs_Sql = gs_Sql & " and P.producto_contratado = CE.producto_contratado"
        gs_Sql = gs_Sql & " and CE.tipo_cuenta_eje =  TCE.tipo_cuenta_eje"
        gs_Sql = gs_Sql & " and O.fecha_operacion > '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 00:00:00'"      'Fecha "HOY"
        gs_Sql = gs_Sql & " and O.fecha_operacion < '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 23:59:59'"      'Fecha "HOY"
        gs_Sql = gs_Sql & " and O.status_operacion >= 2"
        gs_Sql = gs_Sql & " and O.status_operacion <> 250"
    End Sub

    Private Sub ListaAperturasDia()
        'Obtiene TODAS las operaciones de Apertura de Cuenta con Fecha valor HOY
        gs_Sql = "Select distinct"
        gs_Sql = gs_Sql & " O.operacion,"
        gs_Sql = gs_Sql & " PC.cuenta_cliente,"
        gs_Sql = gs_Sql & " O.monto_operacion,"
        gs_Sql = gs_Sql & " case RO.impreso when 1 then 'Impreso' else '' end"
        gs_Sql = gs_Sql & " From TICKET..OPERACION O left outer join TICKET..REPORTE_OPERACION RO on O.operacion = RO.operacion,"
        gs_Sql = gs_Sql & " TICKET..PRODUCTO_CONTRATADO PC,"
        gs_Sql = gs_Sql & " TICKET..OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & " where operacion_definida_global =100 "               'Apertura de Cuentas
        gs_Sql = gs_Sql & " and O.fecha_operacion > '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 00:00:00'"      'Fecha "HOY"
        gs_Sql = gs_Sql & " and O.fecha_operacion < '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 23:59:59'"      'Fecha "HOY"
        gs_Sql = gs_Sql & " and O.status_operacion <> 250"                       'No Canceladas
        gs_Sql = gs_Sql & " and O.producto_contratado = PC.producto_contratado"
        gs_Sql = gs_Sql & " and OD.operacion_definida = O.operacion_definida"
        gs_Sql = gs_Sql & " and PC. agencia = " & mnAgencia
        gs_Sql = gs_Sql & " order by O.operacion"
    End Sub

    Private Sub ListaAperturas()
        'Obtiene las operaciones de Apertura de Cuenta ya validadas
        gs_Sql = "Select distinct"
        gs_Sql = gs_Sql & " O.operacion,"
        gs_Sql = gs_Sql & " PC.cuenta_cliente,"
        gs_Sql = gs_Sql & " O.monto_operacion,"
        gs_Sql = gs_Sql & " case RO.impreso when 1 then 'Impreso' else '' end"
        gs_Sql = gs_Sql & " From TICKET..OPERACION O left outer join TICKET..REPORTE_OPERACION RO on O.operacion = RO.operacion,"
        gs_Sql = gs_Sql & " TICKET..PRODUCTO_CONTRATADO PC, "
        gs_Sql = gs_Sql & " TICKET..OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & " where operacion_definida_global =100 "              'Apertura de Cuenta
        gs_Sql = gs_Sql & " and O.fecha_operacion > '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 00:00:00'"      'Fecha "HOY"
        gs_Sql = gs_Sql & " and O.fecha_operacion < '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 23:59:59'"      'Fecha "HOY"
        gs_Sql = gs_Sql & " and O.status_operacion in (2,3,4,5)"
        gs_Sql = gs_Sql & " and O.status_operacion <> 250"                      'No Canceladas
        gs_Sql = gs_Sql & " and O.producto_contratado = PC.producto_contratado"
        gs_Sql = gs_Sql & " and OD.operacion_definida = O.operacion_definida"
        gs_Sql = gs_Sql & " and PC. agencia = " & mnAgencia
        gs_Sql = gs_Sql & " order by O.operacion"
    End Sub

    Private Sub ListaAperturasVal()
        gs_Sql = "Select distinct"
        gs_Sql = gs_Sql & " O.operacion,"
        gs_Sql = gs_Sql & " PC.cuenta_cliente,"
        gs_Sql = gs_Sql & " O.monto_operacion,"
        gs_Sql = gs_Sql & " case RO.impreso when 1 then 'Impreso' else '' end"
        gs_Sql = gs_Sql & " From TICKET..OPERACION O left outer join TICKET..REPORTE_OPERACION RO on O.operacion = RO.operacion,"
        gs_Sql = gs_Sql & " TICKET..PRODUCTO_CONTRATADO PC, "
        gs_Sql = gs_Sql & " TICKET..OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & " where operacion_definida_global =100 "              'Apertura de Cuenta
        gs_Sql = gs_Sql & " and O.fecha_operacion > '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 00:00:00'"      'Fecha "HOY"
        gs_Sql = gs_Sql & " and O.fecha_operacion < '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 23:59:59'"      'Fecha "HOY"
        gs_Sql = gs_Sql & " and O.status_operacion in (2,3,4,5)"
        gs_Sql = gs_Sql & " and O.status_operacion <> 250"                      'No Canceladas
        gs_Sql = gs_Sql & " and O.producto_contratado = PC.producto_contratado"
        gs_Sql = gs_Sql & " and O.operacion_definida = OD.operacion_definida "
        gs_Sql = gs_Sql & " and PC.agencia = " & mnAgencia
        gs_Sql = gs_Sql & " order by O.operacion"
    End Sub

    Private Sub ListaCDs()
        gs_Sql = "Select distinct"
        gs_Sql = gs_Sql & " O.operacion,"
        gs_Sql = gs_Sql & " PC.cuenta_cliente,"
        gs_Sql = gs_Sql & " O.monto_operacion,"
        gs_Sql = gs_Sql & " case RO.impreso when 1 then 'Impreso' else '' end"
        gs_Sql = gs_Sql & " From TICKET..OPERACION O left outer join TICKET..REPORTE_OPERACION RO on O.operacion = RO.operacion,"
        gs_Sql = gs_Sql & " TICKET..PRODUCTO_CONTRATADO PC,"
        gs_Sql = gs_Sql & " TICKET..COMPRA_CD CD,"
        gs_Sql = gs_Sql & " TICKET..OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & " where operacion_definida_global =80 "
        gs_Sql = gs_Sql & " and O.operacion = CD.operacion "
        gs_Sql = gs_Sql & " and O.fecha_operacion > '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 00:00:00'"      'Fecha "HOY"
        gs_Sql = gs_Sql & " and O.fecha_operacion < '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 23:59:59'"      'Fecha "HOY"
        gs_Sql = gs_Sql & " and status_operacion in (2,3,4,5)"
        gs_Sql = gs_Sql & " and O.producto_contratado = PC.producto_contratado"
        gs_Sql = gs_Sql & " and O.operacion_definida = OD.operacion_definida"
        gs_Sql = gs_Sql & " and OD.agencia = " & mnAgencia
        gs_Sql = gs_Sql & " order by O.operacion"
    End Sub

    Private Sub ListaCDsLista()
        gs_Sql = "Select distinct"
        gs_Sql = gs_Sql & " O.operacion,"
        gs_Sql = gs_Sql & " PC.cuenta_cliente,"
        gs_Sql = gs_Sql & " O.monto_operacion,"
        gs_Sql = gs_Sql & " case RO.impreso when 1 then 'Impreso' else '' end"
        gs_Sql = gs_Sql & " TICKET..OPERACION O left outer join TICKET..REPORTE_OPERACION RO on O.operacion = RO.operacion,"
        gs_Sql = gs_Sql & " TICKET..PRODUCTO_CONTRATADO PC,"
        gs_Sql = gs_Sql & " TICKET..COMPRA_CD CD,"
        gs_Sql = gs_Sql & " TICKET..OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & " where operacion_definida_global =80 "
        gs_Sql = gs_Sql & " and O.operacion = CD.operacion "
        gs_Sql = gs_Sql & " and O.fecha_operacion >= '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"      'Fecha "HOY"
        gs_Sql = gs_Sql & " and O.fecha_operacion <= '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & "'"      'Fecha "HOY"
        gs_Sql = gs_Sql & " and status_operacion in (2,3,4,5)"
        gs_Sql = gs_Sql & " and O.producto_contratado = PC.producto_contratado"
        gs_Sql = gs_Sql & " and O.operacion_definida = OD.operacion_definida"
        gs_Sql = gs_Sql & " and OD.agencia = " & mnAgencia
        gs_Sql = gs_Sql & " order by O.operacion"
    End Sub

    Private Sub ListaDepAreaInt(ByVal OpDefGlobal As String)
        'Obtiene las operaciones con fecha_cierre <= "HOY" ya Validadas
        gs_Sql = "Select distinct"
        gs_Sql = gs_Sql & " O.operacion,"
        gs_Sql = gs_Sql & " PC.cuenta_cliente,"
        gs_Sql = gs_Sql & " O.monto_operacion,"
        gs_Sql = gs_Sql & " case RO.impreso when 1 then 'Impreso' else '' end"
        gs_Sql = gs_Sql & " from TICKET..DEPOSITO_PME ROP,"
        gs_Sql = gs_Sql & " TICKET..OPERACION O left outer join TICKET..REPORTE_OPERACION RO on O.operacion = RO.operacion,"
        gs_Sql = gs_Sql & " TICKET..PRODUCTO_CONTRATADO PC,"
        gs_Sql = gs_Sql & " TICKET..OPERACION_DEFINIDA OD,"
        gs_Sql = gs_Sql & " TICKET..DEPOSITO D,"
        gs_Sql = gs_Sql & " TICKET..TIPO_DOCUMENTO TD"
        gs_Sql = gs_Sql & " where OD.operacion_definida_global = " & OpDefGlobal
        gs_Sql = gs_Sql & " and O.status_operacion <> 250 and O.status_operacion >= 2"
        gs_Sql = gs_Sql & " and O.operacion = ROP.operacion"
        gs_Sql = gs_Sql & " and O.operacion = D.operacion"
        gs_Sql = gs_Sql & " and D.operacion = ROP.operacion"
        gs_Sql = gs_Sql & " and D.tipo_documento = TD.tipo_documento"
        gs_Sql = gs_Sql & " and ROP.fecha_cierre > '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 00:00:00'"      'Fecha "HOY"
        gs_Sql = gs_Sql & " and ROP.fecha_cierre < '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 23:59:59'"      'Fecha "HOY"
        gs_Sql = gs_Sql & " and O.producto_contratado = PC.producto_contratado"
        gs_Sql = gs_Sql & " and O.operacion_definida= OD.operacion_definida"
        gs_Sql = gs_Sql & " and OD.agencia = " & mnAgencia
    End Sub

    Private Sub ListaRetAreaInt()
        'Obtiene las operaciones con fecha_operacion = "HOY" ya validadas
        gs_Sql = "Select distinct "
        gs_Sql = gs_Sql & " O.operacion, "
        gs_Sql = gs_Sql & " PC.cuenta_cliente,"
        gs_Sql = gs_Sql & " O.monto_operacion,"
        gs_Sql = gs_Sql & " case RO.impreso when 1 then 'Impreso' else '' end"
        gs_Sql = gs_Sql & " From"
        gs_Sql = gs_Sql & "  RETIRO_PME ROP,"
        gs_Sql = gs_Sql & "  TICKET..OPERACION O left outer join TICKET..REPORTE_OPERACION RO on O.operacion = RO.operacion,"
        gs_Sql = gs_Sql & "  PRODUCTO_CONTRATADO PC,"
        gs_Sql = gs_Sql & "  OPERACION_DEFINIDA OD"
        gs_Sql = gs_Sql & " Where"
        gs_Sql = gs_Sql & "  OD.operacion_definida_global = 89"
        gs_Sql = gs_Sql & "  and O.status_operacion <> 250"
        gs_Sql = gs_Sql & "  and O.status_operacion >= 2"
        gs_Sql = gs_Sql & "  and O.operacion = ROP.operacion"
        gs_Sql = gs_Sql & "  and O.fecha_operacion > '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 00:00:00'"      'Fecha "HOY"
        gs_Sql = gs_Sql & "  and O.fecha_operacion < '" & CDate(gs_FechaHoy).Year & "-" & CDate(gs_FechaHoy).Month & "-" & CDate(gs_FechaHoy).Day & " 23:59:59'"      'Fecha "HOY"
        gs_Sql = gs_Sql & "  and O.producto_contratado = PC.producto_contratado"
        gs_Sql = gs_Sql & "  and O.operacion_definida=OD.operacion_definida"
        gs_Sql = gs_Sql & "  and OD.agencia = " & mnAgencia
        gs_Sql = gs_Sql & " Order By"
        gs_Sql = gs_Sql & "  O.operacion"
    End Sub
    '----------------------------------------------------------------------------
    'Llena una lista de Tipo ListView con el Query Determinado
    '----------------------------------------------------------------------------
    'Public Sub LlenaLista(ObjetoLista As ListView, Titulos As String, Query As String, MultiSelect As Boolean, Sorted As Boolean, AutoWidth As Boolean, Optional Imagenes, Optional LowCase, Optional MoneyColumns, Optional FormatStrings)
    Public Sub LlenaLista(Titulos As String, Query As String, MultiSelect As Boolean, Sorted As Boolean, AutoWidth As Boolean, Optional Imagenes As Integer = 0, Optional LowCase As Integer = 0, Optional MoneyColumns As String = "", Optional FormatStrings As String = "")
        Dim lc_Columna As ColumnHeader
        'Dim li_LstDato As ListItem
        Dim ls_Titulos As String
        Dim ln_Titulos As Integer
        Dim ln_Next As Integer
        Dim ln_Separador As Integer
        Dim lb_Imagenes As Boolean
        Dim lb_LowCase As Boolean
        Dim ls_MoneyCol As String
        Dim ls_Datos As String
        Dim ls_Formato As String
        Dim ls_Formats As String
        Dim dtRespConsulta As New DataTable

        lb_Imagenes = False
        lb_LowCase = False

        If Not IsNothing(Imagenes) Then
            'Incorpora Imagenes
            If Val(Imagenes) <> 0 Then lb_Imagenes = True
        End If

        If Not IsNothing(LowCase) Then
            'Convierte texto a LowCaseText
            If Val(LowCase) <> 0 Then lb_LowCase = True
        End If

        If Not IsNothing(MoneyColumns) Then
            ls_MoneyCol = CStr(MoneyColumns)
        Else
            ls_MoneyCol = ""
        End If

        If Not IsNothing(FormatStrings) Then
            ls_Formats = CStr(FormatStrings)
        Else
            ls_Formats = ""
        End If

        On Error GoTo ErrorDeclaration

        'ObjetoLista.Arrange = 2
        'ObjetoLista.HideColumnHeaders = False
        'ObjetoLista.MultiSelect = MultiSelect
        'ObjetoLista.Sorted = Sorted
        'ObjetoLista.View = 3

        ln_Titulos = 1

        'Cuenta el numero de titulos
        For ln_Separador = 1 To Len(Titulos)
            If Mid$(Titulos, ln_Separador, 1) = "&" Then ln_Titulos = ln_Titulos + 1
        Next ln_Separador

        'Borra el contenido de la lista
        'ObjetoLista.ListItems.Clear
        dgvOperac.DataSource = Nothing

        'Si se requiere autowidth borra las columnas existentes
        'If AutoWidth = True Then
        '    For ln_Separador = ObjetoLista.ColumnHeaders.Count To 1 Step -1
        '        ObjetoLista.ColumnHeaders.Remove ln_Separador
        'Next ln_Separador
        'End If

        'Verifica si la lista ya tiene columnas
        'If ObjetoLista.ColumnHeaders.Count <= 0 Then
        '    ls_Titulos = Trim$(Titulos)
        '    If ln_Titulos > 1 Then
        '        ls_Titulos = ""
        '        For ln_Separador = 1 To Len(Titulos)
        '            If Mid$(Titulos, ln_Separador, 1) = "&" Then
        '            Set lc_Columna = ObjetoLista.ColumnHeaders.Add(, , ls_Titulos, (ObjetoLista.Width - 950) / ln_Titulos)
        '            ls_Titulos = ""
        '            Else
        '                ls_Titulos = ls_Titulos & Mid$(Titulos, ln_Separador, 1)
        '            End If
        '        Next ln_Separador
        '    Set lc_Columna = ObjetoLista.ColumnHeaders.Add(, , ls_Titulos, (ObjetoLista.Width - 1000) / ln_Titulos)
        ' Else
        '    Set lc_Columna = ObjetoLista.ColumnHeaders.Add(, , ls_Titulos, ObjetoLista.Width - 400)
        'End If
        'End If

        'DGI (EDS) Para el reporte de Depositos SBF.
        Dim intColumnas As Integer, intTotal As Integer, i As Integer
        Dim strTitulos() As String
        'If ObjetoLista.ColumnHeaders.Count < ln_Titulos Then
        If dgvOperac.Columns.Count < ln_Titulos Then
            'intColumnas = ln_Titulos - ObjetoLista.ColumnHeaders.Count
            intColumnas = ln_Titulos - dgvOperac.Columns.Count
            strTitulos = Split(Titulos, "&")
            'intTotal = ObjetoLista.ColumnHeaders.Count
            intTotal = dgvOperac.Columns.Count
            'For i = 0 To intColumnas - 1
            '    'Set lc_Columna = ObjetoLista.ColumnHeaders.Add(, , strTitulos(i + intTotal), (ObjetoLista.Width - 950) / ln_Titulos)
            '    'lc_Columna = dgvOperac.Columns.Add("", "", strTitulos(i + intTotal), (dgvOperac.Width - 950) / ln_Titulos)
            'Next
            'ElseIf ObjetoLista.ColumnHeaders.Count > ln_Titulos Then
        ElseIf dgvOperac.Columns.Count > ln_Titulos Then
            intColumnas = dgvOperac.Columns.Count - ln_Titulos
            intTotal = dgvOperac.Columns.Count
            For i = 0 To intColumnas - 1
                dgvOperac.Columns.Remove(1 + ln_Titulos)
            Next
        End If

        'Ejecuta el Query y llena la lista
        'dbExecQuery(Query)
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbGetRecord
        'If dbError() = 0 Then
        '    Do While dbError() = 0
        '        'Si se deben formatear los textos a Mayus/Minus
        '        If lb_LowCase Then
        '            ls_Datos = LowCaseName(dbGetValue(0))
        '            'Si hay columnas con formato de moneda
        '        ElseIf ls_MoneyCol <> "" Then
        '            If InStr(ls_MoneyCol, "+0") > 0 Then
        '                ls_Datos = Format$(dbGetValue(0), "###,###,###,##0.00")
        '            Else
        '                ls_Datos = Trim$(dbGetValue(0))
        '            End If
        '        Else
        '            ls_Datos = Trim$(dbGetValue(0))
        '        End If
        '        'Si hay columnas con formatos especiales
        '        If ls_Formats <> "" Then
        '            If InStr(ls_Formats, "+0-") > 0 Then
        '                ls_Formato = Mid$(ls_Formats, InStr(ls_Formats, "+0") + 3)
        '                ln_Next = InStr(ls_Formato, "+")
        '                If ln_Next > 0 Then
        '                    ls_Formato = Left$(ls_Formato, InStr(ls_Formato, "+") - 1)
        '                End If
        '                ls_Datos = Format$(ls_Datos, ls_Formato)
        '            End If
        '        End If
        '        'Si la lista lleva imagenes
        '        If lb_Imagenes Then
        '        Set li_LstDato = ObjetoLista.ListItems.Add(, , ls_Datos, 1, 1)
        '     'Si la lista no lleva imagenes
        '     Else
        '        Set li_LstDato = ObjetoLista.ListItems.Add(, , ls_Datos)
        '    End If
        '        'Si hay mas de una columna en la lista
        '        If ln_Titulos > 1 Then
        '            For ln_Separador = 1 To ln_Titulos - 1
        '                'Si se deben formatear los textos a Mayus/Minus
        '                If lb_LowCase Then
        '                    ls_Datos = LowCaseName(dbGetValue(ln_Separador))
        '                    'Si hay columnas con formato de moneda
        '                ElseIf ls_MoneyCol <> "" Then
        '                    If InStr(ls_MoneyCol, "+" & CStr(ln_Separador)) > 0 Then
        '                        ls_Datos = Format$(dbGetValue(ln_Separador), "###,###,###,##0.00")
        '                    Else
        '                        ls_Datos = Trim$(dbGetValue(ln_Separador))
        '                    End If
        '                Else
        '                    ls_Datos = Trim$(dbGetValue(ln_Separador))
        '                End If
        '                'Si hay columnas con formatos especiales
        '                If ls_Formats <> "" Then
        '                    If InStr(ls_Formats, "+" & CStr(ln_Separador) & "-") > 0 Then
        '                        ls_Formato = Mid$(ls_Formats, InStr(ls_Formats, "+" & CStr(ln_Separador)) + 3)
        '                        ln_Next = InStr(ls_Formato, "+")
        '                        If ln_Next > 0 Then
        '                            ls_Formato = Left$(ls_Formato, InStr(ls_Formato, "+") - 1)
        '                        End If
        '                        ls_Datos = Format$(ls_Datos, ls_Formato)
        '                    End If
        '                End If
        '                li_LstDato.SubItems(ln_Separador) = ls_Datos
        '            Next ln_Separador
        '        End If
        '        dbGetRecord
        '    Loop
        'End If

        If dtRespConsulta.Rows.Count > 0 Then
            dgvOperac.DataSource = dtRespConsulta
            dgvOperac.AllowUserToAddRows = False
            If rbtPC.Checked Then
                dgvOperac.Columns("monto_operacion").DefaultCellStyle.Format = "N2"
                dgvOperac.Columns(0).HeaderText = "Ticket"
                dgvOperac.Columns(1).HeaderText = "Cuenta"
                dgvOperac.Columns(2).HeaderText = "Monto"
                dgvOperac.Columns(3).HeaderText = "Status"
                dgvOperac.Columns(4).HeaderText = "Fecha Vencimiento"
                dgvOperac.Columns(5).HeaderText = "Fecha Operacion"
            End If
        Else
            dgvOperac.DataSource = Nothing
            'MsgBox("No se encontraron registros")
        End If

SalidaDeclaration:
        'dbEndQuery
        Exit Sub
ErrorDeclaration:
        If Err.Number = 380 Then
            MsgBox("No coincide el numero de columnas con los resultados del Query.", vbCritical, "Error")
        Else
            MsgBox("Error de Ejecución: " & Err.Description, vbCritical, "Error")
        End If
        Resume SalidaDeclaration
    End Sub
    Public Sub Reporte(ByVal Tipo As Byte)

        mnTipoRep = Tipo
        Select Case mnTipoRep
            Case 2
                Me.Text = "Retiros por Sucursal del Día"
            Case 3
                Me.Text = "Depósitos por Sucursal en Firme del Día"
            Case 4
                Me.Text = "Retiros por Devolución de Cheques del Día"
            Case 5
                'Me.Caption = "Depósitos por Sucursal S.B.F. del Día"
                Me.Text = "Depósitos por Sucursal S.B.F."
                SSPSBF.Visible = True
            Case 6
                Me.Text = "Compras de TD's del Día"
            Case 7
                Me.Text = "Compras de TD's del Día"
            Case 8
                Me.Text = "Aperturas del Día"
            Case 9
                Me.Text = "Aperturas Validadas del Día"
            Case 10
                Me.Text = "Aperturas del Día"
            Case 11
                Me.Text = "Traspasos Misma Agencia del Día"
            Case 12
                Me.Text = "Depósitos Area Interna en Firme del Día"
            Case 13
                Me.Text = "Retiros Area Interna del Día"
            Case 14
                Me.Text = "Traspasos Entre Agencias del Día"
            Case 15
                Me.Text = "Depósitos Area Interna 24 Hrs. del Día"
            Case 16
                Me.Text = "Depósitos Area Interna S.B.F. del Día"
            Case 17
                Me.Text = "Depósitos por Sucursal 24 Horas del Día"
        End Select
        Me.Show()
    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        Dim ls_PorImprimir As String
        Dim ln_Indice As Integer
        Dim ln_NumOps As Integer
        Dim Agencia As String
        Dim bRegistrosSeleccionados As Boolean
        Dim dtRespConsulta As DataTable
        Dim rptDoc As New ReportDocument
        Dim ArchReimpresion As String = "Depo_Ret_General.pdf"
        Dim sNumRep As String = ""
        Dim lsAmbiente As String = ""
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        'For ln_Indice = 1 To lstOperac.ListItems.Count
        '    If lstOperac.ListItems(ln_Indice).Selected Then
        '        GoTo EmiteImpresion
        '        Exit For
        '    End If
        'Next ln_Indice
        'If MsgBox("No hay operaciones seleccionadas, ¿desea imprimir todas las operaciones de la lista?", vbQuestion + vbYesNo, "Impresión") = vbNo Then Exit Sub
        'For ln_Indice = 1 To lstOperac.ListItems.Count
        '    lstOperac.ListItems(ln_Indice).Selected = True
        'Next ln_Indice
        If dgvOperac.SelectedRows.Count > 0 Then
            'For Each dgvrRegistroSeleccionado As DataGridViewRow In dgvOperac.SelectedRows
            bRegistrosSeleccionados = True
            GoTo EmiteImpresion
            'Next
        Else
            If MsgBox("No hay operaciones seleccionadas, ¿desea imprimir todas las operaciones de la lista?", vbQuestion + vbYesNo, "Impresión") = vbNo Then
                Exit Sub
            Else
                bRegistrosSeleccionados = False
                GoTo EmiteImpresion
            End If
        End If

EmiteImpresion:
        'Screen.MousePointer = vbHourglass
        cmdImprimir.Enabled = False
        ls_PorImprimir = ""
        ln_NumOps = 0
        cmdImprimir.Visible = False
        cmdCancel.Visible = False
        pgbCarga.Visible = True
        lbGenArch.Visible = True
        pgbCarga.Maximum = 4
        pgbCarga.Value = 1
        'For ln_Indice = 1 To lstOperac.ListItems.Count
        '    If lstOperac.ListItems(ln_Indice).Selected Then
        '        RegistraOpImpresa(lstOperac.ListItems(ln_Indice).text)
        '        If ls_PorImprimir = "" Then
        '            ls_PorImprimir = lstOperac.ListItems(ln_Indice).text
        '        Else
        '            If Right(Trim(ls_PorImprimir), 1) = "]" Then
        '                ls_PorImprimir = ls_PorImprimir & " or {OPERACION.operacion} in [" & lstOperac.ListItems(ln_Indice).text
        '            Else
        '                ls_PorImprimir = ls_PorImprimir & ", " & lstOperac.ListItems(ln_Indice).text
        '            End If
        '        End If
        '        ln_NumOps = ln_NumOps + 1
        '        If ln_NumOps Mod 20 = 0 Then
        '            ls_PorImprimir = ls_PorImprimir & "]"
        '        End If
        '    End If
        'Next ln_Indice
        If bRegistrosSeleccionados Then
            For Each dgvrRegistroSeleccionado As DataGridViewRow In dgvOperac.SelectedRows
                RegistraOpImpresa(dgvrRegistroSeleccionado.Cells(0).Value)
                If ls_PorImprimir = "" Then
                    ls_PorImprimir = dgvrRegistroSeleccionado.Cells(0).Value
                Else
                    If Microsoft.VisualBasic.Right(Trim(ls_PorImprimir), 1) = "]" Then
                        ls_PorImprimir = ls_PorImprimir & " or {OPERACION.operacion} in [" & dgvrRegistroSeleccionado.Cells(0).Value
                    Else
                        ls_PorImprimir = ls_PorImprimir & ", " & dgvrRegistroSeleccionado.Cells(0).Value
                    End If
                End If
                ln_NumOps = ln_NumOps + 1
                If ln_NumOps Mod 20 = 0 Then
                    ls_PorImprimir = ls_PorImprimir & "]"
                End If
            Next
        Else
            For Each dgvrRegistroSeleccionado As DataGridViewRow In dgvOperac.Rows
                RegistraOpImpresa(dgvrRegistroSeleccionado.Cells(0).Value)
                If ls_PorImprimir = "" Then
                    ls_PorImprimir = dgvrRegistroSeleccionado.Cells(0).Value
                Else
                    If Microsoft.VisualBasic.Right(Trim(ls_PorImprimir), 1) = "]" Then
                        ls_PorImprimir = ls_PorImprimir & " or {OPERACION.operacion} in [" & dgvrRegistroSeleccionado.Cells(0).Value
                    Else
                        ls_PorImprimir = ls_PorImprimir & ", " & dgvrRegistroSeleccionado.Cells(0).Value
                    End If
                End If
                ln_NumOps = ln_NumOps + 1
                If ln_NumOps Mod 20 = 0 Then
                    ls_PorImprimir = ls_PorImprimir & "]"
                End If
            Next
        End If
        pgbCarga.Value = 2
ImprimeReporte:
        If ls_PorImprimir = "" Then GoTo FinReporte
        If Microsoft.VisualBasic.Right(Trim(ls_PorImprimir), 1) = "]" Then
            ls_PorImprimir = "[" & ls_PorImprimir
        Else
            ls_PorImprimir = "[" & ls_PorImprimir & "]"
        End If
        ls_PorImprimir = "({OPERACION.operacion} in " & ls_PorImprimir & ")"
        lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
        If rbtFOH.Checked = True Then
            'rptDoc = New Depo_Ret_General
            lsReporte = lsRutaFolder & "Depo_Ret_General" & lsAmbiente & ".rpt"
            rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
        Else
            'rptDoc = New rptDepSucSBFPendientes
            lsReporte = lsRutaFolder & "rptDepSucSBFPendientes" & lsAmbiente & ".rpt"
            rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
        End If

        objLibreria.logonBDreporte(rptDoc, 1)
        'Report.Formulas(0) = "FechaHoy = '" & InvierteFecha(gs_FechaHoy) & "'"
        rptDoc.DataDefinition.FormulaFields.Item("FechaHoy").Text = "'" & Trim(gs_FechaHoy) & "'"
        Select Case mnTipoRep
            Case 2 'Si la seleccion fue Retiro PME  ***
                'Report.ParameterFields(0) = "pTitulo;" & "RETIROS POR SUCURSAL" & ";TRUE"
                'Agencia = GetAgencia(mnAgencia)
                'Report.ParameterFields(1) = "pAgencia;" & Agencia & ";TRUE"
                'Report.ParameterFields(2) = "pTotal;" & "Total Depósitos (USD):" & ";TRUE"
                'Report.ReportFileName = GPATH & "\Depo_Ret_General.rpt"
                'Report.SelectionFormula = Report.SelectionFormula & ls_PorImprimir
                'Report.SelectionFormula = Report.SelectionFormula & " and {OPERACION.status_operacion} in [2,3,4,5,6, 7, 12, 16] "
                'Report.SelectionFormula = Report.SelectionFormula & " and {PRODUCTO_CONTRATADO.agencia}= " & mnAgencia
            'Si la seleccion fue Deposito Sucursal en Firme
            Case 3
                'Report.ParameterFields(0) = "pTitulo;" & "RETIROS POR SUCURSAL" & ";TRUE"
                'Agencia = GetAgencia(mnAgencia)
                'Report.ParameterFields(1) = "pAgencia;" & Agencia & ";TRUE"
                'Report.ParameterFields(2) = "pTotal;" & "Total Depósitos (USD):" & ";TRUE"
                'Report.ReportFileName = GPATH & "\Depo_Ret_General.rpt"
                'Report.SelectionFormula = Report.SelectionFormula & ls_PorImprimir
                'rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & ls_PorImprimir
            'Si la seleccion fue Deposito Sucursal S.B.F.
            Case 5
                'DGI (EDS)
                'If optSBF(0).Value Then
                If rbtFOH.Checked = True Then
                    'Report.ParameterFields(0) = "pTitulo;" & "DEPÓSITOS POR SUCURSAL SALVO BUEN FIN" & ";TRUE"
                    rptDoc.SetParameterValue("pTitulo", "DEPÓSITOS POR SUCURSAL SALVO BUEN FIN")
                    'Report.ReportFileName = GPATH & "\Depo_Ret_General.rpt"
                    ArchReimpresion = "Depo_Ret_General.pdf"
                Else
                    'Report.ParameterFields(0) = "pTitulo;" & "DEPÓSITOS POR SUCURSAL SALVO BUEN FIN" & ";TRUE"
                    rptDoc.SetParameterValue("pTitulo", "DEPÓSITOS POR SUCURSAL SALVO BUEN FIN")
                    'Report.ParameterFields(3) = "pSubtitulo;" & "-PENDIENTES POR CONFIRMAR-" & ";TRUE"
                    rptDoc.SetParameterValue("pSubtitulo", "-PENDIENTES POR CONFIRMAR-")
                    'Report.ReportFileName = GPATH & "\rptDepSucSBFPendientes.rpt"
                    ArchReimpresion = "rptDepSucSBFPendientes.pdf"
                End If
                Agencia = GetAgencia(mnAgencia)
                'Report.ParameterFields(1) = "pAgencia;" & Agencia & ";TRUE"
                rptDoc.SetParameterValue("pAgencia", Agencia)
                'Report.ParameterFields(2) = "pTotal;" & "Total Depósitos (USD):" & ";TRUE"
                rptDoc.SetParameterValue("pTotal", "Total Depósitos (USD):")
                'Report.SelectionFormula = Report.SelectionFormula & ls_PorImprimir
                rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & ls_PorImprimir
            'Si la seleccion fue TDs
            Case 6
                'Report.ReportFileName = GPATH & "\compras_TD.rpt"
                'Report.SelectionFormula = ls_PorImprimir
                'Report.SelectionFormula = Report.SelectionFormula & " and {PRODUCTO_CONTRATADO.agencia}= " & mnAgencia
                lsReporte = lsRutaFolder & "compras_TD" & lsAmbiente & ".rpt"
                rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                rptDoc.RecordSelectionFormula = ls_PorImprimir
                rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & " and {PRODUCTO_CONTRATADO.agencia}= " & mnAgencia
            'Si la selección fue TDs en lista
            Case 7
                'Report.ReportFileName = GPATH & "\compras_TD_lista.rpt"
                'rptDoc = New compras_TD_lista
                lsReporte = lsRutaFolder & "compras_TD_lista" & lsAmbiente & ".rpt"
                rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                rptDoc.RecordSelectionFormula = ls_PorImprimir
                rptDoc.RecordSelectionFormula = rptDoc.RecordSelectionFormula & " and {PRODUCTO_CONTRATADO.agencia}= " & mnAgencia
            'Si la seleccion fue Aperturas
            Case 8
                'BAGO-EDS-07/MZO/06
                'La fórmula "FechaHoy" no existe en el reporte Aperturas_Back. Se cambia por "FechaInicio"
                'Report.Formulas(0) = "FechaInicio = '" & InvierteFecha(gs_FechaHoy) & "'"
                'Report.ReportFileName = GPATH & "\Aperturas_Back.rpt "
                'Report.SelectionFormula = ls_PorImprimir
                'Report.SelectionFormula = Report.SelectionFormula & " and {PRODUCTO_CONTRATADO.agencia}= " & mnAgencia
                'Agencia = GetAgencia(mnAgencia)
                'Report.ParameterFields(0) = "pAgencia;" & Agencia & ";TRUE"
            'Si la seleccion fue Aperturas Validadas
            Case 9
                'Report.ReportFileName = GPATH & "\aper_ticket.rpt"
                'Report.SelectionFormula = ls_PorImprimir
                'Report.SelectionFormula = Report.SelectionFormula & " and {PRODUCTO_CONTRATADO.agencia}= " & mnAgencia
                'Agencia = GetAgencia(mnAgencia)
                'Report.ParameterFields(0) = "pAgencia;" & Agencia & ";TRUE"
            'Si la seleccion fue Aperutas del dia
            Case 10
                'Report.ReportFileName = GPATH & "\Aperturas_Back.rpt "
                'Report.SelectionFormula = ls_PorImprimir
                'Report.SelectionFormula = Report.SelectionFormula & " and {PRODUCTO_CONTRATADO.agencia}= " & mnAgencia
                'Agencia = GetAgencia(mnAgencia)
                'Report.ParameterFields(0) = "pAgencia;" & Agencia & ";TRUE"
            'Si la seleccion fue Traspasos
            Case 11, 14
                'Agencia = GetAgencia(mnAgencia)
                'Report.ReportFileName = GPATH & "\traspasosagencias.rpt"
                'Report.SelectionFormula = ls_PorImprimir
                'Report.SelectionFormula = Report.SelectionFormula & " and {PRODUCTO_CONTRATADO.agencia}= " & mnAgencia
                'Report.ParameterFields(0) = "pAgencia;" & Agencia & ";TRUE"
            'Si la selección fue Depósitos Areas Internas en Firme
            Case 12
                'Report.ParameterFields(0) = "pTitulo;" & "DEPÓSITOS POR ÁREA INTERNA EN FIRME" & ";TRUE"
                'Agencia = GetAgencia(mnAgencia)
                'Report.ParameterFields(1) = "pAgencia;" & Agencia & ";TRUE"
                'Report.ParameterFields(2) = "pTotal;" & "Total Depósitos (USD):" & ";TRUE"
                'Report.ReportFileName = GPATH & "\Depo_Ret_General.rpt"
                'Report.SelectionFormula = Report.SelectionFormula & ls_PorImprimir
            'Si la selección fue Retiros Areas Internas
            Case 13
                'Report.ParameterFields(0) = "pTitulo;" & "RETIROS POR ÁREA INTERNA" & ";TRUE"
                'Agencia = GetAgencia(mnAgencia)
                'Report.ParameterFields(1) = "pAgencia;" & Agencia & ";TRUE"
                'Report.ParameterFields(2) = "pTotal;" & "Total Retiros (USD):" & ";TRUE"
                'Report.ReportFileName = GPATH & "\Depo_Ret_General.rpt"
                'Report.SelectionFormula = Report.SelectionFormula & ls_PorImprimir
                'Report.SelectionFormula = Report.SelectionFormula & " and {OPERACION.status_operacion} in [2,3,4,5,6, 7, 12, 16] "
            'Si la selección fue Depósitos Areas Internas 24 Hrs.
            Case 15
                'Report.ParameterFields(0) = "pTitulo;" & "DEPÓSITOS ÁREA INTERNA 24 HORAS" & ";TRUE"
                'Agencia = GetAgencia(mnAgencia)
                'Report.ParameterFields(1) = "pAgencia;" & Agencia & ";TRUE"
                'Report.ParameterFields(2) = "pTotal;" & "Total Depósitos (USD):" & ";TRUE"
                'Report.ReportFileName = GPATH & "\Depo_Ret_General.rpt"
                'Report.SelectionFormula = Report.SelectionFormula & ls_PorImprimir
            'Si la selección fue Depósitos Areas Internas S.B.F.
            Case 16
                'Report.ParameterFields(0) = "pTitulo;" & "DEPÓSITOS POR ÁREA INTERNA SALVO BUEN FIN" & ";TRUE"
                'Agencia = GetAgencia(mnAgencia)
                'Report.ParameterFields(1) = "pAgencia;" & Agencia & ";TRUE"
                'Report.ParameterFields(2) = "pTotal;" & "Total Depósitos (USD):" & ";TRUE"
                'Report.ReportFileName = GPATH & "\Depo_Ret_General.rpt"
                'Report.SelectionFormula = Report.SelectionFormula & ls_PorImprimir
            'Si la seleccion fue Deposito Sucursal 24 Hrs.
            Case 17
                'Report.ParameterFields(0) = "pTitulo;" & "DEPÓSITOS POR SUCURSAL 24 HORAS" & ";TRUE"
                'Agencia = GetAgencia(mnAgencia)
                'Report.ParameterFields(1) = "pAgencia;" & Agencia & ";TRUE"
                'Report.ParameterFields(2) = "pTotal;" & "Total de Depósitos:" & ";TRUE"
                'Report.ReportFileName = GPATH & "\Depo_Ret_General.rpt"
                'Report.SelectionFormula = Report.SelectionFormula & ls_PorImprimir

        End Select
        'MuestraVentanaReporte Report
        pgbCarga.Value = 3
        'rptDoc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.Desktop & "\S_B_F\" & ArchReimpresion)
        opcionReporte = 16
        RepOperativa.reporteOFAC = rptDoc
        RepOperativa.ShowDialog()
        pgbCarga.Value = 4
FinReporte:
        ls_PorImprimir = ""
        'rptDoc.Formulas(1) = ""
        rptDoc.FileName = ""
        'rptDoc.RecordSelectionFormula = ""
        cmdImprimir.Enabled = True
        'Screen.MousePointer = vbDefault
        cmdImprimir.Visible = True
        cmdCancel.Visible = True
        pgbCarga.Visible = False
        lbGenArch.Visible = False

    End Sub
    Private Sub RegistraOpImpresa(ByVal Operacion As String)
        Dim dtRespConsulta As DataTable
        Dim iRegistrosInsertados As Integer
        gs_Sql = "Select count(*) from TICKET..REPORTE_OPERACION where operacion = " & Operacion
        'dbExecQuery gs_Sql
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbGetRecord
        'If Val(dbGetValue(0)) = 0 Then
        If dtRespConsulta.Rows.Count = 0 Then
            'dbEndQuery
            gs_Sql = "Insert into REPORTE_OPERACION"
            gs_Sql = gs_Sql & " (operacion , impreso )"
            gs_Sql = gs_Sql & " values(" & Operacion & " , 1)"
            'dbExecQuery gs_Sql
            iRegistrosInsertados = objDatasource.insertar(gs_Sql)
            'If dbError Then
            If iRegistrosInsertados <= 0 Then
                MsgBox("Ha ocurrido un error al marcar la operación " & Operacion & " como impresa.  Se recomienda volver a imprimirla.", vbOKOnly + vbCritical, "Error de Base de Datos")
            End If
        End If
        'dbEndQuery
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Dim sTitulo As String

        Select Case mnTipoRep
            Case 5
                sTitulo = "Salir del apartado Depósitos por Sucursal S.B.F."
            Case 7
                sTitulo = "Salir del apartado Compra de TDs"
        End Select
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, sTitulo) <> vbYes Then
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub

    '**********************************************************************************
    'GetAgencia obtiene la descripción de una agencia determinada.
    'Creada por SVM, Modificada por CEB 14-02-2002
    'CEB - Protegi la funcion contra posibles errores y elimine una variable inecesaria
    '**********************************************************************************
    Public Function GetAgencia(ByVal idAgencia As String) As String
        Dim dtRespConsulta As DataTable

        On Error GoTo errGetAgencia

        gs_Sql = "SELECT descripcion_agencia FROM " & "CATALOGOS" & "..AGENCIA " &
                " WHERE agencia = " & idAgencia
        'dbExecQuery gs_Sql
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbGetRecord
        'If Not IsdbError Then
        If dtRespConsulta.Rows.Count > 0 Then
            'GetAgencia = dbGetValue(0)
            GetAgencia = dtRespConsulta.Rows(0).Item(0)
        Else
            GetAgencia = ""
        End If
        'dbEndQuery
        Exit Function

errGetAgencia:
        MsgBox(Err.Number & " " & Err.Description, vbCritical, "Error")
        GetAgencia = ""

    End Function
End Class