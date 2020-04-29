using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TulsiPF2.Models;

namespace TulsiPF2.Controllers
{
    public class DonationTabsController : Controller
    {
        private TulsiPFEntities2 db = new TulsiPFEntities2();

        // GET: DonationTabs
        public ActionResult Index()
        {
            var donationTabs = db.DonationTabs.Include(d => d.Member);
            return View(donationTabs.ToList());
        }

        // GET: DonationTabs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationTab donationTab = db.DonationTabs.Find(id);
            if (donationTab == null)
            {
                return HttpNotFound();
            }
            return View(donationTab);
        }

        // GET: DonationTabs/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName");
            return View();
        }

        // POST: DonationTabs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonationId,Donation,DonationDate,DonationDetail,MemberId")] DonationTab donationTab)
        {
            if (ModelState.IsValid)
            {
                db.DonationTabs.Add(donationTab);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName", donationTab.MemberId);
            return View(donationTab);
        }

        // GET: DonationTabs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationTab donationTab = db.DonationTabs.Find(id);
            if (donationTab == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName", donationTab.MemberId);
            return View(donationTab);
        }

        // POST: DonationTabs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonationId,Donation,DonationDate,DonationDetail,MemberId")] DonationTab donationTab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donationTab).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName", donationTab.MemberId);
            return View(donationTab);
        }

        // GET: DonationTabs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationTab donationTab = db.DonationTabs.Find(id);
            if (donationTab == null)
            {
                return HttpNotFound();
            }
            return View(donationTab);
        }

        // POST: DonationTabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonationTab donationTab = db.DonationTabs.Find(id);
            db.DonationTabs.Remove(donationTab);
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
