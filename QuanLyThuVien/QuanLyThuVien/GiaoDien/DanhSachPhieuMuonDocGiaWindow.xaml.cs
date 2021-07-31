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
    /// Interaction logic for DanhSachPhieuMuonDocGiaWindow.xaml
    /// </summary>
    public partial class DanhSachPhieuMuonDocGiaWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public PHIEUMUON pHIEUMUON;
        public DanhSachPhieuMuonDocGiaWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            //MainWindow f = new MainWindow();
            //string ma = dc.TAIKHOANDOCGIAs.Find(f.tblmataikhoan.Text).ToString();
            //var kq = pHIEUMUON.CHITIETPHIEUMUONs.ToList().Select(x => new
            //{
            //    MaSach = x.MaSach,
            //    TenSach = x.SACH.TenSach,
            //    TacGia = x.SACH.TacGia,
            //    NguoiDich = x.SACH.NguoiDich,
            //    TienPhat = x.TienPhat,
            //    NgayTraThat = x.NgayTraThat,
            //    TinhTrang = x.TinhTrang,
            //    SoLuongSachMuon = x.SoLuongSachMuon,
            //});
            //dg.ItemsSource = kq.ToList();
            //var kq = pHIEUMUON.THEDOCGIA.MaTaiKhoai.ToList().Where(x => x. == ma);
            //dgphieumuon.ItemsSource = kq.ToList();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
        }

        private void Btnmolapphieu_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.PhieuMuonDocGiaWindow phieuMuon = new PhieuMuonDocGiaWindow();
            this.Hide();
            phieuMuon.ShowDialog();
            phieuMuon.Close();
            hienthi();
            this.ShowDialog();

        }

        private void Dgphieumuon_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {

        }
    }
}
