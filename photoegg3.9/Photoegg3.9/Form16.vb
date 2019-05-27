Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form16
    Private Sub Form16_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Button1.Text = "確定"
            Me.Text = "色彩修正(百分比)"
            RadioButton1.Text = "正向"
            RadioButton2.Text = "反向"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Button1.Text = "determine"
            Me.Text = "Color Correction (Percentage)"
            RadioButton1.Text = "Positive"
            RadioButton2.Text = "Reverse"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Button1.Text = "決定します"
            Me.Text = "色補正（パーセンテージ)"
            RadioButton1.Text = "前方に"
            RadioButton2.Text = "リバース"
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
        RadioButton1.Checked = True
    End Sub
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        Dim tra As Integer = TrackBar1.Value
        Dim tra2 As Integer = TrackBar2.Value
        Dim tra3 As Integer = TrackBar3.Value
        Dim r(255) As Integer, g(255) As Integer, b(255) As Integer
        If RadioButton2.Checked = True Then
            tra = 255 - tra
            tra2 = 255 - tra2
            tra3 = 255 - tra3
        End If
        For i = 0 To 255
            r(i) = i * tra / 100
            g(i) = i * tra2 / 100
            b(i) = i * tra3 / 100
        Next
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
            Dim rr, gg, bb As Integer
            If RadioButton1.Checked = True Then
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    bb = rgbValues(k)
                    gg = rgbValues(k + 1)
                    rr = rgbValues(k + 2)
                    rr = r(rr)
                    gg = g(gg)
                    bb = b(bb)
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
                Next
            Else
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    bb = 255 - rgbValues(k)
                    gg = 255 - rgbValues(k + 1)
                    rr = 255 - rgbValues(k + 2)
                    rr = r(rr)
                    gg = g(gg)
                    bb = b(bb)
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
                    rgbValues(k) = 255 - bb
                    rgbValues(k + 1) = 255 - gg
                    rgbValues(k + 2) = 255 - rr
                Next
            End If
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
        System.GC.Collect()
    End Sub
    Private Sub TrackBar2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar2.Scroll
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        Dim tra As Integer = TrackBar1.Value
        Dim tra2 As Integer = TrackBar2.Value
        Dim tra3 As Integer = TrackBar3.Value
        Dim r(255) As Integer, g(255) As Integer, b(255) As Integer
        If RadioButton2.Checked = True Then
            tra = 255 - tra
            tra2 = 255 - tra2
            tra3 = 255 - tra3
        End If
        For i = 0 To 255
            r(i) = i * tra / 100
            g(i) = i * tra2 / 100
            b(i) = i * tra3 / 100
        Next
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
            Dim rr, gg, bb As Integer
            If RadioButton1.Checked = True Then
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    bb = rgbValues(k)
                    gg = rgbValues(k + 1)
                    rr = rgbValues(k + 2)
                    rr = r(rr)
                    gg = g(gg)
                    bb = b(bb)
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
                Next
            Else
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    bb = 255 - rgbValues(k)
                    gg = 255 - rgbValues(k + 1)
                    rr = 255 - rgbValues(k + 2)
                    rr = r(rr)
                    gg = g(gg)
                    bb = b(bb)
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
                    rgbValues(k) = 255 - bb
                    rgbValues(k + 1) = 255 - gg
                    rgbValues(k + 2) = 255 - rr
                Next
            End If
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
        System.GC.Collect()
    End Sub
    Private Sub TrackBar3_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar3.Scroll
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        Dim tra As Integer = TrackBar1.Value
        Dim tra2 As Integer = TrackBar2.Value
        Dim tra3 As Integer = TrackBar3.Value
        Dim r(255) As Integer, g(255) As Integer, b(255) As Integer
        If RadioButton2.Checked = True Then
            tra = 255 - tra
            tra2 = 255 - tra2
            tra3 = 255 - tra3
        End If
        For i = 0 To 255
            r(i) = i * tra / 100
            g(i) = i * tra2 / 100
            b(i) = i * tra3 / 100
        Next
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
            Dim rr, gg, bb As Integer
            If RadioButton1.Checked = True Then
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    bb = rgbValues(k)
                    gg = rgbValues(k + 1)
                    rr = rgbValues(k + 2)
                    rr = r(rr)
                    gg = g(gg)
                    bb = b(bb)
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
                Next
            Else
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    bb = 255 - rgbValues(k)
                    gg = 255 - rgbValues(k + 1)
                    rr = 255 - rgbValues(k + 2)
                    rr = r(rr)
                    gg = g(gg)
                    bb = b(bb)
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
                    rgbValues(k) = 255 - bb
                    rgbValues(k + 1) = 255 - gg
                    rgbValues(k + 2) = 255 - rr
                Next
            End If
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
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        Dim tra As Integer = TrackBar1.Value
        Dim tra2 As Integer = TrackBar2.Value
        Dim tra3 As Integer = TrackBar3.Value
        Dim r(255) As Integer, g(255) As Integer, b(255) As Integer
        If RadioButton2.Checked = True Then
            tra = 255 - tra
            tra2 = 255 - tra2
            tra3 = 255 - tra3
        End If
        For i = 0 To 255
            r(i) = i * tra / 100
            g(i) = i * tra2 / 100
            b(i) = i * tra3 / 100
        Next
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
            Dim rr, gg, bb As Integer
            If RadioButton1.Checked = True Then
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    bb = rgbValues(k)
                    gg = rgbValues(k + 1)
                    rr = rgbValues(k + 2)
                    rr = r(rr)
                    gg = g(gg)
                    bb = b(bb)
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
                Next
            Else
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    bb = 255 - rgbValues(k)
                    gg = 255 - rgbValues(k + 1)
                    rr = 255 - rgbValues(k + 2)
                    rr = r(rr)
                    gg = g(gg)
                    bb = b(bb)
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
                    rgbValues(k) = 255 - bb
                    rgbValues(k + 1) = 255 - gg
                    rgbValues(k + 2) = 255 - rr
                Next
            End If
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
        System.GC.Collect()
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        Dim tra As Integer = TrackBar1.Value
        Dim tra2 As Integer = TrackBar2.Value
        Dim tra3 As Integer = TrackBar3.Value
        Dim r(255) As Integer, g(255) As Integer, b(255) As Integer
        If RadioButton2.Checked = True Then
            tra = 255 - tra
            tra2 = 255 - tra2
            tra3 = 255 - tra3
        End If
        For i = 0 To 255
            r(i) = i * tra / 100
            g(i) = i * tra2 / 100
            b(i) = i * tra3 / 100
        Next
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
            Dim rr, gg, bb As Integer
            If RadioButton1.Checked = True Then
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    bb = rgbValues(k)
                    gg = rgbValues(k + 1)
                    rr = rgbValues(k + 2)
                    rr = r(rr)
                    gg = g(gg)
                    bb = b(bb)
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
                Next
            Else
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    bb = 255 - rgbValues(k)
                    gg = 255 - rgbValues(k + 1)
                    rr = 255 - rgbValues(k + 2)
                    rr = r(rr)
                    gg = g(gg)
                    bb = b(bb)
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
                    rgbValues(k) = 255 - bb
                    rgbValues(k + 1) = 255 - gg
                    rgbValues(k + 2) = 255 - rr
                Next
            End If
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