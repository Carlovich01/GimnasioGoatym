Imports System.Data
Imports Gimnasio.Entidades
Imports Gimnasio.Errores

''' <summary>
''' Clase de acceso a datos para la gestión de membresías en el sistema de gimnasio.
''' Hereda de <see cref="ConexionBase"/> y utiliza la entidad <see cref="Membresias"/>.
''' Proporciona métodos CRUD y de búsqueda para la tabla membresias_miembro y la vista vista_membresias.
''' </summary>
''' <remarks>
''' La vista_membresias es una vista SQL que consolida información relevante de las membresías,
''' uniendo datos de las tablas membresias_miembro, miembros y planes_membresia.
''' <code>
''' VIEW `vista_membresias` AS
'''    SELECT 
'''        `mm`.`id_membresia` AS `id_membresia`,
'''        `mm`.`id_miembro` AS `id_miembro`,
'''        `mm`.`id_plan` AS `id_plan`,
'''        `m`.`dni` AS `dni_miembro`,
'''        `m`.`apellido` AS `apellido_miembro`,
'''        `m`.`nombre` AS `nombre_miembro`,
'''        `p`.`nombre_plan` AS `nombre_plan`,
'''        `p`.`precio` AS `precio_plan`,
'''        `p`.`duracion_dias` AS `duracion_dias_plan`,
'''        `mm`.`fecha_inicio` AS `fecha_inicio`,
'''        `mm`.`fecha_fin` AS `fecha_fin`,
'''        `mm`.`estado_membresia` AS `estado_membresia`,
'''        `mm`.`fecha_registro` AS `fecha_registro`,
'''        `mm`.`ultima_modificacion` AS `ultima_modificacion`
'''    FROM
'''        ((`membresias_miembro` `mm`
'''        JOIN `miembros` `m` ON ((`mm`.`id_miembro` = `m`.`id_miembro`)))
'''        JOIN `planes_membresia` `p` ON ((`mm`.`id_plan` = `p`.`id_plan`)))
'''    ORDER BY `mm`.`ultima_modificacion` DESC
''' </code>
''' 
''' Los diccionarios se utilizan para asociar los parametros de la consulta con los parametros del metodo
''' </remarks>
Public Class DMembresias
    Inherits ConexionBase

    ''' <summary>
    ''' Realiza una consulta SQL (SELECT) que obtiene todas las membresías de la vista vista_membresias.
    ''' </summary>
    ''' <returns>DataTable con los datos de las membresías.</returns>
    Public Function Listar() As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_membresias"
            Return ExecuteQuery(query, Nothing)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Recibe una instancia de Membresia y ejecuta una sentencia SQL (INSERT) que inserta un nuevo registro de membresia con los datos proporcionados.
    ''' </summary>
    ''' <param name="membresia">Instancia de <see cref="Membresias"/> a insertar.</param>
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
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Recibe una instancia de Membresia y ejecuta una sentencia SQL (UPDATE) que actualiza el plan de un registro de membresia existente que 
    ''' corresponde al id de la instancia. 
    ''' </summary>
    ''' <param name="membresia">Instancia de <see cref="Membresias"/> con los datos actualizados.</param>
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
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Recibe el id de la membresia a eliminar y ejecuta una sentencia SQL (DELETE) que elimina el registro de membresia correspondiente.
    ''' </summary>
    ''' <param name="id">Id único de la membresía a eliminar.</param>
    Public Sub Eliminar(id As UInteger)
        Try
            Dim query As String = "DELETE FROM membresias_miembro WHERE id_membresia = @id"
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
    ''' Recibe una instancia de Membresia y ejecuta una sentencia SQL (SELECT) que obtiene el id de la membresia correspondiente a la instancia.
    ''' Luego lo convierte a entero. 
    ''' </summary>
    ''' <param name="membresia">Instancia de <see cref="Membresias"/> para la cual se busca el ID.</param>
    ''' <returns>Identificador único de la membresía.</returns>
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
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Recibe una instancia de Membresia y ejecuta una sentencia SQL (UPDATE) que actualiza las fechas de un registro de membresia existente que 
    ''' corresponde al id de la instancia.
    ''' </summary>
    ''' <param name="membresia">Instancia de <see cref="Membresias"/> con los datos a actualizar.</param>
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
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Ejecuta una sentencia SQL (UPDATE) que actualiza el estado de un registro de membresia existente a inactiva si la fecha de vencimiento
    ''' es menor que la fecha actual.
    ''' </summary>
    Public Sub ActualizarAEstadoInactiva()
        Try
            Dim query As String = "
            UPDATE membresias_miembro
            SET estado_membresia = 'Inactiva'
            WHERE estado_membresia = 'Activa' AND fecha_fin < CURDATE()"
            ExecuteNonQuery(query, Nothing)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Recibe un id de membresia y ejecuta una sentencia SQL (SELECT) que obtiene la duración del plan de la membresía correspondiente.
    ''' Luego, la convierte a entero.
    ''' </summary>
    ''' <param name="idMembresia">Identificador único de la membresía.</param>
    ''' <returns>Duración en días del plan.</returns>
    Public Function ObtenerDuracionPorMembresia(idMembresia As UInteger) As UInteger
        Try
            Dim query As String = "
            SELECT duracion_dias_plan
            FROM vista_membresias
            WHERE id_membresia = @idMembresia"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@idMembresia", idMembresia}
        }
            Dim resultado = ExecuteQuery(query, parameters)
            Return If(resultado.Rows.Count > 0, Convert.ToUInt32(resultado.Rows(0)("duracion_dias_plan")), 0)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Recibe un dni de miembro y ejecuta una sentencia SQL (SELECT) que obtiene los registros de la membresías correspondientes al miembro.
    ''' </summary>
    ''' <param name="dni">DNI del miembro.</param>
    ''' <returns>DataTable con los datos de la membresía encontrada.</returns>
    Public Function ObtenerPorDni(dni As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_membresias WHERE dni_miembro=@dni"
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
    ''' Recibe un dni de miembro y ejecuta una sentencia SQL (SELECT) que obtiene los registros de la membresías correspondientes al miembro.
    ''' Permite buscar por parte del DNI utilizando la cláusula LIKE.
    ''' </summary>
    ''' <param name="dni">DNI o parte del DNI del miembro a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorDni(dni As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_membresias WHERE dni_miembro LIKE @dni"
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
    ''' Recibe el nombre de un plan y ejecuta una sentencia SQL (SELECT) que obtiene los registros de membresías que tienen ese plan.
    ''' Permite buscar por parte del nombre utilizando la cláusula LIKE.
    ''' </summary>
    ''' <param name="nombrePlan">Nombre o parte del nombre del plan a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorNombrePlan(nombrePlan As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_membresias WHERE nombre_plan LIKE @nombrePlan"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@nombrePlan", nombrePlan & "%"}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Recibe el estado(Activa, Inactiva) y ejecuta una sentencia SQL (SELECT) que obtiene los registros de membresías que tienen ese estado.
    ''' </summary>
    ''' <param name="estado">Estado de la membresía.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorEstado(estado As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_membresias WHERE estado_membresia = @estado"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@estado", estado}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Recibe una instancia de membresia y ejecuta una sentencia SQL (SELECT COUNT *) que cuenta la cantidad total de registros de membresia
    ''' con el mismo id_miembro y id_plan. Si el resultado es mayor a 0, significa que ya existe una membresía activa con ese plan para ese miembro.  
    ''' </summary>
    ''' <param name="membresia">Instancia de <see cref="Membresias"/> a verificar.</param>
    ''' <returns>True si existe, False en caso contrario.</returns>
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

    ''' <summary>
    ''' Recibe un id de Miembro y ejecuta una sentencia SQL (SELECT) que obtiene la membresía más reciente del miembro.
    ''' La consulta ordena por fecha de fin en orden descendente y limita el resultado a 1.
    ''' </summary>
    ''' <param name="idMiembro">Identificador único del miembro.</param>
    ''' <returns>DataTable con los datos de la membresía más reciente.</returns>
    Public Function ObtenerMembresiaMasReciente(idMiembro As UInteger) As DataTable
        Try
            Dim query As String = "SELECT * FROM membresias_miembro WHERE id_miembro = @idMiembro ORDER BY fecha_fin DESC LIMIT 1"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@idMiembro", idMiembro}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function
End Class

