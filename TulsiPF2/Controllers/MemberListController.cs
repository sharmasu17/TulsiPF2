using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TulsiPF2.Models;


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

        // not in use
        public ActionResult MemberImageListing()   
        {
            List<Member> members = db.Members.ToList();
             return View(members);
        }

        // not in use
        public ActionResult DisplayImage(int memid)  
        {
            List<ImageTab> imagepath = db.ImageTabs.Where(img => img.MemberId == memid).ToList();
            return View(imagepath);
        }


        public ActionResult MemberProfile()
        {
            List<ImageTab> imagetab = db.ImageTabs.ToList();
            return View(imagetab);
        }

    }

}


