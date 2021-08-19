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
    /// Interaction logic for SuathongtincanhanthuthuWindow.xaml
    /// </summary>
    public partial class SuathongtincanhanthuthuWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public TAIKHOANTHUTHU TAIKHOANTHUTHU;
        public SuathongtincanhanthuthuWindow()
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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            txtsodienthoai.Text  =TAIKHOANTHUTHU.THUTHU.SoDienThoai.ToString();
            txtemail.Text = TAIKHOANTHUTHU.THUTHU.Email;
            txtcmnd.Text = TAIKHOANTHUTHU.THUTHU.CMND.ToString();
            txtsodienthoai.Text = TAIKHOANTHUTHU.THUTHU.SoDienThoai.ToString();
           
          
        }
  
        private void Btnluu_Click(object sender, RoutedEventArgs e)
        {
            TAIKHOANTHUTHU aIKHOANTHUTHU = dc.TAIKHOANTHUTHUs.Find(int.Parse(TAIKHOANTHUTHU.MaTaiKhoai.ToString()));
            if (TAIKHOANTHUTHU.MaTaiKhoai.ToString() != null)
            {
                aIKHOANTHUTHU.THUTHU.SoDienThoai = txtsodienthoai.Text;
                aIKHOANTHUTHU.THUTHU.Email = txtemail.Text;
                aIKHOANTHUTHU.THUTHU.CMND = txtcmnd.Text;
                aIKHOANTHUTHU.MatKhau = Encrypt(txtmatkhua.Password);
                MessageBox.Show("Sửa thành công");
                dc.SaveChanges();
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtmatkhua.Visibility = Visibility.Visible;
            btndoimatkhau.Visibility = Visibility.Collapsed;

        }
    }
}
