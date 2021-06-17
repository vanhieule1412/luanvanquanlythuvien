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
    /// Interaction logic for ViTriWindow.xaml
    /// </summary>
    public partial class ViTriWindow : Window
    {
        private Model.UngDungQuanLyThuVienEntities dc = new Model.UngDungQuanLyThuVienEntities();
        public ViTriWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            dgViTri.ItemsSource = dc.VITRIs.ToList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
        }
        private void RdoThem_Click(object sender, RoutedEventArgs e)
        {
            txtmavitri.IsReadOnly = false;
            txttenke.IsReadOnly = false;
            
        }

        private void RdoSua_Click(object sender, RoutedEventArgs e)
        {
            txtmavitri.IsReadOnly = true;
            txttenke.IsReadOnly = false;
           
        }

        private void Btnthuchien_Click(object sender, RoutedEventArgs e)
        {
            if (rdoThem.IsChecked == true)
            {
                Model.VITRI vITRI = new Model.VITRI();
                vITRI.MaKe = txtmavitri.Text;
                vITRI.TenKe = txttenke.Text;
                dc.VITRIs.Add(vITRI);
                dc.SaveChanges();
                hienthi();
            }
            else if (rdoSua.IsChecked == true)
            {
                string make = txtmavitri.Text;
                Model.VITRI vITRI = dc.VITRIs.Find(make);
                if (make != null)
                {
                    vITRI.TenKe = txttenke.Text;
                    dc.SaveChanges();
                }
                hienthi();
            }
            else if (rdoXoa.IsChecked == true)
            {
                if (dgViTri.SelectedItem == null) return;
                else
                {
                    string make = dgViTri.SelectedValue.ToString();
                    Model.VITRI vITRI = dc.VITRIs.Find(make);
                    if (vITRI != null)
                    {
                        dc.VITRIs.Remove(vITRI);
                        dc.SaveChanges();
                        hienthi();
                    }
                }
            }

        }

        private void DgViTri_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgViTri.SelectedItem == null) return;
            Model.VITRI vITRI = dgViTri.SelectedItem as Model.VITRI;
            txtmavitri.Text = vITRI.MaKe;
            txttenke.Text = vITRI.TenKe;
           
        }

        private void RdoXoa_Click(object sender, RoutedEventArgs e)
        {
            txtmavitri.IsReadOnly = true;
            txttenke.IsReadOnly = true;
           
        }
    }
}
