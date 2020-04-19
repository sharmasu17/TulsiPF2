using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TulsiPF2.ViewModels
{
    public class UserLogin
    {

            public int UserID { get; set; }

            [DisplayName("User Id  ")]
            [Required(ErrorMessage = "  This field is Required")]

            public string UserName { get; set; }

            [DisplayName("Password  ")]
            [DataType(DataType.Password)]
            [Required(ErrorMessage = "  This field is Required")]
            public string UserPassword { get; set; }

            public string LoginErrorMessage { get; set; }
        }
    }
