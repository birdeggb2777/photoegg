Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form31
    Private Sub Form31_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Me.Text = "線稿"
            Button1.Text = "確定"
            Label1.Text = "深淺"
            Label2.Text = "亮度"
            Label3.Text = "臨界"
            CheckBox1.Text = "詼諧"
            CheckBox2.Text = "黑白"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Me.Text = "Line draft"
            Button1.Text = "determine"
            Label1.Text = "depth"
            Label2.Text = "brightness"
            Label3.Text = "critical"
            CheckBox1.Text = "humorous"
            CheckBox2.Text = "Black & white"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Me.Text = "芸術作品"
            Button1.Text = "決定します"
            Label1.Text = "深さ"
            Label2.Text = "明るさ"
            Label3.Text = "クリティカル"
            CheckBox1.Text = "滑稽"
            CheckBox2.Text = "黒と白"
        End If
        Me.BackColor = Form1.BackColor
        Me.ForeColor = Form1.ForeColor
        Button1.BackColor = Form1.BackColor
        PictureBox1.Image = Form1.PictureBox2.Image
        PictureBox2.Image = Form1.PictureBox2.Image
        PictureBox3.Image = Form1.PictureBox2.Image
        Dim a As New Bitmap(PictureBox2.Image)
        PictureBox1.Size = New Size(Form1.PictureBox1.Width, Form1.PictureBox1.Height)
        Me.Width = a.Width + 500
        Me.Height = a.Height + 500
        PictureBox2.Left = -200
        Button2.Left = -300
        Button3.Left = -300
        CheckBox1.Checked = True
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
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
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                rgbValues(k) = 255 - rgbValues(k)
                rgbValues(k + 1) = 255 - rgbValues(k + 1)
                rgbValues(k + 2) = 255 - rgbValues(k + 2)
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
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Button2.PerformClick()
        Dim tra3 As Byte = TrackBar3.Value
        Dim tra As Single = TrackBar1.Value / 10
        Dim start_time As Date = Now
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
            Dim rr, gg, bb As Integer
            Dim tr1(255) As Integer
            For i = 0 To 255
                tr1(i) = i * tra
            Next
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                bb = rgbValues(k)
                gg = rgbValues(k + 1)
                rr = rgbValues(k + 2)
                rr = tr1(rr)
                gg = tr1(gg)
                bb = tr1(bb)
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
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
        System.GC.Collect()
        Button3.PerformClick()
        Dim tra2 As Integer = TrackBar2.Value
        Dim tr(255) As Integer
        For i = 0 To 255
            tr(i) = i * tra2 / 100
        Next
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
            Dim rr, gg, bb As Integer
            Dim rgb As Integer
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                bb = rgbValues(k)
                gg = rgbValues(k + 1)
                rr = rgbValues(k + 2)
                rr = tr(rr)
                gg = tr(gg)
                bb = tr(bb)
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
                rgb = (rr + gg + bb) / 3
                If CheckBox2.Checked = True Then
                    If rgb > tra3 Then
                        rgbValues(k) = 255
                        rgbValues(k + 1) = 255
                        rgbValues(k + 2) = 255
                    Else
                        rgbValues(k) = 0
                        rgbValues(k + 1) = 0
                        rgbValues(k + 2) = 0
                    End If
                Else
                    If CheckBox1.Checked = True Then
                        rgbValues(k) = rgb
                        rgbValues(k + 1) = rgb
                        rgbValues(k + 2) = rgb
                    Else
                        rgbValues(k) = bb
                        rgbValues(k + 1) = gg
                        rgbValues(k + 2) = rr
                    End If
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
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim start_time As Date = Now
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
                rgbValues(k) = 255 - rgbValues(k)
                rgbValues(k + 1) = 255 - rgbValues(k + 1)
                rgbValues(k + 2) = 255 - rgbValues(k + 2)
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
        Form1.re2(Form1.re02) = Form1.PictureBox1.Image
        Form1.re02 += 1
        Form1.PictureBox1.Image = PictureBox1.Image
        Me.Close()
    End Sub
    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        Button2.PerformClick()
        Dim tra3 As Byte = TrackBar3.Value
        Dim tra As Single = TrackBar1.Value / 10
        Dim start_time As Date = Now
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
            Dim rr, gg, bb As Integer
            Dim tr1(255) As Integer
            For i = 0 To 255
                tr1(i) = i * tra
            Next
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                bb = rgbValues(k)
                gg = rgbValues(k + 1)
                rr = rgbValues(k + 2)
                rr = tr1(rr)
                gg = tr1(gg)
                bb = tr1(bb)
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
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
        System.GC.Collect()
        Button3.PerformClick()
        Dim tra2 As Integer = TrackBar2.Value
        Dim tr(255) As Integer
        For i = 0 To 255
            tr(i) = i * tra2 / 100
        Next
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
            Dim rr, gg, bb As Integer
            Dim rgb As Integer
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                bb = rgbValues(k)
                gg = rgbValues(k + 1)
                rr = rgbValues(k + 2)
                rr = tr(rr)
                gg = tr(gg)
                bb = tr(bb)
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
                rgb = (rr + gg + bb) / 3
                If CheckBox2.Checked = True Then
                    If rgb > tra3 Then
                        rgbValues(k) = 255
                        rgbValues(k + 1) = 255
                        rgbValues(k + 2) = 255
                    Else
                        rgbValues(k) = 0
                        rgbValues(k + 1) = 0
                        rgbValues(k + 2) = 0
                    End If
                Else
                    If CheckBox1.Checked = True Then
                        rgbValues(k) = rgb
                        rgbValues(k + 1) = rgb
                        rgbValues(k + 2) = rgb
                    Else
                        rgbValues(k) = bb
                        rgbValues(k + 1) = gg
                        rgbValues(k + 2) = rr
                    End If
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
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Button2.PerformClick()
        Dim tra3 As Byte = TrackBar3.Value
        Dim tra As Single = TrackBar1.Value / 10
        Dim start_time As Date = Now
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
            Dim rr, gg, bb As Integer
            Dim tr1(255) As Integer
            For i = 0 To 255
                tr1(i) = i * tra
            Next
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                bb = rgbValues(k)
                gg = rgbValues(k + 1)
                rr = rgbValues(k + 2)
                rr = tr1(rr)
                gg = tr1(gg)
                bb = tr1(bb)
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
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
        System.GC.Collect()
        Button3.PerformClick()
        Dim tra2 As Integer = TrackBar2.Value
        Dim tr(255) As Integer
        For i = 0 To 255
            tr(i) = i * tra2 / 100
        Next
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
            Dim rr, gg, bb As Integer
            Dim rgb As Integer
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                bb = rgbValues(k)
                gg = rgbValues(k + 1)
                rr = rgbValues(k + 2)
                rr = tr(rr)
                gg = tr(gg)
                bb = tr(bb)
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
                rgb = (rr + gg + bb) / 3
                If CheckBox2.Checked = True Then
                    If rgb > tra3 Then
                        rgbValues(k) = 255
                        rgbValues(k + 1) = 255
                        rgbValues(k + 2) = 255
                    Else
                        rgbValues(k) = 0
                        rgbValues(k + 1) = 0
                        rgbValues(k + 2) = 0
                    End If
                Else
                    If CheckBox1.Checked = True Then
                        rgbValues(k) = rgb
                        rgbValues(k + 1) = rgb
                        rgbValues(k + 2) = rgb
                    Else
                        rgbValues(k) = bb
                        rgbValues(k + 1) = gg
                        rgbValues(k + 2) = rr
                    End If
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
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Button2.PerformClick()
        Dim tra3 As Byte = TrackBar3.Value
        Dim tra As Single = TrackBar1.Value / 10
        Dim start_time As Date = Now
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
            Dim rr, gg, bb As Integer
            Dim tr1(255) As Integer
            For i = 0 To 255
                tr1(i) = i * tra
            Next
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                bb = rgbValues(k)
                gg = rgbValues(k + 1)
                rr = rgbValues(k + 2)
                rr = tr1(rr)
                gg = tr1(gg)
                bb = tr1(bb)
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
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
        System.GC.Collect()
        Button3.PerformClick()
        Dim tra2 As Integer = TrackBar2.Value
        Dim tr(255) As Integer
        For i = 0 To 255
            tr(i) = i * tra2 / 100
        Next
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
            Dim rr, gg, bb As Integer
            Dim rgb As Integer
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                bb = rgbValues(k)
                gg = rgbValues(k + 1)
                rr = rgbValues(k + 2)
                rr = tr(rr)
                gg = tr(gg)
                bb = tr(bb)
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
                rgb = (rr + gg + bb) / 3
                If CheckBox2.Checked = True Then
                    If rgb > tra3 Then
                        rgbValues(k) = 255
                        rgbValues(k + 1) = 255
                        rgbValues(k + 2) = 255
                    Else
                        rgbValues(k) = 0
                        rgbValues(k + 1) = 0
                        rgbValues(k + 2) = 0
                    End If
                Else
                    If CheckBox1.Checked = True Then
                        rgbValues(k) = rgb
                        rgbValues(k + 1) = rgb
                        rgbValues(k + 2) = rgb
                    Else
                        rgbValues(k) = bb
                        rgbValues(k + 1) = gg
                        rgbValues(k + 2) = rr
                    End If
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
    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        Button2.PerformClick()
        Dim tra3 As Byte = TrackBar3.Value
        Dim tra As Single = TrackBar1.Value / 10
        Dim start_time As Date = Now
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
            Dim rr, gg, bb As Integer
            Dim tr1(255) As Integer
            For i = 0 To 255
                tr1(i) = i * tra
            Next
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                bb = rgbValues(k)
                gg = rgbValues(k + 1)
                rr = rgbValues(k + 2)
                rr = tr1(rr)
                gg = tr1(gg)
                bb = tr1(bb)
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
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
        System.GC.Collect()
        Button3.PerformClick()
        Dim tra2 As Integer = TrackBar2.Value
        Dim tr(255) As Integer
        For i = 0 To 255
            tr(i) = i * tra2 / 100
        Next
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
            Dim rr, gg, bb As Integer
            Dim rgb As Integer
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                bb = rgbValues(k)
                gg = rgbValues(k + 1)
                rr = rgbValues(k + 2)
                rr = tr(rr)
                gg = tr(gg)
                bb = tr(bb)
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
                rgb = (rr + gg + bb) / 3
                If CheckBox2.Checked = True Then
                    If rgb > tra3 Then
                        rgbValues(k) = 255
                        rgbValues(k + 1) = 255
                        rgbValues(k + 2) = 255
                    Else
                        rgbValues(k) = 0
                        rgbValues(k + 1) = 0
                        rgbValues(k + 2) = 0
                    End If
                Else
                    If CheckBox1.Checked = True Then
                        rgbValues(k) = rgb
                        rgbValues(k + 1) = rgb
                        rgbValues(k + 2) = rgb
                    Else
                        rgbValues(k) = bb
                        rgbValues(k + 1) = gg
                        rgbValues(k + 2) = rr
                    End If
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