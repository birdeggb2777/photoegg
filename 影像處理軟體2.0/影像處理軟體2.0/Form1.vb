Public Class Form1

    Private Sub 檔案ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 檔案ToolStripMenuItem.Click

    End Sub

    Private Sub 會出圖片ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 會出圖片ToolStripMenuItem.Click
        On Error Resume Next
        Dim c As Image
        c = PictureBox1.Image
        Dim saveFileDialog As New SaveFileDialog
        saveFileDialog.Filter = "圖片檔 (*.png;*.jpg;*.bmp;*.gif;*.tif)|*.png;*.jpg;*.bmp;*.gif;*.tif"
        If saveFileDialog.ShowDialog = DialogResult.OK And saveFileDialog.FileName.Trim <> "" Then
            c.Save(saveFileDialog.FileName)
            MsgBox("圖片儲存時會有失真的現象，若想要不失真的圖片請用複製圖片的方式")
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = Color.Snow
        Me.WindowState = 2
        PictureBox2.Left = -200
        PictureBox3.Left = -200
        重複ToolStripMenuItem.Visible = False
    End Sub

    Private Sub 匯入圖片ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 匯入圖片ToolStripMenuItem.Click
        On Error Resume Next
        OpenFileDialog1.Filter = "圖片檔 (*.png;*.jpg;*.bmp;*.gif;*.tif)|*.png;*.jpg;*.bmp;*.gif;*.tif"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox2.Image = PictureBox1.Image
            Dim a As New Bitmap(OpenFileDialog1.FileName)
            PictureBox1.Image = a
            Dim r As Integer
            r = a.Width
            Dim t As Integer
            t = a.Height
            PictureBox1.Size = New Size(r, t)
            If r * t >= 500000 Then
                MsgBox("您的圖片大小超過五十萬畫素，部分功能可能需要更多時間才能完成")
            End If

            '  PictureBox3.Image = PictureBox1.Image
            '    PictureBox4.Image = PictureBox1.Image
            ' PictureBox5.Image = PictureBox1.Image
        End If
    End Sub

    Private Sub 重複ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 重複ToolStripMenuItem.Click
        On Error Resume Next
        ' 復原ToolStripMenuItem.Visible = False
        PictureBox1.Image = PictureBox3.Image
    End Sub

    Private Sub 複製圖片ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 複製圖片ToolStripMenuItem.Click
        On Error Resume Next
        My.Computer.Clipboard.SetImage(PictureBox1.Image)
    End Sub

    Private Sub 貼上圖片ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 貼上圖片ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim a As New Bitmap(My.Computer.Clipboard.GetImage)
        PictureBox1.Image = a
        Dim r As Integer
        r = a.Width
        Dim t As Integer
        t = a.Height
        PictureBox1.Size = New Size(r, t)
        If r * t >= 500000 Then
            MsgBox("您的圖片大小超過五十萬畫素，部分功能可能需要更多時間才能完成")
        End If
    End Sub

    Private Sub 復原ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 復原ToolStripMenuItem.Click
        On Error Resume Next
        重複ToolStripMenuItem.Visible = True
        PictureBox3.Image = PictureBox1.Image
        PictureBox1.Image = PictureBox2.Image
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        復原ToolStripMenuItem.Visible = True
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim co2 As Color
        Dim rr2 As String
        Dim gg2 As String
        Dim bb2 As String
        Dim a As Integer = 1
        Dim b As Integer = 1
        For height1 = 1 To t - 1
            For width1 = 1 To r - 1
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png.GetPixel(a + 1, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If (rr - rr2) ^ 2 <= 3600 Or (gg - gg2) ^ 2 <= 3600 Or (bb - bb2) ^ 2 <= 3600 Then
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        Call picture()
    End Sub
    Private Sub picture()
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 1
        Dim b As Integer = 1
        For height1 = 1 To t - 2
            For width1 = 1 To r - 2
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If rr = 0 And gg = 0 And bb = 0 Then
                Else
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        復原ToolStripMenuItem.Visible = True
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim co2 As Color
        Dim rr2 As String
        Dim gg2 As String
        Dim bb2 As String
        Dim a As Integer = 1
        Dim b As Integer = 1
        For height1 = 1 To t - 1
            For width1 = 1 To r - 1
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png.GetPixel(a + 1, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If (rr - rr2) ^ 2 <= 2500 Or (gg - gg2) ^ 2 <= 2500 Or (bb - bb2) ^ 2 <= 2500 Then
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        Call picture()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        復原ToolStripMenuItem.Visible = True
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim co2 As Color
        Dim rr2 As String
        Dim gg2 As String
        Dim bb2 As String
        Dim a As Integer = 1
        Dim b As Integer = 1
        For height1 = 1 To t - 1
            For width1 = 1 To r - 1
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png.GetPixel(a + 1, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If (rr - rr2) ^ 2 <= 1600 Or (gg - gg2) ^ 2 <= 1600 Or (bb - bb2) ^ 2 <= 1600 Then
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        Call picture()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        復原ToolStripMenuItem.Visible = True
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim co2 As Color
        Dim rr2 As String
        Dim gg2 As String
        Dim bb2 As String
        Dim a As Integer = 1
        Dim b As Integer = 1
        For height1 = 1 To t - 1
            For width1 = 1 To r - 1
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png.GetPixel(a + 1, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If (rr - rr2) ^ 2 <= 900 Or (gg - gg2) ^ 2 <= 900 Or (bb - bb2) ^ 2 <= 900 Then
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        Call picture()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        復原ToolStripMenuItem.Visible = True
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim co2 As Color
        Dim rr2 As String
        Dim gg2 As String
        Dim bb2 As String
        Dim a As Integer = 1
        Dim b As Integer = 1
        For height1 = 1 To t - 1
            For width1 = 1 To r - 1
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png.GetPixel(a + 1, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If (rr - rr2) ^ 2 <= 400 Or (gg - gg2) ^ 2 <= 400 Or (bb - bb2) ^ 2 <= 400 Then
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        Call picture()
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        復原ToolStripMenuItem.Visible = True
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim co2 As Color
        Dim rr2 As String
        Dim gg2 As String
        Dim bb2 As String
        Dim a As Integer = 1
        Dim b As Integer = 1
        For height1 = 1 To t - 1
            For width1 = 1 To r - 1
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png.GetPixel(a + 1, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If (rr - rr2) ^ 2 <= 100 Or (gg - gg2) ^ 2 <= 100 Or (bb - bb2) ^ 2 <= 100 Then
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        Call picture()
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        復原ToolStripMenuItem.Visible = True
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim co2 As Color
        Dim rr2 As String
        Dim gg2 As String
        Dim bb2 As String
        Dim a As Integer = 1
        Dim b As Integer = 1
        For height1 = 1 To t - 1
            For width1 = 1 To r - 1
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png.GetPixel(a + 1, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If (rr - rr2) ^ 2 <= 25 Or (gg - gg2) ^ 2 <= 25 Or (bb - bb2) ^ 2 <= 25 Then
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        Call picture()
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        復原ToolStripMenuItem.Visible = True
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim co2 As Color
        Dim rr2 As String
        Dim gg2 As String
        Dim bb2 As String
        Dim a As Integer = 1
        Dim b As Integer = 1
        For height1 = 1 To t - 1
            For width1 = 1 To r - 1
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png.GetPixel(a + 1, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If (rr - rr2) ^ 2 <= 1 Or (gg - gg2) ^ 2 <= 1 Or (bb - bb2) ^ 2 <= 1 Then
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        Call picture()
    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim co2 As Color
        Dim rr2 As String
        Dim gg2 As String
        Dim bb2 As String
        Dim a As Integer = 1
        Dim b As Integer = 1
        For height1 = 1 To t - 1
            For width1 = 1 To r - 1
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png.GetPixel(a + 1, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If (rr - rr2) ^ 2 <= 100 Or (gg - gg2) ^ 2 <= 100 Or (bb - bb2) ^ 2 <= 100 Then
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                Else

                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim co2 As Color
        Dim rr2 As String
        Dim gg2 As String
        Dim bb2 As String
        Dim a As Integer = 1
        Dim b As Integer = 1
        For height1 = 1 To t - 1
            For width1 = 1 To r - 1
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png.GetPixel(a + 1, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If (rr - rr2) ^ 2 <= 25 Or (gg - gg2) ^ 2 <= 25 Or (bb - bb2) ^ 2 <= 25 Then
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                Else

                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim co2 As Color
        Dim rr2 As String
        Dim gg2 As String
        Dim bb2 As String
        Dim a As Integer = 1
        Dim b As Integer = 1
        For height1 = 1 To t - 1
            For width1 = 1 To r - 1
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png.GetPixel(a + 1, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If (rr - rr2) ^ 2 <= 1 Or (gg - gg2) ^ 2 <= 1 Or (bb - bb2) ^ 2 <= 1 Then
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                Else

                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 繪製油畫ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 繪製油畫ToolStripMenuItem.Click
        On Error Resume Next
        MsgBox("繪製油畫可能需要大量時間，請耐心等候")
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                '白黑灰
                If (rr - gg) ^ 2 <= 625 And (gg - bb) ^ 2 <= 625 And (rr - bb) ^ 2 <= 625 Then
                    If rr > 170 Then
                        png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                    ElseIf rr >= 120 And rr <= 170 Then
                        png.SetPixel(a, b, Color.FromArgb(170, 170, 170))
                    ElseIf rr >= 70 And rr < 120 Then
                        png.SetPixel(a, b, Color.FromArgb(95, 95, 95))
                    ElseIf rr < 70 Then
                        png.SetPixel(a, b, Color.FromArgb(1, 1, 1))
                    End If

                    '皮膚'測試
                    '     ElseIf rr >= 140 And gg - bb >= 30 And gg >= 100 And bb >= 100 And rr - gg >= 20 And rr - bb >= 30 Then
                    '       png.SetPixel(a, b, Color.FromArgb(255, 230, 205))
                    '皮膚'測試2
                    '    ElseIf rr >= 100 And gg - bb >= 15 And gg >= 60 And bb >= 40 And rr - gg >= 20 And rr - bb >= 40 Then
                    '   png.SetPixel(a, b, Color.FromArgb(233, 200, 170))


                    '紅色
                    ' ElseIf rr >= 150 Then
                ElseIf rr >= 180 And (gg - bb) ^ 2 <= 400 And gg <= 110 And bb <= 110 Then
                    png.SetPixel(a, b, Color.FromArgb(227, 35, 35))
                    '淺紅()'有問題
                    '  ElseIf rr >= 200 And (gg - bb) ^ 2 <= 100 And gg >= 170 And bb >= 170 Then
                    '   png.SetPixel(a, b, Color.FromArgb(255, 200, 200))
                    '深紅
                ElseIf rr >= 70 And (gg - bb) ^ 2 <= 100 And gg <= 30 And bb <= 30 Then
                    png.SetPixel(a, b, Color.FromArgb(100, 25, 25))
                    '深紅2
                ElseIf rr >= 90 And (gg - bb) ^ 2 <= 100 And gg <= 80 And bb <= 80 Then
                    png.SetPixel(a, b, Color.FromArgb(110, 60, 60))
                    ' 紅皮膚2
                ElseIf rr >= 200 And gg >= 190 And bb >= 190 And (gg - bb) ^ 2 <= 100 And rr - bb >= 30 Then
                    png.SetPixel(a, b, Color.FromArgb(240, 210, 206))
                    '紅皮膚'待修正
                ElseIf rr >= 180 And gg >= 140 And bb >= 140 And (gg - bb) ^ 2 <= 25 And rr - bb >= 40 Then
                    png.SetPixel(a, b, Color.FromArgb(231, 173, 171))


                    '橘紅色
                ElseIf rr <= 200 And rr >= 100 And gg - bb <= 70 And gg < 80 And bb <= 80 Then
                    png.SetPixel(a, b, Color.FromArgb(130, 40, 0))
                    '深橘紅
                ElseIf rr >= 50 And rr <= 100 And gg - bb <= 50 And gg < 50 And bb <= 50 Then
                    png.SetPixel(a, b, Color.FromArgb(80, 20, 0))
                    '皮膚
                ElseIf rr >= 200 And gg - bb <= 50 And gg >= 110 And gg <= 175 And bb >= 70 And bb <= 150 Then
                    png.SetPixel(a, b, Color.FromArgb(235, 167, 135))
                    '標註'''''''''''''

                    '淺皮膚'''些許問題
                    '   ElseIf rr >= 200 And gg - bb <= 25 And gg - bb >= 5 And gg >= 160 And gg <= 230 And bb >= 130 And bb <= 220 Then
                    '    png.SetPixel(a, b, Color.FromArgb(253, 213, 195))


                    '標註'''''''''''''


                    '黃色
                ElseIf rr >= 150 And gg >= 150 And (rr - gg) ^ 2 < 1600 And bb <= 100 And gg - bb > 150 And rr >= gg Then
                    png.SetPixel(a, b, Color.FromArgb(255, 230, 0))
                    '黃色2'麥
                ElseIf rr >= 180 And gg >= 180 And (rr - gg) ^ 2 <= 900 And rr >= gg And bb <= 210 And bb >= 110 And gg - bb > 20 And rr <= 240 And gg <= 230 Then
                    png.SetPixel(a, b, Color.FromArgb(230, 220, 140))
                    '淺黃色
                ElseIf rr >= gg And rr >= 150 And gg >= 160 And bb >= 80 And (rr - gg) ^ 2 < 400 And bb <= 180 And gg - bb < 90 And gg - bb >= 50 Then
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 120))
                    '暗黃色'有問題

                    '    ElseIf rr >= 100 And rr <= 190 And gg <= 160 And bb <= 80 And (rr - gg) ^ 2 < 900 And gg - bb < 140 Then
                    '       png.SetPixel(a, b, Color.FromArgb(130, 115, 16))
                    '暗暗黃色
                ElseIf rr >= 60 And rr <= 100 And gg <= 80 And bb <= 60 And (rr - gg) ^ 2 < 900 And gg - bb < 80 Then
                    png.SetPixel(a, b, Color.FromArgb(100, 80, 20))
                    '橙色
                ElseIf rr >= 200 And gg - bb <= 150 And gg - bb > 50 And gg >= 130 And gg <= 180 And bb <= 70 Then
                    png.SetPixel(a, b, Color.FromArgb(255, 149, 0))


                    '橘色
                ElseIf rr >= 200 And gg - bb <= 150 And gg - bb > 50 And gg < 130 Then
                    png.SetPixel(a, b, Color.FromArgb(230, 90, 20))
                    '  ElseIf rr >= 150 And gg - bb <= 150 And gg - bb > 50 And gg < 170 Then
                    '      png.SetPixel(a, b, Color.FromArgb(254, 150, 0))
                    '淺橘
                ElseIf rr >= 200 And gg - bb <= 120 And gg - bb >= 50 And gg < 180 Then
                    png.SetPixel(a, b, Color.FromArgb(255, 160, 0))
                    '紅橘
                ElseIf rr >= 100 And rr - gg >= 50 And gg - bb <= 70 And gg >= 60 And gg <= 150 And bb >= 10 And bb <= 100 Then
                    png.SetPixel(a, b, Color.FromArgb(180, 100, 60))
                    '淺紅橘'有問題
                ElseIf rr >= 100 And gg - bb <= 40 And gg - bb >= 0 And gg >= 60 And bb >= 85 And rr <= 210 And rr - gg >= 20 And rr - bb >= 40 Then
                    png.SetPixel(a, b, Color.FromArgb(180, 140, 120))
                    '粉紅
                ElseIf rr >= 150 And bb - gg >= 130 And bb >= 150 And gg < 100 And (rr - bb) ^ 2 <= 900 Then
                    png.SetPixel(a, b, Color.FromArgb(255, 0, 235))
                    '深粉紅
                ElseIf rr >= 80 And bb - gg >= 50 And bb >= 80 And gg < 50 And (rr - bb) ^ 2 <= 900 Then
                    png.SetPixel(a, b, Color.FromArgb(115, 11, 112))
                    '暗粉紅
                ElseIf bb >= 100 And bb <= 200 And rr >= 100 And gg <= 160 And (rr - bb) ^ 2 <= 400 And rr - gg >= 20 And bb - gg >= 20 Then
                    png.SetPixel(a, b, Color.FromArgb(177, 114, 177))


                    '暗暗粉紅
                ElseIf bb >= 80 And bb <= 140 And rr >= 80 And gg <= 140 And (rr - bb) ^ 2 <= 400 And rr - gg >= 10 And bb - gg >= 10 Then
                    png.SetPixel(a, b, Color.FromArgb(130, 80, 130))
                    '紫色
                ElseIf rr >= 150 And bb - gg >= 130 And bb >= 150 And gg < 100 And (rr - bb) ^ 2 >= 900 Then
                    png.SetPixel(a, b, Color.FromArgb(170, 0, 255))
                    '淺粉紅
                ElseIf bb >= 200 And rr >= 200 And gg >= 100 And gg <= 200 Then
                    png.SetPixel(a, b, Color.FromArgb(250, 150, 250))
                    '  End If
                    '藍色偏深
                ElseIf bb >= 150 And rr <= 100 And gg <= 80 Then
                    png.SetPixel(a, b, Color.FromArgb(0, 30, 250))
                    '藍色
                ElseIf bb >= 180 And rr <= 110 And gg >= 110 And gg <= 170 And gg - rr >= 90 And bb - rr >= 120 Then
                    png.SetPixel(a, b, Color.FromArgb(0, 160, 250))

                    '淺淺藍
                ElseIf bb >= 180 And rr <= 200 And rr >= 100 And gg >= 180 And gg - rr >= 45 And bb - rr >= 45 And (gg - bb) ^ 2 <= 100 Then
                    png.SetPixel(a, b, Color.FromArgb(180, 255, 250))
                    '淺藍
                ElseIf bb >= 200 And rr <= 100 And gg >= 200 And gg - rr >= 120 And bb - rr >= 120 Then
                    png.SetPixel(a, b, Color.FromArgb(60, 255, 250))
                    '淺藍2
                ElseIf bb >= 180 And rr <= 160 And gg >= 110 And gg <= 220 And gg - rr >= 60 And bb - rr >= 80 And bb - gg <= 40 And bb - gg >= -20 Then
                    png.SetPixel(a, b, Color.FromArgb(141, 205, 242))
                    ' 暗淺藍
                ElseIf bb >= 100 And rr <= 100 And gg >= 100 And gg - rr >= 80 And bb - rr >= 80 And (gg - bb) ^ 2 <= 100 Then
                    png.SetPixel(a, b, Color.FromArgb(35, 150, 150))
                    '暗暗淺藍
                ElseIf bb >= 50 And rr <= 60 And gg <= 100 And gg - rr >= 20 And bb - rr >= 20 And (gg - bb) ^ 2 <= 100 Then
                    png.SetPixel(a, b, Color.FromArgb(11, 85, 85))
                    '暗淺藍2
                ElseIf bb >= 60 And rr <= 100 And gg >= 100 And gg - rr >= 20 And bb - rr >= 30 And (gg - bb) ^ 2 <= 100 Then
                    png.SetPixel(a, b, Color.FromArgb(80, 120, 125))
                    '  ' ' 藍色偏深偏淺
                ElseIf bb >= 150 And rr >= 100 And gg >= 80 And bb - rr >= 30 And bb - gg >= 30 And rr - gg >= -15 Then
                    png.SetPixel(a, b, Color.FromArgb(160, 170, 240))
                    '  ' ' 藍色偏深偏淺2'測試
                ElseIf bb >= 150 And rr >= 100 And gg >= 80 And bb - rr >= 30 And bb - gg >= 30 And rr - gg < -15 Then
                    png.SetPixel(a, b, Color.FromArgb(160, 170, 240))
                    '藍色淺'測試
                ElseIf bb >= 180 And rr >= 100 And gg >= 90 And bb - rr >= 5 And bb - gg >= 5 And rr - gg < -4 Then
                    png.SetPixel(a, b, Color.FromArgb(209, 214, 230))


                    '藍色偏深偏深偏淺
                ElseIf bb >= 150 And rr >= 60 And gg >= 80 And bb - rr >= 100 And bb - gg >= 70 And gg - rr >= 5 And rr - gg >= -10 Then
                    png.SetPixel(a, b, Color.FromArgb(80, 100, 235))
                    '藍色偏深偏深
                ElseIf bb >= 70 And rr <= 60 And gg <= 80 And bb - rr >= 60 And bb - gg >= 50 And rr - gg >= -10 Then
                    png.SetPixel(a, b, Color.FromArgb(33, 43, 122))
                    ''藍色偏深海底
                ElseIf bb >= 30 And rr <= 40 And gg <= 60 And bb - rr >= 30 And bb - gg >= 20 And rr - gg >= -5 Then
                    png.SetPixel(a, b, Color.FromArgb(6, 14, 81))
                    '  '   '藍色偏深偏淺偏暗
                ElseIf bb >= 70 And bb <= 170 And rr <= 120 And gg <= 120 And rr >= 40 And gg >= 40 And bb - rr >= 15 And bb - gg >= 15 And rr - gg >= -5 Then
                    png.SetPixel(a, b, Color.FromArgb(84, 90, 136))
                    '淺淺綠
                ElseIf gg >= 200 And bb >= 80 And rr >= 110 And gg - rr >= 10 And gg - bb >= 20 Then
                    png.SetPixel(a, b, Color.FromArgb(163, 233, 154))
                    '淺綠色
                ElseIf gg >= 200 And bb <= 100 And rr <= 140 Then
                    png.SetPixel(a, b, Color.FromArgb(80, 230, 60))
                    '綠色
                ElseIf gg >= 100 And bb <= 60 And rr <= 90 Then
                    png.SetPixel(a, b, Color.FromArgb(40, 120, 30))
                    '深綠色
                ElseIf gg >= 10 And gg <= 130 And bb <= 70 And rr <= 80 And gg - rr >= 10 And gg - bb >= 10 Then
                    png.SetPixel(a, b, Color.FromArgb(9, 50, 3))
                    '灰綠
                ElseIf rr >= 180 And gg >= 180 And bb >= 170 And rr <= 230 And gg <= 230 And bb <= 210 And (rr - gg) ^ 2 <= 25 And rr - bb >= 10 Then
                    png.SetPixel(a, b, Color.FromArgb(200, 200, 190))
                    '灰暗綠色
                ElseIf rr >= 150 And gg >= 150 And bb >= 150 And rr <= 230 And gg <= 230 And bb <= 210 And (rr - bb) ^ 2 <= 25 And gg - rr >= 5 Then
                    png.SetPixel(a, b, Color.FromArgb(168, 178, 167))
                    '暗綠色
                ElseIf gg >= 10 And gg <= 200 And bb <= 170 And rr <= 170 And gg - rr >= 10 And gg - bb >= 10 Then
                    png.SetPixel(a, b, Color.FromArgb(105, 143, 84))
                    ''''''''暗藍
                ElseIf rr <= 80 And gg <= 120 And bb >= 60 And bb - rr >= 80 And bb - gg >= 20 Then
                    png.SetPixel(a, b, Color.FromArgb(50, 100, 160))
                    ''''''''桃紅
                ElseIf rr >= 150 And gg <= 130 And bb >= 80 And rr - gg >= 100 And bb - gg >= 70 Then
                    png.SetPixel(a, b, Color.FromArgb(250, 40, 150))
                    ''''''''桃紅2
                ElseIf rr >= 150 And gg >= 30 And bb >= 80 And rr - gg >= 30 And bb - gg >= 30 Then
                    png.SetPixel(a, b, Color.FromArgb(200, 140, 170))




                    '淺淺皮膚
                ElseIf rr >= 200 And rr - bb >= 15 And rr - gg >= 10 And gg - bb >= 5 And gg >= 200 And bb >= 180 Then
                    png.SetPixel(a, b, Color.FromArgb(237, 224, 215))


                    '標註'''''''''''''

                    '淺皮膚'''些許問題
                ElseIf rr >= 200 And gg - bb <= 25 And rr - gg >= 15 And rr - bb >= 15 And gg - bb >= 5 And gg >= 160 And gg <= 230 And bb >= 130 And bb <= 220 Then
                    png.SetPixel(a, b, Color.FromArgb(253, 213, 195))


                    '標註'''''''''''''
                    '一種深藍
                ElseIf rr <= 60 And gg <= 100 And bb >= 50 And bb - gg >= 5 And bb - rr >= 20 And gg - rr >= 10 Then
                    png.SetPixel(a, b, Color.FromArgb(30, 70, 90))

                    '一種灰藍
                ElseIf rr <= 90 And gg <= 160 And bb >= 100 And bb - gg >= 20 And bb - rr >= 60 And gg - rr >= 30 Then
                    png.SetPixel(a, b, Color.FromArgb(70, 110, 140))
                    '一種淺灰藍
                ElseIf rr >= 90 And gg >= 100 And bb >= 100 And rr <= 180 And gg <= 200 And bb <= 200 And (bb - gg) ^ 2 <= 225 And bb - rr >= 20 Then
                    png.SetPixel(a, b, Color.FromArgb(120, 145, 150))


                    '黑色
                ElseIf rr <= 40 And gg <= 40 And bb <= 40 Then
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))




                End If

                a += 1

            Next
            a = 0
            b += 1

        Next
    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c1 = Int(rr / 2) + Int(gg / 2)
                c2 = Int(gg / 2) + Int(bb / 2)
                c3 = Int(rr / 2) + Int(bb / 2)
                png.SetPixel(a, b, Color.FromArgb(c1, c2, c3))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        'PictureBox2.Image = PictureBox2.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c1 = Int(rr / 2) + Int(gg / 2)
                c3 = Int(gg / 2) + Int(bb / 2)
                c2 = Int(rr / 2) + Int(bb / 2)
                png.SetPixel(a, b, Color.FromArgb(c1, c2, c3))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem15.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c2 = Int(rr / 2) + Int(gg / 2)
                c1 = Int(gg / 2) + Int(bb / 2)
                c3 = Int(rr / 2) + Int(bb / 2)
                png.SetPixel(a, b, Color.FromArgb(c1, c2, c3))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem16.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c2 = Int(rr / 2) + Int(gg / 2)
                c3 = Int(gg / 2) + Int(bb / 2)
                c1 = Int(rr / 2) + Int(bb / 2)
                png.SetPixel(a, b, Color.FromArgb(c1, c2, c3))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem17.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c3 = Int(rr / 2) + Int(gg / 2)
                c1 = Int(gg / 2) + Int(bb / 2)
                c2 = Int(rr / 2) + Int(bb / 2)
                png.SetPixel(a, b, Color.FromArgb(c1, c2, c3))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem18.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c3 = Int(rr / 2) + Int(gg / 2)
                c2 = Int(gg / 2) + Int(bb / 2)
                c1 = Int(rr / 2) + Int(bb / 2)
                png.SetPixel(a, b, Color.FromArgb(c1, c2, c3))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem19.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c1 = Int(rr / 2) + Int(gg / 2)
                c2 = Int(gg / 2) + Int(bb / 2)
                png.SetPixel(a, b, Color.FromArgb(c1, c2, bb))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem20.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c1 = Int(rr / 2) + Int(gg / 2)
                c3 = Int(rr / 2) + Int(bb / 2)
                png.SetPixel(a, b, Color.FromArgb(c1, gg, c3))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem21.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c2 = Int(gg / 2) + Int(bb / 2)
                c3 = Int(rr / 2) + Int(bb / 2)
                png.SetPixel(a, b, Color.FromArgb(rr, c2, c3))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem22.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(rr, bb, gg))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem23.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(gg, rr, bb))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem24.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(bb, rr, gg))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem25.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(gg, bb, rr))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem26.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(bb, gg, rr))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem27.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim c As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c = Int(rr / 3) + Int(gg / 3) + Int(bb / 3)
                png.SetPixel(a, b, Color.FromArgb(c, c, bb))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem28.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim c As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c = Int(rr / 3) + Int(gg / 3) + Int(bb / 3)
                png.SetPixel(a, b, Color.FromArgb(c, gg, c))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem29.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim c As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c = Int(rr / 3) + Int(gg / 3) + Int(bb / 3)
                png.SetPixel(a, b, Color.FromArgb(rr, c, c))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem30.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim c As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c2 = Int(gg / 2) + Int(bb / 2)
                c3 = Int(rr / 2) + Int(bb / 2)
                png.SetPixel(a, b, Color.FromArgb(rr, c2, c3))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem31.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim c As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c1 = Int(rr / 2) + Int(gg / 2)
                c2 = Int(gg / 2) + Int(bb / 2)
                png.SetPixel(a, b, Color.FromArgb(c1, c2, bb))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem32.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim c As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c1 = Int(rr / 2) + Int(gg / 2)
                c3 = Int(rr / 2) + Int(bb / 2)
                png.SetPixel(a, b, Color.FromArgb(c1, gg, c3))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem33.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim c As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c3 = Int(rr / 2) + Int(bb / 2)
                png.SetPixel(a, b, Color.FromArgb(c3, gg, bb))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem34.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim c As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c1 = Int(rr / 2) + Int(gg / 2)
                png.SetPixel(a, b, Color.FromArgb(c1, gg, bb))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem35.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim c As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c3 = Int(rr / 2) + Int(bb / 2)
                png.SetPixel(a, b, Color.FromArgb(rr, gg, c3))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem36.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim c As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c1 = Int(rr / 2) + Int(gg / 2)
                png.SetPixel(a, b, Color.FromArgb(rr, c1, bb))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 純白ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 純白ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        png.MakeTransparent(Color.White)
    End Sub

    Private Sub 純黑ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 純黑ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        png.MakeTransparent(Color.Black)
    End Sub

    Private Sub 特效ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 特效ToolStripMenuItem.Click

    End Sub

    Private Sub 對比色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 對比色ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(255 - rr, 255 - gg, 255 - bb))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 訊號不良ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 訊號不良ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim co2 As Color
        Dim rr2 As String
        Dim gg2 As String
        Dim bb2 As String
        Dim a As Integer = 1
        Dim b As Integer = 1
        For height1 = 1 To t - 2
            For width1 = 1 To r - 2
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png.GetPixel(a, b + 1)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If (rr - rr2) ^ 2 <= 900 And (gg - gg2) ^ 2 <= 900 And (bb - bb2) ^ 2 <= 900 Then
                    png.SetPixel(a, b + 1, Color.FromArgb(rr, gg, bb))
                Else

                End If
                '    '''''''
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png.GetPixel(a + 1, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If (rr - rr2) ^ 2 <= 900 And (gg - gg2) ^ 2 <= 900 And (bb - bb2) ^ 2 <= 900 Then
                    png.SetPixel(a + 1, b, Color.FromArgb(rr, gg, bb))
                Else

                End If



                '
                '    '''''''
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 雜訊ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 雜訊ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c As Integer
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                c = Int(Rnd() * 10)
                c1 = Int(Rnd() * 240)
                c2 = Int(Rnd() * 240)
                c3 = Int(Rnd() * 240)
                If c = 5 Then
                    png.SetPixel(a, b, Color.FromArgb(c1, c2, c3))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 纖維化ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 纖維化ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png2 As New Bitmap(PictureBox2.Image)
        Dim png1 As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png1
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim co2 As Color
        Dim co3 As Color
        Dim co4 As Color
        Dim co5 As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim rr2 As String
        Dim gg2 As String
        Dim bb2 As String
        Dim a As Integer = 5
        Dim b As Integer = 5
        Dim c As String
        For height1 = 1 To t - 10
            For width1 = 1 To r - 10
                c = Str(b)
                co = png2.GetPixel(a, b - 5)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png2.GetPixel(a + 5, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If Strings.Right(c, 1) = 1 Or Strings.Right(c, 1) = Strings.Right(c, 1) = 3 Or Strings.Right(c, 1) = 5 Or Strings.Right(c, 1) = 7 Or Strings.Right(c, 1) = 9 Then
                    png1.SetPixel(a, b, Color.FromArgb(rr2, gg2, bb2))
                Else
                    png1.SetPixel(a, b, Color.FromArgb(rr, gg, bb))
                End If
                a += 1
            Next
            a = 5
            b += 1
        Next
    End Sub

    Private Sub 復古ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 復古ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If gg <= 230 And rr <= 200 Then
                    png.SetPixel(a, b, Color.FromArgb(rr + 50, gg + 25, bb))
                ElseIf gg <= 250 And rr <= 225 Then
                    png.SetPixel(a, b, Color.FromArgb(rr + 25, gg + 5, bb))

                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 黑白ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 黑白ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c = Int(rr / 3) + Int(gg / 3) + Int(bb / 3)
                png.SetPixel(a, b, Color.FromArgb(c, c, c))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 枯葉ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 枯葉ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c1 = Int(rr / 2) + Int(gg / 2)
                c2 = Int(gg / 2) + Int(bb / 2)
                c3 = Int(rr / 2) + Int(bb / 2)
                If gg >= 30 And gg - rr >= 0 And gg - bb >= 20 And rr <= 230 And bb <= 200 Then
                    png.SetPixel(a, b, Color.FromArgb(c1, c2, c3))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub ToolStripMenuItem37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem37.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As Integer
        Dim gg As Integer
        Dim bb As Integer
        Dim co2 As Color
        Dim rr2 As Integer
        Dim gg2 As Integer
        Dim bb2 As Integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t / 4

            For width1 = 1 To r / 4
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(255 - rr, 255 - gg, 255 - bb))
                a += 4
            Next
            a = 0
            b += 4
        Next
    End Sub

    Private Sub ToolStripMenuItem41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As Integer
        Dim gg As Integer
        Dim bb As Integer
        Dim co2 As Color
        Dim rr2 As Integer
        Dim gg2 As Integer
        Dim bb2 As Integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t / 2

            For width1 = 1 To r / 2
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(255 - rr, 255 - gg, 255 - bb))
                a += 2
            Next
            a = 0
            b += 2
        Next
    End Sub

    Private Sub ToolStripMenuItem40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As Integer
        Dim gg As Integer
        Dim bb As Integer
        Dim co2 As Color
        Dim rr2 As Integer
        Dim gg2 As Integer
        Dim bb2 As Integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t / 3

            For width1 = 1 To r / 3
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(255 - rr, 255 - gg, 255 - bb))
                a += 3
            Next
            a = 0
            b += 3
        Next
    End Sub

    Private Sub ToolStripMenuItem39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem39.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As Integer
        Dim gg As Integer
        Dim bb As Integer
        Dim co2 As Color
        Dim rr2 As Integer
        Dim gg2 As Integer
        Dim bb2 As Integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t / 2

            For width1 = 1 To r / 2
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(255 - rr, 255 - gg, 255 - bb))
                a += 2
            Next
            a = 0
            b += 2
        Next
    End Sub

    Private Sub ToolStripMenuItem38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem38.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As Integer
        Dim gg As Integer
        Dim bb As Integer
        Dim co2 As Color
        Dim rr2 As Integer
        Dim gg2 As Integer
        Dim bb2 As Integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t / 3

            For width1 = 1 To r / 3
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(255 - rr, 255 - gg, 255 - bb))
                a += 3
            Next
            a = 0
            b += 3
        Next
    End Sub

    Private Sub 透明化ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 透明化ToolStripMenuItem.Click

    End Sub

   
    Private Sub 增加綠色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 增加綠色ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If gg <= 230 Then
                    png.SetPixel(a, b, Color.FromArgb(rr, gg + 20, bb))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 減少綠色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 減少綠色ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If gg >= 20 Then
                    png.SetPixel(a, b, Color.FromArgb(rr, gg - 20, bb))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 增加紅色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 增加紅色ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If rr <= 230 Then
                    png.SetPixel(a, b, Color.FromArgb(rr + 20, gg, bb))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 減少紅色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 減少紅色ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If rr >= 20 Then
                    png.SetPixel(a, b, Color.FromArgb(rr - 20, gg, bb))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 增加藍色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 增加藍色ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If bb <= 230 Then
                    png.SetPixel(a, b, Color.FromArgb(rr, gg, bb + 20))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 減少藍色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 減少藍色ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If bb >= 20 Then
                    png.SetPixel(a, b, Color.FromArgb(rr, gg, bb - 20))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 增加亮度ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 增加亮度ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If rr <= 225 And gg <= 225 And bb <= 225 Then
                    png.SetPixel(a, b, Color.FromArgb(rr + 25, gg + 25, bb + 25))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 減少亮度ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 減少亮度ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As String
        Dim gg As String
        Dim bb As String
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If rr >= 25 And gg >= 25 And bb >= 25 Then
                    png.SetPixel(a, b, Color.FromArgb(rr - 25, gg - 25, bb - 25))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 預設ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 預設ToolStripMenuItem.Click
        Me.BackColor = Color.Snow
    End Sub

    Private Sub Cj6nk4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cj6nk4ToolStripMenuItem.Click
        Me.BackColor = color.red
    End Sub

    Private Sub 綠色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 綠色ToolStripMenuItem.Click
        Me.BackColor = Color.Green
    End Sub

    Private Sub 橘色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 橘色ToolStripMenuItem.Click
        Me.BackColor = Color.Orange
    End Sub

    Private Sub 藍色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 藍色ToolStripMenuItem.Click
        Me.BackColor = Color.Blue
    End Sub

    Private Sub 黑色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 黑色ToolStripMenuItem.Click
        Me.BackColor = Color.Black
    End Sub

    Private Sub 灰色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 灰色ToolStripMenuItem.Click
        Me.BackColor = Color.Gray
    End Sub

    Private Sub 粉紅色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 粉紅色ToolStripMenuItem.Click
        Me.BackColor = Color.Pink
    End Sub

    Private Sub 咖啡色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 咖啡色ToolStripMenuItem.Click
        Me.BackColor = Color.Sienna
    End Sub

    Private Sub 黃色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 黃色ToolStripMenuItem.Click
        Me.BackColor = Color.Yellow
    End Sub

    Private Sub 紫色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 紫色ToolStripMenuItem.Click
        Me.BackColor = Color.Purple
    End Sub
End Class
