Imports System.Data
Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports LogDeErrores
Imports System.Security.Cryptography
Imports System.Text


Public Class NUsuarios
    Private dUsuarios As New DUsuarios()

    Private Sub ValidarCampos(Obj As Usuarios)
        If Obj.Username.Length > 50 Then
            Throw New Exception("El nombre de usuario no puede tener más de 50 caracteres.")
        End If
        If Obj.PasswordHash.Length > 128 Then
            Throw New Exception("La contraseña no puede tener más de 128 caracteres.")
        End If
        If Obj.NombreCompleto.Length > 150 Then
            Throw New Exception("El nombre no puede tener más de 150 caracteres.")
        End If
        If String.IsNullOrWhiteSpace(Obj.Email) Then
            Obj.Email = Nothing
        ElseIf Obj.Email.Length > 100 Then
            Throw New Exception("El nombre no puede tener más de 100 caracteres.")
        End If
    End Sub

    Private Function GenerarHash(password As String) As String
        Try
            Using sha256 As SHA256 = SHA256.Create()
                Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
                Dim hash As Byte() = sha256.ComputeHash(bytes)
                Return Convert.ToBase64String(hash)
            End Using
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function


    Public Function Listar() As DataTable
        Try
            Dim dvUsuarios As DataTable
            dvUsuarios = dUsuarios.Listar()
            Return dvUsuarios
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub Insertar(Obj As Usuarios)
        Try
            If dUsuarios.ObtenerPorUsername(Obj.Username) IsNot Nothing Then
                Throw New Exception("El username ya está registrado.")
            End If
            ValidarCampos(Obj)
            Obj.PasswordHash = GenerarHash(Obj.PasswordHash)
            dUsuarios.Insertar(Obj)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Actualizar(Obj As Usuarios)
        Try
            ValidarCampos(Obj)
            Obj.PasswordHash = GenerarHash(Obj.PasswordHash)
            dUsuarios.Actualizar(Obj)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub


    Public Sub Eliminar(id As UInteger)
        Try
            dUsuarios.Eliminar(id)
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function ListarPorNombre(nombre As String) As DataTable
        Try
            If nombre.Length > 150 Then
                Throw New Exception("El nombre no puede tener más de 150 caracteres.")
            End If
            Dim dvUsuarios As DataTable = dUsuarios.ListarPorNombre(nombre)
            Return dvUsuarios
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ValidarCredenciales(username As String, password As String) As Usuarios
        Try
            Dim usuario As Usuarios = dUsuarios.ObtenerPorUsername(username)
            If usuario IsNot Nothing Then
                Dim hashIngresado As String = GenerarHash(password)
                If usuario.PasswordHash = hashIngresado Then
                    Return usuario
                End If
            End If
            Return Nothing
        Catch ex As Exception
            Logger.LogError("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class