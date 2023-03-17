Public Class ECliente
    Private Cuenta_ As String
    Private Calle_ As String
    Private NoExt_ As String
    Private NoInt_ As String
    Private Componente_ As String
    Private ColoniaCte_ As String
    Private Del_o_mun_ As String
    Private CPCte_ As String
    Private TelefonoCte_ As String
    Private FaxCte_ As String
    Private RFC_ As String
    Private Ubicacion_ As String
    Private FunPesos_ As String

    Public Property Cuenta() As String
        Get
            Return Cuenta_
        End Get
        Set(ByVal value As String)
            Cuenta_ = value
        End Set
    End Property
    Public Property Calle() As String
        Get
            Return Calle_
        End Get
        Set(ByVal value As String)
            Calle_ = value
        End Set
    End Property

    Public Property NoExt() As String
        Get
            Return NoExt_
        End Get
        Set(ByVal value As String)
            NoExt_ = value
        End Set
    End Property

    Public Property NoInt() As String
        Get
            Return NoInt_
        End Get
        Set(ByVal value As String)
            NoInt_ = value
        End Set
    End Property
    Public Property Componente() As String
        Get
            Return Componente_
        End Get
        Set(ByVal value As String)
            Componente_ = value
        End Set
    End Property
    Public Property ColoniaCte() As String
        Get
            Return ColoniaCte_
        End Get
        Set(ByVal value As String)
            ColoniaCte_ = value
        End Set
    End Property

    Public Property Del_o_mun() As String
        Get
            Return Del_o_mun_
        End Get
        Set(ByVal value As String)
            Del_o_mun_ = value
        End Set
    End Property

    Public Property CPCte() As String
        Get
            Return CPCte_
        End Get
        Set(ByVal value As String)
            CPCte_ = value
        End Set
    End Property

    Public Property TelefonoCte() As String
        Get
            Return TelefonoCte_
        End Get
        Set(ByVal value As String)
            TelefonoCte_ = value
        End Set
    End Property

    Public Property FaxCte() As String
        Get
            Return FaxCte_
        End Get
        Set(ByVal value As String)
            FaxCte_ = value
        End Set
    End Property

    Public Property RFC() As String
        Get
            Return RFC_
        End Get
        Set(ByVal value As String)
            RFC_ = value
        End Set
    End Property

    Public Property Ubicacion() As String
        Get
            Return Ubicacion_
        End Get
        Set(ByVal value As String)
            Ubicacion_ = value
        End Set
    End Property

    Public Property FunPesos() As String
        Get
            Return FunPesos_
        End Get
        Set(ByVal value As String)
            FunPesos_ = value
        End Set
    End Property

End Class
