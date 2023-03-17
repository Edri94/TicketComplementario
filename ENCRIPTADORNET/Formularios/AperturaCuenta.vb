Imports VB = Microsoft.VisualBasic
Public Class AperturaCuenta

    Dim TipoCliente As String = ""
    'TipoPersona :  Persona Moral = "1", Persona Fisica = "0"
    Dim sTipoPersona As String = "1"

    Dim FunCte As String

    Private Sub AperturaCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim d As New Datasource
        Dim dtTipoCliente As DataTable

        Me.CenterToScreen()

        txAgencia.Text = "HOUSTON"
        txAgencia.Enabled = False
        CkConfirme.Checked = True
        CkConfirme.Enabled = False
        CkConfirme.Visible = False

        lbTicket.Visible = False
        txTicket.Visible = False
        txTicket.Enabled = False

        optCta100.Checked = True
        CkPersonaMoral.Checked = True
        'CkFideicomiso.Checked = True

        CkFideicomiso.Enabled = True

        'Llena combo Tipo de Cliente
        dtTipoCliente = d.DatosTipoCliente

        ddlTipoCliente.Visible = True
        ddlTipoCliente.DisplayMember = "descripcion_tipo_cliente"
        ddlTipoCliente.ValueMember = "tipo_cliente"
        ddlTipoCliente.DataSource = dtTipoCliente

    End Sub


    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Dim d As New Datasource
        Dim l As New Libreria
        Dim Registro As Integer
        Dim Reg_Fideicomiso As Integer
        Dim Reg_Concepto As Integer
        Dim iActualizaConsecutivos As Integer
        Dim sCampoConsecutivo As String

        '**** Parametro de entrada para el insert  **************************************
        Dim sCuenta_cliente As String
        Dim sNombre As String
        Dim sApellidoPat As String = ""
        Dim sApellidoMat As String = ""

        ' FunCte : variable a nivel formulario
        ' TipoCliente : variable a nivel formulario
        Dim sCuentaejepesos As String
        Dim iTipoCuentaEje As Integer
        Dim sMnemonico As String
        Dim sShortName As String
        Dim sFechaCtaEje As String
        Dim sLinea As String
        Dim sGrabadora As String
        Dim sContacto As String

        Dim dtProductoContratado As DataTable
        Dim iProductoContratado As Integer
        Dim Concepto As String
        Dim dtConcepto As DataTable
        Dim Reg_CuentaEje As Integer

        Dim dtOperacion As DataTable
        Dim dtOperacionDefinida As DataTable
        Dim iOperacionDefinida As Integer
        Dim iOperacion As Integer
        ''**** Parametro de entrada para el insert ...Fin ********************************

        Try
            If Not DatosCorrectos() Then
                Exit Sub
            End If

            sCampoConsecutivo = VB.Left(txNombre.Text, 1).ToUpper()
            'MsgBox("sCuenta_cliente antes de asignacion:" & sCuenta_cliente)
            sCuenta_cliente = CuentaClientePropuesto()
            'MsgBox("sCuenta_cliente con asignacion:" & sCuenta_cliente)

            'Parametros de entrada para insertar en al tabla cliente**********************
            sNombre = txNombre.Text
            If CkPersonaFisica.Checked Then
                sApellidoPat = txApellidoPat.Text
                sApellidoMat = txApellidoMat.Text
            End If
            sCuentaejepesos = txCuentaEjePesos.Text
            sMnemonico = fgMnemonico(txNombre.Text)
            sShortName = fgShortName(txNombre.Text)
            'sFechaCtaEje = l.InvierteFecha(txFechaCtaEje.Text)
            sFechaCtaEje = DTPicker.Value.ToString("yyyy-MM-dd")
            sLinea = 0 'txLineaTel.Text
            sGrabadora = 0 'txGrabadora.Text
            sContacto = ddlGestores.Text

            If optCta100.Checked Then
                iTipoCuentaEje = 2 'Tipo de cuenta para persona moral: CHEQUES S/INTERESES 
                sTipoPersona = "1"
            ElseIf optCta687.Checked Then
                iTipoCuentaEje = 3 'Tipo de cuenta para persona fisica: NOW ACCOUNT
                sTipoPersona = "0"
            ElseIf optCta000.Checked Then
                iTipoCuentaEje = 4 'Tipo de cuenta para persona fisica: INVERSION
                sTipoPersona = "0"
            End If

            'Parametros de entrada para insertar en al tabla cliente ...Fin **************

            'Actualiza Consecutivo
            iActualizaConsecutivos = d.ActualizaConsecutivos(sCampoConsecutivo, sCuenta_cliente)

            'Insert de cliente
            Registro = d.InsertaCliente(sCuenta_cliente, sNombre, FunCte, TipoCliente, sCuentaejepesos, sMnemonico, sShortName, sFechaCtaEje, sApellidoPat, sApellidoMat, sTipoPersona)

            If CkFideicomiso.Checked Then
                'Insert de cliente fideicomiso
                Reg_Fideicomiso = d.InsertaClienteFideicomiso(sCuenta_cliente)
            End If

            'Insert de producto contratado
            dtProductoContratado = d.InsertaProductoContratado(sCuenta_cliente)
            iProductoContratado = dtProductoContratado.Rows(0).Item(0)

            'Insert de cuenta eje
            Reg_CuentaEje = d.InsertaCuentaEje(iProductoContratado, iTipoCuentaEje)

            'Insert de operacion
            dtOperacionDefinida = d.ObtenerOperacionDefinida
            iOperacionDefinida = dtOperacionDefinida.Rows(0).Item(0)
            dtOperacion = d.InsertaOperacion(iProductoContratado, iOperacionDefinida, sLinea, sGrabadora, FunCte, sContacto)
            iOperacion = dtOperacion.Rows(0).Item(0)
            txTicket.Text = Format(iOperacion, "0000000")

            'Insert de conceptos 
            dtConcepto = d.ObtenerConcepto
            Concepto = dtConcepto.Rows(0).Item(0)
            dtConcepto.Clear()
            Reg_Concepto = d.InsertaConcepto(iProductoContratado, Concepto)


            If Registro > 0 And Reg_Concepto > 0 And iProductoContratado > 0 And Reg_CuentaEje > 0 Then
                MsgBox("La cuenta ha sido registrada correctamente!, con el Ticket: " & iOperacion)
                lbTicket.Visible = True
                txTicket.Visible = True
                txTicket.Enabled = False
                LimpiarCampos()
            Else
                MsgBox("Ha ocurrido una inconsistencia al momento se guardar en base de datos.", vbInformation, "Error")
            End If

        Catch ex As Exception
            MsgBox("Ocurrio un error al momento de guardar!" & ex.Message)
            Exit Sub
        End Try


    End Sub

    Private Sub txNombre_Leave(sender As Object, e As EventArgs) Handles txNombre.Leave
        'Se coloca una cuenta cliente propuesta para la apertura.
        If txNombre.Text <> String.Empty Then
            Dim d As New Datasource
            LimpiarCuentaTicket()
            txtCuenta.Text = CuentaClientePropuesto()

            'Agregar validacion para saber si ya existe la cuenta
            Dim ExisteCuenta As String
            ExisteCuenta = d.ExisteCuenta(txtCuenta.Text.Trim())

            If Convert.ToInt32(ExisteCuenta) > 0 Then
                MsgBox("La cuenta ya existe favor de verificar", vbInformation, "Validación")
                Exit Sub
            End If

            txtCuenta.Enabled = False
            CkConfirme.Focus()
        End If
    End Sub

    Private Sub txCuentaEje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txCuentaEjePesos.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ddlTipoCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTipoCliente.SelectedIndexChanged
        TipoCliente = ddlTipoCliente.SelectedValue
        txNombre.Focus()
    End Sub


    'Private Sub txConcertador_Leave(sender As Object, e As EventArgs)
    '    If TXConcertador.Text <> String.Empty Then
    '        Dim d As New Datasource
    '        Dim dtDatosGestor As New DataTable

    '        Try
    '            dtDatosGestor = d.SPGestor(TXConcertador.Text.Trim(), "")
    '            ddlConcertador.Text = dtDatosGestor.Rows(0).Item(1).trim()
    '            ddlConcertador.Focus()
    '        Catch ex As Exception
    '            MsgBox("El numero de funcionario no es valido, favor de seleccionar un funcionario existente")
    '            TXConcertador.Focus()
    '            Exit Sub
    '        End Try

    '    End If
    'End Sub

    'Private Sub ddlGestores_DropDown(sender As Object, e As EventArgs)
    '    'Llena combo nombre de Gestores
    '    Dim d As New Datasource
    '    Dim dtGestores As DataTable

    '    dtGestores = d.DatosGestores(ddlGestores.Text)

    '    ddlGestores.Visible = True
    '    ddlGestores.DisplayMember = "nombre"
    '    ddlGestores.ValueMember = "funcionario"
    '    ddlGestores.DataSource = dtGestores
    'End Sub

    Private Sub ddlGestores_SelectedIndexChanged(sender As Object, e As EventArgs)
        If ddlGestores.SelectedIndex > 0 Then

            Dim d As New Datasource
            Dim dtDatosGestor As New DataTable
            Dim indexGestor As Integer
            Dim dtRutaGestor As New DataTable
            Dim ruta As String = ""
            Dim campo0 As String
            Dim campo1 As String
            Dim campo2 As String
            Dim campo3 As String
            Dim campo4 As String
            Dim l As New Libreria

            'Llenar datos de gestores
            dtDatosGestor = d.SPGestor("N", ddlGestores.Text)
            ddlGestores.Text = dtDatosGestor.Rows(0).Item(1).trim()

            ddlConcertador.Text = ddlGestores.Text

            'Llenar campo unidad organizaconal
            indexGestor = dtDatosGestor.Rows(0).Item(0)

            Dim dtDatosUnidadOrg As New DataTable
            dtDatosUnidadOrg = d.DatosUnidadOrg(indexGestor)

            txUniOrg.Text = dtDatosUnidadOrg.Rows(0).Item(3)


            'Se asigna Bpigo
            dtDatosGestor.Clear()
            dtDatosGestor = d.SPGestor("", ddlGestores.Text)
            TXGestor.Text = dtDatosGestor.Rows(0).Item(1)
            TXConcertador.Text = TXGestor.Text

            FunCte = ddlGestores.SelectedValue
            dtRutaGestor = d.ObtenerRutaDelGestor(FunCte.ToString())

            campo0 = dtRutaGestor.Rows(0).Item(0).ToString().Trim()
            campo1 = dtRutaGestor.Rows(0).Item(1).ToString().Trim()
            campo2 = dtRutaGestor.Rows(0).Item(2).ToString().Trim()
            campo3 = dtRutaGestor.Rows(0).Item(3).ToString().Trim()
            campo4 = dtRutaGestor.Rows(0).Item(4).ToString().Trim()

            If campo0 <> "" Then ruta = l.LowCaseName(campo0)
            If campo1 <> "" Then ruta = ruta & "\" & l.LowCaseName(campo1)
            If campo2 <> "" Then ruta = ruta & "\" & l.LowCaseName(campo2)
            If campo3 <> "" Then ruta = ruta & "\" & l.LowCaseName(campo3)
            If campo4 <> "" Then ruta = ruta & "\" & l.LowCaseName(campo4)

            txRutaUnOrg.Text = ruta

            TXConcertador.Focus()
        End If
    End Sub

    'Private Sub ddlConcertador_DropDown(sender As Object, e As EventArgs)
    '    'Llena combo nombre de Concertadores
    '    Dim d As New Datasource
    '    Dim dtGestores As DataTable

    '    dtGestores = d.DatosGestores(ddlConcertador.Text)

    '    ddlConcertador.Visible = True
    '    ddlConcertador.DisplayMember = "nombre"
    '    ddlConcertador.ValueMember = "funcionario"
    '    ddlConcertador.DataSource = dtGestores

    'End Sub

    Private Sub ddlConcertador_SelectedIndexChanged(sender As Object, e As EventArgs)

        If ddlConcertador.SelectedIndex > 0 Then

            Dim d As New Datasource
            Dim dtDatosGestor As New DataTable


            'Llenar datos de gestores
            dtDatosGestor = d.SPGestor("N", ddlConcertador.Text)
            ddlConcertador.Text = dtDatosGestor.Rows(0).Item(1).trim()


            'Se asigna Bpigo
            dtDatosGestor.Clear()
            dtDatosGestor = d.SPGestor("", ddlConcertador.Text)
            TXConcertador.Text = dtDatosGestor.Rows(0).Item(1)

            txCuentaEjePesos.Focus()

            ''FunCte = ddlGestores.SelectedValue
        End If
    End Sub

    Private Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        Me.Close()
    End Sub


