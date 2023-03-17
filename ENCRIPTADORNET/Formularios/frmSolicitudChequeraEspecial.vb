'*************    Módulo de Chequeras    **************'
'****       Fecha de Creación: 02/06/2020           ***'
'**** Creado por: SGGG-Susan Gabriela Gómez González***' 
Imports VB = Microsoft.VisualBasic
Public Class frmSolicitudChequeraEspecial

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

    Private Sub frmSolicitudChequeraEspeciales_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'iReportes = 1
        txFechaSolicitud.Text = Date.Now.Date.ToString("dd-MM-yyyy")
        Me.CenterToScreen()
        Me.Text = "Solicitud de Chequeras Especiales"
        txNumCta.Focus()
        grbEspeciales.Visible = True
        grbReporte.Visible = True
        LimpiaCampos(1, btLimpiar)
        'Inicio la fecha de impresion al dia de hoy como default
        dtpFechaIni.Text = DateTime.Now
        dtpFechaFin.Text = DateTime.Now
        btSolError.Enabled = False
        btAceptar.Enabled = True

        dllNomCta.DataSource = Nothing
        dllNomCta.DisplayMember = Nothing
        dllNomCta.ValueMember = Nothing

        dllSucCta.DataSource = Nothing
        dllSucCta.DisplayMember = Nothing
        dllSucCta.ValueMember = Nothing
        dllSucCta.SelectedIndex = -1

        txCRCta.CharacterCasing = CharacterCasing.Upper

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
        dtpFechaIni.Value = DateTime.Now
        dtpFechaFin.Value = DateTime.Now
        btCancelar.Visible = False
        grbReporte.Enabled = True
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
                LimpiaCamposGrp(Me.grbEspeciales)
                LimpiaCamposGrp(Me.grbReporte)
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
            If TypeOf lo_Control Is ComboBox Then
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

            sProdCont = dllNomCta.SelectedValue

            If Not ObtenNuevoCheque(CLng(sProdCont), lnUltimoChq, lnStatus, Ln_LongCHQ) Then Exit Sub

            'Si es un registro con error cambia el status
            If Erroneo Then lnStatus = STSChequera.D_Sol_Incorrecta  '"5"
            sLastPart = ""

            'Es chequera especial
            iChequera = d.InsertaChequera(2, sProdCont, "", "", "", txGestorPesos.Text, txNumCRCta.Text, txCRCta.Text, txNumSucCta.Text,
                                dllSucCta.Text, txCtaEjePesos.Text, txNumCheques.Text, lnUltimoChq, Ln_LongCHQ, lnStatus, "", Erroneo, sComentario)
            If iChequera.Rows(0).Item(0) = 0 Then
                MsgBox("No es posible registrar el alta de la chequera.", vbCritical, "SQL Server Error")
                Exit Sub
            End If
            lblRegistro.Text = iChequera.Rows(0).Item(0)

            'Es solicitud Errónea
            If Erroneo = True Then
                lblFolioIni.Text = CStr(lnUltimoChq + 1).Substring(RightToLeft, Ln_LongCHQ)
                lblFolioFin.Text = lblFolioIni.Text
            Else
                lblFolioIni.Text = CStr(lnUltimoChq + 1).Substring(RightToLeft, Ln_LongCHQ)
                lblFolioFin.Text = CStr(lnUltimoChq + Val(txNumCheques.Text)).Substring(RightToLeft, Ln_LongCHQ)
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

            grbEspeciales.Enabled = False
            grbReporte.Enabled = True
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
                End If
                'No hay una solicitud anterior
            Else
                'Busca el número de cuenta eje pesos del cliente
                dtDatosCtaEje = d.DatosCuentaEje(CStr(dllNomCta.SelectedValue))
                'Encontro el número de cuenta
                If dtDatosCtaEje.Rows(0).Item(0) <> 0 Then
                    sCtaEjePesos = Trim(dtDatosCtaEje.Rows(0).Item(0))
                End If
            End If
            'dbEndQuery

            'Muestra la cuenta eje pesos (si esta es valida)
            txCtaEjePesos.Text = sCtaEjePesos

            'ShowDefaultCursor
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en ObtenDatosTicket: " & ex.Message, vbInformation, "SolicitudChequeraEspecial")
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
            If MsgBox("La sucrusal de la cuenta que ingreso no existe, " & vbCrLf &
                    "¿Desea darla de alta?", vbYesNo + vbQuestion,
                    "Agregar sucursal") = vbYes Then

                Reg_SucCHQ = d.InsertaSucursal_CHQ(txNumSucCta.Text, dllSucCta.Text)
                'Error al insertar
                If Reg_SucCHQ = 0 Then
                    MsgBox("Hubo un error al dar de alta la sucursal de la cuenta", vbInformation, "Error al insertar")
                End If
            End If
        End If
        If Val(txNumCheques.Text) = 0 Then
            MsgBox("Es necesario indicar el número de cheques que se solicitan.", vbInformation, "Dato Faltante...")
            txNumCheques.Focus()
            Exit Function
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
                ObtenNuevoCheque = False
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
                'Si esta en cero es porque no se ha generado ningun cheque
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

            'Exit Function
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
            dtpFechaIni.Text = DateTime.Now
            dtpFechaFin.Text = DateTime.Now
            grbEspeciales.Enabled = False
            grbDatosCuenta.Enabled = False
            btAceptar.Enabled = False
            btSolError.Enabled = False
            txNumCheques.Enabled = True
        End If
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

    Private Sub txNumCheques_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txNumCheques.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
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
            dtpFechaIni.Text = DateTime.Now
            dtpFechaFin.Text = DateTime.Now
        End If
        'End If
    End Sub


