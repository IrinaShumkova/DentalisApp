
namespace DentalisApp.Services.DTO.Patient.Response
{
    public class GetPatientRemoveResponseDTO
    {
        public int Id { get; set; }

        public string EGN { get; set; } = null!;
        public string FirstName { get; set; } = null!;

        public string? SecondName { get; set; }

        public string LastName { get; set; } = null!;

        public string? Phone { get; set; }

        public string FullName =>
            $"{FirstName} {SecondName} {LastName}".Replace("  ", " ");
    }
}
