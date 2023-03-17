Public Class frmConsCte

    'Dim gs_sql As String
    Dim mb_CambioDoc As Boolean
    Dim mb_CambioTkt As Boolean
    Dim l As New Libreria
    Dim AnchoEtiquetaNums As Integer = 70
    Dim lbSelManual As Boolean = False
    Dim lbSiHayClientes As Boolean = False

    Public Sub ObtieneNombreCliente()

        Dim IndiceSeleccionado As Integer = cmbCliente.SelectedIndex
        Dim posGuion As Integer
        Dim d As New Datasource
        Dim dt As New DataTable

        If cmbCliente.Items.Count > 0 Then

            If Val(cmbCliente.SelectedValue.ToString) > 0 Then  'La posicion de la lista tiene datos
                posGuion = cmbCliente.Text.IndexOf("-")
                lblNombre1.Text = cmbCliente.Text.Substring(posGuion)
                'lblNombre1.Text = cmbCliente.DisplayMember  'Mid(Trim(cmbCliente.List(cmbCliente.ListIndex)), 8)
                lblNombre1.Refresh()
                Cursor = System.Windows.Forms.Cursors.WaitCursor
                gs_Sql = "Select "
                gs_Sql = gs_Sql & "cuenta_cliente "
                gs_Sql = gs_Sql & "From "
                gs_Sql = gs_Sql & "TICKET.dbo.PRODUCTO_CONTRATADO "
                gs_Sql = gs_Sql & "Where "
                gs_Sql = gs_Sql & "producto_contratado = " & cmbCliente.SelectedValue.ToString

                dt = d.RealizaConsulta(gs_Sql)
                If dt.Rows.Count < 0 Then
                    MsgBox("No es posible leer la base de datos.", vbCritical, "SQL Server Error")
                Else
                    Dim row As DataRow = dt.Rows(dt.Rows.Count - 1)
                    txtCuenta.Text = CStr(row("cuenta_cliente"))
                    LlenaGridDocs()
                    LlenaGridTkts()
                    AjustaCeldas()
                End If
            Else                                            'Si existe algun error con los datos de la lista
                LimpiaCampos(0)
            End If
        End If
    End Sub

    Public Sub ObtieneAgencia()
        Dim d As New Datasource
        Dim dt As New DataTable
        'cpb 9marzo2006 SQL2000 concatenamiento de campos nulos
        gs_Sql = "Select "
        gs_Sql = gs_Sql & "rtrim(AG.prefijo_agencia) + ' ' + "
        gs_Sql = gs_Sql & "rtrim(tratamiento)+'-'+rtrim(CL.nombre_cliente)+' '+rtrim(isnull(CL.apellido_paterno, space(0)))+' '+rtrim(isnull(CL.apellido_materno, space(0))) "
        gs_Sql = gs_Sql & "+'-'+rtrim(AG.descripcion_agencia) as NombreCliente, "
        gs_Sql = gs_Sql & "PC.producto_contratado "
        gs_Sql = gs_Sql & "From "
        gs_Sql = gs_Sql & "CATALOGOS.dbo.CLIENTE CL, "
        gs_Sql = gs_Sql & "Ticket.dbo.PRODUCTO_CONTRATADO PC, "
        gs_Sql = gs_Sql & "CATALOGOS.dbo.AGENCIA AG "
        gs_Sql = gs_Sql & "Where "
        gs_Sql = gs_Sql & "PC.cuenta_cliente = CL.cuenta_cliente and "
        gs_Sql = gs_Sql & "PC.agencia = CL.agencia and "
        gs_Sql = gs_Sql & "AG.agencia = PC.agencia and "
        'gs_Sql = gs_Sql & "AG.agencia " & gs_PermisoAgencias & " and "
        gs_Sql = gs_Sql & "PC.producto in (8009,2009,3009) and "
        gs_Sql = gs_Sql & "PC.cuenta_cliente = '" & Trim(txtCuenta.Text) & "' "
        If gb_FijarAgencia Then gs_Sql = gs_Sql & " And AG.agencia = 1" 'Fijar Agencia Houston
        gs_Sql = gs_Sql & "Order by "
        gs_Sql = gs_Sql & "AG.prefijo_agencia, "
        gs_Sql = gs_Sql & "rtrim(tratamiento)+' '+rtrim(CL.nombre_cliente)+' '+rtrim(isnull(CL.apellido_paterno, space(0)))+' '+rtrim(isnull(CL.apellido_materno, space(0)))"


        dt = d.RealizaConsulta(gs_Sql)

        If dt.Rows.Count > 0 Then
            cmbCliente.DataSource = dt
            cmbCliente.DisplayMember = "NombreCliente"
            cmbCliente.ValueMember = "producto_contratado"
            cmbCliente.SelectedIndex = 0
            cmbCliente.Select()
            lbSiHayClientes = True
        ElseIf dt.Rows.Count = 0 Then
            MsgBox("No se encontró la cuenta " & Trim(txtCuenta.Text) & ".", vbInformation, "Cuenta Inexistente")
            txtCuenta.Text = ""
            txtCuenta.Select()
            LimpiaCampos(0)
        End If
    End Sub

    Public Sub LlenaGridDocs()

        Dim ln_Rows As Integer
        Dim d As New Datasource
        Dim dt As DataTable

        ln_Rows = 1
        Cursor = System.Windows.Forms.Cursors.WaitCursor 'ShowWaitCursor
        gs_Sql = "Select distinct "
        gs_Sql = gs_Sql & "DC.documento  as 'N° Documento', "
        gs_Sql = gs_Sql & "DC.ticket as 'Ticket', "
        gs_Sql = gs_Sql & "monto as 'Monto',"
        gs_Sql = gs_Sql & "convert(char(10),fecha_operacion,105) as 'Fecha Op.', "
        gs_Sql = gs_Sql & "referencia as 'Ficha CED', "
        gs_Sql = gs_Sql & "descripcion_status_concilia as 'Status Conciliación', "
        gs_Sql = gs_Sql & "descripcion_documento as 'Tipo de Documento', "
        gs_Sql = gs_Sql & "operacion_concilia as 'Tkt. Conc.', "
        gs_Sql = gs_Sql & "Case when DI.documento Is NULL then 'Sin Diferencias' Else 'Buscar...' End As Documento "
        gs_Sql = gs_Sql & "From "
        gs_Sql = gs_Sql & "TICKET.dbo.PRODUCTO_CONTRATADO PC, "
        gs_Sql = gs_Sql & "GOS.dbo.TIPO_DOCUMENTO TD, "
        gs_Sql = gs_Sql & "GOS.dbo.STATUS_CONCILIA SC, "
        gs_Sql = gs_Sql & "GOS.dbo.DIFERENCIAS DI, "
        gs_Sql = gs_Sql & "GOS.dbo.DOCUMENTO DC "
        gs_Sql = gs_Sql & "Where "
        gs_Sql = gs_Sql & "TD.tipo_documento = DC.tipo_documento and "
        gs_Sql = gs_Sql & "SC.status_concilia = DC.status_concilia and "
        gs_Sql = gs_Sql & "DC.cuenta_cliente = PC.cuenta_cliente and "
        gs_Sql = gs_Sql & "DC.agencia = PC.agencia and "
        If chkDocFecha.Checked = True Then
            gs_Sql = gs_Sql & "fecha_operacion >= '" & l.InvierteFecha(txtDocFecha0.Text) & " 00:00AM' and " 'FechaQuery(txtDocFecha0.Text)
            gs_Sql = gs_Sql & "fecha_operacion <= '" & l.InvierteFecha(txtDocFecha1.Text) & " 11:59PM' and "
        End If
        If chkDocTicket.Checked = True Then
            gs_Sql = gs_Sql & "DC.ticket >= " & Trim(txtDocTkt0.Text) & " and "
            gs_Sql = gs_Sql & "DC.ticket <= " & Trim(txtDocTkt1.Text) & " and "
        End If
        If chkDocStatus.Checked = True Then
            gs_Sql = gs_Sql & "DC.status_concilia = " & cmbDocStatus.SelectedValue.ToString & " and "
            'ItemData(cmbDocStatus.ListIndex) & " and "
        End If
        gs_Sql = gs_Sql & "DC.documento *= DI.documento and "
        gs_Sql = gs_Sql & "PC.producto_contratado = " & cmbCliente.SelectedValue.ToString
        gs_Sql = gs_Sql & " order by DC.documento desc"

        dt = New DataTable
        dt = d.RealizaConsulta(gs_Sql)

        Me.grdDoc.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)

        If Not IsNothing(dt) Then
            If dt.Rows.Count > 0 Then
                grdDoc.DataSource = dt
                lblNumDocs.Text = dt.Rows.Count.ToString() '.PadRight(20 - lblNumDocs.Text.Length, " ")
                lblNumDocs.Width = AnchoEtiquetaNums
                grdDoc.Columns("Monto").DefaultCellStyle.Format = "C2"
                grdDoc.Columns("Monto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grdDoc.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'grdDoc.Columns(0).HeaderText = "N° Documento"
                'grdDoc.Columns(1).HeaderText = "Ticket"
                'grdDoc.Columns(2).HeaderText = "Monto"
                'grdDoc.Columns(3).HeaderText = "Fecha Op."
                'grdDoc.Columns(4).HeaderText = "Ficha CED"
                'grdDoc.Columns(5).HeaderText = "Status Conciliación"
                'grdDoc.Columns(6).HeaderText = "Tipo de Documento"
                'grdDoc.Columns(7).HeaderText = "Tkt. Conc."
                'grdDoc.Columns(8).HeaderText = "Diferencias"
                'lblNumDocs.Text.PadRight(20, " ")
            Else
                'grdDoc.Rows.Clear()
                grdDoc.DataSource = Nothing
                lblNumDocs.Text = "0"
                MsgBox("No hay Documentos que mostrar", MsgBoxStyle.Information, "Consulta")
            End If
        Else
            grdDoc.DataSource = Nothing

        End If

        mb_CambioDoc = False                              'Apaga la bandera de cambios por actualizar
        Cursor = System.Windows.Forms.Cursors.Default 'ShowDefaultCursor
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub LlenaGridTkts() 'productoContratado As String)

        Dim ln_Rows As Integer
        Dim dst As New Datasource
        Dim dtt As DataTable

        ln_Rows = 1
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        'ShowWaitCursor
        gs_Sql = "Select "
        gs_Sql = gs_Sql & "OP.operacion, "
        gs_Sql = gs_Sql & "OP.monto_operacion, "
        gs_Sql = gs_Sql & "convert(char(10),OP.fecha_captura,105), "
        gs_Sql = gs_Sql & "convert(char(10),OP.fecha_operacion,105), "
        gs_Sql = gs_Sql & "case RP.referencia when null then "
        gs_Sql = gs_Sql & "case DP.referencia when null then 0 else DP.referencia end "
        gs_Sql = gs_Sql & "else RP.referencia end, "
        gs_Sql = gs_Sql & "SC.descripcion_status_concilia, "
        gs_Sql = gs_Sql & "OD.descripcion_operacion_definida "
        gs_Sql = gs_Sql & "From "
        gs_Sql = gs_Sql & "TICKET.dbo.OPERACION_DEFINIDA OD, "
        gs_Sql = gs_Sql & "GOS.dbo.OPERACION_TICKET OT, "
        gs_Sql = gs_Sql & "GOS.dbo.STATUS_CONCILIA SC, "
        gs_Sql = gs_Sql & "GOS.dbo.T_OPERACION OP, "
        gs_Sql = gs_Sql & "GOS.dbo.T_DEPOSITO_PME DP, "
        gs_Sql = gs_Sql & "GOS.dbo.T_RETIRO_PME RP, "
        gs_Sql = gs_Sql & "GOS.dbo.T_TRASPASO TT, "
        gs_Sql = gs_Sql & "GOS.dbo.T_RETIRO_ORDEN_PAGO RO, "
        gs_Sql = gs_Sql & "GOS.dbo.T_RETIRO_ORDEN_DIVISAS RD "
        gs_Sql = gs_Sql & "Where "
        gs_Sql = gs_Sql & "SC.status_concilia = OT.status_concilia and "
        gs_Sql = gs_Sql & "OT.operacion = OP.operacion and "
        gs_Sql = gs_Sql & "OD.operacion_definida = OP.operacion_definida and "
        If chkTktFecha.Checked = True Then
            gs_Sql = gs_Sql & "OP.fecha_operacion >= '" & l.InvierteFecha(txtTktFecha0.Text) & " 00:00AM' and "

            gs_Sql = gs_Sql & "OP.fecha_operacion <= '" & l.InvierteFecha(txtTktFecha1.Text) & " 11:59PM' and "
        End If
        If chkTktTicket.Checked = True Then
            gs_Sql = gs_Sql & "OP.operacion >= " & txtTktTkt0.Text & " and "
            gs_Sql = gs_Sql & "OP.operacion <= " & txtTktTkt1.Text & " and "
        End If
        If chkTktStatus.Checked = True Then
            gs_Sql = gs_Sql & "OT.status_concilia = " & cmbTktStatus.SelectedValue.ToString & " and "
        End If
        gs_Sql = gs_Sql & "OP.operacion *= RP.operacion and "
        gs_Sql = gs_Sql & "OP.operacion *= DP.operacion and "
        gs_Sql = gs_Sql & "OP.operacion *= TT.operacion and "
        gs_Sql = gs_Sql & "OP.operacion *= RO.operacion and "
        gs_Sql = gs_Sql & "OP.operacion *= RD.operacion and "
        gs_Sql = gs_Sql & "OP.producto_contratado = " & cmbCliente.SelectedValue.ToString
        gs_Sql = gs_Sql & " order by OP.operacion desc"
        'MsgBox("gs_sql tickets " & gs_Sql, MessageBoxButtons.OK)
        Me.grdTkt.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)

        dtt = New DataTable
        dtt = dst.RealizaConsulta(gs_Sql)

        If Not IsNothing(dtt) Then
            If dtt.Rows.Count > 0 Then
                grdTkt.DataSource = dtt
                lblNumTkts.Text = dtt.Rows.Count.ToString() '.PadRight(20 - lblNumTkts.Text.Length, " ")
                lblNumTkts.Width = AnchoEtiquetaNums
                'MsgBox("Tickets " + dtt.Rows.Count.ToString().PadRight(15), MsgBoxStyle.Information, "Consulta")
                grdTkt.Columns(0).HeaderText = "Ticket"
                grdTkt.Columns(1).HeaderText = "Monto"
                grdTkt.Columns(2).HeaderText = "Fecha de Captura"
                grdTkt.Columns(3).HeaderText = "Fecha de Operación"
                grdTkt.Columns(4).HeaderText = "Ficha CED"
                grdTkt.Columns(5).HeaderText = "Status Conciliación"
                grdTkt.Columns(6).HeaderText = "Tipo de Documento"
                For i = 0 To 6 Step 1
                    If i = 1 Then
                        grdTkt.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        grdTkt.Columns(i).DefaultCellStyle.Format = "c"
                    Else
                        grdTkt.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End If

                Next
            Else
                grdTkt.DataSource = Nothing
                lblNumTkts.Text = "0"
                MsgBox("No hay Tickets que mostrar", MsgBoxStyle.Information, "Consulta")
            End If
        Else
            grdTkt.DataSource = Nothing

        End If

        'AjustaCeldas
        'grdTkt.Refresh()
        mb_CambioTkt = False                          'Apaga la bandera de cambios por actualizar
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub


    'Private Sub txtCuenta_LostFocus(sender As Object, e As EventArgs)

    '    Dim d As New Datasource
    '    Dim dt As New DataTable

    '    gs_Sql = "Select "
    '    'gs_sql = gs_sql & "AG.prefijo_agencia, "
    '    'gs_sql = gs_sql & "rtrim(tratamiento)+' '+rtrim(CL.nombre_cliente)+' '+rtrim(isnull(CL.apellido_paterno, space(0)))+' '+rtrim(isnull(CL.apellido_materno, space(0))) nombre, "
    '    'gs_sql = gs_sql & "AG.descripcion_agencia, "
    '    gs_Sql = gs_Sql & "AG.prefijo_agencia + '-' +"
    '    gs_Sql = gs_Sql & "rtrim(tratamiento)+' '+rtrim(CL.nombre_cliente)+' '+rtrim(isnull(CL.apellido_paterno, space(0)))+' '+rtrim(isnull(CL.apellido_materno, space(0))) + ' ' +"
    '    gs_Sql = gs_Sql & "AG.descripcion_agencia descripcion, "
    '    gs_Sql = gs_Sql & "PC.producto_contratado "
    '    gs_Sql = gs_Sql & "From "
    '    gs_Sql = gs_Sql & "CATALOGOS.dbo.CLIENTE CL, "
    '    gs_Sql = gs_Sql & "TICKET.dbo.PRODUCTO_CONTRATADO PC, "
    '    gs_Sql = gs_Sql & "CATALOGOS.dbo.AGENCIA AG "
    '    gs_Sql = gs_Sql & "Where "
    '    gs_Sql = gs_Sql & "PC.cuenta_cliente = CL.cuenta_cliente and "
    '    gs_Sql = gs_Sql & "PC.agencia = CL.agencia and "
    '    gs_Sql = gs_Sql & "AG.agencia = PC.agencia and "
    '    'gs_Sql = gs_Sql & "AG.agencia " & gs_PermisoAgencias & " and "
    '    gs_Sql = gs_Sql & "PC.producto in (8009,2009,3009) and "
    '    gs_Sql = gs_Sql & "PC.cuenta_cliente = '" & Trim(txtCuenta.Text) & "' "
    '    gs_Sql = gs_Sql & "Order by "
    '    gs_Sql = gs_Sql & "AG.prefijo_agencia, "
    '    gs_Sql = gs_Sql & "rtrim(tratamiento)+' '+rtrim(CL.nombre_cliente)+' '+rtrim(isnull(CL.apellido_paterno, space(0)))+' '+rtrim(isnull(CL.apellido_materno, space(0)))"

    '    dt = d.RealizaConsulta(gs_Sql)

    '    If dt.Rows.Count > 0 Then

    '        cmbCliente.DataSource = dt
    '        cmbCliente.DisplayMember = Trim("descripcion")
    '        'Trim("prefijo_agencia") + 
    '        '+ "nombre" + "descripcion_agencia"
    '        cmbCliente.ValueMember = "producto_contratado"

    '    Else
    '        MsgBox("No se encontro la cuenta " & Trim(txtCuenta.Text) & ".", MessageBoxButtons.OK)
    '    End If


    '    'dbExecQuery gs_sql                            'Busca las cuentas existentes
    '    'dbGetRecord
    '    'Do While dbError = 0
    '    '    cmbCliente.AddItem dbGetValue(0) & " - " & LowCaseName(dbGetValue(1)) & "  (" & Trim(dbGetValue(2)) & ")"
    '    'cmbCliente.ItemData(cmbCliente.NewIndex) = Val(dbGetValue(3))
    '    '    dbGetRecord
    '    'Loop
    '    'dbEndQuery
    '    'ShowDefaultCursor
    '    'If cmbCliente.ListCount = 0 Then              'No se encontro alguna cuenta
    '    '    MsgBox "No se encontro la cuenta " & Trim(txtCuenta.Text) & ".", vbInformation, "Cuenta Inexistente"
    '    'txtCuenta.Text = ""
    '    '    txtCuenta.SetFocus
    '    'ElseIf cmbCliente.ListCount = 1 Then          'Se encontro solo una cuenta, selecciona la cuenta para desplegar sus datos
    '    '    cmbCliente.ListIndex = 0
    '    'Else                                          'Se encontro mas de una cuenta, abre el combo para seleccion
    '    '    gs_sql = SendMessage(cmbCliente.hWnd, 335, 1, 0)
    '    'End If
    '    'End If

    '    'End If

    'End Sub

    Private Sub txtCuenta_LostFocus(sender As Object, e As EventArgs) Handles txtCuenta.LostFocus
        'Dim d As New Datasource
        'Dim dt As New DataTable
        'If Trim(txtCuenta.Text) <> "" Then                     'Existen datos de la cuenta
        '    If cmbCliente.Items.Count <= 1 Then                'No se ha buscado dicha cuenta
        '        Cursor = System.Windows.Forms.Cursors.WaitCursor 'ShowWaitCursor
        '        'cpb 9marzo2006 SQL2000 concatenamiento de campos nulos
        '        gs_Sql = "Select "
        '        gs_Sql = gs_Sql & "rtrim(AG.prefijo_agencia) + ' ' + "
        '        gs_Sql = gs_Sql & "rtrim(tratamiento)+'-'+rtrim(CL.nombre_cliente)+' '+rtrim(isnull(CL.apellido_paterno, space(0)))+' '+rtrim(isnull(CL.apellido_materno, space(0))) "
        '        gs_Sql = gs_Sql & "+'-'+rtrim(AG.descripcion_agencia) as NombreCliente, "
        '        gs_Sql = gs_Sql & "PC.producto_contratado "
        '        gs_Sql = gs_Sql & "From "
        '        gs_Sql = gs_Sql & "CATALOGOS.dbo.CLIENTE CL, "
        '        gs_Sql = gs_Sql & "Ticket.dbo.PRODUCTO_CONTRATADO PC, "
        '        gs_Sql = gs_Sql & "CATALOGOS.dbo.AGENCIA AG "
        '        gs_Sql = gs_Sql & "Where "
        '        gs_Sql = gs_Sql & "PC.cuenta_cliente = CL.cuenta_cliente and "
        '        gs_Sql = gs_Sql & "PC.agencia = CL.agencia and "
        '        gs_Sql = gs_Sql & "AG.agencia = PC.agencia and "
        '        'gs_Sql = gs_Sql & "AG.agencia " & gs_PermisoAgencias & " and "
        '        gs_Sql = gs_Sql & "PC.producto in (8009,2009,3009) and "
        '        gs_Sql = gs_Sql & "PC.cuenta_cliente = '" & Trim(txtCuenta.Text) & "' "
        '        gs_Sql = gs_Sql & "Order by "
        '        gs_Sql = gs_Sql & "AG.prefijo_agencia, "
        '        gs_Sql = gs_Sql & "rtrim(tratamiento)+' '+rtrim(CL.nombre_cliente)+' '+rtrim(isnull(CL.apellido_paterno, space(0)))+' '+rtrim(isnull(CL.apellido_materno, space(0)))"

        '        dt = d.RealizaConsulta(gs_Sql)

        '        If dt.Rows.Count > 0 Then
        '            cmbCliente.DataSource = dt
        '            cmbCliente.DisplayMember = "NombreCliente"
        '            cmbCliente.ValueMember = "producto_contratado"
        '        ElseIf dt.Rows.Count = 0 Then
        '            MsgBox("No se encontro la cuenta " & Trim(txtCuenta.Text) & ".", vbInformation, "Cuenta Inexistente")
        '            txtCuenta.Text = ""
        '            txtCuenta.Select()
        '            LimpiaCampos(0)
        '        End If
        '        cmbCliente.SelectedIndex = -1
        '        Cursor = System.Windows.Forms.Cursors.Default 'ShowDefaultCursor
        '    End If
        'End If


    End Sub

    Private Sub grdDoc_DoubleClick(sender As Object, e As EventArgs) Handles grdDoc.DoubleClick

        Dim gs_sql As String
        Dim d As New Datasource
        Dim dt As New DataTable
        Dim ls_Doc As String


        If grdDoc.CurrentRow.Index > -1 Then                            'Es un renglon de datos
            If grdDoc.CurrentCell.ColumnIndex = 8 Then                 'Es la columna de diferencias
                If grdDoc.CurrentRow.Cells(8).Value.ToString() <> "Sin Diferencias" Then      'El texto en la celda indica que existan diferencias.
                    'If grdDoc.Text <> "Sin Diferencias" Then      'El texto en la celda indica que existan diferencias.
                    grdDoc.CurrentRow.Cells(8).Value = "Buscando..." 'grdDoc.Text = "Buscando..."
                    grdDoc.CurrentRow.Cells(0).Selected = True                              'Activa la columna de documento en el 
                    gs_sql = "Select operacion "
                    gs_sql = gs_sql & "From "
                    gs_sql = gs_sql & "GOS.dbo.DIFERENCIAS "
                    gs_sql = gs_sql & "Where "
                    gs_sql = gs_sql & "documento = " & grdDoc.CurrentRow.Cells(0).Value.ToString
                    'grdDoc.Text
                    dt = d.RealizaConsulta(gs_sql)
                    If dt.Rows.Count > 0 Then
                        'cmbDiferencia.DataSource = dt
                        'cmbDiferencia.DisplayMember = "operacion"
                        'cmbDiferencia.ValueMember = "operacion"
                        AjustaCeldas()                                'Reestablece el tamaño de las celdas del grid
                        grdDoc.CurrentRow.Cells(8).Value = "Buscar..."

                    ElseIf dt.Rows.Count = 0 Then  'Si no hay datos en el combo entonces no hay diferencias
                        grdDoc.CurrentRow.Cells(8).Value = "Sin Diferencias"
                        'MsgBox("No hay diferencias", MessageBoxButtons.OK)
                        Exit Sub
                    End If
                    'cmbDiferencia.Visible = True
                Else
                End If
            Else
