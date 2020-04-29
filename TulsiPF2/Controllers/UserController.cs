
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TulsiPF2.Models;
using TulsiPF2.ViewModels;

namespace TulsiPF2.Controllers

{
    public class UserController : Controller
    {
        private TulsiPFEntities2 db = new TulsiPFEntities2();
       
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLogins user)
        {

            {
                var userdetails = db.Users.Where(a => a.UserName == user.UserName &&    // a.Username denote DB col.
                                                      a.UserPassword == user.UserPassword).FirstOrDefault();

                if (userdetails == null)
                {
                    user.LoginErrorMessage = "Wrong User Name or Password";
                    return View("Index", user);
                }

                else if (userdetails.IsAdmin == "Y")
                {
                    Session["UserId"] = userdetails.UserID;    // valid user and storing Userid to session for timeout
                    Session["UserName"] = userdetails.UserName;
                    Session["IsAdmin"] = userdetails.IsAdmin;

                    return RedirectToAction("MemActivities", "Home");

                }
                else
                {
                    Session["UserId"] = userdetails.UserID;    // valid user and storing Userid to session for timeout
                    Session["UserName"] = userdetails.UserName;
                    return RedirectToAction("MemListing", "Home");
                }

            }
        }


        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }



    }
}


