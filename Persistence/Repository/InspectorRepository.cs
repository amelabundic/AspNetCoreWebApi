using Domain.Models;
using Persistence.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class InspectorRepository : IInspectorRepository
    {
        private readonly InspectionApiDbContext _inspectionApiDbContext;

        public InspectorRepository(InspectionApiDbContext inspectionApiDbContext)
        {
            _inspectionApiDbContext = inspectionApiDbContext;
        }

        public bool CreateInspector(Inspector inspector)
        {
            _inspectionApiDbContext.Add(inspector);
            _inspectionApiDbContext.SaveChanges();
            return true;
        }

        public IList<Inspector> GetAllInspector()
        {
           return _inspectionApiDbContext.Inspectors.ToList();
        }

        public Inspector GetInspectorById(int id)
        {
            Inspector inspector = _inspectionApiDbContext.Inspectors.Where(x => x.Id == id).FirstOrDefault();
            return inspector;
        }
        public bool RemoveInspector(int id)
        {
            Inspector inspector = _inspectionApiDbContext.Inspectors.Where(x => x.Id == id).FirstOrDefault();
            if (inspector != null)
            {
                 _inspectionApiDbContext.Inspectors.Remove(inspector);
                _inspectionApiDbContext.SaveChanges();
                return true;
            }
            return false;   
        }

        public bool UpdateInspector(Inspector inspector)
        {
            if (inspector !=null)
            {
                _inspectionApiDbContext.Inspectors.Update(inspector);
                _inspectionApiDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        
    }
}
