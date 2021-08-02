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
using System.ComponentModel;
namespace QuanLyThuVien.GiaoDien
{
    /// <summary>
    /// Interaction logic for PhieuMuonWindow.xaml
    /// </summary>
    public partial class PhieuMuonWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        private PHIEUMUON PM = new PHIEUMUON();

       
        public PhieuMuonWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            //var kq = dc.PHIEUMUONs.ToList().Select(x => new {
            //    MaPhieuMuon = x.MaPhieuMuon,
            //    NgayMuon = x.NgayMuon,
            //    NgayTraDukien = x.NgayTraDukien,
            //    TrangThai = x.TrangThai ? "Được mượn" : "Không Được Mượn",
            //    TienPhatTong = x.TienPhatTong,
            //    DaTra = x.DaTra.Value ? "Đã Trả" : "Chưa Trả",
            //    MaTaiKhoai = x.MaTaiKhoai.Value,
            //    MaTheDocGia = x.MaTheDocGia,
            //}).ToList();
            //dgphieumuon.ItemsSource = dc.PHIEUMUONs.ToList();
            cmbMasach.ItemsSource = dc.SACHes.ToList();
            cmbmataikhoan.ItemsSource = dc.TAIKHOANTHUTHUs.ToList();
            cmbthedocgia.ItemsSource = dc.THEDOCGIAs.ToList();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();            
        }

        private void BtnLapPM_Click(object sender, RoutedEventArgs e)
        {
            string s = PhatSinhTuDong(dc);
            //PHIEUMUON k = dc.PHIEUMUONs.Find(txtmaphieumuon.Text);
            //if (k != null)
            //{
            //    MessageBox.Show("Trùng mã");
            //    return;
            //}
            PHIEUMUON x = new PHIEUMUON();

            x.MaPhieuMuon=s;
            x.NgayMuon = dpNgaymuon.SelectedDate.Value ;
            x.NgayTraDukien = dpNgaytradukien.SelectedDate.Value;
            if (rdbduocmuon.IsChecked == true)
            {
                x.TrangThai = true;
            }
            else
            {
                x.TrangThai = false;
            }
            if (rdbdatra.IsChecked == true)
            {
                x.DaTra = true;
            }
            else
            {
                x.DaTra = false;
            }
            x.TienPhatTong = int.Parse(txttienphattong.Text.ToString());
            x.MaTaiKhoai =int.Parse(cmbmataikhoan.SelectedValue.ToString());
            x.MaTheDocGia = cmbthedocgia.SelectedValue.ToString();
            foreach (CHITIETPHIEUMUON t in PM.CHITIETPHIEUMUONs)
            {
                CHITIETPHIEUMUON ct = new CHITIETPHIEUMUON();
                ct.MaPhieuMuon = t.MaPhieuMuon;
                ct.MaSach = t.MaSach;
                ct.TinhTrang = t.TinhTrang;
                ct.SoLuongSachMuon  = t.SoLuongSachMuon;
                x.CHITIETPHIEUMUONs.Add(ct);
            }
            dc.PHIEUMUONs.Add(x);
            dc.SaveChanges();
            hienthi();
            MessageBox.Show(s+"Thêm thành công");
            this.Close();
        }
        string PhatSinhTuDong(UngDungQuanLyThuVienEntities dc)
        {
            string s = "";
            var c = dc.PHIEUMUONs.Count();
            if (c == 0)
                s = "PM01";
            else
            {
                s = dc.PHIEUMUONs.ToList().ElementAt(c - 1).MaPhieuMuon;
                string sso = s.Substring(2);
                var so = int.Parse(sso);
                so++;
                s = "PM" + so;
            }
            return s;
        }

        private void Btnchon_Click(object sender, RoutedEventArgs e)
        {
            int soluong = 0;
            string ma = cmbMasach.SelectedValue.ToString();
            SACH sACH = dc.SACHes.Find(ma);
         
            CHITIETPHIEUMUON temp = null;
            if (cmbMasach.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn sách");
                return;
            }

            if (cmbMasach.SelectedItem == null) return;
            foreach (CHITIETPHIEUMUON t in PM.CHITIETPHIEUMUONs.Where(x => x.MaSach == cmbMasach.SelectedValue.ToString()))
            {

                temp = t;
                break;
            }
            //if (temp == null)
            //{
            if (soluong == 0)
            {
                CHITIETPHIEUMUON ct = new CHITIETPHIEUMUON();
                ct.SACH = cmbMasach.SelectedItem as SACH;
                ct.MaSach = ct.SACH.MaSach;
                ct.TinhTrang = cmbtinhtrang.SelectionBoxItem.ToString();
                ct.SoLuongSachMuon = int.Parse(txtSoluongsachmuon.Text);
                sACH.SoLuong -= ct.SoLuongSachMuon;
                PM.CHITIETPHIEUMUONs.Add(ct);
            }
            else
            {
               
                sACH.SoLuong += temp.SoLuongSachMuon;
            }

            var kq = getChitietphieumuon(PM);
          
            dgChitiet.ItemsSource = kq.ToList();
        }
        private IEnumerable<object> getChitietphieumuon(PHIEUMUON pHIEUMUON)
        {
            var kq = pHIEUMUON.CHITIETPHIEUMUONs.ToList().Select(x => new
            {
                MaSach = x.MaSach,
                TenSach = x.SACH.TenSach,
                TacGia = x.SACH.TacGia,
                NamXuatBan = x.SACH.NamXuatBan,
                TinhTrang = x.TinhTrang,
                NgayTraThat = x.NgayTraThat,
                TienPhat = x.TienPhat,
                SoLuongSachMuon = x.SoLuongSachMuon,

            });
            return kq.ToList();
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            string ma = dgChitiet.SelectedValue.ToString();
            foreach (CHITIETPHIEUMUON t in PM.CHITIETPHIEUMUONs.Where(x => x.MaSach == ma))
            {
                PM.CHITIETPHIEUMUONs.Remove(t);
                break;
            }
            var kq = getChitietphieumuon(PM);
            dgChitiet.ItemsSource = kq.ToList();

        }

        private void Dgphieumuon_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            PM = e.Row.Item as PHIEUMUON;
            DataGrid dg = e.DetailsElement.FindName("dgCTPM") as DataGrid;
            var kq = PM.CHITIETPHIEUMUONs.ToList().Select(x => new {
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
