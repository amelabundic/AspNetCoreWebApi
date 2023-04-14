using Application.DTOs.Requests;
using Application.DTOs.Responses;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper
{
    public class ApiMapping : Profile
    {
        public ApiMapping()
        {
            CreateMap<Inspector,InspectorResponse>().ReverseMap();
            CreateMap<Inspector, CreateInspectorReguest>().ReverseMap();
            CreateMap<Inspector, UpdateInspectorRequest>().ReverseMap();
        
        }
    }
}
