
											
										--NGUYỄN VĨNH KỲ - DTH195150--

create database QLNV

go

use QLNV

go

--Chức Vụ
--Nhân Viên
--Quá trình Lương

--Tạo bảng chức vụ

create table chucvu
(
	macv nvarchar(5) primary key,
	tencv nvarchar(50) not null,
	hsphucap float
)

go

--Tạo bảng nhân viên

create table nhanvien
(
	manv nvarchar(5) primary key,
	holot nvarchar(50) not null,
	tennv nvarchar(10) not null,
	phai nvarchar(3) check (phai = N'Nam' or phai = N'Nữ') default N'Nam',
	ngaysinh smalldatetime,
	macv nvarchar(5) not null foreign key(macv) references chucvu(macv)
)

go

--Tạo bảng quá trình lương

create table quatrinhluong
(
	manv nvarchar(5) not null foreign key(manv) references nhanvien(manv),
	ngaybd smalldatetime,
	hsluong float not null,
	ghichu bit,
	primary key(manv, ngaybd)
)

go

--Chèn chức vụ vào bảng chức vụ

insert into chucvu values(N'TP', N'Trưởng Phòng', 0.5);
insert into chucvu values(N'PP', N'Phó Trưởng Phòng', 0.45);
insert into chucvu values(N'CV', N'Chuyên Viên', 0.3);
insert into chucvu values(N'KT', N'Kế Toán', 0.25);
insert into chucvu values(N'LX', N'Lái Xe Cơ Quan', 0.25);

go

--Chèn dữ liệu vào bảng nhân viên

insert into nhanvien values(N'NV001', N'Nguyễn Phước Minh', N'Tân', N'Nam','1975-04-19', N'TP');
insert into nhanvien values(N'NV002', N'hà Thị Thanh', N'Nhàn', N'Nữ','1964-03-09', N'PP');
insert into nhanvien values(N'NV003', N'Văn Minh', N'Tú', N'Nam','1960-02-15', N'CV');
insert into nhanvien values(N'NV004', N'Lý Văn', N'Sang', N'Nam','1970-12-21', N'CV');
insert into nhanvien values(N'NV005', N'Nguyễn Thị Thu', N'An', N'Nữ','1981-08-22', N'PP');
insert into nhanvien values(N'NV006', N'Nguyễn Thanh', N'Tùng', N'Nam','1963-04-29', N'LX');
insert into nhanvien values(N'NV007', N'trần Văn', N'Sơn', N'Nam','1999-02-06', N'CV');
insert into nhanvien values(N'NV008', N'Cao Thị Ngọc', N'Nhung', N'Nữ','1995-07-12', N'KT');
insert into nhanvien values(N'NV009', N'Lê Thành', N'Tấn', N'Nam','1975-03-16', N'CV');
insert into nhanvien values(N'NV010', N'Phan Thị Thủy', N'Tiên', N'Nữ','1985-02-21', N'KT');

go

--Chèn dữ liệu vào bảng quá trình lương

go

insert into quatrinhluong values(N'NV003', '2001-01-01', 2.34, 0);
insert into quatrinhluong values(N'NV001', '2001-01-01', 4.4, 0);
insert into quatrinhluong values(N'NV002', '2001-01-01', 4.4, 0);
insert into quatrinhluong values(N'NV008', '2001-01-01', 1.86, 0);
insert into quatrinhluong values(N'NV004', '2002-06-01', 2.06, 0);
insert into quatrinhluong values(N'NV008', '2003-01-01', 2.67, 0);
insert into quatrinhluong values(N'NV003', '2004-01-01', 4.74, 0);
insert into quatrinhluong values(N'NV002', '2004-01-01', 4.74, 0);
insert into quatrinhluong values(N'NV001', '2005-01-01', 2.26, 0);
insert into quatrinhluong values(N'NV008', '2005-06-01', 2.67, 0);
insert into quatrinhluong values(N'NV004', '2005-06-01', 4.4, 0);
insert into quatrinhluong values(N'NV005', '2005-06-01', 2.05, 0);
insert into quatrinhluong values(N'NV006', '2007-01-01', 2.46, 0);
insert into quatrinhluong values(N'NV008', '2007-01-01', 2.34, 0);
insert into quatrinhluong values(N'NV009', '2007-01-01', 3.0, 0);
insert into quatrinhluong values(N'NV003', '2007-01-01', 5.08, 0);
insert into quatrinhluong values(N'NV001', '2007-06-01', 2.23, 0);
insert into quatrinhluong values(N'NV006', '2008-06-01', 4.74, 0);
insert into quatrinhluong values(N'NV007', '2010-01-01', 5.42, 1);
insert into quatrinhluong values(N'NV008', '2010-01-01', 2.67, 1);
insert into quatrinhluong values(N'NV006', '2010-06-01', 2.06, 1);
insert into quatrinhluong values(N'NV001', '2011-01-01', 2.86, 1);
insert into quatrinhluong values(N'NV009', '2011-06-01', 5.08, 1);
insert into quatrinhluong values(N'NV010', '2011-06-01', 2.67, 1);
insert into quatrinhluong values(N'NV008', '2011-06-01', 2.59, 1);

