Imports System.Data.OleDb
Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmAltaFuncs
    Private dtTablaAltaGestoresExcel As New DataTable
    Private txtNombre, txtApellidoP, txtApellidoM, txtTelefono, txtFax, txtCP, txtCalle, txtColonia, txtEstado, txtNumF, txtNumReg, txtRegistroTF, lblUnidadOrgA, chkFuncionarioBBVA, chkEstrategico, cmbSucursal, cmbSucursal1, cmbUbicacion As String
    Private objDatasource As New Datasource
    Private dtRespConsulta As New DataTable
    Private sCarpeta, sArchivo As String
    Private Sub btExaminar_Click(sender As Object, e As EventArgs) Handles btExaminar.Click
        Dim abrir As New OpenFileDialog
        abrir.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        abrir.Filter = "Altas|*.*"
        If abrir.ShowDialog = DialogResult.OK Then
            txtRuta.Text = abrir.FileName
            sArchivo = abrir.SafeFileName
            sCarpeta = abrir.FileName.Substring(0, (abrir.FileName.Length - abrir.SafeFileName.Length) - 1)
        End If
    End Sub
    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
        If MsgBox("¿Desea salir?", vbYesNo + vbQuestion, "Salir de Alta de Gestores") <> vbYes Then
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub
    Private Sub btRegistro_Click(sender As Object, e As EventArgs) Handles btRegistro.Click
        pbRegistro.Visible = True
        btRegistro.Enabled = False
        If txtRuta.Text = "" Then
            MsgBox("No se tiene un archivo seleccionado")
        Else
            If CargaDatos() Then
                Registrar()
            End If
            'MsgBox("Se inserteo la informacion de forma correcta")
        End If
        pbRegistro.Visible = False
        btRegistro.Enabled = True
    End Sub
    Private Function CargaDatos() As Boolean
        Dim xlsx = txtRuta.Text
        Dim xls_cmd As New OleDbCommand
        Dim xls_reader As New OleDbDataAdapter
        Dim nombreXls = Path.GetFileName(xlsx)
        Dim strExtension = Path.GetExtension(xlsx)
        If strExtension = ".xlsx" Then
            If (File.Exists(xlsx)) Then
                Dim m_Excel = CreateObject("Excel.Application")
                m_Excel.DisplayAlerts = False
                m_Excel.Workbooks.Open(xlsx)
                Dim dt As New DataTable("Datos")
                Using xls_cn = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + xlsx + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=0'")
                    xls_cmd.CommandText = "SELECT * FROM [Hoja1$]"
                    xls_cmd.Connection = xls_cn
                    xls_reader.SelectCommand = xls_cmd
                    Dim da As New OleDbDataAdapter(xls_cmd)
                    da.Fill(dt)
                    dtTablaAltaGestoresExcel = dt
                End Using
                m_Excel.Quit()
            End If
            Return True
        Else
            MsgBox("Introduzca un archivo Excel valido.")
            Return False
        End If
    End Function
    Private Sub Registrar()
        Dim lsNewFunc As String
        Dim lsConfirm As String
        Dim lnUnidadOrganizacionalPadre As Integer
        Dim lsUnidadOrgBancomer As String
        Dim lnIdTransaccion As Integer
        Dim numFuncionarioPU As String
        Dim gsSql, gnUnidadOrg As String
        Dim contador = 0
        Dim dtRepuestaConsulta2 As New DataTable
        Dim sSucursalExcel As String

        For Each drRegistro As DataRow In dtTablaAltaGestoresExcel.Rows
            If drRegistro.Item(0).ToString() <> "" And drRegistro.Item(1).ToString() <> "" And drRegistro.Item(3).ToString() <> "" Then
                contador = contador + 1
            Else
                Exit For
            End If
        Next
        pbRegistro.Maximum = contador
        pbRegistro.Value = 0
        contador = 0
        For Each drRegistro As DataRow In dtTablaAltaGestoresExcel.Rows
            If drRegistro.Item(0).ToString() <> "" And drRegistro.Item(1).ToString() <> "" And drRegistro.Item(3).ToString() <> "" Then
                contador = contador + 1
                txtNombre = ValidaCaracteresCadena(drRegistro.Item(0).ToString())
                txtApellidoP = ValidaCaracteresCadena(drRegistro.Item(1).ToString())
                txtApellidoM = ValidaCaracteresCadena(drRegistro.Item(2).ToString())
                txtTelefono = drRegistro.Item(3).ToString()
                txtFax = drRegistro.Item(4).ToString()
                txtCP = drRegistro.Item(5).ToString()
                If drRegistro.Item(6).ToString().Length <= 60 Then
                    txtCalle = ValidaCaracteresCadena(drRegistro.Item(6).ToString())
                Else
                    MsgBox("La columna ''Calle'' solo permite un maximo de 60 caracteres, revisar la informacon de: " & txtNombre & " " & txtApellidoP & " " & txtApellidoM, vbInformation, "Gestores")
                    Exit Sub
                End If
                txtColonia = ValidaCaracteresCadena(drRegistro.Item(7).ToString())
                txtEstado = ValidaCaracteresCadena(drRegistro.Item(8).ToString())
                txtNumF = drRegistro.Item(9).ToString()
                txtNumReg = drRegistro.Item(10).ToString()
                txtRegistroTF = ValidaCaracteresCadena(drRegistro.Item(11).ToString())
                lblUnidadOrgA = drRegistro.Item(12).ToString()
                If ValidaCaracteresCadena(drRegistro.Item(13).ToString()) = "ALTA" Then chkFuncionarioBBVA = 1 Else chkFuncionarioBBVA = 0
                If ValidaCaracteresCadena(drRegistro.Item(14).ToString()) = "ALTA" Then chkEstrategico = 1 Else chkEstrategico = 0
                sSucursalExcel = drRegistro.Item(15).ToString()
                If txtNombre = "" Or txtApellidoP = "" Or txtApellidoM = "" Or txtTelefono = "" Or txtFax = "" Or txtCP = "" Or txtCalle = "" Or txtColonia = "" Or txtEstado = "" Or txtNumF = "" Or txtNumReg = "" Or txtRegistroTF = "" Or lblUnidadOrgA = "" Or sSucursalExcel = "" Then
                    MsgBox("No se tiene la informacion correcta en el regisrto de: " & txtNombre & " " & txtApellidoP & " " & txtApellidoM, vbInformation, "Gestores")
                    Exit Sub
                End If
                dtRepuestaConsulta2 = objDatasource.RealizaConsulta("select cr_opera from CATALOGOS..SUCURSAL where sucursal = " & sSucursalExcel)
                cmbSucursal = dtRepuestaConsulta2.Rows(0).Item(0) 'drRegistro.Item(15).ToString()
                cmbSucursal1 = dtRepuestaConsulta2.Rows(0).Item(0) 'drRegistro.Item(16).ToString()
                gnUnidadOrg = lblUnidadOrgA
                'gsSql = "Select T1.* from (Select ubicacion, descripcion_ubicacion From FUNCIONARIOS..UBICACION where tipo_ubicacion=4 or descripcion_ubicacion='DESCONOCIDO') T1 where T1.descripcion_ubicacion like '%" & txtEstado & "%'"
                'dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
                Dim asUbicacion() As String = Split(txtEstado, "|")
                If asUbicacion IsNot Nothing And Convert.ToInt32(asUbicacion(2).ToString) > 0 Then
                    'cmbUbicacion = dtRespConsulta.Rows(0).Item(0)
                    cmbUbicacion = Convert.ToInt32(asUbicacion(2).ToString)
                Else
                    cmbUbicacion = 1
                End If
                'Busca en la base de datos por el nombre del funcionario
                'cpb 9marzo2006 SQL2000 manejo de la concatenación de campos nulos
                gsSql = "SELECT "
                gsSql = gsSql & "rtrim(FU.nombre_funcionario)+' '+rtrim(isnull(FU.apellido_paterno, space(0)))+' '+rtrim(isnull(FU.apellido_materno, space(0))), "
                gsSql = gsSql & "FU.numero_funcionario "
                'gsSql = gsSql & "UR.banca "
                gsSql = gsSql & "FROM "
                gsSql = gsSql & "FUNCIONARIOS..FUNCIONARIO FU WITH (NOLOCK) "
                'gsSql = gsSql & "FUNCIONARIOS..UNIDAD_ORGANIZACIONAL_RESUMEN UR "
                gsSql = gsSql & "WHERE "
                'gsSql = gsSql & " FU.funcionario = UR.funcionario"
                gsSql = gsSql & " UPPER(rtrim(FU.nombre_funcionario)+' '+rtrim(isnull(FU.apellido_paterno, space(0)))+' '+rtrim(isnull(FU.apellido_materno, space(0)))) " 'gsSql = gsSql & " and UPPER(rtrim(FU.nombre_funcionario)+' '+rtrim(isnull(FU.apellido_paterno, space(0)))+' '+rtrim(isnull(FU.apellido_materno, space(0)))) "
                gsSql = gsSql & " like '%" & UCase(Trim(txtNombre) & " " & Trim(txtApellidoP) & " " & Trim(txtApellidoM)) & "%'"
                'dbExecQuery gsSql
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
                'Existe un funcionario parecido
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                    lsConfirm = "Ya existe el Gestor  " & dtRespConsulta.Rows(0).Item(0).ToLower() & "  (" & Trim(dtRespConsulta.Rows(0).Item(1)) & ")"
                    'lsConfirm = lsConfirm & " en " & (dtRespConsulta.Rows(0).Item(2)).ToLower()
                    lsConfirm = lsConfirm & " ¿Desea dar de alta el nuevo Gestor?"
                    'dbEndQuery
                    'ShowDefaultCursor
                    If MsgBox(lsConfirm, vbQuestion + vbYesNo, "Gestores") = vbNo Then
                        Exit Sub
                    End If
                    'ShowWaitCursor
                End If
                'dbEndQuery

                'dbBeginTran
                objDatasource.IniciaTransaccion()
                gsSql = "Insert into FUNCIONARIOS..FUNCIONARIO ("
                gsSql = gsSql & "unidad_organizacional, "
                gsSql = gsSql & "nombre_funcionario, "
                gsSql = gsSql & "apellido_paterno, "
                gsSql = gsSql & "apellido_materno, "
                gsSql = gsSql & "numero_funcionario, "
                gsSql = gsSql & "numero_registro, "
                gsSql = gsSql & "telefono_funcionario, "
                gsSql = gsSql & "fax_funcionario, "
                gsSql = gsSql & "calle_funcionario, "
                gsSql = gsSql & "colonia_funcionario, "
                gsSql = gsSql & "ubicacion, "
                gsSql = gsSql & "cp_funcionario, "
                gsSql = gsSql & "estrategico, "
                gsSql = gsSql & "bbvab, "
                If cmbSucursal <> -1 Then gsSql = gsSql & "cr_opera, "
                If cmbSucursal1 <> "" Then
                    If cmbSucursal1 <> -1 Then gsSql = gsSql & "cr_opera_term, "
                ElseIf InStr(1, Trim$(lblUnidadOrgA), "Banca Comercial(021)") <> 0 Then
                    If cmbSucursal1 <> -1 Then gsSql = gsSql & "cr_opera_term, "
                End If
                gsSql = gsSql & "activo, "
                gsSql = gsSql & "on_mni, "
                gsSql = gsSql & "on_bsi, "
                gsSql = gsSql & "on_harris, "
                gsSql = gsSql & "unidad_organizacional_anterior, "
                'fecha alta del funcionario
                gsSql = gsSql & "fecha_alta"
                gsSql = gsSql & ") values ("
                gsSql = gsSql & gnUnidadOrg & ", "
                gsSql = gsSql & "'" & UCase(Trim(txtNombre)) & "', "
                gsSql = gsSql & "'" & UCase(Trim(txtApellidoP)) & "', "
                gsSql = gsSql & "'" & UCase(Trim(txtApellidoM)) & "', "
                gsSql = gsSql & "'" & Trim(txtNumF) & "', "
                gsSql = gsSql & "'" & Trim(txtNumReg) & "', "
                gsSql = gsSql & "'" & Trim(txtTelefono) & "', "
                gsSql = gsSql & "'" & Trim(txtFax) & "', "
                gsSql = gsSql & "'" & Trim(txtCalle) & "', "
                gsSql = gsSql & "'" & Trim(txtColonia) & "', "
                gsSql = gsSql & cmbUbicacion & ", "
                gsSql = gsSql & "'" & Trim(txtCP) & "', "
                gsSql = gsSql & chkEstrategico & ", "
                gsSql = gsSql & chkFuncionarioBBVA & ", "
                If cmbSucursal <> -1 Then gsSql = gsSql & cmbSucursal & ", "
                If cmbSucursal1 <> "" Then
                    If cmbSucursal1 <> -1 Then gsSql = gsSql & cmbSucursal1 & ", "
                ElseIf InStr(1, Trim$(lblUnidadOrgA), "Banca Comercial(021)") <> 0 Then
                    If cmbSucursal1 <> -1 Then gsSql = gsSql & cmbSucursal & ", "
                End If
                'Activo y no asignado
                gsSql = gsSql & "1, 0, 0, 0, '', "
                'fecha alta del funcionario
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "')"
                'Da de alta el nuevo funcionario
                'dbExecQuery gsSql
                'No fue posible insertar el nuevo registro
                If objDatasource.EjecutaComandoTransaccion(gsSql) = False Then 'If dbError <> 0 Then
                    'ShowDefaultCursor
                    MsgBox("Ocurrio un error al intentar dar de alta al Gestor.", vbCritical, "Gestores")
                    'dbRollback
                    objDatasource.RollbackTransaccion()
                    GoTo Finalta
                End If
                'dbEndQuery

                gsSql = "Select max(funcionario) "
                gsSql = gsSql & "FROM FUNCIONARIOS..FUNCIONARIO WITH (NOLOCK) "
                'Busca el numero del nuevo funcionario
                'dbExecQuery gsSql
                'dbGetRecord
                If objDatasource.EjecutaComandoTransaccion(gsSql) = False Then 'If dbError <> 0 Then
                    'ShowDefaultCursor
                    MsgBox("Ocurrio un error al intentar dar de alta al Gestor.", vbCritical, "Gestores")
                    'dbRollback
                    objDatasource.RollbackTransaccion()
                    GoTo Finalta
                Else
                    lsNewFunc = iValorTransaccion
                End If
                'dbEndQuery

                'Libera cambios en la Base de Datos
                'dbCommit
                'ShowDefaultCursor
                'Call ActualizaUnidadOrg(lsNewFunc)

                lnUnidadOrganizacionalPadre = gnUnidadOrg

                'Extrae el dato de sucursal o plaza
                gsSql = "SELECT "
                gsSql = gsSql & "unidad_org_bancomer, tipo_unidad_organizacional, unidad_organizacional_padre "
                gsSql = gsSql & "FROM "
                gsSql = gsSql & "FUNCIONARIOS..UNIDAD_ORGANIZACIONAL WITH (NOLOCK) "
                gsSql = gsSql & "WHERE"
                gsSql = gsSql & " unidad_organizacional = " & lnUnidadOrganizacionalPadre
                'dbExecQuery gsSql
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                    lsUnidadOrgBancomer = dtRespConsulta.Rows(0).Item(0)
                End If
                'dbEndQuery

                'cpb 2mzo2006 SQL2000 Cambio de DESARROLLO por la variable BD_TICKET para la tabla TMP_FUNCIONARIOS_PU
                lnIdTransaccion = 0

                'Extrae el Id de la Transacción
                gsSql = "select isnull(max(id_transaccion), 0) as id_transaccion "
                gsSql = gsSql & "from " & "TICKET" & "..TMP_FUNCIONARIOS_PU WITH (NOLOCK) "
                'dbExecQuery gsSql
                'dbGetRecord
                dtRespConsulta = objDatasource.RealizaConsulta(gsSql)
                If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count > 0 Then 'If dbError = 0 Then
                    lnIdTransaccion = dtRespConsulta.Rows(0).Item(0)
                Else
                    'ShowDefaultCursor
                    MsgBox("No fue posible registrar la información para PU.", vbCritical, "Gestores")
                    'dbRollback
                    objDatasource.RollbackTransaccion()
                    GoTo Finalta
                End If
                'dbEndQuery
                'WSS001 begins
                If Trim(txtRegistroTF) = "" Then
                    numFuncionarioPU = "M" & Trim(txtNumF)
                Else
                    numFuncionarioPU = txtRegistroTF
                End If

                'WSS001 Ends
                ' ITS,EAG,ODT1,05/10/2011---------------------------------
                'OFG***
                gsSql = "INSERT INTO FUNCIONARIOS..FUNCIONARIOTF VALUES('"
                'gsSql = gsSql & "funcionario,"
                'gsSql = gsSql & "registrotf,"
                'gsSql = gsSql & "numero_funcionario)"
                'gsSql = gsSql & "VALUES ('"
                gsSql = gsSql & lsNewFunc & "', '"
                'WSS001 begins
                'gsSql = gsSql & txtRegistroTF.text & "', '"
                gsSql = gsSql & numFuncionarioPU & "', '"
                'WSS001 ends
                gsSql = gsSql & txtNumF & "')"
                'dbExecQuery gsSql

                If objDatasource.EjecutaComandoTransaccion(gsSql) = False Then 'If dbError <> 0 Then
                    'ShowDefaultCursor
                    MsgBox("No fue posible registrar la información para el Funcionario TF.", vbCritical, "Gestores")
                    objDatasource.RollbackTransaccion()
                    GoTo Finalta
                End If
                'dbEndQuery

                'Inserta en la Bitacora para envios a HOST

                'Subproducto 0000000002
                lnIdTransaccion = lnIdTransaccion + 1

                gsSql = "Insert into " & "TICKET" & "..TMP_FUNCIONARIOS_PU ("
                gsSql = gsSql & "id_funcionario, "
                gsSql = gsSql & "centro_regional, "
                gsSql = gsSql & "numero_funcionario, "
                gsSql = gsSql & "producto, "
                gsSql = gsSql & "subproducto, "
                gsSql = gsSql & "fecha_alta, "
                gsSql = gsSql & "fecha_baja, "
                gsSql = gsSql & "fecha_ultimo_mant, "
                gsSql = gsSql & "tipo_peticion, "
                gsSql = gsSql & "status_envio, "
                gsSql = gsSql & "id_transaccion, "
                gsSql = gsSql & "tipo) "
                gsSql = gsSql & "VALUES ("
                gsSql = gsSql & lsNewFunc & ", "                        'id_funcionario
                gsSql = gsSql & "'" & Trim(lsUnidadOrgBancomer) & "', " 'sucursal
                'WSS001 Begins
                'gsSql = gsSql & "'M" & Trim(txtNumF.text) & "', "       'numero_funcionario
                gsSql = gsSql & "'" & numFuncionarioPU & "',"           'numero_funcionario
                'WSS001 ends

                gsSql = gsSql & "'10', "                                'producto
                gsSql = gsSql & "'0000000002', "                        'subproducto
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_alta
                gsSql = gsSql & "'12-31-2080', "                        'fecha_baja
                gsSql = gsSql & "null, "                                'fecha_ultimo_mant
                gsSql = gsSql & "'A', "                                 'tipo_peticion
                gsSql = gsSql & "0, "                                   'status_envio
                gsSql = gsSql & lnIdTransaccion & ", "
                gsSql = gsSql & "'A') "

                'Ejecuta la inserción a la bitacora
                'dbExecQuery gsSql

                If objDatasource.EjecutaComandoTransaccion(gsSql) = False Then 'If dbError <> 0 Then
                    'ShowDefaultCursor
                    MsgBox("No fue posible registrar la información para PU.", vbCritical, "Gestores")
                    'dbRollback
                    objDatasource.RollbackTransaccion()
                    GoTo Finalta
                End If

                'dbEndQuery

                'Subproducto 0000000000
                lnIdTransaccion = lnIdTransaccion + 1

                gsSql = "Insert into " & "TICKET" & "..TMP_FUNCIONARIOS_PU ("
                gsSql = gsSql & "id_funcionario, "
                gsSql = gsSql & "centro_regional, "
                gsSql = gsSql & "numero_funcionario, "
                gsSql = gsSql & "producto, "
                gsSql = gsSql & "subproducto, "
                gsSql = gsSql & "fecha_alta, "
                gsSql = gsSql & "fecha_baja, "
                gsSql = gsSql & "fecha_ultimo_mant, "
                gsSql = gsSql & "tipo_peticion, "
                gsSql = gsSql & "status_envio, "
                gsSql = gsSql & "id_transaccion, "
                gsSql = gsSql & "tipo) "
                gsSql = gsSql & "VALUES ("
                gsSql = gsSql & lsNewFunc & ", "                        'id_funcionario
                gsSql = gsSql & "'" & Trim(lsUnidadOrgBancomer) & "', " 'sucursal
                'WSS001 Begins
                'gsSql = gsSql & "'M" & Trim(txtNumF.text) & "', "       'numero_funcionario
                gsSql = gsSql & "'" & numFuncionarioPU & "',"           'numero_funcionario
                'WSS001 ends
                gsSql = gsSql & "'10', "                                'producto
                gsSql = gsSql & "'0000000000', "                        'subproducto
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_alta
                gsSql = gsSql & "'12-31-2080', "                        'fecha_baja
                gsSql = gsSql & "null, "                                'fecha_ultimo_mant
                gsSql = gsSql & "'A', "                                 'tipo_peticion
                gsSql = gsSql & "0, "                                   'status_envio
                gsSql = gsSql & lnIdTransaccion & ", "
                gsSql = gsSql & "'A') "

                'Ejecuta la inserción a la bitacora
                'dbExecQuery gsSql

                If objDatasource.EjecutaComandoTransaccion(gsSql) = False Then 'If dbError <> 0 Then
                    'ShowDefaultCursor
                    MsgBox("No fue posible registrar la información para PU.", vbCritical, "Gestores")
                    'dbRollback
                    objDatasource.RollbackTransaccion()
                    GoTo Finalta
                End If

                'dbEndQuery

                'Subproducto 0000000687
                lnIdTransaccion = lnIdTransaccion + 1

                gsSql = "Insert into " & "TICKET" & "..TMP_FUNCIONARIOS_PU ("
                gsSql = gsSql & "id_funcionario, "
                gsSql = gsSql & "centro_regional, "
                gsSql = gsSql & "numero_funcionario, "
                gsSql = gsSql & "producto, "
                gsSql = gsSql & "subproducto, "
                gsSql = gsSql & "fecha_alta, "
                gsSql = gsSql & "fecha_baja, "
                gsSql = gsSql & "fecha_ultimo_mant, "
                gsSql = gsSql & "tipo_peticion, "
                gsSql = gsSql & "status_envio, "
                gsSql = gsSql & "id_transaccion, "
                gsSql = gsSql & "tipo) "
                gsSql = gsSql & "VALUES ("
                gsSql = gsSql & lsNewFunc & ", "                        'id_funcionario
                gsSql = gsSql & "'" & Trim(lsUnidadOrgBancomer) & "', " 'sucursal
                'WSS001 Begins
                'gsSql = gsSql & "'M" & Trim(txtNumF.text) & "', "       'numero_funcionario
                gsSql = gsSql & "'" & numFuncionarioPU & "',"           'numero_funcionario
                'WSS001 ends
                gsSql = gsSql & "'10', "                                'producto
                gsSql = gsSql & "'0000000687', "                        'subproducto
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_alta
                gsSql = gsSql & "'12-31-2080', "                        'fecha_baja
                gsSql = gsSql & "null, "                                'fecha_ultimo_mant
                gsSql = gsSql & "'A', "                                 'tipo_peticion
                gsSql = gsSql & "0, "                                   'status_envio
                gsSql = gsSql & lnIdTransaccion & ", "
                gsSql = gsSql & "'A') "

                'Ejecuta la inserción a la bitacora
                'dbExecQuery gsSql

                If objDatasource.EjecutaComandoTransaccion(gsSql) = False Then 'If dbError <> 0 Then
                    'ShowDefaultCursor
                    MsgBox("No fue posible registrar la información para PU.", vbCritical, "Gestores")
                    'dbRollback
                    objDatasource.RollbackTransaccion()
                    GoTo Finalta
                End If

                'dbEndQuery

                'Subproducto 0000000100
                lnIdTransaccion = lnIdTransaccion + 1

                gsSql = "Insert into " & "TICKET" & "..TMP_FUNCIONARIOS_PU ("
                gsSql = gsSql & "id_funcionario, "
                gsSql = gsSql & "centro_regional, "
                gsSql = gsSql & "numero_funcionario, "
                gsSql = gsSql & "producto, "
                gsSql = gsSql & "subproducto, "
                gsSql = gsSql & "fecha_alta, "
                gsSql = gsSql & "fecha_baja, "
                gsSql = gsSql & "fecha_ultimo_mant, "
                gsSql = gsSql & "tipo_peticion, "
                gsSql = gsSql & "status_envio, "
                gsSql = gsSql & "id_transaccion, "
                gsSql = gsSql & "tipo) "
                gsSql = gsSql & "VALUES ("
                gsSql = gsSql & lsNewFunc & ", "                        'id_funcionario
                gsSql = gsSql & "'" & Trim(lsUnidadOrgBancomer) & "', " 'sucursal
                'WSS001 Begins
                'gsSql = gsSql & "'M" & Trim(txtNumF.text) & "', "       'numero_funcionario
                gsSql = gsSql & "'" & numFuncionarioPU & "',"           'numero_funcionario
                'WSS001 ends
                gsSql = gsSql & "'10', "                                'producto
                gsSql = gsSql & "'0000000100', "                        'subproducto
                gsSql = gsSql & "'" & Format(CDate(gs_FechaHoy), "yyyy-MM-dd") & "',"  'fecha_alta
                gsSql = gsSql & "'12-31-2080', "                        'fecha_baja
                gsSql = gsSql & "null, "                                'fecha_ultimo_mant
                gsSql = gsSql & "'A', "                                 'tipo_peticion
                gsSql = gsSql & "0, "                                   'status_envio
                gsSql = gsSql & lnIdTransaccion & ", "
                gsSql = gsSql & "'A') "

                'Ejecuta la inserción a la bitacora
                'dbExecQuery gsSql

                If objDatasource.EjecutaComandoTransaccion(gsSql) = False Then 'If dbError <> 0 Then
                    'ShowDefaultCursor
                    MsgBox("No fue posible registrar la información para PU.", vbCritical, "Gestores")
                    'dbRollback
                    objDatasource.RollbackTransaccion()
                    GoTo Finalta
                End If

                'dbEndQuery

                'MsgBox("El Gestor fue dado de alta.", vbInformation, "Gestores")

                'INICIO: Registro de Alta en Bitacora de Gestores creado por Oliva Farias García OFG 01/nov/2016
                gsSql = "EXEC FUNCIONARIOS..sp_mantenimiento_func "
                gsSql = gsSql & lsNewFunc & "," & 1 & "," & usuario
                'dbExecQuery gsSql
                If objDatasource.EjecutaComandoTransaccion(gsSql) = False Then 'If dbError <> 0 Then
                    MsgBox("No fue posible registrar la información en bitacora.", vbCritical, "Gestores")
                End If
                'dbEndQuery
                'FIN: Registro de Bitacora de Gestores creado por Oliva Farias García OFG 01/nov/2016

                'dbCommit
                objDatasource.CommitTransaccion()
