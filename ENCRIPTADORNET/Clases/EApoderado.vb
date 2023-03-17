Public Class EApoderado
    Private Apoderado_ As Integer
    Private Cuenta_ As String
    Private Nombre_ As String
    Private Paterno_ As String
    Private Materno_ As String

    Public Property Apoderado() As String
        Get
            Return Apoderado_
        End Get
        Set(ByVal value As String)
            Apoderado_ = value
        End Set
    End Property
    Public Property Cuenta() As String
        Get
            Return Cuenta_
        End Get
        Set(ByVal value As String)
            Cuenta_ = value
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

    Public Property Paterno() As String
        Get
            Return Paterno_
        End Get
        Set(ByVal value As String)
            Paterno_ = value
        End Set
    End Property

    Public Property Materno() As String
        Get
            Return Materno_
        End Get
        Set(ByVal value As String)
            Materno_ = value
        End Set
    End Property
End Class
