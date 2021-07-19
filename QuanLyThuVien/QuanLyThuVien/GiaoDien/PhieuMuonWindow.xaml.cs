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
    /// Interaction logic for PhieuMuonWindow.xaml
    /// </summary>
    public enum KieuPhepToan {Them,Sua }
    public partial class PhieuMuonWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public KieuPhepToan pheptoan;
        public SACH sACH;
        public PHIEUMUON pHIEUMUON ;
        public PHIEUMUON HIEUMUON = new PHIEUMUON();
        public CHITIETPHIEUMUON sACH_PHIEUMUON;
        public PhieuMuonWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbMaThuThu.ItemsSource = dc.TAIKHOANTHUTHUs.ToList();
            cmbMasach.ItemsSource = dc.SACHes.ToList();
            cmbMaDocGia.ItemsSource = dc.THEDOCGIAs.ToList();
            if (pheptoan == KieuPhepToan.Sua)
            {
                txtmaphieumuon.Text = pHIEUMUON.MaPhieuMuon;
                cmbMaThuThu.SelectedValue = pHIEUMUON.TAIKHOANTHUTHU.MaTaiKhoai;
                cmbMaDocGia.SelectedValue = pHIEUMUON.THEDOCGIA.MaTheDocGia;
                //dpNgayMuon.SelectedDate = pHIEUMUON.NgayMuon;
                dpNgayTra.SelectedDate = pHIEUMUON.NgayTraDukien;
                if (cmbtrangthai.SelectedItem.ToString() == "Đã Trả" )
                    cmbtrangthai.SelectedItem = "Đã Trả";
                else
                    cmbtrangthai.SelectedItem = "Chưa Trả";
                if (pHIEUMUON.DaTra.ToString() == "Đã Trả")
                {
                    ckbdatra.IsChecked = true;
                }
                else
                {
                    ckbdatra.IsChecked = false;
                }
                txttienphattong.Text = pHIEUMUON.TienPhatTong.ToString();

               dgChitiet.ItemsSource = pHIEUMUON.CHITIETPHIEUMUONs;               
            }
        }

        private void Btnchon_Click(object sender, RoutedEventArgs e)
        {
            CHITIETPHIEUMUON temp = null;
           
            if (cmbMasach.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn sách");
                return;
            }

            if (cmbMasach.SelectedItem == null) return;
            foreach (CHITIETPHIEUMUON t in HIEUMUON.CHITIETPHIEUMUONs.Where(x => x.MaSach == cmbMasach.SelectedValue.ToString()))
            {
                temp = t;
                break;
            }
            if (temp == null)
            {

                CHITIETPHIEUMUON ct = new CHITIETPHIEUMUON();
                ct.SACH = cmbMasach.SelectedItem as SACH;
                ct.MaSach = ct.SACH.MaSach;
                ct.TinhTrang = ct.TinhTrang;
                ct.SoLuongSachMuon = int.Parse(txtSoluong.Text);
                HIEUMUON.CHITIETPHIEUMUONs.Add(ct);

            }
            else
            {
                temp.SoLuongSachMuon += int.Parse(txtSoluong.Text);
            }


            var kq = getChitietphieumuon(HIEUMUON);

            dgChitiet.ItemsSource = kq.ToList();

        }
        private IEnumerable<object> getChitietphieumuon(PHIEUMUON pHIEUMUON)
        {
            var kq = pHIEUMUON.CHITIETPHIEUMUONs.ToList().Select(x => new
            {
                MaSach = x.MaSach,
                TenSach = x.SACH.TenSach,
                TacGia = x.SACH.TacGia,
                NguoiDich = x.SACH.NguoiDich,
                NgayTraThat=x.NgayTraThat,
                TienPhat=x.TienPhat,
                TinhTrang=x.TinhTrang,
                SoLuongSachMuon = x.SoLuongSachMuon,

            });
            return kq.ToList();
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            string masach = dgChitiet.SelectedValue.ToString();
            foreach (CHITIETPHIEUMUON t in HIEUMUON.CHITIETPHIEUMUONs.Where(x => x.MaSach == masach))
            {
                HIEUMUON.CHITIETPHIEUMUONs.Remove(t);
                break;
            }
            var kq = getChitietphieumuon(HIEUMUON);
            dgChitiet.ItemsSource = kq.ToList();

        }

        private void Btnlapphieumuon_Click(object sender, RoutedEventArgs e)
        {
            pHIEUMUON = new PHIEUMUON();
            
            pHIEUMUON.MaPhieuMuon = txtmaphieumuon.Text;
            pHIEUMUON.MaTaiKhoai =int.Parse(cmbMaThuThu.SelectedValue.ToString());
            pHIEUMUON.MaTheDocGia = cmbMaDocGia.SelectedValue.ToString();
            pHIEUMUON.NgayMuon = dpNgayMuon.SelectedDate.Value.ToLongDateString().ToString();
            pHIEUMUON.NgayTraDukien = dpNgayTra.SelectedDate.Value.Date;
            if (cmbtrangthai.SelectedItem.ToString() == "Không được mượn")
            {
                pHIEUMUON.TrangThai = false;
            }
            else
            {
                pHIEUMUON.TrangThai = true;
            }
            // x.TienPhat = int.Parse(txttienphat.Text);

            this.DialogResult = true;
            this.Close();
        }
    }
}
