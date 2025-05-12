Public Class Usuarios
    Private _idUsuario As UInteger
    Private _username As String
    Private _passwordHash As String
    Private _nombreCompleto As String
    Private _email As String
    Private _idRol As UInteger
    Private _fechaCreacion As DateTime
    Private _ultimaModificacion As DateTime

    Public Property IdUsuario As UInteger
        Get
            Return _idUsuario
        End Get
        Set(value As UInteger)
            _idUsuario = value
        End Set
    End Property

    Public Property Username As String
        Get
            Return _username
        End Get
        Set(value As String)
            _username = value
        End Set
    End Property

    Public Property PasswordHash As String
        Get
            Return _passwordHash
        End Get
        Set(value As String)
            _passwordHash = value
        End Set
    End Property

    Public Property NombreCompleto As String
        Get
            Return _nombreCompleto
        End Get
        Set(value As String)
            _nombreCompleto = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property

    Public Property IdRol As UInteger
        Get
            Return _idRol
        End Get
        Set(value As UInteger)
            _idRol = value
        End Set
    End Property

    Public Property FechaCreacion As DateTime
        Get
            Return _fechaCreacion
        End Get
        Set(value As DateTime)
            _fechaCreacion = value
        End Set
    End Property

    Public Property UltimaModificacion As DateTime
        Get
            Return _ultimaModificacion
        End Get
        Set(value As DateTime)
            _ultimaModificacion = value
        End Set
    End Property
End Class
