Imports System.Data
Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports LogDeErrores

Public Class NReclamos
    Private dReclamos As New DReclamos()

    Private Sub ValidarCampos(Obj As Reclamos)
        If String.IsNullOrWhiteSpace(Obj.Respuesta) Then
            Obj.Respuesta = Nothing
        End If
    End Sub

    Public Function Listar() As DataTable
        Try
            Dim dvDescripcion As DataTable
            dvDescripcion = dReclamos.Listar()
            Return dvDescripcion
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub Insertar(Obj As Reclamos)
        Try
            ValidarCampos(Obj)
            dReclamos.Insertar(Obj)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Actualizar(Obj As Reclamos)
        Try
            ValidarCampos(Obj)
            dReclamos.Actualizar(Obj)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Eliminar(id As UInteger)
        Try
            dReclamos.Eliminar(id)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub ActualizarElEstadoAResuelto(id As UInteger)
        Try
            dReclamos.ActualizarElEstadoAResuelto(id)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub ActualizarElEstadoAPendiente(id As UInteger)
        Try
            dReclamos.ActualizarElEstadoAPendiente(id)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function ListarPorEstado(estado As String) As DataTable
        Try
            Dim dvEstado As DataTable = dReclamos.ListarPorEstado(estado)
            Return dvEstado
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub ActualizarRespuesta(Obj As Reclamos)
        Try
            dReclamos.ActualizarRespuesta(Obj)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class