using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IInspectorService
    {
        IList<InspectorResponse> GetAllInspector();

        bool CreateInspector(CreateInspectorReguest inspectorRequest);

        bool RemoveInspector(int id);

        bool UpdateInspector(UpdateInspectorRequest updateReguest);

        InspectorResponse GetInspectorById(int id);
    }
}
