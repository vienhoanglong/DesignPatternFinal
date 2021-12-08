CREATE DATABASE QuanLiRapPhim
GO
--
USE QuanLiRapPhim
GO
--
CREATE TABLE NhanVien
(
	MaNV VARCHAR(10) PRIMARY KEY,
	HoTen NVARCHAR(100) NOT NULL,
	NgaySinh DATE NOT NULL,
	DiaChi NVARCHAR(100),
	SDT VARCHAR(100),
	CMND INT NOT NULL UNIQUE
)
GO
--
CREATE TABLE TaiKhoan
(
	UserName NVARCHAR(100) NOT NULL,
	Pass VARCHAR(1000) NOT NULL,
	LoaiTK INT NOT NULL DEFAULT 3, -- 1: BQL 2: NVVe 3: NVQL
	MaNV VARCHAR(10) NOT NULL,

	FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV)
)
GO
--
CREATE TABLE LoaiManHinh
(
	MaMH VARCHAR(10) PRIMARY KEY,
	TenMH NVARCHAR(100) 
)
GO
--
CREATE TABLE PhongChieu
(
	MaPC VARCHAR(10) PRIMARY KEY,
	TenPhong NVARCHAR(100) NOT NULL,
	MaMH VARCHAR(10),
	SoChoNgoi INT NOT NULL,
	TinhTrang INT NOT NULL DEFAULT 1, -- 0:ON || 1:OFF
	SoHangGhe int not null,
	SoGheMotHang int not null,

	FOREIGN KEY (MaMH) REFERENCES dbo.LoaiManHinh(MaMH)
)
GO
--
CREATE TABLE Phim
(
	MaP VARCHAR(10) PRIMARY KEY,
	TenPhim NVARCHAR(100) NOT NULL,
	MoTa NVARCHAR(500) NULL,
	ThoiLuong FLOAT NOT NULL,
	NgayChieu DATE NOT NULL,
	NgayKetThuc DATE NOT NULL,
	SanXuat NVARCHAR(100) NOT NULL,
	DaoDien NVARCHAR(100) NULL,
	NamSX INT NOT NULL,
	HinhAnh IMAGE
)
GO
--
CREATE TABLE DinhDangPhim
(
	MaDD varchar(10) NOT NULL primary key,
	MaP VARCHAR(10) NOT NULL,
	MaMH VARCHAR(10) NOT NULL,

	FOREIGN KEY (MaP) REFERENCES dbo.Phim(MaP),
	FOREIGN KEY (MaMH) REFERENCES dbo.LoaiManHinh(MaMH),
)
GO
--
CREATE TABLE TheLoai
(
	MaTL VARCHAR(10) PRIMARY KEY,
	TenTheLoai NVARCHAR(100) NOT NULL,
	MoTa NVARCHAR(500)
)
GO
--
CREATE TABLE PhanLoaiPhim 
(
	MaP VARCHAR(10) NOT NULL,
	MaTL VARCHAR(10) NOT NULL,

	FOREIGN KEY (MaP) REFERENCES dbo.Phim(MaP),
	FOREIGN KEY (MaTL) REFERENCES dbo.TheLoai(MaTL),

	CONSTRAINT PK_PhanLoaiPhim PRIMARY KEY(MaP,MaTL)
)
GO
--
CREATE TABLE LichChieu
(
	MaLC VARCHAR(10) PRIMARY KEY,
	ThoiGianChieu DATETIME NOT NULL,
	MaPC VARCHAR(10) NOT NULL,
	MaDD VARCHAR(10) NOT NULL,
	GiaVe Money NOT NULL,
	TrangThai INT NOT NULL DEFAULT '0', 
	FOREIGN KEY (MaPC) REFERENCES dbo.PhongChieu(MaPC),
	FOREIGN KEY (MaDD) REFERENCES dbo.DinhDangPhim(MaDD),
)
GO
--
CREATE TABLE KhachHang
(
	MaKH VARCHAR(10) PRIMARY KEY,
	HoTen NVARCHAR(100) NOT NULL,
	NgaySinh DATE NOT NULL,
	DiaChi NVARCHAR(100),
	SDT VARCHAR(100),
	CMND INT NOT NULL UNIQUE,
	DiemThuong INT
)
GO
--
CREATE TABLE Ve
(
	MaVe INT IDENTITY(1,1) PRIMARY KEY,
	LoaiVe INT  DEFAULT '0', 
	MaLC VARCHAR(10),
	MaGhe VARCHAR(10),
	MaKH VARCHAR(10),
	TrangThai INT NOT NULL DEFAULT '0', 
	TienBanVe MONEY DEFAULT '0'

	FOREIGN KEY (MaLC) REFERENCES dbo.LichChieu(MaLC),
	FOREIGN KEY (MaKH) REFERENCES dbo.KhachHang(MaKH)
)
GO
CREATE TABLE ThucPham(
	MaTP VARCHAR(10) PRIMARY KEY,
	LoaiTP NVARCHAR(100) NOT NULL,
	TenTP NVARCHAR(100) NOT NULL,
	GiaTP INT,
)
CREATE TABLE SKQuangCao(
	MaSK VARCHAR(10) PRIMARY KEY,
	TenSK NVARCHAR(100) NOT NULL,
	Uudai NVARCHAR(100),
	ChuDe NVARCHAR(100),
	ThoiGianApDung DATE,
	ThoiGianKetThuc DATE
)
--TRIGGER
CREATE TRIGGER KT_Ngay_Chieu
ON dbo.LichChieu
FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @MaDD VARCHAR(50), @ThoiGianChieu DATE, @NgayChieu DATE, @NgayKetThuc DATE

	SELECT @MaDD = MaDD, @ThoiGianChieu = CONVERT(DATE, ThoiGianChieu) from INSERTED

	SELECT @NgayChieu = P.NgayChieu, @NgayKetThuc = P.NgayKetThuc
	FROM dbo.Phim P, dbo.DinhDangPhim DD
	WHERE @MaDD = DD.MaDD AND DD.MaP = P.MaP

	IF ( @ThoiGianChieu > @NgayKetThuc or @ThoiGianChieu < @NgayChieu)
	BEGIN
		ROLLBACK TRAN
		Raiserror('Lịch Chiếu lớn hơn hoặc bằng Ngày Khởi Chiếu và nhỏ hơn hoặc bằng Ngày Kết Thúc',16,1)
		Return
    END
