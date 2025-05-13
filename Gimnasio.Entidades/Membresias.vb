''' <summary>
''' Representa una membresía de un miembro en el sistema del gimnasio.
''' Contiene información sobre el plan, fechas, estado y días restantes de la membresía.
''' </summary>
Public Class Membresias
    ''' <summary>
    ''' Identificador único de la membresía.
    ''' </summary>
    Private _idMembresia As UInteger
    ''' <summary>
    ''' Identificador del miembro asociado a la membresía.
    ''' </summary>
    Private _idMiembro As UInteger
    ''' <summary>
    ''' Identificador del plan asociado a la membresía.
    ''' </summary>
    Private _idPlan As UInteger
    ''' <summary>
    ''' Fecha de inicio de la membresía.
    ''' </summary>
    Private _fechaInicio As Date
    ''' <summary>
    ''' Fecha de finalización de la membresía.
    ''' </summary>
    Private _fechaFin As Date
    ''' <summary>
    ''' Estado actual de la membresía (por ejemplo: activa, inactiva, vencida).
    ''' </summary>
    Private _estadoMembresia As String
    ''' <summary>
    ''' Fecha de registro de la membresía en el sistema.
    ''' </summary>
    Private _fechaRegistro As Date
    ''' <summary>
    ''' Fecha de la última modificación de la membresía.
    ''' </summary>
    Private _ultimaModificacion As Date
    ''' <summary>
    ''' Días restantes hasta la finalización de la membresía.
    ''' </summary>
    Private _diasRestantes As UInteger

    ''' <summary>
    ''' Obtiene o establece el identificador único de la membresía.
    ''' </summary>
    Public Property IdMembresia As UInteger
        Get
            Return _idMembresia
        End Get
        Set(value As UInteger)
            _idMembresia = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el identificador del miembro asociado.
    ''' </summary>
    Public Property IdMiembro As UInteger
        Get
            Return _idMiembro
        End Get
        Set(value As UInteger)
            _idMiembro = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el identificador del plan asociado.
    ''' </summary>
    Public Property IdPlan As UInteger
        Get
            Return _idPlan
        End Get
        Set(value As UInteger)
            _idPlan = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece la fecha de inicio de la membresía.
    ''' </summary>
    Public Property FechaInicio As Date
        Get
            Return _fechaInicio
        End Get
        Set(value As Date)
            _fechaInicio = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece la fecha de finalización de la membresía.
    ''' </summary>
    Public Property FechaFin As Date
        Get
            Return _fechaFin
        End Get
        Set(value As Date)
            _fechaFin = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el estado actual de la membresía.
    ''' </summary>
    Public Property EstadoMembresia As String
        Get
            Return _estadoMembresia
        End Get
        Set(value As String)
            _estadoMembresia = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece la fecha de registro de la membresía.
    ''' </summary>
    Public Property FechaRegistro As Date
        Get
            Return _fechaRegistro
        End Get
        Set(value As Date)
            _fechaRegistro = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece la fecha de la última modificación de la membresía.
    ''' </summary>
    Public Property UltimaModificacion As Date
        Get
            Return _ultimaModificacion
        End Get
        Set(value As Date)
            _ultimaModificacion = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece los días restantes hasta la finalización de la membresía.
    ''' </summary>
    Public Property DiasRestantes As UInteger
        Get
            Return _diasRestantes
        End Get
        Set(value As UInteger)
            _diasRestantes = value
        End Set
    End Property
End Class

