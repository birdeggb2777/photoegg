Public Class Form10
    Private Sub Form10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "模糊程度"
            Button1.Text = "確定"
            Me.Text = "素描"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "Degree of blur"
            Button1.Text = "determine"
            Me.Text = "sketch"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "ぼかしの度合い"
            Button1.Text = "決定します"
            Me.Text = "ズームブラー"
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
    End Sub
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
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
        System.GC.Collect()
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
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.re2(Form1.re02) = Form1.PictureBox1.Image
        Form1.re02 += 1
        Form1.PictureBox1.Image = PictureBox1.Image
        Me.Close()
    End Sub
End Class