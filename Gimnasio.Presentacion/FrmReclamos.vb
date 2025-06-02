Imports Gimnasio.Negocio
Imports Gimnasio.Entidades
Imports Gimnasio.Errores

''' <summary>
''' Formulario para la gestión de reclamos en el sistema del gimnasio.
''' Permite listar, buscar, agregar, actualizar, responder, cambiar estado y eliminar reclamos.
''' Utiliza la clase <see cref="NReclamos"/> para la lógica de negocio y la clase <see cref="Reclamos"/> como entidad.
''' Todas las operaciones de esta capa están envueltas en bloques Try...Catch. 
''' El manejo de errores se realiza a través de <see cref="Gimnasio.Errores.ManejarErrores.Mostrar(String, Exception)"/>
''' que permite guardar el error en un log.txt y a su vez mostrar un mensaje al usuario.
''' </summary>
''' <remarks>
''' Todas las operaciones de esta capa están envueltas en bloques Try...Catch. 
''' El manejo de errores se realiza a través de <see cref="Gimnasio.Errores.ManejarErrores.Mostrar(String, Exception)"/>
''' que permite guardar el error en un log.txt y a su vez mostrar un mensaje al usuario.
''' </remarks>
Public Class FrmReclamos
    ''' <summary>
    ''' Instancia de la capa de negocio para reclamos.
    ''' </summary>
    Private nReclamos As New NReclamos()
    ''' <summary>
    ''' Indica si la operación actual es de inserción (<c>True</c>) o actualización (<c>False</c>).
    ''' </summary>
    Private esNuevo As Boolean

    ''' <summary>
    ''' Constructor del formulario de reclamos. Inicializa los componentes del formulario.
    ''' Si el rol del usuario es 2 (recepcionista), oculta los botones de eliminar, cambiar estado y responder.
    ''' </summary>
    ''' <param name="usuario">Instancia de <see cref="Usuarios"/> que representa al usuario logueado.</param>
    Friend Sub New(usuario As Usuarios)
        InitializeComponent()
        If usuario.IdRol = 2 Then
            btnEliminar.Visible = False
            btnEliminar.Enabled = False
            btnCambiarEstado.Visible = False
            btnCambiarEstado.Enabled = False
            btnResponder.Visible = False
            btnResponder.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cargar el formulario.
    ''' Inicializa el listado de reclamos, configura las columnas del DataGridView y selecciona la 1° opción del ComboBox.
    ''' </summary>
    Private Sub frmReclamos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDgv()
            dgvListado.Columns(0).Visible = False
            dgvListado.Columns(0).HeaderText = "ID RECLAMO"
            dgvListado.Columns(1).HeaderText = "TIPO"
            dgvListado.Columns(2).HeaderText = "DESCRIPCION"
            dgvListado.Columns(3).HeaderText = "FECHA ENVIO"
            dgvListado.Columns(4).HeaderText = "ESTADO"
            dgvListado.Columns(5).HeaderText = "RESPUESTA"
            dgvListado.Columns(6).HeaderText = "FECHA RESPUESTA"
            dgvListado.Columns(7).HeaderText = "DNI MIEMBRO"
            cbOpcionBuscar.SelectedIndex = 0
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar pestaña de reclamos", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el DataGridView con la lista de reclamos obtenida desde la capa de negocio mediante <see cref="NReclamos.Listar"/>.
    ''' - Obtiene todos los reclamos registrados en el sistema y los asigna como origen de datos del DataGridView.
    ''' - Actualiza la etiqueta lblTotal mostrando la cantidad total de reclamos listados.
    ''' </summary>
    Public Sub ActualizarDgv()
        Try
            Dim dvReclamos As DataTable = nReclamos.Listar()
            dgvListado.DataSource = dvReclamos
            lblTotal.Text = "Total Reclamos: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar reclamos", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el DataGridView con una lista específica de reclamos proporcionada como parámetro.
    ''' - Asigna el DataTable recibido Listado como origen de datos del DataGridView.
    ''' - Actualiza la etiqueta lblTotal mostrando la cantidad total de reclamos listados en el DataGridView.
    ''' </summary>
    ''' <param name="Listado">DataTable que contiene la lista de reclamos a mostrar en el DataGridView.</param>
    Public Sub ActualizarDgv(Listado As DataTable)
        Try
            Dim dvReclamos As DataTable = Listado
            dgvListado.DataSource = dvReclamos
            lblTotal.Text = "Total Reclamos: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar reclamos", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Habilita la vista de listado de reclamos y oculta los paneles de ingreso y respuesta.
    ''' </summary>
    Public Sub HabilitarListado()
        Try
            panelListado.Enabled = True
            panelDatosIngreso.Visible = False
            panelRespuestaIngreso.Visible = False
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al habilitar listado", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Muestra el panel de datos de ingreso y lo ajusta para ocupar todo el espacio disponible.
    ''' Deshabilita el panel de listado para evitar la interacción mientras se realiza el ingreso o edición.
    ''' Selecciona la primera opción del ComboBox de tipo de reclamo.
    ''' Limpia los campos de descripción, DNI y respuesta para asegurar que no contengan datos previos.
    ''' </summary>
    Public Sub HabilitarIngreso()
        Try
            panelDatosIngreso.Visible = True
            panelDatosIngreso.Dock = DockStyle.Fill
            panelListado.Enabled = False
            cbTipo.SelectedIndex = 0
            tbDescripcion.Clear()
            tbDNI.Clear()
            TbRespuesta.Clear()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al habilitar ingreso", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Muestra el panel de respuesta y lo ajusta para ocupar todo el espacio disponible en el formulario.
    ''' Deshabilita el panel de listado para evitar la interacción con la lista de reclamos mientras se ingresa la respuesta.
    ''' Limpia el campo de texto de respuesta para asegurar que no contenga datos previos.
    ''' </summary>
    Public Sub HabilitarRespuesta()
        Try
            panelRespuestaIngreso.Visible = True
            panelRespuestaIngreso.Dock = DockStyle.Fill
            panelListado.Enabled = False
            TbRespuesta.Clear()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al habilitar respuesta", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Insertar".
    ''' - Habilita el panel de ingreso para permitir la carga de un nuevo reclamo mediante <see cref="HabilitarIngreso"/>.
    ''' - Cambia el texto de la etiqueta lblDatosIngreso a "Nuevo reclamo" para indicar la acción al usuario.
    ''' - Establece la variable esNuevo en True para señalar que la siguiente operación será una inserción.
    ''' </summary>
    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Try
            HabilitarIngreso()
            lblDatosIngreso.Text = "Nuevo reclamo"
            esNuevo = True
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de inserción", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Actualizar".
    ''' - Verifica si hay una fila seleccionada en el DataGridView de reclamos.
    ''' - Si hay selección, habilita el panel de ingreso mediante <see cref="HabilitarIngreso"/> para editar el reclamo.
    ''' - Establece la variable esNuevo en False para indicar que la operación es una actualización.
    ''' - Carga en los controles de ingreso los datos del reclamo seleccionado (ID, tipo y descripción).
    ''' - Cambia el texto de la etiqueta lblDatosIngreso a "Actualizar Reclamo" para informar al usuario.
    ''' - Si no hay selección, lanza una excepción.
    ''' </summary>
    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                HabilitarIngreso()
                esNuevo = False
                tbID.Text = selectedRow.Cells("id_reclamos").Value.ToString
                cbTipo.Text = selectedRow.Cells("tipo").Value.ToString
                tbDescripcion.Text = selectedRow.Cells("descripcion").Value.ToString
                tbDNI.Text = selectedRow.Cells("dni_miembro").Value.ToString
                lblDatosIngreso.Text = "Actualizar Reclamo"
            Else
                Throw New Exception("No se ha seleccionado un reclamo para actualizar.")
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de actualización", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Responder".
    ''' - Verifica si hay una fila seleccionada en el DataGridView de reclamos.
    ''' - Si hay selección, habilita el panel de respuesta mediante <see cref="HabilitarRespuesta"/> para permitir ingresar o modificar la respuesta.
    ''' - Carga en los controles de respuesta el ID y la respuesta actual del reclamo seleccionado.
    ''' - Si no hay selección, lanza una excepción
    ''' </summary>
    Private Sub btnResponder_Click(sender As Object, e As EventArgs) Handles btnResponder.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                HabilitarRespuesta()
                tbID.Text = selectedRow.Cells("id_reclamos").Value.ToString
                TbRespuesta.Text = selectedRow.Cells("respuesta").Value.ToString
            Else
                Throw New Exception("No se ha seleccionado un reclamo para responder.")
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de actualización", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Guardar".
    ''' - Valida que los campos obligatorios de tipo y descripción estén completos; si no, lanza una excepción.
    ''' - Crea una instancia de <see cref="Reclamos"/> y asigna los valores de los controles del formulario.
    ''' - Si se ingresó un DNI, busca el miembro correspondiente usando <see cref="NMiembros.ObtenerPorDni"/> y asigna su ID al reclamo; 
    ''' - Si no se encuentra, lanza una excepción. Y si no se ingreso un DNI asigna Nothing al IdMiembro
    ''' - Si la operación es de inserción, utiliza <see cref="NReclamos.Insertar"/> para agregar el reclamo y muestra un mensaje de éxito.
    ''' - Si la operación es de actualización, asigna el ID del reclamo y utiliza <see cref="NReclamos.Actualizar"/>, mostrando un mensaje de éxito.
    ''' - Actualiza el listado de reclamos mediante <see cref="ActualizarDgv"/> y vuelve a la vista de listado con <see cref="HabilitarListado"/>.
    ''' </summary>
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If String.IsNullOrWhiteSpace(cbTipo.Text) OrElse String.IsNullOrWhiteSpace(tbDescripcion.Text) Then
                Throw New Exception("Complete los campos obligatorios (*).")
            End If
            Dim reclamo As New Reclamos()
            reclamo.Tipo = cbTipo.Text
            reclamo.Descripcion = tbDescripcion.Text
            Dim nmiembro As New NMiembros()
            If tbDNI.Text.ToString IsNot "" Then
                Dim tmiembro As DataTable = nmiembro.ObtenerPorDni(tbDNI.Text)
                If tmiembro.Rows.Count > 0 Then
                    reclamo.IdMiembro = CUInt(tmiembro.Rows(0)("id_miembro"))
                Else
                    Throw New Exception("El DNI no ha sido encontrado")
                End If
            End If
            If tbDNI.Text.ToString Is "" Then
                reclamo.IdMiembro = Nothing
            End If
            If esNuevo Then

                nReclamos.Insertar(reclamo)
                MsgBox("Reclamo agregado exitosamente.", MsgBoxStyle.Information, "Exito")
                ActualizarDgv()
            Else
                reclamo.IdReclamos = CUInt(tbID.Text.ToString)
                nReclamos.Actualizar(reclamo)
                MsgBox("Reclamo actualizado exitosamente.", MsgBoxStyle.Information, "Exito")
                ActualizarDgv()
            End If
            HabilitarListado()
        Catch ex As Exception
            ManejarErrores.Mostrar(If(esNuevo, "Error al guardar reclamo: ", "Error al actualizar reclamo: "), ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Guardar Respuesta".
    ''' - Valida que el campo de respuesta no esté vacío; si no lanza una excepción
    ''' - Crea una instancia de <see cref="Reclamos"/> y asigna la respuesta y el ID del reclamo seleccionado.
    ''' - Utiliza <see cref="NReclamos.ActualizarRespuesta"/> para actualizar la respuesta del reclamo en la base de datos.
    ''' - Muestra un mensaje de éxito al usuario.
    ''' - Actualiza el listado de reclamos mediante <see cref="ActualizarDgv"/> y vuelve a la vista de listado con <see cref="HabilitarListado"/>.
    ''' </summary>
    Private Sub tbGuardarRespuesta_Click(sender As Object, e As EventArgs) Handles tbGuardarRespuesta.Click
        Try
            If String.IsNullOrEmpty(TbRespuesta.Text.ToString) Then
                Throw New Exception("La respuesta no puede estar vacía.")
            Else
                Dim reclamoPorActualizar As New Reclamos()
                reclamoPorActualizar.Respuesta = TbRespuesta.Text.ToString
                reclamoPorActualizar.IdReclamos = CUInt(tbID.Text.ToString)
                nReclamos.ActualizarRespuesta(reclamoPorActualizar)
                MsgBox("Reclamo respondido exitosamente.", MsgBoxStyle.Information, "Exito")
                ActualizarDgv()
                HabilitarListado()
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al guardar la respuesta", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Cancelar". Vuelve a la vista de listado de reclamos.
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
    ''' - Verifica si hay una fila seleccionada en el DataGridView de reclamos.
    ''' - Si hay selección, obtiene el ID del reclamo seleccionado y solicita confirmación al usuario mediante un cuadro de diálogo.
    ''' - Si el usuario confirma, utiliza <see cref="NReclamos.Eliminar"/> para eliminar el reclamo de la base de datos.
    ''' - Actualiza el listado de reclamos en el DataGridView mediante <see cref="ActualizarDgv"/> y muestra un mensaje de éxito.
    ''' - Si no hay selección, lanza una excepción.
    ''' </summary>
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                Dim idReclamo As UInteger = selectedRow.Cells("id_reclamos").Value

                Dim confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar este reclamo?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    nReclamos.Eliminar(idReclamo)
                    ActualizarDgv()
                    MsgBox("Reclamo eliminado exitosamente.", MsgBoxStyle.Information, "Exito")
                End If
            Else
                Throw New Exception("No se ha seleccionado un reclamo para eliminar.")
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al eliminar reclamo", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar la opción seleccionada en el ComboBox de búsqueda de reclamos.
    ''' - Filtra el listado de reclamos mostrado en el DataGridView según el estado seleccionado en el ComboBox (todos, pendiente o resuelto).
    ''' - Utiliza una estructura Select Case para determinar el filtro:
    '''   - Opción 0: muestra todos los reclamos llamando a <see cref="ActualizarDgv"/>.
    '''   - Opción 1: muestra solo los reclamos pendientes llamando a <see cref="NReclamos.ListarPorEstado"/> con el parámetro "pendiente".
    '''   - Opción 2: muestra solo los reclamos resueltos llamando a <see cref="NReclamos.ListarPorEstado"/> con el parámetro "resuelto".
    ''' - Actualiza el DataGridView con el resultado correspondiente.
    ''' </summary>
    Private Sub cb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOpcionBuscar.SelectedIndexChanged
        Try
            Select Case cbOpcionBuscar.SelectedIndex
                Case 0
                    ActualizarDgv()
                Case 1
                    ActualizarDgv(nReclamos.ListarPorEstado("pendiente"))
                Case 2
                    ActualizarDgv(nReclamos.ListarPorEstado("resuelto"))
            End Select
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al buscar reclamos", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Cambiar Estado".
    ''' - Verifica si hay una fila seleccionada en el DataGridView de reclamos.
    ''' - Si hay selección, obtiene el ID y el estado actual del reclamo seleccionado.
    ''' - Si el estado es "pendiente", utiliza <see cref="NReclamos.ActualizarElEstadoAResuelto"/> para cambiarlo a "resuelto" y muestra un mensaje de confirmación.
    ''' - Si el estado es "resuelto", utiliza <see cref="NReclamos.ActualizarElEstadoAPendiente"/> para cambiarlo a "pendiente" y muestra un mensaje de confirmación.
    ''' - Actualiza el listado con todos los reclamos mediante <see cref="Reiniciar"/>.
    ''' - Si no hay selección, lanza una excepción.
    ''' </summary>
    Private Sub btnCambiarEstado_Click(sender As Object, e As EventArgs) Handles btnCambiarEstado.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                Dim idReclamo As UInteger = CInt(selectedRow.Cells("id_reclamos").Value)
                Dim estadoActual = selectedRow.Cells("estado").Value.ToString

                If estadoActual = "pendiente" Then
                    nReclamos.ActualizarElEstadoAResuelto(idReclamo)
                    MsgBox("El estado del reclamo ha sido cambiado a 'resuelto'.", MsgBoxStyle.Information, "Estado actualizado")
                ElseIf estadoActual = "resuelto" Then
                    nReclamos.ActualizarElEstadoAPendiente(idReclamo)
                    MsgBox("El estado del reclamo ha sido cambiado a 'pendiente'.", MsgBoxStyle.Information, "Estado actualizado")
                End If
                ActualizarDgv()
            Else
                Throw New Exception("No se ha seleccionado un reclamo para cambiar su estado.")
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cambiar el estado del reclamo", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Cancelar Respuesta". Vuelve a la vista de listado de reclamos.
    ''' </summary>
    Private Sub tbCancelarRespuesta_Click(sender As Object, e As EventArgs) Handles tbCancelarRespuesta.Click
        Try
            HabilitarListado()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cancelar respuesta", ex)
        End Try
    End Sub


    ''' <summary>
    ''' Restablece el formulario de reclamos a su estado inicial.
    ''' - Selecciona la primera opción del ComboBox de búsqueda, mostrando todos los reclamos en el listado.
    ''' </summary>
    Public Sub Reiniciar()
        Try
            cbOpcionBuscar.SelectedIndex = 0
            ActualizarDgv()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al reiniciar el formulario de reclamos", ex)
        End Try
    End Sub

    '''<summary>
    ''' Evento que se ejecuta al hacer clic en el boton "Reiniciar". Llama a <see cref="Reiniciar"/> 
    '''</summary>
    Private Sub pbReiniciar_Click(sender As Object, e As EventArgs) Handles pbReiniciar.Click
        Try
            Reiniciar()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al reiniciar", ex)
        End Try
    End Sub
End Class
