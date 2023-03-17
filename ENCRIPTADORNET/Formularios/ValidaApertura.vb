Public Class ValidaApertura
    Dim FTicket As String
    Dim FProductoContratado As Integer
    Dim FCuentaCliente As String
    Dim FPersonaMoral As String
    Private Sub ValidaApertura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Try
            Dim d As New Datasource

            txAgencia.Text = "Houston"
            txAgencia.Enabled = False
            lbPersona.Visible = False
            lbTpPersona.Visible = False
            txRutaUnOrg.Enabled = False

            'Llenado de operaciones con status = 6
            gvOperaciones.DataSource = d.OperacionesPorValidar()

            'Llenado de combo Ubicacion y Ubicacion Envio
            CombosUbicacion()
            CombosUbicacionEnvio()

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en la funcion ValidaApertura_Load, Error:" & ex.Message, vbInformation, "Carga formulario ValidaApertura")
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

    Private Sub gvOperaciones_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles gvOperaciones.CellMouseClick
        Try
            Dim d = New Datasource
            Dim dtExisteDir As DataTable
            Dim dtFun As DataTable
            Dim dg = New Datasource
            Dim dtRutaFun As DataTable

            If Not String.IsNullOrEmpty(gvOperaciones.CurrentRow.Cells("cuenta").Value.ToString()) Then
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
                txRutaUnOrg.Enabled = False

                lbPersona.Visible = True
                lbTpPersona.Visible = True

                If FPersonaMoral = "1" Then
                    lbTpPersona.Text = "Moral"
                    btBeneficiario.Text = "Apoderado"
                    btCotitulares.Visible = False
                Else
                    lbTpPersona.Text = "Fisica"
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
            If MsgBox("Esta seguro de validar el Ticket " & FTicket & ". ¿Desea Continuar?", vbYesNo + vbQuestion + vbDefaultButton2, "Validacion") <> vbYes Then Exit Sub

            Dim d = New Datasource
            Dim dt As DataTable
            Dim gs_sql As String
            Dim opAtrasadas As Integer
            Dim Reg_operacion As Integer = 0
            Dim Reg_swift As Integer = 0
            Dim Reg_evento As Integer = 1

            'Existen depositos anteriores al dia de hoy
            dt = d.ExisteDepositosAnteriores(FProductoContratado)
            opAtrasadas = dt.Rows(0).Item(0)
            If opAtrasadas > 0 Then
                gs_sql = " La cuenta " & "8000-" & FCuentaCliente & " tiene " & opAtrasadas & " depósitos que no pueden ser " & Chr(13)
                gs_sql = gs_sql & "enviados a Equation por ser de fechas anteriores al día de hoy."
                MsgBox(gs_sql, vbInformation, "Operaciones de la Cuenta")
            End If

            'Actualiza status de operacion
            Reg_operacion = d.ValidaOperacion(FTicket, usuario)

            'Inserta evento operacion
            Reg_evento = d.InsertaEventoOperacionVal(FTicket, usuario)

            'registro para Swift
            Reg_swift = d.InsertaBitacoraSwift(FTicket)

            If Reg_operacion > 0 And Reg_evento > 0 And Reg_swift > 0 Then
                MsgBox("El ticket " & FTicket.ToString() & " ha sido validado", vbInformation, "Validacion de Ticket")
                LimpiarCompApertura()
                'Llenado de operaciones con status = 1
                gvOperaciones.DataSource = d.OperacionesPorComplementar
            End If

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento btAceptar_Click, Error:" & ex.Message, vbInformation, "Validar Autorizado")
            Exit Sub
        End Try

    End Sub

    Private Sub btAutorizados_Click(sender As Object, e As EventArgs) Handles btAutorizados.Click
        Try
            Dim fVerAutorizados As New VerAutorizados()
            CuentaCompApertura = FCuentaCliente

            If IsNothing(CuentaCompApertura) Then
                MsgBox("Debe seleccionar una cuenta.", vbInformation, "Validar Apertura")
                Exit Sub
            End If

            fVerAutorizados.ShowDialog()

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en btAutorizados_Click: " & ex.Message, vbInformation, "Validacion de Apertura")
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
                Dim fVerApoderados As New VerApoderados()
                CuentaCompApertura = FCuentaCliente

                If IsNothing(CuentaCompApertura) Then
                    MsgBox("Debe seleccionar una cuenta.", vbInformation, "Validar Apertura")
                    Exit Sub
                End If

                fVerApoderados.ShowDialog()
            End If
            If FPersonaMoral = "0" Then
                btBeneficiario.Text = "Beneficiario"
                Dim fVerBeneficiarios As New VerBeneficiarios()
                CuentaCompApertura = FCuentaCliente

                If IsNothing(CuentaCompApertura) Then
                    MsgBox("Debe seleccionar una cuenta.", vbInformation, "Validar Apertura")
                    Exit Sub
                End If

                fVerBeneficiarios.ShowDialog()
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

            If IsNothing(CuentaCompApertura) Then
                MsgBox("Debe seleccionar una cuenta.", vbInformation, "Validar Apertura")
                Exit Sub
            End If

            fVerCotitulares.ShowDialog()
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en btCotitulares_Click: " & ex.Message, vbInformation, "Validacion de Apertura")
            Exit Sub
        End Try

    End Sub

    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
        Me.Close()
    End Sub

    'Funcion que llena datos de linea telefonica, grabadora, fecha de apertura Primera parte.
    Sub CargaParte1(ByVal iTicket As Integer)
        Try
            Dim d = New Datasource
            Dim dt As DataTable

            dt = d.LoadCuentaParte1(iTicket)
            'txlinea.Text = dt.Rows(0).Item(0)          'Ya no aplica
            'txgrabadora.Text = dt.Rows(0).Item(1)      'Ya no aplica
            txfechaApertura.Text = dt.Rows(0).Item(4).ToString().Substring(0, 10)
            txhoraApertura.Text = dt.Rows(0).Item(5)

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

            Dim dtUbica As DataTable
            Dim iUbicacion As Integer = 0
            Dim iTipoUbicacion As Integer = 0
            Dim sCiudadEstado As String = ""
            Dim sSql As String = ""


            dt = d.LoadCuentaParte2(sCuenta)
            txNombre.Text = dt.Rows(0).Item(0)
            txApellidoPat.Text = dt.Rows(0).Item(8)
            txApellidoMat.Text = dt.Rows(0).Item(9)
            txCalle.Text = dt.Rows(0).Item(1)
            txCP.Text = dt.Rows(0).Item(2)
            txTelefonoCte.Text = dt.Rows(0).Item(3)
            txFax.Text = dt.Rows(0).Item(4)
            'dllCiudad.SelectedValue = dt.Rows(0).Item(6)
            dllCiudad.Text = dt.Rows(0).Item(6)
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

            iUbicacion = dt.Rows(0).Item(20)
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
            dllCiudad.Text = sCiudadEstado

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

            Dim dtUbica As DataTable
            Dim iUbicacion As Integer = 0
            Dim iTipoUbicacion As Integer = 0
            Dim sCiudadEstado As String = ""
            Dim sSql As String = ""

            dt = d.LoadCuentaParte3(sCuenta)
            txCalleEnvio.Text = dt.Rows(0).Item(0)
            txCPEnv.Text = dt.Rows(0).Item(1)
            txColoniaEnv.Text = dt.Rows(0).Item(2)
            dllCiudadEnv.SelectedValue = dt.Rows(0).Item(3)
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
        txfechaApertura.Text = String.Empty
        txhoraApertura.Text = String.Empty

        txTelefonoCte.Text = String.Empty
        txFax.Text = String.Empty
        txFunPesos.Text = String.Empty
        txFunDll.Text = String.Empty
        txNombreFunDll.Text = String.Empty
        txCuentaEje.Text = String.Empty
        txFechaCtaEje.Text = String.Empty
        txCalle.Text = String.Empty
        txNumExt.Text = String.Empty
        txNumInt.Text = String.Empty
        txCP.Text = String.Empty
        txComponente.Text = String.Empty
        txColonia.Text = String.Empty
        dllCiudad.SelectedIndex = 0
        dllCiudad.SelectedValue = 0
        dllCiudad.Text = String.Empty

        txRutaUnOrg.Text = String.Empty

        LimpiarDireccionEnvio()
    End Sub

    Private Sub gvOperaciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvOperaciones.CellContentClick

    End Sub
End Class