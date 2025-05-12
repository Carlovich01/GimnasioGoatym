Imports Gimnasio.Entidades
Imports Gimnasio.Datos
Imports LogDeErrores
Imports System.Data
Public Class NAsistencia
    Private dAsistencias As New DAsistencia()


    Public Function Listar() As DataTable
        Try
            Return dAsistencias.Listar()
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function RegistrarIngresoPorDNI(dni As String) As String
        Try
            Dim resultado As String = "Fallido_Otro"
            Dim idMembresiaValida As UInteger? = Nothing
            Dim nMiembros As New DMiembros()
            Dim miembroTabla As DataTable = nMiembros.ObtenerPorDni(dni)
            If miembroTabla.Rows.Count = 0 Then
                resultado = "Fallido_DNI_NoEncontrado"
            Else
                Dim idMiembro As UInteger = miembroTabla.Rows(0)("id_miembro")
                Dim nMembresias As New NMembresias()
                Dim membresiaTabla As DataTable = nMembresias.ObtenerMembresiaMasReciente(idMiembro)
                If membresiaTabla.Rows.Count = 0 Then
                    resultado = "Fallido_No_Hay_Membresia"
                Else
                    Dim estadoMembresia As String = membresiaTabla.Rows(0)("estado_membresia").ToString()
                    Select Case estadoMembresia
                        Case "Activa"
                            resultado = "Exitoso"
                            idMembresiaValida = membresiaTabla.Rows(0)("id_membresia")
                        Case "Inactiva"
                            resultado = "Fallido_Membresia_Inactiva"
                    End Select
                End If

                Dim asistencia As New Asistencia() With {
                .IdMiembro = idMiembro,
                .FechaHoraCheckin = DateTime.Now,
                .Resultado = resultado,
                .IdMembresiaValida = idMembresiaValida
            }
                dAsistencias.RegistrarAsistencia(asistencia)
            End If

            Return resultado
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try

    End Function

    Public Function ListarPorDNI(dni As String) As DataTable
        Try
            If dni.Length > 15 Then
                Throw New Exception("El DNI no puede tener más de 15 caracteres.")
            End If
            Dim dt As DataTable = dAsistencias.ListarPorDNI(dni)
            Return dt
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function


    Public Function ListarPorFecha(fechaInicio As DateTime, fechaFin As DateTime) As DataTable
        Try
            If fechaInicio > fechaFin Then
                Dim temp As DateTime = fechaInicio
                fechaInicio = fechaFin
                fechaFin = temp
            End If
            Dim dvPagos As DataTable
            dvPagos = dAsistencias.ListarPorFecha(fechaInicio, fechaFin)
            Return dvPagos
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub Eliminar(id As UInteger)
        Try
            dAsistencias.Eliminar(id)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

End Class
