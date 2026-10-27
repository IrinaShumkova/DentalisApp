namespace DentalisApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DentalisApp.GCommon.Constants.EntityValidation;
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;

        [Required]
        [StringLength(PatientEGNLength, MinimumLength =PatientEGNLength)]
        public string EGN { get; set; } = null!;


        [Required]
        [MaxLength(PatientFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [MaxLength(PatientSecondNameMaxLength)]
        public string? SecondName { get; set; }

        [Required]
        [MaxLength(PatientLastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [MaxLength(PatientAddressMaxLength)]
        public string? Address { get; set; }

        [MaxLength(PatientPhoneMaxLength)]
        public string? Phone { get; set; }

        [EmailAddress]
        [MaxLength(PatientEmailMaxLength)]
        public string? Email { get; set; }

        [MaxLength(PatientAllergiesMaxLength)]
        public string? Allergies { get; set; }

        [MaxLength(PatientMedicalHistoryMaxLength)]
        public string? MedicalHistory { get; set; }

        [MaxLength(PatientNotesMaxLength)]
        public string? Notes { get; set; }

        [Required]
        [ForeignKey(nameof(Dentist))]
        public string DentistId { get; set; } = null!;
        public virtual IdentityUser Dentist { get; set; } = null!;

        public virtual ICollection<Appointment> Appointments { get; set; }
        = new List<Appointment>();
    }
}
