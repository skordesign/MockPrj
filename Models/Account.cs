using System.ComponentModel.DataAnnotations;

namespace MockPrj.Models
{
    public class Account : Base
    {
        [MaxLength(50)]
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string PasswordHashed { get; set; }
        public virtual Role Role { get; set; }
    }
}