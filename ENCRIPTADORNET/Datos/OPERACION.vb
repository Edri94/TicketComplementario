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

Partial Public Class OPERACION
    Public Property operacion1 As Integer
    Public Property producto_contratado As Integer
    Public Property operacion_definida As Short
    Public Property fecha_captura As Date
    Public Property status_operacion As Byte
    Public Property fecha_operacion As Date
    Public Property monto_operacion As Decimal
    Public Property usuario_captura As Short
    Public Property usuario_valida As Nullable(Of Short)
    Public Property linea As Nullable(Of Integer)
    Public Property funcionario As Nullable(Of Integer)
    Public Property contacto As String
    Public Property grabadora As Nullable(Of Integer)

    Public Overridable Property OPERACION_DEFINIDA1 As OPERACION_DEFINIDA
    Public Overridable Property PRODUCTO_CONTRATADO1 As PRODUCTO_CONTRATADO
    Public Overridable Property RETIRO_ORDEN_PAGO As ICollection(Of RETIRO_ORDEN_PAGO) = New HashSet(Of RETIRO_ORDEN_PAGO)
    Public Overridable Property COMPRA_CD As COMPRA_CD
    Public Overridable Property COMPRA_TD_OVERNIGHT As COMPRA_TD_OVERNIGHT
    Public Overridable Property CERTIFICADO_DEPOSITO As ICollection(Of CERTIFICADO_DEPOSITO) = New HashSet(Of CERTIFICADO_DEPOSITO)
    Public Overridable Property OPERACION_SWIFT As ICollection(Of OPERACION_SWIFT) = New HashSet(Of OPERACION_SWIFT)
    Public Overridable Property DEPOSITO_PME As DEPOSITO_PME
    Public Overridable Property DEPOSITO As DEPOSITO
    Public Overridable Property DETALLE_AUTORIZACION As DETALLE_AUTORIZACION
    Public Overridable Property DETALLE_INSTRUMENTO As ICollection(Of DETALLE_INSTRUMENTO) = New HashSet(Of DETALLE_INSTRUMENTO)
    Public Overridable Property RETIRO_PME As RETIRO_PME
    Public Overridable Property TRASPASO As TRASPASO
    Public Overridable Property DEPOSITO_CED As DEPOSITO_CED
    Public Overridable Property OPERACION_PIU As OPERACION_PIU
    Public Overridable Property OPERACION_PIU_BATCH As OPERACION_PIU_BATCH
    Public Overridable Property RETIRO_CED As RETIRO_CED

End Class
