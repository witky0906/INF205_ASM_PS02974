Imports System.Data
Imports System.Data.SqlClient
Public Class FrmKhachHang
    Dim db As New DataTable

    Dim con As New SqlConnection("workstation id=ASMPS02974.mssql.somee.com;packet size=4096;user id=witky0906_SQLLogin_1;pwd=qx8lbpyey7;data source=ASMPS02974.mssql.somee.com;persist security info=False;initial catalog=ASMPS02974")

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbbTim.Text = "Mã KH"
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
        Dim com As New SqlCommand("Select * from  KhachHang", con)
        Dim da As New SqlDataAdapter(com)
            Dim dt As New DataTable
            da.Fill(dt)
            con.Close()
        lsvKH.Items.Clear()
        Dim i As Integer
            For Each row As DataRow In dt.Rows
            lsvKH.Items.Add(row("MaKH").ToString())
            lsvKH.Items(i).SubItems.Add(row("TenKH").ToString())
            lsvKH.Items(i).SubItems.Add(row("DiaChi").ToString())
            lsvKH.Items(i).SubItems.Add(row("DienThoai").ToString())
            i += 1
            Next
            con.Close()
        End Sub

    Private Sub lsvSanPham_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvKH.SelectedIndexChanged
        For Each list As ListViewItem In lsvKH.SelectedItems
            txtMaKH.Text = list.SubItems(0).Text
            txtTenKH.Text = list.SubItems(1).Text
            txtDiachi.Text = list.SubItems(2).Text
            txtSDT.Text = list.SubItems(3).Text
        Next
    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
            Try
                con.Open()
            Dim MaKH As String = txtMaKH.Text
            Dim TenKH As String = txtTenKH.Text
            Dim DiaChi As String = txtDiachi.Text
            Dim SDT As String = txtSDT.Text
            Dim com As New SqlCommand("INSERT INTO KhachHang (MaKH,TenKH,DiaChi,DienThoai) VALUES (N'" + MaKH + "',N'" + TenKH + "',N'" + DiaChi + "',N'" + SDT + "')", con)
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
            Dim MaKH As String = txtMaKH.Text
            Dim com As New SqlCommand("DELETE FROM  KhachHang Where MaKH = '" + MaKH + "'", con)
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
            Dim MaKH As String = txtMaKH.Text
            Dim TenKH As String = txtTenKH.Text
            Dim DiaChi As String = txtDiachi.Text
            Dim SDT As String = txtSDT.Text
            Dim com As New SqlCommand("UPDATE KhachHang SET TenKH =N'" + TenKH + "',DiaChi =N'" + DiaChi + "',DienThoai =N'" + SDT + "' WHERE MaKH =N'" + MaKH + "'", con)
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

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        frmTrangChu.Show()

    End Sub

    Private Sub btntim_Click(sender As Object, e As EventArgs) Handles btntim.Click

        Dim sql As String = "select * from KhachHang where MaKH like  '%" & txtTimkiem.Text & "%'"

        'load du lieu
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand(sql, con)
        da.Fill(dt)
        txtMaKH.DataBindings.Clear()
        txtTenKH.DataBindings.Clear()
        txtDiachi.DataBindings.Clear()
        txtSDT.DataBindings.Clear()
        txtMaKH.DataBindings.Add("text", dt, "MaKH")
        txtTenKH.DataBindings.Add("text", dt, "TenKH")
        txtDiachi.DataBindings.Add("text", dt, "Diachi")
        txtSDT.DataBindings.Add("text", dt, "DienThoai")
    End Sub
End Class

