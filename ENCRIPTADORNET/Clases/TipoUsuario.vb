Public Class TipoUsuario
    Private Perfil_ As String
    Private Usuario_ As String
    Private Nombre_ As String
    Private Login_ As String
    Private Accesos_ As String
    Private AccPerfil_ As String
    Private Marcacion_ As String
    Public Property Perfil() As String
        Get
            Return Perfil_
        End Get
        Set(ByVal value As String)
            Perfil_ = value
        End Set
    End Property
    Public Property Usuario() As String
        Get
            Return Usuario_
        End Get
        Set(ByVal value As String)
            Usuario_ = value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return Nombre_
        End Get
        Set(ByVal value As String)
            Nombre_ = value
        End Set
    End Property
    Public Property Login() As String
        Get
            Return Login_
        End Get
        Set(ByVal value As String)
            Login_ = value
        End Set
    End Property
    Public Property Accesos() As String
        Get
            Return Accesos_
        End Get
        Set(ByVal value As String)
            Accesos_ = value
        End Set
    End Property
    Public Property AccPerfil() As String
        Get
            Return AccPerfil_
        End Get
        Set(ByVal value As String)
            AccPerfil_ = value
        End Set
    End Property
    Public Property Marcacion() As String
        Get
            Return Marcacion_
        End Get
        Set(ByVal value As String)
            Marcacion_ = value
        End Set
    End Property
End Class
