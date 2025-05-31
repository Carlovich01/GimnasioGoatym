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
    ''' Referencia al formulario de registro de asistencias <see cref="FrmRegistroAsistencias"/>.
    ''' </summary>
    Private frmRegistroAsistencias As FrmRegistroAsistencias

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
    ''' - Si ya existe un formulario cargado en el panel, lo libera de memoria correctamente:
    '''   - Si el formulario actual es una instancia de <see cref="FrmRegistroAsistencias"/> verifica que:
    '''     - Si es el mismo formulario que se intenta mostrar, no hace nada y retorna.
    '''     - Si es diferente, verifica si su formulario hijo (<see cref="FrmAsistencias"/>) está abierto.
    '''     - Si <see cref="FrmAsistencias"/> no está abierto o ya fue liberado, elimina y libera la instancia 
    '''     de <see cref="FrmRegistroAsistencias"/> y su referencia.
    '''     - Si <see cref="FrmAsistencias"/> sigue abierto, mantiene la instancia de <see cref="FrmRegistroAsistencias"/> viva 
    '''     para preservar su estado.
    '''   - Si el formulario actual no es <see cref="FrmRegistroAsistencias"/>, lo elimina y libera normalmente.
    ''' - Limpia el panel de cualquier control previo.
    ''' - Configura el formulario recibido como parámetro para que no sea de nivel superior, sin bordes y ajustado al tamaño del panel principal.
    ''' - Agrega el formulario al panel y lo muestra.
    ''' </summary>
    ''' <param name="formulario">Instancia de <see cref="Form"/> a mostrar en el panel principal.</param>
    Public Sub MostrarFormulario(formulario As Form)
        Try
            If PanelDeFormularios.Controls.Count > 0 AndAlso TypeOf PanelDeFormularios.Controls(0) Is Form Then
                Dim formActual = CType(PanelDeFormularios.Controls(0), Form)
                If TypeOf formActual Is FrmRegistroAsistencias Then
                    If formActual Is formulario Then
                        Return
                    End If
                    Dim frmReg = CType(formActual, FrmRegistroAsistencias)
                    Dim frmAsist As FrmAsistencias = frmReg.GetFrmAsistencia()
                    If frmAsist Is Nothing OrElse frmAsist.IsDisposed Then
                        formActual.Dispose()
                        frmRegistroAsistencias = Nothing
                    End If
                Else
                    formActual.Dispose()
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
    ''' Evento que abre el formulario de planes <see cref="FrmPlanes"/>.
    ''' </summary>
    Private Sub btnPlanes_Click(sender As Object, e As EventArgs) Handles btnPlanes.Click
        Try
            Dim frmPlanes = New FrmPlanes(usuarioActual)
            MostrarFormulario(frmPlanes)
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de planes", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que abre el formulario de miembros <see cref="FrmMiembros"/>.
    ''' </summary>
    Private Sub btnMiembros_Click(sender As Object, e As EventArgs) Handles btnMiembros.Click
        Try
            Dim frmMiembros = New FrmMiembros(Me)
            MostrarFormulario(frmMiembros)
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de miembros", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que abre el formulario de membresías <see cref="FrmMembresias"/>.
    ''' </summary>
    Private Sub btnMembresias_Click(sender As Object, e As EventArgs) Handles btnMembresias.Click
        Try
            Dim frmMembresias = New FrmMembresias(usuarioActual)
            MostrarFormulario(frmMembresias)
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de membresías", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que abre el formulario de pagos <see cref="FrmPagos"/>.
    ''' </summary>
    Private Sub btnPagos_Click(sender As Object, e As EventArgs) Handles btnPagos.Click
        Try
            Dim frmPagos = New FrmPagos(usuarioActual)
            MostrarFormulario(frmPagos)
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de pagos", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón para abrir el formulario de registro de asistencias (<see cref="FrmRegistroAsistencias"/>).
    ''' - Si no existe una instancia activa de <see cref="FrmRegistroAsistencias"/>, crea una nueva pasando el usuario actualmente logueado.
    ''' - Si ya existe una instancia activa, reutiliza la misma para evitar duplicados y mantener el estado.
    ''' - Llama a <see cref="MostrarFormulario"/> para mostrar el formulario de registro de asistencias en el panel principal de la aplicación.
    ''' </summary>
    Private Sub btnRegistroAsistencias_Click(sender As Object, e As EventArgs) Handles btRegistroAsistencias.Click
        Try
            If frmRegistroAsistencias Is Nothing Then
                frmRegistroAsistencias = New FrmRegistroAsistencias(usuarioActual)
            End If
            MostrarFormulario(frmRegistroAsistencias)
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de registro de asistencias", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que abre el formulario de reclamos <see cref="FrmReclamos"/>.
    ''' </summary>
    Private Sub btnReclamos_Click(sender As Object, e As EventArgs) Handles btnReclamos.Click
        Try
            Dim frmReclamos = New FrmReclamos(usuarioActual)
            MostrarFormulario(frmReclamos)
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de reclamos", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que abre el formulario de usuarios <see cref="FrmUsuarios"/>.
    ''' Solo visible para usuarios con rol de administrador.
    ''' </summary>
    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
        Try
            Dim frmUsuarios = New FrmUsuarios()
            MostrarFormulario(frmUsuarios)
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de usuarios", ex)
        End Try
    End Sub

    ''' <summary>
    ''' - Se ejecuta al hacer clic en el elemento de menú "Cerrar Sesión".
    ''' - Solicita confirmación al usuario mediante un cuadro de diálogo.
    ''' - Si el usuario confirma la acción:
    '''     - Cierra y libera los recursos del formulario Registro de Asistencia y a su hijo.
    '''     - Oculta el formulario principal.
    '''     - Muestra el formulario de login.
    '''     - Restablece los campos del formulario de login llamando a <see cref="FrmLogin.Formato()"/>.
    '''     - Libera los recursos del formulario principal.
    ''' </summary>
    Private Sub miCerrarSesion_Click(sender As Object, e As EventArgs) Handles miCerrarSesión.Click
        Try
            Dim resultado = MessageBox.Show("¿Está seguro de que desea cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If frmRegistroAsistencias IsNot Nothing Then
                Dim frmAsist As FrmAsistencias = frmRegistroAsistencias.GetFrmAsistencia()
                If frmAsist IsNot Nothing AndAlso Not frmAsist.IsDisposed Then
                    frmAsist.Close()
                    frmAsist.Dispose()
                End If
                frmRegistroAsistencias.Close()
                frmRegistroAsistencias.Dispose()
                frmRegistroAsistencias = Nothing
            End If
            If resultado = DialogResult.Yes Then
                Me.Hide()
                frmLogin.Show()
                frmLogin.Formato()
                Me.Dispose()
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cerrar sesión", ex)
        End Try
    End Sub

    ''' <summary>
    ''' - Se ejecuta al hacer clic en el elemento de menú "Salir".
    ''' - Libera recursos de el formulario de login como de este formulario.
    ''' </summary>
    Private Sub frmPrincipal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            frmLogin.Dispose()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al liberar recursos al cerrar la aplicación", ex)
        End Try
    End Sub

End Class