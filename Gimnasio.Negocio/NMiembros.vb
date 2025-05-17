Imports System.Data
Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports Gimnasio.Errores

''' <summary>
''' Lógica de negocio para la gestión de miembros en el sistema de gimnasio.
''' Interactúa con la capa de datos <see cref="DMiembros"/> y la entidad <see cref="Miembros"/>.
''' </summary>
Public Class NMiembros
    ''' <summary>
    ''' Instancia de la capa de datos para miembros.
    ''' </summary>
    Private dMiembros As New DMiembros()

    ''' <summary>
    ''' Obtiene la lista de todos los miembros registrados.
    ''' </summary>
    ''' <returns><see cref="DataTable"/> con los datos de los miembros.</returns>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Function Listar() As DataTable
        Dim dvMiembros As DataTable
        Try
            dvMiembros = dMiembros.Listar()
            Return dvMiembros
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Valida los campos de la entidad <see cref="Miembros"/> antes de realizar operaciones de inserción o actualización.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Miembros"/> a validar.</param>
    ''' <exception cref="Exception">Se lanza si algún campo no cumple con las reglas de negocio.</exception>
    Private Sub ValidarCampos(Obj As Miembros)
        If Obj.Dni.Length > 15 Then
            Throw New Exception("El DNI no puede tener más de 15 caracteres.")
        End If

        For Each c As Char In Obj.Dni
            If Not Char.IsDigit(c) Then
                Throw New Exception("El DNI solo puede contener números.")
            End If
        Next

        If Obj.Nombre.Length > 100 Then
            Throw New Exception("El nombre no puede tener más de 100 caracteres.")
        End If

        For Each c As Char In Obj.Nombre
            If Char.IsDigit(c) Then
                Throw New Exception("El nombre no puede contener números.")
            End If
        Next

        If Obj.Apellido.Length > 100 Then
            Throw New Exception("El apellido no puede tener más de 100 caracteres.")
        End If

        For Each c As Char In Obj.Apellido
            If Char.IsDigit(c) Then
                Throw New Exception("El apellido no puede contener números.")
            End If
        Next

        If String.IsNullOrWhiteSpace(Obj.Genero) Then
            Obj.Genero = Nothing
        End If

        If String.IsNullOrWhiteSpace(Obj.Telefono) Then
            Obj.Telefono = Nothing
        ElseIf Obj.Telefono.Length > 30 Then
            Throw New Exception("El teléfono no puede tener más de 30 caracteres.")
        End If

        For Each c As Char In Obj.Telefono
            If Char.IsLetter(c) Then
                Throw New Exception("El teléfono no puede contener letras.")
            End If
        Next

        If String.IsNullOrWhiteSpace(Obj.Email) Then
            Obj.Email = Nothing
        ElseIf Obj.Email.Length > 100 Then
            Throw New Exception("El email no puede tener más de 100 caracteres.")
        End If
    End Sub

    ''' <summary>
    ''' Inserta un nuevo miembro en el sistema.
    ''' Valida que no exista un miembro con el mismo DNI y que los campos sean correctos.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Miembros"/> a insertar.</param>
    ''' <exception cref="Exception">Se lanza si el DNI ya existe o si hay errores de validación.</exception>
    Public Sub Insertar(Obj As Miembros)
        Try
            Dim existeDni As DataTable = dMiembros.ObtenerPorDni(Obj.Dni)
            If existeDni.Rows.Count > 0 Then
                Throw New Exception("El DNI ya está registrado.")
            End If
            ValidarCampos(Obj)
            dMiembros.Insertar(Obj)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza los datos de un miembro existente.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Miembros"/> con los datos actualizados.</param>
    ''' <exception cref="Exception">Se lanza si hay errores de validación o de la capa de datos.</exception>
    Public Sub Actualizar(Obj As Miembros)
        Try
            ValidarCampos(Obj)
            dMiembros.Actualizar(Obj)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Elimina un miembro del sistema según su identificador.
    ''' </summary>
    ''' <param name="id">Identificador único del miembro a eliminar.</param>
    ''' <exception cref="Exception">Propaga excepciones de la capa de datos.</exception>
    Public Sub Eliminar(id As UInteger)
        Try
            dMiembros.Eliminar(id)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Busca miembros por nombre utilizando la capa de datos <see cref="DMiembros.ListarPorNombre"/>.
    ''' </summary>
    ''' <param name="nombre">Nombre o parte del nombre del miembro a buscar.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    ''' <exception cref="Exception">Se lanza si el nombre excede el límite permitido o por errores de la capa de datos.</exception>
    Public Function ListarPorNombre(nombre As String) As DataTable
        Try
            If nombre.Length > 100 Then
                Throw New Exception("El nombre no puede tener más de 100 caracteres.")
            End If
            Dim dvMiembros As DataTable = dMiembros.ListarPorNombre(nombre)
            Return dvMiembros
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene un miembro por su DNI utilizando la capa de datos <see cref="DMiembros.ObtenerPorDni"/>.
    ''' </summary>
    ''' <param name="dni">DNI del miembro a buscar.</param>
    ''' <returns><see cref="DataTable"/> con los datos del miembro encontrado.</returns>
    ''' <exception cref="Exception">Se lanza si el DNI excede el límite permitido o por errores de la capa de datos.</exception>
    Public Function ObtenerPorDni(dni As String) As DataTable
        Try
            If dni.Length > 15 Then
                Throw New Exception("El DNI no puede tener más de 15 caracteres.")
            End If
            Dim dvMiembros As DataTable = dMiembros.ObtenerPorDni(dni)
            Return dvMiembros
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Busca miembros por DNI utilizando la capa de datos <see cref="DMiembros.ListarPorDni"/>.
    ''' </summary>
    ''' <param name="dni">DNI o parte del DNI del miembro a buscar.</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la búsqueda.</returns>
    ''' <exception cref="Exception">Se lanza si el DNI excede el límite permitido o por errores de la capa de datos.</exception>
    Public Function ListarPorDni(dni As String) As DataTable
        Try
            If dni.Length > 15 Then
                Throw New Exception("El DNI no puede tener más de 15 caracteres.")
            End If
            Dim dvMiembros As DataTable = dMiembros.ListarPorDni(dni)
            Return dvMiembros
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
