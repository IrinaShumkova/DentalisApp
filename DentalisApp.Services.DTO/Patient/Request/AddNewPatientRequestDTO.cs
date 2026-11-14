using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalisApp.Services.DTO.Patient.Request
{
    public class AddNewPatientRequestDTO
    {
        public string EGN { get; set; } = null!;

        public string FirstName { get; set; } = null!;

         public string? SecondName { get; set; }

        public string LastName { get; set; } = null!;

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Allergies { get; set; }

        public string? MedicalHistory { get; set; }

        public string? Notes { get; set; }

        public string DentistId { get; set; } = null!;
    }
}
