using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MockPrj.Models
{
    public class Category : Base
    {
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }
        [MaxLength(200)]
        [MinLength(20)]
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}