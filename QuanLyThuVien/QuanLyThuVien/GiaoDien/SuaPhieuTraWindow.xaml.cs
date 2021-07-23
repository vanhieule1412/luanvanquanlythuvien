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
    /// Interaction logic for SuaPhieuTraWindow.xaml
    /// </summary>
    
    public partial class SuaPhieuTraWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public CHITIETPHIEUMUON phieutra;
        public ChucNang ChucNang;
        public SuaPhieuTraWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (ChucNang == ChucNang.Sua)
            {
                txtmaphieumuon.Text = phieutra.MaPhieuMuon;
                txtmasach.Text = phieutra.MaSach;
                if (phieutra.TinhTrang == "Hoàn chỉnh")
                {
                    cmbhoanchinh.IsSelected = true;
                }
                else if (phieutra.TinhTrang == "Bị hư hại")
                {
                    cmbbihu.IsSelected = true;
                }
                else
                {
                    cmbbimat.IsSelected = true;
                }
                
            }
        }

        private void Btnthuchien_Click(object sender, RoutedEventArgs e)
        {
            phieutra = new CHITIETPHIEUMUON();
            phieutra.MaSach = txtmasach.Text;
            phieutra.MaPhieuMuon = txtmaphieumuon.Text;
            phieutra.NgayTraThat = dpngaytrathat.SelectedDate;
            phieutra.TienPhat =int.Parse(txttienphat.Text.ToString());
            phieutra.TinhTrang = cmbtinhtrang.SelectedValue.ToString();
            this.DialogResult = true;
            this.Close();
        }
    }
}
