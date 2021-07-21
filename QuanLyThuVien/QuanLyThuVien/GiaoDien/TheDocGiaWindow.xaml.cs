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
    /// Interaction logic for TheDocGiaWindow.xaml
    /// </summary>
    public partial class TheDocGiaWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public TheDocGiaWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            dgthedocgia.ItemsSource = dc.THEDOCGIAs.ToList();
            cmbmataikhoandocgia.ItemsSource = dc.TAIKHOANDOCGIAs.ToList();
            cmbmataikhoanthuthu.ItemsSource = dc.TAIKHOANTHUTHUs.ToList();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
        }

        private void Btntaotaikhoan_Click(object sender, RoutedEventArgs e)
        {
            if (rdoThem.IsChecked == true)
            {
                THEDOCGIA HEDOCGIA = dc.THEDOCGIAs.Find(txtmathedocgia.Text);
                if (HEDOCGIA != null)
                {
                    MessageBox.Show("Trùng mã");
                    return;
                }
                THEDOCGIA tHEDOCGIA = new THEDOCGIA();
                tHEDOCGIA.MaTheDocGia = txtmathedocgia.Text.Trim().ToUpper();
                tHEDOCGIA.NgayTheDuocTao = dtpngaytao.SelectedDate.Value.Date;
                tHEDOCGIA.NgayTheDuocGiaHan = dtpngayhethan.SelectedDate.Value.Date;
                tHEDOCGIA.TenDocGia = txttendocgia.Text;
                tHEDOCGIA.NamSinh = dtpnamsinh.SelectedDate.Value.Date;
                tHEDOCGIA.MaTaiKhoai = int.Parse(cmbmataikhoanthuthu.SelectedValue.ToString());
                tHEDOCGIA.MaTaiKhoaiDocGia = int.Parse(cmbmataikhoandocgia.SelectedValue.ToString());
                dc.THEDOCGIAs.Add(tHEDOCGIA);
                dc.SaveChanges();
                hienthi();

                //var ds = dc.DOCGIAs.Where(x => x.TenDocGia == null).ToList();
                //if (ds.Count >= 1)
                //{
                   
                    
                //}
                //else
                //{
                //    MessageBox.Show("Tên không hợp lệ");
                //    return;
                //}
                
            }
            else if (rdoSua.IsChecked == true)
            {
                string mathe = txtmathedocgia.Text;
                THEDOCGIA tHEDOCGIA = dc.THEDOCGIAs.Find(mathe);
                if (mathe != null)
                {
                    tHEDOCGIA.NgayTheDuocTao = dtpngaytao.SelectedDate.Value.Date;
                    tHEDOCGIA.NgayTheDuocGiaHan = dtpngayhethan.SelectedDate.Value.Date;
                    tHEDOCGIA.TenDocGia = txttendocgia.Text;
                    tHEDOCGIA.NamSinh = dtpnamsinh.SelectedDate.Value.Date;
                    tHEDOCGIA.MaTaiKhoai = int.Parse(cmbmataikhoanthuthu.SelectedValue.ToString());
                    tHEDOCGIA.MaTaiKhoaiDocGia = int.Parse(cmbmataikhoandocgia.SelectedValue.ToString());

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

        private void Dgthedocgia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            THEDOCGIA tHEDOCGIA = dgthedocgia.SelectedItem as THEDOCGIA;
            if (tHEDOCGIA != null)
            {
                txtmathedocgia.Text = tHEDOCGIA.MaTheDocGia;
                dtpngaytao.SelectedDate = tHEDOCGIA.NgayTheDuocTao;
                dtpngayhethan.SelectedDate = tHEDOCGIA.NgayTheDuocGiaHan;
                txttendocgia.Text = tHEDOCGIA.TenDocGia;
                dtpnamsinh.SelectedDate = tHEDOCGIA.NamSinh;
                cmbmataikhoandocgia.SelectedValue = tHEDOCGIA.MaTaiKhoaiDocGia;
                cmbmataikhoanthuthu.SelectedValue = tHEDOCGIA.MaTaiKhoai;
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
    }
}
