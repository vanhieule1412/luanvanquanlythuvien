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

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Btndangnhap_Click(object sender, RoutedEventArgs e)
        {
            if (txttaikhoan.Text == "admin" && txtmatkhau.Text == "admin")
            {
                MainWindow mainf = new MainWindow();
                mainf.Show();
                this.Close();
            }
            else
            {
                foreach (var a in dc.TAIKHOANTHUTHUs)
                {
                    if (txttaikhoan.Text == a.TenTaiKhoai && txtmatkhau.Text == a.MatKhau)
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
                foreach (var b in dc.TAIKHOANDOCGIAs)
                {
                    if (txttaikhoan.Text == b.TenTaiKhoan && txtmatkhau.Text == b.MatKhau)
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
