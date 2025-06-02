Imports Gimnasio.Negocio
Imports Gimnasio.Entidades
Imports Gimnasio.Errores

''' <summary>
''' Formulario para la gestión de planes en el sistema de gimnasio. Permite listar, buscar, insertar, actualizar y eliminar planes.
''' Utiliza la clase <see cref="Gimnasio.Negocio.NPlanes"/> para la lógica de negocio y la clase <see cref="Gimnasio.Entidades.Planes"/> como entidad.
''' El acceso a las operaciones de mantenimiento depende del rol del usuario (<see cref="Gimnasio.Entidades.Usuarios"/>).
''' </summary>
''' <remarks>
''' Todas las operaciones de esta capa están envueltas en bloques Try...Catch. 
''' El manejo de errores se realiza a través de <see cref="Gimnasio.Errores.ManejarErrores.Mostrar(String, Exception)"/>
''' que permite guardar el error en un log.txt y a su vez mostrar un mensaje al usuario.
''' </remarks>

Public Class FrmPlanes

    ''' <summary>
    ''' Instancia de la capa de negocio para planes.
    ''' </summary>
    Private ReadOnly nPlanes As New NPlanes()

    ''' <summary>
    ''' Indica si la operación actual es de inserción (True) o actualización (False).
    ''' </summary>
    Private esNuevo As Boolean

    ''' <summary>
    ''' Constructor del formulario. 
    ''' - Inicializa los componentes visuales.
    ''' - Si el usuario tiene el rol de Recepcionista (IdRol = 2), deshabilita y oculta los botones de insertar, actualizar y eliminar.
    ''' </summary>
    ''' <param name="usuario">Instancia de <see cref="Usuarios"/> que representa al usuario logueado.</param>

    Friend Sub New(usuario As Usuarios)
        InitializeComponent()
        If usuario.IdRol = 2 Then
            btnInsertar.Visible = False
            btnInsertar.Enabled = False
            btnActualizar.Visible = False
            btnActualizar.Enabled = False
            btnEliminar.Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cargar el formulario. Actualiza el listado de planes con <see cref="ActualizarDgv()"/>
    ''' configura las columnas del DataGridView y establece una opción de busqueda del ComboBox.
    ''' </summary>
    Private Sub frmPlanes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDgv()
            dgvListado.Columns(0).Visible = False
            dgvListado.Columns(1).HeaderText = "NOMBRE DEL PLAN"
            dgvListado.Columns(2).HeaderText = "DESCRIPCIÓN"
            dgvListado.Columns(3).HeaderText = "DURACIÓN"
            dgvListado.Columns(4).HeaderText = "PRECIO"
            dgvListado.Columns(5).HeaderText = "FECHA DE CREACIÓN"
            dgvListado.Columns(6).HeaderText = "ULTIMA MODIFICACIÓN"
            cbOpcionBuscar.SelectedIndex = 0
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar el formulario", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el DataGridView con la lista de planes completa obtenida de la capa de negocio con <see cref="NPlanes.Listar"/>.
    ''' También actualiza la etiqueta que muestra el total de planes.
    ''' </summary>
    Public Sub ActualizarDgv()
        Try
            dgvListado.DataSource = nPlanes.Listar()
            lblTotal.Text = "Total Planes: " & dgvListado.Rows.Count
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar los planes", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el DataGridView con un DataTable específico de planes, por ejemplo, tras una búsqueda o filtrado.
    ''' También actualiza la etiqueta con el total de miembros.
    ''' </summary>
    ''' <param name="listado">es un DataTable que contiene la lista de planes.</param>
    Public Sub ActualizarDgv(listado As DataTable)
        Try
            dgvListado.DataSource = listado
            lblTotal.Text = "Total Planes: " & dgvListado.Rows.Count
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar los planes", ex)
        End Try
    End Sub


    ''' <summary>
    ''' Habilita la vista de listado de planes y oculta el panel de ingreso de datos.
    ''' </summary>
    Public Sub HabilitarListado()
        Try
            panelListado.Enabled = True
            panelDatosIngreso.Visible = False
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al habilitar listado", ex)
        End Try
    End Sub

    ''' <summary>
    ''' - Hace visible el panel de ingreso de datos y lo ajusta para ocupar todo el espacio disponible.
    ''' - Deshabilita el panel de listado de planes para evitar la interacción con el listado mientras se está ingresando o editando un plan.
    ''' - Limpia los campos de entrada para asegurar que no queden datos residuales de operaciones anteriores.
    ''' </summary>
    Public Sub HabilitarIngreso()
        Try
            panelDatosIngreso.Visible = True
            panelDatosIngreso.Dock = DockStyle.Fill
            panelListado.Enabled = False
            tbNombre.Clear()
            tbDescripcion.Clear()
            tbDuracion.Clear()
            tbPrecio.Clear()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al habilitar ingreso", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Insertar".
    ''' - Habilita el panel de ingreso con <see cref="HabilitarIngreso"/>.
    ''' - Establece la variable esNuevo en True para indicar que la operación es de alta.
    ''' - Cambia el texto del label  a "Agregar Plan" para informar al usuario el contexto de la operación.
    ''' </summary>
    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Try
            HabilitarIngreso()
            esNuevo = True
            lblDatosIngreso.Text = "Agregar Plan"
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de inserción", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en "Actualizar". 
    ''' - Verifica si hay una fila seleccionada en el DataGridView.
    '''   - Si hay una selección:
    '''     - Cambia el modo a edición estableciendo esNuevo en False.
    '''     - Llama a <see cref="HabilitarIngreso"/> para mostrar el panel de ingreso.
    '''     - Carga los datos del plan seleccionado en los campos de entrada. Si es nulo lo carga como una cadena vacia.
    '''     - Cambia el texto del label a "Actualizar Plan" para indicar el contexto de edición.
    '''   - Si no hay selección, lanza una excepción indicando que no se ha seleccionado ningún plan.
    ''' </summary>

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)

                esNuevo = False
                HabilitarIngreso()

                tbID.Text = selectedRow.Cells("id_plan").Value
                tbNombre.Text = selectedRow.Cells("nombre_plan").Value
                tbDescripcion.Text = If(IsDBNull(selectedRow.Cells("descripcion").Value), "", selectedRow.Cells("descripcion").Value.ToString())
                tbDuracion.Text = selectedRow.Cells("duracion_dias").Value
                tbPrecio.Text = selectedRow.Cells("precio").Value
                lblDatosIngreso.Text = "Actualizar Plan"
            Else
                Throw New Exception("No se ha seleccionado ningun plan para actualizar.")
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al seleccionar el plan", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en "Guardar". 
    ''' - Valida que los campos obligatorios (Nombre, Duracion, Precio) no estén vacíos. Verifica que la duración y el precio sea un valor numérico y positivo.
    ''' - Si hay algún error en la validación, lanza una excepción con un mensaje descriptivo.
    ''' - Si las validaciones son correctas:
    '''   - Crea una instancia de <see cref="Planes"/> y carga los datos desde los campos de entrada.
    '''   - Si esNuevo es True, utiliza <see cref="NPlanes.Insertar"/> para agregar el plan y muestra un mensaje de éxito.
    '''   - Si esNuevo es False, utiliza <see cref="NPlanes.Actualizar"/> para modificar el plan existente y muestra un mensaje de éxito.
    '''   - Actualiza el listado de planes llamando a <see cref="ActualizarDgv"/> y vuelve a la vista de listado con <see cref="HabilitarListado"/>.
    ''' </summary>
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If String.IsNullOrWhiteSpace(tbNombre.Text) OrElse String.IsNullOrWhiteSpace(tbDuracion.Text) OrElse String.IsNullOrWhiteSpace(tbPrecio.Text) Then
                Throw New Exception("Los campos obligatorios (*) no pueden estar vacíos")
            End If
            If Not IsNumeric(tbDuracion.Text) OrElse CInt(tbDuracion.Text) <= 0 Then
                tbDuracion.Focus()
                Throw New Exception("La duración debe ser numerica y positiva.")
            End If
            If Not IsNumeric(tbPrecio.Text) OrElse CDec(tbPrecio.Text) < 0 Then
                tbPrecio.Focus()
                Throw New Exception("El precio debe ser numerico y postivo")
            End If

            Dim Plan As New Planes
            Plan.NombrePlan = tbNombre.Text
            Plan.Descripcion = tbDescripcion.Text
            Plan.DuracionDias = CUInt(tbDuracion.Text)
            Plan.Precio = CDec(tbPrecio.Text)
            If esNuevo Then
                nPlanes.Insertar(Plan)
                MsgBox("Plan agregado exitosamente.", MsgBoxStyle.Information, "Éxito")
            Else
                Plan.IdPlan = CUInt(tbID.Text)
                nPlanes.Actualizar(Plan)
                MsgBox("Plan actualizado exitosamente.", MsgBoxStyle.Information, "Éxito")
            End If
            ActualizarDgv()
            HabilitarListado()
        Catch ex As Exception
            ManejarErrores.Mostrar(If(esNuevo, "Error al guardar plan", "Error al actualizar plan"), ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Cancelar". Vuelve a la vista de listado de planes.
    ''' </summary>
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            HabilitarListado()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cancelar", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en "Eliminar". 
    ''' - Verifica si hay una fila seleccionada en el DataGridView. Si hay una selección:
    '''     - Obtiene el id_plan de la fila seleccionada.
    '''     - Solicita confirmación al usuario mediante un cuadro de diálogo.
    '''     - Si el usuario confirma, invoca <see cref="NPlanes.Eliminar"/> para eliminar el plan.
    '''     - Actualiza el listado de planes llamando a <see cref="ActualizarDgv"/> y muestra un mensaje de éxito.
    ''' - Si no hay selección, lanza una excepción indicando que no se ha seleccionado ningún plan.
    ''' </summary>
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                Dim idPlan As UInteger = CUInt(selectedRow.Cells("id_plan").Value)

                If MessageBox.Show("¿Está seguro de que desea eliminar este plan?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    nPlanes.Eliminar(idPlan)
                    ActualizarDgv()
                    MsgBox("Plan eliminado exitosamente.", MsgBoxStyle.Information, "Éxito")
                End If
            Else
                Throw New Exception("No se ha seleccionado ningun plan para eliminar.")
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al eliminar plan", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al modificar el texto del campo de búsqueda. 
    ''' - Si la opción seleccionada en el ComboBox es 0 (búsqueda por nombre), invoca <see cref="NPlanes.ListarPorNombre"/> 
    '''   pasando el texto ingresado y actualiza el listado de planes llamando a <see cref="ActualizarDgv(DataTable)"/>.
    ''' </summary>
    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            If cbOpcionBuscar.SelectedIndex = 0 Then
                ActualizarDgv(nPlanes.ListarPorNombre(tbBuscar.Text))
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al buscar plan", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar la opción seleccionada en el ComboBox de búsqueda. Se encarga de: 
    ''' - Limpiar el campo de búsqueda
    ''' - Actualiza el DataGridView con el listado completo de planes llamando a <see cref="ActualizarDgv()"/>.
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
    ''' Evento que se ejecuta al presionar una tecla en el campo de búsqueda.
    ''' - Si se presiona la tecla Enter y la opción seleccionada es 1 (búsqueda por duración):
    '''     - Valida que el texto ingresado sea numérico y positivo.
    '''     - Si la validación es correcta, invoca <see cref="NPlanes.ListarPorDuracion"/> y actualiza el DataGridView con los resultados.
    '''     - Si la validación falla, lanza una excepción con un mensaje descriptivo.
    ''' - Si se presiona la tecla Enter y la opción seleccionada es 2 (búsqueda por precio):
    '''     - Valida que el texto ingresado sea numérico y positivo.
    '''     - Si la validación es correcta, invoca <see cref="NPlanes.ListarPorPrecio"/> y actualiza el DataGridView con los resultados.
    '''     - Si la validación falla, lanza una excepción con un mensaje descriptivo.
    ''' </summary>
    Private Sub tbBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles tbBuscar.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Select Case cbOpcionBuscar.SelectedIndex
                    Case 1
                        If Not IsNumeric(tbBuscar.Text) OrElse CInt(tbBuscar.Text) <= 0 Then
                            Throw New Exception("La duración debe ser numerica positiva.")
                        End If
                        ActualizarDgv(nPlanes.ListarPorDuracion(CInt(tbBuscar.Text)))
                    Case 2
                        If Not IsNumeric(tbBuscar.Text) OrElse CInt(tbBuscar.Text) <= 0 Then
                            Throw New Exception("El precio debe ser numerico positivo.")
                        End If
                        ActualizarDgv(nPlanes.ListarPorPrecio(tbBuscar.Text))
                End Select
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al buscar plan", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el listado de planes y limpia el campo de busqueda.
    ''' </summary>
    Public Sub Reiniciar()
        Try
            tbBuscar.Clear()
            ActualizarDgv()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al reiniciar busqueda", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Reiniciar". LLama a <see cref="Reiniciar()"/>.
    ''' </summary>
    Private Sub pbReiniciar_Click(sender As Object, e As EventArgs) Handles pbReiniciar.Click
        Try
            Reiniciar()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al reiniciar busqueda", ex)
        End Try
    End Sub
End Class