END
GO
--
--CREATE TRIGGER KT_TG_Chieu
--ON dbo.LichChieu
--FOR INSERT, UPDATE
--AS
--BEGIN
--	DECLARE @count INT = 0, @count2 INT = 0, @ThoiGianChieu DATETIME, @MaP VARCHAR(10), @MaDD VARCHAR(10)

--	SELECT @MaPC = MaPC, @ThoiGianChieu = ThoiGianChieu, @MaDD = Inserted.MaDD from INSERTED

--	SELECT @count = COUNT(*)
--	FROM dbo.LichChieu LC, dbo.DinhDangPhim DD, dbo.Phim P
--	WHERE LC.MaPC = @MaPC AND LC.MaDD = DD.MaDD AND DD.MaP = P.MaP AND (@ThoiGianChieu >= LC.ThoiGianChieu AND @ThoiGianChieu <= DATEADD(MINUTE, P.ThoiLuong, LC.ThoiGianChieu))

--	SELECT @count2 = COUNT(*)
--	FROM dbo.LichChieu LC, dbo.DinhDangPhim DD, dbo.Phim P
--	WHERE @MaPC = LC.MaPC AND @MaDD = DD.MaDD AND DD.MaP = P.MaP AND (LC.ThoiGianChieu >= @ThoiGianChieu AND LC.ThoiGianChieu <= DATEADD(MINUTE, P.ThoiLuong, @ThoiGianChieu))

--	IF (@count > 1 OR @count2 > 1)
--	BEGIN
--		ROLLBACK TRAN
--		Raiserror('Thời Gian Chiếu đã trùng với một lịch chiếu khác cùng Phòng Chiếu',16,1)
--		Return
--	END
--END
--GO
--
CREATE PROC CapNhatMatKhau
@username NVARCHAR(100), @pass VARCHAR(1000), @newPass VARCHAR(1000)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	SELECT @isRightPass = COUNT(*) FROM dbo.TaiKhoan WHERE UserName = @username AND Pass = @pass

	IF (@isRightPass = 1)
	BEGIN
		UPDATE dbo.TaiKhoan SET Pass = @newPass WHERE UserName = @username
    END
END
GO
--
CREATE PROC DangNhap
@userName NVARCHAR(100), @pass VARCHAR(1000)
AS
BEGIN
	SELECT * FROM dbo.TaiKhoan WHERE UserName = @userName AND Pass = @pass
