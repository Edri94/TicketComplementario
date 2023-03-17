Imports System.IO
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Threading

Public Class frmGeneraPrinterChq

    Private msLocalPath As String
    Private Ms_ABA1 As String
    Private Ms_ABA3 As String
    Private objLibreria As New Libreria
    Private objDatasource As New Datasource
    Private dtConfiguracionGurdada As New DataTable


    '----------------------------------------------------------------------
    'Elimina de la Cadena recibida los caracteres no deseables para Printer
    '----------------------------------------------------------------------
    Private Function DepuraCadena(Cadena As String) As String
        Dim lnCaracter As Integer
        Dim lsCadena As String

        Try
            lsCadena = ""
            For lnCaracter = 1 To Len(Cadena)
                If (Mid$(Cadena, lnCaracter, 1) = ".") Or (Mid$(Cadena, lnCaracter, 1) = ",") Then
                    lsCadena = lsCadena & " "
                Else
                    lsCadena = lsCadena & Mid$(Cadena, lnCaracter, 1)
                End If
            Next
            DepuraCadena = lsCadena
        Catch ex As Exception
            DepuraCadena = ""
        End Try
    End Function

    Private Sub EnviaReporte(ByVal sSelectionFormula As String, ByVal iTipo As Integer)
        Dim rptDoc As New ReportDocument
        Dim ArchControl As String
        Dim ArchPrograsa As String
        Dim lsAmbiente As String = ""
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""
        If iTipo = 0 Then
            ArchControl = "CHQ_ControlBANCOMER.pdf"
            ArchPrograsa = "CHQ_PrograsaBANCOMER.pdf"
        Else
            ArchControl = "CHQ_ControlBBVA.pdf"
            ArchPrograsa = "CHQ_PrograsaBBVA.pdf"
        End If
        pbrSolicitudes.Value = 2
        'rptDoc = New CHQ_Prograsa
        lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
        lsReporte = lsRutaFolder & "CHQ_Prograsa" & lsAmbiente & ".rpt"
        rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
        objLibreria.logonBDreporte(rptDoc, 1)
        rptDoc.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & Now().ToString("dd-MM-yyyy") & "'"
        rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Now().ToString("hh:mm") & "'"
        rptDoc.DataDefinition.FormulaFields.Item("Origen").Text = "'" & IIf(iTipo = 0, "BANCOMER", "BBVA") & "'"
        rptDoc.RecordSelectionFormula = sSelectionFormula
        'rptDoc.SetDatabaseLogon(objLibreria.Decrypt("qeOBHX/EztY="), objLibreria.Decrypt("qeOBHX/EztY="), objLibreria.Decrypt("fTfCwJ8K9qe67+hwukVAum7KXg3BSb3kKFPPq51rev8="), objLibreria.Decrypt("z1Rh9boc5VE="))
        pbrSolicitudes.Value = 3
        'rptDoc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, txtRutaHD.Text & "\" & ArchPrograsa)
        opcionReporte = 16
        RepOperativa.reporteOFAC = rptDoc
        RepOperativa.ShowDialog()
        pbrSolicitudes.Value = 4

        'rptDoc = New CHQ_Control
        lsReporte = lsRutaFolder & "CHQ_Control" & lsAmbiente & ".rpt"
        rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
        objLibreria.logonBDreporte(rptDoc, 1)
        rptDoc.Refresh()
        rptDoc.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & gs_FechaHoy & "'"
        rptDoc.DataDefinition.FormulaFields.Item("Hora").Text = "'" & gs_HoraSistema & "'"
        rptDoc.DataDefinition.FormulaFields.Item("Origen").Text = "'" & IIf(iTipo = 0, "BANCOMER", "BBVA") & "'"
        ''MARB
        ''Parametros para asignar ABA de agencia 1 y 3 al reporte
        rptDoc.DataDefinition.FormulaFields.Item("ABA_1").Text = "'" & Ms_ABA1 & "'"
        rptDoc.DataDefinition.FormulaFields.Item("ABA_3").Text = "'" & Ms_ABA3 & "'"
        rptDoc.RecordSelectionFormula = sSelectionFormula
        'rptDoc.SetDatabaseLogon(objLibreria.Decrypt("qeOBHX/EztY="), objLibreria.Decrypt("qeOBHX/EztY="), objLibreria.Decrypt("fTfCwJ8K9qe67+hwukVAum7KXg3BSb3kKFPPq51rev8="), objLibreria.Decrypt("z1Rh9boc5VE="))
        pbrSolicitudes.Value = 5
        'rptDoc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, txtRutaHD.Text & "\" & ArchControl)
        opcionReporte = 16
        RepOperativa.reporteOFAC = rptDoc
        RepOperativa.ShowDialog()
        pbrSolicitudes.Value = 6
        pbrSolicitudes.Visible = False
    End Sub
    Private Sub chkReimpresion_CheckedChanged(sender As Object, e As EventArgs) Handles chkReimpresion.CheckedChanged
        Dim dtRespConsulta As DataTable
        Dim drRegistro As DataRow
        If chkReimpresion.Checked = True Then
            dtpFechaIni.Enabled = True
            dtpFechaFin.Enabled = True
            'dbExecQuery("select convert(Char(10), fecha_sistema, 110) from PARAMETROS")
            'dbGetRecord
            'gs_FechaHoy = dbGetValue(0)
            'If Trim(txtFechaIni) = "" Then txtFechaIni = InvierteFecha(gs_FechaHoy)
            'If Trim(txtFechaFin) = "" Then dtpFechaIni.Value = InvierteFecha(gs_FechaHoy)
            'dtpFechaIni.Value = gs_FechaHoy
            'dtpFechaFin.Value = gs_FechaHoy
            If CDate(dtpFechaIni.Value) < CDate(dtpFechaFin.Value) Then dtpFechaIni.Value = dtpFechaFin.Value
            gs_Sql = "Select count(*) from "
            gs_Sql = gs_Sql & " CHEQUERAS where "
            gs_Sql = gs_Sql & " status_chequera = 3 and "
            gs_Sql = gs_Sql & " tipo_chequera <> 1 and "
            gs_Sql = gs_Sql & " fecha_envio >= '" & Format(dtpFechaIni.Value, "yyyy-MM-dd") & " 00:01' and "
            gs_Sql = gs_Sql & " fecha_envio < '" & Format(dtpFechaFin.Value, "yyyy-MM-dd") & " 23:59'"
            'dbExecQuery gs_Sql
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            If dtRespConsulta.Rows.Count <= 0 Then
                Exit Sub
            End If
            'dbGetRecord
            'lblPorEnviar = CStr(Val(dbGetValue(0))) & " "
            'dbEndQuery
            drRegistro = dtRespConsulta.Rows(0)
            txtPorEnviar.Text = drRegistro.Item(0)
            dtpFechaIni.Focus()
        Else
            dtpFechaIni.Enabled = False
            dtpFechaFin.Enabled = False
            'dtpFechaIni.Value = gs_FechaHoy
            'dtpFechaFin.Value = gs_FechaHoy
            gs_Sql = "Select count(*) "
            gs_Sql = gs_Sql & " from CHEQUERAS "
            gs_Sql = gs_Sql & " where status_chequera in (1,2)"
            gs_Sql = gs_Sql & " and tipo_chequera <> 1 "
            'dbExecQuery gs_Sql
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            If dtRespConsulta.Rows.Count <= 0 Then
                Exit Sub
            End If
            'dbGetRecord
            'lblPorEnviar = CStr(Val(dbGetValue(0))) & " "
            'dbEndQuery
            drRegistro = dtRespConsulta.Rows(0)
            txtPorEnviar.Text = drRegistro.Item(0)
        End If
    End Sub
    Private Sub btGenerar_Click(sender As Object, e As EventArgs) Handles btGenerar.Click
        'Generación de archivos DBF para el impresor de chequeras
        'MARB 14 Mar 2003
        'Cambio de constantes para obtenerlas en base a la agencia
        'Dim FILE1 As String * 7 = "DOLANGE"
        Dim FILE1 As String '= "DOLANGE"
        'Dim loDBFile As New rdoConnection
        Dim lsOrden As String = 0
        Dim lsDBQuery As String
        Dim LsFormula As String
        Dim lsFechaFin As String
        Dim lnErrores As Integer
        Dim lnConteo As Integer
        Dim lsPathLocal As String
        Dim lsPathTemp As String
        Dim lsPathChequera As String
        Dim iCount As Integer
        Dim sFile As String

        Dim dtRespConsulta As DataTable
        Dim drRegistro As DataRow
        Dim NumRegistros As Integer = 0
        Dim loDBFile As SqlConnection = Nothing
        Dim DBFConnection As OleDbConnection = New OleDbConnection()
        Dim DBFCommand As OleDbCommand = New OleDbCommand()
        Dim DBFCadena As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " & Path.GetTempPath() & "; Extended Properties = dBase IV" '; User ID =;Password ="

        'lsPathChequera = Trim$(dirFolder.Path)
        lsPathChequera = txtRutaHD.Text

        If Microsoft.VisualBasic.Right$(lsPathChequera, 1) <> "\" Then lsPathChequera = lsPathChequera & "\"

        If lsPathChequera = "" Then
            MsgBox("La ruta de generación es inválida, indique una carpeta existente.", vbInformation, "Ruta inválida")
            'dirFolder.SetFocus
            Exit Sub
        End If

        'lsPathLocal = GPATH & "\"
        'MsgBox(Path.GetTempPath())

        'MARB 14 Mar 2003
        'Adición de nombre de agencia
        'FILE1 = (objDatasource.ValorParametro("NOMARCHCHQ1").Rows(0).Item("valor").ToString).Trim(" ")
        FILE1 = "DOLHOUS"
        sFile = Dir(Path.GetTempPath() & "do*.dbf")
        Do While sFile <> ""
            Kill(Path.GetTempPath() & sFile)
            sFile = Dir(Path.GetTempPath() & "do*.dbf")
        Loop
        If Trim$(txtRutaHD.Text) = "" Then
            MsgBox("Es necesario indicar la ruta destino de los archivos a generar", vbInformation, "Dato faltante")
            txtRutaHD.Focus()
            Exit Sub
        End If
        If chkReimpresion.Checked = True Then
            If Trim$(dtpFechaIni.Text) = "" Then
                MsgBox("Es necesario indicar la fecha inicial del periodo.", vbInformation, "Dato faltante")
                dtpFechaIni.Focus()
                Exit Sub
            End If
            If Trim$(dtpFechaFin.Text) = "" Then
                MsgBox("Es necesario indicar la fecha final del periodo.", vbInformation, "Dato faltante")
                dtpFechaFin.Focus()
                Exit Sub
            End If
            If CDate(dtpFechaIni.Text) > CDate(dtpFechaFin.Text) Then
                MsgBox("La fecha inicial del periodo debe ser menor o igual que la fecha final.", vbInformation, "Fecha inválida")
                dtpFechaIni.Focus()
                Exit Sub
            End If
        End If

        On Error GoTo ErrorArchivo

        'No existe PRINTER.DBF   ENCRIPTADORNET\Resources\Documentos
        'If Dir$(lsPathLocal & "PRINTER.DBF") = "" Then
        '    MsgBox("No se encontro el archivo PRINTER.DBF en " & objLibreria.LowCaseName(lsPathLocal), vbCritical, "Archivo Faltante")
        '    Exit Sub
        'End If

        sFile = FILE1 & ".DBF"
        'Ya existe alguno de los archivos
        If Dir$(lsPathChequera & sFile) <> "" Then
            If MsgBox("El archivo " & sFile & " ya existe, ¿desea reemplazarlo?", vbQuestion + vbYesNo, "Archivo") = vbNo Then
                Exit Sub
            Else
                lnErrores = -1
                'Elimina el archivo del directorio de chequera
                Kill(lsPathChequera & sFile)
                If Dir(Path.GetTempPath() & sFile) <> "" Then
                    Kill(Path.GetTempPath() & sFile) 'Elimina DOLANGE del directorio temporal
                End If
            End If
        End If

        lnErrores = 0

        'FileCopy(lsPathLocal & "PRINTER.DBF", Path.GetTempPath() & sFile)  'Genera DOLANGE.DBF en directorio temporal
        File.WriteAllBytes(Path.GetTempPath() & sFile, My.Resources.PRINTER)

        'ShowWaitCursor

        On Error GoTo ErrorConeccion

        'Set loDBFile = rdoEnvironments(0).OpenConnection("CHEQUERA", rdDriverNoPrompt, False, "DSN=CHEQUERA;DBQ=" & lsPathChequera & ";DefaultDir=" & lsPathChequera & ";FIL=dBase III;MaxBufferSize=512;PageTimeout=600;")

        On Error GoTo 0

        lnConteo = 0
        lblSolicitudes.Text = "Registrando 0 solicitudes de " & txtPorEnviar.Text
        pbrSolicitudes.Maximum = CInt(txtPorEnviar.Text)
        pbrSolicitudes.Value = 0
        lblSolicitudes.Visible = True
        pbrSolicitudes.Visible = True

        objDatasource.IniciaTransaccion()
        'No es reimpresion
        If chkReimpresion.Checked = False Then
            'dbBeginTran
            'Obtiene la ultima orden generada
            'dbExecQuery("Select MAX(orden) from CHEQUERAS Where bbvab = 1")
            dtRespConsulta = objDatasource.RealizaConsulta("Select MAX(orden) from CHEQUERAS Where bbvab = 1")
            'dbGetRecord
            'If dbError() <> 0 Then
            If dtRespConsulta.Rows.Count = 0 Then
                'dbRollback
                'loDBFile.Close
                'ShowWaitCursor
                objDatasource.RollbackTransaccion()
                MsgBox("No es posible leer la base de datos.", vbCritical, "SQL Server Error")
                Exit Sub
            Else
                'Determina el nuevo numero de orden
                'lsOrden = CStr(Val(dbGetValue(0)) + 1)
                lsOrden = CStr(dtRespConsulta.Rows(0).Item(0) + 1)
            End If
            'dbEndQuery
            gs_Sql = "Update CHEQUERAS Set "
            gs_Sql = gs_Sql & "orden = " & lsOrden & ", "
            gs_Sql = gs_Sql & "fecha_envio = '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & " " & gs_HoraSistema & "', "
            gs_Sql = gs_Sql & "status_chequera = 3, "
            gs_Sql = gs_Sql & "usuario_envia = " & usuario
            gs_Sql = gs_Sql & " Where status_chequera In ( 1, 2 ) "
            gs_Sql = gs_Sql & "And tipo_chequera <> 1"
            'Actualiza las solicitudes por enviari
            'dbExecQuery gs_Sql
            NumRegistros = objDatasource.insertar(gs_Sql)
            If NumRegistros = 0 Then
                'dbRollback
                'loDBFile.Close
                'ShowWaitCursor
                objDatasource.RollbackTransaccion()
                MsgBox("No es posible actualizar la base de datos.", vbCritical, "SQL Server Error")
                Exit Sub
            End If
            'dbEndQuery
        End If

