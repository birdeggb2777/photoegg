Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form20
    Private Sub Form20_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            RadioButton1.Text = "正向"
            RadioButton2.Text = "反向"
            Button1.Text = "確定"
            Me.Text = "顏色相減"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            RadioButton1.Text = "Positive"
            RadioButton2.Text = "Reverse"
            Button1.Text = "determine"
            Me.Text = "Color subtraction"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            RadioButton1.Text = "フォワード"
            RadioButton2.Text = "リバース"
            Button1.Text = "決定します"
            Me.Text = "減色"
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
        RadioButton1.Checked = True
    End Sub
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        Dim tra As Integer = TrackBar1.Value
        Dim tra2 As Integer = TrackBar2.Value
        Dim tra3 As Integer = TrackBar3.Value
        Dim ra As Byte
        If RadioButton1.Checked = True Then
            ra = 1
        Else
            ra = 2
        End If
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
            Dim rr, gg, bb As Integer
            For i = 1 To ra
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    bb = rgbValues(k)
                    gg = rgbValues(k + 1)
                    rr = rgbValues(k + 2)
                    rr = Math.Abs(rr - tra)
                    gg = Math.Abs(gg - tra2)
                    bb = Math.Abs(bb - tra3)
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

    Private Sub TrackBar2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar2.Scroll
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        Dim tra As Integer = TrackBar1.Value
        Dim tra2 As Integer = TrackBar2.Value
        Dim tra3 As Integer = TrackBar3.Value
        Dim ra As Byte
        If RadioButton1.Checked = True Then
            ra = 1
        Else
            ra = 2
        End If
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
            Dim rr, gg, bb As Integer
            For i = 1 To ra
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    bb = rgbValues(k)
                    gg = rgbValues(k + 1)
                    rr = rgbValues(k + 2)
                    rr = Math.Abs(rr - tra)
                    gg = Math.Abs(gg - tra2)
                    bb = Math.Abs(bb - tra3)
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

    Private Sub TrackBar3_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar3.Scroll
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        Dim tra As Integer = TrackBar1.Value
        Dim tra2 As Integer = TrackBar2.Value
        Dim tra3 As Integer = TrackBar3.Value
        Dim ra As Byte
        If RadioButton1.Checked = True Then
            ra = 1
        Else
            ra = 2
        End If
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
            Dim rr, gg, bb As Integer
            For i = 1 To ra
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    bb = rgbValues(k)
                    gg = rgbValues(k + 1)
                    rr = rgbValues(k + 2)
                    rr = Math.Abs(rr - tra)
                    gg = Math.Abs(gg - tra2)
                    bb = Math.Abs(bb - tra3)
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

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        Dim tra As Integer = TrackBar1.Value
        Dim tra2 As Integer = TrackBar2.Value
        Dim tra3 As Integer = TrackBar3.Value
        Dim ra As Byte
        If RadioButton1.Checked = True Then
            ra = 1
        Else
            ra = 2
        End If
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
            Dim rr, gg, bb As Integer
            For i = 1 To ra
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    bb = rgbValues(k)
                    gg = rgbValues(k + 1)
                    rr = rgbValues(k + 2)
                    rr = Math.Abs(rr - tra)
                    gg = Math.Abs(gg - tra2)
                    bb = Math.Abs(bb - tra3)
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

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        Dim tra As Integer = TrackBar1.Value
        Dim tra2 As Integer = TrackBar2.Value
        Dim tra3 As Integer = TrackBar3.Value
        Dim ra As Byte
        If RadioButton1.Checked = True Then
            ra = 1
        Else
            ra = 2
        End If
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
            Dim rr, gg, bb As Integer
            For i = 1 To ra
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    bb = rgbValues(k)
                    gg = rgbValues(k + 1)
                    rr = rgbValues(k + 2)
                    rr = Math.Abs(rr - tra)
                    gg = Math.Abs(gg - tra2)
                    bb = Math.Abs(bb - tra3)
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