END
GO
--
CREATE PROC DanhSachTaiKhoan
AS
BEGIN
	SELECT TK.UserName AS [Username], TK.LoaiTK AS [Loại tài khoản], NV.MaNV AS [Mã nhân viên], NV.HoTen AS [Tên nhân viên]
	FROM dbo.TaiKhoan TK, dbo.NhanVien NV
	WHERE NV.MaNV = TK.MaNV
END
GO
--
CREATE PROC ThemTaiKhoan
@username NVARCHAR(100), @loaiTK INT, @MaNV VARCHAR(10)
AS
BEGIN
	INSERT dbo.TaiKhoan ( UserName, Pass, LoaiTK, MaNV )
	VALUES ( @username, '5512317111114510840231031535810616566202691', @loaiTK, @MaNV )
END
GO
--
CREATE PROC CapNhatTaiKhoan
@username NVARCHAR(100), @loaiTK INT
AS
BEGIN
	UPDATE dbo.TaiKhoan 
	SET LoaiTK = @loaiTK
	WHERE UserName = @username
END
GO
--
CREATE PROC KhoiPhucTaiKhoan
@username NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.TaiKhoan 
	SET Pass = '5512317111114510840231031535810616566202691' 
	WHERE UserName = @username
END
GO
--
CREATE PROC TiemKiemTaiKhoan
@hoTen NVARCHAR(100)
AS
BEGIN
	SELECT TK.UserName AS [Username], TK.LoaiTK AS [Loại tài khoản], NV.MaNV AS [Mã nhân viên], NV.HoTen AS [Tên nhân viên]
	FROM dbo.TaiKhoan TK, dbo.NhanVien NV
	WHERE NV.MaNV = TK.MaNV AND dbo.fuConvertToUnsign1(NV.HoTen) LIKE N'%' + dbo.fuConvertToUnsign1(@hoTen) + N'%'
END
GO
--#
CREATE PROC DanhsachKhachHang
AS
BEGIN
	SELECT MaKH AS [Mã khách hàng], HoTen AS [Họ tên], NgaySinh AS [Ngày sinh], DiaChi AS [Địa chỉ], SDT AS [SĐT], CMND AS [CMND], DiemThuong AS [Điểm thưởng]
	FROM dbo.KhachHang
END
GO
--
CREATE PROC ThemKhachHang
@MaKH VARCHAR(10), @hoTen NVARCHAR(100), @ngaySinh date, @diaChi NVARCHAR(100), @sdt VARCHAR(100), @cmnd INT
AS
BEGIN
	INSERT dbo.KhachHang (MaKH, HoTen, NgaySinh, DiaChi, SDT, CMND, DiemThuong)
	VALUES (@MaKH, @hoTen, @ngaySinh, @diaChi, @sdt, @cmnd, 0)
END
GO
--
CREATE PROC TimKiemKhachHang
@hoTen NVARCHAR(100)
AS
BEGIN
	SELECT MaKH AS [Mã khách hàng], HoTen AS [Họ tên], NgaySinh AS [Ngày sinh], DiaChi AS [Địa chỉ], SDT AS [SĐT], CMND AS [CMND], DiemTichLuy AS [Điểm tích lũy]
	FROM dbo.KhachHang
	WHERE dbo.fuConvertToUnsign1(HoTen) LIKE N'%' + dbo.fuConvertToUnsign1(@hoTen) + N'%'
END
GO
--
CREATE PROC ThemTheLoai
@MaTL VARCHAR(10), @ten NVARCHAR(100), @moTa NVARCHAR(500)
AS
BEGIN
	INSERT dbo.TheLoai (MaTL, TenTheLoai, MoTa)
	VALUES  (@MaTL, @ten, @moTa)
END
GO
--
CREATE PROC DachSachPhim
AS
BEGIN
	SELECT MaP AS [Mã phim], TenPhim AS [Tên phim], MoTa AS [Mô tả], ThoiLuong AS [Thời lượng], NgayChieu AS [Ngày chiếu], NgayKetThuc AS [Ngày kết thúc], SanXuat AS [Sản xuất], DaoDien AS [Đạo diễn], NamSX AS [Năm SX], HinhAnh AS [Hình Ảnh]
	FROM dbo.Phim
END
GO
--
CREATE PROC DanhSachTheLoaiPhim
@MaP VARCHAR(10)
AS
BEGIN
	SELECT TL.MaTL, TenTheLoai, TL.MoTa
	FROM dbo.PhanLoaiPhim PL, dbo.TheLoai TL
	WHERE MaP = @MaP AND PL.MaTL = TL.MaTL
