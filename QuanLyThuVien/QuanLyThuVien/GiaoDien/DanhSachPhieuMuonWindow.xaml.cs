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
    /// Interaction logic for DanhSachPhieuMuonWindow.xaml
    /// </summary>
    public partial class DanhSachPhieuMuonWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
       

        public DanhSachPhieuMuonWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            dgphieumuon.Items.SortDescriptions.Clear();
            dgphieumuon.Items.SortDescriptions.Add(new SortDescription("MaPhieuMuon", ListSortDirection.Descending));
            dgphieumuon.Items.Refresh();
            dgphieumuon.ItemsSource = dc.PHIEUMUONs.ToList();
            //var filteredsach = dc.PHIEUMUONs.Where(x => x.TrangThai == false);
            //dgphieumuon.ItemsSource = null;
            //dgphieumuon.ItemsSource = filteredsach.ToList();

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
                TienPhat=x.TienPhat,
                NgayTraThat=x.NgayTraThat,
                TinhTrang=x.TinhTrang,
                SoLuongSachMuon = x.SoLuongSachMuon,
            });
            dg.ItemsSource = kq.ToList();
             

        }
        private void Btnlap_Click(object sender, RoutedEventArgs e)
        {
            //GiaoDien.PhieuMuonWindow fphieumuon = new PhieuMuonWindow();
            //fphieumuon.pheptoan = KieuPhepToan.Them;
            //if (fphieumuon.ShowDialog() == true)
            //{
            //    foreach (CHITIETPHIEUMUON t in fphieumuon.HIEUMUON.CHITIETPHIEUMUONs)
            //    {
            //        CHITIETPHIEUMUON ct = new CHITIETPHIEUMUON();
            //        ct.MaPhieuMuon = t.MaPhieuMuon;
            //        ct.MaSach = t.MaSach;
            //        ct.SoLuongSachMuon = t.SoLuongSachMuon;
            //        fphieumuon.pHIEUMUON.CHITIETPHIEUMUONs.Add(ct);
            //    }
            //    dc.PHIEUMUONs.Add(fphieumuon.pHIEUMUON);
            //    dc.SaveChanges();
            //    dgphieumuon.ItemsSource = dc.PHIEUMUONs.ToList();
            //}


        }
        private void Btnmolapphieu_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.PhieuMuonWindow phieuMuon = new PhieuMuonWindow();
            this.Hide();
            phieuMuon.ShowDialog();          
            phieuMuon.Close();
            dgphieumuon.ItemsSource = dc.PHIEUMUONs.ToList();
            dgphieumuon.Items.SortDescriptions.Clear();
            dgphieumuon.Items.SortDescriptions.Add(new SortDescription("MaPhieuMuon", ListSortDirection.Descending));
            dgphieumuon.Items.Refresh();
            this.ShowDialog();
        }
      
    }
}
