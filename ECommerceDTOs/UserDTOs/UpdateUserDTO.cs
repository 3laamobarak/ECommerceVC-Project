using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDTOs
{
    public class UpdateUserDTO
    {
        public int UserId { get; set; }
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[\W_]).+$", ErrorMessage = "Password must include letters, numbers, and symbols.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Username is required.")]

        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email format is invalid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "FirstName is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required.")]

        public string LastName { get; set; }

    }
}
