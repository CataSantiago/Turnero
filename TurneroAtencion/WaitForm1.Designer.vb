<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WaitForm1
    Inherits DevExpress.XtraWaitForm.WaitForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        progressPanel1 = New DevExpress.XtraWaitForm.ProgressPanel()
        tableLayoutPanel1 = New TableLayoutPanel()
        tableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' progressPanel1
        ' 
        progressPanel1.Appearance.BackColor = Color.Transparent
        progressPanel1.Appearance.Options.UseBackColor = True
        progressPanel1.AppearanceCaption.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point)
        progressPanel1.AppearanceCaption.Options.UseFont = True
        progressPanel1.AppearanceDescription.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        progressPanel1.AppearanceDescription.Options.UseFont = True
        progressPanel1.Caption = "Espere por favor"
        progressPanel1.Description = "Cargando Turnos  ..."
        progressPanel1.Dock = DockStyle.Fill
        progressPanel1.ImageHorzOffset = 20
        progressPanel1.Location = New Point(0, 17)
        progressPanel1.Margin = New Padding(0, 3, 0, 3)
        progressPanel1.Name = "progressPanel1"
        progressPanel1.Size = New Size(246, 39)
        progressPanel1.TabIndex = 0
        progressPanel1.Text = "progressPanel1"
        ' 
        ' tableLayoutPanel1
        ' 
        tableLayoutPanel1.AutoSize = True
        tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        tableLayoutPanel1.BackColor = Color.Transparent
        tableLayoutPanel1.ColumnCount = 1
        tableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        tableLayoutPanel1.Controls.Add(progressPanel1, 0, 0)
        tableLayoutPanel1.Dock = DockStyle.Fill
        tableLayoutPanel1.Location = New Point(0, 0)
        tableLayoutPanel1.Name = "tableLayoutPanel1"
        tableLayoutPanel1.Padding = New Padding(0, 14, 0, 14)
        tableLayoutPanel1.RowCount = 1
        tableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tableLayoutPanel1.Size = New Size(246, 73)
        tableLayoutPanel1.TabIndex = 1
        ' 
        ' WaitForm1
        ' 
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        ClientSize = New Size(246, 73)
        Controls.Add(tableLayoutPanel1)
        DoubleBuffered = True
        Name = "WaitForm1"
        StartPosition = FormStartPosition.Manual
        Text = "Form1"
        tableLayoutPanel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Private WithEvents progressPanel1 As DevExpress.XtraWaitForm.ProgressPanel
    Private WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
End Class
