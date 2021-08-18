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
    /// Interaction logic for TheLoaiWindow.xaml
    /// </summary>
    public partial class TheLoaiWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public TheLoaiWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            //var kq = dc.THELOAIs.Select(x => new {
            //    MaTheLoai = x.MaTheLoai,
            //    TenTheLoai = x.TenTheLoai,
            //});
            dgTheLoai.ItemsSource =dc.THELOAIs.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
        }
        
        private void DgTheLoai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (dgTheLoai.SelectedItem == null) return;
           THELOAI tl = dgTheLoai.SelectedItem as THELOAI;
            if (tl != null)
            {
                txtmatheloai.Text = tl.MaTheLoai;
                txttentheloai.Text = tl.TenTheLoai;
                txtmota.Text = tl.MoTaTheLoai;
            }
            else {
                txtmatheloai.Text = "";
                txttentheloai.Text = "";
                txtmota.Text = "";
                return;
            }
     
        }
        private bool HasSpecialChars(string yourString)
        {
            return yourString.Any(ch => !Char.IsLetterOrDigit(ch));
        }
        private void Btnthuchien_Click(object sender, RoutedEventArgs e)
        {
            if (rdoThem.IsChecked == true)
            {
                THELOAI k = dc.THELOAIs.Find(txtmatheloai.Text);
                if (k != null)
                {
                    MessageBox.Show("Trùng mã");
                    return;
                }
                Regex trimmer = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
                txttentheloai.Text = trimmer.Replace(txttentheloai.Text, " ");
                txtmota.Text = trimmer.Replace(txtmota.Text, " ");                
                if (HasSpecialChars(txtmatheloai.Text) == true)
                {
                    MessageBox.Show("Mã không được có kí tự đặc biệt hoặc khoảng trắng");
                    txtmatheloai.Focus();
                    txtmatheloai.Select(txtmatheloai.Text.Length, 0);
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtmatheloai.Text) == true)
                {
                    MessageBox.Show("Mã chưa điền");
                    txtmatheloai.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(txttentheloai.Text) == true)
                {
                    MessageBox.Show("Tên chưa điền");
                    txttentheloai.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtmota.Text) == true)
                {
                    MessageBox.Show("Mô tả chưa điền");
                    txtmota.Focus();
                    return;
                }
                else
                {
                    THELOAI tHELOAI = new THELOAI();
                    tHELOAI.MaTheLoai = txtmatheloai.Text.Trim().ToUpper();
                    tHELOAI.TenTheLoai = txttentheloai.Text.Trim();
                    tHELOAI.MoTaTheLoai = txtmota.Text.Trim();
                    dc.THELOAIs.Add(tHELOAI);
                    dc.SaveChanges();
                    clear();
                    hienthi();
                }
             
            }
            else if (rdoSua.IsChecked == true)
            {
                string matheloai = txtmatheloai.Text;
                THELOAI tHELOAI = dc.THELOAIs.Find(matheloai);
                if (matheloai != null)
                {
                    Regex trimmer = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
                    txttentheloai.Text = trimmer.Replace(txttentheloai.Text, " ");
                    txtmota.Text = trimmer.Replace(txtmota.Text, " ");
                    if (HasSpecialChars(txtmatheloai.Text) == true)
                    {
                        MessageBox.Show("Mã không được có kí tự đặc biệt hoặc khoảng trắng");
                        txtmatheloai.Focus();
                        txtmatheloai.Select(txtmatheloai.Text.Length, 0);
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(txtmatheloai.Text) == true)
                    {
                        MessageBox.Show("Mã chưa điền");
                        txtmatheloai.Focus();
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(txttentheloai.Text) == true)
                    {
                        MessageBox.Show("Tên chưa điền");
                        txttentheloai.Focus();
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(txtmota.Text) == true)
                    {
                        MessageBox.Show("Mô tả chưa điền");
                        txtmota.Focus();
                        return;
                    }
                    else
                    {
                        tHELOAI.TenTheLoai = txttentheloai.Text.Trim();
                        tHELOAI.MoTaTheLoai = txtmota.Text.Trim();
                        dc.SaveChanges();
                    }
                }
                hienthi();
            }
            else if(rdoXoa.IsChecked==true)
            {
                if (dgTheLoai.SelectedItem == null) return;
                else
                {
                    string matheloai = dgTheLoai.SelectedValue.ToString();
                    THELOAI tHELOAI = dc.THELOAIs.Find(matheloai);
                    var ds = dc.SACHes.Where(x => x.MaTheLoai == matheloai).ToList();
                    if (ds.Count > 0)
                    {
                        MessageBox.Show("Thể loại này không thể xóa được");
                        return;
                    }
                    if (tHELOAI != null)
                    {
                        dc.THELOAIs.Remove(tHELOAI);
                        dc.SaveChanges();
                        hienthi();
                    }

                }
            }
        }
        private void clear()
        {
            txtmatheloai.Text = "";
            txttentheloai.Text = "";
            txtmota.Text = "";
            txtmatheloai.Focus();

        }
        private void RdoThem_Click(object sender, RoutedEventArgs e)
        {
            clear();
            txtmatheloai.IsReadOnly = false;
            txttentheloai.IsReadOnly = false;
            txtmota.IsReadOnly = false;
           
        }

        private void RdoSua_Click(object sender, RoutedEventArgs e)
        {
            txtmatheloai.IsReadOnly = true;
            txttentheloai.IsReadOnly = false;
            txtmota.IsReadOnly = false;
            

        }
        private void RdoXoa_Click(object sender, RoutedEventArgs e)
        {
            txtmatheloai.IsReadOnly = true;
            txttentheloai.IsReadOnly = true;
            txtmota.IsReadOnly = true;
        }
    }
}