#Region "Funciones"

    Function DatosCorrectos() As Boolean
        Dim d As New Datasource
        Dim fechaHoy As Date
        Dim fechaCtaEje As Date
        Dim diafinal As Date

        If TXGestor.Text = String.Empty Or ddlGestores.Text = String.Empty Then
            MsgBox("Es necesario ingresar el Gestor del Cliente", vbInformation, "Validación")
            TXGestor.Focus()
            Return False
        End If

        If TXConcertador.Text = String.Empty Then
            MsgBox("Es necesario el numero del Concertador", vbInformation, "Validación")
            TXConcertador.Focus()
            Return False
        End If

        If ddlConcertador.Text = String.Empty Then
            MsgBox("Es necesario el nombre del Concertador", vbInformation, "Validación")
            ddlConcertador.Focus()
            Return False
        End If

        If txCuentaEjePesos.Text = String.Empty Then
            MsgBox("Es necesario ingresar la cuenta eje", vbInformation, "Validación")
            txCuentaEjePesos.Focus()
            Return False
        End If

        If Not IsNumeric(txCuentaEjePesos.Text) Then
            MsgBox("El campo cuenta eje debe ser numerico", vbInformation, "Validación")
            txCuentaEjePesos.Focus()
            Return False
        End If

        'If txFechaCtaEje.Text = String.Empty Then
        '    MsgBox("Es necesario la fecha de la cuenta en pesos", vbInformation, "Validación")
        '    txFechaCtaEje.Focus()
        '    Return False
        'End If

        If Not IsDate(DTPicker.Value) Then
            MsgBox("Es necesario la fecha de la cuenta en pesos", vbInformation, "Validación")
            DTPicker.Focus()
            Return False
        End If

        If ValorParametro("TIEMPOEJE") > 0 Then
            Try
                fechaHoy = d.FechaSistema()
                'fechaCtaEje = Convert.ToDateTime(txFechaCtaEje.Text)
                DTPicker.CustomFormat = ("yyyy-MM-dd")
                fechaCtaEje = DTPicker.Value
                diafinal = fechaCtaEje.AddMonths(ValorParametro("TIEMPOEJE"))

                If diafinal > fechaHoy Then
                    MsgBox("La cuenta en pesos no tiene la antiguedad necesaria..")
                    'txFechaCtaEje.Focus()
                    If Not optCta000.Checked Then
                        DTPicker.Focus()
                        Return False
                    End If
                End If
            Catch ex As Exception
                MsgBox("El formato de fecha no es valido")
                Return False
            End Try

        Else
            MsgBox("Error al obtener el dato del parametro, notifique a Sistemas, Codigo de parametro: TIEMPOEJE")
            'txFechaCtaEje.Focus()
            DTPicker.Focus()
            Return False
        End If

        'OGJ se elimina validaciòn
        'If CkConfirme.Checked = False Then
        '    MsgBox("Se debe confirmar con el promotor que la cuenta no tendra tarjeta de débito.", vbInformation, "Validación")

        '    CkConfirme.Focus()
        '    Return False
        'End If

        If txNombre.Text = String.Empty Then
            MsgBox("El nombre del cliente es requerido")
            txNombre.Focus()
            Return False
        End If


        If CkPersonaFisica.Checked Then
            If txApellidoPat.Text = String.Empty Then
                MsgBox("El apellido paterno del cliente es requerido")
                txNombre.Focus()
                Return False
            End If

            If txApellidoMat.Text = String.Empty Then
                MsgBox("El apellido materno del cliente es requerido")
                txNombre.Focus()
                Return False
            End If
        Else
            If ddlTipoCliente.Text = String.Empty Then
                MsgBox("Debe seleccionar un  tipo de cliente", vbInformation, "Validación")
                ddlTipoCliente.Focus()
                Return False
            End If
        End If

        Return True

    End Function

    Function ValorParametro(ByVal sParametro As String) As String
        Dim d As New Datasource
        Dim dtParametro As DataTable

        dtParametro = d.ValorParametro(sParametro)
        ValorParametro = dtParametro.Rows(0).Item(0)

        Return ValorParametro

    End Function

    Function CuentaClientePropuesto() As String
        Dim d As New Datasource
        Dim sCampoConsecutivo As String
        Dim dtConsecutivo As DataTable
        Dim lnConsecutivo As Integer


        sCampoConsecutivo = VB.Left(txNombre.Text, 1).ToUpper()

        If (InStr("ABCDEFGHIJKLMNÑOPQRSTUVWXYZ", sCampoConsecutivo) > 0) Then
            dtConsecutivo = d.ObtenerConsecutivoCte(sCampoConsecutivo)
            CuentaClientePropuesto = dtConsecutivo.Rows(0).Item(0)
        Else
            sCampoConsecutivo = "A"
            dtConsecutivo = d.ObtenerConsecutivoCte(sCampoConsecutivo)
            CuentaClientePropuesto = dtConsecutivo.Rows(0).Item(0)
        End If

        'MsgBox("CuentaClientePropuesto inicial:" & CuentaClientePropuesto)
        'Incrementar el consecutivo de la cuenta cliente + 1
        CuentaClientePropuesto = (Convert.ToInt32(CuentaClientePropuesto) + 1).ToString()
        lnConsecutivo = Len(Trim(CuentaClientePropuesto))
        If (lnConsecutivo < 6) Then
            CuentaClientePropuesto = "0" & CuentaClientePropuesto
        End If
        'MsgBox("CuentaClientePropuesto final:" & CuentaClientePropuesto)
        Return CuentaClientePropuesto

    End Function
    Private Sub DTPicker_ValueChanged(sender As Object, e As EventArgs) Handles DTPicker.ValueChanged
        ddlTipoCliente.Focus()
    End Sub

    Private Sub CkConfirme_CheckedChanged(sender As Object, e As EventArgs) Handles CkConfirme.CheckedChanged
        If CkConfirme.Checked Then
            btGuardar.Focus()
        End If
    End Sub

    Sub LimpiarCampos()
        Dim d As New Datasource
        Dim fechaHoy As Date
        fechaHoy = d.FechaSistema()
        txRutaUnOrg.Text = String.Empty
        TXGestor.Text = String.Empty
        ddlGestores.SelectedIndex = -1
        ddlGestores.Text = String.Empty
        TXConcertador.Text = String.Empty
        ddlConcertador.SelectedIndex = -1
        ddlConcertador.Text = String.Empty
        txUniOrg.Text = String.Empty
        txCuentaEjePesos.Text = String.Empty
        ddlTipoCliente.SelectedIndex = -1
        txNombre.Text = String.Empty
        CkConfirme.Checked = False
        DTPicker.Value = fechaHoy
        txApellidoPat.Text = String.Empty
        txApellidoMat.Text = String.Empty
        txtCuenta.Text = String.Empty
        txTicket.Text = String.Empty

    End Sub

    Sub LimpiarCuentaTicket()
        lbTicket.Visible = False
        txTicket.Text = String.Empty
        txTicket.Visible = False
        txtCuenta.Text = String.Empty
    End Sub

    Public Function fgMnemonico(ByVal sTexto As String, Optional sCuenta As String = "") As String

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
        If IsNumeric(VB.Left(sTexto, 1)) Then
            iPrimera = fgPrimeraLetra(sTexto)
            iPalabras = fgCuentaPalabras(sTexto)
            sMnemonico = VB.Left(sTexto, IIf(iPrimera >= 4, 4, iPrimera))
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
                    sMnemonico = Trim(VB.Left(sTexto, 9))
                Case 2
                    iPrimera = fgPosicionPalabra(sTexto, 2)
                    sMnemonico = Trim(VB.Left(sTexto, IIf(iPrimera > 5, 5, iPrimera - 1)))
                    'Posición de la segunda palabra
                    iPos = InStr(1, sTexto, " ")
                    sMnemonico = sMnemonico & Trim(VB.Left(Mid$(sTexto, iPos + 1), 4))
                Case Else
                    iPrimera = fgPosicionPalabra(sTexto, 2)
                    sMnemonico = Trim(VB.Left(sTexto, IIf(iPrimera > 3, 3, iPrimera - 1)))
                    sTexto = Trim(Mid$(sTexto, iPrimera))
                    'Posición de la segunda palabra
                    iPrimera = fgPosicionPalabra(sTexto, 2)
                    sMnemonico = sMnemonico & Trim(VB.Left(sTexto, IIf(iPrimera > 3, 3, iPrimera - 1)))
                    sTexto = Trim(Mid$(sTexto, iPrimera))
                    'Posición de la segunda palabra
                    iPrimera = fgPosicionPalabra(sTexto, 2)
                    'Fueron exactamente 3 palabras
                    If iPrimera = 0 Then
                        iPrimera = Len(sTexto)
                    End If
                    sMnemonico = sMnemonico & Trim(VB.Left(sTexto, IIf(iPrimera > 3, 3, iPrimera - 1)))
            End Select
        End If
        'Aplicamos la última regla, anteponer la constante "21"
        If Len(sMnemonico) > 7 Then
            sMnemonico = Trim(VB.Left(sMnemonico, 7))
        End If
        sMnemonico = "21" & sMnemonico
        fgMnemonico = fgUnico(Trim(sMnemonico), "mnemonico", sCuenta, "1")
    End Function
    '-------------------------------------------------------------------
    'Quitamos la puntuación (puntos y comas) del texto enviado
    'Originalmente se encontraba en modComunes
    'Agregada e identada por CEB 20-02-2002
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
                    sTexto = VB.Left(sTexto, iPos - 1) & Mid$(sTexto, iPos + 1)
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
    'Originalmente se encontraba en modComunes
    'Agregada e identada por CEB 20-02-2002
    '--------------------------------------------------------------------------------
    Public Function fgUnEspacio(ByVal sTexto As String) As String

        Dim sTemp As String
        Dim iPos As Long

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
            sWord = Trim(VB.Left(sTexto, iPos - 1))
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
    'Originalmente se encontraba en modComunes
    'Agregada e identada por CEB 20-02-2002
    '--------------------------------------------------------------------------------------
    Function fgReemplazaCia(ByVal sTexto As String) As String

        If VB.Left(sTexto, 8) = "COMPAÑIA" Then
            sTexto = "CIA" & Mid$(sTexto, 9)
        End If
        fgReemplazaCia = sTexto
    End Function

    '----------------------------------------------------------------------
    'Contamos el número de palabras que tiene el texto enviado
    'Originalmente se encontraba en modComunes
    'Agregada e identada por CEB 20-02-2002
    '----------------------------------------------------------------------
    Public Function fgCuentaPalabras(ByVal sTexto As String) As Integer

        Dim iCount As Integer
        Dim iPos As Integer

        iPos = 0&
        sTexto = Trim(sTexto)
        'De entrada cuenta con una palabra
        If Len(sTexto) > 0 Then
            iCount = 1
        End If
        Do
            iPos = InStr(iPos + 1, sTexto, " ")
            iCount = iCount + IIf(iPos = 0&, 0, 1)
        Loop Until iPos = 0&
        fgCuentaPalabras = iCount
    End Function

    '-------------------------------------------------------------------
    'Devolvemos la posición del primer caracter alfabetico
    'Originalmente se encontraba en modComunes
    'Agregada e identada por CEB 20-02-2002
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

    End Function

    '--------------------------------------------------------------------------------
    'Determinamos la posición inicial dentro de "sTexto" de la palabra "iPalabra"
    'Si se regresa un cero, es que no existe ese número de palabra dentro del texto.
    'Originalmente se encontraba en modComunes
    'Agregada e identada por CEB 20-02-2002
    '--------------------------------------------------------------------------------
    Public Function fgPosicionPalabra(ByVal sTexto As String, ByVal iPalabra As Integer) As Long

        Dim iCount As Integer
        Dim iPos As Integer

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
            iPos = InStr(iPos + 1, sTexto, " ")
            If iPos > 0& Then
                iCount = iCount + 1
            End If
        Loop Until (iCount = iPalabra) Or (iPos = 0&)
        'Si al final iPos = 0 es que la frase tiene menos palabras que la buscada
        fgPosicionPalabra = IIf(iPos = 0&, 0&, iPos + 1&)
    End Function

    '-----------------------------------------------------------------------------------------
    'Verificamos que "sTexto" no exista dentro de la tabla de "Clientes" en el campo "sField"
    'Se vuelve a crear por Beatriz A Palacios Sanchez. Fecha: 04 Ago 2019
    '-----------------------------------------------------------------------------------------
    Function fgUnico(ByVal sTexto As String, Optional sField As String = "mnemonico", Optional sCuenta As String = "", Optional sAgencia As String = "1") As String

        Dim sNum As String
        Dim iCuenta As Integer
        Dim d As New Datasource
        Dim dt As DataTable

        Do
            dt = d.Unico(sField, sTexto)

            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item(0) > 0 Then
                    iCuenta = iCuenta + 1
                    sNum = Trim(CStr(iCuenta))

                    If Len(sTexto) + Len(sNum) <= 9 Then
                        sTexto = sTexto & sNum
                    Else
                        sTexto = VB.Left(sTexto, Len(sTexto) - Len(sNum))
                        sTexto = sTexto & sNum
                    End If
                Else
                    iCuenta = 0
                End If
            End If

        Loop While (iCuenta > 0)

        fgUnico = sTexto

    End Function


    '----------------------------------------------------------------
    'Eliminamos las preposiciones  
    'Se vuelve a crear por Beatriz A Palacios Sanchez. Fecha: 04 Ago 2019
    '----------------------------------------------------------------
    Public Function fgSinPreposiciones(ByVal sTexto As String) As String

        Dim sPrep As String

        Dim d As New Datasource
        Dim dt As DataTable

        sPrep = ""
        dt = d.Preposiciones

        sTexto = sTexto.Trim().ToUpper()

        For Each dr As DataRow In dt.Rows
            sPrep = dr("pre_texto").Trim().ToUpper()
            sTexto = fgQuitaPalabras(sTexto, sPrep)
        Next


        'Quitamos los tipos de empresa o sociedad
        fgSinPreposiciones = fgSinEmpresa(sTexto)

    End Function

    '-----------------------------------------------------------------------------
    'Eliminamos los tipos de empresa
    'Se vuelve a crear por Beatriz A Palacios Sanchez. Fecha: 04 Ago 2019
    '-----------------------------------------------------------------------------
    Function fgSinEmpresa(ByVal sTexto As String) As String

        Dim sEmpresa As String

        Dim d As New Datasource
        Dim dt As DataTable

        sEmpresa = ""
        dt = d.TipoSociedad
        sTexto = sTexto.Trim().ToUpper()

        For Each dr As DataRow In dt.Rows
            sEmpresa = dr("tipo_sociedad").Trim().ToUpper()
            sTexto = fgQuitaPalabras(sTexto, sEmpresa)
        Next

        fgSinEmpresa = sTexto

    End Function


    '---------------------------------------------------------------------------
    'Quitamos la palabra deseada si se encuentra dentro del texto
    'Se vuelve a crear por Beatriz A Palacios Sanchez. Fecha: 04 Ago 2019
    '---------------------------------------------------------------------------
    Public Function fgQuitaPalabras(ByVal sTexto As String, ByVal sPalabra As String) As String

        Dim sPrimera As String
        Dim sUltima As String

        Dim iFin As Integer
        Dim arr() As String

        'Elimina preposiones que dentro del texto es decir no al principio ni al final
        sTexto = sTexto.Replace(" " & sPalabra & " ", " ")

        arr = sTexto.Split(" ")
        iFin = UBound(arr)

        sPrimera = arr(0)
        sUltima = arr(iFin)

        'Eliminar preposicion si esxiste al principio
        If sTexto.Substring(0, sPrimera.Length) = sPalabra Then
            sTexto = sTexto.Substring(sPrimera.Length, sTexto.Length - sPrimera.Length)
            sTexto = sTexto.Trim()
        End If


        Dim palabrafinal = sTexto.Substring(sTexto.Length - sUltima.Length, sUltima.Length)
        'Eliminar preposicion si esxiste al final
        If palabrafinal = sPalabra Then
            sTexto = sTexto.Substring(0, sTexto.Length - sUltima.Length)
            sTexto = sTexto.Trim()
        End If

        fgQuitaPalabras = sTexto

    End Function


    '-------------------------------------------------------------------------------------------------------------
    'Attribute fgShortName.VB_Description = "Obtiene el nombre corto de máximo 16 caracteres de la cadena enviada"
    'Devolvemos el short name del texto enviado
    'Originalmente se encontraba en modComunes
    'Agregada e identada por CEB 20-02-2002
    '-------------------------------------------------------------------------------------------------------------
    Public Function fgShortName(ByVal sTexto As String, Optional sCuenta As String = "", Optional sAgencia As String = "1") As String

        Dim iPalabras As Integer
        Dim iPos As Long
        Dim sShortName As String

        sTexto = fgSinPuntuacion(sTexto)
        sTexto = fgSinPreposiciones(sTexto)
        sTexto = fgMenores(sTexto)
        sTexto = fgReemplazaCia(sTexto)
        iPalabras = fgCuentaPalabras(sTexto)
        Select Case iPalabras
            Case 1
                sShortName = Trim(VB.Left(sTexto, 16))
            Case 2
                iPos = fgPosicionPalabra(sTexto, 2)
                sShortName = Trim(VB.Left(sTexto, IIf(iPos > 8, 8, iPos - 1))) & "-"
                sShortName = sShortName & Trim(Mid$(sTexto, iPos, 6))
            Case Else
                iPos = fgPosicionPalabra(sTexto, 2)
                sShortName = Trim(VB.Left(sTexto, IIf(iPos > 5, 5, iPos - 1))) & "-"
                sTexto = Mid$(sTexto, iPos)
                iPos = fgPosicionPalabra(sTexto, 2)
                sShortName = sShortName & Trim(VB.Left(sTexto, IIf(iPos > 5, 5, iPos - 1))) & "-"
                sTexto = Mid$(sTexto, iPos)
                iPos = fgPosicionPalabra(sTexto, 2)
                'Fueron tres palabras exactamente
                If iPos = 0& Then
                    sShortName = sShortName & Trim(VB.Left(sTexto, 3))
                Else
                    sShortName = sShortName & Trim(VB.Left(sTexto, IIf(iPos > 3, 4, iPos - 1)))
                End If
        End Select
        fgShortName = fgUnico(sShortName, "shortname", sCuenta, sAgencia)
    End Function

    Private Sub btGuardar_Leave(sender As Object, e As EventArgs) Handles btGuardar.Leave
        btCancelar.Focus()
    End Sub

    Private Sub CkPersonaFisica_CheckedChanged(sender As Object, e As EventArgs) Handles CkPersonaFisica.CheckedChanged
        optCta000.Visible = True
        optCta687.Visible = True
        optCta100.Visible = False

        lbApP.Visible = True
        lbApM.Visible = True
        txApellidoPat.Visible = True
        txApellidoMat.Visible = True
        ddlTipoCliente.Visible = False
        lbTipoCliente.Visible = False

        optCta687.Checked = True
        CkFideicomiso.Enabled = False
        CkFideicomiso.Visible = False

    End Sub

    Private Sub CkPersonaMoral_CheckedChanged(sender As Object, e As EventArgs) Handles CkPersonaMoral.CheckedChanged
        optCta000.Visible = False
        optCta687.Visible = False
        optCta100.Visible = True

        lbApP.Visible = False
        lbApM.Visible = False
        txApellidoPat.Visible = False
        txApellidoMat.Visible = False
        ddlTipoCliente.Visible = True
        lbTipoCliente.Visible = True

        optCta100.Checked = True
        CkFideicomiso.Enabled = True
        CkFideicomiso.Visible = True

    End Sub

    Private Sub TXGestor_Leave(sender As Object, e As EventArgs) Handles TXGestor.Leave

        If TXGestor.Text <> String.Empty Then
            Dim d As New Datasource
            Dim l As New Libreria
            Dim dtDatosGestor As New DataTable
            Dim indexGestor As Integer
            Dim dtRutaGestor As New DataTable
            Dim ruta As String = ""
            Dim campo0 As String
            Dim campo1 As String
            Dim campo2 As String
            Dim campo3 As String
            Dim campo4 As String

            Try
                dtDatosGestor = d.SPGestor(TXGestor.Text.Trim(), "")

                If dtDatosGestor.Rows.Count > 0 Then
                    ddlGestores.Text = dtDatosGestor.Rows(0).Item(1).trim()

                    TXConcertador.Text = TXGestor.Text
                    ddlConcertador.Text = ddlGestores.Text

                    'Llenar campo unidad organizaconal
                    indexGestor = dtDatosGestor.Rows(0).Item(0)
                    FunCte = indexGestor


                    dtRutaGestor = d.ObtenerRutaDelGestor(FunCte.ToString())

                    campo0 = dtRutaGestor.Rows(0).Item(0).ToString().Trim()
                    campo1 = dtRutaGestor.Rows(0).Item(1).ToString().Trim()
                    campo2 = dtRutaGestor.Rows(0).Item(2).ToString().Trim()
                    campo3 = dtRutaGestor.Rows(0).Item(3).ToString().Trim()
                    campo4 = dtRutaGestor.Rows(0).Item(4).ToString().Trim()

                    If campo0 <> "" Then ruta = l.LowCaseName(campo0)
                    If campo1 <> "" Then ruta = ruta & "\" & l.LowCaseName(campo1)
                    If campo2 <> "" Then ruta = ruta & "\" & l.LowCaseName(campo2)
                    If campo3 <> "" Then ruta = ruta & "\" & l.LowCaseName(campo3)
                    If campo4 <> "" Then ruta = ruta & "\" & l.LowCaseName(campo4)

                    txRutaUnOrg.Text = ruta

                    Dim dtDatosUnidadOrg As New DataTable

                    If dtDatosGestor.Rows.Count > 0 Then
                        dtDatosUnidadOrg = d.DatosUnidadOrg(indexGestor)

                        txUniOrg.Text = dtDatosUnidadOrg.Rows(0).Item(3)
                        txUniOrg.Enabled = False
                        ddlGestores.Focus()
                    End If
                Else
                    MsgBox("No es un funcionario valido")
                    TXGestor.Focus()
                    Exit Sub
                End If

            Catch ex As Exception
                MsgBox("El numero de funcionario no es valido, favor de seleccionar un funcionario existente")
                TXGestor.Focus()
                Exit Sub
            End Try
        End If



    End Sub

    Private Sub TXConcertador_Leave(sender As Object, e As EventArgs) Handles TXConcertador.Leave
        If TXConcertador.Text <> String.Empty Then
            Dim d As New Datasource
            Dim dtDatosGestor As New DataTable

            Try
                dtDatosGestor = d.SPGestor(TXConcertador.Text.Trim(), "")
                ddlConcertador.Text = dtDatosGestor.Rows(0).Item(1).trim()
                ddlConcertador.Focus()
            Catch ex As Exception
                MsgBox("El numero de funcionario no es valido, favor de seleccionar un funcionario existente")
                TXConcertador.Focus()
                Exit Sub
            End Try

        End If
    End Sub

    Private Sub ddlGestores_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ddlGestores.SelectedIndexChanged
        If ddlGestores.SelectedIndex > 0 Then

            Dim d As New Datasource
            Dim dtDatosGestor As New DataTable
            Dim indexGestor As Integer
            Dim dtRutaGestor As New DataTable
            Dim ruta As String = ""
            Dim campo0 As String
            Dim campo1 As String
            Dim campo2 As String
            Dim campo3 As String
            Dim campo4 As String
            Dim l As New Libreria

            'Llenar datos de gestores
            dtDatosGestor = d.SPGestor("N", ddlGestores.Text)
            ddlGestores.Text = dtDatosGestor.Rows(0).Item(1).trim()

            ddlConcertador.Text = ddlGestores.Text

            'Llenar campo unidad organizaconal
            indexGestor = dtDatosGestor.Rows(0).Item(0)

            Dim dtDatosUnidadOrg As New DataTable
            dtDatosUnidadOrg = d.DatosUnidadOrg(indexGestor)

            txUniOrg.Text = dtDatosUnidadOrg.Rows(0).Item(3)


            'Se asigna Bpigo
            dtDatosGestor.Clear()
            dtDatosGestor = d.SPGestor("", ddlGestores.Text)
            TXGestor.Text = dtDatosGestor.Rows(0).Item(1)
            TXConcertador.Text = TXGestor.Text

            FunCte = ddlGestores.SelectedValue
            dtRutaGestor = d.ObtenerRutaDelGestor(FunCte.ToString())

            campo0 = dtRutaGestor.Rows(0).Item(0).ToString().Trim()
            campo1 = dtRutaGestor.Rows(0).Item(1).ToString().Trim()
            campo2 = dtRutaGestor.Rows(0).Item(2).ToString().Trim()
            campo3 = dtRutaGestor.Rows(0).Item(3).ToString().Trim()
            campo4 = dtRutaGestor.Rows(0).Item(4).ToString().Trim()

            If campo0 <> "" Then ruta = l.LowCaseName(campo0)
            If campo1 <> "" Then ruta = ruta & "\" & l.LowCaseName(campo1)
            If campo2 <> "" Then ruta = ruta & "\" & l.LowCaseName(campo2)
            If campo3 <> "" Then ruta = ruta & "\" & l.LowCaseName(campo3)
            If campo4 <> "" Then ruta = ruta & "\" & l.LowCaseName(campo4)

            txRutaUnOrg.Text = ruta

            TXConcertador.Focus()
        End If
    End Sub

    Private Sub ddlGestores_DropDown(sender As Object, e As EventArgs) Handles ddlGestores.DropDown
        'Llena combo nombre de Gestores
        Dim d As New Datasource
        Dim dtGestores As DataTable

        dtGestores = d.DatosGestores(ddlGestores.Text)

        ddlGestores.Visible = True
        ddlGestores.DisplayMember = "nombre"
        ddlGestores.ValueMember = "funcionario"
        ddlGestores.DataSource = dtGestores
    End Sub

    Private Sub ddlConcertador_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ddlConcertador.SelectedIndexChanged

        If ddlConcertador.SelectedIndex > 0 Then
            Dim d As New Datasource
            Dim dtDatosGestor As New DataTable

            'Llenar datos de gestores
            dtDatosGestor = d.SPGestor("N", ddlConcertador.Text)
            ddlConcertador.Text = dtDatosGestor.Rows(0).Item(1).trim()

            'Se asigna Bpigo
            dtDatosGestor.Clear()
            dtDatosGestor = d.SPGestor("", ddlConcertador.Text)
            TXConcertador.Text = dtDatosGestor.Rows(0).Item(1)

            txCuentaEjePesos.Focus()
            ''FunCte = ddlGestores.SelectedValue
        End If
    End Sub

    Private Sub ddlConcertador_DropDown(sender As Object, e As EventArgs) Handles ddlConcertador.DropDown
        'Llena combo nombre de Concertadores
        Dim d As New Datasource
        Dim dtGestores As DataTable

        dtGestores = d.DatosGestores(ddlConcertador.Text)

        ddlConcertador.Visible = True
        ddlConcertador.DisplayMember = "nombre"
        ddlConcertador.ValueMember = "funcionario"
        ddlConcertador.DataSource = dtGestores
    End Sub

    Private Sub txCuentaEjePesos_TextChanged(sender As Object, e As EventArgs) Handles txCuentaEjePesos.TextChanged

    End Sub

    Private Sub TXGestor_TextChanged(sender As Object, e As EventArgs) Handles TXGestor.TextChanged

    End Sub

    Private Sub grMuestraNuevaCuenta_Enter(sender As Object, e As EventArgs) Handles grMuestraNuevaCuenta.Enter

    End Sub











#End Region
End Class