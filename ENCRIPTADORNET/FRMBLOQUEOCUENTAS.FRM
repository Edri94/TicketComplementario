VERSION 4.00
Begin VB.Form frmBloqueoCuentas 
   BackColor       =   &H00808000&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Bloqueo/Desbloqueo de Cuentas"
   ClientHeight    =   6870
   ClientLeft      =   285
   ClientTop       =   1485
   ClientWidth     =   9975
   ControlBox      =   0   'False
   Height          =   7275
   Left            =   225
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   6870
   ScaleLeft       =   2310
   ScaleMode       =   0  'User
   ScaleTop        =   2700
   ScaleWidth      =   9975
   Top             =   1140
   Width           =   10095
   Begin VB.TextBox txtEstado 
      Height          =   765
      Left            =   8265
      Locked          =   -1  'True
      MultiLine       =   -1  'True
      TabIndex        =   28
      Top             =   795
      Visible         =   0   'False
      Width           =   1590
   End
   Begin VB.TextBox txtRestringida 
      Height          =   285
      Left            =   165
      Locked          =   -1  'True
      MaxLength       =   50
      TabIndex        =   10
      Top             =   1620
      Width           =   5625
   End
   Begin VB.Frame frmAlerta 
      BackColor       =   &H00808000&
      Caption         =   "Cuenta en Alerta"
      ForeColor       =   &H00FFFFFF&
      Height          =   540
      Left            =   150
      TabIndex        =   11
      Top             =   2010
      Width           =   5655
      Begin VB.CheckBox chkAlerta 
         BackColor       =   &H00808000&
         Caption         =   "Alerta por ...."
         Height          =   240
         Left            =   345
         TabIndex        =   12
         Top             =   225
         Width           =   1425
      End
   End
   Begin VB.OptionButton optAlerta 
      BackColor       =   &H00808000&
      Caption         =   "Cuenta en Alerta"
      Height          =   195
      Left            =   825
      TabIndex        =   6
      Top             =   1065
      Width           =   2295
   End
   Begin VB.TextBox txtBloqueoPor 
      Height          =   285
      Left            =   135
      Locked          =   -1  'True
      TabIndex        =   22
      Top             =   5820
      Width           =   9690
   End
   Begin VB.CommandButton cmdActualizar 
      Caption         =   "&Actualizar"
      Height          =   420
      Left            =   8730
      TabIndex        =   27
      Top             =   4170
      Width           =   1110
   End
   Begin VB.TextBox txtCausaAlerta 
      Height          =   480
      Left            =   150
      MaxLength       =   100
      MultiLine       =   -1  'True
      TabIndex        =   14
      Top             =   2925
      Width           =   5655
   End
   Begin VB.ListBox lstDescripcion_Bloqueos 
      Height          =   1035
      Left            =   6840
      TabIndex        =   15
      Top             =   1935
      Visible         =   0   'False
      Width           =   3015
   End
   Begin VB.Frame frmBloqueo 
      BackColor       =   &H00808000&
      Caption         =   "Bloqueo de Cuentas"
      ForeColor       =   &H00FFFFFF&
      Height          =   1755
      Left            =   150
      TabIndex        =   16
      Top             =   3480
      Width           =   5655
      Begin VB.CheckBox chkOtros 
         BackColor       =   &H00808000&
         Caption         =   "Otros"
         Height          =   255
         Left            =   345
         TabIndex        =   20
         Top             =   1245
         Width           =   5000
      End
      Begin VB.CheckBox chkPME 
         BackColor       =   &H00808000&
         Caption         =   "Bloqueo por Desvíos en Depósitos y Retiros P.M.E."
         Height          =   255
         Left            =   345
         TabIndex        =   19
         Top             =   945
         Width           =   5000
      End
      Begin VB.CheckBox chkTDD 
         BackColor       =   &H00808000&
         Caption         =   "Bloqueo por TDD Asociada"
         Height          =   255
         Left            =   345
         TabIndex        =   18
         Top             =   645
         Width           =   5000
      End
      Begin VB.CheckBox chkCreditos 
         BackColor       =   &H00808000&
         Caption         =   "Bloqueo por Crédito Asociado"
         Height          =   255
         Left            =   345
         TabIndex        =   17
         Top             =   330
         Width           =   5000
      End
   End
   Begin VB.OptionButton optRestringida 
      BackColor       =   &H00808000&
      Caption         =   "Cuenta Restringida"
      Height          =   195
      Left            =   3465
      TabIndex        =   7
      Top             =   1065
      Value           =   -1  'True
      Width           =   2655
   End
   Begin VB.TextBox txtCuenta 
      Height          =   285
      Left            =   825
      MaxLength       =   6
      TabIndex        =   1
      Top             =   120
      Width           =   945
   End
   Begin VB.ComboBox CmbAgencia 
      Height          =   315
      ItemData        =   "frmBloqueoCuentas.frx":0000
      Left            =   3555
      List            =   "frmBloqueoCuentas.frx":0002
      TabIndex        =   3
      Top             =   90
      Width           =   6300
   End
   Begin VB.CommandButton cmdSalir 
      Caption         =   "&Salir"
      Height          =   420
      Left            =   8730
      TabIndex        =   26
      Top             =   5265
      Width           =   1110
   End
   Begin VB.CommandButton cmdGuardar 
      Caption         =   "&Guardar"
      Height          =   435
      Left            =   8730
      TabIndex        =   25
      Top             =   4710
      Width           =   1110
   End
   Begin VB.TextBox txtCausaBloqueo 
      Height          =   285
      Left            =   135
      MaxLength       =   100
      MultiLine       =   -1  'True
      TabIndex        =   24
      Top             =   6360
      Width           =   9690
   End
   Begin VB.OptionButton optActiva 
      BackColor       =   &H00808000&
      Caption         =   "Cuenta Activa"
      Height          =   195
      Left            =   825
      TabIndex        =   4
      Top             =   705
      Width           =   2295
   End
   Begin VB.OptionButton optBloqueada 
      BackColor       =   &H00808000&
      Caption         =   "Cuenta Bloqueada"
      Height          =   195
      Left            =   3465
      TabIndex        =   5
      Top             =   705
      Width           =   2535
   End
   Begin VB.Label Label8 
      BackColor       =   &H00808000&
      BackStyle       =   0  'Transparent
      Caption         =   "Restringida por:"
      ForeColor       =   &H00FFFFFF&
      Height          =   210
      Left            =   195
      TabIndex        =   9
      Top             =   1395
      Width           =   1515
   End
   Begin VB.Label Label7 
      BackColor       =   &H00808000&
      Caption         =   "Estados que Presenta:"
      ForeColor       =   &H00FFFFFF&
      Height          =   225
      Left            =   8265
      TabIndex        =   8
      Top             =   570
      Visible         =   0   'False
      Width           =   1620
   End
   Begin VB.Label Label6 
      BackColor       =   &H00808000&
      Caption         =   "Causa de la Alerta:"
      ForeColor       =   &H00FFFFFF&
      Height          =   240
      Left            =   165
      TabIndex        =   13
      Top             =   2700
      Width           =   1425
   End
   Begin VB.Label Label4 
      AutoSize        =   -1  'True
      BackColor       =   &H00808000&
      Caption         =   "Bloqueo de Cuentas por:"
      ForeColor       =   &H00FFFFFF&
      Height          =   195
      Left            =   165
      TabIndex        =   21
      Top             =   5595
      Width           =   1755
   End
   Begin VB.Label Label3 
      Alignment       =   1  'Right Justify
      BackColor       =   &H00808000&
      Caption         =   "Agencia:"
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   2670
      TabIndex        =   2
      Top             =   150
      Width           =   840
   End
   Begin VB.Label Label1 
      Alignment       =   1  'Right Justify
      BackColor       =   &H00808000&
      BackStyle       =   0  'Transparent
      Caption         =   "Cuenta:"
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   0
      TabIndex        =   0
      Top             =   165
      Width           =   780
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      BackColor       =   &H00808000&
      Caption         =   "Causa del bloqueo:"
      ForeColor       =   &H00FFFFFF&
      Height          =   195
      Left            =   165
      TabIndex        =   23
      Top             =   6165
      Width           =   1365
   End
