Imports System.IO
Imports System.Threading

Public Class frmReimpRepMT198
    Private strnameFile As String
    Private objExcel As Object   'Objeto excel
    Private existeArchivo As Boolean
    Private strFile As String

    Private sRutaTemporal, sNomArchivo As String
    Private objLibreria As New Libreria
    Private objDatasource As New Datasource
    Private Sub frmReimpRepMT198_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        'ControlBox = False
        FormBorderStyle = FormBorderStyle.FixedSingle
        Dim dtRespConsulta As DataTable
        Dim dsLista As New DataSet
        gs_Sql = "Select descripcion_agencia, agencia from CATALOGOS..AGENCIA (nolock) where agencia = 1 order by agencia"
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        cboAgencias.Items.Insert(0, "Selecciona una opción")
        For Each row As DataRow In dtRespConsulta.Rows
            cboAgencias.Items.Insert(row.Item("agencia"), row.Item("descripcion_agencia"))
        Next
        cboAgencias.SelectedIndex = 0
        If Thread.CurrentThread.CurrentCulture.Name = "en-US" Then
            dtpFecha.CustomFormat = "MM-dd-yyyy"
        ElseIf Thread.CurrentThread.CurrentCulture.Name = "es-MX" Then
            dtpFecha.CustomFormat = "dd-MM-yyyy"
        End If
        If Not Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Desktop & "\ReimpresionMT198") Then
            Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Desktop & "\ReimpresionMT198")
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir de Reimpresión MT198") <> vbYes Then
            Exit Sub
        Else
            Me.Close()
        End If

    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Dim strTipoReporte As String = 0
        Dim lvntObtenerOperaciones(0, 0) As String
        Dim dblContador As Double
        Dim dtRespConsulta As DataTable
        'Screen.MousePointer = vbHourglass

        'If cboAgencias.SelectedIndex > 0 And IsDate(dtpFecha.Text) Then
        If cboAgencias.SelectedIndex > 0 And IsDate(dtpFecha.Text) Then

            'If generaInstancia(cboAgencias.ItemData(cboAgencias.ListIndex)) Then
            If generaInstancia(cboAgencias.SelectedIndex) Then

                'If grdOperaciones.RowSel <> 0 And grdOperaciones.RowSel <> (grdOperaciones.Rows - 1) Then
                If grdOperaciones.SelectedRows.Count <> 0 And grdOperaciones.SelectedRows.Count <> (grdOperaciones.Rows.Count - 1) Then
                    Dim sNumRep As String = ""

                    For Each dgvrRegistroSeleccionado As DataGridViewRow In grdOperaciones.SelectedRows
                        sNumRep = sNumRep & ","
                        sNumRep = sNumRep & dgvrRegistroSeleccionado.Cells(0).Value
                    Next
                    sNumRep = sNumRep.Substring(1, sNumRep.Length - 1)

                    gs_Sql = "SELECT O.operacion, TRS.desc_tipo_reporte_swift " &
                            "FROM OPERACION O, OPERACION_SWIFT OS, REPORTE_SWIFT RS, TIPO_REPORTE_SWIFT TRS " &
                            "WHERE OS.no_rep_swift in (" & sNumRep & ") " &
                                    "AND trs.agencia = rs.agencia " &
                                    "AND rs.agencia = " & cboAgencias.SelectedIndex & " " &
                                    "AND OS.no_rep_swift = RS.no_rep_swift " &
                                    "AND OS.operacion = O.operacion " &
                                    "AND rs.tipo_reporte_swift = trs.tipo_reporte_swift"

                    'dbGetRecord
                    dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                    gs_Sql = ""
                    'strTipoReporte = dbGetValue(1)
                    If (dtRespConsulta IsNot Nothing) Then
                        strTipoReporte = dtRespConsulta.Rows(0).Item(1)
                    End If
                    ReDim lvntObtenerOperaciones(dtRespConsulta.Rows.Count - 1, 1)
                    dblContador = 0

                    'Do While dbError() = 0
                    Do While dblContador <> dtRespConsulta.Rows.Count
                        lvntObtenerOperaciones(dblContador, 0) = dtRespConsulta.Rows(dblContador).Item(1) 'dbGetValue(1)
                        lvntObtenerOperaciones(dblContador, 1) = dtRespConsulta.Rows(dblContador).Item(0) 'dbGetValue(0)
                        dblContador = dblContador + 1
                    Loop

                    For dblContador = 0 To UBound(lvntObtenerOperaciones)
                        If poneEncabezados(lvntObtenerOperaciones(dblContador, 0)) Then
                            insertaOpExcel(lvntObtenerOperaciones(dblContador, 1))
                        End If
                    Next dblContador
                    Call terminaExcel()
                    Call muestraExcel()
                    Erase lvntObtenerOperaciones
                    FileCopy(sRutaTemporal, My.Computer.FileSystem.SpecialDirectories.Desktop & "\ReimpresionMT198\" & sNomArchivo)
                    'Kill(sRutaTemporal)
                    'If File.Exists(sRutaTemporal) Then
                    '    Kill(sRutaTemporal)
                    'End If
                Else

                    If MsgBox("No ha selecionado ninguna operación." & vbCrLf & vbCrLf & "¿Desea imprimir todas las operaciones existentes?.", vbYesNo, "Reporte MT198") = vbYes Then
                        gs_Sql = "SELECT O.operacion, TRS.desc_tipo_reporte_swift " &
                                "FROM OPERACION O, OPERACION_SWIFT OS, REPORTE_SWIFT RS, TIPO_REPORTE_SWIFT TRS " &
                                "WHERE O.fecha_operacion = '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' " &
                                        "AND trs.agencia = rs.agencia " &
                                        "AND rs.agencia = " & cboAgencias.SelectedIndex & " " &
                                        "AND OS.no_rep_swift = RS.no_rep_swift " &
                                        "AND OS.operacion = O.operacion " &
                                        "AND rs.tipo_reporte_swift = trs.tipo_reporte_swift " &
                                "Order by trs.desc_tipo_reporte_swift"

                        'dbGetRecord
                        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                        dblContador = 0

                        ReDim lvntObtenerOperaciones(grdOperaciones.Rows.Count - 2, 1)

                        'Do While dbError() = 0
                        Do While dblContador <> dtRespConsulta.Rows.Count
                            lvntObtenerOperaciones(dblContador, 0) = dtRespConsulta.Rows(dblContador).Item(1) 'dbGetValue(1)
                            lvntObtenerOperaciones(dblContador, 1) = dtRespConsulta.Rows(dblContador).Item(0) 'dbGetValue(0)
                            dblContador = dblContador + 1
                            'dbGetRecord
                        Loop

                        For dblContador = 0 To UBound(lvntObtenerOperaciones)
                            If poneEncabezados(lvntObtenerOperaciones(dblContador, 0)) Then
                                insertaOpExcel(lvntObtenerOperaciones(dblContador, 1))
                            End If
                        Next dblContador

                        Call terminaExcel
                        Call muestraExcel()
                        Erase lvntObtenerOperaciones
                        FileCopy(sRutaTemporal, My.Computer.FileSystem.SpecialDirectories.Desktop & "\ReimpresionMT198\" & sNomArchivo)
                        'Kill(sRutaTemporal)
                        'If File.Exists(sRutaTemporal) Then
                        '    File.Delete(sRutaTemporal)
                        'End If
                    End If
                End If
                'objExcel.Workbooks(strFile).Close
                'objExcel.Workbooks.SaveChanges(True)
            End If
        End If
        'Screen.MousePointer = vbDefault
    End Sub
    '-------------------------------------------------------------------------------
    'Se genera la instancia de Excel si no existe si ya existe toma el existente
    '-------------------------------------------------------------------------------
    Private Function generaInstancia(ByVal Agencia As Long) As Boolean

        On Error GoTo errExcel

        generaInstancia = False

        Dim intFile As Integer
        Dim nomAgencia As String

        If Agencia = 1 Then
            nomAgencia = "HO"
        ElseIf Agencia = 3 Then
            nomAgencia = "GC"
        End If

        'Create Object
        'Set objExcel = CreateObject("Excel.Application")
        objExcel = CreateObject("Excel.Application")
        objExcel.DisplayAlerts = False

        'ChDir(GetTempDir)
        'ChDir(Path.GetTempPath())
        intFile = 1

        'Nombre del archivo
        strnameFile = "B" & nomAgencia & Format(Now, "yyyyMMddHHmmss")
        strFile = Path.GetTempPath() & strnameFile & ".xlsx"    ' porque no genera bien la ruta por el cambio de chequeras. 14/oct/2005 "\" & Esto ya no es necesario porque ya lo envia la funcion GetTempDir (03-11-2005)

        'Verificamos si existe el archivo
        'If Dir(strFile, vbArchive) = "" Then
        If File.Exists(strFile) = False Then
            existeArchivo = False
            'Si no existe se crea
            'Open strFile For Output As #intFile
            File.WriteAllBytes(strFile, My.Resources.ArchivoExcel)
            existeArchivo = True
        Else
            existeArchivo = True
        End If

        'Close #intFile

        'Open Excel File
        'objExcel.Workbooks.Open FileName:=strFile
        objExcel.Workbooks.Open(strFile)
        sRutaTemporal = strFile
        sNomArchivo = strnameFile & ".xlsx"
        'Para mostrar la ventana excel
        'objExcel.Application.Visible = True

        generaInstancia = True
        Exit Function
errExcel:
        MsgBox(Err.Number & " " & Err.Description, vbCritical, "Error")
        'Destroy Object
        'Set objExcel = Nothing
        objExcel.Workbooks.Close()
        objExcel = Nothing
        generaInstancia = False
    End Function
    '-------------------------------------------------------------------------------
    'Funcion prepara archivo de excel para dejar listo los encabezados
    'para imprimir las operacion
    '-------------------------------------------------------------------------------
    Private Function poneEncabezados(ByVal nombreOp As String) As Boolean

        On Error GoTo errEncabezados

        Dim X As Long
        Dim Y As Long

        poneEncabezados = False

        'La longitud para una pestaña no debe sobrepasar 31 caracteres
        If Len(nombreOp) > 31 Then nombreOp = Mid(nombreOp, 1, 30)

        Y = 0
        'Si el archivo ya esta creado agrega lo necesario
        If StrComp(strnameFile, objExcel.Worksheets.Item(1).Name, vbTextCompare) <> 0 Then

            'Verificamos si ya existe la hoja de ese tipo de operaciones
            For X = 1 To objExcel.Worksheets.Count
                If StrComp(objExcel.Worksheets.Item(X).Name, nombreOp, vbTextCompare) = 0 Then
                    Y = X
                    Exit For
                End If
            Next X

            'Si ya existe checa si tiene los encabezados
            If Y > 0 Then
                objExcel.Worksheets.Item(Y).Select
                'Si son necesarias Headers
                objExcel.Range("B1").Select
                If StrComp(objExcel.ActiveCell.FormulaR1C1, "No. de Operaciones", vbTextCompare) <> 0 Then
                    objExcel.ActiveCell.FormulaR1C1 = "No. de Operaciones"
                End If
                objExcel.Range("C2").Select
                If StrComp(objExcel.ActiveCell.FormulaR1C1, "REPORTE MT198", vbTextCompare) <> 0 Then
                    objExcel.ActiveCell.FormulaR1C1 = "REPORTE MT198"
                End If
                objExcel.Range("A3").Select
                If StrComp(objExcel.ActiveCell.FormulaR1C1, "FECHA OPERACIÓN", vbTextCompare) <> 0 Then
                    objExcel.ActiveCell.FormulaR1C1 = "FECHA OPERACIÓN"
                End If
                objExcel.Range("B3").Select
                If StrComp(objExcel.ActiveCell.FormulaR1C1, "AGENCIA", vbTextCompare) <> 0 Then
                    objExcel.ActiveCell.FormulaR1C1 = "AGENCIA"
                End If
                objExcel.Range("C3").Select
                If StrComp(objExcel.ActiveCell.FormulaR1C1, "OPERACIÓN", vbTextCompare) <> 0 Then
                    objExcel.ActiveCell.FormulaR1C1 = "OPERACIÓN"
                End If
                objExcel.Range("D3").Select
                If StrComp(objExcel.ActiveCell.FormulaR1C1, "REFERENCIA", vbTextCompare) <> 0 Then
                    objExcel.ActiveCell.FormulaR1C1 = "REFERENCIA"
                End If
                objExcel.Range("E3").Select
                If StrComp(objExcel.ActiveCell.FormulaR1C1, "CUENTA CLIENTE", vbTextCompare) <> 0 Then
                    objExcel.ActiveCell.FormulaR1C1 = "CUENTA CLIENTE"
                End If
                objExcel.Range("F3").Select
                If StrComp(objExcel.ActiveCell.FormulaR1C1, "MONTO OPERACIÓN", vbTextCompare) <> 0 Then
                    objExcel.ActiveCell.FormulaR1C1 = "MONTO OPERACIÓN"
                End If

                objExcel.Range("G3").Select
                If StrComp(objExcel.ActiveCell.FormulaR1C1, "NO. REPORTE SWIFT", vbTextCompare) <> 0 Then
                    objExcel.ActiveCell.FormulaR1C1 = "NO. REPORTE SWIFT"
                End If

                'Si la hoja no existe crea una con ese nombre y pone el encabezado
            Else
                objExcel.Worksheets.Add
                objExcel.ActiveWorkbook.ActiveSheet.Name = nombreOp
                'Headers
                objExcel.Range("A1").Select
                objExcel.ActiveCell.FormulaR1C1 = "0"
                objExcel.Range("B1").Select
                objExcel.ActiveCell.FormulaR1C1 = "No. de Operaciones"
                objExcel.Range("C2").Select
                objExcel.ActiveCell.FormulaR1C1 = "REPORTE MT198"
                objExcel.Range("A3").Select
                objExcel.ActiveCell.FormulaR1C1 = "FECHA OPERACIÓN"
                objExcel.Range("B3").Select
                objExcel.ActiveCell.FormulaR1C1 = "AGENCIA"
                objExcel.Range("C3").Select
                objExcel.ActiveCell.FormulaR1C1 = "OPERACIÓN"
                objExcel.Range("D3").Select
                objExcel.ActiveCell.FormulaR1C1 = "REFERENCIA"
                objExcel.Range("E3").Select
                objExcel.ActiveCell.FormulaR1C1 = "CUENTA CLIENTE"
                objExcel.Range("F3").Select
                objExcel.ActiveCell.FormulaR1C1 = "MONTO OPERACIÓN"
                objExcel.Range("G3").Select
                objExcel.ActiveCell.FormulaR1C1 = "NO. REPORTE SWIFT"
            End If
            'Si el archivo No esta creado pone encabezados
        Else  'If Not existeArchivo Then
            'Ponemos el nombre a la hoja de Excel correspondiente al tipo de operacion
            objExcel.ActiveWorkbook.ActiveSheet.Name = nombreOp
            'Headers
            objExcel.Range("A1").Select
            objExcel.ActiveCell.FormulaR1C1 = "0"
            objExcel.Range("B1").Select
            objExcel.ActiveCell.FormulaR1C1 = "No. de Operaciones"
            objExcel.Range("C2").Select
            objExcel.ActiveCell.FormulaR1C1 = "REPORTE MT198"
            objExcel.Range("A3").Select
            objExcel.ActiveCell.FormulaR1C1 = "FECHA OPERACIÓN"
            objExcel.Range("B3").Select
            objExcel.ActiveCell.FormulaR1C1 = "AGENCIA"
            objExcel.Range("C3").Select
            objExcel.ActiveCell.FormulaR1C1 = "OPERACIÓN"
            objExcel.Range("D3").Select
            objExcel.ActiveCell.FormulaR1C1 = "REFERENCIA"
            objExcel.Range("E3").Select
            objExcel.ActiveCell.FormulaR1C1 = "CUENTA CLIENTE"
            objExcel.Range("F3").Select
            objExcel.ActiveCell.FormulaR1C1 = "MONTO OPERACIÓN"
            objExcel.Range("G3").Select
            objExcel.ActiveCell.FormulaR1C1 = "NO. REPORTE SWIFT"
        End If
        poneEncabezados = True
        Exit Function
errEncabezados:
        MsgBox(Err.Number & " " & Err.Description, vbCritical, "Error Encabezados")
        poneEncabezados = False
    End Function
    '----------------------------------------------------------------
    'Agrega la operacion correspondiente al Excel
    '----------------------------------------------------------------
    Private Function insertaOpExcel(ByVal noTicket As String) As Boolean
        'Modificación: BAGO-EDS-07/MZO/06. Cambio en los "Select Case" para adecuar el Null por Is Null

        On Error GoTo errponRenglon

        Dim noRenglon As Long
        Dim numOpDef As Integer
        Dim dtRespConsulta As DataTable = New DataTable

        insertaOpExcel = False

        numOpDef = opDefXTicket(noTicket)
        'Encontramos los datos a imprimir en el excel segun tipo de operacion definida para
        'buscar en sus tablas correspondientes
        If numOpDef <> 8058 Then
            If numOpDef = 8552 Or numOpDef = 8553 Then
                gs_Sql = "SELECT OP.fecha_operacion, AG.descripcion_agencia, OP.operacion, REF.observaciones, "
                gs_Sql = gs_Sql & "AG.prefijo_agencia + ' ' + PC.cuenta_cliente + ' ' + TCE.sufijo_kapiti, "
                gs_Sql = gs_Sql & "OP.monto_operacion "
                gs_Sql = gs_Sql & "FROM TICKET.dbo.OPERACION OP, CATALOGOS.dbo.AGENCIA AG, "
                gs_Sql = gs_Sql & "TICKET.dbo.DEPOSITO_CED REF, TICKET.dbo.PRODUCTO_CONTRATADO PC, "
            ElseIf numOpDef = 8052 Or numOpDef = 8053 Or numOpDef = 8054 Or numOpDef = 8056 Or numOpDef = 8057 Then
                gs_Sql = "SELECT OP.fecha_operacion, AG.descripcion_agencia, OP.operacion, REF.observaciones, "
                gs_Sql = gs_Sql & "AG.prefijo_agencia + ' ' + PC.cuenta_cliente + ' ' + TCE.sufijo_kapiti, "
                gs_Sql = gs_Sql & "OP.monto_operacion "
                gs_Sql = gs_Sql & "FROM TICKET.dbo.OPERACION OP, CATALOGOS.dbo.AGENCIA AG, "
                gs_Sql = gs_Sql & "TICKET.dbo.RETIRO_CED REF, TICKET.dbo.PRODUCTO_CONTRATADO PC, "
            ElseIf numOpDef <> 0 Then
                gs_Sql = "SELECT OP.fecha_operacion, AG.descripcion_agencia, OP.operacion, REF.referencia, "
                gs_Sql = gs_Sql & "AG.prefijo_agencia + ' ' + PC.cuenta_cliente + ' ' + TCE.sufijo_kapiti, "
                gs_Sql = gs_Sql & "OP.monto_operacion "
                gs_Sql = gs_Sql & "FROM TICKET.dbo.OPERACION OP, CATALOGOS.dbo.AGENCIA AG, "
                gs_Sql = gs_Sql & "TICKET.dbo.REFERENCIAS REF, TICKET.dbo.PRODUCTO_CONTRATADO PC, "
            End If
            gs_Sql = gs_Sql & "TICKET.dbo.CUENTA_EJE CE, TICKET.dbo.TIPO_CUENTA_EJE TCE "
            gs_Sql = gs_Sql & "WHERE CE.tipo_cuenta_eje = TCE.tipo_cuenta_eje "
            gs_Sql = gs_Sql & "AND PC.producto_contratado = CE.producto_contratado "
            gs_Sql = gs_Sql & "AND OP.producto_contratado = PC.producto_contratado "
            gs_Sql = gs_Sql & "AND OP.operacion = REF.operacion "
            gs_Sql = gs_Sql & "AND PC.agencia = AG.agencia "
            gs_Sql = gs_Sql & "AND OP.operacion = " & CLng(noTicket)
        ElseIf numOpDef = 8058 Then
            gs_Sql = "SELECT OP.fecha_operacion, AG.descripcion_agencia, OP.operacion, REF.referencia, "
            gs_Sql = gs_Sql & "AG.prefijo_agencia + ' ' + PC.cuenta_cliente + ' ' + TCE.sufijo_kapiti, "
            gs_Sql = gs_Sql & "TMOP.monto_operacion "
            gs_Sql = gs_Sql & "FROM TICKET.dbo.OPERACION OP, TICKET.dbo.TMP_OPS_COMISIONES TMOP, CATALOGOS.dbo.AGENCIA AG, "
            gs_Sql = gs_Sql & "TICKET.dbo.REFERENCIAS REF, TICKET.dbo.PRODUCTO_CONTRATADO PC, "
            gs_Sql = gs_Sql & "TICKET.dbo.CUENTA_EJE CE, TICKET.dbo.TIPO_CUENTA_EJE TCE "
            gs_Sql = gs_Sql & "WHERE CE.tipo_cuenta_eje = TCE.tipo_cuenta_eje "
            gs_Sql = gs_Sql & "AND PC.producto_contratado = CE.producto_contratado "
            gs_Sql = gs_Sql & "AND OP.producto_contratado = PC.producto_contratado "
            gs_Sql = gs_Sql & "AND OP.operacion = TMOP.operacion "
            gs_Sql = gs_Sql & "AND TMOP.producto_contratado = PC.producto_contratado "
            gs_Sql = gs_Sql & "AND TMOP.operacion = REF.operacion "
            gs_Sql = gs_Sql & "AND PC.agencia = AG.agencia "
            gs_Sql = gs_Sql & "AND TMOP.operacion = " & CLng(noTicket)
        End If
        'dbExecQuery gs_Sql
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbGetRecord
        'If Not dbError() Then
        If dtRespConsulta.Rows.Count > 0 Then
            objExcel.Range("A1").Select
            noRenglon = CLng(objExcel.ActiveCell.FormulaR1C1)
            objExcel.Range("A" & noRenglon + 4).Select
            objExcel.ActiveCell.FormulaR1C1 = Format(dtRespConsulta.Rows(0).Item(0), "dd-MM-yyyy")
            objExcel.Range("B" & noRenglon + 4).Select
            objExcel.ActiveCell.FormulaR1C1 = dtRespConsulta.Rows(0).Item(1)
            objExcel.Range("C" & noRenglon + 4).Select
            objExcel.ActiveCell.FormulaR1C1 = dtRespConsulta.Rows(0).Item(2)
            objExcel.Range("D" & noRenglon + 4).Select
            objExcel.ActiveCell.FormulaR1C1 = dtRespConsulta.Rows(0).Item(3)
            objExcel.Range("E" & noRenglon + 4).Select
            objExcel.ActiveCell.FormulaR1C1 = dtRespConsulta.Rows(0).Item(4)
            objExcel.Range("F" & noRenglon + 4).Select
            objExcel.ActiveCell.FormulaR1C1 = Format(dtRespConsulta.Rows(0).Item(5), "$#,###.00")
            objExcel.Range("G" & noRenglon + 4).Select
            objExcel.ActiveCell.FormulaR1C1 = grdOperaciones.Rows(noRenglon + 1).Cells(0).Value.ToString 'grdOperaciones.TextMatrix(noRenglon + 1, 0)

            objExcel.Range("A1").Select
            objExcel.ActiveCell.FormulaR1C1 = CStr(noRenglon + 1)
        End If
        'dbEndQuery
        insertaOpExcel = True
        Exit Function
errponRenglon:
        MsgBox(Err.Number & " " & Err.Description, vbCritical, "Error Agrega Operación")
        insertaOpExcel = False
    End Function
    Private Function terminaExcel()

        Dim verExel As Integer

        On Error GoTo errTermina
        'Save File

        verExel = objExcel.Version

        'Se agrega validación de version de Exel SLGM 20121016
        If Not existeArchivo Then
            If verExel = 11 Then
                'xlExcel9795 = 43
                'objExcel.ActiveWorkbook.SaveAs strFile, 43
                objExcel.ActiveWorkbook.SaveAs(strFile, 43)
            ElseIf verExel = 12 Then
                objExcel.ActiveWorkbook.SaveAs(strFile)
            End If
        Else
            objExcel.ActiveWorkbook.Save
        End If

        'objExcel.DisplayAlerts(True)
        'Close File
        objExcel.ActiveWorkbook.Close(True)
        'Cerrar Excel
        objExcel.Quit
        'Destroy Object
        objExcel = Nothing
        Exit Function
errTermina:
        MsgBox(Err.Number & " " & Err.Description, vbCritical, "Error Cierra Excel")
        objExcel = Nothing
    End Function

    Private Function muestraExcel()

        On Error GoTo errMuestra

        'Create Object
        objExcel = CreateObject("Excel.Application")
        'Open Excel File
        'objExcel.Workbooks.Open FileName:=strFile
        objExcel.Workbooks.Open(strFile)
        'Para mostrar la ventana excel
        objExcel.Application.Visible = True
        'Destroy Object
        objExcel = Nothing
        Exit Function
errMuestra:
        MsgBox(Err.Number & " " & Err.Description, vbCritical, "Error Muestra Excel")
        objExcel = Nothing
    End Function
    '----------------------------------------------------------------------------------
    'La funcion regresa el tipo de Operacion definida segun el numero de Ticket que se pasa
    '----------------------------------------------------------------------------------
    Private Function opDefXTicket(ByVal ticket As Double) As Integer

        On Error GoTo erropDefXTicket

        Dim ls_qry As String
        Dim dtRespConsulta As DataTable

        opDefXTicket = 0
        'dbEndQuery
        ls_qry = "SELECT operacion_definida FROM OPERACION "
        ls_qry = ls_qry & "WHERE operacion = " & ticket
        'dbExecQuery ls_qry
        dtRespConsulta = objDatasource.RealizaConsulta(ls_qry)
        'dbGetRecord
        'If Not IsdbError Then opDefXTicket = Val(dbGetValue(0))
        If dtRespConsulta.Rows.Count > 0 Then opDefXTicket = Val(dtRespConsulta.Rows(0).Item(0))
        'dbEndQuery
        Exit Function
erropDefXTicket:
        MsgBox(Err.Number & " " & Err.Description, vbCritical, "Error")
        opDefXTicket = 0
    End Function

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        Dim strTipoReporte, sSelectionFormula As String
        Dim lvntObtenerOperaciones1(0) As Object
        Dim lvntObtenerOperaciones2(0) As VariantType
        Dim dblContador As Double
        Dim dtRespConsulta As DataTable
        Dim rptDoc As New ReportDocument
        Dim ArchReimpresion As String = "MT198 Reimpresion.pdf"
        Dim sNumRep As String = ""
        Dim lsAmbiente As String = ""
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""

        'Screen.MousePointer = vbHourglass
        lblTotalOperaciones.Visible = False
        pbGenArch.Maximum = 100
        pbGenArch.Value = 0
        lbGenArch.Visible = True
        pbGenArch.Visible = True


        If cboAgencias.SelectedIndex > -1 And IsDate(dtpFecha.Text) Then
            If grdOperaciones.SelectedRows.Count <> 0 And grdOperaciones.SelectedRows.Count <> (grdOperaciones.Rows.Count - 1) Then
                For Each dgvrRegistroSeleccionado As DataGridViewRow In grdOperaciones.SelectedRows
                    sNumRep = sNumRep & ","
                    sNumRep = sNumRep & dgvrRegistroSeleccionado.Cells(0).Value
                Next
                sNumRep = sNumRep.Substring(1, sNumRep.Length - 1)
                gs_Sql = "SELECT trs.desc_tipo_reporte_swift,trs.tipo_reporte_swift " &
                        "FROM OPERACION O, OPERACION_SWIFT OS, REPORTE_SWIFT RS, TIPO_REPORTE_SWIFT TRS " &
                        "WHERE OS.no_rep_swift in(" & sNumRep & ") " &
                                "AND trs.agencia = rs.agencia " &
                                "AND rs.agencia = " & cboAgencias.SelectedIndex & " " &
                                "AND OS.no_rep_swift = RS.no_rep_swift " &
                                "AND OS.operacion = O.operacion " &
                                "AND rs.tipo_reporte_swift = trs.tipo_reporte_swift " &
                        "Group by trs.tipo_reporte_swift, trs.desc_tipo_reporte_swift"
            Else
                If MsgBox("No ha selecionado ninguna operación." & vbCrLf & vbCrLf & "¿Desea imprimir todas las operaciones existentes?.", vbYesNo, "Reporte MT198") = vbYes Then
                    gs_Sql = "SELECT trs.desc_tipo_reporte_swift,trs.tipo_reporte_swift " &
                            "FROM OPERACION O, OPERACION_SWIFT OS, REPORTE_SWIFT RS, TIPO_REPORTE_SWIFT TRS " &
                            "WHERE O.fecha_operacion = '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' " &
                                    "AND trs.agencia = rs.agencia " &
                                    "AND rs.agencia = " & cboAgencias.SelectedIndex & " " &
                                    "AND OS.no_rep_swift = RS.no_rep_swift " &
                                    "AND OS.operacion = O.operacion " &
                                    "AND rs.tipo_reporte_swift = trs.tipo_reporte_swift " &
                            "Group by trs.tipo_reporte_swift, trs.desc_tipo_reporte_swift"
                Else
                    Exit Sub
                End If
            End If
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            'dbGetRecord
            dblContador = 0

            'Do While dbError() = 0
            Do While dblContador <> dtRespConsulta.Rows.Count
                ReDim Preserve lvntObtenerOperaciones1(dtRespConsulta.Rows.Count - 1)
                ReDim Preserve lvntObtenerOperaciones2(dtRespConsulta.Rows.Count - 1)
                lvntObtenerOperaciones1(dblContador) = dtRespConsulta.Rows(dblContador).Item(0)
                lvntObtenerOperaciones2(dblContador) = dtRespConsulta.Rows(dblContador).Item(1)
                dblContador = dblContador + 1
                'dbGetRecord
            Loop
            'dbEndQuery
            pbGenArch.Maximum = lvntObtenerOperaciones1.Length
            If grdOperaciones.SelectedRows.Count <> 0 And grdOperaciones.SelectedRows.Count <> (grdOperaciones.Rows.Count - 1) Then
                For dblContador = 0 To UBound(lvntObtenerOperaciones1)
                    rptDoc = New ReportDocument
                    lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
                    lsReporte = lsRutaFolder & "MT198_Reimpresion" & lsAmbiente & ".rpt"
                    rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                    objLibreria.logonBDreporte(rptDoc, 1)
                    rptDoc.DataDefinition.FormulaFields.Item("Operacion").Text = "'" & lvntObtenerOperaciones1(dblContador) & "'"
                    rptDoc.DataDefinition.FormulaFields.Item("Agencia").Text = "'" & cboAgencias.GetItemText(cboAgencias.SelectedItem) & "'"
                    rptDoc.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & Trim(dtpFecha.Text) & "'"
                    rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Format(gs_HoraSistema, "hh:mm") & "'"
                    sSelectionFormula = "{REPORTE_SWIFT.status_reporte} in [ 3, 4, 5 ] and "
                    sSelectionFormula = sSelectionFormula & "{REPORTE_SWIFT.fecha_reporte} = Date (" & dtpFecha.Value.Date.Year & ", " & dtpFecha.Value.Date.Month & ", " & dtpFecha.Value.Date.Day & ") and "
                    sSelectionFormula = sSelectionFormula & "{REPORTE_SWIFT.agencia} = " & cboAgencias.SelectedIndex & " and "
                    sSelectionFormula = sSelectionFormula & "{REPORTE_SWIFT.tipo_reporte_swift} = " & lvntObtenerOperaciones2(dblContador) & " and "
                    sSelectionFormula = sSelectionFormula & "{REPORTE_SWIFT.no_rep_swift} in [ " & sNumRep & " ] " 'grdOperaciones.Rows(grdOperaciones.CurrentRow.Index).Cells(0).Value.ToString
                    rptDoc.RecordSelectionFormula = sSelectionFormula
                    'rptDoc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.Desktop & "\ReimpresionMT198\" & dblContador & "_" & ArchReimpresion)
                    opcionReporte = 16
                    RepOperativa.reporteOFAC = rptDoc
                    RepOperativa.ShowDialog()
                    pbGenArch.Value = dblContador + 1
                Next dblContador
            Else
                For dblContador = 0 To UBound(lvntObtenerOperaciones1)
                    rptDoc = New ReportDocument
                    lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
                    lsReporte = lsRutaFolder & "MT198_Reimpresion" & lsAmbiente & ".rpt"
                    rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                    objLibreria.logonBDreporte(rptDoc, 1)
                    rptDoc.DataDefinition.FormulaFields.Item("Operacion").Text = "'" & lvntObtenerOperaciones1(dblContador) & "'"
                    rptDoc.DataDefinition.FormulaFields.Item("Agencia").Text = "'" & cboAgencias.GetItemText(cboAgencias.SelectedItem) & "'"
                    rptDoc.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & Trim(dtpFecha.Text) & "'"
                    rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Format(gs_HoraSistema, "hh:mm") & "'"
                    sSelectionFormula = "{REPORTE_SWIFT.status_reporte} in [3,4,5] and "
                    sSelectionFormula = sSelectionFormula & "{REPORTE_SWIFT.fecha_reporte}=Date (" & dtpFecha.Value.Date.Year & ", " & dtpFecha.Value.Date.Month & ", " & dtpFecha.Value.Date.Day & ") and "
                    sSelectionFormula = sSelectionFormula & "{REPORTE_SWIFT.agencia}= " & cboAgencias.SelectedIndex & " and "
                    sSelectionFormula = sSelectionFormula & "{REPORTE_SWIFT.tipo_reporte_swift}= " & lvntObtenerOperaciones2(dblContador)
                    rptDoc.RecordSelectionFormula = sSelectionFormula
                    'rptDoc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.Desktop & "\ReimpresionMT198\" & dblContador & "_" & ArchReimpresion)
                    opcionReporte = 16
                    RepOperativa.reporteOFAC = rptDoc
                    RepOperativa.ShowDialog()
                    pbGenArch.Value = dblContador + 1
                Next dblContador
            End If
        End If
        MsgBox("Los archivos se generaron de forma correcta")
        lblTotalOperaciones.Visible = True
        lbGenArch.Visible = False
        pbGenArch.Visible = False
        'Screen.MousePointer = vbDefault
    End Sub
    Private Sub cboAgencias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAgencias.SelectedIndexChanged
        ObtenerOperaciones()
    End Sub
    Private Function ObtenerOperaciones()
        Dim dtRespConsulta As DataTable
        'Dim drRegistro As DataRow

        If IsDate(dtpFecha.Text) And cboAgencias.SelectedIndex <> 0 Then

            dtRespConsulta = objDatasource.RealizaConsulta("Select count(*) from CATALOGOS..DIAS_FERIADOS WHERE fecha = '" & dtpFecha.Value.Year & "-" & dtpFecha.Value.Month & "-" & dtpFecha.Value.Day & "'")
            'dbGetRecord

            'If Val(dbGetValue(0)) = 0 Then
            If dtRespConsulta.Rows(0).Item(0) = 0 Then
                'dbEndQuery
                Dim dblContador As Double

                gs_Sql = "SELECT os.no_rep_swift as [No Reporte],op.operacion as Ticket,trs.desc_tipo_reporte_swift as Operación, op.fecha_captura as [Fecha Captura], op.monto_operacion as Monto, " &
                            "ltrim(rtrim(convert(char(4),A.prefijo_agencia))) + '-' + ltrim(rtrim(convert(char(7),pc.cuenta_cliente))) + '-' + ltrim(rtrim(convert(char(3),tce.sufijo_kapiti))) AS Cuenta " &
                    "FROM OPERACION OP, PRODUCTO_CONTRATADO PC,OPERACION_DEFINIDA od, TIPO_REPORTE_SWIFT trs, " &
                            "catalogos..agencia A, CUENTA_EJE CE, TIPO_CUENTA_EJE TCE, OPERACION_SWIFT OS, REPORTE_SWIFT RS " &
                    "WHERE OP.operacion_definida = od.operacion_definida " &
                            "AND od.operacion_definida_global = trs.operacion_definida_global " &
                            "AND od.agencia = trs.agencia " &
                            "AND od.agencia = " & cboAgencias.SelectedIndex & " " &
                            "AND od.agencia = A.agencia " &
                            "AND op.producto_contratado = CE.producto_contratado " &
                            "AND ce.tipo_cuenta_eje = TCE.tipo_cuenta_eje " &
                            "AND op.operacion = os.operacion " &
                            "AND RS.no_rep_swift = os.no_rep_swift " &
                            "AND status_reporte = 4 " &
                            "AND trs.tipo_reporte_swift IN (SELECT trs.tipo_reporte_swift " &
                                                            "FROM OPERACION_DEFINIDA od (nolock), TIPO_REPORTE_SWIFT trs (nolock) " &
                                                            "WHERE trs.operacion_definida_global = od.operacion_definida_global " &
                                                                    "AND od.agencia = trs.agencia " &
                                                                    "AND od.agencia = " & cboAgencias.SelectedIndex & " " &
                                                                    "AND trs.tipo_reporte_swift not in (17,18)) " &
                            "AND fecha_operacion = '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' " &
                            "AND OP.producto_contratado = PC.producto_contratado " &
                            "AND trs.tipo_reporte_swift NOT IN (17,18) " &
                            "ORDER BY op.operacion"

                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                'dbGetRecord
                grdOperaciones.Rows.Clear()
                grdOperaciones.Columns.Clear()
                grdOperaciones.DataSource = Nothing
                grdOperaciones.Refresh()

                'Dim i As Double
                'If grdOperaciones.Rows.Count > 1 Then
                '    dblContador = grdOperaciones.Rows.Count
                '    'While grdOperaciones.Rows.Index <> 2
                '    '    grdOperaciones.RemoveItem(2)
                '    '    'Wend
                '    'End While
                '    'grdOperaciones.TextMatrix(0, 0) = ""
                '    'grdOperaciones.TextMatrix(0, 1) = ""
                '    'grdOperaciones.TextMatrix(0, 2) = ""
                '    'grdOperaciones.TextMatrix(0, 3) = ""
                '    'grdOperaciones.TextMatrix(0, 4) = ""
                '    'grdOperaciones.TextMatrix(0, 5) = ""
                'End If


                ''If dbError() = 0 Then
                ''grdOperaciones.ColWidth(0) = 1000
                ''grdOperaciones.ColWidth(2) = 2500
                ''grdOperaciones.ColWidth(3) = 1800
                ''grdOperaciones.ColWidth(4) = 1200
                ''grdOperaciones.ColWidth(5) = 1500
                ''grdOperaciones.TextMatrix(0, 0) = "No Reporte"
                ''grdOperaciones.TextMatrix(0, 1) = "Ticket"
                ''grdOperaciones.TextMatrix(0, 2) = "Operación"
                ''grdOperaciones.TextMatrix(0, 3) = "Fecha Captura"
                ''grdOperaciones.TextMatrix(0, 4) = "Monto"
                ''grdOperaciones.Columns(4).DefaultCellStyle.Alignment = 7
                ''grdOperaciones.TextMatrix(0, 5) = "Cuenta"
                ''End If

                'dblContador = 1

                'Do While dbError() = 0

                '    If dblContador <> 1 Then grdOperaciones.AddItem dblContador
                'grdOperaciones.TextMatrix(dblContador, 0) = dbGetValue(0)
                '    grdOperaciones.TextMatrix(dblContador, 1) = dbGetValue(1)
                '    grdOperaciones.TextMatrix(dblContador, 2) = dbGetValue(2)
                '    grdOperaciones.TextMatrix(dblContador, 3) = dbGetValue(3)
                '    grdOperaciones.TextMatrix(dblContador, 4) = Format(dbGetValue(4), "$###,###,###.00")
                '    grdOperaciones.TextMatrix(dblContador, 5) = dbGetValue(5)

                '    dblContador = dblContador + 1
                '    dbGetRecord
                'Loop
                'dbEndQuery

                'If dblContador - 1 > 0 Then
                If dtRespConsulta.Rows.Count > 0 Then
                    grdOperaciones.DataSource = dtRespConsulta
                    grdOperaciones.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    grdOperaciones.Columns(4).DefaultCellStyle.Format = "N2"
                    'grdOperaciones.Rows(0).Selected = True
                    grdOperaciones.Refresh()
                    cmdAceptar.Enabled = True
                    cmdImprimir.Enabled = True
                Else
                    cmdAceptar.Enabled = False
                    cmdImprimir.Enabled = False
                    MsgBox("No existen operaciones", vbOKOnly + vbInformation, "Reporte MT198")
                    cboAgencias.Focus()
                End If

                lblTotalOperaciones.Text = "Número de operaciones encontradas: " & dtRespConsulta.Rows.Count 'dblContador - 1
                lblTotalOperaciones.ForeColor = Color.White
                'grdOperaciones.RowSel = 0
                'grdOperaciones.ColAlignment(0) = Left
                'grdOperaciones.TextMatrix(0, 0)
            Else
                'MsgBox "Verifique la fecha. Día no laborable. ", vbOKOnly + vbInformation, "Reporte MT198"
                MsgBox("Es día feriado y no se permiten operaciones", vbOKOnly, "Día feriado")
                'dbEndQuery
                cmdAceptar.Enabled = False
                cmdImprimir.Enabled = False

                dtpFecha.Focus()
            End If
        End If
    End Function

End Class