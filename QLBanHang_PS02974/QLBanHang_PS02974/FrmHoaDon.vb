Imports System.Data
Imports System.Data.SqlClient

Public Class FrmHoaDon

    Dim con As New SqlConnection("workstation id=ASMPS02974.mssql.somee.com;packet size=4096;user id=witky0906_SQLLogin_1;pwd=qx8lbpyey7;data source=ASMPS02974.mssql.somee.com;persist security info=False;initial catalog=ASMPS02974")

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            con.Open()
            con.Close()
        Catch ex As Exception
            MessageBox.Show("Kết nối không thành công")
        End Try
        LoadData()
    End Sub

    Private Sub LoadData()
        con.Open()
        Dim com As New SqlCommand("Select * from HoaDon", con)
        Dim da As New SqlDataAdapter(com)
        Dim dt As New DataTable
        da.Fill(dt)
        con.Close()
        lsvHD.Items.Clear()
        Dim i As Integer
        For Each row As DataRow In dt.Rows
            lsvHD.Items.Add(row("MaHD").ToString())
            lsvHD.Items(i).SubItems.Add(row("MaKH").ToString())
            lsvHD.Items(i).SubItems.Add(row("NgayLapHD").ToString())
            lsvHD.Items(i).SubItems.Add(row("SoLuong").ToString())
            lsvHD.Items(i).SubItems.Add(row("MaSP").ToString())

            i += 1
        Next
        con.Close()
    End Sub

    Private Sub lsvSanPham_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvHD.SelectedIndexChanged
        For Each list As ListViewItem In lsvHD.SelectedItems
            txtMaHD.Text = list.SubItems(0).Text
            txtMaKH.Text = list.SubItems(1).Text
            dtpHD.Text = list.SubItems(2).Text
            txtSL.Text = list.SubItems(3).Text
            txtMaSP.Text = list.SubItems(4).Text
        Next
    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Try
            con.Open()
            Dim MaHD As String = txtMaHD.Text
            Dim MaKH As String = txtMaKH.Text
            Dim NgayLapHD As String = Format(Convert.ToDateTime(dtpHD.Text), "MM/dd/yyyy")
            Dim SoLuong As String = txtSL.Text
            Dim MaSP As String = txtMaSP.Text
            Dim com As New SqlCommand("INSERT INTO HoaDon (MaHD,MaKH,NgayLapHD,SoLuong,MaSP) VALUES (N'" + MaHD + "',N'" + MaKH + "',N'" + NgayLapHD + "',N'" + SoLuong + "',N'" + MaSP + "')", con)
            com.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
        Catch ex As Exception
            MessageBox.Show("Lỗi thêm dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Try
            con.Open()
            Dim MaHD As String = txtMaHD.Text
            Dim com As New SqlCommand("DELETE FROM HoaDon Where MaHD = '" + MaHD + "'", con)
            com.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
        Catch ex As Exception
            MessageBox.Show("Lỗi xóa dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        Try
            con.Open()
            Dim MaHD As String = txtMaHD.Text
            Dim MaKH As String = txtMaKH.Text
            Dim NgayLapHD As String = Format(Convert.ToDateTime(dtpHD.Text), "MM/dd/yyyy")
            Dim SoLuong As String = txtSL.Text
            Dim MaSP As String = txtMaSP.Text
            Dim com As New SqlCommand("UPDATE HoaDon SET MaKH =N'" + MaKH + "',NgayLapHD =N'" + NgayLapHD + "',SoLuong =N'" + SoLuong + "',MaSP =N'" + MaSP + "' WHERE MaHD =N'" + MaHD + "'", con)
            com.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
        Catch ex As Exception
            MessageBox.Show("Lỗi cập nhật dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        frmTrangChu.Show()

    End Sub
End Class