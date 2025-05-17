Imports System.Data
Imports Gimnasio.Entidades
Imports Gimnasio.Errores

''' <summary>
''' Clase de acceso a datos para la gestión de membresías en el sistema de gimnasio.
''' Hereda de <see cref="ConexionBase"/> y utiliza la entidad <see cref="Membresias"/>.
''' Proporciona métodos CRUD y de búsqueda para la tabla <c>membresias_miembro</c> y la vista <c>vista_membresias</c>.
''' </summary>
Public Class DMembresias
    Inherits ConexionBase

    ''' <summary>
    ''' Obtiene todas las membresías desde la vista <c>vista_membresias</c>.
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
    ''' Inserta una nueva membresía en la base de datos.
    ''' Utiliza los datos de la entidad <see cref="Membresias"/>.
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
    ''' Actualiza los datos de una membresía existente en la base de datos.
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
    ''' Elimina una membresía de la base de datos según su identificador.
    ''' </summary>
    ''' <param name="id">Identificador único de la membresía a eliminar.</param>
    ''' <exception cref="Exception">Se lanza si la membresía tiene pagos asociados o por errores de la base de datos.</exception>
    Public Sub Eliminar(id As UInteger)
        Try
            Dim query As String = "DELETE FROM membresias_miembro WHERE id_membresia = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", id}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            If ex.Message.Contains("a foreign key constraint fails") Then
                ManejarErrores.Log("Capa Datos", ex)
                Throw New Exception("No se puede eliminar la membresia porque tiene un pago asociado.")
            Else
                ManejarErrores.Log("Capa Datos", ex)
                Throw
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene el identificador de una membresía específica según el miembro y el plan.
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
    ''' Actualiza el estado y las fechas de una membresía.
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
    ''' Actualiza el estado de las membresías vencidas a "Inactiva".
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
    ''' Obtiene la duración (en días) del plan asociado a una membresía.
    ''' </summary>
    ''' <param name="idMembresia">Identificador único de la membresía.</param>
    ''' <returns>Duración en días del plan.</returns>
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
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Obtiene una membresía por el DNI exacto del miembro.
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
    ''' Busca membresías por coincidencia parcial de DNI utilizando la cláusula LIKE.
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
    ''' Busca membresías por nombre de plan utilizando la cláusula LIKE.
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
    ''' Busca membresías por estado (por ejemplo: "Activa", "Inactiva").
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
    ''' Verifica si ya existe una membresía para un miembro y plan determinados.
    ''' </summary>
    ''' <param name="membresia">Instancia de <see cref="Membresias"/> a verificar.</param>
    ''' <returns><c>True</c> si existe, <c>False</c> en caso contrario.</returns>
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
    ''' Obtiene la membresía más reciente de un miembro específico.
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

