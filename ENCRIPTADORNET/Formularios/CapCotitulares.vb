Public Class CapCotitulares
    Private Sub CapCotitulares_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Try
            cargaGridView()
        Catch ex As Exception
            MsgBox("Ha ocurrido un error en la funcion CapCotitulares_Load, Error:" & ex.Message, vbInformation, "Listado de Cotitulares")
            Exit Sub
        End Try
    End Sub
    Private Sub btAgregar_Click(sender As Object, e As EventArgs) Handles btAgregar.Click
        Dim d As New Datasource
        Dim ECot As New ECotitular
        Dim Reg As Integer
        Dim ExisteCot As String

        Try
            If Not DatosCorrectos() Then
                Exit Sub
            End If

            ECot.Cuenta = CuentaCompApertura
            ECot.Nombre = txNombre.Text.Trim()
            ECot.Paterno = txApellidoPat.Text.Trim()
            ECot.Materno = txApellidoMat.Text.Trim()

            'Validacion de que ya existe el autorizado **********************************************************
            ExisteCot = d.ExisteCotitular(ECot)

            If ExisteCot = "1" Then
                MsgBox("Este cotitular ya existe", vbInformation, "Validación Cotitular")
                Exit Sub
            End If
            'Validacion de que ya existe el autorizado FIN*******************************************************

            Reg = d.InsertaCotitular(ECot, usuario)

            If Reg > 0 Then
                cargaGridView()
                LimpiarCampos()
                MsgBox("Se ha guardado correctamente el Cotitular", vbInformation, "Alta de Cotitular")
            End If

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento btAgregar_Click, Error:" & ex.Message, vbInformation, "Alta Cotitular")
            Exit Sub
        End Try

    End Sub

    Private Sub btEliminar_Click(sender As Object, e As EventArgs) Handles btEliminar.Click
        Dim d As New Datasource
        Dim Sel As Integer
        Dim idCotitular As Integer
        Dim Reg As Integer
        Dim nombre As String = ""

        gvCotitulares.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        If gvCotitulares.Rows.Count > 0 Then

            nombre = gvCotitulares.CurrentRow.Cells("Nombre").Value
            If MsgBox("Esta seguro de eliminar el cotitular " & nombre & ". ¿Desea Continuar?", vbYesNo + vbQuestion + vbDefaultButton2, "Cotitulares") <> vbYes Then Exit Sub

            Sel = gvCotitulares.CurrentRow.Index
            idCotitular = gvCotitulares.CurrentRow.Cells("Cotitular").Value

            If Sel > -1 Then
                Reg = d.EliminaCotitular(idCotitular)
            Else
                MsgBox("Seleccione en la lista eL COTITULAR a eliminar")
                Exit Sub
            End If

            gvCotitulares.Rows.RemoveAt(gvCotitulares.CurrentRow.Index)

            If Reg > 0 Then
                cargaGridView()
                LimpiarCampos()
                MsgBox("Se ha eliminado correctamente el Cotitular", vbInformation, "Elimina Cotitular")
            End If

            btGuardar.Enabled = False
            btEliminar.Enabled = False

        End If

    End Sub
    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Dim d As New Datasource
        Dim ECot As New ECotitular
        Dim idCotitular As Integer
        Dim Reg As Integer

        Try
            If Not DatosCorrectos() Then
                Exit Sub
            End If

            idCotitular = gvCotitulares.CurrentRow.Cells("Cotitular").Value
            ECot.Cotitular = idCotitular
            ECot.Cuenta = CuentaCompApertura
            ECot.Nombre = txNombre.Text.Trim()
            ECot.Paterno = txApellidoPat.Text.Trim()
            ECot.Materno = txApellidoMat.Text.Trim()

            Reg = d.ActualizaCotitular(ECot, usuario)

            If Reg > 0 Then
                cargaGridView()
                LimpiarCampos()
                MsgBox("Se ha actualizado correctamente el Cotitular", vbInformation, "Actualiza Cotitular")
            End If

            btGuardar.Enabled = False
            btEliminar.Enabled = False

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento btGuardar_Click, Error:" & ex.Message, vbInformation, "Actualiza Cotitular")
            Exit Sub
        End Try
    End Sub
    Private Sub gvCotitulares_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles gvCotitulares.CellMouseClick
        Dim idCotitular As Integer

        Try
            If gvCotitulares.RowCount > 0 Then
                'Llena Campos
                txNombre.Text = gvCotitulares.CurrentRow.Cells("NOMBRE").Value.Trim()
                txApellidoPat.Text = gvCotitulares.CurrentRow.Cells("APELLIDOPAT").Value.Trim()
                txApellidoMat.Text = gvCotitulares.CurrentRow.Cells("APELLIDOMAT").Value.Trim()

                idCotitular = gvCotitulares.CurrentRow.Cells("Cotitular").Value

                btGuardar.Enabled = True
                btEliminar.Enabled = True
            Else
                btGuardar.Enabled = False
                btEliminar.Enabled = False
            End If

        Catch ex As Exception
            MsgBox("Ha ocurrido un error en el evento gvCotitulares_CellMouseClick, Error:" & ex.Message, vbInformation, "Seleccionar un Cotitular")
            Exit Sub
        End Try

    End Sub
    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
        Me.Close()
    End Sub
    Sub cargaGridView()
        Dim d As New Datasource
        Dim dtCot As DataTable

        dtCot = d.ObtieneCotitulares(CuentaCompApertura)

        If dtCot.Rows.Count > 0 Then
            gvCotitulares.DataSource = dtCot
        End If
    End Sub
    Function DatosCorrectos() As Boolean
        If txNombre.Text.Trim() = String.Empty Then
            MsgBox("Es necesario indicar el nombre del cotitular", vbInformation, "Validación")
            txNombre.Focus()
            Return False
        End If

        If txApellidoPat.Text.Trim() = String.Empty Then
            MsgBox("Es necesario indicar el apellido paterno del cotitular", vbInformation, "Validación")
            txApellidoPat.Focus()
            Return False
        End If

        If txApellidoMat.Text.Trim() = String.Empty Then
            MsgBox("Es necesario indicar el apellido materno del cotitular", vbInformation, "Validación")
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