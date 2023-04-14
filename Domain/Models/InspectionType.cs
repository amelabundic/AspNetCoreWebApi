
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class InspectionType 
    {
        public int Id { get; set; }

        
        public string InspectionName { get; set; } = string.Empty; 

    }
}
