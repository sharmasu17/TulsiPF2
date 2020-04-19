using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TulsiPF2.ViewModels;
using TulsiPF2.Models;

namespace TulsiPF2.Controllers
{
    public class UserRegisterController : Controller
    {
        private TulsiPFEntities4 db = new TulsiPFEntities4();

        // GET: UserRegister
        [HttpGet]

        public ActionResult Registration()
        {
            return View();
        }


        // GET: UserRegister
        [HttpPost]
        public ActionResult Registration(UserRegistration obj)
        {
            bool userexist = db.Users.Any(x => x.UserName == obj.UserName);
            if (userexist)
            {
                ViewBag.useridMessage = "This user id already exist - try another";
                return View();
            }

            bool emailexist = db.Users.Any(y => y.UserEmail == obj.UserEmail);
            if (emailexist)
            {
                ViewBag.emailMessage = "This email is already in use - try another";
                return View();
            }

            User u = new User();

            u.UserName = obj.UserName;
            u.UserPassword = obj.UserPassword;
            u.UserEmail = obj.UserEmail;
            u.UserMobile = obj.UserMobile;
            u.UserCreatedDate = DateTime.Now;

            db.Users.Add(u);
            db.SaveChanges();

            ViewBag.RegistrationSuccessful = "Registration Successfully Completed";
           
            return View();
        }
    }
}
