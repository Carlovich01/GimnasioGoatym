Imports Gimnasio.Entidades
Imports Gimnasio.Negocio
Imports Gimnasio.Errores

''' <summary>
''' Formulario de inicio de sesión para el sistema de gimnasio. Permite al usuario ingresar sus credenciales y acceder al sistema principal.
''' </summary>
''' <remarks>
''' Todas las operaciones de esta capa están envueltas en bloques Try...Catch. 
''' El manejo de errores se realiza a través de <see cref="Gimnasio.Errores.ManejarErrores.Mostrar(String, Exception)"/>
''' que permite guardar el error en un log.txt y a su vez mostrar un mensaje al usuario. 
''' </remarks>
Public Class FrmLogin
    ''' <summary>
    ''' Evento que se ejecuta al cargar el formulario. Inicializa el formato de los controles
    ''' </summary>
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Formato()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar el formulario de inicio de sesión", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Establece el formato inicial de los controles del formulario. Limpia los campos de usuario y contraseña y oculta la contraseña.
    ''' </summary>
    Public Sub Formato()
        Try
            tbUsuario.Text = "admin"
            tbContraseña.Text = "1234"
            tbContraseña.UseSystemPasswordChar = True
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al establecer el formato del formulario de inicio de sesión", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Iniciar Sesión" en el formulario de login.
    ''' - Obtiene el nombre de usuario y la contraseña ingresados en los campos.
    ''' - Valida que ambos campos no estén vacíos; si alguno está vacío, lanza una excepción y muestra un mensaje de error.
    ''' - Instancia la capa de negocio <see cref="NUsuarios"/> y llama a <see cref="NUsuarios.ValidarCredenciales"/> para verificar las credenciales.
    '''     - Si las credenciales son correctas (el método devuelve un objeto <see cref="Usuarios"/> distinto de Nothing):
    '''         - Oculta el formulario de login.
    '''         - Crea y muestra el formulario principal <see cref="FrmPrincipal"/>, pasando el usuario autenticado como parámetro.
    '''     - Si las credenciales son incorrectas, lanza una excepción y muestra un mensaje de error.
    ''' </summary>
    Private Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click
        Try
            Dim username As String = tbUsuario.Text
            Dim password As String = tbContraseña.Text

            If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
                Throw New Exception("Usuario o contraseña vacíos")
            End If

            Dim nUsuarios As New NUsuarios()
            Dim usuarioActual As Usuarios
            usuarioActual = nUsuarios.ValidarCredenciales(username, password)
            If usuarioActual IsNot Nothing Then
                Me.Hide()
                Dim frmPrincipal As New FrmPrincipal(Me, usuarioActual)
                frmPrincipal.Show()
            Else
                Throw New Exception("Usuario o contraseña incorrectos")
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al iniciar sesión", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el icono para mostrar u ocultar la contraseña en el formulario de login.
    ''' - Verifica el estado actual del campo de contraseña:
    '''     - Si la contraseña está oculta, la muestra y cambia el icono a "ojo abierto".
    '''     - Si la contraseña está visible, la oculta y cambia el icono a "ojo cerrado".
    ''' </summary>
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
            ManejarErrores.Mostrar("Error al mostrar/ocultar la contraseña", ex)
        End Try
    End Sub
End Class