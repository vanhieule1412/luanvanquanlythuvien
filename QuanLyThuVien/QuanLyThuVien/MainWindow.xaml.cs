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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyThuVien
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void Btnquanltheloai_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.TheLoaiWindow f = new GiaoDien.TheLoaiWindow();
            f.ShowDialog();
        }

        private void Btnquanlnhaxuatban_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.NhaXuatBanWindow fnxb = new GiaoDien.NhaXuatBanWindow();
            fnxb.ShowDialog();
            
        }

        private void Btnvitri_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.ViTriWindow fvitri = new GiaoDien.ViTriWindow();
            fvitri.ShowDialog();
        }

        private void Btnthuthu_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.ThuThuWindow fthuthu = new GiaoDien.ThuThuWindow();
            fthuthu.ShowDialog();
        }

        private void Btndocgia_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.DocGiaWindow fdocgia = new GiaoDien.DocGiaWindow();
            fdocgia.ShowDialog();
        }
    }
}
