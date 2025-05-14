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
        lblTotal = New Label()
        dgvListado = New DataGridView()
        tbBuscar = New TextBox()
        lbIngresosTotales = New Label()
        cbOpcionBuscar = New ComboBox()
        dtpFechaFin = New DateTimePicker()
        dtpFechaInicio = New DateTimePicker()
        PanelFecha = New Panel()
        Label2 = New Label()
        Label1 = New Label()
        BtnBuscarFecha = New Button()
        PanelMonto = New Panel()
        btnBuscarMonto = New Button()
        Label7 = New Label()
        Label6 = New Label()
        tbMontoFinal = New TextBox()
        tbMontoInicial = New TextBox()
        Label4 = New Label()
        Label5 = New Label()
        Button1 = New Button()
        btnEliminar = New Button()
        CType(dgvListado, ComponentModel.ISupportInitialize).BeginInit()
        PanelFecha.SuspendLayout()
        PanelMonto.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblTotal
        ' 
        lblTotal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        lblTotal.AutoSize = True
        lblTotal.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        lblTotal.Font = New Font("Segoe UI", 12F)
        lblTotal.ForeColor = Color.White
        lblTotal.Location = New Point(433, 690)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(114, 21)
        lblTotal.TabIndex = 21
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
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvListado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvListado.GridColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        dgvListado.Location = New Point(11, 57)
        dgvListado.MultiSelect = False
        dgvListado.Name = "dgvListado"
        dgvListado.ReadOnly = True
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvListado.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvListado.Size = New Size(986, 618)
        dgvListado.TabIndex = 15
        ' 
        ' tbBuscar
        ' 
        tbBuscar.Font = New Font("Segoe UI", 12F)
        tbBuscar.Location = New Point(288, 14)
        tbBuscar.Name = "tbBuscar"
        tbBuscar.Size = New Size(669, 29)
        tbBuscar.TabIndex = 16
        ' 
        ' lbIngresosTotales
        ' 
        lbIngresosTotales.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        lbIngresosTotales.AutoSize = True
        lbIngresosTotales.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        lbIngresosTotales.Font = New Font("Segoe UI", 12F)
        lbIngresosTotales.ForeColor = Color.White
        lbIngresosTotales.Location = New Point(657, 690)
        lbIngresosTotales.Name = "lbIngresosTotales"
        lbIngresosTotales.Size = New Size(127, 21)
        lbIngresosTotales.TabIndex = 21
        lbIngresosTotales.Text = "Ingresos Totales :"
        ' 
        ' cbOpcionBuscar
        ' 
        cbOpcionBuscar.DropDownStyle = ComboBoxStyle.DropDownList
        cbOpcionBuscar.Font = New Font("Segoe UI", 12F)
        cbOpcionBuscar.FormattingEnabled = True
        cbOpcionBuscar.Items.AddRange(New Object() {"Buscar por fechas", "Buscar por DNI", "Buscar por plan", "Buscar por monto", "Efectivo", "Tarjeta Débito", "Tarjeta Crédito", "Transferencia Bancaria", "Mercado Pago", "Otro"})
        cbOpcionBuscar.Location = New Point(12, 16)
        cbOpcionBuscar.Name = "cbOpcionBuscar"
        cbOpcionBuscar.Size = New Size(236, 29)
        cbOpcionBuscar.TabIndex = 24
        ' 
        ' dtpFechaFin
        ' 
        dtpFechaFin.Font = New Font("Segoe UI", 12F)
        dtpFechaFin.Location = New Point(312, 13)
        dtpFechaFin.Name = "dtpFechaFin"
        dtpFechaFin.Size = New Size(200, 29)
        dtpFechaFin.TabIndex = 25
        ' 
        ' dtpFechaInicio
        ' 
        dtpFechaInicio.Font = New Font("Segoe UI", 12F)
        dtpFechaInicio.Location = New Point(59, 13)
        dtpFechaInicio.Name = "dtpFechaInicio"
        dtpFechaInicio.Size = New Size(200, 29)
        dtpFechaInicio.TabIndex = 25
        ' 
        ' PanelFecha
        ' 
        PanelFecha.Controls.Add(dtpFechaInicio)
        PanelFecha.Controls.Add(dtpFechaFin)
        PanelFecha.Controls.Add(Label2)
        PanelFecha.Controls.Add(Label1)
        PanelFecha.Controls.Add(BtnBuscarFecha)
        PanelFecha.Location = New Point(288, 2)
        PanelFecha.Name = "PanelFecha"
        PanelFecha.Size = New Size(669, 49)
        PanelFecha.TabIndex = 27
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Label2.AutoSize = True
        Label2.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(270, 15)
        Label2.Name = "Label2"
        Label2.Size = New Size(34, 21)
        Label2.TabIndex = 21
        Label2.Text = "Fin:"
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Label1.AutoSize = True
        Label1.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(3, 15)
        Label1.Name = "Label1"
        Label1.Size = New Size(50, 21)
        Label1.TabIndex = 21
        Label1.Text = "Inicio:"
        ' 
        ' BtnBuscarFecha
        ' 
        BtnBuscarFecha.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        BtnBuscarFecha.Font = New Font("Segoe UI", 12F)
        BtnBuscarFecha.Location = New Point(551, 13)
        BtnBuscarFecha.Name = "BtnBuscarFecha"
        BtnBuscarFecha.Size = New Size(92, 28)
        BtnBuscarFecha.TabIndex = 22
        BtnBuscarFecha.Text = "Buscar"
        BtnBuscarFecha.UseVisualStyleBackColor = True
        ' 
        ' PanelMonto
        ' 
        PanelMonto.Controls.Add(btnBuscarMonto)
        PanelMonto.Controls.Add(Label7)
        PanelMonto.Controls.Add(Label6)
        PanelMonto.Controls.Add(tbMontoFinal)
        PanelMonto.Controls.Add(tbMontoInicial)
        PanelMonto.Controls.Add(Label4)
        PanelMonto.Controls.Add(Label5)
        PanelMonto.Controls.Add(Button1)
        PanelMonto.Location = New Point(275, 5)
        PanelMonto.Name = "PanelMonto"
        PanelMonto.Size = New Size(669, 49)
        PanelMonto.TabIndex = 28
        ' 
        ' btnBuscarMonto
        ' 
        btnBuscarMonto.Font = New Font("Segoe UI", 12F)
        btnBuscarMonto.Location = New Point(553, 10)
        btnBuscarMonto.Name = "btnBuscarMonto"
        btnBuscarMonto.Size = New Size(87, 32)
        btnBuscarMonto.TabIndex = 26
        btnBuscarMonto.Text = "Buscar"
        btnBuscarMonto.UseVisualStyleBackColor = True
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12F)
        Label7.ForeColor = Color.White
        Label7.Location = New Point(287, 14)
        Label7.Name = "Label7"
        Label7.Size = New Size(49, 21)
        Label7.TabIndex = 25
        Label7.Text = "Hasta"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(33, 12)
        Label6.Name = "Label6"
        Label6.Size = New Size(53, 21)
        Label6.TabIndex = 25
        Label6.Text = "Desde"
        ' 
        ' tbMontoFinal
        ' 
        tbMontoFinal.Font = New Font("Segoe UI", 12F)
        tbMontoFinal.Location = New Point(362, 12)
        tbMontoFinal.Name = "tbMontoFinal"
        tbMontoFinal.Size = New Size(147, 29)
        tbMontoFinal.TabIndex = 24
        ' 
        ' tbMontoInicial
        ' 
        tbMontoInicial.Font = New Font("Segoe UI", 12F)
        tbMontoInicial.Location = New Point(109, 12)
        tbMontoInicial.Name = "tbMontoInicial"
        tbMontoInicial.Size = New Size(137, 29)
        tbMontoInicial.TabIndex = 23
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Label4.AutoSize = True
        Label4.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(739, -36)
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
        Label5.Font = New Font("Segoe UI", 12F)
        Label5.ForeColor = Color.White
        Label5.Location = New Point(472, -36)
        Label5.Name = "Label5"
        Label5.Size = New Size(50, 21)
        Label5.TabIndex = 21
        Label5.Text = "Inicio:"
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Button1.Font = New Font("Segoe UI", 12F)
        Button1.Location = New Point(551, -38)
        Button1.Name = "Button1"
        Button1.Size = New Size(92, 28)
        Button1.TabIndex = 22
        Button1.Text = "Buscar"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnEliminar.Font = New Font("Segoe UI", 12F)
        btnEliminar.Location = New Point(12, 684)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(80, 33)
        btnEliminar.TabIndex = 29
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' FrmPagos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(1008, 729)
        Controls.Add(btnEliminar)
        Controls.Add(cbOpcionBuscar)
        Controls.Add(lbIngresosTotales)
        Controls.Add(lblTotal)
        Controls.Add(PanelMonto)
        Controls.Add(dgvListado)
        Controls.Add(PanelFecha)
        Controls.Add(tbBuscar)
        Name = "FrmPagos"
        Text = "FrmPagos"
        CType(dgvListado, ComponentModel.ISupportInitialize).EndInit()
        PanelFecha.ResumeLayout(False)
        PanelFecha.PerformLayout()
        PanelMonto.ResumeLayout(False)
        PanelMonto.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTotal As Label
    Friend WithEvents dgvListado As DataGridView
    Friend WithEvents tbBuscar As TextBox
    Friend WithEvents lbIngresosTotales As Label
    Friend WithEvents cbOpcionBuscar As ComboBox
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents PanelFecha As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnBuscarFecha As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents PanelMonto As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents btnBuscarMonto As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents tbMontoFinal As TextBox
    Friend WithEvents tbMontoInicial As TextBox
    Friend WithEvents btnEliminar As Button
End Class
