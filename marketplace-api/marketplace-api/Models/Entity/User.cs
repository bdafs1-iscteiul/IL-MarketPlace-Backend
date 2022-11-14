using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace marketplace_api.Models.Entity
{
    //User model should have other optional params such as Age/Location nationality
    //OR instead of putting it in user model we put it on profile with its own model
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]//must be unique//maybe doesnt need long
        public long MembershipNumber { get; set; }
        [Required]
        //must be unique
        public string Email { get; set; }
        [Required]//must be unique  //maybe doesnt need long
        public long PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
