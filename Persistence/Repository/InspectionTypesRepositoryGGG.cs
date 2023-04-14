using Domain.Models;
using Persistence.IGenericRepository;
using Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class InspectionTypesRepositoryGGG : GenericRepository<InspectionType>, IInspectionTypesRepositoryGGG
    {
        public InspectionTypesRepositoryGGG(InspectionApiDbContext _inspectionApiDbContext) : base(_inspectionApiDbContext)
        {
        }

        public bool CreateInspectionTypes(InspectionType inspectionType)
        {
            _inspectionApiDbContext.Add(inspectionType);
            _inspectionApiDbContext.SaveChanges();
            return true;
        }

        public IList<InspectionType> GetAllInspectionTypes()
        {
            return _inspectionApiDbContext.InspectionTypes.ToList();
        }

        public InspectionType GetInspectionTypesById(int id)
        {
            InspectionType inspectionTypes = _inspectionApiDbContext.InspectionTypes.Where(x => x.Id == id)
                 .FirstOrDefault();

            return inspectionTypes;
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

        public bool UpdateInspectionTypes(InspectionType inspectionTypes)
        {
            if (inspectionTypes != null)
            {
                _inspectionApiDbContext.InspectionTypes.Update(inspectionTypes);
                _inspectionApiDbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
