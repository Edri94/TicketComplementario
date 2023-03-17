'*************    Módulo de Chequeras    **************'
'****       Fecha de Creación: 02/06/2020           ***'
'**** Creado por: SGGG-Susan Gabriela Gómez González***' 
Imports VB = Microsoft.VisualBasic
Public Class frmSolicitudChequeraNormal

    Dim bTipoSol As Byte
    Dim sNumCheques As String = ""
    Dim sSucursal As String = ""
    Dim sSucCta As String = ""

    Dim moForma As Object

    'Enum para tener mas detallado el status de la chequera
    Enum STSChequera
        A_Sol_Chequera = 1
        B_Sol_x_Apertura = 2
        C_Env_Printer = 3
        D_Sol_Incorrecta = 5
        E_Sol_Cancel = 250
    End Enum

    Private Sub frmSolicitudChequeraNormal_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        txFechaSolicitud.Text = Date.Now.Date.ToString("dd-MM-yyyy")
        Me.CenterToScreen()
        Me.Text = "Solicitud de Chequeras"
        txNumCta.Focus()
        grbNoEspeciales.Visible = True
        LimpiaCampos(1, btLimpiar)
        btSolError.Enabled = False
        btAceptar.Enabled = True

        dllNomCta.DataSource = Nothing
        dllNomCta.DisplayMember = Nothing
        dllNomCta.ValueMember = Nothing

        dllSucCta.DataSource = Nothing
        dllSucCta.DisplayMember = Nothing
        dllSucCta.ValueMember = Nothing
        dllSucCta.SelectedIndex = -1
        dllSucursal.DataSource = Nothing
        dllSucursal.DisplayMember = Nothing
        dllSucursal.ValueMember = Nothing
        dllSucursal.SelectedIndex = -1
        dllNumCheques.DataSource = Nothing
        dllNumCheques.DisplayMember = Nothing
        dllNumCheques.ValueMember = Nothing
        dllNumCheques.SelectedIndex = -1

        txNomGestor.CharacterCasing = CharacterCasing.Upper
        txCRCta.CharacterCasing = CharacterCasing.Upper
        txCR.CharacterCasing = CharacterCasing.Upper

        txNumCta.Text = iCtaCliente
        If txNumCta.Text <> "" Then
            txNumCta_Leave(txNumCta, AcceptButton)
        End If
    End Sub

    Private Sub btCerrar_Click_1(sender As Object, e As EventArgs) Handles btCerrar.Click
        Me.Close()
    End Sub


    'Limpia campos
    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        If dllNomCta.SelectedIndex <> -1 Then
            dllNomCta.DataSource = Nothing
            dllNomCta.DisplayMember = Nothing
            dllNomCta.ValueMember = Nothing
        End If
        LimpiaCampos(1, btLimpiar)
        grbNoEspeciales.Enabled = False
        btCancelar.Visible = False
        btSolError.Text = "Solicitud Errónea"
        btSolError.Enabled = False
        btAceptar.Enabled = False
        txMotivoError.Text = String.Empty
        txMotivoError.Visible = False
        lbMotivoError.Visible = False
        txNumCta.Focus()
        dllSucCta.DataSource = Nothing
        dllSucCta.DisplayMember = Nothing
        dllSucCta.ValueMember = Nothing
        dllSucCta.SelectedIndex = -1
        dllSucursal.DataSource = Nothing
        dllSucursal.DisplayMember = Nothing
        dllSucursal.ValueMember = Nothing
        dllSucursal.SelectedIndex = -1
        dllNumCheques.DataSource = Nothing
        dllNumCheques.DisplayMember = Nothing
        dllNumCheques.ValueMember = Nothing
        dllNumCheques.SelectedIndex = -1

    End Sub

    Sub LimpiaCampos(ByVal itpLimpiar As Integer, Excepcion As Control)

        Dim lo_Control As Control

        'Si es limpieza general de campos
        For Each lo_Control In Controls
            If lo_Control.Name <> Excepcion.Name Then
                If itpLimpiar = 1 Then
                    LimpiaCamposGrp(Me.grbDatosCliente)
                End If
                LimpiaCamposGrp(Me.grbDatosCuenta)
                LimpiaCamposGrp(Me.grbNoEspeciales)
                LimpiaCamposGrp(Me.grbResultados)
            End If
        Next

        Cursor = System.Windows.Forms.Cursors.Default
        txFechaSolicitud.Text = Date.Now.Date.ToString("dd-MM-yyyy")
    End Sub
    Sub LimpiaCamposGrp(ByVal sNomcontrol As GroupBox)
        Dim lo_Control As Control

        'Recorremos todos los controles del formulario que enviamos  
        For Each lo_Control In sNomcontrol.Controls

            'Filtramos solo aquellos de tipo TextBox 
            If TypeOf lo_Control Is TextBox Then
                If lo_Control.Name <> "lbMotivoError" Then
                    lo_Control.Text = "" ' eliminar el texto  
                End If
            End If

            'Filtramos solo aquellos de tipo ComboBox 
            If TypeOf lo_Control Is ComboBox And (lo_Control.Name <> "dllNumCheques") Then
                lo_Control.Text = ""
            End If
        Next
    End Sub
    Private Sub btAceptar_Click(sender As Object, e As EventArgs) Handles btAceptar.Click
        'False indica que no es una solicitud Errónea y se deber verificar los datos
        RegistraChequera("Solicitud de Chequera", False)
    End Sub

    Private Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        btAceptar.Enabled = True
        btCancelar.Visible = False
        btSolError.Text = "Solicitud Errónea"
        txMotivoError.Text = ""
        txMotivoError.Visible = False
        lbMotivoError.Visible = False
    End Sub

    Private Sub btSolError_Click(sender As Object, e As EventArgs) Handles btSolError.Click
        If btSolError.Text = "Solicitud Errónea" Then
            btCancelar.Visible = True
            btAceptar.Enabled = False
            btSolError.Text = "Registra Error"
            txMotivoError.Text = ""
            txMotivoError.Visible = True
            lbMotivoError.Visible = True
            txMotivoError.Focus()
        Else
            If Trim$(txMotivoError.Text) = "" Then
                MsgBox("Es necesario indicar el motivo del error.", vbInformation, "Dato faltante")
                txMotivoError.Focus()
            Else
                btCancelar.Visible = False
                btAceptar.Enabled = True
                btSolError.Text = "Solicitud Errónea"
                'txMotivoError.Text = ""
                txMotivoError.Visible = False
                lbMotivoError.Visible = False
                RegistraChequera(txMotivoError.Text, True)
            End If
        End If
    End Sub

    Sub RegistraChequera(ByVal sComentario As String, ByVal Erroneo As Boolean)

        Try
            Dim d As New Datasource
            Dim iChequera As DataTable
            Dim sProdCont As String
            Dim ln_Orden As Byte
            Dim sLastPart As String

            Dim lnUltimoChq As Long
            Dim lnStatus As STSChequera
            Dim Ln_LongCHQ As Integer

            'No es solicitud Errónea
            If Not Erroneo Then
                If Not DatosCorrectos() Then Exit Sub
            End If

            sProdCont = dllNomCta.SelectedItem(dllNomCta.SelectedIndex)

            If Not ObtenNuevoCheque(CLng(sProdCont), lnUltimoChq, lnStatus, Ln_LongCHQ) Then Exit Sub

            'Si es un registro con error cambia el status
            If Erroneo Then lnStatus = STSChequera.D_Sol_Incorrecta  '"5"
            sLastPart = ""

            'Es chequera NORMAL
            iChequera = d.InsertaChequera(1, sProdCont, txNumSucursal.Text, txNomGestor.Text, txNumGestor.Text, txGestorPesos.Text, txNumCRCta.Text, txCRCta.Text, txNumSucCta.Text,
                                dllSucCta.Text, txCtaEjePesos.Text, dllNumCheques.Text, lnUltimoChq, Ln_LongCHQ, lnStatus, txNumCR.Text, Erroneo, sComentario)

            If iChequera.Rows(0).Item(0) = 0 Then
                MsgBox("No es posible registrar el alta de la chequera.", vbCritical, "SQL Server Error")
                Exit Sub
            End If
            lblRegistro.Text = iChequera.Rows(0).Item(0)

            'Si es chequera de 500 cheques
            If Val(sNumCheques) = 500 Then
                'Es solicitud Errónea
                If Erroneo = True Then
                    lblFolioIni.Text = lnUltimoChq - 499
                    lblFolioFin.Text = lnUltimoChq - 499

                Else
                    'Es solicitud normal
                    lblFolioIni.Text = lnUltimoChq - 499
                    lblFolioFin.Text = lnUltimoChq
                End If
            Else
                'Es solicitud Errónea
                If Erroneo = True Then
                    lblFolioIni.Text = CStr(lnUltimoChq + 1).Substring(RightToLeft, Ln_LongCHQ)
                    lblFolioFin.Text = lblFolioIni.Text
                Else
                    lblFolioIni.Text = CStr(lnUltimoChq + 1).Substring(RightToLeft, Ln_LongCHQ)
                    lblFolioFin.Text = CStr(lnUltimoChq + Val(dllNumCheques.Text)).Substring(RightToLeft, Ln_LongCHQ)
                End If
            End If

            'Si no es chequera Errónea actualiza Cliente
            If lnStatus = STSChequera.A_Sol_Chequera Or lnStatus = STSChequera.B_Sol_x_Apertura Then
                d.ActualizaCliente(sProdCont)
            End If

            btAceptar.Enabled = False
            btSolError.Enabled = False

            If Erroneo Then
                MsgBox("La solicitud de Chequera se registró como Incorrecta.", vbInformation, "Solicitud Registrada.")
            Else
                MsgBox("La solicitud de Chequera ha sido registrada.", vbInformation, "Solicitud Registrada.")
            End If

            grbNoEspeciales.Enabled = False
            grbDatosCuenta.Enabled = False
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en RegistraChequera: " & ex.Message, vbInformation, "SolicitudChequeraEspecial")
            Exit Sub
        End Try
    End Sub

    Private Sub ObtenDatosTicket()
        Try
            Dim d As New Datasource
            Dim dtExisteCHQ As New DataTable
            Dim dtDatosCHQAnterior As New DataTable
            Dim dtDatosCtaEje As New DataTable
            Dim dtDatosCR As New DataTable
            Dim dtDatosSucursal As New DataTable

            Dim sChqAnterior As String
            Dim sCtaEjePesos As String

            sChqAnterior = ""
            sCtaEjePesos = ""

            'ShowWaitCursor
            'Busca datos de una solicitud de chequera previa
            dtExisteCHQ = d.ExisteCHQ(CStr(dllNomCta.SelectedValue))
            'Se encontro una solicitud anterior
            If dtExisteCHQ.Rows(0).Item(0) <> 0 Then
                sChqAnterior = dtExisteCHQ.Rows(0).Item(0)
            End If

            'Existe una solicitud anterior
            If Trim$(sChqAnterior) <> "" Then
                'Busca la información de la ultima solicitud
                dtDatosCHQAnterior = d.DatosCHQAnterior(sChqAnterior)
                'Se encontraron datos de la ultima solicitud
                If dtDatosCHQAnterior.Rows().Count > 0 Then
                    txGestorPesos.Text = dtDatosCHQAnterior.Rows(0).Item(0)
                    txNumCRCta.Text = dtDatosCHQAnterior.Rows(0).Item(1)
                    txCRCta.Text = Trim(dtDatosCHQAnterior.Rows(0).Item(2))
                    txNumSucCta.Text = Trim(dtDatosCHQAnterior.Rows(0).Item(5)).PadLeft(7, "0")
                    If dllSucCta.SelectedIndex = -1 Then
                        dllSucCta.Items.Add(Trim(dtDatosCHQAnterior.Rows(0).Item(6)))
                        dllSucCta.ValueMember = Val(dtDatosCHQAnterior.Rows(0).Item(5))
                        dllSucCta.SelectedIndex = 0
                    Else
                        dllSucCta.Text() = Trim(dtDatosCHQAnterior.Rows(0).Item(6))
                    End If
                    sCtaEjePesos = Trim(dtDatosCHQAnterior.Rows(0).Item(7))

                    If Trim(dtDatosCHQAnterior.Rows(0).Item(8)) <> "" Then
                        txNumSucursal.Text = Trim(dtDatosCHQAnterior.Rows(0).Item(8)).PadLeft(7, "0")
                    Else
                        txNumSucursal.Text = ""
                    End If
                    txNomGestor.Text = Trim$(dtDatosCHQAnterior.Rows(0).Item(9))
                    txNumGestor.Text = Trim$(dtDatosCHQAnterior.Rows(0).Item(10))
                    txNumCR.Text = Trim$(dtDatosCHQAnterior.Rows(0).Item(11))
                End If
                'No hay una solicitud anterior
            Else
                'Busca el número de cuenta eje pesos del cliente
                dtDatosCtaEje = d.DatosCuentaEje(CStr(dllNomCta.SelectedValue))
                'Encontro el número de cuenta
                If dtDatosCtaEje.Rows.Count > 0 Then
                    sCtaEjePesos = Trim(dtDatosCtaEje.Rows(0).Item(0))
                End If
            End If

            'Muestra la cuenta eje pesos (si esta es valida)
            txCtaEjePesos.Text = sCtaEjePesos

            'Obtiene datos del Centro Regional
            If Trim(txNumCR.Text) <> "" And Val(txNumCR.Text) > 0 Then
                If Trim$(txNumCR.Text) <> "" Then
                    'ShowWaitCursor
                    dtDatosCR = d.DatosCR(txNumCR.Text)
                    If dtDatosCR.Rows().Count = 0 Then
                        If Trim(txNumCRCta.Text) = Trim(txNumCR.Text) Then
                            txCR.Text = txCRCta.Text
                        Else
                            txCR.Text = ""
                        End If

                    Else
                        txCR.Text = dtDatosCR.Rows(0).Item(0)
                    End If
                    'ShowDefaultCursor
                End If
            End If
            'Obtiene datos de la Sucursal
            If Trim(txNumSucursal.Text) <> "" And Val(txNumSucursal.Text) > 0 Then
                If Trim$(txNumSucursal.Text) <> "" Then
                    dtDatosSucursal = d.LoadSucursal("", txNumSucursal.Text)
                    If Val(txNumSucursal.Text) = Val(txNumSucCta.Text) Then
                        If Trim(dllSucCta.Text) = "" Then
                            MsgBox("La sucursal de la cuenta no puede estar vacia", vbInformation)
                            Exit Sub
                        End If
                        dllSucursal.Items.Add(dllSucCta.Text)
                        dllSucursal.ValueMember = dllSucCta.SelectedValue
                        dllSucursal.SelectedIndex = 0
                    Else

                        If dllSucursal.SelectedIndex = -1 Then
                            dllSucursal.Items.Add(Trim(dtDatosSucursal.Rows(0).Item(1)))
                            dllSucursal.ValueMember = Trim(dtDatosSucursal.Rows(0).Item(0))
                            dllSucursal.SelectedIndex = 0
                        Else
                            dllSucursal.Text() = Trim(dtDatosSucursal.Rows(0).Item(1))
                        End If
                    End If
                End If


                'txtNumSucursal_LostFocus

            End If

            'ShowDefaultCursor
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en ObtenDatosTicket: " & ex.Message, vbInformation, "SolicitudChequeraNormal")
            Exit Sub
        End Try

    End Sub



