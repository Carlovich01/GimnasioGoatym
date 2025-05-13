Imports Gimnasio.Entidades
Imports Gimnasio.Datos
Imports System.Data
Imports LogDeErrores

''' <summary>
''' Lógica de negocio para la gestión de membresías en el sistema de gimnasio.
''' Interactúa con la capa de datos <see cref="DMembresias"/> y la entidad <see cref="Membresias"/>.
''' </summary>
Public Class NMembresias
    ''' <summary>
    ''' Instancia de la capa de datos para membresías.
    ''' </summary>
    Private dMembresias As New DMembresias()

    ''' <summary>
    ''' Obtiene la lista de todas las membresías registradas.
    ''' Antes de listar, actualiza el estado de las membresías vencidas a inactivas mediante <see cref="ActualizaAEstadoInactiva"/>.
    ''' </summary>
    ''' <returns><see cref="DataTable"/> con los datos de las membresías.</returns>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Function Listar() As DataTable
        Try
            ActualizaAEstadoInactiva()
            Return dMembresias.Listar()
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Inserta una nueva membresía en el sistema.
    ''' Valida que no exista una membresía activa o pendiente de pago para el mismo miembro y plan.
    ''' </summary>
    ''' <param name="membresia">Instancia de <see cref="Membresias"/> a insertar.</param>
    ''' <exception cref="Exception">Se lanza si ya existe una membresía activa o pendiente para el mismo miembro y plan, o por errores de la capa de datos.</exception>
    Public Sub Insertar(membresia As Membresias)
        Try
            If dMembresias.VerificarExistenciaDeMiembroYPlan(membresia) Then
                Throw New Exception("El usuario ya tiene una membresía activa o pendiente de pago para este plan.")
            End If
            membresia.FechaInicio = DateTime.Now
            membresia.FechaFin = DateTime.Now
            dMembresias.Insertar(membresia)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza los datos de una membresía existente.
    ''' </summary>
    ''' <param name="membresia">Instancia de <see cref="Membresias"/> con los datos actualizados.</param>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Sub Actualizar(membresia As Membresias)
        Try
            dMembresias.Actualizar(membresia)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Elimina una membresía del sistema según su identificador.
    ''' </summary>
    ''' <param name="id">Identificador único de la membresía a eliminar.</param>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Sub Eliminar(id As UInteger)
        Try
            dMembresias.Eliminar(id)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene el identificador de una membresía específica.
    ''' </summary>
    ''' <param name="membresia">Instancia de <see cref="Membresias"/> para la cual se busca el ID.</param>
    ''' <returns>Identificador único de la membresía.</returns>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Function ObtenerIdMembresia(membresia As Membresias) As UInteger
        Try
            Dim idMembresia As UInteger = dMembresias.ObtenerIdMembresia(membresia)
            Return idMembresia
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene una membresía por el DNI del miembro.
    ''' </summary>
    ''' <param name="dni">DNI del miembro.</param>
    ''' <returns><see cref="DataTable"/> con los datos de la membresía encontrada.</returns>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Function ObtenerPorDni(dni As String) As DataTable
        Try
            Return dMembresias.ObtenerPorDni(dni)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Busca membresías por DNI del miembro utilizando la capa de datos <see cref="DMembresias.ListarPorDni"/>.
    ''' </summary>
    ''' <param name="dni">DNI o parte del DNI del miembro a buscar.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Function ListarPorDni(dni As String) As DataTable
        Try
            Dim dvMembresias As DataTable = dMembresias.ListarPorDni(dni)
            Return dvMembresias
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Busca membresías por nombre de plan utilizando la capa de datos <see cref="DMembresias.ListarPorNombrePlan"/>.
    ''' </summary>
    ''' <param name="nombre">Nombre o parte del nombre del plan a buscar.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Function ListarPorNombrePlan(nombre As String) As DataTable
        Try
            Dim dvMembresias As DataTable = dMembresias.ListarPorNombrePlan(nombre)
            Return dvMembresias
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Busca membresías por estado utilizando la capa de datos <see cref="DMembresias.ListarPorEstado"/>.
    ''' </summary>
    ''' <param name="estado">Estado de la membresía (por ejemplo: "Activa", "Inactiva").</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Function ListarPorEstado(estado As String) As DataTable
        Try
            Dim dvMembresias As DataTable = dMembresias.ListarPorEstado(estado)
            Return dvMembresias
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Actualiza el estado de las membresías vencidas a "Inactiva" utilizando <see cref="DMembresias.ActualizarAEstadoInactiva"/>.
    ''' </summary>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Sub ActualizaAEstadoInactiva()
        Try
            dMembresias.ActualizarAEstadoInactiva()
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene la membresía más reciente de un miembro específico.
    ''' </summary>
    ''' <param name="idMiembro">Identificador único del miembro.</param>
    ''' <returns><see cref="DataTable"/> con los datos de la membresía más reciente.</returns>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Function ObtenerMembresiaMasReciente(idMiembro As UInteger) As DataTable
        Try
            Return dMembresias.ObtenerMembresiaMasReciente(idMiembro)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class


