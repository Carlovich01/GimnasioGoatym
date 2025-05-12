Imports System.Data
Imports Gimnasio.Entidades
Imports LogDeErrores

Public Class DReclamos
    Inherits ConexionBase

    'VIEW `vista_reclamos` AS
    'Select Case
    '    `r`.`id_reclamos` AS `id_reclamos`,
    '    `r`.`tipo` AS `tipo`,
    '    `r`.`descripcion` AS `descripcion`,
    '    `r`.`fecha_envio` AS `fecha_envio`,
    '    `r`.`estado` AS `estado`,
    '    `r`.`respuesta` AS `respuesta`,
    '    `r`.`fecha_respuesta` AS `fecha_respuesta`,
    '    `m`.`dni` AS `dni_miembro`
    'FROM
    '    (`reclamos` `r`
    '    LEFT JOIN `miembros` `m` On ((`r`.`id_miembro` = `m`.`id_miembro`)))
    'ORDER BY `r`.`fecha_envio` DESC
    Public Function Listar() As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_reclamos"
            Return ExecuteQuery(query, Nothing)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

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
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub

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
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub

    Public Sub Eliminar(id As UInteger)
        Try
            Dim query As String = "DELETE FROM reclamos WHERE id_reclamos = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", id}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub

    Public Sub ActualizarElEstadoAResuelto(id As UInteger)
        Try
            Dim query As String = "UPDATE reclamos SET estado = 'resuelto' WHERE id_reclamos = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", id}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub

    Public Sub ActualizarElEstadoAPendiente(id As UInteger)
        Try
            Dim query As String = "UPDATE reclamos SET estado = 'pendiente' WHERE id_reclamos = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", id}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub

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
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub

    Public Function ListarPorEstado(Estado As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_reclamos WHERE estado = @estado"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@estado", Estado}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function
End Class
