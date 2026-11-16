using DentalisApp.Services.DTO.Patient.Request;
using DentalisApp.Services.DTO.Patient.Response;
using Enums;
namespace DentalisApp.Services.Contracts
{
    public interface IPatientService
    {
        Task<IEnumerable<GetPatientUserResponseDTO>> GetPatientAllDataAsync(GetPatientUserRequestDTO requestData);

        Task<IEnumerable<GetMyPatientsResponseDTO>> GetPatientUserDataAsync(GetPatientUserRequestDTO requestData);
        Task<AddPatientResult> AddPatientAsync(AddNewPatientRequestDTO requestData);

        Task<GetPatientDetailsResponseDTO?> GetPatientByIdAsync(int id);
        Task<GetPatientDetailsResponseDTO?> GetPatientByIdAsync(int id, string dentistId);

        Task<AddPatientResult> UpdatePatientAsync(UpdatePatientRequestDTO requestData,string dentistId);

        Task<GetPatientRemoveResponseDTO?> GetPatientForRemoveAsync(int id, string dentistId);

        Task<AddPatientResult> RemovePatientAsync(RemovePatientRequestDTO requestData, string dentistId);

        Task<bool> IsPatientSavedAsync(IsPatientSavedRequestDTO requestData);

        Task<bool> IsPatientPublisherAsync(IsPatientPublishedRequestDTO requestData);
    }
}
