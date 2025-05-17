Imports Gimnasio.Entidades
Imports Gimnasio.Negocio
Imports Gimnasio.Errores

''' <summary>
''' Formulario para la gestión de membresías en el sistema del gimnasio. Permite listar, buscar, agregar, actualizar, eliminar membresías y registrar pagos.
''' Utiliza la clase <see cref="Gimnasio.Negocio.NMembresias"/> para la lógica de negocio y la clase <see cref="Membresias"/> como entidad.
''' Todas las operaciones de esta capa están envueltas en bloques Try...Catch. 
''' El manejo de errores se realiza a través de <see cref="Gimnasio.Errores.ManejarErrores.Mostrar(String, Exception)"/>
''' que permite guardar el error en un log.txt y a su vez mostrar un mensaje al usuario.
''' </summary>
Public Class FrmMembresias

    ''' <summary>
    ''' Instancia de la capa de negocio para membresías.
    ''' </summary>
    Private nMembresias As New NMembresias()

    ''' <summary>
    ''' Usuario actualmente logueado, utilizado para registrar pagos.
    ''' </summary>
    Private usuarioActual As Usuarios

    ''' <summary>
    ''' Indica si la operación actual es de inserción (True) o actualización (False).
    ''' </summary>
    Private esNuevo As Boolean

    ''' <summary>
    ''' Constructor que inicializa el formulario. Si es recepcionista oculta el boton de eliminar.
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
    ''' Evento que se ejecuta al cargar el formulario. Inicializa el listado de membresías con <see cref="NMembresias.Listar()"/>, 
    ''' configura las columnas del DataGridView y establece una opción de busqueda del ComboBox.
    ''' </summary>
    Private Sub frmMembresias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDgv()

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
            ManejarErrores.Mostrar("Error al cargar la pestaña de membresias", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el DataGridView con la lista de membresías completa obtenida de la capa de negocio <see cref="NMembresias.Listar"/>.
    ''' También actualiza la etiqueta que muestra el total de membresias.
    ''' </summary>
    Public Sub ActualizarDgv()
        Try
            dgvListado.DataSource = nMembresias.Listar()
            lblTotal.Text = "Total Membresias: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar listado de membresias", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el DataGridView con un DataTable específico de membresía, por ejemplo, tras una búsqueda o filtrado.
    ''' También actualiza la etiqueta con el total de membresias.
    ''' </summary>
    ''' <param name="listado">es un DataTable que contiene la lista de membresías.</param>
    Public Sub ActualizarDgv(listado As DataTable)
        Try
            dgvListado.DataSource = listado
            lblTotal.Text = "Total Membresias: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar listado de membresias", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Habilita la vista de listado de membresías y oculta los paneles de ingreso y pago.
    ''' </summary>
    Public Sub HabilitarListado()
        Try
            panelListado.Enabled = True
            panelDatosIngreso.Visible = False
            panelPagoIngreso.Visible = False
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al habilitar el listado de membresías: ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' - Hace visible el panel de ingreso de datos y lo ajusta para ocupar todo el espacio disponible.
    ''' - Deshabilita el panel de listado de membresías para evitar la interacción con el listado mientras se está ingresando o editando una membresía.
    ''' - Habilita y limpia los campos de búsqueda de miembro y plan, y muestra el botón de reinicio de miembro.
    ''' - Inicializa el DataGridView de miembros  con la lista completa de miembros, configurando la visibilidad y los encabezados de las columnas.
    ''' - Inicializa el DataGridView de planes con la lista completa de planes, configurando la visibilidad y los encabezados de las columnas.
    ''' - Establece la opción predeterminada de búsqueda de miembro en "DNI" (índice 1) y de plan en "Nombre" (índice 0).
    ''' </summary>
    Public Sub HabilitarIngreso()
        Try
            panelDatosIngreso.Visible = True
            panelDatosIngreso.Dock = DockStyle.Fill
            panelListado.Enabled = False
            tbBuscarMiembro.Enabled = True
            cbOpcionBuscarMiembro.Enabled = True
            tbBuscarMiembro.Clear()
            pbReiniciarMiembro.Visible = True
            tbBuscarPlan.Clear()

            Dim nMiembros As New NMiembros()
            dgvMiembro.DataSource = nMiembros.Listar()
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

            Dim nPlanes As New NPlanes()
            dgvPlan.DataSource = nPlanes.Listar()
            dgvPlan.Columns(0).Visible = False
            dgvPlan.Columns(1).HeaderText = "Nombre del Plan"
            dgvPlan.Columns(2).HeaderText = "Descripción"
            dgvPlan.Columns(3).HeaderText = "Duración"
            dgvPlan.Columns(4).HeaderText = "Precio"
            dgvPlan.Columns(5).HeaderText = "Fecha de Creación"
            dgvPlan.Columns(6).HeaderText = "Última Modificación"
            cbBuscarOpcionPlan.SelectedIndex = 0

        Catch ex As Exception
            ManejarErrores.Mostrar("Error al habilitar el ingreso de membresías", ex)
        End Try
    End Sub

    ''' <summary>
    ''' - Llama a <see cref="HabilitarIngreso"/> para preparar la interfaz de ingreso de membresías.
    ''' - Asigna el valor del DNI recibido al campo de búsqueda de miembro.
    ''' - Deshabilita la edición del campo de búsqueda de miembro y del ComboBox de opciones de búsqueda de miembro, para evitar que el usuario cambie el miembro preseleccionado.
    ''' - Oculta el botón de reinicio de miembro, ya que no es necesario reiniciar la búsqueda en este contexto.
    ''' - Establece la variable esNuevo en True para indicar que la operación es de inserción de una nueva membresía.
    ''' - Cambia el texto del label para indicar al usuario que debe seleccionar un plan para agregar la membresía.
    ''' </summary>
    ''' <param name="dni">DNI del miembro a preseleccionar en el formulario de ingreso de membresía.</param>
    Public Sub HabilitarIngresoConMiembro(dni As String)
        Try
            HabilitarIngreso()
            tbBuscarMiembro.Text = dni
            tbBuscarMiembro.Enabled = False
            pbReiniciarMiembro.Visible = False
            cbOpcionBuscarMiembro.Enabled = False
            esNuevo = True
            lblDatosIngreso.Text = "Seleccione un Plan Para Agregar Membresia"
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al habilitar el ingreso de membresías con miembro preseleccionado", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Insertar".
    ''' - Llama al método <see cref="HabilitarIngreso"/> para mostrar el panel de ingreso de datos.
    ''' - Establece la variable esNuevo en True para indicar que la operación es de alta.
    ''' - Cambia el texto del label para informar al usuario el contexto de la operación.
    ''' </summary>
    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Try
            HabilitarIngreso()
            esNuevo = True
            lblDatosIngreso.Text = "Seleccione Miembro y Plan Para Agregar Membresia"
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al habilitar el ingreso de membresías", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Actualizar".
    ''' - Verifica si hay una fila seleccionada en el DataGridView.
    '''   - Si hay una selección:
    '''     - Si la membresía seleccionada tiene estado "Activa", lanza una excepción e informa que no se puede actualizar una membresía activa.
    '''     - Si la membresía es Inactiva:
    '''         - Cambia el modo a edición estableciendo esNuevo en False.
    '''         - Llama a <see cref="HabilitarIngreso"/> para mostrar el panel de ingreso.
    '''         - Carga los datos de la membresía seleccionada en los campos de entrada.
    '''         - Deshabilita la edición del miembro  y oculta el botón de reinicio de miembro.
    '''         - Cambia el texto del label para indicar el contexto de edición.
    '''   - Si no hay ninguna fila seleccionada, lanza una excepción informando que no se ha seleccionado ningún miembro.
    ''' </summary>

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)

                If selectedRow.Cells("estado_membresia").Value.ToString = "Activa" Then
                    Throw New Exception("No se puede actualizar una membresía Activa.")
                End If

                esNuevo = False
                HabilitarIngreso()
                tbIDmembresia.Text = selectedRow.Cells("id_membresia").Value
                tbIDmiembro.Text = selectedRow.Cells("id_miembro").Value
                tbBuscarMiembro.Text = selectedRow.Cells("dni_miembro").Value
                tbBuscarMiembro.Enabled = False
                pbReiniciarMiembro.Visible = False
                cbOpcionBuscarMiembro.Enabled = False
                tbBuscarPlan.Text = selectedRow.Cells("nombre_plan").Value
                lblDatosIngreso.Text = "Actualizar Membresia: Seleccione un nuevo plan"
            Else
                Throw New Exception("No se ha seleccionado ningun miembro.")
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al habilitar el ingreso de membresías para actualización", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Guardar".
    ''' - Valida que haya un miembro y un plan seleccionados en los DataGridView correspondientes. Si no hay selección, lanza una excepción y muestra un mensaje.
    ''' - Crea un objeto <see cref="Membresias"/> y asigna los valores seleccionados de miembro y plan.
    ''' - Si la operación es de inserción (esNuevo = True):
    '''     - Llama a <see cref="NMembresias.Insertar"/> para agregar la nueva membresía. Muestra un mensaje de éxito.
    '''     - Pregunta al usuario si desea registrar un pago para la nueva membresía mediante un cuadro de diálogo.
    '''         - Si el usuario acepta, habilita el panel de ingreso de pago. 
    '''         - Obtiene el ID de la membresía recién insertada usando <see cref="NMembresias.ObtenerIdMembresia"/>, 
    '''           precarga el monto y método de pago, y detiene la ejecución para esperar el registro del pago.
    ''' - Si la operación es de actualización (esNuevo = False):
    '''     - Asigna el ID de la membresía desde el campo correspondiente.
    '''     - Llama a <see cref="NMembresias.Actualizar"/> para modificar la membresía existente. Muestra un mensaje de éxito.
    ''' - Finalmente, actualiza el listado de membresías y vuelve a la vista de listado.
    ''' </summary>

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim membresia As New Membresias
            If dgvMiembro.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvMiembro.SelectedRows(0)
                membresia.IdMiembro = CInt(selectedRow.Cells("id_miembro").Value)
            Else
                Throw New Exception("El Listado de Miembros esta vacio")
            End If
            Dim precio As Decimal
            If dgvPlan.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvPlan.SelectedRows(0)
                membresia.IdPlan = CInt(selectedRow.Cells("id_plan").Value)
                precio = Convert.ToDecimal(selectedRow.Cells("precio").Value)
            Else
                Throw New Exception("El Listado de Planes esta vacio")
            End If
            If esNuevo Then
                nMembresias.Insertar(membresia)
                MsgBox("Membresía insertada correctamente.", MsgBoxStyle.Information, "Éxito")
                Dim resultado = MessageBox.Show("¿Desea registrar un pago para esta membresía?", "Registrar Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resultado = DialogResult.Yes Then
                    HabilitarIngresoPago()
                    membresia.IdMembresia = nMembresias.ObtenerIdMembresia(membresia)
                    tbIDpago.Text = membresia.IdMembresia
                    tbMonto.Text = precio.ToString("F2")
                    tbMonto.ReadOnly = True
                    cbMetodo.SelectedIndex = 0
                    Return
                End If
            Else
                membresia.IdMembresia = CInt(tbIDmembresia.Text)
                nMembresias.Actualizar(membresia)
                MsgBox("Membresía actualizada correctamente.", MsgBoxStyle.Information, "Éxito")
            End If
            ActualizarDgv()
            HabilitarListado()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al guardar membresias", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Cancelar". Vuelve a la vista de listado de membresías.
    ''' </summary>
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            HabilitarListado()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cancelar la operación", ex)
        End Try
    End Sub

    ''' <summary>
    ''' - Hace visible el panel de ingreso de pago panelPagoIngreso y lo ajusta para ocupar todo el espacio disponible del formulario.
    ''' - Oculta el panel de ingreso de datos y el de listado de membresía.
    ''' - Limpia el campo de monto, el campo de comprobante y el campo de notas.
    ''' - Establece el método de pago predeterminado seleccionando el primer elemento del ComboBox.
    ''' </summary>

    Public Sub HabilitarIngresoPago()
        Try
            panelPagoIngreso.Visible = True
            panelDatosIngreso.Visible = False
            panelPagoIngreso.Dock = DockStyle.Fill
            panelListado.Enabled = False
            tbMonto.Clear()
            tbComprobante.Clear()
            tbNotas.Clear()
            cbMetodo.SelectedIndex = 0
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al habilitar el ingreso de pago", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Pagar".
    ''' - Verifica si hay una fila seleccionada en el DataGridView de membresías.
    '''     - Si no hay ninguna selección, lanza una excepción y muestra un mensaje de advertencia.
    ''' - Obtiene el estado de la membresía seleccionada:
    '''     - Si el estado es "Activa", lanza una excepción e informa que no se puede registrar un pago para una membresía activa.
    '''     - Si el estado es "Inactiva":
    '''         - Llama a <see cref="HabilitarIngresoPago"/> para mostrar el panel de registro de pago.
    '''         - Precarga el ID de la membresía y el monto correspondiente en los campos de pago.
    '''         - Establece el campo de monto como solo lectura y selecciona el método de pago predeterminado.
    ''' </summary>

    Private Sub BtnPagar_Click(sender As Object, e As EventArgs) Handles BtnPagar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                Dim EstadoMembresia As String
                EstadoMembresia = selectedRow.Cells("estado_membresia").Value.ToString
                If EstadoMembresia = "Activa" Then
                    Throw New Exception("No se puede registrar un pago para una membresía activa.")
                ElseIf EstadoMembresia = "Inactiva" Then
                    HabilitarIngresoPago()
                    tbIDpago.Text = selectedRow.Cells("id_membresia").Value
                    tbMonto.Text = selectedRow.Cells("precio_plan").Value
                    tbMonto.ReadOnly = True
                    cbMetodo.SelectedIndex = 0
                End If
            Else
                Throw New Exception("No se ha seleccionado ninguna membresia.")
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de pagos", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Guardar Pago".
    ''' - Crea un nuevo objeto <see cref="Pagos"/> y le asigna los valores ingresados en el formulario:
    ''' - Instancia la capa de negocio <see cref="NPagos"/> y llama a <see cref="NPagos.Insertar"/> para registrar el pago en la base de datos.
    ''' - Muestra un mensaje de éxito al usuario.
    ''' - Actualiza el listado de membresías para reflejar el nuevo estado.
    ''' - Vuelve a la vista de listado de membresías.
    ''' </summary>

    Private Sub btnGuardarPago_Click(sender As Object, e As EventArgs) Handles btnGuardarPago.Click
        Try
            Dim pago As New Pagos
            pago.IdMembresia = CUInt(tbIDpago.Text)
            pago.MontoPagado = CDec(tbMonto.Text)
            pago.MetodoPago = cbMetodo.SelectedItem.ToString()
            pago.NumeroComprobante = tbComprobante.Text
            pago.Notas = tbNotas.Text
            pago.IdUsuarioRegistro = usuarioActual.IdUsuario

            Dim nPagos As New NPagos()
            nPagos.Insertar(pago)

            MsgBox("Pago registrado correctamente.", MsgBoxStyle.Information, "Éxito")
            ActualizarDgv()
            HabilitarListado()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al guardar el pago: ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Cancelar Pago". Vuelve a la vista de listado de membresías.
    ''' </summary>
    Private Sub btnCancelarPago_Click(sender As Object, e As EventArgs) Handles btnCancelarPago.Click
        Try
            HabilitarListado()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cancelar: ", ex)
        End Try
    End Sub


    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Eliminar".
    ''' - Verifica si hay una fila seleccionada en el DataGridView de membresías.
    '''     - Si no hay ninguna selección, lanza una excepción y muestra un mensaje de advertencia al usuario.
    ''' - Si hay una membresía seleccionada:
    '''     - Obtiene el ID de la membresía a eliminar.
    '''     - Solicita confirmación al usuario mediante un cuadro de diálogo.
    '''         - Si el usuario confirma la eliminación:
    '''             - Llama a <see cref="NMembresias.Eliminar"/> para eliminar la membresía de la base de datos.
    '''             - Actualiza el listado de membresías llamando a <see cref="ActualizarDgv"/>. Muestra un mensaje de éxito al usuario.
    ''' </summary>

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                Dim idMiembro As UInteger = CInt(selectedRow.Cells("id_membresia").Value)

                Dim confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar esta Membresia?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    nMembresias.Eliminar(idMiembro)
                    ActualizarDgv()
                    MsgBox("Membresia eliminado exitosamente.", MsgBoxStyle.Information, "Exito")
                End If
            Else
                Throw New Exception("No se ha seleccionado ninguna membresia.")
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al eliminar la membresia.", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta cada vez que cambia el texto en el campo de búsqueda de membresías.
    ''' - Según la opción seleccionada en el ComboBox:
    '''     - Si la opción es índice 0, realiza una búsqueda de membresías filtrando por el DNI del miembro usando <see cref="NMembresias.ListarPorDni"/>.
    '''     - Si la opción es índice 1, realiza una búsqueda de membresías filtrando por el nombre del plan usando <see cref="NMembresias.ListarPorNombrePlan"/>.
    ''' - El resultado de la búsqueda se muestra en el DataGridView de membresías mediante el método <see cref="ActualizarDgv"/>.
    ''' </summary>
    Private Sub tbBuscarMembresias_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            If cbOpcionBuscar.SelectedIndex = 0 Then
                ActualizarDgv(nMembresias.ListarPorDni(tbBuscar.Text))
            ElseIf cbOpcionBuscar.SelectedIndex = 1 Then
                ActualizarDgv(nMembresias.ListarPorNombrePlan(tbBuscar.Text))
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al buscar membresias. ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar la opción seleccionada en el ComboBox de búsqueda de membresías.
    ''' - Al cambiar la opción, limpia el campo de búsqueda y actualiza el listado de membresías mostrando todos los registros mediante <see cref="ActualizarDgv"/>.
    ''' - Si la opción seleccionada es "Activa" (índice 2):
    '''     - Filtra y muestra solo las membresías activas utilizando <see cref="NMembresias.ListarPorEstado"/> con el parámetro "Activa".
    '''     - Deshabilita el campo de búsqueda.
    ''' - Si la opción seleccionada es "Inactiva" (índice 3):
    '''     - Filtra y muestra solo las membresías inactivas utilizando <see cref="NMembresias.ListarPorEstado"/> con el parámetro "Inactiva".
    '''     - Deshabilita el campo de búsqueda.
    ''' - Para cualquier otra opción (por ejemplo, búsqueda por DNI o por nombre de plan):
    '''     - Habilita el campo de búsqueda, para permitir la búsqueda dinámica.
    ''' </summary>
    Private Sub cb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOpcionBuscar.SelectedIndexChanged
        Try
            ActualizarDgv()
            tbBuscar.Clear()
            If cbOpcionBuscar.SelectedIndex = 2 Then
                ActualizarDgv(nMembresias.ListarPorEstado("Activa"))
                tbBuscar.Enabled = False
            ElseIf cbOpcionBuscar.SelectedIndex = 3 Then
                ActualizarDgv(nMembresias.ListarPorEstado("Inactiva"))
                tbBuscar.Enabled = False
            Else
                tbBuscar.Enabled = True
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al buscar membresias", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta cada vez que cambia el texto en el campo de búsqueda de miembros tbBuscarMiembro en el panel de ingreso de membresías.
    ''' Según la opción seleccionada en el ComboBox cbOpcionBuscarMiembro:
    ''' - Si la opción es "Nombre" (índice 0), busca miembros utilizando <see cref="NMiembros.ListarPorNombre"/>.
    ''' - Si la opción es "DNI" (índice 1), busca miembros cuyo utilizando <see cref="NMiembros.ObtenerPorDni"/>.
    ''' El resultado de la búsqueda se muestra en el DataGridView dgvMiembro.
    ''' </summary>

    Private Sub tbBuscarMiembro_TextChanged(sender As Object, e As EventArgs) Handles tbBuscarMiembro.TextChanged
        Try
            Dim nMiembros As New NMiembros
            If cbOpcionBuscarMiembro.SelectedIndex = 0 Then
                dgvMiembro.DataSource = nMiembros.ListarPorNombre(tbBuscarMiembro.Text)

            ElseIf cbOpcionBuscarMiembro.SelectedIndex = 1 Then
                dgvMiembro.DataSource = nMiembros.ObtenerPorDni(tbBuscarMiembro.Text)
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al buscar miembro. ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta cada vez que cambia el texto en el campo de búsqueda de planes.
    ''' - Según la opción seleccionada en el ComboBox:
    '''     - Si la opción es "Nombre" (índice 0), realiza una búsqueda de planes filtrando por el nombre usando <see cref="NPlanes.ListarPorNombre"/>.
    ''' - El resultado de la búsqueda se muestra en el DataGridView de planes.
    ''' </summary>
    Private Sub tbBuscarPlan_TextChanged(sender As Object, e As EventArgs) Handles tbBuscarPlan.TextChanged
        Try
            Dim nPLan As New NPlanes()
            If cbBuscarOpcionPlan.SelectedIndex = 0 Then
                dgvPlan.DataSource = nPLan.ListarPorNombre(tbBuscarPlan.Text)
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al buscar plan. ", ex)
        End Try
    End Sub


    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón de reinicio en la gestión de membresías.
    ''' Según la opción seleccionada en el ComboBox cbOpcionBuscar:
    ''' - Si la opción es "DNI" o "Nombre de Plan" (índices 0 o 1), limpia el campo de búsqueda y actualiza el listado de membresías mostrando todos los registros.
    ''' - Si la opción es "Activa" o "Inactiva" (índices 2 o 3), restablece la opción del ComboBox a "DNI" (índice 0) y actualiza el listado mostrando todos los registros.
    ''' </summary>
    Private Sub pbReiniciar_Click(sender As Object, e As EventArgs) Handles pbReiniciar.Click
        Try
            Select Case cbOpcionBuscar.SelectedIndex
                Case 0, 1
                    tbBuscar.Clear()
                    ActualizarDgv()
                Case 2, 3
                    cbOpcionBuscar.SelectedIndex = 0
                    ActualizarDgv()
            End Select
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al reiniciar el listado ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón de reinicio pbReiniciarMiembro.
    ''' Limpia el campo de búsqueda de miembros tbBuscarMiembro y actualiza el DataGridView dgvMiembro mostrando la lista completa de miembros,
    ''' utilizando el método <see cref="NMiembros.Listar"/>. 
    ''' </summary>
    Private Sub pbReiniciarMiembro_Click(sender As Object, e As EventArgs) Handles pbReiniciarMiembro.Click
        Try
            Dim nMiembros As New NMiembros
            tbBuscarMiembro.Clear()
            dgvMiembro.DataSource = nMiembros.Listar
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al reiniciar el listado ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón de reinicio pbReiniciarPlan.
    ''' Limpia el campo de búsqueda de planes tbBuscarPlan y actualiza el DataGridView dgvPlan mostrando la lista completa de planes,
    ''' utilizando el método <see cref="NPlanes.Listar"/>. 
    ''' </summary>
    Private Sub pbReiniciarPlan_Click(sender As Object, e As EventArgs) Handles pbReiniciarPlan.Click
        Try
            Dim nPlan As New NPlanes
            tbBuscarPlan.Clear()
            dgvPlan.DataSource = nPlan.Listar
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al reiniciar el listado ", ex)
        End Try
    End Sub

End Class
