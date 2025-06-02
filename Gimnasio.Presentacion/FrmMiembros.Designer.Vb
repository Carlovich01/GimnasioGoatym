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
        tbTelefono = New TextBox()
        tbEmail = New TextBox()
        cbGenero = New ComboBox()
        btnCancelar = New Button()
        btnGuardar = New Button()
        lblApellido = New Label()
        lblEmail = New Label()
        lblTelefono = New Label()
        lblGenero = New Label()
        tbApellido = New TextBox()
        tbDni = New TextBox()
        tbNombre = New TextBox()
        lblDNI = New Label()
        lblNombre = New Label()
        panelListado.SuspendLayout()
        CType(pbReiniciar, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvListado, ComponentModel.ISupportInitialize).BeginInit()
        panelDatosIngreso.SuspendLayout()
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
        pbReiniciar.Location = New Point(962, 12)
        pbReiniciar.Name = "pbReiniciar"
        pbReiniciar.Size = New Size(34, 30)
        pbReiniciar.SizeMode = PictureBoxSizeMode.Zoom
        pbReiniciar.TabIndex = 33
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
        btnEliminar.TabIndex = 31
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' cbOpcionBuscar
        ' 
        cbOpcionBuscar.Cursor = Cursors.Hand
        cbOpcionBuscar.DropDownStyle = ComboBoxStyle.DropDownList
        cbOpcionBuscar.Font = New Font("Segoe UI", 12F)
        cbOpcionBuscar.FormattingEnabled = True
        cbOpcionBuscar.Items.AddRange(New Object() {"Buscar por nombre", "Buscar por DNI"})
        cbOpcionBuscar.Location = New Point(723, 13)
        cbOpcionBuscar.Name = "cbOpcionBuscar"
        cbOpcionBuscar.Size = New Size(222, 29)
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
        btnActualizar.Cursor = Cursors.Hand
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
        tbBuscar.Size = New Size(687, 29)
        tbBuscar.TabIndex = 26
        ' 
        ' btnInsertar
        ' 
        btnInsertar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnInsertar.Cursor = Cursors.Hand
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
        panelDatosIngreso.Controls.Add(tbID)
        panelDatosIngreso.Controls.Add(lblDatosIngreso)
        panelDatosIngreso.Controls.Add(tbTelefono)
        panelDatosIngreso.Controls.Add(tbEmail)
        panelDatosIngreso.Controls.Add(cbGenero)
        panelDatosIngreso.Controls.Add(btnCancelar)
        panelDatosIngreso.Controls.Add(btnGuardar)
        panelDatosIngreso.Controls.Add(lblApellido)
        panelDatosIngreso.Controls.Add(lblEmail)
        panelDatosIngreso.Controls.Add(lblTelefono)
        panelDatosIngreso.Controls.Add(lblGenero)
        panelDatosIngreso.Controls.Add(tbApellido)
        panelDatosIngreso.Controls.Add(tbDni)
        panelDatosIngreso.Controls.Add(tbNombre)
        panelDatosIngreso.Controls.Add(lblDNI)
        panelDatosIngreso.Controls.Add(lblNombre)
        panelDatosIngreso.Location = New Point(288, 107)
        panelDatosIngreso.Name = "panelDatosIngreso"
        panelDatosIngreso.Size = New Size(635, 546)
        panelDatosIngreso.TabIndex = 32
        panelDatosIngreso.Visible = False
        ' 
        ' tbID
        ' 
        tbID.AccessibleRole = AccessibleRole.SplitButton
        tbID.Location = New Point(475, 19)
        tbID.Name = "tbID"
        tbID.Size = New Size(100, 23)
        tbID.TabIndex = 55
        tbID.Visible = False
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
        cbGenero.Cursor = Cursors.Hand
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
        ' lblApellido
        ' 
        lblApellido.AutoSize = True
        lblApellido.Font = New Font("Segoe UI", 12F)
        lblApellido.ForeColor = Color.White
        lblApellido.Location = New Point(60, 174)
        lblApellido.Name = "lblApellido"
        lblApellido.Size = New Size(87, 21)
        lblApellido.TabIndex = 40
        lblApellido.Text = "Apellido(*):"
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Font = New Font("Segoe UI", 12F)
        lblEmail.ForeColor = Color.White
        lblEmail.Location = New Point(89, 353)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(51, 21)
        lblEmail.TabIndex = 41
        lblEmail.Text = "Email:"
        ' 
        ' lblTelefono
        ' 
        lblTelefono.AutoSize = True
        lblTelefono.Font = New Font("Segoe UI", 12F)
        lblTelefono.ForeColor = Color.White
        lblTelefono.Location = New Point(69, 296)
        lblTelefono.Name = "lblTelefono"
        lblTelefono.Size = New Size(71, 21)
        lblTelefono.TabIndex = 42
        lblTelefono.Text = "Telefono:"
        ' 
        ' lblGenero
        ' 
        lblGenero.AutoSize = True
        lblGenero.Font = New Font("Segoe UI", 12F)
        lblGenero.ForeColor = Color.White
        lblGenero.Location = New Point(83, 241)
        lblGenero.Name = "lblGenero"
        lblGenero.Size = New Size(64, 21)
        lblGenero.TabIndex = 43
        lblGenero.Text = "Genero:"
        ' 
        ' tbApellido
        ' 
        tbApellido.Cursor = Cursors.IBeam
        tbApellido.Font = New Font("Segoe UI", 12F)
        tbApellido.Location = New Point(153, 174)
        tbApellido.Name = "tbApellido"
        tbApellido.Size = New Size(418, 29)
        tbApellido.TabIndex = 48
        ' 
        ' tbDni
        ' 
        tbDni.Cursor = Cursors.IBeam
        tbDni.Font = New Font("Segoe UI", 12F)
        tbDni.Location = New Point(155, 63)
        tbDni.Name = "tbDni"
        tbDni.Size = New Size(418, 29)
        tbDni.TabIndex = 46
        ' 
        ' tbNombre
        ' 
        tbNombre.Cursor = Cursors.IBeam
        tbNombre.Font = New Font("Segoe UI", 12F)
        tbNombre.Location = New Point(153, 115)
        tbNombre.Name = "tbNombre"
        tbNombre.Size = New Size(418, 29)
        tbNombre.TabIndex = 47
        ' 
        ' lblDNI
        ' 
        lblDNI.AutoSize = True
        lblDNI.Font = New Font("Segoe UI", 12F)
        lblDNI.ForeColor = Color.White
        lblDNI.Location = New Point(83, 63)
        lblDNI.Name = "lblDNI"
        lblDNI.Size = New Size(57, 21)
        lblDNI.TabIndex = 44
        lblDNI.Text = "DNI(*):"
        ' 
        ' lblNombre
        ' 
        lblNombre.AutoSize = True
        lblNombre.Font = New Font("Segoe UI", 12F)
        lblNombre.ForeColor = Color.White
        lblNombre.Location = New Point(59, 115)
        lblNombre.Name = "lblNombre"
        lblNombre.Size = New Size(88, 21)
        lblNombre.TabIndex = 45
        lblNombre.Text = "Nombre(*):"
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
        CType(pbReiniciar, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblApellido As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblTelefono As Label
    Friend WithEvents lblGenero As Label
    Friend WithEvents tbApellido As TextBox
    Friend WithEvents tbDni As TextBox
    Friend WithEvents tbNombre As TextBox
    Friend WithEvents lblDNI As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents lblDatosIngreso As Label
    Friend WithEvents pbReiniciar As PictureBox
    Friend WithEvents tbID As TextBox
End Class
