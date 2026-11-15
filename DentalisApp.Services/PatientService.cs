using DentalisApp.Data;
using DentalisApp.Data.Models;
using DentalisApp.Services.Contracts;
using DentalisApp.Services.DTO.Patient.Request;
using DentalisApp.Services.DTO.Patient.Response;
using Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DentalisApp.Services
{
    public class PatientService : IPatientService
    {
        private readonly DentalisAppDbContex dbContex;
        private readonly ILogger<PatientService> logger;

        public PatientService(DentalisAppDbContex dbContex, ILogger<PatientService> logger)
        {
            this.dbContex = dbContex;
            this.logger = logger;
        }

        public async Task<AddPatientResult> AddPatientAsync(AddNewPatientRequestDTO requestData)
        {
            bool egnExists = await dbContex.Patients.AnyAsync(p => p.EGN == requestData.EGN);

            if (egnExists)
            {
                return AddPatientResult.EgnAlreadyExists;
            }

            Patient newPatient = new Patient
                {
                    EGN = requestData.EGN,
                    FirstName = requestData.FirstName,
                    SecondName = requestData.SecondName,
                    LastName = requestData.LastName,
                    Address = requestData.Address,
                    Phone = requestData.Phone,
                    Email = requestData.Email,
                    Allergies = requestData.Allergies,
                    MedicalHistory = requestData.MedicalHistory,
                    Notes = requestData.Notes,
                    DentistId = requestData.DentistId
                };
            try
            {
                await dbContex.Patients.AddAsync(newPatient);
                await dbContex.SaveChangesAsync();
                return AddPatientResult.Success;
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occurred while adding a new patient.");
            }
      
            return AddPatientResult.Failed;

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
