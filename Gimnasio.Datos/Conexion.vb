Imports System.Data
Imports MySql.Data.MySqlClient
Imports LogDeErrores

''' <summary>
''' Clase base para la gestión de la conexión y operaciones con la base de datos MySQL.
''' Proporciona métodos genéricos para ejecutar consultas y comandos SQL.
''' </summary>
Public Class ConexionBase
    ''' <summary>
    ''' Cadena de conexión a la base de datos MySQL.
    ''' </summary>
    Private connectionString As String = "Server=localhost; Port=3307; Database=goatym2; Uid=root; Pwd=1234;"

    ''' <summary>
    ''' Ejecuta una consulta SQL que retorna un conjunto de resultados.
    ''' </summary>
    ''' <param name="query">Consulta SQL a ejecutar.</param>
    ''' <param name="parameters">Diccionario de parámetros para la consulta (puede ser <c>Nothing</c>).</param>
    ''' <returns><see cref="DataTable"/> con los resultados de la consulta.</returns>
    ''' <exception cref="Exception">Propaga cualquier error ocurrido durante la ejecución.</exception>
    Public Function ExecuteQuery(query As String, parameters As Dictionary(Of String, Object)) As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Using comando As New MySqlCommand(query, conexion)
                    If parameters IsNot Nothing Then
                        For Each param In parameters
                            comando.Parameters.AddWithValue(param.Key, param.Value)
                        Next
                    End If
                    Using adapter As New MySqlDataAdapter(comando)
                        Dim tabla As New DataTable()
                        adapter.Fill(tabla)
                        Return tabla
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Ejecuta un comando SQL que no retorna resultados (INSERT, UPDATE, DELETE).
    ''' </summary>
    ''' <param name="query">Comando SQL a ejecutar.</param>
    ''' <param name="parameters">Diccionario de parámetros para el comando (puede ser <c>Nothing</c>).</param>
    ''' <exception cref="Exception">Propaga cualquier error ocurrido durante la ejecución.</exception>
    Public Sub ExecuteNonQuery(query As String, parameters As Dictionary(Of String, Object))
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Using comando As New MySqlCommand(query, conexion)
                    If parameters IsNot Nothing Then
                        For Each param In parameters
                            comando.Parameters.AddWithValue(param.Key, param.Value)
                        Next
                    End If
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Logger.LogError("Capa Datos", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class
