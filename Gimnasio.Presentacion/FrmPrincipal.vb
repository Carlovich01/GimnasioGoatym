Imports Gimnasio.Negocio
Imports Gimnasio.Entidades
Imports LogDeErrores

''' <summary>
''' Formulario principal de la aplicación del gimnasio.
''' Gestiona la navegación entre los diferentes módulos y controla el acceso según el rol del usuario.
''' </summary>
''' <remarks>
''' Utiliza la clase <see cref="Usuarios"/> para identificar al usuario logueado y su rol.
''' Llama a formularios secundarios como <see cref="FrmPlanes"/>, <see cref="FrmMiembros"/>, <see cref="FrmMembresias"/>, <see cref="FrmPagos"/>, <see cref="FrmAsistencias"/>, <see cref="FrmRegistroAsistencias"/>, <see cref="FrmReclamos"/> y <see cref="FrmUsuarios"/>.
''' </remarks>
Public Class FrmPrincipal
    ''' <summary>
    ''' Usuario actualmente logueado en la aplicación.
    ''' </summary>
    Private usuarioActual As Usuarios

    ''' <summary>
    ''' Constructor del formulario principal.
    ''' Inicializa los componentes y configura la interfaz según el rol del usuario.
    ''' </summary>
    ''' <param name="usuario">Instancia de <see cref="Usuarios"/> que representa al usuario logueado.</param>
    Public Sub New(usuario As Usuarios)
        InitializeComponent()
        usuarioActual = usuario
        btnUsuarioLogueado.Text = usuarioActual.NombreCompleto
        lblBienvenido.Text = "¡Bienvenido, " & usuarioActual.NombreCompleto & "! Tu rol es " & If(usuarioActual.IdRol = 1, "Administrador", "Recepcionista") & "."
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
    ''' Evento que se ejecuta al cargar el formulario principal.
    ''' Actualiza el estado de las membresías utilizando <see cref="NMembresias.ActualizaAEstadoInactiva"/>.
    ''' </summary>
    ''' <param name="sender">Objeto que genera el evento.</param>
    ''' <param name="e">Argumentos del evento.</param>
    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim nMembresias As New NMembresias()
            nMembresias.ActualizaAEstadoInactiva()
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al actualizar los estados de las membresías: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Muestra un formulario secundario dentro del panel principal.
    ''' Elimina cualquier formulario previamente cargado en el panel.
    ''' </summary>
    ''' <param name="formulario">Instancia de <see cref="Form"/> a mostrar.</param>
    Public Sub MostrarFormulario(formulario As Form)
        Try
            If PanelDeFormularios.Controls.Count > 0 AndAlso TypeOf PanelDeFormularios.Controls(0) Is Form Then
                PanelDeFormularios.Controls(0).Dispose()
            End If

            PanelDeFormularios.Controls.Clear()
            formulario.TopLevel = False
            formulario.FormBorderStyle = FormBorderStyle.None
            formulario.Dock = DockStyle.Fill
            PanelDeFormularios.Controls.Add(formulario)
            formulario.Show()
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al mostrar formulario: " & ex.Message, MsgBoxStyle.Critical, "Error")
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
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de planes: " & ex.Message, MsgBoxStyle.Critical, "Error")
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
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de miembros: " & ex.Message, MsgBoxStyle.Critical, "Error")
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
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de membresías: " & ex.Message, MsgBoxStyle.Critical, "Error")
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
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de pagos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que abre el formulario de asistencias <see cref="FrmAsistencias"/>.
    ''' </summary>
    Private Sub btnAsistencia_Click(sender As Object, e As EventArgs) Handles btnAsistencia.Click
        Try
            Dim frmAsistencia = New FrmAsistencias()
            MostrarFormulario(frmAsistencia)
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de asistencia: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que abre el formulario de registro de asistencias <see cref="FrmRegistroAsistencias"/>.
    ''' </summary>
    Private Sub btRegistroAsistencias_Click(sender As Object, e As EventArgs) Handles btRegistroAsistencias.Click
        Try
            Dim frmRegistrosAsistencias = New FrmRegistroAsistencias(usuarioActual)
            MostrarFormulario(frmRegistrosAsistencias)
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de Asistencia: " & ex.Message, MsgBoxStyle.Critical, "Error")
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
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de reclamos: " & ex.Message, MsgBoxStyle.Critical, "Error")
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
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de Usuarios: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que gestiona el cierre de sesión del usuario.
    ''' Oculta el formulario principal, muestra el formulario de login <see cref="FrmLogin"/> y limpia los campos.
    ''' </summary>
    Private Sub CerrarSesiónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesiónToolStripMenuItem.Click
        Try
            Dim resultado = MessageBox.Show("¿Está seguro de que desea cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resultado = DialogResult.Yes Then
                Me.Hide()
                FrmLogin.Show()
                FrmLogin.Formato()
                Me.Dispose()
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al cerrar sesión: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cerrar el formulario principal.
    ''' Libera los recursos del formulario principal y del formulario de login.
    ''' </summary>
    Private Sub frmPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Me.Dispose()
            FrmLogin.Dispose()
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al cerrar la aplicación: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class