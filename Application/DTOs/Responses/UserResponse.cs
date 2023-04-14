using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Responses
{
    public class UserResponse
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public string accesToken { get; set; }
        public string refreshToken { get; set; }

    }
}
