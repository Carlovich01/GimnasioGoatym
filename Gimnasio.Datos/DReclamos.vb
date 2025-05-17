Imports System.Data
Imports Gimnasio.Entidades
Imports Gimnasio.Errores

''' <summary>
''' Clase de acceso a datos para la gestión de reclamos en el sistema de gimnasio.
''' Hereda de <see cref="ConexionBase"/> y utiliza la entidad <see cref="Reclamos"/>.
''' Proporciona métodos CRUD y de búsqueda para la tabla <c>reclamos</c> y la vista <c>vista_reclamos</c>.
''' </summary>
Public Class DReclamos
    Inherits ConexionBase

    ''' <summary>
    ''' Obtiene todos los reclamos desde la vista <c>vista_reclamos</c>.
    ''' </summary>
    ''' <returns>DataTable con los datos de los reclamos.</returns>
    Public Function Listar() As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_reclamos"
            Return ExecuteQuery(query, Nothing)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Inserta un nuevo reclamo en la base de datos.
    ''' Utiliza los datos de la entidad <see cref="Reclamos"/>.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Reclamos"/> a insertar.</param>
    Public Sub Insertar(Obj As Reclamos)
        Try
            Dim query As String = "INSERT INTO reclamos (tipo, descripcion, id_miembro) VALUES (@tipo, @des, @idMiembro)"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@tipo", Obj.Tipo},
            {"@des", Obj.Descripcion},
            {"@idMiembro", If(Obj.IdMiembro.HasValue, Obj.IdMiembro, DBNull.Value)}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza los datos de un reclamo existente en la base de datos.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Reclamos"/> con los datos actualizados.</param>
    Public Sub Actualizar(Obj As Reclamos)
        Try
            Dim query As String = "UPDATE reclamos SET tipo = @tipo, descripcion = @des, id_miembro = @idMiembro WHERE id_reclamos = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", Obj.IdReclamos},
            {"@tipo", Obj.Tipo},
            {"@des", Obj.Descripcion},
            {"@idMiembro", If(Obj.IdMiembro.HasValue, Obj.IdMiembro, DBNull.Value)}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Elimina un reclamo de la base de datos según su identificador.
    ''' </summary>
    ''' <param name="id">Identificador único del reclamo a eliminar.</param>
    Public Sub Eliminar(id As UInteger)
        Try
            Dim query As String = "DELETE FROM reclamos WHERE id_reclamos = @id"
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
    ''' Cambia el estado de un reclamo a "resuelto".
    ''' </summary>
    ''' <param name="id">Identificador único del reclamo.</param>
    Public Sub ActualizarElEstadoAResuelto(id As UInteger)
        Try
            Dim query As String = "UPDATE reclamos SET estado = 'resuelto' WHERE id_reclamos = @id"
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
    ''' Cambia el estado de un reclamo a "pendiente".
    ''' </summary>
    ''' <param name="id">Identificador único del reclamo.</param>
    Public Sub ActualizarElEstadoAPendiente(id As UInteger)
        Try
            Dim query As String = "UPDATE reclamos SET estado = 'pendiente' WHERE id_reclamos = @id"
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
    ''' Actualiza la respuesta y la fecha de respuesta de un reclamo.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Reclamos"/> con la respuesta actualizada.</param>
    Public Sub ActualizarRespuesta(Obj As Reclamos)
        Try
            Dim query As String = "UPDATE reclamos SET respuesta = @respuesta, fecha_respuesta = @fechr WHERE id_reclamos = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@respuesta", Obj.Respuesta},
            {"@id", Obj.IdReclamos},
            {"@fechr", DateTime.Now}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Busca reclamos por estado utilizando la vista <c>vista_reclamos</c>.
    ''' </summary>
    ''' <param name="Estado">Estado del reclamo (por ejemplo: "pendiente", "resuelto").</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorEstado(Estado As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_reclamos WHERE estado = @estado"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@estado", Estado}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function
End Class

