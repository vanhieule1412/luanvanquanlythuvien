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
        public static string ma;
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
                this.Close();
                mainf.tbltentaikhoan.Text = "admin";
                mainf.tbltenthuthu.Text = "admin";
                mainf.btndangnhap.Visibility = Visibility.Collapsed;
                mainf.menu.Visibility = Visibility.Visible;
                mainf.menuquanly.Visibility = Visibility.Visible;
                mainf.mnthuthu.Visibility = Visibility.Visible;
                mainf.mnphieumuon.Visibility = Visibility.Collapsed;
                mainf.mnphieutra.Visibility = Visibility.Collapsed;
                mainf.ShowDialog();
            }
            else
            {
                foreach (var a in dc.TAIKHOANTHUTHUs)
                {
                    if (txttaikhoan.Text == a.TenTaiKhoai && txtmatkhau.Password == a.MatKhau)
                    {

                        usename = txttaikhoan.Text;
                        MainWindow formmain = new MainWindow();
                        this.Close();
                        formmain.tbltentaikhoan.Text = usename;
                        formmain.tblmataikhoan.Text = a.MaTaiKhoai.ToString();
                        formmain.tbltenthuthu.Text = a.THUTHU.TenThuThu;
                        formmain.btndangnhap.Visibility = Visibility.Collapsed;
                        formmain.menu.Visibility = Visibility.Visible;
                        formmain.menuquanly.Visibility = Visibility.Visible;
                        formmain.mndocgia.Visibility = Visibility.Visible;
                        formmain.mnsach.Visibility = Visibility.Visible;
                        formmain.mnvitri.Visibility = Visibility.Visible;
                        formmain.mnlapPMDG.Visibility = Visibility.Collapsed;
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
                        usename = txttaikhoan.Text;
                        MainWindow formmain = new MainWindow();
                        this.Close();
                        formmain.tbltentaikhoan.Text = usename;
                        formmain.tblmataikhoan.Text = b.MaTaiKhoaiDocGia.ToString();
                        formmain.tbltenthuthu.Text = b.DOCGIA.TenDocGia;
                        formmain.btndangnhap.Visibility = Visibility.Collapsed;
                        formmain.mnduyetPM.Visibility = Visibility.Collapsed;
                        formmain.menu.Visibility = Visibility.Visible;
                        formmain.menuquanly.Visibility = Visibility.Visible;
                        formmain.mnlapPM.Visibility = Visibility.Collapsed;
                        formmain.mnphieutra.Visibility = Visibility.Collapsed;
                        formmain.ShowDialog();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void Btntrolai_Click(object sender, RoutedEventArgs e)
        {
            MainWindow f = new MainWindow();
            this.Hide();
            f.ShowDialog();
            f.Close();
        }
    }
}
