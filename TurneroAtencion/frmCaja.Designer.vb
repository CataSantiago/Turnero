<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCaja))
        txtCaja = New TextBox()
        btnCancelar = New Button()
        btnAceptar = New Button()
        lblConsigna = New Label()
        SuspendLayout()
        ' 
        ' txtCaja
        ' 
        txtCaja.Location = New Point(118, 12)
        txtCaja.MaxLength = 3
        txtCaja.Name = "txtCaja"
        txtCaja.Size = New Size(100, 23)
        txtCaja.TabIndex = 1
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Location = New Point(143, 63)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(75, 23)
        btnCancelar.TabIndex = 3
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' btnAceptar
        ' 
        btnAceptar.Enabled = False
        btnAceptar.Location = New Point(64, 63)
        btnAceptar.Name = "btnAceptar"
        btnAceptar.RightToLeft = RightToLeft.Yes
        btnAceptar.Size = New Size(75, 23)
        btnAceptar.TabIndex = 4
        btnAceptar.Text = "Aceptar"
        btnAceptar.UseVisualStyleBackColor = True
        ' 
        ' lblConsigna
        ' 
        lblConsigna.AutoSize = True
        lblConsigna.Enabled = False
        lblConsigna.Location = New Point(13, 15)
        lblConsigna.Name = "lblConsigna"
        lblConsigna.Size = New Size(99, 15)
        lblConsigna.TabIndex = 5
        lblConsigna.Tag = ""
        lblConsigna.Text = "Numero de Caja: "
        ' 
        ' frmCaja
        ' 
        AcceptButton = btnAceptar
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnCancelar
        ClientSize = New Size(243, 92)
        Controls.Add(lblConsigna)
        Controls.Add(btnAceptar)
        Controls.Add(btnCancelar)
        Controls.Add(txtCaja)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MaximumSize = New Size(259, 131)
        MinimumSize = New Size(259, 131)
        Name = "frmCaja"
        Text = "Ingrese Numero de Caja"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtCaja As TextBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents lblConsigna As Label
End Class
