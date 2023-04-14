using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TokenResponse
    {
        public string RefreshToken { get; set; } = String.Empty;
        public string AccessToken { get; set; } = String.Empty;
    }
}
