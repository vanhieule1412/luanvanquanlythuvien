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
using System.Security.Cryptography;

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
        public string Encrypt(string decrypted)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(decrypted));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
        public string Decrypt(string encrypted)
        {
            var encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecodeByte = Convert.FromBase64String(encrypted);
            int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
            char[] decodedChar = new char[charCount];
            utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
            string result = new String(decodedChar);
            return result;
        }
        private void Btndangnhap_Click(object sender, RoutedEventArgs e)
        {
           
            if (txttaikhoan.Text == "admin" && txtmatkhau.Password == "admin")
            {
                usename = txttaikhoan.Text;
                MainWindow mainf = new MainWindow();
                this.Close();
                mainf.tbltentaikhoan.Text = "admin";
                mainf.btndangnhap.Visibility = Visibility.Collapsed;
                mainf.menu.Visibility = Visibility.Visible;
                mainf.mnthedocgia.Visibility = Visibility.Collapsed;
                mainf.mnmataikhoan.Visibility = Visibility.Collapsed;
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
                    var mk = Encrypt(txtmatkhau.Password);
                    if (txttaikhoan.Text == a.TenTaiKhoai && mk == a.MatKhau)
                    {
                        usename = txttaikhoan.Text;
                        MainWindow formmain = new MainWindow();
                        this.Close();
                        formmain.tbltentaikhoan.Text = usename;
                        formmain.tblmataikhoan.Text = a.MaTaiKhoai.ToString();                      
                        formmain.btndangnhap.Visibility = Visibility.Collapsed;
                        formmain.menu.Visibility = Visibility.Visible;
                        formmain.mnthedocgia.Visibility = Visibility.Collapsed;
                        formmain.mnsuattcanhanthuthu.Visibility = Visibility.Visible;
                        formmain.menuquanly.Visibility = Visibility.Visible;
                        formmain.mndocgia.Visibility = Visibility.Visible;
                        formmain.mnsach.Visibility = Visibility.Visible;
                        formmain.mnvitri.Visibility = Visibility.Visible;
                        formmain.mnlapPMDG.Visibility = Visibility.Collapsed;
                        formmain.ShowDialog();                        
                    }
                }
                foreach (var b in dc.TAIKHOANDOCGIAs)
                {
                    var mk = Encrypt(txtmatkhau.Password);
                    if (txttaikhoan.Text == b.TenTaiKhoan && mk == b.MatKhau)
                    {
                        usename = txttaikhoan.Text;
                        MainWindow formmain = new MainWindow();
                        this.Close();
                        formmain.tbltentaikhoan.Text = usename;
                        formmain.tblmataikhoan.Text = b.MaTaiKhoaiDocGia.ToString();
                    
                        foreach (var a in dc.THEDOCGIAs)
                        {                           
                            formmain.tblthedocgia.Text = a.MaTheDocGia;
                        }                        
                        formmain.btndangnhap.Visibility = Visibility.Collapsed;
                        formmain.mnduyetPM.Visibility = Visibility.Collapsed;
                        formmain.menu.Visibility = Visibility.Visible;
                        formmain.mnlistlichsu.Visibility = Visibility.Visible;
                        formmain.mnlichsutra.Visibility = Visibility.Visible;
                        formmain.mnsuattcanhan.Visibility = Visibility.Visible;
                        formmain.mnlichsu.Visibility = Visibility.Visible;
                        formmain.menuquanly.Visibility = Visibility.Visible;
                        formmain.mnlapPM.Visibility = Visibility.Collapsed;
                        formmain.mnphieutra.Visibility = Visibility.Collapsed;
                        formmain.ShowDialog();
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
