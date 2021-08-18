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
            txtmakhu.IsReadOnly = false;
            txttenkhu.IsReadOnly = false;
           
        }

        private void RdoSua_Click(object sender, RoutedEventArgs e)
        {
            txtmakhu.IsReadOnly = true;
            txttenkhu.IsReadOnly = false;
        }

        private void RdoXoa_Click(object sender, RoutedEventArgs e)
        {
            txtmakhu.IsReadOnly = true;
            txttenkhu.IsReadOnly = true;
        }
        private bool HasSpecialChars(string yourString)
        {
            return yourString.Any(ch => !Char.IsLetterOrDigit(ch));
        }
        private void Btnthuchien_Click(object sender, RoutedEventArgs e)
        {
            if (rdoThem.IsChecked == true)
            {
                KHU k = dc.KHUs.Find(txtmakhu.Text);
                if (k != null)
                {
                    MessageBox.Show("Trùng mã");
                    return;
                }
                Regex trimmer = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
                txttenkhu.Text = trimmer.Replace(txttenkhu.Text, " ");
                if (HasSpecialChars(txtmakhu.Text) == true)
                {
                    MessageBox.Show("Mã không được có kí tự đặc biệt hoặc khoảng trắng");
                    txtmakhu.Focus();
                    txtmakhu.Select(txtmakhu.Text.Length, 0);
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtmakhu.Text) == true)
                {
                    MessageBox.Show("Mã chưa điền");
                    txtmakhu.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(txttenkhu.Text) == true)
                {
                    MessageBox.Show("Tên chưa điền");
                    txttenkhu.Focus();
                    return;
                }
                else
                {
                    KHU kHU = new KHU();
                    kHU.MaKhu = txtmakhu.Text.Trim();
                    kHU.TenKhu = txttenkhu.Text.Trim();
                    dc.KHUs.Add(kHU);
                    dc.SaveChanges();
                    hienthi();
                }
            }
            else if (rdoSua.IsChecked == true)
            {
                string makhu = txtmakhu.Text;
                KHU kHU = dc.KHUs.Find(makhu);
                if (makhu != null)
                {
                    Regex trimmer = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
                    txttenkhu.Text = trimmer.Replace(txttenkhu.Text, " ");
                    if (String.IsNullOrWhiteSpace(txttenkhu.Text) == true)
                    {
                        MessageBox.Show("Tên chưa điền");
                        txttenkhu.Focus();
                        return;
                    }
                    else
                    {
                        kHU.TenKhu = txttenkhu.Text;
                    }
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
                    var ds = dc.KEs.Where(x => x.MaKhu == makhu ).ToList();
                    if (ds.Count > 0)
                    {
                        MessageBox.Show("Khu này không thể xóa được");
                        return;
                    }
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
