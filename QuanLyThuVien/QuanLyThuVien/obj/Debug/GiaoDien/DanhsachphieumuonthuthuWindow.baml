   M S B A M L   `   `   `  ����H  DQuanLyThuVien, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:QuanLyThuVien.GiaoDienQuanLyThuVien.GiaoDien  5   	   :    4QuanLyThuVien.GiaoDien.DanhsachphieumuonthuthuWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:QuanLyThuVien.GiaoDien     5   	   -   5          � Title$#  DanhsachphieumuonthuthuWindow��5   	   $	��450��6/   $	��800��6<    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      �� .+�5   
   �� $%��Danh sách các phiếu mượn��6   $��Center=�63   $��20(�6W   $
��Bold"�6e   �� 5   
   �� 5   
   -   5        $��gbphieumuon��5   1   $ ��Thông tin phiếu mượn��6   .��5      �  � ColumnDefinitions 5      �� 5      �� 5      �� 5       � RowDefinitions 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5!      �� $��0��6   $��0��6,   $��Mã phiếu mượn��69   �� 5"      $��0��6   $��1��6,   $��Ngày mượn��69   �� 5#      $��0��6   $��2��6,   $��Ngày trả dự kiến��69   �� 5$      $��0��6   $��3��6,   $��Trạng thái��69   �� 5%      $��0��6   $��4��6,   $��Tiền phạt tổng��69   �� 5&      $��0��6   $��5��6,   $��
Đã trả��69   �� 5'      $��0��6   $��6��6,   $��Mã Tài khoản thu thư��69   �� 5(      $��0��6   $��7��6,   $��Mã thẻ độc giả��69   �� 5)      -   5        $��txtmaphieumuon��5)   7   $��1��6   $��0��6*    �� 
IsReadOnly . 6M   (  "System.Windows.Controls.DatePicker  5*      -   5        $��
dpNgaymuon��5*   :   $��1��6   $��1��6-   {�.  6L     5+      -   5        $��dpNgaytradukien��5+   :   $��1��6   $��2��6-   {�.  6Q   � 5,      $��1��6   $��3��6,   .+�5-      	� -   5        $��rdbduocmuon��5-   "   $��Được mượn��65   	� 5.      -   5        $��rdbkhongduocmuon��5.   "   $��Không được mượn��6:    d� 	IsChecked$
 TrueY�6U   5/      �� 50      -   5        $��txttienphattong��50   7   $��1��6   $��4��6*    . 6N   � 51      $��1��6   $��5��6,   {�.  .+�52      	� -	   5        $��rdbdatra��52   #   $��
Đã trả��63   	� 53      -
   5        $��
rdbchuatra��53   #   $��Chưa trả��65   $
 TrueY�6H   54      �� 55      -   5        $��txtmataikhoan��55   7   $��1��6   $��6��6*   67   �� 56      -   5        $��txtthedocgia��56   7   $��1��6   $��7��6*   67   �� 57      -   5        $��
btnDuyetPM��57   6   $��2��6   $��0��6)   $��Duyệt phiếu mượn��6H   $��21��6|   $	��Top=�6�   58      59      �� 5:   
   $.��(Danh sách phiếu mượn chờ duyệt��6   .��5;      &   System.Windows.Controls.DataGrid  -   5        $��dgphieumuon��5;         
IsReadOnly .    AutoGenerateColumns .  $	��160��6X      CanUserAddRows .  	   Columns	 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Mã Phiếu Mượn��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *MaPhieuMuon+  5>      $
 Ngày mượn��6)    6<   �� *
NgayMuon+ �� StringFormat$ 
dd/MM/yyyy��  5?      $
 Ngày trả dự kiến��6)    6C   �� *NgayTraDukien+$ 
dd/MM/yyyy��4  .System.Windows.Controls.DataGridCheckBoxColumn  5@      $
 Trạng thái��6-    6A   �� *	TrangThai+  5A      $
 Tiền phạt tổng��6)    6A   �� *TienPhatTong+$ {0:#,##0.## đ}��  5B      $
 
Đã trả��6-    6=   �� *DaTra+  5C      $!
 Mã tài khoản thủ thư��6)    6G   �� *
MaTaiKhoai+  5D      $"
 Tên tài khoản thủ thư��6)    6H   �� *TAIKHOANTHUTHU.TenTaiKhoai+  5E      $
 Mã thẻ độc giả��6)    6A   �� *MaTheDocGia+  5F      $
 Tên độc giả��6)    6>   �� *THEDOCGIA.TenDocGia+   RowDetailsTemplate 5H      �� 5I      .R�5J      �� .+�5K        $��dgCTPM��6'    .   . 	 5L   "     5M   &   $
 	Mã Sách��69    6J   �� *MaSach+  5N   &   $
 
Tên Sách��69    6K   �� *	TenSach+  5O   &   $
 
Tác Giả��69    6J   �� *TacGia+  5P   &   $
 Năm Xuất Bản��69    6O   �� *
NamXuatBan+  5Q   &   $
 Tình trạng��69    6M   �� *	TinhTrang+  5R   &   $
 Ngày trả thật��69    6P   �� *NgayTraThat+$ 
dd/MM/yyyy��  5S   &   $
 Tiền Phạt��69    6L   �� *
TienPhat+$ {0:#,##0.## đ}��  5T   &   $!
 Số lượng sách mượn��69    6U   �� *SoLuongSachMuon+5V      5W      5Y      5\      5]      5^      5_      