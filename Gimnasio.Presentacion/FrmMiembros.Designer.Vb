<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMiembros
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
        btnEliminar = New Button()
        cbOpcionBuscar = New ComboBox()
        lblTotal = New Label()
        btnActualizar = New Button()
        dgvListado = New DataGridView()
        tbBuscar = New TextBox()
        btnInsertar = New Button()
        panelDatosIngreso = New Panel()
        lblDatosIngreso = New Label()
        tbTelefono = New TextBox()
        tbEmail = New TextBox()
        cbGenero = New ComboBox()
        btnCancelar = New Button()
        btnGuardar = New Button()
        Label2 = New Label()
        Label5 = New Label()
        labelTelefono = New Label()
        Label3 = New Label()
        tbApellido = New TextBox()
        tbDni = New TextBox()
        tbNombre = New TextBox()
        Label6 = New Label()
        Label1 = New Label()
        panelListado.SuspendLayout()
        CType(dgvListado, ComponentModel.ISupportInitialize).BeginInit()
        panelDatosIngreso.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelListado
        ' 
        panelListado.Controls.Add(btnEliminar)
        panelListado.Controls.Add(cbOpcionBuscar)
        panelListado.Controls.Add(lblTotal)
        panelListado.Controls.Add(btnActualizar)
        panelListado.Controls.Add(dgvListado)
        panelListado.Controls.Add(tbBuscar)
        panelListado.Controls.Add(btnInsertar)
        panelListado.Dock = DockStyle.Fill
        panelListado.Location = New Point(0, 0)
        panelListado.Name = "panelListado"
        panelListado.Size = New Size(1008, 729)
        panelListado.TabIndex = 0
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnEliminar.Font = New Font("Segoe UI", 12F)
        btnEliminar.Location = New Point(225, 687)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(92, 28)
        btnEliminar.TabIndex = 31
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' cbOpcionBuscar
        ' 
        cbOpcionBuscar.DropDownStyle = ComboBoxStyle.DropDownList
        cbOpcionBuscar.Font = New Font("Segoe UI", 12F)
        cbOpcionBuscar.FormattingEnabled = True
        cbOpcionBuscar.Items.AddRange(New Object() {"Buscar por nombre", "Buscar por DNI"})
        cbOpcionBuscar.Location = New Point(842, 13)
        cbOpcionBuscar.Name = "cbOpcionBuscar"
        cbOpcionBuscar.Size = New Size(155, 29)
        cbOpcionBuscar.TabIndex = 30
        ' 
        ' lblTotal
        ' 
        lblTotal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        lblTotal.AutoSize = True
        lblTotal.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        lblTotal.Font = New Font("Segoe UI", 12F)
        lblTotal.ForeColor = Color.White
        lblTotal.Location = New Point(811, 687)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(42, 21)
        lblTotal.TabIndex = 28
        lblTotal.Text = "Total"
        ' 
        ' btnActualizar
        ' 
        btnActualizar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnActualizar.Font = New Font("Segoe UI", 12F)
        btnActualizar.Location = New Point(118, 687)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(92, 28)
        btnActualizar.TabIndex = 27
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = True
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
        tbBuscar.Location = New Point(11, 13)
        tbBuscar.Name = "tbBuscar"
        tbBuscar.Size = New Size(809, 29)
        tbBuscar.TabIndex = 26
        ' 
        ' btnInsertar
        ' 
        btnInsertar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnInsertar.Font = New Font("Segoe UI", 12F)
        btnInsertar.Location = New Point(11, 686)
        btnInsertar.Name = "btnInsertar"
        btnInsertar.Size = New Size(92, 28)
        btnInsertar.TabIndex = 29
        btnInsertar.Text = "Insertar"
        btnInsertar.UseVisualStyleBackColor = True
        ' 
        ' panelDatosIngreso
        ' 
        panelDatosIngreso.Controls.Add(lblDatosIngreso)
        panelDatosIngreso.Controls.Add(tbTelefono)
        panelDatosIngreso.Controls.Add(tbEmail)
        panelDatosIngreso.Controls.Add(cbGenero)
        panelDatosIngreso.Controls.Add(btnCancelar)
        panelDatosIngreso.Controls.Add(btnGuardar)
        panelDatosIngreso.Controls.Add(Label2)
        panelDatosIngreso.Controls.Add(Label5)
        panelDatosIngreso.Controls.Add(labelTelefono)
        panelDatosIngreso.Controls.Add(Label3)
        panelDatosIngreso.Controls.Add(tbApellido)
        panelDatosIngreso.Controls.Add(tbDni)
        panelDatosIngreso.Controls.Add(tbNombre)
        panelDatosIngreso.Controls.Add(Label6)
        panelDatosIngreso.Controls.Add(Label1)
        panelDatosIngreso.Location = New Point(288, 107)
        panelDatosIngreso.Name = "panelDatosIngreso"
        panelDatosIngreso.Size = New Size(635, 546)
        panelDatosIngreso.TabIndex = 32
        panelDatosIngreso.Visible = False
        ' 
        ' lblDatosIngreso
        ' 
        lblDatosIngreso.AutoSize = True
        lblDatosIngreso.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDatosIngreso.ForeColor = Color.White
        lblDatosIngreso.Location = New Point(279, 17)
        lblDatosIngreso.Name = "lblDatosIngreso"
        lblDatosIngreso.Size = New Size(67, 21)
        lblDatosIngreso.TabIndex = 54
        lblDatosIngreso.Text = "Ingresar"
        ' 
        ' tbTelefono
        ' 
        tbTelefono.Cursor = Cursors.IBeam
        tbTelefono.Font = New Font("Segoe UI", 12F)
        tbTelefono.Location = New Point(156, 293)
        tbTelefono.Name = "tbTelefono"
        tbTelefono.Size = New Size(305, 29)
        tbTelefono.TabIndex = 53
        ' 
        ' tbEmail
        ' 
        tbEmail.Font = New Font("Segoe UI", 12F)
        tbEmail.Location = New Point(156, 350)
        tbEmail.Name = "tbEmail"
        tbEmail.Size = New Size(419, 29)
        tbEmail.TabIndex = 52
        ' 
        ' cbGenero
        ' 
        cbGenero.DropDownStyle = ComboBoxStyle.DropDownList
        cbGenero.Font = New Font("Segoe UI", 12F)
        cbGenero.FormattingEnabled = True
        cbGenero.Items.AddRange(New Object() {"Masculino", "Femenino", "Otro", "Prefiero no decir"})
        cbGenero.Location = New Point(155, 238)
        cbGenero.Name = "cbGenero"
        cbGenero.Size = New Size(306, 29)
        cbGenero.TabIndex = 51
        ' 
        ' btnCancelar
        ' 
        btnCancelar.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnCancelar.FlatAppearance.BorderSize = 0
        btnCancelar.FlatAppearance.MouseDownBackColor = Color.White
        btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        btnCancelar.FlatStyle = FlatStyle.Flat
        btnCancelar.Font = New Font("Segoe UI", 12F)
        btnCancelar.Location = New Point(378, 453)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(82, 31)
        btnCancelar.TabIndex = 50
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = False
        ' 
        ' btnGuardar
        ' 
        btnGuardar.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnGuardar.FlatAppearance.BorderColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnGuardar.FlatAppearance.MouseDownBackColor = Color.White
        btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        btnGuardar.FlatStyle = FlatStyle.Flat
        btnGuardar.Font = New Font("Segoe UI", 12F)
        btnGuardar.Location = New Point(156, 453)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(83, 31)
        btnGuardar.TabIndex = 49
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(60, 174)
        Label2.Name = "Label2"
        Label2.Size = New Size(87, 21)
        Label2.TabIndex = 40
        Label2.Text = "Apellido(*):"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F)
        Label5.ForeColor = Color.White
        Label5.Location = New Point(89, 353)
        Label5.Name = "Label5"
        Label5.Size = New Size(51, 21)
        Label5.TabIndex = 41
        Label5.Text = "Email:"
        ' 
        ' labelTelefono
        ' 
        labelTelefono.AutoSize = True
        labelTelefono.Font = New Font("Segoe UI", 12F)
        labelTelefono.ForeColor = Color.White
        labelTelefono.Location = New Point(69, 296)
        labelTelefono.Name = "labelTelefono"
        labelTelefono.Size = New Size(71, 21)
        labelTelefono.TabIndex = 42
        labelTelefono.Text = "Telefono:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(83, 241)
        Label3.Name = "Label3"
        Label3.Size = New Size(64, 21)
        Label3.TabIndex = 43
        Label3.Text = "Genero:"
        ' 
        ' tbApellido
        ' 
        tbApellido.Cursor = Cursors.IBeam
        tbApellido.Font = New Font("Segoe UI", 12F)
        tbApellido.Location = New Point(153, 174)
        tbApellido.Name = "tbApellido"
        tbApellido.Size = New Size(418, 29)
        tbApellido.TabIndex = 46
        ' 
        ' tbDni
        ' 
        tbDni.Cursor = Cursors.IBeam
        tbDni.Font = New Font("Segoe UI", 12F)
        tbDni.Location = New Point(155, 63)
        tbDni.Name = "tbDni"
        tbDni.Size = New Size(418, 29)
        tbDni.TabIndex = 47
        ' 
        ' tbNombre
        ' 
        tbNombre.Cursor = Cursors.IBeam
        tbNombre.Font = New Font("Segoe UI", 12F)
        tbNombre.Location = New Point(153, 115)
        tbNombre.Name = "tbNombre"
        tbNombre.Size = New Size(418, 29)
        tbNombre.TabIndex = 48
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(83, 63)
        Label6.Name = "Label6"
        Label6.Size = New Size(57, 21)
        Label6.TabIndex = 44
        Label6.Text = "DNI(*):"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(59, 115)
        Label1.Name = "Label1"
        Label1.Size = New Size(88, 21)
        Label1.TabIndex = 45
        Label1.Text = "Nombre(*):"
        ' 
        ' FrmMiembros
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(1008, 729)
        Controls.Add(panelDatosIngreso)
        Controls.Add(panelListado)
        Name = "FrmMiembros"
        Text = "FrmMiembros"
        panelListado.ResumeLayout(False)
        panelListado.PerformLayout()
        CType(dgvListado, ComponentModel.ISupportInitialize).EndInit()
        panelDatosIngreso.ResumeLayout(False)
        panelDatosIngreso.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents panelListado As Panel
    Friend WithEvents btnEliminar As Button
    Friend WithEvents cbOpcionBuscar As ComboBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnActualizar As Button
    Friend WithEvents dgvListado As DataGridView
    Friend WithEvents tbBuscar As TextBox
    Friend WithEvents btnInsertar As Button
    Friend WithEvents panelDatosIngreso As Panel
    Friend WithEvents tbTelefono As TextBox
    Friend WithEvents tbEmail As TextBox
    Friend WithEvents cbGenero As ComboBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents labelTelefono As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tbApellido As TextBox
    Friend WithEvents tbDni As TextBox
    Friend WithEvents tbNombre As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblDatosIngreso As Label
End Class
