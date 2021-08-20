using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Interaction logic for NhaXuatBanWindow.xaml
    /// </summary>
    public partial class NhaXuatBanWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public NhaXuatBanWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            dgNhaXuatBan.ItemsSource = dc.NHAXUATBANs.ToList();
        }
        private void DgNhaXuatBan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (dgNhaXuatBan.SelectedItem == null) return;
            NHAXUATBAN nHAXUATBAN = dgNhaXuatBan.SelectedItem as NHAXUATBAN;
            if (nHAXUATBAN != null)
            {
                txtmanhaxuatban.Text = nHAXUATBAN.MaNhaXuatBan;
                txttennhaxuatban.Text = nHAXUATBAN.TenNhaXuatBan;
                txtdiachi.Text = nHAXUATBAN.DiaChi;
                txtemail.Text = nHAXUATBAN.Email;
                txtdiachiweb.Text = nHAXUATBAN.DiaChiWebsite;
                txtsodienthoai.Text = nHAXUATBAN.SoDienThoai.ToString();
            }
           
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
        }

        private void RdoThem_Click(object sender, RoutedEventArgs e)
        {
            clear();
            txtmanhaxuatban.IsReadOnly = false;
            txttennhaxuatban.IsReadOnly = false;
            txtdiachi.IsReadOnly = false;
            txtemail.IsReadOnly = false;
            txtsodienthoai.IsReadOnly = false;
            txtdiachiweb.IsReadOnly = false;
        }

        private void RdoSua_Click(object sender, RoutedEventArgs e)
        {
            
            txtmanhaxuatban.IsReadOnly = true;
            txttennhaxuatban.IsReadOnly = false;
            txtdiachi.IsReadOnly = false;
            txtemail.IsReadOnly = false;
            txtsodienthoai.IsReadOnly = false;
            txtdiachiweb.IsReadOnly = false;
        }

        private void RdoXoa_Click(object sender, RoutedEventArgs e)
        {
            txtmanhaxuatban.IsReadOnly = true;
            txttennhaxuatban.IsReadOnly = true;
            txtdiachi.IsReadOnly = true;
            txtemail.IsReadOnly = true;
            txtsodienthoai.IsReadOnly = true;
            txtdiachiweb.IsReadOnly = true;
        }
        private void clear()
        {
            txtmanhaxuatban.Text = "";
            txttennhaxuatban.Text = "";
            txtdiachi.Text = "";
            txtemail.Text = "";
            txtsodienthoai.Text = "";
            txtdiachiweb.Text = "";
            txtmanhaxuatban.Focus();

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
        private bool RemoteFileExists(string url)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
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
        private void Btnthuchien_Click(object sender, RoutedEventArgs e)
            {
            if (rdoThem.IsChecked == true)
            {               
                NHAXUATBAN hAXUATBAN = dc.NHAXUATBANs.Find(txtmanhaxuatban.Text);
                Regex trimmer = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
                txttennhaxuatban.Text = trimmer.Replace(txttennhaxuatban.Text, " ");
                txtdiachi.Text = trimmer.Replace(txtdiachi.Text, " ");
                if (hAXUATBAN != null)
                {
                    MessageBox.Show("Mã bị trùng");
                    txtmanhaxuatban.Focus();
                    txtmanhaxuatban.Select(txtmanhaxuatban.Text.Length, 0);                    
                    return;
                }
                if (RemoteFileExists(txtdiachiweb.Text) == false)
                {
                    MessageBox.Show("Website này không tồn tại");
                    txtdiachiweb.Focus();
                    txtdiachiweb.Select(txtdiachiweb.Text.Length, 0);
                    return;
                }
                if (HasSpecialChars(txtmanhaxuatban.Text) == true)
                {
                    MessageBox.Show("Mã không được có kí tự đặc biệt hoặc khoảng trắng");
                    txtmanhaxuatban.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtmanhaxuatban.Text) == true)
                {
                    MessageBox.Show("Mã chưa điền");
                    txtmanhaxuatban.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(txttennhaxuatban.Text) == true)
                {
                    MessageBox.Show("Tên chưa điền");
                    txttennhaxuatban.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtdiachi.Text) == true)
                {
                    MessageBox.Show("Địa chỉ chưa điền");
                    txtdiachi.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtdiachiweb.Text) == true)
                {
                    MessageBox.Show("Chưa điền địa chỉ website");
                    txtdiachiweb.Focus();
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
                if (IsInt(txtsodienthoai.Text) == false)
                {
                    MessageBox.Show("Số điện thoại phải là số");
                    return;
                }
                if (HasSpecialChars(txtsodienthoai.Text.ToString())==true)
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
                    NHAXUATBAN nHAXUATBAN = new NHAXUATBAN();
                    nHAXUATBAN.MaNhaXuatBan = txtmanhaxuatban.Text.Replace(" ", String.Empty).Trim().ToUpper();
                    nHAXUATBAN.TenNhaXuatBan = txttennhaxuatban.Text.Trim();
                    nHAXUATBAN.DiaChi = txtdiachi.Text.Trim();
                    nHAXUATBAN.Email = txtemail.Text.Replace(" ", String.Empty).Trim();
                    nHAXUATBAN.DiaChiWebsite = txtdiachiweb.Text.Trim();
                    //nHAXUATBAN.SoDienThoai = int.Parse(txtsodienthoai.Text.Replace(" ",String.Empty).ToString().Trim());                    
                    nHAXUATBAN.SoDienThoai = txtsodienthoai.Text;
                    dc.NHAXUATBANs.Add(nHAXUATBAN);
                    dc.SaveChanges();
                    clear();
                    hienthi();
                }
             
            }
            else if (rdoSua.IsChecked == true)
            {
                string manhanxuatban = txtmanhaxuatban.Text;
                NHAXUATBAN nHAXUATBAN = dc.NHAXUATBANs.Find(manhanxuatban);
                if (manhanxuatban != null)
                {
                    Regex trimmer = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
                    txttennhaxuatban.Text = trimmer.Replace(txttennhaxuatban.Text, " ");
                    txtdiachi.Text = trimmer.Replace(txtdiachi.Text, " ");
                    var isNumeric = int.TryParse(txtsodienthoai.Text, out int n);
                    if (RemoteFileExists(txtdiachiweb.Text) == false)
                    {
                        MessageBox.Show("Website này không tồn tại");
                        txtdiachiweb.Focus();
                        txtdiachiweb.Select(txtdiachiweb.Text.Length, 0);
                        return;
                    }
                    if (HasSpecialChars(txtmanhaxuatban.Text) == true)
                    {
                        MessageBox.Show("Mã không được có kí tự đặc biệt");
                        txtmanhaxuatban.Focus();
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(txtmanhaxuatban.Text) == true)
                    {
                        MessageBox.Show("Mã chưa điền");
                        txtmanhaxuatban.Focus();
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(txttennhaxuatban.Text) == true)
                    {
                        MessageBox.Show("Tên chưa điền");
                        txttennhaxuatban.Focus();
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(txtdiachi.Text) == true)
                    {
                        MessageBox.Show("Địa chỉ chưa điền");
                        txtdiachi.Focus();
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(txtdiachiweb.Text) == true)
                    {
                        MessageBox.Show("Chưa điền địa chỉ website");
                        txtdiachiweb.Focus();
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
                    if (isNumeric == false)
                    {
                        MessageBox.Show("Số điện thoại phải là số");
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
                        nHAXUATBAN.TenNhaXuatBan = txttennhaxuatban.Text.Trim();
                        nHAXUATBAN.DiaChi = txtdiachi.Text.Trim();
                        nHAXUATBAN.Email = txtemail.Text.Trim();
                        nHAXUATBAN.DiaChiWebsite = txtdiachiweb.Text.Trim();
                        nHAXUATBAN.SoDienThoai = txtsodienthoai.Text.Trim();
                        dc.SaveChanges();
                    }
                }
                hienthi();
            }
            else if (rdoXoa.IsChecked == true)
            {
                if (dgNhaXuatBan.SelectedItem == null) return;
                else
                {
                    string manhanxuatban = dgNhaXuatBan.SelectedValue.ToString();
                    NHAXUATBAN nHAXUATBAN = dc.NHAXUATBANs.Find(manhanxuatban);
                    var ds = dc.SACHes.Where(x => x.MaNhaXuatBan == manhanxuatban).ToList();
                    if (ds.Count > 0)
                    {
                        MessageBox.Show("Không thể nhà xuất bản này");
                        return;
                    }
                    if (nHAXUATBAN != null)
                    {
                        dc.NHAXUATBANs.Remove(nHAXUATBAN);
                        dc.SaveChanges();
                        hienthi();
                    }
                }
            }
        }
    }
}
