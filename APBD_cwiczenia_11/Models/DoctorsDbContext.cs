using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cwiczenia_11.Models
{
    public class DoctorsDbContext : DbContext
    {

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Prescription> Prescriptions { get; set; }


        public DoctorsDbContext()
        {

        }

        public DoctorsDbContext(DbContextOptions options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>((builder) =>
            {
                //...
                builder.HasKey(e => e.IdDoctor);
                builder.Property(e => e.IdDoctor).ValueGeneratedOnAdd();
                builder.Property(e => e.FirstName).IsRequired();

                builder.HasMany(a => a.Prescriptions)
                       .WithOne(a => a.Doctor)
                       .HasForeignKey(a => a.IdDoctor)
                       .IsRequired();

                //builder.ToTable("Lekarz", "apbd");
            });


            modelBuilder.Entity<Prescription>((builder) =>
            {
                builder.HasKey(p => p.IdPrescription);
            });

            modelBuilder.Entity<Patient>((builder) =>
            {
                builder.HasKey(p => p.IdPatient);
                builder.Property(p => p.IdPatient).ValueGeneratedOnAdd();
                builder.Property(p => p.FirstName).IsRequired();

                builder.HasMany(p => p.Prescriptions)
                      .WithOne(p => p.Patient)
                      .HasForeignKey(p => p.IdPatient)
                      .IsRequired();

            });




            modelBuilder.Entity<Medicament>((builder) =>
            {
                builder.HasKey(m => m.IdMedicament);
                builder.Property(m => m.IdMedicament).ValueGeneratedOnAdd();
            });

            //modelBuilder.Entity<Prescription_Medicament>((builder) =>
            //{
            //    builder.HasOne(pm => pm.IdMedicament);
            //    builder.Property(pm => pm.IdMedicament).ValueGeneratedOnAdd();
            //});
        }


      

    }
}
