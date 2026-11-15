using DentalisApp.Services.DTO.Patient.Request;
using DentalisApp.Services.DTO.Patient.Response;
using Enums;
namespace DentalisApp.Services.Contracts
{
    public interface IPatientService
    {
        Task<IEnumerable<GetPatientUserResponseDTO>> GetPatientUserDataAsync(GetPatientUserRequestDTO requestData);
        Task<AddPatientResult> AddPatientAsync(AddNewPatientRequestDTO requestData);
    }
}
