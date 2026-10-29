namespace DentalisApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DentalisApp.GCommon.Constants.EntityValidation;
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = AppointmentDateTimeSQlType)]
        public DateTime VisitDate { get; set; }

    
        [MaxLength(AppointmentDiagnosisMaxLength)]
        public string? Diagnosis { get; set; }

        [Column(TypeName = InvoiceItemPriceType)]
        public decimal Price { get; set; }

        [Column(TypeName = InvoiceItemPriceType)]
        public decimal Paid { get; set; }

        [NotMapped]
        public decimal? Balance => Price - Paid;

        [MaxLength(AppointmentNotesMaxLength)]
        public string? Notes { get; set; }

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; } = null!;

        public virtual ICollection<AppointmentTooth> AppointmentTeeth { get; set; }
        = new List<AppointmentTooth>();

    }
}
