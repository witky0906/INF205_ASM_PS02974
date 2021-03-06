-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2016-01-25 16:17:54.087
Create Database AssigmentDTDM_PS02974
USE AssigmentDTDM_PS02974

-- tables
-- Table: HoaDon
CREATE TABLE HoaDon (
    MaHD varchar(10)  NOT NULL,
    MaKH varchar(10)  NOT NULL,
    NgayLapHD datetime  NOT NULL,
    SoLuong int  NOT NULL,
    MaSP varchar(10)  NOT NULL,
    CONSTRAINT HoaDon_pk PRIMARY KEY  (MaHD)
)
;

-- Table: KhachHang
CREATE TABLE KhachHang (
    MaKH varchar(10)  NOT NULL,
    TenKH nvarchar(30)  NOT NULL,
    DiaChi varchar(50)  NOT NULL,
    DienThoai int  NOT NULL,
    CONSTRAINT KhachHang_pk PRIMARY KEY  (MaKH)
)
;

-- Table: SanPham
CREATE TABLE SanPham (
    MaSP varchar(10)  NOT NULL,
    TenSP nvarchar(20)  NOT NULL,
    GiaTien varchar(10)  NOT NULL,
    CONSTRAINT SanPham_pk PRIMARY KEY  (MaSP)
)
;
-- foreign keys
-- Reference:  HoaDon_KhachHang (table: HoaDon)

ALTER TABLE HoaDon ADD CONSTRAINT HoaDon_KhachHang 
    FOREIGN KEY (MaKH)
    REFERENCES KhachHang (MaKH)
;

-- Reference:  HoaDon_SanPham (table: HoaDon)

ALTER TABLE HoaDon ADD CONSTRAINT HoaDon_SanPham 
    FOREIGN KEY (MaSP)
    REFERENCES SanPham (MaSP)
;


-- Thêm dữ liệu vào bảng HoaDon
Insert into HoaDon 
Values ('A001','PS00002','2016-1-05',1,'SP02')
Insert into HoaDon 
Values ('A002','PS00003','2016-1-10',2,'SP03')
Insert into HoaDon 
Values ('A003','PS00005','2015-1-12',3,'SP05')
Insert into HoaDon 
Values ('A004','PS00002','2015-1-20',2,'SP01')
Insert into HoaDon 
Values ('A005','PS00004','2015-1-22',1,'SP04')

    
--Thêm dữ liệu vào bảng KhachHang
Insert into KhachHang
Values ('PS00001','Nguyễn Văn A','287 Binh My huyen Cu Chi',01887671210)
Insert into KhachHang
Values ('PS00002','Nguyễn Văn B','300 Nguyen Cong Tru',01886071747)
Insert into KhachHang
Values ('PS00003','Nguyễn Thị C','285 Nam Ki Khoi Nghia',0188994709)
Insert into KhachHang
Values ('PS00004','Nguyễn Thị D','205 Phan Dinh Phung',0188444585)
Insert into KhachHang
Values ('PS00005','Nguyễn Văn E','244 Luy Ban Bich',0188686804)

-- Thêm dữ liệu vào bảng SanPhan
Insert into SanPham
Values ('SP01','Áo thun cổ tròn','200.000vnd')
Insert into SanPham
Values ('SP02','Áo sơ mi','250.000vnd')
Insert into SanPham
Values ('SP03','Quần Jean dài','368.000vnd')
Insert into SanPham
Values ('SP04','Quần Kaki','280.000vnd')
Insert into SanPham
Values ('SP05','Áo khoát','400.000vnd')