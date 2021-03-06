-- Script Date: 1/11/2021 10:42 AM  - ErikEJ.SqlCeScripting version 3.5.2.86
-- Database information:
-- Locale Identifier: 1033
-- Encryption Mode: 
-- Case Sensitive: False
-- Database: C:\Users\Tanya\Desktop\iClothing\DB\iClothing.sdf
-- ServerVersion: 4.0.8876.1
-- DatabaseSize: 512 KB
-- SpaceAvailable: 3.999 GB
-- Created: 1/5/2021 11:18 AM

-- User Table information:
-- Number of tables: 11
-- ART: 487 row(s)
-- Color: 4 row(s)
-- Customer: 2 row(s)
-- Order: 0 row(s)
-- Product: 303 row(s)
-- Roles: 2 row(s)
-- Staff: 1 row(s)
-- Stock: 5 row(s)
-- Supplier: 2 row(s)
-- Transaction: 0 row(s)
-- Type: 4 row(s)

INSERT INTO [Type] ([LoaiID],[Ten],[Mieuta],[Ngaytao],[Ngaysua]) VALUES (
N'0000001',N'BTP Chưa in',NULL,{ts '2021-01-10 00:00:00.000'},{ts '2021-01-10 00:00:00.000'});
GO
INSERT INTO [Type] ([LoaiID],[Ten],[Mieuta],[Ngaytao],[Ngaysua]) VALUES (
N'0000002',N'BTP Đã in',NULL,{ts '2021-01-10 00:00:00.000'},{ts '2021-01-10 00:00:00.000'});
GO
INSERT INTO [Type] ([LoaiID],[Ten],[Mieuta],[Ngaytao],[Ngaysua]) VALUES (
N'0000003',N'Thành Phẩm ',NULL,{ts '2021-01-10 00:00:00.000'},{ts '2021-01-10 00:00:00.000'});
GO
INSERT INTO [Type] ([LoaiID],[Ten],[Mieuta],[Ngaytao],[Ngaysua]) VALUES (
N'000004',N'Sản phẩm lỗi',NULL,{ts '2021-01-10 00:00:00.000'},{ts '2021-01-10 00:00:00.000'});
GO
INSERT INTO [Supplier] ([NhaccID],[Ten],[Mota],[Diachi],[Sodt],[Email]) VALUES (
N'0000001',N'Xưởng 1',NULL,NULL,NULL,NULL);
GO
INSERT INTO [Supplier] ([NhaccID],[Ten],[Mota],[Diachi],[Sodt],[Email]) VALUES (
N'0000002',N'Xưởng 2',NULL,NULL,NULL,NULL);
GO
INSERT INTO [Roles] ([RoleID],[Ten],[Mota]) VALUES (
N'0000001',N'Admin',N'Admin');
GO
INSERT INTO [Roles] ([RoleID],[Ten],[Mota]) VALUES (
N'0000002',N'User',N'User');
GO
INSERT INTO [Staff] ([NhanvienID],[RoleID],[Matkhau],[Ten],[Ho],[Diachi],[Sodt],[Tendangnhap]) VALUES (
N'0000001',N'0000001',N'123456',N'Ly',N'Truong',NULL,NULL,N'ly.truong');
GO
INSERT INTO [Customer] ([Ngaytao],[KHID],[HoTen],[Diachi],[Sodt],[Email]) VALUES (
{ts '2021-01-10 00:00:00.000'},N'000001',N'Nguyen Thao',N'423 Hai Phong',N'0922323761',N'thao@gmail.com');
GO
INSERT INTO [Customer] ([Ngaytao],[KHID],[HoTen],[Diachi],[Sodt],[Email]) VALUES (
{ts '2021-01-10 00:00:00.000'},N'000002',N'Truong Ly',N'947/11 Ngo Quyen',N'0905666770',N'lytruong.dn@gmail.com');
GO
INSERT INTO [Color] ([SonID],[Ten],[Mieuta],[Ngaytao],[Ngaysua]) VALUES (
N'000000',N'Không In',N'',{ts '2021-08-01 05:13:20.000'},{ts '2021-08-01 05:13:20.000'});
GO
INSERT INTO [Color] ([SonID],[Ten],[Mieuta],[Ngaytao],[Ngaysua]) VALUES (
N'000001',N'BAC',N'',{ts '2021-07-01 03:02:03.000'},{ts '2021-07-01 03:02:03.000'});
GO
INSERT INTO [Color] ([SonID],[Ten],[Mieuta],[Ngaytao],[Ngaysua]) VALUES (
N'000002',N'GOLD',N'',{ts '2021-07-01 03:01:11.000'},{ts '2021-07-01 03:01:11.000'});
GO
INSERT INTO [Color] ([SonID],[Ten],[Mieuta],[Ngaytao],[Ngaysua]) VALUES (
N'000003',N'TRẮNG',N'Mau trang',{ts '2021-08-01 05:08:51.000'},{ts '2021-08-01 05:08:51.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'00397241',N'0336',N'',NULL,{ts '2021-10-01 02:48:07.000'},{ts '2021-10-01 02:48:07.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'00558988',N'0327',N'',NULL,{ts '2021-10-01 02:48:12.000'},{ts '2021-10-01 02:48:12.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'00590452',N'0860',N'',NULL,{ts '2021-10-01 02:48:24.000'},{ts '2021-10-01 02:48:24.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'00641189',N'0333',N'',NULL,{ts '2021-10-01 02:48:29.000'},{ts '2021-10-01 02:48:29.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'01319239',N'0631',N'',NULL,{ts '2021-10-01 02:48:20.000'},{ts '2021-10-01 02:48:20.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'01360288',N'0629',N'',NULL,{ts '2021-10-01 02:48:32.000'},{ts '2021-10-01 02:48:32.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'01424477',N'0640',N'',NULL,{ts '2021-10-01 02:48:13.000'},{ts '2021-10-01 02:48:13.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'01676114',N'0737',N'',NULL,{ts '2021-10-01 02:48:17.000'},{ts '2021-10-01 02:48:17.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'02012977',N'0333',N'',NULL,{ts '2021-10-01 02:48:08.000'},{ts '2021-10-01 02:48:08.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'02050989',N'0865',N'',NULL,{ts '2021-10-01 02:48:45.000'},{ts '2021-10-01 02:48:45.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'02086264',N'0604',N'',NULL,{ts '2021-10-01 02:48:27.000'},{ts '2021-10-01 02:48:27.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'02199965',N'0332',N'',NULL,{ts '2021-10-01 02:48:28.000'},{ts '2021-10-01 02:48:28.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'02710389',N'0572',N'',NULL,{ts '2021-10-01 02:48:30.000'},{ts '2021-10-01 02:48:30.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'02926215',N'0712',N'',NULL,{ts '2021-10-01 02:48:15.000'},{ts '2021-10-01 02:48:15.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'03024080',N'0700',N'',NULL,{ts '2021-10-01 02:48:16.000'},{ts '2021-10-01 02:48:16.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'03271489',N'0650',N'',NULL,{ts '2021-10-01 02:48:14.000'},{ts '2021-10-01 02:48:14.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'03921388',N'0695',N'',NULL,{ts '2021-10-01 02:48:16.000'},{ts '2021-10-01 02:48:16.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'03995914',N'0638',N'',NULL,{ts '2021-10-01 02:48:33.000'},{ts '2021-10-01 02:48:33.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'04198615',N'0640',N'',NULL,{ts '2021-10-01 02:48:33.000'},{ts '2021-10-01 02:48:33.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'04203953',N'0611',N'',NULL,{ts '2021-10-01 02:48:26.000'},{ts '2021-10-01 02:48:26.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'04367141',N'0604',N'',NULL,{ts '2021-10-01 02:48:07.000'},{ts '2021-10-01 02:48:07.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'04464690',N'0604',N'',NULL,{ts '2021-10-01 02:48:31.000'},{ts '2021-10-01 02:48:31.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'04490203',N'0630',N'',NULL,{ts '2021-10-01 02:48:12.000'},{ts '2021-10-01 02:48:12.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'05125841',N'0450',N'',NULL,{ts '2021-10-01 02:48:39.000'},{ts '2021-10-01 02:48:39.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'05247977',N'0703',N'',NULL,{ts '2021-10-01 02:48:15.000'},{ts '2021-10-01 02:48:15.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'05433889',N'0628',N'',NULL,{ts '2021-10-01 02:48:32.000'},{ts '2021-10-01 02:48:32.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'06265103',N'0631',N'',NULL,{ts '2021-10-01 02:48:20.000'},{ts '2021-10-01 02:48:20.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'06307265',N'0887',N'',NULL,{ts '2021-10-01 02:48:25.000'},{ts '2021-10-01 02:48:25.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'06474353',N'0859',N'',NULL,{ts '2021-10-01 02:48:44.000'},{ts '2021-10-01 02:48:44.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'06620230',N'0738',N'',NULL,{ts '2021-10-01 02:48:17.000'},{ts '2021-10-01 02:48:17.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'06716992',N'0',N'',NULL,{ts '2021-10-01 02:48:10.000'},{ts '2021-10-01 02:48:10.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'06928688',N'0561',N'',NULL,{ts '2021-10-01 02:48:27.000'},{ts '2021-10-01 02:48:27.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'06996115',N'0705',N'',NULL,{ts '2021-10-01 02:48:15.000'},{ts '2021-10-01 02:48:15.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'07555255',N'0611',N'',NULL,{ts '2021-10-01 02:48:06.000'},{ts '2021-10-01 02:48:06.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'07862603',N'0690',N'',NULL,{ts '2021-10-01 02:48:16.000'},{ts '2021-10-01 02:48:16.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'07930601',N'0653',N'',NULL,{ts '2021-10-01 02:48:35.000'},{ts '2021-10-01 02:48:35.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'08026463',N'0336',N'',NULL,{ts '2021-10-01 02:48:28.000'},{ts '2021-10-01 02:48:28.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'08051067',N'0538',N'',NULL,{ts '2021-10-01 02:48:09.000'},{ts '2021-10-01 02:48:09.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'08158515',N'0638',N'',NULL,{ts '2021-10-01 02:48:33.000'},{ts '2021-10-01 02:48:33.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'08273853',N'0892',N'',NULL,{ts '2021-10-01 02:48:26.000'},{ts '2021-10-01 02:48:26.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'08581702',N'0770',N'',NULL,{ts '2021-10-01 02:48:19.000'},{ts '2021-10-01 02:48:19.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'09093530',N'0832',N'',NULL,{ts '2021-10-01 02:48:21.000'},{ts '2021-10-01 02:48:21.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'09301589',N'0653',N'',NULL,{ts '2021-10-01 02:48:14.000'},{ts '2021-10-01 02:48:14.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'09404790',N'0425',N'',NULL,{ts '2021-10-01 02:48:31.000'},{ts '2021-10-01 02:48:31.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'09555427',N'0688',N'',NULL,{ts '2021-10-01 02:48:36.000'},{ts '2021-10-01 02:48:36.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'09619616',N'0716',N'',NULL,{ts '2021-10-01 02:48:17.000'},{ts '2021-10-01 02:48:17.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'10579851',N'0430',N'',NULL,{ts '2021-10-01 02:48:41.000'},{ts '2021-10-01 02:48:41.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'10692677',N'0561',N'',NULL,{ts '2021-10-01 02:48:09.000'},{ts '2021-10-01 02:48:09.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'10917064',N'0611',N'',NULL,{ts '2021-10-01 02:48:26.000'},{ts '2021-10-01 02:48:26.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'10957015',N'0561',N'',NULL,{ts '2021-10-01 02:48:14.000'},{ts '2021-10-01 02:48:14.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'11938851',N'0608',N'',NULL,{ts '2021-10-01 02:48:08.000'},{ts '2021-10-01 02:48:08.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'12070903',N'0639',N'',NULL,{ts '2021-10-01 02:48:13.000'},{ts '2021-10-01 02:48:13.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'12233663',N'0887',N'',NULL,{ts '2021-10-01 02:48:25.000'},{ts '2021-10-01 02:48:25.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'12542602',N'0764',N'',NULL,{ts '2021-10-01 02:48:18.000'},{ts '2021-10-01 02:48:18.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'12818687',N'0689',N'',NULL,{ts '2021-10-01 02:48:15.000'},{ts '2021-10-01 02:48:15.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'12928737',N'0465',N'',NULL,{ts '2021-10-01 02:48:40.000'},{ts '2021-10-01 02:48:40.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'12950739',N'0494',N'',NULL,{ts '2021-10-01 02:48:20.000'},{ts '2021-10-01 02:48:20.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'13146641',N'0383',N'',NULL,{ts '2021-10-01 02:48:38.000'},{ts '2021-10-01 02:48:38.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'13351899',N'0583',N'',NULL,{ts '2021-10-01 02:48:30.000'},{ts '2021-10-01 02:48:30.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'13415187',N'0451',N'',NULL,{ts '2021-10-01 02:48:11.000'},{ts '2021-10-01 02:48:11.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'13515237',N'0707',N'',NULL,{ts '2021-10-01 02:48:35.000'},{ts '2021-10-01 02:48:35.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'13670526',N'0697',N'',NULL,{ts '2021-10-01 02:48:16.000'},{ts '2021-10-01 02:48:16.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'13952852',N'0607',N'',NULL,{ts '2021-10-01 02:48:28.000'},{ts '2021-10-01 02:48:28.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'14048514',N'0831',N'',NULL,{ts '2021-10-01 02:48:21.000'},{ts '2021-10-01 02:48:21.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'14601099',N'0609',N'',NULL,{ts '2021-10-01 02:48:28.000'},{ts '2021-10-01 02:48:28.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'14643463',N'0493',N'',NULL,{ts '2021-10-01 02:48:41.000'},{ts '2021-10-01 02:48:41.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'14894225',N'0631',N'',NULL,{ts '2021-10-01 02:48:41.000'},{ts '2021-10-01 02:48:41.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'14980087',N'0641',N'',NULL,{ts '2021-10-01 02:48:34.000'},{ts '2021-10-01 02:48:34.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'15012149',N'0',N'',NULL,{ts '2021-10-01 02:48:38.000'},{ts '2021-10-01 02:48:38.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'15177338',N'0462',N'',NULL,{ts '2021-10-01 02:48:19.000'},{ts '2021-10-01 02:48:19.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'15382675',N'0329',N'',NULL,{ts '2021-10-01 02:48:12.000'},{ts '2021-10-01 02:48:12.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'15481826',N'0691',N'',NULL,{ts '2021-10-01 02:48:36.000'},{ts '2021-10-01 02:48:36.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'15577588',N'0452',N'',NULL,{ts '2021-10-01 02:48:29.000'},{ts '2021-10-01 02:48:29.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'16082877',N'0609',N'',NULL,{ts '2021-10-01 02:48:08.000'},{ts '2021-10-01 02:48:08.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'16162402',N'0775',N'',NULL,{ts '2021-10-01 02:48:20.000'},{ts '2021-10-01 02:48:20.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'16519051',N'0829',N'',NULL,{ts '2021-10-01 02:48:42.000'},{ts '2021-10-01 02:48:42.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'16632776',N'0583',N'',NULL,{ts '2021-10-01 02:48:10.000'},{ts '2021-10-01 02:48:10.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'16957164',N'0582',N'',NULL,{ts '2021-10-01 02:48:27.000'},{ts '2021-10-01 02:48:27.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'16988637',N'0770',N'',NULL,{ts '2021-10-01 02:48:39.000'},{ts '2021-10-01 02:48:39.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'17077941',N'0330',N'',NULL,{ts '2021-10-01 02:48:08.000'},{ts '2021-10-01 02:48:08.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'17235037',N'0701',N'',NULL,{ts '2021-10-01 02:48:37.000'},{ts '2021-10-01 02:48:37.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'18328041',N'0561',N'',NULL,{ts '2021-10-01 02:48:06.000'},{ts '2021-10-01 02:48:06.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'18571201',N'0705',N'',NULL,{ts '2021-10-01 02:48:35.000'},{ts '2021-10-01 02:48:35.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'18589789',N'0426',N'',NULL,{ts '2021-10-01 02:48:11.000'},{ts '2021-10-01 02:48:11.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'18854126',N'0468',N'',NULL,{ts '2021-10-01 02:48:40.000'},{ts '2021-10-01 02:48:40.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'18940888',N'0638',N'',NULL,{ts '2021-10-01 02:48:33.000'},{ts '2021-10-01 02:48:33.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'18980839',N'0827',N'',NULL,{ts '2021-10-01 02:48:21.000'},{ts '2021-10-01 02:48:21.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'19137238',N'0343',N'',NULL,{ts '2021-10-01 02:48:19.000'},{ts '2021-10-01 02:48:19.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'19548488',N'0582',N'',NULL,{ts '2021-10-01 02:48:29.000'},{ts '2021-10-01 02:48:29.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'20077013',N'0561',N'',NULL,{ts '2021-10-01 02:48:38.000'},{ts '2021-10-01 02:48:38.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'20447709',N'0690',N'',NULL,{ts '2021-10-01 02:48:36.000'},{ts '2021-10-01 02:48:36.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'20634140',N'0836',N'',NULL,{ts '2021-10-01 02:48:22.000'},{ts '2021-10-01 02:48:22.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'20749388',N'0653',N'',NULL,{ts '2021-10-01 02:48:14.000'},{ts '2021-10-01 02:48:14.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'21034290',N'0451',N'',NULL,{ts '2021-10-01 02:48:32.000'},{ts '2021-10-01 02:48:32.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'21199488',N'0638',N'',NULL,{ts '2021-10-01 02:48:12.000'},{ts '2021-10-01 02:48:12.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'21533462',N'0383',N'',NULL,{ts '2021-10-01 02:48:29.000'},{ts '2021-10-01 02:48:29.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'21568165',N'0586',N'',NULL,{ts '2021-10-01 02:48:10.000'},{ts '2021-10-01 02:48:10.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'21665613',N'0644',N'',NULL,{ts '2021-10-01 02:48:34.000'},{ts '2021-10-01 02:48:34.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'21931598',N'0341',N'',NULL,{ts '2021-10-01 02:48:31.000'},{ts '2021-10-01 02:48:31.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'22166665',N'0610',N'',NULL,{ts '2021-10-01 02:48:06.000'},{ts '2021-10-01 02:48:06.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'22531102',N'0561',N'',NULL,{ts '2021-10-01 02:48:35.000'},{ts '2021-10-01 02:48:35.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'23158187',N'0571',N'',NULL,{ts '2021-10-01 02:48:30.000'},{ts '2021-10-01 02:48:30.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'23197138',N'0',N'',NULL,{ts '2021-10-01 02:48:18.000'},{ts '2021-10-01 02:48:18.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'23464013',N'0710',N'',NULL,{ts '2021-10-01 02:48:15.000'},{ts '2021-10-01 02:48:15.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'23627874',N'0331',N'',NULL,{ts '2021-10-01 02:48:28.000'},{ts '2021-10-01 02:48:28.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'23874263',N'0460',N'',NULL,{ts '2021-10-01 02:48:25.000'},{ts '2021-10-01 02:48:25.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'23901798',N'0329',N'',NULL,{ts '2021-10-01 02:48:32.000'},{ts '2021-10-01 02:48:32.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'23904349',N'0383',N'',NULL,{ts '2021-10-01 02:48:08.000'},{ts '2021-10-01 02:48:08.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'24183212',N'0',N'',NULL,{ts '2021-10-01 02:48:18.000'},{ts '2021-10-01 02:48:18.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'24407600',N'0713',N'',NULL,{ts '2021-10-01 02:48:36.000'},{ts '2021-10-01 02:48:36.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'24549752',N'0775',N'',NULL,{ts '2021-10-01 02:48:40.000'},{ts '2021-10-01 02:48:40.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'24562898',N'0699',N'',NULL,{ts '2021-10-01 02:48:16.000'},{ts '2021-10-01 02:48:16.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'24653577',N'0453',N'',NULL,{ts '2021-10-01 02:48:09.000'},{ts '2021-10-01 02:48:09.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'24877286',N'0639',N'',NULL,{ts '2021-10-01 02:48:33.000'},{ts '2021-10-01 02:48:33.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'25005100',N'0',N'',NULL,{ts '2021-10-01 02:48:31.000'},{ts '2021-10-01 02:48:31.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'25156837',N'0708',N'',NULL,{ts '2021-10-01 02:48:36.000'},{ts '2021-10-01 02:48:36.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'25435835',N'0788',N'',NULL,{ts '2021-10-01 02:48:41.000'},{ts '2021-10-01 02:48:41.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'25535414',N'0640',N'',NULL,{ts '2021-10-01 02:48:33.000'},{ts '2021-10-01 02:48:33.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'25593362',N'0582',N'',NULL,{ts '2021-10-01 02:48:29.000'},{ts '2021-10-01 02:48:29.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'25904412',N'0764',N'',NULL,{ts '2021-10-01 02:48:39.000'},{ts '2021-10-01 02:48:39.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'25908651',N'0331',N'',NULL,{ts '2021-10-01 02:48:07.000'},{ts '2021-10-01 02:48:07.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'26022336',N'0696',N'',NULL,{ts '2021-10-01 02:48:36.000'},{ts '2021-10-01 02:48:36.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'26059700',N'0464',N'',NULL,{ts '2021-10-01 02:48:19.000'},{ts '2021-10-01 02:48:19.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'26090274',N'0428',N'',NULL,{ts '2021-10-01 02:48:32.000'},{ts '2021-10-01 02:48:32.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'26187524',N'0441',N'',NULL,{ts '2021-10-01 02:48:17.000'},{ts '2021-10-01 02:48:17.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'26191862',N'0862',N'',NULL,{ts '2021-10-01 02:48:24.000'},{ts '2021-10-01 02:48:24.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'26502012',N'0650',N'',NULL,{ts '2021-10-01 02:48:34.000'},{ts '2021-10-01 02:48:34.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'26653649',N'0764',N'',NULL,{ts '2021-10-01 02:48:39.000'},{ts '2021-10-01 02:48:39.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'26811649',N'0775',N'',NULL,{ts '2021-10-01 02:48:20.000'},{ts '2021-10-01 02:48:20.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'26888487',N'0711',N'',NULL,{ts '2021-10-01 02:48:15.000'},{ts '2021-10-01 02:48:15.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'27026887',N'0638',N'',NULL,{ts '2021-10-01 02:48:12.000'},{ts '2021-10-01 02:48:12.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'27221799',N'0561',N'',NULL,{ts '2021-10-01 02:48:30.000'},{ts '2021-10-01 02:48:30.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'27289637',N'0887',N'',NULL,{ts '2021-10-01 02:48:25.000'},{ts '2021-10-01 02:48:25.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'27874249',N'0582',N'',NULL,{ts '2021-10-01 02:48:08.000'},{ts '2021-10-01 02:48:08.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'28093063',N'0611',N'',NULL,{ts '2021-10-01 02:48:06.000'},{ts '2021-10-01 02:48:06.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'28101525',N'0441',N'',NULL,{ts '2021-10-01 02:48:38.000'},{ts '2021-10-01 02:48:38.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'28623487',N'0582',N'',NULL,{ts '2021-10-01 02:48:08.000'},{ts '2021-10-01 02:48:08.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'28787137',N'0812',N'',NULL,{ts '2021-10-01 02:48:21.000'},{ts '2021-10-01 02:48:21.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'28806613',N'0493',N'',NULL,{ts '2021-10-01 02:48:20.000'},{ts '2021-10-01 02:48:20.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'29596324',N'0638',N'',NULL,{ts '2021-10-01 02:48:33.000'},{ts '2021-10-01 02:48:33.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'29599975',N'0506',N'',NULL,{ts '2021-10-01 02:48:09.000'},{ts '2021-10-01 02:48:09.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'29804363',N'0908',N'',NULL,{ts '2021-10-01 02:48:26.000'},{ts '2021-10-01 02:48:26.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'29873899',N'0629',N'',NULL,{ts '2021-10-01 02:48:14.000'},{ts '2021-10-01 02:48:14.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'29969552',N'0561',N'',NULL,{ts '2021-10-01 02:48:07.000'},{ts '2021-10-01 02:48:07.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'30029600',N'0764',N'',NULL,{ts '2021-10-01 02:48:19.000'},{ts '2021-10-01 02:48:19.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'30093236',N'0712',N'',NULL,{ts '2021-10-01 02:48:36.000'},{ts '2021-10-01 02:48:36.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'30147424',N'0715',N'',NULL,{ts '2021-10-01 02:48:17.000'},{ts '2021-10-01 02:48:17.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'30328647',N'0826',N'',NULL,{ts '2021-10-01 02:48:21.000'},{ts '2021-10-01 02:48:21.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'30584949',N'0570',N'',NULL,{ts '2021-10-01 02:48:09.000'},{ts '2021-10-01 02:48:09.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'30613559',N'0582',N'',NULL,{ts '2021-10-01 02:48:38.000'},{ts '2021-10-01 02:48:38.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'30742135',N'0737',N'',NULL,{ts '2021-10-01 02:48:38.000'},{ts '2021-10-01 02:48:38.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'30983086',N'0629',N'',NULL,{ts '2021-10-01 02:48:12.000'},{ts '2021-10-01 02:48:12.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'31086787',N'0429',N'',NULL,{ts '2021-10-01 02:48:12.000'},{ts '2021-10-01 02:48:12.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'31189998',N'0330',N'',NULL,{ts '2021-10-01 02:48:29.000'},{ts '2021-10-01 02:48:29.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'31361224',N'0812',N'',NULL,{ts '2021-10-01 02:48:41.000'},{ts '2021-10-01 02:48:41.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'31558674',N'0579',N'',NULL,{ts '2021-10-01 02:48:27.000'},{ts '2021-10-01 02:48:27.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'32013913',N'0736',N'',NULL,{ts '2021-10-01 02:48:17.000'},{ts '2021-10-01 02:48:17.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'32457986',N'0629',N'',NULL,{ts '2021-10-01 02:48:34.000'},{ts '2021-10-01 02:48:34.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'32589048',N'0',N'',NULL,{ts '2021-10-01 02:48:39.000'},{ts '2021-10-01 02:48:39.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'33048037',N'0611',N'',NULL,{ts '2021-10-01 02:48:06.000'},{ts '2021-10-01 02:48:06.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'33109675',N'0604',N'',NULL,{ts '2021-10-01 02:48:10.000'},{ts '2021-10-01 02:48:10.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'33424162',N'0561',N'',NULL,{ts '2021-10-01 02:48:27.000'},{ts '2021-10-01 02:48:27.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'33455636',N'0464',N'',NULL,{ts '2021-10-01 02:48:40.000'},{ts '2021-10-01 02:48:40.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'33732011',N'0430',N'',NULL,{ts '2021-10-01 02:48:20.000'},{ts '2021-10-01 02:48:20.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'34108325',N'0696',N'',NULL,{ts '2021-10-01 02:48:16.000'},{ts '2021-10-01 02:48:16.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'34459197',N'0694',N'',NULL,{ts '2021-10-01 02:48:16.000'},{ts '2021-10-01 02:48:16.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'34541398',N'0631',N'',NULL,{ts '2021-10-01 02:48:33.000'},{ts '2021-10-01 02:48:33.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'34545859',N'0506',N'',NULL,{ts '2021-10-01 02:48:09.000'},{ts '2021-10-01 02:48:09.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'34828873',N'0645',N'',NULL,{ts '2021-10-01 02:48:13.000'},{ts '2021-10-01 02:48:13.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'34929452',N'0505',N'',NULL,{ts '2021-10-01 02:48:06.000'},{ts '2021-10-01 02:48:06.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'34989401',N'0764',N'',NULL,{ts '2021-10-01 02:48:18.000'},{ts '2021-10-01 02:48:18.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'35056687',N'0628',N'',NULL,{ts '2021-10-01 02:48:11.000'},{ts '2021-10-01 02:48:11.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'35149898',N'0608',N'',NULL,{ts '2021-10-01 02:48:28.000'},{ts '2021-10-01 02:48:28.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'35486323',N'0830',N'',NULL,{ts '2021-10-01 02:48:21.000'},{ts '2021-10-01 02:48:21.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'35741761',N'0908',N'',NULL,{ts '2021-10-01 02:48:26.000'},{ts '2021-10-01 02:48:26.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'35992499',N'0603',N'',NULL,{ts '2021-10-01 02:48:31.000'},{ts '2021-10-01 02:48:31.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'36170362',N'0492',N'',NULL,{ts '2021-10-01 02:48:41.000'},{ts '2021-10-01 02:48:41.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'36418896',N'0640',N'',NULL,{ts '2021-10-01 02:48:34.000'},{ts '2021-10-01 02:48:34.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'36604237',N'0461',N'',NULL,{ts '2021-10-01 02:48:19.000'},{ts '2021-10-01 02:48:19.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'36897472',N'0340',N'',NULL,{ts '2021-10-01 02:48:31.000'},{ts '2021-10-01 02:48:31.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'37027409',N'0692',N'',NULL,{ts '2021-10-01 02:48:37.000'},{ts '2021-10-01 02:48:37.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'37086936',N'0860',N'',NULL,{ts '2021-10-01 02:48:25.000'},{ts '2021-10-01 02:48:25.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'37118098',N'0506',N'',NULL,{ts '2021-10-01 02:48:29.000'},{ts '2021-10-01 02:48:29.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'37150561',N'0833',N'',NULL,{ts '2021-10-01 02:48:42.000'},{ts '2021-10-01 02:48:42.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'37424914',N'0704',N'',NULL,{ts '2021-10-01 02:48:15.000'},{ts '2021-10-01 02:48:15.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'37426446',N'0764',N'',NULL,{ts '2021-10-01 02:48:39.000'},{ts '2021-10-01 02:48:39.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'37703912',N'0775',N'',NULL,{ts '2021-10-01 02:48:20.000'},{ts '2021-10-01 02:48:20.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'37835163',N'0469',N'',NULL,{ts '2021-10-01 02:48:25.000'},{ts '2021-10-01 02:48:25.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'38113161',N'0570',N'',NULL,{ts '2021-10-01 02:48:30.000'},{ts '2021-10-01 02:48:30.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'38153012',N'0561',N'',NULL,{ts '2021-10-01 02:48:18.000'},{ts '2021-10-01 02:48:18.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'38268350',N'0340',N'',NULL,{ts '2021-10-01 02:48:11.000'},{ts '2021-10-01 02:48:11.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'38429097',N'0709',N'',NULL,{ts '2021-10-01 02:48:15.000'},{ts '2021-10-01 02:48:15.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'38529247',N'0461',N'',NULL,{ts '2021-10-01 02:48:40.000'},{ts '2021-10-01 02:48:40.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'39495736',N'0775',N'',NULL,{ts '2021-10-01 02:48:40.000'},{ts '2021-10-01 02:48:40.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'39701662',N'0893',N'',NULL,{ts '2021-10-01 02:48:26.000'},{ts '2021-10-01 02:48:26.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'39917598',N'0425',N'',NULL,{ts '2021-10-01 02:48:11.000'},{ts '2021-10-01 02:48:11.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'39985436',N'0505',N'',NULL,{ts '2021-10-01 02:48:06.000'},{ts '2021-10-01 02:48:06.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'41130485',N'0561',N'',NULL,{ts '2021-10-01 02:48:09.000'},{ts '2021-10-01 02:48:09.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'41162959',N'0835',N'',NULL,{ts '2021-10-01 02:48:22.000'},{ts '2021-10-01 02:48:22.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'41505922',N'0561',N'',NULL,{ts '2021-10-01 02:48:38.000'},{ts '2021-10-01 02:48:38.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'41975508',N'0689',N'',NULL,{ts '2021-10-01 02:48:36.000'},{ts '2021-10-01 02:48:36.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'42003422',N'0643',N'',NULL,{ts '2021-10-01 02:48:34.000'},{ts '2021-10-01 02:48:34.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'42061260',N'0337',N'',NULL,{ts '2021-10-01 02:48:29.000'},{ts '2021-10-01 02:48:29.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'42125559',N'0573',N'',NULL,{ts '2021-10-01 02:48:10.000'},{ts '2021-10-01 02:48:10.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'42440947',N'0579',N'',NULL,{ts '2021-10-01 02:48:27.000'},{ts '2021-10-01 02:48:27.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'42471410',N'0328',N'',NULL,{ts '2021-10-01 02:48:39.000'},{ts '2021-10-01 02:48:39.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'42627397',N'0638',N'',NULL,{ts '2021-10-01 02:48:12.000'},{ts '2021-10-01 02:48:12.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'42788034',N'0719',N'',NULL,{ts '2021-10-01 02:48:17.000'},{ts '2021-10-01 02:48:17.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'43476650',N'0607',N'',NULL,{ts '2021-10-01 02:48:08.000'},{ts '2021-10-01 02:48:08.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'44448697',N'0338',N'',NULL,{ts '2021-10-01 02:48:32.000'},{ts '2021-10-01 02:48:32.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'44474200',N'0641',N'',NULL,{ts '2021-10-01 02:48:13.000'},{ts '2021-10-01 02:48:13.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'44603035',N'0719',N'',NULL,{ts '2021-10-01 02:48:37.000'},{ts '2021-10-01 02:48:37.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'44666545',N'0891',N'',NULL,{ts '2021-10-01 02:48:25.000'},{ts '2021-10-01 02:48:25.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'44725072',N'0641',N'',NULL,{ts '2021-10-01 02:48:13.000'},{ts '2021-10-01 02:48:13.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'44799797',N'0573',N'',NULL,{ts '2021-10-01 02:48:30.000'},{ts '2021-10-01 02:48:30.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'44811834',N'0579',N'',NULL,{ts '2021-10-01 02:48:06.000'},{ts '2021-10-01 02:48:06.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'44843986',N'0428',N'',NULL,{ts '2021-10-01 02:48:11.000'},{ts '2021-10-01 02:48:11.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'45048110',N'0710',N'',NULL,{ts '2021-10-01 02:48:36.000'},{ts '2021-10-01 02:48:36.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'45191385',N'0452',N'',NULL,{ts '2021-10-01 02:48:09.000'},{ts '2021-10-01 02:48:09.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'45373611',N'0825',N'',NULL,{ts '2021-10-01 02:48:21.000'},{ts '2021-10-01 02:48:21.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'45679523',N'0573',N'',NULL,{ts '2021-10-01 02:48:38.000'},{ts '2021-10-01 02:48:38.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'46103408',N'0692',N'',NULL,{ts '2021-10-01 02:48:16.000'},{ts '2021-10-01 02:48:16.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'46134872',N'Không in',N'',NULL,{ts '2021-10-01 02:48:29.000'},{ts '2021-10-01 02:48:29.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'46166024',N'0641',N'',NULL,{ts '2021-10-01 02:48:34.000'},{ts '2021-10-01 02:48:34.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'46340898',N'0657',N'',NULL,{ts '2021-10-01 02:48:14.000'},{ts '2021-10-01 02:48:14.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'46533909',N'0',N'',NULL,{ts '2021-10-01 02:48:31.000'},{ts '2021-10-01 02:48:31.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'46848060',N'0629',N'',NULL,{ts '2021-10-01 02:48:11.000'},{ts '2021-10-01 02:48:11.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'46983234',N'0864',N'',NULL,{ts '2021-10-01 02:48:24.000'},{ts '2021-10-01 02:48:24.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'47046850',N'0828',N'',NULL,{ts '2021-10-01 02:48:41.000'},{ts '2021-10-01 02:48:41.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'47079997',N'0735',N'',NULL,{ts '2021-10-01 02:48:17.000'},{ts '2021-10-01 02:48:17.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'47160575',N'0573',N'',NULL,{ts '2021-10-01 02:48:10.000'},{ts '2021-10-01 02:48:10.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'47216396',N'0707',N'',NULL,{ts '2021-10-01 02:48:15.000'},{ts '2021-10-01 02:48:15.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'47436550',N'0482',N'',NULL,{ts '2021-10-01 02:48:07.000'},{ts '2021-10-01 02:48:07.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'47545022',N'0',N'',NULL,{ts '2021-10-01 02:48:39.000'},{ts '2021-10-01 02:48:39.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'47690210',N'0468',N'',NULL,{ts '2021-10-01 02:48:20.000'},{ts '2021-10-01 02:48:20.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'47914608',N'0698',N'',NULL,{ts '2021-10-01 02:48:37.000'},{ts '2021-10-01 02:48:37.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'48000460',N'0539',N'',NULL,{ts '2021-10-01 02:48:30.000'},{ts '2021-10-01 02:48:30.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'48042833',N'0835',N'',NULL,{ts '2021-10-01 02:48:42.000'},{ts '2021-10-01 02:48:42.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'48132512',N'0655',N'',NULL,{ts '2021-10-01 02:48:34.000'},{ts '2021-10-01 02:48:34.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'48348448',N'0775',N'',NULL,{ts '2021-10-01 02:48:20.000'},{ts '2021-10-01 02:48:20.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'48415759',N'Không in',N'',NULL,{ts '2021-10-01 02:48:08.000'},{ts '2021-10-01 02:48:08.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'48627446',N'0887',N'',NULL,{ts '2021-10-01 02:48:25.000'},{ts '2021-10-01 02:48:25.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'48663836',N'0700',N'',NULL,{ts '2021-10-01 02:48:37.000'},{ts '2021-10-01 02:48:37.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'48759698',N'0561',N'',NULL,{ts '2021-10-01 02:48:30.000'},{ts '2021-10-01 02:48:30.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'49009010',N'0704',N'',NULL,{ts '2021-10-01 02:48:35.000'},{ts '2021-10-01 02:48:35.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'49539434',N'0540',N'',NULL,{ts '2021-10-01 02:48:38.000'},{ts '2021-10-01 02:48:38.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'49543672',N'0863',N'',NULL,{ts '2021-10-01 02:48:45.000'},{ts '2021-10-01 02:48:45.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'49790061',N'0582',N'',NULL,{ts '2021-10-01 02:48:42.000'},{ts '2021-10-01 02:48:42.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'50184272',N'0860',N'',NULL,{ts '2021-10-01 02:48:45.000'},{ts '2021-10-01 02:48:45.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'50342172',N'0906',N'',NULL,{ts '2021-10-01 02:48:26.000'},{ts '2021-10-01 02:48:26.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'50809960',N'0427',N'',NULL,{ts '2021-10-01 02:48:11.000'},{ts '2021-10-01 02:48:11.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'50933544',N'0775',N'',NULL,{ts '2021-10-01 02:48:40.000'},{ts '2021-10-01 02:48:40.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'51457419',N'0328',N'',NULL,{ts '2021-10-01 02:48:19.000'},{ts '2021-10-01 02:48:19.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'51496460',N'0561',N'',NULL,{ts '2021-10-01 02:48:06.000'},{ts '2021-10-01 02:48:06.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'51498983',N'0604',N'',NULL,{ts '2021-10-01 02:48:31.000'},{ts '2021-10-01 02:48:31.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'52086473',N'0505',N'',NULL,{ts '2021-10-01 02:48:27.000'},{ts '2021-10-01 02:48:27.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'52492434',N'0482',N'',NULL,{ts '2021-10-01 02:48:07.000'},{ts '2021-10-01 02:48:07.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'52771085',N'0571',N'',NULL,{ts '2021-10-01 02:48:09.000'},{ts '2021-10-01 02:48:09.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'52912858',N'0561',N'',NULL,{ts '2021-10-01 02:48:09.000'},{ts '2021-10-01 02:48:09.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'52954321',N'0582',N'',NULL,{ts '2021-10-01 02:48:22.000'},{ts '2021-10-01 02:48:22.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'53654523',N'0573',N'',NULL,{ts '2021-10-01 02:48:18.000'},{ts '2021-10-01 02:48:18.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'54065672',N'0482',N'',NULL,{ts '2021-10-01 02:48:28.000'},{ts '2021-10-01 02:48:28.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'54270910',N'0788',N'',NULL,{ts '2021-10-01 02:48:20.000'},{ts '2021-10-01 02:48:20.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'54595308',N'0653',N'',NULL,{ts '2021-10-01 02:48:37.000'},{ts '2021-10-01 02:48:37.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'54746045',N'0836',N'',NULL,{ts '2021-10-01 02:48:42.000'},{ts '2021-10-01 02:48:42.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'54952971',N'0561',N'',NULL,{ts '2021-10-01 02:48:27.000'},{ts '2021-10-01 02:48:27.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'55090697',N'0698',N'',NULL,{ts '2021-10-01 02:48:16.000'},{ts '2021-10-01 02:48:16.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'55302072',N'0887',N'',NULL,{ts '2021-10-01 02:48:25.000'},{ts '2021-10-01 02:48:25.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'55366672',N'0644',N'',NULL,{ts '2021-10-01 02:48:13.000'},{ts '2021-10-01 02:48:13.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'55520011',N'0',N'',NULL,{ts '2021-10-01 02:48:18.000'},{ts '2021-10-01 02:48:18.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'55897996',N'0693',N'',NULL,{ts '2021-10-01 02:48:16.000'},{ts '2021-10-01 02:48:16.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'56027923',N'0834',N'',NULL,{ts '2021-10-01 02:48:21.000'},{ts '2021-10-01 02:48:21.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'56063322',N'0639',N'',NULL,{ts '2021-10-01 02:48:33.000'},{ts '2021-10-01 02:48:33.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'56207145',N'0905',N'',NULL,{ts '2021-10-01 02:48:26.000'},{ts '2021-10-01 02:48:26.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'56330207',N'0586',N'',NULL,{ts '2021-10-01 02:48:31.000'},{ts '2021-10-01 02:48:31.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'56484596',N'0628',N'',NULL,{ts '2021-10-01 02:48:11.000'},{ts '2021-10-01 02:48:11.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'56931160',N'0582',N'',NULL,{ts '2021-10-01 02:48:28.000'},{ts '2021-10-01 02:48:28.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'57058396',N'0641',N'',NULL,{ts '2021-10-01 02:48:34.000'},{ts '2021-10-01 02:48:34.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'57191558',N'0764',N'',NULL,{ts '2021-10-01 02:48:39.000'},{ts '2021-10-01 02:48:39.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'57245747',N'0465',N'',NULL,{ts '2021-10-01 02:48:19.000'},{ts '2021-10-01 02:48:19.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'57428082',N'0427',N'',NULL,{ts '2021-10-01 02:48:32.000'},{ts '2021-10-01 02:48:32.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'57529761',N'0859',N'',NULL,{ts '2021-10-01 02:48:24.000'},{ts '2021-10-01 02:48:24.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'57560134',N'0695',N'',NULL,{ts '2021-10-01 02:48:36.000'},{ts '2021-10-01 02:48:36.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'57596519',N'0463',N'',NULL,{ts '2021-10-01 02:48:19.000'},{ts '2021-10-01 02:48:19.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'57615423',N'0540',N'',NULL,{ts '2021-10-01 02:48:17.000'},{ts '2021-10-01 02:48:17.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'57734908',N'0718',N'',NULL,{ts '2021-10-01 02:48:17.000'},{ts '2021-10-01 02:48:17.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'58052957',N'0584',N'',NULL,{ts '2021-10-01 02:48:10.000'},{ts '2021-10-01 02:48:10.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'58230810',N'0775',N'',NULL,{ts '2021-10-01 02:48:20.000'},{ts '2021-10-01 02:48:20.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'58514744',N'0860',N'',NULL,{ts '2021-10-01 02:48:25.000'},{ts '2021-10-01 02:48:25.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'58563785',N'0638',N'',NULL,{ts '2021-10-01 02:48:12.000'},{ts '2021-10-01 02:48:12.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'58656996',N'0506',N'',NULL,{ts '2021-10-01 02:48:29.000'},{ts '2021-10-01 02:48:29.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'58839132',N'0830',N'',NULL,{ts '2021-10-01 02:48:42.000'},{ts '2021-10-01 02:48:42.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'59011656',N'0482',N'',NULL,{ts '2021-10-01 02:48:28.000'},{ts '2021-10-01 02:48:28.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'59067046',N'0770',N'',NULL,{ts '2021-10-01 02:48:39.000'},{ts '2021-10-01 02:48:39.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'59204446',N'0715',N'',NULL,{ts '2021-10-01 02:48:37.000'},{ts '2021-10-01 02:48:37.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'59344522',N'0492',N'',NULL,{ts '2021-10-01 02:48:20.000'},{ts '2021-10-01 02:48:20.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'59373972',N'0429',N'',NULL,{ts '2021-10-01 02:48:25.000'},{ts '2021-10-01 02:48:25.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'59581911',N'0561',N'',NULL,{ts '2021-10-01 02:48:18.000'},{ts '2021-10-01 02:48:18.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'59687360',N'0832',N'',NULL,{ts '2021-10-01 02:48:42.000'},{ts '2021-10-01 02:48:42.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'59744671',N'0573',N'',NULL,{ts '2021-10-01 02:48:30.000'},{ts '2021-10-01 02:48:30.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'59925994',N'0657',N'',NULL,{ts '2021-10-01 02:48:35.000'},{ts '2021-10-01 02:48:35.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'60455396',N'0341',N'',NULL,{ts '2021-10-01 02:48:11.000'},{ts '2021-10-01 02:48:11.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'60943558',N'0582',N'',NULL,{ts '2021-10-01 02:48:08.000'},{ts '2021-10-01 02:48:08.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'60949328',N'0462',N'',NULL,{ts '2021-10-01 02:48:40.000'},{ts '2021-10-01 02:48:40.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'60981570',N'0862',N'',NULL,{ts '2021-10-01 02:48:44.000'},{ts '2021-10-01 02:48:44.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'61134544',N'0429',N'',NULL,{ts '2021-10-01 02:48:26.000'},{ts '2021-10-01 02:48:26.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'61170934',N'0736',N'',NULL,{ts '2021-10-01 02:48:38.000'},{ts '2021-10-01 02:48:38.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'61293070',N'0650',N'',NULL,{ts '2021-10-01 02:48:14.000'},{ts '2021-10-01 02:48:14.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'61389733',N'0561',N'',NULL,{ts '2021-10-01 02:48:07.000'},{ts '2021-10-01 02:48:07.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'61440470',N'0562',N'',NULL,{ts '2021-10-01 02:48:11.000'},{ts '2021-10-01 02:48:11.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'61446919',N'0703',N'',NULL,{ts '2021-10-01 02:48:35.000'},{ts '2021-10-01 02:48:35.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'61941208',N'0650',N'',NULL,{ts '2021-10-01 02:48:14.000'},{ts '2021-10-01 02:48:14.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'62037960',N'0561',N'',NULL,{ts '2021-10-01 02:48:07.000'},{ts '2021-10-01 02:48:07.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'62516118',N'0694',N'',NULL,{ts '2021-10-01 02:48:36.000'},{ts '2021-10-01 02:48:36.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'62668384',N'0561',N'',NULL,{ts '2021-10-01 02:48:09.000'},{ts '2021-10-01 02:48:09.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'63419669',N'0638',N'',NULL,{ts '2021-10-01 02:48:12.000'},{ts '2021-10-01 02:48:12.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'63658260',N'0537',N'',NULL,{ts '2021-10-01 02:48:41.000'},{ts '2021-10-01 02:48:41.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'63670307',N'0653',N'',NULL,{ts '2021-10-01 02:48:17.000'},{ts '2021-10-01 02:48:17.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'63817706',N'0653',N'',NULL,{ts '2021-10-01 02:48:15.000'},{ts '2021-10-01 02:48:15.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'63995794',N'0645',N'',NULL,{ts '2021-10-01 02:48:34.000'},{ts '2021-10-01 02:48:34.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'64113618',N'0628',N'',NULL,{ts '2021-10-01 02:48:32.000'},{ts '2021-10-01 02:48:32.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'64546895',N'0561',N'',NULL,{ts '2021-10-01 02:48:18.000'},{ts '2021-10-01 02:48:18.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'64647583',N'0604',N'',NULL,{ts '2021-10-01 02:48:10.000'},{ts '2021-10-01 02:48:10.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'64903468',N'0606',N'',NULL,{ts '2021-10-01 02:48:08.000'},{ts '2021-10-01 02:48:08.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'65089107',N'0342',N'',NULL,{ts '2021-10-01 02:48:33.000'},{ts '2021-10-01 02:48:33.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'65131844',N'0718',N'',NULL,{ts '2021-10-01 02:48:37.000'},{ts '2021-10-01 02:48:37.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'65194444',N'0429',N'',NULL,{ts '2021-10-01 02:48:25.000'},{ts '2021-10-01 02:48:25.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'65259633',N'0579',N'',NULL,{ts '2021-10-01 02:48:06.000'},{ts '2021-10-01 02:48:06.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'65263971',N'0641',N'',NULL,{ts '2021-10-01 02:48:13.000'},{ts '2021-10-01 02:48:13.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'65610520',N'0653',N'',NULL,{ts '2021-10-01 02:48:35.000'},{ts '2021-10-01 02:48:35.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'65912108',N'0641',N'',NULL,{ts '2021-10-01 02:48:13.000'},{ts '2021-10-01 02:48:13.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'66007332',N'0654',N'',NULL,{ts '2021-10-01 02:48:38.000'},{ts '2021-10-01 02:48:38.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'66606282',N'0335',N'',NULL,{ts '2021-10-01 02:48:28.000'},{ts '2021-10-01 02:48:28.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'66914121',N'0829',N'',NULL,{ts '2021-10-01 02:48:21.000'},{ts '2021-10-01 02:48:21.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'66983758',N'481',N'',NULL,{ts '2021-10-01 02:48:09.000'},{ts '2021-10-01 02:48:09.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'67041357',N'0505',N'',NULL,{ts '2021-10-01 02:48:26.000'},{ts '2021-10-01 02:48:26.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'67142045',N'0770',N'',NULL,{ts '2021-10-01 02:48:19.000'},{ts '2021-10-01 02:48:19.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'67325371',N'339',N'',NULL,{ts '2021-10-01 02:48:31.000'},{ts '2021-10-01 02:48:31.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'67572770',N'0582',N'',NULL,{ts '2021-10-01 02:48:29.000'},{ts '2021-10-01 02:48:29.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'67586018',N'0709',N'',NULL,{ts '2021-10-01 02:48:36.000'},{ts '2021-10-01 02:48:36.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'67631207',N'0702',N'',NULL,{ts '2021-10-01 02:48:16.000'},{ts '2021-10-01 02:48:16.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'68077060',N'0335',N'',NULL,{ts '2021-10-01 02:48:07.000'},{ts '2021-10-01 02:48:07.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'68137119',N'0467',N'',NULL,{ts '2021-10-01 02:48:19.000'},{ts '2021-10-01 02:48:19.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'68160271',N'0865',N'',NULL,{ts '2021-10-01 02:48:24.000'},{ts '2021-10-01 02:48:24.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'68411033',N'0863',N'',NULL,{ts '2021-10-01 02:48:24.000'},{ts '2021-10-01 02:48:24.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'68452507',N'0697',N'',NULL,{ts '2021-10-01 02:48:37.000'},{ts '2021-10-01 02:48:37.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'68507795',N'0383',N'',NULL,{ts '2021-10-01 02:48:17.000'},{ts '2021-10-01 02:48:17.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'68584668',N'0827',N'',NULL,{ts '2021-10-01 02:48:41.000'},{ts '2021-10-01 02:48:41.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'68821183',N'0650',N'',NULL,{ts '2021-10-01 02:48:34.000'},{ts '2021-10-01 02:48:34.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'69040007',N'0629',N'',NULL,{ts '2021-10-01 02:48:32.000'},{ts '2021-10-01 02:48:32.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'69101744',N'0699',N'',NULL,{ts '2021-10-01 02:48:37.000'},{ts '2021-10-01 02:48:37.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'69104295',N'0639',N'',NULL,{ts '2021-10-01 02:48:13.000'},{ts '2021-10-01 02:48:13.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'69548269',N'0538',N'',NULL,{ts '2021-10-01 02:48:30.000'},{ts '2021-10-01 02:48:30.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'69570321',N'0650',N'',NULL,{ts '2021-10-01 02:48:34.000'},{ts '2021-10-01 02:48:34.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'69641970',N'0561',N'',NULL,{ts '2021-10-01 02:48:30.000'},{ts '2021-10-01 02:48:30.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'69857896',N'0708',N'',NULL,{ts '2021-10-01 02:48:15.000'},{ts '2021-10-01 02:48:15.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'70498406',N'0688',N'',NULL,{ts '2021-10-01 02:48:15.000'},{ts '2021-10-01 02:48:15.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'70565494',N'0653',N'',NULL,{ts '2021-10-01 02:48:35.000'},{ts '2021-10-01 02:48:35.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'70871320',N'0631',N'',NULL,{ts '2021-10-01 02:48:20.000'},{ts '2021-10-01 02:48:20.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'70935180',N'0327',N'',NULL,{ts '2021-10-01 02:48:33.000'},{ts '2021-10-01 02:48:33.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'71062316',N'0738',N'',NULL,{ts '2021-10-01 02:48:38.000'},{ts '2021-10-01 02:48:38.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'71282570',N'0572',N'',NULL,{ts '2021-10-01 02:48:30.000'},{ts '2021-10-01 02:48:30.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'71532671',N'0606',N'',NULL,{ts '2021-10-01 02:48:28.000'},{ts '2021-10-01 02:48:28.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'71976554',N'0860',N'',NULL,{ts '2021-10-01 02:48:45.000'},{ts '2021-10-01 02:48:45.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'72098919',N'0770',N'',NULL,{ts '2021-10-01 02:48:19.000'},{ts '2021-10-01 02:48:19.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'72203267',N'0630',N'',NULL,{ts '2021-10-01 02:48:12.000'},{ts '2021-10-01 02:48:12.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'72564144',N'0631',N'',NULL,{ts '2021-10-01 02:48:41.000'},{ts '2021-10-01 02:48:41.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'72833580',N'0655',N'',NULL,{ts '2021-10-01 02:48:14.000'},{ts '2021-10-01 02:48:14.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'72934269',N'0582',N'',NULL,{ts '2021-10-01 02:48:06.000'},{ts '2021-10-01 02:48:06.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'72943721',N'0561',N'',NULL,{ts '2021-10-01 02:48:38.000'},{ts '2021-10-01 02:48:38.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'73033044',N'334',N'',NULL,{ts '2021-10-01 02:48:07.000'},{ts '2021-10-01 02:48:07.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'73165196',N'0631',N'',NULL,{ts '2021-10-01 02:48:12.000'},{ts '2021-10-01 02:48:12.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'73430642',N'0826',N'',NULL,{ts '2021-10-01 02:48:41.000'},{ts '2021-10-01 02:48:41.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'73553368',N'0572',N'',NULL,{ts '2021-10-01 02:48:10.000'},{ts '2021-10-01 02:48:10.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'73978755',N'0579',N'',NULL,{ts '2021-10-01 02:48:27.000'},{ts '2021-10-01 02:48:27.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'74627983',N'0561',N'',NULL,{ts '2021-10-01 02:48:27.000'},{ts '2021-10-01 02:48:27.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'74819229',N'0343',N'',NULL,{ts '2021-10-01 02:48:39.000'},{ts '2021-10-01 02:48:39.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'74905981',N'0628',N'',NULL,{ts '2021-10-01 02:48:32.000'},{ts '2021-10-01 02:48:32.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'75182321',N'0654',N'',NULL,{ts '2021-10-01 02:48:18.000'},{ts '2021-10-01 02:48:18.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'75278083',N'339',N'',NULL,{ts '2021-10-01 02:48:11.000'},{ts '2021-10-01 02:48:11.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'75515518',N'0610',N'',NULL,{ts '2021-10-01 02:48:05.000'},{ts '2021-10-01 02:48:05.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'75529856',N'0',N'',NULL,{ts '2021-10-01 02:48:10.000'},{ts '2021-10-01 02:48:10.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'75937454',N'0859',N'',NULL,{ts '2021-10-01 02:48:44.000'},{ts '2021-10-01 02:48:44.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'75976405',N'0630',N'',NULL,{ts '2021-10-01 02:48:32.000'},{ts '2021-10-01 02:48:32.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'76008870',N'0579',N'',NULL,{ts '2021-10-01 02:48:06.000'},{ts '2021-10-01 02:48:06.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'76023116',N'0653',N'',NULL,{ts '2021-10-01 02:48:37.000'},{ts '2021-10-01 02:48:37.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'76058829',N'0450',N'',NULL,{ts '2021-10-01 02:48:18.000'},{ts '2021-10-01 02:48:18.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'76492893',N'0653',N'',NULL,{ts '2021-10-01 02:48:35.000'},{ts '2021-10-01 02:48:35.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'76534954',N'0467',N'',NULL,{ts '2021-10-01 02:48:40.000'},{ts '2021-10-01 02:48:40.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'76740970',N'0887',N'',NULL,{ts '2021-10-01 02:48:25.000'},{ts '2021-10-01 02:48:25.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'77376868',N'0628',N'',NULL,{ts '2021-10-01 02:48:11.000'},{ts '2021-10-01 02:48:11.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'77524268',N'0539',N'',NULL,{ts '2021-10-01 02:48:09.000'},{ts '2021-10-01 02:48:09.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'77620717',N'0638',N'',NULL,{ts '2021-10-01 02:48:33.000'},{ts '2021-10-01 02:48:33.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'77888607',N'0656',N'',NULL,{ts '2021-10-01 02:48:14.000'},{ts '2021-10-01 02:48:14.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'78067579',N'0859',N'',NULL,{ts '2021-10-01 02:48:24.000'},{ts '2021-10-01 02:48:24.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'78555731',N'0833',N'',NULL,{ts '2021-10-01 02:48:21.000'},{ts '2021-10-01 02:48:21.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'78966881',N'0426',N'',NULL,{ts '2021-10-01 02:48:31.000'},{ts '2021-10-01 02:48:31.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'79069582',N'0562',N'',NULL,{ts '2021-10-01 02:48:32.000'},{ts '2021-10-01 02:48:32.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'79297406',N'0561',N'',NULL,{ts '2021-10-01 02:48:30.000'},{ts '2021-10-01 02:48:30.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'79479732',N'0834',N'',NULL,{ts '2021-10-01 02:48:42.000'},{ts '2021-10-01 02:48:42.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'79693457',N'0604',N'',NULL,{ts '2021-10-01 02:48:10.000'},{ts '2021-10-01 02:48:10.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'79969432',N'0482',N'',NULL,{ts '2021-10-01 02:48:07.000'},{ts '2021-10-01 02:48:07.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'80111931',N'0658',N'',NULL,{ts '2021-10-01 02:48:35.000'},{ts '2021-10-01 02:48:35.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'80125278',N'0831',N'',NULL,{ts '2021-10-01 02:48:42.000'},{ts '2021-10-01 02:48:42.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'80395705',N'0706',N'',NULL,{ts '2021-10-01 02:48:15.000'},{ts '2021-10-01 02:48:15.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'80462793',N'0656',N'',NULL,{ts '2021-10-01 02:48:35.000'},{ts '2021-10-01 02:48:35.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'80558455',N'0604',N'',NULL,{ts '2021-10-01 02:48:28.000'},{ts '2021-10-01 02:48:28.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'80595855',N'0770',N'',NULL,{ts '2021-10-01 02:48:39.000'},{ts '2021-10-01 02:48:39.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'80832379',N'0630',N'',NULL,{ts '2021-10-01 02:48:32.000'},{ts '2021-10-01 02:48:32.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'80873843',N'0864',N'',NULL,{ts '2021-10-01 02:48:45.000'},{ts '2021-10-01 02:48:45.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'81014893',N'0764',N'',NULL,{ts '2021-10-01 02:48:18.000'},{ts '2021-10-01 02:48:18.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'81461343',N'0775',N'',NULL,{ts '2021-10-01 02:48:40.000'},{ts '2021-10-01 02:48:40.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'81522080',N'0860',N'',NULL,{ts '2021-10-01 02:48:45.000'},{ts '2021-10-01 02:48:45.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'81580928',N'0466',N'',NULL,{ts '2021-10-01 02:48:40.000'},{ts '2021-10-01 02:48:40.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'81584168',N'0337',N'',NULL,{ts '2021-10-01 02:48:08.000'},{ts '2021-10-01 02:48:08.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'81796854',N'0887',N'',NULL,{ts '2021-10-01 02:48:25.000'},{ts '2021-10-01 02:48:25.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'82087429',N'0711',N'',NULL,{ts '2021-10-01 02:48:35.000'},{ts '2021-10-01 02:48:35.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'82393355',N'0537',N'',NULL,{ts '2021-10-01 02:48:21.000'},{ts '2021-10-01 02:48:21.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'82557105',N'0639',N'',NULL,{ts '2021-10-01 02:48:33.000'},{ts '2021-10-01 02:48:33.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'82618742',N'0735',N'',NULL,{ts '2021-10-01 02:48:38.000'},{ts '2021-10-01 02:48:38.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'82926781',N'0604',N'',NULL,{ts '2021-10-01 02:48:31.000'},{ts '2021-10-01 02:48:31.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'83105654',N'0494',N'',NULL,{ts '2021-10-01 02:48:41.000'},{ts '2021-10-01 02:48:41.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'83584331',N'0579',N'',NULL,{ts '2021-10-01 02:48:39.000'},{ts '2021-10-01 02:48:39.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'83929343',N'0604',N'',NULL,{ts '2021-10-01 02:48:07.000'},{ts '2021-10-01 02:48:07.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'83952494',N'0338',N'',NULL,{ts '2021-10-01 02:48:12.000'},{ts '2021-10-01 02:48:12.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'84049679',N'0453',N'',NULL,{ts '2021-10-01 02:48:29.000'},{ts '2021-10-01 02:48:29.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'84053917',N'0693',N'',NULL,{ts '2021-10-01 02:48:36.000'},{ts '2021-10-01 02:48:36.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'84108105',N'0653',N'',NULL,{ts '2021-10-01 02:48:17.000'},{ts '2021-10-01 02:48:17.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'84519355',N'0582',N'',NULL,{ts '2021-10-01 02:48:27.000'},{ts '2021-10-01 02:48:27.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'85074704',N'0582',N'',NULL,{ts '2021-10-01 02:48:18.000'},{ts '2021-10-01 02:48:18.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'85450839',N'0770',N'',NULL,{ts '2021-10-01 02:48:39.000'},{ts '2021-10-01 02:48:39.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'85490770',N'0561',N'',NULL,{ts '2021-10-01 02:48:27.000'},{ts '2021-10-01 02:48:27.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'85544068',N'0582',N'',NULL,{ts '2021-10-01 02:48:08.000'},{ts '2021-10-01 02:48:08.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'86325804',N'0691',N'',NULL,{ts '2021-10-01 02:48:16.000'},{ts '2021-10-01 02:48:16.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'86588555',N'0482',N'',NULL,{ts '2021-10-01 02:48:28.000'},{ts '2021-10-01 02:48:28.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'86894481',N'0643',N'',NULL,{ts '2021-10-01 02:48:13.000'},{ts '2021-10-01 02:48:13.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'87452030',N'0828',N'',NULL,{ts '2021-10-01 02:48:21.000'},{ts '2021-10-01 02:48:21.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'87735954',N'0650',N'',NULL,{ts '2021-10-01 02:48:26.000'},{ts '2021-10-01 02:48:26.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'87867106',N'0585',N'',NULL,{ts '2021-10-01 02:48:31.000'},{ts '2021-10-01 02:48:31.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'87880143',N'0582',N'',NULL,{ts '2021-10-01 02:48:06.000'},{ts '2021-10-01 02:48:06.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'88272717',N'0717',N'',NULL,{ts '2021-10-01 02:48:17.000'},{ts '2021-10-01 02:48:17.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'88429117',N'0654',N'',NULL,{ts '2021-10-01 02:48:14.000'},{ts '2021-10-01 02:48:14.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'88596205',N'0641',N'',NULL,{ts '2021-10-01 02:48:34.000'},{ts '2021-10-01 02:48:34.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'88760979',N'0658',N'',NULL,{ts '2021-10-01 02:48:14.000'},{ts '2021-10-01 02:48:14.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'89052543',N'0860',N'',NULL,{ts '2021-10-01 02:48:24.000'},{ts '2021-10-01 02:48:24.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'89184705',N'481',N'',NULL,{ts '2021-10-01 02:48:29.000'},{ts '2021-10-01 02:48:29.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'89249994',N'0585',N'',NULL,{ts '2021-10-01 02:48:10.000'},{ts '2021-10-01 02:48:10.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'90008229',N'0650',N'',NULL,{ts '2021-10-01 02:48:34.000'},{ts '2021-10-01 02:48:34.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'90031366',N'0603',N'',NULL,{ts '2021-10-01 02:48:10.000'},{ts '2021-10-01 02:48:10.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'90223477',N'0561',N'',NULL,{ts '2021-10-01 02:48:27.000'},{ts '2021-10-01 02:48:27.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'90507491',N'0562',N'',NULL,{ts '2021-10-01 02:48:32.000'},{ts '2021-10-01 02:48:32.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'90532104',N'0639',N'',NULL,{ts '2021-10-01 02:48:13.000'},{ts '2021-10-01 02:48:13.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'90979629',N'0610',N'',NULL,{ts '2021-10-01 02:48:05.000'},{ts '2021-10-01 02:48:05.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'91003203',N'0654',N'',NULL,{ts '2021-10-01 02:48:35.000'},{ts '2021-10-01 02:48:35.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'91136465',N'0463',N'',NULL,{ts '2021-10-01 02:48:40.000'},{ts '2021-10-01 02:48:40.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'91473989',N'0429',N'',NULL,{ts '2021-10-01 02:48:33.000'},{ts '2021-10-01 02:48:33.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'91624627',N'0716',N'',NULL,{ts '2021-10-01 02:48:37.000'},{ts '2021-10-01 02:48:37.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'91628866',N'0610',N'',NULL,{ts '2021-10-01 02:48:06.000'},{ts '2021-10-01 02:48:06.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'92404453',N'0860',N'',NULL,{ts '2021-10-01 02:48:45.000'},{ts '2021-10-01 02:48:45.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'92660330',N'0579',N'',NULL,{ts '2021-10-01 02:48:18.000'},{ts '2021-10-01 02:48:18.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'92823080',N'0584',N'',NULL,{ts '2021-10-01 02:48:30.000'},{ts '2021-10-01 02:48:30.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'92978279',N'0562',N'',NULL,{ts '2021-10-01 02:48:11.000'},{ts '2021-10-01 02:48:11.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'93002953',N'0631',N'',NULL,{ts '2021-10-01 02:48:40.000'},{ts '2021-10-01 02:48:40.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'93411580',N'0429',N'',NULL,{ts '2021-10-01 02:48:26.000'},{ts '2021-10-01 02:48:26.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'93489017',N'0650',N'',NULL,{ts '2021-10-01 02:48:14.000'},{ts '2021-10-01 02:48:14.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'93536828',N'0770',N'',NULL,{ts '2021-10-01 02:48:19.000'},{ts '2021-10-01 02:48:19.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'93575779',N'0561',N'',NULL,{ts '2021-10-01 02:48:07.000'},{ts '2021-10-01 02:48:07.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'93979791',N'0706',N'',NULL,{ts '2021-10-01 02:48:36.000'},{ts '2021-10-01 02:48:36.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'94091266',N'0572',N'',NULL,{ts '2021-10-01 02:48:09.000'},{ts '2021-10-01 02:48:09.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'94355505',N'0653',N'',NULL,{ts '2021-10-01 02:48:14.000'},{ts '2021-10-01 02:48:14.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'94560843',N'0332',N'',NULL,{ts '2021-10-01 02:48:07.000'},{ts '2021-10-01 02:48:07.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'94593004',N'0342',N'',NULL,{ts '2021-10-01 02:48:12.000'},{ts '2021-10-01 02:48:12.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'95340689',N'0713',N'',NULL,{ts '2021-10-01 02:48:15.000'},{ts '2021-10-01 02:48:15.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'95797228',N'0702',N'',NULL,{ts '2021-10-01 02:48:37.000'},{ts '2021-10-01 02:48:37.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'95978441',N'0825',N'',NULL,{ts '2021-10-01 02:48:41.000'},{ts '2021-10-01 02:48:41.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'96436341',N'0582',N'',NULL,{ts '2021-10-01 02:48:08.000'},{ts '2021-10-01 02:48:08.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'96469593',N'0640',N'',NULL,{ts '2021-10-01 02:48:13.000'},{ts '2021-10-01 02:48:13.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'96678643',N'0717',N'',NULL,{ts '2021-10-01 02:48:37.000'},{ts '2021-10-01 02:48:37.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'96691789',N'0640',N'',NULL,{ts '2021-10-01 02:48:13.000'},{ts '2021-10-01 02:48:13.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'97134081',N'334',N'',NULL,{ts '2021-10-01 02:48:28.000'},{ts '2021-10-01 02:48:28.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'97326327',N'0775',N'',NULL,{ts '2021-10-01 02:48:40.000'},{ts '2021-10-01 02:48:40.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'97349329',N'0812',N'',NULL,{ts '2021-10-01 02:48:21.000'},{ts '2021-10-01 02:48:21.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'98000589',N'0582',N'',NULL,{ts '2021-10-01 02:48:29.000'},{ts '2021-10-01 02:48:29.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'98078016',N'0701',N'',NULL,{ts '2021-10-01 02:48:16.000'},{ts '2021-10-01 02:48:16.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'99041053',N'0812',N'',NULL,{ts '2021-10-01 02:48:41.000'},{ts '2021-10-01 02:48:41.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'99479265',N'0611',N'',NULL,{ts '2021-10-01 02:48:26.000'},{ts '2021-10-01 02:48:26.000'});
GO
INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Anh],[Ngaytao],[Ngaysua]) VALUES (
N'99565928',N'0466',N'',NULL,{ts '2021-10-01 02:48:19.000'},{ts '2021-10-01 02:48:19.000'});
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'00043172844403',N'Y 45',1160,90,N'23904349',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:12.000'},{ts '2021-10-01 03:40:12.000'},N'36FY03470');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'00199203532390',N'N 227',1160,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:40.000'},{ts '2021-10-01 03:42:40.000'},N'77FY6837R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'00321590955497',N'N 228',870,70,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:40.000'},{ts '2021-10-01 03:42:40.000'},N'77FY9327R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'00835123342324',N'Y 95',2080,90,N'42627397',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:19.000'},{ts '2021-10-01 03:40:19.000'},N'36FY07930');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'01288527144422',N'N 3',1180,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:09.000'},{ts '2021-10-01 03:42:09.000'},N'36FY09690');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'01657847152431',N'N 151',1510,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:43:58.000'},{ts '2021-10-01 03:43:58.000'},N'78FY5977R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'01688310183853',N'N 244',1280,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:10.000'},{ts '2021-10-01 03:44:10.000'},N'36FY02050');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'01760148915796',N'Y 9',1100,90,N'39985436',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:07.000'},{ts '2021-10-01 03:40:07.000'},N'36FY05940 ');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'02286801264739',N'N 211',1310,70,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:06.000'},{ts '2021-10-01 03:44:06.000'},N'77FY0237R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'02701611946017',N'Y 101',1170,90,N'12070903',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:20.000'},{ts '2021-10-01 03:40:20.000'},N'36FY07990');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'02919660448196',N'Y 51',1210,60,N'08051067',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:13.000'},{ts '2021-10-01 03:40:13.000'},N'36FY06140');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'03614509886023',N'Y 194',1410,90,N'68137119',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:32.000'},{ts '2021-10-01 03:40:32.000'},N'36FY05070');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'03990084357870',N'Y 53',1110,70,N'18328041',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:13.000'},{ts '2021-10-01 03:40:13.000'},N'36FY06240');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'05248061847504',N'N 164',1270,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:00.000'},{ts '2021-10-01 03:44:00.000'},N'77FY6417R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'05414122153177',N'Y 115',1570,100,N'61293070',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:22.000'},{ts '2021-10-01 03:40:22.000'},N'36FY08390');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'05615935646953',N'Y 23',1160,140,N'52492434',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:09.000'},{ts '2021-10-01 03:40:09.000'},N'36FY05110');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'06363484758567',N'Y 80',1630,110,N'92978279',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:17.000'},{ts '2021-10-01 03:40:17.000'},N'36FY06190 ');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'06395546063861',N'Y 117',1540,160,N'72833580',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:22.000'},{ts '2021-10-01 03:40:22.000'},N'36FY08330');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'07275372698672',N'Y 173',690,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:40:30.000'},{ts '2021-10-01 03:40:30.000'},N'36FY09630');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'07350778877964',N'N 40',1260,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:14.000'},{ts '2021-10-01 03:42:14.000'},N'36FY09830');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'07822665001695',N'N 148',1390,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:29.000'},{ts '2021-10-01 03:42:29.000'},N'78FY1137R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'08110497361044',N'Y 88',1310,160,N'83952494',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:18.000'},{ts '2021-10-01 03:40:18.000'},N'36FY02310');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'08455092351704',N'N 222',1170,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:39.000'},{ts '2021-10-01 03:42:39.000'},N'76FY4497R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'09086995965737',N'Y 94',2030,90,N'42627397',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:19.000'},{ts '2021-10-01 03:40:19.000'},N'36FY07920');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'09462300056669',N'N 197',1320,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:04.000'},{ts '2021-10-01 03:44:04.000'},N'78FY3117R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'09541754320786',N'N 171',1740,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:32.000'},{ts '2021-10-01 03:42:32.000'},N'78FY5017R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'09798154604389',N'N 154',1540,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:30.000'},{ts '2021-10-01 03:42:30.000'},N'76FY1707R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'09910330127476',N'N 155',1390,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:30.000'},{ts '2021-10-01 03:42:30.000'},N'76FY2027R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'09940891000999',N'N 186',1080,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:34.000'},{ts '2021-10-01 03:42:34.000'},N'77FY6397R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'10182264078601',N'N 173',1660,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:32.000'},{ts '2021-10-01 03:42:32.000'},N'78FY5037R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'10544136729750',N'N 148',1390,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:43:58.000'},{ts '2021-10-01 03:43:58.000'},N'78FY1137R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'10663995959865',N'Y 183',810,110,N'34989401',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:31.000'},{ts '2021-10-01 03:40:31.000'},N'36FY09890');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'10686922683221',N'Y 4',1580,170,N'75515518',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:07.000'},{ts '2021-10-01 03:40:07.000'},N'36FY07620');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'10940360411622',N'Y 42',1780,130,N'17077941',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:12.000'},{ts '2021-10-01 03:40:12.000'},N'36FY02230');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'12408853489778',N'N 165',1320,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:31.000'},{ts '2021-10-01 03:42:31.000'},N'77FY6587R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'12410808453242',N'Y 191',1260,90,N'26059700',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:32.000'},{ts '2021-10-01 03:40:32.000'},N'36FY05040');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'12939277682078',N'N 180',1060,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:33.000'},{ts '2021-10-01 03:42:33.000'},N'78FY2957R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'13034773309692',N'Y 32',1310,60,N'64903468',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:10.000'},{ts '2021-10-01 03:40:10.000'},N' 36FY07480');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'13271984958838',N'N 215',760,60,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:06.000'},{ts '2021-10-01 03:44:06.000'},N'77FY5697R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'13799285013340',N'N 173',1660,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:01.000'},{ts '2021-10-01 03:44:01.000'},N'78FY5037R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'15394872936224',N'N 202',1160,85,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:05.000'},{ts '2021-10-01 03:44:05.000'},N'76FY3597R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'15543607243594',N'Y 113',1260,90,N'61293070',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:21.000'},{ts '2021-10-01 03:40:21.000'},N'36FY08370');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'15882785812079',N'Y 40',1500,90,N'87880143',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:11.000'},{ts '2021-10-01 03:40:11.000'},N'36FY06940  ');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'16388507619072',N'Y 63',1280,170,N'16632776',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:14.000'},{ts '2021-10-01 03:40:14.000'},N'36FY07020');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'16623102609832',N'N 195',780,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:35.000'},{ts '2021-10-01 03:42:35.000'},N'78FY4317R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'16674323525021',N'N 221',1080,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:07.000'},{ts '2021-10-01 03:44:07.000'},N'77FY2247R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'17762108642901',N'N 228',870,70,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:08.000'},{ts '2021-10-01 03:44:08.000'},N'77FY9327R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'18048169969585',N'Y 176A',910,100,N'34989401',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:30.000'},{ts '2021-10-01 03:40:30.000'},N'36FY09591');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'18377403880429',N'N 200',730,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:36.000'},{ts '2021-10-01 03:42:36.000'},N'78FY5507R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'18643623552595',N'N 230',1170,70,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:08.000'},{ts '2021-10-01 03:44:08.000'},N'77FY9307R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'18714938362914',N'N 149',750,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:29.000'},{ts '2021-10-01 03:42:29.000'},N'78FY4307R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'18817639795695',N'N 152',1160,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:29.000'},{ts '2021-10-01 03:42:29.000'},N'78FY5987R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'18929684879268',N'Y 178',1220,60,N'76058829',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:30.000'},{ts '2021-10-01 03:40:30.000'},N'36FY04770');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'19221272191532',N'Y 17',1110,80,N'18328041',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:08.000'},{ts '2021-10-01 03:40:08.000'},N'36FY06790');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'20059355414199',N'Y 162',1080,90,N'23904349',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:28.000'},{ts '2021-10-01 03:40:28.000'},N'36FY03460');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'20103644453850',N'Y 18',1420,90,N'18328041',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:09.000'},{ts '2021-10-01 03:40:09.000'},N'36FY06810');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'20216345885531',N'Y 21',1270,90,N'04367141',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:09.000'},{ts '2021-10-01 03:40:09.000'},N'36FY07380');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'20246706778054',N'Y 56',1420,80,N'18328041',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:13.000'},{ts '2021-10-01 03:40:13.000'},N'36FY06280');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'20473596602274',N'N 182',940,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:02.000'},{ts '2021-10-01 03:44:02.000'},N'77FY9547R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'20782470040271',N'Y 181',1390,160,N'19137238',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:31.000'},{ts '2021-10-01 03:40:31.000'},N'36FY02360');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'21219490087905',N'N 212',1620,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:38.000'},{ts '2021-10-01 03:42:38.000'},N'77FY4777R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'21244861822136',N'N 5',1420,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:43:38.000'},{ts '2021-10-01 03:43:38.000'},N'36FY09710');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'21426782121877',N'Y 186',1180,90,N'08581702',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:31.000'},{ts '2021-10-01 03:40:31.000'},N'36FY09870');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'21627495613642',N'Y 96',2130,90,N'42627397',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:19.000'},{ts '2021-10-01 03:40:19.000'},N'36FY07940');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'22256469725940',N'Y 155',950,290,N'88272717',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:27.000'},{ts '2021-10-01 03:40:27.000'},N'36FY08950');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'22275044815266',N'Y 153',780,290,N'30147424',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:27.000'},{ts '2021-10-01 03:40:27.000'},N'36FY08930');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'22301758773501',N'Y 11',1260,90,N'65259633',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:08.000'},{ts '2021-10-01 03:40:08.000'},N'36FY06640');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'22307106130561',N'Y 188',1260,90,N'36604237',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:32.000'},{ts '2021-10-01 03:40:32.000'},N'36FY05010');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'22696484680569',N'N 170',830,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:00.000'},{ts '2021-10-01 03:44:00.000'},N'78FY4327R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'22931071976811',N'Y 29',1930,150,N'68077060',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:10.000'},{ts '2021-10-01 03:40:10.000'},N'36FY02280');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'23863545906233',N'Y 121',840,90,N'18328041',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:22.000'},{ts '2021-10-01 03:40:22.000'},N'36FY08730');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'24045969854207',N'Y 16',1030,80,N'18328041',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:08.000'},{ts '2021-10-01 03:40:08.000'},N'36FY06780');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'24142164560364',N'N 169',1400,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:32.000'},{ts '2021-10-01 03:42:32.000'},N'78FY2497R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'24807569570604',N'Y 35',1310,60,N'16082877',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:11.000'},{ts '2021-10-01 03:40:11.000'},N' 36FY07510');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'25426668899795',N'Y 59',1180,70,N'94091266',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:14.000'},{ts '2021-10-01 03:40:14.000'},N'36FY06430');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'25700614762978',N'N 225',1000,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:39.000'},{ts '2021-10-01 03:42:39.000'},N'77FY5027R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'26121607238621',N'Y 202',1640,180,N'73165196',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:33.000'},{ts '2021-10-01 03:40:33.000'},N'36FY10190');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'27097105832414',N'Y 208',1550,150,N'33732011',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:34.000'},{ts '2021-10-01 03:40:34.000'},N'36FY04310');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'27270979970391',N'Y 64',1380,170,N'58052957',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:15.000'},{ts '2021-10-01 03:40:15.000'},N'36FY07030');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'27407760814510',N'N 190',1440,110,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:03.000'},{ts '2021-10-01 03:44:03.000'},N'77FY4327R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'27515574060151',N'N 196',1770,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:36.000'},{ts '2021-10-01 03:42:36.000'},N'78FY3127R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'27669407210120',N'N 225',1000,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:08.000'},{ts '2021-10-01 03:44:08.000'},N'77FY5027R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'28022818790769',N'Y 68',1180,90,N'04367141',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:15.000'},{ts '2021-10-01 03:40:15.000'},N'36FY07370');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'28124845086802',N'N 155',1390,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:43:58.000'},{ts '2021-10-01 03:43:58.000'},N'76FY2027R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'28496999970845',N'N 198',1370,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:36.000'},{ts '2021-10-01 03:42:36.000'},N'78FY3107R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'28873073472499',N'N 156',1620,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:43:59.000'},{ts '2021-10-01 03:43:59.000'},N'76FY7167R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'29017982484878',N'Y 25B',50,60,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:40:16.000'},{ts '2021-10-01 03:40:16.000'},N'745565800');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'29150044799072',N'Y 107',2230,90,N'65263971',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:20.000'},{ts '2021-10-01 03:40:20.000'},N'36FY08050');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'29279529889488',N'Y 105',2110,90,N'65263971',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:20.000'},{ts '2021-10-01 03:40:20.000'},N'36FY08030');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'29354772428987',N'N 198',1370,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:04.000'},{ts '2021-10-01 03:44:04.000'},N'78FY3107R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'29701956130597',N'Y 179',580,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:40:30.000'},{ts '2021-10-01 03:40:30.000'},N'36FY09610');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'31079132057543',N'Y 24',1240,140,N'52492434',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:09.000'},{ts '2021-10-01 03:40:09.000'},N'36FY05130');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'31268436050744',N'N 243',1240,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:42.000'},{ts '2021-10-01 03:42:42.000'},N'36FY02040');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'31512368347195',N'N 165',1320,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:00.000'},{ts '2021-10-01 03:44:00.000'},N'77FY6587R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'31555267211183',N'Y 184',1020,90,N'08581702',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:31.000'},{ts '2021-10-01 03:40:31.000'},N'36FY09850');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'32246383883186',N'N 185',1060,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:02.000'},{ts '2021-10-01 03:44:02.000'},N'77FY5057R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'32583772257788',N'N 167',1100,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:00.000'},{ts '2021-10-01 03:44:00.000'},N'78FY1757R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'32637681269157',N'Y 81',1110,85,N'56484596',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:17.000'},{ts '2021-10-01 03:40:17.000'},N'36FY07780');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'33193020035839',N'Y 12',1420,90,N'65259633',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:08.000'},{ts '2021-10-01 03:40:08.000'},N'36FY06650');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'33669155299579',N'Y 172',990,90,N'18328041',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:29.000'},{ts '2021-10-01 03:40:29.000'},N'36FY06860');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'33744551479870',N'N 39',1190,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:14.000'},{ts '2021-10-01 03:42:14.000'},N'36FY09820');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'33760843574452',N'Y 118',1620,170,N'77888607',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:22.000'},{ts '2021-10-01 03:40:22.000'},N'36FY08340');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'34570787330893',N'N 182',940,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:34.000'},{ts '2021-10-01 03:42:34.000'},N'77FY9547R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'34575694772534',N'Y 89 A',1130,90,N'15382675',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:18.000'},{ts '2021-10-01 03:40:18.000'},N'36FY02390');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'34625075388554',N'N 41',1140,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:14.000'},{ts '2021-10-01 03:42:14.000'},N'36FY09840');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'35455119672218',N'Y 91 A',1040,90,N'00558988',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:18.000'},{ts '2021-10-01 03:40:18.000'},N'36FY02370');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'35829299862394',N'N 223',1390,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:39.000'},{ts '2021-10-01 03:42:39.000'},N'76FY2797R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'36385648638076',N'N 156',1620,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:30.000'},{ts '2021-10-01 03:42:30.000'},N'76FY7167R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'36583759836606',N'N 39',1190,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:43:43.000'},{ts '2021-10-01 03:43:43.000'},N'36FY09820');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'36913989509959',N'Y 203',1500,180,N'73165196',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:34.000'},{ts '2021-10-01 03:40:34.000'},N'36FY10200');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'37500570680926',N'Y 170',1570,90,N'18328041',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:29.000'},{ts '2021-10-01 03:40:29.000'},N'36FY06820');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'38021044663021',N'N 152',1160,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:43:58.000'},{ts '2021-10-01 03:43:58.000'},N'78FY5987R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'38076828457607',N'Y 102',2080,90,N'01424477',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:20.000'},{ts '2021-10-01 03:40:20.000'},N'36FY08000');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'38399783264687',N'Y 48',2140,90,N'66983758',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:12.000'},{ts '2021-10-01 03:40:12.000'},N'36FY05100');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'38929107367988',N'Y 65',1480,170,N'89249994',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:15.000'},{ts '2021-10-01 03:40:15.000'},N'36FY07040');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'39259786141757',N'N 201',690,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:36.000'},{ts '2021-10-01 03:42:36.000'},N'78FY5497R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'39265381868471',N'Y 54',1160,70,N'18328041',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:13.000'},{ts '2021-10-01 03:40:13.000'},N'36FY06250');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'39988806397613',N'Y 195',1410,90,N'47690210',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:32.000'},{ts '2021-10-01 03:40:32.000'},N'36FY05080');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'40022573312769',N'N 204',1140,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:37.000'},{ts '2021-10-01 03:42:37.000'},N'36FY00830');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'41050708322063',N'N 244',1280,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:42.000'},{ts '2021-10-01 03:42:42.000'},N'36FY02050');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'41409657925314',N'N 162',1390,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:43:59.000'},{ts '2021-10-01 03:43:59.000'},N'76FY2827R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'42524980836476',N'Y 78',1220,60,N'13415187',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:17.000'},{ts '2021-10-01 03:40:17.000'},N'36FY04740');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'43117985200739',N'N 194',940,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:35.000'},{ts '2021-10-01 03:42:35.000'},N'78FY4347R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'43417207834311',N'N 204',1140,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:05.000'},{ts '2021-10-01 03:44:05.000'},N'36FY00830');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'44184161189405',N'N 146',1700,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:29.000'},{ts '2021-10-01 03:42:29.000'},N'76FY2397R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'45079135873414',N'N 150',1520,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:29.000'},{ts '2021-10-01 03:42:29.000'},N'78FY4427R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'45282936206295',N'N 153',1470,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:29.000'},{ts '2021-10-01 03:42:29.000'},N'76FY1697R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'45333574601806',N'N 185',1060,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:34.000'},{ts '2021-10-01 03:42:34.000'},N'77FY5057R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'45734906145478',N'N 195',780,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:04.000'},{ts '2021-10-01 03:44:04.000'},N'78FY4317R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'45753481235894',N'N 193',1230,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:04.000'},{ts '2021-10-01 03:44:04.000'},N'78FY6607R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'47050229194821',N'Y 5',1770,130,N'33048037',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:07.000'},{ts '2021-10-01 03:40:07.000'},N'36FY07630');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'47315668922213',N'Y 43',1590,140,N'02012977',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:12.000'},{ts '2021-10-01 03:40:12.000'},N'36FY02260');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'47639065771242',N'Y 168',1670,100,N'42125559',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:29.000'},{ts '2021-10-01 03:40:29.000'},N'36FY06470');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'47918333230340',N'N 149',750,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:43:58.000'},{ts '2021-10-01 03:43:58.000'},N'78FY4307R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'47931643003505',N'Y 7',2080,130,N'33048037',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:07.000'},{ts '2021-10-01 03:40:07.000'},N'36FY07650');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'48963117034827',N'Y 99',2080,90,N'12070903',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:19.000'},{ts '2021-10-01 03:40:19.000'},N'36FY07970');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'49163482424931',N'N 174',1080,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:01.000'},{ts '2021-10-01 03:44:01.000'},N'78FY5247R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'49409970710292',N'Y 33',1310,60,N'43476650',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:10.000'},{ts '2021-10-01 03:40:10.000'},N'36FY07490');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'49555111498289',N'N 215',760,60,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:38.000'},{ts '2021-10-01 03:42:38.000'},N'77FY5697R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'49773150990368',N'N 166',1130,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:31.000'},{ts '2021-10-01 03:42:31.000'},N'78FY1737R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'49875105964832',N'Y 192',1260,90,N'57245747',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:32.000'},{ts '2021-10-01 03:40:32.000'},N'36FY05050');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'50209423579885',N'N 220',1130,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:39.000'},{ts '2021-10-01 03:42:39.000'},N'78FY0757R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'50210193513551',N'N 212',1620,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:06.000'},{ts '2021-10-01 03:44:06.000'},N'77FY4777R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'50291352071511',N'Y 34',1310,60,N'11938851',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:11.000'},{ts '2021-10-01 03:40:11.000'},N' 36FY07500');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'50954828589125',N'Y 86 A',1530,100,N'72203267',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:18.000'},{ts '2021-10-01 03:40:18.000'},N'36FY07840');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'51143281990888',N'Y 38',1180,90,N'87880143',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:11.000'},{ts '2021-10-01 03:40:11.000'},N' 36FY06920');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'51172866981205',N'Y 36',1150,90,N'87880143',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:11.000'},{ts '2021-10-01 03:40:11.000'},N'36FY07280');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'52167106027938',N'N 220',1130,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:07.000'},{ts '2021-10-01 03:44:07.000'},N'78FY0757R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'52175911273578',N'N 226',1040,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:40.000'},{ts '2021-10-01 03:42:40.000'},N'77FY5047R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'53038620936611',N'N 222',1170,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:07.000'},{ts '2021-10-01 03:44:07.000'},N'76FY4497R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'53640193797982',N'Y 61',1420,100,N'42125559',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:14.000'},{ts '2021-10-01 03:40:14.000'},N'36FY06450');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'54033604621721',N'N 226',1040,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:08.000'},{ts '2021-10-01 03:44:08.000'},N'77FY5047R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'54200765947394',N'Y 174',1580,90,N'65259633',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:30.000'},{ts '2021-10-01 03:40:30.000'},N'36FY06660');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'54461402342014',N'Y 209',1450,90,N'28787137',N'000002',N'Cái',N'',{ts '2021-10-01 03:40:34.000'},{ts '2021-10-01 03:40:34.000'},N'36FY10400');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'54861296381335',N'N 199',1280,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:36.000'},{ts '2021-10-01 03:42:36.000'},N'78FY0397R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'55247270983099',N'N 157',1770,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:43:59.000'},{ts '2021-10-01 03:43:59.000'},N'77FY0067R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'55342827252698',N'Y 211',1210,60,N'82393355',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:35.000'},{ts '2021-10-01 03:40:35.000'},N'36FY06130');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'55497015201369',N'Y 69',1410,100,N'04367141',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:15.000'},{ts '2021-10-01 03:40:15.000'},N'36FY07390');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'56176253641187',N'Y 180',640,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:40:31.000'},{ts '2021-10-01 03:40:31.000'},N'36FY09620');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'56363604804052',N'Y 73',1620,160,N'60455396',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:16.000'},{ts '2021-10-01 03:40:16.000'},N'36FY02340');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'56482189995368',N'Y 71',1310,160,N'75278083',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:16.000'},{ts '2021-10-01 03:40:16.000'},N'36FY02320');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'56514241200663',N'Y 108',2060,90,N'65263971',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:21.000'},{ts '2021-10-01 03:40:21.000'},N'36FY08060');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'56575047679508',N'N 172',1750,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:32.000'},{ts '2021-10-01 03:42:32.000'},N'78FY5027R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'56578841964340',N'Y 19',820,80,N'18328041',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:09.000'},{ts '2021-10-01 03:40:09.000'},N'36FY06840');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'57478117225174',N'N 200',730,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:04.000'},{ts '2021-10-01 03:44:04.000'},N'78FY5507R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'57847893113864',N'N 183',1200,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:02.000'},{ts '2021-10-01 03:44:02.000'},N'77FY4337R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'57955508269405',N'N 189',920,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:35.000'},{ts '2021-10-01 03:42:35.000'},N'77FY5017R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'57966379203180',N'N 181',1390,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:02.000'},{ts '2021-10-01 03:44:02.000'},N'77FY9897R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'58082792124243',N'Y 97',1120,90,N'42627397',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:19.000'},{ts '2021-10-01 03:40:19.000'},N'36FY07950');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'58492852942254',N'Y 171',1720,90,N'18328041',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:29.000'},{ts '2021-10-01 03:40:29.000'},N'36FY06830');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'58574797598505',N'N 213',1270,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:38.000'},{ts '2021-10-01 03:42:38.000'},N'77FY6417R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'58799934658893',N'N 161',1350,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:31.000'},{ts '2021-10-01 03:42:31.000'},N'76FY2817R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'58891989631467',N'Y 187',1250,90,N'08581702',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:31.000'},{ts '2021-10-01 03:40:31.000'},N'36FY09880');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'59060781091150',N'N 171',1740,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:01.000'},{ts '2021-10-01 03:44:01.000'},N'78FY5017R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'59206278387411',N'Y 30',2080,150,N'00397241',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:10.000'},{ts '2021-10-01 03:40:10.000'},N'36FY02290');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'59610766236531',N'Y 156',950,290,N'57734908',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:27.000'},{ts '2021-10-01 03:40:27.000'},N'36FY08960');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'59640241326857',N'Y 154',870,290,N'09619616',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:27.000'},{ts '2021-10-01 03:40:27.000'},N'36FY08940');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'59660459567587',N'N 163',1430,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:31.000'},{ts '2021-10-01 03:42:31.000'},N'76FY2837R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'59772403541151',N'Y 189',1260,90,N'15177338',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:32.000'},{ts '2021-10-01 03:40:32.000'},N'36FY05020');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'60063569931800',N'N 181',1390,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:34.000'},{ts '2021-10-01 03:42:34.000'},N'77FY9897R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'60354891465472',N'N 191',660,220,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:03.000'},{ts '2021-10-01 03:44:03.000'},N'77FY5037R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'60403038597869',N'Y 157',1030,290,N'42788034',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:27.000'},{ts '2021-10-01 03:40:27.000'},N'36FY08970');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'60567237546429',N'Y 13',1260,80,N'18328041',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:08.000'},{ts '2021-10-01 03:40:08.000'},N'36FY06800');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'60944084841484',N'N 183',1200,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:34.000'},{ts '2021-10-01 03:42:34.000'},N'77FY4337R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'61081795940104',N'N 221',1080,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:39.000'},{ts '2021-10-01 03:42:39.000'},N'77FY2247R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'61438741455113',N'Y 15',1420,90,N'87880143',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:08.000'},{ts '2021-10-01 03:40:08.000'},N'36FY06510');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'62820316183818',N'Y 92',1770,160,N'94593004',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:19.000'},{ts '2021-10-01 03:40:19.000'},N'36FY02350');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'62957956337207',N'N 40',1260,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:43:43.000'},{ts '2021-10-01 03:43:43.000'},N'36FY09830');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'63387286010540',N'Y 204',1460,170,N'59344522',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:34.000'},{ts '2021-10-01 03:40:34.000'},N'36FY05390');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'63397566957831',N'N 146',1700,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:43:57.000'},{ts '2021-10-01 03:43:57.000'},N'76FY2397R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'63408072536153',N'N 158',900,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:30.000'},{ts '2021-10-01 03:42:30.000'},N'78FY4337R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'63820993298940',N'N 223',1390,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:07.000'},{ts '2021-10-01 03:44:07.000'},N'76FY2797R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'63938708454581',N'N 229',1470,70,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:40.000'},{ts '2021-10-01 03:42:40.000'},N'77FY9337R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'64258601910234',N'Y 206',1740,190,N'12950739',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:34.000'},{ts '2021-10-01 03:40:34.000'},N'36FY05410');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'64394304878588',N'Y 66',1590,170,N'21568165',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:15.000'},{ts '2021-10-01 03:40:15.000'},N'36FY07050');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'64485341174612',N'N 153',1470,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:43:58.000'},{ts '2021-10-01 03:43:58.000'},N'76FY1697R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'64650389242497',N'Y 46',1350,60,N'45191385',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:12.000'},{ts '2021-10-01 03:40:12.000'},N'36FY04750');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'65430125967298',N'Y 103',2150,90,N'01424477',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:20.000'},{ts '2021-10-01 03:40:20.000'},N'36FY08010');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'65763090675278',N'Y 49',1410,90,N'34545859',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:13.000'},{ts '2021-10-01 03:40:13.000'},N'36FY05920');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'66624083652347',N'N 202',1160,85,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:36.000'},{ts '2021-10-01 03:42:36.000'},N'76FY3597R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'66639589279961',N'Y 55',1260,70,N'18328041',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:13.000'},{ts '2021-10-01 03:40:13.000'},N'36FY06270');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'67287038471675',N'Y 111',1680,190,N'34828873',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:21.000'},{ts '2021-10-01 03:40:21.000'},N'36FY07830');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'68360589687402',N'N 201',690,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:05.000'},{ts '2021-10-01 03:44:05.000'},N'78FY5497R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'68628395440317',N'N 192',1330,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:35.000'},{ts '2021-10-01 03:42:35.000'},N'78FY6617R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'68747970530733',N'N 190',1440,110,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:35.000'},{ts '2021-10-01 03:42:35.000'},N'77FY4327R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'69092989779758',N'Y 82',1180,85,N'56484596',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:17.000'},{ts '2021-10-01 03:40:17.000'},N'36FY07790');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'69134040985052',N'Y 119',1690,170,N'46340898',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:22.000'},{ts '2021-10-01 03:40:22.000'},N'36FY08350');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'69193577954730',N'Y 27',2080,130,N'94560843',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:10.000'},{ts '2021-10-01 03:40:10.000'},N'36FY02250');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'69857080668379',N'N 168',1500,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:00.000'},{ts '2021-10-01 03:44:00.000'},N'78FY2487R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'70473477565788',N'N 189',920,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:03.000'},{ts '2021-10-01 03:44:03.000'},N'77FY5017R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'70872504245902',N'N 205',600,70,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:05.000'},{ts '2021-10-01 03:44:05.000'},N'36FY02820');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'71127688746384',N'N 194',940,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:04.000'},{ts '2021-10-01 03:44:04.000'},N'78FY4347R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'71458368690005',N'N 147',1430,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:29.000'},{ts '2021-10-01 03:42:29.000'},N'76FY9777R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'71746190850444',N'Y 87 A',1570,110,N'72203267',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:18.000'},{ts '2021-10-01 03:40:18.000'},N'36FY07850');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'71826356102712',N'N 184',1180,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:34.000'},{ts '2021-10-01 03:42:34.000'},N'77FY2257R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'72198103645078',N'N 196',1770,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:04.000'},{ts '2021-10-01 03:44:04.000'},N'78FY3127R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'72555486368678',N'Y 177',1070,90,N'34989401',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:30.000'},{ts '2021-10-01 03:40:30.000'},N'36FY09600');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'73612698454137',N'Y 93',2060,85,N'73165196',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:19.000'},{ts '2021-10-01 03:40:19.000'},N'36FY07900');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'74094262182832',N'Y 169',1340,90,N'87880143',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:29.000'},{ts '2021-10-01 03:40:29.000'},N'36FY06500');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'74185107728183',N'N 211',1310,70,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:38.000'},{ts '2021-10-01 03:42:38.000'},N'77FY0237R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'74282630741831',N'N 150',1520,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:43:58.000'},{ts '2021-10-01 03:43:58.000'},N'78FY4427R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'74395940514195',N'Y 8',1180,90,N'39985436',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:07.000'},{ts '2021-10-01 03:40:07.000'},N'36FY05640');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'74425436605411',N'Y 6',1920,130,N'33048037',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:07.000'},{ts '2021-10-01 03:40:07.000'},N'36FY07640');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'74771397484862',N'Y 224',1220,90,N'87880143',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:36.000'},{ts '2021-10-01 03:40:36.000'},N'36FY10830');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'74789865333803',N'Y 44',1590,150,N'81584168',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:12.000'},{ts '2021-10-01 03:40:12.000'},N'36FY02300');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'75224103772262',N'N 243',1240,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:10.000'},{ts '2021-10-01 03:44:10.000'},N'36FY02040');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'75276365414789',N'Y 10',1110,90,N'65259633',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:08.000'},{ts '2021-10-01 03:40:08.000'},N'36FY06620');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'75337414545427',N'Y 100',2150,90,N'12070903',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:20.000'},{ts '2021-10-01 03:40:20.000'},N'36FY07980');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'75655363937596',N'Y 50',1480,90,N'34545859',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:13.000'},{ts '2021-10-01 03:40:13.000'},N'36FY05930');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'75829418909879',N'N 216',1350,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:38.000'},{ts '2021-10-01 03:42:38.000'},N'78FY6627R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'76249302475422',N'Y 193',1410,90,N'99565928',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:32.000'},{ts '2021-10-01 03:40:32.000'},N'36FY05060');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'76526887846280',N'Y 52',1350,60,N'77524268',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:13.000'},{ts '2021-10-01 03:40:13.000'},N'36FY06150');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'77497870823359',N'N 205',600,70,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:37.000'},{ts '2021-10-01 03:42:37.000'},N'36FY02820');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'77787192357922',N'N 216',1350,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:07.000'},{ts '2021-10-01 03:44:07.000'},N'78FY6627R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'78050825642687',N'Y 114',1410,100,N'61293070',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:21.000'},{ts '2021-10-01 03:40:21.000'},N'36FY08380');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'78873864336914',N'N 163',1430,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:00.000'},{ts '2021-10-01 03:44:00.000'},N'76FY2837R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'78976565758795',N'N 166',1130,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:00.000'},{ts '2021-10-01 03:44:00.000'},N'78FY1737R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'79021349552271',N'Y 116',1720,100,N'61293070',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:22.000'},{ts '2021-10-01 03:40:22.000'},N'36FY08400');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'79500767801645',N'N 193',1230,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:35.000'},{ts '2021-10-01 03:42:35.000'},N'78FY6607R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'79999287347077',N'Y 79',1610,110,N'92978279',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:17.000'},{ts '2021-10-01 03:40:17.000'},N'36FY06180');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'81246264836791',N'N 192',1330,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:03.000'},{ts '2021-10-01 03:44:03.000'},N'78FY6617R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'81378326041905',N'N 229',1470,70,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:08.000'},{ts '2021-10-01 03:44:08.000'},N'77FY9337R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'81397901131311',N'N 227',1160,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:08.000'},{ts '2021-10-01 03:44:08.000'},N'77FY6837R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'81674962458984',N'Y 175',810,90,N'34989401',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:30.000'},{ts '2021-10-01 03:40:30.000'},N'36FY09580');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'81735609853505',N'Y 210',1490,90,N'28787137',N'000002',N'Cái',N'',{ts '2021-10-01 03:40:34.000'},{ts '2021-10-01 03:40:34.000'},N'36FY10410');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'81861313712959',N'Y 70',1570,100,N'04367141',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:15.000'},{ts '2021-10-01 03:40:15.000'},N'36FY07400');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'82443432384004',N'N 151',1510,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:29.000'},{ts '2021-10-01 03:42:29.000'},N'78FY5977R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'82612477394580',N'N 158',900,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:43:59.000'},{ts '2021-10-01 03:43:59.000'},N'78FY4337R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'82792886642271',N'Y 160',1350,60,N'57615423',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:28.000'},{ts '2021-10-01 03:40:28.000'},N'36FY06160');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'83299698448274',N'Y 182',1090,90,N'51457419',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:31.000'},{ts '2021-10-01 03:40:31.000'},N'36FY02380');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'83311725272630',N'Y 3',1480,170,N'75515518',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:07.000'},{ts '2021-10-01 03:40:07.000'},N'36FY07610');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'83359151714086',N'N 180',1060,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:02.000'},{ts '2021-10-01 03:44:02.000'},N'78FY2957R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'83856386406959',N'Y 72',1470,160,N'38268350',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:16.000'},{ts '2021-10-01 03:40:16.000'},N'36FY02330');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'83861990827081',N'N 199',1280,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:04.000'},{ts '2021-10-01 03:44:04.000'},N'78FY0397R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'84211090524464',N'N 184',1180,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:02.000'},{ts '2021-10-01 03:44:02.000'},N'77FY2257R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'84456909635733',N'Y 98',1160,90,N'42627397',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:19.000'},{ts '2021-10-01 03:40:19.000'},N'36FY07960');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'84699481577695',N'N 174',1080,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:32.000'},{ts '2021-10-01 03:42:32.000'},N'78FY5247R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'84823563384625',N'Y 22',1720,100,N'04367141',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:09.000'},{ts '2021-10-01 03:40:09.000'},N'36FY07410  ');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'85153231068494',N'N 162',1390,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:31.000'},{ts '2021-10-01 03:42:31.000'},N'76FY2827R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'85948994009196',N'N 214',1270,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:38.000'},{ts '2021-10-01 03:42:38.000'},N'77FY6577R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'86034656978178',N'N 164',1270,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:31.000'},{ts '2021-10-01 03:42:31.000'},N'77FY6417R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'86146600052741',N'Y 190',1260,90,N'57596519',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:32.000'},{ts '2021-10-01 03:40:32.000'},N'36FY05030');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'86325988502750',N'N 172',1750,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:01.000'},{ts '2021-10-01 03:44:01.000'},N'78FY5027R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'86660575898002',N'Y 31',2140,90,N'52492434',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:10.000'},{ts '2021-10-01 03:40:10.000'},N'36FY07220 ');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'8691275000523',N'Y 2',1380,170,N'75515518',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:06.000'},{ts '2021-10-01 03:40:06.000'},N'36FY07600');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'87536064492895',N'Y 37',1110,90,N'87880143',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:11.000'},{ts '2021-10-01 03:40:11.000'},N'36FY06910');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'87684490024141',N'N 213',1270,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:06.000'},{ts '2021-10-01 03:44:06.000'},N'77FY6417R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'87806687447248',N'N 214',1270,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:06.000'},{ts '2021-10-01 03:44:06.000'},N'77FY6577R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'87992349426220',N'N 161',1350,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:43:59.000'},{ts '2021-10-01 03:43:59.000'},N'76FY2817R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'88417488301479',N'Y 39',1570,90,N'87880143',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:11.000'},{ts '2021-10-01 03:40:11.000'},N'36FY06520 ');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'88659382069468',N'N 170',830,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:32.000'},{ts '2021-10-01 03:42:32.000'},N'78FY4327R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'89033885298898',N'Y 60',1270,80,N'94091266',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:14.000'},{ts '2021-10-01 03:40:14.000'},N'36FY06440');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'8938511728101',N'Y 1',2080,140,N'75515518',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:00.000'},{ts '2021-10-01 03:40:00.000'},N'36FY07590');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'89914300108572',N'Y 62',1570,100,N'42125559',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:14.000'},{ts '2021-10-01 03:40:14.000'},N'36FY06460');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'90202905955171',N'N 230',1170,70,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:40.000'},{ts '2021-10-01 03:42:40.000'},N'77FY9307R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'90294100709530',N'N 224',1140,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:08.000'},{ts '2021-10-01 03:44:08.000'},N'77FY7567R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'90622908421824',N'Y 207',2150,90,N'54270910',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:34.000'},{ts '2021-10-01 03:40:34.000'},N'36FY10230');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'90741484521130',N'Y 205',1600,170,N'28806613',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:34.000'},{ts '2021-10-01 03:40:34.000'},N'36FY05400');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'91022792469244',N'N 197',1320,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:36.000'},{ts '2021-10-01 03:42:36.000'},N'78FY3117R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'91024586753087',N'Y 47',1350,60,N'24653577',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:12.000'},{ts '2021-10-01 03:40:12.000'},N'36FY04760');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'91392228577203',N'N 5',1420,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:09.000'},{ts '2021-10-01 03:42:09.000'},N'36FY09710');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'91750548585212',N'N 154',1540,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:43:58.000'},{ts '2021-10-01 03:43:58.000'},N'76FY1707R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'91758601389178',N'Y 67',1110,80,N'90031366',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:15.000'},{ts '2021-10-01 03:40:15.000'},N'36FY07360');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'92653685073278',N'Y 25A',60,70,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:40:15.000'},{ts '2021-10-01 03:40:15.000'},N'745566300');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'92785837288472',N'Y 106',2160,90,N'65263971',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:20.000'},{ts '2021-10-01 03:40:20.000'},N'36FY08040');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'92804322378898',N'Y 104',1170,90,N'01424477',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:20.000'},{ts '2021-10-01 03:40:20.000'},N'36FY08020');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'93842048475941',N'Y 20',940,90,N'18328041',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:09.000'},{ts '2021-10-01 03:40:09.000'},N'36FY06850');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'94111178041223',N'N 191',660,220,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:35.000'},{ts '2021-10-01 03:42:35.000'},N'77FY5037R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'95062485710287',N'Y 185',1110,90,N'08581702',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:31.000'},{ts '2021-10-01 03:40:31.000'},N'36FY09860');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'95222287179979',N'N 169',1400,120,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:00.000'},{ts '2021-10-01 03:44:00.000'},N'78FY2497R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'95686350555637',N'Y 26',1930,130,N'25908651',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:10.000'},{ts '2021-10-01 03:40:10.000'},N'36FY02240');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'95852600372279',N'N 186',1080,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:44:03.000'},{ts '2021-10-01 03:44:03.000'},N'77FY6397R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'96455820481757',N'N 4',1260,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:09.000'},{ts '2021-10-01 03:42:09.000'},N'36FY09700');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'96466186180348',N'Y 83',1260,85,N'56484596',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:17.000'},{ts '2021-10-01 03:40:17.000'},N'36FY07800');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'96508248495642',N'Y 120',1770,170,N'88760979',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:22.000'},{ts '2021-10-01 03:40:22.000'},N'36FY08360');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'96567874465221',N'Y 28',1780,150,N'73033044',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:10.000'},{ts '2021-10-01 03:40:10.000'},N'36FY02270');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'97788967159774',N'N 168',1500,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:32.000'},{ts '2021-10-01 03:42:32.000'},N'78FY2487R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'97807443249080',N'N 167',1100,90,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:31.000'},{ts '2021-10-01 03:42:31.000'},N'78FY1757R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'97932534957020',N'Y 14',1260,90,N'87880143',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:08.000'},{ts '2021-10-01 03:40:08.000'},N'36FY06490');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'98336416261488',N'N 224',1140,80,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:39.000'},{ts '2021-10-01 03:42:39.000'},N'77FY7567R');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'99322263748897',N'N 41',1140,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:43:43.000'},{ts '2021-10-01 03:43:43.000'},N'36FY09840');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'99756400727031',N'Y 201',1570,190,N'73165196',N'000003',N'Cái',N'',{ts '2021-10-01 03:40:33.000'},{ts '2021-10-01 03:40:33.000'},N'36FY10180');
GO
INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) VALUES (
N'99891855037160',N'N 157',1770,100,N'75529856',N'000000',N'Cái',N'',{ts '2021-10-01 03:42:30.000'},{ts '2021-10-01 03:42:30.000'},N'77FY0067R');
GO
INSERT INTO [Stock] ([TonkhoID],[Barcode],[LoaiID],[Mieuta],[Soluongcon],[Ngaytao]) VALUES (
N'0000001',N'8691275000523',N'0000001',NULL,50,{ts '2021-01-10 00:00:00.000'});
GO
INSERT INTO [Stock] ([TonkhoID],[Barcode],[LoaiID],[Mieuta],[Soluongcon],[Ngaytao]) VALUES (
N'0000002',N'8938511728101',N'0000003',NULL,10000,{ts '2021-01-10 00:00:00.000'});
GO
INSERT INTO [Stock] ([TonkhoID],[Barcode],[LoaiID],[Mieuta],[Soluongcon],[Ngaytao]) VALUES (
N'0000003',N'8691275000523',N'0000002',NULL,40,{ts '2021-01-10 00:00:00.000'});
GO
INSERT INTO [Stock] ([TonkhoID],[Barcode],[LoaiID],[Mieuta],[Soluongcon],[Ngaytao]) VALUES (
N'0000004',N'8691275000523',N'0000003',NULL,30008,{ts '2021-01-10 00:00:00.000'});
GO
INSERT INTO [Stock] ([TonkhoID],[Barcode],[LoaiID],[Mieuta],[Soluongcon],[Ngaytao]) VALUES (
N'0000005',N'8938511728101',N'000004',NULL,30,{ts '2021-01-10 00:00:00.000'});
GO

