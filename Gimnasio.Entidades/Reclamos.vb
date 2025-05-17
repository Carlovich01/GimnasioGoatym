''' <summary>
''' Representa un reclamo realizado por un miembro en el sistema del gimnasio.
''' Contiene información sobre el tipo, descripción, estado, respuesta y fechas asociadas al reclamo.
''' </summary>
Public Class Reclamos
    ''' <summary>
    ''' Identificador único del reclamo.
    ''' </summary>
    Private _idReclamos As UInteger
    ''' <summary>
    ''' Tipo de reclamo ('sugerencia', 'reclamo').
    ''' </summary>
    Private _tipo As String
    ''' <summary>
    ''' Descripción detallada del reclamo.
    ''' </summary>
    Private _descripcion As String
    ''' <summary>
    ''' Fecha en que se envió el reclamo.
    ''' </summary>
    Private _fechaEnvio As DateTime
    ''' <summary>
    ''' Estado actual del reclamo (pendiente, resuelto).
    ''' </summary>
    Private _estado As String
    ''' <summary>
    ''' Respuesta dada al reclamo.
    ''' </summary>
    Private _respuesta As String
    ''' <summary>
    ''' Fecha en que se respondió el reclamo.
    ''' </summary>
    Private _fechaRespuesta As DateTime
    ''' <summary>
    ''' Identificador del miembro que realizó el reclamo (puede ser nulo).
    ''' </summary>
    Private _idMiembro As UInteger?

    ''' <summary>
    ''' Obtiene o establece el identificador único del reclamo.
    ''' </summary>
    Public Property IdReclamos As UInteger
        Get
            Return _idReclamos
        End Get
        Set(value As UInteger)
            _idReclamos = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el tipo de reclamo.
    ''' </summary>
    Public Property Tipo As String
        Get
            Return _tipo
        End Get
        Set(value As String)
            _tipo = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece la descripción del reclamo.
    ''' </summary>
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece la fecha de envío del reclamo.
    ''' </summary>
    Public Property FechaEnvio As Date
        Get
            Return _fechaEnvio
        End Get
        Set(value As Date)
            _fechaEnvio = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el estado actual del reclamo.
    ''' </summary>
    Public Property Estado As String
        Get
            Return _estado
        End Get
        Set(value As String)
            _estado = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece la respuesta dada al reclamo.
    ''' </summary>
    Public Property Respuesta As String
        Get
            Return _respuesta
        End Get
        Set(value As String)
            _respuesta = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece la fecha de respuesta del reclamo.
    ''' </summary>
    Public Property FechaRespuesta As Date
        Get
            Return _fechaRespuesta
        End Get
        Set(value As Date)
            _fechaRespuesta = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el identificador del miembro que realizó el reclamo.
    ''' </summary>
    Public Property IdMiembro As UInteger?
        Get
            Return _idMiembro
        End Get
        Set(value As UInteger?)
            _idMiembro = value
        End Set
    End Property
End Class
