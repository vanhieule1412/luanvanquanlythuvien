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
    /// Interaction logic for ThuThuWindow.xaml
    /// </summary>
    public partial class ThuThuWindow : Window
    {
        private Model.UngDungQuanLyThuVienEntities dc = new Model.UngDungQuanLyThuVienEntities();
        
        public ThuThuWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
         
            dgThuThu.ItemsSource = dc.THUTHUs.ToList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
        }
        private void RdoThem_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void RdoSua_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btnthuchien_Click(object sender, RoutedEventArgs e)
        {
            if (rdoThem.IsChecked == true)
            {
                Model.THUTHU tHUTHU = new Model.THUTHU();
                tHUTHU.MaThuThu = txtmathuthu.Text;
                tHUTHU.TenThuThu = txttenthuthu.Text;
                tHUTHU.NamSinh = int.Parse(txtnamsinh.Text);
                tHUTHU.SoDienThoai = int.Parse(txtnamsinh.Text);
                tHUTHU.TrangThaiHoatDong = rdohoatdong.IsChecked;
                tHUTHU.TenDangNhap = txttendangnhap.Text;
                tHUTHU.MatKhau = txtmatkhau.Text;
                dc.THUTHUs.Add(tHUTHU);
                dc.SaveChanges();
                hienthi();
            }
            else if (rdoSua.IsChecked == true)
            {
                string mathuthu = txtmathuthu.Text;
                Model.THUTHU tHUTHU = dc.THUTHUs.Find(mathuthu);
                if (mathuthu != null)
                {
                    tHUTHU.TenThuThu = txttenthuthu.Text;
                    tHUTHU.NamSinh = int.Parse(txtnamsinh.Text);
                    tHUTHU.SoDienThoai = int.Parse(txtsodienthoai.Text);
                    if (rdohoatdong.IsChecked == true && rdokhonghoatdong.IsChecked == false)
                        tHUTHU.TrangThaiHoatDong=true;
                    else if (rdohoatdong.IsChecked == false && rdokhonghoatdong.IsChecked == true)
                    {
                        tHUTHU.TrangThaiHoatDong=false;
                    }
                    tHUTHU.TenDangNhap = txttendangnhap.Text;
                    tHUTHU.MatKhau = txtmatkhau.Text;
                    dc.SaveChanges();
                }
                hienthi();
            }
        }

        private void DgThuThu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (dgNhaXuatBan.SelectedItem == null) return;
           
            Model.THUTHU tHUTHU = dgThuThu.SelectedItem as Model.THUTHU;
            if (tHUTHU != null)
            {
                txtmathuthu.Text = tHUTHU.MaThuThu;
                txttenthuthu.Text = tHUTHU.TenThuThu;
                txtnamsinh.Text = tHUTHU.NamSinh.ToString();
                txtsodienthoai.Text = tHUTHU.SoDienThoai.ToString();
                if (tHUTHU.TrangThaiHoatDong.Value == true) rdohoatdong.IsChecked = true;
                else rdokhonghoatdong.IsChecked = true;
                txttendangnhap.Text = tHUTHU.TenDangNhap;
                txtmatkhau.Text = tHUTHU.MatKhau;
            }
            else
                return;
            
        }
    }
}
