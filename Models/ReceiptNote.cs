using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MockPrj.Models
{
    public class ReceiptNote : Base
    {
        public string Description { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<ReceiptNoteDetails> ReceiptNoteDetailses { get; set; }
    }
}