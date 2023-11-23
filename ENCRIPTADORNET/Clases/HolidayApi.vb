Imports System.Net
Imports Newtonsoft.Json.Linq
Imports RestSharp

Public Class HolidayApi

    Public Structure Pais
        Const Mexico = "MX"
        Const USA = "US"
        Const Espana = "ES"
    End Structure

    Private Const urlBase = "https://api.generadordni.es/v2/holidays/holidays"
    Public Function GetDiasFestivos(year As Integer, country As String) As List(Of Holiday)
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Dim client As RestClient = New RestClient(urlBase)

        Dim request = New RestRequest()
        request.Method = Method.Get

        request.AddParameter("country", country)
        request.AddParameter("year", year.ToString())

        Dim resultado As String = client.Execute(request).Content.ToString()

        Dim fechas As JToken = Newtonsoft.Json.JsonConvert.DeserializeObject(Of JToken)(resultado)

        Dim dias_feriados As List(Of Holiday) = New List(Of Holiday)

        For Each fecha As JToken In fechas
            Dim hijo As JEnumerable(Of JToken) = fecha.Children()
            dias_feriados.Add(New Holiday().JTokenToHoliday(hijo))
        Next

        Return dias_feriados
    End Function
End Class
