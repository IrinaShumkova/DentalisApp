using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalisApp.Data.Models
{
    public class ToothNumbersAll
    {
        [Key]
        public int Id { get; set; }

        public int ToothNumber { get; set; }

        public string ToothName { get; set; } = null!;

        public virtual ICollection<AppointmentTooth> AppointmentTeeth { get; set; }
       = new List<AppointmentTooth>();
    }
}
