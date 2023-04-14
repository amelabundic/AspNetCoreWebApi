using Microsoft.EntityFrameworkCore;
using Persistence.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly InspectionApiDbContext _inspectionApiDbContext;
        public GenericRepository(InspectionApiDbContext _inspectionApiDbContext)
        {
            _inspectionApiDbContext = _inspectionApiDbContext;
        }

        public void Add(T entity)
        {
            _inspectionApiDbContext.Set<T>().Add(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _inspectionApiDbContext.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _inspectionApiDbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _inspectionApiDbContext.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _inspectionApiDbContext.Set<T>().Remove(entity);
        }
    }
}
