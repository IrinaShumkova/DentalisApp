using DentalisApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DentalisApp.Data
{
    public class DentalisAppDbContex : IdentityDbContext
    {
        public DentalisAppDbContex(DbContextOptions<DentalisAppDbContex> options) 
        : base(options)
        {

        }

        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<ToothNumbersAll> ToothNumbersAlls { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; } = null!;
        public virtual DbSet<AppointmentTooth> AppointmentsTeeth { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppointmentTooth>()
             .HasKey(at => new { at.AppointmentId, at.ToothNumbersAllId });

            modelBuilder.Entity<AppointmentTooth>()
               .HasOne(at => at.Appointment)
               .WithMany(a => a.AppointmentTeeth)
               .HasForeignKey(at => at.AppointmentId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AppointmentTooth>()
                .HasOne(at => at.ToothNumbersAll)
                .WithMany(t => t.AppointmentTeeth)
                .HasForeignKey(at => at.ToothNumbersAllId)
                .OnDelete(DeleteBehavior.NoAction);

           modelBuilder.Entity<ToothNumbersAll>()
                .HasData
                (new ToothNumbersAll()
                {
                    Id = 1,
                    ToothNumber = 11,
                    ToothName = "Upper Right Central Incisor"
                },
                new ToothNumbersAll()
                {
                    Id = 2,
                    ToothNumber = 12,
                    ToothName = "Upper Right Lateral Incisor"
                },
                new ToothNumbersAll()
                {
                    Id = 3,
                    ToothNumber = 13,
                    ToothName = "Upper Right Canine"
                },
                new ToothNumbersAll()
                {
                    Id = 4,
                    ToothNumber = 14,
                    ToothName = "Upper Right First Premolar"
                },
                new ToothNumbersAll()
                {
                    Id = 5,
                    ToothNumber = 15,
                    ToothName = "Upper Right Second Premolar"
                },
                new ToothNumbersAll()
                {
                    Id = 6,
                    ToothNumber = 16,
                    ToothName = "Upper Right First Molar"
                },
                new ToothNumbersAll()
                {
                    Id = 7,
                    ToothNumber = 17,
                    ToothName = "Upper Right Second Molar"
                },
                new ToothNumbersAll()
                {
                    Id = 8,
                    ToothNumber = 18,
                    ToothName = "Upper Right Third Molar"
                },

                new ToothNumbersAll()
                {
                    Id = 9,
                    ToothNumber = 21,
                    ToothName = "Upper Left Central Incisor"
                },
                new ToothNumbersAll()
                {
                    Id = 10,
                    ToothNumber = 22,
                    ToothName = "Upper Left Lateral Incisor"
                },
                new ToothNumbersAll()
                {
                    Id = 11,
                    ToothNumber = 23,
                    ToothName = "Upper Left Canine"
                },
                new ToothNumbersAll()
                {
                    Id = 12,
                    ToothNumber = 24,
                    ToothName = "Upper Left First Premolar"
                },
                new ToothNumbersAll()
                {
                    Id = 13,
                    ToothNumber = 25,
                    ToothName = "Upper Left Second Premolar"
                },
                new ToothNumbersAll()
                {
                    Id = 14,
                    ToothNumber = 26,
                    ToothName = "Upper Left First Molar"
                },
                new ToothNumbersAll()
                {
                    Id = 15,
                    ToothNumber = 27,
                    ToothName = "Upper Left Second Molar"
                },
                new ToothNumbersAll()
                {
                    Id = 16,
                    ToothNumber = 28,
                    ToothName = "Upper Left Third Molar"
                },

                new ToothNumbersAll()
                {
                    Id = 17,
                    ToothNumber = 31,
                    ToothName = "Lower Left Central Incisor"
                },
                new ToothNumbersAll()
                {
                    Id = 18,
                    ToothNumber = 32,
                    ToothName = "Lower Left Lateral Incisor"
                },
                new ToothNumbersAll()
                {
                    Id = 19,
                    ToothNumber = 33,
                    ToothName = "Lower Left Canine"
                },
                new ToothNumbersAll()
                {
                    Id = 20,
                    ToothNumber = 34,
                    ToothName = "Lower Left First Premolar"
                },
                new ToothNumbersAll()
                {
                    Id = 21,
                    ToothNumber = 35,
                    ToothName = "Lower Left Second Premolar"
                },
                new ToothNumbersAll()
                {
                    Id = 22,
                    ToothNumber = 36,
                    ToothName = "Lower Left First Molar"
                },
                new ToothNumbersAll()
                {
                    Id = 23,
                    ToothNumber = 37,
                    ToothName = "Lower Left Second Molar"
                },
                new ToothNumbersAll()
                {
                    Id = 24,
                    ToothNumber = 38,
                    ToothName = "Lower Left Third Molar"
                },

                new ToothNumbersAll()
                {
                    Id = 25,
                    ToothNumber = 41,
                    ToothName = "Lower Right Central Incisor"
                },
                new ToothNumbersAll()
                {
                    Id = 26,
                    ToothNumber = 42,
                    ToothName = "Lower Right Lateral Incisor"
                },
                new ToothNumbersAll()
                {
                    Id = 27,
                    ToothNumber = 43,
                    ToothName = "Lower Right Canine"
                },
                new ToothNumbersAll()
                {
                    Id = 28,
                    ToothNumber = 44,
                    ToothName = "Lower Right First Premolar"
                },
                new ToothNumbersAll()
                {
                    Id = 29,
                    ToothNumber = 45,
                    ToothName = "Lower Right Second Premolar"
                },
                new ToothNumbersAll()
                {
                    Id = 30,
                    ToothNumber = 46,
                    ToothName = "Lower Right First Molar"
                },
                new ToothNumbersAll()
                {
                    Id = 31,
                    ToothNumber = 47,
                    ToothName = "Lower Right Second Molar"
                },
                new ToothNumbersAll()
                {
                    Id = 32,
                    ToothNumber = 48,
                    ToothName = "Lower Right Third Molar"
                });
        }

    }
}
