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
    /// Interaction logic for DocGiaWindow.xaml
    /// </summary>
    public partial class DocGiaWindow : Window
    {
        private Model.UngDungQuanLyThuVienEntities dc = new Model.UngDungQuanLyThuVienEntities();
        public DocGiaWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            dgDocGia.ItemsSource = dc.DOCGIAs.ToList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
        }

        private void Btnthuchien_Click(object sender, RoutedEventArgs e)
        {
            if (rdoThem.IsChecked == true)
            {
                Model.DOCGIA dOCGIA = new Model.DOCGIA();
                dOCGIA.MaDocGia = txtmadocgia.Text;
                dOCGIA.TenDocGia = txttendocgia.Text;
                dOCGIA.NamSinh = int.Parse(txtnamsinh.Text);
                dOCGIA.SoDienThoai = int.Parse(txtsodienthoai.Text);
                dOCGIA.MatKhau = txtmatkhau.Text;
                dc.DOCGIAs.Add(dOCGIA);
                dc.SaveChanges();
                hienthi();
            }
            else if (rdoSua.IsChecked == true)
            {
                string madocgia = txtmadocgia.Text;
                Model.DOCGIA dOCGIA = dc.DOCGIAs.Find(madocgia);
                if (madocgia != null)
                {
                    dOCGIA.TenDocGia = txttendocgia.Text;
                    dOCGIA.NamSinh = int.Parse(txtnamsinh.Text);
                    dOCGIA.SoDienThoai = int.Parse(txtsodienthoai.Text);
                    dOCGIA.MatKhau = txtmatkhau.Text;
                    dc.SaveChanges();
                }
                hienthi();
            }
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

        private void DgDocGia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgDocGia.SelectedItem == null) return;
            Model.DOCGIA dOCGIA = dgDocGia.SelectedItem as Model.DOCGIA;
            txtmadocgia.Text = dOCGIA.MaDocGia;
            txttendocgia.Text = dOCGIA.TenDocGia;
            txtnamsinh.Text = dOCGIA.NamSinh.ToString();
            txtsodienthoai.Text = dOCGIA.SoDienThoai.ToString();
            txtmatkhau.Text = dOCGIA.MatKhau;
        }
    }
}
