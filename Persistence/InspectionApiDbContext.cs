using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Persistence
{
    public class InspectionApiDbContext : IdentityDbContext<User>
    {
        public InspectionApiDbContext(DbContextOptions<InspectionApiDbContext> options) : base(options)
        {

        }

        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<InspectionType> InspectionTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Inspector> Inspectors { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }


       
    }
}
