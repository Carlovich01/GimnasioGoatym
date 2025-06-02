<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReclamos
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
        lblBuscar = New Label()
        btnEliminar = New Button()
        cbOpcionBuscar = New ComboBox()
        lblTotal = New Label()
        btnActualizar = New Button()
        btnCambiarEstado = New Button()
        dgvListado = New DataGridView()
        btnInsertar = New Button()
        btnResponder = New Button()
        panelRespuestaIngreso = New Panel()
        lblResponder = New Label()
        tbCancelarRespuesta = New Button()
        tbGuardarRespuesta = New Button()
        TbRespuesta = New TextBox()
        panelDatosIngreso = New Panel()
        tbID = New TextBox()
        lblDatosIngreso = New Label()
        lblDNI = New Label()
        tbDNI = New TextBox()
        cbTipo = New ComboBox()
        btnCancelar = New Button()
        btnGuardar = New Button()
        tbDescripcion = New TextBox()
        lblDescripcion = New Label()
        lblTipo = New Label()
        pbReiniciar = New PictureBox()
        panelListado.SuspendLayout()
        CType(dgvListado, ComponentModel.ISupportInitialize).BeginInit()
        panelRespuestaIngreso.SuspendLayout()
        panelDatosIngreso.SuspendLayout()
        CType(pbReiniciar, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' panelListado
        ' 
        panelListado.Controls.Add(pbReiniciar)
        panelListado.Controls.Add(lblBuscar)
        panelListado.Controls.Add(btnEliminar)
        panelListado.Controls.Add(cbOpcionBuscar)
        panelListado.Controls.Add(lblTotal)
        panelListado.Controls.Add(btnActualizar)
        panelListado.Controls.Add(btnCambiarEstado)
        panelListado.Controls.Add(dgvListado)
        panelListado.Controls.Add(btnInsertar)
        panelListado.Controls.Add(btnResponder)
        panelListado.Dock = DockStyle.Fill
        panelListado.Location = New Point(0, 0)
        panelListado.Name = "panelListado"
        panelListado.Size = New Size(1008, 729)
        panelListado.TabIndex = 0
        ' 
        ' lblBuscar
        ' 
        lblBuscar.AutoSize = True
        lblBuscar.Font = New Font("Segoe UI", 12F)
        lblBuscar.ForeColor = Color.White
        lblBuscar.Location = New Point(17, 15)
        lblBuscar.Name = "lblBuscar"
        lblBuscar.Size = New Size(87, 21)
        lblBuscar.TabIndex = 54
        lblBuscar.Text = "Buscar por:"
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnEliminar.Cursor = Cursors.Hand
        btnEliminar.Font = New Font("Segoe UI", 12F)
        btnEliminar.Location = New Point(236, 689)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(92, 28)
        btnEliminar.TabIndex = 53
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' cbOpcionBuscar
        ' 
        cbOpcionBuscar.Cursor = Cursors.Hand
        cbOpcionBuscar.DropDownStyle = ComboBoxStyle.DropDownList
        cbOpcionBuscar.Font = New Font("Segoe UI", 12F)
        cbOpcionBuscar.FormattingEnabled = True
        cbOpcionBuscar.Items.AddRange(New Object() {"todos", "pendiente", "resuelto"})
        cbOpcionBuscar.Location = New Point(110, 12)
        cbOpcionBuscar.Name = "cbOpcionBuscar"
        cbOpcionBuscar.Size = New Size(253, 29)
        cbOpcionBuscar.TabIndex = 52
        ' 
        ' lblTotal
        ' 
        lblTotal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        lblTotal.AutoSize = True
        lblTotal.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        lblTotal.Font = New Font("Segoe UI", 12F)
        lblTotal.ForeColor = Color.White
        lblTotal.Location = New Point(835, 693)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(116, 21)
        lblTotal.TabIndex = 50
        lblTotal.Text = "Total Reclamos:"
        ' 
        ' btnActualizar
        ' 
        btnActualizar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnActualizar.Cursor = Cursors.Hand
        btnActualizar.Font = New Font("Segoe UI", 12F)
        btnActualizar.Location = New Point(127, 689)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(92, 28)
        btnActualizar.TabIndex = 47
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = True
        ' 
        ' btnCambiarEstado
        ' 
        btnCambiarEstado.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnCambiarEstado.Cursor = Cursors.Hand
        btnCambiarEstado.Font = New Font("Segoe UI", 12F)
        btnCambiarEstado.Location = New Point(351, 689)
        btnCambiarEstado.Name = "btnCambiarEstado"
        btnCambiarEstado.Size = New Size(138, 28)
        btnCambiarEstado.TabIndex = 48
        btnCambiarEstado.Text = "Cambiar Estado"
        btnCambiarEstado.UseVisualStyleBackColor = True
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
        dgvListado.TabIndex = 46
        ' 
        ' btnInsertar
        ' 
        btnInsertar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnInsertar.Cursor = Cursors.Hand
        btnInsertar.Font = New Font("Segoe UI", 12F)
        btnInsertar.Location = New Point(12, 689)
        btnInsertar.Name = "btnInsertar"
        btnInsertar.Size = New Size(92, 28)
        btnInsertar.TabIndex = 51
        btnInsertar.Text = "Insertar"
        btnInsertar.UseVisualStyleBackColor = True
        ' 
        ' btnResponder
        ' 
        btnResponder.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnResponder.Cursor = Cursors.Hand
        btnResponder.Font = New Font("Segoe UI", 12F)
        btnResponder.Location = New Point(514, 689)
        btnResponder.Name = "btnResponder"
        btnResponder.Size = New Size(96, 28)
        btnResponder.TabIndex = 49
        btnResponder.Text = "Responder"
        btnResponder.UseVisualStyleBackColor = True
        ' 
        ' panelRespuestaIngreso
        ' 
        panelRespuestaIngreso.Controls.Add(lblResponder)
        panelRespuestaIngreso.Controls.Add(tbCancelarRespuesta)
        panelRespuestaIngreso.Controls.Add(tbGuardarRespuesta)
        panelRespuestaIngreso.Controls.Add(TbRespuesta)
        panelRespuestaIngreso.Location = New Point(17, 39)
        panelRespuestaIngreso.Name = "panelRespuestaIngreso"
        panelRespuestaIngreso.Size = New Size(616, 432)
        panelRespuestaIngreso.TabIndex = 55
        panelRespuestaIngreso.Visible = False
        ' 
        ' lblResponder
        ' 
        lblResponder.AutoSize = True
        lblResponder.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblResponder.ForeColor = Color.White
        lblResponder.Location = New Point(231, 24)
        lblResponder.Name = "lblResponder"
        lblResponder.Size = New Size(85, 21)
        lblResponder.TabIndex = 57
        lblResponder.Text = "Responder"
        ' 
        ' tbCancelarRespuesta
        ' 
        tbCancelarRespuesta.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        tbCancelarRespuesta.Cursor = Cursors.Hand
        tbCancelarRespuesta.FlatAppearance.BorderColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        tbCancelarRespuesta.FlatAppearance.BorderSize = 0
        tbCancelarRespuesta.FlatAppearance.MouseDownBackColor = Color.White
        tbCancelarRespuesta.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        tbCancelarRespuesta.FlatStyle = FlatStyle.Flat
        tbCancelarRespuesta.Font = New Font("Segoe UI", 12F)
        tbCancelarRespuesta.Location = New Point(190, 380)
        tbCancelarRespuesta.Name = "tbCancelarRespuesta"
        tbCancelarRespuesta.Size = New Size(126, 29)
        tbCancelarRespuesta.TabIndex = 56
        tbCancelarRespuesta.Text = "Cancelar"
        tbCancelarRespuesta.UseVisualStyleBackColor = False
        ' 
        ' tbGuardarRespuesta
        ' 
        tbGuardarRespuesta.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        tbGuardarRespuesta.Cursor = Cursors.Hand
        tbGuardarRespuesta.FlatAppearance.BorderColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        tbGuardarRespuesta.FlatAppearance.MouseDownBackColor = Color.White
        tbGuardarRespuesta.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        tbGuardarRespuesta.FlatStyle = FlatStyle.Flat
        tbGuardarRespuesta.Font = New Font("Segoe UI", 12F)
        tbGuardarRespuesta.Location = New Point(23, 380)
        tbGuardarRespuesta.Name = "tbGuardarRespuesta"
        tbGuardarRespuesta.Size = New Size(126, 29)
        tbGuardarRespuesta.TabIndex = 55
        tbGuardarRespuesta.Text = "Guardar"
        tbGuardarRespuesta.UseVisualStyleBackColor = False
        ' 
        ' TbRespuesta
        ' 
        TbRespuesta.Font = New Font("Segoe UI", 12F)
        TbRespuesta.Location = New Point(23, 66)
        TbRespuesta.Multiline = True
        TbRespuesta.Name = "TbRespuesta"
        TbRespuesta.Size = New Size(570, 301)
        TbRespuesta.TabIndex = 54
        ' 
        ' panelDatosIngreso
        ' 
        panelDatosIngreso.Controls.Add(tbID)
        panelDatosIngreso.Controls.Add(lblDatosIngreso)
        panelDatosIngreso.Controls.Add(lblDNI)
        panelDatosIngreso.Controls.Add(tbDNI)
        panelDatosIngreso.Controls.Add(cbTipo)
        panelDatosIngreso.Controls.Add(btnCancelar)
        panelDatosIngreso.Controls.Add(btnGuardar)
        panelDatosIngreso.Controls.Add(tbDescripcion)
        panelDatosIngreso.Controls.Add(lblDescripcion)
        panelDatosIngreso.Controls.Add(lblTipo)
        panelDatosIngreso.Location = New Point(303, 191)
        panelDatosIngreso.Name = "panelDatosIngreso"
        panelDatosIngreso.Size = New Size(616, 432)
        panelDatosIngreso.TabIndex = 55
        panelDatosIngreso.Visible = False
        ' 
        ' tbID
        ' 
        tbID.AccessibleRole = AccessibleRole.SplitButton
        tbID.Location = New Point(460, 10)
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
        lblDatosIngreso.Location = New Point(244, 12)
        lblDatosIngreso.Name = "lblDatosIngreso"
        lblDatosIngreso.Size = New Size(126, 21)
        lblDatosIngreso.TabIndex = 54
        lblDatosIngreso.Text = "Agregar reclamo"
        ' 
        ' lblDNI
        ' 
        lblDNI.AutoSize = True
        lblDNI.Font = New Font("Segoe UI", 12F)
        lblDNI.ForeColor = Color.White
        lblDNI.Location = New Point(23, 267)
        lblDNI.Name = "lblDNI"
        lblDNI.Size = New Size(113, 21)
        lblDNI.TabIndex = 52
        lblDNI.Text = "DNI (opcional):"
        ' 
        ' tbDNI
        ' 
        tbDNI.Cursor = Cursors.IBeam
        tbDNI.Font = New Font("Segoe UI", 12F)
        tbDNI.Location = New Point(142, 264)
        tbDNI.Name = "tbDNI"
        tbDNI.Size = New Size(418, 29)
        tbDNI.TabIndex = 51
        ' 
        ' cbTipo
        ' 
        cbTipo.Cursor = Cursors.Hand
        cbTipo.DropDownStyle = ComboBoxStyle.DropDownList
        cbTipo.FormattingEnabled = True
        cbTipo.Items.AddRange(New Object() {"sugerencia", "reclamo"})
        cbTipo.Location = New Point(142, 42)
        cbTipo.Name = "cbTipo"
        cbTipo.Size = New Size(418, 23)
        cbTipo.TabIndex = 50
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
        btnCancelar.Location = New Point(375, 368)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(126, 29)
        btnCancelar.TabIndex = 49
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
        btnGuardar.Location = New Point(142, 368)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(126, 29)
        btnGuardar.TabIndex = 48
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = False
        ' 
        ' tbDescripcion
        ' 
        tbDescripcion.Cursor = Cursors.IBeam
        tbDescripcion.Font = New Font("Segoe UI", 12F)
        tbDescripcion.Location = New Point(142, 109)
        tbDescripcion.Multiline = True
        tbDescripcion.Name = "tbDescripcion"
        tbDescripcion.Size = New Size(418, 111)
        tbDescripcion.TabIndex = 47
        ' 
        ' lblDescripcion
        ' 
        lblDescripcion.AutoSize = True
        lblDescripcion.Font = New Font("Segoe UI", 12F)
        lblDescripcion.ForeColor = Color.White
        lblDescripcion.Location = New Point(25, 112)
        lblDescripcion.Name = "lblDescripcion"
        lblDescripcion.Size = New Size(111, 21)
        lblDescripcion.TabIndex = 45
        lblDescripcion.Text = "Descripcion(*):"
        ' 
        ' lblTipo
        ' 
        lblTipo.AutoSize = True
        lblTipo.Font = New Font("Segoe UI", 12F)
        lblTipo.ForeColor = Color.White
        lblTipo.Location = New Point(76, 40)
        lblTipo.Name = "lblTipo"
        lblTipo.Size = New Size(60, 21)
        lblTipo.TabIndex = 46
        lblTipo.Text = "Tipo(*):"
        ' 
        ' pbReiniciar
        ' 
        pbReiniciar.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        pbReiniciar.Cursor = Cursors.Hand
        pbReiniciar.Image = My.Resources.Resources.reiniciar
        pbReiniciar.Location = New Point(382, 11)
        pbReiniciar.Name = "pbReiniciar"
        pbReiniciar.Size = New Size(34, 30)
        pbReiniciar.SizeMode = PictureBoxSizeMode.Zoom
        pbReiniciar.TabIndex = 55
        pbReiniciar.TabStop = False
        ' 
        ' FrmReclamos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(1008, 729)
        Controls.Add(panelDatosIngreso)
        Controls.Add(panelRespuestaIngreso)
        Controls.Add(panelListado)
        Name = "FrmReclamos"
        Text = "FrmReclamos"
        panelListado.ResumeLayout(False)
        panelListado.PerformLayout()
        CType(dgvListado, ComponentModel.ISupportInitialize).EndInit()
        panelRespuestaIngreso.ResumeLayout(False)
        panelRespuestaIngreso.PerformLayout()
        panelDatosIngreso.ResumeLayout(False)
        panelDatosIngreso.PerformLayout()
        CType(pbReiniciar, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents panelListado As Panel
    Friend WithEvents panelDatosIngreso As Panel
    Friend WithEvents lblBuscar As Label
    Friend WithEvents btnEliminar As Button
    Friend WithEvents cbOpcionBuscar As ComboBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnActualizar As Button
    Friend WithEvents btnCambiarEstado As Button
    Friend WithEvents dgvListado As DataGridView
    Friend WithEvents btnInsertar As Button
    Friend WithEvents btnResponder As Button
    Friend WithEvents lblDNI As Label
    Friend WithEvents tbDNI As TextBox
    Friend WithEvents cbTipo As ComboBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents tbDescripcion As TextBox
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents lblTipo As Label
    Friend WithEvents lblDatosIngreso As Label
    Friend WithEvents panelRespuestaIngreso As Panel
    Friend WithEvents lblResponder As Label
    Friend WithEvents tbCancelarRespuesta As Button
    Friend WithEvents tbGuardarRespuesta As Button
    Friend WithEvents TbRespuesta As TextBox
    Friend WithEvents tbID As TextBox
    Friend WithEvents pbReiniciar As PictureBox
End Class
