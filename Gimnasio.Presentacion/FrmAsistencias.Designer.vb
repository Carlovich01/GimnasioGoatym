﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAsistencias))
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
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Window
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvListado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvListado.DefaultCellStyle = DataGridViewCellStyle2
        dgvListado.GridColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        dgvListado.Location = New Point(37, 265)
        dgvListado.MultiSelect = False
        dgvListado.Name = "dgvListado"
        dgvListado.ReadOnly = True
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Window
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        dgvListado.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
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
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "FrmAsistencias"
        Text = "Asistencia"
        CType(dgvListado, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents tbDNI As TextBox
    Friend WithEvents lblParaIngresarDNI As Label
    Friend WithEvents labelResultado As Label
    Friend WithEvents dgvListado As DataGridView
End Class
