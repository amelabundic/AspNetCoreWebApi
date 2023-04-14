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
    public class InspectionService : IInspectionService
    {
        private readonly IInspectionRepository _inspectionRepository;

        public InspectionService(IInspectionRepository _inspectionRepository)
        {
            this._inspectionRepository = _inspectionRepository;
        }

        public bool CreateInspection(Inspection inspection)
        {
            return _inspectionRepository.CreateInspection(inspection);
        }

        public IList<Inspection> GetAllInspection()
        {
            return _inspectionRepository.GetAllInspection();
        }

        public Inspection GetInspectionById(int id)
        {
            return _inspectionRepository.GetInspectionById(id);
        }

        public bool RemoveInspection(int id)
        {
            return _inspectionRepository.RemoveInspection(id);
        }

        //public bool UpadateInspection(Inspection inspection)
        //{
        //    return _inspectionRepository.UpdateInspection(inspection);
        //}
    }
}
