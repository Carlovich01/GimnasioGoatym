Imports Gimnasio.Entidades
Imports Gimnasio.Negocio
Imports LogDeErrores

''' <summary>
''' Formulario para la gestión de miembros en el sistema del gimnasio.
''' Permite listar, buscar, agregar, actualizar y eliminar miembros.
''' Utiliza la clase <see cref="NMiembros"/> para la lógica de negocio y la clase <see cref="Miembros"/> como entidad.
''' </summary>
Public Class FrmMiembros
    ''' <summary>
    ''' Instancia de la capa de negocio para miembros.
    ''' </summary>
    Private nMiembros As New NMiembros()
    ''' <summary>
    ''' Indica si la operación actual es de inserción (<c>True</c>) o actualización (<c>False</c>).
    ''' </summary>
    Private esNuevo As Boolean
    ''' <summary>
    ''' Miembro seleccionado para actualizar.
    ''' </summary>
    Private miembroPorActualizar As Miembros
    ''' <summary>
    ''' Referencia al formulario principal para navegación y acceso al usuario actual.
    ''' </summary>
    Private frmPrincipal As FrmPrincipal

    ''' <summary>
    ''' Constructor del formulario de miembros.
    ''' </summary>
    ''' <param name="frmPrincipal">Instancia de <see cref="FrmPrincipal"/> para navegación y acceso al usuario actual.</param>
    Public Sub New(frmPrincipal As FrmPrincipal)
        InitializeComponent()
        Me.frmPrincipal = frmPrincipal
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cargar el formulario.
    ''' Inicializa el listado de miembros y configura las columnas del <see cref="DataGridView"/>.
    ''' </summary>
    Private Sub frmMiembros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()

            dgvListado.Columns(0).Visible = False
            dgvListado.Columns(1).HeaderText = "DNI"
            dgvListado.Columns(2).HeaderText = "Nombre"
            dgvListado.Columns(3).HeaderText = "Apellido"
            dgvListado.Columns(4).HeaderText = "Género"
            dgvListado.Columns(5).HeaderText = "Teléfono"
            dgvListado.Columns(6).HeaderText = "Email"
            dgvListado.Columns(7).HeaderText = "Fecha de Registro"
            dgvListado.Columns(8).HeaderText = "Última Modificación"

            cbOpcionBuscar.SelectedIndex = 0

        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al cargar pestaña de miembros: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el <see cref="DataGridView"/> con la lista de miembros obtenida desde <see cref="NMiembros.Listar"/>.
    ''' </summary>
    Public Sub ActualizarDataGridView()
        Try
            Dim dvMiembros As DataTable = nMiembros.Listar()
            dgvListado.DataSource = dvMiembros
            lblTotal.Text = "Total Miembros: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al cargar los miembros: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Habilita la vista de listado de miembros y oculta el panel de ingreso de datos.
    ''' </summary>
    Public Sub HabilitarListado()
        panelDatosIngreso.Visible = False
        panelListado.Enabled = True
    End Sub

    ''' <summary>
    ''' Habilita el panel de ingreso de datos para agregar o actualizar un miembro.
    ''' Limpia los campos de entrada.
    ''' </summary>
    Public Sub HabilitarIngreso()
        panelDatosIngreso.Visible = True
        panelDatosIngreso.Dock = DockStyle.Fill
        panelListado.Enabled = False
        tbNombre.Clear()
        tbDni.Clear()
        tbApellido.Clear()
        tbTelefono.Clear()
        tbEmail.Clear()
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Insertar".
    ''' Habilita el panel de ingreso para agregar un nuevo miembro.
    ''' </summary>
    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Try
            HabilitarIngreso()
            esNuevo = True
            lblDatosIngreso.Text = "Agregar Miembro"
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de inserción: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Actualizar".
    ''' Carga los datos del miembro seleccionado en el panel de ingreso para su edición.
    ''' </summary>
    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                miembroPorActualizar = New Miembros()
                miembroPorActualizar.IdMiembro = CUInt(selectedRow.Cells("id_miembro").Value)
                miembroPorActualizar.Dni = selectedRow.Cells("dni").Value.ToString
                miembroPorActualizar.Nombre = selectedRow.Cells("nombre").Value.ToString
                miembroPorActualizar.Apellido = selectedRow.Cells("apellido").Value.ToString
                miembroPorActualizar.Genero = selectedRow.Cells("genero").Value.ToString
                miembroPorActualizar.Telefono = selectedRow.Cells("telefono").Value.ToString
                miembroPorActualizar.Email = selectedRow.Cells("email").Value.ToString

                esNuevo = False
                HabilitarIngreso()
                tbDni.Text = miembroPorActualizar.Dni
                tbNombre.Text = miembroPorActualizar.Nombre
                tbApellido.Text = miembroPorActualizar.Apellido
                cbGenero.SelectedItem = miembroPorActualizar.Genero
                tbTelefono.Text = miembroPorActualizar.Telefono
                tbEmail.Text = miembroPorActualizar.Email
                lblDatosIngreso.Text = "Actualizar Miembro"
            Else
                MsgBox("Seleccione un miembro para actualizar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al seleccionar el miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Guardar".
    ''' Inserta o actualiza un miembro utilizando <see cref="NMiembros.Insertar"/> o <see cref="NMiembros.Actualizar"/>.
    ''' Si se agrega un nuevo miembro, ofrece la opción de agregar una membresía.
    ''' </summary>
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If String.IsNullOrWhiteSpace(tbDni.Text) OrElse String.IsNullOrWhiteSpace(tbNombre.Text) OrElse String.IsNullOrWhiteSpace(tbApellido.Text) Then
                MsgBox("Por favor, complete los campos obligatorios (*).", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If

            If esNuevo Then
                Dim nuevoMiembro As New Miembros()
                nuevoMiembro.Dni = tbDni.Text
                nuevoMiembro.Nombre = tbNombre.Text
                nuevoMiembro.Apellido = tbApellido.Text
                If cbGenero.SelectedItem IsNot Nothing Then
                    nuevoMiembro.Genero = cbGenero.SelectedItem.ToString()
                End If
                nuevoMiembro.Telefono = tbTelefono.Text
                nuevoMiembro.Email = tbEmail.Text
                nMiembros.Insertar(nuevoMiembro)
                MsgBox("Miembro agregado exitosamente.", MsgBoxStyle.Information, "Exito")
                ActualizarDataGridView()

                Dim resultado = MessageBox.Show("¿Desea agregar una membresía para este miembro?", "Agregar Membresía", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resultado = DialogResult.Yes Then
                    Dim FrmMembresias As New FrmMembresias(frmPrincipal.obtenerUsuarioActual)
                    frmPrincipal.MostrarFormulario(FrmMembresias)
                    FrmMembresias.HabilitarIngresoConMiembro(nuevoMiembro.Dni)
                    Return
                End If
            Else
                miembroPorActualizar.Dni = tbDni.Text
                miembroPorActualizar.Nombre = tbNombre.Text
                miembroPorActualizar.Apellido = tbApellido.Text
                If cbGenero.SelectedItem IsNot Nothing Then
                    miembroPorActualizar.Genero = cbGenero.SelectedItem.ToString()
                End If
                miembroPorActualizar.Telefono = tbTelefono.Text
                miembroPorActualizar.Email = tbEmail.Text
                miembroPorActualizar.IdMiembro = Me.miembroPorActualizar.IdMiembro
                nMiembros.Actualizar(miembroPorActualizar)
                MsgBox("Miembro actualizado exitosamente.", MsgBoxStyle.Information, "Exito")
                ActualizarDataGridView()
            End If
            HabilitarListado()
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox(If(esNuevo, "Error al guardar miembro: " & ex.Message, "Error al actualizar miembro: " & ex.Message), MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Cancelar".
    ''' Vuelve a la vista de listado de miembros.
    ''' </summary>
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            HabilitarListado()
        Catch ex As Exception
            Logger.LogError("Capa Presentación", ex)
            MsgBox("Error al cancelar", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Eliminar".
    ''' Elimina el miembro seleccionado utilizando <see cref="NMiembros.Eliminar"/>.
    ''' </summary>
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                Dim idMiembro As UInteger = CInt(selectedRow.Cells("id_miembro").Value)

                Dim confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar este Miembro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    nMiembros.Eliminar(idMiembro)
                    ActualizarDataGridView()
                    MsgBox("Miembro eliminado exitosamente.", MsgBoxStyle.Information, "Exito")
                End If
            Else
                MsgBox("Seleccione un Miembro para eliminar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al eliminar el Miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar el texto en el campo de búsqueda.
    ''' Realiza la búsqueda de miembros por nombre o DNI utilizando <see cref="NMiembros.ListarPorNombre"/> o <see cref="NMiembros.ListarPorDni"/>.
    ''' </summary>
    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            If cbOpcionBuscar.SelectedIndex = 0 Then
                Dim dvMiembro = nMiembros.ListarPorNombre(tbBuscar.Text)
                dgvListado.DataSource = dvMiembro
                lblTotal.Text = "Total Miembros:" & dgvListado.Rows.Count.ToString
            ElseIf cbOpcionBuscar.SelectedIndex = 1 Then
                Dim dvMiembro = nMiembros.ListarPorDni(tbBuscar.Text)
                dgvListado.DataSource = dvMiembro
                lblTotal.Text = "Total Miembros:" & dgvListado.Rows.Count.ToString
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al buscar miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

End Class
