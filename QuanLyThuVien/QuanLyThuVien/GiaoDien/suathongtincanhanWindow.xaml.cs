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
    /// Interaction logic for suathongtincanhanWindow.xaml
    /// </summary>
    public partial class suathongtincanhanWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public DOCGIA DOCGIA;
        public TAIKHOANDOCGIA TAIKHOANDOCGIA;
        public suathongtincanhanWindow()
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
            txtsodienthoai.Text = TAIKHOANDOCGIA.DOCGIA.SoDienThoai.ToString();
            txtemail.Text = TAIKHOANDOCGIA.DOCGIA.Email;
            txtdiachi.Text = TAIKHOANDOCGIA.DOCGIA.DiaChi;
            txtcmnd.Text = TAIKHOANDOCGIA.DOCGIA.CMND.ToString();
            txtsodienthoai.Text = TAIKHOANDOCGIA.DOCGIA.SoDienThoai.ToString();

        }

        private void Btnluu_Click(object sender, RoutedEventArgs e)
        {
            TAIKHOANDOCGIA aIKHOANDOCGIA= dc.TAIKHOANDOCGIAs.Find(int.Parse(TAIKHOANDOCGIA.MaTaiKhoaiDocGia.ToString()));
            if (TAIKHOANDOCGIA.MaTaiKhoaiDocGia.ToString() != null)
            {
                aIKHOANDOCGIA.DOCGIA.SoDienThoai = txtsodienthoai.Text;
                aIKHOANDOCGIA.DOCGIA.Email = txtemail.Text;
                aIKHOANDOCGIA.DOCGIA.DiaChi = txtdiachi.Text;
                aIKHOANDOCGIA.DOCGIA.CMND = txtcmnd.Text;
                aIKHOANDOCGIA.MatKhau = Encrypt(txtmatkhua.Password) ;
                MessageBox.Show("Sửa thành công");
                dc.SaveChanges();
                this.Close();
            }
        }

        private void Btndoimatkhau_Click(object sender, RoutedEventArgs e)
        {
            txtmatkhua.Visibility = Visibility.Visible;
            btndoimatkhau.Visibility = Visibility.Collapsed;
        }
    }
}
