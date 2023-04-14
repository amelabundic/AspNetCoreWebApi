using Application.Interfaces;
using Domain;
using Persistence.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    //public class IdentityService : IIdentityService<User>
    //{
    //    public readonly IIdentityRepository<User> _identityRepository;

    //    public IdentityService(IIdentityRepository<User> identityRepository)
    //    {
    //        _identityRepository = identityRepository;
    //    }

    //    public Task<User> Create(User appUser)
    //    {
    //        try
    //        {
    //            if (appUser == null)
    //            {
    //                throw new ArgumentNullException(nameof(appUser));
    //            }
    //            else
    //            {
    //                return  _identityRepository.Create(appUser);
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }
    //    }

    //    public bool Delete(int id)
    //    {
    //        return _identityRepository.Delete(id);
    //    }

    //    public IList<User> GetAll()
    //    {
    //        return _identityRepository.GetAll();
    //    }

    //    //public User GetById(int id)
    //    //{
    //    //    return _identityRepository.GetById(id);
    //    //}

    //    public bool  Update(User user)
    //    {
    //        return _identityRepository.Update(user);
    //    }
    //}
}
