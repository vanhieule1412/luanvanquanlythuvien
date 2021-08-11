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

        }
        private void Btnthuchien_Click(object sender, RoutedEventArgs e)
        {
            if (rdoThem.IsChecked == true)
            {              
                var regexItem = new Regex("^[a-zA-Z ]*$");
                var kitukokhoangtrang = new Regex("^[a-zA-Z]*$");
                NHAXUATBAN hAXUATBAN = dc.NHAXUATBANs.Find(txtmanhaxuatban.Text);
                if (hAXUATBAN != null)
                {
                    MessageBox.Show("Mã bị trùng");
                    return;
                }
                if (regexItem.IsMatch(txttennhaxuatban.Text))
                {
                    MessageBox.Show("Tên không được có kí tự đặc biệt hoặc số");
                    return;
                }
                if (kitukokhoangtrang.IsMatch(txtmanhaxuatban.Text))
                {
                    MessageBox.Show("Mã không được có kí tự đặc biệt hoặc số");
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtmanhaxuatban.Text) == true)
                {
                    MessageBox.Show("Mã không được khoảng trắng");
                }
                //if (txtsodienthoai.Text)
                //{
                //    MessageBox.Show("Số điện thoại không được có kí tự đặc biệt");
                //    return;
                //}
                //if()
                else
                {
                    NHAXUATBAN nHAXUATBAN = new NHAXUATBAN();
                    nHAXUATBAN.MaNhaXuatBan = txtmanhaxuatban.Text.Replace(" ",String.Empty).Trim().ToUpper();
                    nHAXUATBAN.TenNhaXuatBan = txttennhaxuatban.Text.Trim();
                    nHAXUATBAN.DiaChi = txtdiachi.Text.Trim();
                    nHAXUATBAN.Email = txtemail.Text.Trim();
                    nHAXUATBAN.DiaChiWebsite = txtdiachiweb.Text.Trim();
                    nHAXUATBAN.SoDienThoai = int.Parse(txtsodienthoai.Text.ToString().Trim());
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
                    nHAXUATBAN.TenNhaXuatBan = txttennhaxuatban.Text;
                    nHAXUATBAN.DiaChi = txtdiachi.Text;
                    nHAXUATBAN.Email = txtemail.Text;
                    nHAXUATBAN.DiaChiWebsite = txtdiachiweb.Text;
                    nHAXUATBAN.SoDienThoai = int.Parse(txtsodienthoai.Text);
                    dc.SaveChanges();
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
