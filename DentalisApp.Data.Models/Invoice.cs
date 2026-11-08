using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalisApp.Data.Models
{
    using static Common.Constants.EntityValidation;
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
