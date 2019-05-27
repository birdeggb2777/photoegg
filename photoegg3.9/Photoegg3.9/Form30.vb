Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form30
    Private Sub Form30_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Me.Text = "加深顏色"
            Button1.Text = "確定"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Me.Text = "Deepen the color"
            Button1.Text = "determine"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Me.Text = "色を深めます"
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
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Dim tra As Single = TrackBar1.Value / 10
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        Dim rgb(255) As Integer
        For i = 0 To 255
            RGB(i) = i * tra
        Next
        Try
            mBitmap = New Bitmap(PictureBox2.Image)
            Width = mBitmap.Width
            Height = mBitmap.Height
            Dim rect As New Rectangle(0, 0, Width, Height)
            Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
            Dim ptr As IntPtr = bmpData.Scan0
            Dim bytes As Integer = bmpData.Stride * Height
            With bmpData
            End With
            Dim Bpx As Byte = bmpData.Stride \ mBitmap.Width
            Dim rgbValues(bytes - 1) As Byte
            Marshal.Copy(ptr, rgbValues, 0, bytes)
            Dim rr, gg, bb As Integer
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                bb = 255 - rgbValues(k)
                gg = 255 - rgbValues(k + 1)
                rr = 255 - rgbValues(k + 2)
                rr = rgb(rr)
                gg = rgb(gg)
                bb = rgb(bb)
                If rr > 255 Then
                    rr = 255
                End If
                If gg > 255 Then
                    gg = 255
                End If
                If bb > 255 Then
                    bb = 255
                End If
                If rr < 0 Then
                    rr = 0
                End If
                If gg < 0 Then
                    gg = 0
                End If
                If bb < 0 Then
                    bb = 0
                End If
                rgbValues(k) = 255 - bb
                rgbValues(k + 1) = 255 - gg
                rgbValues(k + 2) = 255 - rr
            Next
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
        System.GC.Collect()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.re2(Form1.re02) = Form1.PictureBox1.Image
        Form1.re02 += 1
        Form1.PictureBox1.Image = PictureBox1.Image
        Me.Close()
    End Sub
End Class