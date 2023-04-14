using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IGenericRepository
{
    public interface IInspectorRepository
    {
        IList<Inspector> GetAllInspector();

        bool CreateInspector(Inspector inspector);

        bool RemoveInspector(int id);

        bool UpdateInspector(Inspector inspector);

        Inspector GetInspectorById(int id);
      
    }
}
