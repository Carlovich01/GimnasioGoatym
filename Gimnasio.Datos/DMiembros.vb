Imports Gimnasio.Entidades
Imports System.Data
Imports LogDeErrores

Public Class DMiembros
    Inherits ConexionBase

    Public Function Listar() As DataTable
        Try
            Dim query As String = "SELECT * FROM miembros ORDER BY ultima_modificacion DESC"
            Return ExecuteQuery(query, Nothing)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

    Public Sub Insertar(Obj As Miembros)
        Try
            Dim query As String = "INSERT INTO miembros (dni, nombre, apellido, genero, telefono, email) VALUES (@dni, @nom, @ape, @gen, @tel, @ema)"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", Obj.Dni},
            {"@nom", Obj.Nombre},
            {"@ape", Obj.Apellido},
            {"@gen", If(Obj.Genero = Nothing, DBNull.Value, Obj.Genero)},
            {"@tel", If(Obj.Telefono = Nothing, DBNull.Value, Obj.Telefono)},
            {"@ema", If(Obj.Email = Nothing, DBNull.Value, Obj.Email)}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            If ex.Message.Contains("Duplicate entry") Then
                Logger.LogError("Capa Datos", ex)
                Throw New Exception("El DNI ya está registrado.")
            Else
                Logger.LogError("Capa Datos", ex)
                Throw
            End If
        End Try
    End Sub

    Public Sub Actualizar(Obj As Miembros)
        Try
            Dim query As String = "UPDATE miembros SET dni = @dni, nombre = @nom, apellido = @ape, genero = @gen, telefono = @tel, email = @ema WHERE id_miembro = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", Obj.Dni},
            {"@nom", Obj.Nombre},
            {"@ape", Obj.Apellido},
            {"@gen", If(Obj.Genero = Nothing, DBNull.Value, Obj.Genero)},
            {"@tel", If(Obj.Telefono = Nothing, DBNull.Value, Obj.Telefono)},
            {"@ema", If(Obj.Email = Nothing, DBNull.Value, Obj.Email)},
            {"@id", Obj.IdMiembro}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub

    Public Sub Eliminar(id As UInteger)
        Try
            Dim query As String = "DELETE FROM miembros WHERE id_miembro = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", id}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            If ex.Message.Contains("a foreign key constraint fails") Then
                Logger.LogError("Capa Datos", ex)
                Throw New Exception("No se puede eliminar el miembro porque tiene una membresía asociada.")
            Else
                Logger.LogError("Capa Datos", ex)
                Throw
            End If
        End Try
    End Sub

    Public Function ListarPorNombre(nombre As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM miembros WHERE nombre LIKE @nombre OR apellido LIKE @apellido ORDER BY ultima_modificacion DESC"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@nombre", nombre & "%"},
            {"@apellido", nombre & "%"}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

    Public Function ObtenerPorDni(dni As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM miembros WHERE dni = @dni"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", dni}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

    Public Function ListarPorDni(dni As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM miembros WHERE dni LIKE @dni ORDER BY ultima_modificacion DESC"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", dni & "%"}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function
End Class
