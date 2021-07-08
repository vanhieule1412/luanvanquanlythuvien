using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        private string path = "";
        private string tenFileHinh = "";
        
        public SachWindow()
        {
            InitializeComponent();
           
        }
        private void hienthi()
        {
            //dgSach.ItemsSource = dc.SACHes.ToList();
            //cmbMatheloai.ItemsSource = dc.THELOAIs.ToList();
            //cmbManhaxuatban.ItemsSource = dc.NHAXUATBANs.ToList();
            //cmbMake.ItemsSource = dc.VITRIs.ToList();
            //var kq = dc.SACHes.Select(x => new
            //{
            //    MaSach = x.MaSach,
            //    TenSach = x.TenSach,
            //    SoLuong = x.SoLuong,
            //    NamXuatBan = x.NamXuatBan,
            //    TacGia = x.TacGia,
            //    NguoiDich = x.NguoiDich,
            //    TenTheLoai = x.THELOAI.TenTheLoai,
            //    TenNhaXuatBan = x.NHAXUATBAN.TenNhaXuatBan,
            //    TenKe = x.VITRI.TenKe,
            //});
            //dgSach.ItemsSource = kq.ToList();

        }
        private void DgSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (dgSach.SelectedItem == null) return;
            //SACH s = dgSach.SelectedItem as SACH;
            //if (s != null)
            //{
            //    txtMasach.Text = s.MaSach;
            //    txtTensach.Text = s.TenSach;
            //    txtsoluong.Text = s.SoLuong.ToString();
            //    txttacgia.Text = s.TacGia;
            //    txtnamxuatban.Text = s.NamXuatBan.ToString();
            //    txtnguoidich.Text = s.NguoiDich;
            //    BitmapImage tempBM = imghinh.Source as BitmapImage;
            //    if (tempBM != null)
            //    {
            //        tempBM.StreamSource.Close();
            //        imghinh.Source = null;
            //    }
            //    if (s.Hinh != "")
            //    {
            //        string tenfile = path + s.Hinh;
            //        tenFileHinh = tenfile;
            //        if (File.Exists(tenfile))
            //        {
            //            BitmapImage tm = new BitmapImage();
            //            tm.BeginInit();
            //            tm.StreamSource = new FileStream(tenfile, FileMode.Open);
            //            tm.EndInit();
            //            imghinh.Source = tm;
            //        }
            //    }
            //    else
            //    {
            //        imghinh.Source = null;
            //    }
            //    cmbMatheloai.SelectedValue = s.THELOAI.MaTheLoai;
            //    cmbManhaxuatban.SelectedValue = s.NHAXUATBAN.MaNhaXuatBan;
            //    cmbMake.SelectedValue = s.VITRI.MaKe;
            //}
            //else
            //{
            //    return;
            //}

            
               
            
            
        }
        private void Btnthuchien_Click(object sender, RoutedEventArgs e)
        {
            //if (rdoThem.IsChecked == true)
            //{
            //    SACH sACH = new SACH();
            //    sACH.MaSach = txtMasach.Text;
            //    sACH.TenSach = txtTensach.Text;
            //    sACH.SoLuong = int.Parse(txtsoluong.Text);
            //    sACH.TacGia = txttacgia.Text;
            //    sACH.NamXuatBan =int.Parse(txtnamxuatban.Text);
            //    sACH.NguoiDich = txtnguoidich.Text;
            //    sACH.MaTheLoai = cmbMatheloai.SelectedValue.ToString();
            //    sACH.MaNhaXuatBan = cmbManhaxuatban.SelectedValue.ToString();
            //    sACH.MaKe = cmbMake.SelectedValue.ToString();
            //    FileInfo fi = new FileInfo(tenFileHinh);
            //    sACH.Hinh = sACH.MaSach + fi.Extension;
            //    File.Copy(tenFileHinh, path + sACH.Hinh);
            //    dc.SACHes.Add(sACH);
            //    dc.SaveChanges();
            //    hienthi();
            //}
            //else if (rdoSua.IsChecked == true)
            //{
            //    string masach = txtMasach.Text;
            //    SACH sACH = dc.SACHes.Find(masach);
            //    sACH.TenSach = txtTensach.Text;
            //    sACH.SoLuong = int.Parse(txtsoluong.Text);
            //    sACH.NamXuatBan = int.Parse(txtnamxuatban.Text);
            //    sACH.NguoiDich = txtnguoidich.Text;
            //    sACH.TacGia = txttacgia.Text;
            //    sACH.MaNhaXuatBan = cmbManhaxuatban.SelectedValue.ToString();
            //    sACH.MaTheLoai = cmbMatheloai.SelectedValue.ToString();
            //    sACH.MaKe = cmbMake.SelectedValue.ToString();
            //    if (tenFileHinh == path + sACH.Hinh)
            //    {
            //        dc.SaveChanges();
            //        dgSach.ItemsSource = dc.SACHes.ToList();
            //        return;
            //    }
            //    else
            //    {
            //        BitmapImage tempBM = imghinh.Source as BitmapImage;
            //        if (tempBM != null)
            //        {
            //            tempBM.StreamSource.Close();
            //            imghinh.Source = null;
            //        }
            //        File.Delete(path + sACH.Hinh);
            //        if (tenFileHinh != "")
            //        {
            //            FileInfo fi = new FileInfo(tenFileHinh);
            //            sACH.Hinh = sACH.MaSach + fi.Extension;
            //            File.Copy(tenFileHinh, path + sACH.Hinh);
            //        }

            //        else
            //        {
            //            sACH.Hinh = "";
            //        }

            //        dc.SaveChanges();
            //        hienthi();
            //    }
            //}
            //else if (rdoXoa.IsChecked == true)
            //{
            //    if (dgSach.SelectedItem == null) return;
            //    else
            //    {
            //        string masach = dgSach.SelectedValue.ToString();
            //        SACH sACH = dc.SACHes.Find(masach);
            //        if (sACH != null)
            //        {

            //            if (sACH.Hinh != "")
            //            {
            //                BitmapImage tempBM = imghinh.Source as BitmapImage;
            //                if (tempBM != null)
            //                {
            //                    tempBM.StreamSource.Close();
            //                    imghinh.Source = null;
            //                }
            //                File.Delete(path + sACH.Hinh);
            //            }
            //            dc.SACHes.Remove(sACH);
            //            dc.SaveChanges();
            //            hienthi();
            //        }
            //    }
            //}
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DirectoryInfo di = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
            di = di.Parent;
            di = di.Parent;
            path = di.FullName + @"\Hinhanh\";
            hienthi();
            //var kq = dc.SACHes.Select(x => new {
            //    MaSach = x.MaSach,
            //    TenSach = x.TenSach,
            //    SoLuong = x.SoLuong,
            //    NamXuatBan = x.NamXuatBan,
            //    TacGia = x.TacGia,
            //    NguoiDich = x.NguoiDich,
            //    TenTheLoai = x.THELOAI.TenTheLoai,
            //    TenNhaXuatBan = x.NHAXUATBAN.TenNhaXuatBan,
            //    TenKe = x.VITRI.TenKe,
            //});
            //dgSach.ItemsSource = kq.ToList();



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

       

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(dgSach.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    SACH p = o as SACH;
                    if (t.Name == "txtId")
                        return p.MaSach.StartsWith(filter);
                    return (p.TenSach.StartsWith(filter));
                };
            }
        }

        
    }
}
