Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form1
    Dim re02 As Integer = 0
    Dim re(1) As Image
    Dim re2(5000) As Image
    Dim X, Y As Integer
    Dim x2, y2 As Object
    Dim draw0 As Byte = 0
    Dim penbig As Byte = 1
    Dim penstyle As Byte = 1
    Dim pics As Byte = 2
    Public rrrr As Integer = 50
    Public tttt As Integer = 50
    Private Sub 匯入圖片ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 匯入圖片ToolStripMenuItem.Click
        Dim ya As Byte
        ya = MsgBox("加入新的圖片會更新所有圖層和環原點，是否繼續?", MsgBoxStyle.YesNo, "匯入圖片")
        If ya = 6 Then
            OpenFileDialog1.Filter = "圖片檔 (*.png;*.jpg;*.bmp;*.gif)|*.png;*.jpg;*.bmp;*.gif"
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
                Dim a As New Bitmap(OpenFileDialog1.FileName)
                PictureBox1.Image = a
                Dim r As Integer
                r = a.Width
                Dim t As Integer
                t = a.Height
                rrrr = a.Width
                tttt = a.Height
                PictureBox1.Size = New Size(r, t)
                re(0) = PictureBox1.Image
                PictureBox3.Image = PictureBox1.Image
                re02 = 0
                re2(re02) = PictureBox1.Image
                re02 += 1
            End If
        End If
    End Sub
    Private Sub 複製圖片ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 複製圖片ToolStripMenuItem.Click
        On Error Resume Next
        My.Computer.Clipboard.SetImage(PictureBox1.Image)
    End Sub
    Private Sub 貼上圖片ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 貼上圖片ToolStripMenuItem.Click
        Dim ya As Byte
        ya = MsgBox("加入新的圖片會更新所有圖層和環原點，是否繼續?", MsgBoxStyle.YesNo, "貼上圖片")
        If ya = 6 Then
            Try
                Dim a As New Bitmap(My.Computer.Clipboard.GetImage)
                PictureBox1.Image = a
                Dim r As Integer
                r = a.Width
                Dim t As Integer
                t = a.Height
                PictureBox1.Size = New Size(r, t)
                re(0) = PictureBox1.Image
                PictureBox3.Image = PictureBox1.Image
                re02 = 0
                re2(re02) = PictureBox1.Image
                re02 += 1
                rrrr = a.Width
                tttt = a.Height
            Catch
                MsgBox("貼上圖片失敗，請確認剪貼簿中是否有圖片")
            End Try
        End If
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawImage(PictureBox1.Image, 0, 0)
    End Sub
    Private Sub 列印圖片ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 列印圖片ToolStripMenuItem.Click
        On Error Resume Next
        PictureBox1.Width = rrrr
        PictureBox1.Height = tttt
        PrintDocument1.Print()
        If Label8.Text = 100 Then
            PictureBox1.Width = rrrr
            PictureBox1.Height = tttt
        ElseIf Label8.Text = 50 Then
            PictureBox1.Width = rrrr / 2
            PictureBox1.Height = tttt / 2
        ElseIf Label8.Text = 25 Then
            PictureBox1.Width = rrrr / 4
            PictureBox1.Height = tttt / 4
        ElseIf Label8.Text = 12 Then
            PictureBox1.Width = rrrr / 8
            PictureBox1.Height = tttt / 8
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        解除選擇ToolStripMenuItem.Enabled = False
        Button1.Left = -500
        Me.BackColor = Color.RoyalBlue
        Me.ForeColor = Color.Orange
        MenuStrip1.ForeColor = Color.Black
        MenuStrip1.BackColor = Color.LightSteelBlue
        PictureBox1.Image = My.Resources.白紙
        re(0) = PictureBox1.Image
        PictureBox3.Image = PictureBox1.Image
        Me.WindowState = 2
        PrintDialog1.Document = PrintDocument1
        PictureBox1.Size = New Size(PictureBox1.Image.Width, PictureBox1.Image.Height)
        PictureBox2.Image = PictureBox1.Image
        PictureBox4.Image = PictureBox1.Image
        色相1ToolStripMenuItem.PerformClick()
        ToolStripMenuItem2.PerformClick()
        圖層二預設ToolStripMenuItem.PerformClick()
        rrrr = PictureBox1.Width
        tttt = PictureBox1.Height
        Me.Icon = My.Resources.photoegglogo
    End Sub
    Private Sub 對比色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 對比色ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim start_time As Date = Now
        Dim R As Byte, G As Byte, B As Byte
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
                B = CByte(255 - rgbValues(k))
                G = CByte(255 - rgbValues(k + 1))
                R = CByte(255 - rgbValues(k + 2))
                rgbValues(k) = B
                rgbValues(k + 1) = G
                rgbValues(k + 2) = R
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
    Private Sub 灰階ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 灰階ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim start_time As Date = Now
        Dim R As Byte, G As Byte, B As Byte
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
                Dim rr, gg, bb As Integer
                bb = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3)
                gg = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3)
                rr = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3)
                B = CByte(bb)
                G = CByte(gg)
                R = CByte(rr)
                rgbValues(k) = B
                rgbValues(k + 1) = G
                rgbValues(k + 2) = R
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
    Private Sub 浮雕ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 浮雕ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form2
        w.ShowDialog()
    End Sub
    Private Sub 油漆ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 油漆ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form27
        w.ShowDialog()
    End Sub
    Private Sub 版畫ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 版畫ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form4
        w.ShowDialog()
    End Sub
    Private Sub 色相ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 色相ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form5
        w.ShowDialog()
    End Sub
    Private Sub 模糊ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 模糊ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form6
        w.ShowDialog()
    End Sub
    Private Sub 玻璃ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 玻璃ToolStripMenuItem.Click
        PictureBox1.Width = rrrr
        PictureBox1.Height = tttt
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim start_time As Date = Now
        Dim R As Byte, G As Byte, B As Byte
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
            Dim c As Integer
            Dim widt As Integer = PictureBox1.Width
            Dim tra As Byte = 10
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
        PictureBox1.Image = mBitmap
        For z = 1 To 3
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
                Dim rr, gg, bb, rr2, gg2, bb2, rr3, gg3, bb3, rr4, gg4, bb4 As Integer
                Dim widt As Integer = PictureBox1.Width
                For k As Integer = widt * 4 * 5 + 4 To rgbValues.Length - Bpx - widt * 4 * 5 - 4 Step Bpx
                    bb = CByte(rgbValues(k - 4 * 5))
                    gg = CByte(rgbValues(k + 1 - 4 * 5))
                    rr = CByte(rgbValues(k + 2 - 4 * 5))
                    bb2 = CByte(rgbValues(k + widt * 4 * 5))
                    gg2 = CByte(rgbValues(k + 1 + widt * 4 * 5))
                    rr2 = CByte(rgbValues(k + 2 + widt * 4 * 5))
                    bb3 = CByte(rgbValues(k - widt * 4 * 5))
                    gg3 = CByte(rgbValues(k + 1 - widt * 4 * 5))
                    rr3 = CByte(rgbValues(k + 2 - widt * 4 * 5))
                    bb4 = CByte(rgbValues(k + 20))
                    gg4 = CByte(rgbValues(k + 1 + 20))
                    rr4 = CByte(rgbValues(k + 2 + 20))
                    rgbValues(k) = (bb + bb2 + bb3 + bb4) / 4
                    rgbValues(k + 1) = (gg + gg2 + gg3 + gg4) / 4
                    rgbValues(k + 2) = (rr + rr2 + rr3 + rr4) / 4
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
        Next
        PictureBox1.Image = mBitmap
        System.GC.Collect()
        If Label8.Text = 100 Then
            PictureBox1.Width = rrrr
            PictureBox1.Height = tttt
        ElseIf Label8.Text = 50 Then
            PictureBox1.Width = rrrr / 2
            PictureBox1.Height = tttt / 2
        ElseIf Label8.Text = 25 Then
            PictureBox1.Width = rrrr / 4
            PictureBox1.Height = tttt / 4
        ElseIf Label8.Text = 12 Then
            PictureBox1.Width = rrrr / 8
            PictureBox1.Height = tttt / 8
        End If
    End Sub
    Private Sub 幻彩ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 幻彩ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form7
        w.ShowDialog()
    End Sub
    Private Sub 線稿ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 線稿ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        '  Dim w As New Form8
        '  w.ShowDialog()
        Dim start_time As Date = Now
        Dim rr, gg, bb, rr2, gg2, bb2, rr3, gg3, bb3, rr4, gg4, bb4 As Integer
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        PictureBox2.Image = PictureBox1.Image
        For z = 1 To 10
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
                ' Dim rr, gg, bb, rr2, gg2, bb2, rr3, gg3, bb3, rr4, gg4, bb4 As Integer
                Dim widt As Integer = PictureBox1.Width
                Dim ll As Integer = rgbValues.Length
                For k As Integer = widt * 4 * 5 + 4 To ll - Bpx - widt * 4 * 5 - 4 Step Bpx
                    bb = CByte(rgbValues(k - 4))
                    gg = CByte(rgbValues(k + 1 - 4))
                    rr = CByte(rgbValues(k + 2 - 4))
                    bb2 = CByte(rgbValues(k + widt * 4))
                    gg2 = CByte(rgbValues(k + 1 + widt * 4))
                    rr2 = CByte(rgbValues(k + 2 + widt * 4))
                    bb3 = CByte(rgbValues(k - widt * 4))
                    gg3 = CByte(rgbValues(k + 1 - widt * 4))
                    rr3 = CByte(rgbValues(k + 2 - widt * 4))
                    bb4 = CByte(rgbValues(k + 4))
                    gg4 = CByte(rgbValues(k + 5))
                    rr4 = CByte(rgbValues(k + 6))
                    rgbValues(k) = (bb + bb2 + bb3 + bb4) / 4
                    rgbValues(k + 1) = (gg + gg2 + gg3 + gg4) / 4
                    rgbValues(k + 2) = (rr + rr2 + rr3 + rr4) / 4
                    If Bpx = 4 Then
                        rgbA = rgbValues(k + 3)
                    End If
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
            Dim bmpData2 As BitmapData = mBitmap2.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
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
            Dim rgbA As Byte
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                Bb = rgbValues(k)
                Gg = rgbValues(k + 1)
                Rr = rgbValues(k + 2)
                bb2 = rgbValues2(k)
                gg2 = rgbValues2(k + 1)
                rr2 = rgbValues2(k + 2)
                Rr = Math.Abs(Rr - rr2)
                Gg = Math.Abs(Gg - gg2)
                Bb = Math.Abs(Bb - bb2)
                If Rr > 255 Then Rr = 255
                If Gg > 255 Then Gg = 255
                If Bb > 255 Then Bb = 255
                If Rr < 0 Then Rr = 0
                If Gg < 0 Then Gg = 0
                If Bb < 0 Then Bb = 0
                rgbValues(k) = Bb
                rgbValues(k + 1) = Gg
                rgbValues(k + 2) = Rr
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
        對比色ToolStripMenuItem.PerformClick()
        System.GC.Collect()
        re2(re02 - 1) = Nothing
        re02 -= 1
    End Sub
    Private Sub 縮放圖片ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 縮放圖片ToolStripMenuItem.Click
        Dim ya As Byte
        ya = MsgBox("使用此功能會更新所有圖層和環原點，是否繼續?", MsgBoxStyle.YesNo, "縮小圖片")
        If ya = 6 Then
            PictureBox1.Width = rrrr
            PictureBox1.Height = tttt
            Dim w As New Form9
            w.ShowDialog()
            re02 = 0
        End If
    End Sub
    Private Sub 縮放模糊ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 縮放模糊ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form10
        w.ShowDialog()
    End Sub
    Private Sub 一般噴槍ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 一般噴槍ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form11
        w.ShowDialog()
    End Sub
    Private Sub 彩色噴槍ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 彩色噴槍ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form12
        w.ShowDialog()
    End Sub
    Private Sub 彩色雜點ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 彩色雜點ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form13
        w.ShowDialog()
    End Sub
    Private Sub 色彩修正加減ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 色彩修正加減ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form15
        w.ShowDialog()
    End Sub
    Private Sub 增加顏色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 增加顏色ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form14
        w.ShowDialog()
    End Sub
    Private Sub 色彩修正百分比ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 色彩修正百分比ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form16
        w.ShowDialog()
    End Sub
    Private Sub 飽和度ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 飽和度ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form17
        w.ShowDialog()
    End Sub
    Private Sub 復古ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 復古ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
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
                Dim rr, gg, bb As Integer
                bb = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3)
                gg = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3)
                rr = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3)
                rr += 30
                bb -= 30
                If rr > 255 Then rr = 255
                If bb < 0 Then bb = 0
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
    End Sub
    Private Sub 圖片加密程式ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 圖片加密程式ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form18
        w.ShowDialog()
    End Sub
    Private Sub 放大圖片ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 放大圖片ToolStripMenuItem.Click
        Dim ya As Byte
        ya = MsgBox("使用此功能會更新所有圖層和環原點，是否繼續?", MsgBoxStyle.YesNo, "放大圖片")
        If ya = 6 Then
            PictureBox1.Width = rrrr
            PictureBox1.Height = tttt
            Dim w As New Form19
            w.ShowDialog()
            re02 = 0
        End If
    End Sub
    Private Sub 建立還原點ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 建立還原點ToolStripMenuItem.Click
        re(0) = PictureBox1.Image
    End Sub
    Private Sub 恢復自還原點ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 恢復自還原點ToolStripMenuItem.Click
        re(1) = PictureBox1.Image
        PictureBox1.Image = re(0)
        re(0) = re(1)
    End Sub
    Private Sub 複製圖片到圖層3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 複製圖片到圖層3ToolStripMenuItem.Click
        PictureBox3.Image = PictureBox1.Image
    End Sub
    Private Sub 圖層一和圖層三ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 圖層一和圖層三ToolStripMenuItem.Click
        re(1) = PictureBox1.Image
        PictureBox1.Image = PictureBox3.Image
        PictureBox3.Image = re(1)
    End Sub
    Private Sub 色相1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 色相1ToolStripMenuItem.Click
        If 語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "畫筆:色相1"
        ElseIf 語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "brush:Hue1"
        ElseIf 語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "ブラシ:フエ1"
        End If
        penstyle = 1
        Label7.Text = Label1.Text & "  " & Label3.Text & "  " & Label5.Text
    End Sub
    Private Sub 色相2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 色相2ToolStripMenuItem.Click
        If 語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "畫筆:色相2"
        ElseIf 語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "brush:Hue2"
        ElseIf 語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "ブラシ:フエ2"
        End If
        penstyle = 2
        Label7.Text = Label1.Text & "  " & Label3.Text & "  " & Label5.Text
    End Sub
    Private Sub 色相3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 色相3ToolStripMenuItem.Click
        If 語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "畫筆:色相3"
        ElseIf 語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "brush:Hue3"
        ElseIf 語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "ブラシ:フエ3"
        End If
        penstyle = 3
        Label7.Text = Label1.Text & "  " & Label3.Text & "  " & Label5.Text
    End Sub
    Private Sub 色相4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 色相4ToolStripMenuItem.Click
        If 語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "畫筆:色相4"
        ElseIf 語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "brush:Hue4"
        ElseIf 語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "ブラシ:フエ4"
        End If
        penstyle = 4
        Label7.Text = Label1.Text & "  " & Label3.Text & "  " & Label5.Text
    End Sub
    Private Sub 色相5ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 色相5ToolStripMenuItem.Click
        If 語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "畫筆:色相5"
        ElseIf 語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "brush:Hue5"
        ElseIf 語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "ブラシ:フエ5"
        End If
        penstyle = 5
        Label7.Text = Label1.Text & "  " & Label3.Text & "  " & Label5.Text
    End Sub
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
       If 語言ToolStripMenuItem.Text = "語言" Then
            Label3.Text = "大小:1"
        ElseIf 語言ToolStripMenuItem.Text = "Language" Then
            Label3.Text = "size:1"
        ElseIf 語言ToolStripMenuItem.Text = "言語" Then
            Label3.Text = "サイズ:1"
        End If
        penbig = 1
        Label7.Text = Label1.Text & "  " & Label3.Text & "  " & Label5.Text
    End Sub
    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        If 語言ToolStripMenuItem.Text = "語言" Then
            Label3.Text = "大小:3"
        ElseIf 語言ToolStripMenuItem.Text = "Language" Then
            Label3.Text = "size:3"
        ElseIf 語言ToolStripMenuItem.Text = "言語" Then
            Label3.Text = "サイズ:3"
        End If
        penbig = 3
        Label7.Text = Label1.Text & "  " & Label3.Text & "  " & Label5.Text
    End Sub
    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        If 語言ToolStripMenuItem.Text = "語言" Then
            Label3.Text = "大小:5"
        ElseIf 語言ToolStripMenuItem.Text = "Language" Then
            Label3.Text = "size:5"
        ElseIf 語言ToolStripMenuItem.Text = "言語" Then
            Label3.Text = "サイズ:5"
        End If
        penbig = 5
        Label7.Text = Label1.Text & "  " & Label3.Text & "  " & Label5.Text
    End Sub
    Private Sub 圖層一連續塗抹ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 圖層一連續塗抹ToolStripMenuItem.Click
        If 語言ToolStripMenuItem.Text = "語言" Then
            Label5.Text = "參照圖層:圖層一"
        ElseIf 語言ToolStripMenuItem.Text = "Language" Then
            Label5.Text = "Reference layer: layer one"
        ElseIf 語言ToolStripMenuItem.Text = "言語" Then
            Label5.Text = "参照レイヤー：レイヤー"
        End If
        pics = 1
        Label7.Text = Label1.Text & "  " & Label3.Text & "  " & Label5.Text
    End Sub
    Private Sub 圖層二預設ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 圖層二預設ToolStripMenuItem.Click
        If 語言ToolStripMenuItem.Text = "語言" Then
            Label5.Text = "參照圖層:圖層二"
        ElseIf 語言ToolStripMenuItem.Text = "Language" Then
            Label5.Text = "Reference Layer: Layer II"
        ElseIf 語言ToolStripMenuItem.Text = "言語" Then
            Label5.Text = "参照層：2層"
        End If
        pics = 2
        Label7.Text = Label1.Text & "  " & Label3.Text & "  " & Label5.Text
    End Sub
    Private Sub 圖層三ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 圖層三ToolStripMenuItem.Click
        If 語言ToolStripMenuItem.Text = "語言" Then
            Label5.Text = "參照圖層:圖層三"
        ElseIf 語言ToolStripMenuItem.Text = "Language" Then
            Label5.Text = "Reference Layers: Layer 3"
        ElseIf 語言ToolStripMenuItem.Text = "言語" Then
            Label5.Text = "参照層：3層"
        End If
        pics = 3
        Label7.Text = Label1.Text & "  " & Label3.Text & "  " & Label5.Text
    End Sub
    Private Sub 顏色相減ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 顏色相減ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form20
        w.ShowDialog()
    End Sub
    Private Sub 白色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 白色ToolStripMenuItem.Click
        Me.BackColor = Color.Snow
    End Sub
    Private Sub 紅色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 紅色ToolStripMenuItem.Click
        Me.BackColor = Color.Red
    End Sub
    Private Sub 深藍ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 深藍ToolStripMenuItem.Click
        Me.BackColor = Color.Blue
    End Sub
    Private Sub 皇家藍預設ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 皇家藍預設ToolStripMenuItem.Click
        Me.BackColor = Color.RoyalBlue
    End Sub
    Private Sub 橘色ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 橘色ToolStripMenuItem1.Click
        Me.ForeColor = Color.Orange
    End Sub
    Private Sub 粉紅ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 粉紅ToolStripMenuItem.Click
        Me.BackColor = Color.Pink
    End Sub
    Private Sub 綠色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 綠色ToolStripMenuItem.Click
        Me.ForeColor = Color.Green
    End Sub
    Private Sub 黃色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 黃色ToolStripMenuItem.Click
        Me.ForeColor = Color.Yellow
    End Sub
    Private Sub 黑色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 黑色ToolStripMenuItem.Click
        Me.ForeColor = Color.Black
    End Sub
    Private Sub 淺藍預設ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 淺藍預設ToolStripMenuItem.Click
        MenuStrip1.BackColor = Color.LightSteelBlue
    End Sub
    Private Sub 粉紅ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 粉紅ToolStripMenuItem1.Click
        MenuStrip1.BackColor = Color.Pink
    End Sub
    Private Sub 白色ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 白色ToolStripMenuItem1.Click
        MenuStrip1.BackColor = Color.Snow
    End Sub
    Private Sub 橘色ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 橘色ToolStripMenuItem2.Click
        MenuStrip1.BackColor = Color.Orange
    End Sub
    Private Sub 黑色預設ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 黑色預設ToolStripMenuItem.Click
        MenuStrip1.ForeColor = Color.Black
    End Sub
    Private Sub 紅色ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 紅色ToolStripMenuItem1.Click
        MenuStrip1.ForeColor = Color.Red
    End Sub
    Private Sub 黃色ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 黃色ToolStripMenuItem1.Click
        MenuStrip1.ForeColor = Color.Yellow
    End Sub
    Private Sub 藍色ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 藍色ToolStripMenuItem.Click
        MenuStrip1.ForeColor = Color.Blue
    End Sub
    Private Sub 亮度調整加減ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 亮度調整加減ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form21
        w.ShowDialog()
    End Sub
    Private Sub 亮度調整百分比ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 亮度調整百分比ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form22
        w.ShowDialog()
    End Sub
    Private Sub 檢查更新ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 檢查更新ToolStripMenuItem.Click
        Shell("cmd.exe /c start " & "http://birdeggsblogger1.blogspot.tw/p/blog-page_24.html")
    End Sub
    Private Sub 檢視版本ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 檢視版本ToolStripMenuItem.Click
        MsgBox("此軟體的版本為3.6")
    End Sub
    Private Sub 圖層一和圖層三ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 圖層一和圖層三ToolStripMenuItem1.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim start_time As Date = Now
        Dim Rr, Gg, Bb, rr2, gg2, bb2 As Integer
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
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
            mBitmap2 = New Bitmap(PictureBox3.Image)
            Width = mBitmap2.Width
            Height = mBitmap2.Height
            Dim rect2 As New Rectangle(0, 0, Width, Height)
            Dim bmpData2 As BitmapData = mBitmap2.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
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
            Dim rgbA As Byte
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                Bb = rgbValues(k)
                Gg = rgbValues(k + 1)
                Rr = rgbValues(k + 2)
                bb2 = rgbValues2(k)
                gg2 = rgbValues2(k + 1)
                rr2 = rgbValues2(k + 2)
                Rr = Math.Abs(Rr - rr2)
                Gg = Math.Abs(Gg - gg2)
                Bb = Math.Abs(Bb - bb2)
                If Rr > 255 Then Rr = 255
                If Gg > 255 Then Gg = 255
                If Bb > 255 Then Bb = 255
                If Rr < 0 Then Rr = 0
                If Gg < 0 Then Gg = 0
                If Bb < 0 Then Bb = 0
                rgbValues(k) = Bb
                rgbValues(k + 1) = Gg
                rgbValues(k + 2) = Rr
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
    Private Sub 復原ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 復原ToolStripMenuItem.Click
        Try
            PictureBox1.Image = re2(re02 - 1)
            re2(re02 - 1) = Nothing
            re02 -= 1
        Catch
            MsgBox("無法再復原")
        End Try
    End Sub
    Private Sub 圖層一和圖層三ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 圖層一和圖層三ToolStripMenuItem2.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim start_time As Date = Now
        Dim Rr, Gg, Bb, rr2, gg2, bb2 As Integer
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
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
            mBitmap2 = New Bitmap(PictureBox3.Image)
            Width = mBitmap2.Width
            Height = mBitmap2.Height
            Dim rect2 As New Rectangle(0, 0, Width, Height)
            Dim bmpData2 As BitmapData = mBitmap2.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
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
            Dim rgbA As Byte
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                Bb = rgbValues(k)
                Gg = rgbValues(k + 1)
                Rr = rgbValues(k + 2)
                bb2 = rgbValues2(k)
                gg2 = rgbValues2(k + 1)
                rr2 = rgbValues2(k + 2)
                Rr = (Rr + rr2) / 2
                Gg = (Gg + gg2) / 2
                Bb = (Bb + bb2) / 2
                rgbValues(k) = Bb
                rgbValues(k + 1) = Gg
                rgbValues(k + 2) = Rr
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
    Private Sub picturebox1_Mousedown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        ' re2(re02) = PictureBox1.Image
        ' re02 += 1
        '  draw0 = 1
        '  PictureBox2.Image = PictureBox1.Image
    End Sub
    Private Sub picturebox1_Mouseup(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        '  draw0 = 0
    End Sub
    Private Sub picturebox1_Mousemove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        ' Try
        '     If pics = 3 Then
        '         PictureBox2.Image = PictureBox1.Image
        '     ElseIf pics = 3 Then
        '         PictureBox2.Image = PictureBox3.Image
        '     End If
        '     If draw0 = 1 Then
        '         If penstyle = 1 Then
        '             Dim png As New Bitmap(PictureBox1.Image)
        '             PictureBox1.Image = png
        '             Dim png2 As New Bitmap(PictureBox2.Image)
        '             PictureBox2.Image = png2
        '             X = e.X
        '             Y = e.Y
        '             Dim co As Color
        '             For i = 0 To penbig
        '                 For ii = 0 To penbig
        '                     co = png2.GetPixel(X + i, Y + ii)
        '                     png.SetPixel(X + i, Y + ii, Color.FromArgb(co.B, co.R, co.G))
        '                 Next
        '             Next
        '             System.GC.Collect()
        '         ElseIf penstyle = 2 Then
        '             Dim png As New Bitmap(PictureBox1.Image)
        '             PictureBox1.Image = png
        '             Dim png2 As New Bitmap(PictureBox2.Image)
        '             PictureBox2.Image = png2
        '             X = e.X
        '             Y = e.Y
        '             Dim co As Color
        '             For i = 0 To penbig
        '                 For ii = 0 To penbig
        '                     co = png2.GetPixel(X + i, Y + ii)
        '                     png.SetPixel(X + i, Y + ii, Color.FromArgb(co.B, co.G, co.R))
        '                 Next
        '             Next
        '            System.GC.Collect()
        '         ElseIf penstyle = 3 Then
        '             Dim png As New Bitmap(PictureBox1.Image)
        '             PictureBox1.Image = png
        '             Dim png2 As New Bitmap(PictureBox2.Image)
        '             PictureBox2.Image = png2
        '             X = e.X
        '             Y = e.Y
        '             Dim co As Color
        '             For i = 0 To penbig
        '                 For ii = 0 To penbig
        '                     co = png2.GetPixel(X + i, Y + ii)
        '                     png.SetPixel(X + i, Y + ii, Color.FromArgb(co.G, co.B, co.R))
        '                 Next
        '             Next
        '            System.GC.Collect()
        '         ElseIf penstyle = 4 Then
        '             Dim png As New Bitmap(PictureBox1.Image)
        '             PictureBox1.Image = png
        '             Dim png2 As New Bitmap(PictureBox2.Image)
        '             PictureBox2.Image = png2
        '             X = e.X
        '             Y = e.Y
        '             Dim co As Color
        '             For i = 0 To penbig
        '                 For ii = 0 To penbig
        '                     co = png2.GetPixel(X + i, Y + ii)
        '                     png.SetPixel(X + i, Y + ii, Color.FromArgb(co.G, co.R, co.B))
        '                 Next
        '             Next
        '            System.GC.Collect()
        '         ElseIf penstyle = 5 Then
        '             Dim png As New Bitmap(PictureBox1.Image)
        '             PictureBox1.Image = png
        '             Dim png2 As New Bitmap(PictureBox2.Image)
        '             PictureBox2.Image = png2
        '             X = e.X
        '             Y = e.Y
        '             Dim co As Color
        '             For i = 0 To penbig
        '                 For ii = 0 To penbig
        '                     co = png2.GetPixel(X + i, Y + ii)
        '                     png.SetPixel(X + i, Y + ii, Color.FromArgb(co.R, co.B, co.G))
        '                 Next
        '             Next
        '             System.GC.Collect()
        '         ElseIf penstyle = 6 Then
        '             Dim png As New Bitmap(PictureBox1.Image)
        '             PictureBox1.Image = png
        '             Dim png2 As New Bitmap(PictureBox2.Image)
        '             PictureBox2.Image = png2
        '             X = e.X
        '             Y = e.Y
        '             Dim co As Color
        '             For i = 0 To penbig
        '                 For ii = 0 To penbig
        '                     co = png2.GetPixel(X + i, Y + ii)
        '                     png.SetPixel(X + i, Y + ii, Color.FromArgb(255 - co.R, 255 - co.G, 255 - co.B))
        '                 Next
        '             Next
        '             System.GC.Collect()
        '         ElseIf penstyle = 7 Then
        '             Dim png As New Bitmap(PictureBox1.Image)
        '             PictureBox1.Image = png
        '             Dim png2 As New Bitmap(PictureBox2.Image)
        '             PictureBox2.Image = png2
        '             X = e.X
        '             Y = e.Y
        '             Dim co As Color
        '             For i = 0 To penbig
        '                 For ii = 0 To penbig
        '                     co = png2.GetPixel(X + i, Y + ii)
        '                     png.SetPixel(X + i, Y + ii, Color.FromArgb(co.R, co.G, co.B))
        '                 Next
        '             Next
        '             System.GC.Collect()
        '         End If
        '     End If
        ' Catch ex As SystemException
        ' End Try
    End Sub
    Private Sub 對比色筆ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 對比色筆ToolStripMenuItem.Click
        If 語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "畫筆:反轉筆"
        ElseIf 語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "brush:Reverse pen"
        ElseIf 語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "ブラシ:リバースペン"
        End If
        penstyle = 6
        Label7.Text = Label1.Text & "  " & Label3.Text & "  " & Label5.Text
    End Sub
    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        If 語言ToolStripMenuItem.Text = "語言" Then
            Label3.Text = "大小:10"
        ElseIf 語言ToolStripMenuItem.Text = "Language" Then
            Label3.Text = "size:10"
        ElseIf 語言ToolStripMenuItem.Text = "言語" Then
            Label3.Text = "サイズ:10"
        End If
        penbig = 10
        Label7.Text = Label1.Text & "  " & Label3.Text & "  " & Label5.Text
    End Sub
    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        If 語言ToolStripMenuItem.Text = "語言" Then
            Label3.Text = "大小:20"
        ElseIf 語言ToolStripMenuItem.Text = "Language" Then
            Label3.Text = "size:20"
        ElseIf 語言ToolStripMenuItem.Text = "言語" Then
            Label3.Text = "サイズ:20"
        End If
        penbig = 20
        Label7.Text = Label1.Text & "  " & Label3.Text & "  " & Label5.Text
    End Sub
    Private Sub 同色筆ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 同色筆ToolStripMenuItem.Click
        If 語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "畫筆:同色筆"
        ElseIf 語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "brush:The same color pen"
        ElseIf 語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "ブラシ:カラーペンで"
        End If
        penstyle = 7
        Label7.Text = Label1.Text & "  " & Label3.Text & "  " & Label5.Text
    End Sub
    Private Sub 圖片顏色查看程式ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 圖片顏色查看程式ToolStripMenuItem.Click
        Dim w As New Form24
        w.ShowDialog()
    End Sub
    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        Me.Opacity = 1
    End Sub
    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        Me.Opacity = 0.9
    End Sub
    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        Me.Opacity = 0.8
    End Sub
    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        Me.Opacity = 0.7
    End Sub
    Private Sub 參考文獻ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 參考文獻ToolStripMenuItem.Click
        Dim w As New Form25
        w.ShowDialog()
    End Sub
    Private Sub 中文ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 中文ToolStripMenuItem.Click
        圖片ToolStripMenuItem.Text = "圖片"
        匯入圖片ToolStripMenuItem.Text = "匯入圖片"
        匯出圖片ToolStripMenuItem.Text = "匯出圖片"
        編輯ToolStripMenuItem.Text = "編輯"
        復原ToolStripMenuItem.Text = "復原"
        建立還原點ToolStripMenuItem.Text = "建立還原點"
        恢復自還原點ToolStripMenuItem.Text = "恢復自還原點"
        剪貼簿ToolStripMenuItem.Text = "剪貼簿"
        複製圖片ToolStripMenuItem.Text = "複製圖片"
        貼上圖片ToolStripMenuItem.Text = "貼上圖片"
        列印ToolStripMenuItem.Text = "列印"
        列印圖片ToolStripMenuItem.Text = "列印圖片"
        濾鏡ToolStripMenuItem.Text = "濾鏡"
        對比色ToolStripMenuItem.Text = "反轉顏色"
        灰階ToolStripMenuItem.Text = "灰階"
        藝術化ToolStripMenuItem.Text = "藝術化"
        浮雕ToolStripMenuItem.Text = "浮雕"
        水墨畫二值化ToolStripMenuItem.Text = "二值化"
        油漆ToolStripMenuItem.Text = "油漆"
        版畫ToolStripMenuItem.Text = "版畫"
        噴槍ToolStripMenuItem.Text = "噴槍"
        線稿ToolStripMenuItem.Text = "草稿"
        一般噴槍ToolStripMenuItem.Text = "一般噴槍"
        彩色噴槍ToolStripMenuItem.Text = "彩色噴槍"
        模糊ToolStripMenuItem.Text = "像素模糊"
        縮放模糊ToolStripMenuItem.Text = "縮放模糊"
        玻璃ToolStripMenuItem.Text = "玻璃"
        幻彩ToolStripMenuItem.Text = "幻彩"
        彩色雜點ToolStripMenuItem.Text = "彩色雜點"
        復古ToolStripMenuItem.Text = "復古"
        變色ToolStripMenuItem.Text = "變色"
        色相ToolStripMenuItem.Text = "色相"
        顏色相減ToolStripMenuItem.Text = "顏色相減"
        色彩修正ToolStripMenuItem.Text = "色彩修正"
        色彩修正加減ToolStripMenuItem.Text = "色彩修正(加減)"
        色彩修正百分比ToolStripMenuItem.Text = "色彩修正(百分比)"
        亮度調整加減ToolStripMenuItem.Text = "亮度調整(加減)"
        亮度調整百分比ToolStripMenuItem.Text = "亮度調整(百分比)"
        增加顏色ToolStripMenuItem.Text = "增加顏色"
        飽和度ToolStripMenuItem.Text = "飽和度"
        縮放ToolStripMenuItem.Text = "縮放"
        縮放圖片ToolStripMenuItem.Text = "縮小圖片"
        放大圖片ToolStripMenuItem.Text = "放大圖片"
        附屬程式ToolStripMenuItem.Text = "附屬程式"
        圖片加密程式ToolStripMenuItem.Text = "圖片加密程式"
        圖片顏色查看程式ToolStripMenuItem.Text = "圖片顏色查看程式"
        複製圖片到圖層3ToolStripMenuItem.Text = "複製圖片到圖層三"
        切換圖層ToolStripMenuItem.Text = "切換圖層"
        交叉淡化ToolStripMenuItem.Text = "交叉淡化"
        顏色相減ToolStripMenuItem1.Text = "顏色相減"
        圖層一和圖層三ToolStripMenuItem.Text = "圖層一和圖層三"
        圖層一和圖層三ToolStripMenuItem1.Text = "圖層一和圖層三"
        圖層一和圖層三ToolStripMenuItem2.Text = "圖層一和圖層三"
        畫筆ToolStripMenuItem.Text = "畫筆"
        大小ToolStripMenuItem.Text = "大小"
        參照圖層ToolStripMenuItem.Text = "參照圖層"
        色相筆ToolStripMenuItem.Text = "色相筆"
        對比色筆ToolStripMenuItem.Text = "反轉筆"
        同色筆ToolStripMenuItem.Text = "同色筆"
        色相1ToolStripMenuItem.Text = "色相1"
        色相2ToolStripMenuItem.Text = "色相2"
        色相3ToolStripMenuItem.Text = "色相3"
        色相4ToolStripMenuItem.Text = "色相4"
        色相5ToolStripMenuItem.Text = "色相5"
        圖層一連續塗抹ToolStripMenuItem.Text = "圖層一(連續塗抹)"
        圖層二預設ToolStripMenuItem.Text = "圖層二(預設)"
        圖層三ToolStripMenuItem.Text = "圖層三"
        選項ToolStripMenuItem.Text = "選項"
        個人化ToolStripMenuItem.Text = "個人化"
        版本ToolStripMenuItem.Text = "版本"
        參考文獻ToolStripMenuItem.Text = "參考文獻"
        語言ToolStripMenuItem.Text = "語言"
        介面色彩ToolStripMenuItem.Text = "介面色彩"
        視窗透明度ToolStripMenuItem.Text = "視窗透明度"
        檢查更新ToolStripMenuItem.Text = "檢查更新"
        檢視版本ToolStripMenuItem.Text = "檢視版本"
        表單色彩ToolStripMenuItem.Text = "表單色彩"
        表單文字色彩ToolStripMenuItem.Text = "表單文字色彩"
        選單色彩ToolStripMenuItem.Text = "選單色彩"
        選單文字色彩ToolStripMenuItem.Text = "選單文字色彩"
        皇家藍預設ToolStripMenuItem.Text = "皇家藍(預設)"
        白色ToolStripMenuItem.Text = "白色"
        紅色ToolStripMenuItem.Text = "紅色"
        深藍ToolStripMenuItem.Text = "深藍"
        粉紅ToolStripMenuItem.Text = "粉紅"
        橘色ToolStripMenuItem1.Text = "橘色(預設)"
        綠色ToolStripMenuItem.Text = "綠色"
        黃色ToolStripMenuItem.Text = "黃色"
        黑色ToolStripMenuItem.Text = "黑色"
        淺藍預設ToolStripMenuItem.Text = "淺藍(預設)"
        粉紅ToolStripMenuItem1.Text = "粉紅"
        白色ToolStripMenuItem1.Text = "白色"
        橘色ToolStripMenuItem2.Text = "橘色"
        黑色預設ToolStripMenuItem.Text = "黑色(預設)"
        紅色ToolStripMenuItem1.Text = "紅色"
        黃色ToolStripMenuItem1.Text = "黃色"
        藍色ToolStripMenuItem.Text = "藍色"
        圖層ToolStripMenuItem.Text = "圖層"
        旋轉ToolStripMenuItem.Text = "翻轉"
        旋轉180度ToolStripMenuItem.Text = "翻轉180度"
        水平翻轉ToolStripMenuItem.Text = "水平翻轉"
        垂直翻轉ToolStripMenuItem.Text = "垂直翻轉"
        橫向切割ToolStripMenuItem.Text = "橫向切割"
        馬賽克ToolStripMenuItem.Text = "馬賽克"
        掃描線ToolStripMenuItem.Text = "掃描線"
        畫筆ToolStripMenuItem1.Text = "畫筆"
        迷宮ToolStripMenuItem.Text = "迷宮"
        渲染ToolStripMenuItem.Text = "渲染"
        選擇範圍ToolStripMenuItem.Text = "選擇範圍"
        色域選擇ToolStripMenuItem.Text = "色域選擇"
        解除選擇ToolStripMenuItem.Text = "解除選擇"
        深淺調整ToolStripMenuItem.Text = "深淺調整"
        檢視比例ToolStripMenuItem.Text = "檢視比例"
        官方網站ToolStripMenuItem.Text = "官方網站"
        If penstyle = 1 Then
            色相1ToolStripMenuItem.PerformClick()
        ElseIf penstyle = 2 Then
            色相2ToolStripMenuItem.PerformClick()
        ElseIf penstyle = 3 Then
            色相3ToolStripMenuItem.PerformClick()
        ElseIf penstyle = 4 Then
            色相4ToolStripMenuItem.PerformClick()
        ElseIf penstyle = 5 Then
            色相5ToolStripMenuItem.PerformClick()
        ElseIf penstyle = 6 Then
            對比色筆ToolStripMenuItem.PerformClick()
        ElseIf penstyle = 7 Then
            同色筆ToolStripMenuItem.PerformClick()
        End If
        If penbig = 1 Then
            ToolStripMenuItem2.PerformClick()
        ElseIf penbig = 3 Then
            ToolStripMenuItem3.PerformClick()
        ElseIf penbig = 5 Then
            ToolStripMenuItem4.PerformClick()
        ElseIf penbig = 10 Then
            ToolStripMenuItem5.PerformClick()
        ElseIf penbig = 20 Then
            ToolStripMenuItem6.PerformClick()
        End If
        If pics = 1 Then
            圖層一連續塗抹ToolStripMenuItem.PerformClick()
        ElseIf pics = 2 Then
            圖層二預設ToolStripMenuItem.PerformClick()
        ElseIf pics = 3 Then
            圖層三ToolStripMenuItem.PerformClick()
        End If
    End Sub
    Private Sub EnglishToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglishToolStripMenuItem.Click
        圖片ToolStripMenuItem.Text = "image"
        匯入圖片ToolStripMenuItem.Text = "Import images"
        匯出圖片ToolStripMenuItem.Text = "Export image"
        編輯ToolStripMenuItem.Text = "edit"
        復原ToolStripMenuItem.Text = "recovery"
        建立還原點ToolStripMenuItem.Text = "Create a restore point"
        恢復自還原點ToolStripMenuItem.Text = "Restore from the restore point"
        剪貼簿ToolStripMenuItem.Text = "scrapbook"
        複製圖片ToolStripMenuItem.Text = "Copy the image"
        貼上圖片ToolStripMenuItem.Text = "Paste the picture"
        列印ToolStripMenuItem.Text = "Print"
        列印圖片ToolStripMenuItem.Text = "Print picture"
        濾鏡ToolStripMenuItem.Text = "Filter"
        對比色ToolStripMenuItem.Text = "Reverse color"
        灰階ToolStripMenuItem.Text = "Grayscale"
        藝術化ToolStripMenuItem.Text = "Art"
        浮雕ToolStripMenuItem.Text = "Relief"
        水墨畫二值化ToolStripMenuItem.Text = "Binarization"
        油漆ToolStripMenuItem.Text = "paint"
        版畫ToolStripMenuItem.Text = "Engraving"
        噴槍ToolStripMenuItem.Text = "spray gun"
        線稿ToolStripMenuItem.Text = "draft"
        一般噴槍ToolStripMenuItem.Text = "General gun"
        彩色噴槍ToolStripMenuItem.Text = "Color spray gun"
        模糊ToolStripMenuItem.Text = "Pixel blur"
        縮放模糊ToolStripMenuItem.Text = "Zoom Blur"
        玻璃ToolStripMenuItem.Text = "glass"
        幻彩ToolStripMenuItem.Text = "Symphony"
        彩色雜點ToolStripMenuItem.Text = "Symphony"
        復古ToolStripMenuItem.Text = "Retro"
        變色ToolStripMenuItem.Text = "Discoloration"
        色相ToolStripMenuItem.Text = "Hue"
        顏色相減ToolStripMenuItem.Text = "Color subtraction"
        色彩修正ToolStripMenuItem.Text = "Color correction"
        色彩修正加減ToolStripMenuItem.Text = "Color correction (addition and subtraction)"
        色彩修正百分比ToolStripMenuItem.Text = "Color Correction (Percentage)"
        亮度調整加減ToolStripMenuItem.Text = "Brightness adjustment (addition and subtraction)"
        亮度調整百分比ToolStripMenuItem.Text = "Brightness Adjustment (Percentage))"
        增加顏色ToolStripMenuItem.Text = "Increase the color"
        飽和度ToolStripMenuItem.Text = "saturation"
        縮放ToolStripMenuItem.Text = "Zoom"
        縮放圖片ToolStripMenuItem.Text = "Zoom out"
        放大圖片ToolStripMenuItem.Text = "Zoom in picture"
        附屬程式ToolStripMenuItem.Text = "Adjunct"
        圖片加密程式ToolStripMenuItem.Text = "Image encryption program"
        圖片顏色查看程式ToolStripMenuItem.Text = "Image Color Viewer"
        複製圖片到圖層3ToolStripMenuItem.Text = "Copy the image to layer three"
        切換圖層ToolStripMenuItem.Text = "Toggles the layer"
        交叉淡化ToolStripMenuItem.Text = "Cross-fade"
        顏色相減ToolStripMenuItem1.Text = "The colors are added"
        圖層一和圖層三ToolStripMenuItem.Text = "Layer one and layer three"
        圖層一和圖層三ToolStripMenuItem1.Text = "Layer one and layer three"
        圖層一和圖層三ToolStripMenuItem2.Text = "Layer one and layer three"
        畫筆ToolStripMenuItem.Text = "brush"
        畫筆ToolStripMenuItem1.Text = "brush"
        大小ToolStripMenuItem.Text = "size"
        參照圖層ToolStripMenuItem.Text = "Refer to layers"
        色相筆ToolStripMenuItem.Text = "Hue pen"
        對比色筆ToolStripMenuItem.Text = "Reverse pen"
        同色筆ToolStripMenuItem.Text = "The same color pen"
        色相1ToolStripMenuItem.Text = "Hue1"
        色相2ToolStripMenuItem.Text = "Hue2"
        色相3ToolStripMenuItem.Text = "Hue3"
        色相4ToolStripMenuItem.Text = "Hue4"
        色相5ToolStripMenuItem.Text = "Hue5"
        圖層一連續塗抹ToolStripMenuItem.Text = "Layer one (continuous smear)"
        圖層二預設ToolStripMenuItem.Text = "Layer two (default)"
        圖層三ToolStripMenuItem.Text = "Layer three"
        選項ToolStripMenuItem.Text = "Option"
        個人化ToolStripMenuItem.Text = "personalize"
        版本ToolStripMenuItem.Text = "version"
        參考文獻ToolStripMenuItem.Text = "references"
        語言ToolStripMenuItem.Text = "Language"
        介面色彩ToolStripMenuItem.Text = "Interface color"
        視窗透明度ToolStripMenuItem.Text = "Window transparency"
        檢查更新ToolStripMenuItem.Text = "Check for updates"
        檢視版本ToolStripMenuItem.Text = "View the version"
        表單色彩ToolStripMenuItem.Text = "Form colors"
        表單文字色彩ToolStripMenuItem.Text = "Form text color"
        選單色彩ToolStripMenuItem.Text = "Menu Color"
        選單文字色彩ToolStripMenuItem.Text = "Menu text color"
        皇家藍預設ToolStripMenuItem.Text = "Royal Blue (default)"
        白色ToolStripMenuItem.Text = "white"
        紅色ToolStripMenuItem.Text = "red"
        深藍ToolStripMenuItem.Text = "dark blue"
        粉紅ToolStripMenuItem.Text = "pink "
        橘色ToolStripMenuItem1.Text = "orange(default)"
        綠色ToolStripMenuItem.Text = "green"
        黃色ToolStripMenuItem.Text = "yellow"
        黑色ToolStripMenuItem.Text = "black"
        淺藍預設ToolStripMenuItem.Text = "light blue(default)"
        粉紅ToolStripMenuItem1.Text = "pink"
        白色ToolStripMenuItem1.Text = "white"
        橘色ToolStripMenuItem2.Text = "orange"
        黑色預設ToolStripMenuItem.Text = "black(default)"
        紅色ToolStripMenuItem1.Text = "red"
        黃色ToolStripMenuItem1.Text = "yellow"
        藍色ToolStripMenuItem.Text = "blue"
        圖層ToolStripMenuItem.Text = "layers"
        旋轉ToolStripMenuItem.Text = "flip"
        旋轉180度ToolStripMenuItem.Text = "flip 180 degrees"
        水平翻轉ToolStripMenuItem.Text = "Flip horizontally"
        垂直翻轉ToolStripMenuItem.Text = "Flip vertically"
        橫向切割ToolStripMenuItem.Text = "Transverse cutting"
        馬賽克ToolStripMenuItem.Text = "Mosaic"
        掃描線ToolStripMenuItem.Text = "Scan line"
        迷宮ToolStripMenuItem.Text = "maze"
        渲染ToolStripMenuItem.Text = "Rendering"
        選擇範圍ToolStripMenuItem.Text = "Select the range"
        色域選擇ToolStripMenuItem.Text = "Gamut Select"
        解除選擇ToolStripMenuItem.Text = "Deselect"
        深淺調整ToolStripMenuItem.Text = "Depth adjustment"
        檢視比例ToolStripMenuItem.Text = "View the scale"
        官方網站ToolStripMenuItem.Text = "Official website"
        If penstyle = 1 Then
            色相1ToolStripMenuItem.PerformClick()
        ElseIf penstyle = 2 Then
            色相2ToolStripMenuItem.PerformClick()
        ElseIf penstyle = 3 Then
            色相3ToolStripMenuItem.PerformClick()
        ElseIf penstyle = 4 Then
            色相4ToolStripMenuItem.PerformClick()
        ElseIf penstyle = 5 Then
            色相5ToolStripMenuItem.PerformClick()
        ElseIf penstyle = 6 Then
            對比色筆ToolStripMenuItem.PerformClick()
        ElseIf penstyle = 7 Then
            同色筆ToolStripMenuItem.PerformClick()
        End If
        If penbig = 1 Then
            ToolStripMenuItem2.PerformClick()
        ElseIf penbig = 3 Then
            ToolStripMenuItem3.PerformClick()
        ElseIf penbig = 5 Then
            ToolStripMenuItem4.PerformClick()
        ElseIf penbig = 10 Then
            ToolStripMenuItem5.PerformClick()
        ElseIf penbig = 20 Then
            ToolStripMenuItem6.PerformClick()
        End If
        If pics = 1 Then
            圖層一連續塗抹ToolStripMenuItem.PerformClick()
        ElseIf pics = 2 Then
            圖層二預設ToolStripMenuItem.PerformClick()
        ElseIf pics = 3 Then
            圖層三ToolStripMenuItem.PerformClick()
        End If
    End Sub
    Private Sub 日本語ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 日本語ToolStripMenuItem.Click
        圖片ToolStripMenuItem.Text = "画像"
        匯入圖片ToolStripMenuItem.Text = "インポート画像"
        匯出圖片ToolStripMenuItem.Text = "エクスポート画像"
        編輯ToolStripMenuItem.Text = "編集"
        復原ToolStripMenuItem.Text = "回復"
        建立還原點ToolStripMenuItem.Text = "復元ポイントを確立"
        恢復自還原點ToolStripMenuItem.Text = "復元ポイントから復元"
        剪貼簿ToolStripMenuItem.Text = "スクラップブック"
        複製圖片ToolStripMenuItem.Text = "コピー画像"
        貼上圖片ToolStripMenuItem.Text = "貼り付け写真"
        列印ToolStripMenuItem.Text = "印刷"
        列印圖片ToolStripMenuItem.Text = "印刷画像"
        濾鏡ToolStripMenuItem.Text = "フィルタ"
        對比色ToolStripMenuItem.Text = "反転色"
        灰階ToolStripMenuItem.Text = "グレースケール"
        藝術化ToolStripMenuItem.Text = "アート"
        浮雕ToolStripMenuItem.Text = "救済"
        水墨畫二值化ToolStripMenuItem.Text = "バイナリ"
        油漆ToolStripMenuItem.Text = "ペイント"
        版畫ToolStripMenuItem.Text = "印刷"
        噴槍ToolStripMenuItem.Text = "スプレーガン"
        線稿ToolStripMenuItem.Text = "ドラフト"
        一般噴槍ToolStripMenuItem.Text = "一般的なガン"
        彩色噴槍ToolStripMenuItem.Text = "カラーガンの"
        模糊ToolStripMenuItem.Text = "ピクセルボケ"
        縮放模糊ToolStripMenuItem.Text = "ズームブラー"
        玻璃ToolStripMenuItem.Text = "グラス"
        幻彩ToolStripMenuItem.Text = "交響曲"
        彩色雜點ToolStripMenuItem.Text = "カラーノイズ"
        復古ToolStripMenuItem.Text = "レトロ"
        變色ToolStripMenuItem.Text = "変色します"
        色相ToolStripMenuItem.Text = "フエ"
        顏色相減ToolStripMenuItem.Text = "減色"
        色彩修正ToolStripMenuItem.Text = "色補正"
        色彩修正加減ToolStripMenuItem.Text = "色補正(修正されました)"
        色彩修正百分比ToolStripMenuItem.Text = "色補正(パーセンテージ)"
        亮度調整加減ToolStripMenuItem.Text = "輝度調整(修正されました)"
        亮度調整百分比ToolStripMenuItem.Text = "輝度調整(パーセンテージ)"
        增加顏色ToolStripMenuItem.Text = "色を追加"
        飽和度ToolStripMenuItem.Text = "飽和"
        縮放ToolStripMenuItem.Text = "スケーリング"
        縮放圖片ToolStripMenuItem.Text = "サムネイル画像"
        放大圖片ToolStripMenuItem.Text = "イメージを拡大"
        附屬程式ToolStripMenuItem.Text = "提携プログラム"
        圖片加密程式ToolStripMenuItem.Text = "画像暗号化プログラム"
        圖片顏色查看程式ToolStripMenuItem.Text = "カラー画像表示プログラム"
        複製圖片到圖層3ToolStripMenuItem.Text = "3の層に画像をコピー"
        切換圖層ToolStripMenuItem.Text = "レイヤーの切り替え"
        交叉淡化ToolStripMenuItem.Text = "クロスフェード"
        顏色相減ToolStripMenuItem1.Text = "減色"
        圖層一和圖層三ToolStripMenuItem.Text = "レイヤ1とレイヤ3"
        圖層一和圖層三ToolStripMenuItem1.Text = "レイヤ1とレイヤ3"
        圖層一和圖層三ToolStripMenuItem2.Text = "レイヤ1とレイヤ3"
        畫筆ToolStripMenuItem.Text = "ブラシ"
        畫筆ToolStripMenuItem1.Text = "ブラシ"
        大小ToolStripMenuItem.Text = "サイズ"
        參照圖層ToolStripMenuItem.Text = "参照レイヤ"
        色相筆ToolStripMenuItem.Text = "フエペン"
        對比色筆ToolStripMenuItem.Text = "リバースペン"
        同色筆ToolStripMenuItem.Text = "カラーペンで"
        色相1ToolStripMenuItem.Text = "フエ1"
        色相2ToolStripMenuItem.Text = "フエ2"
        色相3ToolStripMenuItem.Text = "フエ3"
        色相4ToolStripMenuItem.Text = "フエ4"
        色相5ToolStripMenuItem.Text = "フエ5"
        圖層一連續塗抹ToolStripMenuItem.Text = "レイヤ1（連続スミア"
        圖層二預設ToolStripMenuItem.Text = "レイヤ2（デフォルト）"
        圖層三ToolStripMenuItem.Text = "レイヤ3"
        選項ToolStripMenuItem.Text = "オプション"
        個人化ToolStripMenuItem.Text = "個別の"
        版本ToolStripMenuItem.Text = "リリース"
        參考文獻ToolStripMenuItem.Text = "リファレンス"
        語言ToolStripMenuItem.Text = "言語"
        介面色彩ToolStripMenuItem.Text = "インターフェイスの色"
        視窗透明度ToolStripMenuItem.Text = "ウィンドウの透明性"
        檢查更新ToolStripMenuItem.Text = "更新プログラムの確認"
        檢視版本ToolStripMenuItem.Text = "ビューのバージョン"
        表單色彩ToolStripMenuItem.Text = "フォームの色"
        表單文字色彩ToolStripMenuItem.Text = "フォームのテキストの色"
        選單色彩ToolStripMenuItem.Text = "メニュー色"
        選單文字色彩ToolStripMenuItem.Text = "メニューテキストの色"
        皇家藍預設ToolStripMenuItem.Text = "ロイヤルブルー（デフォルト"
        白色ToolStripMenuItem.Text = "ホワイト"
        紅色ToolStripMenuItem.Text = "レッド"
        深藍ToolStripMenuItem.Text = "ディープブルー"
        粉紅ToolStripMenuItem.Text = "ピンク"
        橘色ToolStripMenuItem1.Text = "オレンジ(デフォルト）"
        綠色ToolStripMenuItem.Text = "グリーン"
        黃色ToolStripMenuItem.Text = "黄色"
        黑色ToolStripMenuItem.Text = "ブラック"
        淺藍預設ToolStripMenuItem.Text = "ライトブルー（デフォルト"
        粉紅ToolStripMenuItem1.Text = "ピンク"
        白色ToolStripMenuItem1.Text = "ホワイト"
        橘色ToolStripMenuItem2.Text = "オレンジ"
        黑色預設ToolStripMenuItem.Text = "ブラック（デフォルト"
        紅色ToolStripMenuItem1.Text = "レッド"
        黃色ToolStripMenuItem1.Text = "黄色"
        藍色ToolStripMenuItem.Text = "ブルー"
        圖層ToolStripMenuItem.Text = "層"
        旋轉ToolStripMenuItem.Text = "覆します"
        旋轉180度ToolStripMenuItem.Text = "180度"
        水平翻轉ToolStripMenuItem.Text = "左右反転"
        垂直翻轉ToolStripMenuItem.Text = "垂直方向に反転"
        橫向切割ToolStripMenuItem.Text = "横方向のカット"
        馬賽克ToolStripMenuItem.Text = "モザイク"
        掃描線ToolStripMenuItem.Text = "走査線"
        迷宮ToolStripMenuItem.Text = "迷路"
        渲染ToolStripMenuItem.Text = "レンダー"
        選擇範圍ToolStripMenuItem.Text = "選択の範囲"
        色域選擇ToolStripMenuItem.Text = "色域を選択"
        解除選擇ToolStripMenuItem.Text = "選択を解除"
        深淺調整ToolStripMenuItem.Text = "深さ調整"
        檢視比例ToolStripMenuItem.Text = "ビューの割合"
        官方網站ToolStripMenuItem.Text = "公式サイト"
        If penstyle = 1 Then
            色相1ToolStripMenuItem.PerformClick()
        ElseIf penstyle = 2 Then
            色相2ToolStripMenuItem.PerformClick()
        ElseIf penstyle = 3 Then
            色相3ToolStripMenuItem.PerformClick()
        ElseIf penstyle = 4 Then
            色相4ToolStripMenuItem.PerformClick()
        ElseIf penstyle = 5 Then
            色相5ToolStripMenuItem.PerformClick()
        ElseIf penstyle = 6 Then
            對比色筆ToolStripMenuItem.PerformClick()
        ElseIf penstyle = 7 Then
            同色筆ToolStripMenuItem.PerformClick()
        End If
        If penbig = 1 Then
            ToolStripMenuItem2.PerformClick()
        ElseIf penbig = 3 Then
            ToolStripMenuItem3.PerformClick()
        ElseIf penbig = 5 Then
            ToolStripMenuItem4.PerformClick()
        ElseIf penbig = 10 Then
            ToolStripMenuItem5.PerformClick()
        ElseIf penbig = 20 Then
            ToolStripMenuItem6.PerformClick()
        End If
        If pics = 1 Then
            圖層一連續塗抹ToolStripMenuItem.PerformClick()
        ElseIf pics = 2 Then
            圖層二預設ToolStripMenuItem.PerformClick()
        ElseIf pics = 3 Then
            圖層三ToolStripMenuItem.PerformClick()
        End If
    End Sub
    Private Sub 旋轉180度ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 旋轉180度ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        PictureBox2.Image = PictureBox1.Image
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        Dim mBitmap2 As Bitmap
        Try
            mBitmap = New Bitmap(PictureBox1.Image)
            mBitmap2 = New Bitmap(PictureBox2.Image)
            Width = mBitmap.Width
            Height = mBitmap.Height
            Dim rect As New Rectangle(0, 0, Width, Height)
            Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
            Dim ptr As IntPtr = bmpData.Scan0
            Dim bytes As Integer = bmpData.Stride * Height
            With bmpData
            End With
            Dim rect2 As New Rectangle(0, 0, Width, Height) '
            Dim bmpData2 As BitmapData = mBitmap2.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
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
            Dim wi As Integer = PictureBox1.Width
            Dim he As Integer = PictureBox1.Height
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                rgbValues(k) = rgbValues2(rgbValues.Length - Bpx - k)
                rgbValues(k + 1) = rgbValues2(rgbValues.Length - Bpx - k + 1)
                rgbValues(k + 2) = rgbValues2(rgbValues.Length - Bpx - k + 2)
                If Bpx = 4 Then
                    rgbValues(k + 3) = rgbValues2(rgbValues.Length - Bpx - k + 3)
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
    Private Sub 水平翻轉ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 水平翻轉ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        PictureBox2.Image = PictureBox1.Image
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        Dim mBitmap2 As Bitmap
        Try
            mBitmap = New Bitmap(PictureBox1.Image)
            mBitmap2 = New Bitmap(PictureBox2.Image)
            Width = mBitmap.Width
            Height = mBitmap.Height
            Dim rect As New Rectangle(0, 0, Width, Height)
            Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
            Dim ptr As IntPtr = bmpData.Scan0
            Dim bytes As Integer = bmpData.Stride * Height
            With bmpData
            End With
            Dim rect2 As New Rectangle(0, 0, Width, Height)
            Dim bmpData2 As BitmapData = mBitmap2.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
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
            Dim wi As Integer = PictureBox1.Width
            Dim he As Integer = PictureBox1.Height
            For i As Integer = 1 To he - 2
                For k As Integer = 0 To wi * 4 + 2 Step Bpx
                    rgbValues(k + i * wi * 4) = rgbValues2(wi * 4 + i * wi * 4 - k - 4)
                    rgbValues(k + i * wi * 4 + 1) = rgbValues2(wi * 4 + i * wi * 4 - k + 1 - 4)
                    rgbValues(k + i * wi * 4 + 2) = rgbValues2(wi * 4 + i * wi * 4 - k + 2 - 4)
                    If Bpx = 4 Then
                        rgbValues(k + i * wi * 4 + 3) = rgbValues2(wi * 4 + i * wi * 4 - k + 3)
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
        Dim png As New Bitmap(PictureBox1.Image)
        Dim png2 As New Bitmap(PictureBox2.Image)
        PictureBox1.Image = png
        Dim r As Integer
        r = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        Dim width1 As Integer
        Dim co As Color
        Dim a As Integer = 1
        Dim b As Integer = t - 1
        For width1 = 1 To r - 1
            co = png2.GetPixel(a, b)
            png.SetPixel(PictureBox1.Width - a, b, Color.FromArgb(co.R, co.G, co.B))
            a += 1
        Next
        a = 1
        b = 0
        For width1 = 1 To r - 1
            co = png2.GetPixel(a, b)
            png.SetPixel(PictureBox1.Width - a, b, Color.FromArgb(co.R, co.G, co.B))
            a += 1
        Next
    End Sub
    Private Sub 垂直翻轉ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 垂直翻轉ToolStripMenuItem.Click
        旋轉180度ToolStripMenuItem.PerformClick()
        水平翻轉ToolStripMenuItem.PerformClick()
        re2(re02 - 1) = Nothing
        re02 -= 1
    End Sub
    Private Sub 橫向切割ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 橫向切割ToolStripMenuItem.Click
        PictureBox1.Width = rrrr
        PictureBox1.Height = tttt
        re2(re02) = PictureBox1.Image
        re02 += 1
        PictureBox2.Image = PictureBox1.Image
        Dim start_time As Date = Now
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        Dim mBitmap2 As Bitmap
        Try
            mBitmap = New Bitmap(PictureBox1.Image)
            mBitmap2 = New Bitmap(PictureBox2.Image)
            Width = mBitmap.Width
            Height = mBitmap.Height
            Dim rect As New Rectangle(0, 0, Width, Height)
            Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
            Dim ptr As IntPtr = bmpData.Scan0
            Dim bytes As Integer = bmpData.Stride * Height
            With bmpData
            End With
            Dim rect2 As New Rectangle(0, 0, Width, Height)
            Dim bmpData2 As BitmapData = mBitmap2.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
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
            Dim wi As Integer = PictureBox1.Width
            Dim he As Integer = PictureBox1.Height
            If wi > he Then
                For i As Integer = 0 To wi - Bpx
                    For k As Integer = 0 To he * 4 - Bpx Step Bpx
                        rgbValues(k + i * he * 4) = rgbValues2(he * 4 + i * he * 4 - k)
                        rgbValues(k + i * he * 4 + 1) = rgbValues2(he * 4 + i * he * 4 - k + 1)
                        rgbValues(k + i * he * 4 + 2) = rgbValues2(he * 4 + i * he * 4 - k + 2)
                        If Bpx = 4 Then
                            rgbValues(k + i * he * 4 + 3) = rgbValues2(wi * 4 + i * he * 4 - k + 3)
                        End If
                    Next
                Next
            Else
                MsgBox("此功能只支援寬度大於高度的圖片")
            End If
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox1.Image = mBitmap
        System.GC.Collect()
        If Label8.Text = 100 Then
            PictureBox1.Width = rrrr
            PictureBox1.Height = tttt
        ElseIf Label8.Text = 50 Then
            PictureBox1.Width = rrrr / 2
            PictureBox1.Height = tttt / 2
        ElseIf Label8.Text = 25 Then
            PictureBox1.Width = rrrr / 4
            PictureBox1.Height = tttt / 4
        ElseIf Label8.Text = 12 Then
            PictureBox1.Width = rrrr / 8
            PictureBox1.Height = tttt / 8
        End If
    End Sub
    Private Sub 馬賽克ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 馬賽克ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form23
        w.ShowDialog()
    End Sub
    Private Sub 掃描線ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 掃描線ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form26
        w.ShowDialog()
    End Sub
    Private Sub 迷宮ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 迷宮ToolStripMenuItem.Click
        PictureBox1.Width = rrrr
        PictureBox1.Height = tttt
        re2(re02) = PictureBox1.Image
        re02 += 1
        PictureBox2.Image = PictureBox1.Image
        Dim start_time As Date = Now
        Dim R As Byte, G As Byte, B As Byte
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        Dim pi As Integer = PictureBox1.Width
        Dim tra As Integer = 50
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
            Dim wi As Integer = PictureBox1.Width
            Dim he As Integer = PictureBox1.Height
            For i As Integer = 0 To he * 4 - Bpx * tra Step Bpx * tra
                For k As Integer = 0 To wi * 4 - Bpx * tra Step Bpx * tra
                    B = CByte(rgbValues(k + wi * i))
                    G = CByte(rgbValues(k + 1 + wi * i))
                    R = CByte(rgbValues(k + 2 + wi * i))
                    For i2 = 0 To tra * 4 - 4 Step Bpx
                        For i1 = 0 To tra * 4 - 4 Step Bpx
                            rgbValues(i2 * wi + k + wi * i + i1) = B
                            rgbValues(i2 * wi + k + wi * i + i1 + 1) = G
                            rgbValues(i2 * wi + k + wi * i + i1 + 2) = R
                        Next
                    Next
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
        Button1.PerformClick()
        If Label8.Text = 100 Then
            PictureBox1.Width = rrrr
            PictureBox1.Height = tttt
        ElseIf Label8.Text = 50 Then
            PictureBox1.Width = rrrr / 2
            PictureBox1.Height = tttt / 2
        ElseIf Label8.Text = 25 Then
            PictureBox1.Width = rrrr / 4
            PictureBox1.Height = tttt / 4
        ElseIf Label8.Text = 12 Then
            PictureBox1.Width = rrrr / 8
            PictureBox1.Height = tttt / 8
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PictureBox2.Image = PictureBox1.Image
        Dim pp3 As Image = PictureBox1.Image
        Dim pp4 As Image = PictureBox1.Image
        Dim start_time As Date = Now
        Dim R As Byte, G As Byte, B As Byte
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
            Dim widt As Integer = PictureBox1.Width
            Dim tra As Integer = 7
            For k As Integer = 0 To rgbValues.Length - Bpx - widt * tra * 4 - 4 * tra Step Bpx
                B = CByte(255 - rgbValues(k + widt * tra * 4 + 4 * tra))
                G = CByte(255 - rgbValues(k + 1 + widt * tra * 4 + 4 * tra))
                R = CByte(255 - rgbValues(k + 2 + widt * tra * 4 + 4 * tra))
                rgbValues(k) = B
                rgbValues(k + 1) = G
                rgbValues(k + 2) = R
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
        pp3 = mBitmap
        System.GC.Collect()
        Dim mBitmap2 As Bitmap
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
            mBitmap2 = New Bitmap(pp3)
            Width = mBitmap2.Width
            Height = mBitmap2.Height
            Dim rect2 As New Rectangle(0, 0, Width, Height)
            Dim bmpData2 As BitmapData = mBitmap2.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
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
            Dim rgbA As Byte
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                B = CByte(rgbValues(k) / 2 + rgbValues2(k) / 2)
                G = CByte(rgbValues(k + 1) / 2 + rgbValues2(k + 1) / 2)
                R = CByte(rgbValues(k + 2) / 2 + rgbValues2(k + 2) / 2)
                rgbValues(k) = B
                rgbValues(k + 1) = G
                rgbValues(k + 2) = R
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
        pp4 = mBitmap
        System.GC.Collect()
        For i = 1 To 4
            Try
                mBitmap = New Bitmap(pp4)
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
                Dim widt As Integer = PictureBox1.Width
                Dim tra As Integer = 7
                For k As Integer = 0 To rgbValues.Length - Bpx - widt * tra * 4 - 4 * tra Step Bpx
                    B = CByte(255 - rgbValues(k + widt * tra * 4 + 4 * tra))
                    G = CByte(255 - rgbValues(k + 1 + widt * tra * 4 + 4 * tra))
                    R = CByte(255 - rgbValues(k + 2 + widt * tra * 4 + 4 * tra))
                    rgbValues(k) = B
                    rgbValues(k + 1) = G
                    rgbValues(k + 2) = R
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
            pp3 = mBitmap
            System.GC.Collect()
            Try
                mBitmap = New Bitmap(pp4)
                Width = mBitmap.Width
                Height = mBitmap.Height
                Dim rect As New Rectangle(0, 0, Width, Height)
                Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
                Dim ptr As IntPtr = bmpData.Scan0
                Dim bytes As Integer = bmpData.Stride * Height
                With bmpData
                End With
                mBitmap2 = New Bitmap(pp3)
                Width = mBitmap2.Width
                Height = mBitmap2.Height
                Dim rect2 As New Rectangle(0, 0, Width, Height)
                Dim bmpData2 As BitmapData = mBitmap2.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
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
                Dim rgbA As Byte
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    B = CByte(rgbValues(k) / 2 + rgbValues2(k) / 2)
                    G = CByte(rgbValues(k + 1) / 2 + rgbValues2(k + 1) / 2)
                    R = CByte(rgbValues(k + 2) / 2 + rgbValues2(k + 2) / 2)
                    rgbValues(k) = B
                    rgbValues(k + 1) = G
                    rgbValues(k + 2) = R
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
            pp4 = mBitmap
            System.GC.Collect()
        Next
        PictureBox1.Image = mBitmap
        System.GC.Collect()
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
            Dim rr, gg, bb As Byte
            Dim tra2 As Integer = 128
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                bb = CByte(rgbValues(k))
                gg = CByte(rgbValues(k + 1))
                rr = CByte(rgbValues(k + 2))
                If rr >= tra2 And gg >= tra2 And bb >= tra2 Then
                    rgbValues(k + 2) = 255
                    rgbValues(k + 1) = 255
                    rgbValues(k) = 255
                ElseIf rr >= tra2 And gg >= tra2 And bb < tra2 Then
                    rgbValues(k + 2) = 255
                    rgbValues(k + 1) = 255
                    rgbValues(k) = 0
                ElseIf rr >= tra2 And gg < tra2 And bb >= tra2 Then
                    rgbValues(k + 2) = 255
                    rgbValues(k + 1) = 0
                    rgbValues(k) = 255
                ElseIf rr >= tra2 And gg < tra2 And bb < tra2 Then
                    rgbValues(k + 2) = 255
                    rgbValues(k + 1) = 0
                    rgbValues(k) = 0
                ElseIf rr < tra2 And gg >= tra2 And bb >= tra2 Then
                    rgbValues(k + 2) = 0
                    rgbValues(k + 1) = 255
                    rgbValues(k) = 255
                ElseIf rr < tra2 And gg >= tra2 And bb < tra2 Then
                    rgbValues(k + 2) = 0
                    rgbValues(k + 1) = 255
                    rgbValues(k) = 0
                ElseIf rr < tra2 And gg < tra2 And bb >= tra2 Then
                    rgbValues(k + 2) = 0
                    rgbValues(k + 1) = 0
                    rgbValues(k) = 255
                ElseIf rr < tra2 And gg < tra2 And bb < tra2 Then
                    rgbValues(k + 2) = 0
                    rgbValues(k + 1) = 0
                    rgbValues(k) = 0
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
            Dim rbg1 As Integer
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                rbg1 = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3)
                If rbg1 >= 127 Then
                    rgbValues(k) = 255
                    rgbValues(k + 1) = 255
                    rgbValues(k + 2) = 255
                Else
                    rgbValues(k) = 0
                    rgbValues(k + 1) = 0
                    rgbValues(k + 2) = 0
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
    Private Sub 匯出圖片ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 匯出圖片ToolStripMenuItem.Click
        Dim c As Image
        c = PictureBox1.Image
        Dim saveFileDialog As New SaveFileDialog
        saveFileDialog.Filter = "圖片檔 (*.png;*.jpg;*.bmp;*.gif)|*.png;*.jpg;*.bmp;*.gif"
        If saveFileDialog.ShowDialog = DialogResult.OK And saveFileDialog.FileName.Trim <> "" Then
            c.Save(saveFileDialog.FileName)
        End If
    End Sub
    Private Sub 渲染ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 渲染ToolStripMenuItem.Click
        PictureBox1.Width = rrrr
        PictureBox1.Height = tttt
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim mBitmap As Bitmap
        PictureBox2.Image = PictureBox1.Image
        Dim start_time As Date = Now
        Dim rr, gg, bb, rr2, gg2, bb2, rr3, gg3, bb3, rr4, gg4, bb4 As Integer
        Dim Width As Integer, Height As Integer
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
            Dim widt As Integer = PictureBox1.Width
            For z = 1 To 10
                For k As Integer = widt * 4 * 5 * 2 + 4 To rgbValues.Length - Bpx - widt * 4 * 5 * 2 - 4 Step Bpx
                    bb = CByte(rgbValues(k - 4 * 5 * 2))
                    gg = CByte(rgbValues(k + 1 - 4 * 5))
                    rr = CByte(rgbValues(k + 2 - 4 * 5))
                    bb2 = CByte(rgbValues(k + widt * 4 * 5))
                    gg2 = CByte(rgbValues(k + 1 + widt * 4 * 5 * 2))
                    rr2 = CByte(rgbValues(k + 2 + widt * 4 * 5))
                    bb3 = CByte(rgbValues(k - widt * 4 * 5))
                    gg3 = CByte(rgbValues(k + 1 - widt * 4 * 5))
                    rr3 = CByte(rgbValues(k + 2 - widt * 4 * 5 * 2))
                    bb4 = CByte(rgbValues(k + 20))
                    gg4 = CByte(rgbValues(k + 1 + 20))
                    rr4 = CByte(rgbValues(k + 2 + 20))
                    rgbValues(k) = (bb + bb2 + bb3 + bb4) / 4
                    rgbValues(k + 1) = (gg + gg2 + gg3 + gg4) / 4
                    rgbValues(k + 2) = (rr + rr2 + rr3 + rr4) / 4
                    If Bpx = 4 Then
                        rgbA = rgbValues(k + 3)
                    End If
                Next
            Next
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
            PictureBox1.Image = mBitmap
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
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
            Dim bmpData2 As BitmapData = mBitmap2.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
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
            Dim rgbA As Byte
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                Bb = rgbValues(k)
                Gg = rgbValues(k + 1)
                Rr = rgbValues(k + 2)
                bb2 = rgbValues2(k)
                gg2 = rgbValues2(k + 1)
                rr2 = rgbValues2(k + 2)
                Rr = Math.Abs(Rr - rr2)
                Gg = Math.Abs(Gg - gg2)
                Bb = Math.Abs(Bb - bb2)
                If Rr > 255 Then Rr = 255
                If Gg > 255 Then Gg = 255
                If Bb > 255 Then Bb = 255
                If Rr < 0 Then Rr = 0
                If Gg < 0 Then Gg = 0
                If Bb < 0 Then Bb = 0
                rgbValues(k) = Bb
                rgbValues(k + 1) = Gg
                rgbValues(k + 2) = Rr
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
        對比色ToolStripMenuItem.PerformClick()
        System.GC.Collect()
        re2(re02 - 1) = Nothing
        re02 -= 1
        If Label8.Text = 100 Then
            PictureBox1.Width = rrrr
            PictureBox1.Height = tttt
        ElseIf Label8.Text = 50 Then
            PictureBox1.Width = rrrr / 2
            PictureBox1.Height = tttt / 2
        ElseIf Label8.Text = 25 Then
            PictureBox1.Width = rrrr / 4
            PictureBox1.Height = tttt / 4
        ElseIf Label8.Text = 12 Then
            PictureBox1.Width = rrrr / 8
            PictureBox1.Height = tttt / 8
        End If
    End Sub

    Private Sub 測試ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 測試ToolStripMenuItem.Click
        
        Dim rk As Integer
        rk = PictureBox1.Width
        Dim t As Integer
        t = PictureBox1.Height
        PictureBox3.Size = New Size(rk, t)
        Dim start_time As Date = Now
        Dim rr, gg, bb, rr2, gg2, bb2, rr3, gg3, bb3, rr4, gg4, bb4 As Integer
        Dim Width As Integer, Height As Integer
        Dim mBitmap As Bitmap
        For z = 1 To 10
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
                ' Dim rr, gg, bb, rr2, gg2, bb2, rr3, gg3, bb3, rr4, gg4, bb4 As Integer
                Dim widt As Integer = PictureBox1.Width
                Dim ll As Integer = rgbValues.Length
                For k As Integer = widt * 4 * 5 + 4 To ll - Bpx - widt * 4 * 5 - 4 Step Bpx
                    bb = CByte(rgbValues(k - 4))
                    gg = CByte(rgbValues(k + 1 - 4))
                    rr = CByte(rgbValues(k + 2 - 4))
                    bb2 = CByte(rgbValues(k + widt * 4))
                    gg2 = CByte(rgbValues(k + 1 + widt * 4))
                    rr2 = CByte(rgbValues(k + 2 + widt * 4))
                    bb3 = CByte(rgbValues(k - widt * 4))
                    gg3 = CByte(rgbValues(k + 1 - widt * 4))
                    rr3 = CByte(rgbValues(k + 2 - widt * 4))
                    bb4 = CByte(rgbValues(k + 4))
                    gg4 = CByte(rgbValues(k + 5))
                    rr4 = CByte(rgbValues(k + 6))
                    rgbValues(k) = (bb + bb2 + bb3 + bb4) / 4
                    rgbValues(k + 1) = (gg + gg2 + gg3 + gg4) / 4
                    rgbValues(k + 2) = (rr + rr2 + rr3 + rr4) / 4
                    If Bpx = 4 Then
                        rgbA = rgbValues(k + 3)
                    End If
                Next
                Marshal.Copy(rgbValues, 0, ptr, bytes) '
                mBitmap.UnlockBits(bmpData)
                Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
                PictureBox3.Image = mBitmap
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
            mBitmap2 = New Bitmap(PictureBox3.Image)
            Width = mBitmap2.Width
            Height = mBitmap2.Height
            Dim rect2 As New Rectangle(0, 0, Width, Height)
            Dim bmpData2 As BitmapData = mBitmap2.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
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
            Dim rgbA As Byte
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
                If Bpx = 4 Then
                    rgbA = rgbValues(k + 3)
                End If
            Next
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            mBitmap2.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        PictureBox3.Image = mBitmap
        Dim r, g, b As Integer
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
            Dim rgbA As Byte
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                b = CByte(255 - rgbValues(k))
                g = CByte(255 - rgbValues(k + 1))
                r = CByte(255 - rgbValues(k + 2))
                rgbValues(k) = b
                rgbValues(k + 1) = g
                rgbValues(k + 2) = r
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
        PictureBox3.Image = mBitmap
        System.GC.Collect()
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
            Dim rgbA As Byte
            Dim rbg1 As Integer
            Dim tra As Integer = 240
            For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                rbg1 = (rgbValues(k) / 3 + rgbValues(k + 1) / 3 + rgbValues(k + 2) / 3)
                If rbg1 >= tra Then
                    rgbValues(k) = 255
                    rgbValues(k + 1) = 255
                    rgbValues(k + 2) = 255
                Else
                    rgbValues(k) = 0
                    rgbValues(k + 1) = 0
                    rgbValues(k + 2) = 0
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
        PictureBox3.Image = mBitmap
        System.GC.Collect()


        '''''''''''''''''''
        For z = 1 To 1
            Try
                ''''''''''
                Dim rect2 As New Rectangle(0, 0, Width, Height)
                Dim bmpData2 As BitmapData = mBitmap2.LockBits(rect2, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
                Dim ptr2 As IntPtr = bmpData2.Scan0
                Dim bytes2 As Integer = bmpData2.Stride * Height
                mBitmap2 = New Bitmap(PictureBox2.Image)
                Width = mBitmap2.Width
                Height = mBitmap2.Height
                With bmpData2
                End With
                Dim Bpx As Byte = bmpData2.Stride \ mBitmap.Width
                Dim Bpx2 As Byte = bmpData2.Stride \ mBitmap2.Width
                Dim rgbValues(bytes2 - 1) As Byte
                Marshal.Copy(ptr2, rgbValues, 0, bytes2)
                Dim rgbValues2(bytes2 - 1) As Byte
                Marshal.Copy(ptr2, rgbValues2, 0, bytes2)
                Dim rgbA As Byte
                '''''''''''
                mBitmap = New Bitmap(PictureBox3.Image)
                Width = mBitmap.Width
                Height = mBitmap.Height
                Dim rect As New Rectangle(0, 0, Width, Height)
                Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
                Dim ptr As IntPtr = bmpData.Scan0
                Dim bytes As Integer = bmpData.Stride * Height
                With bmpData
                End With

                Marshal.Copy(ptr, rgbValues, 0, bytes)

                ' Dim rr, gg, bb, rr2, gg2, bb2, rr3, gg3, bb3, rr4, gg4, bb4 As Integer
                Dim widt As Integer = PictureBox1.Width
                Dim ll As Integer = rgbValues.Length
                For k As Integer = widt * 4 * 5 + 4 To ll - Bpx - widt * 4 * 5 - 4 Step Bpx
                    If rgbValues(k - 4) = 0 Then
                    ElseIf rgbValues(k - 8) = 0 Then
                        bb = CByte(rgbValues2(k - 4))
                        gg = CByte(rgbValues2(k + 1 - 4))
                        rr = CByte(rgbValues2(k + 2 - 4))
                    ElseIf rgbValues(k - 12) = 0 Then
                        bb = CByte(rgbValues2(k - 8))
                        gg = CByte(rgbValues2(k + 1 - 8))
                        rr = CByte(rgbValues2(k + 2 - 8))
                    ElseIf rgbValues(k - 16) = 0 Then
                        bb = CByte(rgbValues2(k - 12))
                        gg = CByte(rgbValues2(k + 1 - 12))
                        rr = CByte(rgbValues2(k + 2 - 12))
                    End If
                    '
                    If rgbValues(k + widt * 4) = 0 Then
                    ElseIf rgbValues(k + widt * 8) = 0 Then
                        bb2 = CByte(rgbValues2(k + widt * 4))
                        gg2 = CByte(rgbValues2(k + 1 + widt * 4))
                        rr2 = CByte(rgbValues2(k + 2 + widt * 4))
                    ElseIf rgbValues(k + widt * 12) = 0 Then
                        bb2 = CByte(rgbValues2(k + widt * 8))
                        gg2 = CByte(rgbValues2(k + 1 + widt * 8))
                        rr2 = CByte(rgbValues2(k + 2 + widt * 8))
                    ElseIf rgbValues(k + widt * 16) = 0 Then
                        bb2 = CByte(rgbValues2(k + widt * 12))
                        gg2 = CByte(rgbValues2(k + 1 + widt * 12))
                        rr2 = CByte(rgbValues2(k + 2 + widt * 12))
                    End If
                    '
                    If rgbValues(k - widt * 4) = 0 Then
                    ElseIf rgbValues(k - widt * 8) = 0 Then
                        bb3 = CByte(rgbValues2(k - widt * 4))
                        gg3 = CByte(rgbValues2(k + 1 - widt * 4))
                        rr3 = CByte(rgbValues2(k + 2 - widt * 4))
                    ElseIf rgbValues(k - widt * 12) = 0 Then
                        bb3 = CByte(rgbValues2(k - widt * 8))
                        gg3 = CByte(rgbValues2(k + 1 - widt * 8))
                        rr3 = CByte(rgbValues2(k + 2 - widt * 8))
                    ElseIf rgbValues(k - widt * 16) = 0 Then
                        bb3 = CByte(rgbValues2(k - widt * 12))
                        gg3 = CByte(rgbValues2(k + 1 - widt * 12))
                        rr3 = CByte(rgbValues2(k + 2 - widt * 12))
                    End If
                    '
                    If rgbValues(k + 4) = 0 Then
                    ElseIf rgbValues(k + 8) = 0 Then
                        bb = CByte(rgbValues2(k + 4))
                        gg = CByte(rgbValues2(k + 1 + 4))
                        rr = CByte(rgbValues2(k + 2 + 4))
                    ElseIf rgbValues(k + 12) = 0 Then
                        bb = CByte(rgbValues2(k + 8))
                        gg = CByte(rgbValues2(k + 1 + 8))
                        rr = CByte(rgbValues2(k + 2 + 8))
                    ElseIf rgbValues(k + 16) = 0 Then
                        bb = CByte(rgbValues2(k + 12))
                        gg = CByte(rgbValues2(k + 1 + 12))
                        rr = CByte(rgbValues2(k + 2 + 12))
                    End If








                    rgbValues(k) = (bb + bb2 + bb3 + bb4) / 4
                    rgbValues(k + 1) = (gg + gg2 + gg3 + gg4) / 4
                    rgbValues(k + 2) = (rr + rr2 + rr3 + rr4) / 4
                    If Bpx = 4 Then
                        rgbA = rgbValues(k + 3)
                    End If
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

    End Sub

    Private Sub 測試2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 測試2ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim start_time As Date = Now
        Dim R As Byte, G As Byte, B As Byte
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
                If rgbValues(k) = 0 Then
                    B = CByte(255 - rgbValues(k))
                    G = CByte(255 - rgbValues(k + 1))
                    R = CByte(255 - rgbValues(k + 2))
                    rgbValues(k) = 255
                    rgbValues(k + 1) = 255
                    rgbValues(k + 2) = 255
                    If Bpx = 4 Then
                        rgbA = rgbValues(k + 3)
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
    Private Sub 水墨畫二值化ToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 水墨畫二值化ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form3
        w.ShowDialog()
    End Sub
    Private Sub 色域選擇ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 色域選擇ToolStripMenuItem.Click
        Dim ya As Byte
        ya = MsgBox("選擇範圍以及解除選擇會更新所有圖層和環原點，是否繼續?", MsgBoxStyle.YesNo, "色域選擇")
        If ya = 6 Then
            PictureBox4.Image = PictureBox1.Image
            re2(re02) = PictureBox1.Image
            re02 += 1
            re(0) = PictureBox1.Image
            PictureBox3.Image = PictureBox1.Image
            re02 = 0
            re2(re02) = PictureBox1.Image
            re02 += 1
            解除選擇ToolStripMenuItem.Enabled = True
            色域選擇ToolStripMenuItem.Enabled = False
            圖片ToolStripMenuItem.Enabled = False
            編輯ToolStripMenuItem.Enabled = False
            剪貼簿ToolStripMenuItem.Enabled = False
            圖層ToolStripMenuItem.Enabled = False
            縮放ToolStripMenuItem.Enabled = False
            旋轉ToolStripMenuItem.Enabled = False
            列印ToolStripMenuItem.Enabled = False
            模糊ToolStripMenuItem.Enabled = False
            縮放模糊ToolStripMenuItem.Enabled = False
            Dim w As New Form28
            w.ShowDialog()
        End If
    End Sub
    Private Sub 解除選擇ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 解除選擇ToolStripMenuItem.Click
        Try
            Dim start_time As Date = Now
            Dim Width As Integer, Height As Integer
            Dim mBitmap As Bitmap
            Dim mBitmap2 As Bitmap
            mBitmap = New Bitmap(PictureBox1.Image)
            Width = mBitmap.Width
            Height = mBitmap.Height
            Dim rect As New Rectangle(0, 0, Width, Height)
            Dim bmpData As BitmapData = mBitmap.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
            Dim ptr As IntPtr = bmpData.Scan0
            Dim bytes As Integer = bmpData.Stride * Height
            With bmpData
            End With
            mBitmap2 = New Bitmap(PictureBox4.Image)
            Width = mBitmap2.Width
            Height = mBitmap2.Height
            Dim rect2 As New Rectangle(0, 0, Width, Height)
            Dim bmpData2 As BitmapData = mBitmap2.LockBits(rect, ImageLockMode.ReadWrite, mBitmap.PixelFormat)
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
                If rgbValues(k + 3) = 1 Then
                    rgbValues(k) = rgbValues2(k)
                    rgbValues(k + 1) = rgbValues2(k + 1)
                    rgbValues(k + 2) = rgbValues2(k + 2)
                    rgbValues(k + 3) = rgbValues2(k + 3)
                End If
            Next
            Marshal.Copy(rgbValues, 0, ptr, bytes) '
            mBitmap.UnlockBits(bmpData)
            Dim elapsed_time As TimeSpan = Now.Subtract(start_time)
            PictureBox1.Image = mBitmap
        Catch ex As SystemException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        System.GC.Collect()
        re2(re02) = PictureBox1.Image
        re02 += 1
        re(0) = PictureBox1.Image
        PictureBox3.Image = PictureBox1.Image
        re02 = 0
        re2(re02) = PictureBox1.Image
        re02 += 1
        解除選擇ToolStripMenuItem.Enabled = False
        色域選擇ToolStripMenuItem.Enabled = True
        範圍選擇ToolStripMenuItem.Enabled = True
        圖片ToolStripMenuItem.Enabled = True
        編輯ToolStripMenuItem.Enabled = True
        剪貼簿ToolStripMenuItem.Enabled = True
        圖層ToolStripMenuItem.Enabled = True
        縮放ToolStripMenuItem.Enabled = True
        旋轉ToolStripMenuItem.Enabled = True
        列印ToolStripMenuItem.Enabled = True
        模糊ToolStripMenuItem.Enabled = True
        縮放模糊ToolStripMenuItem.Enabled = True
    End Sub
    Private Sub 範圍選擇ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 範圍選擇ToolStripMenuItem.Click
        Dim ya As Byte
        ya = MsgBox("選擇範圍以及解除選擇會更新所有圖層和環原點，是否繼續?", MsgBoxStyle.YesNo, "色域選擇")
        If ya = 6 Then
            PictureBox4.Image = PictureBox1.Image
            re2(re02) = PictureBox1.Image
            re02 += 1
            re(0) = PictureBox1.Image
            PictureBox3.Image = PictureBox1.Image
            re02 = 0
            re2(re02) = PictureBox1.Image
            re02 += 1
            解除選擇ToolStripMenuItem.Enabled = True
            範圍選擇ToolStripMenuItem.Enabled = False
            圖片ToolStripMenuItem.Enabled = False
            編輯ToolStripMenuItem.Enabled = False
            剪貼簿ToolStripMenuItem.Enabled = False
            圖層ToolStripMenuItem.Enabled = False
            縮放ToolStripMenuItem.Enabled = False
            旋轉ToolStripMenuItem.Enabled = False
            列印ToolStripMenuItem.Enabled = False
            Dim w As New Form29
            w.ShowDialog()
        End If
    End Sub
    Private Sub 深淺調整ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 深淺調整ToolStripMenuItem.Click
        re2(re02) = PictureBox1.Image
        re02 += 1
        Dim w As New Form30
        w.ShowDialog()
    End Sub
    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
        PictureBox1.Width = rrrr / 2
        PictureBox1.Height = tttt / 2
        Label8.Text = 50
    End Sub
    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        PictureBox1.Width = rrrr / 4
        PictureBox1.Height = tttt / 4
        Label8.Text = 25
    End Sub
    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        PictureBox1.Width = rrrr
        PictureBox1.Height = tttt
        Label8.Text = 100
    End Sub
    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        PictureBox1.Width = rrrr / 8
        PictureBox1.Height = tttt / 8
        Label8.Text = 12
    End Sub
    Private Sub 官方網站ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 官方網站ToolStripMenuItem.Click
        Shell("cmd.exe /c start " & "http://photoeggblogger.blogspot.tw/")
    End Sub
End Class