using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyImage.Models
{
    public class User : IdentityUser
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [Required]

        public string Gender { get; set; }
        [Required]
        [Phone]
        public string Contact { get; set; }
        [Required]

        public string Address { get; set; }
    }
}
