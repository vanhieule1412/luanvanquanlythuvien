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
    /// Interaction logic for NhaXuatBanWindow.xaml
    /// </summary>
    public partial class NhaXuatBanWindow : Window
    {
        private Model.UngDungQuanLyThuVienEntities dc = new Model.UngDungQuanLyThuVienEntities();
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
            if (dgNhaXuatBan.SelectedItem == null) return;
            Model.NHAXUATBAN nHAXUATBAN = dgNhaXuatBan.SelectedItem as Model.NHAXUATBAN;
            txtmanhaxuatban.Text = nHAXUATBAN.MaNhaXuatBan;
            txttennhaxuatban.Text = nHAXUATBAN.TenNhaXuatBan;
            txtdiachi.Text = nHAXUATBAN.DiaChi;
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
        }

        private void RdoSua_Click(object sender, RoutedEventArgs e)
        {

            txtmanhaxuatban.IsReadOnly = true;
            txttennhaxuatban.IsReadOnly = false;
            txtdiachi.IsReadOnly = false;
        }

        private void RdoXoa_Click(object sender, RoutedEventArgs e)
        {
            txtmanhaxuatban.IsReadOnly = true;
            txttennhaxuatban.IsReadOnly = true;
            txtdiachi.IsReadOnly = true;
        }

        private void Btnthuchien_Click(object sender, RoutedEventArgs e)
        {
            if (rdoThem.IsChecked == true)
            {
                Model.NHAXUATBAN nHAXUATBAN = new Model.NHAXUATBAN();
                nHAXUATBAN.MaNhaXuatBan = txtmanhaxuatban.Text;
                nHAXUATBAN.TenNhaXuatBan = txttennhaxuatban.Text;
                nHAXUATBAN.DiaChi = txtdiachi.Text;
                dc.NHAXUATBANs.Add(nHAXUATBAN);
                dc.SaveChanges();
                hienthi();
            }
            else if (rdoSua.IsChecked == true)
            {
                string manhanxuatban = txtmanhaxuatban.Text;
                Model.NHAXUATBAN nHAXUATBAN = dc.NHAXUATBANs.Find(manhanxuatban);
                if (manhanxuatban != null)
                {
                    nHAXUATBAN.TenNhaXuatBan = txttennhaxuatban.Text;
                    nHAXUATBAN.DiaChi = txtdiachi.Text;
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
                    Model.NHAXUATBAN nHAXUATBAN = dc.NHAXUATBANs.Find(manhanxuatban);
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
