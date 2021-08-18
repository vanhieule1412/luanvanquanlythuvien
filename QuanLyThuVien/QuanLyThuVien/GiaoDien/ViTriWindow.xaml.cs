using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            clear();
            txtmavitri.IsReadOnly = false;
            txttenke.IsReadOnly = false;
            cmbmakhu.IsEnabled = true;
            
        }

        private void RdoSua_Click(object sender, RoutedEventArgs e)
        {
            txtmavitri.IsReadOnly = true;
            txttenke.IsReadOnly = false;
            cmbmakhu.IsEnabled = true;
           
        }
        private void clear()
        {
            txtmavitri.Text = "";
            txttenke.Text = "";
            cmbmakhu.Text = " ";
            txtmavitri.Focus();
        }
        private bool HasSpecialChars(string yourString)
        {
            return yourString.Any(ch => !Char.IsLetterOrDigit(ch));
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
                Regex trimmer = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
                txttenke.Text = trimmer.Replace(txttenke.Text, " ");               
                if (HasSpecialChars(txtmavitri.Text) == true)
                {
                    MessageBox.Show("Mã không được có kí tự đặc biệt hoặc khoảng trắng");
                    txtmavitri.Focus();
                    txtmavitri.Select(txtmavitri.Text.Length, 0);
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtmavitri.Text) == true)
                {
                    MessageBox.Show("Mã chưa điền");
                    txtmavitri.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(txttenke.Text) == true)
                {
                    MessageBox.Show("Tên chưa điền");
                    txttenke.Focus();
                    return;
                }             
                else
                {
                    KE kE = new KE();
                    kE.MaKe = txtmavitri.Text.Trim();
                    kE.TenKe = txttenke.Text.Trim();
                    kE.MaKhu = cmbmakhu.SelectedValue.ToString();
                    dc.KEs.Add(kE);
                    dc.SaveChanges();
                    hienthi();
                }
            }
            else if (rdoSua.IsChecked == true)
            {
                string make = txtmavitri.Text;
                KE kE = dc.KEs.Find(make);
                if (make != null)
                {
                    Regex trimmer = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
                    txttenke.Text = trimmer.Replace(txttenke.Text, " ");
                    if (HasSpecialChars(txtmavitri.Text) == true)
                    {
                        MessageBox.Show("Mã không được có kí tự đặc biệt hoặc khoảng trắng");
                        txtmavitri.Focus();
                        txtmavitri.Select(txtmavitri.Text.Length, 0);
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(txtmavitri.Text) == true)
                    {
                        MessageBox.Show("Mã chưa điền");
                        txtmavitri.Focus();
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(txttenke.Text) == true)
                    {
                        MessageBox.Show("Tên chưa điền");
                        txttenke.Focus();
                        return;
                    }
                    else
                    {
                        kE.TenKe = txttenke.Text;
                        kE.MaKhu = cmbmakhu.SelectedValue.ToString();
                        dc.SaveChanges();
                    }
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
                    var ds = dc.SACHes.Where(x => x.MaKe == make).ToList();
                    if (ds.Count > 0)
                    {
                        MessageBox.Show("Kệ này không thể xóa được");
                        return;
                    }
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
            cmbmakhu.IsEnabled = false;
        }

       
    }
}