End
Attribute VB_Name = "frmBloqueoCuentas"
Attribute VB_Creatable = False
Attribute VB_Exposed = False
Option Explicit

Private mnProdCont As Long
Private mnStatus As Long
Private mnAlerta As Integer
Private mbActiva As Boolean
Private mbAlerta As Boolean
Private mbRestringida As Boolean
Private mbBloqueada As Boolean
Private msMsg1 As String
Private msMsg2 As String
Private msMsg3 As String
Private msMsg4 As String
Private msMsg5 As String
Private msMsg6 As String
Private Sub CuentaEnAlerta()
  
  If chkCreditos = 0 And _
    chkTDD = 0 And _
    chkPME = 0 And _
    chkOtros = 0 Then
    If chkAlerta = 1 Then
      mnStatus = 1
      mbAlerta = True
      optAlerta.Value = True
    ElseIf chkAlerta = 0 Then
      mnStatus = 1
      mbAlerta = False
    End If
  End If
End Sub
Private Function DatosCompletos() As Boolean

  DatosCompletos = False
  'Si la se eligió la opción cuenta bloqueada y no se capturó la causa, la solicita
  If (chkCreditos = 1 Or chkTDD = 1 Or chkPME = 1 Or chkOtros = 1) And Trim(txtCausaBLOQUEO.Text) = "" Then
    MsgBox "Debe existir una causa de Bloqueo.", vbInformation, "Aviso"
    txtCausaBLOQUEO.SetFocus
    Exit Function
  End If
  'Si la se eligió la opción cuenta en Alerta y no se capturó la causa, la solicita
  If chkAlerta = 1 And txtCausaAlerta = "" Then
    MsgBox "Debe existir una causa de Alerta.", vbInformation, "Aviso"
    txtCausaAlerta.SetFocus
    Exit Function
  End If
  'Checa si los si desea guardar algun estado de bloqueo
  If (chkCreditos = 0 And chkTDD = 0 And chkPME = 0 And chkOtros = 0) And frmBloqueo.Visible Then
    MsgBox "Debe existir un tipo de Bloqueo.", vbInformation, "Aviso"
    ShowDefaultCursor
    Exit Function
  End If
  DatosCompletos = True
End Function

Private Sub Descripcion_Bloqueo()
Dim lsBloqueo As String
  
  lsBloqueo = ""
  If Len(msMsg1) <> 0 Then lsBloqueo = msMsg1
  If Len(msMsg2) <> 0 And Len(lsBloqueo) <> 0 Then
    lsBloqueo = lsBloqueo & ", " & msMsg2
  ElseIf Len(msMsg2) <> 0 Then
    lsBloqueo = msMsg2
  End If
  If Len(msMsg3) <> 0 And Len(lsBloqueo) <> 0 Then
    lsBloqueo = lsBloqueo & ", " & msMsg3
  ElseIf Len(msMsg3) <> 0 Then
    lsBloqueo = msMsg3
  End If
  If Len(msMsg4) <> 0 And Len(lsBloqueo) <> 0 Then
    lsBloqueo = lsBloqueo & ", " & msMsg4
  ElseIf Len(msMsg4) <> 0 Then
    lsBloqueo = msMsg4
  End If
  If Len(msMsg5) <> 0 And Len(lsBloqueo) <> 0 Then
    lsBloqueo = lsBloqueo & ", " & msMsg5
  ElseIf Len(msMsg5) <> 0 Then
    lsBloqueo = msMsg5
  End If
  If Len(msMsg6) <> 0 And Len(lsBloqueo) <> 0 Then
    lsBloqueo = lsBloqueo & ", " & msMsg6
  ElseIf Len(msMsg6) <> 0 Then
    lsBloqueo = msMsg6
  End If
  txtBloqueoPor = lsBloqueo
End Sub
Private Sub LimpiaCampos()
  
  cmbAgencia.Clear
  chkCreditos.Value = 0
  chkTDD.Value = 0
  chkPME.Value = 0
  chkOtros.Value = 0
  chkAlerta.Value = 0
  msMsg1 = ""
  msMsg2 = ""
  msMsg3 = ""
  msMsg4 = ""
  msMsg5 = ""
  msMsg6 = ""
  optActiva.Value = False
  optAlerta.Value = False
  optRestringida.Value = False
  optBloqueada.Value = False
  Label2.Visible = False
  Label4.Visible = False
  Label6.Visible = False
  Label7.Visible = False
  Label8.Visible = False
  lstDescripcion_Bloqueos.Visible = False
  txtEstado = ""
  txtEstado.Visible = False
  txtRestringida = ""
  txtRestringida.Visible = False
  txtCausaAlerta = ""
  txtCausaAlerta.Visible = False
  txtBloqueoPor = ""
  txtBloqueoPor.Visible = False
  txtCausaBLOQUEO.Text = ""
  txtCausaBLOQUEO.Visible = False
  frmAlerta.Visible = False
  frmBloqueo.Visible = False
