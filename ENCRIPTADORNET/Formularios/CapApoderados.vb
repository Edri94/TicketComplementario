Public Class CapApoderados
    Private Sub CapApoderados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Try
            cargaGridView()
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en la funcion CapApoderados_Load, Error:" & ex.Message, vbInformation, "Listado de Apoderados")
            Exit Sub
        End Try
    End Sub
    Private Sub btAgregar_Click(sender As Object, e As EventArgs) Handles btAgregar.Click
        Dim d As New Datasource
        Dim EApo As New EApoderado
        Dim Reg As Integer
        Dim ExisteApo As String

        Try
            If Not DatosCorrectos() Then
                Exit Sub
            End If

            EApo.Cuenta = CuentaCompApertura
            EApo.Nombre = txNombre.Text.Trim()
            EApo.Paterno = txApellidoPat.Text.Trim()
            EApo.Materno = txApellidoMat.Text.Trim()

            'Validacion de que ya existe el apoderado **********************************************************
            ExisteApo = d.ExisteApoderado(EApo)

            If ExisteApo = "1" Then
                MsgBox("Este apoderado ya existe", vbInformation, "Validación Apoderado")
                Exit Sub
            End If
            'Validacion de que ya existe el apoderado FIN*******************************************************


            Reg = d.InsertaApoderado(EApo, usuario)

            If Reg > 0 Then
                cargaGridView()
                LimpiarCampos()
                MsgBox("Se ha guardado correctamente el Apoderado", vbInformation, "Alta de Apoderado")
            End If

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento btAgregar_Click, Error:" & ex.Message, vbInformation, "Alta Apoderado")
            Exit Sub
        End Try
    End Sub

    Private Sub btEliminar_Click(sender As Object, e As EventArgs) Handles btEliminar.Click
        Dim d As New Datasource
        Dim Sel As Integer
        Dim idApoderado As Integer
        Dim Reg As Integer
        Dim nombre As String = ""

        Try
            gvApoderados.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If gvApoderados.Rows.Count > 0 Then
                nombre = gvApoderados.CurrentRow.Cells("Nombre").Value

                If MsgBox("Esta seguro de eliminar el apoderado " & nombre & ". ¿Desea Continuar?", vbYesNo + vbQuestion + vbDefaultButton2, "Apoderados") <> vbYes Then Exit Sub

                Sel = gvApoderados.CurrentRow.Index
                idApoderado = gvApoderados.CurrentRow.Cells("Apoderado").Value

                If Sel > -1 Then
                    Reg = d.EliminaApoderado(idApoderado)
                Else
                    MsgBox("Seleccione en la lista el APODERADO a eliminar")
                    Exit Sub
                End If

                gvApoderados.Rows.RemoveAt(gvApoderados.CurrentRow.Index)

                If Reg > 0 Then
                    cargaGridView()
                    LimpiarCampos()
                    MsgBox("Se ha eliminado correctamente el Apoderado", vbInformation, "Elimina Apoderado")
                End If

                btGuardar.Enabled = False
                btEliminar.Enabled = False

            End If

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento btEliminar_Click, Error:" & ex.Message, vbInformation, "Elimina Apoderado")
            Exit Sub
        End Try

    End Sub
    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Dim d As New Datasource
        Dim EApo As New EApoderado
        Dim idApoderado As Integer
        Dim Reg As Integer

        Try
            If Not DatosCorrectos() Then
                Exit Sub
            End If

            idApoderado = gvApoderados.CurrentRow.Cells("Apoderado").Value
            EApo.Apoderado = idApoderado
            EApo.Cuenta = CuentaCompApertura
            EApo.Nombre = txNombre.Text.Trim()
            EApo.Paterno = txApellidoPat.Text.Trim()
            EApo.Materno = txApellidoMat.Text.Trim()

            Reg = d.ActualizaApoderado(EApo, usuario)

            If Reg > 0 Then
                cargaGridView()
                LimpiarCampos()
                MsgBox("Se ha actualizado correctamente el Apoderado", vbInformation, "Actualiza Apoderado")
            End If

            btGuardar.Enabled = False
            btEliminar.Enabled = False

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento btGuardar_Click, Error:" & ex.Message, vbInformation, "Actualiza Apoderado")
            Exit Sub
        End Try

    End Sub

    Private Sub gvApoderados_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles gvApoderados.CellMouseClick
        Dim idApoderado As Integer

        Try
            If gvApoderados.RowCount > 0 Then
                'Llena Campos
                txNombre.Text = gvApoderados.CurrentRow.Cells("NOMBRE").Value.Trim()
                txApellidoPat.Text = gvApoderados.CurrentRow.Cells("APELLIDOPAT").Value.Trim()
                txApellidoMat.Text = gvApoderados.CurrentRow.Cells("APELLIDOMAT").Value.Trim()

                idApoderado = gvApoderados.CurrentRow.Cells("Apoderado").Value

                btGuardar.Enabled = True
                btEliminar.Enabled = True
            Else
                btGuardar.Enabled = False
                btEliminar.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento gvApoderados_CellMouseClick, Error:" & ex.Message, vbInformation, "Seleccionar un Apoderado")
            Exit Sub
        End Try

    End Sub

    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
        Me.Close()
    End Sub

    Sub cargaGridView()
        Dim d As New Datasource
        Dim dtApo As DataTable

        dtApo = d.ObtieneApoderados(CuentaCompApertura)

        If dtApo.Rows.Count > 0 Then
            gvApoderados.DataSource = dtApo
        End If
    End Sub

    Function DatosCorrectos() As Boolean
        If txNombre.Text.Trim() = String.Empty Then
            MsgBox("Es necesario indicar el nombre del apoderado", vbInformation, "Validación")
            txNombre.Focus()
            Return False
        End If

        If txApellidoPat.Text.Trim() = String.Empty Then
            MsgBox("Es necesario indicar el apellido paterno del apoderado", vbInformation, "Validación")
            txApellidoPat.Focus()
            Return False
        End If

        If txApellidoMat.Text.Trim() = String.Empty Then
            MsgBox("Es necesario indicar el apellido materno del apoderado", vbInformation, "Validación")
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