Imports System.Data
Imports Gimnasio.Entidades
Imports LogDeErrores

Public Class DMembresias
    Inherits ConexionBase

    'VIEW `vista_membresias` AS
    'SELECT 
    '    `mm`.`id_membresia` AS `id_membresia`,
    '    `mm`.`id_miembro` AS `id_miembro`,
    '    `mm`.`id_plan` AS `id_plan`,
    '    `m`.`dni` AS `dni_miembro`,
    '    `m`.`apellido` AS `apellido_miembro`,
    '    `m`.`nombre` AS `nombre_miembro`,
    '    `p`.`nombre_plan` AS `nombre_plan`,
    '    `p`.`precio` AS `precio_plan`,
    '    `p`.`duracion_dias` AS `duracion_dias_plan`,
    '    `mm`.`fecha_inicio` AS `fecha_inicio`,
    '    `mm`.`fecha_fin` AS `fecha_fin`,
    '    `mm`.`estado_membresia` AS `estado_membresia`,
    '    `mm`.`fecha_registro` AS `fecha_registro`,
    '    `mm`.`ultima_modificacion` AS `ultima_modificacion`
    'FROM
    '    ((`membresias_miembro` `mm`
    '    JOIN `miembros` `m` ON ((`mm`.`id_miembro` = `m`.`id_miembro`)))
    '    JOIN `planes_membresia` `p` ON ((`mm`.`id_plan` = `p`.`id_plan`)))
    'ORDER BY `mm`.`ultima_modificacion` DESC

    Public Function Listar() As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_membresias"
            Return ExecuteQuery(query, Nothing)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

    Public Sub Insertar(membresia As Membresias)
        Try
            Dim query As String = "INSERT INTO membresias_miembro (id_miembro, id_plan, fecha_inicio, fecha_fin) VALUES (@idmi, @idpla, @in, @fin)"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@idmi", membresia.IdMiembro},
            {"@idpla", membresia.IdPlan},
            {"@in", membresia.FechaInicio},
            {"@fin", membresia.FechaFin}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub

    Public Sub Actualizar(membresia As Membresias)
        Try
            Dim query As String = "
        UPDATE membresias_miembro
        SET id_plan = @idPlan
        WHERE id_membresia = @idMembresia"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@idPlan", membresia.IdPlan},
            {"@idMembresia", membresia.IdMembresia}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub


    Public Sub Eliminar(id As UInteger)
        Try
            Dim query As String = "DELETE FROM membresias_miembro WHERE id_membresia = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", id}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            If ex.Message.Contains("a foreign key constraint fails") Then
                Logger.LogError("Capa Datos", ex)
                Throw New Exception("No se puede eliminar la membresia porque tiene un pago asociado.")
            Else
                Logger.LogError("Capa Datos", ex)
                Throw
            End If
        End Try
    End Sub

    Public Function ObtenerIdMembresia(membresia As Membresias) As UInteger
        Try
            Dim query As String = "SELECT id_membresia FROM membresias_miembro WHERE id_miembro = @idmi AND id_plan = @idpla"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@idmi", membresia.IdMiembro},
            {"@idpla", membresia.IdPlan}
        }
            Dim resultado = ExecuteQuery(query, parameters)
            Return If(resultado.Rows.Count > 0, Convert.ToUInt32(resultado.Rows(0)("id_membresia")), 0)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

    Public Sub ActualizarEstadoYFechas(membresia As Membresias)
        Try
            Dim query As String = "
            UPDATE membresias_miembro
            SET estado_membresia = @estado, fecha_inicio = @fechaInicio, fecha_fin = @fechaFin
            WHERE id_membresia = @idMembresia"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@estado", membresia.EstadoMembresia},
            {"@fechaInicio", membresia.FechaInicio},
            {"@fechaFin", membresia.FechaFin},
            {"@idMembresia", membresia.IdMembresia}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub

    Public Sub ActualizarAEstadoInactiva()
        Try
            Dim query As String = "
            UPDATE membresias_miembro
            SET estado_membresia = 'Inactiva'
            WHERE estado_membresia = 'Activa' AND fecha_fin < CURDATE()"
            ExecuteNonQuery(query, Nothing)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub

    Public Function ObtenerDuracionPorMembresia(idMembresia As UInteger) As UInteger
        Try
            Dim query As String = "
            SELECT p.duracion_dias
            FROM membresias_miembro mm
            INNER JOIN planes_membresia p ON mm.id_plan = p.id_plan
            WHERE mm.id_membresia = @idMembresia"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@idMembresia", idMembresia}
        }
            Dim resultado = ExecuteQuery(query, parameters)
            Return If(resultado.Rows.Count > 0, Convert.ToUInt32(resultado.Rows(0)("duracion_dias")), 0)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

    Public Function ObtenerPorDni(dni As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_membresias WHERE dni_miembro=@dni"
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
            Dim query As String = "SELECT * FROM vista_membresias WHERE dni_miembro LIKE @dni"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", dni & "%"}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

    Public Function ListarPorNombrePlan(nombrePlan As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_membresias WHERE nombre_plan LIKE @nombrePlan"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@nombrePlan", nombrePlan & "%"}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

    Public Function ListarPorEstado(estado As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_membresias WHERE estado_membresia = @estado"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@estado", estado}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

    Public Function VerificarExistenciaDeMiembroYPlan(membresia As Membresias) As Boolean
        Dim verificarQuery As String = "
            SELECT COUNT(*) 
            FROM membresias_miembro 
            WHERE id_miembro = @idMiembro 
              AND id_plan = @idPlan"
        Dim verificarParams As New Dictionary(Of String, Object) From {
        {"@idMiembro", membresia.IdMiembro},
        {"@idPlan", membresia.IdPlan}
    }
        Dim existe As UInteger = Convert.ToUInt32(ExecuteQuery(verificarQuery, verificarParams).Rows(0)(0))
        If existe > 0 Then
            Return True
        End If
        Return False
    End Function

    Public Function ObtenerMembresiaMasReciente(idMiembro As UInteger) As DataTable
        Try
            Dim query As String = "SELECT * FROM membresias_miembro WHERE id_miembro = @idMiembro ORDER BY fecha_fin DESC LIMIT 1"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@idMiembro", idMiembro}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function
End Class
