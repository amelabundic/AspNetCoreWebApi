using Application.Interfaces;
using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Persistence.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    //public class TokenService : ITokenService
    //{
    //    private readonly ITokenRepository _tokenRepository;
    //    public TokenService(ITokenRepository tokenRepository)
    //    {
    //        _tokenRepository = tokenRepository;
    //    }


    //    public TokenResponse GenerateRefreshToken(string userName)
    //    {
    //        return _tokenRepository.GenerateRefreshToken(userName);
    //    }

    //    public TokenResponse GenerateToken(string userName)
    //    {
    //        return _tokenRepository.GenerateToken(userName);
    //    }

    //    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    //    {
    //        return _tokenRepository.GetPrincipalFromExpiredToken(token);
    //    }
    //}
    }
