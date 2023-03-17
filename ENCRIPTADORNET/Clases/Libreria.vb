Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Threading
Imports System.Management
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Collections.ObjectModel

Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports VB = Microsoft.VisualBasic


Public Class Libreria

    Public ARCHIVOINI As String = My.Application.Info.DirectoryPath & "\MT103202.INI"
    'Public DB As String = Trim(ReadIni(ARCHIVOINI, "DATABASE", "DB", "F/zR1+RmJaBlM9ASBnA7fA=="))
    Public DB As String = Trim(ReadIni(ARCHIVOINI, "DATABASE", "DB", "z1Rh9boc5VE="))
    Public DBFUN As String = Trim(ReadIni(ARCHIVOINI, "DATABASE", "DBFUN", "F/zR1+RmJaBlM9ASBnA7fA=="))
    Public SERVER As String = Trim(ReadIni(ARCHIVOINI, "DATABASE", "SERVER", "yZdfPixuOVHe2BW1AkcI3YVFLyxAsdr8"))
    Public USER As String = Trim(ReadIni(ARCHIVOINI, "DATABASE", "USER", "0fWlJK7YTOg="))
    Public PWD As String = Trim(ReadIni(ARCHIVOINI, "DATABASE", "PWD", "qeOBHX/EztY="))
    Public USERNM As String = Trim(ReadIni(ARCHIVOINI, "DATABASE", "USERNM", "0fWlJK7YTOg="))
    Public PWDNM As String = Trim(ReadIni(ARCHIVOINI, "DATABASE", "PWDNM", "qeOBHX/EztY="))
    Public ENTORNO As String = Trim(ReadIni(ARCHIVOINI, "DATABASE", "AMBIENTE", "TEST"))
    Public sFolderRPT As String = Trim(ReadIni(ARCHIVOINI, "DATABASE", "REPORTESFOLDER", "ReportesTKT"))
    Public DBGOS As String = Trim(ReadIni(ARCHIVOINI, "DATABASE", "DBGOS", "z1Rh9boc5VE="))

    Public CONECTION As Datasource

    Private Shared DES As New TripleDESCryptoServiceProvider
    Private Shared MD5 As New MD5CryptoServiceProvider

    Dim la_Lst(22, 1) As String
    Dim ls_Str As String
    Dim ls_Tmp As String = ""
    Dim lb_Ucs As Boolean
    Dim ln_Pos As Integer
    Dim ln_Chr As Integer
    Dim ln_Lap As Byte
    Dim ln_Len As Byte
    Dim ln_Rem As Byte

    Public Shared Function MD5Hash(ByVal value As String) As Byte()
        Return MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value))
    End Function



    Private Declare Unicode Function GetPrivateProfileString Lib "kernel32" _
   Alias "GetPrivateProfileStringW" (ByVal lpApplicationName As String,
   ByVal lpKeyName As String, ByVal lpDefault As String,
   ByVal lpReturnedString As String, ByVal nSize As Int32,
   ByVal lpFileName As String) As Int32

    'Funciones de libreria para leer en el archivo de configuracion de base de datos
    Public Function ReadIni(ByVal IniFileName As String, ByVal Section As String, ByVal ParamName As String, Optional ByVal ParamDefault As String = "") As String
        On Error Resume Next
        Dim ParamVal As String
        Dim LenParamVal As Long

        ParamVal = Space$(1024)
        LenParamVal = GetPrivateProfileString(Section, ParamName, ParamDefault, ParamVal, Len(ParamVal), IniFileName)
        'ReadIni = Left$(ParamVal, LenParamVal)
        ReadIni = ParamVal.Substring(0, LenParamVal)

        If Not Err.Number = 0 Then
            Err.Clear()
        End If
    End Function

    Sub logonBDreporte(ByVal reporteCR As ReportDocument, ByVal idTipo As Integer)
        ' ******************************************
        ' Seccion a eliminar , solo es de pruebas
        ' ******************************************
        'recaba datos de conexion
        ARCHIVOINI = My.Application.Info.DirectoryPath & "\MT103202.INI"
        'Public DB As String = Trim(ReadIni(ARCHIVOINI, "DATABASE", "DB", "F/zR1+RmJaBlM9ASBnA7fA=="))
        DB = Trim(ReadIni(ARCHIVOINI, "DATABASE", "DB", "z1Rh9boc5VE="))
        DBFUN = Trim(ReadIni(ARCHIVOINI, "DATABASE", "DBFUN", "F/zR1+RmJaBlM9ASBnA7fA=="))
        SERVER = Trim(ReadIni(ARCHIVOINI, "DATABASE", "SERVER", "yZdfPixuOVHe2BW1AkcI3YVFLyxAsdr8"))
        USERNM = Trim(ReadIni(ARCHIVOINI, "DATABASE", "USERNM", "NZ7TndcmAJooU8+rnWt6/w=="))
        PWDNM = Trim(ReadIni(ARCHIVOINI, "DATABASE", "PWDNM", "maeGKEX48pooU8+rnWt6/w=="))
        USER = Trim(ReadIni(ARCHIVOINI, "DATABASE", "USER", "qeOBHX/EztY="))
        PWD = Trim(ReadIni(ARCHIVOINI, "DATABASE", "PWD", "qeOBHX/EztY="))
        DBGOS = Trim(ReadIni(ARCHIVOINI, "DATABASE", "DBGOS", "3/J6zNbFogA="))

        DB = Decrypt(DB)
        DBFUN = Decrypt(DBFUN)
        SERVER = Decrypt(SERVER)
        USER = Decrypt(USER)
        PWD = Decrypt(PWD)
        USERNM = Decrypt(USERNM)
        PWDNM = Decrypt(PWDNM)

        DBGOS = Decrypt(DBGOS)
        ' ******************************************
        ' FIN Seccion a eliminar , solo es de pruebas
        ' ******************************************
        If idTipo = 1 Then   'tipo=1 negint
            reporteCR.SetDatabaseLogon(USER, PWD, SERVER, DB)
            ' ******************************************
            ' INICIA Seccion a eliminar , solo es de pruebas,validar como se realizara la conexión
            ' ******************************************
            reporteCR.SetDatabaseLogon(USER, PWD, SERVER, DBGOS)
            ' ******************************************
            ' FIN Seccion a eliminar , solo es de pruebas
            ' ******************************************
        Else 'tipo=2     negint, nuevomis
            reporteCR.SetDatabaseLogon(USER, PWD, SERVER, DB)
            reporteCR.SetDatabaseLogon(USERNM, PWDNM, SERVER, DBFUN)
        End If

        If Not Err.Number = 0 Then
            MsgBox("logonBDreporte", Err.Description)
            Err.Clear()
        End If

    End Sub
    Sub CredencialesConexion()
        On Error Resume Next

        'Servidor de desarrollo: Desencriptar credenciales para conexion a base de datos

        DB = Decrypt(DB)
        DBFUN = Decrypt(DBFUN)
        SERVER = Decrypt(SERVER)
        USER = Decrypt(USER)
        PWD = Decrypt(PWD)

        If Not Err.Number = 0 Then
            MsgBox("CredencialesConexion", Err.Description)
            Err.Clear()
        End If
    End Sub

    Sub CredencialesConexionRep()
        On Error Resume Next

        'Servidor de desarrollo: Desencriptar credenciales para conexion a base de datos

        DB = Decrypt(DB)
        DBFUN = Decrypt(DBFUN)
        SERVER = Decrypt(SERVER)
        USER = Decrypt(USER)
        PWD = Decrypt(PWD)
        USERNM = Decrypt(USERNM)
        PWDNM = Decrypt(PWDNM)

        If Not Err.Number = 0 Then
            MsgBox("CredencialesConexionRep", Err.Description)
            Err.Clear()
        End If
    End Sub

    Public Function Decrypt(ByVal encryptedString As String, Optional ByVal key As String = "BBVA BANCOMER") As String
        Try
            If encryptedString = "" Then
                Return ""
                Exit Function
            End If

            DES.Key = MD5Hash(key)
            DES.Mode = CipherMode.ECB
            Dim Buffer As Byte() = Convert.FromBase64String(encryptedString)
            Return ASCIIEncoding.ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
        Catch ex As Exception
            Return ""
        End Try

        Return ""
    End Function

    Public Function Encrypt(ByVal stringToEncrypt As String, Optional ByVal key As String = "BBVA BANCOMER") As String
        On Error Resume Next
        If stringToEncrypt = "" Then
            stringToEncrypt = "BBVA BANCOMER"
        End If
        DES.Key = MD5Hash(key)
        DES.Mode = CipherMode.ECB
        Dim Buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(stringToEncrypt)
        Return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
    End Function
    '-----------------------------------RACB
    Public Function Encryption(ByVal Accion As Byte, ByVal Palabra As String) As String
        Dim objEncriptar As New MNICript.clsEncripta
        On Error GoTo NoSingOn

        Encryption = objEncriptar.VerificaClaves(Accion, Palabra)
        Exit Function

