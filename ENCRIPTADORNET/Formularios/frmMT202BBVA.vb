Imports System.Data.OleDb '--------------- Pruebas de mt202

Public Class frmMT202BBVA
    Dim lb_ExisteDef As Boolean
    Dim la_Reportes() As Long
    Dim ls_Tipo As String
    'Dim Ls_Siglas(1 To 3) As String
    Dim Ls_Siglas(3) As String

    Private Const sRetirosCayman As String = "86,83,87,97,94,88,89"
    'Private Const sRetirosNYLA As String = "83,87,97,86,94,88,89"
    'Se agregan operaciones definidas de Tarjeta de Débito CED
    Private Const sRetirosNYLA As String = "83,87,97,86,94,88,89, 52, 53, 54, 56, 57, 58, 59"
    'Private Const sDepositos As String = "583,584,587,597,585,588,589,590,591,592"
    Private Const sDepositos As String = "583,584,587,597,585,588,589,590,591,592, 552, 553, 559"

    Private objDatasource As New Datasource
    Private objLibreria As New Libreria

    Private Sub frmMT202BBVA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'lmc 24-may-2002 Cambio de imagen de la forma
        'CargarColores Me, cambio
        'Centerform Me
        LlenaCampos()
        Habilita_definitivo()
    End Sub
    '------------------------------------------------------
    'Obtiene las descripciones de las Agencias y su número
    '------------------------------------------------------
    Private Sub LlenaCampos()
        Dim dtRespConsulta As New DataTable()
        gs_Sql = "select descripcion_agencia, agencia "
        gs_Sql = gs_Sql & " from " & "CATALOGOS.dbo.AGENCIA WITH (NOLOCK) where agencia = 1 order by agencia"
        'dbExecQuery(gs_Sql)
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        '    Do While Not dbError()
        '        ComboAgencias.AddItem dbGetValue(0)
        'ComboAgencias.ItemData(ComboAgencias.NewIndex) = dbGetValue(1)
        '        dbGetRecord
        '    Loop
        '    dbEndQuery
        '    If ComboAgencias.ListCount > 0 Then ComboAgencias.ListIndex = 0
        ComboAgencias.DisplayMember = "descripcion_agencia"
        ComboAgencias.ValueMember = "agencia"
        ComboAgencias.DataSource = dtRespConsulta
        ComboAgencias.SelectedValue = 1
    End Sub
    '-------------------------------------------------------------
    'Verifica si ya se envio algun MT202 definitivo
    '-------------------------------------------------------------
    Private Sub Habilita_definitivo()
        Dim dtRespConsulta As New DataTable()
        If ComboAgencias.SelectedValue <= 0 Then Exit Sub
        gs_Sql = "select count(*) from REPORTES_EMITIDOS_MT202 RE WITH (NOLOCK)"
        gs_Sql = gs_Sql & " where RE.fecha_reporte = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
        'gs_Sql = gs_Sql & " and RE.agencia = " & ComboAgencias.ItemData(ComboAgencias.ListIndex)
        gs_Sql = gs_Sql & " and RE.agencia = " & ComboAgencias.SelectedValue
        gs_Sql = gs_Sql & " and RE.tipo_202 = 1 and bbvab = 1"
        'Obtiene el No. de operaciones en REPORTES_EMITIDOS_MT202 con fecha_reporte = hoy y tipo_202 = 1 (corte parcial)
        'dbExecQuery(gs_Sql)
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'If Not IsdbError Then
        If IsNothing(dtRespConsulta) = False Then
            'ya se mando alguna vez el definitivo
            'If Val(dbGetValue(0)) > 0 Then
            If dtRespConsulta.Rows(0).Item(0) > 0 Then
                'dbEndQuery
                chkEnvioDef.Enabled = False
                lb_ExisteDef = True
            Else
                'dbEndQuery
                If CDate(gs_HoraSistema) > CDate("12:00") Then chkEnvioDef.Enabled = True
                lb_ExisteDef = False
            End If
        Else
            MsgBox(" Ha ocurrido un error con la tabla de envios")
            'dbEndQuery
        End If
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        pbProceso.Visible = True
        pbProceso.Maximum = 10
        Dim dtRespConsulta As New DataTable()
        Dim ln_Respuesta As Byte
        Dim ln_Suma As Long = -1

        dtRespConsulta = objDatasource.RealizaConsulta("SELECT convert(char(5),getdate(),14)")
        gs_HoraSistema = dtRespConsulta.Rows(0).Item(0).ToString

        cmdAceptar.Enabled = False
        'Screen.MousePointer = vbHourglass
        ln_Suma = 0
        Habilita_definitivo()
        'If ComboAgencias.ListIndex = -1 Then Exit Sub
        If ComboAgencias.SelectedValue = -1 Then Exit Sub
        If OperacionesPorEnviarAgenciaBBVA(Val(ComboAgencias.SelectedValue)) Then
            If MsgBox("Aún faltan operaciones por enviar para esta agencia. ¿Desea continuar?",
                vbQuestion + vbYesNo, "Reporte MT202") = vbNo Then
                Exit Sub
            End If
        End If
        pbProceso.Value = 1
        gs_Sql = " select count(*)  "
        gs_Sql = gs_Sql & " from REPORTE_SWIFT RS, OPERACION_SWIFT OS, OPERACION O,  " & "FUNCIONARIOS" & "..FUNCIONARIO F"
        gs_Sql = gs_Sql & " where RS.no_rep_swift = OS.no_rep_swift "
        'gs_Sql = gs_Sql & " and RS.agencia = " & ComboAgencias.ItemData(ComboAgencias.ListIndex)
        gs_Sql = gs_Sql & " and RS.agencia = " & ComboAgencias.SelectedValue
        gs_Sql = gs_Sql & " and O.funcionario = F.funcionario "
        gs_Sql = gs_Sql & " and O.operacion = OS.operacion "
        gs_Sql = gs_Sql & " and RS.status_reporte in (2,3,4,5) "
        gs_Sql = gs_Sql & " and F.bbvab = 1 "   ' sólo operaciones realizadas con funcionarios que operan en suc migradas
        gs_Sql = gs_Sql & " and RS.fecha_reporte='" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "' "
        'dbExecQuery(gs_Sql)  ' Obtiene el No. de operaciones que se encuentran en REPORTE_SWIFT con fecha_reporte = hoy
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'If Not IsdbError Then
        If IsNothing(dtRespConsulta) = False Then
            If Val(dtRespConsulta.Rows(0).Item(0)) > 0 Then
                ln_Suma = Val(dtRespConsulta.Rows(0).Item(0))
            End If
            'dbEndQuery
        Else
            MsgBox("Ocurrió un error al intentar accesar la base de datos.")
            'dbEndQuery
            Exit Sub
        End If
        pbProceso.Value = 2
        gs_Sql = " select count(*)  "
        gs_Sql = gs_Sql & " from REPORTE_SWIFT RS, OPERACION_SWIFT OS, OPERACION O "
        gs_Sql = gs_Sql & " where RS.no_rep_swift = OS.no_rep_swift "
        'gs_Sql = gs_Sql & " and RS.agencia = " & ComboAgencias.ItemData(ComboAgencias.ListIndex)
        gs_Sql = gs_Sql & " and RS.agencia = " & ComboAgencias.SelectedValue
        gs_Sql = gs_Sql & " and O.funcionario is null "
        gs_Sql = gs_Sql & " and O.operacion = OS.operacion "
        gs_Sql = gs_Sql & " and RS.status_reporte in (2,3,4,5) "
        gs_Sql = gs_Sql & " and RS.fecha_reporte='" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "' "
        '*******
        'dbExecQuery(gs_Sql)  ' Obtiene el No. de operaciones que se encuentran en REPORTE_SWIFT con fecha_reporte = hoy
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'If Not IsdbError Then
        If IsNothing(dtRespConsulta) = False Then
            If Val(dtRespConsulta.Rows(0).Item(0)) > 0 Then
                ln_Suma = ln_Suma + Val(dtRespConsulta.Rows(0).Item(0))
            End If
        Else
            MsgBox("Ocurrió un error al intentar accesar la base de datos.")
            'dbEndQuery
            Exit Sub
        End If
        pbProceso.Value = 3
        If ln_Suma > -1 Then
            'dbEndQuery
            'Screen.MousePointer = vbHourglass
            If lb_ExisteDef Then
                If Oper_adicionales() Then
                    ln_Respuesta = MsgBox(" Ya se emitio un MT202 definitivo. ¿Desea reimprimir? ",
                                   vbQuestion + vbYesNoCancel + vbDefaultButton3, "Reporte MT202")
                    If ln_Respuesta = vbYes Then
                        'Reimpresion ComboAgencias.ItemData(ComboAgencias.ListIndex), 3
                        Reimpresion(ComboAgencias.SelectedValue, 3)
                    ElseIf ln_Respuesta = vbNo Then
                        If MsgBox("¿Desea enviar un reporte MT202 adicional", vbQuestion + vbYesNo, "Reporte MT202") = vbYes Then
                            'DetalleSwift ComboAgencias.ItemData(ComboAgencias.ListIndex), 4
                            DetalleSwift(ComboAgencias.SelectedValue, 4)
                        Else
                            'Screen.MousePointer = vbDefault
                            cmdAceptar.Enabled = True
                            Exit Sub
                        End If
                    Else
                        'Screen.MousePointer = vbDefault
                        cmdAceptar.Enabled = True
                        Exit Sub
                    End If
                Else
                    If MsgBox("Ya se emitio un MT202 definitivo. No hay operaciones adicionales a netear ¿Desea reimprimir? ",
                      vbQuestion + vbYesNo + vbDefaultButton1, "Reporte MT202") = vbYes Then
                        'Reimpresion ComboAgencias.ItemData(ComboAgencias.ListIndex), 3
                        Reimpresion(ComboAgencias.SelectedValue, 3)
                    Else
                        'Screen.MousePointer = vbDefault
                        cmdAceptar.Enabled = True
                        pbProceso.Value = 10
                        pbProceso.Visible = False
                        pbProceso.Value = 0
                        Exit Sub
                    End If
                End If
                pbProceso.Value = 4
            Else  'yud
                'If chkEnvioDef.Value = 1 Then
                If chkEnvioDef.Checked = True Then
                    'Screen.MousePointer = vbDefault
                    If MsgBox("Se emitira un envio definitivo. ¿Desea continuar? ",
                        vbQuestion + vbYesNo + vbDefaultButton2, "Reporte MT202 Envío definitivo") = vbYes Then
                        'DetalleSwift ComboAgencias.ItemData(ComboAgencias.ListIndex), 2
                        DetalleSwift(ComboAgencias.SelectedValue, 2)
                    Else
                        cmdAceptar.Enabled = True
                        'Screen.MousePointer = vbDefault
                        Exit Sub
                    End If
                Else
                    'DetalleSwift ComboAgencias.ItemData(ComboAgencias.ListIndex), 1 '1-parcial
                    DetalleSwift(ComboAgencias.SelectedValue, 1) '1-parcial
                End If
                pbProceso.Value = 4
            End If
            'Screen.MousePointer = vbDefault
            cmdAceptar.Enabled = True
        Else
            MsgBox("No existen operaciones de " & UCase(ComboAgencias.SelectedText) & " para netear.")
            'dbEndQuery
            cmdAceptar.Enabled = True
            'Screen.MousePointer = vbDefault
            Exit Sub
        End If
        pbProceso.Value = 5
        Habilita_definitivo()
        pbProceso.Value = 6
        'Screen.MousePointer = vbDefault
        cmdAceptar.Enabled = True
        pbProceso.Value = 10
        pbProceso.Visible = False
        pbProceso.Value = 0
    End Sub
    Function OperacionesPorEnviarAgenciaBBVA(nagencia As Integer) As Boolean
        Dim dtRespConsulta As New DataTable()
        OperacionesPorEnviarAgenciaBBVA = False
        'Se excluyen de esta funcion las operaciones con operacion_definida_global 81 y 91
        gs_Sql = "select count(OP.operacion) "
        gs_Sql = gs_Sql & " from OPERACION OP WITH (NOLOCK), PRODUCTO_CONTRATADO PC WITH (NOLOCK), " & "FUNCIONARIOS" & "..FUNCIONARIO F WITH (NOLOCK) "
        gs_Sql = gs_Sql & " where fecha_operacion = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "' "
        gs_Sql = gs_Sql & " and operacion_definida in "
        'los angeles
        If nagencia = 1 Then
            gs_Sql = gs_Sql & " (8583,8083,8587,8087,8089,8597,8097,8585,8085,8584,8094,8086,"
            gs_Sql = gs_Sql & "  8096,8088,8588,8589,8590,8591,8592,"                                                   '24 Horas  17-08-1998
            'Se agregan operaciones definidas para tarjeta de debito CED - ALB
            gs_Sql = gs_Sql & "  8052, 8053, 8054, 8056, 8057, 8552, 8553)"
            '    'NY
            '    ElseIf nagencia = 2 Then
            '        gs_sql = gs_sql & " (2583,2083,2587,2087,2089,2597,2097,2585,2085,2584,2094,2086,"
            '        gs_sql = gs_sql & "  2096,2088,2588,2589,2590,2591,2592)"                                                             '24 Horas  17-08-1998
            'Cayman
        ElseIf nagencia = 3 Then
            gs_Sql = gs_Sql & " (3583,3083,3587,3087,3089,3597,3097,3585,3085,3584,3094,3086,"
            gs_Sql = gs_Sql & "  3096,3081,3091,3088,3588,3589,3590,3591,3592)"                                               '24 Horas  17-08-1998
            'Londres (todavía no se encuetran definidas en producción las operaciones_definidas)
        Else
            gs_Sql = gs_Sql & " (0)"
        End If

        gs_Sql = gs_Sql & " and status_operacion in (2,3,4,5) "
        gs_Sql = gs_Sql & " and OP.funcionario = F.funcionario "
        'Sólo operaciones realizadas con funcionarios que operan en suc migradas
        gs_Sql = gs_Sql & " and F.bbvab = 1 "
        gs_Sql = gs_Sql & " and OP.producto_contratado = PC.producto_contratado "
        gs_Sql = gs_Sql & " and OP.operacion  not in ( "
        gs_Sql = gs_Sql & " select operacion "
        gs_Sql = gs_Sql & " from REPORTE_SWIFT RS, OPERACION_SWIFT OS, STATUS_REPORTE_SWIFT SR "
        gs_Sql = gs_Sql & " where fecha_reporte = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "' "
        gs_Sql = gs_Sql & " and RS.no_rep_swift = OS.no_rep_swift "
        gs_Sql = gs_Sql & " and SR.status_reporte = RS.status_reporte "
        gs_Sql = gs_Sql & " and RS.agencia = " & nagencia
        gs_Sql = gs_Sql & " ) "
        'dbExecQuery(gs_Sql)
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'If dbError() <> 0 Then
        If IsNothing(dtRespConsulta) Then
            MsgBox("Ha ocurrido un error al guardar la operación.", vbCritical, "Error")
            OperacionesPorEnviarAgenciaBBVA = False
            'ElseIf dbGetValue(0) > 0 Then
        ElseIf dtRespConsulta.Rows(0).Item(0) > 0 Then
            OperacionesPorEnviarAgenciaBBVA = True
        Else
            OperacionesPorEnviarAgenciaBBVA = False
        End If
        'dbEndQuery

        gs_Sql = "select count(OP.operacion) "
        gs_Sql = gs_Sql & " from OPERACION OP WITH (NOLOCK), PRODUCTO_CONTRATADO PC WITH (NOLOCK)"
        gs_Sql = gs_Sql & " where fecha_operacion = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "' "

        gs_Sql = gs_Sql & " and operacion_definida in "
        'los angeles
        If nagencia = 1 Then
            gs_Sql = gs_Sql & " (8583,8083,8587,8087,8089,8597,8097,8585,8085,8584,8094,8086,"
            gs_Sql = gs_Sql & "  8096,8088,8588,8589,8590,8591,8592, "                                                             '24 Horas  17-08-1998
            'Se agregan operaciones definidas para tarjeta de debito CED - ALB
            gs_Sql = gs_Sql & "  8052, 8053, 8054, 8056, 8057, 8552, 8553)"
            '    'NY
            '    ElseIf nagencia = 2 Then
            '        gs_sql = gs_sql & " (2583,2083,2587,2087,2089,2597,2097,2585,2085,2584,2094,2086,"
            '        gs_sql = gs_sql & "  2096,2088,2588,2589,2590,2591,2592)"                                                             '24 Horas  17-08-1998
            'Cayman
        ElseIf nagencia = 3 Then
            gs_Sql = gs_Sql & " (3583,3083,3587,3087,3089,3597,3097,3585,3085,3584,3094,3086,"
            gs_Sql = gs_Sql & "  3096,3081,3091,3088,3588,3589,3590,3591,3592)"                                               '24 Horas  17-08-1998
            'Londres (todavía no se encuetran definidas en producción las operaciones_definidas)
        Else
            gs_Sql = gs_Sql & " (0)"
        End If

        gs_Sql = gs_Sql & " and status_operacion in (2,3,4,5) "
        gs_Sql = gs_Sql & " and OP.funcionario is null "
        gs_Sql = gs_Sql & " and OP.producto_contratado = PC.producto_contratado "
        gs_Sql = gs_Sql & " and OP.operacion  not in ( "
        gs_Sql = gs_Sql & " select operacion "
        gs_Sql = gs_Sql & " from REPORTE_SWIFT RS, OPERACION_SWIFT OS, STATUS_REPORTE_SWIFT SR "
        gs_Sql = gs_Sql & " where fecha_reporte = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "' "
        gs_Sql = gs_Sql & " and RS.no_rep_swift = OS.no_rep_swift "
        gs_Sql = gs_Sql & " and SR.status_reporte = RS.status_reporte "
        gs_Sql = gs_Sql & " and RS.agencia = " & nagencia
        gs_Sql = gs_Sql & " ) "
        'dbExecQuery(gs_Sql)
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'If dbError() <> 0 Then
        If IsNothing(dtRespConsulta) Then
            MsgBox("Ha ocurrido un error al guardar la operación.", vbCritical, "Error")
            OperacionesPorEnviarAgenciaBBVA = False
            'ElseIf dbGetValue(0) > 0 Then
        ElseIf dtRespConsulta.Rows(0).Item(0) > 0 Then
            OperacionesPorEnviarAgenciaBBVA = True
        End If
        'dbEndQuery
    End Function
    '-----------------------------------------------------------------------------------------------------------
    'Obtiene el No. de Retiros con fecha_reporte = hoy y que no este en REPORTES_EMITIDOS_MT202 con tipo_202 = 1
    '-----------------------------------------------------------------------------------------------------------
    Private Function Oper_adicionales() As Boolean
        Dim dtRespConsulta As New DataTable()
        Oper_adicionales = False
        gs_Sql = "select count(*)"
        gs_Sql = gs_Sql & " from OPERACION_SWIFT OS WITH (NOLOCK), OPERACION O WITH (NOLOCK), "
        gs_Sql = gs_Sql & " REPORTE_SWIFT RS WITH (NOLOCK), OPERACION_DEFINIDA OD WITH (NOLOCK), "
        gs_Sql = gs_Sql & " REPORTES_EMITIDOS_MT202 RE WITH (NOLOCK), " & "FUNCIONARIOS" & "..FUNCIONARIO F WITH (NOLOCK)"
        gs_Sql = gs_Sql & " where status_reporte in (2,3,4,5) "
        gs_Sql = gs_Sql & " and O.operacion = OS.operacion"
        gs_Sql = gs_Sql & " and RS.no_rep_swift = OS.no_rep_swift"
        gs_Sql = gs_Sql & " and O.operacion_definida = OD.operacion_definida"
        gs_Sql = gs_Sql & " and O.funcionario = F.funcionario "
        gs_Sql = gs_Sql & " and F.bbvab = 1 "   ' sólo operaciones realizadas con funcionarios que operan en suc migradas
        'If Val(ComboAgencias.ItemData(ComboAgencias.ListIndex)) = 3 Then
        If Val(ComboAgencias.SelectedValue) = 3 Then
            gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sRetirosCayman
        Else
            gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sRetirosNYLA
        End If
        gs_Sql = gs_Sql & " ," & sDepositos & ")"
        gs_Sql = gs_Sql & " and RS.fecha_reporte = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
        'gs_Sql = gs_Sql & " and RS.agencia = " & ComboAgencias.ItemData(ComboAgencias.ListIndex)
        gs_Sql = gs_Sql & " and RS.agencia = " & ComboAgencias.SelectedValue
        gs_Sql = gs_Sql & " and OS.operacion not in ( select operacion "
        gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, REPORTES_EMITIDOS_MT202 RE"
        gs_Sql = gs_Sql & " where OS.numero_reporte_202 = RE.numero_reporte_202"
        gs_Sql = gs_Sql & " and tipo_202 = 1)"
        'dbExecQuery(gs_Sql)
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'If Not IsdbError Then
        If IsNothing(dtRespConsulta) = False Then
            If Val(dtRespConsulta.Rows(0).Item(0)) > 0 Then
                Oper_adicionales = True
            End If
            'dbEndQuery
        Else
            MsgBox("Error al netear")
            'dbEndQuery
            Oper_adicionales = False
            Exit Function
        End If
        gs_Sql = "select count(*)"
        gs_Sql = gs_Sql & " from OPERACION_SWIFT OS WITH (NOLOCK), OPERACION O WITH (NOLOCK), "
        gs_Sql = gs_Sql & " REPORTE_SWIFT RS WITH (NOLOCK), OPERACION_DEFINIDA OD WITH (NOLOCK), "
        gs_Sql = gs_Sql & " REPORTES_EMITIDOS_MT202 RE  WITH (NOLOCK)"
        gs_Sql = gs_Sql & " where status_reporte in (2,3,4,5) "
        gs_Sql = gs_Sql & " and O.operacion = OS.operacion"
        gs_Sql = gs_Sql & " and RS.no_rep_swift = OS.no_rep_swift"
        gs_Sql = gs_Sql & " and O.operacion_definida = OD.operacion_definida"
        gs_Sql = gs_Sql & " and O.funcionario is null "
        'If Val(ComboAgencias.ItemData(ComboAgencias.ListIndex)) = 3 Then
        If Val(ComboAgencias.SelectedValue) = 3 Then
            gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sRetirosCayman
        Else
            gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sRetirosNYLA
        End If
        gs_Sql = gs_Sql & " ," & sDepositos & ")"
        gs_Sql = gs_Sql & " and RS.fecha_reporte = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
        'gs_Sql = gs_Sql & " and RS.agencia = " & ComboAgencias.ItemData(ComboAgencias.ListIndex)
        gs_Sql = gs_Sql & " and RS.agencia = " & ComboAgencias.SelectedValue
        gs_Sql = gs_Sql & " and OS.operacion not in ( select operacion "
        gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, REPORTES_EMITIDOS_MT202 RE"
        gs_Sql = gs_Sql & " where OS.numero_reporte_202 = RE.numero_reporte_202"
        gs_Sql = gs_Sql & " and tipo_202 = 1)"
        'dbExecQuery(gs_Sql)
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'If Not IsdbError Then
        If IsNothing(dtRespConsulta) = False Then
            If Val(dtRespConsulta.Rows(0).Item(0)) > 0 Then
                Oper_adicionales = True
            End If
            'dbEndQuery
        Else
            MsgBox("Error al netear")
            'dbEndQuery
            Oper_adicionales = False
            Exit Function
        End If
    End Function
    Private Sub Reimpresion(sAgencia As String, nTipo_202 As Integer)
        Dim dtRespConsulta As New DataTable()
        Dim ln_Reportes As Long
        Dim ln_Indice As Long
        gs_Sql = "select count(*) from REPORTES_EMITIDOS_MT202 R WITH (NOLOCK)"
        gs_Sql = gs_Sql & " where R.fecha_reporte = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
        gs_Sql = gs_Sql & " and R.tipo_202 = 1 and bbvab = 1 "
        gs_Sql = gs_Sql & " and agencia = " & sAgencia
        'dbExecQuery(gs_Sql)            ' Obtiene el No. de operaciones en REPORTES_EMITIDOS_MT202 con fecha_reporte = hoy y tipo_202 = 1
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'If dbError Then
        If IsNothing(dtRespConsulta) Then
            'dbEndQuery
            Exit Sub
        Else
            ln_Reportes = Val(dtRespConsulta.Rows(0).Item(0))
            'dbEndQuery
        End If
        If ln_Reportes = 1 Then         ' Si existe una operación en REPORTES_EMITIDOS_MT202 entonces obtiene el numero_reporte_202
            'gs_sql = "select numero_reporte_202 from REPORTES_EMITIDOS_MT202 R, PARAMETROS P"
            gs_Sql = "select numero_reporte_202 from REPORTES_EMITIDOS_MT202 R WITH (NOLOCK)"
            gs_Sql = gs_Sql & " where R.fecha_reporte = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
            gs_Sql = gs_Sql & " and R.tipo_202 = 1 and bbvab =  1 "
            gs_Sql = gs_Sql & " and agencia = " & sAgencia
            'dbExecQuery(gs_Sql)
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            ReDim la_Reportes(1)
            la_Reportes(0) = Val(dtRespConsulta.Rows(0).Item(0))
            'dbEndQuery
            ReimprimeDetalle(ComboAgencias.SelectedValue, 3, la_Reportes(0))
        Else                            ' Si existe más de una operación
            gs_Sql = "select numero_reporte_202 from REPORTES_EMITIDOS_MT202 R WITH (NOLOCK)"
            gs_Sql = gs_Sql & " where R.fecha_reporte = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
            gs_Sql = gs_Sql & " and R.tipo_202 = 1  and bbvab =  1 "
            gs_Sql = gs_Sql & " and agencia = " & sAgencia
            'dbExecQuery(gs_Sql)
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            ReDim la_Reportes(ln_Reportes)
            For ln_Indice = 0 To ln_Reportes - 1
                la_Reportes(ln_Indice) = Val(dtRespConsulta.Rows(ln_Indice).Item(0))
                'dbGetRecord
            Next ln_Indice
            'dbEndQuery
            For ln_Indice = 0 To ln_Reportes - 1
                ReimprimeDetalle(ComboAgencias.SelectedValue, 3, la_Reportes(ln_Indice))
            Next ln_Indice
        End If
    End Sub
    '-----------------------------------------------------------------------
    'Reimprime con tipos de corte:  1 parcial
    '                               2 definitivo
    '                               3 reimpresion
    '                               4 envio adicional
    '-----------------------------------------------------------------------
    Private Sub ReimprimeDetalle(sAgencia As String, nTipo_202 As Integer, ByVal Num_reporte_MT202 As Long)
        Dim ln_TotRets As Double
        Dim ln_TotDeps As Double
        Dim ls_Banco As String
        Dim Ls_BancoDest As String
        Dim ls_BancoRemit As String
        Dim ls_BancoCuenta As String
        Dim ls_Tipo As String
        Dim ls_Info As String
        Dim ls_Monto As String
        Dim sTipoReimp As String
        Dim ln_Monto As Double
        Dim ls_Year As String
        Dim ls_Month As String
        Dim ls_Day As String
        Dim ls_Time As String
        Dim ln_NumRep As Long
        'MARB
        Dim Ls_BancoBenef As String
        Dim Ls_Leyenda As String
        Dim blnDepMayor As Boolean
        Dim blnRetMayor As Boolean

        Dim dtRespConsulta As New DataTable()
        Dim rptDoc As New ReportDocument
        Dim lsAmbiente As String = ""
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""

        ln_TotDeps = 0
        ln_TotRets = 0
        ln_TotDeps = TotalOperacionesReimpresion("DEPOSITO", ComboAgencias.SelectedValue, nTipo_202, Num_reporte_MT202)
        ln_TotRets = TotalOperacionesReimpresion("RETIRO", ComboAgencias.SelectedValue, nTipo_202, Num_reporte_MT202)
        'lmc 23-ago-2002
        Call ObtienInfBanco(ComboAgencias.SelectedValue, ln_TotDeps, ln_TotRets, ls_Banco, Ls_BancoDest, ls_Tipo, ls_Info, Ls_BancoBenef, ls_BancoRemit, ls_BancoCuenta)

        If ln_TotDeps < ln_TotRets Then
            ln_Monto = ln_TotRets - ln_TotDeps
            blnDepMayor = False
            blnRetMayor = True
        ElseIf ln_TotDeps > ln_TotRets Then
            ln_Monto = ln_TotDeps - ln_TotRets
            blnDepMayor = True
            blnRetMayor = False
        Else
            ls_Monto = "0"
            'ls_Tipo = ""
            ls_Info = ""
            ln_Monto = 0
        End If

        ls_Year = CDate(gs_FechaHoy).Year.ToString.Substring(2, 2) 'Right(gs_FechaHoy, 2) 'lmc 23-ago-2002
        ls_Month = CDate(gs_FechaHoy).Month 'Left(gs_FechaHoy, 2)
        ls_Day = CDate(gs_FechaHoy).Day 'Mid(gs_FechaHoy, 4, 2)
        If ls_Day.Length = 1 Then
            ls_Day = "0" & ls_Day
        End If
        If ls_Month.Length = 1 Then
            ls_Month = "0" & ls_Month
        End If

