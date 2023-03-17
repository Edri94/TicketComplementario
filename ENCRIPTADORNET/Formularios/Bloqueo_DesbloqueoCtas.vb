Public Class Bloqueo_DesbloqueoCtas

    Dim sCta As String
    Dim sProductoContratado As String
    Dim sStatusProducto As String
    Dim sActiva As String = "ACTIVA"
    Dim sBloqueada As String = "BLOQUEADA"
    Dim sCancelada As String = "CANCELADA"
    Dim iCuantosAlertas As Integer = 0
    Dim iCuantosBloqueos As Integer = 0
    Dim mnALERTA() As Long
    Dim mnBLOQUEO() As Long
    Dim mbAlerta As Boolean = False
    Dim mbActiva As Boolean = False
    Dim mbBloqueada As Boolean = False
    Dim mbRestringida As Boolean = False
    Dim mbCarga As Boolean = False
    Dim mnAlertaOBS() As Integer
    Dim mnBloqueoOBS() As Integer
    Dim msMsg1 As String
    Dim msMsg2 As String
    Dim msMsg3 As String
    Dim msMsg4 As String
    Dim msMsg5 As String
    Dim msMsg6 As String
    Dim sProducto As Integer = 0
    Dim PFideicomiso As Integer = 0     'Por default entra como NO Fideicomiso
    Dim bHuboCambios As Boolean

    Private Sub Bloqueo_DesbloqueoCtas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        lbCtaRestringida.Visible = False
        cmdGuardar.Visible = False
        cmdSalir.Visible = True
        LlenaCatalogosAlertas()
        LlenaCatalogosBloqueos()
        LblCtaFideicomiso.Visible = False
        bHuboCambios = False
        Me.Size = New Size(970, 550)
    End Sub

    Private Sub btSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Dim Message As String = "Desea salir sin guardar los cambios?"
        Dim Caption As String = "Salir de modulo bloqueo/desbloqueo de Cuentas"
        Dim Buttons As MessageBoxButtons = MessageBoxButtons.YesNo

        Dim Result As DialogResult

        If bHuboCambios Then
            'Displays the MessageBox
            Result = MessageBox.Show(Message, Caption, Buttons)
            If Result = System.Windows.Forms.DialogResult.Yes Then
                ' Closes the parent form.
                Me.Close()
            End If
        Else
            Me.Close()
        End If

    End Sub

    Private Sub txtCuenta_Leave(sender As Object, e As EventArgs) Handles txtCuenta.Leave
        'revisa si el dato es correcto

        If txtCuenta.Text <> String.Empty Then

            If Len(txtCuenta.Text.ToString.Trim) <> 6 Then
                MsgBox("El formato de la cuenta NO es correcto", MsgBoxStyle.Information)
                txtCuenta.Text = ""
                txtCuenta.Select()
                Exit Sub
            End If

            Try
                If Not cargaAgencia() Then
                    limpiarCampos()
                    txtCuenta.Text = ""
                    txtCuenta.Select()
                    Exit Sub
                End If

                If Not ExisteCuenta() Then
                    limpiarCampos()
                    txtCuenta.Text = ""
                    txtCuenta.Select()
                    Exit Sub
                End If
                limpiarCampos2() '----RACB 10/03/2021
                llenaCampos() '----RACB 10/03/2021
                bHuboCambios = False '----RACB 10/03/2021
                cmdGuardar.Visible = True
                If chkAlerta.Checked = True Then '----RACB 10/03/2021
                    ChkLstAlertas.Enabled = True
                    txtCausaAlerta.Enabled = True
                Else
                    ChkLstAlertas.Enabled = False
                    txtCausaAlerta.Enabled = False
                End If '----RACB 10/03/2021

                Exit Sub

            Catch ex As Exception
                MsgBox("Ocurrio un error en el evento: txCuenta_Leave; " + Err.Description, vbInformation, "Bloqueo y Alertamiento de Cuentas")
                Exit Sub
            End Try

        End If

    End Sub

    Sub llenaCampos()
        Dim d As New DataSourceModCancelaCtas
        Dim ds As New Datasource
        Dim dt As DataTable
        Dim l As New Libreria
        Dim sCta As String = ""
        Dim sStatus As String = ""

        Dim indice As Integer = 0
        Dim sSufijo As String = ""

        sCta = txtCuenta.Text
        dt = ds.ObtieneStatusCuenta(sCta)
        sStatus = dt.Rows(0).Item(2)
        sStatus = Trim(sStatus.ToUpper())
        sProducto = dt.Rows(0).Item(1)
        sSufijo = dt.Rows(0).Item(5)


        'inicializa opciones
        'optActiva.Checked = False
        'optBloqueada.Checked = False
        optRActiva.Checked = False
        optRBloqueada.Checked = False
        chkAlerta.Checked = False
        lbCtaRestringida.Enabled = False

        'Activa las opciones de la pantalla
        If sStatus = sActiva Then                              'CUENTA ACTIVA
            'optActiva.Checked = True
            optRActiva.Checked = True
            mbActiva = True
            mbBloqueada = False '-----RACB 10/03/2021
            'busca si la cuenta esta restringida
            dt = ds.EsCuentaRestringida(sProducto)
            If dt.Rows.Count > 0 Then   'la cuenta es restringida
                lbCtaRestringida.Enabled = True
                MsgBox("La Cuenta esta RESTRINGIDA, no se puede operar Bloqueos", MsgBoxStyle.Exclamation)
                cmdGuardar.Enabled = False
            End If
            'llena alertas
            CargaAlertasDeLacuenta(sProducto)

        ElseIf sStatus = sBloqueada Then                       'CUENTA BLOQUEADA
            'optBloqueada.Checked = True
            optRBloqueada.Checked = True
            mbBloqueada = True
            mbActiva = False '-----RACB 10/03/2021
            'llena bloqueos
            CargaBloqueosDeLacuenta(sProducto)
            'llena alertas
            CargaAlertasDeLacuenta(sProducto)

        ElseIf sStatus = sCancelada Then                       'CUENTA CANCELADA
            lbCtaRestringida.Enabled = True
            MsgBox("La Cuenta esta CANCELADA, no se puede operar Bloqueos", MsgBoxStyle.Exclamation)
            cmdGuardar.Enabled = False
            mbCarga = False
            Exit Sub
        Else
            MsgBox("No se tiene un Estatus de la cuenta favor de verificar con el Administrador", MsgBoxStyle.Exclamation)
            cmdGuardar.Enabled = False
            mbCarga = False
            Exit Sub
        End If

        If mbBloqueada Or mbAlerta Then
            'carga motivo de bloqueo
            dt = ds.BuscaDetalleBloqueo(sProducto, 0)     '0, incluye bloqueos y alertas
            If dt.Rows.Count > 0 Then   'ENCONTRO MOTIVO
                For i = 0 To (dt.Rows.Count - 1)
                    If (dt.Rows(i).Item(1) = 1) Or (dt.Rows(i).Item(1) = 0) Then
                        txtCausaBloqueo.Text = dt.Rows(i).Item(0)
                    End If
                    If (dt.Rows(i).Item(1) = 3) Then
                        txtCausaAlerta.Text = dt.Rows(i).Item(0)
                    End If
                Next
            End If
            If Not mbAlerta Then
                txtCausaAlerta.Text = ""
            End If
            'como esta bloqueada, NO permite captura, hasta que cambie de Estado
            'txtCausaAlerta.Enabled = False
            'txtCausaBloqueo.Enabled = False
        End If


        txtSufijo.Text = sSufijo

        mbCarga = True


        'If bStatus0 Then
        '    optActiva.Text = "Reactivar cuenta"
        '    optBloqueada.Enabled = False
        '    optCancelada.Enabled = True
        'End If

        'If bStatus2 Then
        '    optCancelada.Text = "Cancelar cuenta"
        '    optActiva.Enabled = True
        'End If

        'Revisa si es una Cuenta de fideicomiso
        '1-Fideicomiso; 0-NoEsFideicomiso
        PFideicomiso = d.EsFideicomiso(sCta)
        If PFideicomiso = 1 Then
            LblCtaFideicomiso.Visible = True
        End If

        cmbAgencia.SelectedIndex = 1 '---- RACB 10/03/2021

    End Sub


    Sub CargaAlertasDeLacuenta(sProducto)
        Dim ds As New Datasource
        Dim dt As DataTable
        Dim indice As Integer = 0

        dt = ds.LlenaAlertasCuenta(sProducto)
        If dt.Rows.Count > 0 Then   'la cuenta tiene alertas
            chkAlerta.Checked = True
            mbAlerta = True
            'Activa las opciones de alertas que tenga la cuenta
            For i = 0 To (ChkLstAlertas.Items.Count - 1)
                If Trim(ChkLstAlertas.Items(i).ToString) = Trim(dt.Rows(0).Item(1)) Then
                    ChkLstAlertas.SetItemChecked(i, True)
                End If
            Next

            For i = 0 To (dt.Rows.Count - 1)
                'llena arreglo de Alertas que tiene de la cuenta
                mnALERTA(indice) = Trim(dt.Rows(0).Item(0))
                indice &= 1
            Next
            msMsg6 = Trim(dt.Rows(dt.Rows.Count - 1).Item(1))
        Else
            mbAlerta = False
        End If
    End Sub

    Sub CargaBloqueosDeLacuenta(sProducto)
        Dim ds As New Datasource
        Dim dt As DataTable
        Dim indice As Integer = 0

        dt = ds.LlenaBloqueosCuenta(sProducto)
        If dt.Rows.Count > 0 Then   'la cuenta tiene Bloqueos
            'optBloqueada.Checked = True
            optRBloqueada.Checked = True
            mbBloqueada = True
            'Activa las opciones de Bloqueos que tenga la cuenta
            For i = 0 To (ChkLstBloqueos.Items.Count - 1)
                If Trim(ChkLstBloqueos.Items(i).ToString) = Trim(dt.Rows(0).Item(1)) Then
                    ChkLstBloqueos.SetItemChecked(i, True)
                End If
            Next

            For i = 0 To (dt.Rows.Count - 1)
                'llena arreglo de Bloqueos de la cuenta
                mnBLOQUEO(indice) = Trim(dt.Rows(0).Item(0))
                indice &= 1
            Next

        End If

    End Sub

    Sub limpiarCampos()
        txtCuenta.Text = String.Empty
        txtSufijo.Text = String.Empty
        cmbAgencia.Text = String.Empty
        txtCausaBloqueo.Text = String.Empty
        txtCausaAlerta.Text = String.Empty
        LimpiaCatalogos()
        LlenaCatalogosAlertas()
        LlenaCatalogosBloqueos()

    End Sub
    Sub limpiarCampos2()
        'txtCuenta.Text = String.Empty
        txtSufijo.Text = String.Empty
        cmbAgencia.Text = String.Empty
        txtCausaBloqueo.Text = String.Empty
        txtCausaAlerta.Text = String.Empty
        LimpiaCatalogos()
        LlenaCatalogosAlertas()
        LlenaCatalogosBloqueos()

    End Sub

    Sub LimpiaCatalogos()
        ChkLstAlertas.Items.Clear()
        ChkLstBloqueos.Items.Clear()

    End Sub

    Private Sub optBloqueada_CheckedChanged(sender As Object, e As EventArgs)
        Dim indice As Integer
        Dim lbTieneBloqueos As Boolean = False

        If mbCarga Then
            'If optBloqueada.Checked = False Then
            If optRBloqueada.Checked = False Then

                For Each indice In ChkLstBloqueos.CheckedIndices
                    If ChkLstBloqueos.GetItemChecked(indice) Then
                        lbTieneBloqueos = True
                    End If
                Next
            Else
                txtCausaBloqueo.Enabled = True
            End If
            If lbTieneBloqueos Then
                MsgBox("Es necesario quitar los bloqueos de la Cuenta", MsgBoxStyle.Exclamation)
                'optBloqueada.Checked = True
                optRBloqueada.Checked = True
            Else
                cmdGuardar.Visible = True
                cmdGuardar.Enabled = True
                bHuboCambios = True
            End If
        End If
    End Sub

    Private Sub chkAlerta_CheckedChanged(sender As Object, e As EventArgs) Handles chkAlerta.CheckedChanged
        Dim indice As Integer
        Dim i As Integer
        Dim lbTieneAlertas As Boolean = False

        If mbCarga Then
            'MsgBox("numero de elementos e icuantos")
            'MsgBox(iCuantosAlertas)

            For Each indice In ChkLstAlertas.CheckedIndices
                If ChkLstAlertas.GetItemChecked(indice) Then
                    lbTieneAlertas = True
                End If
            Next
            If chkAlerta.Checked = True Then
                'activa los frames
                txtCausaAlerta.Enabled = True
            Else
                If lbTieneAlertas Then
                    MsgBox("Es necesario quitar las alertas de la Cuenta", MsgBoxStyle.Information)
                    chkAlerta.Checked = True
                    Exit Sub
                End If
                'For Each i In ChkLstAlertas.CheckedIndices
                'ChkLstAlertas.SetItemChecked(i, False)
                'Next
                txtCausaAlerta.Text = ""
                'activa frames
            End If
        End If
        cmdGuardar.Visible = True
        cmdGuardar.Enabled = True
        bHuboCambios = True
        If chkAlerta.Checked = True Then
            ChkLstAlertas.Enabled = True
            txtCausaAlerta.Enabled = True
        Else
            ChkLstAlertas.Enabled = False
            txtCausaAlerta.Enabled = False
        End If
    End Sub

    Private Sub optActiva_CheckedChanged(sender As Object, e As EventArgs)
        Dim indice As Integer
        Dim lbTieneBloqueos As Boolean = False

        If mbCarga Then
            For Each indice In ChkLstBloqueos.CheckedIndices
                If ChkLstBloqueos.Items(indice).checked = True Then
                    lbTieneBloqueos = True
                End If
            Next
            If optRBloqueada.Checked = True Then
                'áctiva frames
            Else
                If lbTieneBloqueos Then
                    MsgBox("Es necesario quitar los bloqueos de la Cuenta", MsgBoxStyle.Information)
                    'optBloqueada.Checked = True
                    optRBloqueada.Checked = True
                    cmdSalir.Select()
                    Exit Sub
                End If
                txtCausaBloqueo.Text = ""
            End If
        End If
        cmdGuardar.Visible = True
        cmdGuardar.Enabled = True
        bHuboCambios = True
    End Sub





