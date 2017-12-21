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
{
    public class DonorDetailsController : Controller
    {
        private Bloodbank db = new Bloodbank();

        // GET: DonorDetails contact details of donors
        public ActionResult Index()
        {
            //Relationship betwwen Donor and DonorDetails
            var donorDetails = db.DonorDetails.Include(d => d.Donor);
            return View(donorDetails.ToList());
        }

        // GET: DonorDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorDetail donorDetail = db.DonorDetails.Find(id);
            if (donorDetail == null)
            {
                return HttpNotFound();
            }
            return View(donorDetail);
        }

        // GET: DonorDetails/Create
        public ActionResult Create()
        {
            ViewBag.DonorId = new SelectList(db.Donors, "ContactId", "Name");
            return View();
        }

        // POST: DonorDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonorId,PhonenUMBER,Email")] DonorDetail donorDetail)
        {
            if (ModelState.IsValid)
            {
                db.DonorDetails.Add(donorDetail);
                db.SaveChanges();
                return RedirectToAction("../Donors/Index");
            }

            ViewBag.DonorId = new SelectList(db.Donors, "ContactId", "Name", donorDetail.DonorId);
            return View(donorDetail);
        }

        // GET: DonorDetails/Edit/
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorDetail donorDetail = db.DonorDetails.Find(id);
            if (donorDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonorId = new SelectList(db.Donors, "ContactId", "Name", donorDetail.DonorId);
            return View(donorDetail);
        }

        // POST: DonorDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonorId,PhonenUMBER,Email")] DonorDetail donorDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donorDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../Donors/Index");
            }
            ViewBag.DonorId = new SelectList(db.Donors, "ContactId", "Name", donorDetail.DonorId);
            return View(donorDetail);
        }

        // GET: DonorDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorDetail donorDetail = db.DonorDetails.Find(id);
            if (donorDetail == null)
            {
                return HttpNotFound();
            }
            return View(donorDetail);
        }

        // POST: DonorDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
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
