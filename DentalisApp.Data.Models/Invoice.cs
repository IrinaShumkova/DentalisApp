using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalisApp.Data.Models
{
    using static GCommon.Constants.EntityValidation;
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(InvoiceNumberMaxLength)]
        public string InvoiceNumber { get; set; } = null!;

        public DateTime InvoiceDate { get; set; } = DateTime.Today;

        [Column(TypeName = InvoiceItemPriceType)]
        [NotMapped]
        public decimal Total => InvoiceItems.Sum(i => i.Price);

        
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; } = null!;

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } =
        new List<InvoiceItem>();

    }
}
