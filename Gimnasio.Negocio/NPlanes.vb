Imports System.Data
Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports Gimnasio.Errores

''' <summary>
''' Lógica de negocio para la gestión de planes en el sistema de gimnasio.
''' Interactúa con la capa de datos <see cref="DPlanes"/> y la entidad <see cref="Planes"/>.
''' </summary>
''' <remarks>
''' Todas las operaciones de la capa de negocio están envueltas en bloques Try...Catch.  
''' Si ocurre una excepción, se registra el error utilizando <see cref="ManejarErrores.Log"/> en un log.txt
''' Luego, la excepción se propaga nuevamente mediante Throw New Exception(ex.Message) para que pueda ser gestionada en la interfaz de usuario.
''' </remarks>
Public Class NPlanes
    ''' <summary>
    ''' Instancia de la capa de datos para planes.
    ''' </summary>
    Private dPlanes As New DPlanes()

    ''' <summary>
    ''' Valida los campos de la entidad <see cref="Planes"/> antes de realizar operaciones de inserción o actualización.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Planes"/> a validar.</param>
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
    ''' Obtiene la lista de todos los planes registrados con <see cref="dPlanes.Listar()"/>.
    ''' </summary>
    ''' <returns>DataTable con los datos de los planes.</returns>
    Public Function Listar() As DataTable
        Try
            Return dPlanes.Listar()
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 1. Verifica que no exista ya un plan con el mismo nombre utilizando <see cref="DPlanes.ListarPorNombre(String)"/>.
    '''    - Si existe, lanza una excepción indicando que el plan ya está registrado.
    ''' 2. Valida los campos de la entidad <see cref="Planes"/> con <see cref="ValidarCampos(Planes)"/>:
    ''' 3. Inserta el plan en la base de datos mediante <see cref="DPlanes.Insertar(Planes)"/>.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Planes"/> a insertar.</param>
    Public Sub Insertar(Obj As Planes)
        Try
            Dim existePlan As DataTable = dPlanes.ListarPorNombre(Obj.NombrePlan)
            If existePlan.Rows.Count > 0 Then
                Throw New Exception("El Plan ya está registrado.")
            End If
            ValidarCampos(Obj)
            dPlanes.Insertar(Obj)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 1. Valida los campos de la entidad <see cref="Planes"/> con <see cref="ValidarCampos(Planes)"/>:
    ''' 2. Actualiza el plan en la base de datos mediante <see cref="DPlanes.Actualizar(Planes)"/>.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Planes"/> con los datos actualizados.</param>
    Public Sub Actualizar(Obj As Planes)
        Try
            ValidarCampos(Obj)
            dPlanes.Actualizar(Obj)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Elimina un plan según su id con <see cref="dPlanes.Eliminar(UInteger)"/>.
    ''' </summary>
    ''' <param name="id">Identificador único del plan a eliminar.</param>
    Public Sub Eliminar(id As UInteger)
        Try
            dPlanes.Eliminar(id)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Realiza una validación y busca planes por nombre utilizando la capa de datos <see cref="DPlanes.ListarPorNombre(String)"/>.
    ''' </summary>
    ''' <param name="nombre">Nombre o parte del nombre del plan a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorNombre(nombre As String) As DataTable
        Try
            If nombre.Length > 100 Then
                Throw New Exception("El nombre del plan no puede exceder los 100 caracteres.")
            End If
            Return dPlanes.ListarPorNombre(nombre)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Realiza una validación y busca planes por duración utilizando la capa de datos <see cref="DPlanes.ListarPorDuracion(UInteger)"/>.
    ''' </summary>
    ''' <param name="duracion">Duración en días del plan.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorDuracion(duracion As UInteger) As DataTable
        Try
            If duracion <= 0 Then
                Throw New Exception("La duración debe ser mayor a 0.")
            End If
            Return dPlanes.ListarPorDuracion(duracion)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Realiza una validación y busca planes por precio utilizando la capa de datos <see cref="DPlanes.ListarPorPrecio(Decimal)"/>.
    ''' </summary>
    ''' <param name="precio">Precio del plan.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorPrecio(precio As Decimal) As DataTable
        Try
            If precio < 0 OrElse precio > 9999999999 Then
                Throw New Exception("El precio no puede ser negativo ni mayor a 10 digitos.")
            End If
            Return dPlanes.ListarPorPrecio(precio)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class

