Imports Gimnasio.Negocio
Imports Gimnasio.Entidades
Imports Gimnasio.Errores

''' <summary>
''' Formulario principal de la aplicación del gimnasio. Gestiona la navegación entre los diferentes módulos y controla el acceso según el rol del usuario.
''' Utiliza la clase <see cref="Usuarios"/> para identificar al usuario logueado y su rol. Llama a formularios secundarios como <see cref="FrmPlanes"/>,
''' <see cref="FrmMiembros"/>, <see cref="FrmMembresias"/>, <see cref="FrmPagos"/>, <see cref="FrmRegistroAsistencias"/>, <see cref="FrmReclamos"/> y 
''' <see cref="FrmUsuarios"/>.
''' </summary>
''' <remarks>
''' Todas las operaciones de esta capa están envueltas en bloques Try...Catch. 
''' El manejo de errores se realiza a través de <see cref="Gimnasio.Errores.ManejarErrores.Mostrar(String, Exception)"/>
''' que permite guardar el error en un log.txt y a su vez mostrar un mensaje al usuario.
''' </remarks>
Public Class FrmPrincipal
    ''' <summary>
    ''' Referencia al formulario de login <see cref="FrmLogin"/>. 
    ''' Se utiliza para mostrar el formulario de login al cerrar sesión.
    ''' </summary>
    Private frmLogin As FrmLogin
    ''' <summary>
    ''' Usuario actualmente logueado en la aplicación.
    ''' </summary>
    Private usuarioActual As Usuarios

    ''' <summary>
    ''' Referencia al formulario de planes <see cref="FrmPlanes"/>.
    ''' </summary>
    Private frmPlanes As FrmPlanes

    ''' <summary>
    ''' Referencia al formulario de miembros <see cref="FrmMiembros"/>.
    ''' </summary>
    Private frmMiembros As FrmMiembros

    ''' <summary>
    ''' Referencia al formulario de membresías <see cref="FrmMembresias"/>.
    ''' </summary>
    Private frmMembresias As FrmMembresias

    ''' <summary>
    ''' Referencia al formulario de pagos <see cref="FrmPagos"/>.
    ''' </summary>
    Private frmPagos As FrmPagos

    ''' <summary>
    ''' Referencia al formulario de registro de asistencias <see cref="FrmRegistroAsistencias"/>.
    ''' </summary>
    Private frmRegistroAsistencias As FrmRegistroAsistencias

    ''' <summary>
    ''' Referencia al formulario de reclamos <see cref="FrmReclamos"/>.
    ''' </summary>
    Private frmReclamos As FrmReclamos

    ''' <summary>
    ''' Referencia al formulario de usuarios <see cref="FrmUsuarios"/>.
    ''' </summary>
    Private frmUsuarios As FrmUsuarios

    ''' <summary>
    ''' Constructor del formulario principal.
    ''' - Inicializa los componentes visuales del formulario.
    ''' - Guarda la referencia a la instancia del formulario de login.
    ''' - Asigna el usuario actualmente logueado recibido como parámetro.
    ''' - Muestra el nombre completo del usuario en el botón btnUsuarioLogueado.
    ''' - Si el usuario tiene el rol de recepcionista IdRol = 2:
    '''     - Oculta y deshabilita el apartado de usuarios.
    ''' </summary>
    ''' <param name="usuario">Instancia de <see cref="Usuarios"/> que representa al usuario logueado.</param>
    Public Sub New(frmLogin As FrmLogin, usuario As Usuarios)
        InitializeComponent()
        Me.frmLogin = frmLogin
        usuarioActual = usuario
        btnUsuarioLogueado.Text = usuarioActual.NombreCompleto
        If usuarioActual.IdRol = 2 Then
            btnUsuarios.Visible = False
            btnUsuarios.Enabled = False
            ToolStripSeparator5.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' Devuelve el usuario actualmente logueado.
    ''' </summary>
    ''' <returns>Instancia de <see cref="Usuarios"/> correspondiente al usuario actual.</returns>
    Public Function obtenerUsuarioActual() As Usuarios
        Return usuarioActual
    End Function

    ''' <summary>
    ''' Evento que se ejecuta al cargar el formulario principal. Muestra un mensaje de bienvenida al usuario con su nombre y rol.
    ''' Actualiza el estado de las membresías utilizando <see cref="NMembresias.ActualizaAEstadoInactiva"/>.
    ''' </summary>
    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            MsgBox("¡Bienvenido, " & usuarioActual.NombreCompleto & "! Tu rol es " & If(usuarioActual.IdRol = 1, "Administrador", "Recepcionista") & ".", MsgBoxStyle.Information, "Exito")
            Dim nMembresias As New NMembresias()
            nMembresias.ActualizaAEstadoInactiva()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar el formulario principal", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Muestra un formulario secundario dentro del panel principal de la aplicación.
    ''' Si el formulario que se intenta mostrar ya está activo en el panel, no realiza ninguna acción para evitar recargas innecesarias.
    ''' Si es un formulario diferente, limpia el panel, configura el formulario recibido para que se muestre embebido (sin bordes y ajustado al panel)
    ''' y lo agrega al panel principal, mostrándolo al usuario.
    ''' </summary>
    ''' <param name="formulario">Instancia de <see cref="Form"/> que se desea mostrar en el panel principal.</param>
    Public Sub MostrarFormulario(formulario As Form)
        Try
            If PanelDeFormularios.Controls.Count > 0 Then
                Dim actual As Form = TryCast(PanelDeFormularios.Controls(0), Form)
                If actual Is formulario Then
                    Return
                End If
            End If
            PanelDeFormularios.Controls.Clear()
            formulario.TopLevel = False
            formulario.FormBorderStyle = FormBorderStyle.None
            formulario.Dock = DockStyle.Fill
            PanelDeFormularios.Controls.Add(formulario)
            formulario.Show()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al mostrar formulario", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Planes".
    ''' - Si no existe una instancia previa del formulario de planes (<see cref="FrmPlanes"/>), la crea utilizando el usuario actualmente logueado.
    ''' - Llama al método <see cref="FrmPlanes.Reiniciar"/> para restablecer el estado del formulario de planes antes de mostrarlo.
    ''' - Muestra el formulario de planes embebido en el panel principal mediante <see cref="MostrarFormulario"/>.
    ''' </summary>
    Private Sub btnPlanes_Click(sender As Object, e As EventArgs) Handles btnPlanes.Click
        Try
            If frmPlanes Is Nothing Then
                frmPlanes = New FrmPlanes(usuarioActual)
            End If
            frmPlanes.Reiniciar()
            MostrarFormulario(frmPlanes)
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de planes", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Miembros".
    ''' - Si no existe una instancia previa del formulario de miembros (<see cref="FrmMiembros"/>), 
    '''   la crea pasando como parámetro la instancia del formulario principal (<see cref="FrmPrincipal"/>).
    ''' - Llama al método <see cref="FrmMiembros.Reiniciar"/> para restablecer el estado del formulario de miembros antes de mostrarlo.
    ''' - Muestra el formulario de miembros embebido en el panel principal mediante <see cref="MostrarFormulario"/>.
    ''' </summary>
    Private Sub btnMiembros_Click(sender As Object, e As EventArgs) Handles btnMiembros.Click
        Try
            If frmMiembros Is Nothing Then
                frmMiembros = New FrmMiembros(Me)
            End If
            frmMiembros.Reiniciar()
            MostrarFormulario(frmMiembros)
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de miembros", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Membresías".
    ''' - Si no existe una instancia previa del formulario de membresías (<see cref="FrmMembresias"/>), 
    '''   la crea utilizando el usuario actualmente logueado.
    ''' - Llama al método <see cref="FrmMembresias.Reiniciar"/> para restablecer el estado del formulario de membresías antes de mostrarlo.
    ''' - Muestra el formulario de membresías embebido en el panel principal mediante <see cref="MostrarFormulario"/>.
    ''' </summary>
    Private Sub btnMembresias_Click(sender As Object, e As EventArgs) Handles btnMembresias.Click
        Try
            If frmMembresias Is Nothing Then
                frmMembresias = New FrmMembresias(usuarioActual)
            End If
            frmMembresias.Reiniciar()
            MostrarFormulario(frmMembresias)
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de membresías", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Pagos".
    ''' - Si no existe una instancia previa del formulario de pagos (<see cref="FrmPagos"/>), la crea utilizando el usuario actualmente logueado.
    ''' - Llama al método <see cref="FrmPagos.Reiniciar"/> para restablecer el estado del formulario de pagos antes de mostrarlo.
    ''' - Muestra el formulario de pagos embebido en el panel principal mediante <see cref="MostrarFormulario"/>.
    ''' </summary>
    Private Sub btnPagos_Click(sender As Object, e As EventArgs) Handles btnPagos.Click
        Try
            If frmPagos Is Nothing Then
                frmPagos = New FrmPagos(usuarioActual)
            End If
            frmPagos.Reiniciar()
            MostrarFormulario(frmPagos)
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de pagos", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Registro de Asistencias".
    ''' - Si no existe una instancia previa del formulario de registro de asistencias (<see cref="FrmRegistroAsistencias"/>), 
    '''   la crea utilizando el usuario actualmente logueado.
    ''' - Llama al método <see cref="FrmRegistroAsistencias.Reiniciar"/> para restablecer el estado del formulario antes de mostrarlo.
    ''' - Muestra el formulario de registro de asistencias embebido en el panel principal mediante <see cref="MostrarFormulario"/>.
    ''' </summary>
    Private Sub btnRegistroAsistencias_Click(sender As Object, e As EventArgs) Handles btRegistroAsistencias.Click
        Try
            If frmRegistroAsistencias Is Nothing Then
                frmRegistroAsistencias = New FrmRegistroAsistencias(usuarioActual)
            End If
            frmRegistroAsistencias.Reiniciar()
            MostrarFormulario(frmRegistroAsistencias)
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de registro de asistencias", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Reclamos".
    ''' - Si no existe una instancia previa del formulario de reclamos (<see cref="FrmReclamos"/>), la crea utilizando el usuario actualmente logueado.
    ''' - Llama al método <see cref="FrmReclamos.Reiniciar"/> para restablecer el estado del formulario de reclamos antes de mostrarlo.
    ''' - Muestra el formulario de reclamos embebido en el panel principal mediante <see cref="MostrarFormulario"/>.
    ''' </summary>
    Private Sub btnReclamos_Click(sender As Object, e As EventArgs) Handles btnReclamos.Click
        Try
            If frmReclamos Is Nothing Then
                frmReclamos = New FrmReclamos(usuarioActual)
            End If
            frmReclamos.Reiniciar()
            MostrarFormulario(frmReclamos)
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de reclamos", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Usuarios".
    ''' - Si no existe una instancia previa del formulario de usuarios (<see cref="FrmUsuarios"/>), la crea.
    ''' - Llama al método <see cref="FrmUsuarios.Reiniciar"/> para restablecer el estado del formulario de usuarios antes de mostrarlo.
    ''' - Muestra el formulario de usuarios embebido en el panel principal mediante <see cref="MostrarFormulario"/>.
    ''' </summary>
    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
        Try
            If frmUsuarios Is Nothing Then
                frmUsuarios = New FrmUsuarios()
            End If
            frmUsuarios.Reiniciar()
            MostrarFormulario(frmUsuarios)
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de usuarios", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Muestra el formulario de gestión de membresías (<see cref="FrmMembresias"/>) en el panel principal y habilita el ingreso directo de una membresía 
    ''' para un miembro específico. Si no existe una instancia previa del formulario de membresías, la crea utilizando el usuario actualmente logueado.
    ''' Luego, muestra el formulario y llama al método <see cref="FrmMembresias.HabilitarIngresoConMiembro"/> pasando el DNI del miembro para facilitar la asociación.
    ''' </summary>
    Public Sub MiembroAMembresia(dni As String)
        Try
            If frmMembresias Is Nothing Then
                frmMembresias = New FrmMembresias(usuarioActual)
            End If
            MostrarFormulario(frmMembresias)
            frmMembresias.HabilitarIngresoConMiembro(dni)
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de membresías con miembro", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Libera y cierra todos los formularios secundarios instanciados en el formulario principal, liberando los recursos asociados.
    ''' Cierra y elimina las instancias de <see cref="FrmPlanes"/>, <see cref="FrmMiembros"/>, <see cref="FrmMembresias"/>, <see cref="FrmPagos"/>,
    ''' <see cref="FrmRegistroAsistencias"/>, <see cref="FrmReclamos"/> y <see cref="FrmUsuarios"/> si están activos.
    ''' Finalmente, libera los recursos del propio formulario principal.
    ''' </summary>
    Public Sub LiberarRecursos()
        Try
            If frmPlanes IsNot Nothing AndAlso Not frmPlanes.IsDisposed Then
                frmPlanes.Close()
                frmPlanes.Dispose()
                frmPlanes = Nothing
            End If

            If frmMiembros IsNot Nothing AndAlso Not frmMiembros.IsDisposed Then
                frmMiembros.Close()
                frmMiembros.Dispose()
                frmMiembros = Nothing
            End If

            If frmMembresias IsNot Nothing AndAlso Not frmMembresias.IsDisposed Then
                frmMembresias.Close()
                frmMembresias.Dispose()
                frmMembresias = Nothing
            End If

            If frmPagos IsNot Nothing AndAlso Not frmPagos.IsDisposed Then
                frmPagos.Close()
                frmPagos.Dispose()
                frmPagos = Nothing
            End If

            If frmRegistroAsistencias IsNot Nothing AndAlso Not frmRegistroAsistencias.IsDisposed Then
                frmRegistroAsistencias.Close()
                frmRegistroAsistencias.Dispose()
                frmRegistroAsistencias = Nothing
            End If

            If frmReclamos IsNot Nothing AndAlso Not frmReclamos.IsDisposed Then
                frmReclamos.Close()
                frmReclamos.Dispose()
                frmReclamos = Nothing
            End If

            If frmUsuarios IsNot Nothing AndAlso Not frmUsuarios.IsDisposed Then
                frmUsuarios.Close()
                frmUsuarios.Dispose()
                frmUsuarios = Nothing
            End If
            Me.Dispose()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cerrar", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en la opción "Cerrar Sesión" del menú.
    ''' Solicita confirmación al usuario para cerrar la sesión actual mediante un cuadro de diálogo.
    ''' Si el usuario confirma, muestra nuevamente el formulario de login, restablece su formato 
    ''' y libera los recursos asociados al formulario principal y sus formularios secundarios.
    ''' </summary>
    Private Sub miCerrarSesion_Click(sender As Object, e As EventArgs) Handles miCerrarSesión.Click
        Try
            Dim resultado = MessageBox.Show("¿Está seguro de que desea cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resultado = DialogResult.Yes Then
                frmLogin.Show()
                frmLogin.Formato()
                LiberarRecursos()
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cerrar sesión", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cerrarse el formulario principal de la aplicación. Libera todos los recursos asociados a los formularios secundarios 
    ''' y al propio formulario principal, y cierra el formulario de login.
    ''' </summary>
    Private Sub frmPrincipal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            LiberarRecursos()
            frmLogin.Close()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cerrar la aplicación", ex)
        End Try
    End Sub
End Class