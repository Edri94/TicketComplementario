Public Class frmConsulta

    'Option Explicit On

    Dim mbTraduce As Boolean   'No se usa la variable TRADUCE por ocuparse esta pantalla en LA Enquiry
    Dim mbFED As Boolean       'Bandera para identificar consultas del FED
    Public mnTipo As Byte         'Variable para identificar el criterio de Consulta
    'Dim gs_sql As String
    Dim row As DataRow


    '-------------------------------------------------------------------------
    'Busca el documento u operacion (valída el tipo de operacion) a consultar
    '-------------------------------------------------------------------------
    Public Sub Consulta(ByVal Tipo As Byte, ByVal Folio As String, FED As String) 'PrevForm As Form, FED As Boolean)

        Dim lsTicket As String
        Dim lbConsFED As Boolean
        Dim lnFichas As Integer

        Dim d As New Datasource
        Dim dt As New DataTable

        Cursor = System.Windows.Forms.Cursors.WaitCursor

        lnFichas = 0                          'Puesta en cero de varibles indicadoras
        lbConsFED = False
        lsTicket = Trim(Folio)
        If FED = "FED" Then            'Es consulta para el FED
            lbConsFED = True
        End If



        'Inicio Obtener el Origen del Usuario para colocar el idioma
        Dim dsu As New Datasource
        Dim dtu As New DataTable
        gs_Sql = "select origen_usuario from Catalogos.dbo.Usuario where login = '" + nameUser + "'"
        'dbExecQuery gs_sql                              'Busca datos particulares del documento
        'dbGetRecord
        dtu = New DataTable
        dtu = dsu.RealizaConsulta(gs_Sql)
        Dim li_OrigenUsuario As Integer
        If dtu.Rows.Count > 0 Then
            'If dbError = 0 Then
            row = dtu.Rows(0)
            li_OrigenUsuario = row.Item("origen_usuario").ToString
            If li_OrigenUsuario = 11 Then
                lbConsFED = True
            End If
        End If
        'Fin Obteber Origen del Usuario para colocar el idioma 




        If Tipo = 0 Then                      'Es consulta de documentos
            gs_Sql = "Select count(*) from GOS.dbo.DOCUMENTO where documento = " & lsTicket
            'MsgBox("El sql en frmConsulta " + gs_Sql, MessageBoxButtons.OK)
        ElseIf Tipo = 1 Then                  'Es consulta de Ticket por Ticket
            If lbConsFED = True Then
                gs_Sql = " Select count(*) "
                gs_Sql = gs_Sql & " from "
                gs_Sql = gs_Sql & " GOS.dbo.T_OPERACION o, "
                gs_Sql = gs_Sql & "TICKET.dbo.OPERACION_DEFINIDA od"
                gs_Sql = gs_Sql & " where operacion = " & lsTicket
                gs_Sql = gs_Sql & " and o.operacion_definida =  od.operacion_definida"
                'gs_Sql = gs_Sql & " and od.agencia " & gs_PermisoAgencias
            Else
                gs_Sql = "Select count(*) from GOS.dbo.T_OPERACION where operacion = " & lsTicket
            End If
        ElseIf Tipo = 2 Then                  'Es consulta de Ticket por Ficha CED
            If lbConsFED = True Then
                gs_Sql = " Select count(*) "
                gs_Sql = gs_Sql & " from "
                gs_Sql = gs_Sql & " T_OPERACION o, "
                gs_Sql = gs_Sql & " TICKET.dbo.OPERACION_DEFINIDA od , "
                gs_Sql = gs_Sql & " T_RETIRO_PME r"
                gs_Sql = gs_Sql & " where referencia = " & lsTicket
                gs_Sql = gs_Sql & " and o.operacion_definida =  od.operacion_definida"
                gs_Sql = gs_Sql & " and o.operacion = r.operacion"
                'gs_Sql = gs_Sql & " and od.agencia " & gs_PermisoAgencias
            Else
                gs_Sql = "Select count(*) from T_RETIRO_PME where referencia = " & lsTicket
            End If
            'dbExecQuery gs_Sql                  'Busca Retiros con el numero de Ficha
            'dbGetRecord
            'lnFichas = Val(dbGetValue(0))       'Agrega al conteo de operaciones con Ficha
            'dbEndQuery
            If lbConsFED = True Then
                gs_Sql = " Select count(*) "
                gs_Sql = gs_Sql & " from "
                gs_Sql = gs_Sql & " T_OPERACION o, "
                gs_Sql = gs_Sql & " TICKET.dbo.OPERACION_DEFINIDA od , "
                gs_Sql = gs_Sql & " T_DEPOSITO_PME d"
                gs_Sql = gs_Sql & " where referencia = " & lsTicket
                gs_Sql = gs_Sql & " and o.operacion_definida =  od.operacion_definida"
                gs_Sql = gs_Sql & " and o.operacion = d.operacion"
                'gs_Sql = gs_Sql & " and od.agencia " & gs_PermisoAgencias
            Else
                gs_Sql = "Select count(*) from T_DEPOSITO_PME where referencia = " & lsTicket
            End If
        End If
        dt = d.RealizaConsulta(gs_Sql)
        If dt.Rows.Count = 0 Then
            If Tipo = 0 Then                    'Es consulta de documentos
                MsgBox("No se encuentra el Documento " & lsTicket & " en la base de datos.", vbInformation, "Documento Invalido")
            ElseIf Tipo = 1 Then                'Es consulta de Ticket por Ticket
                If mbTraduce = True Then
                    MsgBox("Ticket number " & lsTicket & " not found in Data Base.", vbInformation, "Invalid Ticket")
                Else
                    MsgBox("No se encuentra el Ticket " & lsTicket & " en la base de datos.", vbInformation, "Ticket Invalido")
                End If
            ElseIf Tipo = 2 Then                'Es consulta de Ticket por Ficha CED
                If lnFichas = 0 Then              'Si el conteo de operaciones con Ficha es 0
                    If mbTraduce = True Then
                        MsgBox("Ticket SLIP number " & lsTicket & " not found in Data Base.", vbInformation, "Invalid SLIP")
                    Else
                        MsgBox("No se encuentran operaciones con la Ficha " & lsTicket & " en la base de datos.", vbInformation, "Ficha CED Invalida")
                    End If
                Else                              'Si se encontraron operaciones con Ficha previamente
                    'GoTo ConsultaFicha              'Continua con el proceso
                End If
            End If
            Exit Sub
        Else
        End If
        If Tipo = 0 Then                      'El folio existe y es consulta de documentos
            'MsgBox("Vamos a consultar el doc en frmConsDocto " & lsTicket & " en la base de datos.", vbInformation, "Documento Valido")
            Dim frmConsDoctoDesdeConsulta As New frmConsDocto
            If frmConsDoctoDesdeConsulta.Muestra(lsTicket, lbConsFED, mnTipo) Then frmConsDoctoDesdeConsulta.Show()
            Cursor = System.Windows.Forms.Cursors.Default
            ElseIf Tipo = 1 Then
                Dim dtt As DataTable
                Dim ds As New Datasource
                Dim lblOpe As String
                gs_Sql = "Select operacion_definida_global, "
                gs_Sql = gs_Sql & "descripcion_operacion_definida "
                gs_Sql = gs_Sql & "From "
                gs_Sql = gs_Sql & " TICKET.dbo.PRODUCTO_CONTRATADO PC, "
                gs_Sql = gs_Sql & " TICKET.dbo.OPERACION_DEFINIDA OD, "
                gs_Sql = gs_Sql & " GOS.dbo.T_OPERACION OP "
                gs_Sql = gs_Sql & "where "
                gs_Sql = gs_Sql & "PC.producto_contratado = OP.producto_contratado and "
                gs_Sql = gs_Sql & "OD.operacion_definida = OP.operacion_definida and "
                gs_Sql = gs_Sql & "OP.operacion = " & lsTicket

            dtt = New DataTable
            dtt = ds.RealizaConsulta(gs_Sql)
            If dtt.Rows.Count > 0 Then
                'If dbError = 0 Then
                row = dtt.Rows(0)
                'value = row.Item("agecliesufijo")
                'lblCta.Text = CStr(value)                'Val(dbGetValue(0))
                lblOpe = row.Item("operacion_definida_global").ToString
                Select Case lblOpe      'Llama la pantalla de consulta dependiendo de la operacion definida
                    Case 87                             'Retiro por Traspaso Misma Agencia
                        'frmConsTrasp.Muestra(lsTicket, lbConsFED, mnTipo)
                        MsgBox("Consulta del Retiro por Traspaso Misma Agencia " + lsTicket + ", se encuentra en Construcción.", MessageBoxButtons.OK)
                    Case 583                            'Deposito por Sucursal en Firme
                        frmConsDepsRets.Muestra(lsTicket, lbConsFED, mnTipo)
                    Case 81                           'Retiro por Orden de Pago
                        'frmConsROP.Muestra lsTicket, lbConsFED, mnTipo
                        MsgBox("Consulta de Retiro por Orden de Pago " + lsTicket + ", se encuentra en Construcción.", MessageBoxButtons.OK)
                    Case 83                           'Retiro por Sucursal en Firme
                        frmConsDepsRets.Muestra(lsTicket, lbConsFED, mnTipo)
                    Case 86                           'Retiro por Orden de Pago Otras Divisas
                        'frmConsROP.Muestra lsTicket, lbConsFED, mnTipo
                        MsgBox("Consulta del Retiro por Orden de Pago Otras Divisas " + lsTicket + ", se encuentra en Construcción.", MessageBoxButtons.OK)
                    Case 88                           'Retiro por Devolución de Cheque
                        frmConsDepsRets.Muestra(lsTicket, lbConsFED, mnTipo)
                    Case 89                           'Retiro por Area Interna
                        frmConsDepsRets.Muestra(lsTicket, lbConsFED, mnTipo)
                    Case 97                           'Retiro por Traspaso Entre Agencias
                        'frmConsTrasp.Muestra lsTicket, lbConsFED, mnTipo
                        MsgBox("Consulta del Retiro por Traspaso Entre Agencias " + lsTicket + ", se encuentra en Construcción.", MessageBoxButtons.OK)
                    Case 583                          'Deposito por Sucursal en Firme
                        frmConsDepsRets.Muestra(lsTicket, lbConsFED, mnTipo)
                    Case 588                          'Deposito por Sucursal S.B.F.
                        frmConsDepsRets.Muestra(lsTicket, lbConsFED, mnTipo)
                    Case 589                          'Deposito por Area Interna
                        frmConsDepsRets.Muestra(lsTicket, lbConsFED, mnTipo)
                    Case 587                          'Deposito por Traspaso Misma Agencia
                        'frmConsTrasp.Muestra lsTicket, lbConsFED, mnTipo
                        MsgBox("Consulta del Deposito por Traspaso Misma Agencia " + lsTicket + ", se encuentra en Construcción.", MessageBoxButtons.OK)
                    Case 590                          'Deposito por Sucursal 24 Hrs
                        frmConsDepsRets.Muestra(lsTicket, lbConsFED, mnTipo)
                    Case 591                          'Deposito por Area Interna 24 Hrs
                        frmConsDepsRets.Muestra(lsTicket, lbConsFED, mnTipo)
                    Case 592                          'Deposito por Area Interna S.B.F.
                        frmConsDepsRets.Muestra(lsTicket, lbConsFED, mnTipo)
                    Case 597                          'Deposito por Traspaso Entre Agencias
                        'frmConsTrasp.Muestra lsTicket, lbConsFED, mnTipo
                        MsgBox("Consulta del Deposito por Traspaso Entre Agencias " + lsTicket + ", se encuentra en Construcción.", MessageBoxButtons.OK)
                    Case Else
                        If lbConsFED = True Then       'Es consulta para el FED
                            MsgBox("The Ticket " & lsTicket & " is not a valid operation type.", vbInformation, "Invalid Ticket")
                        Else
                            MsgBox("La operacion " & lsTicket & " es un " & Trim(row.Item("descripcion_operacion_definida").ToString) & " invalido para GOS.", vbInformation, "Operacion Invalida")
                        End If
                        'If Not IsMissing(PrevForm) Then 'Si la consulta biene de alguna otra pantalla
                        '    If TypeOf PrevForm Is Form Then
                        '        If PrevForm.WindowState = 1 Then PrevForm.WindowState = 2
                        '    End If
                        'End If
                End Select
            Else
                If lbConsFED = True Then       'Es consulta para el FED
                    MsgBox("The Ticket " & lsTicket & " is not a valid operation type.", vbInformation, "Invalid Ticket")
                Else
                    MsgBox("La operacion " & lsTicket & " no tiene un tipo de operación válida para GOS.", vbInformation, "Operacion Inválida")
                End If
            End If



        ElseIf Tipo = 2 Then 'El folio existe y es consulta de Ticket por Ficha CED
