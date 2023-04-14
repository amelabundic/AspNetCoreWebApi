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
    public class StatusesServiceGGG : IStatusesServiceGGG
    {
        private readonly IUnitOfWork _unitOfWork;
        public StatusesServiceGGG(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        public bool CreateStatus(Status statuses)
        {
            _unitOfWork.Status.Add(statuses);
            _unitOfWork.Save();
            return true;
        }

        public IList<Status> GetAllStatuses()
        {
            return _unitOfWork.Status.GetAllStatuses();
        }

        public Status GetStatusById(int id)
        {
            return _unitOfWork.Status.GetById(id);
        }

        public bool RemoveStatus(int id)
        {
            return _unitOfWork.Status.RemoveStatus(id);
        }

        public bool UpdateStatus(Status statuses)
        {
            return _unitOfWork.Status.UpdateStatus(statuses);
        }
    }
}
