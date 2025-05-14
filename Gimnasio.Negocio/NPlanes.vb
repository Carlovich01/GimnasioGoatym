Imports System.Data
Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports LogDeErrores

''' <summary>
''' Lógica de negocio para la gestión de planes en el sistema de gimnasio.
''' Interactúa con la capa de datos <see cref="DPlanes"/> y la entidad <see cref="Planes"/>.
''' </summary>
Public Class NPlanes
    ''' <summary>
    ''' Instancia de la capa de datos para planes.
    ''' </summary>
    Private dPlanes As New DPlanes()

    ''' <summary>
    ''' Valida los campos de la entidad <see cref="Planes"/> antes de realizar operaciones de inserción o actualización.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Planes"/> a validar.</param>
    ''' <exception cref="Exception">Se lanza si algún campo no cumple con las reglas de negocio.</exception>
    Private Sub ValidarCampos(Obj As Planes)
        If Obj.NombrePlan.Length > 100 Then
            Throw New Exception("El nombre del plan no puede exceder los 100 caracteres.")
        End If

        If Obj.Precio > 9999999999 Then
            Throw New Exception("El precio no puede exceder los 10 dígitos.")
        End If

        If String.IsNullOrWhiteSpace(Obj.Descripcion) Then
            Obj.Descripcion = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Obtiene la lista de todos los planes registrados.
    ''' </summary>
    ''' <returns><see cref="DataTable"/> con los datos de los planes.</returns>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Function Listar() As DataTable
        Try
            Return dPlanes.Listar()
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Inserta un nuevo plan en el sistema.
    ''' Valida que no exista un plan con el mismo nombre y que los campos sean correctos.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Planes"/> a insertar.</param>
    ''' <exception cref="Exception">Se lanza si el plan ya existe o si hay errores de validación.</exception>
    Public Sub Insertar(Obj As Planes)
        Try
            Dim existePlan As DataTable = dPlanes.ListarPorNombre(Obj.NombrePlan)
            If existePlan.Rows.Count > 0 Then
                Throw New Exception("El Plan ya está registrado.")
            End If
            ValidarCampos(Obj)
            dPlanes.Insertar(Obj)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza los datos de un plan existente.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Planes"/> con los datos actualizados.</param>
    ''' <exception cref="Exception">Se lanza si hay errores de validación o de la capa de datos.</exception>
    Public Sub Actualizar(Obj As Planes)
        Try
            ValidarCampos(Obj)
            dPlanes.Actualizar(Obj)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Elimina un plan del sistema según su identificador.
    ''' </summary>
    ''' <param name="id">Identificador único del plan a eliminar.</param>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Sub Eliminar(id As UInteger)
        Try
            dPlanes.Eliminar(id)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Busca planes por nombre utilizando la capa de datos <see cref="DPlanes.ListarPorNombre"/>.
    ''' </summary>
    ''' <param name="nombre">Nombre o parte del nombre del plan a buscar.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    ''' <exception cref="Exception">Se lanza si el nombre excede el límite permitido o por errores de la capa de datos.</exception>
    Public Function ListarPorNombre(nombre As String) As DataTable
        Try
            If nombre.Length > 100 Then
                Throw New Exception("El nombre del plan no puede exceder los 100 caracteres.")
            End If
            Return dPlanes.ListarPorNombre(nombre)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Busca planes por duración utilizando la capa de datos <see cref="DPlanes.ListarPorDuracion"/>.
    ''' </summary>
    ''' <param name="duracion">Duración en días del plan.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    ''' <exception cref="Exception">Se lanza si la duración es menor o igual a cero o por errores de la capa de datos.</exception>
    Public Function ListarPorDuracion(duracion As UInteger) As DataTable
        Try
            If duracion <= 0 Then
                Throw New Exception("La duración debe ser mayor a 0.")
            End If
            Return dPlanes.ListarPorDuracion(duracion)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Busca planes por precio utilizando la capa de datos <see cref="DPlanes.ListarPorPrecio"/>.
    ''' </summary>
    ''' <param name="precio">Precio del plan.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    ''' <exception cref="Exception">Se lanza si el precio es negativo o mayor al límite permitido, o por errores de la capa de datos.</exception>
    Public Function ListarPorPrecio(precio As Decimal) As DataTable
        Try
            If precio < 0 OrElse precio > 9999999999 Then
                Throw New Exception("El precio no puede ser negativo ni mayor a 10 digitos.")
            End If
            Return dPlanes.ListarPorPrecio(precio)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class

