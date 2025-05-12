Imports System.Data
Imports Gimnasio.Entidades
Imports LogDeErrores

Public Class DUsuarios
    Inherits ConexionBase

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
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

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
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub

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
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub

    Public Sub Eliminar(id As UInteger)
        Try
            Dim query As String = "DELETE FROM usuarios_sistema WHERE id_usuario = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", id}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub

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
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

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
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function
End Class
