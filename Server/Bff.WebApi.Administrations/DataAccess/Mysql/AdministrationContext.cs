using Bff.WebApi.Services.Administrations.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bff.WebApi.Services.Administrations.DataAccess.Mysql
{
    public class AdministrationContext : DbContext, IAdministrationContext
    {
        protected readonly IConfiguration Configuration;

        public AdministrationContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<User>? Users { get; set; }

        public async Task<User?> GetUser(string username, string password){
            return await Users?.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
    }
}
