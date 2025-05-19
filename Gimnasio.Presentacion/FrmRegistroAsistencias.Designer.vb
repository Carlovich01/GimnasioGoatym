<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRegistroAsistencias
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
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        cbOpcionBuscar = New ComboBox()
        lblTotal = New Label()
        dgvListado = New DataGridView()
        tbBuscar = New TextBox()
        PanelFecha = New Panel()
        btnBuscar = New Button()
        lblFin = New Label()
        lblInicio = New Label()
        dtpFechaInicio = New DateTimePicker()
        dtpFechaFin = New DateTimePicker()
        BtnBuscarFecha = New Button()
        btnEliminar = New Button()
        btnInsertar = New Button()
        pbReiniciar = New PictureBox()
        CType(dgvListado, ComponentModel.ISupportInitialize).BeginInit()
        PanelFecha.SuspendLayout()
        CType(pbReiniciar, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' cbOpcionBuscar
        ' 
        cbOpcionBuscar.Cursor = Cursors.Hand
        cbOpcionBuscar.DropDownStyle = ComboBoxStyle.DropDownList
        cbOpcionBuscar.Font = New Font("Segoe UI", 12F)
        cbOpcionBuscar.FormattingEnabled = True
        cbOpcionBuscar.Items.AddRange(New Object() {"Buscar por DNI", "Buscar por fecha"})
        cbOpcionBuscar.Location = New Point(11, 12)
        cbOpcionBuscar.Name = "cbOpcionBuscar"
        cbOpcionBuscar.Size = New Size(155, 29)
        cbOpcionBuscar.TabIndex = 32
        ' 
        ' lblTotal
        ' 
        lblTotal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        lblTotal.AutoSize = True
        lblTotal.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        lblTotal.Font = New Font("Segoe UI", 12F)
        lblTotal.ForeColor = Color.White
        lblTotal.Location = New Point(779, 689)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(42, 21)
        lblTotal.TabIndex = 30
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
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Window
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        dgvListado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        dgvListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvListado.GridColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        dgvListado.Location = New Point(11, 57)
        dgvListado.MultiSelect = False
        dgvListado.Name = "dgvListado"
        dgvListado.ReadOnly = True
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = SystemColors.Window
        DataGridViewCellStyle4.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle4.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True
        dgvListado.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvListado.Size = New Size(986, 618)
        dgvListado.TabIndex = 25
        ' 
        ' tbBuscar
        ' 
        tbBuscar.Font = New Font("Segoe UI", 12F)
        tbBuscar.Location = New Point(272, 13)
        tbBuscar.Name = "tbBuscar"
        tbBuscar.Size = New Size(667, 29)
        tbBuscar.TabIndex = 26
        ' 
        ' PanelFecha
        ' 
        PanelFecha.Controls.Add(btnBuscar)
        PanelFecha.Controls.Add(lblFin)
        PanelFecha.Controls.Add(lblInicio)
        PanelFecha.Controls.Add(dtpFechaInicio)
        PanelFecha.Controls.Add(dtpFechaFin)
        PanelFecha.Controls.Add(BtnBuscarFecha)
        PanelFecha.Location = New Point(269, 2)
        PanelFecha.Name = "PanelFecha"
        PanelFecha.Size = New Size(670, 49)
        PanelFecha.TabIndex = 34
        ' 
        ' btnBuscar
        ' 
        btnBuscar.Cursor = Cursors.Hand
        btnBuscar.Font = New Font("Segoe UI", 12F)
        btnBuscar.Location = New Point(589, 13)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(78, 29)
        btnBuscar.TabIndex = 27
        btnBuscar.Text = "Buscar Fecha"
        btnBuscar.UseVisualStyleBackColor = True
        ' 
        ' lblFin
        ' 
        lblFin.AutoSize = True
        lblFin.Font = New Font("Segoe UI", 12F)
        lblFin.ForeColor = Color.White
        lblFin.Location = New Point(319, 18)
        lblFin.Name = "lblFin"
        lblFin.Size = New Size(34, 21)
        lblFin.TabIndex = 26
        lblFin.Text = "Fin:"
        ' 
        ' lblInicio
        ' 
        lblInicio.AutoSize = True
        lblInicio.Font = New Font("Segoe UI", 12F)
        lblInicio.ForeColor = Color.White
        lblInicio.Location = New Point(19, 18)
        lblInicio.Name = "lblInicio"
        lblInicio.Size = New Size(50, 21)
        lblInicio.TabIndex = 26
        lblInicio.Text = "Inicio:"
        ' 
        ' dtpFechaInicio
        ' 
        dtpFechaInicio.Cursor = Cursors.Hand
        dtpFechaInicio.Font = New Font("Segoe UI", 12F)
        dtpFechaInicio.Location = New Point(75, 13)
        dtpFechaInicio.Name = "dtpFechaInicio"
        dtpFechaInicio.Size = New Size(200, 29)
        dtpFechaInicio.TabIndex = 25
        ' 
        ' dtpFechaFin
        ' 
        dtpFechaFin.Cursor = Cursors.Hand
        dtpFechaFin.Font = New Font("Segoe UI", 12F)
        dtpFechaFin.Location = New Point(368, 13)
        dtpFechaFin.Name = "dtpFechaFin"
        dtpFechaFin.Size = New Size(200, 29)
        dtpFechaFin.TabIndex = 25
        ' 
        ' BtnBuscarFecha
        ' 
        BtnBuscarFecha.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        BtnBuscarFecha.Font = New Font("Segoe UI", 12F)
        BtnBuscarFecha.Location = New Point(551, -38)
        BtnBuscarFecha.Name = "BtnBuscarFecha"
        BtnBuscarFecha.Size = New Size(92, 28)
        BtnBuscarFecha.TabIndex = 22
        BtnBuscarFecha.Text = "Buscar"
        BtnBuscarFecha.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnEliminar.Cursor = Cursors.Hand
        btnEliminar.Font = New Font("Segoe UI", 12F)
        btnEliminar.Location = New Point(139, 686)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(80, 33)
        btnEliminar.TabIndex = 35
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' btnInsertar
        ' 
        btnInsertar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnInsertar.Cursor = Cursors.Hand
        btnInsertar.Font = New Font("Segoe UI", 12F)
        btnInsertar.Location = New Point(11, 687)
        btnInsertar.Name = "btnInsertar"
        btnInsertar.Size = New Size(87, 30)
        btnInsertar.TabIndex = 36
        btnInsertar.Text = "Insertar"
        btnInsertar.UseVisualStyleBackColor = True
        ' 
        ' pbReiniciar
        ' 
        pbReiniciar.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        pbReiniciar.Cursor = Cursors.Hand
        pbReiniciar.Image = My.Resources.Resources.reiniciar
        pbReiniciar.Location = New Point(962, 15)
        pbReiniciar.Name = "pbReiniciar"
        pbReiniciar.Size = New Size(34, 30)
        pbReiniciar.SizeMode = PictureBoxSizeMode.Zoom
        pbReiniciar.TabIndex = 37
        pbReiniciar.TabStop = False
        ' 
        ' FrmRegistroAsistencias
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(1008, 729)
        Controls.Add(pbReiniciar)
        Controls.Add(btnInsertar)
        Controls.Add(btnEliminar)
        Controls.Add(cbOpcionBuscar)
        Controls.Add(lblTotal)
        Controls.Add(dgvListado)
        Controls.Add(PanelFecha)
        Controls.Add(tbBuscar)
        Name = "FrmRegistroAsistencias"
        Text = "FrmRegistroAsistencias"
        CType(dgvListado, ComponentModel.ISupportInitialize).EndInit()
        PanelFecha.ResumeLayout(False)
        PanelFecha.PerformLayout()
        CType(pbReiniciar, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents cbOpcionBuscar As ComboBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents dgvListado As DataGridView
    Friend WithEvents tbBuscar As TextBox
    Friend WithEvents PanelFecha As Panel
    Friend WithEvents lblFin As Label
    Friend WithEvents lblInicio As Label
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents BtnBuscarFecha As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnInsertar As Button
    Friend WithEvents pbReiniciar As PictureBox
End Class
