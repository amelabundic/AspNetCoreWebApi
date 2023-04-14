using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IGenericRepository
{
    public interface IInspectionTypesRepository
    {
        IList<InspectionType> GetAllInspectionTypes();

        bool CreateInspectionTypes(InspectionType inspectionType);

        bool RemoveInspectionTypes(int id);

        InspectionType GetInspectionTypesById(int id); 

        bool UpdateInspectionTypes(InspectionType inspectionTypes);
    }
}