End Sub
Private Sub LlenaCampos()
Dim lnAgencia As Integer
Dim lbCancelada As Boolean
Dim lnTipoBloq As Integer
  
  mbActiva = False
  mbAlerta = False
  mbRestringida = False
  mbBloqueada = False
  lbCancelada = False
  lnAgencia = cmbAgencia.ItemData(cmbAgencia.ListIndex)
  gs_sql = "Select producto_contratado, "
  gs_sql = gs_sql & "status_producto_global "
  gs_sql = gs_sql & "From "
  gs_sql = gs_sql & "PRODUCTO_CONTRATADO PC, "
  gs_sql = gs_sql & "STATUS_PRODUCTO SP, "
  gs_sql = gs_sql & "PRODUCTO PR "
  gs_sql = gs_sql & "Where "
  gs_sql = gs_sql & " PC.cuenta_cliente = '" & txtCuenta & "'"
  gs_sql = gs_sql & " and PC.agencia = " & lnAgencia
  gs_sql = gs_sql & " and PC.status_producto = SP.status_producto"
  gs_sql = gs_sql & " and PC.producto = PR.producto"
  gs_sql = gs_sql & " and PR.producto_global = 9"
  dbExecQuery gs_sql
  dbGetRecord
  If dbError = 0 Then
    mnProdCont = dbGetValue(0)
    Select Case Val(dbGetValue(1))      'Interpreta el estado de la cuenta
      Case 1
        mbActiva = True
      Case 4
        mbBloqueada = True
      Case 39
        lbCancelada = True
    End Select
    dbEndQuery
    If mbActiva = True Then             'La cuenta esta activa
      gs_sql = "Select descripcion_bloqueo_observacio "
      gs_sql = gs_sql & "From "
      gs_sql = gs_sql & "BLOQUEO_CUENTAS_DINAMICO BC, "
      gs_sql = gs_sql & "BLOQUEO_OBSERVACION BO, "
      gs_sql = gs_sql & "STATUS_BLOQUEO SB "
      gs_sql = gs_sql & "Where"
      gs_sql = gs_sql & " producto_contratado = " & mnProdCont
      gs_sql = gs_sql & " and BO.status_bloqueo = 0"
      gs_sql = gs_sql & " and BC.bloqueo_observacion = BO.bloqueo_observacion"
      gs_sql = gs_sql & " and BO.status_bloqueo = SB.status_bloqueo"
      dbExecQuery gs_sql                'Verifica si la cuenta esta restringida
      dbGetRecord
      If dbError = 0 Then
        txtRestringida = Trim(dbGetValue(0))
        mbRestringida = True
        optRestringida.Value = True
      End If
      dbEndQuery
      gs_sql = "Select bc.bloqueo_observacion, "
      gs_sql = gs_sql & "bo.descripcion_bloqueo_observacio "
      gs_sql = gs_sql & "From "
      gs_sql = gs_sql & "BLOQUEO_CUENTAS_DINAMICO bc, "
      gs_sql = gs_sql & "BLOQUEO_OBSERVACION bo "
      gs_sql = gs_sql & "Where"
      gs_sql = gs_sql & " producto_contratado = " & mnProdCont
      gs_sql = gs_sql & " and bc.bloqueo_observacion = bo.bloqueo_observacion"
      gs_sql = gs_sql & " and posicion_bloqueo = 11"
      dbExecQuery gs_sql                'Verifica si la cuenta se encuentra en alerta
      dbGetRecord
      If dbError = 0 Then
        mnAlerta = Val(dbGetValue(0))
        msMsg6 = Trim(dbGetValue(1))
        mbAlerta = True
        optAlerta.Value = True
        dbEndQuery
        chkAlerta.Value = 1
      End If
      dbEndQuery
      If Not mbRestringida And Not mbAlerta Then optActiva.Value = 1
    End If
    If mbBloqueada = True Then          'La cuenta esta bloqueada
      optBloqueada.Value = True
      gs_sql = "Select bloqueo_observacion "
      gs_sql = gs_sql & "From "
      gs_sql = gs_sql & "BLOQUEO_CUENTAS_DINAMICO "
      gs_sql = gs_sql & "Where producto_contratado = " & mnProdCont
      dbExecQuery gs_sql
      dbGetRecord
      If dbError = 0 Then
        Do While dbError = 0
          lnTipoBloq = Val(dbGetValue(0))
          If lnTipoBloq = 5 Then chkCreditos.Value = 1
          If lnTipoBloq = 6 Then chkTDD.Value = 1
          If lnTipoBloq = 7 Then chkPME.Value = 1
          If lnTipoBloq = 8 Then chkOtros.Value = 1
          Descripcion_Bloqueo
          dbGetRecord
        Loop
      End If
      dbEndQuery
      gs_sql = "Select bc.bloqueo_observacion, "
      gs_sql = gs_sql & "bo.descripcion_bloqueo_observacio "
      gs_sql = gs_sql & "From "
      gs_sql = gs_sql & "BLOQUEO_CUENTAS_DINAMICO bc, "
      gs_sql = gs_sql & "BLOQUEO_OBSERVACION bo "
      gs_sql = gs_sql & "Where"
      gs_sql = gs_sql & " producto_contratado = " & mnProdCont
      gs_sql = gs_sql & " and bc.bloqueo_observacion = bo.bloqueo_observacion"
      gs_sql = gs_sql & " and posicion_bloqueo = 11"
      dbExecQuery gs_sql                  'Busca otros estados de alerta
      dbGetRecord
      If dbError = 0 Then
        msMsg6 = Trim(dbGetValue(1))
        dbEndQuery
        chkAlerta.Value = 1
        If mbAlerta = False Then
          frmAlerta.Visible = True
          Label6.Visible = True
          txtCausaAlerta.Visible = True
          mbAlerta = True
        End If
      End If
      dbEndQuery
      'verifica si existe ademas de los estados anteriores exite el estado restringido
      'cuando la cuenta eje esta bloqueada
      gs_sql = "Select descripcion_bloqueo_observacio "
      gs_sql = gs_sql & "From "
      gs_sql = gs_sql & "BLOQUEO_CUENTAS_DINAMICO BC, "
      gs_sql = gs_sql & "BLOQUEO_OBSERVACION BO, "
      gs_sql = gs_sql & "STATUS_BLOQUEO SB "
      gs_sql = gs_sql & "Where"
      gs_sql = gs_sql & " producto_contratado = " & mnProdCont
      gs_sql = gs_sql & " and BO.status_bloqueo = 0"
      gs_sql = gs_sql & " and BC.bloqueo_observacion = BO.bloqueo_observacion"
      gs_sql = gs_sql & " and BO.status_bloqueo = SB.status_bloqueo"
      dbExecQuery gs_sql
      dbGetRecord
      If dbError = 0 Then
        txtRestringida = Trim(dbGetValue(0))
        mbRestringida = True
        txtRestringida.Visible = True
        Label8.Visible = True
      End If
      dbEndQuery
    End If
    'Si la cuenta está bloqueada se asigna el motivo del bloqueo a txtcausaBLOQUEO
    If mbBloqueada Or mbAlerta Then
      gs_sql = "Select explicacion, "
      gs_sql = gs_sql & "status_bloqueo "
      gs_sql = gs_sql & "From "
      gs_sql = gs_sql & "DETALLE_STATUS "
      gs_sql = gs_sql & "Where producto_contratado = " & mnProdCont
      dbExecQuery gs_sql
      If Not dbError Then
        dbGetRecord
        Do While Not dbError
          If Val(dbGetValue(1)) = 1 Or Val(dbGetValue(1)) = 0 Then txtCausaBLOQUEO = dbGetValue(0)
          If Val(dbGetValue(1)) = 3 Then txtCausaAlerta = dbGetValue(0)
          dbGetRecord
        Loop
      Else
        txtCausaAlerta.Text = ""
        txtCausaBLOQUEO.Text = ""
      End If
      dbEndQuery
    End If
    'Si la cuenta está cancelada habilita todas la opciones en la pantalla
    If lbCancelada Then
      optActiva.Value = False
      MsgBox "Esta cuenta esta cancelada!", vbInformation, "Aviso"
      optActiva.Enabled = False
      optBloqueada.Enabled = False
      optAlerta.Enabled = False
    End If
    Label7.Visible = False
    txtEstado.Text = ""
    txtEstado.Visible = False
    If mbRestringida = True Then txtEstado.Text = "Restringida "
    If mbAlerta = True Then txtEstado.Text = txtEstado.Text & "En Alerta "
    If mbBloqueada = True Then txtEstado.Text = txtEstado.Text & "Bloqueada"
    If Trim(txtEstado.Text) <> "" Then
      txtEstado.Visible = True
      Label7.Visible = True
    End If
  Else
    optActiva.Value = True
    MsgBox "No existe la cuenta.", vbInformation, "Aviso"
    optActiva.Enabled = False
    optBloqueada.Enabled = False
    dbEndQuery
  End If
