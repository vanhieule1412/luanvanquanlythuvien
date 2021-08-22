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
    /// Interaction logic for DanhSachTaiKhoanDocGiaWindow.xaml
    /// </summary>
    public partial class DanhSachTaiKhoanDocGiaWindow : Window
    {
        UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public DanhSachTaiKhoanDocGiaWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgtaikhoandocgia.ItemsSource = dc.TAIKHOANDOCGIAs.ToList();

        }
        private bool ktcodulieu(int n)
        {
            foreach (var a in dc.THEDOCGIAs)
            {
                if (a.MaTaiKhoaiDocGia == n)
                {
                    return true;
                }

            }
            return false;
        }
        private void BtnTaoTheDocGia_Click(object sender, RoutedEventArgs e)
        {
            DateTime time = DateTime.Now;
            GiaoDien.TheDocGiaWindow f = new TheDocGiaWindow();            
            f.TAIKHOANDOCGIA = dc.TAIKHOANDOCGIAs.Find(int.Parse(dgtaikhoandocgia.SelectedValue.ToString()));
            if (ktcodulieu(f.TAIKHOANDOCGIA.MaTaiKhoaiDocGia) == false)
            {
                f.ShowDialog();
                f.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản này đã tạo thẻ");
                return;
            }

       
            
        }

        private void Btnsuathongtintaikhoan_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.SuadocgiathuthuWindow f = new SuadocgiathuthuWindow();
            f.chucnang = KieuChucNang.suathuthu;
            f.tAIKHOANDOCGIA = dc.TAIKHOANDOCGIAs.Find(int.Parse(dgtaikhoandocgia.SelectedValue.ToString()));
            if (f.ShowDialog() == true)
            {
                TAIKHOANDOCGIA dg = dc.TAIKHOANDOCGIAs.Find(f.tAIKHOANDOCGIA.MaTaiKhoaiDocGia);
                if (dg != null)
                {
                    dg.TrangThai = f.tAIKHOANDOCGIA.TrangThai;
                    dg.MatKhau = f.tAIKHOANDOCGIA.MatKhau;
                    dc.SaveChanges();
                    dgtaikhoandocgia.ItemsSource = dc.TAIKHOANDOCGIAs.ToList();
                }
            }
        }
    }
}
