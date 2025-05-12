Imports Gimnasio.Negocio
Imports Gimnasio.Entidades
Imports LogDeErrores

Public Class FrmPrincipal
    Private usuarioActual As Usuarios

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
    Public Function obtenerUsuarioActual() As Usuarios
        Return usuarioActual
    End Function

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim nMembresias As New NMembresias()
            nMembresias.ActualizaAEstadoInactiva()
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al actualizar los estados de las membresías: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

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

    Private Sub btnPlanes_Click(sender As Object, e As EventArgs) Handles btnPlanes.Click
        Try
            Dim frmPlanes = New FrmPlanes(usuarioActual)
            MostrarFormulario(frmPlanes)
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de planes: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnMiembros_Click(sender As Object, e As EventArgs) Handles btnMiembros.Click
        Try
            Dim frmMiembros = New FrmMiembros(Me)
            MostrarFormulario(frmMiembros)
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de miembros: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnMembresias_Click(sender As Object, e As EventArgs) Handles btnMembresias.Click
        Try
            Dim frmMembresias = New FrmMembresias(usuarioActual)
            MostrarFormulario(frmMembresias)
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de membresías: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnPagos_Click(sender As Object, e As EventArgs) Handles btnPagos.Click
        Try
            Dim frmPagos = New FrmPagos(usuarioActual)
            MostrarFormulario(frmPagos)
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de pagos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnAsistencia_Click(sender As Object, e As EventArgs) Handles btnAsistencia.Click
        Try
            Dim frmAsistencia = New FrmAsistencias()
            MostrarFormulario(frmAsistencia)
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de asistencia: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btRegistroAsistencias_Click(sender As Object, e As EventArgs) Handles btRegistroAsistencias.Click
        Try
            Dim frmRegistrosAsistencias = New FrmRegistroAsistencias(usuarioActual)
            MostrarFormulario(frmRegistrosAsistencias)
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de Asistencia: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnReclamos_Click(sender As Object, e As EventArgs) Handles btnReclamos.Click
        Try
            Dim frmReclamos = New FrmReclamos(usuarioActual)
            MostrarFormulario(frmReclamos)
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de reclamos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
        Try
            Dim frmUsuarios = New FrmUsuarios()
            MostrarFormulario(frmUsuarios)
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de Usuarios: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


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