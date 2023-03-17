Public Class ConsultaCTA
    Dim FTicket As String
    Dim FProductoContratado As Integer
    Dim FCuentaCliente As String
    Dim FPersonaMoral As String
    Dim sCta As String
    Dim sProductoContratado As String
    Dim sStatusProducto As String
    Dim iEstatusOpe As Integer
    Dim sMotivoBloqueo As String = ""
    Dim sMotivoAlerta As String = ""


    Private Sub ConsultaCTA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        lblAlertas.Text = ""
        lblBloqueos.Text = ""
        lblAlertas.Visible = False
        lblBloqueos.Visible = False
        lblAlertas.Enabled = False
        lblBloqueos.Enabled = False
        lblMotivoCancelacion.Visible = False
        lblMotivoCancelacion.Enabled = False
        lblTipoCuenta.Text = ""
        Me.Size = New Size(1140, 685)
    End Sub


    Private Sub txConsulta_Leave(sender As Object, e As EventArgs) Handles txConsulta.Leave
        Try

            Cursor = System.Windows.Forms.Cursors.WaitCursor
            If Not ExisteCuenta2() Then
                LimpiarCompApertura()
                LimpiarDireccionEnvio()
                Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If

            CargaParte1(sCta)
            CargaParte2(sCta)
            CargaDatosGestor(sCta)
            If iEstatusOpe <> 1 Then   'No esta complementada, y NO hay datos que cargar
                CombosUbicacionEnvio()
                CargaParte3(sCta)
            ElseIf iEstatusOpe = 1 Then
                LimpiarDatosxComplementar()
            End If

            If FPersonaMoral = "1" Then
                Lbpersona1.Text = "Moral"
                LbPersona.Visible = True
                Lbpersona1.Visible = True
                LbPersona.Enabled = True
                Lbpersona1.Enabled = True
                btBeneficiario.Text = "Apoderado"
                btCotitulares.Visible = False
            Else
                Lbpersona1.Text = "Fisica"
                LbPersona.Visible = True
                Lbpersona1.Visible = True
                btBeneficiario.Text = "Beneficiario"
                btCotitulares.Visible = True
            End If

            If sStatusProducto = "1" Then
                If iEstatusOpe = 1 Then
                    Label25.Text = "Activa, por Complementar Datos"
                    Label25.ForeColor = Color.Blue
                Else
                    Label25.Text = "Activa"
                    Label25.ForeColor = Color.Green
                End If
                Label24.Visible = True
                Label25.Visible = True
                'busca alertas

            End If
            If sStatusProducto = "4" Then
                Label25.Text = "Bloqueada"
                Label24.Visible = True
                Label25.Visible = True
                Label25.ForeColor = Color.OrangeRed
                If buscaMotivoBloqueo(sProductoContratado) Then
                    lblBloqueos.Enabled = True
                    lblBloqueos.Visible = True
                    lblBloqueos.Text = sMotivoBloqueo.ToString.Trim
                End If
            End If
            If sStatusProducto = "39" Then
                Label25.Text = "Cancelada"
                Label24.Visible = True
                Label25.Visible = True
                Label25.ForeColor = Color.Red
                'buscar motivo de cancelación
                lblMotivoCancelacion.Visible = True
                lblMotivoCancelacion.Text = ObtieneMotivoCancela(sProductoContratado)
                lblMotivoCancelacion.ForeColor = Color.Red
                'lblMotivoCancelacion.Font = Font.Bold
                txtFecCan.Visible = True
                Label28.Visible = True
            End If
            Label24.Enabled = True
            Label25.Enabled = True

            If buscaMotivoAlerta(sProductoContratado) Then
                lblAlertas.Enabled = True
                lblAlertas.Visible = True
                lblAlertas.Text = sMotivoAlerta.ToString.Trim
            End If

            'muestra tipo de cuenta
            CargaParte4(sProductoContratado)
            Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Cursor = System.Windows.Forms.Cursors.Default
            'MsgBox("Ocurrio un error en el evento: txCuenta_Leave", vbInformation, "Cancelación de cuentas")
            Exit Sub
        End Try

    End Sub


    'Llenado de combo Ubicacion
    Sub CombosUbicacion()
        Try
            Dim d = New Datasource
            Dim dt As DataTable


            dt = d.DatosUbicacion()

            dllCiudad.DisplayMember = "descripcion"
            dllCiudad.ValueMember = "ubicacion"
            dllCiudad.DataSource = dt

        Catch ex As Exception
            MsgBox("Error en carga de Combos Ubicación")
            Exit Sub
        End Try

    End Sub

    'Llenado de combo Ubicacion Envio
    Sub CombosUbicacionEnvio()
        Try
            Dim d = New Datasource
            Dim dt As DataTable

            dt = d.DatosUbicacion()

            dllCiudadEnv.DisplayMember = "descripcion"
            dllCiudadEnv.ValueMember = "ubicacion"
            dllCiudadEnv.DataSource = dt


        Catch ex As Exception
            MsgBox("Error en carga de Combos Ubicación Envio")
            Exit Sub
        End Try

    End Sub



    Private Sub btAutorizados_Click(sender As Object, e As EventArgs) Handles btAutorizados.Click
        Try
            Dim fVerAutorizados As New VerAutorizados()
            sCta = txConsulta.Text.ToString().Trim()
            If sCta > 0 Then
                'If IsNothing(CuentaCompApertura) Then
                'MsgBox("Debe seleccionar una cuenta.", vbInformation, "Validar Apertura")
                'Exit Sub
                'End If
                CuentaCompApertura = sCta
                fVerAutorizados.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en btAutorizados_Click: " & ex.Message, vbInformation, "Validacion de Apertura")
            Exit Sub
        End Try
    End Sub

    Private Sub btBeneficiario_Click(sender As Object, e As EventArgs) Handles btBeneficiario.Click
        Try
            sCta = txConsulta.Text.ToString().Trim()
            If sCta > 0 Then
                'If IsNothing(FPersonaMoral) Then
                'MsgBox("Debe seleccionar una cuenta.", vbInformation, "Actualización datos complemento")
                'Exit Sub
                'End If

                If FPersonaMoral = "1" Then
                    Dim fVerApoderados As New VerApoderados()
                    'CuentaCompApertura = FCuentaCliente
                    CuentaCompApertura = sCta

                    'If IsNothing(CuentaCompApertura) Then
                    'MsgBox("Debe seleccionar una cuenta.", vbInformation, "Validar Apertura")
                    '' Exit Sub
                    ' End If

                    fVerApoderados.ShowDialog()
                End If
                If FPersonaMoral = "0" Then
                    btBeneficiario.Text = "Beneficiario"
                    Dim fVerBeneficiarios As New VerBeneficiarios()
                    CuentaCompApertura = sCta

                    'If IsNothing(CuentaCompApertura) Then
                    'MsgBox("Debe seleccionar una cuenta.", vbInformation, "Validar Apertura")
                    'Exit Sub
                    'End If

                    fVerBeneficiarios.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en btBeneficiario_Click: " & ex.Message, vbInformation, "Validacion de Apertura")
            Exit Sub
        End Try
    End Sub

    Private Sub btCotitulares_Click(sender As Object, e As EventArgs) Handles btCotitulares.Click
        Try
            Dim fVerCotitulares As New VerCotitulares()
            CuentaCompApertura = FCuentaCliente
            sCta = txConsulta.Text.ToString().Trim()
            If sCta > 0 Then

                CuentaCompApertura = sCta
                'If IsNothing(CuentaCompApertura) Then
                'MsgBox("Debe seleccionar una cuenta.", vbInformation, "Validar Apertura")
                'Exit Sub
                ' End If

                fVerCotitulares.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en btCotitulares_Click: " & ex.Message, vbInformation, "Validacion de Apertura")
            Exit Sub
        End Try

    End Sub

    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
        Me.Close()
    End Sub

    'Funcion que llena datos de linea telefonica, grabadora, fecha de apertura Primera parte.
    Sub CargaParte1(ByVal sCuenta As String)
        Try
            Dim dcta = New Datasource
            Dim dtcta As DataTable

            sProductoContratado = ""

            dtcta = dcta.LoadCuenta(sCuenta)
            'txlinea.Text = dt.Rows(0).Item(0)          'Ya no aplica
            'txgrabadora.Text = dt.Rows(0).Item(1)      'Ya no aplica

            txTicket.Text = dtcta.Rows(0).Item(5)
            txCuenta.Text = dtcta.Rows(0).Item(1)
            sProductoContratado = dtcta.Rows(0).Item(0).ToString()

            txfechaApertura.Text = dtcta.Rows(0).Item(2).ToString().Substring(0, 10)
            txhoraApertura.Text = dtcta.Rows(0).Item(3).ToString().Substring(0, 5)

            'Obtiene Producto contratado
            'FProductoContratado = dt.Rows(0).Item(2)
            txTicket.Enabled = False
            txCuenta.Enabled = False

            txfechaApertura.Enabled = False
            txhoraApertura.Enabled = False

            'obtenemos estatus de la operaciòn
            iEstatusOpe = dtcta.Rows(0).Item(4)
            'MsgBox("realizo cargaparte1")
            '------------- RACB 11/01/2022
            If dtcta.Rows(0).Item(7).ToString() IsNot Nothing And dtcta.Rows(0).Item(7).ToString() <> "" Then
                txtFecCan.Text = dtcta.Rows(0).Item(7).ToString().Substring(0, 16)
            Else
                txtFecCan.Text = ""
            End If
            '------------- RACB 11/01/2022
            txtFecCan.Visible = False
            Label28.Visible = False
        Catch ex As Exception
            MsgBox("Error en carga de datos de la Cuenta (Funcion CargaParte1): " & ex.Message)
            Exit Sub
        End Try

    End Sub

    'Funcion que llena datos de la cuenta Parte 2 datos del cliente.
    Sub CargaParte2(ByVal sCuenta As String)
        Dim d = New Datasource
        Dim dt As DataTable
        Dim dtUbica As DataTable
        Dim iUbicacion As Integer = 0
        Dim iTipoUbicacion As Integer = 0
        Dim sCiudadEstado As String = ""
        Dim sSql As String = ""

        Try
            dt = d.LoadCuentaParte2(sCuenta)

            txNombre.Text = dt.Rows(0).Item(0)
            txApellidoPat.Text = dt.Rows(0).Item(8)
            txApellidoMat.Text = dt.Rows(0).Item(9)
            txCalle.Text = dt.Rows(0).Item(1)
            txCP.Text = dt.Rows(0).Item(2)
            txTelefonoCte.Text = dt.Rows(0).Item(3)
            txFax.Text = dt.Rows(0).Item(4)
            dllCiudad.SelectedValue = dt.Rows(0).Item(20)
            'dllCiudad.Text = dt.Rows(0).Item(6)
            txFunPesos.Text = dt.Rows(0).Item(7)
            txColonia.Text = dt.Rows(0).Item(10)
            txNumExt.Text = dt.Rows(0).Item(12)
            txNumInt.Text = dt.Rows(0).Item(13)
            txComponente.Text = dt.Rows(0).Item(14)
            txRFC.Text = dt.Rows(0).Item(15)
            FPersonaMoral = dt.Rows(0).Item(17)
            txCuentaEje.Text = dt.Rows(0).Item(18)
            txFechaCtaEje.Text = dt.Rows(0).Item(19)

            txNombre.Enabled = False
            txApellidoPat.Enabled = False
            txApellidoMat.Enabled = False
            txRFC.Enabled = False

            iUbicacion = dt.Rows(0).Item(20)
            iTipoUbicacion = iUbicacion

            While iTipoUbicacion > 0
                If iTipoUbicacion > 3 Then
                    sSql = "select ubicacion, descripcion_ubicacion, tipo_ubicacion, ubicacion_padre from CATALOGOS..UBICACION where ubicacion = " & iUbicacion
                    dtUbica = d.RealizaConsulta(sSql)
                    If dtUbica IsNot Nothing And dtUbica.Rows.Count() Then
                        If sCiudadEstado = "" Then
                            sCiudadEstado = dtUbica.Rows(0).Item(1).ToString.Trim
                        Else
                            sCiudadEstado &= ", " & dtUbica.Rows(0).Item(1).ToString.Trim
                        End If
                        iTipoUbicacion = dtUbica.Rows(0).Item(2).ToString
                        iUbicacion = dtUbica.Rows(0).Item(3).ToString
                    Else
                        Exit While
                    End If
                Else
                    iTipoUbicacion = 0
                End If
            End While
            dllCiudad.Text = sCiudadEstado

        Catch ex As Exception
            MsgBox("Error en carga de datos de la Cuenta (Funcion CargaParte2): " & ex.Message)
            Exit Sub
        End Try

    End Sub

    'Funcion que llena datos de la cuenta Parte 3 datos Direccion Envio.
    Sub CargaParte3(ByVal sCuenta As String)
        Dim d = New Datasource
        Dim dt As DataTable
        Dim dtUbica As DataTable
        Dim iUbicacion As Integer = 0
        Dim iTipoUbicacion As Integer = 0
        Dim sCiudadEstado As String = ""
        Dim sSql As String = ""
        Try
            dt = d.LoadCuentaParte3(sCuenta)
            txCalleEnvio.Text = dt.Rows(0).Item(0)
            txCPEnv.Text = dt.Rows(0).Item(1)
            txColoniaEnv.Text = dt.Rows(0).Item(2)
            'dllCiudadEnv.SelectedValue = dt.Rows(0).Item(3)
            txNumExtEnv.Text = dt.Rows(0).Item(4)
            txNumIntEnv.Text = dt.Rows(0).Item(5)
            txComponenteEnv.Text = dt.Rows(0).Item(6)
            dllCiudadEnv.Text = dt.Rows(0).Item(8)

            iUbicacion = dt.Rows(0).Item(3)
            iTipoUbicacion = iUbicacion

            While iTipoUbicacion > 0
                If iTipoUbicacion > 3 Then
                    sSql = "select ubicacion, descripcion_ubicacion, tipo_ubicacion, ubicacion_padre from CATALOGOS..UBICACION where ubicacion = " & iUbicacion
                    dtUbica = d.RealizaConsulta(sSql)
                    If sCiudadEstado = "" Then
                        sCiudadEstado = dtUbica.Rows(0).Item(1).ToString.Trim
                    Else
                        sCiudadEstado &= ", " & dtUbica.Rows(0).Item(1).ToString.Trim
                    End If
                    iTipoUbicacion = dtUbica.Rows(0).Item(2).ToString
                    iUbicacion = dtUbica.Rows(0).Item(3).ToString
                Else
                    iTipoUbicacion = 0
                End If
            End While
            dllCiudadEnv.Text = sCiudadEstado


        Catch ex As Exception
            MsgBox("Error en carga de datos de la Cuenta (Funcion CargaParte3): " & ex.Message)
            Exit Sub
        End Try

    End Sub

    Sub CargaParte4(ByVal sProducCont As String)
        Dim d = New Datasource
        Dim dt As DataTable
        Dim dtUbica As DataTable
        Dim iUbicacion As Integer = 0
        Dim iTipoUbicacion As Integer = 0
        Dim sCiudadEstado As String = ""
        Dim sSql As String = ""
        Try
            dt = d.LoadTipoCuenta(sProducCont)
            lblTipoCuenta.Text = "Tipo Cuenta: "
            lblTipoCuenta.Text &= dt.Rows(0).Item(3) & " - " & dt.Rows(0).Item(2)

        Catch ex As Exception
            MsgBox("Error en carga de datos de la Cuenta (Funcion LoadTipoCuenta): " & ex.Message)
            Exit Sub
        End Try

    End Sub


    Sub CargaDatosGestor(ByVal sCuenta As String)
        Try
            Dim d = New Datasource
            Dim dt As DataTable

            dt = d.ObtenDatosGestor(sCuenta)
            'txFunDll.Text = dt.Rows(0).Item(6)
            txFunDll.Text = dt.Rows(0).Item(2)
            txNombreFunDll.Text = dt.Rows(0).Item(3)

        Catch ex As Exception
            MsgBox("Error en carga de datos de la Cuenta (Funcion CargaDatosGestor): " & ex.Message)
            Exit Sub
        End Try

    End Sub

    Sub LimpiarDireccionEnvio()
        txCalleEnvio.Text = String.Empty
        txNumExtEnv.Text = String.Empty
        txNumIntEnv.Text = String.Empty
        txCPEnv.Text = String.Empty
        txComponenteEnv.Text = String.Empty
        txColoniaEnv.Text = String.Empty
        dllCiudadEnv.SelectedValue = 0
        dllCiudadEnv.Text = String.Empty

    End Sub

    Sub LimpiarCompApertura()

        txTicket.Text = String.Empty
        txCuenta.Text = String.Empty
        txNombre.Text = String.Empty
        txApellidoPat.Text = String.Empty
        txApellidoMat.Text = String.Empty
        txRFC.Text = String.Empty
        txfechaApertura.Text = String.Empty
        txhoraApertura.Text = String.Empty

        txTelefonoCte.Text = String.Empty
        txFax.Text = String.Empty
        txRFC.Text = String.Empty
        txFunPesos.Text = String.Empty
        txFunDll.Text = String.Empty
        txNombreFunDll.Text = String.Empty
        txFechaCtaEje.Text = String.Empty
        txCalle.Text = String.Empty
        txNumExt.Text = String.Empty
        txNumInt.Text = String.Empty
        txCP.Text = String.Empty
        txComponente.Text = String.Empty
        txColonia.Text = String.Empty
        dllCiudad.SelectedIndex = 0
        LimpiarDireccionEnvio()
    End Sub

    Sub LimpiarDatosxComplementar()

        txTelefonoCte.Text = String.Empty
        txFax.Text = String.Empty
        txFunPesos.Text = String.Empty

        'txFechaCtaEje.Text = String.Empty
        txCalle.Text = String.Empty
        txNumExt.Text = String.Empty
        txNumInt.Text = String.Empty
        txCP.Text = String.Empty
        txComponente.Text = String.Empty
        txColonia.Text = String.Empty
        'txCuentaEje.Text = String.Empty

        txCalleEnvio.Text = String.Empty
        txNumExtEnv.Text = String.Empty
        txNumIntEnv.Text = String.Empty
        txCPEnv.Text = String.Empty
        txComponenteEnv.Text = String.Empty
        txColoniaEnv.Text = String.Empty
        dllCiudadEnv.Text = String.Empty

        'dllCiudad.SelectedIndex = 0
        'dllCiudadEnv.SelectedValue = 0


    End Sub

    Private Function ObtieneMotivoCancela(sProducCont As String) As String

        Dim sSQLconsulta As String = ""
        Dim d As New Datasource
        Dim dtBuscaMotivo As DataTable

        ObtieneMotivoCancela = ""

        sSQLconsulta = " Select motivo "
        sSQLconsulta &= " from TICKET..CANCELA_REACTIVA_CUENTAS "
        sSQLconsulta &= " where producto_contratado = " & sProducCont
        sSQLconsulta &= " order by fecha desc" '--- RACB 08/11/2021

        dtBuscaMotivo = d.RealizaConsulta(sSQLconsulta)
        'ObtieneMotivoCancela = d.RealizaConsulta(sSQLconsulta)
        If dtBuscaMotivo.Rows.Count > 0 Then
            ObtieneMotivoCancela = "Motivo de Cancelación: " & dtBuscaMotivo.Rows(0).Item(0).ToString.Trim
        End If

    End Function

    Private Sub txConsulta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txConsulta.KeyPress
        Dim dtAut As DataTable
        Dim dtBen As DataTable
        Dim dtCot As DataTable
        Dim dtApo As DataTable
        Dim objData As New Datasource

        'If Not IsNumeric(e.KeyChar) Then
        'e.Handled = True

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        'End If
        If AscW(e.KeyChar) = CInt(Keys.Enter) Then
            Try
                btAutorizados.Visible = True
                btBeneficiario.Visible = True
                Cursor = System.Windows.Forms.Cursors.WaitCursor
                If Not ExisteCuenta2() Then
                    LimpiarCompApertura()
                    LimpiarDireccionEnvio()
                    Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub
                End If

                CargaParte1(sCta)
                CombosUbicacion()
                CargaParte2(sCta)
                CargaDatosGestor(sCta)
                If iEstatusOpe <> 1 Then   'No esta complementada, y NO hay datos que cargar
                    CombosUbicacionEnvio()
                    CargaParte3(sCta)
                ElseIf iEstatusOpe = 1 Then
                    LimpiarDatosxComplementar()
                End If

                If FPersonaMoral = "1" Then
                    Lbpersona1.Text = "Moral"
                    LbPersona.Visible = True
                    Lbpersona1.Visible = True
                    LbPersona.Enabled = True
                    Lbpersona1.Enabled = True
                    btBeneficiario.Text = "Apoderado"
                    btCotitulares.Visible = False
                Else
                    Lbpersona1.Text = "Fisica"
                    LbPersona.Visible = True
                    Lbpersona1.Visible = True
                    btBeneficiario.Text = "Beneficiario"
                    btCotitulares.Visible = True
                End If

                If sStatusProducto = "1" Then
                    If iEstatusOpe = 1 Then
                        Label25.Text = "Activa, por Complementar Datos"
                        Label25.ForeColor = Color.Blue
                    Else
                        Label25.Text = "Activa"
                        Label25.ForeColor = Color.Green
                    End If
                    Label24.Visible = True
                    Label25.Visible = True
                    'busca alertas

                End If
                If sStatusProducto = "4" Then
                    Label25.Text = "Bloqueada"
                    Label24.Visible = True
                    Label25.Visible = True
                    Label25.ForeColor = Color.OrangeRed
                    If buscaMotivoBloqueo(sProductoContratado) Then
                        lblBloqueos.Enabled = True
                        lblBloqueos.Visible = True
                        lblBloqueos.Text = sMotivoBloqueo.ToString.Trim
                    End If
                End If
                If sStatusProducto = "39" Then
                    Label25.Text = "Cancelada"
                    Label24.Visible = True
                    Label25.Visible = True
                    Label25.ForeColor = Color.Red
                    'buscar motivo de cancelación
                    lblMotivoCancelacion.Visible = True
                    lblMotivoCancelacion.Text = ObtieneMotivoCancela(sProductoContratado)
                    lblMotivoCancelacion.ForeColor = Color.Red
                    'lblMotivoCancelacion.Font = Font.Bold
                    txtFecCan.Visible = True
                    Label28.Visible = True
                End If
                Label24.Enabled = True
                Label25.Enabled = True

                If buscaMotivoAlerta(sProductoContratado) Then
                    lblAlertas.Enabled = True
                    lblAlertas.Visible = True
                    lblAlertas.Text = sMotivoAlerta.ToString.Trim
                End If

                'muestra tipo de cuenta
                CargaParte4(sProductoContratado)
                Cursor = System.Windows.Forms.Cursors.Default

                dtAut = objData.ObtieneAutorizados(txConsulta.Text)
                If dtAut.Rows.Count > 0 Then
                    btAutorizados.Enabled = True
                Else
                    btAutorizados.Enabled = False
                End If

                dtBen = objData.ObtieneBeneficiarios(txConsulta.Text)
                dtApo = objData.ObtieneApoderados(txConsulta.Text)
                If dtBen.Rows.Count > 0 Or dtApo.Rows.Count > 0 Then
                    btBeneficiario.Enabled = True
                Else
                    btBeneficiario.Enabled = False
                End If

                dtCot = objData.ObtieneCotitulares(txConsulta.Text)
                If dtCot.Rows.Count > 0 Then
                    btCotitulares.Enabled = True
                Else
                    btCotitulares.Enabled = False
                End If

            Catch ex As Exception
                Cursor = System.Windows.Forms.Cursors.Default
                'MsgBox("Ocurrio un error en el evento: txCuenta_Leave", vbInformation, "Cancelación de cuentas")
                Exit Sub
            End Try
        End If

    End Sub

