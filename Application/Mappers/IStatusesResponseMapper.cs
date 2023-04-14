﻿using Application.DTOs.Responses;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public interface IStatusesResponseMapper
    {
        public StatusResponse Map(Status statuses);
    }
}