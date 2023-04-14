using Application.DTOs.Responses;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class InspectionTypesResponseMapper : IInspectionTypesResponseMapper
    {
        public InspectionTypesResponse Map(InspectionType inspectionTypes)
        {
            if (inspectionTypes == null)
            {
                return new InspectionTypesResponse();
            }

            return new InspectionTypesResponse()
            {
                Id = inspectionTypes.Id,

                InspectionName = inspectionTypes.InspectionName,
            };
        }
    }
}
