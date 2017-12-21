namespace Assignment.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Bloodbank : DbContext
    {
        public Bloodbank()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<DonorDetail> DonorDetails { get; set; }
        public virtual DbSet<Donor> Donors { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonorDetail>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.Bloodgroup)
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .HasOptional(e => e.DonorDetail)
                .WithRequired(e => e.Donor);

            modelBuilder.Entity<Hospital>()
                .Property(e => e.HospitalName)
                .IsUnicode(false);

            modelBuilder.Entity<Hospital>()
                .Property(e => e.HospitalAddress)
                .IsUnicode(false);
        }
    }
}
