using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TulsiPF2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Tulsi Phuloria Foundation";
           
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Do you want to send message, please write below and click send.";

            return View();
        }


        [HttpPost]
        public ActionResult Contact(string message)
        {
            ViewBag.Message = "Thanks, we got your message.";

            return View();
        }

        public ActionResult MemActivities()
        {
            List<SelectListItem> Items = new List<SelectListItem> ();
            SelectListItem item1 = new SelectListItem() { Text = "Select Options", Value = "1", Selected = true };
            SelectListItem item2 = new SelectListItem() { Text = "Add/Upd/Del Member Details", Value = "2", Selected = false };
            SelectListItem item3 = new SelectListItem() { Text = "Add/Upd/Del Member Donation", Value = "3", Selected = false };
            SelectListItem item4 = new SelectListItem() { Text = "Upload Member Picture", Value = "4", Selected = false };
            SelectListItem item5 = new SelectListItem() { Text = "Delete Member Picture", Value = "5", Selected = false };
            SelectListItem item6 = new SelectListItem() { Text = "Member Listing", Value = "6", Selected = false };
            SelectListItem item7 = new SelectListItem() { Text = "Member Profile", Value = "7", Selected = false };
            SelectListItem item8 = new SelectListItem() { Text = "Logout", Value = "9", Selected = false };

            Items.Add(item1);
            Items.Add(item2);
            Items.Add(item3);
            Items.Add(item4);
            Items.Add(item5);
            Items.Add(item6);
            Items.Add(item7);
            Items.Add(item8);


            ViewBag.Memberdata = Items;

            return View();
        }


        public ActionResult MemListing()
        {
            List<SelectListItem> Items = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem() { Text = "Select Options", Value = "1", Selected = true };
            SelectListItem item2 = new SelectListItem() { Text = "Members Details", Value = "2", Selected = false };
            SelectListItem item3 = new SelectListItem() { Text = "Members Profile", Value = "3", Selected = false };
            SelectListItem item4 = new SelectListItem() { Text = "Logout", Value = "9", Selected = false };

            Items.Add(item1);
            Items.Add(item2);
            Items.Add(item3);
            Items.Add(item4);
    

            ViewBag.Memberdata = Items;

            return View();
        }


    }

}
