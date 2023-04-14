using Application;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces;
using Application.Mappers;
using Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusesServiceGGG _statusesService;
        private readonly IStatusesResponseMapper _statusResponseMapper;
        public StatusController(IStatusesServiceGGG statusesService, IStatusesResponseMapper statusResponseMapper)
        {
            _statusesService = statusesService;
            _statusResponseMapper = statusResponseMapper;
        }

        //private readonly IStatusesService _statusesService;
        //private readonly IStatusesResponseMapper _statusResponseMapper;
        //public StatusController(IStatusesService statusesService, IStatusesResponseMapper _statusResponseMapper)
        //{
        //    this._statusesService = statusesService;
        //    this._statusResponseMapper = _statusResponseMapper; 
        //}
        
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllStatuses()
        {
            try
            {
                IList<Status> domainStatuses = _statusesService.GetAllStatuses();
                IList<StatusResponse> responseStatuses = new List<StatusResponse>();

                foreach (var domainStatus in domainStatuses)
                {
                    StatusResponse statusesResponse = _statusResponseMapper.Map(domainStatus);
                    responseStatuses.Add(statusesResponse);
                }
                return Ok(responseStatuses);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
           
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateStatus([FromBody] CreateStatusRequest request)
        {
            try
            {
                Status statuses = new Status
                {
                     //Id = request.Id,
                    StatusOption = request.StatusOption,

                };

                var createdStatuse = _statusesService.CreateStatus(statuses);
                return Ok(createdStatuse);  
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult RemoveStatus([FromQuery] int id)
        {
            try
            {

                bool removedStatus = _statusesService.RemoveStatus(id);
                
                return Ok(removedStatus);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult GetStatusById([FromQuery] int id)
        {
            try
            {
                Status statuses = _statusesService.GetStatusById(id);

                if (statuses == null)
                {
                    return NotFound();
                }

                StatusResponse statusesResponse = _statusResponseMapper.Map(statuses);
                return Ok(statusesResponse);    
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateStatus([FromBody] UpdateStatusReguest request)
        {
            try
            {
                Status statuses = _statusesService.GetStatusById(request.Id);

                if (statuses == null)
                {
                    return BadRequest($"The statuse with id{request.Id} does not exist");
                }
                statuses.Id = request.Id;
                statuses.StatusOption = request.StatusOption;

                bool updatesStatus = _statusesService.UpdateStatus(statuses);
                return Ok(updatesStatus);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
