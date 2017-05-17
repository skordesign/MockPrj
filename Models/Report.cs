using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MockPrj.Models
{
    public class Report : Base
    {
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Content { get; set; }
        public bool IsSeen { get; set; }
        public bool IsSaleMngt { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}