Imports Gimnasio.Entidades
Imports Gimnasio.Negocio
Imports LogDeErrores

''' <summary>
''' Formulario de inicio de sesión para el sistema de gimnasio.
''' Permite al usuario ingresar sus credenciales y acceder al sistema principal.
''' </summary>
Public Class FrmLogin
    ''' <summary>
    ''' Evento que se ejecuta al cargar el formulario.
    ''' Inicializa el formato de los controles y gestiona errores de carga.
    ''' </summary>
    ''' <param name="sender">Objeto que genera el evento.</param>
    ''' <param name="e">Argumentos del evento.</param>
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Formato()
        Catch ex As Exception
            ' Registra el error utilizando Logger.LogError en un archivo de texto y muestra un mensaje al usuario.
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al cargar el formulario de inicio de sesión: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Establece el formato inicial de los controles del formulario.
    ''' Limpia los campos de usuario y contraseña y oculta la contraseña.
    ''' </summary>
    Public Sub Formato()
        tbContraseña.UseSystemPasswordChar = True
        tbUsuario.Text = ""
        tbContraseña.Text = ""
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón de iniciar sesión.
    ''' Valida las credenciales del usuario utilizando <see cref="NUsuarios.ValidarCredenciales"/>.
    ''' Si las credenciales son correctas, muestra el formulario principal <see cref="FrmPrincipal"/>.
    ''' </summary>
    ''' <param name="sender">Objeto que genera el evento.</param>
    ''' <param name="e">Argumentos del evento.</param>
    Private Sub btIniciarSesion_Click(sender As Object, e As EventArgs) Handles btIniciarSesion.Click
        Try
            Dim username As String = tbUsuario.Text.Trim()
            Dim password As String = tbContraseña.Text.Trim()

            If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
                MsgBox("Por favor, ingrese su usuario y contraseña.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            ' Instancia la capa de negocio NUsuarios y valida las credenciales.
            Dim nUsuarios As New NUsuarios()
            Dim usuarioActual As Usuarios
            usuarioActual = nUsuarios.ValidarCredenciales(username, password)
            If usuarioActual IsNot Nothing Then
                ' Si las credenciales son válidas, oculta el formulario de login y muestra FrmPrincipal
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

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el icono para mostrar/ocultar la contraseña.
    ''' Alterna la visibilidad del texto de la contraseña y cambia el icono correspondiente.
    ''' </summary>
    ''' <param name="sender">Objeto que genera el evento.</param>
    ''' <param name="e">Argumentos del evento.</param>
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