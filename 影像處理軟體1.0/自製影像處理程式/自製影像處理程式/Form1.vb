Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        PictureBox2.Left = Val(Label1.Left) - 200
        PictureBox3.Left = Val(Label1.Left) - 200
        PictureBox4.Left = Val(Label1.Left) - 200
        PictureBox5.Left = Val(Label1.Left) - 200
        If Me.Height < 770 Then
            MsgBox("您的電腦解析度過低，部分元件可能無法顯示")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        OpenFileDialog1.Filter = "圖片檔 (*.png;*.jpg;*.bmp;*.gif;*.tif)|*.png;*.jpg;*.bmp;*.gif;*.tif"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
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
            PictureBox2.Image = PictureBox1.Image
            PictureBox3.Image = PictureBox1.Image
            PictureBox4.Image = PictureBox1.Image
            PictureBox5.Image = PictureBox1.Image
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim png As New Bitmap(OpenFileDialog1.FileName)
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
                co2 = png.GetPixel(a + 1, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If (rr - rr2) ^ 2 <= 50 ^ 2 Or (gg - gg2) ^ 2 <= 50 ^ 2 Or (bb - bb2) ^ 2 <= 50 ^ 2 Then
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        Call picture()
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
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

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox3.Image)
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
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim png As New Bitmap(OpenFileDialog1.FileName)
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
                co2 = png.GetPixel(a + 1, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If (rr - rr2) ^ 2 <= 5 ^ 2 Or (gg - gg2) ^ 2 <= 5 ^ 2 Or (bb - bb2) ^ 2 <= 5 ^ 2 Then
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        Call picture()
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim png As New Bitmap(OpenFileDialog1.FileName)
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
                co2 = png.GetPixel(a + 1, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If (rr - rr2) ^ 2 <= 20 ^ 2 Or (gg - gg2) ^ 2 <= 20 ^ 2 Or (bb - bb2) ^ 2 <= 20 ^ 2 Then
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        Call picture()
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox3.Image)
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
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox3.Image)
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
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox3.Image)
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
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox3.Image)
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
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox3.Image)
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
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox3.Image)
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
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox3.Image)
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
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox4.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox4.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox4.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        On Error Resume Next
        PictureBox1.Image = PictureBox2.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = png.Width
        Dim t As Integer
        t = png.Height
        PictureBox1.Size = New Size(r, t)
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
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
                '白黑灰
                If (rr - gg) ^ 2 <= 225 And (gg - bb) ^ 2 <= 225 And (rr - bb) ^ 2 <= 225 Then
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
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
        Dim co2 As Color
        Dim co3 As Color
        Dim co4 As Color
        Dim co5 As Color
        Dim rr2 As String
        Dim gg2 As String
        Dim bb2 As String
        Dim a As Integer = 2
        Dim b As Integer = 2
        For height1 = 1 To t - 3
            For width1 = 1 To r - 3
                co = png.GetPixel(a, b)
                co2 = png.GetPixel(a, b + 1)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                co3 = png.GetPixel(a + 1, b)
                co4 = png.GetPixel(a, b - 1)
                co5 = png.GetPixel(a - 1, b)
                If co2 = co3 And co3 = co4 And co4 = co5 And co <> co2 Then
                    png.SetPixel(a, b, Color.FromArgb(rr2, gg2, bb2))
                End If
                a += 1
            Next
            a = 2
            b += 1
        Next
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
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
        Dim co2 As Color
        Dim co3 As Color
        Dim co4 As Color
        Dim co5 As Color
        Dim rr2 As String
        Dim gg2 As String
        Dim bb2 As String
        Dim a As Integer = 4
        Dim b As Integer = 4
        For height1 = 1 To t - 8
            For width1 = 1 To r - 8
                co = png.GetPixel(a, b)
                co2 = png.GetPixel(a, b + 3)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                co3 = png.GetPixel(a + 3, b)
                co4 = png.GetPixel(a, b - 3)
                co5 = png.GetPixel(a - 3, b)
                If co2 = co3 And co3 = co4 And co4 = co5 And co <> co2 Then
                    png.SetPixel(a, b, Color.FromArgb(rr2, gg2, bb2))
                End If
                a += 1
            Next
            a = 4
            b += 1
        Next
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
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
        Dim co2 As Color
        Dim co3 As Color
        Dim co4 As Color
        Dim co5 As Color
        Dim rr2 As String
        Dim gg2 As String
        Dim bb2 As String
        Dim a As Integer = 5
        Dim b As Integer = 5
        For height1 = 1 To t - 10
            For width1 = 1 To r - 10
                co = png.GetPixel(a, b)
                co2 = png.GetPixel(a, b + 5)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                co3 = png.GetPixel(a + 5, b)
                co4 = png.GetPixel(a, b - 5)
                co5 = png.GetPixel(a - 5, b)
                If co2 = co3 And co3 = co4 And co4 = co5 And co <> co2 Then
                    png.SetPixel(a, b, Color.FromArgb(rr2, gg2, bb2))
                End If
                a += 1
            Next
            a = 5
            b += 1
        Next
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
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
        Dim co2 As Color
        Dim co3 As Color
        Dim co4 As Color
        Dim co5 As Color
        Dim rr2 As String
        Dim gg2 As String
        Dim bb2 As String
        Dim a As Integer = 8
        Dim b As Integer = 8
        For height1 = 1 To t - 15
            For width1 = 1 To r - 15
                co = png.GetPixel(a, b)
                co2 = png.GetPixel(a, b + 7)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                co3 = png.GetPixel(a + 7, b)
                co4 = png.GetPixel(a, b - 7)
                co5 = png.GetPixel(a - 7, b)
                If co2 = co3 And co3 = co4 And co4 = co5 And co <> co2 Then
                    png.SetPixel(a, b, Color.FromArgb(rr2, gg2, bb2))
                End If
                a += 1
            Next
            a = 8
            b += 1
        Next
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
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
                If gg >= 30 And gg - rr >= 0 And gg - bb >= 15 And rr <= 200 And bb <= 200 Then
                    png.SetPixel(a, b, Color.FromArgb(rr + 50, gg - 29, bb))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
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
                If gg >= 30 And gg - rr >= 0 And gg - bb >= 15 And rr <= 200 And bb <= 200 Then
                    png.SetPixel(a, b, Color.FromArgb(rr, gg - 29, bb + 50))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click
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
                c = Int(Rnd() * 1000)
                If c = 5 And rr <= 50 And gg <= 50 And bb <= 50 Then
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button32.Click
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button34.Click
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button36.Click
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button37.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button38.Click
        On Error Resume Next
        'PictureBox2.Image = PictureBox2.Image
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button39.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button40.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button41.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button42.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button43.Click
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
                If rr >= 60 And rr - gg >= 15 And rr - bb >= 15 And gg <= 200 And bb <= 200 And (gg - bb) ^ 2 <= 900 Then
                    png.SetPixel(a, b, Color.FromArgb(rr - 29, gg + 50, bb))
                End If



                a += 1
            Next
            a = 0
            b += 1
        Next
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button44.Click
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
                If rr >= 60 And rr - gg >= 15 And rr - bb >= 15 And gg <= 200 And bb <= 200 And (gg - bb) ^ 2 <= 900 Then
                    png.SetPixel(a, b, Color.FromArgb(rr - 29, gg, bb + 50))
                End If



                a += 1
            Next
            a = 0
            b += 1
        Next
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button45.Click
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
                If bb >= 30 And bb - gg >= -15 And bb - rr >= 15 And gg <= 230 And rr <= 230 Then
                    png.SetPixel(a, b, Color.FromArgb(rr + 20, gg, bb - 29))
                End If



                a += 1
            Next
            a = 0
            b += 1
        Next
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button46.Click
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
                If bb >= 30 And bb - gg >= -15 And bb - rr >= 15 And gg <= 230 And rr <= 230 Then
                    png.SetPixel(a, b, Color.FromArgb(rr, gg + 20, bb - 29))
                End If



                a += 1
            Next
            a = 0
            b += 1
        Next
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button47.Click
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button48.Click
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button49.Click
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
        For c = 1 To 6
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
            a = 0
            b = 0
        Next
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button50.Click
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
        For c = 1 To 6
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
            a = 0
            b = 0
        Next
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button51.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        png.MakeTransparent(Color.White)
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button52.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        png.MakeTransparent(Color.Black)
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button53.Click
        On Error Resume Next
        My.Computer.Clipboard.SetImage(PictureBox1.Image)
    End Sub

    Private Sub Button54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button54.Click
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button55.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim time As Integer = 0
        Opacity = 0 '視窗透明(不然會照到自己)
        For time = 1 To 10
            Dim ScrnPB As PictureBox = PictureBox1
            Dim ScrnSize As Size = My.Computer.Screen.Bounds.Size
            Dim ScrnImage As New Bitmap(ScrnSize.Width, ScrnSize.Height)
            Dim g As Graphics = Graphics.FromImage(ScrnImage)
            g.CopyFromScreen(New Point(Me.Left, Me.Top), New Point(0, 0), ScrnSize) '以自己視窗為始點修正偏移
            Dim dc As IntPtr = g.GetHdc
            g.ReleaseHdc(dc)
            With ScrnPB '使大小相同
                .Size = ScrnSize
                .Image = ScrnImage
            End With
        Next
        PictureBox1.Size = Me.Size
        Opacity = 70 '視窗透明度70%
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        PictureBox1.Size = New Size(r, t)
        If r * t >= 500000 Then
            MsgBox("您的圖片大小超過五十萬畫素，部分功能可能需要更多時間才能完成")
        End If
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button56.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button57_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button57.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button58_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button58.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button59_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button59.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button60_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button60.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button61_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button61.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button62_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button62.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button63_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button63.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button64_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button64.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button65_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button65.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button66_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button66.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button67_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button67.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button68_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button68.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button69_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button69.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button70_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button70.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button71_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button71.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button73_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button73.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub Button72_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button72.Click
        On Error Resume Next
        Dim png As New Bitmap(PictureBox5.Image)
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
        PictureBox3.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
    End Sub
End Class
