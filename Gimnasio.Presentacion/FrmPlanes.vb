Imports Gimnasio.Negocio
Imports Gimnasio.Entidades
Imports LogDeErrores

''' <summary>
''' Formulario para la gestión de planes en el sistema de gimnasio.
''' Permite listar, buscar, agregar, actualizar y eliminar planes.
''' </summary>
''' <remarks>
''' Utiliza la clase <see cref="NPlanes"/> para la lógica de negocio y la clase <see cref="Planes"/> como entidad.
''' El acceso a las operaciones de mantenimiento depende del rol del usuario (<see cref="Usuarios"/>).
''' </remarks>
Public Class FrmPlanes
    ''' <summary>
    ''' Instancia de la capa de negocio para planes.
    ''' </summary>
    Private ReadOnly nPlanes As New NPlanes()
    ''' <summary>
    ''' Indica si la operación actual es de inserción (<c>True</c>) o actualización (<c>False</c>).
    ''' </summary>
    Private esNuevo As Boolean
    ''' <summary>
    ''' Plan seleccionado para actualizar.
    ''' </summary>
    Private planPorActualizar As Planes

    ''' <summary>
    ''' Constructor del formulario de planes.
    ''' Configura la interfaz según el rol del usuario.
    ''' </summary>
    ''' <param name="usuario">Instancia de <see cref="Usuarios"/> que representa al usuario logueado.</param>
    Sub New(usuario As Usuarios)
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
    ''' Evento que se ejecuta al cargar el formulario.
    ''' Inicializa el listado de planes y configura las columnas del <see cref="DataGridView"/>.
    ''' </summary>
    Private Sub frmPlanes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()
            dgvListado.Columns(0).Visible = False
            dgvListado.Columns(1).HeaderText = "Nombre del Plan"
            dgvListado.Columns(2).HeaderText = "Descripción"
            dgvListado.Columns(3).HeaderText = "Duración"
            dgvListado.Columns(4).HeaderText = "Precio"
            dgvListado.Columns(5).HeaderText = "Fecha de Creación"
            dgvListado.Columns(6).HeaderText = "Última Modificación"
            cbOpcionBuscar.SelectedIndex = 0
        Catch ex As Exception
            Logger.LogError("Capa Presentación", ex)
            MsgBox("Error al cargar pestaña de planes", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el <see cref="DataGridView"/> con la lista de planes obtenida desde <see cref="NPlanes.Listar"/>.
    ''' </summary>
    Public Sub ActualizarDataGridView()
        Try
            dgvListado.DataSource = nPlanes.Listar()
            lblTotal.Text = "Total Planes: " & dgvListado.Rows.Count
        Catch ex As Exception
            Logger.LogError("Capa Presentación", ex)
            MsgBox("Error al cargar los planes", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Habilita la vista de listado de planes y oculta el panel de ingreso de datos.
    ''' </summary>
    Public Sub HabilitarListado()
        panelDatosIngreso.Visible = False
        panelListado.Enabled = True
    End Sub

    ''' <summary>
    ''' Habilita el panel de ingreso de datos para agregar o actualizar un plan.
    ''' Limpia los campos de entrada.
    ''' </summary>
    Public Sub HabilitarIngreso()
        panelDatosIngreso.Visible = True
        panelDatosIngreso.Dock = DockStyle.Fill
        panelListado.Enabled = False
        tbNombre.Clear()
        tbDescripcion.Clear()
        tbDuracion.Clear()
        tbPrecio.Clear()
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Insertar".
    ''' Habilita el panel de ingreso para agregar un nuevo plan.
    ''' </summary>
    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Try
            HabilitarIngreso()
            esNuevo = True
            lblDatosIngreso.Text = "Agregar Plan"
        Catch ex As Exception
            Logger.LogError("Capa Presentación", ex)
            MsgBox("Error al abrir el formulario de inserción", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Actualizar".
    ''' Carga los datos del plan seleccionado en el panel de ingreso para su edición.
    ''' </summary>
    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)

                planPorActualizar = New Planes
                planPorActualizar.IdPlan = CUInt(selectedRow.Cells("id_plan").Value)
                planPorActualizar.NombrePlan = selectedRow.Cells("nombre_plan").Value.ToString()
                planPorActualizar.Descripcion = selectedRow.Cells("descripcion").Value.ToString()
                planPorActualizar.DuracionDias = CUInt(selectedRow.Cells("duracion_dias").Value)
                planPorActualizar.Precio = CDec(selectedRow.Cells("precio").Value)

                esNuevo = False
                HabilitarIngreso()
                tbNombre.Text = planPorActualizar.NombrePlan
                tbDescripcion.Text = planPorActualizar.Descripcion
                tbDuracion.Text = planPorActualizar.DuracionDias.ToString()
                tbPrecio.Text = planPorActualizar.Precio.ToString()
                lblDatosIngreso.Text = "Actualizar Plan"
            Else
                MsgBox("Seleccione un plan para actualizar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentación", ex)
            MsgBox("Error al seleccionar el plan", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Guardar".
    ''' Inserta o actualiza un plan utilizando <see cref="NPlanes.Insertar"/> o <see cref="NPlanes.Actualizar"/>.
    ''' </summary>
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If String.IsNullOrWhiteSpace(tbNombre.Text) OrElse String.IsNullOrWhiteSpace(tbDuracion.Text) OrElse String.IsNullOrWhiteSpace(tbPrecio.Text) Then
                MsgBox("Por favor, complete los campos obligatorios (*).", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If
            If Not IsNumeric(tbDuracion.Text) OrElse CInt(tbDuracion.Text) <= 0 Then
                MsgBox("La duración debe ser un número entero positivo.", MsgBoxStyle.Exclamation, "Aviso")
                tbDuracion.Focus()
                Return
            End If
            If Not IsNumeric(tbPrecio.Text) OrElse CDec(tbPrecio.Text) < 0 Then
                MsgBox("El precio debe ser un número decimal positivo.", MsgBoxStyle.Exclamation, "Aviso")
                tbPrecio.Focus()
                Return
            End If

            If esNuevo Then
                Dim Plan As New Planes
                Plan.NombrePlan = tbNombre.Text
                Plan.Descripcion = tbDescripcion.Text
                Plan.DuracionDias = CUInt(tbDuracion.Text)
                Plan.Precio = CDec(tbPrecio.Text)
                nPlanes.Insertar(Plan)
                MsgBox("Plan agregado exitosamente.", MsgBoxStyle.Information, "Éxito")
                ActualizarDataGridView()
            Else
                planPorActualizar.NombrePlan = tbNombre.Text
                planPorActualizar.Descripcion = tbDescripcion.Text
                planPorActualizar.DuracionDias = CUInt(tbDuracion.Text)
                planPorActualizar.Precio = CDec(tbPrecio.Text)
                nPlanes.Actualizar(planPorActualizar)
                MsgBox("Plan actualizado exitosamente.", MsgBoxStyle.Information, "Éxito")
                ActualizarDataGridView()
            End If
            HabilitarListado()
        Catch ex As Exception
            Logger.LogError("Capa Presentación", ex)
            MsgBox(If(esNuevo, "Error al guardar plan", "Error al actualizar plan"), MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Cancelar".
    ''' Vuelve a la vista de listado de planes.
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
    ''' Elimina el plan seleccionado utilizando <see cref="NPlanes.Eliminar"/>.
    ''' </summary>
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                Dim idPlan As UInteger = CUInt(selectedRow.Cells("id_plan").Value)

                If MessageBox.Show("¿Está seguro de que desea eliminar este plan?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    nPlanes.Eliminar(idPlan)
                    ActualizarDataGridView()
                    MsgBox("Plan eliminado exitosamente.", MsgBoxStyle.Information, "Éxito")
                End If
            Else
                MsgBox("Seleccione un plan para eliminar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentación", ex)
            MsgBox("Error al eliminar el plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar el texto en el campo de búsqueda.
    ''' Realiza la búsqueda de planes por nombre utilizando <see cref="NPlanes.ListarPorNombre"/>.
    ''' </summary>
    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            If cbOpcionBuscar.SelectedIndex = 0 Then
                Dim dtPlanes = nPlanes.ListarPorNombre(tbBuscar.Text)
                dgvListado.DataSource = dtPlanes
                lblTotal.Text = "Total Planes: " & dgvListado.Rows.Count.ToString
                If dgvListado.Rows.Count = 0 Then
                    MsgBox("No se encontró ningún plan con ese criterio.", MsgBoxStyle.Information, "Sin resultados")
                    tbBuscar.Clear()
                    ActualizarDataGridView()
                End If
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentación", ex)
            MsgBox("Error al buscar plan:", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al presionar una tecla en el campo de búsqueda.
    ''' Permite buscar por duración o precio según la opción seleccionada utilizando <see cref="NPlanes.ListarPorDuracion"/> o <see cref="NPlanes.ListarPorPrecio"/>.
    ''' </summary>
    Private Sub tbBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles tbBuscar.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If cbOpcionBuscar.SelectedIndex = 1 Then
                    If Not IsNumeric(tbBuscar.Text) OrElse CInt(tbBuscar.Text) <= 0 Then
                        MsgBox("La duración debe ser numerica.", MsgBoxStyle.Exclamation, "Aviso")
                        tbBuscar.Clear()
                        Return
                    End If
                    Dim dtPlanes = nPlanes.ListarPorDuracion(CInt(tbBuscar.Text))
                    dgvListado.DataSource = dtPlanes
                    lblTotal.Text = "Total Planes: " & dgvListado.Rows.Count.ToString
                    BusquedaSinResultados()
                ElseIf cbOpcionBuscar.SelectedIndex = 2 Then
                    If Not IsNumeric(tbBuscar.Text) OrElse CInt(tbBuscar.Text) <= 0 Then
                        MsgBox("El precio debe ser numerico.", MsgBoxStyle.Exclamation, "Aviso")
                        tbBuscar.Clear()
                        Return
                    End If
                    Dim dtPlanes = nPlanes.ListarPorPrecio(tbBuscar.Text)
                    dgvListado.DataSource = dtPlanes
                    lblTotal.Text = "Total Planes: " & dgvListado.Rows.Count.ToString
                    BusquedaSinResultados()
                End If
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentación", ex)
            MsgBox("Error al buscar plan:", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Verifica si la búsqueda no devolvió resultados y muestra un mensaje al usuario.
    ''' </summary>
    ''' <remarks>
    ''' Se utiliza para mostrar un mensaje cuando no se encuentran planes según el criterio de búsqueda.
    ''' </remarks>
    Public Sub BusquedaSinResultados()
        Try
            If dgvListado.Rows.Count = 0 And Not String.IsNullOrEmpty(tbBuscar.Text) Then
                MsgBox("No se encontró ningún plan con ese criterio.", MsgBoxStyle.Information, "Sin resultados")
                tbBuscar.Clear()
                ActualizarDataGridView()
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentación", ex)
            MsgBox("Error al buscar los planes", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class