#Region "funciones"
    Function buscaMotivoBloqueo(sProducCont As String) As Boolean
        Dim sSQLconsulta As String = ""
        Dim d As New Datasource
        Dim dtBuscaMotivo As DataTable
        Dim dtBuscaDetMotivo As DataTable '-------------------------- Octavio

        buscaMotivoBloqueo = False

        sSQLconsulta = " Select bc.bloqueo_observacion, bo.descripcion_bloqueo_observacio, fecha_bloqueo_proceso"
        sSQLconsulta &= " from TICKET..BLOQUEO_CUENTAS_DINAMICO BC, BLOQUEO_OBSERVACION BO "
        sSQLconsulta &= " where producto_contratado = " & sProducCont
        sSQLconsulta &= " and BC.bloqueo_observacion = BO.bloqueo_observacion "
        sSQLconsulta &= " and BO.status_bloqueo = 1 order by fecha_bloqueo_proceso desc"

        dtBuscaMotivo = d.RealizaConsulta(sSQLconsulta)
        If dtBuscaMotivo.Rows.Count > 0 Then
            sMotivoBloqueo = "Motivo de Bloqueo: " & dtBuscaMotivo.Rows(0).Item(2).ToString.Trim & " - " & dtBuscaMotivo.Rows(0).Item(1).ToString.Trim
            '-------------------------- Octavio
            'Busca el detalle del bloqueo
            dtBuscaDetMotivo = Nothing
            sSQLconsulta = "Select explicacion From DETALLE_STATUS "
            sSQLconsulta &= "Where producto_contratado = " & sProducCont
            sSQLconsulta &= "and status_bloqueo = 1"

            dtBuscaDetMotivo = d.RealizaConsulta(sSQLconsulta)
            If dtBuscaDetMotivo.Rows.Count > 0 Then
                sMotivoBloqueo &= " " & Chr(13) & Space(25) & dtBuscaDetMotivo.Rows(0).Item(0).ToString.Trim
            End If
            '-------------------------- Octavio
        Else
            sMotivoBloqueo = "Sin Bloqueos."
            Exit Function
        End If

        buscaMotivoBloqueo = True
    End Function

    Function buscaMotivoAlerta(sProducCont As String) As Boolean
        Dim sSQLconsulta As String = ""
        Dim d As New Datasource
        Dim dtBuscaMotivo As DataTable
        Dim dtBuscaDetMotivo As DataTable '-------------------------- Octavio

        buscaMotivoAlerta = False

        sSQLconsulta = "Select bc.bloqueo_observacion, bo.descripcion_bloqueo_observacio, fecha_bloqueo_proceso "
        sSQLconsulta &= " from TICKET..BLOQUEO_CUENTAS_DINAMICO BC, BLOQUEO_OBSERVACION BO "
        sSQLconsulta &= " where producto_contratado = " & sProducCont
        sSQLconsulta &= " And BC.bloqueo_observacion = BO.bloqueo_observacion "
        sSQLconsulta &= " And status_bloqueo = 3 order by fecha_bloqueo_proceso desc"

        dtBuscaMotivo = d.RealizaConsulta(sSQLconsulta)
        If dtBuscaMotivo.Rows.Count > 0 Then
            sMotivoAlerta = "Motivo de Alerta: " & dtBuscaMotivo.Rows(0).Item(2).ToString.Trim & " - " & dtBuscaMotivo.Rows(0).Item(1).ToString.Trim
            '-------------------------- Octavio
            'Busca el detalle del bloqueo
            dtBuscaDetMotivo = Nothing
            sSQLconsulta = "Select explicacion From DETALLE_STATUS "
            sSQLconsulta &= "Where producto_contratado = " & sProducCont
            sSQLconsulta &= "and status_bloqueo = 3"

            dtBuscaDetMotivo = d.RealizaConsulta(sSQLconsulta)
            If dtBuscaDetMotivo.Rows.Count > 0 Then
                sMotivoAlerta &= " " & Chr(13) & Space(25) & dtBuscaDetMotivo.Rows(0).Item(0).ToString.Trim
            End If
            '-------------------------- Octavio
        Else
            sMotivoAlerta = "Sin Alertas."
            Exit Function
        End If

        buscaMotivoAlerta = True
    End Function

    Function ExisteCuenta2() As Boolean
        Dim d As New DataSourceModCancelaCtas
        Dim dtBuscaCta As DataTable
        Dim sSufijo As String

        'MsgBox("la cuenta en el textbox es:" & txConsulta.Text)
        sCta = txConsulta.Text.ToString().Trim()
        'MsgBox("la cuenta asignada es:" & sCta)
        dtBuscaCta = d.buscaCuenta(sCta)

        If dtBuscaCta.Rows.Count > 0 Then
            sProductoContratado = dtBuscaCta.Rows(0).Item(0).ToString().Trim()
            sStatusProducto = dtBuscaCta.Rows(0).Item(1).ToString().Trim()
            sSufijo = dtBuscaCta.Rows(0).Item(2).ToString().Trim()
            'txSufijo.Text = sSufijo
            'txSufijo.Enabled = False
        Else
            MsgBox("No existe la cuenta", vbInformation, "Cancelación de cuentas")
            Return False
        End If

        Return True

    End Function

#End Region

End Class