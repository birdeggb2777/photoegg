Public Class Form8
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Button1.Text = "確定"
            Me.Text = "色彩修正"
            Label1.Text = "臨界值:"
            Label2.Text = "標準值:"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Button1.Text = "determine"
            Me.Text = "Color Correction"
            Label1.Text = "Critical value:"
            Label2.Text = "standard value:"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Button1.Text = "決定します"
            Me.Text = "色補正"
            Label1.Text = "臨界値:"
            Label2.Text = "標準値:"
        End If
        Me.BackColor = Form1.BackColor
        Me.ForeColor = Form1.ForeColor
        Button1.BackColor = Form1.BackColor
        TextBox1.Text = Form1.rgb127
        TextBox2.Text = Form1.rr127
        TextBox3.Text = Form1.gg127
        TextBox4.Text = Form1.bb127
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text >= 0 And TextBox1.Text <= 255 And TextBox2.Text >= 0 And TextBox2.Text <= 255 And TextBox3.Text >= 0 And TextBox3.Text <= 255 And TextBox4.Text >= 0 And TextBox4.Text <= 255 Then
                Form1.rgb127 = TextBox1.Text
                Form1.rr127 = TextBox2.Text
                Form1.gg127 = TextBox3.Text
                Form1.bb127 = TextBox4.Text
                Me.Close()
            Else
                MsgBox("請輸入0～255的數字")
            End If
        Catch
            MsgBox("請輸入0～255的數字")
        End Try
    End Sub
End Class