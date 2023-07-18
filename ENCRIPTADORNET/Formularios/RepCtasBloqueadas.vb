Public Class RepCtasBloqueadas
    Private ln_TipoBloqueo As Integer
    Private objDatasource As New Datasource
    Private Sub RepCtasBloqueadas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtRespConsulta As DataTable
        'Screen.MousePointer = vbHourglass
        'CargarColores Me, cambio
        'Centerform Me
        gs_Sql = "Select agencia, descripcion_agencia from " & "CATALOGOS" & ".dbo.AGENCIA "
        gs_Sql = gs_Sql & " where agencia = 1" '& GsPermisoAgencia
        gs_Sql = gs_Sql & " order by agencia"
        'dbExecQuery(gs_Sql)
        'dbGetRecord
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'Do While Not IsdbError
        '    lstAgencia.AddItem(dbGetValue(1))
        '    lstAgencia.ItemData(lstAgencia.NewIndex) = dbGetValue(0)
        '    dbGetRecord
        'Loop
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then
            lstAgencia.Items.Add(Convert.ToString(dtRespConsulta.Rows(0).Item(1)))
            lstAgencia.SelectedIndex = 0
        End If
        'dbEndQuery
        'Set lc_Columna = lstBloqueo.ColumnHeaders.Add(, , "Fechas", 650)
        'Set lc_Columna = lstBloqueo.ColumnHeaders.Add(, , "Cuentas", 650, 2)
        'Set lc_Columna = lstBloqueo.ColumnHeaders.Add(, , "Estado", 3200)
        'Set lc_Columna = lstBloqueo.ColumnHeaders.Add(, , "Nombre Cliente", 3000)
        'Screen.MousePointer = vbDefault
        rbOpcReporte0.Checked = True
        ln_TipoBloqueo = 0
    End Sub
    Private Sub rbOpcReporte0_CheckedChanged(sender As Object, e As EventArgs) Handles rbOpcReporte0.CheckedChanged
        If rbOpcReporte0.Checked = True Then
            'txtFecha(0) = FechaY2K(DateAdd("d", -1, InvierteFecha(gs_FechaHoy)))
            'txtFecha(1) = InvierteFecha(gs_FechaHoy)
            dtpFecha0.Visible = True
            dtpFecha1.Visible = True
            'lblFecha.Visible = True
            dtpFecha0.Focus()
        Else
            'dtpFecha(0) = ""
            'dtpFecha(1) = ""
            dtpFecha0.Visible = False
            dtpFecha1.Visible = False
            ' lblFecha.Visible = False
        End If
        If rbOpcReporte1.Checked = True Then
            txtCuenta0.Visible = True
            txtCuenta1.Visible = True
            txtCuenta0.Focus()
        Else
            txtCuenta0.Visible = False
            txtCuenta1.Visible = False
        End If
    End Sub
    Private Sub chkTipoBloqueo1_CheckedChanged(sender As Object, e As EventArgs) Handles chkTipoBloqueo1.CheckedChanged
        TipoBloqueo()
    End Sub
    Private Sub chkTipoBloqueo0_CheckedChanged(sender As Object, e As EventArgs) Handles chkTipoBloqueo0.CheckedChanged
        TipoBloqueo()
    End Sub

    Private Sub chkTipoBloqueo2_CheckedChanged(sender As Object, e As EventArgs) Handles chkTipoBloqueo2.CheckedChanged
        TipoBloqueo()
    End Sub

    Private Sub chkTipoBloqueo3_CheckedChanged(sender As Object, e As EventArgs) Handles chkTipoBloqueo3.CheckedChanged
        TipoBloqueo()
    End Sub

    Private Sub chkTipoBloqueo4_CheckedChanged(sender As Object, e As EventArgs) Handles chkTipoBloqueo4.CheckedChanged
        TipoBloqueo()
    End Sub
    Private Sub TipoBloqueo()
        If chkTipoBloqueo1.Checked = True Then
            ln_TipoBloqueo = ln_TipoBloqueo + 1
        Else
            ln_TipoBloqueo = ln_TipoBloqueo - 1
        End If
    End Sub
    Private Sub cmdBuscar_Click(sender As Object, e As EventArgs) Handles cmdBuscar.Click
        Dim ls_SelectB As String
        Dim ls_SelectA As String
        Dim lb_Existe As Boolean
        Dim dtRespuesta As New DataTable

        'Screen.MousePointer = vbHourglass
        'dbExecQuery("Delete REPORTE_CTAS_BLOQUEADAS")
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        If objDatasource.insertar("Delete REPORTE_CTAS_BLOQUEADAS") = -1 Then
            'dbEndQuery
            'Screen.MousePointer = vbDefault
            MsgBox("Ocurrio un error al operar sobre REPORTE_CTAS_BLOQUEADAS. (Avisar a Sistemas)", vbCritical, "Error de Base de Datos")
            Exit Sub
        End If
        'dbEndQuery
        If DatosCorrectos() Then
            'BAGO-EDS-10/MZO/06. Uso de IsNull en concatenación de cadenas
            ls_SelectA = "select pc.producto_contratado, bcd.bloqueo_observacion, bcd.fecha_bloqueo_proceso,"
            ls_SelectA = ls_SelectA & " bcd.consultor_bloquea, bcd.fecha_restriccion, bcd.tipo_bloqueo"
            ls_SelectB = "select convert(char(10),bcd.fecha_bloqueo_proceso,105) Fechas, c.cuenta_cliente Cuentas, "
            ls_SelectB = ls_SelectB & " bo.descripcion_bloqueo_observacio Estado, rtrim(c.nombre_cliente)+' '+"
            ls_SelectB = ls_SelectB & "rtrim(IsNull(c.apellido_paterno, Space(0)))+' '+rtrim(IsNull(c.apellido_materno, Space(0))) [Nombre Cliente]"
            gs_Sql = " from " & "CATALOGOS" & ".dbo.CLIENTE c, PRODUCTO_CONTRATADO pc,"
            gs_Sql = gs_Sql & " BLOQUEO_CUENTAS_DINAMICO bcd, BLOQUEO_OBSERVACION bo"
            gs_Sql = gs_Sql & " Where pc.producto_contratado = bcd.producto_contratado"
            gs_Sql = gs_Sql & " and bcd.bloqueo_observacion=bo.bloqueo_observacion"
            gs_Sql = gs_Sql & " and c.cuenta_cliente = pc.cuenta_cliente"
            gs_Sql = gs_Sql & " and c.agencia=pc.agencia"
            gs_Sql = gs_Sql & " and pc.status_producto not in (2039,3039,8039)"
            gs_Sql = gs_Sql & " and pc.agencia = " & 1 'lstAgencia.ItemData(lstAgencia.ListIndex) 
            If Len(SeleccionBloqueo) <> 0 Then
                gs_Sql = gs_Sql & " and bo.posicion_bloqueo in (" & SeleccionBloqueo() & ")"
            Else
                gs_Sql = gs_Sql & " and bo.posicion_bloqueo not in (0,11)"
            End If
            If rbOpcReporte0.Checked = True Then
                gs_Sql = gs_Sql & " and bcd.fecha_bloqueo_proceso between '" & Format(dtpFecha0.Value, "yyyy-MM-dd")
                gs_Sql = gs_Sql & "' and '" & Format(dtpFecha1.Value, "yyyy-MM-dd") & "'"
            End If
            If rbOpcReporte1.Checked = True Then
                gs_Sql = gs_Sql & " and c.cuenta_cliente between '" & txtCuenta0.Text & "' and '" & txtCuenta1.Text & "'"
            End If
            If rbOrden0.Checked = True Then
                gs_Sql = gs_Sql & " Order by bcd.fecha_bloqueo_proceso"
            End If
            If rbOrden1.Checked = True Then
                If rbOrden0.Checked = True Then
                    gs_Sql = gs_Sql & ", c.cuenta_cliente"
                Else
                    gs_Sql = gs_Sql & " Order by c.cuenta_cliente"
                End If
            End If
            dtRespuesta = objDatasource.RealizaConsulta(ls_SelectB & gs_Sql)
            dgvBloqueo.DataSource = dtRespuesta
            If dtRespuesta IsNot Nothing And dtRespuesta.Rows.Count > 0 Then
                cmdImprimir.Enabled = True
                lb_Existe = True
            Else
                cmdImprimir.Enabled = False
                lb_Existe = False
            End If
            '        LlenaLista lstBloqueo, "Fechas&Cuentas&Estado&Nombre Cliente", ls_SelectB & gs_Sql, False, False, False, 0, 1
            'If lstBloqueo.ListItems.Count > 0 Then
            '            cmdImprimir.Enabled = True
            '            lb_Existe = True
            '        Else
            '            MsgBox("No se encontraron registros con tales características.", vbInformation, "Resultado")
            '            cmdImprimir.Enabled = False
            '            lb_Existe = False
            '        End If

            If lb_Existe Then
                    'dbExecQuery("Insert Into REPORTE_CTAS_BLOQUEADAS ( producto_contratado, bloqueo_observacion, fecha_bloqueo_proceso, consultor_bloquea, fecha_restriccion, tipo_bloqueo ) " & ls_SelectA & gs_Sql)
                    If objDatasource.insertar("Insert Into REPORTE_CTAS_BLOQUEADAS ( producto_contratado, bloqueo_observacion, fecha_bloqueo_proceso, consultor_bloquea, fecha_restriccion, tipo_bloqueo ) " & ls_SelectA & gs_Sql) = -1 Then
                        MsgBox("Ocurrio un error al operar sobre REPORTE_CTAS_BLOQUEADAS. (Avisar a Sistemas)", vbCritical, "Error de Base de Datos")
                        cmdImprimir.Enabled = False
                    End If
                    'dbEndQuery
                End If
            End If
        'Screen.MousePointer = vbDefault

    End Sub
    Private Function DatosCorrectos() As Boolean
        DatosCorrectos = False
        If lstAgencia.SelectedIndex < 0 Then
            MsgBox("Debe elegir una agencia.", vbInformation, "Falta Agencia")
            Exit Function
        End If
        If rbOpcReporte0.Checked = True Then
            If CDate(dtpFecha0.Value) > CDate(dtpFecha1.Value) Then
                MsgBox("La Fecha Final no debe ser mayor a la Fecha Final.", vbInformation, "Fecha Invalida")
                dtpFecha0.Focus()
                Exit Function
            End If
        End If
        If rbOpcReporte1.Checked = True Then
            If Val(txtCuenta1.Text) < Val(txtCuenta0.Text) Then
                MsgBox("El numero de cuenta final no debe ser mayor al numero de cuenta inicial.", vbInformation, "Cuenta Invalida")
                txtCuenta0.Focus()
                Exit Function
            End If
        End If
        DatosCorrectos = True
    End Function
    Private Function SeleccionBloqueo() As String
        SeleccionBloqueo = ""
        If chkTipoBloqueo0.Checked = True Then SeleccionBloqueo = "1"
        If chkTipoBloqueo1.Checked = True Then SeleccionBloqueo = SeleccionBloqueo & IIf(SeleccionBloqueo = "", "2", ",2")
        If chkTipoBloqueo2.Checked = True Then SeleccionBloqueo = SeleccionBloqueo & IIf(SeleccionBloqueo = "", "3", ",3")
        If chkTipoBloqueo3.Checked = True Then SeleccionBloqueo = SeleccionBloqueo & IIf(SeleccionBloqueo = "", "4", ",4")
        If chkTipoBloqueo4.Checked = True Then SeleccionBloqueo = SeleccionBloqueo & IIf(SeleccionBloqueo = "", "5", ",5")
    End Function
    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        Dim rptDoc As New ReportDocument
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""
        Dim objLibreria As New Libreria
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        If ln_TipoBloqueo = 0 Then
            MsgBox("Seleccione un tipo de Bloqueo.", vbInformation, "Tipo Faltante")
        Else
            If dgvBloqueo.DataSource Is Nothing Then
                MsgBox("No existen cuentas bloqueadas en la lista.", vbInformation, "Sin Datos")
                'cmdBuscar.SetFocus
            Else
                'Screen.MousePointer = vbHourglass
                'rptCtaBloqueada.ReportFileName = GPATH & "\CuentaBloqueada.rpt"
                lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
                lsReporte = lsRutaFolder & "CuentaBloqueada" & ".rpt"
                rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                objLibreria.logonBDreporte(rptDoc, 1)
                'rptCtaBloqueada.Formulas(0) = "TITULO='CUENTAS BLOQUEADAS'"
                rptDoc.DataDefinition.FormulaFields.Item("TITULO").Text = "'CUENTAS BLOQUEADAS'"
                'rptCtaBloqueada.SelectionFormula = "{CLIENTE.agencia}= " & lstAgencia.ItemData(lstAgencia.ListIndex)
                rptDoc.RecordSelectionFormula = "{CLIENTE.agencia}= 1"
                'MuestraVentanaReporte rptCtaBloqueada
                opcionReporte = 16
                RepOperativa.reporteOFAC = rptDoc
                RepOperativa.ShowDialog()
                'Screen.MousePointer = vbDefault
            End If
        End If
    End Sub
    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir de Cuentas Bloqueadas") <> vbYes Then Exit Sub
        Me.Close()
    End Sub
End Class