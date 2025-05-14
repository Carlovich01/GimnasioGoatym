Imports Gimnasio.Negocio
Imports LogDeErrores

''' <summary>
''' Formulario para el registro de asistencias de miembros mediante el ingreso de DNI.
''' Permite registrar el ingreso, mostrar el estado de las membresías y los días restantes.
''' Utiliza la clase <see cref="NAsistencia"/> para la lógica de negocio de asistencias y <see cref="NMembresias"/> para la consulta de membresías.
''' </summary>
Public Class FrmAsistencias
    ''' <summary>
    ''' Instancia de la capa de negocio para asistencias.
    ''' </summary>
    Private nAsistencias As New NAsistencia()

    ''' <summary>
    ''' Evento que se ejecuta al cargar el formulario.
    ''' Inicializa la visibilidad del <see cref="DataGridView"/> de resultados.
    ''' </summary>
    Private Sub frmAsistencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dgvListado.Visible = False
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al cargar el formulario: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al presionar una tecla en el campo de texto del DNI.
    ''' Si se presiona Enter, intenta registrar la asistencia mediante <see cref="NAsistencia.RegistrarIngresoPorDNI"/>.
    ''' Muestra el estado de las membresías y los días restantes utilizando <see cref="NMembresias.ObtenerPorDni"/>.
    ''' </summary>
    ''' <param name="sender">Objeto que genera el evento.</param>
    ''' <param name="e">Argumentos de la tecla presionada.</param>
    Private Sub tbDNI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbDNI.KeyPress
        Try
            dgvListado.Visible = False
            If e.KeyChar = ChrW(Keys.Enter) Then
                Dim dni As String = tbDNI.Text.Trim()
                Dim resultado As String = nAsistencias.RegistrarIngresoPorDNI(dni)
                Select Case resultado
                    Case "Exitoso", "Fallido_Membresia_Inactiva"
                        dgvListado.Visible = True

                        Dim nMembresias As New NMembresias()
                        Dim membresias As DataTable = nMembresias.ObtenerPorDni(dni)

                        Dim nombreMiembro As String = membresias.Rows(0)("nombre_miembro").ToString()

                        labelResultado.Text = If(resultado = "Exitoso",
                                             $"¡Ingreso Exitoso. Bienvenido {nombreMiembro}! El estado de sus planes actualmente es:",
                                             $"Ingreso Erróneo. Posee membresía/s vencidas: {nombreMiembro}. El estado de sus planes actualmente es:")

                        ' Calcula los días restantes para cada membresía
                        If Not membresias.Columns.Contains("dias_restantes") Then
                            membresias.Columns.Add("dias_restantes", GetType(UInteger))
                        End If
                        For Each row As DataRow In membresias.Rows
                            Dim fechaFin As Date = Convert.ToDateTime(row("fecha_fin"))
                            Dim diasRestantes As Integer = (fechaFin - DateTime.Now).Days
                            row("dias_restantes") = If(diasRestantes > 0, diasRestantes, 0)
                        Next

                        dgvListado.DataSource = membresias

                        dgvListado.DefaultCellStyle.ForeColor = Color.Black
                        dgvListado.DefaultCellStyle.BackColor = Color.White
                        dgvListado.Columns(0).Visible = False
                        dgvListado.Columns(1).Visible = False
                        dgvListado.Columns(2).Visible = False
                        dgvListado.Columns(3).HeaderText = "DNI"
                        dgvListado.Columns(4).HeaderText = "APELLIDO"
                        dgvListado.Columns(5).HeaderText = "NOMBRE"
                        dgvListado.Columns(6).HeaderText = "PLAN"
                        dgvListado.Columns(7).Visible = False
                        dgvListado.Columns(8).HeaderText = "DURACION"
                        dgvListado.Columns(9).HeaderText = "FECHA INICIO"
                        dgvListado.Columns(10).HeaderText = "FECHA FIN"
                        dgvListado.Columns(11).HeaderText = "ESTADO"
                        dgvListado.Columns(12).Visible = False
                        dgvListado.Columns(13).Visible = False
                        dgvListado.Columns(14).HeaderText = "DIAS RESTANTES"

                        tbDNI.Text = ""

                    Case "Fallido_DNI_NoEncontrado"
                        labelResultado.Text = "DNI no encontrado. Ingrese nuevamente."
                        tbDNI.Text = ""
                    Case "Fallido_No_Hay_Membresia"
                        labelResultado.Text = "No posee membresías. Inscríbase a algún plan."
                        tbDNI.Text = ""
                    Case Else
                        MessageBox.Show("Error desconocido. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Select
            End If
        Catch ex As Exception
            Logger.LogError("Capa Presentacion ", ex)
            MsgBox("Error al registrar asistencia:" & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
