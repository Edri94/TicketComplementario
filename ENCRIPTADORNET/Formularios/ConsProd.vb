Imports System.Data.Entity.Infrastructure
Imports System.Data.SqlClient

Public Class ConsProd
    Public Property prod As Integer

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ConsProd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenaCampos()
    End Sub

    Private Sub LlenaCampos()
        'Obtiene la fecha de contratacion y de vencimiento del td
        ObtenerFecTicket()

        'Obtiene el monto del td y la tasa del td, el valor del concepto
        ObtenerMontoTasa()

        'Obtiene el tipo de td y su origen (si es renovacion)
        ObtenerTipoOrigen()
    End Sub

    Private Sub ObtenerTipoOrigen()
        Dim certificado As CertificadoRenovacionOrigen = CertificadoRenovacionOrigenByProducto(prod)
    End Sub

    Private Function CertificadoRenovacionOrigenByProducto(producto_contratado As Integer) As CertificadoRenovacionOrigen
        Dim certificado As CertificadoRenovacionOrigen
        Dim gs_Sql As String = "SELECT 
                 R.descripcion [Renovacion], O.descripcion [Origen], T.descripcion [Tipo]
                 From CERTIFICADO_DEPOSITO CD (NOLOCK),
                 CATALOGOS.dbo.RENOVACION_CD R (NOLOCK),
                 CATALOGOS.dbo.TIPO_CD T (NOLOCK),
                 CATALOGOS.dbo.ORIGEN_CD O (NOLOCK)
             Where producto_contratado = @producto_contratado
                AND CD.renovacion = R.renovacion 
                And O.origen = CD.origen 
                AND T.tipo_cd = CD.tipo_cd"


        Using contexto As New TICKETEntities
            CertificadoRenovacionOrigenByProducto = contexto.Database.SqlQuery(Of CertificadoRenovacionOrigen)(gs_Sql, New SqlParameter("@producto_contratado", 1542)).FirstOrDefault()

            If CertificadoRenovacionOrigenByProducto IsNot Nothing Then
                txtTipoRenov.Text = certificado.Renovacion
                txtOrigen.Text = certificado.Origen
                txtTipoTD.Text = certificado.Tipo
            End If

        End Using

    End Function

    Private Function ProductoContratadoByProduto(prod As Integer) As PRODUCTO_CONTRATADO
        Using contexto As New TICKETEntities
            ProductoContratadoByProduto = (
                    From pc In contexto.PRODUCTO_CONTRATADO
                    Join sp In contexto.STATUS_PRODUCTO On pc.status_producto Equals sp.status_producto1
                    Where pc.clave_producto_contratado = prod '[PRUEBA] Para obtener aaunque sea un reusltado
                    Select pc
            ).FirstOrDefault()

            If ProductoContratadoByProduto IsNot Nothing Then
                txtFechaCont.Text = ProductoContratadoByProduto.fecha_contratacion
                txtFechaVenc.Text = ProductoContratadoByProduto.fecha_vencimiento
                txtTicket.Text = ProductoContratadoByProduto.clave_producto_contratado
                txtPlazo.Text = (ProductoContratadoByProduto.fecha_contratacion - ProductoContratadoByProduto.fecha_vencimiento).Value.Days
                txtStatusProd.Text = ProductoContratadoByProduto.STATUS_PRODUCTO1.descripcion_status
            End If

        End Using
    End Function

    Private Sub ObtenerMontoTasa()
        Dim conceptos As ConceptoGroup = ConceptoByProductoContratado(prod)
    End Sub

    Private Function ConceptoByProductoContratado(producto_contratado As Integer) As ConceptoGroup
        Dim tasa, valor As Decimal
        Dim bTDorigen As Boolean
        Dim interes As Decimal
        Dim NumDias As Integer
        Dim nStatus As Integer
        Dim gs_Sql As String = "SELECT  C.producto_contratado,
          SUM(ISNULL( 
             CASE  WHEN  CD.concepto_definido_global = 7 
                   THEN  C.valor_concepto
                   ELSE  0
             END,0)) Monto,
          SUM(ISNULL(
             CASE  WHEN  CD.concepto_definido_global = 8
                   THEN  C.valor_concepto
                   ELSE  0
             END,0)) Tasa
        FROM  TICKET.dbo.CONCEPTO C (NOLOCK),
             TICKET.dbo.CONCEPTO_DEFINIDO CD (NOLOCK)
        WHERE   C.concepto_definido = CD.concepto_definido And 
             C.producto_contratado = @producto_contratado
        GROUP BY C.producto_contratado"

        Using contexto As New TICKETEntities
            ConceptoByProductoContratado = contexto.Database.SqlQuery(Of ConceptoGroup)(gs_Sql, New SqlParameter("@producto_contratado", 1542)).FirstOrDefault()

            If ConceptoByProductoContratado IsNot Nothing Then
                txtMontoTD.Text = ConceptoByProductoContratado.Monto
                txtTasa.Text = ConceptoByProductoContratado.Tasa
                interes = ConceptoByProductoContratado.Tasa * ConceptoByProductoContratado.Monto * Decimal.Parse(txtPlazo.Text) / 36000
                txtMontoIntereses.Text = interes.ToString("C")
                txtTotal.Text = (interes + valor).ToString("C")
            End If

        End Using


    End Function

    Private Sub ObtenerFecTicket()
        Dim product As PRODUCTO_CONTRATADO = ProductoContratadoByProduto(prod)
    End Sub

    Public Class CertificadoRenovacionOrigen
        Private _renovacion As String
        Private _origen As String
        Private _tipo As String
        Public Property Tipo() As String
            Get
                Return _tipo
            End Get
            Set(ByVal value As String)
                _tipo = value
            End Set
        End Property
        Public Property Origen() As String
            Get
                Return _origen
            End Get
            Set(ByVal value As String)
                _origen = value
            End Set
        End Property

        Public Property Renovacion() As String
            Get
                Return _renovacion
            End Get
            Set(ByVal value As String)
                _renovacion = value
            End Set
        End Property

    End Class

    Public Class ConceptoGroup

        Private _productoContratado As Integer
        Private _monto As Decimal
        Private _tasa As Decimal


        Public Property producto_contratado() As Integer
            Get
                Return _productoContratado
            End Get
            Set(ByVal value As Integer)
                _productoContratado = value
            End Set
        End Property

        Public Property Monto() As Decimal
            Get
                Return _monto
            End Get
            Set(ByVal value As Decimal)
                _monto = value
            End Set
        End Property

        Public Property Tasa() As Decimal
            Get
                Return _tasa
            End Get
            Set(ByVal value As Decimal)
                _tasa = value
            End Set
        End Property
    End Class
End Class