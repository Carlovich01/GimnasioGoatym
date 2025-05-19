Imports Gimnasio.Negocio
Imports Gimnasio.Errores

''' <summary>
''' Formulario para el registro de asistencias de miembros mediante el ingreso de DNI.
''' Permite registrar el ingreso, mostrar el estado de las membresías y los días restantes.
''' Utiliza la clase <see cref="NAsistencia"/> para la lógica de negocio de asistencias y <see cref="NMembresias"/> para la consulta de membresías.
''' </summary>
''' <remarks>
''' Todas las operaciones de esta capa están envueltas en bloques Try...Catch. 
''' El manejo de errores se realiza a través de <see cref="Gimnasio.Errores.ManejarErrores.Mostrar(String, Exception)"/>
''' que permite guardar el error en un log.txt y a su vez mostrar un mensaje al usuario. 
''' </remarks>
Public Class FrmAsistencias
    ''' <summary>
    ''' Instancia de la capa de negocio para asistencias.
    ''' </summary>
    Private nAsistencias As New NAsistencia()

    ''' <summary>
    ''' Referencia al formulario <see cref="FrmRegistroAsistencias"/> desde el formulario de asistencias.
    ''' </summary>
    Private frmRegistro As FrmRegistroAsistencias

    ''' <summary>
    ''' Constructor del formulario <see cref="FrmAsistencias"/>.
    ''' - Inicializa los componentes visuales del formulario llamando a <see cref="InitializeComponent"/>.
    ''' - Recibe una instancia de <see cref="FrmRegistroAsistencias"/> como parámetro y la asigna al campo privado <see cref="frmRegistro"/>.
    ''' </summary>
    ''' <param name="frmRegistro">Instancia de <see cref="FrmRegistroAsistencias"/> que permite la interacción entre formularios.</param>
    Public Sub New(frmRegistro As FrmRegistroAsistencias)
        InitializeComponent()
        Me.frmRegistro = frmRegistro
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al cargar el formulario. Oculta el DataGriedView.
    ''' </summary>
    Private Sub frmAsistencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dgvListado.Visible = False
            labelResultado.Text = ""
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al cargar el formulario", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al presionar una tecla en el campo de texto del DNI.
    ''' - Si la tecla presionada es Enter, intenta registrar la asistencia del miembro mediante <see cref="NAsistencia.RegistrarIngresoPorDNI"/>.
    ''' - Llama a <see cref="FrmRegistroAsistencias.ActualizarDgv"/> para actualizar el listado general de asistencias.
    ''' - Si el resultado es "Exitoso" o "Fallido_Membresia_Inactiva":
    '''     - Muestra el DataGridView con el estado de las membresías del miembro, calculando y mostrando los días restantes de cada plan.
    '''     - Muestra un mensaje de bienvenida o advertencia según el resultado.
    ''' - Si el resultado es "Fallido_DNI_NoEncontrado", informa que el DNI no fue encontrado y solicita reingreso.
    ''' - Si el resultado es "Fallido_No_Hay_Membresia", informa que no posee membresías activas y sugiere inscribirse a un plan.
    ''' - En cualquier otro caso, lanza una excepción indicando un error desconocido.
    ''' - Limpia el campo de texto del DNI tras cada intento.
    ''' </summary>
    Private Sub tbDNI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbDNI.KeyPress
        Try
            dgvListado.Visible = False
            If e.KeyChar = ChrW(Keys.Enter) Then
                Dim dni As String = tbDNI.Text.Trim()
                Dim resultado As String = nAsistencias.RegistrarIngresoPorDNI(dni)
                frmRegistro.ActualizarDgv()
                Select Case resultado
                    Case "Exitoso", "Fallido_Membresia_Inactiva"
                        dgvListado.Visible = True
                        Dim nMembresias As New NMembresias()
                        Dim membresias As DataTable = nMembresias.ObtenerPorDni(dni)
                        Dim nombreMiembro As String = membresias.Rows(0)("nombre_miembro").ToString()
                        labelResultado.Text = If(resultado = "Exitoso",
                                             $"¡Ingreso Exitoso. Bienvenido {nombreMiembro}! El estado de sus planes actualmente es:",
                                             $"Ingreso Erróneo. Posee membresía/s vencidas: {nombreMiembro}. El estado de sus planes actualmente es:")
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
                        Throw New Exception("Error desconocido al registrar asistencia.")
                End Select
            End If
        Catch ex As Exception
            ManejarErrores.Mostrar("Error al registrar asistencia", ex)
        End Try
    End Sub
End Class
