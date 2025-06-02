<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPrincipal
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
        ToolStripPestañas.Size = New Size(1008, 32)
        ToolStripPestañas.TabIndex = 0
        ToolStripPestañas.Text = "ToolStrip1"
        ' 
        ' btnPlanes
        ' 
        btnPlanes.Font = New Font("Segoe UI", 13F)
        btnPlanes.Image = My.Resources.Resources.iconoPlanes
        btnPlanes.ImageTransparentColor = Color.Magenta
        btnPlanes.Name = "btnPlanes"
        btnPlanes.Size = New Size(82, 29)
        btnPlanes.Text = "Planes"
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(6, 32)
        ' 
        ' btnMiembros
        ' 
        btnMiembros.Font = New Font("Segoe UI", 13F)
        btnMiembros.Image = My.Resources.Resources.iconoMiembro
        btnMiembros.ImageTransparentColor = Color.Magenta
        btnMiembros.Name = "btnMiembros"
        btnMiembros.Size = New Size(113, 29)
        btnMiembros.Text = "Miembros"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 32)
        ' 
        ' btnMembresias
        ' 
        btnMembresias.Font = New Font("Segoe UI", 13F)
        btnMembresias.Image = My.Resources.Resources.iconoMembresia
        btnMembresias.ImageTransparentColor = Color.Magenta
        btnMembresias.Name = "btnMembresias"
        btnMembresias.Size = New Size(128, 29)
        btnMembresias.Text = "Membresías"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(6, 32)
        ' 
        ' btnPagos
        ' 
        btnPagos.Font = New Font("Segoe UI", 13F)
        btnPagos.Image = My.Resources.Resources.iconoPago
        btnPagos.ImageTransparentColor = Color.Magenta
        btnPagos.Name = "btnPagos"
        btnPagos.Size = New Size(80, 29)
        btnPagos.Text = "Pagos"
        ' 
        ' ToolStripSeparator4
        ' 
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New Size(6, 32)
        ' 
        ' btRegistroAsistencias
        ' 
        btRegistroAsistencias.Font = New Font("Segoe UI", 13F)
        btRegistroAsistencias.Image = My.Resources.Resources.logoAsistencia
        btRegistroAsistencias.ImageTransparentColor = Color.Magenta
        btRegistroAsistencias.Name = "btRegistroAsistencias"
        btRegistroAsistencias.Size = New Size(118, 29)
        btRegistroAsistencias.Text = "Asistencias"
        ' 
        ' ToolStripSeparator6
        ' 
        ToolStripSeparator6.Name = "ToolStripSeparator6"
        ToolStripSeparator6.Size = New Size(6, 32)
        ' 
        ' btnReclamos
        ' 
        btnReclamos.Font = New Font("Segoe UI", 13F)
        btnReclamos.Image = My.Resources.Resources.logoReclamos
        btnReclamos.ImageTransparentColor = Color.Magenta
        btnReclamos.Name = "btnReclamos"
        btnReclamos.Size = New Size(107, 29)
        btnReclamos.Text = "Reclamos"
        ' 
        ' ToolStripSeparator8
        ' 
        ToolStripSeparator8.Name = "ToolStripSeparator8"
        ToolStripSeparator8.Size = New Size(6, 32)
        ' 
        ' btnUsuarios
        ' 
        btnUsuarios.Font = New Font("Segoe UI", 13F)
        btnUsuarios.Image = My.Resources.Resources.logoUsuariosSistema
        btnUsuarios.ImageTransparentColor = Color.Magenta
        btnUsuarios.Name = "btnUsuarios"
        btnUsuarios.Size = New Size(100, 29)
        btnUsuarios.Text = "Usuarios"
        ' 
        ' ToolStripSeparator5
        ' 
        ToolStripSeparator5.Name = "ToolStripSeparator5"
        ToolStripSeparator5.Size = New Size(6, 32)
        ' 
        ' btnUsuarioLogueado
        ' 
        btnUsuarioLogueado.DropDownItems.AddRange(New ToolStripItem() {miCerrarSesión})
        btnUsuarioLogueado.Font = New Font("Segoe UI", 13F)
        btnUsuarioLogueado.Image = My.Resources.Resources.usuario_logo2
        btnUsuarioLogueado.ImageTransparentColor = Color.Magenta
        btnUsuarioLogueado.Name = "btnUsuarioLogueado"
        btnUsuarioLogueado.Size = New Size(101, 29)
        btnUsuarioLogueado.Text = "Usuario"
        ' 
        ' miCerrarSesión
        ' 
        miCerrarSesión.Name = "miCerrarSesión"
        miCerrarSesión.Size = New Size(188, 30)
        miCerrarSesión.Text = "Cerrar Sesión"
        ' 
        ' ToolStripSeparator7
        ' 
        ToolStripSeparator7.Name = "ToolStripSeparator7"
        ToolStripSeparator7.Size = New Size(6, 32)
        ' 
        ' PanelDeFormularios
        ' 
        PanelDeFormularios.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        PanelDeFormularios.Controls.Add(pbLogo)
        PanelDeFormularios.Dock = DockStyle.Fill
        PanelDeFormularios.Location = New Point(0, 32)
        PanelDeFormularios.Name = "PanelDeFormularios"
        PanelDeFormularios.Size = New Size(1008, 697)
        PanelDeFormularios.TabIndex = 1
        ' 
        ' pbLogo
        ' 
        pbLogo.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pbLogo.Image = CType(resources.GetObject("pbLogo.Image"), Image)
        pbLogo.Location = New Point(140, 109)
        pbLogo.Name = "pbLogo"
        pbLogo.Size = New Size(755, 468)
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
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
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
