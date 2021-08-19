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
        private string PhatSinhTuDong(UngDungQuanLyThuVienEntities dc)
        {
            string s = "";
            var c = dc.DOCGIAs.Count();
            if (c == 0)
                s = "DG01";
            else
            {
                s = dc.DOCGIAs.ToList().ElementAt(c - 1).MaDocGia;
                string sso = s.Substring(2);
                var so = int.Parse(sso);
                so++;
                s = "DG" + so;
            }
            return s;
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
        private void clear()
        {
            txttendocgia.Text = "";
            txtsodienthoai.Text = "";
            txtemail.Text = "";
            txtcmnd.Text = "";
            cmbgioitinh.Text = "";
            dtpnamsinh.Text = "";
            txtdiachi.Text = "";
            cmbmataikhoanthuthu.Text = "";
            txttendocgia.Focus();

        }
        private void Btnthuchien_Click(object sender, RoutedEventArgs e)
        {
            if (rdoThem.IsChecked == true)
            {
                //DOCGIA oCGIA = dc.DOCGIAs.Find(txtmadocgia.Text);
                Regex trimmer = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
                txttendocgia.Text = trimmer.Replace(txttendocgia.Text, " ");
                txtdiachi.Text = trimmer.Replace(txttendocgia.Text, " ");
                //var isNumeric = int.TryParse(txtsodienthoai.Text, out int n);
                //var isNumericcmnd = int.TryParse(txtcmnd.Text, out int m);
                if (String.IsNullOrWhiteSpace(txttendocgia.Text) == true)
                {
                    MessageBox.Show("Tên chưa điền");
                    txttendocgia.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(cmbmataikhoanthuthu.Text) == true)
                {
                    MessageBox.Show("Mã tài khoản chưa có điền");
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtcmnd.Text) == true)
                {
                    MessageBox.Show("CMND chưa điền");
                    txtcmnd.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtdiachi.Text) == true)
                {
                    MessageBox.Show("Địa chỉ chưa điền");
                    txtdiachi.Focus();
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
                if (String.IsNullOrWhiteSpace(dtpnamsinh.Text) == true)
                {
                    MessageBox.Show("Năm sinh chưa điền");
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
                    DOCGIA dOCGIA = new DOCGIA();
                    dOCGIA.MaDocGia = s;
                    dOCGIA.TenDocGia = txttendocgia.Text.Trim();
                    dOCGIA.NamSinh = dtpnamsinh.SelectedDate.Value;
                    dOCGIA.SoDienThoai = txtsodienthoai.Text.Trim();
                    dOCGIA.Email = txtemail.Text.Trim();
                    dOCGIA.GioiTinh = cmbgioitinh.SelectionBoxItem.ToString();
                    dOCGIA.DiaChi = txtdiachi.Text.Trim();
                    dOCGIA.CMND = txtcmnd.Text.Trim();
                    dOCGIA.MaTaiKhoai = int.Parse(cmbmataikhoanthuthu.SelectedValue.ToString());
                    dc.DOCGIAs.Add(dOCGIA);
                    dc.SaveChanges();
                    clear();
                    hienthi();
                }
            }
            else if (rdoSua.IsChecked == true)
            {
                string madocgia = txtmadocgia.Text;
                DOCGIA dOCGIA = dc.DOCGIAs.Find(madocgia);
                if (madocgia != null)
                {
                    Regex trimmer = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
                    txttendocgia.Text = trimmer.Replace(txttendocgia.Text, " ");
                    txtdiachi.Text = trimmer.Replace(txtdiachi.Text, " ");
                    //var isNumeric = int.TryParse(txtsodienthoai.Text, out int n);
                    //var isNumericcmnd = int.TryParse(txtcmnd.Text, out int m);
                    if (String.IsNullOrWhiteSpace(txttendocgia.Text) == true)
                    {
                        MessageBox.Show("Tên chưa điền");
                        txttendocgia.Focus();
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(cmbmataikhoanthuthu.Text) == true)
                    {
                        MessageBox.Show("Mã tài khoản chưa có điền");
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(txtcmnd.Text) == true)
                    {
                        MessageBox.Show("CMND chưa điền");
                        txtcmnd.Focus();
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(txtdiachi.Text) == true)
                    {
                        MessageBox.Show("Địa chỉ chưa điền");
                        txtdiachi.Focus();
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
                    if (String.IsNullOrWhiteSpace(dtpnamsinh.Text) == true)
                    {
                        MessageBox.Show("Năm sinh chưa điền");
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
                        dOCGIA.TenDocGia = txttendocgia.Text;
                        dOCGIA.NamSinh = dtpnamsinh.SelectedDate.Value;
                        dOCGIA.SoDienThoai = txtsodienthoai.Text;
                        dOCGIA.Email = txtemail.Text;
                        dOCGIA.GioiTinh = cmbgioitinh.SelectionBoxItem.ToString();
                        dOCGIA.DiaChi = txtdiachi.Text;
                        dOCGIA.CMND = txtcmnd.Text;
                        dOCGIA.MaTaiKhoai = int.Parse(cmbmataikhoanthuthu.SelectedValue.ToString());
                        dc.SaveChanges();
                    }
                }
                hienthi();
            }
        }

        private void RdoThem_Click(object sender, RoutedEventArgs e)
        {
            clear();
            txtmadocgia.IsReadOnly = true;
            txttendocgia.IsReadOnly = false;
            txtsodienthoai.IsReadOnly = false;
            txtemail.IsReadOnly = false;
            txtcmnd.IsReadOnly = false;
            cmbgioitinh.IsEnabled = true;
            txtdiachi.IsReadOnly = false;
            cmbmataikhoanthuthu.IsEnabled = true;
            txttendocgia.Focus();
        }

        private void RdoSua_Click(object sender, RoutedEventArgs e)
        {
            txtmadocgia.IsReadOnly = true;
            txttendocgia.IsReadOnly = false;
            txtsodienthoai.IsReadOnly = false;
            txtemail.IsReadOnly = false;
            txtcmnd.IsReadOnly = false;
            cmbgioitinh.IsEnabled = true;
            txtdiachi.IsReadOnly = false;
            cmbmataikhoanthuthu.IsEnabled = true;
        }

        private void RdoXoa_Click(object sender, RoutedEventArgs e)
        {
            txtmadocgia.IsReadOnly = true;
            txttendocgia.IsReadOnly = true;
            txtsodienthoai.IsReadOnly = true;
            txtemail.IsReadOnly = true;
            txtcmnd.IsReadOnly = true;
            cmbgioitinh.IsEnabled = false;
            txtdiachi.IsReadOnly = true;
            cmbmataikhoanthuthu.IsEnabled = false;

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
