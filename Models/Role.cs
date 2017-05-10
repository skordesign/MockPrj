using System.Collections.Generic;

namespace MockPrj.Models
{
    public class Role : Base
    {
        public string Name { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}