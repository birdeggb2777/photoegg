Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form26
    Private Sub Form26_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "線條數量"
            Button1.Text = "確定"
            Me.Text = "掃描線"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "Number of lines"
            Button1.Text = "determine"
            Me.Text = "Scan line"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "行数"
            Button1.Text = "決定します"
            Me.Text = "走査線"
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
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Dim start_time As Date = Now
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
            Dim wi As Integer = mBitmap.Width
            Dim he As Integer = mBitmap.Height
            For i As Integer = 0 To he * 4 - Bpx * tra Step Bpx * tra
                For k As Integer = 0 To wi * 4 - Bpx * tra Step Bpx * tra
                    rgbValues(k + wi * i) = 0
                    rgbValues(k + 1 + wi * i) = 0
                    rgbValues(k + 2 + wi * i) = 0
                    For i1 = 0 To tra * 4 - 4 Step Bpx
                        rgbValues(k + wi * i + i1) = 0
                        rgbValues(k + wi * i + i1 + 1) = 0
                        rgbValues(k + wi * i + i1 + 2) = 0
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
        Form1.re2(Form1.re02) = Form1.PictureBox1.Image
        Form1.re02 += 1
        Form1.PictureBox1.Image = PictureBox1.Image
        Me.Close()
    End Sub
End Class