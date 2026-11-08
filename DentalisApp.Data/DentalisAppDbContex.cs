using DentalisApp.Data.Configuration;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppointmentTooth>()
               .HasOne(at => at.Appointment)
               .WithMany(a => a.AppointmentTeeth)
               .HasForeignKey(at => at.AppointmentId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<AppointmentTooth>()
                .HasOne(at => at.ToothNumbersAll)
                .WithMany(t => t.AppointmentTeeth)
                .HasForeignKey(at => at.ToothNumbersAllId)
                .OnDelete(DeleteBehavior.NoAction);

          builder.ApplyConfigurationsFromAssembly(typeof(DentalisAppDbContex).Assembly);
        }

    }
}
