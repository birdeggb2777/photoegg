﻿Public Class Form1
    Dim ti As Integer = 0
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PictureBox1.BringToFront()
        Me.BackColor = Color.Snow
        Me.WindowState = 2
        PictureBox2.Left = -200
        PictureBox3.Left = -200
        PictureBox5.Left = -200
        PictureBox6.Left = -200
        重複ToolStripMenuItem.Visible = False
        TrackBar1.Hide()
        TrackBar2.Hide()
        TrackBar3.Hide()
        Button1.Hide()
        Label1.Hide()
        Label2.Hide()
        Label3.Hide()
        Button2.Hide()
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
        Dim rr As Integer
        Dim gg As Integer
        Dim bb As Integer
        Dim co2 As Color
        Dim rr2 As Integer
        Dim gg2 As Integer
        Dim bb2 As Integer
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
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        '   Call picture()
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As Integer
        Dim gg As Integer
        Dim bb As Integer
        Dim co2 As Color
        Dim rr2 As Integer
        Dim gg2 As Integer
        Dim bb2 As Integer
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
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        '  Call picture()
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
        Dim rr As Integer
        Dim gg As Integer
        Dim bb As Integer
        Dim co2 As Color
        Dim rr2 As Integer
        Dim gg2 As Integer
        Dim bb2 As Integer
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
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        ' Call picture()
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
        Dim rr As Integer
        Dim gg As Integer
        Dim bb As Integer
        Dim co2 As Color
        Dim rr2 As Integer
        Dim gg2 As Integer
        Dim bb2 As Integer
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
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        ' Call picture()
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
        Dim rr As Integer
        Dim gg As Integer
        Dim bb As Integer
        Dim co2 As Color
        Dim rr2 As Integer
        Dim gg2 As Integer
        Dim bb2 As Integer
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
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        ' Call picture()
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
        Dim rr As Integer
        Dim gg As Integer
        Dim bb As Integer
        Dim co2 As Color
        Dim rr2 As Integer
        Dim gg2 As Integer
        Dim bb2 As Integer
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
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        'Call picture()
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
        Dim rr As Integer
        Dim gg As Integer
        Dim bb As Integer
        Dim co2 As Color
        Dim rr2 As Integer
        Dim gg2 As Integer
        Dim bb2 As Integer
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
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        'Call picture()
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
        Dim rr As Integer
        Dim gg As Integer
        Dim bb As Integer
        Dim co2 As Color
        Dim rr2 As Integer
        Dim gg2 As Integer
        Dim bb2 As Integer
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
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        'Call picture()
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
        Dim rr As Integer
        Dim gg As Integer
        Dim bb As Integer
        Dim co2 As Color
        Dim rr2 As Integer
        Dim gg2 As Integer
        Dim bb2 As Integer
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
        Dim rr As Integer
        Dim gg As Integer
        Dim bb As Integer
        Dim co2 As Color
        Dim rr2 As Integer
        Dim gg2 As Integer
        Dim bb2 As Integer
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
        Dim rr As Integer
        Dim gg As Integer
        Dim bb As Integer
        Dim co2 As Color
        Dim rr2 As Integer
        Dim gg2 As Integer
        Dim bb2 As Integer
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
        Dim rr As Integer
        Dim gg As Integer
        Dim bb As Integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim co2 As Color
        Dim rr2 As integer
        Dim gg2 As integer
        Dim bb2 As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim rr2 As integer
        Dim gg2 As integer
        Dim bb2 As integer
        Dim a As Integer = 5
        Dim b As Integer = 5
        Dim c As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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
        Me.BackColor = Color.Red
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

    Private Sub 樣式1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 樣式1ToolStripMenuItem.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
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

    Private Sub 樣式2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 樣式2ToolStripMenuItem.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(255 - rr, 255 - bb, 255 - gg))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 樣式3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 樣式3ToolStripMenuItem.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(255 - gg, 255 - rr, 255 - bb))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 樣式4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 樣式4ToolStripMenuItem.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(255 - gg, 255 - bb, 255 - rr))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 樣式5ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 樣式5ToolStripMenuItem.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(255 - bb, 255 - rr, 255 - gg))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 樣式6ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 樣式6ToolStripMenuItem.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(255 - bb, 255 - gg, 255 - rr))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub
    Private Sub 圖層1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 圖層1ToolStripMenuItem.Click
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
            If r * t >= 600000 Then
                MsgBox("注意:您的圖片過大，請更換成較小的圖片，否則圖片繪製的時間可能會很久")
            End If
            '  PictureBox3.Image = PictureBox1.Image
            '    PictureBox4.Image = PictureBox1.Image
            ' PictureBox5.Image = PictureBox1.Image
        End If
    End Sub

    Private Sub 圖層2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 圖層2ToolStripMenuItem.Click
        On Error Resume Next
        OpenFileDialog1.Filter = "圖片檔 (*.png;*.jpg;*.bmp;*.gif;*.tif)|*.png;*.jpg;*.bmp;*.gif;*.tif"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox4.Image = Image.FromFile(OpenFileDialog1.FileName)
            ' PictureBox2.Image = PictureBox1.Image
            Dim a As New Bitmap(OpenFileDialog1.FileName)
            PictureBox4.Image = a
            Dim r As Integer
            r = a.Width
            Dim t As Integer
            t = a.Height
            Dim r2 As Integer = PictureBox1.Width
            Dim t2 As Integer = PictureBox1.Height
            PictureBox4.Size = New Size(r, t)
            If r * t >= 600000 Then
                MsgBox("注意:您的圖片過大，請更換成較小的圖片，否則圖片繪製的時間可能會很久")
            End If
        End If
    End Sub

    Private Sub 交叉淡化ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 交叉淡化ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        Dim png2 As New Bitmap(PictureBox4.Image)
        PictureBox4.Image = png2
        PictureBox1.Image = png
        Dim r2 As Integer = PictureBox4.Width
        Dim t2 As Integer = PictureBox4.Height
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
        If r2 > r And t2 < t Then
            For height1 = 1 To t
                For width1 = 1 To r
                    If r2 = a Then
                        Exit For
                    End If
                    If t2 = b Then
                        Exit For
                    End If
                    co = png.GetPixel(a, b)
                    co2 = png2.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    png.SetPixel(a, b, Color.FromArgb((rr + rr2) / 2, (gg + gg2) / 2, (bb + bb2) / 2))
                    a += 1
                Next
                If r2 = a Then
                    Exit For
                End If
                If t2 = b Then
                    Exit For
                End If
                a = 0
                b += 1
            Next
            '   MsgBox("1")
        ElseIf r2 < r And t2 > t Then
            For width1 = 1 To r
                For height1 = 1 To t
                    If r2 = a Then
                        Exit For
                    End If
                    If t2 = b Then
                        Exit For
                    End If
                    co = png.GetPixel(a, b)
                    co2 = png2.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    png.SetPixel(a, b, Color.FromArgb((rr + rr2) / 2, (gg + gg2) / 2, (bb + bb2) / 2))
                    b += 1
                Next
                If r2 = a Then
                    Exit For
                End If
                If t2 = b Then
                    Exit For
                End If
                b = 0
                a += 1
            Next
            '   MsgBox("2")
        ElseIf r >= r2 And t >= t2 Then
            For height1 = 1 To t2
                For width1 = 1 To r2
                    co = png.GetPixel(a, b)
                    co2 = png2.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    png.SetPixel(a, b, Color.FromArgb((rr + rr2) / 2, (gg + gg2) / 2, (bb + bb2) / 2))
                    a += 1
                Next
                a = 0
                b += 1
            Next
            '  MsgBox("3")
        Else
            For height1 = 1 To t
                For width1 = 1 To r
                    co = png.GetPixel(a, b)
                    co2 = png2.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    png.SetPixel(a, b, Color.FromArgb((rr + rr2) / 2, (gg + gg2) / 2, (bb + bb2) / 2))
                    a += 1
                Next
                a = 0
                b += 1
            Next
            ' MsgBox("4")
        End If
    End Sub

    Private Sub 切換圖層ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 切換圖層ToolStripMenuItem.Click
        On Error Resume Next
        Dim r As Integer = PictureBox1.Width
        Dim t As Integer = PictureBox1.Height
        Dim r2 As Integer = PictureBox4.Width
        Dim t2 As Integer = PictureBox4.Height
        PictureBox5.Image = PictureBox1.Image
        PictureBox6.Image = PictureBox4.Image
        PictureBox1.Image = PictureBox6.Image
        PictureBox4.Image = PictureBox5.Image
        PictureBox1.Width = r2
        PictureBox1.Height = t2
        PictureBox4.Width = r
        PictureBox4.Height = t
        PictureBox2.Image = PictureBox1.Image
    End Sub

    Private Sub 圖層1ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 圖層1ToolStripMenuItem1.Click
        On Error Resume Next
        MsgBox("注意:使用此軟體儲存圖片會有失真的現象")
        Dim c As Image
        c = PictureBox1.Image
        Dim saveFileDialog As New SaveFileDialog
        saveFileDialog.Filter = "圖片檔 (*.png;*.jpg;*.bmp;*.gif;*.tif)|*.png;*.jpg;*.bmp;*.gif;*.tif"
        If saveFileDialog.ShowDialog = DialogResult.OK And saveFileDialog.FileName.Trim <> "" Then
            c.Save(saveFileDialog.FileName)
        End If
    End Sub

    Private Sub 圖層2ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 圖層2ToolStripMenuItem1.Click
        On Error Resume Next
        MsgBox("注意:使用此軟體儲存圖片會有失真的現象")
        Dim c As Image
        c = PictureBox4.Image
        Dim saveFileDialog As New SaveFileDialog
        saveFileDialog.Filter = "圖片檔 (*.png;*.jpg;*.bmp;*.gif;*.tif)|*.png;*.jpg;*.bmp;*.gif;*.tif"
        If saveFileDialog.ShowDialog = DialogResult.OK And saveFileDialog.FileName.Trim <> "" Then
            c.Save(saveFileDialog.FileName)
            MsgBox("圖片儲存時會有失真的現象，若想要不失真的圖片請用複製圖片的方式")
        End If
    End Sub

    Private Sub 小ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 小ToolStripMenuItem.Click
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
        For height1 = 1 To t / 2 - 1
            For width1 = 1 To r / 2 - 1
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 1, b, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a, b + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 1, b + 1, Color.FromArgb(rr, gg, bb))
                a += 2
            Next
            a = 0
            b += 2
        Next
    End Sub

    Private Sub 中ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 中ToolStripMenuItem.Click
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
        For height1 = 1 To t / 3 - 2
            For width1 = 1 To r / 3 - 2
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 1, b, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 2, b, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a, b + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 1, b + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 2, b + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a, b + 2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 1, b + 2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 2, b + 2, Color.FromArgb(rr, gg, bb))
                a += 3
            Next
            a = 0
            b += 3
        Next
    End Sub

    Private Sub 大ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 大ToolStripMenuItem.Click
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
        For height1 = 1 To t / 4 - 3
            For width1 = 1 To r / 4 - 3
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 1, b, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 2, b, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 3, b, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a, b + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 1, b + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 2, b + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 3, b + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a, b + 2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 1, b + 2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 2, b + 2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 3, b + 2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a, b + 3, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 1, b + 3, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 2, b + 3, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 3, b + 3, Color.FromArgb(rr, gg, bb))
                a += 4
            Next
            a = 0
            b += 4
        Next
    End Sub

    ' Private Sub 蠟筆畫ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 蠟筆畫ToolStripMenuItem1.Click
    '   On Error Resume Next
    'PictureBox2.Image = PictureBox1.Image
    'Dim png As New Bitmap(PictureBox1.Image)
    'PictureBox1.Image = png
    'Dim r As Integer
    'r = PictureBox1.Width
    'Dim t As Integer
    't = PictureBox1.Height
    'Dim width1 As Integer
    'Dim height1 As Integer
    'Dim co As Color
    'Dim rr As integer
    'Dim gg As integer
    'Dim bb As integer
    'Dim a As Integer = 0
    'Dim b As Integer = 0
    'For height1 = 1 To t
    '    For width1 = 1 To r
    '        co = png.GetPixel(a, b)
    '        rr = co.R
    '        gg = co.G
    '        bb = co.B
    '        If rr > gg And rr > bb Then
    '            If rr - gg > 0 And rr - bb > 0 Then
    '                png.SetPixel(a, b, Color.FromArgb(rr + (255 - rr), gg - rr + 255, bb - rr + 255))
    '            End If
    '        End If
    '
    '        If gg > rr And gg > bb Then
    '            If gg - rr > 0 And gg - bb > 0 Then
    '                png.SetPixel(a, b, Color.FromArgb(rr + (255 - gg), 255, bb - gg + 255))
    '            End If
    '        End If
    '
    '        If bb > gg And bb > bb Then
    '            If bb - gg > 0 And bb - rr > 0 Then
    '                png.SetPixel(a, b, Color.FromArgb(rr + (255 - bb), gg - bb + 255, 255))
    '            End If
    '        End If
    '






    'a += 1
    '     Next
    '  a = 0
    '  b += 1
    ' Next
    '  End Sub

    Private Sub 樣式2ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 樣式2ToolStripMenuItem1.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If rr >= gg And rr >= bb Then
                    png.SetPixel(a, b, Color.FromArgb(0, gg, bb))
                ElseIf gg >= rr And gg >= bb Then
                    png.SetPixel(a, b, Color.FromArgb(rr, 0, bb))
                ElseIf bb >= gg And bb >= rr Then
                    png.SetPixel(a, b, Color.FromArgb(rr, gg, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 樣式1ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 樣式1ToolStripMenuItem1.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If rr >= gg And rr >= bb Then
                    png.SetPixel(a, b, Color.FromArgb(255, gg, bb))
                ElseIf gg >= rr And gg >= bb Then
                    png.SetPixel(a, b, Color.FromArgb(rr, 255, bb))
                ElseIf bb >= gg And bb >= rr Then
                    png.SetPixel(a, b, Color.FromArgb(rr, gg, 255))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 樣式3ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 樣式3ToolStripMenuItem1.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If rr <= gg And rr <= bb Then
                    png.SetPixel(a, b, Color.FromArgb(255, gg, bb))
                ElseIf gg <= rr And gg <= bb Then
                    png.SetPixel(a, b, Color.FromArgb(rr, 255, bb))
                ElseIf bb <= gg And bb <= rr Then
                    png.SetPixel(a, b, Color.FromArgb(rr, gg, 255))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 樣式4ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 樣式4ToolStripMenuItem1.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If rr <= gg And rr <= bb Then
                    png.SetPixel(a, b, Color.FromArgb(0, gg, bb))
                ElseIf gg <= rr And gg <= bb Then
                    png.SetPixel(a, b, Color.FromArgb(rr, 0, bb))
                ElseIf bb <= gg And bb <= rr Then
                    png.SetPixel(a, b, Color.FromArgb(rr, gg, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 特大ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 特大ToolStripMenuItem.Click
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
        For height1 = 1 To t / 5 - 4
            For width1 = 1 To r / 5 - 4
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 1, b, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 2, b, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 3, b, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 4, b, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a, b + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 1, b + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 2, b + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 3, b + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 4, b + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a, b + 2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 1, b + 2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 2, b + 2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 3, b + 2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 4, b + 2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a, b + 3, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 1, b + 3, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 2, b + 3, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 3, b + 3, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 4, b + 3, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a, b + 4, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 1, b + 4, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 2, b + 4, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 3, b + 4, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 4, b + 4, Color.FromArgb(rr, gg, bb))
                a += 5
            Next
            a = 0
            b += 5
        Next
    End Sub

    Private Sub 純色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 純色ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        Dim png2 As New Bitmap(PictureBox4.Image)
        PictureBox4.Image = png2
        PictureBox1.Image = png
        Dim r2 As Integer = PictureBox4.Width
        Dim t2 As Integer = PictureBox4.Height
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
        If r2 > r And t2 < t Then
            For height1 = 1 To t
                For width1 = 1 To r
                    If r2 = a + 1 Then
                        Exit For
                    End If
                    If t2 = b + 1 Then
                        Exit For
                    End If
                    co = png.GetPixel(a, b)
                    co2 = png2.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    If rr = 255 And gg = 255 And bb = 255 Then
                        png.SetPixel(a, b, Color.FromArgb(rr2, gg2, bb2))
                    End If

                    a += 1
                Next
                If r2 = a + 1 Then
                    Exit For
                End If
                If t2 = b + 1 Then
                    Exit For
                End If
                a = 0
                b += 1
            Next
            '   MsgBox("1")
        ElseIf r2 < r And t2 > t Then
            For width1 = 1 To r
                For height1 = 1 To t
                    If r2 = a + 1 Then
                        Exit For
                    End If
                    If t2 = b + 1 Then
                        Exit For
                    End If
                    co = png.GetPixel(a, b)
                    co2 = png2.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    If rr = 255 And gg = 255 And bb = 255 Then
                        png.SetPixel(a, b, Color.FromArgb(rr2, gg2, bb2))
                    End If
                    b += 1
                Next
                If r2 = a + 1 Then
                    Exit For
                End If
                If t2 = b + 1 Then
                    Exit For
                End If
                b = 0
                a += 1
            Next
            '   MsgBox("2")
        ElseIf r >= r2 And t >= t2 Then
            For height1 = 1 To t2
                For width1 = 1 To r2
                    co = png.GetPixel(a, b)
                    co2 = png2.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    If rr = 255 And gg = 255 And bb = 255 Then
                        png.SetPixel(a, b, Color.FromArgb(rr2, gg2, bb2))
                    End If
                    a += 1
                Next
                a = 0
                b += 1
            Next
            '  MsgBox("3")
        Else
            For height1 = 1 To t
                For width1 = 1 To r
                    co = png.GetPixel(a, b)
                    co2 = png2.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    If rr = 255 And gg = 255 And bb = 255 Then
                        png.SetPixel(a, b, Color.FromArgb(rr2, gg2, bb2))
                    End If
                    a += 1
                Next
                a = 0
                b += 1
            Next
            ' MsgBox("4")
        End If
    End Sub

    Private Sub 純黑ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 純黑ToolStripMenuItem1.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        Dim png2 As New Bitmap(PictureBox4.Image)
        PictureBox4.Image = png2
        PictureBox1.Image = png
        Dim r2 As Integer = PictureBox4.Width
        Dim t2 As Integer = PictureBox4.Height
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
        If r2 > r And t2 < t Then
            For height1 = 1 To t
                For width1 = 1 To r
                    If r2 = a + 1 Then
                        Exit For
                    End If
                    If t2 = b + 1 Then
                        Exit For
                    End If
                    co = png.GetPixel(a, b)
                    co2 = png2.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    If rr = 0 And gg = 0 And bb = 0 Then
                        png.SetPixel(a, b, Color.FromArgb(rr2, gg2, bb2))
                    End If

                    a += 1
                Next
                If r2 = a + 1 Then
                    Exit For
                End If
                If t2 = b + 1 Then
                    Exit For
                End If
                a = 0
                b += 1
            Next
            '   MsgBox("1")
        ElseIf r2 < r And t2 > t Then
            For width1 = 1 To r
                For height1 = 1 To t
                    If r2 = a + 1 Then
                        Exit For
                    End If
                    If t2 = b + 1 Then
                        Exit For
                    End If
                    co = png.GetPixel(a, b)
                    co2 = png2.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    If rr = 0 And gg = 0 And bb = 0 Then
                        png.SetPixel(a, b, Color.FromArgb(rr2, gg2, bb2))
                    End If
                    b += 1
                Next
                If r2 = a + 1 Then
                    Exit For
                End If
                If t2 = b + 1 Then
                    Exit For
                End If
                b = 0
                a += 1
            Next
            '   MsgBox("2")
        ElseIf r >= r2 And t >= t2 Then
            For height1 = 1 To t2
                For width1 = 1 To r2
                    co = png.GetPixel(a, b)
                    co2 = png2.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    If rr = 0 And gg = 0 And bb = 0 Then
                        png.SetPixel(a, b, Color.FromArgb(rr2, gg2, bb2))
                    End If
                    a += 1
                Next
                a = 0
                b += 1
            Next
            '  MsgBox("3")
        Else
            For height1 = 1 To t
                For width1 = 1 To r
                    co = png.GetPixel(a, b)
                    co2 = png2.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    If rr = 0 And gg = 0 And bb = 0 Then
                        png.SetPixel(a, b, Color.FromArgb(rr2, gg2, bb2))
                    End If
                    a += 1
                Next
                a = 0
                b += 1
            Next
            ' MsgBox("4")
        End If
    End Sub

    Private Sub 偏白ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 偏白ToolStripMenuItem.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 偏黑ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 偏黑ToolStripMenuItem.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(rr / 2, gg / 2, bb / 2))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 大雨ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 大雨ToolStripMenuItem.Click
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
        Dim rr, gg, bb, rr2, rr3, rr4, rr5, rr6, rr7, gg2, gg3, gg4, gg5, gg6, gg7, bb2, bb3, bb4, bb5, bb6, bb7 As Integer
        Dim c As Integer
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim a1, a2, a3, a4, a5, a6, a7 As Color
        For height1 = 1 To t - 6
            For width1 = 1 To r
                a1 = png.GetPixel(a, b)
                a2 = png.GetPixel(a, b + 1)
                a3 = png.GetPixel(a, b + 2)
                a4 = png.GetPixel(a, b + 3)
                a5 = png.GetPixel(a, b + 4)
                a6 = png.GetPixel(a, b + 5)
                a7 = png.GetPixel(a, b + 6)
                c = Int(Rnd() * 20)
                rr = a1.R
                gg = a1.G
                bb = a1.B
                rr2 = a2.R
                gg2 = a2.G
                bb2 = a2.B
                rr3 = a3.R
                gg3 = a3.G
                bb3 = a3.B
                rr4 = a4.R
                gg4 = a4.G
                bb4 = a4.B
                rr5 = a5.R
                gg5 = a5.G
                rr5 = a5.R
                gg6 = a6.G
                bb6 = a6.B
                bb6 = a6.B
                gg7 = a7.G
                bb7 = a7.B
                bb7 = a7.B
                If c = 1 And rr < 245 And gg < 245 And bb < 245 And rr2 < 245 And gg2 < 245 And bb2 < 245 And rr3 < 245 And gg3 < 245 And bb3 < 245 And rr4 < 245 And gg4 < 245 And bb4 < 245 And rr5 < 245 And gg5 < 245 And bb5 < 245 And rr6 < 245 And gg6 < 245 And bb6 < 245 And rr7 < 245 And gg7 < 245 And bb7 < 245 Then
                    png.SetPixel(a, b, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 1, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 2, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 3, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 4, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 5, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 6, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 細雨ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 細雨ToolStripMenuItem.Click
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
        Dim rr, gg, bb, rr2, rr3, rr4, rr5, rr6, rr7, gg2, gg3, gg4, gg5, gg6, gg7, bb2, bb3, bb4, bb5, bb6, bb7 As Integer
        Dim c As Integer
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim a1, a2, a3, a4, a5, a6, a7 As Color
        For height1 = 1 To t - 6
            For width1 = 1 To r
                a1 = png.GetPixel(a, b)
                a2 = png.GetPixel(a, b + 1)
                a3 = png.GetPixel(a, b + 2)
                a4 = png.GetPixel(a, b + 3)
                a5 = png.GetPixel(a, b + 4)
                a6 = png.GetPixel(a, b + 5)
                a7 = png.GetPixel(a, b + 6)
                c = Int(Rnd() * 30)
                rr = a1.R
                gg = a1.G
                bb = a1.B
                rr2 = a2.R
                gg2 = a2.G
                bb2 = a2.B
                rr3 = a3.R
                gg3 = a3.G
                bb3 = a3.B
                rr4 = a4.R
                gg4 = a4.G
                bb4 = a4.B
                rr5 = a5.R
                gg5 = a5.G
                rr5 = a5.R
                gg6 = a6.G
                bb6 = a6.B
                bb6 = a6.B
                gg7 = a7.G
                bb7 = a7.B
                bb7 = a7.B
                If c = 1 And rr < 245 And gg < 245 And bb < 245 And rr2 < 245 And gg2 < 245 And bb2 < 245 And rr3 < 245 And gg3 < 245 And bb3 < 245 And rr4 < 245 And gg4 < 245 And bb4 < 245 And rr5 < 245 And gg5 < 245 And bb5 < 245 And rr6 < 245 And gg6 < 245 And bb6 < 245 And rr7 < 245 And gg7 < 245 And bb7 < 245 Then
                    png.SetPixel(a, b, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 1, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 2, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 3, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 4, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 5, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 6, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 毛毛雨ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 毛毛雨ToolStripMenuItem.Click
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
        Dim rr, gg, bb, rr2, rr3, rr4, rr5, rr6, rr7, gg2, gg3, gg4, gg5, gg6, gg7, bb2, bb3, bb4, bb5, bb6, bb7 As Integer
        Dim c As Integer
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim a1, a2, a3, a4, a5, a6, a7 As Color
        For height1 = 1 To t - 6
            For width1 = 1 To r
                a1 = png.GetPixel(a, b)
                a2 = png.GetPixel(a, b + 1)
                a3 = png.GetPixel(a, b + 2)
                a4 = png.GetPixel(a, b + 3)
                a5 = png.GetPixel(a, b + 4)
                a6 = png.GetPixel(a, b + 5)
                a7 = png.GetPixel(a, b + 6)
                c = Int(Rnd() * 60)
                rr = a1.R
                gg = a1.G
                bb = a1.B
                rr2 = a2.R
                gg2 = a2.G
                bb2 = a2.B
                rr3 = a3.R
                gg3 = a3.G
                bb3 = a3.B
                rr4 = a4.R
                gg4 = a4.G
                bb4 = a4.B
                rr5 = a5.R
                gg5 = a5.G
                rr5 = a5.R
                gg6 = a6.G
                bb6 = a6.B
                bb6 = a6.B
                gg7 = a7.G
                bb7 = a7.B
                bb7 = a7.B
                If c = 1 And rr < 245 And gg < 245 And bb < 245 And rr2 < 245 And gg2 < 245 And bb2 < 245 And rr3 < 245 And gg3 < 245 And bb3 < 245 And rr4 < 245 And gg4 < 245 And bb4 < 245 And rr5 < 245 And gg5 < 245 And bb5 < 245 And rr6 < 245 And gg6 < 245 And bb6 < 245 And rr7 < 245 And gg7 < 245 And bb7 < 245 Then
                    png.SetPixel(a, b, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 1, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 2, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 3, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 4, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 5, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 6, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 傾盆大雨ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 傾盆大雨ToolStripMenuItem.Click
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
        Dim rr, gg, bb, rr2, rr3, rr4, rr5, rr6, rr7, gg2, gg3, gg4, gg5, gg6, gg7, bb2, bb3, bb4, bb5, bb6, bb7 As Integer
        Dim c As Integer
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim a1, a2, a3, a4, a5, a6, a7 As Color
        For height1 = 1 To t - 6
            For width1 = 1 To r
                a1 = png.GetPixel(a, b)
                a2 = png.GetPixel(a, b + 1)
                a3 = png.GetPixel(a, b + 2)
                a4 = png.GetPixel(a, b + 3)
                a5 = png.GetPixel(a, b + 4)
                a6 = png.GetPixel(a, b + 5)
                a7 = png.GetPixel(a, b + 6)
                c = Int(Rnd() * 3)
                rr = a1.R
                gg = a1.G
                bb = a1.B
                rr2 = a2.R
                gg2 = a2.G
                bb2 = a2.B
                rr3 = a3.R
                gg3 = a3.G
                bb3 = a3.B
                rr4 = a4.R
                gg4 = a4.G
                bb4 = a4.B
                rr5 = a5.R
                gg5 = a5.G
                rr5 = a5.R
                gg6 = a6.G
                bb6 = a6.B
                bb6 = a6.B
                gg7 = a7.G
                bb7 = a7.B
                bb7 = a7.B
                If c = 1 And rr < 245 And gg < 245 And bb < 245 And rr2 < 245 And gg2 < 245 And bb2 < 245 And rr3 < 245 And gg3 < 245 And bb3 < 245 And rr4 < 245 And gg4 < 245 And bb4 < 245 And rr5 < 245 And gg5 < 245 And bb5 < 245 And rr6 < 245 And gg6 < 245 And bb6 < 245 And rr7 < 245 And gg7 < 245 And bb7 < 245 Then
                    png.SetPixel(a, b, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 1, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 2, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 3, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 4, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 5, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 6, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub
    Private Sub 毛毛雨ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 毛毛雨ToolStripMenuItem1.Click
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
        Dim rr, gg, bb As Integer
        Dim c As Integer
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim co As Color
        For height1 = 1 To t - 6
            For width1 = 1 To r
                c = Int(Rnd() * 60)
                If c = 5 Then
                    co = png.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    png.SetPixel(a, b, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 1, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 2, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 3, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 4, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 5, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 6, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 細雨ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 細雨ToolStripMenuItem1.Click
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
        Dim rr, gg, bb As Integer
        Dim c As Integer
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim co As Color
        For height1 = 1 To t - 6
            For width1 = 1 To r
                c = Int(Rnd() * 30)
                If c = 5 Then
                    co = png.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    png.SetPixel(a, b, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 1, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 2, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 3, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 4, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 5, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 6, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 傾盆大雨ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 傾盆大雨ToolStripMenuItem1.Click
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
        Dim rr, gg, bb As Integer
        Dim c As Integer
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim co As Color
        For height1 = 1 To t - 6
            For width1 = 1 To r
                c = Int(Rnd() * 5)
                If c = 1 Then
                    co = png.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    png.SetPixel(a, b, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 1, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 2, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 3, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 4, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 5, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 6, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 大雨ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 大雨ToolStripMenuItem1.Click
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
        Dim rr, gg, bb As Integer
        Dim c As Integer
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim co As Color
        For height1 = 1 To t - 6
            For width1 = 1 To r
                c = Int(Rnd() * 20)
                If c = 5 Then
                    co = png.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    png.SetPixel(a, b, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 1, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 2, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 3, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 4, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 5, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 6, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 直條ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 直條ToolStripMenuItem.Click
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
        Dim rr, gg, bb As Integer
        Dim c As Integer
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim a1, a2, a3, a4, a5, a6, a7 As Color
        For height1 = 1 To t - 6
            For width1 = 1 To r
                a1 = png.GetPixel(a, b)
                a2 = png.GetPixel(a, b + 1)
                a3 = png.GetPixel(a, b + 2)
                a4 = png.GetPixel(a, b + 3)
                a5 = png.GetPixel(a, b + 4)
                a6 = png.GetPixel(a, b + 5)
                a7 = png.GetPixel(a, b + 6)
                c = Int(Rnd() * 3)
                rr = a1.R
                gg = a1.G
                bb = a1.B
                If c = 0 Then
                    png.SetPixel(a, b, Color.FromArgb(rr, gg, bb))
                    png.SetPixel(a, b + 1, Color.FromArgb(rr, gg, bb))
                    png.SetPixel(a, b + 2, Color.FromArgb(rr, gg, bb))
                    png.SetPixel(a, b + 3, Color.FromArgb(rr, gg, bb))
                    png.SetPixel(a, b + 4, Color.FromArgb(rr, gg, bb))
                    png.SetPixel(a, b + 5, Color.FromArgb(rr, gg, bb))
                    png.SetPixel(a, b + 6, Color.FromArgb(rr, gg, bb))
                End If

                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 檢查更新ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 檢查更新ToolStripMenuItem.Click
        Shell("cmd.exe /c start " & "http://birdeggsblogger1.blogspot.tw/p/blog-page_24.html")
    End Sub

    Private Sub 增加綠色ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 增加綠色ToolStripMenuItem1.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(rr, (255 + gg) / 2, bb))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 減少綠色ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 減少綠色ToolStripMenuItem1.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb((255 + rr) / 2, gg, (255 + bb) / 2))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 增加紅色ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 增加紅色ToolStripMenuItem1.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb((255 + rr) / 2, gg, bb))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 增加黃色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 增加黃色ToolStripMenuItem.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(rr, (255 + gg) / 2, (255 + bb) / 2))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 增加藍色ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 增加藍色ToolStripMenuItem1.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(rr, gg, (255 + bb) / 2))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 增加黃色ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 增加黃色ToolStripMenuItem1.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, bb))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub
    Private Sub 模糊ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 模糊ToolStripMenuItem.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim co1 As Color
        Dim co2 As Color
        Dim co3 As Color
        Dim co4 As Color
        Dim rr2, rr1, rr3, rr4 As Integer
        Dim gg2, gg1, gg3, gg4 As Integer
        Dim bb2, bb1, bb3, bb4 As Integer
        Dim a As Integer = 5
        Dim b As Integer = 5
        For height1 = 1 To t - 10
            For width1 = 1 To r - 10
                co = png.GetPixel(a, b)
                co1 = png.GetPixel(a + 5, b)
                co2 = png.GetPixel(a + 5, b + 5)
                co3 = png.GetPixel(a, b - 5)
                co4 = png.GetPixel(a - 5, b)
                rr = co.R
                gg = co.G
                bb = co.B
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                rr1 = co1.R
                gg1 = co1.G
                bb1 = co1.B
                rr3 = co3.R
                gg3 = co3.G
                bb3 = co3.B
                rr4 = co4.R
                gg4 = co4.G
                bb4 = co4.B
                png.SetPixel(a, b, Color.FromArgb((rr1 + rr2 + rr3 + rr4) / 4, (gg1 + gg2 + gg3 + gg4) / 4, (bb1 + bb2 + bb3 + bb4) / 4))
                a += 1
            Next
            a = 5
            b += 1
        Next
    End Sub
    Private Sub 六色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 六色ToolStripMenuItem.Click
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
                If rr + gg + bb >= 750 Then
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                ElseIf rr + gg + bb >= 600 Then
                    png.SetPixel(a, b, Color.FromArgb(200, 200, 200))
                ElseIf rr + gg + bb >= 450 Then
                    png.SetPixel(a, b, Color.FromArgb(150, 150, 150))
                ElseIf rr + gg + bb >= 300 Then
                    png.SetPixel(a, b, Color.FromArgb(100, 100, 100))
                ElseIf rr + gg + bb >= 150 Then
                    png.SetPixel(a, b, Color.FromArgb(50, 50, 50))
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If

                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 雙色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 雙色ToolStripMenuItem.Click
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
                If rr + gg + bb >= 381 Then
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If

                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 四色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 四色ToolStripMenuItem.Click
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
                If rr + gg + bb >= 750 Then
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                ElseIf rr + gg + bb >= 510 Then
                    png.SetPixel(a, b, Color.FromArgb(170, 170, 170))
                ElseIf rr + gg + bb >= 255 Then
                    png.SetPixel(a, b, Color.FromArgb(85, 85, 85))
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If

                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 檢視版本ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 檢視版本ToolStripMenuItem.Click
        MsgBox("此軟體的版本為2.5")
    End Sub
    Private Sub 磁磚ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 磁磚ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        Dim png2 As New Bitmap(PictureBox5.Image)
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
                If rr + gg + bb >= 750 Then
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                ElseIf rr + gg + bb >= 600 Then
                    png.SetPixel(a, b, Color.FromArgb(200, 200, 200))
                ElseIf rr + gg + bb >= 450 Then
                    png.SetPixel(a, b, Color.FromArgb(150, 150, 150))
                ElseIf rr + gg + bb >= 300 Then
                    png.SetPixel(a, b, Color.FromArgb(100, 100, 100))
                ElseIf rr + gg + bb >= 150 Then
                    png.SetPixel(a, b, Color.FromArgb(50, 50, 50))
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        a = 0
        b = 0
        Dim a1 As Integer = 0
        Dim b1 As Integer = 0
        Dim co2, co3 As Color
        Dim rr2, gg2, bb2, rr3, gg3, bb3 As Integer
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
                co3 = png2.GetPixel(a1, b1)
                rr3 = co3.R
                gg3 = co3.G
                bb3 = co3.B
                If a = 0 Then
                    a1 = a
                    b1 = b
                End If
                If co = co2 Then
                    png.SetPixel(a, b, Color.FromArgb(rr3, gg3, bb3))
                Else
                    a1 = a + 1
                    b1 = b
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub
    Private Sub 十色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 十色ToolStripMenuItem.Click
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
                If rr + gg + bb >= 675 Then
                    png.SetPixel(a, b, Color.FromArgb(225, 225, 225))
                ElseIf rr + gg + bb >= 600 Then
                    png.SetPixel(a, b, Color.FromArgb(200, 200, 200))
                ElseIf rr + gg + bb >= 525 Then
                    png.SetPixel(a, b, Color.FromArgb(175, 175, 175))
                ElseIf rr + gg + bb >= 450 Then
                    png.SetPixel(a, b, Color.FromArgb(150, 150, 150))
                ElseIf rr + gg + bb >= 375 Then
                    png.SetPixel(a, b, Color.FromArgb(125, 125, 125))
                ElseIf rr + gg + bb >= 300 Then
                    png.SetPixel(a, b, Color.FromArgb(100, 100, 100))
                ElseIf rr + gg + bb >= 225 Then
                    png.SetPixel(a, b, Color.FromArgb(75, 75, 75))
                ElseIf rr + gg + bb >= 150 Then
                    png.SetPixel(a, b, Color.FromArgb(50, 50, 50))
                ElseIf rr + gg + bb >= 75 Then
                    png.SetPixel(a, b, Color.FromArgb(25, 25, 25))
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub
    Private Sub 噴槍ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 噴槍ToolStripMenuItem.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim c As Integer
        Dim co1 As Color
        Dim co2 As Color
        Dim co3 As Color
        Dim co4 As Color
        Dim rr2, rr1, rr3, rr4 As Integer
        Dim gg2, gg1, gg3, gg4 As Integer
        Dim bb2, bb1, bb3, bb4 As Integer
        Dim a As Integer = 5
        Dim b As Integer = 5
        For height1 = 1 To t - 10
            For width1 = 1 To r - 10
                co = png.GetPixel(a, b)
                co1 = png.GetPixel(a + 5, b)
                co2 = png.GetPixel(a + 5, b + 5)
                co3 = png.GetPixel(a, b - 5)
                co4 = png.GetPixel(a - 5, b)
                rr = co.R
                gg = co.G
                bb = co.B
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                rr1 = co1.R
                gg1 = co1.G
                bb1 = co1.B
                rr3 = co3.R
                gg3 = co3.G
                bb3 = co3.B
                rr4 = co4.R
                gg4 = co4.G
                bb4 = co4.B
                c = Int(Rnd() * 4)
                If c = 0 Then
                    png.SetPixel(a, b, Color.FromArgb(rr1, gg1, bb1))
                ElseIf c = 1 Then
                    png.SetPixel(a, b, Color.FromArgb(rr2, gg2, bb2))
                ElseIf c = 2 Then
                    png.SetPixel(a, b, Color.FromArgb(rr3, gg3, bb3))
                ElseIf c = 3 Then
                    png.SetPixel(a, b, Color.FromArgb(rr4, gg4, bb4))
                End If
                a += 1
            Next
            a = 5
            b += 1
        Next
    End Sub

    Private Sub 色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 色ToolStripMenuItem.Click
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
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                '  If rr >= 200 And gg - bb <= 50 And gg >= 110 And gg <= 175 And bb >= 70 And bb <= 150 Then
                '      png.SetPixel(a, b, Color.FromArgb(235, 167, 135))
                '  ElseIf rr >= 200 And gg - bb <= 25 And gg - bb >= 5 And gg >= 160 And gg <= 230 And bb >= 130 And bb <= 220 Then
                '      png.SetPixel(a, b, Color.FromArgb(253, 213, 195))
                '  Else
                If rr >= 210 Then
                    If gg >= 210 Then
                        If bb >= 210 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 0))
                        End If
                    End If
                ElseIf rr >= 180 Then
                    If gg >= 240 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 0))
                        End If
                    End If
                ElseIf rr >= 120 Then
                    If gg >= 240 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 0))
                        End If
                    End If
                ElseIf rr >= 60 Then
                    If gg >= 240 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 0))
                        End If
                    End If
                Else
                    If gg >= 240 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                        End If
                    End If
                End If
                '  End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

 
    Private Sub 樣式1ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 樣式1ToolStripMenuItem2.Click
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
                If rr + gg + bb >= 750 Then
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                ElseIf rr + gg + bb >= 510 Then
                    png.SetPixel(a, b, Color.FromArgb(170, 170, 170))
                ElseIf rr + gg + bb >= 255 Then
                    png.SetPixel(a, b, Color.FromArgb(85, 85, 85))
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        a = 1
        b = 1
        Dim co2 As Color
        Dim rr2, gg2, bb2 As Integer
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
                If co = co2 Then
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                    png.SetPixel(a - 1, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 樣式2ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 樣式2ToolStripMenuItem2.Click
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
                If rr + gg + bb >= 750 Then
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                ElseIf rr + gg + bb >= 600 Then
                    png.SetPixel(a, b, Color.FromArgb(200, 200, 200))
                ElseIf rr + gg + bb >= 450 Then
                    png.SetPixel(a, b, Color.FromArgb(150, 150, 150))
                ElseIf rr + gg + bb >= 300 Then
                    png.SetPixel(a, b, Color.FromArgb(100, 100, 100))
                ElseIf rr + gg + bb >= 150 Then
                    png.SetPixel(a, b, Color.FromArgb(50, 50, 50))
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        a = 1
        b = 1
        Dim co2 As Color
        Dim rr2, gg2, bb2 As Integer
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
                If co = co2 Then
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                    png.SetPixel(a - 1, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 樣式3ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 樣式3ToolStripMenuItem2.Click
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
                If rr + gg + bb >= 675 Then
                    png.SetPixel(a, b, Color.FromArgb(225, 225, 225))
                ElseIf rr + gg + bb >= 600 Then
                    png.SetPixel(a, b, Color.FromArgb(200, 200, 200))
                ElseIf rr + gg + bb >= 525 Then
                    png.SetPixel(a, b, Color.FromArgb(175, 175, 175))
                ElseIf rr + gg + bb >= 450 Then
                    png.SetPixel(a, b, Color.FromArgb(150, 150, 150))
                ElseIf rr + gg + bb >= 375 Then
                    png.SetPixel(a, b, Color.FromArgb(125, 125, 125))
                ElseIf rr + gg + bb >= 300 Then
                    png.SetPixel(a, b, Color.FromArgb(100, 100, 100))
                ElseIf rr + gg + bb >= 225 Then
                    png.SetPixel(a, b, Color.FromArgb(75, 75, 75))
                ElseIf rr + gg + bb >= 150 Then
                    png.SetPixel(a, b, Color.FromArgb(50, 50, 50))
                ElseIf rr + gg + bb >= 75 Then
                    png.SetPixel(a, b, Color.FromArgb(25, 25, 25))
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        a = 1
        b = 1
        Dim co2 As Color
        Dim rr2, gg2, bb2 As Integer
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
                If co = co2 Then
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                    png.SetPixel(a - 1, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 簡單色調ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 簡單色調ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox5.Image = PictureBox1.Image
        Dim png2 As New Bitmap(PictureBox5.Image)
        PictureBox1.Image = png
        PictureBox5.Image = png2
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
                If rr + gg + bb >= 675 Then
                    png.SetPixel(a, b, Color.FromArgb(225, 225, 225))
                ElseIf rr + gg + bb >= 600 Then
                    png.SetPixel(a, b, Color.FromArgb(200, 200, 200))
                ElseIf rr + gg + bb >= 525 Then
                    png.SetPixel(a, b, Color.FromArgb(175, 175, 175))
                ElseIf rr + gg + bb >= 450 Then
                    png.SetPixel(a, b, Color.FromArgb(150, 150, 150))
                ElseIf rr + gg + bb >= 375 Then
                    png.SetPixel(a, b, Color.FromArgb(125, 125, 125))
                ElseIf rr + gg + bb >= 300 Then
                    png.SetPixel(a, b, Color.FromArgb(100, 100, 100))
                ElseIf rr + gg + bb >= 225 Then
                    png.SetPixel(a, b, Color.FromArgb(75, 75, 75))
                ElseIf rr + gg + bb >= 150 Then
                    png.SetPixel(a, b, Color.FromArgb(50, 50, 50))
                ElseIf rr + gg + bb >= 75 Then
                    png.SetPixel(a, b, Color.FromArgb(25, 25, 25))
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        a = 0
        b = 0
        Dim a1 As Integer = 0
        Dim co2 As Color
        Dim rr2, gg2, bb2 As Integer
        Dim b1 As Integer = 0
        Dim ttt, rrr As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png2.GetPixel(a, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If rr + gg + bb = 675 Then
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr + gg + bb = 675 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                ElseIf rr + gg + bb = 600 Then
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr + gg + bb = 600 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                ElseIf rr + gg + bb = 525 Then
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr + gg + bb = 525 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                ElseIf rr + gg + bb = 450 Then
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr + gg + bb = 450 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                ElseIf rr + gg + bb = 375 Then
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr + gg + bb = 375 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                ElseIf rr + gg + bb = 300 Then
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr + gg + bb = 300 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                ElseIf rr + gg + bb = 225 Then
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr + gg + bb = 225 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                ElseIf rr + gg + bb = 150 Then
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr + gg + bb = 150 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                ElseIf rr + gg + bb = 75 Then
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr + gg + bb = 75 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                ElseIf rr + gg + bb = 0 Then

                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr + gg + bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub
    Private Sub 玻璃ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 玻璃ToolStripMenuItem.Click
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim c As Integer
        Dim co1 As Color
        Dim co2 As Color
        Dim co3 As Color
        Dim co4 As Color
        Dim rr2, rr1, rr3, rr4 As Integer
        Dim gg2, gg1, gg3, gg4 As Integer
        Dim bb2, bb1, bb3, bb4 As Integer
        Dim a As Integer = 5
        Dim b As Integer = 5
        Dim i As Integer
        For i = 1 To 3
            For height1 = 1 To t - 10
                For width1 = 1 To r - 10
                    co = png.GetPixel(a, b)
                    co1 = png.GetPixel(a + 5, b)
                    co2 = png.GetPixel(a + 5, b + 5)
                    co3 = png.GetPixel(a, b - 5)
                    co4 = png.GetPixel(a - 5, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    rr1 = co1.R
                    gg1 = co1.G
                    bb1 = co1.B
                    rr3 = co3.R
                    gg3 = co3.G
                    bb3 = co3.B
                    rr4 = co4.R
                    gg4 = co4.G
                    bb4 = co4.B
                    c = Int(Rnd() * 4)
                    If c = 0 Then
                        png.SetPixel(a, b, Color.FromArgb(rr1, gg1, bb1))
                    ElseIf c = 1 Then
                        png.SetPixel(a, b, Color.FromArgb(rr2, gg2, bb2))
                    ElseIf c = 2 Then
                        png.SetPixel(a, b, Color.FromArgb(rr3, gg3, bb3))
                    ElseIf c = 3 Then
                        png.SetPixel(a, b, Color.FromArgb(rr4, gg4, bb4))
                    End If
                    a += 1
                Next
                a = 5
                b += 1
            Next
            a = 5
            b = 5
        Next
        For i = 1 To 3
            a = 5
            b = 5
            For height1 = 1 To t - 10
                For width1 = 1 To r - 10
                    co = png.GetPixel(a, b)
                    co1 = png.GetPixel(a + 5, b)
                    co2 = png.GetPixel(a + 5, b + 5)
                    co3 = png.GetPixel(a, b - 5)
                    co4 = png.GetPixel(a - 5, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    rr1 = co1.R
                    gg1 = co1.G
                    bb1 = co1.B
                    rr3 = co3.R
                    gg3 = co3.G
                    bb3 = co3.B
                    rr4 = co4.R
                    gg4 = co4.G
                    bb4 = co4.B
                    png.SetPixel(a, b, Color.FromArgb((rr1 + rr2 + rr3 + rr4) / 4, (gg1 + gg2 + gg3 + gg4) / 4, (bb1 + bb2 + bb3 + bb4) / 4))
                    a += 1
                Next
                a = 5
                b += 1
            Next
        Next
    End Sub
    Private Sub 模糊()
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
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim co1 As Color
        Dim co2 As Color
        Dim co3 As Color
        Dim co4 As Color
        Dim rr2, rr1, rr3, rr4 As Integer
        Dim gg2, gg1, gg3, gg4 As Integer
        Dim bb2, bb1, bb3, bb4 As Integer
        Dim a As Integer = 5
        Dim b As Integer = 5
        For height1 = 1 To t - 10
            For width1 = 1 To r - 10
                co = png.GetPixel(a, b)
                co1 = png.GetPixel(a + 5, b)
                co2 = png.GetPixel(a + 5, b + 5)
                co3 = png.GetPixel(a, b - 5)
                co4 = png.GetPixel(a - 5, b)
                rr = co.R
                gg = co.G
                bb = co.B
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                rr1 = co1.R
                gg1 = co1.G
                bb1 = co1.B
                rr3 = co3.R
                gg3 = co3.G
                bb3 = co3.B
                rr4 = co4.R
                gg4 = co4.G
                bb4 = co4.B
                png.SetPixel(a, b, Color.FromArgb((rr1 + rr2 + rr3 + rr4) / 4, (gg1 + gg2 + gg3 + gg4) / 4, (bb1 + bb2 + bb3 + bb4) / 4))
                a += 1
            Next
            a = 5
            b += 1
        Next
    End Sub

    Private Sub 自訂色彩ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 自訂色彩ToolStripMenuItem.Click
        PictureBox2.Image = PictureBox1.Image
        PictureBox1.Left = 200
        PictureBox4.Left = 200
        TrackBar1.Show()
        TrackBar2.Show()
        TrackBar3.Show()
        Button1.Show()
        Label1.Show()
        Label2.Show()
        Label3.Show()
        Button2.Show()
        PictureBox5.Image = PictureBox1.Image
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        PictureBox1.Image = PictureBox5.Image
        Dim png As New Bitmap(PictureBox1.Image)
        Dim png2 As New Bitmap(PictureBox5.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png2.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb((TrackBar1.Value + rr) / 2, (TrackBar2.Value + gg) / 2, (TrackBar3.Value + bb) / 2))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TrackBar1.Hide()
        TrackBar2.Hide()
        TrackBar3.Hide()
        Button1.Hide()
        Label1.Hide()
        Label2.Hide()
        Label3.Hide()
        Button2.Hide()
        PictureBox1.Left = 12
        PictureBox4.Left = 12
    End Sub

    Private Sub 樣式2ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 樣式2ToolStripMenuItem3.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        Dim png2 As New Bitmap(PictureBox5.Image)
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
                If rr + gg + bb >= 750 Then
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                ElseIf rr + gg + bb >= 600 Then
                    png.SetPixel(a, b, Color.FromArgb(200, 200, 200))
                ElseIf rr + gg + bb >= 450 Then
                    png.SetPixel(a, b, Color.FromArgb(150, 150, 150))
                ElseIf rr + gg + bb >= 300 Then
                    png.SetPixel(a, b, Color.FromArgb(100, 100, 100))
                ElseIf rr + gg + bb >= 150 Then
                    png.SetPixel(a, b, Color.FromArgb(50, 50, 50))
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        a = 0
        b = 0
        Dim a1 As Integer = 0
        Dim b1 As Integer = 0
        Dim co2, co3 As Color
        Dim rr2, gg2, bb2, rr3, gg3, bb3 As Integer
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
                co3 = png2.GetPixel(a1, b1)
                rr3 = co3.R
                gg3 = co3.G
                bb3 = co3.B
                If a = 0 Then
                    a1 = a
                    b1 = b
                End If
                If co = co2 Then
                    png.SetPixel(a + 1, b, Color.FromArgb(rr3, gg3, bb3))
                Else
                    a1 = a + 1
                    b1 = b
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 樣式1ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 樣式1ToolStripMenuItem3.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        Dim png2 As New Bitmap(PictureBox5.Image)
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
                If rr >= 210 Then
                    If gg >= 210 Then
                        If bb >= 210 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 0))
                        End If
                    End If
                ElseIf rr >= 180 Then
                    If gg >= 240 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 0))
                        End If
                    End If
                ElseIf rr >= 120 Then
                    If gg >= 240 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 0))
                        End If
                    End If
                ElseIf rr >= 60 Then
                    If gg >= 240 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 0))
                        End If
                    End If
                Else
                    If gg >= 240 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                        End If
                    End If
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        a = 0
        b = 0
        Dim a1 As Integer = 0
        Dim b1 As Integer = 0
        Dim co2, co3 As Color
        Dim rr2, gg2, bb2, rr3, gg3, bb3 As Integer
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
                co3 = png2.GetPixel(a1, b1)
                rr3 = co3.R
                gg3 = co3.G
                bb3 = co3.B
                If a = 0 Then
                    a1 = a
                    b1 = b
                End If
                If co = co2 Then
                    png.SetPixel(a + 1, b, Color.FromArgb(rr3, gg3, bb3))
                Else
                    a1 = a + 1
                    b1 = b
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub
    Private Sub 雜訊變色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 雜訊變色ToolStripMenuItem.Click
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
        Dim c As Integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c = Int(Rnd() * 6)
                If c = 0 Then
                    png.SetPixel(a, b, Color.FromArgb(rr, gg, bb))
                ElseIf c = 1 Then
                    png.SetPixel(a, b, Color.FromArgb(gg, rr, bb))
                ElseIf c = 2 Then
                    png.SetPixel(a, b, Color.FromArgb(bb, gg, rr))
                ElseIf c = 3 Then
                    png.SetPixel(a, b, Color.FromArgb(bb, rr, gg))
                ElseIf c = 4 Then
                    png.SetPixel(a, b, Color.FromArgb(rr, bb, gg))
                ElseIf c = 5 Then
                    png.SetPixel(a, b, Color.FromArgb(bb, gg, rr))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub
    Private Sub 樣式3含輪廓ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 樣式3含輪廓ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
        PictureBox5.Size = PictureBox1.Size
        PictureBox6.Image = PictureBox1.Image
        PictureBox6.Size = PictureBox1.Size
        Dim png As New Bitmap(PictureBox1.Image)
        Dim png2 As New Bitmap(PictureBox5.Image)
        Dim png3 As New Bitmap(PictureBox6.Image)
        PictureBox1.Image = png
        Dim r2 As Integer = PictureBox1.Width
        Dim t2 As Integer = PictureBox1.Height
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
                If rr >= 210 Then
                    If gg >= 210 Then
                        If bb >= 210 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 0))
                        End If
                    End If
                ElseIf rr >= 180 Then
                    If gg >= 240 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 0))
                        End If
                    End If
                ElseIf rr >= 120 Then
                    If gg >= 240 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 0))
                        End If
                    End If
                ElseIf rr >= 60 Then
                    If gg >= 240 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 0))
                        End If
                    End If
                Else
                    If gg >= 240 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                        End If
                    End If
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        a = 0
        b = 0
        Dim a1 As Integer = 0
        Dim b1 As Integer = 0
        Dim co2, co3 As Color
        Dim rr2, gg2, bb2, rr3, gg3, bb3 As Integer
        For height1 = 1 To t - 1
            For width1 = 1 To r - 1
                co = png2.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png2.GetPixel(a + 1, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                co3 = png3.GetPixel(a1, b1)
                rr3 = co3.R
                gg3 = co3.G
                bb3 = co3.B
                If a = 0 Then
                    a1 = a
                    b1 = b
                End If
                If co = co2 Then
                    png2.SetPixel(a + 1, b, Color.FromArgb(rr3, gg3, bb3))
                Else
                    a1 = a + 1
                    b1 = b
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        a = 0
        b = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png2.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If rr + gg + bb >= 675 Then
                    png2.SetPixel(a, b, Color.FromArgb(225, 225, 225))
                ElseIf rr + gg + bb >= 600 Then
                    png2.SetPixel(a, b, Color.FromArgb(200, 200, 200))
                ElseIf rr + gg + bb >= 525 Then
                    png2.SetPixel(a, b, Color.FromArgb(175, 175, 175))
                ElseIf rr + gg + bb >= 450 Then
                    png2.SetPixel(a, b, Color.FromArgb(150, 150, 150))
                ElseIf rr + gg + bb >= 375 Then
                    png2.SetPixel(a, b, Color.FromArgb(125, 125, 125))
                ElseIf rr + gg + bb >= 300 Then
                    png2.SetPixel(a, b, Color.FromArgb(100, 100, 100))
                ElseIf rr + gg + bb >= 225 Then
                    png2.SetPixel(a, b, Color.FromArgb(75, 75, 75))
                ElseIf rr + gg + bb >= 150 Then
                    png2.SetPixel(a, b, Color.FromArgb(50, 50, 50))
                ElseIf rr + gg + bb >= 75 Then
                    png2.SetPixel(a, b, Color.FromArgb(25, 25, 25))
                Else
                    png2.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        a = 2
        b = 2
        For height1 = 1 To t - 3
            For width1 = 1 To r - 3
                co = png2.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png2.GetPixel(a + 1, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If co = co2 Then
                    'png2.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                Else
                    png2.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        a = 0
        b = 0



        If r2 > r And t2 < t Then
            For height1 = 1 To t
                For width1 = 1 To r
                    If r2 = a Then
                        Exit For
                    End If
                    If t2 = b Then
                        Exit For
                    End If
                    co = png.GetPixel(a, b)
                    co2 = png2.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    png.SetPixel(a, b, Color.FromArgb((rr + rr2) / 2, (gg + gg2) / 2, (bb + bb2) / 2))
                    a += 1
                Next
                If r2 = a Then
                    Exit For
                End If
                If t2 = b Then
                    Exit For
                End If
                a = 0
                b += 1
            Next
            '   MsgBox("1")
        ElseIf r2 < r And t2 > t Then
            For width1 = 1 To r
                For height1 = 1 To t
                    If r2 = a Then
                        Exit For
                    End If
                    If t2 = b Then
                        Exit For
                    End If
                    co = png.GetPixel(a, b)
                    co2 = png2.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    png.SetPixel(a, b, Color.FromArgb((rr + rr2) / 2, (gg + gg2) / 2, (bb + bb2) / 2))
                    b += 1
                Next
                If r2 = a Then
                    Exit For
                End If
                If t2 = b Then
                    Exit For
                End If
                b = 0
                a += 1
            Next
            '   MsgBox("2")
        ElseIf r >= r2 And t >= t2 Then
            For height1 = 1 To t2
                For width1 = 1 To r2
                    co = png.GetPixel(a, b)
                    co2 = png2.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    png.SetPixel(a, b, Color.FromArgb((rr + rr2) / 2, (gg + gg2) / 2, (bb + bb2) / 2))
                    a += 1
                Next
                a = 0
                b += 1
            Next
            '  MsgBox("3")
        Else
            For height1 = 1 To t
                For width1 = 1 To r
                    co = png.GetPixel(a, b)
                    co2 = png2.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    png.SetPixel(a, b, Color.FromArgb((rr + rr2) / 2, (gg + gg2) / 2, (bb + bb2) / 2))
                    a += 1
                Next
                a = 0
                b += 1
            Next
            ' MsgBox("4")
        End If
        PictureBox5.Width = 5
        PictureBox5.Height = 5
        PictureBox6.Width = 5
        PictureBox6.Height = 5
    End Sub

    Private Sub 普通ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 普通ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width - 5
        Dim t As Integer
        t = PictureBox1.Height - 5
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        For c3 = 1 To r * t
            c1 = Int(Rnd() * (r - 2) + 3)
            c2 = Int(Rnd() * (t - 2) + 3)
            co = png.GetPixel(c1, c2)
            rr = co.R
            gg = co.G
            bb = co.B
            png.SetPixel(c1, c2 - 2, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 - 1, c2 - 1, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 + 1, c2 - 1, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1, c2 - 1, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 - 1, c2, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 - 2, c2, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1, c2, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 + 1, c2, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 + 2, c2, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1, c2 + 1, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 + 1, c2 + 1, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 - 1, c2 + 1, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1, c2 + 2, Color.FromArgb(rr, gg, bb))
        Next
    End Sub

    Private Sub 輕微ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 輕微ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        PictureBox5.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        Dim png2 As New Bitmap(PictureBox5.Image)
        PictureBox5.Image = png2
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width - 5
        Dim t As Integer
        t = PictureBox1.Height - 5
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        For c3 = 1 To r * t
            c1 = Int(Rnd() * (r - 2) + 3)
            c2 = Int(Rnd() * (t - 2) + 3)
            co = png2.GetPixel(c1, c2)
            rr = co.R
            gg = co.G
            bb = co.B
            png.SetPixel(c1, c2 - 2, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 - 1, c2 - 1, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 + 1, c2 - 1, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1, c2 - 1, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 - 1, c2, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 - 2, c2, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1, c2, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 + 1, c2, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 + 2, c2, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1, c2 + 1, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 + 1, c2 + 1, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 - 1, c2 + 1, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1, c2 + 2, Color.FromArgb(rr, gg, bb))
        Next
    End Sub
    Private Sub 簡單色調2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 簡單色調2ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox5.Image = PictureBox1.Image
        Dim png2 As New Bitmap(PictureBox5.Image)
        PictureBox1.Image = png
        PictureBox5.Image = png2
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
                If rr >= 210 Then
                    If gg >= 210 Then
                        If bb >= 210 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(240, 0, 0))
                        End If
                    End If
                ElseIf rr >= 180 Then
                    If gg >= 240 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(180, 0, 0))
                        End If
                    End If
                ElseIf rr >= 120 Then
                    If gg >= 240 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(120, 0, 0))
                        End If
                    End If
                ElseIf rr >= 60 Then
                    If gg >= 240 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(60, 0, 0))
                        End If
                    End If
                Else
                    If gg >= 240 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 240, 0))
                        End If
                    ElseIf gg >= 180 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 180, 0))
                        End If
                    ElseIf gg >= 120 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 120, 0))
                        End If
                    ElseIf gg >= 60 Then
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 60, 0))
                        End If
                    Else
                        If bb >= 240 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 240))
                        ElseIf bb >= 180 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 180))
                        ElseIf bb >= 120 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 120))
                        ElseIf bb >= 60 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 60))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                        End If
                    End If
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        a = 0
        b = 0
        Dim a1 As Integer = 0
        Dim co2, co1 As Color
        Dim rr2, gg2, bb2 As Integer
        Dim b1 As Integer = 0
        Dim ttt, rrr As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png2.GetPixel(a, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                If rr = 0 And gg = 0 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 0 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 0 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 0 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 0 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 0 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 0 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 0 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 0 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 0 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 60 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 60 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 60 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 60 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 60 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 60 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 60 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 60 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 60 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 60 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 120 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 120 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 120 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 120 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 120 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 120 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 120 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 120 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 120 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 120 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 180 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 180 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 180 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 180 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 180 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 180 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 180 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 180 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 180 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 180 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 240 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 240 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 240 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 240 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 240 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 240 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 240 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 240 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 0 And gg = 240 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 0 And gg = 240 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If

                If rr = 60 And gg = 0 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 0 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 0 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 0 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 0 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 0 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 0 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 0 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 0 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 0 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 60 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 60 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 60 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 60 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 60 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 60 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 60 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 60 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 60 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 60 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 120 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 120 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 120 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 120 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 120 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 120 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 120 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 120 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 120 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 120 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 180 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 180 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 180 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 180 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 180 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 180 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 180 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 180 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 180 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 180 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 240 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 240 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 240 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 240 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 240 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 240 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 240 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 240 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 60 And gg = 240 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 60 And gg = 240 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If

                If rr = 120 And gg = 0 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 0 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 0 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 0 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 0 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 0 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 0 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 0 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 0 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 0 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 60 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 60 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 60 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 60 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 60 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 60 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 60 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 60 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 60 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 60 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 120 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 120 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 120 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 120 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 120 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 120 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 120 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 120 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 120 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 120 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 180 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 180 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 180 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 180 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 180 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 180 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 180 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 180 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 180 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 180 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 240 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 240 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 240 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 240 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 240 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 240 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 240 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 240 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 120 And gg = 240 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 120 And gg = 240 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If

                If rr = 180 And gg = 0 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 0 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 0 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 0 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 0 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 0 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 0 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 0 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 0 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 0 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 60 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 60 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 60 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 60 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 60 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 60 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 60 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 60 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 60 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 60 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 120 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 120 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 120 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 120 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 120 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 120 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 120 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 120 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 120 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 120 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 180 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 180 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 180 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 180 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 180 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 180 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 180 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 180 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 180 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 180 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 240 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 240 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 240 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 240 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 240 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 240 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 240 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 240 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 180 And gg = 240 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 180 And gg = 240 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If

                If rr = 240 And gg = 0 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 0 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 0 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 0 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 0 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 0 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 0 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 0 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 0 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 0 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 60 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 60 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 60 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 60 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 60 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 60 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 60 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 60 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 60 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 60 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 120 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 120 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 120 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 120 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 120 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 120 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 120 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 120 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 120 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 120 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 180 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 180 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 180 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 180 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 180 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 180 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 180 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 180 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 180 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 180 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 240 And bb = 0 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 240 And bb = 0 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 240 And bb = 60 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 240 And bb = 60 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 240 And bb = 120 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 240 And bb = 120 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 240 And bb = 180 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 240 And bb = 180 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                If rr = 240 And gg = 240 And bb = 240 Then
                    co1 = png.GetPixel(a1, b1)
                    For ttt = 1 To t
                        For rrr = 1 To r
                            co = png.GetPixel(a1, b1)
                            rr = co.R
                            gg = co.G
                            bb = co.B
                            If rr = 240 And gg = 240 And bb = 240 Then
                                png.SetPixel(a1, b1, Color.FromArgb(rr2, gg2, bb2))
                            End If
                            a1 += 1
                        Next
                        a1 = 0
                        b1 += 1
                    Next
                    a1 = 0
                    b1 = 0
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub
    Private Sub 淺ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 淺ToolStripMenuItem.Click
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
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If rr >= 170 Then
                    If gg >= 170 Then
                        If bb >= 170 Then
                            png.SetPixel(a, b, Color.FromArgb(255, 255, 255))

                        ElseIf bb >= 85 Then
                            png.SetPixel(a, b, Color.FromArgb(255, 255, 170))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(255, 255, 85))
                        End If
                    ElseIf gg >= 85 Then
                        If bb >= 170 Then
                            png.SetPixel(a, b, Color.FromArgb(255, 170, 255))
                        ElseIf bb >= 85 Then
                            png.SetPixel(a, b, Color.FromArgb(255, 170, 170))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(255, 170, 85))
                        End If
                    Else
                        If bb >= 170 Then
                            png.SetPixel(a, b, Color.FromArgb(255, 85, 255))
                        ElseIf bb >= 85 Then
                            png.SetPixel(a, b, Color.FromArgb(255, 85, 170))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(255, 85, 85))
                        End If
                    End If
                ElseIf rr >= 85 Then
                    If gg >= 170 Then
                        If bb >= 170 Then
                            png.SetPixel(a, b, Color.FromArgb(170, 255, 255))

                        ElseIf bb >= 85 Then
                            png.SetPixel(a, b, Color.FromArgb(170, 255, 170))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(170, 255, 85))
                        End If
                    ElseIf gg >= 85 Then
                        If bb >= 170 Then
                            png.SetPixel(a, b, Color.FromArgb(170, 170, 255))
                        ElseIf bb >= 85 Then
                            png.SetPixel(a, b, Color.FromArgb(170, 170, 170))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(170, 170, 85))
                        End If
                    Else
                        If bb >= 170 Then
                            png.SetPixel(a, b, Color.FromArgb(170, 85, 255))
                        ElseIf bb >= 85 Then
                            png.SetPixel(a, b, Color.FromArgb(170, 85, 170))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(170, 85, 85))
                        End If
                    End If
                Else
                    If gg >= 170 Then
                        If bb >= 170 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 170, 170))
                        ElseIf bb >= 85 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 170, 85))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 170, 0))
                        End If
                    ElseIf gg >= 85 Then
                        If bb >= 170 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 85, 170))
                        ElseIf bb >= 85 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 85, 85))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 85, 0))
                        End If
                    Else
                        If bb >= 170 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 170))
                        ElseIf bb >= 85 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 85))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                        End If
                    End If
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 深ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 深ToolStripMenuItem.Click
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
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If rr >= 170 Then
                    If gg >= 170 Then
                        If bb >= 170 Then
                            png.SetPixel(a, b, Color.FromArgb(170, 170, 170))

                        ElseIf bb >= 85 Then
                            png.SetPixel(a, b, Color.FromArgb(170, 170, 85))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(170, 170, 0))
                        End If
                    ElseIf gg >= 85 Then
                        If bb >= 170 Then
                            png.SetPixel(a, b, Color.FromArgb(170, 85, 170))
                        ElseIf bb >= 85 Then
                            png.SetPixel(a, b, Color.FromArgb(170, 85, 85))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(170, 85, 0))
                        End If
                    Else
                        If bb >= 170 Then
                            png.SetPixel(a, b, Color.FromArgb(170, 0, 170))
                        ElseIf bb >= 85 Then
                            png.SetPixel(a, b, Color.FromArgb(170, 0, 85))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(170, 0, 0))
                        End If
                    End If
                ElseIf rr >= 85 Then
                    If gg >= 170 Then
                        If bb >= 170 Then
                            png.SetPixel(a, b, Color.FromArgb(85, 170, 170))

                        ElseIf bb >= 85 Then
                            png.SetPixel(a, b, Color.FromArgb(85, 170, 85))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(85, 170, 0))
                        End If
                    ElseIf gg >= 85 Then
                        If bb >= 170 Then
                            png.SetPixel(a, b, Color.FromArgb(85, 85, 170))
                        ElseIf bb >= 85 Then
                            png.SetPixel(a, b, Color.FromArgb(85, 85, 85))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(85, 85, 0))
                        End If
                    Else
                        If bb >= 170 Then
                            png.SetPixel(a, b, Color.FromArgb(85, 0, 170))
                        ElseIf bb >= 85 Then
                            png.SetPixel(a, b, Color.FromArgb(85, 0, 85))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(85, 0, 0))
                        End If
                    End If
                Else
                    If gg >= 170 Then
                        If bb >= 170 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 170, 170))
                        ElseIf bb >= 85 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 170, 85))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 170, 0))
                        End If
                    ElseIf gg >= 85 Then
                        If bb >= 170 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 85, 170))
                        ElseIf bb >= 85 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 85, 85))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 85, 0))
                        End If
                    Else
                        If bb >= 170 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 170))
                        ElseIf bb >= 85 Then
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 85))
                        Else
                            png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                        End If
                    End If
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub
    Private Sub 顏色異常2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 顏色異常2ToolStripMenuItem.Click
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
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If rr >= 127 And gg >= 127 And bb >= 127 Then
                    png.SetPixel(a, b, Color.FromArgb(rr - 127, gg - 127, bb - 127))
                ElseIf rr >= 127 And gg >= 127 And bb < 127 Then
                    png.SetPixel(a, b, Color.FromArgb(rr - 127, gg - 127, bb + 127))
                ElseIf rr >= 127 And gg < 127 And bb >= 127 Then
                    png.SetPixel(a, b, Color.FromArgb(rr - 127, gg + 127, bb - 127))
                ElseIf rr >= 127 And gg < 127 And bb < 127 Then
                    png.SetPixel(a, b, Color.FromArgb(rr - 127, gg + 127, bb + 127))
                ElseIf rr < 127 And gg >= 127 And bb >= 127 Then
                    png.SetPixel(a, b, Color.FromArgb(rr + 127, gg - 127, bb - 127))
                ElseIf rr < 127 And gg >= 127 And bb < 127 Then
                    png.SetPixel(a, b, Color.FromArgb(rr + 127, gg - 127, bb + 127))
                ElseIf rr < 127 And gg < 127 And bb >= 127 Then
                    png.SetPixel(a, b, Color.FromArgb(rr + 127, gg + 127, bb - 127))
                ElseIf rr < 127 And gg < 127 And bb < 127 Then
                    png.SetPixel(a, b, Color.FromArgb(rr + 127, gg + 127, bb + 127))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 樣式2ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 樣式2ToolStripMenuItem4.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        Dim png2 As New Bitmap(PictureBox2.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim rr, gg, bb, rr2, rr3, rr4, rr5, rr6, rr7, gg2, gg3, gg4, gg5, gg6, gg7, bb2, bb3, bb4, bb5, bb6, bb7 As Integer
        Dim c As Integer
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim co, co2 As Color
        Dim a1, a2, a3, a4, a5, a6, a7 As Color
        For height1 = 1 To t - 6
            For width1 = 1 To r
                a1 = png.GetPixel(a, b)
                a2 = png.GetPixel(a, b + 1)
                a3 = png.GetPixel(a, b + 2)
                a4 = png.GetPixel(a, b + 3)
                a5 = png.GetPixel(a, b + 4)
                a6 = png.GetPixel(a, b + 5)
                a7 = png.GetPixel(a, b + 6)
                c = Int(Rnd() * 3)
                rr = a1.R
                gg = a1.G
                bb = a1.B
                rr2 = a2.R
                gg2 = a2.G
                bb2 = a2.B
                rr3 = a3.R
                gg3 = a3.G
                bb3 = a3.B
                rr4 = a4.R
                gg4 = a4.G
                bb4 = a4.B
                rr5 = a5.R
                gg5 = a5.G
                rr5 = a5.R
                gg6 = a6.G
                bb6 = a6.B
                bb6 = a6.B
                gg7 = a7.G
                bb7 = a7.B
                bb7 = a7.B
                If c = 1 And rr < 245 And gg < 245 And bb < 245 And rr2 < 245 And gg2 < 245 And bb2 < 245 And rr3 < 245 And gg3 < 245 And bb3 < 245 And rr4 < 245 And gg4 < 245 And bb4 < 245 And rr5 < 245 And gg5 < 245 And bb5 < 245 And rr6 < 245 And gg6 < 245 And bb6 < 245 And rr7 < 245 And gg7 < 245 And bb7 < 245 Then
                    png.SetPixel(a, b, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 1, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 2, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 3, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 4, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 5, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                    png.SetPixel(a, b + 6, Color.FromArgb(rr + 10, gg + 10, bb + 10))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        a = 0
        b = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png2.GetPixel(a, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                png.SetPixel(a, b, Color.FromArgb((rr + rr2) / 2, (gg + gg2) / 2, (bb + bb2) / 2))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 樣式1ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 樣式1ToolStripMenuItem4.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        Dim png2 As New Bitmap(PictureBox2.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim rr, gg, bb, rr2, gg2, bb2 As Integer
        Dim c As Integer
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim co, co2 As Color
        For height1 = 1 To t - 6
            For width1 = 1 To r
                c = Int(Rnd() * 5)
                If c = 1 Then
                    co = png.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    png.SetPixel(a, b, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 1, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 2, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 3, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 4, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 5, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 6, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        a = 0
        b = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png2.GetPixel(a, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                png.SetPixel(a, b, Color.FromArgb((rr + rr2) / 2, (gg + gg2) / 2, (bb + bb2) / 2))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub
    Private Sub 雜訊變色2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 雜訊變色2ToolStripMenuItem.Click
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
        Dim c As Integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                c = Int(Rnd() * 6)
                If c = 0 Or c = 1 Or c = 2 Then
                    png.SetPixel(a, b, Color.FromArgb(rr, gg, bb))
                ElseIf c = 1 Then
                    png.SetPixel(a, b, Color.FromArgb(gg, rr, bb))
                ElseIf c = 2 Then
                    png.SetPixel(a, b, Color.FromArgb(bb, gg, rr))
                ElseIf c = 3 Then
                    png.SetPixel(a, b, Color.FromArgb(bb, rr, gg))
                ElseIf c = 4 Then
                    png.SetPixel(a, b, Color.FromArgb(rr, bb, gg))
                ElseIf c = 5 Then
                    png.SetPixel(a, b, Color.FromArgb(bb, gg, rr))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub
    Private Sub 交錯ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 交錯ToolStripMenuItem1.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width - 5
        Dim t As Integer
        t = PictureBox1.Height - 5
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co As Color
        Dim rr As integer
        Dim gg As integer
        Dim bb As integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c As Integer
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        For c3 = 1 To t * r
            c1 = Int(Rnd() * (r - 2) + 3)
            c2 = Int(Rnd() * (t - 2) + 3)
            c = Int(Rnd() * 2)
            co = png.GetPixel(c1, c2)
            rr = co.R
            gg = co.G
            bb = co.B
            If c = 0 Then
                png.SetPixel(c1, c2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(c1 + 1, c2 + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(c1 + 2, c2 + 2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(c1 - 1, c2 - 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(c1 - 2, c2 - 2, Color.FromArgb(rr, gg, bb))
            Else
                png.SetPixel(c1 - 1, c2 + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(c1 - 2, c2 + 2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(c1, c2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(c1 + 1, c2 - 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(c1 + 2, c2 - 2, Color.FromArgb(rr, gg, bb))
            End If
        Next
    End Sub

    Private Sub 降低彩度ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 降低彩度ToolStripMenuItem1.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        Dim png2 As New Bitmap(PictureBox2.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co, co2 As Color
        Dim rr, rr2 As Integer
        Dim gg, gg2 As Integer
        Dim bb, bb2 As Integer
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
        a = 0
        b = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png2.GetPixel(a, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                png.SetPixel(a, b, Color.FromArgb((rr + rr2) / 2, (gg + gg2) / 2, (bb + bb2) / 2))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 烏面ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 烏面ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        Dim png2 As New Bitmap(PictureBox2.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim co, co2 As Color
        Dim rr, rr2, gg, gg2, bb, bb2 As Integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If rr >= gg And gg >= bb Then
                    png.SetPixel(a, b, Color.FromArgb(rr - bb, rr - bb, rr - bb))
                ElseIf rr >= bb And bb >= gg Then
                    png.SetPixel(a, b, Color.FromArgb(rr - gg, rr - gg, rr - gg))
                ElseIf gg >= rr And rr >= bb Then
                    png.SetPixel(a, b, Color.FromArgb(gg - bb, gg - bb, gg - bb))
                ElseIf gg >= bb And bb >= rr Then
                    png.SetPixel(a, b, Color.FromArgb(gg - rr, gg - rr, gg - rr))
                ElseIf bb >= rr And rr >= gg Then
                    png.SetPixel(a, b, Color.FromArgb(bb - gg, bb - gg, bb - gg))
                ElseIf bb >= gg And gg >= rr Then
                    png.SetPixel(a, b, Color.FromArgb(bb - rr, bb - rr, bb - rr))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        a = 0
        b = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png2.GetPixel(a, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                png.SetPixel(a, b, Color.FromArgb((rr + rr2) / 2, (gg + gg2) / 2, (bb + bb2) / 2))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 雜訊ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 雜訊ToolStripMenuItem1.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        Dim png2 As New Bitmap(PictureBox2.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim height1 As Integer
        Dim a As Integer = 0
        Dim co, co2 As Color
        Dim rr, rr2, gg, gg2, bb, bb2 As Integer
        Dim b As Integer = 0
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        For height1 = 1 To t
            For width1 = 1 To r
                c1 = Int(Rnd() * 240)
                c2 = Int(Rnd() * 240)
                c3 = Int(Rnd() * 240)
                png.SetPixel(a, b, Color.FromArgb(c1, c2, c3))
                a += 1
            Next
            a = 0
            b += 1
        Next
        a = 0
        b = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png2.GetPixel(a, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                png.SetPixel(a, b, Color.FromArgb((rr + rr2) / 2, (gg + gg2) / 2, (bb + bb2) / 2))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 朦朧ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 朦朧ToolStripMenuItem1.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        Dim png2 As New Bitmap(PictureBox2.Image)
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
        Dim z As Integer
        Dim co1 As Color
        Dim co2 As Color
        Dim co3 As Color
        Dim co4 As Color
        Dim rr2, rr1, rr3, rr4 As Integer
        Dim gg2, gg1, gg3, gg4 As Integer
        Dim bb2, bb1, bb3, bb4 As Integer
        Dim a As Integer = 5
        Dim b As Integer = 5
        For z = 1 To 6
            For height1 = 1 To t - 10
                For width1 = 1 To r - 10
                    co = png.GetPixel(a, b)
                    co1 = png.GetPixel(a + 5, b)
                    co2 = png.GetPixel(a + 5, b + 5)
                    co3 = png.GetPixel(a, b - 5)
                    co4 = png.GetPixel(a - 5, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    rr1 = co1.R
                    gg1 = co1.G
                    bb1 = co1.B
                    rr3 = co3.R
                    gg3 = co3.G
                    bb3 = co3.B
                    rr4 = co4.R
                    gg4 = co4.G
                    bb4 = co4.B
                    png.SetPixel(a, b, Color.FromArgb((rr1 + rr2 + rr3 + rr4) / 4, (gg1 + gg2 + gg3 + gg4) / 4, (bb1 + bb2 + bb3 + bb4) / 4))
                    a += 1
                Next
                a = 5
                b += 1
            Next
            a = 5
            b = 5
        Next
        a = 0
        b = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png2.GetPixel(a, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                png.SetPixel(a, b, Color.FromArgb((rr + rr2) / 2, (gg + gg2) / 2, (bb + bb2) / 2))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub
    Private Sub 拼圖ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 拼圖ToolStripMenuItem1.Click
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
        Dim c As Integer
        Dim co1 As Color
        Dim co2 As Color
        Dim co3 As Color
        Dim co4 As Color
        Dim rr2, rr1, rr3, rr4 As Integer
        Dim gg2, gg1, gg3, gg4 As Integer
        Dim bb2, bb1, bb3, bb4 As Integer
        Dim a As Integer = 5
        Dim b As Integer = 5
        Dim z As Integer
        For z = 1 To 5
            For height1 = 1 To t - 10
                For width1 = 1 To r - 10
                    co = png.GetPixel(a, b)
                    co1 = png.GetPixel(a + 5, b)
                    co2 = png.GetPixel(a + 5, b + 5)
                    co3 = png.GetPixel(a, b - 5)
                    co4 = png.GetPixel(a - 5, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    rr1 = co1.R
                    gg1 = co1.G
                    bb1 = co1.B
                    rr3 = co3.R
                    gg3 = co3.G
                    bb3 = co3.B
                    rr4 = co4.R
                    gg4 = co4.G
                    bb4 = co4.B
                    c = Int(Rnd() * 4)
                    If c = 0 Then
                        png.SetPixel(a, b, Color.FromArgb(rr1, gg1, bb1))
                    ElseIf c = 1 Then
                        png.SetPixel(a, b, Color.FromArgb(rr2, gg2, bb2))
                    ElseIf c = 2 Then
                        png.SetPixel(a, b, Color.FromArgb(rr3, gg3, bb3))
                    ElseIf c = 3 Then
                        png.SetPixel(a, b, Color.FromArgb(rr4, gg4, bb4))
                    End If
                    a += 1
                Next
                a = 5
                b += 1
            Next
            a = 5
            b = 5
        Next
        a = 0
        b = 0
        For height1 = 1 To t / 5 - 4
            For width1 = 1 To r / 5 - 4
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                png.SetPixel(a, b, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 1, b, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 2, b, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 3, b, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 4, b, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a, b + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 1, b + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 2, b + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 3, b + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 4, b + 1, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a, b + 2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 1, b + 2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 2, b + 2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 3, b + 2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 4, b + 2, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a, b + 3, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 1, b + 3, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 2, b + 3, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 3, b + 3, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 4, b + 3, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a, b + 4, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 1, b + 4, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 2, b + 4, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 3, b + 4, Color.FromArgb(rr, gg, bb))
                png.SetPixel(a + 4, b + 4, Color.FromArgb(rr, gg, bb))
                a += 5
            Next
            a = 0
            b += 5
        Next
    End Sub

    Private Sub 扭曲ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 扭曲ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        Dim png2 As New Bitmap(PictureBox2.Image)
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
        Dim co1 As Color
        Dim co2 As Color
        Dim co3 As Color
        Dim co4 As Color
        Dim rr2, rr1, rr3, rr4 As Integer
        Dim gg2, gg1, gg3, gg4 As Integer
        Dim bb2, bb1, bb3, bb4 As Integer
        Dim a As Integer = 5
        Dim b As Integer = 5
        Dim z As Integer
        For z = 1 To 4
            For height1 = 1 To t - 10
                For width1 = 1 To r - 10
                    co = png.GetPixel(a, b)
                    co1 = png.GetPixel(a + 5, b)
                    co2 = png.GetPixel(a + 5, b + 5)
                    co3 = png.GetPixel(a, b - 5)
                    co4 = png.GetPixel(a - 5, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    rr2 = co2.R
                    gg2 = co2.G
                    bb2 = co2.B
                    rr1 = co1.R
                    gg1 = co1.G
                    bb1 = co1.B
                    rr3 = co3.R
                    gg3 = co3.G
                    bb3 = co3.B
                    rr4 = co4.R
                    gg4 = co4.G
                    bb4 = co4.B
                    png.SetPixel(a, b, Color.FromArgb((rr1 + rr2 + rr3 + rr4) / 4, (gg1 + gg2 + gg3 + gg4) / 4, (bb1 + bb2 + bb3 + bb4) / 4))
                    a += 1
                Next
                a = 5
                b += 1
            Next
            a = 5
            b = 5
        Next
        a = 0
        b = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                If rr + gg + bb >= 750 Then
                    png.SetPixel(a, b, Color.FromArgb(255, 255, 255))
                ElseIf rr + gg + bb >= 600 Then
                    png.SetPixel(a, b, Color.FromArgb(200, 200, 200))
                ElseIf rr + gg + bb >= 450 Then
                    png.SetPixel(a, b, Color.FromArgb(150, 150, 150))
                ElseIf rr + gg + bb >= 300 Then
                    png.SetPixel(a, b, Color.FromArgb(100, 100, 100))
                ElseIf rr + gg + bb >= 150 Then
                    png.SetPixel(a, b, Color.FromArgb(50, 50, 50))
                Else
                    png.SetPixel(a, b, Color.FromArgb(0, 0, 0))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        a = 0
        b = 0
        Dim a1 As Integer = 0
        Dim b1 As Integer = 0
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
                co3 = png2.GetPixel(a1, b1)
                rr3 = co3.R
                gg3 = co3.G
                bb3 = co3.B
                If a = 0 Then
                    a1 = a
                    b1 = b
                End If
                If co = co2 Then
                    png.SetPixel(a, b, Color.FromArgb(rr3, gg3, bb3))
                Else
                    png.SetPixel(a, b, Color.FromArgb(rr3, gg3, bb3))
                    a1 = a + 1
                    b1 = b
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 細網ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 細網ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox2.Image = PictureBox1.Image
        Dim png As New Bitmap(PictureBox1.Image)
        Dim png2 As New Bitmap(PictureBox2.Image)
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
        a = 0
        b = 0
        For height1 = 1 To t
            For width1 = 1 To r
                co = png.GetPixel(a, b)
                rr = co.R
                gg = co.G
                bb = co.B
                co2 = png2.GetPixel(a, b)
                rr2 = co2.R
                gg2 = co2.G
                bb2 = co2.B
                png.SetPixel(a, b, Color.FromArgb((rr + rr2) / 2, (gg + gg2) / 2, (bb + bb2) / 2))
                a += 1
            Next
            a = 0
            b += 1
        Next
    End Sub

    Private Sub 碎片ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 碎片ToolStripMenuItem.Click
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
        Dim rr, gg, bb As Integer
        Dim c As Integer
        Dim c1 As Integer
        Dim c2 As Integer
        Dim c3 As Integer
        Dim co As Color
        For height1 = 1 To t - 6
            For width1 = 1 To r
                c = Int(Rnd() * 5)
                If c = 1 Then
                    co = png.GetPixel(a, b)
                    rr = co.R
                    gg = co.G
                    bb = co.B
                    png.SetPixel(a, b, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 1, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 2, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 3, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 4, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 5, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                    png.SetPixel(a, b + 6, Color.FromArgb((255 + rr) / 2, (255 + gg) / 2, (255 + bb) / 2))
                End If
                a += 1
            Next
            a = 0
            b += 1
        Next
        a = 0
        b = 0
        r = PictureBox1.Width - 5
        t = PictureBox1.Height - 5
        For c3 = 1 To r * t
            c1 = Int(Rnd() * (r - 2) + 3)
            c2 = Int(Rnd() * (t - 2) + 3)
            co = png.GetPixel(c1, c2)
            rr = co.R
            gg = co.G
            bb = co.B
            png.SetPixel(c1, c2 - 2, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 - 1, c2 - 1, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 + 1, c2 - 1, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1, c2 - 1, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 - 1, c2, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 - 2, c2, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1, c2, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 + 1, c2, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 + 2, c2, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1, c2 + 1, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 + 1, c2 + 1, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1 - 1, c2 + 1, Color.FromArgb(rr, gg, bb))
            png.SetPixel(c1, c2 + 2, Color.FromArgb(rr, gg, bb))
        Next
    End Sub
End Class
