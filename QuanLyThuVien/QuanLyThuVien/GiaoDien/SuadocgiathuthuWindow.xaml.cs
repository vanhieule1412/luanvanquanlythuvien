using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for SuadocgiathuthuWindow.xaml
    /// </summary>
    public partial class SuadocgiathuthuWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public KieuChucNang chucnang;
        public TAIKHOANDOCGIA tAIKHOANDOCGIA;

        public SuadocgiathuthuWindow()
        {
            InitializeComponent();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (chucnang == KieuChucNang.suathuthu)
            {
                //txtmatkhau.Password = tAIKHOANTHUTHU.MatKhau;
                if (tAIKHOANDOCGIA.TrangThai == "Không hoạt động")
                {
                    cmbkhonghoatdong.IsSelected = true;
                }
                else if (tAIKHOANDOCGIA.TrangThai == "Hoạt Động")
                {
                    cmbhoatdong.IsSelected = true;
                }
            }
        }

        private void Btncapnhat_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtmatkhau.Password) == true)
            {
                this.Close();
                return;
            }
            else
            {
                tAIKHOANDOCGIA.MatKhau = Encrypt(txtmatkhau.Password.Trim());
                tAIKHOANDOCGIA.TrangThai = cmbtrangthai.SelectionBoxItem.ToString();
                this.DialogResult = true;
                this.Close();
            }

        }

        private void Btndoimatkhau_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Bạn có muốn đổi mật khẩu","Thông báo", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                btndoimatkhau.Visibility = Visibility.Hidden;
                txtmatkhau.Visibility = Visibility.Visible;
            }
            else if(result == MessageBoxResult.No)
            {
                return;
            }
            
        }
    }
}
