   M S B A M L   `   `   `  ����H  DQuanLyThuVien, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:QuanLyThuVien.GiaoDienQuanLyThuVien.GiaoDien  5   	   +    %QuanLyThuVien.GiaoDien.PhieuTraWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:QuanLyThuVien.GiaoDien     5   	   -   5          � Title$  PhieuTraWindow��5   	   $	��600��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      �� $��0,0,0,-2q�6   .+�5   
   �� $��Quản lý phiếu trả��6   $��Center=�6,   $��20(�6P   $
��Bold"�6^   �� 5   
   �� 5   
   $��Tìm kiếm��6   �� 5   
   -   5        $��
txttimkiem��5      $��60��6I   $
��Left=�6T   �� 5   
   �� 5   
   $��Thông tin phiếu trả��6   .��5      �  � ColumnDefinitions 5      �� 5      �� 5      �� 5       � RowDefinitions 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      .+�5$      �� $��0��6   $��6��6,   $��Ngày mượn��69   �� 5%      $��0��6   $��7��6,   $��Ngày trả dự kiện��69   �� 5&      $��0��6   $��3��6,   $��Trạng thái��69   �� 5'      $��0��6   $��4��6,   $��Tiền phạt tổng��69   �� 5(      $��0��6   $��1��6,   $��Mã thủ thư��69   �� 5)      $��0��6   $��2��6,   $��Mã độc giả��69   �� 5*      $��0��6   $��0��6,   $��Mã Phiếu mượn��69   �� 5+      $��0��6   $��8��6,   $��
Đã trả��69   �� 5,      -   5        $��cmbMaThuThu��5,   J   $��1��6   $��1��6+   {�.   �� SelectedValuePath$ 
MaTaiKhoai��6]    �� DisplayMemberPath$ 
MaTaiKhoai��6|   �� 5-      -   5        $��cmbMaDocGia��5-   J   $��1��6   $��2��6+   {�.  $ MaTheDocGia��6]   $ MaTheDocGia��6}   (  "System.Windows.Controls.DatePicker  5.      -   5        $��
dpNgayMuon��5.   L   $��1��6   $��6��6-   {�.  $��24��6^   $	��Top=�6j     5/      -   5        $��	dpNgayTra��5/   L   $��1��6   $��7��6-   {�.  6L   �� 50      -   5        $��cmbtrangthai��50   8   $��1��6   $��3��6+   {�.   �� SelectedItem$ 	TrangThai��6^   .@�51      �� -   5        $��cmbduocmuon��51   #   $��Được mượn��66   �� 52      -	   5        $��cmbkhongduocmuon��52   #   $��Không được mượn��6;   53      �� 54      -
   5        $��ckbdatra��54      $��1��6+   $��8��6;   {�.  6H   �� 55      -   5        $��txttienphattong��55   7   $��1��6   $��4��6*    �� 
IsReadOnly . $��0��6`   � 57      $��2��6   $��1��6,   .+�58      �� $��Tên thủ thư: ��6    �� 59      ��6    ��  �� ElementName$ cmbMaThuThu��	 �� Path$	 SelectedItem.TenTaiKhoai�5:      � 5;      $��2��6   $��2��6,   .+�5<      �� $��Tên độc giả: ��6    �� 5=      ��6    �� $ cmbMaDocGia��$	 SelectedItem.TenDocGia�5>      � 5?      $��2��6   $��4��6,   $��Center=�69   .+�5@      �� -   5        $��ckbchopheptra��5@      $��Cho phép trả��64   6K   5A      �� 5B      -   5        $��txtmaphieumuon��5B   7   $��1��6   $��0��6*    . 6M   5C      5D      �� 5E   
   -   5        $��btnlapphieutra��5E   .   $��0��6   $��0��6!   $1��+Thông tin chi tiết của phiếu mượn��6D   $y�Visible=�6p   6�   �� 5F   
   -   5        $��
btnxacnhan��5F   .   $��0��6   $��0��6!   $��Xác nhận đã trả��6@   $y�	Collapsed=�6Z   6q   �� 5I   
   $��Danh sách phiếu trả��6   .��5J      &   System.Windows.Controls.DataGrid  -   5        $��
dgphieutra��5J      $	��200��6)   
   
IsReadOnly
 .    AutoGenerateColumns .     CanUserAddRows .  $ MaPhieuMuon��6�   $��
0,0,0,-150q�6�      Columns 5K      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã Phiếu Mượn��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *MaPhieuMuon+  5M      $ Ngày mượn��6)    6<   �� *
NgayMuon+ �� StringFormat$ 
dd/MM/yyyy��  5N      $ Ngày trả dự kiến��6)    6C   �� *NgayTraDukien+$ 
dd/MM/yyyy��4  .System.Windows.Controls.DataGridCheckBoxColumn  5O      $ Trạng thái��6-    6A   �� *	TrangThai+  5P      $ Tiền phạt tổng��6)    6A   �� *TienPhatTong+$ {0:#,##0.## đ}��  5Q      $ 
Đã trả��6-    6=   �� *DaTra+  5R      $! Mã tài khoản thủ thư��6)    6G   �� *
MaTaiKhoai+  5S      $" Tên tài khoản thủ thư��6)    6H   �� *TAIKHOANTHUTHU.TenTaiKhoai+  5T      $ Mã thẻ độc giả��6)    6A   �� *MaTheDocGia+  5U      $ Tên độc giả��6)    6>   �� *THEDOCGIA.TenDocGia+   RowDetailsTemplate 5W      �� 5X      .R�5Y      9� .��5Z      �� .+�5[   "     $��dgCTPT��6+    .   5\   &     5]   *   $ 	Mã Sách��6=    6N   �� *MaSach+  5^   *   $ 
Tên Sách��6=    6O   �� *	TenSach+  5_   *   $ 
Tác Giả��6=    6N   �� *TacGia+  5`   *   $ Năm Xuất Bản��6=    6S   �� *
NamXuatBan+  5a   *   $ Tình trạng��6=    6Q   �� *	TinhTrang+  5b   *   $ Ngày trả thật��6=    6T   �� *NgayTraThat+$ 
dd/MM/yyyy��  5c   *   $ Tiền Phạt��6=    6P   �� *
TienPhat+$ {0:#,##0.## đ}��  5d   *   $! Số lượng sách mượn��6=    6Y   �� *SoLuongSachMuon+5f   #   5g      5h      5i      5k      5l      5m      5n      