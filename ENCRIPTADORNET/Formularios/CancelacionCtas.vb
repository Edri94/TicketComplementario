Public Class CancelacionCtas

    Dim sProductoContratado As String
    Dim sStatusProducto As String
    Dim sCta As String
    Dim PFideicomiso As String
    Dim bStatus0 As Boolean
    Dim bStatus2 As Boolean
    Dim lsSufijo As String
    Dim lsPrefijo As String
    Dim lsNombreFunc As String
    Dim lsRutaFunc As String
    Dim liNumeroFunc As Integer
    Dim msProdCont As Integer
    Dim gn_Usuario As Integer
    Dim RegEmptyControls As Integer



#Region "Eventos"
    Private Sub txCuenta_Leave(sender As Object, e As EventArgs) Handles txCuenta.Leave

        txSufijo.Text = ""
        Try
            If Not cargaAgencia() Then
                limpiarCampos()
                Exit Sub
            End If

            If Not ExisteCuenta() Then
                limpiarCampos()
                Exit Sub
            End If

            llenaCampos()
        Catch ex As Exception
            MsgBox("Ocurrio un error en el evento: txCuenta_Leave", vbInformation, "Cancelación de cuentas")
            Exit Sub
        End Try

    End Sub

    Private Sub btActualizar_Click(sender As Object, e As EventArgs) Handles btActualizar.Click
        btActualizar.Enabled = True
        Dim d As New DataSourceModCancelaCtas
        Dim dtDatosCta As DataTable
        Dim sExisteHistorico As String = ""
        Dim RegistroHist As Integer
        Dim RegActStatusCta As Integer

        Dim dtUlStatus As DataTable
        Dim lnStatusAnterior As Integer
        Dim RegDatos As Integer
        Dim sCausa As String
        Dim RegBloqFideicomiso As Integer
        Dim RegCancelacionCTA As Integer
        Dim dtBRNFunCTA As DataTable
        Dim RegCancelaFideicomiso As Integer
        Dim RegCanReCTA1 As Integer
        Dim RegCanReCTA2 As Integer
        Dim RegCanReCTA3 As Integer
        Dim dtBuscaCTA As DataTable
        Dim RegExisteDirec As Integer
        Dim RegActualizaDirec As Integer
        Dim dtBuscaFun As DataTable
        Dim RegAsignafun As Integer
        Dim RegAsignafunCancela As Integer
        Dim dtStored As DataTable
        Dim dtStatusOP As DataTable
        Dim lbBanderita As Boolean
        Dim RegReactivaCTA As Integer
        Dim dtSreactivaCTA As DataTable
        Dim RegStatusAper As Integer
        Dim Regcomplementa As Integer
        Dim RegMERDactCTA As Integer
        Dim RegCTAhouston As Integer
        Dim RegDIRECCION_ENVIO As Integer
        Dim RegDIRECCION_ENVIO2 As Integer
        Dim RegDIRECCION_ENVIO3 As Integer
        Dim RegFuncionarioAsig As Integer
        Dim sOpcionRealizada As String
        Dim ifunCta As Integer
        Dim ibuscaCta As Integer
        Dim iestatusOper As Integer
        Dim RegManntoCta As Integer
        Dim RegEventOper As Integer

        sOpcionRealizada = ""
        lnStatusAnterior = 1

        If Not DatosCorrectos() Then
            Exit Sub
        End If

        Try
            'Obtenemos datos de la cuenta: prefijo_agencia, sufijo_kapiti
            dtDatosCta = d.ObtenDatosCuenta(sCta)
            'MsgBox("registros de dtDatosCta.Rows.Count(): " & dtDatosCta.Rows.Count())

            'La siguiente validaciòn funciona si en el select realizado NO realizamos un count de registros, aplica para lista de campos
            If dtDatosCta.Rows.Count() = 0 Then
                MsgBox("No existen datos de la cuenta.", vbCritical, "Cancelación de Cuentas")
                Exit Sub
            Else
                lsPrefijo = dtDatosCta.Rows(0).Item(0)
                lsSufijo = dtDatosCta.Rows(0).Item(1)

                '***************************
                'Falta formato de fecha para Fecha operaciòn  en tabla de Mantenimiento Cuenta
                '***************************

                'Se desea cancelar la cuenta
                '***********************************
                ' Opcion Cuenta Cancelada
                '***********************************
                If optCancelada.Checked Then

                    'MsgBox("Entro a Opcion de Cancelacion de Cuenta")
                    sExisteHistorico = d.ExisteHistorico(sCta)
                    'MsgBox("sExisteHistorico: " & sExisteHistorico)

                    If sExisteHistorico <> "" Then
                        If Convert.ToInt32(sExisteHistorico) = 0 Then
                            Try
                                RegistroHist = d.InsertaHistorico(sCta)

                                'OGJ eliminar los mensajes de cara al usuario
                                If RegistroHist > 0 Then
                                    MsgBox("Se ha ingresado en Historico correctamente.", vbInformation, "Cancelación de Cuentas")
                                End If

                            Catch ex As Exception
                                MsgBox("Error en base de datos funcion InsertaHistorico.", vbInformation, "Cancelación de Cuentas")
                            End Try
                        End If
                    End If
                End If     'FIN If optCancelada.Checked Then



                'Se va a reactivar la cuenta
                If optActiva.Checked Then
                    'MsgBox("sProductoContratado")
                    'MsgBox(sProductoContratado)
                    'Obtiene el ultimo estatus de la cuenta
                    dtUlStatus = d.UltimoStatusCuenta(sProductoContratado)
                    'validar resultado del select
                    lnStatusAnterior = dtUlStatus.Rows(0).Item(0)
                    'MsgBox("dtUlStatus")
                    'MsgBox(dtUlStatus)
                    'MsgBox("lnStatusAnterior")
                    'MsgBox(lnStatusAnterior)

                End If    'FIN If optActiva.Checked Then



                'valida que opcion fue seleccionada
                If optActiva.Checked Then
                    sOpcionRealizada = "Activa"
                ElseIf optCancelada.Checked Then
                    sOpcionRealizada = "Cancelada"
                End If


                'OGJ Falta Cancelaciòn de BankLink de la Cuenta a Cancelar
                'se manejara en la cancelacion final el no validar el banklink

                '********************************************************
                'Actualiza el status del Producto Contratado de la Cuenta Eje
                '********************************************************
                RegActStatusCta = d.ActualizaStatusCta(sStatusProducto, sCta, sProductoContratado, lnStatusAnterior, sOpcionRealizada)
                'MsgBox("RegActStatusCta")


                '********************************************************
                'Guarda los datos de la cancelación/reactivación
                '********************************************************
                sCausa = txCausa.Text
                RegDatos = d.InsertaDatosReactivaCanc(sProductoContratado, sStatusProducto, usuario, sCausa)
                'MsgBox("RegDatos")


                'Bloqueo de Cuenta para el Fideicomiso
                If optBloqueada.Checked And PFideicomiso = 1 Then
                    RegBloqFideicomiso = d.BloqueoFideicomiso(sCta)
                End If

                '********************************************************
                'CancelacionCTA
                '********************************************************
                If optCancelada.Checked Then
                    'MsgBox("RegCancelacionCTA")
                    RegCancelacionCTA = d.CancelacionCTA(sCta)

                    'Busca Ruta y Nombre de Funcionario de la Cuenta
                    'MsgBox("dtBRNFunCTA")
                    dtBRNFunCTA = d.BRNFunCTA(sCta)

                    'validar valor de retorno del query, sino hay respuesta, asignar blancos
                    lsNombreFunc = dtBRNFunCTA.Rows(0).Item(0)
                    lsRutaFunc = dtBRNFunCTA.Rows(0).Item(1)
                    'MsgBox("lsNombreFunc: " & lsNombreFunc)
                    'MsgBox("lsRutaFunc: " & lsRutaFunc)

                    'End If

                    '********************************************************
                    'MERD cancelacion del Fideicomiso
                    '********************************************************
                    If optCancelada.Checked And PFideicomiso = 1 Then
                        'MsgBox("RegCancelaFideicomiso")
                        RegCancelaFideicomiso = d.CancelacionFideicomiso(sCta)
                        'MsgBox("RegCancelaFideicomiso saliendo")
                    End If


                    'DGI 29-05-2008 PARA LA CANCELACION Y REACTIVACION DE CUENTAS
                    '*********************************************************************
                    'Actualiza colonia de envio en la tabla HIST_CAN_REAC_CTA con el valor de la tabla DIREECION_ENVIO
                    'MsgBox("RegCanReCTA1")
                    RegCanReCTA1 = d.CanReCTA1(sCta)

                    'Actualiza direccion de envio en la tabla HIST_CAN_REAC_CTA con el valor de la tabla DIREECION_ENVIO
                    'MsgBox("RegCanReCTA2")
                    RegCanReCTA2 = d.CanReCTA2(sCta)

                    'Actualiza codigo postal de envio en la tabla HIST_CAN_REAC_CTA con el valor de la tabla DIREECION_ENVIO
                    'MsgBox("RegCanReCTA3")
                    RegCanReCTA3 = d.CanReCTA3(sCta)
                    '********************************************************************

                    'Busca si existe la cuenta en DIRECCION_ENVIO, esta con la funcion BuscaCTA, pero es una busqueda de la Direccion_Envio
                    dtBuscaCTA = d.BuscaCTA(sCta)
                    ibuscaCta = dtBuscaCTA.Rows(0).Item(0)
                    'MsgBox("dtBuscaCTA")
                    If ibuscaCta > 0 Then
                        'Existe dirección de envio, procede a la actualizaciòn de la direcciòn de envio, esta como ExisteDirec, pero es el Update de Direcciòn_Envio UpdDirecEnvio
                        'MsgBox("RegExisteDirec")
                        'RegExisteDirec = d.ExisteDirec(sCta)
                        RegExisteDirec = d.UpdDirecEnv(sCta, lsRutaFunc, lsNombreFunc)
                        'MsgBox("RegExisteDirec" & RegExisteDirec)
                    Else
                        'si no hay direccion de envio, debe de insertar un registro en Direcciòn_envio
                        'esta como ActualizaDirec, pero es el Insert sobre Direcciòn_Envio. InsDirecEnv
                        'MsgBox("RegActualizaDirec")
                        'RegActualizaDirec = d.ActualizaDirec(sCta, lsRutaFunc, lsNombreFunc)
                        RegActualizaDirec = d.InsDirecEnv(sCta, lsRutaFunc, lsNombreFunc)
                        'MsgBox("RegActualizaDirec: " & RegActualizaDirec)
                    End If


                    'Buscamos los funcionarios para actualizarlos 
                    'MsgBox("RegActualizaDirec" & RegActualizaDirec)

                    'If ibuscaCta > 0 Then 'si no encuentra cuenta en direccion de envio entonces pasa la sig fun
                    'If RegActualizaDirec = 0 Then
                    'busca el funcionario de la cuenta
                    'MsgBox("dtBuscaFun")

                    dtBuscaFun = d.BuscaFun(sCta)
                    ifunCta = dtBuscaFun.Rows(0).Item(0)

                    'MsgBox("dtBuscaFun: " & ifunCta)
                    'Se encontro información de la cuenta
                    If ifunCta <> 0 Then
                        liNumeroFunc = dtBuscaFun.Rows.Count()
                        'MsgBox("liNumeroFunc")
                    Else
                        MsgBox("Ha ocurrido un error en el procesamiento de la transacción. Se recomienda cancelar y capturar nuevamente ", vbRetryCancel, " Error de SQL Server")
                        Exit Sub
                    End If
                    'End If


                    'Actualiza Funcionario de Cancelación en la tabla HIST_CAN_REAC_CTA, esta como Asignafun, pero actualiza HIST_CAN_REAC_CTA
                    RegAsignafun = d.Asignafun(sCta)
                    'MsgBox("RegAsignafun: " & RegAsignafun)

                    If RegAsignafun > 0 Then

                        'Asigna Funcionario de Cancelación, en tabla de CLIENTE 
                        RegAsignafunCancela = d.AsignafunCancela(sCta)
                        'MsgBox("RegAsignafunCancela")
                        If RegAsignafun > 0 Then

                            If liNumeroFunc <> 0 And liNumeroFunc <> 4252 Then
                                'Ejecutamos el stored para indicar que el funcionario no tiene cuentas  podriamos pasar ifunCta
                                'dtStored = d.Stored(sCta)
                                'dtStored = d.Stored(ifunCta)
                                dtStored = d.Stored(liNumeroFunc)
                                'MsgBox("dtStored")

                            End If

                        End If

                    End If

                    'Busca estatus de la Operaciòn asociada a la apertura de la cuenta
                    'MsgBox("dtStatusOP")
                    'MsgBox("sProductoContratado: " & sProductoContratado)
                    dtStatusOP = d.StatusOP(sProductoContratado)
                    'Por ser datatable, se obtiene el estatus de la operacion
                    iestatusOper = dtStatusOP.Rows(0).Item(0)

                    'MsgBox("dtStatusOP: " & dtStatusOP.Rows.Count())
                    If iestatusOper = 3 Or iestatusOper = 4 Then     'Estatus 3-Enviado a Equation; Estatus 4-Integrada en Equation
                        lbBanderita = True
                    Else
                        lbBanderita = False
                    End If

                    If lbBanderita Then
                        MsgBox("La Cancelación NO realiza envio a Equation, Ni envio a Swift de forma Automática", vbInformation)
                    End If


                    'manda llamar Identity
                    'esto porque?
                    'dtBuscaFun = d.BuscaFun(sCta)
                    'MsgBox("dtBuscaFun")

                    '****************************************************************************
                    '  inserta en la tabla de Mantenimientos de Cuentas, registro de control
                    '****************************************************************************
                    'sProductoContratado     'gn_Usuario    'RegManntoCta
                    'verificar si va dentro de la condiciòn de banderita, despues del mensaje
                    RegManntoCta = d.InsMantenimientoCuenta(sProductoContratado, gn_Usuario)
                    'MsgBox("RegManntoCta:" & RegManntoCta)


                    '******************************
                    'Inserta en Evento operaciòn
                    '******************************
                    RegEventOper = d.InsEventoProducto(sProductoContratado, gn_Usuario, "Cancelacion de cuenta", 8039)


                End If   'Termina If optCancelada.Checked Then





                'DGI (EDS) Nuevo Reactivación de cuenta
                '******************************************************
                ' Primero valida si esta activo la opcion de Reactivar
                '******************************************************
                ' Opcion Cuenta Activa
                '******************************************************
                If optActiva.Checked Then

                    RegReactivaCTA = d.ReactivaCTA(sCta)
                    MsgBox("RegReactivaCTA:" & RegReactivaCTA)

                    'validar si debe ir esta condisciòn
                    'If RegReactivaCTA = 0 Then
                    'MsgBox("Entro a Reactivar la cuenta RegReactivaCTA:")
                    Dim lnOperacionAper = 0
                    Dim lnStatusAper = 0

                    dtSreactivaCTA = d.sConsOper_Status(sCta, lsPrefijo, lsSufijo)
                    MsgBox("dtSreactivaCTA")
                    MsgBox(dtSreactivaCTA.Rows.Count)

                    If Not dtSreactivaCTA.Rows.Count = 0 Then
                        MsgBox("Asigna Operacion y Estatus")
                        lnOperacionAper = dtSreactivaCTA.Rows(0).Item(0)
                        lnStatusAper = dtSreactivaCTA.Rows(0).Item(1)
                        MsgBox(lnOperacionAper)
                        MsgBox(lnStatusAper)
                    End If

                    MsgBox(lnStatusAper)
                    If lnStatusAper = 250 Then
                        RegStatusAper = d.StatusAper(lnOperacionAper)
                        If RegStatusAper = 0 Then
                            'Inserta en Evento Operaciòn la reactivaciòn
                            MsgBox("Inserta Evento Operacion Reactivacion")
                            Regcomplementa = d.InsEventoOperacion(lnOperacionAper, gn_Usuario)
                        End If
                    End If

                    'MERD Activacion de la cuenta
                    If optActiva.Checked And PFideicomiso = 1 Then
                        'If dtDatosCta.Rows.Count() And PFideicomiso = 1 Then
                        'Actualiza Estatus del fideicomiso
                        RegMERDactCTA = d.MERDactCTA(sCta)
                        MsgBox("Actualiza Fideicomiso Reactiva RegMERDactCTA")
                        If RegMERDactCTA = 0 Then
                        End If
                    End If

                    'DGI 29-05-2008 PARA LA CANCELACION Y REACTIVACION DE CUENTAS
                    RegCTAhouston = d.CTAhouston(sCta)
                    MsgBox("RegCTAhouston: " & RegCTAhouston)

                    'If RegCTAhouston = 0 Then

                    MsgBox("Entro a Actualizar Direcciones por Reactivacion")
                    RegDIRECCION_ENVIO = d.DIRECCION_ENVIO(sCta)
                    If RegDIRECCION_ENVIO = 0 Then
                        'se da rollback
                    End If
                    RegDIRECCION_ENVIO2 = d.DIRECCION_ENVIO3(sCta)
                    If RegDIRECCION_ENVIO2 = 0 Then
                        'se da rollback
                    End If
                    RegDIRECCION_ENVIO3 = d.DIRECCION_ENVIO3(sCta)
                    If RegDIRECCION_ENVIO3 = 0 Then
                        'se da rollback
                    End If

                    MsgBox("No hay registro de la direccion de envio para ser actualizada", vbInformation)
                    'End If

                    RegFuncionarioAsig = d.UpdFuncCuenta(sCta)
                    'RegFuncionarioAsig = d.FuncionarioAsig(sCta)
                    'UpdFuncCuenta
                    MsgBox("RegFuncionarioAsig")
                    If RegFuncionarioAsig = 0 Then
                        MsgBox("La cuenta No tiene Funcionario Asignado en el Historial para su Reactivacion", vbInformation)

                    End If


                    'End If 'fin DGI (EDS) Nuevo Reactivación de cuent

                End If   'Fin If optActiva.Checked Then

                If optCancelada.Checked Then
                    MsgBox("La Cuenta  " & sCta & "  ha sido cancelada en Ticket.", vbInformation, "Cancelación de Cuentas")
                ElseIf optActiva.Checked Then
                    MsgBox("La Cuenta   " & sCta & "  ha sido reactivada en TIcket.", vbInformation, "Reactivación de Cuentas")
                End If

                btActualizar.Enabled = False

            End If    'fin If dtDatosCta.Rows.Count() = 0 Then

            Exit Sub

        Catch ex As Exception
            MsgBox("No es posible obtener datos de la cuenta.", vbCritical, "SQL Server Error")
            Exit Sub
        End Try


    End Sub

    'Private Sub txSufijo_Leave(sender As Object, e As EventArgs) Handles txSufijo.Leave

    '    If txSufijo.Text <> String.Empty Then
    '        If txCuenta.Text = String.Empty Then
    '            MsgBox("Es necesario ingresar el numero de cuenta", vbInformation, "Cancelación de cuentas")
    '            txCuenta.Focus()
    '            Exit Sub
    '        End If
    '    End If
    'End Sub

    Private Sub txSufijo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txSufijo.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    'Private Sub txCuenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txCuenta.KeyPress
    Private Sub txCuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txCuenta.KeyPress


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

    End Sub

    Private Sub btSalir_Click(sender As Object, e As EventArgs) Handles btSalir.Click
        If (String.IsNullOrEmpty(txCuenta.Text)) Then

            If btActualizar.Enabled Then
                If MsgBox("No ingreso ningun Dato ¿Desea salir?", vbYesNo + vbQuestion + vbDefaultButton2, "Apoderados") <> vbYes Then Exit Sub
                Me.Close()
                Return
            Else
                Me.Close()
                Return
            End If
        End If

        If btActualizar.Enabled Then
            If MsgBox("La cuenta no se ha actualizado. ¿Desea salir sin guardar los cambios?", vbYesNo + vbQuestion + vbDefaultButton2, "Apoderados") <> vbYes Then Exit Sub
            Me.Close()
            Return
        Else
            Me.Close()
            Return
        End If





    End Sub

    Private Sub optActiva_CheckedChanged(sender As Object, e As EventArgs) Handles optActiva.CheckedChanged


        If bStatus0 Then
            optActiva.Text = "Reactivar cuenta"
            optBloqueada.Enabled = False

            gTituloCausa.Text = "Causa de la reactivación"
            txCausa.Enabled = True
            btActualizar.Enabled = True
            txCausa.Text = String.Empty
            txCausa.Focus()

        End If



    End Sub

    Private Sub optCancelada_CheckedChanged(sender As Object, e As EventArgs) Handles optCancelada.CheckedChanged
        Dim d As New DataSourceModCancelaCtas
        Dim dt As DataTable
        Dim dtProdActivos As DataTable
        Dim saldo As Integer = 0
        Dim iProdActivos As Integer



        If sStatusProducto <> "39" Then

            dt = d.buscaSaldoCta(sProductoContratado)

            If dt.Rows.Count() Then
                saldo = dt.Rows(0).Item(0)
            End If

            If saldo <> 0 Then
                'La cuenta tiene saldo (acreedor o deudor)
                If saldo < 0 Then
                    'El saldo es deudor
                    MsgBox("Esta cuenta no se puede cancelar porque está sobregirada.", vbCritical, "Cancelación de Cuentas")



                    optCancelada.Checked = False
                    optCancelada.Enabled = False
                    optActiva.Enabled = False
                    optActiva.Checked = True
                ElseIf saldo > 0 Then
                    'El saldo es acreedor
                    MsgBox("Esta cuenta no se puede cancelar porque tiene saldo a favor.", vbCritical, "Cancelación de Cuentas")

                    optCancelada.Checked = False
                    'limpiarCampos()
                    optCancelada.Enabled = False
                    optActiva.Enabled = False
                    optActiva.Checked = True

                End If

                txCausa.Enabled = False
                btActualizar.Enabled = False

                Exit Sub


            End If


            dtProdActivos = d.buscaProductosActivos(sCta)
            iProdActivos = dtProdActivos.Rows(0).Item(0)

            'La cuenta tiene productos activos
            If iProdActivos > 0 Then
                'If dtProdActivos.Rows.Count > 0 Then
                MsgBox("Esta cuenta no se puede cancelar porque tiene " & dtProdActivos.Rows.Count & " operaciones pendientes.", vbCritical, "Cancelación de Cuentas")
                optCancelada.Checked = False
                optCancelada.Enabled = False

                optActiva.Enabled = False
                optActiva.Checked = True
                txCausa.Enabled = False
                btActualizar.Enabled = False

                Exit Sub
                optCancelada.Checked = False
                optCancelada.Enabled = False
                optActiva.Enabled = False
                limpiarCampos()

            End If

            If bStatus2 Then
                gTituloCausa.Text = "Causa de la cancelacion"
                txCausa.Enabled = True
                btActualizar.Enabled = True
                txCausa.Text = String.Empty
                txCausa.Focus()


            End If


            gTituloCausa.Text = "Causa de la cancelacion"
            btActualizar.Enabled = True
            txCausa.Text = String.Empty
            txCausa.Focus()

            'optCancelada.Checked = False



        End If





    End Sub
