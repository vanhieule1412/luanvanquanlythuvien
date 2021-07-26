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
    }
}
