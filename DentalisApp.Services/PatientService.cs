using DentalisApp.Data;
using DentalisApp.Data.Models;
using DentalisApp.Services.Contracts;
using DentalisApp.Services.DTO.Patient.Request;
using DentalisApp.Services.DTO.Patient.Response;
using Enums;
using Microsoft.AspNetCore.Mvc;
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
                    IsActive = requestData.IsActive,
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

        public async Task<GetPatientDetailsResponseDTO?> GetPatientByIdAsync(int id)
        {
            Patient? patient = await dbContex.Patients.FindAsync(id);

            GetPatientDetailsResponseDTO? patientDetailsResponse = null;

            if (patient != null)
            {
                patientDetailsResponse = new GetPatientDetailsResponseDTO
                {
                    Id = patient.Id,
                    EGN = patient.EGN,
                    FirstName = patient.FirstName,
                    SecondName = patient.SecondName,
                    LastName = patient.LastName,
                    Address = patient.Address,
                    Phone = patient.Phone,
                    Email = patient.Email,
                    Allergies = patient.Allergies,
                    MedicalHistory = patient.MedicalHistory,
                    Notes = patient.Notes,
                    IsActive = patient.IsActive,
                    DentistId = patient.DentistId
                };
            }
            return patientDetailsResponse;
        }

        public Task<bool> IsPatientPublisherAsync(IsPatientPublishedRequestDTO requestData)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsPatientSavedAsync(IsPatientSavedRequestDTO requestData)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<GetPatientUserResponseDTO>> GetPatientAllDataAsync(GetPatientUserRequestDTO requestData)
        {
            if (string.IsNullOrWhiteSpace(requestData.UserId))
            {
                throw new ArgumentException("UserId cannot be null or empty.", nameof(requestData.UserId));  
            }

          IEnumerable<GetPatientUserResponseDTO> getUserPatientResponseDatas =  await dbContex.Patients
                .Select(p => new GetPatientUserResponseDTO
                {
                    Id = p.Id,
                    IsActive = p.IsActive,
                    FirstName = p.FirstName,
                    SecondName = p.SecondName,
                    LastName = p.LastName,
                    EGN = p.EGN,
                    Phone = p.Phone,
                    Email = p.Email,
                    DentistId = p.DentistId

                })
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.SecondName)
                .ThenBy(p => p.LastName)
                .ToArrayAsync();

            return getUserPatientResponseDatas;
        }

        public async Task<IEnumerable<GetMyPatientsResponseDTO>> GetPatientUserDataAsync(GetPatientUserRequestDTO requestData)
        {
            if (string.IsNullOrWhiteSpace(requestData.UserId))
            {
                throw new ArgumentException("UserId cannot be null or empty.", nameof(requestData.UserId));
            }

            IEnumerable<GetMyPatientsResponseDTO> getMyPatientsResponseDatas = await dbContex.Patients
                  .Where(p => p.DentistId.ToLower() == requestData.UserId.ToLower())
                  .Select(p => new GetMyPatientsResponseDTO
                  {
                      Id = p.Id,
                      IsActive = p.IsActive,
                      FirstName = p.FirstName,
                      SecondName = p.SecondName,
                      LastName = p.LastName,
                      EGN = p.EGN,
                      Phone = p.Phone,
                      Email = p.Email,
                      DentistId = p.DentistId
                  })
                  .OrderBy(p => p.FirstName)
                  .ThenBy(p => p.SecondName)
                  .ThenBy(p => p.LastName)
                  .ToArrayAsync();

            return getMyPatientsResponseDatas;
        }

        public async Task<AddPatientResult> UpdatePatientAsync(UpdatePatientRequestDTO requestData, string dentistId)
        {
            Patient? patient = await dbContex.Patients.FirstOrDefaultAsync(p =>p.Id == requestData.Id &&
            p.DentistId == dentistId);

            if (patient == null)
            {
                return AddPatientResult.NotAuthorized;
            }

            bool egnExists = await dbContex.Patients
                .AnyAsync(p =>p.EGN == requestData.EGN && p.Id != requestData.Id);

            if (egnExists)
                return AddPatientResult.EgnAlreadyExists;

            patient.Id = requestData.Id;
            patient.IsActive = requestData.IsActive;
            patient.EGN = requestData.EGN;
            patient.FirstName = requestData.FirstName;
            patient.SecondName = requestData.SecondName;
            patient.LastName = requestData.LastName;
            patient.Address = requestData.Address;
            patient.Phone = requestData.Phone;
            patient.Email = requestData.Email;
            patient.Allergies = requestData.Allergies;
            patient.MedicalHistory = requestData.MedicalHistory;
            patient.Notes = requestData.Notes;
            patient.DentistId = dentistId;

            await dbContex.SaveChangesAsync();

            return AddPatientResult.Success;
        }

        public async Task<GetPatientDetailsResponseDTO?> GetPatientByIdAsync(int id, string dentistId)
        {
            return await dbContex.Patients
                .Where(p => p.Id == id && p.DentistId == dentistId)
                .Select(p => new GetPatientDetailsResponseDTO
                {
                    Id = p.Id,
                    EGN = p.EGN,
                    FirstName = p.FirstName,
                    SecondName = p.SecondName,
                    LastName = p.LastName,
                    Address = p.Address,
                    Phone = p.Phone,
                    Email = p.Email,
                    Allergies = p.Allergies,
                    MedicalHistory = p.MedicalHistory,
                    Notes = p.Notes,
                    IsActive = p.IsActive,
                    DentistId = p.DentistId
                })
                .FirstOrDefaultAsync();
        }
    }
}
