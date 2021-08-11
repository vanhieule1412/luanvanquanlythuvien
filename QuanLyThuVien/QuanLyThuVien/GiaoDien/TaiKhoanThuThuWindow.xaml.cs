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
    /// Interaction logic for TaiKhoanThuThuWindow.xaml
    /// </summary>
    public enum KieuChucNang {Them,Sua}
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
            byte[] data = UTF8Encoding.UTF8.GetBytes(decrypted);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider tripDES = new TripleDESCryptoServiceProvider();
            tripDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(decrypted));
            tripDES.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripDES.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
            return Convert.ToBase64String(result);
        }
     

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (chucnang == KieuChucNang.Them)
            {
                txtmathuthu.Text = THUTHU.MaThuThu;
            }
            else if(chucnang ==KieuChucNang.Sua)
            {
                txttenthuthu.Text = tAIKHOANTHUTHU.TenTaiKhoai;
                txtmatkhau.Text = tAIKHOANTHUTHU.MatKhau;
                txtmathuthu.Text = tAIKHOANTHUTHU.MaThuThu;

            }
        }

        private void Txttaotaikhoan_Click(object sender, RoutedEventArgs e)
        {
            tAIKHOANTHUTHU = new TAIKHOANTHUTHU();
            tAIKHOANTHUTHU.TenTaiKhoai = txttenthuthu.Text;
            tAIKHOANTHUTHU.MatKhau = Encrypt(txtmatkhau.Text);
            tAIKHOANTHUTHU.TrangThai = cmbtrangthai.SelectionBoxItem.ToString();
            tAIKHOANTHUTHU.MaThuThu=txtmathuthu.Text;
            this.DialogResult = true;
            this.Close();
        }
    }
}
