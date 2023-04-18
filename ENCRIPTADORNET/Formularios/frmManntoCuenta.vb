Imports System.ComponentModel
Public Class frmManntoCuenta
    Private GnTipoCuenta As Long
    Private GnProductoContratado As Long
    Private GsCuenta As String
    Private bCargaDatosenCurso As Boolean

    Private msnombre As String
    Private msUbicacionEnvio As String
    Private msUbicacion As String
    Private mbMoral As Boolean
    Private mbDirecEnvio As Boolean
    Private mnUbicacion As Long
    Private mnUbicaEnvio As Long
    Private mnTipoCliente As Long
    Private mnBanca As Long
    Private mnOperacion As Long
    Private mnProdCon As Long
    Private mnStatusCta As Long
    Private mnStatusGlobalCta As Long
    Private mnAgencia As Integer
    Private mnTipoCta As Byte
    Private msFechaCtaEje As String
    Private msFechaPesos As String
    Private lnUbicacion As Long
    Private lnUbicacionEnvio As Long
    Private mnTipoEmpresa As Long
    Private mnTipoSociedad As Long
    Private papelera As String
    Private CuentaOriginal As String
    Private ModificacionCTA As Boolean
    Private CargaValores As Boolean
    Private msCuenta As String
    Private strArregloMantenimiento(2) As String
    Private Fideicomiso As Integer
    Private FecAlta As String

    'OGJ 2014ago26 - variables para el control de detalle mantenimiento cuenta
    'variable direccion residencia
    Private intMnntoDR_CA As Boolean
    Private intMnntoDR_NE As Boolean
    Private intMnntoDR_NI As Boolean
    Private intMnntoDR_CO As Boolean
    Private intMnntoDR_CL As Boolean
    Private intMnntoDR_DM As Boolean
    Private intMnntoDR_CE As Boolean
    Private intMnntoDR_CP As Boolean
    'variable direccion envio
    Private intMnntoDE_CA As Boolean
    Private intMnntoDE_NE As Boolean
    Private intMnntoDE_NI As Boolean
    Private intMnntoDE_CO As Boolean
    Private intMnntoDE_CL As Boolean
    Private intMnntoDE_DM As Boolean
    Private intMnntoDE_CE As Boolean
    Private intMnntoDE_CP As Boolean
    'variables nombre cliente
    Private intMnntoNC_N As Boolean
    Private intMnntoNC_AP As Boolean
    Private intMnntoNC_AM As Boolean
    'variable Gestor Pesos, Telefono, Fax
    Private intMnntoGestor As Boolean
    Private intMnntoTelef As Boolean
    Private intMnntoFax As Boolean
    'variable Cuenta Eje Pesos y Fecha Cuenta Eje Pesos
    Private intCuentaEje As Boolean
    Private intFechaCtaEje As Boolean

    Dim lsFechaOriginal As String

    Private GnProdContMnnto As Long
    Private GnIndMnnto As Boolean

    Private gAgencia As Integer
    Private gn_Operacion_Definida As Integer
    Public selec As Boolean



    Private Sub frmManntoCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        HabilitaControles(0)
        AcomodaCombos()
        'Inicializa la variable de control de cambio de cta pesos
        ModificacionCTA = False
        'OGJ 2014ago26 - Inicializa variables para el control de mantenimientos con detalle
        Inicializa_VarMnnto()
        optCuenta.Checked = True
        Me.Width = 1160
        Me.Height = 624
        Me.CenterToScreen()
        cmdGuardar.Enabled = False
        txtCuenta.Focus()
        optCuenta_Click(Nothing, Nothing)
        gs_FechaHoy = Format(Now(), "dd-MM-yyyy")

    End Sub

    Private Sub HabilitaControles(ByVal lnIndicador As Integer)
        Dim lnCuentaObjetos As Integer, i As Integer
        lnCuentaObjetos = Me.Controls.Count
        For i = 0 To lnCuentaObjetos - 1
            If lnIndicador = 0 Then
                Me.Controls(i).Enabled = False
            Else
                Me.Controls(i).Enabled = True
            End If
        Next
        Me.pnlManttoPend.Enabled = True
        'Me.GroupBox3.Enabled = True
        Me.cmdCerrar.Enabled = True
        Me.optCuenta.Enabled = True
        Me.optNombre.Enabled = True
    End Sub

    'OGJ 2014ago26 manejo de mantenimiento de cuenta
    Private Sub Inicializa_VarMnnto()
        'variable direccion envio
        intMnntoDR_CA = False
        intMnntoDR_NE = False
        intMnntoDR_NI = False
        intMnntoDR_CO = False
        intMnntoDR_CL = False
        intMnntoDR_DM = False
        intMnntoDR_CE = False
        intMnntoDR_CP = False
        'variable direccion envio
        intMnntoDE_CA = False
        intMnntoDE_NE = False
        intMnntoDE_NI = False
        intMnntoDE_CO = False
        intMnntoDE_CL = False
        intMnntoDE_DM = False
        intMnntoDE_CE = False
        intMnntoDE_CP = False
        'variables nombre cliente
        intMnntoNC_N = False
        intMnntoNC_AP = False
        intMnntoNC_AM = False
        'variable de gestor pesos, telefono, fax
        intMnntoGestor = False
        intMnntoTelef = False
        intMnntoFax = False
        'variable de cuenta eje pesos y fecha cuenta eje
        intCuentaEje = False
        intFechaCtaEje = False

    End Sub

    Private Sub AcomodaCombos()
        pgFillCombo(cmbtipoempresa, 1)
        pgFillCombo(cmbtiposociedad, 2)
    End Sub

    '--------------------------------------------------------------------------------------
    'Llenamos el combo enviado con el contenido de la tabla especifícada
    'Originalmente se encontraba en modComunes
    'Agregada e identada por CEB 20-02-2002
    '--------------------------------------------------------------------------------------
    Public Sub pgFillCombo(cmbControl As ComboBox, ByVal iTabla As Integer)
        Dim sDesc As String
        Dim sCodi As String
        Dim d As New DataSourceMannto
        Dim dtDatos As DataTable
        Dim renglones As Integer
        Dim renglon As Integer
        Dim lenDesc As Integer

        'Primero borramos cualquier posible contenido del combo
        cmbControl.Items.Clear()

        renglones = 0
        renglon = 0
        lenDesc = 0
        dtDatos = Nothing
        dtDatos = d.LLenacombos(iTabla)

        renglones = dtDatos.Rows.Count
        If (dtDatos.Rows.Count > 0) Then
            For Each rows As DataRow In dtDatos.Rows
                sDesc = dtDatos.Rows(renglon).Item(0)
                sCodi = dtDatos.Rows(renglon).Item(0)
                lenDesc = Len(sDesc.Trim)
                sDesc = sDesc + sCodi
                cmbControl.Items.Add(sDesc)
                renglon = renglon + 1
            Next
        Else
            MsgBox("NO se obtuvieron valores en la consulta.", vbInformation, "LLenaCombos")
        End If

    End Sub

    Private Sub LimpiaCampos()

        GnTipoCuenta = 0
        GnProductoContratado = 0
        GsCuenta = ""
        cmbAgencia.Items.Clear()
        txtNombre.Text = ""
        txtNombreCte.Text = ""
        txtAPaterno.Text = ""
        txtAMaterno.Text = ""
        txtTelefono.Text = ""
        txtRFC.Text = ""
        txtFax.Text = ""
        txtFuncPesos.Text = ""
        txtNumFuncionario.Text = ""
        lblFunc.Text = ""
        lblUsuario.Text = ""
        lblRuta.Text = ""
        lblMancomunada.Visible = False
        lblFechaAlta.Text = ""
        lblFechaCaptura.Text = ""
        lblHoraCaptura.Text = ""
        lblFechaCancela.Text = ""
        lblTipoCuenta.Text = ""
        txtcuenta_pesos.Text = ""
        txtFechaCtaEje.Text = ""
        lblTipoCliente.Visible = False
        CmbTipoCliente.Items.Clear()
        lblLinea.Text = ""
        lblLinea.Enabled = False
        lblLinea.Visible = True
        lblGrabadora.Text = ""
        lblGrabadora.Enabled = False
        lblGrabadora.Visible = True
        lblCtaHou.Text = ""
        lblCtaHou.Enabled = True
        lblCtaHou.Visible = True
        lblFechaBanklink.Text = ""
        chkPersonaMoral.Checked = 0
        chkFideicomiso.Checked = 0
        chkFideicomiso.Enabled = False
        chkChequera.Checked = 0
        cmdBeneficiarios.Enabled = False
        cmdCotitulares.Enabled = False
        cmdAutorizado.Enabled = False
        'Direccion
        txtCalle.Text = ""
        txtNoExt.Text = ""
        txtNoInt.Text = ""
        txtComponente.Text = ""
        txtColonia.Text = ""
        cmbUbicacion.Items.Clear()
        txtCP.Text = ""
        txtDelMunicipio.Text = ""
        'Direccion Envío
        txtCalleEnvio.Text = ""
        txtNoExtEnvio.Text = ""
        txtNoIntEnvio.Text = ""
        txtComponenteEnvio.Text = ""
        txtColoniaEnvio.Text = ""
        cmbUbicacionEnvio.Items.Clear()
        txtDelMunicipioE.Text = ""
        txtCPEnvio.Text = ""
        lblFechaCancela.Visible = False
        lblT1.Visible = False
        'lblT2.Visible = False
        cmdCotitulares.Enabled = False
        cmdBeneficiarios.Enabled = False
        cmdAutorizado.Enabled = False
        pnlStatusCta.Visible = False
        lblAPaterno.Text = "Apellido Paterno"
        lblAMaterno.Text = "ApellidoMaterno"
        lblNombre.Text = "Nombre"
        'txtNombreCte.Top = 1035
        'txtAPaterno.Top = 255
        'txtAMaterno.Top = 645
        txtNombreCte.Visible = True
        txtAPaterno.Visible = True
        txtAMaterno.Visible = True
        cmbConfirmaRecepcion.Items.Clear()
        cmbConfirmaRecepcion.Enabled = False
        pnlManttoPend.Tag = ""
        pnlManttoPend.Visible = True
    End Sub

    Private Sub optCuenta_CheckedChanged(sender As Object, e As EventArgs) Handles optCuenta.CheckedChanged
        If optCuenta.Checked = True Then
            txtCuenta.Enabled = True
            txtNombre.Enabled = False
        End If
    End Sub

    Private Sub optCuenta_Click(sender As Object, e As EventArgs) Handles optCuenta.Click
        If optCuenta.Checked = True Then
            txtNombre.Text = ""
            txtCuenta.Text = ""
            txtNombre.Enabled = False
            txtCuenta.Enabled = True
            txtRFC.Enabled = True
            LimpiaCampos()
            txtCuenta.Focus()
            cmbAgencia.Items.Clear()
            lblAPaterno.Visible = True
            lblAMaterno.Visible = True
            lblAyuda.Visible = False
            cmbtipoempresa.Visible = False
            cmbtiposociedad.Visible = False
        End If
    End Sub

    Private Sub optNombre_CheckedChanged(sender As Object, e As EventArgs) Handles optNombre.CheckedChanged
        Exit Sub
        'If optNombre.Checked = True Then
        '    txtNombre.Text = ""
        '    txtCuenta.Text = ""
        '    txtNombre.Enabled = True
        '    txtCuenta.Enabled = False
        '    LimpiaCampos()
        '    txtNombre.Focus()
        '    cmbAgencia.Items.Clear()
        '    cmbtipoempresa.Visible = False
        '    cmbtiposociedad.Visible = False
        '    lblAPaterno.Visible = True
        '    lblAMaterno.Visible = True
        '    lblAyuda.Visible = False
        'End If
    End Sub

    Private Sub txtCuenta_TextChanged(sender As Object, e As EventArgs) Handles txtCuenta.TextChanged
        Exit Sub
    End Sub

    Private Sub txtCuenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCuenta.KeyPress
        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            'If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True
            txtCuenta_LostFocus(sender, e)
        End If
    End Sub

    Private Sub txtCuenta_LostFocus(sender As Object, e As EventArgs) Handles txtCuenta.LostFocus
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        If txtCuenta.Text <> "" Then
            If EncontroMantenimientos() Then
                '1 - Habilita controles
                HabilitaControles(1)
                LimpiaCampos()
                txtNombre.Text = ""
                If txtCuenta.Text <> "" Then LlenaComboAgencias()
                cmbtipoempresa.Visible = False
                cmbtiposociedad.Visible = False
                lblAyuda.Visible = False
                LimpiarTag()
            Else
                MsgBox("No es posible registrar el mantenimiento en este momento" & vbCrLf & "Intente más tarde", vbOKOnly + vbInformation, "Cuenta con mantenimientos pendientes.")
                LimpiaCampos()
                LimpiarTag()
                txtCuenta.Text = ""
                txtCuenta.Focus()
            End If

        End If

    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Function EncontroMantenimientos() As Boolean
        Dim d As New Datasource
        Dim dtDatos As DataTable
        Dim lnAgenProdContra As Long

        lnAgenProdContra = 1

        dtDatos = d.ObtenProductoContratado(txtCuenta.Text)

        If dtDatos.Rows.Count > 0 Then
            lnAgenProdContra = dtDatos.Rows(0).Item(0)
            'Else
            '    MsgBox("NO existe la cuenta, revise e intente nuevamente", vbInformation, "Consulta Cuenta")

        End If

        'OGJ 2014ago26 asigna producto contratado global, despues de salir de esta forma, se debe inicializar a ceros
        GnProdContMnnto = lnAgenProdContra

        dtDatos = Nothing
        dtDatos = d.EncuentraMannto(lnAgenProdContra)

        lnAgenProdContra = dtDatos.Rows(0).Item(0)

        If lnAgenProdContra = 0 Then
            EncontroMantenimientos = True
        Else
            EncontroMantenimientos = False
        End If

    End Function

    Private Sub LimpiarTag()

        txtcuenta_pesos.Tag = ""
        txtFechaCtaEje.Tag = ""
        txtCalle.Tag = ""
        txtNoExt.Tag = ""
        txtNoInt.Tag = ""
        txtComponente.Tag = ""
        txtColonia.Tag = ""
        txtDelMunicipio.Tag = ""
        cmbUbicacion.Tag = ""
        txtCP.Tag = ""
        txtCalleEnvio.Tag = ""
        txtNoExtEnvio.Tag = ""
        txtNoIntEnvio.Tag = ""
        txtComponenteEnvio.Tag = ""
        txtColoniaEnvio.Tag = ""
        txtDelMunicipioE.Tag = ""
        cmbUbicacionEnvio.Tag = ""
        txtCPEnvio.Tag = ""
        pnlManttoPend.Tag = ""
        txtFax.Tag = ""
        txtTelefono.Tag = ""
        txtNombreCte.Tag = ""
        txtAPaterno.Tag = ""
        txtAMaterno.Tag = ""
        txtRFC.Tag = ""
        txtFuncPesos.Tag = ""

    End Sub

    Private Sub LlenaComboAgencias()
        Dim d As New Datasource
        Dim dtDatos As DataTable
        Dim renglon As Integer


        If cmbAgencia.Items.Count > 0 Then Exit Sub
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        'BAGO-EDS-10/MZO/06. Uso de IsNull en concatenación de cadenas
        If optCuenta.Checked = True Then
            dtDatos = d.DatosAgencia(2, txtCuenta.Text.Trim)
        Else
            dtDatos = d.DatosAgencia(1, txtNombre.Text.Trim)
        End If

        renglon = 0
        If dtDatos.Rows.Count > 0 Then
            For Each rows As DataRow In dtDatos.Rows
                cmbAgencia.Items.Add(dtDatos.Rows(renglon).Item(0))
                'cmbAgencia.Items.IndexOf = dtDatos.Rows(renglon).Item(1)
                renglon = renglon + 1
            Next
        Else
            MsgBox("No se encontraron clientes que concuerden con la información proporcionada.", vbInformation, "Consulta")
        End If

        'Busca las cuentas similares a los datos proporcionados
        Cursor = System.Windows.Forms.Cursors.Default

        'No hay datos en la lista
        If cmbAgencia.Items.Count = 0 Then
            'MsgBox("No se encontraron clientes que concuerden con la información proporcionada.", vbInformation, "Consulta")
            If optCuenta.Checked = True Then
                LimpiaCampos()
                txtNombre.Enabled = False
                txtCuenta.Text = ""
                txtCuenta.Focus()
            Else
                txtCuenta.Enabled = False
                txtNombre.Text = ""
                txtNombre.Focus()
            End If
            'Solo hay un dato en la lista
        ElseIf cmbAgencia.Items.Count = 1 Then
            cmbAgencia.SelectedIndex = 0
            'Hay mas de un dato en la lista
        Else
            'SendMessage cmbAgencia.hWnd, 335, 1, 0
        End If

        If Not cmbAgencia.Enabled Then
            cmbAgencia.Enabled = True
            txtNombre.Enabled = True
        End If
        cmbAgencia.Focus()

    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        Exit Sub
    End Sub

    Private Sub optNombre_Click(sender As Object, e As EventArgs) Handles optNombre.Click
        If optNombre.Checked = True Then
            txtNombre.Text = ""
            txtCuenta.Text = ""
            txtNombre.Enabled = True
            txtCuenta.Enabled = False
            LimpiaCampos()
            txtNombre.Focus()
            cmbAgencia.Items.Clear()
            cmbtipoempresa.Visible = False
            cmbtiposociedad.Visible = False
            lblAPaterno.Visible = True
            lblAMaterno.Visible = True
            lblAyuda.Visible = False
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        Dim lnCuentaObjetos As Integer, i As Integer
        lnCuentaObjetos = Me.Controls.Count

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            If Trim(txtNombre.Text) <> "" Then
                '1 - Habilita controles
                HabilitaControles(1)
                LlenaComboAgencias()
                cmbtipoempresa.Visible = False
                cmbtiposociedad.Visible = False
                presentacombos()
            End If
        Else
            If cmbAgencia.Items.Count > 0 Then
                cmbAgencia.Items.Clear()
                txtCuenta.Text = ""
                LimpiaCampos()
                LimpiarTag()
            End If

        End If

    End Sub

    Public Sub presentacombos()

        If mbMoral = True And chkPersonaMoral.Checked = True Then
            lblNombre.Text = "Nombre"
            'Label14(2).Top = 345
            'txtNombreCte.Top = 255
            txtAPaterno.Enabled = False
            txtAPaterno.Visible = False
            txtAMaterno.Enabled = False
            txtAMaterno.Visible = False
            lblAPaterno.Visible = False
            lblAMaterno.Visible = False

        Else
            'lblnombre.Top = 1035
            lblAPaterno.Text = "Apellido Paterno"
            lblAPaterno.Visible = True
            lblAMaterno.Text = "ApellidoMaterno"
            lblAMaterno.Visible = True
            lblNombre.Text = "Nombre"
            txtAPaterno.Enabled = True
            txtAPaterno.Visible = True
            txtAMaterno.Enabled = True
            txtAMaterno.Visible = True
            'txtNombreCte.Top = 1035
            lblAyuda.Visible = False
        End If
        Me.Refresh()
    End Sub

    Private Sub txtNombre_LostFocus(sender As Object, e As EventArgs) Handles txtNombre.LostFocus
        If cmbAgencia.SelectedIndex >= 0 Then
            'If cmbAgencia.Selecteditem >= 0 Then
            If Trim(txtNombre.Text) <> "" Then LlenaComboAgencias()
        End If
    End Sub

    Private Sub cmbAgencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAgencia.SelectedIndexChanged
        Exit Sub
    End Sub

    Private Sub cmbAgencia_Click(sender As Object, e As EventArgs) Handles cmbAgencia.Click
        Exit Sub
        'If cmbAgencia.SelectedIndex >= 0 Then
        '    'mnAgencia = cmbAgencia.ItemData(cmbAgencia.ListIndex)
        '    mnAgencia = 1
        '    'txtCuenta.Text = Right(Left(cmbAgencia, 11), 6)
        '    txtCuenta.Text = cmbAgencia.Text.Substring(5, 6)
        '    LlenaCampos()
        '    LimpiarTag()
        '    presentacombos()
        'End If
    End Sub

    Private Sub cmbAgencia_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbAgencia.SelectionChangeCommitted
        If cmbAgencia.SelectedIndex >= 0 Then
            'mnAgencia = cmbAgencia.ItemData(cmbAgencia.ListIndex)
            mnAgencia = 1
            'txtCuenta.Text = Right(Left(cmbAgencia, 11), 6)
            'txtCuenta.Text = cmbAgencia.Text.Substring(5, 6)
            txtCuenta.Text = cmbAgencia.SelectedItem.ToString.Substring(5, 6)
            LlenaCampos()
            LimpiarTag()
            presentacombos()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub


    Private Sub LlenaCampos()

        Dim lnUnidadPadre As Long
        Dim lsCuenta As String
        Dim lnFunc As Long
        'Dim lnStatusOp As Long
        Dim lsDireccion As String
        Dim lsDireccionEnvio As String
        Dim lsnombre As String
        Dim ls_msg As String
        Dim d As New Datasource
        Dim dtDatos As DataTable
        'Dim renglon As Integer

        'Variable que indica que se esta cargando información de una cuenta
        bCargaDatosenCurso = True

        ' Variable que indica que se acaba de realizar una carga de valores en la forma
        CargaValores = True

        Cursor = System.Windows.Forms.Cursors.WaitCursor
        txtManntoPend.Text = "Buscando información de la cuenta " & txtCuenta.Text.Trim
        Me.Refresh()

        'lsCuenta = Mid(cmbAgencia.List(cmbAgencia.ListIndex), 6, 6)
        lsCuenta = cmbAgencia.Items(cmbAgencia.SelectedIndex).ToString.Substring(5, 6)
        If lsCuenta = vbNullString Then
            Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
        msnombre = ""
        mbMoral = False
        cmdGuardar.Enabled = False
        GsCuenta = lsCuenta
        txtCuenta.Text = lsCuenta
        mnStatusCta = 0
        mnStatusGlobalCta = 0
        msFechaCtaEje = ""
        msFechaPesos = ""
        mnProdCon = 0
        mnTipoCliente = -1
        cmbUbicacionEnvio.Items.Clear()
        cmbUbicacion.Items.Clear()
        'gAgencia = cmbAgencia.ItemData(cmbAgencia.ListIndex)
        gAgencia = 1
        lblRuta.Text = ""


        'Si no hay elementos en el combo, sale de la rutina.
        If cmbAgencia.Items.Count <= 0 Then Exit Sub

        Cursor = System.Windows.Forms.Cursors.WaitCursor
        txtManntoPend.Text = "Cargando la información de la cuenta " & txtCuenta.Text.Trim
        Me.Refresh()

        dtDatos = d.DatosCuenta(1, GsCuenta)

        If dtDatos.Rows.Count > 0 Then
            txtNombre.Text = dtDatos.Rows(0).Item(0).ToString.Trim & " " & dtDatos.Rows(0).Item(1).ToString.Trim & " " & dtDatos.Rows(0).Item(2).ToString.Trim
            msnombre = dtDatos.Rows(0).Item(0).ToString.Trim
            txtNombreCte.Text = dtDatos.Rows(0).Item(0).ToString.Trim
            lsnombre = txtNombreCte.Text
            txtAPaterno.Text = dtDatos.Rows(0).Item(1).ToString.Trim
            txtAMaterno.Text = dtDatos.Rows(0).Item(2).ToString.Trim
            txtTelefono.Text = dtDatos.Rows(0).Item(3).ToString.Trim
            txtRFC.Text = dtDatos.Rows(0).Item(4).ToString.Trim
            txtFax.Text = dtDatos.Rows(0).Item(5).ToString.Trim
            txtFuncPesos.Text = dtDatos.Rows(0).Item(6).ToString.Trim
            lnFunc = Val(dtDatos.Rows(0).Item(7))

            If Val(dtDatos.Rows(0).Item(8)) = 1 Then lblMancomunada.Visible = True
            ' Almacena la cuenta original en una variable
            CuentaOriginal = dtDatos.Rows(0).Item(9).ToString.Trim
            If Len(CuentaOriginal.Trim) < 10 Then
                CuentaOriginal = StrDup(10 - Len(CuentaOriginal.Trim), "0") + CuentaOriginal.Trim
            ElseIf Len(CuentaOriginal.Trim) > 10 Then
                CuentaOriginal = Mid(CuentaOriginal.ToString.Trim, Len(CuentaOriginal.Trim) - 10 + 1, 10)
            Else
                CuentaOriginal = CuentaOriginal.ToString.Trim
            End If
            ' Establece que no existen modificaciones en este atributo
            ModificacionCTA = False
            ' Formatea la Cuenta para desplegar unicamente 10 digitos
            'txtcuenta_pesos.Text = Right("0000000000" + CuentaOriginal, 10)
            txtcuenta_pesos.Text = CuentaOriginal

            'txtFechaCtaEje.Text = Format(dtDatos.Rows(0).Item(30), "dd-mm-yyyy")
            'txtFechaCtaEje.Text = Format(CDate(dtDatos.Rows(0).Item(30).ToString), "dd-MM-yyyy")
            'msFechaCtaEje = Format(CDate(dtDatos.Rows(0).Item(30).ToString), "dd-MM-yyyy")
            If dtDatos.Rows(0).Item(30).ToString <> "" Then
                txtFechaCtaEje.Text = (dtDatos.Rows(0).Item(30).ToString).Substring(3, 3) & (dtDatos.Rows(0).Item(30).ToString).Substring(0, 3) & (dtDatos.Rows(0).Item(30).ToString).Substring(6, 4) '--------- RACB 14/10/2021
                msFechaCtaEje = (dtDatos.Rows(0).Item(30).ToString).Substring(3, 3) & (dtDatos.Rows(0).Item(30).ToString).Substring(0, 3) & (dtDatos.Rows(0).Item(30).ToString).Substring(6, 4) '--------- RACB 14/10/2021
            End If
            If dtDatos.Rows(0).Item(10).ToString <> "" Then
                msFechaPesos = Format(CDate(dtDatos.Rows(0).Item(10).ToString), "dd-MM-yyyy")
            End If

            If Val(dtDatos.Rows(0).Item(11)) = 1 Then
                chkPersonaMoral.Checked = True
                cmdCotitulares.Visible = False
                cmdBeneficiarios.Text = "&Apoderados"
                lblTipoCliente.Visible = True
                CmbTipoCliente.Enabled = True
                CmbTipoCliente.Visible = True
                CmbTipoCliente.Text = dtDatos.Rows(0).Item(12)
                mbMoral = True
            Else
                chkPersonaMoral.Checked = False
                cmdCotitulares.Visible = True
                cmdBeneficiarios.Text = "&Beneficiarios"
                CmbTipoCliente.Visible = False
                CmbTipoCliente.Text = "Física"
            End If

            If dtDatos.Rows(0).Item(13).ToString <> "" Then lblCtaHou.Text = dtDatos.Rows(0).Item(13).ToString.Trim
            If dtDatos.Rows(0).Item(14).ToString <> "" Then lblFechaBanklink.Text = Format(CDate(dtDatos.Rows(0).Item(14).ToString), "dd-MM-yyyy")

            If Val(dtDatos.Rows(0).Item(15)) > 0 Then
                chkChequera.Checked = True
            Else
                chkChequera.Checked = False
            End If
            'chkChequera = Val(dtDatos.Rows(0).Item(15))
            txtManntoPend.Text = "Cargando la información direcciones de la cuenta " & txtCuenta.Text.Trim
            Me.Refresh()

            txtCalle.Text = dtDatos.Rows(0).Item(16).ToString.Trim
            txtNoExt.Text = dtDatos.Rows(0).Item(17).ToString.Trim
            txtNoInt.Text = dtDatos.Rows(0).Item(18).ToString.Trim
            txtComponente.Text = dtDatos.Rows(0).Item(19).ToString.Trim
            txtColonia.Text = dtDatos.Rows(0).Item(20).ToString.Trim
            lnUbicacion = Val(dtDatos.Rows(0).Item(21))
            txtCP.Text = dtDatos.Rows(0).Item(22).ToString.Trim
            mnProdCon = Val(dtDatos.Rows(0).Item(23))

            'Tipo cuenta Eje
            lblTipoCuenta.Text = dtDatos.Rows(0).Item(24).ToString.Trim
            'Status de la cta
            mnStatusCta = Val(dtDatos.Rows(0).Item(25))
            If dtDatos.Rows(0).Item(26).ToString <> "" Then
                lblFechaCancela.Visible = True
                lblFechaCancela.Text = Format(CDate(dtDatos.Rows(0).Item(26).ToString), "dd-MM-yyyy")
                lblT1.Visible = True
                'lblT2.Visible = True
            End If
            mnTipoCliente = Val(dtDatos.Rows(0).Item(27).ToString.Trim)
            If dtDatos.Rows(0).Item(28).ToString.Trim <> "" Then
                pnlStatusCta.Visible = True
                'Descripcion del Status de la Cta
                pnlStatusCta.Text = "Cuenta " & dtDatos.Rows(0).Item(28).ToString.Trim
            End If
            mnStatusGlobalCta = Val(dtDatos.Rows(0).Item(29))

            lsDireccion = dtDatos.Rows(0).Item(31).ToString.Trim
            'OGJ 2014oct23 Activa aviso para mantenimiento
            dtDatos = Nothing
            dtDatos = d.StatusCuenta(mnProdCon)
            If dtDatos.Rows.Count > 0 Then
                If dtDatos.Rows(0).Item(0) = 6 Then
                    'Agrega descripcion de estatus de envio a Equation.
                    pnlStatusCta.Text = "Cuenta aun NO ha sido enviada a Equation, Espere por favor"
                    pnlStatusCta0.Text = "Cuenta aun NO ha sido enviada a Equation, Espere por favor"
                Else
                    pnlStatusCta.Text = ""
                    pnlStatusCta0.Text = ""
                End If
            End If

        Else
            dtDatos = Nothing
            MsgBox("No es posible obtener información sobre la cuenta.", vbInformation, "Consulta")
            cmdCerrar.Focus()
            Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub

        End If

        dtDatos = Nothing
        '- CODIGO UBICACIÓN
        If lsDireccion <> "" Then
            If txtCalle.Text = "" And txtNoExt.Text = "" Then txtCalle.Text = lsDireccion
        End If

        dtDatos = Nothing
        If lnUbicacion > 0 Then
            dtDatos = d.ObtieneUbicacion(lnUbicacion, lsCuenta)
            If dtDatos.Rows.Count > 0 Then
                cmbUbicacion.Items.Add(dtDatos.Rows(0).Item(0))
                msUbicacion = dtDatos.Rows(0).Item(0)
                cmbUbicacion.SelectedIndex = 0
            End If
        End If

        dtDatos = Nothing
        '- CODIGO DEL/MUNICIPIO
        dtDatos = d.ObtieneDelMun(lsCuenta)
        If dtDatos.Rows.Count > 0 Then
            txtDelMunicipio.Text = dtDatos.Rows(0).Item(0).ToString.Trim
        End If

        txtManntoPend.Text = "Cargando la información dirección envio de la cuenta " & txtCuenta.Text.Trim
        Me.Refresh()

        dtDatos = Nothing
        ' Datos de Envio
        dtDatos = d.ObtieneDirEnvio(lsCuenta)
        lsDireccionEnvio = ""
        If dtDatos.Rows.Count > 0 Then
            txtCalleEnvio.Text = dtDatos.Rows(0).Item(0).ToString.Trim
            txtNoExtEnvio.Text = dtDatos.Rows(0).Item(1).ToString.Trim
            txtNoIntEnvio.Text = dtDatos.Rows(0).Item(2).ToString.Trim
            txtComponenteEnvio.Text = dtDatos.Rows(0).Item(3).ToString.Trim
            txtColoniaEnvio.Text = dtDatos.Rows(0).Item(4).ToString.Trim
            lnUbicacionEnvio = Val(dtDatos.Rows(0).Item(5))
            txtCPEnvio.Text = dtDatos.Rows(0).Item(6).ToString.Trim
            lsDireccionEnvio = dtDatos.Rows(0).Item(7).ToString.Trim
            txtDelMunicipioE.Text = dtDatos.Rows(0).Item(8).ToString.Trim
        End If

        dtDatos = Nothing

        If lsDireccionEnvio <> "" Then
            If txtCalleEnvio.Text = "" And txtNoExtEnvio.Text = "" Then txtCalleEnvio.Text = lsDireccionEnvio
        End If

        If lnUbicacionEnvio > 0 Then
            dtDatos = d.ObtieneUbicacionEnvio(lnUbicacionEnvio)
            If dtDatos.Rows.Count > 0 Then
                cmbUbicacionEnvio.Items.Add(dtDatos.Rows(0).Item(0))
                msUbicacionEnvio = dtDatos.Rows(0).Item(0)
                cmbUbicacionEnvio.SelectedIndex = 0
            End If
        End If

        dtDatos = Nothing

        txtManntoPend.Text = "Cargando la información del funcionario de la cuenta " & txtCuenta.Text.Trim
        Me.Refresh()

        'Si hay Funcionario de Cta Dlls
        If Val(lnFunc) > 0 Then
            dtDatos = d.ObtieneFunc(lnFunc)
            If dtDatos.Rows.Count > 0 Then
                lblFunc.Text = dtDatos.Rows(0).Item(0).ToString.Trim
                txtNumFuncionario.Text = dtDatos.Rows(0).Item(1).ToString.Trim
            End If

            dtDatos = Nothing
            'Obtiene la ruta del Funcionario
            dtDatos = d.ObtieneRutaFunc(lsCuenta)
            If dtDatos.Rows.Count > 0 Then
                lnUnidadPadre = dtDatos.Rows(0).Item(0)
                lblRuta.Text = "\" & Replace((dtDatos.Rows(0).Item(1)), " ", "")
            End If

            dtDatos = Nothing
            If lnUnidadPadre > 0 Then
                Do While lnUnidadPadre > 0
                    dtDatos = Nothing
                    dtDatos = d.ObtieneUnidadPadre(lnUnidadPadre)
                    If dtDatos.Rows.Count > 0 Then
                        lnUnidadPadre = dtDatos.Rows(0).Item(0)
                        lblRuta.Text = "\" & Replace((dtDatos.Rows(0).Item(1)), " ", "") & lblRuta.Text
                    End If
                Loop
            Else
                ls_msg = "El Gestor no está asignado a ningun tipo de BANCA. Pedir BANCA, DIVISION, CENTRO REGIONAL y SUCURSAL"
                ls_msg &= " del Gestor para asignarlo correctamente. Si es necesario, pedir también el nombre del Gestor de la cuenta."
                ls_msg &= "Esta información pasarla al área de Sistemas para hacer los cambios correspondientes."
                MsgBox(ls_msg, vbCritical, "MENSAJE IMPORTANTE")
            End If

        End If

        txtManntoPend.Text = "Cargando la datos adicionales de la cuenta " & txtCuenta.Text.Trim
        Me.Refresh()

        dtDatos = Nothing
        dtDatos = d.ObtieneDatosAdic(mnProdCon)
        If dtDatos.Rows.Count > 0 Then
            lblUsuario.Text = dtDatos.Rows(0).Item(0).ToString.Trim
            If dtDatos.Rows(0).Item(1).ToString.Trim <> "" Then lblFechaCaptura.Text = Format(CDate(dtDatos.Rows(0).Item(1).ToString), "dd-MM-yyyy")
            lblHoraCaptura.Text = dtDatos.Rows(0).Item(2).ToString.Trim
            If dtDatos.Rows(0).Item(3).ToString.Trim <> "" Then lblFechaAlta.Text = Format(CDate(dtDatos.Rows(0).Item(3).ToString), "dd-MM-yyyy")
            lblLinea.Text = dtDatos.Rows(0).Item(4).ToString.Trim
            lblGrabadora.Text = dtDatos.Rows(0).Item(5).ToString.Trim
        End If

        txtManntoPend.Text = "Buscando la información de participes de la cuenta " & txtCuenta.Text.Trim
        Me.Refresh()

        dtDatos = Nothing
        dtDatos = d.ExisteParticipes(lsCuenta, 1)   '-- 1 Cotitulares, 2 Beneficiarios, 3 Autorizados, 4 Apoderados
        If dtDatos.Rows.Count > 0 Then
            If Val(dtDatos.Rows(0).Item(0)) > 0 Then cmdCotitulares.Enabled = True
        End If

        dtDatos = Nothing
        dtDatos = d.ExisteParticipes(lsCuenta, 2)   '-- 1 Cotitulares, 2 Beneficiarios, 3 Autorizados, 4 Apoderados
        If dtDatos.Rows.Count > 0 Then
            If Val(dtDatos.Rows(0).Item(0)) > 0 Then cmdBeneficiarios.Enabled = True
        End If

        dtDatos = Nothing
        dtDatos = d.ExisteParticipes(lsCuenta, 3)   '-- 1 Cotitulares, 2 Beneficiarios, 3 Autorizados, 4 Apoderados
        If dtDatos.Rows.Count > 0 Then
            If Val(dtDatos.Rows(0).Item(0)) > 0 Then cmdAutorizado.Enabled = True
        End If

        'Revisar se se activaran el boton de Apoderados
        If chkPersonaMoral.Checked = True Then
            dtDatos = Nothing
            dtDatos = d.ExisteParticipes(lsCuenta, 4)   '-- 1 Cotitulares, 2 Beneficiarios, 3 Autorizados, 4 Apoderados
            If dtDatos.Rows.Count > 0 Then
                If Val(dtDatos.Rows(0).Item(0)) > 0 Then
                    cmdBeneficiarios.Enabled = True
                    cmdBeneficiarios.Text = "Apoderados"
                End If
            End If

        End If

        If mnStatusGlobalCta <> 39 Then
            cmdBeneficiarios.Enabled = True
            cmdCotitulares.Enabled = True
            cmdAutorizado.Enabled = True
            cmdGuardar.Enabled = True
            TabDirecciones.TabPages.Item("TabDirFiscal").Enabled = True
            TabDirecciones.TabPages.Item("TabDirEnvio").Enabled = True
        Else
            cmdBeneficiarios.Enabled = False
            cmdCotitulares.Enabled = False
            cmdAutorizado.Enabled = False
            cmdGuardar.Enabled = False
            chkFideicomiso.Enabled = False
            TabDirecciones.TabPages.Item("TabDirFiscal").Enabled = False
            TabDirecciones.TabPages.Item("TabDirEnvio").Enabled = False
        End If


        txtManntoPend.Text = "Revisa si es un fideicomiso la cuenta " & txtCuenta.Text.Trim
        Me.Refresh()

        'Busca si es un Fideicomiso
        If chkPersonaMoral.Checked = True Then
            dtDatos = Nothing
            dtDatos = d.EsFideicomiso(lsCuenta)

            If dtDatos.Rows.Count > 0 Then
                If Val(dtDatos.Rows(0).Item(0)) > 0 Then
                    chkFideicomiso.Enabled = True
                    Fideicomiso = 1
                    Fideicomiso = MsgBox("El cliente tiene pendiente de autorizar la Cuenta a Fideicomiso", vbInformation, "Aviso de cuentas de Fideicomiso")
                Else
                    dtDatos = Nothing
                    dtDatos = d.EsFideicomiso(lsCuenta)
                    If dtDatos.Rows.Count > 0 Then
                        If Val(dtDatos.Rows(0).Item(0)) > 0 Then
                            chkFideicomiso.Checked = True
                            chkFideicomiso.Enabled = False
                            Fideicomiso = 1
                        Else
                            chkFideicomiso.Checked = False
                            Fideicomiso = 0
                            If mnStatusGlobalCta <> 39 Then
                                chkFideicomiso.Enabled = True
                            End If
                        End If
                    Else
                        chkFideicomiso.Checked = False
                        Fideicomiso = 0
                        If mnStatusGlobalCta <> 39 Then
                            chkFideicomiso.Enabled = True
                        End If
                    End If

                End If
            Else
                chkFideicomiso.Checked = False
                Fideicomiso = 0
                If mnStatusGlobalCta <> 39 Then
                    chkFideicomiso.Enabled = True
                End If
            End If

            'llena combo  TipoCuenta
            dtDatos = Nothing
            dtDatos = d.LlenaTipoCliente()
            Dim renglon As Integer
            renglon = 0
            If dtDatos.Rows.Count > 0 Then
                For Each rows As DataRow In dtDatos.Rows
                    CmbTipoCliente.Items.Add(New CBBItem(dtDatos.Rows(renglon).Item(0), dtDatos.Rows(renglon).Item(1)))
                    'CmbTipoCliente.Items.IndexOf(dtDatos.Rows(renglon).Item(1))
                    renglon = renglon + 1
                Next
            End If

        End If

        'Apaga variable de carga de datos de la cuenta.
        bCargaDatosenCurso = False

        txtManntoPend.Text = ""
        Cursor = System.Windows.Forms.Cursors.Default
        Me.Refresh()

    End Sub

    Private Sub cmdCerrar_Click_1(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub CmbTipoCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoCliente.SelectedIndexChanged

    End Sub

    Private Sub CmbTipoCliente_DropDown(sender As Object, e As EventArgs) Handles CmbTipoCliente.DropDown
        Exit Sub
        'If chkPersonaMoral.Enabled = True Then
        '    If CmbTipoCliente.Items.Count > 0 Then
        '        mnTipoCliente = 1
        '    End If
        'End If
    End Sub

    Private Sub CmbTipoCliente_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CmbTipoCliente.SelectionChangeCommitted
        Dim o As Object = CmbTipoCliente.SelectedItem
        Dim dsc As String

        mnTipoCliente = CmbTipoCliente.SelectedIndex

        If TypeOf o Is CBBItem Then
            Dim cmbi As CBBItem
            cmbi = CType(o, CBBItem)
            dsc = cmbi.Contenido
            mnTipoCliente = cmbi.Valor
        Else
            dsc = CmbTipoCliente.SelectedItem.ToString
        End If

    End Sub

    Private Sub txtNombreCte_TextChanged(sender As Object, e As EventArgs) Handles txtNombreCte.TextChanged
        If Not bCargaDatosenCurso Then
            txtNombreCte.Tag = "1"
        End If
    End Sub

    Private Sub txtAPaterno_TextChanged(sender As Object, e As EventArgs) Handles txtAPaterno.TextChanged
        If Not bCargaDatosenCurso Then
            txtAPaterno.Tag = "1"
        End If
    End Sub

    Private Sub txtAMaterno_TextChanged(sender As Object, e As EventArgs) Handles txtAMaterno.TextChanged
        If Not bCargaDatosenCurso Then
            txtAMaterno.Tag = "1"
        End If
    End Sub

    Private Sub txtTelefono_TextChanged(sender As Object, e As EventArgs) Handles txtTelefono.TextChanged
        If Not bCargaDatosenCurso Then
            txtTelefono.Tag = "1"
        End If
    End Sub

    Private Sub txtFax_TextChanged(sender As Object, e As EventArgs) Handles txtFax.TextChanged
        If Not bCargaDatosenCurso Then
            txtFax.Tag = "1"
        End If
    End Sub

    Private Sub txtRFC_TextChanged(sender As Object, e As EventArgs) Handles txtRFC.TextChanged
        If Not bCargaDatosenCurso Then
            txtRFC.Tag = "1"
        End If
    End Sub

    Private Sub lblLinea_TextChanged(sender As Object, e As EventArgs) Handles lblLinea.TextChanged
        If Not bCargaDatosenCurso Then
            lblLinea.Tag = "1"
        End If
    End Sub

    Private Sub lblGrabadora_TextChanged(sender As Object, e As EventArgs) Handles lblGrabadora.TextChanged
        If Not bCargaDatosenCurso Then
            lblGrabadora.Tag = "1"
        End If
    End Sub

    Private Sub lblCtaHou_TextChanged(sender As Object, e As EventArgs) Handles lblCtaHou.TextChanged
        If Not bCargaDatosenCurso Then
            lblCtaHou.Tag = "1"
        End If
    End Sub

    Private Sub txtcuenta_pesos_TextChanged(sender As Object, e As EventArgs) Handles txtcuenta_pesos.TextChanged
        If Not bCargaDatosenCurso Then
            txtcuenta_pesos.Tag = "1"
        End If
    End Sub

    Private Sub txtFechaCtaEje_TextChanged(sender As Object, e As EventArgs) Handles txtFechaCtaEje.TextChanged
        If Not bCargaDatosenCurso Then
            txtFechaCtaEje.Tag = "1"
        End If
    End Sub

    Private Sub lblFechaBanklink_TextChanged(sender As Object, e As EventArgs) Handles lblFechaBanklink.TextChanged
        If Not bCargaDatosenCurso Then
            lblFechaBanklink.Tag = "1"
        End If
    End Sub

    Private Sub txtFuncPesos_TextChanged(sender As Object, e As EventArgs) Handles txtFuncPesos.TextChanged
        If Not bCargaDatosenCurso Then
            txtFuncPesos.Tag = "1"
        End If
    End Sub

    Private Sub txtNombreCte_GotFocus(sender As Object, e As EventArgs) Handles txtNombreCte.GotFocus
        Dim g As New Cursors
        g.MarcaTexto(txtNombreCte)
    End Sub

    Private Sub txtAPaterno_GotFocus(sender As Object, e As EventArgs) Handles txtAPaterno.GotFocus
        Dim g As New Cursors
        g.MarcaTexto(txtAPaterno)
    End Sub

    Private Sub txtAPaterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAPaterno.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtAMaterno.Focus()
        End If
    End Sub

    Private Sub txtAPaterno_LostFocus(sender As Object, e As EventArgs) Handles txtAPaterno.LostFocus
        Dim g As New Cursors
        txtAPaterno.Text = g.ChecaTexto(txtAPaterno.Text)
    End Sub

    Private Sub txtNombre_GotFocus(sender As Object, e As EventArgs) Handles txtNombre.GotFocus
        Dim g As New Cursors
        g.MarcaTexto(txtNombre)
    End Sub

    Private Sub txtAMaterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAMaterno.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtNombreCte.Focus()
        End If
    End Sub

    Private Sub txtNombreCte_LostFocus(sender As Object, e As EventArgs) Handles txtNombreCte.LostFocus
        txtNombreCte.Text = UCase(txtNombreCte.Text)
        If msnombre = "" Then Exit Sub
        If Trim(txtNombreCte.Text) = "" Then
            MsgBox("El nombre del Cliente no puede ser vacío.", vbInformation, "Dato Faltante")
            txtNombreCte.Enabled = True
            txtNombreCte.Text = msnombre
            txtNombreCte.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtRFC_GotFocus(sender As Object, e As EventArgs) Handles txtRFC.GotFocus
        Dim g As New Cursors
        g.MarcaTexto(txtRFC)
    End Sub

    Private Sub txtRFC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRFC.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub txtRFC_LostFocus(sender As Object, e As EventArgs) Handles txtRFC.LostFocus
        Dim g As New Cursors
        txtRFC.Text = g.ChecaTexto(txtRFC.Text)
    End Sub

    Private Sub txtTelefono_GotFocus(sender As Object, e As EventArgs) Handles txtTelefono.GotFocus
        Dim g As New Cursors
        g.MarcaTexto(txtTelefono)
    End Sub

    Private Sub txtTelefono_LostFocus(sender As Object, e As EventArgs) Handles txtTelefono.LostFocus
        Dim g As New Cursors
        txtTelefono.Text = g.ChecaTexto(txtTelefono.Text)
    End Sub

    Private Sub txtFax_GotFocus(sender As Object, e As EventArgs) Handles txtFax.GotFocus
        Dim g As New Cursors
        g.MarcaTexto(txtFax)
    End Sub

    Private Sub txtFax_LostFocus(sender As Object, e As EventArgs) Handles txtFax.LostFocus
        Dim g As New Cursors
        g.MarcaTexto(txtFax)
    End Sub

    Private Sub txtFuncPesos_GotFocus(sender As Object, e As EventArgs) Handles txtFuncPesos.GotFocus
        Dim g As New Cursors
        g.MarcaTexto(txtFuncPesos)
    End Sub

    Private Sub txtcuenta_pesos_GotFocus(sender As Object, e As EventArgs) Handles txtcuenta_pesos.GotFocus
        Dim g As New Cursors
        g.MarcaTexto(txtcuenta_pesos)
        CargaValores = False
    End Sub

    Private Sub txtcuenta_pesos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcuenta_pesos.KeyPress
        Dim lnCadena As Integer
        Dim lnCadenaDif As Integer
        Dim lsCandenaAux As String
        Dim lsCandenaCta As String

        ' Al perder el foco este control verifica el estado de la cuenta en pesos
        If Not CargaValores Then                ' Si la condicion es verdadera indica que el usuario intento modificar la cuenta

            lnCadena = Len(CuentaOriginal.ToString.Trim)
            If lnCadena < 10 Then
                lnCadenaDif = 10 - lnCadena
                lsCandenaAux = StrDup(lnCadenaDif, "0")
                lsCandenaCta = lsCandenaAux + CuentaOriginal.ToString.Trim
            ElseIf lnCadena > 10 Then
                lnCadenaDif = lnCadena - 10
                lsCandenaAux = ""
                lsCandenaCta = Mid(CuentaOriginal.ToString.Trim, lnCadenaDif - 1, 10)
            Else
                lnCadenaDif = 0
                lsCandenaAux = ""
                lsCandenaCta = CuentaOriginal.ToString.Trim
            End If

            If StrComp(txtcuenta_pesos.Text, lsCandenaCta, vbTextCompare) = 0 Then    ' Si son iguales
                ModificacionCTA = False         ' El usuario no cambio la cta en pesos
            Else
                ModificacionCTA = True          ' El usuario cambio la cta en pesos
            End If
        End If
    End Sub

    Private Sub txtFechaCtaEje_GotFocus(sender As Object, e As EventArgs) Handles txtFechaCtaEje.GotFocus
        Dim g As New Cursors
        g.MarcaTexto(txtFechaCtaEje)
    End Sub

    Private Sub txtFechaCtaEje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFechaCtaEje.KeyPress
        txtFechaCtaEje.MaxLength = 10
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            cmdGuardar.Focus()
        End If
    End Sub

    Private Sub txtFechaCtaEje_LostFocus(sender As Object, e As EventArgs) Handles txtFechaCtaEje.LostFocus
        Dim LsFecha As String
        Dim g As New Cursors
        Dim d As New Datasource

        gs_FechaHoy = Format(Now(), "dd-MM-yyyy")

        If Trim(txtFechaCtaEje.Text) <> "" Then
            If Not g.EsFechaY2K(txtFechaCtaEje.Text) Then
                txtFechaCtaEje.Text = g.FechaY2K(txtFechaCtaEje.Text)
                txtFechaCtaEje.Focus()
                g.MarcaTexto(txtFechaCtaEje)
                MsgBox("Fecha Erronea. Utilice el formato de fecha dd-mm-aaaa.", vbInformation, "Fecha Erronea")
                Exit Sub
            ElseIf CDate(txtFechaCtaEje.Text) > CDate(gs_FechaHoy) Then
                'ElseIf CDate(txtFechaCtaEje.Text) > CDate(g.InvierteFecha(gs_FechaHoy)) Then
                txtFechaCtaEje.Text = g.InvierteFecha(gs_FechaHoy)
                txtFechaCtaEje.Focus()
                g.MarcaTexto(txtFechaCtaEje)
                MsgBox("Fecha Erronea. La fecha no puede ser mayor al día de hoy.", vbInformation, "Fecha Erronea")
                Exit Sub
            Else
                txtFechaCtaEje.Text = g.FechaY2K(txtFechaCtaEje.Text)
            End If
            LsFecha = "'" & d.InvierteFecha_yyymmdd(txtFechaCtaEje.Text) & "'"
            msFechaCtaEje = Trim(txtFechaCtaEje.Text)
        End If
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click

        Dim lnUbicaDEnvio As Integer
        Dim lsCuentaPesos As String
        Dim lstipoempresa As String
        Dim lstipoSociedad As String
        Dim lsNam1 As String
        Dim lsName As String
        Dim lsnemonico As String
        Dim lsshortname As String
        Dim strValidaEjecucion As String
        Dim strTabla As String
        Dim lngOperacion As Long
        'Insert a la tabla Mantenimiento_cuenta
        Dim strOpciones() As String, i As Integer
        Dim lnConsecutivoBitacora As Long
        Dim lnConsecutivoMant As Long
        Dim lnCuentaObjetos As Integer
        'Dim lsFechaOriginal As String
        Dim lsFechaObtenida As String
        Dim lsHora As String
        Dim lsHoraValParam As String
        Dim lbBanderita As Boolean
        Dim opcion_det As Integer

        Dim bShortname As Boolean
        Dim bMnemonic As Boolean
        Dim d As New Datasource
        Dim g As New Cursors
        Dim dtDatos As DataTable
        Dim Respuesta As Integer
        Dim sTablaError As String
        '------------------------------------------------------- RACB 22/03/2023
        Dim objGlobal As New Cursors
        If objGlobal.ValidaCamposFormulario(Me.Controls) = False Then
            Exit Sub
        End If
        '------------------------------------------------------- RACB 22/03/2023
        If DatosCorrectos <> True Then Exit Sub

        If ModificacionCTA Then
            lsCuentaPesos = txtcuenta_pesos.Text    ' La cuenta ha sido modificada por el usuario
        Else
            lsCuentaPesos = CuentaOriginal          ' No se requiere actuliazar la cuenta
        End If

        strValidaEjecucion = ValidarEjecucion()

        'NO Hubo mantenimiento y no se debe continuar
        If Mid(strValidaEjecucion, 1, 1) = "0" Then
            'MsgBox ("")
            Exit Sub
        End If

        'Fue un mantenimiento y no deseo continuar
        If Mid(strValidaEjecucion, 1, 1) = "2" Then Exit Sub

        If Mid(strValidaEjecucion, 1, 1) = "1" Then
            'obtiene el estatus del producto contratado de la cuenta
            dtDatos = d.ObtieneStatusProdCont(mnProdCon)
            If dtDatos.Rows.Count > 0 Then
                If Val(dtDatos.Rows(0).Item(0)) = 3 Or Val(dtDatos.Rows(0).Item(0)) = 4 Or Val(dtDatos.Rows(0).Item(0)) = 6 Then   '-- eliminar el estatus 6
                    lbBanderita = True
                Else
                    lbBanderita = False
                End If
            Else
                lbBanderita = False
            End If
        Else
            lbBanderita = True
        End If
        'dtDatos = Nothing

        '*************************
        'IniciaTrans:
        '*************************
        'recupera Mnemonico, 'recupera Shortname
        lsnemonico = ""
        lsshortname = ""
        dtDatos = d.ObtieneShortName_Mnemonico(txtCuenta.Text)

        If dtDatos.Rows.Count > 0 Then
            If dtDatos.Rows(0).Item(1).ToString = "" Then 'No encontro valor para el Shorname
                bMnemonic = True
                If chkPersonaMoral.Checked = True Then
                    lsnemonico = g.fgMnemonico(Trim(lstipoempresa) & " " & txtNombreCte.Text.Trim, txtCuenta.Text.Trim, 1)
                Else
                    lsnemonico = g.fgMnemonico(Trim(lstipoempresa) & " " & txtNombreCte.Text.Trim, txtCuenta.Text.Trim, 1)
                End If
            End If
            If dtDatos.Rows(0).Item(0).ToString = "" Then 'No encontro valor para el Shorname
                bShortname = True
                If chkPersonaMoral.Checked = True Then
                    lsshortname = g.fgShortName(lstipoempresa & " " & txtNombreCte.Text.Trim, txtCuenta.Text.Trim, 1)
                Else
                    lsshortname = g.fgShortName(txtAPaterno.Text & " " & txtAMaterno.Text & " " & txtNombreCte.Text.Trim, txtCuenta.Text.Trim, 1)
                End If
            End If

        End If

        'revisa fechas para el mantenimiento
        lsFechaOriginal = gs_FechaHoy
        lsFechaObtenida = g.FechaOpera(lsFechaOriginal, 0)
        'lsFechaObtenida = g.InvierteFecha(g.FechaOpera(g.InvierteFecha(lsFechaOriginal)))
        lsHora = Format(DateAndTime.Now, "HH:MM:00")

        lsHoraValParam = d.ValorParametroStr("HR_FIN_MANT")

        If lsHora > lsHoraValParam Then
            If CDate(lsFechaOriginal) = CDate(lsFechaObtenida) Then
                lsFechaObtenida = DateAdd("d", 1, (lsFechaObtenida))
            End If
            lsFechaObtenida = g.FechaOpera(lsFechaObtenida, "0")
            'lsFechaObtenida = g.InvierteFecha(g.FechaOpera(g.InvierteFecha(lsFechaObtenida)))
        End If

        If CDate(lsFechaOriginal) <> CDate(lsFechaObtenida) Then
            'MsgBox "El mantenimiento en Equation y su mensaje Swift " & vbCrLf & "serán enviados el siguiente día hábil en la agencia", vbOKOnly + vbInformation, "Día feriado en la Agencia"
            MsgBox("El mantenimiento en Equation" & vbCrLf & "serán enviados el siguiente día hábil en la agencia", vbOKOnly + vbInformation, "Día feriado en la Agencia")
            lsFechaOriginal = lsFechaObtenida
        End If

        Dim lsGsSql As String
        'actualiza datos en tabla CLIENTES
        lsGsSql = "Update "
        lsGsSql &= " CATALOGOS.dbo.CLIENTE "
        lsGsSql &= " set "
        If chkPersonaMoral.Checked = False Then
            lsGsSql &= " nombre_cliente = '" & UCase(Trim(txtNombreCte.Text)) & "', "
            lsGsSql &= " apellido_paterno = '" & UCase(Trim(txtAPaterno.Text)) & "', "
            lsGsSql &= " apellido_materno = '" & UCase(Trim(txtAMaterno.Text)) & "', "
        Else
            lsGsSql &= " nombre_cliente = '" & UCase(Trim(txtNombreCte.Text)) & "', "
            lsGsSql &= " apellido_paterno = '',"
            lsGsSql &= " apellido_materno = '',"
            lsGsSql &= " tipo_cliente = '" & mnTipoCliente & "', "
        End If
        lsGsSql &= " rfc = '" & Trim(txtRFC.Text) & "', "
        lsGsSql &= " telefono_cliente = '" & Trim(txtTelefono.Text) & "', "
        lsGsSql &= " fax_cliente = '" & UCase(Trim(txtFax.Text)) & "', "
        lsGsSql &= " func_pesos = '" & UCase(Trim(txtFuncPesos.Text)) & "', "
        lsGsSql &= " calle = '" & UCase(Trim(txtCalle.Text)) & "', "
        lsGsSql &= " no_ext = '" & UCase(Trim(txtNoExt.Text)) & "', "
        lsGsSql &= " no_int = '" & UCase(Trim(txtNoInt.Text)) & "', "
        lsGsSql &= " componente = '" & UCase(Trim(txtComponente.Text)) & "', "
        lsGsSql &= " colonia_cliente = '" & UCase(Trim(txtColonia.Text)) & "', "
        'lsGsSql &= " del_o_municipio = '" & msUbicacion & "', "                   'cambiar por el dato duro recuperado de la BD y activar el id para mantenimiento.
        lsGsSql &= " del_o_municipio = '" & UCase(Trim(txtDelMunicipio.Text)) & "', "      'Se toma el dato del textbox, en lugar de la dsc de contenido del combo Ubicación..
        lsGsSql &= " cp_cliente = '" & UCase(Trim(txtCP.Text)) & "', "
        lsGsSql &= " ubicacion = " & mnUbicacion & ", "
        lsGsSql &= " cuenta_eje_pesos = '" & lsCuentaPesos & "', "
        If bMnemonic Then
            lsGsSql &= " mnemonico = '" & lsnemonico & "', "
        End If
        If bShortname Then
            lsGsSql &= " shortname  ='" & Trim(lsshortname) & "',"
        End If
        lsGsSql &= " fecha_cuenta_pesos = '" & d.InvierteFecha_yyymmdd(txtFechaCtaEje.Text) & "', "
        lsGsSql &= " cuenta_modificada = 1 "
        lsGsSql &= " where "
        lsGsSql &= " cuenta_cliente = '" & Trim(GsCuenta) & "'"
        lsGsSql &= " and agencia = 1"

        Respuesta = d.UpdCliente(lsGsSql)

        If Respuesta <= 0 Then
            sTablaError = "CLIENTE"
            GoTo ErrorTran
        End If

        'inserta en Fideicomiso
        If chkFideicomiso.Checked = True And chkPersonaMoral.Checked = True And Fideicomiso = 0 Then
            'Insertar datos en Tabla Fideicomiso si el Ckeck esta activo

            gn_Operacion_Definida = 8100
            FecAlta = Format(txtFechaCtaEje.Text, "yyyy-mm-dd")
            Respuesta = 0

            lsGsSql = "Insert into catalogos..CLIENTE_FIDEICOMISO ("
            lsGsSql &= " agencia, cuenta_cliente, fecha_alta, fecha_baja, estatus, tipo_operacion ) "
            lsGsSql &= " values ( 1 , '" & Trim(txtCuenta.Text) & "', '" & FecAlta & "', null, 0, 'M') "

            Respuesta = d.UpdCliente(lsGsSql)

            chkFideicomiso.Enabled = False

            If Respuesta <= 0 Then
                sTablaError = "CLIENTE_FIDEICOMISO"
                GoTo ErrorTran
            End If

            'inserta en PERMISOS_REMOTOS
            lsGsSql = "Insert into CATALOGOS..PERMISOS_REMOTOS"
            lsGsSql &= " (cuenta_cliente, operacion_definida, monto, usuario, fecha,"
            lsGsSql &= " datos_referencia, comentario_peticion, comentario_respuesta, status_autorizacion, autorizacion, aplicacion)"
            lsGsSql &= " values ('" & Trim(txtCuenta.Text) & "'," & gn_Operacion_Definida
            lsGsSql &= ",  0 , " & usuario & ", getdate()"
            lsGsSql &= ", 'Autorizacion Manto de Fideicomiso', null,'AMFIDEICOMISOS',0,0,2)"
            Respuesta = 0

            Respuesta = d.UpdCliente(lsGsSql)
            If Respuesta <= 0 Then
                sTablaError = "PERMISOS_REMOTOS"
                GoTo ErrorTran
            End If

            Fideicomiso = MsgBox("Para que se Realice la Actualizacion a Fideicomiso Tendra que ser Autorizado", vbExclamation, "Aviso para Autorizacion de Fideicomiso")

        End If

        'revisa si hay direccion de envio
        If mbDirecEnvio Then
            'Revisa si ya existe algún registro
            lsGsSql = "Select count(*) "
            lsGsSql &= "from CATALOGOS.dbo.DIRECCION_ENVIO "
            lsGsSql &= "Where cuenta_cliente = '" & Trim(GsCuenta) & "'"
            lsGsSql &= " and agencia = 1"

            lnUbicaDEnvio = 0
            lnUbicaDEnvio = d.ConsultaQuery(lsGsSql)

            If lnUbicaDEnvio = 0 Then 'NO tiene direccion de envio la cuenta
                'si NO hay direccion de envio, inserta en DIRECCION_ENVIO
                lsGsSql = "Insert into "
                lsGsSql &= "CATALOGOS.dbo.DIRECCION_ENVIO "
                lsGsSql &= " (agencia, cuenta_cliente, cp_cliente, colonia_cliente, "
                lsGsSql &= " ubicacion, calle_envio, no_ext_envio, no_int_envio, "
                lsGsSql &= " direccion_cliente, componente_envio, del_o_municipio_envio) "
                lsGsSql &= " values "
                lsGsSql &= " ( 1 , '" & Trim(GsCuenta) & "', "
                lsGsSql &= " '" & UCase(Trim(txtCPEnvio.Text)) & "', "
                lsGsSql &= " '" & UCase(Trim(txtColoniaEnvio.Text)) & "', "
                lsGsSql &= mnUbicaEnvio & ", '" & UCase(Trim(txtCalleEnvio.Text)) & "', "
                lsGsSql &= " '" & UCase(Trim(txtNoExtEnvio.Text)) & "' "
                If Trim(txtNoIntEnvio.Text) <> "" Then
                    lsGsSql &= " ,'" & UCase(Trim(txtNoIntEnvio.Text)) & "' "
                Else
                    lsGsSql &= " , '' "
                End If
                If Trim(txtCalleEnvio.Text) <> "" Or Trim(txtNoExtEnvio.Text) <> "" Or Trim(txtNoIntEnvio.Text) <> "" Then
                    lsGsSql &= " ,'" & UCase(Trim(txtCalleEnvio.Text)) & " " & UCase(Trim(txtNoExtEnvio.Text)) & " " & UCase(Trim(txtNoIntEnvio.Text)) & "' "
                Else
                    lsGsSql &= " , '' "
                End If
                If Trim(txtComponenteEnvio.Text) <> "" Then
                    lsGsSql &= " ,'" & UCase(Trim(txtComponenteEnvio.Text)) & "' "
                Else
                    lsGsSql &= " ,'' "
                End If
                'lsGsSql &= " , '" & msUbicacionEnvio & "')"     'se toma el contenido del textbox
                lsGsSql &= " , '" & UCase(Trim(txtDelMunicipioE.Text)) & "')"

            ElseIf lnUbicaDEnvio > 0 Then
                'si hay direccion de envio, actualiza DIRECCION_ENVIO
                lsGsSql = "update CATALOGOS.dbo.DIRECCION_ENVIO set"
                lsGsSql &= " calle_envio = '" & UCase(Trim(txtCalleEnvio.Text)) & "',"
                lsGsSql &= " no_ext_envio = '" & UCase(Trim(txtNoExtEnvio.Text)) & "', "
                If Trim(txtNoIntEnvio.Text) <> "" Then
                    lsGsSql &= "no_int_envio = '" & UCase(Trim(txtNoIntEnvio.Text)) & "', "
                End If
                If Trim(txtComponenteEnvio.Text) <> "" Then
                    lsGsSql &= "componente_envio = '" & UCase(Trim(txtComponenteEnvio.Text)) & "', "
                End If
                lsGsSql &= " direccion_cliente = '" & UCase(Trim(txtCalleEnvio.Text)) & " " & UCase(Trim(txtNoExtEnvio.Text)) & " " & UCase(Trim(txtNoIntEnvio.Text)) & "',"
                lsGsSql &= " colonia_cliente = '" & UCase(Trim(txtColoniaEnvio.Text)) & "',"
                'lsGsSql &= " del_o_municipio_envio = '" & msUbicacionEnvio & "', "
                lsGsSql &= " del_o_municipio_envio = '" & UCase(Trim(txtDelMunicipioE.Text)) & "', "
                lsGsSql &= " cp_cliente = '" & UCase(Trim(txtCPEnvio.Text)) & "',"
                lsGsSql &= " ubicacion = " & mnUbicaEnvio
                lsGsSql &= " Where "
                lsGsSql &= " cuenta_cliente = '" & Trim(GsCuenta) & "'"
                lsGsSql &= " and agencia = " & mnAgencia

            End If
            Respuesta = 0

            Respuesta = d.UpdCliente(lsGsSql)
            If Respuesta <= 0 Then
                sTablaError = "DIRECCION_ENVIO"
                GoTo ErrorTran
            End If

            'actualiza en CUENTA_BCA_CR
            If lnUbicaDEnvio >= 0 Then
                lsGsSql = "update "
                lsGsSql &= "CUENTA_BCA_CR set"
                lsGsSql &= " ubicacion = " & mnUbicaEnvio
                lsGsSql &= " Where cuenta = '" & Trim(GsCuenta) & "'"
                Respuesta = 0

                Respuesta = d.UpdCliente(lsGsSql)
                If Respuesta <= 0 Then
                    sTablaError = "CUENTA_BCA_CR"
                    GoTo ErrorTran
                End If

            End If

            Respuesta = 0
            'inserta en EVENTO_PRODUCTO
            Respuesta = d.InsertaEventoProducto(mnProdCon, d.InvierteFecha_yyymmdd(gs_FechaHoy), lsHora, mnStatusCta, usuario)
            If Respuesta <= 0 Then
                sTablaError = "EVENTO_PRODUCTO"
                MsgBox("Hubo un error al actualizar la tabla: " & sTablaError, vbInformation, "Actualiza" & sTablaError)
                'GoTo ErrorTran
            End If

        End If

        'Mantenimiento TABLA MANTENIMIENTO_CUENTA
        'el primer digito de strValidaEjecucion indica si hubo o no mantenimientos
        'si el primer digito es 0, NO hay mantenimiento
        If Mid(strValidaEjecucion, 1, 1) = "1" Then
            If lbBanderita Then
                gs_Sql = "SELECT OP.operacion " &
                        "FROM OPERACION OP, OPERACION_DEFINIDA OD " &
                        "WHERE OP.OPERACION_DEFINIDA = OD.OPERACION_DEFINIDA " &
                        "AND OD.OPERACION_DEFINIDA_GLOBAL=100 " &
                        "AND producto_contratado=" & mnProdCon
                lngOperacion = d.ConsultaQuery(gs_Sql)

                'el primer digito de strValidaEjecucion indica si hubo o no mantenimientos
                'si el primer digito es 0, NO hay mantenimiento
                'hacemos el split de cada opción que hubo cambios, a partir de la posición 2, ya que la uno es el indicador primario.
                strOpciones = Split(Mid(strValidaEjecucion, 2), ",")
                'strOpciones = Split(Mid(strValidaEjecucion, 2), ",")

                If lngOperacion <> 0 Then
                    For i = 0 To UBound(strOpciones)
                        If strOpciones(i) <> 0 Then
                            opcion_det = Val(strOpciones(i))
                            'If strOpciones(i) = 2 Or strOpciones(i) = 3 Or strOpciones(i) = 10 Or strOpciones(i) = 12 Or strOpciones(i) = 11 Or (strOpciones(i) = 1 And intCuentaEje) Then
                            gs_Sql = "Insert into MANTENIMIENTO_CUENTA (producto_contratado, tipo_mantenimiento, " &
                                                 "fecha_mantenimiento, fecha_operacion, status_mantenimiento, usuario) " &
                                    "VALUES (" & mnProdCon & "," & strOpciones(i) & "," & "getdate(),'" &
                                                d.InvierteFecha_yyymmdd(lsFechaOriginal) & "'," & "4," & usuario & ")"

                            Respuesta = d.InsQuery(gs_Sql)
                            If Respuesta <= 0 Then
                                sTablaError = "EVENTO_PRODUCTO"
                                MsgBox("Hubo un error al actualizar la tabla: " & sTablaError, vbInformation, "Actualiza" & sTablaError)
                                'GoTo ErrorTran
                            End If

                            'Else
                            '     gs_Sql = "Insert into MANTENIMIENTO_CUENTA (producto_contratado, tipo_mantenimiento, " &
                            '                    "fecha_mantenimiento, fecha_operacion, status_mantenimiento, usuario) " &
                            '        "VALUES (" & mnProdCon & "," & strOpciones(i) & "," & "getdate(),'" &
                            'lsFechaOriginal & "'," & "4," & usuario & ")"
                            'End If

                            If strOpciones(i) = 1 Or strOpciones(i) = 2 Or strOpciones(i) = 3 Or strOpciones(i) = 10 Or strOpciones(i) = 12 Or strOpciones(i) = 11 Then
                                graba_Detalle_Mnnto(opcion_det)
                            End If
                        End If
                    Next
                Else
                    MsgBox("No existe ticket de la cuenta o el registro está incompleto." & vbCrLf &
                            "El mantenimiento a Equation y Swift deberá llevarse a cabo en forma manual.", vbOKOnly + vbInformation,
                            "Información de apertura de cuenta incompleta")
                End If
            End If
        End If



        'actualiza RENOVACION_W8
        'Mantenimiento TABLAS RENOVACION_W8 O AVISO_MANTENIMIENTO_CUENTA
        'If cmbConfirmaRecepcion.ListCount > 0 And cmbConfirmaRecepcion.ListIndex > -1 Then
        '    If Mid(cmbConfirmaRecepcion.List(cmbConfirmaRecepcion.ListIndex), 1, InStr(1, cmbConfirmaRecepcion.List(cmbConfirmaRecepcion.ListIndex), "-") - 1) = "5" Then
        '        gs_Sql = "UPDATE RENOVACION_W8 " &
        '            "SET status_aviso = 1, " &
        '            "fecha_renovacion=convert(char(10), getdate(), 110)," &
        '            "fecha_vencimiento=convert(char(10), dateadd(yy,3,getdate()), 110)" &
        '            "WHERE id_mantenimiento=" & cmbConfirmaRecepcion.ItemData(cmbConfirmaRecepcion.ListIndex)
        '    Else
        '        gs_Sql = "UPDATE AVISO_MANTENIMIENTO_CUENTA " &
        '            "SET status_aviso = 1, " &
        '            "fecha_recepcion = convert(char(10), getdate(), 110) " &
        '            "WHERE id_mantenimiento=" & cmbConfirmaRecepcion.ItemData(cmbConfirmaRecepcion.ListIndex)
        '    End If

        '    dbExecQuery gs_Sql
        'If dbError Then GoTo ErrorTran
        '    dbEndQuery
        'End If



        'si banderita es TRUE
        'actualiza MANTENIMIENTO_CUENTA
        'inserta en EVENTO_PRODUCTO
        'OGJ - 2021mayo17; Como nunca se activa el panel de mantenimiento pendiente pnlManttoPend se omite todo el codigo siguiente.
        'If pnlManttoPend.Visible = True Then
        '    If lbBanderita Then
        '        gs_Sql = "UPDATE MANTENIMIENTO_CUENTA " &
        '            "SET status_mantenimiento=7 " &
        '            "WHERE status_mantenimiento = 1 " &
        '            "AND id_mantenimiento= " & strArregloMantenimiento(0)

        '        dbExecQuery gs_Sql
        '    If dbError Then GoTo ErrorTran
        '        dbEndQuery
        '        '///////////////////////////////////////////////////////

        '        gs_Sql = "Insert into "
        '        gs_Sql = gs_Sql & " EVENTO_PRODUCTO "
        '        gs_Sql = gs_Sql & " (producto_contratado, fecha_evento, status_producto, "
        '        gs_Sql = gs_Sql & " comentario_evento, usuario) "
        '        gs_Sql = gs_Sql & " values "
        '        gs_Sql = gs_Sql & " ( " & mnProdCon & ", '" & gs_FechaHoy & " " & HoraSistema & "', "
        '        gs_Sql = gs_Sql & mnStatusCta & "," & Mid("MANT. CUENTA POR CORRECCION: " & Mid(cmbConfirmaRecepcion.List(cmbConfirmaRecepcion.ListIndex), InStr(1, cmbConfirmaRecepcion.List(cmbConfirmaRecepcion.ListIndex), "-") + 1), 1, 100) & ", " & gn_Usuario & ") "
        '        'Inserto un registro en EVENTO_PRODUCTO
        '        dbExecQuery gs_Sql
        '    If dbError Then GoTo ErrorTran
        '        dbEndQuery

        '        '///////////////////////////////////////////////////////

        '        gs_Sql = "INSERT INTO MANTENIMIENTO_CUENTA(tipo_mantenimiento," &
        '                                                "fecha_mantenimiento," &
        '                                                "status_mantenimiento," &
        '                                                "usuario," &
        '                                                "fecha_operacion, " &
        '                                                "producto_contratado) " &
        '            "VALUES(" & strArregloMantenimiento(1) & "," &
        '                    "getdate()," &
        '                    "2," &
        '                    gn_Usuario & ",'" &
        '                    lsFechaOriginal & "'," &
        '                    mnProdCon & ")"

        '        dbExecQuery gs_Sql
        '    If dbError Then GoTo ErrorTran
        '        dbEndQuery
        '        gs_Sql = "select @@Identity"
        '        dbExecQuery gs_Sql
        '    If dbError Then GoTo ErrorTran
        '        dbGetRecord

        '        gs_Sql = "INSERT INTO AVISO_MANTENIMIENTO_CUENTA(id_mantenimiento," &
        '                                                    "fecha_aviso," &
        '                                                    "status_aviso," &
        '                                                    "fecha_recepcion) " &
        '                "VALUES(" & Val(dbGetValue(0)) & ",'" &
        '                strArregloMantenimiento(2) & "'," &
        '                "0," &
        '                "NULL )"
        '        dbEndQuery
        '        dbExecQuery gs_Sql
        '    If dbError Then GoTo ErrorTran
        '        dbEndQuery

        '        gs_Sql = "SELECT OP.operacion " &
        '            "FROM OPERACION OP, OPERACION_DEFINIDA OD " &
        '            "WHERE OP.OPERACION_DEFINIDA = OD.OPERACION_DEFINIDA " &
        '                "AND OD.OPERACION_DEFINIDA_GLOBAL=100 " &
        '                "AND producto_contratado=" & mnProdCon
        '        dbExecQuery gs_Sql
        '    If dbError Then GoTo ErrorTran
        '        dbGetRecord

        '        'Ingreso a la tabla BITACORA_REPORTE_SWIFT_MT198
        '        gs_Sql = "Insert into BITACORA_REPORTE_SWIFT_MT198 (operacion, " &
        '                                                 "tipo_operacion," &
        '                                                 "agencia," &
        '                                                 "archivo," &
        '                                                 "fecha_envio," &
        '                                                 "fecha_validado," &
        '                                                 "status_reporte," &
        '                                                 "status_envio) " &
        '                "values(" & dbGetValue(0) & "," &
        '                         "'CM'," &
        '                         mnAgencia & "," &
        '                         "NULL,'" &
        '                         lsFechaOriginal & " " & lsHora & "'," &
        '                         "NULL," &
        '                         "'2'," &
        '                         "0)"

        '        dbEndQuery
        '        dbExecQuery gs_Sql
        '    If dbError Then GoTo ErrorTran
        '        dbEndQuery

        '        '///////////////////////////////////////////////////////

        '        gs_Sql = "Insert into "
        '        gs_Sql = gs_Sql & " EVENTO_PRODUCTO "
        '        gs_Sql = gs_Sql & " (producto_contratado, fecha_evento, status_producto, "
        '        gs_Sql = gs_Sql & " comentario_evento, usuario) "
        '        gs_Sql = gs_Sql & " values "
        '        gs_Sql = gs_Sql & " ( " & mnProdCon & ", '" & gs_FechaHoy & " " & HoraSistema & "', "
        '        gs_Sql = gs_Sql & mnStatusCta & "," & Mid("MANT. CUENTA POR CORRECCION: " & Mid(cmbConfirmaRecepcion.List(cmbConfirmaRecepcion.ListIndex), InStr(1, cmbConfirmaRecepcion.List(cmbConfirmaRecepcion.ListIndex), "-") + 1), 1, 100) & ", " & gn_Usuario & ") "
        '        'Inserto un registro en EVENTO_PRODUCTO
        '        dbExecQuery gs_Sql
        '    If dbError Then GoTo ErrorTran
        '        dbEndQuery
        '    End If
        '    '///////////////////////////////////////////////////////
        'End If

        Cursor = System.Windows.Forms.Cursors.Default
        cmdBeneficiarios.Enabled = False
        cmdCotitulares.Enabled = False
        cmdAutorizado.Enabled = False
        'cmdGuardar_LostFocus
        selec = False
        cmdGuardar.Enabled = False
        TabDirFiscal.Enabled = False
        TabDirEnvio.Enabled = False

        lnCuentaObjetos = Me.Controls.Count

        For i = 0 To lnCuentaObjetos - 1
            If Me.Controls(i).Name <> "txtCuenta" And
            Me.Controls(i).Name <> "cmdCerrar" Then
                Me.Controls(1).Enabled = False
            End If
        Next

        MsgBox("La modificación a la información de la cuenta se realizó exitósamente.", vbInformation, "Mantenimiento Cuenta")
        txtNombre.Enabled = False
        cmbAgencia.Enabled = False
        cmdCerrar.Focus()
        Exit Sub

