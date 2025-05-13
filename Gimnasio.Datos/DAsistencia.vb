Imports System.Data
Imports Gimnasio.Entidades
Imports LogDeErrores

''' <summary>
''' Clase de acceso a datos para la gestión de asistencias en el sistema de gimnasio.
''' Hereda de <see cref="ConexionBase"/> y utiliza la entidad <see cref="Asistencia"/>.
''' Proporciona métodos CRUD y de búsqueda para la tabla <c>asistencia</c> y la vista <c>vista_asistencia</c>.
''' </summary>
Public Class DAsistencia
    Inherits ConexionBase

    ''' <summary>
    ''' Obtiene todos los registros de asistencia desde la vista <c>vista_asistencia</c>.
    ''' </summary>
    ''' <returns><see cref="DataTable"/> con los datos de las asistencias.</returns>
    Public Function Listar() As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_asistencia"
            Return ExecuteQuery(query, Nothing)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Elimina un registro de asistencia de la base de datos según su identificador.
    ''' </summary>
    ''' <param name="id">Identificador único de la asistencia a eliminar.</param>
    Public Sub Eliminar(id As UInteger)
        Try
            Dim query As String = "DELETE FROM asistencia WHERE id_asistencia = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", id}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Inserta un nuevo registro de asistencia en la base de datos.
    ''' Utiliza los datos de la entidad <see cref="Asistencia"/>.
    ''' </summary>
    ''' <param name="asistencia">Instancia de <see cref="Asistencia"/> a registrar.</param>
    Public Sub RegistrarAsistencia(asistencia As Asistencia)
        Try
            Dim query As String = "INSERT INTO asistencia (id_miembro, fecha_hora_checkin, resultado, id_membresia_valida) VALUES (@idMiembro, @fechaHoraCheckin, @resultado, @idMembresiaValida)"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@idMiembro", If(asistencia.IdMiembro.HasValue, asistencia.IdMiembro, DBNull.Value)},
            {"@fechaHoraCheckin", asistencia.FechaHoraCheckin},
            {"@resultado", asistencia.Resultado},
            {"@idMembresiaValida", If(asistencia.IdMembresiaValida.HasValue, asistencia.IdMembresiaValida, DBNull.Value)}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Busca asistencias por coincidencia parcial de DNI utilizando la vista <c>vista_asistencia</c>.
    ''' </summary>
    ''' <param name="dni">DNI o parte del DNI del miembro a buscar.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    Public Function ListarPorDNI(dni As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_asistencia WHERE dni_miembro LIKE @dni"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", dni & "%"}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Busca asistencias por rango de fechas utilizando la vista <c>vista_asistencia</c>.
    ''' </summary>
    ''' <param name="fechaInicio">Fecha de inicio del rango.</param>
    ''' <param name="fechaFin">Fecha de fin del rango.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    Public Function ListarPorFecha(fechaInicio As DateTime, fechaFin As DateTime) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_asistencia WHERE fecha_ingreso BETWEEN @fechaInicio AND @fechaFin"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@fechaInicio", fechaInicio},
            {"@fechaFin", fechaFin}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function
End Class


