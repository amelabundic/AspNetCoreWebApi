using Domain;
using Persistence.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class StatusesRepository : IStatusesRepository
    {
        private readonly InspectionApiDbContext _inspectionApiDbContext;

        public StatusesRepository(InspectionApiDbContext inspectionApiDbContext)
        {
            this._inspectionApiDbContext = inspectionApiDbContext;    
        }

        public bool CreateStatus(Status statuses)
        {
            _inspectionApiDbContext.Add(statuses);
            _inspectionApiDbContext.SaveChanges();
            return true;    
        }

        public IList<Status> GetAllStatuses()
        {
            return _inspectionApiDbContext.Statuses.ToList();
        }

        public Status GetStatusById(int id)
        {
            Status statuses = _inspectionApiDbContext.Statuses.Where(s => s.Id == id).FirstOrDefault();

            return statuses;
        }

        public bool RemoveStatus(int id)
        {
            Status removedStatus = _inspectionApiDbContext.Statuses.Where(s => s.Id == id)
                .FirstOrDefault();

            if (removedStatus != null)
            {
                _inspectionApiDbContext.Statuses.Remove(removedStatus);
                _inspectionApiDbContext.SaveChanges();
                return true;
            }
            return false;

        }

        public bool UpdateStatus(Status statuses)
        {
            if (statuses != null)
            {
                _inspectionApiDbContext.Update(statuses);
                _inspectionApiDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
