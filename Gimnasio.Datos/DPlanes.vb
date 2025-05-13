Imports System.Data
Imports Gimnasio.Entidades
Imports LogDeErrores

''' <summary>
''' Clase de acceso a datos para la gestión de planes de membresía.
''' Hereda de <see cref="ConexionBase"/> y utiliza la entidad <see cref="Planes"/>.
''' Proporciona métodos CRUD y de búsqueda para la tabla <c>planes_membresia</c>.
''' </summary>
Public Class DPlanes
    Inherits ConexionBase

    ''' <summary>
    ''' Obtiene todos los planes de la base de datos ordenados por la última modificación.
    ''' </summary>
    ''' <returns><see cref="DataTable"/> con los datos de los planes.</returns>
    Public Function Listar() As DataTable
        Try
            Dim query As String = "SELECT * FROM planes_membresia ORDER BY ultima_modificacion DESC"
            Return ExecuteQuery(query, Nothing)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Inserta un nuevo plan en la base de datos.
    ''' Utiliza los datos de la entidad <see cref="Planes"/>.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Planes"/> a insertar.</param>
    ''' <exception cref="Exception">Se lanza si el nombre del plan ya existe o por errores de la base de datos.</exception>
    Public Sub Insertar(Obj As Planes)
        Try
            Dim query As String = "INSERT INTO planes_membresia (nombre_plan, descripcion, duracion_dias, precio) VALUES (@nom, @des, @dur, @pre)"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@nom", Obj.NombrePlan},
            {"@des", If(Obj.Descripcion = Nothing, DBNull.Value, Obj.Descripcion)},
            {"@dur", Obj.DuracionDias},
            {"@pre", Obj.Precio}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            If ex.Message.Contains("Duplicate entry") AndAlso ex.Message.Contains("nombre_plan") Then
                Logger.LogError("Capa Datos", ex)
                Throw New Exception("El nombre del plan" & Obj.NombrePlan & "ya existe. Por favor, elija otro nombre.")
            End If
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza los datos de un plan existente en la base de datos.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Planes"/> con los datos actualizados.</param>
    Public Sub Actualizar(Obj As Planes)
        Try
            Dim query As String = "UPDATE planes_membresia SET nombre_plan = @nom, descripcion = @des, duracion_dias = @dur, precio = @pre WHERE id_plan = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", Obj.IdPlan},
            {"@nom", Obj.NombrePlan},
            {"@des", If(Obj.Descripcion = Nothing, DBNull.Value, Obj.Descripcion)},
            {"@dur", Obj.DuracionDias},
            {"@pre", Obj.Precio}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Elimina un plan de la base de datos según su identificador.
    ''' </summary>
    ''' <param name="id">Identificador único del plan a eliminar.</param>
    ''' <exception cref="Exception">Se lanza si el plan tiene membresías asociadas o por errores de la base de datos.</exception>
    Public Sub Eliminar(id As UInteger)
        Try
            Dim query As String = "DELETE FROM planes_membresia WHERE id_plan = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", id}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            If ex.Message.Contains("a foreign key constraint fails") Then
                Logger.LogError("Capa Datos", ex)
                Throw New Exception("No se puede eliminar el plan porque tiene una membresía asociada.")
            Else
                Logger.LogError("Capa Datos", ex)
                Throw
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Busca planes por nombre utilizando la cláusula LIKE.
    ''' </summary>
    ''' <param name="nombre">Nombre o parte del nombre del plan a buscar.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    Public Function ListarPorNombre(nombre As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM planes_membresia WHERE nombre_plan LIKE @nombre ORDER BY ultima_modificacion DESC"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@nombre", nombre & "%"}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Busca planes por duración exacta en días.
    ''' </summary>
    ''' <param name="duracion">Duración en días del plan.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    Public Function ListarPorDuracion(duracion As UInteger) As DataTable
        Try
            Dim query As String = "SELECT * FROM planes_membresia WHERE duracion_dias = @duracion ORDER BY ultima_modificacion DESC"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@duracion", duracion}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Busca planes por precio exacto.
    ''' </summary>
    ''' <param name="precio">Precio del plan.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    Public Function ListarPorPrecio(precio As Decimal) As DataTable
        Try
            Dim query As String = "SELECT * FROM planes_membresia WHERE precio = @precio ORDER BY ultima_modificacion DESC"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@precio", precio}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw
        End Try
    End Function
End Class
