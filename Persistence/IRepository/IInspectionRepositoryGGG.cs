using Domain.Models;
using Persistence.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IRepository
{
    public interface IInspectionRepositoryGGG : IGenericRepository<Inspection>
    {
        IList<Inspection> GetAllInspection();
        bool CreateInspection(Inspection inspection);
        bool RemoveInspection(int id);
        Inspection GetInspectionById(int id);
        bool UpdateInspection(Inspection inspection);
    }
}
