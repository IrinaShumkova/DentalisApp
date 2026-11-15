
namespace DentalisApp.Services.DTO.Patient.Request
{
    public class IsPatientSavedRequestDTO
    {
        public int PatientId { get; set; }
        public string UserId { get; set; } = null!;
    }
}