IniciaTran:
        'dbBeginTran
        objDatasource.IniciaTransaccion()
        gs_Sql = "update PARAMETROS "
        gs_Sql = gs_Sql & " set mt202_banco = '" & ls_Banco & "', "
        gs_Sql = gs_Sql & " mt202_bancodest = '" & Ls_BancoDest & "',"
        gs_Sql = gs_Sql & " mt202_tipo = '" & ls_Tipo & "', "
        gs_Sql = gs_Sql & " mt202_info = '" & ls_Info & "',"
        gs_Sql = gs_Sql & " mt202_monto2 = " & ln_Monto & ", "
        gs_Sql = gs_Sql & " mt202_anio = '" & ls_Year & "',"
        gs_Sql = gs_Sql & " mt202_mes = '" & ls_Month & "', "
        gs_Sql = gs_Sql & " mt202_dia = '" & ls_Day & "' "
        'dbExecQuery(gs_Sql)                  ' Actualiza PARAMETROS

        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
            'If dbError Then
            'dbEndQuery
            MsgBox("Ocurrio un error al imprimir el reporte.")
            'dbRollback
            objDatasource.RollbackTransaccion()
            Exit Sub
        Else
            'dbEndQuery
        End If
        gs_Sql = "DELETE FROM REPORTE_MT202"


        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
            'dbEndQuery
            MsgBox("Ocurrio un error al imprimir el reporte.")
            'dbRollback
            objDatasource.RollbackTransaccion()
            Exit Sub
        End If
        'dbEndQuery
        'ls_Time = Format(Time, "hh:mm")
        ls_Time = Format(gs_HoraSistema, "hh:mm")
        gs_Sql = "insert into REPORTE_MT202 "
        gs_Sql = gs_Sql & "( descripcion_operacion_definida, total_operaciones, "
        gs_Sql = gs_Sql & "monto_operaciones, tipo_operacion ) "
        gs_Sql = gs_Sql & " select OD.descripcion_operacion_definida, "
        gs_Sql = gs_Sql & " count(*), sum(O.monto_operacion), 0"
        gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, OPERACION O, REPORTE_SWIFT RS, "
        gs_Sql = gs_Sql & " OPERACION_DEFINIDA OD, REPORTES_EMITIDOS_MT202 RE "
        gs_Sql = gs_Sql & " where status_reporte in (2,3,4,5) "
        gs_Sql = gs_Sql & " and O.operacion = OS.operacion"
        gs_Sql = gs_Sql & " and RS.no_rep_swift = OS.no_rep_swift"
        gs_Sql = gs_Sql & " and O.operacion_definida = OD.operacion_definida"
        gs_Sql = gs_Sql & " and RE.bbvab = 1 "   ' sólo operaciones MT202 BBVA
        If Val(sAgencia) = 3 Then               ' Cayman
            gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sRetirosCayman & ")"
        Else                                    ' NYLA
            gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sRetirosNYLA & ")"
        End If
        gs_Sql = gs_Sql & " and RS.fecha_reporte = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
        gs_Sql = gs_Sql & " and RS.agencia = " & sAgencia
        gs_Sql = gs_Sql & " and OS.numero_reporte_202 =" & Num_reporte_MT202
        gs_Sql = gs_Sql & " and RE.tipo_202 = 1"
        gs_Sql = gs_Sql & " and OS.numero_reporte_202 =  RE.numero_reporte_202 "
        gs_Sql = gs_Sql & " Group By OD.descripcion_operacion_definida "
        '*****
        'dbExecQuery(gs_Sql)                    ' Inserta en REPORTE_MT202 las operaciones de Retiro con fecha_reporte = hoy y con tipo_202 = 1


        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
            'dbEndQuery
            MsgBox("Ocurrio un error al imprimir el reporte.")
            'dbRollback
            objDatasource.RollbackTransaccion()
            Exit Sub
        End If
        'dbEndQuery
        gs_Sql = "insert into REPORTE_MT202 "
        gs_Sql = gs_Sql & "( descripcion_operacion_definida, total_operaciones, "
        gs_Sql = gs_Sql & "monto_operaciones, tipo_operacion ) "
        gs_Sql = gs_Sql & " select OD.descripcion_operacion_definida, "
        gs_Sql = gs_Sql & " count(*), sum(O.monto_operacion), 1"
        gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, OPERACION O, REPORTE_SWIFT RS, "
        gs_Sql = gs_Sql & " OPERACION_DEFINIDA OD, REPORTES_EMITIDOS_MT202 RE "
        gs_Sql = gs_Sql & " where status_reporte in (2,3,4,5) "
        gs_Sql = gs_Sql & " and O.operacion = OS.operacion"
        gs_Sql = gs_Sql & " and RS.no_rep_swift = OS.no_rep_swift"
        gs_Sql = gs_Sql & " and O.operacion_definida = OD.operacion_definida "
        gs_Sql = gs_Sql & " and RE.bbvab = 1 "   ' sólo operaciones realizadas MT202 BBVA
        gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sDepositos & ")"
        gs_Sql = gs_Sql & " and RS.fecha_reporte = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
        gs_Sql = gs_Sql & " and RS.agencia = " & sAgencia
        gs_Sql = gs_Sql & " and OS.numero_reporte_202 =" & Num_reporte_MT202
        gs_Sql = gs_Sql & " and RE.tipo_202 = 1"
        gs_Sql = gs_Sql & " and OS.numero_reporte_202 = RE.numero_reporte_202 "
        gs_Sql = gs_Sql & " Group By OD.descripcion_operacion_definida "
        'dbExecQuery(gs_Sql)                    ' Inserta en REPORTE_MT202 los Depositos con fecha_reporte = hoy y tipo_202 = 1
        'If dbError Then

        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
            'dbEndQuery
            MsgBox("Ocurrio un error al imprimir el reporte.")
            'dbRollback
            objDatasource.RollbackTransaccion()
            Exit Sub
        End If
        'dbEndQuery

        gs_Sql = "select tipo_reporte from REPORTES_EMITIDOS_MT202 WITH (NOLOCK) "
        gs_Sql = gs_Sql & "where numero_reporte_202 = " & Num_reporte_MT202
        gs_Sql = gs_Sql & " and bbvab = 1 "
        'dbExecQuery(gs_Sql)                    ' Obtiene el tipo_reporte de REPORTES_EMITIDOS_MT202
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'If Not dbError() Then
        If IsNothing(dtRespConsulta) = False Then
            'Select Case dbGetValue(0)
            Select Case dtRespConsulta.Rows(0).Item(0)
                Case 2
                    sTipoReimp = " DEFINITIVO"
                Case 4
                    sTipoReimp = " ADICIONAL"
            End Select
        Else
            MsgBox("Ocurrió un error al accesar la base de datos.")
        End If
        'dbEndQuery

        Select Case nTipo_202
            Case 1
                Ls_Leyenda = "PARCIAL NO ENVIAR"
            Case 2
                Ls_Leyenda = "DEFINITIVO SI ENVIAR"
            Case 4
                Ls_Leyenda = "ADICIONAL"
            Case 3
                Ls_Leyenda = "REIMPRESION " & Trim(sTipoReimp)
        End Select

        If GrabarReporteMT202(Num_reporte_MT202, CInt(sAgencia), nTipo_202, ls_Tipo, Format(CDate(gs_FechaHoy), "yyyy-MM-dd"), ls_Time,
                          ls_Banco, Ls_BancoDest, "", ls_Year, ls_Month, ls_Day,
                          CStr(ln_Monto), ls_BancoRemit, ls_BancoCuenta, Ls_BancoBenef, ls_Info,
                          Ls_Siglas(1), Ls_Siglas(2), Ls_Siglas(3), Ls_Leyenda, blnDepMayor, blnRetMayor) Then
            'dbCommit
            objDatasource.CommitTransaccion()
        Else
            MsgBox("Ocurrió un error al imprimir el reporte.")
            'dbRollback
            objDatasource.RollbackTransaccion()
            Exit Sub
        End If

        'Reporte
        'RepMT202.Formulas(0) = "FECHA = 'FECHA: " & InvierteFecha(gs_FechaHoy) & "'"
        'RepMT202.Formulas(1) = "Hora = '" & ls_Time & "'"
        lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
        lsReporte = lsRutaFolder & "MT202_det_newBBVA" & lsAmbiente & ".rpt"
        rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
        objLibreria.logonBDreporte(rptDoc, 1)
        rptDoc.DataDefinition.FormulaFields.Item("FECHA").Text = "'FECHA: " & Format(CDate(gs_FechaHoy), "MM-dd-yyyy") & "'"
        rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & ls_Time & "'"

        Select Case nTipo_202
            Case 1
                'RepMT202.Formulas(2) = "Leyenda = 'PARCIAL NO ENVIAR'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'PARCIAL NO ENVIAR'"
            Case 2
                'RepMT202.Formulas(2) = "Leyenda = 'DEFINITIVO SI ENVIAR'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'DEFINITIVO SI ENVIAR'"
            Case 4
                'RepMT202.Formulas(2) = "Leyenda = 'ADICIONAL'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'ADICIONAL'"
            Case 3
                'RepMT202.Formulas(2) = "Leyenda = 'REIMPRESION' + '" & sTipoReimp & "'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'REIMPRESION' + '" & sTipoReimp & "'"
        End Select

        'RepMT202.Formulas(3) = "Monto = " & ln_Monto
        rptDoc.DataDefinition.FormulaFields.Item("Monto").Text = ln_Monto
        'RepMT202.Formulas(4) = "NombreAgencia = '" & UCase(ComboAgencias.List(ComboAgencias.ListIndex)) & "'"
        rptDoc.DataDefinition.FormulaFields.Item("NombreAgencia").Text = "'" & UCase(ComboAgencias.SelectedText) & "'"
        'RepMT202.ReportFileName = GPATH & "\MT202_det_newBBVA.rpt"
        'MuestraVentanaReporte RepMT202
        opcionReporte = 16
        RepOperativa.reporteOFAC = rptDoc
        RepOperativa.ShowDialog()

        rptDoc = New ReportDocument
        lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
        lsReporte = lsRutaFolder & "mt202BBVA" & lsAmbiente & ".rpt"
        rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
        objLibreria.logonBDreporte(rptDoc, 1)
        'RepMT202.Formulas(0) = "FECHA = 'FECHA: " & InvierteFecha(gs_FechaHoy) & "'"
        'RepMT202.Formulas(1) = "Hora = '" & ls_Time & "'"
        rptDoc.DataDefinition.FormulaFields.Item("Fecha").Text = "'FECHA: " & CDate(gs_FechaHoy).ToString("dd-MM-yyyy") & "'"
        rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & gs_HoraSistema & "'"

        Select Case nTipo_202
            Case 1
                'RepMT202.Formulas(2) = "Leyenda = 'PARCIAL NO ENVIAR'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'PARCIAL NO ENVIAR'"
            Case 2
                'RepMT202.Formulas(2) = "Leyenda = 'DEFINITIVO SI ENVIAR'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'DEFINITIVO SI ENVIAR'"
            Case 4
                'RepMT202.Formulas(2) = "Leyenda = 'ADICIONAL'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'ADICIONAL'"
            Case 3
                'RepMT202.Formulas(2) = "Leyenda = 'REIMPRESION' + '" & sTipoReimp & "'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'REIMPRESION' + '" & sTipoReimp & "'"
        End Select

        'RepMT202.Formulas(4) = "NombreAgencia = '" & UCase(ComboAgencias.List(ComboAgencias.ListIndex)) & "'"
        rptDoc.DataDefinition.FormulaFields.Item("NombreAgencia").Text = "'" & UCase(ComboAgencias.SelectedText) & "'"
        'MARB - IDS Comercial, 25 Feb 03
        'RepMT202.Formulas(5) = "BancoBenef2 = '" & UCase(Ls_BancoBenef) & "'"
        rptDoc.DataDefinition.FormulaFields.Item("BancoBenef2").Text = "'" & UCase(Ls_BancoBenef) & "'"
        '** siglas para la comparación de tipo en el reporte
        'RepMT202.Formulas(6) = "SiglasLA = '" & Ls_Siglas(1) & "'"
        'RepMT202.Formulas(7) = "SiglasNY = '" & Ls_Siglas(2) & "'"
        'RepMT202.Formulas(8) = "SiglasGC = '" & Ls_Siglas(3) & "'"
        rptDoc.DataDefinition.FormulaFields.Item("SiglasLA").Text = "'" & "HO" & "'"
        'rptDoc.DataDefinition.FormulaFields.Item("SiglasNY").Text = "'" & Ls_Siglas(2) & "'"
        'rptDoc.DataDefinition.FormulaFields.Item("SiglasGC").Text = "'" & Ls_Siglas(3) & "'"
        'RepMT202.Formulas(9) = "BancoRemitente1 = '" & ls_BancoRemit & "'"
        'RepMT202.Formulas(10) = "BancoCuenta1 = '" & ls_BancoCuenta & "'"
        rptDoc.DataDefinition.FormulaFields.Item("BancoRemitente1").Text = "'" & ls_BancoRemit & "'"
        rptDoc.DataDefinition.FormulaFields.Item("BancoCuenta1").Text = "'" & ls_BancoCuenta & "'"
        '**
        'RepMT202.ReportFileName = GPATH & "\mt202BBVA.rpt"
        'MuestraVentanaReporte RepMT202
        opcionReporte = 16
        RepOperativa.reporteOFAC = rptDoc
        RepOperativa.ShowDialog()
    End Sub
    '-----------------------------------------------------------------------------------
    'Obtiene la suma de los Depósitos o Retiros de una Agencia con fecha_reporte = hoy
    '-----------------------------------------------------------------------------------
    Private Function TotalOperacionesReimpresion(SOperaciong As String, sAgencia As Integer, nTipo_202 As Integer, ByVal Numero_Reporte As Long) As Double
        Dim dtRespConsulta As New DataTable()
        gs_Sql = " select sum(O.monto_operacion) "
        gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, OPERACION O, REPORTE_SWIFT RS, "
        gs_Sql = gs_Sql & " OPERACION_DEFINIDA OD, REPORTES_EMITIDOS_MT202 RE "
        gs_Sql = gs_Sql & " where O.operacion = OS.operacion "
        gs_Sql = gs_Sql & " and RS.no_rep_swift = OS.no_rep_swift "
        gs_Sql = gs_Sql & " and O.operacion_definida = OD.operacion_definida "
        gs_Sql = gs_Sql & " and RE.bbvab = 1 "   ' sólo operaciones con MT202 BBVA
        gs_Sql = gs_Sql & " and RS.fecha_reporte = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
        gs_Sql = gs_Sql & " and RS.agencia = " & sAgencia & " "
        gs_Sql = gs_Sql & " and RS.status_reporte in (2,3,4,5) "
        gs_Sql = gs_Sql & " and OS.numero_reporte_202 =" & Numero_Reporte
        gs_Sql = gs_Sql & " and RE.tipo_202 = 1"    ' corte parcial
        gs_Sql = gs_Sql & " and OS.numero_reporte_202 =  RE.numero_reporte_202 "
        If SOperaciong = "RETIRO" Then
            If sAgencia = 3 Then                      ' Retiro Cayman
                gs_Sql = gs_Sql & "and OD.operacion_definida_global in (" & sRetirosCayman & ")"
            Else                                      ' Retiro NYLA
                gs_Sql = gs_Sql & "and OD.operacion_definida_global in (" & sRetirosNYLA & ")"
            End If
        ElseIf SOperaciong = "DEPOSITO" Then
            gs_Sql = gs_Sql & "and OD.operacion_definida_global in (" & sDepositos & ")"
        End If
        'dbExecQuery(gs_Sql)
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'If Not IsdbError Then
        If IsNothing(dtRespConsulta) = False Then
            If dtRespConsulta.Rows(0).Item(0).ToString() = "" Then
                TotalOperacionesReimpresion = 0
            Else
                TotalOperacionesReimpresion = Val(dtRespConsulta.Rows(0).Item(0))
            End If
        Else
            MsgBox("Ocurrio un error al obtener el monto")
            'dbEndQuery
            TotalOperacionesReimpresion = 0
        End If
        'dbEndQuery
    End Function
    Private Sub ObtienInfBanco(ln_Agencia As Long,
                            ln_TotDeps As Double,
                            ln_TotRets As Double,
                            ByRef ls_Banco As String,
                            ByRef Ls_BancoDest As String,
                            ByRef ls_Tipo As String,
                            ByRef ls_Info As String,
                            ByRef Ls_BancoBenef As String,
                            ByRef ls_BancoRemit As String,
                            ByRef ls_BancoCuenta As String)

        Dim ls_Datos As String
        Dim Ls_Leyenda As String
        Dim Ls_BcoBenef As String
        Dim Ls_Temporal() As String
        Dim Ls_Siglas As String

        ls_Banco = "BCMRMXMMAOPE"
        If ln_TotDeps < ln_TotRets Then
            ls_Tipo = "R"
            ' CHDG
            ls_BancoRemit = "D:/8000225300100,FED"
            ls_BancoCuenta = "A:/CHASUS33"
        Else
            ' CHDG
            ls_BancoRemit = "400001942,A:BCMRMXMM"
            ls_BancoCuenta = ""
            ls_Tipo = "D"
        End If

        ls_Datos = ValParametroAgencias("DATOS" & ls_Tipo & CStr(ln_Agencia))
        Ls_Leyenda = ValParametroAgencias("LEYENDA" & CStr(ln_Agencia))
        Ls_BcoBenef = ValParametroAgencias("BCOBENEF" & ls_Tipo & CStr(ln_Agencia))

        'marb
        'Verificar si trae la leyenda para la descripción y las siglas
        If UBound(Split(Ls_Leyenda, ",")) = 1 Then
            ls_Tipo = ls_Tipo & Trim(Split(Ls_Leyenda, ",")(1))
            Ls_Leyenda = Trim(Split(Ls_Leyenda, ",")(0))
        Else
            ls_Tipo = ""
            MsgBox("El campo de LEYENDA" & ln_Agencia & " de la tabla de parametrización es incorrecto, consultelo con el administrador", vbCritical, "Error")
            Exit Sub
        End If

        Ls_Temporal = Split(ls_Datos, ",")
        If UBound(Ls_Temporal) = 1 And Ls_Leyenda <> "" Then
            'Banco Destino e Info Banco a Banco
            Ls_BancoDest = Ls_Temporal(0)
            ls_Info = Ls_Temporal(1) & " " & Ls_Leyenda
            Ls_BancoBenef = Ls_BcoBenef
        Else
            ls_Tipo = ""
            MsgBox("El campo de DATOS" & ls_Tipo & ln_Agencia & " de la tabla de parametrización es incorrecto, consultelo con el administrador", vbCritical, "Error")
        End If
    End Sub
    Private Function ValParametroAgencias(Ls_Parametro As String) As String
        Dim dtRespConsulta As New DataTable()
        Dim Ls_ValorParametro As String
        Dim ls_sql As String
        ls_sql = "Select valor from PARAMETRIZACION WITH (NOLOCK) " & "where codigo = '" & Trim(Ls_Parametro) & "'"
        Ls_ValorParametro = ""
        'dbExecQuery ls_sql
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(ls_sql)
        'If dbError = 0 Then
        If IsNothing(dtRespConsulta) = False Then
            'Do
            '    Ls_ValorParametro = Ls_ValorParametro & Trim(dbGetValue(0))
            '    dbGetRecord
            'Loop While dbError = 0
            For Each row As DataRow In dtRespConsulta.Rows
                Ls_ValorParametro = Ls_ValorParametro & Trim(row.Item(0))
            Next
        Else
            MsgBox("Error  al  Obtener  Dato  Parametrizado." & Chr(13) & "Notifique al Departamento de Sistemas!" & Chr(13) & "Código de Parametro: " & Trim(Ls_Parametro), vbCritical, "Error")
            Exit Function
        End If
        'dbEndQuery
        ValParametroAgencias = Ls_ValorParametro
    End Function
    '---------------------------------------
    'Funcion para grabar el reporte MT202
    '---------------------------------------
    Private Function GrabarReporteMT202(lngNoRep202 As Long,
                                        intAgencia As Integer,
                                        intTipo As Integer,
                                        strTipo As String,
                                        datFecha As String,
                                        strHora As String,
                                        strBanco As String,
                                        strBancoDest As String,
                                        strRepFolio As String,
                                        strAnnio As String,
                                        strMes As String,
                                        strDia As String,
                                        strMonto As String,
                                        strBancoRemitente As String,
                                        strBancoCuenta As String,
                                        strBancoBenef As String,
                                        strInfo As String,
                                        strSiglasLA As String,
                                        strSiglasNY As String,
                                        strSiglasGC As String,
                                        strLeyenda As String,
                                        blnDepMayor As Boolean,
                                        blnRetMayor As Boolean) As Boolean

        On Error GoTo ErrGrabarReporteMT202

        Dim strSQL As String
        Dim lngRep As Long
        Dim intTipRep As Integer
        Dim blnDefinitivo As Boolean
        Dim blnReimpresion As Boolean
        Dim strTipoRet1 As String
        Dim strTipoRet2 As String
        Dim strTipoRet3 As String
        Dim strTipoDep1 As String
        Dim strTipoDep2 As String
        Dim strTipoDep3 As String
        Dim strCampo20 As String
        Dim strCampo21 As String
        Dim strCampo32 As String
        Dim strCampo52 As String
        Dim strCampo53_D As String
        Dim strCampo53_1 As String
        Dim strCampo57_A As String
        Dim strCampo57_1 As String
        Dim strCampo58_A As String
        Dim strCampo58_1 As String
        Dim strCampo72_1 As String
        Dim arrBenef() As String
        Dim arrBcoRem() As String
        Dim arrBcoCta() As String
        Dim dblMonto1 As Double
        Dim dblMonto2 As Double
        Dim intStatus As Integer
        Dim ls_msg As String
        Dim dtRespConsulta As New DataTable()
        strSiglasLA = "HO"
        ls_msg = ""
        If blnDepMayor = True And blnRetMayor = False Then
            ls_msg = "Depósitos Mayores a Retiros. "
        ElseIf blnDepMayor = False And blnRetMayor = True Then
            ls_msg = "Retiros Mayores a Depósitos. "
        Else
            ls_msg = "Depósitos - Retiros queda en cero o existe un error en el cálculo de las operaciones. "
        End If

        strTipoRet1 = "R" & strSiglasLA
        'strTipoRet2 = "R" & strSiglasNY
        'strTipoRet3 = "R" & strSiglasGC

        strTipoDep1 = "D" & strSiglasLA
        'strTipoDep2 = "D" & strSiglasNY
        'strTipoDep3 = "D" & strSiglasGC

        If intTipo = 2 Then 'DEFINITIVO SI ENVIAR"
            blnDefinitivo = True
        Else
            blnDefinitivo = False
        End If

        If strLeyenda = "REIMPRESION DEFINITIVO" Then
            blnReimpresion = True
            blnDefinitivo = True
            intTipRep = 2
        ElseIf strLeyenda = "REIMPRESION ADICIONAL" Then
            blnReimpresion = True
            intTipRep = 4
        Else
            blnReimpresion = False
        End If

        Select Case strTipo
            Case strTipoDep1
                strCampo20 = "6055 " & strMes & " " & strDia & " " & strTipoRet1 '& " " & strRepFolio
                strCampo21 = "6055 " & strMes & " " & strDia & " " & strTipoRet1 '& " " & strRepFolio
            Case strTipoDep2
                strCampo20 = "6055 " & strMes & " " & strDia & " " & strTipoRet2 '& " " & strRepFolio
                strCampo21 = "6055 " & strMes & " " & strDia & " " & strTipoRet2 '& " " & strRepFolio
            Case strTipoDep3
                strCampo20 = "6055 " & strMes & " " & strDia & " " & strTipoRet3 '& " " & strRepFolio
                strCampo21 = "6055 " & strMes & " " & strDia & " " & strTipoRet3 '& " " & strRepFolio
            Case Else
                strCampo20 = "6055 " & strMes & " " & strDia & " " & strTipo '& " " & strRepFolio
                strCampo21 = "6055 " & strMes & " " & strDia & " " & strTipo '& " " & strRepFolio
        End Select
        strCampo32 = strAnnio & strMes & strDia & "USD" & Format(Double.Parse(strMonto), "#0.00")
        dblMonto1 = Val(strMonto)

        strCampo52 = "BCMRMXMM"

        arrBcoRem = Split(strBancoRemitente, ",")
        If UBound(arrBcoRem) > 0 Then
            strCampo53_D = Trim(arrBcoRem(0))
            strCampo53_1 = Trim(arrBcoRem(1))
        End If

        arrBcoCta = Split(strBancoCuenta, ",")
        If UBound(arrBcoCta) > 0 Then
            strCampo57_A = Trim(arrBcoCta(0))
            strCampo57_1 = Trim(arrBcoCta(1))
        End If

        arrBenef = Split(strBancoBenef, ",")
        If UBound(arrBenef) > 0 Then
            strCampo58_A = Trim(arrBenef(0))
            strCampo58_1 = Trim(arrBenef(1))
        End If

        strCampo72_1 = "/BNF/" & strInfo

        If intTipo = 2 Or intTipo = 4 Or (intTipo = 3 And blnReimpresion) Then
            If intTipo = 2 Or intTipo = 4 Then
                intTipRep = intTipo
                strSQL = "SELECT count(num_rep) FROM REPORTE_SWIFT_MT202 WITH (NOLOCK) "
                strSQL = strSQL & "WHERE num_rep_202 = " & lngNoRep202
                strSQL = strSQL & "  AND tipo_202 = " & intTipRep
            Else
                strSQL = "SELECT count(num_rep) FROM REPORTE_SWIFT_MT202 WITH (NOLOCK) "
                strSQL = strSQL & "WHERE num_rep_202 = " & lngNoRep202
                strSQL = strSQL & "  AND tipo_202 = " & intTipRep
            End If

            'dbExecQuery(strSQL)
            dtRespConsulta = objDatasource.RealizaConsulta(strSQL)
            'If dbError Then
            If IsNothing(dtRespConsulta) Then
                'dbEndQuery
                MsgBox("Ocurrio un error al consultar el reporte.")
                Exit Function
            End If

            'dbGetRecord
            'If Val(dbGetValue(0)) = 0 Then
            If Val(dtRespConsulta.Rows(0).Item(0)) = 0 Then
                'dbEndQuery
                strSQL = "INSERT INTO REPORTE_SWIFT_MT202 VALUES ( "
                strSQL = strSQL & lngNoRep202 & ", "
                strSQL = strSQL & intTipRep & ", "
                strSQL = strSQL & intAgencia & ", "
                'strSQL = strSQL & "'" & Format(datFecha & " " & strHora, "MM-DD-YYYY Hh:Nn") & "', "  '" " & strHora) & "', "
                strSQL = strSQL & "'" & datFecha & " " & strHora & "', " 'Format(strHora, "Hh:Nn") & "', "
                strSQL = strSQL & "1, "
                strSQL = strSQL & Math.Abs(CInt(blnDefinitivo)) & ", "
                strSQL = strSQL & Math.Abs(CInt(blnReimpresion)) & ", "
                strSQL = strSQL & "'" & Trim(strBanco) & "', "
                strSQL = strSQL & "'" & Trim(strBancoDest) & "', "
                strSQL = strSQL & "'" & Trim(strCampo20) & "', "
                strSQL = strSQL & "'" & Trim(strCampo21) & "', "
                strSQL = strSQL & "'" & Trim(strCampo32) & "', "
                strSQL = strSQL & "'" & Trim(strCampo52) & "', "
                strSQL = strSQL & "'" & Trim(strCampo53_D) & "', "
                strSQL = strSQL & "'" & Trim(strCampo53_1) & "', "
                strSQL = strSQL & "'" & Trim(strCampo57_A) & "', "
                strSQL = strSQL & "'" & Trim(strCampo57_1) & "', "
                strSQL = strSQL & "'" & Trim(strCampo58_A) & "', "
                strSQL = strSQL & "'" & Trim(strCampo58_1) & "', "
                strSQL = strSQL & "'" & Trim(strCampo72_1) & "', "
                strSQL = strSQL & Math.Abs(CInt(blnDepMayor)) & ", "
                strSQL = strSQL & Math.Abs(CInt(blnRetMayor)) & " ) "
                'dbExecQuery(strSQL)


                If objDatasource.EjecutaComandoTransaccion(strSQL) = False Then 'If (objDatasource.insertar(strSQL)) = 0 Then
                    'dbEndQuery
                    MsgBox("Ocurrio un error al grabar el reporte en la tabla REPORTE_SWIFT_MT202.")
                    Exit Function
                Else
                    'dbEndQuery
                End If

                strSQL = "SELECT @@Identity"
                strSQL = "select MAX(num_rep) from TICKET..REPORTE_SWIFT_MT202 WITH (NOLOCK) "
                'dbExecQuery(strSQL)
                dtRespConsulta = objDatasource.RealizaConsulta(strSQL)
                'If dbError Then
                If IsNothing(dtRespConsulta) Then
                    'dbEndQuery
                    MsgBox("Ocurrio un error al consultar el no. de reporte.")
                    Exit Function
                End If
                'dbGetRecord
                'lngRep = Val(dbGetValue(0))
                lngRep = Val(dtRespConsulta.Rows(0).Item(0).ToString())
                'dbEndQuery

                If intAgencia = 3 And blnRetMayor Then
                    intStatus = 1
                Else
                    intStatus = 0
                End If

                'Se pregunta si se desea enviar el mensaje a Swift la decisión la toma el usuario
                If intStatus = 0 Then
                    ls_msg = ls_msg & "¿Desea enviar el Mesaje MT202 a Swift? "
                    If MsgBox(ls_msg, vbYesNo) = vbNo Then intStatus = 1
                End If

                strSQL = "INSERT INTO BITACORA_ENVIO_SWIFT_MT202 "
                strSQL = strSQL & " (num_rep, status_envio) VALUES ("
                strSQL = strSQL & lngRep & ", "
                strSQL = strSQL & intStatus & " ) "
                'dbExecQuery(strSQL)

                If objDatasource.EjecutaComandoTransaccion(strSQL) = False Then 'If (objDatasource.insertar(strSQL)) = 0 Then
                    'dbEndQuery
                    MsgBox("Ocurrio un error al grabar el reporte en la tabla BITACORA_ENVIO_SWIFT_MT202.")
                    Exit Function
                Else
                    'dbEndQuery
                End If
            Else
                'dbEndQuery

                If blnReimpresion Then
                    strSQL = "SELECT campo_32 FROM REPORTE_SWIFT_MT202 WITH (NOLOCK) "
                    strSQL = strSQL & "WHERE num_rep_202 = " & lngNoRep202
                    strSQL = strSQL & "  AND tipo_202 = " & intTipRep

                    'dbExecQuery(strSQL)
                    dtRespConsulta = objDatasource.RealizaConsulta(strSQL)
                    'If dbError Then
                    If IsNothing(dtRespConsulta) Then
                        'dbEndQuery
                        MsgBox("Ocurrio un error al consultar el reporte.")
                        Exit Function
                    End If
                    'dbGetRecord
                    dblMonto2 = Val(Mid(dtRespConsulta.Rows(0).Item(0), 10, 16))
                    'dbEndQuery

                    If dblMonto1 <> dblMonto2 Then
                        If intTipRep = 2 Then
                            MsgBox("El monto del reporte de reimpresión es diferente al definitivo.", vbInformation, "Reimpresión")
                        ElseIf intTipRep = 4 Then
                            MsgBox("El monto del reporte de reimpresión es diferente al adicional.", vbInformation, "Reimpresión")
                        End If
                    End If
                End If

                strSQL = "UPDATE REPORTE_SWIFT_MT202 SET "
                strSQL = strSQL & " definitivo = " & Math.Abs(CInt(blnDefinitivo)) & " , "
                strSQL = strSQL & " reimpresion = " & Math.Abs(CInt(blnReimpresion))
                strSQL = strSQL & " WHERE num_rep_202 = " & lngNoRep202
                strSQL = strSQL & "   AND tipo_202 = " & intTipRep
                'dbExecQuery(strSQL)
                'If dbError Then

                If objDatasource.EjecutaComandoTransaccion(strSQL) = False Then 'If objDatasource.insertar(strSQL) = 0 Then
                    'dbEndQuery
                    MsgBox("Ocurrio un error al grabar el reporte en la tabla REPORTE_SWIFT_MT202.")
                    Exit Function
                Else
                    'dbEndQuery
                End If
            End If
        End If
        GrabarReporteMT202 = True
        Exit Function
