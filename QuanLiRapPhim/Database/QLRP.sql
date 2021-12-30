﻿CREATE DATABASE QLRP
GO
USE QLRP
GO

CREATE TABLE NhanVien
(
	id VARCHAR(50) PRIMARY KEY,
	HoTen NVARCHAR(100) NOT NULL,
	NgaySinh DATE NOT NULL,
	DiaChi NVARCHAR(100),
	SDT VARCHAR(100),
	CMND INT NOT NULL Unique
)
GO

CREATE TABLE TaiKhoan
(
	UserName NVARCHAR(100) NOT NULL,
	Pass VARCHAR(1000) NOT NULL,
	LoaiTK INT NOT NULL DEFAULT 2, -- 1:admin || 2:staff
	idNV VARCHAR(50) NOT NULL,

	FOREIGN KEY (idNV) REFERENCES dbo.NhanVien(ID)
)
GO

CREATE TABLE LoaiManHinh
(
	id VARCHAR(50) PRIMARY KEY,
	TenMH NVARCHAR(100) --2D || 3D || IMax
)
GO

CREATE TABLE PhongChieu
(
	id VARCHAR(50) PRIMARY KEY,
	TenPhong NVARCHAR(100) NOT NULL,
	idManHinh VARCHAR(50),
	SoChoNgoi INT NOT NULL,
	TinhTrang INT NOT NULL DEFAULT 1, -- 0:không hoạt động || 1:đang hoạt động
	SoHangGhe int not null,
	SoGheMotHang int not null,

	FOREIGN KEY (idManHinh) REFERENCES dbo.LoaiManHinh(id)
)
GO

CREATE TABLE Phim
(
	id varchar(50) PRIMARY KEY,
	TenPhim nvarchar(100) NOT NULL,
	MoTa nvarchar(1000) NULL,
	ThoiLuong float NOT NULL,
	NgayKhoiChieu date NOT NULL,
	NgayKetThuc date NOT NULL,
	SanXuat nvarchar(50) NOT NULL,
	DaoDien nvarchar(100) NULL,
	NamSX int NOT NULL,
	ApPhich image
)
GO

CREATE TABLE DinhDangPhim --Phim có hỗ trợ màn hình 3D hay IMax không?
(
	id varchar(50) NOT NULL primary key,
	idPhim VARCHAR(50) NOT NULL,
	idLoaiManHinh VARCHAR(50) NOT NULL,

	FOREIGN KEY (idPhim) REFERENCES dbo.Phim(id),
	FOREIGN KEY (idLoaiManHinh) REFERENCES dbo.LoaiManHinh,
)
GO

CREATE TABLE TheLoai
(
	id VARCHAR(50) PRIMARY KEY,
	TenTheLoai NVARCHAR(100) NOT NULL,
	MoTa NVARCHAR(100)
)
GO

CREATE TABLE PhanLoaiPhim --Quan hệ giữa Phim và LoaiPhim là quan hệ n-n
(
	idPhim VARCHAR(50) NOT NULL,
	idTheLoai VARCHAR(50) NOT NULL,

	FOREIGN KEY (idPhim) REFERENCES dbo.Phim(id),
	FOREIGN KEY (idTheLoai) REFERENCES dbo.TheLoai(id),

	CONSTRAINT PK_PhanLoaiPhim PRIMARY KEY(idPhim,idTheLoai)
)
GO

CREATE TABLE LichChieu
(
	id VARCHAR(50) PRIMARY KEY,
	ThoiGianChieu DATETIME NOT NULL,
	idPhong VARCHAR(50) NOT NULL,
	idDinhDang VARCHAR(50) NOT NULL,
	GiaVe Money NOT NULL,
	TrangThai INT NOT NULL DEFAULT '0', --0: Chưa tạo vé cho lịch chiếu || 1: Đã tạo vé

	FOREIGN KEY (idPhong) REFERENCES dbo.PhongChieu(id),
	FOREIGN KEY (idDinhDang) REFERENCES dbo.DinhDangPhim(id),

	--CONSTRAINT PK_LichChieu PRIMARY KEY(ngayChieu,gioChieu,idPhong) --Vì cùng 1 thời điểm có thể có nhiều phòng cùng hoạt động nên khóa chính phải là cả 3 cái
)
GO

