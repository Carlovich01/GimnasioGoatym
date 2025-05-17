<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPagos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        panelListado = New Panel()
        btnActualizar = New Button()
        PanelFecha = New Panel()
        lblFin = New Label()
        lblInicio = New Label()
        dtpFechaInicio = New DateTimePicker()
        dtpFechaFin = New DateTimePicker()
        BtnBuscarFecha = New Button()
        PanelMonto = New Panel()
        btnBuscarMonto = New Button()
        lblHasta = New Label()
        lblDesde = New Label()
        tbMontoFinal = New TextBox()
        tbMontoInicial = New TextBox()
        Label4 = New Label()
        Label5 = New Label()
        Button1 = New Button()
        pbReiniciar = New PictureBox()
        btnEliminar = New Button()
        cbOpcionBuscar = New ComboBox()
        lbIngresosTotales = New Label()
        lblTotal = New Label()
        dgvListado = New DataGridView()
        tbBuscar = New TextBox()
        panelEdicionPago = New Panel()
        lblComprobante = New Label()
        tbIDpago = New TextBox()
        lblPagoIngreso = New Label()
        btnCancelarPago = New Button()
        btnGuardarPago = New Button()
        Button2 = New Button()
        Button3 = New Button()
        cbMetodo = New ComboBox()
        tbNotas = New TextBox()
        tbComprobante = New TextBox()
        tbMonto = New TextBox()
        lblNotas = New Label()
        lblMetodo = New Label()
        lblMonto = New Label()
        panelListado.SuspendLayout()
        PanelFecha.SuspendLayout()
        PanelMonto.SuspendLayout()
        CType(pbReiniciar, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvListado, ComponentModel.ISupportInitialize).BeginInit()
        panelEdicionPago.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelListado
        ' 
        panelListado.Controls.Add(PanelFecha)
        panelListado.Controls.Add(btnActualizar)
        panelListado.Controls.Add(pbReiniciar)
        panelListado.Controls.Add(btnEliminar)
        panelListado.Controls.Add(cbOpcionBuscar)
        panelListado.Controls.Add(PanelMonto)
        panelListado.Controls.Add(lbIngresosTotales)
        panelListado.Controls.Add(lblTotal)
        panelListado.Controls.Add(dgvListado)
        panelListado.Controls.Add(tbBuscar)
        panelListado.Dock = DockStyle.Fill
        panelListado.Location = New Point(0, 0)
        panelListado.Name = "panelListado"
        panelListado.Size = New Size(1008, 729)
        panelListado.TabIndex = 0
        ' 
        ' btnActualizar
        ' 
        btnActualizar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnActualizar.Cursor = Cursors.Hand
        btnActualizar.Font = New Font("Segoe UI", 12.0F)
        btnActualizar.Location = New Point(12, 691)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(87, 31)
        btnActualizar.TabIndex = 72
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = True
        ' 
        ' PanelFecha
        ' 
        PanelFecha.Controls.Add(lblFin)
        PanelFecha.Controls.Add(lblInicio)
        PanelFecha.Controls.Add(dtpFechaInicio)
        PanelFecha.Controls.Add(dtpFechaFin)
        PanelFecha.Controls.Add(BtnBuscarFecha)
        PanelFecha.Location = New Point(254, 12)
        PanelFecha.Name = "PanelFecha"
        PanelFecha.Size = New Size(697, 49)
        PanelFecha.TabIndex = 68
        ' 
        ' lblFin
        ' 
        lblFin.AutoSize = True
        lblFin.Font = New Font("Segoe UI", 12.0F)
        lblFin.ForeColor = Color.White
        lblFin.Location = New Point(292, 18)
        lblFin.Name = "lblFin"
        lblFin.Size = New Size(34, 21)
        lblFin.TabIndex = 28
        lblFin.Text = "Fin:"
        ' 
        ' lblInicio
        ' 
        lblInicio.AutoSize = True
        lblInicio.Font = New Font("Segoe UI", 12.0F)
        lblInicio.ForeColor = Color.White
        lblInicio.Location = New Point(3, 18)
        lblInicio.Name = "lblInicio"
        lblInicio.Size = New Size(50, 21)
        lblInicio.TabIndex = 27
        lblInicio.Text = "Inicio:"
        ' 
        ' dtpFechaInicio
        ' 
        dtpFechaInicio.Cursor = Cursors.Hand
        dtpFechaInicio.Font = New Font("Segoe UI", 12.0F)
        dtpFechaInicio.Location = New Point(59, 13)
        dtpFechaInicio.Name = "dtpFechaInicio"
        dtpFechaInicio.Size = New Size(216, 29)
        dtpFechaInicio.TabIndex = 25
        ' 
        ' dtpFechaFin
        ' 
        dtpFechaFin.Cursor = Cursors.Hand
        dtpFechaFin.Font = New Font("Segoe UI", 12.0F)
        dtpFechaFin.Location = New Point(329, 12)
        dtpFechaFin.Name = "dtpFechaFin"
        dtpFechaFin.Size = New Size(216, 29)
        dtpFechaFin.TabIndex = 25
        ' 
        ' BtnBuscarFecha
        ' 
        BtnBuscarFecha.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        BtnBuscarFecha.Font = New Font("Segoe UI", 12.0F)
        BtnBuscarFecha.Location = New Point(574, -38)
        BtnBuscarFecha.Name = "BtnBuscarFecha"
        BtnBuscarFecha.Size = New Size(92, 28)
        BtnBuscarFecha.TabIndex = 22
        BtnBuscarFecha.Text = "Buscar"
        BtnBuscarFecha.UseVisualStyleBackColor = True
        ' 
        ' PanelMonto
        ' 
        PanelMonto.Controls.Add(btnBuscarMonto)
        PanelMonto.Controls.Add(lblHasta)
        PanelMonto.Controls.Add(lblDesde)
        PanelMonto.Controls.Add(tbMontoFinal)
        PanelMonto.Controls.Add(tbMontoInicial)
        PanelMonto.Controls.Add(Label4)
        PanelMonto.Controls.Add(Label5)
        PanelMonto.Controls.Add(Button1)
        PanelMonto.Location = New Point(254, 12)
        PanelMonto.Name = "PanelMonto"
        PanelMonto.Size = New Size(700, 49)
        PanelMonto.TabIndex = 69
        ' 
        ' btnBuscarMonto
        ' 
        btnBuscarMonto.Cursor = Cursors.Hand
        btnBuscarMonto.Font = New Font("Segoe UI", 12.0F)
        btnBuscarMonto.Location = New Point(569, 8)
        btnBuscarMonto.Name = "btnBuscarMonto"
        btnBuscarMonto.Size = New Size(87, 32)
        btnBuscarMonto.TabIndex = 26
        btnBuscarMonto.Text = "Buscar"
        btnBuscarMonto.UseVisualStyleBackColor = True
        ' 
        ' lblHasta
        ' 
        lblHasta.AutoSize = True
        lblHasta.Font = New Font("Segoe UI", 12.0F)
        lblHasta.ForeColor = Color.White
        lblHasta.Location = New Point(292, 14)
        lblHasta.Name = "lblHasta"
        lblHasta.Size = New Size(49, 21)
        lblHasta.TabIndex = 25
        lblHasta.Text = "Hasta"
        ' 
        ' lblDesde
        ' 
        lblDesde.AutoSize = True
        lblDesde.Font = New Font("Segoe UI", 12.0F)
        lblDesde.ForeColor = Color.White
        lblDesde.Location = New Point(34, 13)
        lblDesde.Name = "lblDesde"
        lblDesde.Size = New Size(53, 21)
        lblDesde.TabIndex = 25
        lblDesde.Text = "Desde"
        ' 
        ' tbMontoFinal
        ' 
        tbMontoFinal.Font = New Font("Segoe UI", 12.0F)
        tbMontoFinal.Location = New Point(363, 11)
        tbMontoFinal.Name = "tbMontoFinal"
        tbMontoFinal.Size = New Size(167, 29)
        tbMontoFinal.TabIndex = 24
        ' 
        ' tbMontoInicial
        ' 
        tbMontoInicial.Font = New Font("Segoe UI", 12.0F)
        tbMontoInicial.Location = New Point(108, 9)
        tbMontoInicial.Name = "tbMontoInicial"
        tbMontoInicial.Size = New Size(154, 29)
        tbMontoInicial.TabIndex = 23
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Label4.AutoSize = True
        Label4.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        Label4.Font = New Font("Segoe UI", 12.0F)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(1270, -87)
        Label4.Name = "Label4"
        Label4.Size = New Size(34, 21)
        Label4.TabIndex = 21
        Label4.Text = "Fin:"
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Label5.AutoSize = True
        Label5.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        Label5.Font = New Font("Segoe UI", 12.0F)
        Label5.ForeColor = Color.White
        Label5.Location = New Point(1003, -87)
        Label5.Name = "Label5"
        Label5.Size = New Size(50, 21)
        Label5.TabIndex = 21
        Label5.Text = "Inicio:"
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Button1.Font = New Font("Segoe UI", 12.0F)
        Button1.Location = New Point(551, -89)
        Button1.Name = "Button1"
        Button1.Size = New Size(92, 28)
        Button1.TabIndex = 22
        Button1.Text = "Buscar"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' pbReiniciar
        ' 
        pbReiniciar.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        pbReiniciar.Cursor = Cursors.Hand
        pbReiniciar.Image = My.Resources.Resources.reiniciar
        pbReiniciar.Location = New Point(963, 21)
        pbReiniciar.Name = "pbReiniciar"
        pbReiniciar.Size = New Size(34, 30)
        pbReiniciar.SizeMode = PictureBoxSizeMode.Zoom
        pbReiniciar.TabIndex = 71
        pbReiniciar.TabStop = False
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnEliminar.Cursor = Cursors.Hand
        btnEliminar.Font = New Font("Segoe UI", 12.0F)
        btnEliminar.Location = New Point(130, 689)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(84, 33)
        btnEliminar.TabIndex = 70
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' cbOpcionBuscar
        ' 
        cbOpcionBuscar.Cursor = Cursors.Hand
        cbOpcionBuscar.DropDownStyle = ComboBoxStyle.DropDownList
        cbOpcionBuscar.Font = New Font("Segoe UI", 12.0F)
        cbOpcionBuscar.FormattingEnabled = True
        cbOpcionBuscar.Items.AddRange(New Object() {"Buscar por fechas", "Buscar por DNI", "Buscar por plan", "Buscar por monto", "Efectivo", "Tarjeta Débito", "Tarjeta Crédito", "Transferencia Bancaria", "Mercado Pago", "Otro"})
        cbOpcionBuscar.Location = New Point(12, 21)
        cbOpcionBuscar.Name = "cbOpcionBuscar"
        cbOpcionBuscar.Size = New Size(236, 29)
        cbOpcionBuscar.TabIndex = 67
        ' 
        ' lbIngresosTotales
        ' 
        lbIngresosTotales.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        lbIngresosTotales.AutoSize = True
        lbIngresosTotales.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        lbIngresosTotales.Font = New Font("Segoe UI", 12.0F)
        lbIngresosTotales.ForeColor = Color.White
        lbIngresosTotales.Location = New Point(657, 695)
        lbIngresosTotales.Name = "lbIngresosTotales"
        lbIngresosTotales.Size = New Size(127, 21)
        lbIngresosTotales.TabIndex = 65
        lbIngresosTotales.Text = "Ingresos Totales :"
        ' 
        ' lblTotal
        ' 
        lblTotal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        lblTotal.AutoSize = True
        lblTotal.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        lblTotal.Font = New Font("Segoe UI", 12.0F)
        lblTotal.ForeColor = Color.White
        lblTotal.Location = New Point(433, 695)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(114, 21)
        lblTotal.TabIndex = 66
        lblTotal.Text = "Total Registros:"
        ' 
        ' dgvListado
        ' 
        dgvListado.AllowUserToAddRows = False
        dgvListado.AllowUserToDeleteRows = False
        dgvListado.AllowUserToOrderColumns = True
        dgvListado.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvListado.BackgroundColor = Color.FromArgb(CByte(85), CByte(96), CByte(105))
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Window
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9.0F)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvListado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvListado.GridColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        dgvListado.Location = New Point(11, 62)
        dgvListado.MultiSelect = False
        dgvListado.Name = "dgvListado"
        dgvListado.ReadOnly = True
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9.0F)
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvListado.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvListado.Size = New Size(986, 618)
        dgvListado.TabIndex = 63
        ' 
        ' tbBuscar
        ' 
        tbBuscar.Font = New Font("Segoe UI", 12.0F)
        tbBuscar.Location = New Point(274, 22)
        tbBuscar.Name = "tbBuscar"
        tbBuscar.Size = New Size(669, 29)
        tbBuscar.TabIndex = 64
        ' 
        ' panelEdicionPago
        ' 
        panelEdicionPago.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        panelEdicionPago.Controls.Add(lblComprobante)
        panelEdicionPago.Controls.Add(tbIDpago)
        panelEdicionPago.Controls.Add(lblPagoIngreso)
        panelEdicionPago.Controls.Add(btnCancelarPago)
        panelEdicionPago.Controls.Add(btnGuardarPago)
        panelEdicionPago.Controls.Add(Button2)
        panelEdicionPago.Controls.Add(Button3)
        panelEdicionPago.Controls.Add(cbMetodo)
        panelEdicionPago.Controls.Add(tbNotas)
        panelEdicionPago.Controls.Add(tbComprobante)
        panelEdicionPago.Controls.Add(tbMonto)
        panelEdicionPago.Controls.Add(lblNotas)
        panelEdicionPago.Controls.Add(lblMetodo)
        panelEdicionPago.Controls.Add(lblMonto)
        panelEdicionPago.ForeColor = Color.White
        panelEdicionPago.Location = New Point(201, 112)
        panelEdicionPago.Name = "panelEdicionPago"
        panelEdicionPago.Size = New Size(607, 504)
        panelEdicionPago.TabIndex = 73
        panelEdicionPago.Visible = False
        ' 
        ' lblComprobante
        ' 
        lblComprobante.AutoSize = True
        lblComprobante.Font = New Font("Segoe UI", 12.0F)
        lblComprobante.ForeColor = Color.White
        lblComprobante.Location = New Point(59, 254)
        lblComprobante.Name = "lblComprobante"
        lblComprobante.Size = New Size(128, 21)
        lblComprobante.TabIndex = 59
        lblComprobante.Text = "N° Comprobante"
        ' 
        ' tbIDpago
        ' 
        tbIDpago.AccessibleRole = AccessibleRole.SplitButton
        tbIDpago.Location = New Point(443, 69)
        tbIDpago.Name = "tbIDpago"
        tbIDpago.Size = New Size(100, 23)
        tbIDpago.TabIndex = 58
        tbIDpago.Visible = False
        ' 
        ' lblPagoIngreso
        ' 
        lblPagoIngreso.AutoSize = True
        lblPagoIngreso.Font = New Font("Segoe UI", 12.0F)
        lblPagoIngreso.ForeColor = Color.White
        lblPagoIngreso.Location = New Point(209, 71)
        lblPagoIngreso.Name = "lblPagoIngreso"
        lblPagoIngreso.Size = New Size(202, 21)
        lblPagoIngreso.TabIndex = 21
        lblPagoIngreso.Text = "Actualice los datos del pago"
        ' 
        ' btnCancelarPago
        ' 
        btnCancelarPago.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnCancelarPago.Cursor = Cursors.Hand
        btnCancelarPago.FlatStyle = FlatStyle.Flat
        btnCancelarPago.Font = New Font("Segoe UI", 12.0F)
        btnCancelarPago.ForeColor = Color.Black
        btnCancelarPago.Location = New Point(363, 399)
        btnCancelarPago.Name = "btnCancelarPago"
        btnCancelarPago.Size = New Size(85, 34)
        btnCancelarPago.TabIndex = 20
        btnCancelarPago.Text = "Cancelar"
        btnCancelarPago.UseVisualStyleBackColor = False
        ' 
        ' btnGuardarPago
        ' 
        btnGuardarPago.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnGuardarPago.Cursor = Cursors.Hand
        btnGuardarPago.FlatStyle = FlatStyle.Flat
        btnGuardarPago.Font = New Font("Segoe UI", 12.0F)
        btnGuardarPago.ForeColor = Color.Black
        btnGuardarPago.Location = New Point(200, 399)
        btnGuardarPago.Name = "btnGuardarPago"
        btnGuardarPago.Size = New Size(83, 34)
        btnGuardarPago.TabIndex = 19
        btnGuardarPago.Text = "Guardar"
        btnGuardarPago.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Segoe UI", 12.0F)
        Button2.ForeColor = Color.White
        Button2.Location = New Point(363, 399)
        Button2.Name = "Button2"
        Button2.Size = New Size(85, 34)
        Button2.TabIndex = 20
        Button2.Text = "Cancelar"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Font = New Font("Segoe UI", 12.0F)
        Button3.ForeColor = Color.White
        Button3.Location = New Point(200, 399)
        Button3.Name = "Button3"
        Button3.Size = New Size(83, 34)
        Button3.TabIndex = 19
        Button3.Text = "Guardar"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' cbMetodo
        ' 
        cbMetodo.Cursor = Cursors.Hand
        cbMetodo.DropDownStyle = ComboBoxStyle.DropDownList
        cbMetodo.Font = New Font("Segoe UI", 12.0F)
        cbMetodo.ForeColor = SystemColors.ControlText
        cbMetodo.FormattingEnabled = True
        cbMetodo.Items.AddRange(New Object() {"Efectivo", "Tarjeta Débito", "Tarjeta Crédito", "Transferencia Bancaria", "Mercado Pago", "Otro"})
        cbMetodo.Location = New Point(200, 202)
        cbMetodo.Name = "cbMetodo"
        cbMetodo.Size = New Size(343, 29)
        cbMetodo.TabIndex = 18
        ' 
        ' tbNotas
        ' 
        tbNotas.Font = New Font("Segoe UI", 12.0F)
        tbNotas.ForeColor = SystemColors.ControlText
        tbNotas.Location = New Point(200, 307)
        tbNotas.Name = "tbNotas"
        tbNotas.Size = New Size(343, 29)
        tbNotas.TabIndex = 17
        ' 
        ' tbComprobante
        ' 
        tbComprobante.Font = New Font("Segoe UI", 12.0F)
        tbComprobante.ForeColor = SystemColors.ControlText
        tbComprobante.Location = New Point(200, 251)
        tbComprobante.Name = "tbComprobante"
        tbComprobante.Size = New Size(343, 29)
        tbComprobante.TabIndex = 16
        ' 
        ' tbMonto
        ' 
        tbMonto.Font = New Font("Segoe UI", 12.0F)
        tbMonto.ForeColor = SystemColors.ControlText
        tbMonto.Location = New Point(200, 145)
        tbMonto.Name = "tbMonto"
        tbMonto.Size = New Size(343, 29)
        tbMonto.TabIndex = 15
        ' 
        ' lblNotas
        ' 
        lblNotas.AutoSize = True
        lblNotas.Font = New Font("Segoe UI", 12.0F)
        lblNotas.ForeColor = Color.White
        lblNotas.Location = New Point(136, 310)
        lblNotas.Name = "lblNotas"
        lblNotas.Size = New Size(51, 21)
        lblNotas.TabIndex = 14
        lblNotas.Text = "Notas"
        ' 
        ' lblMetodo
        ' 
        lblMetodo.AutoSize = True
        lblMetodo.Font = New Font("Segoe UI", 12.0F)
        lblMetodo.ForeColor = Color.White
        lblMetodo.Location = New Point(107, 202)
        lblMetodo.Name = "lblMetodo"
        lblMetodo.Size = New Size(85, 21)
        lblMetodo.TabIndex = 12
        lblMetodo.Text = "Metodo (*)"
        ' 
        ' lblMonto
        ' 
        lblMonto.AutoSize = True
        lblMonto.Font = New Font("Segoe UI", 12.0F)
        lblMonto.ForeColor = Color.White
        lblMonto.Location = New Point(115, 145)
        lblMonto.Name = "lblMonto"
        lblMonto.Size = New Size(77, 21)
        lblMonto.TabIndex = 11
        lblMonto.Text = "Monto (*)"
        ' 
        ' FrmPagos
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(1008, 729)
        Controls.Add(panelEdicionPago)
        Controls.Add(panelListado)
        Name = "FrmPagos"
        Text = "FrmPagos"
        panelListado.ResumeLayout(False)
        panelListado.PerformLayout()
        PanelFecha.ResumeLayout(False)
        PanelFecha.PerformLayout()
        PanelMonto.ResumeLayout(False)
        PanelMonto.PerformLayout()
        CType(pbReiniciar, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvListado, ComponentModel.ISupportInitialize).EndInit()
        panelEdicionPago.ResumeLayout(False)
        panelEdicionPago.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents lblComprobante As Label
    Friend WithEvents panelListado As Panel
    Friend WithEvents btnActualizar As Button
    Friend WithEvents PanelFecha As Panel
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents BtnBuscarFecha As Button
    Friend WithEvents PanelMonto As Panel
    Friend WithEvents btnBuscarMonto As Button
    Friend WithEvents lblHasta As Label
    Friend WithEvents lblDesde As Label
    Friend WithEvents tbMontoFinal As TextBox
    Friend WithEvents tbMontoInicial As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents pbReiniciar As PictureBox
    Friend WithEvents btnEliminar As Button
    Friend WithEvents cbOpcionBuscar As ComboBox
    Friend WithEvents lbIngresosTotales As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents dgvListado As DataGridView
    Friend WithEvents tbBuscar As TextBox
    Friend WithEvents lblFin As Label
    Friend WithEvents lblInicio As Label
    Friend WithEvents panelEdicionPago As Panel
    Friend WithEvents tbIDpago As TextBox
    Friend WithEvents lblPagoIngreso As Label
    Friend WithEvents btnCancelarPago As Button
    Friend WithEvents btnGuardarPago As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents cbMetodo As ComboBox
    Friend WithEvents tbNotas As TextBox
    Friend WithEvents tbComprobante As TextBox
    Friend WithEvents tbMonto As TextBox
    Friend WithEvents lblNotas As Label
    Friend WithEvents lblMetodo As Label
    Friend WithEvents lblMonto As Label
End Class
