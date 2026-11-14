
using System.ComponentModel.DataAnnotations;
using static DentalisApp.Common.Constants.EntityValidation;

namespace DentalisApp.Web.ViewModels.Patient
{
     public class PatientCreateInputModel
    {
            [Required]
            [StringLength(PatientEGNLength)]
            [Display(Name = "EGN")]
            public string EGN { get; set; } = null!;

            [Required]
            [StringLength(PatientFirstNameMaxLength, MinimumLength = PatientFirstNameMinLength)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; } = null!;

            [MaxLength(PatientSecondNameMaxLength)]
            [Display(Name = "Second Name")]
            public string? SecondName { get; set; }

            [Required]
            [StringLength(PatientLastNameMaxLength, MinimumLength = PatientLastNameMinLength)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; } = null!;

            [MaxLength(PatientAddressMaxLength)]
            public string? Address { get; set; }

            [Phone]
            [MaxLength(PatientPhoneMaxLength)]
            public string? Phone { get; set; }

            [EmailAddress]
            [MaxLength(PatientEmailMaxLength)]
            public string? Email { get; set; }

            [MaxLength(PatientAllergiesMaxLength)]
            public string? Allergies { get; set; }

            [MaxLength(PatientMedicalHistoryMaxLength)]
            [Display(Name = "Medical History")]
            public string? MedicalHistory { get; set; }

            [MaxLength(PatientNotesMaxLength)]
            public string? Notes { get; set; }
        
    }
}
