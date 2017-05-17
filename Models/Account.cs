using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MockPrj.Models
{
    public class Account : Base
    {
        [MaxLength(20)]
        [MinLength(2)]
        [Required]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Lastname { get; set; }
        [Required]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(200)]
        public string PasswordHashed { get; set; }
        public bool IsBlocked { get; set; } = false;
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<ReceiptNote> ReceiptNotes { get; set; }
        public virtual ICollection<DeliveryNote> DeliveryNotes { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}