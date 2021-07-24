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
using System.IO;

namespace QuanLyThuVien.GiaoDien
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public static string usename;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Btndangnhap_Click(object sender, RoutedEventArgs e)
        {
           
            if (txttaikhoan.Text == "admin" && txtmatkhau.Password == "admin")
            {
                usename = txttaikhoan.Text;
                MainWindow mainf = new MainWindow();
                mainf.tbltentaikhoan.Text = "admin";
                this.Close();
            }
            else
            {
                //var a = dc.TAIKHOANTHUTHUs.FirstOrDefault(x => x.TenTaiKhoai == txttaikhoan.ToString() && x.MatKhau == txtmatkhau.ToString());
                //if (a == null)
                //{
                //    MessageBox.Show("Không có tài khoản này ");
                //}
                //else
                //{
                //    var role = a.TenTaiKhoai.FirstOrDefault();
                //    this.Close();
                //}
                foreach (var a in dc.TAIKHOANTHUTHUs)
                {

                    if (txttaikhoan.Text == a.TenTaiKhoai && txtmatkhau.Password == a.MatKhau)
                    {
                        usename = txttaikhoan.Text;
                        MainWindow formmain = new MainWindow();
                        this.Close();
                        formmain.tbltentaikhoan.Text = usename;
                        formmain.tbltenthuthu.Text = a.THUTHU.TenThuThu;

                        formmain.ShowDialog();
                      
                        
                    }
                    else
                    {
                        break;
                    }
                }
                foreach (var b in dc.TAIKHOANDOCGIAs)
                {
                    if (txttaikhoan.Text == b.TenTaiKhoan && txtmatkhau.Password == b.MatKhau)
                    {
                        MainWindow formmain = new MainWindow();
                        formmain.Show();
                        this.Close();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
