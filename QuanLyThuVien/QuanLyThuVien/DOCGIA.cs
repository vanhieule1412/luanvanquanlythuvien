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
    
    public partial class DOCGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOCGIA()
        {
            this.TAIKHOANDOCGIAs = new HashSet<TAIKHOANDOCGIA>();
        }
    
        public string MaDocGia { get; set; }
        public string TenDocGia { get; set; }
        public System.DateTime NamSinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string GioiTinh { get; set; }
        public string CMND { get; set; }
        public string DiaChi { get; set; }
        public int MaTaiKhoai { get; set; }
    
        public virtual TAIKHOANTHUTHU TAIKHOANTHUTHU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAIKHOANDOCGIA> TAIKHOANDOCGIAs { get; set; }
    }
}
