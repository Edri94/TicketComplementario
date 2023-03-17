Imports System.Data.OleDb

Public Class modPermisos
    Private NumAplicacion As String
    Private objLibreria As New Libreria
    Private objDatasource As New Datasource
    Private gn_ProcessID As Integer
    Private gn_DBSwapNum As Integer  'Numero de referencia a archivo Swap MDB
    Private strFile As String
    Private existeArchivo As Boolean = False
    Public gc_Perfiles(0, 0) As String         'Arreglo para almacenar los perfiles del sistema
    Public ga_Perfiles(0, 0) As String         'Arreglo para almacenar el numero total de permisos y autorizaciones por perfil

    Dim dtRepReporte As DataTable = New DataTable()
    Dim dcRepColumna As DataColumn
    Dim drRepRegistro As DataRow
    Dim dvRepVista As DataView
    '--------------------------------------------------------------------------
    'Genera un reporte de los usuarios que tienen permiso sobre esta aplicacion
    '--------------------------------------------------------------------------
    Public Sub ImprimePermisos(Titulo As String, objReporte As ReportDocument, sNumApp As String)
        Dim objTipoUsuario As TipoUsuario
        Dim la_Buffer As New List(Of TipoUsuario)
        Dim ln_Accesos As String
        Dim ln_AccPerfil As String
        Dim ln_Indice As Integer
        Dim ln_Temp As Long
        Dim ln_SwapFile As Integer
        Dim ln_Error As Long
        Dim gn_Indice As Long
        Dim dtRespConsulta As DataTable
        Try
            NumAplicacion = sNumApp '--- "9" '"1,2" '----- RACB NumAp
            If gn_TotalPermisos = 0 Then
                MsgBox("No existen permisos para esta aplicación. No es posible generar un reporte.", vbInformation, "Permisos")
                Exit Sub
            End If
            If MsgBox("Se va a generar el reporte de Permisos por Usuario. ¿Desea Continuar?", vbYesNo + vbQuestion, "Permisos") = vbNo Then Exit Sub
            ProcessMessage("Leyendo base de datos...")
            gn_Indice = 0
            gs_Sql = "Select PF.nombre_perfil, "
            gs_Sql = gs_Sql & "US.usuario, "
            gs_Sql = gs_Sql & "US.nombre_usuario, "
            gs_Sql = gs_Sql & "US.login, "
            gs_Sql = gs_Sql & "PU.masc_permisos, "
            gs_Sql = gs_Sql & "PF.masc_permisos "
            gs_Sql = gs_Sql & "From "
            gs_Sql = gs_Sql & "CATALOGOS" & "..PERMISOS_X_USUARIO_HEXA PU, "
            gs_Sql = gs_Sql & "CATALOGOS" & ".." & "USUARIO" & " US, "
            gs_Sql = gs_Sql & "CATALOGOS" & "..PERFIL_HEXA PF "
            gs_Sql = gs_Sql & "Where "
            gs_Sql = gs_Sql & "PU.usuario = US.usuario and "
            gs_Sql = gs_Sql & "PU.perfil = PF.perfil and "
            gs_Sql = gs_Sql & "PF.aplicacion in (" & NumAplicacion & ") and "
            gs_Sql = gs_Sql & "US.password <> 'ANULADO' "
            gs_Sql = gs_Sql & "order by US.login"
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            If dtRespConsulta Is Nothing Or dtRespConsulta.Rows.Count <= 0 Then
                MsgBox("No se encontraron usuarios con Permisos sobre esta Aplicación.", vbInformation, "Aviso")
                Exit Sub
            Else
                For Each drRegistro As DataRow In dtRespConsulta.Rows
                    objTipoUsuario = New TipoUsuario()
                    objTipoUsuario.Perfil = StrConv(drRegistro.Item(0).ToString(), VbStrConv.ProperCase)
                    objTipoUsuario.Usuario = Val(drRegistro.Item(1))
                    objTipoUsuario.Nombre = StrConv(drRegistro.Item(2), VbStrConv.ProperCase)
                    objTipoUsuario.Login = Trim(drRegistro.Item(3))
                    objTipoUsuario.Accesos = drRegistro.Item(4)
                    objTipoUsuario.AccPerfil = drRegistro.Item(5)
                    objTipoUsuario.Marcacion = ""
                    la_Buffer.Add(objTipoUsuario)
                Next
            End If
            gn_Indice = la_Buffer.Count - 1
            ProcessMessage("Interpretando Permisos...")
            'Interpreta los datos que existen en el arreglo
            For ln_Temp = 0 To gn_Indice
                ln_Accesos = la_Buffer(ln_Temp).Accesos
                ln_AccPerfil = la_Buffer(ln_Temp).AccPerfil
                'Busca en todos los permisos existentes
                For ln_Indice = 0 To gn_TotalPermisos - 1
                    'El usuario tiene el permiso
                    If PermisosPorUsuario(ga_Permisos(ln_Indice).Nombre, ln_Accesos, ga_Permisos(ln_Indice).IDAplicacion) Then
                        'El perfil del usuario tiene el permiso
                        If PermisosPorUsuario(ga_Permisos(ln_Indice).Nombre, ln_AccPerfil, ga_Permisos(ln_Indice).IDAplicacion) Then
                            la_Buffer(ln_Temp).Marcacion = la_Buffer(ln_Temp).Marcacion & " " & Format(ln_Indice, "00")
                            'El perfil del usuario no tiene el permiso
                        Else
                            la_Buffer(ln_Temp).Marcacion = la_Buffer(ln_Temp).Marcacion & "+" & Format(ln_Indice, "00")
                        End If
                        'El usuario no tiene el permiso
                    Else
                        'El perfil del usuario tiene el permiso
                        If PermisosPorUsuario(ga_Permisos(ln_Indice).Nombre, ln_AccPerfil, ga_Permisos(ln_Indice).IDAplicacion) Then
                            la_Buffer(ln_Temp).Marcacion = la_Buffer(ln_Temp).Marcacion & " " & Format(ln_Indice, "00")
                            'El perfil del usuario no tiene el permiso
                        Else
                            la_Buffer(ln_Temp).Marcacion = la_Buffer(ln_Temp).Marcacion & "   "
                        End If
                    End If
                Next ln_Indice
            Next ln_Temp
            ProcessMessage("Generando reporte...")
            ln_SwapFile = DBCreateSwap(1)
            If ln_SwapFile = 0 Then
                ProcessMessage("")
                MsgBox("No es posible generar el reporte.", vbInformation, "Reporte")
                Exit Sub
            End If
            For ln_Temp = 0 To gn_Indice
                With la_Buffer(ln_Temp)
                    gs_Sql = "Select "
                    gs_Sql = gs_Sql & Trim(.Usuario) & ", "
                    gs_Sql = gs_Sql & "'" & Trim(.Login) & "', "
                    gs_Sql = gs_Sql & "'" & Trim(.Nombre) & "', "
                    gs_Sql = gs_Sql & "'" & Trim(.Perfil) & "', "
                    gs_Sql = gs_Sql & "'" & .Marcacion & "'"
                    ln_Error = DBSwapInsert(ln_SwapFile, gs_Sql, 5, 1)
                End With
            Next ln_Temp
            ProcessMessage("Agregando descripciones...")
            'Descripcion de permisos
            gs_Sql = "Select 10000,'','ZZZ','','', 1, '" & Space(200) & ".', 0, ''"
            ln_Error = DBSwapInsert(ln_SwapFile, gs_Sql, 9, 1)
            gs_Sql = "Select 10000,'','ZZZ','','', 2, '" & Space(200) & ".', 0, ''"
            ln_Error = DBSwapInsert(ln_SwapFile, gs_Sql, 9, 1)
            gs_Sql = "Select 10000,'','ZZZ','','', 3, '" & Space(200) & ".', 0, ''"
            ln_Error = DBSwapInsert(ln_SwapFile, gs_Sql, 9, 1)
            gs_Sql = "Select 10000,'','ZZZ','','', 4, 'Descripcion de Permisos', 0, ''"
            ln_Error = DBSwapInsert(ln_SwapFile, gs_Sql, 9, 1)
            gs_Sql = "Select 10000,'','ZZZ','','', 5, '" & "".PadRight(255, "_") & "', 0, ''"
            ln_Error = DBSwapInsert(ln_SwapFile, gs_Sql, 9, 1)
            gs_Sql = "Select 10000,'','ZZZ','','', 6, '" & Space(200) & ".', 0, ''"
            ln_Error = DBSwapInsert(ln_SwapFile, gs_Sql, 9, 1)
            For ln_Temp = 0 To gn_TotalPermisos - 1
                gs_Sql = "Select "
                gs_Sql = gs_Sql & "10000,'','ZZZ','','', "
                gs_Sql = gs_Sql & ln_Temp + 7 & ", "
                gs_Sql = gs_Sql & "'', "
                gs_Sql = gs_Sql & ln_Temp & ", "
                gs_Sql = gs_Sql & "': " & ga_Permisos(ln_Temp).Descripcion & "'"
                ln_Error = DBSwapInsert(ln_SwapFile, gs_Sql, 9, 1)
            Next ln_Temp
            ProcessMessage("Imprimiendo...")
            objReporte.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & gs_FechaHoy & "'"
            objReporte.DataDefinition.FormulaFields.Item("Hora").Text = "'" & gs_HoraSistema & "'"
            objReporte.DataDefinition.FormulaFields.Item("Aplicacion").Text = "'" & Trim(Titulo) & "'"
            objReporte.Database.Tables("Datos").SetDataSource(dtRepReporte)
            opcionReporte = 16
            RepOperativa.reporteOFAC = objReporte
            RepOperativa.ShowDialog()
            ProcessMessage("Reporte Correcto")
            Exit Sub
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbCritical, "Error")
            Err.Clear()
        End Try
    End Sub
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    'Devuelve el valor booleano correspondiente a un permiso de un usuario distinto al que firmo
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function PermisosPorUsuario(ByVal strNombrePer As String, ByVal strMascAccesos As String, Optional NumApp As String = "9") As Boolean
        Dim ln_Valor As Integer
        Dim ls_CadBin As String
        If strNombrePer <> Nothing Then
            NumAplicacion = NumApp

            DEFAULT_SRVR = objLibreria.SERVER
            PermisosPorUsuario = False

            ln_Valor = ValorPermiso(strNombrePer)

            If ln_Valor < 0 Then
                MsgBox("Error: Descripción o Nombre de Permiso Inexistente." & vbCrLf & DEFAULT_SRVR & " \ " & "CATALOGOS" & " \ " & strNombrePer, vbCritical + vbOKOnly, "Error")
                Exit Function
            Else
                ls_CadBin = Hex2Bin(strMascAccesos)
                If Mid(ls_CadBin, ln_Valor, 1) = "1" Then
                    PermisosPorUsuario = True
                End If
            End If

        End If
    End Function
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    ' Busca el permiso en el arreglo de permisos y devuelve su valor.
    ' Si no lo encuentra devuelve -1
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Function ValorPermiso(strNombrePer As String)
        Dim i As Integer
        ValorPermiso = -1
        For i = LBound(ga_Permisos) To UBound(ga_Permisos)
            If ga_Permisos(i).IDAplicacion = (NumAplicacion.Replace("(", "")).Replace(")", "") Then
                If Trim(ga_Permisos(i).Nombre) = Trim(strNombrePer) Then
                    ValorPermiso = ga_Permisos(i).Valor
                    Exit For
                End If
            End If
        Next
    End Function
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    ' Funcion que cambia de una cadena Hexdecimal a Binaria.
    ' Utilizada para la interpretación de los permisos.
    ' Agregada por CEB, esta funcion se encontraba en modHexBin (módulo eliminado).
    ' 08-02-2002
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function Hex2Bin(strHex As String) As String
        Dim strBin As String
        Dim i As Integer
        For i = 1 To Len(strHex)
            Select Case Mid(strHex, i, 1)
                Case "0" : strBin = strBin & "0000" '"0000"
                Case "1" : strBin = strBin & "1000" '"0001"
                Case "2" : strBin = strBin & "0100" '"0010"
                Case "3" : strBin = strBin & "1100" '"0011"
                Case "4" : strBin = strBin & "0010" '"0100"
                Case "5" : strBin = strBin & "1010" '"0101"
                Case "6" : strBin = strBin & "0110" '"0110"
                Case "7" : strBin = strBin & "1110" '"0111"
                Case "8" : strBin = strBin & "0001" '"1000"
                Case "9" : strBin = strBin & "1001" '"1001"
                Case "A" : strBin = strBin & "0101" '"1010"
                Case "B" : strBin = strBin & "1101" '"1011"
                Case "C" : strBin = strBin & "0011" '"1100"
                Case "D" : strBin = strBin & "1011" '"1101"
                Case "E" : strBin = strBin & "0111" '"1110"
                Case "F" : strBin = strBin & "1111" '"1111"
                Case Else
                    Err.Raise(13)
            End Select
        Next i
        Return strBin
    End Function
    Public Sub ProcessMessage(sMensaje As String)
        Dim AckTime As Integer, InfoBox As Object
        InfoBox = CreateObject("WScript.Shell")
        AckTime = 1
        Select Case InfoBox.Popup(sMensaje, AckTime, "Permisos...", 0)
            Case 1, -1
                Exit Sub
        End Select
    End Sub
    '--------------------------------------------------------
    'Crea una base de datos MDB en el directorio Temporal
    '--------------------------------------------------------
    Public Function DBCreateSwap(iArchivoCrear As Integer) As Integer
        Try
            Select Case iArchivoCrear
                Case 1
                    dcRepColumna = New DataColumn()
                    dcRepColumna.DataType = System.Type.GetType("System.Int32")
                    dcRepColumna.ColumnName = "ID"
                    dtRepReporte.Columns.Add(dcRepColumna)
                    dcRepColumna = New DataColumn()
                    dcRepColumna.DataType = Type.GetType("System.String")
                    dcRepColumna.ColumnName = "Login"
                    dtRepReporte.Columns.Add(dcRepColumna)
                    dcRepColumna = New DataColumn()
                    dcRepColumna.DataType = Type.GetType("System.String")
                    dcRepColumna.ColumnName = "Nombre"
                    dtRepReporte.Columns.Add(dcRepColumna)
                    dcRepColumna = New DataColumn()
                    dcRepColumna.DataType = Type.GetType("System.String")
                    dcRepColumna.ColumnName = "Perfil"
                    dtRepReporte.Columns.Add(dcRepColumna)
                    dcRepColumna = New DataColumn()
                    dcRepColumna.DataType = Type.GetType("System.String")
                    dcRepColumna.ColumnName = "Permisos"
                    dtRepReporte.Columns.Add(dcRepColumna)
                    dcRepColumna = New DataColumn()
                    dcRepColumna.DataType = Type.GetType("System.Int32")
                    dcRepColumna.ColumnName = "POrden"
                    dtRepReporte.Columns.Add(dcRepColumna)
                    dcRepColumna = New DataColumn()
                    dcRepColumna.DataType = Type.GetType("System.String")
                    dcRepColumna.ColumnName = "PTitulo"
                    dtRepReporte.Columns.Add(dcRepColumna)
                    dcRepColumna = New DataColumn()
                    dcRepColumna.DataType = Type.GetType("System.Int32")
                    dcRepColumna.ColumnName = "PValor"
                    dtRepReporte.Columns.Add(dcRepColumna)
                    dcRepColumna = New DataColumn()
                    dcRepColumna.DataType = Type.GetType("System.String")
                    dcRepColumna.ColumnName = "PDescripcion"
                    dtRepReporte.Columns.Add(dcRepColumna)
                Case 2
                    dcRepColumna = New DataColumn()
                    dcRepColumna.DataType = System.Type.GetType("System.String")
                    dcRepColumna.ColumnName = "UsLogin"
                    dtRepReporte.Columns.Add(dcRepColumna)
                    dcRepColumna = New DataColumn()
                    dcRepColumna.DataType = Type.GetType("System.String")
                    dcRepColumna.ColumnName = "UsNombre"
                    dtRepReporte.Columns.Add(dcRepColumna)
                    dcRepColumna = New DataColumn()
                    dcRepColumna.DataType = Type.GetType("System.String")
                    dcRepColumna.ColumnName = "Login"
                    dtRepReporte.Columns.Add(dcRepColumna)
                    dcRepColumna = New DataColumn()
                    dcRepColumna.DataType = Type.GetType("System.String")
                    dcRepColumna.ColumnName = "Nombre"
                    dtRepReporte.Columns.Add(dcRepColumna)
                    dcRepColumna = New DataColumn()
                    dcRepColumna.DataType = Type.GetType("System.String")
                    dcRepColumna.ColumnName = "Fecha"
                    dtRepReporte.Columns.Add(dcRepColumna)
                    dcRepColumna = New DataColumn()
                    dcRepColumna.DataType = Type.GetType("System.String")
                    dcRepColumna.ColumnName = "Permisos"
                    dtRepReporte.Columns.Add(dcRepColumna)
                    dcRepColumna = New DataColumn()
                    dcRepColumna.DataType = Type.GetType("System.Int32")
                    dcRepColumna.ColumnName = "POrden"
                    dtRepReporte.Columns.Add(dcRepColumna)
                    dcRepColumna = New DataColumn()
                    dcRepColumna.DataType = Type.GetType("System.String")
                    dcRepColumna.ColumnName = "PTitulo"
                    dtRepReporte.Columns.Add(dcRepColumna)
                    dcRepColumna = New DataColumn()
                    dcRepColumna.DataType = Type.GetType("System.Int32")
                    dcRepColumna.ColumnName = "PValor"
                    dtRepReporte.Columns.Add(dcRepColumna)
                    dcRepColumna = New DataColumn()
                    dcRepColumna.DataType = Type.GetType("System.String")
                    dcRepColumna.ColumnName = "PDescripcion"
                    dtRepReporte.Columns.Add(dcRepColumna)
            End Select
            gn_DBSwapNum = gn_DBSwapNum + 1
            Return gn_DBSwapNum
        Catch ex As Exception
            gn_DBSwapNum = gn_DBSwapNum - 1
            gn_DBSwapNum = 0
            Err.Clear()
            Return gn_DBSwapNum
        End Try
    End Function
    Public Function DBSwapInsert(SwapFile As Integer, Query As String, Columnas As Integer, iArchivoCrear As Integer, Optional ProgBar As Object = Nothing) As Long
        Dim result As String()
        Try
            Query = Query.Replace("""", "")
            Query = Query.Replace("'", "")
            result = Query.Replace("Select ", "").Split(",")
            Select Case iArchivoCrear
                Case 1
                    If Columnas = 5 Then
                        drRepRegistro = dtRepReporte.NewRow()
                        drRepRegistro("ID") = result(0)
                        drRepRegistro("Login") = result(1).ToString()
                        drRepRegistro("Nombre") = result(2).ToString()
                        drRepRegistro("Perfil") = result(3).ToString()
                        drRepRegistro("Permisos") = result(4).ToString()
                        dtRepReporte.Rows.Add(drRepRegistro)
                    ElseIf Columnas = 9 Then
                        drRepRegistro = dtRepReporte.NewRow()
                        drRepRegistro("ID") = result(0)
                        drRepRegistro("Login") = result(1).ToString()
                        drRepRegistro("Nombre") = result(2).ToString()
                        drRepRegistro("Perfil") = result(3).ToString()
                        drRepRegistro("Permisos") = result(4).ToString()
                        drRepRegistro("POrden") = result(5).ToString()
                        drRepRegistro("PTitulo") = result(6).ToString()
                        drRepRegistro("PValor") = result(7).ToString()
                        drRepRegistro("PDescripcion") = result(8).ToString()
                        dtRepReporte.Rows.Add(drRepRegistro)
                    End If
                Case 2
                    If Columnas = 6 Then
                        drRepRegistro = dtRepReporte.NewRow()
                        drRepRegistro("UsLogin") = result(0).ToString()
                        drRepRegistro("UsNombre") = result(1).ToString()
                        drRepRegistro("Login") = result(2).ToString()
                        drRepRegistro("Nombre") = result(3).ToString()
                        drRepRegistro("Fecha") = result(4).ToString()
                        drRepRegistro("Permisos") = result(5).ToString()
                        dtRepReporte.Rows.Add(drRepRegistro)
                    ElseIf Columnas = 10 Then
                        drRepRegistro = dtRepReporte.NewRow()
                        drRepRegistro("UsLogin") = result(0).ToString()
                        drRepRegistro("UsNombre") = result(1).ToString()
                        drRepRegistro("Login") = result(2).ToString()
                        drRepRegistro("Nombre") = result(3).ToString()
                        drRepRegistro("Fecha") = result(4).ToString()
                        drRepRegistro("Permisos") = result(5).ToString()
                        drRepRegistro("POrden") = result(6)
                        drRepRegistro("PTitulo") = result(7).ToString()
                        drRepRegistro("PValor") = result(8)
                        drRepRegistro("PDescripcion") = result(9).ToString()
                        dtRepReporte.Rows.Add(drRepRegistro)
                    End If
            End Select
            Return 0
        Catch ex As Exception
            Return 1
        End Try
    End Function
    Public Function DBSwapFile(Indice As Integer) As Boolean 'String
        Return existeArchivo
    End Function
    '---------------------------------------------------------------------------
    'Genera un reporte con los cambios efectuados a los permisos de los usuarios
    '---------------------------------------------------------------------------
    Public Sub ImprimeBitacora(Usuario As Integer, FechaInicia As String, FechaTermina As String, Titulo As String, objReporte As ReportDocument, Optional NumApp As String = "1")
        Dim objTipoBitacora As TipoBitacora
        Dim la_Buffer As New List(Of TipoBitacora)
        Dim objCursors As New Cursors
        Dim ln_Accesos As String
        Dim ln_Indice As Long
        Dim ln_Temp As Long
        Dim la_Meses() As Object
        Dim ln_SwapFile As Integer
        Dim ln_Error As Long
        Dim gn_Indice As Long
        Dim dtRespConsulta As DataTable
        NumAplicacion = NumApp '---- RACB 09/05/2022
        Try
            If MsgBox("Se va a generar el reporte de Bitacora de Cambios. ¿Desea Continuar?", vbYesNo + vbQuestion, "Bitacora") = vbNo Then Exit Sub
            la_Meses = New String() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"}
            ProcessMessage("Leyendo base de datos...")
            gn_Indice = 0
            gs_Sql = "Select US.usuario, "
            gs_Sql = gs_Sql & "US.nombre_usuario, "
            gs_Sql = gs_Sql & "US.login, "
            gs_Sql = gs_Sql & "USV.login, "
            gs_Sql = gs_Sql & "USV.nombre_usuario,"
            gs_Sql = gs_Sql & "convert(char(10),Bu.FECHA_MOVIMIENTO,105), "
            gs_Sql = gs_Sql & "convert(char(5),Bu.FECHA_MOVIMIENTO,8),"
            gs_Sql = gs_Sql & "COMENTARIO=case when bu.COMENTARIO='ALTA DE USUARIO' then bu.COMENTARIO "
            gs_Sql = gs_Sql & "when bu.COMENTARIO='ELIMINO USUARIO' then bu.COMENTARIO "
            gs_Sql = gs_Sql & "when bu.COMENTARIO='DESBLOQUEO DE USUARIO' then bu.COMENTARIO "
            gs_Sql = gs_Sql & "when bu.COMENTARIO='ACTIVACION DE USUARIO' then bu.COMENTARIO "
            gs_Sql = gs_Sql & "when bu.COMENTARIO='PERMISOS PARA USUARIO' then bu.COMENTARIO + ' (Perfil. '+ isnull(bu.Permisos,'') +') '"
            gs_Sql = gs_Sql & "when bu.COMENTARIO='MANTENIMIENTO A USUARIO' then bu.COMENTARIO + ' ('+ isnull(bu.Mantenimiento ,'')+') ' end "
            gs_Sql = gs_Sql & " From  CATALOGOS..BITACORA_USUARIO BU WITH (NOLOCK),"
            gs_Sql = gs_Sql & "CATALOGOS" & ".." & "USUARIO" & " US WITH (NOLOCK), "
            gs_Sql = gs_Sql & "CATALOGOS" & ".." & "USUARIO" & " USV  WITH (NOLOCK) "
            gs_Sql = gs_Sql & "Where BU.Usuario = US.Usuario And BU.usuario_valida = USV.Usuario "
            gs_Sql = gs_Sql & "and BU.aplicacion in (" & NumAplicacion & ") and " 'gs_Sql = gs_Sql & "and BU.aplicacion in (1,9) and " '------- RACB 08/09/2022
            gs_Sql = gs_Sql & "Bu.FECHA_MOVIMIENTO >= '" & Format(CDate(FechaInicia), "yyyy-MM-dd") & " 00:01AM' and "
            gs_Sql = gs_Sql & "Bu.FECHA_MOVIMIENTO <= '" & Format(CDate(FechaTermina), "yyyy-MM-dd") & " 11:59PM' "
            If Usuario <> 0 Then
                gs_Sql = gs_Sql & " and USV.usuario = " & Usuario
            End If
            gs_Sql = gs_Sql & " order by Bu.FECHA_MOVIMIENTO asc  "
            'dbExecQuery gs_Sql
            'dbGetRecord
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            'If dbError Then
            If dtRespConsulta Is Nothing Or dtRespConsulta.Rows.Count <= 0 Then
                'dbEndQuery
                'ProcessMessage("")
                MsgBox("No se encontraron Cambios de Permisos para Usuarios sobre esta Aplicación.", vbInformation, "Aviso")
                'ShowDefaultCursor
                Exit Sub
            Else
                For Each drRegistro As DataRow In dtRespConsulta.Rows
                    objTipoBitacora = New TipoBitacora()
                    objTipoBitacora.uUsuario = Val(drRegistro.Item(0))
                    objTipoBitacora.uNombre = Left(UCase(Trim(drRegistro.Item(1))), 30)
                    objTipoBitacora.uLogin = Trim(drRegistro.Item(2))
                    objTipoBitacora.uMarcacion = Trim(drRegistro.Item(7))
                    objTipoBitacora.uAccPerfil = 0 'Trim(drRegistro.Item(8))
                    objTipoBitacora.uAccesos = 0 'Trim(drRegistro.Item(9))
                    objTipoBitacora.Login = Trim(drRegistro.Item(3))
                    objTipoBitacora.Nombre = Left(UCase(Trim(drRegistro.Item(4))), 30)
                    objTipoBitacora.Fecha = objCursors.FechaY2K(drRegistro.Item(5)) & " " & Trim(drRegistro.Item(6))
                    la_Buffer.Add(objTipoBitacora)
                Next
            End If
            gn_Indice = la_Buffer.Count - 1
            For ln_Temp = 0 To gn_Indice
                ln_Accesos = la_Buffer(ln_Temp).uAccesos
                For ln_Indice = 0 To gn_TotalPermisos - 1
                    If PermisosPorUsuario(ga_Permisos(ln_Indice).Nombre, ln_Accesos, ga_Permisos(ln_Indice).IDAplicacion) Then
                        la_Buffer(ln_Temp).uMarcacion = la_Buffer(ln_Temp).uMarcacion & " " & Format(ln_Indice, "00")
                    Else
                        la_Buffer(ln_Temp).uMarcacion = la_Buffer(ln_Temp).uMarcacion & "   "
                    End If
                Next ln_Indice
            Next ln_Temp
            ProcessMessage("Generando reporte...")
            ln_SwapFile = DBCreateSwap(2)
            If ln_SwapFile = 0 Then
                ProcessMessage("")
                MsgBox("No es posible generar el reporte.", vbInformation, "Reporte")
                Exit Sub
            End If
            For ln_Temp = 0 To gn_Indice
                With la_Buffer(ln_Temp)
                    gs_Sql = "Select "
                    gs_Sql = gs_Sql & "'" & Trim(.uLogin) & "', "
                    gs_Sql = gs_Sql & "'" & Trim(.uNombre) & "', "
                    gs_Sql = gs_Sql & "'" & Trim(.Login) & "', "
                    gs_Sql = gs_Sql & "'" & Trim(.Nombre) & "', "
                    gs_Sql = gs_Sql & "'" & Trim(.Fecha) & "', "
                    gs_Sql = gs_Sql & "'" & .uMarcacion & "'"
                    ln_Error = DBSwapInsert(ln_SwapFile, gs_Sql, 6, 2)
                End With
            Next ln_Temp
            ProcessMessage("Agregando descripciones...")
            gs_Sql = "Select '','ZZZ','','','','', 1, '" & Space(200) & ".', 0, ''"
            ln_Error = DBSwapInsert(ln_SwapFile, gs_Sql, 10, 2)
            gs_Sql = "Select '','ZZZ','','','','', 2, '" & Space(200) & ".', 0, ''"
            ln_Error = DBSwapInsert(ln_SwapFile, gs_Sql, 10, 2)
            gs_Sql = "Select '','ZZZ','','','','', 3, '" & Space(200) & ".', 0, ''"
            ln_Error = DBSwapInsert(ln_SwapFile, gs_Sql, 10, 2)
            gs_Sql = "Select '','ZZZ','','','','', 4, 'Descripcion de Permisos', 0, ''"
            ln_Error = DBSwapInsert(ln_SwapFile, gs_Sql, 10, 2)
            gs_Sql = "Select '','ZZZ','','','','', 5, '" & "".PadRight(255, "_") & "', 0, ''"
            ln_Error = DBSwapInsert(ln_SwapFile, gs_Sql, 10, 2)
            gs_Sql = "Select '','ZZZ','','','','', 6, '" & Space(200) & ".', 0, ''"
            ln_Error = DBSwapInsert(ln_SwapFile, gs_Sql, 10, 2)
            For ln_Temp = 0 To gn_TotalPermisos - 1
                gs_Sql = "Select "
                gs_Sql = gs_Sql & "'','ZZZ','','','01-01-1990','', "
                gs_Sql = gs_Sql & ln_Temp + 7 & ", "
                gs_Sql = gs_Sql & "'', "
                gs_Sql = gs_Sql & ln_Temp & ", "
                gs_Sql = gs_Sql & "': " & ga_Permisos(ln_Temp).Descripcion & "'"
            Next ln_Temp
            ProcessMessage("Imprimiendo...")
            objReporte.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & gs_FechaHoy & "'"
            objReporte.DataDefinition.FormulaFields.Item("Hora").Text = "'" & gs_HoraSistema & "'"
            objReporte.DataDefinition.FormulaFields.Item("Aplicacion").Text = "'" & Trim(Titulo) & "'"
            objReporte.DataDefinition.FormulaFields.Item("Periodo").Text = "' Periodo: " & Format(CDate(FechaInicia), "dd-MM-yyyy") & " al " & Format(CDate(FechaTermina), "dd-MM-yyyy") & "'"
            objReporte.Database.Tables("Datos").SetDataSource(dtRepReporte)
            opcionReporte = 16
            RepOperativa.reporteOFAC = objReporte
            RepOperativa.ShowDialog()
            ProcessMessage("Reporte Correcto")
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub
    '--------------------------------------------------------------------------
    'Genera el reporte de usuarios que tienen permisos sobre esta aplicacion
    '--------------------------------------------------------------------------
    Public Sub GesImprimePermisos(Titulo As String, objReporte As ReportDocument)
        Dim objTipoUsuario As TipoUsuario
        Dim laBuffer As New List(Of TipoUsuario)
        Dim lnAccesos As String
        Dim lnAccPerfil As String
        Dim lnIndice As Integer
        Dim lnTemp As Long
        Dim lnSwapFile As Integer
        Dim lnError As Long
        Dim gnIndice As Long
        Dim gsSql As String
        Dim dtRespConsulta As DataTable
        Try
            If gn_TotalPermisos = 0 Then
                MsgBox("No existen permisos para esta aplicación. No es posible generar un reporte.", vbInformation, "Permisos")
                Exit Sub
            End If
            If MsgBox("Se va a generar el reporte de Permisos por Usuario. ¿Desea Continuar?", vbYesNo + vbQuestion, "Permisos") = vbNo Then
                Exit Sub
            End If
            'ShowWaitCursor
            ProcessMessage("Leyendo base de datos...")
            gnIndice = 0
            'ReDim laBuffer(0)
            gsSql = "Select PF.nombre_perfil, "
            gsSql = gsSql & "US.usuario, "
            gsSql = gsSql & "US.nombre_usuario, "
            gsSql = gsSql & "US.login, "
            gsSql = gsSql & "PU.masc_permisos, "
            gsSql = gsSql & "PF.masc_permisos "
            gsSql = gsSql & "From "
            gsSql = gsSql & "FUNCIONARIOS..PERMISOS_X_USUARIO_HEXA PU, "
            gsSql = gsSql & "FUNCIONARIOS..USUARIO" & " US, "
            gsSql = gsSql & "FUNCIONARIOS..PERFIL_HEXA PF "
            gsSql = gsSql & "Where "
            gsSql = gsSql & "PU.usuario = US.usuario and "
            gsSql = gsSql & "PU.perfil = PF.perfil and "
            gsSql = gsSql & "US.password <> 'ANULADO' "
            gsSql = gsSql & "order by US.login"
            dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
            If dtRespConsulta Is Nothing Or dtRespConsulta.Rows.Count <= 0 Then
                MsgBox("No se encontraron usuarios con Permisos sobre esta Aplicación.", vbInformation, "Aviso")
                Exit Sub
            Else
                For Each drRegistro As DataRow In dtRespConsulta.Rows
                    objTipoUsuario = New TipoUsuario()
                    objTipoUsuario.Perfil = StrConv(drRegistro.Item(0).ToString(), VbStrConv.ProperCase)
                    objTipoUsuario.Usuario = Val(drRegistro.Item(1))
                    objTipoUsuario.Nombre = StrConv(drRegistro.Item(2), VbStrConv.ProperCase)
                    objTipoUsuario.Login = Trim(drRegistro.Item(3))
                    objTipoUsuario.Accesos = drRegistro.Item(4)
                    objTipoUsuario.AccPerfil = drRegistro.Item(5)
                    objTipoUsuario.Marcacion = ""
                    laBuffer.Add(objTipoUsuario)
                Next
            End If
            gnIndice = laBuffer.Count - 1
            ProcessMessage("Interpretando Permisos...")
            'Interpreta los datos que existen en el arreglo
            For lnTemp = 0 To gnIndice
                lnAccesos = laBuffer(lnTemp).Accesos
                lnAccPerfil = laBuffer(lnTemp).AccPerfil
                'Busca en todos los permisos existentes
                For lnIndice = 0 To gn_TotalPermisos - 1
                    'El usuario tiene el permiso
                    If PermisosPorUsuario(ga_Permisos(lnIndice).Nombre, lnAccesos) Then
                        'El perfil del usuario tiene el permiso
                        If PermisosPorUsuario(ga_Permisos(lnIndice).Nombre, lnAccPerfil) Then
                            laBuffer(lnTemp).Marcacion = laBuffer(lnTemp).Marcacion & " " & Format(lnIndice, "00")
                            'El perfil del usuario no tiene el permiso
                        Else
                            laBuffer(lnTemp).Marcacion = laBuffer(lnTemp).Marcacion & "+" & Format(lnIndice, "00")
                        End If
                        'El usuario no tiene el permiso
                    Else
                        'El perfil del usuario tiene el permiso
                        If PermisosPorUsuario(ga_Permisos(lnIndice).Nombre, lnAccPerfil) Then
                            laBuffer(lnTemp).Marcacion = laBuffer(lnTemp).Marcacion & " " & Format(lnIndice, "00")
                            'El perfil del usuario no tiene el permiso
                        Else
                            laBuffer(lnTemp).Marcacion = laBuffer(lnTemp).Marcacion & "   "
                        End If
                    End If
                Next lnIndice
            Next lnTemp
            ProcessMessage("Generando reporte...")
            lnSwapFile = DBCreateSwap(1)

            If lnSwapFile = 0 Then
                'ShowWaitCursor
                MsgBox("No es posible generar el reporte.", vbInformation, "Reporte")
                Exit Sub
            End If
            For lnTemp = 0 To gnIndice
                With laBuffer(lnTemp)
                    gsSql = "Select "
                    gsSql = gsSql & Trim(.Usuario) & ", "
                    gsSql = gsSql & "'" & Trim(.Login) & "', "
                    gsSql = gsSql & "'" & Trim(.Nombre) & "', "
                    gsSql = gsSql & "'" & Trim(.Perfil) & "', "
                    gsSql = gsSql & "'" & .Marcacion & "'"
                    lnError = DBSwapInsert(lnSwapFile, gsSql, 5, 1)
                End With
            Next lnTemp
            ProcessMessage("Agregando descripciones...")
            'Descripcion de permisos
            gsSql = "Select 10000,'','ZZZ','','', 1, '" & Space(200) & ".', 0, ''"
            lnError = DBSwapInsert(lnSwapFile, gsSql, 9, 1)
            gsSql = "Select 10000,'','ZZZ','','', 2, '" & Space(200) & ".', 0, ''"
            lnError = DBSwapInsert(lnSwapFile, gsSql, 9, 1)
            gsSql = "Select 10000,'','ZZZ','','', 3, '" & Space(200) & ".', 0, ''"
            lnError = DBSwapInsert(lnSwapFile, gsSql, 9, 1)
            gsSql = "Select 10000,'','ZZZ','','', 4, 'Descripcion de Permisos', 0, ''"
            lnError = DBSwapInsert(lnSwapFile, gsSql, 9, 1)
            gsSql = "Select 10000,'','ZZZ','','', 5, '" & "".PadRight(255, "_") & "', 0, ''"
            lnError = DBSwapInsert(lnSwapFile, gsSql, 9, 1)
            gsSql = "Select 10000,'','ZZZ','','', 6, '" & Space(200) & ".', 0, ''"
            lnError = DBSwapInsert(lnSwapFile, gsSql, 9, 1)
            For lnTemp = 0 To gn_TotalPermisos - 1
                gsSql = "Select "
                gsSql = gsSql & "10000,'','ZZZ','','', "
                gsSql = gsSql & lnTemp + 7 & ", "
                gsSql = gsSql & "'', "
                gsSql = gsSql & lnTemp & ", "
                gsSql = gsSql & "': " & ga_Permisos(lnTemp).Descripcion & "'"
                lnError = DBSwapInsert(lnSwapFile, gsSql, 9, 1)
            Next lnTemp
            ProcessMessage("Imprimiendo...")
            objReporte.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & gs_FechaHoy & "'"
            objReporte.DataDefinition.FormulaFields.Item("Hora").Text = "'" & gs_HoraSistema & "'"
            objReporte.DataDefinition.FormulaFields.Item("Aplicacion").Text = "'" & Trim(Titulo) & "'"
            objReporte.Database.Tables("Datos").SetDataSource(dtRepReporte)
            opcionReporte = 16
            RepOperativa.reporteOFAC = objReporte
            RepOperativa.ShowDialog()
            ProcessMessage("Reporte Correcto")
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub
    'Elimina los 0's que sobran a la derecha de un binario o hexadecimal
    Public Function ZeroTrim(s As String) As String
        ZeroTrim = RTrimChar(s, "0")
    End Function
    '----------------------------------------------------
    'Originalmene estaba localizada en modStrings
    '----------------------------------------------------
    Public Function RTrimChar(ps_SourceString As String, ByVal ps_char As String) As String
        Dim i As Integer
        ps_char = Mid(ps_char, 1, 1)
        For i = Len(ps_SourceString) To 1 Step -1
            If Mid(ps_SourceString, i, 1) <> ps_char Then Exit For
        Next
        RTrimChar = Mid(ps_SourceString, 1, i)
    End Function
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    'Devuelve el valor booleano correspondiente a una autorizacion de un usuario distinto al que firmo
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function AutorizacionesPorUsuario(ByVal strNombreAut As String, ByVal strMascAutoriza As String, Optional NumApp As String = "1") As Boolean
        Dim ln_Valor As Integer
        NumAplicacion = NumApp
        AutorizacionesPorUsuario = False
        ln_Valor = ValorAutorizacion(strNombreAut)
        If ln_Valor < 0 Then
            MsgBox("Error: Descripción o Nombre de Autorización Inexistente." & vbCrLf & DEFAULT_SRVR & " \ " & "CATALOGOS" & " \ " & strNombreAut, vbCritical + vbOKOnly, "Error")
            Exit Function
        Else
            Dim ver = Mid(Hex2Bin(strMascAutoriza), ln_Valor, 1)
            If Mid(Hex2Bin(strMascAutoriza), ln_Valor, 1) = "1" Then
                AutorizacionesPorUsuario = True
            End If
        End If
    End Function
    'Busca la autorizacion en el arreglo de autorizaciones
    Function ValorAutorizacion(ByVal strNombreAut As String)
        Dim i As Integer
        ValorAutorizacion = -1
        If gn_TotalAutorizaciones > 0 Then
            strNombreAut = Trim(strNombreAut)
            For i = LBound(ga_Autorizaciones) To UBound(ga_Autorizaciones)
                If ga_Autorizaciones(i).IDAplicacion = (NumAplicacion.Replace("(", "")).Replace(")", "") Then
                    If Trim(ga_Autorizaciones(i).Nombre) = strNombreAut Then
                        ValorAutorizacion = ga_Autorizaciones(i).Valor
                        Exit For
                    End If
                End If
            Next
        End If
    End Function
End Class
