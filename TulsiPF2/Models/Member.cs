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
    using System.ComponentModel.DataAnnotations;

    public partial class    Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            this.DonationTabs = new HashSet<DonationTab>();
            this.ImageTabs = new HashSet<ImageTab>();
        }
    
        public int MemberId { get; set; }
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(1)]
        [Required]
        public string Sex { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
        [DataType (DataType.EmailAddress)]
        public string Email { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string Profile { get; set; }
        public Nullable<System.DateTime> MemberSince { get; set; }
        [DisplayName("Address Line 1")]
        [MaxLength(50)]
        public string AddLine1 { get; set; }
        [DisplayName("Address Line 2")]
        [MaxLength(50)]
        public string AddLine2 { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        [MaxLength(30)]
        public string State { get; set; }
        [MaxLength(10)]
        public string Zip { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonationTab> DonationTabs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageTab> ImageTabs { get; set; }

        [DisplayName("Sex")]
        public virtual SexTab SexTab { get; set; }
    }
}
