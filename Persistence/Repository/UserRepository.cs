using Domain;
using Domain.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Persistence.IGenericRepository;

namespace Persistence.Repository
{
    //public class UserRepository : IUserRepository
    //{
    //    private readonly UserManager<User> _userManager;
    //    private readonly InspectionApiDbContext _inspectionApiDbContext;

    //    public UserRepository(UserManager<User> userManager, InspectionApiDbContext inspectionApiDbContext)
    //    {
    //        this._userManager = userManager;
    //        this._inspectionApiDbContext = inspectionApiDbContext;
    //    }



    //    public UserRefreshToken AddUserRefreshTokens(UserRefreshToken user)
    //    {
    //        _inspectionApiDbContext.UserRefreshTokens.Add(user);
    //        return user;
    //    }

    //    public void DeleteUserRefreshTokens(string username, string refreshToken)
    //    {
    //        var item = _inspectionApiDbContext.UserRefreshTokens.FirstOrDefault(x => x.UserName == username && x.RefreshToken == refreshToken);
    //        if (item != null)
    //        {
    //            _inspectionApiDbContext.UserRefreshTokens.Remove(item);
    //        }
    //    }

    //    public UserRefreshToken GetSavedRefreshTokens(string username, string refreshToken)
    //    {
    //        return _inspectionApiDbContext.UserRefreshTokens.FirstOrDefault(x => x.UserName == username && x.RefreshToken == refreshToken && x.IsActive == true);
    //    }

    //    public int SaveCommit()
    //    {
    //        return _inspectionApiDbContext.SaveChanges();
    //    }

    //    public async Task<bool> IsValidUserAsync(User users)
    //    {
    //        var u = _userManager.Users.FirstOrDefault(o => o.UserName == users.Name);
    //        var result = await _userManager.CheckPasswordAsync(u, users.Password);
    //        return result;

    //    }
    //}
}

