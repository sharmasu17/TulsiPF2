using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TulsiPF2.ViewModels
{
    
    public partial class UserRegistration
       {
        
        public int UserID { get; set; }

        [DisplayName("User Id")]
        [MinLength(5)]
        [Required(ErrorMessage = "This field is Required")]
        public string UserName { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password), MinLength(5)]
        [Required(ErrorMessage = "This field is Required and must be > 5 characters")]
        public string UserPassword { get; set; }

        [Compare("UserPassword"), DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        public string ConfirmUserPassword { get; set; }

        [EmailAddress, Required]
        [DisplayName("Email")]
        public string UserEmail { get; set; }

        [DisplayName("Mobile (Opt)")]
        public string UserMobile { get; set; }
    
        }
}
