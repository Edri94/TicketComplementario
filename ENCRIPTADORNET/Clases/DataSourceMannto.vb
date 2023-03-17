Public Class DataSourceMannto


    Function LLenacombos(ByVal iTabla As Integer) As DataTable
        Dim cSQL As String
        Dim d As New Datasource

        cSQL = "SELECT "
        Select Case iTabla
            Case 0
                'If IsMissing(sQuery) Then
                'No hay nada que realizar, salimos
                'Exit Sub
                'End If
        'Llenamos con Tipos de Empresa
            Case 1
                cSQL &= "descripcion_tipo_empresa, tipo_empresa FROM "
                cSQL &= "CATALOGOS..TIPO_EMPRESA ORDER BY "
                cSQL &= "descripcion_tipo_empresa, tipo_empresa"
        'Llenamos con Tipos de Sociedad
            Case 2
                cSQL &= "descripcion_tipo_sociedad, tipo_sociedad FROM "
                cSQL &= "CATALOGOS..TIPO_SOCIEDAD ORDER BY "
                cSQL &= "descripcion_tipo_sociedad, tipo_sociedad"
        'Llenamos con Ubicación
            Case 3
                cSQL = " Select U.ubicacion as ubicacion, rtrim(U.descripcion_ubicacion)+', '+rtrim(U2.descripcion_ubicacion) as dsc_ubicacion "
                cSQL &= "From FUNCIONARIOS..UBICACION U, "
                cSQL &= " FUNCIONARIOS..UBICACION U2 "
                cSQL &= "Where U.tipo_ubicacion = 4 "
                cSQL &= " and U.ubicacion_padre = U2.ubicacion"
                cSQL &= " order by U.descripcion_ubicacion"
            Case 4
                cSQL = " Select U.ubicacion as ubicacion, rtrim(U.descripcion_ubicacion)+', '+rtrim(U2.descripcion_ubicacion) as dsc_ubicacion "
                cSQL &= "From CATALOGOS..UBICACION U, "
                cSQL &= " CATALOGOS..UBICACION U2 "
                cSQL &= "Where U.tipo_ubicacion = 4 "
                cSQL &= " and U.ubicacion_padre = U2.ubicacion"
                cSQL &= " order by U.descripcion_ubicacion"

        End Select

        Return d.Consulta(cSQL, "LLenaCombos")

    End Function

End Class
