using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MockPrj.Models
{
    public class Bill : Base
    {
        [MaxLength(200)]
        public string Description { get; set; }
        public double Total { get; set; }
        public int AccountId { get; set; }
        public virtual Account Sale { get; set; }
        public bool IsDealt { get; set; }
        public virtual ICollection<BillDetails> BillDetailses { get; set; }
    }
}