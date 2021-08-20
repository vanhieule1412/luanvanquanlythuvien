using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
        private bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        private bool HasSpecialChars(string yourString)
        {
            return yourString.Any(ch => !Char.IsLetterOrDigit(ch));
        }
        private bool IsInt(string sVal)
        {
            foreach (char c in sVal)
            {
                int iN = (int)c;
                if ((iN > 57) || (iN < 48))
                    return false;
            }
            return true;
        }
        private void Btnluu_Click(object sender, RoutedEventArgs e)
        {
            TAIKHOANTHUTHU aIKHOANTHUTHU = dc.TAIKHOANTHUTHUs.Find(int.Parse(TAIKHOANTHUTHU.MaTaiKhoai.ToString()));
            if (TAIKHOANTHUTHU.MaTaiKhoai.ToString() != null)
            {
                if (String.IsNullOrWhiteSpace(txtmatkhua.Password) == true)
                {
                    this.Close();
                    return;
                }
                else if (String.IsNullOrWhiteSpace(txtsodienthoai.Text) == true)
                {
                    MessageBox.Show("Số số điện thoại không được để trống");
                    return;
                }
                else if (String.IsNullOrWhiteSpace(txtcmnd.Text) == true)
                {
                    MessageBox.Show("CMND không được để trống");
                    return;
                }
                else if (String.IsNullOrWhiteSpace(txtemail.Text) == true)
                {
                    MessageBox.Show("email không được để trống");
                    return;
                }
                else if (HasSpecialChars(txtcmnd.Text.ToString()) == true)
                {
                    MessageBox.Show("CMND không có khoảng trắng hoặc kí tự đặc biệt");
                    txtcmnd.Focus();
                    txtcmnd.Select(txtcmnd.Text.Length, 0);
                    return;
                }
                else if (IsInt(txtcmnd.Text) == false)
                {
                    MessageBox.Show("CMND phải là số");
                    return;
                }
                else if (IsInt(txtsodienthoai.Text) == false)
                {
                    MessageBox.Show("Số điện thoại phải là số");
                    return;
                }
                else if (txtcmnd.Text.Length != 9 && txtcmnd.Text.Length != 12)
                {
                    MessageBox.Show("CMND không hợp lệ");
                    txtcmnd.Focus();
                    txtcmnd.Select(txtcmnd.Text.Length, 0);
                    return;
                }
                else if (HasSpecialChars(txtsodienthoai.Text.ToString()) == true)
                {
                    MessageBox.Show("Số điện thoại không có khoảng trắng hoặc kí tự đặc biệt");
                    txtsodienthoai.Focus();
                    txtsodienthoai.Select(txtsodienthoai.Text.Length, 0);
                    return;
                }
                else if (isEmail(txtemail.Text) == false)
                {
                    MessageBox.Show("Đây không phải là email");
                    txtemail.Focus();
                    txtemail.Select(txtemail.Text.Length, 0);
                    return;
                }
                else
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn đổi mật khẩu", "Thông báo", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                btndoimatkhau.Visibility = Visibility.Hidden;
                txtmatkhua.Visibility = Visibility.Visible;
            }
            else if (result == MessageBoxResult.No)
            {
                return;
            }

        }
    }
}
