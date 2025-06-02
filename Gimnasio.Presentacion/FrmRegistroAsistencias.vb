Imports Gimnasio.Negocio
Imports Gimnasio.Entidades
Imports Gimnasio.Errores

''' <summary>
''' Formulario para la gestión y consulta de asistencias de los miembros en el sistema del gimnasio.
''' Permite listar, buscar por DNI o fecha, y eliminar registros de asistencia. Utiliza la clase <see cref="NAsistencia"/> para la lógica de negocio.
''' Todas las operaciones de esta capa están envueltas en bloques Try...Catch. 
''' El manejo de errores se realiza a través de <see cref="Gimnasio.Errores.ManejarErrores.Mostrar(String, Exception)"/>
''' que permite guardar el error en un log.txt y a su vez mostrar un mensaje al usuario.
''' </summary>
''' <remarks>
''' Todas las operaciones de esta capa están envueltas en bloques Try...Catch. 
''' El manejo de errores se realiza a través de <see cref="Gimnasio.Errores.ManejarErrores.Mostrar(String, Exception)"/>
''' que permite guardar el error en un log.txt y a su vez mostrar un mensaje al usuario.
''' </remarks>
Public Class FrmRegistroAsistencias
    ''' <summary>
    ''' Instancia de la capa de negocio para asistencias.
    ''' </summary>
    Private nAsistencias As New NAsistencia()

    ''' <summary>
    ''' Referencia a la instancia del formulario <see cref="FrmAsistencias"/> asociada a este formulario de registro de asistencias.
    ''' Permite la comunicación y sincronización entre ambos formularios.
    ''' </summary>
    Private frmAsistencia As FrmAsistencias

    ''' <summary>
    ''' Constructor del formulario de asistencias. Si el usuario es recepcionista, oculta el boton de eliminar.
    ''' </summary>
    ''' <param name="usuario">Instancia de <see cref="Usuarios"/> que representa al usuario logueado.</param>
    Friend Sub New(usuario As Usuarios)
        InitializeComponent()
        If usuario.IdRol = 2 Then
            btnEliminar.Visible = False
            btnEliminar.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cargar el formulario de registro de asistencias.
    ''' - Inicializa el listado de asistencias en el DataGridView llamando a <see cref="ActualizarDgv"/>.
    ''' - Configura la visibilidad y los encabezados de las columnas del DataGridView 
    '''   para mostrar solo la información relevante y con títulos descriptivos.
    ''' - Establece la opción predeterminada del ComboBox de búsqueda en la segunda opción (índice 1).
    ''' - Configura los controles DateTimePicker para fecha de inicio y fin con un formato personalizado vacío
    ''' </summary>
    Private Sub frmRegistroAsistencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDgv()
            dgvListado.Columns(0).Visible = False
            dgvListado.Columns(1).Visible = False
            dgvListado.Columns(2).Visible = False
            dgvListado.Columns(0).HeaderText = "ID ASISTENCIA"
            dgvListado.Columns(1).HeaderText = "ID MIEMBRO"
            dgvListado.Columns(2).HeaderText = "ID MEMBRESIA"
            dgvListado.Columns(3).HeaderText = "DNI MIEMBRO"
            dgvListado.Columns(4).HeaderText = "NOMBRE MIEMBRO"
            dgvListado.Columns(5).HeaderText = "APELLIDO MIEMBRO"
            dgvListado.Columns(6).HeaderText = "FECHA INGRESO"
            dgvListado.Columns(7).HeaderText = "RESULTADO"
            dgvListado.Columns(8).HeaderText = "PLAN AL DIA"
            cbOpcionBuscar.SelectedIndex = 1
            dtpFechaInicio.Format = DateTimePickerFormat.Custom
            dtpFechaInicio.CustomFormat = " "
            dtpFechaFin.Format = DateTimePickerFormat.Custom
            dtpFechaFin.CustomFormat = " "
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar el formulario de asistencias", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el DataGridView con la lista de asistencias obtenida desde la capa de negocio mediante <see cref="NAsistencia.Listar"/>.
    ''' - Obtiene todos los registros de asistencias y los asigna como origen de datos del DataGridView.
    ''' - Actualiza la etiqueta lblTotal mostrando la cantidad total de asistencias listadas.
    ''' </summary>
    Public Sub ActualizarDgv()
        Try
            Dim dvAsistencias As DataTable = nAsistencias.Listar()
            dgvListado.DataSource = dvAsistencias
            lblTotal.Text = "Total Asistencias: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar las asistencias", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el DataGridView con una lista específica de asistencias proporcionada como parámetro.
    ''' - Asigna el DataTable recibido como origen de datos del DataGridView.
    ''' - Actualiza la etiqueta lblTotal mostrando la cantidad total de asistencias listadas en el DataGridView.
    ''' </summary>
    Public Sub ActualizarDgv(Listado As DataTable)
        Try
            dgvListado.DataSource = Listado
            lblTotal.Text = "Total Asistencias: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar las asistencias", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Insertar" en el formulario de registro de asistencias.
    ''' - Verifica si ya existe una instancia activa y no liberada del formulario <see cref="FrmAsistencias"/> asociada a este formulario.
    '''   - Si ya está abierta, muestra un mensaje informando al usuario y lleva el formulario existente al frente y le da el foco.
    '''   - Si no existe o ya fue cerrada, crea una nueva instancia de <see cref="FrmAsistencias"/>, pasando como parámetro la instancia actual de
    '''   este formulario.
    ''' - Muestra el formulario <see cref="FrmAsistencias"/> para permitir el registro de una nueva asistencia mediante el ingreso de DNI.
    ''' </summary>
    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Try
            If frmAsistencia IsNot Nothing AndAlso Not frmAsistencia.IsDisposed Then
                MessageBox.Show("El formulario de registro de asistencias ya está abierto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmAsistencia.BringToFront()
                frmAsistencia.Focus()
                Return
            End If
            frmAsistencia = New FrmAsistencias(Me)
            frmAsistencia.Show()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al abrir el formulario de registro de asistencias", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar la opción seleccionada en el ComboBox de búsqueda de asistencias.
    ''' - Actualiza el DataGridView mostrando todas las asistencias mediante <see cref="ActualizarDgv"/>.
    ''' - Utiliza una estructura Select Case para determinar el tipo de búsqueda:
    '''   - Opción 0: habilita el campo de texto para buscar por DNI y oculta el panel de búsqueda por fecha.
    '''   - Opción 1: oculta y deshabilita el campo de texto de búsqueda y muestra el panel para búsqueda por rango de fechas.
    ''' - Permite alternar entre búsqueda por DNI o por fechas según la selección del usuario.
    ''' </summary>
    Private Sub cb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOpcionBuscar.SelectedIndexChanged
        Try
            ActualizarDgv()
            Select Case cbOpcionBuscar.SelectedIndex
                Case 0
                    tbBuscar.Visible = True
                    tbBuscar.Enabled = True
                    PanelFecha.Visible = False
                Case 1
                    tbBuscar.Visible = False
                    tbBuscar.Enabled = False
                    PanelFecha.Visible = True
            End Select
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cambiar la opción de búsqueda", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar el texto en el campo de búsqueda de asistencias.
    ''' - Si la opción seleccionada en el ComboBox es la de búsqueda por DNI (índice 0), filtra las asistencias 
    ''' utilizando <see cref="NAsistencia.ListarPorDNI"/> con el texto ingresado.
    ''' - Actualiza el DataGridView con los resultados de la búsqueda llamando a <see cref="ActualizarDgv"/>.
    ''' </summary>
    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            If cbOpcionBuscar.SelectedIndex = 0 Then
                ActualizarDgv(nAsistencias.ListarPorDNI(tbBuscar.Text))
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al buscar asistencias", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar el valor del DateTimePicker para la fecha de inicio. Cambia el formato a corto para mostrar solo la fecha.
    ''' </summary>
    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        Try
            dtpFechaInicio.Format = DateTimePickerFormat.Short
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cambiar la fecha de inicio", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar el valor del DateTimePicker para la fecha de fin. Cambia el formato a corto para mostrar solo la fecha.
    ''' </summary>
    Private Sub dtpFechaFin_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFin.ValueChanged
        Try
            dtpFechaFin.Format = DateTimePickerFormat.Short
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cambiar la fecha de fin", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón para buscar asistencias por fecha.
    ''' - Obtiene las fechas seleccionadas en los controles DateTimePicker para inicio y fin.
    ''' - Valida que la fecha de inicio no sea mayor que la fecha de fin; si lo es, lanza una excepción.
    ''' - Llama a <see cref="NAsistencia.ListarPorFecha"/> para obtener las asistencias dentro del rango de fechas especificado.
    ''' - Actualiza el DataGridView con los resultados llamando a <see cref="ActualizarDgv()"/>.
    ''' </summary>
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim fechaInicio = dtpFechaInicio.Value.Date
            Dim fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1)
            If fechaInicio > fechaFin Then
                Throw New Exception("La fecha de inicio no puede ser mayor que la fecha de fin.")
            End If
            ActualizarDgv(nAsistencias.ListarPorFecha(fechaInicio, fechaFin))
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al buscar asistencias por fecha", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Eliminar".
    ''' - Verifica si hay una fila seleccionada en el DataGridView de asistencias.
    ''' - Si hay selección, obtiene el ID de la asistencia seleccionada y solicita confirmación al usuario mediante un cuadro de diálogo.
    ''' - Si el usuario confirma, utiliza <see cref="NAsistencia.Eliminar"/> para eliminar el registro de asistencia de la base de datos.
    ''' - Actualiza el listado de asistencias en el DataGridView mediante <see cref="ActualizarDgv"/> y muestra un mensaje de éxito.
    ''' - Si no hay selección, lanza una excepción indicando que no se ha seleccionado ninguna asistencia para eliminar.
    ''' </summary>
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim idMiembro As UInteger = CInt(selectedRow.Cells("id_asistencia").Value)
                Dim confirmacion As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este asistencia", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    nAsistencias.Eliminar(idMiembro)
                    ActualizarDgv()
                    MsgBox("asistencia eliminado exitosamente.", MsgBoxStyle.Information, "Exito")
                End If
            Else
                Throw New Exception("No se ha seleccionado ninguna asistencia para eliminar.")
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al eliminar la asistencia", ex)
        End Try
    End Sub

    ''' <summary>
    ''' - Si la opción seleccionada en el ComboBox es búsqueda por DNI (índice 0), 
    ''' limpia el campo de búsqueda y actualiza el DataGridView mostrando todas las asistencias.
    ''' - Si la opción seleccionada es búsqueda por fecha (índice 1), restablece los DateTimePicker de fecha de inicio y fin a la fecha actual, 
    ''' limpia sus formatos y actualiza el DataGridView mostrando todas las asistencias.
    ''' </summary>
    Public Sub Reiniciar()
        Try
            Select Case cbOpcionBuscar.SelectedIndex
                Case 0
                    tbBuscar.Clear()
                    ActualizarDgv()
                Case 1
                    dtpFechaInicio.Value = Date.Now
                    dtpFechaFin.Value = Date.Now
                    dtpFechaInicio.Format = DateTimePickerFormat.Custom
                    dtpFechaInicio.CustomFormat = " "
                    dtpFechaFin.Format = DateTimePickerFormat.Custom
                    dtpFechaFin.CustomFormat = " "
                    ActualizarDgv()
            End Select
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al reiniciar el listado. ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Reiniciar". LLama a <see cref="Reiniciar()"/>.
    ''' </summary>
    Private Sub pbReiniciar_Click(sender As Object, e As EventArgs) Handles pbReiniciar.Click
        Try
            Reiniciar()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al reiniciar el listado. ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cerrar el formulario de registro de asistencias.
    ''' - Verifica si existe una instancia activa y no liberada del formulario <see cref="FrmAsistencias"/> asociada a este formulario.
    ''' - Si la instancia existe y no ha sido liberada, la cierra y libera sus recursos llamando a Close() y Dispose().
    ''' </summary>
    Private Sub RegistroAsis_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            If frmAsistencia IsNot Nothing AndAlso Not frmAsistencia.IsDisposed Then
                frmAsistencia.Close()
                frmAsistencia.Dispose()
                frmAsistencia = Nothing
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al liberar recursos al cerrar la aplicación", ex)
        End Try
    End Sub
End Class
