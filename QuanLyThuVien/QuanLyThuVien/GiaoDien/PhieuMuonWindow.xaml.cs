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
    /// Interaction logic for PhieuMuonWindow.xaml
    /// </summary>
    public enum KieuPhepToan {Them,Sua }
    public partial class PhieuMuonWindow : Window
    {
        private UngDungQuanLyThuVienEntities dc = new UngDungQuanLyThuVienEntities();
        public KieuPhepToan pheptoan;
        //public Model.SACH sACH;
        public PHIEUMUON pHIEUMUON ;
        public PHIEUMUON HIEUMUON = new PHIEUMUON();
        //public Model.SACH_PHIEUMUON sACH_PHIEUMUON;
        public PhieuMuonWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbMaThuThu.ItemsSource = dc.THUTHUs.ToList();
            cmbMasach.ItemsSource = dc.SACHes.ToList();
            cmbMaDocGia.ItemsSource = dc.DOCGIAs.ToList();
            if (pheptoan == KieuPhepToan.Sua)
            {
                txtmaphieumuon.Text = pHIEUMUON.MaPhieuMuon;
                //cmbMaThuThu.SelectedValue = pHIEUMUON.THUTHU.MaThuThu;
                //cmbMaDocGia.SelectedValue = pHIEUMUON.DOCGIA.MaDocGia;
                dpNgayMuon.SelectedDate = pHIEUMUON.NgayMuon;
               // dpNgayTra.SelectedDate = pHIEUMUON.NgayTra;
                cmbtrangthai.SelectedItem = pHIEUMUON.TrangThai;
                if (cmbtrangthai.SelectedItem.ToString() == "Đã Trả" )
                    cmbtrangthai.SelectedItem = "Đã Trả";
                else
                    cmbtrangthai.SelectedItem = "Chưa Trả";

               // dgChitiet.ItemsSource = pHIEUMUON.SACH_PHIEUMUON;               
            }
        }

        private void Btnchon_Click(object sender, RoutedEventArgs e)
        {
          //  SACH_PHIEUMUON temp = null;
           
            if (cmbMasach.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn sách");
                return;
            }

            if (cmbMasach.SelectedItem == null) return;
            //foreach (SACH_PHIEUMUON t in HIEUMUON.SACH_PHIEUMUON.Where(x => x.MaSach == cmbMasach.SelectedValue.ToString()))
            //{
            //    temp = t;
            //    break;
            //}
            //if (temp == null)
            //{

            //    SACH_PHIEUMUON ct = new SACH_PHIEUMUON();
            //    ct.SACH = cmbMasach.SelectedItem as SACH;
            //    ct.MaSach = ct.SACH.MaSach;
            //    ct.SoLuongSachMuon = int.Parse(txtSoluong.Text);
            //    HIEUMUON.SACH_PHIEUMUON.Add(ct);

            //}
            //else
            //{
            //    temp.SoLuongSachMuon += int.Parse(txtSoluong.Text);
            //}

           
            //var kq = getChitietphieumuon(HIEUMUON);

            //dgChitiet.ItemsSource = kq.ToList();
           
        }
        //private IEnumerable<object> getChitietphieumuon(PHIEUMUONTRA pHIEUMUON)
        //{
        //    //var kq = pHIEUMUON.SACH_PHIEUMUON.ToList().Select(x => new
        //    //{
        //    //    MaSach = x.MaSach,
        //    //    TenSach = x.SACH.TenSach,
        //    //    TacGia = x.SACH.TacGia,
        //    //    NguoiDich = x.SACH.NguoiDich,
        //    //    SoLuongSachMuon = x.SoLuongSachMuon,

        //    //});
        //    //return kq.ToList();
        //}

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            //string masach = dgChitiet.SelectedValue.ToString();
            //foreach (SACH_PHIEUMUON t in HIEUMUON.SACH_PHIEUMUON.Where(x => x.MaSach == masach))
            //{
            //    HIEUMUON.SACH_PHIEUMUON.Remove(t);
            //    break;
            //}
            //var kq = getChitietphieumuon(HIEUMUON);
            //dgChitiet.ItemsSource = kq.ToList();

        }

        private void Btnlapphieumuon_Click(object sender, RoutedEventArgs e)
        {
            //pHIEUMUON = new PHIEUMUON();
            ////Model.PHIEUMUON x = new Model.PHIEUMUON();
            //pHIEUMUON.MaPhieuMuon = txtmaphieumuon.Text;
            //pHIEUMUON.MaThuThu = cmbMaThuThu.SelectedValue.ToString();
            //pHIEUMUON.MaDocGia = cmbMaDocGia.SelectedValue.ToString();
            //pHIEUMUON.NgayMuon = dpNgayMuon.SelectedDate.Value;
            //pHIEUMUON.NgayTra = dpNgayTra.SelectedDate.Value;
            //pHIEUMUON.TrangThai = cmbtrangthai.SelectionBoxItem.ToString();
            //// x.TienPhat = int.Parse(txttienphat.Text);

            //this.DialogResult = true;
            //this.Close();
        }
    }
}
