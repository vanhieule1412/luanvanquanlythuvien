﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyThuVien
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            
        }

        private void Btnquanltheloai_Click(object sender, RoutedEventArgs e)
        {

            GiaoDien.TheLoaiWindow f = new GiaoDien.TheLoaiWindow();
            this.Hide();
            f.ShowDialog();
            f.Close();
            this.ShowDialog();
            



        }

        private void Btnquanlnhaxuatban_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.NhaXuatBanWindow fnxb = new GiaoDien.NhaXuatBanWindow();
            this.Hide();
            fnxb.ShowDialog();
            fnxb.Close();
            this.ShowDialog();

        }

        private void Btnvitri_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.ViTriWindow fvitri = new GiaoDien.ViTriWindow();
            this.Hide();
            fvitri.ShowDialog(); 
            fvitri.Close();
            this.ShowDialog();

        }

        private void Btnthuthu_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.ThuThuWindow fthuthu = new GiaoDien.ThuThuWindow();
            this.Hide();
            fthuthu.ShowDialog();
            fthuthu.Close();
            this.ShowDialog();
        }

        private void Btndocgia_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.DocGiaWindow fdocgia = new GiaoDien.DocGiaWindow();
            this.Hide();
            fdocgia.ShowDialog();
            fdocgia.Close();
            this.ShowDialog();
        }

        private void Btnsach_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.SachWindow fsach = new GiaoDien.SachWindow();
            this.Hide();
            fsach.ShowDialog();
            fsach.Close();
            this.ShowDialog();
        }
    }
}