<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlanes
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
        panelListado = New Panel()
        pbReiniciar = New PictureBox()
        cbOpcionBuscar = New ComboBox()
        lblTotal = New Label()
        btnActualizar = New Button()
        btnEliminar = New Button()
        dgvListado = New DataGridView()
        tbBuscar = New TextBox()
        btnInsertar = New Button()
        panelDatosIngreso = New Panel()
        tbID = New TextBox()
        lblDatosIngreso = New Label()
        btnCancelar = New Button()
        btnGuardar = New Button()
        tbDescripcion = New TextBox()
        lblDescripcion = New Label()
        tbPrecio = New TextBox()
        lblDuracion = New Label()
        tbDuracion = New TextBox()
        lblPrecio = New Label()
        tbNombre = New TextBox()
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
        panelListado.Controls.Add(cbOpcionBuscar)
        panelListado.Controls.Add(lblTotal)
        panelListado.Controls.Add(btnActualizar)
        panelListado.Controls.Add(btnEliminar)
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
        pbReiniciar.TabIndex = 32
        pbReiniciar.TabStop = False
        ' 
        ' cbOpcionBuscar
        ' 
        cbOpcionBuscar.Cursor = Cursors.Hand
        cbOpcionBuscar.DropDownStyle = ComboBoxStyle.DropDownList
        cbOpcionBuscar.Font = New Font("Segoe UI", 12F)
        cbOpcionBuscar.FormattingEnabled = True
        cbOpcionBuscar.Items.AddRange(New Object() {"Buscar por nombre", "Buscar por duracion (Presione Enter)", "Buscar por precio (Presione Enter)"})
        cbOpcionBuscar.Location = New Point(631, 13)
        cbOpcionBuscar.Name = "cbOpcionBuscar"
        cbOpcionBuscar.Size = New Size(310, 29)
        cbOpcionBuscar.TabIndex = 31
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
        lblTotal.Size = New Size(94, 21)
        lblTotal.TabIndex = 29
        lblTotal.Text = "Total Planes:"
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
        ' btnEliminar
        ' 
        btnEliminar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnEliminar.Cursor = Cursors.Hand
        btnEliminar.Font = New Font("Segoe UI", 12F)
        btnEliminar.Location = New Point(227, 687)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(92, 28)
        btnEliminar.TabIndex = 28
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
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
        tbBuscar.Size = New Size(598, 29)
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
        btnInsertar.TabIndex = 30
        btnInsertar.Text = "Insertar"
        btnInsertar.UseVisualStyleBackColor = True
        ' 
        ' panelDatosIngreso
        ' 
        panelDatosIngreso.Controls.Add(tbID)
        panelDatosIngreso.Controls.Add(lblDatosIngreso)
        panelDatosIngreso.Controls.Add(btnCancelar)
        panelDatosIngreso.Controls.Add(btnGuardar)
        panelDatosIngreso.Controls.Add(tbDescripcion)
        panelDatosIngreso.Controls.Add(lblDescripcion)
        panelDatosIngreso.Controls.Add(tbPrecio)
        panelDatosIngreso.Controls.Add(lblDuracion)
        panelDatosIngreso.Controls.Add(tbDuracion)
        panelDatosIngreso.Controls.Add(lblPrecio)
        panelDatosIngreso.Controls.Add(tbNombre)
        panelDatosIngreso.Controls.Add(lblNombre)
        panelDatosIngreso.ForeColor = SystemColors.ControlText
        panelDatosIngreso.Location = New Point(423, 148)
        panelDatosIngreso.Name = "panelDatosIngreso"
        panelDatosIngreso.Size = New Size(553, 486)
        panelDatosIngreso.TabIndex = 32
        panelDatosIngreso.Visible = False
        ' 
        ' tbID
        ' 
        tbID.AccessibleRole = AccessibleRole.SplitButton
        tbID.Location = New Point(434, 18)
        tbID.Name = "tbID"
        tbID.Size = New Size(100, 23)
        tbID.TabIndex = 37
        tbID.Visible = False
        ' 
        ' lblDatosIngreso
        ' 
        lblDatosIngreso.AutoSize = True
        lblDatosIngreso.Font = New Font("Segoe UI", 12F)
        lblDatosIngreso.ForeColor = Color.White
        lblDatosIngreso.Location = New Point(192, 16)
        lblDatosIngreso.Name = "lblDatosIngreso"
        lblDatosIngreso.Size = New Size(197, 21)
        lblDatosIngreso.TabIndex = 36
        lblDatosIngreso.Text = "Ingrese los datos de planes"
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
        btnCancelar.Location = New Point(377, 400)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(82, 31)
        btnCancelar.TabIndex = 35
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
        btnGuardar.Location = New Point(117, 400)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(83, 31)
        btnGuardar.TabIndex = 34
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = False
        ' 
        ' tbDescripcion
        ' 
        tbDescripcion.Cursor = Cursors.IBeam
        tbDescripcion.Font = New Font("Segoe UI", 12F)
        tbDescripcion.Location = New Point(117, 131)
        tbDescripcion.Multiline = True
        tbDescripcion.Name = "tbDescripcion"
        tbDescripcion.Size = New Size(418, 111)
        tbDescripcion.TabIndex = 31
        ' 
        ' lblDescripcion
        ' 
        lblDescripcion.AutoSize = True
        lblDescripcion.Font = New Font("Segoe UI", 12F)
        lblDescripcion.ForeColor = Color.White
        lblDescripcion.Location = New Point(16, 131)
        lblDescripcion.Name = "lblDescripcion"
        lblDescripcion.Size = New Size(94, 21)
        lblDescripcion.TabIndex = 26
        lblDescripcion.Text = "Descripcion:"
        ' 
        ' tbPrecio
        ' 
        tbPrecio.Font = New Font("Segoe UI", 12F)
        tbPrecio.Location = New Point(117, 316)
        tbPrecio.Name = "tbPrecio"
        tbPrecio.Size = New Size(158, 29)
        tbPrecio.TabIndex = 33
        ' 
        ' lblDuracion
        ' 
        lblDuracion.AutoSize = True
        lblDuracion.Font = New Font("Segoe UI", 12F)
        lblDuracion.ForeColor = Color.White
        lblDuracion.Location = New Point(18, 266)
        lblDuracion.Name = "lblDuracion"
        lblDuracion.Size = New Size(93, 21)
        lblDuracion.TabIndex = 27
        lblDuracion.Text = "Duracion(*):"
        ' 
        ' tbDuracion
        ' 
        tbDuracion.Font = New Font("Segoe UI", 12F)
        tbDuracion.Location = New Point(117, 264)
        tbDuracion.Name = "tbDuracion"
        tbDuracion.Size = New Size(158, 29)
        tbDuracion.TabIndex = 32
        ' 
        ' lblPrecio
        ' 
        lblPrecio.AutoSize = True
        lblPrecio.Font = New Font("Segoe UI", 12F)
        lblPrecio.ForeColor = Color.White
        lblPrecio.Location = New Point(33, 316)
        lblPrecio.Name = "lblPrecio"
        lblPrecio.Size = New Size(73, 21)
        lblPrecio.TabIndex = 28
        lblPrecio.Text = "Precio(*):"
        ' 
        ' tbNombre
        ' 
        tbNombre.Cursor = Cursors.IBeam
        tbNombre.Font = New Font("Segoe UI", 12F)
        tbNombre.Location = New Point(116, 71)
        tbNombre.Name = "tbNombre"
        tbNombre.Size = New Size(418, 29)
        tbNombre.TabIndex = 30
        ' 
        ' lblNombre
        ' 
        lblNombre.AutoSize = True
        lblNombre.Font = New Font("Segoe UI", 12F)
        lblNombre.ForeColor = Color.White
        lblNombre.Location = New Point(22, 74)
        lblNombre.Name = "lblNombre"
        lblNombre.Size = New Size(88, 21)
        lblNombre.TabIndex = 29
        lblNombre.Text = "Nombre(*):"
        ' 
        ' FrmPlanes
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(1008, 729)
        Controls.Add(panelDatosIngreso)
        Controls.Add(panelListado)
        Name = "FrmPlanes"
        Text = "FrmPlanes"
        panelListado.ResumeLayout(False)
        panelListado.PerformLayout()
        CType(pbReiniciar, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvListado, ComponentModel.ISupportInitialize).EndInit()
        panelDatosIngreso.ResumeLayout(False)
        panelDatosIngreso.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents panelListado As Panel
    Friend WithEvents panelDatosIngreso As Panel
    Friend WithEvents cbOpcionBuscar As ComboBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnActualizar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents dgvListado As DataGridView
    Friend WithEvents tbBuscar As TextBox
    Friend WithEvents btnInsertar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents tbDescripcion As TextBox
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents tbPrecio As TextBox
    Friend WithEvents lblDuracion As Label
    Friend WithEvents tbDuracion As TextBox
    Friend WithEvents lblPrecio As Label
    Friend WithEvents tbNombre As TextBox
    Friend WithEvents lblNombre As Label
    Friend WithEvents lblDatosIngreso As Label
    Friend WithEvents pbReiniciar As PictureBox
    Friend WithEvents tbID As TextBox
End Class
