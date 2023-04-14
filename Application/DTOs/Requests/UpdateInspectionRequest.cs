using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Requests
{
    public class UpdateInspectionRequest : CreateInspectionRequest
    {
        [Required(ErrorMessage = "Please,enter id")]
        public int Id { get; set; }
    }
}
