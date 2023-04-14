using Application.DTOs.Responses;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class StatusResponseMapper : IStatusesResponseMapper
    {
        public StatusResponse Map(Status statuses)
        {
            if (statuses == null)
            {
                return new StatusResponse();
            }

            return new StatusResponse()
            {
                Id = statuses.Id,
                StatusOption = statuses.StatusOption,
            };
        }
    }
}