ErrorTran:
        MsgBox("Hubo un error al actualizar la tabla: " & sTablaError, vbCritical, "Actualiza" & sTablaError)

    End Sub




    Private Function DatosCorrectos() As Boolean
        Dim g As New Cursors

        'OGJ 2014oct24, se da aviso de dato faltante, pero permite continuar con el mantenimiento
        DatosCorrectos = False

        'Campos obligatorios y que no pueden ser nulos
        If Trim(txtNombreCte.Text) = "" And msnombre <> "" Then
            MsgBox("Es necesario indicar el Nombre del Cliente.", vbInformation, "Dato Faltante")
            txtNombreCte.Text = msnombre
            txtNombreCte.Focus()
            Exit Function
        End If
        'La persona es Moral
        If mbMoral = False Then
            If Trim(txtAPaterno.Text) = "" Then
                MsgBox("Es necesario indicar el apellido Paterno del Cliente.", vbInformation, "Dato Faltante")
                txtAPaterno.Focus()
                Exit Function
            End If
        End If
        If chkPersonaMoral.Checked = True And mnTipoCliente < 0 Then
            MsgBox("Es necesario que seleccione el tipo de persona Moral.", vbInformation, "Tipo de Persona")
            'CmbTipoCliente.Focus()
            Exit Function
        End If
        If Len(txtcuenta_pesos.Text) <> 10 Then
            'Cursor = System.Windows.Forms.Cursors.Default
            MsgBox("Es necesario capturar los 10 digitos de la cuenta", vbInformation, "Aviso")
            'Cursor = System.Windows.Forms.Cursors.WaitCursor
            txtcuenta_pesos.Focus()
            Exit Function
        End If
        'Fecha cuenta Eje Pesos
        'fecha con formato mmm-dd-aaaa
        If Trim(txtFechaCtaEje.Text) <> "" Then
            If msFechaCtaEje = "" Then msFechaCtaEje = txtFechaCtaEje.Text
            'Fecha con formato dd-mm-aaaa
            If Not g.EsFechaY2K(msFechaPesos) Then
                txtFechaCtaEje.Focus()
                g.MarcaTexto(txtFechaCtaEje)
                MsgBox("Fecha Erronea. Utilice el formato de fecha dd-mm-aaaa.", vbInformation, "Fecha Erronea")
                Exit Function
            ElseIf CDate(msFechaPesos) > CDate(gs_FechaHoy) Then
                'ElseIf CDate(msFechaPesos) > CDate(g.InvierteFecha(gs_FechaHoy)) Then
                txtFechaCtaEje.Text = g.InvierteFecha(gs_FechaHoy)
                txtFechaCtaEje.Focus()
                g.MarcaTexto(txtFechaCtaEje)
                MsgBox("Fecha Erronea. La fecha no puede ser mayor al día de hoy.", vbInformation, "Fecha Erronea")
                Exit Function
            End If
        End If
        'Campos obligatorios en el complemento de una apertura en Dirección
        'No se ha capturado la calle
        If Trim(txtCalle.Text) = "" Then
            MsgBox("No se indico la Calle.", vbInformation, "Aviso Datos")
            txtCalle.Focus()
            Exit Function
        End If
        'No se ha capturado la direccion
        If Trim(txtNoExt.Text) = "" Then
            MsgBox("No se indico el No. Exterior.", vbInformation, "Aviso Datos")
            txtNoExt.Focus()
            Exit Function
        End If
        'No se ha capturado la colonia
        If Trim(txtColonia.Text) = "" Then
            MsgBox("No se indico la Colonia del Cliente.", vbInformation, "Aviso Datos")
            txtColonia.Focus()
            Exit Function
        End If
        'No se ha seleccionado al Ubicacion
        If msUbicacion = "" Then
            MsgBox("No se indico una ciudad de la lista.", vbInformation, "Aviso Datos")
            'cmbUbicacion.SetFocus
            'Exit Function
        End If
        If mnUbicacion = 0 Then mnUbicacion = lnUbicacion
        'No se ha capturado el C.P.
        If Trim(txtCP.Text) = "" Then
            MsgBox("No se indico el C.P. del Cliente.", vbInformation, "Aviso Datos")
            txtCP.Focus()
            Exit Function
        End If

        mbDirecEnvio = False
        'Campos obligatorios en el complemento de una apertura en Dirección Envío
        'Si alguno es diferencte de vacio, llenar todos
        If Trim(txtCalleEnvio.Text) <> "" Or Trim(txtNoExtEnvio.Text) <> "" Or
            Trim(txtColoniaEnvio.Text) <> "" Or cmbUbicacionEnvio.SelectedIndex > -1 Or
            Trim(txtCPEnvio.Text) <> "" Then

            'No se ha capturado la calle
            If Trim(txtCalleEnvio.Text) = "" Then
                MsgBox("No se indico la Calle de la Dirección de Envío.", vbInformation, "Aviso Datos")
                txtCalleEnvio.Focus()
                Exit Function
            End If
            'No se ha capturado la direccion
            If Trim(txtNoExtEnvio.Text) = "" Then
                MsgBox("No se indico el No. Exterior de la Dirección de Envío.", vbInformation, "Aviso Datos")
                txtNoExtEnvio.Focus()
                Exit Function
            End If
            'No se ha capturado la colonia
            If Trim(txtColoniaEnvio.Text) = "" Then
                MsgBox("No se indico la Colonia de la Dirección de Envío.", vbInformation, "Aviso Datos")
                txtColoniaEnvio.Focus()
                Exit Function
            End If
            'No se ha seleccionado al Ubicacion
            If msUbicacionEnvio = "" Then
                MsgBox("No se indico una Ciudad de la lista en Dirección de Envío.", vbInformation, "Aviso Datos")
                cmbUbicacionEnvio.Focus()
                'mbDirecEnvio = False
                Exit Function
            End If
            If mnUbicaEnvio = 0 Then mnUbicaEnvio = lnUbicacionEnvio
            'No se ha capturado el C.P.
            If Trim(txtCPEnvio.Text) = "" Then
                MsgBox("No se indico el C.P. de la Dirección de Envío.", vbInformation, "Aviso Datos")
                txtCPEnvio.Focus()
                Exit Function
            End If
        End If
        'Si alguno es diferencte de vacio, llenar todos
        If Trim(txtCalleEnvio.Text) <> "" And Trim(txtNoExtEnvio.Text) <> "" And
            Trim(txtColoniaEnvio.Text) <> "" And cmbUbicacionEnvio.SelectedIndex > -1 And
            Trim(txtCPEnvio.Text) <> "" Then
            'Si se modificó dirección envio
            mbDirecEnvio = True
        End If
        'Datos obligatorios para el complemento
        If Trim(txtTelefono.Text) = "" Then
            MsgBox("No se indico el número de teléfono.", vbInformation, "Aviso Datos")
            txtTelefono.Focus()
            Exit Function
        End If
        If Trim(txtFuncPesos.Text) = "" Then
            MsgBox("No se indico el nombre del Gestor Pesos.", vbInformation, "Aviso Datos")
            txtFuncPesos.Focus()
            Exit Function
        End If

        DatosCorrectos = True

    End Function



    Private Function ValidarEjecucion() As String
        Dim strMensaje As String
        Dim intMantenimientoCE As Integer
        Dim intMantenimientoD As Integer
        Dim intMantenimientoDE As Integer
        Dim intMantenimientoDCN As Integer
        Dim intMantenimientoDCT As Integer
        Dim intMantenimientoRFC As Integer
        Dim intMantenimientoGP As Integer

        strMensaje = ""


        If pnlManttoPend.Visible = True And pnlManttoPend.Tag = "2" Then
            If cmbUbicacion.Tag = "" Then
                MsgBox("No se actualizó información para el mantenimiento pendiente, no puede seguir con la operación ", vbYesNo + vbDefaultButton1, "Mantenimiento")
                ValidarEjecucion = "2"
                cmbUbicacion.Focus()
                GoTo Salida
            End If
        ElseIf pnlManttoPend.Visible = True And pnlManttoPend.Tag = "3" Then
            If cmbUbicacionEnvio.Tag = "" Then
                MsgBox("No se actualizó información para el mantenimiento pendiente, no puede seguir con la operación ", vbYesNo + vbDefaultButton1, "Mantenimiento")
                ValidarEjecucion = "2"
                cmbUbicacionEnvio.Focus()
                GoTo Salida
            End If
        End If

        ''If cmbConfirmaRecepcion.ListCount > 0 And cmbConfirmaRecepcion.ListIndex > -1 Then
        'If cmbConfirmaRecepcion.Items.Count > 0 And cmbConfirmaRecepcion.SelectedIndex > -1 Then
        '    'If MsgBox("¿Confirma recepción de documentos de " & Mid(cmbConfirmaRecepcion.List(cmbConfirmaRecepcion.ListIndex), InStr(1, cmbConfirmaRecepcion.List(cmbConfirmaRecepcion.ListIndex), "-") + 1) & " de la cuenta: " & txtCuenta & " ?", vbYesNo + vbDefaultButton1, "Mantenimiento") = vbNo Then
        '    If MsgBox("¿Confirma recepción de documentos de " &
        '              Mid(cmbConfirmaRecepcion.SelectedItem(cmbConfirmaRecepcion.SelectedIndex), InStr(1, cmbConfirmaRecepcion.List(cmbConfirmaRecepcion.ListIndex), "-") + 1) &
        '              " de la cuenta: " & txtCuenta & " ?", vbYesNo + vbDefaultButton1, "Mantenimiento") = vbNo Then
        '        ValidarEjecucion = "2"
        '        GoTo Salida
        '    End If
        'End If

        If txtNombreCte.Tag <> "" Or txtAPaterno.Tag <> "" Or txtAMaterno.Tag <> "" Then
            strMensaje = "Datos de Nombre del Cliente " & vbCrLf & "--------------------------------------" & vbCrLf
            intMantenimientoDCN = 10
            If txtNombreCte.Tag <> "" Then intMnntoNC_N = True
            If txtAPaterno.Tag <> "" Then intMnntoNC_AP = True
            If txtAMaterno.Tag <> "" Then intMnntoNC_AM = True
        End If

        If txtRFC.Tag <> "" Then
            If strMensaje <> "" Then
                strMensaje = strMensaje = "Datos de RFC " & vbCrLf & "--------------------------------------" & vbCrLf
            Else
                strMensaje = "Datos de RFC " & vbCrLf & "--------------------------------------" & vbCrLf
            End If
            intMantenimientoRFC = 12
        End If

        'txxtfunpesos.tag se debe iniciar a 0, ya que se activa nuevamente cuando se carga la info nuevamente
        If txtTelefono.Tag <> "" Or txtFax.Tag <> "" Or txtFuncPesos.Tag <> "" Then
            If strMensaje <> "" Then
                strMensaje = strMensaje & vbCrLf & strMensaje = "Datos de Funcionario Pesos/Telefono/Fax " & vbCrLf & "--------------------------------------" & vbCrLf
            Else
                strMensaje = "Datos de Funcionario Pesos/Telefono/Fax " & vbCrLf & "--------------------------------------" & vbCrLf
            End If

            intMantenimientoDCT = 11
            'Gestor Pesos
            If txtFuncPesos.Tag <> "" Then intMnntoGestor = True
            'Telefono
            If txtTelefono.Tag <> "" Then intMnntoTelef = True
            'Fax
            If txtFax.Tag <> "" Then intMnntoFax = True
        End If

        'Cuenta eje
        If txtcuenta_pesos.Tag <> "" Or txtFechaCtaEje.Tag <> "" Then
            If strMensaje <> "" Then
                strMensaje = strMensaje & vbCrLf & "Datos de Cuenta Eje" & vbCrLf & "--------------------------------------" & vbCrLf
            Else
                strMensaje = "Datos de Cuenta Eje" & vbCrLf & "--------------------------------------" & vbCrLf
            End If

            intMantenimientoCE = 1
            If txtcuenta_pesos.Tag <> "" Then intCuentaEje = True
            If txtFechaCtaEje.Tag <> "" Then intFechaCtaEje = True
        End If

        'Direccion
        If txtCalle.Tag <> "" Or txtNoExt.Tag <> "" Or txtNoInt.Tag <> "" Or txtComponente.Tag <> "" Or
           txtColonia.Tag <> "" Or txtDelMunicipio.Tag <> "" Or cmbUbicacion.Tag <> "" Or txtCP.Tag <> "" Then
            If strMensaje <> "" Then
                strMensaje = strMensaje & vbCrLf & "Datos de Dirección" & vbCrLf & "--------------------------------------" & vbCrLf
            Else
                strMensaje = "Datos de Dirección" & vbCrLf & "--------------------------------------" & vbCrLf
            End If

            intMantenimientoD = 2
            If txtCalle.Tag <> "" Then
                strMensaje = strMensaje & "Direccion: Calle" & vbCrLf
                intMnntoDR_CA = True
            End If
            If txtNoExt.Tag <> "" Then
                strMensaje = strMensaje & "Direccion: No Exterior" & vbCrLf
                intMnntoDR_NE = True
            End If
            If txtNoInt.Tag <> "" Then
                strMensaje = strMensaje & "Direccion: No Interior" & vbCrLf
                intMnntoDR_NI = True
            End If
            If txtComponente.Tag <> "" Then
                strMensaje = strMensaje & "Direccion: Componente" & vbCrLf
                intMnntoDR_CO = True
            End If
            If txtColonia.Tag <> "" Then
                strMensaje = strMensaje & "Direccion: Colonia" & vbCrLf
                intMnntoDR_CL = True
            End If
            If txtDelMunicipio.Tag <> "" Then
                strMensaje = strMensaje & "Direccion envio: Delegación/Municipio" & vbCrLf
                intMnntoDR_DM = True
            End If
            If cmbUbicacion.Tag <> "" Then
                strMensaje = strMensaje & "Dirección: Ubicación" & vbCrLf
                intMnntoDR_CE = True
            End If
            If txtCP.Tag <> "" Then
                strMensaje = strMensaje & "Dirección: C.P." & vbCrLf
                intMnntoDR_CP = True
            End If

        End If

        'Direccion Envio
        If txtCalleEnvio.Tag <> "" Or txtNoExtEnvio.Tag <> "" Or txtNoIntEnvio.Tag <> "" Or txtComponenteEnvio.Tag <> "" Or
           txtColoniaEnvio.Tag <> "" Or txtDelMunicipioE.Tag <> "" Or cmbUbicacionEnvio.Tag <> "" Or txtCPEnvio.Tag <> "" Then
            If strMensaje <> "" Then
                strMensaje = strMensaje & vbCrLf & "Datos de Dirección Envio" & vbCrLf & "--------------------------------------" & vbCrLf
            Else
                strMensaje = "Datos de Dirección Envio" & vbCrLf & "--------------------------------------" & vbCrLf
            End If

            intMantenimientoDE = 3
            If txtCalleEnvio.Tag <> "" Then
                strMensaje = strMensaje & "Direccion envio: Calle" & vbCrLf
                intMnntoDE_CA = True
            End If
            If txtNoExtEnvio.Tag <> "" Then
                strMensaje = strMensaje & "Direccion envio: No Exterior" & vbCrLf
                intMnntoDE_NE = True
            End If
            If txtNoIntEnvio.Tag <> "" Then
                strMensaje = strMensaje & "Direccion envio: No Interior" & vbCrLf
                intMnntoDE_NI = True
            End If
            If txtComponenteEnvio.Tag <> "" Then
                strMensaje = strMensaje & "Direccion envio: Componente" & vbCrLf
                intMnntoDE_CO = True
            End If
            If txtColoniaEnvio.Tag <> "" Then
                strMensaje = strMensaje & "Direccion envio: Colonia" & vbCrLf
                intMnntoDE_CL = True
            End If
            If txtDelMunicipioE.Tag <> "" Then
                strMensaje = strMensaje & "Direccion envio: Delegación/Municipio" & vbCrLf
                intMnntoDE_DM = True
            End If
            If cmbUbicacionEnvio.Tag <> "" Then
                strMensaje = strMensaje & "Dirección envio: Ubicación" & vbCrLf
                intMnntoDE_CE = True
            End If
            If txtCPEnvio.Tag <> "" Then
                strMensaje = strMensaje & "Dirección envio: C.P." & vbCrLf
                intMnntoDE_CP = True
            End If
        End If

        'If strMensaje = "" Then
        If intMantenimientoCE = 0 And intMantenimientoD = 0 And intMantenimientoDE = 0 And intMantenimientoDCN = 0 And
           intMantenimientoDCT = 0 And intMantenimientoRFC = 0 And intMantenimientoGP = 0 Then
            'Significa que se no se afecto ninguna de los campos para manteniento
            ValidarEjecucion = "0"
        Else
            'strMensaje = "Aviso: Se han encontrado modificaciones en:" & vbCrLf & vbCrLf & strMensaje & vbCrLf
            'strMensaje = strMensaje & "--------------------------------------"
            'strMensaje = strMensaje & vbCrLf & "¿DESEA CONTINUAR? YES/NO?"
            If MsgBox(strMensaje, vbDefaultButton1 + vbYesNo, "Mantenimiento") = vbYes Then
                'Significa que se haga el mantenimiento
                ValidarEjecucion = "1" &
                                intMantenimientoCE & "," &       '--1 
                                intMantenimientoD & "," &        '--2 
                                intMantenimientoDE & "," &       '--3 
                                intMantenimientoDCN & "," &      '--10 
                                intMantenimientoDCT & "," &      '--11 
                                intMantenimientoRFC              '--12 
                '                   & "," & _
                'intMantenimientoGP
            Else
                'Significa que se no haga el mantenimiento
                ValidarEjecucion = "2"
                '    Screen.MousePointer = vbDefault
            End If
        End If