CREATE TABLE KhachHang
(
	id VARCHAR(50) PRIMARY KEY,
	HoTen NVARCHAR(100) NOT NULL,
	NgaySinh DATE NOT NULL,
	DiaChi NVARCHAR(100),
	SDT VARCHAR(100),
	CMND INT NOT NULL Unique,
	DiemTichLuy int
)
GO


CREATE TABLE Ve
(
	id int identity(1,1) PRIMARY KEY,
	LoaiVe INT  DEFAULT '0', --0: Vé người lớn || 1: Vé học sinh - sinh viên || 2: vé trẻ em
	idLichChieu VARCHAR(50),
	MaGheNgoi VARCHAR(50),
	idKhachHang VARCHAR(50),
	TrangThai INT NOT NULL DEFAULT '0', --0: 'Chưa Bán' || 1: 'Đã Bán'
	TienBanVe MONEY DEFAULT '0'

	FOREIGN KEY (idLichChieu) REFERENCES dbo.LichChieu(id),
	FOREIGN KEY (idKhachHang) REFERENCES dbo.KhachHang(id)
)
GO
CREATE TABLE ThucPham(
	MaTP VARCHAR(10) PRIMARY KEY,
	LoaiTP NVARCHAR(100) NOT NULL,
	TenTP NVARCHAR(100) NOT NULL,
	GiaTP INT,
)
GO
CREATE TABLE SKQuangCao(
	MaSK VARCHAR(10) PRIMARY KEY,
	TenSK NVARCHAR(100) NOT NULL,
	Uudai NVARCHAR(100),
	ChuDe NVARCHAR(100),
	ThoiGianApDung DATE,
	ThoiGianKetThuc DATE
)
GO
--Trigger
CREATE TRIGGER UTG_INSERT_CheckDateLichChieu
ON dbo.LichChieu
FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idDinhDang VARCHAR(50), @ThoiGianChieu DATE, @NgayKhoiChieu DATE, @NgayKetThuc DATE

	SELECT @idDinhDang = idDinhDang, @ThoiGianChieu = CONVERT(DATE, ThoiGianChieu) from INSERTED

	SELECT @NgayKhoiChieu = P.NgayKhoiChieu, @NgayKetThuc = P.NgayKetThuc
	FROM dbo.Phim P, dbo.DinhDangPhim DD
	WHERE @idDinhDang = DD.id AND DD.idPhim = P.id

	IF ( @ThoiGianChieu > @NgayKetThuc or @ThoiGianChieu < @NgayKhoiChieu)
	BEGIN
		ROLLBACK TRAN
		Raiserror('Lịch Chiếu lớn hơn hoặc bằng Ngày Khởi Chiếu và nhỏ hơn hoặc bằng Ngày Kết Thúc',16,1)
		Return
    END
END
GO

CREATE TRIGGER UTG_CheckTimeLichChieu
ON dbo.LichChieu
FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @count INT = 0, @count2 INT = 0, @ThoiGianChieu DATETIME, @idPhong VARCHAR(50), @idDinhDang VARCHAR(50)

	SELECT @idPhong = idPhong, @ThoiGianChieu = ThoiGianChieu, @idDinhDang = Inserted.idDinhDang from INSERTED

	SELECT @count = COUNT(*)
	FROM dbo.LichChieu LC, dbo.DinhDangPhim DD, dbo.Phim P
	WHERE LC.idPhong = @idPhong AND LC.idDinhDang = DD.id AND DD.idPhim = P.id AND (@ThoiGianChieu >= LC.ThoiGianChieu AND @ThoiGianChieu <= DATEADD(MINUTE, P.ThoiLuong, LC.ThoiGianChieu))

	SELECT @count2 = COUNT(*)
	FROM dbo.LichChieu LC, dbo.DinhDangPhim DD, dbo.Phim P
	WHERE @idPhong = LC.idPhong AND @idDinhDang = DD.id AND DD.idPhim = P.id AND (LC.ThoiGianChieu >= @ThoiGianChieu AND LC.ThoiGianChieu <= DATEADD(MINUTE, P.ThoiLuong, @ThoiGianChieu))

	IF (@count > 1 OR @count2 > 1)
	BEGIN
		ROLLBACK TRAN
		Raiserror('Thời Gian Chiếu đã trùng với một lịch chiếu khác cùng Phòng Chiếu',16,1)
		Return
	END
END
GO

--Stored Procedures
--TÀI KHOẢN (Đổi mật khẩu & đăng nhập)
CREATE PROC USP_UpdatePasswordForAccount
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

