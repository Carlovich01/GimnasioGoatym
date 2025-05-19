<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAsistencias
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
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        tbDNI = New TextBox()
        lblParaIngresarDNI = New Label()
        labelResultado = New Label()
        dgvListado = New DataGridView()
        CType(dgvListado, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' tbDNI
        ' 
        tbDNI.Font = New Font("Segoe UI", 16F)
        tbDNI.Location = New Point(37, 96)
        tbDNI.Name = "tbDNI"
        tbDNI.Size = New Size(433, 36)
        tbDNI.TabIndex = 1
        ' 
        ' lblParaIngresarDNI
        ' 
        lblParaIngresarDNI.AutoSize = True
        lblParaIngresarDNI.Font = New Font("Segoe UI", 16F)
        lblParaIngresarDNI.ForeColor = Color.White
        lblParaIngresarDNI.Location = New Point(37, 23)
        lblParaIngresarDNI.Name = "lblParaIngresarDNI"
        lblParaIngresarDNI.Size = New Size(364, 30)
        lblParaIngresarDNI.TabIndex = 2
        lblParaIngresarDNI.Text = "INGRESE SU DNI Y PRESIONE ENTER"
        ' 
        ' labelResultado
        ' 
        labelResultado.AutoSize = True
        labelResultado.Font = New Font("Segoe UI", 16F)
        labelResultado.ForeColor = Color.White
        labelResultado.Location = New Point(37, 171)
        labelResultado.Name = "labelResultado"
        labelResultado.Size = New Size(107, 30)
        labelResultado.TabIndex = 3
        labelResultado.Text = "Resultado"
        ' 
        ' dgvListado
        ' 
        dgvListado.AllowUserToAddRows = False
        dgvListado.AllowUserToDeleteRows = False
        dgvListado.AllowUserToOrderColumns = True
        dgvListado.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvListado.BackgroundColor = Color.FromArgb(CByte(85), CByte(96), CByte(105))
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = SystemColors.Window
        DataGridViewCellStyle4.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle4.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True
        dgvListado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        dgvListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = SystemColors.Window
        DataGridViewCellStyle5.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle5.ForeColor = Color.White
        DataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.False
        dgvListado.DefaultCellStyle = DataGridViewCellStyle5
        dgvListado.GridColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        dgvListado.Location = New Point(37, 265)
        dgvListado.MultiSelect = False
        dgvListado.Name = "dgvListado"
        dgvListado.ReadOnly = True
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = SystemColors.Window
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle6.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.True
        dgvListado.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvListado.Size = New Size(872, 340)
        dgvListado.TabIndex = 25
        ' 
        ' FrmAsistencias
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(950, 631)
        Controls.Add(dgvListado)
        Controls.Add(labelResultado)
        Controls.Add(lblParaIngresarDNI)
        Controls.Add(tbDNI)
        ForeColor = Color.White
        Name = "FrmAsistencias"
        Text = "FrmAsistencias"
        CType(dgvListado, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents tbDNI As TextBox
    Friend WithEvents lblParaIngresarDNI As Label
    Friend WithEvents labelResultado As Label
    Friend WithEvents dgvListado As DataGridView
End Class
