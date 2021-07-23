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
    /// Interaction logic for SuachitietphieumuonWindow.xaml
    /// </summary>
    public enum ChucNang { Sua }
    public partial class SuachitietphieumuonWindow : Window
    {
        
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public PHIEUMUON PHIEUMUON;
        public ChucNang chucnang;
        public SuachitietphieumuonWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (chucnang == ChucNang.Sua)
            {
                txtmaphieumuon.Text = PHIEUMUON.MaPhieuMuon;
            }
            dgchitietphieumuon.ItemsSource = dc.CHITIETPHIEUMUONs.ToList();
         

        }

        private void Btnthuchienchitiet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btnsuachitiet_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.SuaPhieuTraWindow f = new GiaoDien.SuaPhieuTraWindow();
            f.ChucNang = ChucNang.Sua;
            f.phieutra = dc.CHITIETPHIEUMUONs.Find(dgchitietphieumuon.SelectedValue);
            if (f.ShowDialog() == true)
            {
                CHITIETPHIEUMUON pm = dc.CHITIETPHIEUMUONs.Find(f.phieutra.MaMuonTra);
                if (pm != null)
                {
                    pm.TienPhat = f.phieutra.TienPhat;
                    pm.TinhTrang = f.phieutra.TinhTrang;
                    pm.NgayTraThat = f.phieutra.NgayTraThat;
                    dc.SaveChanges();
                    dgchitietphieumuon.ItemsSource = dc.CHITIETPHIEUMUONs.ToList();
                }
            }
        }
       
        private void Txttim_TextChanged(object sender, TextChangedEventArgs e)
        {
            txttim.Text = txtmaphieumuon.Text;
            TextBox t = (TextBox)sender;
            string filter = t.Text.Trim();
            ICollectionView cv = CollectionViewSource.GetDefaultView(dgchitietphieumuon.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    CHITIETPHIEUMUON p = o as CHITIETPHIEUMUON;
                    if (t.Name == "txttim")
                        return p.MaPhieuMuon.StartsWith(filter);
                    return p.MaPhieuMuon.StartsWith(filter);
                };
            }

        }
    }
}
