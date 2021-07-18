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
            txtmathuthu.IsReadOnly = false;
            txttenthuthu.IsReadOnly = false;
        }

        private void RdoSua_Click(object sender, RoutedEventArgs e)
        {
            txtmathuthu.IsReadOnly = true;
            txttenthuthu.IsReadOnly = true;
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
                tHUTHU.NamSinh = dpnamsinh.SelectedDate.Value;
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
                    tHUTHU.NamSinh = dpnamsinh.SelectedDate.Value;
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
                //if (tHUTHU.GioiTinh == "Nam") cmbgioitinh.SelectedItem = "Nam";
                //else cmbgioitinh.SelectedItem = "Nữ";
                if (tHUTHU.GioiTinh == "Nam")
                {
                    cmbnam.IsSelected = true;
                }
                else if (tHUTHU.GioiTinh == "Nữ")
                {
                    cmbnu.IsSelected = true;
                }

                txtemail.Text = tHUTHU.Email;
                txtcmnd.Text = tHUTHU.CMND.ToString();
            }
            else
            {
                txtmathuthu.Text ="";
                txttenthuthu.Text = "";
                dpnamsinh.SelectedDate = null;
                txtsodienthoai.Text = "";
                cmbgioitinh.SelectedItem = "";
                txtemail.Text = "";
                txtcmnd.Text = "";
                return;
         
            }
        }
        //private void RdoTaotk_Click(object sender, RoutedEventArgs e)
        //{
        //    if (rdoTaotk.IsChecked == true)
        //    {
        //        txttaotaikhoan.Visibility = Visibility.Visible;
        //        txtmathuthu.Clear();
        //        txttenthuthu.Clear();
        //        dpnamsinh.SelectedDate = null;
        //        txtsodienthoai.Clear() ;
        //        cmbgioitinh.SelectedItem.ToString();
        //        txtemail.Clear();
        //        txtcmnd.Clear();
        //    }
        //}

        private void Txttaotaikhoan_Click(object sender, RoutedEventArgs e)
        {
            //GiaoDien.TaiKhoanThuThuWindow ftaikhoan = new TaiKhoanThuThuWindow();
            //ftaikhoan.chucnang = KieuChucNang.Them;
            //ftaikhoan.tAIKHOANTHUTHU = dc.TAIKHOANTHUTHUs.Find(dgThuThu.SelectedValue.ToString());
            //if (ftaikhoan.ShowDialog() == true)
            //{
            //    dc.TAIKHOANTHUTHUs.Add(ftaikhoan.tAIKHOANTHUTHU);
            //    dc.SaveChanges();
            //    hienthi();
            //}
            GiaoDien.TaiKhoanThuThuWindow ftaikhoan = new TaiKhoanThuThuWindow();
            ftaikhoan.chucnang = KieuChucNang.Them;            
            ftaikhoan.THUTHU = dc.THUTHUs.Find(dgThuThu.SelectedValue.ToString());
            string mathuthu = dgThuThu.SelectedValue.ToString();
            var ds = dc.TAIKHOANTHUTHUs.Where(x => x.MaThuThu == mathuthu).ToList();
            if (ds.Count > 0)
            {
                MessageBox.Show("Thủ thư này đã có tài khoản");
                return;
            }          
                if (ftaikhoan.ShowDialog() == true)
                {
                    dc.TAIKHOANTHUTHUs.Add(ftaikhoan.tAIKHOANTHUTHU);
                    dc.SaveChanges();

                }
          
           
           




        }     
    }
}
