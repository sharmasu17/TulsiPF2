using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TulsiPF2.Models;
//using TulsiPF2.ViewModels;


namespace TulsiPF2.Controllers
{

    public class MemberListController : Controller
    {
        private TulsiPFModels db = new TulsiPFModels();

        // GET: Members
        public ActionResult Listing()
        {
            var members = db.Members;
            return View(members.ToList());
        }

    }

}

//public class MemberListController : Controller
//{
//    // GET: MemberList
//    public ActionResult Listing()
//    {
//        Address addobj = new Address();
//            addobj.City = "Mumbai";
//            addobj.Id = 1;
//        MemberList_Address memaddobj = new MemberList_Address();
//        memaddobj.vmobj = addobj;

//        MemberList list = new MemberList();
//            list.Id = 1;
//            list.FirstName = "Suresh";
//            list.LastName = "Sharma";
//            list.Title = "President";
//            list.MemberSince = 2015;

//        MemberList list2 = new MemberList();
//            list2.Id = 2;
//            list2.FirstName = "Jatinder";
//            list2.LastName = "Raheja";
//            list2.Title = "Lead";
//            list2.MemberSince = 2019;

//        List<MemberList> MemberLists = new List<MemberList>();
//            MemberLists.Add(list);
//            MemberLists.Add(list2);

//        memaddobj.MemberLists = MemberLists;

//        return View(memaddobj);
//    }
//}