#Region "FUNCIONES"
    Function DatosCorrectos() As Boolean

        Dim Reg_SucCHQ As Integer = 0
        Dim d As New Datasource
        DatosCorrectos = False
        Dim CuentaActiva As StringAlignment


        If Trim$(txGestorPesos.Text) = "" Then
            MsgBox("Es necesario indicar el número de Funcionario Eje Pesos.", vbInformation, "Dato Faltante...")
            txGestorPesos.Focus()
            Exit Function
        End If

        If Trim$(txNumCRCta.Text) = "" Then
            MsgBox("Es necesario indicar el número de DAR de la cuenta de envío.", vbInformation, "Dato Faltante...")
            txNumCRCta.Focus()
            Exit Function
        End If

        If Trim$(txCRCta.Text) = "" Then
            MsgBox("Es necesario indicar el DAR de la cuenta de envió.", vbInformation, "Dato Faltante...")
            txCRCta.Focus()
            Exit Function
        End If

        If Trim$(txNumSucCta.Text) = "" Then
            MsgBox("Es necesario indicar el número de sucursal de la cuenta de envió.", vbInformation, "Dato Faltante...")
            txNumSucCta.Focus()
            Exit Function
        End If

        If Trim$(dllSucCta.Text) = "" Then
            MsgBox("Es necesario indicar la sucursal de la cuenta de envió.", vbInformation, "Dato Faltante...")
            dllSucCta.Focus()
            Exit Function
        End If

        If Len(Trim$(txCtaEjePesos.Text)) <> 10 Then
            MsgBox("La Cuenta Eje Pesos es inválida.", vbInformation, "Verifique dato ...")
            txCtaEjePesos.Focus()
            Exit Function
        End If

        CuentaActiva = MsgBox("¿Ya revisó que la cuenta del cliente se encuentre activa?", vbYesNo, "Verificar...")
        'Si no se ha validado la cuenta del cliente
        If CuentaActiva = vbNo Then
            Exit Function
        End If

        'Insertamos las sucursales que no hayan sido seleccionadas
        'Unicamente la de envio
        If dllSucCta.SelectedIndex = -1 Then
            If MsgBox("La sucursal de la cuenta que ingreso no existe, " & vbCrLf &
                    "¿Desea darla de alta?", vbYesNo + vbQuestion,
                    "Agregar sucursal") = vbYes Then

                Reg_SucCHQ = d.InsertaSucursal_CHQ(txNumSucCta.Text, dllSucCta.Text)
                'Error al insertar
                If Reg_SucCHQ = 0 Then
                    MsgBox("Hubo un error al dar de alta la sucursal de la cuenta", vbInformation, "Error al insertar")
                End If
            End If
        End If

        'Si se trata de chequera normal

        If (Trim$(txNumGestor.Text) = "") Or (Trim$(txNomGestor.Text) = "") Then
            MsgBox("Es necesario indicar el funcionario que solicita la chequera.", vbInformation, "Dato Faltante...")
            txNumGestor.Focus()
            Exit Function
        End If
        If Trim$(txNumCR.Text) = "" Then
            MsgBox("Es necesario indicar el DAR de donde se solicita la chequera.", vbInformation, "Dato Faltante...")
            txNumCR.Focus()
            Exit Function
        End If
        'Valida las descripciones de la sucursal y el cr de donde se solicita
        If Trim$(dllSucursal.Text) = "" Then
            MsgBox("Es necesario indicar la sucursal de la cuenta de donde se solicita.", vbInformation, "Dato Faltante...")
            dllSucursal.Focus()
            Exit Function
        End If
        If Trim$(txCR.Text) = "" Then
            MsgBox("Es necesario indicar el DAR de la cuenta de donde se solicita.", vbInformation, "Dato Faltante...")
            txCR.Focus()
            Exit Function
        End If
        '**
        If Trim$(txNumSucursal.Text) = "" Then
            MsgBox("Es necesario indicar la sucursal de donde se solicita la chequera.", vbInformation, "Dato Faltante...")
            txNumSucursal.Focus()
            Exit Function
        End If
        If dllNumCheques.SelectedIndex = -1 Then
            MsgBox("Es necesario indicar el número de cheques que se solicitan.", vbInformation, "Dato Faltante...")
            dllNumCheques.Focus()
            Exit Function
        End If

        'La de solicitud cuando es chequera normal unicamente
        If dllSucursal.SelectedIndex = -1 Then
            If MsgBox("La sucursal destino que ingreso no existe, " & vbCrLf &
                        "¿Desea darla de alta?", vbYesNo + vbQuestion,
                        "Agregar sucursal") = vbYes Then

                Reg_SucCHQ = d.InsertaSucursal_CHQ(txNumSucursal.Text, dllSucursal.Text)
                'Error al insertar
                If Reg_SucCHQ <> 0 Then
                    MsgBox("Hubo un error al dar de alta la sucursal destino", vbInformation, "Error al insertar")
                End If
            End If
        End If


        DatosCorrectos = True

    End Function

    Function ObtenNuevoCheque(ByVal Ln_ProdCont As Long,
                                  ByRef Ln_UltimoCHQ As Long,
                                  ByRef Ln_Status As STSChequera,
                                  ByRef Ln_LongCheque As Integer) As Boolean
        Try
            'Variables para tomar parametros del sistema para control de numero de cheques
            Dim Ln_ChequeInicial As Integer
            Dim Ln_UltLongChq As Integer
            Dim d As New Datasource
            Dim dtDatosCheques As New DataTable

            'Obtiene longitud del Cheque
            Ln_LongCheque = Val(ValorParametro("LONGFOLIOCHQ"))
            'Valida que la longitud del cheque sea mayor a cero
            If Ln_LongCheque <= 0 Then
                MsgBox("El valor de la longitud del número de cheque es incorrecto, favor de verificar el parametro ""LONGFOLIOCHQ""", vbCritical, "Error")
                Exit Function
            End If
            Ln_ChequeInicial = Val(ValorParametro("FOLIOINICHQ")) - 1

            'Valida que la longitud del cheque sea mayor a cero
            If Ln_ChequeInicial < 0 Then
                MsgBox("El valor inicial del número de cheque es incorrecto, favor de verificar el parametro ""FOLIOINICHQ""", vbCritical, "Error")
                Exit Function
            End If


            'Obtiene ultimo_cheque y la longitud con la que fue generada la chequera la ultima ocasión
            'Busca el ultimo número de cheque para la cuenta Error
            dtDatosCheques = d.ObtieneCheque(Ln_ProdCont)

            'Si no trae resultados no existe chequera alguna
            If dtDatosCheques.Rows.Count() = 0 Then
                Ln_UltLongChq = Ln_LongCheque
                Ln_UltimoCHQ = Ln_ChequeInicial
                Ln_Status = STSChequera.B_Sol_x_Apertura
            Else
                Ln_UltLongChq = 0 & dtDatosCheques.Rows(0).Item(1)
                'Si esta en cero es porque no se ha gZenerado ningun cheque
                If Val(dtDatosCheques.Rows(0).Item(0)) = 0 Then
                    Ln_UltimoCHQ = Ln_ChequeInicial
                    Ln_Status = STSChequera.B_Sol_x_Apertura
                Else
                    Ln_UltimoCHQ = 0 & dtDatosCheques.Rows(0).Item(0)
                    Ln_Status = STSChequera.A_Sol_Chequera
                End If
            End If

            'Se compara la longitud del ultimo cheque exitente y la longitud constante
            'Si son diferentes reinicio el numero de cheque
            If Ln_UltLongChq <> Ln_LongCheque Then Ln_UltimoCHQ = Ln_ChequeInicial
            ObtenNuevoCheque = True
            Exit Function
        Catch ex As Exception
            ObtenNuevoCheque = False
            MsgBox("Error al obtener el nuevo numero de cheque" & vbCrLf & Err.Number & ":" & Err.Description, vbCritical, "Error")

            MsgBox("Ha ocurrido un error en ObtenDatosTicket: " & ex.Message, vbInformation, "SolicitudChequeraEspecial")
            Exit Function
        End Try
    End Function

    'Obtiene valor de la tabla Parametros
    Function ValorParametro(ByVal sParametro As String) As String
        Dim d As New Datasource
        Dim dtParametro As DataTable

        dtParametro = d.ValorParametro(sParametro)
        ValorParametro = dtParametro.Rows(0).Item(0)

        Return ValorParametro

    End Function
    Sub LlenaComboSuc(ByVal sucursal As String)
        Dim d As New Datasource
        Dim dtDatosSucursal As New DataTable
        'txNumSucursal.Text = ""'----- RACB 12/03/2021
        'Llenar datos de sucursales
        dllSucursal.Visible = True
        dtDatosSucursal = d.LoadSucursal("", txNumSucursal.Text) '----- RACB 12/03/2021
        'Llena el combo de sucursales (si se encontraron)
        If dtDatosSucursal.Rows.Count > 0 Then '----- RACB 12/03/2021
            dllSucursal.DataSource = dtDatosSucursal
            dllSucursal.DisplayMember = "suc_nombre"
            dllSucursal.ValueMember = "suc_sucursal"
        End If
    End Sub

