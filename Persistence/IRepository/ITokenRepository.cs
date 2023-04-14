using Domain;
using Domain.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TokenResponse = Domain.Models.TokenResponse;

namespace Persistence.IGenericRepository
{
    //public interface ITokenRepository
    //{
    //    TokenResponse GenerateToken(string userName);
    //    TokenResponse GenerateRefreshToken(string userName);
    //    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    //}
}
