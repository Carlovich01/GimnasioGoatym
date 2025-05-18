Imports System.Data
Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports Gimnasio.Errores

''' <summary>
''' Lógica de negocio para la gestión de miembros en el sistema de gimnasio.
''' Interactúa con la capa de datos <see cref="DMiembros"/> y la entidad <see cref="Miembros"/>.
''' Todas las operaciones de la capa de negocio están envueltas en bloques Try...Catch.  
''' Si ocurre una excepción, se registra el error utilizando <see cref="ManejarErrores.Log"/> en un log.txt
''' Luego, la excepción se propaga nuevamente mediante Throw New Exception(ex.Message).
''' </summary>
Public Class NMiembros
    ''' <summary>
    ''' Instancia de la capa de datos para miembros.
    ''' </summary>
    Private dMiembros As New DMiembros()

    ''' <summary>
    ''' Obtiene la lista de todos los miembros registrados con <see cref="DMiembros.Listar()"/>.
    ''' </summary>
    ''' <returns>DataTable con los datos de los miembros.</returns>
    Public Function Listar() As DataTable
        Try
            Return dMiembros.Listar()
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Valida los campos de la entidad <see cref="Miembros"/> antes de realizar operaciones de inserción o actualización.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Miembros"/> a validar.</param>
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
        Else
            If Obj.Telefono.Length > 30 Then
                Throw New Exception("El teléfono no puede tener más de 30 caracteres.")
            End If
            For Each c As Char In Obj.Telefono
                If Char.IsLetter(c) Then
                    Throw New Exception("El teléfono no puede contener letras.")
                End If
            Next
        End If

        If String.IsNullOrWhiteSpace(Obj.Email) Then
            Obj.Email = Nothing
        ElseIf Obj.Email.Length > 100 Then
            Throw New Exception("El email no puede tener más de 100 caracteres.")
        End If
    End Sub

    ''' <summary>
    ''' Obtiene un miembro por su ID con <see cref="DMiembros.ObtenerPorDni(String)"/>.
    ''' Valida que no exista un miembro con el mismo DNI y que los campos sean correctos con <see cref="ValidarCampos(Miembros)"/>.
    ''' Por ultimo, inserta el miembro en la base de datos con <see cref="DMiembros.Insertar(Miembros)"/>.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Miembros"/> a insertar.</param>
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
    ''' Valida que los campos sean correctos con <see cref="ValidarCampos(Miembros)"/>.
    ''' Actualiza los datos de un miembro existente en la base de datos con <see cref="DMiembros.Insertar(Miembros)"/>.
    ''' </summary>
    ''' <param name="Obj">Instancia de <see cref="Miembros"/> con los datos actualizados.</param>
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
    ''' Elimina un miembro del sistema según su id con <see cref="DMiembros.Eliminar(UInteger)"/>.
    ''' </summary>
    ''' <param name="id">Identificador único del miembro a eliminar.</param>
    Public Sub Eliminar(id As UInteger)
        Try
            dMiembros.Eliminar(id)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Realiza una validación y busca miembros por nombre utilizando la capa de datos <see cref="DMiembros.ListarPorNombre(String)"/>.
    ''' </summary>
    ''' <param name="nombre">Nombre o parte del nombre del miembro a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorNombre(nombre As String) As DataTable
        Try
            If nombre.Length > 100 Then
                Throw New Exception("El nombre no puede tener más de 100 caracteres.")
            End If
            Return dMiembros.ListarPorNombre(nombre)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Realiza una validación y obtiene un miembro por su DNI utilizando la capa de datos <see cref="DMiembros.ObtenerPorDni(String)"/>.
    ''' </summary>
    ''' <param name="dni">DNI del miembro a buscar.</param>
    ''' <returns>DataTable con los datos del miembro encontrado.</returns>
    Public Function ObtenerPorDni(dni As String) As DataTable
        Try
            If dni.Length > 15 Then
                Throw New Exception("El DNI no puede tener más de 15 caracteres.")
            End If
            Return dMiembros.ObtenerPorDni(dni)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Realiza una validación y busca miembros por DNI utilizando la capa de datos <see cref="DMiembros.ListarPorDni(String)"/>.
    ''' </summary>
    ''' <param name="dni">DNI o parte del DNI del miembro a buscar.</param>
    ''' <returns>DataTable con los resultados de la búsqueda.</returns>
    Public Function ListarPorDni(dni As String) As DataTable
        Try
            If dni.Length > 15 Then
                Throw New Exception("El DNI no puede tener más de 15 caracteres.")
            End If
            Return dMiembros.ListarPorDni(dni)
        Catch ex As Exception
            ManejarErrores.Log("Capa Negocio", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