ConsultaFicha:
                        If lnFichas = 1 Then                'Solo existe una operacion con el numero de Ficha
                            gs_Sql = "Select operacion from T_RETIRO_PME where referencia = " & lsTicket
                            dt = d.RealizaConsulta(gs_Sql)
                            'dbExecQuery gs_Sql                'Busca Retiros con el numero de Ficha
                            'dbGetRecord
                            If dt.Rows.Count > 0 Then 'dbError = 0 Then               'Encontro la Operacion en Retiros
                                lsTicket = row.Item("operacion").ToString 'Trim(dbGetValue(0))
                                'dbEndQuery
                                Consulta(1, lsTicket, FED) 'PrevForm, FED)     'Genera la consulta por Ticket
                            Else                              'No encontro la Operacion en Retiros
                                'dbEndQuery
                                gs_Sql = "Select operacion from T_DEPOSITO_PME where referencia = " & lsTicket
                                'dbExecQuery gs_Sql              'Busca Depositos con el numero de Ficha
                                'dbGetRecord
                                dt = d.RealizaConsulta(gs_Sql)
                                If dt.Rows.Count > 0 Then 'dbError = 0 Then   'Encontro la Operacion en Depositos
                                    lsTicket = row.Item("operacion").ToString 'Trim(dbGetValue(0))
                                    'dbEndQuery
                                    Consulta(1, lsTicket, FED) 'PrevForm, FED)   'Genera la consulta por Ticket
                                Else                            'No encontro la Operacion en Depositos
                                    'dbEndQuery
                                    If lbConsFED = True Then      'Es consulta para el FED
                                        MsgBox("Ticket SLIP number " & lsTicket & " not found in Data Base.", vbInformation, "Invalid SLIP")
                                    Else
                                        MsgBox("No se encuentran operaciones con la Ficha " & lsTicket & " en la base de datos.", vbInformation, "Ficha CED Invalida")
                                    End If
                                    Exit Sub
                                End If
                            End If
                        Else                                'Existe mas de una operacion con el numero de Ficha
                            'frmConsFichaCED.Lista lsTicket    'Muestra la pantalla de Tickets relacionados con la Ficha
                        End If
        End If



        '        If Tipo = 0 Then                      'El folio existe y es consulta de documentos
        '            'frmConsDocto.Muestra lsTicket, lbConsFED, mnTipo
        '        ElseIf Tipo = 1 Then                  'El folio existe y es consulta de Ticket por Ticket
        '            gs_Sql = "Select operacion_definida_global, "
        '            gs_Sql = gs_Sql & "descripcion_operacion_definida "
        '            gs_Sql = gs_Sql & "From "
        '            gs_sql = gs_sql & " TICKET.dbo.PRODUCTO_CONTRATADO PC, "
        '            gs_sql = gs_sql & " TICKET.dbo.OPERACION_DEFINIDA OD, "
        '            gs_sql = gs_Sql & "T_OPERACION OP "
        '            gs_Sql = gs_Sql & "where "
        '            gs_Sql = gs_Sql & "PC.producto_contratado = OP.producto_contratado and "
        '            gs_Sql = gs_Sql & "OD.operacion_definida = OP.operacion_definida and "
        '            gs_Sql = gs_Sql & "OP.operacion = " & lsTicket
        '            'dbExecQuery gs_Sql                  'Consulta el tipo de operacion
        '            'dbGetRecord
        '            '100
        '            '      Select Case Val(dbGetValue(0))      'Llama la pantalla de consulta dependiendo de la operacion definida
        '            '          Case 81                           'Retiro por Orden de Pago
        '            '              dbEndQuery
        '            '              frmConsROP.Muestra lsTicket, lbConsFED, mnTipo
        '            'Case 83                           'Retiro por Sucursal en Firme
        '            '              dbEndQuery
        '            '              frmConsDepsRets.Muestra lsTicket, lbConsFED, mnTipo
        '            'Case 86                           'Retiro por Orden de Pago Otras Divisas
        '            '              dbEndQuery
        '            '              frmConsROP.Muestra lsTicket, lbConsFED, mnTipo
        '            'Case 87                           'Retiro por Traspaso Misma Agencia
        '            '              dbEndQuery
        '            '              frmConsTrasp.Muestra lsTicket, lbConsFED, mnTipo
        '            'Case 88                           'Retiro por Devolución de Cheque
        '            '              dbEndQuery
        '            '              frmConsDepsRets.Muestra lsTicket, lbConsFED, mnTipo
        '            'Case 89                           'Retiro por Area Interna
        '            '              dbEndQuery
        '            '              frmConsDepsRets.Muestra lsTicket, lbConsFED, mnTipo
        '            'Case 97                           'Retiro por Traspaso Entre Agencias
        '            '              dbEndQuery
        '            '              frmConsTrasp.Muestra lsTicket, lbConsFED, mnTipo
        '            'Case 583                          'Deposito por Sucursal en Firme
        '            '              dbEndQuery
        '            '              frmConsDepsRets.Muestra lsTicket, lbConsFED, mnTipo
        '            'Case 588                          'Deposito por Sucursal S.B.F.
        '            '              dbEndQuery
        '            '              frmConsDepsRets.Muestra lsTicket, lbConsFED, mnTipo
        '            'Case 589                          'Deposito por Area Interna
        '            '              dbEndQuery
        '            '              frmConsDepsRets.Muestra lsTicket, lbConsFED, mnTipo
        '            'Case 587                          'Deposito por Traspaso Misma Agencia
        '            '              dbEndQuery
        '            '              frmConsTrasp.Muestra lsTicket, lbConsFED, mnTipo
        '            'Case 590                          'Deposito por Sucursal 24 Hrs
        '            '              dbEndQuery
        '            '              frmConsDepsRets.Muestra lsTicket, lbConsFED, mnTipo
        '            'Case 591                          'Deposito por Area Interna 24 Hrs
        '            '              dbEndQuery
        '            '              frmConsDepsRets.Muestra lsTicket, lbConsFED, mnTipo
        '            'Case 592                          'Deposito por Area Interna S.B.F.
        '            '              dbEndQuery
        '            '              frmConsDepsRets.Muestra lsTicket, lbConsFED, mnTipo
        '            'Case 597                          'Deposito por Traspaso Entre Agencias
        '            '              dbEndQuery
        '            '              frmConsTrasp.Muestra lsTicket, lbConsFED, mnTipo
        '            'Case Else                         'Cualquier otra operacion definida
        '            '              If lbConsFED = True Then       'Es consulta para el FED
        '            '                  MsgBox "The Ticket " & lsTicket & " is not a valid operation type.", vbInformation, "Invalid Ticket"
        '            '  Else
        '            '                  MsgBox "La operacion " & lsTicket & " es un " & Trim(dbGetValue(1)) & " invalido para GOS.", vbInformation, "Operacion Invalida"
        '            '  End If
        '            '              If Not IsMissing(PrevForm) Then 'Si la consulta biene de alguna otra pantalla
        '            '                  If TypeOf PrevForm Is Form Then
        '            '                      If PrevForm.WindowState = 1 Then PrevForm.WindowState = 2
        '            '                  End If
        '            '              End If
        '            '      End Select
        '            'dbEndQuery
        '        ElseIf Tipo = 2 Then                  'El folio existe y es consulta de Ticket por Ficha CED
        'ConsultaFicha:
        '            If lnFichas = 1 Then                'Solo existe una operacion con el numero de Ficha
        '                'gs_Sql = "Select operacion from T_RETIRO_PME where referencia = " & lsTicket
        '                'dbExecQuery gs_Sql                'Busca Retiros con el numero de Ficha
        '                'dbGetRecord
        '                'If dbError = 0 Then               'Encontro la Operacion en Retiros
        '                '    lsTicket = Trim(dbGetValue(0))
        '                '    dbEndQuery
        '                '    Consulta 1, lsTicket, PrevForm, FED     'Genera la consulta por Ticket
        '                'Else                              'No encontro la Operacion en Retiros
        '                '    dbEndQuery
        '                '    gs_Sql = "Select operacion from T_DEPOSITO_PME where referencia = " & lsTicket
        '                '    dbExecQuery gs_Sql              'Busca Depositos con el numero de Ficha
        '                '    dbGetRecord
        '                '    If dbError = 0 Then             'Encontro la Operacion en Depositos
        '                '        lsTicket = Trim(dbGetValue(0))
        '                '        dbEndQuery
        '                '        Consulta 1, lsTicket, PrevForm, FED   'Genera la consulta por Ticket
        '                '    Else                            'No encontro la Operacion en Depositos
        '                '        dbEndQuery
        '                '        If lbConsFED = True Then      'Es consulta para el FED
        '                '            MsgBox "Ticket SLIP number " & lsTicket & " not found in Data Base.", vbInformation, "Invalid SLIP"
        '                '        Else
        '                '            MsgBox "No se encuentran operaciones con la Ficha " & lsTicket & " en la base de datos.", vbInformation, "Ficha CED Invalida"
        '                '        End If
        '                '        Exit Sub
        '                '    End If
        '                'End If
        '            Else                                'Existe mas de una operacion con el numero de Ficha
        '                'frmConsFichaCED.Lista lsTicket    'Muestra la pantalla de Tickets relacionados con la Ficha
        '            End If
        '        End If
    End Sub

    '---------------------------------------------------------
    'Presenta la pantalla de consulta dependiendo de la fuente
    '---------------------------------------------------------
    Public Sub Fuente(ByVal Tipo As Byte, FED As String)

        'Cursor = System.Windows.Forms.Cursors.WaitCursor
        On Error Resume Next
        'Unload frmConsFichaCED            'Descarga la pantalla de Tickets relacionados con la Ficha
        If FED = "FED" Then  'Not IsMissing(FED) Then        'Es consulta para el FED
            mbFED = True                     'Prende la bandera de consulta del FED
            mbTraduce = True                'Forza la traducción de las pantallas
        Else
            mbFED = False
            'mbTraduce = TRADUCE             'Obtiene el parametro de traduccion general
        End If
        mnTipo = Tipo                     'Guarda el tipo de consulta
        If mbTraduce = True Then
            cmdAceptar.Text = "&Search"
            cmdCierra.Text = "&Exit"
            If Tipo = 0 Then                'Consulta de Documentos
                Me.Text = "Document Search"
                lblTitulo.Text = "Input the Document number:"
            ElseIf Tipo = 1 Then            'Consulta de Tickets por numero de Operacion
                Me.Text = "Ticket Search"
                lblTitulo.Text = "Input the Ticket number:"
            ElseIf Tipo = 2 Then            'Consulta de Tickets por numero de Ficha CED
                Me.Text = "SLIP Search"
                lblTitulo.Text = "Input the SLIP number:"
            Else                            'Error en el Tipo de Consulta
                Exit Sub
            End If
        Else
            If Tipo = 0 Then                'Consulta de Documentos
                Me.Text = "Consulta de Documentos"
                lblTitulo.Text = "Escriba el número de Documento que desea consultar:"
            ElseIf Tipo = 1 Then            'Consulta de Tickets por numero de Operacion
                Me.Text = "Consulta de Tickets"
                lblTitulo.Text = "Escriba el número de Ticket que desea consultar:"
            ElseIf Tipo = 2 Then            'Consulta de Tickets por numero de Ficha CED
                Me.Text = "Consulta de Tickets por Ficha CED"
                lblTitulo.Text = "Escriba el número de Ficha CED que desea consultar:"
            Else                            'Error en el Tipo de Consulta
                Exit Sub
            End If
        End If
        Me.Width = 498
        Me.Height = 198
        Me.CenterToParent() 'Centerform Me
        Me.Show()
    End Sub

    Private Sub frmConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Dim lsTicket As String

        Cursor = System.Windows.Forms.Cursors.WaitCursor
        If Val(txtTicket.Text) > 0 Then   'Es un numero de Documento/Ticket/FichaCED valido
            lsTicket = Trim(txtTicket.Text)
            Me.Close()
            If mbFED = True Then            'Es consulta para el FED
                Consulta(mnTipo, lsTicket, "FED")
            Else                            'No es consulta para el FED
                Consulta(mnTipo, lsTicket, "")
            End If
        Else                              'No es un numero de Documento/Ticket/FichaCED valido
            If mbTraduce = True Then
                If mnTipo = 0 Then
                    MsgBox("Please type a Document number.", vbInformation, "Invalid Data")
                ElseIf mnTipo = 1 Then
                    MsgBox("Please type a Ticket number.", vbInformation, "Invalid Data")
                Else
                    MsgBox("Please type a SLIP number.", vbInformation, "Invalid Data")
                End If
            Else
                If mnTipo = 0 Then
                    MsgBox("Es necesario el número de documento.", vbInformation, "Documento Faltante")
                ElseIf mnTipo = 1 Then
                    MsgBox("Es necesario el número de Ticket.", vbInformation, "Ticket Faltante")
                Else
                    MsgBox("Es necesario el número de Ficha CED.", vbInformation, "Ficha CED Faltante")
                End If
            End If
            Me.txtTicket.Focus() ' Text   Se SetFocus
        End If

    End Sub

    Private Sub cmdCierra_Click(sender As Object, e As EventArgs) Handles cmdCierra.Click
        Me.Close()
    End Sub


End Class