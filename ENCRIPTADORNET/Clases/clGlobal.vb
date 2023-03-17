Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Screen

Public Class Cursors

    '-------------------------------------------------
    'Centra la forma pasada por parametro
    'Originalmente se encontraba en moddeclaraciones-Mesa y modMiscelaneas - Back
    'Agregada e identada por CEB 20-02-2002
    '-------------------------------------------------
    Public Sub Centerform(Forma As Form)

        Forma.Left = (Screen.PrimaryScreen.WorkingArea.Width - Forma.Width) / 2
        Forma.Top = (Screen.PrimaryScreen.WorkingArea.Height - Forma.Height) / 2
        If Forma.IsMdiChild Then
            If Forma.Height < (Screen.PrimaryScreen.WorkingArea.Height - 200) Then
                Forma.Top = Forma.Top - 500
            End If
        End If

    End Sub

    '--------------------------------------------------------------
    'Evalua el Codigo Ascii proporcionado y lo filtra segun el caso
    'Filtro: 1 = Solo numeros
    '        2 = Solo letras
    '        3 = Solo caracteres de fecha (0..9,-,/)
    '        4 = Solo caracteres de moneda (0..9,'.',',')
    '--------------------------------------------------------------
    Function Filtra(Codigo As Integer, Filtro As Byte) As Byte

        Filtra = Codigo
        'Excluye Tab, Enter, BackSpace y Espacio
        If (Codigo = 8) Or (Codigo = 9) Or
        (Codigo = 13) Or (Codigo = 32) Then
            Exit Function
        End If
        Select Case Filtro
            Case 1
                If (Codigo < 48) Or (Codigo > 57) Then
                    Filtra = 0
                End If
            Case 2
                If (Codigo < 65 Or Codigo > 90) Then
                    If (Codigo < 97) Or (Codigo > 122) Then
                        Filtra = 0
                    End If
                End If
            Case 3
                If (Codigo < 48) Or (Codigo > 57) Then
                    If (Codigo <> 45) And (Codigo <> 47) Then
                        Filtra = 0
                    End If
                End If
            Case 4
                If (Codigo < 48) Or (Codigo > 57) Then
                    If (Codigo <> 44) And (Codigo <> 46) Then
                        Filtra = 0
                    End If
                End If
            Case Else
                Filtra = 0
        End Select
    End Function

    '-------------------------------------------------
    'Pone en Highligth el Texto del Objeto Seleccioado
    '-------------------------------------------------
    Public Sub MarcaTexto(sender As Control)

        If (sender Is Nothing) Then Exit Sub
        If (TypeOf sender IsNot TextBox) Then Exit Sub
        If (sender.Text = String.Empty) Then Exit Sub

        'Obtenemos el TextBox que ejecutó en evento
        Dim txt As TextBox = CType(sender, TextBox)

        'Seleccionamos el texto del TextBox
        txt.SelectAll()

    End Sub

    '--------------------------------------------------------------------------
    Public Function ChecaTexto(ps_SourceString As String) As String
        'Public Function ChecaTexto(ps_SourceString As String, Optional pn_length As Integer) As String

        Dim i As Integer
        Dim c As String
        Dim ls_RetVal As String
        Dim ln_RetLen As Integer
        Dim pn_length As Integer

        If pn_length = 0 Then pn_length = Len(ps_SourceString)
        ln_RetLen = Len(ps_SourceString)
        If pn_length < ln_RetLen Then ln_RetLen = pn_length
        'ls_RetVal = String(ln_RetLen, vbNullChar)
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

    'quitar esta funcion despues de cambiar en el Back de Es_FechaY2K a EsFechaY2K
    Public Function EsFechaY2K(ByVal Fecha As String) As Boolean
        'Public Function EsFechaY2K(ByVal Fecha As String, Optional Orden) As Boolean

        Dim ls_Cadena As String

        EsFechaY2K = False
        ls_Cadena = Trim(Fecha)
        If Not IsDate(ls_Cadena) Then Exit Function
        'Si le falta un caracter al dia
        If Mid(ls_Cadena, 2, 1) = "-" Or Mid(ls_Cadena, 2, 1) = "/" Then
            ls_Cadena = "0" & ls_Cadena
        End If
        'Si le falta un caracter al mes
        If Mid(ls_Cadena, 5, 1) = "-" Or Mid(ls_Cadena, 5, 1) = "/" Then
            ls_Cadena = Left(ls_Cadena, 3) & "0" & Mid(ls_Cadena, 4, (Len(ls_Cadena) - 3))
        End If
        If Len(ls_Cadena) <> 10 Then Exit Function
        'If Not IsMissing(Orden) Then
        '    If Val(Orden) <> 0 Then
        '        If Val(Left(ls_Cadena, 2)) > 12 Then Exit Function
        '    Else
        '        If Val(Mid(ls_Cadena, 4, 2)) > 12 Then Exit Function
        '    End If
        'Else
        '    If Val(Mid(ls_Cadena, 4, 2)) > 12 Then Exit Function
        'End If
        EsFechaY2K = True
    End Function

    '----------------------------------------------------------------------------
    'Devuelve la fecha con formato dd-mm-yyyy si el parametro es una fecha valida
    '----------------------------------------------------------------------------
    Public Function FechaY2K(ByVal Fecha As String) As String

        Dim ls_Cadena As String

        FechaY2K = Trim(Fecha)
        ls_Cadena = Trim(Fecha)
        'Si no es una fecha valida, termina
        If Not IsDate(Fecha) Then Exit Function
        'Si le falta un caracter al dia
        If Mid(ls_Cadena, 2, 1) = "-" Or Mid(ls_Cadena, 2, 1) = "/" Then
            ls_Cadena = "0" & ls_Cadena
        End If
        'Si le falta un caracter al mes
        If Mid(ls_Cadena, 5, 1) = "-" Or Mid(ls_Cadena, 5, 1) = "/" Then
            ls_Cadena = Left(ls_Cadena, 3) & "0" & Mid(ls_Cadena, 4, 4)
        End If
        FechaY2K = Left(ls_Cadena, 6) & DatePart("yyyy", FechaY2K)
    End Function

    '--------------------------------------------------------------------------------------
    'Invierte la entre los formatos dd-mm-yy y mm-dd-yy si el parametro es una fecha valida
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
            ls_Cadena = Left(ls_Cadena, 3) & "0" & Mid(ls_Cadena, 4, 4)
        End If
        InvierteFecha = Mid(ls_Cadena, 4, 3) & Left(ls_Cadena, 3) & DatePart("yyyy", InvierteFecha)
    End Function

    '------------------------------------------------------------------------------------------
    'Devuelve una fecha habil en formato dd-mm-yyyy (resta o suma dias habiles a la fecha dada)
    '------------------------------------------------------------------------------------------
    Public Function FechaOpera(ByVal Fecha As String, ByVal nDias As String) As String
        'Public Function FechaOpera(ByVal Fecha As String, Optional nDias As String) As String
        Dim ls_Cadena As String
        Dim ln_Dias As String
        Dim d As New Datasource
        Dim dtDatos As DataTable
        Dim l As New Libreria

        FechaOpera = Trim(Fecha)
        ls_Cadena = Trim(Fecha)
        'Si no es una fecha valida, termina
        If Not IsDate(Fecha) Then Exit Function
        'Verifica si se desea sumar o restar dias
        If nDias.ToString.Trim <> 0 Then
            'If Not IsMissing(nDias) Then
            ln_Dias = Val(nDias)
        Else
            ln_Dias = 0
        End If
        'Hace la operacion con la fecha
        ls_Cadena = DateAdd(DateInterval.Day, CDbl(ln_Dias), CDate(ls_Cadena))
        'ls_Cadena = DateAdd("d", ln_Dias, ls_Cadena)
        'Si le falta un caracter al dia
        If Mid(ls_Cadena, 2, 1) = "-" Or Mid(ls_Cadena, 2, 1) = "/" Then
            ls_Cadena = "0" & ls_Cadena
        End If
        'Si le falta un caracter al mes
        If Mid(ls_Cadena, 5, 1) = "-" Or Mid(ls_Cadena, 5, 1) = "/" Then
            ls_Cadena = Left(ls_Cadena, 3) & "0" & Left(ls_Cadena, 6)
        End If