#Region "Funciones"
    Function cargaAgencia() As Boolean
        Dim d As New Datasource
        Dim dtAgencia As DataTable

        dtAgencia = d.ObtenAgencia(txtCuenta.Text.Trim()) 'Funcion que obtiene la clave y descripcion de la Agencia
        If dtAgencia.Rows.Count() > 0 Then '---- RACB 10/03/2021
            cmbAgencia.DataSource = Nothing '---- RACB 10/03/2021
            cmbAgencia.Items.Clear() '---- RACB 10/03/2021
            'cmbAgencia.DisplayMember = "NombreAgencia"
            'cmbAgencia.ValueMember = "agencia"
            'cmbAgencia.DataSource = dtAgencia 
            cmbAgencia.Items.Insert(0, "") '---- RACB 10/03/2021
            For Each row As DataRow In dtAgencia.Rows '---- RACB 10/03/2021
                cmbAgencia.Items.Insert(row.Item("agencia"), row.Item("NombreAgencia")) '---- RACB 10/03/2021
            Next '---- RACB 10/03/2021
        Else
            MsgBox("El numero Cuenta no existe en la base de datos", vbInformation, "Cancelación de cuentas")
            Return False
        End If

        Return True

    End Function

    Function ExisteCuenta() As Boolean
        Dim d As New DataSourceModCancelaCtas
        Dim dtBuscaCta As DataTable
        Dim sSufijo As String

        sCta = txtCuenta.Text.ToString().Trim()

        dtBuscaCta = d.buscaCuenta(sCta)

        If dtBuscaCta.Rows.Count > 0 Then
            sProductoContratado = dtBuscaCta.Rows(0).Item(0).ToString().Trim()
            sStatusProducto = dtBuscaCta.Rows(0).Item(1).ToString().Trim()
            sSufijo = dtBuscaCta.Rows(0).Item(2).ToString().Trim()
            txtSufijo.Text = sSufijo
            txtSufijo.Enabled = False
        Else
            MsgBox("No existe la cuenta", vbInformation, "Alerta/Bloques de cuentas")
            Return False
        End If

        Return True

    End Function

    Function LlenaCatalogosAlertas() As Boolean
        Dim d As New DataSourceModBloqCta
        Dim dtBuscaCta As DataTable
        Dim dctas = New Datasource
        Dim dAlertas = New DataTable
        'Dim iCuantos As Integer
        Dim i As Integer = 0

        dtBuscaCta = d.buscaAlerta("3")
        If dtBuscaCta.Rows.Count > 0 Then
            'almacena el numero de alertas obtenido
            iCuantosAlertas = dtBuscaCta.Rows(0).Item(0).ToString().Trim()
            'activa el check de que la cuenta tiene alertas
            chkAlerta.Checked = False
            'recupera las alertas dentro del datasource
            dAlertas = dctas.LoadCatalogoAlertas()

            'carga en el checklistbox la descripción de las alertas
            For i = 0 To (iCuantosAlertas - 1)
                ChkLstAlertas.Items.Add(dAlertas.Rows(i).Item(0))
            Next

            ReDim mnALERTA(iCuantosAlertas)
        Else
            MsgBox("No existen elementos en la tabla de Alertas", vbInformation, "Alertas de cuentas")

            Return False
        End If

        Return True
    End Function

    Function LlenaCatalogosBloqueos() As Boolean
        Dim d As New DataSourceModBloqCta
        Dim dtBuscaCta As DataTable
        Dim dctas = New Datasource
        Dim dbloqueos = New DataTable
        'Dim iCuantos As Integer
        Dim i As Integer = 0

        dtBuscaCta = d.buscaAlerta("1")
        If dtBuscaCta.Rows.Count > 0 Then
            iCuantosBloqueos = dtBuscaCta.Rows(0).Item(0).ToString().Trim()
            'activa el check de que la cuenta tiene alertas
            'optBloqueada.Checked = False
            optRBloqueada.Checked = False

            'recupera los bloqueos dentro del datasource
            dbloqueos = dctas.LoadCatalogoBloqueos()

            'carga en el checklistbox la descripción de las alertas
            For i = 0 To (iCuantosBloqueos - 1)
                ChkLstBloqueos.Items.Add(dbloqueos.Rows(i).Item(0))
            Next
            ReDim mnBLOQUEO(iCuantosBloqueos)

        Else
            MsgBox("No existen elementos en la tabla de Alertas", vbInformation, "Alertas de cuentas")
            Return False
        End If

        Return True
    End Function

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        If cmbAgencia.SelectedIndex > 0 Then '---- RACB 10/03/2021
            Dim indice As Integer
            Dim indDetAlerta As Integer
            Dim bComentario As Boolean
            Dim iChecks As Integer
            Dim n As Integer
            Dim d As New Datasource
            Dim c As New DataSourceModCancelaCtas
            Dim dbloqueos As New DataTable
            Dim idBloqueo As Integer
            Dim dalertas As New DataTable
            Dim dRegistro As Integer
            Dim lsHora As String = ""

            If Not DatosCompletos() Then
                Exit Sub
            End If

            Try
                'cuenta Activa inicialmente
                If mbActiva Then
                    Dim lsObservacion As String = ""
                    If chkAlerta.Checked = True Then
                        If mbAlerta Then
                            'dalertas = d.EliminaAlertas(sProducto, 3)
                            dRegistro = d.EliminaAlertas(sProducto, 3)
                        End If
                        For Each indice In ChkLstAlertas.CheckedIndices
                            lsObservacion = ""
                            lsHora = "15:35"
                            dbloqueos = d.ObtieneBloqueoObservacionID(ChkLstAlertas.Items(indice))
                            idBloqueo = dbloqueos.Rows(0).Item(0)
                            'lsObservacion = ChkLstAlertas.CheckedIndices(indice)
                            dRegistro = d.InsertaAlertas(sProducto, idBloqueo, Format(Now(), "yyyy-MM-dd"), 520, Format(Now(), "HH:mm"))
                        Next
                        If Not Causas(3, txtCausaAlerta.Text) Then
                            MsgBox("No se pudo insertar la causa de alerta", MsgBoxStyle.Exclamation, "Aviso")
                        End If
                    End If
                    If optRBloqueada.Checked = True Then
                        dRegistro = 0
                        For Each i In ChkLstBloqueos.CheckedIndices
                            dbloqueos = d.ObtieneBloqueoObservacionID(ChkLstBloqueos.Items(i))
                            idBloqueo = dbloqueos.Rows(0).Item(0)
                            dRegistro = d.InsertaBloqueos(sProducto, idBloqueo, Format(Now(), "yyyy-MM-dd"), 520, Format(Now(), "HH:mm"))
                        Next
                        'actualiza estatus de la cuenta
                        dRegistro = d.UpdateCuenta(sProducto, 4)
                        'ya no se actualiza el registro, se tomara el estatus de la cuenta eje en Producto_Contratado
                        'If optBloqueada.Checked = True And PFideicomiso = 1 Then
                        '    'actualiza estatus en tabla fideicomiso
                        '    dRegistro = d.UpdateCuentaFideicomiso(sProducto)
                        'End If
                        'inserta en evento_producto
                        dRegistro = c.InsEventoProducto(sProducto, "520", "Mantenimiento Cuenta Bloqueada", 8004)
                        If Not Causas(1, txtCausaBloqueo.Text) Then
                            MsgBox("No se pudo insertar la causa de bloqueo", MsgBoxStyle.Exclamation, "Aviso")
                        End If
                    End If
                End If

                'Cuenta Bloqueada inicialmente
                If mbBloqueada Then
                    'si se activo la cuenta (se desbloqueo la cuenta)
                    If optRActiva.Checked = True Then
                        If BorraBloqueos() Then
                            dRegistro = d.UpdateCuenta(sProducto, 1)
                            If dRegistro <= 0 Then
                                MsgBox("No se pudo Activar la cuenta", MsgBoxStyle.Exclamation, "Aviso")
                            End If
                            dRegistro = d.EliminaBloqueoDetalle(sProducto, 1)    '1 elimina registros de Bloqueos
                            If dRegistro <= 0 Then
                                MsgBox("No se pudo eliminar los detalles de bloqueo de la cuenta", MsgBoxStyle.Exclamation, "Aviso")
                            End If
                        End If
                    End If

                    'si el bloqueo permanece o cambio el tipo de bloqueo
                    If optRBloqueada.Checked = True Then
                        If BorraBloqueos() Then
                            'inserta los nuevos bloqueos de la cuenta
                            dRegistro = 0
                            For Each i In ChkLstBloqueos.CheckedIndices
                                'tiene que obtener el id de bloqueo_observacion para pasarlo a la siguiente como.
                                dbloqueos = d.ObtieneBloqueoObservacionID(ChkLstBloqueos.Items(i))
                                'revisa si ya tiene el id de bloqueo registrado
                                idBloqueo = dbloqueos.Rows(0).Item(0)
                                'si no lo tiene,    'registra el nuevo bloqueo
                                dRegistro = d.InsertaBloqueos(sProducto, idBloqueo, Format(Now(), "yyyy-MM-dd"), 520, Format(Now(), "HH:mm"))
                            Next
                            If Not Causas(1, txtCausaBloqueo.Text) Then
                                MsgBox("No se pudo insertar la causa de bloqueo", MsgBoxStyle.Exclamation, "Aviso")
                            End If
                        End If
                    End If

                    'Si la cuenta se puso en alerta
                    If chkAlerta.Checked = True Then
                        Dim lsObservacion As String = ""
                        'si ya tenía alerta, y cambio el tipo de alerta
                        If mbAlerta Then
                            'dalertas = d.EliminaAlertas(sProducto, 3)
                            dRegistro = d.EliminaAlertas(sProducto, 3)
                            For Each indice In ChkLstAlertas.CheckedIndices
                                lsObservacion = ""
                                lsHora = "15:35"
                                dbloqueos = d.ObtieneBloqueoObservacionID(ChkLstAlertas.Items(indice))
                                idBloqueo = dbloqueos.Rows(0).Item(0)
                                dRegistro = d.InsertaAlertas(sProducto, idBloqueo, Format(Now(), "yyyy-MM-dd"), 520, Format(Now(), "HH:mm"))
                            Next
                        Else   'sino tenia alertas, inserta las seleccionadas
                            For Each indice In ChkLstAlertas.CheckedIndices
                                lsObservacion = ""
                                lsHora = "15:35"
                                'tiene que obtener el id de bloqueo_observacion para pasarlo a la siguiente como.
                                dbloqueos = d.ObtieneBloqueoObservacionID(ChkLstAlertas.Items(indice))
                                'lsObservacion = ChkLstAlertas.CheckedIndices(indice)
                                'revisa si ya tiene el id de bloqueo registrado
                                idBloqueo = dbloqueos.Rows(0).Item(0)
                                dRegistro = d.InsertaAlertas(sProducto, idBloqueo, Format(Now(), "yyyy-MM-dd"), 520, Format(Now(), "HH:mm"))
                            Next
                        End If
                        If Not Causas(3, txtCausaAlerta.Text) Then
                            MsgBox("No se pudo insertar la causa de bloqueo", MsgBoxStyle.Exclamation, "Aviso")
                        End If
                    End If

                End If

                'Si la cuenta estaba en alerta y se quito esta
                If mbAlerta And chkAlerta.Checked = False Then
                    dRegistro = d.EliminaAlertas(sProducto, 3)

                    dalertas = d.BuscaDetalleBloqueo(sProducto, 3)    '3 considera solo alertas
                    If dalertas.Rows.Count > 0 Then
                        dRegistro = d.EliminaBloqueoDetalle(sProducto, 3)    '3 elimina registros de alertas
                        If dRegistro <= 0 Then
                            MsgBox("No se pudo eliminar los detalles de bloqueo de la cuenta", MsgBoxStyle.Exclamation, "Aviso")
                        End If
                    End If

                End If

                MsgBox("El estado de la cuenta ha cambiado Exitosamente", MsgBoxStyle.Information, "Bloqueo/Alertas de Cuentas")

                txtCausaAlerta.Enabled = False
                txtCausaBloqueo.Enabled = False
                limpiarCampos2() '--- RACB10/03/2021
                txtCuenta.Text = "" '--- RACB10/03/2021
                bHuboCambios = False '--- RACB10/03/2021

                Exit Sub

            Catch ex As Exception
                MsgBox("ocurrio un error:" & Err.Number & ": " & Err.Description)
                Exit Sub
            End Try
        Else
            MsgBox("Mantén seleccionada una agencia valida.") '---- RACB 10/03/2021
        End If

    End Sub

    Private Function BorraBloqueos() As Boolean
        Dim d As New Datasource
        Dim dtable As New DataTable
        Dim iRegistro As Integer

        BorraBloqueos = True
        'guarda bloqueos en el historico, antes de borrar
        iRegistro = d.InsertaBloqueosHistorico(sProducto, Format(Now(), "yyyy-MM-dd"), Format(Now(), "HH:mm"))
        'si nu hubiera registros, mandar aviso y continuar.
        If iRegistro <= 0 Then
            MsgBox("No se pudieron insertar bloqueos en el Historico")
            'BorraBloqueos = False
        End If

        'elimina bloqueos el status=1
        iRegistro = d.EliminaAlertas(sProducto, 1)
        '////////////////////////
        'cambiar validacion, ya que no regresa valor a la variable de tabla
        '////////////////////////
        If iRegistro <= 0 Then
            MsgBox("No se pudieron eliminar los bloqueos")
            'BorraBloqueos = False
        End If

    End Function

    Private Function DatosCompletos() As Boolean
        Dim lbTieneBloqueos As Boolean
        Dim lbTieneAlertas As Boolean
        Dim indice As Integer
        Dim lsMensaje As String

        DatosCompletos = False
        lbTieneBloqueos = False
        lbTieneAlertas = False

        If optRActiva.Checked = False And optRBloqueada.Checked = False And chkAlerta.Checked = False Then
            MsgBox("Debe elegir un Estatus para la Cuenta", MsgBoxStyle.Information)
            Exit Function
        End If

        'si se eligio la opción de la cuenta bloqueada
        'se revisa que exista algun estado de bloqueo
        If optRBloqueada.Checked = True Then
            For Each indice In ChkLstBloqueos.CheckedIndices
                'ChkLstBloqueos.Items(indice).checked    - trae la descripción del item seleccionado
                'If ChkLstBloqueos.Items(indice).checked = True Then
                'lbTieneBloqueos = True
                'End If
                'GetItemChecked para saber si eta seleccionado el item
                If ChkLstBloqueos.GetItemChecked(indice) Then
                    lbTieneBloqueos = True
                End If
            Next
            If lbTieneBloqueos = False Then
                MsgBox("Es necesario seleccionar al menos un tipo de Bloqueo", MsgBoxStyle.Exclamation, "Dato Faltante")
                'Me.Cursor = Cursors.Default
                Exit Function
            End If
            'Si no se capturo la causa, se solicita
            If Trim(txtCausaBloqueo.Text) = "" Then
                MsgBox("Es necesario la causa de Bloqueo", MsgBoxStyle.Exclamation, "Aviso")
                txtCausaBloqueo.Select()
                Exit Function
            End If
        End If

        'Si se eligio la opcion de cuenta en Alerta
        If chkAlerta.Checked = True Then
            For Each indice In ChkLstAlertas.CheckedIndices
                If ChkLstAlertas.GetItemChecked(indice) Then
                    lbTieneAlertas = True
                End If
            Next
            If lbTieneAlertas = False Then
                MsgBox("Es necesario seleccionar al menos un tipo de Alerta", MsgBoxStyle.Exclamation, "Dato Faltante")
                Cursor = System.Windows.Forms.Cursors.Default
                Exit Function
            End If
            If Trim(txtCausaAlerta.Text) = "" Then
                MsgBox("Es necesario la causa de Alerta", MsgBoxStyle.Exclamation, "Aviso")
                txtCausaAlerta.Select()
                Exit Function
            End If
        End If

        'Si se eligio la opcion cuenta Activa
        'Checa que no tenga ningun bloqueo
        If optRActiva.Checked = True And lbTieneBloqueos Then
            Dim d As New Datasource
            Dim dbloqueos = New DataTable
            dbloqueos = d.LlenaBloqueosCuenta(sProducto)
            If dbloqueos.Rows.Count > 0 Then
                lsMensaje = ""
                For i = 0 To dbloqueos.Rows.Count - 1
                    lsMensaje = dbloqueos.Rows(i).Item(1).ToString
                Next
                MsgBox("La cuenta se encuentra Bloqueada y no se puede reactivar debido a:" & vbCrLf & lsMensaje & " Deshabilite los bloqueos que existen sobre la cuenta para continuar.", MsgBoxStyle.Information, "Aviso")
            End If
        End If

        DatosCompletos = True

    End Function

    Private Function Causas(ByVal status As Integer, ByVal Texto As String) As Boolean
        Dim lnExisteCausa As Integer
        Dim ssql As String
        Dim d As New Datasource
        Dim dtable As New DataTable
        Dim iRegistro As Integer

        Causas = False
        ssql = "select count(*) from DETALLE_STATUS where producto_contratado = " & sProducto
        ssql &= " and status_bloqueo = " & status
        dtable = d.Consulta(ssql, "queryCausa")

        If dtable.Rows.Count > 0 Then
            lnExisteCausa = dtable.Rows(0).Item(0)
        End If
        If lnExisteCausa > 0 Then
            ssql = "Update TICKET..DETALLE_STATUS set explicacion = '" & Texto & "' "
            ssql &= " where producto_contratado = " & sProducto
            ssql &= " and status_bloqueo = " & status
        Else
            ssql = "Insert into TICKET..DETALLE_STATUS "
            ssql &= " ( producto_contratado, explicacion, status_bloqueo ) "
            ssql &= " values ( " & sProducto & ", '" & Texto & "', " & status & " )"
        End If
        iRegistro = d.insertar(ssql)
        If iRegistro <= 0 Then
            MsgBox("Ha ocurrido un error al guardar la causa del bloqueo.", MsgBoxStyle.Critical, "Aviso")
            Exit Function
        End If
        Causas = True
    End Function

    Private Sub optRActiva_CheckedChanged(sender As Object, e As EventArgs) Handles optRActiva.CheckedChanged
        Dim indice As Integer
        Dim lbTieneBloqueos As Boolean = False

        If mbCarga Then
            For Each indice In ChkLstBloqueos.CheckedIndices
                If ChkLstBloqueos.GetItemChecked(indice) Then
                    lbTieneBloqueos = True
                End If
                'If ChkLstBloqueos.Items(indice).checked = True Then
                '    lbTieneBloqueos = True
                'End If
            Next
            If optRBloqueada.Checked = True Then
                'áctiva frames
                txtCausaBloqueo.Enabled = True
            Else
                If lbTieneBloqueos Then
                    MsgBox("Es necesario quitar los bloqueos de la Cuenta", MsgBoxStyle.Information)
                    'optBloqueada.Checked = True
                    optRBloqueada.Checked = True
                    cmdSalir.Select()
                    Exit Sub
                End If
                txtCausaBloqueo.Text = ""
            End If
        End If
        cmdGuardar.Visible = True
        cmdGuardar.Enabled = True
        If optRActiva.Checked = True Then
            ChkLstBloqueos.Enabled = False
            txtCausaBloqueo.Enabled = False
        End If
    End Sub

    Private Sub optRBloqueada_CheckedChanged(sender As Object, e As EventArgs) Handles optRBloqueada.CheckedChanged
        Dim indice As Integer
        Dim lbTieneBloqueos As Boolean = False

        If mbCarga Then
            If optRBloqueada.Checked = False Then

                For Each indice In ChkLstBloqueos.CheckedIndices
                    If ChkLstBloqueos.GetItemChecked(indice) Then
                        lbTieneBloqueos = True
                    End If
                Next
            Else
                txtCausaBloqueo.Enabled = True
            End If
            If lbTieneBloqueos Then
                MsgBox("Es necesario quitar los bloqueos de la Cuenta", MsgBoxStyle.Exclamation)
                'optBloqueada.Checked = True
                optRBloqueada.Checked = True
            Else
                cmdGuardar.Visible = True
                cmdGuardar.Enabled = True
            End If
        End If
        If optRBloqueada.Checked = True Then
            ChkLstBloqueos.Enabled = True
            txtCausaBloqueo.Enabled = True
        End If
    End Sub

    Private Sub ChkLstBloqueos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ChkLstBloqueos.SelectedIndexChanged
        bHuboCambios = True '--- RACB10/03/2021
    End Sub

    Private Sub txtCausaBloqueo_TextChanged(sender As Object, e As EventArgs) Handles txtCausaBloqueo.TextChanged
        bHuboCambios = True '--- RACB10/03/2021
    End Sub
    '--- RACB10/03/2021
    Private Sub txtCuenta_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtCuenta.KeyPress
        If AscW(e.KeyChar) = CInt(Keys.Enter) Then
            'revisa si el dato es correcto

            If txtCuenta.Text <> String.Empty Then

                If Len(txtCuenta.Text.ToString.Trim) <> 6 Then
                    MsgBox("El formato de la cuenta NO es correcto", MsgBoxStyle.Information)
                    txtCuenta.Text = ""
                    txtCuenta.Select()
                    Exit Sub
                End If

                Try
                    If Not cargaAgencia() Then
                        limpiarCampos()
                        txtCuenta.Text = ""
                        txtCuenta.Select()
                        Exit Sub
                    End If

                    If Not ExisteCuenta() Then
                        limpiarCampos()
                        txtCuenta.Text = ""
                        txtCuenta.Select()
                        Exit Sub
                    End If
                    limpiarCampos2() '----RACB 10/03/2021
                    llenaCampos() '----RACB 10/03/2021
                    bHuboCambios = False '----RACB 10/03/2021
                    cmdGuardar.Visible = True
                    If chkAlerta.Checked = True Then '----RACB 10/03/2021
                        ChkLstAlertas.Enabled = True
                        txtCausaAlerta.Enabled = True
                    Else
                        ChkLstAlertas.Enabled = False
                        txtCausaAlerta.Enabled = False
                    End If '----RACB 10/03/2021

                    Exit Sub

                Catch ex As Exception
                    MsgBox("Ocurrio un error en el evento: txCuenta_KeyPress: " + Err.Description, vbInformation, "Bloqueo y Alertamiento de Cuentas")
                    Exit Sub
                End Try

            End If
        End If
    End Sub


#End Region


End Class