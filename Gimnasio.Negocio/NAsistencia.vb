Imports Gimnasio.Entidades
Imports Gimnasio.Datos
Imports LogDeErrores
Imports System.Data

''' <summary>
''' Lógica de negocio para la gestión de asistencias en el sistema de gimnasio.
''' Interactúa con la capa de datos <see cref="DAsistencia"/> y la entidad <see cref="Asistencia"/>.
''' </summary>
Public Class NAsistencia
    ''' <summary>
    ''' Instancia de la capa de datos para asistencias.
    ''' </summary>
    Private dAsistencias As New DAsistencia()

    ''' <summary>
    ''' Obtiene la lista de todas las asistencias registradas.
    ''' </summary>
    ''' <returns><see cref="DataTable"/> con los datos de las asistencias.</returns>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Function Listar() As DataTable
        Try
            Return dAsistencias.Listar()
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Registra el ingreso de un miembro por su DNI.
    ''' Valida la existencia del miembro y el estado de su membresía más reciente.
    ''' Registra la asistencia mediante <see cref="DAsistencia.RegistrarAsistencia"/>.
    ''' </summary>
    ''' <param name="dni">DNI del miembro.</param>
    ''' <returns>
    ''' "Exitoso" si la membresía está activa,
    ''' "Fallido_Membresia_Inactiva" si la membresía está inactiva,
    ''' "Fallido_DNI_NoEncontrado" si el DNI no existe,
    ''' "Fallido_No_Hay_Membresia" si no tiene membresía,
    ''' "Fallido_Otro" para otros casos.
    ''' </returns>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Function RegistrarIngresoPorDNI(dni As String) As String
        Try
            Dim resultado As String = "Fallido_Otro"
            Dim idMembresiaValida As UInteger? = Nothing
            Dim nMiembros As New NMiembros()
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

    ''' <summary>
    ''' Busca asistencias por DNI del miembro utilizando la capa de datos <see cref="DAsistencia.ListarPorDNI"/>.
    ''' </summary>
    ''' <param name="dni">DNI o parte del DNI del miembro a buscar.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    ''' <exception cref="Exception">Se lanza si el DNI excede el límite permitido o por errores de la capa de datos.</exception>
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

    ''' <summary>
    ''' Busca asistencias por rango de fechas utilizando la capa de datos <see cref="DAsistencia.ListarPorFecha"/>.
    ''' </summary>
    ''' <param name="fechaInicio">Fecha de inicio del rango.</param>
    ''' <param name="fechaFin">Fecha de fin del rango.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Function ListarPorFecha(fechaInicio As DateTime, fechaFin As DateTime) As DataTable
        Try
            Dim dvPagos As DataTable
            dvPagos = dAsistencias.ListarPorFecha(fechaInicio, fechaFin)
            Return dvPagos
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Elimina un registro de asistencia del sistema según su identificador.
    ''' </summary>
    ''' <param name="id">Identificador único de la asistencia a eliminar.</param>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Sub Eliminar(id As UInteger)
        Try
            dAsistencias.Eliminar(id)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

End Class
