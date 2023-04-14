using Application;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces;
using Application.Mappers;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class InspectionController : ControllerBase
    {
        private readonly IInspectionServiceGGG _inspectionService;
        private readonly IInspectionResponseMapper _inspectionResponseMapper;

        public InspectionController(IInspectionServiceGGG inspectionService, IInspectionResponseMapper inspectionResponseMapper)
        {
            this._inspectionResponseMapper = inspectionResponseMapper;
            this._inspectionService = inspectionService;
        }


        //private readonly IInspectionService _inspectionService;
        //private readonly IInspectionResponseMapper _inspectionResponseMapper;

        //public InspectionController(IInspectionService inspectionService,IInspectionResponseMapper inspectionResponseMapper)
        //{
        //    this._inspectionResponseMapper = inspectionResponseMapper;
        //    this._inspectionService = inspectionService;    
        //}

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllInspections()
        {
            try
            {
                IList<Inspection> domainInspections = _inspectionService.GetAllInspection();
                IList<InspectionResponse> responseInspections = new List<InspectionResponse>();

                foreach (var domainInspection in domainInspections)
                {
                    InspectionResponse inspectionResponse = _inspectionResponseMapper.Map(domainInspection);
                    responseInspections.Add(inspectionResponse);
                }
                return Ok(responseInspections);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateInspection([FromBody] CreateInspectionRequest request)
        {
            try
            {
                Inspection inspection = new Inspection
                { 
                    Status = request.Status,
                    Comment = request.Comment,
                    InspectionTypeId = request.InspectionTypeId,
                };

                bool createdInspection = _inspectionService.CreateInspection(inspection);
                
                return Ok(createdInspection);   
            }
            catch (Exception e)
            {

               return BadRequest(e.Message);
            }
        }
    
       [HttpDelete]
       [Route("[action]")]
        public IActionResult RemoveInspection([FromQuery] int id)
        {
            try
            {
                bool removedInspection = _inspectionService.RemoveInspection(id);
                return Ok(removedInspection);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetInspectionById([FromQuery]int id)
        {

            try
            {
                Inspection inspection = _inspectionService.GetInspectionById(id);

                if (inspection == null)
                {
                    return BadRequest($"Inspection with id {id} does not exist!");
                }

                InspectionResponse inspectionView =  _inspectionResponseMapper.Map(inspection);

                return Ok(inspectionView);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
              
        }


        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateInspection([FromBody] UpdateInspectionRequest request)
        {
            try
            {
                Inspection inspection = _inspectionService.GetInspectionById(request.Id);

                if (inspection == null)
                {
                    return BadRequest($"Inspection with id {request.Id} does not exist");
                }
                    inspection.Status = request.Status;
                    inspection.Comment = request.Comment;
                    inspection.InspectionTypeId = request.InspectionTypeId;

                    bool updatedInspection = _inspectionService.UpdateInspection(inspection);

                
                return Ok(updatedInspection);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
