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
    /// Interaction logic for TheDocGiaWindow.xaml
    /// </summary>
    public partial class TheDocGiaWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public TAIKHOANDOCGIA TAIKHOANDOCGIA;
        public DOCGIA DOCGIA;

        public TheDocGiaWindow()
        {
            InitializeComponent();
        }
     


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
                txtmatkdocgia.Text = TAIKHOANDOCGIA.MaTaiKhoaiDocGia.ToString();
                txttendocgia.Text = TAIKHOANDOCGIA.DOCGIA.TenDocGia;
                dpnamsinh.SelectedDate = TAIKHOANDOCGIA.DOCGIA.NamSinh;
            cmbmataikhoanthuthu.SelectedValue = TAIKHOANDOCGIA.MaTaiKhoai;
                DateTime ngaytao = DateTime.Now;
                dtpngaytao.SelectedDate = ngaytao;
                DateTime ngayhet = ngaytao.AddYears(1);
                dtpngayhethan.SelectedDate = ngayhet;
            cmbmataikhoanthuthu.ItemsSource = dc.TAIKHOANTHUTHUs.ToList();
            


        }
        private string PhatSinhTuDong(UngDungQuanLyThuVienEntities dc)
        {
            string s = "";
            var c = dc.THEDOCGIAs.Count();
            if (c == 0)
                s = "TDG01";
            else
            {
                s = dc.THEDOCGIAs.ToList().ElementAt(c - 1).MaTheDocGia;
                string sso = s.Substring(3);
                var so = int.Parse(sso);
                so++;
                s = "TDG" + so;
            }
            return s;
        }

        private void Btntaotaikhoan_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = DateTime.Now;
            var ds = dc.THEDOCGIAs.Where(x => x.MaTheDocGia == txtmatkdocgia.Text).ToList();
            if (ds.Count > 0 && dtpngayhethan.SelectedDate > date)
            {
                MessageBox.Show("Thể loại này không thể xóa được");
                return;
            }
            string s = PhatSinhTuDong(dc);
            string randownumber;
            Random rd = new Random();            
            randownumber = rd.Next(1, 100).ToString();
            THEDOCGIA tHEDOCGIA = new THEDOCGIA();

                tHEDOCGIA.MaTheDocGia = s + randownumber;
                tHEDOCGIA.NgayTheDuocTao = dtpngaytao.SelectedDate.Value;
                tHEDOCGIA.NgayTheDuocGiaHan = dtpngayhethan.SelectedDate.Value;
                tHEDOCGIA.TenDocGia = txttendocgia.Text;
                tHEDOCGIA.NamSinh = dpnamsinh.SelectedDate.Value.Date;
                tHEDOCGIA.MaTaiKhoai = int.Parse(cmbmataikhoanthuthu.SelectedValue.ToString());
                tHEDOCGIA.MaTaiKhoaiDocGia = int.Parse(txtmatkdocgia.Text);
                dc.THEDOCGIAs.Add(tHEDOCGIA);
                dc.SaveChanges();
            this.Close();
           
            
        }     
    }
}
