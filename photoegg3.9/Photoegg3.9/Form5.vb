Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form5
    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Button1.Text = "確定"
            Me.Text = "色相"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Button1.Text = "determine"
            Me.Text = "Hue"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Button1.Text = "決定します"
            Me.Text = "フエ"
        End If
        Button1.BackColor = Form1.BackColor
        Me.BackColor = Form1.BackColor
        Me.ForeColor = Form1.ForeColor
        PictureBox1.Image = Form1.PictureBox1.Image
        PictureBox2.Image = Form1.PictureBox1.Image
        Dim a As New Bitmap(PictureBox1.Image)
        PictureBox1.Size = New Size(Form1.PictureBox1.Width, Form1.PictureBox1.Height)
        Me.Width = a.Width + 500
        Me.Height = a.Height + 500
        PictureBox2.Left = -200
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.re2(Form1.re02) = Form1.PictureBox1.Image
        Form1.re02 += 1
        Form1.PictureBox1.Image = PictureBox1.Image
        Me.Close()
    End Sub
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Dim start_time As Date = Now
        Dim R As Byte, G As Byte, B As Byte
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
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
            Dim tra As Byte = TrackBar1.Value
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                B = rgbValues(k)
                G = rgbValues(k + 1)
                R = rgbValues(k + 2)
                If tra = 1 Then
                    rgbValues(k) = B
                    rgbValues(k + 1) = G
                    rgbValues(k + 2) = R
                ElseIf tra = 2 Then
                    rgbValues(k) = B
                    rgbValues(k + 1) = R
                    rgbValues(k + 2) = G
                ElseIf tra = 3 Then
                    rgbValues(k) = G
                    rgbValues(k + 1) = B
                    rgbValues(k + 2) = R
                ElseIf tra = 4 Then
                    rgbValues(k) = G
                    rgbValues(k + 1) = R
                    rgbValues(k + 2) = B
                ElseIf tra = 5 Then
                    rgbValues(k) = R
                    rgbValues(k + 1) = G
                    rgbValues(k + 2) = B
                Else
                    rgbValues(k) = R
                    rgbValues(k + 1) = R
                    rgbValues(k + 2) = B
                End If
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
End Class