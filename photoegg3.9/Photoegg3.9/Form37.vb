Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form37
    Private Sub Form37_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Me.Text = "色域調整"
            Button1.Text = "確定"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Me.Text = "Color gamut adjustment"
            Button1.Text = "determine"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Me.Text = "域調整"
            Button1.Text = "決定します"
        End If
        Me.BackColor = Form1.BackColor
        Me.ForeColor = Form1.ForeColor
        Button1.BackColor = Form1.BackColor
        PictureBox1.Image = Form1.PictureBox1.Image
        PictureBox2.Image = Form1.PictureBox1.Image
        Dim a As New Bitmap(PictureBox1.Image)
        PictureBox1.Size = New Size(Form1.PictureBox1.Width, Form1.PictureBox1.Height)
        Me.Width = a.Width + 500
        Me.Height = a.Height + 500
        PictureBox2.Left = -200
    End Sub
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        If TrackBar2.Value < TrackBar1.Value Then TrackBar2.Value = TrackBar1.Value
        Dim tra As Byte = TrackBar1.Value
        Dim tra2 As Byte = TrackBar2.Value
        Dim tra3 As Byte = TrackBar3.Value
        Dim tra4 As Byte = TrackBar4.Value
        Dim tra5 As Byte = TrackBar5.Value
        Dim tra6 As Byte = TrackBar6.Value
        Dim r(255), g(255), b(255) As Byte
        Dim i As Single
        For i = 0 To 255
            b(i) = tra5 + (i * ((tra6 - tra5) / 255))
            g(i) = tra3 + (i * ((tra4 - tra3) / 255))
            r(i) = tra + (i * ((tra2 - tra) / 255))
        Next
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Single
        Dim mBitmap As Bitmap
        Try
            mBitmap = New Bitmap(PictureBox2.Image)
            Width = mBitmap.Width
            Height = mBitmap.Height
            Dim rect As New Rectangle(0, 0, Width, Height)
            Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
            Dim ptr As IntPtr = bmpData.Scan0
            Dim bytes As Integer = bmpData.Stride * Height
            Dim Bpx As Byte = bmpData.Stride \ mBitmap.Width
            Dim rgbValues(bytes - 1) As Byte
            Marshal.Copy(ptr, rgbValues, 0, bytes)
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                rgbValues(k) = b(rgbValues(k))
                rgbValues(k + 1) = g(rgbValues(k + 1))
                rgbValues(k + 2) = r(rgbValues(k + 2))
            Next
            Marshal.Copy(rgbValues, 0, ptr, bytes)
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
        System.GC.Collect()
    End Sub
    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        If TrackBar4.Value < TrackBar3.Value Then TrackBar4.Value = TrackBar3.Value
        Dim tra As Byte = TrackBar1.Value
        Dim tra2 As Byte = TrackBar2.Value
        Dim tra3 As Byte = TrackBar3.Value
        Dim tra4 As Byte = TrackBar4.Value
        Dim tra5 As Byte = TrackBar5.Value
        Dim tra6 As Byte = TrackBar6.Value
        Dim r(255), g(255), b(255) As Byte
        Dim i As Single
        For i = 0 To 255
            b(i) = tra5 + (i * ((tra6 - tra5) / 255))
            g(i) = tra3 + (i * ((tra4 - tra3) / 255))
            r(i) = tra + (i * ((tra2 - tra) / 255))
        Next
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Single
        Dim mBitmap As Bitmap
        Try
            mBitmap = New Bitmap(PictureBox2.Image)
            Width = mBitmap.Width
            Height = mBitmap.Height
            Dim rect As New Rectangle(0, 0, Width, Height)
            Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
            Dim ptr As IntPtr = bmpData.Scan0
            Dim bytes As Integer = bmpData.Stride * Height
            Dim Bpx As Byte = bmpData.Stride \ mBitmap.Width
            Dim rgbValues(bytes - 1) As Byte
            Marshal.Copy(ptr, rgbValues, 0, bytes)
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                rgbValues(k) = b(rgbValues(k))
                rgbValues(k + 1) = g(rgbValues(k + 1))
                rgbValues(k + 2) = r(rgbValues(k + 2))
            Next
            Marshal.Copy(rgbValues, 0, ptr, bytes)
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
        System.GC.Collect()
    End Sub
    Private Sub TrackBar5_Scroll(sender As Object, e As EventArgs) Handles TrackBar5.Scroll
        If TrackBar6.Value < TrackBar5.Value Then TrackBar6.Value = TrackBar5.Value
        Dim tra As Byte = TrackBar1.Value
        Dim tra2 As Byte = TrackBar2.Value
        Dim tra3 As Byte = TrackBar3.Value
        Dim tra4 As Byte = TrackBar4.Value
        Dim tra5 As Byte = TrackBar5.Value
        Dim tra6 As Byte = TrackBar6.Value
        Dim r(255), g(255), b(255) As Byte
        Dim i As Single
        For i = 0 To 255
            b(i) = tra5 + (i * ((tra6 - tra5) / 255))
            g(i) = tra3 + (i * ((tra4 - tra3) / 255))
            r(i) = tra + (i * ((tra2 - tra) / 255))
        Next
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Single
        Dim mBitmap As Bitmap
        Try
            mBitmap = New Bitmap(PictureBox2.Image)
            Width = mBitmap.Width
            Height = mBitmap.Height
            Dim rect As New Rectangle(0, 0, Width, Height)
            Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
            Dim ptr As IntPtr = bmpData.Scan0
            Dim bytes As Integer = bmpData.Stride * Height
            Dim Bpx As Byte = bmpData.Stride \ mBitmap.Width
            Dim rgbValues(bytes - 1) As Byte
            Marshal.Copy(ptr, rgbValues, 0, bytes)
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                rgbValues(k) = b(rgbValues(k))
                rgbValues(k + 1) = g(rgbValues(k + 1))
                rgbValues(k + 2) = r(rgbValues(k + 2))
            Next
            Marshal.Copy(rgbValues, 0, ptr, bytes)
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
        System.GC.Collect()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.re2(Form1.re02) = Form1.PictureBox1.Image
        Form1.re02 += 1
        Form1.PictureBox1.Image = PictureBox1.Image
        Me.Close()
    End Sub
    Private Sub TrackBar2_Scroll_1(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        If TrackBar1.Value > TrackBar2.Value Then TrackBar1.Value = TrackBar2.Value
        Dim tra As Byte = TrackBar1.Value
        Dim tra2 As Byte = TrackBar2.Value
        Dim tra3 As Byte = TrackBar3.Value
        Dim tra4 As Byte = TrackBar4.Value
        Dim tra5 As Byte = TrackBar5.Value
        Dim tra6 As Byte = TrackBar6.Value
        Dim r(255), g(255), b(255) As Byte
        Dim i As Single
        For i = 0 To 255
            b(i) = tra5 + (i * ((tra6 - tra5) / 255))
            g(i) = tra3 + (i * ((tra4 - tra3) / 255))
            r(i) = tra + (i * ((tra2 - tra) / 255))
        Next
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Single
        Dim mBitmap As Bitmap
        Try
            mBitmap = New Bitmap(PictureBox2.Image)
            Width = mBitmap.Width
            Height = mBitmap.Height
            Dim rect As New Rectangle(0, 0, Width, Height)
            Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
            Dim ptr As IntPtr = bmpData.Scan0
            Dim bytes As Integer = bmpData.Stride * Height
            Dim Bpx As Byte = bmpData.Stride \ mBitmap.Width
            Dim rgbValues(bytes - 1) As Byte
            Marshal.Copy(ptr, rgbValues, 0, bytes)
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                rgbValues(k) = b(rgbValues(k))
                rgbValues(k + 1) = g(rgbValues(k + 1))
                rgbValues(k + 2) = r(rgbValues(k + 2))
            Next
            Marshal.Copy(rgbValues, 0, ptr, bytes)
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
        System.GC.Collect()
    End Sub
    Private Sub TrackBar4_Scroll_1(sender As Object, e As EventArgs) Handles TrackBar4.Scroll
        If TrackBar3.Value > TrackBar4.Value Then TrackBar3.Value = TrackBar4.Value
        Dim tra As Byte = TrackBar1.Value
        Dim tra2 As Byte = TrackBar2.Value
        Dim tra3 As Byte = TrackBar3.Value
        Dim tra4 As Byte = TrackBar4.Value
        Dim tra5 As Byte = TrackBar5.Value
        Dim tra6 As Byte = TrackBar6.Value
        Dim r(255), g(255), b(255) As Byte
        Dim i As Single
        For i = 0 To 255
            b(i) = tra5 + (i * ((tra6 - tra5) / 255))
            g(i) = tra3 + (i * ((tra4 - tra3) / 255))
            r(i) = tra + (i * ((tra2 - tra) / 255))
        Next
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Single
        Dim mBitmap As Bitmap
        Try
            mBitmap = New Bitmap(PictureBox2.Image)
            Width = mBitmap.Width
            Height = mBitmap.Height
            Dim rect As New Rectangle(0, 0, Width, Height)
            Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
            Dim ptr As IntPtr = bmpData.Scan0
            Dim bytes As Integer = bmpData.Stride * Height
            Dim Bpx As Byte = bmpData.Stride \ mBitmap.Width
            Dim rgbValues(bytes - 1) As Byte
            Marshal.Copy(ptr, rgbValues, 0, bytes)
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                rgbValues(k) = b(rgbValues(k))
                rgbValues(k + 1) = g(rgbValues(k + 1))
                rgbValues(k + 2) = r(rgbValues(k + 2))
            Next
            Marshal.Copy(rgbValues, 0, ptr, bytes)
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
        System.GC.Collect()
    End Sub
    Private Sub TrackBar6_Scroll_1(sender As Object, e As EventArgs) Handles TrackBar6.Scroll
        If TrackBar5.Value > TrackBar6.Value Then TrackBar5.Value = TrackBar6.Value
        Dim tra As Byte = TrackBar1.Value
        Dim tra2 As Byte = TrackBar2.Value
        Dim tra3 As Byte = TrackBar3.Value
        Dim tra4 As Byte = TrackBar4.Value
        Dim tra5 As Byte = TrackBar5.Value
        Dim tra6 As Byte = TrackBar6.Value
        Dim r(255), g(255), b(255) As Byte
        Dim i As Single
        For i = 0 To 255
            b(i) = tra5 + (i * ((tra6 - tra5) / 255))
            g(i) = tra3 + (i * ((tra4 - tra3) / 255))
            r(i) = tra + (i * ((tra2 - tra) / 255))
        Next
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Single
        Dim mBitmap As Bitmap
        Try
            mBitmap = New Bitmap(PictureBox2.Image)
            Width = mBitmap.Width
            Height = mBitmap.Height
            Dim rect As New Rectangle(0, 0, Width, Height)
            Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
            Dim ptr As IntPtr = bmpData.Scan0
            Dim bytes As Integer = bmpData.Stride * Height
            Dim Bpx As Byte = bmpData.Stride \ mBitmap.Width
            Dim rgbValues(bytes - 1) As Byte
            Marshal.Copy(ptr, rgbValues, 0, bytes)
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                rgbValues(k) = b(rgbValues(k))
                rgbValues(k + 1) = g(rgbValues(k + 1))
                rgbValues(k + 2) = r(rgbValues(k + 2))
            Next
            Marshal.Copy(rgbValues, 0, ptr, bytes)
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
        System.GC.Collect()
    End Sub
End Class