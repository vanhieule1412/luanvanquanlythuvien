using System;
using System.Collections.Generic;
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
    /// Interaction logic for PhieuMuonDocGiaWindow.xaml
    /// </summary>
    public partial class PhieuMuonDocGiaWindow : Window
    {
        UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        private PHIEUMUON PM = new PHIEUMUON();
        public LichSu ls;
        public PhieuMuonDocGiaWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            cmbMasach.ItemsSource = dc.SACHes.ToList();
            //cmbmataikhoan.ItemsSource = dc.TAIKHOANTHUTHUs.ToList();
                    
            DateTime ngaymuon = DateTime.Now;
            dpNgaymuon.SelectedDate = ngaymuon;
            DateTime ngaytra = ngaymuon.AddDays(30);
            dpNgaytradukien.SelectedDate = ngaytra;
        }
        
       

        private string PhatSinhTuDong(UngDungQuanLyThuVienEntities dc)
        {
            string s = "";
            var c = dc.PHIEUMUONs.Count();
            if (c == 0)
                s = "PM01";
            else
            {
                s = dc.PHIEUMUONs.ToList().ElementAt(c - 1).MaPhieuMuon;
                string sso = s.Substring(2);
                var so = int.Parse(sso);
                so++;
                s = "PM" + so;
            }
            return s;
        }
        private bool HasSpecialChars(string yourString)
        {
            return yourString.Any(ch => !Char.IsLetterOrDigit(ch));
        }
        private bool ktmathetontai(string n)
        {
            foreach (var a in dc.THEDOCGIAs)
            {
                if (a.MaTheDocGia == n)
                {
                    return true;
                }
            }
            return false;
        }
        private void BtnLapPM_Click(object sender, RoutedEventArgs e)
        {
            DateTime time = DateTime.Now;
            string s = PhatSinhTuDong(dc);
            PHIEUMUON x = new PHIEUMUON();
            x.MaPhieuMuon = s.Trim();
            if (cmbMasach.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn sách");
                return;
            }
         
            
            if (HasSpecialChars(txtmathedocgia.Text) == true)
            {
                MessageBox.Show("Mã thẻ không có khoảng trắng hoặc kí tự đặc biệt");
                txtmathedocgia.Focus();
                txtmathedocgia.Select(txtmathedocgia.Text.Length, 0);
                return;
            }
            if (dgChitiet.ItemsSource == null)
            {
                MessageBox.Show("Chưa chọn sách");
                return;
            }
            if (String.IsNullOrWhiteSpace(txtmathedocgia.Text) == true)
            {
                MessageBox.Show("Mã thẻ không để trắng");
                return;
            }
            if (ktmathetontai(txtmathedocgia.Text) == false)
            {
                MessageBox.Show("Mã thẻ không hợp lệ");
                return;
            }
            else
            {
                x.MaTheDocGia = txtmathedocgia.Text.Trim().ToUpper();
                x.NgayMuon = dpNgaymuon.SelectedDate.Value;
                x.NgayTraDukien = dpNgaytradukien.SelectedDate.Value;
                x.DaTra = false;
                //x.MaTheDocGia = txtmathedocgia.Text;
                foreach (CHITIETPHIEUMUON t in PM.CHITIETPHIEUMUONs)
                {
                    CHITIETPHIEUMUON ct = new CHITIETPHIEUMUON();
                    ct.MaPhieuMuon = t.MaPhieuMuon;
                    ct.MaSach = t.MaSach;
                    ct.TienPhat = 0;
                    ct.TinhTrang = t.TinhTrang;
                    ct.SoLuongSachMuon = t.SoLuongSachMuon;
                    x.CHITIETPHIEUMUONs.Add(ct);
                }
                dc.PHIEUMUONs.Add(x);
                dc.SaveChanges();
                hienthi();
                MessageBox.Show("Phiếu mượn " + s + " thêm thành công");
                this.Close();
            }
            //x.MaPhieuMuon = txtmaphieumuon.Text;
            
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            string ma = dgChitiet.SelectedValue.ToString();
            foreach (CHITIETPHIEUMUON t in PM.CHITIETPHIEUMUONs.Where(x => x.MaSach == ma))
            {
                PM.CHITIETPHIEUMUONs.Remove(t);
                break;
            }
            var kq = getChitietphieumuon(PM);
            dgChitiet.ItemsSource = kq.ToList();
        }
        private IEnumerable<object> getChitietphieumuon(PHIEUMUON pHIEUMUON)
        {
            var kq = pHIEUMUON.CHITIETPHIEUMUONs.ToList().Select(x => new {
                MaSach = x.MaSach,
                TenSach = x.SACH.TenSach,
                TacGia = x.SACH.TacGia,
                NamXuatBan = x.SACH.NamXuatBan,
                TinhTrang = x.TinhTrang,
                NgayTraThat = x.NgayTraThat,
                TienPhat = x.TienPhat,
                SoLuongSachMuon = x.SoLuongSachMuon,

            });
            return kq.ToList();
        }
        private void Btnchon_Click(object sender, RoutedEventArgs e)
        {
            int soluong = 0;
            string ma = cmbMasach.SelectedValue.ToString();
            SACH sACH = dc.SACHes.Find(ma);

            CHITIETPHIEUMUON temp = null;
            if (cmbMasach.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn sách");
                return;
            }

            if (cmbMasach.SelectedItem == null) return;
            foreach (CHITIETPHIEUMUON t in PM.CHITIETPHIEUMUONs.Where(x => x.MaSach == cmbMasach.SelectedValue.ToString()))
            {
                temp = t;
                break;
            }

            if (soluong == 0)
            {
                CHITIETPHIEUMUON ct = new CHITIETPHIEUMUON();
                ct.SACH = cmbMasach.SelectedItem as SACH;
                ct.MaSach = ct.SACH.MaSach;
                ct.SoLuongSachMuon = int.Parse(txtSoluongsachmuon.Text);
                if (sACH.SoLuong != 0)
                {
                    sACH.SoLuong -= ct.SoLuongSachMuon;
                }
                else
                {
                    MessageBox.Show("Sách đã hết");
                    return;
                }
                PM.CHITIETPHIEUMUONs.Add(ct);
            }
            else
            {
                sACH.SoLuong += temp.SoLuongSachMuon;
            }
            var kq = getChitietphieumuon(PM);
            dgChitiet.ItemsSource = kq.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
        }
    }
}
