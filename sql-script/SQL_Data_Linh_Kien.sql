USE [DataLinhKien]
GO
/****** Object:  Table [dbo].[CHI_TIET_DON_HANG]    Script Date: 12/10/2023 8:54:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHI_TIET_DON_HANG](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[DON_HANG_ID] [bigint] NULL,
	[SAN_PHAM_ID] [bigint] NULL,
	[GIA] [decimal](12, 2) NULL,
	[MAU] [nvarchar](50) NULL,
	[SO_LUONG] [int] NULL,
	[TEN_SAN_PHAM] [nvarchar](100) NULL,
	[HINH_ANH] [varchar](200) NULL,
 CONSTRAINT [PR__CHI_TIET_DON_HANG__DON_HANG_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHI_TIET_SAN_PHAM]    Script Date: 12/10/2023 8:54:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHI_TIET_SAN_PHAM](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SAN_PHAM_ID] [bigint] NOT NULL,
	[TIEU_DE] [nvarchar](100) NULL,
	[NOI_DUNG] [nvarchar](300) NULL,
 CONSTRAINT [PR__CHI_TIET_SAN_PHAM__ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DON_HANG]    Script Date: 12/10/2023 8:54:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DON_HANG](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TEN_TAI_KHOAN] [varchar](50) NULL,
	[NGAY_DAT_HANG] [date] NULL,
	[TONG_SAN_PHAM] [int] NULL,
	[TONG_TIEN] [decimal](15, 2) NULL,
	[TRANG_THAI] [nvarchar](50) NULL,
	[NGAY_DUYET] [date] NULL,
	[NGAY_HUY] [date] NULL,
 CONSTRAINT [PR_DON_HANG_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GIO_HANG]    Script Date: 12/10/2023 8:54:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GIO_HANG](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TEN_TAI_KHOAN] [varchar](50) NOT NULL,
	[SAN_PHAM_ID] [bigint] NOT NULL,
	[SO_LUONG] [int] NULL,
 CONSTRAINT [PR__GIO_HANG__ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HINH_ANH]    Script Date: 12/10/2023 8:54:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HINH_ANH](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SAN_PHAM_ID] [bigint] NULL,
	[TEN_FILE] [varchar](555) NOT NULL,
	[THU_MUC] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAI_SAN_PHAM]    Script Date: 12/10/2023 8:54:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAI_SAN_PHAM](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TEN] [nvarchar](50) NULL,
 CONSTRAINT [PR__LOAI_SAN_PHAM__ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SAN_PHAM]    Script Date: 12/10/2023 8:54:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SAN_PHAM](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TEN] [nvarchar](200) NOT NULL,
	[GIA] [decimal](12, 2) NULL,
	[MAU] [nvarchar](50) NULL,
	[MA_PHAN_LOAI] [varchar](50) NULL,
	[SO_LUONG] [int] NULL,
	[TRANG_THAI] [nvarchar](50) NULL,
	[LOAI_SP_ID] [bigint] NULL,
 CONSTRAINT [PR_SANPHAM_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAI_KHOAN]    Script Date: 12/10/2023 8:54:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAI_KHOAN](
	[TEN_TAI_KHOAN] [varchar](50) NOT NULL,
	[MAT_KHAU] [varchar](50) NOT NULL,
	[QUYEN_HAN] [varchar](50) NOT NULL,
	[EMAIL] [varchar](200) NOT NULL,
 CONSTRAINT [PR__TAI_KHOAN__TEN_TAI_KHOAN] PRIMARY KEY CLUSTERED 
(
	[TEN_TAI_KHOAN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THONG_TIN_DON_HANG]    Script Date: 12/10/2023 8:54:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THONG_TIN_DON_HANG](
	[ID] [bigint] NOT NULL,
	[TEN] [nvarchar](50) NULL,
	[HO] [nvarchar](50) NULL,
	[SDT] [varchar](20) NULL,
	[GIOI_TINH] [nvarchar](4) NULL,
	[DIA_CHI] [nvarchar](50) NULL,
	[PHUONG_XA] [nvarchar](50) NULL,
	[QUAN_HUYEN] [nvarchar](50) NULL,
	[TINH_THANH] [nvarchar](50) NULL,
 CONSTRAINT [PR__THONG_TIN_DON_HANG__ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THONG_TIN_TAI_KHOAN]    Script Date: 12/10/2023 8:54:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THONG_TIN_TAI_KHOAN](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TEN_TAI_KHOAN] [varchar](50) NOT NULL,
	[TEN] [nvarchar](50) NOT NULL,
	[HO] [nvarchar](50) NOT NULL,
	[SDT] [varchar](11) NULL,
	[GIOI_TINH] [nvarchar](4) NULL,
	[DIA_CHI] [nvarchar](50) NULL,
	[PHUONG_XA] [nvarchar](50) NULL,
	[QUAN_HUYEN] [nvarchar](50) NULL,
	[TINH_THANH] [nvarchar](50) NULL,
	[ANH_DAI_DIEN] [varchar](200) NULL,
 CONSTRAINT [PR__THONG_TIN_TAI_KHOAN__ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CHI_TIET_DON_HANG] ON 

INSERT [dbo].[CHI_TIET_DON_HANG] ([ID], [DON_HANG_ID], [SAN_PHAM_ID], [GIA], [MAU], [SO_LUONG], [TEN_SAN_PHAM], [HINH_ANH]) VALUES (2, 2, 3, CAST(100000.00 AS Decimal(12, 2)), N'R3', 1, N'Arduino UNO R3 DIP Kèm cáp', N'mach/arduino-uno-r3-dip-1-b1hz-2-600x600.jpg')
INSERT [dbo].[CHI_TIET_DON_HANG] ([ID], [DON_HANG_ID], [SAN_PHAM_ID], [GIA], [MAU], [SO_LUONG], [TEN_SAN_PHAM], [HINH_ANH]) VALUES (3, 3, 3, CAST(100000.00 AS Decimal(12, 2)), N'R3', 1, N'Arduino UNO R3 DIP Kèm cáp', N'mach/arduino-uno-r3-dip-1-b1hz-2-600x600.jpg')
INSERT [dbo].[CHI_TIET_DON_HANG] ([ID], [DON_HANG_ID], [SAN_PHAM_ID], [GIA], [MAU], [SO_LUONG], [TEN_SAN_PHAM], [HINH_ANH]) VALUES (4, 4, 3, CAST(100000.00 AS Decimal(12, 2)), N'R3', 2, N'Arduino UNO R3 DIP Kèm cáp', N'mach/arduino-uno-r3-dip-1-b1hz-3-600x600.jpg')
INSERT [dbo].[CHI_TIET_DON_HANG] ([ID], [DON_HANG_ID], [SAN_PHAM_ID], [GIA], [MAU], [SO_LUONG], [TEN_SAN_PHAM], [HINH_ANH]) VALUES (5, 4, 14, CAST(180000.00 AS Decimal(12, 2)), N'', 1, N'Cảm biến tiệm cận kim loại FOTEK PM12-04N Chính hãng', N'cambien/de-cam-bien-mua-tzpn-1-600x600.jpg')
INSERT [dbo].[CHI_TIET_DON_HANG] ([ID], [DON_HANG_ID], [SAN_PHAM_ID], [GIA], [MAU], [SO_LUONG], [TEN_SAN_PHAM], [HINH_ANH]) VALUES (6, 4, 20, CAST(70000.00 AS Decimal(12, 2)), N'', 1, N'Chip Led 10W ánh sáng trắng 6000 - 6500K 60 độ', N'led/chip-led-sieu-sang-6000-6500k-gou9-f0pn-5-600x600.jpg')
SET IDENTITY_INSERT [dbo].[CHI_TIET_DON_HANG] OFF
GO
SET IDENTITY_INSERT [dbo].[CHI_TIET_SAN_PHAM] ON 

INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (430, 1, N'Vi điều khiển', N'ATmega328P')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (431, 1, N'Nạp dữ liệu qua cổng', N'Type-C')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (432, 1, N'Chân Digital I/O', N'14')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (433, 1, N'Chân PWM Digital', N'6')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (434, 1, N'Chân đầu vào Analog', N'8 (thêm A6, A7 so với UNO)')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (435, 1, N'Bộ nhớ Flash', N'32 KB (ATmega328P)')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (436, 2, N'Bộ vi điều khiển', N'LGT8F328P')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (437, 2, N'Điện áp hoạt động', N'5V')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (438, 2, N'Điện áp đầu vào (khuyến nghị)', N'7-12V')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (439, 2, N'Điện áp đầu vào (giới hạn)', N'6-20V')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (440, 2, N'Chân I / O kỹ thuật số', N'14 (trong đó 6 chân cung cấp đầu ra PWM)')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (441, 3, N'IC', N'LGT8F328P')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (442, 3, N'FLASH', N'32 Kbytes')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (443, 3, N'SRAM', N'2 Kbytes')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (444, 3, N'E2PROM', N'có thể cấu hình thành 0K/1K/2K/4K/8K (Shared With Flash)')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (445, 3, N'Tốc độ thạch anh', N'16 MHz (MAX 32Mhz)')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (446, 3, N'Ngõ I/O', N'14 ( trong đó 6 chân có thể output PWM )')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (447, 4, N'IC', N'LGT8F328P')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (448, 4, N'FLASH', N'32 Kbytes')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (449, 4, N'SRAM', N'2 Kbytes')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (450, 4, N'E2PROM', N'có thể cấu hình thành 0K/1K/2K/4K/8K (Shared With Flash)')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (451, 4, N'Tốc độ thạch anh', N'16 MHz (MAX 32Mhz)')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (452, 4, N'Ngõ I/O', N'14 ( trong đó 6 chân có thể output PWM )')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (468, 8, N'Model', N'BKF-DS30C4')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (469, 8, N'Nhà sản xuất', N'Dawei')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (470, 8, N'Phát hiện', N'vật cản màu tối hoặc bất kể đối tượng phản chiếu nào')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (471, 8, N'Khoảng cách phát hiện', N'7 to 60cm (có thể điều chỉnh bằng biến trở)')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (472, 8, N'Điện áp làm việc', N'DC 6 – 36V DC')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (473, 8, N'Dòng làm việc', N'80 ~ 300mA')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (474, 9, N'Khoảng cách phát hiện', N'≤4 mm')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (475, 9, N'Lỗ lắp đặt', N'12 mm')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (476, 9, N'Điện áp', N'90 ~ 250V AC')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (477, 9, N'Loại cảm biến', N'NO')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (478, 9, N'Dòng ra', N'< 300mA')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (479, 9, N'Tần số đáp ứng', N'200Hz')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (480, 10, N'Khoảng cách phát hiện', N'≤8 mm')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (481, 10, N'Lỗ lắp đặt', N'18 mm')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (482, 10, N'Điện áp', N'90 ~ 250V AC')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (483, 10, N'Loại cảm biến', N'NO')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (484, 10, N'Dòng ra', N'< 300mA')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (485, 10, N'Đối tượng phát hiện', N'Kim loại đồng, sắt, nhôm, vàng...')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (486, 10, N'Tần số đáp ứng', N'200Hz')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (487, 10, N'Chiều dài cable', N'1.5 mét')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (488, 12, N'Một bộ gồm', N'cảm biến và mạch giải mã tín hiệu')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (489, 12, N'Điện áp', N'5V')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (490, 12, N'Dạng tín hiệu', N'Analog hoặc didital')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (491, 12, N'Dòng ra tối đa', N'100mA')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (492, 14, N'Model', N'KM12-04N')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (493, 14, N'Nhà sản xuất', N'FOTEK')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (494, 14, N'Điện áp', N'10-30V')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (495, 14, N'Loại cảm biến', N'NPN (NO)')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (496, 14, N'Khoảng cách phát hiện', N'≤4 mm')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (497, 14, N'Dòng ra', N'< 150mA')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (498, 14, N'Đối tượng phát hiện', N'Kim loại đồng, sắt, nhôm, vàng,..')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (499, 14, N'Lỗ lắp đặt', N'12mm')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (500, 15, N'Model', N'SN04-N')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (501, 15, N'Nhà sản xuất', N'ROKO')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (502, 15, N'Điện áp', N'10-30V')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (503, 15, N'Dạng ngõ ra', N'NPN cực thu hở (cần mắc trở treo lên VCC để tạo mức cao (High))')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (504, 15, N'Khoảng cách phát hiện', N'≤4 mm')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (505, 15, N'Dòng chịu tải', N'<300mA')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (506, 17, N'Model', N'E3F-R2C1')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (507, 17, N'Điện áp làm việc', N'6-36 VDC')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (508, 17, N'Cảm biến khoảng cách', N'10-300 cm')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (509, 17, N'Thời gian đáp ứng', N'2ms')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (510, 17, N'Dòng điện ngõ ra', N'80-300mA')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (511, 17, N'Đường kính cảm biến', N'18mm')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (512, 18, N'Điện áp sử dụng', N'3.4 ~ 3.8')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (513, 18, N'Dòng  định mức', N'700mA')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (514, 18, N'Độ sáng', N'180~250 Lumen')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (515, 19, N'Hãng sản xuất', N'Epistar')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (516, 19, N'Ánh sáng', N'4000 – 4500K')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (517, 19, N'Công suất', N'20W')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (518, 19, N'Dòng điện', N'<700mA')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (519, 19, N'Điện áp', N'30 – 34vdc')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (520, 19, N'Trọng lượng', N'30g')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (521, 20, N'Công suất', N'10w')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (522, 20, N'Điện áp', N'9 – 11vdc')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (523, 20, N'Dòng điện', N'< 1A')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (524, 20, N'Ánh sáng', N'ánh sáng trắng 6000 – 6500K')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (525, 20, N'Luminous Flux', N'1000 – 1100lm')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (526, 20, N'Góc độ ánh sáng', N'60 độ')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (527, 20, N'Trọng lượng', N'7g')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (528, 21, N'Công suất', N'3W')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (529, 21, N'Dòng điện', N'<700mA')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (530, 21, N'Điện áp', N'3.2 – 3.4V')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (531, 21, N'Loại led', N'Chip Wafer')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (532, 21, N'Ánh sáng', N'màu trắng chân thật')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (533, 21, N'Nhiệt độ màu', N'6000 – 6500K')
INSERT [dbo].[CHI_TIET_SAN_PHAM] ([ID], [SAN_PHAM_ID], [TIEU_DE], [NOI_DUNG]) VALUES (534, 21, N'Trọng lượng', N'~ 1g')
SET IDENTITY_INSERT [dbo].[CHI_TIET_SAN_PHAM] OFF
GO
SET IDENTITY_INSERT [dbo].[DON_HANG] ON 

INSERT [dbo].[DON_HANG] ([ID], [TEN_TAI_KHOAN], [NGAY_DAT_HANG], [TONG_SAN_PHAM], [TONG_TIEN], [TRANG_THAI], [NGAY_DUYET], [NGAY_HUY]) VALUES (2, N'huunam66', CAST(N'2023-12-10' AS Date), 1, CAST(100000.00 AS Decimal(15, 2)), N'Đã hủy', NULL, CAST(N'2023-12-10' AS Date))
INSERT [dbo].[DON_HANG] ([ID], [TEN_TAI_KHOAN], [NGAY_DAT_HANG], [TONG_SAN_PHAM], [TONG_TIEN], [TRANG_THAI], [NGAY_DUYET], [NGAY_HUY]) VALUES (3, N'huunam66', CAST(N'2023-12-10' AS Date), 1, CAST(100000.00 AS Decimal(15, 2)), N'Đã duyệt', CAST(N'2023-12-10' AS Date), NULL)
INSERT [dbo].[DON_HANG] ([ID], [TEN_TAI_KHOAN], [NGAY_DAT_HANG], [TONG_SAN_PHAM], [TONG_TIEN], [TRANG_THAI], [NGAY_DUYET], [NGAY_HUY]) VALUES (4, N'huunam66', CAST(N'2023-12-10' AS Date), 4, CAST(450000.00 AS Decimal(15, 2)), N'Đang duyệt', NULL, NULL)
SET IDENTITY_INSERT [dbo].[DON_HANG] OFF
GO
SET IDENTITY_INSERT [dbo].[GIO_HANG] ON 

INSERT [dbo].[GIO_HANG] ([ID], [TEN_TAI_KHOAN], [SAN_PHAM_ID], [SO_LUONG]) VALUES (1, N'admin', 17, 1)
SET IDENTITY_INSERT [dbo].[GIO_HANG] OFF
GO
SET IDENTITY_INSERT [dbo].[HINH_ANH] ON 

INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (1, 1, N'arduino-uno-r3-dip-b1hz-5-600x600.jpg', N'mach')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (2, 1, N'arduino-uno-r3-lgt8f328p-smd-chip-dan-kem-cap-5b4c-1-600x600.jpg', N'mach')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (3, 1, N'arduino-uno-r3-lgt8f328p-smd-chip-dan-kem-cap-5b4c-2-600x600.jpg', N'mach')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (4, 1, N'arduino-uno-r3-lgt8f328p-smd-chip-dan-kem-cap-5b4c-3-600x600.jpg', N'mach')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (5, 1, N'arduino-uno-r3-lgt8f328p-smd-chip-dan-kem-cap-5b4c-4-600x600.jpg', N'mach')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (6, 2, N'arduino-nano-3-0-lgt8f328p-TZB3-2020-600x600.jpg', N'mach')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (7, 2, N'arduino-promini-lgt328p-ssop20-55xw-2-600x600.jpg', N'mach')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (8, 2, N'arduino-promini-lgt328p-ssop20-55xw-3-600x600.jpg', N'mach')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (9, 3, N'arduino-uno-r3-dip-1-b1hz-3-600x600.jpg', N'mach')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (10, 3, N'arduino-uno-r3-dip-1-b1hz-2-600x600.jpg', N'mach')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (11, 3, N'arduino-uno-r3-dip-1-b1hz-5-600x600.jpg', N'mach')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (12, 3, N'arduino-uno-r3-dip-b1hz-2-600x600.jpg', N'mach')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (13, 4, N'arduino-uno-r3-lgt8f328p-smd-chip-dan-kem-cap-5b4c-6-600x600.jpg', N'mach')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (14, 4, N'arduino-uno-r3-lgt8f328p-smd-chip-dan-kem-cap-5b4c-5-600x600.jpg', N'mach')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (23, 8, N'cam-bien-khi-de-chay-mp-4-od7d-1-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (24, 8, N'cam-bien-khi-de-chay-mp-4-od7d-2-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (25, 8, N'cam-bien-khi-de-chay-mp-4-od7d-3-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (26, 9, N'cam-bien-phan-xa-hong-ngoai-e3f-r2c1-npn-3T3K-2020-0-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (27, 9, N'cam-bien-phan-xa-hong-ngoai-e3f-r2c1-npn-3T3K-2020-3-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (28, 9, N'cam-bien-phan-xa-hong-ngoai-e3f-r2c1-npn-3T3K-2020-4-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (29, 9, N'cam-bien-phan-xa-hong-ngoai-e3f-r2c1-npn-3T3K-2020-5-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (30, 10, N'cam-bien-phat-hien-kim-loai-tiem-can-lj12a3-zmo6-1-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (31, 10, N'cam-bien-phat-hien-kim-loai-tiem-can-lj12a3-zmo6-2-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (32, 10, N'cam-bien-phat-hien-kim-loai-tiem-can-lj12a3-zmo6-5-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (33, 11, N'cam-bien-tiem-can-kim-loai-fotek-pm12-04n-chinh-hang-hk11-1-600x600.jpg', N'mach')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (34, 11, N'cam-bien-tiem-can-kim-loai-fotek-pm12-04n-chinh-hang-hk11-2-600x600.jpg', N'mach')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (35, 11, N'cam-bien-tiem-can-kim-loai-fotek-pm12-04n-chinh-hang-hk11-3-600x600.jpg', N'mach')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (36, 12, N'cam-bien-tiem-can-roko-sn04-n-npn-chinh-hang-qe1h-1-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (37, 12, N'cam-bien-tiem-can-roko-sn04-n-npn-chinh-hang-qe1h-2-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (38, 12, N'cam-bien-tiem-can-roko-sn04-n-npn-chinh-hang-qe1h-3-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (39, 13, N'de-cam-bien-hien-dien-con-nguoi-ld2410-5vdc-10a-chvx-1-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (40, 13, N'de-cam-bien-hien-dien-con-nguoi-ld2410-5vdc-10a-chvx-3-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (41, 14, N'de-cam-bien-mua-tzpn-1-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (42, 14, N'de-cam-bien-mua-tzpn-2-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (43, 15, N'tren-tay-cam-bien-tiem-can-kim-loai-220v-2-day-dawei-l9k3-6kjo-1-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (44, 16, N'cam-bien-hong-ngoai-vat-can-bkf-ds30c4-npn-6-36v-7-60cm-ggk7-2-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (45, 17, N'tren-tay-de-cam-bien-hien-dien-con-nguoi-ld2410-5vdc-10a-chvx-1-600x600.jpg', N'cambien')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (46, 18, N'bo-thau-kinh-choa-den-led-5w-3w-1w-voi-khung-do-phang-stk2-y38f-ki4b-tmeg-p8rh-yios-upiu-8-600x600.jpg', N'led')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (47, 19, N'chip-led-10w-60-do-6000-6500k-anh-sang-trang-ux8h-1-600x600.jpg', N'led')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (48, 19, N'chip-led-10w-60-do-6000-6500k-anh-sang-trang-ux8h-2-600x600.jpg', N'led')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (49, 19, N'chip-led-10w-60-do-6000-6500k-anh-sang-trang-ux8h-3-600x600.jpg', N'led')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (50, 20, N'chip-led-sieu-sang-6000-6500k-gou9-f0pn-5-600x600.jpg', N'led')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (51, 21, N'led-sieu-sang-3w-anh-sang-do-1c6l-1-600x600.jpg', N'led')
INSERT [dbo].[HINH_ANH] ([ID], [SAN_PHAM_ID], [TEN_FILE], [THU_MUC]) VALUES (52, 21, N'led-sieu-sang-3w-anh-sang-do-1c6l-2-600x600.jpg', N'led')
SET IDENTITY_INSERT [dbo].[HINH_ANH] OFF
GO
SET IDENTITY_INSERT [dbo].[LOAI_SAN_PHAM] ON 

INSERT [dbo].[LOAI_SAN_PHAM] ([ID], [TEN]) VALUES (1, N'Mạch (Board)')
INSERT [dbo].[LOAI_SAN_PHAM] ([ID], [TEN]) VALUES (2, N'Cảm biến')
INSERT [dbo].[LOAI_SAN_PHAM] ([ID], [TEN]) VALUES (3, N'Đèn LED, Điều khiển LED')
INSERT [dbo].[LOAI_SAN_PHAM] ([ID], [TEN]) VALUES (4, N'Điện dân dụng')
SET IDENTITY_INSERT [dbo].[LOAI_SAN_PHAM] OFF
GO
SET IDENTITY_INSERT [dbo].[SAN_PHAM] ON 

INSERT [dbo].[SAN_PHAM] ([ID], [TEN], [GIA], [MAU], [MA_PHAN_LOAI], [SO_LUONG], [TRANG_THAI], [LOAI_SP_ID]) VALUES (1, N'Board Arduino Nano 3.0 ATmega328P Type-C', CAST(100000.00 AS Decimal(12, 2)), N'Nano 3.0', N'ATmega328P', 100, N'Còn hàng', 1)
INSERT [dbo].[SAN_PHAM] ([ID], [TEN], [GIA], [MAU], [MA_PHAN_LOAI], [SO_LUONG], [TRANG_THAI], [LOAI_SP_ID]) VALUES (2, N'Arduino UNO R3 LGT8F328P SMD chip dán (kèm cáp)', CAST(140000.00 AS Decimal(12, 2)), N'R3', N'LGT8F328P', 100, N'Còn hàng', 1)
INSERT [dbo].[SAN_PHAM] ([ID], [TEN], [GIA], [MAU], [MA_PHAN_LOAI], [SO_LUONG], [TRANG_THAI], [LOAI_SP_ID]) VALUES (3, N'Arduino UNO R3 DIP Kèm cáp', CAST(100000.00 AS Decimal(12, 2)), N'R3', N'UNO', 100, N'Còn hàng', 1)
INSERT [dbo].[SAN_PHAM] ([ID], [TEN], [GIA], [MAU], [MA_PHAN_LOAI], [SO_LUONG], [TRANG_THAI], [LOAI_SP_ID]) VALUES (4, N'Board Arduino Nano V3.1 LGT8F328P', CAST(10000.00 AS Decimal(12, 2)), N'V3.1', N'LGT8F328P', 100, N'Còn hàng', 1)
INSERT [dbo].[SAN_PHAM] ([ID], [TEN], [GIA], [MAU], [MA_PHAN_LOAI], [SO_LUONG], [TRANG_THAI], [LOAI_SP_ID]) VALUES (8, N'Cảm biến hồng ngoại vật cản BKF-DS30C4 NPN 6-36V 7-60cm', CAST(210000.00 AS Decimal(12, 2)), N'', N'BKF-DS30C4', 78, N'Còn hàng', 2)
INSERT [dbo].[SAN_PHAM] ([ID], [TEN], [GIA], [MAU], [MA_PHAN_LOAI], [SO_LUONG], [TRANG_THAI], [LOAI_SP_ID]) VALUES (9, N'Cảm biến tiệm cận kim loại 220V 2 dây Dawei LJ12A3-4-J/EZ NO 4mm', CAST(54000.00 AS Decimal(12, 2)), N'220V', N'LJ12A3-4-J/EZ', 25, N'Còn hàng', 2)
INSERT [dbo].[SAN_PHAM] ([ID], [TEN], [GIA], [MAU], [MA_PHAN_LOAI], [SO_LUONG], [TRANG_THAI], [LOAI_SP_ID]) VALUES (10, N'Cảm biến tiệm cận kim loại 220V 2 dây Dawei LJ18A3-8-J/EZ NO 8mm', CAST(68000.00 AS Decimal(12, 2)), N'220V', N'Dawei', 26, N'Còn hàng', 2)
INSERT [dbo].[SAN_PHAM] ([ID], [TEN], [GIA], [MAU], [MA_PHAN_LOAI], [SO_LUONG], [TRANG_THAI], [LOAI_SP_ID]) VALUES (11, N'Đế Ra Chân Arduino Nano v3', CAST(25000.00 AS Decimal(12, 2)), N'', N'', 100, N'Còn hàng', 1)
INSERT [dbo].[SAN_PHAM] ([ID], [TEN], [GIA], [MAU], [MA_PHAN_LOAI], [SO_LUONG], [TRANG_THAI], [LOAI_SP_ID]) VALUES (12, N'Cảm Biến Mưa một bộ', CAST(13000.00 AS Decimal(12, 2)), N'', N'', 120, N'Còn hàng', 2)
INSERT [dbo].[SAN_PHAM] ([ID], [TEN], [GIA], [MAU], [MA_PHAN_LOAI], [SO_LUONG], [TRANG_THAI], [LOAI_SP_ID]) VALUES (13, N'Đế cảm biến hiện diện con người LD2410 5VDC 10A', CAST(25000.00 AS Decimal(12, 2)), N'', N'', 128, N'Còn hàng', 2)
INSERT [dbo].[SAN_PHAM] ([ID], [TEN], [GIA], [MAU], [MA_PHAN_LOAI], [SO_LUONG], [TRANG_THAI], [LOAI_SP_ID]) VALUES (14, N'Cảm biến tiệm cận kim loại FOTEK PM12-04N Chính hãng', CAST(180000.00 AS Decimal(12, 2)), N'', N'', 60, N'Còn hàng', 2)
INSERT [dbo].[SAN_PHAM] ([ID], [TEN], [GIA], [MAU], [MA_PHAN_LOAI], [SO_LUONG], [TRANG_THAI], [LOAI_SP_ID]) VALUES (15, N'Cảm biến tiệm cận ROKO SN04-N NPN chính hãng', CAST(89000.00 AS Decimal(12, 2)), N'', N'', 77, N'Còn hàng', 2)
INSERT [dbo].[SAN_PHAM] ([ID], [TEN], [GIA], [MAU], [MA_PHAN_LOAI], [SO_LUONG], [TRANG_THAI], [LOAI_SP_ID]) VALUES (16, N'Cảm biến khí dễ cháy MP-4', CAST(110000.00 AS Decimal(12, 2)), N'', N'', 54, N'Còn hàng', 2)
INSERT [dbo].[SAN_PHAM] ([ID], [TEN], [GIA], [MAU], [MA_PHAN_LOAI], [SO_LUONG], [TRANG_THAI], [LOAI_SP_ID]) VALUES (17, N'Cảm biến vật cản gương phản xạ hồng ngoại E3F-R2C1 NPN', CAST(104000.00 AS Decimal(12, 2)), N'', N'', 122, N'Còn hàng', 2)
INSERT [dbo].[SAN_PHAM] ([ID], [TEN], [GIA], [MAU], [MA_PHAN_LOAI], [SO_LUONG], [TRANG_THAI], [LOAI_SP_ID]) VALUES (18, N'Led siêu sáng 3W ánh sáng đỏ / trắng ấm / xanh dương trắng sáng', CAST(10000.00 AS Decimal(12, 2)), N'', N'', 100, N'Còn hàng', 3)
INSERT [dbo].[SAN_PHAM] ([ID], [TEN], [GIA], [MAU], [MA_PHAN_LOAI], [SO_LUONG], [TRANG_THAI], [LOAI_SP_ID]) VALUES (19, N'Chip Led Đài Loan Epistar 33mil 4000-4500K 20W', CAST(24000.00 AS Decimal(12, 2)), N'', N'', 233, N'Còn hàng', 3)
INSERT [dbo].[SAN_PHAM] ([ID], [TEN], [GIA], [MAU], [MA_PHAN_LOAI], [SO_LUONG], [TRANG_THAI], [LOAI_SP_ID]) VALUES (20, N'Chip Led 10W ánh sáng trắng 6000 - 6500K 60 độ', CAST(70000.00 AS Decimal(12, 2)), N'', N'', 122, N'Còn hàng', 3)
INSERT [dbo].[SAN_PHAM] ([ID], [TEN], [GIA], [MAU], [MA_PHAN_LOAI], [SO_LUONG], [TRANG_THAI], [LOAI_SP_ID]) VALUES (21, N'Chip Led siêu sáng 6000 - 6500K 3W', CAST(6000.00 AS Decimal(12, 2)), N'', N'', 122, N'Còn hàng', 3)
SET IDENTITY_INSERT [dbo].[SAN_PHAM] OFF
GO
INSERT [dbo].[TAI_KHOAN] ([TEN_TAI_KHOAN], [MAT_KHAU], [QUYEN_HAN], [EMAIL]) VALUES (N'admin', N'123', N'admin', N'admin@gmail.com')
INSERT [dbo].[TAI_KHOAN] ([TEN_TAI_KHOAN], [MAT_KHAU], [QUYEN_HAN], [EMAIL]) VALUES (N'huunam66', N'123', N'user', N'nguyen.hnam2024@gmail.com')
INSERT [dbo].[TAI_KHOAN] ([TEN_TAI_KHOAN], [MAT_KHAU], [QUYEN_HAN], [EMAIL]) VALUES (N'huunam66123123', N'123', N'user', N'nguyen.hnam2012224@gmail.com')
INSERT [dbo].[TAI_KHOAN] ([TEN_TAI_KHOAN], [MAT_KHAU], [QUYEN_HAN], [EMAIL]) VALUES (N'tungne', N'123', N'user', N'letung@gmail.com')
GO
INSERT [dbo].[THONG_TIN_DON_HANG] ([ID], [TEN], [HO], [SDT], [GIOI_TINH], [DIA_CHI], [PHUONG_XA], [QUAN_HUYEN], [TINH_THANH]) VALUES (2, N'Hữu Nam', N'Nguyễn', N'+84909932013', N'Nam', N'1241f  gwgewr13412', N'Xã Xuân Lai', N'Huyện Gia Bình', N'Tỉnh Bắc Ninh')
INSERT [dbo].[THONG_TIN_DON_HANG] ([ID], [TEN], [HO], [SDT], [GIOI_TINH], [DIA_CHI], [PHUONG_XA], [QUAN_HUYEN], [TINH_THANH]) VALUES (3, N'Hữu Nam', N'Nguyễn', N'+84909932013', N'Nam', N'1241f  gwgewr13412', N'Phường Nam Sơn', N'Thành phố Bắc Ninh', N'Tỉnh Bắc Ninh')
INSERT [dbo].[THONG_TIN_DON_HANG] ([ID], [TEN], [HO], [SDT], [GIOI_TINH], [DIA_CHI], [PHUONG_XA], [QUAN_HUYEN], [TINH_THANH]) VALUES (4, N'Hữu Nam', N'Nguyễn', N'+84909932013', N'Nam', N'1241f  gwgewr13412', N'Xã Ngũ Thái', N'Thị xã Thuận Thành', N'Tỉnh Bắc Ninh')
GO
SET IDENTITY_INSERT [dbo].[THONG_TIN_TAI_KHOAN] ON 

INSERT [dbo].[THONG_TIN_TAI_KHOAN] ([ID], [TEN_TAI_KHOAN], [TEN], [HO], [SDT], [GIOI_TINH], [DIA_CHI], [PHUONG_XA], [QUAN_HUYEN], [TINH_THANH], [ANH_DAI_DIEN]) VALUES (2, N'huunam66', N'Hữu Nam', N'Nguyễn', N'0909932013', N'Nam', N'49/4', N'Phường Hiệp Thành', N'Quận 12', N'Thành phố Hồ Chí Minh', N'avt.jpg')
INSERT [dbo].[THONG_TIN_TAI_KHOAN] ([ID], [TEN_TAI_KHOAN], [TEN], [HO], [SDT], [GIOI_TINH], [DIA_CHI], [PHUONG_XA], [QUAN_HUYEN], [TINH_THANH], [ANH_DAI_DIEN]) VALUES (3, N'tungne', N'le', N'tung', N'123213213', N'Nam', N'dsadsadsa', N'Thị trấn Thanh Thủy', N'Huyện Thanh Thuỷ', N'Tỉnh Phú Thọ', NULL)
SET IDENTITY_INSERT [dbo].[THONG_TIN_TAI_KHOAN] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_SANPHAM_TEN]    Script Date: 12/10/2023 8:54:31 PM ******/
ALTER TABLE [dbo].[SAN_PHAM] ADD  CONSTRAINT [UQ_SANPHAM_TEN] UNIQUE NONCLUSTERED 
(
	[TEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TAI_KHOAN__EMAIL]    Script Date: 12/10/2023 8:54:31 PM ******/
ALTER TABLE [dbo].[TAI_KHOAN] ADD  CONSTRAINT [UQ__TAI_KHOAN__EMAIL] UNIQUE NONCLUSTERED 
(
	[EMAIL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CHI_TIET_DON_HANG]  WITH CHECK ADD  CONSTRAINT [FK__CHI_TIET_DON_HANG__DON_HANG_ID] FOREIGN KEY([DON_HANG_ID])
REFERENCES [dbo].[DON_HANG] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CHI_TIET_DON_HANG] CHECK CONSTRAINT [FK__CHI_TIET_DON_HANG__DON_HANG_ID]
GO
ALTER TABLE [dbo].[CHI_TIET_DON_HANG]  WITH CHECK ADD  CONSTRAINT [FK__CHI_TIET_DON_HANG__SAN_PHAM_ID] FOREIGN KEY([SAN_PHAM_ID])
REFERENCES [dbo].[SAN_PHAM] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CHI_TIET_DON_HANG] CHECK CONSTRAINT [FK__CHI_TIET_DON_HANG__SAN_PHAM_ID]
GO
ALTER TABLE [dbo].[CHI_TIET_SAN_PHAM]  WITH CHECK ADD  CONSTRAINT [FK__CHI_TIET_SAN_PHAM__ID_PRODUCT] FOREIGN KEY([SAN_PHAM_ID])
REFERENCES [dbo].[SAN_PHAM] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CHI_TIET_SAN_PHAM] CHECK CONSTRAINT [FK__CHI_TIET_SAN_PHAM__ID_PRODUCT]
GO
ALTER TABLE [dbo].[DON_HANG]  WITH CHECK ADD  CONSTRAINT [FK__DON_HANG__TEN_TAI_KHOAN] FOREIGN KEY([TEN_TAI_KHOAN])
REFERENCES [dbo].[TAI_KHOAN] ([TEN_TAI_KHOAN])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[DON_HANG] CHECK CONSTRAINT [FK__DON_HANG__TEN_TAI_KHOAN]
GO
ALTER TABLE [dbo].[GIO_HANG]  WITH CHECK ADD  CONSTRAINT [FK__GIO_HANG__SAN_PHAM_ID] FOREIGN KEY([SAN_PHAM_ID])
REFERENCES [dbo].[SAN_PHAM] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GIO_HANG] CHECK CONSTRAINT [FK__GIO_HANG__SAN_PHAM_ID]
GO
ALTER TABLE [dbo].[GIO_HANG]  WITH CHECK ADD  CONSTRAINT [FK__GIO_HANG__TEN_TAI_KHOAN] FOREIGN KEY([TEN_TAI_KHOAN])
REFERENCES [dbo].[TAI_KHOAN] ([TEN_TAI_KHOAN])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GIO_HANG] CHECK CONSTRAINT [FK__GIO_HANG__TEN_TAI_KHOAN]
GO
ALTER TABLE [dbo].[HINH_ANH]  WITH CHECK ADD  CONSTRAINT [FK_HINH_ANH_SAN_PHAM_ID] FOREIGN KEY([SAN_PHAM_ID])
REFERENCES [dbo].[SAN_PHAM] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HINH_ANH] CHECK CONSTRAINT [FK_HINH_ANH_SAN_PHAM_ID]
GO
ALTER TABLE [dbo].[SAN_PHAM]  WITH CHECK ADD  CONSTRAINT [FK__SANPHAM__ID_Type] FOREIGN KEY([LOAI_SP_ID])
REFERENCES [dbo].[LOAI_SAN_PHAM] ([ID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[SAN_PHAM] CHECK CONSTRAINT [FK__SANPHAM__ID_Type]
GO
ALTER TABLE [dbo].[THONG_TIN_DON_HANG]  WITH CHECK ADD  CONSTRAINT [FK__THONG_TIN_DON_HANG__ID] FOREIGN KEY([ID])
REFERENCES [dbo].[DON_HANG] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[THONG_TIN_DON_HANG] CHECK CONSTRAINT [FK__THONG_TIN_DON_HANG__ID]
GO
ALTER TABLE [dbo].[THONG_TIN_TAI_KHOAN]  WITH CHECK ADD  CONSTRAINT [FK__THONG_TIN_TAI_KHOAN__TEN_TAI_KHOAN] FOREIGN KEY([TEN_TAI_KHOAN])
REFERENCES [dbo].[TAI_KHOAN] ([TEN_TAI_KHOAN])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[THONG_TIN_TAI_KHOAN] CHECK CONSTRAINT [FK__THONG_TIN_TAI_KHOAN__TEN_TAI_KHOAN]
GO
