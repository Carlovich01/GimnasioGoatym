Imports Gimnasio.Entidades
Imports Gimnasio.Datos
Imports System.Data
Imports LogDeErrores

Public Class NMembresias
    Private dMembresias As New DMembresias()

    Public Function Listar() As DataTable
        Try
            ActualizaAEstadoInactiva()
            Return dMembresias.Listar()
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

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

    Public Sub Actualizar(membresia As Membresias)
        Try
            dMembresias.Actualizar(membresia)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Sub Eliminar(id As UInteger)
        Try
            dMembresias.Eliminar(id)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function ObtenerIdMembresia(membresia As Membresias) As UInteger
        Try
            Dim idMembresia As UInteger = dMembresias.ObtenerIdMembresia(membresia)
            Return idMembresia
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ObtenerPorDni(dni As String) As DataTable
        Try
            Return dMembresias.ObtenerPorDni(dni)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function ListarPorDni(dni As String) As DataTable
        Try
            Dim dvMembresias As DataTable = dMembresias.ListarPorDni(dni)
            Return dvMembresias
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarPorNombrePlan(nombre As String) As DataTable
        Try
            Dim dvMembresias As DataTable = dMembresias.ListarPorNombrePlan(nombre)
            Return dvMembresias
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarPorEstado(estado As String) As DataTable
        Try
            Dim dvMembresias As DataTable = dMembresias.ListarPorEstado(estado)
            Return dvMembresias
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub ActualizaAEstadoInactiva()
        Try
            dMembresias.ActualizarAEstadoInactiva()
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function ObtenerMembresiaMasReciente(idMiembro As UInteger) As DataTable
        Try
            Return dMembresias.ObtenerMembresiaMasReciente(idMiembro)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class

