using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MockPrj.Models
{
    public class DeliveryNote : Base
    {
        public string Description { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<DeliveryNoteDetails> DeliveryNoteDetailses { get; set; }
    }
}