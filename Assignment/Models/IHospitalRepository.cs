using System;
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace Assignment.Models

{

    public interface IHospitalRepository

    {

        // used for Unit Testing with Mock Store Manager Album data

        IQueryable<Hospital> Hospitals { get; }

        IQueryable<Donor> Donors { get; }

        IQueryable<DonorDetail> DonorDtails { get; }

        Hospital Save(Hospital Hospitals);

        void Delete(Hospital Hospitals);

    }

}