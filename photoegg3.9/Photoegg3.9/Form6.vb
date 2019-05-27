Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form6
    Dim p(5) As Image
    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "模糊程度"
            Button1.Text = "確定"
            Me.Text = "像素模糊"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "Degree of blur"
            Button1.Text = "determine"
            Me.Text = "Pixel blur"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "ぼかしの度合い"
            Button1.Text = "決定します"
            Me.Text = "ピクセルボケ"
        End If
        Button1.BackColor = Form1.BackColor
        Me.BackColor = Form1.BackColor
        Me.ForeColor = Form1.ForeColor
        PictureBox1.Image = Form1.PictureBox1.Image
        PictureBox2.Image = Form1.PictureBox1.Image
        PictureBox3.Image = Form1.PictureBox1.Image
        Dim a As New Bitmap(PictureBox1.Image)
        PictureBox1.Size = New Size(Form1.PictureBox1.Width, Form1.PictureBox1.Height)
        Me.Width = a.Width + 500
        Me.Height = a.Height + 500
        PictureBox2.Left = -200
        PictureBox3.Left = -200
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        PictureBox3.Image = PictureBox2.Image
        For z = 1 To 5
            Try
                mBitmap = New Bitmap(PictureBox3.Image)
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
                Dim rr, gg, bb, rr2, gg2, bb2, rr3, gg3, bb3, rr4, gg4, bb4 As Integer
                Dim widt As Integer = mBitmap.Width
                Dim ll As Integer = rgbValues.Length
                For k As Integer = widt * 4 * 5 + 4 To ll - Bpx - widt * 4 * 5 - 4 Step Bpx
                    bb = rgbValues(k - 4)
                    gg = rgbValues(k + 1 - 4)
                    rr = rgbValues(k + 2 - 4)
                    bb2 = rgbValues(k + widt * 4)
                    gg2 = rgbValues(k + 1 + widt * 4)
                    rr2 = rgbValues(k + 2 + widt * 4)
                    bb3 = rgbValues(k - widt * 4)
                    gg3 = rgbValues(k + 1 - widt * 4)
                    rr3 = rgbValues(k + 2 - widt * 4)
                    bb4 = rgbValues(k + 4)
                    gg4 = rgbValues(k + 5)
                    rr4 = rgbValues(k + 6)
                    rgbValues(k) = (bb + bb2 + bb3 + bb4) / 4
                    rgbValues(k + 1) = (gg + gg2 + gg3 + gg4) / 4
                    rgbValues(k + 2) = (rr + rr2 + rr3 + rr4) / 4
                Next
                System.GC.Collect()
                Marshal.Copy(rgbValues, 0, ptr, bytes) '
                mBitmap.UnlockBits(bmpData)
                Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
                PictureBox3.Image = mBitmap
                p(z) = PictureBox3.Image
            Catch ex As SystemException
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        Next
        System.GC.Collect()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.re2(Form1.re02) = Form1.PictureBox1.Image
        Form1.re02 += 1
        Form1.PictureBox1.Image = PictureBox1.Image
        System.GC.Collect()
        Me.Close()
    End Sub
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        PictureBox1.Image = p(TrackBar1.Value)
        If TrackBar1.Value = 0 Then
            PictureBox1.Image = Form1.PictureBox1.Image
        End If
        System.GC.Collect()
    End Sub
End Class