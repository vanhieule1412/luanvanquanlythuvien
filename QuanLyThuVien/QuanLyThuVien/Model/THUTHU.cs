//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyThuVien.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class THUTHU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THUTHU()
        {
            this.PHIEUMUONs = new HashSet<PHIEUMUON>();
        }
    
        public string MaThuThu { get; set; }
        public string TenThuThu { get; set; }
        public int NamSinh { get; set; }
        public int SoDienThoai { get; set; }
        public Nullable<bool> TrangThaiHoatDong { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUMUON> PHIEUMUONs { get; set; }
    }
}
