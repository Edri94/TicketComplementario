Public Class EVENTO_OPERACION
    Private _operacion As OPERACION
    Public Property operacion() As OPERACION
        Get
            Return _operacion
        End Get
        Set(ByVal value As OPERACION)
            _operacion = value
        End Set
    End Property

    Private _fechaEvento As DateTime
    Public Property fechaEvento() As DateTime
        Get
            Return _fechaEvento
        End Get
        Set(ByVal value As DateTime)
            _fechaEvento = value
        End Set
    End Property

    Private _statusOperacion As Integer
    Public Property statusOperacion() As Integer
        Get
            Return _statusOperacion
        End Get
        Set(ByVal value As Integer)
            _statusOperacion = value
        End Set
    End Property

    Private _comentarioEvento As String
    Public Property comentarioEvento() As String
        Get
            Return _comentarioEvento
        End Get
        Set(ByVal value As String)
            _comentarioEvento = value
        End Set
    End Property

    Private _usuario As USUARIO
    Public Property usuario() As USUARIO
        Get
            Return _usuario
        End Get
        Set(ByVal value As USUARIO)
            _usuario = value
        End Set
    End Property

    Private _tipoEvento As TIPO_EVENTO_OPERACION
    Public Property tipoEvento() As TIPO_EVENTO_OPERACION
        Get
            Return _tipoEvento
        End Get
        Set(ByVal value As TIPO_EVENTO_OPERACION)
            _tipoEvento = value
        End Set
    End Property
End Class
