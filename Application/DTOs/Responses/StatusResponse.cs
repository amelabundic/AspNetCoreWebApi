using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Responses
{
    public class StatusResponse
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please,enter status option")]
        [Display(Name = "Status option")]
        public StatusOption? StatusOption { get; set; }
    }
}
