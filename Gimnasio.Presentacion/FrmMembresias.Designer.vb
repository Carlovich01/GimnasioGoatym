<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMembresias
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
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As DataGridViewCellStyle = New DataGridViewCellStyle()
        panelListado = New Panel()
        btnActualizar = New Button()
        btnEliminar = New Button()
        BtnPagar = New Button()
        cbOpcionBuscar = New ComboBox()
        lblTotal = New Label()
        dgvListado = New DataGridView()
        tbBuscar = New TextBox()
        btnInsertar = New Button()
        panelDatosIngreso = New Panel()
        Label2 = New Label()
        lblDatosIngreso = New Label()
        Label1 = New Label()
        dgvPlan = New DataGridView()
        tbBuscarPlan = New TextBox()
        btnGuardar = New Button()
        btnCancelar = New Button()
        cbBuscarOpcionPlan = New ComboBox()
        dgvMiembro = New DataGridView()
        tbBuscarMiembro = New TextBox()
        cbOpcionBuscarMiembro = New ComboBox()
        panelPagoIngreso = New Panel()
        lblPagoIngreso = New Label()
        btnCancelarPago = New Button()
        btnGuardarPago = New Button()
        Button1 = New Button()
        Button2 = New Button()
        cbMetodo = New ComboBox()
        tbNotas = New TextBox()
        tbComprobante = New TextBox()
        tbMonto = New TextBox()
        Label4 = New Label()
        Label3 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        panelListado.SuspendLayout()
        CType(dgvListado, ComponentModel.ISupportInitialize).BeginInit()
        panelDatosIngreso.SuspendLayout()
        CType(dgvPlan, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvMiembro, ComponentModel.ISupportInitialize).BeginInit()
        panelPagoIngreso.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelListado
        ' 
        panelListado.Controls.Add(btnActualizar)
        panelListado.Controls.Add(btnEliminar)
        panelListado.Controls.Add(BtnPagar)
        panelListado.Controls.Add(cbOpcionBuscar)
        panelListado.Controls.Add(lblTotal)
        panelListado.Controls.Add(dgvListado)
        panelListado.Controls.Add(tbBuscar)
        panelListado.Controls.Add(btnInsertar)
        panelListado.Dock = DockStyle.Fill
        panelListado.Location = New Point(0, 0)
        panelListado.Name = "panelListado"
        panelListado.Size = New Size(1008, 729)
        panelListado.TabIndex = 0
        ' 
        ' btnActualizar
        ' 
        btnActualizar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnActualizar.Font = New Font("Segoe UI", 12F)
        btnActualizar.Location = New Point(242, 685)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(87, 31)
        btnActualizar.TabIndex = 42
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnEliminar.Font = New Font("Segoe UI", 12F)
        btnEliminar.Location = New Point(352, 685)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(90, 30)
        btnEliminar.TabIndex = 41
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' BtnPagar
        ' 
        BtnPagar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        BtnPagar.Font = New Font("Segoe UI", 12F)
        BtnPagar.Location = New Point(125, 684)
        BtnPagar.Name = "BtnPagar"
        BtnPagar.Size = New Size(90, 31)
        BtnPagar.TabIndex = 40
        BtnPagar.Text = "Pagar"
        BtnPagar.UseVisualStyleBackColor = True
        ' 
        ' cbOpcionBuscar
        ' 
        cbOpcionBuscar.DropDownStyle = ComboBoxStyle.DropDownList
        cbOpcionBuscar.Font = New Font("Segoe UI", 12F)
        cbOpcionBuscar.FormattingEnabled = True
        cbOpcionBuscar.Items.AddRange(New Object() {"Buscar por DNI", "Buscar por Plan ", "Membresias Activas", "Membresias Inactivas"})
        cbOpcionBuscar.Location = New Point(842, 12)
        cbOpcionBuscar.Name = "cbOpcionBuscar"
        cbOpcionBuscar.Size = New Size(155, 29)
        cbOpcionBuscar.TabIndex = 39
        ' 
        ' lblTotal
        ' 
        lblTotal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        lblTotal.AutoSize = True
        lblTotal.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        lblTotal.Font = New Font("Segoe UI", 12F)
        lblTotal.ForeColor = Color.White
        lblTotal.Location = New Point(811, 686)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(42, 21)
        lblTotal.TabIndex = 37
        lblTotal.Text = "Total"
        ' 
        ' dgvListado
        ' 
        dgvListado.AllowUserToAddRows = False
        dgvListado.AllowUserToDeleteRows = False
        dgvListado.AllowUserToOrderColumns = True
        dgvListado.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvListado.BackgroundColor = Color.FromArgb(CByte(85), CByte(96), CByte(105))
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = SystemColors.Window
        DataGridViewCellStyle7.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle7.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = DataGridViewTriState.True
        dgvListado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        dgvListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvListado.GridColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        dgvListado.Location = New Point(11, 56)
        dgvListado.MultiSelect = False
        dgvListado.Name = "dgvListado"
        dgvListado.ReadOnly = True
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = SystemColors.Window
        DataGridViewCellStyle8.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle8.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = DataGridViewTriState.True
        dgvListado.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvListado.Size = New Size(986, 618)
        dgvListado.TabIndex = 35
        ' 
        ' tbBuscar
        ' 
        tbBuscar.Font = New Font("Segoe UI", 12F)
        tbBuscar.Location = New Point(11, 12)
        tbBuscar.Name = "tbBuscar"
        tbBuscar.Size = New Size(809, 29)
        tbBuscar.TabIndex = 36
        ' 
        ' btnInsertar
        ' 
        btnInsertar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnInsertar.Font = New Font("Segoe UI", 12F)
        btnInsertar.Location = New Point(11, 685)
        btnInsertar.Name = "btnInsertar"
        btnInsertar.Size = New Size(92, 28)
        btnInsertar.TabIndex = 38
        btnInsertar.Text = "Insertar"
        btnInsertar.UseVisualStyleBackColor = True
        ' 
        ' panelDatosIngreso
        ' 
        panelDatosIngreso.Controls.Add(panelPagoIngreso)
        panelDatosIngreso.Controls.Add(Label2)
        panelDatosIngreso.Controls.Add(lblDatosIngreso)
        panelDatosIngreso.Controls.Add(Label1)
        panelDatosIngreso.Controls.Add(dgvPlan)
        panelDatosIngreso.Controls.Add(tbBuscarPlan)
        panelDatosIngreso.Controls.Add(btnGuardar)
        panelDatosIngreso.Controls.Add(btnCancelar)
        panelDatosIngreso.Controls.Add(cbBuscarOpcionPlan)
        panelDatosIngreso.Controls.Add(dgvMiembro)
        panelDatosIngreso.Controls.Add(tbBuscarMiembro)
        panelDatosIngreso.Controls.Add(cbOpcionBuscarMiembro)
        panelDatosIngreso.Location = New Point(12, 83)
        panelDatosIngreso.Name = "panelDatosIngreso"
        panelDatosIngreso.Size = New Size(968, 551)
        panelDatosIngreso.TabIndex = 43
        panelDatosIngreso.Visible = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(13, 249)
        Label2.Name = "Label2"
        Label2.Size = New Size(60, 21)
        Label2.TabIndex = 53
        Label2.Text = "Plan(*):"
        ' 
        ' lblDatosIngreso
        ' 
        lblDatosIngreso.AutoSize = True
        lblDatosIngreso.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDatosIngreso.ForeColor = Color.White
        lblDatosIngreso.Location = New Point(13, 13)
        lblDatosIngreso.Name = "lblDatosIngreso"
        lblDatosIngreso.Size = New Size(83, 21)
        lblDatosIngreso.TabIndex = 52
        lblDatosIngreso.Text = "Seleccione"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(13, 60)
        Label1.Name = "Label1"
        Label1.Size = New Size(94, 21)
        Label1.TabIndex = 48
        Label1.Text = "Miembro(*):"
        ' 
        ' dgvPlan
        ' 
        dgvPlan.AllowUserToAddRows = False
        dgvPlan.AllowUserToDeleteRows = False
        dgvPlan.AllowUserToOrderColumns = True
        dgvPlan.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvPlan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPlan.BackgroundColor = Color.FromArgb(CByte(85), CByte(96), CByte(105))
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = SystemColors.Window
        DataGridViewCellStyle9.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle9.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = DataGridViewTriState.True
        dgvPlan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        dgvPlan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPlan.GridColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        dgvPlan.Location = New Point(13, 292)
        dgvPlan.MultiSelect = False
        dgvPlan.Name = "dgvPlan"
        dgvPlan.ReadOnly = True
        DataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = SystemColors.Window
        DataGridViewCellStyle10.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle10.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = DataGridViewTriState.True
        dgvPlan.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        dgvPlan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPlan.Size = New Size(928, 178)
        dgvPlan.TabIndex = 56
        ' 
        ' tbBuscarPlan
        ' 
        tbBuscarPlan.Font = New Font("Segoe UI", 12F)
        tbBuscarPlan.Location = New Point(113, 249)
        tbBuscarPlan.Name = "tbBuscarPlan"
        tbBuscarPlan.Size = New Size(619, 29)
        tbBuscarPlan.TabIndex = 57
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnGuardar.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnGuardar.FlatAppearance.BorderColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnGuardar.FlatAppearance.MouseDownBackColor = Color.White
        btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        btnGuardar.FlatStyle = FlatStyle.Flat
        btnGuardar.Font = New Font("Segoe UI", 12F)
        btnGuardar.Location = New Point(13, 488)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(83, 31)
        btnGuardar.TabIndex = 54
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = False
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnCancelar.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnCancelar.FlatAppearance.BorderSize = 0
        btnCancelar.FlatAppearance.MouseDownBackColor = Color.White
        btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        btnCancelar.FlatStyle = FlatStyle.Flat
        btnCancelar.Font = New Font("Segoe UI", 12F)
        btnCancelar.Location = New Point(198, 488)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(82, 31)
        btnCancelar.TabIndex = 55
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = False
        ' 
        ' cbBuscarOpcionPlan
        ' 
        cbBuscarOpcionPlan.DropDownStyle = ComboBoxStyle.DropDownList
        cbBuscarOpcionPlan.Font = New Font("Segoe UI", 12F)
        cbBuscarOpcionPlan.FormattingEnabled = True
        cbBuscarOpcionPlan.Items.AddRange(New Object() {"Nombre"})
        cbBuscarOpcionPlan.Location = New Point(774, 249)
        cbBuscarOpcionPlan.Name = "cbBuscarOpcionPlan"
        cbBuscarOpcionPlan.Size = New Size(155, 29)
        cbBuscarOpcionPlan.TabIndex = 58
        ' 
        ' dgvMiembro
        ' 
        dgvMiembro.AllowUserToAddRows = False
        dgvMiembro.AllowUserToDeleteRows = False
        dgvMiembro.AllowUserToOrderColumns = True
        dgvMiembro.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        dgvMiembro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvMiembro.BackgroundColor = Color.FromArgb(CByte(85), CByte(96), CByte(105))
        DataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = SystemColors.Window
        DataGridViewCellStyle11.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle11.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = DataGridViewTriState.True
        dgvMiembro.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        dgvMiembro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMiembro.GridColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        dgvMiembro.Location = New Point(13, 100)
        dgvMiembro.MultiSelect = False
        dgvMiembro.Name = "dgvMiembro"
        dgvMiembro.ReadOnly = True
        DataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = SystemColors.Window
        DataGridViewCellStyle12.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle12.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = DataGridViewTriState.True
        dgvMiembro.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        dgvMiembro.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMiembro.Size = New Size(928, 129)
        dgvMiembro.TabIndex = 49
        ' 
        ' tbBuscarMiembro
        ' 
        tbBuscarMiembro.Font = New Font("Segoe UI", 12F)
        tbBuscarMiembro.Location = New Point(113, 57)
        tbBuscarMiembro.Name = "tbBuscarMiembro"
        tbBuscarMiembro.Size = New Size(619, 29)
        tbBuscarMiembro.TabIndex = 50
        ' 
        ' cbOpcionBuscarMiembro
        ' 
        cbOpcionBuscarMiembro.DropDownStyle = ComboBoxStyle.DropDownList
        cbOpcionBuscarMiembro.Font = New Font("Segoe UI", 12F)
        cbOpcionBuscarMiembro.FormattingEnabled = True
        cbOpcionBuscarMiembro.Items.AddRange(New Object() {"Buscar por nombre", "Buscar por DNI"})
        cbOpcionBuscarMiembro.Location = New Point(774, 57)
        cbOpcionBuscarMiembro.Name = "cbOpcionBuscarMiembro"
        cbOpcionBuscarMiembro.Size = New Size(155, 29)
        cbOpcionBuscarMiembro.TabIndex = 51
        ' 
        ' panelPagoIngreso
        ' 
        panelPagoIngreso.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        panelPagoIngreso.Controls.Add(lblPagoIngreso)
        panelPagoIngreso.Controls.Add(btnCancelarPago)
        panelPagoIngreso.Controls.Add(btnGuardarPago)
        panelPagoIngreso.Controls.Add(Button1)
        panelPagoIngreso.Controls.Add(Button2)
        panelPagoIngreso.Controls.Add(cbMetodo)
        panelPagoIngreso.Controls.Add(tbNotas)
        panelPagoIngreso.Controls.Add(tbComprobante)
        panelPagoIngreso.Controls.Add(tbMonto)
        panelPagoIngreso.Controls.Add(Label4)
        panelPagoIngreso.Controls.Add(Label3)
        panelPagoIngreso.Controls.Add(Label5)
        panelPagoIngreso.Controls.Add(Label6)
        panelPagoIngreso.ForeColor = Color.White
        panelPagoIngreso.Location = New Point(102, 74)
        panelPagoIngreso.Name = "panelPagoIngreso"
        panelPagoIngreso.Size = New Size(607, 504)
        panelPagoIngreso.TabIndex = 60
        panelPagoIngreso.Visible = False
        ' 
        ' lblPagoIngreso
        ' 
        lblPagoIngreso.AutoSize = True
        lblPagoIngreso.Font = New Font("Segoe UI", 12F)
        lblPagoIngreso.ForeColor = Color.White
        lblPagoIngreso.Location = New Point(209, 71)
        lblPagoIngreso.Name = "lblPagoIngreso"
        lblPagoIngreso.Size = New Size(191, 21)
        lblPagoIngreso.TabIndex = 21
        lblPagoIngreso.Text = "Ingrese los datos del pago"
        ' 
        ' btnCancelarPago
        ' 
        btnCancelarPago.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnCancelarPago.FlatStyle = FlatStyle.Flat
        btnCancelarPago.Font = New Font("Segoe UI", 12F)
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
        btnGuardarPago.FlatStyle = FlatStyle.Flat
        btnGuardarPago.Font = New Font("Segoe UI", 12F)
        btnGuardarPago.ForeColor = Color.Black
        btnGuardarPago.Location = New Point(200, 399)
        btnGuardarPago.Name = "btnGuardarPago"
        btnGuardarPago.Size = New Size(83, 34)
        btnGuardarPago.TabIndex = 19
        btnGuardarPago.Text = "Guardar"
        btnGuardarPago.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe UI", 12F)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(363, 399)
        Button1.Name = "Button1"
        Button1.Size = New Size(85, 34)
        Button1.TabIndex = 20
        Button1.Text = "Cancelar"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Segoe UI", 12F)
        Button2.ForeColor = Color.White
        Button2.Location = New Point(200, 399)
        Button2.Name = "Button2"
        Button2.Size = New Size(83, 34)
        Button2.TabIndex = 19
        Button2.Text = "Guardar"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' cbMetodo
        ' 
        cbMetodo.DropDownStyle = ComboBoxStyle.DropDownList
        cbMetodo.Font = New Font("Segoe UI", 12F)
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
        tbNotas.Font = New Font("Segoe UI", 12F)
        tbNotas.ForeColor = SystemColors.ControlText
        tbNotas.Location = New Point(200, 307)
        tbNotas.Name = "tbNotas"
        tbNotas.Size = New Size(343, 29)
        tbNotas.TabIndex = 17
        ' 
        ' tbComprobante
        ' 
        tbComprobante.Font = New Font("Segoe UI", 12F)
        tbComprobante.ForeColor = SystemColors.ControlText
        tbComprobante.Location = New Point(200, 251)
        tbComprobante.Name = "tbComprobante"
        tbComprobante.Size = New Size(343, 29)
        tbComprobante.TabIndex = 16
        ' 
        ' tbMonto
        ' 
        tbMonto.Font = New Font("Segoe UI", 12F)
        tbMonto.ForeColor = SystemColors.ControlText
        tbMonto.Location = New Point(200, 145)
        tbMonto.Name = "tbMonto"
        tbMonto.ReadOnly = True
        tbMonto.Size = New Size(343, 29)
        tbMonto.TabIndex = 15
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(118, 310)
        Label4.Name = "Label4"
        Label4.Size = New Size(51, 21)
        Label4.TabIndex = 14
        Label4.Text = "Notas"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(64, 259)
        Label3.Name = "Label3"
        Label3.Size = New Size(128, 21)
        Label3.TabIndex = 13
        Label3.Text = "N° Comprobante"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F)
        Label5.ForeColor = Color.White
        Label5.Location = New Point(107, 202)
        Label5.Name = "Label5"
        Label5.Size = New Size(85, 21)
        Label5.TabIndex = 12
        Label5.Text = "Metodo (*)"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(115, 145)
        Label6.Name = "Label6"
        Label6.Size = New Size(77, 21)
        Label6.TabIndex = 11
        Label6.Text = "Monto (*)"
        ' 
        ' FrmMembresias
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(1008, 729)
        Controls.Add(panelDatosIngreso)
        Controls.Add(panelListado)
        Name = "FrmMembresias"
        Text = "FrmMembresias"
        panelListado.ResumeLayout(False)
        panelListado.PerformLayout()
        CType(dgvListado, ComponentModel.ISupportInitialize).EndInit()
        panelDatosIngreso.ResumeLayout(False)
        panelDatosIngreso.PerformLayout()
        CType(dgvPlan, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvMiembro, ComponentModel.ISupportInitialize).EndInit()
        panelPagoIngreso.ResumeLayout(False)
        panelPagoIngreso.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents panelListado As Panel
    Friend WithEvents btnActualizar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents BtnPagar As Button
    Friend WithEvents cbOpcionBuscar As ComboBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents dgvListado As DataGridView
    Friend WithEvents tbBuscar As TextBox
    Friend WithEvents btnInsertar As Button
    Friend WithEvents panelDatosIngreso As Panel
    Friend WithEvents lblDatosIngreso As Label
    Friend WithEvents dgvMiembro As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents tbBuscarMiembro As TextBox
    Friend WithEvents cbOpcionBuscarMiembro As ComboBox
    Friend WithEvents dgvPlan As DataGridView
    Friend WithEvents tbBuscarPlan As TextBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents cbBuscarOpcionPlan As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents panelPagoIngreso As Panel
    Friend WithEvents btnCancelarPago As Button
    Friend WithEvents btnGuardarPago As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents cbMetodo As ComboBox
    Friend WithEvents tbNotas As TextBox
    Friend WithEvents tbComprobante As TextBox
    Friend WithEvents tbMonto As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblPagoIngreso As Label
End Class