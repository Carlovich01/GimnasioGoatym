Imports System.Data
Imports Gimnasio.Entidades
Imports Gimnasio.Errores

''' <summary>
''' Clase de acceso a datos para la gestión de reclamos en el sistema de gimnasio.
''' Hereda de <see cref="ConexionBase"/> y utiliza la entidad <see cref="Reclamos"/>.
''' Proporciona métodos CRUD y de búsqueda para la tabla reclamos y la vista vista_reclamos.
'''</summary>
'''<remarks>
''' La vista consolida la información relevante de los reclamos, permitiendo consultar en una sola consulta datos del reclamo 
''' y el miembro que lo realizo.
''' Realiza LEFT JOIN entre la reclamos y miembros, permitiendo obtener la información de reclamo incluso si los datos de miembro no están presentes.
''' <code>
''' VIEW `vista_reclamos` As
''' SELECT
'''        `r`.`id_reclamos` AS `id_reclamos`,
'''        `r`.`tipo` AS `tipo`,
'''        `r`.`descripcion` AS `descripcion`,
'''        `r`.`fecha_envio` AS `fecha_envio`,
'''        `r`.`estado` AS `estado`,
'''        `r`.`respuesta` AS `respuesta`,
'''        `r`.`fecha_respuesta` AS `fecha_respuesta`,
'''        `m`.`dni` AS `dni_miembro`
''' FROM
'''        (`reclamos` `r`
'''        LEFT JOIN `miembros` `m` On ((`r`.`id_miembro` = `m`.`id_miembro`)))
'''    ORDER BY `r`.`fecha_envio` DESC
''' </code>
''' 
''' Los diccionarios se utilizan para asociar los parametros de la consulta con los parametros del metodo
''' </remarks>
Public Class DReclamos
    Inherits ConexionBase

    ''' <summary>
    ''' Realiza una consulta SQL (SELECT) que obtiene todos los registros de la vista_reclamos.
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
    ''' Recibe una instancia de Reclamos y ejecuta una sentencia SQL (INSERT) que inserta un nuevo registro de reclamos con los datos proporcionados.
    ''' Si id de miembro es nulo, se insertará NULL en la base de datos
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
    ''' Recibe una instancia de Reclamos y ejecuta una sentencia SQL (UPDATE) que actualiza los datos de un registro de reclamo existente que 
    ''' corresponde al id de la instancia. 
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
    ''' Recibe el id del reclamo a eliminar y ejecuta una sentencia SQL (DELETE) que elimina el registro de reclamo correspondiente.
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
    ''' Recibe un id de reclamo y ejecuta una sentencia SQL (UPDATE) que actualiza el estado a resuelto de un registro de reclamo  que 
    ''' corresponde al id.
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
    ''' Recibe un id de reclamo y ejecuta una sentencia SQL (UPDATE) que actualiza el estado a pendiente de un registro de reclamo  que 
    ''' corresponde al id.
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
    ''' Recibe una instancia de Reclamos y ejecuta una sentencia SQL (UPDATE) que actualiza el campo de respuesta de un registro de reclamo existente 
    ''' que corresponde al id de la instancia. 
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
    ''' Recibe el estado y ejecuta una sentencia SQL (SELECT) que obtiene los registros de reclamos que tienen ese estado.
    ''' </summary>
    ''' <param name="Estado">Estado del reclamo ("pendiente", "resuelto").</param>
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

