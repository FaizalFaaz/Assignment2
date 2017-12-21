using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;



namespace Assignment.Models

{

    public class EFHospitalRepository : IHospitalRepository

    {
        Bloodbank db = new Bloodbank();
        
        public IQueryable<Hospital> Hospitals { get { return db.Hospitals; } }
        public IQueryable<Donor> Donors { get { return db.Donors; } }
        public IQueryable<DonorDetail> DonorDtails { get { return db.DonorDetails; } }

        public void Delete(Hospital hospital)

        {

            db.Hospitals.Remove(hospital);

            db.SaveChanges();

        }



        public Hospital Save(Hospital hospital)

        {

            if (hospital.HospitalId == 0)

            {

                db.Hospitals.Add(hospital);

            }

            else

            {

                db.Entry(hospital).State = EntityState.Modified;

            }

            db.SaveChanges();



            return hospital;

        }

    }

}