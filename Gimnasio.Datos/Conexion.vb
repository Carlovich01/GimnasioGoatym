Imports System.Data
Imports MySql.Data.MySqlClient
Imports Gimnasio.Errores
''' <summary>
''' Clase base para la gestión de la conexión y operaciones con la base de datos MySQL.
''' Proporciona métodos genéricos para ejecutar consultas y comandos SQL.
''' </summary>
''' <remarks>
''' Beneficios de utilizar <see cref="ExecuteQuery"/> y <see cref="ExecuteNonQuery"/>:
''' - Centralizan y simplifican el acceso a datos, evitando duplicación de código.
''' - Permiten el uso de parámetros, ayudando a prevenir inyecciones SQL.
''' - Manejan automáticamente la apertura y cierre de conexiones.
''' - Facilitan el mantenimiento y la escalabilidad del acceso a la base de datos.
''' 
''' Todas las operaciones de acceso a datos están envueltas en bloques Try...Catch.
''' - Si ocurre una excepción durante la ejecución de una consulta o comando SQL, el error se registra en el archivo de log 
''' mediante <see cref="ManejarErrores.Log"/>.
''' - Tras registrar el error, la excepción se propaga nuevamente mediante Throw New Exception(ex.Message).
''' </remarks>
Public Class ConexionBase
    ''' <summary>
    ''' Cadena de conexión a la base de datos MySQL.
    ''' </summary>
    Private connectionString As String = "Server=localhost; Port=3307; Database=goatym2; Uid=root; Pwd=1234;"

    ''' <summary>
    ''' Ejecuta una consulta SQL sobre la base de datos MySQL y retorna los resultados en un DataTable. Proceso:
    ''' 1. Abre una conexión a la base de datos utilizando la cadena de conexión definida.
    ''' 2. Crea un comando SQL con la consulta proporcionada y agrega los parámetros especificados (si existen).
    ''' 3. Utiliza un MySqlDataAdapter para ejecutar la consulta y llenar un DataTable con los resultados.
    ''' 4. Retorna el DataTable con los datos obtenidos.
    ''' </summary>
    ''' <param name="query">Consulta SQL a ejecutar.</param>
    ''' <param name="parameters">Diccionario de parámetros para la consulta (puede ser Nothing).</param>
    ''' <returns>DataTable con los resultados de la consulta.</returns>
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
            ManejarErrores.Log("Capa Datos", ex)
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Ejecuta un comando SQL sobre la base de datos MySQL que no retorna resultados (por ejemplo, INSERT, UPDATE o DELETE). Proceso:
    ''' 1. Abre una conexión a la base de datos utilizando la cadena de conexión definida.
    ''' 2. Crea un comando SQL con la instrucción proporcionada y agrega los parámetros especificados (si existen).
    ''' 3. Ejecuta el comando mediante MySqlCommand.ExecuteNonQuery para realizar la operación solicitada.
    ''' 4. No retorna ningún valor, ya que está orientado a operaciones que modifican datos pero no devuelven resultados.
    ''' </summary>
    ''' <param name="query">Comando SQL a ejecutar (INSERT, UPDATE, DELETE, etc.).</param>
    ''' <param name="parameters">Diccionario de parámetros para el comando (puede ser Nothing).</param>
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
            ManejarErrores.Log("Capa Datos", ex)
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class
