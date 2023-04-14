using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IInspectionServiceGGG
    {
        IList<Inspection> GetAllInspection();
        bool CreateInspection(Inspection inspection);
        bool RemoveInspection(int id);
        Inspection GetInspectionById(int id);
        bool UpdateInspection(Inspection inspection);
    }
}
