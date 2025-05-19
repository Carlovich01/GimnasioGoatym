<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        pbLogo = New PictureBox()
        tbUsuario = New TextBox()
        tbContraseña = New TextBox()
        lblUsuario = New Label()
        lblContraseña = New Label()
        btnIniciarSesion = New Button()
        pbMostrarContraseña = New PictureBox()
        CType(pbLogo, ComponentModel.ISupportInitialize).BeginInit()
        CType(pbMostrarContraseña, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pbLogo
        ' 
        pbLogo.Image = CType(resources.GetObject("pbLogo.Image"), Image)
        pbLogo.Location = New Point(193, 12)
        pbLogo.Name = "pbLogo"
        pbLogo.Size = New Size(302, 253)
        pbLogo.SizeMode = PictureBoxSizeMode.Zoom
        pbLogo.TabIndex = 1
        pbLogo.TabStop = False
        ' 
        ' tbUsuario
        ' 
        tbUsuario.Font = New Font("Segoe UI", 16F)
        tbUsuario.Location = New Point(154, 291)
        tbUsuario.Name = "tbUsuario"
        tbUsuario.Size = New Size(438, 36)
        tbUsuario.TabIndex = 1
        tbUsuario.Text = "admin"
        ' 
        ' tbContraseña
        ' 
        tbContraseña.Font = New Font("Segoe UI", 16F)
        tbContraseña.Location = New Point(154, 362)
        tbContraseña.Name = "tbContraseña"
        tbContraseña.Size = New Size(438, 36)
        tbContraseña.TabIndex = 2
        tbContraseña.Text = "1234"
        tbContraseña.UseSystemPasswordChar = True
        ' 
        ' lblUsuario
        ' 
        lblUsuario.AutoSize = True
        lblUsuario.Font = New Font("Segoe UI", 16F)
        lblUsuario.ForeColor = Color.White
        lblUsuario.Location = New Point(48, 291)
        lblUsuario.Name = "lblUsuario"
        lblUsuario.Size = New Size(91, 30)
        lblUsuario.TabIndex = 3
        lblUsuario.Text = "Usuario:"
        ' 
        ' lblContraseña
        ' 
        lblContraseña.AutoSize = True
        lblContraseña.Font = New Font("Segoe UI", 16F)
        lblContraseña.ForeColor = Color.White
        lblContraseña.Location = New Point(12, 365)
        lblContraseña.Name = "lblContraseña"
        lblContraseña.Size = New Size(127, 30)
        lblContraseña.TabIndex = 3
        lblContraseña.Text = "Contraseña:"
        ' 
        ' btnIniciarSesion
        ' 
        btnIniciarSesion.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnIniciarSesion.Cursor = Cursors.Hand
        btnIniciarSesion.FlatStyle = FlatStyle.Flat
        btnIniciarSesion.Font = New Font("Segoe UI", 16F)
        btnIniciarSesion.Location = New Point(260, 432)
        btnIniciarSesion.Name = "btnIniciarSesion"
        btnIniciarSesion.Size = New Size(159, 43)
        btnIniciarSesion.TabIndex = 4
        btnIniciarSesion.Text = "Iniciar Sesión"
        btnIniciarSesion.UseVisualStyleBackColor = False
        ' 
        ' pbMostrarContraseña
        ' 
        pbMostrarContraseña.Cursor = Cursors.Hand
        pbMostrarContraseña.Image = My.Resources.Resources.ojo_cerrado
        pbMostrarContraseña.Location = New Point(618, 362)
        pbMostrarContraseña.Name = "pbMostrarContraseña"
        pbMostrarContraseña.Size = New Size(52, 50)
        pbMostrarContraseña.SizeMode = PictureBoxSizeMode.Zoom
        pbMostrarContraseña.TabIndex = 5
        pbMostrarContraseña.TabStop = False
        ' 
        ' FrmLogin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(682, 503)
        Controls.Add(btnIniciarSesion)
        Controls.Add(lblContraseña)
        Controls.Add(lblUsuario)
        Controls.Add(tbContraseña)
        Controls.Add(tbUsuario)
        Controls.Add(pbLogo)
        Controls.Add(pbMostrarContraseña)
        Name = "FrmLogin"
        Text = "Inicio de Sesión"
        CType(pbLogo, ComponentModel.ISupportInitialize).EndInit()
        CType(pbMostrarContraseña, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pbLogo As PictureBox
    Friend WithEvents tbUsuario As TextBox
    Friend WithEvents tbContraseña As TextBox
    Friend WithEvents lblUsuario As Label
    Friend WithEvents lblContraseña As Label
    Friend WithEvents btnIniciarSesion As Button
    Friend WithEvents pbMostrarContraseña As PictureBox
End Class
