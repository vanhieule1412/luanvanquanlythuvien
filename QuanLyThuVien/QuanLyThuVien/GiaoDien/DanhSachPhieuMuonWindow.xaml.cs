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
        private void hienthi()
        {
            //var kq = dc.PHIEUMUONs.Select(x => new
            //{
            //    MaPhieuMuon = x.MaPhieuMuon,
            //    NgayMuon = x.NgayMuon,
            //    NgayTra = x.NgayTra,
            //    TrangThai = x.TrangThai ? "Chưa Trả" : "Đã trả",
            //    TienPhat = x.TienPhat,
            //    MaDocGia = x.DOCGIA.MaDocGia,
            //    TenDocGia = x.DOCGIA.TenDocGia,
            //    MaThuThu = x.THUTHU.MaThuThu,
            //    TenThuThu = x.THUTHU.TenThuThu,
            //});
            //dgphieumuon.ItemsSource = kq.ToList();
            //dgphieumuon.ItemsSource = dc.DOCGIAs.ToList();
            //dgphieumuon.ItemsSource = dc.THUTHUs.ToList();

            dgphieumuon.ItemsSource = dc.PHIEUMUONs.ToList();



        }
   
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            hienthi();


            

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

        }

        private void Btnlap_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.PhieuMuonWindow fphieumuon = new PhieuMuonWindow();
            fphieumuon.pheptoan = KieuPhepToan.Them;
            if (fphieumuon.ShowDialog() == true)
            {
                //foreach (Model.SACH_PHIEUMUON t in pHIEUMUON.SACH_PHIEUMUON)
                //{
                //    Model.SACH_PHIEUMUON ct = new Model.SACH_PHIEUMUON();

                //    ct.MaPhieuMuon = t.MaPhieuMuon;
                //    ct.MaSach = t.MaSach;
                //    ct.SoLuongSachMuon = t.SoLuongSachMuon;
                //    pHIEUMUON.SACH_PHIEUMUON.Add(ct);
                //}         
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
                hienthi();
                



            }
        }

      
    }
}