End Sub

Private Sub chkAlerta_LostFocus()
  If lstDescripcion_Bloqueos.Visible And lstDescripcion_Bloqueos.ListIndex < 0 Then
    MsgBox "Olvido Seleccionar el Concepto de la Alerta", 16, "Aviso"
    lstDescripcion_Bloqueos.SetFocus
    Exit Sub
  End If
End Sub

Private Sub chkCreditos_Click()
  If chkCreditos.Value = 1 Then
    msMsg2 = "Bloqueo Por Crédito Asociado"
  Else
    msMsg2 = ""
  End If
  Descripcion_Bloqueo
  CuentaEnAlerta
  If mbAlerta = False Then optBloqueada.Value = True
End Sub

Private Sub chkAlerta_Click()
  If chkAlerta.Value = 1 And mbAlerta = False Then
    lstDescripcion_Bloqueos.Visible = True
    lstDescripcion_Bloqueos.Clear
    gs_sql = "select bloqueo_observacion,descripcion_bloqueo_observacio "
    gs_sql = gs_sql & " from BLOQUEO_OBSERVACION where posicion_bloqueo=11"
    dbExecQuery gs_sql
    dbGetRecord
    If dbError = 0 Then
      Do While dbError = 0
        lstDescripcion_Bloqueos.AddItem dbGetValue(1)
        lstDescripcion_Bloqueos.ItemData(lstDescripcion_Bloqueos.NewIndex) = dbGetValue(0)
        dbGetRecord
      Loop
    Else
      MsgBox "No se encontró ninguna observación de bloqueo."
      lstDescripcion_Bloqueos.Visible = False
    End If
    dbEndQuery
  Else
    If mbAlerta = False Then
      lstDescripcion_Bloqueos.Visible = False
      msMsg6 = ""
    End If
  End If
  Descripcion_Bloqueo
  CuentaEnAlerta
End Sub
Private Sub chkOtros_Click()
  If chkOtros.Value = 1 Then
    msMsg5 = "Bloqueo Por Otros Conceptos"
  Else
    msMsg5 = ""
  End If
  Descripcion_Bloqueo
  CuentaEnAlerta
  If mbAlerta = False Then optBloqueada.Value = True
End Sub
Private Sub chkPME_Click()
  If chkPME.Value = 1 Then
    msMsg4 = "Bloqueo Por Desvios en PME"
  Else
    msMsg4 = ""
  End If
  Descripcion_Bloqueo
  CuentaEnAlerta
  If mbAlerta = False Then optBloqueada.Value = True
End Sub
Private Sub chkTDD_Click()
  If chkTDD.Value = 1 Then
    msMsg3 = "Bloqueo Por TDD Asociada"
  Else
    msMsg3 = ""
  End If
  Descripcion_Bloqueo
  CuentaEnAlerta
  If mbAlerta = False Then optBloqueada.Value = True
  
End Sub
Private Sub CmbAgencia_Click()
  
  If cmbAgencia.ListIndex >= 0 Then
    chkAlerta.Value = 0
    optActiva.Value = 0
    optActiva.Visible = True
    optActiva.Enabled = False
    optAlerta.Value = 0
    optAlerta.Visible = True
    optAlerta.Enabled = False
    optRestringida.Value = 0
    optRestringida.Visible = True
    optRestringida.Enabled = False
    optBloqueada.Value = 0
    optBloqueada.Visible = True
    optBloqueada.Enabled = False
    cmdGuardar.Enabled = False
    cmdActualizar.Enabled = False
    Label2.Visible = False
    Label4.Visible = False
    Label6.Visible = False
    Label8.Visible = False
    txtRestringida = ""
    txtRestringida.Visible = False
    txtCausaAlerta = ""
    txtCausaAlerta.Visible = False
    txtBloqueoPor = ""
    txtBloqueoPor.Visible = False
    txtCausaBLOQUEO.Text = ""
    txtCausaBLOQUEO.Visible = False
    frmBloqueo.Visible = False
    chkCreditos = 0
    chkTDD = 0
    chkPME = 0
    chkOtros = 0
    frmAlerta.Visible = False
    msMsg1 = ""
    msMsg2 = ""
    msMsg3 = ""
    msMsg4 = ""
    msMsg5 = ""
    msMsg6 = ""
    LlenaCampos
  End If
  
End Sub
Private Sub cmdActualizar_Click()
  txtCuenta_LostFocus
End Sub
Private Sub cmdGuardar_Click()
Dim lnAgencia As Integer
Dim lbComentario As Boolean
Dim lbBloqueo As Boolean
Dim lnBloqueos As Integer
Dim lbCambioAlerta As Boolean
Dim lsMensaje As String

  If DatosCompletos = False Then Exit Sub
  lsMensaje = ""
  lbComentario = False
  lbCambioAlerta = False
  lnAgencia = cmbAgencia.ItemData(cmbAgencia.ListIndex)
  ShowWaitCursor
  'Vefica si el status es Activo que no se encuentre ningun registro en BLOQUEO_CUENTAS_DINAMICO
  If optActiva And (chkCreditos = 1 Or chkTDD = 1 Or chkPME = 1 Or chkOtros = 1) Then
    gs_sql = "Select descripcion_bloqueo_observacio "
    gs_sql = gs_sql & "From "
    gs_sql = gs_sql & "BLOQUEO_CUENTAS_DINAMICO bc, "
    gs_sql = gs_sql & "BLOQUEO_OBSERVACION bo "
    gs_sql = gs_sql & "Where"
    gs_sql = gs_sql & " producto_contratado = " & mnProdCont
    gs_sql = gs_sql & " and bc.bloqueo_observacion = bo.bloqueo_observacion "
    gs_sql = gs_sql & " and bo.posicion_bloqueo in (2,3,4,5)"
    dbExecQuery gs_sql
    dbGetRecord
    If dbError = 0 Then
      Do While dbError = 0
        lsMensaje = lsMensaje & " ° " & dbGetValue(0) & "," & Chr(13)
        dbGetRecord
      Loop
      dbEndQuery
      ShowDefaultCursor
      MsgBox "La cuenta se encuentra Bloqueada y no se puede reactivar debido a:" & Chr(13) & lsMensaje & " Pulse el Boton Actualizar para continuar y deshabilite los bloqueos que existen sobre la cuenta", vbInformation, "Aviso"
      Exit Sub
    End If
    dbEndQuery
  End If
  'verifica que haya seleccionado una opcion de la lista que corresponde a chkAlerta
  If chkAlerta = 1 Then
    gs_sql = "Select bc.bloqueo_observacion "
    gs_sql = gs_sql & "From "
    gs_sql = gs_sql & "BLOQUEO_CUENTAS_DINAMICO bc, "
    gs_sql = gs_sql & "BLOQUEO_OBSERVACION bo "
    gs_sql = gs_sql & "Where"
    gs_sql = gs_sql & " producto_contratado = " & mnProdCont
    gs_sql = gs_sql & " and bc.bloqueo_observacion = bo.bloqueo_observacion"
    gs_sql = gs_sql & " and posicion_bloqueo = 11"
    dbExecQuery gs_sql
    dbGetRecord
    If dbError = 0 Then
      lbBloqueo = True
      lnBloqueos = Val(dbGetValue(0))
    End If
    dbEndQuery
    If lstDescripcion_Bloqueos.ListIndex >= 0 Then
      lnBloqueos = Val(lstDescripcion_Bloqueos.ItemData(lstDescripcion_Bloqueos.ListIndex))
      lbCambioAlerta = True
    End If
  End If

