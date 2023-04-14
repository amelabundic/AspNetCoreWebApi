using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class InspectionRepository : IInspectionRepository
    {
        private readonly InspectionApiDbContext? _inspectionApiDbContext;

        public InspectionRepository(InspectionApiDbContext inspectionApiDbContext)
        {
            this._inspectionApiDbContext = inspectionApiDbContext;
        }

       public IList<Inspection> GetAllInspection()
       {
            return _inspectionApiDbContext.Inspections
                .Include(x => x.InspectionType).ToList<Inspection>();
       }


       public bool CreateInspection(Inspection inspection)
        {
             _inspectionApiDbContext.Add(inspection);
            _inspectionApiDbContext.SaveChanges();
            return true;
        }


        public bool RemoveInspection(int id)
        {
            Inspection removeInspection = _inspectionApiDbContext.Inspections.Where(i => i.Id == id)
                .FirstOrDefault();

            if (removeInspection != null)
            {
                _inspectionApiDbContext.Inspections.Remove(removeInspection);
                _inspectionApiDbContext.SaveChanges();
                return true;
        }
            return false;
        }

        public Inspection GetInspectionById(int id)
        {

                Inspection inspection = _inspectionApiDbContext.Inspections.Where(i => i.Id == id) 
                .FirstOrDefault();
           
            return inspection;
        }


        //public bool UpdateInspection(Inspection inspection)
        //{
        //   Inspection removeInspection = _inspectionApiDbContext.Inspections.Where(i => i.Id == id)
        //        .FirstOrDefault();

        //    if (removeInspection != null)
        //    {
        //        _inspectionApiDbContext.Inspections.Remove(removeInspection);
        //        _inspectionApiDbContext.SaveChanges();
        //        return true;
        //}
        //    return false;
        //}
    }
}
