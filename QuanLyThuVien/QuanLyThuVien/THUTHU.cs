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
    
    public partial class THUTHU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THUTHU()
        {
            this.TAIKHOANTHUTHUs = new HashSet<TAIKHOANTHUTHU>();
        }
    
        public string MaThuThu { get; set; }
        public string TenThuThu { get; set; }
        public Nullable<System.DateTime> NamSinh { get; set; }
        public int SoDienThoai { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public Nullable<int> CMND { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAIKHOANTHUTHU> TAIKHOANTHUTHUs { get; set; }
    }
}
