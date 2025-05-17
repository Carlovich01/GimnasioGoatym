<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUsuarios
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
        pbReiniciar = New PictureBox()
        btnEliminar = New Button()
        cbOpcionBuscar = New ComboBox()
        lblTotal = New Label()
        btnActualizar = New Button()
        dgvListado = New DataGridView()
        tbBuscar = New TextBox()
        btnInsertar = New Button()
        panelDatosIngreso = New Panel()
        tbID = New TextBox()
        lblDatosIngreso = New Label()
        pbMostrarContraseña = New PictureBox()
        tbEmail = New TextBox()
        cbRol = New ComboBox()
        btnCancelar = New Button()
        btnGuardar = New Button()
        Label2 = New Label()
        labelTelefono = New Label()
        Label3 = New Label()
        tbNombreCompleto = New TextBox()
        tbNombreUsuario = New TextBox()
        tbContraseña = New TextBox()
        Label6 = New Label()
        Label1 = New Label()
        panelListado.SuspendLayout()
        CType(pbReiniciar, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvListado, ComponentModel.ISupportInitialize).BeginInit()
        panelDatosIngreso.SuspendLayout()
        CType(pbMostrarContraseña, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' panelListado
        ' 
        panelListado.Controls.Add(pbReiniciar)
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
        ' pbReiniciar
        ' 
        pbReiniciar.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        pbReiniciar.Cursor = Cursors.Hand
        pbReiniciar.Image = My.Resources.Resources.reiniciar
        pbReiniciar.Location = New Point(962, 11)
        pbReiniciar.Name = "pbReiniciar"
        pbReiniciar.Size = New Size(34, 30)
        pbReiniciar.SizeMode = PictureBoxSizeMode.Zoom
        pbReiniciar.TabIndex = 48
        pbReiniciar.TabStop = False
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnEliminar.Cursor = Cursors.Hand
        btnEliminar.Font = New Font("Segoe UI", 12F)
        btnEliminar.Location = New Point(225, 687)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(92, 28)
        btnEliminar.TabIndex = 47
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' cbOpcionBuscar
        ' 
        cbOpcionBuscar.Cursor = Cursors.Hand
        cbOpcionBuscar.DropDownStyle = ComboBoxStyle.DropDownList
        cbOpcionBuscar.Font = New Font("Segoe UI", 12F)
        cbOpcionBuscar.FormattingEnabled = True
        cbOpcionBuscar.Items.AddRange(New Object() {"Buscar por nombre"})
        cbOpcionBuscar.Location = New Point(753, 12)
        cbOpcionBuscar.Name = "cbOpcionBuscar"
        cbOpcionBuscar.Size = New Size(186, 29)
        cbOpcionBuscar.TabIndex = 46
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
        lblTotal.Size = New Size(114, 21)
        lblTotal.TabIndex = 44
        lblTotal.Text = "Total Usuarios: "
        ' 
        ' btnActualizar
        ' 
        btnActualizar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnActualizar.Cursor = Cursors.Hand
        btnActualizar.Font = New Font("Segoe UI", 12F)
        btnActualizar.Location = New Point(118, 687)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(92, 28)
        btnActualizar.TabIndex = 43
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
        dgvListado.TabIndex = 41
        ' 
        ' tbBuscar
        ' 
        tbBuscar.Font = New Font("Segoe UI", 12F)
        tbBuscar.Location = New Point(11, 13)
        tbBuscar.Name = "tbBuscar"
        tbBuscar.Size = New Size(716, 29)
        tbBuscar.TabIndex = 42
        ' 
        ' btnInsertar
        ' 
        btnInsertar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnInsertar.Cursor = Cursors.Hand
        btnInsertar.Font = New Font("Segoe UI", 12F)
        btnInsertar.Location = New Point(11, 686)
        btnInsertar.Name = "btnInsertar"
        btnInsertar.Size = New Size(92, 28)
        btnInsertar.TabIndex = 45
        btnInsertar.Text = "Insertar"
        btnInsertar.UseVisualStyleBackColor = True
        ' 
        ' panelDatosIngreso
        ' 
        panelDatosIngreso.Controls.Add(tbID)
        panelDatosIngreso.Controls.Add(lblDatosIngreso)
        panelDatosIngreso.Controls.Add(pbMostrarContraseña)
        panelDatosIngreso.Controls.Add(tbEmail)
        panelDatosIngreso.Controls.Add(cbRol)
        panelDatosIngreso.Controls.Add(btnCancelar)
        panelDatosIngreso.Controls.Add(btnGuardar)
        panelDatosIngreso.Controls.Add(Label2)
        panelDatosIngreso.Controls.Add(labelTelefono)
        panelDatosIngreso.Controls.Add(Label3)
        panelDatosIngreso.Controls.Add(tbNombreCompleto)
        panelDatosIngreso.Controls.Add(tbNombreUsuario)
        panelDatosIngreso.Controls.Add(tbContraseña)
        panelDatosIngreso.Controls.Add(Label6)
        panelDatosIngreso.Controls.Add(Label1)
        panelDatosIngreso.Location = New Point(225, 163)
        panelDatosIngreso.Name = "panelDatosIngreso"
        panelDatosIngreso.Size = New Size(700, 449)
        panelDatosIngreso.TabIndex = 48
        panelDatosIngreso.Visible = False
        ' 
        ' tbID
        ' 
        tbID.AccessibleRole = AccessibleRole.SplitButton
        tbID.Location = New Point(513, 11)
        tbID.Name = "tbID"
        tbID.Size = New Size(100, 23)
        tbID.TabIndex = 69
        tbID.Visible = False
        ' 
        ' lblDatosIngreso
        ' 
        lblDatosIngreso.AutoSize = True
        lblDatosIngreso.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDatosIngreso.ForeColor = Color.White
        lblDatosIngreso.ImageAlign = ContentAlignment.TopLeft
        lblDatosIngreso.Location = New Point(310, 13)
        lblDatosIngreso.Name = "lblDatosIngreso"
        lblDatosIngreso.Size = New Size(124, 21)
        lblDatosIngreso.TabIndex = 68
        lblDatosIngreso.Text = "Agregar Usuario"
        ' 
        ' pbMostrarContraseña
        ' 
        pbMostrarContraseña.Cursor = Cursors.Hand
        pbMostrarContraseña.Image = My.Resources.Resources.ojo_cerrado
        pbMostrarContraseña.Location = New Point(628, 92)
        pbMostrarContraseña.Name = "pbMostrarContraseña"
        pbMostrarContraseña.Size = New Size(52, 50)
        pbMostrarContraseña.SizeMode = PictureBoxSizeMode.Zoom
        pbMostrarContraseña.TabIndex = 67
        pbMostrarContraseña.TabStop = False
        ' 
        ' tbEmail
        ' 
        tbEmail.Cursor = Cursors.IBeam
        tbEmail.Font = New Font("Segoe UI", 12F)
        tbEmail.Location = New Point(196, 219)
        tbEmail.Name = "tbEmail"
        tbEmail.Size = New Size(305, 29)
        tbEmail.TabIndex = 66
        ' 
        ' cbRol
        ' 
        cbRol.Cursor = Cursors.Hand
        cbRol.Font = New Font("Segoe UI", 12F)
        cbRol.FormattingEnabled = True
        cbRol.Items.AddRange(New Object() {"Administrador", "Recepcionista"})
        cbRol.Location = New Point(196, 275)
        cbRol.Name = "cbRol"
        cbRol.Size = New Size(306, 29)
        cbRol.TabIndex = 65
        ' 
        ' btnCancelar
        ' 
        btnCancelar.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnCancelar.Cursor = Cursors.Hand
        btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnCancelar.FlatAppearance.BorderSize = 0
        btnCancelar.FlatAppearance.MouseDownBackColor = Color.White
        btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        btnCancelar.FlatStyle = FlatStyle.Flat
        btnCancelar.Font = New Font("Segoe UI", 12F)
        btnCancelar.Location = New Point(366, 369)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(82, 31)
        btnCancelar.TabIndex = 64
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = False
        ' 
        ' btnGuardar
        ' 
        btnGuardar.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnGuardar.Cursor = Cursors.Hand
        btnGuardar.FlatAppearance.BorderColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnGuardar.FlatAppearance.MouseDownBackColor = Color.White
        btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        btnGuardar.FlatStyle = FlatStyle.Flat
        btnGuardar.Font = New Font("Segoe UI", 12F)
        btnGuardar.Location = New Point(195, 369)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(83, 31)
        btnGuardar.TabIndex = 63
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(25, 168)
        Label2.Name = "Label2"
        Label2.Size = New Size(164, 21)
        Label2.TabIndex = 55
        Label2.Text = "Nombre Completo (*):"
        ' 
        ' labelTelefono
        ' 
        labelTelefono.AutoSize = True
        labelTelefono.Font = New Font("Segoe UI", 12F)
        labelTelefono.ForeColor = Color.White
        labelTelefono.Location = New Point(132, 283)
        labelTelefono.Name = "labelTelefono"
        labelTelefono.Size = New Size(53, 21)
        labelTelefono.TabIndex = 56
        labelTelefono.Text = "Rol(*):"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(132, 222)
        Label3.Name = "Label3"
        Label3.Size = New Size(51, 21)
        Label3.TabIndex = 57
        Label3.Text = "Email:"
        ' 
        ' tbNombreCompleto
        ' 
        tbNombreCompleto.Cursor = Cursors.IBeam
        tbNombreCompleto.Font = New Font("Segoe UI", 12F)
        tbNombreCompleto.Location = New Point(195, 160)
        tbNombreCompleto.Name = "tbNombreCompleto"
        tbNombreCompleto.Size = New Size(418, 29)
        tbNombreCompleto.TabIndex = 60
        ' 
        ' tbNombreUsuario
        ' 
        tbNombreUsuario.Cursor = Cursors.IBeam
        tbNombreUsuario.Font = New Font("Segoe UI", 12F)
        tbNombreUsuario.Location = New Point(195, 49)
        tbNombreUsuario.Name = "tbNombreUsuario"
        tbNombreUsuario.Size = New Size(418, 29)
        tbNombreUsuario.TabIndex = 61
        ' 
        ' tbContraseña
        ' 
        tbContraseña.Cursor = Cursors.IBeam
        tbContraseña.Font = New Font("Segoe UI", 12F)
        tbContraseña.Location = New Point(195, 101)
        tbContraseña.Name = "tbContraseña"
        tbContraseña.Size = New Size(418, 29)
        tbContraseña.TabIndex = 62
        tbContraseña.UseSystemPasswordChar = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(21, 49)
        Label6.Name = "Label6"
        Label6.Size = New Size(167, 21)
        Label6.TabIndex = 58
        Label6.Text = "Nombre de Usuario(*):"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(79, 104)
        Label1.Name = "Label1"
        Label1.Size = New Size(109, 21)
        Label1.TabIndex = 59
        Label1.Text = "Contraseña(*):"
        ' 
        ' FrmUsuarios
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(1008, 729)
        Controls.Add(panelDatosIngreso)
        Controls.Add(panelListado)
        Name = "FrmUsuarios"
        Text = "FrmUsuarios"
        panelListado.ResumeLayout(False)
        panelListado.PerformLayout()
        CType(pbReiniciar, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvListado, ComponentModel.ISupportInitialize).EndInit()
        panelDatosIngreso.ResumeLayout(False)
        panelDatosIngreso.PerformLayout()
        CType(pbMostrarContraseña, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents pbMostrarContraseña As PictureBox
    Friend WithEvents tbEmail As TextBox
    Friend WithEvents cbRol As ComboBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents labelTelefono As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tbNombreCompleto As TextBox
    Friend WithEvents tbNombreUsuario As TextBox
    Friend WithEvents tbContraseña As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblDatosIngreso As Label
    Friend WithEvents pbReiniciar As PictureBox
    Friend WithEvents tbID As TextBox
End Class
