using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TulsiPF2.Models
{
    public class MemberList
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int MemberSince { get; set; }

    }
}