GeneraArchivos:
        'BAGO-EDS-10/MZO/06. Uso de IsNull en concatenación de cadenas
        gs_Sql = "Select "
        gs_Sql = gs_Sql & "UPPER(rtrim(CT.nombre_cliente)+' '+rtrim(IsNull(CT.apellido_paterno, Space(0)))+' '+rtrim(IsNull(apellido_materno, Space(0)))) AS NOM, "
        gs_Sql = gs_Sql & "AG.prefijo_agencia+'-'+PC.cuenta_cliente+'-'+TC.sufijo_kapiti AS CTAARA, "
        gs_Sql = gs_Sql & "PC.cuenta_cliente+'-'+TC.sufijo_kapiti+'/' AS CTAMAG, "
        gs_Sql = gs_Sql & "case AG.agencia when 1 then '&" & Ms_ABA1 & "&' else '' end AS TRANS, "
        gs_Sql = gs_Sql & "CH.ultimo_cheque AS FOLIO, "
        gs_Sql = gs_Sql & "CH.total_cheques AS CANT, "
        gs_Sql = gs_Sql & "CH.desc_cr_envio AS CREG, "
        gs_Sql = gs_Sql & "convert(int, CH.cr_envio) AS NCREG, "
        gs_Sql = gs_Sql & "CH.desc_plaza_envio AS PLA, "
        gs_Sql = gs_Sql & "CH.plaza_envio AS NPLA, "
        gs_Sql = gs_Sql & "CH.sucursal_envio AS SUC, "
        gs_Sql = gs_Sql & "CC.cve AS CVECH, "
        gs_Sql = gs_Sql & "AG.agencia AS NAGEN "
        gs_Sql = gs_Sql & "From "
        gs_Sql = gs_Sql & "vw_clavechequera CC, "
        gs_Sql = gs_Sql & "CHEQUERAS CH, "
        gs_Sql = gs_Sql & "CUENTA_EJE CE, "
        gs_Sql = gs_Sql & "TIPO_CUENTA_EJE TC, "
        gs_Sql = gs_Sql & "PRODUCTO_CONTRATADO PC, "
        gs_Sql = gs_Sql & "CATALOGOS..AGENCIA AG, "
        gs_Sql = gs_Sql & "CATALOGOS..CLIENTE CT "
        gs_Sql = gs_Sql & "Where "
        gs_Sql = gs_Sql & "PC.producto_contratado = CH.producto_contratado and "
        gs_Sql = gs_Sql & "CE.producto_contratado = CH.producto_contratado and "
        gs_Sql = gs_Sql & "CC.producto_contratado = CH.producto_contratado and "
        gs_Sql = gs_Sql & "CC.tipo_chequera = CH.tipo_chequera and "
        gs_Sql = gs_Sql & "AG.agencia = PC.agencia and "
        gs_Sql = gs_Sql & "CT.agencia = PC.agencia and "
        gs_Sql = gs_Sql & "CT.cuenta_cliente = PC.cuenta_cliente and "
        gs_Sql = gs_Sql & "TC.tipo_cuenta_eje = CE.tipo_cuenta_eje and "
        gs_Sql = gs_Sql & "CH.status_chequera = 3 and "
        gs_Sql = gs_Sql & "CH.tipo_chequera <> 1 and "
        'Si es reimpresion considera fechas
        If chkReimpresion.Checked = True Then
            gs_Sql = gs_Sql & "CH.fecha_envio >= '" & Format(dtpFechaIni.Value.Date, "yyyy-MM-dd") & " 00:01' and "
            gs_Sql = gs_Sql & "CH.fecha_envio <= '" & Format(dtpFechaFin.Value.Date, "yyyy-MM-dd") & " 23:59'"
            'Si es generación considera la orden
        Else
            gs_Sql = gs_Sql & "CH.orden = " & lsOrden
        End If
        gs_Sql = gs_Sql & " And CH.bbvab = 1" ' & iCount
        gs_Sql = gs_Sql & " Order by convert(int, CH.plaza_envio), AG.agencia, CH.chequera"
        'Obtiene los datos por enviar
        'dbExecQuery gs_Sql
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbGetRecord
        Dim dtRespuestaReporte = dtRespConsulta.Copy()
        DBFConnection.ConnectionString = DBFCadena
        DBFConnection.Open()
        DBFCommand.Connection = DBFConnection
        'On Error GoTo ErrorODBC
        NumRegistros = 0
        Do While NumRegistros <> dtRespConsulta.Rows.Count
            If Val(dtRespConsulta.Rows(0).Item(12)) = 1 Then
                lsDBQuery = "Insert into " & Path.GetTempPath() & sFile
                lsDBQuery = lsDBQuery & " values ("
                'lsDBQuery = lsDBQuery & "'" & DepuraCadena(ChecaTexto(dbGetValue(0), 40)) & "', "         'NOM
                lsDBQuery = lsDBQuery & "'" & DepuraCadena(objLibreria.ChecaTexto(Microsoft.VisualBasic.Left(dtRespConsulta.Rows(NumRegistros).Item(0), 40))) & "', "         'NOM
                lsDBQuery = lsDBQuery & "'" & objLibreria.ChecaTexto(dtRespConsulta.Rows(NumRegistros).Item(1)) & "', "                           'CTAARA
                lsDBQuery = lsDBQuery & "'" & objLibreria.ChecaTexto(dtRespConsulta.Rows(NumRegistros).Item(2)) & "', "                           'CTAMAG
                lsDBQuery = lsDBQuery & "'" & objLibreria.ChecaTexto(dtRespConsulta.Rows(NumRegistros).Item(3)) & "', "                           'TRANS
                lsDBQuery = lsDBQuery & "'" & objLibreria.ChecaTexto(dtRespConsulta.Rows(NumRegistros).Item(4)) & "', "                           'FOLIO
                'lsDBQuery = lsDBQuery & "'" & Format(objLibreria.ChecaTexto(dtRespConsulta.Rows(NumRegistros).Item(5)), "000") & "', "            'CANT
                lsDBQuery = lsDBQuery & "'" & (objLibreria.ChecaTexto(Microsoft.VisualBasic.Right(dtRespConsulta.Rows(NumRegistros).Item(5), 3))).PadLeft(3, "0") & "', "            'CANT
                'lsDBQuery = lsDBQuery & "'" & DepuraCadena(ChecaTexto(UCase(dbGetValue(6)), 20)) & "', "  'CREG
                lsDBQuery = lsDBQuery & "'" & DepuraCadena(objLibreria.ChecaTexto(UCase(Microsoft.VisualBasic.Left(dtRespConsulta.Rows(NumRegistros).Item(6), 20)))) & "', "  'CREG
                'lsDBQuery = lsDBQuery & "'" & Format(objLibreria.ChecaTexto(dtRespConsulta.Rows(NumRegistros).Item(7)), "00") & "', "             'NCREG
                lsDBQuery = lsDBQuery & "'" & (objLibreria.ChecaTexto(dtRespConsulta.Rows(NumRegistros).Item(7))).PadLeft(2, "0") & "', "             'NCREG
                'lsDBQuery = lsDBQuery & "'" & DepuraCadena(ChecaTexto(UCase(dbGetValue(8)), 20)) & "', "  'PLA
                lsDBQuery = lsDBQuery & "'" & DepuraCadena(objLibreria.ChecaTexto(UCase(Microsoft.VisualBasic.Left(dtRespConsulta.Rows(NumRegistros).Item(8), 20)))) & "', "  'PLA
                'lsDBQuery = lsDBQuery & "'" & Format(objLibreria.ChecaTexto(dtRespConsulta.Rows(NumRegistros).Item(9)), "000") & "', "            'NPLA
                'lsDBQuery = lsDBQuery & "'" & Format(Microsoft.VisualBasic.Right(dtRespConsulta.Rows(NumRegistros).Item(10), 4), "0000") & "', "             'SUC
                lsDBQuery = lsDBQuery & "'" & (objLibreria.ChecaTexto(Microsoft.VisualBasic.Right(dtRespConsulta.Rows(NumRegistros).Item(9), 3))).PadLeft(3, "0") & "', "            'NPLA
                lsDBQuery = lsDBQuery & "'" & (objLibreria.ChecaTexto(Microsoft.VisualBasic.Right(dtRespConsulta.Rows(NumRegistros).Item(10), 4))).PadLeft(4, "0") & "', "             'SUC
                lsDBQuery = lsDBQuery & "'" & objLibreria.ChecaTexto(dtRespConsulta.Rows(NumRegistros).Item(11)) & "'"                            'CVECH
                lsDBQuery = lsDBQuery & ")"
                'loDBFile.Execute lsDBQuery
                DBFCommand.CommandText = lsDBQuery
                'DBFCommand.ExecuteNonQuery()
                'If loDBFile.RowsAffected < 1 Then
                If DBFCommand.ExecuteNonQuery() < 1 Then
                    lnErrores = lnErrores + 1
                End If
                lnConteo = lnConteo + 1
                pbrSolicitudes.Value = lnConteo
                lblSolicitudes.Text = "Registrando " & lnConteo & " solicitudes de " & txtPorEnviar.Text
                lblSolicitudes.Refresh()
                NumRegistros = lnConteo
                'dbGetRecord
            End If
        Loop

        'dbEndQuery

        'If chkReimpresion.Checked = 0 Then dbCommit
        If chkReimpresion.Checked = False Then objDatasource.CommitTransaccion()

        'Hubo errores de generación
        If lnErrores > 0 Then
            If MsgBox("Ocurrieron " & lnErrores & " al general los archivos, ¿Desea reintentar?", vbQuestion + vbYesNo, "Error de Archivo") = vbYes Then
                'Regenera los archivos de datos
                FileCopy(lsPathLocal & "PRINTER.DBF", Path.GetTempPath() & sFile)
                '            FileCopy lsPathLocal & "PRINTER.DBF", GetTempDir & FILE1 & "2.DBF"
                lnConteo = 0
                GoTo GeneraArchivos
            End If
        End If
        'Cierra conexión y copia archivos a directorio de chequeras
        'loDBFile.Close
        DBFConnection.Close()

        FileCopy(Path.GetTempPath() & sFile, lsPathChequera & sFile)
        If Dir(Path.GetTempPath() & sFile) <> "" Then Kill(Path.GetTempPath() & sFile)
        'Set loDBFile = Nothing

        If chkReimpresion.Checked = False Then
            gs_Sql = "Select count(*) from CHEQUERAS where status_chequera in (1,2) and tipo_chequera <> 1"
            'dbExecQuery gs_Sql
            dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
            'dbGetRecord
            'lblPorEnviar = CStr(Val(dbGetValue(0))) & " "
            drRegistro = dtRespConsulta.Rows(0)
            txtPorEnviar.Text = drRegistro.Item(0)
            'dbEndQuery
        End If

        'ShowDefaultCursor

        If MsgBox("¿Desea imprimir los reportes de la orden generada?", vbQuestion + vbYesNo, "Impresión...") = vbYes Then
            lblSolicitudes.Text = "Generando archivos…"
            pbrSolicitudes.Maximum = 6
            pbrSolicitudes.Value = 0
            LsFormula = "{CHEQUERAS.status_chequera} = 3 and "
            'Si es reimpresion considera fechas
            If chkReimpresion.Checked = True Then
                'lsFechaFin = FechaY2K(DateAdd("d", 1, txtFechaFin.text))
                lsFechaFin = dtpFechaFin.Text
                LsFormula = LsFormula & "{CHEQUERAS.fecha_envio} >= Date(" & dtpFechaIni.Value.Date.Year & ", "
                LsFormula = LsFormula & dtpFechaIni.Value.Date.Month & ", "
                LsFormula = LsFormula & dtpFechaIni.Value.Date.Day & ") and "
                LsFormula = LsFormula & "{CHEQUERAS.fecha_envio} <= Date(" & dtpFechaFin.Value.Date.Year & ", "
                LsFormula = LsFormula & dtpFechaFin.Value.Date.Month & ", "
                LsFormula = LsFormula & dtpFechaFin.Value.Date.Day & ")"
                'Si es generación considera la orden
            Else
                LsFormula = LsFormula & "{CHEQUERAS.orden} = " & lsOrden
            End If
            '        EnviaReporte LsFormula, 0
            pbrSolicitudes.Value = 1
            EnviaReporte(LsFormula, 1)
        End If
        MsgBox("Los archivos se generaron en la ruta indicada de forma correcta")
        'Set loDBFile = Nothing

        lblSolicitudes.Text = "Registrando 0 solicitudes de " & 0
        pbrSolicitudes.Value = 0
        MsgBox("El proceso concluyo de forma correcta")

        Exit Sub