CREATE PROC USP_Login
@userName NVARCHAR(1000), @pass VARCHAR(1000)
AS
BEGIN
	SELECT * FROM dbo.TaiKhoan WHERE UserName = @userName AND Pass = @pass
END
GO

--TÀI KHOẢN (frmAdmin)
CREATE PROC USP_GetAccountList
AS
BEGIN
	SELECT TK.UserName AS [Username], TK.LoaiTK AS [Loại tài khoản], NV.id AS [Mã nhân viên], NV.HoTen AS [Tên nhân viên]
	FROM dbo.TaiKhoan TK, dbo.NhanVien NV
	WHERE NV.id = TK.idNV
END
GO

CREATE PROC USP_InsertAccount
@username NVARCHAR(100), @loaiTK INT, @idnv VARCHAR(50)
AS
BEGIN
	INSERT dbo.TaiKhoan ( UserName, Pass, LoaiTK, idNV )
	VALUES ( @username, '5512317111114510840231031535810616566202691', @loaiTK, @idnv )
END
GO

CREATE PROC USP_UpdateAccount
@username NVARCHAR(100), @loaiTK INT
AS
BEGIN
	UPDATE dbo.TaiKhoan 
	SET LoaiTK = @loaiTK
	WHERE UserName = @username
END
GO

CREATE PROC USP_ResetPasswordtAccount
@username NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.TaiKhoan 
	SET Pass = '5512317111114510840231031535810616566202691' 
	WHERE UserName = @username
END
GO

CREATE PROC USP_SearchAccount
@hoTen NVARCHAR(100)
AS
BEGIN
	SELECT TK.UserName AS [Username], TK.LoaiTK AS [Loại tài khoản], NV.id AS [Mã nhân viên], NV.HoTen AS [Tên nhân viên]
	FROM dbo.TaiKhoan TK, dbo.NhanVien NV
	WHERE NV.id = TK.idNV AND dbo.fuConvertToUnsign1(NV.HoTen) LIKE N'%' + dbo.fuConvertToUnsign1(@hoTen) + N'%'
END
GO


--DOANH THU
CREATE PROC USP_GetRevenueByMovieAndDate
@idMovie VARCHAR(50), @fromDate date, @toDate date
AS
BEGIN
	SELECT P.TenPhim AS [Tên phim], CONVERT(DATE, LC.ThoiGianChieu) AS [Ngày chiếu], CONVERT(TIME(0),LC.ThoiGianChieu) AS [Giờ chiếu], COUNT(V.id) AS [Số vé đã bán], SUM(TienBanVe) AS [Tiền vé]
	FROM dbo.Ve AS V, dbo.LichChieu AS LC, dbo.DinhDangPhim AS DDP, Phim AS P
	WHERE V.idLichChieu = LC.id AND LC.idDinhDang = DDP.id AND DDP.idPhim = P.id AND V.TrangThai = 1 AND P.id = @idMovie AND LC.ThoiGianChieu >= @fromDate AND LC.ThoiGianChieu <= @toDate
	GROUP BY idLichChieu, P.TenPhim, LC.ThoiGianChieu
END
GO

CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO

CREATE PROC USP_GetReportRevenueByMovieAndDate
@idMovie VARCHAR(50), @fromDate date, @toDate date
AS
BEGIN
	SELECT P.TenPhim, CONVERT(DATE, LC.ThoiGianChieu) AS NgayChieu, CONVERT(TIME(0),LC.ThoiGianChieu) AS GioChieu, COUNT(V.id) AS SoVeDaBan, SUM(TienBanVe) AS TienBanVe
	FROM dbo.Ve AS V, dbo.LichChieu AS LC, dbo.DinhDangPhim AS DDP, Phim AS P
	WHERE V.idLichChieu = LC.id AND LC.idDinhDang = DDP.id AND DDP.idPhim = P.id AND V.TrangThai = 1 AND P.id = @idMovie AND LC.ThoiGianChieu >= @fromDate AND LC.ThoiGianChieu <= @toDate
	GROUP BY idLichChieu, P.TenPhim, LC.ThoiGianChieu
END
GO

--KHÁCH HÀNG
CREATE PROC USP_GetCustomer
AS
BEGIN
	SELECT id AS [Mã khách hàng], HoTen AS [Họ tên], NgaySinh AS [Ngày sinh], DiaChi AS [Địa chỉ], SDT AS [SĐT], CMND AS [CMND], DiemTichLuy AS [Điểm tích lũy]
	FROM dbo.KhachHang
END
GO

