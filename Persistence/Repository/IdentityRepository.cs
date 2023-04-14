using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Persistence.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    //public class IdentityRepository : IIdentityRepository<User>
    //{
    //    private readonly InspectionApiDbContext _inspectionApiDbContext;
    //    private readonly ILogger _logger;
    //    public IdentityRepository(ILogger<User> logger)
    //    {
    //        _logger = logger;
    //    }
    //    public async Task<User> Create(User appuser)
    //    {
    //        try
    //        {
    //            if (appuser != null)
    //            {
    //                var user = _inspectionApiDbContext.Add<User>(appuser);
    //                await _inspectionApiDbContext.SaveChangesAsync();
    //                return user.Entity;
    //            }
    //            else
    //            {
    //                return null;
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }
    //    }
    //    public bool Delete(int id)
    //    {
    //        try
    //        {
    //            if (id != null)
    //            {
    //                var user = _inspectionApiDbContext.Remove(id);
    //                if (user != null)
    //                {
    //                    _inspectionApiDbContext.SaveChangesAsync();
    //                    return true;
    //                }
    //            }
    //            return false;
    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }
    //    }
    //    public IList<User> GetAll()
    //    {
    //        try
    //        {
    //            var users = _inspectionApiDbContext.Users.ToList();
    //            if (users != null) return users;
    //            else return null;
    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }
    //    }
    //    //public User GetById(int id)
    //    //{
    //    //    try
    //    //    {
    //    //        if (id != null)
    //    //        {
    //    //            var user = _inspectionApiDbContext.Users.FirstOrDefault(x => x.Id == id);
    //    //            if (user != null) return user;
    //    //            else return null;
    //    //        }
    //    //        else
    //    //        {
    //    //            return null;
    //    //        }
    //    //    }
    //    //    catch (Exception)
    //    //    {
    //    //        throw;
    //    //    }
    //    //}
    //    public bool Update(User appuser)
    //    {
    //        try
    //        {
    //            if (appuser != null)
    //            {
    //                var user = _inspectionApiDbContext.Update(appuser);
    //                if (user != null) _inspectionApiDbContext.SaveChanges();
    //                return true;
    //            }
    //            return false;
    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }
    //    }

    //}
}
