using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IStatusesServiceGGG
    {
        IList<Status> GetAllStatuses();
        bool CreateStatus(Status statuses);
        bool RemoveStatus(int id);
        Status GetStatusById(int id);
        bool UpdateStatus(Status statuses);
    }
}
