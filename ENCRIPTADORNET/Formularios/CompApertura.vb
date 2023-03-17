Public Class CompApertura
    Dim FTicket As String
    Dim FProductoContratado As Integer
    Dim FCuentaCliente As String
    Dim FPersonaMoral As String
    Private Sub CompApertura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Try
            Dim d As New Datasource

            txAgencia.Text = "Houston"
            txAgencia.Enabled = False
            lbPersona.Visible = False
            lbTpPersona.Visible = False

            'Llenado de operaciones con status in 1, 7
            gvOperaciones.DataSource = d.OperacionesPorComplementar

            'Llenado de combo Ubicacion y Ubicacion Envio
            CombosUbicacion()
            CombosUbicacionEnvio()

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en la funcion CompApertura_Load, Error:" & ex.Message, vbInformation, "Carga formulario CompApertura")
            Exit Sub
        End Try

    End Sub
    Private Sub gvOperaciones_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles gvOperaciones.CellMouseClick
        Try

            Dim d = New Datasource
            Dim dtExisteDir As DataTable
            Dim dtFun As DataTable
            Dim dg = New Datasource
            Dim dtRutaFun As DataTable

            If gvOperaciones.RowCount > 0 Then
                'Llena Campos
                FCuentaCliente = gvOperaciones.CurrentRow.Cells("cuenta").Value
                FTicket = Convert.ToUInt32(gvOperaciones.CurrentRow.Cells("ticket").Value)

                txCuenta.Text = FCuentaCliente
                txTicket.Text = FTicket

                txCuenta.Enabled = False
                txTicket.Enabled = False

                CargaParte1(FTicket)
                CargaParte2(FCuentaCliente)

                dtFun = d.ObtenDatosGestor(FCuentaCliente)
                txFunDll.Text = dtFun.Rows(0).Item(6)
                txNombreFunDll.Text = dtFun.Rows(0).Item(3)

                'carga ruta del gestor
                dtRutaFun = dg.ObtenPadreRutaGestor(FCuentaCliente)
                txRutaUnOrg.Text = dtRutaFun.Rows(0).Item(2)

                lbPersona.Visible = True
                lbTpPersona.Visible = True
                lbPersona.Enabled = True
                lbTpPersona.Enabled = True

                If FPersonaMoral = "1" Then
                    lbTpPersona.Text = "Persona Moral"
                    btBeneficiario.Text = "Apoderado"
                    btCotitulares.Visible = False
                Else
                    lbTpPersona.Text = "Persona Fisica"
                    btBeneficiario.Text = "Beneficiario"
                    btCotitulares.Visible = True
                End If

                dtExisteDir = d.ExisteDireccion(FCuentaCliente)

                If dtExisteDir.Rows(0).Item(0) > 0 Then
                    CargaParte3(FCuentaCliente)
                Else
                    'Limpiar campos de Direccion envio
                    LimpiarDireccionEnvio()
                End If
            End If

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento gvOperaciones_CellMouseClick, Error:" & ex.Message, vbInformation, "Seleccionar una operacion")
            Exit Sub
        End Try

    End Sub
    Private Sub btAceptar_Click(sender As Object, e As EventArgs) Handles btAceptar.Click
        Try

            If MsgBox("Esta seguro de validar el complemento de la apertura con numero de Ticket " & FTicket & ". ¿Desea Continuar?", vbYesNo + vbQuestion + vbDefaultButton2, "Complemento") <> vbYes Then Exit Sub

            Dim d = New Datasource
            Dim dtExisteDir As DataTable
            Dim Reg_clientes As Integer = 0
            Dim Reg_DireccionEnv As Integer = 0
            Dim Reg_operacion As Integer = 0
            Dim Reg_evento As Integer = 0

            If Not DatosCorrectos() Then
                Exit Sub
            End If

            Dim listaCliente As New List(Of ECliente)
            Dim ECte As New ECliente

            ECte.Cuenta = FCuentaCliente
            ECte.Calle = txCalle.Text.Trim()
            ECte.NoExt = txNumExt.Text.Trim()
            ECte.NoInt = txNumInt.Text.Trim()
            ECte.Componente = txComponente.Text.Trim()
            ECte.ColoniaCte = txColonia.Text.Trim()
            If dllCiudad.Text.Trim().Length > 28 Then
                ECte.Del_o_mun = dllCiudad.Text.Trim().Substring(1, 28)
            Else
                ECte.Del_o_mun = dllCiudad.Text.Trim()
            End If
            ECte.CPCte = txCP.Text.Trim()
            ECte.TelefonoCte = txTelefonoCte.Text.Trim()
            ECte.FaxCte = txFax.Text.Trim()
            ECte.RFC = txRFC.Text.Trim()
            ECte.Ubicacion = dllCiudad.SelectedValue
            ECte.FunPesos = txFunPesos.Text.Trim()

            'listaCliente.Add(ECte)

            'Actualiza datos de Clientes
            Reg_clientes = d.ActualizaDatosComp(ECte)

            dtExisteDir = d.ExisteDireccion(FCuentaCliente)

            Dim EDirEnv As New EDireccionEnv

            EDirEnv.Cuenta = FCuentaCliente
            EDirEnv.CPCte = txCPEnv.Text.Trim()
            EDirEnv.ColoniaCte = txColoniaEnv.Text.Trim()
            EDirEnv.Ubicacion = dllCiudadEnv.SelectedValue
            EDirEnv.Calle = txCalleEnvio.Text.Trim()
            EDirEnv.NoExt = txNumExtEnv.Text.Trim()
            EDirEnv.NoInt = txNumIntEnv.Text.Trim()
            EDirEnv.Componente = txComponenteEnv.Text.Trim()

            If dllCiudadEnv.Text.Trim().Length > 28 Then
                EDirEnv.Del_o_mun = dllCiudadEnv.Text.Trim().Substring(1, 28)
            Else
                EDirEnv.Del_o_mun = dllCiudadEnv.Text.Trim()
            End If


            'Inserta o Actualiza en Direccion Envio
            If dtExisteDir.Rows(0).Item(0) > 0 Then
                Reg_DireccionEnv = d.ActualizaDireccionEnvio(EDirEnv)
            Else
                Reg_DireccionEnv = d.InsertaDireccionEnvio(EDirEnv)
            End If

            'Actualiza status de operacion
            Reg_operacion = d.ActualizaOperacion(FTicket, usuario)

            'Inserta evento operacion
            Reg_evento = d.InsertaEventoOperacion(FTicket, usuario)

            If Reg_clientes > 0 And Reg_DireccionEnv > 0 And Reg_operacion > 0 And Reg_evento > 0 Then
                MsgBox("La apertura para la opercación " & FTicket.ToString() & " ha sido completada", vbInformation, "Actualización datos complemento")

                LimpiarCompApertura()

                'Llenado de operaciones con status = 1
                gvOperaciones.DataSource = d.OperacionesPorComplementar
            End If

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento btAceptar_Click, Error:" & ex.Message, vbInformation, "Complementar datos de Autorizado")
            Exit Sub
        End Try

    End Sub
    Private Sub btAutorizados_Click(sender As Object, e As EventArgs) Handles btAutorizados.Click
        Try
            Dim fCapAutorizados As New CapAutorizados()
            CuentaCompApertura = FCuentaCliente

            If IsNothing(CuentaCompApertura) Then
                MsgBox("Debe seleccionar una cuenta.", vbInformation, "Actualización datos complemento")
                Exit Sub
            End If

            fCapAutorizados.ShowDialog()
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en btAutorizados_Click: " & ex.Message, vbInformation, "Complemento de Apertura")
            Exit Sub
        End Try

    End Sub
    Private Sub btBeneficiario_Click(sender As Object, e As EventArgs) Handles btBeneficiario.Click
        Try
            If IsNothing(FPersonaMoral) Then
                MsgBox("Debe seleccionar una cuenta.", vbInformation, "Actualización datos complemento")
                Exit Sub
            End If

            If FPersonaMoral = "1" Then
                'Apoderado
                Dim fCapApoderados As New CapApoderados()
                CuentaCompApertura = FCuentaCliente

                If IsNothing(CuentaCompApertura) Then
                    MsgBox("Debe seleccionar una cuenta.", vbInformation, "Actualización datos complemento")
                    Exit Sub
                End If

                fCapApoderados.ShowDialog()
            End If

            If FPersonaMoral = "0" Then
                'Beneficiario
                btBeneficiario.Text = "Beneficiario"
                Dim fCapBeneficiarios As New CapBeneficiarios()
                CuentaCompApertura = FCuentaCliente

                If IsNothing(CuentaCompApertura) Then
                    MsgBox("Debe seleccionar una cuenta.", vbInformation, "Actualización datos complemento")
                    Exit Sub
                End If

                fCapBeneficiarios.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en btBeneficiario_Click: " & ex.Message, vbInformation, "Complemento de Apertura")
            Exit Sub
        End Try

    End Sub
    Private Sub btCotitulares_Click(sender As Object, e As EventArgs) Handles btCotitulares.Click
        Try
            Dim fCapCotitulares As New CapCotitulares()

            CuentaCompApertura = FCuentaCliente

            If IsNothing(CuentaCompApertura) Then
                MsgBox("Debe seleccionar una cuenta.", vbInformation, "Actualización datos complemento")
                Exit Sub
            End If

            fCapCotitulares.ShowDialog()

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en btCotitulares_Click: " & ex.Message, vbInformation, "Complemento de Apertura")
            Exit Sub
        End Try
    End Sub
    Private Sub CkReplicarDir_CheckedChanged(sender As Object, e As EventArgs) Handles CkReplicarDir.CheckedChanged
        Try
            'Replicar Direccion a Direccion Envio
            If CkReplicarDir.Checked Then
                txCalleEnvio.Text = txCalle.Text
                txNumExtEnv.Text = txNumExt.Text
                txNumIntEnv.Text = txNumInt.Text
                txCPEnv.Text = txCP.Text
                txComponenteEnv.Text = txComponente.Text
                txColoniaEnv.Text = txColonia.Text
                dllCiudadEnv.SelectedIndex = dllCiudad.SelectedIndex
            Else
                LimpiarDireccionEnvio()
            End If

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en CkReplicarDir_CheckedChanged: " & ex.Message, vbInformation, "Control replicar informacion de Direccion a Direccion Envio")
            Exit Sub
        End Try
    End Sub
    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
        Me.Close()
    End Sub

    'Funcion que llena datos de la cuenta, fecha de apertura Primera parte.
    Sub CargaParte1(ByVal iTicket As Integer)
        Try
            Dim d = New Datasource
            Dim dt As DataTable

            dt = d.LoadCuentaParte1(iTicket)
            'txlinea.Text = dt.Rows(0).Item(0)        'Ya no aplica
            'txgrabadora.Text = dt.Rows(0).Item(1)    'Ya no aplica
            txfechaApertura.Text = dt.Rows(0).Item(4).ToString().Substring(0, 10) '--------- RACB 14/10/2021
            txhoraApertura.Text = dt.Rows(0).Item(5).trim()

            'Obtiene Producto contratado
            FProductoContratado = dt.Rows(0).Item(2)

            txfechaApertura.Enabled = False
            txhoraApertura.Enabled = False
        Catch ex As Exception
            MsgBox("Error en carga de datos de la Cuenta (Funcion CargaParte1): " & ex.Message)
            Exit Sub
        End Try

    End Sub
    'Funcion que llena datos de la cuenta Parte 2 datos del cliente.
    Sub CargaParte2(ByVal sCuenta As String)
        Try
            Dim d = New Datasource
            Dim dt As DataTable

            dt = d.LoadCuentaParte2(sCuenta)

            txNombre.Text = dt.Rows(0).Item(0).trim()
            txApellidoPat.Text = dt.Rows(0).Item(8).trim()
            txApellidoMat.Text = dt.Rows(0).Item(9).trim()

            txCalle.Text = dt.Rows(0).Item(1).trim()
            txCP.Text = dt.Rows(0).Item(2).trim()
            txTelefonoCte.Text = dt.Rows(0).Item(3).trim()
            txFax.Text = dt.Rows(0).Item(4).trim()

            'dllCiudad.SelectedValue = dt.Rows(0).Item(6)
            dllCiudad.Text = dt.Rows(0).Item(6)

            txFunPesos.Text = dt.Rows(0).Item(7).trim()
            txColonia.Text = dt.Rows(0).Item(10).trim()
            txNumExt.Text = dt.Rows(0).Item(12).trim()
            txNumInt.Text = dt.Rows(0).Item(13).trim()
            txComponente.Text = dt.Rows(0).Item(14).trim()
            txRFC.Text = dt.Rows(0).Item(15).trim()
            FPersonaMoral = dt.Rows(0).Item(17)

            txNombre.Enabled = False
            txApellidoPat.Enabled = False
            txApellidoMat.Enabled = False

        Catch ex As Exception
            MsgBox("Error en carga de datos de la Cuenta (Funcion CargaParte2): " & ex.Message)
            Exit Sub
        End Try

    End Sub

    'Funcion que llena datos de la cuenta Parte 3 datos Direccion Envio.
    Sub CargaParte3(ByVal sCuenta As String)
        Try
            Dim d = New Datasource
            Dim dt As DataTable

            dt = d.LoadCuentaParte3(sCuenta)
            txCalleEnvio.Text = dt.Rows(0).Item(0).trim()
            txCPEnv.Text = dt.Rows(0).Item(1).trim()
            txColoniaEnv.Text = dt.Rows(0).Item(2).trim()
            dllCiudadEnv.SelectedValue = dt.Rows(0).Item(3)
            txNumExtEnv.Text = dt.Rows(0).Item(4).trim()
            txNumIntEnv.Text = dt.Rows(0).Item(5).trim()
            txComponenteEnv.Text = dt.Rows(0).Item(6).trim()
            dllCiudadEnv.Text = dt.Rows(0).Item(8).trim()

        Catch ex As Exception
            MsgBox("Error en carga de datos de la Cuenta (Funcion CargaParte3): " & ex.Message)
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

    Private Function DatosCorrectos() As Boolean

        DatosCorrectos = False
        '------ Campos obligatorios en el complemento de una apertura en Dirección ------
        If txCalle.Text.Trim() = String.Empty Then                    'No se ha capturado la calle
            MsgBox("Es necesario indicar la Calle.", vbInformation, "Dato Faltante")
            txCalle.Focus()
            Exit Function
        End If
        If txNumExt.Text.Trim() = String.Empty Then                    'No se ha capturado la direccion
            MsgBox("Es necesario indicar el No. Exterior.", vbInformation, "Dato Faltante")
            txNumExt.Focus()
            Exit Function
        End If
        If txColonia.Text.Trim() = String.Empty Then                      'No se ha capturado la colonia
            MsgBox("Es necesario indicar la Colonia del Cliente.", vbInformation, "Dato Faltante")
            txColonia.Focus()
            Exit Function
        End If

        If dllCiudad.SelectedValue <= 0 Then                     'No se ha seleccionado al Ubicacion
            MsgBox("Seleccione una ciudad de la lista.", vbInformation, "Dato Faltante")
            dllCiudad.Focus()
            Exit Function
        End If

        If txCP.Text.Trim() = String.Empty Then                           'No se ha capturado el C.P.
            MsgBox("Es necesario indicar el C.P. del Cliente.", vbInformation, "Dato Faltante")
            txCP.Focus()
            Exit Function
        End If


        '    '------ Campos obligatorios en el complemento de una apertura en Dirección Envío ------
        If Trim(txCalleEnvio.Text) <> "" Or Trim(txNumExtEnv.Text) <> "" Or
         Trim(txColoniaEnv.Text) <> "" Or dllCiudadEnv.SelectedValue > 0 Or
         Trim(txCPEnv.Text) <> "" Then           'Si alguno es diferencte de vacio, llenar todos

            If Trim(txCalleEnvio.Text) = String.Empty Then                    'No se ha capturado la calle
                MsgBox("Es necesario indicar la Calle de la Dirección de Envío.", vbInformation, "Dato Faltante")
                txCalleEnvio.Focus()
                Exit Function
            End If

            If Trim(txNumExtEnv.Text) = String.Empty Then                    'No se ha capturado la direccion
                MsgBox("Es necesario indicar el No. Exterior de la Dirección de Envío.", vbInformation, "Dato Faltante")
                txNumExtEnv.Focus()
                Exit Function
            End If
            If Trim(txColoniaEnv.Text) = String.Empty Then                  'No se ha capturado la colonia
                MsgBox("Es necesario indicar la Colonia de la Dirección de Envío.", vbInformation, "Dato Faltante")
                txColoniaEnv.Focus()
                Exit Function
            End If
            If dllCiudadEnv.SelectedValue <= 0 Then                     'No se ha seleccionado al Ubicacion
                MsgBox("Seleccione una Ciudad de la lista en Dirección de Envío.", vbInformation, "Dato Faltante")
                dllCiudadEnv.Focus()
                'mbDirecEnvio = False
                Exit Function
            End If
            If Trim(txCPEnv.Text) = String.Empty Then                           'No se ha capturado el C.P.
                MsgBox("Es necesario indicar el C.P. de la Dirección de Envío.", vbInformation, "Dato Faltante")
                txCPEnv.Focus()
                Exit Function
            End If
        End If


        '------------------ Datos obligatorios para el complemento --------------------
        If Trim(txTelefonoCte.Text) = "" Then
            MsgBox("Es necesario indicar el número de teléfono.", vbInformation, "Dato Faltante")
            txTelefonoCte.Focus()
            Exit Function
        End If
        If Trim(txFunPesos.Text) = "" Then
            MsgBox("Es necesario indicar el nombre del Gestor Pesos.", vbInformation, "Dato Faltante")
            txFunPesos.Focus()
            Exit Function
        End If
        If Trim(txRFC.Text) = "" Then
            MsgBox("Es necesario indicar el RFC.", vbInformation, "Dato Faltante")
            txRFC.Focus()
            Exit Function
        End If

        DatosCorrectos = True

    End Function

    Sub LimpiarDireccionEnvio()
        txCalleEnvio.Text = String.Empty
        txNumExtEnv.Text = String.Empty
        txNumIntEnv.Text = String.Empty
        txCPEnv.Text = String.Empty
        txComponenteEnv.Text = String.Empty
        txColoniaEnv.Text = String.Empty
        dllCiudadEnv.SelectedIndex = 0
    End Sub

    Sub LimpiarCompApertura()
        txTicket.Text = String.Empty
        txCuenta.Text = String.Empty
        txNombre.Text = String.Empty
        txApellidoPat.Text = String.Empty
        txApellidoMat.Text = String.Empty
        txfechaApertura.Text = String.Empty
        txhoraApertura.Text = String.Empty

        txTelefonoCte.Text = String.Empty
        txFax.Text = String.Empty
        txRFC.Text = String.Empty
        txFunPesos.Text = String.Empty
        txCalle.Text = String.Empty
        txNumExt.Text = String.Empty
        txNumInt.Text = String.Empty
        txCP.Text = String.Empty
        txComponente.Text = String.Empty
        txColonia.Text = String.Empty
        dllCiudad.SelectedIndex = 0

        txFunDll.Text = String.Empty
        txNombreFunDll.Text = String.Empty
        txRutaUnOrg.Text = String.Empty

        LimpiarDireccionEnvio()
    End Sub


End Class