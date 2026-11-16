
namespace DentalisApp.Services.DTO.Patient.Response
{
    public class GetMyPatientsResponseDTO
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public string EGN { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? SecondName { get; set; }
        public string LastName { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string DentistId { get; set; } = null!;
    }
}
