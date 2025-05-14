<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistroAsistencias
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        cbOpcionBuscar = New ComboBox()
        lblTotal = New Label()
        dgvListado = New DataGridView()
        tbBuscar = New TextBox()
        PanelFecha = New Panel()
        btnBuscar = New Button()
        Label4 = New Label()
        Label3 = New Label()
        dtpFechaInicio = New DateTimePicker()
        dtpFechaFin = New DateTimePicker()
        Label2 = New Label()
        Label1 = New Label()
        BtnBuscarFecha = New Button()
        btnEliminar = New Button()
        CType(dgvListado, ComponentModel.ISupportInitialize).BeginInit()
        PanelFecha.SuspendLayout()
        SuspendLayout()
        ' 
        ' cbOpcionBuscar
        ' 
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
        PanelFecha.Controls.Add(Label4)
        PanelFecha.Controls.Add(Label3)
        PanelFecha.Controls.Add(dtpFechaInicio)
        PanelFecha.Controls.Add(dtpFechaFin)
        PanelFecha.Controls.Add(Label2)
        PanelFecha.Controls.Add(Label1)
        PanelFecha.Controls.Add(BtnBuscarFecha)
        PanelFecha.Location = New Point(269, 2)
        PanelFecha.Name = "PanelFecha"
        PanelFecha.Size = New Size(670, 49)
        PanelFecha.TabIndex = 34
        ' 
        ' btnBuscar
        ' 
        btnBuscar.Font = New Font("Segoe UI", 12F)
        btnBuscar.Location = New Point(589, 13)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(78, 29)
        btnBuscar.TabIndex = 27
        btnBuscar.Text = "Buscar Fecha"
        btnBuscar.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(299, 19)
        Label4.Name = "Label4"
        Label4.Size = New Size(49, 21)
        Label4.TabIndex = 26
        Label4.Text = "Hasta"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(13, 19)
        Label3.Name = "Label3"
        Label3.Size = New Size(56, 21)
        Label3.TabIndex = 26
        Label3.Text = "Desde:"
        ' 
        ' dtpFechaInicio
        ' 
        dtpFechaInicio.Font = New Font("Segoe UI", 12F)
        dtpFechaInicio.Location = New Point(75, 13)
        dtpFechaInicio.Name = "dtpFechaInicio"
        dtpFechaInicio.Size = New Size(200, 29)
        dtpFechaInicio.TabIndex = 25
        ' 
        ' dtpFechaFin
        ' 
        dtpFechaFin.Font = New Font("Segoe UI", 12F)
        dtpFechaFin.Location = New Point(368, 13)
        dtpFechaFin.Name = "dtpFechaFin"
        dtpFechaFin.Size = New Size(200, 29)
        dtpFechaFin.TabIndex = 25
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Label2.AutoSize = True
        Label2.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(740, -36)
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
        Label1.Location = New Point(473, -36)
        Label1.Name = "Label1"
        Label1.Size = New Size(50, 21)
        Label1.TabIndex = 21
        Label1.Text = "Inicio:"
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
        btnEliminar.Font = New Font("Segoe UI", 12F)
        btnEliminar.Location = New Point(11, 684)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(80, 33)
        btnEliminar.TabIndex = 35
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' FrmRegistroAsistencias
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(1008, 729)
        Controls.Add(btnEliminar)
        Controls.Add(PanelFecha)
        Controls.Add(cbOpcionBuscar)
        Controls.Add(lblTotal)
        Controls.Add(dgvListado)
        Controls.Add(tbBuscar)
        Name = "FrmRegistroAsistencias"
        Text = "FrmRegistroAsistencias"
        CType(dgvListado, ComponentModel.ISupportInitialize).EndInit()
        PanelFecha.ResumeLayout(False)
        PanelFecha.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents cbOpcionBuscar As ComboBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents dgvListado As DataGridView
    Friend WithEvents tbBuscar As TextBox
    Friend WithEvents PanelFecha As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnBuscarFecha As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnEliminar As Button
End Class
