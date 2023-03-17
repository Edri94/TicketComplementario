Public Class CapBeneficiarios
    Private Sub CapBeneficiarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Try
            cargaGridView()
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en la funcion CapBeneficiarios_Load, Error:" & ex.Message, vbInformation, "Listado de Beneficiarios")
            Exit Sub
        End Try
    End Sub
    Private Sub btAgregar_Click(sender As Object, e As EventArgs) Handles btAgregar.Click
        Dim d As New Datasource
        Dim EBen As New EBeneficiario
        Dim Reg As Integer
        Dim ExisteBen As String

        Try
            If Not DatosCorrectos() Then
                Exit Sub
            End If

            EBen.Cuenta = CuentaCompApertura
            EBen.Nombre = txNombre.Text.Trim()
            EBen.Paterno = txApellidoPat.Text.Trim()
            EBen.Materno = txApellidoMat.Text.Trim()

            'Validacion de que ya existe el autorizado **********************************************************
            ExisteBen = d.ExisteBeneficiario(EBen)

            If ExisteBen = "1" Then
                MsgBox("Este beneficiario ya existe", vbInformation, "Validación Beneficiario")
                Exit Sub
            End If
            'Validacion de que ya existe el autorizado FIN*******************************************************

            Reg = d.InsertaBeneficiario(EBen, usuario)

            If Reg > 0 Then
                cargaGridView()
                LimpiarCampos()
                MsgBox("Se ha guardado correctamente el Beneficiario", vbInformation, "Alta de Beneficiario")
            End If

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento btAgregar_Click, Error:" & ex.Message, vbInformation, "Alta Beneficiario")
            Exit Sub
        End Try

    End Sub
    Private Sub btEliminar_Click(sender As Object, e As EventArgs) Handles btEliminar.Click
        Dim d As New Datasource
        Dim Sel As Integer
        Dim idBeneficiario As Integer
        Dim Reg As Integer
        Dim nombre As String = ""

        Try
            gvBeneficiarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If gvBeneficiarios.Rows.Count > 0 Then

                nombre = gvBeneficiarios.CurrentRow.Cells("Nombre").Value

                If MsgBox("Esta seguro de eliminar el beneficiario " & nombre & ". ¿Desea Continuar?", vbYesNo + vbQuestion + vbDefaultButton2, "Beneficiarios") <> vbYes Then Exit Sub

                Sel = gvBeneficiarios.CurrentRow.Index
                idBeneficiario = gvBeneficiarios.CurrentRow.Cells("Beneficiario").Value

                If Sel > -1 Then
                    Reg = d.EliminaBeneficiario(idBeneficiario)
                Else
                    MsgBox("Seleccione en la lista el BENEFICIARIO a eliminar")
                    Exit Sub
                End If

                gvBeneficiarios.Rows.RemoveAt(gvBeneficiarios.CurrentRow.Index)

                If Reg > 0 Then
                    cargaGridView()
                    LimpiarCampos()
                    MsgBox("Se ha eliminado correctamente el Beneficiario", vbInformation, "Elimina Beneficiario")
                End If

                btGuardar.Enabled = False
                btEliminar.Enabled = False

            End If

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento btEliminar_Click, Error:" & ex.Message, vbInformation, "Elimina Beneficiario")
            Exit Sub
        End Try

    End Sub

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Dim d As New Datasource
        Dim EBen As New EBeneficiario
        Dim idBeneficiario As Integer
        Dim Reg As Integer

        Try
            If Not DatosCorrectos() Then
                Exit Sub
            End If

            idBeneficiario = gvBeneficiarios.CurrentRow.Cells("Beneficiario").Value
            EBen.Beneficiario = idBeneficiario
            EBen.Cuenta = CuentaCompApertura
            EBen.Nombre = txNombre.Text.Trim()
            EBen.Paterno = txApellidoPat.Text.Trim()
            EBen.Materno = txApellidoMat.Text.Trim()

            Reg = d.ActualizaBeneficiario(EBen, usuario)

            If Reg > 0 Then
                cargaGridView()
                LimpiarCampos()
                MsgBox("Se ha actualizado correctamente el Beneficiario", vbInformation, "Actualiza Beneficiario")
            End If

            btGuardar.Enabled = False
            btEliminar.Enabled = False
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento btGuardar_Click, Error:" & ex.Message, vbInformation, "Actualiza Beneficiario")
            Exit Sub
        End Try

    End Sub
    Private Sub gvBeneficiarios_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles gvBeneficiarios.CellMouseClick
        Dim idBeneficiario As Integer

        Try
            If gvBeneficiarios.RowCount > 0 Then
                'Llena Campos
                txNombre.Text = gvBeneficiarios.CurrentRow.Cells("NOMBRE").Value.Trim()
                txApellidoPat.Text = gvBeneficiarios.CurrentRow.Cells("APELLIDOPAT").Value.Trim()
                txApellidoMat.Text = gvBeneficiarios.CurrentRow.Cells("APELLIDOMAT").Value.Trim()

                idBeneficiario = gvBeneficiarios.CurrentRow.Cells("Beneficiario").Value

                btGuardar.Enabled = True
                btEliminar.Enabled = True
            Else
                btGuardar.Enabled = False
                btEliminar.Enabled = False
            End If

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento gvBeneficiarios_CellMouseClick, Error:" & ex.Message, vbInformation, "Seleccionar un Beneficiario")
            Exit Sub
        End Try

    End Sub

    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
        Me.Close()
    End Sub

    Sub cargaGridView()
        Dim d As New Datasource
        Dim dtBen As DataTable

        dtBen = d.ObtieneBeneficiarios(CuentaCompApertura)

        If dtBen.Rows.Count > 0 Then
            gvBeneficiarios.DataSource = dtBen
        End If

    End Sub

    Function DatosCorrectos() As Boolean
        If txNombre.Text.Trim() = String.Empty Then
            MsgBox("Es necesario indicar el nombre del beneficiario", vbInformation, "Validación")
            txNombre.Focus()
            Return False
        End If

        If txApellidoPat.Text.Trim() = String.Empty Then
            MsgBox("Es necesario indicar el apellido paterno del beneficiario", vbInformation, "Validación")
            txApellidoPat.Focus()
            Return False
        End If

        If txApellidoMat.Text.Trim() = String.Empty Then
            MsgBox("Es necesario indicar el apellido materno del beneficiario", vbInformation, "Validación")
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