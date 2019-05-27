Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form32
    Private Sub Form32_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "簡化程度"
            Label2.Text = "顏料量"
            Button1.Text = "確定"
            Me.Text = "油畫"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "Simplification"
            Label2.Text = "pigment"
            Button1.Text = "determine"
            Me.Text = "oil painting"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "簡素化"
            Label2.Text = "顔料の量"
            Button1.Text = "決定します"
            Me.Text = "油絵"
        End If
        Button1.BackColor = Form1.BackColor
        Me.BackColor = Form1.BackColor
        Me.ForeColor = Form1.ForeColor
        PictureBox1.Image = Form1.PictureBox1.Image
        PictureBox2.Image = Form1.PictureBox1.Image
        PictureBox3.Image = Form1.PictureBox1.Image
        Dim a As New Bitmap(PictureBox1.Image)
        PictureBox1.Size = New Size(Form1.PictureBox1.Width, Form1.PictureBox1.Height)
        PictureBox2.Size = New Size(a.Width, a.Height)
        PictureBox3.Size = New Size(a.Width, a.Height)
        Me.Width = a.Width + 500
        Me.Height = a.Height + 500
        PictureBox2.Left = -200
        PictureBox2.Hide()
        PictureBox3.Hide()
        Button2.Left = -200
    End Sub
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Dim anti_alias As Boolean = True
        Dim mbitmap As Bitmap
        mbitmap = New Bitmap(PictureBox2.Image)
        PictureBox2.Image = mbitmap
        Dim wid As Integer = CInt(PictureBox2.Width / TrackBar1.Value)
        Dim hgt As Integer = CInt(PictureBox2.Height / TrackBar1.Value)
        Dim rBitmap As New Bitmap(wid, hgt)
        Dim gr As Graphics = Graphics.FromImage(rBitmap)
        If anti_alias Then gr.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBilinear
        gr.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        gr.DrawImage(mbitmap, 0, 0, wid - 1, hgt - 1)
        PictureBox3.Image = rBitmap
        PictureBox3.Size = New Size(wid, hgt)
        Button2.PerformClick()
        System.GC.Collect()
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Integer
        Dim tra As Integer = TrackBar1.Value
        Dim tra2 As Integer = TrackBar2.Value
        Dim rgb(255) As Integer
        For ii = 0 To 255
            For i = 0 To 255 Step 255 / tra2
                If ii > i Then rgb(ii) = i
            Next
        Next
        Try
            mbitmap = New Bitmap(PictureBox1.Image)
            Width = mbitmap.Width
            Height = mbitmap.Height
            Dim rect As New Rectangle(0, 0, Width, Height)
            Dim bmpData As BitmapData = mbitmap.LockBits(rect, ImageLockMode.ReadWrite, mbitmap.PixelFormat)
            Dim ptr As IntPtr = bmpData.Scan0
            Dim bytes As Integer = bmpData.Stride * Height
            With bmpData
            End With
            Dim Bpx As Byte = bmpData.Stride \ mbitmap.Width
            Dim rgbValues(bytes - 1) As Byte
            Marshal.Copy(ptr, rgbValues, 0, bytes)
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                rgbValues(k) = rgb(rgbValues(k))
                rgbValues(k + 1) = rgb(rgbValues(k + 1))
                rgbValues(k + 2) = rgb(rgbValues(k + 2))
            Next
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mbitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mbitmap
        System.GC.Collect()
        PictureBox1.Size = New Size(Form1.PictureBox1.Width, Form1.PictureBox1.Height)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim anti_alias As Boolean = True
        Dim mbitmap As Bitmap
        mbitmap = New Bitmap(PictureBox3.Image)
        PictureBox3.Image = mbitmap
        Dim wid As Integer = CInt(PictureBox2.Width)
        Dim hgt As Integer = CInt(PictureBox2.Height)
        Dim rBitmap As New Bitmap(wid, hgt)
        Dim gr As Graphics = Graphics.FromImage(rBitmap)
        If anti_alias Then gr.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBilinear
        gr.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        gr.DrawImage(mbitmap, 0, 0, wid - 1, hgt - 1)
        PictureBox1.Image = rBitmap
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.re2(Form1.re02) = Form1.PictureBox1.Image
        Form1.re02 += 1
        Form1.PictureBox1.Image = PictureBox1.Image
        Me.Close()
    End Sub
    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        Dim anti_alias As Boolean = True
        Dim mbitmap As Bitmap
        mbitmap = New Bitmap(PictureBox2.Image)
        PictureBox2.Image = mbitmap
        Dim wid As Integer = CInt(PictureBox2.Width / TrackBar1.Value)
        Dim hgt As Integer = CInt(PictureBox2.Height / TrackBar1.Value)
        Dim rBitmap As New Bitmap(wid, hgt)
        Dim gr As Graphics = Graphics.FromImage(rBitmap)
        If anti_alias Then gr.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBilinear
        gr.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        gr.DrawImage(mbitmap, 0, 0, wid - 1, hgt - 1)
        PictureBox3.Image = rBitmap
        PictureBox3.Size = New Size(wid, hgt)
        Button2.PerformClick()
        System.GC.Collect()
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Integer
        Dim tra As Integer = TrackBar1.Value
        Dim tra2 As Integer = TrackBar2.Value
        Dim rgb(255) As Integer
        For ii = 0 To 255
            For i = 0 To 255 Step 255 / tra2
                If ii > i Then rgb(ii) = i
            Next
        Next
        Try
            mbitmap = New Bitmap(PictureBox1.Image)
            Width = mbitmap.Width
            Height = mbitmap.Height
            Dim rect As New Rectangle(0, 0, Width, Height)
            Dim bmpData As BitmapData = mbitmap.LockBits(rect, ImageLockMode.ReadWrite, mbitmap.PixelFormat)
            Dim ptr As IntPtr = bmpData.Scan0
            Dim bytes As Integer = bmpData.Stride * Height
            With bmpData
            End With
            Dim Bpx As Byte = bmpData.Stride \ mbitmap.Width
            Dim rgbValues(bytes - 1) As Byte
            Marshal.Copy(ptr, rgbValues, 0, bytes)
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                rgbValues(k) = rgb(rgbValues(k))
                rgbValues(k + 1) = rgb(rgbValues(k + 1))
                rgbValues(k + 2) = rgb(rgbValues(k + 2))
            Next
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mbitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mbitmap
        System.GC.Collect()
        PictureBox1.Size = New Size(Form1.PictureBox1.Width, Form1.PictureBox1.Height)
    End Sub
End Class