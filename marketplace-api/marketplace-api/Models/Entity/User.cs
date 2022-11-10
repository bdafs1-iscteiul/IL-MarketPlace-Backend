using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace marketplace_api.Models.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public long MembershipNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public long PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
