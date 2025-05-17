Imports Gimnasio.Entidades
Imports System.Data
Imports Gimnasio.Errores

''' <summary>
''' Clase de acceso a datos para la gestión de miembros en el sistema de gimnasio.
''' Hereda de <see cref="ConexionBase"/> y utiliza la entidad <see cref="Miembros"/>.
''' Proporciona métodos CRUD y de búsqueda para la tabla <c>miembros</c>.
''' </summary>
Public Class DMiembros
    Inherits ConexionBase

    ''' <summary>
    ''' Obtiene todos los miembros de la base de datos ordenados por la última modificación.
    ''' </summary>
    ''' <returns>DataTable con los datos de los miembros.</returns>
    Public Function Listar() As DataTable
        Try
            Dim query As String = "SELECT * FROM miembros ORDER BY ultima_modificacion DESC"
            Return ExecuteQuery(query, Nothing)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Inserta un nuevo miembro en la base de datos.
    ''' Utiliza los datos de la entidad <see cref="Miembros"/>.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Miembros"/> a insertar.</param>
    ''' <exception cref="Exception">Se lanza si el DNI ya está registrado o por errores de la base de datos.</exception>
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
                ManejarErrores.Log("Capa Datos", ex)
                Throw New Exception("El DNI ya está registrado.")
            Else
                ManejarErrores.Log("Capa Datos", ex)
                Throw
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza los datos de un miembro existente en la base de datos.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Miembros"/> con los datos actualizados.</param>
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
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Elimina un miembro de la base de datos según su identificador.
    ''' </summary>
    ''' <param name="id">Identificador único del miembro a eliminar.</param>
    ''' <exception cref="Exception">Se lanza si el miembro tiene membresías asociadas o por errores de la base de datos.</exception>
    Public Sub Eliminar(id As UInteger)
        Try
            Dim query As String = "DELETE FROM miembros WHERE id_miembro = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", id}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            If ex.Message.Contains("a foreign key constraint fails") Then
                ManejarErrores.Log("Capa Datos", ex)
                Throw New Exception("No se puede eliminar el miembro porque tiene una membresía asociada.")
            Else
                ManejarErrores.Log("Capa Datos", ex)
                Throw
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Busca miembros por nombre o apellido utilizando la cláusula LIKE.
    ''' </summary>
    ''' <param name="nombre">Nombre o parte del nombre/apellido del miembro a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorNombre(nombre As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM miembros WHERE nombre LIKE @nombre OR apellido LIKE @apellido ORDER BY ultima_modificacion DESC"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@nombre", nombre & "%"},
            {"@apellido", nombre & "%"}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Obtiene un miembro por su DNI exacto.
    ''' </summary>
    ''' <param name="dni">DNI del miembro a buscar.</param>
    ''' <returns>DataTable con los datos del miembro encontrado.</returns>
    Public Function ObtenerPorDni(dni As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM miembros WHERE dni = @dni"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", dni}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Busca miembros por coincidencia parcial de DNI utilizando la cláusula LIKE.
    ''' </summary>
    ''' <param name="dni">DNI o parte del DNI del miembro a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorDni(dni As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM miembros WHERE dni LIKE @dni ORDER BY ultima_modificacion DESC"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", dni & "%"}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function
End Class
