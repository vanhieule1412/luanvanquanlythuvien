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
    /// Interaction logic for LichsutraWindow.xaml
    /// </summary>
    public partial class LichsutraWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public PHIEUMUON PHIEUMUON;
        public LichsutraWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MainWindow mainWindow = new MainWindow();
            //var filteredsach = dc.PHIEUMUONs.Where(x => x.MaTheDocGia.Contains(mainWindow.tblthedocgia.Text));
            var filteredsach = dc.PHIEUMUONs.Where(x => x.MaTheDocGia == PHIEUMUON.MaTheDocGia);
            filteredsach = dc.PHIEUMUONs.Where(x => x.DaTra.Value == true);
            dgptls.ItemsSource = null;
            dgptls.ItemsSource = filteredsach.ToList();
        }

        private void Dgptls_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            PHIEUMUON = e.Row.Item as PHIEUMUON;
            DataGrid dg = e.DetailsElement.FindName("dgCTPM") as DataGrid;
            var kq = PHIEUMUON.CHITIETPHIEUMUONs.ToList().Select(x => new {
                MaSach = x.MaSach,
                TenSach = x.SACH.TenSach,
                TacGia = x.SACH.TacGia,
                NamXuatBan = x.SACH.NamXuatBan,
                TinhTrang = x.TinhTrang,
                NgayTraThat = x.NgayTraThat,
                TienPhat = x.TienPhat,
                SoLuongSachMuon = x.SoLuongSachMuon,
            });
            dg.ItemsSource = kq.ToList();
        }
    }
}
