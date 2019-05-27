Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form17
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.PictureBox1.Image = PictureBox1.Image
        Me.Close()
    End Sub
    Private Sub Form17_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "鮮豔度"
            Button1.Text = "確定"
            Me.Text = "飽和度"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "Brightness"
            Button1.Text = "determine"
            Me.Text = "saturation"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "鮮やかさ"
            Button1.Text = "決定します"
            Me.Text = "飽和"
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
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Dim tra As Byte = TrackBar1.Value
        If tra = 1 Then
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
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    Dim rr, gg, bb As Integer
                    bb = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3) / 2 + rgbValues(k) / 2
                    gg = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3) / 2 + rgbValues(k + 1) / 2
                    rr = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3) / 2 + rgbValues(k + 2) / 2
                    rgbValues(k) = bb
                    rgbValues(k + 1) = gg
                    rgbValues(k + 2) = rr
                    bb = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3) / 2 + rgbValues(k) / 2
                    gg = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3) / 2 + rgbValues(k + 1) / 2
                    rr = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3) / 2 + rgbValues(k + 2) / 2
                    rgbValues(k) = bb
                    rgbValues(k + 1) = gg
                    rgbValues(k + 2) = rr
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
        ElseIf tra = 2 Then
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
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    Dim rr, gg, bb As Integer
                    bb = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3) / 2 + rgbValues(k) / 2
                    gg = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3) / 2 + rgbValues(k + 1) / 2
                    rr = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3) / 2 + rgbValues(k + 2) / 2
                    rgbValues(k) = bb
                    rgbValues(k + 1) = gg
                    rgbValues(k + 2) = rr
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
        ElseIf tra = 3 Then
            PictureBox1.Image = PictureBox2.Image
        ElseIf tra = 4 Then
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
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    Dim rr, gg, bb, c As Integer
                    bb = rgbValues(k)
                    gg = rgbValues(k + 1)
                    rr = rgbValues(k + 2)
                    c = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3)
                    rr = rr * 2 - c
                    gg = gg * 2 - c
                    bb = bb * 2 - c
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
                    rgbValues(k) = bb
                    rgbValues(k + 1) = gg
                    rgbValues(k + 2) = rr
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
        ElseIf tra = 5 Then
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
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    Dim rr, gg, bb, c As Integer
                    bb = rgbValues(k)
                    gg = rgbValues(k + 1)
                    rr = rgbValues(k + 2)
                    c = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3)
                    rr = rr * 2 - c
                    gg = gg * 2 - c
                    bb = bb * 2 - c
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
                    rgbValues(k) = bb
                    rgbValues(k + 1) = gg
                    rgbValues(k + 2) = rr
                    bb = rgbValues(k)
                    gg = rgbValues(k + 1)
                    rr = rgbValues(k + 2)
                    c = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3)
                    rr = rr * 2 - c
                    gg = gg * 2 - c
                    bb = bb * 2 - c
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
                    rgbValues(k) = bb
                    rgbValues(k + 1) = gg
                    rgbValues(k + 2) = rr
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
        End If
    End Sub
End Class