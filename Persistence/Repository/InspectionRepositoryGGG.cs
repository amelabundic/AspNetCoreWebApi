using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.IGenericRepository;
using Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class InspectionRepositoryGGG : GenericRepository<Inspection>, IInspectionRepositoryGGG
    {
        public InspectionRepositoryGGG(InspectionApiDbContext _inspectionApiDbContext) : base(_inspectionApiDbContext)
        {
        }

        public bool CreateInspection(Inspection inspection)
        {
            _inspectionApiDbContext.Add(inspection);
            _inspectionApiDbContext.SaveChanges();
            return true;
        }

        public IList<Inspection> GetAllInspection()
        {
            return _inspectionApiDbContext.Inspections
               .Include(x => x.InspectionType).ToList<Inspection>();
        }

        public Inspection GetInspectionById(int id)
        {
            Inspection inspection = _inspectionApiDbContext.Inspections.Where(i => i.Id == id)
              .FirstOrDefault();

            return inspection;
        }

        public bool RemoveInspection(int id)
        {
            Inspection removeInspection = _inspectionApiDbContext.Inspections.Where(i => i.Id == id)
                .FirstOrDefault();

            if (removeInspection != null)
            {
                _inspectionApiDbContext.Inspections.Remove(removeInspection);
                _inspectionApiDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateInspection(Inspection inspection)
        {
            if (inspection != null)
            {
                _inspectionApiDbContext.Inspections.Update(inspection);
                _inspectionApiDbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
