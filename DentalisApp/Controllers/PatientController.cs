using DentalisApp.Services.Contracts;
using DentalisApp.Services.DTO.Patient.Request;
using DentalisApp.Services.DTO.Patient.Response;
using DentalisApp.Web.ViewModels.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Enums;


namespace DentalisApp.Web.Controllers
{
using static Common.Constants.ApplicationConstants;
    
    public class PatientController : BaseController
    {
        private readonly IPatientService patientService;

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? userId = GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            IEnumerable<GetPatientUserResponseDTO> patientData 
            = await patientService.GetPatientUserDataAsync(new GetPatientUserRequestDTO { UserId = userId });

            ICollection<PatientIndexViewModel> patientViewModels = new List<PatientIndexViewModel>();

            foreach (GetPatientUserResponseDTO patient in patientData)
            {
                PatientIndexViewModel patientIndexViewModel=new PatientIndexViewModel
                {
                    Id = patient.Id,
                    IsActive = patient.IsActive,
                    EGN = patient.EGN,
                    FirstName = patient.FirstName,
                    SecondName = patient.SecondName,
                    LastName = patient.LastName,
                    Phone = patient.Phone,
                    Email = patient.Email
                };
                patientViewModels.Add(patientIndexViewModel);
            }
           
            return View(patientViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            PatientCreateInputModel patientCreateInputModel = new PatientCreateInputModel();
            
            return View(patientCreateInputModel);
            
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientCreateInputModel patientCreateInputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(patientCreateInputModel);
            }
            string? userId = GetUserId();

            if (userId == null)
            {
                return Unauthorized();
            }


            AddNewPatientRequestDTO addNewPatientRequestDTO = new AddNewPatientRequestDTO
            {
                EGN = patientCreateInputModel.EGN,
                FirstName = patientCreateInputModel.FirstName,
                SecondName = patientCreateInputModel.SecondName,
                LastName = patientCreateInputModel.LastName,
                Address = patientCreateInputModel.Address,
                Phone = patientCreateInputModel.Phone,
                Email = patientCreateInputModel.Email,
                Allergies = patientCreateInputModel.Allergies,
                MedicalHistory = patientCreateInputModel.MedicalHistory,
                Notes = patientCreateInputModel.Notes,
                DentistId = userId
            };
            AddPatientResult addPatientResult = await patientService.AddPatientAsync(addNewPatientRequestDTO);

            switch (addPatientResult)
            {       
                case AddPatientResult.Success:
                    TempData["SuccessMessage"] = "Patient successfully registered!";
                    return RedirectToAction(nameof(Index));

                case AddPatientResult.EgnAlreadyExists:
                    ModelState.AddModelError(nameof(patientCreateInputModel.EGN),"A patient with this EGN already exists.");
                    return View(patientCreateInputModel);

                case AddPatientResult.Failed:
                    ModelState.AddModelError(string.Empty,"An error occurred while saving the patient.");
                    return View(patientCreateInputModel);
            }
          
            return RedirectToAction(nameof(Index));
        }

    }
}
