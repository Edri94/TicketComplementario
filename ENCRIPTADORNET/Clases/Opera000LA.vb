Public Class Opera000LA
    '************VARIABLES CON TIPOS DEFINIDOS***********************
    'Para evaluar la operacion dela cuenta 000 de LA
    Private Continua_ As Boolean
    Private CapturaTD_ As Boolean
    Public Property Continua() As String
        Get
            Return Continua_
        End Get
        Set(ByVal value As String)
            Continua_ = value
        End Set
    End Property
    Public Property CapturaTD() As String
        Get
            Return CapturaTD_
        End Get
        Set(ByVal value As String)
            CapturaTD_ = value
        End Set
    End Property
End Class