CREATE PROC USP_InsertCustomer
@idCus VARCHAR(50), @hoTen NVARCHAR(100), @ngaySinh date, @diaChi NVARCHAR(100), @sdt VARCHAR(100), @cmnd INT
AS
BEGIN
	INSERT dbo.KhachHang (id, HoTen, NgaySinh, DiaChi, SDT, CMND, DiemTichLuy)
	VALUES (@idCus, @hoTen, @ngaySinh, @diaChi, @sdt, @cmnd, 0)
END
GO

CREATE PROC USP_SearchCustomer
@hoTen NVARCHAR(100)
AS
BEGIN
	SELECT id AS [Mã khách hàng], HoTen AS [Họ tên], NgaySinh AS [Ngày sinh], DiaChi AS [Địa chỉ], SDT AS [SĐT], CMND AS [CMND], DiemTichLuy AS [Điểm tích lũy]
	FROM dbo.KhachHang
	WHERE dbo.fuConvertToUnsign1(HoTen) LIKE N'%' + dbo.fuConvertToUnsign1(@hoTen) + N'%'
END
GO

--THỂ LOẠI
CREATE PROC USP_InsertGenre
@idGenre VARCHAR(50), @ten NVARCHAR(100), @moTa NVARCHAR(100)
AS
BEGIN
	INSERT dbo.TheLoai (id, TenTheLoai, MoTa)
	VALUES  (@idGenre, @ten, @moTa)
END
GO

--LOẠI MÀN HÌNH
CREATE PROC USP_InsertScreenType
@idScreenType VARCHAR(50), @ten NVARCHAR(100)
AS
BEGIN
	INSERT dbo.LoaiManHinh ( id, TenMH )
	VALUES  (@idScreenType, @ten)
END
GO

--PHIM
CREATE PROC USP_GetMovie
AS
BEGIN
	SELECT id AS [Mã phim], TenPhim AS [Tên phim], MoTa AS [Mô tả], ThoiLuong AS [Thời lượng], NgayKhoiChieu AS [Ngày khởi chiếu], NgayKetThuc AS [Ngày kết thúc], SanXuat AS [Sản xuất], DaoDien AS [Đạo diễn], NamSX AS [Năm SX], ApPhich AS [Áp Phích]
	FROM dbo.Phim
END
GO

CREATE PROC USP_GetListGenreByMovie
@idPhim VARCHAR(50)
AS
BEGIN
	SELECT TL.id, TenTheLoai, TL.MoTa
	FROM dbo.PhanLoaiPhim PL, dbo.TheLoai TL
	WHERE idPhim = @idPhim AND PL.idTheLoai = TL.id
END
GO

CREATE PROC USP_InsertMovie
@id VARCHAR(50), @tenPhim NVARCHAR(100), @moTa NVARCHAR(1000), @thoiLuong FLOAT, @ngayKhoiChieu DATE, @ngayKetThuc DATE, @sanXuat NVARCHAR(50), @daoDien NVARCHAR(100), @namSX INT, @apPhich IMAGE
AS
BEGIN
	INSERT dbo.Phim (id , TenPhim , MoTa , ThoiLuong , NgayKhoiChieu , NgayKetThuc , SanXuat , DaoDien , NamSX, ApPhich)
	VALUES (@id , @tenPhim , @moTa , @thoiLuong , @ngayKhoiChieu , @ngayKetThuc , @sanXuat , @daoDien , @namSX, @apPhich)
END
GO

CREATE PROC USP_UpdateMovie
@id VARCHAR(50), @tenPhim NVARCHAR(100), @moTa NVARCHAR(1000), @thoiLuong FLOAT, @ngayKhoiChieu DATE, @ngayKetThuc DATE, @sanXuat NVARCHAR(50), @daoDien NVARCHAR(100), @namSX INT , @apPhich IMAGE
AS
BEGIN
	UPDATE dbo.Phim SET TenPhim = @tenPhim, MoTa = @moTa, ThoiLuong = @thoiLuong, NgayKhoiChieu = @ngayKhoiChieu, NgayKetThuc = @ngayKetThuc, SanXuat = @sanXuat, DaoDien = @daoDien, NamSX = @namSX, ApPhich = @apPhich WHERE id = @id
END
GO

