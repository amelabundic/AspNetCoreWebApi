
using Application.AutoMapper;
using Application.Interfaces;
using Application.Mappers;
using Application.Services;
using Domain;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.IGenericRepository;
using Persistence.Repository;
using Persistence.UoW;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IInspectionServiceGGG, InspectionServiceGGG>();
builder.Services.AddScoped<IInspectionTypesServiceGGG, InspectionTypesServiceGGG>();
builder.Services.AddScoped<IStatusesServiceGGG, StatusesServiceGGG>();


//builder.Services.AddScoped<IInspectionService, InspectionService>();
//builder.Services.AddScoped<IInspectionTypesService, InspectionTypesService>();
//builder.Services.AddScoped<IStatusesService, StatusesService>();


builder.Services.AddScoped<IInspectionRepository, InspectionRepository>();
builder.Services.AddScoped<IInspectionTypesRepository, InspectionTypesRepository>();
builder.Services.AddScoped<IStatusesRepository, StatusesRepository>();

builder.Services.AddScoped<IInspectionResponseMapper, InspectionResponseMapper>();
builder.Services.AddScoped<IInspectionTypesResponseMapper, InspectionTypesResponseMapper>();
builder.Services.AddScoped<IStatusesResponseMapper, StatusResponseMapper>();
builder.Services.AddScoped<IIdentityResponseMapper, IdentityResponseMapper>();

//builder.Services.AddSingleton<IIdentityRepository<User>, IdentityRepository>();
//builder.Services.AddSingleton<IIdentityService<User>, IdentityService>();

//builder.Services.AddTransient<ITokenRepository, TokenRepository>();
//builder.Services.AddTransient<ITokenService, TokenService>();


//builder.Services.AddTransient<IUserRepository, UserRepository>();
//builder.Services.AddTransient<IUserService, UserService>();



builder.Services.AddTransient<IInspectorRepository, InspectorRepository>();
builder.Services.AddTransient<IInspectorService, InspectorService>();
builder.Services.AddAutoMapper(typeof(ApiMapping));



builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
        });
});


builder.Services.AddDbContext<InspectionApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


builder.Services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<InspectionApiDbContext>()
.AddDefaultTokenProviders();


builder.Services.AddAuthentication(x => {
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o => {
	var Key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
	o.SaveToken = true;
	o.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = false, // on production make it true
		ValidateAudience = false, // on production make it true
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = configuration["JWT:Issuer"],
		ValidAudience = configuration["JWT:Audience"],
		IssuerSigningKey = new SymmetricSecurityKey(Key),
		ClockSkew = TimeSpan.Zero
	};
	o.Events = new JwtBearerEvents
	{
		OnAuthenticationFailed = context => {
			if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
			{
				context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
			}
			return Task.CompletedTask;
		}
	};
});

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.SaveToken = true;
//    options.RequireHttpsMetadata = false;
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuerSigningKey = bool.Parse(builder.Configuration["JsonWebTokenKeys:ValidateIssuerSigningKey"]),
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JsonWebTokenKeys:IssuerSigningKey"])),
//        ValidateIssuer = bool.Parse(builder.Configuration["JsonWebTokenKeys:ValidateIssuer"]),
//        ValidAudience = builder.Configuration["JsonWebTokenKeys:ValidAudience"],
//        ValidIssuer = builder.Configuration["JsonWebTokenKeys:ValidIssuer"],
//        ValidateAudience = bool.Parse(builder.Configuration["JsonWebTokenKeys:ValidateAudience"]),
//        RequireExpirationTime = bool.Parse(builder.Configuration["JsonWebTokenKeys:RequireExpirationTime"]),
//        ValidateLifetime = bool.Parse(builder.Configuration["JsonWebTokenKeys:ValidateLifetime"])
//    };
//});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
