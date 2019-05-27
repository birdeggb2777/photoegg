Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form13
    Private Sub Form13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "不透明度"
            Button1.Text = "確定"
            Me.Text = "彩色雜點"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "Opacity"
            Button1.Text = "determine"
            Me.Text = "Color noise"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "不透明度"
            Button1.Text = "決定します"
            Me.Text = "カラーノイズ"
        End If
        Button1.BackColor = Form1.BackColor
        Me.BackColor = Form1.BackColor
        Me.ForeColor = Form1.ForeColor
        PictureBox1.Image = Form1.PictureBox1.Image
        PictureBox2.Image = Form1.PictureBox1.Image
        PictureBox3.Image = Form1.PictureBox1.Image
        Dim a As New Bitmap(PictureBox1.Image)
        PictureBox1.Size = New Size(a.Width, a.Height)
        PictureBox2.Size = New Size(a.Width, a.Height)
        Me.Width = a.Width + 500
        Me.Height = a.Height + 500
        PictureBox2.Left = -200
        PictureBox3.Left = -200
        PictureBox2.Hide()
        Dim start_time As Date = Now
        Dim R As Byte, G As Byte, B As Byte
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        Try
            mBitmap = New Bitmap(PictureBox1.Image)
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
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                B = Int(Rnd() * 240)
                G = Int(Rnd() * 240)
                R = Int(Rnd() * 240)
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
        PictureBox2.Image = mBitmap
    End Sub
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        System.GC.Collect()
        Dim start_time As Date = Now
        Dim R As Byte, G As Byte, B As Byte
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
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
            Dim tra As Byte = TrackBar1.Value
            Dim rgbA As Byte
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                If tra = 1 Then
                    B = CByte(rgbValues(k) / 10 * 1 + rgbValues2(k) / 10 * 9)
                    G = CByte(rgbValues(k + 1) / 10 * 1 + rgbValues2(k + 1) / 10 * 9)
                    R = CByte(rgbValues(k + 2) / 10 * 1 + rgbValues2(k + 2) / 10 * 9)
                ElseIf tra = 2 Then
                    B = CByte(rgbValues(k) / 10 * 2 + rgbValues2(k) / 10 * 8)
                    G = CByte(rgbValues(k + 1) / 10 * 2 + rgbValues2(k + 1) / 10 * 8)
                    R = CByte(rgbValues(k + 2) / 10 * 2 + rgbValues2(k + 2) / 10 * 8)
                ElseIf tra = 3 Then
                    B = CByte(rgbValues(k) / 10 * 3 + rgbValues2(k) / 10 * 7)
                    G = CByte(rgbValues(k + 1) / 10 * 3 + rgbValues2(k + 1) / 10 * 7)
                    R = CByte(rgbValues(k + 2) / 10 * 3 + rgbValues2(k + 2) / 10 * 7)
                ElseIf tra = 4 Then
                    B = CByte(rgbValues(k) / 10 * 4 + rgbValues2(k) / 10 * 6)
                    G = CByte(rgbValues(k + 1) / 10 * 4 + rgbValues2(k + 1) / 10 * 6)
                    R = CByte(rgbValues(k + 2) / 10 * 4 + rgbValues2(k + 2) / 10 * 6)
                ElseIf tra = 5 Then
                    B = CByte(rgbValues(k) / 10 * 5 + rgbValues2(k) / 10 * 5)
                    G = CByte(rgbValues(k + 1) / 10 * 5 + rgbValues2(k + 1) / 10 * 5)
                    R = CByte(rgbValues(k + 2) / 10 * 5 + rgbValues2(k + 2) / 10 * 5)
                ElseIf tra = 6 Then
                    B = CByte(rgbValues(k) / 10 * 6 + rgbValues2(k) / 10 * 4)
                    G = CByte(rgbValues(k + 1) / 10 * 6 + rgbValues2(k + 1) / 10 * 4)
                    R = CByte(rgbValues(k + 2) / 10 * 6 + rgbValues2(k + 2) / 10 * 4)
                ElseIf tra = 7 Then
                    B = CByte(rgbValues(k) / 10 * 7 + rgbValues2(k) / 10 * 3)
                    G = CByte(rgbValues(k + 1) / 10 * 7 + rgbValues2(k + 1) / 10 * 3)
                    R = CByte(rgbValues(k + 2) / 10 * 7 + rgbValues2(k + 2) / 10 * 3)
                ElseIf tra = 8 Then
                    B = CByte(rgbValues(k) / 10 * 8 + rgbValues2(k) / 10 * 2)
                    G = CByte(rgbValues(k + 1) / 10 * 8 + rgbValues2(k + 1) / 10 * 2)
                    R = CByte(rgbValues(k + 2) / 10 * 8 + rgbValues2(k + 2) / 10 * 2)
                ElseIf tra = 9 Then
                    B = CByte(rgbValues(k) / 10 * 9 + rgbValues2(k) / 10 * 1)
                    G = CByte(rgbValues(k + 1) / 10 * 9 + rgbValues2(k + 1) / 10 * 1)
                    R = CByte(rgbValues(k + 2) / 10 * 9 + rgbValues2(k + 2) / 10 * 1)
                ElseIf tra = 10 Then
                    B = CByte(rgbValues(k))
                    G = CByte(rgbValues(k + 1))
                    R = CByte(rgbValues(k + 2))
                End If
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
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.PictureBox1.Image = PictureBox1.Image
        Me.Close()
    End Sub
End Class