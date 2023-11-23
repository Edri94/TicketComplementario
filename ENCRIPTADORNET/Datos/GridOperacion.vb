Public Class GridOperacion
    Private _num_operacion As Integer
    Public Property num_operacion() As Integer
        Get
            Return _num_operacion
        End Get
        Set(ByVal value As Integer)
            _num_operacion = value
        End Set
    End Property

    Private _statusNombre As String
    Public Property status_nombre() As String
        Get
            Return _statusNombre
        End Get
        Set(ByVal value As String)
            _statusNombre = value
        End Set
    End Property

    Private _descripcionOperacionDefinida As String
    Public Property descripcion_operacion_definida() As String
        Get
            Return _descripcionOperacionDefinida
        End Get
        Set(ByVal value As String)
            _descripcionOperacionDefinida = value
        End Set
    End Property

    Private _fechaCaptura As DateTime
    Public Property fecha_captura() As DateTime
        Get
            Return _fechaCaptura
        End Get
        Set(ByVal value As DateTime)
            _fechaCaptura = value
        End Set
    End Property

    Private _fechaOperacion As DateTime
    Public Property fecha_operacion() As DateTime
        Get
            Return _fechaOperacion
        End Get
        Set(ByVal value As DateTime)
            _fechaOperacion = value
        End Set
    End Property

    Private _montoOperacion As Decimal
    Public Property monto_operacion() As Decimal
        Get
            Return _montoOperacion
        End Get
        Set(ByVal value As Decimal)
            _montoOperacion = value
        End Set
    End Property
End Class