END
GO
--
CREATE PROC ThemPhim
@MaP VARCHAR(10), @tenPhim NVARCHAR(100), @moTa NVARCHAR(500), @thoiLuong FLOAT, @ngayChieu DATE, @ngayKetThuc DATE, @sanXuat NVARCHAR(50), @daoDien NVARCHAR(100), @namSX INT, @hinhAnh IMAGE
AS
BEGIN
	INSERT dbo.Phim (MaP , TenPhim , MoTa , ThoiLuong , NgayChieu , NgayKetThuc , SanXuat , DaoDien , NamSX, HinhAnh)
	VALUES (@MaP , @tenPhim , @moTa , @thoiLuong , @ngayChieu , @ngayKetThuc , @sanXuat , @daoDien , @namSX, @hinhAnh)
END
GO
--
CREATE PROC CapNhatPhim
@MaP VARCHAR(10), @tenPhim NVARCHAR(100), @moTa NVARCHAR(500), @thoiLuong FLOAT, @ngayChieu DATE, @ngayKetThuc DATE, @sanXuat NVARCHAR(50), @daoDien NVARCHAR(100), @namSX INT , @hinhAnh IMAGE
AS
BEGIN
	UPDATE dbo.Phim SET TenPhim = @tenPhim, MoTa = @moTa, ThoiLuong = @thoiLuong, NgayChieu = @ngayChieu, NgayKetThuc = @ngayKetThuc, SanXuat = @sanXuat, DaoDien = @daoDien, NamSX = @namSX, HinhAnh = @hinhAnh WHERE MaP = @MaP
END
GO
--
CREATE PROC DanhSachDinhDang
AS
BEGIN
	SELECT DD.MaDD AS [Mã định dạng], P.MaP AS [Mã phim], P.TenPhim AS [Tên phim], MH.MaMH AS [Mã MH], MH.TenMH AS [Tên MH]
	FROM dbo.DinhDangPhim DD, Phim P, dbo.LoaiManHinh MH
	WHERE DD.MaP = P.MaP AND DD.MaMH = MH.MaMH
END
GO
--
CREATE PROC ThemDinhDang
@MaDD VARCHAR(10), @MaP VARCHAR(50), @MaMH VARCHAR(50)
AS
BEGIN
	INSERT dbo.DinhDangPhim ( MaDD, MaP, MaMH )
	VALUES  ( @MaDD, @MaP, @MaMH )
END
GO
--#
CREATE PROC DanhSachLichChieu
@MaLC varchar(10), @Date Datetime
AS
BEGIN
	select l.MaLC, pc.TenPhong, p.TenPhim, l.ThoiGianChieu, d.MaDD as MaDD, l.GiaVe, l.TrangThai
	from Phim p ,DinhDangPhim d, LichChieu l, PhongChieu pc
	where p.MaP = d.MaP and d.MaDD = l.MaDD and l.MaPC = pc.MaPC
	and d.MaDD = @MaLC and CONVERT(DATE, @Date) = CONVERT(DATE, l.ThoiGianChieu)
	order by l.ThoiGianChieu
END
GO
--
CREATE PROC ThoiGianChieu
AS
BEGIN
	SELECT LC.MaLC AS [Mã lịch chiếu], LC.MaPC AS [Mã phòng], P.TenPhim AS [Tên phim], MH.TenMH AS [Màn hình], LC.ThoiGianChieu AS [Thời gian chiếu], LC.GiaVe AS [Giá vé]
	FROM dbo.LichChieu AS LC, dbo.DinhDangPhim AS DD, Phim AS P, dbo.LoaiManHinh AS MH
	WHERE LC.MaDD = DD.MaDD AND DD.MaP = P.MaP AND DD.MaMH = MH.MaMH
END
GO
--
CREATE PROC ThemThoiGianChieu
@MaLC VARCHAR(10), @MaPC VARCHAR(10), @MaDD VARCHAR(10), @thoiGianChieu DATETIME, @giaVe FLOAT
AS
BEGIN
	INSERT dbo.LichChieu ( MaLC , MaPC , MaDD, ThoiGianChieu  , GiaVe , TrangThai )
	VALUES  ( @MaLC , @MaPC , @MaDD, @thoiGianChieu  , @giaVe , 0 )
