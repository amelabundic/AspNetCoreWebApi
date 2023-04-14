using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Responses
{
    public class InspectorResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        //[Key]
        //public int Id { get; set; }

        //public string UserId { get; set; }

        //[StringLength(50)]
        //public string Address { get; set; }

        //[StringLength(50)]

        //[ForeignKey(nameof(UserId))]
        //public IdentityUser User { get; set; }
    }
}
