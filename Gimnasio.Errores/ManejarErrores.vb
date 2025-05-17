Imports System.IO
'''<summary>
''' Clase utilitaria para el registro de errores en el sistema.
''' Permite guardar mensajes de error y excepciones en un archivo de log ubicado en la carpeta Logs.
''' Ademas permite mostrar mensajes de error al usuario mediante cuadros de diálogo.
''' </summary>
Public Class ManejarErrores
    ''' <summary>
    ''' Ruta completa del archivo de log donde se almacenan los errores.
    ''' </summary>
    Private Shared ReadOnly logFilePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs\log.txt")

    ''' <summary>
    ''' 1. Verifica si el directorio de logs existe; si no, lo crea automáticamente.
    ''' 2. Abre (o crea) el archivo log.txt en modo adjuntar dentro de la carpeta Logs de la aplicación.
    ''' 3. Escribe una entrada de error que incluye:
    '''    - Fecha y hora del registro.
    '''    - Mensaje personalizado que describe el contexto del error.
    '''    - Mensaje de la excepción capturada.
    '''    - Stack trace de la excepción.
    ''' 4. Separa cada registro con una línea divisoria.
    ''' 5. Si ocurre una excepción de E/S durante el proceso de log, la omite silenciosamente para evitar errores adicionales.
    ''' Este método es estático y puede ser llamado desde cualquier parte del sistema para registrar errores técnicos o de negocio.
    ''' </summary>
    ''' <param name="message">Mensaje personalizado que describe el contexto del error.</param>
    ''' <param name="ex">Excepción capturada que contiene detalles del error.</param>

    Public Shared Sub Log(message As String, ex As Exception)
        Try
            Dim logDirectory As String = Path.GetDirectoryName(logFilePath)
            If Not Directory.Exists(logDirectory) Then
                Directory.CreateDirectory(logDirectory)
            End If

            Using writer As New StreamWriter(logFilePath, True)
                writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {message}")
                writer.WriteLine($"Detalles: {ex.Message}")
                writer.WriteLine($"StackTrace: {ex.StackTrace}")
                writer.WriteLine(New String("-"c, 50))
            End Using
        Catch ioEx As IOException
        End Try
    End Sub

    ''' <summary>
    ''' 1. Registra la excepción recibida en el archivo log.txt utilizando <see cref="Log"/> con el mensaje "Capa Presentación".
    ''' 2. Muestra un cuadro de diálogo al usuario con un mensaje personalizado y el mensaje de la excepción, usando MsgBox en modo crítico.
    ''' 3. Si ocurre una excepción de E/S durante el proceso, la omite silenciosamente para evitar errores adicionales.
    ''' Este método asegura que todos los errores sean registrados y notificados al usuario de forma clara.
    ''' </summary>
    ''' <param name="mensajeUsuario">Mensaje personalizado que se mostrará al usuario.</param>
    ''' <param name="ex">Excepción capturada que será registrada y cuyo mensaje se mostrará al usuario.</param>

    Public Shared Sub Mostrar(mensajeUsuario As String, ex As Exception)
        Try
            Log("Capa Presentación", ex)
            MsgBox(mensajeUsuario & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
        Catch ioEx As IOException
        End Try
    End Sub
End Class