CeldaComun:
                'grdDoc.Col = 0                                'Activa la columna de documento en el grid
                ls_Doc = grdDoc.CurrentRow.Cells(0).Value.ToString()
                'MsgBox("Documento " + ls_Doc, MessageBoxButtons.OK)
                'frmConsulta.Consulta(0, ls_Doc, False)
                If Trim(ls_Doc) <> "" Then               'Si la celda activa contiene un numero de documento
                    Cursor = System.Windows.Forms.Cursors.WaitCursor
                    Dim frmConsultadesdeCliente As New frmConsulta
                    'frmConsultadesdeCliente.ShowDialog()
                    frmConsultadesdeCliente.Consulta(0, ls_Doc, False)
                    Cursor = System.Windows.Forms.Cursors.Default

                    '    Me.WindowState = 1
                    '    frmConsulta.Consulta 0, grdDoc.Text, Me     'Llama a la funcion de consulta de documentos
                End If
            End If
        End If
    End Sub

    Private Sub frmConsCte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ShowWaitCursor
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        On Error Resume Next

        'If Not MDIGOS.ActiveForm Is Nothing Then
        '    If MDIGOS.ActiveForm.Name = "frmCaptura" Then 'Si se encuentra activa la pantalla de captura
        '        Unload frmCaptura                           'Cierra la pantalla de captura
        '    End If
        'End If
        'grdDoc.Row = 0
        cmbCliente.DataSource = Nothing
        grdDoc.DataSource = Nothing
        grdTkt.DataSource = Nothing
        'grdDoc.Columns(0).HeaderText = "N° Documento"
        'grdDoc.Columns(1).HeaderText = "Ticket"
        'grdDoc.Columns(2).HeaderText = "Monto"
        'grdDoc.Columns(3).HeaderText = "Fecha Op."
        'grdDoc.Columns(4).HeaderText = "Ficha CED"
        'grdDoc.Columns(5).HeaderText = "Status Conciliación"
        'grdDoc.Columns(6).HeaderText = "Tipo de Documento"
        'grdDoc.Columns(7).HeaderText = "Tkt. Conc."
        'grdDoc.Columns(8).HeaderText = "Diferencias"
        'For i = 0 To 8 Step 1
        '    grdDoc.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Next
        'grdTkt.Columns(0).HeaderText = "Ticket"
        'grdTkt.Columns(1).HeaderText = "Monto"
        'grdTkt.Columns(2).HeaderText = "Fecha de Captura"
        'grdTkt.Columns(3).HeaderText = "Fecha de Operación"
        'grdTkt.Columns(4).HeaderText = "Ficha CED"
        'grdTkt.Columns(5).HeaderText = "Status Conciliación"
        'grdTkt.Columns(6).HeaderText = "Tipo de Documento"
        'For i = 0 To 6 Step 1
        '    grdTkt.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Next
        'Me.grdTkt.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
        'grdTkt.FixedRows = 1
        'LimpiaCampos 0
        gs_Sql = ""
        gs_Sql = " Select "
        gs_Sql = gs_Sql & " descripcion_status_concilia, "
        gs_Sql = gs_Sql & " status_concilia "
        gs_Sql = gs_Sql & " From "
        gs_Sql = gs_Sql & " GOS.dbo.STATUS_CONCILIA "
        gs_Sql = gs_Sql & " where status_concilia not in (6,7,250)"           'No temporales
        gs_Sql = gs_Sql & " Order by descripcion_status_concilia"

        Dim d As New Datasource
        Dim dtd, dtt As New DataTable

        dtd = d.RealizaConsulta(gs_Sql)
        dtt = d.RealizaConsulta(gs_Sql)
        If dtd.Rows.Count > 0 Then
            cmbDocStatus.DataSource = dtd
            cmbDocStatus.DisplayMember = "descripcion_status_concilia"
            cmbDocStatus.ValueMember = "status_concilia"
            cmbTktStatus.DataSource = dtt
            cmbTktStatus.DisplayMember = "descripcion_status_concilia"
            cmbTktStatus.ValueMember = "status_concilia"
        Else
            MsgBox("No hay diferencias.", MessageBoxButtons.OK)
            'GoTo CeldaComun
        End If

        Me.Refresh()
        'ShowDefaultCursor
        Cursor = System.Windows.Forms.Cursors.Default
        'Me.ToolTip1.SetToolTip(cmbCliente, "Este es el mensaje")

        'lmc 27-jun-2002 Cambio de imagen de la forma
        'CargarColores Me, True
        'cambiarLabels lblNombre1
        'cambiarLabels lblNumDocs
        'cambiarLabels lblNumTkts
    End Sub

    '-----------------------------------------------------------------------------------------------------
    'Limpia los campos.Tipo 0: Limpia Todo, 1: Limpia ambos grids, 2:Limpia Grid Doctos, 3:Limpia Grid Tkt
    '-----------------------------------------------------------------------------------------------------
    Private Sub LimpiaCampos(Tipo As Byte)
        Dim ln_Cols As Byte

        If Tipo = 0 Then
            lbSelManual = False
            'txtCuenta.Text = "      " '.PadRight(6, " ") ' = ""
            cmbCliente.DataSource = Nothing 'Items.Clear() 'Clear
            lblNombre1.Text = "                                                                                                    " '.PadRight(70) ' = ""
            chkDocFecha.Checked = False 'Value = 0
            chkDocTicket.Checked = False
            chkDocStatus.Checked = False
            chkTktFecha.Checked = False
            chkTktTicket.Checked = False
            chkTktStatus.Checked = False
            lblNumDocs.Text = "                    "
            lblNumTkts.Text = "                    "
            lbSiHayClientes = False
        End If
        If Tipo = 3 Then GoTo LimpiaTkt
        lblNumDocs.Text = "                    "
        'grdDoc.Rows = 2
        'grdDoc.Row = 1
        'For ln_Cols = 0 To 8
        'grdDoc.Col = ln_Cols
        grdDoc.DataSource = Nothing 'Text = ""
        'Next ln_Cols
        'grdDoc.Refresh()
        If Tipo = 2 Then GoTo Fin
