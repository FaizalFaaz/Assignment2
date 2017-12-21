using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Assignment.Models;
namespace Assignment.Controllers

{/*[Authorize]*/
    public class DonorsController : Controller
    {
        private Bloodbank db = new Bloodbank();

        // GET: Donors
        public ActionResult Index()
        {

            var donors = db.Donors.Include(d => d.DonorDetail);
            return View(donors.ToList());
        }

        // GET: Donors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }

        // GET: Donors/Create
        public ActionResult Create()
        {
            ViewBag.ContactId = new SelectList(db.DonorDetails, "DonorId", "Email", "PhonenUMBER");
            return View();
        }

        // POST: Donors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include =  "Name,Address,Bloodgroup,DonorId,Email,PhonenUMBER")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                db.Donors.Add(donor);
                db.SaveChanges();
                return RedirectToAction("../DonorDetails/Create",new { id = "ContactId" });
            }

            ViewBag.ContactId = new SelectList(db.DonorDetails, "DonorId", "Email", "PhonenUMBER", donor.ContactId);
            return View(donor);
        }

        // GET: Donors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Donor donor = db.Donors.Find(id);
            DonorDetail donorDetail = db.DonorDetails.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.DonorDetails, "DonorId", "Email", "PhonenUMBER", donor.ContactId);
            return View(donor);
        }

        // POST: Donors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactId,Name,Address,Bloodgroup")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.ContactId = new SelectList(db.DonorDetails, "DonorId", "Email", "PhonenUMBER", donor.ContactId);
            return View(donor);
        }

        // GET: Donors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }
        [Authorize (Roles = "Administrator")]
        // POST: Donors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donor donor = db.Donors.Find(id);
            db.Donors.Remove(donor);
            DonorDetail donorDetail = db.DonorDetails.Find(id);
            db.DonorDetails.Remove(donorDetail);
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
