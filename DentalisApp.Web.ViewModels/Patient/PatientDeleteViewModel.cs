
namespace DentalisApp.Web.ViewModels.Patient
{
    public class PatientDeleteViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public string EGN { get; set; } = null!;
        //public string FirstName { get; set; } = null!;
        //public string? SecondName { get; set; }
        //public string LastName { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public string FullName { get; set; } = null!;
        //public string FullName =>
        //$"{FirstName} {SecondName} {LastName}".Replace("  ", " ");
    }
}
