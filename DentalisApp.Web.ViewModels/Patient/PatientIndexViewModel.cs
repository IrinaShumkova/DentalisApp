using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalisApp.Web.ViewModels.Patient
{
    public class PatientIndexViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public string EGN { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? SecondName { get; set; }
        public string LastName { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string FullName =>
        $"{FirstName} {SecondName} {LastName}".Replace("  ", " ");

    }
}