LimpiaTkt:
        lblNumTkts.Text = "                    "
        'grdTkt.Rows = 2
        'grdTkt.Row = 1
        'For ln_Cols = 0 To 6
        'grdTkt.Col = ln_Cols
        grdTkt.DataSource = Nothing '.Text = ""
        'Next ln_Cols
        'grdTkt.Refresh()
Fin:
        'AjustaCeldas
        'cmbDiferencia.Items.Clear()
        'cmbDiferencia.Visible = False
    End Sub

    Private Sub cmbDiferencia_Click(sender As Object, e As EventArgs) Handles cmbDiferencia.Click

        'grdDoc.Col = 8
        If cmbDiferencia.SelectedIndex > -1 Then
            grdDoc.Text = cmbDiferencia.Text                'Despliega en la celda el valor del combo
            grdDoc.Select()
        Else
            grdDoc.Text = "Buscar..."
        End If

    End Sub

    Private Sub cmbDiferencia_LostFocus(sender As Object, e As EventArgs) Handles cmbDiferencia.LostFocus
        Dim ln_Rows As Integer

        'For ln_Rows = 0 To grdDoc.Rows - 1                'Reestablece el tamaño de las celdas del grid
        'If grdDoc.RowHeight(ln_Rows) <> 225 Then
        '    grdDoc.RowHeight(ln_Rows) = 225
        '    cmbDiferencia.Visible = False                 'Oculta el combo de diferencias
        'End If
        'Next ln_Rows
        cmbDiferencia.DataSource = Nothing
        cmbDiferencia.Items.Clear()
        cmbDiferencia.Visible = False
        grdDoc.Refresh()
    End Sub

    Private Sub cmdActualiza_Click(sender As Object, e As EventArgs) Handles cmdActualiza.Click

        If mb_CambioDoc = True Then
            If chkDocFecha.Checked = True Then
                If Trim(txtDocFecha0.Text) = "" Then            'Fecha Inicial
                    MsgBox("Es necesario que indique la fecha de operación inicial.", vbInformation, "Dato Necesario")
                    txtDocFecha0.Select()
                    Exit Sub
                End If
                If Trim(txtDocFecha1.Text) = "" Then            'Fecha Final
                    MsgBox("Es necesario que indique la fecha de operación final.", vbInformation, "Dato Necesario")
                    txtDocFecha1.Select()
                    Exit Sub
                End If
                If CDate(txtDocFecha0.Text) > CDate(txtDocFecha1.Text) Then
                    MsgBox("La fecha de operación inicial debe ser menor o igual que la fecha final.", vbInformation, "Dato Necesario")
                    txtDocFecha0.Select()
                    Exit Sub
                End If
            End If
            If chkDocTicket.Checked = True Then                      'Ticket Inicial
                If Trim(txtDocTkt0.Text) = "" Then
                    MsgBox("Es necesario que indique el ticket inicial.", vbInformation, "Dato Necesario")
                    txtDocTkt0.Select()
                    Exit Sub
                End If
                If Trim(txtDocTkt1.Text) = "" Then              'Ticket Final
                    MsgBox("Es necesario que indique el ticket final.", vbInformation, "Dato Necesario")
                    txtDocTkt1.Select()
                    Exit Sub
                End If
                If Val(txtDocTkt0.Text) > Val(txtDocTkt1.Text) Then
                    MsgBox("El ticket inicial debe ser menor o igual al ticket final.", vbInformation, "Dato Necesario")
                    txtDocTkt0.Select()
                    Exit Sub
                End If
            End If
            If chkDocStatus.Checked = True Then
                If cmbDocStatus.SelectedIndex = -1 Then               'Status de Conciliación
                    MsgBox("Es necesario indicar un status de conciliación.", vbInformation, "Dato Necesario")
                    cmbDocStatus.Select()
                    Exit Sub
                End If
            End If
            LimpiaCampos(2)
            LlenaGridDocs()
        End If
        If mb_CambioTkt = True Then
            If chkTktFecha.Checked = True Then
                If Trim(txtTktFecha0.Text) = "" Then            'Fecha Inicial
                    MsgBox("Es necesario que indique la fecha de operación inicial.", vbInformation, "Dato Necesario")
                    txtTktFecha0.Select()
                    Exit Sub
                End If
                If Trim(txtTktFecha1.Text) = "" Then            'Fecha Final
                    MsgBox("Es necesario que indique la fecha de operación final.", vbInformation, "Dato Necesario")
                    txtTktFecha1.Select()
                    Exit Sub
                End If
                If CDate(txtTktFecha0.Text) > CDate(txtTktFecha1.Text) Then
                    MsgBox("La fecha de operación inicial debe ser menor o igual que la fecha final.", vbInformation, "Dato Necesario")
                    txtTktFecha0.Select()
                    Exit Sub
                End If
            End If
            If chkTktTicket.Checked = True Then
                If Trim(txtTktTkt0.Text) = "" Then              'Ticket Inicial
                    MsgBox("Es necesario que indique el ticket inicial.", vbInformation, "Dato Necesario")
                    txtTktTkt0.Select()
                    Exit Sub
                End If
                If Trim(txtTktTkt1.Text) = "" Then              'Ticket Final
                    MsgBox("Es necesario que indique el ticket final.", vbInformation, "Dato Necesario")
                    txtTktTkt1.Select()
                    Exit Sub
                End If
                If Val(txtTktTkt0.Text) > Val(txtTktTkt1.Text) Then
                    MsgBox("El ticket inicial debe ser menor o igual al ticket final.", vbInformation, "Dato Necesario")
                    txtTktTkt0.Select()
                    Exit Sub
                End If
            End If
            If chkTktStatus.Checked = True Then
                If cmbTktStatus.SelectedIndex = -1 Then               'Status de Conciliación
                    MsgBox("Es necesario indicar un status de conciliación.", vbInformation, "Dato Necesario")
                    cmbTktStatus.Select()
                    Exit Sub
                End If
            End If
            LimpiaCampos(3)
            LlenaGridTkts()
        End If
        cmdActualiza.Enabled = False
    End Sub
    Private Sub cmdactualiza_GotFocus()

        '    pg_ColorBoton cmdActualiza, 1, True, 0
        'If cmdActualiza.Enabled = False Then
        '        pg_ColorBoton cmdActualiza, 0, False, 0
        'End If
        '    selec = True
    End Sub

    Private Sub cmdactualiza_LostFocus()

        '    pg_ColorBoton cmdActualiza, 0, True, 0
        'selec = False
        '    cmdActualiza.ButtonStyle = ssBorderless
    End Sub

    Private Sub cmdactualiza_MouseEnter(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Single, ByVal Y As Single)
        cmdactualiza_GotFocus()
    End Sub

    Private Sub cmdactualiza_MouseExit(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Single, ByVal Y As Single)
        cmdactualiza_LostFocus()
    End Sub




    Private Sub chkDocFecha_Click(sender As Object, e As EventArgs) Handles chkDocFecha.Click
        cambio(0)
        If chkDocFecha.Checked = True Then
            txtDocFecha0.Visible = True
            txtDocFecha1.Visible = True
            txtDocFecha0.Select()
        Else
            txtDocFecha0.Text = ""
            txtDocFecha1.Text = ""
            txtDocFecha0.Visible = False
            txtDocFecha1.Visible = False
        End If
    End Sub

    Private Sub chkDocStatus_Click(sender As Object, e As EventArgs) Handles chkDocStatus.Click

        cambio(0)
        If chkDocStatus.Checked = True Then
            cmbDocStatus.Visible = True
        Else
            cmbDocStatus.SelectedIndex = -1
            cmbDocStatus.Visible = False
        End If
    End Sub




    'Private Sub chkDocFecha_Click()

    '    cambio(0)
    '    If chkDocFecha.ThreeState = True Then
    '        txtDocFecha0.Visible = True
    '        txtDocFecha1.Visible = True
    '        'txtDocFecha0.SetFocus
    '    Else
    '        txtDocFecha0.Text = ""
    '        txtDocFecha1.Text = ""
    '        txtDocFecha0.Visible = False
    '        txtDocFecha1.Visible = False
    '    End If
    'End Sub



    Private Sub chkTktStatus_Click(sender As Object, e As EventArgs) Handles chkTktStatus.Click

        cambio(1)
        If chkTktStatus.Checked = True Then
            cmbTktStatus.Visible = True
        Else
            cmbTktStatus.SelectedIndex = -1
            cmbTktStatus.Visible = False
        End If
    End Sub

    Private Sub chkTktTicket_Click(sender As Object, e As EventArgs) Handles chkTktTicket.Click

        cambio(1)
        If chkTktTicket.Checked = True Then
            txtTktTkt0.Visible = True
            txtTktTkt1.Visible = True
            txtTktTkt0.Select()
        Else
            txtTktTkt0.Text = ""
            txtTktTkt1.Text = ""
            txtTktTkt0.Visible = False
            txtTktTkt1.Visible = False
        End If
    End Sub

    Private Sub cambio(Origen As Byte)

        If Trim(txtCuenta.Text) <> "" Then   'Existe cliente
            If Origen = 0 Then            'Cambiaron condiciones de busqueda de Doctos
                mb_CambioDoc = True
                cmdActualiza.Enabled = True
            Else                          'Cambiaron condiciones de busqueda de Ticket
                mb_CambioTkt = True
                cmdActualiza.Enabled = True
            End If
        End If
    End Sub

    '-------------------------------------------------------------
    'Establece el tamaño de las celdas de los grids de datos
    '-------------------------------------------------------------
    Private Sub AjustaCeldas()

        grdDoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        grdTkt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        'grdDoc.Columns(0).Width = 65
        'grdDoc.Columns(1).Width = 45
        'grdDoc.Columns(2).Width = 55
        'grdDoc.Columns(3).Width = 60
        'grdDoc.Columns(4).Width = 50
        'grdDoc.Columns(5).Width = 75
        'grdDoc.Columns(6).Width = 85
        'If grdDoc.RowCount > 8 Then                           'El grid tiene mas de 8 renglones
        '    grdDoc.Columns(6).Width = 75
        'End If
        'grdDoc.Columns(7).Width = 45
        'grdDoc.Columns(8).Width = 65
        'grdDoc.Refresh()
        'grdTkt.Columns(0).Width = 65
        'grdTkt.Columns(1).Width = 60
        'grdTkt.Columns(2).Width = 80
        'grdTkt.Columns(3).Width = 80
        'grdTkt.Columns(4).Width = 50
        'grdTkt.Columns(5).Width = 100
        'grdTkt.Columns(6).Width = 110
        'If grdTkt.RowCount > 8 Then                            'El grid tiene mas de 8 renglones
        '    grdTkt.Columns(6).Width = 105
        'End If
        grdTkt.Refresh()
    End Sub

    Private Sub chkTktFecha_Click(sender As Object, e As EventArgs) Handles chkTktFecha.Click

        cambio(1)
        If chkTktFecha.Checked = True Then
            txtTktFecha0.Visible = True
            txtTktFecha1.Visible = True
            txtTktFecha0.Select()
        Else
            txtTktFecha0.Text = ""
            txtTktFecha1.Text = ""
            txtTktFecha0.Visible = False
            txtTktFecha1.Visible = False
        End If
    End Sub

    Private Sub chkDocTicket_Click(sender As Object, e As EventArgs) Handles chkDocTicket.Click
        cambio(0)
        If chkDocTicket.Checked = True Then
            txtDocTkt0.Visible = True
            txtDocTkt1.Visible = True
            txtDocTkt0.Select()
        Else
            txtDocTkt0.Text = ""
            txtDocTkt1.Text = ""
            txtDocTkt0.Visible = False
            txtDocTkt1.Visible = False
        End If
    End Sub

    Private Sub txtDocFecha0_TextChanged(sender As Object, e As EventArgs)
        cambio(0)
    End Sub

    Private Sub txtDocFecha0_LostFocus(sender As Object, e As EventArgs)

        l.ValidaFecha(txtDocFecha0.Text, Date.Now)

    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub




    Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedIndexChanged

        Dim IndiceSeleccionado As Integer = cmbCliente.SelectedIndex
        Dim posGuion As Integer
        Dim d As New Datasource
        Dim dt As New DataTable

        If Not lbSelManual Then Return

        'cmbCliente.Items.Count > 1 And
        If IndiceSeleccionado > -1 Then
            'If IndiceSeleccionado > -1 Then                 'Se eligio alguna cuenta de la lista
            LimpiaCampos(1)                                  'Limpia los campos del grid
            On Error Resume Next
            If Val(cmbCliente.SelectedValue.ToString) > 0 Then  'La posicion de la lista tiene datos
                posGuion = cmbCliente.Text.IndexOf("-")
                lblNombre1.Text = cmbCliente.Text.Substring(posGuion)
                'lblNombre1.Text = cmbCliente.DisplayMember  'Mid(Trim(cmbCliente.List(cmbCliente.ListIndex)), 8)
                lblNombre1.Refresh()
                Cursor = System.Windows.Forms.Cursors.WaitCursor
                gs_Sql = "Select "
                gs_Sql = gs_Sql & "cuenta_cliente "
                gs_Sql = gs_Sql & "From "
                gs_Sql = gs_Sql & "TICKET.dbo.PRODUCTO_CONTRATADO "
                gs_Sql = gs_Sql & "Where "
                gs_Sql = gs_Sql & "producto_contratado = " & cmbCliente.SelectedValue.ToString

                dt = d.RealizaConsulta(gs_Sql)
                If dt.Rows.Count < 0 Then
                    MsgBox("No es posible leer la base de datos.", vbCritical, "SQL Server Error")
                Else

                    Dim row As DataRow = dt.Rows(dt.Rows.Count - 1)

                    txtCuenta.Text = CStr(row("cuenta-cliente"))
                    LlenaGridDocs()
                    LlenaGridTkts()
                    AjustaCeldas()
                End If
            Else                                            'Si existe algun error con los datos de la lista
                LimpiaCampos(0)
            End If
        End If
        'End If

    End Sub

    Private Sub grdTkt_DoubleClick(sender As Object, e As EventArgs) Handles grdTkt.DoubleClick

        Dim ls_Tkt As String

        ls_Tkt = grdTkt.CurrentRow.Cells(0).Value.ToString()
        'MsgBox("Ticket " + ls_Tkt, MessageBoxButtons.OK)
        If Trim(ls_Tkt) <> "" Then                 'Si la celda activa tiene un numero de operacion
            'frmConsulta.Consulta(1, ls_Tkt, False)
        End If

        If grdTkt.Rows.Count > 0 Then                            'Es un renglon de datos


            ls_Tkt = grdTkt.CurrentRow.Cells(0).Value.ToString()
            'MsgBox("Consulta del detalle del Ticket " + ls_Tkt + ", se encuentra en Construcción.", MessageBoxButtons.OK)
            'frmConsulta.Consulta(0, ls_Doc, False)
            If Trim(ls_Tkt) <> "" Then               'Si la celda activa contiene un numero de documento
                Cursor = System.Windows.Forms.Cursors.WaitCursor
                Dim frmConsultadesdeCliente As New frmConsulta
                'frmConsultadesdeCliente.ShowDialog()
                frmConsultadesdeCliente.Consulta(1, ls_Tkt, False)
                Cursor = System.Windows.Forms.Cursors.Default
                'Cursor = System.Windows.Forms.Cursors.WaitCursor
                'Me.WindowState = 1
                'frmConsulta.Consulta(1, ls_Tkt, False)
                'Cursor = System.Windows.Forms.Cursors.Default
                '    Me.WindowState = 1
            End If
        End If
    End Sub

    Private Sub txtCuenta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCuenta.KeyDown
        Dim d As New Datasource
        Dim dt As New DataTable

        If e.KeyCode = Keys.Enter Then
            'cmbCliente.Select()

            If Trim(txtCuenta.Text) <> "" Then                     'Existen datos de la cuenta
                If cmbCliente.Items.Count <= 1 Then                'No se ha buscado dicha cuenta
                    Cursor = System.Windows.Forms.Cursors.WaitCursor 'ShowWaitCursor
                    ObtieneAgencia()
                    ObtieneNombreCliente()
                    Cursor = System.Windows.Forms.Cursors.Default 'ShowDefaultCursor
                End If
            Else
                MsgBox("Ingrese una cuenta para llevar a cabo la consulta.", vbInformation, "Cuenta Inexistente")
            End If
        Else
            'If cmbCliente.Items.Count >= 1 Then LimpiaCampos(0)
            LimpiaCampos(0)
        End If
    End Sub

    Private Sub cmbCliente_Click(sender As Object, e As EventArgs) Handles cmbCliente.Click

        lbSelManual = True
        'Dim IndiceSeleccionado As Integer = cmbCliente.SelectedIndex
        'Dim posGuion As Integer
        'Dim d As New Datasource
        'Dim dt As New DataTable

        'If IndiceSeleccionado = -1 Then Return

        ''cmbCliente.Items.Count > 1 And
        'If IndiceSeleccionado > -1 Then
        '    'If IndiceSeleccionado > -1 Then                 'Se eligio alguna cuenta de la lista
        '    LimpiaCampos(1)                                  'Limpia los campos del grid
        '    On Error Resume Next
        '    If Val(cmbCliente.SelectedValue.ToString) > 0 Then  'La posicion de la lista tiene datos
        '        posGuion = cmbCliente.Text.IndexOf("-")
        '        lblNombre1.Text = cmbCliente.Text.Substring(posGuion)
        '        'lblNombre1.Text = cmbCliente.DisplayMember  'Mid(Trim(cmbCliente.List(cmbCliente.ListIndex)), 8)
        '        lblNombre1.Refresh()
        '        Cursor = System.Windows.Forms.Cursors.WaitCursor
        '        gs_Sql = "Select "
        '        gs_Sql = gs_Sql & "cuenta_cliente "
        '        gs_Sql = gs_Sql & "From "
        '        gs_Sql = gs_Sql & "TICKET.dbo.PRODUCTO_CONTRATADO "
        '        gs_Sql = gs_Sql & "Where "
        '        gs_Sql = gs_Sql & "producto_contratado = " & cmbCliente.SelectedValue.ToString

        '        dt = d.RealizaConsulta(gs_Sql)
        '        If dt.Rows.Count < 0 Then
        '            MsgBox("No es posible leer la base de datos.", vbCritical, "SQL Server Error")
        '        Else

        '            Dim row As DataRow = dt.Rows(dt.Rows.Count - 1)

        '            txtCuenta.Text = CStr(row("cuenta-cliente"))
        '            LlenaGridDocs()
        '            LlenaGridTkts()
        '            AjustaCeldas()
        '        End If
        '    Else                                            'Si existe algun error con los datos de la lista
        '        LimpiaCampos(0)
        '    End If
        'End If
        ''End If
    End Sub

    Private Sub cmbCliente_MouseHover(sender As Object, e As EventArgs) Handles cmbCliente.MouseHover

        If lbSiHayClientes Then
            ToolTip1.SetToolTip(cmbCliente, "Seleccione un cliente.")
            ToolTip1.ToolTipTitle = "Nombre del Cliente"
            ToolTip1.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub txtCuenta_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtCuenta.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            If Trim(txtCuenta.Text) <> "" Then                     'Existen datos de la cuenta
                If cmbCliente.Items.Count <= 1 Then                'No se ha buscado dicha cuenta
                    Cursor = System.Windows.Forms.Cursors.WaitCursor 'ShowWaitCursor
                    ObtieneAgencia()
                    ObtieneNombreCliente()
                    Cursor = System.Windows.Forms.Cursors.Default 'ShowDefaultCursor
                End If
            Else
                MsgBox("Ingrese una cuenta para llevar a cabo la consulta.", vbInformation, "Cuenta Inexistente")
            End If
        End If
    End Sub


End Class