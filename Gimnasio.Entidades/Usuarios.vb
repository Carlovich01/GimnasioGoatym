''' <summary>
''' Representa un usuario del sistema del gimnasio.
''' Contiene información de autenticación, datos personales, rol y fechas de registro y modificación.
''' </summary>
Public Class Usuarios
    ''' <summary>
    ''' Identificador único del usuario.
    ''' </summary>
    Private _idUsuario As UInteger
    ''' <summary>
    ''' Nombre de usuario utilizado para iniciar sesión.
    ''' </summary>
    Private _username As String
    ''' <summary>
    ''' Hash de la contraseña del usuario.
    ''' </summary>
    Private _passwordHash As String
    ''' <summary>
    ''' Nombre completo del usuario.
    ''' </summary>
    Private _nombreCompleto As String
    ''' <summary>
    ''' Correo electrónico del usuario.
    ''' </summary>
    Private _email As String
    ''' <summary>
    ''' Identificador del rol asignado al usuario.
    ''' </summary>
    Private _idRol As UInteger
    ''' <summary>
    ''' Fecha de creación del usuario en el sistema.
    ''' </summary>
    Private _fechaCreacion As DateTime
    ''' <summary>
    ''' Fecha de la última modificación de los datos del usuario.
    ''' </summary>
    Private _ultimaModificacion As DateTime

    ''' <summary>
    ''' Obtiene o establece el identificador único del usuario.
    ''' </summary>
    Public Property IdUsuario As UInteger
        Get
            Return _idUsuario
        End Get
        Set(value As UInteger)
            _idUsuario = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el nombre de usuario.
    ''' </summary>
    Public Property Username As String
        Get
            Return _username
        End Get
        Set(value As String)
            _username = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el hash de la contraseña.
    ''' </summary>
    Public Property PasswordHash As String
        Get
            Return _passwordHash
        End Get
        Set(value As String)
            _passwordHash = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el nombre completo del usuario.
    ''' </summary>
    Public Property NombreCompleto As String
        Get
            Return _nombreCompleto
        End Get
        Set(value As String)
            _nombreCompleto = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el correo electrónico del usuario.
    ''' </summary>
    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el identificador del rol asignado al usuario.
    ''' </summary>
    Public Property IdRol As UInteger
        Get
            Return _idRol
        End Get
        Set(value As UInteger)
            _idRol = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece la fecha de creación del usuario.
    ''' </summary>
    Public Property FechaCreacion As DateTime
        Get
            Return _fechaCreacion
        End Get
        Set(value As DateTime)
            _fechaCreacion = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece la fecha de la última modificación de los datos del usuario.
    ''' </summary>
    Public Property UltimaModificacion As DateTime
        Get
            Return _ultimaModificacion
        End Get
        Set(value As DateTime)
            _ultimaModificacion = value
        End Set
    End Property
End Class
