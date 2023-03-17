Public Class CapAutorizados

    Private Sub CapAutorizados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Try
            cargaGridView()
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en la funcion CapAutorizados_Load, Error:" & ex.Message, vbInformation, "Listado de Autorizados")
            Exit Sub
        End Try
    End Sub

    Private Sub btAgregar_Click(sender As Object, e As EventArgs) Handles btAgregar.Click
        Dim d As New Datasource
        Dim EAut As New EAutorizado
        Dim Reg As Integer
        Dim ExisteAut As String

        Try
            If Not DatosCorrectos() Then
                Exit Sub
            End If

            EAut.Cuenta = CuentaCompApertura
            EAut.Nombre = txNombre.Text.Trim()
            EAut.Paterno = txApellidoPat.Text.Trim()
            EAut.Materno = txApellidoMat.Text.Trim()

            'Validacion de que ya existe el autorizado **********************************************************
            ExisteAut = d.ExisteAutorizado(EAut)

            If ExisteAut = "1" Then
                MsgBox("Este autorizado ya existe", vbInformation, "Validación Autorizados")
                Exit Sub
            End If
            'Validacion de que ya existe el autorizado FIN*******************************************************

            Reg = d.InsertaAutorizado(EAut, usuario)

            If Reg > 0 Then
                cargaGridView()
                LimpiarCampos()
                MsgBox("Se ha guardado correctamente el Autorizado", vbInformation, "Alta de Autorizado")

            End If
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento btAgregar_Click, Error:" & ex.Message, vbInformation, "Alta Autorizado")
            Exit Sub
        End Try

    End Sub

    Private Sub btEliminar_Click(sender As Object, e As EventArgs) Handles btEliminar.Click
        Dim d As New Datasource
        Dim Sel As Integer
        Dim idAutorizado As Integer
        Dim Reg As Integer
        Dim nombre As String = ""

        Try
            gvAutorizados.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If gvAutorizados.Rows.Count > 0 Then

                nombre = gvAutorizados.CurrentRow.Cells("Nombre").Value

                If MsgBox("Esta seguro de eliminar el autorizado " & nombre & ". ¿Desea Continuar?", vbYesNo + vbQuestion + vbDefaultButton2, "Autorizados") <> vbYes Then Exit Sub

                Sel = gvAutorizados.CurrentRow.Index
                idAutorizado = gvAutorizados.CurrentRow.Cells("Autorizado").Value

                If Sel > -1 Then
                    Reg = d.EliminaAutorizado(idAutorizado)
                Else
                    MsgBox("Seleccione en la lista el AUTORIZADO a eliminar")
                    Exit Sub
                End If

                gvAutorizados.Rows.RemoveAt(gvAutorizados.CurrentRow.Index)

                If Reg > 0 Then
                    cargaGridView()
                    LimpiarCampos()
                    MsgBox("Se ha eliminado correctamente el Autorizado", vbInformation, "Elimina Autorizado")
                End If

                btGuardar.Enabled = False
                btEliminar.Enabled = False

            End If

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento btEliminar_Click, Error:" & ex.Message, vbInformation, "Elimina Autorizado")
            Exit Sub
        End Try

    End Sub
    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Dim d As New Datasource
        Dim EAut As New EAutorizado
        Dim idAutorizado As Integer
        Dim Reg As Integer

        Try
            If Not DatosCorrectos() Then
                Exit Sub
            End If

            idAutorizado = gvAutorizados.CurrentRow.Cells("Autorizado").Value
            EAut.Autorizado = idAutorizado
            EAut.Cuenta = CuentaCompApertura
            EAut.Nombre = txNombre.Text.Trim()
            EAut.Paterno = txApellidoPat.Text.Trim()
            EAut.Materno = txApellidoMat.Text.Trim()

            Reg = d.ActualizaAutorizado(EAut, usuario)

            If Reg > 0 Then
                cargaGridView()
                LimpiarCampos()
                MsgBox("Se ha actualizado correctamente el Autorizado", vbInformation, "Actualiza Autorizado")

            End If

            btGuardar.Enabled = False
            btEliminar.Enabled = False

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento btGuardar_Click, Error:" & ex.Message, vbInformation, "Actualiza Autorizado")
            Exit Sub
        End Try

    End Sub

    Private Sub gvAutorizados_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles gvAutorizados.CellMouseClick
        Dim idAutorizado As Integer

        Try
            If gvAutorizados.RowCount > 0 Then
                'Llena Campos
                txNombre.Text = gvAutorizados.CurrentRow.Cells("NOMBRE").Value.Trim()
                txApellidoPat.Text = gvAutorizados.CurrentRow.Cells("APELLIDOPAT").Value.Trim()
                txApellidoMat.Text = gvAutorizados.CurrentRow.Cells("APELLIDOMAT").Value.Trim()

                idAutorizado = gvAutorizados.CurrentRow.Cells("Autorizado").Value

                btGuardar.Enabled = True
                btEliminar.Enabled = True
            Else
                btGuardar.Enabled = False
                btEliminar.Enabled = False
            End If

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento gvAutorizados_CellMouseClick, Error:" & ex.Message, vbInformation, "Seleccionar un Autorizado")
            Exit Sub
        End Try

    End Sub
    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
        Me.Close()
    End Sub

    Sub cargaGridView()
        Dim d As New Datasource
        Dim dtAut As DataTable

        dtAut = d.ObtieneAutorizados(CuentaCompApertura)

        If dtAut.Rows.Count > 0 Then
            gvAutorizados.DataSource = dtAut
        End If

    End Sub

    Function DatosCorrectos() As Boolean
        If txNombre.Text.Trim() = String.Empty Then
            MsgBox("Es necesario indicar el nombre del autorizado", vbInformation, "Validación")
            txNombre.Focus()
            Return False
        End If

        If txApellidoPat.Text.Trim() = String.Empty Then
            MsgBox("Es necesario indicar el apellido paterno del autorizado", vbInformation, "Validación")
            txApellidoPat.Focus()
            Return False
        End If

        If txApellidoMat.Text.Trim() = String.Empty Then
            MsgBox("Es necesario indicar el apellido materno del autorizado", vbInformation, "Validación")
            txApellidoMat.Focus()
            Return False
        End If

        Return True

    End Function

    Sub LimpiarCampos()
        txNombre.Text = String.Empty
        txApellidoPat.Text = String.Empty
        txApellidoMat.Text = String.Empty
    End Sub

End Class