using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    public enum LichSumain { hienthi }
    public partial class MainWindow : Window 
    {
        
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public TAIKHOANTHUTHU TAIKHOANTHUTHU;
        private string path = "";
        private string tenFileHinh = "";
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

        private void Btnphieumuon_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.DanhSachPhieuMuonWindow fdanhsachphieumuon = new GiaoDien.DanhSachPhieuMuonWindow();
            this.Hide();
            fdanhsachphieumuon.ShowDialog();
            fdanhsachphieumuon.Close();

            this.ShowDialog();
        }

        private void Btnkhu_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.KhuWindow fkhu = new GiaoDien.KhuWindow();
            this.Hide();
            fkhu.ShowDialog();
            fkhu.Close();
            this.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DirectoryInfo di = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
            di = di.Parent;
            di = di.Parent;
            path = di.FullName + @"\Hinhanh\";
            //dgtimkiem.ItemsSource=dc.SACHes.
            dgtimkiem.ItemsSource = dc.SACHes.ToList();   
        }

        private void Btnthedocgia_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.CapNhatTheDocGiaWindow fthedocgia = new GiaoDien.CapNhatTheDocGiaWindow();
            this.Hide();
            fthedocgia.ShowDialog();
            fthedocgia.Close();
            this.ShowDialog();
        }

        private void Btnphieutra_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.PhieuTraWindow phieuTraWindow = new GiaoDien.PhieuTraWindow();
            this.Hide();
            phieuTraWindow.ShowDialog();
            phieuTraWindow.Close();
            this.ShowDialog();
                
        }

        private void Btntimkiem_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.HeThongTimKiemWindow f = new GiaoDien.HeThongTimKiemWindow();
            this.Hide();
            f.ShowDialog();
            f.Close();
            this.ShowDialog();
        }

        private void Txttimkiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txttimkiem.Text != "" && cmbtimten.IsSelected)
            {
                var filteredsach = dc.SACHes.Where(x => x.TenSach.ToLower().Contains(txttimkiem.Text.ToLower()));

                dgtimkiem.ItemsSource = null;
                dgtimkiem.ItemsSource = filteredsach.ToList();

            }
            else if (txttimkiem.Text != "" && cmbtimnamxuatban.IsSelected)
            {
                var filterednamxuatban = dc.SACHes.Where(x => x.NamXuatBan.ToString().Contains(txttimkiem.Text.ToString()));

                dgtimkiem.ItemsSource = null;
                dgtimkiem.ItemsSource = filterednamxuatban.ToList();


            }
            else
            {
                dgtimkiem.ItemsSource = dc.SACHes.ToList();
            }
        }

        private void Btndangnhap_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.LoginWindow login = new GiaoDien.LoginWindow();
            this.Close();
            login.ShowDialog();
          

        }

        private void Btndangxuat_Click(object sender, RoutedEventArgs e)
        {
            tbltentaikhoan.Text = null;
            menu.Visibility = Visibility.Collapsed;
            btndangnhap.Visibility = Visibility.Visible;
            menuquanly.Visibility = Visibility.Collapsed;
        }

        private void Dgtimkiem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgtimkiem.SelectedItem == null) return;
            SACH s = dgtimkiem.SelectedItem as SACH;
            if (s != null)
            {
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
                    else
                    {
                        return;
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

        private void Btndanhsachtaikhoandocgia_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.DanhSachTaiKhoanDocGiaWindow f = new GiaoDien.DanhSachTaiKhoanDocGiaWindow();
            this.Hide();
            f.ShowDialog();
            f.Close();
            this.ShowDialog();
        }

        private void Danhsachtaikhoanthuthu_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.DanhsachtaikhoanthuthuWindow f = new GiaoDien.DanhsachtaikhoanthuthuWindow();
            this.Hide();
            f.ShowDialog();
            f.Close();
            this.ShowDialog();
        }

        private void MnduyetPM_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.DanhsachphieumuonthuthuWindow f = new GiaoDien.DanhsachphieumuonthuthuWindow();
            this.Hide();
            f.ShowDialog();
            f.Close();
            this.ShowDialog();
        }


        private bool ktthe(string ma)
        {
            foreach (var a in dc.THEDOCGIAs)
            {
                if (a.MaTheDocGia == ma)
                {
                    return true;
                }
            }
            return false;

        }
        private void btnlapPMDG_Click(object sender, RoutedEventArgs e)
        {
            DateTime time = DateTime.Now;
            GiaoDien.DanhSachPhieuMuonDocGiaWindow f = new GiaoDien.DanhSachPhieuMuonDocGiaWindow();
            foreach (var a in dc.THEDOCGIAs)
            {
                if (tblthedocgia.Text == a.MaTheDocGia)
                {
                    TimeSpan kt = a.NgayTheDuocGiaHan - time;

                    if (kt.Days < 0)
                    {
                        MessageBox.Show("Thẻ Độc giả này đã hết hạn");
                        return;
                    }
                    else
                    {
                        f.ShowDialog();
                        f.Close();
                    }
                }
            }       


        }

        private void Mnshutdown_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.Application.Current.Shutdown();
            Environment.Exit(-1);
        }     
        private void Mnlichsu_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.LichSuWindow f = new GiaoDien.LichSuWindow();
            f.ls = GiaoDien.LichSu.hienthi;
            f.HIEUMUON = dc.PHIEUMUONs.Find(tblthedocgia.Text);
            this.Hide();
            f.ShowDialog();
            f.Close();
            this.ShowDialog();
           
        }
        private void Mnlichsutra_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.LichsutraWindow f = new GiaoDien.LichsutraWindow();
            f.PHIEUMUON = dc.PHIEUMUONs.Find(tblthedocgia.Text);
            this.Hide();
            f.ShowDialog();
            f.Close();
            this.ShowDialog();
        }

        private void Mnsuattcanhan_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.suathongtincanhanWindow f = new GiaoDien.suathongtincanhanWindow();
            f.TAIKHOANDOCGIA = dc.TAIKHOANDOCGIAs.Find(int.Parse(tblmataikhoan.Text));
            this.Hide();
            f.ShowDialog();
            f.Close();
            this.ShowDialog();
        }

        private void Mnsuattcanhanthuthu_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien.SuathongtincanhanthuthuWindow f = new GiaoDien.SuathongtincanhanthuthuWindow();
            f.TAIKHOANTHUTHU = dc.TAIKHOANTHUTHUs.Find(int.Parse(tblmataikhoan.Text));
            this.Hide();
            f.ShowDialog();
            f.Close();
            this.ShowDialog();
        }
    }
}
