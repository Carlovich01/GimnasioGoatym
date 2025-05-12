Imports System.Data
Imports Gimnasio.Entidades
Imports LogDeErrores

Public Class DAsistencia
    Inherits ConexionBase

    'VIEW `vista_asistencia` AS
    'Select Case
    '    `a`.`id_asistencia` AS `id_asistencia`,
    '    `a`.`id_miembro` AS `id_miembro`,
    '    `a`.`id_membresia_valida` AS `id_membresia`,
    '    `m`.`dni` AS `dni_miembro`,
    '    `m`.`nombre` AS `nombre_miembro`,
    '    `m`.`apellido` AS `apellido_miembro`,
    '    `a`.`fecha_hora_checkin` AS `fecha_ingreso`,
    '    `a`.`resultado` AS `resultado`
    'FROM
    '    ((`asistencia` `a`
    '    JOIN `miembros` `m` ON ((`a`.`id_miembro` = `m`.`id_miembro`)))
    '    LEFT JOIN `membresias_miembro` `mm` On ((`a`.`id_membresia_valida` = `mm`.`id_membresia`)))
    'ORDER BY `a`.`fecha_hora_checkin` DESC
    Public Function Listar() As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_asistencia"
            Return ExecuteQuery(query, Nothing)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

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

