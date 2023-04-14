using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class InspectionTypesRepository : IInspectionTypesRepository
    {
        private readonly InspectionApiDbContext _inspectionApiDbContext;

        public InspectionTypesRepository(InspectionApiDbContext inspectionApiDbContext)
        {
            this._inspectionApiDbContext = inspectionApiDbContext;  
        }


        public IList<InspectionType> GetAllInspectionTypes()
        {
            return _inspectionApiDbContext.InspectionTypes.ToList();
        }

        public bool CreateInspectionTypes(InspectionType inspectionType)
        {

             _inspectionApiDbContext.Add(inspectionType);
            _inspectionApiDbContext.SaveChanges();
            return true;
        }


        public bool RemoveInspectionTypes(int id)
        {
            InspectionType removedInspectionType = _inspectionApiDbContext.InspectionTypes.Where(t => t.Id == id)
                .FirstOrDefault();

            if (removedInspectionType != null)
            {
                _inspectionApiDbContext.InspectionTypes.Remove(removedInspectionType);
                _inspectionApiDbContext.SaveChanges();
                return true;
            }
            return false;

        }


        public InspectionType GetInspectionTypesById(int id)
        {
            InspectionType inspectionTypes = _inspectionApiDbContext.InspectionTypes.Where(x => x.Id == id)
                .FirstOrDefault();

            return inspectionTypes;
        }


        public bool UpdateInspectionTypes(InspectionType inspectionType)
        {
            if (inspectionType != null)
            {
                _inspectionApiDbContext.InspectionTypes.Update(inspectionType);
                _inspectionApiDbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
