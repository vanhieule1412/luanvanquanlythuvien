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
    /// Interaction logic for CapNhatTheDocGiaWindow.xaml
    /// </summary>
    public partial class CapNhatTheDocGiaWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public CapNhatTheDocGiaWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            dgthedocgia.ItemsSource = dc.THEDOCGIAs.ToList();
            cmbmataikhoanthuthu.ItemsSource = dc.TAIKHOANTHUTHUs.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
        }

        private void Btncapnhat_Click(object sender, RoutedEventArgs e)
        {
            if (rdoSua.IsChecked == true)
            {
                string mathe = txtmathedocgia.Text;
                THEDOCGIA tHEDOCGIA = dc.THEDOCGIAs.Find(mathe);
                if (mathe != null)
                {
                    tHEDOCGIA.NgayTheDuocTao = dtpngaytao.SelectedDate.Value.Date;
                    tHEDOCGIA.NgayTheDuocGiaHan = dtpngayhethan.SelectedDate.Value.Date;
                    tHEDOCGIA.TenDocGia = txttendocgia.Text;
                    tHEDOCGIA.NamSinh = dpnamsinh.SelectedDate.Value.Date;
                    tHEDOCGIA.MaTaiKhoai = int.Parse(cmbmataikhoanthuthu.SelectedValue.ToString());
                    tHEDOCGIA.MaTaiKhoaiDocGia = int.Parse(txtmatkdocgia.Text);
                    dc.SaveChanges();
                }
                hienthi();
            }
            else if (rdoXoa.IsChecked == true)
            {
                if (dgthedocgia.SelectedItem == null) return;
                else
                {
                    string mathe = dgthedocgia.SelectedValue.ToString();
                    THEDOCGIA tHEDOCGIA = dc.THEDOCGIAs.Find(mathe);
                    if (tHEDOCGIA != null)
                    {
                        dc.THEDOCGIAs.Remove(tHEDOCGIA);
                        dc.SaveChanges();
                        hienthi();
                    }
                }
            }
        }

        private void RdoSua_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RdoXoa_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dgthedocgia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            THEDOCGIA tHEDOCGIA = dgthedocgia.SelectedItem as THEDOCGIA;
            if (tHEDOCGIA != null)
            {
                txtmathedocgia.Text = tHEDOCGIA.MaTheDocGia;
                dtpngaytao.SelectedDate = tHEDOCGIA.NgayTheDuocTao;
                dtpngayhethan.SelectedDate = tHEDOCGIA.NgayTheDuocGiaHan;
                txttendocgia.Text = tHEDOCGIA.TenDocGia;
                dpnamsinh.SelectedDate = tHEDOCGIA.NamSinh;
                txtmatkdocgia.Text = tHEDOCGIA.MaTaiKhoaiDocGia.ToString();
                cmbmataikhoanthuthu.SelectedValue = tHEDOCGIA.MaTaiKhoai;
                hienthi();
            }
        }
    }
}
