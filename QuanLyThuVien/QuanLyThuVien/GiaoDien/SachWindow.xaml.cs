using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for SachWindow.xaml
    /// </summary>
    public partial class SachWindow : Window
    {
        private Model.UngDungQuanLyThuVienEntities dc = new Model.UngDungQuanLyThuVienEntities();
        private string path = "";
        private string tenFileHinh = "";
        public SachWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            dgSach.ItemsSource = dc.SACHes.ToList();
            cmbMatheloai.ItemsSource = dc.THELOAIs.ToList();
            cmbManhaxuatban.ItemsSource = dc.NHAXUATBANs.ToList();
            cmbMake.ItemsSource = dc.VITRIs.ToList();
        }
        private void DgSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if (dgSach.SelectedItem == null) return;
            Model.SACH s = dgSach.SelectedItem as Model.SACH;
            
            
                txtMasach.Text = s.MaSach;
                txtTensach.Text = s.TenSach;
                txtsoluong.Text = s.SoLuong.ToString();
                txttacgia.Text = s.TacGia;
                txtnamxuatban.Text = s.NamXuatBan.ToString();
                txtnguoidich.Text = s.NguoiDich;
                BitmapImage tempBM = imghinh.Source as BitmapImage;
                if (tempBM != null)
                {
                    tempBM.StreamSource.Close();
                    imghinh.Source = null;
                }
                if (s.Hinh != "")
                {
                    string tenfile = path + s.Hinh;
                    tenFileHinh = tenfile;
                    if (File.Exists(tenfile))
                    {
                        BitmapImage tm = new BitmapImage();
                        tm.BeginInit();
                        tm.StreamSource = new FileStream(tenfile, FileMode.Open);
                        tm.EndInit();
                        imghinh.Source = tm;
                    }
                }
                else
                {
                    imghinh.Source = null;
                }
                cmbMatheloai.SelectedValue = s.THELOAI.MaTheLoai;
                cmbManhaxuatban.SelectedValue = s.NHAXUATBAN.MaNhaXuatBan;
                cmbMake.SelectedValue = s.VITRI.MaKe;
            
            
        }
        private void Btnthuchien_Click(object sender, RoutedEventArgs e)
        {
            if (rdoThem.IsChecked == true)
            {
                Model.SACH sACH = new Model.SACH();
                sACH.MaSach = txtMasach.Text;
                sACH.TenSach = txtTensach.Text;
                sACH.SoLuong = int.Parse(txtsoluong.Text);
                sACH.TacGia = txttacgia.Text;
                sACH.NamXuatBan =int.Parse(txtnamxuatban.Text);
                sACH.NguoiDich = txtnguoidich.Text;
                sACH.MaTheLoai = cmbMatheloai.SelectedValue.ToString();
                sACH.MaNhaXuatBan = cmbManhaxuatban.SelectedValue.ToString();
                sACH.MaKe = cmbMake.SelectedValue.ToString();
                FileInfo fi = new FileInfo(tenFileHinh);
                sACH.Hinh = sACH.MaSach + fi.Extension;
                File.Copy(tenFileHinh, path + sACH.Hinh);
                dc.SACHes.Add(sACH);
                dc.SaveChanges();
                hienthi();
            }
            else if (rdoSua.IsChecked == true)
            { }
            else if (rdoXoa.IsChecked == true)
            { }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DirectoryInfo di = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
            di = di.Parent;
            di = di.Parent;
            path = di.FullName + @"\Hinhanh\";
            hienthi();
        }

        private void BtnChonhinh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();
            if (dig.ShowDialog() == true)
            {
                tenFileHinh = dig.FileName;
                BitmapImage tempBM = imghinh.Source as BitmapImage;
                if (tempBM != null)
                {
                    tempBM.StreamSource.Close();
                    imghinh.Source = null;
                }
                if (File.Exists(tenFileHinh))
                {
                    BitmapImage tm = new BitmapImage();
                    tm.BeginInit();
                    tm.StreamSource = new FileStream(tenFileHinh, FileMode.Open);
                    tm.EndInit();
                    imghinh.Source = tm;
                }
            }
        }

        private void BtnBohinh_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage tempBM = imghinh.Source as BitmapImage;
            if (tempBM != null)
            {
                tempBM.StreamSource.Close();
                imghinh.Source = null;
            }
            tenFileHinh = "";
            imghinh.Source = null;
        }
    }
}
