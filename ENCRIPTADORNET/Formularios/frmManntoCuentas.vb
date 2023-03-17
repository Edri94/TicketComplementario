Imports System.Globalization
Imports System.Threading

Public Class frmManntoCuentas
    Dim TipoMannto As String = ""
    Dim sTipoMannto As String = "1"
    Dim iCultura As Integer = 0

    Private Sub frmManntoCuentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim d As New Datasource
        Dim dtTipoMannto As DataTable
        Dim sSql As String
        '------------------------------RACB 14/04/2021
        Dim culture As String = ""

        If Thread.CurrentThread.CurrentCulture.Name = "en-US" Then
            culture = "en-US"
            lblFecha.Text = "(mm-dd-aaaa)"
            lblRango.Text = "(mm-dd-aaaa)"
            iCultura = 1
        ElseIf Thread.CurrentThread.CurrentCulture.Name = "es-MX" Then
            culture = "es-MX"
            lblFecha.Text = "(dd-mm-aaaa)"
            lblRango.Text = "(dd-mm-aaaa)"
            iCultura = 2
        End If
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture)
        '------------------------------RACB 14/04/2021

        sSql = " select tipo_mantenimiento, descripcion " &
                " from TICKET..TIPO_MANTENIMIENTO_CUENTA " &
                " where tipo_mantenimiento in (1,10,11,12,2,3,4,5) " &
                " order by tipo_mantenimiento"
        'Llena combo Tipo de Mantenimiento
        dtTipoMannto = d.Consulta(sSql, "TipoMantenimiento")

        cmbTipoMannto.Visible = True
        cmbTipoMannto.DisplayMember = "descripcion"
        cmbTipoMannto.ValueMember = "tipo_mantenimiento"
        cmbTipoMannto.DataSource = dtTipoMannto

        ApagaControles()

        Me.CenterToScreen()
    End Sub

    Private Sub chkFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkFecha.CheckedChanged
        If chkFecha.Checked = True Then
            txtFecha.Visible = True
            lblFecha.Visible = True
            txtFecha.Enabled = True
            txtFecha.Focus()
            'txtFecha.Text = Date.Now().Date.ToString("dd-MM-yyyy")

            chkRango.Checked = False
        Else
            txtFecha.Visible = False
            lblFecha.Visible = False
            txtFecha.Enabled = False
            txtFecha.Text = ""
        End If
        If cmdImprimir.Enabled = True Then
            cmdImprimir.Enabled = False
        End If
    End Sub

    Private Sub chkRango_CheckedChanged(sender As Object, e As EventArgs) Handles chkRango.CheckedChanged
        If chkRango.Checked = True Then
            txtFechaIni.Visible = True
            txtFechaFin.Visible = True
            lblRango.Visible = True
            txtFechaIni.Enabled = True
            txtFechaFin.Enabled = True
            txtFechaIni.Text = ""
            txtFechaFin.Text = ""
            txtFechaIni.Focus()
            If iCultura = 2 Then
                txtFechaIni.Text = Date.Now().Date.ToString("dd-MM-yyyy")
                txtFechaFin.Text = Date.Now().Date.ToString("dd-MM-yyyy")
            ElseIf iCultura = 1 Then
                txtFechaIni.Text = Date.Now().Date.ToString("MM-dd-yyyy")
                txtFechaFin.Text = Date.Now().Date.ToString("MM-dd-yyyy")
            End If


            chkFecha.Checked = False
            Else
                txtFechaIni.Visible = False
            txtFechaFin.Visible = False
            lblRango.Visible = False
            txtFechaIni.Enabled = False
            txtFechaFin.Enabled = False
            txtFechaIni.Text = ""
            txtFechaFin.Text = ""
        End If
        If cmdImprimir.Enabled = True Then
            cmdImprimir.Enabled = False
        End If
    End Sub

    Private Sub chkCuenta_CheckedChanged(sender As Object, e As EventArgs) Handles chkCuenta.CheckedChanged
        If chkCuenta.Checked = True Then
            txtCuenta.Visible = True
            txtCuenta.Enabled = True
            txtCuenta.Text = ""
            txtCuenta.Focus()
        Else
            txtCuenta.Visible = False
            txtCuenta.Enabled = False
            txtCuenta.Text = ""
        End If
        If cmdImprimir.Enabled = True Then
            cmdImprimir.Enabled = False
        End If
    End Sub

    Private Sub chkTipo_CheckedChanged(sender As Object, e As EventArgs) Handles chkTipo.CheckedChanged
        If chkTipo.Checked = True Then
            cmbTipoMannto.Enabled = True
            cmbTipoMannto.Visible = True
        Else
            cmbTipoMannto.Enabled = False
            cmbTipoMannto.Visible = False
        End If
        If cmdImprimir.Enabled = True Then
            cmdImprimir.Enabled = False
        End If
    End Sub

    Private Sub cmdBuscar_Click(sender As Object, e As EventArgs) Handles cmdBuscar.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        'Valida los datos proporcionados por el usuario
        If Not ChecaDatos() Then
            Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
        If LlenaMantenimientos() Then
            cmdImprimir.Enabled = True
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub


    Private Function LlenaMantenimientos() As Boolean
        Dim d As New Datasource
        'Dim dtManntocta As DataTable
        Dim sSqlQuery As String
        Dim sSql As String
        Dim sSqlCount As String
        Dim sSqlSelect As String
        Dim sWhere As String
        Dim bActivo As Boolean

        Dim strTipoMannto As String
        Dim strTipoManntoCR As String
        Dim intTipoMannto As Integer

        Dim iRegistros As Integer

        LlenaMantenimientos = False
        bActivo = False

        ls_PorImprimir = ""
        sWhere = ""
        iRegistros = 0
        dgvManntoCuentas.DataSource = ""

        sSqlCount = "Select count(*) "
        sSqlSelect = " Select vw_mant_cta.PREFIJO_AGENCIA, vw_mant_cta.CUENTA_CLIENTE, vw_mant_cta.SUFIJO_KAPITI, "
        sSqlSelect &= " vw_mant_cta.NOMBRE_CLIENTE, vw_mant_cta.TIPO_MANTENIMIENTO_DESC, vw_mant_cta.STATUS, "
        sSqlSelect &= " vw_mant_cta.FECHA_OPERACION, vw_mant_cta.FECHA_MANTENIMIENTO, vw_mant_cta.GESTOR, vw_mant_cta.CR "
        sSql = " From TICKET.dbo.vw_mant_cta vw_mant_cta "

        If chkCuenta.Checked = True Then
            bActivo = True
            sWhere = " Where vw_mant_cta.CUENTA_CLIENTE = '" & txtCuenta.Text & "' "
            ls_PorImprimir = " {vw_mant_cta.CUENTA_CLIENTE} = '" & txtCuenta.Text & "' "
        End If
        'Format(CDate(txtCuenta.Text), "yyyy-MM-dd")
        If chkFecha.Checked = True Then
            If bActivo Then
                'sWhere &= " and vw_mant_cta.FECHA_OPERACION = '" & txtFecha.Text.Substring(6, 4) & "-" & txtFecha.Text.Substring(3, 2) & "-" & txtFecha.Text.Substring(0, 2) & "'"
                'ls_PorImprimir &= " and {vw_mant_cta.FECHA_OPERACION} = Date(" & txtFecha.Text.Substring(6, 4) & "," & txtFecha.Text.Substring(3, 2) & "," & txtFecha.Text.Substring(0, 2) & ")"
                sWhere &= " and vw_mant_cta.FECHA_OPERACION = '" & CDate(txtFecha.Text).Year & "-" & CDate(txtFecha.Text).Month & "-" & CDate(txtFecha.Text).Day & "'" '------- RACB 14/04/2021
                ls_PorImprimir &= " and {vw_mant_cta.FECHA_OPERACION} = Date(" & CDate(txtFecha.Text).Year & "," & CDate(txtFecha.Text).Month & "," & CDate(txtFecha.Text).Day & ")" '------- RACB 14/04/2021
            Else
                'sWhere &= " Where vw_mant_cta.FECHA_OPERACION = '" & txtFecha.Text.Substring(6, 4) & "-" & txtFecha.Text.Substring(3, 2) & "-" & txtFecha.Text.Substring(0, 2) & "'"
                'ls_PorImprimir = " {vw_mant_cta.FECHA_OPERACION} = Date(" & txtFecha.Text.Substring(6, 4) & "," & txtFecha.Text.Substring(3, 2) & "," & txtFecha.Text.Substring(0, 2) & ")"
                sWhere &= " Where vw_mant_cta.FECHA_OPERACION = '" & CDate(txtFecha.Text).Year & "-" & CDate(txtFecha.Text).Month & "-" & CDate(txtFecha.Text).Day & "'" '------- RACB 14/04/2021
                ls_PorImprimir = " {vw_mant_cta.FECHA_OPERACION} = Date(" & CDate(txtFecha.Text).Year & "," & CDate(txtFecha.Text).Month & "," & CDate(txtFecha.Text).Day & ")" '------- RACB 14/04/2021
                bActivo = True
            End If
        End If

        If chkRango.Checked = True Then
            If bActivo Then
                'sWhere &= " and vw_mant_cta.FECHA_MANTENIMIENTO >= '" & txtFechaIni.Text.Substring(6, 4) & "-" & txtFechaIni.Text.Substring(3, 2) & "-" & txtFechaIni.Text.Substring(0, 2) & "'"
                'sWhere &= " and vw_mant_cta.FECHA_MANTENIMIENTO <= '" & txtFechaFin.Text.Substring(6, 4) & "-" & txtFechaFin.Text.Substring(3, 2) & "-" & txtFechaFin.Text.Substring(0, 2) & "'"
                'ls_PorImprimir &= " and {vw_mant_cta.FECHA_MANTENIMIENTO} >= Date(" & txtFechaIni.Text.Substring(6, 4) & "," & txtFechaIni.Text.Substring(3, 2) & "," & txtFechaIni.Text.Substring(0, 2) & ")"
                'ls_PorImprimir &= " and {vw_mant_cta.FECHA_MANTENIMIENTO} <= Date(" & txtFechaFin.Text.Substring(6, 4) & "," & txtFechaFin.Text.Substring(3, 2) & "," & txtFechaFin.Text.Substring(0, 2) & ")"
                sWhere &= " and vw_mant_cta.FECHA_MANTENIMIENTO >= '" & CDate(txtFechaIni.Text).Year & "-" & CDate(txtFechaIni.Text).Month & "-" & CDate(txtFechaIni.Text).Day & "'" '------- RACB 14/04/2021
                sWhere &= " and vw_mant_cta.FECHA_MANTENIMIENTO <= '" & CDate(txtFechaFin.Text).Year & "-" & CDate(txtFechaFin.Text).Month & "-" & CDate(txtFechaFin.Text).Day & "'" '------- RACB 14/04/2021
                ls_PorImprimir &= " and {vw_mant_cta.FECHA_MANTENIMIENTO} >= Date(" & CDate(txtFechaIni.Text).Year & "," & CDate(txtFechaIni.Text).Month & "," & CDate(txtFechaIni.Text).Day & ")" '------- RACB 14/04/2021
                ls_PorImprimir &= " and {vw_mant_cta.FECHA_MANTENIMIENTO} <= Date(" & CDate(txtFechaFin.Text).Year & "," & CDate(txtFechaFin.Text).Month & "," & CDate(txtFechaFin.Text).Day & ")" '------- RACB 14/04/2021
            Else
                'sWhere &= " Where vw_mant_cta.FECHA_MANTENIMIENTO >= '" & txtFechaIni.Text.Substring(6, 4) & "-" & txtFechaIni.Text.Substring(3, 2) & "-" & txtFechaIni.Text.Substring(0, 2) & "'"
                'sWhere &= " and vw_mant_cta.FECHA_MANTENIMIENTO <= '" & txtFechaFin.Text.Substring(6, 4) & "-" & txtFechaFin.Text.Substring(3, 2) & "-" & txtFechaFin.Text.Substring(0, 2) & "'"
                'ls_PorImprimir &= " {vw_mant_cta.FECHA_MANTENIMIENTO} >= Date(" & txtFechaIni.Text.Substring(6, 4) & "," & txtFechaIni.Text.Substring(3, 2) & "," & txtFechaIni.Text.Substring(0, 2) & ")"
                'ls_PorImprimir &= " and {vw_mant_cta.FECHA_MANTENIMIENTO} <= Date(" & txtFechaFin.Text.Substring(6, 4) & "," & txtFechaFin.Text.Substring(3, 2) & "," & txtFechaFin.Text.Substring(0, 2) & ")"
                sWhere &= " Where vw_mant_cta.FECHA_MANTENIMIENTO >= '" & CDate(txtFechaIni.Text).Year & "-" & CDate(txtFechaIni.Text).Month & "-" & CDate(txtFechaIni.Text).Day & "'" '------- RACB 14/04/2021
                sWhere &= " and vw_mant_cta.FECHA_MANTENIMIENTO <= '" & CDate(txtFechaFin.Text).Year & "-" & CDate(txtFechaFin.Text).Month & "-" & CDate(txtFechaFin.Text).Day & "'" '------- RACB 14/04/2021
                ls_PorImprimir &= " {vw_mant_cta.FECHA_MANTENIMIENTO} >= Date(" & CDate(txtFechaIni.Text).Year & "," & CDate(txtFechaIni.Text).Month & "," & CDate(txtFechaIni.Text).Day & ")" '------- RACB 14/04/2021
                ls_PorImprimir &= " and {vw_mant_cta.FECHA_MANTENIMIENTO} <= Date(" & CDate(txtFechaFin.Text).Year & "," & CDate(txtFechaFin.Text).Month & "," & CDate(txtFechaFin.Text).Day & ")" '------- RACB 14/04/2021
                bActivo = True
            End If
        End If

        If chkTipo.Checked = True Then
            intTipoMannto = cmbTipoMannto.SelectedValue
            'intTipoMannto = cmbTipoMannto.ItemData(cmbTipoMannto.ListIndex)

            If intTipoMannto = 1 Then
                strTipoMannto = " = 1 "
                strTipoManntoCR = " = '1' "
            ElseIf intTipoMannto = 10 Then
                strTipoMannto = " in (41,42,43) "
                strTipoManntoCR = " in ['41', '42', '43'] "
                'strTipoManntoCR = " =41 or {vw_mant_cta.TIPO_MANTENIMIENTO}=42 or {vw_mant_cta.TIPO_MANTENIMIENTO}=43 ) "
            ElseIf intTipoMannto = 11 Then
                strTipoMannto = " in (61, 63) "
                strTipoManntoCR = " in ['61', '63'] "
                'strTipoManntoCR = " =61 or {vw_mant_cta.TIPO_MANTENIMIENTO}=62 or {vw_mant_cta.TIPO_MANTENIMIENTO}=63 ) "
            ElseIf intTipoMannto = 12 Then
                strTipoMannto = " = 12 "
                strTipoManntoCR = " = '12' "
            ElseIf intTipoMannto = 2 Then
                strTipoMannto = " in (21, 22, 23, 24, 25, 26, 27, 28) "
                strTipoManntoCR = " in ['21', '22', '23', '24', '25', '26', '27', '28'] "
                'strTipoManntoCR = " =21 or {vw_mant_cta.TIPO_MANTENIMIENTO}=22 or {vw_mant_cta.TIPO_MANTENIMIENTO}=23 or {vw_mant_cta.TIPO_MANTENIMIENTO}=24 or {vw_mant_cta.TIPO_MANTENIMIENTO}=25 or {vw_mant_cta.TIPO_MANTENIMIENTO}=26 or {vw_mant_cta.TIPO_MANTENIMIENTO}=27 or {vw_mant_cta.TIPO_MANTENIMIENTO}=28 ) "
            ElseIf intTipoMannto = 3 Then
                strTipoMannto = " in (31, 32, 33, 34, 35, 36, 37, 38) "
                strTipoManntoCR = " in ['31', '32', '33', '34', '35', '36', '37', '38'] "
                'strTipoManntoCR = " =31 or {vw_mant_cta.TIPO_MANTENIMIENTO}=32 or {vw_mant_cta.TIPO_MANTENIMIENTO}=33 or {vw_mant_cta.TIPO_MANTENIMIENTO}=34 or {vw_mant_cta.TIPO_MANTENIMIENTO}=35 or {vw_mant_cta.TIPO_MANTENIMIENTO}=36 or {vw_mant_cta.TIPO_MANTENIMIENTO}=37 or {vw_mant_cta.TIPO_MANTENIMIENTO}=38 ) "
            ElseIf intTipoMannto = 4 Then
                strTipoMannto = " = 4 "
                strTipoManntoCR = " = '4' "
            ElseIf intTipoMannto = 5 Then
                strTipoMannto = " in (50, 51, 52, 53, 54, 55, 56, 57, 58) "
                strTipoManntoCR = " in ['50', '51', '52', '53', '54', '55', '56', '57', '58'] "
                'strTipoManntoCR = " ='50' or {vw_mant_cta.TIPO_MANTENIMIENTO}='51' or {vw_mant_cta.TIPO_MANTENIMIENTO}='52' or {vw_mant_cta.TIPO_MANTENIMIENTO}='53' or {vw_mant_cta.TIPO_MANTENIMIENTO}='54' or {vw_mant_cta.TIPO_MANTENIMIENTO}='55' or {vw_mant_cta.TIPO_MANTENIMIENTO}='56' or {vw_mant_cta.TIPO_MANTENIMIENTO}='57' or {vw_mant_cta.TIPO_MANTENIMIENTO}='58'  "
            End If

            If bActivo Then
                sWhere &= " and vw_mant_cta.TIPO_MANTENIMIENTO " & strTipoMannto
                ls_PorImprimir &= " and {vw_mant_cta.TIPO_MANTENIMIENTO} " & strTipoManntoCR
            Else
                sWhere &= " Where vw_mant_cta.TIPO_MANTENIMIENTO " & strTipoMannto
                ls_PorImprimir &= " {vw_mant_cta.TIPO_MANTENIMIENTO} " & strTipoManntoCR
                bActivo = True
            End If

        End If

        If Not bActivo Then
            MsgBox("No se ha selecionado ningun tipo de filtro. ", MsgBoxStyle.Exclamation, "Reporte Mantenimiento Cuenta")
            Exit Function
        End If

        sSqlQuery = sSqlCount & sSql & sWhere
        'obtiene registros de la consulta
        iRegistros = d.HayRegistros(sSqlQuery)

        If iRegistros <= 0 Then
            MsgBox("No se encontraron registros para el filtro seleccionado. ", MsgBoxStyle.Exclamation, "Reporte Mantenimiento Cuenta")
            Exit Function
        End If

        sSqlQuery = sSqlSelect & sSql & sWhere
        dgvManntoCuentas.DataSource = d.RealizaConsulta(sSqlQuery)

        LlenaMantenimientos = True

    End Function

    Private Function ChecaDatos() As Boolean
        Dim booBien As Boolean
        Dim strMensaje As String
        Dim boMateria As Boolean

        boMateria = False
        booBien = True
        ChecaDatos = True
        strMensaje = "Mantenimiento Cuentas PU," & vbCrLf & "La información siguiente es requerida : " & vbCrLf & vbCrLf

        'Verfifca el numero de cuenta que no esten vacios y no sea mayor la del fin
        If chkCuenta.Checked = True Then
            If txtCuenta.Text = "" Then
                strMensaje &= "Cuenta cliente, "
                booBien = False
                ChecaDatos = False
                chkCuenta.Focus()
                txtCuenta.Focus()
            End If
        End If

        If chkFecha.Checked = True Then
            If Not IsDate(txtFecha.Text) Then
                booBien = False
                ChecaDatos = False
                strMensaje &= "Fecha de reporte, " '"Formato de fecha incorrecta, "
                txtFecha.Focus()
            End If
        End If

        If chkRango.Checked = True Then
            If StrComp(Trim(txtFechaIni.Text), "", vbTextCompare) <> 0 And StrComp(Trim(txtFechaFin.Text), "", vbTextCompare) <> 0 Then
                If DateDiff("d", CDate(Trim(txtFechaIni.Text)), CDate(Trim(txtFechaFin.Text))) < 0 Then
                    booBien = False
                    ChecaDatos = False
                    strMensaje &= "El rango de Fin debe ser menor a la de Inicio, "
                    txtFechaFin.Text = ""
                    txtFechaFin.Focus()
                End If
            Else
                booBien = False
                ChecaDatos = False
                If txtFechaIni.Text = "" And txtFechaFin.Text = "" Or txtFechaFin.Text <> "" Then
                    txtFechaIni.Focus()
                    strMensaje &= "Rango Inicio, "
                Else
                    txtFechaFin.Focus()
                    strMensaje &= "Rango Fin, "
                End If
            End If
        End If

        If chkTipo.Checked = True Then
            If cmbTipoMannto.Text = String.Empty Then
                booBien = False
                ChecaDatos = False
                strMensaje &= "Seleccione un tipo de mantenimiento, "
                cmbTipoMannto.Focus()
            End If
        End If

    End Function

    Private Function ApagaControles() As Boolean
        cmdImprimir.Enabled = False
        txtCuenta.Enabled = False
        txtFecha.Enabled = False
        txtFechaIni.Enabled = False
        txtFechaFin.Enabled = False
        cmbTipoMannto.Enabled = False

        txtCuenta.Visible = False
        txtFecha.Visible = False
        txtFechaIni.Visible = False
        txtFechaFin.Visible = False
        cmbTipoMannto.Visible = False

        lblFecha.Visible = False
        lblRango.Visible = False

        ApagaControles = True

    End Function

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        'realiza la extracción de la información
        opcionReporte = 12    'reporte de Mantenimientos

        RepOperativa.ShowDialog()
    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    Private Sub cmbTipoMannto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoMannto.SelectedIndexChanged
        TipoMannto = cmbTipoMannto.SelectedValue
        cmdBuscar.Focus()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class