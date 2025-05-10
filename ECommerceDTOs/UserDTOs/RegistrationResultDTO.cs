using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDTOs
{
    public class RegistrationResultDTO
    {
        public bool Success { get; set; } = true;
        public RegisterUserDto RegisterationUserData { get; set; }
        public Dictionary<string,List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();
    }
}
