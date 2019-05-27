Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form29
    Dim w1 As Integer
    Dim h1 As Integer
    Dim w2 As Integer
    Dim h2 As Integer
    Private Sub Form29_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Me.Text = "範圍選擇"
            Button1.Text = "確定"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Me.Text = "Range selection"
            Button1.Text = "determine"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Me.Text = "範囲選択"
            Button1.Text = "決定します"
        End If
        Me.BackColor = Form1.BackColor
        Me.ForeColor = Form1.ForeColor
        Button1.BackColor = Form1.BackColor
        PictureBox1.Image = Form1.PictureBox1.Image
        PictureBox2.Image = Form1.PictureBox1.Image
        Dim a As New Bitmap(PictureBox1.Image)
        PictureBox1.Size = New Size(a.Width, a.Height)
        Me.Width = a.Width + 500
        Me.Height = a.Height + 500
        w2 = a.Width
        h2 = a.Height
        PictureBox2.Left = -200
        Label1.Text = "Ｘ：" & w1 & "～" & w2
        Label2.Text = "Ｙ：" & h1 & "～" & h2
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.PictureBox1.Image = PictureBox1.Image
        Me.Close()
    End Sub
    Private Sub picturebox1_Mousedown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        w1 = e.X
        h1 = e.Y
        Label1.Text = "Ｘ：" & w1 & "～" & w2
        Label2.Text = "Ｙ：" & h1 & "～" & h2
    End Sub
    Private Sub picturebox1_Mouseup(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        w2 = e.X
        h2 = e.Y
        Label1.Text = "Ｘ：" & w1 & "～" & w2
        Label2.Text = "Ｙ：" & h1 & "～" & h2
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
            Dim wi As Integer = PictureBox1.Width
            Dim he As Integer = PictureBox1.Height
            '   For k As Integer = 0 To rgbValues.Length - Bpx Step Bpx
            '       If rgbValues.Length / k / Bpx >= w1 And rgbValues.Length / k / Bpx <= w2 And k Then
            '
            '       Else
            '           rgbValues(k + 3) = 1
            '       End If
            '   Next
            '     For i2 = w1 To (w2 - w1) * 4 - 4 Step Bpx
            '         For i1 = h1 To (h2 - h1) * 4 - 4 Step Bpx
            '             rgbValues(i2 * wi + k + wi * i + i1) = B
            '             rgbValues(i2 * wi + k + wi * i + i1 + 1) = G
            '             rgbValues(i2 * wi + k + wi * i + i1 + 2) = R
            '         Next
            '     Next
            ' For i As Integer = w1 * 4 To w2 * 4 Step Bpx * (w2 - w1)
            '     For k As Integer = h1 * 4 To h2 * 4 Step Bpx * (h2 - h1)
            '         B = 0
            '         G = 0
            '         R = 0
            '         For i2 = w1 To (w2 - w1) * 4 - 4 Step Bpx
            '             For i1 = w1 To (w2 - w1) * 4 - 4 Step Bpx
            '                 rgbValues(i2 * wi + k + wi * i + i1) = B
            '                 rgbValues(i2 * wi + k + wi * i + i1 + 1) = G
            '                 rgbValues(i2 * wi + k + wi * i + i1 + 2) = R
            '             Next
            '         Next
            '     Next
            ' Next
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