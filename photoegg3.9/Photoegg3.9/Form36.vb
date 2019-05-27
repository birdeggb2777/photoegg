Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form36
    Private Sub Form36_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "效果"
            Label2.Text = "距離"
            Button1.Text = "套用"
            Button2.Text = "確定"
            Me.Text = "幻彩"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "effect"
            Label2.Text = "distance"
            Button1.Text = "Apply"
            Button2.Text = "determine"
            Me.Text = "Symphony"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "効果"
            Label2.Text = "距離"
            Button1.Text = "適用"
            Button2.Text = "決定します"
            Me.Text = "シンフォニー"
        End If
        Button1.BackColor = Form1.BackColor
        Button2.BackColor = Form1.BackColor
        Me.BackColor = Form1.BackColor
        Me.ForeColor = Form1.ForeColor
        PictureBox1.Image = Form1.PictureBox1.Image
        PictureBox2.Image = Form1.PictureBox1.Image
        Dim a As New Bitmap(PictureBox1.Image)
        PictureBox1.Size = New Size(Form1.PictureBox1.Width, Form1.PictureBox1.Height)
        PictureBox2.Size = New Size(a.Width, a.Height)
        Me.Width = a.Width + 500
        Me.Height = a.Height + 500
        PictureBox2.Left = -200
        PictureBox2.Hide()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tra As Integer = TrackBar1.Value
        Dim tra2 As Integer = TrackBar2.Value
        ProgressBar1.Maximum = tra
        Dim mBitmap As Bitmap
        Dim start_time As Date = Now
        Dim rr, gg, bb, rr2, gg2, bb2, rr3, gg3, bb3, rr4, gg4, bb4 As Integer
        Dim Width As Integer, Height As Integer
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
            Dim widt As Integer = mBitmap.Width
            For z = 1 To tra
                For k As Integer = widt * 4 * tra2 * 2 + 4 To rgbValues.Length - Bpx - widt * 4 * tra2 * 2 - 4 Step Bpx
                    bb = rgbValues(k - 4 * tra2 * 2)
                    gg = rgbValues(k + 1 - 4 * tra2)
                    rr = rgbValues(k + 2 - 4 * tra2)
                    bb2 = rgbValues(k + widt * 4 * tra2)
                    gg2 = rgbValues(k + 1 + widt * 4 * tra2 * 2)
                    rr2 = rgbValues(k + 2 + widt * 4 * tra2)
                    bb3 = rgbValues(k - widt * 4 * tra2)
                    gg3 = rgbValues(k + 1 - widt * 4 * tra2)
                    rr3 = rgbValues(k + 2 - widt * 4 * tra2 * 2)
                    bb4 = rgbValues(k + 4 * tra2)
                    gg4 = rgbValues(k + 1 + 4 * tra2)
                    rr4 = rgbValues(k + 2 + 4 * tra2)
                    rgbValues(k) = (bb + bb2 + bb3 + bb4) / 4
                    rgbValues(k + 1) = (gg + gg2 + gg3 + gg4) / 4
                    rgbValues(k + 2) = (rr + rr2 + rr3 + rr4) / 4
                Next
                ProgressBar1.Value = z
            Next
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
            PictureBox1.Image = mBitmap
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        System.GC.Collect()
        Dim mBitmap2 As Bitmap
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
            mBitmap2 = New Bitmap(PictureBox2.Image)
            Width = mBitmap2.Width
            Height = mBitmap2.Height
            Dim rect2 As New Rectangle(0, 0, Width, Height)
            Dim bmpData2 As BitmapData = mBitmap2.LockBits(rect, ImageLockMode.ReadWrite, mBitmap2.PixelFormat)
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
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                bb = rgbValues(k)
                gg = rgbValues(k + 1)
                rr = rgbValues(k + 2)
                bb2 = rgbValues2(k)
                gg2 = rgbValues2(k + 1)
                rr2 = rgbValues2(k + 2)
                rr = Math.Abs(rr - rr2)
                gg = Math.Abs(gg - gg2)
                bb = Math.Abs(bb - bb2)
                If rr > 255 Then rr = 255
                If gg > 255 Then gg = 255
                If bb > 255 Then bb = 255
                If rr < 0 Then rr = 0
                If gg < 0 Then gg = 0
                If bb < 0 Then bb = 0
                rgbValues(k) = 255 - bb
                rgbValues(k + 1) = 255 - gg
                rgbValues(k + 2) = 255 - rr
            Next
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            mBitmap2.UnlockBits(bmpData2)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
        System.GC.Collect()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.re2(Form1.re02) = Form1.PictureBox1.Image
        Form1.re02 += 1
        Form1.PictureBox1.Image = PictureBox1.Image
        Me.Close()
    End Sub
End Class