﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TulsiPF2.Models;

namespace TulsiPF2.Controllers
{
    public class MembersController : Controller
    {
        public TulsiPFEntities2 db = new TulsiPFEntities2();

        // GET: Members
        //public ActionResult Index()
        //{
        //    var members = db.Members.Include(m => m.SexTab);
        //    return View(members.ToList());
        //}

        public ActionResult Index(string searchBy, string search)
        {
            var members = db.Members.Include(m => m.SexTab);

            if (searchBy == "LastName")
            {
                return View(members.Where(x => x.LastName.StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "State")
            {
                return View(members.Where(x => x.State.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(members.Where(x => x.City.StartsWith(search) || search == null).ToList());
            }

        }



        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            ViewBag.Sex = new SelectList(db.SexTabs, "SexCode", "SexDesc");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberId,FirstName,LastName,Sex,Phone,Email,Profile,MemberSince,AddLine1,AddLine2,City,State,Zip")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sex = new SelectList(db.SexTabs, "SexCode", "SexDesc", member.Sex);
            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sex = new SelectList(db.SexTabs, "SexCode", "SexDesc", member.Sex);
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberId,FirstName,LastName,Sex,Phone,Email,Profile,MemberSince,AddLine1,AddLine2,City,State,Zip")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sex = new SelectList(db.SexTabs, "SexCode", "SexDesc", member.Sex);
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
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

