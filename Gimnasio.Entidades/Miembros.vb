''' <summary>
''' Representa un miembro del gimnasio.
''' Contiene información personal y de contacto, así como fechas de registro y última modificación.
''' </summary>
Public Class Miembros
    ''' <summary>
    ''' Identificador único del miembro.
    ''' </summary>
    Private _idMiembro As UInteger
    ''' <summary>
    ''' Documento Nacional de Identidad del miembro.
    ''' </summary>
    Private _dni As String
    ''' <summary>
    ''' Nombre del miembro.
    ''' </summary>
    Private _nombre As String
    ''' <summary>
    ''' Apellido del miembro.
    ''' </summary>
    Private _apellido As String
    ''' <summary>
    ''' Género del miembro.
    ''' </summary>
    Private _genero As String
    ''' <summary>
    ''' Teléfono de contacto del miembro.
    ''' </summary>
    Private _telefono As String
    ''' <summary>
    ''' Correo electrónico del miembro.
    ''' </summary>
    Private _email As String
    ''' <summary>
    ''' Fecha de registro del miembro en el sistema.
    ''' </summary>
    Private _fechaRegistro As Date
    ''' <summary>
    ''' Fecha de la última modificación de los datos del miembro.
    ''' </summary>
    Private _ultimaModificacion As Date

    ''' <summary>
    ''' Obtiene o establece el identificador único del miembro.
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
    ''' Obtiene o establece el DNI del miembro.
    ''' </summary>
    Public Property Dni As String
        Get
            Return _dni
        End Get
        Set(value As String)
            _dni = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el nombre del miembro.
    ''' </summary>
    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el apellido del miembro.
    ''' </summary>
    Public Property Apellido As String
        Get
            Return _apellido
        End Get
        Set(value As String)
            _apellido = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el género del miembro.
    ''' </summary>
    Public Property Genero As String
        Get
            Return _genero
        End Get
        Set(value As String)
            _genero = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el teléfono del miembro.
    ''' </summary>
    Public Property Telefono As String
        Get
            Return _telefono
        End Get
        Set(value As String)
            _telefono = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el correo electrónico del miembro.
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
    ''' Obtiene o establece la fecha de registro del miembro.
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
    ''' Obtiene o establece la fecha de la última modificación de los datos del miembro.
    ''' </summary>
    Public Property UltimaModificacion As Date
        Get
            Return _ultimaModificacion
        End Get
        Set(value As Date)
            _ultimaModificacion = value
        End Set
    End Property
End Class
