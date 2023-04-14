using Application.DTOs.Responses;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class IdentityResponseMapper : IIdentityResponseMapper
    {
        public UserResponse Map(User user)
        {
            //if (inspection == null)
            //{
            //    return new InspectionResponse();
            //}

            //return new InspectionResponse()
            //{
            //    Status = inspection.Status,
            //    Comment = inspection.Comment,
            //    InspectionTypeId = inspection.InspectionTypeId,
            //};

            if (user == null)
            {
                return new UserResponse();
            }
            return new UserResponse()
            {
                username = user.UserName,
                
            };
        }
    }
}
