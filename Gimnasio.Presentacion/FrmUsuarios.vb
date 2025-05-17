Imports Gimnasio.Entidades
Imports Gimnasio.Negocio
Imports Gimnasio.Errores

''' <summary>
''' Formulario para la gestión de usuarios del sistema del gimnasio. Permite listar, buscar, agregar, actualizar y eliminar usuarios.
''' Utiliza la clase <see cref="NUsuarios"/> para la lógica de negocio y la clase <see cref="Usuarios"/> como entidad.
''' El manejo de errores se realiza a través de <see cref="Gimnasio.Errores.ManejarErrores.Mostrar(String, Exception)"/>
''' que permite guardar el error en un log.txt y a su vez mostrar un mensaje al usuario. 
''' </summary>
Public Class FrmUsuarios
    ''' <summary>
    ''' Instancia de la capa de negocio para usuarios.
    ''' </summary>
    Private nUsuarios As New NUsuarios()
    ''' <summary>
    ''' Indica si la operación actual es de inserción (<c>True</c>) o actualización (<c>False</c>).
    ''' </summary>
    Private esNuevo As Boolean

    ''' <summary>
    ''' Evento que se ejecuta al cargar el formulario. Inicializa el listado de usuarios y configura las columnas del DataGridView.
    ''' Selecciona una opcion por defecto del comboBox.
    ''' </summary>
    Private Sub frmUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDgv()
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
            ManejarErrores.Mostrar("Error al cargar el formulario de usuarios", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el DataGridView con la lista de usuarios obtenida desde la capa de negocio mediante <see cref="NUsuarios.Listar"/>.
    ''' - Obtiene todos los registros de usuarios y los asigna como origen de datos del DataGridView.
    ''' - Actualiza la etiqueta lblTotal mostrando la cantidad total de usuarios listados.
    ''' </summary>
    Public Sub ActualizarDgv()
        Try
            Dim dvUsuarios As DataTable = nUsuarios.Listar()
            dgvListado.DataSource = dvUsuarios
            lblTotal.Text = "Total Usuarios: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar los usuarios", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el DataGridView con una lista específica de usuarios proporcionada como parámetro.
    ''' - Asigna el DataTable recibido como origen de datos del DataGridView.
    ''' - Actualiza la etiqueta lblTotal mostrando la cantidad total de usuarios listados en el DataGridView.
    ''' </summary>
    Public Sub ActualizarDgv(Listado As DataTable)
        Try
            Dim dvUsuarios As DataTable = Listado
            dgvListado.DataSource = dvUsuarios
            lblTotal.Text = "Total Usuarios: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar los usuarios", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Habilita la vista de listado de usuarios y oculta el panel de ingreso.
    ''' </summary>
    Public Sub HabilitarListado()
        Try
            panelListado.Enabled = True
            panelDatosIngreso.Visible = False
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al habilitar el listado de usuarios", ex)
        End Try
    End Sub

    ''' <summary>
    ''' - Muestra el panel de ingreso (<see cref="panelDatosIngreso"/>) y lo ajusta para ocupar todo el espacio disponible en el formulario.
    ''' - Deshabilita el panel de listado para evitar la interacción mientras se realiza el ingreso o edición.
    ''' - Limpia los campos de nombre de usuario y contraseña para asegurar que no contengan datos previos.
    ''' </summary>
    Public Sub HabilitarIngreso()
        Try
            panelDatosIngreso.Visible = True
            panelDatosIngreso.Dock = DockStyle.Fill
            panelListado.Enabled = False
            tbNombreUsuario.Clear()
            tbContraseña.Clear()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al habilitar el ingreso de datos", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Insertar" en el formulario de usuarios.
    ''' - Habilita el panel de ingreso de datos mediante <see cref="HabilitarIngreso"/> para permitir la carga de un nuevo usuario.
    ''' - Establece la variable esNuevo en True para indicar que la siguiente operación será una inserción.
    ''' - Cambia el texto de la etiqueta lblDatosIngreso a "Agregar Usuario" para informar al usuario sobre la acción actual.
    ''' </summary>
    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Try
            HabilitarIngreso()
            esNuevo = True
            lblDatosIngreso.Text = "Agregar Usuario"
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de inserción", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Actualizar" en el formulario de usuarios.
    ''' - Verifica si hay una fila seleccionada en el DataGridView de usuarios.
    ''' - Si hay selección, prepara el formulario para la edición de un usuario existente:
    '''   - Establece la variable esNuevo en False para indicar que la siguiente operación será una actualización.
    '''   - Habilita el panel de ingreso de datos mediante <see cref="HabilitarIngreso"/>.
    '''   - Cambia el texto de la etiqueta lblDatosIngreso a "Actualizar Usuario".
    '''   - Carga en los controles de ingreso los datos del usuario seleccionado
    ''' - Si no hay selección, lanza una excepción indicando que no se seleccionó ningún usuario para actualizar.
    ''' </summary>
    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                esNuevo = False
                HabilitarIngreso()
                lblDatosIngreso.Text = "Actualizar Usuario"
                tbID.Text = selectedRow.Cells("id_usuario").Value
                tbNombreUsuario.Text = selectedRow.Cells("username").Value.ToString
                tbNombreCompleto.Text = selectedRow.Cells("nombre_completo").Value.ToString
                tbEmail.Text = selectedRow.Cells("email").Value.ToString
                cbRol.SelectedIndex = If(selectedRow.Cells("nombre_rol").Value.ToString = "Administrador", 0, 1)
            Else
                Throw New Exception("No se seleccionó ningún usuario para actualizar.")
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de actualización", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Guardar" en el formulario de usuarios.
    ''' - Valida que los campos obligatorios estén completos; si no lanza una excepción.
    ''' - Crea una instancia de <see cref="Usuarios"/> y asigna los valores de los controles del formulario.
    ''' - Si la operación es de inserción, utiliza <see cref="NUsuarios.Insertar"/> para agregar el usuario y muestra un mensaje de éxito.
    ''' - Si la operación es de actualización, asigna el ID del usuario y utiliza <see cref="NUsuarios.Actualizar"/> para modificar el usuario, 
    ''' mostrando un mensaje de éxito.
    ''' - Actualiza el listado de usuarios mediante <see cref="ActualizarDgv"/> y vuelve a la vista de listado con <see cref="HabilitarListado"/>.
    ''' </summary>
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If String.IsNullOrWhiteSpace(tbNombreUsuario.Text) OrElse String.IsNullOrWhiteSpace(tbContraseña.Text) OrElse String.IsNullOrWhiteSpace(tbNombreCompleto.Text) OrElse String.IsNullOrWhiteSpace(cbRol.Text) Then
                Throw New Exception("Faltan campos obligatorios")
            End If
            Dim Usuario As New Usuarios()
            Usuario.Username = tbNombreUsuario.Text
            Usuario.PasswordHash = tbContraseña.Text
            Usuario.NombreCompleto = tbNombreCompleto.Text
            Usuario.Email = tbEmail.Text
            Usuario.IdRol = If(cbRol.SelectedItem.ToString() = "Administrador", 1, 2)
            If esNuevo Then
                nUsuarios.Insertar(Usuario)
                MsgBox("Usuario guardado exitosamente.", MsgBoxStyle.Information, "Exito")
            Else
                Usuario.IdUsuario = Usuario.IdUsuario
                nUsuarios.Actualizar(Usuario)
                MsgBox("Usuario actualizado exitosamente.", MsgBoxStyle.Information, "Exito")
            End If
            ActualizarDgv()
            HabilitarListado()
        Catch ex As Exception
            ManejarErrores.Mostrar(If(esNuevo, "Error al guardar usuario: ", "Error al actualizar usuario: "), ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Cancelar". Vuelve a la vista de listado de usuarios.
    ''' </summary>
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            HabilitarListado()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cancelar la operación", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el icono para mostrar u ocultar la contraseña. Cambia la visibilidad del campo de contraseña.
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
            ManejarErrores.Mostrar("Error al mostrar contraseña", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar el texto en el campo de búsqueda de usuarios.
    ''' - Si la opción seleccionada en el ComboBox de búsqueda es la de buscar por nombre (índice 0), 
    ''' filtra los usuarios utilizando <see cref="NUsuarios.ListarPorNombre"/> con el texto ingresado.
    ''' - Actualiza el DataGridView con los resultados llamando a <see cref="ActualizarDgv"/>.
    ''' </summary>
    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            If cbOpcionBuscar.SelectedIndex = 0 Then
                ActualizarDgv(nUsuarios.ListarPorNombre(tbBuscar.Text))
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al buscar usuario", ex)
        End Try
    End Sub

    ''' Evento que se ejecuta al hacer clic en el botón "Eliminar" en el formulario de usuarios.
    ''' - Verifica si hay una fila seleccionada en el DataGridView de usuarios.
    '''   - Si hay una fila seleccionada:
    '''     - Obtiene el ID del usuario seleccionado.
    '''     - Solicita confirmación al usuario mediante un cuadro de diálogo.
    '''     - Si el usuario confirma la eliminación:
    '''         - Llama al método <see cref="NUsuarios.Eliminar"/> de la capa de negocio para eliminar el usuario.
    '''         - Actualiza el listado de usuarios en el DataGridView llamando a <see cref="ActualizarDgv"/>.
    '''         - Muestra un mensaje de éxito.
    '''   - Si no hay ninguna fila seleccionada: lanza excepción.
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                Dim idUsuario As UInteger = CInt(selectedRow.Cells("id_usuario").Value)

                Dim confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar este Usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    nUsuarios.Eliminar(idUsuario)

                    ActualizarDgv()
                    MsgBox("Usuario eliminado exitosamente.", MsgBoxStyle.Information, "Exito")
                End If
            Else
                Throw New Exception("No se seleccionó ningún usuario para eliminar.")
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al eliminar el usuario", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón o icono de "Reiniciar" en el formulario de usuarios.
    ''' - Limpia el campo de búsqueda de usuarios (<see cref="tbBuscar"/>), eliminando cualquier texto ingresado por el usuario.
    ''' - Actualiza el listado usuarios llamando a <see cref="ActualizarDgv"/>, mostrando nuevamente la lista completa de usuarios sin filtros.
    ''' </summary>
    Private Sub pbReiniciar_Click(sender As Object, e As EventArgs) Handles pbReiniciar.Click
        Try
            tbBuscar.Clear()
            ActualizarDgv()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al reiniciar la búsqueda", ex)
        End Try
    End Sub

End Class
