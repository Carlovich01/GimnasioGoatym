Imports Gimnasio.Negocio
Imports Gimnasio.Entidades
Imports LogDeErrores

''' <summary>
''' Formulario para la gestión y consulta de asistencias de los miembros en el sistema del gimnasio.
''' Permite listar, buscar por DNI o fecha, y eliminar registros de asistencia.
''' Utiliza la clase <see cref="NAsistencia"/> para la lógica de negocio.
''' </summary>
Public Class FrmRegistroAsistencias
    ''' <summary>
    ''' Instancia de la capa de negocio para asistencias.
    ''' </summary>
    Private nAsistencias As New NAsistencia()

    ''' <summary>
    ''' Constructor del formulario de asistencias.
    ''' Configura la interfaz según el rol del usuario.
    ''' </summary>
    ''' <param name="usuario">Instancia de <see cref="Usuarios"/> que representa al usuario logueado.</param>
    Sub New(usuario As Usuarios)
        InitializeComponent()
        If usuario.IdRol = 2 Then
            btnEliminar.Visible = False
            btnEliminar.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cargar el formulario.
    ''' Inicializa el listado de asistencias y configura las columnas del <see cref="DataGridView"/>.
    ''' </summary>
    Private Sub frmRegistroAsistencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()
            dgvListado.Sort(dgvListado.Columns("fecha_ingreso"), System.ComponentModel.ListSortDirection.Descending)
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
            cbOpcionBuscar.SelectedIndex = 1

        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al cargar la pestaña de membresias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el <see cref="DataGridView"/> con la lista de asistencias obtenida desde <see cref="NAsistencia.Listar"/>.
    ''' </summary>
    Public Sub ActualizarDataGridView()
        Try
            Dim dvAsistencias As DataTable = nAsistencias.Listar()
            dgvListado.DataSource = dvAsistencias
            lblTotal.Text = "Total Asistencias: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al cargar las asistencias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar la opción de búsqueda.
    ''' Permite buscar asistencias por DNI o por rango de fechas utilizando los métodos de <see cref="NAsistencia"/>.
    ''' </summary>
    Private Sub cbOpcionBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOpcionBuscar.SelectedIndexChanged
        Try
            ActualizarDataGridView()
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
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al buscar asistencias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cambiar el texto en el campo de búsqueda.
    ''' Permite buscar asistencias por DNI utilizando <see cref="NAsistencia.ListarPorDNI"/>.
    ''' </summary>
    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            If cbOpcionBuscar.SelectedIndex = 0 Then
                Dim dvAsistencias As DataTable = nAsistencias.ListarPorDNI(tbBuscar.Text)
                dgvListado.DataSource = dvAsistencias
                lblTotal.Text = "Total Asistencias: " & dgvListado.Rows.Count.ToString()
                If dgvListado.Rows.Count = 0 And Not String.IsNullOrEmpty(tbBuscar.Text) Then
                    MsgBox("No se encontró ningún miembro con ese criterio.", MsgBoxStyle.Information, "Sin resultados")
                    tbBuscar.Clear()
                    ActualizarDataGridView()
                End If
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al buscar asistencias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón para buscar asistencias por fecha.
    ''' Filtra las asistencias utilizando <see cref="NAsistencia.ListarPorFecha"/>.
    ''' </summary>
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim fechaInicio = dtpFechaInicio.Value.Date
            Dim fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1)
            If fechaInicio > fechaFin Then
                MsgBox("La fecha de inicio no puede ser mayor que la fecha de fin.", MsgBoxStyle.Exclamation, "Error")
                Return
            End If
            Dim dvAsistencias = nAsistencias.ListarPorFecha(fechaInicio, fechaFin)
            dgvListado.DataSource = dvAsistencias
            lblTotal.Text = "Total Asistencias: " & dgvListado.Rows.Count.ToString
            If dgvListado.Rows.Count = 0 Then
                MsgBox("No se encontraron ingresos en el rango de fechas seleccionado.", MsgBoxStyle.Information, "Sin resultados")
                ActualizarDataGridView()
                dtpFechaInicio.Value = DateTime.Now
                dtpFechaFin.Value = DateTime.Now
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al buscar asistencias por fecha: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al hacer clic en el botón "Eliminar".
    ''' Elimina la asistencia seleccionada utilizando <see cref="NAsistencia.Eliminar"/>.
    ''' </summary>
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim idMiembro As UInteger = CInt(selectedRow.Cells("id_asistencia").Value)
                Dim confirmacion As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este asistencia", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    nAsistencias.Eliminar(idMiembro)
                    ActualizarDataGridView()
                    MsgBox("asistencia eliminado exitosamente.", MsgBoxStyle.Information, "Exito")
                End If
            Else
                MsgBox("Seleccione un asistencia para eliminar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al eliminar el asistencia: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
