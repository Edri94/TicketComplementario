Public Class UnidadOrg
    Private Relacion_ As String
    Private TreeChild_ As String
    Private Llave_ As String
    Private Texto_ As String
    Private Imagen_ As String
    Public Property Relacion() As String
        Get
            Return Relacion_
        End Get
        Set(ByVal value As String)
            Relacion_ = value
        End Set
    End Property
    Public Property TreeChild() As String
        Get
            Return TreeChild_
        End Get
        Set(ByVal value As String)
            TreeChild_ = value
        End Set
    End Property
    Public Property Llave() As String
        Get
            Return Llave_
        End Get
        Set(ByVal value As String)
            Llave_ = value
        End Set
    End Property
    Public Property Texto() As String
        Get
            Return Texto_
        End Get
        Set(ByVal value As String)
            Texto_ = value
        End Set
    End Property
    Public Property Imagen() As String
        Get
            Return Imagen_
        End Get
        Set(ByVal value As String)
            Imagen_ = value
        End Set
    End Property
End Class
