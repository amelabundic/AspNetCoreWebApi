using Application.DTOs.Responses;
using Application.Interfaces;
using AutoMapper;
using Domain;

using Persistence.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    //public class UserService : IUserService
    //{
    //    private readonly IUserRepository _userRepository;

    //    public UserService(IUserRepository userRepository)
    //    {
    //        this._userRepository = userRepository;

    //    }

    //    public UserRefreshToken AddUserRefreshTokens(UserRefreshToken user)
    //    {
    //        return _userRepository.AddUserRefreshTokens(user);
    //    }

    //    public void DeleteUserRefreshTokens(string username, string refreshToken)
    //    {
    //        _userRepository.DeleteUserRefreshTokens(username, refreshToken);
    //    }

    //    public UserRefreshToken GetSavedRefreshTokens(string username, string refreshtoken)
    //    {
    //        return _userRepository.GetSavedRefreshTokens(username, refreshtoken);
    //    }

    //    public Task<bool> IsValidUserAsync(User users)
    //    {
    //        return _userRepository.IsValidUserAsync(users);
    //    }

    //    public int SaveCommit()
    //    {
    //        return _userRepository.SaveCommit();
    //    }

    //}
}
