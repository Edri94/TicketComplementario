'------------------------------------------------------------------------------
' <auto-generated>
'     Este código se generó a partir de una plantilla.
'
'     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
'     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class COMPRA_CD
    Public Property operacion As Integer
    Public Property fecha_vencimiento As Date
    Public Property tipo_cd As Byte
    Public Property plazo As Short
    Public Property tasa As Decimal
    Public Property renovacion As Byte
    Public Property origen As Byte
    Public Property subtipo_cd As Nullable(Of Byte)
    Public Property referencia_sujeto As String
    Public Property referencia_detalle As String
    Public Property producto_contratado_a_renovar As Nullable(Of Integer)
    Public Property plazo_origen As Nullable(Of Short)
    Public Property tipo_tasa As Nullable(Of Byte)
    Public Property operacion_venc As Nullable(Of Integer)

    Public Overridable Property OPERACION1 As OPERACION

End Class
