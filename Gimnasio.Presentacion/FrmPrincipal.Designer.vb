<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrincipal))
        ToolStripPestañas = New ToolStrip()
        btnPlanes = New ToolStripButton()
        ToolStripSeparator3 = New ToolStripSeparator()
        btnMiembros = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        btnMembresias = New ToolStripButton()
        ToolStripSeparator2 = New ToolStripSeparator()
        btnPagos = New ToolStripButton()
        ToolStripSeparator4 = New ToolStripSeparator()
        btRegistroAsistencias = New ToolStripButton()
        ToolStripSeparator6 = New ToolStripSeparator()
        btnReclamos = New ToolStripButton()
        ToolStripSeparator8 = New ToolStripSeparator()
        btnUsuarios = New ToolStripButton()
        ToolStripSeparator5 = New ToolStripSeparator()
        btnUsuarioLogueado = New ToolStripDropDownButton()
        miCerrarSesión = New ToolStripMenuItem()
        ToolStripSeparator7 = New ToolStripSeparator()
        PanelDeFormularios = New Panel()
        pbLogo = New PictureBox()
        ToolStripPestañas.SuspendLayout()
        PanelDeFormularios.SuspendLayout()
        CType(pbLogo, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ToolStripPestañas
        ' 
        ToolStripPestañas.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        ToolStripPestañas.Items.AddRange(New ToolStripItem() {btnPlanes, ToolStripSeparator3, btnMiembros, ToolStripSeparator1, btnMembresias, ToolStripSeparator2, btnPagos, ToolStripSeparator4, btRegistroAsistencias, ToolStripSeparator6, btnReclamos, ToolStripSeparator8, btnUsuarios, ToolStripSeparator5, btnUsuarioLogueado, ToolStripSeparator7})
        ToolStripPestañas.Location = New Point(0, 0)
        ToolStripPestañas.Name = "ToolStripPestañas"
        ToolStripPestañas.Size = New Size(1008, 28)
        ToolStripPestañas.TabIndex = 0
        ToolStripPestañas.Text = "ToolStrip1"
        ' 
        ' btnPlanes
        ' 
        btnPlanes.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnPlanes.Font = New Font("Segoe UI", 12F)
        btnPlanes.Image = CType(resources.GetObject("btnPlanes.Image"), Image)
        btnPlanes.ImageTransparentColor = Color.Magenta
        btnPlanes.Name = "btnPlanes"
        btnPlanes.Size = New Size(59, 25)
        btnPlanes.Text = "Planes"
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(6, 28)
        ' 
        ' btnMiembros
        ' 
        btnMiembros.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnMiembros.Font = New Font("Segoe UI", 12F)
        btnMiembros.Image = CType(resources.GetObject("btnMiembros.Image"), Image)
        btnMiembros.ImageTransparentColor = Color.Magenta
        btnMiembros.Name = "btnMiembros"
        btnMiembros.Size = New Size(85, 25)
        btnMiembros.Text = "Miembros"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 28)
        ' 
        ' btnMembresias
        ' 
        btnMembresias.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnMembresias.Font = New Font("Segoe UI", 12F)
        btnMembresias.Image = CType(resources.GetObject("btnMembresias.Image"), Image)
        btnMembresias.ImageTransparentColor = Color.Magenta
        btnMembresias.Name = "btnMembresias"
        btnMembresias.Size = New Size(99, 25)
        btnMembresias.Text = "Membresías"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(6, 28)
        ' 
        ' btnPagos
        ' 
        btnPagos.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnPagos.Font = New Font("Segoe UI", 12F)
        btnPagos.Image = CType(resources.GetObject("btnPagos.Image"), Image)
        btnPagos.ImageTransparentColor = Color.Magenta
        btnPagos.Name = "btnPagos"
        btnPagos.Size = New Size(55, 25)
        btnPagos.Text = "Pagos"
        ' 
        ' ToolStripSeparator4
        ' 
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New Size(6, 28)
        ' 
        ' btRegistroAsistencias
        ' 
        btRegistroAsistencias.DisplayStyle = ToolStripItemDisplayStyle.Text
        btRegistroAsistencias.Font = New Font("Segoe UI", 12F)
        btRegistroAsistencias.Image = CType(resources.GetObject("btRegistroAsistencias.Image"), Image)
        btRegistroAsistencias.ImageTransparentColor = Color.Magenta
        btRegistroAsistencias.Name = "btRegistroAsistencias"
        btRegistroAsistencias.Size = New Size(152, 25)
        btRegistroAsistencias.Text = "Registro Asistencias"
        ' 
        ' ToolStripSeparator6
        ' 
        ToolStripSeparator6.Name = "ToolStripSeparator6"
        ToolStripSeparator6.Size = New Size(6, 28)
        ' 
        ' btnReclamos
        ' 
        btnReclamos.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnReclamos.Font = New Font("Segoe UI", 12F)
        btnReclamos.Image = CType(resources.GetObject("btnReclamos.Image"), Image)
        btnReclamos.ImageTransparentColor = Color.Magenta
        btnReclamos.Name = "btnReclamos"
        btnReclamos.Size = New Size(81, 25)
        btnReclamos.Text = "Reclamos"
        ' 
        ' ToolStripSeparator8
        ' 
        ToolStripSeparator8.Name = "ToolStripSeparator8"
        ToolStripSeparator8.Size = New Size(6, 28)
        ' 
        ' btnUsuarios
        ' 
        btnUsuarios.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnUsuarios.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnUsuarios.Image = CType(resources.GetObject("btnUsuarios.Image"), Image)
        btnUsuarios.ImageTransparentColor = Color.Magenta
        btnUsuarios.Name = "btnUsuarios"
        btnUsuarios.Size = New Size(75, 25)
        btnUsuarios.Text = "Usuarios"
        ' 
        ' ToolStripSeparator5
        ' 
        ToolStripSeparator5.Name = "ToolStripSeparator5"
        ToolStripSeparator5.Size = New Size(6, 28)
        ' 
        ' btnUsuarioLogueado
        ' 
        btnUsuarioLogueado.DropDownItems.AddRange(New ToolStripItem() {miCerrarSesión})
        btnUsuarioLogueado.Font = New Font("Segoe UI", 12F)
        btnUsuarioLogueado.Image = CType(resources.GetObject("btnUsuarioLogueado.Image"), Image)
        btnUsuarioLogueado.ImageTransparentColor = Color.Magenta
        btnUsuarioLogueado.Name = "btnUsuarioLogueado"
        btnUsuarioLogueado.Size = New Size(93, 25)
        btnUsuarioLogueado.Text = "Usuario"
        ' 
        ' miCerrarSesión
        ' 
        miCerrarSesión.Name = "miCerrarSesión"
        miCerrarSesión.Size = New Size(174, 26)
        miCerrarSesión.Text = "Cerrar Sesión"
        ' 
        ' ToolStripSeparator7
        ' 
        ToolStripSeparator7.Name = "ToolStripSeparator7"
        ToolStripSeparator7.Size = New Size(6, 28)
        ' 
        ' PanelDeFormularios
        ' 
        PanelDeFormularios.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        PanelDeFormularios.Controls.Add(pbLogo)
        PanelDeFormularios.Dock = DockStyle.Fill
        PanelDeFormularios.Location = New Point(0, 28)
        PanelDeFormularios.Name = "PanelDeFormularios"
        PanelDeFormularios.Size = New Size(1008, 701)
        PanelDeFormularios.TabIndex = 1
        ' 
        ' pbLogo
        ' 
        pbLogo.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pbLogo.Image = CType(resources.GetObject("pbLogo.Image"), Image)
        pbLogo.Location = New Point(140, 109)
        pbLogo.Name = "pbLogo"
        pbLogo.Size = New Size(755, 472)
        pbLogo.SizeMode = PictureBoxSizeMode.Zoom
        pbLogo.TabIndex = 0
        pbLogo.TabStop = False
        ' 
        ' FrmPrincipal
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        ClientSize = New Size(1008, 729)
        Controls.Add(PanelDeFormularios)
        Controls.Add(ToolStripPestañas)
        Name = "FrmPrincipal"
        Text = "Goatym"
        WindowState = FormWindowState.Maximized
        ToolStripPestañas.ResumeLayout(False)
        ToolStripPestañas.PerformLayout()
        PanelDeFormularios.ResumeLayout(False)
        CType(pbLogo, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ToolStripPestañas As ToolStrip
    Friend WithEvents PanelDeFormularios As Panel
    Friend WithEvents pbLogo As PictureBox
    Friend WithEvents btnPlanes As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnMembresias As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btnMiembros As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnPagos As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents btnReclamos As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents btRegistroAsistencias As ToolStripButton
    Friend WithEvents btnUsuarios As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnUsuarioLogueado As ToolStripDropDownButton
    Friend WithEvents miCerrarSesión As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
End Class
