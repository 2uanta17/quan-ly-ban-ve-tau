IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'QUANLYBANVETAU')
BEGIN
    CREATE DATABASE QUANLYBANVETAU;
END
GO

USE QUANLYBANVETAU;
GO

-- Xóa các bảng nếu đã tồn tại
DROP TABLE IF EXISTS Ve;
DROP TABLE IF EXISTS HanhTrinh;
DROP TABLE IF EXISTS Tau;
DROP TABLE IF EXISTS GaTau;
DROP TABLE IF EXISTS QuanLy;
GO

-- Bảng Ga Tàu
CREATE TABLE GaTau (
    MaGa INT PRIMARY KEY IDENTITY(1,1),
    TenGa NVARCHAR(100) NOT NULL UNIQUE
);
GO

-- Bảng Tàu
CREATE TABLE Tau (
    MaTau INT PRIMARY KEY IDENTITY(1,1),
    TenTau NVARCHAR(50) NOT NULL UNIQUE 
);
GO

-- Bảng Hành Trình
CREATE TABLE HanhTrinh (
    MaHanhTrinh INT PRIMARY KEY IDENTITY(1,1),
    MaTau INT NOT NULL REFERENCES Tau(MaTau),
    MaGaDi INT NOT NULL REFERENCES GaTau(MaGa),
    MaGaDen INT NOT NULL REFERENCES GaTau(MaGa),
    NgayDi DATE NOT NULL,
    GioDi TIME NOT NULL,
    GioDen TIME NOT NULL,
    GiaVe DECIMAL(18, 0) NOT NULL
);
GO

-- 4. Bảng Vé
CREATE TABLE Ve (
    MaVe INT PRIMARY KEY IDENTITY(1,1),
    MaHanhTrinh INT NOT NULL REFERENCES HanhTrinh(MaHanhTrinh),
    SoGhe INT NOT NULL,
    TenHanhKhach NVARCHAR(100) NOT NULL,
    ThongTinLienHe NVARCHAR(100) NOT NULL,
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Đã đặt'
);
GO

-- 5. Bảng Quản Lý
CREATE TABLE QuanLy (
    MaQuanLy INT PRIMARY KEY IDENTITY(1,1),
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    MatKhau NVARCHAR(100) NOT NULL
);
GO

-- Thêm dữ liệu mẫu

-- Bảng Ga Tàu
INSERT INTO GaTau (TenGa) VALUES 
(N'Hà Nội'), 
(N'Hải Phòng'), 
(N'Đà Nẵng'), 
(N'TP. Hồ Chí Minh'), 
(N'Vinh'),
(N'Huế'), 
(N'Nha Trang'), 
(N'Quy Nhơn'), 
(N'Lào Cai'), 
(N'Hải Dương');
GO

-- Bảng Tàu
INSERT INTO Tau (TenTau) VALUES 
(N'HP1'), (N'LP3'), (N'LP5'), (N'HP2'), (N'LP4'), 
(N'SE1'), (N'SE2'), (N'TN1'), (N'SP1'), (N'LC3');
GO

-- Bảng Quản Lý
INSERT INTO QuanLy (TenDangNhap, MatKhau) VALUES 
(N'admin', N'admin123'),
(N'manager', N'manager123');
GO

-- Bảng Hành Trình

-- Lấy MaGa
DECLARE @MaGaHN INT = (SELECT MaGa FROM GaTau WHERE TenGa = N'Hà Nội');
DECLARE @MaGaHP INT = (SELECT MaGa FROM GaTau WHERE TenGa = N'Hải Phòng');
DECLARE @MaGaDN INT = (SELECT MaGa FROM GaTau WHERE TenGa = N'Đà Nẵng');
DECLARE @MaGaHCM INT = (SELECT MaGa FROM GaTau WHERE TenGa = N'TP. Hồ Chí Minh');
DECLARE @MaGaVinh INT = (SELECT MaGa FROM GaTau WHERE TenGa = N'Vinh');
DECLARE @MaGaHue INT = (SELECT MaGa FROM GaTau WHERE TenGa = N'Huế');
DECLARE @MaGaNT INT = (SELECT MaGa FROM GaTau WHERE TenGa = N'Nha Trang');

-- Lấy MaTau
DECLARE @MaTauHP1 INT = (SELECT MaTau FROM Tau WHERE TenTau = N'HP1');
DECLARE @MaTauLP3 INT = (SELECT MaTau FROM Tau WHERE TenTau = N'LP3');
DECLARE @MaTauLP5 INT = (SELECT MaTau FROM Tau WHERE TenTau = N'LP5');
DECLARE @MaTauHP2 INT = (SELECT MaTau FROM Tau WHERE TenTau = N'HP2');
DECLARE @MaTauSE1 INT = (SELECT MaTau FROM Tau WHERE TenTau = N'SE1');
DECLARE @MaTauSE2 INT = (SELECT MaTau FROM Tau WHERE TenTau = N'SE2');
DECLARE @MaTauTN1 INT = (SELECT MaTau FROM Tau WHERE TenTau = N'TN1');

