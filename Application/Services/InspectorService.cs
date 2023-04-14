using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using Persistence.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class InspectorService : IInspectorService
    {
        private readonly IInspectorRepository _inspectorRepository;
        private readonly IMapper _mapper;

        public InspectorService(IInspectorRepository inspectorRepository, IMapper mapper)
        {
            _inspectorRepository = inspectorRepository;
            _mapper = mapper;
        }

        public bool CreateInspector(CreateInspectorReguest inspectorRequest)
        {
          
            if (inspectorRequest != null)
            {
                var newInspector = _mapper.Map<Inspector>(inspectorRequest);
                _inspectorRepository.CreateInspector(newInspector);
                return true;
            }
            return false;
        }

        public IList<InspectorResponse> GetAllInspector()
        {

          var InspectorsList =  _inspectorRepository.GetAllInspector();
          var InspectorsListResponse = _mapper.Map<List<InspectorResponse>>(InspectorsList);

            return InspectorsListResponse;

        }

        public InspectorResponse GetInspectorById(int id)
        {
            if (id > 0)
            {
                var inspector = _inspectorRepository.GetInspectorById(id);

                if (inspector != null)
                {
                    var inspectorIdResponse = _mapper.Map<InspectorResponse>(inspector); 
                    return inspectorIdResponse;
                }
            }

            return null;
        }

        public bool RemoveInspector(int id)
        {
            return _inspectorRepository.RemoveInspector(id);
        }

        public bool UpdateInspector(UpdateInspectorRequest updateReguest)
        {
            if (updateReguest != null)
            {
                var updateInspector = _mapper.Map<Inspector>(updateReguest);
                _inspectorRepository.UpdateInspector(updateInspector);
                return true;
            }
            return false;
        }
    }
}
