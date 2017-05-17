using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MockPrj.Models
{
    public class Role : Base
    {
        [MaxLength(20)]
        public string Name { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}