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
    public class InvoiceItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(InvoiceItemDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Column(TypeName = InvoiceItemPriceType)]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Invoice))]
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; } = null!;
    }
}
