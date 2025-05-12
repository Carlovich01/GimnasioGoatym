Imports Gimnasio.Entidades
Imports Gimnasio.Negocio
Imports LogDeErrores

Public Class FrmUsuarios
    Private nUsuarios As New NUsuarios()
    Private esNuevo As Boolean
    Private UsuarioPorActualizar As Usuarios
    Private Sub frmUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()
            dgvListado.Columns(0).Visible = False
            dgvListado.Columns(1).HeaderText = "NOMBRE DE USUARIO"
            dgvListado.Columns(2).HeaderText = "CONTRASEÑA"
            dgvListado.Columns(3).HeaderText = "NOMBRE COMPLETO"
            dgvListado.Columns(4).HeaderText = "EMAIL"
            dgvListado.Columns(5).HeaderText = "ROL"
            dgvListado.Columns(6).HeaderText = "FECHA CREACION"
            dgvListado.Columns(7).HeaderText = "ULTIMA MODIFICACION"
            cbOpcionBuscar.SelectedIndex = 0
        Catch ex As Exception
            Logger.LogError("Capa Presentacion", ex)
            MsgBox("Error al cargar los usuarios: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ActualizarDataGridView()
        Try
            Dim dvUsuarios As DataTable = nUsuarios.Listar()
            dgvListado.DataSource = dvUsuarios
            lblTotal.Text = "Total Usuarios: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            Logger.LogError("Capa Presentacion", ex)
            MsgBox("Error al cargar los usuarios: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub HabilitarListado()
        panelDatosIngreso.Visible = False
        panelListado.Enabled = True
    End Sub

    Public Sub HabilitarIngreso()
        panelDatosIngreso.Visible = True
        panelDatosIngreso.Dock = DockStyle.Fill
        panelListado.Enabled = False
        tbNombreUsuario.Clear()
        tbContraseña.Clear()
        tbNombreCompleto.Clear()
        tbEmail.Clear()
        cbRol.SelectedIndex = 0
    End Sub

    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Try
            HabilitarIngreso()
            esNuevo = True
            lblDatosIngreso.Text = "Agregar Usuario"
        Catch ex As Exception
            Logger.LogError("Capa Presentacion", ex)
            MsgBox("Error al abrir el formulario de inserción: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                UsuarioPorActualizar = New Usuarios
                UsuarioPorActualizar.IdUsuario = CInt(selectedRow.Cells("id_usuario").Value)
                UsuarioPorActualizar.Username = selectedRow.Cells("username").Value.ToString
                UsuarioPorActualizar.NombreCompleto = selectedRow.Cells("nombre_completo").Value.ToString
                UsuarioPorActualizar.Email = selectedRow.Cells("email").Value.ToString
                UsuarioPorActualizar.IdRol = If(selectedRow.Cells("nombre_rol").Value.ToString = "Administrador", 1, 2)
                esNuevo = False
                HabilitarIngreso()
                lblDatosIngreso.Text = "Actualizar Usuario"
                tbNombreUsuario.Text = UsuarioPorActualizar.Username
                tbNombreCompleto.Text = UsuarioPorActualizar.NombreCompleto
                tbEmail.Text = UsuarioPorActualizar.Email
                cbRol.SelectedItem = If(UsuarioPorActualizar.IdRol = 1, "Administrador", "Recepcionista")
            Else
                MsgBox("Seleccione un usuario para actualizar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion", ex)
            MsgBox("Error al seleccionar el usuario: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If String.IsNullOrWhiteSpace(tbNombreUsuario.Text) OrElse String.IsNullOrWhiteSpace(tbContraseña.Text) OrElse String.IsNullOrWhiteSpace(tbNombreCompleto.Text) OrElse String.IsNullOrWhiteSpace(cbRol.Text) Then
                MsgBox("Por favor, complete los campos obligatorios (*).", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            If esNuevo Then
                Dim nuevoUsuario As New Usuarios()
                nuevoUsuario.Username = tbNombreUsuario.Text
                nuevoUsuario.PasswordHash = tbContraseña.Text
                nuevoUsuario.NombreCompleto = tbNombreCompleto.Text
                nuevoUsuario.Email = tbEmail.Text
                nuevoUsuario.IdRol = If(cbRol.SelectedItem.ToString() = "Administrador", 1, 2)
                nUsuarios.Insertar(nuevoUsuario)
                ActualizarDataGridView()
                MsgBox("Usuario guardado exitosamente.", MsgBoxStyle.Information, "Exito")
            Else
                UsuarioPorActualizar.IdUsuario = UsuarioPorActualizar.IdUsuario
                UsuarioPorActualizar.Username = tbNombreUsuario.Text
                UsuarioPorActualizar.PasswordHash = tbContraseña.Text
                UsuarioPorActualizar.NombreCompleto = tbNombreCompleto.Text
                UsuarioPorActualizar.Email = tbEmail.Text
                UsuarioPorActualizar.IdRol = If(cbRol.SelectedItem.ToString() = "Administrador", 1, 2)
                nUsuarios.Actualizar(UsuarioPorActualizar)
                ActualizarDataGridView()
                MsgBox("Usuario actualizado exitosamente.", MsgBoxStyle.Information, "Exito")
            End If
            HabilitarListado()
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox(If(esNuevo, "Error al guardar usuario: " & ex.Message, "Error al actualizar usuario: " & ex.Message), MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            HabilitarListado()
        Catch ex As Exception
            MsgBox("Error al cancelar: " & ex.Message, MsgBoxStyle.Critical, "Error")
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

    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            If cbOpcionBuscar.SelectedIndex = 0 Then
                Dim dvUsuaurio = nUsuarios.ListarPorNombre(tbBuscar.Text)
                dgvListado.DataSource = dvUsuaurio
                lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion", ex)
            MsgBox("Error al buscar usuario: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                Dim idUsuario As UInteger = CInt(selectedRow.Cells("id_usuario").Value)

                Dim confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar este Usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    nUsuarios.Eliminar(idUsuario)

                    ActualizarDataGridView()
                    MsgBox("Usuario eliminado exitosamente.", MsgBoxStyle.Information, "Exito")
                End If
            Else
                MsgBox("Seleccione un Usuario para eliminar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion", ex)
            MsgBox("Error al eliminar el Usuario: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

End Class