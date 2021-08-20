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
    /// Interaction logic for TaiKhoanThuThuWindow.xaml
    /// </summary>
    public enum KieuChucNang {Them,Sua,suaadmin,suathuthu}
    public partial class TaiKhoanThuThuWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public KieuChucNang chucnang;
        public TAIKHOANTHUTHU tAIKHOANTHUTHU;
        public THUTHU THUTHU;
        public TaiKhoanThuThuWindow()
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

        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
    "í","ì","ỉ","ĩ","ị",
    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
    "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
    "d",
    "e","e","e","e","e","e","e","e","e","e","e",
    "i","i","i","i","i",
    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
    "u","u","u","u","u","u","u","u","u","u","u",
    "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (chucnang == KieuChucNang.Them)
            {
                txtmathuthu.Text = THUTHU.MaThuThu;
                txtmatkhau.Password = RemoveUnicode(THUTHU.TenThuThu);
                txtmatkhau.Password = txtmatkhau.Password.Replace(" ", "");
            }
            else if (chucnang == KieuChucNang.Sua)
            {
                txttenthuthu.Text = tAIKHOANTHUTHU.TenTaiKhoai;
                txtmatkhau.Password = tAIKHOANTHUTHU.MatKhau;
                txtmathuthu.Text = tAIKHOANTHUTHU.MaThuThu;
            }
          
        }

        private void Txttaotaikhoan_Click(object sender, RoutedEventArgs e)
        {
            tAIKHOANTHUTHU = new TAIKHOANTHUTHU();
                if (String.IsNullOrWhiteSpace(txttenthuthu.Text) == true)
                {
                    MessageBox.Show("Tên chưa điền");
                    txttenthuthu.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtmatkhau.Password) == true)
                {
                    MessageBox.Show("Mật khẩu chưa điền");
                    txtmatkhau.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(cmbtrangthai.Text) == true)
                {
                    MessageBox.Show("Trạng thái chưa điền");
                    cmbtrangthai.Focus();
                    return;
                }
                else
                {
                    tAIKHOANTHUTHU.TenTaiKhoai = txttenthuthu.Text.Trim();
                    tAIKHOANTHUTHU.MatKhau = Encrypt(txtmatkhau.Password.Trim());
                    tAIKHOANTHUTHU.TrangThai = cmbtrangthai.SelectionBoxItem.ToString();
                    tAIKHOANTHUTHU.MaThuThu = txtmathuthu.Text.Trim();
                    this.DialogResult = true;
                    this.Close();
                }
            
                
            
        }
    }
}
