using DentalisApp.Services.DTO.Patient.Request;
using DentalisApp.Services.DTO.Patient.Response;
namespace DentalisApp.Services.Contracts
{
    public interface IPatientService
    {
        Task<IEnumerable<GetPatientUserResponseDTO>> GetPatientUserDataAsync(GetPatientUserRequestDTO requestData);
    }
}
