Public Class TipoBitacora
    Private uUsuario_ As String
    Private uNombre_ As String
    Private uLogin_ As String
    Private uAccesos_ As String
    Private uAccPerfil_ As String
    Private uMarcacion_ As String
    Private Login_ As String
    Private Nombre_ As String
    Private Fecha_ As String
    Public Property uUsuario() As String
        Get
            Return uUsuario_
        End Get
        Set(ByVal value As String)
            uUsuario_ = value
        End Set
    End Property
    Public Property uNombre() As String
        Get
            Return uNombre_
        End Get
        Set(ByVal value As String)
            uNombre_ = value
        End Set
    End Property
    Public Property uLogin() As String
        Get
            Return uLogin_
        End Get
        Set(ByVal value As String)
            uLogin_ = value
        End Set
    End Property
    Public Property uAccesos() As String
        Get
            Return uAccesos_
        End Get
        Set(ByVal value As String)
            uAccesos_ = value
        End Set
    End Property
    Public Property uAccPerfil() As String
        Get
            Return uAccPerfil_
        End Get
        Set(ByVal value As String)
            uAccPerfil_ = value
        End Set
    End Property
    Public Property uMarcacion() As String
        Get
            Return uMarcacion_
        End Get
        Set(ByVal value As String)
            uMarcacion_ = value
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
    Public Property Nombre() As String
        Get
            Return Nombre_
        End Get
        Set(ByVal value As String)
            Nombre_ = value
        End Set
    End Property
    Public Property Fecha() As String
        Get
            Return Fecha_
        End Get
        Set(ByVal value As String)
            Fecha_ = value
        End Set
    End Property
End Class
