Public Class Asistencia
    Private _idAsistencia As ULong
    Private _idMiembro As UInteger?
    Private _fechaHoraCheckin As DateTime
    Private _resultado As String
    Private _idMembresiaValida As UInteger?

    Public Property IdAsistencia As ULong
        Get
            Return _idAsistencia
        End Get
        Set(value As ULong)
            _idAsistencia = value
        End Set
    End Property

    Public Property IdMiembro As UInteger?
        Get
            Return _idMiembro
        End Get
        Set(value As UInteger?)
            _idMiembro = value
        End Set
    End Property

    Public Property FechaHoraCheckin As DateTime
        Get
            Return _fechaHoraCheckin
        End Get
        Set(value As DateTime)
            _fechaHoraCheckin = value
        End Set
    End Property

    Public Property Resultado As String
        Get
            Return _resultado
        End Get
        Set(value As String)
            _resultado = value
        End Set
    End Property

    Public Property IdMembresiaValida As UInteger?
        Get
            Return _idMembresiaValida
        End Get
        Set(value As UInteger?)
            _idMembresiaValida = value
        End Set
    End Property

End Class

