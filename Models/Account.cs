using System.ComponentModel.DataAnnotations;

namespace MockPrj.Models
{
    public class Account : Base
    {
        [MaxLength(10)]
        [Required]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(10)]
        public string Lastname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string PasswordHashed { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}