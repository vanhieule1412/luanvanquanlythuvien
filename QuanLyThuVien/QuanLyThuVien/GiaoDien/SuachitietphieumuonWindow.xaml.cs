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
        private void hienthi()
        {
            var filteredsach = dc.CHITIETPHIEUMUONs.Where(x => x.MaPhieuMuon.Contains(txtmaphieumuon.Text.ToUpper()));
            dgchitietphieumuon.ItemsSource = null;
            dgchitietphieumuon.ItemsSource = filteredsach.ToList();
            DateTime date = DateTime.Now;
            dpngaytrathat.SelectedDate = date;

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (chucnang == ChucNang.Sua)
            {

                txtmaphieumuon.Text = PHIEUMUON.MaPhieuMuon;
            }
            hienthi();
        }

        private void Btnthuchienchitiet_Click(object sender, RoutedEventArgs e)
        {
            //GiaoDien.SuaPhieuTraWindow f = new GiaoDien.SuaPhieuTraWindow();
            //f.ChucNang = ChucNang.Sua;
            //f.phieutra = dc.CHITIETPHIEUMUONs.Find(dgchitietphieumuon.SelectedValue);
            double tongtienphat = 0;
            string ma = txtmasach.Text;
            string mapm = txtmaphieumuon.Text;
            SACH sACH = dc.SACHes.Find(ma);
            PHIEUMUON pHIEUMUON = dc.PHIEUMUONs.Find(mapm);
            if (String.IsNullOrWhiteSpace(txtmact.Text) == true)
            {
                MessageBox.Show("Chưa học sách cần trả");
                return;
            }
            CHITIETPHIEUMUON pm = dc.CHITIETPHIEUMUONs.Find(int.Parse(txtmact.Text));
            if (cmbtinhtrang.SelectedValue == null)
            {
                MessageBox.Show("Chưa chọn tình trạng của sách trả");
                return;
            }
            if (pm != null)
            {
                var sachnuagia = pm.SACH.Gia / 2;
                TimeSpan time = pm.PHIEUMUON.NgayTraDukien - dpngaytrathat.SelectedDate.Value  ;
                
                int Tongsongay = time.Days;
                pm.TinhTrang = cmbtinhtrang.SelectionBoxItem.ToString();
                //if ((pm.TinhTrang == "Bị hư hại" || pm.TinhTrang == "Bị mất") && Tongsongay == 0)
                //{
                //    pm.TienPhat = pm.SACH.Gia + 100000;
                //     tongtienphat = (double)pm.TienPhat;
                //    //txttienphat.Text = pm.TienPhat.ToString();
                //}
                if (dpngaytrathat.SelectedDate < pm.PHIEUMUON.NgayMuon)
                {
                    MessageBox.Show("Ngày trả thật không được trước ngày mượn");
                    return;
                }
                else if ((pm.TinhTrang == "Hoàn chỉnh") && Tongsongay >= 0)
                {
                    pm.TienPhat = 0;
                    tongtienphat = 0;
                }
                else if ((pm.TinhTrang == "Hoàn chỉnh") && Tongsongay < 0)
                {
                    pm.TienPhat = System.Math.Abs(Tongsongay) * 10000;
                    tongtienphat = 0;
                }
                else if ((pm.TinhTrang == "Bị hư hại" || pm.TinhTrang == "Bị mất") && Tongsongay >= 0)
                {
                    pm.TienPhat =  pm.SACH.Gia + 100000;
                    tongtienphat = (double)pm.TienPhat;
                }
                else if ((pm.TinhTrang == "Bị hư hại" || pm.TinhTrang == "Bị mất") && Tongsongay < 0)
                {
                    pm.TienPhat = (System.Math.Abs(Tongsongay) * 10000)+ pm.SACH.Gia + 100000;
                    tongtienphat = (double)pm.TienPhat;
                }
                else if ((pm.TinhTrang == "Bị hư hại nhẹ") && Tongsongay >= 0)
                {
                    pm.TienPhat = sachnuagia;
                    tongtienphat = (double)pm.TienPhat;
                }
                else if ((pm.TinhTrang == "Bị hư hại nhẹ") && Tongsongay < 0)
                {
                    pm.TienPhat = (System.Math.Abs(Tongsongay) * 10000) + sachnuagia;
                    tongtienphat = (double)pm.TienPhat;
                }


                if (dpngaytrathat.SelectedDate != null && cmbhoanchinh.IsSelected)
                {
                    sACH.SoLuong += pm.SoLuongSachMuon;
                }
                else if (dpngaytrathat.SelectedDate != null && cmbbihunhe.IsSelected)
                {
                    sACH.SoLuong += pm.SoLuongSachMuon;
                }
                pm.NgayTraThat = dpngaytrathat.SelectedDate;
                txttienphat.Text = pm.TienPhat.ToString();
                foreach (var b in dc.PHIEUMUONs.Where(x => x.MaPhieuMuon == pm.MaPhieuMuon))
                {
                    if (b.MaPhieuMuon == pm.MaPhieuMuon)
                    {
                        b.TienPhatTong += tongtienphat;
                    }
                }
                dc.SaveChanges();
                hienthi();
            }
           
            //GiaoDien.PhieuTraWindow f = new PhieuTraWindow();
            //this.Close();
            //f.ShowDialog();
        }


        private void Txttim_TextChanged(object sender, TextChangedEventArgs e)
        {
                //if (txttim.Text.ToUpper() == txtmaphieumuon.Text)
                //{
                //    var filteredsach = dc.CHITIETPHIEUMUONs.Where(x => x.MaPhieuMuon.Contains(txtmaphieumuon.Text.ToUpper()));

                //    dgchitietphieumuon.ItemsSource = null;
                //    dgchitietphieumuon.ItemsSource = filteredsach.ToList();

                //}
                //else
                //{
                //    dgchitietphieumuon.ItemsSource = dc.CHITIETPHIEUMUONs.ToList();
                //}
           
       
            

        }

        private void Dgchitietphieumuon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgchitietphieumuon.SelectedItem == null) return;
            CHITIETPHIEUMUON ct = dgchitietphieumuon.SelectedItem as CHITIETPHIEUMUON;
            txtmasach.Text = ct.MaSach;
            txtsoluongchitiet.Text =ct.SoLuongSachMuon.ToString();
            txttienphat.Text = ct.TienPhat.ToString();
            txtmact.Text = ct.MaMuonTra.ToString();


        }

        private void Btnback_Click(object sender, RoutedEventArgs e)
        {
            //GiaoDien.PhieuTraWindow f = new PhieuTraWindow();
            //this.Close();
            //f.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            GiaoDien.PhieuTraWindow f = new PhieuTraWindow();
            this.Close();
            f.ShowDialog();
        }
    }
}