ErrorODBC:
        'ShowDefaultCursor
        'dbRollback
        'dbEndQuery
        objDatasource.RollbackTransaccion()
        MsgBox("Error: " & Err.Description, vbCritical, "Error de ODBC")

        On Error Resume Next

        'loDBFile.Close

        'Set loDBFile = Nothing

        Exit Sub

ErrorArchivo:
        'ShowDefaultCursor

        'Error de Path o Acceso
        If Err().Number = 75 Then
            'Error al borrar archivo DOLANGE
            If lnErrores = -1 Then
                MsgBox("Verifique que no se ecuentre abierto el archivo " & lsPathChequera & sFile, vbCritical, "Error de Acceso")
            End If
        Else
            MsgBox("Error: " & Err.Description, vbCritical, "Error de Archivo")
        End If

        Exit Sub

ErrorConeccion:
        'ShowDefaultCursor

        MsgBox("Error: " & Err.Description, vbCritical, "Error de Conexión")
        MsgBox("Asegurese de tener instalado el ODBC 'CHEQUERA' de tipo DBase III o superior.", vbInformation, "Configuración de ODBC")

        Exit Sub
    End Sub

    Private Sub frmGeneraPrinterChq_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        'ControlBox = False
        FormBorderStyle = FormBorderStyle.FixedSingle
        Dim dtRespConsulta As DataTable
        Dim drRegistro As DataRow
        'CargarColores Me, cambio
        'Centerform Me
        'btPrint.Enabled = False
        'btGenerar.Enabled = False
        txtFecha.Text = gs_FechaHoy
        If Thread.CurrentThread.CurrentCulture.Name = "en-US" Then
            dtpFechaIni.CustomFormat = "MM-dd-yyyy"
            dtpFechaFin.CustomFormat = "MM-dd-yyyy"
        ElseIf Thread.CurrentThread.CurrentCulture.Name = "es-MX" Then
            dtpFechaIni.CustomFormat = "dd-MM-yyyy"
            dtpFechaFin.CustomFormat = "dd-MM-yyyy"
        End If
        'Busca las Chequeras Normales que se encuentran pendientes
        gs_Sql = "Select count(*) from CHEQUERAS "
        gs_Sql = gs_Sql & " where status_chequera in (1,2)"
        gs_Sql = gs_Sql & " and tipo_chequera <> 1"
        'dbExecQuery gs_Sql
        dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
        'dbGetRecord
        'lblPorEnviar = CStr(Val(dbGetValue(0))) & " "
        'dbEndQuery
        drRegistro = dtRespConsulta.Rows(0)
        txtPorEnviar.Text = drRegistro.Item(0)
        msLocalPath = GetSetting("Middle", "PATHS", "CHEQUERA", "C:\CHEQUERA")
        'If Dir(msLocalPath, vbDirectory) = "" Then
        '    dirFolder.Path = "C:\"
        '    drvDrive.Drive = "C:"
        'Else
        '    drvDrive.Drive = Left(msLocalPath, 2)
        '    dirFolder.Path = msLocalPath
        'End If
        'MARB
        Ms_ABA1 = objDatasource.ValorParametro("BCOBENEFD1").Rows(0).Item("valor").ToString
        If InStr(1, Ms_ABA1, ",") Then
            Ms_ABA1 = Microsoft.VisualBasic.Left(Ms_ABA1, InStr(1, Ms_ABA1, ",") - 1)
            If InStr(1, Ms_ABA1, "/") Then
                Ms_ABA1 = Trim(Mid(Ms_ABA1, InStr(1, Ms_ABA1, "/") + 1))
            End If
        End If
        Ms_ABA3 = objDatasource.ValorParametro("BCOBENEFD3").Rows(0).Item("valor").ToString
        If InStr(1, Ms_ABA3, ",") Then
            Ms_ABA3 = Microsoft.VisualBasic.Left(Ms_ABA3, InStr(1, Ms_ABA3, ",") - 1)
            If InStr(1, Ms_ABA3, "/") Then
                Ms_ABA3 = Trim(Mid(Ms_ABA3, InStr(1, Ms_ABA3, "/") + 1))
            End If
        End If
        '--------------- Guarda ultima configuracion (Ruta)
        If Dir$(My.Computer.FileSystem.CurrentDirectory & "\Configuraciones.mdb") = "" Then
            File.WriteAllBytes(My.Computer.FileSystem.CurrentDirectory & "\Configuraciones.mdb", My.Resources.Configuraciones)
        End If
        ConfiguracionGuardaConsulta(1)
        If dtConfiguracionGurdada IsNot Nothing And dtConfiguracionGurdada.Rows.Count > 0 Then
            txtRutaHD.Text = dtConfiguracionGurdada.Rows(0).Item(3)
        End If
        '--------------- Guarda ultima configuracion (Ruta)
    End Sub

    Private Sub btPrint_Click(sender As Object, e As EventArgs) Handles btPrint.Click
        Dim LsFormula As String
        Dim lsFechaFin As String

        If chkReimpresion.Checked = True Then
            If Trim$(dtpFechaIni.Text) = "" Then
                MsgBox("Es necesario indicar la fecha inicial del período.", vbInformation, "Dato faltante")
                dtpFechaIni.Focus()
                Exit Sub
            End If
            If Trim$(dtpFechaFin.Text) = "" Then
                MsgBox("Es necesario indicar la fecha final del período.", vbInformation, "Dato faltante")
                dtpFechaFin.Focus()
                Exit Sub
            End If
            If CDate(dtpFechaIni.Text) > CDate(dtpFechaFin.Text) Then
                MsgBox("La fecha inicial del período debe ser menor o igual que la fecha final.", vbInformation, "Fecha inválida")
                dtpFechaIni.Focus()
                Exit Sub
            End If
        End If

        'Solo Chequeras Normales
        LsFormula = "{CHEQUERAS.status_chequera} = 3 and {CHEQUERAS.tipo_chequera} <> 1 "

        'Si es reimpresion considera fechas de reimpresion
        If chkReimpresion.Checked = True Then
            'lsFechaFin = FechaY2K(DateAdd("d", 1, txtFechaFin.text))
            LsFormula = LsFormula & "And {CHEQUERAS.fecha_envio} >= Date ( " & dtpFechaIni.Value.Date.Year & ", "
            LsFormula = LsFormula & dtpFechaIni.Value.Date.Month & ", "
            LsFormula = LsFormula & dtpFechaIni.Value.Date.Day & " ) and "
            LsFormula = LsFormula & "{CHEQUERAS.fecha_envio} <= Date ( " & dtpFechaFin.Value.Date.Year & ", "
            LsFormula = LsFormula & dtpFechaFin.Value.Date.Month & ", "
            LsFormula = LsFormula & dtpFechaFin.Value.Date.Day & " )"
            'Si es generación considera la fecha del día
        Else
            LsFormula = LsFormula & "And {CHEQUERAS.fecha_envio} >= Date ( " & CDate(gs_FechaHoy).Year & ", "
            LsFormula = LsFormula & CDate(gs_FechaHoy).Month & ", "
            LsFormula = LsFormula & CDate(gs_FechaHoy).Day & " )"
        End If

		pbrSolicitudes.Maximum = 6
        pbrSolicitudes.Value = 0
		pbrSolicitudes.Value = 1
        'Reporte para sucursales Bancomer
        EnviaReporte(LsFormula, 0)
		pbrSolicitudes.Value = 0
		pbrSolicitudes.Value = 1
        'Reporte para sucursales BBVA
        EnviaReporte(LsFormula, 1)
        MsgBox("Los archivos se generaron en la ruta indicada de forma correcta")
        MsgBox("El proceso concluyo de forma correcta")
		pbrSolicitudes.Value = 0
    End Sub

    Private Sub lblPorEnviar_TextChanged(sender As Object, e As EventArgs) Handles txtPorEnviar.TextChanged
        If Val(txtPorEnviar.Text) = 0 Then
            btGenerar.Enabled = False
            btPrint.Enabled = False
        Else
            btGenerar.Enabled = True
            btPrint.Enabled = True
        End If
    End Sub
    Private Sub btSalir_Click(sender As Object, e As EventArgs) Handles btSalir.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir de Generación de Archivo") <> vbYes Then Exit Sub
        Me.Close()
    End Sub
    Private Sub dtpFechaIni_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaIni.ValueChanged
        Dim dtRespConsulta As DataTable
        Dim drRegistro As DataRow
        'La fecha de inicio es correcta
        'If objLibreria.ValidaFecha(dtpFechaIni, "") Then
        'Si existe fecha fin
        If Trim(dtpFechaFin.Value) <> "" And CDate(dtpFechaFin.Value) >= CDate(dtpFechaIni.Value) Then
            'If objLibreria.ValidaFecha(dtpFechaFin, "") Then
            'Fecha fin es menor que fecha inicio
            If CDate(dtpFechaFin.Value) < CDate(dtpFechaIni.Value) Then
                gs_Sql = "Select count(*) from "
                gs_Sql = gs_Sql & "CHEQUERAS where "
                gs_Sql = gs_Sql & "status_chequera = 3 and "
                gs_Sql = gs_Sql & "fecha_envio >= '" & Format(dtpFechaIni.Value, "yyyy-MM-dd") & " 00:01' and "
                gs_Sql = gs_Sql & "fecha_envio < '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & " 23:59'"
                'Fecha fin es mayor o igual que fecha inicio
            Else
                gs_Sql = "Select count(*) from "
                gs_Sql = gs_Sql & "CHEQUERAS where "
                gs_Sql = gs_Sql & "status_chequera = 3 and "
                gs_Sql = gs_Sql & "fecha_envio >= '" & Format(dtpFechaIni.Value, "yyyy-MM-dd") & " 00:01' and "
                gs_Sql = gs_Sql & "fecha_envio < '" & Format(dtpFechaFin.Value, "yyyy-MM-dd") & " 23:59'"
            End If
            'Busca solicitudes por reenviar
            '    dbExecQuery gs_Sql
            '    dbGetRecord
            If (gs_Sql <> "") Then
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                '    lblPorEnviar = CStr(Val(dbGetValue(0))) & " "
                '    dbEndQuery
                If (dtRespConsulta IsNot Nothing) Then
                    drRegistro = dtRespConsulta.Rows(0)
                    txtPorEnviar.Text = drRegistro.Item(0)
                End If
            End If
        End If
        'End If
        'End If
    End Sub
    Private Sub dtpFechaFin_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFin.ValueChanged
        Dim dtRespConsulta As DataTable
        Dim drRegistro As DataRow
        'La fecha fin es correcta
        'If objLibreria.ValidaFecha(dtpFechaFin, "") Then
        'Si existe fecha inicio
        If Trim(dtpFechaIni.Value) <> "" And CDate(dtpFechaFin.Value) >= CDate(dtpFechaIni.Value) Then
            'If objLibreria.ValidaFecha(dtpFechaIni, "") Then
            'Fecha fin es menor que fecha inicio
            If CDate(dtpFechaFin.Value) < CDate(dtpFechaIni.Value) Then
                gs_Sql = "Select count(*) from "
                gs_Sql = gs_Sql & "CHEQUERAS where "
                gs_Sql = gs_Sql & "status_chequera = 3 and "
                gs_Sql = gs_Sql & "fecha_envio >= '" & Format(dtpFechaIni.Value, "yyyy-MM-dd") & " 00:01' and "
                gs_Sql = gs_Sql & "fecha_envio < '" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & " 23:59'"
                'Fecha fin es mayor o igual que fecha inicio
            Else
                gs_Sql = "Select count(*) from "
                gs_Sql = gs_Sql & "CHEQUERAS where "
                gs_Sql = gs_Sql & "status_chequera = 3 and "
                gs_Sql = gs_Sql & "fecha_envio >= '" & Format(dtpFechaIni.Value, "yyyy-MM-dd") & " 00:01' and "
                gs_Sql = gs_Sql & "fecha_envio < '" & Format(dtpFechaFin.Value, "yyyy-MM-dd") & " 23:59'"
            End If
            'Busca solicitudes por reenviar
            '    dbExecQuery gs_Sql
            '    dbGetRecord
            If (gs_Sql <> "") Then
                dtRespConsulta = objDatasource.RealizaConsulta(gs_Sql)
                '    lblPorEnviar = CStr(Val(dbGetValue(0))) & " "
                '    dbEndQuery
                If (dtRespConsulta IsNot Nothing) Then
                    drRegistro = dtRespConsulta.Rows(0)
                    txtPorEnviar.Text = drRegistro.Item(0)
                End If
            End If
        End If
        'End If
    End Sub
    Private Sub txtPorEnviar_ValueChanged()

        If Val(txtPorEnviar) = 0 Then
            btGenerar.Enabled = False
            btPrint.Enabled = False
        Else
            btGenerar.Enabled = True
            btPrint.Enabled = True
        End If
    End Sub
    Private Sub btExaminar_Click(sender As Object, e As EventArgs) Handles btExaminar.Click
        fbdExplorarCarpetas.Description() = "Seleccione la carpeta en la que se desea guardar el archivo."
        If (fbdExplorarCarpetas.ShowDialog() = DialogResult.OK) Then
            txtRutaHD.Text = fbdExplorarCarpetas.SelectedPath
        End If
        ConfiguracionGuardaConsulta(1)
        If dtConfiguracionGurdada IsNot Nothing And dtConfiguracionGurdada.Rows.Count <= 0 Then
            ConfiguracionGuardaConsulta(2)
        ElseIf dtConfiguracionGurdada.Rows.Count > 0 Then
            ConfiguracionGuardaConsulta(3)
        End If
    End Sub
    Private Sub ConfiguracionGuardaConsulta(Opcion As Integer)
        Dim oledbConectar As New OleDbConnection
        Dim oledbQueryConsulta As New OleDbDataAdapter
        Dim oledbQuery As New OleDbCommand
        Dim dsRespuesta As New DataSet
        oledbConectar.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Computer.FileSystem.CurrentDirectory & "\Configuraciones.mdb"
        oledbConectar.Open()
        Select Case Opcion
            Case 1 'Consultar
                oledbQueryConsulta = New OleDbDataAdapter("SELECT * FROM ConfiguracionGuardad WHERE Usuario = " & usuario, oledbConectar)
                oledbQueryConsulta.Fill(dsRespuesta)
                dtConfiguracionGurdada = dsRespuesta.Tables(0)
            Case 2 'Insertar
                oledbQuery = New OleDbCommand("INSERT INTO ConfiguracionGuardad VALUES(" & usuario & ",'Generación Archivo Interfase','" & txtRutaHD.Name & "','" & txtRutaHD.Text & "')", oledbConectar)
                Dim ver = oledbQuery.ExecuteNonQuery()
            Case 3 'Actualizar
                oledbQuery = New OleDbCommand("UPDATE ConfiguracionGuardad SET Valor = '" & txtRutaHD.Text & "' WHERE Usuario = " & usuario & " AND Opcion = 'Generación Archivo Interfase' AND Elemento = '" & txtRutaHD.Name & "'", oledbConectar)
                Dim ver = oledbQuery.ExecuteNonQuery()
        End Select
        oledbConectar.Close()
    End Sub
End Class