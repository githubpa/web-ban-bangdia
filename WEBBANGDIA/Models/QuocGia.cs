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
    
    public partial class QuocGia
    {
        public QuocGia()
        {
            this.HangSanXuats = new HashSet<HangSanXuat>();
        }
    
        public int MaQG { get; set; }
        public string TenQG { get; set; }
    
        public virtual ICollection<HangSanXuat> HangSanXuats { get; set; }
    }
}
