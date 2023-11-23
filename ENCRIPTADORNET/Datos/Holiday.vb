Imports Newtonsoft.Json.Linq

Public Class Holiday
    Private _fecha As DateTime
    Public Property fecha() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property

    Private _empieza As DateTime
    Public Property empieza() As DateTime
        Get
            Return _empieza
        End Get
        Set(ByVal value As DateTime)
            _empieza = value
        End Set
    End Property

    Private _termina As DateTime
    Public Property termina() As DateTime
        Get
            Return _termina
        End Get
        Set(ByVal value As DateTime)
            _termina = value
        End Set
    End Property

    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _tipo As String
    Public Property tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property

    Private _rule As String
    Public Property rule() As String
        Get
            Return _rule
        End Get
        Set(ByVal value As String)
            _rule = value
        End Set
    End Property

    Public Function JTokenToHoliday(json As JEnumerable(Of JToken)) As Holiday
        JTokenToHoliday = New Holiday

        Dim dia_Festivo As IEnumerable(Of JToken) = json.Children()
        Dim fecha As DateTime = Convert.ToDateTime(dia_Festivo(0).ToString())
        Dim empieza As DateTime = Convert.ToDateTime(dia_Festivo(1).ToString())
        Dim termina As DateTime = Convert.ToDateTime(dia_Festivo(2).ToString())
        Dim nombre As String = dia_Festivo(3).ToString()
        Dim tipo As String = dia_Festivo(4).ToString()
        Dim regla As String = dia_Festivo(5).ToString()

        JTokenToHoliday = New Holiday With {
            .fecha = fecha,
            .empieza = empieza,
            .termina = termina,
            .nombre = nombre,
            .tipo = tipo,
            .rule = regla
        }


    End Function


End Class