Salida:
    End Function

    Private Sub graba_Detalle_Mnnto(ByVal Opcion As Integer)
        Dim gs_sql_det0 As String
        Dim gs_sql_det1 As String
        Dim gs_sql_det2 As String
        Dim gs_sql_det3 As String
        Dim d As New Datasource
        Dim dtDatos As DataTable
        Dim Respuesta As Integer
        Dim sRespuesta As String

        gs_sql_det1 = "Insert into MANTENIMIENTO_CUENTA " &
                      " (producto_contratado, tipo_mantenimiento, fecha_mantenimiento, fecha_operacion, status_mantenimiento, usuario) " &
                      " VALUES (" & mnProdCon & ","
        gs_sql_det2 = ""
        gs_sql_det3 = "getdate(),'" & d.InvierteFecha_yyymmdd(lsFechaOriginal) & "',4," & usuario & ")"

        If Opcion = 2 Then
            'inserta registros si el boleano esta activo
            If intMnntoDR_CA Then
                gs_sql_det2 = " 21 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
            If intMnntoDR_NE Then
                gs_sql_det2 = " 22 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
            If intMnntoDR_NI Then
                gs_sql_det2 = " 23 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
            If intMnntoDR_CO Then
                gs_sql_det2 = " 24 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
            If intMnntoDR_CL Then
                gs_sql_det2 = " 25 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
            If intMnntoDR_DM Then
                gs_sql_det2 = " 26 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
            If intMnntoDR_CE Then
                gs_sql_det2 = " 27 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
            If intMnntoDR_CP Then
                gs_sql_det2 = " 28 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
        ElseIf Opcion = 3 Then
            If intMnntoDE_CA Then
                gs_sql_det2 = " 31 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
            If intMnntoDE_NE Then
                gs_sql_det2 = " 32 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
            If intMnntoDE_NI Then
                gs_sql_det2 = " 33 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
            If intMnntoDE_CO Then
                gs_sql_det2 = " 34 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
            If intMnntoDE_CL Then
                gs_sql_det2 = " 35 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
            If intMnntoDE_DM Then
                gs_sql_det2 = "36 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
            If intMnntoDE_CE Then
                gs_sql_det2 = "37 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
            If intMnntoDE_CP Then
                gs_sql_det2 = "38 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
        ElseIf Opcion = 10 Then
            If intMnntoNC_N Then
                gs_sql_det2 = "41 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
            If intMnntoNC_AP Then
                gs_sql_det2 = "42 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
            If intMnntoNC_AM Then
                gs_sql_det2 = "43 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
        ElseIf Opcion = 11 Then
            If intMnntoGestor Then
                gs_sql_det2 = "61 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
            If intMnntoTelef Then
                gs_sql_det2 = "62 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
            If intMnntoFax Then
                gs_sql_det2 = "63 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
        ElseIf Opcion = 1 Then
            If intCuentaEje Then
                gs_sql_det2 = "71 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
            If intFechaCtaEje Then
                gs_sql_det2 = "72 ,"
                gs_sql_det0 = gs_sql_det1 & gs_sql_det2 & gs_sql_det3
                Respuesta = d.InsQuery(gs_sql_det0)
                If Respuesta <= 0 Then
                    GoTo ErrorTranDetalle
                End If
            End If
        Else
            GoTo ErrorTranDetalle
        End If

        Exit Sub