-- Ngày
DECLARE @Ngay1 DATE = '2025-11-12';
DECLARE @Ngay2 DATE = '2025-11-13';
DECLARE @Ngay3 DATE = '2025-11-14';

INSERT INTO HanhTrinh (MaTau, MaGaDi, MaGaDen, NgayDi, GioDi, GioDen, GiaVe)
VALUES
-- Tuyến HN -> HP (Ngày 1)
(@MaTauHP1, @MaGaHN, @MaGaHP, @Ngay1, '06:00:00', '08:25:00', 150000), -- 1
(@MaTauLP3, @MaGaHN, @MaGaHP, @Ngay1, '09:17:00', '12:00:00', 145000), -- 2
(@MaTauLP5, @MaGaHN, @MaGaHP, @Ngay1, '15:20:00', '18:00:00', 160000), -- 3
-- Tuyến HP -> HN (Ngày 1)
(@MaTauHP2, @MaGaHP, @MaGaHN, @Ngay1, '06:15:00', '08:45:00', 150000), -- 4
-- Tuyến HN -> HP (Ngày 2)
(@MaTauHP1, @MaGaHN, @MaGaHP, @Ngay2, '06:00:00', '08:25:00', 155000), -- 5 (giá khác)
-- Tuyến HN -> Vinh (Ngày 1)
(@MaTauSE1, @MaGaHN, @MaGaVinh, @Ngay1, '19:30:00', '01:00:00', 350000), -- 6
-- Tuyến HN -> Đà Nẵng (Ngày 1)
(@MaTauSE1, @MaGaHN, @MaGaDN, @Ngay1, '19:30:00', '11:30:00', 700000), -- 7
-- Tuyến HCM -> Nha Trang (Ngày 1)
(@MaTauTN1, @MaGaHCM, @MaGaNT, @Ngay1, '08:00:00', '15:00:00', 450000), -- 8
-- Tuyến HCM -> Đà Nẵng (Ngày 2)
(@MaTauSE2, @MaGaHCM, @MaGaDN, @Ngay2, '20:00:00', '12:00:00', 750000), -- 9
-- Tuyến Đà Nẵng -> Huế (Ngày 3)
(@MaTauSE1, @MaGaDN, @MaGaHue, @Ngay3, '11:40:00', '14:20:00', 120000); -- 10
GO

-- Bảng Vé
DECLARE @MaTauHP1 INT = (SELECT MaTau FROM Tau WHERE TenTau = N'HP1');
DECLARE @MaTauLP3 INT = (SELECT MaTau FROM Tau WHERE TenTau = N'LP3');
DECLARE @MaTauSE1 INT = (SELECT MaTau FROM Tau WHERE TenTau = N'SE1');

-- Lấy MaHanhTrinh
DECLARE @HT1 INT = (SELECT MaHanhTrinh FROM HanhTrinh WHERE MaTau = @MaTauHP1 AND NgayDi = '2025-11-12');
DECLARE @HT2 INT = (SELECT MaHanhTrinh FROM HanhTrinh WHERE MaTau = @MaTauLP3 AND NgayDi = '2025-11-12');
DECLARE @HT6 INT = (SELECT MaHanhTrinh FROM HanhTrinh WHERE MaTau = @MaTauSE1 AND MaGaDen = (SELECT MaGa FROM GaTau WHERE TenGa = N'Vinh'));

INSERT INTO Ve (MaHanhTrinh, SoGhe, TenHanhKhach, ThongTinLienHe, TrangThai)
VALUES
-- Vé cho HP1 (Ngày 1)
(@HT1, 5, N'Nguyễn Văn A', N'0912345678', N'Đã đặt'), -- 1
(@HT1, 12, N'Trần Thị B', N'0987654321', N'Đã đặt'), -- 2
(@HT1, 15, N'Lê Minh C', N'0905111222', N'Đã đặt'), -- 3
(@HT1, 44, N'Phạm Gia D', N'0977333444', N'Đã hủy'), -- 4
(@HT1, 45, N'Võ Hùng E', N'0944555666', N'Đã đặt'), -- 5
-- Vé cho LP3 (Ngày 1)
(@HT2, 1, N'Hoàng Thị F', N'0888123123', N'Đã đặt'), -- 6
(@HT2, 2, N'Đặng Văn G', N'0868456456', N'Đã đặt'), -- 7
(@HT2, 30, N'Bùi Hữu H', N'0812789789', N'Đã đặt'), -- 8
-- Vé cho SE1 (HN -> Vinh)
(@HT6, 10, N'Trịnh Xuân I', N'0777999888', N'Đã đặt'), -- 9
(@HT6, 11, N'Đinh Bảo K', N'0707111222', N'Đã đặt'); -- 10
GO