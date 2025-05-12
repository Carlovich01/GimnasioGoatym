Imports System.IO

Public Class Logger
    Private Shared ReadOnly logFilePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs\log.txt")

    Public Shared Sub LogError(message As String, ex As Exception)
        Try
            ' Crear el directorio Logs si no existe
            Dim logDirectory As String = Path.GetDirectoryName(logFilePath)
            If Not Directory.Exists(logDirectory) Then
                Directory.CreateDirectory(logDirectory)
            End If

            ' Escribir el error en el archivo de log
            Using writer As New StreamWriter(logFilePath, True)
                writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {message}")
                writer.WriteLine($"Detalles: {ex.Message}")
                writer.WriteLine($"StackTrace: {ex.StackTrace}")
                writer.WriteLine(New String("-"c, 50))
            End Using
        Catch ioEx As IOException
            ' Si ocurre un error al escribir el log, no hacemos nada para evitar un bucle infinito
        End Try
    End Sub
End Class
