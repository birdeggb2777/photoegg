Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form17
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.re2(Form1.re02) = Form1.PictureBox1.Image
        Form1.re02 += 1
        Form1.PictureBox1.Image = PictureBox1.Image
        Me.Close()
    End Sub
    Private Sub Form17_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Button1.Text = "確定"
            Me.Text = "彩度調整"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Button1.Text = "determine"
            Me.Text = "Saturation adjustment"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Button1.Text = "決定します"
            Me.Text = "彩度の調整"
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
    End Sub
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Dim tra As Byte = TrackBar1.Value
        Dim tra2 As Byte = TrackBar2.Value
        Dim tra3 As Byte = TrackBar3.Value
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
            Dim rr, gg, bb As Integer
            Dim rr0, gg0, bb0 As Integer
            Dim rr1, gg1, bb1 As Integer
            Dim rr2, gg2, bb2 As Integer
            Dim rr4, gg4, bb4 As Integer
            Dim rr5, gg5, bb5 As Integer
            Dim c As Integer
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                rr0 = rgbValues(k + 2)
                gg0 = rgbValues(k + 1)
                bb0 = rgbValues(k)
                bb = (bb0 + gg0 + rr0) / 6 + bb0 / 2
                gg = (bb0 + gg0 + rr0) / 6 + gg0 / 2
                rr = (bb0 + gg0 + rr0) / 6 + rr0 / 2
                bb4 = bb
                gg4 = gg
                rr4 = rr
                bb = (bb4 + gg4 + rr4) / 6 + bb4 / 2
                gg = (bb4 + gg4 + rr4) / 6 + gg4 / 2
                rr = (bb4 + gg4 + rr4) / 6 + rr4 / 2
                bb5 = bb
                gg5 = gg
                rr5 = rr
                bb = bb0
                gg = gg0
                rr = rr0
                c = (bb0 + gg0 + rr0) / 3
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
                bb2 = bb
                gg2 = gg
                rr2 = rr
                c = (bb + gg + rr) / 3
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
                bb1 = bb
                gg1 = gg
                rr1 = rr
                If tra = 1 Then
                    rgbValues(k + 2) = rr5
                ElseIf tra = 2 Then
                    rgbValues(k + 2) = rr4
                ElseIf tra = 3 Then
                    rgbValues(k + 2) = rr0
                ElseIf tra = 4 Then
                    rgbValues(k + 2) = rr2
                ElseIf tra = 5 Then
                    rgbValues(k + 2) = rr1
                End If
                If tra2 = 1 Then
                    rgbValues(k + 1) = gg5
                ElseIf tra2 = 2 Then
                    rgbValues(k + 1) = gg4
                ElseIf tra2 = 3 Then
                    rgbValues(k + 1) = gg0
                ElseIf tra2 = 4 Then
                    rgbValues(k + 1) = gg2
                ElseIf tra2 = 5 Then
                    rgbValues(k + 1) = gg1
                End If
                If tra3 = 1 Then
                    rgbValues(k) = bb5
                ElseIf tra3 = 2 Then
                    rgbValues(k) = bb4
                ElseIf tra3 = 3 Then
                    rgbValues(k) = bb0
                ElseIf tra3 = 4 Then
                    rgbValues(k) = bb2
                ElseIf tra3 = 5 Then
                    rgbValues(k) = bb1
                End If
            Next
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
    End Sub
    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        Dim tra As Byte = TrackBar1.Value
        Dim tra2 As Byte = TrackBar2.Value
        Dim tra3 As Byte = TrackBar3.Value
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
            Dim rr, gg, bb As Integer
            Dim rr0, gg0, bb0 As Integer
            Dim rr1, gg1, bb1 As Integer
            Dim rr2, gg2, bb2 As Integer
            Dim rr4, gg4, bb4 As Integer
            Dim rr5, gg5, bb5 As Integer
            Dim c As Integer
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                rr0 = rgbValues(k + 2)
                gg0 = rgbValues(k + 1)
                bb0 = rgbValues(k)
                bb = (bb0 + gg0 + rr0) / 6 + bb0 / 2
                gg = (bb0 + gg0 + rr0) / 6 + gg0 / 2
                rr = (bb0 + gg0 + rr0) / 6 + rr0 / 2
                bb4 = bb
                gg4 = gg
                rr4 = rr
                bb = (bb4 + gg4 + rr4) / 6 + bb4 / 2
                gg = (bb4 + gg4 + rr4) / 6 + gg4 / 2
                rr = (bb4 + gg4 + rr4) / 6 + rr4 / 2
                bb5 = bb
                gg5 = gg
                rr5 = rr
                bb = bb0
                gg = gg0
                rr = rr0
                c = (bb0 + gg0 + rr0) / 3
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
                bb2 = bb
                gg2 = gg
                rr2 = rr
                c = (bb + gg + rr) / 3
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
                bb1 = bb
                gg1 = gg
                rr1 = rr
                If tra = 1 Then
                    rgbValues(k + 2) = rr5
                ElseIf tra = 2 Then
                    rgbValues(k + 2) = rr4
                ElseIf tra = 3 Then
                    rgbValues(k + 2) = rr0
                ElseIf tra = 4 Then
                    rgbValues(k + 2) = rr2
                ElseIf tra = 5 Then
                    rgbValues(k + 2) = rr1
                End If
                If tra2 = 1 Then
                    rgbValues(k + 1) = gg5
                ElseIf tra2 = 2 Then
                    rgbValues(k + 1) = gg4
                ElseIf tra2 = 3 Then
                    rgbValues(k + 1) = gg0
                ElseIf tra2 = 4 Then
                    rgbValues(k + 1) = gg2
                ElseIf tra2 = 5 Then
                    rgbValues(k + 1) = gg1
                End If
                If tra3 = 1 Then
                    rgbValues(k) = bb5
                ElseIf tra3 = 2 Then
                    rgbValues(k) = bb4
                ElseIf tra3 = 3 Then
                    rgbValues(k) = bb0
                ElseIf tra3 = 4 Then
                    rgbValues(k) = bb2
                ElseIf tra3 = 5 Then
                    rgbValues(k) = bb1
                End If
            Next
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
    End Sub
    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        Dim tra As Byte = TrackBar1.Value
        Dim tra2 As Byte = TrackBar2.Value
        Dim tra3 As Byte = TrackBar3.Value
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
            Dim rr, gg, bb As Integer
            Dim rr0, gg0, bb0 As Integer
            Dim rr1, gg1, bb1 As Integer
            Dim rr2, gg2, bb2 As Integer
            Dim rr4, gg4, bb4 As Integer
            Dim rr5, gg5, bb5 As Integer
            Dim c As Integer
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                rr0 = rgbValues(k + 2)
                gg0 = rgbValues(k + 1)
                bb0 = rgbValues(k)
                bb = (bb0 + gg0 + rr0) / 6 + bb0 / 2
                gg = (bb0 + gg0 + rr0) / 6 + gg0 / 2
                rr = (bb0 + gg0 + rr0) / 6 + rr0 / 2
                bb4 = bb
                gg4 = gg
                rr4 = rr
                bb = (bb4 + gg4 + rr4) / 6 + bb4 / 2
                gg = (bb4 + gg4 + rr4) / 6 + gg4 / 2
                rr = (bb4 + gg4 + rr4) / 6 + rr4 / 2
                bb5 = bb
                gg5 = gg
                rr5 = rr
                bb = bb0
                gg = gg0
                rr = rr0
                c = (bb0 + gg0 + rr0) / 3
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
                bb2 = bb
                gg2 = gg
                rr2 = rr
                c = (bb + gg + rr) / 3
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
                bb1 = bb
                gg1 = gg
                rr1 = rr
                If tra = 1 Then
                    rgbValues(k + 2) = rr5
                ElseIf tra = 2 Then
                    rgbValues(k + 2) = rr4
                ElseIf tra = 3 Then
                    rgbValues(k + 2) = rr0
                ElseIf tra = 4 Then
                    rgbValues(k + 2) = rr2
                ElseIf tra = 5 Then
                    rgbValues(k + 2) = rr1
                End If
                If tra2 = 1 Then
                    rgbValues(k + 1) = gg5
                ElseIf tra2 = 2 Then
                    rgbValues(k + 1) = gg4
                ElseIf tra2 = 3 Then
                    rgbValues(k + 1) = gg0
                ElseIf tra2 = 4 Then
                    rgbValues(k + 1) = gg2
                ElseIf tra2 = 5 Then
                    rgbValues(k + 1) = gg1
                End If
                If tra3 = 1 Then
                    rgbValues(k) = bb5
                ElseIf tra3 = 2 Then
                    rgbValues(k) = bb4
                ElseIf tra3 = 3 Then
                    rgbValues(k) = bb0
                ElseIf tra3 = 4 Then
                    rgbValues(k) = bb2
                ElseIf tra3 = 5 Then
                    rgbValues(k) = bb1
                End If
            Next
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
    End Sub
End Class