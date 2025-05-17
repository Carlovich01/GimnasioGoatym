Imports System.Data
Imports Gimnasio.Entidades
Imports Gimnasio.Errores

''' <summary>
''' Clase de acceso a datos para la gestión de pagos en el sistema de gimnasio.
''' Hereda de <see cref="ConexionBase"/> y utiliza la entidad <see cref="Pagos"/>.
''' Proporciona métodos CRUD y de búsqueda para la tabla <c>pagos</c> y la vista <c>vista_pagos</c>.
''' </summary>
Public Class DPagos
    Inherits ConexionBase

    ''' <summary>
    ''' Obtiene todos los pagos desde la vista <c>vista_pagos</c>.
    ''' </summary>
    ''' <returns><see cref="DataTable"/> con los datos de los pagos.</returns>
    Public Function Listar() As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_pagos"
            Return ExecuteQuery(query, Nothing)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Inserta un nuevo pago en la base de datos.
    ''' Utiliza los datos de la entidad <see cref="Pagos"/>.
    ''' </summary>
    ''' <param name="pago">Instancia de <see cref="Pagos"/> a insertar.</param>
    Public Sub Insertar(pago As Pagos)
        Try
            Dim query As String = "INSERT INTO pagos (id_membresia, id_usuario_registro, monto_pagado, metodo_pago, numero_comprobante, notas) VALUES (@idmem, @idus, @mont, @met, @num, @notas)"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@idmem", If(pago.IdMembresia.HasValue, pago.IdMembresia, DBNull.Value)},
            {"@idus", If(pago.IdUsuarioRegistro.HasValue, pago.IdUsuarioRegistro, DBNull.Value)},
            {"@mont", pago.MontoPagado},
            {"@met", pago.MetodoPago},
            {"@num", If(pago.NumeroComprobante = Nothing, DBNull.Value, pago.NumeroComprobante)},
            {"@notas", If(pago.Notas = Nothing, DBNull.Value, pago.Notas)}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza un pago existente en la base de datos.
    ''' </summary>
    ''' <param name="pago">Instancia de <see cref="Pagos"/> con los datos actualizados.</param>
    Public Sub Actualizar(pago As Pagos)
        Try
            Dim query As String = "UPDATE pagos SET monto_pagado = @mont, metodo_pago = @met, numero_comprobante = @num, notas = @notas WHERE id_pago = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@mont", pago.MontoPagado},
            {"@met", pago.MetodoPago},
            {"@num", If(pago.NumeroComprobante = Nothing, DBNull.Value, pago.NumeroComprobante)},
            {"@notas", If(pago.Notas = Nothing, DBNull.Value, pago.Notas)},
            {"@id", pago.IdPago}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Elimina un pago de la base de datos según su identificador.
    ''' </summary>
    ''' <param name="id">Identificador único del pago a eliminar.</param>
    Public Sub Eliminar(id As UInteger)
        Try
            Dim query As String = "DELETE FROM pagos WHERE id_pago = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", id}
        }
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Busca pagos por rango de fechas utilizando la vista <c>vista_pagos</c>.
    ''' </summary>
    ''' <param name="fechaInicio">Fecha de inicio del rango.</param>
    ''' <param name="fechaFin">Fecha de fin del rango.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    Public Function ListarPorFecha(fechaInicio As DateTime, fechaFin As DateTime) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_pagos WHERE fecha_pago BETWEEN @fechaInicio AND @fechaFin"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@fechaInicio", fechaInicio},
            {"@fechaFin", fechaFin}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Busca pagos por coincidencia parcial de DNI utilizando la vista <c>vista_pagos</c>.
    ''' </summary>
    ''' <param name="dni">DNI o parte del DNI del miembro a buscar.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    Public Function ListarPorDni(dni As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_pagos WHERE dni_miembro LIKE @dni"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", "%" & dni & "%"}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Busca pagos por coincidencia parcial de nombre de plan utilizando la vista <c>vista_pagos</c>.
    ''' </summary>
    ''' <param name="nombre">Nombre o parte del nombre del plan a buscar.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    Public Function ListarPorNombrePlan(nombre As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_pagos WHERE nombre_plan LIKE @nombre"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@nombre", "%" & nombre & "%"}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Busca pagos por método de pago utilizando la vista <c>vista_pagos</c>.
    ''' </summary>
    ''' <param name="metodoPago">Método de pago a buscar.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    Public Function ListarPorMetodoPago(metodoPago As String) As DataTable
        Try
            Dim query As String = "SELECT * FROM vista_pagos WHERE metodo = @metodoPago"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@metodoPago", metodoPago}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Busca pagos por rango de montos utilizando la vista <c>vista_pagos</c>.
    ''' </summary>
    ''' <param name="montoMin">Monto mínimo.</param>
    ''' <param name="montoMax">Monto máximo.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    Public Function ListarPorMontos(montoMin As Decimal, montoMax As Decimal) As DataTable
        Try
            Dim query As String = "
            SELECT * 
            FROM vista_pagos
            WHERE monto BETWEEN @montoMin AND @montoMax"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@montoMin", montoMin},
            {"@montoMax", montoMax}
        }
            Return ExecuteQuery(query, parameters)
        Catch ex As Exception
            ManejarErrores.Log("Capa Datos", ex)
            Throw
        End Try
    End Function
End Class

