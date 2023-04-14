using Application.Interfaces;
using Domain.Models;
using Persistence.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class InspectionTypesService : IInspectionTypesService
    {
        private readonly IInspectionTypesRepository _inspectionTypesRepository;

        public InspectionTypesService(IInspectionTypesRepository inspectionTypesRepository)
        {
            this._inspectionTypesRepository = inspectionTypesRepository;
        }


        public IList<InspectionType> GetInspectionTypes()
        {
            return _inspectionTypesRepository.GetAllInspectionTypes();
        }

        public bool CreateInspectionTypes(InspectionType inspectionType)
        {
            InspectionType inspectionTypes = new InspectionType
            {
                InspectionName = inspectionType.InspectionName
            };

            return _inspectionTypesRepository.CreateInspectionTypes(inspectionTypes);
        }


        public InspectionType GetInspectionTypesById(int id)
        {
            return _inspectionTypesRepository.GetInspectionTypesById(id);
        }

        public bool RemoveInspectionTypes(int id)
        {
            return _inspectionTypesRepository.RemoveInspectionTypes(id);
        }

        public bool UpdateInspectionTypes(InspectionType inspectionType)
        {
            return _inspectionTypesRepository.UpdateInspectionTypes(inspectionType);
        }
    }
}