ErrorTranDetalle:
        Cursor = System.Windows.Forms.Cursors.Default
        MsgBox("Ha ocurrido un error al intentar insertar detalle de mantenimiento..", vbOKOnly, "SQL Server Error")
        Cursor = System.Windows.Forms.Cursors.Default
        Resume Next
    End Sub

    Private Sub cmdGuardar_LostFocus(sender As Object, e As EventArgs) Handles cmdGuardar.LostFocus
        selec = False
    End Sub

    Private Sub cmdGuardar_GotFocus(sender As Object, e As EventArgs) Handles cmdGuardar.GotFocus
        selec = True
    End Sub

    Private Sub txtCalle_TextChanged(sender As Object, e As EventArgs) Handles txtCalle.TextChanged
        txtCalle.Tag = "1"
    End Sub

    Private Sub txtNoExt_TextChanged(sender As Object, e As EventArgs) Handles txtNoExt.TextChanged
        txtNoExt.Tag = "1"
    End Sub

    Private Sub txtNoInt_TextChanged(sender As Object, e As EventArgs) Handles txtNoInt.TextChanged
        txtNoInt.Tag = "1"
    End Sub

    Private Sub txtCP_TextChanged(sender As Object, e As EventArgs) Handles txtCP.TextChanged
        txtCP.Tag = "1"
    End Sub

    Private Sub txtComponente_TextChanged(sender As Object, e As EventArgs) Handles txtComponente.TextChanged
        txtComponente.Tag = "1"
    End Sub

    Private Sub txtColonia_TextChanged(sender As Object, e As EventArgs) Handles txtColonia.TextChanged
        txtColonia.Tag = "1"
    End Sub

    Private Sub txtDelMunicipio_TextChanged(sender As Object, e As EventArgs) Handles txtDelMunicipio.TextChanged
        If Not bCargaDatosenCurso Then
            txtDelMunicipio.Tag = "1"
        End If
    End Sub

    Private Sub cmbUbicacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUbicacion.SelectedIndexChanged
        cmbUbicacion.Tag = "1"
    End Sub

    Private Sub txtCalleEnvio_TextChanged(sender As Object, e As EventArgs) Handles txtCalleEnvio.TextChanged
        txtCalleEnvio.Tag = "1"
    End Sub

    Private Sub txtNoExtEnvio_TextChanged(sender As Object, e As EventArgs) Handles txtNoExtEnvio.TextChanged
        txtNoExtEnvio.Tag = "1"
    End Sub

    Private Sub txtNoIntEnvio_TextChanged(sender As Object, e As EventArgs) Handles txtNoIntEnvio.TextChanged
        txtNoIntEnvio.Tag = "1"
    End Sub

    Private Sub txtCPEnvio_TextChanged(sender As Object, e As EventArgs) Handles txtCPEnvio.TextChanged
        txtCPEnvio.Tag = "1"
    End Sub

    Private Sub txtComponenteEnvio_TextChanged(sender As Object, e As EventArgs) Handles txtComponenteEnvio.TextChanged
        txtComponenteEnvio.Tag = "1"
    End Sub

    Private Sub txtColoniaEnvio_TextChanged(sender As Object, e As EventArgs) Handles txtColoniaEnvio.TextChanged
        txtColoniaEnvio.Tag = "1"
    End Sub

    Private Sub txtDelMunicipioE_TextChanged(sender As Object, e As EventArgs) Handles txtDelMunicipioE.TextChanged
        If Not bCargaDatosenCurso Then
            txtDelMunicipioE.Tag = "1"
        End If
    End Sub

    Private Sub cmbUbicacionEnvio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUbicacionEnvio.SelectedIndexChanged
        cmbUbicacionEnvio.Tag = "1"
    End Sub

    Private Sub cmbUbicacion_DropDown(sender As Object, e As EventArgs) Handles cmbUbicacion.DropDown
        Dim d As New DataSourceMannto
        Dim dtDatos As DataTable
        Dim renglones As Integer
        Dim iTabla As Integer = 3    'tabla de ubicacion
        Dim renglon As Integer = 0

        'Llena los combos de Ubicacion
        dtDatos = d.LLenacombos(iTabla)
        renglones = dtDatos.Rows.Count

        If (dtDatos.Rows.Count > 0) Then
            cmbUbicacion.Items.Clear()   'inicializa control
            cmbUbicacion.Items.Insert(0, "Seleccionar...")   'agrega iem a control de inicio
            For Each row As DataRow In dtDatos.Rows
                msUbicacion = dtDatos.Rows(renglon).Item(1)
                mnUbicacion = dtDatos.Rows(renglon).Item(0)
                'CmbTipoCliente.Items.Add(New CBBItem(dtDatos.Rows(renglon).Item(0), dtDatos.Rows(renglon).Item(1)))
                cmbUbicacion.Items.Add(New CBBItem(dtDatos.Rows(renglon).Item(1), dtDatos.Rows(renglon).Item(0)))

                'cmbUbicacion.Items.Insert(CInt(row.Item("ubicacion")), row.Item("dsc_ubicacion"))
                'cmbUbicacion.Items.Insert(CInt(row.Item("ubicacion")), row.Item("dsc_ubicacion"))

                renglon = renglon + 1
            Next
        Else
            MsgBox("NO se obtuvieron valores en la consulta.", vbInformation, "LLenaCombos")
        End If

    End Sub
    '----------------------------------------------- RACB 21-10-2021
    Private Sub cmbUbicacionEnvio_DropDown(sender As Object, e As EventArgs) Handles cmbUbicacionEnvio.DropDown
        Dim d As New DataSourceMannto
        Dim dtDatos As DataTable
        Dim renglones As Integer
        Dim iTabla As Integer = 4    'tabla de ubicacion
        Dim renglon As Integer = 0

        'Llena los combos de Ubicacion
        dtDatos = d.LLenacombos(iTabla)
        renglones = dtDatos.Rows.Count

        If (dtDatos.Rows.Count > 0) Then
            cmbUbicacionEnvio.Items.Clear()   'inicializa control
            cmbUbicacionEnvio.Items.Insert(0, "Seleccionar...")   'agrega iem a control de inicio
            For Each row As DataRow In dtDatos.Rows
                msUbicacionEnvio = dtDatos.Rows(renglon).Item(1)
                mnUbicaEnvio = dtDatos.Rows(renglon).Item(0)
                'CmbTipoCliente.Items.Add(New CBBItem(dtDatos.Rows(renglon).Item(0), dtDatos.Rows(renglon).Item(1)))
                cmbUbicacionEnvio.Items.Add(New CBBItem(dtDatos.Rows(renglon).Item(1), dtDatos.Rows(renglon).Item(0)))

                'cmbUbicacion.Items.Insert(CInt(row.Item("ubicacion")), row.Item("dsc_ubicacion"))
                'cmbUbicacion.Items.Insert(CInt(row.Item("ubicacion")), row.Item("dsc_ubicacion"))

                renglon = renglon + 1
            Next
        Else
            MsgBox("NO se obtuvieron valores en la consulta.", vbInformation, "LLenaCombos")
        End If
    End Sub
    Private Sub cmbUbicacionEnvio_LostFocus(sender As Object, e As EventArgs) Handles cmbUbicacionEnvio.LostFocus
        Dim d As New Datasource
        Dim dtDatos As DataTable
        'Dim Respuesta As Integer

        msUbicacionEnvio = cmbUbicacionEnvio.Text
        If cmbUbicacionEnvio.Text = "" Then
            dtDatos = d.ConsultaUbicacion(gs_Sql)
            If dtDatos.Rows.Count > 0 Then
                msUbicacionEnvio = dtDatos.Rows(0).Item(0).ToString.Trim
            End If
        End If
    End Sub
    '----------------------------------------------- RACB 21-10-2021
    Private Sub cmbUbicacion_LostFocus(sender As Object, e As EventArgs) Handles cmbUbicacion.LostFocus
        Dim d As New Datasource
        Dim dtDatos As DataTable
        'Dim Respuesta As Integer

        msUbicacion = cmbUbicacion.Text
        If cmbUbicacion.Text = "" Then
            dtDatos = d.ConsultaUbicacion(gs_Sql)
            If dtDatos.Rows.Count > 0 Then
                msUbicacion = dtDatos.Rows(0).Item(0).ToString.Trim
            End If
        End If
    End Sub

    Private Sub cmbUbicacion_Click(sender As Object, e As EventArgs) Handles cmbUbicacion.Click
        'Dim o As Object = cmbUbicacion.SelectedItem
        'Dim dsc As String

        'If cmbUbicacion.SelectedIndex > -1 Then
        '    'mnUbicacion = cmbUbicacion.SelectedItem
        '    cmbUbicacion.Tag = "1"
        '    If TypeOf o Is CBBItem Then
        '        Dim cmbi As CBBItem
        '        cmbi = CType(o, CBBItem)
        '        dsc = cmbi.Contenido
        '        'mnTipoCliente = cmbi.Valor
        '        mnUbicacion = cmbi.Valor
        '    Else
        '        dsc = cmbUbicacion.SelectedItem.ToString
        '    End If
        'End If
    End Sub

    Private Sub cmbUbicacion_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbUbicacion.SelectionChangeCommitted
        Dim o As Object = cmbUbicacion.SelectedItem
        Dim dsc As String

        If cmbUbicacion.SelectedIndex > -1 Then
            'mnUbicacion = cmbUbicacion.SelectedItem
            cmbUbicacion.Tag = "1"
            If TypeOf o Is CBBItem Then
                Dim cmbi As CBBItem
                cmbi = CType(o, CBBItem)
                dsc = cmbi.Contenido
                'mnTipoCliente = cmbi.Valor
                mnUbicacion = cmbi.Valor
            Else
                dsc = cmbUbicacion.SelectedItem.ToString
            End If
        End If
    End Sub
    '----------------------------------------------- RACB 21-10-2021
    Private Sub cmbUbicacionEnvio_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbUbicacionEnvio.SelectionChangeCommitted
        Dim o As Object = cmbUbicacionEnvio.SelectedItem
        Dim dsc As String

        If cmbUbicacionEnvio.SelectedIndex > -1 Then
            'mnUbicacion = cmbUbicacionEnvio.SelectedItem
            cmbUbicacionEnvio.Tag = "1"
            If TypeOf o Is CBBItem Then
                Dim cmbi As CBBItem
                cmbi = CType(o, CBBItem)
                dsc = cmbi.Contenido
                'mnTipoCliente = cmbi.Valor
                mnUbicaEnvio = cmbi.Valor
            Else
                dsc = cmbUbicacionEnvio.SelectedItem.ToString
            End If
        End If
    End Sub
    '----------------------------------------------- RACB 21-10-2021
    Private Sub cmdAutorizado_Click(sender As Object, e As EventArgs) Handles cmdAutorizado.Click
        Try
            Dim fCapAutorizados As New CapAutorizados()
            CuentaCompApertura = ""
            CuentaCompApertura = txtCuenta.Text       'Variable global, que se maneja en el formulario

            If IsNothing(CuentaCompApertura) Then
                MsgBox("Debe seleccionar una cuenta.", vbInformation, "Mantenimiento Participes")
                Exit Sub
            End If

            fCapAutorizados.ShowDialog()
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en btAutorizados_Click: " & ex.Message, vbInformation, "Mantenimiento Participes")
            Exit Sub
        End Try
    End Sub

    Private Sub cmdCotitulares_Click(sender As Object, e As EventArgs) Handles cmdCotitulares.Click
        Try
            Dim fCapCotitulares As New CapCotitulares()
            CuentaCompApertura = ""
            CuentaCompApertura = txtCuenta.Text       'Variable global, que se maneja en el formulario

            If IsNothing(CuentaCompApertura) Then
                MsgBox("Debe seleccionar una cuenta.", vbInformation, "Mantenimiento Participes")
                Exit Sub
            End If

            fCapCotitulares.ShowDialog()
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en btAutorizados_Click: " & ex.Message, vbInformation, "Mantenimiento Participes")
            Exit Sub
        End Try
    End Sub

    Private Sub cmdBeneficiarios_Click(sender As Object, e As EventArgs) Handles cmdBeneficiarios.Click
        Try
            CuentaCompApertura = txtCuenta.Text

            If IsNothing(CuentaCompApertura) Then
                MsgBox("Debe seleccionar una cuenta.", vbInformation, "Mantenimiento Participes")
                Exit Sub
            End If

            If UCase(cmdBeneficiarios.Text) = "&BENEFICIARIOS" Or UCase(cmdBeneficiarios.Text) = "BENEFICIARIOS" Then     'PERSONA MORAL
                'BeneficiarioS
                Dim fCapBeneficiarios As New CapBeneficiarios()
                fCapBeneficiarios.ShowDialog()

            Else                                                    'PERSONA FISICA
                'ApoderadoS
                Dim fCapApoderados As New CapApoderados()
                fCapApoderados.ShowDialog()

            End If

        Catch ex As Exception
            If UCase(cmdBeneficiarios.Text) = "APODERADOS" Then
                MsgBox("Ha ocurrido un error en cmdApoderados_Click: " & ex.Message, vbInformation, "Mantenimiento Participes")
            Else
                MsgBox("Ha ocurrido un error en cmdBeneficiarios_Click:  " & ex.Message, vbInformation, "Mantenimiento Participes")
                Exit Sub
            End If
        End Try

    End Sub
End Class



Class CBBItem
    Public Contenido As String
    Public Valor As Integer
    '
    Public Sub New(ByVal c As String, ByVal v As Integer)
        Contenido = c
        Valor = v
    End Sub
    '
    Public Overrides Function ToString() As String
        Return Contenido
    End Function
End Class