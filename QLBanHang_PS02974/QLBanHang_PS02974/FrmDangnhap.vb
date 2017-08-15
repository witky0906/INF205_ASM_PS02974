Imports System.Configuration
Imports System.Data.SqlClient
Public Class frmDangNhap
    'Khai bao bien toan cuc de ket noi voi CSDL
    Private _ConnectionString As String = ConfigurationSettings.AppSettings("MyConnectionString")
    Private conn As SqlConnection
    Private da As SqlDataAdapter

    Dim Connect As String = "workstation id=ASMPS02974.mssql.somee.com;packet size=4096;
user id=witky0906_SQLLogin_1;pwd=qx8lbpyey7;
data source=ASMPS02974.mssql.somee.com;persist security info=False;initial catalog=ASMPS02974"
    Dim ketnoi As SqlConnection = New SqlConnection(Connect)

    'Dinh nghia ham lay du lieu do vao table
    Private Function getDataTable(sqlQuery As String) As DataTable
        Dim dTable As New DataTable
        'khoi tao bien conn
        conn = New SqlConnection(_ConnectionString)
        'khoi tao bien da
        da = New SqlDataAdapter(sqlQuery, conn)
        Try
            'mo connection
            conn.Open()
            'do du lieu vao  dtable
            da.Fill(dTable)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error") 'thong bao loi neu co loi xay ra
        Finally
            conn.Close() 'dong chuoi ket noi

        End Try
        Return dTable
    End Function

    'Dinh nghia ham kiem tra username ,password nhap vao co dung khong
    Private Function CheckLogin(user As String, pass As String) As Boolean
        Dim sqlQuery As String = String.Format("select * from dbo.Account where username = '{0}' and password = '{1}'", user, pass)
        Dim dTable As DataTable = getDataTable(sqlQuery)
        Return dTable.Rows.Count > 0
    End Function

    'Dinh nghia ham kiem tra user, pass nhap vao co rong hay khong
    Private Function IsEmpty() As Boolean
        'Ham tra ve True neu username hoac password is empty
        Return String.IsNullOrEmpty(Me.txtTendangnhap.Text) OrElse String.IsNullOrEmpty(Me.txtMatkhau.Text)
    End Function
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtMatkhau.TextChanged

    End Sub



    Private Sub btnDangnhap_Click(sender As Object, e As EventArgs) Handles btnDangnhap.Click
        'Kiem tra username va password
        If IsEmpty() Then
            MessageBox.Show("Username,Password cannot be Empty !")
        Else
            If CheckLogin(Me.txtTendangnhap.Text.ToLower, Me.txtMatkhau.Text.ToLower) Then 'dang nhap thanh cong
                MessageBox.Show("Đăng nhập thành công !")
                Me.Hide()
                frmTrangChu.Show()

            Else 'Truong hop sai username va password
                MessageBox.Show(" Username hoặc Password không đúng ")
            End If
        End If
    End Sub

    Private Sub btnHuybo_Click(sender As Object, e As EventArgs) Handles btnHuybo.Click
        If (MessageBox.Show("Bạn có thật sự muốn thoát không ?", "Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            Me.Close()
            Global.System.Windows.Forms.Application.Exit()
        End If
    End Sub

    Private Sub frmDangNhap_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class