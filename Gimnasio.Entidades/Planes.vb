''' <summary>
''' Representa un plan de membresía dentro del sistema del gimnasio.
''' Contiene información relevante como nombre, descripción, duración, precio y fechas de creación y modificación.
''' </summary>
Public Class Planes
    ''' <summary>
    ''' Identificador único del plan.
    ''' </summary>
    Private _IdPlan As UInteger
    ''' <summary>
    ''' Nombre del plan.
    ''' </summary>
    Private _NombrePlan As String
    ''' <summary>
    ''' Descripción del plan.
    ''' </summary>
    Private _Descripcion As String
    ''' <summary>
    ''' Duración del plan en días.
    ''' </summary>
    Private _DuracionDias As UInteger
    ''' <summary>
    ''' Precio del plan.
    ''' </summary>
    Private _Precio As Decimal
    ''' <summary>
    ''' Fecha de creación del plan.
    ''' </summary>
    Private _FechaCreacion As DateTime
    ''' <summary>
    ''' Fecha de la última modificación del plan.
    ''' </summary>
    Private _UltimaModificacion As DateTime

    ''' <summary>
    ''' Obtiene o establece el identificador único del plan.
    ''' </summary>
    Public Property IdPlan As UInteger
        Get
            Return _IdPlan
        End Get
        Set(value As UInteger)
            _IdPlan = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el nombre del plan.
    ''' </summary>
    Public Property NombrePlan As String
        Get
            Return _NombrePlan
        End Get
        Set(value As String)
            _NombrePlan = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece la descripción del plan.
    ''' </summary>
    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece la duración del plan en días.
    ''' </summary>
    Public Property DuracionDias As UInteger
        Get
            Return _DuracionDias
        End Get
        Set(value As UInteger)
            _DuracionDias = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el precio del plan.
    ''' </summary>
    Public Property Precio As Decimal
        Get
            Return _Precio
        End Get
        Set(value As Decimal)
            _Precio = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece la fecha de creación del plan.
    ''' </summary>
    Public Property FechaCreacion As Date
        Get
            Return _FechaCreacion
        End Get
        Set(value As Date)
            _FechaCreacion = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece la fecha de la última modificación del plan.
    ''' </summary>
    Public Property UltimaModificacion As Date
        Get
            Return _UltimaModificacion
        End Get
        Set(value As Date)
            _UltimaModificacion = value
        End Set
    End Property
End Class

