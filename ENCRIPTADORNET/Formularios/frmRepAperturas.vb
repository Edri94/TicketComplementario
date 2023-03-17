Public Class frmRepAperturas
    Private Sub frmRepAperturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        'asigna fecha a controles de fecha
        dtpFechaInicio.Value = Date.Now.Date.ToString("yyyy-MM-dd")
        dtpFechaFin.Value = Date.Now.Date.ToString("yyyy-MM-dd")

        iReportes = 1

    End Sub

    Private Sub cmdBuscar_Click(sender As Object, e As EventArgs) Handles cmdBuscar.Click
        'realizar la busqueda de cuentas aperturadas en el intervalo de tiempo establecido
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        'revisa que opción se eligio
        If rb_DelDia.Checked Then
            ListaAperturasdelDia()
        End If

        If rb_ValidadasdelDia.Checked Then
            ListaAperturasValidadasdelDia()
        End If

        If rb_PorRango.Checked Then
            ListaAperturasxfecha()
        End If
        'llama a subrutina de carga de datos a control de istado

        If rb_ConsolidXTicket.Checked Then
            ListaAperConsolidadoxTicket()
        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub



    Sub ListaAperturasdelDia()
        'declara variables
        Dim lsFechaInicio As String
        Dim lsFechaFin As String
        Dim dctas = New Datasource
        'Dim dtctas As DataTable

        'asigna fechas a variables
        lsFechaInicio = dtpFechaInicio.Value.ToString("yyyy-MM-dd")
        lsFechaFin = dtpFechaFin.Value.ToString("yyyy-MM-dd")

        'obtiene cuentas dentro de las fecha seleccionada, y llena el Grid de la forma
        gvCuentasAperturadas.DataSource = dctas.LoadCuentasApertura(lsFechaInicio, lsFechaFin)

    End Sub

    Sub ListaAperturasValidadasdelDia()
        'declara variables
        Dim lsFechaInicio As String
        Dim lsFechaFin As String
        Dim dctas = New Datasource
        'Dim dtctas As DataTable

        'asigna fechas a variables
        lsFechaInicio = dtpFechaInicio.Value.ToString("yyyy-MM-dd")
        lsFechaFin = dtpFechaFin.Value.ToString("yyyy-MM-dd")

        'obtiene cuentas dentro de las fecha seleccionada, y llena el Grid de la forma
        gvCuentasAperturadas.DataSource = dctas.LoadCuentasAperturaValidadas(lsFechaInicio, lsFechaFin)

    End Sub

    Sub ListaAperturasxfecha()
        'declara variables
        Dim lsFechaInicio As String
        Dim lsFechaFin As String
        Dim dctas = New Datasource
        'Dim dtctas As DataTable

        'asigna fechas a variables
        lsFechaInicio = dtpFechaInicio.Value.ToString("yyyy-MM-dd")
        lsFechaFin = dtpFechaFin.Value.ToString("yyyy-MM-dd")

        'obtiene cuentas dentro de las fechas asignadas, y llena el Grid de la forma
        gvCuentasAperturadas.DataSource = dctas.LoadCuentasAperturaxFecha(lsFechaInicio, lsFechaFin)

    End Sub

    Sub ListaAperConsolidadoxTicket()
        'declara variables
        Dim lsFechaInicio As String
        Dim lsFechaFin As String
        Dim dctas = New Datasource

        'asigna fechas a variables
        lsFechaInicio = dtpFechaInicio.Value.ToString("yyyy-MM-dd")
        lsFechaFin = dtpFechaFin.Value.ToString("yyyy-MM-dd")

        'obtiene cuentas dentro de las fecha seleccionada, y llena el Grid de la forma
        gvCuentasAperturadas.DataSource = dctas.LoadCuentasAperConsolidadoxTicket(lsFechaInicio, lsFechaFin)


    End Sub



    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click

        Dim ln_Indice As Integer
        Dim ln_NumOps As Integer
        'Dim Agencia As String

        ls_PorImprimir = ""
        opcionReporte = 0

        fe_Inicio = dtpFechaInicio.Value.ToString("yyyy-MM-dd")
        fe_Fin = dtpFechaFin.Value.ToString("yyyy-MM-dd")

        ln_NumOps = gvCuentasAperturadas.RowCount

        '**********************************************************************
        ' Reporte 1, Aperturas del Día
        '**********************************************************************
        If rb_DelDia.Checked Then
            ls_TituloReporte = "Reporte de Aperturas del Día."
            If ln_NumOps > 1 Then    'Descarta el cabecero del Grid
                If ln_NumOps > 2 Then    'considera la opcion OR para la formula
                    For ln_Indice = 0 To (ln_NumOps - 2)
                        If ls_PorImprimir = "" Then
                            ls_PorImprimir = "{OPERACION.operacion} = " + gvCuentasAperturadas.Rows(ln_Indice).Cells(0).Value.ToString()
                        Else
                            ls_PorImprimir = ls_PorImprimir + " OR {OPERACION.operacion} = " + gvCuentasAperturadas.Rows(ln_Indice).Cells(0).Value.ToString()
                        End If
                    Next
                Else
                    'For ln_Indice = 0 To (ln_NumOps - 1)
                    If ls_PorImprimir = "" Then
                        ls_PorImprimir = "{OPERACION.operacion} = " + gvCuentasAperturadas.Rows(ln_Indice).Cells(0).Value.ToString()
                    End If
                    'Next
                End If

                If ls_PorImprimir = "" Then
                    MsgBox("No hay cuentas a Imprimir", MsgBoxStyle.Information)
                    Exit Sub
                Else
                    ls_PorImprimir = "(" + ls_PorImprimir + ")"
                    'reporte numero 1, Aperturas del Dia.
                    opcionReporte = 1
                    RepAperturas.ShowDialog()
                End If
            Else
                MsgBox("No hay cuentas a Imprimir", MsgBoxStyle.Information)
            End If
        End If    'fin rb_DelDia.Checked


        '**********************************************************************
        ' Reporte 2, Aperturas Validadas del Día con Detalle
        '**********************************************************************
        If rb_ValidadasdelDia.Checked Then
            ls_TituloReporte = "Reporte de Aperturas Validadas con Detalle."
            If ln_NumOps > 1 Then
                opcionReporte = 2
                RepAperturas.ShowDialog()
            Else
                MsgBox("No hay cuentas a Imprimir", MsgBoxStyle.Information)
            End If
        End If

        '**********************************************************************
        ' Reporte 3, Aperturas por Rango de Fechas
        '**********************************************************************
        If rb_PorRango.Checked Then
            ls_TituloReporte = "Reporte de Aperturas por Rango de Fechas"
            If ln_NumOps > 1 Then
                'reporte numero 1, Aperturas por Rango de Fechas.
                opcionReporte = 3
                RepAperturas.ShowDialog()
            Else
                MsgBox("No hay cuentas a Imprimir", MsgBoxStyle.Information)
            End If
        End If

        '**********************************************************************
        ' Reporte 4, Apertura Consolidado por Ticket.
        '**********************************************************************
        If rb_ConsolidXTicket.Checked Then
            ls_TituloReporte = "Reporte consolidado de Aperturas por #Ticket."
            If ln_NumOps > 1 Then    'Descarta el cabecero del Grid
                If ln_NumOps > 2 Then    'considera la opcion OR para la formula
                    For ln_Indice = 0 To (ln_NumOps - 2)
                        If ls_PorImprimir = "" Then
                            ls_PorImprimir = "{OPERACION.operacion} = " + gvCuentasAperturadas.Rows(ln_Indice).Cells(0).Value.ToString()
                        Else
                            ls_PorImprimir = ls_PorImprimir + " OR {OPERACION.operacion} = " + gvCuentasAperturadas.Rows(ln_Indice).Cells(0).Value.ToString()
                        End If
                    Next
                Else
                    '-- For ln_Indice = 0 To (ln_NumOps - 1)
                    If ls_PorImprimir = "" Then
                        ls_PorImprimir = "{OPERACION.operacion} = " + gvCuentasAperturadas.Rows(ln_Indice).Cells(0).Value.ToString()
                    End If
                    '-- Next
                End If  'FIN ln_NumOps > 2
                If ls_PorImprimir = "" Then
                    MsgBox("No hay cuentas a Imprimir", MsgBoxStyle.Information)
                    Exit Sub
                Else
                    ls_PorImprimir = "(" + ls_PorImprimir + " and {PRODUCTO_CONTRATADO.agencia}= 1 )"
                    '***********************************
                    'reporte numero 4, Consolidado por Ticket.
                    opcionReporte = 4
                    RepAperturas.ShowDialog()
                    '***********************************
                End If
            Else
                MsgBox("No hay cuentas a Imprimir", MsgBoxStyle.Information)
            End If      'FIN ln_NumOps > 1
        End If  'FIN DE rb_ConsolidXTicket.Checked


    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles rb_DelDia.CheckedChanged
        'inicializa fecha al día de hoy
        dtpFechaInicio.Value = Date.Now.Date.ToString("yyyy-MM-dd")
        dtpFechaFin.Value = Date.Now.Date.ToString("yyyy-MM-dd")
        'inhabilita controles para que no haya cambios.
        dtpFechaInicio.Enabled = True
        dtpFechaFin.Enabled = True

    End Sub

    Private Sub rb_ValidadasdelDia_CheckedChanged(sender As Object, e As EventArgs) Handles rb_ValidadasdelDia.CheckedChanged
        'inicializa fecha al día de hoy
        dtpFechaInicio.Value = Date.Now.Date.ToString("yyyy-MM-dd")
        dtpFechaFin.Value = Date.Now.Date.ToString("yyyy-MM-dd")
        'inhabilita controles para que no haya cambios.
        dtpFechaInicio.Enabled = True
        dtpFechaFin.Enabled = False
    End Sub

    Private Sub rb_PorRango_CheckedChanged(sender As Object, e As EventArgs) Handles rb_PorRango.CheckedChanged
        'inicializa fecha al día de hoy
        dtpFechaInicio.Value = Date.Now.Date.ToString("yyyy-MM-dd")
        dtpFechaFin.Value = Date.Now.Date.ToString("yyyy-MM-dd")
        'inhabilita controles para que no haya cambios.
        dtpFechaInicio.Enabled = True
        dtpFechaFin.Enabled = True
    End Sub

    Private Sub rb_ConsolidXTicket_CheckedChanged(sender As Object, e As EventArgs) Handles rb_ConsolidXTicket.CheckedChanged
        'inicializa fecha al día de hoy
        dtpFechaInicio.Value = Date.Now.Date.ToString("yyyy-MM-dd")
        dtpFechaFin.Value = Date.Now.Date.ToString("yyyy-MM-dd")
        'inhabilita controles para que no haya cambios.
        dtpFechaInicio.Enabled = True
        dtpFechaFin.Enabled = False
    End Sub

    Private Sub gvCuentasAperturadas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvCuentasAperturadas.CellContentClick

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class