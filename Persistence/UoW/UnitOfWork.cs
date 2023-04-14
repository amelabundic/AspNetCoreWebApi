using Persistence.IGenericRepository;
using Persistence.IRepository;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private InspectionApiDbContext _inspectionApiDbContext;
        public UnitOfWork(InspectionApiDbContext inspectionApiDbContext)
        {
            _inspectionApiDbContext = inspectionApiDbContext;
          
            Inspection = new InspectionRepositoryGGG(_inspectionApiDbContext);
            InspectionType = new InspectionTypesRepositoryGGG(_inspectionApiDbContext);
            Status = new StatusesRepositoryGGG(_inspectionApiDbContext);
        }
        public IInspectionRepositoryGGG Inspection { get; private set;}

        public IInspectionTypesRepositoryGGG InspectionType { get; private set; }

        public IStatusesRepositoryGGG Status { get; private set; }

        public void Dispose()
        {
            _inspectionApiDbContext.Dispose();
        }

        public int Save()
        {
           return _inspectionApiDbContext.SaveChanges();
        }
    }
}
