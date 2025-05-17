Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports System.Data
Imports Gimnasio.Errores

''' <summary>
''' Lógica de negocio para la gestión de pagos en el sistema de gimnasio.
''' Interactúa con la capa de datos <see cref="DPagos"/> y la entidad <see cref="Pagos"/>.
''' Todas las operaciones de la capa de negocio están envueltas en bloques Try...Catch.  
''' Si ocurre una excepción, se registra el error utilizando <see cref="ManejarErrores.Log"/> en un log.txt
''' Luego, la excepción se propaga nuevamente mediante Throw New Exception(ex.Message).
''' </summary>
Public Class NPagos
    ''' <summary>
    ''' Instancia de la capa de datos para pagos.
    ''' </summary>
    Private dPagos As New DPagos()

    ''' <summary>
    ''' Valida los campos de la entidad <see cref="Pagos"/> antes de realizar operaciones de inserción.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Pagos"/> a validar.</param>
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

    ''' <summary>
    ''' Obtiene la lista de todos los pagos registrados con <see cref="DPagos.Listar()"/>.
    ''' </summary>
    ''' <returns>DataTable con los datos de los pagos.</returns>
    Public Function Listar() As DataTable
        Try
            Return dPagos.Listar()
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 1. Valida los campos de la entidad <see cref="Pagos"/> recibida como parámetro.
    ''' 2. Inserta el pago en la base de datos utilizando <see cref="DPagos.Insertar(Pagos)"/>.
    ''' 3. Actualiza la membresía asociada al pago:
    '''    - Obtiene la duración de la membresía con <see cref="DMembresias.ObtenerDuracionPorMembresia"/>.
    '''    - Establece la fecha de inicio como la fecha actual y la fecha de fin sumando la duración.
    '''    - Cambia el estado de la membresía a "Activa".
    '''    - Actualiza estos datos en la base de datos mediante <see cref="DMembresias.ActualizarEstadoYFechas"/>.
    ''' </summary>
    ''' <param name="pago">Instancia de <see cref="Pagos"/> a insertar.</param>
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
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza un pago existente en el sistema.
    ''' </summary>
    ''' <param name="pago">Instancia de <see cref="Pagos"/> con los datos actualizados.</param>
    Public Sub Actualizar(pago As Pagos)
        Try
            ValidarCampos(pago)
            dPagos.Actualizar(pago)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Elimina un pago del sistema según su id con <see cref="DPagos.Eliminar(UInteger)"/>.
    ''' </summary>
    ''' <param name="id">Identificador único del pago a eliminar.</param>
    Public Sub Eliminar(id As UInteger)
        Try
            dPagos.Eliminar(id)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Busca pagos por rango de fechas utilizando la capa de datos <see cref="DPagos.ListarPorFecha(Date, Date)"/>.
    ''' </summary>
    ''' <param name="fechaInicio">Fecha de inicio del rango.</param>
    ''' <param name="fechaFin">Fecha de fin del rango.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorFecha(fechaInicio As DateTime, fechaFin As DateTime) As DataTable
        Try
            Return dPagos.ListarPorFecha(fechaInicio, fechaFin)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Realiza una validación y busca pagos por DNI del miembro utilizando la capa de datos <see cref="DPagos.ListarPorDni(String)"/>.
    ''' </summary>
    ''' <param name="dni">DNI o parte del DNI del miembro a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorDni(dni As String) As DataTable
        Try
            If dni.Length > 15 Then
                Throw New Exception("El DNI no puede tener más de 15 caracteres.")
            End If
            Return dPagos.ListarPorDni(dni)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Realiza una validación y Busca pagos por nombre de plan utilizando la capa de datos <see cref="DPagos.ListarPorNombrePlan(String)"/>.
    ''' </summary>
    ''' <param name="nombre">Nombre o parte del nombre del plan a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorNombrePlan(nombre As String) As DataTable
        Try
            If nombre.Length > 100 Then
                Throw New Exception("El nombre no puede tener más de 100 caracteres.")
            End If
            Return dPagos.ListarPorNombrePlan(nombre)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Busca pagos por método de pago utilizando la capa de datos <see cref="DPagos.ListarPorMetodoPago(String)"/>.
    ''' </summary>
    ''' <param name="metodo">Método de pago a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorMetodoPago(metodo As String) As DataTable
        Try
            Return dPagos.ListarPorMetodoPago(metodo)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Realiza una validación y Busca pagos por rango de montos utilizando la capa de datos <see cref="DPagos.ListarPorMontos(Decimal, Decimal)"/>.
    ''' </summary>
    ''' <param name="montoMin">Monto mínimo.</param>
    ''' <param name="montoMax">Monto máximo.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorMontos(montoMin As Decimal, montoMax As Decimal) As DataTable
        Try
            If montoMin < 0 Or montoMax < 0 Then
                Throw New Exception("Los montos no pueden ser negativos.")
            End If
            Return dPagos.ListarPorMontos(montoMin, montoMax)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
