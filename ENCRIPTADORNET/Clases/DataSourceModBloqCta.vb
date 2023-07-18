Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports System.Data.OleDb
Public Class DataSourceModBloqCta
    Private sqlstring As String


    'Funciones GONET Beatriz Adriana Palacios Sánchez
#Region "Bloqueo y Desbloque de cuentas"

    'Busca el status de la cuenta
    Function ObtenStatusCuenta(ByVal sCuenta As String) As DataTable
        Dim d As New Datasource

        Dim s As String

        s = "  Select producto_contratado, 
              status_producto_global 
              From 
              PRODUCTO_CONTRATADO PC, 
              STATUS_PRODUCTO SP, 
              PRODUCTO PR 
              Where 
               PC.cuenta_cliente = '" & sCuenta & "'
               and PC.agencia =  1
               and PC.status_producto = SP.status_producto
               and PC.producto = PR.producto
               and PR.producto_global = 9"

        Return d.Consulta(s, "ObtenStatusCuenta")

    End Function

    Function buscaAlerta(ByVal tpAlerta As String) As DataTable
        Dim d As New Datasource
        Dim s As String

        s = "  Select count(*) 
                From 
                TICKET..BLOQUEO_OBSERVACION 
                Where
                 status_bloqueo = " & tpAlerta
        Return d.Consulta(s, "buscaAlerta")
    End Function





#End Region

End Class