go

--Câu a) Cho biết các nhân viên có mã chức vụ là 'CV'

	select manv as N'Mã nhân viên', holot +' '+ tennv as N'Họ và tên', phai as N'Giới tính', ngaysinh as N'Ngày sinh', macv as N'Mã chức vụ' from nhanvien where macv = N'CV'

--Câu b) cho biết tên nhân viên có chứa ký tự 't'

	select manv as N'Mã nhân viên', holot +' '+ tennv as N'Họ và tên', phai as N'Giới tính', ngaysinh as N'Ngày sinh', macv as N'Mã chức vụ' from nhanvien where tennv like N'%t%'

--Câu C) Cho biết các nhân viên có ngày sinh trong tháng 8

	select manv as N'Mã nhân viên', holot +' '+ tennv as N'Họ và tên', phai as N'Giới tính', ngaysinh as N'Ngày sinh', macv as N'Mã chức vụ' from nhanvien where MONTH(ngaysinh) = '08'

--Câu D) Cho biết các nhân viên có hệ số lương dưới 3.0

	select nv.manv, nv.holot, nv.tennv, nv.phai, nv.ngaysinh, qtl.hsluong from nhanvien as nv, quatrinhluong as qtl where nv.manv = qtl.manv and nv.manv not in (select qtl.manv from quatrinhluong where qtl.hsluong > 3.0)

--Câu E) Cho biết nhân viên không còn công tác nữa

	select manv as N'Mã nhân viên', holot +' '+ tennv as N'Họ và tên', phai as N'Giới tính', ngaysinh as N'Ngày sinh', macv as N'Mã chức vụ' from nhanvien where manv not in (select manv from quatrinhluong where ghichu = 1)

--Câu F) Cho biết các nhân viên được nâng lương trong các năm 2009, 2010. Thông tin gồm: Họ tên, Hệ số lương, Tháng-năm nâng lương.

	select nv.holot +' '+ nv.tennv as N'Họ và tên', qtl.hsluong as N'Hệ số lương', qtl.ngaybd as N'Tháng - Năm nâng lương' from nhanvien as nv, quatrinhluong as qtl where nv.manv = qtl.manv and year(ngaybd) between '2009' and '2010'

--Câu h) Tính tổng số nhân viên theo từng chức vụ.

	select  C.tencv AS 'Tên chức vụ', COUNT(N.manv) AS 'Số lượng nhân viên' FROM nhanvien AS N, chucvu AS C WHERE N.macv = C.macv GROUP BY C.tencv

--Câu i) Cho biết các nhân viên có tuổi nhỏ hơn độ tuổi trung bình, gồm: Họ tên, Giới tính, Tuổi.

	select manv as N'Mã nhân viên', holot + ' ' + tennv as N'Họ và tên', phai as N'Giới tính', DATEDIFF(YEAR, ngaysinh, GETDATE()) AS 'Tuổi' from nhanvien where  DATEDIFF(YEAR, ngaysinh, GETDATE()) < (SELECT AVG(DATEDIFF(YEAR, ngaysinh, GETDATE())) from nhanvien)

--Câu j) Cho biết tổng số nhân viên nam, tổng số nhân viên nữ đang công tác.

	select phai as 'Giới tính', count(phai) as N'Số lượng nhân viên' from nhanvien group by phai

--Câu k) Cho biết các nhân viên đã được nâng lương trên 3 lần.

	select nv.manv as N'Mã nhân viên', nv.holot + ' ' + nv.tennv as N'Họ và tên', nv.phai as N'Giới tính', count(nv.manv) as N'Số lần tăng lương' from nhanvien as nv, quatrinhluong as qtl where nv.manv = qtl.manv group by nv.manv, nv.holot + ' ' + nv.tennv, nv.phai HAVING COUNT(nv.manv) > 3

--Câu l) Cập nhật tên chức vụ có mã “CV” thành “Nhân viên chuyên trách”.

	update chucvu set tencv = N'Nhân viên chuyên trách' where macv = 'CV'

--Câu m) Xóa các nhân viên hiện không còn công tác nữa (ghichu=0).

	--Xóa khóa phụ
	DELETE quatrinhluong where ghichu = 0

	--Xóa khóa chính
	DELETE nhanvien where manv NOT IN (select manv from quatrinhluong)
