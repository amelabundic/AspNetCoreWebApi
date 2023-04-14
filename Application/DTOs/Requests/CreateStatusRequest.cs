using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Requests
{
    public class CreateStatusRequest
    {
        //public int Id { get; set; }
        //[Required]
        //[Display(Name = "Status option")]
        public StatusOption? StatusOption { get; set; }
    }
}
