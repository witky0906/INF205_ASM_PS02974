Public Class frmTrangChu
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmKhachHang.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmHoaDon.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmSanPham.Show()
    End Sub

    Private Sub btnLienHe_Click(sender As Object, e As EventArgs) Handles btnLienHe.Click
        System.Diagnostics.Process.Start("https://docs.google.com/a/fpt.edu.vn/forms/d/1RcEu34jjzBOfzvVhyM1Eds9hor_tjE0X25ohWu39zQ4/viewform")
    End Sub

    Private Sub frmTrangChu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class