Imports System.IO
'''<summary>
''' Clase utilitaria para el registro de errores en el sistema.
''' Permite guardar mensajes de error y excepciones en un archivo de log ubicado en la carpeta Logs.
''' </summary>
Public Class ManejarErrores
    ''' <summary>
    ''' Ruta completa del archivo de log donde se almacenan los errores.
    ''' </summary>
    Private Shared ReadOnly logFilePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs\log.txt")

    ''' <summary>
    ''' Registra un error en el archivo de log.
    ''' Incluye la fecha y hora, un mensaje personalizado, el mensaje de la excepción y el stack trace.
    ''' Si el directorio de logs no existe, lo crea automáticamente.
    ''' </summary>
    ''' <param name="message">Mensaje personalizado que describe el contexto del error.</param>
    ''' <param name="ex">Excepción capturada que contiene detalles del error.</param>
    Public Shared Sub Log(message As String, ex As Exception)
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

    ''' <summary>
    ''' - Registra la excepción recibida en el log.txt utilizando <see cref="LogError"/> con el mensaje "Capa Presentación".
    ''' - Muestra un mensaje de error al usuario mediante un cuadro de diálogo, con un mensaje personalizado  y el mensaje de la excepción.
    ''' Este método asegura que todos los errores sean registrados y notificados al usuario. Se utiliza en los bloques Try-Catch.
    ''' </summary>
    ''' <param name="mensajeUsuario">Mensaje personalizado que se mostrará al usuario.</param>
    ''' <param name="ex">Excepción capturada que será registrada y cuyo mensaje se mostrará al usuario.</param>
    Public Shared Sub Mostrar(mensajeUsuario As String, ex As Exception)
        Log("Capa Presentación", ex)
        MsgBox(mensajeUsuario & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
    End Sub

End Class
