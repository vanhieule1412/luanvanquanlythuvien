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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtsodienthoai.Text  =TAIKHOANTHUTHU.THUTHU.SoDienThoai.ToString();
            txtemail.Text = TAIKHOANTHUTHU.THUTHU.Email;
            txtcmnd.Text = TAIKHOANTHUTHU.THUTHU.CMND.ToString();
            txtsodienthoai.Text = TAIKHOANTHUTHU.THUTHU.SoDienThoai.ToString();
            txtmatkhua.Text = TAIKHOANTHUTHU.MatKhau;
        }

        private void Btnluu_Click(object sender, RoutedEventArgs e)
        {
            TAIKHOANTHUTHU aIKHOANTHUTHU = dc.TAIKHOANTHUTHUs.Find(int.Parse(TAIKHOANTHUTHU.MaTaiKhoai.ToString()));
            if (TAIKHOANTHUTHU.MaTaiKhoai.ToString() != null)
            {
                aIKHOANTHUTHU.THUTHU.SoDienThoai = int.Parse(txtsodienthoai.Text);
                aIKHOANTHUTHU.THUTHU.Email = txtemail.Text;
                aIKHOANTHUTHU.THUTHU.CMND = int.Parse(txtcmnd.Text);
                aIKHOANTHUTHU.MatKhau = txtmatkhua.Text;
                MessageBox.Show("Sửa thành công");
                dc.SaveChanges();
            }
        }
    }
}
