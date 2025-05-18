Imports System.Data
Imports Gimnasio.Entidades
Imports Gimnasio.Errores

''' <summary>
''' Clase de acceso a datos para la gestión de asistencias.
''' Hereda de <see cref="ConexionBase"/> y utiliza la entidad <see cref="Asistencia"/>.
''' Proporciona métodos CRUD y de búsqueda para la tabla asistencia y la vista vista_asistencia.
''' 
''' La vista consolida la información relevante de los registros de asistencias,
''' permitiendo consultar en una sola consulta datos de la asistencia, el miembro, la membresía y el plan asociado.
''' Realiza LEFT JOIN entre la asistencia y las demás tablas, permitiendo obtener la información de asistencia
''' incluso si los datos de miembro, membresía o plan no están presentes.
''' <code>
''' VIEW `vista_asistencia` AS
'''    SELECT 
'''        `a`.`id_asistencia` AS `id_asistencia`,
'''        `a`.`id_miembro` AS `id_miembro`,
'''        `a`.`id_membresia_valida` AS `id_membresia`,
'''        `m`.`dni` AS `dni_miembro`,
'''        `m`.`nombre` AS `nombre_miembro`,
'''        `m`.`apellido` AS `apellido_miembro`,
'''       `a`.`fecha_hora_checkin` AS `fecha_ingreso`,
'''        `a`.`resultado` AS `resultado`,
'''       `pm`.`nombre_plan` AS `nombre_plan_membresia`
'''    FROM
'''       (((`asistencia` `a`
'''       LEFT JOIN `miembros` `m` ON ((`a`.`id_miembro` = `m`.`id_miembro`)))
'''       LEFT JOIN `membresias_miembro` `mm` ON ((`a`.`id_membresia_valida` = `mm`.`id_membresia`)))
'''       LEFT JOIN `planes_membresia` `pm` ON ((`mm`.`id_plan` = `pm`.`id_plan`)))
'''    ORDER BY `a`.`fecha_hora_checkin` DESC
''' </code>
''' 
''' Los diccionarios se utilizan para asociar los parametros de la consulta con los parametros del metodo
''' </summary>
Public Class DAsistencia
    Inherits ConexionBase
    ''' <summary>
    ''' Realiza una consulta SQL (SELECT) que obtiene todos los registros de la vista_asistencia.
    ''' </summary>
    ''' <returns>DataTable con los datos de las asistencias.</returns>
    Public Function Listar() As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_asistencia"
            Return ExecuteQuery(query, Nothing)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Recibe el id de la asistencia a eliminar y ejecuta una sentencia SQL (DELETE) que elimina el registro de asistencia correspondiente.
    ''' </summary>
    ''' <param name="id">Id único de la asistencia a eliminar.</param>
    Public Sub Eliminar(id As UInteger)
        Try
            Dim query As String = "DELETE FROM asistencia WHERE id_asistencia = @id"
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
    ''' Recibe una instancia de Asistencia y ejecuta una sentencia SQL (INSERT) que inserta un nuevo registro de asistencia con los datos proporcionados.
    ''' Si el id_miembro o id_membresia_valida son nulos, se insertará NULL en la base de datos
    ''' </summary>
    ''' <param name="asistencia">Instancia de Asistencia con los datos a insertar.</param>
    Public Sub RegistrarAsistencia(asistencia As Asistencia)
        Try
            Dim query As String = "
            INSERT INTO asistencia (id_miembro, fecha_hora_checkin, resultado, id_membresia_valida) 
            VALUES (@idMiembro, @fechaHoraCheckin, @resultado, @idMembresiaValida)"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@idMiembro", If(asistencia.IdMiembro.HasValue, asistencia.IdMiembro, DBNull.Value)},
            {"@fechaHoraCheckin", asistencia.FechaHoraCheckin},
            {"@resultado", asistencia.Resultado},
            {"@idMembresiaValida", If(asistencia.IdMembresiaValida.HasValue, asistencia.IdMembresiaValida, DBNull.Value)}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Realiza una consulta SQL (SELECT) sobre la vista_asistencia para obtener los registros de asistencias 
    ''' cuyo DNI del miembro coincida parcial o totalmente con el valor proporcionado.
    ''' </summary>
    ''' <param name="dni">DNI o parte del DNI del miembro a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorDNI(dni As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_asistencia WHERE dni_miembro LIKE @dni"
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
    ''' Realiza una consulta SQL (SELECT) sobre la vista_asistencia para obtener los registros de asistencias cuya fecha de ingreso se encuentre
    ''' dentro del rango proporcionado.
    ''' </summary>
    ''' <param name="fechaInicio">Fecha de inicio del rango.</param>
    ''' <param name="fechaFin">Fecha de fin del rango.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorFecha(fechaInicio As DateTime, fechaFin As DateTime) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_asistencia WHERE fecha_ingreso BETWEEN @fechaInicio AND @fechaFin"
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
End Class


