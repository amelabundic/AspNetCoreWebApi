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
    public class InspectionTypesServiceGGG : IInspectionTypesServiceGGG
    {
        private readonly IUnitOfWork _unitOfWork;
        public InspectionTypesServiceGGG(IUnitOfWork unitOfWork)
        {
         _unitOfWork = unitOfWork;  
        }
        public bool CreateInspectionTypes(InspectionType inspectionType)
        {
            _unitOfWork.InspectionType.Add(inspectionType);
            _unitOfWork.Save();
            return true;
        }

        public IList<InspectionType> GetAllInspectionTypes()
        {
            return _unitOfWork.InspectionType.GetAllInspectionTypes();
        }

        public InspectionType GetInspectionTypesById(int id)
        {
           return _unitOfWork.InspectionType.GetById(id);
        }

        public bool RemoveInspectionTypes(int id)
        {
            return _unitOfWork.InspectionType.RemoveInspectionTypes(id);
        }

        public bool UpdateInspectionTypes(InspectionType inspectionTypes)
        {
            return _unitOfWork.InspectionType.UpdateInspectionTypes(inspectionTypes);
        }
    }
}