ErrGrabarReporteMT202:
        GrabarReporteMT202 = False
    End Function
    '------------------------------------------------------------------------------------
    'Genera el Reporte Swift MT202 de Tipo:   1 parcial
    '                                         2 definitivo
    '                                         3 reimpresion
    '                                         4 envio adicional
    '------------------------------------------------------------------------------------
    Private Sub DetalleSwift(sAgencia As Integer, nTipo_202 As Integer)
        Dim dtRespConsulta As New DataTable()
        Dim rptDoc As New ReportDocument
        Dim lsAmbiente As String = ""
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""

        Dim ln_TotRets As Double
        Dim ln_TotDeps As Double
        Dim ls_Banco As String
        Dim Ls_BancoDest As String
        Dim ls_BancoRemit As String
        Dim ls_BancoCuenta As String
        Dim ls_Info As String
        Dim ls_Monto As String
        Dim ln_Monto As Double
        Dim ls_Year As String
        Dim ls_Month As String
        Dim ls_Day As String
        Dim ls_Time As String
        Dim ln_NumRep As Long
        Dim ln_Numeracion As Long
        'MARB
        Dim Ls_BancoBenef As String
        Dim Ls_Leyenda As String
        Dim blnDepMayor As Boolean
        Dim blnRetMayor As Boolean

        ln_TotDeps = 0
        ln_TotRets = 0
        ln_TotDeps = TotalOperacion("DEPOSITO", ComboAgencias.SelectedValue, nTipo_202)
        ln_TotRets = TotalOperacion("RETIRO", ComboAgencias.SelectedValue, nTipo_202)
        If (ln_TotDeps = 0) And (ln_TotRets = 0) And nTipo_202 = 4 Then
            MsgBox("No hay más operaciones enviadas para reportar", vbExclamation, "Error")
            Exit Sub
        End If

        'lmc 23-ago-2002
        Call ObtienInfBanco(ComboAgencias.SelectedValue, ln_TotDeps, ln_TotRets, ls_Banco, Ls_BancoDest, ls_Tipo, ls_Info, Ls_BancoBenef, ls_BancoRemit, ls_BancoCuenta)

        If ln_TotDeps < ln_TotRets Then
            ln_Monto = ln_TotRets - ln_TotDeps
            blnDepMayor = False
            blnRetMayor = True
            'If MsgBox("Se tienen retiros mayores a los depósitos, por un monto de: USD " & Format(Double.Parse(ln_Monto), "#0.00") & " ¿Es correcto?", vbYesNo) = vbNo Then
            '    Exit Sub
            'End If
        ElseIf ln_TotDeps > ln_TotRets Then
            ln_Monto = ln_TotDeps - ln_TotRets
            blnDepMayor = True
            blnRetMayor = False
            'If MsgBox("Se tienen depósitos mayores a los retiros, por un monto de: USD " & Format(Double.Parse(ln_Monto), "#0.00") & " ¿Es correcto?", vbYesNo) = vbNo Then
            '    Exit Sub
            'End If
        Else
            ls_Monto = "0"
            ls_Tipo = ""
            ls_Info = ""
            ln_Monto = 0
            blnDepMayor = False
            blnRetMayor = False
            'If MsgBox("Se tienen depósitos iguales a los retiros, por un monto de: USD " & Format(Double.Parse(ln_Monto), "#0.00") & " ¿Es correcto?", vbYesNo) = vbNo Then
            '    Exit Sub
            'End If
        End If

        ls_Year = CDate(gs_FechaHoy).Year.ToString.Substring(2, 2) 'Microsoft.VisualBasic.Right(gs_FechaHoy, 2)   'lmc 23-ago-2002
        ls_Month = CDate(gs_FechaHoy).Month 'Microsoft.VisualBasic.Left(gs_FechaHoy, 2)
        ls_Day = CDate(gs_FechaHoy).Day 'Microsoft.VisualBasic.Mid(gs_FechaHoy, 4, 2)
        If ls_Day.Length = 1 Then
            ls_Day = "0" & ls_Day
        End If
        If ls_Month.Length = 1 Then
            ls_Month = "0" & ls_Month
        End If

