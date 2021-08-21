using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLyThuVien.GiaoDien
{
    /// <summary>
    /// Interaction logic for DanhsachphieumuonthuthuWindow.xaml
    /// </summary>
    public partial class DanhsachphieumuonthuthuWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        PHIEUMUON PM = new PHIEUMUON();
        public DanhsachphieumuonthuthuWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            dgphieumuon.Items.SortDescriptions.Clear();
            dgphieumuon.Items.SortDescriptions.Add(new SortDescription("MaPhieuMuon", ListSortDirection.Descending));
            dgphieumuon.Items.Refresh();
            var filteredsach = dc.PHIEUMUONs.Where(x => x.TrangThai == false);
            dgphieumuon.ItemsSource = null;
            dgphieumuon.ItemsSource = filteredsach.ToList();
           

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
        }

        private void Dgphieumuon_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            PHIEUMUON pHIEUMUON = e.Row.Item as PHIEUMUON;
            DataGrid dg = e.DetailsElement.FindName("dgCTPM") as DataGrid;
            var kq = pHIEUMUON.CHITIETPHIEUMUONs.ToList().Select(x => new
            {
                MaSach = x.MaSach,
                TenSach = x.SACH.TenSach,
                TacGia = x.SACH.TacGia,
                NguoiDich = x.SACH.NguoiDich,
                TienPhat = x.TienPhat,
                NgayTraThat = x.NgayTraThat,
                TinhTrang = x.TinhTrang,
                SoLuongSachMuon = x.SoLuongSachMuon,
            });
            dg.ItemsSource = kq.ToList();
        }
        private bool ktmatktontai(int n)
        {
            foreach (var a in dc.TAIKHOANTHUTHUs)
            {
                if (a.MaTaiKhoai == n)
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsInt(string sVal)
        {
            foreach (char c in sVal)
            {
                int iN = (int)c;
                if ((iN > 57) || (iN < 48))
                    return false;
            }
            return true;
        }
        private bool HasSpecialChars(string yourString)
        {
            return yourString.Any(ch => !Char.IsLetterOrDigit(ch));
        }
        private void BtnDuyetPM_Click(object sender, RoutedEventArgs e)
        {
            string ma = txtmaphieumuon.Text;
            PHIEUMUON pHIEUMUON = dc.PHIEUMUONs.Find(ma);
            if (ma != null)
            {
                if (HasSpecialChars(txtmataikhoan.Text) == true)
                {
                    MessageBox.Show("Mã tài khoản không có khoảng trắng hoặc kí tự đặc biệt");
                    txtmataikhoan.Focus();
                    txtmataikhoan.Select(txtmataikhoan.Text.Length, 0);
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtthedocgia.Text) == true)
                {
                    MessageBox.Show("Chưa chọn phiếu mượn cần duyệt");
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtmataikhoan.Text) == true)
                {
                    MessageBox.Show("Mã tài khoản không để trống");
                    return;
                }
                if (ktmatktontai(int.Parse(txtmataikhoan.Text)) == false)
                {
                    MessageBox.Show("Mã tài khoản không hợp lệ");
                    return;
                }
                if (IsInt(txtmataikhoan.Text) == false)
                {
                    MessageBox.Show("Mã tài khoản phải là số");
                    return;
                }
                else
                {
                    if (rdbduocmuon.IsChecked == true)
                    {
                        pHIEUMUON.TrangThai = true;
                    }
                    else
                    {
                        pHIEUMUON.TrangThai = false;
                    }
                    
                    pHIEUMUON.TienPhatTong = 0;
                    pHIEUMUON.MaTaiKhoai = int.Parse(txtmataikhoan.Text);
                    dc.SaveChanges();
                    hienthi();
                }
            }
          
        }

        private void Dgphieumuon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PHIEUMUON pHIEUMUON = dgphieumuon.SelectedItem as PHIEUMUON;
            if (pHIEUMUON != null)
            {
                txtmaphieumuon.Text = pHIEUMUON.MaPhieuMuon;
                dpNgaymuon.SelectedDate = pHIEUMUON.NgayMuon;
                dpNgaytradukien.SelectedDate = pHIEUMUON.NgayTraDukien;
                if (pHIEUMUON.TrangThai.ToString() == "Được mượn")
                {
                    rdbduocmuon.IsChecked = true;
                }
                else {
                    rdbkhongduocmuon.IsChecked = true;
                }
                if (pHIEUMUON.DaTra.ToString() == "Đã trả")
                {
                    rdbdatra.IsChecked = true;
                }
                else
                {
                    rdbchuatra.IsChecked = true;
                }
                txtmataikhoan.Text = pHIEUMUON.MaTaiKhoai.ToString();
                txtthedocgia.Text = pHIEUMUON.MaTheDocGia;
               

            }
            else
            {
                txtmaphieumuon.Text = "";
                dpNgaymuon.SelectedDate = null;
                dpNgaytradukien.SelectedDate = null;
                rdbchuatra.IsChecked = true;
                rdbkhongduocmuon.IsChecked = true;
                txtmataikhoan.Text = "";
                txtthedocgia.Text = "";
                return;
            }

        }
      
    }
}
