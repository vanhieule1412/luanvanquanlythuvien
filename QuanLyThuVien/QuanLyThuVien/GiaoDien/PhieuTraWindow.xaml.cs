﻿using System;
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
    /// Interaction logic for PhieuTraWindow.xaml
    /// </summary>
    
    public partial class PhieuTraWindow : Window
    {
       
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public PhieuTraWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            dgphieutra.ItemsSource = dc.PHIEUMUONs.ToList();
            cmbMaDocGia.ItemsSource = dc.THEDOCGIAs.ToList();
            cmbMaThuThu.ItemsSource = dc.TAIKHOANTHUTHUs.ToList();
        }
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
        }

        private void Dgphieutra_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            PHIEUMUON pHIEUMUON = e.Row.Item as PHIEUMUON;
            DataGrid dg = e.DetailsElement.FindName("dgCTPT") as DataGrid;
            var kq = pHIEUMUON.CHITIETPHIEUMUONs.ToList().Select(x => new
            {
                MaSach = x.MaSach,
                TenSach = x.SACH.TenSach,
                TacGia = x.SACH.TacGia,
                NguoiDich = x.SACH.NguoiDich,
                TienPhat = x.TienPhat,
                NgayTraThat = x.NgayTraThat,
                TinhTrang = x.TinhTrang,
                SoLuongSachMuon = x.SoLuongSachMuon,
            });
            dg.ItemsSource = kq.ToList();
        }

        private void Dgphieutra_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgphieutra.SelectedItem == null) return;
            PHIEUMUON s = dgphieutra.SelectedItem as PHIEUMUON;
            if (s != null)
            {
                txtmaphieumuon.Text = s.MaPhieuMuon;
                dpNgayMuon.SelectedDate = s.NgayMuon;
                dpNgayTra.SelectedDate = s.NgayTraDukien;
                cmbMaDocGia.SelectedValue = s.MaTheDocGia;
                cmbMaThuThu.Text = s.MaTaiKhoai.ToString();
                if (s.TrangThai.ToString() == "Được mượn")
                {
                    cmbduocmuon.IsSelected = true;
                }
                else
                {
                    cmbkhongduocmuon.IsSelected = true;
                }
                txttienphattong.Text = s.TienPhatTong.ToString();
                if (s.DaTra == true)
                {
                    ckbdatra.IsChecked = true;
                }
                else
                {
                    ckbdatra.IsChecked = false;
                }
            }
        }

        private void Btnlapphieutra_Click(object sender, RoutedEventArgs e)
        {
           
            GiaoDien.SuachitietphieumuonWindow f = new SuachitietphieumuonWindow();
            f.chucnang = ChucNang.Sua;
            f.PHIEUMUON = dc.PHIEUMUONs.Find(dgphieutra.SelectedValue.ToString());           
            this.Hide();
            f.ShowDialog();
       
            f.Close();
            this.ShowDialog();
          

        }
    }
}