using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Requests
{
    public class CreateInspectorReguest
    {

        //[Key]
        //public int Id { get; set; }

        //public string UserId { get; set; } = string.Empty;  

        //[StringLength(50)]
        //public string Address { get; set; } = string.Empty;

        //[StringLength(50)]

        //[ForeignKey(nameof(UserId))]
        //public IdentityUser User { get; set; }


        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
