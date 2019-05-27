Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form9
    Dim rrrr As Integer
    Dim tttt As Integer
    Private Sub Form9_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "大小"
            Button1.Text = "確定"
            Me.Text = "縮小圖片"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "size"
            Button1.Text = "determine"
            Me.Text = "Zoom out"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "サイズ"
            Button1.Text = "決定します"
            Me.Text = "サムネイル画像"
        End If
        Button1.BackColor = Form1.BackColor
        Me.BackColor = Form1.BackColor
        Me.ForeColor = Form1.ForeColor
        PictureBox1.Image = Form1.PictureBox1.Image
        PictureBox2.Image = Form1.PictureBox1.Image
        Dim a As New Bitmap(PictureBox1.Image)
        PictureBox1.Size = New Size(a.Width, a.Height)
        PictureBox2.Size = New Size(a.Width, a.Height)
        Me.Width = a.Width + 500
        Me.Height = a.Height + 500
        PictureBox2.Left = -200
        PictureBox2.Hide()
        rrrr = PictureBox1.Width
        tttt = PictureBox1.Height
    End Sub
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Dim anti_alias As Boolean = True
        Dim mbitmap As Bitmap
        mbitmap = New Bitmap(PictureBox2.Image)
        PictureBox2.Image = mbitmap
        Dim wid As Integer = CInt(PictureBox2.Width * TrackBar1.Value / 100)
        Dim hgt As Integer = CInt(PictureBox2.Height * TrackBar1.Value / 100)
        Dim rBitmap As New Bitmap(wid, hgt)
        Dim gr As Graphics = Graphics.FromImage(rBitmap)
        If anti_alias Then gr.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBilinear
        gr.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        gr.DrawImage(mbitmap, 0, 0, wid - 1, hgt - 1)
        PictureBox1.Image = rBitmap
        PictureBox1.Size = New Size(wid, hgt)
        System.GC.Collect()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.rrrr = PictureBox1.Width
        Form1.tttt = PictureBox1.Height
        Form1.PictureBox1.Image = PictureBox1.Image
        Form1.PictureBox1.Size = PictureBox1.Size
        Form1.建立還原點ToolStripMenuItem.PerformClick()
        Form1.PictureBox3.Image = PictureBox1.Image
        If Form1.Label8.Text = 100 Then
            Form1.PictureBox1.Width = PictureBox1.Width
            Form1.PictureBox1.Height = PictureBox1.Height
        ElseIf Form1.Label8.Text = 50 Then
            Form1.PictureBox1.Width = PictureBox1.Width / 2
            Form1.PictureBox1.Height = PictureBox1.Height / 2
        ElseIf Form1.Label8.Text = 25 Then
            Form1.PictureBox1.Width = PictureBox1.Width / 4
            Form1.PictureBox1.Height = PictureBox1.Height / 4
        ElseIf Form1.Label8.Text = 12 Then
            Form1.PictureBox1.Width = PictureBox1.Width / 8
            Form1.PictureBox1.Height = PictureBox1.Height / 8
        End If
        Me.Close()
    End Sub
End Class