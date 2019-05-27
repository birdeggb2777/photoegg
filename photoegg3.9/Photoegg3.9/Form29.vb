Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form29
    Dim rrr, ggg, bbb As Integer
    Private Sub Form29_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Button1.Text = "確定"
            Me.Text = "色彩修正(平均值)"
            RadioButton1.Text = "正向"
            RadioButton2.Text = "反向"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Button1.Text = "determine"
            Me.Text = "Color Correction (average value)"
            RadioButton1.Text = "Positive"
            RadioButton2.Text = "Reverse"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Button1.Text = "決定します"
            Me.Text = "色補正（平均値)"
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
        Dim start_time As Date = Now
        Dim rr, gg, bb As Long
        Dim rgb As Integer = 127
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
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                bb += rgbValues(k)
                gg += rgbValues(k + 1)
                rr += rgbValues(k + 2)
            Next
            rrr = rr / (rgbValues.Length / 4)
            ggg = gg / (rgbValues.Length / 4)
            bbb = bb / (rgbValues.Length / 4)
            Marshal.Copy(rgbValues, 0, ptr, bytes)
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        System.GC.Collect()
        TrackBar1.Value = rrr
        TrackBar2.Value = ggg
        TrackBar3.Value = bbb
        If (rrr + ggg + bbb) / 3 < 127 Then
            RadioButton1.Checked = True
        Else
            RadioButton2.Checked = True
        End If
    End Sub
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Dim tra As Single = TrackBar1.Value
        Dim tra2 As Single = TrackBar2.Value
        Dim tra3 As Single = TrackBar3.Value
        Dim start_time As Date = Now
        Dim r, g, b As Integer
        Dim rr As Long = rrr, gg As Long = ggg, bb As Long = bbb
        Dim rgb As Integer = 127
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        If RadioButton1.Checked = True Then
            tra = tra / rr
            tra2 = tra2 / gg
            tra3 = tra3 / bb
            Dim r1(255) As Integer, g1(255) As Integer, b1(255) As Integer
            For i = 0 To 255
                r1(i) = i * tra
                g1(i) = i * tra2
                b1(i) = i * tra3
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
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    b = rgbValues(k)
                    g = rgbValues(k + 1)
                    r = rgbValues(k + 2)
                    r = r1(r)
                    g = g1(g)
                    b = b1(b)
                    If r > 255 Then
                        r = 255
                    End If
                    If g > 255 Then
                        g = 255
                    End If
                    If b > 255 Then
                        b = 255
                    End If
                    If r < 0 Then
                        r = 0
                    End If
                    If g < 0 Then
                        g = 0
                    End If
                    If b < 0 Then
                        b = 0
                    End If
                    rgbValues(k) = b
                    rgbValues(k + 1) = g
                    rgbValues(k + 2) = r
                Next
                Marshal.Copy(rgbValues, 0, ptr, bytes)
                mBitmap.UnlockBits(bmpData)
                Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
            Catch ex As SystemException
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        Else
            tra = (255 - tra) / (255 - rr)
            tra2 = (255 - tra2) / (255 - gg)
            tra3 = (255 - tra3) / (255 - bb)
            Dim r1(255) As Integer, g1(255) As Integer, b1(255) As Integer
            For i = 0 To 255
                r1(i) = i * tra
                g1(i) = i * tra2
                b1(i) = i * tra3
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
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    b = 255 - rgbValues(k)
                    g = 255 - rgbValues(k + 1)
                    r = 255 - rgbValues(k + 2)
                    r = r1(r)
                    g = g1(g)
                    b = b1(b)
                    If r > 255 Then
                        r = 255
                    End If
                    If g > 255 Then
                        g = 255
                    End If
                    If b > 255 Then
                        b = 255
                    End If
                    If r < 0 Then
                        r = 0
                    End If
                    If g < 0 Then
                        g = 0
                    End If
                    If b < 0 Then
                        b = 0
                    End If
                    rgbValues(k) = 255 - b
                    rgbValues(k + 1) = 255 - g
                    rgbValues(k + 2) = 255 - r
                Next
                Marshal.Copy(rgbValues, 0, ptr, bytes)
                mBitmap.UnlockBits(bmpData)
                Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
            Catch ex As SystemException
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
        PictureBox1.Image = mBitmap
        System.GC.Collect()
    End Sub
    Private Sub TrackBar2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar2.Scroll
        Dim tra As Single = TrackBar1.Value
        Dim tra2 As Single = TrackBar2.Value
        Dim tra3 As Single = TrackBar3.Value
        Dim start_time As Date = Now
        Dim r, g, b As Integer
        Dim rr As Long = rrr, gg As Long = ggg, bb As Long = bbb
        Dim rgb As Integer = 127
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        If RadioButton1.Checked = True Then
            tra = tra / rr
            tra2 = tra2 / gg
            tra3 = tra3 / bb
            Dim r1(255) As Integer, g1(255) As Integer, b1(255) As Integer
            For i = 0 To 255
                r1(i) = i * tra
                g1(i) = i * tra2
                b1(i) = i * tra3
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
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    b = rgbValues(k)
                    g = rgbValues(k + 1)
                    r = rgbValues(k + 2)
                    r = r1(r)
                    g = g1(g)
                    b = b1(b)
                    If r > 255 Then
                        r = 255
                    End If
                    If g > 255 Then
                        g = 255
                    End If
                    If b > 255 Then
                        b = 255
                    End If
                    If r < 0 Then
                        r = 0
                    End If
                    If g < 0 Then
                        g = 0
                    End If
                    If b < 0 Then
                        b = 0
                    End If
                    rgbValues(k) = b
                    rgbValues(k + 1) = g
                    rgbValues(k + 2) = r
                Next
                Marshal.Copy(rgbValues, 0, ptr, bytes)
                mBitmap.UnlockBits(bmpData)
                Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
            Catch ex As SystemException
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        Else
            tra = (255 - tra) / (255 - rr)
            tra2 = (255 - tra2) / (255 - gg)
            tra3 = (255 - tra3) / (255 - bb)
            Dim r1(255) As Integer, g1(255) As Integer, b1(255) As Integer
            For i = 0 To 255
                r1(i) = i * tra
                g1(i) = i * tra2
                b1(i) = i * tra3
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
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    b = 255 - rgbValues(k)
                    g = 255 - rgbValues(k + 1)
                    r = 255 - rgbValues(k + 2)
                    r = r1(r)
                    g = g1(g)
                    b = b1(b)
                    If r > 255 Then
                        r = 255
                    End If
                    If g > 255 Then
                        g = 255
                    End If
                    If b > 255 Then
                        b = 255
                    End If
                    If r < 0 Then
                        r = 0
                    End If
                    If g < 0 Then
                        g = 0
                    End If
                    If b < 0 Then
                        b = 0
                    End If
                    rgbValues(k) = 255 - b
                    rgbValues(k + 1) = 255 - g
                    rgbValues(k + 2) = 255 - r
                Next
                Marshal.Copy(rgbValues, 0, ptr, bytes)
                mBitmap.UnlockBits(bmpData)
                Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
            Catch ex As SystemException
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
        PictureBox1.Image = mBitmap
        System.GC.Collect()
    End Sub
    Private Sub TrackBar3_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar3.Scroll
        Dim tra As Single = TrackBar1.Value
        Dim tra2 As Single = TrackBar2.Value
        Dim tra3 As Single = TrackBar3.Value
        Dim start_time As Date = Now
        Dim r, g, b As Integer
        Dim rr As Long = rrr, gg As Long = ggg, bb As Long = bbb
        Dim rgb As Integer = 127
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        If RadioButton1.Checked = True Then
            tra = tra / rr
            tra2 = tra2 / gg
            tra3 = tra3 / bb
            Dim r1(255) As Integer, g1(255) As Integer, b1(255) As Integer
            For i = 0 To 255
                r1(i) = i * tra
                g1(i) = i * tra2
                b1(i) = i * tra3
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
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    b = rgbValues(k)
                    g = rgbValues(k + 1)
                    r = rgbValues(k + 2)
                    r = r1(r)
                    g = g1(g)
                    b = b1(b)
                    If r > 255 Then
                        r = 255
                    End If
                    If g > 255 Then
                        g = 255
                    End If
                    If b > 255 Then
                        b = 255
                    End If
                    If r < 0 Then
                        r = 0
                    End If
                    If g < 0 Then
                        g = 0
                    End If
                    If b < 0 Then
                        b = 0
                    End If
                    rgbValues(k) = b
                    rgbValues(k + 1) = g
                    rgbValues(k + 2) = r
                Next
                Marshal.Copy(rgbValues, 0, ptr, bytes)
                mBitmap.UnlockBits(bmpData)
                Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
            Catch ex As SystemException
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        Else
            tra = (255 - tra) / (255 - rr)
            tra2 = (255 - tra2) / (255 - gg)
            tra3 = (255 - tra3) / (255 - bb)
            Dim r1(255) As Integer, g1(255) As Integer, b1(255) As Integer
            For i = 0 To 255
                r1(i) = i * tra
                g1(i) = i * tra2
                b1(i) = i * tra3
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
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    b = 255 - rgbValues(k)
                    g = 255 - rgbValues(k + 1)
                    r = 255 - rgbValues(k + 2)
                    r = r1(r)
                    g = g1(g)
                    b = b1(b)
                    If r > 255 Then
                        r = 255
                    End If
                    If g > 255 Then
                        g = 255
                    End If
                    If b > 255 Then
                        b = 255
                    End If
                    If r < 0 Then
                        r = 0
                    End If
                    If g < 0 Then
                        g = 0
                    End If
                    If b < 0 Then
                        b = 0
                    End If
                    rgbValues(k) = 255 - b
                    rgbValues(k + 1) = 255 - g
                    rgbValues(k + 2) = 255 - r
                Next
                Marshal.Copy(rgbValues, 0, ptr, bytes)
                mBitmap.UnlockBits(bmpData)
                Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
            Catch ex As SystemException
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
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
        Dim tra As Single = TrackBar1.Value
        Dim tra2 As Single = TrackBar2.Value
        Dim tra3 As Single = TrackBar3.Value
        Dim start_time As Date = Now
        Dim r, g, b As Integer
        Dim rr As Long = rrr, gg As Long = ggg, bb As Long = bbb
        Dim rgb As Integer = 127
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        If RadioButton1.Checked = True Then
            tra = tra / rr
            tra2 = tra2 / gg
            tra3 = tra3 / bb
            Dim r1(255) As Integer, g1(255) As Integer, b1(255) As Integer
            For i = 0 To 255
                r1(i) = i * tra
                g1(i) = i * tra2
                b1(i) = i * tra3
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
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    b = rgbValues(k)
                    g = rgbValues(k + 1)
                    r = rgbValues(k + 2)
                    r = r1(r)
                    g = g1(g)
                    b = b1(b)
                    If r > 255 Then
                        r = 255
                    End If
                    If g > 255 Then
                        g = 255
                    End If
                    If b > 255 Then
                        b = 255
                    End If
                    If r < 0 Then
                        r = 0
                    End If
                    If g < 0 Then
                        g = 0
                    End If
                    If b < 0 Then
                        b = 0
                    End If
                    rgbValues(k) = b
                    rgbValues(k + 1) = g
                    rgbValues(k + 2) = r
                Next
                Marshal.Copy(rgbValues, 0, ptr, bytes)
                mBitmap.UnlockBits(bmpData)
                Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
            Catch ex As SystemException
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        Else
            tra = (255 - tra) / (255 - rr)
            tra2 = (255 - tra2) / (255 - gg)
            tra3 = (255 - tra3) / (255 - bb)
            Dim r1(255) As Integer, g1(255) As Integer, b1(255) As Integer
            For i = 0 To 255
                r1(i) = i * tra
                g1(i) = i * tra2
                b1(i) = i * tra3
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
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    b = 255 - rgbValues(k)
                    g = 255 - rgbValues(k + 1)
                    r = 255 - rgbValues(k + 2)
                    r = r1(r)
                    g = g1(g)
                    b = b1(b)
                    If r > 255 Then
                        r = 255
                    End If
                    If g > 255 Then
                        g = 255
                    End If
                    If b > 255 Then
                        b = 255
                    End If
                    If r < 0 Then
                        r = 0
                    End If
                    If g < 0 Then
                        g = 0
                    End If
                    If b < 0 Then
                        b = 0
                    End If
                    rgbValues(k) = 255 - b
                    rgbValues(k + 1) = 255 - g
                    rgbValues(k + 2) = 255 - r
                Next
                Marshal.Copy(rgbValues, 0, ptr, bytes)
                mBitmap.UnlockBits(bmpData)
                Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
            Catch ex As SystemException
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
        PictureBox1.Image = mBitmap
        System.GC.Collect()
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Dim tra As Single = TrackBar1.Value
        Dim tra2 As Single = TrackBar2.Value
        Dim tra3 As Single = TrackBar3.Value
        Dim start_time As Date = Now
        Dim r, g, b As Integer
        Dim rr As Long = rrr, gg As Long = ggg, bb As Long = bbb
        Dim rgb As Integer = 127
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        If RadioButton1.Checked = True Then
            tra = tra / rr
            tra2 = tra2 / gg
            tra3 = tra3 / bb
            Dim r1(255) As Integer, g1(255) As Integer, b1(255) As Integer
            For i = 0 To 255
                r1(i) = i * tra
                g1(i) = i * tra2
                b1(i) = i * tra3
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
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    b = rgbValues(k)
                    g = rgbValues(k + 1)
                    r = rgbValues(k + 2)
                    r = r1(r)
                    g = g1(g)
                    b = b1(b)
                    If r > 255 Then
                        r = 255
                    End If
                    If g > 255 Then
                        g = 255
                    End If
                    If b > 255 Then
                        b = 255
                    End If
                    If r < 0 Then
                        r = 0
                    End If
                    If g < 0 Then
                        g = 0
                    End If
                    If b < 0 Then
                        b = 0
                    End If
                    rgbValues(k) = b
                    rgbValues(k + 1) = g
                    rgbValues(k + 2) = r
                Next
                Marshal.Copy(rgbValues, 0, ptr, bytes)
                mBitmap.UnlockBits(bmpData)
                Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
            Catch ex As SystemException
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        Else
            tra = (255 - tra) / (255 - rr)
            tra2 = (255 - tra2) / (255 - gg)
            tra3 = (255 - tra3) / (255 - bb)
            Dim r1(255) As Integer, g1(255) As Integer, b1(255) As Integer
            For i = 0 To 255
                r1(i) = i * tra
                g1(i) = i * tra2
                b1(i) = i * tra3
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
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    b = 255 - rgbValues(k)
                    g = 255 - rgbValues(k + 1)
                    r = 255 - rgbValues(k + 2)
                    r = r1(r)
                    g = g1(g)
                    b = b1(b)
                    If r > 255 Then
                        r = 255
                    End If
                    If g > 255 Then
                        g = 255
                    End If
                    If b > 255 Then
                        b = 255
                    End If
                    If r < 0 Then
                        r = 0
                    End If
                    If g < 0 Then
                        g = 0
                    End If
                    If b < 0 Then
                        b = 0
                    End If
                    rgbValues(k) = 255 - b
                    rgbValues(k + 1) = 255 - g
                    rgbValues(k + 2) = 255 - r
                Next
                Marshal.Copy(rgbValues, 0, ptr, bytes)
                mBitmap.UnlockBits(bmpData)
                Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
            Catch ex As SystemException
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
        PictureBox1.Image = mBitmap
        System.GC.Collect()
    End Sub
End Class