//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyThuVien
{
    using System;
    using System.Collections.Generic;
    
    public partial class PHIEUMUONTRA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUMUONTRA()
        {
            this.SACH_PHIEUMUONTRA = new HashSet<SACH_PHIEUMUONTRA>();
        }
    
        public string MaPhieuMuon { get; set; }
        public System.DateTime NgayMuon { get; set; }
        public int SoLuongSachMuon { get; set; }
        public bool TrangThai { get; set; }
        public Nullable<decimal> TienPhatTong { get; set; }
        public System.DateTime NgayTraDukien { get; set; }
        public Nullable<bool> DaTra { get; set; }
        public int MaTaiKhoai { get; set; }
        public string MaTheDocGia { get; set; }
    
        public virtual THEDOCGIA THEDOCGIA { get; set; }
        public virtual TAIKHOANTHUTHU TAIKHOANTHUTHU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SACH_PHIEUMUONTRA> SACH_PHIEUMUONTRA { get; set; }
    }
}
