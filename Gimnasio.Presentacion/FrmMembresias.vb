Imports System.Numerics
Imports Gimnasio.Entidades
Imports Gimnasio.Negocio
Imports LogDeErrores

''' <summary>
''' Formulario para la gestión de membresías en el sistema del gimnasio.
''' Permite listar, buscar, agregar, actualizar, eliminar membresías y registrar pagos asociados.
''' Utiliza la clase <see cref="NMembresias"/> para la lógica de negocio y la clase <see cref="Membresias"/> como entidad.
''' </summary>
Public Class FrmMembresias
    ''' <summary>
    ''' Instancia de la capa de negocio para membresías.
    ''' </summary>
    Private nMembresias As New NMembresias()
    ''' <summary>
    ''' Instancia de la membresía seleccionada o en edición.
    ''' </summary>
    Private membresia As Membresias
    ''' <summary>
    ''' Usuario actualmente logueado, utilizado para registrar pagos.
    ''' </summary>
    Private usuarioActual As Usuarios
    ''' <summary>
    ''' Indica si la operación actual es de inserción (<c>True</c>) o actualización (<c>False</c>).
    ''' </summary>
    Private esNuevo As Boolean

    ''' <summary>
    ''' Constructor del formulario de membresías.
    ''' Configura la interfaz según el rol del usuario.
    ''' </summary>
    ''' <param name="usuario">Instancia de <see cref="Usuarios"/> que representa al usuario logueado.</param>
    Sub New(usuario As Usuarios)
        InitializeComponent()
        usuarioActual = usuario
        If usuarioActual.IdRol = 2 Then
            btnEliminar.Visible = False
            btnEliminar.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cargar el formulario.
    ''' Inicializa el listado de membresías y configura las columnas del <see cref="DataGridView"/>.
    ''' </summary>
    Private Sub frmMembresias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()

            dgvListado.Columns(0).Visible = False
            dgvListado.Columns(1).Visible = False
            dgvListado.Columns(2).Visible = False
            dgvListado.Columns(0).HeaderText = "ID MEMBRESIA"
            dgvListado.Columns(1).HeaderText = "ID MIEMBRO"
            dgvListado.Columns(2).HeaderText = "ID PLAN"
            dgvListado.Columns(3).HeaderText = "DNI MIEMBRO"
            dgvListado.Columns(4).HeaderText = "APELLIDO MIEMBRO"
            dgvListado.Columns(5).HeaderText = "NOMBRE MIEMBRO"
            dgvListado.Columns(6).HeaderText = "NOMBRE PLAN"
            dgvListado.Columns(7).HeaderText = "PRECIO PLAN"
            dgvListado.Columns(8).HeaderText = "DURACION PLAN"
            dgvListado.Columns(9).HeaderText = "FECHA INICIO"
            dgvListado.Columns(10).HeaderText = "FECHA FIN"
            dgvListado.Columns(11).HeaderText = "ESTADO"
            dgvListado.Columns(12).HeaderText = "FECHA REGISTRO"
            dgvListado.Columns(13).HeaderText = "ULTIMA MODIFICACION"

            cbOpcionBuscar.SelectedIndex = 0

        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al cargar la pestaña de membresias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el <see cref="DataGridView"/> con la lista de membresías obtenida desde <see cref="NMembresias.Listar"/>.
    ''' </summary>
    Public Sub ActualizarDataGridView()
        Try
            Dim dvMembresias As DataTable = nMembresias.Listar()
            dgvListado.DataSource = dvMembresias
            lblTotal.Text = "Total Membresias: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al cargar listado de membresias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Habilita la vista de listado de membresías y oculta los paneles de ingreso y pago.
    ''' </summary>
    Public Sub HabilitarListado()
        panelDatosIngreso.Visible = False
        panelPagoIngreso.Visible = False
        panelListado.Enabled = True
    End Sub

    ''' <summary>
    ''' Habilita el panel de ingreso de datos para agregar o actualizar una membresía.
    ''' Inicializa los listados de miembros y planes.
    ''' </summary>
    Public Sub HabilitarIngreso()
        panelDatosIngreso.Visible = True
        panelDatosIngreso.Dock = DockStyle.Fill
        panelListado.Enabled = False
        tbBuscarMiembro.Clear()
        tbBuscarPlan.Clear()

        Dim nMiembros As New NMiembros()
        Dim dtMiembros As DataTable = nMiembros.Listar()
        dgvMiembro.DataSource = dtMiembros
        dgvMiembro.Columns(0).Visible = False
        dgvMiembro.Columns(1).HeaderText = "DNI"
        dgvMiembro.Columns(2).HeaderText = "Nombre"
        dgvMiembro.Columns(3).HeaderText = "Apellido"
        dgvMiembro.Columns(4).HeaderText = "Género"
        dgvMiembro.Columns(5).HeaderText = "Teléfono"
        dgvMiembro.Columns(6).HeaderText = "Email"
        dgvMiembro.Columns(7).HeaderText = "Fecha de Registro"
        dgvMiembro.Columns(8).HeaderText = "Última Modificación"
        cbOpcionBuscarMiembro.SelectedIndex = 1

        Dim nPlan As New NPlanes()
        Dim dtPlanes As DataTable = nPlan.Listar()
        dgvPlan.DataSource = dtPlanes
        dgvPlan.Columns(0).Visible = False
        dgvPlan.Columns(1).HeaderText = "Nombre del Plan"
        dgvPlan.Columns(2).HeaderText = "Descripción"
        dgvPlan.Columns(3).HeaderText = "Duración"
        dgvPlan.Columns(4).HeaderText = "Precio"
        dgvPlan.Columns(5).HeaderText = "Fecha de Creación"
        dgvPlan.Columns(6).HeaderText = "Última Modificación"
        cbBuscarOpcionPlan.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Habilita el panel de ingreso de membresía con un miembro preseleccionado por DNI.
    ''' </summary>
    ''' <param name="dni">DNI del miembro a preseleccionar.</param>
    Public Sub HabilitarIngresoConMiembro(dni As String)
        HabilitarIngreso()
        tbBuscarMiembro.Text = dni
        tbBuscarMiembro.Enabled = False
        esNuevo = True
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Insertar".
    ''' Habilita el panel de ingreso para agregar una nueva membresía.
    ''' </summary>
    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Try
            HabilitarIngreso()
            esNuevo = True
            lblDatosIngreso.Text = "Seleccione Miembro y Plan Para Agregar Membresia"
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de inserción: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Guardar".
    ''' Inserta o actualiza una membresía utilizando <see cref="NMembresias.Insertar"/> o <see cref="NMembresias.Actualizar"/>.
    ''' Si se agrega una nueva membresía, ofrece la opción de registrar un pago.
    ''' </summary>
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            If esNuevo Then
                Dim membresia As New Membresias
                Dim precio As Decimal
                If dgvMiembro.SelectedRows.Count > 0 Then
                    Dim selectedRow = dgvMiembro.SelectedRows(0)
                    membresia.IdMiembro = CInt(selectedRow.Cells("id_miembro").Value)
                Else
                    Throw New Exception("El Listado de Miembros esta vacio")
                End If
                If dgvPlan.SelectedRows.Count > 0 Then
                    Dim selectedRow = dgvPlan.SelectedRows(0)
                    membresia.IdPlan = CInt(selectedRow.Cells("id_plan").Value)
                    precio = Convert.ToDecimal(selectedRow.Cells("precio").Value)
                Else
                    Throw New Exception("El Listado de Planes esta vacio")
                End If
                nMembresias.Insertar(membresia)
                MsgBox("Membresía insertada correctamente.", MsgBoxStyle.Information, "Éxito")
                ActualizarDataGridView()
                Dim resultado = MessageBox.Show("¿Desea registrar un pago para esta membresía?", "Registrar Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resultado = DialogResult.Yes Then
                    HabilitarIngresoPago()
                    membresia.IdMembresia = nMembresias.ObtenerIdMembresia(membresia)
                    Me.membresia = membresia
                    tbMonto.Text = precio.ToString("F2")
                    tbMonto.ReadOnly = True
                    cbMetodo.SelectedIndex = 0
                    Return
                End If
            Else
                If dgvPlan.SelectedRows.Count > 0 Then
                    Dim selectedRow = dgvPlan.SelectedRows(0)
                    membresia.IdPlan = CInt(selectedRow.Cells("id_plan").Value)
                Else
                    Throw New Exception("El Listado de Planes esta vacio")
                End If
                nMembresias.Actualizar(membresia)
                MsgBox("Membresía actualizada correctamente.", MsgBoxStyle.Information, "Éxito")
                ActualizarDataGridView()
            End If
            HabilitarListado()
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al guardar membresias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Cancelar".
    ''' Vuelve a la vista de listado de membresías.
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
    ''' Habilita el panel de ingreso de pago para una membresía.
    ''' </summary>
    Public Sub HabilitarIngresoPago()
        panelPagoIngreso.Visible = True
        panelDatosIngreso.Visible = False
        panelPagoIngreso.Dock = DockStyle.Fill
        panelListado.Enabled = False
        tbMonto.Clear()
        cbMetodo.SelectedIndex = 0
        tbComprobante.Clear()
        tbNotas.Clear()
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Pagar".
    ''' Permite registrar un pago para una membresía inactiva.
    ''' </summary>
    Private Sub BtnPagar_Click(sender As Object, e As EventArgs) Handles BtnPagar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                membresia = New Membresias()
                membresia.EstadoMembresia = selectedRow.Cells("estado_membresia").Value.ToString
                If membresia.EstadoMembresia = "Activa" Then
                    MsgBox("La membresía ya está activa. No es necesario realizar un pago.", MsgBoxStyle.Information, "Información")
                    Return
                ElseIf membresia.EstadoMembresia = "Inactiva" Then
                    HabilitarIngresoPago()
                    membresia.IdMembresia = CInt(selectedRow.Cells("id_membresia").Value)
                    Dim precio = Convert.ToDecimal(selectedRow.Cells("precio_plan").Value)
                    tbMonto.Text = precio.ToString("F2")
                    tbMonto.ReadOnly = True
                    cbMetodo.SelectedIndex = 0
                Else
                    MsgBox("El estado de la membresía no es válido.", MsgBoxStyle.Exclamation, "Advertencia")
                End If
            Else
                MsgBox("Por favor, seleccione una fila antes de continuar.", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al abrir el formulario de pagos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Guardar Pago".
    ''' Inserta un pago asociado a la membresía utilizando <see cref="NPagos.Insertar"/>.
    ''' </summary>
    Private Sub btnGuardarPago_Click(sender As Object, e As EventArgs) Handles btnGuardarPago.Click
        Try
            Dim pago As New Pagos
            pago.IdMembresia = membresia.IdMembresia
            pago.IdUsuarioRegistro = usuarioActual.IdUsuario
            pago.MontoPagado = Convert.ToDecimal(tbMonto.Text)
            pago.MetodoPago = cbMetodo.SelectedItem.ToString()
            pago.NumeroComprobante = tbComprobante.Text
            pago.Notas = tbNotas.Text

            Dim nPagos As New NPagos()
            nPagos.Insertar(pago)

            MsgBox("Pago registrado correctamente.", MsgBoxStyle.Information, "Éxito")
            ActualizarDataGridView()
            HabilitarListado()
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al guardar el pago: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Cancelar Pago".
    ''' Vuelve a la vista de listado de membresías.
    ''' </summary>
    Private Sub btnCancelarPago_Click(sender As Object, e As EventArgs) Handles btnCancelarPago.Click
        Try
            HabilitarListado()
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al cancelar: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar el texto en el campo de búsqueda de membresías.
    ''' Realiza la búsqueda de membresías por DNI o nombre de plan utilizando <see cref="NMembresias.ListarPorDni"/> o <see cref="NMembresias.ListarPorNombrePlan"/>.
    ''' </summary>
    Private Sub tbBuscarMembresias_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            If cbOpcionBuscar.SelectedIndex = 0 Then
                Dim dvMembresia = nMembresias.ListarPorDni(tbBuscar.Text)
                dgvListado.DataSource = dvMembresia
                lblTotal.Text = "Total Membresias: " & dgvListado.Rows.Count.ToString
                BusquedaSinResultados(0)
            ElseIf cbOpcionBuscar.SelectedIndex = 1 Then
                Dim dvMembresia = nMembresias.ListarPorNombrePlan(tbBuscar.Text)
                dgvListado.DataSource = dvMembresia
                lblTotal.Text = "Total Membresias: " & dgvListado.Rows.Count.ToString
                BusquedaSinResultados(0)
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al buscar miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar la opción de búsqueda de membresías.
    ''' Permite filtrar por estado (activa/inactiva) utilizando <see cref="NMembresias.ListarPorEstado"/>.
    ''' </summary>
    Private Sub cbOpcionBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOpcionBuscar.SelectedIndexChanged
        Try
            If cbOpcionBuscar.SelectedIndex = 2 Then
                Dim dvMembresia = nMembresias.ListarPorEstado("Activa")
                dgvListado.DataSource = dvMembresia
                lblTotal.Text = "Total Membresias: " & dgvListado.Rows.Count.ToString
                tbBuscar.Enabled = False
                BusquedaSinResultados(1)
            ElseIf cbOpcionBuscar.SelectedIndex = 3 Then
                Dim dvMembresia = nMembresias.ListarPorEstado("Inactiva")
                dgvListado.DataSource = dvMembresia
                lblTotal.Text = "Total Membresias: " & dgvListado.Rows.Count.ToString
                tbBuscar.Enabled = False
                BusquedaSinResultados(2)
            Else
                tbBuscar.Enabled = True
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al buscar miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar el texto en el campo de búsqueda de miembros en el panel de ingreso.
    ''' Realiza la búsqueda de miembros por nombre o DNI utilizando <see cref="NMiembros.ListarPorNombre"/> o <see cref="NMiembros.ObtenerPorDni"/>.
    ''' </summary>
    Private Sub tbBuscarMiembro_TextChanged(sender As Object, e As EventArgs) Handles tbBuscarMiembro.TextChanged
        Try
            Dim nMiembros As New NMiembros
            If cbOpcionBuscarMiembro.SelectedIndex = 0 Then
                Dim dtMiembro = nMiembros.ListarPorNombre(tbBuscarMiembro.Text)
                dgvMiembro.DataSource = dtMiembro
                BusquedaSinResultados(3)

            ElseIf cbOpcionBuscarMiembro.SelectedIndex = 1 Then
                Dim dtMiembro = nMiembros.ObtenerPorDni(tbBuscarMiembro.Text)
                dgvMiembro.DataSource = dtMiembro
                BusquedaSinResultados(3)
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al buscar membresias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar el texto en el campo de búsqueda de planes en el panel de ingreso.
    ''' Realiza la búsqueda de planes por nombre utilizando <see cref="NPlanes.ListarPorNombre"/>.
    ''' </summary>
    Private Sub tbBuscarPlan_TextChanged(sender As Object, e As EventArgs) Handles tbBuscarPlan.TextChanged
        Try
            Dim nPLan As New NPlanes()
            If cbBuscarOpcionPlan.SelectedIndex = 0 Then
                Dim dtPlan As DataTable = nPLan.ListarPorNombre(tbBuscarPlan.Text)
                dgvPlan.DataSource = dtPlan
                BusquedaSinResultados(4)
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al buscar plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Verifica si la búsqueda de membresías, miembros o planes no devolvió resultados.
    ''' Muestra un mensaje informativo y restablece el campo de búsqueda.
    ''' </summary>
    ''' <param name="caso">Caso que indica qué tipo de búsqueda se realizó.</param>
    ''' <remarks>0: Membresías, 1: Membresías activas, 2: Membresías inactivas, 3: Miembros, 4: Planes</remarks>
    Public Sub BusquedaSinResultados(caso As Integer)
        Try
            Select Case caso
                Case 0
                    If dgvListado.Rows.Count = 0 And Not String.IsNullOrEmpty(tbBuscar.Text) Then
                        MsgBox("No se encontró ninguna membresía con ese criterio.", MsgBoxStyle.Information, "Sin resultados")
                        tbBuscar.Clear()
                        ActualizarDataGridView()
                    End If
                Case 1
                    If dgvListado.Rows.Count = 0 Then
                        MsgBox("No se encontró ninguna membresía activa.", MsgBoxStyle.Information, "Sin resultados")
                        tbBuscar.Clear()
                        ActualizarDataGridView()
                        tbBuscar.Enabled = True
                        cbOpcionBuscar.SelectedIndex = 0
                    End If
                Case 2
                    If dgvListado.Rows.Count = 0 Then
                        MsgBox("No se encontró ninguna membresía inactiva.", MsgBoxStyle.Information, "Sin resultados")
                        tbBuscar.Clear()
                        ActualizarDataGridView()
                        tbBuscar.Enabled = True
                        cbOpcionBuscar.SelectedIndex = 0
                    End If
                Case 3
                    Dim nMiembros As New NMiembros
                    If dgvMiembro.Rows.Count = 0 And Not String.IsNullOrEmpty(tbBuscarMiembro.Text) Then
                        MsgBox("No se encontró ningún miembro con ese criterio.", MsgBoxStyle.Information, "Sin resultados")
                        tbBuscarMiembro.Clear()
                        Dim dtMiembros As DataTable = nMiembros.Listar()
                        dgvMiembro.DataSource = dtMiembros
                    End If
                Case 4
                    Dim nPlan As New NPlanes
                    If dgvPlan.Rows.Count = 0 And Not String.IsNullOrEmpty(tbBuscarPlan.Text) Then
                        MsgBox("No se encontró ningún plan con ese criterio.", MsgBoxStyle.Information, "Sin resultados")
                        tbBuscarPlan.Clear()
                        Dim dtPlanes As DataTable = nPlan.Listar()
                        dgvPlan.DataSource = dtPlanes
                    End If
            End Select
        Catch ex As Exception
            Logger.LogError("Capa Presentación", ex)
            MsgBox("Error al buscar las membresias", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Eliminar".
    ''' Elimina la membresía seleccionada utilizando <see cref="NMembresias.Eliminar"/>.
    ''' </summary>
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                Dim idMiembro As UInteger = CInt(selectedRow.Cells("id_membresia").Value)

                Dim confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar esta Membresia?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    nMembresias.Eliminar(idMiembro)
                    ActualizarDataGridView()
                    MsgBox("Memmbresia eliminado exitosamente.", MsgBoxStyle.Information, "Exito")
                End If
            Else
                MsgBox("Seleccione una Membresia para eliminar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al eliminar la membresia: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Actualizar".
    ''' Carga los datos de la membresía seleccionada en el panel de ingreso para su edición.
    ''' </summary>
    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)

                If selectedRow.Cells("estado_membresia").Value.ToString = "Activa" Then
                    MsgBox("No se puede actualizar una membresía Activa.", MsgBoxStyle.Exclamation, "Aviso")
                    Return
                End If
                membresia = New Membresias
                membresia.IdMembresia = CUInt(selectedRow.Cells("id_membresia").Value)
                membresia.IdMiembro = CUInt(selectedRow.Cells("id_miembro").Value)

                esNuevo = False
                HabilitarIngreso()
                tbBuscarMiembro.Text = selectedRow.Cells("dni_miembro").Value.ToString()
                tbBuscarMiembro.Enabled = False
                tbBuscarPlan.Text = selectedRow.Cells("nombre_plan").Value.ToString()
                lblDatosIngreso.Text = "Actualizar Membresia"

            Else
                MsgBox("Seleccione un miembro para actualizar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al agregar el miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub panelListado_Paint(sender As Object, e As PaintEventArgs) Handles panelListado.Paint

    End Sub
End Class
