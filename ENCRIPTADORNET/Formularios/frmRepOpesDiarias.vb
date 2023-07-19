Imports System
Imports System.IO

Public Class frmRepOpesDiarias

    Dim iRegistrosD As Integer = 0
    Dim iRegistrosR As Integer = 0
    Dim iRegistrosT As Integer = 0
    Dim l As New Libreria

    Private Sub cmdBuscar_Click(sender As Object, e As EventArgs) Handles cmdBuscar.Click
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        If ValidaDatos() Then
            If Not LlenaGridOpesDiarias() Then
                cmdExportar.Enabled = False
            Else
                'activa boton de imprimir
                cmdExportar.Enabled = True
            End If
        End If
        Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Function ValidaDatos() As Boolean

        ValidaDatos = False

        If Trim(mtxtFechaIni.Text) = "" Then
            MsgBox("Es necesario indicar una fecha de captura inicial.", MsgBoxStyle.Information, "Fecha Faltante")
            mtxtFechaIni.Select()
            Exit Function
        End If
        If Trim(mtxtFechaFin.Text) = "" Then
            MsgBox("Es necesario indicar una fecha de captura final.", MsgBoxStyle.Information, "Fecha Faltante")
            mtxtFechaFin.Select()
            Exit Function
        End If

        If Convert.ToDateTime(mtxtFechaIni.Text) > Convert.ToDateTime(mtxtFechaFin.Text) Then
            MsgBox("La fecha final del periodo debe ser mayor o igual a la fecha inicial.", MsgBoxStyle.Information, "Fecha Invalida")
            mtxtFechaFin.Select()
            Exit Function
        End If

        ValidaDatos = True

    End Function

    Function LlenaGridOpesDiarias() As Boolean
        Dim gs_sql As String
        Dim d As New Datasource
        Dim dt As New DataTable

        LlenaGridOpesDiarias = False

        If buscaOpesDiarias() Then


            'arma el query para presentar en el grid
            gs_sql = " Select AGENCIA.prefijo_agencia ,PRODUCTO_CONTRATADO.cuenta_cliente,TIPO_CUENTA_EJE.sufijo_kapiti, " &
                        "OPERACION.operacion , OPERACION.monto_operacion, OPERACION.fecha_captura, OPERACION.fecha_operacion, " &
                        "OPERACION_DEFINIDA.descripcion_operacion_definida, DEPOSITO_PME.referencia, DEPOSITO_PME.sucursal As sucope, " &
                        "DEPOSITO_PME.nombre_sucursal,TIPO_DOCUMENTO.descripcion_documento, CONVERT(varchar,DOCGOS.documento) as DocAICED " &
                        "FROM(((((((Ticket.dbo.PRODUCTO_CONTRATADO   PRODUCTO_CONTRATADO  INNER JOIN  TICKET.dbo.OPERACION   OPERACION  ON   " &
                        "PRODUCTO_CONTRATADO.producto_contratado = OPERACION.producto_contratado ) INNER JOIN  TICKET.dbo.CUENTA_EJE   CUENTA_EJE  On  " &
                        "PRODUCTO_CONTRATADO.producto_contratado = CUENTA_EJE.producto_contratado ) INNER JOIN  CATALOGOS.dbo.AGENCIA   AGENCIA  On   " &
                        "PRODUCTO_CONTRATADO.agencia = AGENCIA.agencia ) INNER JOIN  TICKET.dbo.TIPO_CUENTA_EJE   TIPO_CUENTA_EJE  On  " &
                        "CUENTA_EJE.tipo_cuenta_eje = TIPO_CUENTA_EJE.tipo_cuenta_eje ) INNER JOIN  TICKET.dbo.DEPOSITO_PME   DEPOSITO_PME  On   " &
                        "OPERACION.operacion = DEPOSITO_PME.operacion ) INNER JOIN  TICKET.dbo.DEPOSITO   DEPOSITO  On  " &
                        "( OPERACION.operacion = DEPOSITO.operacion ) And ( DEPOSITO_PME.operacion = DEPOSITO.operacion )) INNER JOIN  TICKET.dbo.OPERACION_DEFINIDA   OPERACION_DEFINIDA  ON  " &
                        "( OPERACION.operacion_definida = OPERACION_DEFINIDA.operacion_definida ) And ( AGENCIA.agencia = OPERACION_DEFINIDA.agencia )) LEFT OUTER JOIN  TICKET.dbo.TIPO_DOCUMENTO   TIPO_DOCUMENTO  ON   " &
                        "DEPOSITO.tipo_documento = TIPO_DOCUMENTO.tipo_documento  "
            'Colocaremos el join para el documento de AICED
            gs_sql = gs_sql + "LEFT OUTER JOIN GOS.dbo.DOCUMENTO DOCGOS ON OPERACION.operacion = DOCGOS.ticket " &
                        "WHERE OPERACION.fecha_captura >= '" + l.InvierteFecha(mtxtFechaIni.Text) & " 00:00AM'" &
                        " and OPERACION.fecha_captura <= '" + l.InvierteFecha(mtxtFechaFin.Text) & " 23:59PM' " &
                        "union  " &
                        "Select AGENCIA.prefijo_agencia,PRODUCTO_CONTRATADO.cuenta_cliente ,  TIPO_CUENTA_EJE.sufijo_kapiti , " &
                        "OPERACION.operacion , OPERACION.monto_operacion, OPERACION.fecha_captura, OPERACION.fecha_operacion, " &
                        "OPERACION_DEFINIDA.descripcion_operacion_definida, RETIRO_PME.referencia, RETIRO_PME.sucursal  As sucope, " &
                        "RETIRO_PME.nombre_sucursal,TIPO_DOCUMENTO.descripcion_documento, CONVERT(varchar,DOCGOS.documento) as DocAICED  " &
                        "FROM((((((CATALOGOS.dbo.AGENCIA   AGENCIA  INNER JOIN  TICKET.dbo.PRODUCTO_CONTRATADO   PRODUCTO_CONTRATADO  ON  " &
                        "AGENCIA.agencia = PRODUCTO_CONTRATADO.agencia ) INNER JOIN  TICKET.dbo.OPERACION   OPERACION  On  " &
                        "PRODUCTO_CONTRATADO.producto_contratado = OPERACION.producto_contratado ) INNER JOIN  TICKET.dbo.CUENTA_EJE   CUENTA_EJE  On  " &
                        "PRODUCTO_CONTRATADO.producto_contratado = CUENTA_EJE.producto_contratado ) INNER JOIN  TICKET.dbo.TIPO_CUENTA_EJE   TIPO_CUENTA_EJE  On  " &
                        "CUENTA_EJE.tipo_cuenta_eje = TIPO_CUENTA_EJE.tipo_cuenta_eje ) INNER JOIN  TICKET.dbo.RETIRO_PME   RETIRO_PME  On  " &
                        "OPERACION.operacion = RETIRO_PME.operacion ) INNER JOIN  TICKET.dbo.OPERACION_DEFINIDA   OPERACION_DEFINIDA  On  " &
                        "OPERACION.operacion_definida = OPERACION_DEFINIDA.operacion_definida ) LEFT OUTER JOIN  TICKET.dbo.TIPO_DOCUMENTO   TIPO_DOCUMENTO  On  " &
                        "RETIRO_PME.tipo_documento = TIPO_DOCUMENTO.tipo_documento "
            'Colocaremos el join para el documento de AICED
            gs_sql = gs_sql + "LEFT OUTER JOIN GOS.dbo.DOCUMENTO DOCGOS ON OPERACION.operacion = DOCGOS.ticket " &
                        "WHERE OPERACION.fecha_captura >= '" + l.InvierteFecha(mtxtFechaIni.Text) & " 00:00AM'" &
                        " and OPERACION.fecha_captura <= '" + l.InvierteFecha(mtxtFechaFin.Text) & " 23:59PM' "
            '" ORDER BY sucope"
            '------------------------------- RACB 06/06/2022
            '--TRASPASOS
            gs_sql = gs_sql & " union  " &
                "Select AG.prefijo_agencia, PC.cuenta_cliente, TCE.sufijo_kapiti, OP.operacion, OP.monto_operacion, 
                OP.fecha_captura, OP.fecha_operacion, OD.descripcion_operacion_definida , 
                TE.ficha_ced, SU.sucursal,SU.nombre_sucursal,'Retiro por Traspaso Misma Agencia', CONVERT(varchar,'')
                From CATALOGOS.dbo.AGENCIA AG, TICKET.dbo.PRODUCTO_CONTRATADO PC, TICKET.dbo.OPERACION OP, 
                TICKET.dbo.RETIRO_CED RC, TICKET.dbo.OPERACION_DEFINIDA OD, 
                TICKET.dbo.TAREAS_ENTRADAS_CED TE, CATALOGOS..SUCURSAL SU,
                TICKET.dbo.CUENTA_EJE CE, TICKET.dbo.TIPO_CUENTA_EJE TCE
                Where OP.fecha_operacion >= '" & l.InvierteFecha(mtxtFechaIni.Text) & " 00:00AM'" & " and OP.fecha_operacion <= '" & l.InvierteFecha(mtxtFechaFin.Text) & " 23:59PM' " & " 
                and OP.fecha_captura >= '" & l.InvierteFecha(mtxtFechaIni.Text) & " 00:00AM'" & " and OP.fecha_captura <= '" & l.InvierteFecha(mtxtFechaFin.Text) & " 23:59PM " & "' 
                and AG.agencia = PC.agencia and AG.agencia  in (1,3) 
                and PC.producto_contratado = OP.producto_contratado 
                and OP.operacion = RC.operacion 
                AND TE.operacion = OP.operacion 
                and OP.operacion_definida = OD.operacion_definida 
                AND OP.operacion_definida = 8087
                and PC.producto in (8009,3009) 
                and OP.status_operacion <> 250 
                and PC.producto_contratado = CE.producto_contratado 
                and CE.tipo_cuenta_eje = TCE.tipo_cuenta_eje 
                AND TE.indicador_retencion = 3 
                AND SUBSTRING (SU.sucursal,4,4) = TE.CENTRO_ORIGEN"
            '--TRASPASOS MANUALES
            gs_sql = gs_sql & " union  " &
                "Select AG.prefijo_agencia, PC.cuenta_cliente, TCE.sufijo_kapiti, OP.operacion, OP.monto_operacion, 
                OP.fecha_captura, OP.fecha_operacion, OD.descripcion_operacion_definida, 
                0 as referencia, isnull('000'+UO.unidad_org_bancomer,'0000000') as sucursal,UO.descripcion_unidad_organizacio as nombre_sucursal,
                'Retiro por Traspaso Misma Agencia(Manuales MNI)' as descripcion_documento, CONVERT(varchar,'') as descripcion_moneda
                From CATALOGOS.dbo.AGENCIA AG, TICKET.dbo.PRODUCTO_CONTRATADO PC, TICKET.dbo.OPERACION OP, 
                TICKET.dbo.OPERACION_DEFINIDA OD, FUNCIONARIOS..FUNCIONARIO FU,  FUNCIONARIOS..UNIDAD_ORGANIZACIONAL UO,
                TICKET.dbo.CUENTA_EJE CE, TICKET.dbo.TIPO_CUENTA_EJE TCE
                Where OP.fecha_operacion >= '" & l.InvierteFecha(mtxtFechaIni.Text) & " 00:00AM' and OP.fecha_operacion <= '" & l.InvierteFecha(mtxtFechaFin.Text) & " 11:59PM' 
                and OP.fecha_captura >= '" & l.InvierteFecha(mtxtFechaIni.Text) & " 00:00AM' and OP.fecha_captura <= '" & l.InvierteFecha(mtxtFechaFin.Text) & " 11:59PM' 
                and AG.agencia = PC.agencia and AG.agencia  in (1,3) 
                and PC.producto_contratado = OP.producto_contratado 
                AND OP.operacion_definida = 8087
                and OP.operacion_definida = OD.operacion_definida 
                and PC.producto in (8009,3009) 
                and OP.status_operacion <> 250 
                and PC.producto_contratado = CE.producto_contratado 
                and CE.tipo_cuenta_eje = TCE.tipo_cuenta_eje 
                AND OP.funcionario IN (7055,6830,7819,6962)
                AND OP.usuario_captura IN (618,75,632,616)
                AND OP.funcionario = FU.funcionario
                AND FU.unidad_organizacional = UO.unidad_organizacional"
            '--RETIROS POR ORDENES DE PAGO
            gs_sql = gs_sql & " union  " &
                "Select AG.prefijo_agencia, PC.cuenta_cliente, TCE.sufijo_kapiti, OP.operacion, OP.monto_operacion, 
                OP.fecha_captura, OP.fecha_operacion, OD.descripcion_operacion_definida, 
                TE.ficha_ced as referencia, SU.sucursal,SU.nombre_sucursal,'Retiro por Orden de Pago' as descripcion_documento, CONVERT(varchar,'') as descripcion_moneda
                From CATALOGOS.dbo.AGENCIA AG, TICKET.dbo.PRODUCTO_CONTRATADO PC, 
                TICKET.dbo.OPERACION OP, TICKET.dbo.RETIRO_CED RC, TICKET.dbo.OPERACION_DEFINIDA OD, 
                TICKET.dbo.TAREAS_ENTRADAS_CED TE, CATALOGOS..SUCURSAL  SU,
                TICKET.dbo.CUENTA_EJE CE, TICKET.dbo.TIPO_CUENTA_EJE TCE
                Where OP.fecha_operacion >= '" & l.InvierteFecha(mtxtFechaIni.Text) & " 00:00AM' and OP.fecha_operacion <= '" & l.InvierteFecha(mtxtFechaFin.Text) & " 11:59PM' 
                and OP.fecha_captura >= '" & l.InvierteFecha(mtxtFechaIni.Text) & " 00:00AM' and OP.fecha_captura <= '" & l.InvierteFecha(mtxtFechaFin.Text) & " 11:59PM' 
                and AG.agencia = PC.agencia and AG.agencia  in (1,3) 
                and PC.producto_contratado = OP.producto_contratado 
                and OP.operacion = RC.operacion 
                AND TE.operacion = OP.operacion 
                and OP.operacion_definida = OD.operacion_definida 
                AND OP.operacion_definida = 8081
                and PC.producto in (8009,3009) 
                and OP.status_operacion <> 250 
                and PC.producto_contratado = CE.producto_contratado 
                and CE.tipo_cuenta_eje = TCE.tipo_cuenta_eje 
                AND indicador_retencion = 3 
                AND SUBSTRING (SU.sucursal,4,4) = TE.CENTRO_ORIGEN"
            '--RETIROS POR ORDENES DE PAGO
            gs_sql = gs_sql & " union  " &
                "Select AG.prefijo_agencia, PC.cuenta_cliente, TCE.sufijo_kapiti, OP.operacion, OP.monto_operacion, 
                OP.fecha_captura, OP.fecha_operacion, OD.descripcion_operacion_definida, 
                0 as referencia, isnull('000'+UO.unidad_org_bancomer,'0000000') as sucursal,UO.descripcion_unidad_organizacio as nombre_sucursal,
                'Retiro por Orden de Pago (Manuales MNI)' as descripcion_documento, CONVERT(varchar,'') as descripcion_moneda 
                From CATALOGOS.dbo.AGENCIA AG, TICKET.dbo.PRODUCTO_CONTRATADO PC, TICKET.dbo.OPERACION OP, 
                TICKET.dbo.OPERACION_DEFINIDA OD, FUNCIONARIOS..FUNCIONARIO FU,  FUNCIONARIOS..UNIDAD_ORGANIZACIONAL UO,
                TICKET.dbo.CUENTA_EJE CE, TICKET.dbo.TIPO_CUENTA_EJE TCE
                Where OP.fecha_operacion >= '" & l.InvierteFecha(mtxtFechaIni.Text) & " 00:00AM' and OP.fecha_operacion <= '" & l.InvierteFecha(mtxtFechaFin.Text) & " 11:59PM' 
                and OP.fecha_captura >= '" & l.InvierteFecha(mtxtFechaIni.Text) & " 00:00AM' and OP.fecha_captura <= '" & l.InvierteFecha(mtxtFechaFin.Text) & " 11:59PM' 
                and AG.agencia = PC.agencia and AG.agencia  in (1,3) 
                and PC.producto_contratado = OP.producto_contratado 
                AND OP.operacion_definida = 8081
                and OP.operacion_definida = OD.operacion_definida 
                and PC.producto in (8009,3009) 
                and OP.status_operacion <> 250 
                and PC.producto_contratado = CE.producto_contratado 
                and CE.tipo_cuenta_eje = TCE.tipo_cuenta_eje 
                AND OP.funcionario IN (7055,6830,7819,6962)
                AND OP.usuario_captura IN (618,75,632,616)
                AND OP.funcionario = FU.funcionario
                AND FU.unidad_organizacional = UO.unidad_organizacional"
            '--RETIROS POR ORDENES DE PAGO (OTRAS DIVISAS)
            gs_sql = gs_sql & " union  " &
                "Select AG.prefijo_agencia, PC.cuenta_cliente, TCE.sufijo_kapiti, OP.operacion, OP.monto_operacion, 
                OP.fecha_captura, OP.fecha_operacion, OD.descripcion_operacion_definida , 
                0 as referencia, isnull('000'+UO.unidad_org_bancomer,'0000000') as sucursal, UO.descripcion_unidad_organizacio,'Retiro por Orden de Pago otras Divisas' as descripcion_documento, CONVERT(varchar,'') as descripcion_moneda
                From CATALOGOS.dbo.AGENCIA AG, TICKET.dbo.PRODUCTO_CONTRATADO PC, TICKET.dbo.OPERACION OP, 
                TICKET.dbo.OPERACION_DEFINIDA OD, FUNCIONARIOS..FUNCIONARIO FU,  FUNCIONARIOS..UNIDAD_ORGANIZACIONAL UO,
                TICKET.dbo.CUENTA_EJE CE, TICKET.dbo.TIPO_CUENTA_EJE TCE
                Where OP.fecha_operacion >= '" & l.InvierteFecha(mtxtFechaIni.Text) & " 00:00AM' and OP.fecha_operacion <= '" & l.InvierteFecha(mtxtFechaFin.Text) & " 11:59PM' 
                and OP.fecha_captura >= '" & l.InvierteFecha(mtxtFechaIni.Text) & " 00:00AM' and OP.fecha_captura <= '" & l.InvierteFecha(mtxtFechaFin.Text) & " 11:59PM' 
                and AG.agencia = PC.agencia and AG.agencia  in (1,3) 
                and PC.producto_contratado = OP.producto_contratado 
                AND OP.operacion_definida = 8086
                and OP.operacion_definida = OD.operacion_definida 
                and PC.producto in (8009,3009) 
                and OP.status_operacion <> 250 
                and PC.producto_contratado = CE.producto_contratado 
                and CE.tipo_cuenta_eje = TCE.tipo_cuenta_eje 
                AND OP.usuario_captura IN (618,75,632,616)
                AND FU.funcionario = CASE 
						                WHEN OP.usuario_captura = 75  THEN 6830
						                WHEN OP.usuario_captura = 616 THEN 6962
						                WHEN OP.usuario_captura = 618 THEN 7055
						                WHEN OP.usuario_captura = 632 THEN 7819
					                END 
                AND FU.unidad_organizacional = UO.unidad_organizacional"
            '--DEPOSITOS
            gs_sql = gs_sql & " union  " &
                "Select AG.prefijo_agencia, PC.cuenta_cliente, TCE.sufijo_kapiti, OP.operacion, OP.monto_operacion, 
                OP.fecha_captura, OP.fecha_operacion, OD.descripcion_operacion_definida, 
                DP.referencia, DP.sucursal, DP.nombre_sucursal, TD.descripcion_documento, CONVERT(varchar,TM.descripcion_moneda)
                From CATALOGOS.dbo.AGENCIA AG, TICKET.dbo.PRODUCTO_CONTRATADO PC, TICKET.dbo.OPERACION OP, 
                TICKET.dbo.DEPOSITO_PME DP, TICKET.dbo.DEPOSITO DE left outer join TICKET.dbo.TIPO_DOCUMENTO TD on DE.tipo_documento = TD.tipo_documento left outer join TICKET.dbo.TIPO_MONEDA TM on DE.tipo_moneda = TM.tipo_moneda, TICKET.dbo.OPERACION_DEFINIDA OD, 
                TICKET.dbo.CUENTA_EJE CE, TICKET.dbo.TIPO_CUENTA_EJE TCE 
                Where  OP.fecha_operacion >= '" & l.InvierteFecha(mtxtFechaIni.Text) & " 00:00AM' and  OP.fecha_operacion <= '" & l.InvierteFecha(mtxtFechaFin.Text) & " 11:59PM' 
                and  OD.operacion_definida_global in (589,583) and  OP.fecha_captura >= '" & l.InvierteFecha(mtxtFechaIni.Text) & " 00:00AM' and  OP.fecha_captura <= '" & l.InvierteFecha(mtxtFechaFin.Text) & " 11:59PM' 
                and AG.agencia = PC.agencia 
                and AG.agencia  in (1,3) 
                and PC.producto_contratado = OP.producto_contratado 
                and OP.operacion = DP.operacion 
                and OP.operacion = DE.operacion 
                and OP.operacion_definida = OD.operacion_definida 
                and PC.producto in (8009,3009) 
                and OP.status_operacion <> 250 
                and PC.producto_contratado = CE.producto_contratado 
                and CE.tipo_cuenta_eje = TCE.tipo_cuenta_eje  " &
                " union  " &
                "Select AG.prefijo_agencia, PC.cuenta_cliente, TCE.sufijo_kapiti, OP.operacion, OP.monto_operacion, 
                OP.fecha_captura, OP.fecha_operacion, OD.descripcion_operacion_definida, 
                DP.referencia, DP.sucursal, DP.nombre_sucursal, TD.descripcion_documento, CONVERT(varchar,TM.descripcion_moneda) 
                From CATALOGOS.dbo.AGENCIA AG, TICKET.dbo.PRODUCTO_CONTRATADO PC, TICKET.dbo.OPERACION OP, TICKET.dbo.DEPOSITO_PME DP, 
                TICKET.dbo.DEPOSITO DE left outer join TICKET.dbo.TIPO_DOCUMENTO TD on DE.tipo_documento = TD.tipo_documento left outer join TICKET.dbo.TIPO_MONEDA TM on DE.tipo_moneda = TM.tipo_moneda, TICKET.dbo.OPERACION_DEFINIDA OD, 
                TICKET.dbo.CUENTA_EJE CE, TICKET.dbo.TIPO_CUENTA_EJE TCE 
                Where  OP.fecha_operacion >= '" & l.InvierteFecha(mtxtFechaIni.Text) & "' and  OP.fecha_operacion <= '" & l.InvierteFecha(mtxtFechaFin.Text) & "' 
                and  OD.operacion_definida_global in (588,592,590,591) 
                and  OP.fecha_captura >= '" & l.InvierteFecha(mtxtFechaIni.Text) & " 00:00AM'
                and  OP.fecha_captura <= '" & l.InvierteFecha(mtxtFechaFin.Text) & " 11:59PM' 
                and AG.agencia = PC.agencia and AG.agencia  in (1,3) 
                and PC.producto_contratado = OP.producto_contratado 
                and OP.operacion = DP.operacion 
                and OP.operacion = DE.operacion 
                and OP.operacion_definida = OD.operacion_definida 
                and PC.producto in (8009,2009,3009) 
                and OP.status_operacion <> 250 
                and PC.producto_contratado = CE.producto_contratado 
                and CE.tipo_cuenta_eje = TCE.tipo_cuenta_eje "

            '------------------------------- RACB 06/06/2022
            'MsgBox(gs_sql)

            dt = d.RealizaConsulta(gs_sql)
            If dt IsNot Nothing Then

                dgvOpesDiarias.DataSource = dt

                dgvOpesDiarias.Columns(0).HeaderText = "Agencia"
                dgvOpesDiarias.Columns(1).HeaderText = "Cuenta"
                dgvOpesDiarias.Columns(2).HeaderText = "Sufijo"
                dgvOpesDiarias.Columns(3).HeaderText = "Ticket"
                dgvOpesDiarias.Columns(4).HeaderText = "Monto"
                dgvOpesDiarias.Columns(5).HeaderText = "Fecha Captura"
                dgvOpesDiarias.Columns(6).HeaderText = "Fecha Operación"
                dgvOpesDiarias.Columns(7).HeaderText = "Descripción"
                dgvOpesDiarias.Columns(8).HeaderText = "Ficha CED"
                dgvOpesDiarias.Columns(9).HeaderText = "C. Costos"
                dgvOpesDiarias.Columns(10).HeaderText = "Sucursal"
                dgvOpesDiarias.Columns(11).HeaderText = "Documento"
                dgvOpesDiarias.Columns(12).HeaderText = "Núm. de Docto. AICED"


                dgvOpesDiarias.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvOpesDiarias.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvOpesDiarias.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvOpesDiarias.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvOpesDiarias.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvOpesDiarias.Columns(4).DefaultCellStyle.Format = "c"
                dgvOpesDiarias.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvOpesDiarias.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvOpesDiarias.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvOpesDiarias.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvOpesDiarias.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvOpesDiarias.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvOpesDiarias.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvOpesDiarias.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                cmdExportar.Enabled = True

                lblTotal.Text = "Total de registros " & dt.Rows.Count().ToString() '----- RACB 06/06/2022
            Else
                'dgvOpesDiarias.DataSource = dt
                'lblStatus.Text = "Sin solicitudes en la lista..."
                'cmdImprimir.Enabled = True
                cmdExportar.Enabled = False

            End If


        Else
            LlenaGridOpesDiarias = False
        End If



        LlenaGridOpesDiarias = True
    End Function


    Function buscaOpesDiarias() As Boolean
        Dim gs_sql As String
        Dim d As New Datasource
        Dim dctas = New Datasource
        iRegistrosD = 0
        iRegistrosR = 0
        iRegistrosT = 0

        buscaOpesDiarias = False

        'busca depositos
        gs_sql = "Select  count(*) " &
                 "FROM(((((((Ticket.dbo.PRODUCTO_CONTRATADO   PRODUCTO_CONTRATADO  INNER JOIN  TICKET.dbo.OPERACION   OPERACION  On   " &
                 "PRODUCTO_CONTRATADO.producto_contratado = OPERACION.producto_contratado ) INNER JOIN  TICKET.dbo.CUENTA_EJE   CUENTA_EJE  On  " &
                 "PRODUCTO_CONTRATADO.producto_contratado = CUENTA_EJE.producto_contratado ) INNER JOIN  CATALOGOS.dbo.AGENCIA   AGENCIA  On   " &
                 "PRODUCTO_CONTRATADO.agencia = AGENCIA.agencia ) INNER JOIN  TICKET.dbo.TIPO_CUENTA_EJE   TIPO_CUENTA_EJE  On   " &
                 "CUENTA_EJE.tipo_cuenta_eje = TIPO_CUENTA_EJE.tipo_cuenta_eje ) INNER JOIN  TICKET.dbo.DEPOSITO_PME   DEPOSITO_PME  On  " &
                 "OPERACION.operacion = DEPOSITO_PME.operacion ) INNER JOIN  TICKET.dbo.DEPOSITO   DEPOSITO  On  " &
                 "( OPERACION.operacion = DEPOSITO.operacion ) And ( DEPOSITO_PME.operacion = DEPOSITO.operacion )) INNER JOIN  TICKET.dbo.OPERACION_DEFINIDA   OPERACION_DEFINIDA  On  " &
                 "( OPERACION.operacion_definida = OPERACION_DEFINIDA.operacion_definida ) And ( AGENCIA.agencia = OPERACION_DEFINIDA.agencia )) LEFT OUTER JOIN  TICKET.dbo.TIPO_DOCUMENTO   TIPO_DOCUMENTO  On   " &
                 "DEPOSITO.tipo_documento = TIPO_DOCUMENTO.tipo_documento " &
                 "WHERE OPERACION.fecha_captura >= '" + l.InvierteFecha(mtxtFechaIni.Text) & " 00:00AM'" &
                 " and OPERACION.fecha_captura <= '" + l.InvierteFecha(mtxtFechaFin.Text) & " 23:59PM'"


        'MsgBox(gs_sql)
        iRegistrosD = d.HayRegistros(gs_sql)

        'MsgBox("cuantos " + iRegistrosD.ToString())

        'busca retiros
        gs_sql = "Select count(*) " &
                "FROM((((((CATALOGOS.dbo.AGENCIA AGENCIA INNER JOIN TICKET.dbo.PRODUCTO_CONTRATADO PRODUCTO_CONTRATADO ON  " &
                "AGENCIA.agencia=PRODUCTO_CONTRATADO.agencia) INNER JOIN TICKET.dbo.OPERACION OPERACION ON  " &
                "PRODUCTO_CONTRATADO.producto_contratado = OPERACION.producto_contratado) INNER JOIN TICKET.dbo.cUENTA_EJE cUENTA_EJE On  " &
                "PRODUCTO_CONTRATADO.producto_contratado=CUENTA_EJE.producto_contratado) INNER JOIN TICKET.dbo.TIPO_CUENTA_EJE TIPO_CUENTA_EJE ON  " &
                "CUENTA_EJE.tipo_cuenta_eje=TIPO_CUENTA_EJE.tipo_cuenta_eje) INNER JOIN TICKET.dbo.RETIRO_PME RETIRO_PME ON  " &
                "OPERACION.operacion=RETIRO_PME.operacion) INNER JOIN TICKET.dbo.OPERACION_DEFINIDA OPERACION_DEFINIDA ON  " &
                "OPERACION.operacion_definida=OPERACION_DEFINIDA.operacion_definida) LEFT OUTER JOIN TICKET.dbo.TIPO_DOCUMENTO TIPO_DOCUMENTO ON  " &
                "RETIRO_PME.tipo_documento=TIPO_DOCUMENTO.tipo_documento " &
                "WHERE OPERACION.fecha_captura >= '" + l.InvierteFecha(mtxtFechaIni.Text) & " 00:00AM'" &
                " and OPERACION.fecha_captura <= '" + l.InvierteFecha(mtxtFechaFin.Text) & " 23:59PM'"

        iRegistrosR = d.HayRegistros(gs_sql)
        'suma depositos y retiros.
        iRegistrosT = iRegistrosD + iRegistrosR

        If (iRegistrosT) > 0 Then
            buscaOpesDiarias = True
            lblTotal.Text = "Total de registros " + iRegistrosT.ToString()
        Else
            MsgBox("No existen operaciones con los parametros indicados", MsgBoxStyle.Information, "Sin Operaciones Relevantes")
        End If


    End Function

    Private Sub monthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs)
        'Show the start And end dates in the text box.
        'txtRangoFechas.Text = "Date Changed: Start =  " +
        mtxtFechaIni.Text = e.Start.ToShortDateString()
        mtxtFechaFin.Text = e.End.ToShortDateString()
    End Sub

    Private Sub frmRepOpesDiarias_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToParent()
        'MonthCalendar1.SelectionRange = New SelectionRange(DateTime.Today, DateTime.Today)
        'dgvChequeras.ReadOnly = False
        'dgvChequeras.ScrollBars.Both
    End Sub




    'Creamos función para la exportación del Reporte a CSV
    Public Function GetMyCSVFile(ByVal Datagrid As DataGridView)
        ' botón para recorrer el datagridView y guardarlo en el archivo

        Const DELIMITADOR As String = ”,”
        Dim ThisMoment As Date

        ' Ruta del fichero de texto agregando la fecha y la hora para la distintas exportaciones que se hagan a lo largo del día
        Dim fechaHora As String = DateTime.Now.ToString("dd-MM-yyyy H-mm-ss")
        Dim fileName As String = String.Format(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + “\ReporteConciliacionAICED-{0}.csv", fechaHora)

        Dim ARCHIVO_CSV As String = fileName

        Try
            'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas
            Using archivo As StreamWriter = New StreamWriter(ARCHIVO_CSV)

                ' variable para almacenar la línea actual del dataview
                Dim linea As String = String.Empty

                With Datagrid
                    'Ingresamos los encabezados para el archivo
                    archivo.WriteLine("Agencia,Cuenta,Sufijo,Ticket,Monto,Fecha Captura,Fecha Operacion,Descripcion,FichaCED,CCostos,Sucursal,Documento,Num. de Docto. AICED")
                    ' Recorrer las filas del dataGridView
                    For fila As Integer = 0 To .RowCount - 1
                        ' vaciar la línea
                        linea = String.Empty

                        ' Recorrer la cantidad de columnas que contiene el dataGridView
                        For col As Integer = 0 To .Columns.Count - 1
                            ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
                            linea = linea & .Item(col, fila).Value.ToString & DELIMITADOR
                        Next

                        ' Escribir una línea con el método WriteLine
                        With archivo
                            ' eliminar el último caracter “;” de la cadena
                            linea = linea.Remove(linea.Length - 1).ToString
                            ' escribir la fila
                            .WriteLine(linea.ToString)
                        End With
                    Next
                End With
            End Using

            ' Abrir con Process.Start el archivo de texto
            Process.Start(ARCHIVO_CSV)
            'error
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
        Return True
    End Function

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    Private Sub cmdExportar_Click(sender As Object, e As EventArgs) Handles cmdExportar.Click
        GetMyCSVFile(dgvOpesDiarias)
    End Sub

    Private Sub mtxtFechaIni_KeyDown(sender As Object, e As KeyEventArgs) Handles mtxtFechaIni.KeyDown
        dgvOpesDiarias.DataSource = Nothing
        mtxtFechaFin.Text = ""
        cmdExportar.Enabled = False
        lblTotal.Text = ""
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class