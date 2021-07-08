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
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public ViTriWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            
            cmbmakhu.ItemsSource = dc.KHUs.ToList();
            dgViTri.ItemsSource = dc.KEs.ToList();
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
                KE k = dc.KEs.Find(txtmavitri.Text);
                if (k != null)
                {
                    MessageBox.Show("Trùng mã");
                    return;
                }
                KE kE = new KE();
                kE.MaKe = txtmavitri.Text;
                kE.TenKe = txttenke.Text;
                kE.MaKhu = cmbmakhu.SelectedValue.ToString();
                dc.KEs.Add(kE);
                dc.SaveChanges();
                hienthi();
            }
            else if (rdoSua.IsChecked == true)
            {
                string make = txtmavitri.Text;
                KE kE = dc.KEs.Find(make);
                if (make != null)
                {
                    kE.TenKe = txttenke.Text;
                    kE.MaKhu = cmbmakhu.SelectedValue.ToString();
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
                    KE kE = dc.KEs.Find(make);
                    if (kE != null)
                    {
                        dc.KEs.Remove(kE);
                        dc.SaveChanges();
                        hienthi();
                    }
                }
            }

        }

        private void DgViTri_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KE kE = dgViTri.SelectedItem as KE;
            if (kE != null)
            {
                txtmavitri.Text = kE.MaKe;
                txttenke.Text = kE.TenKe;
                hienthi();
                cmbmakhu.SelectedValue = kE.KHU.MaKhu;
            }
            else
            {
                txtmavitri.Text = "";
                txttenke.Text = "";
                cmbmakhu.SelectedValue = null;
                return;
            }



        }

        private void RdoXoa_Click(object sender, RoutedEventArgs e)
        {
            txtmavitri.IsReadOnly = true;
            txttenke.IsReadOnly = true;          
        }

       
    }
}