IniciaTrans:
  ShowWaitCursor
  dbBeginTran
  lbBloqueo = False
  gs_sql = "Select count(bc.bloqueo_observacion) "
  gs_sql = gs_sql & "From "
  gs_sql = gs_sql & "BLOQUEO_CUENTAS_DINAMICO bc, "
  gs_sql = gs_sql & "BLOQUEO_OBSERVACION bo "
  gs_sql = gs_sql & "Where"
  gs_sql = gs_sql & " producto_contratado = " & mnProdCont
  gs_sql = gs_sql & " and bc.bloqueo_observacion = bo.bloqueo_observacion"
  gs_sql = gs_sql & " and posicion_bloqueo = 11"
  dbExecQuery gs_sql                              'Se ACTUALIZA el estado del registro correspondiente a chkAlerta
  dbGetRecord
  If dbError <> 0 Then GoTo ErrorTrans
  If Val(dbGetValue(0)) <> 0 Then lbBloqueo = True
  dbEndQuery
  If lbBloqueo = True And chkAlerta = 0 Then
    gs_sql = "Delete BLOQUEO_CUENTAS_DINAMICO from BLOQUEO_CUENTAS_DINAMICO bc, BLOQUEO_OBSERVACION bo "
    gs_sql = gs_sql & " where producto_contratado=" & mnProdCont
    gs_sql = gs_sql & " and bc.bloqueo_observacion=bo.bloqueo_observacion"
    gs_sql = gs_sql & " and posicion_bloqueo=11"
    dbExecQuery gs_sql
    If dbError <> 0 Then GoTo ErrorTrans
    dbEndQuery
    gs_sql = "Select count(*) "
    gs_sql = gs_sql & "From "
    gs_sql = gs_sql & "DETALLE_STATUS "
    gs_sql = gs_sql & "Where"
    gs_sql = gs_sql & " producto_contratado = " & mnProdCont
    gs_sql = gs_sql & " and status_bloqueo = 3"
    dbExecQuery gs_sql
    dbGetRecord
    If Val(dbGetValue(0)) > 0 Then
      dbEndQuery
      gs_sql = "Delete DETALLE_STATUS "
      gs_sql = gs_sql & "Where"
      gs_sql = gs_sql & " producto_contratado = " & mnProdCont
      gs_sql = gs_sql & " and status_bloqueo = 3"
      dbExecQuery gs_sql
      If dbError <> 0 Then GoTo ErrorTrans
    End If
    dbEndQuery
  End If
  If lbBloqueo = False And chkAlerta = 1 Then
    gs_sql = "Insert into BLOQUEO_CUENTAS_DINAMICO (producto_contratado,bloqueo_observacion,"
    gs_sql = gs_sql & " fecha_bloqueo_proceso,consultor_bloquea,fecha_restriccion,"
    gs_sql = gs_sql & " tipo_bloqueo) values(" & mnProdCont & "," & lnBloqueos
    gs_sql = gs_sql & ",'" & sFechaHoy & "'," & gn_Usuario & ",'" & sFechaHoy & " " & Hora_Sistema & "',1)"
    dbExecQuery gs_sql
    If dbError <> 0 Then GoTo ErrorTrans
    dbEndQuery
    gs_sql = "Insert into DETALLE_STATUS (producto_contratado, explicacion, status_bloqueo) values (" & mnProdCont & ",'" & txtCausaAlerta & "',3)"
    dbExecQuery gs_sql
    If dbError <> 0 Then GoTo ErrorTrans
    dbEndQuery
  End If
  If (lbBloqueo = True And lbCambioAlerta = True) Or (lbBloqueo = True And chkAlerta = 1) Then
    gs_sql = "Update BLOQUEO_CUENTAS_DINAMICO set bloqueo_observacion=" & lnBloqueos & ", "
    gs_sql = gs_sql & "consultor_bloquea=" & gn_Usuario & ", fecha_restriccion='" & sFechaHoy & " " & Hora_Sistema & "'"
    gs_sql = gs_sql & " where producto_contratado = " & mnProdCont & " And bloqueo_observacion = " & mnAlerta
    dbExecQuery gs_sql
    If dbError <> 0 Then GoTo ErrorTrans
    dbEndQuery
    gs_sql = "Select count(*) from DETALLE_STATUS "
    gs_sql = gs_sql & " where producto_contratado = " & mnProdCont & " and status_bloqueo=3"
    dbExecQuery gs_sql
    dbGetRecord
    If dbError <> 0 Then GoTo ErrorTrans
    If Val(dbGetValue(0)) <> 0 Then
      gs_sql = "Update DETALLE_STATUS set "
      gs_sql = gs_sql & "explicacion = '" & txtCausaAlerta.Text & "' "
      gs_sql = gs_sql & "Where"
      gs_sql = gs_sql & " producto_contratado = " & mnProdCont
      gs_sql = gs_sql & " and status_bloqueo = 3"
    Else
      gs_sql = "Insert into DETALLE_STATUS ("
      gs_sql = gs_sql & "producto_contratado, explicacion, "
      gs_sql = gs_sql & "status_bloqueo"
      gs_sql = gs_sql & ") values ("
      gs_sql = gs_sql & mnProdCont & ", "
      gs_sql = gs_sql & "'" & txtCausaAlerta.Text & "', "
      gs_sql = gs_sql & "3)"
    End If
    dbEndQuery
    dbExecQuery gs_sql
    If dbError <> 0 Then GoTo ErrorTrans
    dbEndQuery
  End If

  'se ACTUALIZA el estado del registro correspondiente a chkCreditos
  lbBloqueo = False
  gs_sql = "Select count(*) "
  gs_sql = gs_sql & "From "
  gs_sql = gs_sql & "BLOQUEO_CUENTAS_DINAMICO bc, "
  gs_sql = gs_sql & "BLOQUEO_OBSERVACION bo "
  gs_sql = gs_sql & "where"
  gs_sql = gs_sql & " producto_contratado = " & mnProdCont
  gs_sql = gs_sql & " and bc.bloqueo_observacion = bo.bloqueo_observacion"
  gs_sql = gs_sql & " and posicion_bloqueo = 2"
  dbExecQuery gs_sql
  dbGetRecord
  If Val(dbGetValue(0)) = 0 Then
    lbBloqueo = False
  Else
    lbBloqueo = True
  End If
  dbEndQuery
  If lbBloqueo = True And chkCreditos = 0 Then
    gs_sql = "Insert into BLOQUEO_CUENTAS_HISTORICO select bc.producto_contratado,"
    gs_sql = gs_sql & " bc.bloqueo_observacion , bc.fecha_bloqueo_proceso, bc.consultor_bloquea"
    gs_sql = gs_sql & ", '" & sFechaHoy & " " & Hora_Sistema & "'"
    gs_sql = gs_sql & " from BLOQUEO_CUENTAS_DINAMICO bc, BLOQUEO_OBSERVACION bo"
    gs_sql = gs_sql & " Where producto_contratado =" & mnProdCont
    gs_sql = gs_sql & " and bc.bloqueo_observacion=bo.bloqueo_observacion"
    gs_sql = gs_sql & " and bo.posicion_bloqueo=2"
    dbExecQuery gs_sql
    If dbError <> 0 Then GoTo ErrorTrans
    dbEndQuery
    gs_sql = "Delete BLOQUEO_CUENTAS_DINAMICO from BLOQUEO_CUENTAS_DINAMICO bc, BLOQUEO_OBSERVACION bo "
    gs_sql = gs_sql & " where producto_contratado=" & mnProdCont
    gs_sql = gs_sql & " and bc.bloqueo_observacion=bo.bloqueo_observacion"
    gs_sql = gs_sql & " and posicion_bloqueo=2"
    dbExecQuery gs_sql
    If dbError <> 0 Then GoTo ErrorTrans
    dbEndQuery
  End If
  If lbBloqueo = False And chkCreditos = 1 Then
    gs_sql = "Insert into BLOQUEO_CUENTAS_DINAMICO (producto_contratado,bloqueo_observacion,"
    gs_sql = gs_sql & " fecha_bloqueo_proceso,consultor_bloquea,fecha_restriccion,"
    gs_sql = gs_sql & " tipo_bloqueo) values(" & mnProdCont & ",5"
    gs_sql = gs_sql & ",'" & sFechaHoy & "'," & gn_Usuario & ",'" & sFechaHoy & " " & Hora_Sistema & "',1)"
    dbExecQuery gs_sql
    If dbError <> 0 Then GoTo ErrorTrans
    dbEndQuery
  End If
  'se ACTUALIZA el estado del registro correspondiente a chkTDD
  lbBloqueo = False
  gs_sql = "Select count(*) from BLOQUEO_CUENTAS_DINAMICO bc, BLOQUEO_OBSERVACION bo"
  gs_sql = gs_sql & " where producto_contratado=" & mnProdCont
  gs_sql = gs_sql & " and bc.bloqueo_observacion=bo.bloqueo_observacion"
  gs_sql = gs_sql & " and posicion_bloqueo=3"
  dbExecQuery gs_sql
  dbGetRecord
  If Val(dbGetValue(0)) = 0 Then
    lbBloqueo = False
  Else
    lbBloqueo = True
  End If
  dbEndQuery
  If lbBloqueo = True And chkTDD = 0 Then
    gs_sql = "Insert into BLOQUEO_CUENTAS_HISTORICO select bc.producto_contratado,"
    gs_sql = gs_sql & " bc.bloqueo_observacion , bc.fecha_bloqueo_proceso, bc.consultor_bloquea"
    gs_sql = gs_sql & ", '" & sFechaHoy & " " & Hora_Sistema & "'"
    gs_sql = gs_sql & " from BLOQUEO_CUENTAS_DINAMICO bc, BLOQUEO_OBSERVACION bo"
    gs_sql = gs_sql & " Where producto_contratado =" & mnProdCont
    gs_sql = gs_sql & " and bc.bloqueo_observacion=bo.bloqueo_observacion"
    gs_sql = gs_sql & " and bo.posicion_bloqueo=3"
    dbExecQuery gs_sql
    If dbError <> 0 Then GoTo ErrorTrans
    dbEndQuery
    gs_sql = "Delete BLOQUEO_CUENTAS_DINAMICO from BLOQUEO_CUENTAS_DINAMICO bc, BLOQUEO_OBSERVACION bo "
    gs_sql = gs_sql & " where producto_contratado=" & mnProdCont
    gs_sql = gs_sql & " and bc.bloqueo_observacion=bo.bloqueo_observacion"
    gs_sql = gs_sql & " and posicion_bloqueo=3"
    dbExecQuery gs_sql
    If dbError <> 0 Then GoTo ErrorTrans
    dbEndQuery
  End If
  If lbBloqueo = False And chkTDD = 1 Then
    gs_sql = "Insert into BLOQUEO_CUENTAS_DINAMICO (producto_contratado,bloqueo_observacion,"
    gs_sql = gs_sql & " fecha_bloqueo_proceso,consultor_bloquea,fecha_restriccion,"
    gs_sql = gs_sql & " tipo_bloqueo) values(" & mnProdCont & ",6"
    gs_sql = gs_sql & ",'" & sFechaHoy & "'," & gn_Usuario & ",'" & sFechaHoy & " " & Hora_Sistema & "',1)"
    dbExecQuery gs_sql
    If dbError <> 0 Then GoTo ErrorTrans
    dbEndQuery
  End If
  'se ACTUALIZA el estado del registro correspondiente a chkPME
  lbBloqueo = False
  gs_sql = "Select count(*) from BLOQUEO_CUENTAS_DINAMICO bc, BLOQUEO_OBSERVACION bo"
  gs_sql = gs_sql & " where producto_contratado=" & mnProdCont
  gs_sql = gs_sql & " and bc.bloqueo_observacion=bo.bloqueo_observacion"
  gs_sql = gs_sql & " and posicion_bloqueo=4"
  dbExecQuery gs_sql
  dbGetRecord
  If Val(dbGetValue(0)) = 0 Then
    lbBloqueo = False
  Else
    lbBloqueo = True
  End If
  dbEndQuery
  If lbBloqueo = True And chkPME = 0 Then
    gs_sql = "Insert into BLOQUEO_CUENTAS_HISTORICO select bc.producto_contratado,"
    gs_sql = gs_sql & " bc.bloqueo_observacion , bc.fecha_bloqueo_proceso, bc.consultor_bloquea"
    gs_sql = gs_sql & ", '" & sFechaHoy & " " & Hora_Sistema & "'"
    gs_sql = gs_sql & " from BLOQUEO_CUENTAS_DINAMICO bc, BLOQUEO_OBSERVACION bo"
    gs_sql = gs_sql & " Where producto_contratado =" & mnProdCont
    gs_sql = gs_sql & " and bc.bloqueo_observacion=bo.bloqueo_observacion"
    gs_sql = gs_sql & " and bo.posicion_bloqueo=4"
    dbExecQuery gs_sql
    If dbError <> 0 Then GoTo ErrorTrans
    dbEndQuery
    gs_sql = "Delete BLOQUEO_CUENTAS_DINAMICO from BLOQUEO_CUENTAS_DINAMICO bc, BLOQUEO_OBSERVACION bo "
    gs_sql = gs_sql & " where producto_contratado=" & mnProdCont
    gs_sql = gs_sql & " and bc.bloqueo_observacion=bo.bloqueo_observacion"
    gs_sql = gs_sql & " and posicion_bloqueo=4"
    dbExecQuery gs_sql
    If dbError <> 0 Then GoTo ErrorTrans
    dbEndQuery
  End If
  If lbBloqueo = False And chkPME = 1 Then
    gs_sql = "Insert into BLOQUEO_CUENTAS_DINAMICO (producto_contratado,bloqueo_observacion,"
    gs_sql = gs_sql & " fecha_bloqueo_proceso,consultor_bloquea,fecha_restriccion,"
    gs_sql = gs_sql & " tipo_bloqueo) values(" & mnProdCont & ",7"
    gs_sql = gs_sql & ",'" & sFechaHoy & "'," & gn_Usuario & ",'" & sFechaHoy & " " & Hora_Sistema & "',1)"
    dbExecQuery gs_sql
    If dbError <> 0 Then GoTo ErrorTrans
    dbEndQuery
  End If
  'se ACTUALIZA el estado del registro correspondiente a chkOtros
  lbBloqueo = False
  gs_sql = "Select count(*) from BLOQUEO_CUENTAS_DINAMICO bc, BLOQUEO_OBSERVACION bo"
  gs_sql = gs_sql & " where producto_contratado=" & mnProdCont
  gs_sql = gs_sql & " and bc.bloqueo_observacion=bo.bloqueo_observacion"
  gs_sql = gs_sql & " and posicion_bloqueo=5"
  dbExecQuery gs_sql
  dbGetRecord
  If Val(dbGetValue(0)) = 0 Then
    lbBloqueo = False
  Else
    lbBloqueo = True
  End If
  dbEndQuery
  If lbBloqueo = True And chkOtros = 0 Then
    gs_sql = "Insert into BLOQUEO_CUENTAS_HISTORICO select bc.producto_contratado,"
    gs_sql = gs_sql & " bc.bloqueo_observacion , bc.fecha_bloqueo_proceso, bc.consultor_bloquea"
    gs_sql = gs_sql & ", '" & sFechaHoy & " " & Hora_Sistema & "'"
    gs_sql = gs_sql & " from BLOQUEO_CUENTAS_DINAMICO bc, BLOQUEO_OBSERVACION bo"
    gs_sql = gs_sql & " Where producto_contratado =" & mnProdCont
    gs_sql = gs_sql & " and bc.bloqueo_observacion=bo.bloqueo_observacion"
    gs_sql = gs_sql & " and bo.posicion_bloqueo=5"
    dbExecQuery gs_sql
    If dbError <> 0 Then GoTo ErrorTrans
    dbEndQuery
    gs_sql = "Delete BLOQUEO_CUENTAS_DINAMICO from BLOQUEO_CUENTAS_DINAMICO bc, BLOQUEO_OBSERVACION bo "
    gs_sql = gs_sql & " where producto_contratado=" & mnProdCont
    gs_sql = gs_sql & " and bc.bloqueo_observacion=bo.bloqueo_observacion"
    gs_sql = gs_sql & " and posicion_bloqueo=5"
    dbExecQuery gs_sql
    If dbError <> 0 Then GoTo ErrorTrans
    dbEndQuery
  End If
  If lbBloqueo = False And chkOtros = 1 Then
    gs_sql = "Insert into BLOQUEO_CUENTAS_DINAMICO (producto_contratado,bloqueo_observacion,"
    gs_sql = gs_sql & " fecha_bloqueo_proceso,consultor_bloquea,fecha_restriccion,"
    gs_sql = gs_sql & " tipo_bloqueo) values(" & mnProdCont & ",8"
    gs_sql = gs_sql & ",'" & sFechaHoy & "'," & gn_Usuario & ",'" & sFechaHoy & " " & Hora_Sistema & "',1)"
    dbExecQuery gs_sql
    If dbError <> 0 Then GoTo ErrorTrans
    dbEndQuery
  End If
  'Si se eligió la opción de cuenta activa se asigna un status
  If optActiva.Value Then
    mnStatus = 1
  Else
    mnStatus = 4
  End If
  'Para actualizar el status si la unica opcion es chkAlerta el status no será bloqueado si no activa
  CuentaEnAlerta
  'Actualiza el status en la tabla de PRODUCTO_CONTRATADO
  gs_sql = "Update PRODUCTO_CONTRATADO set status_producto = SP.status_producto"
  gs_sql = gs_sql & " from STATUS_PRODUCTO SP"
  gs_sql = gs_sql & " where PRODUCTO_CONTRATADO.cuenta_cliente = '" & txtCuenta & "'"
  gs_sql = gs_sql & " and PRODUCTO_CONTRATADO.producto_contratado = " & mnProdCont
  gs_sql = gs_sql & " and PRODUCTO_CONTRATADO.agencia = " & lnAgencia
  gs_sql = gs_sql & " and SP.status_producto_global = " & mnStatus
  gs_sql = gs_sql & " and SP.producto= PRODUCTO_CONTRATADO.producto"
  dbExecQuery gs_sql
  If dbError <> 0 Then GoTo ErrorTrans
  dbEndQuery
  'si el status es 4 selecciona informacion de la tabla DETALLE_STATUS para ese producto si no hay nada en la tabla
  'inserta la información capturada en la pantalla de lo contrario solo actualiza la explicación
  If mnStatus = 4 Then
    lbComentario = False
    gs_sql = "Select count(*) from DETALLE_STATUS "
    gs_sql = gs_sql & " where producto_contratado = " & mnProdCont & " and status_bloqueo=1"
    dbExecQuery gs_sql
    dbGetRecord
    If Val(dbGetValue(0)) <> 0 Then lbComentario = True
    dbEndQuery
    If lbComentario Then
      gs_sql = "Update DETALLE_STATUS set explicacion = '" & Trim(txtCausaBLOQUEO.Text) & "' where producto_contratado = " & mnProdCont & " And status_bloqueo = 1"
    Else
      gs_sql = "Insert into DETALLE_STATUS (producto_contratado, explicacion, status_bloqueo) values (" & mnProdCont & ",'" & Trim(txtCausaBLOQUEO.Text) & "',1)"
    End If
    dbExecQuery gs_sql
    If dbError <> 0 Then GoTo ErrorTrans
    dbEndQuery
  Else
    gs_sql = "Delete from DETALLE_STATUS where (producto_contratado = " & mnProdCont & " And status_bloqueo = 1)"
    gs_sql = gs_sql & " or  (producto_contratado =" & mnProdCont & " and status_bloqueo=null)"
    dbExecQuery gs_sql
    If dbError <> 0 Then GoTo ErrorTrans
    dbEndQuery
  End If
  dbCommit
  MsgBox "El estado de la cuenta ha cambiado.", vbInformation, "Bloqueo de Cuentas"
  ShowDefaultCursor
  Exit Sub
  
