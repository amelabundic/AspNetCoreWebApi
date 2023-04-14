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
    public class InspectionServiceGGG : IInspectionServiceGGG
    {
        private readonly IUnitOfWork _unitOfWork;
        public InspectionServiceGGG(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        public bool CreateInspection(Inspection inspection)
        {
            _unitOfWork.Inspection.Add(inspection);
            _unitOfWork.Save();
            return true;
        }

        public IList<Inspection> GetAllInspection()
        {
            return _unitOfWork.Inspection.GetAllInspection();
        }

        public Inspection GetInspectionById(int id)
        {
            return _unitOfWork.Inspection.GetById(id);
        }

        public bool RemoveInspection(int id)
        {
            return _unitOfWork.Inspection.RemoveInspection(id);
        }

        public bool UpdateInspection(Inspection inspection)
        {
            return _unitOfWork.Inspection.UpdateInspection(inspection);
        }
    }
}
