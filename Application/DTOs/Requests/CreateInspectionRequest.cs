using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Requests
{
    public class CreateInspectionRequest
    {
        [Required(ErrorMessage = "Please,enter status")]
        [Display(Name = "Status")]
        public string? Status { get; set; }

        [Required(ErrorMessage = "Please,enter comment")]
        [Display(Name = "Comment")]
        [StringLength(250)]
        public string? Comment { get; set; }

        [Required(ErrorMessage = "Please,enter inspection type id")]
        [Display(Name = "Inspection type id")]
        public int InspectionTypeId { get; set; }
    }
}
