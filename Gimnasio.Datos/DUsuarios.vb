Imports System.Data
Imports Gimnasio.Entidades
Imports Gimnasio.Errores

''' <summary>
''' Clase de acceso a datos para la gestión de usuarios en el sistema de gimnasio.
''' Hereda de <see cref="ConexionBase"/> y utiliza la entidad <see cref="Usuarios"/>.
''' Proporciona métodos CRUD y de búsqueda para la tabla <c>usuarios_sistema</c>.
''' </summary>
Public Class DUsuarios
    Inherits ConexionBase

    ''' <summary>
    ''' Obtiene todos los usuarios del sistema, incluyendo información de roles.
    ''' </summary>
    ''' <returns>DataTable con los datos de los usuarios.</returns>
    Public Function Listar() As DataTable
        Try
            Dim query As String = "
            SELECT u.id_usuario, u.username, u.password_hash, u.nombre_completo, u.email, 
                   r.nombre_rol, u.fecha_creacion, u.ultima_modificacion 
            FROM usuarios_sistema AS u 
            INNER JOIN roles AS r ON u.id_rol = r.id_rol 
            ORDER BY u.ultima_modificacion DESC"
            Return ExecuteQuery(query, Nothing)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Inserta un nuevo usuario en la base de datos.
    ''' Utiliza los datos de la entidad <see cref="Usuarios"/>.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Usuarios"/> a insertar.</param>
    Public Sub Insertar(Obj As Usuarios)
        Try
            Dim query As String = "
            INSERT INTO usuarios_sistema (username, password_hash, nombre_completo, email, id_rol) 
            VALUES (@user, @pass, @nom, @ema, @idr)"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@user", Obj.Username},
            {"@pass", Obj.PasswordHash},
            {"@nom", Obj.NombreCompleto},
            {"@ema", Obj.Email},
            {"@idr", Obj.IdRol}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza los datos de un usuario existente en la base de datos.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Usuarios"/> con los datos actualizados.</param>
    Public Sub Actualizar(Obj As Usuarios)
        Try
            Dim query As String = "
            UPDATE usuarios_sistema 
            SET username = @user, password_hash = @pass, nombre_completo = @nom, email = @ema 
            WHERE id_usuario = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", Obj.IdUsuario},
            {"@user", Obj.Username},
            {"@pass", Obj.PasswordHash},
            {"@nom", Obj.NombreCompleto},
            {"@ema", Obj.Email}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Elimina un usuario de la base de datos según su identificador.
    ''' </summary>
    ''' <param name="id">Identificador único del usuario a eliminar.</param>
    Public Sub Eliminar(id As UInteger)
        Try
            Dim query As String = "DELETE FROM usuarios_sistema WHERE id_usuario = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", id}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Busca usuarios por coincidencia parcial de nombre completo.
    ''' </summary>
    ''' <param name="nombre">Nombre o parte del nombre del usuario a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorNombre(nombre As String) As DataTable
        Try
            Dim query As String = "
            SELECT * 
            FROM usuarios_sistema 
            WHERE nombre_completo LIKE @nombre 
            ORDER BY ultima_modificacion DESC"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@nombre", nombre & "%"}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Obtiene un usuario por su nombre de usuario.
    ''' </summary>
    ''' <param name="username">Nombre de usuario a buscar.</param>
    ''' <returns>
    ''' Instancia de <see cref="Usuarios"/> si se encuentra el usuario, <c>Nothing</c> en caso contrario.
    ''' </returns>
    Public Function ObtenerPorUsername(username As String) As Usuarios
        Try
            Dim query As String = "SELECT * FROM usuarios_sistema WHERE username = @user"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@user", username}
        }
            Dim resultado As DataTable = ExecuteQuery(query, parameters)

            If resultado.Rows.Count > 0 Then
                Dim row = resultado.Rows(0)
                Dim usuario As New Usuarios() With {
                .IdUsuario = Convert.ToUInt32(row("id_usuario")),
                .Username = row("username").ToString(),
                .PasswordHash = row("password_hash").ToString(),
                .NombreCompleto = row("nombre_completo").ToString(),
                .Email = If(IsDBNull(row("email")), Nothing, row("email").ToString()),
                .IdRol = Convert.ToUInt32(row("id_rol"))
            }
                Return usuario
            End If

            Return Nothing
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function
End Class