ErrorTrans:
  dbRollback
  ShowDefaultCursor
  If MsgBox("Ha ocurrido un error al guardar la operación. Se recomienda Cancelar la operación y capturar de nuevo", vbRetryCancel + vbCritical, "Aviso") = vbRetry Then
    GoTo IniciaTrans
  End If
End Sub
Private Sub cmdSalir_Click()
  
  Unload Me
End Sub
Private Sub Form_Load()
  
  Me.Top = 2115
  Me.Left = 705
  CenterForm Me
  optActiva.Visible = True
  optActiva.Enabled = False
  optAlerta.Visible = True
  optAlerta.Enabled = False
  optRestringida.Visible = True
  optRestringida.Enabled = False
  optBloqueada.Visible = True
  optBloqueada.Enabled = False
  cmdGuardar.Enabled = False
  cmdActualizar.Enabled = False
  Label2.Visible = False
  Label4.Visible = False
  Label6.Visible = False
  Label8.Visible = False
  txtRestringida.Visible = False
  txtCausaAlerta.Visible = False
  txtBloqueoPor.Visible = False
  txtCausaBLOQUEO.Visible = False
  frmBloqueo.Visible = False
  frmAlerta.Visible = False
End Sub
Private Sub LlenaComboAgencias()
  
  gs_sql = "select ag.prefijo_agencia+'-'+cte.cuenta_cliente+' '+"
  gs_sql = gs_sql & " rtrim(rtrim(nombre_cliente)+' '+rtrim(apellido_paterno)+"
  gs_sql = gs_sql & "' '+rtrim(apellido_materno))+'('+"
  gs_sql = gs_sql & " ag.descripcion_agencia+')', ag.agencia"
  gs_sql = gs_sql & " from " & DBCATALOGOS & "..CLIENTE cte, PRODUCTO_CONTRATADO PC, "
  gs_sql = gs_sql & " " & DBCATALOGOS & "..AGENCIA ag, PRODUCTO P"
  gs_sql = gs_sql & " where cte.cuenta_cliente = '" & txtCuenta & "'"
  gs_sql = gs_sql & " and PC.cuenta_cliente= cte.cuenta_cliente"
  gs_sql = gs_sql & " and PC.agencia= cte.agencia"
  gs_sql = gs_sql & " and PC.producto= P.producto"
  gs_sql = gs_sql & " and P.producto_global=9"
  gs_sql = gs_sql & " and PC.agencia= ag.agencia"
  gs_sql = gs_sql & " and PC.agencia " & GsPermisoAgencia
  dbExecQuery gs_sql
  dbGetRecord
  If dbError = 0 Then
    Do While dbError = 0
      cmbAgencia.AddItem dbGetValue(0)
      cmbAgencia.ItemData(cmbAgencia.NewIndex) = CLng(dbGetValue(1))
      dbGetRecord
    Loop
  Else
    MsgBox "No se encontró el cliente para ese número de cuenta."
  End If
  dbEndQuery
  If cmbAgencia.ListCount = 1 Then cmbAgencia.ListIndex = 0
  If cmbAgencia.ListCount > 1 Then
    gs_sql = SendMessage(cmbAgencia.hwnd, 335, 1, 0)
  End If
