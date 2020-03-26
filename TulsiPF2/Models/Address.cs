using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TulsiPF2.Models
{
    public class Address   
    {
        public int Id { get; set; }
        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public String State { get; set; }
        public String City { get; set; }
        public String Zip { get; set; } 
    }
}