#End Region

#Region "PROCESOS KEYPRESS"
    Private Sub txNumCta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txNumCta.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
        txNumCta.MaxLength = 6
        If dllNomCta.SelectedIndex <> -1 Then
            dllNomCta.SelectedIndex = -1
            LimpiaCampos(1, txNumCta)
            grbNoEspeciales.Enabled = False
            grbDatosCuenta.Enabled = False
            btAceptar.Enabled = False
            btSolError.Enabled = False
        End If
        '--- RACB 10/03/2021
        If AscW(e.KeyChar) = CInt(Keys.Enter) Then
            Dim d As New Datasource
            Dim dtDatosCliente As New DataTable
            If Trim$(txNumCta.Text) <> "" Then
                If dllNomCta.SelectedIndex = -1 Then
                    dllNomCta.Visible = True
                    dtDatosCliente = d.ObtieneDatoscliente(txNumCta.Text)
                    dllNomCta.DataSource = dtDatosCliente
                    dllNomCta.DisplayMember = "nombrecliente"
                    dllNomCta.ValueMember = "producto_contratado"

                    If dllNomCta.Items.Count = 0 Then
                        MsgBox("La cuenta no existe o no es valida para solicitud de chequera.", vbInformation, "Cuenta Inexistente")
                        txNumCta.Text = ""
                        txNumCta.Focus()
                    ElseIf dllNomCta.Items.Count = 1 Then
                        ObtenDatosTicket()
                        dllNomCta.SelectedIndex = 0
                    End If
                End If
            End If
        End If
        '--- RACB 10/03/2021
    End Sub

    Private Sub txGestorPesos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txGestorPesos.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
        txGestorPesos.MaxLength = 8
    End Sub
    Private Sub txNumCRCta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txNumCRCta.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
        txNumCRCta.MaxLength = 4
    End Sub
    Private Sub txNumSucCta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txNumSucCta.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
        txNumSucCta.MaxLength = 7
        If dllSucCta.SelectedIndex <> -1 Then
            dllSucCta.SelectedIndex = -1
        End If
    End Sub

    Private Sub txCtaEjePesos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txCtaEjePesos.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
        txCtaEjePesos.MaxLength = 12
    End Sub

    Private Sub txNumGestor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txNumGestor.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
        txNumGestor.MaxLength = 8
    End Sub

    Private Sub txNumCR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txNumCR.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
        txNumCR.MaxLength = 4
    End Sub

    Private Sub txNumSucursal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txNumSucursal.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
        txNumSucursal.MaxLength = 7
        If dllSucursal.SelectedIndex <> -1 Then
            dllSucursal.SelectedIndex = -1
        End If
    End Sub
    Private Sub txMotivoError_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txMotivoError.KeyPress
        txCtaEjePesos.MaxLength = 100
    End Sub
    Private Sub cmbNomCta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dllNomCta.KeyPress
        If Trim$(txNumCta.Text) <> "" Then txNumCta.Text = ""
        If dllNomCta.SelectedIndex > -1 Then
            dllNomCta.SelectedText = ""
            LimpiaCampos(1, dllNomCta)
        End If
        'End If
    End Sub