END
GO
--
CREATE PROC CapNhatLichChieu
@MaLC VARCHAR(10), @MaPC VARCHAR(10), @MaDD VARCHAR(10), @thoiGianChieu DATETIME, @giaVe FLOAT
AS
BEGIN
	UPDATE dbo.LichChieu 
	SET MaPC = @MaPC, MaDD = @MaDD, ThoiGianChieu = @thoiGianChieu , GiaVe = @giaVe
	WHERE MaLC = @MaLC
END
GO
--
CREATE PROC  TimKiemLichChieu
@tenPhim NVARCHAR(100)
AS
BEGIN
	SELECT LC.MaLC AS [Mã lịch chiếu], LC.MaPC AS [Mã phòng], P.TenPhim AS [Tên phim], MH.TenMH AS [Màn hình], LC.ThoiGianChieu AS [Thời gian chiếu], LC.GiaVe AS [Giá vé]
	FROM dbo.LichChieu AS LC, dbo.DinhDangPhim AS DD, Phim AS P, dbo.LoaiManHinh AS MH
	WHERE LC.MaDD = DD.MaDD AND DD.MaP = P.MaP AND DD.MaMH = MH.MaMH AND dbo.fuConvertToUnsign1(P.TenPhim) LIKE N'%' + dbo.fuConvertToUnsign1(@tenPhim) + N'%'
END
GO
--
CREATE PROC TatCaDanhSachLichChieu
AS
BEGIN
	select l.MaLC, pc.TenPhong, p.TenPhim, l.ThoiGianChieu, d.MaDD as MaDD, l.GiaVe, l.TrangThai
	from Phim p ,DinhDangPhim d, LichChieu l, PhongChieu pc
	where p.MaP = d.MaP and d.MaDD = l.MaDD and l.MaPC = pc.MaPC
	order by l.ThoiGianChieu
END
GO
--
CREATE PROC  DanhSachLichChieuChuaCoVe
AS
BEGIN
	select l.MaLC, pc.TenPhong, p.TenPhim, l.ThoiGianChieu, d.MaDD as MaDD, l.GiaVe, l.TrangThai
	from Phim p ,DinhDangPhim d, LichChieu l, PhongChieu pc
	where p.MaP = d.MaP and d.MaDD = l.MaDD and l.MaPC = pc.MaPC and l.TrangThai = 0
	order by l.ThoiGianChieu
END
GO
--
CREATE PROC CapNhatTrangThaiLichChieu
@MaLC NVARCHAR(50), @status int
AS
BEGIN
	UPDATE dbo.LichChieu
	SET TrangThai = @status
	WHERE MaLC = @MaLC
END
GO
--
CREATE PROC DanhSachNhanVien
AS
BEGIN
	SELECT MaNV AS [Mã nhân viên], HoTen AS [Họ tên], NgaySinh AS [Ngày sinh], DiaChi AS [Địa chỉ], SDT AS [SĐT], CMND AS [CMND]
	FROM dbo.NhanVien
END
GO
--
CREATE PROC ThemNhanVien
@MaNV VARCHAR(10), @hoTen NVARCHAR(100), @ngaySinh date, @diaChi NVARCHAR(100), @sdt VARCHAR(100), @cmnd INT
AS
BEGIN
	INSERT dbo.NhanVien (MaNV, HoTen, NgaySinh, DiaChi, SDT, CMND)
	VALUES (@MaNV, @hoTen, @ngaySinh, @diaChi, @sdt, @cmnd)
END
GO
--
CREATE PROC TimKiemNhanVien
@hoTen NVARCHAR(100)
AS
BEGIN
	SELECT MaNV AS [Mã nhân viên], HoTen AS [Họ tên], NgaySinh AS [Ngày sinh], DiaChi AS [Địa chỉ], SDT AS [SĐT], CMND AS [CMND]
	FROM dbo.NhanVien
	WHERE dbo.fuConvertToUnsign1(HoTen) LIKE N'%' + dbo.fuConvertToUnsign1(@hoTen) + N'%'
END
GO
--
CREATE PROC DanhSachPhongChieu
AS
BEGIN
	SELECT PC.MaPC AS [Mã phòng], TenPhong AS [Tên phòng], TenMH AS [Tên màn hình], PC.SoChoNgoi AS [Số chỗ ngồi], PC.TinhTrang AS [Tình trạng], PC.SoHangGhe AS [Số hàng ghế], PC.SoGheMotHang AS [Ghế mỗi hàng]
	FROM dbo.PhongChieu AS PC, dbo.LoaiManHinh AS MH
	WHERE PC.MaMH = MH.MaMH
