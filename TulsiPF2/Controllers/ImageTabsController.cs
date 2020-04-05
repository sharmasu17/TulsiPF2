using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using TulsiPF2.Models;
//using TulsiPF2.ViewModels;

namespace TulsiPF2.Controllers
{
    public class ImageTabsController : Controller
    {
        private TulsiPFModels db = new TulsiPFModels();

        [HttpGet]
        public ActionResult AddImage()
        {
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName");
            return View();
        }

      
        [HttpPost]
        public ActionResult AddImage(ImageTab tab)
        {
            if (tab.ImageFile != null && tab.ImageFile.ContentLength > 0)
            {
                string extension = Path.GetExtension(tab.ImageFile.FileName);
                if (extension.ToLower().Equals(".jpg") ||
                    extension.ToLower().Equals(".jpeg") ||
                    extension.ToLower().Equals(".png"))
                {
                    string fileName = Path.GetFileNameWithoutExtension(tab.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    tab.ImagePath = "~/Image/" + fileName;   // saving virtual path to table column

                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);   // combine full path  and filename
                    tab.ImageFile.SaveAs(fileName);   // to save to full path of the folder

                    db.ImageTabs.Add(tab);
                    db.SaveChanges();
                    ModelState.Clear();
                    MessageBox.Show("Image has been uploaded successfully !!");
                    return RedirectToRoute("ImageTabs");
                }
                else
                {
                    MessageBox.Show("Not an Image file - must be JPG, JPEG, PNG only !");
                    return RedirectToRoute("ImageTabs");
                }
            }
            else
            {
                MessageBox.Show("Invalid file, or size is 0 byte ");
                return RedirectToRoute("ImageTabs");
            }

        }

         //       return View();
         //       return RedirectToAction("Home");
         //       return RedirectToRoute("Home");
         //       return Redirect("MemActivities/Home");

    }
}