NoSingOn:
        Encryption = "ERROR"
        MsgBox("No es posible verificar datos encriptados.", vbCritical, "Error:" & Err.Description)
    End Function
    '-----------------------------------RACB

    '--------------------------------------------------------------------------------
    'Quitamos los espacios excedentes entre el texto enviado
    '2020 junio 09
    '--------------------------------------------------------------------------------
    Public Function fgUnEspacio(ByVal sTexto As String) As String

        Dim sTemp As String
        Dim iPos As Long
        sTemp = ""
        sTexto = Trim(sTexto)
        Do While Len(sTexto) > 0
            iPos = InStr(1, sTexto, " ")
            If iPos = 0 Then
                iPos = Len(sTexto) + 1
            End If
            sTemp = sTemp & Trim(VB.Left(sTexto, iPos - 1)) & " "
            sTexto = Trim(Mid$(sTexto, iPos))
        Loop
        fgUnEspacio = Trim(sTemp)
    End Function

    '--------------------------------------------------------------------------------------
    'Invierte la entre los formatos dd-mm-yy y mm-dd-yy si el parametro es una fecha valida
    '2020 junio 09 
    '--------------------------------------------------------------------------------------
    Public Function InvierteFecha(ByVal Fecha As String) As String

        Dim ls_Cadena As String

        InvierteFecha = Trim(Fecha)
        ls_Cadena = Trim(Fecha)
        'Si no es una fecha valida, termina
        If Not IsDate(Fecha) Then Exit Function
        'Si le falta un caracter al dia
        If Mid(ls_Cadena, 2, 1) = "-" Or Mid(ls_Cadena, 2, 1) = "/" Then
            ls_Cadena = "0" & ls_Cadena
        End If
        'Si le falta un caracter al mes
        If Mid(ls_Cadena, 5, 1) = "-" Or Mid(ls_Cadena, 5, 1) = "/" Then
            ls_Cadena = VB.Left(ls_Cadena, 3) & "0" & Mid(ls_Cadena, 4, 4)
        End If
        InvierteFecha = Mid(ls_Cadena, 4, 3) & VB.Left(ls_Cadena, 3) & DatePart("yyyy", InvierteFecha)
    End Function

    '---------------------------------------------------------------------------------------
    'Convierte una cadena de Mayusculas a Mayusculas-Minusculas EJEMPLO -> Ejemplo
    'Fecha: 23 de Octubre 2019
    '---------------------------------------------------------------------------------------
    Public Function LowCaseName(Nombre As String) As String

        Try
            ls_Str = Trim(Nombre)
            'La cadena es vacia termina
            If ls_Str = "" Then
                LowCaseName = ""
                Exit Function
            End If
            'La cadena tiene ya tiene minusculas entonces termina
            If UCase(ls_Str) <> Trim(Nombre) Then
                LowCaseName = Trim(Nombre)
                Exit Function
            End If
            'Llena la lista de excepciones
            la_Lst(0, 0) = "De" : la_Lst(0, 1) = "de"
            la_Lst(1, 0) = "La" : la_Lst(1, 1) = "la"
            la_Lst(2, 0) = "El" : la_Lst(2, 1) = "el"
            la_Lst(3, 0) = "Los" : la_Lst(3, 1) = "los"
            la_Lst(4, 0) = "Td" : la_Lst(4, 1) = "TD"
            la_Lst(5, 0) = "Tds" : la_Lst(5, 1) = "TDs"
            la_Lst(6, 0) = "S.a." : la_Lst(6, 1) = "S.A."
            la_Lst(7, 0) = "C.v." : la_Lst(7, 1) = "C.V."
            la_Lst(8, 0) = "Sa" : la_Lst(8, 1) = "S.A."
            la_Lst(9, 0) = "Cv" : la_Lst(9, 1) = "C.V."
            la_Lst(10, 0) = "Y" : la_Lst(10, 1) = "y"
            la_Lst(11, 0) = "Edo.mex." : la_Lst(11, 1) = "Edo.Mex."
            la_Lst(12, 0) = "Fa-" : la_Lst(12, 1) = "FA-@"
            la_Lst(13, 0) = "Mn" : la_Lst(13, 1) = "MN"
            la_Lst(14, 0) = "Usd" : la_Lst(14, 1) = "USD"
            la_Lst(15, 0) = "D.f." : la_Lst(15, 1) = "D.F."
            la_Lst(16, 0) = "Por" : la_Lst(16, 1) = "por"
            la_Lst(17, 0) = "S.b.f." : la_Lst(17, 1) = "S.B.F."
            la_Lst(18, 0) = "En" : la_Lst(18, 1) = "en"
            la_Lst(19, 0) = "Q.r." : la_Lst(19, 1) = "Q.R."
            la_Lst(20, 0) = "Cd" : la_Lst(20, 1) = "CD@"
            la_Lst(21, 0) = "Del" : la_Lst(21, 1) = "del"
            la_Lst(22, 0) = "CD." : la_Lst(22, 1) = "Cd."

            lb_Ucs = False
            ls_Tmp = UCase(VB.Left(ls_Str, 1))
            'Si la cadena no es vacia convierte
            For ln_Pos = 2 To Len(ls_Str)
                ls_Tmp = ls_Tmp & IIf(lb_Ucs, UCase(Mid(ls_Str, ln_Pos, 1)), LCase(Mid(ls_Str, ln_Pos, 1)))
                If Mid(Trim(Nombre), ln_Pos, 1) = " " Then
                    lb_Ucs = True
                Else
                    lb_Ucs = False
                End If
            Next ln_Pos

            'Repasa 3 veces la cadena para confirmar
            For ln_Lap = 1 To 3
                'Compara cadena convertida contra lista de excepciones
                For ln_Pos = 0 To 22
                    'Longitud de cadena original
                    ln_Len = Len(la_Lst(ln_Pos, 0))
                    'Longitud de cadena reemplazo
                    ln_Rem = Len(la_Lst(ln_Pos, 1))
                    'Busca excepcion en cadena convertida
                    ln_Chr = InStr(1, ls_Tmp, la_Lst(ln_Pos, 0))
                    'Si existe la excepcion
                    If ln_Chr > 0 Then
                        'Si es al inicio de la cadena
                        If ln_Chr = 1 Then
                            'Si no es preposicion
                            If ln_Pos > 3 Then
                                'Si la cadena es mayor que la long. del reemplazo
                                If ln_Len < Len(ls_Tmp) Then
                                    'Si es mitad de cadena
                                    If Mid(ls_Tmp, ln_Chr + ln_Len, 1) = " " Then
                                        LowCaseName = Reemplaza()
                                    End If
                                    'Si es reemplazo con comodin
                                    If VB.Right(la_Lst(ln_Pos, 1), 1) = "@" Then
                                        LowCaseName = Reemplaza()
                                    End If
                                    'Si la cadena no es mayor que el reemplazo
                                Else
                                    LowCaseName = Reemplaza()
                                End If
                            End If
                            'Si es al fin de la cadena
                        ElseIf ln_Chr + ln_Len = Len(ls_Tmp) + 1 Then
                            'Si el caracter anterior es un espacio
                            If Mid(ls_Tmp, ln_Chr - 1, 1) = " " Then
                                LowCaseName = Reemplaza()
                            End If
                            'Si es entre la cadena
                        Else
                            If Mid(ls_Tmp, ln_Chr + ln_Len, 1) = " " And Mid(ls_Tmp, ln_Chr - 1, 1) = " " Then
                                LowCaseName = Reemplaza()
                            End If
                        End If
                    End If
                Next ln_Pos
            Next ln_Lap
        Catch ex As Exception
            LowCaseName = ls_Tmp
            Exit Function
        End Try

        LowCaseName = ls_Tmp

    End Function

    Public Function Reemplaza() As String
        'Si la cadena de reemplazo es mayor que la original
        If ln_Rem > ln_Len Then
            'Si es reemplazo con comodin
            If VB.Right(la_Lst(ln_Pos, 1), 1) <> "@" Then
                ls_Tmp = Mid(ls_Tmp, 1, ln_Chr - 1) & Space(ln_Rem - ln_Len) & Mid(ls_Tmp, ln_Chr, Len(ls_Tmp))
            End If
        End If
        'Si es reemplazo con comodin
        If VB.Right(la_Lst(ln_Pos, 1), 1) = "@" Then
            Mid(ls_Tmp, ln_Chr, ln_Rem) = VB.Left(la_Lst(ln_Pos, 1), (Len(la_Lst(ln_Pos, 1)) - 1))
            Mid(ls_Tmp, Len(la_Lst(ln_Pos, 1)), 1) = UCase(Mid(ls_Tmp, Len(la_Lst(ln_Pos, 1)), 1))
        Else
            'Reemplaza la cadena
            Mid(ls_Tmp, ln_Chr, ln_Rem) = la_Lst(ln_Pos, 1)
        End If
        Reemplaza = ls_Tmp
    End Function

