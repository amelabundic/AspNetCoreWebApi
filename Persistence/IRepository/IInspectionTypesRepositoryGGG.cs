using Domain.Models;
using Persistence.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IRepository
{
    public interface IInspectionTypesRepositoryGGG : IGenericRepository<InspectionType>
    {
        IList<InspectionType> GetAllInspectionTypes();

        bool CreateInspectionTypes(InspectionType inspectionType);

        bool RemoveInspectionTypes(int id);

        InspectionType GetInspectionTypesById(int id);

        bool UpdateInspectionTypes(InspectionType inspectionTypes);
    }
}
