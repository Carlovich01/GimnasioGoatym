''' <summary>
''' Representa un pago realizado por una membresía en el sistema del gimnasio.
''' Contiene información sobre el monto, método, usuario que registró el pago y otros detalles relevantes.
''' </summary>
Public Class Pagos
    ''' <summary>
    ''' Identificador único del pago.
    ''' </summary>
    Private _idPago As UInteger
    ''' <summary>
    ''' Identificador de la membresía asociada al pago.
    ''' </summary>
    Private _idMembresia As UInteger?
    ''' <summary>
    ''' Identificador del usuario que registró el pago.
    ''' </summary>
    Private _idUsuarioRegistro As UInteger?
    ''' <summary>
    ''' Fecha y hora en que se realizó el pago.
    ''' </summary>
    Private _fechaPago As DateTime
    ''' <summary>
    ''' Monto pagado.
    ''' </summary>
    Private _montoPagado As Decimal
    ''' <summary>
    ''' Método de pago utilizado (por ejemplo: efectivo, tarjeta, transferencia).
    ''' </summary>
    Private _metodoPago As String
    ''' <summary>
    ''' Número de comprobante del pago (si corresponde).
    ''' </summary>
    Private _numeroComprobante As String
    ''' <summary>
    ''' Notas adicionales sobre el pago.
    ''' </summary>
    Private _notas As String

    ''' <summary>
    ''' Obtiene o establece el identificador único del pago.
    ''' </summary>
    Public Property IdPago As UInteger
        Get
            Return _idPago
        End Get
        Set(value As UInteger)
            _idPago = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el identificador de la membresía asociada al pago.
    ''' </summary>
    Public Property IdMembresia As UInteger?
        Get
            Return _idMembresia
        End Get
        Set(value As UInteger?)
            _idMembresia = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el identificador del usuario que registró el pago.
    ''' </summary>
    Public Property IdUsuarioRegistro As UInteger?
        Get
            Return _idUsuarioRegistro
        End Get
        Set(value As UInteger?)
            _idUsuarioRegistro = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece la fecha y hora en que se realizó el pago.
    ''' </summary>
    Public Property FechaPago As DateTime
        Get
            Return _fechaPago
        End Get
        Set(value As DateTime)
            _fechaPago = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el monto pagado.
    ''' </summary>
    Public Property MontoPagado As Decimal
        Get
            Return _montoPagado
        End Get
        Set(value As Decimal)
            _montoPagado = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el método de pago utilizado.
    ''' </summary>
    Public Property MetodoPago As String
        Get
            Return _metodoPago
        End Get
        Set(value As String)
            _metodoPago = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el número de comprobante del pago.
    ''' </summary>
    Public Property NumeroComprobante As String
        Get
            Return _numeroComprobante
        End Get
        Set(value As String)
            _numeroComprobante = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece notas adicionales sobre el pago.
    ''' </summary>
    Public Property Notas As String
        Get
            Return _notas
        End Get
        Set(value As String)
            _notas = value
        End Set
    End Property
End Class

