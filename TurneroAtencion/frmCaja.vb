Imports System.ComponentModel

Public Class frmCaja
    Private Sub txtCaja_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCaja.KeyPress

        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If txtCaja.Text.Length = 3 Then
            My.Settings.caja = txtCaja.Text
            My.Settings.Save()
            Turnero.Text = $"Turnerno: Caja {My.Settings.caja}"
            Turnero.cmbMotivos.Enabled = True
            btnCancelar.PerformClick()
        Else

            MsgBox("Nombre de caja debe ser de 3 digitos", MsgBoxStyle.Exclamation)

        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Turnero.Show()
        Turnero.Enabled = True
        Me.Close()

    End Sub

    Private Sub frmCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Turnero.Hide()
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Focus()
        Me.BringToFront()
        Me.TopMost = True

    End Sub

    Private Sub frmCaja_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        Turnero.Show()
        Turnero.Enabled = True

    End Sub

    Private Sub txtCaja_TextChanged(sender As Object, e As EventArgs) Handles txtCaja.TextChanged

        If txtCaja.TextLength = 3 Then

            btnAceptar.Enabled = True

        Else

            btnAceptar.Enabled = False
        End If

    End Sub
End Class