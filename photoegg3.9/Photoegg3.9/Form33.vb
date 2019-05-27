Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form33
    Private Sub Form33_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "細節"
            Button1.Text = "確定"
            Me.Text = "素描"
            RadioButton1.Text = "彩色"
            RadioButton2.Text = "灰色"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "detail"
            Button1.Text = "determine"
            Me.Text = "sketch"
            RadioButton1.Text = "color"
            RadioButton2.Text = "gray"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "詳細"
            Button1.Text = "決定します"
            Me.Text = "スケッチ"
            RadioButton1.Text = "カラー"
            RadioButton2.Text = "グレー"
        End If
        Button1.BackColor = Form1.BackColor
        Me.BackColor = Form1.BackColor
        Me.ForeColor = Form1.ForeColor
        PictureBox1.Image = Form1.PictureBox1.Image
        PictureBox2.Image = Form1.PictureBox1.Image
        PictureBox3.Image = Form1.PictureBox1.Image
        Dim a As New Bitmap(PictureBox1.Image)
        PictureBox1.Size = New Size(Form1.PictureBox1.Width, Form1.PictureBox1.Height)
        PictureBox2.Size = New Size(a.Width, a.Height)
        PictureBox3.Size = New Size(a.Width, a.Height)
        Me.Width = a.Width + 500
        Me.Height = a.Height + 500
        PictureBox2.Left = -200
        PictureBox2.Hide()
        PictureBox3.Hide()
        Button2.Left = -200
        Button3.Left = -200
        Button4.Left = -200
        Button5.Left = -200
        RadioButton1.Checked = True
    End Sub
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        PictureBox1.Image = Form1.PictureBox1.Image
        Dim anti_alias As Boolean = True
        Dim mbitmap As Bitmap
        mbitmap = New Bitmap(PictureBox2.Image)
        PictureBox2.Image = mbitmap
        Dim wid As Integer = CInt(PictureBox2.Width / TrackBar1.Value)
        Dim hgt As Integer = CInt(PictureBox2.Height / TrackBar1.Value)
        Dim rBitmap As New Bitmap(wid, hgt)
        Dim gr As Graphics = Graphics.FromImage(rBitmap)
        If anti_alias Then gr.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBilinear
        gr.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        gr.DrawImage(mbitmap, 0, 0, wid - 1, hgt - 1)
        PictureBox3.Image = rBitmap
        PictureBox3.Size = New Size(wid, hgt)
        Button2.PerformClick()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim anti_alias As Boolean = True
        Dim mbitmap As Bitmap
        mbitmap = New Bitmap(PictureBox3.Image)
        PictureBox3.Image = mbitmap
        Dim wid As Integer = CInt(PictureBox2.Width)
        Dim hgt As Integer = CInt(PictureBox2.Height)
        Dim rBitmap As New Bitmap(wid, hgt)
        Dim gr As Graphics = Graphics.FromImage(rBitmap)
        If anti_alias Then gr.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBilinear
        gr.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        gr.DrawImage(mbitmap, 0, 0, wid - 1, hgt - 1)
        PictureBox1.Image = rBitmap
        System.GC.Collect()
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Integer
        Dim tra As Single = 10
        Dim tra2 As Integer = 10
        Try
            mbitmap = New Bitmap(PictureBox1.Image)
            Width = mbitmap.Width
            Height = mbitmap.Height
            Dim rect As New Rectangle(0, 0, Width, Height)
            Dim bmpData As BitmapData = mbitmap.LockBits(rect, ImageLockMode.ReadWrite, mbitmap.PixelFormat)
            Dim ptr As IntPtr = bmpData.Scan0
            Dim bytes As Integer = bmpData.Stride * Height
            With bmpData
            End With
            Dim Bpx As Byte = bmpData.Stride \ mbitmap.Width
            Dim rgbValues(bytes - 1) As Byte
            Marshal.Copy(ptr, rgbValues, 0, bytes)
            Dim rgb(255) As Integer
            For ii = 0 To 255
                For i = 0 To 255 Step 255 / tra
                    If ii > i Then rgb(ii) = i
                Next
            Next
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                rgbValues(k) = rgb(rgbValues(k))
                rgbValues(k + 1) = rgb(rgbValues(k + 1))
                rgbValues(k + 2) = rgb(rgbValues(k + 2))
            Next
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mbitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mbitmap
        System.GC.Collect()
        PictureBox2.Image = PictureBox1.Image
        PictureBox3.Image = PictureBox1.Image
        Button5.PerformClick()
        tra = 15
        Try
            mbitmap = New Bitmap(PictureBox1.Image)
            Width = mbitmap.Width
            Height = mbitmap.Height
            Dim rect As New Rectangle(0, 0, Width, Height)
            Dim bmpData As BitmapData = mbitmap.LockBits(rect, ImageLockMode.ReadWrite, mbitmap.PixelFormat)
            Dim ptr As IntPtr = bmpData.Scan0
            Dim bytes As Integer = bmpData.Stride * Height
            With bmpData
            End With
            Dim Bpx As Byte = bmpData.Stride \ mbitmap.Width
            Dim rgbValues(bytes - 1) As Byte
            Marshal.Copy(ptr, rgbValues, 0, bytes)
            Dim rr, gg, bb As Integer
            Dim rgb2(255) As Integer
            For i = 0 To 255
                rgb2(i) = i * 15
            Next
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                bb = rgbValues(k)
                gg = rgbValues(k + 1)
                rr = rgbValues(k + 2)
                rr = rgb2(rr) 'tra
                gg = rgb2(gg) 'tra
                bb = rgb2(bb) 'tra
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
            mbitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mbitmap
        System.GC.Collect()
        Button4.PerformClick()
        tra2 = 100
        Dim bbggrr As Integer
        Try
            mbitmap = New Bitmap(PictureBox1.Image)
            Width = mbitmap.Width
            Height = mbitmap.Height
            Dim rect As New Rectangle(0, 0, Width, Height)
            Dim bmpData As BitmapData = mbitmap.LockBits(rect, ImageLockMode.ReadWrite, mbitmap.PixelFormat)
            Dim ptr As IntPtr = bmpData.Scan0
            Dim bytes As Integer = bmpData.Stride * Height
            With bmpData
            End With
            Dim Bpx As Byte = bmpData.Stride \ mbitmap.Width
            Dim rgbValues(bytes - 1) As Byte
            Marshal.Copy(ptr, rgbValues, 0, bytes)
            Dim rr, gg, bb As Integer
            If RadioButton1.Checked = True Then
            Else
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    bb = rgbValues(k)
                    gg = rgbValues(k + 1)
                    rr = rgbValues(k + 2)
                    bbggrr = (bb + gg + rr) / 3
                    rgbValues(k) = bbggrr
                    rgbValues(k + 1) = bbggrr
                    rgbValues(k + 2) = bbggrr
                Next
            End If
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mbitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mbitmap
        System.GC.Collect()
        PictureBox2.Image = Form1.PictureBox1.Image
        PictureBox3.Image = Form1.PictureBox1.Image
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.re2(Form1.re02) = Form1.PictureBox1.Image
        Form1.re02 += 1
        Form1.PictureBox1.Image = PictureBox1.Image
        Me.Close()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
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
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
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
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim start_time As Date = Now
        Dim rr, gg, bb, rr2, gg2, bb2, rr3, gg3, bb3, rr4, gg4, bb4 As Integer
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        For z = 1 To 1
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
                Marshal.Copy(rgbValues, 0, ptr, bytes) '
                mBitmap.UnlockBits(bmpData)
                Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
                PictureBox1.Image = mBitmap
            Catch ex As SystemException
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        Next
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
                rgbValues(k) = bb
                rgbValues(k + 1) = gg
                rgbValues(k + 2) = rr
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
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        PictureBox1.Image = Form1.PictureBox1.Image
        Dim anti_alias As Boolean = True
        Dim mbitmap As Bitmap
        mbitmap = New Bitmap(PictureBox2.Image)
        PictureBox2.Image = mbitmap
        Dim wid As Integer = CInt(PictureBox2.Width / TrackBar1.Value)
        Dim hgt As Integer = CInt(PictureBox2.Height / TrackBar1.Value)
        Dim rBitmap As New Bitmap(wid, hgt)
        Dim gr As Graphics = Graphics.FromImage(rBitmap)
        If anti_alias Then gr.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBilinear
        gr.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        gr.DrawImage(mbitmap, 0, 0, wid - 1, hgt - 1)
        PictureBox3.Image = rBitmap
        PictureBox3.Size = New Size(wid, hgt)
        Button2.PerformClick()
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        PictureBox1.Image = Form1.PictureBox1.Image
        Dim anti_alias As Boolean = True
        Dim mbitmap As Bitmap
        mbitmap = New Bitmap(PictureBox2.Image)
        PictureBox2.Image = mbitmap
        Dim wid As Integer = CInt(PictureBox2.Width / TrackBar1.Value)
        Dim hgt As Integer = CInt(PictureBox2.Height / TrackBar1.Value)
        Dim rBitmap As New Bitmap(wid, hgt)
        Dim gr As Graphics = Graphics.FromImage(rBitmap)
        If anti_alias Then gr.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBilinear
        gr.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        gr.DrawImage(mbitmap, 0, 0, wid - 1, hgt - 1)
        PictureBox3.Image = rBitmap
        PictureBox3.Size = New Size(wid, hgt)
        Button2.PerformClick()
    End Sub
End Class