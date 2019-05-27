Public Class Form24
    Dim X, Y As Integer
    Dim x2, y2 As Object
    Dim draw0 As Byte = 0
    Private Sub Form24_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Me.Text = "圖片顏色查看程式"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Me.Text = "Image Color Viewer"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Me.Text = "カラー画像表示プログラム"
        End If
        Me.BackColor = Form1.BackColor
        Me.ForeColor = Form1.ForeColor
        PictureBox1.Image = Form1.PictureBox1.Image
        Dim a As New Bitmap(PictureBox1.Image)
        PictureBox1.Size = New Size(Form1.PictureBox1.Width, Form1.PictureBox1.Height)
        Me.Width = a.Width + 500
        Me.Height = a.Height + 500
    End Sub
    Private Sub picturebox1_Mousemove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        Try
            Dim png As New Bitmap(PictureBox1.Image)
            PictureBox1.Image = png
            X = e.X
            Y = e.Y
            Dim co As Color
            co = png.GetPixel(X, Y)
            Label2.Text = co.R
            Label4.Text = co.G
            Label6.Text = co.B
            System.GC.Collect()
        Catch ex As SystemException
        End Try
    End Sub
End Class