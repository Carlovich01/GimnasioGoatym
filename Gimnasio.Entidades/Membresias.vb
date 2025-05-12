Public Class Membresias
    Private _idMembresia As UInteger
    Private _idMiembro As UInteger
    Private _idPlan As UInteger
    Private _fechaInicio As Date
    Private _fechaFin As Date
    Private _estadoMembresia As String
    Private _fechaRegistro As Date
    Private _ultimaModificacion As Date
    Private _diasRestantes As UInteger
    Public Property IdMembresia As UInteger
        Get
            Return _idMembresia
        End Get
        Set(value As UInteger)
            _idMembresia = value
        End Set
    End Property

    Public Property IdMiembro As UInteger
        Get
            Return _idMiembro
        End Get
        Set(value As UInteger)
            _idMiembro = value
        End Set
    End Property

    Public Property IdPlan As UInteger
        Get
            Return _idPlan
        End Get
        Set(value As UInteger)
            _idPlan = value
        End Set
    End Property

    Public Property FechaInicio As Date
        Get
            Return _fechaInicio
        End Get
        Set(value As Date)
            _fechaInicio = value
        End Set
    End Property

    Public Property FechaFin As Date
        Get
            Return _fechaFin
        End Get
        Set(value As Date)
            _fechaFin = value
        End Set
    End Property

    Public Property EstadoMembresia As String
        Get
            Return _estadoMembresia
        End Get
        Set(value As String)
            _estadoMembresia = value
        End Set
    End Property

    Public Property FechaRegistro As Date
        Get
            Return _fechaRegistro
        End Get
        Set(value As Date)
            _fechaRegistro = value
        End Set
    End Property

    Public Property UltimaModificacion As Date
        Get
            Return _ultimaModificacion
        End Get
        Set(value As Date)
            _ultimaModificacion = value
        End Set
    End Property

    Public Property DiasRestantes As UInteger
        Get
            Return _diasRestantes
        End Get
        Set(value As UInteger)
            _diasRestantes = value
        End Set
    End Property
End Class
