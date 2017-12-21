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
    public class HospitalsController : Controller
    {
        // private Bloodbank db = new Bloodbank();
        private IHospitalRepository db;
        public HospitalsController()
        {
            this.db =new EFHospitalRepository();

        }
        public HospitalsController(IHospitalRepository ihrep)
        {
            this.db = ihrep;
        }

        // GET: Hospitals
        public ViewResult Index()
        {
            return View(db.Hospitals.ToList());
        }

        // GET: Hospitals/Details/5
        public ViewResult Details(int? id)
        {
            if (id == null)
            {
                return View("error");
            }
            Hospital hospital = db.Hospitals.SingleOrDefault(a=> a.HospitalId == id);
            if (hospital == null)
            {
                return View("error");
            }
            return View(hospital);
        }

        // GET: Hospitals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hospitals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HospitalId,HospitalName,HospitalAddress,PhoneNumber")] Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                //db.Hospitals.Add(hospital);
                //db.SaveChanges();
                db.Save(hospital);
                return RedirectToAction("Index");
            }


            ViewBag.HospitalId = new SelectList(db.Hospitals, "HospitalAddress", "HospitalName", hospital.HospitalId);
            return View("Create");
        }

        // GET: Hospitals/Edit/5
        public ViewResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Hospital hospital = db.Hospitals.SingleOrDefault(a => a.HospitalId == id);
            if (hospital == null)
            {
                return View("Error");
            }
            return View(hospital);
        }

        // POST: Hospitals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HospitalId,HospitalName,HospitalAddress,PhoneNumber")] Hospital hospital)
        {

            if (ModelState.IsValid)
            {
                
                db.Save(hospital);
                return RedirectToAction("Index");
            }
            ViewBag.HospitalId = new SelectList(db.Hospitals, "HospitalAddress", "HospitalName", hospital.HospitalId);
            return View("Edit", hospital);

        }



    // GET: Hospitals/Delete/5
    public ViewResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Hospital hospital = db.Hospitals.SingleOrDefault(a => a.HospitalId == id);
            if (hospital == null)
            {
                return View("Error");
            }
            return View(hospital);
        }

        // POST: Hospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {           
            if (id == null)
            {
                return View("Error");
            }

            Hospital hospital = db.Hospitals.SingleOrDefault(a => a.HospitalId == id);
               if (hospital == null)
            {

                return View("Error");

            }
               
            db.Delete(hospital);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
