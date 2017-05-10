using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MockPrj.Models
{
    public class ReceiptNoteDetails
    {
        public int ReceiptNoteId { get; set; }
        public virtual ReceiptNote ReceiptNote { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
    }
}