using System;
using System.ComponentModel.DataAnnotations;

namespace MockPrj.Models
{
    public class Base
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime ModifiedTime { get; set; }
    }
}