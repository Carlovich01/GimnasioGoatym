''' <summary>
''' Representa un registro de asistencia de un miembro en el sistema del gimnasio.
''' Contiene información sobre el miembro, la fecha y hora de ingreso, el resultado y la membresía válida asociada.
''' </summary>
Public Class Asistencia
    ''' <summary>
    ''' Identificador único del registro de asistencia.
    ''' </summary>
    Private _idAsistencia As ULong
    ''' <summary>
    ''' Identificador del miembro que realizó el check-in (puede ser nulo).
    ''' </summary>
    Private _idMiembro As UInteger?
    ''' <summary>
    ''' Fecha y hora en que se registró la asistencia.
    ''' </summary>
    Private _fechaHoraCheckin As DateTime
    ''' <summary>
    ''' Resultado del intento de asistencia (por ejemplo: "Permitido", "Denegado", "Fuera de horario").
    ''' </summary>
    Private _resultado As String
    ''' <summary>
    ''' Identificador de la membresía válida utilizada para el ingreso (puede ser nulo).
    ''' </summary>
    Private _idMembresiaValida As UInteger?

    ''' <summary>
    ''' Obtiene o establece el identificador único del registro de asistencia.
    ''' </summary>
    Public Property IdAsistencia As ULong
        Get
            Return _idAsistencia
        End Get
        Set(value As ULong)
            _idAsistencia = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el identificador del miembro que realizó el check-in.
    ''' </summary>
    Public Property IdMiembro As UInteger?
        Get
            Return _idMiembro
        End Get
        Set(value As UInteger?)
            _idMiembro = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece la fecha y hora del check-in.
    ''' </summary>
    Public Property FechaHoraCheckin As DateTime
        Get
            Return _fechaHoraCheckin
        End Get
        Set(value As DateTime)
            _fechaHoraCheckin = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el resultado del registro de asistencia.
    ''' </summary>
    Public Property Resultado As String
        Get
            Return _resultado
        End Get
        Set(value As String)
            _resultado = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el identificador de la membresía válida asociada al registro de asistencia.
    ''' </summary>
    Public Property IdMembresiaValida As UInteger?
        Get
            Return _idMembresiaValida
        End Get
        Set(value As UInteger?)
            _idMembresiaValida = value
        End Set
    End Property

End Class
