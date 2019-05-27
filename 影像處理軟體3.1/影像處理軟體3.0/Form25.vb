Public Class Form25
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Shell("cmd.exe /c start " & "https://dotblogs.com.tw/larrynung/archive/2009/06/03/8652.aspx")
    End Sub
    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Shell("cmd.exe /c start " & "http://www.blueshop.com.tw/board/FUM20050124191756KKC/BRD20070815152558NU8.html")
    End Sub
    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Shell("cmd.exe /c start " & "https://zhidao.baidu.com/question/1766687328225392820.html")
    End Sub
    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        Shell("cmd.exe /c start " & "http://www.programmer-club.com.tw/ShowSameTitleN/vbdotnet/9453.html")
    End Sub
    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click
        Shell("cmd.exe /c start " & "http://www.chday169.url.tw/VB%20Net%20Graphics%20method(B).htm")
    End Sub
    Private Sub Form25_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Form1.語言ToolStripMenuItem.Text = "語言" Then
            Label1.Text = "感謝以下網頁提供教學(點擊網址可連上該網頁)"
            Label4.Text = "顏色處理"
            Label5.Text = "圖片存檔"
            Label7.Text = "列印圖片"
            Label9.Text = "記憶體釋放"
            Label11.Text = "進階影像處理"
            Me.Text = "參考文獻"
        ElseIf Form1.語言ToolStripMenuItem.Text = "Language" Then
            Label1.Text = "Thanks to the following pages for teaching (Click the URL to link to the page)"
            Label4.Text = "Color processing"
            Label5.Text = "Picture Archive"
            Label7.Text = "Print a picture"
            Label9.Text = "Memory release"
            Label11.Text = "Advanced Image Processing"
            Me.Text = "references"
        ElseIf Form1.語言ToolStripMenuItem.Text = "言語" Then
            Label1.Text = "教え提供以下のページのおかげで（URLをクリックしてページに接続することができます）"
            Label4.Text = "色の処理"
            Label5.Text = "写真アーカイブ"
            Label7.Text = "印刷画像"
            Label9.Text = "メモリ解放"
            Label11.Text = "高度画像処理"
            Me.Text = "リファレンス"
        End If
        Me.BackColor = Form1.BackColor
        Me.ForeColor = Form1.ForeColor
    End Sub
End Class