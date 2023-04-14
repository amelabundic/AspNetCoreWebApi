using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces;
using Application.Mappers;
using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InspectionAPI.Controllers
{
	//[Authorize]
	//[Route("api/[controller]")]
 //   [ApiController]
 //   public class UserController : ControllerBase
 //   {
 //       private readonly IUserService _userService;
 //       private readonly ITokenService _tokenService;
 //       private readonly IIdentityService<User> _identityService;

 //       private readonly UserManager<User> userManager;
 //       private readonly RoleManager<IdentityRole> roleManager;
 //       private readonly IConfiguration _configuration;
 //       private readonly SignInManager<User> signInManager;



 //       public UserController(IUserService userService, ITokenService tokenService, IIdentityService<User> identityService, UserManager<User> _userManager, RoleManager<IdentityRole> _roleManager, IConfiguration configuration, SignInManager<User> _signInManager)
 //       {
 //           _userService = userService;
 //           _tokenService = tokenService;
 //           _identityService = identityService;
 //           userManager = _userManager;
 //           roleManager = _roleManager;
 //           _configuration = configuration;
 //           signInManager = _signInManager;
 //       }


 //       [AllowAnonymous]
 //       [HttpPost]
 //       [Route("Register")]
 //       public async Task<IActionResult> Register([FromBody] RegisterRequest reguest)
 //       {
 //           var IsExist = await userManager.FindByNameAsync(reguest.Name);
 //           if (IsExist != null) return StatusCode(StatusCodes.Status500InternalServerError, new IdentityResponse
 //           {
 //               Status = "Error",
 //               Message = "User already exists!"
 //           });
 //           User user = new User
 //           {
 //               UserName = reguest.Name,
 //               Email = reguest.Email,
 //               PhoneNumber = reguest.PhoneNumber,
 //               Password = reguest.Password,
 //               UserRole = reguest.UserRole,
 //           };

 //           var result = await userManager.CreateAsync(/*user*/user, reguest.Password);
 //           if (!result.Succeeded) return StatusCode(StatusCodes.Status500InternalServerError, new IdentityResponse
 //           {
 //               Status = "Error",
 //               Message = "User creation failed! Please check user details and try again."
 //           });
 //           if (!await roleManager.RoleExistsAsync(reguest.UserRole)) await roleManager.CreateAsync(new IdentityRole(reguest.UserRole));
 //           if (await roleManager.RoleExistsAsync(reguest.UserRole))
 //           {
 //               await userManager.AddToRoleAsync(user, reguest.UserRole);
 //           }
 //           return Ok(new IdentityResponse
 //           {
 //               Status = "Success",
 //               Message = "User created successfully!"
 //           });
 //       }

 //       [AllowAnonymous]
 //       [HttpPost]
 //       [Route("Login")]
 //       public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
 //       {
 //           //var user1 = await userManager.FindByIdAsync(loginRequest.Id);
 //           var user = await userManager.FindByNameAsync(loginRequest.UserName);
 //           if (user != null && await userManager.CheckPasswordAsync(user, loginRequest.Password))
 //           {
 //               var userRoles = await userManager.GetRolesAsync(user);
 //               var authClaims = new List<Claim> {
 //                   new Claim(ClaimTypes.Name, user.UserName),
 //                   new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
 //                   new Claim(ClaimTypes.Email, user.Email),

 //                   new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
 //               };
 //               foreach (var userRole in userRoles)
 //               {
 //                   authClaims.Add(new Claim(ClaimTypes.Role, userRole));
 //               }
   
 //               var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

 //               var token = new JwtSecurityToken(expires: DateTime.Now.AddMinutes(1), claims: authClaims, signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));
 //               return Ok(new
 //               {
 //                   token = new JwtSecurityTokenHandler().WriteToken(token),
 //                   expiration = token.ValidTo,
 //                   user = user,
 //                   Role = userRoles,

 //                   status = "User Login Successfully"

 //               });


 //           }
 //           return Unauthorized();
 //       }

 //       [AllowAnonymous]
 //       [HttpPost]
 //       [Route("RegisterAdmin")]
 //       public async Task<IActionResult> RegisterAdmin([FromBody] RegisterRequest reguest)
 //       {
 //           var IsExist = await userManager.FindByNameAsync(reguest.Name);
 //           if (IsExist != null) return StatusCode(StatusCodes.Status500InternalServerError, new IdentityResponse
 //           {
 //               Status = "Error",
 //               Message = "User already exists!"
 //           });
 //           User user = new User
 //           {
 //               UserName = reguest.Name,
 //               Email = reguest.Email,
 //               PhoneNumber = reguest.PhoneNumber,
 //               Password = reguest.Password,
 //               UserRole = reguest.UserRole, 
 //           };

 //           var result = await userManager.CreateAsync(user, reguest.Password);
 //           if (!result.Succeeded) return StatusCode(StatusCodes.Status500InternalServerError, new IdentityResponse
 //           {
 //               Status = "Error",
 //               Message = "User creation failed! Please check user details and try again."
 //           });
 //           if (!await roleManager.RoleExistsAsync(reguest.UserRole)) await roleManager.CreateAsync(new IdentityRole(reguest.UserRole));
 //           if (await roleManager.RoleExistsAsync(reguest.UserRole))
 //           {
 //               await userManager.AddToRoleAsync(user, reguest.UserRole);
 //           }

 //           if (!await roleManager.RoleExistsAsync(UserRole.Admin))
 //           {
 //               await roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
 //           }

 //           if (!await roleManager.RoleExistsAsync(UserRole.User))
 //           {
 //               await roleManager.CreateAsync(new IdentityRole(UserRole.User));
 //           }

 //           if (await roleManager.RoleExistsAsync(UserRole.Admin))
 //           {
 //               await userManager.AddToRoleAsync(user, UserRole.Admin);
 //           }
 //           return Ok(new IdentityResponse
 //           {
 //               Status = "Success",
 //               Message = "Admin created successfully!"
 //           });
 //       }


 //       [AllowAnonymous]
 //       [HttpPost]
 //       [Route("authenticate")]

 //       public async Task<IActionResult> AuthenticateAsync(User usersdata)
 //       {
 //           var validUser = await _userService.IsValidUserAsync(usersdata);

 //           if (!validUser)
 //           {
 //               return Unauthorized("Incorrect username or password!");
 //           }

 //           var token = _tokenService.GenerateToken(usersdata.Name);

 //           if (token == null)
 //           {
 //               return Unauthorized("Invalid Attempt!");
 //           }

 //           // spasavam refreshToken u db
 //           UserRefreshToken obj = new UserRefreshToken
 //           {
 //               RefreshToken = token.RefreshToken,
 //               UserName = usersdata.Name,
              
 //           };

 //           _userService.AddUserRefreshTokens(obj);
 //           _userService.SaveCommit();
 //           return Ok(token);
 //       }


        


 //       [AllowAnonymous]
 //       [HttpPost]
 //       [Route("refresh")]
 //       public IActionResult Refresh(Tokens token)
 //       {
 //           var principal = _tokenService.GetPrincipalFromExpiredToken(token.AccessToken);
 //           var username = principal.Identity?.Name;

 //           //spašeni refreshtokeni u bazi
 //           var savedRefreshToken = _userService.GetSavedRefreshTokens(username, token.RefreshToken);

 //           if (savedRefreshToken.RefreshToken != token.RefreshToken)
 //           {
 //               return Unauthorized("Invalid attempt!");
 //           }

 //           var newJwtToken = _tokenService.GenerateRefreshToken(username);

 //           if (newJwtToken == null)
 //           {
 //               return Unauthorized("Invalid attempt!");
 //           }

 //           // spasavam token u bazu
 //           UserRefreshToken obj = new UserRefreshToken
 //           {
 //               RefreshToken = newJwtToken.RefreshToken,
 //               UserName = username
 //           };

 //           _userService.DeleteUserRefreshTokens(username, token.RefreshToken);
 //           _userService.AddUserRefreshTokens(obj);
 //           _userService.SaveCommit();

 //           return Ok(newJwtToken);
 //       }
 //   }

}

