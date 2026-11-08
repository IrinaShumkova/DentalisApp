using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalisApp.Data.Models
{
    [PrimaryKey(nameof(AppointmentId), nameof(ToothNumbersAllId))]
    public class AppointmentTooth
    {
        [ForeignKey(nameof(Appointment))]
        public int AppointmentId { get; set; }

        public virtual Appointment Appointment { get; set; } = null!;

        [ForeignKey(nameof(ToothNumbersAll))]
        public int ToothNumbersAllId { get; set; }

        public virtual ToothNumbersAll ToothNumbersAll { get; set; } = null!;

    }
}
