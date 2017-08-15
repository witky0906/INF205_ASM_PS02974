Imports System.Data
Imports System.Data.SqlClient

Public Class frmSanPham


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
        Dim com As New SqlCommand("Select * from SanPham", con)
        Dim da As New SqlDataAdapter(com)
        Dim dt As New DataTable
        da.Fill(dt)
        con.Close()
        lsvSanPham.Items.Clear()
        Dim i As Integer
        For Each row As DataRow In dt.Rows
            lsvSanPham.Items.Add(row("MaSP").ToString())
            lsvSanPham.Items(i).SubItems.Add(row("TenSP").ToString())
            lsvSanPham.Items(i).SubItems.Add(row("GiaTien").ToString())

            i += 1
        Next
        con.Close()
    End Sub

    Private Sub lsvSanPham_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvSanPham.SelectedIndexChanged
        For Each list As ListViewItem In lsvSanPham.SelectedItems
            txtMaSP.Text = list.SubItems(0).Text
            txtTenSP.Text = list.SubItems(1).Text
            txtGiaTien.Text = list.SubItems(2).Text

        Next
    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Try
            con.Open()
            Dim MaSP As String = txtMaSP.Text
            Dim TenSP As String = txtTenSP.Text
            Dim GiaTien As String = txtGiaTien.Text

            Dim com As New SqlCommand("INSERT INTO SanPham (MaSP,TenSP,GiaTien) VALUES (N'" + MaSP + "',N'" + TenSP + "',N'" + GiaTien + "')", con)
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
            Dim MaSP As String = txtMaSP.Text
            Dim com As New SqlCommand("DELETE FROM SanPham Where MaSP = '" + MaSP + "'", con)
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
            Dim MaSP As String = txtMaSP.Text
            Dim TenSP As String = txtTenSP.Text
            Dim GiaTien As String = txtGiaTien.Text

            Dim com As New SqlCommand("UPDATE SanPham SET TenSP =N'" + TenSP + "',GiaTien =N'" + GiaTien + "' WHERE MaSP =N'" + MaSP + "'", con)
            com.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
        Catch ex As Exception
            MessageBox.Show("Lỗi cập nhật dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        If (MessageBox.Show("Bạn có thật sự muốn thoát không ?", "Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            Me.Close()
            Global.System.Windows.Forms.Application.Exit()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        frmTrangChu.Show()

    End Sub

    Private Sub btnDatHang_Click(sender As Object, e As EventArgs) Handles btnDatHang.Click
        System.Diagnostics.Process.Start("https://docs.google.com/a/fpt.edu.vn/forms/d/1R1bzLRC0jK8set4VK7iRebpC2rTPgRHXme6CL5VCAfY/viewform")
    End Sub
End Class
