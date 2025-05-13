Imports Gimnasio.Negocio
Imports Gimnasio.Entidades
Imports LogDeErrores

''' <summary>
''' Formulario para la gestión de reclamos en el sistema del gimnasio.
''' Permite listar, buscar, agregar, actualizar, responder, cambiar estado y eliminar reclamos.
''' Utiliza la clase <see cref="NReclamos"/> para la lógica de negocio y la clase <see cref="Reclamos"/> como entidad.
''' </summary>
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
    ''' Reclamo seleccionado para actualizar o responder.
    ''' </summary>
    Private reclamoPorActualizar As Reclamos

    ''' <summary>
    ''' Constructor del formulario de reclamos.
    ''' Configura la interfaz según el rol del usuario.
    ''' </summary>
    ''' <param name="usuario">Instancia de <see cref="Usuarios"/> que representa al usuario logueado.</param>
    Sub New(usuario As Usuarios)
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
    ''' Inicializa el listado de reclamos y configura las columnas del <see cref="DataGridView"/>.
    ''' </summary>
    Private Sub frmReclamos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()
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
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al cargar pestaña de reclamos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el <see cref="DataGridView"/> con la lista de reclamos obtenida desde <see cref="NReclamos.Listar"/>.
    ''' </summary>
    Public Sub ActualizarDataGridView()
        Try
            Dim dvReclamos As DataTable = nReclamos.Listar()
            dgvListado.DataSource = dvReclamos
            lblTotal.Text = "Total Reclamos: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al cargar los reclamos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Habilita la vista de listado de reclamos y oculta los paneles de ingreso y respuesta.
    ''' </summary>
    Public Sub HabilitarListado()
        panelDatosIngreso.Visible = False
        panelRespuestaIngreso.Visible = False
        panelListado.Enabled = True
    End Sub

    ''' <summary>
    ''' Habilita el panel de ingreso de datos para agregar o actualizar un reclamo.
    ''' Limpia los campos de entrada.
    ''' </summary>
    Public Sub HabilitarIngreso()
        panelDatosIngreso.Visible = True
        panelDatosIngreso.Dock = DockStyle.Fill
        panelListado.Enabled = False
        cbTipo.SelectedIndex = 0
        tbDescripcion.Clear()
        tbDNI.Clear()
        TbRespuesta.Clear()
    End Sub

    ''' <summary>
    ''' Habilita el panel de ingreso de respuesta para un reclamo.
    ''' </summary>
    Public Sub HabilitarRespuesta()
        panelRespuestaIngreso.Visible = True
        panelRespuestaIngreso.Dock = DockStyle.Fill
        panelListado.Enabled = False
        TbRespuesta.Clear()
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Insertar".
    ''' Habilita el panel de ingreso para agregar un nuevo reclamo.
    ''' </summary>
    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Try
            HabilitarIngreso()
            lblDatosIngreso.Text = "Nuevo reclamo"
            esNuevo = True
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de inserción: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Actualizar".
    ''' Carga los datos del reclamo seleccionado en el panel de ingreso para su edición.
    ''' </summary>
    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                reclamoPorActualizar = New Reclamos
                reclamoPorActualizar.IdReclamos = CUInt(selectedRow.Cells("id_reclamos").Value)
                reclamoPorActualizar.Tipo = selectedRow.Cells("tipo").Value.ToString
                reclamoPorActualizar.Descripcion = selectedRow.Cells("descripcion").Value.ToString
                HabilitarIngreso()
                esNuevo = False
                cbTipo.Text = reclamoPorActualizar.Tipo
                tbDescripcion.Text = reclamoPorActualizar.Descripcion
                lblDatosIngreso.Text = "Actualizar Reclamo"
            Else
                MsgBox("Seleccione un reclamo para actualizar.", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de actualización: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Responder".
    ''' Habilita el panel de respuesta para el reclamo seleccionado.
    ''' </summary>
    Private Sub btnResponder_Click(sender As Object, e As EventArgs) Handles btnResponder.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                reclamoPorActualizar = New Reclamos
                reclamoPorActualizar.IdReclamos = CUInt(selectedRow.Cells("id_reclamos").Value)
                reclamoPorActualizar.Respuesta = selectedRow.Cells("respuesta").Value.ToString
                HabilitarRespuesta()
                TbRespuesta.Text = reclamoPorActualizar.Respuesta
            Else
                MsgBox("Seleccione un reclamo para actualizar.", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de actualización: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Guardar".
    ''' Inserta o actualiza un reclamo utilizando <see cref="NReclamos.Insertar"/> o <see cref="NReclamos.Actualizar"/>.
    ''' </summary>
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If String.IsNullOrWhiteSpace(cbTipo.Text) OrElse String.IsNullOrWhiteSpace(tbDescripcion.Text) Then
                MsgBox("Por favor, complete los campos obligatorios (*).", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If
            If esNuevo Then
                Dim nuevoReclamo As New Reclamos()
                nuevoReclamo.Tipo = cbTipo.Text
                nuevoReclamo.Descripcion = tbDescripcion.Text
                Dim nmiembro As New NMiembros()
                If tbDNI.Text.ToString IsNot "" Then
                    Dim tmiembro As DataTable = nmiembro.ObtenerPorDni(tbDNI.Text)
                    If tmiembro.Rows.Count > 0 Then
                        nuevoReclamo.IdMiembro = Convert.ToUInt32(tmiembro.Rows(0)("id_miembro"))
                    Else
                        MsgBox("El DNI no ha sido encontrado.", MsgBoxStyle.Exclamation, "Aviso")
                    End If
                End If
                nReclamos.Insertar(nuevoReclamo)
                MsgBox("Reclamo agregado exitosamente.", MsgBoxStyle.Information, "Exito")
                ActualizarDataGridView()
            Else
                reclamoPorActualizar.Tipo = cbTipo.Text
                reclamoPorActualizar.Descripcion = tbDescripcion.Text
                Dim nmiembro As New NMiembros()
                If tbDNI.Text.ToString IsNot "" Then
                    Dim tmiembro As DataTable = nmiembro.ObtenerPorDni(tbDNI.Text)
                    If tmiembro.Rows.Count > 0 Then
                        reclamoPorActualizar.IdMiembro = Convert.ToUInt32(tmiembro.Rows(0)("id_miembro"))
                    Else
                        MsgBox("El DNI no ha sido encontrado.", MsgBoxStyle.Exclamation, "Aviso")
                    End If
                End If
                nReclamos.Actualizar(reclamoPorActualizar)
                MsgBox("Reclamo actualizado exitosamente.", MsgBoxStyle.Information, "Exito")
                ActualizarDataGridView()
            End If
            HabilitarListado()
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox(If(esNuevo, "Error al guardar reclamo: " & ex.Message, "Error al actualizar reclamo: " & ex.Message), MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Guardar Respuesta".
    ''' Actualiza la respuesta de un reclamo utilizando <see cref="NReclamos.ActualizarRespuesta"/>.
    ''' </summary>
    Private Sub tbGuardarRespuesta_Click(sender As Object, e As EventArgs) Handles tbGuardarRespuesta.Click
        Try
            If String.IsNullOrEmpty(TbRespuesta.Text.ToString) Then
                MsgBox("Por favor, complete la respuesta.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            Else
                reclamoPorActualizar.Respuesta = TbRespuesta.Text.ToString
                Dim nreclamos As New NReclamos()
                nreclamos.ActualizarRespuesta(reclamoPorActualizar)
                MsgBox("Reclamo respondido exitosamente.", MsgBoxStyle.Information, "Exito")
                ActualizarDataGridView()
                HabilitarListado()
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al guardar la respuesta: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Cancelar".
    ''' Vuelve a la vista de listado de reclamos.
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
    ''' Elimina el reclamo seleccionado utilizando <see cref="NReclamos.Eliminar"/>.
    ''' </summary>
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                Dim idReclamo As UInteger = selectedRow.Cells("id_reclamos").Value

                Dim confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar este reclamo?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    nReclamos.Eliminar(idReclamo)
                    ActualizarDataGridView()
                    MsgBox("Reclamo eliminado exitosamente.", MsgBoxStyle.Information, "Exito")
                End If
            Else
                MsgBox("Seleccione un reclamo para eliminar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al eliminar el reclamo: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar la opción de búsqueda.
    ''' Permite filtrar reclamos por estado utilizando <see cref="NReclamos.ListarPorEstado"/>.
    ''' </summary>
    Private Sub cbOpcionBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOpcionBuscar.SelectedIndexChanged
        Try
            Dim dvPlanes = nReclamos.ListarPorEstado(If(cbOpcionBuscar.SelectedIndex = 0, "pendiente", "resuelto"))
            dgvListado.DataSource = dvPlanes
            lblTotal.Text = "Total Reclamos: " & dgvListado.Rows.Count.ToString
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al buscar reclamos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Cambiar Estado".
    ''' Cambia el estado del reclamo seleccionado entre "pendiente" y "resuelto" utilizando <see cref="NReclamos.ActualizarElEstadoAResuelto"/> y <see cref="NReclamos.ActualizarElEstadoAPendiente"/>.
    ''' </summary>
    Private Sub btnCambiarEstado_Click(sender As Object, e As EventArgs) Handles btnCambiarEstado.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                Dim idReclamo As UInteger = CInt(selectedRow.Cells("id_reclamos").Value)
                Dim estadoActual = selectedRow.Cells("estado").Value.ToString.ToLower

                If estadoActual = "pendiente" Then
                    nReclamos.ActualizarElEstadoAResuelto(idReclamo)
                    MsgBox("El estado del reclamo ha sido cambiado a 'resuelto'.", MsgBoxStyle.Information, "Estado actualizado")
                ElseIf estadoActual = "resuelto" Then
                    nReclamos.ActualizarElEstadoAPendiente(idReclamo)
                    MsgBox("El estado del reclamo ha sido cambiado a 'pendiente'.", MsgBoxStyle.Information, "Estado actualizado")
                Else
                    MsgBox("El estado actual no es válido para cambiar.", MsgBoxStyle.Exclamation, "Advertencia")
                End If
                ActualizarDataGridView()
            Else
                MsgBox("Seleccione un reclamo para cambiar su estado.", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al cambiar el estado del reclamo: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Cancelar Respuesta".
    ''' Vuelve a la vista de listado de reclamos.
    ''' </summary>
    Private Sub tbCancelarRespuesta_Click(sender As Object, e As EventArgs) Handles tbCancelarRespuesta.Click
        Try
            HabilitarListado()
        Catch ex As Exception
            Logger.LogError("Capa Presentación", ex)
            MsgBox("Error al cancelar", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
