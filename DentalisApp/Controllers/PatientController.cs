using DentalisApp.Services.Contracts;
using DentalisApp.Services.DTO.Patient.Request;
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

        public async Task<IActionResult> MyPatients()
        {
            string? userId = GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            GetPatientUserData requestData = new GetPatientUserData()
            {
                UserId = userId,
                SkipEntries = DefaultSkipEntries,
                TakeEntries = DefaultTakeEntries
            };

           // var patients = await patientService.GetPatientsAsync(requestData);
            return View();
        }
    }
}
