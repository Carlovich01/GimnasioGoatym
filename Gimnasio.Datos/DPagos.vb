Imports System.Data
Imports Gimnasio.Entidades
Imports Gimnasio.Errores

''' <summary>
''' Clase de acceso a datos para la gestión de pagos en el sistema de gimnasio.
''' Hereda de <see cref="ConexionBase"/> y utiliza la entidad <see cref="Pagos"/>.
''' Proporciona métodos CRUD y de búsqueda para la tabla pagos y la vista vista_pagos.
''' 
''' La vista consolida la información relevante de los registros de pagos,
''' Permite consultar en una sola consulta los datos del pago, el miembro, el plan, el usuario que registró el pago.
''' Realiza LEFT JOIN entre pagos y las demás tablas, permitiendo obtener la información de pagos
''' incluso si los datos de miembro, membresía, plan o usuario no están presentes.
''' <code>
''' VIEW `vista_pagos` AS
'''    SELECT 
'''        `p`.`id_pago` AS `id_pago`,
'''        `p`.`id_membresia` AS `id_membresia`,
'''        `p`.`id_usuario_registro` AS `id_usuario_registro`,
'''        `m`.`apellido` AS `apellido_miembro`,
'''        `m`.`nombre` AS `nombre_miembro`,
'''        `m`.`dni` AS `dni_miembro`,
'''        `pm`.`nombre_plan` AS `nombre_plan`,
'''        `p`.`monto_pagado` AS `monto`,
'''        `p`.`metodo_pago` AS `metodo`,
'''        `p`.`numero_comprobante` AS `comprobante`,
'''        `p`.`notas` AS `notas`,
'''        `p`.`fecha_pago` AS `fecha_pago`,
'''        `us`.`nombre_completo` AS `nombre_usuario`
'''    FROM
'''        ((((`pagos` `p`
'''        LEFT JOIN `membresias_miembro` `mm` ON ((`p`.`id_membresia` = `mm`.`id_membresia`)))
'''        LEFT JOIN `miembros` `m` ON ((`mm`.`id_miembro` = `m`.`id_miembro`)))
'''        LEFT JOIN `planes_membresia` `pm` ON ((`mm`.`id_plan` = `pm`.`id_plan`)))
'''        LEFT JOIN `usuarios_sistema` `us` ON ((`p`.`id_usuario_registro` = `us`.`id_usuario`)))
'''    ORDER BY `p`.`fecha_pago` DESC
''' </code>
''' 
''' Los diccionarios se utilizan para asociar los parametros de la consulta con los parametros del metodo
''' </summary>
Public Class DPagos
    Inherits ConexionBase

    ''' <summary>
    ''' Realizaa una consulta SQL(SELECT) que Obtiene todos los pagos desde la vista_pagos.
    ''' </summary>
    ''' <returns>DataTable con los datos de los pagos.</returns>
    Public Function Listar() As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_pagos"
            Return ExecuteQuery(query, Nothing)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Recibe una instancia de Pagos y ejecuta una sentencia SQL (INSERT) que inserta un nuevo registro de pago con los datos proporcionados.
    ''' Si los datos son nulos, se insertará NULL en la base de datos.
    ''' </summary>
    ''' <param name="pago">Instancia de <see cref="Pagos"/> a insertar.</param>
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
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Recibe una instancia de Pago y ejecuta una sentencia SQL (UPDATE) que actualiza los datos de un registro de pago existente que 
    ''' corresponde al id de la instancia. 
    ''' </summary>
    ''' <param name="pago">Instancia de <see cref="Pagos"/> con los datos actualizados.</param>
    Public Sub Actualizar(pago As Pagos)
        Try
            Dim query As String = "UPDATE pagos SET monto_pagado = @mont, metodo_pago = @met, numero_comprobante = @num, notas = @notas WHERE id_pago = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@mont", pago.MontoPagado},
            {"@met", pago.MetodoPago},
            {"@num", If(pago.NumeroComprobante = Nothing, DBNull.Value, pago.NumeroComprobante)},
            {"@notas", If(pago.Notas = Nothing, DBNull.Value, pago.Notas)},
            {"@id", pago.IdPago}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Recibe el id del pago a eliminar y ejecuta una sentencia SQL (DELETE) que elimina el registro de pago correspondiente.
    ''' </summary>
    ''' <param name="id">Identificador único del pago a eliminar.</param>
    Public Sub Eliminar(id As UInteger)
        Try
            Dim query As String = "DELETE FROM pagos WHERE id_pago = @id"
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
    ''' Realiza una consulta SQL (SELECT) sobre la vista_pagos para obtener los registros cuya fecha de pago se encuentre
    ''' dentro del rango proporcionado.
    ''' </summary>
    ''' <param name="fechaInicio">Fecha de inicio del rango.</param>
    ''' <param name="fechaFin">Fecha de fin del rango.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorFecha(fechaInicio As DateTime, fechaFin As DateTime) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_pagos WHERE fecha_pago BETWEEN @fechaInicio AND @fechaFin"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@fechaInicio", fechaInicio},
            {"@fechaFin", fechaFin}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Recibe un dni de miembro y ejecuta una sentencia SQL (SELECT) que obtiene los registros de pagos correspondientes al miembro.
    ''' Permite buscar por parte del DNI utilizando la cláusula LIKE.
    ''' </summary>
    ''' <param name="dni">DNI o parte del DNI del miembro a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorDni(dni As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_pagos WHERE dni_miembro LIKE @dni"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", dni & "%"}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Recibe el nombre de un plan y ejecuta una sentencia SQL (SELECT) que obtiene los registros de pagos correspondientes a ese plan.
    ''' Permite buscar por parte del nombre utilizando la cláusula LIKE.
    ''' </summary>
    ''' <param name="nombre">Nombre o parte del nombre del plan a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorNombrePlan(nombre As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_pagos WHERE nombre_plan LIKE @nombre"
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
    ''' Recibe el metodo de pago y ejecuta una sentencia SQL (SELECT) que obtiene los registros de pago que tienen ese metodo.
    ''' </summary>
    ''' <param name="metodoPago">Método de pago a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorMetodoPago(metodoPago As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_pagos WHERE metodo = @metodoPago"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@metodoPago", metodoPago}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Realiza una consulta SQL (SELECT) sobre la vista_pagos para obtener los registros cuyo monto se encuentre
    ''' dentro del rango proporcionado.
    ''' </summary>
    ''' <param name="montoMin">Monto mínimo.</param>
    ''' <param name="montoMax">Monto máximo.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
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
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function
End Class

