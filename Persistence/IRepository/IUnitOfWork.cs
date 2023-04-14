using Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IGenericRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IInspectionRepositoryGGG Inspection { get; }
        IInspectionTypesRepositoryGGG InspectionType { get; }
        IStatusesRepositoryGGG Status { get; }
        int Save();
    }
}