--ĐỊNH DẠNG PHIM
CREATE PROC USP_GetListFormatMovie
AS
BEGIN
	SELECT DD.id AS [Mã định dạng], P.id AS [Mã phim], P.TenPhim AS [Tên phim], MH.id AS [Mã MH], MH.TenMH AS [Tên MH]
	FROM dbo.DinhDangPhim DD, Phim P, dbo.LoaiManHinh MH
	WHERE DD.idPhim = P.id AND DD.idLoaiManHinh = MH.id
END
GO

CREATE PROC USP_InsertFormatMovie
@id VARCHAR(50), @idPhim VARCHAR(50), @idLoaiManHinh VARCHAR(50)
AS
BEGIN
	INSERT dbo.DinhDangPhim ( id, idPhim, idLoaiManHinh )
	VALUES  ( @id, @idPhim, @idLoaiManHinh )
END
GO


--LỊCH CHIẾU
CREATE PROC USP_GetListShowTimesByFormatMovie
@ID varchar(50), @Date Datetime
AS
BEGIN
	select l.id, pc.TenPhong, p.TenPhim, l.ThoiGianChieu, d.id as idDinhDang, l.GiaVe, l.TrangThai
	from Phim p ,DinhDangPhim d, LichChieu l, PhongChieu pc
	where p.id = d.idPhim and d.id = l.idDinhDang and l.idPhong = pc.id
	and d.id = @ID and CONVERT(DATE, @Date) = CONVERT(DATE, l.ThoiGianChieu)
	order by l.ThoiGianChieu
END
GO

CREATE PROC USP_GetShowtime
AS
BEGIN
	SELECT LC.id AS [Mã lịch chiếu], LC.idPhong AS [Mã phòng], P.TenPhim AS [Tên phim], MH.TenMH AS [Màn hình], LC.ThoiGianChieu AS [Thời gian chiếu], LC.GiaVe AS [Giá vé]
	FROM dbo.LichChieu AS LC, dbo.DinhDangPhim AS DD, Phim AS P, dbo.LoaiManHinh AS MH
	WHERE LC.idDinhDang = DD.id AND DD.idPhim = P.id AND DD.idLoaiManHinh = MH.id
END
GO

CREATE PROC USP_InsertShowtime
@id VARCHAR(50), @idPhong VARCHAR(50), @idDinhDang VARCHAR(50), @thoiGianChieu DATETIME, @giaVe FLOAT
AS
BEGIN
	INSERT dbo.LichChieu ( id , idPhong , idDinhDang, ThoiGianChieu  , GiaVe , TrangThai )
	VALUES  ( @id , @idPhong , @idDinhDang, @thoiGianChieu  , @giaVe , 0 )
END
GO

CREATE PROC USP_UpdateShowtime
@id VARCHAR(50), @idPhong VARCHAR(50), @idDinhDang VARCHAR(50), @thoiGianChieu DATETIME, @giaVe FLOAT
AS
BEGIN
	UPDATE dbo.LichChieu 
	SET idPhong = @idPhong, idDinhDang = @idDinhDang, ThoiGianChieu = @thoiGianChieu , GiaVe = @giaVe
	WHERE id = @id
END
GO

CREATE PROC USP_SearchShowtimeByMovieName
@tenPhim NVARCHAR(100)
AS
BEGIN
	SELECT LC.id AS [Mã lịch chiếu], LC.idPhong AS [Mã phòng], P.TenPhim AS [Tên phim], MH.TenMH AS [Màn hình], LC.ThoiGianChieu AS [Thời gian chiếu], LC.GiaVe AS [Giá vé]
	FROM dbo.LichChieu AS LC, dbo.DinhDangPhim AS DD, Phim AS P, dbo.LoaiManHinh AS MH
	WHERE LC.idDinhDang = DD.id AND DD.idPhim = P.id AND DD.idLoaiManHinh = MH.id AND dbo.fuConvertToUnsign1(P.TenPhim) LIKE N'%' + dbo.fuConvertToUnsign1(@tenPhim) + N'%'
END
GO

CREATE PROC USP_GetAllListShowTimes
AS
BEGIN
	select l.id, pc.TenPhong, p.TenPhim, l.ThoiGianChieu, d.id as idDinhDang, l.GiaVe, l.TrangThai
	from Phim p ,DinhDangPhim d, LichChieu l, PhongChieu pc
	where p.id = d.idPhim and d.id = l.idDinhDang and l.idPhong = pc.id
	order by l.ThoiGianChieu
END
GO