#End Region

#Region "Funciones"
    Function cargaAgencia() As Boolean

        Dim d As New Datasource
        Dim dtAgencia As DataTable


        If txCuenta.Text = String.Empty Then
            'MsgBox("Es necesario ingresar el numero de cuenta", vbInformation, "Cancelación de cuentas")
            Return False
        End If

        dtAgencia = d.ObtenAgencia(txCuenta.Text.Trim()) 'Funcion que obtiene la clave y descripcion de la Agencia
        If dtAgencia.Rows.Count() > 0 Then
            dllAgencia.DisplayMember = "NombreAgencia"
            dllAgencia.ValueMember = "agencia"
            dllAgencia.DataSource = dtAgencia
        Else
            MsgBox("El numero cuenta no existe en la base de datos", vbInformation, "Cancelación de cuentas")

            optActiva.Enabled = False
            optActiva.Checked = False
            Return False
            optCancelada.Checked = False
            optCancelada.Enabled = False


        End If

        Return True

    End Function

    Function ExisteCuenta() As Boolean
        Dim d As New DataSourceModCancelaCtas
        Dim dtBuscaCta As DataTable
        Dim sSufijo As String

        sCta = txCuenta.Text.ToString().Trim()

        dtBuscaCta = d.buscaCuenta(sCta)

        If dtBuscaCta.Rows.Count > 0 Then
            sProductoContratado = dtBuscaCta.Rows(0).Item(0).ToString().Trim()
            sStatusProducto = dtBuscaCta.Rows(0).Item(1).ToString().Trim()
            sSufijo = dtBuscaCta.Rows(0).Item(2).ToString().Trim()
            txSufijo.Text = sSufijo
            txSufijo.Enabled = False
        Else
            MsgBox("No existe la cuenta", vbInformation, "Cancelación de cuentas")
            Return False
        End If

        Return True

    End Function

    Sub llenaCampos()
        Dim d As New DataSourceModCancelaCtas
        Dim dt As DataTable
        Dim l As New Libreria

        optActiva.Enabled = True
        optBloqueada.Enabled = False
        optCancelada.Enabled = True

        Select Case sStatusProducto
            Case "1"
                'Cuenta activa
                optActiva.Checked = True
                gTituloCausa.Visible = True
                gTituloCausa.Text = "Comentario"
                dt = d.MotivoCta(sProductoContratado)
                'txCausa.Text = l.LowCaseName(dt.Rows(0).Item(0).ToString().Trim())
                bStatus0 = False
                bStatus2 = True
                btActualizar.Enabled = False
            Case "4"
                'Cuenta bloqueada
                optBloqueada.Checked = True
                gTituloCausa.Visible = True
                gTituloCausa.Text = "Causa del bloqueo"
                dt = d.MotivoCtaBloqueada(sProductoContratado)
                txCausa.Text = l.LowCaseName(dt.Rows(0).Item(0).ToString().Trim())
                bStatus0 = False
                bStatus2 = True
                txCausa.Visible = True
                btActualizar.Enabled = False
            Case "39"
                'Cuenta cancelada
                optCancelada.Checked = True
                gTituloCausa.Visible = True
                gTituloCausa.Text = "Causa de la cancelacion"
                dt = d.MotivoCtaCancelada(sProductoContratado)
                txCausa.Text = l.LowCaseName(dt.Rows(0).Item(0).ToString().Trim())
                bStatus0 = True
                bStatus2 = False
                btActualizar.Enabled = False
        End Select

        If bStatus0 Then
            optActiva.Text = "Reactivar cuenta"
            optBloqueada.Enabled = False
            optCancelada.Enabled = True
        End If

        If bStatus2 Then
            optCancelada.Text = "Cancelar cuenta"
            optActiva.Enabled = True
        End If


        PFideicomiso = d.EsFideicomiso(sCta)


    End Sub

    Sub limpiarCampos()
        txCuenta.Text = String.Empty
        txSufijo.Text = String.Empty
        dllAgencia.Text = String.Empty
        txCausa.Text = String.Empty
    End Sub

    Function DatosCorrectos() As Boolean
        If (optCancelada.Checked = False) And (optActiva.Checked = False) Then
            MsgBox("Debe elegir un estado para la cuenta (Activa o Cancelada).", vbInformation, "Cancelación de Cuentas")
            Return False
        End If
        If Trim(txCausa.Text) = String.Empty Then
            If optCancelada.Checked Then
                MsgBox("Debe escribir el motivo de la cancelación.", vbInformation, "Cancelación de Cuentas")
                txCausa.Focus()
                Return False
            End If
            If optActiva.Checked Then
                MsgBox("Debe escribir el motivo de la reactivación.", vbInformation, "Reactivación de Cuentas")
                txCausa.Focus()
                Return False
            End If
        End If

        Return True

    End Function

    Private Sub txCuenta_TextChanged(sender As Object, e As EventArgs) Handles txCuenta.TextChanged

    End Sub

    Private Sub CancelacionCtas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gn_Usuario = usuario
        Me.CenterToScreen()
    End Sub































#End Region
End Class