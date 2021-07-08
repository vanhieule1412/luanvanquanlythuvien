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
    /// Interaction logic for KhuWindow.xaml
    /// </summary>
    public partial class KhuWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public KhuWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            dgkhu.ItemsSource = dc.KHUs.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
        }

        private void RdoThem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RdoSua_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RdoXoa_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btnthuchien_Click(object sender, RoutedEventArgs e)
        {
            if (rdoThem.IsChecked == true)
            {
                KHU kHU = new KHU();
                kHU.MaKhu = txtmakhu.Text;
                kHU.TenKhu = txttenkhu.Text;
                dc.KHUs.Add(kHU);
                dc.SaveChanges();
                hienthi();
            }
            else if (rdoSua.IsChecked == true)
            {
                string makhu = txtmakhu.Text;
                KHU kHU = dc.KHUs.Find(makhu);
                if (makhu != null)
                {
                    kHU.TenKhu = txttenkhu.Text;
                    dc.SaveChanges();
                }
                hienthi();
            }
            else if (rdoXoa.IsChecked == true)
            {
                if (dgkhu.SelectedItem == null) return;
                else
                {
                    string makhu = dgkhu.SelectedValue.ToString();
                    KHU kHU = dc.KHUs.Find(makhu);
                    if (kHU != null)
                    {
                        dc.KHUs.Remove(kHU);
                        dc.SaveChanges();
                        hienthi();
                    }
                }
            }
        }

        private void Dgkhu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            KHU kHU = dgkhu.SelectedItem as KHU;

            if (kHU != null)
            {
                txtmakhu.Text = kHU.MaKhu;
                txttenkhu.Text = kHU.TenKhu;
            }
            else
            {

                return;
            }
        }
    }
}
