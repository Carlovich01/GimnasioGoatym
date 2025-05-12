Imports System.Data
Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports LogDeErrores

Public Class NMiembros
    Private dMiembros As New DMiembros()
    Public Function Listar() As DataTable
        Dim dvMiembros As DataTable
        Try
            dvMiembros = dMiembros.Listar()
            Return dvMiembros
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Sub ValidarCampos(Obj As Miembros)
        If Obj.Dni.Length > 15 Then
            Throw New Exception("El DNI no puede tener más de 15 caracteres.")
        End If

        If Obj.Nombre.Length > 100 Then
            Throw New Exception("El nombre no puede tener más de 100 caracteres.")
        End If
        If Obj.Apellido.Length > 100 Then
            Throw New Exception("El apellido no puede tener más de 100 caracteres.")
        End If
        If String.IsNullOrWhiteSpace(Obj.Genero) Then
            Obj.Genero = Nothing
        End If
        If String.IsNullOrWhiteSpace(Obj.Telefono) Then
            Obj.Telefono = Nothing
        ElseIf Obj.Telefono.Length > 30 Then
            Throw New Exception("El teléfono no puede tener más de 30 caracteres.")
        End If
        If String.IsNullOrWhiteSpace(Obj.Email) Then
            Obj.Email = Nothing
        ElseIf Obj.Email.Length > 100 Then
            Throw New Exception("El email no puede tener más de 100 caracteres.")
        End If
    End Sub

    Public Sub Insertar(Obj As Miembros)
        Try
            Dim existeDni As DataTable = dMiembros.ObtenerPorDni(Obj.Dni)
            If existeDni.Rows.Count > 0 Then
                Throw New Exception("El DNI ya está registrado.")
            End If
            ValidarCampos(Obj)
            dMiembros.Insertar(Obj)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Actualizar(Obj As Miembros)
        Try
            ValidarCampos(Obj)
            dMiembros.Actualizar(Obj)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Eliminar(id As UInteger)
        Try
            dMiembros.Eliminar(id)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function ListarPorNombre(nombre As String) As DataTable
        Try
            If nombre.Length > 100 Then
                Throw New Exception("El nombre no puede tener más de 100 caracteres.")
            End If
            Dim dvMiembros As DataTable = dMiembros.ListarPorNombre(nombre)
            Return dvMiembros
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ObtenerPorDni(dni As String) As DataTable
        Try
            If dni.Length > 15 Then
                Throw New Exception("El DNI no puede tener más de 15 caracteres.")
            End If
            Dim dvMiembros As DataTable = dMiembros.ObtenerPorDni(dni)
            Return dvMiembros
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
            Dim dvMiembros As DataTable = dMiembros.ListarPorDni(dni)
            Return dvMiembros
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class