   M S B A M L   `   `   `  ����H  DQuanLyThuVien, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:QuanLyThuVien.GiaoDienQuanLyThuVien.GiaoDien  5   	   1    +QuanLyThuVien.GiaoDien.HeThongTimKiemWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:QuanLyThuVien.GiaoDien     5   	   -   5          � Title$  HeThongTimKiemWindow��5   	   $	��450��6&   $	��800��63    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      �� .+�5   
   �  � ColumnDefinitions 5      �� 5      �� 5      �� 5       � RowDefinitions 5      �� 5      �� 5      �� 5      .+�5      �� $��0��6   $��0��6(   $��Tìm kiếm��65   �� 5      -   5        $��
txttimkiem��5   3   $��0��6   $��1��6&   6E   �� 5      $��1��6   $��1��6'   .@�5      �� -   5        $��	cmbtimten��5       �� 
IsSelected . $��Tìm theo tên sách��6B   �� 5      -   5        $��cmbtimnamxuatban��5      $!��Tìm theo năm xuất bản��67   5      5      &   System.Windows.Controls.DataGrid  5    
   -   5        $��	dgtimkiem��5          AutoGenerateColumns .   �� SelectedValuePath$ MaSach��6@      CanUserAddRows .     Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn	   Header$	 	Mã Sách��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 66   �� *MaSach+  5#      $	 
Tên Sách��6%   
 67   �� *	TenSach+  5$      $	 Số Lượng��6%   
 67   �� *	SoLuong+  5%      $	 
Tác Giả��6%   
 66   �� *TacGia+  5&      $	 Năm xuất bản��6%   
 6;   �� *
NamXuatBan+  5'      $	 Người dịch��6%   
 69   �� *	NguoiDich+  5(      $	 Mã thể loại��6%   
 6:   �� *	MaTheLoai+  5)      $	 Tên thể loại��6%   
 6;   �� *THELOAI.TenTheLoai+  5*      $	 Mã nhà xuất bản��6%   
 6>   �� *MaNhaXuatBan+  5+      $	 Tên nhà xuất bản��6%   
 6?   �� *NHAXUATBAN.TenNhaXuatBan+  5,      $	 Mã kệ��6%   
 64   �� *MaKe+  5-      $	 	Tên kệ��6%   
 65   �� *
KE.TenKe+  5.      $	 Tên khu��6%   
 66   �� *KE.KHU.TenKhu+  5/      $	 Nội dung tóm tắt��6%   
 6?   �� *NoiDungTomTat+  50      $
	 Giá��6%   
 62   �� *Gia+  51      $	 Tên file hình��6%   
 6<   �� *	HinhAnh+54      55      56      