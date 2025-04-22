Imports System.ComponentModel
Imports System.IO
Imports System.Media
Imports System.Net
Imports System.Net.Http
Imports System.Runtime.Intrinsics.X86
Imports System.Text
Imports System.Text.Json
Imports DevExpress.CodeParser
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Turnero

    Dim connectionString = "http://api.totemapp.com:5000"
    Dim httpClient As New HttpClient()
    Dim responceTurnos
    Dim caja As String
    Dim turno

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.StartPosition = FormStartPosition.CenterScreen

        'Cargar colas segun motivo

        'Se bloquean los botones hasta elegir motivo

        cmbMotivos.Items.Add("Ventas")
        cmbMotivos.Items.Add("Cobranzas")

        If My.Settings.caja Is "" Then

            frmCaja.Show()
            frmCaja.Focus()

            Me.Enabled = False

        Else

            Me.cmbMotivos.Enabled = True

        End If

        If My.Settings.Motivo IsNot "" Then

            cmbMotivos.Text = My.Settings.Motivo
            btnAnterior.Enabled = True
            btnSiguiente.Enabled = True

        End If

        Me.Text = $"Turnerno: Caja {My.Settings.caja}"

        'CambiarHost()

    End Sub



    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click

        'Tomar siguiente turno, quitarlo de la cola
        Dim urlSiguienteTurno = $"{connectionString}/caja/siguiente/{cmbMotivos.Text.ToLower}/{My.Settings.caja}"

        Try
            AbrirEspera()
            turno = MakeRequestPOST(urlSiguienteTurno)
            CerrarEspera()

            If turno <> "The remote server returned an error: (404) NOT FOUND." Then

                Dim json As JsonDocument = JsonDocument.Parse(turno)
                Dim rootElement = json.RootElement
                txtTurno.Text = $"Turno: {rootElement.GetProperty("codigo").ToString}"

                btnFinalizar.Enabled = True
                btnSiguiente.Enabled = False

            Else

                MsgBox("No hay turnos para atender.", MsgBoxStyle.Exclamation, "Sin turnos")

            End If


        Catch ex As Exception

            If ex.Message.Contains("'S'") Then

                MsgBox("La Aplicacion de Pantalla no se esta ejecutando.", MsgBoxStyle.Critical, "Turnero")

            ElseIf ex.Message.Contains("'T'") Then

                MsgBox("No hay turnos anteriores para atender.", MsgBoxStyle.Exclamation, "Sin turnos")
                turno = Nothing
                btnFinalizar.Enabled = False

            Else

                MsgBox(ex.Message, MsgBoxStyle.Critical, "Turnero")

            End If

        End Try


    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click

        'Devolver el turno tomado a la cola
        Dim urlAnteriorTurno = $"{connectionString}/caja/anterior/{cmbMotivos.Text.ToLower}/{My.Settings.caja}"

        Try
            AbrirEspera()
            turno = MakeRequestPOST(urlAnteriorTurno)
            CerrarEspera()

            If turno <> "The remote server returned an error: (404) NOT FOUND." Then
                Dim json As JsonDocument = JsonDocument.Parse(turno)
                Dim rootElement = json.RootElement

                txtTurno.Text = $"Turno: {rootElement.GetProperty("codigo").ToString}"
                'SystemSounds.Beep.Play()
                btnFinalizar.Enabled = True
                btnAnterior.Enabled = False
            Else

                MsgBox("No hay turnos para atender.", MsgBoxStyle.Exclamation, "Sin turnos")

            End If
        Catch ex As Exception

            If ex.Message.Contains("'S'") Then

                MsgBox("La Aplicacion de Pantalla no se esta ejecutando.", MsgBoxStyle.Critical, "Turnero")

            ElseIf ex.Message.Contains("'T'") Then

                MsgBox("No hay turnos anteriores para atender.", MsgBoxStyle.Exclamation, "Sin turnos")
                turno = Nothing
                btnFinalizar.Enabled = False

            Else

                MsgBox(ex.Message, MsgBoxStyle.Critical, "Turnero")

            End If

        End Try

    End Sub

    Private Sub CargarTurnos()

        'MsgBox("Cargando Turnos", MsgBoxStyle.Information, "Turnero")
        AbrirEspera()
        Dim urlTurnos = $"{connectionString}/turnos"
        responceTurnos = MakeRequestGET(urlTurnos)
        CerrarEspera()
        'MsgBox("")

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMotivos.SelectedIndexChanged



        My.Settings.Motivo = cmbMotivos.Text
        My.Settings.Save()

        'Carga cola correspondiente al motivo seleccionado
        'If cmbMotivos.Text Is "Venta" Then
        CargarTurnos()
        '    RichTextBox1.Text = "Turno: "

        'End If
        'Desbloquea botones
        btnAnterior.Enabled = True
        btnSiguiente.Enabled = True
        'btnCrearTurno.Enabled = True


    End Sub

    Function MakeRequestGET(url As String) As String

        Dim responseData As String
        Try
            Dim request = DirectCast(WebRequest.Create(url), HttpWebRequest)
            request.Method = "GET"
            request.ContentType = "application/json"

            Using response = DirectCast(request.GetResponse(), HttpWebResponse)
                Using streamReader As New StreamReader(response.GetResponseStream())
                    responseData = streamReader.ReadToEnd()
                End Using
            End Using

            Return responseData
        Catch ex As WebException
            If ex.Response IsNot Nothing Then
                Using stream As Stream = ex.Response.GetResponseStream()
                    Using reader As New StreamReader(stream)
                        responseData = reader.ReadToEnd()
                    End Using
                End Using
            End If

            Return ex.Message
        End Try

    End Function

    Function MakeRequestPOST(url As String) As Object

        Dim responseData = ""
        Dim request = DirectCast(WebRequest.Create(url), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        Try


            Using response = DirectCast(request.GetResponse(), HttpWebResponse)
                Using streamReader As New StreamReader(response.GetResponseStream())

                    If response.StatusCode = HttpStatusCode.OK Then

                        responseData = streamReader.ReadToEnd()

                    End If

                    If response.StatusCode = HttpStatusCode.NotFound Then

                        responseData = "404"

                    End If

                End Using
            End Using

            Return responseData

        Catch ex As WebException

            If ex.Response IsNot Nothing Then
                Using stream As Stream = ex.Response.GetResponseStream()
                    Using reader As New StreamReader(stream)

                        responseData = reader.ReadToEnd()
                    End Using
                End Using
            End If

            Return ex.Message

        End Try

    End Function

    Function MakeRequestPOSTCrear(url As String, data As Object) As Object

        'Dim responseData = ""
        'Dim jsonData As String = JsonConvert.SerializeObject(data)
        'Dim request = DirectCast(WebRequest.Create(url), HttpWebRequest)
        'request.Method = "POST"
        'request.ContentType = "application/json"
        'Try

        '    Using streamWriter As New StreamWriter(request.GetRequestStream())
        '        streamWriter.Write(data)
        '        streamWriter.Flush()
        '        streamWriter.Close()
        '    End Using

        '    Using response = DirectCast(request.GetResponse(), HttpWebResponse)
        '        Using streamReader As New StreamReader(response.GetResponseStream())
        '            responseData = streamReader.ReadToEnd()
        '        End Using
        '    End Using

        '    Return responseData

        'Catch ex As WebException

        '    If ex.Response IsNot Nothing Then
        '        Using stream As Stream = ex.Response.GetResponseStream()
        '            Using reader As New StreamReader(stream)
        '                responseData = reader.ReadToEnd()
        '            End Using
        '        End Using
        '    End If

        '    Return ex.Message

        'End Try

        Using client As New HttpClient()
            ' Crear la solicitud HTTP
            Dim request As New HttpRequestMessage(HttpMethod.Post, url)



            ' Datos del cuerpo de la solicitud
            Dim content As New StringContent(data, Encoding.UTF8, "application/json")
            request.Content = content

            ' Enviar la solicitud
            Dim response As HttpResponseMessage = client.SendAsync(request).Result

            ' Verificar si la solicitud fue exitosa
            response.EnsureSuccessStatusCode()

            ' Devolver la respuesta como cadena
            'frmTextBoxAltaArt.AgregarMensaje(response.Content.ReadAsStringAsync().Result)
            Return response.Content.ReadAsStringAsync().Result
        End Using

    End Function

    'SOLO PARA DESARROLLO. OCULTAR ANTES DE SALIR A PROD
    Private Sub btnCrearTurno_Click(sender As Object, e As EventArgs)

        Dim urlTurnos = $"{connectionString}/turno"

        'Dim data = New Dictionary(Of String, String) From {
        '    {"motivo", cmbMotivos.Text.ToLower}
        '}
        Dim data = $"{{""motivo"":""{cmbMotivos.Text.ToLower}""}}"

        MakeRequestPOSTCrear(urlTurnos, data)

    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click

        Try

            Dim json As JsonDocument = JsonDocument.Parse(turno)
            Dim rootElement = json.RootElement

            Dim urlFinalizar = $"{connectionString}//turno/{rootElement.GetProperty("id").ToString}/finalizar"

            AbrirEspera()
            MakeRequestPOST(urlFinalizar)
            CerrarEspera()

            txtTurno.Text = $"Turno: {rootElement.GetProperty("codigo").ToString} atendido"

            'Habilitar botones siguiente y anterior
            btnSiguiente.Enabled = True
            btnAnterior.Enabled = True

        Catch ex As Exception

            If ex.Message.Contains("'T'") Then

                MsgBox("No hay turnos para finalizar.", MsgBoxStyle.Exclamation, "Sin turnos")
                Me.Enabled = False

            Else

                MsgBox(ex.Message, MsgBoxStyle.Critical, "Turnero")

            End If


        End Try

    End Sub

    Private Sub btnCaja_Click(sender As Object, e As EventArgs) Handles btnCaja.Click

        frmCaja.Show()

    End Sub


    Private Sub Turnero_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If turno IsNot Nothing Then

            btnFinalizar.PerformClick()

        End If

    End Sub
    Private Sub AbrirEspera()


        If SSM.IsSplashFormVisible = False Then
            Me.Enabled = False
            SSM.ShowWaitForm()
        End If

    End Sub

    Private Sub CerrarEspera()
        If SSM.IsSplashFormVisible Then
            SSM.CloseWaitForm()
            Me.Enabled = True
        End If
    End Sub

    'Private Sub CambiarHost()

    '    Dim ip As String = "127.0.0.1"
    '    Dim hostname As String = "midominio.local"

    '    Dim psi As New ProcessStartInfo()
    '    psi.FileName = "modificar_hosts.bat"
    '    psi.Arguments = ip & " " & hostname
    '    psi.Verb = "runas" ' Ejecutar como administrador
    '    psi.UseShellExecute = True

    '    Try
    '        Process.Start(psi)
    '    Catch ex As Exception
    '        MessageBox.Show("Error al ejecutar el script: " & ex.Message)
    '    End Try


    'End Sub

End Class
