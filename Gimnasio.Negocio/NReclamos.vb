Imports System.Data
Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports Gimnasio.Errores

''' <summary>
''' Lógica de negocio para la gestión de reclamos en el sistema de gimnasio.
''' Interactúa con la capa de datos <see cref="DReclamos"/> y la entidad <see cref="Reclamos"/>.
''' </summary>
Public Class NReclamos
    ''' <summary>
    ''' Instancia de la capa de datos para reclamos.
    ''' </summary>
    Private dReclamos As New DReclamos()

    ''' <summary>
    ''' Valida los campos de la entidad <see cref="Reclamos"/> antes de realizar operaciones de inserción o actualización.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Reclamos"/> a validar.</param>
    Private Sub ValidarCampos(Obj As Reclamos)
        If String.IsNullOrWhiteSpace(Obj.Respuesta) Then
            Obj.Respuesta = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Obtiene la lista de todos los reclamos registrados.
    ''' </summary>
    ''' <returns>DataTable con los datos de los reclamos.</returns>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Function Listar() As DataTable
        Try
            Dim dvDescripcion As DataTable
            dvDescripcion = dReclamos.Listar()
            Return dvDescripcion
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Inserta un nuevo reclamo en el sistema.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Reclamos"/> a insertar.</param>
    ''' <exception cref="Exception">Se lanza si hay errores de validación o de la capa de datos.</exception>
    Public Sub Insertar(Obj As Reclamos)
        Try
            ValidarCampos(Obj)
            dReclamos.Insertar(Obj)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza los datos de un reclamo existente.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Reclamos"/> con los datos actualizados.</param>
    ''' <exception cref="Exception">Se lanza si hay errores de validación o de la capa de datos.</exception>
    Public Sub Actualizar(Obj As Reclamos)
        Try
            ValidarCampos(Obj)
            dReclamos.Actualizar(Obj)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Elimina un reclamo del sistema según su identificador.
    ''' </summary>
    ''' <param name="id">Identificador único del reclamo a eliminar.</param>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Sub Eliminar(id As UInteger)
        Try
            dReclamos.Eliminar(id)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Cambia el estado de un reclamo a "resuelto" utilizando <see cref="DReclamos.ActualizarElEstadoAResuelto"/>.
    ''' </summary>
    ''' <param name="id">Identificador único del reclamo.</param>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Sub ActualizarElEstadoAResuelto(id As UInteger)
        Try
            dReclamos.ActualizarElEstadoAResuelto(id)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Cambia el estado de un reclamo a "pendiente" utilizando <see cref="DReclamos.ActualizarElEstadoAPendiente"/>.
    ''' </summary>
    ''' <param name="id">Identificador único del reclamo.</param>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Sub ActualizarElEstadoAPendiente(id As UInteger)
        Try
            dReclamos.ActualizarElEstadoAPendiente(id)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Busca reclamos por estado utilizando la capa de datos <see cref="DReclamos.ListarPorEstado"/>.
    ''' </summary>
    ''' <param name="estado">Estado del reclamo (por ejemplo: "pendiente", "resuelto").</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Function ListarPorEstado(estado As String) As DataTable
        Try
            Dim dvEstado As DataTable = dReclamos.ListarPorEstado(estado)
            Return dvEstado
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Actualiza la respuesta de un reclamo utilizando <see cref="DReclamos.ActualizarRespuesta"/>.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Reclamos"/> con la respuesta actualizada.</param>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Sub ActualizarRespuesta(Obj As Reclamos)
        Try
            dReclamos.ActualizarRespuesta(Obj)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class
