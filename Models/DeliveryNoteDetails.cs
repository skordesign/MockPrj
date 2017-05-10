using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MockPrj.Models
{
    public class DeliveryNoteDetails
    {
        public int DeliveryNoteId { get; set; }
        public virtual DeliveryNote DeliveryNote { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
    }
}