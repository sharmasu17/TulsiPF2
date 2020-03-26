using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TulsiPF2.Models;

namespace TulsiPF2.ViewModels
{
    public class MemberList_Address
    {
        public Address vmobj { get; set; }
        public List<MemberList> MemberLists { get; set; }
                     
    }
}