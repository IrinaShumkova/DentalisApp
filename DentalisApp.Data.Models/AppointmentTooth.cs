using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalisApp.Data.Models
{
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
