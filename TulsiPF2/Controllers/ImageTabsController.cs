﻿using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Windows;
using TulsiPF2.Models;
//using TulsiPF2.ViewModels;

namespace TulsiPF2.Controllers
{
    public class ImageTabsController : Controller
    {
        public TulsiPFEntities2 db = new TulsiPFEntities2();


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
                    tab.ImagePath = "~/Image/" + fileName;   // saving table column

                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    tab.ImageFile.SaveAs(fileName);   // to save with full path of the folder

                    db.ImageTabs.Add(tab);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.ImageMessage = "Image has been uploaded successfully !!";
                    //MessageBox.Show("Image has been uploaded successfully !!");
                    //return RedirectToRoute("ImageTabs");
                    //return RedirectToAction("AddImage", "ImageTabs");
                    return View();
                }
                else
                {
                    ViewBag.ImageMessage = "Not an Image file - must be JPG, JPEG, PNG only !";
                    return View();
                }
            }
            else
            {
                ViewBag.ImageMessage = "Invalid file, or size is 0 byte";
                return View();
            }

        }


        // GET: ImageTabs
        public ActionResult Index()
        {
            var imageTabs = db.ImageTabs.Include(i => i.Member);
            return View(imageTabs.ToList());
        }



        // GET: ImageTabs1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageTab imageTab = db.ImageTabs.Find(id);
            if (imageTab == null)
            {
                return HttpNotFound();
            }
            return View(imageTab);
        }

        // POST: ImageTabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImageTab imageTab = db.ImageTabs.Find(id);
            db.ImageTabs.Remove(imageTab);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
