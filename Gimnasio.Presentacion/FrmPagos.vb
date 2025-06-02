Imports Gimnasio.Entidades
Imports Gimnasio.Negocio
Imports Gimnasio.Errores

''' <summary>
''' Formulario para la gestión y consulta de pagos en el sistema del gimnasio. Permite listar, buscar, actualizar y eliminar pagos.
''' Utiliza la clase <see cref="Gimnasio.Negocio.NPagos"/> para la lógica de negocio y la clase <see cref="Pagos"/> como entidad.
''' </summary>
''' <remarks>
''' Todas las operaciones de esta capa están envueltas en bloques Try...Catch. 
''' El manejo de errores se realiza a través de <see cref="Gimnasio.Errores.ManejarErrores.Mostrar(String, Exception)"/>
''' que permite guardar el error en un log.txt y a su vez mostrar un mensaje al usuario.
''' </remarks>
Public Class FrmPagos
    ''' <summary>
    ''' Instancia de la capa de negocio para pagos.
    ''' </summary>
    Private nPagos As New NPagos()

    ''' <summary>
    ''' Constructor del formulario de pagos. Si es recepcionista oculta el boton de Actualizar y Eliminar.
    ''' </summary>
    ''' <param name="usuario">Instancia de <see cref="Usuarios"/> que representa al usuario logueado.</param>
    Friend Sub New(usuario As Usuarios)
        InitializeComponent()
        If usuario.IdRol = 2 Then
            btnActualizar.Visible = False
            btnActualizar.Enabled = False
            btnEliminar.Visible = False
            btnEliminar.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cargar el formulario FrmPagos.
    ''' Inicializa el listado de pagos, configura la visibilidad y los encabezados de las columnas del DataGridView dgvListado,
    ''' y establece la opción predeterminada del ComboBox de búsqueda.
    ''' También inicializa los controles de selección de fecha dtpFechaInicio y dtpFechaFin con un formato personalizado vacío.
    ''' </summary>
    Private Sub frmPagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDgv()
            dgvListado.Columns(0).Visible = False
            dgvListado.Columns(1).Visible = False
            dgvListado.Columns(2).Visible = False
            dgvListado.Columns(0).HeaderText = "ID PAGO"
            dgvListado.Columns(1).HeaderText = "ID MEMBRESIA"
            dgvListado.Columns(2).HeaderText = "ID USUARIO REGISTRO"
            dgvListado.Columns(3).HeaderText = "APELLIDO MIEMBRO"
            dgvListado.Columns(4).HeaderText = "NOMBRE MIEMBRO"
            dgvListado.Columns(5).HeaderText = "DNI MIEMBRO"
            dgvListado.Columns(6).HeaderText = "NOMBRE PLAN"
            dgvListado.Columns(7).HeaderText = "MONTO PAGADO"
            dgvListado.Columns(8).HeaderText = "METODO PAGO"
            dgvListado.Columns(9).HeaderText = "NUMERO COMPROBANTE"
            dgvListado.Columns(10).HeaderText = "NOTAS"
            dgvListado.Columns(11).HeaderText = "FECHA PAGO"
            dgvListado.Columns(12).HeaderText = "ENCARGADO"
            cbOpcionBuscar.SelectedIndex = 0
            dtpFechaInicio.Format = DateTimePickerFormat.Custom
            dtpFechaInicio.CustomFormat = " "
            dtpFechaFin.Format = DateTimePickerFormat.Custom
            dtpFechaFin.CustomFormat = " "
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar pestaña de pagos. ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el DataGridView con la lista completa de pagos obtenida desde la capa de negocio mediante <see cref="NPagos.Listar"/>.
    ''' Actualiza la etiqueta lblTotal con la cantidad de pagos listados
    ''' y calcula el total de ingresos sumando los valores de la columna "monto" de cada fila, mostrando el resultado en lbIngresosTotales.
    ''' </summary>
    Public Sub ActualizarDgv()
        Try
            Dim dvMembresias As DataTable = nPagos.Listar()
            dgvListado.DataSource = dvMembresias
            lblTotal.Text = "Cantidad Pagos: " & dgvListado.Rows.Count.ToString()
            Dim totalIngresos As Decimal = 0
            For Each row As DataGridViewRow In dgvListado.Rows
                totalIngresos += Convert.ToDecimal(row.Cells("monto").Value)
            Next

            lbIngresosTotales.Text = "Ingresos Totales: $" & totalIngresos.ToString()

        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar listado de pagos. ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el DataGridView con una lista específica de pagos proporcionada en el parámetro listado.
    ''' Actualiza la etiqueta lblTotal con la cantidad de pagos listados
    ''' y calcula el total de ingresos sumando los valores de la columna "monto" de cada fila, mostrando el resultado en lbIngresosTotales.
    ''' </summary>
    ''' <param name="listado"> DataTable que contiene la lista de pagos a mostrar en el DataGridView.</param>
    Public Sub ActualizarDgv(listado As DataTable)
        Try
            dgvListado.DataSource = listado
            lblTotal.Text = "Cantidad Pagos: " & dgvListado.Rows.Count.ToString()
            Dim totalIngresos As Decimal = 0
            For Each row As DataGridViewRow In dgvListado.Rows
                totalIngresos += Convert.ToDecimal(row.Cells("monto").Value)
            Next

            lbIngresosTotales.Text = "Ingresos Totales: $" & totalIngresos.ToString()

        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar listado de pagos. ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Habilita el panel de listado de pagos. Oculta el panel de edición de pagos.
    ''' </summary>
    Public Sub HabilitarListado()
        Try
            panelListado.Enabled = True
            panelEdicionPago.Visible = False
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al habilitar el listado de pagos", ex)
        End Try
    End Sub

    ''' <summary>
    ''' - Hace visible el panel de edición de pagos y lo ajusta para ocupar todo el espacio disponible del formulario.
    ''' - Deshabilita el panel de listado de pagos para evitar la interacción con el listado mientras se edita un pago.
    ''' - Limpia los campos de monto, comprobante y notas.
    ''' - Establece el método de pago predeterminado seleccionando el primer elemento del ComboBox.
    ''' </summary>
    Public Sub HabilitarEdicionPago()
        Try
            panelEdicionPago.Visible = True
            panelEdicionPago.Dock = DockStyle.Fill
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
    ''' Evento que se ejecuta al hacer clic en el botón "Actualizar" en el formulario de pagos.
    ''' - Verifica si hay una fila seleccionada en el DataGridView.
    '''     - Si hay una selección:
    '''         - Llama a <see cref="HabilitarEdicionPago"/> para mostrar el panel de edición.
    '''         - Carga en los campos de edición los datos del pago seleccionado.
    '''     - Si no hay ninguna fila seleccionada, lanza una excepción informando que no se ha seleccionado ningún pago.
    ''' </summary>
    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                HabilitarEdicionPago()
                tbIDpago.Text = selectedRow.Cells("id_pago").Value
                tbMonto.Text = selectedRow.Cells("monto").Value
                cbMetodo.SelectedItem = selectedRow.Cells("metodo").Value
                tbComprobante.Text = If(selectedRow.Cells("comprobante").Value IsNot Nothing, selectedRow.Cells("comprobante").Value.ToString(), "")
                tbNotas.Text = If(selectedRow.Cells("notas").Value IsNot Nothing, selectedRow.Cells("notas").Value.ToString(), "")
            Else
                Throw New Exception("No se ha seleccionado ningún pago.")
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al preparar la edición del pago.", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Guardar" en el formulario de edición de pagos.
    ''' - Valida que el campo monto no este vacio y que sea un numero valido, sino lanza una excepción.
    ''' - Si las validaciones son correctas, crea un nuevo objeto Pagos con los datos ingresados y lo actualiza en la base de datos.
    ''' - Muestra un mensaje de éxito y actualiza el listado de pagos.
    ''' </summary>
    Private Sub btnGuardarPago_Click(sender As Object, e As EventArgs) Handles btnGuardarPago.Click
        Try
            If String.IsNullOrWhiteSpace(tbMonto.Text) Then
                Throw New Exception("Complete los campos obligatorios(*).")
            End If
            If Not IsNumeric(tbMonto.Text) OrElse CDec(tbMonto.Text) <= 0 Then
                Throw New Exception("El monto debe ser un número positivo.")
            End If
            Dim pago As New Pagos
            pago.IdPago = CUInt(tbIDpago.Text)
            pago.MontoPagado = CDec(tbMonto.Text)
            pago.MetodoPago = cbMetodo.SelectedItem.ToString()
            pago.NumeroComprobante = tbComprobante.Text
            pago.Notas = tbNotas.Text

            nPagos.Actualizar(pago)
            MsgBox("Pago actualizado correctamente.", MsgBoxStyle.Information, "Éxito")
            ActualizarDgv()
            HabilitarListado()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al guardar el pago.", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar el valor del DateTimePicker para la fecha de inicio. Le da un formato corto a la fecha para que sea visible.
    ''' </summary>
    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        Try
            dtpFechaInicio.Format = DateTimePickerFormat.Short
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cambiar la fecha de inicio. ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar el valor del DateTimePicker para la fecha de fin. Le da un formato corto a la fecha para que sea visible.
    ''' </summary>
    Private Sub dtpFechaFin_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFin.ValueChanged
        Try
            dtpFechaFin.Format = DateTimePickerFormat.Short
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cambiar la fecha de fin. ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón para buscar pagos por fecha en el formulario de pagos.
    ''' - Obtiene las fechas seleccionadas en los controles dtpFechaInicio y dtpFechaFin.
    ''' - Ajusta la fecha de fin para incluir todo el día seleccionado (agregando un día y restando un tick).
    ''' - Valida que la fecha de inicio no sea mayor que la fecha de fin; si lo es, lanza una excepción.
    ''' - Si las fechas son válidas, utiliza el método <see cref="NPagos.ListarPorFecha"/> para filtrar los pagos dentro del rango especificado.
    ''' - Actualiza el DataGridView con los resultados filtrados mediante <see cref="ActualizarDgv"/>.
    ''' </summary>
    Private Sub btnBuscarFecha_Click(sender As Object, e As EventArgs) Handles BtnBuscarFecha.Click
        Try
            Dim fechaInicio = dtpFechaInicio.Value.Date
            Dim fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1)
            If fechaInicio > fechaFin Then
                Throw New Exception("La fecha de inicio no puede ser mayor que la fecha de fin.")
            End If
            ActualizarDgv(nPagos.ListarPorFecha(fechaInicio, fechaFin))
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al buscar pagos por fecha. ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar la opción seleccionada en el ComboBox de búsqueda (cbOpcionBuscar).
    ''' - Limpia los campos de búsqueda y restablece los controles de fecha y monto a sus valores iniciales.
    ''' - Actualiza el DataGridView con la lista completa de pagos.
    ''' - Según la opción elegida:
    '''   * Opción 0 (por fecha): muestra el panel de fechas y oculta los demás campos de búsqueda.
    '''   * Opción 1 (por DNI) y 2 (por nombre de plan): habilita el campo de texto para búsqueda y oculta los paneles de fecha y monto.
    '''   * Opción 3 (por monto): muestra el panel de montos y oculta los demás campos.
    '''   * Opciones 4 a 10 (por método de pago): oculta todos los campos de búsqueda y filtra automáticamente los pagos por el método seleccionado 
    '''   con <see cref="nPagos.ListarPorMetodoPago"/>
    ''' </summary>

    Private Sub cb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOpcionBuscar.SelectedIndexChanged
        Try
            tbBuscar.Clear()
            tbMontoInicial.Clear()
            tbMontoFinal.Clear()
            dtpFechaInicio.Value = Date.Now
            dtpFechaFin.Value = Date.Now
            dtpFechaInicio.Format = DateTimePickerFormat.Custom
            dtpFechaInicio.CustomFormat = " "
            dtpFechaFin.Format = DateTimePickerFormat.Custom
            dtpFechaFin.CustomFormat = " "
            ActualizarDgv()

            Select Case cbOpcionBuscar.SelectedIndex
                Case 0
                    tbBuscar.Visible = False
                    tbBuscar.Enabled = False
                    PanelFecha.Visible = True
                    PanelMonto.Visible = False

                Case 1
                    tbBuscar.Visible = True
                    tbBuscar.Enabled = True
                    PanelFecha.Visible = False
                    PanelMonto.Visible = False

                Case 2
                    tbBuscar.Visible = True
                    tbBuscar.Enabled = True
                    PanelFecha.Visible = False
                    PanelMonto.Visible = False

                Case 3
                    tbBuscar.Visible = False
                    tbBuscar.Enabled = False
                    PanelFecha.Visible = False
                    PanelMonto.Visible = True

                Case 4, 5, 6, 7, 8, 9, 10
                    tbBuscar.Visible = False
                    tbBuscar.Enabled = False
                    PanelFecha.Visible = False
                    PanelMonto.Visible = False

                    ActualizarDgv(nPagos.ListarPorMetodoPago(cbOpcionBuscar.SelectedItem.ToString))
            End Select
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cambiar la opción de búsqueda. ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al modificar el texto en el campo de búsqueda (tbBuscar).
    ''' Su función es filtrar dinámicamente los pagos mostrados en el DataGridView según el criterio seleccionado en el ComboBox de búsqueda.
    ''' - Si la opción seleccionada es 1 (DNI), invoca <see cref="NPagos.ListarPorDni"/> pasando el texto ingresado y actualiza el listado.
    ''' - Si la opción seleccionada es 2 (Nombre plan), invoca <see cref="NPagos.ListarPorNombrePlan"/> con el texto ingresado y actualiza el listado.
    ''' </summary>
    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            Select Case cbOpcionBuscar.SelectedIndex
                Case 1
                    ActualizarDgv(nPagos.ListarPorDni(tbBuscar.Text))
                Case 2
                    ActualizarDgv(nPagos.ListarPorNombrePlan(tbBuscar.Text))
            End Select
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al buscar pagos. ", ex)
        End Try
    End Sub


    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón para buscar pagos por monto (btnBuscarMonto).
    ''' Permite filtrar los pagos mostrados en el DataGridView según un rango de montos especificado por el usuario.
    ''' - Valida que ambos campos de monto (tbMontoInicial y tbMontoFinal) no estén vacíos. Verifica tambien que sean numéricos positivos.
    ''' - Comprueba que el monto inicial no sea mayor que el monto final.
    ''' - Si todas las validaciones son correctas, invoca <see cref="NPagos.ListarPorMontos"/> pasando los valores convertidos a decimal
    '''   y actualiza el DataGridView con los resultados filtrados.
    ''' </summary>
    Private Sub btnBuscarMonto_Click(sender As Object, e As EventArgs) Handles btnBuscarMonto.Click
        Try
            If String.IsNullOrWhiteSpace(tbMontoInicial.Text) Or String.IsNullOrWhiteSpace(tbMontoFinal.Text) Then
                Throw New Exception("Los montos no pueden estar vacíos.")
            End If
            If Not IsNumeric(tbMontoInicial.Text) Or Not IsNumeric(tbMontoFinal.Text) Then
                MsgBox("Los montos deben ser numéricos.", MsgBoxStyle.Exclamation, "Error")
                Throw New Exception("Los montos deben ser numéricos.")
            End If
            If CDec(tbMontoInicial.Text) <= 0 Or CDec(tbMontoFinal.Text) <= 0 Then
                Throw New Exception("Los montos deben ser mayores a cero.")
            End If
            If CDec(tbMontoInicial.Text) > CDec(tbMontoFinal.Text) Then
                Throw New Exception("El monto inicial no puede ser mayor que el monto final.")
            End If
            ActualizarDgv(nPagos.ListarPorMontos(tbMontoInicial.Text, tbMontoFinal.Text))
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al buscar pagos por monto. ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Eliminar" (btnEliminar).
    ''' - Verifica si hay una fila seleccionada en el DataGridView.
    ''' - Si hay una selección, obtiene el identificador del pago ("id_pago") de la fila seleccionada.
    ''' - Solicita confirmación al usuario mediante un cuadro de diálogo antes de proceder con la eliminación.
    ''' - Si el usuario confirma, invoca <see cref="NPagos.Eliminar"/> para eliminar el pago y actualiza el listado de pago.
    ''' - Muestra un mensaje de éxito si la eliminación se realiza correctamente.
    ''' - Si no hay ninguna fila seleccionada, lanza una excepción.
    ''' </summary>
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                Dim idMiembro As UInteger = CInt(selectedRow.Cells("id_pago").Value)
                Dim confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar este Pago", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    nPagos.Eliminar(idMiembro)
                    ActualizarDgv()
                    MsgBox("Pago eliminado exitosamente.", MsgBoxStyle.Information, "Exito")
                End If
            Else
                Throw New Exception("No se ha seleccionado ningún pago.")
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al eliminar el Pago. ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' - Restablece los campos de búsqueda y filtros según la opción seleccionada en el ComboBox:
    '''     - Opción 0 (por fecha): reinicia los controles de fecha al valor actual y les aplica un formato vacío y actualiza el listado completo de pagos.
    '''     - Opción 1 o 2 (por DNI o por nombre de plan): limpia el campo de búsqueda y actualiza el listado completo de pagos.
    '''     - Opción 3 (por monto): limpia los campos de monto inicial y final y actualiza el listado completo de pagos.
    '''     - Opciones 4 a 10 (por método de pago): actualiza el listado completo de pagos y restablece la opción seleccionada 
    '''       en el ComboBox a la opción predeterminada (0).
    ''' </summary>
    Public Sub Reiniciar()
        Try
            Select Case cbOpcionBuscar.SelectedIndex
                Case 0
                    dtpFechaInicio.Value = Date.Now
                    dtpFechaFin.Value = Date.Now
                    dtpFechaInicio.Format = DateTimePickerFormat.Custom
                    dtpFechaInicio.CustomFormat = " "
                    dtpFechaFin.Format = DateTimePickerFormat.Custom
                    dtpFechaFin.CustomFormat = " "
                    ActualizarDgv()
                Case 1, 2
                    tbBuscar.Clear()
                    ActualizarDgv()
                Case 3
                    tbMontoInicial.Clear()
                    tbMontoFinal.Clear()
                    ActualizarDgv()
                Case 4, 5, 6, 7, 8, 9, 10
                    ActualizarDgv()
                    cbOpcionBuscar.SelectedIndex = 0
            End Select
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al reiniciar el listado. ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Reiniciar" (pbReiniciar) en el formulario de pagos. Llama al método <see cref="Reiniciar"/> 
    ''' </summary>
    Private Sub pbReiniciar_Click(sender As Object, e As EventArgs) Handles pbReiniciar.Click
        Try
            Reiniciar()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al reiniciar el listado. ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Cancelar" durante la edición de un pago. Llama al método <see cref="HabilitarListado"/>
    ''' </summary>
    Private Sub btnCancelarPago_Click(sender As Object, e As EventArgs) Handles btnCancelarPago.Click
        Try
            HabilitarListado()
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cancelar la edición del pago.", ex)
        End Try
    End Sub
End Class
