using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TulsiPF2.Models;

namespace TulsiPF2.Models
{
    [Table("Member")]                       // below model is mapped with Member table
    public class MemberImageModel
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string Sex { get; set; }
        [DisplayName("Member Profile")]
        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string Profile { get; set; }

        public virtual ICollection<ImageTab> ImageTabs { get; set; }

        //      public List<ImageTab> ImageTabs { get; set; }  // from ImageTab- there can be multiple image for a person
    }
}