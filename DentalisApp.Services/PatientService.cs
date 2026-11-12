using DentalisApp.Data;
using DentalisApp.Services.Contracts;
using DentalisApp.Services.DTO.Patient.Request;
using DentalisApp.Services.DTO.Patient.Response;
using Microsoft.EntityFrameworkCore;

namespace DentalisApp.Services
{
    public class PatientService : IPatientService
    {
        private readonly DentalisAppDbContex dbContex;

        public PatientService(DentalisAppDbContex dbContex)
        {
            this.dbContex = dbContex;
        }
        public async Task<IEnumerable<GetPatientUserResponseDTO>> GetPatientUserDataAsync(GetPatientUserRequestDTO requestData)
        {
            if (string.IsNullOrWhiteSpace(requestData.UserId))
            {
                throw new ArgumentException("UserId cannot be null or empty.", nameof(requestData.UserId));  
            }

          IEnumerable<GetPatientUserResponseDTO> getUserPatientResponseDatas =  await dbContex.Patients
                .Where(p => p.DentistId.ToLower() == requestData.UserId.ToLower())
                .Select(p => new GetPatientUserResponseDTO
                {
                    Id = p.Id,
                    IsActive = p.IsActive,
                    FirstName = p.FirstName,
                    SecondName = p.SecondName,
                    LastName = p.LastName,
                    EGN = p.EGN,
                    Phone = p.Phone,
                    Email = p.Email

                })
                .OrderBy(p => p.Id)
                .ToArrayAsync();

            return getUserPatientResponseDatas;
        }
    }
}
