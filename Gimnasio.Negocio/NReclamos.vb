Imports System.Data
Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports Gimnasio.Errores

''' <summary>
''' Lógica de negocio para la gestión de reclamos en el sistema de gimnasio.
''' Interactúa con la capa de datos <see cref="DReclamos"/> y la entidad <see cref="Reclamos"/>.
''' Todas las operaciones de la capa de negocio están envueltas en bloques Try...Catch.  
''' Si ocurre una excepción, se registra el error utilizando <see cref="ManejarErrores.Log"/> en un log.txt
''' Luego, la excepción se propaga nuevamente mediante Throw New Exception(ex.Message) para que pueda ser gestionada en la interfaz de usuario.
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
    ''' Obtiene la lista de todos los reclamos registrados con <see cref="DReclamos.Listar()"/>.
    ''' </summary>
    ''' <returns>DataTable con los datos de los reclamos.</returns>
    Public Function Listar() As DataTable
        Try
            Return dReclamos.Listar()
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Valida los campos e inserta un nuevo reclamo en el sistema con <see cref="DReclamos.Insertar(Reclamos)"/>.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Reclamos"/> a insertar.</param>
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
    ''' Valida los campos y actualiza los datos de un reclamo existente con <see cref="DReclamos.Actualizar(Reclamos)"/>
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Reclamos"/> con los datos actualizados.</param>
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
    ''' Elimina un reclamo del sistema según su id con <see cref="dReclamos.Eliminar(UInteger)"/>
    ''' </summary>
    ''' <param name="id">Identificador único del reclamo a eliminar.</param>
    Public Sub Eliminar(id As UInteger)
        Try
            dReclamos.Eliminar(id)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Cambia el estado de un reclamo a "resuelto" utilizando <see cref="DReclamos.ActualizarElEstadoAResuelto(UInteger)"/>.
    ''' </summary>
    ''' <param name="id">Identificador único del reclamo.</param>
    Public Sub ActualizarElEstadoAResuelto(id As UInteger)
        Try
            dReclamos.ActualizarElEstadoAResuelto(id)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Cambia el estado de un reclamo a "pendiente" utilizando <see cref="DReclamos.ActualizarElEstadoAPendiente(UInteger)"/>.
    ''' </summary>
    ''' <param name="id">Identificador único del reclamo.</param>
    Public Sub ActualizarElEstadoAPendiente(id As UInteger)
        Try
            dReclamos.ActualizarElEstadoAPendiente(id)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Busca reclamos por estado utilizando la capa de datos <see cref="DReclamos.ListarPorEstado(String)"/>.
    ''' </summary>
    ''' <param name="estado">Estado del reclamo ("pendiente", "resuelto").</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorEstado(estado As String) As DataTable
        Try
            Return dReclamos.ListarPorEstado(estado)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Actualiza la respuesta de un reclamo utilizando <see cref="DReclamos.ActualizarRespuesta(Reclamos)"/>.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Reclamos"/> con la respuesta actualizada.</param>
    Public Sub ActualizarRespuesta(Obj As Reclamos)
        Try
            dReclamos.ActualizarRespuesta(Obj)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class
