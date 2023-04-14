using Application.DTOs.Responses;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public interface IInspectionTypesResponseMapper
    {
        public InspectionTypesResponse Map(InspectionType inspectionTypes);
    }
}
