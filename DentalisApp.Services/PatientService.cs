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
        public async Task<IEnumerable<GetUserPatientResponseData>> GetPatientUserDataAsync(GetPatientUserData requestData)
        {
            if (string.IsNullOrWhiteSpace(requestData.UserId))
            {
                throw new ArgumentException("UserId cannot be null or empty.", nameof(requestData.UserId));  
            }

          IEnumerable<GetUserPatientResponseData> getUserPatientResponseDatas =  await dbContex.Patients
                .Where(p => p.DentistId.ToLower() == requestData.UserId.ToLower())
                .Select(p => new GetUserPatientResponseData
                {
                    Id = p.Id,
                    FirstName = p.FirstName
                })
                .OrderBy(p => p.Id)
                .Skip(requestData.SkipEntries)
                .Take(requestData.TakeEntries)
                .ToArrayAsync();

            return getUserPatientResponseDatas;
        }
    }
}
