Imports Gimnasio.Entidades
Imports Gimnasio.Negocio
Imports LogDeErrores

Public Class FrmPagos
    Private nPagos As New NPagos()

    Sub New(usuario As Usuarios)
        InitializeComponent()
        If usuario.IdRol = 2 Then
            btnEliminar.Visible = False
            btnEliminar.Enabled = False
        End If
    End Sub
    Private Sub frmPagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()
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
            dgvListado.Columns(10).HeaderText = "FECHA PAGO"
            dgvListado.Columns(11).HeaderText = "ENCARGADO"
            cbOpcionBuscar.SelectedIndex = 0
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al cargar pestaña de membresias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ActualizarDataGridView()
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
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al cargar las membresias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnBuscarFecha_Click(sender As Object, e As EventArgs) Handles BtnBuscarFecha.Click
        Try
            Dim fechaInicio = dtpFechaInicio.Value.Date
            Dim fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1)
            Dim dvPagos = nPagos.ListarPorFecha(fechaInicio, fechaFin)
            dgvListado.DataSource = dvPagos

            lblTotal.Text = "Cantidad Pagos: " & dgvListado.Rows.Count.ToString

            Dim totalIngresos As Decimal = 0
            For Each row As DataGridViewRow In dgvListado.Rows
                totalIngresos += Convert.ToDecimal(row.Cells("monto").Value)
            Next

            lbIngresosTotales.Text = "Ingresos Totales: $" & totalIngresos.ToString
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al buscar pagos por fecha: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cbOpcionBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOpcionBuscar.SelectedIndexChanged
        Try
            ActualizarDataGridView()
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
                    Dim dvPagos As DataTable = nPagos.ListarPorMetodoPago(cbOpcionBuscar.SelectedItem.ToString)
                    dgvListado.DataSource = dvPagos
                    lblTotal.Text = "Cantidad Pagos: " & dgvListado.Rows.Count.ToString()
                    Dim totalIngresos As Decimal = 0
                    For Each row As DataGridViewRow In dgvListado.Rows
                        totalIngresos += Convert.ToDecimal(row.Cells("monto").Value)
                    Next
                    lbIngresosTotales.Text = "Ingresos Totales: $" & totalIngresos.ToString()
            End Select
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al buscar pagos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            Select Case cbOpcionBuscar.SelectedIndex
                Case 1
                    Dim dvPagos As DataTable = nPagos.ListarPorDni(tbBuscar.Text)
                    dgvListado.DataSource = dvPagos
                    lblTotal.Text = "Total Pagos: " & dgvListado.Rows.Count.ToString()
                    Dim totalIngresos As Decimal = 0
                    For Each row As DataGridViewRow In dgvListado.Rows
                        totalIngresos += Convert.ToDecimal(row.Cells("monto").Value)
                    Next
                    lbIngresosTotales.Text = "Ingresos Totales: $" & totalIngresos.ToString()
                Case 2
                    Dim dvPagos As DataTable = nPagos.ListarPorNombrePlan(tbBuscar.Text)
                    dgvListado.DataSource = dvPagos
                    lblTotal.Text = "Total Pagos: " & dgvListado.Rows.Count.ToString()
                    Dim totalIngresos As Decimal = 0
                    For Each row As DataGridViewRow In dgvListado.Rows
                        totalIngresos += Convert.ToDecimal(row.Cells("monto").Value)
                    Next
                    lbIngresosTotales.Text = "Ingresos Totales: $" & totalIngresos.ToString()
            End Select
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al buscar pagos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnBuscarMonto_Click(sender As Object, e As EventArgs) Handles btnBuscarMonto.Click
        Try
            Dim dvPagos As DataTable = nPagos.ListarPorMontos(CDec(tbMontoInicial.Text), CDec(tbMontoFinal.Text))
            dgvListado.DataSource = dvPagos
            lblTotal.Text = "Total Pagos: " & dgvListado.Rows.Count.ToString()
            Dim totalIngresos As Decimal = 0
            For Each row As DataGridViewRow In dgvListado.Rows
                totalIngresos += Convert.ToDecimal(row.Cells("monto").Value)
            Next
            lbIngresosTotales.Text = "Ingresos Totales: $" & totalIngresos.ToString()
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al buscar pagos por monto: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim idMiembro As UInteger = CInt(selectedRow.Cells("id_pago").Value)
                Dim confirmacion As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este Pago", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    nPagos.Eliminar(idMiembro)
                    ActualizarDataGridView()
                    MsgBox("Pago eliminado exitosamente.", MsgBoxStyle.Information, "Exito")
                End If
            Else
                MsgBox("Seleccione un Pago para eliminar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al eliminar el Pago: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class