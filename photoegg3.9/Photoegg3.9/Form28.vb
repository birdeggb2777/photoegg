Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form28
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        If TrackBar2.Value < TrackBar1.Value Then TrackBar2.Value = TrackBar1.Value
        Label1.Text = "R：" & TrackBar1.Value & "~" & TrackBar2.Value
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
            Dim r1 As Byte = TrackBar1.Value
            Dim r2 As Byte = TrackBar2.Value
            Dim g1 As Byte = TrackBar3.Value
            Dim g2 As Byte = TrackBar4.Value
            Dim b1 As Byte = TrackBar5.Value
            Dim b2 As Byte = TrackBar6.Value
            If RadioButton1.Checked = True Then
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    If rgbValues(k + 2) >= r1 And rgbValues(k + 2) <= r2 And rgbValues(k + 1) >= g1 And rgbValues(k + 1) <= g2 And rgbValues(k) >= b1 And rgbValues(k) <= b2 Then
                    Else
                        rgbValues(k + 3) = 1
                    End If
                Next
            Else
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    If rgbValues(k + 2) >= r1 And rgbValues(k + 2) <= r2 And rgbValues(k + 1) >= g1 And rgbValues(k + 1) <= g2 And rgbValues(k) >= b1 And rgbValues(k) <= b2 Then
                        rgbValues(k + 3) = 1
                    End If
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
        If TrackBar1.Value > TrackBar2.Value Then TrackBar1.Value = TrackBar2.Value
        Label1.Text = "R：" & TrackBar1.Value & "~" & TrackBar2.Value
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
            Dim r1 As Byte = TrackBar1.Value
            Dim r2 As Byte = TrackBar2.Value
            Dim g1 As Byte = TrackBar3.Value
            Dim g2 As Byte = TrackBar4.Value
            Dim b1 As Byte = TrackBar5.Value
            Dim b2 As Byte = TrackBar6.Value
            If RadioButton1.Checked = True Then
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    If rgbValues(k + 2) >= r1 And rgbValues(k + 2) <= r2 And rgbValues(k + 1) >= g1 And rgbValues(k + 1) <= g2 And rgbValues(k) >= b1 And rgbValues(k) <= b2 Then
                    Else
                        rgbValues(k + 3) = 1
                    End If
                Next
            Else
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    If rgbValues(k + 2) >= r1 And rgbValues(k + 2) <= r2 And rgbValues(k + 1) >= g1 And rgbValues(k + 1) <= g2 And rgbValues(k) >= b1 And rgbValues(k) <= b2 Then
                        rgbValues(k + 3) = 1
                    End If
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
        If TrackBar4.Value < TrackBar3.Value Then TrackBar4.Value = TrackBar3.Value
        Label2.Text = "G：" & TrackBar3.Value & "~" & TrackBar4.Value
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
            Dim r1 As Byte = TrackBar1.Value
            Dim r2 As Byte = TrackBar2.Value
            Dim g1 As Byte = TrackBar3.Value
            Dim g2 As Byte = TrackBar4.Value
            Dim b1 As Byte = TrackBar5.Value
            Dim b2 As Byte = TrackBar6.Value
            If RadioButton1.Checked = True Then
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    If rgbValues(k + 2) >= r1 And rgbValues(k + 2) <= r2 And rgbValues(k + 1) >= g1 And rgbValues(k + 1) <= g2 And rgbValues(k) >= b1 And rgbValues(k) <= b2 Then
                    Else
                        rgbValues(k + 3) = 1
                    End If
                Next
            Else
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    If rgbValues(k + 2) >= r1 And rgbValues(k + 2) <= r2 And rgbValues(k + 1) >= g1 And rgbValues(k + 1) <= g2 And rgbValues(k) >= b1 And rgbValues(k) <= b2 Then
                        rgbValues(k + 3) = 1
                    End If
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
    Private Sub TrackBar4_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar4.Scroll
        If TrackBar3.Value > TrackBar4.Value Then TrackBar3.Value = TrackBar4.Value
        Label2.Text = "G：" & TrackBar3.Value & "~" & TrackBar4.Value
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
            Dim r1 As Byte = TrackBar1.Value
            Dim r2 As Byte = TrackBar2.Value
            Dim g1 As Byte = TrackBar3.Value
            Dim g2 As Byte = TrackBar4.Value
            Dim b1 As Byte = TrackBar5.Value
            Dim b2 As Byte = TrackBar6.Value
            If RadioButton1.Checked = True Then
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    If rgbValues(k + 2) >= r1 And rgbValues(k + 2) <= r2 And rgbValues(k + 1) >= g1 And rgbValues(k + 1) <= g2 And rgbValues(k) >= b1 And rgbValues(k) <= b2 Then
                    Else
                        rgbValues(k + 3) = 1
                    End If
                Next
            Else
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    If rgbValues(k + 2) >= r1 And rgbValues(k + 2) <= r2 And rgbValues(k + 1) >= g1 And rgbValues(k + 1) <= g2 And rgbValues(k) >= b1 And rgbValues(k) <= b2 Then
                        rgbValues(k + 3) = 1
                    End If
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
    Private Sub TrackBar5_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar5.Scroll
        If TrackBar6.Value < TrackBar5.Value Then TrackBar6.Value = TrackBar5.Value
        Label3.Text = "B：" & TrackBar5.Value & "~" & TrackBar6.Value
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
            Dim r1 As Byte = TrackBar1.Value
            Dim r2 As Byte = TrackBar2.Value
            Dim g1 As Byte = TrackBar3.Value
            Dim g2 As Byte = TrackBar4.Value
            Dim b1 As Byte = TrackBar5.Value
            Dim b2 As Byte = TrackBar6.Value
            If RadioButton1.Checked = True Then
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    If rgbValues(k + 2) >= r1 And rgbValues(k + 2) <= r2 And rgbValues(k + 1) >= g1 And rgbValues(k + 1) <= g2 And rgbValues(k) >= b1 And rgbValues(k) <= b2 Then
                    Else
                        rgbValues(k + 3) = 1
                    End If
                Next
            Else
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    If rgbValues(k + 2) >= r1 And rgbValues(k + 2) <= r2 And rgbValues(k + 1) >= g1 And rgbValues(k + 1) <= g2 And rgbValues(k) >= b1 And rgbValues(k) <= b2 Then
                        rgbValues(k + 3) = 1
                    End If
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
    Private Sub TrackBar6_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar6.Scroll
        If TrackBar5.Value > TrackBar6.Value Then TrackBar5.Value = TrackBar6.Value
        Label3.Text = "B：" & TrackBar5.Value & "~" & TrackBar6.Value
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
            Dim r1 As Byte = TrackBar1.Value
            Dim r2 As Byte = TrackBar2.Value
            Dim g1 As Byte = TrackBar3.Value
            Dim g2 As Byte = TrackBar4.Value
            Dim b1 As Byte = TrackBar5.Value
            Dim b2 As Byte = TrackBar6.Value
            If RadioButton1.Checked = True Then
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    If rgbValues(k + 2) >= r1 And rgbValues(k + 2) <= r2 And rgbValues(k + 1) >= g1 And rgbValues(k + 1) <= g2 And rgbValues(k) >= b1 And rgbValues(k) <= b2 Then
                    Else
                        rgbValues(k + 3) = 1
                    End If
                Next
            Else
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    If rgbValues(k + 2) >= r1 And rgbValues(k + 2) <= r2 And rgbValues(k + 1) >= g1 And rgbValues(k + 1) <= g2 And rgbValues(k) >= b1 And rgbValues(k) <= b2 Then
                        rgbValues(k + 3) = 1
                    End If
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
    Private Sub Form28_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Me.Text = "色域選擇"
            Button1.Text = "確定"
            RadioButton1.Text = "正向選擇"
            RadioButton2.Text = "反向選擇"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Me.Text = "Gamut Select"
            Button1.Text = "determine"
            RadioButton1.Text = "Forward selection"
            RadioButton2.Text = "Inverse selection"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Me.Text = "色域を選択"
            Button1.Text = "決定します"
            RadioButton1.Text = "正の選択"
            RadioButton2.Text = "逆選択"
        End If
        Me.BackColor = Form1.BackColor
        Me.ForeColor = Form1.ForeColor
        Button1.BackColor = Form1.BackColor
        PictureBox1.Image = Form1.PictureBox1.Image
        PictureBox2.Image = Form1.PictureBox1.Image
        Dim a As New Bitmap(PictureBox1.Image)
        PictureBox1.Size = New Size(Form1.PictureBox1.Width, Form1.PictureBox1.Height)
        Me.Width = a.Width + 500
        Me.Height = a.Height + 500
        PictureBox2.Left = -200
        RadioButton1.Checked = True
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.PictureBox4.Image = Form1.PictureBox1.Image
        Form1.re2(Form1.re02) = Form1.PictureBox1.Image
        Form1.re02 += 1
        Form1.re(0) = Form1.PictureBox1.Image
        Form1.PictureBox3.Image = Form1.PictureBox1.Image
        Form1.re02 = 0
        Form1.re2(Form1.re02) = Form1.PictureBox1.Image
        Form1.re02 += 1
        Form1.解除選擇ToolStripMenuItem.Enabled = True
        Form1.色域選擇ToolStripMenuItem.Enabled = False
        Form1.色域選擇百分比ToolStripMenuItem.Enabled = False
        Form1.編輯ToolStripMenuItem.Enabled = False
        Form1.圖層ToolStripMenuItem.Enabled = False
        Form1.縮放ToolStripMenuItem.Enabled = False
        Form1.旋轉ToolStripMenuItem.Enabled = False
        Form1.模糊ToolStripMenuItem.Enabled = False
        Form1.縮放模糊ToolStripMenuItem.Enabled = False
        Form1.方框模糊ToolStripMenuItem.Enabled = False
        Form1.朦朧ToolStripMenuItem.Enabled = False
        Form1.玻璃ToolStripMenuItem.Enabled = False
        Form1.線稿ToolStripMenuItem.Enabled = False
        Form1.抽象畫ToolStripMenuItem.Enabled = False
        Form1.素描ToolStripMenuItem.Enabled = False
        Form1.PictureBox1.Image = PictureBox1.Image
        Me.Close()
    End Sub
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
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
            Dim r1 As Byte = TrackBar1.Value
            Dim r2 As Byte = TrackBar2.Value
            Dim g1 As Byte = TrackBar3.Value
            Dim g2 As Byte = TrackBar4.Value
            Dim b1 As Byte = TrackBar5.Value
            Dim b2 As Byte = TrackBar6.Value
            If RadioButton1.Checked = True Then
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    If rgbValues(k + 2) >= r1 And rgbValues(k + 2) <= r2 And rgbValues(k + 1) >= g1 And rgbValues(k + 1) <= g2 And rgbValues(k) >= b1 And rgbValues(k) <= b2 Then
                    Else
                        rgbValues(k + 3) = 1
                    End If
                Next
            Else
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    If rgbValues(k + 2) >= r1 And rgbValues(k + 2) <= r2 And rgbValues(k + 1) >= g1 And rgbValues(k + 1) <= g2 And rgbValues(k) >= b1 And rgbValues(k) <= b2 Then
                        rgbValues(k + 3) = 1
                    End If
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
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
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
            Dim r1 As Byte = TrackBar1.Value
            Dim r2 As Byte = TrackBar2.Value
            Dim g1 As Byte = TrackBar3.Value
            Dim g2 As Byte = TrackBar4.Value
            Dim b1 As Byte = TrackBar5.Value
            Dim b2 As Byte = TrackBar6.Value
            If RadioButton1.Checked = True Then
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    If rgbValues(k + 2) >= r1 And rgbValues(k + 2) <= r2 And rgbValues(k + 1) >= g1 And rgbValues(k + 1) <= g2 And rgbValues(k) >= b1 And rgbValues(k) <= b2 Then
                    Else
                        rgbValues(k + 3) = 1
                    End If
                Next
            Else
                For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
                    If rgbValues(k + 2) >= r1 And rgbValues(k + 2) <= r2 And rgbValues(k + 1) >= g1 And rgbValues(k + 1) <= g2 And rgbValues(k) >= b1 And rgbValues(k) <= b2 Then
                        rgbValues(k + 3) = 1
                    End If
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