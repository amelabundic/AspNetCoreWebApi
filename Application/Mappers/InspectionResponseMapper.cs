using Application.DTOs.Responses;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class InspectionResponseMapper : IInspectionResponseMapper
    {
        public InspectionResponse Map(Inspection inspection)
        {
            if (inspection == null)
            {
                return new InspectionResponse();
            }

            return new InspectionResponse()
            {
                Status = inspection.Status,
                Comment = inspection.Comment,
                InspectionTypeId = inspection.InspectionTypeId,
            };
        }
    }
}
