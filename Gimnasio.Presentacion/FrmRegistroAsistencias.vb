Imports Gimnasio.Negocio
Imports Gimnasio.Entidades
Imports LogDeErrores

Public Class FrmRegistroAsistencias
    Private nAsistencias As New NAsistencia()

    Sub New(usuario As Usuarios)
        InitializeComponent()
        If usuario.IdRol = 2 Then
            btnEliminar.Visible = False
            btnEliminar.Enabled = False
        End If
    End Sub

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
    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            If cbOpcionBuscar.SelectedIndex = 0 Then
                Dim dvAsistencias As DataTable = nAsistencias.ListarPorDNI(tbBuscar.Text)
                dgvListado.DataSource = dvAsistencias
                lblTotal.Text = "Total Asistencias: " & dgvListado.Rows.Count.ToString()
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al buscar asistencias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim fechaInicio = dtpFechaInicio.Value.Date
            Dim fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1)
            Dim dvAsistencias = nAsistencias.ListarPorFecha(fechaInicio, fechaFin)
            dgvListado.DataSource = dvAsistencias

            lblTotal.Text = "Total Asistencias: " & dgvListado.Rows.Count.ToString
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al buscar asistencias por fecha: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

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