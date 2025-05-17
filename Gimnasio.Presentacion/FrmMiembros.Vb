Imports Gimnasio.Entidades
Imports Gimnasio.Negocio
Imports Gimnasio.Errores

''' <summary>
''' Formulario para la gestión de miembros en el sistema del gimnasio. Permite listar, buscar, agregar, actualizar y eliminar miembros.
''' Utiliza la clase <see cref="Gimnasio.Negocio.NMiembros"/> para la lógica de negocio y la clase <see cref="Gimnasio.Entidades.Miembros"/> como entidad.
''' Todas las operaciones de esta capa están envueltas en bloques Try...Catch. 
''' El manejo de errores se realiza a través de <see cref="Gimnasio.Errores.ManejarErrores.Mostrar(String, Exception)"/>
''' que permite guardar el error en un log.txt y a su vez mostrar un mensaje al usuario.
''' </summary>
Public Class FrmMiembros
    ''' <summary>
    ''' Instancia de la capa de negocio para miembros.
    ''' </summary>
    Private nMiembros As New NMiembros()

    ''' <summary>
    ''' Indica si la operación actual es de inserción (True) o actualización (False).
    ''' </summary>
    Private esNuevo As Boolean

    ''' <summary>
    ''' Referencia al formulario principal para cambiar a la pestaña de membresias y acceder al usuario actual.
    ''' </summary>
    Private frmPrincipal As FrmPrincipal

    ''' <summary>
    ''' Este constructor se utiliza para inicializar el formulario y establecer la referencia al formulario principal.
    ''' </summary>
    ''' <param name="frmPrincipal">Instancia de <see cref="Gimnasio.Presentacion.FrmPrincipal"/>.</param>
    Public Sub New(frmPrincipal As FrmPrincipal)
        InitializeComponent()
        Me.frmPrincipal = frmPrincipal
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cargar el formulario 
    ''' - Llama a <see cref="ActualizarDgv"/> para cargar y mostrar la lista completa de miembros en el DataGridView.
    ''' - Configura la visibilidad y los encabezados de las columnas del DataGridView para mostrar los datos relevantes de los miembros
    ''' - Establece la opción predeterminada del ComboBox de búsqueda en la primera opción (índice 0).
    ''' </summary>
    Private Sub frmMiembros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDgv()

            dgvListado.Columns(0).Visible = False
            dgvListado.Columns(1).HeaderText = "DNI"
            dgvListado.Columns(2).HeaderText = "NOMBRE"
            dgvListado.Columns(3).HeaderText = "APELLIDO"
            dgvListado.Columns(4).HeaderText = "GÉNERO"
            dgvListado.Columns(5).HeaderText = "TELÉFONO"
            dgvListado.Columns(6).HeaderText = "EMAIL"
            dgvListado.Columns(7).HeaderText = "FECHA DE REGISTRO"
            dgvListado.Columns(8).HeaderText = "ÚLTIMA MODIFICACIÓN"

            cbOpcionBuscar.SelectedIndex = 0

        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar la pestaña de miembros", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el DataGridView con la lista completa de miembros obtenida desde la capa de negocio con <see cref="nMiembros.Listar()"/> 
    ''' También actualiza la etiqueta con el total de miembros.
    ''' </summary>
    Public Sub ActualizarDgv()
        Try
            dgvListado.DataSource = nMiembros.Listar()
            lblTotal.Text = "Total Miembros: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar los miembros", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el DataGridView con un DataTable específico de miembros, por ejemplo, tras una búsqueda o filtrado.
    ''' También actualiza la etiqueta con el total de miembros.
    ''' </summary>
    ''' <param name="listado">es un DataTable con la información de los miembros a mostrar.</param>
    Public Sub ActualizarDgv(listado As DataTable)
        Try
            dgvListado.DataSource = listado
            lblTotal.Text = "Total Miembros: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar los miembros", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Habilita el panel de listado de miembros y oculta el panel de ingreso de datos.
    ''' </summary>
    Public Sub HabilitarListado()
        Try
            panelListado.Enabled = True
            panelDatosIngreso.Visible = False
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar los miembros", ex)
        End Try
    End Sub

    ''' <summary>
    ''' - Hace visible el panel de ingreso de datos y lo ajusta para ocupar todo el espacio disponible.
    ''' - Deshabilita el panel de listado de miembros para evitar la interacción con el listado mientras se está ingresando o editando un miembro.
    ''' - Limpia los campos de entrada para asegurar que no queden datos residuales de operaciones anteriores.
    ''' </summary>
    Public Sub HabilitarIngreso()
        Try
            panelDatosIngreso.Visible = True
        panelDatosIngreso.Dock = DockStyle.Fill
        panelListado.Enabled = False
        tbNombre.Clear()
        tbDni.Clear()
        tbApellido.Clear()
        tbTelefono.Clear()
            tbEmail.Clear()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al habilitar el ingreso de datos", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Insertar".
    ''' - Llama al método <see cref="HabilitarIngreso"/> para mostrar el panel de ingreso de datos.
    ''' - Establece la variable esNuevo en True para indicar que la operación es de alta.
    ''' - Cambia el texto del label a "Agregar Miembro" para informar al usuario el contexto de la operación.
    ''' </summary>
    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Try
            HabilitarIngreso()
            esNuevo = True
            lblDatosIngreso.Text = "Agregar Miembro"
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de inserción", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Actualizar".
    ''' - Verifica si hay una fila seleccionada en el DataGridView.
    '''   - Si hay una selección:
    '''     - Cambia el modo a edición estableciendo esNuevo en False.
    '''     - Llama a <see cref="HabilitarIngreso"/> para mostrar el panel de ingreso.
    '''     - Carga los datos del miembro seleccionado en los campos de entrada.
    '''     - Cambia el texto del label a "Actualizar Miembro" para indicar el contexto de edición.
    '''   - Si no hay selección, lanza una excepción indicando que no se ha seleccionado ningún miembro.
    ''' </summary>

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)

                esNuevo = False
                HabilitarIngreso()
                tbID.Text = selectedRow.Cells("id_miembro").Value
                tbDni.Text = selectedRow.Cells("dni").Value
                tbNombre.Text = selectedRow.Cells("nombre").Value
                tbApellido.Text = selectedRow.Cells("apellido").Value
                cbGenero.SelectedItem = selectedRow.Cells("genero").Value
                tbTelefono.Text = selectedRow.Cells("telefono").Value
                tbEmail.Text = selectedRow.Cells("email").Value
                lblDatosIngreso.Text = "Actualizar Miembro"
            Else
                Throw New Exception("No se ha seleccionado ningún miembro.")
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al seleccionar el miembro", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Guardar".
    ''' - Valida que los campos obligatorios (Dni, Nombre, Apellido) no estén vacíos.
    ''' - Si la validación falla, lanza una excepcion con el mensaje.
    ''' - Si las validaciones son correctas:
    '''   - Crea una instancia de <see cref="Miembros"/> y carga los datos desde los campos de entrada.
    '''   - Si esNuevo es True:
    '''     - Utiliza <see cref="NMiembros.Insertar"/> para agregar el miembro y muestra un mensaje de éxito.
    '''     - Ofrece la opción de agregar una membresía al nuevo miembro. Si el usuario acepta, abre el formulario de membresías con 
    ''' <see cref="FrmPrincipal.MostrarFormulario(Form)"/> y llama con el DNI a <see cref="FrmMembresias.HabilitarIngresoConMiembro(String)"/>.
    '''   - Si esNuevo esFalse:
    '''     - Asigna el IdMiembro y utiliza <see cref="NMiembros.Actualizar"/> para modificar el miembro existente, mostrando un mensaje de éxito.
    '''   - Actualiza el listado de miembros llamando a <see cref="ActualizarDgv"/> y vuelve a la vista de listado con <see cref="HabilitarListado"/>.
    ''' </summary>
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If String.IsNullOrWhiteSpace(tbDni.Text) OrElse String.IsNullOrWhiteSpace(tbNombre.Text) OrElse String.IsNullOrWhiteSpace(tbApellido.Text) Then
                Throw New Exception("Los campos obligatorios (*) no pueden estar vacíos")
            End If

            Dim miembro As New Miembros()
            miembro.Dni = tbDni.Text
            miembro.Nombre = tbNombre.Text
            miembro.Apellido = tbApellido.Text
            If cbGenero.SelectedItem IsNot Nothing Then
                miembro.Genero = cbGenero.SelectedItem.ToString()
            End If
            miembro.Telefono = tbTelefono.Text
            miembro.Email = tbEmail.Text
            If esNuevo Then
                nMiembros.Insertar(miembro)
                MsgBox("Miembro agregado exitosamente.", MsgBoxStyle.Information, "Exito")
                Dim resultado = MessageBox.Show("¿Desea agregar una membresía para este miembro?", "Agregar Membresía", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resultado = DialogResult.Yes Then
                    Dim FrmMembresias As New FrmMembresias(frmPrincipal.obtenerUsuarioActual)
                    frmPrincipal.MostrarFormulario(FrmMembresias)
                    FrmMembresias.HabilitarIngresoConMiembro(miembro.Dni)
                    Return
                End If
            Else
                miembro.IdMiembro = CUInt(tbID.Text)
                nMiembros.Actualizar(miembro)
                MsgBox("Miembro actualizado exitosamente.", MsgBoxStyle.Information, "Exito")
            End If
            ActualizarDgv()
            HabilitarListado()
        Catch ex As Exception
            ManejarErrores.Mostrar(If(esNuevo, "Error al guardar miembro: ", "Error al actualizar miembro: "), ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Cancelar". Vuelve a la vista de listado de miembros.
    ''' </summary>
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            HabilitarListado()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cancelar", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Eliminar".
    ''' - Verifica si hay una fila seleccionada en el DataGridView.
    '''   - Si hay una selección:
    '''     - Obtiene el identificador del miembro id_miembro de la fila seleccionada.
    '''     - Solicita confirmación al usuario mediante un cuadro de diálogo.
    '''     - Si el usuario confirma, invoca <see cref="NMiembros.Eliminar"/> para eliminar el miembro.
    '''     - Actualiza el listado de miembros llamando a <see cref="ActualizarDgv"/> y muestra un mensaje de éxito.
    '''   - Si no hay ninguna fila seleccionada, lanza una excepción con un mensaje.
    ''' </summary>
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                Dim idMiembro As UInteger = CInt(selectedRow.Cells("id_miembro").Value)

                Dim confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar este Miembro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    nMiembros.Eliminar(idMiembro)
                    ActualizarDgv()
                    MsgBox("Miembro eliminado exitosamente.", MsgBoxStyle.Information, "Exito")
                End If
            Else
                MsgBox("Seleccione un Miembro para eliminar.", MsgBoxStyle.Exclamation, "Aviso")
                Throw New Exception("No se ha seleccionado ningún miembro.")
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al eliminar el miembro", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta cada vez que cambia el texto en el campo de búsqueda (<c>tbBuscar</c>).
    ''' - Si la opción seleccionada es "Nombre" (índice 0), busca miembros por nombre utilizando <see cref="NMiembros.ListarPorNombre"/> 
    ''' y actualiza el listado llamando a <see cref="ActualizarDgv(DataTable)"/>.
    ''' - Si la opción seleccionada es "DNI" (índice 1), busca miembros por DNI utilizando <see cref="NMiembros.ListarPorDni"/> 
    ''' y actualiza el listado llamando a <see cref="ActualizarDgv(DataTable)"/>.
    ''' </summary>
    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            If cbOpcionBuscar.SelectedIndex = 0 Then
                ActualizarDgv(nMiembros.ListarPorNombre(tbBuscar.Text))
            ElseIf cbOpcionBuscar.SelectedIndex = 1 Then
                ActualizarDgv(nMiembros.ListarPorDni(tbBuscar.Text))
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al buscar miembro", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Al cambiar de opción del ComboBox limpia el campo de busqueda y actualiza al listado completo de miembros 
    ''' </summary>
    Private Sub cb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOpcionBuscar.SelectedIndexChanged
        Try
            tbBuscar.Clear()
            ActualizarDgv()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cambiar de opción", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Reiniciar". Limpia el campo de búsqueda y actualiza al listado completo de miembros.
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
