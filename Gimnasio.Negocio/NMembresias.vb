Imports Gimnasio.Entidades
Imports Gimnasio.Datos
Imports System.Data
Imports Gimnasio.Errores
Imports System.Net

''' <summary>
''' Lógica de negocio para la gestión de membresías en el sistema de gimnasio.
''' Interactúa con la capa de datos <see cref="DMembresias"/> y la entidad <see cref="Membresias"/>.
''' Todas las operaciones de la capa de negocio están envueltas en bloques Try...Catch.  
''' Si ocurre una excepción, se registra el error utilizando <see cref="ManejarErrores.Log"/> en un log.txt
''' Luego, la excepción se propaga nuevamente mediante Throw New Exception(ex.Message).
''' </summary>
Public Class NMembresias
    ''' <summary>
    ''' Instancia de la capa de datos para membresías.
    ''' </summary>
    Private dMembresias As New DMembresias()

    ''' <summary>
    ''' Actualiza el estado de las membresías vencidas a "Inactiva" utilizando <see cref="DMembresias.ActualizarAEstadoInactiva"/>.
    ''' </summary>
    Public Sub ActualizaAEstadoInactiva()
        Try
            dMembresias.ActualizarAEstadoInactiva()
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene la lista de todas las membresías registradas con <see cref="DMembresias.Listar()"/>.
    ''' Antes de listar, actualiza el estado de las membresías vencidas a inactivas mediante <see cref="ActualizaAEstadoInactiva"/>.
    ''' </summary>
    ''' <returns>DataTable con los datos de las membresías.</returns>
    Public Function Listar() As DataTable
        Try
            ActualizaAEstadoInactiva()
            Return dMembresias.Listar()
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Inserta una nueva membresía en el sistema. Valida que no exista una membresía activa o pendiente de pago para el mismo miembro y plan
    ''' con <see cref="DMembresias.VerificarExistenciaDeMiembroYPlan"/>.
    ''' Si no existe, establece la fecha de inicio y fin de la membresía y la inserta en la bd con <see cref="DMembresias.Insertar(Membresias)"/>.
    ''' </summary>
    ''' <param name="membresia">Instancia de <see cref="Membresias"/> a insertar.</param>
    Public Sub Insertar(membresia As Membresias)
        Try
            If dMembresias.VerificarExistenciaDeMiembroYPlan(membresia) Then
                Throw New Exception("El usuario ya tiene una membresía  para este plan.")
            End If
            membresia.FechaInicio = DateTime.Now
            membresia.FechaFin = DateTime.Now
            dMembresias.Insertar(membresia)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza los datos de una membresía existente. Valida que no exista con <see cref="DMembresias.VerificarExistenciaDeMiembroYPlan"/>
    ''' Si no existe, actualiza la membresía en la base de datos con <see cref="DMembresias.Actualizar(Membresias)"/>.
    ''' </summary>
    ''' <param name="membresia">Instancia de <see cref="Membresias"/> con los datos actualizados.</param>
    Public Sub Actualizar(membresia As Membresias)
        Try
            If dMembresias.VerificarExistenciaDeMiembroYPlan(membresia) Then
                Throw New Exception("El usuario ya tiene una membresía para este plan.")
            End If
            dMembresias.Actualizar(membresia)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Elimina una membresía según su id con <see cref="DMembresias.Eliminar(UInteger)"/>.
    ''' </summary>
    ''' <param name="id">Identificador único de la membresía a eliminar.</param>
    Public Sub Eliminar(id As UInteger)
        Try
            dMembresias.Eliminar(id)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene el id de una membresía específica con <see cref="DMembresias.ObtenerIdMembresia(Membresias)"/>
    ''' </summary>
    ''' <param name="membresia">Instancia de <see cref="Membresias"/> para la cual se busca el ID.</param>
    ''' <returns>Identificador único de la membresía.</returns>
    Public Function ObtenerIdMembresia(membresia As Membresias) As UInteger
        Try
            Return dMembresias.ObtenerIdMembresia(membresia)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene una membresía por el DNI del miembro con <see cref="DMembresias.ObtenerPorDni(String)"/>.
    ''' </summary>
    ''' <param name="dni">DNI del miembro.</param>
    ''' <returns>DataTable con los datos de la membresía encontrada.</returns>
    Public Function ObtenerPorDni(dni As String) As DataTable
        Try
            Return dMembresias.ObtenerPorDni(dni)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Busca membresías por DNI del miembro con <see cref="DMembresias.ListarPorDni(String)"/>.
    ''' </summary>
    ''' <param name="dni">DNI o parte del DNI del miembro a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorDni(dni As String) As DataTable
        Try
            Return dMembresias.ListarPorDni(dni)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Busca membresías por nombre de plan con <see cref="DMembresias.ListarPorNombrePlan(String)"/>.
    ''' </summary>
    ''' <param name="nombre">Nombre o parte del nombre del plan a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Function ListarPorNombrePlan(nombre As String) As DataTable
        Try
            Return dMembresias.ListarPorNombrePlan(nombre)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Busca membresías por estado con <see cref="DMembresias.ListarPorEstado(String)"/>.
    ''' </summary>
    ''' <param name="estado">Estado de la membresía (por ejemplo: "Activa", "Inactiva").</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorEstado(estado As String) As DataTable
        Try
            Return dMembresias.ListarPorEstado(estado)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene la membresía más reciente de un miembro con <see cref="DMembresias.ObtenerMembresiaMasReciente(UInteger)"/>.
    ''' </summary>
    ''' <param name="idMiembro">Identificador único del miembro.</param>
    ''' <returns>DataTable con los datos de la membresía más reciente.</returns>
    Public Function ObtenerMembresiaMasReciente(idMiembro As UInteger) As DataTable
        Try
            Return dMembresias.ObtenerMembresiaMasReciente(idMiembro)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class


