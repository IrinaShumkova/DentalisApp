
namespace DentalisApp.Services.DTO.Patient.Request
{
    public class GetPatientUserData
    {
        public string UserId { get; set; }=null!;

        public int SkipEntries { get; set; }
        public int TakeEntries { get; set; }
    }
}
