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

            
            //string ma = dc.PHIEUMUONs.Find(f.tblmataikhoan.Text).ToString();
            //var kq = pHIEUMUON.THEDOCGIA.MaTaiKhoai.ToList().Where(x => x. == ma);
            //dgphieumuon.ItemsSource = kq.ToList();
            dgphieumuon.ItemsSource = dc.PHIEUMUONs.ToList();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgphieumuon.Items.SortDescriptions.Clear();
            dgphieumuon.Items.SortDescriptions.Add(new SortDescription("MaPhieuMuon", ListSortDirection.Descending));
            dgphieumuon.Items.Refresh();
            hienthi();

        }

        private void Btnmolapphieu_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.PhieuMuonDocGiaWindow phieuMuon = new PhieuMuonDocGiaWindow();
            this.Hide();
            phieuMuon.ShowDialog();
            phieuMuon.Close();
            dgphieumuon.Items.SortDescriptions.Clear();
            dgphieumuon.Items.SortDescriptions.Add(new SortDescription("MaPhieuMuon", ListSortDirection.Descending));
            dgphieumuon.Items.Refresh();
            hienthi();
            this.ShowDialog();

        }

        private void Dgphieumuon_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {

        }
    }
}
