
namespace DentalisApp.Services.DTO.Patient.Request
{
    public class IsPatientPublishedRequestDTO
    {
        public int PatientId { get; set; }
        public string UserId { get; set; } = null!;
    }
}
