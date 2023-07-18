Public Class PermisoRemoto
    Private peticion_ As Long
    Private Autorizacion_ As Integer
    Private UsuarioAutoriza_ As Integer
    Private Comentario_ As String
    Private Respuesta_ As String
    Private tasa_ As Double
    Private SobreTasa_ As Double
    Public Property peticion() As String
        Get
            Return peticion_
        End Get
        Set(ByVal value As String)
            peticion_ = value
        End Set
    End Property
    Public Property Autorizacion() As String
        Get
            Return Autorizacion_
        End Get
        Set(ByVal value As String)
            Autorizacion_ = value
        End Set
    End Property
    Public Property UsuarioAutoriza() As String
        Get
            Return UsuarioAutoriza_
        End Get
        Set(ByVal value As String)
            UsuarioAutoriza_ = value
        End Set
    End Property
    Public Property Comentario() As String
        Get
            Return Comentario_
        End Get
        Set(ByVal value As String)
            Comentario_ = value
        End Set
    End Property
    Public Property Respuesta() As String
        Get
            Return Respuesta_
        End Get
        Set(ByVal value As String)
            Respuesta_ = value
        End Set
    End Property
    Public Property tasa() As String
        Get
            Return tasa_
        End Get
        Set(ByVal value As String)
            tasa_ = value
        End Set
    End Property
    Public Property SobreTasa() As String
        Get
            Return SobreTasa_
        End Get
        Set(ByVal value As String)
            SobreTasa_ = value
        End Set
    End Property
End Class
