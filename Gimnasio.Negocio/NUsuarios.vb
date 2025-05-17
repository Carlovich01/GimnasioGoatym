Imports System.Data
Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports Gimnasio.Errores
Imports System.Security.Cryptography
Imports System.Text

''' <summary>
''' Lógica de negocio para la gestión de usuarios en el sistema de gimnasio.
''' Interactúa con la capa de datos <see cref="DUsuarios"/> y la entidad <see cref="Usuarios"/>.
''' Todas las operaciones de la capa de negocio están envueltas en bloques Try...Catch.  
''' Si ocurre una excepción, se registra el error utilizando <see cref="ManejarErrores.Log"/> en un log.txt
''' Luego, la excepción se propaga nuevamente mediante Throw New Exception(ex.Message) para que pueda ser gestionada en la interfaz de usuario.
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

        For Each c As Char In Obj.NombreCompleto
            If Char.IsDigit(c) Then
                Throw New Exception("El nombre no puede contener números.")
            End If
        Next

        If String.IsNullOrWhiteSpace(Obj.Email) Then
            Obj.Email = Nothing
        ElseIf Obj.Email.Length > 100 Then
            Throw New Exception("El nombre no puede tener más de 100 caracteres.")
        End If
    End Sub

    ''' <summary>
    ''' Genera un hash SHA256 para la contraseña proporcionada (utiliza System.Security.Cryptography)
    ''' </summary>
    ''' <param name="password">Contraseña en texto plano.</param>
    ''' <returns>Hash de la contraseña en formato Base64.</returns>
    Private Function GenerarHash(password As String) As String
        Try
            Using sha256 As SHA256 = SHA256.Create()
                Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
                Dim hash As Byte() = sha256.ComputeHash(bytes)
                Return Convert.ToBase64String(hash)
            End Using
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene la lista de todos los usuarios registrado con <see cref="DUsuarios.Listar()"/>.
    ''' </summary>
    ''' <returns>DataTable con los datos de los usuarios.</returns>
    Public Function Listar() As DataTable
        Try
            Return dUsuarios.Listar()
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 1. Verifica si el nombre de usuario ya está registrado utilizando <see cref="DUsuarios.ObtenerPorUsername"/>.
    '''    - Si el usuario existe, lanza una excepción indicando que el username ya está registrado.
    ''' 2. Valida los campos de la entidad <see cref="Usuarios"/> con <see cref="ValidarCampos(Usuarios)"/>
    ''' 3. Genera el hash SHA256 de la contraseña antes de almacenarla, utilizando el método privado <see cref="GenerarHash"/>.
    ''' 4. Inserta el usuario en la base de datos mediante <see cref="DUsuarios.Insertar(Usuarios)"/>.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Usuarios"/> a insertar.</param>
    Public Sub Insertar(Obj As Usuarios)
        Try
            If dUsuarios.ObtenerPorUsername(Obj.Username) IsNot Nothing Then
                Throw New Exception("El username ya está registrado.")
            End If
            ValidarCampos(Obj)
            Obj.PasswordHash = GenerarHash(Obj.PasswordHash)
            dUsuarios.Insertar(Obj)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 1. Valida los campos de la entidad <see cref="Usuarios"/> recibida como parámetro mediante <see cref="ValidarCampos(Usuarios)"/>:
    ''' 2. Genera el hash SHA256 de la nueva contraseña antes de almacenarla, utilizando el método privado <see cref="GenerarHash"/>.
    ''' 3. Actualiza el usuario en la base de datos mediante <see cref="DUsuarios.Actualizar(Usuarios)"/>.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Usuarios"/> con los datos actualizados.</param>
    Public Sub Actualizar(Obj As Usuarios)
        Try
            ValidarCampos(Obj)
            Obj.PasswordHash = GenerarHash(Obj.PasswordHash)
            dUsuarios.Actualizar(Obj)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Elimina un usuario del sistema según su id con <see cref="DUsuarios.Eliminar(UInteger)"/>.
    ''' </summary>
    ''' <param name="id">Identificador único del usuario a eliminar.</param>
    Public Sub Eliminar(id As UInteger)
        Try
            dUsuarios.Eliminar(id)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Realiza una validación y busca usuarios por nombre utilizando la capa de datos <see cref="DUsuarios.ListarPorNombre(String)"/>.
    ''' </summary>
    ''' <param name="nombre">Nombre o parte del nombre del usuario a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorNombre(nombre As String) As DataTable
        Try
            If nombre.Length > 150 Then
                Throw New Exception("El nombre no puede tener más de 150 caracteres.")
            End If
            Return dUsuarios.ListarPorNombre(nombre)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 1. Busca el usuario por su nombre de usuario utilizando <see cref="DUsuarios.ObtenerPorUsername(String)"/>.
    '''    - Si no existe, retorna Nothing.
    ''' 2. Si el usuario existe, genera el hash SHA256 de la contraseña ingresada mediante <see cref="GenerarHash(String)"/>.
    ''' 3. Compara el hash generado con el hash almacenado en la base de datos.
    '''    - Si coinciden, retorna la instancia de <see cref="Usuarios"/> correspondiente.
    '''    - Si no coinciden, retorna Nothing.
    ''' </summary>
    ''' <param name="username">Nombre de usuario.</param>
    ''' <param name="password">Contraseña en texto plano.</param>
    ''' <returns>
    ''' Instancia de <see cref="Usuarios"/> si las credenciales son válidas, Nothing en caso contrario.
    ''' </returns>
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
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