CREATE PROC USP_GetListShowTimesNotCreateTickets
AS
BEGIN
	select l.id, pc.TenPhong, p.TenPhim, l.ThoiGianChieu, d.id as idDinhDang, l.GiaVe, l.TrangThai
	from Phim p ,DinhDangPhim d, LichChieu l, PhongChieu pc
	where p.id = d.idPhim and d.id = l.idDinhDang and l.idPhong = pc.id and l.TrangThai = 0
	order by l.ThoiGianChieu
END
GO

CREATE PROC USP_UpdateStatusShowTimes
@idLichChieu NVARCHAR(50), @status int
AS
BEGIN
	UPDATE dbo.LichChieu
	SET TrangThai = @status
	WHERE id = @idLichChieu
END
GO

--NHÂN VIÊN
CREATE PROC USP_GetStaff
AS
BEGIN
	SELECT id AS [Mã nhân viên], HoTen AS [Họ tên], NgaySinh AS [Ngày sinh], DiaChi AS [Địa chỉ], SDT AS [SĐT], CMND AS [CMND]
	FROM dbo.NhanVien
END
GO

CREATE PROC USP_InsertStaff
@idStaff VARCHAR(50), @hoTen NVARCHAR(100), @ngaySinh date, @diaChi NVARCHAR(100), @sdt VARCHAR(100), @cmnd INT
AS
BEGIN
	INSERT dbo.NhanVien (id, HoTen, NgaySinh, DiaChi, SDT, CMND)
	VALUES (@idStaff, @hoTen, @ngaySinh, @diaChi, @sdt, @cmnd)
END
GO

CREATE PROC USP_SearchStaff
@hoTen NVARCHAR(100)
AS
BEGIN
	SELECT id AS [Mã nhân viên], HoTen AS [Họ tên], NgaySinh AS [Ngày sinh], DiaChi AS [Địa chỉ], SDT AS [SĐT], CMND AS [CMND]
	FROM dbo.NhanVien
	WHERE dbo.fuConvertToUnsign1(HoTen) LIKE N'%' + dbo.fuConvertToUnsign1(@hoTen) + N'%'
END
GO


--PHÒNG CHIẾU
CREATE PROC USP_GetCinema
AS
BEGIN
	SELECT PC.id AS [Mã phòng], TenPhong AS [Tên phòng], TenMH AS [Tên màn hình], PC.SoChoNgoi AS [Số chỗ ngồi], PC.TinhTrang AS [Tình trạng], PC.SoHangGhe AS [Số hàng ghế], PC.SoGheMotHang AS [Ghế mỗi hàng]
	FROM dbo.PhongChieu AS PC, dbo.LoaiManHinh AS MH
	WHERE PC.idManHinh = MH.id
END
GO

CREATE PROC USP_InsertCinema
@idCinema VARCHAR(50), @tenPhong NVARCHAR(100), @idMH VARCHAR(50), @soChoNgoi INT, @tinhTrang INT, @soHangGhe INT, @soGheMotHang INT
AS
BEGIN
	INSERT dbo.PhongChieu ( id , TenPhong , idManHinh , SoChoNgoi , TinhTrang , SoHangGhe , SoGheMotHang)
	VALUES (@idCinema , @tenPhong , @idMH , @soChoNgoi , @tinhTrang , @soHangGhe , @soGheMotHang)
END
GO


--VÉ
CREATE PROC USP_InsertTicketByShowTimes
@idlichChieu VARCHAR(50), @maGheNgoi VARCHAR(50)
AS
BEGIN
	INSERT INTO dbo.Ve
	(
		idLichChieu,
		MaGheNgoi,
		idKhachHang
	)
	VALUES
	(
		@idlichChieu,
		@maGheNgoi,
		NULL
	)
END
GO

CREATE PROC USP_DeleteTicketsByShowTimes
@idlichChieu VARCHAR(50)
AS
BEGIN
	DELETE FROM dbo.Ve
	WHERE idLichChieu = @idlichChieu
END
GO

--Insert Dữ Liệu
INSERT INTO TheLoai(id,TenTheLoai,MoTa) VALUES (N'TL01',N'Hành Động', NULL);
INSERT INTO TheLoai(id,TenTheLoai,MoTa) VALUES (N'TL02',N'Viễn Tưởng', NULL);
INSERT INTO TheLoai(id,TenTheLoai,MoTa) VALUES (N'TL03',N'Tâm Lí', NULL);
INSERT INTO TheLoai(id,TenTheLoai,MoTa) VALUES (N'TL04',N'Tình Cảm', NULL);
INSERT INTO TheLoai(id,TenTheLoai,MoTa) VALUES (N'TL05',N'Kinh Dị', NULL);

