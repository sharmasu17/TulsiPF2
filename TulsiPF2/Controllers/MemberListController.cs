using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TulsiPF2.Models;


namespace TulsiPF2.Controllers
{
    public class MemberListController : Controller
    {
        public TulsiPFEntities2 db = new TulsiPFEntities2();

        // GET: Members
        public ActionResult Listing()
        {
            var members = db.Members;
            return View(members.ToList());
        }


        public ActionResult MemberProfile()
        {
            List<ImageTab> imagetab = db.ImageTabs.ToList();
            return View(imagetab);
        }


    }

}


