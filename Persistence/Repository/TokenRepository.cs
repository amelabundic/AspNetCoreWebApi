using Domain;
using Domain.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Persistence.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TokenResponse = Domain.Models.TokenResponse;

namespace Persistence.Repository
{
    //public class TokenRepository : ITokenRepository
    //{
    //    private readonly InspectionApiDbContext _inspectionApiDbConterxt;
    //    private readonly IConfiguration _configuration;
    //    private readonly UserManager<User> userManager;
    //    private readonly RoleManager<IdentityRole> roleManager;
    //    private readonly SignInManager<User> signInManager;

    //    public TokenRepository(InspectionApiDbContext inspectionApiDbConterxt, IConfiguration _configuration, UserManager<User> _userManager, RoleManager<IdentityRole> _roleManager, SignInManager<User> _signInManager)
    //    {
    //        _inspectionApiDbConterxt = inspectionApiDbConterxt;
    //        this._configuration = _configuration;
    //        userManager = _userManager;
    //        roleManager = _roleManager;
    //        signInManager = _signInManager;
    //    }

    //    public TokenResponse GenerateToken(string userName)
    //    {
    //        return GenerateJWTTokens(userName);
    //    }

    //    public TokenResponse GenerateRefreshToken(string username)
    //    {
    //        return GenerateJWTTokens(username);
    //    }

    //    public TokenResponse GenerateJWTTokens(string userName)
    //    {
    //        try
    //        {
    //            var tokenHandler = new JwtSecurityTokenHandler();
    //            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
    //            var tokenDescriptor = new SecurityTokenDescriptor
    //            {
    //                Subject = new ClaimsIdentity(new Claim[]
    //              {
    //                 new Claim(ClaimTypes.Name, userName)
    //              }),
    //                Expires = DateTime.Now.AddMinutes(1),
    //                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
    //            };
    //            var token = tokenHandler.CreateToken(tokenDescriptor);
    //            var refreshToken = GenerateRefreshToken();
    //            return new TokenResponse { AccessToken = tokenHandler.WriteToken(token), RefreshToken = refreshToken };
    //        }
    //        catch (Exception)
    //        {
    //            return null;
    //        }
    //    }

    //    public string GenerateRefreshToken()
    //    {
    //        var randomNumber = new byte[32];
    //        using (var rng = RandomNumberGenerator.Create())
    //        {
    //            rng.GetBytes(randomNumber);
    //            return Convert.ToBase64String(randomNumber);
    //        }
    //    }

    //    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    //    {
            
    //        var Key = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            

    //        var tokenValidationParameters = new TokenValidationParameters
    //        {
    //            ValidateIssuer = false,
    //            ValidateAudience = false,
    //            ValidateLifetime = false,
    //            ValidateIssuerSigningKey = true,
    //            IssuerSigningKey = new SymmetricSecurityKey(Key),
    //            ClockSkew = TimeSpan.Zero
    //        };

    //        var tokenHandler = new JwtSecurityTokenHandler();
    //        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
    //        JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
    //        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
    //        {
    //            throw new SecurityTokenException("Invalid token");
    //        }


    //        return principal;
    //    }

    //}
}
    
