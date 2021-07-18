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
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public DocGiaWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            cmbmataikhoanthuthu.ItemsSource =dc.TAIKHOANTHUTHUs.ToList();
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
                DOCGIA oCGIA = dc.DOCGIAs.Find(txtmadocgia.Text);
                if (oCGIA != null)
                {
                    MessageBox.Show("Trùng mã");
                    return;
                }
                DOCGIA dOCGIA = new DOCGIA();
                dOCGIA.MaDocGia = txtmadocgia.Text;
                dOCGIA.TenDocGia = txttendocgia.Text;
                dOCGIA.NamSinh = dtpnamsinh.SelectedDate.Value;
                dOCGIA.SoDienThoai = int.Parse(txtsodienthoai.Text);
                dOCGIA.Email = txtemail.Text;
                dOCGIA.GioiTinh = cmbgioitinh.SelectionBoxItem.ToString();
                dOCGIA.DiaChi = txtdiachi.Text;
                dOCGIA.CMND = int.Parse(txtcmnd.Text);
                dOCGIA.MaTaiKhoai = int.Parse(cmbmataikhoanthuthu.SelectedValue.ToString());
                dc.DOCGIAs.Add(dOCGIA);
                dc.SaveChanges();
                hienthi();
            }
            else if (rdoSua.IsChecked == true)
            {
                string madocgia = txtmadocgia.Text;
                DOCGIA dOCGIA = dc.DOCGIAs.Find(madocgia);
                if (madocgia != null)
                {
                    dOCGIA.TenDocGia = txttendocgia.Text;
                    dOCGIA.NamSinh = dtpnamsinh.SelectedDate.Value;
                    dOCGIA.SoDienThoai = int.Parse(txtsodienthoai.Text);
                    dOCGIA.Email = txtemail.Text;
                    dOCGIA.GioiTinh = cmbgioitinh.SelectionBoxItem.ToString();
                    dOCGIA.DiaChi = txtdiachi.Text;
                    dOCGIA.CMND = int.Parse(txtcmnd.Text);
                    dOCGIA.MaTaiKhoai = int.Parse(cmbmataikhoanthuthu.SelectedValue.ToString());
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
            DOCGIA dOCGIA = dgDocGia.SelectedItem as DOCGIA;
            if (dOCGIA != null)
            {
                txtmadocgia.Text = dOCGIA.MaDocGia;
                txttendocgia.Text = dOCGIA.TenDocGia;
                dtpnamsinh.SelectedDate = dOCGIA.NamSinh;
                txtsodienthoai.Text = dOCGIA.SoDienThoai.ToString();
                txtemail.Text = dOCGIA.Email;
                txtdiachi.Text = dOCGIA.DiaChi;
                txtcmnd.Text = dOCGIA.CMND.ToString();
                if (dOCGIA.GioiTinh == "Nam")
                {
                    cmbnam.IsSelected = true;
                }
                else if (dOCGIA.GioiTinh == "Nữ")
                {
                    cmbnu.IsSelected = true;
                }
                cmbmataikhoanthuthu.SelectedValue = dOCGIA.MaTaiKhoai.ToString();
            }
            else
            {
                return;
            }
          

        }

        private void Btntaotaikhoandocgia_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.TaiKhoanDocGiaWindow ftaikhoan = new TaiKhoanDocGiaWindow();
            ftaikhoan.chucnang = KieuChucNang.Them;
            ftaikhoan.DOCGIA = dc.DOCGIAs.Find(dgDocGia.SelectedValue.ToString());
            string madocgia = dgDocGia.SelectedValue.ToString();
            var ds = dc.TAIKHOANDOCGIAs.Where(x => x.MaDocGia == madocgia).ToList();
            if (ds.Count > 0)
            {
                MessageBox.Show("Đọc giả này đã có tài khoản");
                return;
            }
            if (ftaikhoan.ShowDialog() == true)
            {
                dc.TAIKHOANDOCGIAs.Add(ftaikhoan.tAIKHOANDOCGIA);
                dc.SaveChanges();

            }
        }
    }
}
