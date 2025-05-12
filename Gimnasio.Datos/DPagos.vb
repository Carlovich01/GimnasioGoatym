Imports System.Data
Imports Gimnasio.Entidades
Imports LogDeErrores

Public Class DPagos
    Inherits ConexionBase

    'VIEW `vista_pagos` AS
    'SELECT 
    '    `p`.`id_pago` AS `id_pago`,
    '    `p`.`id_membresia` AS `id_membresia`,
    '    `p`.`id_usuario_registro` AS `id_usuario_registro`,
    '    `m`.`apellido` AS `apellido_miembro`,
    '    `m`.`nombre` AS `nombre_miembro`,
    '    `m`.`dni` AS `dni_miembro`,
    '    `pm`.`nombre_plan` AS `nombre_plan`,
    '    `p`.`monto_pagado` AS `monto`,
    '    `p`.`metodo_pago` AS `metodo`,
    '    `p`.`numero_comprobante` AS `comprobante`,
    '    `p`.`fecha_pago` AS `fecha_pago`,
    '    `us`.`nombre_completo` AS `nombre_usuario`
    'FROM
    '    ((((`pagos` `p`
    '    LEFT JOIN `membresias_miembro` `mm` ON ((`p`.`id_membresia` = `mm`.`id_membresia`)))
    '    LEFT JOIN `miembros` `m` ON ((`mm`.`id_miembro` = `m`.`id_miembro`)))
    '    LEFT JOIN `planes_membresia` `pm` ON ((`mm`.`id_plan` = `pm`.`id_plan`)))
    '    LEFT JOIN `usuarios_sistema` `us` ON ((`p`.`id_usuario_registro` = `us`.`id_usuario`)))
    'ORDER BY `p`.`fecha_pago` DESC
    Public Function Listar() As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_pagos"
            Return ExecuteQuery(query, Nothing)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

    Public Sub Insertar(pago As Pagos)
        Try
            Dim query As String = "INSERT INTO pagos (id_membresia, id_usuario_registro, monto_pagado, metodo_pago, numero_comprobante, notas) VALUES (@idmem, @idus, @mont, @met, @num, @notas)"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@idmem", If(pago.IdMembresia.HasValue, pago.IdMembresia, DBNull.Value)},
            {"@idus", If(pago.IdUsuarioRegistro.HasValue, pago.IdUsuarioRegistro, DBNull.Value)},
            {"@mont", pago.MontoPagado},
            {"@met", pago.MetodoPago},
            {"@num", If(pago.NumeroComprobante = Nothing, DBNull.Value, pago.NumeroComprobante)},
            {"@notas", If(pago.Notas = Nothing, DBNull.Value, pago.Notas)}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub

    Public Sub Eliminar(id As UInteger)
        Try
            Dim query As String = "DELETE FROM pagos WHERE id_pago = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", id}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub


    Public Function ListarPorFecha(fechaInicio As DateTime, fechaFin As DateTime) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_pagos WHERE fecha_pago BETWEEN @fechaInicio AND @fechaFin"
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

    Public Function ListarPorDni(dni As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_pagos WHERE dni_miembro LIKE @dni"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", "%" & dni & "%"}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

    Public Function ListarPorNombrePlan(nombre As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_pagos WHERE nombre_plan LIKE @nombre"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@nombre", "%" & nombre & "%"}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

    Public Function ListarPorMetodoPago(metodoPago As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_pagos WHERE metodo = @metodoPago"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@metodoPago", metodoPago}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

    Public Function ListarPorMontos(montoMin As Decimal, montoMax As Decimal) As DataTable
        Try
            Dim query As String = "
            SELECT * 
            FROM vista_pagos
            WHERE monto BETWEEN @montoMin AND @montoMax"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@montoMin", montoMin},
            {"@montoMax", montoMax}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function
End Class