End Sub

Private Sub lstDescripcion_Bloqueos_Click()
  
  If chkAlerta.Value = 1 Then
    lstDescripcion_Bloqueos.SetFocus
    gs_sql = "select descripcion_bloqueo_observacio from BLOQUEO_OBSERVACION "
    gs_sql = gs_sql & " where bloqueo_observacion= " & lstDescripcion_Bloqueos.ItemData(lstDescripcion_Bloqueos.ListIndex)
    dbExecQuery gs_sql
    dbGetRecord
    If dbError = 0 Then
      msMsg6 = Trim(dbGetValue(0))
      txtCausaAlerta = ""
    Else
      msMsg6 = ""
    End If
    dbEndQuery
  Else
    msMsg6 = ""
  End If
  Descripcion_Bloqueo
  lstDescripcion_Bloqueos.Visible = False
End Sub
Private Sub optActiva_Click()

  'Si la cuenta se encontraba bloqueada y se quiere activar nuevamente
  If mbBloqueada = True Then
    'Vefica que no se encuentre ningun registro en BLOQUEO_CUENTAS_DINAMICO
    If chkCreditos = 1 Or chkTDD = 1 Or chkPME = 1 Or chkOtros = 1 Then
      MsgBox "Para Activar la Cuenta deberá deshabilitar primero los bloqueos que existen sobre ésta!", vbInformation, "Aviso"
      ShowDefaultCursor
      Exit Sub
    End If
  End If
  optActiva.Visible = True
  optActiva.Enabled = True
  optAlerta.Visible = True
  optAlerta.Enabled = True
  optRestringida.Visible = False
  optRestringida.Enabled = False
  optBloqueada.Visible = True
  optBloqueada.Enabled = True
  cmdGuardar.Enabled = False
  cmdActualizar.Enabled = False
  Label2.Visible = False
  Label4.Visible = False
  Label6.Visible = False
  Label8.Visible = False
  txtRestringida.Visible = False
  txtBloqueoPor.Visible = False
  txtCausaBLOQUEO.Visible = False
  txtCausaAlerta.Visible = False
  frmBloqueo.Visible = False
  If frmAlerta.Visible Then
    frmAlerta.Visible = False
    lstDescripcion_Bloqueos.Visible = False
  End If
  If mbBloqueada Then
    cmdActualizar.Enabled = True
    cmdGuardar.Enabled = True
  End If