#Region "Permisos Seguridad"
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=---
    'Devuelve el resultado de la combinación binaria de dos numeros decimales
    '2020 junio 09
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=NumDec1-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=---
    Public Function CombinaValores(NumDec1 As String, NumDec2 As String) As String

        Dim ls_Binario1 As String
        Dim ls_Binario2 As String
        Dim ls_BinFinal As String
        Dim ln_Posicion As Integer
        Dim ln_Longitud As Integer

        ls_BinFinal = ""
        'Obtiene el numero binario de los decimales
        ls_Binario1 = Trim(ObtenBinario(NumDec1))
        ls_Binario2 = Trim(ObtenBinario(NumDec2))

        'Obtiene la longitud del binario final
        ln_Longitud = IIf((Len(ls_Binario1) > Len(ls_Binario2)), Len(ls_Binario1), Len(ls_Binario2))
        ls_BinFinal = StrDup(ln_Longitud, "0")

        'Iguala la longitud de ambas cadenas binarias
        If Len(ls_Binario1) < ln_Longitud Then _
        ls_Binario1 = ls_Binario1 & StrDup(ln_Longitud - Len(ls_Binario1), "0")

        If Len(ls_Binario2) < ln_Longitud Then _
        ls_Binario2 = ls_Binario2 & StrDup(ln_Longitud - Len(ls_Binario2), "0")

        'Genera la cadena binaria final
        For ln_Posicion = 1 To ln_Longitud
            If Val(Mid(ls_Binario1, ln_Posicion, 1)) + Val(Mid(ls_Binario2, ln_Posicion, 1)) > 0 Then
                Mid(ls_BinFinal, ln_Posicion, 1) = "1"
            End If
        Next ln_Posicion
        If ls_BinFinal <> "" Then
            CombinaValores = Bin2Hex(ls_BinFinal)
        End If
    End Function

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=---
    ' Descompone un numero decimal en su correspondiente binario
    '2020 junio 09
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=---

    Public Function ObtenBinario(ByVal NumDecimal As String) As String
        ObtenBinario = Hex2Bin(NumDecimal)
    End Function

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    ' Funcion que cambia de una cadena Binaria a Hexadecimal.
    ' Utilizada para la interpretación de los permisos al guardarlos en la base.
    ' 2020 junio 10
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function Bin2Hex(strBin As String) As String

        Dim strTmp As String
        Dim strHex As String
        Dim intLength As Integer
        Dim intOffset As Integer
        Dim i As Integer
        Dim j As Integer
        Dim intDec As Integer

        ' Redondear a multiplos de 4
        intLength = Len(strBin)
        intLength = ((intLength \ 4) + Math.Sign(intLength Mod 4)) * 4

        ' Rellenar con ceros a la derecha
        strTmp = StrDup(intLength, "0")
        Mid(strTmp, 1, Len(strBin)) = strBin

        strHex = ""
        For i = 0 To (intLength \ 4) - 1
            intOffset = i * 4
            intDec = 0
            For j = 1 To 4
                intDec = intDec + (IIf(Mid(strTmp, intOffset + j, 1) = "1", (2 ^ (j - 1)), 0))
            Next j
            strHex &= Hex(Val(intDec))
        Next i
        Bin2Hex = strHex
    End Function

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    ' Funcion que cambia de una cadena Hexdecimal a Binaria.
    ' Utilizada para la interpretación de los permisos.
    '2020 junio 09
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
        Hex2Bin = strBin
    End Function


    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=---
    'Lee la base de datos para llenar los arreglos de permisos.
    '2020 junio 09
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=---
    Public Sub CargaPermisos(sNumApp As String)
        Dim d As New Datasource
        Dim dtPermisos As New DataTable

        Dim ls_sql As String
        Dim i As Integer

        Const COL_ID = 0
        Const COL_NOMBRE = 1
        Const COL_DESCRIPCION = 2

        'Verificamos la existencia de permisos, para cargarlos en un arreglo
        gn_TotalPermisos = 0
        ls_sql = "SELECT count(*) FROM CATALOGOS.dbo.PERMISOS_HEXA WHERE aplicacion in (" & sNumApp & ") "
        gn_TotalPermisos = d.HayRegistros(ls_sql)

        'Si existen permisos para la aplicacion los cargamos en un arreglo
        If gn_TotalPermisos > 0 Then
            ReDim ga_Permisos(0 To gn_TotalPermisos)
            ' Lee los permisos de la base de datos por aplicacion
            ls_sql = "SELECT permiso, nombre_permiso, descripcion, aplicacion FROM " '-----RACB 09/08/2021
            ls_sql &= " CATALOGOS.dbo.PERMISOS_HEXA WHERE "
            ls_sql &= " aplicacion in (" & sNumApp & ")  order by aplicacion,descripcion" '-----RACB 09/08/2021
            ' LEO valor_permiso b
            i = 0

            dtPermisos = d.Consulta(ls_sql, "Permisos")

            Do While Not (i = (gn_TotalPermisos))
                ga_Permisos(i).Valor = dtPermisos.Rows(i).Item(COL_ID)
                ga_Permisos(i).Nombre = dtPermisos.Rows(i).Item(COL_NOMBRE).ToString.Trim
                ga_Permisos(i).Descripcion = ChecaTexto(dtPermisos.Rows(i).Item(COL_DESCRIPCION).ToString.Trim)
                ga_Permisos(i).IDAplicacion = dtPermisos.Rows(i).Item(3) '-----RACB 09/08/2021
                'Almacenamos el mayor ID del permiso, este dara la longitud de la cadena.
                gn_MaxPermiso = IIf(gn_MaxPermiso > ga_Permisos(i).Valor, gn_MaxPermiso, ga_Permisos(i).Valor)
                i = i + 1
            Loop
        End If
        Call CargaAutorizaciones(sNumApp)
    End Sub

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=---
    'Lee la base de datos para llenar los arreglos de autorizaciones.
    '2020 junio 09
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=---
    Public Sub CargaAutorizaciones(sNumApp As String)
        Dim d As New Datasource
        Dim dtAutorizaciones As New DataTable
        Dim ls_sql As String
        Dim i As Integer

        Const COL_NOMBRE = 0
        Const COL_DESCRIPCION = 1
        Const COL_COMENTARIO = 2
        Const COL_HORA_LIMITE = 3
        Const COL_ID = 4

        'Verificamos la existencia de autorizaciones, para cargarlos en un arreglo.
        gn_TotalAutorizaciones = 0

        'Lee las autorizaciones de la base de datos por aplicacion
        ls_sql = "SELECT count(*) FROM CATALOGOS.dbo.AUTORIZACIONES_HEXA WHERE aplicacion in (" & sNumApp & ")"

        gn_TotalAutorizaciones = d.HayRegistros(ls_sql)

        If gn_TotalAutorizaciones > 0 Then
            ReDim ga_Autorizaciones(0 To gn_TotalAutorizaciones - 1)
            ls_sql = "select nombre_autorizacion, descripcion, requiere_comentario,"
            ls_sql &= " convert(char(5),hora_limite,8), autorizacion, aplicacion from " '------------- RACB 09/08/2021
            ls_sql &= " CATALOGOS.dbo.AUTORIZACIONES_HEXA where "
            ls_sql &= "aplicacion in (" & sNumApp & ") order by aplicacion,descripcion" 'ls_sql &= "aplicacion = 1 order by descripcion" '------------- RACB 09/08/2021

            i = 0
            dtAutorizaciones = d.Consulta(ls_sql, "Permisos")

            Do While (i <> gn_TotalAutorizaciones) 'Do While Not(i <> gn_TotalAutorizaciones) '------------- RACB 09/08/2021
                ga_Autorizaciones(i).Nombre = dtAutorizaciones.Rows(i).Item(COL_NOMBRE).ToString.Trim
                ga_Autorizaciones(i).Descripcion = ChecaTexto(dtAutorizaciones.Rows(i).Item(COL_DESCRIPCION).ToString.Trim)
                ga_Autorizaciones(i).Comentario = dtAutorizaciones.Rows(i).Item(COL_COMENTARIO) '------------- RACB 09/08/2021
                ga_Autorizaciones(i).Hora = dtAutorizaciones.Rows(i).Item(COL_HORA_LIMITE).ToString.Trim
                ga_Autorizaciones(i).Valor = Val(dtAutorizaciones.Rows(i).Item(COL_ID))
                ga_Autorizaciones(i).IDAplicacion = dtAutorizaciones.Rows(i).Item(5) '------------- RACB 09/08/2021
                'Almacenamos el maximo ID de las autrizaciones, este darta la longitud de la cadena de autorizaciones
                gn_MaxAutorizacion = IIf(gn_MaxAutorizacion > ga_Autorizaciones(i).Valor, gn_MaxAutorizacion, ga_Autorizaciones(i).Valor)
                i = i + 1

            Loop
        End If
    End Sub


    '--------------------------------------------------------------------------
    'Devuelve una cadena preparada para un Query
    '2020 junio 09
    '--------------------------------------------------------------------------
    'Public Function ChecaTexto(ps_SourceString As String, Optional pn_length As Integer) As String
    Public Function ChecaTexto(ps_SourceString As String) As String
        Dim i As Integer
        Dim c As String
        Dim ls_RetVal As String
        Dim ln_RetLen As Integer
        Dim pn_length As Integer

        pn_length = Len(ps_SourceString)
        ln_RetLen = Len(ps_SourceString)
        If pn_length < ln_RetLen Then ln_RetLen = pn_length
        ls_RetVal = StrDup(ln_RetLen, vbNullChar)
        For i = 1 To ln_RetLen
            c = Mid(ps_SourceString, i, 1)
            Select Case Asc(c)
            'Comillas y apóstrofe
                Case 34, 39
                    Mid(ls_RetVal, i, 1) = "´"
            'Barra, Pipe, Enter
                Case 10, 13, 124
                    Mid(ls_RetVal, i, 1) = " "
                    'Cualquier otro caso
                Case Else
                    Mid(ls_RetVal, i, 1) = c
            End Select
        Next i
        ChecaTexto = ls_RetVal
    End Function

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    'Devuelve el valor booleano correspondiente a un permiso del usuario que firmo
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    Public Function Permiso(strNombrePer As String) As Boolean
        Permiso = False
        If gn_TotalPermisos > 0 Then
            Permiso = PermisosPorUsuario(strNombrePer, gs_Permisos1)
            If Permiso = False Then
                Permiso = PermisosPorUsuario(strNombrePer, gs_Permisos2)
            End If
        End If
    End Function

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    'Devuelve el valor booleano correspondiente a un permiso de un usuario distinto al que firmo
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function PermisosPorUsuario(ByVal strNombrePer As String, ByVal strMascAccesos As String) As Boolean
        Dim l As New Libreria

        Dim ln_Valor As Integer
        Dim ls_CadBin As String

        PermisosPorUsuario = False

        ln_Valor = ValorPermiso(strNombrePer)

        If ln_Valor < 0 Then
            MsgBox("Error: Descripción o Nombre de Permiso Inexistente." & vbCrLf &
            l.SERVER & " \ CATALOGOS \ " & strNombrePer, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
            Exit Function
        Else
            ls_CadBin = Hex2Bin(strMascAccesos)
            If Mid(ls_CadBin, ln_Valor, 1) = "1" Then
                PermisosPorUsuario = True
            End If
        End If
    End Function

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    ' Busca el permiso en el arreglo de permisos y devuelve su valor.
    ' Si no lo encuentra devuelve -1
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Function ValorPermiso(strNombrePer As String)
        Dim i As Integer
        Dim ival As Integer
        Dim inom As String
        Dim idsc As String

        ValorPermiso = -1

        For i = LBound(ga_Permisos) To UBound(ga_Permisos)
            'ival = ga_Permisos(i).Valor
            'inom = ga_Permisos(i).Nombre
            'idsc = ga_Permisos(i).Descripcion

            If Trim(ga_Permisos(i).Nombre) = Trim(strNombrePer) Then
                ValorPermiso = ga_Permisos(i).Valor
                Exit For
            End If
        Next i
    End Function

    'Public Function StrDup(Number As Integer, Character As Char) As String
#End Region'------------------------------------------------------------------------
    'Valida que los datos contenidos en el objeto Fecha, sea una fecha valida
    '------------------------------------------------------------------------
    Public Function ValidaFecha(Fecha As Object, LimiteMax As Object) As Boolean

        ' Esta llamada es exigida por el diseñador.
        'InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim ls_FechaLimite As String

        'If Not IsMissing(LimiteMax) Then
        '    ls_FechaLimite = LimiteMax
        'Else
        '    ls_FechaLimite = gs_FechaHoy
        'End If
        'Return False
        If TypeOf Fecha Is TextBox Then
            If Trim(Fecha) = "" Then
                'ElseIf Not EsFechaY2K(Fecha) Then
                '    If TRADUCE = True Then
                '        MsgBox "The date format must be " & gs_FormatoFecha & ".", vbCritical, "Invalid Date"
                '    Else
                MsgBox("El formato de fecha debe ser " & gs_FormatoFecha & ".", vbCritical, "Fecha Invalida")
                '    End If
                '    Fecha = ""
                '    Fecha.SetFocus
                Return False
                Exit Function
            ElseIf CDate(Fecha) < CDate("01-01-1960") Then
                'If TRADUCE = True Then
                'MsgBox "The date can not be smaller to 1960.", vbCritical, "Invalid Date"
                'Else
                MsgBox("La fecha no puede ser menor a 1960.", vbCritical, "Fecha Invalida")
                'End If
                Fecha = Date.Now
                Fecha.SetFocus
                Return False
                Exit Function
            ElseIf CDate(Fecha) > CDate(ls_FechaLimite) Then
                'If TRADUCE = True Then
                'MsgBox "The date can not be greater than today.", vbCritical, "Invalid Date"
                'Else
                MsgBox("La fecha no debe ser mayor a hoy.", vbCritical, "Fecha Invalida")
                'End If
                Fecha = Date.Now
                Fecha.SetFocus
                Exit Function
            Else
                'Fecha = FechaY2K(Fecha)
            End If
            ' ValidaFecha = True
        End If

    End Function


    Public Function cambiarLabels(label As Object)
        On Error Resume Next


        label.BackColor = &HE0E0E0
        label.FontName = "Tahoma"
        label.FontSize = 8
        label.FontItalic = False
        label.FontBold = False

    End Function

    '---------------------------------------------------------------------------------
    'Despliega la pantalla que muestra la digitalizacion de un Documento en Particular
    '---------------------------------------------------------------------------------
    Public Function MuestraDigitalizacion(ByVal Documento As String, ByVal TopMost As Long, Acta As Long)

        Dim ls_DocDigital As String
        Dim ls_Directorio As String
        Dim ls_Titulo As String
        Dim ln_Respuesta As Long
        Dim ln_MidScr As Long
        Dim ln_Height As Long
        Dim ln_PosX As Long
        Dim row As DataRow

        Dim d As New Datasource
        Dim dt As New DataTable


        gs_Sql = "Select digitalizacion "
        gs_Sql = gs_Sql & "From "
        If Acta <> 0 Then  'If Not IsMissing(Acta) Then                                         'Es consulta de Acta Digitalizada
            gs_Sql = gs_Sql & "ACTA_ADM "
            gs_Sql = gs_Sql & "Where acta = " & Documento
        Else                                                                'Es consulta de Documento Digitalizado
            gs_Sql = gs_Sql & "DOCUMENTO "
            gs_Sql = gs_Sql & "Where documento = " & Documento
        End If



        dt = d.RealizaConsulta(gs_Sql)
        If dt.Rows.Count <= 0 Then
            Exit Function
        End If

        'dbExecQuery gs_Sql
        'dbGetRecord
        'ls_DocDigital = Trim(dbGetValue(0))

        row = dt.Rows(0)
        ls_DocDigital = row.Item("digitalizacion").ToString


        If Val(ls_DocDigital) < 1 Then
            MsgBox("No se encontro la digitalización del documento.", vbInformation, "Digitalización")
            Exit Function
        End If
        'ln_MidScr = (Screen.Width / 2) / Screen.TwipsPerPixelX              'Obtiene la mitad de la longitud de la pantalla en pixels
        'ln_Height = (Screen.Height / 2) / Screen.TwipsPerPixelY             'Obtiene la mitad de la altura de la pantalla en pixels
        If Acta <> 0 Then                                         'Es consulta de Acta Digitalizada
            ls_Titulo = "Acta Digitalizada"
        Else                                                                'Es consulta de Documento Digitalizado
            ls_Titulo = "Documento Digitalizado"
        End If
        Err.Clear()                                                           'Elimina cualquier error antes de mostrar la digitalizacion
        'Obtiene directorio para buscar archivo digitalizado MMQ 17-jun-2010 -----
        gs_Sql = " select distinct documento,TDOCUMENTO.nombre,"
        gs_Sql = gs_Sql & " IsNull(tipoacceso,0) as acceso, TDOCUMENTO.disco,"
        gs_Sql = gs_Sql & " TDOCUMENTO.directorio , TDISCO.nombre as disco_nombre,"
        gs_Sql = gs_Sql & " TDISCO.drive as disco_drive, TDISCO.activo as disco_activo"
        gs_Sql = gs_Sql & " from TDOCUMENTO,TRESTRICCION,TACCESO, TDISCO  where (documento=" & ls_DocDigital & ")"
        gs_Sql = gs_Sql & " and   (tipo=1)  and   ((TDOCUMENTO.acceso*=TRESTRICCION.acceso)  and"
        gs_Sql = gs_Sql & " (TRESTRICCION.tipousuario=1))  and TDISCO.disco=TDOCUMENTO.disco"

        'gs_Sql = "SELECT Directorio FROM TDOCUMENTO WHERE DOCUMENTO= " & Documento
        'dbExecQuery gs_Sql
        'dbGetRecord

        dt = d.RealizaConsulta(gs_Sql)
        If dt.Rows.Count <= 0 Then
            Exit Function
        End If

        row = dt.Rows(0)
        ls_Directorio = row.Item("directorio").ToString

        'ls_Directorio = Trim(dbGetValue(4))
        PATHGOS = row.Item("directorio").ToString 'Trim(dbGetValue(6))
        'dbEndQuery
        If Val(ls_Directorio) < 1 Then
            MsgBox("No se encontro directorio del documento.", vbInformation, "Digitalización")
            Exit Function
        End If

        On Error Resume Next
        'ln_Respuesta = CargaDocumento("Firma", "Softtek", 2, ls_DocDigital, "1", ls_Titulo, ln_MidScr, 0, ln_MidScr, _ln_Height, TopMost)                                 
        'Muestra el documento en 1/2 de la pantalla (esq. superior derecha)
        'If TRADUCE = True Then
        'ln_Respuesta = Shell("C:\Program Files\Xerox\Pagis Viewer 2.0\XifLite.exe" & " " & PATHGOS & ls_Directorio & "\" & ls_DocDigital, vbNormalFocus)
        'Else
        ln_Respuesta = Shell(PAGISVIEWER & " " & PATHGOS & ls_Directorio & "\" & ls_DocDigital, vbNormalFocus)
        'End If
        '-----------


        If Err.Number Then 'Err() <> 0 Then                                                    'Ocurrio algun error de tipo DDE
            Select Case Err.Number                                            'Muestra la causa
                Case 298
                    MsgBox("No es posible carga la libreria LoadView32.DLL.", vbCritical, "Digitalización")
                Case 337
                    MsgBox("No se encuentra el Servidor de Objetos para Documentos Digitalizados.", vbCritical, "Digitalización")
                Case 47
                    MsgBox("No es posible mostrar la digitalización. Hay demasiadas ventadas abiertas.", vbCritical, "Digitalización")
                Case 48
                    MsgBox("No se ha instalado el visualizador de Documentos Digitalizados.", vbCritical, "Digitalización")
                Case 49
                    MsgBox("La versión del visualizador de Documentos Digitalizados es erronea.", vbCritical, "Digitalización")
                Case Else                                                       'No conoce la causa
                    MsgBox("Error inesperado: " & Err.Description, vbCritical, "Digitalización")
            End Select
        Else                                                                'No ocurrio ningun error de tipo DDE
            Select Case ln_Respuesta                                          'Evalua la respuesta del LoadView32
                Case 1, 2
                    MsgBox("No es posible establecer conexión con la base de datos.", vbCritical, "Digitalización")
                Case 5
                    MsgBox("No es posible mostrar el documento.", vbCritical, "Digitalización")
                Case 6 To 10
                    MsgBox("Los parametros de conexión con la base de datos son erroneos.", vbCritical, "Digitalización")
            End Select
        End If
    End Function

    'Implementaremos una función para consultar el origen del usuario para determinar 
    'si se debe traducir o no

    Public Function verificarTraduccion()
        On Error Resume Next

        Dim li_origenUsuario As Integer
        Dim row As DataRow
        Dim d As New Datasource
        Dim dt As New DataTable

        gs_Sql = "Select origen_usuario from CATALOGOS.dbo.usuario where usuario =  " + usuario.ToString()

        dt = d.RealizaConsulta(gs_Sql)

        If dt.Rows.Count <= 0 Then
            Exit Function
        End If

        row = dt.Rows(0)
        li_origenUsuario = row.Item("origen_usuario")

        If li_origenUsuario = 11 Then  'Agencia Houston = 11
            TRADUCE = True
        End If

    End Function


End Class
