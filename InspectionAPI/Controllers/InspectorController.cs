using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspectionAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class InspectorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInspectorService _inspectorService;
        public InspectorController(IMapper mapper, IInspectorService inspectorService)
        {
            _mapper = mapper;
            _inspectorService = inspectorService;   
        }

        [HttpGet]
        [Route("GetAllInspectors")]
        public IActionResult GetAllInspector()
        {
            try
            {
                IList<InspectorResponse> inspectorResponse = _inspectorService.GetAllInspector();   
                return Ok(inspectorResponse);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);  
            }
        }

        [HttpGet]
        [Route("GetInspectorById")]
        public IActionResult GetInspectorById([FromQuery] int id)
        {
            try
            {
                InspectorResponse inspectorResponse = _inspectorService.GetInspectorById(id);
                return Ok(inspectorResponse);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateInspector")]
        public IActionResult CreateInspector([FromBody] CreateInspectorReguest request)
        {
            try
            {
              bool created = _inspectorService.CreateInspector(request); 
                return Ok(created);
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("UpdateInspector")]
        public IActionResult UpdateInspector([FromBody] UpdateInspectorRequest request)
        {
            try
            {
               var updated = _inspectorService.UpdateInspector(request);
                return Ok(updated);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("RemoveInspector")]
        public IActionResult RemoveInspector([FromQuery] int id)
        {
            try
            {
                bool removedInspector = _inspectorService.RemoveInspector(id);
                return Ok(removedInspector);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
