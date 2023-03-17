Public Class CapturaOpe
    Dim ls_CtaCliente As String
    Dim ls_padre As Integer
    Dim ls_ruta As String


    Private Sub btGestor_Click(sender As Object, e As EventArgs) Handles btGestor.Click
        Dim d As New Datasource
        Dim Registro As Integer

        Registro = d.InsertaRegistroGestor(usuario)

        If Registro > 0 Then
            MsgBox("El gestor ha sido registrado correctamente!")
        End If


        ShowCaptura()

    End Sub

    Private Sub CapturaOpe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowGestor()
    End Sub
    Private Sub txCuenta_Leave(sender As Object, e As EventArgs) Handles txCuenta.Leave
        Dim d As New Datasource
        Dim dtAgencia As New DataTable
        Dim validaLogin As Integer

        If My.Computer.Network.IsAvailable = False Then
            MsgBox("EL EQUIPO NO TIENE CONEXION DE RED")
            Exit Sub
        Else
            dtAgencia = d.ObtenAgencia(txCuenta.Text.Trim()) 'Funcion que obtiene la clave y descripcion de la Agencia

            validaLogin = dtAgencia.Rows.Count

            If validaLogin > 0 Then

                txAgencia.Text = dtAgencia.Rows(0).Item(0).ToString.Trim()

                'Llena campos
                LlenaCampos()
            Else
                MsgBox("EL USUARIO NO ES VALIDO, VERIFIQUE SI ESTA BLOQUEADO O ANULADO O SI EXISTE")
            End If
        End If
    End Sub

    '' Funciones desarrolladas por Beatriz Adriana Palacios Sanchez.
#Region "Funciones GONET Beatriz A Palacios"
    Sub ShowGestor()
        btGestor.Enabled = True
        btGestor.Visible = True
        PnDatosCap.Visible = False
        PnGestor.Visible = True
    End Sub

    Sub ShowCaptura()
        btGestor.Enabled = False
        btGestor.Visible = False
        PnDatosCap.Visible = True
        PnGestor.Visible = False
    End Sub

    Sub LlenaCampos()

        ''Llena datos de Gestor

        GNombreAgencia = Mid(txAgencia.Text, 13)
        txNombreAg.Text = GNombreAgencia

        ls_CtaCliente = Mid(txAgencia.Text, 6, 6)

        Dim d As New Datasource
        Dim dtDatosGestor As New DataTable
        Dim dtPadre As New DataTable
        Dim dtRuta As New DataTable
        Dim dtProductoCont As New DataTable
        Dim dtTipoCuenta As New DataTable
        Dim dtProducto As New DataTable
        Dim dtConceptoDef As New DataTable
        Dim dtOperaciones As New DataTable
        Dim StatusOperacion As Integer

        dtDatosGestor = d.ObtenDatosGestor(ls_CtaCliente)

        lbTelefonoGestor.Text = dtDatosGestor.Rows(0).Item(0)
        lbFaxGestor.Text = dtDatosGestor.Rows(0).Item(1)
        lbCveGestor.Text = dtDatosGestor.Rows(0).Item(2)
        lbNombreGestor.Text = dtDatosGestor.Rows(0).Item(3)
        txCotitular.Text = dtDatosGestor.Rows(0).Item(5)


        ''Llena ruta organizacional de Gestor
        dtPadre = d.ObtenPadreRutaGestor(ls_CtaCliente)

        ls_padre = dtPadre.Rows(0).Item(1)
        ls_ruta = "\" & dtPadre.Rows(0).Item(2) & ls_ruta

        Do While ls_padre > 0
            dtRuta = d.ObtenRutaGestor(ls_padre)

            'Banca
            If dtRuta.Rows(0).Item(4) = 2 Then
                txBanca.Text = dtRuta.Rows(0).Item(1)
            End If

            ls_ruta = "\" & dtRuta.Rows(0).Item(2) & ls_ruta
            lbRuta.Text = ls_ruta
            ls_padre = dtRuta.Rows(0).Item(0)
        Loop

        dtProductoCont = d.ObtenProductoContratado(ls_CtaCliente)
        GProductoContratado = dtProductoCont.Rows(0).Item(0)

        If dtProductoCont.Rows(0).Item(1) = 39 Or dtProductoCont.Rows(0).Item(1) = 4 Then
            MsgBox("LA CUENTA ESTA CANCELADA O INACTIVA")
        End If

        ''Llena tipo de cuenta
        dtTipoCuenta = d.ObtenTipoCuenta(GProductoContratado)
        txTipoCueta.Text = dtTipoCuenta.Rows(0).Item(0)

        ''LLena griProducto
        dtProducto = d.ObtenProducto(ls_CtaCliente)
        gvProducto.DataSource = dtProducto

        ''LLena concepto definido y valor

        dtConceptoDef = d.ObtenConcepto(GProductoContratado)

        lbConcepto.Text = dtConceptoDef.Rows(0).Item(0).trim()
        lbValor.Text = dtConceptoDef.Rows(0).Item(1)

        ''LLena concepto gridOperaciones
        dtOperaciones = d.ObtenOperaciones(ls_CtaCliente)
        gvOperaciones.DataSource = dtOperaciones

        GOperacion = Convert.ToInt32(dtOperaciones.Rows(0).Item(0))

        ''Obtiene Status operacion para validaciones
        StatusOperacion = d.ObtenStatusOperacion(GProductoContratado)

        Select Case StatusOperacion
            Case 0, 1, 250
                btDepositos.Visible = False
            Case 2, 3, 4, 5, 6, 99
                btDepositos.Visible = True
        End Select




    End Sub

    Private Sub btDepositos_Click(sender As Object, e As EventArgs) Handles btDepositos.Click

    End Sub

    Sub Consultar()
        Dim d As New Datasource
        Dim dtTipoOperacion As DataTable

        dtTipoOperacion = d.ObtenTipoOperacion(GOperacion)

        MsgBox(dtTipoOperacion)

    End Sub

#End Region

End Class