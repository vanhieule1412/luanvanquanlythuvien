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
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        
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
                THUTHU hUTHU = dc.THUTHUs.Find(txtmathuthu.Text);
                if (hUTHU != null)
                {
                    MessageBox.Show("Trùng mã");
                    return;
                }
                THUTHU tHUTHU = new THUTHU();
                tHUTHU.MaThuThu = txtmathuthu.Text;
                tHUTHU.TenThuThu = txttenthuthu.Text;
                tHUTHU.NamSinh = dpnamsinh.SelectedDate;
                tHUTHU.SoDienThoai = int.Parse(txtsodienthoai.Text);
                tHUTHU.GioiTinh = cmbgioitinh.SelectionBoxItem.ToString();
                tHUTHU.Email = txtemail.Text;
                tHUTHU.CMND = int.Parse(txtcmnd.Text);
                dc.THUTHUs.Add(tHUTHU);
                dc.SaveChanges();
                hienthi();
            }
            else if (rdoSua.IsChecked == true)
            {
                string mathuthu = txtmathuthu.Text;
                THUTHU tHUTHU = dc.THUTHUs.Find(mathuthu);
                if (mathuthu != null)
                {
                    tHUTHU.TenThuThu = txttenthuthu.Text;
                    tHUTHU.NamSinh = dpnamsinh.SelectedDate;
                    tHUTHU.SoDienThoai = int.Parse(txtsodienthoai.Text);
                    tHUTHU.GioiTinh = cmbgioitinh.SelectionBoxItem.ToString();
                    tHUTHU.Email = txtemail.Text;
                    tHUTHU.CMND =int.Parse(txtcmnd.Text);
                    dc.SaveChanges();
                }
                hienthi();
            }
        }

        private void DgThuThu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgThuThu.SelectedItem == null) return;
            THUTHU tHUTHU = dgThuThu.SelectedItem as THUTHU;
            if (tHUTHU != null)
            {
                txtmathuthu.Text = tHUTHU.MaThuThu;
                txttenthuthu.Text = tHUTHU.TenThuThu;
                dpnamsinh.SelectedDate = tHUTHU.NamSinh;
                txtsodienthoai.Text = tHUTHU.SoDienThoai.ToString();
                if (tHUTHU.GioiTinh == "Nam") cmbgioitinh.SelectedItem = "Nam";
                else cmbgioitinh.SelectedItem = "Nữ";
                txtemail.Text = tHUTHU.Email;
                txtcmnd.Text = tHUTHU.CMND.ToString();
            }
            else
                return;

        }

        private void Txttaotaikhoan_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
