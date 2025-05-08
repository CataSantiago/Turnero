<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Turnero
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Turnero))
        btnSiguiente = New Button()
        btnAnterior = New Button()
        txtTurno = New RichTextBox()
        TextBox1 = New TextBox()
        cmbMotivos = New ComboBox()
        grpBotones = New GroupBox()
        GroupBox1 = New GroupBox()
        btnFinalizar = New Button()
        btnCaja = New Button()
        SSM = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(WaitForm1), True, True)
        grpBotones.SuspendLayout()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnSiguiente
        ' 
        btnSiguiente.Enabled = False
        btnSiguiente.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnSiguiente.Location = New Point(58, 22)
        btnSiguiente.Name = "btnSiguiente"
        btnSiguiente.Size = New Size(340, 164)
        btnSiguiente.TabIndex = 0
        btnSiguiente.Text = "Siguiente Turno"
        btnSiguiente.UseVisualStyleBackColor = True
        ' 
        ' btnAnterior
        ' 
        btnAnterior.Enabled = False
        btnAnterior.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnAnterior.Location = New Point(17, 22)
        btnAnterior.Name = "btnAnterior"
        btnAnterior.Size = New Size(102, 164)
        btnAnterior.TabIndex = 1
        btnAnterior.Text = "Regresar Turno"
        btnAnterior.UseVisualStyleBackColor = True
        btnAnterior.Visible = False
        ' 
        ' txtTurno
        ' 
        txtTurno.BorderStyle = BorderStyle.None
        txtTurno.Enabled = False
        txtTurno.Font = New Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point)
        txtTurno.Location = New Point(12, 12)
        txtTurno.Name = "txtTurno"
        txtTurno.Size = New Size(338, 91)
        txtTurno.TabIndex = 2
        txtTurno.Text = "Turno: A la espera"
        ' 
        ' TextBox1
        ' 
        TextBox1.BorderStyle = BorderStyle.None
        TextBox1.Enabled = False
        TextBox1.Location = New Point(13, 13)
        TextBox1.Name = "TextBox1"
        TextBox1.ReadOnly = True
        TextBox1.Size = New Size(121, 16)
        TextBox1.TabIndex = 3
        TextBox1.Text = "Motivo"
        ' 
        ' cmbMotivos
        ' 
        cmbMotivos.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMotivos.Enabled = False
        cmbMotivos.FormattingEnabled = True
        cmbMotivos.Location = New Point(13, 35)
        cmbMotivos.Name = "cmbMotivos"
        cmbMotivos.Size = New Size(121, 23)
        cmbMotivos.TabIndex = 4
        ' 
        ' grpBotones
        ' 
        grpBotones.Controls.Add(btnAnterior)
        grpBotones.Controls.Add(btnSiguiente)
        grpBotones.Location = New Point(12, 111)
        grpBotones.Name = "grpBotones"
        grpBotones.Size = New Size(488, 203)
        grpBotones.TabIndex = 5
        grpBotones.TabStop = False
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(cmbMotivos)
        GroupBox1.Controls.Add(TextBox1)
        GroupBox1.Location = New Point(356, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(144, 77)
        GroupBox1.TabIndex = 7
        GroupBox1.TabStop = False
        ' 
        ' btnFinalizar
        ' 
        btnFinalizar.Enabled = False
        btnFinalizar.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnFinalizar.Location = New Point(416, 320)
        btnFinalizar.Name = "btnFinalizar"
        btnFinalizar.Size = New Size(84, 37)
        btnFinalizar.TabIndex = 8
        btnFinalizar.Text = "Finalizar"
        btnFinalizar.UseVisualStyleBackColor = True
        ' 
        ' btnCaja
        ' 
        btnCaja.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnCaja.Location = New Point(12, 320)
        btnCaja.Name = "btnCaja"
        btnCaja.Size = New Size(119, 37)
        btnCaja.TabIndex = 9
        btnCaja.Text = "Cambiar Caja"
        btnCaja.UseVisualStyleBackColor = True
        ' 
        ' SSM
        ' 
        SSM.ClosingDelay = 500
        ' 
        ' Turnero
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(526, 374)
        Controls.Add(btnCaja)
        Controls.Add(btnFinalizar)
        Controls.Add(GroupBox1)
        Controls.Add(grpBotones)
        Controls.Add(txtTurno)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MaximumSize = New Size(542, 413)
        MinimumSize = New Size(542, 413)
        Name = "Turnero"
        Text = "Turnero"
        grpBotones.ResumeLayout(False)
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnSiguiente As Button
    Friend WithEvents btnAnterior As Button
    Friend WithEvents txtTurno As RichTextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents cmbMotivos As ComboBox
    Friend WithEvents grpBotones As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnFinalizar As Button
    Friend WithEvents btnCaja As Button
    Friend WithEvents SSM As DevExpress.XtraSplashScreen.SplashScreenManager

End Class