END
GO
--
CREATE PROC ThemPhongChieu
@MaPC VARCHAR(10), @tenPhong NVARCHAR(100), @MaMH VARCHAR(10), @soChoNgoi INT, @tinhTrang INT, @soHangGhe INT, @soGheMotHang INT
AS
BEGIN
	INSERT dbo.PhongChieu ( MaPC , TenPhong , MaMH , SoChoNgoi , TinhTrang , SoHangGhe , SoGheMotHang)
	VALUES (@MaPC , @tenPhong , @MaMH , @soChoNgoi , @tinhTrang , @soHangGhe , @soGheMotHang)
END
GO
--
CREATE PROC ThemVe
@MaLC VARCHAR(10), @MaGhe VARCHAR(10)
AS
BEGIN
	INSERT INTO dbo.Ve
	(
		MaLC,
		MaGhe,
		MaKH
	)
	VALUES
	(
		@MaLC,
		@MaGhe,
		NULL
	)
END
GO
--
CREATE PROC XoaVe
@MaLC VARCHAR(50)
AS
BEGIN
	DELETE FROM dbo.Ve
	WHERE MaLC = @MaLC
END
GO
--
INSERT INTO TheLoai(MaTL,TenTheLoai,MoTa) VALUES (N'TL01',N'Hành Động', NULL);
INSERT INTO TheLoai(MaTL,TenTheLoai,MoTa) VALUES (N'TL02',N'Viễn Tưởng', NULL);
INSERT INTO TheLoai(MaTL,TenTheLoai,MoTa) VALUES (N'TL03',N'Tâm Lí', NULL);
INSERT INTO TheLoai(MaTL,TenTheLoai,MoTa) VALUES (N'TL04',N'Tình Cảm', NULL);
INSERT INTO TheLoai(MaTL,TenTheLoai,MoTa) VALUES (N'TL05',N'Kinh Dị', NULL);

