using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MockPrj.Models
{
    public class Product : Base
    {
        [MaxLength(30)]
        [MinLength(2)]
        [Required]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public bool Status { get; set; } = true;
        [Required]
        public double Quantity { get; set; }
        public string CalculationUnit { get; set; }
        [Required]
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<BillDetails> BillDetailses { get; set; }
        public virtual ICollection<DeliveryNoteDetails> DeliveryNoteDetailses { get; set; }
        public virtual ICollection<ReceiptNoteDetails> ReceiptNoteDetailses { get; set; }
    }
}