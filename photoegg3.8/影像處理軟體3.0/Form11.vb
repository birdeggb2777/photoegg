Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form11
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll, TrackBar2.Scroll
        Dim start_time As Date = Now
        Dim R As Byte, G As Byte, B As Byte
        Dim Width As Integer, Height As Integer
        Dim tra As Byte = TrackBar1.Value
        PictureBox2.Image = Form1.PictureBox1.Image
        Dim mBitmap As Bitmap
        For i = 1 To TrackBar2.Value
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
                Dim c As Integer
                Dim widt As Integer = PictureBox1.Width
                For k As Integer = widt * 4 * tra + 4 To rgbValues.Length - Bpx - widt * 4 * tra - 4 Step Bpx
                    c = Int(Rnd() * 4)
                    B = CByte(rgbValues(k))
                    G = CByte(rgbValues(k + 1))
                    R = CByte(rgbValues(k + 2))
                    If c = 0 Then
                        rgbValues(k + widt * 4 * tra) = B
                        rgbValues(k + 1 + widt * 4 * tra) = G
                        rgbValues(k + 2 + widt * 4 * tra) = R
                    ElseIf c = 1 Then
                        rgbValues(k - widt * 4 * tra) = B
                        rgbValues(k + 1 - widt * 4 * tra) = G
                        rgbValues(k + 2 - widt * 4 * tra) = R
                    ElseIf c = 2 Then
                        rgbValues(k + 4 * tra) = B
                        rgbValues(k + 1 + 4 * tra) = G
                        rgbValues(k + 2 + 4 * tra) = R
                    ElseIf c = 3 Then
                        rgbValues(k - 4 * tra) = B
                        rgbValues(k + 1 - 4 * tra) = G
                        rgbValues(k + 2 - 4 * tra) = R
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
            PictureBox2.Image = mBitmap
        Next
        PictureBox1.Image = mBitmap
        System.GC.Collect()
    End Sub
    Private Sub Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "距離"
            Label2.Text = "程度"
            Button1.Text = "確定"
            Me.Text = "一般噴槍"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "distance"
            Label2.Text = "degree"
            Button1.Text = "determine"
            Me.Text = "General gun"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "距離"
            Label2.Text = "エクステント"
            Button1.Text = "決定します"
            Me.Text = "一般的なガン"
        End If
        Button1.BackColor = Form1.BackColor
        Me.BackColor = Form1.BackColor
        Me.ForeColor = Form1.ForeColor
        PictureBox1.Image = Form1.PictureBox1.Image
        PictureBox2.Image = Form1.PictureBox1.Image
        Dim a As New Bitmap(PictureBox1.Image)
        PictureBox1.Size = New Size(a.Width, a.Height)
        Me.Width = a.Width + 500
        Me.Height = a.Height + 500
        PictureBox2.Left = -200
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.PictureBox1.Image = PictureBox1.Image
        Me.Close()
    End Sub
End Class