Imports Gimnasio.Entidades
Imports Gimnasio.Negocio
Imports LogDeErrores

Public Class FrmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Formato()
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al cargar el formulario de inicio de sesión: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub Formato()
        tbContraseña.UseSystemPasswordChar = True
        tbUsuario.Text = ""
        tbContraseña.Text = ""
    End Sub

    Private Sub btIniciarSesion_Click(sender As Object, e As EventArgs) Handles btIniciarSesion.Click
        Try
            Dim username As String = tbUsuario.Text.Trim()
            Dim password As String = tbContraseña.Text.Trim()

            If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
                MsgBox("Por favor, ingrese su usuario y contraseña.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            Dim nUsuarios As New NUsuarios()
            Dim usuarioActual As Usuarios
            usuarioActual = nUsuarios.ValidarCredenciales(username, password)
            If usuarioActual IsNot Nothing Then
                Me.Hide()
                Dim frmPrincipal As New FrmPrincipal(usuarioActual)
                frmPrincipal.Show()
            Else
                MsgBox("Usuario o contraseña incorrectos", MsgBoxStyle.Critical, "Error")
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al iniciar sesión: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub pbMostrarContraseña_Click(sender As Object, e As EventArgs) Handles pbMostrarContraseña.Click
        Try
            If tbContraseña.UseSystemPasswordChar Then
                tbContraseña.UseSystemPasswordChar = False
                pbMostrarContraseña.Image = My.Resources.ojo_abierto
            Else
                tbContraseña.UseSystemPasswordChar = True
                pbMostrarContraseña.Image = My.Resources.ojo_cerrado
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al mostrar contraseña:" & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class