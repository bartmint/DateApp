using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DateApp.UI.ViewModels
{
    public class UserForRegisterDtO
    {
        [Required] [MinLength(5, ErrorMessage ="Min 5 letters")] public string Username { get; set; }
        [Required] public string KnownAs { get; set; }
        [Required] public string Gender { get; set; }
        [Required] public DateTime DateOfBirth { get; set; }
        [Required] public string City { get; set; }
        [Required] public string Country { get; set; }
        [Required][StringLength(8,MinimumLength =4, ErrorMessage ="At least 4 letters password")] public string Password { get; set; }
    }
}
