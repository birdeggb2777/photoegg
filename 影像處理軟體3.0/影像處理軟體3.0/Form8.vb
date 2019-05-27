Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form8
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Dim start_time As Date = Now
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
            Dim rgbA As Byte
            Dim rr, gg, bb, rr2, gg2, bb2, rr3, gg3, bb3 As Integer
            Dim tra As Integer = TrackBar1.Value
            Dim widt As Integer = PictureBox1.Width
            For k As Integer = 0 To rgbValues.Length - Bpx - widt * 4 - 4 Step Bpx
                bb = rgbValues(k)
                gg = rgbValues(k + 1)
                rr = rgbValues(k + 2)
                bb2 = rgbValues(k + 4)
                gg2 = rgbValues(k + 1 + 4)
                rr2 = rgbValues(k + 2 + 4)
                bb3 = rgbValues(k + widt * 4)
                gg3 = rgbValues(k + 1 + widt * 4)
                rr3 = rgbValues(k + 2 + widt * 4)
                If (rr - rr2) ^ 2 >= tra ^ 2 Or (gg - gg2) ^ 2 >= tra ^ 2 Or (bb - bb2) ^ 2 >= tra ^ 2 Then
                    rgbValues(k) = 0
                    rgbValues(k + 1) = 0
                    rgbValues(k + 2) = 0
                ElseIf (rr - rr3) ^ 2 >= tra ^ 2 Or (gg - gg3) ^ 2 >= tra ^ 2 Or (bb - bb3) ^ 2 >= tra ^ 2 Then
                    rgbValues(k) = 0
                    rgbValues(k + 1) = 0
                    rgbValues(k + 2) = 0
                Else
                    rgbValues(k) = 255
                    rgbValues(k + 1) = 255
                    rgbValues(k + 2) = 255
                End If
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
    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Button1.Text = "確定"
            Me.Text = "草稿"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Button1.Text = "determine"
            Me.Text = "draft"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Button1.Text = "決定します"
            Me.Text = "ドラフト"
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
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.PictureBox1.Image = PictureBox1.Image
        Me.Close()
    End Sub
End Class