Imports System.Data
Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports LogDeErrores
Imports System.Security.Cryptography
Imports System.Text

''' <summary>
''' Lógica de negocio para la gestión de usuarios en el sistema de gimnasio.
''' Interactúa con la capa de datos <see cref="DUsuarios"/> y la entidad <see cref="Usuarios"/>.
''' </summary>
Public Class NUsuarios
    ''' <summary>
    ''' Instancia de la capa de datos para usuarios.
    ''' </summary>
    Private dUsuarios As New DUsuarios()

    ''' <summary>
    ''' Valida los campos de la entidad <see cref="Usuarios"/> antes de realizar operaciones de inserción o actualización.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Usuarios"/> a validar.</param>
    ''' <exception cref="Exception">Se lanza si algún campo no cumple con las reglas de negocio.</exception>
    Private Sub ValidarCampos(Obj As Usuarios)
        If Obj.Username.Length > 50 Then
            Throw New Exception("El nombre de usuario no puede tener más de 50 caracteres.")
        End If
        If Obj.PasswordHash.Length > 128 Then
            Throw New Exception("La contraseña no puede tener más de 128 caracteres.")
        End If
        If Obj.NombreCompleto.Length > 150 Then
            Throw New Exception("El nombre no puede tener más de 150 caracteres.")
        End If
        If String.IsNullOrWhiteSpace(Obj.Email) Then
            Obj.Email = Nothing
        ElseIf Obj.Email.Length > 100 Then
            Throw New Exception("El nombre no puede tener más de 100 caracteres.")
        End If
    End Sub

    ''' <summary>
    ''' Genera un hash SHA256 para la contraseña proporcionada.
    ''' </summary>
    ''' <param name="password">Contraseña en texto plano.</param>
    ''' <returns>Hash de la contraseña en formato Base64.</returns>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Private Function GenerarHash(password As String) As String
        Try
            Using sha256 As SHA256 = SHA256.Create()
                Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
                Dim hash As Byte() = sha256.ComputeHash(bytes)
                Return Convert.ToBase64String(hash)
            End Using
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene la lista de todos los usuarios registrados.
    ''' </summary>
    ''' <returns><see cref="DataTable"/> con los datos de los usuarios.</returns>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Function Listar() As DataTable
        Try
            Dim dvUsuarios As DataTable
            dvUsuarios = dUsuarios.Listar()
            Return dvUsuarios
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Inserta un nuevo usuario en el sistema.
    ''' Valida que el nombre de usuario no esté registrado y aplica hash a la contraseña.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Usuarios"/> a insertar.</param>
    ''' <exception cref="Exception">Se lanza si el usuario ya existe, hay errores de validación o de la capa de datos.</exception>
    Public Sub Insertar(Obj As Usuarios)
        Try
            If dUsuarios.ObtenerPorUsername(Obj.Username) IsNot Nothing Then
                Throw New Exception("El username ya está registrado.")
            End If
            ValidarCampos(Obj)
            Obj.PasswordHash = GenerarHash(Obj.PasswordHash)
            dUsuarios.Insertar(Obj)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza los datos de un usuario existente.
    ''' Aplica hash a la contraseña antes de actualizar.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Usuarios"/> con los datos actualizados.</param>
    ''' <exception cref="Exception">Se lanza si hay errores de validación o de la capa de datos.</exception>
    Public Sub Actualizar(Obj As Usuarios)
        Try
            ValidarCampos(Obj)
            Obj.PasswordHash = GenerarHash(Obj.PasswordHash)
            dUsuarios.Actualizar(Obj)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Elimina un usuario del sistema según su identificador.
    ''' </summary>
    ''' <param name="id">Identificador único del usuario a eliminar.</param>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Sub Eliminar(id As UInteger)
        Try
            dUsuarios.Eliminar(id)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Busca usuarios por nombre utilizando la capa de datos <see cref="DUsuarios.ListarPorNombre"/>.
    ''' </summary>
    ''' <param name="nombre">Nombre o parte del nombre del usuario a buscar.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    ''' <exception cref="Exception">Se lanza si el nombre excede el límite permitido o por errores de la capa de datos.</exception>
    Public Function ListarPorNombre(nombre As String) As DataTable
        Try
            If nombre.Length > 150 Then
                Throw New Exception("El nombre no puede tener más de 150 caracteres.")
            End If
            Dim dvUsuarios As DataTable = dUsuarios.ListarPorNombre(nombre)
            Return dvUsuarios
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Valida las credenciales de un usuario.
    ''' Compara el hash de la contraseña ingresada con el almacenado.
    ''' </summary>
    ''' <param name="username">Nombre de usuario.</param>
    ''' <param name="password">Contraseña en texto plano.</param>
    ''' <returns>
    ''' Instancia de <see cref="Usuarios"/> si las credenciales son válidas, <c>Nothing</c> en caso contrario.
    ''' </returns>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Function ValidarCredenciales(username As String, password As String) As Usuarios
        Try
            Dim usuario As Usuarios = dUsuarios.ObtenerPorUsername(username)
            If usuario IsNot Nothing Then
                Dim hashIngresado As String = GenerarHash(password)
                If usuario.PasswordHash = hashIngresado Then
                    Return usuario
                End If
            End If
            Return Nothing
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
