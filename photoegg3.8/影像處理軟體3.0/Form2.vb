Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form2
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "距離"
            Button2.Text = "確定"
            Me.Text = "浮雕"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "distance"
            Button2.Text = "determine"
            Me.Text = "Relief"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "距離"
            Button2.Text = "決定します"
            Me.Text = "救済"
        End If
        Button2.BackColor = Form1.BackColor
        Me.BackColor = Form1.BackColor
        Me.ForeColor = Form1.ForeColor
        PictureBox1.Image = Form1.PictureBox1.Image
        PictureBox2.Image = Form1.PictureBox1.Image
        PictureBox3.Image = Form1.PictureBox1.Image
        Dim a As New Bitmap(PictureBox1.Image)
        PictureBox1.Size = New Size(a.Width, a.Height)
        Me.Width = a.Width + 500
        Me.Height = a.Height + 500
        PictureBox2.Left = -200
        PictureBox3.Left = -200
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form1.PictureBox1.Image = PictureBox1.Image
        Me.Close()
    End Sub
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Dim start_time As Date = Now
        Dim R As Byte, G As Byte, B As Byte
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        mBitmap = New Bitmap(PictureBox2.Image)
        Try
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
            Dim rgbA As Byte
            Dim widt As Integer = PictureBox1.Width
            Dim tra As Integer = TrackBar1.Value
            For k As Integer = 0 To rgbValues.Length - Bpx - widt * tra * 4 - 4 * tra Step Bpx
                B = CByte(255 - rgbValues(k + widt * tra * 4 + 4 * tra))
                G = CByte(255 - rgbValues(k + 1 + widt * tra * 4 + 4 * tra))
                R = CByte(255 - rgbValues(k + 2 + widt * tra * 4 + 4 * tra))
                rgbValues(k) = B
                rgbValues(k + 1) = G
                rgbValues(k + 2) = R
                If Bpx = 4 Then
                    rgbA = rgbValues(k + 3)
                End If
            Next
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox3.Image = mBitmap
        System.GC.Collect()
        Dim mBitmap2 As Bitmap
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
            mBitmap2 = New Bitmap(PictureBox3.Image)
            Width = mBitmap2.Width
            Height = mBitmap2.Height
            Dim rect2 As New Rectangle(0, 0, Width, Height)
            Dim bmpData2 As BitmapData = mBitmap2.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
            Dim ptr2 As IntPtr = bmpData2.Scan0
            Dim bytes2 As Integer = bmpData2.Stride * Height
            With bmpData2
            End With
            Dim Bpx As Byte = bmpData.Stride \ mBitmap.Width
            Dim Bpx2 As Byte = bmpData2.Stride \ mBitmap2.Width
            Dim rgbValues(bytes - 1) As Byte
            Marshal.Copy(ptr, rgbValues, 0, bytes)
            Dim rgbValues2(bytes - 1) As Byte
            Marshal.Copy(ptr2, rgbValues2, 0, bytes)
            Dim rgbA As Byte
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                B = CByte(rgbValues(k) / 2 + rgbValues2(k) / 2)
                G = CByte(rgbValues(k + 1) / 2 + rgbValues2(k + 1) / 2)
                R = CByte(rgbValues(k + 2) / 2 + rgbValues2(k + 2) / 2)
                rgbValues(k) = B
                rgbValues(k + 1) = G
                rgbValues(k + 2) = R
                If Bpx = 4 Then
                    rgbA = rgbValues(k + 3)
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