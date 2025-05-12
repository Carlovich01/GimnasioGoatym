Imports System.Data
Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports LogDeErrores

Public Class NPlanes
    Private dPlanes As New DPlanes()

    Private Sub ValidarCampos(Obj As Planes)
        If Obj.NombrePlan.Length > 100 Then
            Throw New Exception("El nombre del plan no puede exceder los 100 caracteres.")
        End If
        If Obj.Precio > 9999999999 Then
            Throw New Exception("El precio no puede exceder los 10 dígitos.")
        End If

        If String.IsNullOrWhiteSpace(Obj.Descripcion) Then
            Obj.Descripcion = Nothing
        End If
    End Sub
    Public Function Listar() As DataTable
        Try
            Return dPlanes.Listar()
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub Insertar(Obj As Planes)
        Try
            Dim existePlan As DataTable = dPlanes.ListarPorNombre(Obj.NombrePlan)
            If existePlan.Rows.Count > 0 Then
                Throw New Exception("El Plan ya está registrado.")
            End If
            ValidarCampos(Obj)
            dPlanes.Insertar(Obj)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Actualizar(Obj As Planes)
        Try
            ValidarCampos(Obj)
            dPlanes.Actualizar(Obj)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Eliminar(id As UInteger)
        Try
            dPlanes.Eliminar(id)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function ListarPorNombre(nombre As String) As DataTable
        Try
            If nombre.Length > 100 Then
                Throw New Exception("El nombre del plan no puede exceder los 100 caracteres.")
            End If
            Return dPlanes.ListarPorNombre(nombre)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarPorDuracion(duracion As UInteger) As DataTable
        Try
            If duracion <= 0 Then
                Throw New Exception("La duración debe ser mayor a 0.")
            End If
            Return dPlanes.ListarPorDuracion(duracion)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarPorPrecio(precio As Decimal) As DataTable
        Try
            If precio < 0 OrElse precio > 9999999999 Then
                Throw New Exception("El precio no puede ser negativo ni mayor a 10 digitos.")
            End If
            Return dPlanes.ListarPorPrecio(precio)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
