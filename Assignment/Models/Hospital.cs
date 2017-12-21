namespace Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hospital
    {
        public int HospitalId { get; set; }

        [StringLength(50)]
        public string HospitalName { get; set; }

        [StringLength(50)]
        public string HospitalAddress { get; set; }

        public long? PhoneNumber { get; set; }
    }
}
