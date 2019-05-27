Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form23
    Private Sub Form23_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "方塊大小"
            Button1.Text = "確定"
            Me.Text = "馬賽克"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "Block size"
            Button1.Text = "determine"
            Me.Text = "Mosaic"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "ブロックサイズ"
            Button1.Text = "決定します"
            Me.Text = "モザイク"
        End If
        Button1.BackColor = Form1.BackColor
        Me.BackColor = Form1.BackColor
        Me.ForeColor = Form1.ForeColor
        PictureBox1.Image = Form1.PictureBox1.Image
        PictureBox2.Image = Form1.PictureBox1.Image
        Dim a As New Bitmap(PictureBox1.Image)
        PictureBox1.Size = New Size(a.Width, a.Height)
        Me.Width = a.Width + 150
        Me.Height = a.Height + 150
        PictureBox2.Left = -200
    End Sub
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Dim start_time As Date = Now
        Dim R As Byte, G As Byte, B As Byte
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        Dim pi As Integer = PictureBox1.Width
        Dim tra As Integer = TrackBar1.Value
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
            Dim wi As Integer = PictureBox1.Width
            Dim he As Integer = PictureBox1.Height
            For i As Integer = 0 To he * 4 - Bpx * tra Step Bpx * tra
                For k As Integer = 0 To wi * 4 - Bpx * tra Step Bpx * tra
                    B = CByte(rgbValues(k + wi * i))
                    G = CByte(rgbValues(k + 1 + wi * i))
                    R = CByte(rgbValues(k + 2 + wi * i))
                    For i2 = 0 To tra * 4 - 4 Step Bpx
                        For i1 = 0 To tra * 4 - 4 Step Bpx
                            rgbValues(i2 * wi + k + wi * i + i1) = B
                            rgbValues(i2 * wi + k + wi * i + i1 + 1) = G
                            rgbValues(i2 * wi + k + wi * i + i1 + 2) = R
                        Next
                    Next
                Next
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