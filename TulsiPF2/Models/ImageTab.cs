//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace TulsiPF2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web;

    public partial class ImageTab
    {
        public int ImageId { get; set; }

       
        [DisplayName("Title")]
        public string ImageTitle { get; set; }

        [DisplayName("Picture")]
        public string ImagePath { get; set; }
        public Nullable<int> MemberId { get; set; }

        public virtual Member Member { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}