VerificaDiasFeriados:

        dtDatos = d.VerificaDiasFeriados(ls_Cadena)

        If Not IsNothing(dtDatos) Then

            If dtDatos.Rows.Count > 0 Then
                'Si la fecha calculada no es un dia feriado
                If Val(dtDatos.Rows(0).Item(0)) = 0 Then
                    FechaOpera = Left(ls_Cadena, 6) & DatePart("yyyy", ls_Cadena)
                    'FechaOpera = ValidaFormato(FechaOpera, "")
                    'FechaOpera = ValidaFormato(FechaOpera)
                    'FechaOpera = Replace(FechaOpera, "/", "-")
                    Exit Function
                    'Si la fecha calculada es un dia feriado
                Else
                    If ln_Dias >= 0 Then
                        'Agrega un dia y verifica si es feriado
                        ls_Cadena = DateAdd(DateInterval.Day, 1, CDate(ls_Cadena))
                        'ls_Cadena = DateAdd("d", 1, ls_Cadena)
                    Else
                        'Resta un dia y verifica si es feriado
                        ls_Cadena = DateAdd(DateInterval.Day, -1, CDate(ls_Cadena))
                        'ls_Cadena = DateAdd("d", -1, ls_Cadena)
                    End If
                    GoTo VerificaDiasFeriados
                End If
            Else
                MsgBox("No se puede leer la tabla CATALOGOS.dbo.DIAS_FERIADOS en " & l.SERVER & ".", vbCritical, "Error")
                Exit Function
            End If
        Else

            MsgBox("No se puede leer la tabla CATALOGOS.dbo.DIAS_FERIADOS en " & l.SERVER & ".", vbCritical, "Error")
            Exit Function

        End If

    End Function



    '----------------------------------------------------
    'Despliega un mensaje Informativo
    'Agregada por: 
    '----------------------------------------------------
    Public Sub InfoBox(mensaje As String)

    End Sub

    '-------------------------------------------------------------------------------------
    'Attribute fgMnemonico.VB_Description
    '"Obtiene el mnemonico de máximo 9 caracteres de la cadena enviada"
    'Devolvemos el mnemonico del texto enviado
    '-------------------------------------------------------------------------------------
    Public Function fgMnemonico(ByVal sTexto As String, ByVal sCuenta As String, ByVal sAgencia As String) As String

        Dim iPrimera As Integer
        Dim iPalabras As Integer
        Dim sMnemonico As String
        Dim iPos As Long

        sTexto = fgSinPuntuacion(sTexto)
        sTexto = fgSinPreposiciones(sTexto)
        sTexto = fgMenores(sTexto)
        sTexto = fgReemplazaCia(sTexto)

        iPalabras = fgCuentaPalabras(sTexto)

        'Si empieza con números, asumimos la regla de aplicación para cuentas contables
        If IsNumeric(Left$(sTexto, 1)) Then
            iPrimera = fgPrimeraLetra(sTexto)
            iPalabras = fgCuentaPalabras(sTexto)
            sMnemonico = Left$(sTexto, IIf(iPrimera >= 4, 4, iPrimera))
            If iPalabras = 1 Then
                sMnemonico = sMnemonico & Mid$(sTexto, iPrimera, 5)
            Else
                sMnemonico = sMnemonico & Mid$(sTexto, iPrimera, 3)
                iPos = InStr(iPrimera, sTexto, " ")
                sMnemonico = sMnemonico & Mid$(sTexto, iPos + 1, 2)
            End If
        Else
            Select Case iPalabras
                Case 1
                    sMnemonico = Trim(Left$(sTexto, 9))
                Case 2
                    iPrimera = fgPosicionPalabra(sTexto, 2)
                    sMnemonico = Trim(Left$(sTexto, IIf(iPrimera > 5, 5, iPrimera - 1)))
                    'Posición de la segunda palabra
                    iPos = InStr(1, sTexto, " ")
                    sMnemonico = sMnemonico & Trim(Left$(Mid$(sTexto, iPos + 1), 4))
                Case Else
                    iPrimera = fgPosicionPalabra(sTexto, 2)
                    sMnemonico = Trim(Left$(sTexto, IIf(iPrimera > 3, 3, iPrimera - 1)))
                    sTexto = Trim(Mid$(sTexto, iPrimera))
                    'Posición de la segunda palabra
                    iPrimera = fgPosicionPalabra(sTexto, 2)
                    sMnemonico = sMnemonico & Trim(Left$(sTexto, IIf(iPrimera > 3, 3, iPrimera - 1)))
                    sTexto = Trim(Mid$(sTexto, iPrimera))
                    'Posición de la segunda palabra
                    iPrimera = fgPosicionPalabra(sTexto, 2)
                    'Fueron exactamente 3 palabras
                    If iPrimera = 0 Then
                        iPrimera = Len(sTexto)
                    End If
                    sMnemonico = sMnemonico & Trim(Left$(sTexto, IIf(iPrimera > 3, 3, iPrimera - 1)))
            End Select
        End If
        'Aplicamos la última regla, anteponer la constante "21"
        If Len(sMnemonico) > 7 Then
            sMnemonico = Trim(Left$(sMnemonico, 7))
        End If
        sMnemonico = "21" & sMnemonico
        fgMnemonico = FGUnico(Trim(sMnemonico), "mnemonico", sCuenta, sAgencia)
    End Function


    '-------------------------------------------------------------------------------------------------------------
    'Attribute fgShortName.VB_Description = "Obtiene el nombre corto de máximo 16 caracteres de la cadena enviada"
    'Devolvemos el short name del texto enviado
    '-------------------------------------------------------------------------------------------------------------
    Public Function fgShortName(ByVal sTexto As String, ByVal sCuenta As String, ByVal sAgencia As String) As String
        Dim iPalabras As Integer
        Dim iPos As Long
        Dim sShortName As String

        iPalabras = 0
        iPos = 0
        sShortName = ""
        sTexto = fgSinPuntuacion(sTexto)
        sTexto = fgSinPreposiciones(sTexto)
        sTexto = fgMenores(sTexto)
        sTexto = fgReemplazaCia(sTexto)
        iPalabras = fgCuentaPalabras(sTexto)
        Select Case iPalabras
            Case 1
                sShortName = Trim(Left$(sTexto, 16))
            Case 2
                iPos = fgPosicionPalabra(sTexto, 2)
                sShortName = Trim(Left$(sTexto, IIf(iPos > 8, 8, iPos - 1))) & "-"
                sShortName = sShortName & Trim(Mid$(sTexto, iPos, 6))
            Case Else
                iPos = fgPosicionPalabra(sTexto, 2)
                sShortName = Trim(Left$(sTexto, IIf(iPos > 5, 5, iPos - 1))) & "-"
                sTexto = Mid$(sTexto, iPos)
                iPos = fgPosicionPalabra(sTexto, 2)
                sShortName = sShortName & Trim(Left$(sTexto, IIf(iPos > 5, 5, iPos - 1))) & "-"
                sTexto = Mid$(sTexto, iPos)
                iPos = fgPosicionPalabra(sTexto, 2)
                'Fueron tres palabras exactamente
                If iPos = 0& Then
                    sShortName = sShortName & Trim(Left$(sTexto, 3))
                Else
                    sShortName = sShortName & Trim(Left$(sTexto, IIf(iPos > 3, 4, iPos - 1)))
                End If
        End Select
        fgShortName = FGUnico(sShortName, "shortname", sCuenta, sAgencia)

    End Function


    '-------------------------------------------------------------------
    'Quitamos la puntuación (puntos y comas) del texto enviado
    '-------------------------------------------------------------------
    Public Function fgSinPuntuacion(ByVal sTexto As String) As String

        'Caracteres a eliminar
        Const PUNTOS = ".,;:"
        'Caracteres a reemplazar por espacio en blanco
        Const REEMPLAZO = "-/"

        Dim iPos As Long
        Dim iCount As Integer

        sTexto = Trim(sTexto)
        sTexto = UCase(sTexto)
        For iCount = 1 To Len(PUNTOS)
            Do
                iPos = InStr(1, sTexto, Mid$(PUNTOS, iCount, 1))
                If iPos > 0 Then
                    sTexto = Left$(sTexto, iPos - 1) & Mid$(sTexto, iPos + 1)
                End If
            Loop Until iPos = 0
        Next
        For iCount = 1 To Len(REEMPLAZO)
            Do
                iPos = InStr(1, sTexto, Mid$(REEMPLAZO, iCount, 1))
                If iPos > 0 Then
                    Mid$(sTexto, iPos, 1) = " "
                End If
            Loop Until iPos = 0
        Next
        sTexto = fgUnEspacio(sTexto)
        fgSinPuntuacion = Trim(sTexto)
    End Function

    '--------------------------------------------------------------------------------
    'Quitamos los espacios excedentes entre el texto enviado
    '--------------------------------------------------------------------------------
    Public Function fgUnEspacio(ByVal sTexto As String) As String

        Dim sTemp As String = ""
        Dim iPos As Long

        sTexto = Trim(sTexto)
        Do While Len(sTexto) > 0
            iPos = InStr(1, sTexto, " ")
            If iPos = 0 Then
                iPos = Len(sTexto) + 1
            End If
            sTemp = sTemp & Trim(Left$(sTexto, iPos - 1)) & " "
            sTexto = Trim(Mid$(sTexto, iPos))
        Loop
        fgUnEspacio = Trim(sTemp)
    End Function

    '-----------------------------------------------------------------------------------------
    'Verificamos que "lsTexto" no exista dentro de la tabla de "Clientes" en el campo "sField"
    'Si este campo es omitido, asumimos que se trata del mnemonico
    '-----------------------------------------------------------------------------------------
    Function FGUnico(ByVal lsTexto As String, ByVal lsField As String, ByVal lsCuenta As String, ByVal lsAgencia As String) As String
        Dim cSQL As String
        Dim sNum As String
        Dim iCuenta As Integer
        Dim d As New Datasource
        Dim dtDatos As DataTable
        Dim Respuesta As Integer

        If lsField.ToString.Trim = "" Then
            'If IsMissing(sField) Then
            lsField = "mnemonico"
        End If
        If lsCuenta.ToString.Trim = "" Then
            lsCuenta = ""
        Else
            lsCuenta = Trim(lsCuenta)
        End If
        If lsAgencia.ToString.Trim = "" Then
            lsAgencia = ""
        Else
            lsAgencia = Trim(lsAgencia)
        End If

        Do
            cSQL = "Select Count (*) From CATALOGOS..CLIENTE Where " & lsField & " = '" & lsTexto & "'"
            Respuesta = d.ConsultaQuery(cSQL)
            If Respuesta > 0 Then
                If Respuesta = 0 Then
                    Exit Do
                End If
            Else
                Exit Do
            End If
            iCuenta = iCuenta + 1
            sNum = Trim(CStr(iCuenta))
            If Len(lsTexto) + Len(sNum) <= 9 Then
                lsTexto = lsTexto & sNum
            Else
                lsTexto = Left$(lsTexto, Len(lsTexto) - Len(sNum))
                lsTexto = lsTexto & sNum
            End If
        Loop
        FGUnico = lsTexto
    End Function

    '----------------------------------------------------------------
    'Eliminamos las preposiciones
    '----------------------------------------------------------------
    Public Function FgSinPreposiciones(ByVal sTexto As String) As String

        Dim cSQL As String
        Dim sPrep As String
        Dim d As New Datasource
        Dim dtDatos As DataTable

        sTexto = UCase(sTexto)
        cSQL = "Select pre_texto From CATALOGOS..PREPOSICION Where pre_status <> 9"
        dtDatos = d.Consulta(cSQL, "fgSinPreposiciones01")
        'Error al intentar leer la tabla
        If dtDatos.Rows.Count <= 0 Then
            FgSinPreposiciones = fgSinEmpresa(sTexto)
            Exit Function
        End If

        Dim renglon As Integer
        renglon = 0
        For Each rows As DataRow In dtDatos.Rows
            sPrep = dtDatos.Rows(renglon).Item(0).ToString
            'La palabra entre espacios
            sPrep = " " & Trim(UCase(sPrep)) & " "
            sTexto = fgQuitaPalabras(sTexto, sPrep)
            'Leemos la siguiente empresa
            renglon = renglon + 1
        Next
        'Quitamos los tipos de empresa o sociedad
        FgSinPreposiciones = fgSinEmpresa(sTexto)
    End Function


    '-----------------------------------------------------------------------------
    'Eliminamos los tipos de empresa
    'Originalmente se encontraba en modComunes
    'Agregada e identada por CEB 20-02-2002
    '-----------------------------------------------------------------------------
    Function fgSinEmpresa(ByVal sTexto As String) As String
        Dim cSQL As String
        Dim sPrep As String
        Dim d As New Datasource
        Dim dtDatos As DataTable

        sTexto = UCase(sTexto)
        cSQL = "Select tipo_sociedad From CATALOGOS..TIPO_SOCIEDAD"
        dtDatos = d.Consulta(cSQL, "fgSinEmpresa01")
        If dtDatos.Rows.Count <= 0 Then
            fgSinEmpresa = Trim(sTexto)
            Exit Function
        End If

        Dim renglon As Integer
        renglon = 0
        For Each rows As DataRow In dtDatos.Rows
            sPrep = dtDatos.Rows(renglon).Item(0).ToString
            'La palabra entre espacios
            sPrep = " " & Trim(UCase(sPrep)) & " "
            sTexto = fgQuitaPalabras(sTexto, sPrep)
            'Leemos la siguiente empresa
            renglon = renglon + 1
        Next
        fgSinEmpresa = Trim(sTexto)
    End Function


    '---------------------------------------------------------------------------
    'Quitamos la palabra deseada si se encuentra dentro del texto
    '---------------------------------------------------------------------------
    Public Function fgQuitaPalabras(ByVal sTexto As String, ByVal sPalabra As String) As String
        Dim iPos As Long

        'Buscamos la palabra en la primera posición dentro del texto
        Do
            If Left$(sTexto & " ", Len(Trim(sPalabra)) + 1) = (Trim(sPalabra) & " ") Then
                sTexto = Trim(Mid$(sTexto, Len(sPalabra) - 1))
            Else
                Exit Do
            End If
        Loop
        'Buscamos la palabra dentro del cuerpo del texto
        Do
            iPos = InStr(1, sTexto & " ", sPalabra)
            If iPos > 0 Then
                sTexto = Left$(sTexto, iPos) & Mid$(sTexto, iPos + Len(sPalabra))
            End If
        Loop Until iPos = 0
        fgQuitaPalabras = Trim(sTexto)
    End Function

    '-------------------------------------------------------------------------------
    'Quitamos cualquier palabra dentro del texto que sea menor a tres caracteres
    'Originalmente se encontraba en modComunes
    'Agregada e identada por CEB 20-02-2002
    '-------------------------------------------------------------------------------
    Function fgMenores(ByVal sTexto As String) As String
        Dim iCuenta As Integer
        Dim iPos As Long
        Dim sTemp As String
        Dim sWord As String
        Do
            iPos = InStr(1, sTexto, " ")
            If iPos = 0 Then
                'Es la única palabra, se queda sin importar su tamaño
                If iCuenta = 0 Then
                    sTemp = sTexto
                    Exit Do
                Else
                    iPos = Len(sTexto) + 1
                End If
            End If
            sWord = Trim(Left$(sTexto, iPos - 1))
            If Len(sWord) >= 3 Then
                sTemp = sTemp & sWord & " "
            End If
            sTexto = Trim(Mid$(sTexto, iPos))
            iCuenta = iCuenta + 1
        Loop While Len(sTexto) > 0
        fgMenores = Trim(sTemp)
    End Function

    '--------------------------------------------------------------------------------------
    'Esta función reemplaza la palabra COMPAÑIA por la abreviatura CIA, si y solo si, se
    'encuentra como primer palabra del string
    '--------------------------------------------------------------------------------------
    Function fgReemplazaCia(ByVal sTexto As String) As String
        'Dim iPos As Long

        If Left$(sTexto, 8) = "COMPAÑIA" Then
            sTexto = "CIA" & Mid$(sTexto, 9)
        End If
        fgReemplazaCia = sTexto
    End Function

    '----------------------------------------------------------------------
    'Contamos el número de palabras que tiene el texto enviado
    '----------------------------------------------------------------------
    Public Function fgCuentaPalabras(ByVal sTexto As String) As Integer
        Dim iCount As Integer
        Dim iPos As Long

        iPos = 0&
        sTexto = Trim(sTexto)
        'De entrada cuenta con una palabra
        If Len(sTexto) > 0 Then
            iCount = 1
        End If
        Do
            'iPos = InStr(iPos + 1, sTexto, " ")
            iPos = InStr((iPos + 1), sTexto, " ", CompareMethod.Text)
            iCount = iCount + IIf(iPos = 0&, 0, 1)
        Loop Until iPos = 0&
        fgCuentaPalabras = iCount
    End Function


    '-------------------------------------------------------------------
    'Devolvemos la posición del primer caracter alfabetico
    '-------------------------------------------------------------------
    Public Function fgPrimeraLetra(ByVal sTexto As String) As Long
        Dim iPos As Long
        sTexto = UCase(sTexto)
        For iPos = 1 To Len(sTexto)
            If Asc(Mid$(sTexto, iPos, 1)) >= Asc("A") And Asc(Mid$(sTexto, iPos, 1)) <= Asc("Z") Then
                fgPrimeraLetra = iPos
                Exit For
            End If
        Next
        fgPrimeraLetra = iPos
    End Function


    '--------------------------------------------------------------------------------
    'Determinamos la posición inicial dentro de "sTexto" de la palabra "iPalabra"
    'Si se regresa un cero, es que no existe ese número de palabra dentro del texto.
    '--------------------------------------------------------------------------------
    Public Function fgPosicionPalabra(ByVal sTexto As String, ByVal iPalabra As Integer) As Long
        Dim iCount As Integer
        Dim iPos As Long

        iPos = 0&
        iCount = 1
        If iPalabra = 1 Then
            'La posición de la primer palabra depende si es un string nulo o no
            If Len(sTexto) > 0 Then
                fgPosicionPalabra = 1&
            Else
                fgPosicionPalabra = 0&
            End If
            Exit Function
        End If
        Do
            'iPos = InStr(iPos + 1, sTexto, " ")
            iPos = InStr((iPos + 1), sTexto, " ", CompareMethod.Text)
            If iPos > 0& Then
                iCount = iCount + 1
            End If
        Loop Until (iCount = iPalabra) Or (iPos = 0&)
        'Si al final iPos = 0 es que la frase tiene menos palabras que la buscada
        fgPosicionPalabra = IIf(iPos = 0&, 0&, iPos + 1&)
    End Function

    Public Function ValidaFormato(ByVal strFecha As String, ByVal strFormato As String) As String
        'Public Function ValidaFormato(ByVal strFecha As String, Optional ByVal strFormato As String) As String

        Dim aux As String, aux2 As String,
        PrimerBloque As String, SegundoBloque As String, TercerBloque As String,
        intNumeros As Integer, intFormato As Integer

        Dim arrTemporal() As String
        Dim sBuffer As String, lBufferLen As Long, i As Integer

        PrimerBloque = ""
        SegundoBloque = ""
        TercerBloque = ""

        If strFormato = "" Then
            lBufferLen = 50
            sBuffer = Space(lBufferLen)
            'GetLocaleInfo(LOCALE_USER_DEFAULT, Base2Long("1F", 16), sBuffer, lBufferLen)
            'strFormato = Left(sBuffer, InStr(sBuffer, Chr(0)) - 1)
        End If

        'Obtener los primero numeros antes de el separador
        intNumeros = 1
        aux = Mid(strFecha, intNumeros, 1)
        While IsNumeric(aux)
            PrimerBloque = PrimerBloque & aux
            intNumeros = intNumeros + 1
            aux = Mid(strFecha, intNumeros, 1)
        End While

        'Obtener la primera letra del formato de fecha
        intFormato = 1
        aux2 = UCase(Mid(strFormato, intFormato, 1))
        aux = UCase(Mid(strFormato, intFormato, 1))
        While aux = "D" Or aux = "M" Or aux = "Y"
            aux2 = UCase(Mid(strFormato, intFormato, 1))
            intFormato = intFormato + 1
            aux = UCase(Mid(strFormato, intFormato, 1))
        End While

        'Valida longitud de los campos
        If aux2 = "D" Or aux2 = "M" Then
            PrimerBloque = StrDup(2 - Len(PrimerBloque), "0") & PrimerBloque
            'PrimerBloque = String(2 - Len(PrimerBloque), "0") & PrimerBloque
            '               replica el caracter N veces
        Else
            If Len(PrimerBloque) <> 4 Then
                PrimerBloque = Format(PrimerBloque, "20##")
            End If
        End If

        PrimerBloque = aux2 & "." & PrimerBloque
        strFormato = Mid(strFormato, intFormato + 1)

        'Obtener el segundo bloque despues del separador
        strFecha = Mid(strFecha, intNumeros + 1)
        intNumeros = 1
        aux = Mid(strFecha, intNumeros, 1)
        While IsNumeric(aux)
            SegundoBloque = SegundoBloque & aux
            intNumeros = intNumeros + 1
            aux = Mid(strFecha, intNumeros, 1)
        End While

        'Obtener la primera letra del formato de fecha
        intFormato = 1
        aux2 = UCase(Mid(strFormato, intFormato, 1))
        aux = UCase(Mid(strFormato, intFormato, 1))
        While aux = "D" Or aux = "M" Or aux = "Y"
            aux2 = UCase(Mid(strFormato, intFormato, 1))
            intFormato = intFormato + 1
            aux = UCase(Mid(strFormato, intFormato, 1))
        End While

        'Valida longitud de los campos
        If aux2 = "D" Or aux2 = "M" Then
            SegundoBloque = StrDup(2 - Len(SegundoBloque), "0") & SegundoBloque
        Else
            If Len(SegundoBloque) <> 4 Then
                SegundoBloque = Format(SegundoBloque, "20##")
            End If
        End If

        SegundoBloque = aux2 & "." & SegundoBloque
        strFormato = Mid(strFormato, intFormato + 1)

        'Obtener el tercer bloque despues del separador
        strFecha = Mid(strFecha, intNumeros + 1)
        intNumeros = 1
        aux = Mid(strFecha, intNumeros, 1)
        While IsNumeric(aux)
            TercerBloque = TercerBloque & aux
            intNumeros = intNumeros + 1
            aux = Mid(strFecha, intNumeros, 1)
        End While

        'Obtener la primera letra del formato de fecha
        intFormato = 1
        aux2 = UCase(Mid(strFormato, intFormato, 1))
        aux = UCase(Mid(strFormato, intFormato, 1))
        While aux = "D" Or aux = "M" Or aux = "Y"
            aux2 = UCase(Mid(strFormato, intFormato, 1))
            intFormato = intFormato + 1
            aux = UCase(Mid(strFormato, intFormato, 1))
        End While

        'Valida longitud de los campos
        If aux2 = "D" Or aux2 = "M" Then
            TercerBloque = StrDup(2 - Len(TercerBloque), "0") & TercerBloque
        Else
            If Len(TercerBloque) <> 4 Then
                TercerBloque = Format(TercerBloque, "20##")
            End If
        End If

        TercerBloque = aux2 & "." & TercerBloque

        lBufferLen = 50
        sBuffer = Space(lBufferLen)
        'If (GetLocaleInfo(LOCALE_USER_DEFAULT, Base2Long("1F", 16), sBuffer, lBufferLen)) Then
        '    aux = Left(sBuffer, InStr(sBuffer, Chr(0)) - 1)

        '    strFecha = "D-M-Y"

        '    arrTemporal = Split(PrimerBloque, ".")
        '    strFecha = Replace(strFecha, UCase(arrTemporal(0)), arrTemporal(1))

        '    Erase arrTemporal
        '    arrTemporal = Split(SegundoBloque, ".")
        '    strFecha = Replace(strFecha, UCase(arrTemporal(0)), arrTemporal(1))

        '    Erase arrTemporal
        '    arrTemporal = Split(TercerBloque, ".")
        '    strFecha = Replace(strFecha, UCase(arrTemporal(0)), arrTemporal(1))
        '    ValidaFormato = strFecha
        'End If
    End Function


    Public Function Base2Long(s As String, ByVal nB As Integer) As Long
        Dim s2 As String
        Dim i As Long
        Dim j As Long
        Dim X As Long
        Dim n As Boolean
        Dim s3 As String

        If Len(s) < 1 Then
            Base2Long = 0
            Exit Function
        End If

        s2 = UCase(s)

        If Left$(s2, 1) = "-" Then
            n = True
            s2 = Right$(s2, Len(s2) - 1)
        Else
            n = False
        End If

        j = 1
        X = 0

        For i = Len(s2) To 1 Step -1
            s3 = Mid$(s2, i, 1)
            Select Case s3
                Case "0" To "9"
                    X = X + j * (Asc(s3) - 48)
                Case "A" To "Z"
                    X = X + j * (Asc(s3) - 55)
            End Select

            j = j * nB
        Next i

        If n Then
            X = -X
        End If

        Base2Long = X
    End Function


    Public Const LOCALE_USER_DEFAULT = &H400 'presentar información del usuario
    Declare Function GetLocaleInfo Lib "kernel32" Alias "GetLocaleInfoA" (ByVal Locale As Long, ByVal LCType As Long, ByVal lpLCData As String, ByVal cchData As Long) As Long



End Class
