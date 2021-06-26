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
    /// Interaction logic for DanhSachPhieuMuonWindow.xaml
    /// </summary>
    public partial class DanhSachPhieuMuonWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
       
        public DanhSachPhieuMuonWindow()
        {
            InitializeComponent();
        }
        
   
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgphieumuon.ItemsSource = dc.PHIEUMUONs.ToList();
            
        }
       
        private void Dgphieumuon_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
           
                PHIEUMUON pHIEUMUON = e.Row.Item as PHIEUMUON;            
                DataGrid dg = e.DetailsElement.FindName("dgsachphieumuon") as DataGrid;
                var kq = pHIEUMUON.SACH_PHIEUMUON.ToList().Select(x => new
                {
                    MaSach = x.MaSach,
                    TenSach = x.SACH.TenSach,
                    TacGia = x.SACH.TacGia,
                    NguoiDich = x.SACH.NguoiDich,
                    SoLuongSachMuon = x.SoLuongSachMuon,
                });
                dg.ItemsSource = kq.ToList();
           
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSua_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.PhieuMuonWindow f = new PhieuMuonWindow();
            f.pheptoan = KieuPhepToan.Sua;
            f.pHIEUMUON = dc.PHIEUMUONs.Find(dgphieumuon.SelectedValue.ToString());
            if (f.ShowDialog() == true)
            {
                PHIEUMUON hIEUMUON = dc.PHIEUMUONs.Find(f.pHIEUMUON.MaPhieuMuon);
                if (hIEUMUON != null)
                {               
                    ////hIEUMUON.MaThuThu = f.pHIEUMUON.MaThuThu;
                    ////hIEUMUON.MaDocGia = f.pHIEUMUON.MaDocGia;
                    //hIEUMUON.NgayMuon = f.pHIEUMUON.NgayMuon;
                    //hIEUMUON.NgayTra = f.pHIEUMUON.NgayTra;
                    hIEUMUON.TrangThai = f.pHIEUMUON.TrangThai;
                    hIEUMUON.TienPhat = f.pHIEUMUON.TienPhat;
                    //hIEUMUON.SACH_PHIEUMUON = f.pHIEUMUON.SACH_PHIEUMUON;
                    dc.SaveChanges();
                    dgphieumuon.ItemsSource = dc.PHIEUMUONs.ToList();
                }
            }
        }

        private void Btnlap_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.PhieuMuonWindow fphieumuon = new PhieuMuonWindow();
            fphieumuon.pheptoan = KieuPhepToan.Them;
            if (fphieumuon.ShowDialog() == true)
            {        
                foreach (SACH_PHIEUMUON t in fphieumuon.HIEUMUON.SACH_PHIEUMUON)
                {
                    SACH_PHIEUMUON ct = new SACH_PHIEUMUON();
                    ct.MaPhieuMuon = t.MaPhieuMuon;
                    ct.MaSach = t.MaSach;
                    ct.SoLuongSachMuon = t.SoLuongSachMuon;
                    fphieumuon.pHIEUMUON.SACH_PHIEUMUON.Add(ct);
                }
                dc.PHIEUMUONs.Add(fphieumuon.pHIEUMUON);
                dc.SaveChanges();
                dgphieumuon.ItemsSource = dc.PHIEUMUONs.ToList();
            }
            
        }
        

      
    }
}
