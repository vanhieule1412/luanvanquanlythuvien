using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for HeThongTimKiemWindow.xaml
    /// </summary>
    public partial class HeThongTimKiemWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public HeThongTimKiemWindow()
        {
            InitializeComponent();
        }

        private void Dgtimkiem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            dgtimkiem.ItemsSource = dc.SACHes.ToList();
        }

        private void Txttimkiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txttimkiem.Text != "" && cmbtimten.IsSelected)
            {
                var filteredsach = dc.SACHes.Where(x => x.TenSach.ToLower().Contains(txttimkiem.Text.ToLower()));
                
                dgtimkiem.ItemsSource = null;
                dgtimkiem.ItemsSource = filteredsach.ToList();
                
            }
            else if(txttimkiem.Text != "" && cmbtimnamxuatban.IsSelected)
            {
                var filterednamxuatban = dc.SACHes.Where(x => x.NamXuatBan.ToString().Contains(txttimkiem.Text.ToString()));

                dgtimkiem.ItemsSource = null;
                dgtimkiem.ItemsSource = filterednamxuatban.ToList();


            }
            else
            {
                
                dgtimkiem.ItemsSource = dc.SACHes.ToList();
            }
        }
    }
}
