using DentalisApp.Services.Contracts;
using DentalisApp.Services.DTO.Patient.Request;
using DentalisApp.Services.DTO.Patient.Response;
using DentalisApp.Web.ViewModels.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}
