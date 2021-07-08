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
                THELOAI tHELOAI = new THELOAI();
                tHELOAI.MaTheLoai = txtmatheloai.Text;
                tHELOAI.TenTheLoai = txttentheloai.Text;
                tHELOAI.MoTaTheLoai = txtmota.Text;
                dc.THELOAIs.Add(tHELOAI);
                dc.SaveChanges();
                hienthi();
             
            }
            else if (rdoSua.IsChecked == true)
            {
                string matheloai = txtmatheloai.Text;
                THELOAI tHELOAI = dc.THELOAIs.Find(matheloai);
                if (matheloai != null)
                {
                    tHELOAI.TenTheLoai = txttentheloai.Text;
                    tHELOAI.MoTaTheLoai = txtmota.Text;
                    dc.SaveChanges();
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
                    if (tHELOAI != null)
                    {
                        dc.THELOAIs.Remove(tHELOAI);
                        dc.SaveChanges();
                        hienthi();

                    }

                }
            }
        }

        private void RdoThem_Click(object sender, RoutedEventArgs e)
        {
            txtmatheloai.IsReadOnly = false;
            txttentheloai.IsReadOnly = false;
           
        }

        private void RdoSua_Click(object sender, RoutedEventArgs e)
        {
            txtmatheloai.IsReadOnly = true;
            txttentheloai.IsReadOnly = false;
            

        }
        private void RdoXoa_Click(object sender, RoutedEventArgs e)
        {
            txtmatheloai.IsReadOnly = true;
            txttentheloai.IsReadOnly = true;
        }
    }
}
