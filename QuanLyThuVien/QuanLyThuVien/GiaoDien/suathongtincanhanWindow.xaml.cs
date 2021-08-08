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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtsodienthoai.Text = TAIKHOANDOCGIA.DOCGIA.SoDienThoai.ToString();
            txtemail.Text = TAIKHOANDOCGIA.DOCGIA.Email;
            txtdiachi.Text = TAIKHOANDOCGIA.DOCGIA.DiaChi;
            txtcmnd.Text = TAIKHOANDOCGIA.DOCGIA.CMND.ToString();
            txtsodienthoai.Text = TAIKHOANDOCGIA.DOCGIA.SoDienThoai.ToString();
            txtmatkhua.Text = TAIKHOANDOCGIA.MatKhau;

        }

        private void Btnluu_Click(object sender, RoutedEventArgs e)
        {
            TAIKHOANDOCGIA aIKHOANDOCGIA= dc.TAIKHOANDOCGIAs.Find(int.Parse(TAIKHOANDOCGIA.MaTaiKhoaiDocGia.ToString()));
            if (TAIKHOANDOCGIA.MaTaiKhoaiDocGia.ToString() != null)
            {
                aIKHOANDOCGIA.DOCGIA.SoDienThoai = int.Parse(txtsodienthoai.Text);
                aIKHOANDOCGIA.DOCGIA.Email = txtemail.Text;
                aIKHOANDOCGIA.DOCGIA.DiaChi = txtdiachi.Text;
                aIKHOANDOCGIA.DOCGIA.CMND = int.Parse(txtcmnd.Text);
                aIKHOANDOCGIA.MatKhau = txtmatkhua.Text;
                MessageBox.Show("Sửa thành công");
                dc.SaveChanges();
            }
        }
    }
}
