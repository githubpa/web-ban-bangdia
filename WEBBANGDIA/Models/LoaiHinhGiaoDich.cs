//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEBBANGDIA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoaiHinhGiaoDich
    {
        public LoaiHinhGiaoDich()
        {
            this.DatHangs = new HashSet<DatHang>();
        }
    
        public int MaLoaiHinh { get; set; }
        public string TenLoaiHinh { get; set; }
        public int DatCoc { get; set; }
        public int ThanhToan { get; set; }
    
        public virtual ICollection<DatHang> DatHangs { get; set; }
    }
}
