﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for TaiKhoanDocGiaWindow.xaml
    /// </summary>
    
    public partial class TaiKhoanDocGiaWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public KieuChucNang chucnang;
        public TAIKHOANDOCGIA tAIKHOANDOCGIA;
        public DOCGIA DOCGIA;
        public TaiKhoanDocGiaWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (chucnang == KieuChucNang.Them)
            {
                txtmataikhoanthuthu.Text = DOCGIA.MaTaiKhoai.ToString();
                txtmadocgia.Text = DOCGIA.MaDocGia;
            }
        }
        public string Encrypt(string decrypted)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(decrypted);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider tripDES = new TripleDESCryptoServiceProvider();
            tripDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(decrypted));
            tripDES.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripDES.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
            return Convert.ToBase64String(result);
        }
        private void Txttaotaikhoan_Click(object sender, RoutedEventArgs e)
        {
            tAIKHOANDOCGIA = new TAIKHOANDOCGIA();
            tAIKHOANDOCGIA.TenTaiKhoan = txttentaikhoandocgia.Text;
            tAIKHOANDOCGIA.MatKhau =Encrypt(txtmatkhau.Text);
            tAIKHOANDOCGIA.TrangThai = cmbtrangthai.SelectionBoxItem.ToString();
            tAIKHOANDOCGIA.MaTaiKhoai =int.Parse( txtmataikhoanthuthu.Text);
            tAIKHOANDOCGIA.MaDocGia = txtmadocgia.Text;
            this.DialogResult = true;
            this.Close();
        }
    }
}
