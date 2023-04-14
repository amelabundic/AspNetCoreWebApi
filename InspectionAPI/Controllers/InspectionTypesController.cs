using Application;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces;
using Application.Mappers;
using Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class InspectionTypesController : ControllerBase
    {
        private readonly IInspectionTypesServiceGGG _inspectionTypesService;
        private readonly IInspectionTypesResponseMapper _inspectionTypesViewMapper;

        public InspectionTypesController(IInspectionTypesServiceGGG inspectionTypesService, IInspectionTypesResponseMapper inspectionTypesViewMapper)
        {
          _inspectionTypesService = inspectionTypesService;
            _inspectionTypesViewMapper = inspectionTypesViewMapper;
        }

        //private readonly IInspectionTypesService _inspectionTypesService;
        //private readonly IInspectionTypesResponseMapper _inspectionTypesViewMapper;

        //public InspectionTypesController(IInspectionTypesService inspectionTypesService, IInspectionTypesResponseMapper inspectionTypesViewMapper)
        //{
        //    this._inspectionTypesService = inspectionTypesService;
        //    this._inspectionTypesViewMapper = inspectionTypesViewMapper;  
        //}

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllInspectionTypes()
        {
            try
            {
                IList<InspectionType> domainTypes = _inspectionTypesService.GetAllInspectionTypes();
                IList<InspectionTypesResponse> responseType = new List<InspectionTypesResponse>();  

                foreach (var domainType in domainTypes)
                {
                    InspectionTypesResponse inspectionTypesResponse = _inspectionTypesViewMapper.Map(domainType);
                    responseType.Add(inspectionTypesResponse);
                }
                return Ok(responseType);    
            }
            catch (Exception e)
            {

                return BadRequest(e.Message); 
            }
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateInspectinTypes([FromBody] CreateTypeRequest request)
        {
            try
            {
                InspectionType inspectionType = new InspectionType 
                {
                 InspectionName = request.InspectionName,
                };

                bool createdType = _inspectionTypesService.CreateInspectionTypes(inspectionType);

                return Ok(createdType);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult RemoveInspectionTypes([FromQuery] int id)
        {
            try
            {
                bool removeInspectionTypes = _inspectionTypesService.RemoveInspectionTypes(id);

                return Ok(removeInspectionTypes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult GetInspectionTypeById([FromQuery] int id)
        {
            try
            {
                InspectionType inspectionType = _inspectionTypesService.GetInspectionTypesById(id);

                if (inspectionType == null)
                {
                    return BadRequest($"Inspection type with id {id} does not exist!");
                }

                InspectionTypesResponse response =  _inspectionTypesViewMapper.Map(inspectionType);
                return Ok(response);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateInspectionType([FromBody] UpdateTypeRequest request)
        {
            try
            {
                InspectionType inspectionType = _inspectionTypesService.GetInspectionTypesById(request.Id);

                if (inspectionType == null)
                {
                    return BadRequest($"Inspection with id {request.Id} does not exist!");
                }

                inspectionType.InspectionName = request.InspectionName;

                bool updateInspectionType = _inspectionTypesService.UpdateInspectionTypes(inspectionType);

                return Ok(updateInspectionType);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
