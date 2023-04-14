using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Requests
{
    public class CreateTypeRequest
    {
        [Required(ErrorMessage = "Please,enter inspection name")]
        [Display(Name = "Inspection name")]
        public string? InspectionName { get; set; }
    }
}
