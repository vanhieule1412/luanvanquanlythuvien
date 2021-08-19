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
    /// Interaction logic for ThuThuWindow.xaml
    /// </summary>
    public partial class ThuThuWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        
        public ThuThuWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {            
            dgThuThu.ItemsSource = dc.THUTHUs.ToList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
        }
        private void RdoThem_Click(object sender, RoutedEventArgs e)
        {
            clear();
            //tblmathuthu.Visibility = Visibility.Hidden;
            //txtmathuthu.Visibility = Visibility.Hidden;
            txtmathuthu.IsReadOnly = true;
            txttenthuthu.IsReadOnly = false;
            txtsodienthoai.IsReadOnly = false;
            txtemail.IsReadOnly = false;
            txtcmnd.IsReadOnly = false;
            cmbgioitinh.IsEnabled= true;
            dpnamsinh.IsEnabled =  true;

        }

        private void RdoSua_Click(object sender, RoutedEventArgs e)
        {
            //tblmathuthu.Visibility = Visibility.Visible;
            //txtmathuthu.Visibility = Visibility.Visible;
            txtmathuthu.IsReadOnly = true;
            txttenthuthu.IsReadOnly = false;
            txtsodienthoai.IsReadOnly = false;
            txtemail.IsReadOnly = false;
            txtcmnd.IsReadOnly = false;
            cmbgioitinh.IsEnabled = true;
            dpnamsinh.IsEnabled = true;
        }
        private string PhatSinhTuDong(UngDungQuanLyThuVienEntities dc)
        {
            string s = "";
            var c = dc.THUTHUs.Count();
            if (c == 0)
                s = "TT01";
            else
            {
                s = dc.THUTHUs.ToList().ElementAt(c - 1).MaThuThu;
                string sso = s.Substring(2);
                var so = int.Parse(sso);
                so++;
                s = "TT" + so;
            }
            return s;
        }
        private bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        private bool HasSpecialChars(string yourString)
        {
            return yourString.Any(ch => !Char.IsLetterOrDigit(ch));
        }
        private bool IsInt(string sVal)
        {
            foreach (char c in sVal)
            {
                int iN = (int)c;
                if ((iN > 57) || (iN < 48))
                    return false;
            }
            return true;
        }
        private void clear()
        {
            txttenthuthu.Text = "";
            txtsodienthoai.Text = "";
            txtemail.Text = "";
            txtcmnd.Text = "";
            cmbgioitinh.Text = "";
            dpnamsinh.Text = "";
            txttenthuthu.Focus();

        }
        private void Btnthuchien_Click(object sender, RoutedEventArgs e)
        {
            if (rdoThem.IsChecked == true)
            {
                Regex trimmer = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
                txttenthuthu.Text = trimmer.Replace(txttenthuthu.Text, " ");
                //var isNumeric = int.TryParse(txtsodienthoai.Text, out int n);
                //var isNumericcmnd = int.TryParse(txtcmnd.Text, out int m);
                if (String.IsNullOrWhiteSpace(txttenthuthu.Text) == true)
                {
                    MessageBox.Show("Tên chưa điền");
                    txttenthuthu.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(dpnamsinh.Text) == true)
                {
                    MessageBox.Show("Năm sinh chưa điền");
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtcmnd.Text) == true)
                {
                    MessageBox.Show("CMND chưa điền");
                    txtcmnd.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtemail.Text) == true)
                {
                    MessageBox.Show("Chưa điền địa chỉ email");
                    txtemail.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtsodienthoai.Text) == true)
                {
                    MessageBox.Show("Chưa điền số điện thoại");
                    txtsodienthoai.Focus();
                    txtsodienthoai.Select(txtsodienthoai.Text.Length, 0);
                    return;
                }
                if (txtsodienthoai.Text.Length != 10 || txtsodienthoai.Text.Length < 10 || txtsodienthoai.Text.Length > 10)
                {
                    MessageBox.Show("Số Điện Thoại phải đủ 10 số");
                    txtsodienthoai.Focus();
                    txtsodienthoai.Select(txtsodienthoai.Text.Length, 0);
                    return;
                }
                if (HasSpecialChars(txtcmnd.Text.ToString()) == true)
                {
                    MessageBox.Show("CMND không có khoảng trắng hoặc kí tự đặc biệt");
                    txtcmnd.Focus();
                    txtcmnd.Select(txtcmnd.Text.Length, 0);
                    return;
                }
                if (IsInt(txtcmnd.Text) == false)
                {
                    MessageBox.Show("CMND phải là số");
                    return;
                }
                if (IsInt(txtsodienthoai.Text) == false)
                {
                    MessageBox.Show("Số điện thoại phải là số");
                    return;
                }
                if (txtcmnd.Text.Length != 9 && txtcmnd.Text.Length != 12)
                {
                    MessageBox.Show("CMND không hợp lệ");
                    txtcmnd.Focus();
                    txtcmnd.Select(txtcmnd.Text.Length, 0);
                    return;
                }
                if (HasSpecialChars(txtsodienthoai.Text.ToString()) == true)
                {
                    MessageBox.Show("Số điện thoại không có khoảng trắng hoặc kí tự đặc biệt");
                    txtsodienthoai.Focus();
                    txtsodienthoai.Select(txtsodienthoai.Text.Length, 0);
                    return;
                }
                if (isEmail(txtemail.Text) == false)
                {
                    MessageBox.Show("Đây không phải là email");
                    txtemail.Focus();
                    txtemail.Select(txtemail.Text.Length, 0);
                    return;
                }
                else
                {
                    string s = PhatSinhTuDong(dc);
                    THUTHU tHUTHU = new THUTHU();
                    tHUTHU.MaThuThu = s;
                    tHUTHU.TenThuThu = txttenthuthu.Text.Trim();
                    tHUTHU.NamSinh = dpnamsinh.SelectedDate.Value;
                    tHUTHU.SoDienThoai = txtsodienthoai.Text.Trim();
                    tHUTHU.GioiTinh = cmbgioitinh.SelectionBoxItem.ToString();
                    tHUTHU.Email = txtemail.Text.Trim();
                    tHUTHU.CMND = txtcmnd.Text.Trim();
                    dc.THUTHUs.Add(tHUTHU);
                    dc.SaveChanges();
                    clear();
                    hienthi();
                }
              
            }
            else if (rdoSua.IsChecked == true)
            {
                string mathuthu = txtmathuthu.Text;
                THUTHU tHUTHU = dc.THUTHUs.Find(mathuthu);
                if (mathuthu != null)
                {
                    Regex trimmer = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
                    txttenthuthu.Text = trimmer.Replace(txttenthuthu.Text, " ");
                    //var isNumeric = int.TryParse(txtsodienthoai.Text, out int n);
                    //var isNumericcmnd = int.TryParse(txtcmnd.Text, out int m);
                    if (String.IsNullOrWhiteSpace(txttenthuthu.Text) == true)
                    {
                        MessageBox.Show("Tên chưa điền");
                        txttenthuthu.Focus();
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(txtcmnd.Text) == true)
                    {
                        MessageBox.Show("CMND chưa điền");
                        txtcmnd.Focus();
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(txtemail.Text) == true)
                    {
                        MessageBox.Show("Chưa điền địa chỉ email");
                        txtemail.Focus();
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(txtsodienthoai.Text) == true)
                    {
                        MessageBox.Show("Chưa điền số điện thoại");
                        txtsodienthoai.Focus();
                        txtsodienthoai.Select(txtsodienthoai.Text.Length, 0);
                        return;
                    }
                    if (txtsodienthoai.Text.Length != 10 || txtsodienthoai.Text.Length < 10 || txtsodienthoai.Text.Length > 10)
                    {
                        MessageBox.Show("Số Điện Thoại phải đủ 10 số");
                        txtsodienthoai.Focus();
                        txtsodienthoai.Select(txtsodienthoai.Text.Length, 0);
                        return;
                    }
                    if (HasSpecialChars(txtcmnd.Text.ToString()) == true)
                    {
                        MessageBox.Show("CMND không có khoảng trắng hoặc kí tự đặc biệt");
                        txtcmnd.Focus();
                        txtcmnd.Select(txtcmnd.Text.Length, 0);
                        return;
                    }
                    if (IsInt(txtcmnd.Text) == false)
                    {
                        MessageBox.Show("CMND phải là số");
                        return;
                    }
                    if (IsInt(txtsodienthoai.Text) == false)
                    {
                        MessageBox.Show("Số điện thoại phải là số");
                        return;
                    }
                    if (txtcmnd.Text.Length != 9 && txtcmnd.Text.Length != 12)
                    {
                        MessageBox.Show("CMND không hợp lệ");
                        txtcmnd.Focus();
                        txtcmnd.Select(txtcmnd.Text.Length, 0);
                        return;
                    }
                    if (HasSpecialChars(txtsodienthoai.Text.ToString()) == true)
                    {
                        MessageBox.Show("Số điện thoại không có khoảng trắng hoặc kí tự đặc biệt");
                        txtsodienthoai.Focus();
                        txtsodienthoai.Select(txtsodienthoai.Text.Length, 0);
                        return;
                    }
                    if (isEmail(txtemail.Text) == false)
                    {
                        MessageBox.Show("Đây không phải là email");
                        txtemail.Focus();
                        txtemail.Select(txtemail.Text.Length, 0);
                        return;
                    }
                    else
                    {
                        tHUTHU.TenThuThu = txttenthuthu.Text.Trim();
                        tHUTHU.NamSinh = dpnamsinh.SelectedDate.Value;
                        tHUTHU.SoDienThoai = txtsodienthoai.Text.Trim();
                        tHUTHU.GioiTinh = cmbgioitinh.SelectionBoxItem.ToString();
                        tHUTHU.Email = txtemail.Text.Trim();
                        tHUTHU.CMND = txtcmnd.Text.Trim();
                        dc.SaveChanges();
                    }
                }
                hienthi();
            }
        }

        private void DgThuThu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgThuThu.SelectedItem == null) return;
            THUTHU tHUTHU = dgThuThu.SelectedItem as THUTHU;
            if (tHUTHU != null)
            {
                txtmathuthu.Text = tHUTHU.MaThuThu;
                txttenthuthu.Text = tHUTHU.TenThuThu;
                dpnamsinh.SelectedDate = tHUTHU.NamSinh;
                txtsodienthoai.Text = tHUTHU.SoDienThoai.ToString();
                //if (tHUTHU.GioiTinh == "Nam") cmbgioitinh.SelectedItem = "Nam";
                //else cmbgioitinh.SelectedItem = "Nữ";
                if (tHUTHU.GioiTinh == "Nam")
                {
                    cmbnam.IsSelected = true;
                }
                else if (tHUTHU.GioiTinh == "Nữ")
                {
                    cmbnu.IsSelected = true;
                }

                txtemail.Text = tHUTHU.Email;
                txtcmnd.Text = tHUTHU.CMND.ToString();
            }
            else
            {
                txtmathuthu.Text ="";
                txttenthuthu.Text = "";
                dpnamsinh.SelectedDate = null;
                txtsodienthoai.Text = "";
                cmbgioitinh.SelectedItem = "";
                txtemail.Text = "";
                txtcmnd.Text = "";
                return;
         
            }
        }
        //private void RdoTaotk_Click(object sender, RoutedEventArgs e)
        //{
        //    if (rdoTaotk.IsChecked == true)
        //    {
        //        txttaotaikhoan.Visibility = Visibility.Visible;
        //        txtmathuthu.Clear();
        //        txttenthuthu.Clear();
        //        dpnamsinh.SelectedDate = null;
        //        txtsodienthoai.Clear() ;
        //        cmbgioitinh.SelectedItem.ToString();
        //        txtemail.Clear();
        //        txtcmnd.Clear();
        //    }
        //}

        private void Txttaotaikhoan_Click(object sender, RoutedEventArgs e)
        {
            //GiaoDien.TaiKhoanThuThuWindow ftaikhoan = new TaiKhoanThuThuWindow();
            //ftaikhoan.chucnang = KieuChucNang.Them;
            //ftaikhoan.tAIKHOANTHUTHU = dc.TAIKHOANTHUTHUs.Find(dgThuThu.SelectedValue.ToString());
            //if (ftaikhoan.ShowDialog() == true)
            //{
            //    dc.TAIKHOANTHUTHUs.Add(ftaikhoan.tAIKHOANTHUTHU);
            //    dc.SaveChanges();
            //    hienthi();
            //}
            GiaoDien.TaiKhoanThuThuWindow ftaikhoan = new TaiKhoanThuThuWindow();
            ftaikhoan.chucnang = KieuChucNang.Them;            
            ftaikhoan.THUTHU = dc.THUTHUs.Find(dgThuThu.SelectedValue.ToString());
            string mathuthu = dgThuThu.SelectedValue.ToString();
            var ds = dc.TAIKHOANTHUTHUs.Where(x => x.MaThuThu == mathuthu).ToList();
            if (ds.Count > 0)
            {
                MessageBox.Show("Thủ thư này đã có tài khoản");
                return;
            }          
                if (ftaikhoan.ShowDialog() == true)
                {
                    dc.TAIKHOANTHUTHUs.Add(ftaikhoan.tAIKHOANTHUTHU);
                    dc.SaveChanges();

                }
        }     
    }
}
