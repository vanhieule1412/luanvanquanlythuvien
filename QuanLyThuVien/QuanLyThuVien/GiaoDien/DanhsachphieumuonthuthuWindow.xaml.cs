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
    /// Interaction logic for DanhsachphieumuonthuthuWindow.xaml
    /// </summary>
    public partial class DanhsachphieumuonthuthuWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public DanhsachphieumuonthuthuWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgphieumuon.Items.SortDescriptions.Clear();
            dgphieumuon.Items.SortDescriptions.Add(new SortDescription("MaPhieuMuon", ListSortDirection.Descending));
            dgphieumuon.Items.Refresh();
            dgphieumuon.ItemsSource = dc.PHIEUMUONs.ToList();
            cmbthedocgia.ItemsSource = dc.THEDOCGIAs.ToList();
            cmbmataikhoan.ItemsSource = dc.TAIKHOANTHUTHUs.ToList();

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
                TienPhat = x.TienPhat,
                NgayTraThat = x.NgayTraThat,
                TinhTrang = x.TinhTrang,
                SoLuongSachMuon = x.SoLuongSachMuon,
            });
            dg.ItemsSource = kq.ToList();
        }

        private void BtnDuyetPM_Click(object sender, RoutedEventArgs e)
        {
            string ma = txtmaphieumuon.Text;
            PHIEUMUON pHIEUMUON = dc.PHIEUMUONs.Find(ma);
            if (ma != null)
            {
                pHIEUMUON.NgayMuon = dpNgaymuon.SelectedDate.Value;
                pHIEUMUON.NgayTraDukien = dpNgaytradukien.SelectedDate.Value;
                if (rdbduocmuon.IsChecked == true)
                {
                    pHIEUMUON.TrangThai = true;
                }
                else
                {
                    pHIEUMUON.TrangThai = false;
                }
                pHIEUMUON.MaTaiKhoai = int.Parse(cmbmataikhoan.SelectedValue.ToString());

                dc.SaveChanges();
                dgphieumuon.ItemsSource = dc.PHIEUMUONs.ToList();
            }
        }

        private void Dgphieumuon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PHIEUMUON pHIEUMUON = dgphieumuon.SelectedItem as PHIEUMUON;
            if (pHIEUMUON != null)
            {
                txtmaphieumuon.Text = pHIEUMUON.MaPhieuMuon;
                dpNgaymuon.SelectedDate = pHIEUMUON.NgayMuon;
                dpNgaytradukien.SelectedDate = pHIEUMUON.NgayTraDukien;
                if (pHIEUMUON.TrangThai.ToString() == "Được mượn")
                {
                    rdbduocmuon.IsChecked = true;
                }
                else {
                    rdbkhongduocmuon.IsChecked = true;
                }
                if (pHIEUMUON.DaTra.ToString() == "Đã trả")
                {
                    rdbdatra.IsChecked = true;
                }
                else
                {
                    rdbchuatra.IsChecked = true;
                }
                cmbmataikhoan.SelectedValue = pHIEUMUON.MaTaiKhoai;
                cmbthedocgia.SelectedValue = pHIEUMUON.MaTheDocGia;
               

            }
            else
            {
                txtmaphieumuon.Text = "";
                dpNgaymuon.SelectedDate = null;
                dpNgaytradukien.SelectedDate = null;
                rdbchuatra.IsChecked = true;
                rdbkhongduocmuon.IsChecked = true;
                cmbmataikhoan.SelectedValue = null;
                cmbthedocgia.SelectedValue = null;
                return;
            }

        }
    }
}