Finalta:
                gnUnidadOrg = 0
                'Unload Me
            Else
                Exit For
            End If
            pbRegistro.Value = contador
        Next
        MsgBox("Se dieron de alta " & contador & " Gestores", vbInformation, "Gestores")
        pbRegistro.Value = 0
    End Sub

    Private Function ValidaCaracteresCadena(sCadenaValidar As String) As String
        Dim sCaracteresValidos As String = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ .,|#0123456789"
        Dim sCaracterCadenaValidar As String
        sCadenaValidar = LTrim(RTrim(sCadenaValidar.ToUpper()))
        For i = 1 To Len(sCadenaValidar)
            sCaracterCadenaValidar = Mid(sCadenaValidar, i, 1)
            If sCaracteresValidos.Contains(sCaracterCadenaValidar) = False Then
                Return ""
            End If
        Next i
        Return sCadenaValidar
    End Function
    Private Function ValidaNumero(sNumeroValidar As String, bSucursal As Boolean) As String
        Dim sCaracteresValidos As String = "0123456789"
        Dim sCaracterCadenaValidar As String
        sNumeroValidar = LTrim(RTrim(sNumeroValidar))
        For i = 1 To Len(sNumeroValidar)
            sCaracterCadenaValidar = Mid(sNumeroValidar, i, 1)
            If sCaracteresValidos.Contains(sCaracterCadenaValidar) = False Then
                Return ""
            End If
        Next i
        If bSucursal Then
            Return sNumeroValidar.ToString().PadLeft(4, "0")
        Else
            Return ""
        End If
    End Function
End Class