Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports System.Data
Imports LogDeErrores

Public Class NPagos
    Private dPagos As New DPagos()
    Private Sub ValidarCampos(Obj As Pagos)
        If Obj.MontoPagado > 9999999999 Then
            Throw New Exception("El monto no puede exceder los 10 dígitos.")
        End If
        If Obj.NumeroComprobante.Length > 100 Then
            Throw New Exception("El N° de Comprobante no puede tener más de 100 caracteres.")
        End If
        If String.IsNullOrWhiteSpace(Obj.NumeroComprobante) Then
            Obj.NumeroComprobante = Nothing
        ElseIf Obj.NumeroComprobante.Length > 100 Then
            Throw New Exception("El teléfono no puede tener más de 100 caracteres.")
        End If
        If String.IsNullOrWhiteSpace(Obj.Notas) Then
            Obj.Notas = Nothing
        End If
    End Sub

    Public Function Listar() As DataTable
        Try
            Dim dvPagos As DataTable
            dvPagos = dPagos.Listar()
            Return dvPagos
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub Insertar(pago As Pagos)
        Try
            ValidarCampos(pago)
            dPagos.Insertar(pago)

            Dim dMembresia As New DMembresias()
            Dim duracionDias As UInteger = dMembresia.ObtenerDuracionPorMembresia(pago.IdMembresia)


            Dim membresia As New Membresias()
            membresia.IdMembresia = pago.IdMembresia
            membresia.FechaInicio = DateTime.Now
            membresia.FechaFin = membresia.FechaInicio.AddDays(duracionDias)
            membresia.EstadoMembresia = "Activa"


            Dim dMembresias As New DMembresias()
            dMembresias.ActualizarEstadoYFechas(membresia)

        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Eliminar(id As UInteger)
        Try
            dPagos.Eliminar(id)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function ListarPorFecha(fechaInicio As DateTime, fechaFin As DateTime) As DataTable
        Try
            If fechaInicio > fechaFin Then
                Dim temp As DateTime = fechaInicio
                fechaInicio = fechaFin
                fechaFin = temp
            End If
            Dim dvPagos As DataTable
            dvPagos = dPagos.ListarPorFecha(fechaInicio, fechaFin)
            Return dvPagos
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarPorDni(dni As String) As DataTable
        Try
            If dni.Length > 15 Then
                Throw New Exception("El DNI no puede tener más de 15 caracteres.")
            End If
            Dim dvPagos As DataTable
            dvPagos = dPagos.ListarPorDni(dni)
            Return dvPagos
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarPorNombrePlan(nombre As String) As DataTable
        Try
            If nombre.Length > 100 Then
                Throw New Exception("El nombre no puede tener más de 100 caracteres.")
            End If
            Dim dvPagos As DataTable
            dvPagos = dPagos.ListarPorNombrePlan(nombre)
            Return dvPagos
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarPorMetodoPago(metodo As String) As DataTable
        Try
            Dim dvPagos As DataTable
            dvPagos = dPagos.ListarPorMetodoPago(metodo)
            Return dvPagos
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarPorMontos(montoMin As Decimal, montoMax As Decimal) As DataTable
        Try
            If montoMin < 0 Or montoMax < 0 Then
                Throw New Exception("Los montos no pueden ser negativos.")
            End If
            If montoMin > montoMax Then
                Dim temp As Decimal = montoMin
                montoMin = montoMax
                montoMax = temp
            End If
            Return dPagos.ListarPorMontos(montoMin, montoMax)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