IniciaTran:
        'dbBeginTran
        objDatasource.IniciaTransaccion()
        gs_Sql = "Update PARAMETROS "
        gs_Sql = gs_Sql & " set mt202_banco = '" & ls_Banco & "', "
        gs_Sql = gs_Sql & " mt202_bancodest = '" & Ls_BancoDest & "',"
        gs_Sql = gs_Sql & " mt202_tipo = '" & ls_Tipo & "', "
        gs_Sql = gs_Sql & " mt202_info = '" & ls_Info & "',"
        gs_Sql = gs_Sql & " mt202_monto2 = " & ln_Monto & ", "
        gs_Sql = gs_Sql & " mt202_anio = '" & ls_Year & "',"
        gs_Sql = gs_Sql & " mt202_mes = '" & ls_Month & "', "
        gs_Sql = gs_Sql & " mt202_dia = '" & ls_Day & "' "
        'dbExecQuery(gs_Sql)                                          ' Actualiza PARAMETROS
        'If dbError Then

        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
            'dbEndQuery
            MsgBox("Ocurrio un error al imprimir el reporte.")
            'dbRollback
            objDatasource.RollbackTransaccion()
            Exit Sub
        Else
            'dbEndQuery
        End If
        gs_Sql = "DELETE FROM REPORTE_MT202"
        'dbExecQuery(gs_Sql)                                          ' Limpia REPORTE_MT202
        'If dbError Then

        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
            'dbEndQuery
            MsgBox("Ocurrio un error al imprimir el reporte.")
            'dbRollback
            objDatasource.RollbackTransaccion()
            Exit Sub
        End If
        'dbEndQuery
        'ls_Time = Format(Time, "hh:mm")
        dtRespConsulta = objDatasource.RealizaConsulta("SELECT convert(char(5),getdate(),14)")
        gs_HoraSistema = dtRespConsulta.Rows(0).Item(0).ToString
        ls_Time = gs_HoraSistema 'Format(gs_HoraSistema, "hh:mm")
        gs_Sql = "Insert into REPORTE_MT202 "
        gs_Sql = gs_Sql & "( descripcion_operacion_definida, total_operaciones, "
        gs_Sql = gs_Sql & "monto_operaciones, tipo_operacion ) "
        gs_Sql = gs_Sql & " select OD.descripcion_operacion_definida, count(*), "
        gs_Sql = gs_Sql & " sum(O.monto_operacion), 0"
        gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, OPERACION O, "
        gs_Sql = gs_Sql & " REPORTE_SWIFT RS, OPERACION_DEFINIDA OD, " & "FUNCIONARIOS" & "..FUNCIONARIO F"
        gs_Sql = gs_Sql & " where status_reporte in (2,3,4,5)"
        gs_Sql = gs_Sql & " and O.operacion = OS.operacion "
        gs_Sql = gs_Sql & " and O.funcionario = F.funcionario "
        gs_Sql = gs_Sql & " and F.bbvab = 1 "   ' sólo operaciones realizadas con funcionarios que operan en suc migradas
        gs_Sql = gs_Sql & " and RS.no_rep_swift = OS.no_rep_swift"
        gs_Sql = gs_Sql & " and O.operacion_definida = OD.operacion_definida"
        If Val(sAgencia) = 3 Then                                     ' RETIROS en Cayman
            gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sRetirosCayman & ")"
        Else                                                          ' RETIROS LA y NY
            gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sRetirosNYLA & ")"
        End If
        gs_Sql = gs_Sql & " and RS.fecha_reporte = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
        gs_Sql = gs_Sql & " and RS.agencia = " & Val(sAgencia)
        gs_Sql = gs_Sql & " and O.status_operacion <> 250 "           ' No canceladas
        If nTipo_202 = 4 Then                                         ' Si es adicional
            gs_Sql = gs_Sql & " and OS.operacion not in (Select operacion "
            gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, REPORTES_EMITIDOS_MT202 RE"
            gs_Sql = gs_Sql & " where OS.numero_reporte_202 = RE.numero_reporte_202"
            gs_Sql = gs_Sql & " and tipo_202 = 1)"
        End If
        gs_Sql = gs_Sql & " Group By OD.descripcion_operacion_definida "

        gs_Sql = gs_Sql & " UNION select OD.descripcion_operacion_definida, count(*), "
        gs_Sql = gs_Sql & " sum(O.monto_operacion), 0"
        gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, OPERACION O, "
        gs_Sql = gs_Sql & " REPORTE_SWIFT RS, OPERACION_DEFINIDA OD "
        gs_Sql = gs_Sql & " where status_reporte in (2,3,4,5)"
        gs_Sql = gs_Sql & " and O.operacion = OS.operacion "
        gs_Sql = gs_Sql & " and O.funcionario is null "
        gs_Sql = gs_Sql & " and RS.no_rep_swift = OS.no_rep_swift"
        gs_Sql = gs_Sql & " and O.operacion_definida = OD.operacion_definida"
        If Val(sAgencia) = 3 Then                                     ' RETIROS en Cayman
            gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sRetirosCayman & ")"
        Else                                                          ' RETIROS LA y NY
            gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sRetirosNYLA & ")"
        End If
        gs_Sql = gs_Sql & " and RS.fecha_reporte = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
        gs_Sql = gs_Sql & " and RS.agencia = " & Val(sAgencia)
        gs_Sql = gs_Sql & " and O.status_operacion <> 250 "           ' No canceladas
        If nTipo_202 = 4 Then                                         ' Si es adicional
            gs_Sql = gs_Sql & " and OS.operacion not in (Select operacion "
            gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, REPORTES_EMITIDOS_MT202 RE"
            gs_Sql = gs_Sql & " where OS.numero_reporte_202 = RE.numero_reporte_202"
            gs_Sql = gs_Sql & " and tipo_202 = 1)"
        End If
        gs_Sql = gs_Sql & " Group By OD.descripcion_operacion_definida "

        'dbExecQuery(gs_Sql)                                          ' Inserta en REPORTE_MT202 las operaciones de Retiros con fecha_corte = hoy
        'If dbError Then

        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
            'dbEndQuery
            MsgBox("Ocurrio un error al imprimir el reporte.")
            'dbRollback
            objDatasource.RollbackTransaccion()
            Exit Sub
        End If
        'dbEndQuery
        gs_Sql = "insert into REPORTE_MT202 "                              ' Inserta en REPORTE_MT202
        gs_Sql = gs_Sql & "( descripcion_operacion_definida, total_operaciones, "
        gs_Sql = gs_Sql & "monto_operaciones, tipo_operacion ) "
        gs_Sql = gs_Sql & " select OD.descripcion_operacion_definida, "
        gs_Sql = gs_Sql & " count(*), sum(O.monto_operacion), 1"
        gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, OPERACION O, "
        gs_Sql = gs_Sql & " REPORTE_SWIFT RS, OPERACION_DEFINIDA OD , " & "FUNCIONARIOS" & "..FUNCIONARIO F"
        gs_Sql = gs_Sql & " where "
        gs_Sql = gs_Sql & " status_reporte in (2,3,4,5)"
        gs_Sql = gs_Sql & " and O.operacion = OS.operacion"
        gs_Sql = gs_Sql & " and O.funcionario = F.funcionario "
        gs_Sql = gs_Sql & " and F.bbvab = 1 "   ' sólo operaciones realizadas con funcionarios que operan en suc migradas
        gs_Sql = gs_Sql & " and RS.no_rep_swift = OS.no_rep_swift"
        gs_Sql = gs_Sql & " and O.operacion_definida = OD.operacion_definida "
        gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sDepositos & ")"
        gs_Sql = gs_Sql & " and RS.fecha_reporte = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
        gs_Sql = gs_Sql & " and RS.agencia = " & Val(sAgencia)
        gs_Sql = gs_Sql & " and O.status_operacion <> 250 "
        If nTipo_202 = 4 Then                                         ' Si es adicional
            gs_Sql = gs_Sql & " and OS.operacion not in (Select operacion"
            gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, REPORTES_EMITIDOS_MT202 RE"
            gs_Sql = gs_Sql & " where OS.numero_reporte_202 = RE.numero_reporte_202"
            gs_Sql = gs_Sql & " and tipo_202 = 1)"
        End If
        gs_Sql = gs_Sql & " Group By OD.descripcion_operacion_definida "

        gs_Sql = gs_Sql & " union  select OD.descripcion_operacion_definida, "
        gs_Sql = gs_Sql & " count(*), sum(O.monto_operacion), 1"
        gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, OPERACION O, "
        gs_Sql = gs_Sql & " REPORTE_SWIFT RS, OPERACION_DEFINIDA OD "
        gs_Sql = gs_Sql & " where "
        gs_Sql = gs_Sql & " status_reporte in (2,3,4,5)"
        gs_Sql = gs_Sql & " and O.operacion = OS.operacion"
        gs_Sql = gs_Sql & " and O.funcionario is null "
        gs_Sql = gs_Sql & " and RS.no_rep_swift = OS.no_rep_swift"
        gs_Sql = gs_Sql & " and O.operacion_definida = OD.operacion_definida "
        gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sDepositos & ")"
        gs_Sql = gs_Sql & " and RS.fecha_reporte = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
        gs_Sql = gs_Sql & " and RS.agencia = " & Val(sAgencia)
        gs_Sql = gs_Sql & " and O.status_operacion <> 250 "
        If nTipo_202 = 4 Then                                         ' Si es adicional
            gs_Sql = gs_Sql & " and OS.operacion not in (Select operacion"
            gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, REPORTES_EMITIDOS_MT202 RE"
            gs_Sql = gs_Sql & " where OS.numero_reporte_202 = RE.numero_reporte_202"
            gs_Sql = gs_Sql & " and tipo_202 = 1)"
        End If
        gs_Sql = gs_Sql & " Group By OD.descripcion_operacion_definida "
        'dbExecQuery(gs_Sql)
        'If dbError Then

        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
            'dbEndQuery
            MsgBox("Ocurrio un error al imprimir el reporte.")
            'dbRollback
            objDatasource.RollbackTransaccion()
            Exit Sub
        End If
        'dbEndQuery
        If nTipo_202 = 2 Or nTipo_202 = 4 Then                        ' Es Definitivo o adicional
            gs_Sql = "Insert into REPORTES_EMITIDOS_MT202 "
            gs_Sql = gs_Sql & "( fecha_reporte, agencia, hora_reporte, tipo_reporte, tipo_202, bbvab ) "
            gs_Sql = gs_Sql & "Values ( '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "', " & Val(sAgencia)
            gs_Sql = gs_Sql & ", '" & ls_Time & "', " & nTipo_202 & ", 1, 1 )"
            'dbExecQuery(gs_Sql)
            'If dbError Then

            If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
                'dbEndQuery
                MsgBox("Ocurrio un error al imprimir el reporte.")
                'dbRollback
                objDatasource.RollbackTransaccion()
                Exit Sub
            End If
            'dbEndQuery
            gs_Sql = "select @@Identity"
            gs_Sql = "Select MAX(numero_reporte_202) from TICKET..REPORTES_EMITIDOS_MT202 With (NOLOCK) "
            'dbExecQuery(gs_Sql)
            'dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            iValorTransaccion = 0
            objDatasource.EjecutaComandoTransaccion(gs_Sql) '--------------- RACB 28/06/2022
            'If dbError Then
            If iValorTransaccion = 0 Then 'If IsNothing(dtRespConsulta) Then
                'dbEndQuery
                MsgBox("Ocurrio un error al imprimir el reporte.")
                'dbRollback
                objDatasource.RollbackTransaccion()
                Exit Sub
            End If
            'dbGetRecord
            'ln_NumRep = Val(dtRespConsulta.Rows(0).Item(0).ToString())
            ln_NumRep = iValorTransaccion '--------------- RACB 28/06/2022
            'dbEndQuery
            gs_Sql = "UPDATE OPERACION_SWIFT "
            gs_Sql = gs_Sql & " set numero_reporte_202 = " & ln_NumRep & ","
            gs_Sql = gs_Sql & " hora_envio = '" & ls_Time & "'"
            gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, OPERACION O, "
            gs_Sql = gs_Sql & " REPORTE_SWIFT RS, OPERACION_DEFINIDA OD , " & "FUNCIONARIOS" & "..FUNCIONARIO F"
            gs_Sql = gs_Sql & " where "
            gs_Sql = gs_Sql & " status_reporte in (2,3,4,5) "
            gs_Sql = gs_Sql & " and O.operacion = OS.operacion"
            gs_Sql = gs_Sql & " and O.funcionario = F.funcionario "
            gs_Sql = gs_Sql & " and F.bbvab = 1 "   ' sólo operaciones realizadas con funcionarios que operan en suc migradas
            gs_Sql = gs_Sql & " and RS.no_rep_swift = OS.no_rep_swift"
            gs_Sql = gs_Sql & " and O.operacion_definida = OD.operacion_definida "
            gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sDepositos & ","
            If Val(sAgencia) = 3 Then
                gs_Sql = gs_Sql & sRetirosCayman & ")"
            Else
                gs_Sql = gs_Sql & sRetirosNYLA & ")"
            End If
            gs_Sql = gs_Sql & " and RS.fecha_reporte = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
            gs_Sql = gs_Sql & " and RS.agencia = " & Val(sAgencia)
            gs_Sql = gs_Sql & " and O.status_operacion <> 250 "
            If nTipo_202 = 4 Then                                       ' Si es adicional
                gs_Sql = gs_Sql & " and OS.operacion not in (select operacion"
                gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, REPORTES_EMITIDOS_MT202 RE"
                gs_Sql = gs_Sql & " where OS.numero_reporte_202 = RE.numero_reporte_202"
                gs_Sql = gs_Sql & " and tipo_202 = 1)"
            End If
            'dbExecQuery(gs_Sql)                                        ' Actualiza OPERACION_SWIFT
            'If dbError Then

            If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
                'dbEndQuery
                MsgBox("Ocurrió un error al imprimir el reporte.")
                'dbRollback
                objDatasource.RollbackTransaccion()
                Exit Sub
            End If
            'dbEndQuery
            '*****
            gs_Sql = "UPDATE OPERACION_SWIFT "
            gs_Sql = gs_Sql & " set numero_reporte_202 = " & ln_NumRep & ","
            gs_Sql = gs_Sql & " hora_envio = '" & ls_Time & "'"
            gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, OPERACION O, "
            gs_Sql = gs_Sql & " REPORTE_SWIFT RS, OPERACION_DEFINIDA OD "
            gs_Sql = gs_Sql & " where "
            gs_Sql = gs_Sql & " status_reporte in (2,3,4,5) "
            gs_Sql = gs_Sql & " and O.operacion = OS.operacion"
            gs_Sql = gs_Sql & " and O.funcionario is null "
            gs_Sql = gs_Sql & " and RS.no_rep_swift = OS.no_rep_swift"
            gs_Sql = gs_Sql & " and O.operacion_definida = OD.operacion_definida "
            gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sDepositos & ","
            If Val(sAgencia) = 3 Then
                gs_Sql = gs_Sql & sRetirosCayman & ")"
            Else
                gs_Sql = gs_Sql & sRetirosNYLA & ")"
            End If
            gs_Sql = gs_Sql & " and RS.fecha_reporte = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
            gs_Sql = gs_Sql & " and RS.agencia = " & Val(sAgencia)
            gs_Sql = gs_Sql & " and O.status_operacion <> 250 "
            If nTipo_202 = 4 Then                                       ' Si es adicional
                gs_Sql = gs_Sql & " and OS.operacion not in (select operacion"
                gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, REPORTES_EMITIDOS_MT202 RE"
                gs_Sql = gs_Sql & " where OS.numero_reporte_202 = RE.numero_reporte_202"
                gs_Sql = gs_Sql & " and tipo_202 = 1)"
            End If
            'dbExecQuery(gs_Sql)                                        ' Actualiza OPERACION_SWIFT
            'If dbError Then

            If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
                'dbEndQuery
                MsgBox("Ocurrió un error al imprimir el reporte.")
                'dbRollback
                objDatasource.RollbackTransaccion()
                Exit Sub
            End If
            'dbEndQuery

        End If

        gs_Sql = "select count(*) "
        gs_Sql = gs_Sql & " from REPORTES_EMITIDOS_MT202 WITH (NOLOCK) "
        gs_Sql = gs_Sql & " where tipo_reporte = 4 and bbvab = 1 and "
        gs_Sql = gs_Sql & " agencia =" & ComboAgencias.SelectedValue
        gs_Sql = gs_Sql & " and fecha_reporte  = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
        'dbExecQuery(gs_Sql)                                            ' Obtiene el No. de operaciones en REPORTES_EMITIDOS_MT202 con fecha_reporte = hoy
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'If Not dbError() Then
        If IsNothing(dtRespConsulta) = False Then
            ln_Numeracion = Val(dtRespConsulta.Rows(0).Item(0))
        End If
        'dbEndQuery

        Select Case nTipo_202
            Case 1
                Ls_Leyenda = "PARCIAL NO ENVIAR"
            Case 2
                Ls_Leyenda = "DEFINITIVO SI ENVIAR"
            Case 4
                Ls_Leyenda = "ADICIONAL " & Trim(CStr(ln_Numeracion))
            Case 3
                Ls_Leyenda = "REIMPRESION"
        End Select

        If GrabarReporteMT202(ln_NumRep, sAgencia, nTipo_202, ls_Tipo, Format(CDate(gs_FechaHoy), "yyyy-MM-dd"), ls_Time,
                          ls_Banco, Ls_BancoDest, CStr(ln_Numeracion), ls_Year, ls_Month, ls_Day,
                          CStr(ln_Monto), ls_BancoRemit, ls_BancoCuenta, Ls_BancoBenef, ls_Info,
                          Ls_Siglas(1), Ls_Siglas(2), Ls_Siglas(3), Ls_Leyenda, blnDepMayor, blnRetMayor) Then
            'dbCommit
            objDatasource.CommitTransaccion()
        Else
            MsgBox("Ocurrió un error al imprimir el reporte.")
            'dbRollback
            objDatasource.RollbackTransaccion()
            Exit Sub
        End If

        lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
        lsReporte = lsRutaFolder & "MT202_det_newBBVA" & lsAmbiente & ".rpt"
        rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
        objLibreria.logonBDreporte(rptDoc, 1)
        'RepMT202.Formulas(0) = "FECHA = 'FECHA: " & InvierteFecha(gs_FechaHoy) & "'"
        'RepMT202.Formulas(1) = "Hora = '" & ls_Time & "'"
        rptDoc.DataDefinition.FormulaFields.Item("Fecha").Text = "'FECHA: " & CDate(gs_FechaHoy).ToString("dd-MM-yyyy") & "'"
        rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & ls_Time & "'"
        Select Case nTipo_202
            Case 1
                'RepMT202.Formulas(2) = "LEYENDA = 'PARCIAL NO ENVIAR'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'PARCIAL NO ENVIAR'"
            Case 2
                'RepMT202.Formulas(2) = "LEYENDA = 'DEFINITIVO SI ENVIAR'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'DEFINITIVO SI ENVIAR'"
            Case 4
                'RepMT202.Formulas(2) = "LEYENDA = 'ADICIONAL ' + '" & CStr(ln_Numeracion) & "'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'ADICIONAL ' + '" & CStr(ln_Numeracion) & "'"
            Case 3
                'RepMT202.Formulas(2) = "LEYENDA = 'REIMPRESION'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'REIMPRESION'"
        End Select

        'RepMT202.Formulas(3) = "Monto = " & ln_Monto
        'RepMT202.Formulas(4) = "NombreAgencia = '" & UCase(ComboAgencias.SelectedText) & "'"
        rptDoc.DataDefinition.FormulaFields.Item("Monto").Text = ln_Monto
        rptDoc.DataDefinition.FormulaFields.Item("NombreAgencia").Text = "'" & UCase(ComboAgencias.SelectedText) & "'"
        'RepMT202.ReportFileName = GPATH & "\MT202_det_newBBVA.rpt"
        'MuestraVentanaReporte RepMT202
        opcionReporte = 16
        RepOperativa.reporteOFAC = rptDoc
        RepOperativa.ShowDialog()

        rptDoc = New ReportDocument
        lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
        lsReporte = lsRutaFolder & "MT202BBVA" & lsAmbiente & ".rpt"
        rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
        objLibreria.logonBDreporte(rptDoc, 1)
        'RepMT202.Formulas(0) = "FECHA = 'FECHA: " & FechaY2K(InvierteFecha(gs_FechaHoy)) & "'"
        'RepMT202.Formulas(1) = "Hora = '" & ls_Time & "'"
        rptDoc.DataDefinition.FormulaFields.Item("Fecha").Text = "'FECHA: " & CDate(gs_FechaHoy).ToString("dd-MM-yyyy") & "'"
        rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & ls_Time & "'"

        Select Case nTipo_202
            Case 1
                'RepMT202.Formulas(2) = "LEYENDA = 'PARCIAL NO ENVIAR'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'PARCIAL NO ENVIAR'"
            Case 2
                'RepMT202.Formulas(2) = "LEYENDA = 'DEFINITIVO SI ENVIAR'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'DEFINITIVO SI ENVIAR'"
            Case 4
                'RepMT202.Formulas(2) = "LEYENDA = 'ADICIONAL ' + '" & CStr(ln_Numeracion) & "'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'ADICIONAL ' + '" & CStr(ln_Numeracion) & "'"
            Case 3
                'RepMT202.Formulas(2) = "LEYENDA = 'REIMPRESION'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'REIMPRESION'"
        End Select

        'RepMT202.Formulas(3) = "rep_folio = '" & CStr(ln_Numeracion) & "'"
        'RepMT202.Formulas(4) = "NombreAgencia = '" & UCase(ComboAgencias.SelectedText) & "'"
        rptDoc.DataDefinition.FormulaFields.Item("rep_folio").Text = "'" & CStr(ln_Numeracion) & "'"
        rptDoc.DataDefinition.FormulaFields.Item("NombreAgencia").Text = "'" & UCase(ComboAgencias.SelectedText) & "'"
        'MARB - IDS Comercial, 25 Feb 03
        'RepMT202.Formulas(5) = "BancoBenef2 = '" & Ls_BancoBenef & "'"
        rptDoc.DataDefinition.FormulaFields.Item("BancoBenef2").Text = "'" & Ls_BancoBenef & "'"
        '** siglas para la comparación de tipo en el reporte
        'RepMT202.Formulas(6) = "SiglasLA = '" & Ls_Siglas(1) & "'"
        'RepMT202.Formulas(7) = "SiglasNY = '" & Ls_Siglas(2) & "'"
        'RepMT202.Formulas(8) = "SiglasGC = '" & Ls_Siglas(3) & "'"
        rptDoc.DataDefinition.FormulaFields.Item("SiglasLA").Text = "'" & "HO" & "'"
        'rptDoc.DataDefinition.FormulaFields.Item("SiglasNY").Text = "'" & Ls_Siglas(2) & "'"
        'rptDoc.DataDefinition.FormulaFields.Item("SiglasGC").Text = "'" & Ls_Siglas(3) & "'"
        'RepMT202.Formulas(9) = "BancoRemitente1 = '" & ls_BancoRemit & "'"
        'RepMT202.Formulas(10) = "BancoCuenta1 = '" & ls_BancoCuenta & "'"
        rptDoc.DataDefinition.FormulaFields.Item("BancoRemitente1").Text = "'" & ls_BancoRemit & "'"
        rptDoc.DataDefinition.FormulaFields.Item("BancoCuenta1").Text = "'" & ls_BancoCuenta & "'"

        'RepMT202.ReportFileName = GPATH & "\mt202BBVA.rpt"
        'MuestraVentanaReporte RepMT202
        opcionReporte = 16
        RepOperativa.reporteOFAC = rptDoc
        RepOperativa.ShowDialog()
    End Sub
    '---------------------------------------------------------------------------------------------------------
    'Regresa el total de la suma de las operaciones de deposito o retiro de una agencia
    '---------------------------------------------------------------------------------------------------------
    Private Function TotalOperacion(SOperaciong As String, sAgencia As Integer, nTipo_202 As Integer) As Double
        Dim dtRespConsulta As New DataTable()
        'dbEndQuery
        gs_Sql = " select sum(O.monto_operacion) "
        gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, OPERACION O, "
        gs_Sql = gs_Sql & " REPORTE_SWIFT RS, OPERACION_DEFINIDA OD, " & "FUNCIONARIOS" & "..FUNCIONARIO F"
        gs_Sql = gs_Sql & "  where "
        gs_Sql = gs_Sql & " O.operacion = OS.operacion "
        gs_Sql = gs_Sql & " and RS.no_rep_swift = OS.no_rep_swift "
        gs_Sql = gs_Sql & " and O.operacion_definida = OD.operacion_definida "
        gs_Sql = gs_Sql & " and O.funcionario = F.funcionario "
        gs_Sql = gs_Sql & " and F.bbvab = 1 "   ' sólo operaciones realizadas con funcionarios que operan en suc migradas
        gs_Sql = gs_Sql & " and RS.fecha_reporte = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
        gs_Sql = gs_Sql & " and RS.agencia = " & sAgencia & " "
        gs_Sql = gs_Sql & " and RS.status_reporte in (2,3,4,5) "
        gs_Sql = gs_Sql & " and O.status_operacion <> 250 "
        If nTipo_202 = 4 Then             ' Si es adicional
            gs_Sql = gs_Sql & " and OS.operacion not in ( select operacion "
            gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, REPORTES_EMITIDOS_MT202 RE"
            gs_Sql = gs_Sql & " where OS.numero_reporte_202 = RE.numero_reporte_202"
            gs_Sql = gs_Sql & " and tipo_202 = 1)"
        End If
        If SOperaciong = "RETIRO" Then
            If sAgencia = 3 Then            ' Retiro Cayman
                gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sRetirosCayman & ")"
            Else                            ' Retiro NYLA
                gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sRetirosNYLA & ")"
            End If                          ' Depósitos
        ElseIf SOperaciong = "DEPOSITO" Then
            gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sDepositos & ")"
        End If
        'dbExecQuery(gs_Sql)
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'If Not IsdbError Then
        If IsNothing(dtRespConsulta) = False Then
            If dtRespConsulta.Rows(0).Item(0).ToString() = "" Then
                TotalOperacion = 0
            Else
                TotalOperacion = Val(dtRespConsulta.Rows(0).Item(0).ToString())
            End If
        Else
            'dbEndQuery
            MsgBox("Ocurrio un error al obtener el monto")
            TotalOperacion = 0
        End If
        'dbEndQuery

        '''***

        gs_Sql = " select sum(O.monto_operacion) "
        gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, OPERACION O, "
        gs_Sql = gs_Sql & " REPORTE_SWIFT RS, OPERACION_DEFINIDA OD "
        gs_Sql = gs_Sql & "  where "
        gs_Sql = gs_Sql & " O.operacion = OS.operacion "
        gs_Sql = gs_Sql & " and RS.no_rep_swift = OS.no_rep_swift "
        gs_Sql = gs_Sql & " and O.operacion_definida = OD.operacion_definida "
        gs_Sql = gs_Sql & " and O.funcionario is null "
        gs_Sql = gs_Sql & " and RS.fecha_reporte = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "'"
        gs_Sql = gs_Sql & " and RS.agencia = " & sAgencia & " "
        gs_Sql = gs_Sql & " and RS.status_reporte in (2,3,4,5) "
        gs_Sql = gs_Sql & " and O.status_operacion <> 250 "
        If nTipo_202 = 4 Then             ' Si es adicional
            gs_Sql = gs_Sql & " and OS.operacion not in ( select operacion "
            gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, REPORTES_EMITIDOS_MT202 RE"
            gs_Sql = gs_Sql & " where OS.numero_reporte_202 = RE.numero_reporte_202"
            gs_Sql = gs_Sql & " and tipo_202 = 1)"
        End If
        If SOperaciong = "RETIRO" Then
            If sAgencia = 3 Then            ' Retiro Cayman
                gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sRetirosCayman & ")"
            Else                            ' Retiro NYLA
                gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sRetirosNYLA & ")"
            End If                          ' Depósitos
        ElseIf SOperaciong = "DEPOSITO" Then
            gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sDepositos & ")"
        End If
        'dbExecQuery(gs_Sql)
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'If Not IsdbError Then
        If IsNothing(dtRespConsulta) = False Then
            'If dbGetValue(0) <> "" Then
            If dtRespConsulta.Rows(0).Item(0).ToString() <> "" Then
                TotalOperacion = Val(dtRespConsulta.Rows(0).Item(0).ToString()) + TotalOperacion
            End If
        Else
            'dbEndQuery
            MsgBox("Ocurrio un error al obtener el monto")
            TotalOperacion = 0
        End If
        'dbEndQuery
    End Function
    Private Sub cmdHistorico_Click(sender As Object, e As EventArgs) Handles cmdHistorico.Click
        Dim ls_FechaCaptura As String
        Dim ln_Reportes As Long
        Dim ln_Index As Long
        Dim dtRespConsulta As New DataTable()
        Dim objclGlobal As New Cursors

        'ls_FechaCaptura = InputBox("¿Para qué fecha desea imprimir el histórico del MT202?  (dd-mm-aaaa)", , InvierteFecha(gs_FechaHoy), 3000, 3000)
        ls_FechaCaptura = InputBox("¿Para qué fecha desea imprimir el histórico del MT202?  (dd-mm-aaaa)", "Fecha de Historico", Format(CDate(gs_FechaHoy), "dd-MM-yyyy"), 100, 0)
        If ls_FechaCaptura = "" Or Not objclGlobal.EsFechaY2K(ls_FechaCaptura) Then
            MsgBox("Utilice el Formato de Fecha dd-mm-aaaa.", vbInformation, "Fecha Erronea")
            Exit Sub
        ElseIf CDate(ls_FechaCaptura) > DateTime.Today Then
            MsgBox("La fecha de impresión no debe ser mayor al día de hoy.", vbInformation, "Fecha Erronea")
            Exit Sub
        End If
        'ls_FechaCaptura = InvierteFecha(ls_FechaCaptura)
        'Screen.MousePointer = vbHourglass
        gs_Sql = "select count(*) "
        gs_Sql = gs_Sql & " from REPORTES_EMITIDOS_MT202 R WITH (NOLOCK)"
        gs_Sql = gs_Sql & " where R.fecha_reporte = '" & Format(CDate(ls_FechaCaptura), "yyyy-MM-dd") & "'"
        gs_Sql = gs_Sql & " and R.tipo_202 = 1"
        gs_Sql = gs_Sql & " and R.bbvab = 1 "
        gs_Sql = gs_Sql & " and agencia = " & ComboAgencias.SelectedValue
        'dbExecQuery(gs_Sql)                        ' Obtiene el No. de operaciones en REPORTES_EMITIDOS_MT202 con fecha_reporte = hoy y tipo_202 = 1
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'If dbError Then
        If IsNothing(dtRespConsulta) Or dtRespConsulta.Rows(0).Item(0) = 0 Then
            'dbEndQuery
            MsgBox("No se encontró histórico con la fecha indicada.")
            Exit Sub
        Else
            ln_Reportes = Val(dtRespConsulta.Rows(0).Item(0))
            'dbEndQuery
        End If
        If ln_Reportes = 1 Then                     ' Si existe una operación entonces obtiene el numero_reporte_202
            gs_Sql = "select numero_reporte_202 "
            gs_Sql = gs_Sql & " from REPORTES_EMITIDOS_MT202 R WITH (NOLOCK)"
            gs_Sql = gs_Sql & " where R.fecha_reporte = '" & Format(CDate(ls_FechaCaptura), "yyyy-MM-dd") & "'"
            gs_Sql = gs_Sql & " and R.tipo_202 = 1"
            gs_Sql = gs_Sql & " and R.bbvab = 1 "
            gs_Sql = gs_Sql & " and agencia = " & ComboAgencias.SelectedValue
            'dbExecQuery(gs_Sql)
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            ReDim la_Reportes(1)
            'la_Reportes(0) = Val(dbGetValue(0))
            la_Reportes(0) = Val(dtRespConsulta.Rows(0).Item(0))
            'dbEndQuery
            ImprimeHistorico(ComboAgencias.SelectedValue, 3, la_Reportes(0), Format(CDate(ls_FechaCaptura), "yyyy-MM-dd"))
        Else
            gs_Sql = "select numero_reporte_202 "
            gs_Sql = gs_Sql & " from REPORTES_EMITIDOS_MT202 R WITH (NOLOCK), PARAMETROS P WITH (NOLOCK)"
            gs_Sql = gs_Sql & " where R.fecha_reporte = '" & Format(CDate(ls_FechaCaptura), "yyyy-MM-dd") & "'"
            gs_Sql = gs_Sql & " and R.tipo_202 = 1"
            gs_Sql = gs_Sql & " and R.bbvab = 1 "
            gs_Sql = gs_Sql & " and agencia = " & ComboAgencias.SelectedValue
            'dbExecQuery(gs_Sql)
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            ReDim la_Reportes(ln_Reportes)
            For ln_Index = 0 To ln_Reportes - 1
                'la_Reportes(ln_Index) = Val(dbGetValue(0))
                la_Reportes(ln_Index) = Val(dtRespConsulta.Rows(ln_Index).Item(0))
                'dbGetRecord
            Next ln_Index
            'dbEndQuery
            For ln_Index = 0 To ln_Reportes - 1
                ImprimeHistorico(ComboAgencias.SelectedValue, 3, la_Reportes(ln_Index), Format(CDate(ls_FechaCaptura), "yyyy-MM-dd"))
            Next ln_Index
        End If
        'Screen.MousePointer = vbDefault
        'cmdHistorico_LostFocus
    End Sub
    Private Sub ImprimeHistorico(sAgencia As String, nTipo_202 As Integer, ByVal Num_reporte_MT202 As Long, FechaCapturada As String)

        Dim ln_TotRets As Double
        Dim ln_TotDeps As Double
        Dim ls_Banco As String
        Dim Ls_BancoDest As String
        Dim ls_BancoRemit As String
        Dim ls_BancoCuenta As String
        Dim ls_Tipo As String
        Dim ls_Info As String
        Dim ls_Monto As String
        Dim sTipoReimp As String
        Dim ln_Monto As Double
        Dim ls_Year As String
        Dim ls_Month As String
        Dim ls_Day As String
        Dim ls_Time As String
        Dim ln_NumRep As Long
        'MARB
        Dim Ls_BancoBenef As String
        Dim dtRespConsulta As New DataTable()
        Dim rptDoc As New ReportDocument
        Dim lsAmbiente As String = ""
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""

        ln_TotDeps = 0
        ln_TotRets = 0
        ln_TotDeps = TotalOperacionesHistorico("DEPOSITO", ComboAgencias.SelectedValue, nTipo_202, Num_reporte_MT202, FechaCapturada)
        ln_TotRets = TotalOperacionesHistorico("RETIRO", ComboAgencias.SelectedValue, nTipo_202, Num_reporte_MT202, FechaCapturada)
        'lmc 23-ago-2002
        Call ObtienInfBanco(ComboAgencias.SelectedValue, ln_TotDeps, ln_TotRets, ls_Banco, Ls_BancoDest, ls_Tipo, ls_Info, Ls_BancoBenef, ls_BancoRemit, ls_BancoCuenta)

        If ln_TotDeps < ln_TotRets Then
            ln_Monto = ln_TotRets - ln_TotDeps
        ElseIf ln_TotDeps > ln_TotRets Then
            ln_Monto = ln_TotDeps - ln_TotRets
        Else
            ls_Monto = "0"
            ls_Tipo = ""
            ls_Info = ""
            ln_Monto = 0
        End If
        ls_Year = CDate(FechaCapturada).Year.ToString.Substring(2, 2) 'Microsoft.VisualBasic.Right(FechaCapturada, 2)  'lmc. 26-agp-2002
        ls_Month = CDate(FechaCapturada).Month 'Microsoft.VisualBasic.Left(FechaCapturada, 2)
        ls_Day = CDate(FechaCapturada).Day 'Microsoft.VisualBasic.Mid(FechaCapturada, 4, 2)

IniciaTran:
        'dbBeginTran
        objDatasource.IniciaTransaccion()
        gs_Sql = "update PARAMETROS "
        gs_Sql = gs_Sql & " set mt202_banco = '" & ls_Banco & "', "
        gs_Sql = gs_Sql & " mt202_bancodest = '" & Ls_BancoDest & "',"
        gs_Sql = gs_Sql & " mt202_tipo = '" & ls_Tipo & "', "
        gs_Sql = gs_Sql & " mt202_info = '" & ls_Info & "',"
        gs_Sql = gs_Sql & " mt202_monto2 = " & ln_Monto & ", "
        gs_Sql = gs_Sql & " mt202_anio = '" & ls_Year & "',"
        gs_Sql = gs_Sql & " mt202_mes = '" & ls_Month & "', "
        gs_Sql = gs_Sql & " mt202_dia = '" & ls_Day & "' "
        'dbExecQuery(gs_Sql)                            ' Actualiza PARAMETROS
        'If dbError Then

        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
            'dbEndQuery
            MsgBox("Ocurrio un error al imprimir el reporte.")
            'dbRollback
            objDatasource.RollbackTransaccion()
            Exit Sub
        Else
            'dbEndQuery
        End If
        gs_Sql = "DELETE FROM REPORTE_MT202"

        'dbExecQuery(gs_Sql)                            ' Limpia REPORTE_MT202
        'If dbError Then
        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
            'dbEndQuery
            MsgBox("Ocurrio un error al imprimir el reporte.")
            'dbRollback
            objDatasource.RollbackTransaccion()
            Exit Sub
        End If
        'dbEndQuery
        'ls_Time = Format(Time, "hh:mm")
        ls_Time = Format(gs_HoraSistema, "hh:mm")
        gs_Sql = "insert into REPORTE_MT202 "
        gs_Sql = gs_Sql & "( descripcion_operacion_definida, total_operaciones, "
        gs_Sql = gs_Sql & "monto_operaciones, tipo_operacion ) "
        gs_Sql = gs_Sql & " select OD.descripcion_operacion_definida, count(*), "
        gs_Sql = gs_Sql & " sum(O.monto_operacion), 0"
        gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, OPERACION O, REPORTE_SWIFT RS, "
        gs_Sql = gs_Sql & " OPERACION_DEFINIDA OD, REPORTES_EMITIDOS_MT202 RE "
        gs_Sql = gs_Sql & " where status_reporte in (2,3,4,5) "
        gs_Sql = gs_Sql & " and O.operacion = OS.operacion"
        gs_Sql = gs_Sql & " and RS.no_rep_swift = OS.no_rep_swift"
        gs_Sql = gs_Sql & " and O.operacion_definida = OD.operacion_definida"
        gs_Sql = gs_Sql & " and RE.bbvab = 1 "   ' sólo operaciones realizadas MT202 BBVA
        If Val(sAgencia) = 3 Then                       ' Cayman
            gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sRetirosCayman & ")"
        Else                                            ' NY, LA
            gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sRetirosNYLA & ")"
        End If
        gs_Sql = gs_Sql & " and RS.fecha_reporte = '" & Format(CDate(FechaCapturada), "yyyy-MM-dd") & "'"
        gs_Sql = gs_Sql & " and RS.agencia = " & sAgencia
        gs_Sql = gs_Sql & " and OS.numero_reporte_202 =" & Num_reporte_MT202
        gs_Sql = gs_Sql & " and RE.tipo_202 = 1"        ' corte parcial
        gs_Sql = gs_Sql & " and OS.numero_reporte_202 =  RE.numero_reporte_202 "
        gs_Sql = gs_Sql & " Group By OD.descripcion_operacion_definida "

        'dbExecQuery(gs_Sql)                            ' Inserta en REPORTE_MT202 las operaciones de Retiros con fecha_reporte = hoy y tipo_202 = 1
        'If dbError Then

        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
            'dbEndQuery
            MsgBox("Ocurrio un error al imprimir el reporte.")
            'dbRollback
            objDatasource.RollbackTransaccion()
            Exit Sub
        End If
        'dbEndQuery
        gs_Sql = "insert into REPORTE_MT202 "
        gs_Sql = gs_Sql & "( descripcion_operacion_definida, total_operaciones, "
        gs_Sql = gs_Sql & "monto_operaciones, tipo_operacion ) "
        gs_Sql = gs_Sql & " select OD.descripcion_operacion_definida, count(*), "
        gs_Sql = gs_Sql & " sum(O.monto_operacion), 1"
        gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, OPERACION O, REPORTE_SWIFT RS, "
        gs_Sql = gs_Sql & " OPERACION_DEFINIDA OD, REPORTES_EMITIDOS_MT202 RE "
        gs_Sql = gs_Sql & " where status_reporte in (2,3,4,5) "
        gs_Sql = gs_Sql & " and O.operacion = OS.operacion"
        gs_Sql = gs_Sql & " and RS.no_rep_swift = OS.no_rep_swift"
        gs_Sql = gs_Sql & " and O.operacion_definida = OD.operacion_definida "
        gs_Sql = gs_Sql & " and RE.bbvab = 1 "   ' sólo operaciones realizadas MT202 BBVA
        gs_Sql = gs_Sql & " and OD.operacion_definida_global in (" & sDepositos & ")"
        gs_Sql = gs_Sql & " and RS.fecha_reporte = '" & Format(CDate(FechaCapturada), "yyyy-MM-dd") & "'"
        gs_Sql = gs_Sql & " and RS.agencia = " & Val(sAgencia)
        gs_Sql = gs_Sql & " and OS.numero_reporte_202 =" & Num_reporte_MT202
        gs_Sql = gs_Sql & " and RE.tipo_202 = 1"        ' corte parcial
        gs_Sql = gs_Sql & " and OS.numero_reporte_202 =  RE.numero_reporte_202 "
        gs_Sql = gs_Sql & " Group By OD.descripcion_operacion_definida "
        'dbExecQuery(gs_Sql)                            ' Inserta en REPORTE_MT202 las operaciones de Depositos con fecha_reporte = hoy y tipo_202 = 1
        'If dbError Then

        If objDatasource.EjecutaComandoTransaccion(gs_Sql) = False Then
            'dbEndQuery
            MsgBox("Ocurrio un error al imprimir el reporte.")
            'dbRollback
            objDatasource.RollbackTransaccion()
            Exit Sub
        End If
        'dbEndQuery
        'dbCommit
        objDatasource.CommitTransaccion()
        gs_Sql = "select tipo_reporte "
        gs_Sql = gs_Sql & " from REPORTES_EMITIDOS_MT202 WITH (NOLOCK) "
        gs_Sql = gs_Sql & "where numero_reporte_202 = " & Num_reporte_MT202
        gs_Sql = gs_Sql & " and bbvab = 1 "
        'dbExecQuery(gs_Sql)                            ' Obtiene el tipo_reporte de REPORTES_EMITIDOS_MT202
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'If Not dbError() Then
        If IsNothing(dtRespConsulta) = False Then
            'Select Case dbGetValue(0)
            Select Case dtRespConsulta.Rows(0).Item(0)
                Case 2
                    sTipoReimp = " DEFINITIVO"
                Case 4
                    sTipoReimp = " ADICIONAL"
            End Select
        Else
            MsgBox("Ocurrió un error al accesar la base de datos.")
        End If
        'dbEndQuery

        lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
        lsReporte = lsRutaFolder & "MT202_det_newBBVA" & lsAmbiente & ".rpt"
        rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
        objLibreria.logonBDreporte(rptDoc, 1)
        rptDoc.DataDefinition.FormulaFields.Item("FECHA").Text = "'FECHA: " & Format(CDate(FechaCapturada), "MM-dd-yyyy") & "'"
        rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & ls_Time & "'"
        Select Case nTipo_202
            Case 1
                'rptDoc.Formulas(2) = "Leyenda = 'PARCIAL NO ENVIAR'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'PARCIAL NO ENVIAR'"
            Case 2
                'RepMT202.Formulas(2) = "Leyenda = 'DEFINITIVO SI ENVIAR'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'DEFINITIVO SI ENVIAR'"
            Case 4
                'RepMT202.Formulas(2) = "Leyenda = 'ADICIONAL'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'ADICIONAL'"
            Case 3
                'RepMT202.Formulas(2) = "Leyenda = 'HISTORICO' + '" & sTipoReimp & "'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'HISTORICO' + '" & sTipoReimp & "'"
        End Select
        'RepMT202.Formulas(3) = "Monto = " & ln_Monto
        rptDoc.DataDefinition.FormulaFields.Item("Monto").Text = ln_Monto
        'RepMT202.Formulas(4) = "NombreAgencia = '" & UCase(ComboAgencias.List(ComboAgencias.ListIndex)) & "'"
        rptDoc.DataDefinition.FormulaFields.Item("NombreAgencia").Text = "'" & UCase(ComboAgencias.SelectedText) & "'"
        'RepMT202.ReportFileName = GPATH & "\MT202_det_newBBVA.rpt"
        'MuestraVentanaReporte(RepMT202)
        opcionReporte = 16
        RepOperativa.reporteOFAC = rptDoc
        RepOperativa.ShowDialog()

        lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
        lsReporte = lsRutaFolder & "MT202BBVA" & lsAmbiente & ".rpt"
        rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
        objLibreria.logonBDreporte(rptDoc, 1)
        'RepMT202.Formulas(0) = "FECHA = 'FECHA: " & InvierteFecha(FechaCapturada) & "'"
        'RepMT202.Formulas(1) = "Hora = '" & ls_Time & "'"
        rptDoc.DataDefinition.FormulaFields.Item("FECHA").Text = "'FECHA: " & Format(CDate(FechaCapturada), "MM-dd-yyyy") & "'"
        rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & ls_Time & "'"
        Select Case nTipo_202
            Case 1
                'RepMT202.Formulas(2) = "Leyenda = 'PARCIAL NO ENVIAR'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'PARCIAL NO ENVIAR'"
            Case 2
                'RepMT202.Formulas(2) = "Leyenda = 'DEFINITIVO SI ENVIAR'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'DEFINITIVO SI ENVIAR'"
            Case 4
                'RepMT202.Formulas(2) = "Leyenda = 'ADICIONAL'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'ADICIONAL'"
            Case 3
                'RepMT202.Formulas(2) = "Leyenda = 'HISTORICO' + '" & sTipoReimp & "'"
                rptDoc.DataDefinition.FormulaFields.Item("Leyenda").Text = "'HISTORICO' + '" & sTipoReimp & "'"
        End Select
        'RepMT202.Formulas(4) = "NombreAgencia = '" & UCase(ComboAgencias.List(ComboAgencias.ListIndex)) & "'"
        rptDoc.DataDefinition.FormulaFields.Item("NombreAgencia").Text = "'" & UCase(ComboAgencias.SelectedText) & "'"
        'MARB - IDS Comercial, 25 Feb 03
        'RepMT202.Formulas(5) = "BancoBenef2 = '" & UCase(Ls_BancoBenef) & "'"
        rptDoc.DataDefinition.FormulaFields.Item("BancoBenef2").Text = "'" & UCase(Ls_BancoBenef) & "'"
        '** siglas para la comparación de tipo en el reporte
        'RepMT202.Formulas(6) = "SiglasLA = '" & Ls_Siglas(1) & "'"
        'RepMT202.Formulas(7) = "SiglasNY = '" & Ls_Siglas(2) & "'"
        'RepMT202.Formulas(8) = "SiglasGC = '" & Ls_Siglas(3) & "'"
        rptDoc.DataDefinition.FormulaFields.Item("SiglasLA").Text = "'" & "HO" & "'"
        'rptDoc.DataDefinition.FormulaFields.Item("SiglasNY").Text = "'" & Ls_Siglas(2) & "'"
        'rptDoc.DataDefinition.FormulaFields.Item("SiglasGC").Text = "'" & Ls_Siglas(3) & "'"
        '**
        'RepMT202.ReportFileName = GPATH & "\mt202BBVA.rpt"
        'MuestraVentanaReporte(RepMT202)
        opcionReporte = 16
        RepOperativa.reporteOFAC = rptDoc
        RepOperativa.ShowDialog()
    End Sub
    '-----------------------------------------------------------------------------------
    'Obtiene la suma de Depósitos o Retiros de una agencia con FechaCaptura (dd-mm-aaaa)
    '-----------------------------------------------------------------------------------
    Private Function TotalOperacionesHistorico(SOperaciong As String, sAgencia As Integer, nTipo_202 As Integer, ByVal Numero_Reporte As Long, ls_FechaCaptura As String) As Double
        Dim dtRespConsulta As New DataTable()
        gs_Sql = " select sum(O.monto_operacion) "
        gs_Sql = gs_Sql & " from OPERACION_SWIFT OS, OPERACION O, REPORTE_SWIFT RS, "
        gs_Sql = gs_Sql & " OPERACION_DEFINIDA OD, REPORTES_EMITIDOS_MT202 RE "
        gs_Sql = gs_Sql & " where O.operacion = OS.operacion "
        gs_Sql = gs_Sql & " and RS.no_rep_swift = OS.no_rep_swift "
        gs_Sql = gs_Sql & " and O.operacion_definida = OD.operacion_definida "
        gs_Sql = gs_Sql & " and RE.bbvab = 1 "   ' sólo operaciones realizadas MT202 BBVA
        gs_Sql = gs_Sql & " and RS.fecha_reporte = '" & Format(CDate(ls_FechaCaptura), "yyyy-MM-dd") & "'"
        gs_Sql = gs_Sql & " and RS.agencia = " & sAgencia & " "
        gs_Sql = gs_Sql & " and RS.status_reporte in (2,3,4,5) "
        gs_Sql = gs_Sql & " and OS.numero_reporte_202 = " & Numero_Reporte
        gs_Sql = gs_Sql & " and RE.tipo_202 = 1"
        gs_Sql = gs_Sql & " and OS.numero_reporte_202 =  RE.numero_reporte_202 "
        If SOperaciong = "RETIRO" Then
            If sAgencia = 3 Then ' Retiro Cayman
                gs_Sql = gs_Sql & "and OD.operacion_definida_global in (" & sRetirosCayman & ")"
            Else                 ' Retiro NYLA
                gs_Sql = gs_Sql & "and OD.operacion_definida_global in (" & sRetirosNYLA & ")"
            End If
        ElseIf SOperaciong = "DEPOSITO" Then
            gs_Sql = gs_Sql & "and OD.operacion_definida_global in (" & sDepositos & ")"
        End If
        'dbExecQuery(gs_Sql)
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'If Not IsdbError Then
        If IsNothing(dtRespConsulta) = False Then
            'If dbGetValue(0) = "" Then
            If dtRespConsulta.Rows(0).Item(0).ToString() = "" Then
                TotalOperacionesHistorico = 0
            Else
                TotalOperacionesHistorico = Val(dtRespConsulta.Rows(0).Item(0))
            End If
        Else
            MsgBox("Ocurrio un error al obtener el monto")
            'dbEndQuery
            TotalOperacionesHistorico = 0
        End If
        'dbEndQuery
    End Function
    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir de Envió de mensaje MT2002") <> vbYes Then
            Exit Sub
        End If
        Me.Close()
    End Sub
End Class