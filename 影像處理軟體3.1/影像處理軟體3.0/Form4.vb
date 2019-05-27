Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form4
    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "深度"
            Label2.Text = "雜訊"
            Label3.Text = "細部"
            Button1.Text = "確定"
            Me.Text = "版畫"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "depth"
            Label2.Text = "Noise"
            Label3.Text = "Details"
            Button1.Text = "determine"
            Me.Text = "print"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "深さ"
            Label2.Text = "ノイズ"
            Label3.Text = "ディテール"
            Button1.Text = "決定します"
            Me.Text = "印刷"
        End If
        Button1.BackColor = Form1.BackColor
        Me.BackColor = Form1.BackColor
        Me.ForeColor = Form1.ForeColor
        PictureBox1.Image = Form1.PictureBox1.Image
        PictureBox2.Image = Form1.PictureBox1.Image
        PictureBox3.Image = Form1.PictureBox1.Image
        PictureBox4.Image = Form1.PictureBox1.Image
        Dim a As New Bitmap(PictureBox1.Image)
        PictureBox1.Size = New Size(a.Width, a.Height)
        Me.Width = a.Width + 200
        Me.Height = a.Height + 200
        PictureBox2.Left = -200
        PictureBox3.Left = -200
        PictureBox4.Left = -200
    End Sub
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
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
            Dim tra As Integer = TrackBar1.Value
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
        PictureBox3.Image = mBitmap
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
        PictureBox4.Image = mBitmap
        System.GC.Collect()
        For i = 1 To TrackBar3.Value
            Try
                mBitmap = New Bitmap(PictureBox4.Image)
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
                Dim tra As Integer = TrackBar1.Value
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
            PictureBox3.Image = mBitmap
            System.GC.Collect()
            Try
                mBitmap = New Bitmap(PictureBox4.Image)
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
            PictureBox4.Image = mBitmap
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
            Dim tra2 As Integer = TrackBar2.Value
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
    Private Sub TrackBar2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar2.Scroll
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
            Dim tra As Integer = TrackBar1.Value
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
        PictureBox3.Image = mBitmap
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
        PictureBox4.Image = mBitmap
        System.GC.Collect()
        For i = 1 To TrackBar3.Value
            Try
                mBitmap = New Bitmap(PictureBox4.Image)
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
                Dim tra As Integer = TrackBar1.Value
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
            PictureBox3.Image = mBitmap
            System.GC.Collect()
            Try
                mBitmap = New Bitmap(PictureBox4.Image)
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
            PictureBox4.Image = mBitmap
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
            Dim tra2 As Integer = TrackBar2.Value
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
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.PictureBox1.Image = PictureBox1.Image
        Me.Close()
    End Sub
    Private Sub TrackBar3_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar3.Scroll
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
            Dim tra As Integer = TrackBar1.Value
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
        PictureBox3.Image = mBitmap
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
        PictureBox4.Image = mBitmap
        For i = 1 To TrackBar3.Value
            Try
                mBitmap = New Bitmap(PictureBox4.Image)
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
                Dim tra As Integer = TrackBar1.Value
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
            PictureBox3.Image = mBitmap
            System.GC.Collect()
            Try
                mBitmap = New Bitmap(PictureBox4.Image)
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
            PictureBox4.Image = mBitmap
            System.GC.Collect()
        Next
        PictureBox1.Image = mBitmap
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
            Dim tra2 As Integer = TrackBar2.Value
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
End Class