INSERT INTO NhanVien(id, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV00',N'admin', '2020-11-11', N'admin',NULL,123456789 );
INSERT INTO NhanVien(id, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV01',N'Bán vé','2020-11-11', NULL,NULL,023456789 );

INSERT INTO TaiKhoan(UserName, Pass, LoaiTK, idNV) VALUES (N'admin', N'59113821474147731767615617822114745333', 1, N'NV00');-- mk hiện thị là admin
INSERT INTO TaiKhoan(UserName, Pass, LoaiTK, idNV) VALUES (N'NV01', N'59113821474147731767615617822114745333', 2, N'NV01');
--INSERT INTO TaiKhoan(UserName, Pass, LoaiTK, MaNV) VALUES (N'NV02', N'59113821474147731767615617822114745333', 3, N'NV02');

INSERT INTO KhachHang(id, HoTen, NgaySinh, DiaChi, SDT, CMND, DiemTichLuy) VALUES (N'KH01',N'Viên Hoàng Long','2020-11-02',N'Quận 7',N'0398719657',316732368,999);
INSERT INTO KhachHang(id, HoTen, NgaySinh, DiaChi, SDT, CMND, DiemTichLuy) VALUES (N'KH02',N'Trần Thị Kim Tuyến','2020-11-11',N'Quận 7',N'038171317',31611368,999);
INSERT INTO KhachHang(id, HoTen, NgaySinh, DiaChi, SDT, CMND, DiemTichLuy) VALUES (N'KH03',N'Trần Hoàng A','2020-04-11',N'Quận 8',N'038171317',33123368,0);

INSERT INTO LoaiManHinh(id, TenMH) VALUES (N'MH01', N'2D');
INSERT INTO LoaiManHinh(id, TenMH) VALUES (N'MH02', N'3D');
INSERT INTO LoaiManHinh(id, TenMH) VALUES (N'MH03', N'4D');

INSERT INTO PhongChieu(id, TenPhong, idManHinh, SoChoNgoi, TinhTrang, SoHangGhe, SoGheMotHang) VALUES(N'PC01',N'CINEMA 01',N'MH02',100,1,10,14);
INSERT INTO PhongChieu(id, TenPhong, idManHinh, SoChoNgoi, TinhTrang, SoHangGhe, SoGheMotHang) VALUES(N'PC02',N'CINEMA 02',N'MH03',100,1,10,14);
INSERT INTO PhongChieu(id, TenPhong, idManHinh, SoChoNgoi, TinhTrang, SoHangGhe, SoGheMotHang) VALUES(N'PC03',N'CINEMA 03',N'MH01',100,1,10,14);


INSERT INTO Phim(id, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc, SanXuat, DaoDien, NamSX) VALUES(N'P01',N'Cô Ba Sài Gòn',N'Cô Ba Sài Gòn',100,'2020-10-11','2020-10-20',N'VAA', N'Kay Nguyễn', 2020);
INSERT INTO Phim(id, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc, SanXuat, DaoDien, NamSX) VALUES(N'P02',N'Mắt Biếc',N'Tác phẩm chuyển thể từ truyện ngắn nổi tiếng',117,'2020-9-12','2020-10-12',N'Galaxy M&E', N'Virctor Vũ', 2020);
INSERT INTO Phim(id, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc, SanXuat, DaoDien, NamSX) VALUES(N'P03',N'Tiệc Trăng Máu',N'Tác phẩm chuyển thể từ kịch bản nước ngoài',118,'2020-10-11','2020-12-12',N'Lotter Entertaiment', N'Nguyễn Quang Dũng', 2020);
INSERT INTO Phim(id, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc, SanXuat, DaoDien, NamSX) VALUES(N'P04',N'Chị Chị em em',N'Nội dung về hai người phụ nữ xinh đẹp',104,'2020-11-06','2020-12-06',N'Muse Film', N'Kathy Uyên', 2020);
INSERT INTO Phim(id, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc, SanXuat, DaoDien, NamSX) VALUES(N'P05',N'Happy Death Day 2',N'Bộ phim kinh dị của Mỹ',129,'2020-10-11','2020-12-20',N'Mỹ', N'Christopher Landon', 2020);

INSERT INTO PhanLoaiPhim(idPhim, idTheLoai) VALUES(N'P01', N'TL01');
INSERT INTO PhanLoaiPhim(idPhim, idTheLoai) VALUES(N'P02', N'TL04');
INSERT INTO PhanLoaiPhim(idPhim, idTheLoai) VALUES(N'P03', N'TL03');
INSERT INTO PhanLoaiPhim(idPhim, idTheLoai) VALUES(N'P04', N'TL02');
INSERT INTO PhanLoaiPhim(idPhim, idTheLoai) VALUES(N'P05', N'TL05');


INSERT INTO DinhDangPhim(id, idPhim, idLoaiManHinh) VALUES (N'DD01', N'P01', N'MH01');
INSERT INTO DinhDangPhim(id, idPhim, idLoaiManHinh) VALUES (N'DD02', N'P01', N'MH03');
INSERT INTO DinhDangPhim(id, idPhim, idLoaiManHinh) VALUES (N'DD03', N'P02', N'MH01');
INSERT INTO DinhDangPhim(id, idPhim, idLoaiManHinh) VALUES (N'DD04', N'P03', N'MH02');

INSERT INTO LichChieu(id, ThoiGianChieu, idPhong, idDinhDang, GiaVe, TrangThai) VALUES (N'LC01','2020-10-11',N'PC01', N'DD01', 85000.0000, 1);
INSERT INTO LichChieu(id, ThoiGianChieu, idPhong, idDinhDang, GiaVe, TrangThai) VALUES (N'LC02','2020-10-11',N'PC03', N'DD02', 85000.0000, 0);
INSERT INTO LichChieu(id, ThoiGianChieu, idPhong, idDinhDang, GiaVe, TrangThai) VALUES (N'LC03','2020-10-11',N'PC02', N'DD03', 85000.0000, 0);

SET IDENTITY_INSERT [dbo].[Ve] ON
GO
INSERT INTO Ve(LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES(0,N'LC01',N'A1',NULL,0,0.0000);
INSERT INTO Ve(LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'A2',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'A3',NULL,0,0.0000);
INSERT INTO Ve(LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'A4',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'A5',NULL,0,0.0000);
INSERT INTO Ve(LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'A6',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'A7',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'A8',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'A9',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'A10',NULL,0,0.0000);
INSERT INTO Ve(LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'B1',NULL,0,0.0000);
INSERT INTO Ve(LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'B2',NULL,0,0.0000);
INSERT INTO Ve(LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'B3',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'B4',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'B5',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'B6',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'B7',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'B8',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'B9',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'B10',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'C1',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'C2',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'C3',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'C4',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'C5',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'C7',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'C8',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'C9',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'C10',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'D1',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'D2',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'D3',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'D4',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'D5',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'D6',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (3,N'LC01',N'D7',NULL,1,59500.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'D8',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'D9',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'D10',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (1,N'LC01',N'E1',NULL,1,85000.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (1,N'LC01',N'E2',NULL,1,85000.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (2,N'LC01',N'E3',NULL,1,68000.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (2,N'LC01',N'E4',NULL,1,68000.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'E5',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'E6',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (3,N'LC01',N'E7',NULL,1,59500.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'E8',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'E9',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'F1',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'F2',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'F3',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'F4',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'F5',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'F6',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'F7',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'F8',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'F9',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'F10',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'G1',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'G2',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'G3',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'G4',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'G5',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'G7',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'G7',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'G8',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'G9',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'G10',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'H1',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'H2',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'H3',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'H4',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'H5',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'H6',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'H7',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'H8',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'H9',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'H10',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'I1',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'I2',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'I3',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'I4',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'I5',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'I6',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'I7',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'I8',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'I9',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'I10',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'J1',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'J2',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'J3',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'J4',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'J5',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'J6',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'J7',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'J8',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'J9',NULL,0,0.0000);
INSERT INTO Ve( LoaiVe, idLichChieu, MaGheNgoi, idKhachHang, TrangThai, TienBanVe) VALUES (0,N'LC01',N'J10',NULL,0,0.0000);
SET IDENTITY_INSERT [dbo].[Ve] OFF
GO
INSERT INTO ThucPham(MaTP, TenTP, LoaiTP, GiaTP) VALUES (N'TP01',N'Bắp',N'Đồ Ăn',25000);

INSERT INTO SKQuangCao(MaSK, TenSK, Uudai, ChuDe, ThoiGianApDung, ThoiGianKetThuc) VALUES(N'SK01',N'Tích điểm',N'Miễn phí vé',N'Noel','2020-10-11','2021-01-01');
