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
    /// Interaction logic for DanhsachtaikhoanthuthuWindow.xaml
    /// </summary>
    public partial class DanhsachtaikhoanthuthuWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public DanhsachtaikhoanthuthuWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           dgtaikhoanthuthu.ItemsSource = dc.TAIKHOANTHUTHUs.ToList();
            

        }

        private void Btnsuataikhoan_Click(object sender, RoutedEventArgs e)
        {

            GiaoDien.Suathuthuadmin f = new Suathuthuadmin();
            f.chucnang = KieuChucNang.suaadmin;
            f.tAIKHOANTHUTHU = dc.TAIKHOANTHUTHUs.Find(int.Parse(dgtaikhoanthuthu.SelectedValue.ToString()));
            if (f.ShowDialog() == true)
            {
                TAIKHOANTHUTHU tt = dc.TAIKHOANTHUTHUs.Find(f.tAIKHOANTHUTHU.MaTaiKhoai);
                if (tt != null)
                {
                    tt.TrangThai = f.tAIKHOANTHUTHU.TrangThai;
                    tt.MatKhau = f.tAIKHOANTHUTHU.MatKhau;
                    dc.SaveChanges();
                    dgtaikhoanthuthu.ItemsSource = dc.TAIKHOANTHUTHUs.ToList();
                }
            }
        }
    }
}
