using Application.Interfaces;
using Domain;
using Persistence.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StatusesService : IStatusesService
    {
        private readonly IStatusesRepository _statusesRepository;

        public StatusesService(IStatusesRepository statusesRepository)
        {
            this._statusesRepository = statusesRepository;
        }

        public bool CreateStatus(Status statuses)
        {
            return _statusesRepository.CreateStatus(statuses);

        }

        public IList<Status> GetAllStatuses()
        {
            return _statusesRepository.GetAllStatuses();
        }

        public Status GetStatusById(int id)
        {
            return this._statusesRepository.GetStatusById(id);
        }

        public bool RemoveStatus(int id)
        {
            return _statusesRepository.RemoveStatus(id);
        }

        public bool UpdateStatus(Status statuses)
        {
            return _statusesRepository.UpdateStatus(statuses);
        }
    }
}