#End Region

    Private Sub dllSucCta_DropDown(sender As Object, e As EventArgs) Handles dllSucCta.DropDown
        Dim d As New Datasource
        Dim dtDatosSucursal As New DataTable
        txNumSucCta.Text = ""
        'Llenar datos de sucursales
        dtDatosSucursal = d.LoadSucursal(dllSucCta.Text, txNumSucCta.Text)
        'Llena el combo de sucursales (si se encontraron)
        dllSucCta.Visible = True
        dllSucCta.DataSource = dtDatosSucursal
        dllSucCta.DisplayMember = "suc_nombre"
        dllSucCta.ValueMember = "suc_sucursal"
    End Sub

    Private Sub dllNomCta_DropDown(sender As Object, e As EventArgs) Handles dllNomCta.DropDown
        Dim d As New Datasource
        Dim dtDatosCliente As New DataTable
        txNumCta.Text = ""
        LimpiaCampos(2, dllNomCta)
        dllNomCta.Visible = True
        dtDatosCliente = d.ObtieneDatoscliente("")
        dllNomCta.DataSource = dtDatosCliente
        dllNomCta.DisplayMember = "nombrecliente"
        dllNomCta.ValueMember = "producto_contratado"
    End Sub
    Private Sub dllSucCta_Leave(sender As Object, e As EventArgs) Handles dllSucCta.Leave
        If dllSucCta.SelectedValue <> Nothing Then
            txNumSucCta.Text = dllSucCta.SelectedValue
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
                Else
                    'gs_sql = SendMessage(cmbNombre.hWnd, 335, 1, 0)
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
                grbEspeciales.Enabled = True
                If txNumCta.Text = "" Then
                    dtDatosNumCuenta = d.ObtieneNumCuenta(dllNomCta.SelectedValue)
                    txNumCta.Text = dtDatosNumCuenta.Rows(0).Item(0)
                End If
                'No hay datos de la Cuenta
                If Trim$(txGestorPesos.Text) = "" Then
                    txGestorPesos.Focus()
                    'Hay datos previos de la Cuenta
                Else
                    If txNumCheques.Visible = True And txNumCheques.Enabled = True Then
                        txNumCheques.Focus()
                    End If
                End If
            End If
        End If
    End Sub


    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click

        'Dim reporte As New ReportDocument
        'Dim l As New Libreria
        'Dim List As New List(Of String)
        ''Try

        Dim sFechaIni As String
            Dim sFechaFin As String

        sFechaIni = DateAdd("d", 0, dtpFechaIni.Text)
            sFechaFin = DateAdd("d", 1, dtpFechaFin.Text)

            'Imprime Solo chequeras especiales
            'arma el query que se pasara al reporte
            ls_PorImprimir = ""
            ls_PorImprimir &= "{CHEQUERAS.tipo_chequera} = 1 "
            ls_PorImprimir &= "And {CHEQUERAS.fecha_solicitud} >= Date (" & sFechaIni.Substring(6, 4) & "," & sFechaIni.Substring(3, 2).Trim & "," & sFechaIni.Substring(0, 2).Trim & ") " & ", "
            ls_PorImprimir &= "AND {CHEQUERAS.fecha_solicitud} <  Date (" & sFechaFin.Substring(6, 4).Trim & "," & sFechaFin.Substring(3, 2).Trim & "," & sFechaFin.Substring(0, 2).Trim & ") " & ", "
            ls_PorImprimir &= "And {CHEQUERAS.bbvab}=True"

            ''Reporte de Chequera Especial
        'lsReporte = "D:\CHQ_PrograsaBBVAEsp" & lsAmbiente & ".rpt"
        ''asigna el reporte a el objeto "reporte"
        'reporte.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
        ''realiza la conexion del objeto "reporte" con la BD 
        'l.logonBDreporte(reporte, 1)
        ''actualiza objeto "reporte"
        'reporte.Refresh()
        'reporte.DataDefinition.FormulaFields.Item("Fecha").Text = "'" & Now().ToString("yyyy-MM-dd") & "'"
        'reporte.DataDefinition.FormulaFields.Item("Hora").Text = "'" & Now().ToString("hh:mm") & "'"
        'reporte.DataDefinition.FormulaFields.Item("Origen").Text = "'BBVA'"

        'reporte.RecordSelectionFormula = (ls_PorImprimir)


        ''Mostramos el reporte
        'crvRepOper.ReportSource = reporte

        'Catch ex As Exception
        '    MsgBox("Ha ocurrido un error: " & ex.Message)
        '    Exit Sub
        'End Try

    End Sub
    'Friend WithEvents crvRepOper As CrystalReportViewer

End Class