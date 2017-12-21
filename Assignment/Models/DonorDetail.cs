namespace Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DonorDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DonorId { get; set; }

        public long PhonenUMBER { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public virtual Donor Donor { get; set; }
    }
}