#End Region

    Private Sub dllSucCta_DropDown(sender As Object, e As EventArgs) Handles dllSucCta.DropDown

        Dim d As New Datasource
        Dim dtDatosSucursal As New DataTable
        'txNumSucCta.Text = ""'---- RACB 12/03/2021
        'Llenar datos de sucursales
        dtDatosSucursal = d.LoadSucursal("", txNumSucCta.Text) '----- RACB 12/03/2021

        'Llena el combo de sucursales (si se encontraron)
        If dtDatosSucursal.Rows.Count > 0 Then '---- RACB 12/03/2021
            dllSucCta.Visible = True
            dllSucCta.DataSource = dtDatosSucursal
            dllSucCta.DisplayMember = "suc_nombre"
            dllSucCta.ValueMember = "suc_sucursal"
        End If
    End Sub

    Private Sub dllSucursal_DropDown(sender As Object, e As EventArgs) Handles dllSucursal.DropDown
        LlenaComboSuc(txNumSucursal.Text)
    End Sub
    Private Sub dllNomCta_DropDown(sender As Object, e As EventArgs) Handles dllNomCta.DropDown
        Dim d As New Datasource
        Dim dtDatosCliente As New DataTable
        If txNumCta.Text = "" Then '------ RACB 12/03/2021
            txNumCta.Text = ""
            LimpiaCampos(2, dllNomCta)
            dllNomCta.Visible = True
            dtDatosCliente = d.ObtieneDatoscliente("")
            dllNomCta.DataSource = dtDatosCliente
            dllNomCta.DisplayMember = "nombrecliente"
            dllNomCta.ValueMember = "producto_contratado"
        End If
    End Sub
    Private Sub dllSucCta_Leave(sender As Object, e As EventArgs) Handles dllSucCta.Leave
        If dllSucCta.SelectedValue <> Nothing Then
            txNumSucCta.Text = dllSucCta.SelectedValue
        End If
    End Sub

    Private Sub dllSucursal_Leave(sender As Object, e As EventArgs) Handles dllSucursal.Leave
        If dllSucursal.SelectedValue <> Nothing Then
            txNumSucursal.Text = dllSucursal.SelectedValue
        End If
    End Sub
    Private Sub txNumSucCta_Leave(sender As Object, e As EventArgs) Handles txNumSucCta.Leave
        Dim d As New Datasource
        Dim dtDatosSucursal As New DataTable
        dllSucCta.DataSource = Nothing
        dllSucCta.DisplayMember = Nothing
        dllSucCta.ValueMember = Nothing
        If txNumSucCta.Text <> "" Then
            'Llenar datos de sucursales
            dtDatosSucursal = d.LoadSucursal(dllSucCta.Text, txNumSucCta.Text)
            'Llena el combo de sucursales (si se encontraron)
            If dtDatosSucursal.Rows.Count > 0 Then
                dllSucCta.Visible = True
                dllSucCta.DataSource = dtDatosSucursal
                dllSucCta.DisplayMember = "suc_nombre"
                dllSucCta.ValueMember = "suc_sucursal"
            Else
                dllSucCta.DataSource = Nothing
                dllSucCta.DisplayMember = Nothing
                dllSucCta.ValueMember = Nothing
            End If
        End If

    End Sub
    Private Sub txNumSucursal_Leave(sender As Object, e As EventArgs) Handles txNumSucursal.Leave
        Dim d As New Datasource
        Dim dtDatosSucursal As New DataTable

        dllSucursal.DataSource = Nothing
        dllSucursal.DisplayMember = Nothing
        dllSucursal.ValueMember = Nothing
        If txNumSucCta.Text <> "" Then
            'Llenar datos de sucursales
            dtDatosSucursal = d.LoadSucursal(dllSucursal.Text, txNumSucursal.Text)
            'Llena el combo de sucursales (si se encontraron)
            If dtDatosSucursal.Rows.Count > 0 Then
                dllSucursal.Visible = True
                dllSucursal.DataSource = dtDatosSucursal
                dllSucursal.DisplayMember = "suc_nombre"
                dllSucursal.ValueMember = "suc_sucursal"
            Else
                dllSucursal.DataSource = Nothing
                dllSucursal.DisplayMember = Nothing
                dllSucursal.ValueMember = Nothing
            End If
        End If

    End Sub

    Private Sub txNumCta_Leave(sender As Object, e As EventArgs) Handles txNumCta.Leave
        Dim d As New Datasource
        Dim dtDatosCliente As New DataTable

        'Cursor = System.Windows.Forms.Cursors.WaitCursor

        If Trim$(txNumCta.Text) <> "" Then
            If dllNomCta.SelectedIndex = -1 Then
                dllNomCta.Visible = True
                dtDatosCliente = d.ObtieneDatoscliente(txNumCta.Text)
                dllNomCta.DataSource = dtDatosCliente
                dllNomCta.DisplayMember = "nombrecliente"
                dllNomCta.ValueMember = "producto_contratado"

                If dllNomCta.Items.Count = 0 Then
                    MsgBox("La cuenta no existe o no es valida para solicitud de chequera.", vbInformation, "Cuenta Inexistente")
                    txNumCta.Text = ""
                    txNumCta.Focus()
                ElseIf dllNomCta.Items.Count = 1 Then
                    ObtenDatosTicket()
                    dllNomCta.SelectedIndex = 0
                End If
            End If
        End If

    End Sub


    Private Sub dllNomCta_Leave(sender As Object, e As EventArgs) Handles dllNomCta.Leave

        Dim d As New Datasource
        Dim dtDatosNumCuenta As DataTable

        If dllNomCta.SelectedIndex > -1 Then
            If Trim(CStr(dllNomCta.SelectedValue)) <> "" Then
                ObtenDatosTicket()
                btAceptar.Enabled = True
                btSolError.Enabled = True
                grbDatosCuenta.Enabled = True
                grbNoEspeciales.Enabled = True
                If txNumCta.Text = "" Then
                    dtDatosNumCuenta = d.ObtieneNumCuenta(dllNomCta.SelectedValue)
                    txNumCta.Text = dtDatosNumCuenta.Rows(0).Item(0)
                    dtDatosNumCuenta = d.ObtieneDatoscliente(txNumCta.Text) '---------RACB 12/03/2021
                    dllNomCta.DataSource = dtDatosNumCuenta '---------RACB 12/03/2021
                    dllNomCta.DisplayMember = "nombrecliente" '---------RACB 12/03/2021
                    dllNomCta.ValueMember = "producto_contratado" '---------RACB 12/03/2021
                End If
                'No hay datos de la Cuenta
                If Trim$(txGestorPesos.Text) = "" Then
                    txGestorPesos.Focus()
                    'Hay datos previos de la Cuenta
                Else
                    If txNumGestor.Visible = True And txNumGestor.Enabled = True Then
                        txNumGestor.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dllNumCheques_DropDown(sender As Object, e As EventArgs) Handles dllNumCheques.DropDown

        Dim d As New Datasource
        Dim dtDatosChequera As DataTable
        'Llena combo numero de cheques
        dllNumCheques.Visible = True
        dtDatosChequera = d.LoadTipoChequera()
        dllNumCheques.DataSource = dtDatosChequera
        dllNumCheques.DisplayMember = "descripcion"
        dllNumCheques.ValueMember = "tipo_chequera"
    End Sub


End Class