End Sub
Private Sub optAlerta_Click()
  
  optActiva.Visible = True
  optActiva.Enabled = False
  optAlerta.Visible = True
  optAlerta.Enabled = True
  optRestringida.Visible = False
  optRestringida.Enabled = False
  optBloqueada.Visible = True
  optBloqueada.Enabled = True
  cmdGuardar.Enabled = True
  cmdActualizar.Enabled = True
  Label6.Visible = True
  Label4.Visible = True
  txtBloqueoPor.Visible = True
  txtCausaAlerta.Visible = True
  frmAlerta.Visible = True
  Descripcion_Bloqueo
  If chkCreditos = 0 And chkTDD = 0 And chkPME = 0 And chkOtros = 0 Then
    frmBloqueo.Visible = False
    Label2.Visible = False
    txtCausaBLOQUEO.Visible = False
  End If
End Sub
Private Sub optBloqueada_Click()
  
  optActiva.Visible = True
  optActiva.Enabled = True
  optAlerta.Visible = True
  optAlerta.Enabled = True
  optRestringida.Visible = False
  optRestringida.Enabled = False
  optBloqueada.Visible = True
  optBloqueada.Enabled = True
  cmdGuardar.Enabled = True
  cmdActualizar.Enabled = True
  Label2.Visible = True
  Label4.Visible = True
  txtBloqueoPor.Visible = True
  txtCausaBLOQUEO.Visible = True
  If Not frmBloqueo.Visible Then
    frmBloqueo.Visible = True
    Descripcion_Bloqueo
  End If
  If mbRestringida Then
   optActiva.Visible = True
   optActiva.Enabled = False
   optRestringida.Visible = True
   optRestringida.Enabled = True
   optBloqueada.Visible = True
   optBloqueada.Enabled = True
  End If
  If chkAlerta = 0 Then
    frmAlerta.Visible = False
    Label6.Visible = False
    txtCausaAlerta.Visible = False
  End If
End Sub
Private Sub optRestringida_Click()
  
  optActiva.Visible = True
  optActiva.Enabled = False
  optAlerta.Visible = True
  optAlerta.Enabled = True
  optRestringida.Visible = True
  optRestringida.Enabled = True
  optBloqueada.Visible = True
  optBloqueada.Enabled = True
  cmdGuardar.Enabled = False
  cmdActualizar.Enabled = False
  txtRestringida.Visible = True
  Label8.Visible = True
  frmBloqueo.Visible = False
End Sub


Private Sub txtCausaBLOQUEO_KeyPress(KeyAscii As Integer)

  If KeyAscii = 13 Then
    If cmdGuardar.Enabled = True Then cmdGuardar.SetFocus
  End If
End Sub
Private Sub txtCuenta_KeyPress(KeyAscii As Integer)
  
  If KeyAscii = 13 Then txtCuenta_LostFocus
End Sub
Private Sub txtCuenta_LostFocus()
  
  If Trim(txtCuenta) <> "" Then
    cmdSalir.SetFocus
    LimpiaCampos
    LlenaComboAgencias
  End If
End Sub
