using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Responses
{
    public class InspectionTypesResponse
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please,enter inspection name")]
        [Display(Name = "Inspection name")]
        public string? InspectionName { get; set; }
    }
}
