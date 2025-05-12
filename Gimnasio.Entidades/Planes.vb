Public Class Planes
    Private _IdPlan As UInteger
    Private _NombrePlan As String
    Private _Descripcion As String
    Private _DuracionDias As UInteger
    Private _Precio As Decimal
    Private _FechaCreacion As DateTime
    Private _UltimaModificacion As DateTime

    Public Property IdPlan As UInteger
        Get
            Return _IdPlan
        End Get
        Set(value As UInteger)
            _IdPlan = value
        End Set
    End Property

    Public Property NombrePlan As String
        Get
            Return _NombrePlan
        End Get
        Set(value As String)
            _NombrePlan = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property DuracionDias As UInteger
        Get
            Return _DuracionDias
        End Get
        Set(value As UInteger)
            _DuracionDias = value
        End Set
    End Property

    Public Property Precio As Decimal
        Get
            Return _Precio
        End Get
        Set(value As Decimal)
            _Precio = value
        End Set
    End Property

    Public Property FechaCreacion As Date
        Get
            Return _FechaCreacion
        End Get
        Set(value As Date)
            _FechaCreacion = value
        End Set
    End Property

    Public Property UltimaModificacion As Date
        Get
            Return _UltimaModificacion
        End Get
        Set(value As Date)
            _UltimaModificacion = value
        End Set
    End Property
End Class
