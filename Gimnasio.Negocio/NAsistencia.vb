Imports Gimnasio.Entidades
Imports Gimnasio.Datos
Imports Gimnasio.Errores
Imports System.Data

''' <summary>
''' Lógica de negocio para la gestión de asistencias en el sistema de gimnasio.
''' Interactúa con la capa de datos <see cref="DAsistencia"/> y la entidad <see cref="Asistencia"/>.
''' </summary>
''' <remarks>
''' Todas las operaciones de la capa de negocio están envueltas en bloques Try...Catch.  
''' Si ocurre una excepción, se registra el error utilizando <see cref="ManejarErrores.Log"/> en un log.txt
''' Luego, la excepción se propaga nuevamente mediante Throw New Exception(ex.Message).
''' </remarks>
Public Class NAsistencia
    ''' <summary>
    ''' Instancia de la capa de datos para asistencias.
    ''' </summary>
    Private dAsistencias As New DAsistencia()

    ''' <summary>
    ''' Obtiene la lista de todas las asistencias registradas.
    ''' </summary>
    ''' <returns>DataTable con los datos de las asistencias.</returns>
    Public Function Listar() As DataTable
        Try
            Return dAsistencias.Listar()
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Registra el ingreso de un miembro al gimnasio utilizando su DNI. Proceso:
    ''' 1. Busca el miembro por su DNI mediante <see cref="NMiembros.ObtenerPorDni(String)"/>.
    '''    - Si no existe, registra la asistencia como "Fallido_DNI_NoEncontrado" y retorna ese resultado.
    ''' 2. Si el miembro existe, obtiene su membresía más reciente con <see cref="NMembresias.ObtenerMembresiaMasReciente(UInteger)"/>.
    '''    - Si no tiene membresía, registra la asistencia como "Fallido_No_Hay_Membresia" y retorna ese resultado.
    '''    - Si la membresía está inactiva, registra la asistencia como "Fallido_Membresia_Inactiva" y retorna ese resultado.
    '''    - Si la membresía está activa, registra la asistencia como "Exitoso" y retorna ese resultado.
    ''' 3. En todos los casos, se crea un registro de asistencia en la base de datos mediante <see cref="DAsistencia.RegistrarAsistencia(Asistencia)"/>,
    '''    incluyendo el resultado, la fecha y hora del intento, el id del miembro (si corresponde) y el id de la membresía válida (si corresponde).
    ''' </summary>
    ''' <param name="dni">DNI del miembro a registrar el ingreso.</param>
    ''' <returns>
    ''' "Exitoso" si la membresía está activa,
    ''' "Fallido_Membresia_Inactiva" si la membresía está inactiva,
    ''' "Fallido_DNI_NoEncontrado" si el DNI no existe,
    ''' "Fallido_No_Hay_Membresia" si no tiene membresía,
    ''' "Fallido_Otro" para otros casos.
    ''' </returns>
    Public Function RegistrarIngresoPorDNI(dni As String) As String
        Try
            Dim resultado As String = "Fallido_Otro"
            Dim nMiembros As New NMiembros()
            Dim miembroTabla As DataTable = nMiembros.ObtenerPorDni(dni)
            Dim asistencia As New Asistencia()
            If miembroTabla.Rows.Count = 0 Then
                resultado = "Fallido_DNI_NoEncontrado"
                Asistencia.IdMiembro = Nothing
                Asistencia.FechaHoraCheckin = DateTime.Now
                Asistencia.Resultado = resultado
                asistencia.IdMembresiaValida = Nothing
                dAsistencias.RegistrarAsistencia(Asistencia)
            Else
                Dim idMiembro As UInteger = miembroTabla.Rows(0)("id_miembro")
                Dim nMembresias As New NMembresias()
                Dim membresiaTabla As DataTable = nMembresias.ObtenerMembresiaMasReciente(idMiembro)
                If membresiaTabla.Rows.Count = 0 Then
                    resultado = "Fallido_No_Hay_Membresia"
                    asistencia.IdMembresiaValida = Nothing
                Else
                    Dim estadoMembresia As String = membresiaTabla.Rows(0)("estado_membresia").ToString()
                    Select Case estadoMembresia
                        Case "Activa"
                            resultado = "Exitoso"
                            asistencia.IdMembresiaValida = membresiaTabla.Rows(0)("id_membresia")
                        Case "Inactiva"
                            resultado = "Fallido_Membresia_Inactiva"
                            asistencia.IdMembresiaValida = Nothing
                    End Select
                End If
                asistencia.IdMiembro = idMiembro
                asistencia.FechaHoraCheckin = DateTime.Now
                asistencia.Resultado = resultado
                dAsistencias.RegistrarAsistencia(asistencia)
            End If

            Return resultado
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Busca asistencias por DNI del miembro utilizando la capa de datos <see cref="DAsistencia.ListarPorDNI(String)"/>.
    ''' </summary>
    ''' <param name="dni">DNI del miembro a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorDNI(dni As String) As DataTable
        Try
            If dni.Length > 15 Then
                Throw New Exception("El DNI no puede tener más de 15 caracteres.")
            End If
            Dim dt As DataTable = dAsistencias.ListarPorDNI(dni)
            Return dt
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Busca asistencias por rango de fechas utilizando la capa de datos <see cref="DAsistencia.ListarPorFecha(Date, Date)"/>.
    ''' </summary>
    ''' <param name="fechaInicio">Fecha de inicio del rango.</param>
    ''' <param name="fechaFin">Fecha de fin del rango.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorFecha(fechaInicio As DateTime, fechaFin As DateTime) As DataTable
        Try
            Return dAsistencias.ListarPorFecha(fechaInicio, fechaFin)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Elimina un registro de asistencia del sistema según su identificador utilizando la capa de datos <see cref="DAsistencia.Eliminar(UInteger)"/>.
    ''' </summary>
    ''' <param name="id">Identificador único de la asistencia a eliminar.</param>
    Public Sub Eliminar(id As UInteger)
        Try
            dAsistencias.Eliminar(id)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

End Class
