Imports System.Globalization
Imports System.Threading
Public Class funcionalidades
    Private l As New Libreria
    Private Sub funcionalidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.tsslUserConectado.Text = "Usuario: " & nameUser
        Me.tsslServerName.Text = "Servidor: " & l.Decrypt(l.SERVER)
        Me.tsslDatabase.Text = "BD: " & l.Decrypt(l.DB)
        Me.tsslFecha.Text = Date.Now().Date.ToString("yyyy-MMMM-dd")
        Call Prende()
        'Carga el arreglo de permisos y autorizaciones
        l.CargaPermisos("9")
        If usuario = 1 Or l.Permiso("PADMINISTRADOR") Then
            AdministradorToolStripMenuItem.Enabled = True
        Else
            AdministradorToolStripMenuItem.Enabled = False
        End If
        If l.Permiso("POFACACTIVAS") Then
            CuentasActivasToolStripMenuItem.Enabled = True
        Else
            CuentasActivasToolStripMenuItem.Enabled = False
        End If
        If l.Permiso("POFACCANCELADAS") Then
            CuentasCanceladasToolStripMenuItem.Enabled = True
        Else
            CuentasCanceladasToolStripMenuItem.Enabled = False
        End If
        If l.Permiso("PAICEDCAP") Then 'If True Then
            CapturaDeToolStripMenuItem.Enabled = True
        Else
            CapturaDeToolStripMenuItem.Enabled = False
        End If
        If l.Permiso("PAICEDCONSUL") Then 'If True Then
            ConsultaToolStripMenuItem.Enabled = True
        Else
            ConsultaToolStripMenuItem.Enabled = False
        End If
        If l.Permiso("PAICEDREP") Then 'If True Then
            ReportesToolStripMenuItem2.Enabled = True
        Else
            ReportesToolStripMenuItem2.Enabled = False
        End If
        If l.Permiso("PGESTORES") Then 'If True Then
            GestoresToolStripMenuItem.Enabled = True
        Else
            GestoresToolStripMenuItem.Enabled = False
        End If
        Relogin = False
    End Sub
    Private Sub AperturaDeCuentaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AperturaDeCuentaToolStripMenuItem1.Click
        Dim fAperturaCuenta As New AperturaCuenta
        If l.Permiso("PAPERCUENCEDMAN") Then
            'MsgBox("encontro permiso")
            fAperturaCuenta.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
        'fAperturaCuenta.ShowDialog()

    End Sub
    Private Sub MT103ToolStripMenuItem2_Click(sender As Object, e As EventArgs)
        'Dim fCapturaOpe As New CapturaOpe
        'fCapturaOpe.ShowDialog()
    End Sub

    Private Sub ComplementoDeAperturaDeCuentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComplementoDeAperturaDeCuentaToolStripMenuItem.Click
        Dim fCompAperturaCuenta As New CompApertura
        If l.Permiso("PCOMPAPERCUECED") Then
            'MsgBox("encontro permiso")
            fCompAperturaCuenta.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
        'fCompAperturaCuenta.ShowDialog()
    End Sub

    Private Sub ValidarAperturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ValidarAperturaToolStripMenuItem.Click
        Dim fValidaApertura As New ValidaApertura
        If l.Permiso("PVALAPERCED") Then
            'MsgBox("encontro permiso")
            fValidaApertura.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
        'fValidaApertura.ShowDialog()
    End Sub
    Private Sub funcionalidades_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    'Private Sub MT103ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles MT103ToolStripMenuItem3.Click
    '    RepTipoMT103 = 0
    '    'Dim RMT103 As New RepMt103Ticket
    '    Dim frmMT103OrdPago As New frmMT103OrdPago
    '    frmMT103OrdPago.ShowDialog()
    '    'RMT103.Size = New System.Drawing.Size(1200, 200)
    '    'RMT103.ShowDialog()
    'End Sub

    'Private Sub MT103CASHWINDOWSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MT103CASHWINDOWSToolStripMenuItem.Click
    '    RepTipoMT103 = 3
    '    Dim RMT103 As New RepMt103Ticket
    '    RMT103.Size = New System.Drawing.Size(1280, 200)
    '    RMT103.ShowDialog()
    'End Sub

    'Private Sub MT103PorUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MT103PorUsuarioToolStripMenuItem.Click
    '    RepTipoMT103 = 2
    '    Dim RMT103 As New RepMt103Ticket
    '    RMT103.Size = New System.Drawing.Size(1280, 200)
    '    RMT103.ShowDialog()
    'End Sub

    'Private Sub MT103CASHWINDOWSToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MT103CASHWINDOWSToolStripMenuItem1.Click
    '    RepTipoMT103 = 1
    '    Dim RMT103 As New RepMt103Ticket
    '    RMT103.Size = New System.Drawing.Size(1280, 200)
    '    RMT103.ShowDialog()
    'End Sub

    Private Sub BloqDesBloqToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BloqDesBloqToolStripMenuItem.Click
        Dim BloqueoDesbloqueoAlertamiento As New Bloqueo_DesbloqueoCtas
        If l.Permiso("PBLOCDESALECTA") Then
            BloqueoDesbloqueoAlertamiento.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub AlertamientoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CancelacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelacionToolStripMenuItem.Click
        Dim CancelacionCtas As New CancelacionCtas
        If l.Permiso("PCANREACUENCED") Then
            'MsgBox("encontro permiso")
            CancelacionCtas.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub ConsultaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ConsultaToolStripMenuItem1.Click
        If l.Permiso("PCONSULCTACED") Then
            Dim ConsultaCTA As New ConsultaCTA
            ConsultaCTA.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub RptCtasNuevasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'Dim frmRepAperturas As New frmRepAperturas
        'frmRepAperturas.ShowDialog()
    End Sub

    'Private Sub AperturasPorRangoDeFechaToolStripMenuItem_Click(sender As Object, e As EventArgs) 
    '    Dim frmAperturasxfecha As New frmAperturasXFecha
    '    frmAperturasxfecha.ShowDialog()
    'End Sub

    'Private Sub ConsolidadoDeAperturasValidadasConDetalleToolStripMenuItem_Click(sender As Object, e As EventArgs) 
    '    Dim frmAperturasDetalle As New frmAperturasDetalle
    '    frmAperturasDetalle.ShowDialog()
    'End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        Dim Acercade As New Acercade
        Acercade.ShowDialog()
    End Sub

    Private Sub CuentasConDineroALaVistaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuentasConDineroALaVistaToolStripMenuItem.Click
        If l.Permiso("PREPCUENDINVIST") Then
            Dim frmRepCtasDineroVista As New frmRepCtasDineroVista
            frmRepCtasDineroVista.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub OperacionesRelevantesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperacionesRelevantesToolStripMenuItem.Click
        If l.Permiso("PREPOPERRELE") Then
            Dim frmRepOperRelev As New frmRepOperRelev
            frmRepOperRelev.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub TDDPosteoRechazadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TDDPosteoRechazadoToolStripMenuItem.Click
        If l.Permiso("PREPTDDPOSRECH") Then
            Dim frmTDDPosteoRechazos As New frmTDDPosteoRechazos
            frmTDDPosteoRechazos.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub OperacionesPorUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperacionesPorUsuarioToolStripMenuItem.Click
        If l.Permiso("POPERXUSU") Then
            Dim frmRepOperUsuario As New frmRepOperUsuario
            frmRepOperUsuario.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub OperacionesNoValidadasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperacionesNoValidadasToolStripMenuItem.Click
        If l.Permiso("PREPOPERNOVALI") Then
            Dim frmRepOperNOValidadas As New frmRepOperNOValidadas
            frmRepOperNOValidadas.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub AplicaciónContableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AplicaciónContableToolStripMenuItem.Click
        If l.Permiso("PREPAPLICONT") Then
            Dim frmRepAplicaContable As New frmRepAplicaContable
            frmRepAplicaContable.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub ReporteCtaCEDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteCtaCEDToolStripMenuItem.Click
        If l.Permiso("PREPCUENCED") Then
            Dim frmRepAperturas As New frmRepAperturas
            frmRepAperturas.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub OrdenesDePagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdenesDePagoToolStripMenuItem.Click
        If l.Permiso("PREPORDPAGMT103") Then
            Dim frmMT103OrdPago As New frmMT103OrdPago
            frmMT103OrdPago.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click
        Dim d As New Datasource
        Dim fTicketLogin As New funcionalidades
        Dim Login As New Login

        Relogin = True
        'Me.Hide()
        'De-registra al usuario de la base de datos
        'Call LogOff
        'Apagamos los puntos de menú que requieren permiso
        Call Apaga()

        'MUESTRA LA FORMA DE LOGIN
        Login.ShowDialog()

        If Relogin = False Then
            funcionalidades_Load(sender, e)
        End If
        'If d.LogOn Then
        'fTicketLogin.Show()
        'End If

    End Sub

    Private Sub Apaga()
        Me.AperturaDeCuentaToolStripMenuItem.Visible = False
        Me.OperacionesToolStripMenuItem.Visible = False
        Me.ReportesToolStripMenuItem.Visible = False
        Me.ChequerasToolStripMenuItem.Visible = False
        Me.MiscelaneaToolStripMenuItem1.Visible = False
    End Sub
    Private Sub Prende()
        Me.AperturaDeCuentaToolStripMenuItem.Visible = True
        Me.OperacionesToolStripMenuItem.Visible = True
        Me.ReportesToolStripMenuItem.Visible = True
        Me.ChequerasToolStripMenuItem.Visible = True
        Me.MiscelaneaToolStripMenuItem1.Visible = True
    End Sub
    Private Sub CuentasActivasOBloqueadasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuentasActivasOBloqueadasToolStripMenuItem.Click
        If l.Permiso("PREPCUENACTIBLO") Then
            Dim frmCtasBloqAct As New frmCtasBloqAct
            frmCtasBloqAct.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub FuncionariosConOSinCuentaCEDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FuncionariosConOSinCuentaCEDToolStripMenuItem.Click
        If l.Permiso("PREPFUNCUENCED") Then
            Dim frmFuncConSinCtaCED As New frmFuncConSinCtaCED
            frmFuncConSinCtaCED.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub ReporteMantenimientoDeCuentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteMantenimientoDeCuentasToolStripMenuItem.Click
        If l.Permiso("PREPMANTCUENT") Then
            Dim frmManntoCuentas As New frmManntoCuentas
            frmManntoCuentas.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub MantenimientoHorariosOperaciónCashToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoHorariosOperaciónCashToolStripMenuItem.Click
        Dim frmManttoParHor As New frmManttoParHor
        If l.Permiso("PMANTHOROPECASH") Then
            frmManttoParHor.MsTabla = "PARAMETROS_HORARIOS"
            frmManttoParHor.Text = "Mantenimiento de Horarios de Operación Cash"
            'MsgBox("encontro permiso")
            frmManttoParHor.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If

    End Sub

    Private Sub MantenimientoHorariosOperaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoHorariosOperaciónToolStripMenuItem.Click
        Dim frmManttoParHor As New frmManttoParHor
        If l.Permiso("PMANTHOROPER") Then
            frmManttoParHor.MsTabla = "PARAMETROS_HORARIOS"
            frmManttoParHor.Text = "Mantenimiento de Horarios de Operación"
            'MsgBox("encontro permiso")
            frmManttoParHor.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If

    End Sub

    Private Sub SaldosCuentasCEDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaldosCuentasCEDToolStripMenuItem.Click
        If l.Permiso("PREPSALCUENCED") Then
            Dim frmCuentasSaldosSobregiros As New frmCuentasSaldosSobregiros
            frmCuentasSaldosSobregiros.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    'Private Sub ConsultaPorClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaPorClienteToolStripMenuItem.Click
    '    Dim frmCuentasSaldosSobregiros As New frmCuentasSaldosSobregiros
    '    frmCuentasSaldosSobregiros.ShowDialog()
    'End Sub

    Private Sub ChequeraNormalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChequeraNormalToolStripMenuItem.Click
        If l.Permiso("PSOLCHEQNORMAL") Then
            Dim frmSolicitudChequeraNormal As New frmSolicitudChequeraNormal
            frmSolicitudChequeraNormal.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub ChequeraEspecialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChequeraEspecialToolStripMenuItem.Click
        If l.Permiso("PSOLCHEQSPECIAL") Then
            Dim frmSolicitudChequeraEspecial As New frmSolicitudChequeraEspecial
            frmSolicitudChequeraEspecial.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub PendientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PendientesToolStripMenuItem.Click
        If l.Permiso("PPENAPERTURA") Then
            Dim frmConsulCHQApertura As New frmConsulCHQApertura
            frmConsulCHQApertura.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub PorCuentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorCuentaToolStripMenuItem.Click
        If l.Permiso("PREPXCUENTA") Then
            Dim frmConsChqCta As New frmConsChqCta
            frmConsChqCta.Tipo(1)
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub PorRangoDeFechasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorRangoDeFechasToolStripMenuItem.Click
        If l.Permiso("PREPXRANGFECHA") Then
            Dim frmConsChqCta As New frmConsChqCta
            frmConsChqCta.Tipo(3)
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub CancelaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelaciónToolStripMenuItem.Click
        If l.Permiso("PCANCELACION") Then
            Dim frmCancelarCHQ As New frmCancelarCHQ
            frmCancelarCHQ.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub ClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClienteToolStripMenuItem.Click
        Dim frmConsCte As New frmConsCte
        frmConsCte.ShowDialog()
    End Sub

    Private Sub ConsultaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaToolStripMenuItem.Click

    End Sub

    Private Sub DocumentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DocumentoToolStripMenuItem.Click
        Dim frmConsulta As New frmConsulta
        frmConsulta.Fuente(0, "")
    End Sub

    Private Sub DocumentosDeSucursalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DocumentosDeSucursalToolStripMenuItem.Click
        Dim frmCaptura As New frmCaptura
        frmCaptura.ShowDialog()
        ' If VerificarHrValida(1) = True Then frmCaptura.Show
    End Sub

    Private Sub TraspasosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim frmCapturaTraspaso As New frmCapturaTraspaso
        frmCapturaTraspaso.ShowDialog()
        ' If VerificarHrValida(3) = True Then frmCapturaTrasp.Show
    End Sub

    Private Sub TicketToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TicketToolStripMenuItem.Click
        Dim frmConsulta As New frmConsulta
        frmConsulta.Fuente(1, "")
    End Sub

    Private Sub ReporteDeOperacionesDiariasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeOperacionesDiariasToolStripMenuItem.Click
        Dim frmRepOpesDiarias As New frmRepOpesDiarias
        frmRepOpesDiarias.ShowDialog()
    End Sub
    Private Sub BloqueoDesloqueoTDsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BloqueoDesloqueoTDsToolStripMenuItem.Click
        If l.Permiso("PBLOQDESBTDS") Then
            ConfReg()
            Dim frmBloqueoTD As New frmBloqueoTD
            frmBloqueoTD.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub CancelacionTDsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelacionTDsToolStripMenuItem.Click
        If l.Permiso("PCANTIMDEP") Then
            Dim frmCancelaTD As New frmCancelaTD
            frmCancelaTD.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub GeneraciónArchivoInterfaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneraciónArchivoInterfaseToolStripMenuItem.Click
        If l.Permiso("PGENARCHIN") Then
            ConfReg()
            Dim GeneraPrinterChq As New frmGeneraPrinterChq
            GeneraPrinterChq.StartPosition = FormStartPosition.CenterScreen
            GeneraPrinterChq.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub ReimpresionMT198ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReimpresionMT198ToolStripMenuItem.Click
        If l.Permiso("PREPREIMPMT198") Then
            ConfReg()
            Dim ReimpRepMT198 As New frmReimpRepMT198
            ReimpRepMT198.StartPosition = FormStartPosition.CenterScreen
            ReimpRepMT198.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub SalvoBuenFinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalvoBuenFinToolStripMenuItem.Click
        If l.Permiso("PSALVOBUENFIN") Then
            ConfReg()
            Dim frmSalBuFin As New frmOperacReport
            frmSalBuFin.StartPosition = FormStartPosition.CenterScreen
            frmSalBuFin.Reporte(5)
            'frmSalBuFin.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub TitularesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TitularesToolStripMenuItem.Click
        ConfReg()
        Dim OFAC As New frmRepOFAC
        OFAC.StartPosition = FormStartPosition.CenterScreen
        OFAC.Reporte(0)
    End Sub

    Private Sub CotitularesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CotitularesToolStripMenuItem.Click
        ConfReg()
        Dim OFAC As New frmRepOFAC
        OFAC.StartPosition = FormStartPosition.CenterScreen
        OFAC.Reporte(2)
    End Sub

    Private Sub BeneficiariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeneficiariosToolStripMenuItem.Click
        ConfReg()
        Dim OFAC As New frmRepOFAC
        OFAC.StartPosition = FormStartPosition.CenterScreen
        OFAC.Reporte(1)
    End Sub

    Private Sub AutorizadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutorizadosToolStripMenuItem.Click
        ConfReg()
        Dim OFAC As New frmRepOFAC
        OFAC.StartPosition = FormStartPosition.CenterScreen
        OFAC.Reporte(3)
    End Sub

    Private Sub TitularesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TitularesToolStripMenuItem1.Click
        ConfReg()
        Dim OFAC As New frmRepOFAC
        OFAC.StartPosition = FormStartPosition.CenterScreen
        OFAC.Reporte(4)
    End Sub

    Private Sub ApoderadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApoderadosToolStripMenuItem.Click
        ConfReg()
        Dim OFAC As New frmRepOFAC
        OFAC.StartPosition = FormStartPosition.CenterScreen
        OFAC.Reporte(5)
    End Sub

    Private Sub AutorizadosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AutorizadosToolStripMenuItem1.Click
        ConfReg()
        Dim OFAC As New frmRepOFAC
        OFAC.StartPosition = FormStartPosition.CenterScreen
        OFAC.Reporte(6)
    End Sub

    Private Sub TitularesToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles TitularesToolStripMenuItem2.Click
        ConfReg()
        Dim OFAC As New frmRepOFAC
        OFAC.StartPosition = FormStartPosition.CenterScreen
        OFAC.Reporte(7)
    End Sub

    Private Sub CotitularesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CotitularesToolStripMenuItem1.Click
        ConfReg()
        Dim OFAC As New frmRepOFAC
        OFAC.StartPosition = FormStartPosition.CenterScreen
        OFAC.Reporte(9)
    End Sub

    Private Sub BeneficiariosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BeneficiariosToolStripMenuItem1.Click
        ConfReg()
        Dim OFAC As New frmRepOFAC
        OFAC.StartPosition = FormStartPosition.CenterScreen
        OFAC.Reporte(8)
    End Sub

    Private Sub AutorizadosToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AutorizadosToolStripMenuItem2.Click
        ConfReg()
        Dim OFAC As New frmRepOFAC
        OFAC.StartPosition = FormStartPosition.CenterScreen
        OFAC.Reporte(10)
    End Sub

    Private Sub TitularesToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles TitularesToolStripMenuItem3.Click
        ConfReg()
        Dim OFAC As New frmRepOFAC
        OFAC.StartPosition = FormStartPosition.CenterScreen
        OFAC.Reporte(11)
    End Sub

    Private Sub ApoderadosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ApoderadosToolStripMenuItem1.Click
        ConfReg()
        Dim OFAC As New frmRepOFAC
        OFAC.StartPosition = FormStartPosition.CenterScreen
        OFAC.Reporte(12)
    End Sub

    Private Sub AutorizadosToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles AutorizadosToolStripMenuItem3.Click
        ConfReg()
        Dim OFAC As New frmRepOFAC
        OFAC.StartPosition = FormStartPosition.CenterScreen
        OFAC.Reporte(13)
    End Sub

    Private Sub IntegradasEnSaldosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IntegradasEnSaldosToolStripMenuItem.Click
        If l.Permiso("PINTESALDOS") Then
            ConfReg()
            Dim IntegradasSaldos As New frmRepAgencias
            IntegradasSaldos.StartPosition = FormStartPosition.CenterScreen
            IntegradasSaldos.ReporteAgencias(10)
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub ComprasDeTimeDepositToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprasDeTimeDepositToolStripMenuItem.Click
        If l.Permiso("PCOMPRASTDLISTA") Then
            ConfReg()
            GsRepTDOver = "Normal"
            Dim IntegradasSaldos As New frmOperacReport
            IntegradasSaldos.StartPosition = FormStartPosition.CenterScreen
            IntegradasSaldos.Reporte(7)
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub VencimientoDeTDsPorDíaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VencimientoDeTDsPorDíaToolStripMenuItem.Click
        If l.Permiso("PVENCTDSXDIA") Then
            ConfReg()
            Dim VenTdsDia As New frmVencimientosTD
            VenTdsDia.StartPosition = FormStartPosition.CenterScreen
            VenTdsDia.Show()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub ReenvioDeTicketsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReenvioDeTicketsToolStripMenuItem.Click
        Dim ReenvioTicket As New frmReenvioTicket
        If l.Permiso("PREENTICKETS") Then
            ConfReg()
            ReenvioTicket.StartPosition = FormStartPosition.CenterScreen
            ReenvioTicket.Show()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub MantenimientoDeCuentaCEDToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles MantenimientoDeCuentaCEDToolStripMenuItem1.Click
        Dim frmManntoCuenta As New frmManntoCuenta
        If l.Permiso("PMANTCUENCED") Then
            'MsgBox("encontro permiso")
            frmManntoCuenta.ShowDialog()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If l.Permiso("PCOMPRASTD") Then
            ConfReg()
            Dim CompraTD As New frmOperacReport
            CompraTD.StartPosition = FormStartPosition.CenterScreen
            CompraTD.Reporte(6)
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub BloqueosTDs_Click(sender As Object, e As EventArgs) Handles BloqueosTDs.Click
        If l.Permiso("PBLOQUEOSTDS") Then
            ConfReg()
            Dim frmBloqueoTDs As New frmReporte_BloqueoTD
            frmBloqueoTDs.StartPosition = FormStartPosition.CenterScreen
            frmBloqueoTDs.Show()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub DetalleDepositosSucursal_Click(sender As Object, e As EventArgs) Handles DetalleDepositosSucursal.Click
        If l.Permiso("PDETDEPSAIFHOY") Then
            ConfReg()
            Dim IntegradasSaldos As New frmRepAgencias
            IntegradasSaldos.StartPosition = FormStartPosition.CenterScreen
            IntegradasSaldos.ReporteAgencias(8)
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub

    Private Sub DetalleRetirosSucursal_Click(sender As Object, e As EventArgs) Handles DetalleRetirosSucursal.Click

        If l.Permiso("PDETRETSAIFHOY") Then
            ConfReg()
            Dim IntegradasSaldos As New frmRepAgencias
            IntegradasSaldos.StartPosition = FormStartPosition.CenterScreen
            IntegradasSaldos.ReporteAgencias(20)
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub PermisosPorUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PermisosPorUsuario.Click
        ConfReg()
        If l.Permiso("PADMINISTRADOR") Then
            ConfReg()
            Dim SelectApp As New frmMenuApp(1)
            SelectApp.StartPosition = FormStartPosition.CenterScreen
            SelectApp.Show()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub BitacoraAdministrador_Click(sender As Object, e As EventArgs) Handles BitacoraAdministrador.Click
        ConfReg()
        If l.Permiso("PADMINISTRADOR") Then
            Dim SelectApp As New frmMenuApp(2)
            SelectApp.StartPosition = FormStartPosition.CenterScreen
            SelectApp.Show()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub ReporteXUsuarioGestores_Click(sender As Object, e As EventArgs) Handles ReporteXUsuarioGestores.Click
        If l.Permiso("PREPXUSUGEST") Then
            Dim objModPermisos As modPermisos = New modPermisos()
            Dim rptDoc As New ReportDocument
            Dim lsReporte As String = ""
            Dim lsRutaFolder As String = ""
            Dim lsAmbiente As String = ""
            Dim objLibreria As New Libreria
            ConfReg()
            lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
            lsReporte = lsRutaFolder & "Funcs_PermisosUsr" & lsAmbiente & ".rpt"
            rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
            objModPermisos.GesImprimePermisos("Administración de Gestores", rptDoc)
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub AsignarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignarToolStripMenuItem.Click
        ConfReg()
        If usuario = 1 Or l.Permiso("PADMINISTRADOR") Then
            Dim FormAsigna As New frmPerfilAsigna
            FormAsigna.StartPosition = FormStartPosition.CenterScreen
            FormAsigna.Show()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        ConfReg()
        If usuario = 1 Or l.Permiso("PADMINISTRADOR") Then
            Dim FormEdita As New frmPerfilEdita
            FormEdita.StartPosition = FormStartPosition.CenterScreen
            FormEdita.Show()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub CambiarContraseñaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarContraseñaToolStripMenuItem.Click
        Dim VistaMantPasswd As New MantPasswd
        ConfReg()
        VistaMantPasswd.StartPosition = FormStartPosition.CenterScreen
        VistaMantPasswd.Show()
    End Sub
    Private Sub MantenimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoToolStripMenuItem.Click
        Dim VistaMantenimientoUsuario As New frmMantUsr
        ConfReg()
        VistaMantenimientoUsuario.StartPosition = FormStartPosition.CenterScreen
        VistaMantenimientoUsuario.Show()
    End Sub
    Private Sub CapturaDeOperacionesMT103ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CapturaDeOperacionesMT103ToolStripMenuItem.Click
        Dim VistaRetirosMT103 As New frmRetirosOrdenPagoMT103(1)
        If l.Permiso("PCAPOPMT103") Then
            ConfReg()
            VistaRetirosMT103.StartPosition = FormStartPosition.CenterScreen
            VistaRetirosMT103.Show()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub ValidarOperacionesMT103ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ValidarOperacionesMT103ToolStripMenuItem.Click
        Dim VistaRetirosMT103 As New frmRetirosOrdenPagoMT103(2)
        If l.Permiso("PVALOPMT103") Then
            ConfReg()
            VistaRetirosMT103.StartPosition = FormStartPosition.CenterScreen
            VistaRetirosMT103.Show()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub NuevoUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoUsuarioToolStripMenuItem.Click
        ConfReg()
        Dim VistaAltaUsuario As New frmNuevoUsuario
        Dim l As New Libreria
        If l.Permiso("PADMINISTRADOR") Then
            VistaAltaUsuario.StartPosition = FormStartPosition.CenterScreen
            VistaAltaUsuario.Show()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub MT202ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MT202ToolStripMenuItem.Click
        If l.Permiso("PMT202") Then 'If True Then
            ConfReg()
            Dim MT202 As New frmMT202BBVA
            MT202.StartPosition = FormStartPosition.CenterScreen
            MT202.Show()
        Else
            MsgBox("Sin permisos para este modulo")
            ConfReg()
        End If
    End Sub
    Private Sub MT198ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MT198ToolStripMenuItem.Click
        If l.Permiso("PENVIOMT198") Then 'If True Then
            Dim VistaReporteMT198 As New frmMT198
            ConfReg()
            VistaReporteMT198.StartPosition = FormStartPosition.CenterScreen
            VistaReporteMT198.Show()
        Else
            MsgBox("Sin permisos para este modulo")
            ConfReg()
        End If
    End Sub
    Private Sub AltaDeGestoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AltaDeGestoresToolStripMenuItem.Click
        ConfReg()
        Dim AltaGestores As New frmAltaFuncs
        AltaGestores.StartPosition = FormStartPosition.CenterScreen
        AltaGestores.Show()
    End Sub
    Private Sub ConsultaDeGestoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeGestoresToolStripMenuItem.Click
        ConfReg()
        Dim fFuncionarios As New frmFunc
        fFuncionarios.mnModo = 1
        fFuncionarios.StartPosition = FormStartPosition.CenterScreen
        fFuncionarios.Show()
    End Sub
    Private Sub MantenimientoDeGestoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeGestoresToolStripMenuItem.Click
        ConfReg()
        Dim fFuncionarios As New frmFunc
        fFuncionarios.mnModo = 2
        fFuncionarios.StartPosition = FormStartPosition.CenterScreen
        fFuncionarios.Show()
    End Sub
    Private Sub ReporteGoMACToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteGoMACToolStripMenuItem.Click
        ConfReg()
        Dim frmSolicitudCuenta As New frmSolicitudCuenta
        frmSolicitudCuenta.StartPosition = FormStartPosition.CenterScreen
        frmSolicitudCuenta.ShowDialog()
    End Sub
    Private Sub ConsultaDeUnidadesOrgToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeUnidadesOrgToolStripMenuItem.Click
        ConfReg()
        Dim frmUnidadOrganizacional As New frmUnidadOrg(1)
        frmUnidadOrganizacional.StartPosition = FormStartPosition.CenterScreen
        frmUnidadOrganizacional.ShowDialog()
    End Sub
    Private Sub MantenimientoDeUnidadesOrgToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeUnidadesOrgToolStripMenuItem.Click
        ConfReg()
        Dim frmUnidadOrganizacional As New frmUnidadOrg(2)
        frmUnidadOrganizacional.StartPosition = FormStartPosition.CenterScreen
        frmUnidadOrganizacional.ShowDialog()
    End Sub
    Private Sub UnidadesOrganizacionalesEstrategicasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnidadesOrganizacionalesEstrategicasToolStripMenuItem.Click
        '******* OLIVIA FARIAS GARCIA OFG 2017-04-21
        'CREACION DE REPORTE DE UNIDADES ORGANIZACIONALES ESTRATEGICAS SOLICITADO POR LA MNI
        ConfReg()
        Dim gsSql As String
        Dim objDatasource As New Datasource
        Dim rptDoc As New ReportDocument
        Dim lsAmbiente As String = ""
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""
        'actualización de la información
        gsSql = "EXEC FUNCIONARIOS..sp_unidad_org_estrategicas "
        'dbExecQuery gsSql
        If objDatasource.insertar(gsSql) <= 0 Then 'If dbError <> 0 Then
            MsgBox("No es posible actualizar la información del reporte..", vbCritical, "Gestores")
        End If
        'dbEndQuery
        'generación del reporte
        'ShowWaitCursor
        'rptFuncs.ReportFileName = REPSPATH & "\rptUnidadOrgEstrategicas.rpt"
        'MaximizaReporte rptFuncs
        'rptFuncs.Formulas(0) = ""
        'ShowDefaultCursor
        lsRutaFolder = My.Application.Info.DirectoryPath & "\" & l.sFolderRPT & "\"
        lsReporte = lsRutaFolder & "rptUnidadOrgEstrategicas" & lsAmbiente & ".rpt"
        rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
        l.logonBDreporte(rptDoc, 1)
        rptDoc.DataDefinition.FormulaFields.Item(0).Text = ""
        opcionReporte = 17
        RepOperativa.reporteOFAC = rptDoc
        RepOperativa.ShowDialog()
    End Sub
    Private Sub CuentasActivasOBloqueadasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CuentasActivasOBloqueadasToolStripMenuItem1.Click
        ConfReg()
        Dim gsSql As String
        Dim objDatasource As New Datasource
        Dim rptDoc As New ReportDocument
        Dim lsAmbiente As String = ""
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""
        gsSql = "EXEC FUNCIONARIOS..sp_ctas_activas_bloqueadas "
        If objDatasource.insertar(gsSql) <= 0 Then 'If dbError <> 0 Then
            MsgBox("No es posible actualizar la información del reporte..", vbCritical, "Gestores")
        End If
        lsRutaFolder = My.Application.Info.DirectoryPath & "\" & l.sFolderRPT & "\"
        lsReporte = lsRutaFolder & "rptCuentasCedAB" & lsAmbiente & ".rpt"
        rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
        l.logonBDreporte(rptDoc, 1)
        opcionReporte = 17
        RepOperativa.reporteOFAC = rptDoc
        RepOperativa.ShowDialog()
    End Sub
    Private Sub GestoresActivosConOSinCEDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestoresActivosConOSinCEDToolStripMenuItem.Click
        ConfReg()
        Dim gsSql As String
        Dim objDatasource As New Datasource
        Dim rptDoc As New ReportDocument
        Dim lsAmbiente As String = ""
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""
        gsSql = "EXEC FUNCIONARIOS..sp_func_cuentas "
        If objDatasource.insertar(gsSql) <= 0 Then 'If dbError <> 0 Then
            MsgBox("No es posible actualizar la información del reporte..", vbCritical, "Gestores")
        End If
        lsRutaFolder = My.Application.Info.DirectoryPath & "\" & l.sFolderRPT & "\"
        lsReporte = lsRutaFolder & "rptGestoresActCED" & lsAmbiente & ".rpt"
        rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
        l.logonBDreporte(rptDoc, 1)
        opcionReporte = 17
        RepOperativa.reporteOFAC = rptDoc
        RepOperativa.ShowDialog()
    End Sub
    Private Sub ReasignaciónDeGestoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReasignaciónDeGestoresToolStripMenuItem.Click
        Try
            If l.Permiso("PREAGEST") Then
                ConfReg()
                Dim frmAsuganFuncionario As New frmReasignaFunc
                frmAsuganFuncionario.StartPosition = FormStartPosition.CenterScreen
                frmAsuganFuncionario.ShowDialog()
            Else
                MsgBox("Sin permisos para este modulo")
                ConfReg()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CancelaciónDeOperacionesValidadasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelaciónDeOperacionesValidadasToolStripMenuItem.Click
        If l.Permiso("PCANCELVAL") Then
            ConfReg()
            Dim CancelOperTick As New frmCancelaTicket
            CancelOperTick.StartPosition = FormStartPosition.CenterScreen
            CancelOperTick.Show()
        Else
            MsgBox("Sin permisos para este modulo")
        End If
    End Sub
    Private Sub ConfReg()
        Dim objLibreria As New Libreria
        Dim objDatasource As New Datasource
        Dim dtRespConsulta As DataTable
        Dim drRegistro As DataRow
        Dim culture As String = ""
        dtRespConsulta = objDatasource.RealizaConsulta("select convert(Char(10), fecha_sistema, 101) from TICKET..PARAMETROS")
        If dtRespConsulta IsNot Nothing And dtRespConsulta.Rows.Count() > 0 Then
            drRegistro = dtRespConsulta.Rows(0)
            gs_FechaHoy = drRegistro.Item(0).ToString
        End If
        If Thread.CurrentThread.CurrentCulture.Name = "en-US" Then
            culture = "en-US"
        ElseIf Thread.CurrentThread.CurrentCulture.Name = "es-MX" Then
            culture = "en-US"
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture)
            gs_FechaHoy = (CDate(gs_FechaHoy).Day).ToString.PadLeft(2, "0") & "-" & (CDate(gs_FechaHoy).Month).ToString.PadLeft(2, "0") & "-" & CDate(gs_FechaHoy).Year
            culture = "es-MX"
        End If
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture)
        dtRespConsulta = objDatasource.RealizaConsulta("SELECT convert(char(5),getdate(),14)")
        drRegistro = dtRespConsulta.Rows(0)
        gs_HoraSistema = drRegistro.Item(0).ToString
    End Sub
End Class