INSERT INTO NhanVien(MaNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV00',N'admin', '2020-11-11', N'admin',NULL,123456789 );
INSERT INTO NhanVien(MaNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV01',N'Bán vé','2020-11-11', NULL,NULL,023456789 );

INSERT INTO TaiKhoan(UserName, Pass, LoaiTK, MaNV) VALUES (N'admin', N'59113821474147731767615617822114745333', 1, N'NV00');-- mk hiện thị là admin
INSERT INTO TaiKhoan(UserName, Pass, LoaiTK, MaNV) VALUES (N'NV01', N'59113821474147731767615617822114745333', 2, N'NV01');
--INSERT INTO TaiKhoan(UserName, Pass, LoaiTK, MaNV) VALUES (N'NV02', N'59113821474147731767615617822114745333', 3, N'NV02');

INSERT INTO KhachHang(MaKH, HoTen, NgaySinh, DiaChi, SDT, CMND, DiemThuong) VALUES (N'KH01',N'Viên Hoàng Long','2020-11-02',N'Quận 7',N'0398719657',316732368,999);
INSERT INTO KhachHang(MaKH, HoTen, NgaySinh, DiaChi, SDT, CMND, DiemThuong) VALUES (N'KH02',N'Trần Thị Kim Tuyến','2020-11-11',N'Quận 7',N'038171317',31611368,999);
INSERT INTO KhachHang(MaKH, HoTen, NgaySinh, DiaChi, SDT, CMND, DiemThuong) VALUES (N'KH03',N'Trần Hoàng A','2020-04-11',N'Quận 8',N'038171317',33123368,0);

INSERT INTO LoaiManHinh(MaMH, TenMH) VALUES (N'MH01', N'2D');
INSERT INTO LoaiManHinh(MaMH, TenMH) VALUES (N'MH02', N'3D');
INSERT INTO LoaiManHinh(MaMH, TenMH) VALUES (N'MH03', N'4D');

INSERT INTO PhongChieu(MaPC, TenPhong, MaMH, SoChoNgoi, TinhTrang, SoHangGhe, SoGheMotHang) VALUES(N'PC01',N'CINEMA 01',N'MH02',100,1,10,14);
INSERT INTO PhongChieu(MaPC, TenPhong, MaMH, SoChoNgoi, TinhTrang, SoHangGhe, SoGheMotHang) VALUES(N'PC02',N'CINEMA 02',N'MH03',100,1,10,14);
INSERT INTO PhongChieu(MaPC, TenPhong, MaMH, SoChoNgoi, TinhTrang, SoHangGhe, SoGheMotHang) VALUES(N'PC03',N'CINEMA 03',N'MH01',100,1,10,14);


INSERT INTO Phim(MaP, TenPhim, MoTa, ThoiLuong, NgayChieu, NgayKetThuc, SanXuat, DaoDien, NamSX) VALUES(N'P01',N'Cô Ba Sài Gòn',N'Cô Ba Sài Gòn',100,'2020-10-11','2020-10-20',N'VAA', N'Kay Nguyễn', 2020);
INSERT INTO Phim(MaP, TenPhim, MoTa, ThoiLuong, NgayChieu, NgayKetThuc, SanXuat, DaoDien, NamSX) VALUES(N'P02',N'Mắt Biếc',N'Tác phẩm chuyển thể từ truyện ngắn nổi tiếng',117,'2020-9-12','2020-10-12',N'Galaxy M&E', N'Virctor Vũ', 2020);
INSERT INTO Phim(MaP, TenPhim, MoTa, ThoiLuong, NgayChieu, NgayKetThuc, SanXuat, DaoDien, NamSX) VALUES(N'P03',N'Tiệc Trăng Máu',N'Tác phẩm chuyển thể từ kịch bản nước ngoài',118,'2020-10-11','2020-12-12',N'Lotter Entertaiment', N'Nguyễn Quang Dũng', 2020);
INSERT INTO Phim(MaP, TenPhim, MoTa, ThoiLuong, NgayChieu, NgayKetThuc, SanXuat, DaoDien, NamSX) VALUES(N'P04',N'Chị Chị em em',N'Nội dung về hai người phụ nữ xinh đẹp',104,'2020-11-06','2020-12-06',N'Muse Film', N'Kathy Uyên', 2020);
INSERT INTO Phim(MaP, TenPhim, MoTa, ThoiLuong, NgayChieu, NgayKetThuc, SanXuat, DaoDien, NamSX) VALUES(N'P05',N'Happy Death Day 2',N'Bộ phim kinh dị của Mỹ',129,'2020-10-11','2020-12-20',N'Mỹ', N'Christopher Landon', 2020);

INSERT INTO PhanLoaiPhim(MaP, MaTL) VALUES(N'P01', N'TL01');
INSERT INTO PhanLoaiPhim(MaP, MaTL) VALUES(N'P02', N'TL04');
INSERT INTO PhanLoaiPhim(MaP, MaTL) VALUES(N'P03', N'TL03');
INSERT INTO PhanLoaiPhim(MaP, MaTL) VALUES(N'P04', N'TL02');
INSERT INTO PhanLoaiPhim(MaP, MaTL) VALUES(N'P05', N'TL05');


INSERT INTO DinhDangPhim(MaDD, MaP, MaMH) VALUES (N'DD01', N'P01', N'MH01');
INSERT INTO DinhDangPhim(MaDD, MaP, MaMH) VALUES (N'DD02', N'P01', N'MH03');
INSERT INTO DinhDangPhim(MaDD, MaP, MaMH) VALUES (N'DD03', N'P02', N'MH01');
INSERT INTO DinhDangPhim(MaDD, MaP, MaMH) VALUES (N'DD04', N'P03', N'MH02');

INSERT INTO LichChieu(MaLC, ThoiGianChieu, MaPC, MaDD, GiaVe, TrangThai) VALUES (N'LC01','2020-10-11',N'PC01', N'DD01', 85000.0000, 1);
INSERT INTO LichChieu(MaLC, ThoiGianChieu, MaPC, MaDD, GiaVe, TrangThai) VALUES (N'LC02','2020-10-11',N'PC03', N'DD02', 85000.0000, 0);
INSERT INTO LichChieu(MaLC, ThoiGianChieu, MaPC, MaDD, GiaVe, TrangThai) VALUES (N'LC03','2020-10-11',N'PC02', N'DD03', 85000.0000, 0);

SET IDENTITY_INSERT [dbo].[Ve] ON
GO
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) 
VALUES(1, 0,N'LC01',N'A1',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (2,0,N'LC01',N'A2',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (3,0,N'LC01',N'A3',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (4,0,N'LC01',N'A4',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (5,0,N'LC01',N'A5',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (6,0,N'LC01',N'A6',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (7,0,N'LC01',N'A7',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (8,0,N'LC01',N'A8',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (9,0,N'LC01',N'A9',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (10,0,N'LC01',N'A10',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (11,0,N'LC01',N'B1',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (12,0,N'LC01',N'B2',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (13,0,N'LC01',N'B3',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (14,0,N'LC01',N'B4',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (15,0,N'LC01',N'B5',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (16,0,N'LC01',N'B6',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (17,0,N'LC01',N'B7',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (18,0,N'LC01',N'B8',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (19,0,N'LC01',N'B9',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (20,0,N'LC01',N'B10',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (21,0,N'LC01',N'C1',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (22,0,N'LC01',N'C2',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (23,0,N'LC01',N'C3',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (24,0,N'LC01',N'C4',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (25,0,N'LC01',N'C5',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (26,0,N'LC01',N'C6',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (27,0,N'LC01',N'C7',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (28,0,N'LC01',N'C8',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (29,0,N'LC01',N'C9',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (30,0,N'LC01',N'C10',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (31,0,N'LC01',N'D1',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (32,0,N'LC01',N'D2',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (33,0,N'LC01',N'D3',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (34,0,N'LC01',N'D4',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (35,0,N'LC01',N'D5',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (36,0,N'LC01',N'D6',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (37,3,N'LC01',N'D7',NULL,1,59500.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (38,0,N'LC01',N'D8',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (39,0,N'LC01',N'D9',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (40,0,N'LC01',N'D10',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (41,1,N'LC01',N'E1',NULL,1,85000.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (42,1,N'LC01',N'E2',NULL,1,85000.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (43,2,N'LC01',N'E3',NULL,1,68000.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (44,2,N'LC01',N'E4',NULL,1,68000.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (45,0,N'LC01',N'E5',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (46,0,N'LC01',N'E6',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (47,3,N'LC01',N'E7',NULL,1,59500.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (48,0,N'LC01',N'E8',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (49,0,N'LC01',N'E9',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (50,0,N'LC01',N'E10',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (51,0,N'LC01',N'F1',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (52,0,N'LC01',N'F2',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (53,0,N'LC01',N'F3',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (54,0,N'LC01',N'F4',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (55,0,N'LC01',N'F5',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (56,0,N'LC01',N'F6',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (57,0,N'LC01',N'F7',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (58,0,N'LC01',N'F8',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (59,0,N'LC01',N'F9',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (60,0,N'LC01',N'F10',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (61,0,N'LC01',N'G1',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (61,0,N'LC01',N'G2',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (63,0,N'LC01',N'G3',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (64,0,N'LC01',N'G4',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (65,0,N'LC01',N'G5',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (66,0,N'LC01',N'G7',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (67,0,N'LC01',N'G7',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (68,0,N'LC01',N'G8',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (69,0,N'LC01',N'G9',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (70,0,N'LC01',N'G10',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (71,0,N'LC01',N'H1',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (72,0,N'LC01',N'H2',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (73,0,N'LC01',N'H3',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (74,0,N'LC01',N'H4',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (75,0,N'LC01',N'H5',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (76,0,N'LC01',N'H6',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (77,0,N'LC01',N'H7',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (78,0,N'LC01',N'H8',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (79,0,N'LC01',N'H9',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (80,0,N'LC01',N'H10',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (81,0,N'LC01',N'I1',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (82,0,N'LC01',N'I2',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (83,0,N'LC01',N'I3',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (84,0,N'LC01',N'I4',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (85,0,N'LC01',N'I5',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (86,0,N'LC01',N'I6',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (87,0,N'LC01',N'I7',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (88,0,N'LC01',N'I8',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (89,0,N'LC01',N'I9',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (90,0,N'LC01',N'I10',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (91,0,N'LC01',N'J1',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (92,0,N'LC01',N'J2',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (93,0,N'LC01',N'J3',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (94,0,N'LC01',N'J4',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (95,0,N'LC01',N'J5',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (96,0,N'LC01',N'J6',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (97,0,N'LC01',N'J7',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (98,0,N'LC01',N'J8',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (99,0,N'LC01',N'J9',NULL,0,0.0000);
INSERT INTO Ve(MaVe, LoaiVe, MaLC, MaGhe, MaKH, TrangThai, TienBanVe) VALUES (100,0,N'LC01',N'J10',NULL,0,0.0000);
GO

INSERT INTO ThucPham(MaTP, TenTP, LoaiTP, GiaTP) VALUES (N'TP01',N'Bắp',N'Đồ Ăn',25000);

INSERT INTO SKQuangCao(MaSK, TenSK, Uudai, ChuDe, ThoiGianApDung, ThoiGianKetThuc) VALUES(N'SK01',N'Tích điểm',N'Miễn phí vé',N'Noel','2020-10-11','2021-01-01');