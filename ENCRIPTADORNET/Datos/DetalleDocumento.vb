Public Class DetalleDocumento
    Private _descDoc As String
    Public Property descDoc() As String
        Get
            Return _descDoc
        End Get
        Set(ByVal value As String)
            _descDoc = value
        End Set
    End Property

    Private _otroDoc As String
    Public Property otroDoc() As String
        Get
            Return _otroDoc
        End Get
        Set(ByVal value As String)
            _otroDoc = value
        End Set
    End Property

    Private _folioLineaServicio As Integer
    Public Property folioLineaServicio() As Integer
        Get
            Return _folioLineaServicio
        End Get
        Set(ByVal value As Integer)
            _folioLineaServicio = value
        End Set
    End Property

    Private _descMoneda As String
    Public Property descMoneda() As String
        Get
            Return _descMoneda
        End Get
        Set(ByVal value As String)
            _descMoneda = value
        End Set
    End Property

    Private _deposito As DEPOSITO
    Public Property deposito() As DEPOSITO
        Get
            Return _deposito
        End Get
        Set(ByVal value As DEPOSITO)
            _deposito = value
        End Set
    End Property

    Private _moneda As TIPO_MONEDA
    Public Property moneda() As TIPO_MONEDA
        Get
            Return _moneda
        End Get
        Set(ByVal value As TIPO_MONEDA)
            _moneda = value
        End Set
    End Property
End Class
