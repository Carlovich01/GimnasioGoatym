Imports System.Data
Imports Gimnasio.Entidades
Imports Gimnasio.Errores

''' <summary>
''' Clase de acceso a datos para la gestión de usuarios en el sistema de gimnasio.
''' Hereda de <see cref="ConexionBase"/> y utiliza la entidad <see cref="Usuarios"/>.
''' Proporciona métodos CRUD y de búsqueda para la tabla usuarios_sistema y la vista_usuarios.
''' 
''' La vista consolida la información relevante de los registros de usuarios,
''' permitiendo consultar en una sola consulta datos de los usuarios y sus roles.
''' Realiza JOIN entre la tabla de usuarios y la tabla de roles, permitiendo obtener la información de usuario junto con su rol asociado.
''' 
''' <code>
''' VIEW `vista_usuarios` AS
'''    SELECT 
'''        `u`.`id_usuario` AS `id_usuario`,
'''        `u`.`username` AS `username`,
'''        `u`.`password_hash` AS `password_hash`,
'''        `u`.`nombre_completo` AS `nombre_completo`,
'''        `u`.`email` AS `email`,
'''        `r`.`nombre_rol` AS `nombre_rol`,
'''        `u`.`fecha_creacion` AS `fecha_creacion`,
'''        `u`.`ultima_modificacion` AS `ultima_modificacion`
'''    FROM
'''        (`usuarios_sistema` `u`
'''        JOIN `roles` `r` ON ((`u`.`id_rol` = `r`.`id_rol`)))
'''    ORDER BY `u`.`ultima_modificacion` DESC
''' </code>
''' 
''' Los diccionarios se utilizan para asociar los parámetros de la consulta con los parámetros del método.
''' </summary>
Public Class DUsuarios
    Inherits ConexionBase

    ''' <summary>
    ''' Realiza una consulta SQL (SELECT) que obtiene todos los registros de la vista_usuarios.
    ''' </summary>
    ''' <returns>DataTable con los datos de los usuarios.</returns>
    Public Function Listar() As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_usuarios"
            Return ExecuteQuery(query, Nothing)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Recibe una instancia de Usuarios y ejecuta una sentencia SQL (INSERT) que inserta un nuevo registro de usuarios con los datos proporcionados.
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
    ''' Recibe una instancia de usuarios y ejecuta una sentencia SQL (UPDATE) que actualiza los datos de un registro de usuario existente que 
    ''' corresponde al id de la instancia. 
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Usuarios"/> con los datos actualizados.</param>
    Public Sub Actualizar(Obj As Usuarios)
        Try
            Dim query As String = "
            UPDATE usuarios_sistema 
            SET username = @user, password_hash = @pass, nombre_completo = @nom, email = @ema, id_rol = @idr
            WHERE id_usuario = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", Obj.IdUsuario},
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
    ''' Recibe el id del usuario a eliminar y ejecuta una sentencia SQL (DELETE) que elimina el registro de usuario correspondiente.
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
    ''' Recibe el nombre de un usuario y ejecuta una sentencia SQL (SELECT) que obtiene los registros de usuario que tienen ese nombre.
    ''' Permite buscar por parte del nombre utilizando la cláusula LIKE.
    ''' </summary>
    ''' <param name="nombre">Nombre o parte del nombre del usuario a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorNombre(nombre As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_usuarios WHERE nombre_completo LIKE @nombre"
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
    ''' Recibe un username y ejecuta una sentencia SQL (SELECT) que obtiene el registro de usuario correspondiente.
    ''' Luego convierte el DataTable en una instancia de Usuarios o retorna Nothing en caso de no encontrar.
    ''' </summary>
    ''' <param name="username">Nombre de usuario a buscar.</param>
    ''' <returns>
    ''' Instancia de <see cref="Usuarios"/> si se encuentra el usuario, Nothing en caso contrario.
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
                Dim usuario As New Usuarios()
                usuario.IdUsuario = Convert.ToUInt32(row("id_usuario"))
                usuario.Username = row("username").ToString()
                usuario.PasswordHash = row("password_hash").ToString()
                usuario.NombreCompleto = row("nombre_completo").ToString()
                usuario.Email = If(IsDBNull(row("email")), Nothing, row("email").ToString())
                usuario.IdRol = Convert.ToUInt32(row("id_rol"))
                Return usuario
            End If

            Return Nothing
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function
End Class
