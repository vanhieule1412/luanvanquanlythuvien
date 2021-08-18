using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
            dgSach.ItemsSource = dc.SACHes.ToList();
            cmbMatheloai.ItemsSource = dc.THELOAIs.ToList();
            cmbManhaxuatban.ItemsSource = dc.NHAXUATBANs.ToList();
            cmbMake.ItemsSource = dc.KEs.ToList();


        }
        private void DgSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgSach.SelectedItem == null) return;
            SACH s = dgSach.SelectedItem as SACH;
            if (s != null)
            {
                txtMasach.Text = s.MaSach;
                txtTensach.Text = s.TenSach;
                txtsoluong.Text = s.SoLuong.ToString();
                txttacgia.Text = s.TacGia;
                txtnamxuatban.Text = s.NamXuatBan.ToString();
                txtnguoidich.Text = s.NguoiDich;
                cmbManhaxuatban.SelectedValue = s.MaNhaXuatBan;
                cmbMatheloai.SelectedValue = s.MaTheLoai;
                cmbMake.SelectedValue = s.MaKe;
                txtnoidungtt.Text = s.NoiDungTomTat;
                txtgia.Text = s.Gia.ToString();
                BitmapImage tempBM = imghinh.Source as BitmapImage;
                if (tempBM != null)
                {
                    tempBM.StreamSource.Close();
                    imghinh.Source = null;
                }
                if (s.HinhAnh != "")
                {
                    string tenfile = path + s.HinhAnh;
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
                
            }
            else
            {
                return;
            }
        }
        private void clear()
        {
            txtMasach.Text = "";
            txtTensach.Text = "";
            txtnamxuatban.Text = "";
            txtnguoidich.Text = "";
            txtnoidungtt.Text = "";
            txtsoluong.Text = "";
            txttacgia.Text = "";
            txtgia.Text = "";
            cmbMake.Text = "";
            cmbManhaxuatban.Text = "";
            cmbMatheloai.Text = "";
            txtMasach.Focus();

        }
        private bool HasSpecialChars(string yourString)
        {
            return yourString.Any(ch => !Char.IsLetterOrDigit(ch));
        }
        private void Btnthuchien_Click(object sender, RoutedEventArgs e)
        {
            if (rdoThem.IsChecked == true)
            {
                Regex trimmer = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
                txtTensach.Text = trimmer.Replace(txtTensach.Text, " ");
                txtnguoidich.Text = trimmer.Replace(txtnguoidich.Text, " ");
                txtnoidungtt.Text = trimmer.Replace(txtnoidungtt.Text, " ");
                var isNumericgia = int.TryParse(txtgia.Text, out int n);
                var isNumericnxb = int.TryParse(txtnamxuatban.Text, out int m);
                var isNumericsoluong = int.TryParse(txtsoluong.Text, out int z);
                SACH tam = dc.SACHes.Find(txtMasach.Text);
                if (tam != null)
                {
                    MessageBox.Show("Trùng Mã");
                    txtMasach.Focus();
                    txtMasach.Select(txtMasach.Text.Length, 0);
                    return;
                }
                else if (isNumericgia == false)
                {
                    MessageBox.Show("Giá không để chữ");
                    txtgia.Focus();
                    txtgia.Select(txtgia.Text.Length, 0);
                    return;
                }
                else if (isNumericnxb == false)
                {
                    MessageBox.Show("Năm xuất bản không để chữ");
                    txtnamxuatban.Focus();
                    txtnamxuatban.Select(txtnamxuatban.Text.Length, 0);
                    return;
                }
                else if (isNumericsoluong == false)
                {
                    MessageBox.Show("Số lượng không để chữ");
                    txtsoluong.Focus();
                    txtsoluong.Select(txtsoluong.Text.Length, 0);
                    return;
                }
                else if (HasSpecialChars(txtgia.Text) == true)
                {
                    MessageBox.Show("Giá không được khoảng trắng hoặc kí tự đặc biệt");
                    txtgia.Focus();
                    txtgia.Select(txtgia.Text.Length, 0);
                    return;
                }
                else if (HasSpecialChars(txtsoluong.Text) == true)
                {
                    MessageBox.Show("Số lượng không được khoảng trắng hoặc kí tự đặc biệt");
                    txtsoluong.Focus();
                    txtsoluong.Select(txtsoluong.Text.Length, 0);
                    return;
                }
                else if (HasSpecialChars(txtnamxuatban.Text) == true)
                {
                    MessageBox.Show("Năm xuất bản không được khoảng trắng hoặc kí tự đặc biệt");
                    txtnamxuatban.Focus();
                    txtnamxuatban.Select(txtnamxuatban.Text.Length, 0);
                    return;
                }
                else if (HasSpecialChars(txtMasach.Text) == true)
                {
                    MessageBox.Show("Mã không được khoảng trắng hoặc kí tự đặc biệt");
                    txtMasach.Focus();
                    txtMasach.Select(txtMasach.Text.Length, 0);
                    return;
                }
                else if (String.IsNullOrWhiteSpace(txtMasach.Text) == true)
                {
                    MessageBox.Show("Chưa nhập mã");
                    txtMasach.Focus();
                    return;
                }
                else if (String.IsNullOrWhiteSpace(txtTensach.Text) == true)
                {
                    MessageBox.Show("Chưa nhập tên");
                    txtTensach.Focus();
                    return;
                }
                else if (String.IsNullOrWhiteSpace(txttacgia.Text) == true)
                {
                    MessageBox.Show("Chưa nhập tác giả");
                    txttacgia.Focus();
                    return;
                }
                else if (String.IsNullOrWhiteSpace(txtnamxuatban.Text) == true)
                {
                    MessageBox.Show("Chưa nhập năm xuất bản");
                    txtnamxuatban.Focus();
                    return;
                }
                else if (String.IsNullOrWhiteSpace(txtsoluong.Text) == true)
                {
                    MessageBox.Show("Chưa nhập số lượng");
                    txtsoluong.Focus();
                    return;
                }
                else if (String.IsNullOrWhiteSpace(txtgia.Text) == true)
                {
                    MessageBox.Show("Chưa nhập giá");
                    txtgia.Focus();
                    return;
                }
                else if (String.IsNullOrWhiteSpace(cmbMake.Text) == true)
                {
                    MessageBox.Show("Chưa nhập kệ");
                    return;
                }
                else if (String.IsNullOrWhiteSpace(cmbManhaxuatban.Text) == true)
                {
                    MessageBox.Show("Chưa nhập nhà xuất bản");
                    return;
                }
                else if (String.IsNullOrWhiteSpace(cmbMatheloai.Text) == true)
                {
                    MessageBox.Show("Chưa nhập thể loại");
                    return;
                }
                else if (tenFileHinh == "")
                {
                    //hv.hinh = "";
                    MessageBox.Show("Chưa chọn hình");
                    return;
                }
                else
                {
                    SACH sACH = new SACH();
                    sACH.MaSach = txtMasach.Text.Trim().ToUpper();
                    sACH.TenSach = txtTensach.Text.Trim();
                    sACH.SoLuong = int.Parse(txtsoluong.Text.Trim());
                    sACH.TacGia = txttacgia.Text.Trim();
                    sACH.NamXuatBan = int.Parse(txtnamxuatban.Text.Trim());
                    sACH.NguoiDich = txtnguoidich.Text.Trim();
                    sACH.MaTheLoai = cmbMatheloai.SelectedValue.ToString();
                    sACH.MaNhaXuatBan = cmbManhaxuatban.SelectedValue.ToString();
                    sACH.MaKe = cmbMake.SelectedValue.ToString();
                    sACH.NoiDungTomTat = txtnoidungtt.Text.Trim();
                    sACH.Gia = int.Parse(txtgia.Text.Trim().ToString());
                    FileInfo fi = new FileInfo(tenFileHinh);
                    sACH.HinhAnh = sACH.MaSach + fi.Extension;
                    File.Copy(tenFileHinh, path + sACH.HinhAnh);
                    dc.SACHes.Add(sACH);
                    dc.SaveChanges();
                    clear();
                    hienthi();
                }
                
            }
            else if (rdoSua.IsChecked == true)
            {
                string masach = txtMasach.Text;
                SACH sACH = dc.SACHes.Find(masach);
                  Regex trimmer = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
                txtTensach.Text = trimmer.Replace(txtTensach.Text, " ");
                txtnguoidich.Text = trimmer.Replace(txtnguoidich.Text, " ");
                txtnoidungtt.Text = trimmer.Replace(txtnoidungtt.Text, " ");
                var isNumericgia = int.TryParse(txtgia.Text, out int n);
                var isNumericnxb = int.TryParse(txtnamxuatban.Text, out int m);
                var isNumericsoluong = int.TryParse(txtsoluong.Text, out int z);
                if (isNumericgia == false)
                {
                    MessageBox.Show("Giá không để chữ");
                    txtgia.Focus();
                    txtgia.Select(txtgia.Text.Length, 0);
                    return;
                }
                else if (isNumericnxb == false)
                {
                    MessageBox.Show("Năm xuất bản không để chữ");
                    txtnamxuatban.Focus();
                    txtnamxuatban.Select(txtnamxuatban.Text.Length, 0);
                    return;
                }
                else if (isNumericsoluong == false)
                {
                    MessageBox.Show("Số lượng không để chữ");
                    txtsoluong.Focus();
                    txtsoluong.Select(txtsoluong.Text.Length, 0);
                    return;
                }
                else if (HasSpecialChars(txtgia.Text) == true)
                {
                    MessageBox.Show("Giá không được khoảng trắng hoặc kí tự đặc biệt");
                    txtgia.Focus();
                    txtgia.Select(txtgia.Text.Length, 0);
                    return;
                }
                else if (HasSpecialChars(txtsoluong.Text) == true)
                {
                    MessageBox.Show("Số lượng không được khoảng trắng hoặc kí tự đặc biệt");
                    txtsoluong.Focus();
                    txtsoluong.Select(txtsoluong.Text.Length, 0);
                    return;
                }
                else if (HasSpecialChars(txtnamxuatban.Text) == true)
                {
                    MessageBox.Show("Năm xuất bản không được khoảng trắng hoặc kí tự đặc biệt");
                    txtnamxuatban.Focus();
                    txtnamxuatban.Select(txtnamxuatban.Text.Length, 0);
                    return;
                }
                else if (HasSpecialChars(txtMasach.Text) == true)
                {
                    MessageBox.Show("Mã không được khoảng trắng hoặc kí tự đặc biệt");
                    txtMasach.Focus();
                    txtMasach.Select(txtMasach.Text.Length, 0);
                    return;
                }
                else if (String.IsNullOrWhiteSpace(txtMasach.Text) == true)
                {
                    MessageBox.Show("Chưa nhập mã");
                    txtMasach.Focus();
                    return;
                }
                else if (String.IsNullOrWhiteSpace(txtTensach.Text) == true)
                {
                    MessageBox.Show("Chưa nhập tên");
                    txtTensach.Focus();
                    return;
                }
                else if (String.IsNullOrWhiteSpace(txttacgia.Text) == true)
                {
                    MessageBox.Show("Chưa nhập tác giả");
                    txttacgia.Focus();
                    return;
                }
                else if (String.IsNullOrWhiteSpace(txtnamxuatban.Text) == true)
                {
                    MessageBox.Show("Chưa nhập năm xuất bản");
                    txtnamxuatban.Focus();
                    return;
                }
                else if (String.IsNullOrWhiteSpace(txtsoluong.Text) == true)
                {
                    MessageBox.Show("Chưa nhập số lượng");
                    txtsoluong.Focus();
                    return;
                }
                else if (String.IsNullOrWhiteSpace(txtgia.Text) == true)
                {
                    MessageBox.Show("Chưa nhập giá");
                    txtgia.Focus();
                    return;
                }
                else if (String.IsNullOrWhiteSpace(cmbMake.Text) == true)
                {
                    MessageBox.Show("Chưa nhập kệ");
                    return;
                }
                else if (String.IsNullOrWhiteSpace(cmbManhaxuatban.Text) == true)
                {
                    MessageBox.Show("Chưa nhập nhà xuất bản");
                    return;
                }
                else if (String.IsNullOrWhiteSpace(cmbMatheloai.Text) == true)
                {
                    MessageBox.Show("Chưa nhập thể loại");
                    return;
                }
                else if (tenFileHinh == "")
                {
                    //hv.hinh = "";
                    MessageBox.Show("Chưa chọn hình");
                    return;
                }
                else
                {
                    sACH.TenSach = txtTensach.Text.Trim();
                    sACH.SoLuong = int.Parse(txtsoluong.Text.Trim());
                    sACH.NamXuatBan = int.Parse(txtnamxuatban.Text.Trim());
                    sACH.NguoiDich = txtnguoidich.Text.Trim();
                    sACH.TacGia = txttacgia.Text.Trim();
                    sACH.MaNhaXuatBan = cmbManhaxuatban.SelectedValue.ToString();
                    sACH.MaTheLoai = cmbMatheloai.SelectedValue.ToString();
                    sACH.MaKe = cmbMake.SelectedValue.ToString();
                    sACH.NoiDungTomTat = txtnoidungtt.Text.Trim();
                    sACH.Gia = int.Parse(txtgia.Text.Trim());
                    if (tenFileHinh == path + sACH.HinhAnh)
                    {
                        dc.SaveChanges();
                        hienthi();
                        return;
                    }
                    else
                    {
                        BitmapImage tempBM = imghinh.Source as BitmapImage;
                        if (tempBM != null)
                        {
                            tempBM.StreamSource.Close();
                            imghinh.Source = null;
                        }
                        File.Delete(path + sACH.HinhAnh);
                        if (tenFileHinh != "")
                        {
                            FileInfo fi = new FileInfo(tenFileHinh);
                            sACH.HinhAnh = sACH.MaSach + fi.Extension;
                            File.Copy(tenFileHinh, path + sACH.HinhAnh);
                        }

                        else
                        {
                            sACH.HinhAnh = "";
                        }

                        dc.SaveChanges();
                        hienthi();
                    }
                }
                
            }
            else if (rdoXoa.IsChecked == true)
            {
                if (dgSach.SelectedItem == null) return;
                else
                {
                    string masach = dgSach.SelectedValue.ToString();
                    SACH sACH = dc.SACHes.Find(masach);
                    var ds = dc.CHITIETPHIEUMUONs.Where(x => x.MaSach == masach).ToList();
                    if (ds.Count > 0)
                    {
                        MessageBox.Show("Không được xóa quyển sách này");
                        return;
                    }
                    if (sACH != null)
                    {
                        if (sACH.HinhAnh != "")
                        {
                            BitmapImage tempBM = imghinh.Source as BitmapImage;
                            if (tempBM != null)
                            {
                                tempBM.StreamSource.Close();
                                imghinh.Source = null;
                            }
                            File.Delete(path + sACH.HinhAnh);
                        }
                        dc.SACHes.Remove(sACH);
                        dc.SaveChanges();
                        hienthi();
                    }
                }
            }
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

        private void RdoThem_Click(object sender, RoutedEventArgs e)
        {
            clear();
            txtMasach.IsReadOnly = false;
            txtTensach.IsReadOnly = false;
            txtnamxuatban.IsReadOnly = false;
            txtnguoidich.IsReadOnly = false;
            txtnoidungtt.IsReadOnly = false;
            txttacgia.IsReadOnly = false;
            txtsoluong.IsReadOnly = false;
            cmbMake.IsEnabled = true;
            cmbManhaxuatban.IsEnabled = true;
            cmbMatheloai.IsEnabled = true;
            txtgia.IsReadOnly = false;
        }

        private void RdoSua_Click(object sender, RoutedEventArgs e)
        {
            txtMasach.IsReadOnly = true;
            txtTensach.IsReadOnly = false;
            txtnamxuatban.IsReadOnly = false;
            txtnguoidich.IsReadOnly = false;
            txtnoidungtt.IsReadOnly = false;
            txttacgia.IsReadOnly = false;
            txtsoluong.IsReadOnly = false;
            cmbMake.IsEnabled = true;
            cmbManhaxuatban.IsEnabled = true;
            cmbMatheloai.IsEnabled = true;
            txtgia.IsReadOnly = false;

        }

        private void RdoXoa_Click(object sender, RoutedEventArgs e)
        {
            txtMasach.IsReadOnly = true;
            txtTensach.IsReadOnly = true;
            txtnamxuatban.IsReadOnly = true;
            txtnguoidich.IsReadOnly = true;
            txtnoidungtt.IsReadOnly = true;
            txttacgia.IsReadOnly = true;
            txtsoluong.IsReadOnly = true;
            cmbMake.IsEnabled=false;
            cmbManhaxuatban.IsEnabled = false;
            cmbMatheloai.IsEnabled = false;
            txtgia.IsReadOnly = true;
        }



        //private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    TextBox t = (TextBox)sender;
        //    string filter = t.Text;
        //    ICollectionView cv = CollectionViewSource.GetDefaultView(dgSach.ItemsSource);
        //    if (filter == "")
        //        cv.Filter = null;
        //    else
        //    {
        //        cv.Filter = o =>
        //        {
        //            SACH p = o as SACH;
        //            if (t.Name == "txtId")
        //                return p.MaSach.StartsWith(filter);
        //            return (p.TenSach.StartsWith(filter));
        //        };
        //    }
        //}


    }
}
