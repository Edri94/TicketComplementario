Public Class frmMenuApp
    Private iOpMenu As Integer
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(Menu As Integer)
        Me.New()
        iOpMenu = Menu
    End Sub
    Private Sub cmdGenerar_Click(sender As Object, e As EventArgs) Handles cmdGenerar.Click
        Dim rptDoc As New ReportDocument
        Dim lsReporte As String = ""
        Dim lsRutaFolder As String = ""
        Dim lsAmbiente As String = ""
        Dim objLibreria As New Libreria
        Dim sNumApp As String
        Dim sNombreRep As String
        If rbTicket.Checked = True Then
            sNumApp = "9"
            sNombreRep = "TicketComplementario"
        ElseIf rbMesa.Checked = True Then
            sNumApp = "1"
            sNombreRep = "Mesa"
        ElseIf rbBack.Checked = True Then
            sNumApp = "2"
            sNombreRep = "Back Agencia"
        ElseIf rbGos.Checked = True Then
            sNumApp = "9"
            sNombreRep = "GOS"
        End If
        Select Case iOpMenu
            Case 1
                objLibreria.CargaPermisos(sNumApp)
                Dim objModPermisos As modPermisos = New modPermisos()
                lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
                lsReporte = lsRutaFolder & "PermisosUsuario" & lsAmbiente & ".rpt"
                rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                objModPermisos.ImprimePermisos(sNombreRep, rptDoc, sNumApp)
                objLibreria.CargaPermisos("9")
            Case 2
                lsRutaFolder = My.Application.Info.DirectoryPath & "\" & objLibreria.sFolderRPT & "\"
                lsReporte = lsRutaFolder & "PermisosBitacora" & lsAmbiente & ".rpt"
                rptDoc.Load(lsReporte, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                Dim BitacoraPermisos As New frmBitacoraPermisos(rptDoc, sNumApp)
                BitacoraPermisos.StartPosition = FormStartPosition.CenterScreen
                BitacoraPermisos.Show()
        End Select

    End Sub
End Class